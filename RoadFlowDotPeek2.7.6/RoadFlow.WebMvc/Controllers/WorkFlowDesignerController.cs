// Decompiled with JetBrains decompiler
// Type: WebMvc.Controllers.WorkFlowDesignerController
// Assembly: WebMvc, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 43FD7615-6DC3-49FB-B263-7F7CC91AFA77
// Assembly location: C:\inetpub\wwwroot\RoadFlowMvc\bin\WebMvc.dll

using LitJson;
using Microsoft.CSharp.RuntimeBinder;
using System;
using System.Collections.Generic;
using System.IO;
using System.Runtime.CompilerServices;
using System.Text;
using System.Web;
using System.Web.Mvc;

namespace WebMvc.Controllers
{
  public class WorkFlowDesignerController : MyController
  {
    public ActionResult Index()
    {
      return (ActionResult) this.View();
    }

    public ActionResult Index1()
    {
      return (ActionResult) this.View();
    }

    public ActionResult Open()
    {
      return (ActionResult) this.View();
    }

    [MyAttribute(CheckApp = false)]
    public ActionResult Open_Tree()
    {
      return (ActionResult) this.View();
    }

    [MyAttribute(CheckApp = false)]
    public ActionResult Open_Tree1()
    {
      return (ActionResult) this.View();
    }

    [MyAttribute(CheckApp = false)]
    public ActionResult Open_List()
    {
      return (ActionResult) this.View();
    }

    [MyAttribute(CheckApp = false)]
    public ActionResult Open_List1()
    {
      return (ActionResult) this.View();
    }

    [HttpPost]
    [ValidateAntiForgeryToken]
    public string Query()
    {
      List<RoadFlow.Data.Model.WorkFlow> workFlowList = new List<RoadFlow.Data.Model.WorkFlow>();
      RoadFlow.Platform.Users users = new RoadFlow.Platform.Users();
      RoadFlow.Platform.WorkFlow workFlow1 = new RoadFlow.Platform.WorkFlow();
      string name = this.Request.Form["flow_name"];
      string str1 = this.Request.Form["typeid"];
      string str2 = this.Request.Form["sidx"];
      string str3 = this.Request.Form["sord"];
      bool flag = "1" == this.Request.Form["openlist"];
      string typeid = "";
      if (str1.IsGuid())
        typeid = new RoadFlow.Platform.Dictionary().GetAllChildsIDString(str1.ToGuid(), true);
      int pageSize = flag ? 10 : RoadFlow.Utility.Tools.GetPageSize();
      int pageNumber = RoadFlow.Utility.Tools.GetPageNumber();
      string order = (str2.IsNullOrEmpty() ? "CreateDate" : str2) + " " + (str3.IsNullOrEmpty() ? "asc" : str3);
      long count;
      List<RoadFlow.Data.Model.WorkFlow> pagerData = workFlow1.GetPagerData(out count, pageSize, pageNumber, RoadFlow.Platform.Users.CurrentUserID.ToString(), typeid, name, order);
      JsonData jsonData1 = new JsonData();
      foreach (RoadFlow.Data.Model.WorkFlow workFlow2 in pagerData)
      {
        JsonData jsonData2 = new JsonData();
        jsonData2["id"] = (JsonData) workFlow2.ID.ToString();
        jsonData2["Name"] = (JsonData) workFlow2.Name;
        jsonData2["CreateDate"] = (JsonData) workFlow2.CreateDate.ToDateTimeString();
        jsonData2["CreateUserID"] = (JsonData) users.GetName(workFlow2.CreateUserID);
        jsonData2["Status"] = (JsonData) workFlow1.GetStatusTitle(workFlow2.Status);
        if (flag)
          jsonData2["Edit"] = (JsonData) ("<a href=\"javascript:void(0);\" onclick=\"openflow('" + (object) workFlow2.ID + "');return false;\"><img src=\"" + this.Url.Content("~/Images/ico/topic_edit.gif") + "\" alt=\"\" style=\"vertical-align:middle; border:0;\" /><span style=\"vertical-align:middle; margin-left:3px;\">编辑</span></a>");
        else
          jsonData2["Edit"] = (JsonData) ("<a class=\"editlink\" href=\"javascript:void(0);\" onclick=\"openflow('" + (object) workFlow2.ID + "','" + workFlow2.Name + "');return false;\"><span style=\"vertical-align:middle;\">编辑</span></a><a class=\"deletelink\" href=\"javascript:void(0);\" style=\"margin-left:5px\" onclick=\"delflow('" + (object) workFlow2.ID + "'); return false;\"><span style=\"vertical-align:middle;\">删除</span></a><a href=\"javascript:void(0);\" style=\"margin-left:5px\" onclick=\"ExportFlow('" + (object) workFlow2.ID + "'); return false;\"><span style=\"vertical-align:middle; background:url(../Images/ico/arrow_medium_right.png) no-repeat;padding-left:18px;\">导出</span></a>");
        jsonData1.Add((object) jsonData2);
      }
      return "{\"userdata\":{\"total\":" + (object) count + ",\"pagesize\":" + (object) pageSize + ",\"pagenumber\":" + (object) pageNumber + "},\"rows\":" + jsonData1.ToJson(true) + "}";
    }

