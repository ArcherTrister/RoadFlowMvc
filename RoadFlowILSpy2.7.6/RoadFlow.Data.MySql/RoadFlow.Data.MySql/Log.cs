using MySql.Data.MySqlClient;
using RoadFlow.Data.Interface;
using RoadFlow.Data.Model;
using RoadFlow.Utility;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Common;
using System.Text;

namespace RoadFlow.Data.MySql
{
	public class Log : ILog
	{
		private DBHelper dbHelper = new DBHelper();

		public int Add(RoadFlow.Data.Model.Log model)
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
			//IL_0070: Expected O, but got Unknown
			//IL_0071: Expected O, but got Unknown
			//IL_007b: Unknown result type (might be due to invalid IL or missing references)
			//IL_0080: Unknown result type (might be due to invalid IL or missing references)
			//IL_0091: Expected O, but got Unknown
			//IL_0092: Expected O, but got Unknown
			//IL_00b0: Unknown result type (might be due to invalid IL or missing references)
			//IL_00b5: Unknown result type (might be due to invalid IL or missing references)
			//IL_00c6: Expected O, but got Unknown
			//IL_00d4: Unknown result type (might be due to invalid IL or missing references)
			//IL_00d9: Unknown result type (might be due to invalid IL or missing references)
			//IL_00e4: Expected O, but got Unknown
			//IL_00e5: Expected O, but got Unknown
			//IL_00fb: Unknown result type (might be due to invalid IL or missing references)
			//IL_0100: Unknown result type (might be due to invalid IL or missing references)
			//IL_010c: Expected O, but got Unknown
			//IL_011a: Unknown result type (might be due to invalid IL or missing references)
			//IL_011f: Unknown result type (might be due to invalid IL or missing references)
			//IL_012a: Expected O, but got Unknown
			//IL_012b: Expected O, but got Unknown
			//IL_0141: Unknown result type (might be due to invalid IL or missing references)
			//IL_0146: Unknown result type (might be due to invalid IL or missing references)
			//IL_0152: Expected O, but got Unknown
			//IL_0160: Unknown result type (might be due to invalid IL or missing references)
			//IL_0165: Unknown result type (might be due to invalid IL or missing references)
			//IL_0170: Expected O, but got Unknown
			//IL_0171: Expected O, but got Unknown
			//IL_0186: Unknown result type (might be due to invalid IL or missing references)
			//IL_018b: Unknown result type (might be due to invalid IL or missing references)
			//IL_0197: Expected O, but got Unknown
			//IL_01a4: Unknown result type (might be due to invalid IL or missing references)
			//IL_01a9: Unknown result type (might be due to invalid IL or missing references)
			//IL_01b4: Expected O, but got Unknown
			//IL_01b5: Expected O, but got Unknown
			//IL_01ca: Unknown result type (might be due to invalid IL or missing references)
			//IL_01cf: Unknown result type (might be due to invalid IL or missing references)
			//IL_01db: Expected O, but got Unknown
			//IL_01e8: Unknown result type (might be due to invalid IL or missing references)
			//IL_01ed: Unknown result type (might be due to invalid IL or missing references)
			//IL_01f8: Expected O, but got Unknown
			//IL_01f9: Expected O, but got Unknown
			//IL_020f: Unknown result type (might be due to invalid IL or missing references)
			//IL_0214: Unknown result type (might be due to invalid IL or missing references)
			//IL_0220: Expected O, but got Unknown
			//IL_022d: Unknown result type (might be due to invalid IL or missing references)
			//IL_0232: Unknown result type (might be due to invalid IL or missing references)
			//IL_023d: Expected O, but got Unknown
			//IL_023e: Expected O, but got Unknown
			//IL_0254: Unknown result type (might be due to invalid IL or missing references)
			//IL_0259: Unknown result type (might be due to invalid IL or missing references)
			//IL_0265: Expected O, but got Unknown
			//IL_0272: Unknown result type (might be due to invalid IL or missing references)
			//IL_0277: Unknown result type (might be due to invalid IL or missing references)
			//IL_0282: Expected O, but got Unknown
			//IL_0283: Expected O, but got Unknown
			//IL_0299: Unknown result type (might be due to invalid IL or missing references)
			//IL_029e: Unknown result type (might be due to invalid IL or missing references)
			//IL_02aa: Expected O, but got Unknown
			//IL_02b7: Unknown result type (might be due to invalid IL or missing references)
			//IL_02bc: Unknown result type (might be due to invalid IL or missing references)
			//IL_02c7: Expected O, but got Unknown
			//IL_02c8: Expected O, but got Unknown
			string sql = "INSERT INTO log\r\n\t\t\t\t(ID,Title,Type,WriteTime,UserID,UserName,IPAddress,URL,Contents,Others,OldXml,NewXml) \r\n\t\t\t\tVALUES(@ID,@Title,@Type,@WriteTime,@UserID,@UserName,@IPAddress,@URL,@Contents,@Others,@OldXml,@NewXml)";
			MySqlParameter[] obj = new MySqlParameter[12];
			MySqlParameter val = new MySqlParameter("@ID", 253, 36);
			((DbParameter)val).Value = model.ID;
			obj[0] = val;
			MySqlParameter val2 = new MySqlParameter("@Title", 751, -1);
			((DbParameter)val2).Value = model.Title;
			obj[1] = val2;
			MySqlParameter val3 = new MySqlParameter("@Type", 253, 50);
			((DbParameter)val3).Value = model.Type;
			obj[2] = val3;
			MySqlParameter val4 = new MySqlParameter("@WriteTime", 12, -1);
			((DbParameter)val4).Value = model.WriteTime;
			obj[3] = val4;
			_003F val5;
			if (model.UserID.HasValue)
			{
				val5 = new MySqlParameter("@UserID", 253, 36);
				((DbParameter)val5).Value = model.UserID;
			}
			else
			{
				val5 = new MySqlParameter("@UserID", 253, 36);
				((DbParameter)val5).Value = DBNull.Value;
			}
			obj[4] = val5;
			_003F val6;
			if (model.UserName != null)
			{
				val6 = new MySqlParameter("@UserName", 253, 50);
				((DbParameter)val6).Value = model.UserName;
			}
			else
			{
				val6 = new MySqlParameter("@UserName", 253, 50);
				((DbParameter)val6).Value = DBNull.Value;
			}
			obj[5] = val6;
			_003F val7;
			if (model.IPAddress != null)
			{
				val7 = new MySqlParameter("@IPAddress", 253, 50);
				((DbParameter)val7).Value = model.IPAddress;
			}
			else
			{
				val7 = new MySqlParameter("@IPAddress", 253, 50);
				((DbParameter)val7).Value = DBNull.Value;
			}
			obj[6] = val7;
			_003F val8;
			if (model.URL != null)
			{
				val8 = new MySqlParameter("@URL", 751, -1);
				((DbParameter)val8).Value = model.URL;
			}
			else
			{
				val8 = new MySqlParameter("@URL", 751, -1);
				((DbParameter)val8).Value = DBNull.Value;
			}
			obj[7] = val8;
			_003F val9;
			if (model.Contents != null)
			{
				val9 = new MySqlParameter("@Contents", 751, -1);
				((DbParameter)val9).Value = model.Contents;
			}
			else
			{
				val9 = new MySqlParameter("@Contents", 751, -1);
				((DbParameter)val9).Value = DBNull.Value;
			}
			obj[8] = val9;
			_003F val10;
			if (model.Others != null)
			{
				val10 = new MySqlParameter("@Others", 751, -1);
				((DbParameter)val10).Value = model.Others;
			}
			else
			{
				val10 = new MySqlParameter("@Others", 751, -1);
				((DbParameter)val10).Value = DBNull.Value;
			}
			obj[9] = val10;
			_003F val11;
			if (model.OldXml != null)
			{
				val11 = new MySqlParameter("@OldXml", 751, -1);
				((DbParameter)val11).Value = model.OldXml;
			}
			else
			{
				val11 = new MySqlParameter("@OldXml", 751, -1);
				((DbParameter)val11).Value = DBNull.Value;
			}
			obj[10] = val11;
			_003F val12;
			if (model.NewXml != null)
			{
				val12 = new MySqlParameter("@NewXml", 751, -1);
				((DbParameter)val12).Value = model.NewXml;
			}
			else
			{
				val12 = new MySqlParameter("@NewXml", 751, -1);
				((DbParameter)val12).Value = DBNull.Value;
			}
			obj[11] = val12;
			MySqlParameter[] parameter = (MySqlParameter[])obj;
			return dbHelper.Execute(sql, parameter);
		}

