using MySql.Data.MySqlClient;
using RoadFlow.Data.Interface;
using RoadFlow.Utility;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.Common;
using System.Text;

namespace RoadFlow.Data.MySql
{
	public class DBHelper : IDBHelper
	{
		private string connectionString;

		public string ConnectionString
		{
			get
			{
				return connectionString;
			}
		}

		public DBHelper()
		{
			connectionString = Config.PlatformConnectionStringMySql;
		}

		public DBHelper(string connString)
		{
			connectionString = connString;
		}

		public void Dispose()
		{
		}

		public MySqlDataReader GetDataReader(string sql)
		{
			//IL_0006: Unknown result type (might be due to invalid IL or missing references)
			//IL_000c: Expected O, but got Unknown
			//IL_0014: Unknown result type (might be due to invalid IL or missing references)
			//IL_001a: Expected O, but got Unknown
			MySqlConnection val = new MySqlConnection(ConnectionString);
			((DbConnection)val).Open();
			MySqlCommand val2 = new MySqlCommand(sql, val);
			try
			{
				((DbCommand)val2).CommandTimeout = 180;
				((DbCommand)val2).Prepare();
				return val2.ExecuteReader(CommandBehavior.CloseConnection);
			}
			finally
			{
				if (val2 != null)
				{
					((IDisposable)val2).Dispose();
				}
			}
		}

		public MySqlDataReader GetDataReader(string sql, MySqlParameter[] parameter)
		{
			//IL_0006: Unknown result type (might be due to invalid IL or missing references)
			//IL_000c: Expected O, but got Unknown
			//IL_0014: Unknown result type (might be due to invalid IL or missing references)
			//IL_001a: Expected O, but got Unknown
			MySqlConnection val = new MySqlConnection(ConnectionString);
			((DbConnection)val).Open();
			MySqlCommand val2 = new MySqlCommand(sql, val);
			try
			{
				((DbCommand)val2).CommandTimeout = 180;
				if (parameter != null && parameter.Length != 0)
				{
					((DbParameterCollection)val2.get_Parameters()).AddRange((Array)parameter);
				}
				MySqlDataReader result = val2.ExecuteReader(CommandBehavior.CloseConnection);
				((DbParameterCollection)val2.get_Parameters()).Clear();
				((DbCommand)val2).Prepare();
				return result;
			}
			finally
			{
				if (val2 != null)
				{
					((IDisposable)val2).Dispose();
				}
			}
		}

		public DataTable GetDataTable(string sql)
		{
			//IL_0006: Unknown result type (might be due to invalid IL or missing references)
			//IL_000c: Expected O, but got Unknown
			//IL_0014: Unknown result type (might be due to invalid IL or missing references)
			//IL_001a: Expected O, but got Unknown
			MySqlConnection val = new MySqlConnection(ConnectionString);
			try
			{
				((DbConnection)val).Open();
				MySqlDataAdapter val2 = new MySqlDataAdapter(sql, val);
				try
				{
					DataTable dataTable = new DataTable();
					((DbDataAdapter)val2).Fill(dataTable);
					((Component)val2).Dispose();
					return dataTable;
				}
				finally
				{
					if (val2 != null)
					{
						((IDisposable)val2).Dispose();
					}
				}
			}
			finally
			{
				if (val != null)
				{
					((IDisposable)val).Dispose();
				}
			}
		}

