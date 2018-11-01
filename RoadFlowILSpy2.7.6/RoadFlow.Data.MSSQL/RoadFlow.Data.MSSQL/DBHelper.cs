using RoadFlow.Data.Interface;
using RoadFlow.Utility;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Text;

namespace RoadFlow.Data.MSSQL
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
			connectionString = Config.PlatformConnectionStringMSSQL;
		}

		public DBHelper(string connString)
		{
			connectionString = connString;
		}

		public void Dispose()
		{
		}

		public SqlDataReader GetDataReader(string sql)
		{
			SqlConnection sqlConnection = new SqlConnection(ConnectionString);
			sqlConnection.Open();
			using (SqlCommand sqlCommand = new SqlCommand(sql, sqlConnection))
			{
				sqlCommand.CommandTimeout = 180;
				sqlCommand.Prepare();
				return sqlCommand.ExecuteReader(CommandBehavior.CloseConnection);
			}
		}

		public SqlDataReader GetDataReader(string sql, SqlParameter[] parameter)
		{
			SqlConnection sqlConnection = new SqlConnection(ConnectionString);
			sqlConnection.Open();
			using (SqlCommand sqlCommand = new SqlCommand(sql, sqlConnection))
			{
				sqlCommand.CommandTimeout = 180;
				if (parameter != null && parameter.Length != 0)
				{
					sqlCommand.Parameters.AddRange(parameter);
				}
				SqlDataReader result = sqlCommand.ExecuteReader(CommandBehavior.CloseConnection);
				sqlCommand.Parameters.Clear();
				sqlCommand.Prepare();
				return result;
			}
		}

		public DataTable GetDataTable(string sql)
		{
			using (SqlConnection sqlConnection = new SqlConnection(ConnectionString))
			{
				sqlConnection.Open();
				using (SqlDataAdapter sqlDataAdapter = new SqlDataAdapter(sql, sqlConnection))
				{
					DataTable dataTable = new DataTable();
					sqlDataAdapter.Fill(dataTable);
					sqlDataAdapter.Dispose();
					return dataTable;
				}
			}
		}

		public DataTable GetDataTable(string sql, SqlParameter[] parameter)
		{
			using (SqlConnection sqlConnection = new SqlConnection(ConnectionString))
			{
				sqlConnection.Open();
				using (SqlCommand sqlCommand = new SqlCommand(sql, sqlConnection))
				{
					if (parameter != null && parameter.Length != 0)
					{
						sqlCommand.Parameters.AddRange(parameter);
					}
					sqlCommand.CommandTimeout = 180;
					using (SqlDataAdapter sqlDataAdapter = new SqlDataAdapter(sqlCommand))
					{
						DataTable dataTable = new DataTable();
						sqlDataAdapter.Fill(dataTable);
						sqlDataAdapter.Dispose();
						sqlCommand.Parameters.Clear();
						sqlCommand.Prepare();
						return dataTable;
					}
				}
			}
		}

		public DataSet GetDataSet(string sql)
		{
			using (SqlConnection sqlConnection = new SqlConnection(ConnectionString))
			{
				sqlConnection.Open();
				using (SqlDataAdapter sqlDataAdapter = new SqlDataAdapter(sql, sqlConnection))
				{
					DataSet dataSet = new DataSet();
					sqlDataAdapter.Fill(dataSet);
					return dataSet;
				}
			}
		}

		public int Execute(string sql)
		{
			using (SqlConnection sqlConnection = new SqlConnection(ConnectionString))
			{
				sqlConnection.Open();
				using (SqlCommand sqlCommand = new SqlCommand(sql, sqlConnection))
				{
					sqlCommand.Prepare();
					return sqlCommand.ExecuteNonQuery();
				}
			}
		}

		public int Execute(List<string> sqlList)
		{
			using (SqlConnection sqlConnection = new SqlConnection(ConnectionString))
			{
				sqlConnection.Open();
				using (SqlCommand sqlCommand = new SqlCommand())
				{
					int num = 0;
					sqlCommand.Connection = sqlConnection;
					foreach (string sql in sqlList)
					{
						sqlCommand.CommandType = CommandType.Text;
						sqlCommand.CommandText = sql;
						sqlCommand.Prepare();
						num += sqlCommand.ExecuteNonQuery();
					}
					return num;
				}
			}
		}

		public int Execute(string sql, SqlParameter[] parameter, bool returnIdentity = false)
		{
			using (SqlConnection sqlConnection = new SqlConnection(ConnectionString))
			{
				sqlConnection.Open();
				using (SqlCommand sqlCommand = new SqlCommand(sql, sqlConnection))
				{
					if (parameter != null && parameter.Length != 0)
					{
						sqlCommand.Parameters.AddRange(parameter);
					}
					int num = sqlCommand.ExecuteNonQuery();
					sqlCommand.Parameters.Clear();
					sqlCommand.Prepare();
					if (returnIdentity)
					{
						sqlCommand.CommandText = "select @@IDENTITY";
						object obj = sqlCommand.ExecuteScalar();
						num = ((obj == null) ? num : obj.ToString().ToInt(num));
					}
					return num;
				}
			}
		}

		public int Execute(List<string> sqlList, List<SqlParameter[]> parameterList)
		{
			if (sqlList.Count > parameterList.Count)
			{
				throw new Exception("参数错误");
			}
			using (SqlConnection sqlConnection = new SqlConnection(ConnectionString))
			{
				sqlConnection.Open();
				using (SqlCommand sqlCommand = new SqlCommand())
				{
					int num = 0;
					sqlCommand.Connection = sqlConnection;
					for (int i = 0; i < sqlList.Count; i++)
					{
						sqlCommand.CommandType = CommandType.Text;
						sqlCommand.CommandText = sqlList[i];
						if (parameterList[i] != null && parameterList[i].Length != 0)
						{
							sqlCommand.Parameters.AddRange(parameterList[i]);
						}
						num += sqlCommand.ExecuteNonQuery();
						sqlCommand.Parameters.Clear();
						sqlCommand.Prepare();
					}
					return num;
				}
			}
		}

		public string ExecuteScalar(string sql)
		{
			using (SqlConnection sqlConnection = new SqlConnection(ConnectionString))
			{
				sqlConnection.Open();
				using (SqlCommand sqlCommand = new SqlCommand(sql, sqlConnection))
				{
					object obj = sqlCommand.ExecuteScalar();
					sqlCommand.Prepare();
					return (obj != null) ? obj.ToString() : string.Empty;
				}
			}
		}

		public string ExecuteScalar(string sql, SqlParameter[] parameter)
		{
			using (SqlConnection sqlConnection = new SqlConnection(ConnectionString))
			{
				sqlConnection.Open();
				using (SqlCommand sqlCommand = new SqlCommand(sql, sqlConnection))
				{
					if (parameter != null && parameter.Length != 0)
					{
						sqlCommand.Parameters.AddRange(parameter);
					}
					object obj = sqlCommand.ExecuteScalar();
					sqlCommand.Parameters.Clear();
					sqlCommand.Prepare();
					return (obj != null) ? obj.ToString() : string.Empty;
				}
			}
		}

		public string GetFieldValue(string sql)
		{
			return ExecuteScalar(sql);
		}

		public string GetFieldValue(string sql, SqlParameter[] parameter)
		{
			return ExecuteScalar(sql, parameter);
		}

		public string GetFields(string sql, SqlParameter[] param)
		{
			using (SqlConnection sqlConnection = new SqlConnection(ConnectionString))
			{
				sqlConnection.Open();
				StringBuilder stringBuilder = new StringBuilder(500);
				using (SqlCommand sqlCommand = new SqlCommand(sql, sqlConnection))
				{
					if (param != null && param.Length != 0)
					{
						sqlCommand.Parameters.AddRange(param);
					}
					SqlDataReader sqlDataReader = sqlCommand.ExecuteReader(CommandBehavior.SchemaOnly);
					for (int i = 0; i < sqlDataReader.FieldCount; i++)
					{
						stringBuilder.Append("[" + sqlDataReader.GetName(i) + "]" + ((i < sqlDataReader.FieldCount - 1) ? "," : string.Empty));
					}
					sqlCommand.Parameters.Clear();
					sqlDataReader.Close();
					sqlDataReader.Dispose();
					sqlCommand.Prepare();
					return stringBuilder.ToString();
				}
			}
		}

		public string GetFields(string sql, SqlParameter[] param, out string tableName)
		{
			using (SqlConnection sqlConnection = new SqlConnection(ConnectionString))
			{
				sqlConnection.Open();
				StringBuilder stringBuilder = new StringBuilder(500);
				using (SqlCommand sqlCommand = new SqlCommand(sql, sqlConnection))
				{
					if (param != null && param.Length != 0)
					{
						sqlCommand.Parameters.AddRange(param);
					}
					SqlDataReader sqlDataReader = sqlCommand.ExecuteReader(CommandBehavior.SchemaOnly);
					tableName = sqlDataReader.GetSchemaTable().TableName;
					for (int i = 0; i < sqlDataReader.FieldCount; i++)
					{
						stringBuilder.Append("[" + sqlDataReader.GetName(i) + "]" + ((i < sqlDataReader.FieldCount - 1) ? "," : string.Empty));
					}
					sqlCommand.Parameters.Clear();
					sqlDataReader.Close();
					sqlDataReader.Dispose();
					sqlCommand.Prepare();
					return stringBuilder.ToString();
				}
			}
		}

		public string GetPaerSql(string sql, int size, int number, out long count, SqlParameter[] param = null)
		{
			string fieldValue = GetFieldValue(string.Format("select count(*) from ({0}) as PagerCountTemp", sql), param);
			long test;
			count = (fieldValue.IsLong(out test) ? test : 0);
			if (count < number * size - size + 1)
			{
				number = 1;
			}
			StringBuilder stringBuilder = new StringBuilder();
			stringBuilder.Append("SELECT * FROM (");
			stringBuilder.Append(sql);
			stringBuilder.AppendFormat(") AS PagerTempTable");
			stringBuilder.AppendFormat(" WHERE PagerAutoRowNumber BETWEEN {0} AND {1}", number * size - size + 1, number * size);
			return stringBuilder.ToString();
		}

		public string GetPaerSql(string table, string fileds, string where, string order, int size, int number, out long count, SqlParameter[] param = null)
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
			string value = string.Format("select {0},ROW_NUMBER() OVER(ORDER BY {1}) as PagerAutoRowNumber from {2} {3}", fileds, order, table, text);
			string fieldValue = GetFieldValue(string.Format("select COUNT(*) FROM {0} {1}", table, text), param);
			long test;
			count = (fieldValue.IsLong(out test) ? test : 0);
			if (count < number * size - size + 1)
			{
				number = 1;
			}
			StringBuilder stringBuilder = new StringBuilder();
			stringBuilder.AppendFormat("SELECT * FROM (");
			stringBuilder.Append(value);
			stringBuilder.AppendFormat(") as PagerTempTable");
			if (count > size)
			{
				stringBuilder.AppendFormat(" WHERE PagerAutoRowNumber BETWEEN {0} AND {1}", number * size - size + 1, number * size);
			}
			return stringBuilder.ToString();
		}

		public int DataTableToDB(DataTable dt)
		{
			using (SqlConnection sqlConnection = new SqlConnection(ConnectionString))
			{
				try
				{
					sqlConnection.Open();
					using (SqlDataAdapter sqlDataAdapter = new SqlDataAdapter("select * from " + dt.TableName + " where 1=0", sqlConnection))
					{
						DataTable dataTable = new DataTable();
						sqlDataAdapter.Fill(dataTable);
						foreach (DataRow row in dt.Rows)
						{
							dataTable.ImportRow(row);
						}
						new SqlCommandBuilder(sqlDataAdapter);
						return sqlDataAdapter.Update(dataTable);
					}
				}
				catch (SqlException ex)
				{
					throw ex;
				}
			}
		}
	}
}
