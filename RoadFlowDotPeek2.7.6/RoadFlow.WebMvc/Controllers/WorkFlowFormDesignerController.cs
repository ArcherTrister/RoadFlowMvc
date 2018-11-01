// Decompiled with JetBrains decompiler
// Type: WebMvc.Controllers.WorkFlowFormDesignerController
// Assembly: WebMvc, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 43FD7615-6DC3-49FB-B263-7F7CC91AFA77
// Assembly location: C:\inetpub\wwwroot\RoadFlowMvc\bin\WebMvc.dll

using LitJson;
using Microsoft.CSharp.RuntimeBinder;
using RoadFlow.Utility;
using System;
using System.Collections.Generic;
using System.IO;
using System.Runtime.CompilerServices;
using System.Text;
using System.Web;
using System.Web.Mvc;

namespace WebMvc.Controllers
{
  public class WorkFlowFormDesignerController : MyController
  {
    [MyAttribute(CheckApp = false)]
    public ActionResult Index()
    {
      return (ActionResult) this.View();
    }

    public ActionResult Index1()
    {
      return (ActionResult) this.View();
    }

    public ActionResult Open_Tree1()
    {
      return (ActionResult) this.View();
    }

    public ActionResult Open_List1(FormCollection collection)
    {
      return (ActionResult) this.View();
    }

    [HttpPost]
    [MyAttribute(CheckApp = false)]
    public string Query()
    {
      List<RoadFlow.Data.Model.WorkFlowForm> workFlowFormList = new List<RoadFlow.Data.Model.WorkFlowForm>();
      RoadFlow.Platform.WorkFlowForm workFlowForm1 = new RoadFlow.Platform.WorkFlowForm();
      string str1 = this.Request.Form["form_name"];
      string str2 = this.Request.Form["typeid"];
      string str3 = this.Request.Form["sidx"];
      string str4 = this.Request.Form["sord"];
      bool flag = "1" == this.Request.Form["openlist"];
      string typeid = "";
      if (str2.IsGuid())
        typeid = new RoadFlow.Platform.Dictionary().GetAllChildsIDString(str2.ToGuid(), true);
      int pageSize = flag ? 10 : RoadFlow.Utility.Tools.GetPageSize();
      int pageNumber = RoadFlow.Utility.Tools.GetPageNumber();
      string order = (str3.IsNullOrEmpty() ? "WriteTime" : str3) + " " + (str4.IsNullOrEmpty() ? "asc" : str4);
      "&appid=" + this.Request.QueryString["appid"] + "&typeid=" + str2 + "&name=" + str1.UrlEncode();
      long count;
      List<RoadFlow.Data.Model.WorkFlowForm> pagerData = workFlowForm1.GetPagerData(out count, pageSize, pageNumber, "", typeid, str1, order);
      JsonData jsonData1 = new JsonData();
      foreach (RoadFlow.Data.Model.WorkFlowForm workFlowForm2 in pagerData)
      {
        JsonData jsonData2 = new JsonData();
        JsonData jsonData3 = jsonData2;
        string index1 = "id";
        Guid id = workFlowForm2.ID;
        JsonData jsonData4 = (JsonData) id.ToString();
        jsonData3[index1] = jsonData4;
        jsonData2["Name"] = (JsonData) workFlowForm2.Name;
        jsonData2["CreateUserName"] = (JsonData) workFlowForm2.CreateUserName;
        jsonData2["CreateTime"] = (JsonData) workFlowForm2.CreateTime.ToDateTimeString();
        jsonData2["LastModifyTime"] = (JsonData) workFlowForm2.LastModifyTime.ToDateTimeString();
        if (flag)
        {
          JsonData jsonData5 = jsonData2;
          string index2 = "Edit";
          string format = "<a href=\"javascript:void(0);\" onclick=\"openform('{0}');return false;\"><img src=\"{1}/Images/ico/topic_edit.gif\" alt=\"\" style=\"vertical-align:middle; border:0;\" /><span style=\"vertical-align:middle;margin-left:2px;\">编辑</span></a><a href=\"javascript:void(0);\" onclick=\"delform('{0}');return false;\"><img src=\"{1}/Images/ico/topic_del.gif\" alt=\"\" style=\"vertical-align:middle; border:0; margin-left:5px;\" /><span style=\"vertical-align:middle;margin-left:2px;\">删除</span></a>";
          id = workFlowForm2.ID;
          string str5 = id.ToString();
          string baseUrl = WebMvc.Common.Tools.BaseUrl;
          JsonData jsonData6 = (JsonData) string.Format(format, (object) str5, (object) baseUrl);
          jsonData5[index2] = jsonData6;
        }
        else
        {
          JsonData jsonData5 = jsonData2;
          string index2 = "Edit";
          string[] strArray = new string[9];
          strArray[0] = "<a class=\"editlink\" href=\"javascript:void(0);\" onclick=\"openform('";
          int index3 = 1;
          id = workFlowForm2.ID;
          string str5 = id.ToString();
          strArray[index3] = str5;
          strArray[2] = "','";
          strArray[3] = workFlowForm2.Name;
          strArray[4] = "');return false;\"><span style=\"vertical-align:middle;\">编辑</span></a><a class=\"deletelink\" href=\"javascript:void(0);\" style=\"margin-left:5px;\" onclick=\"delform('";
          int index4 = 5;
          id = workFlowForm2.ID;
          string str6 = id.ToString();
          strArray[index4] = str6;
          strArray[6] = "'); return false;\"><span style=\"vertical-align:middle;\">删除</span></a><a href=\"javascript:void(0);\" style=\"margin-left:5px;\" onclick=\"ExportForm('";
          int index5 = 7;
          id = workFlowForm2.ID;
          string str7 = id.ToString();
          strArray[index5] = str7;
          strArray[8] = "'); return false;\"><span style=\"vertical-align:middle; background:url(../Images/ico/arrow_medium_right.png) no-repeat;padding-left:18px;\">导出</span></a>";
          JsonData jsonData6 = (JsonData) string.Concat(strArray);
          jsonData5[index2] = jsonData6;
        }
        jsonData1.Add((object) jsonData2);
      }
      return "{\"userdata\":{\"total\":" + (object) count + ",\"pagesize\":" + (object) pageSize + ",\"pagenumber\":" + (object) pageNumber + "},\"rows\":" + jsonData1.ToJson(true) + "}";
    }

