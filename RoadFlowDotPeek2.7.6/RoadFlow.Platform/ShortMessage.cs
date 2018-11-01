// Decompiled with JetBrains decompiler
// Type: RoadFlow.Platform.ShortMessage
// Assembly: RoadFlow.Platform, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 07F26AFD-DE3B-4003-89AF-01A62494BA58
// Assembly location: C:\inetpub\wwwroot\RoadFlowMvc\bin\RoadFlow.Platform.dll

using LitJson;
using Microsoft.AspNet.SignalR;
using RoadFlow.Data.Interface;
using RoadFlow.Platform.SignalR;
using RoadFlow.Platform.WeiXin;
using RoadFlow.Utility;
using System;
using System.Collections.Generic;

namespace RoadFlow.Platform
{
  public class ShortMessage
  {
    private static string cacheKey = Keys.CacheKeys.ShortMessage.ToString();
    private IShortMessage dataShortMessage;

    public ShortMessage()
    {
      this.dataShortMessage = RoadFlow.Data.Factory.Factory.GetShortMessage();
    }

    public static Guid Send(Guid userID, string userName, string title, string contents, int msgType = 0, string linkUrl = "", string linkID = "", string msgID = "")
    {
      if (userID.IsEmptyGuid() || title.IsNullOrEmpty() || contents.IsNullOrEmpty())
        return Guid.Empty;
      if (userName.IsNullOrEmpty())
        userName = new Users().GetName(userID);
      RoadFlow.Data.Model.ShortMessage model = new RoadFlow.Data.Model.ShortMessage();
      model.Contents = contents;
      model.ID = msgID.IsGuid() ? msgID.ToGuid() : Guid.NewGuid();
      model.LinkID = linkID;
      model.LinkUrl = linkUrl;
      model.ReceiveUserID = userID;
      model.ReceiveUserName = userName;
      model.SendTime = DateTimeNew.Now;
      model.SendUserID = Users.CurrentUserID;
      model.SendUserName = Users.CurrentUserName;
      model.Status = 0;
      model.Title = title;
      model.Type = msgType;
      new ShortMessage().Add(model);
      string empty = string.Empty;
      string contents1;
      if (!linkUrl.IsNullOrEmpty())
        contents1 = "<a class=\"blue1\" href=\"" + linkUrl + "\">" + model.Contents + "</a>";
      else
        contents1 = model.Contents;
      ShortMessage.SiganalR(userID, model.ID.ToString(), title, contents1);
      return model.ID;
    }

    public static void SiganalR(Guid userID, string id, string title, string contents)
    {
      //GlobalHost.ConnectionManager.GetConnectionContext<SignalRConnection>().Groups.Send(userID.ToString().ToLower(), (object) new JsonData()
      //{
      //  [nameof (id)] = (JsonData) id,
      //  [nameof (title)] = (JsonData) title,
      //  [nameof (contents)] = (JsonData) contents,
      //  ["count"] = (JsonData) new ShortMessage().GetAllNoReadByUserID(userID).Count
      //}.ToJson(true));
            GlobalHost.ConnectionManager.GetConnectionContext<SignalRConnection>().Groups.Send(userID.ToString().ToLower(), (object)new JsonData()
            {
                [nameof(id)] = (JsonData)id,
                [nameof(title)] = (JsonData)title,
                [nameof(contents)] = (JsonData)contents,
                ["count"] = (JsonData)new ShortMessage().GetAllNoReadByUserID(userID).Count
            }.ToJson());
        }

    public int Add(RoadFlow.Data.Model.ShortMessage model)
    {
      return this.dataShortMessage.Add(model);
    }

    public int Update(RoadFlow.Data.Model.ShortMessage model)
    {
      return this.dataShortMessage.Update(model);
    }

    public List<RoadFlow.Data.Model.ShortMessage> GetAll()
    {
      return this.dataShortMessage.GetAll();
    }

    public RoadFlow.Data.Model.ShortMessage Get(Guid id)
    {
      return this.dataShortMessage.Get(id);
    }

    public RoadFlow.Data.Model.ShortMessage GetRead(Guid id)
    {
      return this.dataShortMessage.GetRead(id);
    }

    public int Delete(Guid id)
    {
      return this.dataShortMessage.Delete(id);
    }

    public long GetCount()
    {
      return this.dataShortMessage.GetCount();
    }

    public List<RoadFlow.Data.Model.ShortMessage> GetAllNoReadByUserID(Guid userID)
    {
      return this.dataShortMessage.GetAllNoReadByUserID(userID);
    }

    public List<RoadFlow.Data.Model.ShortMessage> GetAllNoRead()
    {
      return this.dataShortMessage.GetAllNoRead();
    }

    public int UpdateStatus(Guid id)
    {
      return this.dataShortMessage.UpdateStatus(id);
    }

    public List<RoadFlow.Data.Model.ShortMessage> GetList(out string pager, int[] status, string query = "", string title = "", string contents = "", string senderID = "", string date1 = "", string date2 = "", string receiveID = "")
    {
      senderID = Tools.GetSqlInString<Guid>(new Organize().GetAllUsersIdList(senderID).ToArray(), true);
      return this.dataShortMessage.GetList(out pager, status, query, title, contents, senderID, date1, date2, receiveID);
    }

    public List<RoadFlow.Data.Model.ShortMessage> GetList(out long count, int[] status, int size, int number, string title = "", string contents = "", string senderID = "", string date1 = "", string date2 = "", string receiveID = "", string order = "")
    {
      return this.dataShortMessage.GetList(out count, status, size, number, title, contents, senderID, date1, date2, receiveID, order);
    }

    public int Delete(string linkID, int type)
    {
      return this.dataShortMessage.Delete(linkID, type);
    }

    public bool SendToWeiXin(RoadFlow.Data.Model.ShortMessage msg, string userAccounts)
    {
      if (msg == null)
        return false;
      Message message = new Message();
      string[] imageUrlFromHtml = Tools.GetImageUrlFromHTML(msg.Contents);
      int agentIdByCode = new Agents().GetAgentIDByCode("weixinagents_infocenter");
      if (imageUrlFromHtml.Length != 0)
      {
        string str = RoadFlow.Platform.WeiXin.Config.WebUrl + imageUrlFromHtml[0];
        message.SendNews(new List<Tuple<string, string, string, string>>()
        {
          new Tuple<string, string, string, string>(msg.Title, msg.Contents.RemoveHTML().CutString(100, "..."), RoadFlow.Platform.WeiXin.Config.WebUrl + RoadFlow.Utility.Config.BaseUrl + "/Platform/Info/ShortMessage/Show.aspx?id=" + msg.ID.ToString(), str)
        }, userAccounts, "", "", agentIdByCode, false);
      }
      else
        message.SendText(msg.Contents.RemoveHTML().CutString(100, "...") + "\n点击链接阅读全文：" + RoadFlow.Platform.WeiXin.Config.WebUrl + RoadFlow.Utility.Config.BaseUrl + "Platform/Info/ShortMessage/Show.aspx?id=" + msg.ID.ToString(), userAccounts, "", "", 0, agentIdByCode, false);
      return true;
    }
  }
}