    [MyAttribute(CheckApp = false, CheckLogin = false, CheckUrl = false)]
    public string GetJSON()
    {
      string msg;
      if (!WebMvc.Common.Tools.CheckLogin(out msg) && !RoadFlow.Platform.WeiXin.Organize.CheckLogin())
        return "{}";
      string str1 = this.Request.QueryString["flowid"];
      string str2 = this.Request.QueryString["type"];
      if (!str1.IsGuid())
        return "{}";
      RoadFlow.Data.Model.WorkFlow workFlow = new RoadFlow.Platform.WorkFlow().Get(str1.ToGuid());
      if (workFlow == null)
        return "{}";
      if (!("0" == str2))
        return workFlow.DesignJSON;
      return workFlow.RunJSON;
    }

    [MyAttribute(CheckApp = false)]
    public ActionResult Set_Flow()
    {
      return (ActionResult) this.View();
    }

    [MyAttribute(CheckApp = false)]
    public string GetTables()
    {
      string msg;
      if (!WebMvc.Common.Tools.CheckLogin(out msg))
        return "";
      this.Response.Charset = "utf-8";
      string str1 = this.Request.QueryString["connid"];
      if (!str1.IsGuid())
        return "[]";
      List<string> tables = new RoadFlow.Platform.DBConnection().GetTables(str1.ToGuid(), 0);
      StringBuilder stringBuilder = new StringBuilder("[", 1000);
      foreach (string str2 in tables)
      {
        stringBuilder.Append("{\"name\":");
        stringBuilder.AppendFormat("\"{0}\"", (object) str2);
        stringBuilder.Append("},");
      }
      return stringBuilder.ToString().TrimEnd(',') + "]";
    }

    [MyAttribute(CheckApp = false)]
    public string GetFields()
    {
      string msg;
      if (!WebMvc.Common.Tools.CheckLogin(out msg))
        return "";
      string str1 = this.Request.QueryString["table"];
      string str2 = this.Request.QueryString["connid"];
      if (str1.IsNullOrEmpty() || !str2.IsGuid())
        return "[]";
      System.Collections.Generic.Dictionary<string, string> fields = new RoadFlow.Platform.DBConnection().GetFields(str2.ToGuid(), str1);
      StringBuilder stringBuilder = new StringBuilder("[", 1000);
      foreach (KeyValuePair<string, string> keyValuePair in fields)
      {
        stringBuilder.Append("{");
        stringBuilder.AppendFormat("\"name\":\"{0}\",\"note\":\"{1}\"", (object) keyValuePair.Key, (object) keyValuePair.Value);
        stringBuilder.Append("},");
      }
      return stringBuilder.ToString().TrimEnd(',') + "]";
    }

    [MyAttribute(CheckApp = false)]
    public ActionResult Set_Step()
    {
      return (ActionResult) this.View();
    }

    [MyAttribute(CheckApp = false)]
    public ActionResult Set_SubFlow()
    {
      return (ActionResult) this.View();
    }

    [MyAttribute(CheckApp = false)]
    public ActionResult Set_Line()
    {
      return (ActionResult) this.View();
    }

    public ActionResult Opation()
    {
      return (ActionResult) this.View();
    }

    [MyAttribute(CheckApp = false)]
    public ActionResult Save()
    {
      return (ActionResult) this.View();
    }

    [MyAttribute(CheckApp = false)]
    public ActionResult Install()
    {
      return (ActionResult) this.View();
    }

    [MyAttribute(CheckApp = false)]
    public ActionResult UnInstall()
    {
      return (ActionResult) this.View();
    }

    [MyAttribute(CheckApp = false)]
    public ActionResult SaveAs()
    {
      return (ActionResult) this.View();
    }

    [MyAttribute(CheckApp = false)]
    public string TestLineSqlWhere()
    {
      string msg;
      if (!WebMvc.Common.Tools.CheckLogin(out msg))
        return "";
      string str1 = this.Request["connid"];
      string str2 = this.Request["table"];
      string str3 = this.Request["tablepk"];
      string str4 = this.Request["where"] ?? "";
      RoadFlow.Platform.DBConnection dbConnection = new RoadFlow.Platform.DBConnection();
      if (!str1.IsGuid())
        return "流程未设置数据连接!";
      RoadFlow.Data.Model.DBConnection dbconn = dbConnection.Get(str1.ToGuid(), true);
      if (dbconn == null)
        return "未找到连接!";
      string sql = "SELECT * FROM " + str2 + " WHERE 1=1 AND " + str4.FilterWildcard("");
      return dbConnection.TestSql(dbconn, sql, true) ? "SQL条件正确!" : "SQL条件错误!";
    }

    [MyAttribute(CheckApp = false)]
    public void Export()
    {
      string msg;
      if (!WebMvc.Common.Tools.CheckLogin(out msg))
        return;
      string str = new RoadFlow.Platform.WorkFlow().Export(this.Request.QueryString["flowid"].ToGuid(), 1);
      if (!str.IsNullOrEmpty())
      {
        this.Response.Redirect("../Files/Show?id=" + str.DesEncrypt() + "&appid=" + this.Request.QueryString["appid"] + "&tabid=" + this.Request.QueryString["tabid"]);
      }
      else
      {
        this.Response.Write("导出失败");
        this.Response.End();
      }
    }

