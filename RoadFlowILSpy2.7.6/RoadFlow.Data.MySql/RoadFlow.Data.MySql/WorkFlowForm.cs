using MySql.Data.MySqlClient;
using RoadFlow.Data.Interface;
using RoadFlow.Data.Model;
using RoadFlow.Utility;
using System;
using System.Collections.Generic;
using System.Data.Common;
using System.Text;

namespace RoadFlow.Data.MySql
{
	public class WorkFlowForm : IWorkFlowForm
	{
		private DBHelper dbHelper = new DBHelper();

		public int Add(RoadFlow.Data.Model.WorkFlowForm model)
		{
			//IL_001b: Unknown result type (might be due to invalid IL or missing references)
			//IL_0020: Unknown result type (might be due to invalid IL or missing references)
			//IL_0031: Expected O, but got Unknown
			//IL_0032: Expected O, but got Unknown
			//IL_003f: Unknown result type (might be due to invalid IL or missing references)
			//IL_0044: Unknown result type (might be due to invalid IL or missing references)
			//IL_0050: Expected O, but got Unknown
			//IL_0051: Expected O, but got Unknown
			//IL_005f: Unknown result type (might be due to invalid IL or missing references)
			//IL_0064: Unknown result type (might be due to invalid IL or missing references)
			//IL_0075: Expected O, but got Unknown
			//IL_0076: Expected O, but got Unknown
			//IL_0084: Unknown result type (might be due to invalid IL or missing references)
			//IL_0089: Unknown result type (might be due to invalid IL or missing references)
			//IL_009a: Expected O, but got Unknown
			//IL_009b: Expected O, but got Unknown
			//IL_00a9: Unknown result type (might be due to invalid IL or missing references)
			//IL_00ae: Unknown result type (might be due to invalid IL or missing references)
			//IL_00ba: Expected O, but got Unknown
			//IL_00bb: Expected O, but got Unknown
			//IL_00c5: Unknown result type (might be due to invalid IL or missing references)
			//IL_00ca: Unknown result type (might be due to invalid IL or missing references)
			//IL_00db: Expected O, but got Unknown
			//IL_00dc: Expected O, but got Unknown
			//IL_00e6: Unknown result type (might be due to invalid IL or missing references)
			//IL_00eb: Unknown result type (might be due to invalid IL or missing references)
			//IL_00fc: Expected O, but got Unknown
			//IL_00fd: Expected O, but got Unknown
			//IL_0112: Unknown result type (might be due to invalid IL or missing references)
			//IL_0117: Unknown result type (might be due to invalid IL or missing references)
			//IL_0123: Expected O, but got Unknown
			//IL_0130: Unknown result type (might be due to invalid IL or missing references)
			//IL_0135: Unknown result type (might be due to invalid IL or missing references)
			//IL_0140: Expected O, but got Unknown
			//IL_0141: Expected O, but got Unknown
			//IL_0156: Unknown result type (might be due to invalid IL or missing references)
			//IL_015b: Unknown result type (might be due to invalid IL or missing references)
			//IL_0167: Expected O, but got Unknown
			//IL_0174: Unknown result type (might be due to invalid IL or missing references)
			//IL_0179: Unknown result type (might be due to invalid IL or missing references)
			//IL_0184: Expected O, but got Unknown
			//IL_0185: Expected O, but got Unknown
			//IL_019b: Unknown result type (might be due to invalid IL or missing references)
			//IL_01a0: Unknown result type (might be due to invalid IL or missing references)
			//IL_01ac: Expected O, but got Unknown
			//IL_01b9: Unknown result type (might be due to invalid IL or missing references)
			//IL_01be: Unknown result type (might be due to invalid IL or missing references)
			//IL_01c9: Expected O, but got Unknown
			//IL_01ca: Expected O, but got Unknown
			//IL_01e0: Unknown result type (might be due to invalid IL or missing references)
			//IL_01e5: Unknown result type (might be due to invalid IL or missing references)
			//IL_01f1: Expected O, but got Unknown
			//IL_01fe: Unknown result type (might be due to invalid IL or missing references)
			//IL_0203: Unknown result type (might be due to invalid IL or missing references)
			//IL_020e: Expected O, but got Unknown
			//IL_020f: Expected O, but got Unknown
			//IL_021a: Unknown result type (might be due to invalid IL or missing references)
			//IL_021f: Unknown result type (might be due to invalid IL or missing references)
			//IL_0230: Expected O, but got Unknown
			//IL_0231: Expected O, but got Unknown
			string sql = "INSERT INTO workflowform\r\n\t\t\t\t(ID,Name,Type,CreateUserID,CreateUserName,CreateTime,LastModifyTime,Html,SubTableJson,EventsJson,Attribute,Status) \r\n\t\t\t\tVALUES(@ID,@Name,@Type,@CreateUserID,@CreateUserName,@CreateTime,@LastModifyTime,@Html,@SubTableJson,@EventsJson,@Attribute,@Status)";
			MySqlParameter[] obj = new MySqlParameter[12];
			MySqlParameter val = new MySqlParameter("@ID", 253, 36);
			((DbParameter)val).Value = model.ID;
			obj[0] = val;
			MySqlParameter val2 = new MySqlParameter("@Name", 752, -1);
			((DbParameter)val2).Value = model.Name;
			obj[1] = val2;
			MySqlParameter val3 = new MySqlParameter("@Type", 253, 36);
			((DbParameter)val3).Value = model.Type;
			obj[2] = val3;
			MySqlParameter val4 = new MySqlParameter("@CreateUserID", 253, 36);
			((DbParameter)val4).Value = model.CreateUserID;
			obj[3] = val4;
			MySqlParameter val5 = new MySqlParameter("@CreateUserName", 253, 50);
			((DbParameter)val5).Value = model.CreateUserName;
			obj[4] = val5;
			MySqlParameter val6 = new MySqlParameter("@CreateTime", 12, -1);
			((DbParameter)val6).Value = model.CreateTime;
			obj[5] = val6;
			MySqlParameter val7 = new MySqlParameter("@LastModifyTime", 12, -1);
			((DbParameter)val7).Value = model.LastModifyTime;
			obj[6] = val7;
			_003F val8;
			if (model.Html != null)
			{
				val8 = new MySqlParameter("@Html", 751, -1);
				((DbParameter)val8).Value = model.Html;
			}
			else
			{
				val8 = new MySqlParameter("@Html", 751, -1);
				((DbParameter)val8).Value = DBNull.Value;
			}
			obj[7] = val8;
			_003F val9;
			if (model.SubTableJson != null)
			{
				val9 = new MySqlParameter("@SubTableJson", 751, -1);
				((DbParameter)val9).Value = model.SubTableJson;
			}
			else
			{
				val9 = new MySqlParameter("@SubTableJson", 751, -1);
				((DbParameter)val9).Value = DBNull.Value;
			}
			obj[8] = val9;
			_003F val10;
			if (model.EventsJson != null)
			{
				val10 = new MySqlParameter("@EventsJson", 751, -1);
				((DbParameter)val10).Value = model.EventsJson;
			}
			else
			{
				val10 = new MySqlParameter("@EventsJson", 751, -1);
				((DbParameter)val10).Value = DBNull.Value;
			}
			obj[9] = val10;
			_003F val11;
			if (model.Attribute != null)
			{
				val11 = new MySqlParameter("@Attribute", 751, -1);
				((DbParameter)val11).Value = model.Attribute;
			}
			else
			{
				val11 = new MySqlParameter("@Attribute", 751, -1);
				((DbParameter)val11).Value = DBNull.Value;
			}
			obj[10] = val11;
			MySqlParameter val12 = new MySqlParameter("@Status", 3, 11);
			((DbParameter)val12).Value = model.Status;
			obj[11] = val12;
			MySqlParameter[] parameter = (MySqlParameter[])obj;
			return dbHelper.Execute(sql, parameter);
		}

