using RoadFlow.Data.Model;
using RoadFlow.Platform;
using RoadFlow.Platform.WeiXin;
using RoadFlow.Utility;
using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using System.Web;
using System.Web.Mvc;
using WebMvc.Common;

namespace WebMvc.Controllers
{
	public class FilesController : MyController
	{
		[MyAttribute(CheckApp = false)]
		public ActionResult Index()
		{
			return View();
		}

		[MyAttribute(CheckApp = false)]
		public ActionResult Tree()
		{
			return View();
		}

		[MyAttribute(CheckApp = false)]
		public ActionResult List()
		{
			return List(null);
		}

		[HttpPost]
		[ValidateAntiForgeryToken]
		[MyAttribute(CheckApp = false)]
		public ActionResult List(FormCollection collection)
		{
			string text = (base.Request.QueryString["id"] ?? "").DesDecrypt();
			string text2 = string.Empty;
			string empty = string.Empty;
			RoadFlow.Platform.Files files = new RoadFlow.Platform.Files();
			string empty2 = string.Empty;
			if (text.IsNullOrEmpty() || !Directory.Exists(text))
			{
				base.Response.Write("目录为空或不存在!");
				base.Response.End();
				return null;
			}
			empty = files.GetUserRootPath(RoadFlow.Platform.Users.CurrentUserID);
			if (!text.Equals(empty, StringComparison.CurrentCultureIgnoreCase))
			{
				text2 = Directory.GetParent(text).FullName;
			}
			empty2 = "&appid=" + base.Request.QueryString["appid"] + "&isselect=" + base.Request.QueryString["isselect"] + "&eid=" + base.Request.QueryString["eid"] + "&files=" + base.Request.QueryString["files"] + "&filetype=" + base.Request.QueryString["filetype"] + "&iframeid=" + base.Request.QueryString["iframeid"];
			if (collection != null)
			{
				string b = base.Request.Form["operation"];
				if ("0" == b)
				{
					string str = text2.IsNullOrEmpty() ? empty : text2;
					string text3 = files.Delete(text);
					base.ViewBag.script = "alert('" + (text3.IsNullOrEmpty() ? "删除成功!" : text3) + "');window.location='List?id=" + str.DesEncrypt() + empty2 + "';";
				}
				else if ("1" == b)
				{
					string obj = base.Request.Form["file"] ?? "";
					StringBuilder stringBuilder = new StringBuilder();
					string[] array = obj.Split(',');
					foreach (string str2 in array)
					{
						stringBuilder.Append(files.Delete(str2.DesDecrypt()));
					}
					string str3 = text2.IsNullOrEmpty() ? empty : text2;
					base.ViewBag.script = "alert('" + ((stringBuilder.Length == 0) ? "删除成功!" : stringBuilder.ToString()) + "');window.location='List?id=" + str3.DesEncrypt() + empty2 + "';";
				}
			}
			base.ViewBag.ParentDir = text2;
			base.ViewBag.dir = text;
			base.ViewBag.RootDir = empty;
			base.ViewBag.Query = empty2;
			List<RoadFlow.Data.Model.Files> list = files.GetList(text);
			return View(list);
		}

		[MyAttribute(CheckApp = false)]
		public string Tree1()
		{
			return "[" + new RoadFlow.Platform.Files().GetUserDirectoryJson(RoadFlow.Platform.Users.CurrentUserID, "", true) + "]";
		}

		[MyAttribute(CheckApp = false)]
		public string TreeRefresh()
		{
			string str = base.Request.QueryString["refreshid"];
			if (str.IsNullOrEmpty())
			{
				return "[]";
			}
			return new RoadFlow.Platform.Files().GetUserDirectoryJson(RoadFlow.Platform.Users.CurrentUserID, str.DesDecrypt());
		}

		[MyAttribute(CheckApp = false)]
		public ActionResult Dir_Add()
		{
			return Dir_Add(null);
		}

		[HttpPost]
		[ValidateAntiForgeryToken]
		[MyAttribute(CheckApp = false)]
		public ActionResult Dir_Add(FormCollection collection)
		{
			string text = (base.Request.QueryString["id"] ?? "").DesDecrypt();
			if (text.IsNullOrEmpty() || !Directory.Exists(text))
			{
				base.Response.Write("目录为空或不存在!");
				base.Response.End();
				return null;
			}
			if (collection != null)
			{
				string dirName = base.Request.Form["DirName"];
				if (new RoadFlow.Platform.Files().CreateDirectory(text, dirName))
				{
					base.ViewBag.script = "alert('添加成功!');parent.frames[0].reLoad('" + base.Request.QueryString["id"] + "');window.location='List" + base.Request.Url.Query + "';";
				}
				else
				{
					base.ViewBag.script = "alert('添加失败!')";
				}
			}
			return View();
		}

		[MyAttribute(CheckApp = false)]
		public ActionResult File_Add()
		{
			return View();
		}

