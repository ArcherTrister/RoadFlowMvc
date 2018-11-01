using System.Collections.Generic;
using System.Data;

namespace RoadFlow.Data.Interface
{
	public interface IDBHelper
	{
		DataTable GetDataTable(string sql);

		DataSet GetDataSet(string sql);

		int Execute(string sql);

		int Execute(List<string> sqlList);

		string ExecuteScalar(string sql);

		string GetFieldValue(string sql);
	}
}