		public int Update(RoadFlow.Data.Model.WorkFlowForm model)
		{
			//IL_001a: Unknown result type (might be due to invalid IL or missing references)
			//IL_001f: Unknown result type (might be due to invalid IL or missing references)
			//IL_002b: Expected O, but got Unknown
			//IL_002c: Expected O, but got Unknown
			//IL_003a: Unknown result type (might be due to invalid IL or missing references)
			//IL_003f: Unknown result type (might be due to invalid IL or missing references)
			//IL_0050: Expected O, but got Unknown
			//IL_0051: Expected O, but got Unknown
			//IL_005f: Unknown result type (might be due to invalid IL or missing references)
			//IL_0064: Unknown result type (might be due to invalid IL or missing references)
			//IL_0075: Expected O, but got Unknown
			//IL_0076: Expected O, but got Unknown
			//IL_0084: Unknown result type (might be due to invalid IL or missing references)
			//IL_0089: Unknown result type (might be due to invalid IL or missing references)
			//IL_0095: Expected O, but got Unknown
			//IL_0096: Expected O, but got Unknown
			//IL_00a0: Unknown result type (might be due to invalid IL or missing references)
			//IL_00a5: Unknown result type (might be due to invalid IL or missing references)
			//IL_00b6: Expected O, but got Unknown
			//IL_00b7: Expected O, but got Unknown
			//IL_00c1: Unknown result type (might be due to invalid IL or missing references)
			//IL_00c6: Unknown result type (might be due to invalid IL or missing references)
			//IL_00d7: Expected O, but got Unknown
			//IL_00d8: Expected O, but got Unknown
			//IL_00ed: Unknown result type (might be due to invalid IL or missing references)
			//IL_00f2: Unknown result type (might be due to invalid IL or missing references)
			//IL_00fe: Expected O, but got Unknown
			//IL_010b: Unknown result type (might be due to invalid IL or missing references)
			//IL_0110: Unknown result type (might be due to invalid IL or missing references)
			//IL_011b: Expected O, but got Unknown
			//IL_011c: Expected O, but got Unknown
			//IL_0131: Unknown result type (might be due to invalid IL or missing references)
			//IL_0136: Unknown result type (might be due to invalid IL or missing references)
			//IL_0142: Expected O, but got Unknown
			//IL_014f: Unknown result type (might be due to invalid IL or missing references)
			//IL_0154: Unknown result type (might be due to invalid IL or missing references)
			//IL_015f: Expected O, but got Unknown
			//IL_0160: Expected O, but got Unknown
			//IL_0175: Unknown result type (might be due to invalid IL or missing references)
			//IL_017a: Unknown result type (might be due to invalid IL or missing references)
			//IL_0186: Expected O, but got Unknown
			//IL_0193: Unknown result type (might be due to invalid IL or missing references)
			//IL_0198: Unknown result type (might be due to invalid IL or missing references)
			//IL_01a3: Expected O, but got Unknown
			//IL_01a4: Expected O, but got Unknown
			//IL_01ba: Unknown result type (might be due to invalid IL or missing references)
			//IL_01bf: Unknown result type (might be due to invalid IL or missing references)
			//IL_01cb: Expected O, but got Unknown
			//IL_01d8: Unknown result type (might be due to invalid IL or missing references)
			//IL_01dd: Unknown result type (might be due to invalid IL or missing references)
			//IL_01e8: Expected O, but got Unknown
			//IL_01e9: Expected O, but got Unknown
			//IL_01f4: Unknown result type (might be due to invalid IL or missing references)
			//IL_01f9: Unknown result type (might be due to invalid IL or missing references)
			//IL_020a: Expected O, but got Unknown
			//IL_020b: Expected O, but got Unknown
			//IL_021a: Unknown result type (might be due to invalid IL or missing references)
			//IL_021f: Unknown result type (might be due to invalid IL or missing references)
			//IL_0230: Expected O, but got Unknown
			//IL_0231: Expected O, but got Unknown
			string sql = "UPDATE workflowform SET \r\n\t\t\t\tName=@Name,Type=@Type,CreateUserID=@CreateUserID,CreateUserName=@CreateUserName,CreateTime=@CreateTime,LastModifyTime=@LastModifyTime,Html=@Html,SubTableJson=@SubTableJson,EventsJson=@EventsJson,Attribute=@Attribute,Status=@Status\r\n\t\t\t\tWHERE ID=@ID";
			MySqlParameter[] obj = new MySqlParameter[12];
			MySqlParameter val = new MySqlParameter("@Name", 752, -1);
			((DbParameter)val).Value = model.Name;
			obj[0] = val;
			MySqlParameter val2 = new MySqlParameter("@Type", 253, 36);
			((DbParameter)val2).Value = model.Type;
			obj[1] = val2;
			MySqlParameter val3 = new MySqlParameter("@CreateUserID", 253, 36);
			((DbParameter)val3).Value = model.CreateUserID;
			obj[2] = val3;
			MySqlParameter val4 = new MySqlParameter("@CreateUserName", 253, 50);
			((DbParameter)val4).Value = model.CreateUserName;
			obj[3] = val4;
			MySqlParameter val5 = new MySqlParameter("@CreateTime", 12, -1);
			((DbParameter)val5).Value = model.CreateTime;
			obj[4] = val5;
			MySqlParameter val6 = new MySqlParameter("@LastModifyTime", 12, -1);
			((DbParameter)val6).Value = model.LastModifyTime;
			obj[5] = val6;
			_003F val7;
			if (model.Html != null)
			{
				val7 = new MySqlParameter("@Html", 751, -1);
				((DbParameter)val7).Value = model.Html;
			}
			else
			{
				val7 = new MySqlParameter("@Html", 751, -1);
				((DbParameter)val7).Value = DBNull.Value;
			}
			obj[6] = val7;
			_003F val8;
			if (model.SubTableJson != null)
			{
				val8 = new MySqlParameter("@SubTableJson", 751, -1);
				((DbParameter)val8).Value = model.SubTableJson;
			}
			else
			{
				val8 = new MySqlParameter("@SubTableJson", 751, -1);
				((DbParameter)val8).Value = DBNull.Value;
			}
			obj[7] = val8;
			_003F val9;
			if (model.EventsJson != null)
			{
				val9 = new MySqlParameter("@EventsJson", 751, -1);
				((DbParameter)val9).Value = model.EventsJson;
			}
			else
			{
				val9 = new MySqlParameter("@EventsJson", 751, -1);
				((DbParameter)val9).Value = DBNull.Value;
			}
			obj[8] = val9;
			_003F val10;
			if (model.Attribute != null)
			{
				val10 = new MySqlParameter("@Attribute", 751, -1);
				((DbParameter)val10).Value = model.Attribute;
			}
			else
			{
				val10 = new MySqlParameter("@Attribute", 751, -1);
				((DbParameter)val10).Value = DBNull.Value;
			}
			obj[9] = val10;
			MySqlParameter val11 = new MySqlParameter("@Status", 3, 11);
			((DbParameter)val11).Value = model.Status;
			obj[10] = val11;
			MySqlParameter val12 = new MySqlParameter("@ID", 253, 36);
			((DbParameter)val12).Value = model.ID;
			obj[11] = val12;
			MySqlParameter[] parameter = (MySqlParameter[])obj;
			return dbHelper.Execute(sql, parameter);
		}