		[MyAttribute(CheckApp = false, CheckUrl = false, CheckLogin = false)]
		public string FileUpload()
		{
			string msg;
			if (!WebMvc.Common.Tools.CheckLogin(out msg) && !RoadFlow.Platform.WeiXin.Organize.CheckLogin())
			{
				return "";
			}
			new RoadFlow.Platform.Files();
			string empty = string.Empty;
			string empty2 = string.Empty;
			base.Response.ContentEncoding = Encoding.UTF8;
			empty = base.Request.Form["dir"].DesDecrypt();
			if (RoadFlow.Platform.Users.CurrentUserID.IsEmptyGuid())
			{
				return "";
			}
			if (empty.IsNullOrEmpty())
			{
				return "";
			}
			if (base.Request["REQUEST_METHOD"] == "OPTIONS")
			{
				return "";
			}
			empty2 = RoadFlow.Utility.Config.UploadFileType;
			string text = empty.EndsWith("\\") ? empty : (empty + "\\");
			HttpFileCollection files = System.Web.HttpContext.Current.Request.Files;
			if (!Directory.Exists(text))
			{
				Directory.CreateDirectory(text);
			}
			string arg = files[0].ContentType.Split('/')[1];
			string text2 = System.Web.HttpContext.Current.Request["name"];
			string str = string.IsNullOrEmpty(text2) ? (new Random(24 * (int)DateTime.Now.Ticks).Next() + "." + arg) : text2;
			string text3 = text + str;
			if (System.IO.File.Exists(text3))
			{
				string fileNameWithoutExtension = Path.GetFileNameWithoutExtension(text3);
				string extension = Path.GetExtension(text3);
				text3 = text + fileNameWithoutExtension + "(" + RoadFlow.Utility.Tools.GetRandomString() + ")" + extension;
			}
			string str2 = Path.GetExtension(text3).Replace(".", "");
			if (!("," + empty2 + ",").Contains("," + str2 + ",", StringComparison.CurrentCultureIgnoreCase))
			{
				return "{\"jsonrpc\":\"2.0\",\"error\":\"不允许的文件\",\"id\":\"" + str + "\"}";
			}
			files[0].SaveAs(text3);
			string text4 = text3.Replace1(new RoadFlow.Platform.Files().GetRootPath(), "").DesEncrypt();
			decimal num = decimal.Round(files[0].ContentLength / 1024, 0);
			string text5 = (!(num == decimal.Zero)) ? num.ToFormatString() : ((files[0].ContentLength > 0) ? "1" : "0");
			return "{\"jsonrpc\" : \"2.0\", \"result\" : null, \"id\" : \"" + text3.DesEncrypt() + "\", \"id1\":\"" + text4 + "\",\"size\":\"" + text5 + "KB\"}";
		}

		[MyAttribute(CheckApp = false)]
		public void Show()
		{
			string msg;
			if (!WebMvc.Common.Tools.CheckLogin(out msg) && !RoadFlow.Platform.WeiXin.Organize.CheckLogin())
			{
				base.Response.End();
			}
			else
			{
				FileInfo fileInfo = new FileInfo(base.Request.QueryString["id"].DesDecrypt());
				if (!fileInfo.Exists)
				{
					base.Response.Write("未找到要查看的文件!");
				}
				else if (!("," + RoadFlow.Utility.Config.UploadFileType + ",").Contains("," + fileInfo.Extension.Replace(".", "") + ",", StringComparison.CurrentCultureIgnoreCase))
				{
					base.Response.Write("该文件类型不允许查看!");
				}
				else
				{
					string text = fileInfo.Name;
					if (base.Request != null && base.Request.Browser != null && (base.Request.Browser.Type.StartsWith("IE", StringComparison.CurrentCultureIgnoreCase) || base.Request.Browser.Type.StartsWith("InternetExplorer", StringComparison.CurrentCultureIgnoreCase)))
					{
						text = text.UrlEncode();
					}
					base.Response.AppendHeader("Server-FileName", text);
					string text2 = ",.zip,.rar,.7z,".Contains("," + fileInfo.Extension + ",", StringComparison.CurrentCultureIgnoreCase) ? "" : new RoadFlow.Platform.Files().GetFileContentType(fileInfo.Extension);
					if (string.IsNullOrEmpty(text2))
					{
						base.Response.ContentType = "application/octet-stream";
						base.Response.AppendHeader("Content-Disposition", "attachment; filename=" + text);
					}
					else
					{
						base.Response.ContentType = text2;
						base.Response.AppendHeader("Content-Disposition", "inline; filename=" + text);
					}
					base.Response.AddHeader("Content-Length", fileInfo.Length.ToString());
					using (FileStream fileStream = fileInfo.OpenRead())
					{
						byte[] array = new byte[2048];
						int num = fileStream.Read(array, 0, array.Length);
						while (num > 0 && base.Response.IsClientConnected)
						{
							base.Response.OutputStream.Write(array, 0, num);
							base.Response.Flush();
							num = fileStream.Read(array, 0, array.Length);
						}
					}
					base.Response.Flush();
					base.Response.OutputStream.Close();
					base.Response.Output.Close();
				}
			}
		}

		[MyAttribute(CheckApp = false, CheckUrl = false, CheckLogin = false)]
		public string GetShowString()
		{
			string msg;
			if (!WebMvc.Common.Tools.CheckLogin(out msg) && !RoadFlow.Platform.WeiXin.Organize.CheckLogin())
			{
				return "";
			}
			return RoadFlow.Platform.Files.GetFilesShowString(base.Request["files"], WebMvc.Common.Tools.BaseUrl + "/Content/Show.ashx");
		}
	}
}
