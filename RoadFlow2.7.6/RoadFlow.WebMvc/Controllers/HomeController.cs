// Decompiled with JetBrains decompiler
// Type: WebMvc.Controllers.HomeController
// Assembly: WebMvc, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 43FD7615-6DC3-49FB-B263-7F7CC91AFA77
// Assembly location: C:\inetpub\wwwroot\RoadFlowMvc\bin\WebMvc.dll

using LitJson;
using Microsoft.CSharp.RuntimeBinder;
using RoadFlow.Utility;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Web.Mvc;

namespace WebMvc.Controllers
{
  public class HomeController : MyController
  {
    [MyAttribute(CheckApp = false, CheckUrl = false)]
    public ActionResult Index()
    {
      RoadFlow.Data.Model.Users currentUser = MyController.CurrentUser;
      // ISSUE: reference to a compiler-generated field
      if (HomeController.\u003C\u003Eo__0.\u003C\u003Ep__0 == null)
      {
        // ISSUE: reference to a compiler-generated field
        HomeController.\u003C\u003Eo__0.\u003C\u003Ep__0 = CallSite<Func<CallSite, object, string, object>>.Create(Binder.SetMember(CSharpBinderFlags.None, "UserName", typeof (HomeController), (IEnumerable<CSharpArgumentInfo>) new CSharpArgumentInfo[2]
        {
          CSharpArgumentInfo.Create(CSharpArgumentInfoFlags.None, (string) null),
          CSharpArgumentInfo.Create(CSharpArgumentInfoFlags.UseCompileTimeType, (string) null)
        }));
      }
      // ISSUE: reference to a compiler-generated field
      // ISSUE: reference to a compiler-generated field
      object obj1 = HomeController.\u003C\u003Eo__0.\u003C\u003Ep__0.Target((CallSite) HomeController.\u003C\u003Eo__0.\u003C\u003Ep__0, this.ViewBag, currentUser == null ? "" : currentUser.Name);
      // ISSUE: reference to a compiler-generated field
      if (HomeController.\u003C\u003Eo__0.\u003C\u003Ep__1 == null)
      {
        // ISSUE: reference to a compiler-generated field
        HomeController.\u003C\u003Eo__0.\u003C\u003Ep__1 = CallSite<Func<CallSite, object, string, object>>.Create(Binder.SetMember(CSharpBinderFlags.None, "DateTime", typeof (HomeController), (IEnumerable<CSharpArgumentInfo>) new CSharpArgumentInfo[2]
        {
          CSharpArgumentInfo.Create(CSharpArgumentInfoFlags.None, (string) null),
          CSharpArgumentInfo.Create(CSharpArgumentInfoFlags.UseCompileTimeType, (string) null)
        }));
      }
      // ISSUE: reference to a compiler-generated field
      // ISSUE: reference to a compiler-generated field
      object obj2 = HomeController.\u003C\u003Eo__0.\u003C\u003Ep__1.Target((CallSite) HomeController.\u003C\u003Eo__0.\u003C\u003Ep__1, this.ViewBag, MyController.CurrentDateTime.ToDateWeekString());
      List<RoadFlow.Data.Model.ShortMessage> allNoReadByUserId = new RoadFlow.Platform.ShortMessage().GetAllNoReadByUserID(currentUser.ID);
      if (allNoReadByUserId.Count > 0)
      {
        JsonData jsonData = new JsonData();
        string empty = string.Empty;
        RoadFlow.Data.Model.ShortMessage shortMessage = allNoReadByUserId.OrderByDescending<RoadFlow.Data.Model.ShortMessage, DateTime>((Func<RoadFlow.Data.Model.ShortMessage, DateTime>) (p => p.SendTime)).FirstOrDefault<RoadFlow.Data.Model.ShortMessage>();
        string str;
        if (!shortMessage.LinkUrl.IsNullOrEmpty())
          str = "<a class=\"blue1\" href=\"" + shortMessage.LinkUrl + "\">" + shortMessage.Contents.RemoveHTML() + "</a>";
        else
          str = shortMessage.Contents.RemoveHTML();
        jsonData["title"] = (JsonData) shortMessage.Title;
        jsonData["contents"] = (JsonData) str;
        jsonData["count"] = (JsonData) allNoReadByUserId.Count;
        // ISSUE: reference to a compiler-generated field
        if (HomeController.\u003C\u003Eo__0.\u003C\u003Ep__2 == null)
        {
          // ISSUE: reference to a compiler-generated field
          HomeController.\u003C\u003Eo__0.\u003C\u003Ep__2 = CallSite<Func<CallSite, object, string, object>>.Create(Binder.SetMember(CSharpBinderFlags.None, "NoReadMsgJson", typeof (HomeController), (IEnumerable<CSharpArgumentInfo>) new CSharpArgumentInfo[2]
          {
            CSharpArgumentInfo.Create(CSharpArgumentInfoFlags.None, (string) null),
            CSharpArgumentInfo.Create(CSharpArgumentInfoFlags.UseCompileTimeType, (string) null)
          }));
        }
        // ISSUE: reference to a compiler-generated field
        // ISSUE: reference to a compiler-generated field
        object obj3 = HomeController.\u003C\u003Eo__0.\u003C\u003Ep__2.Target((CallSite) HomeController.\u003C\u003Eo__0.\u003C\u003Ep__2, this.ViewBag, jsonData.ToJson(true));
      }
      string str1 = this.Url.Content("~/Content/UserHeads/default.jpg");
      if (!currentUser.HeadImg.IsNullOrEmpty() && File.Exists(this.Server.MapPath(this.Url.Content("~" + currentUser.HeadImg))))
        str1 = this.Url.Content("~" + currentUser.HeadImg);
      // ISSUE: reference to a compiler-generated field
      if (HomeController.\u003C\u003Eo__0.\u003C\u003Ep__3 == null)
      {
        // ISSUE: reference to a compiler-generated field
        HomeController.\u003C\u003Eo__0.\u003C\u003Ep__3 = CallSite<Func<CallSite, object, string, object>>.Create(Binder.SetMember(CSharpBinderFlags.None, "HeadImg", typeof (HomeController), (IEnumerable<CSharpArgumentInfo>) new CSharpArgumentInfo[2]
        {
          CSharpArgumentInfo.Create(CSharpArgumentInfoFlags.None, (string) null),
          CSharpArgumentInfo.Create(CSharpArgumentInfoFlags.UseCompileTimeType, (string) null)
        }));
      }
      // ISSUE: reference to a compiler-generated field
      // ISSUE: reference to a compiler-generated field
      object obj4 = HomeController.\u003C\u003Eo__0.\u003C\u003Ep__3.Target((CallSite) HomeController.\u003C\u003Eo__0.\u003C\u003Ep__3, this.ViewBag, str1);
      return (ActionResult) this.View();
    }

