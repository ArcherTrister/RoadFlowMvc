// Decompiled with JetBrains decompiler
// Type: WebMvc.Controllers.DocumentsController
// Assembly: WebMvc, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 43FD7615-6DC3-49FB-B263-7F7CC91AFA77
// Assembly location: C:\inetpub\wwwroot\RoadFlowMvc\bin\WebMvc.dll

using LitJson;
using Microsoft.CSharp.RuntimeBinder;
using RoadFlow.Platform.WeiXin;
using RoadFlow.Utility;
using System;
using System.Collections.Generic;
using System.Data;
using System.Runtime.CompilerServices;
using System.Text;
using System.Web.Mvc;

namespace WebMvc.Controllers
{
  public class DocumentsController : MyController
  {
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
    public ActionResult ListNoRead()
    {
      string str = "&appid=" + this.Request.QueryString["appid"] + "&tabid=" + this.Request.QueryString["tabid"] + "&dirid=" + this.Request.QueryString["dirid"];
      // ISSUE: reference to a compiler-generated field
      if (DocumentsController.\u003C\u003Eo__2.\u003C\u003Ep__0 == null)
      {
        // ISSUE: reference to a compiler-generated field
        DocumentsController.\u003C\u003Eo__2.\u003C\u003Ep__0 = CallSite<Func<CallSite, object, string, object>>.Create(Binder.SetMember(CSharpBinderFlags.None, "Query", typeof (DocumentsController), (IEnumerable<CSharpArgumentInfo>) new CSharpArgumentInfo[2]
        {
          CSharpArgumentInfo.Create(CSharpArgumentInfoFlags.None, (string) null),
          CSharpArgumentInfo.Create(CSharpArgumentInfoFlags.UseCompileTimeType, (string) null)
        }));
      }
      // ISSUE: reference to a compiler-generated field
      // ISSUE: reference to a compiler-generated field
      object obj = DocumentsController.\u003C\u003Eo__2.\u003C\u003Ep__0.Target((CallSite) DocumentsController.\u003C\u003Eo__2.\u003C\u003Ep__0, this.ViewBag, str);
      return (ActionResult) this.View();
    }

    public ActionResult List()
    {
      string str = "&appid=" + this.Request.QueryString["appid"] + "&tabid=" + this.Request.QueryString["tabid"] + "&dirid=" + this.Request.QueryString["dirid"];
      // ISSUE: reference to a compiler-generated field
      if (DocumentsController.\u003C\u003Eo__3.\u003C\u003Ep__0 == null)
      {
        // ISSUE: reference to a compiler-generated field
        DocumentsController.\u003C\u003Eo__3.\u003C\u003Ep__0 = CallSite<Func<CallSite, object, string, object>>.Create(Binder.SetMember(CSharpBinderFlags.None, "Query", typeof (DocumentsController), (IEnumerable<CSharpArgumentInfo>) new CSharpArgumentInfo[2]
        {
          CSharpArgumentInfo.Create(CSharpArgumentInfoFlags.None, (string) null),
          CSharpArgumentInfo.Create(CSharpArgumentInfoFlags.UseCompileTimeType, (string) null)
        }));
      }
      // ISSUE: reference to a compiler-generated field
      // ISSUE: reference to a compiler-generated field
      object obj = DocumentsController.\u003C\u003Eo__3.\u003C\u003Ep__0.Target((CallSite) DocumentsController.\u003C\u003Eo__3.\u003C\u003Ep__0, this.ViewBag, str);
      return (ActionResult) this.View();
    }

    public ActionResult DocAdd()
    {
      return this.DocAdd((FormCollection) null);
    }

