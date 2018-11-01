using RoadFlow.Data.Interface;
using RoadFlow.Data.Model;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;

namespace RoadFlow.Data.MSSQL
{
	public class ProgramBuilderQuerys : IProgramBuilderQuerys
	{
		private DBHelper dbHelper = new DBHelper();

		public int Add(RoadFlow.Data.Model.ProgramBuilderQuerys model)
		{
			string sql = "INSERT INTO ProgramBuilderQuerys\r\n\t\t\t\t(ID,ProgramID,Field,ShowTitle,Operators,ControlName,InputType,Width,Sort,DataSource,DataSourceString,DataLinkID,IsQueryUsers,Value) \r\n\t\t\t\tVALUES(@ID,@ProgramID,@Field,@ShowTitle,@Operators,@ControlName,@InputType,@Width,@Sort,@DataSource,@DataSourceString,@DataLinkID,@IsQueryUsers,@Value)";
			SqlParameter[] parameter = new SqlParameter[14]
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
				new SqlParameter("@ShowTitle", SqlDbType.NVarChar, 1000)
				{
					Value = model.ShowTitle
				},
				new SqlParameter("@Operators", SqlDbType.VarChar, 50)
				{
					Value = model.Operators
				},
				new SqlParameter("@ControlName", SqlDbType.VarChar, 50)
				{
					Value = model.ControlName
				},
				new SqlParameter("@InputType", SqlDbType.Int, -1)
				{
					Value = model.InputType
				},
				(model.Width == null) ? new SqlParameter("@Width", SqlDbType.VarChar, 50)
				{
					Value = DBNull.Value
				} : new SqlParameter("@Width", SqlDbType.VarChar, 50)
				{
					Value = model.Width
				},
				new SqlParameter("@Sort", SqlDbType.Int, -1)
				{
					Value = model.Sort
				},
				(!model.DataSource.HasValue) ? new SqlParameter("@DataSource", SqlDbType.Int, -1)
				{
					Value = DBNull.Value
				} : new SqlParameter("@DataSource", SqlDbType.Int, -1)
				{
					Value = model.DataSource
				},
				(model.DataSourceString == null) ? new SqlParameter("@DataSourceString", SqlDbType.VarChar, -1)
				{
					Value = DBNull.Value
				} : new SqlParameter("@DataSourceString", SqlDbType.VarChar, -1)
				{
					Value = model.DataSourceString
				},
				(model.DataLinkID == null) ? new SqlParameter("@DataLinkID", SqlDbType.VarChar, 50)
				{
					Value = DBNull.Value
				} : new SqlParameter("@DataLinkID", SqlDbType.VarChar, 50)
				{
					Value = model.DataLinkID
				},
				(!model.IsQueryUsers.HasValue) ? new SqlParameter("@IsQueryUsers", SqlDbType.Int, -1)
				{
					Value = DBNull.Value
				} : new SqlParameter("@IsQueryUsers", SqlDbType.Int, -1)
				{
					Value = model.IsQueryUsers
				},
				(model.Value == null) ? new SqlParameter("@Value", SqlDbType.VarChar, 50)
				{
					Value = DBNull.Value
				} : new SqlParameter("@Value", SqlDbType.VarChar, 50)
				{
					Value = model.Value
				}
			};
			return dbHelper.Execute(sql, parameter);
		}

