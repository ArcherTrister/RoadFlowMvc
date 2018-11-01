using RoadFlow.Data.Model;
using System;
using System.Collections.Generic;
using System.Data;

namespace RoadFlow.Data.Interface
{
	public interface IDocuments
	{
		int Add(Documents model);

		int Update(Documents model);

		List<Documents> GetAll();

		Documents Get(Guid id);

		int Delete(Guid id);

		long GetCount();

		DataTable GetList(out string pager, string dirID, string userID, string query = "", string title = "", string date1 = "", string date2 = "", bool isNoRead = false);

		DataTable GetList(out long count, int size, int number, string dirID, string userID, string title = "", string date1 = "", string date2 = "", bool isNoRead = false, string order = "");

		void UpdateReadCount(Guid id);

		int DeleteByDirectoryID(Guid directoryID);
	}
}
