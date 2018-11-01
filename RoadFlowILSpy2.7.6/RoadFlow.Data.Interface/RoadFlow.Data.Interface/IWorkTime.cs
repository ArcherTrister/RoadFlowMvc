using RoadFlow.Data.Model;
using System;
using System.Collections.Generic;

namespace RoadFlow.Data.Interface
{
	public interface IWorkTime
	{
		int Add(WorkTime model);

		int Update(WorkTime model);

		List<WorkTime> GetAll();

		WorkTime Get(Guid id);

		int Delete(Guid id);

		long GetCount();

		List<int> GetAllYear();

		List<WorkTime> GetAll(int year);
	}
}