    [HttpPost]
    [ValidateAntiForgeryToken]
    public ActionResult DocAdd(FormCollection collection)
    {
      string str1 = this.Request.QueryString["docid"];
      RoadFlow.Platform.Documents documents = new RoadFlow.Platform.Documents();
      RoadFlow.Platform.DocumentDirectory documentDirectory = new RoadFlow.Platform.DocumentDirectory();
      RoadFlow.Platform.DocumentsReadUsers documentsReadUsers = new RoadFlow.Platform.DocumentsReadUsers();
      RoadFlow.Data.Model.Documents model = (RoadFlow.Data.Model.Documents) null;
      if (str1.IsGuid())
        model = documents.Get(str1.ToGuid());
      if (collection != null)
      {
        string str2 = this.Request.Form["DirectoryID"];
        string str3 = this.Request.Form["Title1"];
        string str4 = this.Request.Form["ReadUsers"];
        string str5 = this.Request.Form["Source"];
        string str6 = this.Request.Form["Contents"];
        string str7 = this.Request.Form["Files"];
        string oldXML = string.Empty;
        bool flag = false;
        if (model == null)
        {
          flag = true;
          model = new RoadFlow.Data.Model.Documents();
          model.ID = Guid.NewGuid();
          model.ReadCount = 0;
          model.WriteTime = DateTimeNew.Now;
          model.WriteUserID = RoadFlow.Platform.Users.CurrentUserID;
          model.WriteUserName = RoadFlow.Platform.Users.CurrentUserName;
        }
        else
          oldXML = model.Serialize();
        model.Contents = str6;
        model.DirectoryID = str2.ToGuid();
        model.DirectoryName = documentDirectory.GetName(model.DirectoryID);
        model.EditTime = new DateTime?(DateTimeNew.Now);
        model.EditUserID = new Guid?(RoadFlow.Platform.Users.CurrentUserID);
        model.EditUserName = RoadFlow.Platform.Users.CurrentUserName;
        model.Files = str7;
        model.ReadUsers = str4;
        model.Source = str5.IsNullOrEmpty() ? " " : str5;
        model.Title = str3.Trim1();
        if (flag)
        {
          documents.Add(model);
          RoadFlow.Platform.Log.Add("添加了文档", model.Serialize(), RoadFlow.Platform.Log.Types.文档中心, "", "", (RoadFlow.Data.Model.Users) null);
        }
        else
        {
          documents.Update(model);
          RoadFlow.Platform.Log.Add("修改了文档", model.Serialize(), RoadFlow.Platform.Log.Types.文档中心, oldXML, model.Serialize(), (RoadFlow.Data.Model.Users) null);
        }
        List<RoadFlow.Data.Model.Users> usersList = model.ReadUsers.IsNullOrEmpty() ? documentDirectory.GetReadUsers(model.DirectoryID) : new RoadFlow.Platform.Organize().GetAllUsers(model.ReadUsers);
        documentsReadUsers.Delete(model.ID);
        bool isUse = RoadFlow.Platform.WeiXin.Config.IsUse;
        Message message = new Message();
        StringBuilder stringBuilder = new StringBuilder();
        foreach (RoadFlow.Data.Model.Users users in usersList)
        {
          documentsReadUsers.Add(new RoadFlow.Data.Model.DocumentsReadUsers()
          {
            DocumentID = model.ID,
            IsRead = 0,
            UserID = users.ID
          });
          if (isUse)
          {
            stringBuilder.Append(users.Account);
            stringBuilder.Append('|');
          }
        }
        string empty = string.Empty;
        string str8 = !flag ? "'DocRead" + this.Request.Url.Query + "'" : "'List" + this.Request.Url.Query + "'";
        if (isUse)
          message.SendText(model.Title, stringBuilder.ToString().TrimEnd('|'), "", "", 0, new Agents().GetAgentIDByCode("weixinagents_documents"), true);
        // ISSUE: reference to a compiler-generated field
        if (DocumentsController.\u003C\u003Eo__5.\u003C\u003Ep__0 == null)
        {
          // ISSUE: reference to a compiler-generated field
          DocumentsController.\u003C\u003Eo__5.\u003C\u003Ep__0 = CallSite<Func<CallSite, object, string, object>>.Create(Binder.SetMember(CSharpBinderFlags.None, "script", typeof (DocumentsController), (IEnumerable<CSharpArgumentInfo>) new CSharpArgumentInfo[2]
          {
            CSharpArgumentInfo.Create(CSharpArgumentInfoFlags.None, (string) null),
            CSharpArgumentInfo.Create(CSharpArgumentInfoFlags.UseCompileTimeType, (string) null)
          }));
        }
        // ISSUE: reference to a compiler-generated field
        // ISSUE: reference to a compiler-generated field
        object obj = DocumentsController.\u003C\u003Eo__5.\u003C\u003Ep__0.Target((CallSite) DocumentsController.\u003C\u003Eo__5.\u003C\u003Ep__0, this.ViewBag, "alert('保存成功!');window.location=" + str8 + ";");
      }
      if (model == null)
        model = new RoadFlow.Data.Model.Documents();
      return (ActionResult) this.View((object) model);
    }

