// Decompiled with JetBrains decompiler
// Type: WebMvc.Controllers.AppLibraryController
// Assembly: WebMvc, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 43FD7615-6DC3-49FB-B263-7F7CC91AFA77
// Assembly location: C:\inetpub\wwwroot\RoadFlowMvc\bin\WebMvc.dll

using LitJson;
using Microsoft.CSharp.RuntimeBinder;
using RoadFlow.Utility;
using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using System.Text;
using System.Transactions;
using System.Web.Mvc;

namespace WebMvc.Controllers
{
  public class AppLibraryController : MyController
  {
    public ActionResult Index()
    {
      return (ActionResult) this.View();
    }

    public ActionResult Tree()
    {
      return (ActionResult) this.View();
    }

    public ActionResult List()
    {
      string str1 = this.Request.QueryString["appid"];
      string str2 = this.Request.QueryString["tabid"];
      string str3 = this.Request.QueryString["typeid"];
      string str4 = string.Format("&appid={0}&tabid={1}&typeid={2}", (object) this.Request.QueryString["appid"], (object) this.Request.QueryString["tabid"], (object) this.Request.QueryString["typeid"]);
      // ISSUE: reference to a compiler-generated field
      if (AppLibraryController.\u003C\u003Eo__2.\u003C\u003Ep__0 == null)
      {
        // ISSUE: reference to a compiler-generated field
        AppLibraryController.\u003C\u003Eo__2.\u003C\u003Ep__0 = CallSite<Func<CallSite, object, string, object>>.Create(Binder.SetMember(CSharpBinderFlags.None, "Query1", typeof (AppLibraryController), (IEnumerable<CSharpArgumentInfo>) new CSharpArgumentInfo[2]
        {
          CSharpArgumentInfo.Create(CSharpArgumentInfoFlags.None, (string) null),
          CSharpArgumentInfo.Create(CSharpArgumentInfoFlags.UseCompileTimeType, (string) null)
        }));
      }
      // ISSUE: reference to a compiler-generated field
      // ISSUE: reference to a compiler-generated field
      object obj1 = AppLibraryController.\u003C\u003Eo__2.\u003C\u003Ep__0.Target((CallSite) AppLibraryController.\u003C\u003Eo__2.\u003C\u003Ep__0, this.ViewBag, str4);
      // ISSUE: reference to a compiler-generated field
      if (AppLibraryController.\u003C\u003Eo__2.\u003C\u003Ep__1 == null)
      {
        // ISSUE: reference to a compiler-generated field
        AppLibraryController.\u003C\u003Eo__2.\u003C\u003Ep__1 = CallSite<Func<CallSite, object, string, object>>.Create(Binder.SetMember(CSharpBinderFlags.None, "TypeID", typeof (AppLibraryController), (IEnumerable<CSharpArgumentInfo>) new CSharpArgumentInfo[2]
        {
          CSharpArgumentInfo.Create(CSharpArgumentInfoFlags.None, (string) null),
          CSharpArgumentInfo.Create(CSharpArgumentInfoFlags.UseCompileTimeType, (string) null)
        }));
      }
      // ISSUE: reference to a compiler-generated field
      // ISSUE: reference to a compiler-generated field
      object obj2 = AppLibraryController.\u003C\u003Eo__2.\u003C\u003Ep__1.Target((CallSite) AppLibraryController.\u003C\u003Eo__2.\u003C\u003Ep__1, this.ViewBag, str3);
      // ISSUE: reference to a compiler-generated field
      if (AppLibraryController.\u003C\u003Eo__2.\u003C\u003Ep__2 == null)
      {
        // ISSUE: reference to a compiler-generated field
        AppLibraryController.\u003C\u003Eo__2.\u003C\u003Ep__2 = CallSite<Func<CallSite, object, string, object>>.Create(Binder.SetMember(CSharpBinderFlags.None, "AppID", typeof (AppLibraryController), (IEnumerable<CSharpArgumentInfo>) new CSharpArgumentInfo[2]
        {
          CSharpArgumentInfo.Create(CSharpArgumentInfoFlags.None, (string) null),
          CSharpArgumentInfo.Create(CSharpArgumentInfoFlags.UseCompileTimeType, (string) null)
        }));
      }
      // ISSUE: reference to a compiler-generated field
      // ISSUE: reference to a compiler-generated field
      object obj3 = AppLibraryController.\u003C\u003Eo__2.\u003C\u003Ep__2.Target((CallSite) AppLibraryController.\u003C\u003Eo__2.\u003C\u003Ep__2, this.ViewBag, str1);
      // ISSUE: reference to a compiler-generated field
      if (AppLibraryController.\u003C\u003Eo__2.\u003C\u003Ep__3 == null)
      {
        // ISSUE: reference to a compiler-generated field
        AppLibraryController.\u003C\u003Eo__2.\u003C\u003Ep__3 = CallSite<Func<CallSite, object, string, object>>.Create(Binder.SetMember(CSharpBinderFlags.None, "TabID", typeof (AppLibraryController), (IEnumerable<CSharpArgumentInfo>) new CSharpArgumentInfo[2]
        {
          CSharpArgumentInfo.Create(CSharpArgumentInfoFlags.None, (string) null),
          CSharpArgumentInfo.Create(CSharpArgumentInfoFlags.UseCompileTimeType, (string) null)
        }));
      }
      // ISSUE: reference to a compiler-generated field
      // ISSUE: reference to a compiler-generated field
      object obj4 = AppLibraryController.\u003C\u003Eo__2.\u003C\u003Ep__3.Target((CallSite) AppLibraryController.\u003C\u003Eo__2.\u003C\u003Ep__3, this.ViewBag, str2);
      return (ActionResult) this.View();
    }

