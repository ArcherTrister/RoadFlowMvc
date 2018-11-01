// Decompiled with JetBrains decompiler
// Type: WebMvc.Controllers.ProgramBuilderController
// Assembly: WebMvc, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 43FD7615-6DC3-49FB-B263-7F7CC91AFA77
// Assembly location: C:\inetpub\wwwroot\RoadFlowMvc\bin\WebMvc.dll

using LitJson;
using Microsoft.CSharp.RuntimeBinder;
using RoadFlow.Data.Model;
using RoadFlow.Utility;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.IO;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Transactions;
using System.Web;
using System.Web.Mvc;

namespace WebMvc.Controllers
{
  public class ProgramBuilderController : MyController
  {
    public ActionResult Index()
    {
      return (ActionResult) this.View();
    }

    public ActionResult List()
    {
      return this.List((FormCollection) null);
    }

    [HttpPost]
    public ActionResult List(FormCollection form)
    {
      RoadFlow.Platform.ProgramBuilder programBuilder = new RoadFlow.Platform.ProgramBuilder();
      string name = this.Request.QueryString["Name1"];
      string typeid = this.Request.QueryString["typeid"];
      if (!this.Request.Form["delete"].IsNullOrEmpty())
      {
        string str1 = this.Request.Form["checkbox_app"] ?? "";
        char[] chArray = new char[1]{ ',' };
        foreach (string str2 in str1.Split(chArray))
        {
          if (str2.IsGuid())
          {
            programBuilder.DeleteAllSet(str2.ToGuid());
            RoadFlow.Platform.Log.Add("删除的应用程序设计", str2, RoadFlow.Platform.Log.Types.系统管理, "", "", (RoadFlow.Data.Model.Users) null);
          }
        }
      }
      if (!this.Request.Form["publish"].IsNullOrEmpty())
      {
        string str1 = this.Request.Form["checkbox_app"] ?? "";
        int num = 0;
        char[] chArray = new char[1]{ ',' };
        foreach (string str2 in str1.Split(chArray))
        {
          if (str2.IsGuid())
            num += programBuilder.Publish(str2.ToGuid(), true) ? 1 : 0;
        }
        // ISSUE: reference to a compiler-generated field
        if (ProgramBuilderController.\u003C\u003Eo__2.\u003C\u003Ep__0 == null)
        {
          // ISSUE: reference to a compiler-generated field
          ProgramBuilderController.\u003C\u003Eo__2.\u003C\u003Ep__0 = CallSite<Func<CallSite, object, string, object>>.Create(Binder.SetMember(CSharpBinderFlags.None, "script", typeof (ProgramBuilderController), (IEnumerable<CSharpArgumentInfo>) new CSharpArgumentInfo[2]
          {
            CSharpArgumentInfo.Create(CSharpArgumentInfoFlags.None, (string) null),
            CSharpArgumentInfo.Create(CSharpArgumentInfoFlags.UseCompileTimeType, (string) null)
          }));
        }
        // ISSUE: reference to a compiler-generated field
        // ISSUE: reference to a compiler-generated field
        object obj = ProgramBuilderController.\u003C\u003Eo__2.\u003C\u003Ep__0.Target((CallSite) ProgramBuilderController.\u003C\u003Eo__2.\u003C\u003Ep__0, this.ViewBag, "alert('成功发布" + num.ToString() + "个应用!');");
      }
      if (form != null)
        name = this.Request.Form["Name1"];
      string query = "&appid=" + this.Request.QueryString["appid"] + "&tabid=" + this.Request.QueryString["tabid"] + "&typeid=" + typeid + "&Name1=" + name;
      string pager;
      List<RoadFlow.Data.Model.ProgramBuilder> list = programBuilder.GetList(out pager, query, name, typeid);
      // ISSUE: reference to a compiler-generated field
      if (ProgramBuilderController.\u003C\u003Eo__2.\u003C\u003Ep__1 == null)
      {
        // ISSUE: reference to a compiler-generated field
        ProgramBuilderController.\u003C\u003Eo__2.\u003C\u003Ep__1 = CallSite<Func<CallSite, object, string, object>>.Create(Binder.SetMember(CSharpBinderFlags.None, "pager", typeof (ProgramBuilderController), (IEnumerable<CSharpArgumentInfo>) new CSharpArgumentInfo[2]
        {
          CSharpArgumentInfo.Create(CSharpArgumentInfoFlags.None, (string) null),
          CSharpArgumentInfo.Create(CSharpArgumentInfoFlags.UseCompileTimeType, (string) null)
        }));
      }
      // ISSUE: reference to a compiler-generated field
      // ISSUE: reference to a compiler-generated field
      object obj1 = ProgramBuilderController.\u003C\u003Eo__2.\u003C\u003Ep__1.Target((CallSite) ProgramBuilderController.\u003C\u003Eo__2.\u003C\u003Ep__1, this.ViewBag, pager);
      // ISSUE: reference to a compiler-generated field
      if (ProgramBuilderController.\u003C\u003Eo__2.\u003C\u003Ep__2 == null)
      {
        // ISSUE: reference to a compiler-generated field
        ProgramBuilderController.\u003C\u003Eo__2.\u003C\u003Ep__2 = CallSite<Func<CallSite, object, string, object>>.Create(Binder.SetMember(CSharpBinderFlags.None, "query1", typeof (ProgramBuilderController), (IEnumerable<CSharpArgumentInfo>) new CSharpArgumentInfo[2]
        {
          CSharpArgumentInfo.Create(CSharpArgumentInfoFlags.None, (string) null),
          CSharpArgumentInfo.Create(CSharpArgumentInfoFlags.UseCompileTimeType, (string) null)
        }));
      }
      // ISSUE: reference to a compiler-generated field
      // ISSUE: reference to a compiler-generated field
      object obj2 = ProgramBuilderController.\u003C\u003Eo__2.\u003C\u003Ep__2.Target((CallSite) ProgramBuilderController.\u003C\u003Eo__2.\u003C\u003Ep__2, this.ViewBag, query);
      return (ActionResult) this.View((object) list);
    }

    public ActionResult Tree()
    {
      return (ActionResult) this.View();
    }

    public ActionResult Add()
    {
      return (ActionResult) this.View();
    }

    public ActionResult Set_Attr()
    {
      return this.Set_Attr((FormCollection) null);
    }

