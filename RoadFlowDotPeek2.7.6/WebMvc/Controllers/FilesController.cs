// Decompiled with JetBrains decompiler
// Type: WebMvc.Controllers.FilesController
// Assembly: WebMvc, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 43FD7615-6DC3-49FB-B263-7F7CC91AFA77
// Assembly location: C:\inetpub\wwwroot\RoadFlowMvc\bin\WebMvc.dll

using Microsoft.CSharp.RuntimeBinder;
using RoadFlow.Platform;
using System;
using System.Collections.Generic;
using System.IO;
using System.Runtime.CompilerServices;
using System.Text;
using System.Web;
using System.Web.Mvc;

namespace WebMvc.Controllers
{
  public class FilesController : MyController
  {
    [MyAttribute(CheckApp = false)]
    public ActionResult Index()
    {
      return (ActionResult) this.View();
    }

    [MyAttribute(CheckApp = false)]
    public ActionResult Tree()
    {
      return (ActionResult) this.View();
    }

    [MyAttribute(CheckApp = false)]
    public ActionResult List()
    {
      return this.List((FormCollection) null);
    }

    [HttpPost]
    [ValidateAntiForgeryToken]
    [MyAttribute(CheckApp = false)]
    public ActionResult List(FormCollection collection)
    {
      string str1 = (this.Request.QueryString["id"] ?? "").DesDecrypt();
      string str2 = string.Empty;
      string empty1 = string.Empty;
      Files files = new Files();
      string empty2 = string.Empty;
      if (str1.IsNullOrEmpty() || !Directory.Exists(str1))
      {
        this.Response.Write("目录为空或不存在!");
        this.Response.End();
        return (ActionResult) null;
      }
      string userRootPath = files.GetUserRootPath(Users.CurrentUserID);
      if (!str1.Equals(userRootPath, StringComparison.CurrentCultureIgnoreCase))
        str2 = Directory.GetParent(str1).FullName;
      string str3 = "&appid=" + this.Request.QueryString["appid"] + "&isselect=" + this.Request.QueryString["isselect"] + "&eid=" + this.Request.QueryString["eid"] + "&files=" + this.Request.QueryString["files"] + "&filetype=" + this.Request.QueryString["filetype"] + "&iframeid=" + this.Request.QueryString["iframeid"];
      if (collection != null)
      {
        string str4 = this.Request.Form["operation"];
        if ("0" == str4)
        {
          string str5 = str2.IsNullOrEmpty() ? userRootPath : str2;
          string str6 = files.Delete(str1);
          // ISSUE: reference to a compiler-generated field
          if (FilesController.\u003C\u003Eo__3.\u003C\u003Ep__0 == null)
          {
            // ISSUE: reference to a compiler-generated field
            FilesController.\u003C\u003Eo__3.\u003C\u003Ep__0 = CallSite<Func<CallSite, object, string, object>>.Create(Binder.SetMember(CSharpBinderFlags.None, "script", typeof (FilesController), (IEnumerable<CSharpArgumentInfo>) new CSharpArgumentInfo[2]
            {
              CSharpArgumentInfo.Create(CSharpArgumentInfoFlags.None, (string) null),
              CSharpArgumentInfo.Create(CSharpArgumentInfoFlags.UseCompileTimeType, (string) null)
            }));
          }
          // ISSUE: reference to a compiler-generated field
          // ISSUE: reference to a compiler-generated field
          object obj = FilesController.\u003C\u003Eo__3.\u003C\u003Ep__0.Target((CallSite) FilesController.\u003C\u003Eo__3.\u003C\u003Ep__0, this.ViewBag, "alert('" + (str6.IsNullOrEmpty() ? "删除成功!" : str6) + "');window.location='List?id=" + str5.DesEncrypt() + str3 + "';");
        }
        else if ("1" == str4)
        {
          string str5 = this.Request.Form["file"] ?? "";
          StringBuilder stringBuilder = new StringBuilder();
          char[] chArray = new char[1]{ ',' };
          foreach (string str6 in str5.Split(chArray))
            stringBuilder.Append(files.Delete(str6.DesDecrypt()));
          string str7 = str2.IsNullOrEmpty() ? userRootPath : str2;
          // ISSUE: reference to a compiler-generated field
          if (FilesController.\u003C\u003Eo__3.\u003C\u003Ep__1 == null)
          {
            // ISSUE: reference to a compiler-generated field
            FilesController.\u003C\u003Eo__3.\u003C\u003Ep__1 = CallSite<Func<CallSite, object, string, object>>.Create(Binder.SetMember(CSharpBinderFlags.None, "script", typeof (FilesController), (IEnumerable<CSharpArgumentInfo>) new CSharpArgumentInfo[2]
            {
              CSharpArgumentInfo.Create(CSharpArgumentInfoFlags.None, (string) null),
              CSharpArgumentInfo.Create(CSharpArgumentInfoFlags.UseCompileTimeType, (string) null)
            }));
          }
          // ISSUE: reference to a compiler-generated field
          // ISSUE: reference to a compiler-generated field
          object obj = FilesController.\u003C\u003Eo__3.\u003C\u003Ep__1.Target((CallSite) FilesController.\u003C\u003Eo__3.\u003C\u003Ep__1, this.ViewBag, "alert('" + (stringBuilder.Length == 0 ? "删除成功!" : stringBuilder.ToString()) + "');window.location='List?id=" + str7.DesEncrypt() + str3 + "';");
        }
      }
      // ISSUE: reference to a compiler-generated field
      if (FilesController.\u003C\u003Eo__3.\u003C\u003Ep__2 == null)
      {
        // ISSUE: reference to a compiler-generated field
        FilesController.\u003C\u003Eo__3.\u003C\u003Ep__2 = CallSite<Func<CallSite, object, string, object>>.Create(Binder.SetMember(CSharpBinderFlags.None, "ParentDir", typeof (FilesController), (IEnumerable<CSharpArgumentInfo>) new CSharpArgumentInfo[2]
        {
          CSharpArgumentInfo.Create(CSharpArgumentInfoFlags.None, (string) null),
          CSharpArgumentInfo.Create(CSharpArgumentInfoFlags.UseCompileTimeType, (string) null)
        }));
      }
      // ISSUE: reference to a compiler-generated field
      // ISSUE: reference to a compiler-generated field
      object obj1 = FilesController.\u003C\u003Eo__3.\u003C\u003Ep__2.Target((CallSite) FilesController.\u003C\u003Eo__3.\u003C\u003Ep__2, this.ViewBag, str2);
      // ISSUE: reference to a compiler-generated field
      if (FilesController.\u003C\u003Eo__3.\u003C\u003Ep__3 == null)
      {
        // ISSUE: reference to a compiler-generated field
        FilesController.\u003C\u003Eo__3.\u003C\u003Ep__3 = CallSite<Func<CallSite, object, string, object>>.Create(Binder.SetMember(CSharpBinderFlags.None, "dir", typeof (FilesController), (IEnumerable<CSharpArgumentInfo>) new CSharpArgumentInfo[2]
        {
          CSharpArgumentInfo.Create(CSharpArgumentInfoFlags.None, (string) null),
          CSharpArgumentInfo.Create(CSharpArgumentInfoFlags.UseCompileTimeType, (string) null)
        }));
      }
      // ISSUE: reference to a compiler-generated field
      // ISSUE: reference to a compiler-generated field
      object obj2 = FilesController.\u003C\u003Eo__3.\u003C\u003Ep__3.Target((CallSite) FilesController.\u003C\u003Eo__3.\u003C\u003Ep__3, this.ViewBag, str1);
      // ISSUE: reference to a compiler-generated field
      if (FilesController.\u003C\u003Eo__3.\u003C\u003Ep__4 == null)
      {
        // ISSUE: reference to a compiler-generated field
        FilesController.\u003C\u003Eo__3.\u003C\u003Ep__4 = CallSite<Func<CallSite, object, string, object>>.Create(Binder.SetMember(CSharpBinderFlags.None, "RootDir", typeof (FilesController), (IEnumerable<CSharpArgumentInfo>) new CSharpArgumentInfo[2]
        {
          CSharpArgumentInfo.Create(CSharpArgumentInfoFlags.None, (string) null),
          CSharpArgumentInfo.Create(CSharpArgumentInfoFlags.UseCompileTimeType, (string) null)
        }));
      }
      // ISSUE: reference to a compiler-generated field
      // ISSUE: reference to a compiler-generated field
      object obj3 = FilesController.\u003C\u003Eo__3.\u003C\u003Ep__4.Target((CallSite) FilesController.\u003C\u003Eo__3.\u003C\u003Ep__4, this.ViewBag, userRootPath);
      // ISSUE: reference to a compiler-generated field
      if (FilesController.\u003C\u003Eo__3.\u003C\u003Ep__5 == null)
      {
        // ISSUE: reference to a compiler-generated field
        FilesController.\u003C\u003Eo__3.\u003C\u003Ep__5 = CallSite<Func<CallSite, object, string, object>>.Create(Binder.SetMember(CSharpBinderFlags.None, "Query", typeof (FilesController), (IEnumerable<CSharpArgumentInfo>) new CSharpArgumentInfo[2]
        {
          CSharpArgumentInfo.Create(CSharpArgumentInfoFlags.None, (string) null),
          CSharpArgumentInfo.Create(CSharpArgumentInfoFlags.UseCompileTimeType, (string) null)
        }));
      }
      // ISSUE: reference to a compiler-generated field
      // ISSUE: reference to a compiler-generated field
      object obj4 = FilesController.\u003C\u003Eo__3.\u003C\u003Ep__5.Target((CallSite) FilesController.\u003C\u003Eo__3.\u003C\u003Ep__5, this.ViewBag, str3);
      return (ActionResult) this.View((object) files.GetList(str1));
    }

