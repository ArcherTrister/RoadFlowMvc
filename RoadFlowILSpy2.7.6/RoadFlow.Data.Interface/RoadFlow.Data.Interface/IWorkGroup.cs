using RoadFlow.Data.Model;
using System;
using System.Collections.Generic;

namespace RoadFlow.Data.Interface
{
	public interface IWorkGroup
	{
		int Add(WorkGroup model);

		int Update(WorkGroup model);

		List<WorkGroup> GetAll();

		WorkGroup Get(Guid id);

		int Delete(Guid id);

		long GetCount();
	}
}
