// Decompiled with JetBrains decompiler
// Type: WebMvc.Controllers.DBConnectionController
// Assembly: WebMvc, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 43FD7615-6DC3-49FB-B263-7F7CC91AFA77
// Assembly location: C:\inetpub\wwwroot\RoadFlowMvc\bin\WebMvc.dll

using LitJson;
using Microsoft.CSharp.RuntimeBinder;
using RoadFlow.Utility;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Web.Mvc;

namespace WebMvc.Controllers
{
  public class DBConnectionController : MyController
  {
    public ActionResult Index()
    {
      string str = string.Format("&appid={0}&tabid={1}", (object) this.Request.QueryString["appid"], (object) this.Request.QueryString["tabid"]);
      List<RoadFlow.Data.Model.DBConnection> all = new RoadFlow.Platform.DBConnection().GetAll(false);
      JsonData jsonData = new JsonData();
      foreach (RoadFlow.Data.Model.DBConnection dbConnection in all)
        jsonData.Add((object) new JsonData()
        {
          ["id"] = (JsonData) dbConnection.ID.ToString(),
          ["Name"] = (JsonData) dbConnection.Name,
          ["Type"] = (JsonData) dbConnection.Type,
          ["ConnectionString"] = (JsonData) dbConnection.ConnectionString,
          ["Note"] = (JsonData) dbConnection.Note,
          ["Opation"] = (JsonData) ("<a class=\"editlink\" href=\"javascript:edit('" + (object) dbConnection.ID + "');\">编辑</a><a onclick=\"test('" + (object) dbConnection.ID + "');\" style=\"background:url(" + this.Url.Content("~/Images/ico/hammer_screwdriver.png") + ") no-repeat left center; padding-left:18px; margin-left:5px;\" href=\"javascript:void(0);\">测试</a><a onclick=\"table('" + (object) dbConnection.ID + "','" + dbConnection.Name + "');\" style=\"background:url(" + this.Url.Content("~/Images/ico/topic_search.gif") + ") no-repeat left center; padding-left:18px; margin-left:5px;\" href=\"javascript:void(0);\">管理表</a>")
        });
      // ISSUE: reference to a compiler-generated field
      if (DBConnectionController.\u003C\u003Eo__0.\u003C\u003Ep__0 == null)
      {
        // ISSUE: reference to a compiler-generated field
        DBConnectionController.\u003C\u003Eo__0.\u003C\u003Ep__0 = CallSite<Func<CallSite, object, string, object>>.Create(Binder.SetMember(CSharpBinderFlags.None, "Query1", typeof (DBConnectionController), (IEnumerable<CSharpArgumentInfo>) new CSharpArgumentInfo[2]
        {
          CSharpArgumentInfo.Create(CSharpArgumentInfoFlags.None, (string) null),
          CSharpArgumentInfo.Create(CSharpArgumentInfoFlags.UseCompileTimeType, (string) null)
        }));
      }
      // ISSUE: reference to a compiler-generated field
      // ISSUE: reference to a compiler-generated field
      object obj1 = DBConnectionController.\u003C\u003Eo__0.\u003C\u003Ep__0.Target((CallSite) DBConnectionController.\u003C\u003Eo__0.\u003C\u003Ep__0, this.ViewBag, str);
      // ISSUE: reference to a compiler-generated field
      if (DBConnectionController.\u003C\u003Eo__0.\u003C\u003Ep__1 == null)
      {
        // ISSUE: reference to a compiler-generated field
        DBConnectionController.\u003C\u003Eo__0.\u003C\u003Ep__1 = CallSite<Func<CallSite, object, string, object>>.Create(Binder.SetMember(CSharpBinderFlags.None, "list", typeof (DBConnectionController), (IEnumerable<CSharpArgumentInfo>) new CSharpArgumentInfo[2]
        {
          CSharpArgumentInfo.Create(CSharpArgumentInfoFlags.None, (string) null),
          CSharpArgumentInfo.Create(CSharpArgumentInfoFlags.UseCompileTimeType, (string) null)
        }));
      }
      // ISSUE: reference to a compiler-generated field
      // ISSUE: reference to a compiler-generated field
      object obj2 = DBConnectionController.\u003C\u003Eo__0.\u003C\u003Ep__1.Target((CallSite) DBConnectionController.\u003C\u003Eo__0.\u003C\u003Ep__1, this.ViewBag, jsonData.ToJson(true));
      return (ActionResult) this.View();
    }

    [HttpPost]
    [ValidateAntiForgeryToken]
    public string Delete()
    {
      RoadFlow.Platform.DBConnection dbConnection = new RoadFlow.Platform.DBConnection();
      string str1 = this.Request.Form["ids"];
      StringBuilder stringBuilder = new StringBuilder();
      char[] chArray = new char[1]{ ',' };
      foreach (string str2 in str1.Split(chArray))
      {
        Guid test;
        if (str2.IsGuid(out test))
        {
          stringBuilder.Append(dbConnection.Get(test, true).Serialize());
          dbConnection.Delete(test);
        }
      }
      dbConnection.ClearCache();
      RoadFlow.Platform.Log.Add("删除了数据连接", stringBuilder.ToString(), RoadFlow.Platform.Log.Types.流程相关, "", "", (RoadFlow.Data.Model.Users) null);
      return "删除成功!";
    }

    public ActionResult Edit()
    {
      return this.Edit((FormCollection) null);
    }

    [HttpPost]
    [ValidateAntiForgeryToken]
    public ActionResult Edit(FormCollection collection)
    {
      string str1 = this.Request.QueryString["id"];
      RoadFlow.Platform.DBConnection dbConnection = new RoadFlow.Platform.DBConnection();
      RoadFlow.Data.Model.DBConnection model = (RoadFlow.Data.Model.DBConnection) null;
      if (str1.IsGuid())
        model = dbConnection.Get(str1.ToGuid(), true);
      bool flag = !str1.IsGuid();
      string oldXML = string.Empty;
      if (model == null)
      {
        model = new RoadFlow.Data.Model.DBConnection();
        model.ID = Guid.NewGuid();
      }
      else
        oldXML = model.Serialize();
      if (collection != null)
      {
        string str2 = this.Request.Form["Name"];
        string str3 = this.Request.Form["LinkType"];
        string str4 = this.Request.Form["ConnStr"];
        string str5 = this.Request.Form["Note"];
        model.Name = str2.Trim();
        model.Type = str3;
        model.ConnectionString = str4;
        model.Note = str5;
        if (flag)
        {
          dbConnection.Add(model);
          RoadFlow.Platform.Log.Add("添加了数据库连接", model.Serialize(), RoadFlow.Platform.Log.Types.数据连接, "", "", (RoadFlow.Data.Model.Users) null);
          // ISSUE: reference to a compiler-generated field
          if (DBConnectionController.\u003C\u003Eo__3.\u003C\u003Ep__0 == null)
          {
            // ISSUE: reference to a compiler-generated field
            DBConnectionController.\u003C\u003Eo__3.\u003C\u003Ep__0 = CallSite<Func<CallSite, object, string, object>>.Create(Binder.SetMember(CSharpBinderFlags.None, "Script", typeof (DBConnectionController), (IEnumerable<CSharpArgumentInfo>) new CSharpArgumentInfo[2]
            {
              CSharpArgumentInfo.Create(CSharpArgumentInfoFlags.None, (string) null),
              CSharpArgumentInfo.Create(CSharpArgumentInfoFlags.UseCompileTimeType | CSharpArgumentInfoFlags.Constant, (string) null)
            }));
          }
          // ISSUE: reference to a compiler-generated field
          // ISSUE: reference to a compiler-generated field
          object obj = DBConnectionController.\u003C\u003Eo__3.\u003C\u003Ep__0.Target((CallSite) DBConnectionController.\u003C\u003Eo__3.\u003C\u003Ep__0, this.ViewBag, "alert('添加成功!');new RoadUI.Window().reloadOpener();new RoadUI.Window().close();");
        }
        else
        {
          dbConnection.Update(model);
          RoadFlow.Platform.Log.Add("修改了数据库连接", "", RoadFlow.Platform.Log.Types.数据连接, oldXML, model.Serialize(), (RoadFlow.Data.Model.Users) null);
          // ISSUE: reference to a compiler-generated field
          if (DBConnectionController.\u003C\u003Eo__3.\u003C\u003Ep__1 == null)
          {
            // ISSUE: reference to a compiler-generated field
            DBConnectionController.\u003C\u003Eo__3.\u003C\u003Ep__1 = CallSite<Func<CallSite, object, string, object>>.Create(Binder.SetMember(CSharpBinderFlags.None, "Script", typeof (DBConnectionController), (IEnumerable<CSharpArgumentInfo>) new CSharpArgumentInfo[2]
            {
              CSharpArgumentInfo.Create(CSharpArgumentInfoFlags.None, (string) null),
              CSharpArgumentInfo.Create(CSharpArgumentInfoFlags.UseCompileTimeType | CSharpArgumentInfoFlags.Constant, (string) null)
            }));
          }
          // ISSUE: reference to a compiler-generated field
          // ISSUE: reference to a compiler-generated field
          object obj = DBConnectionController.\u003C\u003Eo__3.\u003C\u003Ep__1.Target((CallSite) DBConnectionController.\u003C\u003Eo__3.\u003C\u003Ep__1, this.ViewBag, "alert('修改成功!');new RoadUI.Window().reloadOpener();new RoadUI.Window().close();");
        }
        dbConnection.ClearCache();
      }
      // ISSUE: reference to a compiler-generated field
      if (DBConnectionController.\u003C\u003Eo__3.\u003C\u003Ep__2 == null)
      {
        // ISSUE: reference to a compiler-generated field
        DBConnectionController.\u003C\u003Eo__3.\u003C\u003Ep__2 = CallSite<Func<CallSite, object, string, object>>.Create(Binder.SetMember(CSharpBinderFlags.None, "TypeOptions", typeof (DBConnectionController), (IEnumerable<CSharpArgumentInfo>) new CSharpArgumentInfo[2]
        {
          CSharpArgumentInfo.Create(CSharpArgumentInfoFlags.None, (string) null),
          CSharpArgumentInfo.Create(CSharpArgumentInfoFlags.UseCompileTimeType, (string) null)
        }));
      }
      // ISSUE: reference to a compiler-generated field
      // ISSUE: reference to a compiler-generated field
      object obj1 = DBConnectionController.\u003C\u003Eo__3.\u003C\u003Ep__2.Target((CallSite) DBConnectionController.\u003C\u003Eo__3.\u003C\u003Ep__2, this.ViewBag, dbConnection.GetAllTypeOptions(model.Type));
      return (ActionResult) this.View((object) model);
    }

