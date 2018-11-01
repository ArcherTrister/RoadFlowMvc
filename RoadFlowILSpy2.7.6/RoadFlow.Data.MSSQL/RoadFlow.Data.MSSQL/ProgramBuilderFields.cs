using RoadFlow.Data.Interface;
using RoadFlow.Data.Model;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;

namespace RoadFlow.Data.MSSQL
{
	public class ProgramBuilderFields : IProgramBuilderFields
	{
		private DBHelper dbHelper = new DBHelper();

		public int Add(RoadFlow.Data.Model.ProgramBuilderFields model)
		{
			string sql = "INSERT INTO ProgramBuilderFields\r\n\t\t\t\t(ID,ProgramID,Field,ShowTitle,Align,Width,ShowType,ShowFormat,CustomString,Sort) \r\n\t\t\t\tVALUES(@ID,@ProgramID,@Field,@ShowTitle,@Align,@Width,@ShowType,@ShowFormat,@CustomString,@Sort)";
			SqlParameter[] parameter = new SqlParameter[10]
			{
				new SqlParameter("@ID", SqlDbType.UniqueIdentifier, -1)
				{
					Value = model.ID
				},
				new SqlParameter("@ProgramID", SqlDbType.UniqueIdentifier, -1)
				{
					Value = model.ProgramID
				},
				new SqlParameter("@Field", SqlDbType.VarChar, 500)
				{
					Value = model.Field
				},
				new SqlParameter("@ShowTitle", SqlDbType.VarChar, -1)
				{
					Value = model.ShowTitle
				},
				new SqlParameter("@Align", SqlDbType.VarChar, 50)
				{
					Value = model.Align
				},
				(model.Width == null) ? new SqlParameter("@Width", SqlDbType.VarChar, 50)
				{
					Value = DBNull.Value
				} : new SqlParameter("@Width", SqlDbType.VarChar, 50)
				{
					Value = model.Width
				},
				new SqlParameter("@ShowType", SqlDbType.Int, -1)
				{
					Value = model.ShowType
				},
				(model.ShowFormat == null) ? new SqlParameter("@ShowFormat", SqlDbType.VarChar, 50)
				{
					Value = DBNull.Value
				} : new SqlParameter("@ShowFormat", SqlDbType.VarChar, 50)
				{
					Value = model.ShowFormat
				},
				(model.CustomString == null) ? new SqlParameter("@CustomString", SqlDbType.VarChar, -1)
				{
					Value = DBNull.Value
				} : new SqlParameter("@CustomString", SqlDbType.VarChar, -1)
				{
					Value = model.CustomString
				},
				new SqlParameter("@Sort", SqlDbType.Int, -1)
				{
					Value = model.Sort
				}
			};
			return dbHelper.Execute(sql, parameter);
		}

