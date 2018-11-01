// Decompiled with JetBrains decompiler
// Type: WebMvc.Controllers.DictController
// Assembly: WebMvc, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 43FD7615-6DC3-49FB-B263-7F7CC91AFA77
// Assembly location: C:\inetpub\wwwroot\RoadFlowMvc\bin\WebMvc.dll

using Microsoft.CSharp.RuntimeBinder;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Web.Mvc;
using WebMvc.Common;

namespace WebMvc.Controllers
{
  public class DictController : MyController
  {
    public ActionResult Index()
    {
      return (ActionResult) this.View();
    }

    [MyAttribute(CheckApp = false, CheckLogin = false, CheckUrl = false)]
    public string Tree1()
    {
      string msg;
      if (!Tools.CheckLogin(out msg) && !RoadFlow.Platform.WeiXin.Organize.CheckLogin())
        return "";
      RoadFlow.Platform.Dictionary dictionary1 = new RoadFlow.Platform.Dictionary();
      string str = this.Request.QueryString["root"];
      int num1 = "1" == this.Request.QueryString["ischild"] ? 1 : 0;
      Guid test = Guid.Empty;
      if (!str.IsNullOrEmpty() && !str.IsGuid(out test))
      {
        RoadFlow.Data.Model.Dictionary byCode = dictionary1.GetByCode(str, false);
        if (byCode != null)
          test = byCode.ID;
      }
      RoadFlow.Data.Model.Dictionary dictionary2 = test != Guid.Empty ? dictionary1.Get(test, false) : dictionary1.GetRoot();
      bool flag = dictionary1.HasChilds(dictionary2.ID);
      StringBuilder stringBuilder = new StringBuilder("[", 1000);
      stringBuilder.Append("{");
      stringBuilder.AppendFormat("\"id\":\"{0}\",", (object) dictionary2.ID);
      stringBuilder.AppendFormat("\"parentID\":\"{0}\",", (object) dictionary2.ParentID);
      stringBuilder.AppendFormat("\"title\":\"{0}\",", (object) dictionary2.Title);
      stringBuilder.AppendFormat("\"type\":\"{0}\",", flag ? (object) "0" : (object) "2");
      stringBuilder.AppendFormat("\"ico\":\"{0}\",", (object) this.Url.Content("~/images/ico/role.gif"));
      stringBuilder.AppendFormat("\"hasChilds\":\"{0}\",", flag ? (object) "1" : (object) "0");
      stringBuilder.Append("\"childs\":[");
      List<RoadFlow.Data.Model.Dictionary> childs = dictionary1.GetChilds(dictionary2.ID, false);
      int num2 = 0;
      int count = childs.Count;
      foreach (RoadFlow.Data.Model.Dictionary dictionary3 in childs)
      {
        stringBuilder.Append("{");
        stringBuilder.AppendFormat("\"id\":\"{0}\",", (object) dictionary3.ID);
        stringBuilder.AppendFormat("\"parentID\":\"{0}\",", (object) dictionary3.ParentID);
        stringBuilder.AppendFormat("\"title\":\"{0}\",", (object) dictionary3.Title);
        stringBuilder.AppendFormat("\"ico\":\"{0}\",", (object) "");
        stringBuilder.AppendFormat("\"hasChilds\":\"{0}\",", dictionary1.HasChilds(dictionary3.ID) ? (object) "1" : (object) "0");
        stringBuilder.Append("\"childs\":[");
        stringBuilder.Append("]");
        stringBuilder.Append("}");
        if (num2++ < count - 1)
          stringBuilder.Append(",");
      }
      stringBuilder.Append("]");
      stringBuilder.Append("}");
      stringBuilder.Append("]");
      return stringBuilder.ToString();
    }