    public string Test()
    {
      Guid test;
      if (!this.Request.QueryString["id"].IsGuid(out test))
        return "参数错误";
      return new RoadFlow.Platform.DBConnection().Test(test);
    }

    public ActionResult Table(FormCollection collection)
    {
      string str1 = this.Request.QueryString["connid"];
      List<Tuple<string, int>> tupleList = new List<Tuple<string, int>>();
      RoadFlow.Platform.DBConnection dbConnection1 = new RoadFlow.Platform.DBConnection();
      string empty1 = string.Empty;
      string empty2 = string.Empty;
      List<string> systemDataTables = RoadFlow.Utility.Config.SystemDataTables;
      if (!str1.IsGuid())
      {
        this.Response.Write("数据连接ID错误");
        this.Response.End();
        return (ActionResult) null;
      }
      RoadFlow.Data.Model.DBConnection dbConnection2 = dbConnection1.Get(str1.ToGuid(), true);
      if (dbConnection2 == null)
      {
        this.Response.Write("未找到数据连接");
        this.Response.End();
        return (ActionResult) null;
      }
      string type = dbConnection2.Type;
      foreach (string table in dbConnection1.GetTables(dbConnection2.ID, 1))
        tupleList.Add(new Tuple<string, int>(table, 0));
      foreach (string table in dbConnection1.GetTables(dbConnection2.ID, 2))
        tupleList.Add(new Tuple<string, int>(table, 1));
      JsonData jsonData = new JsonData();
      foreach (Tuple<string, int> tuple in tupleList)
      {
        Tuple<string, int> table = tuple;
        bool flag = systemDataTables.Find((Predicate<string>) (p => p.Equals(table.Item1, StringComparison.CurrentCultureIgnoreCase))) != null;
        StringBuilder stringBuilder = new StringBuilder("<a class=\"viewlink\" href=\"javascript:void(0);\" onclick=\"queryTable('" + str1 + "','" + table.Item1 + "');\">查询</a>");
        jsonData.Add((object) new JsonData()
        {
          ["Name"] = (JsonData) table.Item1,
          ["Type"] = (JsonData) (table.Item2 == 0 ? (flag ? "系统表" : "表") : "视图"),
          ["Opation"] = (JsonData) stringBuilder.ToString()
        });
      }
      string str2 = "&connid=" + str1 + "&appid=" + this.Request.QueryString["appid"] + "&tabid=" + this.Request.QueryString["tabid"];
      // ISSUE: reference to a compiler-generated field
      if (DBConnectionController.\u003C\u003Eo__5.\u003C\u003Ep__0 == null)
      {
        // ISSUE: reference to a compiler-generated field
        DBConnectionController.\u003C\u003Eo__5.\u003C\u003Ep__0 = CallSite<Func<CallSite, object, string, object>>.Create(Binder.SetMember(CSharpBinderFlags.None, "Query", typeof (DBConnectionController), (IEnumerable<CSharpArgumentInfo>) new CSharpArgumentInfo[2]
        {
          CSharpArgumentInfo.Create(CSharpArgumentInfoFlags.None, (string) null),
          CSharpArgumentInfo.Create(CSharpArgumentInfoFlags.UseCompileTimeType, (string) null)
        }));
      }
      // ISSUE: reference to a compiler-generated field
      // ISSUE: reference to a compiler-generated field
      object obj1 = DBConnectionController.\u003C\u003Eo__5.\u003C\u003Ep__0.Target((CallSite) DBConnectionController.\u003C\u003Eo__5.\u003C\u003Ep__0, this.ViewBag, str2);
      // ISSUE: reference to a compiler-generated field
      if (DBConnectionController.\u003C\u003Eo__5.\u003C\u003Ep__1 == null)
      {
        // ISSUE: reference to a compiler-generated field
        DBConnectionController.\u003C\u003Eo__5.\u003C\u003Ep__1 = CallSite<Func<CallSite, object, string, object>>.Create(Binder.SetMember(CSharpBinderFlags.None, "dbconnID", typeof (DBConnectionController), (IEnumerable<CSharpArgumentInfo>) new CSharpArgumentInfo[2]
        {
          CSharpArgumentInfo.Create(CSharpArgumentInfoFlags.None, (string) null),
          CSharpArgumentInfo.Create(CSharpArgumentInfoFlags.UseCompileTimeType, (string) null)
        }));
      }
      // ISSUE: reference to a compiler-generated field
      // ISSUE: reference to a compiler-generated field
      object obj2 = DBConnectionController.\u003C\u003Eo__5.\u003C\u003Ep__1.Target((CallSite) DBConnectionController.\u003C\u003Eo__5.\u003C\u003Ep__1, this.ViewBag, str1);
      // ISSUE: reference to a compiler-generated field
      if (DBConnectionController.\u003C\u003Eo__5.\u003C\u003Ep__2 == null)
      {
        // ISSUE: reference to a compiler-generated field
        DBConnectionController.\u003C\u003Eo__5.\u003C\u003Ep__2 = CallSite<Func<CallSite, object, string, object>>.Create(Binder.SetMember(CSharpBinderFlags.None, "DBType", typeof (DBConnectionController), (IEnumerable<CSharpArgumentInfo>) new CSharpArgumentInfo[2]
        {
          CSharpArgumentInfo.Create(CSharpArgumentInfoFlags.None, (string) null),
          CSharpArgumentInfo.Create(CSharpArgumentInfoFlags.UseCompileTimeType, (string) null)
        }));
      }
      // ISSUE: reference to a compiler-generated field
      // ISSUE: reference to a compiler-generated field
      object obj3 = DBConnectionController.\u003C\u003Eo__5.\u003C\u003Ep__2.Target((CallSite) DBConnectionController.\u003C\u003Eo__5.\u003C\u003Ep__2, this.ViewBag, type);
      // ISSUE: reference to a compiler-generated field
      if (DBConnectionController.\u003C\u003Eo__5.\u003C\u003Ep__3 == null)
      {
        // ISSUE: reference to a compiler-generated field
        DBConnectionController.\u003C\u003Eo__5.\u003C\u003Ep__3 = CallSite<Func<CallSite, object, string, object>>.Create(Binder.SetMember(CSharpBinderFlags.None, "list", typeof (DBConnectionController), (IEnumerable<CSharpArgumentInfo>) new CSharpArgumentInfo[2]
        {
          CSharpArgumentInfo.Create(CSharpArgumentInfoFlags.None, (string) null),
          CSharpArgumentInfo.Create(CSharpArgumentInfoFlags.UseCompileTimeType, (string) null)
        }));
      }
      // ISSUE: reference to a compiler-generated field
      // ISSUE: reference to a compiler-generated field
      object obj4 = DBConnectionController.\u003C\u003Eo__5.\u003C\u003Ep__3.Target((CallSite) DBConnectionController.\u003C\u003Eo__5.\u003C\u003Ep__3, this.ViewBag, jsonData.ToJson(true));
      return (ActionResult) this.View();
    }

    public ActionResult TableQuery()
    {
      return this.TableQuery((FormCollection) null);
    }

