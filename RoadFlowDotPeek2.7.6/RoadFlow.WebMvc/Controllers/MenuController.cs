// Decompiled with JetBrains decompiler
// Type: WebMvc.Controllers.MenuController
// Assembly: WebMvc, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 43FD7615-6DC3-49FB-B263-7F7CC91AFA77
// Assembly location: C:\inetpub\wwwroot\RoadFlowMvc\bin\WebMvc.dll

using LitJson;
using Microsoft.CSharp.RuntimeBinder;
using RoadFlow.Utility;
using System;
using System.Collections.Generic;
using System.Data;
using System.Runtime.CompilerServices;
using System.Text;
using System.Web.Mvc;

namespace WebMvc.Controllers
{
  public class MenuController : MyController
  {
    public ActionResult Index()
    {
      return (ActionResult) this.View();
    }

    public ActionResult Empty()
    {
      return (ActionResult) this.View();
    }

    public ActionResult Tree()
    {
      return (ActionResult) this.View();
    }

    [MyAttribute(CheckApp = false)]
    public string Tree1()
    {
      DataTable allDataTable = new RoadFlow.Platform.Menu().GetAllDataTable(true);
      if (allDataTable.Rows.Count == 0)
        return "[]";
      DataRow[] dataRowArray1 = allDataTable.Select("ParentID='" + Guid.Empty.ToString() + "'");
      if (dataRowArray1.Length == 0)
        return "[]";
      DataRow[] dataRowArray2 = allDataTable.Select("ParentID='" + dataRowArray1[0]["ID"].ToString() + "'");
      StringBuilder stringBuilder = new StringBuilder("[", 1000);
      DataRow dataRow1 = dataRowArray1[0];
      string str1 = dataRow1["AppIco"].ToString();
      if (str1.IsNullOrEmpty())
        str1 = dataRow1["Ico"].ToString();
      stringBuilder.Append("{");
      stringBuilder.AppendFormat("\"id\":\"{0}\",", dataRow1["ID"]);
      stringBuilder.AppendFormat("\"title\":\"{0}\",", dataRow1["Title"]);
      stringBuilder.AppendFormat("\"ico\":\"{0}\",", (object) str1);
      stringBuilder.AppendFormat("\"link\":\"{0}\",", dataRow1["Address"]);
      stringBuilder.AppendFormat("\"type\":\"{0}\",", (object) "0");
      stringBuilder.AppendFormat("\"model\":\"{0}\",", dataRow1["OpenMode"]);
      stringBuilder.AppendFormat("\"width\":\"{0}\",", dataRow1["Width"]);
      stringBuilder.AppendFormat("\"height\":\"{0}\",", dataRow1["Height"]);
      stringBuilder.AppendFormat("\"hasChilds\":\"{0}\",", dataRowArray2.Length != 0 ? (object) "1" : (object) "0");
      stringBuilder.AppendFormat("\"childs\":[");
      for (int index = 0; index < dataRowArray2.Length; ++index)
      {
        DataRow dataRow2 = dataRowArray2[index];
        string str2 = dataRow2["AppIco"].ToString();
        if (str2.IsNullOrEmpty())
          str2 = dataRow2["Ico"].ToString();
        DataRow[] dataRowArray3 = allDataTable.Select("ParentID='" + dataRow2["ID"].ToString() + "'");
        stringBuilder.Append("{");
        stringBuilder.AppendFormat("\"id\":\"{0}\",", dataRow2["ID"]);
        stringBuilder.AppendFormat("\"title\":\"{0}\",", dataRow2["Title"]);
        stringBuilder.AppendFormat("\"ico\":\"{0}\",", (object) str2);
        stringBuilder.AppendFormat("\"link\":\"{0}\",", dataRow2["Address"]);
        stringBuilder.AppendFormat("\"type\":\"{0}\",", (object) "0");
        stringBuilder.AppendFormat("\"model\":\"{0}\",", dataRow2["OpenMode"]);
        stringBuilder.AppendFormat("\"width\":\"{0}\",", dataRow2["Width"]);
        stringBuilder.AppendFormat("\"height\":\"{0}\",", dataRow2["Height"]);
        stringBuilder.AppendFormat("\"hasChilds\":\"{0}\",", dataRowArray3.Length != 0 ? (object) "1" : (object) "0");
        stringBuilder.AppendFormat("\"childs\":[");
        stringBuilder.Append("]");
        stringBuilder.Append("}");
        if (index < dataRowArray2.Length - 1)
          stringBuilder.Append(",");
      }
      stringBuilder.Append("]");
      stringBuilder.Append("}");
      stringBuilder.Append("]");
      return stringBuilder.ToString();
    }