    [MyAttribute(CheckApp = false)]
    public ActionResult Home()
    {
      return (ActionResult) this.View();
    }

    [MyAttribute(CheckApp = false)]
    public string Menu()
    {
      string str = this.Request.QueryString["userid"];
      Guid guid = str.IsGuid() ? str.ToGuid() : RoadFlow.Platform.Users.CurrentUserID;
      bool flag = "1" == this.Request.QueryString["showsource"];
      if (guid.IsEmptyGuid())
        return "[]";
      return new RoadFlow.Platform.Menu().GetUserMenuJsonString(guid, this.Url.Content("~/").TrimEnd('/'), (flag ? 1 : 0) != 0);
    }

    [MyAttribute(CheckApp = false)]
    public string MenuRefresh()
    {
      string str1 = this.Request.QueryString["userid"];
      string str2 = this.Request.QueryString["refreshid"];
      bool flag = "1" == this.Request.QueryString["showsource"];
      Guid currentUserId = RoadFlow.Platform.Users.CurrentUserID;
      Guid guid;
      ref Guid local = ref guid;
      if (!str2.IsGuid(out local) || guid.IsEmptyGuid())
        return "[]";
      return new RoadFlow.Platform.Menu().GetUserMenuRefreshJsonString(currentUserId, guid, this.Url.Content("~/").TrimEnd('/'), (flag ? 1 : 0) != 0);
    }

    [MyAttribute(CheckApp = false)]
    public string MenuRefresh1()
    {
      string str = this.Request.QueryString["refreshid"];
      string isrefresh1 = this.Request.QueryString["isrefresh1"];
      Guid currentUserId = RoadFlow.Platform.Users.CurrentUserID;
      Guid guid;
      ref Guid local = ref guid;
      if (!str.IsGuid(out local) || guid.IsEmptyGuid())
        return "";
      return new RoadFlow.Platform.Menu().GetUserMenuChilds(currentUserId, guid, this.Url.Content("~/").TrimEnd('/'), isrefresh1);
    }

