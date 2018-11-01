using RoadFlow.Cache.IO;
using RoadFlow.Data.Model;
using RoadFlow.Utility;
using System;
using System.Collections.Generic;

namespace RoadFlow.Platform
{
	public class OnlineUsers
	{
		private string key = 9.ToString();

		public List<RoadFlow.Data.Model.OnlineUsers> GetAll()
		{
			object obj = Opation.Get(key);
			if (obj == null || !(obj is List<RoadFlow.Data.Model.OnlineUsers>))
			{
				return new List<RoadFlow.Data.Model.OnlineUsers>();
			}
			return (List<RoadFlow.Data.Model.OnlineUsers>)obj;
		}

		private void set(List<RoadFlow.Data.Model.OnlineUsers> list)
		{
			if (list != null)
			{
				Opation.Set(key, list);
			}
		}

		public bool Add(RoadFlow.Data.Model.Users user, Guid uniqueID)
		{
			if (user == null)
			{
				return false;
			}
			List<RoadFlow.Data.Model.OnlineUsers> all = GetAll();
			bool flag = false;
			RoadFlow.Data.Model.OnlineUsers onlineUsers = all.Find((RoadFlow.Data.Model.OnlineUsers p) => p.ID == user.ID);
			if (onlineUsers == null)
			{
				flag = true;
				onlineUsers = new RoadFlow.Data.Model.OnlineUsers();
				RoadFlow.Data.Model.UsersRelation mainByUserID = new UsersRelation().GetMainByUserID(user.ID);
				if (mainByUserID != null)
				{
					onlineUsers.OrgName = new Organize().GetAllParentNames(mainByUserID.OrganizeID);
				}
			}
			onlineUsers.ID = user.ID;
			onlineUsers.ClientInfo = "操作系统：" + Tools.GetOSName() + "  浏览器：" + Tools.GetBrowse();
			onlineUsers.IP = Tools.GetIPAddress();
			onlineUsers.LastPage = "";
			onlineUsers.LoginTime = DateTimeNew.Now;
			onlineUsers.UniqueID = uniqueID;
			onlineUsers.UserName = user.Name;
			if (flag)
			{
				all.Add(onlineUsers);
			}
			set(all);
			return true;
		}

		public bool Remove(Guid userID)
		{
			List<RoadFlow.Data.Model.OnlineUsers> all = GetAll();
			RoadFlow.Data.Model.OnlineUsers onlineUsers = all.Find((RoadFlow.Data.Model.OnlineUsers p) => p.ID == userID);
			if (onlineUsers != null)
			{
				all.Remove(onlineUsers);
			}
			set(all);
			return true;
		}

		public bool RemoveAll()
		{
			List<RoadFlow.Data.Model.OnlineUsers> obj = new List<RoadFlow.Data.Model.OnlineUsers>();
			Opation.Set(key, obj);
			return true;
		}

		public RoadFlow.Data.Model.OnlineUsers Get(Guid userID)
		{
			return GetAll().Find((RoadFlow.Data.Model.OnlineUsers p) => p.ID == userID);
		}
	}
}