    [HttpPost]
    public ActionResult Set_Attr(FormCollection form)
    {
      RoadFlow.Data.Model.ProgramBuilder model = (RoadFlow.Data.Model.ProgramBuilder) null;
      RoadFlow.Platform.ProgramBuilder programBuilder = new RoadFlow.Platform.ProgramBuilder();
      RoadFlow.Platform.Dictionary dictionary = new RoadFlow.Platform.Dictionary();
      string str1 = "1";
      string str2 = "1";
      string str3 = "";
      string str4 = "";
      string empty = string.Empty;
      string str5 = this.Request.QueryString["typeid"];
      string str6 = this.Request.QueryString["pid"];
      string str7 = "";
      string str8 = "";
      if (str6.IsGuid())
      {
        model = programBuilder.Get(str6.ToGuid());
        if (model != null)
        {
          Guid guid = model.Type;
          str5 = guid.ToString();
          str1 = model.IsAdd.ToString();
          str2 = model.IsPager.ToString();
          guid = model.DBConnID;
          str3 = guid.ToString();
          str7 = model.TableName;
          str8 = model.InDataNumberFiledName;
          if (model.FormID.IsGuid())
          {
            empty = model.FormID.ToString();
            RoadFlow.Data.Model.AppLibrary appLibrary = new RoadFlow.Platform.AppLibrary().Get(model.FormID.ToGuid(), false);
            if (appLibrary != null)
            {
              guid = appLibrary.Type;
              str4 = guid.ToString();
            }
          }
        }
      }
      // ISSUE: reference to a compiler-generated field
      if (ProgramBuilderController.\u003C\u003Eo__6.\u003C\u003Ep__0 == null)
      {
        // ISSUE: reference to a compiler-generated field
        ProgramBuilderController.\u003C\u003Eo__6.\u003C\u003Ep__0 = CallSite<Func<CallSite, object, string, object>>.Create(Binder.SetMember(CSharpBinderFlags.None, "TypeOptions", typeof (ProgramBuilderController), (IEnumerable<CSharpArgumentInfo>) new CSharpArgumentInfo[2]
        {
          CSharpArgumentInfo.Create(CSharpArgumentInfoFlags.None, (string) null),
          CSharpArgumentInfo.Create(CSharpArgumentInfoFlags.UseCompileTimeType, (string) null)
        }));
      }
      // ISSUE: reference to a compiler-generated field
      // ISSUE: reference to a compiler-generated field
      object obj1 = ProgramBuilderController.\u003C\u003Eo__6.\u003C\u003Ep__0.Target((CallSite) ProgramBuilderController.\u003C\u003Eo__6.\u003C\u003Ep__0, this.ViewBag, new RoadFlow.Platform.AppLibrary().GetTypeOptions(str5));
      // ISSUE: reference to a compiler-generated field
      if (ProgramBuilderController.\u003C\u003Eo__6.\u003C\u003Ep__1 == null)
      {
        // ISSUE: reference to a compiler-generated field
        ProgramBuilderController.\u003C\u003Eo__6.\u003C\u003Ep__1 = CallSite<Func<CallSite, object, string, object>>.Create(Binder.SetMember(CSharpBinderFlags.None, "IsAddOptions", typeof (ProgramBuilderController), (IEnumerable<CSharpArgumentInfo>) new CSharpArgumentInfo[2]
        {
          CSharpArgumentInfo.Create(CSharpArgumentInfoFlags.None, (string) null),
          CSharpArgumentInfo.Create(CSharpArgumentInfoFlags.UseCompileTimeType, (string) null)
        }));
      }
      // ISSUE: reference to a compiler-generated field
      // ISSUE: reference to a compiler-generated field
      object obj2 = ProgramBuilderController.\u003C\u003Eo__6.\u003C\u003Ep__1.Target((CallSite) ProgramBuilderController.\u003C\u003Eo__6.\u003C\u003Ep__1, this.ViewBag, dictionary.GetOptionsByCode("yesno", RoadFlow.Platform.Dictionary.OptionValueField.Value, str1, "", true));
      // ISSUE: reference to a compiler-generated field
      if (ProgramBuilderController.\u003C\u003Eo__6.\u003C\u003Ep__2 == null)
      {
        // ISSUE: reference to a compiler-generated field
        ProgramBuilderController.\u003C\u003Eo__6.\u003C\u003Ep__2 = CallSite<Func<CallSite, object, string, object>>.Create(Binder.SetMember(CSharpBinderFlags.None, "IsPagerOptions", typeof (ProgramBuilderController), (IEnumerable<CSharpArgumentInfo>) new CSharpArgumentInfo[2]
        {
          CSharpArgumentInfo.Create(CSharpArgumentInfoFlags.None, (string) null),
          CSharpArgumentInfo.Create(CSharpArgumentInfoFlags.UseCompileTimeType, (string) null)
        }));
      }
      // ISSUE: reference to a compiler-generated field
      // ISSUE: reference to a compiler-generated field
      object obj3 = ProgramBuilderController.\u003C\u003Eo__6.\u003C\u003Ep__2.Target((CallSite) ProgramBuilderController.\u003C\u003Eo__6.\u003C\u003Ep__2, this.ViewBag, dictionary.GetOptionsByCode("yesno", RoadFlow.Platform.Dictionary.OptionValueField.Value, str2, "", true));
      // ISSUE: reference to a compiler-generated field
      if (ProgramBuilderController.\u003C\u003Eo__6.\u003C\u003Ep__3 == null)
      {
        // ISSUE: reference to a compiler-generated field
        ProgramBuilderController.\u003C\u003Eo__6.\u003C\u003Ep__3 = CallSite<Func<CallSite, object, string, object>>.Create(Binder.SetMember(CSharpBinderFlags.None, "DbConnOptions", typeof (ProgramBuilderController), (IEnumerable<CSharpArgumentInfo>) new CSharpArgumentInfo[2]
        {
          CSharpArgumentInfo.Create(CSharpArgumentInfoFlags.None, (string) null),
          CSharpArgumentInfo.Create(CSharpArgumentInfoFlags.UseCompileTimeType, (string) null)
        }));
      }
      // ISSUE: reference to a compiler-generated field
      // ISSUE: reference to a compiler-generated field
      object obj4 = ProgramBuilderController.\u003C\u003Eo__6.\u003C\u003Ep__3.Target((CallSite) ProgramBuilderController.\u003C\u003Eo__6.\u003C\u003Ep__3, this.ViewBag, new RoadFlow.Platform.DBConnection().GetAllOptions(str3));
      // ISSUE: reference to a compiler-generated field
      if (ProgramBuilderController.\u003C\u003Eo__6.\u003C\u003Ep__4 == null)
      {
        // ISSUE: reference to a compiler-generated field
        ProgramBuilderController.\u003C\u003Eo__6.\u003C\u003Ep__4 = CallSite<Func<CallSite, object, string, object>>.Create(Binder.SetMember(CSharpBinderFlags.None, "TypeOptions1", typeof (ProgramBuilderController), (IEnumerable<CSharpArgumentInfo>) new CSharpArgumentInfo[2]
        {
          CSharpArgumentInfo.Create(CSharpArgumentInfoFlags.None, (string) null),
          CSharpArgumentInfo.Create(CSharpArgumentInfoFlags.UseCompileTimeType, (string) null)
        }));
      }
      // ISSUE: reference to a compiler-generated field
      // ISSUE: reference to a compiler-generated field
      object obj5 = ProgramBuilderController.\u003C\u003Eo__6.\u003C\u003Ep__4.Target((CallSite) ProgramBuilderController.\u003C\u003Eo__6.\u003C\u003Ep__4, this.ViewBag, new RoadFlow.Platform.AppLibrary().GetTypeOptions(str4));
      // ISSUE: reference to a compiler-generated field
      if (ProgramBuilderController.\u003C\u003Eo__6.\u003C\u003Ep__5 == null)
      {
        // ISSUE: reference to a compiler-generated field
        ProgramBuilderController.\u003C\u003Eo__6.\u003C\u003Ep__5 = CallSite<Func<CallSite, object, string, object>>.Create(Binder.SetMember(CSharpBinderFlags.None, "TableName", typeof (ProgramBuilderController), (IEnumerable<CSharpArgumentInfo>) new CSharpArgumentInfo[2]
        {
          CSharpArgumentInfo.Create(CSharpArgumentInfoFlags.None, (string) null),
          CSharpArgumentInfo.Create(CSharpArgumentInfoFlags.UseCompileTimeType, (string) null)
        }));
      }
      // ISSUE: reference to a compiler-generated field
      // ISSUE: reference to a compiler-generated field
      object obj6 = ProgramBuilderController.\u003C\u003Eo__6.\u003C\u003Ep__5.Target((CallSite) ProgramBuilderController.\u003C\u003Eo__6.\u003C\u003Ep__5, this.ViewBag, str7);
      // ISSUE: reference to a compiler-generated field
      if (ProgramBuilderController.\u003C\u003Eo__6.\u003C\u003Ep__6 == null)
      {
        // ISSUE: reference to a compiler-generated field
        ProgramBuilderController.\u003C\u003Eo__6.\u003C\u003Ep__6 = CallSite<Func<CallSite, object, string, object>>.Create(Binder.SetMember(CSharpBinderFlags.None, "InDataNumberFiledName", typeof (ProgramBuilderController), (IEnumerable<CSharpArgumentInfo>) new CSharpArgumentInfo[2]
        {
          CSharpArgumentInfo.Create(CSharpArgumentInfoFlags.None, (string) null),
          CSharpArgumentInfo.Create(CSharpArgumentInfoFlags.UseCompileTimeType, (string) null)
        }));
      }
      // ISSUE: reference to a compiler-generated field
      // ISSUE: reference to a compiler-generated field
      object obj7 = ProgramBuilderController.\u003C\u003Eo__6.\u003C\u003Ep__6.Target((CallSite) ProgramBuilderController.\u003C\u003Eo__6.\u003C\u003Ep__6, this.ViewBag, str8);
      // ISSUE: reference to a compiler-generated field
      if (ProgramBuilderController.\u003C\u003Eo__6.\u003C\u003Ep__7 == null)
      {
        // ISSUE: reference to a compiler-generated field
        ProgramBuilderController.\u003C\u003Eo__6.\u003C\u003Ep__7 = CallSite<Func<CallSite, object, string, object>>.Create(Binder.SetMember(CSharpBinderFlags.None, "formid", typeof (ProgramBuilderController), (IEnumerable<CSharpArgumentInfo>) new CSharpArgumentInfo[2]
        {
          CSharpArgumentInfo.Create(CSharpArgumentInfoFlags.None, (string) null),
          CSharpArgumentInfo.Create(CSharpArgumentInfoFlags.UseCompileTimeType, (string) null)
        }));
      }
      // ISSUE: reference to a compiler-generated field
      // ISSUE: reference to a compiler-generated field
      object obj8 = ProgramBuilderController.\u003C\u003Eo__6.\u003C\u003Ep__7.Target((CallSite) ProgramBuilderController.\u003C\u003Eo__6.\u003C\u003Ep__7, this.ViewBag, empty);
      string str9 = "&appid=" + this.Request.QueryString["appid"] + "&tabid=" + this.Request.QueryString["tabid"] + "&typeid=" + this.Request.QueryString["typeid"] + "&Name1=" + this.Request.QueryString["Name1"];
      if (form != null)
      {
        string str10 = this.Request.Form["Title1"];
        string str11 = this.Request.Form["sql"];
        string str12 = this.Request.Form["Type"];
        string str13 = this.Request.Form["IsAdd"];
        string str14 = this.Request.Form["DBConnID"];
        string str15 = this.Request.Form["form_forms"];
        string str16 = this.Request.Form["form_editmodel"];
        string str17 = this.Request.Form["form_editmodel_width"];
        string str18 = this.Request.Form["form_editmodel_height"];
        string str19 = this.Request.Form["ButtonLocation"];
        string str20 = this.Request.Form["IsPager"];
        string str21 = this.Request.Form["ClientScript"];
        string str22 = this.Request.Form["ExportTemplate"];
        string str23 = this.Request.Form["ExportHeaderText"];
        string str24 = this.Request.Form["ExportFileName"];
        string str25 = this.Request.Form["TableStyle"];
        string str26 = this.Request.Form["TableHead"];
        string str27 = this.Request.Form["DBTable"];
        string str28 = this.Request.Form["DBFiled"];
        bool flag = false;
        if (model == null)
        {
          flag = true;
          model = new RoadFlow.Data.Model.ProgramBuilder();
          model.ID = Guid.NewGuid();
          model.CreateTime = DateTimeNew.Now;
          model.CreateUser = RoadFlow.Platform.Users.CurrentUserID;
          model.Status = 0;
        }
        model.IsAdd = str13.ToInt(0);
        model.Name = str10.Trim();
        model.SQL = str11;
        model.DBConnID = str14.ToGuid();
        model.Type = str12.ToGuid();
        model.FormID = str15;
        model.EditModel = new int?(str16.ToInt(0));
        model.Width = str17;
        model.Height = str18;
        model.ButtonLocation = new int?(str19.ToInt(0));
        model.IsPager = new int?(str20.ToInt(1));
        model.ClientScript = str21;
        model.ExportTemplate = str22;
        model.ExportHeaderText = str23.Trim1();
        model.ExportFileName = str24.Trim1();
        model.TableStyle = str25;
        model.TableHead = str26;
        model.TableName = str27;
        model.InDataNumberFiledName = str28;
        if (flag)
          programBuilder.Add(model);
        else
          programBuilder.Update(model);
        RoadFlow.Platform.Log.Add("保存了应用程序设计属性", model.Serialize(), RoadFlow.Platform.Log.Types.其它分类, "", "", (RoadFlow.Data.Model.Users) null);
        // ISSUE: reference to a compiler-generated field
        if (ProgramBuilderController.\u003C\u003Eo__6.\u003C\u003Ep__8 == null)
        {
          // ISSUE: reference to a compiler-generated field
          ProgramBuilderController.\u003C\u003Eo__6.\u003C\u003Ep__8 = CallSite<Func<CallSite, object, string, object>>.Create(Binder.SetMember(CSharpBinderFlags.None, "script", typeof (ProgramBuilderController), (IEnumerable<CSharpArgumentInfo>) new CSharpArgumentInfo[2]
          {
            CSharpArgumentInfo.Create(CSharpArgumentInfoFlags.None, (string) null),
            CSharpArgumentInfo.Create(CSharpArgumentInfoFlags.UseCompileTimeType, (string) null)
          }));
        }
        // ISSUE: reference to a compiler-generated field
        // ISSUE: reference to a compiler-generated field
        object obj9 = ProgramBuilderController.\u003C\u003Eo__6.\u003C\u003Ep__8.Target((CallSite) ProgramBuilderController.\u003C\u003Eo__6.\u003C\u003Ep__8, this.ViewBag, "alert('保存成功');parent.location='Add?pid=" + (object) model.ID + str9 + "';");
      }
      if (model == null)
        model = new RoadFlow.Data.Model.ProgramBuilder();
      return (ActionResult) this.View((object) model);
    }

    public ActionResult Set_ListField()
    {
      return this.Set_ListField((FormCollection) null);
    }

    [HttpPost]
    public ActionResult Set_ListField(FormCollection form)
    {
      RoadFlow.Platform.ProgramBuilderFields programBuilderFields = new RoadFlow.Platform.ProgramBuilderFields();
      List<RoadFlow.Data.Model.ProgramBuilderFields> programBuilderFieldsList = new List<RoadFlow.Data.Model.ProgramBuilderFields>();
      string str1 = this.Request.QueryString["pid"];
      if (!this.Request.Form["delete"].IsNullOrEmpty())
      {
        string str2 = this.Request.Form["checkbox_app"] ?? "";
        char[] chArray = new char[1]{ ',' };
        foreach (string str3 in str2.Split(chArray))
          programBuilderFields.Delete(str3.ToGuid());
        RoadFlow.Platform.Log.Add("删除了应用程序设计字段", str1, RoadFlow.Platform.Log.Types.其它分类, "", "", (RoadFlow.Data.Model.Users) null);
      }
      List<RoadFlow.Data.Model.ProgramBuilderFields> all = programBuilderFields.GetAll(str1.ToGuid());
      string str4 = "&appid=" + this.Request.QueryString["appid"] + "&tabid=" + this.Request.QueryString["tabid"] + "&typeid=" + this.Request.QueryString["typeid"] + "&Name1=" + this.Request.QueryString["Name1"] + "&pid=" + this.Request.QueryString["pid"] + "&maxSort=" + (all.Count > 0 ? all.Max<RoadFlow.Data.Model.ProgramBuilderFields>((Func<RoadFlow.Data.Model.ProgramBuilderFields, int>) (p => p.Sort)).ToString() : "0");
      // ISSUE: reference to a compiler-generated field
      if (ProgramBuilderController.\u003C\u003Eo__8.\u003C\u003Ep__0 == null)
      {
        // ISSUE: reference to a compiler-generated field
        ProgramBuilderController.\u003C\u003Eo__8.\u003C\u003Ep__0 = CallSite<Func<CallSite, object, string, object>>.Create(Binder.SetMember(CSharpBinderFlags.None, "query", typeof (ProgramBuilderController), (IEnumerable<CSharpArgumentInfo>) new CSharpArgumentInfo[2]
        {
          CSharpArgumentInfo.Create(CSharpArgumentInfoFlags.None, (string) null),
          CSharpArgumentInfo.Create(CSharpArgumentInfoFlags.UseCompileTimeType, (string) null)
        }));
      }
      // ISSUE: reference to a compiler-generated field
      // ISSUE: reference to a compiler-generated field
      object obj = ProgramBuilderController.\u003C\u003Eo__8.\u003C\u003Ep__0.Target((CallSite) ProgramBuilderController.\u003C\u003Eo__8.\u003C\u003Ep__0, this.ViewBag, str4);
      return (ActionResult) this.View((object) all);
    }

    public ActionResult Set_ListField_Add()
    {
      return this.Set_ListField_Add((FormCollection) null);
    }

