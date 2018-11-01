using LitJson;
using Microsoft.AspNet.SignalR;
using RoadFlow.Data.Factory;
using RoadFlow.Data.Interface;
using RoadFlow.Data.Model;
using RoadFlow.Platform.SignalR;
using RoadFlow.Platform.WeiXin;
using RoadFlow.Utility;
using System;
using System.Collections.Generic;

namespace RoadFlow.Platform
{
	public class ShortMessage
	{
		private IShortMessage dataShortMessage;

		private static string cacheKey = 12.ToString();

		public ShortMessage()
		{
			dataShortMessage = Factory.GetShortMessage();
		}

		public static Guid Send(Guid userID, string userName, string title, string contents, int msgType = 0, string linkUrl = "", string linkID = "", string msgID = "")
		{
			if (userID.IsEmptyGuid() || title.IsNullOrEmpty() || contents.IsNullOrEmpty())
			{
				return Guid.Empty;
			}
			if (userName.IsNullOrEmpty())
			{
				userName = new Users().GetName(userID);
			}
			RoadFlow.Data.Model.ShortMessage shortMessage = new RoadFlow.Data.Model.ShortMessage();
			shortMessage.Contents = contents;
			shortMessage.ID = (msgID.IsGuid() ? msgID.ToGuid() : Guid.NewGuid());
			shortMessage.LinkID = linkID;
			shortMessage.LinkUrl = linkUrl;
			shortMessage.ReceiveUserID = userID;
			shortMessage.ReceiveUserName = userName;
			shortMessage.SendTime = DateTimeNew.Now;
			shortMessage.SendUserID = Users.CurrentUserID;
			shortMessage.SendUserName = Users.CurrentUserName;
			shortMessage.Status = 0;
			shortMessage.Title = title;
			shortMessage.Type = msgType;
			new ShortMessage().Add(shortMessage);
			string empty = string.Empty;
			SiganalR(contents: linkUrl.IsNullOrEmpty() ? shortMessage.Contents : ("<a class=\"blue1\" href=\"" + linkUrl + "\">" + shortMessage.Contents + "</a>"), userID: userID, id: shortMessage.ID.ToString(), title: title);
			return shortMessage.ID;
		}

		public static void SiganalR(Guid userID, string id, string title, string contents)
		{
			IPersistentConnectionContext connectionContext = GlobalHost.ConnectionManager.GetConnectionContext<SignalRConnection>();
			JsonData jsonData = new JsonData();
			jsonData["id"] = id;
			jsonData["title"] = title;
			jsonData["contents"] = contents;
			jsonData["count"] = new ShortMessage().GetAllNoReadByUserID(userID).Count;
			connectionContext.Groups.Send(userID.ToString().ToLower(), (object)jsonData.ToJson(), new string[0]);
		}

		public int Add(RoadFlow.Data.Model.ShortMessage model)
		{
			return dataShortMessage.Add(model);
		}

		public int Update(RoadFlow.Data.Model.ShortMessage model)
		{
			return dataShortMessage.Update(model);
		}

		public List<RoadFlow.Data.Model.ShortMessage> GetAll()
		{
			return dataShortMessage.GetAll();
		}

		public RoadFlow.Data.Model.ShortMessage Get(Guid id)
		{
			return dataShortMessage.Get(id);
		}

		public RoadFlow.Data.Model.ShortMessage GetRead(Guid id)
		{
			return dataShortMessage.GetRead(id);
		}

		public int Delete(Guid id)
		{
			return dataShortMessage.Delete(id);
		}

		public long GetCount()
		{
			return dataShortMessage.GetCount();
		}

		public List<RoadFlow.Data.Model.ShortMessage> GetAllNoReadByUserID(Guid userID)
		{
			return dataShortMessage.GetAllNoReadByUserID(userID);
		}

		public List<RoadFlow.Data.Model.ShortMessage> GetAllNoRead()
		{
			return dataShortMessage.GetAllNoRead();
		}

		public int UpdateStatus(Guid id)
		{
			return dataShortMessage.UpdateStatus(id);
		}

		public List<RoadFlow.Data.Model.ShortMessage> GetList(out string pager, int[] status, string query = "", string title = "", string contents = "", string senderID = "", string date1 = "", string date2 = "", string receiveID = "")
		{
			senderID = Tools.GetSqlInString(new Organize().GetAllUsersIdList(senderID).ToArray());
			return dataShortMessage.GetList(out pager, status, query, title, contents, senderID, date1, date2, receiveID);
		}

		public List<RoadFlow.Data.Model.ShortMessage> GetList(out long count, int[] status, int size, int number, string title = "", string contents = "", string senderID = "", string date1 = "", string date2 = "", string receiveID = "", string order = "")
		{
			return dataShortMessage.GetList(out count, status, size, number, title, contents, senderID, date1, date2, receiveID, order);
		}

		public int Delete(string linkID, int type)
		{
			return dataShortMessage.Delete(linkID, type);
		}

		public bool SendToWeiXin(RoadFlow.Data.Model.ShortMessage msg, string userAccounts)
		{
			if (msg == null)
			{
				return false;
			}
			Message message = new Message();
			string[] imageUrlFromHTML = Tools.GetImageUrlFromHTML(msg.Contents);
			int agentIDByCode = new Agents().GetAgentIDByCode("weixinagents_infocenter");
			if (imageUrlFromHTML.Length != 0)
			{
				string item = RoadFlow.Platform.WeiXin.Config.WebUrl + imageUrlFromHTML[0];
				List<Tuple<string, string, string, string>> list = new List<Tuple<string, string, string, string>>();
				list.Add(new Tuple<string, string, string, string>(msg.Title, msg.Contents.RemoveHTML().CutString(100), RoadFlow.Platform.WeiXin.Config.WebUrl + RoadFlow.Utility.Config.BaseUrl + "/Platform/Info/ShortMessage/Show.aspx?id=" + msg.ID.ToString(), item));
				message.SendNews(list, userAccounts, "", "", agentIDByCode);
			}
			else
			{
				message.SendText(msg.Contents.RemoveHTML().CutString(100) + "\n点击链接阅读全文：" + RoadFlow.Platform.WeiXin.Config.WebUrl + RoadFlow.Utility.Config.BaseUrl + "Platform/Info/ShortMessage/Show.aspx?id=" + msg.ID.ToString(), userAccounts, "", "", 0, agentIDByCode);
			}
			return true;
		}
	}
}
