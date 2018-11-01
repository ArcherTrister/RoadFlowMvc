using RoadFlow.Data.Factory;
using RoadFlow.Data.Interface;
using RoadFlow.Data.Model;
using System;
using System.Collections.Generic;
using System.Data;

namespace RoadFlow.Platform
{
	public class Documents
	{
		private IDocuments dataDocuments;

		public Documents()
		{
			dataDocuments = Factory.GetDocuments();
		}

		public int Add(RoadFlow.Data.Model.Documents model)
		{
			return dataDocuments.Add(model);
		}

		public int Update(RoadFlow.Data.Model.Documents model)
		{
			return dataDocuments.Update(model);
		}

		public List<RoadFlow.Data.Model.Documents> GetAll()
		{
			return dataDocuments.GetAll();
		}

		public RoadFlow.Data.Model.Documents Get(Guid id)
		{
			return dataDocuments.Get(id);
		}

		public int Delete(Guid id)
		{
			return dataDocuments.Delete(id);
		}

		public long GetCount()
		{
			return dataDocuments.GetCount();
		}

		public DataTable GetList(out string pager, string dirID, string userID, string query = "", string title = "", string date1 = "", string date2 = "", bool isNoRead = false)
		{
			return dataDocuments.GetList(out pager, dirID, userID, query, title, date1, date2, isNoRead);
		}

		public DataTable GetList(out long count, int size, int number, string dirID, string userID, string title = "", string date1 = "", string date2 = "", bool isNoRead = false, string order = "")
		{
			return dataDocuments.GetList(out count, size, number, dirID, userID, title, date1, date2, isNoRead, order);
		}

		public void UpdateReadCount(Guid id)
		{
			dataDocuments.UpdateReadCount(id);
		}

		public int DeleteByDirectoryID(Guid directoryID)
		{
			return dataDocuments.DeleteByDirectoryID(directoryID);
		}
	}
}