    [HttpPost]
    public ActionResult Set_ListField_Add(FormCollection form)
    {
      RoadFlow.Data.Model.ProgramBuilderFields model = (RoadFlow.Data.Model.ProgramBuilderFields) null;
      RoadFlow.Platform.ProgramBuilderFields programBuilderFields = new RoadFlow.Platform.ProgramBuilderFields();
      RoadFlow.Platform.Dictionary dictionary = new RoadFlow.Platform.Dictionary();
      RoadFlow.Platform.ProgramBuilder programBuilder = new RoadFlow.Platform.ProgramBuilder();
      string str1 = this.Request.QueryString["pid"];
      string str2 = this.Request.QueryString["fid"];
      string str3 = this.Request.QueryString["maxSort"];
      string str4 = "";
      string str5 = "";
      string str6 = "";
      // ISSUE: reference to a compiler-generated field
      if (ProgramBuilderController.\u003C\u003Eo__10.\u003C\u003Ep__0 == null)
      {
        // ISSUE: reference to a compiler-generated field
        ProgramBuilderController.\u003C\u003Eo__10.\u003C\u003Ep__0 = CallSite<Func<CallSite, object, string, object>>.Create(Binder.SetMember(CSharpBinderFlags.None, "sort", typeof (ProgramBuilderController), (IEnumerable<CSharpArgumentInfo>) new CSharpArgumentInfo[2]
        {
          CSharpArgumentInfo.Create(CSharpArgumentInfoFlags.None, (string) null),
          CSharpArgumentInfo.Create(CSharpArgumentInfoFlags.UseCompileTimeType, (string) null)
        }));
      }
      // ISSUE: reference to a compiler-generated field
      // ISSUE: reference to a compiler-generated field
      object obj1 = ProgramBuilderController.\u003C\u003Eo__10.\u003C\u003Ep__0.Target((CallSite) ProgramBuilderController.\u003C\u003Eo__10.\u003C\u003Ep__0, this.ViewBag, (str3.ToInt() + 5).ToString());
      if (str2.IsGuid())
      {
        model = programBuilderFields.Get(str2.ToGuid());
        if (model != null)
        {
          str4 = model.Field;
          str5 = model.ShowType.ToString();
          str6 = model.Align;
          // ISSUE: reference to a compiler-generated field
          if (ProgramBuilderController.\u003C\u003Eo__10.\u003C\u003Ep__1 == null)
          {
            // ISSUE: reference to a compiler-generated field
            ProgramBuilderController.\u003C\u003Eo__10.\u003C\u003Ep__1 = CallSite<Func<CallSite, object, string, object>>.Create(Binder.SetMember(CSharpBinderFlags.None, "sort", typeof (ProgramBuilderController), (IEnumerable<CSharpArgumentInfo>) new CSharpArgumentInfo[2]
            {
              CSharpArgumentInfo.Create(CSharpArgumentInfoFlags.None, (string) null),
              CSharpArgumentInfo.Create(CSharpArgumentInfoFlags.UseCompileTimeType, (string) null)
            }));
          }
          // ISSUE: reference to a compiler-generated field
          // ISSUE: reference to a compiler-generated field
          object obj2 = ProgramBuilderController.\u003C\u003Eo__10.\u003C\u003Ep__1.Target((CallSite) ProgramBuilderController.\u003C\u003Eo__10.\u003C\u003Ep__1, this.ViewBag, model.Sort.ToString());
        }
      }
      // ISSUE: reference to a compiler-generated field
      if (ProgramBuilderController.\u003C\u003Eo__10.\u003C\u003Ep__2 == null)
      {
        // ISSUE: reference to a compiler-generated field
        ProgramBuilderController.\u003C\u003Eo__10.\u003C\u003Ep__2 = CallSite<Func<CallSite, object, string, object>>.Create(Binder.SetMember(CSharpBinderFlags.None, "ShowTypeOptions", typeof (ProgramBuilderController), (IEnumerable<CSharpArgumentInfo>) new CSharpArgumentInfo[2]
        {
          CSharpArgumentInfo.Create(CSharpArgumentInfoFlags.None, (string) null),
          CSharpArgumentInfo.Create(CSharpArgumentInfoFlags.UseCompileTimeType, (string) null)
        }));
      }
      // ISSUE: reference to a compiler-generated field
      // ISSUE: reference to a compiler-generated field
      object obj3 = ProgramBuilderController.\u003C\u003Eo__10.\u003C\u003Ep__2.Target((CallSite) ProgramBuilderController.\u003C\u003Eo__10.\u003C\u003Ep__2, this.ViewBag, dictionary.GetOptionsByCode("programbuilder_showtype", RoadFlow.Platform.Dictionary.OptionValueField.Value, str5, "", true));
      // ISSUE: reference to a compiler-generated field
      if (ProgramBuilderController.\u003C\u003Eo__10.\u003C\u003Ep__3 == null)
      {
        // ISSUE: reference to a compiler-generated field
        ProgramBuilderController.\u003C\u003Eo__10.\u003C\u003Ep__3 = CallSite<Func<CallSite, object, string, object>>.Create(Binder.SetMember(CSharpBinderFlags.None, "AlignOptions", typeof (ProgramBuilderController), (IEnumerable<CSharpArgumentInfo>) new CSharpArgumentInfo[2]
        {
          CSharpArgumentInfo.Create(CSharpArgumentInfoFlags.None, (string) null),
          CSharpArgumentInfo.Create(CSharpArgumentInfoFlags.UseCompileTimeType, (string) null)
        }));
      }
      // ISSUE: reference to a compiler-generated field
      // ISSUE: reference to a compiler-generated field
      object obj4 = ProgramBuilderController.\u003C\u003Eo__10.\u003C\u003Ep__3.Target((CallSite) ProgramBuilderController.\u003C\u003Eo__10.\u003C\u003Ep__3, this.ViewBag, dictionary.GetOptionsByCode("programbuilder_align", RoadFlow.Platform.Dictionary.OptionValueField.Value, str6, "", true));
      // ISSUE: reference to a compiler-generated field
      if (ProgramBuilderController.\u003C\u003Eo__10.\u003C\u003Ep__4 == null)
      {
        // ISSUE: reference to a compiler-generated field
        ProgramBuilderController.\u003C\u003Eo__10.\u003C\u003Ep__4 = CallSite<Func<CallSite, object, string, object>>.Create(Binder.SetMember(CSharpBinderFlags.None, "FieldOptions", typeof (ProgramBuilderController), (IEnumerable<CSharpArgumentInfo>) new CSharpArgumentInfo[2]
        {
          CSharpArgumentInfo.Create(CSharpArgumentInfoFlags.None, (string) null),
          CSharpArgumentInfo.Create(CSharpArgumentInfoFlags.UseCompileTimeType, (string) null)
        }));
      }
      // ISSUE: reference to a compiler-generated field
      // ISSUE: reference to a compiler-generated field
      object obj5 = ProgramBuilderController.\u003C\u003Eo__10.\u003C\u003Ep__4.Target((CallSite) ProgramBuilderController.\u003C\u003Eo__10.\u003C\u003Ep__4, this.ViewBag, programBuilder.GetFieldsOptions(str1.ToGuid(), str4));
      if (form != null)
      {
        string str7 = this.Request.Form["Field"];
        string str8 = this.Request.Form["ShowTitle"];
        string str9 = this.Request.Form["ShowType"];
        string str10 = this.Request.Form["ShowFormat"];
        string str11 = this.Request.Form["Align"];
        string str12 = this.Request.Form["Width"];
        string str13 = this.Request.Form["CustomString"];
        string str14 = this.Request.Form["Sort"];
        bool flag = false;
        if (model == null)
        {
          flag = true;
          model = new RoadFlow.Data.Model.ProgramBuilderFields();
          model.ID = Guid.NewGuid();
          model.ProgramID = str1.ToGuid();
        }
        model.Align = str11;
        model.CustomString = str13;
        model.Field = str7;
        model.ShowFormat = str10;
        model.ShowTitle = str8.IsNullOrEmpty() ? "" : str8;
        model.ShowType = str9.ToInt();
        model.Sort = str14.ToInt();
        model.Width = str12;
        if (flag)
          programBuilderFields.Add(model);
        else
          programBuilderFields.Update(model);
        // ISSUE: reference to a compiler-generated field
        if (ProgramBuilderController.\u003C\u003Eo__10.\u003C\u003Ep__5 == null)
        {
          // ISSUE: reference to a compiler-generated field
          ProgramBuilderController.\u003C\u003Eo__10.\u003C\u003Ep__5 = CallSite<Func<CallSite, object, string, object>>.Create(Binder.SetMember(CSharpBinderFlags.None, "script", typeof (ProgramBuilderController), (IEnumerable<CSharpArgumentInfo>) new CSharpArgumentInfo[2]
          {
            CSharpArgumentInfo.Create(CSharpArgumentInfoFlags.None, (string) null),
            CSharpArgumentInfo.Create(CSharpArgumentInfoFlags.UseCompileTimeType, (string) null)
          }));
        }
        // ISSUE: reference to a compiler-generated field
        // ISSUE: reference to a compiler-generated field
        object obj2 = ProgramBuilderController.\u003C\u003Eo__10.\u003C\u003Ep__5.Target((CallSite) ProgramBuilderController.\u003C\u003Eo__10.\u003C\u003Ep__5, this.ViewBag, "alert('保存成功!');window.location='Set_ListField" + this.Request.Url.Query + "';");
      }
      if (model == null)
        model = new RoadFlow.Data.Model.ProgramBuilderFields();
      return (ActionResult) this.View((object) model);
    }

    public ActionResult Set_Query()
    {
      return this.Set_Query((FormCollection) null);
    }

    [HttpPost]
    public ActionResult Set_Query(FormCollection form)
    {
      List<RoadFlow.Data.Model.ProgramBuilderQuerys> programBuilderQuerysList = new List<RoadFlow.Data.Model.ProgramBuilderQuerys>();
      RoadFlow.Platform.ProgramBuilderQuerys programBuilderQuerys = new RoadFlow.Platform.ProgramBuilderQuerys();
      string empty1 = string.Empty;
      string empty2 = string.Empty;
      string str1 = this.Request.QueryString["pid"];
      if (!this.Request.Form["delete"].IsNullOrEmpty())
      {
        string str2 = this.Request.Form["checkbox_app"] ?? "";
        char[] chArray = new char[1]{ ',' };
        foreach (string str3 in str2.Split(chArray))
          programBuilderQuerys.Delete(str3.ToGuid());
        RoadFlow.Platform.Log.Add("删除了应用程序设计查询", str1, RoadFlow.Platform.Log.Types.其它分类, "", "", (RoadFlow.Data.Model.Users) null);
      }
      List<RoadFlow.Data.Model.ProgramBuilderQuerys> all = programBuilderQuerys.GetAll(str1.ToGuid());
      string str4 = "&appid=" + this.Request.QueryString["appid"] + "&tabid=" + this.Request.QueryString["tabid"] + "&typeid=" + this.Request.QueryString["typeid"] + "&Name1=" + this.Request.QueryString["Name1"] + "&pid=" + this.Request.QueryString["pid"] + "&maxSort=" + (all.Count > 0 ? all.Max<RoadFlow.Data.Model.ProgramBuilderQuerys>((Func<RoadFlow.Data.Model.ProgramBuilderQuerys, int>) (p => p.Sort)).ToString() : "0");
      // ISSUE: reference to a compiler-generated field
      if (ProgramBuilderController.\u003C\u003Eo__12.\u003C\u003Ep__0 == null)
      {
        // ISSUE: reference to a compiler-generated field
        ProgramBuilderController.\u003C\u003Eo__12.\u003C\u003Ep__0 = CallSite<Func<CallSite, object, string, object>>.Create(Binder.SetMember(CSharpBinderFlags.None, "query", typeof (ProgramBuilderController), (IEnumerable<CSharpArgumentInfo>) new CSharpArgumentInfo[2]
        {
          CSharpArgumentInfo.Create(CSharpArgumentInfoFlags.None, (string) null),
          CSharpArgumentInfo.Create(CSharpArgumentInfoFlags.UseCompileTimeType, (string) null)
        }));
      }
      // ISSUE: reference to a compiler-generated field
      // ISSUE: reference to a compiler-generated field
      object obj = ProgramBuilderController.\u003C\u003Eo__12.\u003C\u003Ep__0.Target((CallSite) ProgramBuilderController.\u003C\u003Eo__12.\u003C\u003Ep__0, this.ViewBag, str4);
      return (ActionResult) this.View((object) all);
    }

    public ActionResult Set_Query_Add()
    {
      return this.Set_Query_Add((FormCollection) null);
    }

