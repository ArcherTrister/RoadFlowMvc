using LitJson;
using MySql.Data.MySqlClient;
using Oracle.ManagedDataAccess.Client;
using RoadFlow.Cache.IO;
using RoadFlow.Data.Factory;
using RoadFlow.Data.Interface;
using RoadFlow.Data.Model;
using RoadFlow.Data.MSSQL;
using RoadFlow.Data.MySql;
using RoadFlow.Data.ORACLE;
using RoadFlow.Utility;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.Common;
using System.Data.SqlClient;
using System.Linq;
using System.Text;

namespace RoadFlow.Platform
{
	public class DBConnection
	{
		public enum Types
		{
			SqlServer,
			Oracle
		}

		public enum ConnTypes
		{
			SqlServer,
			Oracle,
			MySql
		}

		private IDBConnection dataDBConnection;

		public DBConnection()
		{
			dataDBConnection = Factory.GetDBConnection();
		}

		public int Add(RoadFlow.Data.Model.DBConnection model)
		{
			int result = dataDBConnection.Add(model);
			ClearCache();
			return result;
		}

		public int Update(RoadFlow.Data.Model.DBConnection model)
		{
			int result = dataDBConnection.Update(model);
			ClearCache();
			return result;
		}

		public List<RoadFlow.Data.Model.DBConnection> GetAll(bool fromCache = false)
		{
			if (!fromCache)
			{
				return dataDBConnection.GetAll();
			}
			string key = 5.ToString();
			object obj = Opation.Get(key);
			if (obj != null && obj is List<RoadFlow.Data.Model.DBConnection>)
			{
				return (List<RoadFlow.Data.Model.DBConnection>)obj;
			}
			List<RoadFlow.Data.Model.DBConnection> all = dataDBConnection.GetAll();
			Opation.Set(key, all);
			return all;
		}

		public RoadFlow.Data.Model.DBConnection Get(Guid id, bool fromCache = true)
		{
			if (fromCache)
			{
				RoadFlow.Data.Model.DBConnection dBConnection = GetAll(true).Find((RoadFlow.Data.Model.DBConnection p) => p.ID == id);
				if (dBConnection != null)
				{
					return dBConnection;
				}
				return dataDBConnection.Get(id);
			}
			return dataDBConnection.Get(id);
		}

		public int Delete(Guid id)
		{
			int result = dataDBConnection.Delete(id);
			ClearCache();
			return result;
		}

		public long GetCount()
		{
			return dataDBConnection.GetCount();
		}

		public string GetAllTypeOptions(string value = "")
		{
			StringBuilder stringBuilder = new StringBuilder();
			foreach (object value2 in Enum.GetValues(typeof(ConnTypes)))
			{
				stringBuilder.AppendFormat("<option value=\"{0}\" {1}>{0}</option>", value2, (value2.ToString() == value) ? "selected=\"selected\"" : "");
			}
			return stringBuilder.ToString();
		}

		public string GetAllOptions(string value = "")
		{
			List<RoadFlow.Data.Model.DBConnection> all = GetAll(true);
			StringBuilder stringBuilder = new StringBuilder();
			foreach (RoadFlow.Data.Model.DBConnection item in from p in all
			orderby p.Name
			select p)
			{
				stringBuilder.AppendFormat("<option value=\"{0}\" {1}>{2}</option>", item.ID, (string.Compare(item.ID.ToString(), value, true) == 0) ? "selected=\"selected\"" : "", item.Name);
			}
			return stringBuilder.ToString();
		}

		public void ClearCache()
		{
			Opation.Remove(5.ToString());
		}

		public List<string> GetTables(Guid id, int type = 0)
		{
			RoadFlow.Data.Model.DBConnection dBConnection = GetAll(true).Find((RoadFlow.Data.Model.DBConnection p) => p.ID == id);
			if (dBConnection == null)
			{
				return new List<string>();
			}
			List<string> result = new List<string>();
			switch (dBConnection.Type)
			{
			case "SqlServer":
				result = getTables_SqlServer(dBConnection, type);
				break;
			case "Oracle":
				result = getTables_Oracle(dBConnection, type);
				break;
			case "MySql":
				result = getTables_MySql(dBConnection, type);
				break;
			}
			return result;
		}

		public Dictionary<string, string> GetFields(Guid id, string table)
		{
			if (table.IsNullOrEmpty())
			{
				return new Dictionary<string, string>();
			}
			RoadFlow.Data.Model.DBConnection dBConnection = GetAll(true).Find((RoadFlow.Data.Model.DBConnection p) => p.ID == id);
			if (dBConnection == null)
			{
				return new Dictionary<string, string>();
			}
			Dictionary<string, string> result = new Dictionary<string, string>();
			switch (dBConnection.Type)
			{
			case "SqlServer":
				result = getFields_SqlServer(dBConnection, table);
				break;
			case "Oracle":
				result = getFields_Oracle(dBConnection, table);
				break;
			case "MySql":
				result = getFields_MySql(dBConnection, table);
				break;
			}
			return result;
		}

		public string GetFieldValue(Guid connID, string sql, IDbDataParameter[] param = null)
		{
			//IL_00ea: Unknown result type (might be due to invalid IL or missing references)
			//IL_00f1: Expected O, but got Unknown
			//IL_00fb: Unknown result type (might be due to invalid IL or missing references)
			//IL_0102: Expected O, but got Unknown
			//IL_0121: Unknown result type (might be due to invalid IL or missing references)
			//IL_012b: Expected O, but got Unknown
			//IL_018b: Unknown result type (might be due to invalid IL or missing references)
			//IL_0192: Expected O, but got Unknown
			//IL_019c: Unknown result type (might be due to invalid IL or missing references)
			//IL_01a3: Expected O, but got Unknown
			//IL_01c2: Unknown result type (might be due to invalid IL or missing references)
			//IL_01cc: Expected O, but got Unknown
			RoadFlow.Data.Model.DBConnection dBConnection = Get(connID);
			if (dBConnection == null)
			{
				return "";
			}
			switch (dBConnection.Type.ToLower())
			{
			case "sqlserver":
				using (SqlConnection sqlConnection = new SqlConnection(dBConnection.ConnectionString))
				{
					try
					{
						sqlConnection.Open();
						using (SqlCommand sqlCommand = new SqlCommand(sql, sqlConnection))
						{
							if (param != null && param.Length != 0)
							{
								foreach (IDbDataParameter dbDataParameter3 in param)
								{
									sqlCommand.Parameters.Add((SqlParameter)dbDataParameter3);
								}
							}
							object obj5 = sqlCommand.ExecuteScalar();
							sqlCommand.Parameters.Clear();
							return obj5.ToString();
						}
					}
					catch
					{
					}
					finally
					{
						sqlConnection.Close();
						sqlConnection.Dispose();
					}
				}
				break;
			case "oracle":
			{
				OracleConnection val3 = new OracleConnection(dBConnection.ConnectionString);
				try
				{
					try
					{
						((DbConnection)val3).Open();
						OracleCommand val4 = new OracleCommand(sql, val3);
						try
						{
							if (param != null && param.Length != 0)
							{
								foreach (IDbDataParameter dbDataParameter2 in param)
								{
									val4.get_Parameters().Add(dbDataParameter2);
								}
							}
							object obj3 = ((DbCommand)val4).ExecuteScalar();
							((DbParameterCollection)val4.get_Parameters()).Clear();
							return obj3.ToString();
						}
						finally
						{
							if (val4 != null)
							{
								((IDisposable)val4).Dispose();
							}
						}
					}
					catch
					{
					}
					finally
					{
						((DbConnection)val3).Close();
						((Component)val3).Dispose();
					}
				}
				finally
				{
					if (val3 != null)
					{
						((IDisposable)val3).Dispose();
					}
				}
				break;
			}
			case "mysql":
			{
				MySqlConnection val = new MySqlConnection(dBConnection.ConnectionString);
				try
				{
					try
					{
						((DbConnection)val).Open();
						MySqlCommand val2 = new MySqlCommand(sql, val);
						try
						{
							if (param != null && param.Length != 0)
							{
								foreach (IDbDataParameter dbDataParameter in param)
								{
									val2.get_Parameters().Add(dbDataParameter);
								}
							}
							object obj = ((DbCommand)val2).ExecuteScalar();
							((DbParameterCollection)val2.get_Parameters()).Clear();
							return obj.ToString();
						}
						finally
						{
							if (val2 != null)
							{
								((IDisposable)val2).Dispose();
							}
						}
					}
					catch
					{
					}
					finally
					{
						((DbConnection)val).Close();
						val.Dispose();
					}
				}
				finally
				{
					if (val != null)
					{
						((IDisposable)val).Dispose();
					}
				}
				break;
			}
			}
			return "";
		}

		public string GetFieldValue(string link_table_field, Dictionary<string, string> pkFieldValue)
		{
			if (link_table_field.IsNullOrEmpty())
			{
				return "";
			}
			string[] array = link_table_field.Split('.');
			if (array.Length != 3)
			{
				return "";
			}
			string str = array[0];
			string table = array[1];
			string field = array[2];
			List<RoadFlow.Data.Model.DBConnection> all = GetAll(true);
			Guid linkid;
			if (!str.IsGuid(out linkid))
			{
				return "";
			}
			RoadFlow.Data.Model.DBConnection dBConnection = all.Find((RoadFlow.Data.Model.DBConnection p) => p.ID == linkid);
			if (dBConnection == null)
			{
				return "";
			}
			new List<string>();
			string result = string.Empty;
			switch (dBConnection.Type)
			{
			case "SqlServer":
				result = getFieldValue_SqlServer(dBConnection, table, field, pkFieldValue);
				break;
			case "Oracle":
				result = getFieldValue_Oracle(dBConnection, table, field, pkFieldValue);
				break;
			case "MySql":
				result = getFieldValue_MySql(dBConnection, table, field, pkFieldValue);
				break;
			}
			return result;
		}

		public string GetFieldValue(string link_table_field, string pkField, string pkFieldValue)
		{
			if (link_table_field.IsNullOrEmpty())
			{
				return "";
			}
			string[] array = link_table_field.Split('.');
			if (array.Length != 3)
			{
				return "";
			}
			string str = array[0];
			string table = array[1];
			string field = array[2];
			List<RoadFlow.Data.Model.DBConnection> all = GetAll(true);
			Guid linkid;
			if (!str.IsGuid(out linkid))
			{
				return "";
			}
			RoadFlow.Data.Model.DBConnection dBConnection = all.Find((RoadFlow.Data.Model.DBConnection p) => p.ID == linkid);
			if (dBConnection == null)
			{
				return "";
			}
			string result = string.Empty;
			switch (dBConnection.Type)
			{
			case "SqlServer":
				result = getFieldValue_SqlServer(dBConnection, table, field, pkField, pkFieldValue);
				break;
			case "Oracle":
				result = getFieldValue_Oracle(dBConnection, table, field, pkField, pkFieldValue);
				break;
			case "MySql":
				result = getFieldValue_MySql(dBConnection, table, field, pkField, pkFieldValue);
				break;
			}
			return result;
		}

		public string Test(Guid connID)
		{
			RoadFlow.Data.Model.DBConnection dBConnection = Get(connID);
			if (dBConnection != null)
			{
				switch (dBConnection.Type)
				{
				case "SqlServer":
					return test_SqlServer(dBConnection);
				case "Oracle":
					return test_Oracle(dBConnection);
				case "MySql":
					return test_MySql(dBConnection);
				default:
					return "";
				}
			}
			return "未找到连接!";
		}

		private string test_SqlServer(RoadFlow.Data.Model.DBConnection conn)
		{
			try
			{
				using (SqlConnection sqlConnection = new SqlConnection(conn.ConnectionString))
				{
					sqlConnection.Open();
					return "连接成功!";
				}
			}
			catch (SqlException ex)
			{
				return ex.Message;
			}
		}