		public int Update(RoadFlow.Data.Model.Log model)
		{
			//IL_001a: Unknown result type (might be due to invalid IL or missing references)
			//IL_001f: Unknown result type (might be due to invalid IL or missing references)
			//IL_002b: Expected O, but got Unknown
			//IL_002c: Expected O, but got Unknown
			//IL_003a: Unknown result type (might be due to invalid IL or missing references)
			//IL_003f: Unknown result type (might be due to invalid IL or missing references)
			//IL_004b: Expected O, but got Unknown
			//IL_004c: Expected O, but got Unknown
			//IL_0056: Unknown result type (might be due to invalid IL or missing references)
			//IL_005b: Unknown result type (might be due to invalid IL or missing references)
			//IL_006c: Expected O, but got Unknown
			//IL_006d: Expected O, but got Unknown
			//IL_008b: Unknown result type (might be due to invalid IL or missing references)
			//IL_0090: Unknown result type (might be due to invalid IL or missing references)
			//IL_00a1: Expected O, but got Unknown
			//IL_00af: Unknown result type (might be due to invalid IL or missing references)
			//IL_00b4: Unknown result type (might be due to invalid IL or missing references)
			//IL_00bf: Expected O, but got Unknown
			//IL_00c0: Expected O, but got Unknown
			//IL_00d6: Unknown result type (might be due to invalid IL or missing references)
			//IL_00db: Unknown result type (might be due to invalid IL or missing references)
			//IL_00e7: Expected O, but got Unknown
			//IL_00f5: Unknown result type (might be due to invalid IL or missing references)
			//IL_00fa: Unknown result type (might be due to invalid IL or missing references)
			//IL_0105: Expected O, but got Unknown
			//IL_0106: Expected O, but got Unknown
			//IL_011c: Unknown result type (might be due to invalid IL or missing references)
			//IL_0121: Unknown result type (might be due to invalid IL or missing references)
			//IL_012d: Expected O, but got Unknown
			//IL_013b: Unknown result type (might be due to invalid IL or missing references)
			//IL_0140: Unknown result type (might be due to invalid IL or missing references)
			//IL_014b: Expected O, but got Unknown
			//IL_014c: Expected O, but got Unknown
			//IL_0161: Unknown result type (might be due to invalid IL or missing references)
			//IL_0166: Unknown result type (might be due to invalid IL or missing references)
			//IL_0172: Expected O, but got Unknown
			//IL_017f: Unknown result type (might be due to invalid IL or missing references)
			//IL_0184: Unknown result type (might be due to invalid IL or missing references)
			//IL_018f: Expected O, but got Unknown
			//IL_0190: Expected O, but got Unknown
			//IL_01a5: Unknown result type (might be due to invalid IL or missing references)
			//IL_01aa: Unknown result type (might be due to invalid IL or missing references)
			//IL_01b6: Expected O, but got Unknown
			//IL_01c3: Unknown result type (might be due to invalid IL or missing references)
			//IL_01c8: Unknown result type (might be due to invalid IL or missing references)
			//IL_01d3: Expected O, but got Unknown
			//IL_01d4: Expected O, but got Unknown
			//IL_01e9: Unknown result type (might be due to invalid IL or missing references)
			//IL_01ee: Unknown result type (might be due to invalid IL or missing references)
			//IL_01fa: Expected O, but got Unknown
			//IL_0207: Unknown result type (might be due to invalid IL or missing references)
			//IL_020c: Unknown result type (might be due to invalid IL or missing references)
			//IL_0217: Expected O, but got Unknown
			//IL_0218: Expected O, but got Unknown
			//IL_022e: Unknown result type (might be due to invalid IL or missing references)
			//IL_0233: Unknown result type (might be due to invalid IL or missing references)
			//IL_023f: Expected O, but got Unknown
			//IL_024c: Unknown result type (might be due to invalid IL or missing references)
			//IL_0251: Unknown result type (might be due to invalid IL or missing references)
			//IL_025c: Expected O, but got Unknown
			//IL_025d: Expected O, but got Unknown
			//IL_0273: Unknown result type (might be due to invalid IL or missing references)
			//IL_0278: Unknown result type (might be due to invalid IL or missing references)
			//IL_0284: Expected O, but got Unknown
			//IL_0291: Unknown result type (might be due to invalid IL or missing references)
			//IL_0296: Unknown result type (might be due to invalid IL or missing references)
			//IL_02a1: Expected O, but got Unknown
			//IL_02a2: Expected O, but got Unknown
			//IL_02b1: Unknown result type (might be due to invalid IL or missing references)
			//IL_02b6: Unknown result type (might be due to invalid IL or missing references)
			//IL_02c7: Expected O, but got Unknown
			//IL_02c8: Expected O, but got Unknown
			string sql = "UPDATE log SET \r\n\t\t\t\tTitle=@Title,Type=@Type,WriteTime=@WriteTime,UserID=@UserID,UserName=@UserName,IPAddress=@IPAddress,URL=@URL,Contents=@Contents,Others=@Others,OldXml=@OldXml,NewXml=@NewXml\r\n\t\t\t\tWHERE ID=@ID";
			MySqlParameter[] obj = new MySqlParameter[12];
			MySqlParameter val = new MySqlParameter("@Title", 751, -1);
			((DbParameter)val).Value = model.Title;
			obj[0] = val;
			MySqlParameter val2 = new MySqlParameter("@Type", 253, 50);
			((DbParameter)val2).Value = model.Type;
			obj[1] = val2;
			MySqlParameter val3 = new MySqlParameter("@WriteTime", 12, -1);
			((DbParameter)val3).Value = model.WriteTime;
			obj[2] = val3;
			_003F val4;
			if (model.UserID.HasValue)
			{
				val4 = new MySqlParameter("@UserID", 253, 36);
				((DbParameter)val4).Value = model.UserID;
			}
			else
			{
				val4 = new MySqlParameter("@UserID", 253, 36);
				((DbParameter)val4).Value = DBNull.Value;
			}
			obj[3] = val4;
			_003F val5;
			if (model.UserName != null)
			{
				val5 = new MySqlParameter("@UserName", 253, 50);
				((DbParameter)val5).Value = model.UserName;
			}
			else
			{
				val5 = new MySqlParameter("@UserName", 253, 50);
				((DbParameter)val5).Value = DBNull.Value;
			}
			obj[4] = val5;
			_003F val6;
			if (model.IPAddress != null)
			{
				val6 = new MySqlParameter("@IPAddress", 253, 50);
				((DbParameter)val6).Value = model.IPAddress;
			}
			else
			{
				val6 = new MySqlParameter("@IPAddress", 253, 50);
				((DbParameter)val6).Value = DBNull.Value;
			}
			obj[5] = val6;
			_003F val7;
			if (model.URL != null)
			{
				val7 = new MySqlParameter("@URL", 751, -1);
				((DbParameter)val7).Value = model.URL;
			}
			else
			{
				val7 = new MySqlParameter("@URL", 751, -1);
				((DbParameter)val7).Value = DBNull.Value;
			}
			obj[6] = val7;
			_003F val8;
			if (model.Contents != null)
			{
				val8 = new MySqlParameter("@Contents", 751, -1);
				((DbParameter)val8).Value = model.Contents;
			}
			else
			{
				val8 = new MySqlParameter("@Contents", 751, -1);
				((DbParameter)val8).Value = DBNull.Value;
			}
			obj[7] = val8;
			_003F val9;
			if (model.Others != null)
			{
				val9 = new MySqlParameter("@Others", 751, -1);
				((DbParameter)val9).Value = model.Others;
			}
			else
			{
				val9 = new MySqlParameter("@Others", 751, -1);
				((DbParameter)val9).Value = DBNull.Value;
			}
			obj[8] = val9;
			_003F val10;
			if (model.OldXml != null)
			{
				val10 = new MySqlParameter("@OldXml", 751, -1);
				((DbParameter)val10).Value = model.OldXml;
			}
			else
			{
				val10 = new MySqlParameter("@OldXml", 751, -1);
				((DbParameter)val10).Value = DBNull.Value;
			}
			obj[9] = val10;
			_003F val11;
			if (model.NewXml != null)
			{
				val11 = new MySqlParameter("@NewXml", 751, -1);
				((DbParameter)val11).Value = model.NewXml;
			}
			else
			{
				val11 = new MySqlParameter("@NewXml", 751, -1);
				((DbParameter)val11).Value = DBNull.Value;
			}
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
			string sql = "DELETE FROM log WHERE ID=@ID";
			MySqlParameter[] obj = new MySqlParameter[1];
			MySqlParameter val = new MySqlParameter("@ID", 253, 36);
			((DbParameter)val).Value = id.ToString();
			obj[0] = val;
			MySqlParameter[] parameter = (MySqlParameter[])obj;
			return dbHelper.Execute(sql, parameter);
		}

