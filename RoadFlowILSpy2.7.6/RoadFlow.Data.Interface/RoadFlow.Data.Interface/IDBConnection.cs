using RoadFlow.Data.Model;
using System;
using System.Collections.Generic;

namespace RoadFlow.Data.Interface
{
	public interface IDBConnection
	{
		int Add(DBConnection model);

		int Update(DBConnection model);

		List<DBConnection> GetAll();

		DBConnection Get(Guid id);

		int Delete(Guid id);

		long GetCount();
	}
}