		public DataTable GetDataTable(string sql, MySqlParameter[] parameter)
		{
			//IL_0006: Unknown result type (might be due to invalid IL or missing references)
			//IL_000c: Expected O, but got Unknown
			//IL_0014: Unknown result type (might be due to invalid IL or missing references)
			//IL_001a: Expected O, but got Unknown
			//IL_0039: Unknown result type (might be due to invalid IL or missing references)
			//IL_003f: Expected O, but got Unknown
			MySqlConnection val = new MySqlConnection(ConnectionString);
			try
			{
				((DbConnection)val).Open();
				MySqlCommand val2 = new MySqlCommand(sql, val);
				try
				{
					if (parameter != null && parameter.Length != 0)
					{
						((DbParameterCollection)val2.get_Parameters()).AddRange((Array)parameter);
					}
					((DbCommand)val2).CommandTimeout = 180;
					MySqlDataAdapter val3 = new MySqlDataAdapter(val2);
					try
					{
						DataTable dataTable = new DataTable();
						((DbDataAdapter)val3).Fill(dataTable);
						((Component)val3).Dispose();
						((DbParameterCollection)val2.get_Parameters()).Clear();
						((DbCommand)val2).Prepare();
						return dataTable;
					}
					finally
					{
						if (val3 != null)
						{
							((IDisposable)val3).Dispose();
						}
					}
				}
				finally
				{
					if (val2 != null)
					{
						((IDisposable)val2).Dispose();
					}
				}
			}
			finally
			{
				if (val != null)
				{
					((IDisposable)val).Dispose();
				}
			}
		}

		public DataSet GetDataSet(string sql)
		{
			//IL_0006: Unknown result type (might be due to invalid IL or missing references)
			//IL_000c: Expected O, but got Unknown
			//IL_0014: Unknown result type (might be due to invalid IL or missing references)
			//IL_001a: Expected O, but got Unknown
			MySqlConnection val = new MySqlConnection(ConnectionString);
			try
			{
				((DbConnection)val).Open();
				MySqlDataAdapter val2 = new MySqlDataAdapter(sql, val);
				try
				{
					DataSet dataSet = new DataSet();
					((DataAdapter)val2).Fill(dataSet);
					return dataSet;
				}
				finally
				{
					if (val2 != null)
					{
						((IDisposable)val2).Dispose();
					}
				}
			}
			finally
			{
				if (val != null)
				{
					((IDisposable)val).Dispose();
				}
			}
		}

		public int Execute(string sql)
		{
			//IL_0006: Unknown result type (might be due to invalid IL or missing references)
			//IL_000c: Expected O, but got Unknown
			//IL_0014: Unknown result type (might be due to invalid IL or missing references)
			//IL_001a: Expected O, but got Unknown
			MySqlConnection val = new MySqlConnection(ConnectionString);
			try
			{
				((DbConnection)val).Open();
				MySqlCommand val2 = new MySqlCommand(sql, val);
				try
				{
					((DbCommand)val2).Prepare();
					return ((DbCommand)val2).ExecuteNonQuery();
				}
				finally
				{
					if (val2 != null)
					{
						((IDisposable)val2).Dispose();
					}
				}
			}
			finally
			{
				if (val != null)
				{
					((IDisposable)val).Dispose();
				}
			}
		}

		public int Execute(List<string> sqlList)
		{
			//IL_0006: Unknown result type (might be due to invalid IL or missing references)
			//IL_000c: Expected O, but got Unknown
			//IL_0012: Unknown result type (might be due to invalid IL or missing references)
			//IL_0018: Expected O, but got Unknown
			MySqlConnection val = new MySqlConnection(ConnectionString);
			try
			{
				((DbConnection)val).Open();
				MySqlCommand val2 = new MySqlCommand();
				try
				{
					int num = 0;
					val2.set_Connection(val);
					foreach (string sql in sqlList)
					{
						((DbCommand)val2).CommandType = CommandType.Text;
						((DbCommand)val2).CommandText = sql;
						((DbCommand)val2).Prepare();
						num += ((DbCommand)val2).ExecuteNonQuery();
					}
					return num;
				}
				finally
				{
					if (val2 != null)
					{
						((IDisposable)val2).Dispose();
					}
				}
			}
			finally
			{
				if (val != null)
				{
					((IDisposable)val).Dispose();
				}
			}
		}