    [HttpPost]
    public ActionResult Set_Query_Add(FormCollection form)
    {
      RoadFlow.Platform.ProgramBuilder programBuilder = new RoadFlow.Platform.ProgramBuilder();
      RoadFlow.Platform.Dictionary dictionary = new RoadFlow.Platform.Dictionary();
      string empty1 = string.Empty;
      string empty2 = string.Empty;
      RoadFlow.Data.Model.ProgramBuilderQuerys model = (RoadFlow.Data.Model.ProgramBuilderQuerys) null;
      RoadFlow.Platform.ProgramBuilderQuerys programBuilderQuerys = new RoadFlow.Platform.ProgramBuilderQuerys();
      string str1 = this.Request.QueryString["pid"];
      string str2 = this.Request.QueryString["queryid"];
      string str3 = ((this.Request.QueryString["maxSort"] ?? "0").ToInt() + 5).ToString();
      string str4 = "";
      string str5 = "";
      string str6 = "";
      string str7 = "";
      string str8 = "";
      int num;
      if (str2.IsGuid())
      {
        model = programBuilderQuerys.Get(str2.ToGuid());
        if (model != null)
        {
          str4 = model.Field;
          str5 = model.Operators;
          num = model.InputType;
          str6 = num.ToString();
          str7 = model.DataSource.ToString();
          str8 = model.DataLinkID;
          num = model.Sort;
          str3 = num.ToString();
        }
      }
      // ISSUE: reference to a compiler-generated field
      if (ProgramBuilderController.\u003C\u003Eo__14.\u003C\u003Ep__0 == null)
      {
        // ISSUE: reference to a compiler-generated field
        ProgramBuilderController.\u003C\u003Eo__14.\u003C\u003Ep__0 = CallSite<Func<CallSite, object, string, object>>.Create(Binder.SetMember(CSharpBinderFlags.None, "sort", typeof (ProgramBuilderController), (IEnumerable<CSharpArgumentInfo>) new CSharpArgumentInfo[2]
        {
          CSharpArgumentInfo.Create(CSharpArgumentInfoFlags.None, (string) null),
          CSharpArgumentInfo.Create(CSharpArgumentInfoFlags.UseCompileTimeType, (string) null)
        }));
      }
      // ISSUE: reference to a compiler-generated field
      // ISSUE: reference to a compiler-generated field
      object obj1 = ProgramBuilderController.\u003C\u003Eo__14.\u003C\u003Ep__0.Target((CallSite) ProgramBuilderController.\u003C\u003Eo__14.\u003C\u003Ep__0, this.ViewBag, str3.ToString());
      // ISSUE: reference to a compiler-generated field
      if (ProgramBuilderController.\u003C\u003Eo__14.\u003C\u003Ep__1 == null)
      {
        // ISSUE: reference to a compiler-generated field
        ProgramBuilderController.\u003C\u003Eo__14.\u003C\u003Ep__1 = CallSite<Func<CallSite, object, string, object>>.Create(Binder.SetMember(CSharpBinderFlags.None, "FieldOptions", typeof (ProgramBuilderController), (IEnumerable<CSharpArgumentInfo>) new CSharpArgumentInfo[2]
        {
          CSharpArgumentInfo.Create(CSharpArgumentInfoFlags.None, (string) null),
          CSharpArgumentInfo.Create(CSharpArgumentInfoFlags.UseCompileTimeType, (string) null)
        }));
      }
      // ISSUE: reference to a compiler-generated field
      // ISSUE: reference to a compiler-generated field
      object obj2 = ProgramBuilderController.\u003C\u003Eo__14.\u003C\u003Ep__1.Target((CallSite) ProgramBuilderController.\u003C\u003Eo__14.\u003C\u003Ep__1, this.ViewBag, programBuilder.GetFieldsOptions(str1.ToGuid(), str4));
      // ISSUE: reference to a compiler-generated field
      if (ProgramBuilderController.\u003C\u003Eo__14.\u003C\u003Ep__2 == null)
      {
        // ISSUE: reference to a compiler-generated field
        ProgramBuilderController.\u003C\u003Eo__14.\u003C\u003Ep__2 = CallSite<Func<CallSite, object, string, object>>.Create(Binder.SetMember(CSharpBinderFlags.None, "OperatorsOptions", typeof (ProgramBuilderController), (IEnumerable<CSharpArgumentInfo>) new CSharpArgumentInfo[2]
        {
          CSharpArgumentInfo.Create(CSharpArgumentInfoFlags.None, (string) null),
          CSharpArgumentInfo.Create(CSharpArgumentInfoFlags.UseCompileTimeType, (string) null)
        }));
      }
      // ISSUE: reference to a compiler-generated field
      // ISSUE: reference to a compiler-generated field
      object obj3 = ProgramBuilderController.\u003C\u003Eo__14.\u003C\u003Ep__2.Target((CallSite) ProgramBuilderController.\u003C\u003Eo__14.\u003C\u003Ep__2, this.ViewBag, dictionary.GetOptionsByCode("programbuilder_operators", RoadFlow.Platform.Dictionary.OptionValueField.Value, str5, "", true));
      // ISSUE: reference to a compiler-generated field
      if (ProgramBuilderController.\u003C\u003Eo__14.\u003C\u003Ep__3 == null)
      {
        // ISSUE: reference to a compiler-generated field
        ProgramBuilderController.\u003C\u003Eo__14.\u003C\u003Ep__3 = CallSite<Func<CallSite, object, string, object>>.Create(Binder.SetMember(CSharpBinderFlags.None, "InputTypeOptions", typeof (ProgramBuilderController), (IEnumerable<CSharpArgumentInfo>) new CSharpArgumentInfo[2]
        {
          CSharpArgumentInfo.Create(CSharpArgumentInfoFlags.None, (string) null),
          CSharpArgumentInfo.Create(CSharpArgumentInfoFlags.UseCompileTimeType, (string) null)
        }));
      }
      // ISSUE: reference to a compiler-generated field
      // ISSUE: reference to a compiler-generated field
      object obj4 = ProgramBuilderController.\u003C\u003Eo__14.\u003C\u003Ep__3.Target((CallSite) ProgramBuilderController.\u003C\u003Eo__14.\u003C\u003Ep__3, this.ViewBag, dictionary.GetOptionsByCode("programbuilder_inputtype", RoadFlow.Platform.Dictionary.OptionValueField.Value, str6, "", true));
      // ISSUE: reference to a compiler-generated field
      if (ProgramBuilderController.\u003C\u003Eo__14.\u003C\u003Ep__4 == null)
      {
        // ISSUE: reference to a compiler-generated field
        ProgramBuilderController.\u003C\u003Eo__14.\u003C\u003Ep__4 = CallSite<Func<CallSite, object, string, object>>.Create(Binder.SetMember(CSharpBinderFlags.None, "ControlHidden", typeof (ProgramBuilderController), (IEnumerable<CSharpArgumentInfo>) new CSharpArgumentInfo[2]
        {
          CSharpArgumentInfo.Create(CSharpArgumentInfoFlags.None, (string) null),
          CSharpArgumentInfo.Create(CSharpArgumentInfoFlags.UseCompileTimeType, (string) null)
        }));
      }
      // ISSUE: reference to a compiler-generated field
      // ISSUE: reference to a compiler-generated field
      object obj5 = ProgramBuilderController.\u003C\u003Eo__14.\u003C\u003Ep__4.Target((CallSite) ProgramBuilderController.\u003C\u003Eo__14.\u003C\u003Ep__4, this.ViewBag, RoadFlow.Utility.Tools.GetRandomString(6));
      // ISSUE: reference to a compiler-generated field
      if (ProgramBuilderController.\u003C\u003Eo__14.\u003C\u003Ep__5 == null)
      {
        // ISSUE: reference to a compiler-generated field
        ProgramBuilderController.\u003C\u003Eo__14.\u003C\u003Ep__5 = CallSite<Func<CallSite, object, string, object>>.Create(Binder.SetMember(CSharpBinderFlags.None, "DataSource", typeof (ProgramBuilderController), (IEnumerable<CSharpArgumentInfo>) new CSharpArgumentInfo[2]
        {
          CSharpArgumentInfo.Create(CSharpArgumentInfoFlags.None, (string) null),
          CSharpArgumentInfo.Create(CSharpArgumentInfoFlags.UseCompileTimeType, (string) null)
        }));
      }
      // ISSUE: reference to a compiler-generated field
      // ISSUE: reference to a compiler-generated field
      object obj6 = ProgramBuilderController.\u003C\u003Eo__14.\u003C\u003Ep__5.Target((CallSite) ProgramBuilderController.\u003C\u003Eo__14.\u003C\u003Ep__5, this.ViewBag, dictionary.GetRadiosByCode("programbuilder_datasource", "DataSource", RoadFlow.Platform.Dictionary.OptionValueField.Value, str7, "onclick=\"dataSourceChange(this.value)\";"));
      // ISSUE: reference to a compiler-generated field
      if (ProgramBuilderController.\u003C\u003Eo__14.\u003C\u003Ep__6 == null)
      {
        // ISSUE: reference to a compiler-generated field
        ProgramBuilderController.\u003C\u003Eo__14.\u003C\u003Ep__6 = CallSite<Func<CallSite, object, string, object>>.Create(Binder.SetMember(CSharpBinderFlags.None, "DataSource_String_SQL_LinkOptions", typeof (ProgramBuilderController), (IEnumerable<CSharpArgumentInfo>) new CSharpArgumentInfo[2]
        {
          CSharpArgumentInfo.Create(CSharpArgumentInfoFlags.None, (string) null),
          CSharpArgumentInfo.Create(CSharpArgumentInfoFlags.UseCompileTimeType, (string) null)
        }));
      }
      // ISSUE: reference to a compiler-generated field
      // ISSUE: reference to a compiler-generated field
      object obj7 = ProgramBuilderController.\u003C\u003Eo__14.\u003C\u003Ep__6.Target((CallSite) ProgramBuilderController.\u003C\u003Eo__14.\u003C\u003Ep__6, this.ViewBag, new RoadFlow.Platform.DBConnection().GetAllOptions(str8));
      if (form != null)
      {
        string str9 = this.Request.Form["Field"];
        string str10 = this.Request.Form["ShowTitle"];
        string str11 = this.Request.Form["ControlName"];
        string str12 = this.Request.Form["Operators"];
        string str13 = this.Request.Form["InputType"];
        string str14 = this.Request.Form["Width"];
        string str15 = this.Request.Form["Sort"];
        string str16 = this.Request.Form["DataSource"];
        string str17 = this.Request.Form["DataSource_String_SQL_Link"];
        bool flag = false;
        if (model == null)
        {
          flag = true;
          model = new RoadFlow.Data.Model.ProgramBuilderQuerys();
          model.ID = Guid.NewGuid();
          model.ProgramID = str1.ToGuid();
        }
        model.ControlName = str11;
        model.Field = str9;
        model.InputType = str13.ToInt();
        model.Operators = str12;
        model.ShowTitle = str10;
        model.Sort = str15.ToInt();
        model.Width = str14;
        model.DataLinkID = str17;
        if (model.InputType == 6)
        {
          if (str16.IsInt())
          {
            model.DataSource = new int?(str16.ToInt());
            int? dataSource1 = model.DataSource;
            num = 1;
            if ((dataSource1.GetValueOrDefault() == num ? (dataSource1.HasValue ? 1 : 0) : 0) == 0)
            {
              int? dataSource2 = model.DataSource;
              num = 3;
              if ((dataSource2.GetValueOrDefault() == num ? (dataSource2.HasValue ? 1 : 0) : 0) == 0)
              {
                dataSource2 = model.DataSource;
                num = 2;
                if ((dataSource2.GetValueOrDefault() == num ? (dataSource2.HasValue ? 1 : 0) : 0) != 0)
                {
                  model.DataSourceString = this.Request.Form["DataSource_Dict"];
                  goto label_32;
                }
                else
                  goto label_32;
              }
            }
            model.DataSourceString = this.Request.Form["DataSource_String"];
          }
          else
            model.DataSource = new int?();
        }
        else if (model.InputType == 8)
          model.DataSourceString = this.Request.Form["DataSource_Dict_Value"];
        else if (model.InputType == 7)
        {
          string str18 = this.Request.Form["DataSource_Organize_Range"];
          string str19 = this.Request.Form["DataSource_Organize_Type_Unit"];
          string str20 = this.Request.Form["DataSource_Organize_Type_Dept"];
          string str21 = this.Request.Form["DataSource_Organize_Type_Station"];
          string str22 = this.Request.Form["DataSource_Organize_Type_WorkGroup"];
          string str23 = this.Request.Form["DataSource_Organize_Type_Role"];
          string str24 = this.Request.Form["DataSource_Organize_Type_User"];
          string str25 = this.Request.Form["DataSource_Organize_Type_More"];
          string str26 = this.Request.Form["DataSource_Organize_Type_QueryUsers"];
          model.DataSourceString = str18 + "|" + str19 + "|" + str20 + "|" + str21 + "|" + str22 + "|" + str23 + "|" + str24 + "|" + str25;
          model.IsQueryUsers = new int?(str26.ToInt(0));
        }
label_32:
        if (flag)
          programBuilderQuerys.Add(model);
        else
          programBuilderQuerys.Update(model);
        // ISSUE: reference to a compiler-generated field
        if (ProgramBuilderController.\u003C\u003Eo__14.\u003C\u003Ep__7 == null)
        {
          // ISSUE: reference to a compiler-generated field
          ProgramBuilderController.\u003C\u003Eo__14.\u003C\u003Ep__7 = CallSite<Func<CallSite, object, string, object>>.Create(Binder.SetMember(CSharpBinderFlags.None, "script", typeof (ProgramBuilderController), (IEnumerable<CSharpArgumentInfo>) new CSharpArgumentInfo[2]
          {
            CSharpArgumentInfo.Create(CSharpArgumentInfoFlags.None, (string) null),
            CSharpArgumentInfo.Create(CSharpArgumentInfoFlags.UseCompileTimeType, (string) null)
          }));
        }
        // ISSUE: reference to a compiler-generated field
        // ISSUE: reference to a compiler-generated field
        object obj8 = ProgramBuilderController.\u003C\u003Eo__14.\u003C\u003Ep__7.Target((CallSite) ProgramBuilderController.\u003C\u003Eo__14.\u003C\u003Ep__7, this.ViewBag, "alert('保存成功!');window.location='Set_Query" + this.Request.Url.Query + "';");
      }
      if (model == null)
        model = new RoadFlow.Data.Model.ProgramBuilderQuerys();
      return (ActionResult) this.View((object) model);
    }

    public ActionResult Set_Button()
    {
      return this.Set_Button((FormCollection) null);
    }

