// Decompiled with JetBrains decompiler
// Type: WebMvc.Controllers.ShortMessageController
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
using System.Web.Mvc;

namespace WebMvc.Controllers
{
  public class ShortMessageController : MyController
  {
    [MyAttribute(CheckApp = false)]
    public ActionResult Index()
    {
      return (ActionResult) this.View();
    }

    [MyAttribute(CheckApp = false)]
    public ActionResult NoRead()
    {
      return (ActionResult) this.View();
    }

    [HttpPost]
    [ValidateAntiForgeryToken]
    [MyAttribute(CheckApp = false)]
    public string QueryNoRead()
    {
      string title = this.Request.Form["Title1"];
      string contents = this.Request.Form["Contents"];
      string str1 = this.Request.Form["SenderID"];
      string date1 = this.Request.Form["Date1"];
      string date2 = this.Request.Form["Date2"];
      string str2 = this.Request.Form["sidx"];
      string str3 = this.Request.Form["sord"];
      int num = this.Request.Form["status"].ToInt(0);
      string receiveID = RoadFlow.Platform.Users.CurrentUserID.ToString();
      int[] status = new int[1];
      if (2 == num)
      {
        status = new int[2]{ 0, 1 };
        str1 = "'" + MyController.CurrentUserID.ToString() + "'";
        receiveID = "";
      }
      else if (1 == num)
      {
        status = new int[1]{ 1 };
        str1 = Tools.GetSqlInString<Guid>(new RoadFlow.Platform.Organize().GetAllUsersIdList(str1).ToArray(), true);
      }
      List<RoadFlow.Data.Model.ShortMessage> shortMessageList = new List<RoadFlow.Data.Model.ShortMessage>();
      int pageSize = Tools.GetPageSize();
      int pageNumber = Tools.GetPageNumber();
      string order = (str2.IsNullOrEmpty() ? "SenderTime" : str2) + " " + (str3.IsNullOrEmpty() ? "asc" : str3);
      long count;
      List<RoadFlow.Data.Model.ShortMessage> list = new RoadFlow.Platform.ShortMessage().GetList(out count, status, pageSize, pageNumber, title, contents, str1, date1, date2, receiveID, order);
      JsonData jsonData = new JsonData();
      foreach (RoadFlow.Data.Model.ShortMessage shortMessage in list)
        jsonData.Add((object) new JsonData()
        {
          ["id"] = (JsonData) shortMessage.ID.ToString(),
          ["Title"] = (JsonData) ("<a href=\"javascript:show('" + (object) shortMessage.ID + "');\" class=\"blue1\">" + shortMessage.Title + "</a><input type=\"hidden\" id=\"status_" + shortMessage.ID.ToString() + "\" value=\"" + (object) shortMessage.Status + "\"/>"),
          ["Contents"] = (JsonData) Tools.RemoveHTML(shortMessage.Contents).CutString(100, "..."),
          ["SendUserName"] = (JsonData) shortMessage.SendUserName,
          ["SendTime"] = (JsonData) shortMessage.SendTime.ToDateTimeStringS()
        });
      return "{\"userdata\":{\"total\":" + (object) count + ",\"pagesize\":" + (object) pageSize + ",\"pagenumber\":" + (object) pageNumber + "},\"rows\":" + jsonData.ToJson(true) + "}";
    }

    [HttpPost]
    [ValidateAntiForgeryToken]
    [MyAttribute(CheckApp = false)]
    public string NoReadToRead()
    {
      string str1 = this.Request.Form["ids"] ?? "";
      RoadFlow.Platform.ShortMessage shortMessage = new RoadFlow.Platform.ShortMessage();
      char[] chArray = new char[1]{ ',' };
      foreach (string str2 in str1.Split(chArray))
      {
        if (str2.IsGuid())
          shortMessage.UpdateStatus(str2.ToGuid());
      }
      return "操作成功!";
    }

    [MyAttribute(CheckApp = false)]
    public void UpdateStatus()
    {
      string str = this.Request.QueryString["id"];
      if (!str.IsGuid())
        return;
      new RoadFlow.Platform.ShortMessage().UpdateStatus(str.ToGuid());
    }

    [MyAttribute(CheckApp = false)]
    public ActionResult Send()
    {
      return this.Send((FormCollection) null);
    }