    public ActionResult SetList()
    {
      RoadFlow.Platform.HomeItems homeItems = new RoadFlow.Platform.HomeItems();
      // ISSUE: reference to a compiler-generated field
      if (HomeController.\u003C\u003Eo__5.\u003C\u003Ep__0 == null)
      {
        // ISSUE: reference to a compiler-generated field
        HomeController.\u003C\u003Eo__5.\u003C\u003Ep__0 = CallSite<Func<CallSite, object, string, object>>.Create(Binder.SetMember(CSharpBinderFlags.None, "TypeOptions", typeof (HomeController), (IEnumerable<CSharpArgumentInfo>) new CSharpArgumentInfo[2]
        {
          CSharpArgumentInfo.Create(CSharpArgumentInfoFlags.None, (string) null),
          CSharpArgumentInfo.Create(CSharpArgumentInfoFlags.UseCompileTimeType, (string) null)
        }));
      }
      // ISSUE: reference to a compiler-generated field
      // ISSUE: reference to a compiler-generated field
      object obj = HomeController.\u003C\u003Eo__5.\u003C\u003Ep__0.Target((CallSite) HomeController.\u003C\u003Eo__5.\u003C\u003Ep__0, this.ViewBag, homeItems.getTypeOptions(""));
      return (ActionResult) this.View();
    }

    [HttpPost]
    [ValidateAntiForgeryToken]
    public string Query()
    {
      RoadFlow.Platform.HomeItems homeItems1 = new RoadFlow.Platform.HomeItems();
      RoadFlow.Platform.Organize organize = new RoadFlow.Platform.Organize();
      List<RoadFlow.Data.Model.HomeItems> homeItemsList = new List<RoadFlow.Data.Model.HomeItems>();
      string name = this.Request.Form["Name1"];
      string title = this.Request.Form["Title1"];
      string type = this.Request.Form["Type"];
      string str1 = this.Request.Form["sidx"];
      string str2 = this.Request.Form["sord"];
      int pageSize = Tools.GetPageSize();
      int pageNumber = Tools.GetPageNumber();
      string order = (str1.IsNullOrEmpty() ? "Type" : str1) + " " + (str2.IsNullOrEmpty() ? "asc" : str2);
      long count;
      List<RoadFlow.Data.Model.HomeItems> list = homeItems1.GetList(out count, pageSize, pageNumber, name, title, type, order);
      JsonData jsonData = new JsonData();
      foreach (RoadFlow.Data.Model.HomeItems homeItems2 in list)
      {
        StringBuilder stringBuilder = new StringBuilder();
        if (!homeItems2.Ico.IsNullOrEmpty())
        {
          if (homeItems2.Ico.IsFontIco())
            stringBuilder.Append("<i class='fa " + homeItems2.Ico + "' style='font-size:14px;vertical-align:middle;margin-right:3px;'></i>");
          else
            stringBuilder.Append("<img src='" + this.Url.Content("~" + homeItems2.Ico) + "' style='vertical-align:middle;margin-right:3px;'/>");
        }
        stringBuilder.Append(homeItems2.Title);
        jsonData.Add((object) new JsonData()
        {
          ["id"] = (JsonData) homeItems2.ID.ToString(),
          ["Name"] = (JsonData) homeItems2.Name,
          ["Title"] = (JsonData) stringBuilder.ToString(),
          ["Type"] = (JsonData) homeItems1.GetTypeTitle(homeItems2.Type),
          ["DataSourceType"] = (JsonData) homeItems1.GetDataSourceTitle(homeItems2.DataSourceType),
          ["UseOrganizes"] = (JsonData) organize.GetNames(homeItems2.UseOrganizes, ","),
          ["Note"] = (JsonData) homeItems2.Note,
          ["Opation"] = (JsonData) ("<a class=\"editlink\" href=\"javascript:void(0);\" onclick=\"edit('" + (object) homeItems2.ID + "');return false;\">编辑</a>")
        });
      }
      return "{\"userdata\":{\"total\":" + (object) count + ",\"pagesize\":" + (object) pageSize + ",\"pagenumber\":" + (object) pageNumber + "},\"rows\":" + jsonData.ToJson(true) + "}";
    }