    public ActionResult DirAdd()
    {
      return this.DirAdd((FormCollection) null);
    }

    [HttpPost]
    [ValidateAntiForgeryToken]
    public ActionResult DirAdd(FormCollection collection)
    {
      string str1 = this.Request.QueryString["DirID"];
      string str2 = this.Request.QueryString["currentDirID"];
      RoadFlow.Platform.DocumentDirectory documentDirectory = new RoadFlow.Platform.DocumentDirectory();
      RoadFlow.Data.Model.DocumentDirectory model = (RoadFlow.Data.Model.DocumentDirectory) null;
      if (str2.IsGuid())
        model = documentDirectory.Get(str2.ToGuid());
      if (collection != null)
      {
        string str3 = this.Request.Form["Name"];
        string str4 = this.Request.Form["ReadUsers"];
        string str5 = this.Request.Form["PublishUsers"];
        string str6 = this.Request.Form["ManageUsers"];
        string str7 = this.Request.Form["Sort"];
        bool flag = false;
        string oldXML = string.Empty;
        if (model == null)
        {
          flag = true;
          model = new RoadFlow.Data.Model.DocumentDirectory();
          model.ID = Guid.NewGuid();
          model.ParentID = str1.ToGuid();
        }
        else
          oldXML = model.Serialize();
        model.ManageUsers = str6;
        model.Name = str3.Trim1();
        model.PublishUsers = str5;
        model.ReadUsers = str4;
        model.Sort = str7.ToInt();
        if (flag)
        {
          documentDirectory.Add(model);
          RoadFlow.Platform.Log.Add("添加了栏目", model.Serialize(), RoadFlow.Platform.Log.Types.文档中心, "", "", (RoadFlow.Data.Model.Users) null);
        }
        else
        {
          documentDirectory.Update(model);
          RoadFlow.Platform.Log.Add("修改了栏目", model.Serialize(), RoadFlow.Platform.Log.Types.文档中心, oldXML, model.Serialize(), (RoadFlow.Data.Model.Users) null);
        }
        documentDirectory.ClearDirUsersCache(model.ID);
        documentDirectory.ClearCache();
        // ISSUE: reference to a compiler-generated field
        if (DocumentsController.\u003C\u003Eo__7.\u003C\u003Ep__0 == null)
        {
          // ISSUE: reference to a compiler-generated field
          DocumentsController.\u003C\u003Eo__7.\u003C\u003Ep__0 = CallSite<Func<CallSite, object, string, object>>.Create(Binder.SetMember(CSharpBinderFlags.None, "script", typeof (DocumentsController), (IEnumerable<CSharpArgumentInfo>) new CSharpArgumentInfo[2]
          {
            CSharpArgumentInfo.Create(CSharpArgumentInfoFlags.None, (string) null),
            CSharpArgumentInfo.Create(CSharpArgumentInfoFlags.UseCompileTimeType, (string) null)
          }));
        }
        // ISSUE: reference to a compiler-generated field
        // ISSUE: reference to a compiler-generated field
        object obj = DocumentsController.\u003C\u003Eo__7.\u003C\u003Ep__0.Target((CallSite) DocumentsController.\u003C\u003Eo__7.\u003C\u003Ep__0, this.ViewBag, "parent.frames[0].reLoad('" + (object) model.ParentID + "');alert('保存成功!');window.location='List" + this.Request.Url.Query + "';");
      }
      if (model == null)
      {
        model = new RoadFlow.Data.Model.DocumentDirectory();
        model.Sort = documentDirectory.GetMaxSort(str1.ToGuid());
        model.ParentID = str1.ToGuid();
      }
      return (ActionResult) this.View((object) model);
    }