		private List<RoadFlow.Data.Model.Log> DataReaderToList(MySqlDataReader dataReader)
		{
			List<RoadFlow.Data.Model.Log> list = new List<RoadFlow.Data.Model.Log>();
			RoadFlow.Data.Model.Log log = null;
			while (((DbDataReader)dataReader).Read())
			{
				log = new RoadFlow.Data.Model.Log();
				log.ID = ((DbDataReader)dataReader).GetString(0).ToGuid();
				log.Title = ((DbDataReader)dataReader).GetString(1);
				log.Type = ((DbDataReader)dataReader).GetString(2);
				log.WriteTime = ((DbDataReader)dataReader).GetDateTime(3);
				if (!((DbDataReader)dataReader).IsDBNull(4))
				{
					log.UserID = ((DbDataReader)dataReader).GetString(4).ToGuid();
				}
				if (!((DbDataReader)dataReader).IsDBNull(5))
				{
					log.UserName = ((DbDataReader)dataReader).GetString(5);
				}
				if (!((DbDataReader)dataReader).IsDBNull(6))
				{
					log.IPAddress = ((DbDataReader)dataReader).GetString(6);
				}
				if (!((DbDataReader)dataReader).IsDBNull(7))
				{
					log.URL = ((DbDataReader)dataReader).GetString(7);
				}
				if (!((DbDataReader)dataReader).IsDBNull(8))
				{
					log.Contents = ((DbDataReader)dataReader).GetString(8);
				}
				if (!((DbDataReader)dataReader).IsDBNull(9))
				{
					log.Others = ((DbDataReader)dataReader).GetString(9);
				}
				if (!((DbDataReader)dataReader).IsDBNull(10))
				{
					log.OldXml = ((DbDataReader)dataReader).GetString(10);
				}
				if (!((DbDataReader)dataReader).IsDBNull(11))
				{
					log.NewXml = ((DbDataReader)dataReader).GetString(11);
				}
				list.Add(log);
			}
			return list;
		}

