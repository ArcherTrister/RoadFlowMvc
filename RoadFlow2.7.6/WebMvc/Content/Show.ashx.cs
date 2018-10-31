// Decompiled with JetBrains decompiler
// Type: WebMvc.Content.Show
// Assembly: WebMvc, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 43FD7615-6DC3-49FB-B263-7F7CC91AFA77
// Assembly location: C:\inetpub\wwwroot\RoadFlowMvc\bin\WebMvc.dll

using RoadFlow.Platform;
using System;
using System.IO;
using System.Web;
using System.Web.SessionState;

namespace WebMvc.Content
{
  public class Show : IHttpHandler, IReadOnlySessionState, IRequiresSessionState
  {
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
          context.Response.Write("未找到要查看的文件!");
        else if (!("," + RoadFlow.Utility.Config.UploadFileType + ",").Contains("," + fileInfo.Extension.Replace(".", "") + ","))
        {
          context.Response.Write("该文件类型不允许查看!");
        }
        else
        {
          string str1 = fileInfo.Name;
          if (context.Request != null && context.Request.Browser != null && (context.Request.Browser.Type.StartsWith("IE", StringComparison.CurrentCultureIgnoreCase) || context.Request.Browser.Type.StartsWith("InternetExplorer", StringComparison.CurrentCultureIgnoreCase)))
            str1 = str1.UrlEncode();
          context.Response.AppendHeader("Server-FileName", str1);
          string str2 = ",.zip,.rar,.7z,".Contains("," + fileInfo.Extension + ",", StringComparison.CurrentCultureIgnoreCase) ? "" : new Files().GetFileContentType(fileInfo.Extension);
          if (string.IsNullOrEmpty(str2))
          {
            context.Response.ContentType = "application/octet-stream";
            context.Response.AppendHeader("Content-Disposition", "attachment; filename=" + str1);
          }
          else
          {
            context.Response.ContentType = str2;
            context.Response.AppendHeader("Content-Disposition", "inline; filename=" + str1);
          }
          context.Response.AddHeader("Content-Length", fileInfo.Length.ToString());
          using (FileStream fileStream = fileInfo.OpenRead())
          {
            byte[] buffer = new byte[2048];
            for (int count = fileStream.Read(buffer, 0, buffer.Length); count > 0; count = fileStream.Read(buffer, 0, buffer.Length))
            {
              if (context.Response.IsClientConnected)
              {
                context.Response.OutputStream.Write(buffer, 0, count);
                context.Response.Flush();
              }
              else
                break;
            }
          }
          context.Response.Flush();
          context.Response.OutputStream.Close();
        }
      }
    }

    public bool IsReusable
    {
      get
      {
        return false;
      }
    }
  }
}