    [HttpPost]
    [ValidateAntiForgeryToken]
    public string Delete()
    {
      RoadFlow.Platform.AppLibrary appLibrary1 = new RoadFlow.Platform.AppLibrary();
      string str1 = this.Request.Form["ids"];
      StringBuilder stringBuilder = new StringBuilder();
      using (TransactionScope transactionScope = new TransactionScope())
      {
        string str2 = str1;
        char[] chArray = new char[1]{ ',' };
        foreach (string str3 in str2.Split(chArray))
        {
          Guid test;
          if (str3.IsGuid(out test))
          {
            RoadFlow.Data.Model.AppLibrary appLibrary2 = appLibrary1.Get(test, false);
            if (appLibrary2 != null)
            {
              stringBuilder.Append(appLibrary2.Serialize());
              appLibrary1.Delete(test);
              new RoadFlow.Platform.AppLibraryButtons1().DeleteByAppID(test);
              new RoadFlow.Platform.AppLibrarySubPages().DeleteByAppID(test);
            }
          }
        }
        new RoadFlow.Platform.Menu().ClearAllDataTableCache();
        new RoadFlow.Platform.AppLibraryButtons1().ClearCache();
        new RoadFlow.Platform.AppLibrarySubPages().ClearCache();
        RoadFlow.Platform.Log.Add("删除了一批应用程序库", stringBuilder.ToString(), RoadFlow.Platform.Log.Types.菜单权限, "", "", (RoadFlow.Data.Model.Users) null);
        transactionScope.Complete();
      }
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
      string str2 = this.Request.QueryString["typeid"];
      RoadFlow.Platform.AppLibrary appLibrary = new RoadFlow.Platform.AppLibrary();
      RoadFlow.Data.Model.AppLibrary model1 = (RoadFlow.Data.Model.AppLibrary) null;
      if (str1.IsGuid())
        model1 = appLibrary.Get(str1.ToGuid(), false);
      bool flag1 = !str1.IsGuid();
      string oldXML = string.Empty;
      int index1;
      if (model1 == null)
      {
        model1 = new RoadFlow.Data.Model.AppLibrary();
        model1.ID = Guid.NewGuid();
        // ISSUE: reference to a compiler-generated field
        if (AppLibraryController.\u003C\u003Eo__5.\u003C\u003Ep__0 == null)
        {
          // ISSUE: reference to a compiler-generated field
          AppLibraryController.\u003C\u003Eo__5.\u003C\u003Ep__0 = CallSite<Func<CallSite, object, string, object>>.Create(Binder.SetMember(CSharpBinderFlags.None, "TypeOptions", typeof (AppLibraryController), (IEnumerable<CSharpArgumentInfo>) new CSharpArgumentInfo[2]
          {
            CSharpArgumentInfo.Create(CSharpArgumentInfoFlags.None, (string) null),
            CSharpArgumentInfo.Create(CSharpArgumentInfoFlags.UseCompileTimeType, (string) null)
          }));
        }
        // ISSUE: reference to a compiler-generated field
        // ISSUE: reference to a compiler-generated field
        object obj1 = AppLibraryController.\u003C\u003Eo__5.\u003C\u003Ep__0.Target((CallSite) AppLibraryController.\u003C\u003Eo__5.\u003C\u003Ep__0, this.ViewBag, new RoadFlow.Platform.AppLibrary().GetTypeOptions(str2));
        // ISSUE: reference to a compiler-generated field
        if (AppLibraryController.\u003C\u003Eo__5.\u003C\u003Ep__1 == null)
        {
          // ISSUE: reference to a compiler-generated field
          AppLibraryController.\u003C\u003Eo__5.\u003C\u003Ep__1 = CallSite<Func<CallSite, object, string, object>>.Create(Binder.SetMember(CSharpBinderFlags.None, "OpenOptions", typeof (AppLibraryController), (IEnumerable<CSharpArgumentInfo>) new CSharpArgumentInfo[2]
          {
            CSharpArgumentInfo.Create(CSharpArgumentInfoFlags.None, (string) null),
            CSharpArgumentInfo.Create(CSharpArgumentInfoFlags.UseCompileTimeType, (string) null)
          }));
        }
        // ISSUE: reference to a compiler-generated field
        // ISSUE: reference to a compiler-generated field
        object obj2 = AppLibraryController.\u003C\u003Eo__5.\u003C\u003Ep__1.Target((CallSite) AppLibraryController.\u003C\u003Eo__5.\u003C\u003Ep__1, this.ViewBag, new RoadFlow.Platform.Dictionary().GetOptionsByCode("appopenmodel", RoadFlow.Platform.Dictionary.OptionValueField.Value, "", "", true));
      }
      else
      {
        oldXML = model1.Serialize();
        // ISSUE: reference to a compiler-generated field
        if (AppLibraryController.\u003C\u003Eo__5.\u003C\u003Ep__2 == null)
        {
          // ISSUE: reference to a compiler-generated field
          AppLibraryController.\u003C\u003Eo__5.\u003C\u003Ep__2 = CallSite<Func<CallSite, object, string, object>>.Create(Binder.SetMember(CSharpBinderFlags.None, "TypeOptions", typeof (AppLibraryController), (IEnumerable<CSharpArgumentInfo>) new CSharpArgumentInfo[2]
          {
            CSharpArgumentInfo.Create(CSharpArgumentInfoFlags.None, (string) null),
            CSharpArgumentInfo.Create(CSharpArgumentInfoFlags.UseCompileTimeType, (string) null)
          }));
        }
        // ISSUE: reference to a compiler-generated field
        // ISSUE: reference to a compiler-generated field
        object obj1 = AppLibraryController.\u003C\u003Eo__5.\u003C\u003Ep__2.Target((CallSite) AppLibraryController.\u003C\u003Eo__5.\u003C\u003Ep__2, this.ViewBag, new RoadFlow.Platform.AppLibrary().GetTypeOptions(model1.Type.ToString()));
        // ISSUE: reference to a compiler-generated field
        if (AppLibraryController.\u003C\u003Eo__5.\u003C\u003Ep__3 == null)
        {
          // ISSUE: reference to a compiler-generated field
          AppLibraryController.\u003C\u003Eo__5.\u003C\u003Ep__3 = CallSite<Func<CallSite, object, string, object>>.Create(Binder.SetMember(CSharpBinderFlags.None, "OpenOptions", typeof (AppLibraryController), (IEnumerable<CSharpArgumentInfo>) new CSharpArgumentInfo[2]
          {
            CSharpArgumentInfo.Create(CSharpArgumentInfoFlags.None, (string) null),
            CSharpArgumentInfo.Create(CSharpArgumentInfoFlags.UseCompileTimeType, (string) null)
          }));
        }
        // ISSUE: reference to a compiler-generated field
        Func<CallSite, object, string, object> target = AppLibraryController.\u003C\u003Eo__5.\u003C\u003Ep__3.Target;
        // ISSUE: reference to a compiler-generated field
        CallSite<Func<CallSite, object, string, object>> p3 = AppLibraryController.\u003C\u003Eo__5.\u003C\u003Ep__3;
        object viewBag = this.ViewBag;
        RoadFlow.Platform.Dictionary dictionary = new RoadFlow.Platform.Dictionary();
        string code = "appopenmodel";
        int num1 = 3;
        index1 = model1.OpenMode;
        string str3 = index1.ToString();
        string attr = "";
        int num2 = 1;
        string optionsByCode = dictionary.GetOptionsByCode(code, (RoadFlow.Platform.Dictionary.OptionValueField) num1, str3, attr, num2 != 0);
        object obj2 = target((CallSite) p3, viewBag, optionsByCode);
      }
      if (collection != null)
      {
        string str3 = collection["title"];
        string str4 = collection["address"];
        string str5 = collection["openModel"];
        string str6 = collection["width"];
        string str7 = collection["height"];
        string str8 = collection["Params"];
        string str9 = collection["Note"];
        string str10 = collection["Ico"];
        string str11 = collection["IcoColor"];
        string str12 = collection["type"];
        model1.Address = str4.Trim();
        model1.Height = str7.ToIntOrNull();
        model1.Note = str9;
        model1.OpenMode = str5.ToInt();
        model1.Params = str8;
        model1.Title = str3;
        model1.Type = str12.ToGuid();
        model1.Width = str6.ToIntOrNull();
        model1.Ico = str10.IsNullOrEmpty() ? (string) null : str10;
        model1.Color = str11.IsNullOrEmpty() ? (string) null : str11.Trim();
        string str13 = this.Request.QueryString["pagesize"];
        string str14 = this.Request.QueryString["pagenumber"];
        using (TransactionScope transactionScope = new TransactionScope())
        {
          if (flag1)
          {
            appLibrary.Add(model1);
            RoadFlow.Platform.Log.Add("添加了应用程序库", model1.Serialize(), RoadFlow.Platform.Log.Types.菜单权限, "", "", (RoadFlow.Data.Model.Users) null);
            // ISSUE: reference to a compiler-generated field
            if (AppLibraryController.\u003C\u003Eo__5.\u003C\u003Ep__4 == null)
            {
              // ISSUE: reference to a compiler-generated field
              AppLibraryController.\u003C\u003Eo__5.\u003C\u003Ep__4 = CallSite<Func<CallSite, object, string, object>>.Create(Binder.SetMember(CSharpBinderFlags.None, "Script", typeof (AppLibraryController), (IEnumerable<CSharpArgumentInfo>) new CSharpArgumentInfo[2]
              {
                CSharpArgumentInfo.Create(CSharpArgumentInfoFlags.None, (string) null),
                CSharpArgumentInfo.Create(CSharpArgumentInfoFlags.UseCompileTimeType, (string) null)
              }));
            }
            // ISSUE: reference to a compiler-generated field
            // ISSUE: reference to a compiler-generated field
            object obj = AppLibraryController.\u003C\u003Eo__5.\u003C\u003Ep__4.Target((CallSite) AppLibraryController.\u003C\u003Eo__5.\u003C\u003Ep__4, this.ViewBag, "alert('添加成功!');new RoadUI.Window().reloadOpener(undefined,undefined,\"query('" + str13 + "','" + str14 + "')\");new RoadUI.Window().close();");
          }
          else
          {
            appLibrary.Update(model1);
            RoadFlow.Platform.Log.Add("修改了应用程序库", "", RoadFlow.Platform.Log.Types.菜单权限, oldXML, model1.Serialize(), (RoadFlow.Data.Model.Users) null);
            // ISSUE: reference to a compiler-generated field
            if (AppLibraryController.\u003C\u003Eo__5.\u003C\u003Ep__5 == null)
            {
              // ISSUE: reference to a compiler-generated field
              AppLibraryController.\u003C\u003Eo__5.\u003C\u003Ep__5 = CallSite<Func<CallSite, object, string, object>>.Create(Binder.SetMember(CSharpBinderFlags.None, "Script", typeof (AppLibraryController), (IEnumerable<CSharpArgumentInfo>) new CSharpArgumentInfo[2]
              {
                CSharpArgumentInfo.Create(CSharpArgumentInfoFlags.None, (string) null),
                CSharpArgumentInfo.Create(CSharpArgumentInfoFlags.UseCompileTimeType, (string) null)
              }));
            }
            // ISSUE: reference to a compiler-generated field
            // ISSUE: reference to a compiler-generated field
            object obj = AppLibraryController.\u003C\u003Eo__5.\u003C\u003Ep__5.Target((CallSite) AppLibraryController.\u003C\u003Eo__5.\u003C\u003Ep__5, this.ViewBag, "alert('修改成功!');new RoadUI.Window().reloadOpener(undefined,undefined,\"query('" + str13 + "','" + str14 + "')\");new RoadUI.Window().close();");
          }
          RoadFlow.Platform.AppLibraryButtons1 appLibraryButtons1_1 = new RoadFlow.Platform.AppLibraryButtons1();
          string str15 = this.Request.Form["buttonindex"] ?? "";
          List<RoadFlow.Data.Model.AppLibraryButtons1> allByAppId = appLibraryButtons1_1.GetAllByAppID(model1.ID);
          List<RoadFlow.Data.Model.AppLibraryButtons1> appLibraryButtons1List = new List<RoadFlow.Data.Model.AppLibraryButtons1>();
          char[] chArray = new char[1]{ ',' };
          string[] strArray = str15.Split(chArray);
          for (index1 = 0; index1 < strArray.Length; ++index1)
          {
            string index = strArray[index1];
            string str16 = this.Request.Form["button_" + index];
            string str17 = this.Request.Form["buttonname_" + index];
            string str18 = this.Request.Form["buttonevents_" + index];
            string str19 = this.Request.Form["buttonico_" + index];
            string str20 = this.Request.Form["showtype_" + index];
            string str21 = this.Request.Form["buttonsort_" + index];
            if (!str17.IsNullOrEmpty() && !str18.IsNullOrEmpty())
            {
              RoadFlow.Data.Model.AppLibraryButtons1 model2 = allByAppId.Find((Predicate<RoadFlow.Data.Model.AppLibraryButtons1>) (p => p.ID == index.ToGuid()));
              bool flag2 = false;
              if (model2 == null)
              {
                flag2 = true;
                model2 = new RoadFlow.Data.Model.AppLibraryButtons1();
                model2.ID = Guid.NewGuid();
              }
              else
                appLibraryButtons1List.Add(model2);
              model2.AppLibraryID = model1.ID;
              if (str16.IsGuid())
                model2.ButtonID = new Guid?(str16.ToGuid());
              model2.Events = str18;
              model2.Ico = str19;
              model2.Name = str17.Trim1();
              model2.Sort = str21.ToInt(0);
              model2.ShowType = str20.ToInt(0);
              model2.Type = 0;
              if (flag2)
                appLibraryButtons1_1.Add(model2);
              else
                appLibraryButtons1_1.Update(model2);
            }
          }
          foreach (RoadFlow.Data.Model.AppLibraryButtons1 appLibraryButtons1_2 in allByAppId)
          {
            RoadFlow.Data.Model.AppLibraryButtons1 sub = appLibraryButtons1_2;
            if (appLibraryButtons1List.Find((Predicate<RoadFlow.Data.Model.AppLibraryButtons1>) (p => p.ID == sub.ID)) == null)
              appLibraryButtons1_1.Delete(sub.ID);
          }
          transactionScope.Complete();
          appLibraryButtons1_1.ClearCache();
        }
        new RoadFlow.Platform.Menu().ClearAllDataTableCache();
        new RoadFlow.Platform.WorkFlow().ClearStartFlowsCache();
        appLibrary.ClearCache();
      }
      return (ActionResult) this.View((object) model1);
    }