    [HttpPost]
    [ValidateAntiForgeryToken]
    public ActionResult DirDelete(FormCollection collection)
    {
      string str1 = this.Request.QueryString["DirID"];
      string str2 = this.Request.QueryString["currentDirID"];
      RoadFlow.Platform.DocumentDirectory documentDirectory1 = new RoadFlow.Platform.DocumentDirectory();
      RoadFlow.Data.Model.DocumentDirectory documentDirectory2 = (RoadFlow.Data.Model.DocumentDirectory) null;
      if (str2.IsGuid())
        documentDirectory2 = documentDirectory1.Get(str2.ToGuid());
      if (documentDirectory2 == null)
      {
        // ISSUE: reference to a compiler-generated field
        if (DocumentsController.\u003C\u003Eo__8.\u003C\u003Ep__0 == null)
        {
          // ISSUE: reference to a compiler-generated field
          DocumentsController.\u003C\u003Eo__8.\u003C\u003Ep__0 = CallSite<Func<CallSite, object, string, object>>.Create(Binder.SetMember(CSharpBinderFlags.None, "script", typeof (DocumentsController), (IEnumerable<CSharpArgumentInfo>) new CSharpArgumentInfo[2]
          {
            CSharpArgumentInfo.Create(CSharpArgumentInfoFlags.None, (string) null),
            CSharpArgumentInfo.Create(CSharpArgumentInfoFlags.UseCompileTimeType, (string) null)
          }));
        }
        // ISSUE: reference to a compiler-generated field
        // ISSUE: reference to a compiler-generated field
        object obj = DocumentsController.\u003C\u003Eo__8.\u003C\u003Ep__0.Target((CallSite) DocumentsController.\u003C\u003Eo__8.\u003C\u003Ep__0, this.ViewBag, "alert('栏目为空!');window.location='List" + this.Request.Url.Query + "';");
        return (ActionResult) this.View();
      }
      if (documentDirectory2.ParentID == Guid.Empty)
      {
        // ISSUE: reference to a compiler-generated field
        if (DocumentsController.\u003C\u003Eo__8.\u003C\u003Ep__1 == null)
        {
          // ISSUE: reference to a compiler-generated field
          DocumentsController.\u003C\u003Eo__8.\u003C\u003Ep__1 = CallSite<Func<CallSite, object, string, object>>.Create(Binder.SetMember(CSharpBinderFlags.None, "script", typeof (DocumentsController), (IEnumerable<CSharpArgumentInfo>) new CSharpArgumentInfo[2]
          {
            CSharpArgumentInfo.Create(CSharpArgumentInfoFlags.None, (string) null),
            CSharpArgumentInfo.Create(CSharpArgumentInfoFlags.UseCompileTimeType | CSharpArgumentInfoFlags.Constant, (string) null)
          }));
        }
        // ISSUE: reference to a compiler-generated field
        // ISSUE: reference to a compiler-generated field
        object obj = DocumentsController.\u003C\u003Eo__8.\u003C\u003Ep__1.Target((CallSite) DocumentsController.\u003C\u003Eo__8.\u003C\u003Ep__1, this.ViewBag, "alert('根栏目不能删除根栏目!');window.location=window.location;");
        return (ActionResult) this.View();
      }
      string allChildIdString = documentDirectory1.GetAllChildIdString(documentDirectory2.ID);
      RoadFlow.Platform.Documents documents = new RoadFlow.Platform.Documents();
      string str3 = allChildIdString;
      char[] chArray = new char[1]{ ',' };
      foreach (string str4 in str3.Split(chArray))
      {
        documentDirectory1.Delete(str4.ToGuid());
        documents.DeleteByDirectoryID(str4.ToGuid());
        documentDirectory1.ClearDirUsersCache(str4.ToGuid());
      }
      documentDirectory1.ClearCache();
      RoadFlow.Platform.Log.Add("删除的文档栏目及其所有下级栏目", allChildIdString, RoadFlow.Platform.Log.Types.文档中心, "", "", (RoadFlow.Data.Model.Users) null);
      // ISSUE: reference to a compiler-generated field
      if (DocumentsController.\u003C\u003Eo__8.\u003C\u003Ep__2 == null)
      {
        // ISSUE: reference to a compiler-generated field
        DocumentsController.\u003C\u003Eo__8.\u003C\u003Ep__2 = CallSite<Func<CallSite, object, string, object>>.Create(Binder.SetMember(CSharpBinderFlags.None, "script", typeof (DocumentsController), (IEnumerable<CSharpArgumentInfo>) new CSharpArgumentInfo[2]
        {
          CSharpArgumentInfo.Create(CSharpArgumentInfoFlags.None, (string) null),
          CSharpArgumentInfo.Create(CSharpArgumentInfoFlags.UseCompileTimeType, (string) null)
        }));
      }
      // ISSUE: reference to a compiler-generated field
      // ISSUE: reference to a compiler-generated field
      object obj1 = DocumentsController.\u003C\u003Eo__8.\u003C\u003Ep__2.Target((CallSite) DocumentsController.\u003C\u003Eo__8.\u003C\u003Ep__2, this.ViewBag, "parent.frames[0].reLoad('" + (object) documentDirectory2.ParentID + "');alert('删除成功!');window.location='List" + this.Request.Url.Query + "';");
      return (ActionResult) this.View();
    }