		private string test_Oracle(RoadFlow.Data.Model.DBConnection conn)
		{
			//IL_0006: Unknown result type (might be due to invalid IL or missing references)
			//IL_000c: Expected O, but got Unknown
			//IL_0029: Expected O, but got Unknown
			try
			{
				OracleConnection val = new OracleConnection(conn.ConnectionString);
				try
				{
					((DbConnection)val).Open();
					return "连接成功!";
				}
				finally
				{
					if (val != null)
					{
						((IDisposable)val).Dispose();
					}
				}
			}
			catch (OracleException val2)
			{
				return ((Exception)val2).Message;
			}
		}

		private string test_MySql(RoadFlow.Data.Model.DBConnection conn)
		{
			//IL_0006: Unknown result type (might be due to invalid IL or missing references)
			//IL_000c: Expected O, but got Unknown
			//IL_0029: Expected O, but got Unknown
			try
			{
				MySqlConnection val = new MySqlConnection(conn.ConnectionString);
				try
				{
					((DbConnection)val).Open();
					return "连接成功!";
				}
				finally
				{
					if (val != null)
					{
						((IDisposable)val).Dispose();
					}
				}
			}
			catch (MySqlException val2)
			{
				return ((Exception)val2).Message;
			}
		}

		private string testSql_SqlServer(RoadFlow.Data.Model.DBConnection conn, string sql)
		{
			using (SqlConnection sqlConnection = new SqlConnection(conn.ConnectionString))
			{
				try
				{
					sqlConnection.Open();
				}
				catch (SqlException ex)
				{
					return ex.Message;
				}
				using (SqlCommand sqlCommand = new SqlCommand(sql, sqlConnection))
				{
					try
					{
						sqlCommand.ExecuteNonQuery();
					}
					catch (SqlException ex2)
					{
						return ex2.Message;
					}
				}
				return "";
			}
		}

		private string testSql_Oracle(RoadFlow.Data.Model.DBConnection conn, string sql)
		{
			//IL_0006: Unknown result type (might be due to invalid IL or missing references)
			//IL_000c: Expected O, but got Unknown
			//IL_0019: Expected O, but got Unknown
			//IL_001e: Unknown result type (might be due to invalid IL or missing references)
			//IL_0024: Expected O, but got Unknown
			//IL_0032: Expected O, but got Unknown
			OracleConnection val = new OracleConnection(conn.ConnectionString);
			try
			{
				try
				{
					((DbConnection)val).Open();
				}
				catch (OracleException val2)
				{
					return ((Exception)val2).Message;
				}
				OracleCommand val3 = new OracleCommand(sql, val);
				try
				{
					((DbCommand)val3).ExecuteNonQuery();
				}
				catch (OracleException val4)
				{
					return ((Exception)val4).Message;
				}
				finally
				{
					if (val3 != null)
					{
						((IDisposable)val3).Dispose();
					}
				}
				return "";
			}
			finally
			{
				if (val != null)
				{
					((IDisposable)val).Dispose();
				}
			}
		}

		private List<string> getTables_SqlServer(RoadFlow.Data.Model.DBConnection conn, int type)
		{
			using (SqlConnection sqlConnection = new SqlConnection(conn.ConnectionString))
			{
				try
				{
					sqlConnection.Open();
				}
				catch (SqlException err)
				{
					Log.Add(err);
					return new List<string>();
				}
				List<string> list = new List<string>();
				string str = string.Empty;
				switch (type)
				{
				case 0:
					str = "xtype='U' or xtype='V'";
					break;
				case 1:
					str = "xtype='U'";
					break;
				case 2:
					str = "xtype='V'";
					break;
				}
				using (SqlCommand sqlCommand = new SqlCommand("SELECT name FROM sysobjects WHERE " + str + " ORDER BY xtype, name", sqlConnection))
				{
					SqlDataReader sqlDataReader = sqlCommand.ExecuteReader();
					while (sqlDataReader.Read())
					{
						list.Add(sqlDataReader.GetString(0));
					}
					sqlDataReader.Close();
					return list;
				}
			}
		}