		public int Delete(Guid id)
		{
			//IL_001a: Unknown result type (might be due to invalid IL or missing references)
			//IL_001f: Unknown result type (might be due to invalid IL or missing references)
			//IL_0032: Expected O, but got Unknown
			//IL_0033: Expected O, but got Unknown
			string sql = "DELETE FROM workflowform WHERE ID=@ID";
			MySqlParameter[] obj = new MySqlParameter[1];
			MySqlParameter val = new MySqlParameter("@ID", 253, 36);
			((DbParameter)val).Value = id.ToString();
			obj[0] = val;
			MySqlParameter[] parameter = (MySqlParameter[])obj;
			return dbHelper.Execute(sql, parameter);
		}

		private List<RoadFlow.Data.Model.WorkFlowForm> DataReaderToList(MySqlDataReader dataReader)
		{
			List<RoadFlow.Data.Model.WorkFlowForm> list = new List<RoadFlow.Data.Model.WorkFlowForm>();
			RoadFlow.Data.Model.WorkFlowForm workFlowForm = null;
			while (((DbDataReader)dataReader).Read())
			{
				workFlowForm = new RoadFlow.Data.Model.WorkFlowForm();
				workFlowForm.ID = ((DbDataReader)dataReader).GetString(0).ToGuid();
				workFlowForm.Name = ((DbDataReader)dataReader).GetString(1);
				workFlowForm.Type = ((DbDataReader)dataReader).GetString(2).ToGuid();
				workFlowForm.CreateUserID = ((DbDataReader)dataReader).GetString(3).ToGuid();
				workFlowForm.CreateUserName = ((DbDataReader)dataReader).GetString(4);
				workFlowForm.CreateTime = ((DbDataReader)dataReader).GetDateTime(5);
				workFlowForm.LastModifyTime = ((DbDataReader)dataReader).GetDateTime(6);
				if (!((DbDataReader)dataReader).IsDBNull(7))
				{
					workFlowForm.Html = ((DbDataReader)dataReader).GetString(7);
				}
				if (!((DbDataReader)dataReader).IsDBNull(8))
				{
					workFlowForm.SubTableJson = ((DbDataReader)dataReader).GetString(8);
				}
				if (!((DbDataReader)dataReader).IsDBNull(9))
				{
					workFlowForm.EventsJson = ((DbDataReader)dataReader).GetString(9);
				}
				if (!((DbDataReader)dataReader).IsDBNull(10))
				{
					workFlowForm.Attribute = ((DbDataReader)dataReader).GetString(10);
				}
				workFlowForm.Status = ((DbDataReader)dataReader).GetInt32(11);
				list.Add(workFlowForm);
			}
			return list;
		}

