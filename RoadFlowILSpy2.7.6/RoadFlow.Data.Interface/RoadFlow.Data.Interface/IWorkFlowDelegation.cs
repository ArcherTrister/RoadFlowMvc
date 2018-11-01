using RoadFlow.Data.Model;
using System;
using System.Collections.Generic;

namespace RoadFlow.Data.Interface
{
	public interface IWorkFlowDelegation
	{
		int Add(WorkFlowDelegation model);

		int Update(WorkFlowDelegation model);

		List<WorkFlowDelegation> GetAll();

		WorkFlowDelegation Get(Guid id);

		int Delete(Guid id);

		long GetCount();

		List<WorkFlowDelegation> GetByUserID(Guid userID);

		List<WorkFlowDelegation> GetPagerData(out string pager, string query = "", string userID = "", string startTime = "", string endTime = "");

		List<WorkFlowDelegation> GetPagerData(out long count, int pageSize, int pageNumber, string userID = "", string startTime = "", string endTime = "", string order = "");

		List<WorkFlowDelegation> GetNoExpiredList();
	}
}
