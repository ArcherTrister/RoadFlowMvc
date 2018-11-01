using RoadFlow.Data.Interface;
using RoadFlow.Data.Model;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;

namespace RoadFlow.Data.MSSQL
{
	public class DBConnection : IDBConnection
	{
		private DBHelper dbHelper = new DBHelper();

		public int Add(RoadFlow.Data.Model.DBConnection model)
		{
			string sql = "INSERT INTO DBConnection\r\n\t\t\t\t(ID,Name,Type,ConnectionString,Note) \r\n\t\t\t\tVALUES(@ID,@Name,@Type,@ConnectionString,@Note)";
			SqlParameter[] parameter = new SqlParameter[5]
			{
				new SqlParameter("@ID", SqlDbType.UniqueIdentifier, -1)
				{
					Value = model.ID
				},
				new SqlParameter("@Name", SqlDbType.VarChar, 500)
				{
					Value = model.Name
				},
				new SqlParameter("@Type", SqlDbType.VarChar, 500)
				{
					Value = model.Type
				},
				new SqlParameter("@ConnectionString", SqlDbType.VarChar, -1)
				{
					Value = model.ConnectionString
				},
				(model.Note == null) ? new SqlParameter("@Note", SqlDbType.VarChar, -1)
				{
					Value = DBNull.Value
				} : new SqlParameter("@Note", SqlDbType.VarChar, -1)
				{
					Value = model.Note
				}
			};
			return dbHelper.Execute(sql, parameter);
		}

		public int Update(RoadFlow.Data.Model.DBConnection model)
		{
			string sql = "UPDATE DBConnection SET \r\n\t\t\t\tName=@Name,Type=@Type,ConnectionString=@ConnectionString,Note=@Note\r\n\t\t\t\tWHERE ID=@ID";
			SqlParameter[] parameter = new SqlParameter[5]
			{
				new SqlParameter("@Name", SqlDbType.VarChar, 500)
				{
					Value = model.Name
				},
				new SqlParameter("@Type", SqlDbType.VarChar, 500)
				{
					Value = model.Type
				},
				new SqlParameter("@ConnectionString", SqlDbType.VarChar, -1)
				{
					Value = model.ConnectionString
				},
				(model.Note == null) ? new SqlParameter("@Note", SqlDbType.VarChar, -1)
				{
					Value = DBNull.Value
				} : new SqlParameter("@Note", SqlDbType.VarChar, -1)
				{
					Value = model.Note
				},
				new SqlParameter("@ID", SqlDbType.UniqueIdentifier, -1)
				{
					Value = model.ID
				}
			};
			return dbHelper.Execute(sql, parameter);
		}

		public int Delete(Guid id)
		{
			string sql = "DELETE FROM DBConnection WHERE ID=@ID";
			SqlParameter[] parameter = new SqlParameter[1]
			{
				new SqlParameter("@ID", SqlDbType.UniqueIdentifier)
				{
					Value = id
				}
			};
			return dbHelper.Execute(sql, parameter);
		}

		private List<RoadFlow.Data.Model.DBConnection> DataReaderToList(SqlDataReader dataReader)
		{
			List<RoadFlow.Data.Model.DBConnection> list = new List<RoadFlow.Data.Model.DBConnection>();
			RoadFlow.Data.Model.DBConnection dBConnection = null;
			while (dataReader.Read())
			{
				dBConnection = new RoadFlow.Data.Model.DBConnection();
				dBConnection.ID = dataReader.GetGuid(0);
				dBConnection.Name = dataReader.GetString(1);
				dBConnection.Type = dataReader.GetString(2);
				dBConnection.ConnectionString = dataReader.GetString(3);
				if (!dataReader.IsDBNull(4))
				{
					dBConnection.Note = dataReader.GetString(4);
				}
				list.Add(dBConnection);
			}
			return list;
		}

		public List<RoadFlow.Data.Model.DBConnection> GetAll()
		{
			string sql = "SELECT * FROM DBConnection";
			SqlDataReader dataReader = dbHelper.GetDataReader(sql);
			List<RoadFlow.Data.Model.DBConnection> result = DataReaderToList(dataReader);
			dataReader.Close();
			return result;
		}

		public long GetCount()
		{
			string sql = "SELECT COUNT(*) FROM DBConnection";
			long result;
			if (!long.TryParse(dbHelper.GetFieldValue(sql), out result))
			{
				return 0L;
			}
			return result;
		}

		public RoadFlow.Data.Model.DBConnection Get(Guid id)
		{
			string sql = "SELECT * FROM DBConnection WHERE ID=@ID";
			SqlParameter[] parameter = new SqlParameter[1]
			{
				new SqlParameter("@ID", SqlDbType.UniqueIdentifier)
				{
					Value = id
				}
			};
			SqlDataReader dataReader = dbHelper.GetDataReader(sql, parameter);
			List<RoadFlow.Data.Model.DBConnection> list = DataReaderToList(dataReader);
			dataReader.Close();
			if (list.Count <= 0)
			{
				return null;
			}
			return list[0];
		}
	}
}
