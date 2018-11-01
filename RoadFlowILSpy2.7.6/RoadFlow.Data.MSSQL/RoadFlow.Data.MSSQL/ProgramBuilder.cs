using RoadFlow.Data.Interface;
using RoadFlow.Data.Model;
using RoadFlow.Utility;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Text;

namespace RoadFlow.Data.MSSQL
{
	public class ProgramBuilder : IProgramBuilder
	{
		private DBHelper dbHelper = new DBHelper();

		public int Add(RoadFlow.Data.Model.ProgramBuilder model)
		{
			string sql = "INSERT INTO ProgramBuilder\r\n\t\t\t\t(ID,Name,Type,CreateTime,PublishTime,CreateUser,SQL,IsAdd,DBConnID,Status,FormID,EditModel,Width,Height,ButtonLocation,IsPager,ClientScript,ExportTemplate,ExportHeaderText,ExportFileName,TableStyle,TableHead,TableName,InDataNumberFiledName) \r\n\t\t\t\tVALUES(@ID,@Name,@Type,@CreateTime,@PublishTime,@CreateUser,@SQL,@IsAdd,@DBConnID,@Status,@FormID,@EditModel,@Width,@Height,@ButtonLocation,@IsPager,@ClientScript,@ExportTemplate,@ExportHeaderText,@ExportFileName,@TableStyle,@TableHead,@TableName,@InDataNumberFiledName)";
			SqlParameter[] parameter = new SqlParameter[24]
			{
				new SqlParameter("@ID", SqlDbType.UniqueIdentifier, -1)
				{
					Value = model.ID
				},
				new SqlParameter("@Name", SqlDbType.NVarChar, 1000)
				{
					Value = model.Name
				},
				new SqlParameter("@Type", SqlDbType.UniqueIdentifier, -1)
				{
					Value = model.Type
				},
				new SqlParameter("@CreateTime", SqlDbType.DateTime, 8)
				{
					Value = model.CreateTime
				},
				(!model.PublishTime.HasValue) ? new SqlParameter("@PublishTime", SqlDbType.DateTime, 8)
				{
					Value = DBNull.Value
				} : new SqlParameter("@PublishTime", SqlDbType.DateTime, 8)
				{
					Value = model.PublishTime
				},
				new SqlParameter("@CreateUser", SqlDbType.UniqueIdentifier, -1)
				{
					Value = model.CreateUser
				},
				new SqlParameter("@SQL", SqlDbType.VarChar, -1)
				{
					Value = model.SQL
				},
				new SqlParameter("@IsAdd", SqlDbType.Int, -1)
				{
					Value = model.IsAdd
				},
				new SqlParameter("@DBConnID", SqlDbType.UniqueIdentifier, -1)
				{
					Value = model.DBConnID
				},
				new SqlParameter("@Status", SqlDbType.Int, -1)
				{
					Value = model.Status
				},
				(model.FormID == null) ? new SqlParameter("@FormID", SqlDbType.VarChar, 500)
				{
					Value = DBNull.Value
				} : new SqlParameter("@FormID", SqlDbType.VarChar, 500)
				{
					Value = model.FormID
				},
				(!model.EditModel.HasValue) ? new SqlParameter("@EditModel", SqlDbType.Int, -1)
				{
					Value = DBNull.Value
				} : new SqlParameter("@EditModel", SqlDbType.Int, -1)
				{
					Value = model.EditModel
				},
				(model.Width == null) ? new SqlParameter("@Width", SqlDbType.VarChar, 50)
				{
					Value = DBNull.Value
				} : new SqlParameter("@Width", SqlDbType.VarChar, 50)
				{
					Value = model.Width
				},
				(model.Height == null) ? new SqlParameter("@Height", SqlDbType.VarChar, 50)
				{
					Value = DBNull.Value
				} : new SqlParameter("@Height", SqlDbType.VarChar, 50)
				{
					Value = model.Height
				},
				(!model.ButtonLocation.HasValue) ? new SqlParameter("@ButtonLocation", SqlDbType.Int, -1)
				{
					Value = DBNull.Value
				} : new SqlParameter("@ButtonLocation", SqlDbType.Int, -1)
				{
					Value = model.ButtonLocation
				},
				(!model.IsPager.HasValue) ? new SqlParameter("@IsPager", SqlDbType.Int, -1)
				{
					Value = DBNull.Value
				} : new SqlParameter("@IsPager", SqlDbType.Int, -1)
				{
					Value = model.IsPager
				},
				(model.ClientScript == null) ? new SqlParameter("@ClientScript", SqlDbType.VarChar, -1)
				{
					Value = DBNull.Value
				} : new SqlParameter("@ClientScript", SqlDbType.VarChar, -1)
				{
					Value = model.ClientScript
				},
				(model.ExportTemplate == null) ? new SqlParameter("@ExportTemplate", SqlDbType.VarChar, 4000)
				{
					Value = DBNull.Value
				} : new SqlParameter("@ExportTemplate", SqlDbType.VarChar, 4000)
				{
					Value = model.ExportTemplate
				},
				(model.ExportHeaderText == null) ? new SqlParameter("@ExportHeaderText", SqlDbType.NVarChar, 1000)
				{
					Value = DBNull.Value
				} : new SqlParameter("@ExportHeaderText", SqlDbType.NVarChar, 1000)
				{
					Value = model.ExportHeaderText
				},
				(model.ExportFileName == null) ? new SqlParameter("@ExportFileName", SqlDbType.VarChar, 500)
				{
					Value = DBNull.Value
				} : new SqlParameter("@ExportFileName", SqlDbType.VarChar, 500)
				{
					Value = model.ExportFileName
				},
				(model.TableStyle == null) ? new SqlParameter("@TableStyle", SqlDbType.VarChar, 255)
				{
					Value = DBNull.Value
				} : new SqlParameter("@TableStyle", SqlDbType.VarChar, 255)
				{
					Value = model.TableStyle
				},
				(model.TableHead == null) ? new SqlParameter("@TableHead", SqlDbType.VarChar, 255)
				{
					Value = DBNull.Value
				} : new SqlParameter("@TableHead", SqlDbType.VarChar, 255)
				{
					Value = model.TableHead
				},
				(model.TableName == null) ? new SqlParameter("@TableName", SqlDbType.VarChar, 500)
				{
					Value = DBNull.Value
				} : new SqlParameter("@TableName", SqlDbType.VarChar, 500)
				{
					Value = model.TableName
				},
				(model.InDataNumberFiledName == null) ? new SqlParameter("@InDataNumberFiledName", SqlDbType.VarChar, 500)
				{
					Value = DBNull.Value
				} : new SqlParameter("@InDataNumberFiledName", SqlDbType.VarChar, 500)
				{
					Value = model.InDataNumberFiledName
				}
			};
			return dbHelper.Execute(sql, parameter);
		}

