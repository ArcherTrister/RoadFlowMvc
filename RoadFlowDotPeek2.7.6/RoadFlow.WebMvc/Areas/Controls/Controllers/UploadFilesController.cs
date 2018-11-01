// Decompiled with JetBrains decompiler
// Type: WebMvc.Areas.Controls.Controllers.UploadFilesController
// Assembly: WebMvc, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 43FD7615-6DC3-49FB-B263-7F7CC91AFA77
// Assembly location: C:\inetpub\wwwroot\RoadFlowMvc\bin\WebMvc.dll

using RoadFlow.Cache.IO;
using RoadFlow.Utility;
using System;
using System.IO;
using System.Web;
using System.Web.Mvc;

namespace WebMvc.Areas.Controls.Controllers
{
  public class UploadFilesController : Controller
  {
    public ActionResult Index()
    {
      return (ActionResult) this.View();
    }

    public ActionResult Index_App()
    {
      return (ActionResult) this.View();
    }

    public string Upload()
    {
      this.Response.ContentType = "text/plain";
      string str1 = this.Request.Form["filetype"];
      if (!WebMvc.Common.Tools.CheckLogin(false))
        return "您不能上传文件";
      HttpPostedFileBase file = this.Request.Files["Filedata"];
      if (str1.IsNullOrEmpty())
      {
        if (!RoadFlow.Utility.Config.UploadFileType.Contains(Path.GetExtension(file.FileName).TrimStart('.'), StringComparison.CurrentCultureIgnoreCase))
          return "您上传的文件类型不被允许";
      }
      else if (!str1.Contains(Path.GetExtension(file.FileName).TrimStart('.'), StringComparison.CurrentCultureIgnoreCase))
        return "您上传的文件类型不被允许";
      string path1;
      string str2 = this.Server.MapPath(this.getFilePath(out path1));
      if (file == null)
        return "上传文件为空";
      if (!Directory.Exists(str2))
        Directory.CreateDirectory(str2);
      string fileName = this.getFileName(str2, file.FileName);
      string filename = str2 + fileName;
      try
      {
        int contentLength = file.ContentLength;
        file.SaveAs(filename);
        return "1|" + path1 + fileName + "|" + (contentLength / 1000).ToString("###,###") + "|" + fileName;
      }
      catch
      {
        return "上传文件发生了错误";
      }
    }

    private string getFileName(string filePath, string fileName)
    {
      while (File.Exists(filePath + fileName))
        fileName = Path.GetFileNameWithoutExtension(fileName) + "_" + RoadFlow.Utility.Tools.GetRandomString(5) + Path.GetExtension(fileName);
      return fileName;
    }

    private string getFilePath(out string path1)
    {
      DateTime now = DateTimeNew.Now;
      path1 = this.Url.Content("~/Content/UploadFiles/" + now.ToString("yyyyMM") + "/" + now.ToString("dd") + "/");
      return path1;
    }

    public string Delete()
    {
      string key = this.Request.QueryString["str1"];
      string str1 = this.Request.QueryString["str2"];
      if (key == null)
        key = "";
      Opation.Get(key);
      if (!WebMvc.Common.Tools.CheckLogin(false))
        return "var json = {\"success\":0,\"message\":\"您不能删除文件\"}";
      string str2 = this.Request.QueryString["file"];
      if (str2.IsNullOrEmpty())
        return "";
      try
      {
        File.Delete(this.Server.MapPath(Path.Combine(this.Url.Content("~/Content/Controls/UploadFiles/"), str2)));
        return "var json = {\"success\":1,\"message\":\"\"}";
      }
      catch (Exception ex)
      {
        return "var json = {\"success\":0,\"message\":\"" + ex.Message + "\"}";
      }
    }
  }
}
