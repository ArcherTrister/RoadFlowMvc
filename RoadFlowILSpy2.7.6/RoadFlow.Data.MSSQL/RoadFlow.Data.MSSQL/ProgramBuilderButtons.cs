using RoadFlow.Data.Interface;
using RoadFlow.Data.Model;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;

namespace RoadFlow.Data.MSSQL
{
	public class ProgramBuilderButtons : IProgramBuilderButtons
	{
		private DBHelper dbHelper = new DBHelper();

		public int Add(RoadFlow.Data.Model.ProgramBuilderButtons model)
		{
			string sql = "INSERT INTO ProgramBuilderButtons\r\n\t\t\t\t(ID,ProgramID,ButtonID,ButtonName,ClientScript,Ico,ShowType,Sort,IsValidateShow) \r\n\t\t\t\tVALUES(@ID,@ProgramID,@ButtonID,@ButtonName,@ClientScript,@Ico,@ShowType,@Sort,@IsValidateShow)";
			SqlParameter[] parameter = new SqlParameter[9]
			{
				new SqlParameter("@ID", SqlDbType.UniqueIdentifier, -1)
				{
					Value = model.ID
				},
				new SqlParameter("@ProgramID", SqlDbType.UniqueIdentifier, -1)
				{
					Value = model.ProgramID
				},
				(!model.ButtonID.HasValue) ? new SqlParameter("@ButtonID", SqlDbType.UniqueIdentifier, -1)
				{
					Value = DBNull.Value
				} : new SqlParameter("@ButtonID", SqlDbType.UniqueIdentifier, -1)
				{
					Value = model.ButtonID
				},
				new SqlParameter("@ButtonName", SqlDbType.NVarChar, 400)
				{
					Value = model.ButtonName
				},
				(model.ClientScript == null) ? new SqlParameter("@ClientScript", SqlDbType.VarChar, -1)
				{
					Value = DBNull.Value
				} : new SqlParameter("@ClientScript", SqlDbType.VarChar, -1)
				{
					Value = model.ClientScript
				},
				(model.Ico == null) ? new SqlParameter("@Ico", SqlDbType.VarChar, 500)
				{
					Value = DBNull.Value
				} : new SqlParameter("@Ico", SqlDbType.VarChar, 500)
				{
					Value = model.Ico
				},
				new SqlParameter("@ShowType", SqlDbType.Int, -1)
				{
					Value = model.ShowType
				},
				new SqlParameter("@Sort", SqlDbType.Int, -1)
				{
					Value = model.Sort
				},
				new SqlParameter("@IsValidateShow", SqlDbType.Int, -1)
				{
					Value = model.IsValidateShow
				}
			};
			return dbHelper.Execute(sql, parameter);
		}