		public int Execute(string sql, MySqlParameter[] parameter, bool returnIdentity = false)
		{
			//IL_0006: Unknown result type (might be due to invalid IL or missing references)
			//IL_000c: Expected O, but got Unknown
			//IL_0014: Unknown result type (might be due to invalid IL or missing references)
			//IL_001a: Expected O, but got Unknown
			MySqlConnection val = new MySqlConnection(ConnectionString);
			try
			{
				((DbConnection)val).Open();
				MySqlCommand val2 = new MySqlCommand(sql, val);
				try
				{
					if (parameter != null && parameter.Length != 0)
					{
						((DbParameterCollection)val2.get_Parameters()).AddRange((Array)parameter);
					}
					int num = ((DbCommand)val2).ExecuteNonQuery();
					((DbParameterCollection)val2.get_Parameters()).Clear();
					((DbCommand)val2).Prepare();
					if (returnIdentity)
					{
						((DbCommand)val2).CommandText = "select @@IDENTITY";
						object obj = ((DbCommand)val2).ExecuteScalar();
						num = ((obj == null) ? num : obj.ToString().ToInt(num));
					}
					return num;
				}
				finally
				{
					if (val2 != null)
					{
						((IDisposable)val2).Dispose();
					}
				}
			}
			finally
			{
				if (val != null)
				{
					((IDisposable)val).Dispose();
				}
			}
		}

		public int Execute(List<string> sqlList, List<MySqlParameter[]> parameterList)
		{
			//IL_001f: Unknown result type (might be due to invalid IL or missing references)
			//IL_0025: Expected O, but got Unknown
			//IL_002b: Unknown result type (might be due to invalid IL or missing references)
			//IL_0031: Expected O, but got Unknown
			if (sqlList.Count <= parameterList.Count)
			{
				MySqlConnection val = new MySqlConnection(ConnectionString);
				try
				{
					((DbConnection)val).Open();
					MySqlCommand val2 = new MySqlCommand();
					try
					{
						int num = 0;
						val2.set_Connection(val);
						for (int i = 0; i < sqlList.Count; i++)
						{
							((DbCommand)val2).CommandType = CommandType.Text;
							((DbCommand)val2).CommandText = sqlList[i];
							if (parameterList[i] != null && parameterList[i].Length != 0)
							{
								((DbParameterCollection)val2.get_Parameters()).AddRange((Array)parameterList[i]);
							}
							num += ((DbCommand)val2).ExecuteNonQuery();
							((DbParameterCollection)val2.get_Parameters()).Clear();
							((DbCommand)val2).Prepare();
						}
						return num;
					}
					finally
					{
						if (val2 != null)
						{
							((IDisposable)val2).Dispose();
						}
					}
				}
				finally
				{
					if (val != null)
					{
						((IDisposable)val).Dispose();
					}
				}
			}
			throw new Exception("参数错误");
		}

		public string ExecuteScalar(string sql)
		{
			//IL_0006: Unknown result type (might be due to invalid IL or missing references)
			//IL_000c: Expected O, but got Unknown
			//IL_0014: Unknown result type (might be due to invalid IL or missing references)
			//IL_001a: Expected O, but got Unknown
			MySqlConnection val = new MySqlConnection(ConnectionString);
			try
			{
				((DbConnection)val).Open();
				MySqlCommand val2 = new MySqlCommand(sql, val);
				try
				{
					object obj = ((DbCommand)val2).ExecuteScalar();
					((DbCommand)val2).Prepare();
					return (obj != null) ? obj.ToString() : string.Empty;
				}
				finally
				{
					if (val2 != null)
					{
						((IDisposable)val2).Dispose();
					}
				}
			}
			finally
			{
				if (val != null)
				{
					((IDisposable)val).Dispose();
				}
			}
		}