    [MyAttribute(CheckApp = false, CheckLogin = false, CheckUrl = false)]
    public string TreeRefresh()
    {
      string msg;
      if (!Tools.CheckLogin(out msg) && !RoadFlow.Platform.WeiXin.Organize.CheckLogin())
        return "";
      Guid test;
      if (!this.Request.QueryString["refreshid"].IsGuid(out test))
        this.Response.Write("[]");
      StringBuilder stringBuilder = new StringBuilder("[", 1000);
      RoadFlow.Platform.Dictionary dictionary1 = new RoadFlow.Platform.Dictionary();
      IOrderedEnumerable<RoadFlow.Data.Model.Dictionary> source = dictionary1.GetChilds(test, false).OrderBy<RoadFlow.Data.Model.Dictionary, int>((Func<RoadFlow.Data.Model.Dictionary, int>) (p => p.Sort));
      int num1 = 0;
      int num2 = source.Count<RoadFlow.Data.Model.Dictionary>();
      foreach (RoadFlow.Data.Model.Dictionary dictionary2 in (IEnumerable<RoadFlow.Data.Model.Dictionary>) source)
      {
        bool flag = dictionary1.HasChilds(dictionary2.ID);
        stringBuilder.Append("{");
        stringBuilder.AppendFormat("\"id\":\"{0}\",", (object) dictionary2.ID);
        stringBuilder.AppendFormat("\"parentID\":\"{0}\",", (object) dictionary2.ParentID);
        stringBuilder.AppendFormat("\"title\":\"{0}\",", (object) dictionary2.Title);
        stringBuilder.AppendFormat("\"type\":\"{0}\",", flag ? (object) "1" : (object) "2");
        stringBuilder.AppendFormat("\"ico\":\"{0}\",", (object) "");
        stringBuilder.AppendFormat("\"hasChilds\":\"{0}\",", flag ? (object) "1" : (object) "0");
        stringBuilder.Append("\"childs\":[");
        stringBuilder.Append("]");
        stringBuilder.Append("}");
        if (num1++ < num2 - 1)
          stringBuilder.Append(",");
      }
      stringBuilder.Append("]");
      return stringBuilder.ToString();
    }

    [MyAttribute(CheckApp = false)]
    public ActionResult Tree()
    {
      return (ActionResult) this.View();
    }

    public ActionResult Body()
    {
      return this.Body((FormCollection) null);
    }

    [HttpPost]
    [ValidateAntiForgeryToken]
    public ActionResult Body(FormCollection collection)
    {
      RoadFlow.Platform.Dictionary dictionary = new RoadFlow.Platform.Dictionary();
      RoadFlow.Data.Model.Dictionary model = (RoadFlow.Data.Model.Dictionary) null;
      string str1 = this.Request.QueryString["id"];
      if (str1.IsGuid())
        model = dictionary.Get(str1.ToGuid(), false);
      if (model == null)
        model = dictionary.GetRoot();
      if (collection != null)
      {
        Guid guid;
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
        if (!this.Request.Form["Delete"].IsNullOrEmpty())
        {
          int num = dictionary.DeleteAndAllChilds(model.ID);
          dictionary.RefreshCache();
          RoadFlow.Platform.Log.Add("删除了数据字典及其下级共" + num.ToString() + "项", model.Serialize(), RoadFlow.Platform.Log.Types.数据字典, "", "", (RoadFlow.Data.Model.Users) null);
          // ISSUE: reference to a compiler-generated field
          if (DictController.\u003C\u003Eo__5.\u003C\u003Ep__0 == null)
          {
            // ISSUE: reference to a compiler-generated field
            DictController.\u003C\u003Eo__5.\u003C\u003Ep__0 = CallSite<Func<CallSite, object, string, object>>.Create(Binder.SetMember(CSharpBinderFlags.None, "Script", typeof (DictController), (IEnumerable<CSharpArgumentInfo>) new CSharpArgumentInfo[2]
            {
              CSharpArgumentInfo.Create(CSharpArgumentInfoFlags.None, (string) null),
              CSharpArgumentInfo.Create(CSharpArgumentInfoFlags.UseCompileTimeType, (string) null)
            }));
          }
          // ISSUE: reference to a compiler-generated field
          Func<CallSite, object, string, object> target = DictController.\u003C\u003Eo__5.\u003C\u003Ep__0.Target;
          // ISSUE: reference to a compiler-generated field
          CallSite<Func<CallSite, object, string, object>> p0 = DictController.\u003C\u003Eo__5.\u003C\u003Ep__0;
          object viewBag = this.ViewBag;
          string[] strArray = new string[7]{ "alert('删除成功!');parent.frames[0].reLoad('", str3, "');window.location='Body?id=", null, null, null, null };
          int index = 3;
          guid = model.ParentID;
          string str4 = guid.ToString();
          strArray[index] = str4;
          strArray[4] = "&appid=";
          strArray[5] = this.Request.QueryString["appid"];
          strArray[6] = "';";
          string str5 = string.Concat(strArray);
          object obj = target((CallSite) p0, viewBag, str5);
          return (ActionResult) this.View((object) model);
        }
        string str6 = this.Request.Form["Title"];
        string str7 = this.Request.Form["Code"];
        string str8 = this.Request.Form["Values"];
        string str9 = this.Request.Form["Note"];
        string str10 = this.Request.Form["Other"];
        string oldXML = model.Serialize();
        model.Code = str7.IsNullOrEmpty() ? (string) null : str7.Trim();
        model.Note = str9.IsNullOrEmpty() ? (string) null : str9.Trim();
        model.Other = str10.IsNullOrEmpty() ? (string) null : str10.Trim();
        model.Title = str6.Trim();
        model.Value = str8.IsNullOrEmpty() ? (string) null : str8.Trim();
        dictionary.Update(model);
        dictionary.RefreshCache();
        RoadFlow.Platform.Log.Add("修改了数据字典项", "", RoadFlow.Platform.Log.Types.数据字典, oldXML, model.Serialize(), (RoadFlow.Data.Model.Users) null);
        // ISSUE: reference to a compiler-generated field
        if (DictController.\u003C\u003Eo__5.\u003C\u003Ep__1 == null)
        {
          // ISSUE: reference to a compiler-generated field
          DictController.\u003C\u003Eo__5.\u003C\u003Ep__1 = CallSite<Func<CallSite, object, string, object>>.Create(Binder.SetMember(CSharpBinderFlags.None, "Script", typeof (DictController), (IEnumerable<CSharpArgumentInfo>) new CSharpArgumentInfo[2]
          {
            CSharpArgumentInfo.Create(CSharpArgumentInfoFlags.None, (string) null),
            CSharpArgumentInfo.Create(CSharpArgumentInfoFlags.UseCompileTimeType, (string) null)
          }));
        }
        // ISSUE: reference to a compiler-generated field
        // ISSUE: reference to a compiler-generated field
        object obj1 = DictController.\u003C\u003Eo__5.\u003C\u003Ep__1.Target((CallSite) DictController.\u003C\u003Eo__5.\u003C\u003Ep__1, this.ViewBag, "alert('保存成功!');parent.frames[0].reLoad('" + str3 + "');");
      }
      return (ActionResult) this.View((object) model);
    }