		public List<RoadFlow.Data.Model.WorkFlowForm> GetAll()
		{
			string sql = "SELECT * FROM workflowform";
			MySqlDataReader dataReader = dbHelper.GetDataReader(sql);
			List<RoadFlow.Data.Model.WorkFlowForm> result = DataReaderToList(dataReader);
			((DbDataReader)dataReader).Close();
			return result;
		}

		public long GetCount()
		{
			string sql = "SELECT COUNT(*) FROM workflowform";
			long result;
			if (!long.TryParse(dbHelper.GetFieldValue(sql), out result))
			{
				return 0L;
			}
			return result;
		}

		public RoadFlow.Data.Model.WorkFlowForm Get(Guid id)
		{
			//IL_001a: Unknown result type (might be due to invalid IL or missing references)
			//IL_001f: Unknown result type (might be due to invalid IL or missing references)
			//IL_0032: Expected O, but got Unknown
			//IL_0033: Expected O, but got Unknown
			string sql = "SELECT * FROM workflowform WHERE ID=@ID";
			MySqlParameter[] obj = new MySqlParameter[1];
			MySqlParameter val = new MySqlParameter("@ID", 253, 36);
			((DbParameter)val).Value = id.ToString();
			obj[0] = val;
			MySqlParameter[] parameter = (MySqlParameter[])obj;
			MySqlDataReader dataReader = dbHelper.GetDataReader(sql, parameter);
			List<RoadFlow.Data.Model.WorkFlowForm> list = DataReaderToList(dataReader);
			((DbDataReader)dataReader).Close();
			if (list.Count <= 0)
			{
				return null;
			}
			return list[0];
		}