    [MyAttribute(CheckApp = false, CheckUrl = false)]
    public ActionResult DocRead()
    {
      RoadFlow.Data.Model.Documents documents1 = (RoadFlow.Data.Model.Documents) null;
      RoadFlow.Platform.Documents documents2 = new RoadFlow.Platform.Documents();
      RoadFlow.Platform.DocumentsReadUsers documentsReadUsers = new RoadFlow.Platform.DocumentsReadUsers();
      bool flag = false;
      string str = this.Request.QueryString["docid"];
      Guid currentUserId = RoadFlow.Platform.Users.CurrentUserID;
      if (str.IsGuid())
      {
        documents1 = documents2.Get(str.ToGuid());
        if (documents1 != null)
        {
          if (documentsReadUsers.Get(documents1.ID, currentUserId) == null)
          {
            this.Response.Write("您无权查看该文档!");
            this.Response.End();
            return (ActionResult) null;
          }
          flag = new RoadFlow.Platform.DocumentDirectory().HasPublish(documents1.DirectoryID, currentUserId) || new RoadFlow.Platform.DocumentDirectory().HasManage(documents1.DirectoryID, currentUserId);
          documents2.UpdateReadCount(documents1.ID);
          documentsReadUsers.UpdateRead(documents1.ID, currentUserId);
        }
      }
      // ISSUE: reference to a compiler-generated field
      if (DocumentsController.\u003C\u003Eo__9.\u003C\u003Ep__0 == null)
      {
        // ISSUE: reference to a compiler-generated field
        DocumentsController.\u003C\u003Eo__9.\u003C\u003Ep__0 = CallSite<Func<CallSite, object, bool, object>>.Create(Binder.SetMember(CSharpBinderFlags.None, "IsEdit", typeof (DocumentsController), (IEnumerable<CSharpArgumentInfo>) new CSharpArgumentInfo[2]
        {
          CSharpArgumentInfo.Create(CSharpArgumentInfoFlags.None, (string) null),
          CSharpArgumentInfo.Create(CSharpArgumentInfoFlags.UseCompileTimeType, (string) null)
        }));
      }
      // ISSUE: reference to a compiler-generated field
      // ISSUE: reference to a compiler-generated field
      object obj = DocumentsController.\u003C\u003Eo__9.\u003C\u003Ep__0.Target((CallSite) DocumentsController.\u003C\u003Eo__9.\u003C\u003Ep__0, this.ViewBag, flag);
      if (documents1 == null)
        documents1 = new RoadFlow.Data.Model.Documents();
      return (ActionResult) this.View((object) documents1);
    }