		public int Update(RoadFlow.Data.Model.ProgramBuilder model)
		{
			string sql = "UPDATE ProgramBuilder SET \r\n\t\t\t\tName=@Name,Type=@Type,CreateTime=@CreateTime,PublishTime=@PublishTime,CreateUser=@CreateUser,SQL=@SQL,IsAdd=@IsAdd,DBConnID=@DBConnID,Status=@Status,FormID=@FormID,EditModel=@EditModel,Width=@Width,Height=@Height,ButtonLocation=@ButtonLocation,IsPager=@IsPager,ClientScript=@ClientScript,ExportTemplate=@ExportTemplate,ExportHeaderText=@ExportHeaderText,ExportFileName=@ExportFileName,TableStyle=@TableStyle,TableHead=@TableHead,TableName=@TableName,InDataNumberFiledName=@InDataNumberFiledName    \r\n\t\t\t\tWHERE ID=@ID";
			SqlParameter[] parameter = new SqlParameter[24]
			{
				new SqlParameter("@Name", SqlDbType.NVarChar, 1000)
				{
					Value = model.Name
				},
				new SqlParameter("@Type", SqlDbType.UniqueIdentifier, -1)
				{
					Value = model.Type
				},
				new SqlParameter("@CreateTime", SqlDbType.DateTime, 8)
				{
					Value = model.CreateTime
				},
				(!model.PublishTime.HasValue) ? new SqlParameter("@PublishTime", SqlDbType.DateTime, 8)
				{
					Value = DBNull.Value
				} : new SqlParameter("@PublishTime", SqlDbType.DateTime, 8)
				{
					Value = model.PublishTime
				},
				new SqlParameter("@CreateUser", SqlDbType.UniqueIdentifier, -1)
				{
					Value = model.CreateUser
				},
				new SqlParameter("@SQL", SqlDbType.VarChar, -1)
				{
					Value = model.SQL
				},
				new SqlParameter("@IsAdd", SqlDbType.Int, -1)
				{
					Value = model.IsAdd
				},
				new SqlParameter("@DBConnID", SqlDbType.UniqueIdentifier, -1)
				{
					Value = model.DBConnID
				},
				new SqlParameter("@Status", SqlDbType.Int, -1)
				{
					Value = model.Status
				},
				(model.FormID == null) ? new SqlParameter("@FormID", SqlDbType.VarChar, 500)
				{
					Value = DBNull.Value
				} : new SqlParameter("@FormID", SqlDbType.VarChar, 500)
				{
					Value = model.FormID
				},
				(!model.EditModel.HasValue) ? new SqlParameter("@EditModel", SqlDbType.Int, -1)
				{
					Value = DBNull.Value
				} : new SqlParameter("@EditModel", SqlDbType.Int, -1)
				{
					Value = model.EditModel
				},
				(model.Width == null) ? new SqlParameter("@Width", SqlDbType.VarChar, 50)
				{
					Value = DBNull.Value
				} : new SqlParameter("@Width", SqlDbType.VarChar, 50)
				{
					Value = model.Width
				},
				(model.Height == null) ? new SqlParameter("@Height", SqlDbType.VarChar, 50)
				{
					Value = DBNull.Value
				} : new SqlParameter("@Height", SqlDbType.VarChar, 50)
				{
					Value = model.Height
				},
				(!model.ButtonLocation.HasValue) ? new SqlParameter("@ButtonLocation", SqlDbType.Int, -1)
				{
					Value = DBNull.Value
				} : new SqlParameter("@ButtonLocation", SqlDbType.Int, -1)
				{
					Value = model.ButtonLocation
				},
				(!model.IsPager.HasValue) ? new SqlParameter("@IsPager", SqlDbType.Int, -1)
				{
					Value = DBNull.Value
				} : new SqlParameter("@IsPager", SqlDbType.Int, -1)
				{
					Value = model.IsPager
				},
				(model.ClientScript == null) ? new SqlParameter("@ClientScript", SqlDbType.VarChar, -1)
				{
					Value = DBNull.Value
				} : new SqlParameter("@ClientScript", SqlDbType.VarChar, -1)
				{
					Value = model.ClientScript
				},
				(model.ExportTemplate == null) ? new SqlParameter("@ExportTemplate", SqlDbType.VarChar, 4000)
				{
					Value = DBNull.Value
				} : new SqlParameter("@ExportTemplate", SqlDbType.VarChar, 4000)
				{
					Value = model.ExportTemplate
				},
				(model.ExportHeaderText == null) ? new SqlParameter("@ExportHeaderText", SqlDbType.NVarChar, 1000)
				{
					Value = DBNull.Value
				} : new SqlParameter("@ExportHeaderText", SqlDbType.NVarChar, 1000)
				{
					Value = model.ExportHeaderText
				},
				(model.ExportFileName == null) ? new SqlParameter("@ExportFileName", SqlDbType.VarChar, 500)
				{
					Value = DBNull.Value
				} : new SqlParameter("@ExportFileName", SqlDbType.VarChar, 500)
				{
					Value = model.ExportFileName
				},
				(model.TableStyle == null) ? new SqlParameter("@TableStyle", SqlDbType.VarChar, 255)
				{
					Value = DBNull.Value
				} : new SqlParameter("@TableStyle", SqlDbType.VarChar, 255)
				{
					Value = model.TableStyle
				},
				(model.TableHead == null) ? new SqlParameter("@TableHead", SqlDbType.VarChar, -1)
				{
					Value = DBNull.Value
				} : new SqlParameter("@TableHead", SqlDbType.VarChar, -1)
				{
					Value = model.TableHead
				},
				(model.TableName == null) ? new SqlParameter("@TableName", SqlDbType.VarChar, 500)
				{
					Value = DBNull.Value
				} : new SqlParameter("@TableName", SqlDbType.VarChar, 500)
				{
					Value = model.TableName
				},
				(model.InDataNumberFiledName == null) ? new SqlParameter("@InDataNumberFiledName", SqlDbType.VarChar, 500)
				{
					Value = DBNull.Value
				} : new SqlParameter("@InDataNumberFiledName", SqlDbType.VarChar, 500)
				{
					Value = model.InDataNumberFiledName
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
			string sql = "DELETE FROM ProgramBuilder WHERE ID=@ID";
			SqlParameter[] parameter = new SqlParameter[1]
			{
				new SqlParameter("@ID", SqlDbType.UniqueIdentifier)
				{
					Value = id
				}
			};
			return dbHelper.Execute(sql, parameter);
		}

		private List<RoadFlow.Data.Model.ProgramBuilder> DataReaderToList(SqlDataReader dataReader)
		{
			List<RoadFlow.Data.Model.ProgramBuilder> list = new List<RoadFlow.Data.Model.ProgramBuilder>();
			RoadFlow.Data.Model.ProgramBuilder programBuilder = null;
			while (dataReader.Read())
			{
				programBuilder = new RoadFlow.Data.Model.ProgramBuilder();
				programBuilder.ID = dataReader.GetGuid(0);
				programBuilder.Name = dataReader.GetString(1);
				programBuilder.Type = dataReader.GetGuid(2);
				programBuilder.CreateTime = dataReader.GetDateTime(3);
				if (!dataReader.IsDBNull(4))
				{
					programBuilder.PublishTime = dataReader.GetDateTime(4);
				}
				programBuilder.CreateUser = dataReader.GetGuid(5);
				programBuilder.SQL = dataReader.GetString(6);
				programBuilder.IsAdd = dataReader.GetInt32(7);
				programBuilder.DBConnID = dataReader.GetGuid(8);
				programBuilder.Status = dataReader.GetInt32(9);
				if (!dataReader.IsDBNull(10))
				{
					programBuilder.FormID = dataReader.GetString(10);
				}
				if (!dataReader.IsDBNull(11))
				{
					programBuilder.EditModel = dataReader.GetInt32(11);
				}
				if (!dataReader.IsDBNull(12))
				{
					programBuilder.Width = dataReader.GetString(12);
				}
				if (!dataReader.IsDBNull(13))
				{
					programBuilder.Height = dataReader.GetString(13);
				}
				if (!dataReader.IsDBNull(14))
				{
					programBuilder.ButtonLocation = dataReader.GetInt32(14);
				}
				if (!dataReader.IsDBNull(15))
				{
					programBuilder.IsPager = dataReader.GetInt32(15);
				}
				if (!dataReader.IsDBNull(16))
				{
					programBuilder.ClientScript = dataReader.GetString(16);
				}
				if (!dataReader.IsDBNull(17))
				{
					programBuilder.ExportTemplate = dataReader.GetString(17);
				}
				if (!dataReader.IsDBNull(18))
				{
					programBuilder.ExportHeaderText = dataReader.GetString(18);
				}
				if (!dataReader.IsDBNull(19))
				{
					programBuilder.ExportFileName = dataReader.GetString(19);
				}
				if (!dataReader.IsDBNull(20))
				{
					programBuilder.TableStyle = dataReader.GetString(20);
				}
				if (!dataReader.IsDBNull(21))
				{
					programBuilder.TableHead = dataReader.GetString(21);
				}
				if (!dataReader.IsDBNull(22))
				{
					programBuilder.TableName = dataReader.GetString(22);
				}
				if (!dataReader.IsDBNull(23))
				{
					programBuilder.InDataNumberFiledName = dataReader.GetString(23);
				}
				list.Add(programBuilder);
			}
			return list;
		}

		public List<RoadFlow.Data.Model.ProgramBuilder> GetAll()
		{
			string sql = "SELECT * FROM ProgramBuilder";
			SqlDataReader dataReader = dbHelper.GetDataReader(sql);
			List<RoadFlow.Data.Model.ProgramBuilder> result = DataReaderToList(dataReader);
			dataReader.Close();
			return result;
		}

		public long GetCount()
		{
			string sql = "SELECT COUNT(*) FROM ProgramBuilder";
			long result;
			if (!long.TryParse(dbHelper.GetFieldValue(sql), out result))
			{
				return 0L;
			}
			return result;
		}

		public RoadFlow.Data.Model.ProgramBuilder Get(Guid id)
		{
			string sql = "SELECT * FROM ProgramBuilder WHERE ID=@ID";
			SqlParameter[] parameter = new SqlParameter[1]
			{
				new SqlParameter("@ID", SqlDbType.UniqueIdentifier)
				{
					Value = id
				}
			};
			SqlDataReader dataReader = dbHelper.GetDataReader(sql, parameter);
			List<RoadFlow.Data.Model.ProgramBuilder> list = DataReaderToList(dataReader);
			dataReader.Close();
			if (list.Count <= 0)
			{
				return null;
			}
			return list[0];
		}

		public List<RoadFlow.Data.Model.ProgramBuilder> GetList(out string pager, string query = "", string name = "", string typeid = "")
		{
			List<SqlParameter> list = new List<SqlParameter>();
			StringBuilder stringBuilder = new StringBuilder("SELECT *,ROW_NUMBER() OVER(ORDER BY CreateTime DESC) AS PagerAutoRowNumber FROM ProgramBuilder WHERE Status<>2 ");
			if (!name.IsNullOrEmpty())
			{
				stringBuilder.Append(" AND CHARINDEX(@Name,Name)>0");
				list.Add(new SqlParameter("@Name", name));
			}
			if (!typeid.IsNullOrEmpty())
			{
				stringBuilder.Append(" AND Type IN(" + Tools.GetSqlInString(typeid) + ")");
			}
			int pageSize = Tools.GetPageSize();
			int pageNumber = Tools.GetPageNumber();
			long count;
			string paerSql = dbHelper.GetPaerSql(stringBuilder.ToString(), pageSize, pageNumber, out count, list.ToArray());
			pager = Tools.GetPagerHtml(count, pageSize, pageNumber, query);
			SqlDataReader dataReader = dbHelper.GetDataReader(paerSql, list.ToArray());
			List<RoadFlow.Data.Model.ProgramBuilder> result = DataReaderToList(dataReader);
			dataReader.Close();
			return result;
		}
	}
}