    [HttpPost]
    public ActionResult TableQuery(FormCollection collection)
    {
      RoadFlow.Platform.DBConnection dbConnection1 = new RoadFlow.Platform.DBConnection();
      string empty1 = string.Empty;
      string empty2 = string.Empty;
      string empty3 = string.Empty;
      string str1 = this.Request.QueryString["tablename"];
      string str2 = this.Request.QueryString["dbconnid"];
      RoadFlow.Data.Model.DBConnection dbConnection2 = dbConnection1.Get(str2.ToGuid(), true);
      if (dbConnection2 == null)
      {
        // ISSUE: reference to a compiler-generated field
        if (DBConnectionController.\u003C\u003Eo__7.\u003C\u003Ep__0 == null)
        {
          // ISSUE: reference to a compiler-generated field
          DBConnectionController.\u003C\u003Eo__7.\u003C\u003Ep__0 = CallSite<Func<CallSite, object, string, object>>.Create(Binder.SetMember(CSharpBinderFlags.None, "LiteralResult", typeof (DBConnectionController), (IEnumerable<CSharpArgumentInfo>) new CSharpArgumentInfo[2]
          {
            CSharpArgumentInfo.Create(CSharpArgumentInfoFlags.None, (string) null),
            CSharpArgumentInfo.Create(CSharpArgumentInfoFlags.UseCompileTimeType | CSharpArgumentInfoFlags.Constant, (string) null)
          }));
        }
        // ISSUE: reference to a compiler-generated field
        // ISSUE: reference to a compiler-generated field
        object obj1 = DBConnectionController.\u003C\u003Eo__7.\u003C\u003Ep__0.Target((CallSite) DBConnectionController.\u003C\u003Eo__7.\u003C\u003Ep__0, this.ViewBag, "未找到数据连接");
        // ISSUE: reference to a compiler-generated field
        if (DBConnectionController.\u003C\u003Eo__7.\u003C\u003Ep__2 == null)
        {
          // ISSUE: reference to a compiler-generated field
          DBConnectionController.\u003C\u003Eo__7.\u003C\u003Ep__2 = CallSite<Func<CallSite, object, string, object>>.Create(Binder.SetMember(CSharpBinderFlags.None, "Text", typeof (DBConnectionController), (IEnumerable<CSharpArgumentInfo>) new CSharpArgumentInfo[2]
          {
            CSharpArgumentInfo.Create(CSharpArgumentInfoFlags.None, (string) null),
            CSharpArgumentInfo.Create(CSharpArgumentInfoFlags.UseCompileTimeType | CSharpArgumentInfoFlags.Constant, (string) null)
          }));
        }
        // ISSUE: reference to a compiler-generated field
        Func<CallSite, object, string, object> target = DBConnectionController.\u003C\u003Eo__7.\u003C\u003Ep__2.Target;
        // ISSUE: reference to a compiler-generated field
        CallSite<Func<CallSite, object, string, object>> p2 = DBConnectionController.\u003C\u003Eo__7.\u003C\u003Ep__2;
        // ISSUE: reference to a compiler-generated field
        if (DBConnectionController.\u003C\u003Eo__7.\u003C\u003Ep__1 == null)
        {
          // ISSUE: reference to a compiler-generated field
          DBConnectionController.\u003C\u003Eo__7.\u003C\u003Ep__1 = CallSite<Func<CallSite, object, object>>.Create(Binder.GetMember(CSharpBinderFlags.None, "LiteralResultCount", typeof (DBConnectionController), (IEnumerable<CSharpArgumentInfo>) new CSharpArgumentInfo[1]
          {
            CSharpArgumentInfo.Create(CSharpArgumentInfoFlags.None, (string) null)
          }));
        }
        // ISSUE: reference to a compiler-generated field
        // ISSUE: reference to a compiler-generated field
        object obj2 = DBConnectionController.\u003C\u003Eo__7.\u003C\u003Ep__1.Target((CallSite) DBConnectionController.\u003C\u003Eo__7.\u003C\u003Ep__1, this.ViewBag);
        string str3 = "";
        object obj3 = target((CallSite) p2, obj2, str3);
        return (ActionResult) this.View();
      }
      string defaultQuerySql;
      if (collection != null)
        defaultQuerySql = this.Request.Form["sqltext"];
      else if (!str1.IsNullOrEmpty())
      {
        defaultQuerySql = dbConnection1.GetDefaultQuerySql(dbConnection2, str1);
      }
      else
      {
        // ISSUE: reference to a compiler-generated field
        if (DBConnectionController.\u003C\u003Eo__7.\u003C\u003Ep__3 == null)
        {
          // ISSUE: reference to a compiler-generated field
          DBConnectionController.\u003C\u003Eo__7.\u003C\u003Ep__3 = CallSite<Func<CallSite, object, string, object>>.Create(Binder.SetMember(CSharpBinderFlags.None, "LiteralResult", typeof (DBConnectionController), (IEnumerable<CSharpArgumentInfo>) new CSharpArgumentInfo[2]
          {
            CSharpArgumentInfo.Create(CSharpArgumentInfoFlags.None, (string) null),
            CSharpArgumentInfo.Create(CSharpArgumentInfoFlags.UseCompileTimeType | CSharpArgumentInfoFlags.Constant, (string) null)
          }));
        }
        // ISSUE: reference to a compiler-generated field
        // ISSUE: reference to a compiler-generated field
        object obj1 = DBConnectionController.\u003C\u003Eo__7.\u003C\u003Ep__3.Target((CallSite) DBConnectionController.\u003C\u003Eo__7.\u003C\u003Ep__3, this.ViewBag, "");
        // ISSUE: reference to a compiler-generated field
        if (DBConnectionController.\u003C\u003Eo__7.\u003C\u003Ep__4 == null)
        {
          // ISSUE: reference to a compiler-generated field
          DBConnectionController.\u003C\u003Eo__7.\u003C\u003Ep__4 = CallSite<Func<CallSite, object, string, object>>.Create(Binder.SetMember(CSharpBinderFlags.None, "LiteralResultCount", typeof (DBConnectionController), (IEnumerable<CSharpArgumentInfo>) new CSharpArgumentInfo[2]
          {
            CSharpArgumentInfo.Create(CSharpArgumentInfoFlags.None, (string) null),
            CSharpArgumentInfo.Create(CSharpArgumentInfoFlags.UseCompileTimeType | CSharpArgumentInfoFlags.Constant, (string) null)
          }));
        }
        // ISSUE: reference to a compiler-generated field
        // ISSUE: reference to a compiler-generated field
        object obj2 = DBConnectionController.\u003C\u003Eo__7.\u003C\u003Ep__4.Target((CallSite) DBConnectionController.\u003C\u003Eo__7.\u003C\u003Ep__4, this.ViewBag, "");
        return (ActionResult) this.View();
      }
      if (defaultQuerySql.IsNullOrEmpty())
      {
        // ISSUE: reference to a compiler-generated field
        if (DBConnectionController.\u003C\u003Eo__7.\u003C\u003Ep__5 == null)
        {
          // ISSUE: reference to a compiler-generated field
          DBConnectionController.\u003C\u003Eo__7.\u003C\u003Ep__5 = CallSite<Func<CallSite, object, string, object>>.Create(Binder.SetMember(CSharpBinderFlags.None, "LiteralResult", typeof (DBConnectionController), (IEnumerable<CSharpArgumentInfo>) new CSharpArgumentInfo[2]
          {
            CSharpArgumentInfo.Create(CSharpArgumentInfoFlags.None, (string) null),
            CSharpArgumentInfo.Create(CSharpArgumentInfoFlags.UseCompileTimeType | CSharpArgumentInfoFlags.Constant, (string) null)
          }));
        }
        // ISSUE: reference to a compiler-generated field
        // ISSUE: reference to a compiler-generated field
        object obj1 = DBConnectionController.\u003C\u003Eo__7.\u003C\u003Ep__5.Target((CallSite) DBConnectionController.\u003C\u003Eo__7.\u003C\u003Ep__5, this.ViewBag, "SQL为空！");
        // ISSUE: reference to a compiler-generated field
        if (DBConnectionController.\u003C\u003Eo__7.\u003C\u003Ep__6 == null)
        {
          // ISSUE: reference to a compiler-generated field
          DBConnectionController.\u003C\u003Eo__7.\u003C\u003Ep__6 = CallSite<Func<CallSite, object, string, object>>.Create(Binder.SetMember(CSharpBinderFlags.None, "LiteralResultCount", typeof (DBConnectionController), (IEnumerable<CSharpArgumentInfo>) new CSharpArgumentInfo[2]
          {
            CSharpArgumentInfo.Create(CSharpArgumentInfoFlags.None, (string) null),
            CSharpArgumentInfo.Create(CSharpArgumentInfoFlags.UseCompileTimeType | CSharpArgumentInfoFlags.Constant, (string) null)
          }));
        }
        // ISSUE: reference to a compiler-generated field
        // ISSUE: reference to a compiler-generated field
        object obj2 = DBConnectionController.\u003C\u003Eo__7.\u003C\u003Ep__6.Target((CallSite) DBConnectionController.\u003C\u003Eo__7.\u003C\u003Ep__6, this.ViewBag, "");
        return (ActionResult) this.View();
      }
      if (!dbConnection1.CheckSql(defaultQuerySql))
      {
        // ISSUE: reference to a compiler-generated field
        if (DBConnectionController.\u003C\u003Eo__7.\u003C\u003Ep__7 == null)
        {
          // ISSUE: reference to a compiler-generated field
          DBConnectionController.\u003C\u003Eo__7.\u003C\u003Ep__7 = CallSite<Func<CallSite, object, string, object>>.Create(Binder.SetMember(CSharpBinderFlags.None, "LiteralResult", typeof (DBConnectionController), (IEnumerable<CSharpArgumentInfo>) new CSharpArgumentInfo[2]
          {
            CSharpArgumentInfo.Create(CSharpArgumentInfoFlags.None, (string) null),
            CSharpArgumentInfo.Create(CSharpArgumentInfoFlags.UseCompileTimeType | CSharpArgumentInfoFlags.Constant, (string) null)
          }));
        }
        // ISSUE: reference to a compiler-generated field
        // ISSUE: reference to a compiler-generated field
        object obj1 = DBConnectionController.\u003C\u003Eo__7.\u003C\u003Ep__7.Target((CallSite) DBConnectionController.\u003C\u003Eo__7.\u003C\u003Ep__7, this.ViewBag, "SQL含有破坏系统表的语句，禁止执行！");
        // ISSUE: reference to a compiler-generated field
        if (DBConnectionController.\u003C\u003Eo__7.\u003C\u003Ep__8 == null)
        {
          // ISSUE: reference to a compiler-generated field
          DBConnectionController.\u003C\u003Eo__7.\u003C\u003Ep__8 = CallSite<Func<CallSite, object, string, object>>.Create(Binder.SetMember(CSharpBinderFlags.None, "LiteralResultCount", typeof (DBConnectionController), (IEnumerable<CSharpArgumentInfo>) new CSharpArgumentInfo[2]
          {
            CSharpArgumentInfo.Create(CSharpArgumentInfoFlags.None, (string) null),
            CSharpArgumentInfo.Create(CSharpArgumentInfoFlags.UseCompileTimeType | CSharpArgumentInfoFlags.Constant, (string) null)
          }));
        }
        // ISSUE: reference to a compiler-generated field
        // ISSUE: reference to a compiler-generated field
        object obj2 = DBConnectionController.\u003C\u003Eo__7.\u003C\u003Ep__8.Target((CallSite) DBConnectionController.\u003C\u003Eo__7.\u003C\u003Ep__8, this.ViewBag, "");
        RoadFlow.Platform.Log.Add("尝试执行有破坏系统表的SQL语句", defaultQuerySql, RoadFlow.Platform.Log.Types.数据连接, "", "", (RoadFlow.Data.Model.Users) null);
        return (ActionResult) this.View();
      }
      DataTable dataTable = dbConnection1.GetDataTable(dbConnection2, defaultQuerySql, (IDataParameter[]) null);
      RoadFlow.Platform.Log.Add("执行了SQL", defaultQuerySql, RoadFlow.Platform.Log.Types.数据连接, dataTable.ToJsonString(), "", (RoadFlow.Data.Model.Users) null);
      // ISSUE: reference to a compiler-generated field
      if (DBConnectionController.\u003C\u003Eo__7.\u003C\u003Ep__9 == null)
      {
        // ISSUE: reference to a compiler-generated field
        DBConnectionController.\u003C\u003Eo__7.\u003C\u003Ep__9 = CallSite<Func<CallSite, object, string, object>>.Create(Binder.SetMember(CSharpBinderFlags.None, "LiteralResult", typeof (DBConnectionController), (IEnumerable<CSharpArgumentInfo>) new CSharpArgumentInfo[2]
        {
          CSharpArgumentInfo.Create(CSharpArgumentInfoFlags.None, (string) null),
          CSharpArgumentInfo.Create(CSharpArgumentInfoFlags.UseCompileTimeType, (string) null)
        }));
      }
      // ISSUE: reference to a compiler-generated field
      // ISSUE: reference to a compiler-generated field
      object obj4 = DBConnectionController.\u003C\u003Eo__7.\u003C\u003Ep__9.Target((CallSite) DBConnectionController.\u003C\u003Eo__7.\u003C\u003Ep__9, this.ViewBag, Tools.DataTableToHtml(dataTable));
      // ISSUE: reference to a compiler-generated field
      if (DBConnectionController.\u003C\u003Eo__7.\u003C\u003Ep__10 == null)
      {
        // ISSUE: reference to a compiler-generated field
        DBConnectionController.\u003C\u003Eo__7.\u003C\u003Ep__10 = CallSite<Func<CallSite, object, string, object>>.Create(Binder.SetMember(CSharpBinderFlags.None, "LiteralResultCount", typeof (DBConnectionController), (IEnumerable<CSharpArgumentInfo>) new CSharpArgumentInfo[2]
        {
          CSharpArgumentInfo.Create(CSharpArgumentInfoFlags.None, (string) null),
          CSharpArgumentInfo.Create(CSharpArgumentInfoFlags.UseCompileTimeType, (string) null)
        }));
      }
      // ISSUE: reference to a compiler-generated field
      // ISSUE: reference to a compiler-generated field
      object obj5 = DBConnectionController.\u003C\u003Eo__7.\u003C\u003Ep__10.Target((CallSite) DBConnectionController.\u003C\u003Eo__7.\u003C\u003Ep__10, this.ViewBag, "(共" + (object) dataTable.Rows.Count + "行)");
      // ISSUE: reference to a compiler-generated field
      if (DBConnectionController.\u003C\u003Eo__7.\u003C\u003Ep__11 == null)
      {
        // ISSUE: reference to a compiler-generated field
        DBConnectionController.\u003C\u003Eo__7.\u003C\u003Ep__11 = CallSite<Func<CallSite, object, string, object>>.Create(Binder.SetMember(CSharpBinderFlags.None, "sqltext", typeof (DBConnectionController), (IEnumerable<CSharpArgumentInfo>) new CSharpArgumentInfo[2]
        {
          CSharpArgumentInfo.Create(CSharpArgumentInfoFlags.None, (string) null),
          CSharpArgumentInfo.Create(CSharpArgumentInfoFlags.UseCompileTimeType, (string) null)
        }));
      }
      // ISSUE: reference to a compiler-generated field
      // ISSUE: reference to a compiler-generated field
      object obj6 = DBConnectionController.\u003C\u003Eo__7.\u003C\u003Ep__11.Target((CallSite) DBConnectionController.\u003C\u003Eo__7.\u003C\u003Ep__11, this.ViewBag, defaultQuerySql);
      return (ActionResult) this.View();
    }