    [HttpPost]
    [ValidateAntiForgeryToken]
    public string DocDelete()
    {
      RoadFlow.Data.Model.Documents documents1 = (RoadFlow.Data.Model.Documents) null;
      RoadFlow.Platform.Documents documents2 = new RoadFlow.Platform.Documents();
      string str = this.Request.QueryString["docid"];
      if (str.IsGuid())
        documents1 = documents2.Get(str.ToGuid());
      if (documents1 == null)
        return "未找到文档";
      documents2.Delete(documents1.ID);
      new RoadFlow.Platform.DocumentsReadUsers().Delete(documents1.ID);
      RoadFlow.Platform.Log.Add("删除了文档", documents1.Serialize(), RoadFlow.Platform.Log.Types.文档中心, "", "", (RoadFlow.Data.Model.Users) null);
      return "1";
    }

    [MyAttribute(CheckApp = false)]
    public string Tree1()
    {
      return new RoadFlow.Platform.DocumentDirectory().GetTreeJsonString();
    }

    [MyAttribute(CheckApp = false)]
    public string TreeRefresh()
    {
      string str = this.Request["refreshid"];
      if (str.IsGuid())
        return new RoadFlow.Platform.DocumentDirectory().GetTreeRefreshJsonString(str.ToGuid());
      return "[]";
    }

    [HttpPost]
    [ValidateAntiForgeryToken]
    [MyAttribute(CheckApp = false)]
    public string QueryNoRead()
    {
      string str1 = this.Request.Form["DirID"];
      string str2 = this.Request.Form["Title1"];
      string str3 = this.Request.Form["Date1"];
      string str4 = this.Request.Form["Date2"];
      string str5 = this.Request.Form["sidx"];
      string str6 = this.Request.Form["sord"];
      RoadFlow.Platform.Documents documents = new RoadFlow.Platform.Documents();
      RoadFlow.Platform.DocumentDirectory documentDirectory = new RoadFlow.Platform.DocumentDirectory();
      string str7 = "";
      if (str1.IsGuid())
        str7 = new RoadFlow.Platform.DocumentDirectory().GetAllChildIdString(str1.ToGuid(), RoadFlow.Platform.Users.CurrentUserID);
      int pageSize = Tools.GetPageSize();
      int pageNumber = Tools.GetPageNumber();
      string str8 = (str5.IsNullOrEmpty() ? "WriteTime" : str5) + " " + (str6.IsNullOrEmpty() ? "asc" : str6);
      long num1;
      ref long local = ref num1;
      int size = pageSize;
      int number = pageNumber;
      string dirID = str7;
      string userID = RoadFlow.Platform.Users.CurrentUserID.ToString();
      string title = str2.Trim1();
      string date1 = str3;
      string date2 = str4;
      int num2 = 1;
      string order = str8;
      DataTable list = documents.GetList(out local, size, number, dirID, userID, title, date1, date2, num2 != 0, order);
      JsonData jsonData = new JsonData();
      foreach (DataRow row in (InternalDataCollectionBase) list.Rows)
        jsonData.Add((object) new JsonData()
        {
          ["Title"] = (JsonData) ("<a class=\"blue\" href=\"javascript:;\" onclick='showDoc(\"" + row["ID"].ToString() + "\",\"{{window.encodeURIComponent(value.Title)}}\");return false;'>" + row["Title"].ToString() + "</a><span style=\"margin-left:5px;\"><img src=\"../Images/loading/new.png\" style=\"border:0 none; vertical-align:middle;\" /></span>"),
          ["DirectoryName"] = (JsonData) row["DirectoryName"].ToString(),
          ["WriteUserName"] = (JsonData) row["WriteUserName"].ToString(),
          ["WriteTime"] = (JsonData) row["WriteTime"].ToString().ToDateTimeString(),
          ["ReadCount"] = (JsonData) row["ReadCount"].ToString()
        });
      return "{\"userdata\":{\"total\":" + (object) num1 + ",\"pagesize\":" + (object) pageSize + ",\"pagenumber\":" + (object) pageNumber + "},\"rows\":" + jsonData.ToJson(true) + "}";
    }