    public ActionResult SubPages()
    {
      return (ActionResult) this.View();
    }

    public ActionResult SubPageEdit()
    {
      return this.SubPageEdit((FormCollection) null);
    }

    [HttpPost]
    [ValidateAntiForgeryToken]
    public ActionResult SubPageEdit(FormCollection collection)
    {
      RoadFlow.Platform.AppLibrarySubPages appLibrarySubPages = new RoadFlow.Platform.AppLibrarySubPages();
      RoadFlow.Data.Model.AppLibrarySubPages model1 = (RoadFlow.Data.Model.AppLibrarySubPages) null;
      string str1 = this.Request.QueryString["subid"];
      if (str1.IsGuid())
        model1 = appLibrarySubPages.Get(str1.ToGuid());
      if (collection != null)
      {
        string str2 = this.Request.Form["Title"];
        string str3 = this.Request.Form["Address"];
        bool flag1 = false;
        if (model1 == null)
        {
          model1 = new RoadFlow.Data.Model.AppLibrarySubPages();
          flag1 = true;
          model1.ID = Guid.NewGuid();
          model1.AppLibraryID = this.Request.QueryString["id"].ToGuid();
        }
        model1.Name = str2.Trim1();
        model1.Address = str3.Trim1();
        using (TransactionScope transactionScope = new TransactionScope())
        {
          if (flag1)
          {
            appLibrarySubPages.Add(model1);
            RoadFlow.Platform.Log.Add("添加了子页面", model1.Serialize(), RoadFlow.Platform.Log.Types.菜单权限, "", "", (RoadFlow.Data.Model.Users) null);
            // ISSUE: reference to a compiler-generated field
            if (AppLibraryController.\u003C\u003Eo__8.\u003C\u003Ep__0 == null)
            {
              // ISSUE: reference to a compiler-generated field
              AppLibraryController.\u003C\u003Eo__8.\u003C\u003Ep__0 = CallSite<Func<CallSite, object, string, object>>.Create(Binder.SetMember(CSharpBinderFlags.None, "Script", typeof (AppLibraryController), (IEnumerable<CSharpArgumentInfo>) new CSharpArgumentInfo[2]
              {
                CSharpArgumentInfo.Create(CSharpArgumentInfoFlags.None, (string) null),
                CSharpArgumentInfo.Create(CSharpArgumentInfoFlags.UseCompileTimeType, (string) null)
              }));
            }
            // ISSUE: reference to a compiler-generated field
            // ISSUE: reference to a compiler-generated field
            object obj = AppLibraryController.\u003C\u003Eo__8.\u003C\u003Ep__0.Target((CallSite) AppLibraryController.\u003C\u003Eo__8.\u003C\u003Ep__0, this.ViewBag, "alert('添加成功!');window.location='SubPages" + this.Request.Url.Query + "';");
          }
          else
          {
            appLibrarySubPages.Update(model1);
            RoadFlow.Platform.Log.Add("修改了子页面", model1.Serialize(), RoadFlow.Platform.Log.Types.菜单权限, "", "", (RoadFlow.Data.Model.Users) null);
            // ISSUE: reference to a compiler-generated field
            if (AppLibraryController.\u003C\u003Eo__8.\u003C\u003Ep__1 == null)
            {
              // ISSUE: reference to a compiler-generated field
              AppLibraryController.\u003C\u003Eo__8.\u003C\u003Ep__1 = CallSite<Func<CallSite, object, string, object>>.Create(Binder.SetMember(CSharpBinderFlags.None, "Script", typeof (AppLibraryController), (IEnumerable<CSharpArgumentInfo>) new CSharpArgumentInfo[2]
              {
                CSharpArgumentInfo.Create(CSharpArgumentInfoFlags.None, (string) null),
                CSharpArgumentInfo.Create(CSharpArgumentInfoFlags.UseCompileTimeType, (string) null)
              }));
            }
            // ISSUE: reference to a compiler-generated field
            // ISSUE: reference to a compiler-generated field
            object obj = AppLibraryController.\u003C\u003Eo__8.\u003C\u003Ep__1.Target((CallSite) AppLibraryController.\u003C\u003Eo__8.\u003C\u003Ep__1, this.ViewBag, "alert('保存成功!');window.location='SubPages" + this.Request.Url.Query + "';");
          }
          RoadFlow.Platform.AppLibraryButtons1 appLibraryButtons1_1 = new RoadFlow.Platform.AppLibraryButtons1();
          string str4 = this.Request.Form["buttonindex"] ?? "";
          List<RoadFlow.Data.Model.AppLibraryButtons1> allByAppId = appLibraryButtons1_1.GetAllByAppID(model1.ID);
          List<RoadFlow.Data.Model.AppLibraryButtons1> appLibraryButtons1List = new List<RoadFlow.Data.Model.AppLibraryButtons1>();
          char[] chArray = new char[1]{ ',' };
          foreach (string str5 in str4.Split(chArray))
          {
            string index = str5;
            string str6 = this.Request.Form["button_" + index];
            string str7 = this.Request.Form["buttonname_" + index];
            string str8 = this.Request.Form["buttonevents_" + index];
            string str9 = this.Request.Form["buttonico_" + index];
            string str10 = this.Request.Form["showtype_" + index];
            string str11 = this.Request.Form["buttonsort_" + index];
            if (!str7.IsNullOrEmpty() && !str8.IsNullOrEmpty())
            {
              RoadFlow.Data.Model.AppLibraryButtons1 model2 = allByAppId.Find((Predicate<RoadFlow.Data.Model.AppLibraryButtons1>) (p => p.ID == index.ToGuid()));
              bool flag2 = false;
              if (model2 == null)
              {
                flag2 = true;
                model2 = new RoadFlow.Data.Model.AppLibraryButtons1();
                model2.ID = Guid.NewGuid();
              }
              else
                appLibraryButtons1List.Add(model2);
              model2.AppLibraryID = model1.ID;
              if (str6.IsGuid())
                model2.ButtonID = new Guid?(str6.ToGuid());
              model2.Events = str8;
              model2.Ico = str9;
              model2.Name = str7.Trim1();
              model2.Sort = str11.ToInt(0);
              model2.ShowType = str10.ToInt(0);
              model2.Type = 0;
              if (flag2)
                appLibraryButtons1_1.Add(model2);
              else
                appLibraryButtons1_1.Update(model2);
            }
          }
          foreach (RoadFlow.Data.Model.AppLibraryButtons1 appLibraryButtons1_2 in allByAppId)
          {
            RoadFlow.Data.Model.AppLibraryButtons1 sub1 = appLibraryButtons1_2;
            if (appLibraryButtons1List.Find((Predicate<RoadFlow.Data.Model.AppLibraryButtons1>) (p => p.ID == sub1.ID)) == null)
              appLibraryButtons1_1.Delete(sub1.ID);
          }
          transactionScope.Complete();
          appLibraryButtons1_1.ClearCache();
          appLibrarySubPages.ClearCache();
        }
      }
      if (model1 == null)
      {
        model1 = new RoadFlow.Data.Model.AppLibrarySubPages();
        model1.ID = Guid.Empty;
        model1.AppLibraryID = this.Request.QueryString["id"].ToGuid();
      }
      return (ActionResult) this.View((object) model1);
    }