    [MyAttribute(CheckApp = false)]
    public string TreeRefresh()
    {
      string str1 = this.Request["refreshid"];
      if (!str1.IsGuid())
        return "[]";
      RoadFlow.Platform.Menu menu = new RoadFlow.Platform.Menu();
      DataRow[] dataRowArray = menu.GetAllDataTable(true).Select("ParentID='" + str1 + "'");
      StringBuilder stringBuilder = new StringBuilder("[", dataRowArray.Length * 50);
      int length = dataRowArray.Length;
      int num = 0;
      foreach (DataRow dataRow in dataRowArray)
      {
        string str2 = dataRow["AppIco"].ToString();
        if (str2.IsNullOrEmpty())
          str2 = dataRow["Ico"].ToString();
        stringBuilder.Append("{");
        stringBuilder.AppendFormat("\"id\":\"{0}\",", dataRow["ID"]);
        stringBuilder.AppendFormat("\"title\":\"{0}\",", dataRow["Title"]);
        stringBuilder.AppendFormat("\"ico\":\"{0}\",", (object) str2);
        stringBuilder.AppendFormat("\"link\":\"{0}\",", (object) "");
        stringBuilder.AppendFormat("\"type\":\"{0}\",", (object) "0");
        stringBuilder.AppendFormat("\"model\":\"{0}\",", (object) "");
        stringBuilder.AppendFormat("\"width\":\"{0}\",", (object) "");
        stringBuilder.AppendFormat("\"height\":\"{0}\",", (object) "");
        stringBuilder.AppendFormat("\"hasChilds\":\"{0}\",", menu.HasChild(dataRow["ID"].ToString().ToGuid()) ? (object) "1" : (object) "0");
        stringBuilder.AppendFormat("\"childs\":[");
        stringBuilder.Append("]");
        stringBuilder.Append("}");
        if (num++ < length - 1)
          stringBuilder.Append(",");
      }
      stringBuilder.Append("]");
      return stringBuilder.ToString();
    }

    public ActionResult Body()
    {
      return this.Body((FormCollection) null);
    }