    [MyAttribute(CheckApp = false)]
    public string GetHtml()
    {
      Guid test;
      if (!this.Request["id"].IsGuid(out test))
        return "";
      RoadFlow.Data.Model.WorkFlowForm workFlowForm = new RoadFlow.Platform.WorkFlowForm().Get(test);
      if (workFlowForm == null)
        return "";
      return workFlowForm.Html;
    }

    [MyAttribute(CheckApp = false)]
    public string GetAttribute()
    {
      Guid test;
      if (!this.Request["id"].IsGuid(out test))
        return "";
      RoadFlow.Data.Model.WorkFlowForm workFlowForm = new RoadFlow.Platform.WorkFlowForm().Get(test);
      if (workFlowForm == null)
        return "";
      return workFlowForm.Attribute;
    }

    [MyAttribute(CheckApp = false)]
    public string Getsubtable()
    {
      Guid test;
      if (!this.Request["id"].IsGuid(out test))
        return "";
      RoadFlow.Data.Model.WorkFlowForm workFlowForm = new RoadFlow.Platform.WorkFlowForm().Get(test);
      if (workFlowForm == null)
        return "";
      return workFlowForm.SubTableJson;
    }

    [MyAttribute(CheckApp = false)]
    public string GetEvents()
    {
      Guid test;
      if (!this.Request["id"].IsGuid(out test))
        return "";
      RoadFlow.Data.Model.WorkFlowForm workFlowForm = new RoadFlow.Platform.WorkFlowForm().Get(test);
      if (workFlowForm == null)
        return "";
      return workFlowForm.EventsJson;
    }

    [MyAttribute(CheckApp = false)]
    public string TestSql()
    {
      string str1 = this.Request["sql"];
      string str2 = this.Request["dbconn"];
      if (str1.IsNullOrEmpty() || !str2.IsGuid())
        return "SQL语句为空或未设置数据连接";
      RoadFlow.Platform.DBConnection dbConnection = new RoadFlow.Platform.DBConnection();
      return dbConnection.TestSql(dbConnection.Get(str2.ToGuid(), true), str1.ReplaceSelectSql().FilterWildcard(""), true) ? "SQL语句测试正确" : "SQL语句测试错误";
    }

