using RoadFlow.Cache.IO;
using RoadFlow.Data.Factory;
using RoadFlow.Data.Interface;
using RoadFlow.Data.Model;
using RoadFlow.Utility;
using System;
using System.Collections.Generic;
using System.Linq;

namespace RoadFlow.Platform
{
	public class WorkFlowDelegation
	{
		private IWorkFlowDelegation dataWorkFlowDelegation;

		private static string cacheKey = 10.ToString();

		public WorkFlowDelegation()
		{
			dataWorkFlowDelegation = Factory.GetWorkFlowDelegation();
		}

		public int Add(RoadFlow.Data.Model.WorkFlowDelegation model)
		{
			return dataWorkFlowDelegation.Add(model);
		}

		public int Update(RoadFlow.Data.Model.WorkFlowDelegation model)
		{
			return dataWorkFlowDelegation.Update(model);
		}

		public List<RoadFlow.Data.Model.WorkFlowDelegation> GetAll()
		{
			return dataWorkFlowDelegation.GetAll();
		}

		public RoadFlow.Data.Model.WorkFlowDelegation Get(Guid id)
		{
			return dataWorkFlowDelegation.Get(id);
		}

		public int Delete(Guid id)
		{
			return dataWorkFlowDelegation.Delete(id);
		}

		public long GetCount()
		{
			return dataWorkFlowDelegation.GetCount();
		}

		public List<RoadFlow.Data.Model.WorkFlowDelegation> GetByUserID(Guid userID)
		{
			return dataWorkFlowDelegation.GetByUserID(userID);
		}

		public List<RoadFlow.Data.Model.WorkFlowDelegation> GetPagerData(out string pager, string query = "", string userID = "", string startTime = "", string endTime = "")
		{
			return dataWorkFlowDelegation.GetPagerData(out pager, query, userID, startTime, endTime);
		}

		public List<RoadFlow.Data.Model.WorkFlowDelegation> GetPagerData(out long count, int pageSize, int pageNumber, string userID = "", string startTime = "", string endTime = "", string order = "")
		{
			return dataWorkFlowDelegation.GetPagerData(out count, pageSize, pageNumber, userID, startTime, endTime, order);
		}

		public List<RoadFlow.Data.Model.WorkFlowDelegation> GetNoExpiredList()
		{
			return dataWorkFlowDelegation.GetNoExpiredList();
		}

		public void RefreshCache()
		{
			List<RoadFlow.Data.Model.WorkFlowDelegation> noExpiredList = GetNoExpiredList();
			Opation.Set(cacheKey, noExpiredList);
		}

		public List<RoadFlow.Data.Model.WorkFlowDelegation> GetNoExpiredListFromCache()
		{
			object obj = Opation.Get(cacheKey);
			if (obj != null && obj is List<RoadFlow.Data.Model.WorkFlowDelegation>)
			{
				return (List<RoadFlow.Data.Model.WorkFlowDelegation>)obj;
			}
			List<RoadFlow.Data.Model.WorkFlowDelegation> noExpiredList = GetNoExpiredList();
			Opation.Set(cacheKey, noExpiredList);
			return noExpiredList;
		}

		public Guid GetFlowDelegationByUserID(Guid flowID, Guid userID)
		{
			List<RoadFlow.Data.Model.WorkFlowDelegation> noExpiredListFromCache = GetNoExpiredListFromCache();
			if (noExpiredListFromCache.Count != 0)
			{
				Guid empty = Guid.Empty;
				IEnumerable<RoadFlow.Data.Model.WorkFlowDelegation> source = noExpiredListFromCache.Where(delegate(RoadFlow.Data.Model.WorkFlowDelegation p)
				{
					if (p.UserID == userID && (!p.FlowID.HasValue || p.FlowID.Value == Guid.Empty || p.FlowID.Value == flowID) && p.StartTime <= DateTimeNew.Now)
					{
						return p.EndTime >= DateTimeNew.Now;
					}
					return false;
				});
				return getFlowDelegationByUserID1(userID: (source.Count() != 0) ? (from p in source
				orderby p.WriteTime descending
				select p).First().ToUserID : Guid.Empty, flowID: flowID, list: noExpiredListFromCache);
			}
			return Guid.Empty;
		}

		private Guid getFlowDelegationByUserID1(Guid flowID, Guid userID, List<RoadFlow.Data.Model.WorkFlowDelegation> list)
		{
			IEnumerable<RoadFlow.Data.Model.WorkFlowDelegation> source = list.Where(delegate(RoadFlow.Data.Model.WorkFlowDelegation p)
			{
				if (p.UserID == userID && (!p.FlowID.HasValue || p.FlowID.Value == Guid.Empty || p.FlowID.Value == flowID) && p.StartTime <= DateTimeNew.Now)
				{
					return p.EndTime >= DateTimeNew.Now;
				}
				return false;
			});
			if (source.Count() == 0)
			{
				return userID;
			}
			userID = (from p in source
			orderby p.WriteTime descending
			select p).First().ToUserID;
			getFlowDelegationByUserID1(flowID, userID, list);
			return Guid.Empty;
		}
	}
}