    public RedirectResult SubPageDelete()
    {
      string contents = this.Request.Form["subpagesbox"] ?? "";
      RoadFlow.Platform.AppLibrarySubPages appLibrarySubPages = new RoadFlow.Platform.AppLibrarySubPages();
      RoadFlow.Platform.AppLibraryButtons1 appLibraryButtons1 = new RoadFlow.Platform.AppLibraryButtons1();
      using (TransactionScope transactionScope = new TransactionScope())
      {
        string str1 = contents;
        char[] chArray = new char[1]{ ',' };
        foreach (string str2 in str1.Split(chArray))
        {
          if (str2.IsGuid())
          {
            appLibrarySubPages.Delete(str2.ToGuid());
            appLibraryButtons1.DeleteByAppID(str2.ToGuid());
          }
        }
        RoadFlow.Platform.Log.Add("删除了子页面", contents, RoadFlow.Platform.Log.Types.菜单权限, "", "", (RoadFlow.Data.Model.Users) null);
        transactionScope.Complete();
      }
      appLibrarySubPages.ClearCache();
      appLibraryButtons1.ClearCache();
      return this.Redirect("SubPages" + this.Request.Url.Query);
    }

    [MyAttribute(CheckApp = false, CheckLogin = false, CheckUrl = false)]
    public string GetApps()
    {
      return new RoadFlow.Platform.AppLibrary().GetAppsOptions(this.Request.Form["type"].ToGuid(), this.Request.Form["value"]);
    }