    [MyAttribute(CheckApp = false)]
    public string CheckCode()
    {
      return !new RoadFlow.Platform.Dictionary().HasCode(this.Request.Form["value"], this.Request["id"]) ? "1" : "唯一代码重复";
    }

    public ActionResult Add()
    {
      return this.add1((FormCollection) null);
    }

    [HttpPost]
    [ValidateAntiForgeryToken]
    public ActionResult Add(FormCollection collection)
    {
      return this.add1(collection);
    }

    public ActionResult add1(FormCollection collection)
    {
      RoadFlow.Data.Model.Dictionary model = new RoadFlow.Data.Model.Dictionary();
      RoadFlow.Platform.Dictionary dictionary = new RoadFlow.Platform.Dictionary();
      string str1 = this.Request.QueryString["id"];
      if (!str1.IsGuid())
      {
        RoadFlow.Data.Model.Dictionary root = dictionary.GetRoot();
        str1 = root != null ? root.ID.ToString() : "";
      }
      if (!str1.IsGuid())
        throw new Exception("未找到父级");
      if (collection != null)
      {
        string str2 = this.Request.Form["Title"];
        string str3 = this.Request.Form["Code"];
        string str4 = this.Request.Form["Values"];
        string str5 = this.Request.Form["Note"];
        string str6 = this.Request.Form["Other"];
        model.ID = Guid.NewGuid();
        model.Code = str3.IsNullOrEmpty() ? (string) null : str3.Trim();
        model.Note = str5.IsNullOrEmpty() ? (string) null : str5.Trim();
        model.Other = str6.IsNullOrEmpty() ? (string) null : str6.Trim();
        model.ParentID = str1.ToGuid();
        model.Sort = dictionary.GetMaxSort(str1.ToGuid());
        model.Title = str2.Trim();
        model.Value = str4.IsNullOrEmpty() ? (string) null : str4.Trim();
        dictionary.Add(model);
        dictionary.RefreshCache();
        RoadFlow.Platform.Log.Add("添加了数据字典项", model.Serialize(), RoadFlow.Platform.Log.Types.数据字典, "", "", (RoadFlow.Data.Model.Users) null);
        // ISSUE: reference to a compiler-generated field
        if (DictController.\u003C\u003Eo__9.\u003C\u003Ep__0 == null)
        {
          // ISSUE: reference to a compiler-generated field
          DictController.\u003C\u003Eo__9.\u003C\u003Ep__0 = CallSite<Func<CallSite, object, string, object>>.Create(Binder.SetMember(CSharpBinderFlags.None, "Script", typeof (DictController), (IEnumerable<CSharpArgumentInfo>) new CSharpArgumentInfo[2]
          {
            CSharpArgumentInfo.Create(CSharpArgumentInfoFlags.None, (string) null),
            CSharpArgumentInfo.Create(CSharpArgumentInfoFlags.UseCompileTimeType, (string) null)
          }));
        }
        // ISSUE: reference to a compiler-generated field
        // ISSUE: reference to a compiler-generated field
        object obj = DictController.\u003C\u003Eo__9.\u003C\u003Ep__0.Target((CallSite) DictController.\u003C\u003Eo__9.\u003C\u003Ep__0, this.ViewBag, "alert('添加成功!');parent.frames[0].reLoad('" + str1 + "');");
      }
      return (ActionResult) this.View((object) model);
    }

