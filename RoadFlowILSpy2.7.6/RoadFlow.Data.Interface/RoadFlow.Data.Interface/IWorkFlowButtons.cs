using RoadFlow.Data.Model;
using System;
using System.Collections.Generic;

namespace RoadFlow.Data.Interface
{
	public interface IWorkFlowButtons
	{
		int Add(WorkFlowButtons model);

		int Update(WorkFlowButtons model);

		List<WorkFlowButtons> GetAll();

		WorkFlowButtons Get(Guid id);

		int Delete(Guid id);

		long GetCount();

		int GetMaxSort();
	}
}