    [MyAttribute(CheckApp = false)]
    public string Tree1()
    {
      return "[" + new Files().GetUserDirectoryJson(Users.CurrentUserID, "", true) + "]";
    }

    [MyAttribute(CheckApp = false)]
    public string TreeRefresh()
    {
      string str = this.Request.QueryString["refreshid"];
      if (str.IsNullOrEmpty())
        return "[]";
      return new Files().GetUserDirectoryJson(Users.CurrentUserID, str.DesDecrypt(), false);
    }

    [MyAttribute(CheckApp = false)]
    public ActionResult Dir_Add()
    {
      return this.Dir_Add((FormCollection) null);
    }

    [HttpPost]
    [ValidateAntiForgeryToken]
    [MyAttribute(CheckApp = false)]
    public ActionResult Dir_Add(FormCollection collection)
    {
      string str = (this.Request.QueryString["id"] ?? "").DesDecrypt();
      if (str.IsNullOrEmpty() || !Directory.Exists(str))
      {
        this.Response.Write("目录为空或不存在!");
        this.Response.End();
        return (ActionResult) null;
      }
      if (collection != null)
      {
        string dirName = this.Request.Form["DirName"];
        if (new Files().CreateDirectory(str, dirName))
        {
          // ISSUE: reference to a compiler-generated field
          if (FilesController.\u003C\u003Eo__7.\u003C\u003Ep__0 == null)
          {
            // ISSUE: reference to a compiler-generated field
            FilesController.\u003C\u003Eo__7.\u003C\u003Ep__0 = CallSite<Func<CallSite, object, string, object>>.Create(Binder.SetMember(CSharpBinderFlags.None, "script", typeof (FilesController), (IEnumerable<CSharpArgumentInfo>) new CSharpArgumentInfo[2]
            {
              CSharpArgumentInfo.Create(CSharpArgumentInfoFlags.None, (string) null),
              CSharpArgumentInfo.Create(CSharpArgumentInfoFlags.UseCompileTimeType, (string) null)
            }));
          }
          // ISSUE: reference to a compiler-generated field
          // ISSUE: reference to a compiler-generated field
          object obj = FilesController.\u003C\u003Eo__7.\u003C\u003Ep__0.Target((CallSite) FilesController.\u003C\u003Eo__7.\u003C\u003Ep__0, this.ViewBag, "alert('添加成功!');parent.frames[0].reLoad('" + this.Request.QueryString["id"] + "');window.location='List" + this.Request.Url.Query + "';");
        }
        else
        {
          // ISSUE: reference to a compiler-generated field
          if (FilesController.\u003C\u003Eo__7.\u003C\u003Ep__1 == null)
          {
            // ISSUE: reference to a compiler-generated field
            FilesController.\u003C\u003Eo__7.\u003C\u003Ep__1 = CallSite<Func<CallSite, object, string, object>>.Create(Binder.SetMember(CSharpBinderFlags.None, "script", typeof (FilesController), (IEnumerable<CSharpArgumentInfo>) new CSharpArgumentInfo[2]
            {
              CSharpArgumentInfo.Create(CSharpArgumentInfoFlags.None, (string) null),
              CSharpArgumentInfo.Create(CSharpArgumentInfoFlags.UseCompileTimeType | CSharpArgumentInfoFlags.Constant, (string) null)
            }));
          }
          // ISSUE: reference to a compiler-generated field
          // ISSUE: reference to a compiler-generated field
          object obj = FilesController.\u003C\u003Eo__7.\u003C\u003Ep__1.Target((CallSite) FilesController.\u003C\u003Eo__7.\u003C\u003Ep__1, this.ViewBag, "alert('添加失败!')");
        }
      }
      return (ActionResult) this.View();
    }