    [MyAttribute(CheckApp = false)]
    public string Save()
    {
      string str1 = this.Request["html"];
      string str2 = this.Request["name"];
      string str3 = this.Request["att"];
      string str4 = this.Request["id"];
      string str5 = this.Request["type"];
      string str6 = this.Request["subtable"];
      string str7 = this.Request["formEvents"];
      if (str2.IsNullOrEmpty())
        return "表单名称不能为空!";
      Guid test;
      if (!str4.IsGuid(out test))
        return "表单ID无效!";
      RoadFlow.Platform.WorkFlowForm workFlowForm = new RoadFlow.Platform.WorkFlowForm();
      RoadFlow.Data.Model.WorkFlowForm model = workFlowForm.Get(test);
      bool flag = false;
      string oldXML = string.Empty;
      if (model == null)
      {
        model = new RoadFlow.Data.Model.WorkFlowForm();
        model.ID = test;
        model.CreateUserID = RoadFlow.Platform.Users.CurrentUserID;
        model.CreateUserName = RoadFlow.Platform.Users.CurrentUserName;
        model.CreateTime = DateTimeNew.Now;
        model.Status = 0;
        flag = true;
      }
      else
        oldXML = model.Serialize();
      model.Attribute = str3;
      model.Html = str1;
      model.LastModifyTime = DateTimeNew.Now;
      model.Name = str2;
      model.Type = str5.ToGuid();
      model.SubTableJson = str6;
      model.EventsJson = str7;
      if (flag)
      {
        workFlowForm.Add(model);
        RoadFlow.Platform.Log.Add("添加了流程表单", model.Serialize(), RoadFlow.Platform.Log.Types.流程相关, "", "", (RoadFlow.Data.Model.Users) null);
      }
      else
      {
        workFlowForm.Update(model);
        RoadFlow.Platform.Log.Add("修改了流程表单", "", RoadFlow.Platform.Log.Types.流程相关, oldXML, model.Serialize(), (RoadFlow.Data.Model.Users) null);
      }
      return "保存成功!";
    }

    [HttpPost]
    [MyAttribute(CheckApp = false, CheckLogin = false)]
    public string GetSubTableData()
    {
      string msg;
      if (!WebMvc.Common.Tools.CheckLogin(out msg) && !RoadFlow.Platform.WeiXin.Organize.CheckLogin())
        return "{}";
      string secondTable = this.Request["secondtable"];
      string str1 = this.Request["primarytablefiled"];
      string str2 = this.Request["secondtableprimarykey"];
      string fieldValue = this.Request["primarytablefiledvalue"];
      string relationField = this.Request["secondtablerelationfield"];
      string connID = this.Request["dbconnid"];
      string fieldFormat = this.Request["subtableformat"];
      string str3 = this.Request["sortstring"];
      string sortField = str3.IsNullOrEmpty() ? str2 : str3;
      return new RoadFlow.Platform.WorkFlow().GetSubTableData(connID, secondTable, relationField, fieldValue, sortField, fieldFormat).ToJson(true);
    }

