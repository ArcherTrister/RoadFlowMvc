using RoadFlow.Cache.IO;
using RoadFlow.Data.Factory;
using RoadFlow.Data.Interface;
using RoadFlow.Data.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace RoadFlow.Platform
{
	public class WorkFlowComment
	{
		private IWorkFlowComment dataWorkFlowComment;

		public WorkFlowComment()
		{
			dataWorkFlowComment = Factory.GetWorkFlowComment();
		}

		public int Add(RoadFlow.Data.Model.WorkFlowComment model)
		{
			return dataWorkFlowComment.Add(model);
		}

		public int Update(RoadFlow.Data.Model.WorkFlowComment model)
		{
			return dataWorkFlowComment.Update(model);
		}

		public List<RoadFlow.Data.Model.WorkFlowComment> GetAll()
		{
			return dataWorkFlowComment.GetAll();
		}

		public RoadFlow.Data.Model.WorkFlowComment Get(Guid id)
		{
			return dataWorkFlowComment.Get(id);
		}

		public int Delete(Guid id)
		{
			return dataWorkFlowComment.Delete(id);
		}

		public long GetCount()
		{
			return dataWorkFlowComment.GetCount();
		}

		public List<RoadFlow.Data.Model.WorkFlowComment> GetManagerAll()
		{
			return dataWorkFlowComment.GetManagerAll();
		}

		public int GetManagerMaxSort()
		{
			return dataWorkFlowComment.GetManagerMaxSort();
		}

		public int GetUserMaxSort(Guid userID)
		{
			return dataWorkFlowComment.GetUserMaxSort(userID);
		}

		private List<Tuple<Guid, string, int, int, List<Guid>>> GetAllList(bool fromCache = true)
		{
			string key = 8.ToString();
			if (!fromCache)
			{
				return getAllListByDb();
			}
			object obj = Opation.Get(key);
			if (obj == null)
			{
				List<Tuple<Guid, string, int, int, List<Guid>>> allListByDb = getAllListByDb();
				Opation.Set(key, allListByDb);
				return allListByDb;
			}
			return (List<Tuple<Guid, string, int, int, List<Guid>>>)obj;
		}

		private List<Tuple<Guid, string, int, int, List<Guid>>> getAllListByDb()
		{
			List<RoadFlow.Data.Model.WorkFlowComment> all = GetAll();
			Organize organize = new Organize();
			List<Tuple<Guid, string, int, int, List<Guid>>> list = new List<Tuple<Guid, string, int, int, List<Guid>>>();
			foreach (RoadFlow.Data.Model.WorkFlowComment item2 in all)
			{
				List<Guid> list2 = new List<Guid>();
				if (!item2.MemberID.IsNullOrEmpty())
				{
					foreach (RoadFlow.Data.Model.Users allUser in organize.GetAllUsers(item2.MemberID))
					{
						list2.Add(allUser.ID);
					}
				}
				Tuple<Guid, string, int, int, List<Guid>> item = new Tuple<Guid, string, int, int, List<Guid>>(item2.ID, item2.Comment, item2.Type, item2.Sort, list2);
				list.Add(item);
			}
			return list;
		}

		public void ClearCache()
		{
			Opation.Remove(8.ToString());
		}

		public void RefreshCache()
		{
			Opation.Set(8.ToString(), getAllListByDb());
		}

		public List<string> GetListByUserID(Guid userID)
		{
			IOrderedEnumerable<Tuple<Guid, string, int, int, List<Guid>>> source = from p in GetAllList().Where(delegate(Tuple<Guid, string, int, int, List<Guid>> p)
			{
				if (p.Item5.Count != 0)
				{
					return p.Item5.Exists((Guid q) => q == userID);
				}
				return true;
			})
			orderby p.Item3 descending, p.Item4
			select p;
			List<string> list = new List<string>();
			foreach (Tuple<Guid, string, int, int, List<Guid>> item in from p in source
			orderby p.Item3, p.Item4
			select p)
			{
				if (!list.Contains(item.Item2))
				{
					list.Add(item.Item2);
				}
			}
			return list;
		}

		public string GetOptionsStringByUserID(Guid userID)
		{
			List<string> listByUserID = GetListByUserID(userID);
			StringBuilder stringBuilder = new StringBuilder();
			foreach (string item in listByUserID)
			{
				stringBuilder.AppendFormat("<option value=\"{0}\">{0}</option>", item);
			}
			return stringBuilder.ToString();
		}
	}
}
