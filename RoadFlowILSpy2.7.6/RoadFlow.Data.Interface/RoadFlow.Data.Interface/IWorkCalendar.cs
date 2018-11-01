using RoadFlow.Data.Model;
using System;
using System.Collections.Generic;

namespace RoadFlow.Data.Interface
{
	public interface IWorkCalendar
	{
		int Add(WorkCalendar model);

		int Update(WorkCalendar model);

		List<WorkCalendar> GetAll();

		WorkCalendar Get(DateTime workdate);

		int Delete(DateTime workdate);

		long GetCount();

		int Delete(int year);

		List<WorkCalendar> GetAll(int year);
	}
}