    [MyAttribute(CheckApp = false)]
    public string Publish()
    {
      string s = this.Request["html"];
      string str1 = this.Request["name"];
      string str2 = this.Request["att"];
      string str3 = this.Request["id"];
      string str4 = this.Request["formats"];
      Guid test;
      if (!str3.IsGuid(out test) || str1.IsNullOrEmpty() || str2.IsNullOrEmpty())
        return "参数错误!";
      RoadFlow.Platform.WorkFlowForm workFlowForm = new RoadFlow.Platform.WorkFlowForm();
      RoadFlow.Data.Model.WorkFlowForm model1 = workFlowForm.Get(test);
      if (model1 == null)
        return "请先保存表单再发布!";
      string str5 = str3 + ".cshtml";
      StringBuilder stringBuilder = new StringBuilder("@{\r\n");
      JsonData jsonData = JsonMapper.ToObject(str2);
      stringBuilder.Append("\tstring FlowID = Request.QueryString[\"flowid\"];\r\n");
      stringBuilder.Append("\tstring StepID = Request.QueryString[\"stepid\"];\r\n");
      stringBuilder.Append("\tstring GroupID = Request.QueryString[\"groupid\"];\r\n");
      stringBuilder.Append("\tstring TaskID = Request.QueryString[\"taskid\"];\r\n");
      stringBuilder.Append("\tstring InstanceID = Request.QueryString[\"instanceid\"];\r\n");
      stringBuilder.Append("\tstring DisplayModel = Request.QueryString[\"display\"] ?? \"0\";\r\n");
      stringBuilder.AppendFormat("\tstring DBConnID = \"{0}\";\r\n", (object) jsonData["dbconn"].ToString());
      stringBuilder.AppendFormat("\tstring DBTable = \"{0}\";\r\n", (object) jsonData["dbtable"].ToString());
      stringBuilder.AppendFormat("\tstring DBTablePK = \"{0}\";\r\n", (object) jsonData["dbtablepk"].ToString());
      stringBuilder.AppendFormat("\tstring DBTableTitle = \"{0}\";\r\n", (object) jsonData["dbtabletitle"].ToString());
      stringBuilder.Append("\tif(InstanceID.IsNullOrEmpty()){InstanceID = Request.QueryString[\"instanceid1\"];}\r\n");
      stringBuilder.Append("\tRoadFlow.Platform.Dictionary BDictionary = new RoadFlow.Platform.Dictionary();\r\n");
      stringBuilder.Append("\tRoadFlow.Platform.WorkFlow BWorkFlow = new RoadFlow.Platform.WorkFlow();\r\n");
      stringBuilder.Append("\tRoadFlow.Platform.WorkFlowTask BWorkFlowTask = new RoadFlow.Platform.WorkFlowTask();\r\n");
      stringBuilder.Append("\tstring fieldStatus = BWorkFlow.GetFieldStatus(FlowID, StepID);\r\n");
      stringBuilder.Append("\tLitJson.JsonData initData = BWorkFlow.GetFormData(DBConnID, DBTable, DBTablePK, InstanceID, fieldStatus, \"" + str4 + "\");\r\n");
      stringBuilder.Append("\tstring TaskTitle = BWorkFlow.GetFromFieldData(initData, DBTable, DBTableTitle);\r\n");
      stringBuilder.Append("}\r\n");
      stringBuilder.Append("<link href=\"~/Scripts/FlowRun/Forms/flowform.css\" rel=\"stylesheet\" type=\"text/css\" />\r\n");
      stringBuilder.Append("<script src=\"~/Scripts/FlowRun/Forms/common.js\" type=\"text/javascript\" ></script>\r\n");
      if (jsonData.ContainsKey("hasEditor") && "1" == jsonData["hasEditor"].ToString())
      {
        stringBuilder.Append("<script src=\"~/Scripts/Ueditor/ueditor.config.js\" type=\"text/javascript\" ></script>\r\n");
        stringBuilder.Append("<script src=\"~/Scripts/Ueditor/ueditor.all.min.js\" type=\"text/javascript\" ></script>\r\n");
        stringBuilder.Append("<script src=\"~/Scripts/Ueditor/lang/zh-cn/zh-cn.js\" type=\"text/javascript\" ></script>\r\n");
        stringBuilder.Append("<input type=\"hidden\" id=\"Form_HasUEditor\" name=\"Form_HasUEditor\" value=\"1\" />\r\n");
      }
      string str6 = jsonData.ContainsKey("validatealerttype") ? jsonData["validatealerttype"].ToString() : "2";
      stringBuilder.Append("<input type=\"hidden\" id=\"Form_ValidateAlertType\" name=\"Form_ValidateAlertType\" value=\"" + str6 + "\" />\r\n");
      if (jsonData.ContainsKey("autotitle") && jsonData["autotitle"].ToString().ToLower() == "true")
        stringBuilder.AppendFormat("<input type=\"hidden\" id=\"{0}\" name=\"{0}\" value=\"{1}\" />\r\n", (object) (jsonData["dbtable"].ToString() + "." + jsonData["dbtabletitle"].ToString()), (object) "@(TaskTitle.IsNullOrEmpty() ? BWorkFlow.GetAutoTaskTitle(FlowID, StepID, Request.QueryString[\"groupid\"]) : TaskTitle)");
      stringBuilder.AppendFormat("<input type=\"hidden\" id=\"Form_TitleField\" name=\"Form_TitleField\" value=\"{0}\" />\r\n", (object) (jsonData["dbtable"].ToString() + "." + jsonData["dbtabletitle"].ToString()));
      stringBuilder.AppendFormat("<input type=\"hidden\" id=\"Form_DBConnID\" name=\"Form_DBConnID\" value=\"{0}\" />\r\n", (object) jsonData["dbconn"].ToString());
      stringBuilder.AppendFormat("<input type=\"hidden\" id=\"Form_DBTable\" name=\"Form_DBTable\" value=\"{0}\" />\r\n", (object) jsonData["dbtable"].ToString());
      stringBuilder.AppendFormat("<input type=\"hidden\" id=\"Form_DBTablePk\" name=\"Form_DBTablePk\" value=\"{0}\" />\r\n", (object) jsonData["dbtablepk"].ToString());
      stringBuilder.AppendFormat("<input type=\"hidden\" id=\"Form_DBTableTitle\" name=\"Form_DBTableTitle\" value=\"{0}\" />\r\n", (object) jsonData["dbtabletitle"].ToString());
      stringBuilder.AppendFormat("<input type=\"hidden\" id=\"Form_AutoSaveData\" name=\"Form_AutoSaveData\" value=\"{0}\" />\r\n", (object) "1");
      stringBuilder.AppendFormat("<textarea id=\"Form_DBTableTitleExpression\" name=\"Form_DBTableTitleExpression\" style=\"display:none;width:0;height:0;\">{0}</textarea>\r\n", jsonData.ContainsKey("dbtabletitle1") ? (object) jsonData["dbtabletitle1"].ToString() : (object) "");
      stringBuilder.Append("<script type=\"text/javascript\">\r\n");
      stringBuilder.Append("\tvar initData = @Html.Raw(BWorkFlow.GetFormDataJsonString(initData));\r\n");
      stringBuilder.Append("\tvar fieldStatus = \"1\"==\"@Request.QueryString[\"isreadonly\"]\" ? {} : @Html.Raw(fieldStatus);\r\n");
      stringBuilder.Append("\tvar displayModel = '@DisplayModel';\r\n");
      stringBuilder.Append("\t$(window).load(function (){\r\n");
      stringBuilder.AppendFormat("\t\tformrun.initData(initData, \"{0}\", fieldStatus, displayModel);\r\n", (object) jsonData["dbtable"].ToString());
      stringBuilder.Append("\t});\r\n");
      stringBuilder.Append("</script>\r\n");
      FileStream fileStream = File.Open(this.Server.MapPath("~/Views/WorkFlowFormDesigner/Forms/" + str5), FileMode.OpenOrCreate, FileAccess.Write, FileShare.None);
      fileStream.SetLength(0L);
      StreamWriter streamWriter = new StreamWriter((Stream) fileStream, Encoding.UTF8);
      streamWriter.Write(stringBuilder.ToString());
      streamWriter.Write(this.Server.HtmlDecode(s));
      streamWriter.Close();
      fileStream.Close();
      string str7 = JsonMapper.ToObject(model1.Attribute)["apptype"].ToString();
      RoadFlow.Platform.AppLibrary appLibrary = new RoadFlow.Platform.AppLibrary();
      RoadFlow.Data.Model.AppLibrary model2 = appLibrary.GetByCode(str3, true);
      bool flag = false;
      if (model2 == null)
      {
        model2 = new RoadFlow.Data.Model.AppLibrary();
        model2.ID = Guid.NewGuid();
        model2.Code = str3;
        flag = true;
      }
      model2.Address = "/Views/WorkFlowFormDesigner/Forms/" + str5;
      model2.Note = "流程表单";
      model2.OpenMode = 0;
      model2.Params = "";
      model2.Title = str1.Trim();
      model2.Type = str7.IsGuid() ? str7.ToGuid() : new RoadFlow.Platform.Dictionary().GetIDByCode("FormTypes");
      if (flag)
        appLibrary.Add(model2);
      else
        appLibrary.Update(model2);
      RoadFlow.Platform.Log.Add("发布了流程表单", model2.Serialize() + "内容：" + s, RoadFlow.Platform.Log.Types.流程相关, "", "", (RoadFlow.Data.Model.Users) null);
      model1.Status = 1;
      workFlowForm.Update(model1);
      return "发布成功!";
    }