		public int Update(RoadFlow.Data.Model.ProgramBuilderButtons model)
		{
			string sql = "UPDATE ProgramBuilderButtons SET \r\n\t\t\t\tProgramID=@ProgramID,ButtonID=@ButtonID,ButtonName=@ButtonName,ClientScript=@ClientScript,Ico=@Ico,ShowType=@ShowType,Sort=@Sort,IsValidateShow=@IsValidateShow\r\n\t\t\t\tWHERE ID=@ID";
			SqlParameter[] parameter = new SqlParameter[9]
			{
				new SqlParameter("@ProgramID", SqlDbType.UniqueIdentifier, -1)
				{
					Value = model.ProgramID
				},
				(!model.ButtonID.HasValue) ? new SqlParameter("@ButtonID", SqlDbType.UniqueIdentifier, -1)
				{
					Value = DBNull.Value
				} : new SqlParameter("@ButtonID", SqlDbType.UniqueIdentifier, -1)
				{
					Value = model.ButtonID
				},
				new SqlParameter("@ButtonName", SqlDbType.NVarChar, 400)
				{
					Value = model.ButtonName
				},
				(model.ClientScript == null) ? new SqlParameter("@ClientScript", SqlDbType.VarChar, -1)
				{
					Value = DBNull.Value
				} : new SqlParameter("@ClientScript", SqlDbType.VarChar, -1)
				{
					Value = model.ClientScript
				},
				(model.Ico == null) ? new SqlParameter("@Ico", SqlDbType.VarChar, 500)
				{
					Value = DBNull.Value
				} : new SqlParameter("@Ico", SqlDbType.VarChar, 500)
				{
					Value = model.Ico
				},
				new SqlParameter("@ShowType", SqlDbType.Int, -1)
				{
					Value = model.ShowType
				},
				new SqlParameter("@Sort", SqlDbType.Int, -1)
				{
					Value = model.Sort
				},
				new SqlParameter("@IsValidateShow", SqlDbType.Int, -1)
				{
					Value = model.IsValidateShow
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
			string sql = "DELETE FROM ProgramBuilderButtons WHERE ID=@ID";
			SqlParameter[] parameter = new SqlParameter[1]
			{
				new SqlParameter("@ID", SqlDbType.UniqueIdentifier)
				{
					Value = id
				}
			};
			return dbHelper.Execute(sql, parameter);
		}

		private List<RoadFlow.Data.Model.ProgramBuilderButtons> DataReaderToList(SqlDataReader dataReader)
		{
			List<RoadFlow.Data.Model.ProgramBuilderButtons> list = new List<RoadFlow.Data.Model.ProgramBuilderButtons>();
			RoadFlow.Data.Model.ProgramBuilderButtons programBuilderButtons = null;
			while (dataReader.Read())
			{
				programBuilderButtons = new RoadFlow.Data.Model.ProgramBuilderButtons();
				programBuilderButtons.ID = dataReader.GetGuid(0);
				programBuilderButtons.ProgramID = dataReader.GetGuid(1);
				if (!dataReader.IsDBNull(2))
				{
					programBuilderButtons.ButtonID = dataReader.GetGuid(2);
				}
				programBuilderButtons.ButtonName = dataReader.GetString(3);
				if (!dataReader.IsDBNull(4))
				{
					programBuilderButtons.ClientScript = dataReader.GetString(4);
				}
				if (!dataReader.IsDBNull(5))
				{
					programBuilderButtons.Ico = dataReader.GetString(5);
				}
				programBuilderButtons.ShowType = dataReader.GetInt32(6);
				programBuilderButtons.Sort = dataReader.GetInt32(7);
				programBuilderButtons.IsValidateShow = dataReader.GetInt32(8);
				list.Add(programBuilderButtons);
			}
			return list;
		}

		public List<RoadFlow.Data.Model.ProgramBuilderButtons> GetAll()
		{
			string sql = "SELECT * FROM ProgramBuilderButtons";
			SqlDataReader dataReader = dbHelper.GetDataReader(sql);
			List<RoadFlow.Data.Model.ProgramBuilderButtons> result = DataReaderToList(dataReader);
			dataReader.Close();
			return result;
		}

		public long GetCount()
		{
			string sql = "SELECT COUNT(*) FROM ProgramBuilderButtons";
			long result;
			if (!long.TryParse(dbHelper.GetFieldValue(sql), out result))
			{
				return 0L;
			}
			return result;
		}

		public RoadFlow.Data.Model.ProgramBuilderButtons Get(Guid id)
		{
			string sql = "SELECT * FROM ProgramBuilderButtons WHERE ID=@ID";
			SqlParameter[] parameter = new SqlParameter[1]
			{
				new SqlParameter("@ID", SqlDbType.UniqueIdentifier)
				{
					Value = id
				}
			};
			SqlDataReader dataReader = dbHelper.GetDataReader(sql, parameter);
			List<RoadFlow.Data.Model.ProgramBuilderButtons> list = DataReaderToList(dataReader);
			dataReader.Close();
			if (list.Count <= 0)
			{
				return null;
			}
			return list[0];
		}

		public List<RoadFlow.Data.Model.ProgramBuilderButtons> GetAll(Guid id)
		{
			string sql = "SELECT * FROM ProgramBuilderButtons WHERE ProgramID=@ProgramID";
			SqlParameter[] parameter = new SqlParameter[1]
			{
				new SqlParameter("@ProgramID", SqlDbType.UniqueIdentifier)
				{
					Value = id
				}
			};
			SqlDataReader dataReader = dbHelper.GetDataReader(sql, parameter);
			List<RoadFlow.Data.Model.ProgramBuilderButtons> result = DataReaderToList(dataReader);
			dataReader.Close();
			return result;
		}
	}
}
