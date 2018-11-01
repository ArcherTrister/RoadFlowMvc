using RoadFlow.Data.Factory;
using RoadFlow.Data.Interface;
using RoadFlow.Data.Model;
using System;
using System.Collections.Generic;
using System.Data;

namespace RoadFlow.Platform
{
	public class WorkFlowArchives
	{
		private IWorkFlowArchives dataWorkFlowArchives;

		public WorkFlowArchives()
		{
			dataWorkFlowArchives = Factory.GetWorkFlowArchives();
		}

		public int Add(RoadFlow.Data.Model.WorkFlowArchives model)
		{
			return dataWorkFlowArchives.Add(model);
		}

		public int Update(RoadFlow.Data.Model.WorkFlowArchives model)
		{
			return dataWorkFlowArchives.Update(model);
		}

		public List<RoadFlow.Data.Model.WorkFlowArchives> GetAll()
		{
			return dataWorkFlowArchives.GetAll();
		}

		public RoadFlow.Data.Model.WorkFlowArchives Get(Guid id)
		{
			return dataWorkFlowArchives.Get(id);
		}

		public int Delete(Guid id)
		{
			return dataWorkFlowArchives.Delete(id);
		}

		public long GetCount()
		{
			return dataWorkFlowArchives.GetCount();
		}

		public DataTable GetPagerData(out string pager, string query = "", string title = "", string flowIDString = "")
		{
			return dataWorkFlowArchives.GetPagerData(out pager, query, title, flowIDString);
		}

		public DataTable GetPagerData(out long count, int pageSize, int pageNumber, string title = "", string flowIDString = "", string date1 = "", string date2 = "", string order = "")
		{
			return dataWorkFlowArchives.GetPagerData(out count, pageSize, pageNumber, title, flowIDString, date1, date2, order);
		}
	}
}
