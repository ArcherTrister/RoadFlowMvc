using RoadFlow.Data.Interface;
using RoadFlow.Data.Model;
using RoadFlow.Utility;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;

namespace RoadFlow.Data.MSSQL
{
	public class Organize : IOrganize
	{
		private DBHelper dbHelper = new DBHelper();

		public int Add(RoadFlow.Data.Model.Organize model)
		{
			string sql = "INSERT INTO Organize\r\n\t\t\t\t(ID,Name,Number,Type,Status,ParentID,Sort,Depth,ChildsLength,ChargeLeader,Leader,Note,IntID) \r\n\t\t\t\tVALUES(@ID,@Name,@Number,@Type,@Status,@ParentID,@Sort,@Depth,@ChildsLength,@ChargeLeader,@Leader,@Note,@IntID)";
			SqlParameter[] parameter = new SqlParameter[13]
			{
				new SqlParameter("@ID", SqlDbType.UniqueIdentifier, -1)
				{
					Value = model.ID
				},
				new SqlParameter("@Name", SqlDbType.VarChar, 2000)
				{
					Value = model.Name
				},
				new SqlParameter("@Number", SqlDbType.VarChar, 900)
				{
					Value = model.Number
				},
				new SqlParameter("@Type", SqlDbType.Int, -1)
				{
					Value = model.Type
				},
				new SqlParameter("@Status", SqlDbType.Int, -1)
				{
					Value = model.Status
				},
				new SqlParameter("@ParentID", SqlDbType.UniqueIdentifier, -1)
				{
					Value = model.ParentID
				},
				new SqlParameter("@Sort", SqlDbType.Int, -1)
				{
					Value = model.Sort
				},
				new SqlParameter("@Depth", SqlDbType.Int, -1)
				{
					Value = model.Depth
				},
				new SqlParameter("@ChildsLength", SqlDbType.Int, -1)
				{
					Value = model.ChildsLength
				},
				(model.ChargeLeader == null) ? new SqlParameter("@ChargeLeader", SqlDbType.VarChar, 200)
				{
					Value = DBNull.Value
				} : new SqlParameter("@ChargeLeader", SqlDbType.VarChar, 200)
				{
					Value = model.ChargeLeader
				},
				(model.Leader == null) ? new SqlParameter("@Leader", SqlDbType.VarChar, 200)
				{
					Value = DBNull.Value
				} : new SqlParameter("@Leader", SqlDbType.VarChar, 200)
				{
					Value = model.Leader
				},
				(model.Note == null) ? new SqlParameter("@Note", SqlDbType.NVarChar, -1)
				{
					Value = DBNull.Value
				} : new SqlParameter("@Note", SqlDbType.NVarChar, -1)
				{
					Value = model.Note
				},
				new SqlParameter("@IntID", SqlDbType.Int, -1)
				{
					Value = model.IntID
				}
			};
			return dbHelper.Execute(sql, parameter);
		}