    [HttpPost]
    [ValidateAntiForgeryToken]
    public string Delete()
    {
      RoadFlow.Platform.HomeItems homeItems = new RoadFlow.Platform.HomeItems();
      string str1 = this.Request.Form["ids"] ?? "";
      char[] chArray = new char[1]{ ',' };
      foreach (string str2 in str1.Split(chArray))
      {
        homeItems.Delete(str2.ToGuid());
        RoadFlow.Platform.Log.Add("删除了首页模块设置", str2, RoadFlow.Platform.Log.Types.其它分类, "", "", (RoadFlow.Data.Model.Users) null);
      }
      homeItems.ClearCache();
      return "删除成功!";
    }

    public ActionResult SetAdd()
    {
      return this.SetAdd((FormCollection) null);
    }

    [HttpPost]
    public ActionResult SetAdd(FormCollection collection)
    {
      RoadFlow.Platform.HomeItems homeItems1 = new RoadFlow.Platform.HomeItems();
      RoadFlow.Data.Model.HomeItems model = (RoadFlow.Data.Model.HomeItems) null;
      string str1 = this.Request.QueryString["id"];
      if (str1.IsGuid())
        model = homeItems1.Get(str1.ToGuid());
      if (collection != null)
      {
        string str2 = this.Request.Form["Name1"];
        string str3 = this.Request.Form["Title1"];
        string str4 = this.Request.Form["Type"];
        string str5 = this.Request.Form["DataSourceType"];
        string str6 = this.Request.Form["DataSource"];
        string str7 = this.Request.Form["Ico"];
        string str8 = this.Request.Form["BgColor"];
        string str9 = this.Request.Form["UseOrganizes"];
        string str10 = this.Request.Form["DBConnID"];
        string str11 = this.Request.Form["LinkURL"];
        string str12 = this.Request.Form["Note"];
        string str13 = this.Request.Form["Sort"];
        bool flag = false;
        if (model == null)
        {
          model = new RoadFlow.Data.Model.HomeItems();
          model.ID = Guid.NewGuid();
          flag = true;
        }
        model.Title = str3;
        model.Name = str2;
        model.Type = str4.ToInt();
        model.DataSourceType = str5.ToInt();
        model.DataSource = str6;
        model.Ico = str7;
        model.BgColor = str8;
        model.UseOrganizes = str9;
        model.Sort = new int?(str13.IsInt() ? str13.ToInt() : homeItems1.GetMaxSort(model.Type));
        model.DBConnID = !str10.IsGuid() ? new Guid?() : new Guid?(str10.ToGuid());
        model.LinkURL = str11;
        model.Note = str12;
        if (flag)
          homeItems1.Add(model);
        else
          homeItems1.Update(model);
        homeItems1.ClearCache();
        // ISSUE: reference to a compiler-generated field
        if (HomeController.\u003C\u003Eo__9.\u003C\u003Ep__0 == null)
        {
          // ISSUE: reference to a compiler-generated field
          HomeController.\u003C\u003Eo__9.\u003C\u003Ep__0 = CallSite<Func<CallSite, object, string, object>>.Create(Binder.SetMember(CSharpBinderFlags.None, "script", typeof (HomeController), (IEnumerable<CSharpArgumentInfo>) new CSharpArgumentInfo[2]
          {
            CSharpArgumentInfo.Create(CSharpArgumentInfoFlags.None, (string) null),
            CSharpArgumentInfo.Create(CSharpArgumentInfoFlags.UseCompileTimeType, (string) null)
          }));
        }
        // ISSUE: reference to a compiler-generated field
        // ISSUE: reference to a compiler-generated field
        object obj = HomeController.\u003C\u003Eo__9.\u003C\u003Ep__0.Target((CallSite) HomeController.\u003C\u003Eo__9.\u003C\u003Ep__0, this.ViewBag, "alert('保存成功!');window.location='SetList" + this.Request.Url.Query + "';");
      }
      // ISSUE: reference to a compiler-generated field
      if (HomeController.\u003C\u003Eo__9.\u003C\u003Ep__1 == null)
      {
        // ISSUE: reference to a compiler-generated field
        HomeController.\u003C\u003Eo__9.\u003C\u003Ep__1 = CallSite<Func<CallSite, object, string, object>>.Create(Binder.SetMember(CSharpBinderFlags.None, "TypeOptions", typeof (HomeController), (IEnumerable<CSharpArgumentInfo>) new CSharpArgumentInfo[2]
        {
          CSharpArgumentInfo.Create(CSharpArgumentInfoFlags.None, (string) null),
          CSharpArgumentInfo.Create(CSharpArgumentInfoFlags.UseCompileTimeType, (string) null)
        }));
      }
      // ISSUE: reference to a compiler-generated field
      Func<CallSite, object, string, object> target1 = HomeController.\u003C\u003Eo__9.\u003C\u003Ep__1.Target;
      // ISSUE: reference to a compiler-generated field
      CallSite<Func<CallSite, object, string, object>> p1 = HomeController.\u003C\u003Eo__9.\u003C\u003Ep__1;
      object viewBag1 = this.ViewBag;
      RoadFlow.Platform.HomeItems homeItems2 = homeItems1;
      int num;
      string str14;
      if (model != null)
      {
        num = model.Type;
        str14 = num.ToString();
      }
      else
        str14 = "";
      string typeOptions = homeItems2.getTypeOptions(str14);
      object obj1 = target1((CallSite) p1, viewBag1, typeOptions);
      // ISSUE: reference to a compiler-generated field
      if (HomeController.\u003C\u003Eo__9.\u003C\u003Ep__2 == null)
      {
        // ISSUE: reference to a compiler-generated field
        HomeController.\u003C\u003Eo__9.\u003C\u003Ep__2 = CallSite<Func<CallSite, object, string, object>>.Create(Binder.SetMember(CSharpBinderFlags.None, "DataSourceTypeOptions", typeof (HomeController), (IEnumerable<CSharpArgumentInfo>) new CSharpArgumentInfo[2]
        {
          CSharpArgumentInfo.Create(CSharpArgumentInfoFlags.None, (string) null),
          CSharpArgumentInfo.Create(CSharpArgumentInfoFlags.UseCompileTimeType, (string) null)
        }));
      }
      // ISSUE: reference to a compiler-generated field
      Func<CallSite, object, string, object> target2 = HomeController.\u003C\u003Eo__9.\u003C\u003Ep__2.Target;
      // ISSUE: reference to a compiler-generated field
      CallSite<Func<CallSite, object, string, object>> p2 = HomeController.\u003C\u003Eo__9.\u003C\u003Ep__2;
      object viewBag2 = this.ViewBag;
      RoadFlow.Platform.HomeItems homeItems3 = homeItems1;
      string str15;
      if (model != null)
      {
        num = model.DataSourceType;
        str15 = num.ToString();
      }
      else
        str15 = "";
      string dataSourceOptions = homeItems3.getDataSourceOptions(str15);
      object obj2 = target2((CallSite) p2, viewBag2, dataSourceOptions);
      // ISSUE: reference to a compiler-generated field
      if (HomeController.\u003C\u003Eo__9.\u003C\u003Ep__3 == null)
      {
        // ISSUE: reference to a compiler-generated field
        HomeController.\u003C\u003Eo__9.\u003C\u003Ep__3 = CallSite<Func<CallSite, object, string, object>>.Create(Binder.SetMember(CSharpBinderFlags.None, "DBConnIDOptions", typeof (HomeController), (IEnumerable<CSharpArgumentInfo>) new CSharpArgumentInfo[2]
        {
          CSharpArgumentInfo.Create(CSharpArgumentInfoFlags.None, (string) null),
          CSharpArgumentInfo.Create(CSharpArgumentInfoFlags.UseCompileTimeType, (string) null)
        }));
      }
      // ISSUE: reference to a compiler-generated field
      // ISSUE: reference to a compiler-generated field
      object obj3 = HomeController.\u003C\u003Eo__9.\u003C\u003Ep__3.Target((CallSite) HomeController.\u003C\u003Eo__9.\u003C\u003Ep__3, this.ViewBag, new RoadFlow.Platform.DBConnection().GetAllOptions(model == null ? "" : model.DBConnID.ToString()));
      if (model == null)
        model = new RoadFlow.Data.Model.HomeItems();
      return (ActionResult) this.View((object) model);
    }
  }
}