    [HttpPost]
    [ValidateAntiForgeryToken]
    [MyAttribute(CheckApp = false)]
    public string Query()
    {
      string str1 = this.Request.Form["DirID"];
      string str2 = this.Request.Form["Title1"];
      string str3 = this.Request.Form["Date1"];
      string str4 = this.Request.Form["Date2"];
      string str5 = this.Request.Form["sidx"];
      string str6 = this.Request.Form["sord"];
      RoadFlow.Platform.Documents documents = new RoadFlow.Platform.Documents();
      RoadFlow.Platform.DocumentDirectory documentDirectory = new RoadFlow.Platform.DocumentDirectory();
      string str7 = "";
      if (str1.IsGuid())
        str7 = new RoadFlow.Platform.DocumentDirectory().GetAllChildIdString(str1.ToGuid(), RoadFlow.Platform.Users.CurrentUserID);
      int pageSize = Tools.GetPageSize();
      int pageNumber = Tools.GetPageNumber();
      string str8 = (str5.IsNullOrEmpty() ? "WriteTime" : str5) + " " + (str6.IsNullOrEmpty() ? "asc" : str6);
      long num1;
      ref long local = ref num1;
      int size = pageSize;
      int number = pageNumber;
      string dirID = str7;
      string userID = RoadFlow.Platform.Users.CurrentUserID.ToString();
      string title = str2.Trim1();
      string date1 = str3;
      string date2 = str4;
      int num2 = 0;
      string order = str8;
      DataTable list = documents.GetList(out local, size, number, dirID, userID, title, date1, date2, num2 != 0, order);
      JsonData jsonData = new JsonData();
      foreach (DataRow row in (InternalDataCollectionBase) list.Rows)
        jsonData.Add((object) new JsonData()
        {
          ["Title"] = (JsonData) ("<a class=\"blue\" href=\"javascript:;\" onclick='showDoc(\"" + row["ID"].ToString() + "\",\"{{window.encodeURIComponent(value.Title)}}\");return false;'>" + row["Title"].ToString() + "</a><span style=\"margin-left:5px;\">" + ("0" == row["IsRead"].ToString() ? "<img src=\"../Images/loading/new.png\" style=\"border:0 none; vertical-align:middle;\" />" : "") + "</span>"),
          ["DirectoryName"] = (JsonData) row["DirectoryName"].ToString(),
          ["WriteUserName"] = (JsonData) row["WriteUserName"].ToString(),
          ["WriteTime"] = (JsonData) row["WriteTime"].ToString().ToDateTimeString(),
          ["ReadCount"] = (JsonData) row["ReadCount"].ToString()
        });
      return "{\"userdata\":{\"total\":" + (object) num1 + ",\"pagesize\":" + (object) pageSize + ",\"pagenumber\":" + (object) pageNumber + "},\"rows\":" + jsonData.ToJson(true) + "}";
    }
  }
}
