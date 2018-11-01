using RoadFlow.Data.Factory;
using RoadFlow.Data.Interface;
using RoadFlow.Data.Model;
using System;
using System.Collections.Generic;
using System.Text;

namespace RoadFlow.Platform
{
	public class WorkGroup
	{
		public const string PREFIX = "w_";

		private IWorkGroup dataWorkGroup;

		public WorkGroup()
		{
			dataWorkGroup = Factory.GetWorkGroup();
		}

		public int Add(RoadFlow.Data.Model.WorkGroup model)
		{
			return dataWorkGroup.Add(model);
		}

		public int Update(RoadFlow.Data.Model.WorkGroup model)
		{
			return dataWorkGroup.Update(model);
		}

		public List<RoadFlow.Data.Model.WorkGroup> GetAll()
		{
			return dataWorkGroup.GetAll();
		}

		public RoadFlow.Data.Model.WorkGroup Get(Guid id)
		{
			return dataWorkGroup.Get(id);
		}

		public int Delete(Guid id)
		{
			return dataWorkGroup.Delete(id);
		}

		public long GetCount()
		{
			return dataWorkGroup.GetCount();
		}

		public string GetName(Guid id)
		{
			RoadFlow.Data.Model.WorkGroup workGroup = Get(id);
			if (workGroup != null)
			{
				return workGroup.Name;
			}
			return "";
		}

		public static string RemovePrefix(string id)
		{
			if (!id.IsNullOrEmpty())
			{
				return id.Replace("w_", "");
			}
			return "";
		}

		public string RemovePrefix1(string id)
		{
			if (!id.IsNullOrEmpty())
			{
				return id.Replace("w_", "");
			}
			return "";
		}

		public string GetUsersNames(string members, char split = ',')
		{
			if (members.IsNullOrEmpty())
			{
				return "";
			}
			StringBuilder stringBuilder = new StringBuilder();
			foreach (RoadFlow.Data.Model.Users allUser in new Organize().GetAllUsers(members))
			{
				stringBuilder.Append(allUser.Name);
				stringBuilder.Append(split);
			}
			return stringBuilder.ToString().TrimEnd(split);
		}

		public string GetUsersNames(RoadFlow.Data.Model.WorkGroup wg, char split = ',')
		{
			if (wg == null || wg.Members.IsNullOrEmpty())
			{
				return "";
			}
			return GetUsersNames(wg.Members, split);
		}

		public string GetUsersNames(Guid wgID, char split = ',')
		{
			RoadFlow.Data.Model.WorkGroup wg = Get(wgID);
			return GetUsersNames(wg, split);
		}

		public List<RoadFlow.Data.Model.WorkGroup> GetAllByUserID(Guid userID)
		{
			List<RoadFlow.Data.Model.WorkGroup> all = GetAll();
			Organize organize = new Organize();
			List<RoadFlow.Data.Model.WorkGroup> list = new List<RoadFlow.Data.Model.WorkGroup>();
			foreach (RoadFlow.Data.Model.WorkGroup item in all)
			{
				if (organize.GetAllUsers(item.Members).Find((RoadFlow.Data.Model.Users p) => p.ID == userID) != null)
				{
					list.Add(item);
				}
			}
			return list;
		}

		public string GetAllNamesByUserID(Guid userID)
		{
			List<RoadFlow.Data.Model.WorkGroup> allByUserID = GetAllByUserID(userID);
			StringBuilder stringBuilder = new StringBuilder();
			foreach (RoadFlow.Data.Model.WorkGroup item in allByUserID)
			{
				stringBuilder.Append(item.Name);
				stringBuilder.Append(",");
			}
			return stringBuilder.ToString().TrimEnd(',');
		}
	}
}
