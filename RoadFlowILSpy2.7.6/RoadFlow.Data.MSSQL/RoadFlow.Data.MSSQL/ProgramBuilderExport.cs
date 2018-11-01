using RoadFlow.Data.Interface;
using RoadFlow.Data.Model;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;

namespace RoadFlow.Data.MSSQL
{
	public class ProgramBuilderExport : IProgramBuilderExport
	{
		private DBHelper dbHelper = new DBHelper();

		public int Add(RoadFlow.Data.Model.ProgramBuilderExport model)
		{
			string sql = "INSERT INTO ProgramBuilderExport\r\n\t\t\t\t(ID,ProgramID,Field,ShowTitle,Align,Width,ShowType,DataType,ShowFormat,CustomString,Sort) \r\n\t\t\t\tVALUES(@ID,@ProgramID,@Field,@ShowTitle,@Align,@Width,@ShowType,@DataType,@ShowFormat,@CustomString,@Sort)";
			SqlParameter[] parameter = new SqlParameter[11]
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
				(model.ShowTitle == null) ? new SqlParameter("@ShowTitle", SqlDbType.NVarChar, 1000)
				{
					Value = DBNull.Value
				} : new SqlParameter("@ShowTitle", SqlDbType.NVarChar, 1000)
				{
					Value = model.ShowTitle
				},
				new SqlParameter("@Align", SqlDbType.Int, -1)
				{
					Value = model.Align
				},
				(!model.Width.HasValue) ? new SqlParameter("@Width", SqlDbType.Int, -1)
				{
					Value = DBNull.Value
				} : new SqlParameter("@Width", SqlDbType.Int, -1)
				{
					Value = model.Width
				},
				(!model.ShowType.HasValue) ? new SqlParameter("@ShowType", SqlDbType.Int, -1)
				{
					Value = DBNull.Value
				} : new SqlParameter("@ShowType", SqlDbType.Int, -1)
				{
					Value = model.ShowType
				},
				(!model.DataType.HasValue) ? new SqlParameter("@DataType", SqlDbType.Int, -1)
				{
					Value = DBNull.Value
				} : new SqlParameter("@DataType", SqlDbType.Int, -1)
				{
					Value = model.DataType
				},
				(model.ShowFormat == null) ? new SqlParameter("@ShowFormat", SqlDbType.VarChar, 50)
				{
					Value = DBNull.Value
				} : new SqlParameter("@ShowFormat", SqlDbType.VarChar, 50)
				{
					Value = model.ShowFormat
				},
				(model.CustomString == null) ? new SqlParameter("@CustomString", SqlDbType.VarChar, 5000)
				{
					Value = DBNull.Value
				} : new SqlParameter("@CustomString", SqlDbType.VarChar, 5000)
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

		public int Update(RoadFlow.Data.Model.ProgramBuilderExport model)
		{
			string sql = "UPDATE ProgramBuilderExport SET \r\n\t\t\t\tProgramID=@ProgramID,Field=@Field,ShowTitle=@ShowTitle,Align=@Align,Width=@Width,ShowType=@ShowType,DataType=@DataType,ShowFormat=@ShowFormat,CustomString=@CustomString,Sort=@Sort\r\n\t\t\t\tWHERE ID=@ID";
			SqlParameter[] parameter = new SqlParameter[11]
			{
				new SqlParameter("@ProgramID", SqlDbType.UniqueIdentifier, -1)
				{
					Value = model.ProgramID
				},
				new SqlParameter("@Field", SqlDbType.VarChar, 500)
				{
					Value = model.Field
				},
				(model.ShowTitle == null) ? new SqlParameter("@ShowTitle", SqlDbType.NVarChar, 1000)
				{
					Value = DBNull.Value
				} : new SqlParameter("@ShowTitle", SqlDbType.NVarChar, 1000)
				{
					Value = model.ShowTitle
				},
				new SqlParameter("@Align", SqlDbType.Int, -1)
				{
					Value = model.Align
				},
				(!model.Width.HasValue) ? new SqlParameter("@Width", SqlDbType.Int, -1)
				{
					Value = DBNull.Value
				} : new SqlParameter("@Width", SqlDbType.Int, -1)
				{
					Value = model.Width
				},
				(!model.ShowType.HasValue) ? new SqlParameter("@ShowType", SqlDbType.Int, -1)
				{
					Value = DBNull.Value
				} : new SqlParameter("@ShowType", SqlDbType.Int, -1)
				{
					Value = model.ShowType
				},
				(!model.DataType.HasValue) ? new SqlParameter("@DataType", SqlDbType.Int, -1)
				{
					Value = DBNull.Value
				} : new SqlParameter("@DataType", SqlDbType.Int, -1)
				{
					Value = model.DataType
				},
				(model.ShowFormat == null) ? new SqlParameter("@ShowFormat", SqlDbType.VarChar, 50)
				{
					Value = DBNull.Value
				} : new SqlParameter("@ShowFormat", SqlDbType.VarChar, 50)
				{
					Value = model.ShowFormat
				},
				(model.CustomString == null) ? new SqlParameter("@CustomString", SqlDbType.VarChar, 5000)
				{
					Value = DBNull.Value
				} : new SqlParameter("@CustomString", SqlDbType.VarChar, 5000)
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
			string sql = "DELETE FROM ProgramBuilderExport WHERE ID=@ID";
			SqlParameter[] parameter = new SqlParameter[1]
			{
				new SqlParameter("@ID", SqlDbType.UniqueIdentifier)
				{
					Value = id
				}
			};
			return dbHelper.Execute(sql, parameter);
		}

		private List<RoadFlow.Data.Model.ProgramBuilderExport> DataReaderToList(SqlDataReader dataReader)
		{
			List<RoadFlow.Data.Model.ProgramBuilderExport> list = new List<RoadFlow.Data.Model.ProgramBuilderExport>();
			RoadFlow.Data.Model.ProgramBuilderExport programBuilderExport = null;
			while (dataReader.Read())
			{
				programBuilderExport = new RoadFlow.Data.Model.ProgramBuilderExport();
				programBuilderExport.ID = dataReader.GetGuid(0);
				programBuilderExport.ProgramID = dataReader.GetGuid(1);
				programBuilderExport.Field = dataReader.GetString(2);
				if (!dataReader.IsDBNull(3))
				{
					programBuilderExport.ShowTitle = dataReader.GetString(3);
				}
				programBuilderExport.Align = dataReader.GetInt32(4);
				if (!dataReader.IsDBNull(5))
				{
					programBuilderExport.Width = dataReader.GetInt32(5);
				}
				if (!dataReader.IsDBNull(6))
				{
					programBuilderExport.ShowType = dataReader.GetInt32(6);
				}
				if (!dataReader.IsDBNull(7))
				{
					programBuilderExport.DataType = dataReader.GetInt32(7);
				}
				if (!dataReader.IsDBNull(8))
				{
					programBuilderExport.ShowFormat = dataReader.GetString(8);
				}
				if (!dataReader.IsDBNull(9))
				{
					programBuilderExport.CustomString = dataReader.GetString(9);
				}
				programBuilderExport.Sort = dataReader.GetInt32(10);
				list.Add(programBuilderExport);
			}
			return list;
		}

		public List<RoadFlow.Data.Model.ProgramBuilderExport> GetAll()
		{
			string sql = "SELECT * FROM ProgramBuilderExport";
			SqlDataReader dataReader = dbHelper.GetDataReader(sql);
			List<RoadFlow.Data.Model.ProgramBuilderExport> result = DataReaderToList(dataReader);
			dataReader.Close();
			return result;
		}

		public long GetCount()
		{
			string sql = "SELECT COUNT(*) FROM ProgramBuilderExport";
			long result;
			if (!long.TryParse(dbHelper.GetFieldValue(sql), out result))
			{
				return 0L;
			}
			return result;
		}

		public RoadFlow.Data.Model.ProgramBuilderExport Get(Guid id)
		{
			string sql = "SELECT * FROM ProgramBuilderExport WHERE ID=@ID";
			SqlParameter[] parameter = new SqlParameter[1]
			{
				new SqlParameter("@ID", SqlDbType.UniqueIdentifier)
				{
					Value = id
				}
			};
			SqlDataReader dataReader = dbHelper.GetDataReader(sql, parameter);
			List<RoadFlow.Data.Model.ProgramBuilderExport> list = DataReaderToList(dataReader);
			dataReader.Close();
			if (list.Count <= 0)
			{
				return null;
			}
			return list[0];
		}

		public List<RoadFlow.Data.Model.ProgramBuilderExport> GetAll(Guid programID)
		{
			string sql = "SELECT * FROM ProgramBuilderExport WHERE ProgramID=@ProgramID";
			SqlParameter[] parameter = new SqlParameter[1]
			{
				new SqlParameter("@ProgramID", SqlDbType.UniqueIdentifier)
				{
					Value = programID
				}
			};
			SqlDataReader dataReader = dbHelper.GetDataReader(sql, parameter);
			List<RoadFlow.Data.Model.ProgramBuilderExport> result = DataReaderToList(dataReader);
			dataReader.Close();
			return result;
		}
	}
}
