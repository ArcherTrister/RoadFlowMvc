using RoadFlow.Data.Model;
using System;
using System.Collections.Generic;
using System.Data;

namespace RoadFlow.Data.Interface
{
	public interface IWorkFlowArchives
	{
		int Add(WorkFlowArchives model);

		int Update(WorkFlowArchives model);

		List<WorkFlowArchives> GetAll();

		WorkFlowArchives Get(Guid id);

		int Delete(Guid id);

		long GetCount();

		DataTable GetPagerData(out string pager, string query = "", string title = "", string flowIDString = "");

		DataTable GetPagerData(out long count, int pageSize, int pageNumber, string title = "", string flowIDString = "", string date1 = "", string date2 = "", string order = "");
	}
}
