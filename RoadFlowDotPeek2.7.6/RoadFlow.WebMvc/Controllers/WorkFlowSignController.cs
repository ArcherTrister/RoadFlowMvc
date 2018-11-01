// Decompiled with JetBrains decompiler
// Type: WebMvc.Controllers.WorkFlowSignController
// Assembly: WebMvc, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 43FD7615-6DC3-49FB-B263-7F7CC91AFA77
// Assembly location: C:\inetpub\wwwroot\RoadFlowMvc\bin\WebMvc.dll

using Microsoft.CSharp.RuntimeBinder;
using System;
using System.Collections.Generic;
using System.IO;
using System.Runtime.CompilerServices;
using System.Web;
using System.Web.Mvc;

namespace WebMvc.Controllers
{
  public class WorkFlowSignController : MyController
  {
    public ActionResult Index()
    {
      if (this.Request.Files.Count > 0 && this.Request.Files[0].ContentLength > 0)
      {
        HttpPostedFileBase file = this.Request.Files[0];
        string extension = Path.GetExtension(file.FileName);
        if (extension.IsNullOrEmpty() || extension.ToLower() != ".gif" && extension.ToLower() != ".jpg" && extension.ToLower() != ".png")
        {
          this.Response.Write("<script>alert('只能上传gif,jpg,png类型的图片文件!'); window.location = window.location;</script>");
          this.Response.End();
          return (ActionResult) null;
        }
        string str = this.Server.MapPath(this.Url.Content("~/Content/UserSigns/")) + (object) RoadFlow.Platform.Users.CurrentUserID + ".gif";
        file.SaveAs(str);
        RoadFlow.Platform.Log.Add("修改了签名", str, RoadFlow.Platform.Log.Types.流程相关, "", "", (RoadFlow.Data.Model.Users) null);
        // ISSUE: reference to a compiler-generated field
        if (WorkFlowSignController.\u003C\u003Eo__0.\u003C\u003Ep__0 == null)
        {
          // ISSUE: reference to a compiler-generated field
          WorkFlowSignController.\u003C\u003Eo__0.\u003C\u003Ep__0 = CallSite<Func<CallSite, object, string, object>>.Create(Binder.SetMember(CSharpBinderFlags.None, "Script", typeof (WorkFlowSignController), (IEnumerable<CSharpArgumentInfo>) new CSharpArgumentInfo[2]
          {
            CSharpArgumentInfo.Create(CSharpArgumentInfoFlags.None, (string) null),
            CSharpArgumentInfo.Create(CSharpArgumentInfoFlags.UseCompileTimeType | CSharpArgumentInfoFlags.Constant, (string) null)
          }));
        }
        // ISSUE: reference to a compiler-generated field
        // ISSUE: reference to a compiler-generated field
        object obj = WorkFlowSignController.\u003C\u003Eo__0.\u003C\u003Ep__0.Target((CallSite) WorkFlowSignController.\u003C\u003Eo__0.\u003C\u003Ep__0, this.ViewBag, "alert('上传成功!'); window.location = window.location;");
      }
      if (!this.Request.Form["reset"].IsNullOrEmpty())
      {
        string str = this.Server.MapPath(this.Url.Content("~/Content/UserSigns/")) + (object) RoadFlow.Platform.Users.CurrentUserID + ".gif";
        if (File.Exists(str))
        {
          File.Delete(str);
          RoadFlow.Platform.Log.Add("恢复了签名", str, RoadFlow.Platform.Log.Types.流程相关, "", "", (RoadFlow.Data.Model.Users) null);
        }
        // ISSUE: reference to a compiler-generated field
        if (WorkFlowSignController.\u003C\u003Eo__0.\u003C\u003Ep__1 == null)
        {
          // ISSUE: reference to a compiler-generated field
          WorkFlowSignController.\u003C\u003Eo__0.\u003C\u003Ep__1 = CallSite<Func<CallSite, object, string, object>>.Create(Binder.SetMember(CSharpBinderFlags.None, "Script", typeof (WorkFlowSignController), (IEnumerable<CSharpArgumentInfo>) new CSharpArgumentInfo[2]
          {
            CSharpArgumentInfo.Create(CSharpArgumentInfoFlags.None, (string) null),
            CSharpArgumentInfo.Create(CSharpArgumentInfoFlags.UseCompileTimeType | CSharpArgumentInfoFlags.Constant, (string) null)
          }));
        }
        // ISSUE: reference to a compiler-generated field
        // ISSUE: reference to a compiler-generated field
        object obj = WorkFlowSignController.\u003C\u003Eo__0.\u003C\u003Ep__1.Target((CallSite) WorkFlowSignController.\u003C\u003Eo__0.\u003C\u003Ep__1, this.ViewBag, "alert('已恢复为默认签名!'); window.location = window.location;");
      }
      return (ActionResult) this.View();
    }
  }
}