    [MyAttribute(CheckApp = false)]
    public ActionResult File_Add()
    {
      return (ActionResult) this.View();
    }

    [MyAttribute(CheckApp = false, CheckLogin = false, CheckUrl = false)]
    public string FileUpload()
    {
      string msg;
      if (!WebMvc.Common.Tools.CheckLogin(out msg) && !RoadFlow.Platform.WeiXin.Organize.CheckLogin())
        return "";
      Files files1 = new Files();
      string empty1 = string.Empty;
      string empty2 = string.Empty;
      this.Response.ContentEncoding = Encoding.UTF8;
      string str1 = this.Request.Form["dir"].DesDecrypt();
      if (Users.CurrentUserID.IsEmptyGuid() || str1.IsNullOrEmpty() || this.Request["REQUEST_METHOD"] == "OPTIONS")
        return "";
      string uploadFileType = RoadFlow.Utility.Config.UploadFileType;
      string path = str1.EndsWith("\\") ? str1 : str1 + "\\";
      HttpFileCollection files2 = HttpContext.Current.Request.Files;
      if (!Directory.Exists(path))
        Directory.CreateDirectory(path);
      string str2 = files2[0].ContentType.Split('/')[1];
      string str3 = HttpContext.Current.Request["name"];
      string str4 = string.IsNullOrEmpty(str3) ? new Random(24 * (int) DateTime.Now.Ticks).Next().ToString() + "." + str2 : str3;
      string str5 = path + str4;
      if (File.Exists(str5))
      {
        string withoutExtension = Path.GetFileNameWithoutExtension(str5);
        string extension = Path.GetExtension(str5);
        str5 = path + withoutExtension + "(" + RoadFlow.Utility.Tools.GetRandomString(5) + ")" + extension;
      }
      string str6 = Path.GetExtension(str5).Replace(".", "");
      if (!("," + uploadFileType + ",").Contains("," + str6 + ",", StringComparison.CurrentCultureIgnoreCase))
        return "{\"jsonrpc\":\"2.0\",\"error\":\"不允许的文件\",\"id\":\"" + str4 + "\"}";
      files2[0].SaveAs(str5);
      string str7 = str5.Replace1(new Files().GetRootPath(), "").DesEncrypt();
      Decimal str8 = Decimal.Round((Decimal) (files2[0].ContentLength / 1024), 0);
      string str9 = str8 == Decimal.Zero ? (files2[0].ContentLength > 0 ? "1" : "0") : str8.ToFormatString();
      return "{\"jsonrpc\" : \"2.0\", \"result\" : null, \"id\" : \"" + str5.DesEncrypt() + "\", \"id1\":\"" + str7 + "\",\"size\":\"" + str9 + "KB\"}";
    }