    [HttpPost]
    public ActionResult Set_Button(FormCollection form)
    {
      string empty1 = string.Empty;
      string empty2 = string.Empty;
      List<RoadFlow.Data.Model.ProgramBuilderButtons> programBuilderButtonsList = new List<RoadFlow.Data.Model.ProgramBuilderButtons>();
      RoadFlow.Platform.ProgramBuilderButtons programBuilderButtons = new RoadFlow.Platform.ProgramBuilderButtons();
      string str1 = this.Request.QueryString["pid"];
      if (form != null && !this.Request.Form["delete"].IsNullOrEmpty())
      {
        string str2 = this.Request.Form["checkbox_app"] ?? "";
        char[] chArray = new char[1]{ ',' };
        foreach (string str3 in str2.Split(chArray))
        {
          if (str3.IsGuid())
            programBuilderButtons.Delete(str3.ToGuid());
        }
      }
      List<RoadFlow.Data.Model.ProgramBuilderButtons> list = programBuilderButtons.GetAll(str1.ToGuid()).OrderBy<RoadFlow.Data.Model.ProgramBuilderButtons, int>((Func<RoadFlow.Data.Model.ProgramBuilderButtons, int>) (p => p.ShowType)).ThenBy<RoadFlow.Data.Model.ProgramBuilderButtons, int>((Func<RoadFlow.Data.Model.ProgramBuilderButtons, int>) (p => p.Sort)).ToList<RoadFlow.Data.Model.ProgramBuilderButtons>();
      string str4 = "&appid=" + this.Request.QueryString["appid"] + "&tabid=" + this.Request.QueryString["tabid"] + "&typeid=" + this.Request.QueryString["typeid"] + "&Name1=" + this.Request.QueryString["Name1"] + "&pid=" + this.Request.QueryString["pid"] + "&maxSort=" + (list.Count > 0 ? (list.Max<RoadFlow.Data.Model.ProgramBuilderButtons>((Func<RoadFlow.Data.Model.ProgramBuilderButtons, int>) (p => p.Sort)) + 5).ToString() : "0");
      // ISSUE: reference to a compiler-generated field
      if (ProgramBuilderController.\u003C\u003Eo__16.\u003C\u003Ep__0 == null)
      {
        // ISSUE: reference to a compiler-generated field
        ProgramBuilderController.\u003C\u003Eo__16.\u003C\u003Ep__0 = CallSite<Func<CallSite, object, string, object>>.Create(Binder.SetMember(CSharpBinderFlags.None, "query", typeof (ProgramBuilderController), (IEnumerable<CSharpArgumentInfo>) new CSharpArgumentInfo[2]
        {
          CSharpArgumentInfo.Create(CSharpArgumentInfoFlags.None, (string) null),
          CSharpArgumentInfo.Create(CSharpArgumentInfoFlags.UseCompileTimeType, (string) null)
        }));
      }
      // ISSUE: reference to a compiler-generated field
      // ISSUE: reference to a compiler-generated field
      object obj = ProgramBuilderController.\u003C\u003Eo__16.\u003C\u003Ep__0.Target((CallSite) ProgramBuilderController.\u003C\u003Eo__16.\u003C\u003Ep__0, this.ViewBag, str4);
      return (ActionResult) this.View((object) list);
    }

    public ActionResult Set_Button_Add()
    {
      return this.Set_Button_Add((FormCollection) null);
    }

    [HttpPost]
    public ActionResult Set_Button_Add(FormCollection form)
    {
      RoadFlow.Platform.ProgramBuilderButtons programBuilderButtons = new RoadFlow.Platform.ProgramBuilderButtons();
      RoadFlow.Data.Model.ProgramBuilderButtons model = (RoadFlow.Data.Model.ProgramBuilderButtons) null;
      string empty1 = string.Empty;
      string empty2 = string.Empty;
      string str1 = this.Request.QueryString["bid"];
      string str2 = this.Request.QueryString["pid"];
      string str3 = this.Request.QueryString["maxSort"];
      if (str1.IsGuid())
        model = programBuilderButtons.Get(str1.ToGuid());
      if (form != null)
      {
        string str4 = this.Request.Form["buttonname"];
        string str5 = this.Request.Form["ClientScript"];
        string str6 = this.Request.Form["Sort"];
        string str7 = this.Request.Form["buttonid"];
        string str8 = this.Request.Form["Ico"];
        string str9 = this.Request.Form["showtype"];
        string str10 = this.Request.Form["IsValidateShow"];
        bool flag = false;
        if (model == null)
        {
          flag = true;
          model = new RoadFlow.Data.Model.ProgramBuilderButtons();
          model.ID = Guid.NewGuid();
          model.ProgramID = str2.ToGuid();
        }
        model.ButtonName = str4;
        model.ClientScript = str5;
        model.Sort = str6.ToInt(0);
        model.IsValidateShow = str10.ToInt(1);
        if (str7.IsGuid())
          model.ButtonID = new Guid?(str7.ToGuid());
        model.Ico = str8;
        model.ShowType = str9.ToInt(1);
        if (flag)
          programBuilderButtons.Add(model);
        else
          programBuilderButtons.Update(model);
        // ISSUE: reference to a compiler-generated field
        if (ProgramBuilderController.\u003C\u003Eo__18.\u003C\u003Ep__0 == null)
        {
          // ISSUE: reference to a compiler-generated field
          ProgramBuilderController.\u003C\u003Eo__18.\u003C\u003Ep__0 = CallSite<Func<CallSite, object, string, object>>.Create(Binder.SetMember(CSharpBinderFlags.None, "script", typeof (ProgramBuilderController), (IEnumerable<CSharpArgumentInfo>) new CSharpArgumentInfo[2]
          {
            CSharpArgumentInfo.Create(CSharpArgumentInfoFlags.None, (string) null),
            CSharpArgumentInfo.Create(CSharpArgumentInfoFlags.UseCompileTimeType, (string) null)
          }));
        }
        // ISSUE: reference to a compiler-generated field
        // ISSUE: reference to a compiler-generated field
        object obj = ProgramBuilderController.\u003C\u003Eo__18.\u003C\u003Ep__0.Target((CallSite) ProgramBuilderController.\u003C\u003Eo__18.\u003C\u003Ep__0, this.ViewBag, "alert('保存成功!');window.location='Set_Button" + this.Request.Url.Query + "';");
      }
      if (model == null)
      {
        model = new RoadFlow.Data.Model.ProgramBuilderButtons();
        model.Sort = str3.ToInt();
        model.ShowType = 1;
      }
      return (ActionResult) this.View((object) model);
    }

    public ActionResult Set_Validate()
    {
      return this.Set_Validate((FormCollection) null);
    }

    [HttpPost]
    public ActionResult Set_Validate(FormCollection form)
    {
      string str1 = this.Request.QueryString["pid"];
      RoadFlow.Platform.ProgramBuilderValidates builderValidates1 = new RoadFlow.Platform.ProgramBuilderValidates();
      List<RoadFlow.Data.Model.ProgramBuilderValidates> builderValidatesList1 = new List<RoadFlow.Data.Model.ProgramBuilderValidates>();
      List<RoadFlow.Data.Model.ProgramBuilderValidates> builderValidatesList2 = new List<RoadFlow.Data.Model.ProgramBuilderValidates>();
      List<Tuple<string, string, string>> tupleList = new List<Tuple<string, string, string>>();
      if (str1.IsGuid())
      {
        RoadFlow.Data.Model.ProgramBuilder programBuilder = new RoadFlow.Platform.ProgramBuilder().Get(str1.ToGuid());
        if (programBuilder != null && !programBuilder.FormID.IsNullOrEmpty() && programBuilder.FormID.IsGuid())
        {
          RoadFlow.Data.Model.AppLibrary appLibrary = new RoadFlow.Platform.AppLibrary().Get(programBuilder.FormID.ToGuid(), false);
          if (appLibrary != null && appLibrary.Code.IsGuid())
          {
            RoadFlow.Data.Model.WorkFlowForm workFlowForm = new RoadFlow.Platform.WorkFlowForm().Get(appLibrary.Code.ToGuid());
            if (workFlowForm != null)
            {
              JsonData jsonData1 = JsonMapper.ToObject(workFlowForm.Attribute);
              string str2 = jsonData1.ContainsKey("dbconn") ? jsonData1["dbconn"].ToString() : "";
              string str3 = jsonData1.ContainsKey("dbtable") ? jsonData1["dbtable"].ToString() : "";
              if (str2.IsGuid() && !str3.IsNullOrEmpty())
              {
                foreach (KeyValuePair<string, string> field in new RoadFlow.Platform.DBConnection().GetFields(str2.ToGuid(), str3))
                  tupleList.Add(new Tuple<string, string, string>(str3, field.Key, field.Value));
              }
              JsonData jsonData2 = JsonMapper.ToObject(workFlowForm.SubTableJson);
              if (jsonData2.IsArray)
              {
                foreach (JsonData jsonData3 in (IEnumerable) jsonData2)
                {
                  string str4 = jsonData3.ContainsKey("secondtable") ? jsonData3["secondtable"].ToString() : "";
                  if (jsonData3.ContainsKey("colnums"))
                  {
                    JsonData jsonData4 = jsonData3["colnums"];
                    if (jsonData4.IsArray)
                    {
                      foreach (JsonData jsonData5 in (IEnumerable) jsonData4)
                      {
                        string str5 = jsonData5.ContainsKey("fieldname") ? jsonData5["fieldname"].ToString() : "";
                        string str6 = jsonData5.ContainsKey("showname") ? jsonData5["showname"].ToString() : "";
                        if (!str5.IsNullOrEmpty())
                          tupleList.Add(new Tuple<string, string, string>(str4, str5, str6));
                      }
                    }
                  }
                }
              }
            }
          }
        }
      }
      List<RoadFlow.Data.Model.ProgramBuilderValidates> all = builderValidates1.GetAll(str1.ToGuid());
      foreach (Tuple<string, string, string> tuple in tupleList)
      {
        Tuple<string, string, string> filed = tuple;
        RoadFlow.Data.Model.ProgramBuilderValidates builderValidates2 = all.Find((Predicate<RoadFlow.Data.Model.ProgramBuilderValidates>) (p =>
        {
          if (p.TableName.Equals(filed.Item1, StringComparison.CurrentCultureIgnoreCase))
            return p.FieldName.Equals(filed.Item2, StringComparison.CurrentCultureIgnoreCase);
          return false;
        }));
        builderValidatesList1.Add(new RoadFlow.Data.Model.ProgramBuilderValidates()
        {
          ID = Guid.NewGuid(),
          ProgramID = str1.ToGuid(),
          TableName = filed.Item1,
          FieldName = filed.Item2,
          FieldNote = filed.Item3,
          Validate = builderValidates2 != null ? builderValidates2.Validate : 0
        });
      }
      if (form != null)
      {
        using (TransactionScope transactionScope = new TransactionScope())
        {
          builderValidates1.DeleteByProgramID(str1.ToGuid());
          foreach (RoadFlow.Data.Model.ProgramBuilderValidates model in builderValidatesList1)
          {
            model.Validate = this.Request.Form["valdate_" + model.TableName + "_" + model.FieldName].ToInt(0);
            builderValidates1.Add(model);
          }
          transactionScope.Complete();
        }
      }
      return (ActionResult) this.View((object) builderValidatesList1);
    }

    public ActionResult Set_Export()
    {
      return this.Set_Export((FormCollection) null);
    }

    [HttpPost]
    public ActionResult Set_Export(FormCollection form)
    {
      string empty1 = string.Empty;
      List<RoadFlow.Data.Model.ProgramBuilderExport> programBuilderExportList = new List<RoadFlow.Data.Model.ProgramBuilderExport>();
      string str1 = this.Request.QueryString["pid"];
      string empty2 = string.Empty;
      RoadFlow.Platform.ProgramBuilderExport programBuilderExport = new RoadFlow.Platform.ProgramBuilderExport();
      if (form != null && !this.Request.Form["delete"].IsNullOrEmpty())
      {
        string str2 = this.Request.Form["checkbox_app"] ?? "";
        char[] chArray = new char[1]{ ',' };
        foreach (string str3 in str2.Split(chArray))
        {
          if (str3.IsGuid())
            programBuilderExport.Delete(str3.ToGuid());
        }
      }
      List<RoadFlow.Data.Model.ProgramBuilderExport> all = programBuilderExport.GetAll(str1.ToGuid());
      string str4 = "&appid=" + this.Request.QueryString["appid"] + "&tabid=" + this.Request.QueryString["tabid"] + "&typeid=" + this.Request.QueryString["typeid"] + "&Name1=" + this.Request.QueryString["Name1"] + "&pid=" + this.Request.QueryString["pid"] + "&maxSort=" + (all.Count > 0 ? all.Max<RoadFlow.Data.Model.ProgramBuilderExport>((Func<RoadFlow.Data.Model.ProgramBuilderExport, int>) (p => p.Sort)).ToString() : "0");
      // ISSUE: reference to a compiler-generated field
      if (ProgramBuilderController.\u003C\u003Eo__22.\u003C\u003Ep__0 == null)
      {
        // ISSUE: reference to a compiler-generated field
        ProgramBuilderController.\u003C\u003Eo__22.\u003C\u003Ep__0 = CallSite<Func<CallSite, object, string, object>>.Create(Binder.SetMember(CSharpBinderFlags.None, "query", typeof (ProgramBuilderController), (IEnumerable<CSharpArgumentInfo>) new CSharpArgumentInfo[2]
        {
          CSharpArgumentInfo.Create(CSharpArgumentInfoFlags.None, (string) null),
          CSharpArgumentInfo.Create(CSharpArgumentInfoFlags.UseCompileTimeType, (string) null)
        }));
      }
      // ISSUE: reference to a compiler-generated field
      // ISSUE: reference to a compiler-generated field
      object obj = ProgramBuilderController.\u003C\u003Eo__22.\u003C\u003Ep__0.Target((CallSite) ProgramBuilderController.\u003C\u003Eo__22.\u003C\u003Ep__0, this.ViewBag, str4);
      return (ActionResult) this.View((object) all);
    }

