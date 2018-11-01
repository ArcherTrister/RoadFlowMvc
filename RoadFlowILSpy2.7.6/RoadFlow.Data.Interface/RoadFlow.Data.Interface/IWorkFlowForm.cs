using RoadFlow.Data.Model;
using System;
using System.Collections.Generic;

namespace RoadFlow.Data.Interface
{
	public interface IWorkFlowForm
	{
		int Add(WorkFlowForm model);

		int Update(WorkFlowForm model);

		List<WorkFlowForm> GetAll();

		WorkFlowForm Get(Guid id);

		int Delete(Guid id);

		long GetCount();

		List<WorkFlowForm> GetAllByType(string types);

		List<WorkFlowForm> GetPagerData(out string pager, string query = "", string userid = "", string typeid = "", string name = "", int pagesize = 15);

		List<WorkFlowForm> GetPagerData(out long count, int pageSize, int pageNumber, string userid = "", string typeid = "", string name = "", string order = "");
	}
}