    [HttpPost]
    [ValidateAntiForgeryToken]
    public ActionResult Body(FormCollection collection)
    {
      RoadFlow.Platform.AppLibrary appLibrary1 = new RoadFlow.Platform.AppLibrary();
      RoadFlow.Platform.Menu menu = new RoadFlow.Platform.Menu();
      RoadFlow.Data.Model.Menu model = (RoadFlow.Data.Model.Menu) null;
      string str1 = this.Request.QueryString["id"];
      string empty1 = string.Empty;
      string empty2 = string.Empty;
      string empty3 = string.Empty;
      string empty4 = string.Empty;
      string empty5 = string.Empty;
      string empty6 = string.Empty;
      Guid id1;
      ref Guid local = ref id1;
      if (str1.IsGuid(out local))
        model = menu.Get(id1);
      Guid guid;
      if (!this.Request.Form["Save"].IsNullOrEmpty())
      {
        string str2 = this.Request.Form["Name"];
        empty2 = this.Request.Form["Type"];
        string str3 = this.Request.Form["AppID"];
        string str4 = this.Request.Form["Params"];
        string str5 = this.Request.Form["Ico"];
        string str6 = this.Request.Form["IcoColor"];
        string oldXML = model.Serialize();
        model.Title = str2.Trim();
        model.AppLibraryID = !str3.IsGuid() ? new Guid?() : new Guid?(str3.ToGuid());
        model.Params = str4.IsNullOrEmpty() ? (string) null : str4.Trim();
        model.Ico = str5.IsNullOrEmpty() ? (string) null : str5;
        model.IcoColor = str6.IsNullOrEmpty() ? (string) null : str6;
        menu.Update(model);
        RoadFlow.Platform.Log.Add("修改了菜单", "", RoadFlow.Platform.Log.Types.菜单权限, oldXML, model.Serialize(), (RoadFlow.Data.Model.Users) null);
        string str7;
        if (!(model.ParentID == Guid.Empty))
        {
          guid = model.ParentID;
          str7 = guid.ToString();
        }
        else
        {
          guid = model.ID;
          str7 = guid.ToString();
        }
        string str8 = str7;
        // ISSUE: reference to a compiler-generated field
        if (MenuController.\u003C\u003Eo__6.\u003C\u003Ep__0 == null)
        {
          // ISSUE: reference to a compiler-generated field
          MenuController.\u003C\u003Eo__6.\u003C\u003Ep__0 = CallSite<Func<CallSite, object, string, object>>.Create(Binder.SetMember(CSharpBinderFlags.None, "Script", typeof (MenuController), (IEnumerable<CSharpArgumentInfo>) new CSharpArgumentInfo[2]
          {
            CSharpArgumentInfo.Create(CSharpArgumentInfoFlags.None, (string) null),
            CSharpArgumentInfo.Create(CSharpArgumentInfoFlags.UseCompileTimeType, (string) null)
          }));
        }
        // ISSUE: reference to a compiler-generated field
        // ISSUE: reference to a compiler-generated field
        object obj = MenuController.\u003C\u003Eo__6.\u003C\u003Ep__0.Target((CallSite) MenuController.\u003C\u003Eo__6.\u003C\u003Ep__0, this.ViewBag, "parent.frames[0].reLoad('" + str8 + "');alert('保存成功!');");
        menu.ClearAllDataTableCache();
      }
      if (!this.Request.Form["Delete"].IsNullOrEmpty())
      {
        RoadFlow.Platform.Log.Add("删除了菜单及其所有下级共" + menu.DeleteAndAllChilds(model.ID).ToString() + "项", model.Serialize(), RoadFlow.Platform.Log.Types.菜单权限, "", "", (RoadFlow.Data.Model.Users) null);
        string str2;
        if (!(model.ParentID == Guid.Empty))
        {
          guid = model.ParentID;
          str2 = guid.ToString();
        }
        else
        {
          guid = model.ID;
          str2 = guid.ToString();
        }
        string str3 = str2;
        // ISSUE: reference to a compiler-generated field
        if (MenuController.\u003C\u003Eo__6.\u003C\u003Ep__1 == null)
        {
          // ISSUE: reference to a compiler-generated field
          MenuController.\u003C\u003Eo__6.\u003C\u003Ep__1 = CallSite<Func<CallSite, object, string, object>>.Create(Binder.SetMember(CSharpBinderFlags.None, "Script", typeof (MenuController), (IEnumerable<CSharpArgumentInfo>) new CSharpArgumentInfo[2]
          {
            CSharpArgumentInfo.Create(CSharpArgumentInfoFlags.None, (string) null),
            CSharpArgumentInfo.Create(CSharpArgumentInfoFlags.UseCompileTimeType, (string) null)
          }));
        }
        // ISSUE: reference to a compiler-generated field
        // ISSUE: reference to a compiler-generated field
        object obj = MenuController.\u003C\u003Eo__6.\u003C\u003Ep__1.Target((CallSite) MenuController.\u003C\u003Eo__6.\u003C\u003Ep__1, this.ViewBag, "parent.frames[0].reLoad('" + str3 + "');window.location='Body?id=" + str3 + "&appid=" + this.Request.QueryString["appid"] + "&tabid=" + this.Request.QueryString["tabid"] + "';");
        menu.ClearAllDataTableCache();
      }
      Guid? appLibraryId;
      if (model != null)
      {
        appLibraryId = model.AppLibraryID;
        if (appLibraryId.HasValue)
        {
          RoadFlow.Platform.AppLibrary appLibrary2 = new RoadFlow.Platform.AppLibrary();
          appLibraryId = model.AppLibraryID;
          Guid id2 = appLibraryId.Value;
          int num = 0;
          RoadFlow.Data.Model.AppLibrary appLibrary3 = appLibrary2.Get(id2, num != 0);
          if (appLibrary3 != null)
          {
            guid = appLibrary3.Type;
            empty2 = guid.ToString();
          }
        }
      }
      // ISSUE: reference to a compiler-generated field
      if (MenuController.\u003C\u003Eo__6.\u003C\u003Ep__2 == null)
      {
        // ISSUE: reference to a compiler-generated field
        MenuController.\u003C\u003Eo__6.\u003C\u003Ep__2 = CallSite<Func<CallSite, object, string, object>>.Create(Binder.SetMember(CSharpBinderFlags.None, "AppTypesOptions", typeof (MenuController), (IEnumerable<CSharpArgumentInfo>) new CSharpArgumentInfo[2]
        {
          CSharpArgumentInfo.Create(CSharpArgumentInfoFlags.None, (string) null),
          CSharpArgumentInfo.Create(CSharpArgumentInfoFlags.UseCompileTimeType, (string) null)
        }));
      }
      // ISSUE: reference to a compiler-generated field
      // ISSUE: reference to a compiler-generated field
      object obj1 = MenuController.\u003C\u003Eo__6.\u003C\u003Ep__2.Target((CallSite) MenuController.\u003C\u003Eo__6.\u003C\u003Ep__2, this.ViewBag, appLibrary1.GetTypeOptions(empty2));
      // ISSUE: reference to a compiler-generated field
      if (MenuController.\u003C\u003Eo__6.\u003C\u003Ep__3 == null)
      {
        // ISSUE: reference to a compiler-generated field
        MenuController.\u003C\u003Eo__6.\u003C\u003Ep__3 = CallSite<Func<CallSite, object, string, object>>.Create(Binder.SetMember(CSharpBinderFlags.None, "AppID", typeof (MenuController), (IEnumerable<CSharpArgumentInfo>) new CSharpArgumentInfo[2]
        {
          CSharpArgumentInfo.Create(CSharpArgumentInfoFlags.None, (string) null),
          CSharpArgumentInfo.Create(CSharpArgumentInfoFlags.UseCompileTimeType, (string) null)
        }));
      }
      // ISSUE: reference to a compiler-generated field
      Func<CallSite, object, string, object> target = MenuController.\u003C\u003Eo__6.\u003C\u003Ep__3.Target;
      // ISSUE: reference to a compiler-generated field
      CallSite<Func<CallSite, object, string, object>> p3 = MenuController.\u003C\u003Eo__6.\u003C\u003Ep__3;
      object viewBag = this.ViewBag;
      appLibraryId = model.AppLibraryID;
      string str9 = appLibraryId.ToString();
      object obj2 = target((CallSite) p3, viewBag, str9);
      return (ActionResult) this.View((object) model);
    }