		public int Update(RoadFlow.Data.Model.ProgramBuilderQuerys model)
		{
			string sql = "UPDATE ProgramBuilderQuerys SET \r\n\t\t\t\tProgramID=@ProgramID,Field=@Field,ShowTitle=@ShowTitle,Operators=@Operators,ControlName=@ControlName,InputType=@InputType,Width=@Width,Sort=@Sort,DataSource=@DataSource,DataSourceString=@DataSourceString,DataLinkID=@DataLinkID,IsQueryUsers=@IsQueryUsers,Value=@Value\r\n\t\t\t\tWHERE ID=@ID";
			SqlParameter[] parameter = new SqlParameter[14]
			{
				new SqlParameter("@ProgramID", SqlDbType.UniqueIdentifier, -1)
				{
					Value = model.ProgramID
				},
				new SqlParameter("@Field", SqlDbType.VarChar, 500)
				{
					Value = model.Field
				},
				new SqlParameter("@ShowTitle", SqlDbType.NVarChar, 1000)
				{
					Value = model.ShowTitle
				},
				new SqlParameter("@Operators", SqlDbType.VarChar, 50)
				{
					Value = model.Operators
				},
				new SqlParameter("@ControlName", SqlDbType.VarChar, 50)
				{
					Value = model.ControlName
				},
				new SqlParameter("@InputType", SqlDbType.Int, -1)
				{
					Value = model.InputType
				},
				(model.Width == null) ? new SqlParameter("@Width", SqlDbType.VarChar, 50)
				{
					Value = DBNull.Value
				} : new SqlParameter("@Width", SqlDbType.VarChar, 50)
				{
					Value = model.Width
				},
				new SqlParameter("@Sort", SqlDbType.Int, -1)
				{
					Value = model.Sort
				},
				(!model.DataSource.HasValue) ? new SqlParameter("@DataSource", SqlDbType.Int, -1)
				{
					Value = DBNull.Value
				} : new SqlParameter("@DataSource", SqlDbType.Int, -1)
				{
					Value = model.DataSource
				},
				(model.DataSourceString == null) ? new SqlParameter("@DataSourceString", SqlDbType.VarChar, -1)
				{
					Value = DBNull.Value
				} : new SqlParameter("@DataSourceString", SqlDbType.VarChar, -1)
				{
					Value = model.DataSourceString
				},
				(model.DataLinkID == null) ? new SqlParameter("@DataLinkID", SqlDbType.VarChar, 50)
				{
					Value = DBNull.Value
				} : new SqlParameter("@DataLinkID", SqlDbType.VarChar, 50)
				{
					Value = model.DataLinkID
				},
				(!model.IsQueryUsers.HasValue) ? new SqlParameter("@IsQueryUsers", SqlDbType.Int, -1)
				{
					Value = DBNull.Value
				} : new SqlParameter("@IsQueryUsers", SqlDbType.Int, -1)
				{
					Value = model.IsQueryUsers
				},
				(model.Value == null) ? new SqlParameter("@Value", SqlDbType.VarChar, 50)
				{
					Value = DBNull.Value
				} : new SqlParameter("@Value", SqlDbType.VarChar, 50)
				{
					Value = model.Value
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
			string sql = "DELETE FROM ProgramBuilderQuerys WHERE ID=@ID";
			SqlParameter[] parameter = new SqlParameter[1]
			{
				new SqlParameter("@ID", SqlDbType.UniqueIdentifier)
				{
					Value = id
				}
			};
			return dbHelper.Execute(sql, parameter);
		}

		private List<RoadFlow.Data.Model.ProgramBuilderQuerys> DataReaderToList(SqlDataReader dataReader)
		{
			List<RoadFlow.Data.Model.ProgramBuilderQuerys> list = new List<RoadFlow.Data.Model.ProgramBuilderQuerys>();
			RoadFlow.Data.Model.ProgramBuilderQuerys programBuilderQuerys = null;
			while (dataReader.Read())
			{
				programBuilderQuerys = new RoadFlow.Data.Model.ProgramBuilderQuerys();
				programBuilderQuerys.ID = dataReader.GetGuid(0);
				programBuilderQuerys.ProgramID = dataReader.GetGuid(1);
				programBuilderQuerys.Field = dataReader.GetString(2);
				programBuilderQuerys.ShowTitle = dataReader.GetString(3);
				programBuilderQuerys.Operators = dataReader.GetString(4);
				programBuilderQuerys.ControlName = dataReader.GetString(5);
				programBuilderQuerys.InputType = dataReader.GetInt32(6);
				if (!dataReader.IsDBNull(7))
				{
					programBuilderQuerys.Width = dataReader.GetString(7);
				}
				programBuilderQuerys.Sort = dataReader.GetInt32(8);
				if (!dataReader.IsDBNull(9))
				{
					programBuilderQuerys.DataSource = dataReader.GetInt32(9);
				}
				if (!dataReader.IsDBNull(10))
				{
					programBuilderQuerys.DataSourceString = dataReader.GetString(10);
				}
				if (!dataReader.IsDBNull(11))
				{
					programBuilderQuerys.DataLinkID = dataReader.GetString(11);
				}
				if (!dataReader.IsDBNull(12))
				{
					programBuilderQuerys.IsQueryUsers = dataReader.GetInt32(12);
				}
				if (!dataReader.IsDBNull(13))
				{
					programBuilderQuerys.Value = dataReader.GetString(13);
				}
				list.Add(programBuilderQuerys);
			}
			return list;
		}

		public List<RoadFlow.Data.Model.ProgramBuilderQuerys> GetAll()
		{
			string sql = "SELECT * FROM ProgramBuilderQuerys";
			SqlDataReader dataReader = dbHelper.GetDataReader(sql);
			List<RoadFlow.Data.Model.ProgramBuilderQuerys> result = DataReaderToList(dataReader);
			dataReader.Close();
			return result;
		}

		public long GetCount()
		{
			string sql = "SELECT COUNT(*) FROM ProgramBuilderQuerys";
			long result;
			if (!long.TryParse(dbHelper.GetFieldValue(sql), out result))
			{
				return 0L;
			}
			return result;
		}

		public RoadFlow.Data.Model.ProgramBuilderQuerys Get(Guid id)
		{
			string sql = "SELECT * FROM ProgramBuilderQuerys WHERE ID=@ID";
			SqlParameter[] parameter = new SqlParameter[1]
			{
				new SqlParameter("@ID", SqlDbType.UniqueIdentifier)
				{
					Value = id
				}
			};
			SqlDataReader dataReader = dbHelper.GetDataReader(sql, parameter);
			List<RoadFlow.Data.Model.ProgramBuilderQuerys> list = DataReaderToList(dataReader);
			dataReader.Close();
			if (list.Count <= 0)
			{
				return null;
			}
			return list[0];
		}

		public List<RoadFlow.Data.Model.ProgramBuilderQuerys> GetAll(Guid programID)
		{
			string sql = "SELECT * FROM ProgramBuilderQuerys WHERE ProgramID=@ProgramID";
			SqlParameter[] parameter = new SqlParameter[1]
			{
				new SqlParameter("@ProgramID", SqlDbType.UniqueIdentifier)
				{
					Value = programID
				}
			};
			SqlDataReader dataReader = dbHelper.GetDataReader(sql, parameter);
			List<RoadFlow.Data.Model.ProgramBuilderQuerys> result = DataReaderToList(dataReader);
			dataReader.Close();
			return result;
		}

		public int DeleteByProgramID(Guid id)
		{
			string sql = "DELETE FROM ProgramBuilderQuerys WHERE ProgramID=@ProgramID";
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
