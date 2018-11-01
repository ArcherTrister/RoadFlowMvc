using RoadFlow.Data.Interface;
using RoadFlow.Data.Model;
using RoadFlow.Utility;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;

namespace RoadFlow.Data.MSSQL
{
	public class Users : IUsers
	{
		private DBHelper dbHelper = new DBHelper();

		public int Add(RoadFlow.Data.Model.Users model)
		{
			string sql = "INSERT INTO Users\r\n\t\t\t\t(ID,Name,Account,Password,Status,Sort,Note,Mobile,Tel,OtherTel,Fax,Email,QQ,HeadImg,WeiXin,Sex) \r\n\t\t\t\tVALUES(@ID,@Name,@Account,@Password,@Status,@Sort,@Note,@Mobile,@Tel,@OtherTel,@Fax,@Email,@QQ,@HeadImg,@WeiXin,@Sex)";
			SqlParameter[] parameter = new SqlParameter[16]
			{
				new SqlParameter("@ID", SqlDbType.UniqueIdentifier, -1)
				{
					Value = model.ID
				},
				new SqlParameter("@Name", SqlDbType.NVarChar, 100)
				{
					Value = model.Name
				},
				new SqlParameter("@Account", SqlDbType.VarChar, 255)
				{
					Value = model.Account
				},
				new SqlParameter("@Password", SqlDbType.VarChar, 500)
				{
					Value = model.Password
				},
				new SqlParameter("@Status", SqlDbType.Int, -1)
				{
					Value = model.Status
				},
				new SqlParameter("@Sort", SqlDbType.Int, -1)
				{
					Value = model.Sort
				},
				(model.Note == null) ? new SqlParameter("@Note", SqlDbType.NVarChar, -1)
				{
					Value = DBNull.Value
				} : new SqlParameter("@Note", SqlDbType.NVarChar, -1)
				{
					Value = model.Note
				},
				(model.Mobile == null) ? new SqlParameter("@Mobile", SqlDbType.VarChar, 50)
				{
					Value = DBNull.Value
				} : new SqlParameter("@Mobile", SqlDbType.VarChar, 50)
				{
					Value = model.Mobile
				},
				(model.Tel == null) ? new SqlParameter("@Tel", SqlDbType.VarChar, 500)
				{
					Value = DBNull.Value
				} : new SqlParameter("@Tel", SqlDbType.VarChar, 500)
				{
					Value = model.Tel
				},
				(model.OtherTel == null) ? new SqlParameter("@OtherTel", SqlDbType.VarChar, 500)
				{
					Value = DBNull.Value
				} : new SqlParameter("@OtherTel", SqlDbType.VarChar, 500)
				{
					Value = model.OtherTel
				},
				(model.Fax == null) ? new SqlParameter("@Fax", SqlDbType.VarChar, 50)
				{
					Value = DBNull.Value
				} : new SqlParameter("@Fax", SqlDbType.VarChar, 50)
				{
					Value = model.Fax
				},
				(model.Email == null) ? new SqlParameter("@Email", SqlDbType.VarChar, 500)
				{
					Value = DBNull.Value
				} : new SqlParameter("@Email", SqlDbType.VarChar, 500)
				{
					Value = model.Email
				},
				(model.QQ == null) ? new SqlParameter("@QQ", SqlDbType.VarChar, 50)
				{
					Value = DBNull.Value
				} : new SqlParameter("@QQ", SqlDbType.VarChar, 50)
				{
					Value = model.QQ
				},
				(model.HeadImg == null) ? new SqlParameter("@HeadImg", SqlDbType.VarChar, 500)
				{
					Value = DBNull.Value
				} : new SqlParameter("@HeadImg", SqlDbType.VarChar, 500)
				{
					Value = model.HeadImg
				},
				(model.WeiXin == null) ? new SqlParameter("@WeiXin", SqlDbType.VarChar, 50)
				{
					Value = DBNull.Value
				} : new SqlParameter("@WeiXin", SqlDbType.VarChar, 50)
				{
					Value = model.WeiXin
				},
				(!model.Sex.HasValue) ? new SqlParameter("@Sex", SqlDbType.Int, -1)
				{
					Value = DBNull.Value
				} : new SqlParameter("@Sex", SqlDbType.Int, -1)
				{
					Value = model.Sex
				}
			};
			return dbHelper.Execute(sql, parameter);
		}