		public List<RoadFlow.Data.Model.Log> GetAll()
		{
			string sql = "SELECT * FROM log";
			MySqlDataReader dataReader = dbHelper.GetDataReader(sql);
			List<RoadFlow.Data.Model.Log> result = DataReaderToList(dataReader);
			((DbDataReader)dataReader).Close();
			return result;
		}

		public long GetCount()
		{
			string sql = "SELECT COUNT(*) FROM log";
			long result;
			if (!long.TryParse(dbHelper.GetFieldValue(sql), out result))
			{
				return 0L;
			}
			return result;
		}

		public RoadFlow.Data.Model.Log Get(Guid id)
		{
			//IL_001a: Unknown result type (might be due to invalid IL or missing references)
			//IL_001f: Unknown result type (might be due to invalid IL or missing references)
			//IL_0032: Expected O, but got Unknown
			//IL_0033: Expected O, but got Unknown
			string sql = "SELECT * FROM log WHERE ID=@ID";
			MySqlParameter[] obj = new MySqlParameter[1];
			MySqlParameter val = new MySqlParameter("@ID", 253, 36);
			((DbParameter)val).Value = id.ToString();
			obj[0] = val;
			MySqlParameter[] parameter = (MySqlParameter[])obj;
			MySqlDataReader dataReader = dbHelper.GetDataReader(sql, parameter);
			List<RoadFlow.Data.Model.Log> list = DataReaderToList(dataReader);
			((DbDataReader)dataReader).Close();
			if (list.Count <= 0)
			{
				return null;
			}
			return list[0];
		}