    [MyAttribute(CheckApp = false)]
    public string GetApps()
    {
      return new RoadFlow.Platform.AppLibrary().GetAppsOptions(this.Request.Form["type"].ToGuid(), this.Request.Form["value"]);
    }

    public ActionResult AddApp()
    {
      return this.AddApp((FormCollection) null);
    }

    [HttpPost]
    [ValidateAntiForgeryToken]
    public ActionResult AddApp(FormCollection collection)
    {
      RoadFlow.Platform.AppLibrary appLibrary = new RoadFlow.Platform.AppLibrary();
      RoadFlow.Platform.Menu menu = new RoadFlow.Platform.Menu();
      string str1 = this.Request.QueryString["id"];
      if (collection != null)
      {
        menu.Get(str1.ToGuid());
        if (!this.Request.Form["Save"].IsNullOrEmpty())
        {
          string str2 = this.Request.Form["Name"];
          string str3 = this.Request.Form["Type"];
          string str4 = this.Request.Form["AppID"];
          string str5 = this.Request.Form["Params"];
          string str6 = this.Request.Form["Ico"];
          string str7 = this.Request.Form["IcoColor"];
          RoadFlow.Data.Model.Menu model = new RoadFlow.Data.Model.Menu() { ID = Guid.NewGuid(), ParentID = str1.ToGuid(), Title = str2.Trim() };
          model.Sort = menu.GetMaxSort(model.ParentID);
          model.AppLibraryID = !str4.IsGuid() ? new Guid?() : new Guid?(str4.ToGuid());
          model.Params = str5.IsNullOrEmpty() ? (string) null : str5.Trim();
          if (!str6.IsNullOrEmpty())
            model.Ico = str6;
          if (!str7.IsNullOrEmpty())
            model.IcoColor = str7;
          menu.Add(model);
          RoadFlow.Platform.Log.Add("添加了菜单", model.Serialize(), RoadFlow.Platform.Log.Types.菜单权限, "", "", (RoadFlow.Data.Model.Users) null);
          string str8 = str1;
          // ISSUE: reference to a compiler-generated field
          if (MenuController.\u003C\u003Eo__9.\u003C\u003Ep__0 == null)
          {
            // ISSUE: reference to a compiler-generated field
            MenuController.\u003C\u003Eo__9.\u003C\u003Ep__0 = CallSite<Func<CallSite, object, string, object>>.Create(Binder.SetMember(CSharpBinderFlags.None, "Script", typeof (MenuController), (IEnumerable<CSharpArgumentInfo>) new CSharpArgumentInfo[2]
            {
              CSharpArgumentInfo.Create(CSharpArgumentInfoFlags.None, (string) null),
              CSharpArgumentInfo.Create(CSharpArgumentInfoFlags.UseCompileTimeType, (string) null)
            }));
          }
          // ISSUE: reference to a compiler-generated field
          // ISSUE: reference to a compiler-generated field
          object obj = MenuController.\u003C\u003Eo__9.\u003C\u003Ep__0.Target((CallSite) MenuController.\u003C\u003Eo__9.\u003C\u003Ep__0, this.ViewBag, "alert('添加成功');parent.frames[0].reLoad('" + str8 + "');");
          menu.ClearAllDataTableCache();
        }
      }
      // ISSUE: reference to a compiler-generated field
      if (MenuController.\u003C\u003Eo__9.\u003C\u003Ep__1 == null)
      {
        // ISSUE: reference to a compiler-generated field
        MenuController.\u003C\u003Eo__9.\u003C\u003Ep__1 = CallSite<Func<CallSite, object, string, object>>.Create(Binder.SetMember(CSharpBinderFlags.None, "AppTypesOptions", typeof (MenuController), (IEnumerable<CSharpArgumentInfo>) new CSharpArgumentInfo[2]
        {
          CSharpArgumentInfo.Create(CSharpArgumentInfoFlags.None, (string) null),
          CSharpArgumentInfo.Create(CSharpArgumentInfoFlags.UseCompileTimeType, (string) null)
        }));
      }
      // ISSUE: reference to a compiler-generated field
      // ISSUE: reference to a compiler-generated field
      object obj1 = MenuController.\u003C\u003Eo__9.\u003C\u003Ep__1.Target((CallSite) MenuController.\u003C\u003Eo__9.\u003C\u003Ep__1, this.ViewBag, appLibrary.GetTypeOptions(""));
      return (ActionResult) this.View();
    }

