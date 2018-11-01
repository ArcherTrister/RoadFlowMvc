using RoadFlow.Data.Model;
using System;
using System.Collections.Generic;

namespace RoadFlow.Data.Interface
{
	public interface IWorkFlowData
	{
		int Add(WorkFlowData model);

		int Update(WorkFlowData model);

		List<WorkFlowData> GetAll();

		WorkFlowData Get(Guid id);

		int Delete(Guid id);

		long GetCount();

		List<WorkFlowData> GetAll(Guid instanceID);
	}
}