		public DataTable GetPagerData(out string pager, string query = "", int size = 15, int number = 1, string title = "", string type = "", string date1 = "", string date2 = "", string userID = "")
		{
			//IL_002c: Unknown result type (might be due to invalid IL or missing references)
			//IL_0031: Unknown result type (might be due to invalid IL or missing references)
			//IL_0039: Expected O, but got Unknown
			//IL_003e: Expected O, but got Unknown
			//IL_005e: Unknown result type (might be due to invalid IL or missing references)
			//IL_0063: Unknown result type (might be due to invalid IL or missing references)
			//IL_006b: Expected O, but got Unknown
			//IL_0070: Expected O, but got Unknown
			//IL_008d: Unknown result type (might be due to invalid IL or missing references)
			//IL_0092: Unknown result type (might be due to invalid IL or missing references)
			//IL_00ad: Expected O, but got Unknown
			//IL_00b2: Expected O, but got Unknown
			//IL_00cf: Unknown result type (might be due to invalid IL or missing references)
			//IL_00d4: Unknown result type (might be due to invalid IL or missing references)
			//IL_0101: Expected O, but got Unknown
			//IL_0106: Expected O, but got Unknown
			//IL_0126: Unknown result type (might be due to invalid IL or missing references)
			//IL_012b: Unknown result type (might be due to invalid IL or missing references)
			//IL_013d: Expected O, but got Unknown
			//IL_0142: Expected O, but got Unknown
			StringBuilder stringBuilder = new StringBuilder();
			List<MySqlParameter> list = new List<MySqlParameter>();
			if (!title.IsNullOrEmpty())
			{
				stringBuilder.Append("AND INSTR(Title,@Title)>0 ");
				List<MySqlParameter> list2 = list;
				MySqlParameter val = new MySqlParameter("@Title", 253);
				((DbParameter)val).Value = title;
				list2.Add(val);
			}
			if (!type.IsNullOrEmpty())
			{
				stringBuilder.Append("AND Type=@Type ");
				List<MySqlParameter> list3 = list;
				MySqlParameter val2 = new MySqlParameter("@Type", 253);
				((DbParameter)val2).Value = type;
				list3.Add(val2);
			}
			if (date1.IsDateTime())
			{
				stringBuilder.Append("AND WriteTime>=@Date1 ");
				List<MySqlParameter> list4 = list;
				MySqlParameter val3 = new MySqlParameter("@Date1", 12);
				((DbParameter)val3).Value = date1.ToDateTime().ToString("yyyy-MM-dd 00:00:00");
				list4.Add(val3);
			}
			if (date2.IsDateTime())
			{
				stringBuilder.Append("AND WriteTime<=@Date2 ");
				List<MySqlParameter> list5 = list;
				MySqlParameter val4 = new MySqlParameter("@Date2", 12);
				((DbParameter)val4).Value = date2.ToDateTime().AddDays(1.0).ToString("yyyy-MM-dd 00:00:00");
				list5.Add(val4);
			}
			if (userID.IsGuid())
			{
				stringBuilder.Append("AND UserID=@UserID ");
				List<MySqlParameter> list6 = list;
				MySqlParameter val5 = new MySqlParameter("@UserID", 253);
				((DbParameter)val5).Value = userID.ToGuid();
				list6.Add(val5);
			}
			long count;
			string paerSql = dbHelper.GetPaerSql("Log", "ID,Title,Type,WriteTime,UserName,IPAddress", stringBuilder.ToString(), "WriteTime DESC", size, number, out count, list.ToArray());
			pager = Tools.GetPagerHtml(count, size, number, query);
			return dbHelper.GetDataTable(paerSql.ToString(), list.ToArray());
		}

