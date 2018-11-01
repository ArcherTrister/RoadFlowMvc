using RoadFlow.Data.Interface;
using RoadFlow.Data.Model;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;

namespace RoadFlow.Data.MSSQL
{
	public class ProgramBuilderValidates : IProgramBuilderValidates
	{
		private DBHelper dbHelper = new DBHelper();

		public int Add(RoadFlow.Data.Model.ProgramBuilderValidates model)
		{
			string sql = "INSERT INTO ProgramBuilderValidates\r\n\t\t\t\t(ID,ProgramID,TableName,FieldName,FieldNote,Validate) \r\n\t\t\t\tVALUES(@ID,@ProgramID,@TableName,@FieldName,@FieldNote,@Validate)";
			SqlParameter[] parameter = new SqlParameter[6]
			{
				new SqlParameter("@ID", SqlDbType.UniqueIdentifier, -1)
				{
					Value = model.ID
				},
				new SqlParameter("@ProgramID", SqlDbType.UniqueIdentifier, -1)
				{
					Value = model.ProgramID
				},
				new SqlParameter("@TableName", SqlDbType.VarChar, 500)
				{
					Value = model.TableName
				},
				new SqlParameter("@FieldName", SqlDbType.VarChar, 500)
				{
					Value = model.FieldName
				},
				(model.FieldNote == null) ? new SqlParameter("@FieldNote", SqlDbType.NVarChar, 1000)
				{
					Value = DBNull.Value
				} : new SqlParameter("@FieldNote", SqlDbType.NVarChar, 1000)
				{
					Value = model.FieldNote
				},
				new SqlParameter("@Validate", SqlDbType.Int, -1)
				{
					Value = model.Validate
				}
			};
			return dbHelper.Execute(sql, parameter);
		}

		public int Update(RoadFlow.Data.Model.ProgramBuilderValidates model)
		{
			string sql = "UPDATE ProgramBuilderValidates SET \r\n\t\t\t\tProgramID=@ProgramID,TableName=@TableName,FieldName=@FieldName,FieldNote=@FieldNote,Validate=@Validate\r\n\t\t\t\tWHERE ID=@ID";
			SqlParameter[] parameter = new SqlParameter[6]
			{
				new SqlParameter("@ProgramID", SqlDbType.UniqueIdentifier, -1)
				{
					Value = model.ProgramID
				},
				new SqlParameter("@TableName", SqlDbType.VarChar, 500)
				{
					Value = model.TableName
				},
				new SqlParameter("@FieldName", SqlDbType.VarChar, 500)
				{
					Value = model.FieldName
				},
				(model.FieldNote == null) ? new SqlParameter("@FieldNote", SqlDbType.NVarChar, 1000)
				{
					Value = DBNull.Value
				} : new SqlParameter("@FieldNote", SqlDbType.NVarChar, 1000)
				{
					Value = model.FieldNote
				},
				new SqlParameter("@Validate", SqlDbType.Int, -1)
				{
					Value = model.Validate
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
			string sql = "DELETE FROM ProgramBuilderValidates WHERE ID=@ID";
			SqlParameter[] parameter = new SqlParameter[1]
			{
				new SqlParameter("@ID", SqlDbType.UniqueIdentifier)
				{
					Value = id
				}
			};
			return dbHelper.Execute(sql, parameter);
		}

		private List<RoadFlow.Data.Model.ProgramBuilderValidates> DataReaderToList(SqlDataReader dataReader)
		{
			List<RoadFlow.Data.Model.ProgramBuilderValidates> list = new List<RoadFlow.Data.Model.ProgramBuilderValidates>();
			RoadFlow.Data.Model.ProgramBuilderValidates programBuilderValidates = null;
			while (dataReader.Read())
			{
				programBuilderValidates = new RoadFlow.Data.Model.ProgramBuilderValidates();
				programBuilderValidates.ID = dataReader.GetGuid(0);
				programBuilderValidates.ProgramID = dataReader.GetGuid(1);
				programBuilderValidates.TableName = dataReader.GetString(2);
				programBuilderValidates.FieldName = dataReader.GetString(3);
				if (!dataReader.IsDBNull(4))
				{
					programBuilderValidates.FieldNote = dataReader.GetString(4);
				}
				programBuilderValidates.Validate = dataReader.GetInt32(5);
				list.Add(programBuilderValidates);
			}
			return list;
		}

		public List<RoadFlow.Data.Model.ProgramBuilderValidates> GetAll()
		{
			string sql = "SELECT * FROM ProgramBuilderValidates";
			SqlDataReader dataReader = dbHelper.GetDataReader(sql);
			List<RoadFlow.Data.Model.ProgramBuilderValidates> result = DataReaderToList(dataReader);
			dataReader.Close();
			return result;
		}

		public long GetCount()
		{
			string sql = "SELECT COUNT(*) FROM ProgramBuilderValidates";
			long result;
			if (!long.TryParse(dbHelper.GetFieldValue(sql), out result))
			{
				return 0L;
			}
			return result;
		}

		public RoadFlow.Data.Model.ProgramBuilderValidates Get(Guid id)
		{
			string sql = "SELECT * FROM ProgramBuilderValidates WHERE ID=@ID";
			SqlParameter[] parameter = new SqlParameter[1]
			{
				new SqlParameter("@ID", SqlDbType.UniqueIdentifier)
				{
					Value = id
				}
			};
			SqlDataReader dataReader = dbHelper.GetDataReader(sql, parameter);
			List<RoadFlow.Data.Model.ProgramBuilderValidates> list = DataReaderToList(dataReader);
			dataReader.Close();
			if (list.Count <= 0)
			{
				return null;
			}
			return list[0];
		}

		public List<RoadFlow.Data.Model.ProgramBuilderValidates> GetAll(Guid programID)
		{
			string sql = "SELECT * FROM ProgramBuilderValidates WHERE ProgramID=@ProgramID";
			SqlParameter[] parameter = new SqlParameter[1]
			{
				new SqlParameter("@ProgramID", SqlDbType.UniqueIdentifier)
				{
					Value = programID
				}
			};
			SqlDataReader dataReader = dbHelper.GetDataReader(sql, parameter);
			List<RoadFlow.Data.Model.ProgramBuilderValidates> result = DataReaderToList(dataReader);
			dataReader.Close();
			return result;
		}

		public int DeleteByProgramID(Guid id)
		{
			string sql = "DELETE FROM ProgramBuilderValidates WHERE ProgramID=@ProgramID";
			SqlParameter[] parameter = new SqlParameter[1]
			{
				new SqlParameter("@ProgramID", SqlDbType.UniqueIdentifier)
				{
					Value = id
				}
			};
			return dbHelper.Execute(sql, parameter);
		}
	}
}