    public ActionResult Set_Export_Add()
    {
      return this.Set_Export_Add((FormCollection) null);
    }

    [HttpPost]
    public ActionResult Set_Export_Add(FormCollection form)
    {
      RoadFlow.Data.Model.ProgramBuilderExport model = (RoadFlow.Data.Model.ProgramBuilderExport) null;
      RoadFlow.Platform.ProgramBuilderExport programBuilderExport1 = new RoadFlow.Platform.ProgramBuilderExport();
      RoadFlow.Platform.Dictionary dictionary = new RoadFlow.Platform.Dictionary();
      RoadFlow.Platform.ProgramBuilder programBuilder = new RoadFlow.Platform.ProgramBuilder();
      string str1 = this.Request.QueryString["pid"];
      string str2 = this.Request.QueryString["eid"];
      string str3 = this.Request.QueryString["maxSort"];
      string str4 = "";
      string str5 = "";
      string str6 = "";
      string str7 = "";
      // ISSUE: reference to a compiler-generated field
      if (ProgramBuilderController.\u003C\u003Eo__24.\u003C\u003Ep__0 == null)
      {
        // ISSUE: reference to a compiler-generated field
        ProgramBuilderController.\u003C\u003Eo__24.\u003C\u003Ep__0 = CallSite<Func<CallSite, object, string, object>>.Create(Binder.SetMember(CSharpBinderFlags.None, "sort", typeof (ProgramBuilderController), (IEnumerable<CSharpArgumentInfo>) new CSharpArgumentInfo[2]
        {
          CSharpArgumentInfo.Create(CSharpArgumentInfoFlags.None, (string) null),
          CSharpArgumentInfo.Create(CSharpArgumentInfoFlags.UseCompileTimeType, (string) null)
        }));
      }
      // ISSUE: reference to a compiler-generated field
      // ISSUE: reference to a compiler-generated field
      object obj1 = ProgramBuilderController.\u003C\u003Eo__24.\u003C\u003Ep__0.Target((CallSite) ProgramBuilderController.\u003C\u003Eo__24.\u003C\u003Ep__0, this.ViewBag, (str3.ToInt() + 5).ToString());
      int? nullable1;
      if (str2.IsGuid())
      {
        model = programBuilderExport1.Get(str2.ToGuid());
        if (model != null)
        {
          str4 = model.Field;
          str5 = model.ShowType.ToString();
          int num = model.Align;
          str6 = num.ToString();
          // ISSUE: reference to a compiler-generated field
          if (ProgramBuilderController.\u003C\u003Eo__24.\u003C\u003Ep__1 == null)
          {
            // ISSUE: reference to a compiler-generated field
            ProgramBuilderController.\u003C\u003Eo__24.\u003C\u003Ep__1 = CallSite<Func<CallSite, object, string, object>>.Create(Binder.SetMember(CSharpBinderFlags.None, "sort", typeof (ProgramBuilderController), (IEnumerable<CSharpArgumentInfo>) new CSharpArgumentInfo[2]
            {
              CSharpArgumentInfo.Create(CSharpArgumentInfoFlags.None, (string) null),
              CSharpArgumentInfo.Create(CSharpArgumentInfoFlags.UseCompileTimeType, (string) null)
            }));
          }
          // ISSUE: reference to a compiler-generated field
          Func<CallSite, object, string, object> target = ProgramBuilderController.\u003C\u003Eo__24.\u003C\u003Ep__1.Target;
          // ISSUE: reference to a compiler-generated field
          CallSite<Func<CallSite, object, string, object>> p1 = ProgramBuilderController.\u003C\u003Eo__24.\u003C\u003Ep__1;
          object viewBag = this.ViewBag;
          num = model.Sort;
          string str8 = num.ToString();
          object obj2 = target((CallSite) p1, viewBag, str8);
          nullable1 = model.DataType;
          str7 = nullable1.ToString();
        }
      }
      // ISSUE: reference to a compiler-generated field
      if (ProgramBuilderController.\u003C\u003Eo__24.\u003C\u003Ep__2 == null)
      {
        // ISSUE: reference to a compiler-generated field
        ProgramBuilderController.\u003C\u003Eo__24.\u003C\u003Ep__2 = CallSite<Func<CallSite, object, string, object>>.Create(Binder.SetMember(CSharpBinderFlags.None, "ShowTypeOptions", typeof (ProgramBuilderController), (IEnumerable<CSharpArgumentInfo>) new CSharpArgumentInfo[2]
        {
          CSharpArgumentInfo.Create(CSharpArgumentInfoFlags.None, (string) null),
          CSharpArgumentInfo.Create(CSharpArgumentInfoFlags.UseCompileTimeType, (string) null)
        }));
      }
      // ISSUE: reference to a compiler-generated field
      // ISSUE: reference to a compiler-generated field
      object obj3 = ProgramBuilderController.\u003C\u003Eo__24.\u003C\u003Ep__2.Target((CallSite) ProgramBuilderController.\u003C\u003Eo__24.\u003C\u003Ep__2, this.ViewBag, dictionary.GetOptionsByCode("programbuilder_showtype", RoadFlow.Platform.Dictionary.OptionValueField.Value, str5, "", true));
      // ISSUE: reference to a compiler-generated field
      if (ProgramBuilderController.\u003C\u003Eo__24.\u003C\u003Ep__3 == null)
      {
        // ISSUE: reference to a compiler-generated field
        ProgramBuilderController.\u003C\u003Eo__24.\u003C\u003Ep__3 = CallSite<Func<CallSite, object, string, object>>.Create(Binder.SetMember(CSharpBinderFlags.None, "AlignOptions", typeof (ProgramBuilderController), (IEnumerable<CSharpArgumentInfo>) new CSharpArgumentInfo[2]
        {
          CSharpArgumentInfo.Create(CSharpArgumentInfoFlags.None, (string) null),
          CSharpArgumentInfo.Create(CSharpArgumentInfoFlags.UseCompileTimeType, (string) null)
        }));
      }
      // ISSUE: reference to a compiler-generated field
      // ISSUE: reference to a compiler-generated field
      object obj4 = ProgramBuilderController.\u003C\u003Eo__24.\u003C\u003Ep__3.Target((CallSite) ProgramBuilderController.\u003C\u003Eo__24.\u003C\u003Ep__3, this.ViewBag, dictionary.GetOptionsByCode("programbuilder_align", RoadFlow.Platform.Dictionary.OptionValueField.Value, str6, "", true));
      // ISSUE: reference to a compiler-generated field
      if (ProgramBuilderController.\u003C\u003Eo__24.\u003C\u003Ep__4 == null)
      {
        // ISSUE: reference to a compiler-generated field
        ProgramBuilderController.\u003C\u003Eo__24.\u003C\u003Ep__4 = CallSite<Func<CallSite, object, string, object>>.Create(Binder.SetMember(CSharpBinderFlags.None, "FieldOptions", typeof (ProgramBuilderController), (IEnumerable<CSharpArgumentInfo>) new CSharpArgumentInfo[2]
        {
          CSharpArgumentInfo.Create(CSharpArgumentInfoFlags.None, (string) null),
          CSharpArgumentInfo.Create(CSharpArgumentInfoFlags.UseCompileTimeType, (string) null)
        }));
      }
      // ISSUE: reference to a compiler-generated field
      // ISSUE: reference to a compiler-generated field
      object obj5 = ProgramBuilderController.\u003C\u003Eo__24.\u003C\u003Ep__4.Target((CallSite) ProgramBuilderController.\u003C\u003Eo__24.\u003C\u003Ep__4, this.ViewBag, programBuilder.GetFieldsOptions(str1.ToGuid(), str4));
      // ISSUE: reference to a compiler-generated field
      if (ProgramBuilderController.\u003C\u003Eo__24.\u003C\u003Ep__5 == null)
      {
        // ISSUE: reference to a compiler-generated field
        ProgramBuilderController.\u003C\u003Eo__24.\u003C\u003Ep__5 = CallSite<Func<CallSite, object, string, object>>.Create(Binder.SetMember(CSharpBinderFlags.None, "DataTypeOptions", typeof (ProgramBuilderController), (IEnumerable<CSharpArgumentInfo>) new CSharpArgumentInfo[2]
        {
          CSharpArgumentInfo.Create(CSharpArgumentInfoFlags.None, (string) null),
          CSharpArgumentInfo.Create(CSharpArgumentInfoFlags.UseCompileTimeType, (string) null)
        }));
      }
      // ISSUE: reference to a compiler-generated field
      // ISSUE: reference to a compiler-generated field
      object obj6 = ProgramBuilderController.\u003C\u003Eo__24.\u003C\u003Ep__5.Target((CallSite) ProgramBuilderController.\u003C\u003Eo__24.\u003C\u003Ep__5, this.ViewBag, programBuilderExport1.GetDataTypeOptions(str7));
      if (form != null)
      {
        string str8 = this.Request.Form["Field"];
        string str9 = this.Request.Form["ShowTitle"];
        string str10 = this.Request.Form["ShowType"];
        string str11 = this.Request.Form["ShowFormat"];
        string str12 = this.Request.Form["Align"];
        string str13 = this.Request.Form["Width"];
        string str14 = this.Request.Form["CustomString"];
        string str15 = this.Request.Form["Sort"];
        string str16 = this.Request.Form["DataType"];
        bool flag = false;
        if (model == null)
        {
          flag = true;
          model = new RoadFlow.Data.Model.ProgramBuilderExport();
          model.ID = Guid.NewGuid();
          model.ProgramID = str1.ToGuid();
        }
        model.Align = "left" == str12 ? 0 : ("center" == str12 ? 1 : 2);
        model.CustomString = str14;
        model.Field = str8;
        model.ShowFormat = str11;
        model.ShowTitle = str9;
        model.ShowType = new int?(str10.ToInt());
        model.Sort = str15.ToInt();
        if (str13.IsInt())
        {
          model.Width = new int?(str13.ToInt());
        }
        else
        {
          RoadFlow.Data.Model.ProgramBuilderExport programBuilderExport2 = model;
          nullable1 = new int?();
          int? nullable2 = nullable1;
          programBuilderExport2.Width = nullable2;
        }
        model.DataType = new int?(str16.ToInt(0));
        if (flag)
          programBuilderExport1.Add(model);
        else
          programBuilderExport1.Update(model);
        // ISSUE: reference to a compiler-generated field
        if (ProgramBuilderController.\u003C\u003Eo__24.\u003C\u003Ep__6 == null)
        {
          // ISSUE: reference to a compiler-generated field
          ProgramBuilderController.\u003C\u003Eo__24.\u003C\u003Ep__6 = CallSite<Func<CallSite, object, string, object>>.Create(Binder.SetMember(CSharpBinderFlags.None, "script", typeof (ProgramBuilderController), (IEnumerable<CSharpArgumentInfo>) new CSharpArgumentInfo[2]
          {
            CSharpArgumentInfo.Create(CSharpArgumentInfoFlags.None, (string) null),
            CSharpArgumentInfo.Create(CSharpArgumentInfoFlags.UseCompileTimeType, (string) null)
          }));
        }
        // ISSUE: reference to a compiler-generated field
        // ISSUE: reference to a compiler-generated field
        object obj2 = ProgramBuilderController.\u003C\u003Eo__24.\u003C\u003Ep__6.Target((CallSite) ProgramBuilderController.\u003C\u003Eo__24.\u003C\u003Ep__6, this.ViewBag, "alert('保存成功!');window.location='Set_Export" + this.Request.Url.Query + "';");
      }
      if (model == null)
        model = new RoadFlow.Data.Model.ProgramBuilderExport();
      return (ActionResult) this.View((object) model);
    }

    public string Set_Export_CopyForList()
    {
      Guid guid = this.Request.QueryString["pid"].ToGuid();
      if (guid.IsEmptyGuid())
        return "参数错误";
      List<RoadFlow.Data.Model.ProgramBuilderFields> all = new RoadFlow.Platform.ProgramBuilderFields().GetAll(guid);
      RoadFlow.Platform.ProgramBuilderExport programBuilderExport1 = new RoadFlow.Platform.ProgramBuilderExport();
      foreach (RoadFlow.Data.Model.ProgramBuilderExport programBuilderExport2 in programBuilderExport1.GetAll(guid))
        programBuilderExport1.Delete(programBuilderExport2.ID);
      foreach (RoadFlow.Data.Model.ProgramBuilderFields programBuilderFields in all)
      {
        if (!programBuilderFields.Field.IsNullOrEmpty())
          programBuilderExport1.Add(new RoadFlow.Data.Model.ProgramBuilderExport()
          {
            Align = "left" == programBuilderFields.Align ? 0 : ("center" == programBuilderFields.Align ? 1 : 2),
            CustomString = programBuilderFields.CustomString,
            DataType = new int?(0),
            Field = programBuilderFields.Field,
            ID = Guid.NewGuid(),
            ProgramID = guid,
            ShowFormat = programBuilderFields.ShowFormat,
            ShowTitle = programBuilderFields.ShowTitle,
            ShowType = new int?(programBuilderFields.ShowType),
            Sort = programBuilderFields.Sort
          });
      }
      return "复制成功";
    }