		public DataTable GetPagerData(out long count, int size = 15, int number = 1, string title = "", string type = "", string date1 = "", string date2 = "", string userID = "", string order = "")
		{
			//IL_002c: Unknown result type (might be due to invalid IL or missing references)
			//IL_0031: Unknown result type (might be due to invalid IL or missing references)
			//IL_0039: Expected O, but got Unknown
			//IL_003e: Expected O, but got Unknown
			//IL_005e: Unknown result type (might be due to invalid IL or missing references)
			//IL_0063: Unknown result type (might be due to invalid IL or missing references)
			//IL_006b: Expected O, but got Unknown
			//IL_0070: Expected O, but got Unknown
			//IL_008d: Unknown result type (might be due to invalid IL or missing references)
			//IL_0092: Unknown result type (might be due to invalid IL or missing references)
			//IL_00ac: Expected O, but got Unknown
			//IL_00b1: Expected O, but got Unknown
			//IL_00ce: Unknown result type (might be due to invalid IL or missing references)
			//IL_00d3: Unknown result type (might be due to invalid IL or missing references)
			//IL_00fe: Expected O, but got Unknown
			//IL_0103: Expected O, but got Unknown
			//IL_0123: Unknown result type (might be due to invalid IL or missing references)
			//IL_0128: Unknown result type (might be due to invalid IL or missing references)
			//IL_0130: Expected O, but got Unknown
			//IL_0135: Expected O, but got Unknown
			StringBuilder stringBuilder = new StringBuilder();
			List<MySqlParameter> list = new List<MySqlParameter>();
			if (!title.IsNullOrEmpty())
			{
				stringBuilder.Append("AND INSTR(Title,@Title)>0 ");
				List<MySqlParameter> list2 = list;
				MySqlParameter val = new MySqlParameter("@Title", 253);
				((DbParameter)val).Value = title;
				list2.Add(val);
			}
			if (!type.IsNullOrEmpty())
			{
				stringBuilder.Append("AND Type=@Type ");
				List<MySqlParameter> list3 = list;
				MySqlParameter val2 = new MySqlParameter("@Type", 253);
				((DbParameter)val2).Value = type;
				list3.Add(val2);
			}
			if (date1.IsDateTime())
			{
				stringBuilder.Append("AND WriteTime>=@Date1 ");
				List<MySqlParameter> list4 = list;
				MySqlParameter val3 = new MySqlParameter("@Date1", 12);
				((DbParameter)val3).Value = date1.ToDateTime().ToString("yyyy-MM-dd 00:00:00");
				list4.Add(val3);
			}
			if (date2.IsDateTime())
			{
				stringBuilder.Append("AND WriteTime<=@Date2 ");
				List<MySqlParameter> list5 = list;
				MySqlParameter val4 = new MySqlParameter("@Date2", 12);
				((DbParameter)val4).Value = date2.ToDateTime().AddDays(1.0).ToString("yyyy-MM-dd 00:00:00");
				list5.Add(val4);
			}
			if (userID.IsGuid())
			{
				stringBuilder.Append("AND UserID=@UserID ");
				List<MySqlParameter> list6 = list;
				MySqlParameter val5 = new MySqlParameter("@UserID", 253);
				((DbParameter)val5).Value = userID;
				list6.Add(val5);
			}
			string paerSql = dbHelper.GetPaerSql("Log", "ID,Title,Type,WriteTime,UserName,IPAddress", stringBuilder.ToString(), order.IsNullOrEmpty() ? "WriteTime DESC" : order, size, number, out count, list.ToArray());
			return dbHelper.GetDataTable(paerSql.ToString(), list.ToArray());
		}
	}
}