    public ActionResult Sort()
    {
      return this.Sort((FormCollection) null);
    }

    [HttpPost]
    [ValidateAntiForgeryToken]
    public ActionResult Sort(FormCollection collection)
    {
      RoadFlow.Platform.Dictionary dictionary1 = new RoadFlow.Platform.Dictionary();
      string str1 = this.Request.QueryString["id"];
      string str2 = "";
      List<RoadFlow.Data.Model.Dictionary> dictionaryList = new List<RoadFlow.Data.Model.Dictionary>();
      Guid test1;
      if (str1.IsGuid(out test1))
      {
        RoadFlow.Data.Model.Dictionary dictionary2 = dictionary1.Get(test1, false);
        if (dictionary2 != null)
        {
          dictionaryList = dictionary1.GetChilds(dictionary2.ParentID, false);
          str2 = dictionary2.ParentID.ToString();
        }
      }
      if (collection != null)
      {
        string str3 = this.Request.Form["sort"];
        if (str3.IsNullOrEmpty())
          return (ActionResult) this.View((object) dictionaryList);
        string[] strArray = str3.Split(',');
        int num = 1;
        foreach (string str4 in strArray)
        {
          Guid test2;
          if (str4.IsGuid(out test2))
            dictionary1.UpdateSort(test2, num++);
        }
        dictionary1.RefreshCache();
        RoadFlow.Platform.Log.Add("保存了数据字典排序", "保存了ID为：" + str1 + "的同级排序", RoadFlow.Platform.Log.Types.数据字典, "", "", (RoadFlow.Data.Model.Users) null);
        // ISSUE: reference to a compiler-generated field
        if (DictController.\u003C\u003Eo__11.\u003C\u003Ep__0 == null)
        {
          // ISSUE: reference to a compiler-generated field
          DictController.\u003C\u003Eo__11.\u003C\u003Ep__0 = CallSite<Func<CallSite, object, string, object>>.Create(Binder.SetMember(CSharpBinderFlags.None, "Script", typeof (DictController), (IEnumerable<CSharpArgumentInfo>) new CSharpArgumentInfo[2]
          {
            CSharpArgumentInfo.Create(CSharpArgumentInfoFlags.None, (string) null),
            CSharpArgumentInfo.Create(CSharpArgumentInfoFlags.UseCompileTimeType, (string) null)
          }));
        }
        // ISSUE: reference to a compiler-generated field
        // ISSUE: reference to a compiler-generated field
        object obj = DictController.\u003C\u003Eo__11.\u003C\u003Ep__0.Target((CallSite) DictController.\u003C\u003Eo__11.\u003C\u003Ep__0, this.ViewBag, "parent.frames[0].reLoad('" + str2 + "');");
        dictionaryList = dictionary1.GetChilds(str2.ToGuid(), false);
      }
      return (ActionResult) this.View((object) dictionaryList);
    }
  }
}
