using RoadFlow.Data.Model;
using System;
using System.Collections.Generic;
using System.Data;

namespace RoadFlow.Data.Interface
{
	public interface ILog
	{
		int Add(Log model);

		int Update(Log model);

		List<Log> GetAll();

		Log Get(Guid id);

		int Delete(Guid id);

		long GetCount();

		DataTable GetPagerData(out string pager, string query = "", int size = 15, int number = 1, string title = "", string type = "", string date1 = "", string date2 = "", string userID = "");

		DataTable GetPagerData(out long count, int size = 15, int number = 1, string title = "", string type = "", string date1 = "", string date2 = "", string userID = "", string order = "");
	}
}