    public ActionResult Sort()
    {
      return this.Sort((FormCollection) null);
    }

    [HttpPost]
    [ValidateAntiForgeryToken]
    public ActionResult Sort(FormCollection collection)
    {
      RoadFlow.Platform.Menu menu1 = new RoadFlow.Platform.Menu();
      List<RoadFlow.Data.Model.Menu> menuList = new List<RoadFlow.Data.Model.Menu>();
      string str1 = this.Request.QueryString["id"];
      RoadFlow.Data.Model.Menu menu2 = menu1.Get(str1.ToGuid());
      List<RoadFlow.Data.Model.Menu> child = menu1.GetChild(menu2.ParentID);
      if (collection != null)
      {
        string str2 = this.Request.Form["sortapp"];
        if (str2.IsNullOrEmpty())
          return (ActionResult) this.View((object) child);
        string[] strArray = str2.Split(',');
        for (int index = 0; index < strArray.Length; ++index)
        {
          Guid test;
          if (strArray[index].IsGuid(out test))
            menu1.UpdateSort(test, index + 1);
        }
        string str3 = menu2.ParentID.ToString();
        // ISSUE: reference to a compiler-generated field
        if (MenuController.\u003C\u003Eo__11.\u003C\u003Ep__0 == null)
        {
          // ISSUE: reference to a compiler-generated field
          MenuController.\u003C\u003Eo__11.\u003C\u003Ep__0 = CallSite<Func<CallSite, object, string, object>>.Create(Binder.SetMember(CSharpBinderFlags.None, "Script", typeof (MenuController), (IEnumerable<CSharpArgumentInfo>) new CSharpArgumentInfo[2]
          {
            CSharpArgumentInfo.Create(CSharpArgumentInfoFlags.None, (string) null),
            CSharpArgumentInfo.Create(CSharpArgumentInfoFlags.UseCompileTimeType, (string) null)
          }));
        }
        // ISSUE: reference to a compiler-generated field
        // ISSUE: reference to a compiler-generated field
        object obj = MenuController.\u003C\u003Eo__11.\u003C\u003Ep__0.Target((CallSite) MenuController.\u003C\u003Eo__11.\u003C\u003Ep__0, this.ViewBag, "parent.frames[0].reLoad('" + str3 + "');");
        child = menu1.GetChild(menu2.ParentID);
        menu1.ClearAllDataTableCache();
      }
      return (ActionResult) this.View((object) child);
    }