		public List<RoadFlow.Data.Model.WorkFlowForm> GetAllByType(string types)
		{
			string sql = "SELECT ID, Name, Type, CreateUserID, CreateUserName, CreateTime, LastModifyTime, '' as Html, '' as SubTableJson, '' as EventsJson, '' as Attribute, Status FROM WorkFlowForm where Type IN(" + Tools.GetSqlInString(types) + ")";
			MySqlDataReader dataReader = dbHelper.GetDataReader(sql);
			List<RoadFlow.Data.Model.WorkFlowForm> result = DataReaderToList(dataReader);
			((DbDataReader)dataReader).Close();
			return result;
		}

		public List<RoadFlow.Data.Model.WorkFlowForm> GetPagerData(out string pager, string query = "", string userid = "", string typeid = "", string name = "", int pagesize = 15)
		{
			//IL_0030: Unknown result type (might be due to invalid IL or missing references)
			//IL_0035: Unknown result type (might be due to invalid IL or missing references)
			//IL_003c: Expected O, but got Unknown
			//IL_0041: Expected O, but got Unknown
			//IL_0061: Unknown result type (might be due to invalid IL or missing references)
			//IL_0066: Unknown result type (might be due to invalid IL or missing references)
			//IL_006e: Expected O, but got Unknown
			//IL_0073: Expected O, but got Unknown
			StringBuilder stringBuilder = new StringBuilder("AND Status IN(0,1) ");
			List<MySqlParameter> list = new List<MySqlParameter>();
			if (!userid.IsNullOrEmpty())
			{
				stringBuilder.Append("AND CreateUserID=@CreateUserID ");
				List<MySqlParameter> list2 = list;
				MySqlParameter val = new MySqlParameter("@CreateUserID", 253);
				((DbParameter)val).Value = userid;
				list2.Add(val);
			}
			if (!name.IsNullOrEmpty())
			{
				stringBuilder.Append("AND INSTR(Name,@Name)>0 ");
				List<MySqlParameter> list3 = list;
				MySqlParameter val2 = new MySqlParameter("@Name", 253);
				((DbParameter)val2).Value = name;
				list3.Add(val2);
			}
			if (!typeid.IsNullOrEmpty())
			{
				stringBuilder.Append("AND Type IN (" + Tools.GetSqlInString(typeid) + ")");
			}
			int pageNumber = Tools.GetPageNumber();
			long count;
			string paerSql = dbHelper.GetPaerSql("WorkFlowForm", "ID,Name,Type,CreateUserID,CreateUserName,CreateTime,LastModifyTime,'' Html,'' SubTableJson,'' EventsJson,'' Attribute,Status", stringBuilder.ToString(), "CreateTime DESC", pagesize, pageNumber, out count, list.ToArray());
			pager = Tools.GetPagerHtml(count, pagesize, pageNumber, query);
			MySqlDataReader dataReader = dbHelper.GetDataReader(paerSql, list.ToArray());
			List<RoadFlow.Data.Model.WorkFlowForm> result = DataReaderToList(dataReader);
			((DbDataReader)dataReader).Close();
			return result;
		}