    [MyAttribute(CheckApp = false, CheckUrl = false)]
    public string GetFieldsOptions()
    {
      RoadFlow.Data.Model.AppLibrary appLibrary = new RoadFlow.Platform.AppLibrary().Get(this.Request["applibaryid"].ToGuid(), false);
      if (appLibrary == null || !appLibrary.Code.IsGuid())
        return "";
      return new RoadFlow.Platform.ProgramBuilder().GetFieldsOptions(appLibrary.Code.ToGuid(), "");
    }

    public string Publish()
    {
      string str = this.Request.QueryString["pid"];
      return !str.IsGuid() || !new RoadFlow.Platform.ProgramBuilder().Publish(str.ToGuid(), true) ? "成功失败!" : "成功发布!";
    }

    [MyAttribute(CheckApp = false, CheckLogin = false, CheckUrl = false)]
    public ActionResult Run()
    {
      return this.Run((FormCollection) null);
    }

    [HttpPost]
    [MyAttribute(CheckApp = false, CheckLogin = false, CheckUrl = false)]
    public ActionResult Run(FormCollection form)
    {
      if (!WebMvc.Common.Tools.CheckLogin(true) && !RoadFlow.Platform.WeiXin.Organize.CheckLogin())
      {
        this.Response.End();
        return (ActionResult) null;
      }
      ProgramBuilderCache programBuilderCache = (ProgramBuilderCache) null;
      RoadFlow.Platform.ProgramBuilder programBuilder = new RoadFlow.Platform.ProgramBuilder();
      RoadFlow.Platform.ProgramBuilderQuerys programBuilderQuerys = new RoadFlow.Platform.ProgramBuilderQuerys();
      string empty1 = string.Empty;
      RoadFlow.Platform.DBConnection dbConnection1 = new RoadFlow.Platform.DBConnection();
      RoadFlow.Platform.Dictionary dictionary = new RoadFlow.Platform.Dictionary();
      RoadFlow.Platform.Organize organize = new RoadFlow.Platform.Organize();
      string empty2 = string.Empty;
      string empty3 = string.Empty;
      string str1 = this.Request.QueryString["programid"];
      Guid test;
      if (str1.IsGuid(out test))
        programBuilderCache = programBuilder.GetSet(test);
      if (programBuilderCache == null)
      {
        this.Response.Write("未找到程序设置!");
        this.Response.End();
        return (ActionResult) null;
      }
      if (form != null && !this.Request.Form["searchbutton"].IsNullOrEmpty())
      {
        foreach (RoadFlow.Data.Model.ProgramBuilderQuerys query in programBuilderCache.Querys)
        {
          int inputType = query.InputType;
          int[] numArray = new int[2]{ 3, 5 };
          query.Value = !inputType.In(numArray) ? this.Request.Form[query.ControlName].Trim1() : this.Request.Form[query.ControlName + "_start"].Trim1() + "," + this.Request.Form[query.ControlName + "_end"].Trim1();
        }
      }
      else
      {
        foreach (RoadFlow.Data.Model.ProgramBuilderQuerys query in programBuilderCache.Querys)
        {
          int inputType = query.InputType;
          int[] numArray = new int[2]{ 3, 5 };
          query.Value = !inputType.In(numArray) ? this.Request.QueryString[query.ControlName].Trim1() : this.Request.QueryString[query.ControlName + "_start"].Trim1() + "," + this.Request.QueryString[query.ControlName + "_end"].Trim1();
        }
      }
      string str2 = "&programid=" + str1 + "&appid=" + this.Request.QueryString["appid"] + "&tabid=" + this.Request.QueryString["tabid"];
      foreach (RoadFlow.Data.Model.ProgramBuilderQuerys query in programBuilderCache.Querys)
      {
        if (query.InputType.In(3, 5))
        {
          string[] strArray = query.Value.Split(',');
          str2 = str2 + "&" + query.ControlName + "_start=" + strArray[0] + "&" + query.ControlName + "_end=" + strArray[1];
        }
        else
          str2 = str2 + "&" + query.ControlName + "=" + query.Value;
      }
      string str3 = (WebMvc.Common.Tools.BaseUrl + "/ProgramBuilder/Run?1=1" + str2).UrlEncode();
      StringBuilder stringBuilder = new StringBuilder(programBuilderCache.Program.SQL);
      List<IDbDataParameter> parList1 = new List<IDbDataParameter>();
      RoadFlow.Data.Model.DBConnection dbConnection2 = new RoadFlow.Platform.DBConnection().Get(programBuilderCache.Program.DBConnID, true);
      if (dbConnection2 == null)
      {
        this.Response.Write("未找到数据连接!");
        this.Response.End();
        return (ActionResult) null;
      }
      string str4 = string.Empty;
      string type = dbConnection2.Type;
      if (!(type == "SqlServer") && !(type == "MySql"))
      {
        if (type == "Oracle")
          str4 = ":";
      }
      else
        str4 = "@";
      foreach (RoadFlow.Data.Model.ProgramBuilderQuerys query in programBuilderCache.Querys)
      {
        if (!query.Value.IsNullOrEmpty())
        {
          string str5 = query.Value.ReplaceSelectSql();
          string operators = query.Operators;
          if (query.InputType == 7)
          {
            int? isQueryUsers = query.IsQueryUsers;
            int num = 1;
            if ((isQueryUsers.GetValueOrDefault() == num ? (isQueryUsers.HasValue ? 1 : 0) : 0) != 0)
              str5 = new RoadFlow.Platform.Organize().GetAllUsersIdList(str5).ToArray().Join1<Guid>(",");
          }
          if (!(operators == "%LIKE%"))
          {
            if (!(operators == "LIKE%"))
            {
              if (!(operators == "%LIKE"))
              {
                if (!(operators == "IN"))
                {
                  if (operators == "NOT IN")
                    stringBuilder.AppendFormat(" AND {0} NOT IN({1})", (object) query.Field, (object) RoadFlow.Utility.Tools.GetSqlInString(str5, true, ","));
                  else if (query.InputType.In(3, 5))
                  {
                    string[] strArray = str5.Split(',');
                    if (strArray[0].IsDateTime())
                    {
                      strArray[0] = query.InputType == 3 ? strArray[0].ToDateString() : strArray[0].ToDateTimeString();
                      stringBuilder.AppendFormat(" AND {0}{1}{2}{3}_start", (object) query.Field, (object) operators, (object) str4, (object) query.ControlName);
                      parList1.Add((IDbDataParameter) new SqlParameter(str4 + query.ControlName + "_start", (object) strArray[0]));
                    }
                    if (strArray[1].IsDateTime())
                    {
                      strArray[1] = query.InputType == 3 ? strArray[1].ToDateTime().AddDays(1.0).ToDateString() : strArray[1].ToDateTimeString();
                      stringBuilder.AppendFormat(" AND {0}{1}{2}{3}_end", (object) query.Field, operators == ">" ? (object) "<" : (object) "<=", (object) str4, (object) query.ControlName);
                      parList1.Add((IDbDataParameter) new SqlParameter(str4 + query.ControlName + "_end", (object) strArray[1]));
                    }
                  }
                  else
                  {
                    stringBuilder.AppendFormat(" AND {0}{1}{2}{3}", (object) query.Field, (object) operators, (object) str4, (object) query.ControlName);
                    parList1.Add((IDbDataParameter) new SqlParameter(str4 + query.ControlName, (object) str5));
                  }
                }
                else
                  stringBuilder.AppendFormat(" AND {0} IN({1})", (object) query.Field, (object) RoadFlow.Utility.Tools.GetSqlInString(str5, true, ","));
              }
              else
                stringBuilder.AppendFormat(" AND {0} LIKE '%{1}'", (object) query.Field, (object) str5);
            }
            else
              stringBuilder.AppendFormat(" AND {0} LIKE '{1}%'", (object) query.Field, (object) str5);
          }
          else
            stringBuilder.AppendFormat(" AND {0} LIKE '%{1}%'", (object) query.Field, (object) str5);
        }
      }
      string querySql = stringBuilder.ToString().FilterWildcard(RoadFlow.Platform.Users.CurrentUserID.ToString());
      RoadFlow.Platform.DBConnection dbConnection3 = dbConnection1;
      RoadFlow.Data.Model.DBConnection dbconn = dbConnection2;
      string sql = querySql;
      string str6;
      ref string local = ref str6;
      string query1 = str2;
      List<IDbDataParameter> parList2 = parList1;
      int? isPager = programBuilderCache.Program.IsPager;
      int pageSize;
      if (isPager.HasValue)
      {
        isPager = programBuilderCache.Program.IsPager;
        if (isPager.Value == 0)
        {
          pageSize = -1;
          goto label_58;
        }
      }
      pageSize = 0;
label_58:
      DataTable dataTable = dbConnection3.GetDataTable(dbconn, sql, out local, query1, parList2, pageSize);
      // ISSUE: reference to a compiler-generated field
      if (ProgramBuilderController.\u003C\u003Eo__29.\u003C\u003Ep__0 == null)
      {
        // ISSUE: reference to a compiler-generated field
        ProgramBuilderController.\u003C\u003Eo__29.\u003C\u003Ep__0 = CallSite<Func<CallSite, object, string, object>>.Create(Binder.SetMember(CSharpBinderFlags.None, "pager", typeof (ProgramBuilderController), (IEnumerable<CSharpArgumentInfo>) new CSharpArgumentInfo[2]
        {
          CSharpArgumentInfo.Create(CSharpArgumentInfoFlags.None, (string) null),
          CSharpArgumentInfo.Create(CSharpArgumentInfoFlags.UseCompileTimeType, (string) null)
        }));
      }
      // ISSUE: reference to a compiler-generated field
      // ISSUE: reference to a compiler-generated field
      object obj1 = ProgramBuilderController.\u003C\u003Eo__29.\u003C\u003Ep__0.Target((CallSite) ProgramBuilderController.\u003C\u003Eo__29.\u003C\u003Ep__0, this.ViewBag, str6);
      // ISSUE: reference to a compiler-generated field
      if (ProgramBuilderController.\u003C\u003Eo__29.\u003C\u003Ep__1 == null)
      {
        // ISSUE: reference to a compiler-generated field
        ProgramBuilderController.\u003C\u003Eo__29.\u003C\u003Ep__1 = CallSite<Func<CallSite, object, ProgramBuilderCache, object>>.Create(Binder.SetMember(CSharpBinderFlags.None, "PBModel", typeof (ProgramBuilderController), (IEnumerable<CSharpArgumentInfo>) new CSharpArgumentInfo[2]
        {
          CSharpArgumentInfo.Create(CSharpArgumentInfoFlags.None, (string) null),
          CSharpArgumentInfo.Create(CSharpArgumentInfoFlags.UseCompileTimeType, (string) null)
        }));
      }
      // ISSUE: reference to a compiler-generated field
      // ISSUE: reference to a compiler-generated field
      object obj2 = ProgramBuilderController.\u003C\u003Eo__29.\u003C\u003Ep__1.Target((CallSite) ProgramBuilderController.\u003C\u003Eo__29.\u003C\u003Ep__1, this.ViewBag, programBuilderCache);
      // ISSUE: reference to a compiler-generated field
      if (ProgramBuilderController.\u003C\u003Eo__29.\u003C\u003Ep__2 == null)
      {
        // ISSUE: reference to a compiler-generated field
        ProgramBuilderController.\u003C\u003Eo__29.\u003C\u003Ep__2 = CallSite<Func<CallSite, object, string, object>>.Create(Binder.SetMember(CSharpBinderFlags.None, "query", typeof (ProgramBuilderController), (IEnumerable<CSharpArgumentInfo>) new CSharpArgumentInfo[2]
        {
          CSharpArgumentInfo.Create(CSharpArgumentInfoFlags.None, (string) null),
          CSharpArgumentInfo.Create(CSharpArgumentInfoFlags.UseCompileTimeType, (string) null)
        }));
      }
      // ISSUE: reference to a compiler-generated field
      // ISSUE: reference to a compiler-generated field
      object obj3 = ProgramBuilderController.\u003C\u003Eo__29.\u003C\u003Ep__2.Target((CallSite) ProgramBuilderController.\u003C\u003Eo__29.\u003C\u003Ep__2, this.ViewBag, str2);
      // ISSUE: reference to a compiler-generated field
      if (ProgramBuilderController.\u003C\u003Eo__29.\u003C\u003Ep__3 == null)
      {
        // ISSUE: reference to a compiler-generated field
        ProgramBuilderController.\u003C\u003Eo__29.\u003C\u003Ep__3 = CallSite<Func<CallSite, object, string, object>>.Create(Binder.SetMember(CSharpBinderFlags.None, "prevurl", typeof (ProgramBuilderController), (IEnumerable<CSharpArgumentInfo>) new CSharpArgumentInfo[2]
        {
          CSharpArgumentInfo.Create(CSharpArgumentInfoFlags.None, (string) null),
          CSharpArgumentInfo.Create(CSharpArgumentInfoFlags.UseCompileTimeType, (string) null)
        }));
      }
      // ISSUE: reference to a compiler-generated field
      // ISSUE: reference to a compiler-generated field
      object obj4 = ProgramBuilderController.\u003C\u003Eo__29.\u003C\u003Ep__3.Target((CallSite) ProgramBuilderController.\u003C\u003Eo__29.\u003C\u003Ep__3, this.ViewBag, str3);
      programBuilder.AddToExportCache(programBuilderCache.Program.ID, dbConnection2.ID, querySql, parList1);
      if (dataTable != null)
        return (ActionResult) this.View((object) dataTable);
      this.Response.Write("查询错误!");
      return (ActionResult) this.View((object) dataTable);
    }