    public ActionResult Menu()
    {
      return (ActionResult) this.View();
    }

    public ActionResult Buttons()
    {
      string str = "&appid=" + this.Request.QueryString["appid"] + "&tabid=" + this.Request.QueryString["tabid"];
      // ISSUE: reference to a compiler-generated field
      if (MenuController.\u003C\u003Eo__13.\u003C\u003Ep__0 == null)
      {
        // ISSUE: reference to a compiler-generated field
        MenuController.\u003C\u003Eo__13.\u003C\u003Ep__0 = CallSite<Func<CallSite, object, string, object>>.Create(Binder.SetMember(CSharpBinderFlags.None, "Query", typeof (MenuController), (IEnumerable<CSharpArgumentInfo>) new CSharpArgumentInfo[2]
        {
          CSharpArgumentInfo.Create(CSharpArgumentInfoFlags.None, (string) null),
          CSharpArgumentInfo.Create(CSharpArgumentInfoFlags.UseCompileTimeType, (string) null)
        }));
      }
      // ISSUE: reference to a compiler-generated field
      // ISSUE: reference to a compiler-generated field
      object obj = MenuController.\u003C\u003Eo__13.\u003C\u003Ep__0.Target((CallSite) MenuController.\u003C\u003Eo__13.\u003C\u003Ep__0, this.ViewBag, str);
      return (ActionResult) this.View();
    }

