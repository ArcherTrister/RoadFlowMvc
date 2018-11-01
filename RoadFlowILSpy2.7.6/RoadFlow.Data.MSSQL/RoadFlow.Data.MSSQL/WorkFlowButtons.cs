using RoadFlow.Data.Interface;
using RoadFlow.Data.Model;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;

namespace RoadFlow.Data.MSSQL
{
	public class WorkFlowButtons : IWorkFlowButtons
	{
		private DBHelper dbHelper = new DBHelper();

		public int Add(RoadFlow.Data.Model.WorkFlowButtons model)
		{
			string sql = "INSERT INTO WorkFlowButtons\r\n\t\t\t\t(ID,Title,Ico,Script,Note,Sort) \r\n\t\t\t\tVALUES(@ID,@Title,@Ico,@Script,@Note,@Sort)";
			SqlParameter[] parameter = new SqlParameter[6]
			{
				new SqlParameter("@ID", SqlDbType.UniqueIdentifier, -1)
				{
					Value = model.ID
				},
				new SqlParameter("@Title", SqlDbType.NVarChar, 1000)
				{
					Value = model.Title
				},
				(model.Ico == null) ? new SqlParameter("@Ico", SqlDbType.VarChar, 500)
				{
					Value = DBNull.Value
				} : new SqlParameter("@Ico", SqlDbType.VarChar, 500)
				{
					Value = model.Ico
				},
				(model.Script == null) ? new SqlParameter("@Script", SqlDbType.VarChar, -1)
				{
					Value = DBNull.Value
				} : new SqlParameter("@Script", SqlDbType.VarChar, -1)
				{
					Value = model.Script
				},
				(model.Note == null) ? new SqlParameter("@Note", SqlDbType.VarChar, -1)
				{
					Value = DBNull.Value
				} : new SqlParameter("@Note", SqlDbType.VarChar, -1)
				{
					Value = model.Note
				},
				new SqlParameter("@Sort", SqlDbType.Int, -1)
				{
					Value = model.Sort
				}
			};
			return dbHelper.Execute(sql, parameter);
		}

		public int Update(RoadFlow.Data.Model.WorkFlowButtons model)
		{
			string sql = "UPDATE WorkFlowButtons SET \r\n\t\t\t\tTitle=@Title,Ico=@Ico,Script=@Script,Note=@Note,Sort=@Sort\r\n\t\t\t\tWHERE ID=@ID";
			SqlParameter[] parameter = new SqlParameter[6]
			{
				new SqlParameter("@Title", SqlDbType.NVarChar, 1000)
				{
					Value = model.Title
				},
				(model.Ico == null) ? new SqlParameter("@Ico", SqlDbType.VarChar, 500)
				{
					Value = DBNull.Value
				} : new SqlParameter("@Ico", SqlDbType.VarChar, 500)
				{
					Value = model.Ico
				},
				(model.Script == null) ? new SqlParameter("@Script", SqlDbType.VarChar, -1)
				{
					Value = DBNull.Value
				} : new SqlParameter("@Script", SqlDbType.VarChar, -1)
				{
					Value = model.Script
				},
				(model.Note == null) ? new SqlParameter("@Note", SqlDbType.VarChar, -1)
				{
					Value = DBNull.Value
				} : new SqlParameter("@Note", SqlDbType.VarChar, -1)
				{
					Value = model.Note
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
			string sql = "DELETE FROM WorkFlowButtons WHERE ID=@ID";
			SqlParameter[] parameter = new SqlParameter[1]
			{
				new SqlParameter("@ID", SqlDbType.UniqueIdentifier)
				{
					Value = id
				}
			};
			return dbHelper.Execute(sql, parameter);
		}

		private List<RoadFlow.Data.Model.WorkFlowButtons> DataReaderToList(SqlDataReader dataReader)
		{
			List<RoadFlow.Data.Model.WorkFlowButtons> list = new List<RoadFlow.Data.Model.WorkFlowButtons>();
			RoadFlow.Data.Model.WorkFlowButtons workFlowButtons = null;
			while (dataReader.Read())
			{
				workFlowButtons = new RoadFlow.Data.Model.WorkFlowButtons();
				workFlowButtons.ID = dataReader.GetGuid(0);
				workFlowButtons.Title = dataReader.GetString(1);
				if (!dataReader.IsDBNull(2))
				{
					workFlowButtons.Ico = dataReader.GetString(2);
				}
				if (!dataReader.IsDBNull(3))
				{
					workFlowButtons.Script = dataReader.GetString(3);
				}
				if (!dataReader.IsDBNull(4))
				{
					workFlowButtons.Note = dataReader.GetString(4);
				}
				workFlowButtons.Sort = dataReader.GetInt32(5);
				list.Add(workFlowButtons);
			}
			return list;
		}

		public List<RoadFlow.Data.Model.WorkFlowButtons> GetAll()
		{
			string sql = "SELECT * FROM WorkFlowButtons";
			SqlDataReader dataReader = dbHelper.GetDataReader(sql);
			List<RoadFlow.Data.Model.WorkFlowButtons> result = DataReaderToList(dataReader);
			dataReader.Close();
			return result;
		}

		public long GetCount()
		{
			string sql = "SELECT COUNT(*) FROM WorkFlowButtons";
			long result;
			if (!long.TryParse(dbHelper.GetFieldValue(sql), out result))
			{
				return 0L;
			}
			return result;
		}

		public RoadFlow.Data.Model.WorkFlowButtons Get(Guid id)
		{
			string sql = "SELECT * FROM WorkFlowButtons WHERE ID=@ID";
			SqlParameter[] parameter = new SqlParameter[1]
			{
				new SqlParameter("@ID", SqlDbType.UniqueIdentifier)
				{
					Value = id
				}
			};
			SqlDataReader dataReader = dbHelper.GetDataReader(sql, parameter);
			List<RoadFlow.Data.Model.WorkFlowButtons> list = DataReaderToList(dataReader);
			dataReader.Close();
			if (list.Count <= 0)
			{
				return null;
			}
			return list[0];
		}

		public int GetMaxSort()
		{
			string sql = "SELECT ISNULL(MAX(Sort),0)+1 FROM WorkFlowButtons";
			string fieldValue = dbHelper.GetFieldValue(sql);
			if (!fieldValue.IsInt())
			{
				return 1;
			}
			return fieldValue.ToInt();
		}
	}
}