    [MyAttribute(CheckApp = false)]
    public void Show()
    {
      string msg;
      if (!WebMvc.Common.Tools.CheckLogin(out msg) && !RoadFlow.Platform.WeiXin.Organize.CheckLogin())
      {
        this.Response.End();
      }
      else
      {
        FileInfo fileInfo = new FileInfo(this.Request.QueryString["id"].DesDecrypt());
        if (!fileInfo.Exists)
          this.Response.Write("未找到要查看的文件!");
        else if (!("," + RoadFlow.Utility.Config.UploadFileType + ",").Contains("," + fileInfo.Extension.Replace(".", "") + ",", StringComparison.CurrentCultureIgnoreCase))
        {
          this.Response.Write("该文件类型不允许查看!");
        }
        else
        {
          string str1 = fileInfo.Name;
          if (this.Request != null && this.Request.Browser != null && (this.Request.Browser.Type.StartsWith("IE", StringComparison.CurrentCultureIgnoreCase) || this.Request.Browser.Type.StartsWith("InternetExplorer", StringComparison.CurrentCultureIgnoreCase)))
            str1 = str1.UrlEncode();
          this.Response.AppendHeader("Server-FileName", str1);
          string str2 = ",.zip,.rar,.7z,".Contains("," + fileInfo.Extension + ",", StringComparison.CurrentCultureIgnoreCase) ? "" : new Files().GetFileContentType(fileInfo.Extension);
          if (string.IsNullOrEmpty(str2))
          {
            this.Response.ContentType = "application/octet-stream";
            this.Response.AppendHeader("Content-Disposition", "attachment; filename=" + str1);
          }
          else
          {
            this.Response.ContentType = str2;
            this.Response.AppendHeader("Content-Disposition", "inline; filename=" + str1);
          }
          this.Response.AddHeader("Content-Length", fileInfo.Length.ToString());
          using (FileStream fileStream = fileInfo.OpenRead())
          {
            byte[] buffer = new byte[2048];
            for (int count = fileStream.Read(buffer, 0, buffer.Length); count > 0; count = fileStream.Read(buffer, 0, buffer.Length))
            {
              if (this.Response.IsClientConnected)
              {
                this.Response.OutputStream.Write(buffer, 0, count);
                this.Response.Flush();
              }
              else
                break;
            }
          }
          this.Response.Flush();
          this.Response.OutputStream.Close();
          this.Response.Output.Close();
        }
      }
    }

    [MyAttribute(CheckApp = false, CheckLogin = false, CheckUrl = false)]
    public string GetShowString()
    {
      string msg;
      if (!WebMvc.Common.Tools.CheckLogin(out msg) && !RoadFlow.Platform.WeiXin.Organize.CheckLogin())
        return "";
      return Files.GetFilesShowString(this.Request["files"], WebMvc.Common.Tools.BaseUrl + "/Content/Show.ashx", false, true);
    }
  }
}