		public string ExecuteScalar(string sql, MySqlParameter[] parameter)
		{
			//IL_0006: Unknown result type (might be due to invalid IL or missing references)
			//IL_000c: Expected O, but got Unknown
			//IL_0014: Unknown result type (might be due to invalid IL or missing references)
			//IL_001a: Expected O, but got Unknown
			MySqlConnection val = new MySqlConnection(ConnectionString);
			try
			{
				((DbConnection)val).Open();
				MySqlCommand val2 = new MySqlCommand(sql, val);
				try
				{
					if (parameter != null && parameter.Length != 0)
					{
						((DbParameterCollection)val2.get_Parameters()).AddRange((Array)parameter);
					}
					object obj = ((DbCommand)val2).ExecuteScalar();
					((DbParameterCollection)val2.get_Parameters()).Clear();
					((DbCommand)val2).Prepare();
					return (obj != null) ? obj.ToString() : string.Empty;
				}
				finally
				{
					if (val2 != null)
					{
						((IDisposable)val2).Dispose();
					}
				}
			}
			finally
			{
				if (val != null)
				{
					((IDisposable)val).Dispose();
				}
			}
		}

		public string GetFieldValue(string sql)
		{
			return ExecuteScalar(sql);
		}

		public string GetFieldValue(string sql, MySqlParameter[] parameter)
		{
			return ExecuteScalar(sql, parameter);
		}

		public string GetFields(string sql, MySqlParameter[] param)
		{
			//IL_0006: Unknown result type (might be due to invalid IL or missing references)
			//IL_000c: Expected O, but got Unknown
			//IL_001f: Unknown result type (might be due to invalid IL or missing references)
			//IL_0025: Expected O, but got Unknown
			MySqlConnection val = new MySqlConnection(ConnectionString);
			try
			{
				((DbConnection)val).Open();
				StringBuilder stringBuilder = new StringBuilder(500);
				MySqlCommand val2 = new MySqlCommand(sql, val);
				try
				{
					if (param != null && param.Length != 0)
					{
						((DbParameterCollection)val2.get_Parameters()).AddRange((Array)param);
					}
					MySqlDataReader val3 = val2.ExecuteReader(CommandBehavior.SchemaOnly);
					for (int i = 0; i < ((DbDataReader)val3).FieldCount; i++)
					{
						stringBuilder.Append("[" + ((DbDataReader)val3).GetName(i) + "]" + ((i < ((DbDataReader)val3).FieldCount - 1) ? "," : string.Empty));
					}
					((DbParameterCollection)val2.get_Parameters()).Clear();
					((DbDataReader)val3).Close();
					val3.Dispose();
					((DbCommand)val2).Prepare();
					return stringBuilder.ToString();
				}
				finally
				{
					if (val2 != null)
					{
						((IDisposable)val2).Dispose();
					}
				}
			}
			finally
			{
				if (val != null)
				{
					((IDisposable)val).Dispose();
				}
			}
		}

		public string GetFields(string sql, MySqlParameter[] param, out string tableName)
		{
			//IL_0006: Unknown result type (might be due to invalid IL or missing references)
			//IL_000c: Expected O, but got Unknown
			//IL_001f: Unknown result type (might be due to invalid IL or missing references)
			//IL_0025: Expected O, but got Unknown
			MySqlConnection val = new MySqlConnection(ConnectionString);
			try
			{
				((DbConnection)val).Open();
				StringBuilder stringBuilder = new StringBuilder(500);
				MySqlCommand val2 = new MySqlCommand(sql, val);
				try
				{
					if (param != null && param.Length != 0)
					{
						((DbParameterCollection)val2.get_Parameters()).AddRange((Array)param);
					}
					MySqlDataReader val3 = val2.ExecuteReader(CommandBehavior.SchemaOnly);
					tableName = ((DbDataReader)val3).GetSchemaTable().TableName;
					for (int i = 0; i < ((DbDataReader)val3).FieldCount; i++)
					{
						stringBuilder.Append("[" + ((DbDataReader)val3).GetName(i) + "]" + ((i < ((DbDataReader)val3).FieldCount - 1) ? "," : string.Empty));
					}
					((DbParameterCollection)val2.get_Parameters()).Clear();
					((DbDataReader)val3).Close();
					val3.Dispose();
					((DbCommand)val2).Prepare();
					return stringBuilder.ToString();
				}
				finally
				{
					if (val2 != null)
					{
						((IDisposable)val2).Dispose();
					}
				}
			}
			finally
			{
				if (val != null)
				{
					((IDisposable)val).Dispose();
				}
			}
		}

