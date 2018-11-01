using RoadFlow.Platform;
using RoadFlow.Platform.WeiXin;
using RoadFlow.Utility;
using System;
using System.IO;
using System.Web;
using System.Web.SessionState;
using WebMvc.Common;

namespace WebMvc.Content
{
	public class Show : IHttpHandler, IReadOnlySessionState, IRequiresSessionState
	{
		public bool IsReusable
		{
			get
			{
				return false;
			}
		}

		public void ProcessRequest(HttpContext context)
		{
			context.Response.Cache.VaryByParams["SkipGlobalExpires"] = true;
			context.Response.Cache.SetExpires(DateTime.Now.AddSeconds(10.0));
			context.Response.ContentType = "text/plain";
			string msg;
			if (!WebMvc.Common.Tools.CheckLogin(out msg) && !RoadFlow.Platform.WeiXin.Organize.CheckLogin())
			{
				context.Response.Write("您未登录,不能查看文件!");
				context.Response.End();
			}
			else
			{
				FileInfo fileInfo = new FileInfo(context.Request.QueryString["id"].DesDecrypt());
				if (!fileInfo.Exists)
				{
					context.Response.Write("未找到要查看的文件!");
				}
				else if (!("," + RoadFlow.Utility.Config.UploadFileType + ",").Contains("," + fileInfo.Extension.Replace(".", "") + ","))
				{
					context.Response.Write("该文件类型不允许查看!");
				}
				else
				{
					string text = fileInfo.Name;
					if (context.Request != null && context.Request.Browser != null && (context.Request.Browser.Type.StartsWith("IE", StringComparison.CurrentCultureIgnoreCase) || context.Request.Browser.Type.StartsWith("InternetExplorer", StringComparison.CurrentCultureIgnoreCase)))
					{
						text = text.UrlEncode();
					}
					context.Response.AppendHeader("Server-FileName", text);
					string text2 = ",.zip,.rar,.7z,".Contains("," + fileInfo.Extension + ",", StringComparison.CurrentCultureIgnoreCase) ? "" : new Files().GetFileContentType(fileInfo.Extension);
					if (string.IsNullOrEmpty(text2))
					{
						context.Response.ContentType = "application/octet-stream";
						context.Response.AppendHeader("Content-Disposition", "attachment; filename=" + text);
					}
					else
					{
						context.Response.ContentType = text2;
						context.Response.AppendHeader("Content-Disposition", "inline; filename=" + text);
					}
					context.Response.AddHeader("Content-Length", fileInfo.Length.ToString());
					using (FileStream fileStream = fileInfo.OpenRead())
					{
						byte[] array = new byte[2048];
						int num = fileStream.Read(array, 0, array.Length);
						while (num > 0 && context.Response.IsClientConnected)
						{
							context.Response.OutputStream.Write(array, 0, num);
							context.Response.Flush();
							num = fileStream.Read(array, 0, array.Length);
						}
					}
					context.Response.Flush();
					context.Response.OutputStream.Close();
				}
			}
		}
	}
}