    public ActionResult TableDelete()
    {
      return (ActionResult) this.View();
    }

    public ActionResult TableEdit_SqlServer()
    {
      return this.TableEdit_SqlServer((FormCollection) null);
    }

    [HttpPost]
    [ValidateAntiForgeryToken]
    public ActionResult TableEdit_SqlServer(FormCollection collection)
    {
      string empty1 = string.Empty;
      string empty2 = string.Empty;
      RoadFlow.Platform.DBConnection dbConnection1 = new RoadFlow.Platform.DBConnection();
      DataTable dataTable = new DataTable();
      List<string> stringList = new List<string>();
      RoadFlow.Data.Model.DBConnection dbConnection2 = (RoadFlow.Data.Model.DBConnection) null;
      bool flag1 = false;
      List<string> systemDataTables = RoadFlow.Utility.Config.SystemDataTables;
      string str1 = this.Request.QueryString["dbconnid"];
      string str2 = this.Request.QueryString["tablename"];
      if (str2.IsNullOrEmpty())
      {
        str2 = "NEWTABLE_" + Tools.GetRandomString(5);
        flag1 = true;
      }
      if (str1.IsGuid() && !str2.IsNullOrEmpty())
      {
        dbConnection2 = dbConnection1.Get(str1.ToGuid(), true);
        if (dbConnection2 != null)
        {
          IDbConnection connection = dbConnection1.GetConnection(dbConnection2);
          if (connection != null)
          {
            if (connection.State != ConnectionState.Open)
              connection.Open();
            dataTable = dbConnection1.GetTableSchema(connection, str2, dbConnection2.Type);
            stringList = dbConnection1.GetPrimaryKey(dbConnection2, str2);
          }
        }
      }
      if (flag1)
        str2 = "";
      if (dataTable.Rows.Count == 0)
      {
        DataRow row = dataTable.NewRow();
        row["f_name"] = (object) "ID";
        row["t_name"] = (object) "int";
        row["is_null"] = (object) 0;
        row["isidentity"] = (object) 1;
        dataTable.Rows.Add(row);
        stringList.Add("ID");
      }
      // ISSUE: reference to a compiler-generated field
      if (DBConnectionController.\u003C\u003Eo__10.\u003C\u003Ep__0 == null)
      {
        // ISSUE: reference to a compiler-generated field
        DBConnectionController.\u003C\u003Eo__10.\u003C\u003Ep__0 = CallSite<Func<CallSite, object, List<string>, object>>.Create(Binder.SetMember(CSharpBinderFlags.None, "PrimaryKeyList", typeof (DBConnectionController), (IEnumerable<CSharpArgumentInfo>) new CSharpArgumentInfo[2]
        {
          CSharpArgumentInfo.Create(CSharpArgumentInfoFlags.None, (string) null),
          CSharpArgumentInfo.Create(CSharpArgumentInfoFlags.UseCompileTimeType, (string) null)
        }));
      }
      // ISSUE: reference to a compiler-generated field
      // ISSUE: reference to a compiler-generated field
      object obj1 = DBConnectionController.\u003C\u003Eo__10.\u003C\u003Ep__0.Target((CallSite) DBConnectionController.\u003C\u003Eo__10.\u003C\u003Ep__0, this.ViewBag, stringList);
      // ISSUE: reference to a compiler-generated field
      if (DBConnectionController.\u003C\u003Eo__10.\u003C\u003Ep__1 == null)
      {
        // ISSUE: reference to a compiler-generated field
        DBConnectionController.\u003C\u003Eo__10.\u003C\u003Ep__1 = CallSite<Func<CallSite, object, bool, object>>.Create(Binder.SetMember(CSharpBinderFlags.None, "IsAddTable", typeof (DBConnectionController), (IEnumerable<CSharpArgumentInfo>) new CSharpArgumentInfo[2]
        {
          CSharpArgumentInfo.Create(CSharpArgumentInfoFlags.None, (string) null),
          CSharpArgumentInfo.Create(CSharpArgumentInfoFlags.UseCompileTimeType, (string) null)
        }));
      }
      // ISSUE: reference to a compiler-generated field
      // ISSUE: reference to a compiler-generated field
      object obj2 = DBConnectionController.\u003C\u003Eo__10.\u003C\u003Ep__1.Target((CallSite) DBConnectionController.\u003C\u003Eo__10.\u003C\u003Ep__1, this.ViewBag, flag1);
      // ISSUE: reference to a compiler-generated field
      if (DBConnectionController.\u003C\u003Eo__10.\u003C\u003Ep__2 == null)
      {
        // ISSUE: reference to a compiler-generated field
        DBConnectionController.\u003C\u003Eo__10.\u003C\u003Ep__2 = CallSite<Func<CallSite, object, string, object>>.Create(Binder.SetMember(CSharpBinderFlags.None, "tableName", typeof (DBConnectionController), (IEnumerable<CSharpArgumentInfo>) new CSharpArgumentInfo[2]
        {
          CSharpArgumentInfo.Create(CSharpArgumentInfoFlags.None, (string) null),
          CSharpArgumentInfo.Create(CSharpArgumentInfoFlags.UseCompileTimeType, (string) null)
        }));
      }
      // ISSUE: reference to a compiler-generated field
      // ISSUE: reference to a compiler-generated field
      object obj3 = DBConnectionController.\u003C\u003Eo__10.\u003C\u003Ep__2.Target((CallSite) DBConnectionController.\u003C\u003Eo__10.\u003C\u003Ep__2, this.ViewBag, str2);
      if (collection == null)
        return (ActionResult) this.View((object) dataTable);
      if (dbConnection2 == null)
      {
        // ISSUE: reference to a compiler-generated field
        if (DBConnectionController.\u003C\u003Eo__10.\u003C\u003Ep__3 == null)
        {
          // ISSUE: reference to a compiler-generated field
          DBConnectionController.\u003C\u003Eo__10.\u003C\u003Ep__3 = CallSite<Func<CallSite, object, string, object>>.Create(Binder.SetMember(CSharpBinderFlags.None, "ClientScript", typeof (DBConnectionController), (IEnumerable<CSharpArgumentInfo>) new CSharpArgumentInfo[2]
          {
            CSharpArgumentInfo.Create(CSharpArgumentInfoFlags.None, (string) null),
            CSharpArgumentInfo.Create(CSharpArgumentInfoFlags.UseCompileTimeType | CSharpArgumentInfoFlags.Constant, (string) null)
          }));
        }
        // ISSUE: reference to a compiler-generated field
        // ISSUE: reference to a compiler-generated field
        object obj4 = DBConnectionController.\u003C\u003Eo__10.\u003C\u003Ep__3.Target((CallSite) DBConnectionController.\u003C\u003Eo__10.\u003C\u003Ep__3, this.ViewBag, "alert('未找到数据连接!');");
        return (ActionResult) this.View((object) dataTable);
      }
      string[] strArray = (this.Request.Form["f_name"] ?? "").Split(',');
      string str3 = this.Request.Form["tablename"];
      string oldtablename = this.Request.Form["oldtablename"];
      string str4 = this.Request.Form["delfield"] ?? "";
      StringBuilder stringBuilder1 = new StringBuilder();
      StringBuilder stringBuilder2 = new StringBuilder();
      if (systemDataTables.Find((Predicate<string>) (p => p.Equals(oldtablename, StringComparison.CurrentCultureIgnoreCase))) != null)
      {
        // ISSUE: reference to a compiler-generated field
        if (DBConnectionController.\u003C\u003Eo__10.\u003C\u003Ep__4 == null)
        {
          // ISSUE: reference to a compiler-generated field
          DBConnectionController.\u003C\u003Eo__10.\u003C\u003Ep__4 = CallSite<Func<CallSite, object, string, object>>.Create(Binder.SetMember(CSharpBinderFlags.None, "ClientScript", typeof (DBConnectionController), (IEnumerable<CSharpArgumentInfo>) new CSharpArgumentInfo[2]
          {
            CSharpArgumentInfo.Create(CSharpArgumentInfoFlags.None, (string) null),
            CSharpArgumentInfo.Create(CSharpArgumentInfoFlags.UseCompileTimeType | CSharpArgumentInfoFlags.Constant, (string) null)
          }));
        }
        // ISSUE: reference to a compiler-generated field
        // ISSUE: reference to a compiler-generated field
        object obj4 = DBConnectionController.\u003C\u003Eo__10.\u003C\u003Ep__4.Target((CallSite) DBConnectionController.\u003C\u003Eo__10.\u003C\u003Ep__4, this.ViewBag, "alert('您不能修改系统表!');");
        return (ActionResult) this.View((object) dataTable);
      }
      if (flag1)
      {
        stringBuilder1.Append("CREATE TABLE [" + str3 + "] (");
        oldtablename = str3;
      }
      else
      {
        foreach (string constraint in dbConnection1.GetConstraints(dbConnection2, oldtablename))
          stringBuilder1.Append("ALTER TABLE [" + oldtablename + "] DROP CONSTRAINT [" + constraint + "];");
        StringBuilder stringBuilder3 = new StringBuilder();
        string str5 = str4;
        char[] chArray = new char[1]{ ',' };
        foreach (string str6 in str5.Split(chArray))
        {
          if (!str6.IsNullOrEmpty() && dataTable.Select("f_name='" + str6 + "'").Length != 0)
            stringBuilder3.Append("[" + str6 + "],");
        }
        if (stringBuilder3.Length > 0)
          stringBuilder1.Append("ALTER TABLE [" + oldtablename + "] DROP COLUMN " + stringBuilder3.ToString().TrimEnd(',') + ";");
      }
      List<string> source = new List<string>();
      foreach (string str5 in strArray)
      {
        string str6 = this.Request.Form[str5 + "_name1"];
        string str7 = this.Request.Form[str5 + "_type"];
        string str8 = this.Request.Form[str5 + "_length"];
        string str9 = this.Request.Form[str5 + "_isnull"];
        string str10 = this.Request.Form[str5 + "_isidentity"];
        string str11 = this.Request.Form[str5 + "_primarykey"];
        string str12 = this.Request.Form[str5 + "_defaultvalue"];
        string str13 = this.Request.Form[str5 + "_isadd"];
        if (!str6.IsNullOrEmpty() && !str7.IsNullOrEmpty())
        {
          string str14 = string.Empty;
          switch (str7)
          {
            case "char":
              str14 = str7 + "(" + (str8.IsInt() ? str8 : "50") + ")";
              break;
            case "datetime":
            case "float":
            case "int":
            case "money":
            case "text":
            case "uniqueidentifier":
              str14 = str7;
              break;
            case "decimal":
              str14 = str7 + "(" + (str8.IsNullOrEmpty() ? "18,2" : str8) + ")";
              break;
            case "nvarchar":
            case "varchar":
              str14 = str7 + "(" + (str8.IsInt() ? (str8.ToInt() == -1 ? "MAX" : str8) : "50") + ")";
              break;
          }
          string str15 = "1" == str9 ? " NULL" : " NOT NULL";
          string str16 = "1" == str10 ? " IDENTITY(1,1)" : "";
          bool flag2 = "1" == str13;
          if ("1" == str11)
            source.Add(str6);
          if (flag1)
          {
            stringBuilder1.Append("[" + str6 + "] ");
            stringBuilder1.Append(str14);
            stringBuilder1.Append(" " + str15);
            stringBuilder1.Append(" " + str16);
            if (!str12.IsNullOrEmpty())
              stringBuilder1.Append(" DEFAULT " + str12);
            if (!str5.Equals(((IEnumerable<string>) strArray).Last<string>(), StringComparison.CurrentCultureIgnoreCase))
              stringBuilder1.Append(",");
          }
          else
          {
            if (!flag2 && str16.IsNullOrEmpty() && dataTable.Select("f_name='" + str5 + "' and isidentity=1").Length != 0)
            {
              stringBuilder1.Append("ALTER TABLE [" + oldtablename + "] DROP COLUMN [" + str5 + "];");
              stringBuilder1.Append("ALTER TABLE [" + oldtablename + "] ADD [" + str6 + "] " + str14 + str16 + str15 + ";");
            }
            else if (!str16.IsNullOrEmpty() && !flag2)
            {
              stringBuilder1.Append("ALTER TABLE [" + oldtablename + "] DROP COLUMN [" + str5 + "];ALTER TABLE [" + oldtablename + "] ADD [" + str6 + "] int NOT NULL IDENTITY(1,1);");
            }
            else
            {
              if (flag2)
                stringBuilder1.Append("ALTER TABLE [" + oldtablename + "] ADD [" + str6 + "] " + str14 + str16 + str15 + ";");
              else
                stringBuilder1.Append("ALTER TABLE [" + oldtablename + "] ALTER COLUMN [" + str5 + "] " + str14 + str16 + str15 + ";");
              if (!flag2 && !str5.Equals(str6, StringComparison.CurrentCultureIgnoreCase))
                stringBuilder1.Append("EXEC sp_rename N'[" + oldtablename + "].[" + str5 + "]', N'" + str6 + "', 'COLUMN';");
            }
            if (!str12.IsNullOrEmpty())
              stringBuilder1.Append("ALTER TABLE [" + oldtablename + "] ADD CONSTRAINT [DF_" + str3 + "_" + str5 + "] DEFAULT (" + str12 + ") FOR [" + str5 + "];");
          }
        }
      }
      if (flag1)
      {
        if (source.Count > 0)
        {
          stringBuilder1.Append(", PRIMARY KEY (");
          foreach (string str5 in source)
          {
            stringBuilder1.Append("[" + str5 + "]");
            if (!str5.Equals(source.Last<string>()))
              stringBuilder1.Append(",");
          }
          stringBuilder1.Append(")");
        }
        stringBuilder1.Append(")");
      }
      else
      {
        if (source.Count > 0)
        {
          stringBuilder2.Append("ALTER TABLE [" + str3 + "] ADD CONSTRAINT [PK_" + str3 + "] PRIMARY KEY (");
          foreach (string str5 in source)
          {
            stringBuilder2.Append("[" + str5 + "]");
            if (!str5.Equals(source.Last<string>()))
              stringBuilder2.Append(",");
          }
          stringBuilder2.Append(");");
        }
        if (!str3.Equals(oldtablename, StringComparison.CurrentCultureIgnoreCase))
          stringBuilder1.Append("EXEC sp_rename '" + oldtablename + "', '" + str3 + "';");
      }
      string str17 = stringBuilder1.ToString();
      string msg;
      bool flag3 = dbConnection1.TestSql(dbConnection2, str17, out msg, false);
      if (flag3 && stringBuilder2.Length > 0)
        flag3 = dbConnection1.TestSql(dbConnection2, stringBuilder2.ToString(), out msg, false);
      string str18 = "TableEdit_SqlServer?dbconnid=" + str1 + "&tablename=" + str3 + "&connid=" + str1 + "&appid=" + this.Request.QueryString["appid"] + "&tabid=" + this.Request.QueryString["tabid"] + "&s_Name=" + this.Request.QueryString["s_Name"];
      if (flag3)
      {
        RoadFlow.Platform.Log.Add("修改表结构成功-" + dbConnection2.Name + "-" + oldtablename, str17, RoadFlow.Platform.Log.Types.数据连接, "", "", (RoadFlow.Data.Model.Users) null);
        // ISSUE: reference to a compiler-generated field
        if (DBConnectionController.\u003C\u003Eo__10.\u003C\u003Ep__5 == null)
        {
          // ISSUE: reference to a compiler-generated field
          DBConnectionController.\u003C\u003Eo__10.\u003C\u003Ep__5 = CallSite<Func<CallSite, object, string, object>>.Create(Binder.SetMember(CSharpBinderFlags.None, "ClientScript", typeof (DBConnectionController), (IEnumerable<CSharpArgumentInfo>) new CSharpArgumentInfo[2]
          {
            CSharpArgumentInfo.Create(CSharpArgumentInfoFlags.None, (string) null),
            CSharpArgumentInfo.Create(CSharpArgumentInfoFlags.UseCompileTimeType, (string) null)
          }));
        }
        // ISSUE: reference to a compiler-generated field
        // ISSUE: reference to a compiler-generated field
        object obj4 = DBConnectionController.\u003C\u003Eo__10.\u003C\u003Ep__5.Target((CallSite) DBConnectionController.\u003C\u003Eo__10.\u003C\u003Ep__5, this.ViewBag, "alert('保存成功!');window.location='" + str18 + "';");
        return (ActionResult) this.View((object) dataTable);
      }
      RoadFlow.Platform.Log.Add("修改表结构失败-" + dbConnection2.Name + "-" + oldtablename, str17, RoadFlow.Platform.Log.Types.数据连接, "", "", (RoadFlow.Data.Model.Users) null);
      // ISSUE: reference to a compiler-generated field
      if (DBConnectionController.\u003C\u003Eo__10.\u003C\u003Ep__6 == null)
      {
        // ISSUE: reference to a compiler-generated field
        DBConnectionController.\u003C\u003Eo__10.\u003C\u003Ep__6 = CallSite<Func<CallSite, object, string, object>>.Create(Binder.SetMember(CSharpBinderFlags.None, "ClientScript", typeof (DBConnectionController), (IEnumerable<CSharpArgumentInfo>) new CSharpArgumentInfo[2]
        {
          CSharpArgumentInfo.Create(CSharpArgumentInfoFlags.None, (string) null),
          CSharpArgumentInfo.Create(CSharpArgumentInfoFlags.UseCompileTimeType, (string) null)
        }));
      }
      // ISSUE: reference to a compiler-generated field
      // ISSUE: reference to a compiler-generated field
      object obj5 = DBConnectionController.\u003C\u003Eo__10.\u003C\u003Ep__6.Target((CallSite) DBConnectionController.\u003C\u003Eo__10.\u003C\u003Ep__6, this.ViewBag, "alert('保存失败-" + msg.Replace("'", "") + "!');window.location='" + str18 + "';");
      return (ActionResult) this.View((object) dataTable);
    }