		private List<string> getTables_Oracle(RoadFlow.Data.Model.DBConnection conn, int type)
		{
			//IL_0006: Unknown result type (might be due to invalid IL or missing references)
			//IL_000c: Expected O, but got Unknown
			//IL_0019: Expected O, but got Unknown
			//IL_0066: Unknown result type (might be due to invalid IL or missing references)
			//IL_006d: Expected O, but got Unknown
			OracleConnection val = new OracleConnection(conn.ConnectionString);
			try
			{
				try
				{
					((DbConnection)val).Open();
				}
				catch (OracleException val2)
				{
					Log.Add((Exception)val2);
					return new List<string>();
				}
				List<string> list = new List<string>();
				string str = string.Empty;
				switch (type)
				{
				case 0:
					str = "and TABTYPE='TABLE' or TABTYPE='VIEW'";
					break;
				case 1:
					str = "and TABTYPE='TABLE'";
					break;
				case 2:
					str = "and TABTYPE='VIEW'";
					break;
				}
				OracleCommand val3 = new OracleCommand("select * from tab where instr(tname,'$',1,1)=0 " + str, val);
				try
				{
					OracleDataReader val4 = val3.ExecuteReader();
					while (((DbDataReader)val4).Read())
					{
						list.Add(((DbDataReader)val4).GetString(0));
					}
					((DbDataReader)val4).Close();
					return list;
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
				if (val != null)
				{
					((IDisposable)val).Dispose();
				}
			}
		}

		private List<string> getTables_MySql(RoadFlow.Data.Model.DBConnection conn, int type)
		{
			//IL_0006: Unknown result type (might be due to invalid IL or missing references)
			//IL_000c: Expected O, but got Unknown
			//IL_0019: Expected O, but got Unknown
			//IL_0071: Unknown result type (might be due to invalid IL or missing references)
			//IL_0078: Expected O, but got Unknown
			MySqlConnection val = new MySqlConnection(conn.ConnectionString);
			try
			{
				try
				{
					((DbConnection)val).Open();
				}
				catch (MySqlException val2)
				{
					Log.Add((Exception)val2);
					return new List<string>();
				}
				List<string> list = new List<string>();
				string str = string.Empty;
				switch (type)
				{
				case 0:
					str = "table_type='BASE TABLE' or table_type='VIEW'";
					break;
				case 1:
					str = "table_type='BASE TABLE'";
					break;
				case 2:
					str = "table_type='VIEW'";
					break;
				}
				MySqlCommand val3 = new MySqlCommand(string.Format("show full tables from {0} where " + str, ((DbConnection)val).Database), val);
				try
				{
					MySqlDataReader val4 = val3.ExecuteReader();
					while (((DbDataReader)val4).Read())
					{
						list.Add(((DbDataReader)val4).GetString(0));
					}
					((DbDataReader)val4).Close();
					return list;
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
				if (val != null)
				{
					((IDisposable)val).Dispose();
				}
			}
		}

		private Dictionary<string, string> getFields_SqlServer(RoadFlow.Data.Model.DBConnection conn, string table)
		{
			using (SqlConnection sqlConnection = new SqlConnection(conn.ConnectionString))
			{
				try
				{
					sqlConnection.Open();
				}
				catch (SqlException err)
				{
					Log.Add(err);
					return new Dictionary<string, string>();
				}
				Dictionary<string, string> dictionary = new Dictionary<string, string>();
				using (SqlCommand sqlCommand = new SqlCommand(string.Format("SELECT a.name as f_name, b.value from \r\nsys.syscolumns a LEFT JOIN sys.extended_properties b on a.id=b.major_id AND a.colid=b.minor_id AND b.name='MS_Description' \r\nWHERE object_id('{0}')=a.id ORDER BY a.colid", table), sqlConnection))
				{
					SqlDataReader sqlDataReader = sqlCommand.ExecuteReader();
					while (sqlDataReader.Read())
					{
						dictionary.Add(sqlDataReader.GetString(0), sqlDataReader.IsDBNull(1) ? "" : sqlDataReader.GetString(1).Replace1("\r\n", ""));
					}
					sqlDataReader.Close();
					return dictionary;
				}
			}
		}

		private Dictionary<string, string> getFields_Oracle(RoadFlow.Data.Model.DBConnection conn, string table)
		{
			//IL_0006: Unknown result type (might be due to invalid IL or missing references)
			//IL_000c: Expected O, but got Unknown
			//IL_0019: Expected O, but got Unknown
			//IL_0033: Unknown result type (might be due to invalid IL or missing references)
			//IL_0039: Expected O, but got Unknown
			OracleConnection val = new OracleConnection(conn.ConnectionString);
			try
			{
				try
				{
					((DbConnection)val).Open();
				}
				catch (OracleException val2)
				{
					Log.Add((Exception)val2);
					return new Dictionary<string, string>();
				}
				Dictionary<string, string> dictionary = new Dictionary<string, string>();
				OracleCommand val3 = new OracleCommand(string.Format("select COLUMN_NAME,COMMENTS from user_col_comments where TABLE_NAME='{0}'", table), val);
				try
				{
					OracleDataReader val4 = val3.ExecuteReader();
					while (((DbDataReader)val4).Read())
					{
						dictionary.Add(((DbDataReader)val4).GetString(0), ((DbDataReader)val4).IsDBNull(1) ? "" : ((DbDataReader)val4).GetString(1));
					}
					((DbDataReader)val4).Close();
					return dictionary;
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
				if (val != null)
				{
					((IDisposable)val).Dispose();
				}
			}
		}

		private Dictionary<string, string> getFields_MySql(RoadFlow.Data.Model.DBConnection conn, string table)
		{
			//IL_0006: Unknown result type (might be due to invalid IL or missing references)
			//IL_000c: Expected O, but got Unknown
			//IL_0019: Expected O, but got Unknown
			//IL_0033: Unknown result type (might be due to invalid IL or missing references)
			//IL_0039: Expected O, but got Unknown
			MySqlConnection val = new MySqlConnection(conn.ConnectionString);
			try
			{
				try
				{
					((DbConnection)val).Open();
				}
				catch (MySqlException val2)
				{
					Log.Add((Exception)val2);
					return new Dictionary<string, string>();
				}
				Dictionary<string, string> dictionary = new Dictionary<string, string>();
				MySqlCommand val3 = new MySqlCommand(string.Format("show full fields from {0}", table), val);
				try
				{
					MySqlDataReader val4 = val3.ExecuteReader();
					while (((DbDataReader)val4).Read())
					{
						dictionary.Add(((DbDataReader)val4)["Field"].ToString(), ((DbDataReader)val4)["Comment"].ToString());
					}
					((DbDataReader)val4).Close();
					return dictionary;
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
				if (val != null)
				{
					((IDisposable)val).Dispose();
				}
			}
		}

		private string getFieldValue_SqlServer(RoadFlow.Data.Model.DBConnection conn, string table, string field, Dictionary<string, string> pkFieldValue)
		{
			using (SqlConnection sqlConnection = new SqlConnection(conn.ConnectionString))
			{
				try
				{
					sqlConnection.Open();
				}
				catch (SqlException err)
				{
					Log.Add(err);
					return "";
				}
				new List<string>();
				StringBuilder stringBuilder = new StringBuilder();
				stringBuilder.AppendFormat("select {0} from {1} where 1=1", field, table);
				foreach (KeyValuePair<string, string> item in pkFieldValue)
				{
					stringBuilder.AppendFormat(" and {0}='{1}'", item.Key, item.Value);
				}
				using (SqlCommand sqlCommand = new SqlCommand(stringBuilder.ToString(), sqlConnection))
				{
					SqlDataReader sqlDataReader = sqlCommand.ExecuteReader();
					string result = string.Empty;
					if (sqlDataReader.HasRows)
					{
						sqlDataReader.Read();
						result = sqlDataReader.GetString(0);
					}
					sqlDataReader.Close();
					return result;
				}
			}
		}

		private string getFieldValue_Oracle(RoadFlow.Data.Model.DBConnection conn, string table, string field, Dictionary<string, string> pkFieldValue)
		{
			//IL_0006: Unknown result type (might be due to invalid IL or missing references)
			//IL_000c: Expected O, but got Unknown
			//IL_0019: Expected O, but got Unknown
			//IL_008b: Unknown result type (might be due to invalid IL or missing references)
			//IL_0092: Expected O, but got Unknown
			OracleConnection val = new OracleConnection(conn.ConnectionString);
			try
			{
				try
				{
					((DbConnection)val).Open();
				}
				catch (OracleException val2)
				{
					Log.Add((Exception)val2);
					return "";
				}
				new List<string>();
				StringBuilder stringBuilder = new StringBuilder();
				stringBuilder.AppendFormat("select {0} from {1} where 1=1", field, table);
				foreach (KeyValuePair<string, string> item in pkFieldValue)
				{
					stringBuilder.AppendFormat(" and {0}='{1}'", item.Key, item.Value);
				}
				OracleCommand val3 = new OracleCommand(stringBuilder.ToString(), val);
				try
				{
					OracleDataReader val4 = val3.ExecuteReader();
					string result = string.Empty;
					if (((DbDataReader)val4).HasRows)
					{
						((DbDataReader)val4).Read();
						result = ((DbDataReader)val4).GetString(0);
					}
					((DbDataReader)val4).Close();
					return result;
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
				if (val != null)
				{
					((IDisposable)val).Dispose();
				}
			}
		}

		private string getFieldValue_MySql(RoadFlow.Data.Model.DBConnection conn, string table, string field, Dictionary<string, string> pkFieldValue)
		{
			//IL_0006: Unknown result type (might be due to invalid IL or missing references)
			//IL_000c: Expected O, but got Unknown
			//IL_0019: Expected O, but got Unknown
			//IL_008b: Unknown result type (might be due to invalid IL or missing references)
			//IL_0092: Expected O, but got Unknown
			MySqlConnection val = new MySqlConnection(conn.ConnectionString);
			try
			{
				try
				{
					((DbConnection)val).Open();
				}
				catch (MySqlException val2)
				{
					Log.Add((Exception)val2);
					return "";
				}
				new List<string>();
				StringBuilder stringBuilder = new StringBuilder();
				stringBuilder.AppendFormat("select {0} from {1} where 1=1", field, table);
				foreach (KeyValuePair<string, string> item in pkFieldValue)
				{
					stringBuilder.AppendFormat(" and {0}='{1}'", item.Key, item.Value);
				}
				MySqlCommand val3 = new MySqlCommand(stringBuilder.ToString(), val);
				try
				{
					MySqlDataReader val4 = val3.ExecuteReader();
					string result = string.Empty;
					if (((DbDataReader)val4).HasRows)
					{
						((DbDataReader)val4).Read();
						result = ((DbDataReader)val4).GetString(0);
					}
					((DbDataReader)val4).Close();
					return result;
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
				if (val != null)
				{
					((IDisposable)val).Dispose();
				}
			}
		}

		private string getFieldValue_SqlServer(RoadFlow.Data.Model.DBConnection conn, string table, string field, string pkField, string pkFieldValue)
		{
			string result = "";
			using (SqlConnection sqlConnection = new SqlConnection(conn.ConnectionString))
			{
				try
				{
					sqlConnection.Open();
				}
				catch (SqlException err)
				{
					Log.Add(err);
					return "";
				}
				using (SqlDataAdapter sqlDataAdapter = new SqlDataAdapter(string.Format("SELECT {0} FROM {1} WHERE {2} = '{3}'", field, table, pkField, pkFieldValue), sqlConnection))
				{
					try
					{
						DataTable dataTable = new DataTable();
						sqlDataAdapter.Fill(dataTable);
						if (dataTable.Rows.Count > 0)
						{
							result = dataTable.Rows[0][0].ToString();
						}
					}
					catch (SqlException err2)
					{
						Log.Add(err2);
					}
					return result;
				}
			}
		}

		private string getFieldValue_Oracle(RoadFlow.Data.Model.DBConnection conn, string table, string field, string pkField, string pkFieldValue)
		{
			//IL_000c: Unknown result type (might be due to invalid IL or missing references)
			//IL_0012: Expected O, but got Unknown
			//IL_001f: Expected O, but got Unknown
			//IL_004d: Unknown result type (might be due to invalid IL or missing references)
			//IL_0053: Expected O, but got Unknown
			//IL_0092: Expected O, but got Unknown
			string result = "";
			OracleConnection val = new OracleConnection(conn.ConnectionString);
			try
			{
				try
				{
					((DbConnection)val).Open();
				}
				catch (OracleException val2)
				{
					Log.Add((Exception)val2);
					return "";
				}
				OracleDataAdapter val3 = new OracleDataAdapter(string.Format("SELECT {0} FROM {1} WHERE {2} = '{3}'", field, table, pkField, pkFieldValue), val);
				try
				{
					try
					{
						DataTable dataTable = new DataTable();
						((DbDataAdapter)val3).Fill(dataTable);
						if (dataTable.Rows.Count > 0)
						{
							result = dataTable.Rows[0][0].ToString();
						}
					}
					catch (OracleException val4)
					{
						Log.Add((Exception)val4);
					}
					return result;
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
				if (val != null)
				{
					((IDisposable)val).Dispose();
				}
			}
		}

		private string getFieldValue_MySql(RoadFlow.Data.Model.DBConnection conn, string table, string field, string pkField, string pkFieldValue)
		{
			//IL_000c: Unknown result type (might be due to invalid IL or missing references)
			//IL_0012: Expected O, but got Unknown
			//IL_001f: Expected O, but got Unknown
			//IL_004d: Unknown result type (might be due to invalid IL or missing references)
			//IL_0053: Expected O, but got Unknown
			//IL_0092: Expected O, but got Unknown
			string result = "";
			MySqlConnection val = new MySqlConnection(conn.ConnectionString);
			try
			{
				try
				{
					((DbConnection)val).Open();
				}
				catch (MySqlException val2)
				{
					Log.Add((Exception)val2);
					return "";
				}
				MySqlDataAdapter val3 = new MySqlDataAdapter(string.Format("SELECT {0} FROM {1} WHERE {2} = '{3}'", field, table, pkField, pkFieldValue), val);
				try
				{
					try
					{
						DataTable dataTable = new DataTable();
						((DbDataAdapter)val3).Fill(dataTable);
						if (dataTable.Rows.Count > 0)
						{
							result = dataTable.Rows[0][0].ToString();
						}
					}
					catch (MySqlException val4)
					{
						Log.Add((Exception)val4);
					}
					return result;
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
				if (val != null)
				{
					((IDisposable)val).Dispose();
				}
			}
		}

		public IDbConnection GetConnection(RoadFlow.Data.Model.DBConnection dbconn)
		{
			//IL_0065: Unknown result type (might be due to invalid IL or missing references)
			//IL_006b: Expected O, but got Unknown
			//IL_0073: Unknown result type (might be due to invalid IL or missing references)
			//IL_0079: Expected O, but got Unknown
			if (dbconn != null && !dbconn.Type.IsNullOrEmpty() && !dbconn.ConnectionString.IsNullOrEmpty())
			{
				IDbConnection result = null;
				try
				{
					switch (dbconn.Type)
					{
					case "SqlServer":
						result = new SqlConnection(dbconn.ConnectionString);
						return result;
					case "Oracle":
						result = (IDbConnection)new OracleConnection(dbconn.ConnectionString);
						return result;
					case "MySql":
						result = (IDbConnection)new MySqlConnection(dbconn.ConnectionString);
						return result;
					default:
						return result;
					}
				}
				catch (Exception err)
				{
					Log.Add(err);
					return result;
				}
			}
			return null;
		}

		public IDbDataAdapter GetDataAdapter(IDbConnection conn, string connType, string cmdText, IDataParameter[] parArray)
		{
			//IL_0066: Unknown result type (might be due to invalid IL or missing references)
			//IL_0070: Expected O, but got Unknown
			//IL_006b: Unknown result type (might be due to invalid IL or missing references)
			//IL_0071: Expected O, but got Unknown
			//IL_0088: Unknown result type (might be due to invalid IL or missing references)
			//IL_008e: Expected O, but got Unknown
			//IL_0092: Unknown result type (might be due to invalid IL or missing references)
			//IL_009c: Expected O, but got Unknown
			//IL_0097: Unknown result type (might be due to invalid IL or missing references)
			//IL_009d: Expected O, but got Unknown
			//IL_00b4: Unknown result type (might be due to invalid IL or missing references)
			//IL_00ba: Expected O, but got Unknown
			IDbDataAdapter result = null;
			switch (connType)
			{
			case "SqlServer":
				using (SqlCommand sqlCommand = new SqlCommand(cmdText, (SqlConnection)conn))
				{
					if (parArray != null && parArray.Length != 0)
					{
						sqlCommand.Parameters.AddRange(parArray);
					}
					return new SqlDataAdapter(sqlCommand);
				}
			case "Oracle":
			{
				OracleCommand val2 = new OracleCommand(cmdText, conn);
				if (parArray != null && parArray.Length != 0)
				{
					((DbParameterCollection)val2.get_Parameters()).AddRange((Array)parArray);
				}
				result = (IDbDataAdapter)new OracleDataAdapter(val2);
				break;
			}
			case "MySql":
			{
				MySqlCommand val = new MySqlCommand(cmdText, conn);
				if (parArray != null && parArray.Length != 0)
				{
					((DbParameterCollection)val.get_Parameters()).AddRange((Array)parArray);
				}
				result = (IDbDataAdapter)new MySqlDataAdapter(val);
				break;
			}
			}
			return result;
		}

		public string GetSerialNumber(IDbConnection conn, string connType, string table, string field, JsonData serialNumberJson, out int maxNumber)
		{
			//IL_0369: Unknown result type (might be due to invalid IL or missing references)
			//IL_0373: Expected O, but got Unknown
			//IL_036e: Unknown result type (might be due to invalid IL or missing references)
			//IL_0375: Expected O, but got Unknown
			//IL_0453: Unknown result type (might be due to invalid IL or missing references)
			//IL_045d: Expected O, but got Unknown
			//IL_0458: Unknown result type (might be due to invalid IL or missing references)
			//IL_045f: Expected O, but got Unknown
			//IL_0589: Unknown result type (might be due to invalid IL or missing references)
			//IL_0593: Expected O, but got Unknown
			//IL_058e: Unknown result type (might be due to invalid IL or missing references)
			//IL_0595: Expected O, but got Unknown
			//IL_0611: Unknown result type (might be due to invalid IL or missing references)
			//IL_061b: Expected O, but got Unknown
			//IL_0616: Unknown result type (might be due to invalid IL or missing references)
			//IL_061d: Expected O, but got Unknown
			maxNumber = 0;
			if (serialNumberJson == null)
			{
				return "";
			}
			string obj = serialNumberJson.ContainsKey("formatstring") ? serialNumberJson["formatstring"].ToString() : "";
			string text = serialNumberJson.ContainsKey("sqlwhere") ? serialNumberJson["sqlwhere"].ToString().UrlDecode() : "";
			int num = serialNumberJson.ContainsKey("length") ? serialNumberJson["length"].ToString().ToInt() : 0;
			string text2 = serialNumberJson.ContainsKey("maxfiled") ? serialNumberJson["maxfiled"].ToString() : "";
			string text3 = string.Empty;
			if (!text.IsNullOrEmpty())
			{
				text.FilterWildcard(Users.CurrentUserID.ToString());
				if (!text.Trim1().StartsWith("and", StringComparison.CurrentCultureIgnoreCase))
				{
					text = "AND " + text;
				}
			}
			bool flag = obj.Contains("$serialnumber$", StringComparison.CurrentCultureIgnoreCase);
			string text4 = obj.FilterWildcard(Users.CurrentUserID.ToString());
			if (text2.IsNullOrEmpty())
			{
				string empty = string.Empty;
				string empty2 = string.Empty;
				string text5 = flag ? text4.Substring(text4.IndexOf("$serialnumber$")).Replace1("$serialnumber$", "") : "";
				string text6 = flag ? text4.Substring(0, text4.IndexOf("$serialnumber$")) : "";
				switch (connType)
				{
				case "SqlServer":
					empty = (flag ? ("ISNULL(MAX(CAST(REPLACE(REPLACE(" + field + ",'" + text5 + "',''),'" + text6 + "','') as INT)),0)+1") : ("ISNULL(MAX(CAST(RIGHT(" + field + "," + num + ") as INT)),0)+1"));
					using (SqlCommand sqlCommand = new SqlCommand("SELECT " + empty + " FROM " + table + " WHERE 1=1 " + text, (SqlConnection)conn))
					{
						try
						{
							text3 = sqlCommand.ExecuteScalar().ToString().PadLeft(num, '0');
						}
						catch
						{
							text3 = "1".PadLeft(num, '0');
						}
					}
					break;
				case "Oracle":
				{
					empty = (flag ? ("NVL(MAX(CAST(REPLACE(REPLACE(" + field + ",'" + text5 + "',''),'" + text6 + "','') as INT)),0)+1") : ("NVL(MAX(CAST(SUBSTR(" + field + ",LENGTH(" + field + ")-" + (num - 1) + "," + num + ") as INT)),0)+1"));
					OracleCommand val2 = new OracleCommand("SELECT " + empty + " FROM " + table + " WHERE 1=1 " + text, conn);
					try
					{
						text3 = ((DbCommand)val2).ExecuteScalar().ToString().PadLeft(num, '0');
					}
					catch
					{
						text3 = "1".PadLeft(num, '0');
					}
					finally
					{
						if (val2 != null)
						{
							((IDisposable)val2).Dispose();
						}
					}
					break;
				}
				case "MySql":
				{
					empty = (flag ? ("IFNULL(MAX(REPLACE(REPLACE(" + field + ",'" + text5 + "',''),'" + text6 + "','')),0)+1") : ("IFNULL(MAX(RIGHT(" + field + "," + num + ")),0)+1"));
					MySqlCommand val = new MySqlCommand("SELECT " + empty + " FROM " + table + " WHERE 1=1 " + text, conn);
					try
					{
						text3 = ((DbCommand)val).ExecuteScalar().ToString().PadLeft(num, '0');
					}
					catch
					{
						text3 = "1".PadLeft(num, '0');
					}
					finally
					{
						if (val != null)
						{
							((IDisposable)val).Dispose();
						}
					}
					break;
				}
				}
			}
			else
			{
				string empty3 = string.Empty;
				switch (connType)
				{
				case "SqlServer":
					using (SqlCommand sqlCommand2 = new SqlCommand("SELECT ISNULL(MAX(" + text2 + "),0) FROM " + table + " WHERE 1=1 " + text, (SqlConnection)conn))
					{
						try
						{
							maxNumber = sqlCommand2.ExecuteScalar().ToString().ToInt(0) + 1;
							text3 = maxNumber.ToString().PadLeft(num, '0');
						}
						catch
						{
							text3 = "1".PadLeft(num, '0');
						}
					}
					break;
				case "Oracle":
				{
					OracleCommand val4 = new OracleCommand("SELECT NVL(MAX(" + text2 + "),0) FROM " + table + " WHERE 1=1 " + text, conn);
					try
					{
						maxNumber = ((DbCommand)val4).ExecuteScalar().ToString().ToInt(0) + 1;
						text3 = maxNumber.ToString().PadLeft(num, '0');
					}
					catch
					{
						text3 = "1".PadLeft(num, '0');
					}
					finally
					{
						if (val4 != null)
						{
							((IDisposable)val4).Dispose();
						}
					}
					break;
				}
				case "MySql":
				{
					MySqlCommand val3 = new MySqlCommand("SELECT IFNULL(MAX(" + text2 + "),0) FROM " + table + " WHERE 1=1 " + text, conn);
					try
					{
						maxNumber = ((DbCommand)val3).ExecuteScalar().ToString().ToInt(0) + 1;
						text3 = maxNumber.ToString().PadLeft(num, '0');
					}
					catch
					{
						text3 = "1".PadLeft(num, '0');
					}
					finally
					{
						if (val3 != null)
						{
							((IDisposable)val3).Dispose();
						}
					}
					break;
				}
				}
			}
			return flag ? text4.Replace1("$serialnumber$", text3) : (text4 + text3);
		}

		public bool TestSql(RoadFlow.Data.Model.DBConnection dbconn, string sql, bool replaceSql = true)
		{
			//IL_00e9: Unknown result type (might be due to invalid IL or missing references)
			//IL_00f0: Expected O, but got Unknown
			//IL_00fe: Expected O, but got Unknown
			//IL_0108: Unknown result type (might be due to invalid IL or missing references)
			//IL_010f: Expected O, but got Unknown
			//IL_0120: Expected O, but got Unknown
			//IL_016b: Unknown result type (might be due to invalid IL or missing references)
			//IL_0172: Expected O, but got Unknown
			//IL_0180: Expected O, but got Unknown
			//IL_0187: Unknown result type (might be due to invalid IL or missing references)
			//IL_018e: Expected O, but got Unknown
			//IL_019c: Expected O, but got Unknown
			if (dbconn != null)
			{
				if (replaceSql)
				{
					sql = sql.ReplaceSelectSql().FilterWildcard(Users.CurrentUserID.ToString());
				}
				switch (dbconn.Type.ToLower())
				{
				case "sqlserver":
					using (SqlConnection sqlConnection = new SqlConnection(dbconn.ConnectionString))
					{
						try
						{
							sqlConnection.Open();
						}
						catch (SqlException err)
						{
							Log.Add(err);
							return false;
						}
						using (SqlCommand sqlCommand = new SqlCommand(sql, sqlConnection))
						{
							try
							{
								sqlCommand.ExecuteNonQuery();
								return true;
							}
							catch (SqlException ex)
							{
								Log.Add("执行SqlServer语句发生了错误", ex.Message + ex.StackTrace, Log.Types.数据连接, sql);
								return false;
							}
						}
					}
				case "oracle":
				{
					OracleConnection val6 = new OracleConnection(dbconn.ConnectionString);
					try
					{
						try
						{
							((DbConnection)val6).Open();
						}
						catch (OracleException val7)
						{
							Log.Add((Exception)val7);
							return false;
						}
						OracleCommand val8 = new OracleCommand(sql, val6);
						try
						{
							((DbCommand)val8).ExecuteNonQuery();
							return true;
						}
						catch (OracleException val9)
						{
							OracleException val10 = val9;
							Log.Add("执行Oracle语句发生了错误", ((Exception)val10).Message + ((Exception)val10).StackTrace, Log.Types.数据连接, sql);
							return false;
						}
						finally
						{
							if (val8 != null)
							{
								((IDisposable)val8).Dispose();
							}
						}
					}
					finally
					{
						if (val6 != null)
						{
							((IDisposable)val6).Dispose();
						}
					}
				}
				case "mysql":
				{
					MySqlConnection val = new MySqlConnection(dbconn.ConnectionString);
					try
					{
						try
						{
							((DbConnection)val).Open();
						}
						catch (MySqlException val2)
						{
							Log.Add((Exception)val2);
							return false;
						}
						MySqlCommand val3 = new MySqlCommand(sql, val);
						try
						{
							((DbCommand)val3).ExecuteNonQuery();
							return true;
						}
						catch (MySqlException val4)
						{
							MySqlException val5 = val4;
							Log.Add("执行MySql语句发生了错误", ((Exception)val5).Message + ((Exception)val5).StackTrace, Log.Types.数据连接, sql);
							return false;
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
						if (val != null)
						{
							((IDisposable)val).Dispose();
						}
					}
				}
				default:
					return false;
				}
			}
			return false;
		}

		public bool TestSql(RoadFlow.Data.Model.DBConnection dbconn, string sql, out string msg, bool replaceSql = true)
		{
			//IL_00fa: Unknown result type (might be due to invalid IL or missing references)
			//IL_0101: Expected O, but got Unknown
			//IL_010f: Expected O, but got Unknown
			//IL_0119: Unknown result type (might be due to invalid IL or missing references)
			//IL_0120: Expected O, but got Unknown
			//IL_0131: Expected O, but got Unknown
			//IL_0185: Unknown result type (might be due to invalid IL or missing references)
			//IL_018c: Expected O, but got Unknown
			//IL_019a: Expected O, but got Unknown
			//IL_01a1: Unknown result type (might be due to invalid IL or missing references)
			//IL_01a8: Expected O, but got Unknown
			//IL_01b6: Expected O, but got Unknown
			msg = "";
			if (dbconn != null)
			{
				if (replaceSql)
				{
					sql = sql.ReplaceSelectSql().FilterWildcard(Users.CurrentUserID.ToString());
				}
				switch (dbconn.Type.ToLower())
				{
				case "sqlserver":
					using (SqlConnection sqlConnection = new SqlConnection(dbconn.ConnectionString))
					{
						try
						{
							sqlConnection.Open();
						}
						catch (SqlException err)
						{
							Log.Add(err);
							return false;
						}
						using (SqlCommand sqlCommand = new SqlCommand(sql, sqlConnection))
						{
							try
							{
								sqlCommand.ExecuteNonQuery();
								return true;
							}
							catch (SqlException ex)
							{
								msg = ex.Message;
								Log.Add("执行SqlServer语句发生了错误", ex.Message + ex.StackTrace, Log.Types.数据连接, sql);
								return false;
							}
						}
					}
				case "oracle":
				{
					OracleConnection val6 = new OracleConnection(dbconn.ConnectionString);
					try
					{
						try
						{
							((DbConnection)val6).Open();
						}
						catch (OracleException val7)
						{
							Log.Add((Exception)val7);
							return false;
						}
						OracleCommand val8 = new OracleCommand(sql, val6);
						try
						{
							((DbCommand)val8).ExecuteNonQuery();
							return true;
						}
						catch (OracleException val9)
						{
							OracleException val10 = val9;
							msg = ((Exception)val10).Message;
							Log.Add("执行Oracle语句发生了错误", ((Exception)val10).Message + ((Exception)val10).StackTrace, Log.Types.数据连接, sql);
							return false;
						}
						finally
						{
							if (val8 != null)
							{
								((IDisposable)val8).Dispose();
							}
						}
					}
					finally
					{
						if (val6 != null)
						{
							((IDisposable)val6).Dispose();
						}
					}
				}
				case "mysql":
				{
					MySqlConnection val = new MySqlConnection(dbconn.ConnectionString);
					try
					{
						try
						{
							((DbConnection)val).Open();
						}
						catch (MySqlException val2)
						{
							Log.Add((Exception)val2);
							return false;
						}
						MySqlCommand val3 = new MySqlCommand(sql, val);
						try
						{
							((DbCommand)val3).ExecuteNonQuery();
							return true;
						}
						catch (MySqlException val4)
						{
							MySqlException val5 = val4;
							msg = ((Exception)val5).Message;
							Log.Add("执行MySql语句发生了错误", ((Exception)val5).Message + ((Exception)val5).StackTrace, Log.Types.数据连接, sql);
							return false;
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
						if (val != null)
						{
							((IDisposable)val).Dispose();
						}
					}
				}
				default:
					return false;
				}
			}
			return false;
		}

		public DataTable GetDataTable(string dbconn, string table, string field, string fieldValue, string sortString = "")
		{
			//IL_0129: Unknown result type (might be due to invalid IL or missing references)
			//IL_012f: Expected O, but got Unknown
			//IL_01a5: Unknown result type (might be due to invalid IL or missing references)
			//IL_01ab: Expected O, but got Unknown
			if (dbconn.IsNullOrEmpty() || table.IsNullOrEmpty() || field.IsNullOrEmpty() || fieldValue.IsNullOrEmpty())
			{
				return new DataTable();
			}
			string text = sortString.IsNullOrEmpty() ? field : sortString;
			RoadFlow.Data.Model.DBConnection dBConnection = Get(dbconn.ToGuid());
			if (dBConnection == null)
			{
				return new DataTable();
			}
			if (dBConnection.Type == "SqlServer")
			{
				string sql = "SELECT * FROM " + table + " WHERE " + field + " = @" + field + " ORDER BY " + text;
				IDataParameter[] array = new SqlParameter[1]
				{
					new SqlParameter("@" + field, fieldValue)
				};
				IDataParameter[] parameterArray = array;
				return GetDataTable(dBConnection, sql, parameterArray);
			}
			if (dBConnection.Type == "Oracle")
			{
				string sql2 = "SELECT * FROM " + table + " WHERE " + field + " = :" + field + " ORDER BY " + text;
				IDataParameter[] array = (IDataParameter[])new OracleParameter[1]
				{
					new OracleParameter(":" + field, (object)fieldValue)
				};
				IDataParameter[] parameterArray2 = array;
				return GetDataTable(dBConnection, sql2, parameterArray2);
			}
			if (dBConnection.Type == "MySql")
			{
				string sql3 = "SELECT * FROM " + table + " WHERE " + field + " = @" + field + " ORDER BY " + text;
				IDataParameter[] array = (IDataParameter[])new MySqlParameter[1]
				{
					new MySqlParameter("@" + field, (object)fieldValue)
				};
				IDataParameter[] parameterArray3 = array;
				return GetDataTable(dBConnection, sql3, parameterArray3);
			}
			return new DataTable();
		}

		public DataTable GetDataTable(RoadFlow.Data.Model.DBConnection dbconn, string sql, IDataParameter[] parameterArray = null)
		{
			//IL_010f: Unknown result type (might be due to invalid IL or missing references)
			//IL_0116: Expected O, but got Unknown
			//IL_0120: Unknown result type (might be due to invalid IL or missing references)
			//IL_0127: Expected O, but got Unknown
			//IL_0142: Unknown result type (might be due to invalid IL or missing references)
			//IL_0149: Expected O, but got Unknown
			//IL_0181: Expected O, but got Unknown
			//IL_01c5: Unknown result type (might be due to invalid IL or missing references)
			//IL_01cc: Expected O, but got Unknown
			//IL_01d6: Unknown result type (might be due to invalid IL or missing references)
			//IL_01dd: Expected O, but got Unknown
			//IL_01f8: Unknown result type (might be due to invalid IL or missing references)
			//IL_01ff: Expected O, but got Unknown
			//IL_0234: Expected O, but got Unknown
			if (dbconn != null && !dbconn.Type.IsNullOrEmpty() && !dbconn.ConnectionString.IsNullOrEmpty())
			{
				DataTable dataTable = new DataTable();
				switch (dbconn.Type)
				{
				case "SqlServer":
					using (SqlConnection sqlConnection = new SqlConnection(dbconn.ConnectionString))
					{
						try
						{
							sqlConnection.Open();
							using (SqlCommand sqlCommand = new SqlCommand(sql, sqlConnection))
							{
								if (parameterArray != null && parameterArray.Length != 0)
								{
									sqlCommand.Parameters.AddRange((SqlParameter[])parameterArray);
								}
								using (SqlDataAdapter sqlDataAdapter = new SqlDataAdapter(sqlCommand))
								{
									sqlDataAdapter.Fill(dataTable);
									sqlCommand.Parameters.Clear();
									return dataTable;
								}
							}
						}
						catch (SqlException ex)
						{
							Log.Add("获取DataTable发生了错误", ex.Message + ex.StackTrace + ex.TargetSite, Log.Types.数据连接, sql);
							return dataTable;
						}
					}
				case "Oracle":
				{
					OracleConnection val6 = new OracleConnection(dbconn.ConnectionString);
					try
					{
						((DbConnection)val6).Open();
						OracleCommand val7 = new OracleCommand(sql, val6);
						try
						{
							if (parameterArray != null && parameterArray.Length != 0)
							{
								((DbParameterCollection)val7.get_Parameters()).AddRange((Array)(OracleParameter[])parameterArray);
							}
							OracleDataAdapter val8 = new OracleDataAdapter(val7);
							try
							{
								((DbDataAdapter)val8).Fill(dataTable);
								((DbParameterCollection)val7.get_Parameters()).Clear();
								return dataTable;
							}
							finally
							{
								if (val8 != null)
								{
									((IDisposable)val8).Dispose();
								}
							}
						}
						finally
						{
							if (val7 != null)
							{
								((IDisposable)val7).Dispose();
							}
						}
					}
					catch (OracleException val9)
					{
						OracleException val10 = val9;
						Log.Add("获取DataTable发生了错误", ((Exception)val10).Message + ((Exception)val10).StackTrace + ((Exception)val10).TargetSite, Log.Types.数据连接, sql);
						return dataTable;
					}
					finally
					{
						if (val6 != null)
						{
							((IDisposable)val6).Dispose();
						}
					}
				}
				case "MySql":
				{
					MySqlConnection val = new MySqlConnection(dbconn.ConnectionString);
					try
					{
						((DbConnection)val).Open();
						MySqlCommand val2 = new MySqlCommand(sql, val);
						try
						{
							if (parameterArray != null && parameterArray.Length != 0)
							{
								((DbParameterCollection)val2.get_Parameters()).AddRange((Array)(MySqlParameter[])parameterArray);
							}
							MySqlDataAdapter val3 = new MySqlDataAdapter(val2);
							try
							{
								((DbDataAdapter)val3).Fill(dataTable);
								((DbParameterCollection)val2.get_Parameters()).Clear();
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
					catch (MySqlException val4)
					{
						MySqlException val5 = val4;
						Log.Add("获取DataTable发生了错误", ((Exception)val5).Message + ((Exception)val5).StackTrace + ((Exception)val5).TargetSite, Log.Types.数据连接, sql);
						return dataTable;
					}
					finally
					{
						if (val != null)
						{
							((IDisposable)val).Dispose();
						}
					}
				}
				default:
					return dataTable;
				}
			}
			return null;
		}

		public DataTable GetDataTable(Guid connID, string sql, IDataParameter[] param = null)
		{
			//IL_014e: Unknown result type (might be due to invalid IL or missing references)
			//IL_0155: Expected O, but got Unknown
			//IL_015f: Unknown result type (might be due to invalid IL or missing references)
			//IL_0166: Expected O, but got Unknown
			//IL_0196: Unknown result type (might be due to invalid IL or missing references)
			//IL_01a0: Expected O, but got Unknown
			//IL_01b1: Unknown result type (might be due to invalid IL or missing references)
			//IL_01b8: Expected O, but got Unknown
			//IL_0203: Expected O, but got Unknown
			//IL_0229: Unknown result type (might be due to invalid IL or missing references)
			//IL_0230: Expected O, but got Unknown
			//IL_023a: Unknown result type (might be due to invalid IL or missing references)
			//IL_0241: Expected O, but got Unknown
			//IL_0271: Unknown result type (might be due to invalid IL or missing references)
			//IL_027b: Expected O, but got Unknown
			//IL_028c: Unknown result type (might be due to invalid IL or missing references)
			//IL_0293: Expected O, but got Unknown
			//IL_02db: Expected O, but got Unknown
			RoadFlow.Data.Model.DBConnection dBConnection = Get(connID);
			if (dBConnection == null)
			{
				return new DataTable();
			}
			string tableName = "Table_" + Guid.NewGuid().ToString("N");
			switch (dBConnection.Type.ToLower())
			{
			case "sqlserver":
				using (SqlConnection sqlConnection = new SqlConnection(dBConnection.ConnectionString))
				{
					try
					{
						sqlConnection.Open();
						using (SqlCommand sqlCommand = new SqlCommand(sql, sqlConnection))
						{
							if (param != null && param.Length != 0)
							{
								for (int i = 0; i < param.Length; i++)
								{
									IDbDataParameter dbDataParameter3 = (IDbDataParameter)param[i];
									sqlCommand.Parameters.Add(new SqlParameter(dbDataParameter3.ParameterName, dbDataParameter3.Value));
								}
							}
							using (SqlDataAdapter sqlDataAdapter = new SqlDataAdapter(sqlCommand))
							{
								DataTable dataTable3 = new DataTable();
								dataTable3.TableName = tableName;
								sqlDataAdapter.Fill(dataTable3);
								sqlCommand.Parameters.Clear();
								return dataTable3;
							}
						}
					}
					catch (SqlException err)
					{
						Log.Add(err);
					}
					finally
					{
						sqlConnection.Close();
						sqlConnection.Dispose();
					}
				}
				break;
			case "oracle":
			{
				OracleConnection val5 = new OracleConnection(dBConnection.ConnectionString);
				try
				{
					try
					{
						((DbConnection)val5).Open();
						OracleCommand val6 = new OracleCommand(sql, val5);
						try
						{
							if (param != null && param.Length != 0)
							{
								for (int i = 0; i < param.Length; i++)
								{
									IDbDataParameter dbDataParameter2 = (IDbDataParameter)param[i];
									val6.get_Parameters().Add(new OracleParameter(dbDataParameter2.ParameterName, dbDataParameter2.Value));
								}
							}
							OracleDataAdapter val7 = new OracleDataAdapter(val6);
							try
							{
								DataTable dataTable2 = new DataTable();
								dataTable2.TableName = tableName;
								((DbDataAdapter)val7).Fill(dataTable2);
								((DbParameterCollection)val6.get_Parameters()).Clear();
								return dataTable2;
							}
							finally
							{
								if (val7 != null)
								{
									((IDisposable)val7).Dispose();
								}
							}
						}
						finally
						{
							if (val6 != null)
							{
								((IDisposable)val6).Dispose();
							}
						}
					}
					catch (OracleException val8)
					{
						Log.Add((Exception)val8);
					}
					finally
					{
						((DbConnection)val5).Close();
						((Component)val5).Dispose();
					}
				}
				finally
				{
					if (val5 != null)
					{
						((IDisposable)val5).Dispose();
					}
				}
				break;
			}
			case "mysql":
			{
				MySqlConnection val = new MySqlConnection(dBConnection.ConnectionString);
				try
				{
					try
					{
						((DbConnection)val).Open();
						MySqlCommand val2 = new MySqlCommand(sql, val);
						try
						{
							if (param != null && param.Length != 0)
							{
								for (int i = 0; i < param.Length; i++)
								{
									IDbDataParameter dbDataParameter = (IDbDataParameter)param[i];
									val2.get_Parameters().Add(new MySqlParameter(dbDataParameter.ParameterName, dbDataParameter.Value));
								}
							}
							MySqlDataAdapter val3 = new MySqlDataAdapter(val2);
							try
							{
								DataTable dataTable = new DataTable();
								dataTable.TableName = tableName;
								((DbDataAdapter)val3).Fill(dataTable);
								((DbParameterCollection)val2.get_Parameters()).Clear();
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
					catch (MySqlException val4)
					{
						Log.Add((Exception)val4);
					}
					finally
					{
						((DbConnection)val).Close();
						val.Dispose();
					}
				}
				finally
				{
					if (val != null)
					{
						((IDisposable)val).Dispose();
					}
				}
				break;
			}
			}
			return new DataTable();
		}

		public List<string> GetFieldsBySQL(Guid connID, string sql)
		{
			//IL_00f7: Unknown result type (might be due to invalid IL or missing references)
			//IL_00fe: Expected O, but got Unknown
			//IL_0117: Unknown result type (might be due to invalid IL or missing references)
			//IL_011e: Expected O, but got Unknown
			//IL_019c: Unknown result type (might be due to invalid IL or missing references)
			//IL_01a3: Expected O, but got Unknown
			//IL_01bc: Unknown result type (might be due to invalid IL or missing references)
			//IL_01c3: Expected O, but got Unknown
			RoadFlow.Data.Model.DBConnection dBConnection = Get(connID);
			if (dBConnection != null)
			{
				List<string> list = new List<string>();
				switch (dBConnection.Type)
				{
				case "SqlServer":
					using (SqlConnection sqlConnection = new SqlConnection(dBConnection.ConnectionString))
					{
						sqlConnection.Open();
						using (SqlDataAdapter sqlDataAdapter = new SqlDataAdapter(sql.FilterWildcard().ReplaceSelectSql(), sqlConnection))
						{
							DataTable dataTable3 = new DataTable();
							sqlDataAdapter.FillSchema(dataTable3, SchemaType.Source);
							foreach (DataColumn column in dataTable3.Columns)
							{
								list.Add(column.ColumnName);
							}
							return list;
						}
					}
				case "Oracle":
				{
					OracleConnection val3 = new OracleConnection(dBConnection.ConnectionString);
					try
					{
						((DbConnection)val3).Open();
						OracleDataAdapter val4 = new OracleDataAdapter(sql.FilterWildcard().ReplaceSelectSql(), val3);
						try
						{
							DataTable dataTable2 = new DataTable();
							((DbDataAdapter)val4).FillSchema(dataTable2, SchemaType.Source);
							foreach (DataColumn column2 in dataTable2.Columns)
							{
								list.Add(column2.ColumnName);
							}
							return list;
						}
						finally
						{
							if (val4 != null)
							{
								((IDisposable)val4).Dispose();
							}
						}
					}
					finally
					{
						if (val3 != null)
						{
							((IDisposable)val3).Dispose();
						}
					}
				}
				case "MySql":
				{
					MySqlConnection val = new MySqlConnection(dBConnection.ConnectionString);
					try
					{
						((DbConnection)val).Open();
						MySqlDataAdapter val2 = new MySqlDataAdapter(sql.FilterWildcard().ReplaceSelectSql(), val);
						try
						{
							DataTable dataTable = new DataTable();
							((DbDataAdapter)val2).FillSchema(dataTable, SchemaType.Source);
							foreach (DataColumn column3 in dataTable.Columns)
							{
								list.Add(column3.ColumnName);
							}
							return list;
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
				default:
					return list;
				}
			}
			return new List<string>();
		}

		public DataTable GetTableSchema(IDbConnection conn, string tableName, string dbType)
		{
			//IL_0060: Unknown result type (might be due to invalid IL or missing references)
			//IL_006a: Expected O, but got Unknown
			//IL_0065: Unknown result type (might be due to invalid IL or missing references)
			//IL_0070: Expected O, but got Unknown
			//IL_008d: Unknown result type (might be due to invalid IL or missing references)
			//IL_0097: Expected O, but got Unknown
			//IL_0092: Unknown result type (might be due to invalid IL or missing references)
			//IL_009d: Expected O, but got Unknown
			DataTable dataTable = new DataTable();
			switch (dbType)
			{
			case "SqlServer":
				new SqlDataAdapter(string.Format("select a.name as f_name,b.name as t_name,a.prec as [length],a.scale,a.isnullable as is_null, a.cdefault as cdefault,COLUMNPROPERTY( OBJECT_ID('{0}'),a.name,'IsIdentity') as isidentity, \r\n(select top 1 text from sysobjects d inner join syscolumns e on e.id=d.id inner join syscomments f on f.id=e.cdefault \r\nwhere d.name='{0}' and e.name=a.name) as defaultvalue from \r\n                    sys.syscolumns a inner join sys.types b on b.user_type_id=a.xtype \r\n                    where object_id('{0}')=id order by a.colid", tableName), (SqlConnection)conn).Fill(dataTable);
				break;
			case "Oracle":
				((DbDataAdapter)new OracleDataAdapter(string.Format("SELECT COLUMN_NAME as f_name,\r\n                    DATA_TYPE as t_name,\r\n                    CHAR_LENGTH AS length,\r\n                    (DATA_PRECISION||','||DATA_SCALE) AS scale,\r\n                    CASE NULLABLE WHEN 'Y' THEN 1 WHEN 'N' THEN 0 END AS is_null,\r\n                    DATA_DEFAULT AS cdefault,\r\n                    0 as isidentity,DATA_DEFAULT AS defaultvalue FROM user_tab_columns WHERE UPPER(TABLE_NAME)=UPPER('{0}') ORDER BY COLUMN_ID", tableName), conn)).Fill(dataTable);
				break;
			case "MySql":
			{
				DataTable dataTable2 = new DataTable();
				((DbDataAdapter)new MySqlDataAdapter("show full fields from `" + tableName + "`", conn)).Fill(dataTable2);
				dataTable.Columns.Add("f_name", "".GetType());
				dataTable.Columns.Add("t_name", "".GetType());
				dataTable.Columns.Add("length", "".GetType());
				dataTable.Columns.Add("scale", 1.GetType());
				dataTable.Columns.Add("is_null", 1.GetType());
				dataTable.Columns.Add("cdefault", 1.GetType());
				dataTable.Columns.Add("isidentity", 1.GetType());
				dataTable.Columns.Add("defaultvalue", "".GetType());
				{
					foreach (DataRow row in dataTable2.Rows)
					{
						string text = row["Type"].ToString();
						string text2 = row["Type"].ToString();
						string value = "";
						if (text.IndexOf("(") > 0)
						{
							text = text.Substring(0, text.IndexOf("("));
							try
							{
								value = text2.Substring(text2.IndexOf("(") + 1, text2.IndexOf(")") - text2.IndexOf("(") - 1);
							}
							catch
							{
								value = "";
							}
						}
						DataRow dataRow2 = dataTable.NewRow();
						dataRow2["f_name"] = row["Field"].ToString();
						dataRow2["t_name"] = text;
						dataRow2["length"] = value;
						dataRow2["scale"] = 0;
						dataRow2["is_null"] = ("YES" == row["Null"].ToString());
						dataRow2["cdefault"] = (row["Default"].ToString().IsNullOrEmpty() ? 1 : 0);
						dataRow2["isidentity"] = ("auto_increment" == row["Extra"].ToString());
						dataRow2["defaultvalue"] = row["Default"].ToString();
						dataTable.Rows.Add(dataRow2);
					}
					return dataTable;
				}
			}
			}
			return dataTable;
		}

		public object GetDbDefaultValue_SqlServer(string text)
		{
			if (text.IsNullOrEmpty())
			{
				return null;
			}
			object result = text;
			if (text.StartsWith("(("))
			{
				result = text.Replace1("((", "").Replace1("))", "");
			}
			else if (text.StartsWith("('"))
			{
				result = text.Replace1("('", "").Replace1("')", "");
			}
			else
			{
				string a = text.ToLower();
				if (!(a == "(getdate())"))
				{
					if (a == "(newid())")
					{
						result = Guid.NewGuid();
					}
				}
				else
				{
					result = DateTimeNew.Now;
				}
			}
			return result;
		}

		public object GetDbDefaultValue_Oracle(string text)
		{
			if (text.IsNullOrEmpty())
			{
				return null;
			}
			object result = text;
			if (text.StartsWith("'"))
			{
				result = text.Replace1("'", "");
			}
			else
			{
				string a = text.ToLower();
				if (a == "sysdate")
				{
					result = DateTimeNew.Now;
				}
			}
			return result;
		}

		public object GetDbDefaultValue_MySql(string text)
		{
			if (text.IsNullOrEmpty())
			{
				return null;
			}
			object result = text;
			string a = text.ToUpper();
			if (a == "CURRENT_TIMESTAMP")
			{
				result = DateTimeNew.Now;
			}
			return result;
		}

		public void UpdateFieldValue(Guid connID, string table, string field, string value, string where)
		{
			//IL_00d3: Expected O, but got Unknown
			//IL_00ea: Unknown result type (might be due to invalid IL or missing references)
			//IL_00f1: Expected O, but got Unknown
			//IL_00f3: Unknown result type (might be due to invalid IL or missing references)
			//IL_00fd: Expected O, but got Unknown
			//IL_00f8: Unknown result type (might be due to invalid IL or missing references)
			//IL_00ff: Expected O, but got Unknown
			//IL_0120: Expected O, but got Unknown
			//IL_0154: Expected O, but got Unknown
			//IL_016b: Unknown result type (might be due to invalid IL or missing references)
			//IL_0172: Expected O, but got Unknown
			//IL_0174: Unknown result type (might be due to invalid IL or missing references)
			//IL_017e: Expected O, but got Unknown
			//IL_0179: Unknown result type (might be due to invalid IL or missing references)
			//IL_0180: Expected O, but got Unknown
			//IL_019e: Expected O, but got Unknown
			RoadFlow.Data.Model.DBConnection dBConnection = Get(connID);
			if (dBConnection != null)
			{
				string type = dBConnection.Type;
				if (!(type == "SqlServer"))
				{
					if (!(type == "Oracle"))
					{
						if (type == "MySql")
						{
							using (IDbConnection dbConnection = GetConnection(dBConnection))
							{
								try
								{
									dbConnection.Open();
								}
								catch (MySqlException val)
								{
									Log.Add((Exception)val);
								}
								string text = string.Format("UPDATE {0} SET {1}=@value WHERE {2}", table, field, where);
								MySqlParameter val2 = new MySqlParameter("@value", (object)value);
								MySqlCommand val3 = new MySqlCommand(text, dbConnection);
								try
								{
									val3.get_Parameters().Add(val2);
									try
									{
										((DbCommand)val3).ExecuteNonQuery();
									}
									catch (MySqlException val4)
									{
										Log.Add((Exception)val4);
									}
								}
								finally
								{
									if (val3 != null)
									{
										((IDisposable)val3).Dispose();
									}
								}
							}
						}
					}
					else
					{
						using (IDbConnection dbConnection2 = GetConnection(dBConnection))
						{
							try
							{
								dbConnection2.Open();
							}
							catch (OracleException val5)
							{
								Log.Add((Exception)val5);
							}
							string text2 = string.Format("UPDATE {0} SET {1}=:value WHERE {2}", table, field, where);
							OracleParameter val6 = new OracleParameter(":value", (object)value);
							OracleCommand val7 = new OracleCommand(text2, dbConnection2);
							try
							{
								val7.get_Parameters().Add(val6);
								try
								{
									((DbCommand)val7).ExecuteNonQuery();
								}
								catch (OracleException val8)
								{
									Log.Add((Exception)val8);
								}
							}
							finally
							{
								if (val7 != null)
								{
									((IDisposable)val7).Dispose();
								}
							}
						}
					}
				}
				else
				{
					using (IDbConnection dbConnection3 = GetConnection(dBConnection))
					{
						try
						{
							dbConnection3.Open();
						}
						catch (SqlException err)
						{
							Log.Add(err);
						}
						string cmdText = string.Format("UPDATE {0} SET {1}=@value WHERE {2}", table, field, where);
						SqlParameter value2 = new SqlParameter("@value", value);
						using (SqlCommand sqlCommand = new SqlCommand(cmdText, (SqlConnection)dbConnection3))
						{
							sqlCommand.Parameters.Add(value2);
							try
							{
								sqlCommand.ExecuteNonQuery();
							}
							catch (SqlException err2)
							{
								Log.Add(err2);
							}
						}
					}
				}
			}
		}

		public int DeleteData(Guid connID, string table, string pkFiled, string pkValue)
		{
			//IL_00e0: Expected O, but got Unknown
			//IL_00fb: Unknown result type (might be due to invalid IL or missing references)
			//IL_0102: Expected O, but got Unknown
			//IL_0104: Unknown result type (might be due to invalid IL or missing references)
			//IL_010e: Expected O, but got Unknown
			//IL_0109: Unknown result type (might be due to invalid IL or missing references)
			//IL_0110: Expected O, but got Unknown
			//IL_0131: Expected O, but got Unknown
			//IL_0165: Expected O, but got Unknown
			//IL_0180: Unknown result type (might be due to invalid IL or missing references)
			//IL_0187: Expected O, but got Unknown
			//IL_0189: Unknown result type (might be due to invalid IL or missing references)
			//IL_0193: Expected O, but got Unknown
			//IL_018e: Unknown result type (might be due to invalid IL or missing references)
			//IL_0195: Expected O, but got Unknown
			//IL_01b3: Expected O, but got Unknown
			int result = 0;
			RoadFlow.Data.Model.DBConnection dBConnection = Get(connID);
			if (dBConnection != null)
			{
				switch (dBConnection.Type)
				{
				case "SqlServer":
					using (IDbConnection dbConnection3 = GetConnection(dBConnection))
					{
						try
						{
							dbConnection3.Open();
						}
						catch (SqlException err)
						{
							Log.Add(err);
						}
						string cmdText = string.Format("DELETE FROM {0} WHERE {1}=@{1}", table, pkFiled);
						SqlParameter value = new SqlParameter("@" + pkFiled, pkValue);
						using (SqlCommand sqlCommand = new SqlCommand(cmdText, (SqlConnection)dbConnection3))
						{
							sqlCommand.Parameters.Add(value);
							try
							{
								result = sqlCommand.ExecuteNonQuery();
								return result;
							}
							catch (SqlException err2)
							{
								Log.Add(err2);
								return result;
							}
						}
					}
				case "Oracle":
					using (IDbConnection dbConnection2 = GetConnection(dBConnection))
					{
						try
						{
							dbConnection2.Open();
						}
						catch (OracleException val5)
						{
							Log.Add((Exception)val5);
						}
						string text2 = string.Format("DELETE FROM {0} WHERE {1}=:{1}", table, pkFiled);
						OracleParameter val6 = new OracleParameter(":" + pkFiled, (object)pkValue);
						OracleCommand val7 = new OracleCommand(text2, dbConnection2);
						try
						{
							val7.get_Parameters().Add(val6);
							try
							{
								result = ((DbCommand)val7).ExecuteNonQuery();
								return result;
							}
							catch (OracleException val8)
							{
								Log.Add((Exception)val8);
								return result;
							}
						}
						finally
						{
							if (val7 != null)
							{
								((IDisposable)val7).Dispose();
							}
						}
					}
				case "MySql":
					using (IDbConnection dbConnection = GetConnection(dBConnection))
					{
						try
						{
							dbConnection.Open();
						}
						catch (MySqlException val)
						{
							Log.Add((Exception)val);
						}
						string text = string.Format("DELETE FROM {0} WHERE {1}=@{1}", table, pkFiled);
						MySqlParameter val2 = new MySqlParameter("@" + pkFiled, (object)pkValue);
						MySqlCommand val3 = new MySqlCommand(text, dbConnection);
						try
						{
							val3.get_Parameters().Add(val2);
							try
							{
								result = ((DbCommand)val3).ExecuteNonQuery();
								return result;
							}
							catch (MySqlException val4)
							{
								Log.Add((Exception)val4);
								return result;
							}
						}
						finally
						{
							if (val3 != null)
							{
								((IDisposable)val3).Dispose();
							}
						}
					}
				default:
					return result;
				}
			}
			return result;
		}

		public DataTable GetDataTable(RoadFlow.Data.Model.DBConnection dbconn, string sql, out string pager, string query = "", List<IDbDataParameter> parList = null, int pageSize = 0)
		{
			//IL_01f5: Unknown result type (might be due to invalid IL or missing references)
			//IL_01fc: Expected O, but got Unknown
			//IL_023c: Unknown result type (might be due to invalid IL or missing references)
			//IL_0246: Expected O, but got Unknown
			//IL_026e: Unknown result type (might be due to invalid IL or missing references)
			//IL_0275: Expected O, but got Unknown
			//IL_0298: Unknown result type (might be due to invalid IL or missing references)
			//IL_029f: Expected O, but got Unknown
			//IL_0311: Unknown result type (might be due to invalid IL or missing references)
			//IL_0318: Expected O, but got Unknown
			//IL_033b: Unknown result type (might be due to invalid IL or missing references)
			//IL_0342: Expected O, but got Unknown
			//IL_036f: Expected O, but got Unknown
			//IL_03a0: Unknown result type (might be due to invalid IL or missing references)
			//IL_03a7: Expected O, but got Unknown
			//IL_03e7: Unknown result type (might be due to invalid IL or missing references)
			//IL_03f1: Expected O, but got Unknown
			//IL_0419: Unknown result type (might be due to invalid IL or missing references)
			//IL_0420: Expected O, but got Unknown
			//IL_0443: Unknown result type (might be due to invalid IL or missing references)
			//IL_044a: Expected O, but got Unknown
			//IL_04bc: Unknown result type (might be due to invalid IL or missing references)
			//IL_04c3: Expected O, but got Unknown
			//IL_04e6: Unknown result type (might be due to invalid IL or missing references)
			//IL_04ed: Expected O, but got Unknown
			//IL_0517: Expected O, but got Unknown
			pager = "";
			if (dbconn != null)
			{
				string text = string.Empty;
				switch (dbconn.Type)
				{
				case "SqlServer":
					using (SqlConnection sqlConnection = new SqlConnection(dbconn.ConnectionString))
					{
						try
						{
							sqlConnection.Open();
							List<SqlParameter> list3 = new List<SqlParameter>();
							if (parList != null && parList.Count > 0)
							{
								foreach (IDbDataParameter par in parList)
								{
									list3.Add(new SqlParameter(par.ParameterName, par.Value));
								}
							}
							DataTable dataTable3 = new DataTable();
							int num;
							switch (pageSize)
							{
							case -1:
								using (SqlCommand sqlCommand = new SqlCommand(sql, sqlConnection))
								{
									if (list3 != null && list3.Count > 0)
									{
										sqlCommand.Parameters.AddRange(list3.ToArray());
									}
									using (SqlDataAdapter sqlDataAdapter = new SqlDataAdapter(sqlCommand))
									{
										sqlDataAdapter.Fill(dataTable3);
										return dataTable3;
									}
								}
							default:
								num = pageSize;
								break;
							case 0:
								num = Tools.GetPageSize();
								break;
							}
							pageSize = num;
							int pageNumber3 = Tools.GetPageNumber();
							long count3;
							text = new RoadFlow.Data.MSSQL.DBHelper(dbconn.ConnectionString).GetPaerSql(sql, pageSize, pageNumber3, out count3, list3.ToArray());
							pager = Tools.GetPagerHtml(count3, pageSize, pageNumber3, query);
							using (SqlCommand sqlCommand2 = new SqlCommand(text, sqlConnection))
							{
								if (list3 != null && list3.Count > 0)
								{
									sqlCommand2.Parameters.AddRange(list3.ToArray());
								}
								using (SqlDataAdapter sqlDataAdapter2 = new SqlDataAdapter(sqlCommand2))
								{
									sqlDataAdapter2.Fill(dataTable3);
									return dataTable3;
								}
							}
						}
						catch (SqlException ex)
						{
							Log.Add(ex.Message, ex.StackTrace, Log.Types.系统错误, sql, text);
							return null;
						}
					}
				case "Oracle":
				{
					OracleConnection val8 = new OracleConnection(dbconn.ConnectionString);
					try
					{
						((DbConnection)val8).Open();
						List<OracleParameter> list2 = new List<OracleParameter>();
						if (parList != null && parList.Count > 0)
						{
							foreach (IDbDataParameter par2 in parList)
							{
								list2.Add(new OracleParameter(par2.ParameterName, par2.Value));
							}
						}
						DataTable dataTable2 = new DataTable();
						if (-1 != pageSize)
						{
							pageSize = ((pageSize == 0) ? Tools.GetPageSize() : pageSize);
							int pageNumber2 = Tools.GetPageNumber();
							long count2;
							text = new RoadFlow.Data.ORACLE.DBHelper(dbconn.ConnectionString).GetPaerSql(sql, pageSize, pageNumber2, out count2, list2.ToArray());
							pager = Tools.GetPagerHtml(count2, pageSize, pageNumber2, query);
							OracleCommand val9 = new OracleCommand(text, val8);
							try
							{
								if (list2 != null && list2.Count > 0)
								{
									((DbParameterCollection)val9.get_Parameters()).AddRange((Array)list2.ToArray());
								}
								OracleDataAdapter val10 = new OracleDataAdapter(val9);
								try
								{
									((DbDataAdapter)val10).Fill(dataTable2);
									return dataTable2;
								}
								finally
								{
									if (val10 != null)
									{
										((IDisposable)val10).Dispose();
									}
								}
							}
							finally
							{
								if (val9 != null)
								{
									((IDisposable)val9).Dispose();
								}
							}
						}
						OracleCommand val11 = new OracleCommand(sql, val8);
						try
						{
							if (list2 != null && list2.Count > 0)
							{
								((DbParameterCollection)val11.get_Parameters()).AddRange((Array)list2.ToArray());
							}
							OracleDataAdapter val12 = new OracleDataAdapter(val11);
							try
							{
								((DbDataAdapter)val12).Fill(dataTable2);
								return dataTable2;
							}
							finally
							{
								if (val12 != null)
								{
									((IDisposable)val12).Dispose();
								}
							}
						}
						finally
						{
							if (val11 != null)
							{
								((IDisposable)val11).Dispose();
							}
						}
					}
					catch (OracleException val13)
					{
						OracleException val14 = val13;
						Log.Add(((Exception)val14).Message, ((Exception)val14).StackTrace, Log.Types.系统错误, sql, text);
						return null;
					}
					finally
					{
						if (val8 != null)
						{
							((IDisposable)val8).Dispose();
						}
					}
				}
				case "MySql":
				{
					MySqlConnection val = new MySqlConnection(dbconn.ConnectionString);
					try
					{
						((DbConnection)val).Open();
						List<MySqlParameter> list = new List<MySqlParameter>();
						if (parList != null && parList.Count > 0)
						{
							foreach (IDbDataParameter par3 in parList)
							{
								list.Add(new MySqlParameter(par3.ParameterName, par3.Value));
							}
						}
						DataTable dataTable = new DataTable();
						if (-1 != pageSize)
						{
							pageSize = ((pageSize == 0) ? Tools.GetPageSize() : pageSize);
							int pageNumber = Tools.GetPageNumber();
							long count;
							text = new RoadFlow.Data.MySql.DBHelper(dbconn.ConnectionString).GetPaerSql(sql, pageSize, pageNumber, out count, list.ToArray());
							pager = Tools.GetPagerHtml(count, pageSize, pageNumber, query);
							MySqlCommand val2 = new MySqlCommand(text, val);
							try
							{
								if (list != null && list.Count > 0)
								{
									((DbParameterCollection)val2.get_Parameters()).AddRange((Array)list.ToArray());
								}
								MySqlDataAdapter val3 = new MySqlDataAdapter(val2);
								try
								{
									((DbDataAdapter)val3).Fill(dataTable);
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
						MySqlCommand val4 = new MySqlCommand(sql, val);
						try
						{
							if (list != null && list.Count > 0)
							{
								((DbParameterCollection)val4.get_Parameters()).AddRange((Array)list.ToArray());
							}
							MySqlDataAdapter val5 = new MySqlDataAdapter(val4);
							try
							{
								((DbDataAdapter)val5).Fill(dataTable);
								return dataTable;
							}
							finally
							{
								if (val5 != null)
								{
									((IDisposable)val5).Dispose();
								}
							}
						}
						finally
						{
							if (val4 != null)
							{
								((IDisposable)val4).Dispose();
							}
						}
					}
					catch (MySqlException val6)
					{
						MySqlException val7 = val6;
						Log.Add(((Exception)val7).Message, ((Exception)val7).StackTrace, Log.Types.系统错误, sql, text);
						return null;
					}
					finally
					{
						if (val != null)
						{
							((IDisposable)val).Dispose();
						}
					}
				}
				default:
					return null;
				}
			}
			return null;
		}

		public string GetOptionsFromSql(RoadFlow.Data.Model.DBConnection conn, string sql, IDbDataParameter[] parList = null, string value = "")
		{
			DataTable dataTable = GetDataTable(conn, sql.ReplaceSelectSql().FilterWildcard(Users.CurrentUserID.ToString()), parList);
			StringBuilder stringBuilder = new StringBuilder();
			if (dataTable.Columns.Count == 0)
			{
				return "";
			}
			foreach (DataRow row in dataTable.Rows)
			{
				string text = row[0].ToString();
				string arg = (dataTable.Columns.Count > 1) ? row[1].ToString() : text;
				stringBuilder.AppendFormat("<option value=\"{0}\"{1}>{2}</option>", text, text.Equals(value, StringComparison.CurrentCultureIgnoreCase) ? " selected=\"selected\"" : "", arg);
			}
			return stringBuilder.ToString();
		}

		public string GetOptionsFromSql(Guid connID, string sql, IDbDataParameter[] parList = null, string value = "")
		{
			RoadFlow.Data.Model.DBConnection dBConnection = Get(connID);
			if (dBConnection == null)
			{
				return "";
			}
			return GetOptionsFromSql(dBConnection, sql, parList, value);
		}

		public string GetDatabaseName(RoadFlow.Data.Model.DBConnection dbConn)
		{
			if (dbConn == null)
			{
				return string.Empty;
			}
			string result = string.Empty;
			IDbConnection connection = GetConnection(dbConn);
			if (connection != null)
			{
				result = connection.Database;
			}
			return result;
		}

		public List<string> GetPrimaryKey(RoadFlow.Data.Model.DBConnection conn, string table)
		{
			switch (conn.Type.ToLower())
			{
			case "sqlserver":
				return getPrimaryKey_SqlServer(conn, table);
			case "oracle":
				return getPrimaryKey_Oracle(conn, table);
			case "mysql":
				return getPrimaryKey_MySql(conn, table);
			default:
				return new List<string>();
			}
		}

		private List<string> getPrimaryKey_SqlServer(RoadFlow.Data.Model.DBConnection conn, string table)
		{
			string sql = string.Format("select b.column_name\r\nfrom information_schema.table_constraints a\r\ninner join information_schema.constraint_column_usage b\r\non a.constraint_name = b.constraint_name\r\nwhere a.constraint_type = 'PRIMARY KEY' and a.table_name = '{0}'", table);
			DataTable dataTable = GetDataTable(conn, sql);
			List<string> list = new List<string>();
			foreach (DataRow row in dataTable.Rows)
			{
				list.Add(row[0].ToString());
			}
			return list;
		}

		private List<string> getPrimaryKey_Oracle(RoadFlow.Data.Model.DBConnection conn, string table)
		{
			string sql = string.Format("select b.column_name from user_constraints a, user_cons_columns b where a.constraint_name = b.constraint_name and a.constraint_type = 'P' and a.table_name = UPPER('{0}')", table);
			DataTable dataTable = GetDataTable(conn, sql);
			List<string> list = new List<string>();
			foreach (DataRow row in dataTable.Rows)
			{
				list.Add(row[0].ToString());
			}
			return list;
		}

		private List<string> getPrimaryKey_MySql(RoadFlow.Data.Model.DBConnection conn, string table)
		{
			string sql = string.Format("show full fields from `{0}`", table);
			DataTable dataTable = GetDataTable(conn, sql);
			List<string> list = new List<string>();
			foreach (DataRow row in dataTable.Rows)
			{
				if (row["key"].ToString().ToUpper() == "PRI")
				{
					list.Add(row[0].ToString());
				}
			}
			return list;
		}

		public string GetFieldDataTypeOptions(string value, string dbType)
		{
			string result = string.Empty;
			switch (dbType.ToLower())
			{
			case "sqlserver":
				result = getFieldDataTypeOptions_SqlServer(value);
				break;
			case "oracle":
				result = getFieldDataTypeOptions_Oracle(value);
				break;
			case "mysql":
				result = getFieldDataTypeOptions_MySql(value);
				break;
			}
			return result;
		}

		private string getFieldDataTypeOptions_SqlServer(string value)
		{
			List<Tuple<string, string, string>> obj = new List<Tuple<string, string, string>>
			{
				new Tuple<string, string, string>("varchar", "英文字符串", "50"),
				new Tuple<string, string, string>("nvarchar", "中文字符串", "50"),
				new Tuple<string, string, string>("char", "字符", "10"),
				new Tuple<string, string, string>("datetime", "日期时间", ""),
				new Tuple<string, string, string>("text", "长文本", ""),
				new Tuple<string, string, string>("uniqueidentifier", "全局唯一ID", ""),
				new Tuple<string, string, string>("int", "整数", ""),
				new Tuple<string, string, string>("decimal", "小数", ""),
				new Tuple<string, string, string>("money", "货币", ""),
				new Tuple<string, string, string>("float", "浮点数", "")
			};
			StringBuilder stringBuilder = new StringBuilder();
			foreach (Tuple<string, string, string> item in obj)
			{
				stringBuilder.Append("<option data-length=\"" + item.Item3 + "\" value=\"" + item.Item1 + "\"" + (item.Item1.Equals(value, StringComparison.CurrentCultureIgnoreCase) ? " selected=\"selected\"" : "") + ">" + item.Item2 + "</option>");
			}
			return stringBuilder.ToString();
		}

		private string getFieldDataTypeOptions_Oracle(string value)
		{
			List<Tuple<string, string, string>> obj = new List<Tuple<string, string, string>>
			{
				new Tuple<string, string, string>("VARCHAR2", "英文字符串", "50"),
				new Tuple<string, string, string>("NVARCHAR2", "中文字符串", "50"),
				new Tuple<string, string, string>("CHAR", "字符", "10"),
				new Tuple<string, string, string>("DATE", "日期时间", ""),
				new Tuple<string, string, string>("CLOB", "长文本", ""),
				new Tuple<string, string, string>("NCLOB", "中文长文本", ""),
				new Tuple<string, string, string>("NUMBER", "数字", ""),
				new Tuple<string, string, string>("FLOAT", "浮点数", "")
			};
			StringBuilder stringBuilder = new StringBuilder();
			foreach (Tuple<string, string, string> item in obj)
			{
				stringBuilder.Append("<option data-length=\"" + item.Item3 + "\" value=\"" + item.Item1 + "\"" + (item.Item1.Equals(value, StringComparison.CurrentCultureIgnoreCase) ? " selected=\"selected\"" : "") + ">" + item.Item2 + "</option>");
			}
			return stringBuilder.ToString();
		}

		private string getFieldDataTypeOptions_MySql(string value)
		{
			List<Tuple<string, string, string>> obj = new List<Tuple<string, string, string>>
			{
				new Tuple<string, string, string>("varchar", "字符串", "255"),
				new Tuple<string, string, string>("char", "字符", "255"),
				new Tuple<string, string, string>("datetime", "日期时间", ""),
				new Tuple<string, string, string>("timestamp", "时间戳", ""),
				new Tuple<string, string, string>("text", "文本", ""),
				new Tuple<string, string, string>("longtext", "长文本", ""),
				new Tuple<string, string, string>("int", "整数", ""),
				new Tuple<string, string, string>("decimal", "小数", ""),
				new Tuple<string, string, string>("float", "浮点数", "")
			};
			StringBuilder stringBuilder = new StringBuilder();
			foreach (Tuple<string, string, string> item in obj)
			{
				stringBuilder.Append("<option data-length=\"" + item.Item3 + "\" value=\"" + item.Item1 + "\"" + (item.Item1.Equals(value, StringComparison.CurrentCultureIgnoreCase) ? " selected=\"selected\"" : "") + ">" + item.Item2 + "</option>");
			}
			return stringBuilder.ToString();
		}

		public List<string> GetConstraints(RoadFlow.Data.Model.DBConnection dbConn, string tableName)
		{
			List<string> list = new List<string>();
			switch (dbConn.Type.ToLower())
			{
			case "sqlserver":
			{
				string sql = "select name from sysobjects where parent_obj=(select id from sysobjects where name='" + tableName + "' and type='U')";
				{
					foreach (DataRow row in GetDataTable(dbConn, sql).Rows)
					{
						list.Add(row[0].ToString());
					}
					return list;
				}
			}
			default:
				return list;
			}
		}

		public bool CheckSql(string sql)
		{
			if (sql.Contains("delete", StringComparison.CurrentCultureIgnoreCase) || sql.Contains("drop", StringComparison.CurrentCultureIgnoreCase) || sql.Contains("alter", StringComparison.CurrentCultureIgnoreCase) || sql.Contains("truncate", StringComparison.CurrentCultureIgnoreCase))
			{
				foreach (string systemDataTable in Config.SystemDataTables)
				{
					string[] array = sql.Split(' ');
					foreach (string text in array)
					{
						if (text.Equals(systemDataTable, StringComparison.CurrentCultureIgnoreCase) || ("[" + text + "]").Equals("[" + systemDataTable + "]", StringComparison.CurrentCultureIgnoreCase))
						{
							return false;
						}
					}
				}
			}
			return true;
		}

		public string GetDefaultQuerySql(RoadFlow.Data.Model.DBConnection conn, string tableName)
		{
			string result = string.Empty;
			switch (conn.Type.ToLower())
			{
			case "sqlserver":
				result = "SELECT TOP 50 * FROM " + tableName;
				break;
			case "mysql":
				result = "SELECT * FROM " + tableName + " LIMIT 0,50";
				break;
			case "oracle":
				result = "SELECT * FROM " + tableName + " WHERE ROWNUM BETWEEN 0 AND 50";
				break;
			}
			return result;
		}

		public int DataTableToDB(RoadFlow.Data.Model.DBConnection conn, DataTable dt)
		{
			int result = 0;
			switch (conn.Type.ToLower())
			{
			case "sqlserver":
				result = new RoadFlow.Data.MSSQL.DBHelper().DataTableToDB(dt);
				break;
			case "mysql":
				result = new RoadFlow.Data.MySql.DBHelper().DataTableToDB(dt);
				break;
			case "oracle":
				result = new RoadFlow.Data.ORACLE.DBHelper().DataTableToDB(dt);
				break;
			}
			return result;
		}

		public string GetAllTableOptions(Guid connID, string value)
		{
			List<string> tables = GetTables(connID, 1);
			StringBuilder stringBuilder = new StringBuilder();
			foreach (string item in tables)
			{
				stringBuilder.Append("<option value=\"" + item + "\"" + (item.Equals(value, StringComparison.CurrentCultureIgnoreCase) ? " selected=\"selected\"" : "") + ">" + item + "</option>");
			}
			return stringBuilder.ToString();
		}
	}
}