		public int Update(RoadFlow.Data.Model.ProgramBuilderFields model)
		{
			string sql = "UPDATE ProgramBuilderFields SET \r\n\t\t\t\tProgramID=@ProgramID,Field=@Field,ShowTitle=@ShowTitle,Align=@Align,Width=@Width,ShowType=@ShowType,ShowFormat=@ShowFormat,CustomString=@CustomString,Sort=@Sort\r\n\t\t\t\tWHERE ID=@ID";
			SqlParameter[] parameter = new SqlParameter[10]
			{
				new SqlParameter("@ProgramID", SqlDbType.UniqueIdentifier, -1)
				{
					Value = model.ProgramID
				},
				new SqlParameter("@Field", SqlDbType.VarChar, 500)
				{
					Value = model.Field
				},
				new SqlParameter("@ShowTitle", SqlDbType.VarChar, -1)
				{
					Value = model.ShowTitle
				},
				new SqlParameter("@Align", SqlDbType.VarChar, 50)
				{
					Value = model.Align
				},
				(model.Width == null) ? new SqlParameter("@Width", SqlDbType.VarChar, 50)
				{
					Value = DBNull.Value
				} : new SqlParameter("@Width", SqlDbType.VarChar, 50)
				{
					Value = model.Width
				},
				new SqlParameter("@ShowType", SqlDbType.Int, -1)
				{
					Value = model.ShowType
				},
				(model.ShowFormat == null) ? new SqlParameter("@ShowFormat", SqlDbType.VarChar, 50)
				{
					Value = DBNull.Value
				} : new SqlParameter("@ShowFormat", SqlDbType.VarChar, 50)
				{
					Value = model.ShowFormat
				},
				(model.CustomString == null) ? new SqlParameter("@CustomString", SqlDbType.VarChar, -1)
				{
					Value = DBNull.Value
				} : new SqlParameter("@CustomString", SqlDbType.VarChar, -1)
				{
					Value = model.CustomString
				},
				new SqlParameter("@Sort", SqlDbType.Int, -1)
				{
					Value = model.Sort
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
			string sql = "DELETE FROM ProgramBuilderFields WHERE ID=@ID";
			SqlParameter[] parameter = new SqlParameter[1]
			{
				new SqlParameter("@ID", SqlDbType.UniqueIdentifier)
				{
					Value = id
				}
			};
			return dbHelper.Execute(sql, parameter);
		}

		private List<RoadFlow.Data.Model.ProgramBuilderFields> DataReaderToList(SqlDataReader dataReader)
		{
			List<RoadFlow.Data.Model.ProgramBuilderFields> list = new List<RoadFlow.Data.Model.ProgramBuilderFields>();
			RoadFlow.Data.Model.ProgramBuilderFields programBuilderFields = null;
			while (dataReader.Read())
			{
				programBuilderFields = new RoadFlow.Data.Model.ProgramBuilderFields();
				programBuilderFields.ID = dataReader.GetGuid(0);
				programBuilderFields.ProgramID = dataReader.GetGuid(1);
				if (!dataReader.IsDBNull(2))
				{
					programBuilderFields.Field = dataReader.GetString(2);
				}
				programBuilderFields.ShowTitle = dataReader.GetString(3);
				programBuilderFields.Align = dataReader.GetString(4);
				if (!dataReader.IsDBNull(5))
				{
					programBuilderFields.Width = dataReader.GetString(5);
				}
				programBuilderFields.ShowType = dataReader.GetInt32(6);
				if (!dataReader.IsDBNull(7))
				{
					programBuilderFields.ShowFormat = dataReader.GetString(7);
				}
				if (!dataReader.IsDBNull(8))
				{
					programBuilderFields.CustomString = dataReader.GetString(8);
				}
				programBuilderFields.Sort = dataReader.GetInt32(9);
				list.Add(programBuilderFields);
			}
			return list;
		}

		public List<RoadFlow.Data.Model.ProgramBuilderFields> GetAll()
		{
			string sql = "SELECT * FROM ProgramBuilderFields";
			SqlDataReader dataReader = dbHelper.GetDataReader(sql);
			List<RoadFlow.Data.Model.ProgramBuilderFields> result = DataReaderToList(dataReader);
			dataReader.Close();
			return result;
		}

		public long GetCount()
		{
			string sql = "SELECT COUNT(*) FROM ProgramBuilderFields";
			long result;
			if (!long.TryParse(dbHelper.GetFieldValue(sql), out result))
			{
				return 0L;
			}
			return result;
		}

		public RoadFlow.Data.Model.ProgramBuilderFields Get(Guid id)
		{
			string sql = "SELECT * FROM ProgramBuilderFields WHERE ID=@ID";
			SqlParameter[] parameter = new SqlParameter[1]
			{
				new SqlParameter("@ID", SqlDbType.UniqueIdentifier)
				{
					Value = id
				}
			};
			SqlDataReader dataReader = dbHelper.GetDataReader(sql, parameter);
			List<RoadFlow.Data.Model.ProgramBuilderFields> list = DataReaderToList(dataReader);
			dataReader.Close();
			if (list.Count <= 0)
			{
				return null;
			}
			return list[0];
		}

		public List<RoadFlow.Data.Model.ProgramBuilderFields> GetAll(Guid programID)
		{
			string sql = "SELECT * FROM ProgramBuilderFields WHERE ProgramID=@ProgramID";
			SqlParameter[] parameter = new SqlParameter[1]
			{
				new SqlParameter("@ProgramID", SqlDbType.UniqueIdentifier)
				{
					Value = programID
				}
			};
			SqlDataReader dataReader = dbHelper.GetDataReader(sql, parameter);
			List<RoadFlow.Data.Model.ProgramBuilderFields> result = DataReaderToList(dataReader);
			dataReader.Close();
			return result;
		}

		public int DeleteByProgramID(Guid id)
		{
			string sql = "DELETE FROM ProgramBuilderFields WHERE ProgramID=@ProgramID";
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