    [MyAttribute(CheckApp = false)]
    public ActionResult Import()
    {
      return this.Import((FormCollection) null);
    }

    [HttpPost]
    [ValidateAntiForgeryToken]
    [MyAttribute(CheckApp = false)]
    public ActionResult Import(FormCollection collection)
    {
      if (collection != null)
      {
        HttpPostedFileBase file = this.Request.Files["FileUpload1"];
        if (file == null || file.FileName.IsNullOrEmpty())
        {
          // ISSUE: reference to a compiler-generated field
          if (WorkFlowDesignerController.\u003C\u003Eo__23.\u003C\u003Ep__0 == null)
          {
            // ISSUE: reference to a compiler-generated field
            WorkFlowDesignerController.\u003C\u003Eo__23.\u003C\u003Ep__0 = CallSite<Func<CallSite, object, string, object>>.Create(Binder.SetMember(CSharpBinderFlags.None, "script", typeof (WorkFlowDesignerController), (IEnumerable<CSharpArgumentInfo>) new CSharpArgumentInfo[2]
            {
              CSharpArgumentInfo.Create(CSharpArgumentInfoFlags.None, (string) null),
              CSharpArgumentInfo.Create(CSharpArgumentInfoFlags.UseCompileTimeType | CSharpArgumentInfoFlags.Constant, (string) null)
            }));
          }
          // ISSUE: reference to a compiler-generated field
          // ISSUE: reference to a compiler-generated field
          object obj = WorkFlowDesignerController.\u003C\u003Eo__23.\u003C\u003Ep__0.Target((CallSite) WorkFlowDesignerController.\u003C\u003Eo__23.\u003C\u003Ep__0, this.ViewBag, "alert('请选择要导入的文件!');");
          return (ActionResult) this.View();
        }
        string path = RoadFlow.Utility.Config.FilePath + "WorkFlowImportFiles\\" + Guid.NewGuid().ToString("N");
        if (!Directory.Exists(path))
          Directory.CreateDirectory(path);
        string str1 = path + "\\" + file.FileName;
        file.SaveAs(str1);
        string str2 = new RoadFlow.Platform.WorkFlow().Import(str1, 1);
        if ("1" == str2)
        {
          // ISSUE: reference to a compiler-generated field
          if (WorkFlowDesignerController.\u003C\u003Eo__23.\u003C\u003Ep__1 == null)
          {
            // ISSUE: reference to a compiler-generated field
            WorkFlowDesignerController.\u003C\u003Eo__23.\u003C\u003Ep__1 = CallSite<Func<CallSite, object, string, object>>.Create(Binder.SetMember(CSharpBinderFlags.None, "script", typeof (WorkFlowDesignerController), (IEnumerable<CSharpArgumentInfo>) new CSharpArgumentInfo[2]
            {
              CSharpArgumentInfo.Create(CSharpArgumentInfoFlags.None, (string) null),
              CSharpArgumentInfo.Create(CSharpArgumentInfoFlags.UseCompileTimeType | CSharpArgumentInfoFlags.Constant, (string) null)
            }));
          }
          // ISSUE: reference to a compiler-generated field
          // ISSUE: reference to a compiler-generated field
          object obj = WorkFlowDesignerController.\u003C\u003Eo__23.\u003C\u003Ep__1.Target((CallSite) WorkFlowDesignerController.\u003C\u003Eo__23.\u003C\u003Ep__1, this.ViewBag, "alert('导入成功!');new RoadUI.Window().reloadOpener();");
        }
        else
        {
          // ISSUE: reference to a compiler-generated field
          if (WorkFlowDesignerController.\u003C\u003Eo__23.\u003C\u003Ep__2 == null)
          {
            // ISSUE: reference to a compiler-generated field
            WorkFlowDesignerController.\u003C\u003Eo__23.\u003C\u003Ep__2 = CallSite<Func<CallSite, object, string, object>>.Create(Binder.SetMember(CSharpBinderFlags.None, "script", typeof (WorkFlowDesignerController), (IEnumerable<CSharpArgumentInfo>) new CSharpArgumentInfo[2]
            {
              CSharpArgumentInfo.Create(CSharpArgumentInfoFlags.None, (string) null),
              CSharpArgumentInfo.Create(CSharpArgumentInfoFlags.UseCompileTimeType, (string) null)
            }));
          }
          // ISSUE: reference to a compiler-generated field
          // ISSUE: reference to a compiler-generated field
          object obj = WorkFlowDesignerController.\u003C\u003Eo__23.\u003C\u003Ep__2.Target((CallSite) WorkFlowDesignerController.\u003C\u003Eo__23.\u003C\u003Ep__2, this.ViewBag, "alert('" + str2 + "');new RoadUI.Window().reloadOpener();");
        }
      }
      return (ActionResult) this.View();
    }
  }
}