    [HttpPost]
    [ValidateAntiForgeryToken]
    public string ButtonsQuery()
    {
      string title = this.Request.Form["Title"];
      string str1 = this.Request.Form["sidx"];
      string str2 = this.Request.Form["sord"];
      int pageSize = Tools.GetPageSize();
      int pageNumber = Tools.GetPageNumber();
      string order = (str1.IsNullOrEmpty() ? "Type" : str1) + " " + (str2.IsNullOrEmpty() ? "asc" : str2);
      long count;
      List<RoadFlow.Data.Model.AppLibraryButtons> pagerData = new RoadFlow.Platform.AppLibraryButtons().GetPagerData(out count, pageSize, pageNumber, title, order);
      JsonData jsonData = new JsonData();
      foreach (RoadFlow.Data.Model.AppLibraryButtons appLibraryButtons in pagerData)
        jsonData.Add((object) new JsonData()
        {
          ["id"] = (JsonData) appLibraryButtons.ID.ToString(),
          ["Name"] = (JsonData) appLibraryButtons.Name,
          ["Ico"] = (JsonData) (appLibraryButtons.Ico.IsNullOrEmpty() ? "" : (appLibraryButtons.Ico.IsFontIco() ? "<i class='fa " + appLibraryButtons.Ico + "' style='font-size:14px;vertical-align:middle;margin-right:3px;'></i>" : "<img src=\"" + this.Url.Content("~" + appLibraryButtons.Ico) + "\" style=\"vertical-align:middle;\" />")),
          ["Events"] = (JsonData) appLibraryButtons.Events,
          ["Note"] = (JsonData) appLibraryButtons.Note,
          ["Sort"] = (JsonData) appLibraryButtons.Sort,
          ["Opation"] = (JsonData) ("<a class=\"editlink\" href=\"javascript:void(0);\" onclick=\"add('" + (object) appLibraryButtons.ID + "');return false;\">编辑</a>")
        });
      return "{\"userdata\":{\"total\":" + (object) count + ",\"pagesize\":" + (object) pageSize + ",\"pagenumber\":" + (object) pageNumber + "},\"rows\":" + jsonData.ToJson(true) + "}";
    }

    public ActionResult ButtionsEdit()
    {
      return this.ButtionsEdit((FormCollection) null);
    }