		public int Update(RoadFlow.Data.Model.Users model)
		{
			string sql = "UPDATE Users SET \r\n\t\t\t\tName=@Name,Account=@Account,Password=@Password,Status=@Status,Sort=@Sort,Note=@Note,Mobile=@Mobile,Tel=@Tel,OtherTel=@OtherTel,Fax=@Fax,Email=@Email,QQ=@QQ,HeadImg=@HeadImg,WeiXin=@WeiXin,Sex=@Sex\r\n\t\t\t\tWHERE ID=@ID";
			SqlParameter[] parameter = new SqlParameter[16]
			{
				new SqlParameter("@Name", SqlDbType.NVarChar, 100)
				{
					Value = model.Name
				},
				new SqlParameter("@Account", SqlDbType.VarChar, 255)
				{
					Value = model.Account
				},
				new SqlParameter("@Password", SqlDbType.VarChar, 500)
				{
					Value = model.Password
				},
				new SqlParameter("@Status", SqlDbType.Int, -1)
				{
					Value = model.Status
				},
				new SqlParameter("@Sort", SqlDbType.Int, -1)
				{
					Value = model.Sort
				},
				(model.Note == null) ? new SqlParameter("@Note", SqlDbType.NVarChar, -1)
				{
					Value = DBNull.Value
				} : new SqlParameter("@Note", SqlDbType.NVarChar, -1)
				{
					Value = model.Note
				},
				(model.Mobile == null) ? new SqlParameter("@Mobile", SqlDbType.VarChar, 50)
				{
					Value = DBNull.Value
				} : new SqlParameter("@Mobile", SqlDbType.VarChar, 50)
				{
					Value = model.Mobile
				},
				(model.Tel == null) ? new SqlParameter("@Tel", SqlDbType.VarChar, 500)
				{
					Value = DBNull.Value
				} : new SqlParameter("@Tel", SqlDbType.VarChar, 500)
				{
					Value = model.Tel
				},
				(model.OtherTel == null) ? new SqlParameter("@OtherTel", SqlDbType.VarChar, 500)
				{
					Value = DBNull.Value
				} : new SqlParameter("@OtherTel", SqlDbType.VarChar, 500)
				{
					Value = model.OtherTel
				},
				(model.Fax == null) ? new SqlParameter("@Fax", SqlDbType.VarChar, 50)
				{
					Value = DBNull.Value
				} : new SqlParameter("@Fax", SqlDbType.VarChar, 50)
				{
					Value = model.Fax
				},
				(model.Email == null) ? new SqlParameter("@Email", SqlDbType.VarChar, 500)
				{
					Value = DBNull.Value
				} : new SqlParameter("@Email", SqlDbType.VarChar, 500)
				{
					Value = model.Email
				},
				(model.QQ == null) ? new SqlParameter("@QQ", SqlDbType.VarChar, 50)
				{
					Value = DBNull.Value
				} : new SqlParameter("@QQ", SqlDbType.VarChar, 50)
				{
					Value = model.QQ
				},
				(model.HeadImg == null) ? new SqlParameter("@HeadImg", SqlDbType.VarChar, 500)
				{
					Value = DBNull.Value
				} : new SqlParameter("@HeadImg", SqlDbType.VarChar, 500)
				{
					Value = model.HeadImg
				},
				(model.WeiXin == null) ? new SqlParameter("@WeiXin", SqlDbType.VarChar, 50)
				{
					Value = DBNull.Value
				} : new SqlParameter("@WeiXin", SqlDbType.VarChar, 50)
				{
					Value = model.WeiXin
				},
				(!model.Sex.HasValue) ? new SqlParameter("@Sex", SqlDbType.Int, -1)
				{
					Value = DBNull.Value
				} : new SqlParameter("@Sex", SqlDbType.Int, -1)
				{
					Value = model.Sex
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
			string sql = "DELETE FROM Users WHERE ID=@ID";
			SqlParameter[] parameter = new SqlParameter[1]
			{
				new SqlParameter("@ID", SqlDbType.UniqueIdentifier)
				{
					Value = id
				}
			};
			return dbHelper.Execute(sql, parameter);
		}

		private List<RoadFlow.Data.Model.Users> DataReaderToList(SqlDataReader dataReader)
		{
			List<RoadFlow.Data.Model.Users> list = new List<RoadFlow.Data.Model.Users>();
			RoadFlow.Data.Model.Users users = null;
			while (dataReader.Read())
			{
				users = new RoadFlow.Data.Model.Users();
				users.ID = dataReader.GetGuid(0);
				users.Name = dataReader.GetString(1);
				users.Account = dataReader.GetString(2);
				users.Password = dataReader.GetString(3);
				users.Status = dataReader.GetInt32(4);
				users.Sort = dataReader.GetInt32(5);
				if (!dataReader.IsDBNull(6))
				{
					users.Note = dataReader.GetString(6);
				}
				if (!dataReader.IsDBNull(7))
				{
					users.Mobile = dataReader.GetString(7);
				}
				if (!dataReader.IsDBNull(8))
				{
					users.Tel = dataReader.GetString(8);
				}
				if (!dataReader.IsDBNull(9))
				{
					users.OtherTel = dataReader.GetString(9);
				}
				if (!dataReader.IsDBNull(10))
				{
					users.Fax = dataReader.GetString(10);
				}
				if (!dataReader.IsDBNull(11))
				{
					users.Email = dataReader.GetString(11);
				}
				if (!dataReader.IsDBNull(12))
				{
					users.QQ = dataReader.GetString(12);
				}
				if (!dataReader.IsDBNull(13))
				{
					users.HeadImg = dataReader.GetString(13);
				}
				if (!dataReader.IsDBNull(14))
				{
					users.WeiXin = dataReader.GetString(14);
				}
				if (!dataReader.IsDBNull(15))
				{
					users.Sex = dataReader.GetInt32(15);
				}
				list.Add(users);
			}
			return list;
		}

		public List<RoadFlow.Data.Model.Users> GetAll()
		{
			string sql = "SELECT * FROM Users";
			SqlDataReader dataReader = dbHelper.GetDataReader(sql);
			List<RoadFlow.Data.Model.Users> result = DataReaderToList(dataReader);
			dataReader.Close();
			return result;
		}

		public long GetCount()
		{
			string sql = "SELECT COUNT(*) FROM Users";
			long result;
			if (!long.TryParse(dbHelper.GetFieldValue(sql), out result))
			{
				return 0L;
			}
			return result;
		}

		public RoadFlow.Data.Model.Users Get(Guid id)
		{
			string sql = "SELECT * FROM Users WHERE ID=@ID";
			SqlParameter[] parameter = new SqlParameter[1]
			{
				new SqlParameter("@ID", SqlDbType.UniqueIdentifier)
				{
					Value = id
				}
			};
			SqlDataReader dataReader = dbHelper.GetDataReader(sql, parameter);
			List<RoadFlow.Data.Model.Users> list = DataReaderToList(dataReader);
			dataReader.Close();
			if (list.Count <= 0)
			{
				return null;
			}
			return list[0];
		}

		public RoadFlow.Data.Model.Users GetByAccount(string account)
		{
			string sql = "SELECT * FROM Users WHERE Account=@Account";
			SqlParameter[] parameter = new SqlParameter[1]
			{
				new SqlParameter("@Account", SqlDbType.VarChar, 255)
				{
					Value = account
				}
			};
			SqlDataReader dataReader = dbHelper.GetDataReader(sql, parameter);
			List<RoadFlow.Data.Model.Users> list = DataReaderToList(dataReader);
			dataReader.Close();
			if (list.Count <= 0)
			{
				return null;
			}
			return list[0];
		}

		public List<RoadFlow.Data.Model.Users> GetAllByOrganizeID(Guid organizeID)
		{
			string sql = "SELECT * FROM Users WHERE ID in(SELECT UserID FROM UsersRelation WHERE OrganizeID=@OrganizeID) ORDER BY Sort";
			SqlParameter[] parameter = new SqlParameter[1]
			{
				new SqlParameter("@OrganizeID", SqlDbType.UniqueIdentifier)
				{
					Value = organizeID
				}
			};
			SqlDataReader dataReader = dbHelper.GetDataReader(sql, parameter);
			List<RoadFlow.Data.Model.Users> result = DataReaderToList(dataReader);
			dataReader.Close();
			return result;
		}

		public List<RoadFlow.Data.Model.Users> GetAllByOrganizeIDArray(Guid[] organizeIDArray)
		{
			if (organizeIDArray != null && organizeIDArray.Length != 0)
			{
				string sql = "SELECT * FROM Users WHERE ID in(SELECT UserID FROM UsersRelation WHERE OrganizeID in(" + Tools.GetSqlInString(organizeIDArray) + ")) ORDER BY Sort";
				SqlDataReader dataReader = dbHelper.GetDataReader(sql);
				List<RoadFlow.Data.Model.Users> result = DataReaderToList(dataReader);
				dataReader.Close();
				return result;
			}
			return new List<RoadFlow.Data.Model.Users>();
		}

		public bool HasAccount(string account, string userID = "")
		{
			string text = "SELECT ID FROM Users WHERE Account=@Account";
			List<SqlParameter> list = new List<SqlParameter>();
			list.Add(new SqlParameter("@Account", SqlDbType.VarChar)
			{
				Value = account
			});
			if (userID.IsGuid())
			{
				text += " and ID<>@ID";
				list.Add(new SqlParameter("@ID", SqlDbType.UniqueIdentifier)
				{
					Value = userID.ToGuid()
				});
			}
			SqlDataReader dataReader = dbHelper.GetDataReader(text, list.ToArray());
			bool hasRows = dataReader.HasRows;
			dataReader.Close();
			return hasRows;
		}

		public bool UpdatePassword(string password, Guid userID)
		{
			string sql = "UPDATE Users SET Password=@Password WHERE ID=@ID";
			SqlParameter[] parameter = new SqlParameter[2]
			{
				new SqlParameter("@Password", SqlDbType.VarChar)
				{
					Value = password
				},
				new SqlParameter("@ID", SqlDbType.UniqueIdentifier)
				{
					Value = userID
				}
			};
			return dbHelper.Execute(sql, parameter) == 1;
		}

		public int UpdateSort(Guid userID, int sort)
		{
			string sql = "UPDATE Users SET Sort=@Sort WHERE ID=@ID";
			SqlParameter[] parameter = new SqlParameter[2]
			{
				new SqlParameter("@Sort", SqlDbType.Int)
				{
					Value = sort
				},
				new SqlParameter("@ID", SqlDbType.UniqueIdentifier)
				{
					Value = userID
				}
			};
			return dbHelper.Execute(sql, parameter);
		}

		public List<RoadFlow.Data.Model.Users> GetAllByIDString(string idString)
		{
			string sql = "SELECT * FROM Users WHERE ID IN(" + Tools.GetSqlInString(idString) + ")";
			SqlDataReader dataReader = dbHelper.GetDataReader(sql);
			List<RoadFlow.Data.Model.Users> result = DataReaderToList(dataReader);
			dataReader.Close();
			return result;
		}

		public List<RoadFlow.Data.Model.Users> GetAllByWorkGroupID(Guid workgroupid)
		{
			string sql = "SELECT * FROM Users WHERE ID IN(SELECT UserID FROM WorkGroupUsers WHERE WorkGroupID='" + workgroupid + "')";
			SqlDataReader dataReader = dbHelper.GetDataReader(sql);
			List<RoadFlow.Data.Model.Users> result = DataReaderToList(dataReader);
			dataReader.Close();
			return result;
		}
	}
}