    [HttpPost]
    [ValidateAntiForgeryToken]
    [MyAttribute(CheckApp = false)]
    public string Query()
    {
      string str1 = this.Request.Form["Title"];
      string str2 = this.Request.Form["Address"];
      string str3 = this.Request.Form["typeid"];
      string str4 = this.Request.Form["sidx"];
      string str5 = this.Request.Form["sord"];
      RoadFlow.Platform.Dictionary dictionary = new RoadFlow.Platform.Dictionary();
      RoadFlow.Platform.AppLibrary appLibrary1 = new RoadFlow.Platform.AppLibrary();
      string type = str3.IsGuid() ? appLibrary1.GetAllChildsIDString(str3.ToGuid(), true) : "";
      int pageSize = Tools.GetPageSize();
      int pageNumber = Tools.GetPageNumber();
      string order = (str4.IsNullOrEmpty() ? "Title" : str4) + " " + (str5.IsNullOrEmpty() ? "asc" : str5);
      long count;
      List<RoadFlow.Data.Model.AppLibrary> pagerData = appLibrary1.GetPagerData(out count, pageSize, pageNumber, str1.Trim1(), type, str2.Trim1(), order);
      JsonData jsonData = new JsonData();
      foreach (RoadFlow.Data.Model.AppLibrary appLibrary2 in pagerData)
      {
        string empty = string.Empty;
        string str6;
        if (appLibrary2.Ico.IsFontIco())
          str6 = "<i class=\"fa " + appLibrary2.Ico.Trim1() + "\" style=\"font-size:14px;vertical-align:middle;" + (appLibrary2.Color.IsNullOrEmpty() ? "" : "color:" + appLibrary2.Color + ";") + "\"></i>";
        else
          str6 = "<img src=\"" + appLibrary2.Ico.Trim1() + "\" style=\"vertical-align:middle;\" />";
        jsonData.Add((object) new JsonData()
        {
          ["id"] = (JsonData) appLibrary2.ID.ToString(),
          ["Title"] = (JsonData) (str6 + "<span style=\"vertical-align:middle;margin-left:4px;\">" + appLibrary2.Title + "</span>"),
          ["Address"] = (JsonData) appLibrary2.Address,
          ["TypeTitle"] = (JsonData) dictionary.GetTitle(appLibrary2.Type),
          ["Opation"] = (JsonData) ("<a class=\"editlink\" href=\"javascript:void(0);\" onclick=\"edit('" + appLibrary2.ID.ToString() + "');return false;\" style=\"margin-right:6px;\">编辑</a><a class=\"editlink\" href=\"javascript:void(0);\" onclick=\"editsubpage('" + appLibrary2.ID.ToString() + "');return false;\">子页面</a>")
        });
      }
      return "{\"userdata\":{\"total\":" + (object) count + ",\"pagesize\":" + (object) pageSize + ",\"pagenumber\":" + (object) pageNumber + "},\"rows\":" + jsonData.ToJson(true) + "}";
    }
  }
}