    [MyAttribute(CheckApp = false, CheckLogin = false)]
    public string GetFormGridHtml()
    {
      string msg;
      if (!WebMvc.Common.Tools.CheckLogin(out msg) && !RoadFlow.Platform.WeiXin.Organize.CheckLogin())
        return "";
      return new RoadFlow.Platform.WorkFlowForm().GetFormGridHtml(this.Request.Form["dbconnid"], this.Request.Form["dataformat"], this.Request.Form["datasource"], (this.Request.Form["datasource1"] ?? "").FilterWildcard(""), this.Request.Form["params"]);
    }

    [MyAttribute(CheckApp = false)]
    public void Export()
    {
      string str = new RoadFlow.Platform.WorkFlowForm().Export(this.Request.QueryString["formid"].ToGuid(), 1);
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
          if (WorkFlowFormDesignerController.\u003C\u003Eo__16.\u003C\u003Ep__0 == null)
          {
            // ISSUE: reference to a compiler-generated field
            WorkFlowFormDesignerController.\u003C\u003Eo__16.\u003C\u003Ep__0 = CallSite<Func<CallSite, object, string, object>>.Create(Binder.SetMember(CSharpBinderFlags.None, "script", typeof (WorkFlowFormDesignerController), (IEnumerable<CSharpArgumentInfo>) new CSharpArgumentInfo[2]
            {
              CSharpArgumentInfo.Create(CSharpArgumentInfoFlags.None, (string) null),
              CSharpArgumentInfo.Create(CSharpArgumentInfoFlags.UseCompileTimeType | CSharpArgumentInfoFlags.Constant, (string) null)
            }));
          }
          // ISSUE: reference to a compiler-generated field
          // ISSUE: reference to a compiler-generated field
          object obj = WorkFlowFormDesignerController.\u003C\u003Eo__16.\u003C\u003Ep__0.Target((CallSite) WorkFlowFormDesignerController.\u003C\u003Eo__16.\u003C\u003Ep__0, this.ViewBag, "alert('请选择要导入的文件!');");
          return (ActionResult) this.View();
        }
        string path = RoadFlow.Utility.Config.FilePath + "WorkFlowFormImportFiles\\" + Guid.NewGuid().ToString("N");
        if (!Directory.Exists(path))
          Directory.CreateDirectory(path);
        string str1 = path + "\\" + file.FileName;
        file.SaveAs(str1);
        string str2 = new RoadFlow.Platform.WorkFlowForm().Import(str1, 1);
        if ("1" == str2)
        {
          // ISSUE: reference to a compiler-generated field
          if (WorkFlowFormDesignerController.\u003C\u003Eo__16.\u003C\u003Ep__1 == null)
          {
            // ISSUE: reference to a compiler-generated field
            WorkFlowFormDesignerController.\u003C\u003Eo__16.\u003C\u003Ep__1 = CallSite<Func<CallSite, object, string, object>>.Create(Binder.SetMember(CSharpBinderFlags.None, "script", typeof (WorkFlowFormDesignerController), (IEnumerable<CSharpArgumentInfo>) new CSharpArgumentInfo[2]
            {
              CSharpArgumentInfo.Create(CSharpArgumentInfoFlags.None, (string) null),
              CSharpArgumentInfo.Create(CSharpArgumentInfoFlags.UseCompileTimeType | CSharpArgumentInfoFlags.Constant, (string) null)
            }));
          }
          // ISSUE: reference to a compiler-generated field
          // ISSUE: reference to a compiler-generated field
          object obj = WorkFlowFormDesignerController.\u003C\u003Eo__16.\u003C\u003Ep__1.Target((CallSite) WorkFlowFormDesignerController.\u003C\u003Eo__16.\u003C\u003Ep__1, this.ViewBag, "alert('导入成功!');new RoadUI.Window().reloadOpener();");
        }
        else
        {
          // ISSUE: reference to a compiler-generated field
          if (WorkFlowFormDesignerController.\u003C\u003Eo__16.\u003C\u003Ep__2 == null)
          {
            // ISSUE: reference to a compiler-generated field
            WorkFlowFormDesignerController.\u003C\u003Eo__16.\u003C\u003Ep__2 = CallSite<Func<CallSite, object, string, object>>.Create(Binder.SetMember(CSharpBinderFlags.None, "script", typeof (WorkFlowFormDesignerController), (IEnumerable<CSharpArgumentInfo>) new CSharpArgumentInfo[2]
            {
              CSharpArgumentInfo.Create(CSharpArgumentInfoFlags.None, (string) null),
              CSharpArgumentInfo.Create(CSharpArgumentInfoFlags.UseCompileTimeType, (string) null)
            }));
          }
          // ISSUE: reference to a compiler-generated field
          // ISSUE: reference to a compiler-generated field
          object obj = WorkFlowFormDesignerController.\u003C\u003Eo__16.\u003C\u003Ep__2.Target((CallSite) WorkFlowFormDesignerController.\u003C\u003Eo__16.\u003C\u003Ep__2, this.ViewBag, "alert('" + str2 + "');new RoadUI.Window().reloadOpener();");
        }
      }
      return (ActionResult) this.View();
    }
  }
}