		public string GetPaerSql(string sql, int size, int number, out long count, MySqlParameter[] param = null)
		{
			string fieldValue = GetFieldValue(string.Format("select count(*) from ({0}) PagerCountTemp", sql), param);
			long test;
			count = (fieldValue.IsLong(out test) ? test : 0);
			if (count < number * size - size + 1)
			{
				number = 1;
			}
			StringBuilder stringBuilder = new StringBuilder();
			stringBuilder.Append("select * from (");
			stringBuilder.Append(sql);
			stringBuilder.AppendFormat(") PagerTempTable");
			if (count > size)
			{
				stringBuilder.AppendFormat(" LIMIT {0},{1}", number * size - size, size);
			}
			return stringBuilder.ToString();
		}

		public string GetPaerSql(string table, string fileds, string where, string order, int size, int number, out long count, MySqlParameter[] param = null)
		{
			string empty = string.Empty;
			if (where.IsNullOrEmpty())
			{
				empty = "";
			}
			else
			{
				empty = where.Trim();
				if (empty.StartsWith("and", StringComparison.CurrentCultureIgnoreCase))
				{
					empty = empty.Substring(3);
				}
			}
			string text = empty.IsNullOrEmpty() ? "" : ("WHERE " + empty);
			string value = string.Format("SELECT PagerTempTable.* FROM (SELECT {0} FROM {1} {2} ORDER BY {3}) PagerTempTable", fileds, table, text, order);
			string fieldValue = GetFieldValue(string.Format("SELECT COUNT(*) FROM {0} {1}", table, text), param);
			long test;
			count = (fieldValue.IsLong(out test) ? test : 0);
			if (count < number * size - size + 1)
			{
				number = 1;
			}
			StringBuilder stringBuilder = new StringBuilder();
			stringBuilder.Append("SELECT * FROM (");
			stringBuilder.Append(value);
			stringBuilder.AppendFormat(") PagerTempTable");
			if (count > size)
			{
				stringBuilder.AppendFormat(" LIMIT {0},{1}", number * size - size, size);
			}
			return stringBuilder.ToString();
		}

		public int DataTableToDB(DataTable dt)
		{
			//IL_0006: Unknown result type (might be due to invalid IL or missing references)
			//IL_000c: Expected O, but got Unknown
			//IL_0028: Unknown result type (might be due to invalid IL or missing references)
			//IL_002e: Expected O, but got Unknown
			//IL_007e: Unknown result type (might be due to invalid IL or missing references)
			MySqlConnection val = new MySqlConnection(ConnectionString);
			try
			{
				((DbConnection)val).Open();
				MySqlDataAdapter val2 = new MySqlDataAdapter("select * from " + dt.TableName + " where 1=0", val);
				try
				{
					DataTable dataTable = new DataTable();
					((DbDataAdapter)val2).Fill(dataTable);
					foreach (DataRow row in dt.Rows)
					{
						dataTable.ImportRow(row);
					}
					new MySqlCommandBuilder(val2);
					return ((DbDataAdapter)val2).Update(dataTable);
				}
				finally
				{
					if (val2 != null)
					{
						((IDisposable)val2).Dispose();
					}
				}
			}
			catch (MySqlException val3)
			{
				throw val3;
			}
			finally
			{
				if (val != null)
				{
					((IDisposable)val).Dispose();
				}
			}
		}
	}
}
