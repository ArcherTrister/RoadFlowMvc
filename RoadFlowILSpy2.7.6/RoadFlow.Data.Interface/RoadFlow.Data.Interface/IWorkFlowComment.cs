using RoadFlow.Data.Model;
using System;
using System.Collections.Generic;

namespace RoadFlow.Data.Interface
{
	public interface IWorkFlowComment
	{
		int Add(WorkFlowComment model);

		int Update(WorkFlowComment model);

		List<WorkFlowComment> GetAll();

		WorkFlowComment Get(Guid id);

		int Delete(Guid id);

		long GetCount();

		List<WorkFlowComment> GetManagerAll();

		int GetManagerMaxSort();

		int GetUserMaxSort(Guid userID);
	}
}