		public List<RoadFlow.Data.Model.WorkFlowForm> GetPagerData(out long count, int pageSize, int pageNumber, string userid = "", string typeid = "", string name = "", string order = "")
		{
			//IL_0031: Unknown result type (might be due to invalid IL or missing references)
			//IL_0036: Unknown result type (might be due to invalid IL or missing references)
			//IL_003e: Expected O, but got Unknown
			//IL_0043: Expected O, but got Unknown
			//IL_0063: Unknown result type (might be due to invalid IL or missing references)
			//IL_0068: Unknown result type (might be due to invalid IL or missing references)
			//IL_0070: Expected O, but got Unknown
			//IL_0075: Expected O, but got Unknown
			StringBuilder stringBuilder = new StringBuilder("AND Status IN(0,1) ");
			List<MySqlParameter> list = new List<MySqlParameter>();
			if (!userid.IsNullOrEmpty())
			{
				stringBuilder.Append("AND CreateUserID=@CreateUserID ");
				List<MySqlParameter> list2 = list;
				MySqlParameter val = new MySqlParameter("@CreateUserID", 253);
				((DbParameter)val).Value = userid;
				list2.Add(val);
			}
			if (!name.IsNullOrEmpty())
			{
				stringBuilder.Append("AND INSTR(Name,@Name)>0 ");
				List<MySqlParameter> list3 = list;
				MySqlParameter val2 = new MySqlParameter("@Name", 253);
				((DbParameter)val2).Value = name;
				list3.Add(val2);
			}
			if (!typeid.IsNullOrEmpty())
			{
				stringBuilder.Append("AND Type IN (" + Tools.GetSqlInString(typeid) + ")");
			}
			string paerSql = dbHelper.GetPaerSql("WorkFlowForm", "ID,Name,Type,CreateUserID,CreateUserName,CreateTime,LastModifyTime,'' Html,'' SubTableJson,'' EventsJson,'' Attribute,Status", stringBuilder.ToString(), order.IsNullOrEmpty() ? "CreateTime DESC" : order, pageSize, pageNumber, out count, list.ToArray());
			MySqlDataReader dataReader = dbHelper.GetDataReader(paerSql, list.ToArray());
			List<RoadFlow.Data.Model.WorkFlowForm> result = DataReaderToList(dataReader);
			((DbDataReader)dataReader).Close();
			return result;
		}
	}
}