		public int Update(RoadFlow.Data.Model.Organize model)
		{
			string sql = "UPDATE Organize SET \r\n\t\t\t\tName=@Name,Number=@Number,Type=@Type,Status=@Status,ParentID=@ParentID,Sort=@Sort,Depth=@Depth,ChildsLength=@ChildsLength,ChargeLeader=@ChargeLeader,Leader=@Leader,Note=@Note,IntID=@IntID \r\n\t\t\t\tWHERE ID=@ID";
			SqlParameter[] parameter = new SqlParameter[13]
			{
				new SqlParameter("@Name", SqlDbType.VarChar, 2000)
				{
					Value = model.Name
				},
				new SqlParameter("@Number", SqlDbType.VarChar, 900)
				{
					Value = model.Number
				},
				new SqlParameter("@Type", SqlDbType.Int, -1)
				{
					Value = model.Type
				},
				new SqlParameter("@Status", SqlDbType.Int, -1)
				{
					Value = model.Status
				},
				new SqlParameter("@ParentID", SqlDbType.UniqueIdentifier, -1)
				{
					Value = model.ParentID
				},
				new SqlParameter("@Sort", SqlDbType.Int, -1)
				{
					Value = model.Sort
				},
				new SqlParameter("@Depth", SqlDbType.Int, -1)
				{
					Value = model.Depth
				},
				new SqlParameter("@ChildsLength", SqlDbType.Int, -1)
				{
					Value = model.ChildsLength
				},
				(model.ChargeLeader == null) ? new SqlParameter("@ChargeLeader", SqlDbType.VarChar, 200)
				{
					Value = DBNull.Value
				} : new SqlParameter("@ChargeLeader", SqlDbType.VarChar, 200)
				{
					Value = model.ChargeLeader
				},
				(model.Leader == null) ? new SqlParameter("@Leader", SqlDbType.VarChar, 200)
				{
					Value = DBNull.Value
				} : new SqlParameter("@Leader", SqlDbType.VarChar, 200)
				{
					Value = model.Leader
				},
				(model.Note == null) ? new SqlParameter("@Note", SqlDbType.NVarChar, -1)
				{
					Value = DBNull.Value
				} : new SqlParameter("@Note", SqlDbType.NVarChar, -1)
				{
					Value = model.Note
				},
				new SqlParameter("@IntID", SqlDbType.Int, -1)
				{
					Value = model.IntID
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
			string sql = "DELETE FROM Organize WHERE ID=@ID";
			SqlParameter[] parameter = new SqlParameter[1]
			{
				new SqlParameter("@ID", SqlDbType.UniqueIdentifier)
				{
					Value = id
				}
			};
			return dbHelper.Execute(sql, parameter);
		}

		private List<RoadFlow.Data.Model.Organize> DataReaderToList(SqlDataReader dataReader)
		{
			List<RoadFlow.Data.Model.Organize> list = new List<RoadFlow.Data.Model.Organize>();
			RoadFlow.Data.Model.Organize organize = null;
			while (dataReader.Read())
			{
				organize = new RoadFlow.Data.Model.Organize();
				organize.ID = dataReader.GetGuid(0);
				organize.Name = dataReader.GetString(1);
				organize.Number = dataReader.GetString(2);
				organize.Type = dataReader.GetInt32(3);
				organize.Status = dataReader.GetInt32(4);
				organize.ParentID = dataReader.GetGuid(5);
				organize.Sort = dataReader.GetInt32(6);
				organize.Depth = dataReader.GetInt32(7);
				organize.ChildsLength = dataReader.GetInt32(8);
				if (!dataReader.IsDBNull(9))
				{
					organize.ChargeLeader = dataReader.GetString(9);
				}
				if (!dataReader.IsDBNull(10))
				{
					organize.Leader = dataReader.GetString(10);
				}
				if (!dataReader.IsDBNull(11))
				{
					organize.Note = dataReader.GetString(11);
				}
				organize.IntID = dataReader.GetInt32(12);
				list.Add(organize);
			}
			return list;
		}

		public List<RoadFlow.Data.Model.Organize> GetAll()
		{
			string sql = "SELECT * FROM Organize";
			SqlDataReader dataReader = dbHelper.GetDataReader(sql);
			List<RoadFlow.Data.Model.Organize> result = DataReaderToList(dataReader);
			dataReader.Close();
			return result;
		}

		public long GetCount()
		{
			string sql = "SELECT COUNT(*) FROM Organize";
			long result;
			if (!long.TryParse(dbHelper.GetFieldValue(sql), out result))
			{
				return 0L;
			}
			return result;
		}

		public RoadFlow.Data.Model.Organize Get(Guid id)
		{
			string sql = "SELECT * FROM Organize WHERE ID=@ID";
			SqlParameter[] parameter = new SqlParameter[1]
			{
				new SqlParameter("@ID", SqlDbType.UniqueIdentifier)
				{
					Value = id
				}
			};
			SqlDataReader dataReader = dbHelper.GetDataReader(sql, parameter);
			List<RoadFlow.Data.Model.Organize> list = DataReaderToList(dataReader);
			dataReader.Close();
			if (list.Count <= 0)
			{
				return null;
			}
			return list[0];
		}

		public RoadFlow.Data.Model.Organize GetRoot()
		{
			string sql = "SELECT * FROM Organize WHERE ParentID=@ParentID";
			SqlParameter[] parameter = new SqlParameter[1]
			{
				new SqlParameter("@ParentID", SqlDbType.UniqueIdentifier)
				{
					Value = Guid.Empty
				}
			};
			SqlDataReader dataReader = dbHelper.GetDataReader(sql, parameter);
			List<RoadFlow.Data.Model.Organize> list = DataReaderToList(dataReader);
			dataReader.Close();
			if (list.Count <= 0)
			{
				return null;
			}
			return list[0];
		}

		public List<RoadFlow.Data.Model.Organize> GetChilds(Guid ID)
		{
			string sql = "SELECT * FROM Organize WHERE ParentID=@ParentID ORDER BY Sort";
			SqlParameter[] parameter = new SqlParameter[1]
			{
				new SqlParameter("@ParentID", SqlDbType.UniqueIdentifier)
				{
					Value = ID
				}
			};
			SqlDataReader dataReader = dbHelper.GetDataReader(sql, parameter);
			List<RoadFlow.Data.Model.Organize> result = DataReaderToList(dataReader);
			dataReader.Close();
			return result;
		}

		public int GetMaxSort(Guid id)
		{
			string sql = "SELECT ISNULL(MAX(Sort),0)+1 FROM Organize WHERE ParentID=@ParentID";
			SqlParameter[] parameter = new SqlParameter[1]
			{
				new SqlParameter("@ParentID", SqlDbType.UniqueIdentifier)
				{
					Value = id
				}
			};
			return dbHelper.GetFieldValue(sql, parameter).ToInt();
		}

		public int UpdateChildsLength(Guid id, int length)
		{
			string sql = "UPDATE Organize SET ChildsLength=@ChildsLength WHERE ID=@ID";
			SqlParameter[] parameter = new SqlParameter[2]
			{
				new SqlParameter("@ChildsLength", SqlDbType.Int)
				{
					Value = length
				},
				new SqlParameter("@ID", SqlDbType.UniqueIdentifier)
				{
					Value = id
				}
			};
			return dbHelper.Execute(sql, parameter);
		}

		public int UpdateSort(Guid id, int sort)
		{
			string sql = "UPDATE Organize SET Sort=@Sort WHERE ID=@ID";
			SqlParameter[] parameter = new SqlParameter[2]
			{
				new SqlParameter("@Sort", SqlDbType.Int)
				{
					Value = sort
				},
				new SqlParameter("@ID", SqlDbType.UniqueIdentifier)
				{
					Value = id
				}
			};
			return dbHelper.Execute(sql, parameter);
		}

		public List<RoadFlow.Data.Model.Organize> GetAllParent(string number)
		{
			string sql = "SELECT * FROM Organize WHERE ID IN(" + Tools.GetSqlInString(number) + ") ORDER BY Depth";
			SqlDataReader dataReader = dbHelper.GetDataReader(sql);
			List<RoadFlow.Data.Model.Organize> result = DataReaderToList(dataReader);
			dataReader.Close();
			return result;
		}

		public List<RoadFlow.Data.Model.Organize> GetAllChild(string number)
		{
			string sql = "SELECT * FROM Organize WHERE Number LIKE '" + number.ReplaceSql() + "%' ORDER BY Sort";
			SqlDataReader dataReader = dbHelper.GetDataReader(sql);
			List<RoadFlow.Data.Model.Organize> result = DataReaderToList(dataReader);
			dataReader.Close();
			return result;
		}
	}
}