    public ActionResult TableEdit_Oracle()
    {
      return this.TableEdit_Oracle((FormCollection) null);
    }

    [HttpPost]
    [ValidateAntiForgeryToken]
    public ActionResult TableEdit_Oracle(FormCollection collection)
    {
      string empty1 = string.Empty;
      string empty2 = string.Empty;
      RoadFlow.Platform.DBConnection dbConnection1 = new RoadFlow.Platform.DBConnection();
      DataTable dataTable = new DataTable();
      List<string> stringList = new List<string>();
      RoadFlow.Data.Model.DBConnection dbConnection2 = (RoadFlow.Data.Model.DBConnection) null;
      bool flag1 = false;
      List<string> systemDataTables = RoadFlow.Utility.Config.SystemDataTables;
      string str1 = this.Request.QueryString["dbconnid"];
      string str2 = this.Request.QueryString["tablename"];
      if (str2.IsNullOrEmpty())
      {
        str2 = "NEWTABLE_" + Tools.GetRandomString(5);
        flag1 = true;
      }
      if (str1.IsGuid() && !str2.IsNullOrEmpty())
      {
        dbConnection2 = dbConnection1.Get(str1.ToGuid(), true);
        if (dbConnection2 != null)
        {
          IDbConnection connection = dbConnection1.GetConnection(dbConnection2);
          if (connection != null)
          {
            if (connection.State != ConnectionState.Open)
              connection.Open();
            dataTable = dbConnection1.GetTableSchema(connection, str2, dbConnection2.Type);
            stringList = dbConnection1.GetPrimaryKey(dbConnection2, str2);
          }
        }
      }
      if (flag1)
        str2 = "";
      if (dataTable.Rows.Count == 0)
      {
        DataRow row = dataTable.NewRow();
        row["f_name"] = (object) "ID";
        row["t_name"] = (object) "int";
        row["is_null"] = (object) 0;
        row["isidentity"] = (object) 1;
        dataTable.Rows.Add(row);
        stringList.Add("ID");
      }
      // ISSUE: reference to a compiler-generated field
      if (DBConnectionController.\u003C\u003Eo__12.\u003C\u003Ep__0 == null)
      {
        // ISSUE: reference to a compiler-generated field
        DBConnectionController.\u003C\u003Eo__12.\u003C\u003Ep__0 = CallSite<Func<CallSite, object, List<string>, object>>.Create(Binder.SetMember(CSharpBinderFlags.None, "PrimaryKeyList", typeof (DBConnectionController), (IEnumerable<CSharpArgumentInfo>) new CSharpArgumentInfo[2]
        {
          CSharpArgumentInfo.Create(CSharpArgumentInfoFlags.None, (string) null),
          CSharpArgumentInfo.Create(CSharpArgumentInfoFlags.UseCompileTimeType, (string) null)
        }));
      }
      // ISSUE: reference to a compiler-generated field
      // ISSUE: reference to a compiler-generated field
      object obj1 = DBConnectionController.\u003C\u003Eo__12.\u003C\u003Ep__0.Target((CallSite) DBConnectionController.\u003C\u003Eo__12.\u003C\u003Ep__0, this.ViewBag, stringList);
      // ISSUE: reference to a compiler-generated field
      if (DBConnectionController.\u003C\u003Eo__12.\u003C\u003Ep__1 == null)
      {
        // ISSUE: reference to a compiler-generated field
        DBConnectionController.\u003C\u003Eo__12.\u003C\u003Ep__1 = CallSite<Func<CallSite, object, bool, object>>.Create(Binder.SetMember(CSharpBinderFlags.None, "IsAddTable", typeof (DBConnectionController), (IEnumerable<CSharpArgumentInfo>) new CSharpArgumentInfo[2]
        {
          CSharpArgumentInfo.Create(CSharpArgumentInfoFlags.None, (string) null),
          CSharpArgumentInfo.Create(CSharpArgumentInfoFlags.UseCompileTimeType, (string) null)
        }));
      }
      // ISSUE: reference to a compiler-generated field
      // ISSUE: reference to a compiler-generated field
      object obj2 = DBConnectionController.\u003C\u003Eo__12.\u003C\u003Ep__1.Target((CallSite) DBConnectionController.\u003C\u003Eo__12.\u003C\u003Ep__1, this.ViewBag, flag1);
      // ISSUE: reference to a compiler-generated field
      if (DBConnectionController.\u003C\u003Eo__12.\u003C\u003Ep__2 == null)
      {
        // ISSUE: reference to a compiler-generated field
        DBConnectionController.\u003C\u003Eo__12.\u003C\u003Ep__2 = CallSite<Func<CallSite, object, string, object>>.Create(Binder.SetMember(CSharpBinderFlags.None, "tableName", typeof (DBConnectionController), (IEnumerable<CSharpArgumentInfo>) new CSharpArgumentInfo[2]
        {
          CSharpArgumentInfo.Create(CSharpArgumentInfoFlags.None, (string) null),
          CSharpArgumentInfo.Create(CSharpArgumentInfoFlags.UseCompileTimeType, (string) null)
        }));
      }
      // ISSUE: reference to a compiler-generated field
      // ISSUE: reference to a compiler-generated field
      object obj3 = DBConnectionController.\u003C\u003Eo__12.\u003C\u003Ep__2.Target((CallSite) DBConnectionController.\u003C\u003Eo__12.\u003C\u003Ep__2, this.ViewBag, str2);
      if (collection == null)
        return (ActionResult) this.View((object) dataTable);
      if (dbConnection2 == null)
      {
        // ISSUE: reference to a compiler-generated field
        if (DBConnectionController.\u003C\u003Eo__12.\u003C\u003Ep__3 == null)
        {
          // ISSUE: reference to a compiler-generated field
          DBConnectionController.\u003C\u003Eo__12.\u003C\u003Ep__3 = CallSite<Func<CallSite, object, string, object>>.Create(Binder.SetMember(CSharpBinderFlags.None, "ClientScript", typeof (DBConnectionController), (IEnumerable<CSharpArgumentInfo>) new CSharpArgumentInfo[2]
          {
            CSharpArgumentInfo.Create(CSharpArgumentInfoFlags.None, (string) null),
            CSharpArgumentInfo.Create(CSharpArgumentInfoFlags.UseCompileTimeType | CSharpArgumentInfoFlags.Constant, (string) null)
          }));
        }
        // ISSUE: reference to a compiler-generated field
        // ISSUE: reference to a compiler-generated field
        object obj4 = DBConnectionController.\u003C\u003Eo__12.\u003C\u003Ep__3.Target((CallSite) DBConnectionController.\u003C\u003Eo__12.\u003C\u003Ep__3, this.ViewBag, "alert('未找到数据连接!');");
        return (ActionResult) this.View((object) dataTable);
      }
      string[] strArray = (this.Request.Form["f_name"] ?? "").Split(',');
      string str3 = this.Request.Form["tablename"];
      string oldtablename = this.Request.Form["oldtablename"];
      string str4 = this.Request.Form["delfield"] ?? "";
      StringBuilder stringBuilder1 = new StringBuilder();
      List<string> strList = new List<string>();
      string str5 = "temp_" + Guid.NewGuid().ToString("N");
      if (systemDataTables.Find((Predicate<string>) (p => p.Equals(oldtablename, StringComparison.CurrentCultureIgnoreCase))) != null)
      {
        // ISSUE: reference to a compiler-generated field
        if (DBConnectionController.\u003C\u003Eo__12.\u003C\u003Ep__4 == null)
        {
          // ISSUE: reference to a compiler-generated field
          DBConnectionController.\u003C\u003Eo__12.\u003C\u003Ep__4 = CallSite<Func<CallSite, object, string, object>>.Create(Binder.SetMember(CSharpBinderFlags.None, "ClientScript", typeof (DBConnectionController), (IEnumerable<CSharpArgumentInfo>) new CSharpArgumentInfo[2]
          {
            CSharpArgumentInfo.Create(CSharpArgumentInfoFlags.None, (string) null),
            CSharpArgumentInfo.Create(CSharpArgumentInfoFlags.UseCompileTimeType | CSharpArgumentInfoFlags.Constant, (string) null)
          }));
        }
        // ISSUE: reference to a compiler-generated field
        // ISSUE: reference to a compiler-generated field
        object obj4 = DBConnectionController.\u003C\u003Eo__12.\u003C\u003Ep__4.Target((CallSite) DBConnectionController.\u003C\u003Eo__12.\u003C\u003Ep__4, this.ViewBag, "alert('您不能修改系统表!');");
        return (ActionResult) this.View((object) dataTable);
      }
      if (flag1)
      {
        strList.Add("CREATE TABLE \"" + str3 + "\" (\"" + str5 + "\" varchar2(50) NULL)");
        oldtablename = str3;
      }
      if (stringList.Count > 0)
        strList.Add("ALTER TABLE \"" + oldtablename + "\" DROP PRIMARY KEY");
      StringBuilder stringBuilder2 = new StringBuilder();
      string str6 = str4;
      char[] chArray = new char[1]{ ',' };
      foreach (string str7 in str6.Split(chArray))
      {
        if (!str7.IsNullOrEmpty())
          stringBuilder2.Append("\"" + str7 + "\",");
      }
      if (stringBuilder2.Length > 0)
        strList.Add("ALTER TABLE \"" + oldtablename + "\" DROP (" + stringBuilder2.ToString().TrimEnd(',') + ")");
      StringBuilder stringBuilder3 = new StringBuilder();
      foreach (string str7 in strArray)
      {
        string str8 = this.Request.Form[str7 + "_name1"];
        string str9 = this.Request.Form[str7 + "_type"];
        string str10 = this.Request.Form[str7 + "_length"];
        string str11 = this.Request.Form[str7 + "_isnull"];
        string str12 = this.Request.Form[str7 + "_isidentity"];
        string str13 = this.Request.Form[str7 + "_primarykey"];
        string str14 = this.Request.Form[str7 + "_defaultvalue"];
        string str15 = this.Request.Form[str7 + "_isadd"];
        if (!str8.IsNullOrEmpty() && !str9.IsNullOrEmpty())
        {
          string str16 = string.Empty;
          switch (str9.ToLower())
          {
            case "char":
              str16 = str9 + "(" + (str10.IsInt() ? str10 : "50") + ")";
              break;
            case "clog":
            case "date":
            case "float":
            case "int":
            case "nclog":
              str16 = str9;
              break;
            case "number":
              str16 = str9 + "(" + (str10.IsNullOrEmpty() ? "18,2" : str10) + ")";
              break;
            case "nvarchar2":
            case "varchar2":
              str16 = str9 + "(" + (str10.IsInt() ? (str10.ToInt() == -1 ? "50" : str10) : "50") + ")";
              break;
          }
          int num = dataTable.Select("F_Name='" + str7 + "'").Length != 0 ? dataTable.Select("F_Name='" + str7 + "'")[0]["IS_NULL"].ToString().ToInt() : -1;
          string str17 = "";
          if ("1" == str11)
          {
            if (num == 0)
              str17 = " NULL";
          }
          else if (num == 1)
            str17 = " NOT NULL";
          string str18 = "1" == str12 ? " " : "";
          string str19 = !str14.IsNullOrEmpty() ? " DEFAULT " + str14 : "";
          bool flag2 = "1" == str15;
          if (flag2)
            strList.Add("ALTER TABLE \"" + oldtablename + "\" ADD (\"" + str8 + "\" " + str16 + str18 + str19 + str17 + ")");
          else if (!str12.IsNullOrEmpty())
            strList.Add("ALTER TABLE \"" + oldtablename + "\" MODIFY (\"" + str8 + "\" " + str16 + str18 + str19 + str17 + ")");
          else
            strList.Add("ALTER TABLE \"" + oldtablename + "\" MODIFY (\"" + str7 + "\" " + str16 + str18 + str19 + str17 + ")");
          if ("1" == str13)
            stringBuilder3.Append("\"" + str8 + "\",");
          if (!flag2 && !str7.Equals(str8, StringComparison.CurrentCultureIgnoreCase))
            strList.Add("ALTER TABLE \"" + oldtablename + "\" RENAME COLUMN \"" + str7 + "\" TO \"" + str8 + "\"");
        }
      }
      if (stringBuilder3.Length > 0)
        strList.Add("ALTER TABLE \"" + oldtablename + "\" ADD CONSTRAINT \"" + str3 + "_PK\" PRIMARY KEY (" + stringBuilder3.ToString().TrimEnd(',') + ")");
      if (!str3.Equals(oldtablename, StringComparison.CurrentCultureIgnoreCase))
        strList.Add("ALTER TABLE \"" + oldtablename + "\" RENAME TO \"" + str3 + "\"");
      if (flag1)
        strList.Add("ALTER TABLE \"" + oldtablename + "\" DROP (\"" + str5 + "\")");
      string contents = strList.ToString(";");
      bool flag3 = true;
      foreach (string sql in strList)
      {
        if (!dbConnection1.TestSql(dbConnection2, sql, false) & flag3)
          flag3 = false;
      }
      string str20 = "TableEdit_Oracle?dbconnid=" + str1 + "&tablename=" + str3 + "&connid=" + str1 + "&appid=" + this.Request.QueryString["appid"] + "&tabid=" + this.Request.QueryString["tabid"] + "&s_Name=" + this.Request.QueryString["s_Name"];
      if (flag3)
      {
        RoadFlow.Platform.Log.Add("修改表结构成功-" + dbConnection2.Name + "-" + oldtablename, contents, RoadFlow.Platform.Log.Types.数据连接, "", "", (RoadFlow.Data.Model.Users) null);
        // ISSUE: reference to a compiler-generated field
        if (DBConnectionController.\u003C\u003Eo__12.\u003C\u003Ep__5 == null)
        {
          // ISSUE: reference to a compiler-generated field
          DBConnectionController.\u003C\u003Eo__12.\u003C\u003Ep__5 = CallSite<Func<CallSite, object, string, object>>.Create(Binder.SetMember(CSharpBinderFlags.None, "ClientScript", typeof (DBConnectionController), (IEnumerable<CSharpArgumentInfo>) new CSharpArgumentInfo[2]
          {
            CSharpArgumentInfo.Create(CSharpArgumentInfoFlags.None, (string) null),
            CSharpArgumentInfo.Create(CSharpArgumentInfoFlags.UseCompileTimeType, (string) null)
          }));
        }
        // ISSUE: reference to a compiler-generated field
        // ISSUE: reference to a compiler-generated field
        object obj4 = DBConnectionController.\u003C\u003Eo__12.\u003C\u003Ep__5.Target((CallSite) DBConnectionController.\u003C\u003Eo__12.\u003C\u003Ep__5, this.ViewBag, "alert('保存成功!');window.location='" + str20 + "';");
        return (ActionResult) this.View((object) dataTable);
      }
      RoadFlow.Platform.Log.Add("修改表结构失败-" + dbConnection2.Name + "-" + oldtablename, contents, RoadFlow.Platform.Log.Types.数据连接, "", "", (RoadFlow.Data.Model.Users) null);
      // ISSUE: reference to a compiler-generated field
      if (DBConnectionController.\u003C\u003Eo__12.\u003C\u003Ep__6 == null)
      {
        // ISSUE: reference to a compiler-generated field
        DBConnectionController.\u003C\u003Eo__12.\u003C\u003Ep__6 = CallSite<Func<CallSite, object, string, object>>.Create(Binder.SetMember(CSharpBinderFlags.None, "ClientScript", typeof (DBConnectionController), (IEnumerable<CSharpArgumentInfo>) new CSharpArgumentInfo[2]
        {
          CSharpArgumentInfo.Create(CSharpArgumentInfoFlags.None, (string) null),
          CSharpArgumentInfo.Create(CSharpArgumentInfoFlags.UseCompileTimeType, (string) null)
        }));
      }
      // ISSUE: reference to a compiler-generated field
      // ISSUE: reference to a compiler-generated field
      object obj5 = DBConnectionController.\u003C\u003Eo__12.\u003C\u003Ep__6.Target((CallSite) DBConnectionController.\u003C\u003Eo__12.\u003C\u003Ep__6, this.ViewBag, "alert('保存失败!');window.location='" + str20 + "';");
      return (ActionResult) this.View((object) dataTable);
    }