    [HttpPost]
    [ValidateAntiForgeryToken]
    public ActionResult ButtionsEdit(FormCollection collection)
    {
      RoadFlow.Data.Model.AppLibraryButtons model = (RoadFlow.Data.Model.AppLibraryButtons) null;
      RoadFlow.Platform.AppLibraryButtons appLibraryButtons = new RoadFlow.Platform.AppLibraryButtons();
      string str1 = this.Request.QueryString["butid"];
      if (str1.IsGuid())
        model = appLibraryButtons.Get(str1.ToGuid());
      if (collection != null)
      {
        string str2 = this.Request.Form["Name"];
        string str3 = this.Request.Form["Events"];
        string str4 = this.Request.Form["Ico"];
        string str5 = this.Request.Form["Note"];
        string str6 = this.Request.Form["Sort"];
        bool flag = false;
        string oldXML = string.Empty;
        if (model == null)
        {
          flag = true;
          model = new RoadFlow.Data.Model.AppLibraryButtons();
          model.ID = Guid.NewGuid();
        }
        else
          oldXML = model.Serialize();
        model.Name = str2.Trim1();
        model.Events = str3;
        model.Ico = str4;
        model.Note = str5;
        model.Sort = str6.ToInt();
        if (flag)
        {
          appLibraryButtons.Add(model);
          RoadFlow.Platform.Log.Add("添加了按钮", model.Serialize(), RoadFlow.Platform.Log.Types.系统管理, "", "", (RoadFlow.Data.Model.Users) null);
        }
        else
        {
          appLibraryButtons.Update(model);
          RoadFlow.Platform.Log.Add("修改了按钮", model.Serialize(), RoadFlow.Platform.Log.Types.系统管理, oldXML, "", (RoadFlow.Data.Model.Users) null);
        }
        // ISSUE: reference to a compiler-generated field
        if (MenuController.\u003C\u003Eo__16.\u003C\u003Ep__0 == null)
        {
          // ISSUE: reference to a compiler-generated field
          MenuController.\u003C\u003Eo__16.\u003C\u003Ep__0 = CallSite<Func<CallSite, object, string, object>>.Create(Binder.SetMember(CSharpBinderFlags.None, "Script", typeof (MenuController), (IEnumerable<CSharpArgumentInfo>) new CSharpArgumentInfo[2]
          {
            CSharpArgumentInfo.Create(CSharpArgumentInfoFlags.None, (string) null),
            CSharpArgumentInfo.Create(CSharpArgumentInfoFlags.UseCompileTimeType | CSharpArgumentInfoFlags.Constant, (string) null)
          }));
        }
        // ISSUE: reference to a compiler-generated field
        // ISSUE: reference to a compiler-generated field
        object obj = MenuController.\u003C\u003Eo__16.\u003C\u003Ep__0.Target((CallSite) MenuController.\u003C\u003Eo__16.\u003C\u003Ep__0, this.ViewBag, "alert('保存成功!');new RoadUI.Window().getOpenerWindow().query();new RoadUI.Window().close();");
      }
      string str7 = "&appid=" + this.Request.QueryString["appid"] + "&tabid=" + this.Request.QueryString["tabid"] + "&title=";
      // ISSUE: reference to a compiler-generated field
      if (MenuController.\u003C\u003Eo__16.\u003C\u003Ep__1 == null)
      {
        // ISSUE: reference to a compiler-generated field
        MenuController.\u003C\u003Eo__16.\u003C\u003Ep__1 = CallSite<Func<CallSite, object, string, object>>.Create(Binder.SetMember(CSharpBinderFlags.None, "Query", typeof (MenuController), (IEnumerable<CSharpArgumentInfo>) new CSharpArgumentInfo[2]
        {
          CSharpArgumentInfo.Create(CSharpArgumentInfoFlags.None, (string) null),
          CSharpArgumentInfo.Create(CSharpArgumentInfoFlags.UseCompileTimeType, (string) null)
        }));
      }
      // ISSUE: reference to a compiler-generated field
      // ISSUE: reference to a compiler-generated field
      object obj1 = MenuController.\u003C\u003Eo__16.\u003C\u003Ep__1.Target((CallSite) MenuController.\u003C\u003Eo__16.\u003C\u003Ep__1, this.ViewBag, str7);
      if (model == null)
      {
        model = new RoadFlow.Data.Model.AppLibraryButtons();
        model.Sort = appLibraryButtons.GetMaxSort();
      }
      return (ActionResult) this.View((object) model);
    }

    [HttpPost]
    [ValidateAntiForgeryToken]
    public string ButtionsDelete()
    {
      RoadFlow.Platform.AppLibraryButtons appLibraryButtons1 = new RoadFlow.Platform.AppLibraryButtons();
      string str1 = this.Request.Form["ids"] ?? "";
      char[] chArray = new char[1]{ ',' };
      foreach (string str2 in str1.Split(chArray))
      {
        RoadFlow.Data.Model.AppLibraryButtons appLibraryButtons2 = appLibraryButtons1.Get(str2.ToGuid());
        if (appLibraryButtons2 != null)
        {
          appLibraryButtons1.Delete(appLibraryButtons2.ID);
          RoadFlow.Platform.Log.Add("删除了按钮", appLibraryButtons2.Serialize(), RoadFlow.Platform.Log.Types.系统管理, "", "", (RoadFlow.Data.Model.Users) null);
        }
      }
      return "删除成功!";
    }

    public ActionResult Refresh()
    {
      return (ActionResult) this.View();
    }

    public string Refresh1()
    {
      new RoadFlow.Platform.MenuUser().RefreshUsers();
      return "更新完成!";
    }
  }
}