    [HttpPost]
    [ValidateAntiForgeryToken]
    [MyAttribute(CheckApp = false)]
    public ActionResult Send(FormCollection collection)
    {
      if (collection != null)
      {
        string str1 = this.Request.Form["Title1"];
        string str2 = this.Request.Form["Contents"];
        string str3 = this.Request.Form["ReceiveUserID"];
        string str4 = this.Request.Form["Files"];
        string str5 = this.Request.Form["sendtoseixin"];
        if (str1.IsNullOrEmpty() || str2.IsNullOrEmpty() || str3.IsNullOrEmpty())
        {
          // ISSUE: reference to a compiler-generated field
          if (ShortMessageController.\u003C\u003Eo__6.\u003C\u003Ep__0 == null)
          {
            // ISSUE: reference to a compiler-generated field
            ShortMessageController.\u003C\u003Eo__6.\u003C\u003Ep__0 = CallSite<Func<CallSite, object, string, object>>.Create(Binder.SetMember(CSharpBinderFlags.None, "script", typeof (ShortMessageController), (IEnumerable<CSharpArgumentInfo>) new CSharpArgumentInfo[2]
            {
              CSharpArgumentInfo.Create(CSharpArgumentInfoFlags.None, (string) null),
              CSharpArgumentInfo.Create(CSharpArgumentInfoFlags.UseCompileTimeType | CSharpArgumentInfoFlags.Constant, (string) null)
            }));
          }
          // ISSUE: reference to a compiler-generated field
          // ISSUE: reference to a compiler-generated field
          object obj = ShortMessageController.\u003C\u003Eo__6.\u003C\u003Ep__0.Target((CallSite) ShortMessageController.\u003C\u003Eo__6.\u003C\u003Ep__0, this.ViewBag, "alert('数据验证错误!')");
          return (ActionResult) this.View();
        }
        List<RoadFlow.Data.Model.Users> allUsers = new RoadFlow.Platform.Organize().GetAllUsers(str3);
        StringBuilder stringBuilder1 = new StringBuilder();
        StringBuilder stringBuilder2 = new StringBuilder();
        RoadFlow.Data.Model.ShortMessage msg = (RoadFlow.Data.Model.ShortMessage) null;
        RoadFlow.Platform.ShortMessage shortMessage = new RoadFlow.Platform.ShortMessage();
        foreach (RoadFlow.Data.Model.Users users in allUsers)
        {
          RoadFlow.Data.Model.ShortMessage model = new RoadFlow.Data.Model.ShortMessage();
          model.Contents = str2;
          model.ID = Guid.NewGuid();
          model.ReceiveUserID = users.ID;
          model.ReceiveUserName = users.Name;
          model.SendTime = DateTimeNew.Now;
          model.SendUserID = RoadFlow.Platform.Users.CurrentUserID;
          model.SendUserName = RoadFlow.Platform.Users.CurrentUserName;
          model.Status = 0;
          model.Title = str1;
          model.Type = 0;
          model.Files = str4;
          shortMessage.Add(model);
          RoadFlow.Platform.ShortMessage.SiganalR(users.ID, model.ID.ToString(), str1, str2.RemoveHTML());
          stringBuilder1.Append(users.Name);
          stringBuilder1.Append(",");
          stringBuilder2.Append(users.Account);
          stringBuilder2.Append('|');
          if (msg == null)
            msg = model;
        }
        if ("1" == str5 && msg != null && stringBuilder2.Length > 0)
          shortMessage.SendToWeiXin(msg, stringBuilder2.ToString().TrimEnd('|'));
        // ISSUE: reference to a compiler-generated field
        if (ShortMessageController.\u003C\u003Eo__6.\u003C\u003Ep__1 == null)
        {
          // ISSUE: reference to a compiler-generated field
          ShortMessageController.\u003C\u003Eo__6.\u003C\u003Ep__1 = CallSite<Func<CallSite, object, string, object>>.Create(Binder.SetMember(CSharpBinderFlags.None, "script", typeof (ShortMessageController), (IEnumerable<CSharpArgumentInfo>) new CSharpArgumentInfo[2]
          {
            CSharpArgumentInfo.Create(CSharpArgumentInfoFlags.None, (string) null),
            CSharpArgumentInfo.Create(CSharpArgumentInfoFlags.UseCompileTimeType, (string) null)
          }));
        }
        // ISSUE: reference to a compiler-generated field
        // ISSUE: reference to a compiler-generated field
        object obj1 = ShortMessageController.\u003C\u003Eo__6.\u003C\u003Ep__1.Target((CallSite) ShortMessageController.\u003C\u003Eo__6.\u003C\u003Ep__1, this.ViewBag, string.Format("alert('成功将消息发送给了：{0}!');window.location=window.location;", (object) stringBuilder1.ToString()));
      }
      return (ActionResult) this.View();
    }

    [MyAttribute(CheckApp = false, CheckLogin = false, CheckUrl = false)]
    public ActionResult Show()
    {
      return (ActionResult) this.View();
    }

    [MyAttribute(CheckApp = false, CheckUrl = false)]
    public ActionResult Read()
    {
      return (ActionResult) this.View();
    }

    [MyAttribute(CheckApp = false)]
    public ActionResult SendList()
    {
      return (ActionResult) this.View();
    }

    [HttpPost]
    [ValidateAntiForgeryToken]
    [MyAttribute(CheckApp = false)]
    public string Delete()
    {
      string str1 = this.Request.Form["ids"] ?? "";
      RoadFlow.Platform.ShortMessage shortMessage1 = new RoadFlow.Platform.ShortMessage();
      if (str1.IsNullOrEmpty())
        return "没有选择要删除的消息!";
      string str2 = str1;
      char[] chArray = new char[1]{ ',' };
      foreach (string str3 in str2.Split(chArray))
      {
        if (str3.IsGuid())
        {
          RoadFlow.Data.Model.ShortMessage shortMessage2 = shortMessage1.Get(str3.ToGuid());
          if (shortMessage2 != null)
          {
            shortMessage1.Delete(shortMessage2.ID);
            RoadFlow.Platform.Log.Add("删除了站内消息", shortMessage2.Serialize(), RoadFlow.Platform.Log.Types.信息管理, "", "", (RoadFlow.Data.Model.Users) null);
          }
        }
      }
      return "操作成功!";
    }
  }
}