    public ActionResult TableEdit_MySql()
    {
      return this.TableEdit_MySql((FormCollection) null);
    }

    [HttpPost]
    [ValidateAntiForgeryToken]
    public ActionResult TableEdit_MySql(FormCollection collection)
    {
      string empty1 = string.Empty;
      string empty2 = string.Empty;
      RoadFlow.Platform.DBConnection dbConnection1 = new RoadFlow.Platform.DBConnection();
      DataTable dataTable = new DataTable();
      List<string> stringList = new List<string>();
      RoadFlow.Data.Model.DBConnection dbConnection2 = (RoadFlow.Data.Model.DBConnection) null;
      bool flag1 = false;
      List<string> systemDataTables = RoadFlow.Utility.Config.SystemDataTables;
      string str1 = this.Request.QueryString["dbconnid"];
      string str2 = this.Request.QueryString["tablename"];
      if (str2.IsNullOrEmpty())
      {
        str2 = "NEWTABLE_" + Tools.GetRandomString(5);
        flag1 = true;
      }
      if (str1.IsGuid() && !str2.IsNullOrEmpty())
      {
        dbConnection2 = dbConnection1.Get(str1.ToGuid(), true);
        if (dbConnection2 != null)
        {
          IDbConnection connection = dbConnection1.GetConnection(dbConnection2);
          if (connection != null)
          {
            if (connection.State != ConnectionState.Open)
              connection.Open();
            if (!flag1)
            {
              dataTable = dbConnection1.GetTableSchema(connection, str2, dbConnection2.Type);
              stringList = dbConnection1.GetPrimaryKey(dbConnection2, str2);
            }
            else
            {
              dataTable = dbConnection1.GetTableSchema(connection, "Log", dbConnection2.Type);
              dataTable.Rows.Clear();
            }
          }
        }
      }
      if (flag1)
        str2 = "";
      if (dataTable.Rows.Count == 0)
      {
        DataRow row = dataTable.NewRow();
        row["f_name"] = (object) "ID";
        row["t_name"] = (object) "int";
        row["is_null"] = (object) 0;
        row["isidentity"] = (object) 1;
        dataTable.Rows.Add(row);
        stringList.Add("ID");
      }
      // ISSUE: reference to a compiler-generated field
      if (DBConnectionController.\u003C\u003Eo__14.\u003C\u003Ep__0 == null)
      {
        // ISSUE: reference to a compiler-generated field
        DBConnectionController.\u003C\u003Eo__14.\u003C\u003Ep__0 = CallSite<Func<CallSite, object, List<string>, object>>.Create(Binder.SetMember(CSharpBinderFlags.None, "PrimaryKeyList", typeof (DBConnectionController), (IEnumerable<CSharpArgumentInfo>) new CSharpArgumentInfo[2]
        {
          CSharpArgumentInfo.Create(CSharpArgumentInfoFlags.None, (string) null),
          CSharpArgumentInfo.Create(CSharpArgumentInfoFlags.UseCompileTimeType, (string) null)
        }));
      }
      // ISSUE: reference to a compiler-generated field
      // ISSUE: reference to a compiler-generated field
      object obj1 = DBConnectionController.\u003C\u003Eo__14.\u003C\u003Ep__0.Target((CallSite) DBConnectionController.\u003C\u003Eo__14.\u003C\u003Ep__0, this.ViewBag, stringList);
      // ISSUE: reference to a compiler-generated field
      if (DBConnectionController.\u003C\u003Eo__14.\u003C\u003Ep__1 == null)
      {
        // ISSUE: reference to a compiler-generated field
        DBConnectionController.\u003C\u003Eo__14.\u003C\u003Ep__1 = CallSite<Func<CallSite, object, bool, object>>.Create(Binder.SetMember(CSharpBinderFlags.None, "IsAddTable", typeof (DBConnectionController), (IEnumerable<CSharpArgumentInfo>) new CSharpArgumentInfo[2]
        {
          CSharpArgumentInfo.Create(CSharpArgumentInfoFlags.None, (string) null),
          CSharpArgumentInfo.Create(CSharpArgumentInfoFlags.UseCompileTimeType, (string) null)
        }));
      }
      // ISSUE: reference to a compiler-generated field
      // ISSUE: reference to a compiler-generated field
      object obj2 = DBConnectionController.\u003C\u003Eo__14.\u003C\u003Ep__1.Target((CallSite) DBConnectionController.\u003C\u003Eo__14.\u003C\u003Ep__1, this.ViewBag, flag1);
      // ISSUE: reference to a compiler-generated field
      if (DBConnectionController.\u003C\u003Eo__14.\u003C\u003Ep__2 == null)
      {
        // ISSUE: reference to a compiler-generated field
        DBConnectionController.\u003C\u003Eo__14.\u003C\u003Ep__2 = CallSite<Func<CallSite, object, string, object>>.Create(Binder.SetMember(CSharpBinderFlags.None, "tableName", typeof (DBConnectionController), (IEnumerable<CSharpArgumentInfo>) new CSharpArgumentInfo[2]
        {
          CSharpArgumentInfo.Create(CSharpArgumentInfoFlags.None, (string) null),
          CSharpArgumentInfo.Create(CSharpArgumentInfoFlags.UseCompileTimeType, (string) null)
        }));
      }
      // ISSUE: reference to a compiler-generated field
      // ISSUE: reference to a compiler-generated field
      object obj3 = DBConnectionController.\u003C\u003Eo__14.\u003C\u003Ep__2.Target((CallSite) DBConnectionController.\u003C\u003Eo__14.\u003C\u003Ep__2, this.ViewBag, str2);
      if (collection == null)
        return (ActionResult) this.View((object) dataTable);
      if (dbConnection2 == null)
      {
        // ISSUE: reference to a compiler-generated field
        if (DBConnectionController.\u003C\u003Eo__14.\u003C\u003Ep__3 == null)
        {
          // ISSUE: reference to a compiler-generated field
          DBConnectionController.\u003C\u003Eo__14.\u003C\u003Ep__3 = CallSite<Func<CallSite, object, string, object>>.Create(Binder.SetMember(CSharpBinderFlags.None, "ClientScript", typeof (DBConnectionController), (IEnumerable<CSharpArgumentInfo>) new CSharpArgumentInfo[2]
          {
            CSharpArgumentInfo.Create(CSharpArgumentInfoFlags.None, (string) null),
            CSharpArgumentInfo.Create(CSharpArgumentInfoFlags.UseCompileTimeType | CSharpArgumentInfoFlags.Constant, (string) null)
          }));
        }
        // ISSUE: reference to a compiler-generated field
        // ISSUE: reference to a compiler-generated field
        object obj4 = DBConnectionController.\u003C\u003Eo__14.\u003C\u003Ep__3.Target((CallSite) DBConnectionController.\u003C\u003Eo__14.\u003C\u003Ep__3, this.ViewBag, "alert('未找到数据连接!');");
        return (ActionResult) this.View((object) dataTable);
      }
      string[] strArray = (this.Request.Form["f_name"] ?? "").Split(',');
      string str3 = this.Request.Form["tablename"];
      string oldtablename = this.Request.Form["oldtablename"];
      string str4 = this.Request.Form["delfield"] ?? "";
      StringBuilder stringBuilder = new StringBuilder();
      string str5 = "temp_" + Guid.NewGuid().ToString("N");
      if (systemDataTables.Find((Predicate<string>) (p => p.Equals(oldtablename, StringComparison.CurrentCultureIgnoreCase))) != null)
      {
        // ISSUE: reference to a compiler-generated field
        if (DBConnectionController.\u003C\u003Eo__14.\u003C\u003Ep__4 == null)
        {
          // ISSUE: reference to a compiler-generated field
          DBConnectionController.\u003C\u003Eo__14.\u003C\u003Ep__4 = CallSite<Func<CallSite, object, string, object>>.Create(Binder.SetMember(CSharpBinderFlags.None, "ClientScript", typeof (DBConnectionController), (IEnumerable<CSharpArgumentInfo>) new CSharpArgumentInfo[2]
          {
            CSharpArgumentInfo.Create(CSharpArgumentInfoFlags.None, (string) null),
            CSharpArgumentInfo.Create(CSharpArgumentInfoFlags.UseCompileTimeType | CSharpArgumentInfoFlags.Constant, (string) null)
          }));
        }
        // ISSUE: reference to a compiler-generated field
        // ISSUE: reference to a compiler-generated field
        object obj4 = DBConnectionController.\u003C\u003Eo__14.\u003C\u003Ep__4.Target((CallSite) DBConnectionController.\u003C\u003Eo__14.\u003C\u003Ep__4, this.ViewBag, "alert('您不能修改系统表!');");
        return (ActionResult) this.View((object) dataTable);
      }
      if (flag1)
      {
        stringBuilder.Append("CREATE TABLE `" + str3 + "` (`" + str5 + "` varchar(255) PRIMARY KEY NOT NULL);");
        oldtablename = str3;
      }
      stringBuilder.Append("ALTER TABLE `" + oldtablename + "` ");
      if (stringList.Count > 0)
        stringBuilder.Append("DROP PRIMARY KEY,");
      string str6 = str4;
      char[] chArray = new char[1]{ ',' };
      foreach (string str7 in str6.Split(chArray))
      {
        if (!str7.IsNullOrEmpty())
          stringBuilder.Append("DROP COLUMN `" + str7 + "`,");
      }
      foreach (string str7 in strArray)
      {
        string str8 = this.Request.Form[str7 + "_name1"];
        string str9 = this.Request.Form[str7 + "_type"];
        string str10 = this.Request.Form[str7 + "_length"];
        string str11 = this.Request.Form[str7 + "_isnull"];
        string str12 = this.Request.Form[str7 + "_isidentity"];
        string str13 = this.Request.Form[str7 + "_primarykey"];
        string str14 = this.Request.Form[str7 + "_defaultvalue"];
        string str15 = this.Request.Form[str7 + "_isadd"];
        if (!str8.IsNullOrEmpty() && !str9.IsNullOrEmpty())
        {
          string str16 = string.Empty;
          switch (str9)
          {
            case "char":
              str16 = str9 + "(" + (str10.IsInt() ? str10 : "255") + ")";
              break;
            case "datetime":
            case "float":
            case "int":
            case "longtext":
            case "text":
              str16 = str9;
              break;
            case "decimal":
              str16 = str9 + "(" + (str10.IsNullOrEmpty() ? "18,2" : str10) + ")";
              break;
            case "varchar":
              str16 = str9 + "(" + (str10.IsInt() ? (str10.ToInt() <= -1 ? "255" : str10) : "255") + ")";
              break;
          }
          string str17 = "1" == str11 ? " NULL" : " NOT NULL";
          string str18 = "1" == str12 ? " AUTO_INCREMENT" : "";
          string str19 = str14.IsNullOrEmpty() ? "" : " DEFAULT " + str14;
          bool flag2 = "1" == str15;
          if (flag2)
            stringBuilder.Append("ADD COLUMN `" + str8 + "` " + str16 + str18 + str17 + ",");
          else if (!str12.IsNullOrEmpty())
            stringBuilder.Append("MODIFY COLUMN `" + str8 + "` " + str16 + str18 + str17 + str19 + ",");
          else if (!flag2 && !str7.Equals(str8, StringComparison.CurrentCultureIgnoreCase))
            stringBuilder.Append("CHANGE COLUMN `" + str7 + "` `" + str8 + "` " + str16 + str18 + str17 + str19 + ",");
          else
            stringBuilder.Append("MODIFY COLUMN `" + str7 + "` " + str16 + str18 + str17 + str19 + ",");
          if ("1" == str13)
            stringBuilder.Append("ADD PRIMARY KEY (`" + str7 + "`),");
        }
      }
      if (!str3.Equals(oldtablename, StringComparison.CurrentCultureIgnoreCase))
        stringBuilder.Append("RENAME TABLE `" + oldtablename + "` TO `" + str3 + "`,");
      if (flag1)
        stringBuilder.Append("DROP COLUMN `" + str5 + "`,");
      string str20 = stringBuilder.ToString().TrimEnd(',') + ";";
      bool flag3 = dbConnection1.TestSql(dbConnection2, str20, false);
      string str21 = "TableEdit_MySql?dbconnid=" + str1 + "&tablename=" + str3 + "&connid=" + str1 + "&appid=" + this.Request.QueryString["appid"] + "&tabid=" + this.Request.QueryString["tabid"] + "&s_Name=" + this.Request.QueryString["s_Name"];
      if (flag3)
      {
        RoadFlow.Platform.Log.Add("修改表结构成功-" + dbConnection2.Name + "-" + oldtablename, str20, RoadFlow.Platform.Log.Types.数据连接, "", "", (RoadFlow.Data.Model.Users) null);
        // ISSUE: reference to a compiler-generated field
        if (DBConnectionController.\u003C\u003Eo__14.\u003C\u003Ep__5 == null)
        {
          // ISSUE: reference to a compiler-generated field
          DBConnectionController.\u003C\u003Eo__14.\u003C\u003Ep__5 = CallSite<Func<CallSite, object, string, object>>.Create(Binder.SetMember(CSharpBinderFlags.None, "ClientScript", typeof (DBConnectionController), (IEnumerable<CSharpArgumentInfo>) new CSharpArgumentInfo[2]
          {
            CSharpArgumentInfo.Create(CSharpArgumentInfoFlags.None, (string) null),
            CSharpArgumentInfo.Create(CSharpArgumentInfoFlags.UseCompileTimeType, (string) null)
          }));
        }
        // ISSUE: reference to a compiler-generated field
        // ISSUE: reference to a compiler-generated field
        object obj4 = DBConnectionController.\u003C\u003Eo__14.\u003C\u003Ep__5.Target((CallSite) DBConnectionController.\u003C\u003Eo__14.\u003C\u003Ep__5, this.ViewBag, "alert('保存成功!');window.location='" + str21 + "';");
        return (ActionResult) this.View((object) dataTable);
      }
      RoadFlow.Platform.Log.Add("修改表结构失败-" + dbConnection2.Name + "-" + oldtablename, str20, RoadFlow.Platform.Log.Types.数据连接, "", "", (RoadFlow.Data.Model.Users) null);
      // ISSUE: reference to a compiler-generated field
      if (DBConnectionController.\u003C\u003Eo__14.\u003C\u003Ep__6 == null)
      {
        // ISSUE: reference to a compiler-generated field
        DBConnectionController.\u003C\u003Eo__14.\u003C\u003Ep__6 = CallSite<Func<CallSite, object, string, object>>.Create(Binder.SetMember(CSharpBinderFlags.None, "ClientScript", typeof (DBConnectionController), (IEnumerable<CSharpArgumentInfo>) new CSharpArgumentInfo[2]
        {
          CSharpArgumentInfo.Create(CSharpArgumentInfoFlags.None, (string) null),
          CSharpArgumentInfo.Create(CSharpArgumentInfoFlags.UseCompileTimeType, (string) null)
        }));
      }
      // ISSUE: reference to a compiler-generated field
      // ISSUE: reference to a compiler-generated field
      object obj5 = DBConnectionController.\u003C\u003Eo__14.\u003C\u003Ep__6.Target((CallSite) DBConnectionController.\u003C\u003Eo__14.\u003C\u003Ep__6, this.ViewBag, "alert('保存失败!');window.location='" + str21 + "';");
      return (ActionResult) this.View((object) dataTable);
    }
  }
}