    [MyAttribute(CheckApp = false)]
    public ActionResult RunDelete()
    {
      string str1 = this.Request.QueryString["secondtableeditform"];
      string str2 = this.Request.QueryString["instanceid"] ?? "";
      RoadFlow.Data.Model.AppLibrary appLibrary = new RoadFlow.Platform.AppLibrary().Get(str1.ToGuid(), false);
      if (appLibrary != null)
      {
        RoadFlow.Data.Model.WorkFlowForm workFlowForm = new RoadFlow.Platform.WorkFlowForm().Get(appLibrary.Code.ToGuid());
        if (workFlowForm != null)
        {
          RoadFlow.Platform.DBConnection dbConnection = new RoadFlow.Platform.DBConnection();
          JsonData jsonData = JsonMapper.ToObject(workFlowForm.Attribute);
          string str3 = jsonData.ContainsKey("dbconn") ? jsonData["dbconn"].ToString() : "";
          string str4 = jsonData.ContainsKey("dbtable") ? jsonData["dbtable"].ToString() : "";
          string str5 = jsonData.ContainsKey("dbtablepk") ? jsonData["dbtablepk"].ToString() : "";
          if (str3.IsGuid() && !str4.IsNullOrEmpty() && !str5.IsNullOrEmpty())
          {
            string str6 = str2 ?? "";
            char[] chArray = new char[1]{ ',' };
            foreach (string str7 in str6.Split(chArray))
            {
              DataTable dataTable = dbConnection.GetDataTable(str3, str4, str5, str7, "");
              if (dataTable.Rows.Count > 0)
              {
                dbConnection.DeleteData(str3.ToGuid(), str4, str5, str7);
                RoadFlow.Platform.Log.Add("删除了数据(生成程序)(" + str4 + ")", "连接ID:" + str3 + ",表名:" + str4 + ",主键:" + str7, RoadFlow.Platform.Log.Types.其它分类, dataTable.ToJsonString(), "", (RoadFlow.Data.Model.Users) null);
              }
            }
          }
        }
      }
      // ISSUE: reference to a compiler-generated field
      if (ProgramBuilderController.\u003C\u003Eo__30.\u003C\u003Ep__0 == null)
      {
        // ISSUE: reference to a compiler-generated field
        ProgramBuilderController.\u003C\u003Eo__30.\u003C\u003Ep__0 = CallSite<Func<CallSite, object, string, object>>.Create(Binder.SetMember(CSharpBinderFlags.None, "script", typeof (ProgramBuilderController), (IEnumerable<CSharpArgumentInfo>) new CSharpArgumentInfo[2]
        {
          CSharpArgumentInfo.Create(CSharpArgumentInfoFlags.None, (string) null),
          CSharpArgumentInfo.Create(CSharpArgumentInfoFlags.UseCompileTimeType, (string) null)
        }));
      }
      // ISSUE: reference to a compiler-generated field
      // ISSUE: reference to a compiler-generated field
      object obj = ProgramBuilderController.\u003C\u003Eo__30.\u003C\u003Ep__0.Target((CallSite) ProgramBuilderController.\u003C\u003Eo__30.\u003C\u003Ep__0, this.ViewBag, "alert('删除成功!');window.location='" + this.Request.QueryString["prevurl"] + "'");
      return (ActionResult) this.View();
    }

    [MyAttribute(CheckApp = false)]
    public ActionResult OutToExcel()
    {
      return (ActionResult) this.View();
    }

    [MyAttribute(CheckApp = false)]
    public ActionResult InFromExcel()
    {
      return this.InFromExcel((FormCollection) null);
    }

    [HttpPost]
    [MyAttribute(CheckApp = false)]
    [ValidateAntiForgeryToken]
    public ActionResult InFromExcel(FormCollection coll)
    {
      string str1 = this.Request.QueryString["programid"];
      RoadFlow.Data.Model.ProgramBuilder programBuilder = new RoadFlow.Platform.ProgramBuilder().Get(str1.ToGuid());
      RoadFlow.Platform.DBConnection dbConnection = new RoadFlow.Platform.DBConnection();
      // ISSUE: reference to a compiler-generated field
      if (ProgramBuilderController.\u003C\u003Eo__33.\u003C\u003Ep__0 == null)
      {
        // ISSUE: reference to a compiler-generated field
        ProgramBuilderController.\u003C\u003Eo__33.\u003C\u003Ep__0 = CallSite<Func<CallSite, object, string, object>>.Create(Binder.SetMember(CSharpBinderFlags.None, "TableOptions", typeof (ProgramBuilderController), (IEnumerable<CSharpArgumentInfo>) new CSharpArgumentInfo[2]
        {
          CSharpArgumentInfo.Create(CSharpArgumentInfoFlags.None, (string) null),
          CSharpArgumentInfo.Create(CSharpArgumentInfoFlags.UseCompileTimeType, (string) null)
        }));
      }
      // ISSUE: reference to a compiler-generated field
      // ISSUE: reference to a compiler-generated field
      object obj1 = ProgramBuilderController.\u003C\u003Eo__33.\u003C\u003Ep__0.Target((CallSite) ProgramBuilderController.\u003C\u003Eo__33.\u003C\u003Ep__0, this.ViewBag, dbConnection.GetAllTableOptions(programBuilder.DBConnID, ""));
      // ISSUE: reference to a compiler-generated field
      if (ProgramBuilderController.\u003C\u003Eo__33.\u003C\u003Ep__1 == null)
      {
        // ISSUE: reference to a compiler-generated field
        ProgramBuilderController.\u003C\u003Eo__33.\u003C\u003Ep__1 = CallSite<Func<CallSite, object, string, object>>.Create(Binder.SetMember(CSharpBinderFlags.None, "ConnID", typeof (ProgramBuilderController), (IEnumerable<CSharpArgumentInfo>) new CSharpArgumentInfo[2]
        {
          CSharpArgumentInfo.Create(CSharpArgumentInfoFlags.None, (string) null),
          CSharpArgumentInfo.Create(CSharpArgumentInfoFlags.UseCompileTimeType, (string) null)
        }));
      }
      // ISSUE: reference to a compiler-generated field
      // ISSUE: reference to a compiler-generated field
      object obj2 = ProgramBuilderController.\u003C\u003Eo__33.\u003C\u003Ep__1.Target((CallSite) ProgramBuilderController.\u003C\u003Eo__33.\u003C\u003Ep__1, this.ViewBag, programBuilder.DBConnID.ToString());
      // ISSUE: reference to a compiler-generated field
      if (ProgramBuilderController.\u003C\u003Eo__33.\u003C\u003Ep__2 == null)
      {
        // ISSUE: reference to a compiler-generated field
        ProgramBuilderController.\u003C\u003Eo__33.\u003C\u003Ep__2 = CallSite<Func<CallSite, object, string, object>>.Create(Binder.SetMember(CSharpBinderFlags.None, "TableName", typeof (ProgramBuilderController), (IEnumerable<CSharpArgumentInfo>) new CSharpArgumentInfo[2]
        {
          CSharpArgumentInfo.Create(CSharpArgumentInfoFlags.None, (string) null),
          CSharpArgumentInfo.Create(CSharpArgumentInfoFlags.UseCompileTimeType, (string) null)
        }));
      }
      // ISSUE: reference to a compiler-generated field
      // ISSUE: reference to a compiler-generated field
      object obj3 = ProgramBuilderController.\u003C\u003Eo__33.\u003C\u003Ep__2.Target((CallSite) ProgramBuilderController.\u003C\u003Eo__33.\u003C\u003Ep__2, this.ViewBag, programBuilder.TableName);
      // ISSUE: reference to a compiler-generated field
      if (ProgramBuilderController.\u003C\u003Eo__33.\u003C\u003Ep__3 == null)
      {
        // ISSUE: reference to a compiler-generated field
        ProgramBuilderController.\u003C\u003Eo__33.\u003C\u003Ep__3 = CallSite<Func<CallSite, object, string, object>>.Create(Binder.SetMember(CSharpBinderFlags.None, "NumberFiled", typeof (ProgramBuilderController), (IEnumerable<CSharpArgumentInfo>) new CSharpArgumentInfo[2]
        {
          CSharpArgumentInfo.Create(CSharpArgumentInfoFlags.None, (string) null),
          CSharpArgumentInfo.Create(CSharpArgumentInfoFlags.UseCompileTimeType, (string) null)
        }));
      }
      // ISSUE: reference to a compiler-generated field
      // ISSUE: reference to a compiler-generated field
      object obj4 = ProgramBuilderController.\u003C\u003Eo__33.\u003C\u003Ep__3.Target((CallSite) ProgramBuilderController.\u003C\u003Eo__33.\u003C\u003Ep__3, this.ViewBag, programBuilder.InDataNumberFiledName);
      if (coll != null)
      {
        HttpPostedFileBase file = this.Request.Files["excel"];
        if (file != null && !file.FileName.IsNullOrEmpty())
        {
          string numberFiled = this.Request.Form["NumberFiled"];
          string table = this.Request.Form["TableName"];
          string str2 = this.Server.MapPath(this.Url.Content("~/Content/UploadFiles/ProgramInExcel/" + str1 + "/" + Guid.NewGuid().ToString()));
          if (!Directory.Exists(str2))
            Directory.CreateDirectory(str2);
          string str3 = Path.Combine(str2, file.FileName);
          file.SaveAs(str3);
          string msg;
          int num = new RoadFlow.Platform.ProgramBuilder().InDataFormExcel(str1.ToGuid(), table, str3, out msg, numberFiled);
          // ISSUE: reference to a compiler-generated field
          if (ProgramBuilderController.\u003C\u003Eo__33.\u003C\u003Ep__4 == null)
          {
            // ISSUE: reference to a compiler-generated field
            ProgramBuilderController.\u003C\u003Eo__33.\u003C\u003Ep__4 = CallSite<Func<CallSite, object, string, object>>.Create(Binder.SetMember(CSharpBinderFlags.None, "script", typeof (ProgramBuilderController), (IEnumerable<CSharpArgumentInfo>) new CSharpArgumentInfo[2]
            {
              CSharpArgumentInfo.Create(CSharpArgumentInfoFlags.None, (string) null),
              CSharpArgumentInfo.Create(CSharpArgumentInfoFlags.UseCompileTimeType, (string) null)
            }));
          }
          // ISSUE: reference to a compiler-generated field
          // ISSUE: reference to a compiler-generated field
          object obj5 = ProgramBuilderController.\u003C\u003Eo__33.\u003C\u003Ep__4.Target((CallSite) ProgramBuilderController.\u003C\u003Eo__33.\u003C\u003Ep__4, this.ViewBag, "alert('" + (msg.IsNullOrEmpty() ? "本次共导入了" + num.ToString() + "条数据!" : msg) + "');new RoadUI.Window().close();");
        }
        else
        {
          // ISSUE: reference to a compiler-generated field
          if (ProgramBuilderController.\u003C\u003Eo__33.\u003C\u003Ep__5 == null)
          {
            // ISSUE: reference to a compiler-generated field
            ProgramBuilderController.\u003C\u003Eo__33.\u003C\u003Ep__5 = CallSite<Func<CallSite, object, string, object>>.Create(Binder.SetMember(CSharpBinderFlags.None, "script", typeof (ProgramBuilderController), (IEnumerable<CSharpArgumentInfo>) new CSharpArgumentInfo[2]
            {
              CSharpArgumentInfo.Create(CSharpArgumentInfoFlags.None, (string) null),
              CSharpArgumentInfo.Create(CSharpArgumentInfoFlags.UseCompileTimeType | CSharpArgumentInfoFlags.Constant, (string) null)
            }));
          }
          // ISSUE: reference to a compiler-generated field
          // ISSUE: reference to a compiler-generated field
          object obj5 = ProgramBuilderController.\u003C\u003Eo__33.\u003C\u003Ep__5.Target((CallSite) ProgramBuilderController.\u003C\u003Eo__33.\u003C\u003Ep__5, this.ViewBag, "alert('要导入的Excel文件为空!');");
        }
      }
      return (ActionResult) this.View();
    }
  }
}
