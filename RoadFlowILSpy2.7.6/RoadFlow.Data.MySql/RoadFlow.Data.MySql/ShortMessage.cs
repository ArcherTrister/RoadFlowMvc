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
	public class ShortMessage : IShortMessage
	{
		private DBHelper dbHelper = new DBHelper();

		public int Add(RoadFlow.Data.Model.ShortMessage model)
		{
			//IL_001b: Unknown result type (might be due to invalid IL or missing references)
			//IL_0020: Unknown result type (might be due to invalid IL or missing references)
			//IL_0031: Expected O, but got Unknown
			//IL_0032: Expected O, but got Unknown
			//IL_003f: Unknown result type (might be due to invalid IL or missing references)
			//IL_0044: Unknown result type (might be due to invalid IL or missing references)
			//IL_0050: Expected O, but got Unknown
			//IL_0051: Expected O, but got Unknown
			//IL_006a: Unknown result type (might be due to invalid IL or missing references)
			//IL_006f: Unknown result type (might be due to invalid IL or missing references)
			//IL_007b: Expected O, but got Unknown
			//IL_008c: Unknown result type (might be due to invalid IL or missing references)
			//IL_0091: Unknown result type (might be due to invalid IL or missing references)
			//IL_009c: Expected O, but got Unknown
			//IL_009d: Expected O, but got Unknown
			//IL_00ab: Unknown result type (might be due to invalid IL or missing references)
			//IL_00b0: Unknown result type (might be due to invalid IL or missing references)
			//IL_00c1: Expected O, but got Unknown
			//IL_00c2: Expected O, but got Unknown
			//IL_00cf: Unknown result type (might be due to invalid IL or missing references)
			//IL_00d4: Unknown result type (might be due to invalid IL or missing references)
			//IL_00e0: Expected O, but got Unknown
			//IL_00e1: Expected O, but got Unknown
			//IL_00ef: Unknown result type (might be due to invalid IL or missing references)
			//IL_00f4: Unknown result type (might be due to invalid IL or missing references)
			//IL_0105: Expected O, but got Unknown
			//IL_0106: Expected O, but got Unknown
			//IL_0113: Unknown result type (might be due to invalid IL or missing references)
			//IL_0118: Unknown result type (might be due to invalid IL or missing references)
			//IL_0124: Expected O, but got Unknown
			//IL_0125: Expected O, but got Unknown
			//IL_012f: Unknown result type (might be due to invalid IL or missing references)
			//IL_0134: Unknown result type (might be due to invalid IL or missing references)
			//IL_0145: Expected O, but got Unknown
			//IL_0146: Expected O, but got Unknown
			//IL_015f: Unknown result type (might be due to invalid IL or missing references)
			//IL_0164: Unknown result type (might be due to invalid IL or missing references)
			//IL_0170: Expected O, but got Unknown
			//IL_0181: Unknown result type (might be due to invalid IL or missing references)
			//IL_0186: Unknown result type (might be due to invalid IL or missing references)
			//IL_0191: Expected O, but got Unknown
			//IL_0192: Expected O, but got Unknown
			//IL_01a9: Unknown result type (might be due to invalid IL or missing references)
			//IL_01ae: Unknown result type (might be due to invalid IL or missing references)
			//IL_01ba: Expected O, but got Unknown
			//IL_01c8: Unknown result type (might be due to invalid IL or missing references)
			//IL_01cd: Unknown result type (might be due to invalid IL or missing references)
			//IL_01d8: Expected O, but got Unknown
			//IL_01d9: Expected O, but got Unknown
			//IL_01e4: Unknown result type (might be due to invalid IL or missing references)
			//IL_01e9: Unknown result type (might be due to invalid IL or missing references)
			//IL_01fa: Expected O, but got Unknown
			//IL_01fb: Expected O, but got Unknown
			//IL_0209: Unknown result type (might be due to invalid IL or missing references)
			//IL_020e: Unknown result type (might be due to invalid IL or missing references)
			//IL_021a: Expected O, but got Unknown
			//IL_021b: Expected O, but got Unknown
			string sql = "INSERT INTO shortmessage\r\n\t\t\t\t(ID,Title,Contents,SendUserID,SendUserName,ReceiveUserID,ReceiveUserName,SendTime,LinkUrl,LinkID,Type,Files) \r\n\t\t\t\tVALUES(@ID,@Title,@Contents,@SendUserID,@SendUserName,@ReceiveUserID,@ReceiveUserName,@SendTime,@LinkUrl,@LinkID,@Type,@Files)";
			MySqlParameter[] obj = new MySqlParameter[12];
			MySqlParameter val = new MySqlParameter("@ID", 253, 36);
			((DbParameter)val).Value = model.ID;
			obj[0] = val;
			MySqlParameter val2 = new MySqlParameter("@Title", 752, -1);
			((DbParameter)val2).Value = model.Title;
			obj[1] = val2;
			_003F val3;
			if (model.Contents != null)
			{
				val3 = new MySqlParameter("@Contents", 253, 4000);
				((DbParameter)val3).Value = model.Contents;
			}
			else
			{
				val3 = new MySqlParameter("@Contents", 253, 4000);
				((DbParameter)val3).Value = DBNull.Value;
			}
			obj[2] = val3;
			MySqlParameter val4 = new MySqlParameter("@SendUserID", 253, 36);
			((DbParameter)val4).Value = model.SendUserID;
			obj[3] = val4;
			MySqlParameter val5 = new MySqlParameter("@SendUserName", 752, -1);
			((DbParameter)val5).Value = model.SendUserName;
			obj[4] = val5;
			MySqlParameter val6 = new MySqlParameter("@ReceiveUserID", 253, 36);
			((DbParameter)val6).Value = model.ReceiveUserID;
			obj[5] = val6;
			MySqlParameter val7 = new MySqlParameter("@ReceiveUserName", 752, -1);
			((DbParameter)val7).Value = model.ReceiveUserName;
			obj[6] = val7;
			MySqlParameter val8 = new MySqlParameter("@SendTime", 12, -1);
			((DbParameter)val8).Value = model.SendTime;
			obj[7] = val8;
			_003F val9;
			if (model.LinkUrl != null)
			{
				val9 = new MySqlParameter("@LinkUrl", 253, 2000);
				((DbParameter)val9).Value = model.LinkUrl;
			}
			else
			{
				val9 = new MySqlParameter("@LinkUrl", 253, 2000);
				((DbParameter)val9).Value = DBNull.Value;
			}
			obj[8] = val9;
			_003F val10;
			if (model.LinkID != null)
			{
				val10 = new MySqlParameter("@LinkID", 253, 50);
				((DbParameter)val10).Value = model.LinkID;
			}
			else
			{
				val10 = new MySqlParameter("@LinkID", 253, 50);
				((DbParameter)val10).Value = DBNull.Value;
			}
			obj[9] = val10;
			MySqlParameter val11 = new MySqlParameter("@Type", 3, 11);
			((DbParameter)val11).Value = model.Type;
			obj[10] = val11;
			MySqlParameter val12 = new MySqlParameter("@Files", 752, -1);
			((DbParameter)val12).Value = model.Files;
			obj[11] = val12;
			MySqlParameter[] parameter = (MySqlParameter[])obj;
			return dbHelper.Execute(sql, parameter);
		}

		public int Update(RoadFlow.Data.Model.ShortMessage model)
		{
			//IL_001a: Unknown result type (might be due to invalid IL or missing references)
			//IL_001f: Unknown result type (might be due to invalid IL or missing references)
			//IL_002b: Expected O, but got Unknown
			//IL_002c: Expected O, but got Unknown
			//IL_0045: Unknown result type (might be due to invalid IL or missing references)
			//IL_004a: Unknown result type (might be due to invalid IL or missing references)
			//IL_0056: Expected O, but got Unknown
			//IL_0067: Unknown result type (might be due to invalid IL or missing references)
			//IL_006c: Unknown result type (might be due to invalid IL or missing references)
			//IL_0077: Expected O, but got Unknown
			//IL_0078: Expected O, but got Unknown
			//IL_0086: Unknown result type (might be due to invalid IL or missing references)
			//IL_008b: Unknown result type (might be due to invalid IL or missing references)
			//IL_009c: Expected O, but got Unknown
			//IL_009d: Expected O, but got Unknown
			//IL_00aa: Unknown result type (might be due to invalid IL or missing references)
			//IL_00af: Unknown result type (might be due to invalid IL or missing references)
			//IL_00bb: Expected O, but got Unknown
			//IL_00bc: Expected O, but got Unknown
			//IL_00ca: Unknown result type (might be due to invalid IL or missing references)
			//IL_00cf: Unknown result type (might be due to invalid IL or missing references)
			//IL_00e0: Expected O, but got Unknown
			//IL_00e1: Expected O, but got Unknown
			//IL_00ee: Unknown result type (might be due to invalid IL or missing references)
			//IL_00f3: Unknown result type (might be due to invalid IL or missing references)
			//IL_00ff: Expected O, but got Unknown
			//IL_0100: Expected O, but got Unknown
			//IL_010a: Unknown result type (might be due to invalid IL or missing references)
			//IL_010f: Unknown result type (might be due to invalid IL or missing references)
			//IL_0120: Expected O, but got Unknown
			//IL_0121: Expected O, but got Unknown
			//IL_013a: Unknown result type (might be due to invalid IL or missing references)
			//IL_013f: Unknown result type (might be due to invalid IL or missing references)
			//IL_014b: Expected O, but got Unknown
			//IL_015c: Unknown result type (might be due to invalid IL or missing references)
			//IL_0161: Unknown result type (might be due to invalid IL or missing references)
			//IL_016c: Expected O, but got Unknown
			//IL_016d: Expected O, but got Unknown
			//IL_0183: Unknown result type (might be due to invalid IL or missing references)
			//IL_0188: Unknown result type (might be due to invalid IL or missing references)
			//IL_0194: Expected O, but got Unknown
			//IL_01a2: Unknown result type (might be due to invalid IL or missing references)
			//IL_01a7: Unknown result type (might be due to invalid IL or missing references)
			//IL_01b2: Expected O, but got Unknown
			//IL_01b3: Expected O, but got Unknown
			//IL_01be: Unknown result type (might be due to invalid IL or missing references)
			//IL_01c3: Unknown result type (might be due to invalid IL or missing references)
			//IL_01d4: Expected O, but got Unknown
			//IL_01d5: Expected O, but got Unknown
			//IL_01e3: Unknown result type (might be due to invalid IL or missing references)
			//IL_01e8: Unknown result type (might be due to invalid IL or missing references)
			//IL_01f4: Expected O, but got Unknown
			//IL_01f5: Expected O, but got Unknown
			//IL_0204: Unknown result type (might be due to invalid IL or missing references)
			//IL_0209: Unknown result type (might be due to invalid IL or missing references)
			//IL_021a: Expected O, but got Unknown
			//IL_021b: Expected O, but got Unknown
			string sql = "UPDATE shortmessage SET \r\n\t\t\t\tTitle=@Title,Contents=@Contents,SendUserID=@SendUserID,SendUserName=@SendUserName,ReceiveUserID=@ReceiveUserID,ReceiveUserName=@ReceiveUserName,SendTime=@SendTime,LinkUrl=@LinkUrl,LinkID=@LinkID,Type=@Type,Files=@Files\r\n\t\t\t\tWHERE ID=@ID";
			MySqlParameter[] obj = new MySqlParameter[12];
			MySqlParameter val = new MySqlParameter("@Title", 752, -1);
			((DbParameter)val).Value = model.Title;
			obj[0] = val;
			_003F val2;
			if (model.Contents != null)
			{
				val2 = new MySqlParameter("@Contents", 253, 4000);
				((DbParameter)val2).Value = model.Contents;
			}
			else
			{
				val2 = new MySqlParameter("@Contents", 253, 4000);
				((DbParameter)val2).Value = DBNull.Value;
			}
			obj[1] = val2;
			MySqlParameter val3 = new MySqlParameter("@SendUserID", 253, 36);
			((DbParameter)val3).Value = model.SendUserID;
			obj[2] = val3;
			MySqlParameter val4 = new MySqlParameter("@SendUserName", 752, -1);
			((DbParameter)val4).Value = model.SendUserName;
			obj[3] = val4;
			MySqlParameter val5 = new MySqlParameter("@ReceiveUserID", 253, 36);
			((DbParameter)val5).Value = model.ReceiveUserID;
			obj[4] = val5;
			MySqlParameter val6 = new MySqlParameter("@ReceiveUserName", 752, -1);
			((DbParameter)val6).Value = model.ReceiveUserName;
			obj[5] = val6;
			MySqlParameter val7 = new MySqlParameter("@SendTime", 12, -1);
			((DbParameter)val7).Value = model.SendTime;
			obj[6] = val7;
			_003F val8;
			if (model.LinkUrl != null)
			{
				val8 = new MySqlParameter("@LinkUrl", 253, 2000);
				((DbParameter)val8).Value = model.LinkUrl;
			}
			else
			{
				val8 = new MySqlParameter("@LinkUrl", 253, 2000);
				((DbParameter)val8).Value = DBNull.Value;
			}
			obj[7] = val8;
			_003F val9;
			if (model.LinkID != null)
			{
				val9 = new MySqlParameter("@LinkID", 253, 50);
				((DbParameter)val9).Value = model.LinkID;
			}
			else
			{
				val9 = new MySqlParameter("@LinkID", 253, 50);
				((DbParameter)val9).Value = DBNull.Value;
			}
			obj[8] = val9;
			MySqlParameter val10 = new MySqlParameter("@Type", 3, 11);
			((DbParameter)val10).Value = model.Type;
			obj[9] = val10;
			MySqlParameter val11 = new MySqlParameter("@Files", 752, -1);
			((DbParameter)val11).Value = model.Files;
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
			string sql = "DELETE FROM shortmessage WHERE ID=@ID";
			MySqlParameter[] obj = new MySqlParameter[1];
			MySqlParameter val = new MySqlParameter("@ID", 253, 36);
			((DbParameter)val).Value = id.ToString();
			obj[0] = val;
			MySqlParameter[] parameter = (MySqlParameter[])obj;
			return dbHelper.Execute(sql, parameter);
		}

		private List<RoadFlow.Data.Model.ShortMessage> DataReaderToList(MySqlDataReader dataReader)
		{
			List<RoadFlow.Data.Model.ShortMessage> list = new List<RoadFlow.Data.Model.ShortMessage>();
			RoadFlow.Data.Model.ShortMessage shortMessage = null;
			while (((DbDataReader)dataReader).Read())
			{
				shortMessage = new RoadFlow.Data.Model.ShortMessage();
				shortMessage.ID = ((DbDataReader)dataReader).GetString(0).ToGuid();
				shortMessage.Title = ((DbDataReader)dataReader).GetString(1);
				if (!((DbDataReader)dataReader).IsDBNull(2))
				{
					shortMessage.Contents = ((DbDataReader)dataReader).GetString(2);
				}
				shortMessage.SendUserID = ((DbDataReader)dataReader).GetString(3).ToGuid();
				shortMessage.SendUserName = ((DbDataReader)dataReader).GetString(4);
				shortMessage.ReceiveUserID = ((DbDataReader)dataReader).GetString(5).ToGuid();
				shortMessage.ReceiveUserName = ((DbDataReader)dataReader).GetString(6);
				shortMessage.SendTime = ((DbDataReader)dataReader).GetDateTime(7);
				if (!((DbDataReader)dataReader).IsDBNull(8))
				{
					shortMessage.LinkUrl = ((DbDataReader)dataReader).GetString(8);
				}
				if (!((DbDataReader)dataReader).IsDBNull(9))
				{
					shortMessage.LinkID = ((DbDataReader)dataReader).GetString(9);
				}
				shortMessage.Type = ((DbDataReader)dataReader).GetInt32(10);
				if (!((DbDataReader)dataReader).IsDBNull(11))
				{
					shortMessage.Files = ((DbDataReader)dataReader).GetString(11);
				}
				if (((DbDataReader)dataReader).FieldCount > 11)
				{
					shortMessage.Status = ((DbDataReader)dataReader).GetInt32(12);
				}
				else
				{
					shortMessage.Status = 0;
				}
				list.Add(shortMessage);
			}
			return list;
		}

		public List<RoadFlow.Data.Model.ShortMessage> GetAll()
		{
			string sql = "SELECT *,0 AS Status FROM shortmessage";
			MySqlDataReader dataReader = dbHelper.GetDataReader(sql);
			List<RoadFlow.Data.Model.ShortMessage> result = DataReaderToList(dataReader);
			((DbDataReader)dataReader).Close();
			return result;
		}

		public long GetCount()
		{
			string sql = "SELECT COUNT(*) FROM shortmessage";
			long result;
			if (!long.TryParse(dbHelper.GetFieldValue(sql), out result))
			{
				return 0L;
			}
			return result;
		}

		public RoadFlow.Data.Model.ShortMessage Get(Guid id)
		{
			//IL_001a: Unknown result type (might be due to invalid IL or missing references)
			//IL_001f: Unknown result type (might be due to invalid IL or missing references)
			//IL_0032: Expected O, but got Unknown
			//IL_0033: Expected O, but got Unknown
			string sql = "SELECT *,0 AS Status FROM shortmessage WHERE ID=@ID";
			MySqlParameter[] obj = new MySqlParameter[1];
			MySqlParameter val = new MySqlParameter("@ID", 253, 36);
			((DbParameter)val).Value = id.ToString();
			obj[0] = val;
			MySqlParameter[] parameter = (MySqlParameter[])obj;
			MySqlDataReader dataReader = dbHelper.GetDataReader(sql, parameter);
			List<RoadFlow.Data.Model.ShortMessage> list = DataReaderToList(dataReader);
			((DbDataReader)dataReader).Close();
			if (list.Count <= 0)
			{
				return null;
			}
			return list[0];
		}

		public RoadFlow.Data.Model.ShortMessage GetRead(Guid id)
		{
			//IL_0018: Unknown result type (might be due to invalid IL or missing references)
			//IL_001d: Unknown result type (might be due to invalid IL or missing references)
			//IL_0030: Expected O, but got Unknown
			//IL_0031: Expected O, but got Unknown
			string sql = "SELECT *,0 AS Status FROM ShortMessage1 WHERE ID=@ID";
			MySqlParameter[] obj = new MySqlParameter[1];
			MySqlParameter val = new MySqlParameter("@ID", 253);
			((DbParameter)val).Value = id.ToString();
			obj[0] = val;
			MySqlParameter[] parameter = (MySqlParameter[])obj;
			MySqlDataReader dataReader = dbHelper.GetDataReader(sql, parameter);
			List<RoadFlow.Data.Model.ShortMessage> list = DataReaderToList(dataReader);
			((DbDataReader)dataReader).Close();
			if (list.Count <= 0)
			{
				return null;
			}
			return list[0];
		}

		public List<RoadFlow.Data.Model.ShortMessage> GetAllNoRead()
		{
			string sql = "SELECT *,0 AS Status FROM ShortMessage";
			MySqlDataReader dataReader = dbHelper.GetDataReader(sql);
			List<RoadFlow.Data.Model.ShortMessage> result = DataReaderToList(dataReader);
			((DbDataReader)dataReader).Close();
			return result;
		}

		public List<RoadFlow.Data.Model.ShortMessage> GetAllNoReadByUserID(Guid userID)
		{
			//IL_0018: Unknown result type (might be due to invalid IL or missing references)
			//IL_001d: Unknown result type (might be due to invalid IL or missing references)
			//IL_0030: Expected O, but got Unknown
			//IL_0031: Expected O, but got Unknown
			string sql = "SELECT *,0 AS Status FROM ShortMessage WHERE ReceiveUserID=@ReceiveUserID";
			MySqlParameter[] obj = new MySqlParameter[1];
			MySqlParameter val = new MySqlParameter("@ReceiveUserID", 253);
			((DbParameter)val).Value = userID.ToString();
			obj[0] = val;
			MySqlParameter[] parameter = (MySqlParameter[])obj;
			MySqlDataReader dataReader = dbHelper.GetDataReader(sql, parameter);
			List<RoadFlow.Data.Model.ShortMessage> result = DataReaderToList(dataReader);
			((DbDataReader)dataReader).Close();
			return result;
		}

		public int UpdateStatus(Guid id)
		{
			//IL_0018: Unknown result type (might be due to invalid IL or missing references)
			//IL_001d: Unknown result type (might be due to invalid IL or missing references)
			//IL_0030: Expected O, but got Unknown
			//IL_0031: Expected O, but got Unknown
			string sql = "INSERT INTO ShortMessage1 SELECT * FROM ShortMessage WHERE ID=@ID;DELETE FROM ShortMessage WHERE ID=@ID";
			MySqlParameter[] obj = new MySqlParameter[1];
			MySqlParameter val = new MySqlParameter("@ID", 253);
			((DbParameter)val).Value = id.ToString();
			obj[0] = val;
			MySqlParameter[] parameter = (MySqlParameter[])obj;
			return dbHelper.Execute(sql, parameter);
		}

		public List<RoadFlow.Data.Model.ShortMessage> GetList(out string pager, int[] status, string query = "", string title = "", string contents = "", string senderID = "", string date1 = "", string date2 = "", string receiveID = "")
		{
			//IL_0063: Unknown result type (might be due to invalid IL or missing references)
			//IL_006d: Expected O, but got Unknown
			//IL_008a: Unknown result type (might be due to invalid IL or missing references)
			//IL_0094: Expected O, but got Unknown
			//IL_00b1: Unknown result type (might be due to invalid IL or missing references)
			//IL_00bb: Expected O, but got Unknown
			//IL_00f9: Unknown result type (might be due to invalid IL or missing references)
			//IL_0103: Expected O, but got Unknown
			//IL_013c: Unknown result type (might be due to invalid IL or missing references)
			//IL_0146: Expected O, but got Unknown
			List<MySqlParameter> list = new List<MySqlParameter>();
			string value = string.Empty;
			if (status.Length == 1 && status[0] == 0)
			{
				value = "SELECT *,0 AS Status FROM ShortMessage WHERE 1=1";
			}
			else if (status.Length == 1 && status[0] == 1)
			{
				value = "SELECT *,1 AS Status FROM ShortMessage1 WHERE 1=1";
			}
			else if (status.Length == 2)
			{
				value = "SELECT * FROM(SELECT *,0 AS Status FROM ShortMessage WHERE 1=1 UNION ALL SELECT *,1 AS Status FROM ShortMessage1 WHERE 1=1) temp WHERE 1=1";
			}
			StringBuilder stringBuilder = new StringBuilder(value);
			if (receiveID.IsGuid())
			{
				stringBuilder.Append(" AND ReceiveUserID=@ReceiveUserID");
				list.Add(new MySqlParameter("@ReceiveUserID", (object)receiveID));
			}
			if (!title.IsNullOrEmpty())
			{
				stringBuilder.Append(" AND INSTR(Title,@Title)>0");
				list.Add(new MySqlParameter("@Title", (object)title));
			}
			if (!contents.IsNullOrEmpty())
			{
				stringBuilder.Append(" AND INSTR(Contents,@Contents)>0");
				list.Add(new MySqlParameter("@Contents", (object)contents));
			}
			if (!senderID.IsNullOrEmpty())
			{
				stringBuilder.AppendFormat(" AND SendUserID IN({0})", senderID);
			}
			if (date1.IsDateTime())
			{
				stringBuilder.Append(" AND SendTime>=@SendTime");
				list.Add(new MySqlParameter("@SendTime", (object)date1.ToDateTime()));
			}
			if (date2.IsDateTime())
			{
				stringBuilder.Append(" AND SendTime<=@SendTime1");
				list.Add(new MySqlParameter("@SendTime1", (object)date2.ToDateTime().AddDays(1.0).ToDateString()));
			}
			stringBuilder.Append(" ORDER BY SendTime DESC");
			int pageSize = Tools.GetPageSize();
			int pageNumber = Tools.GetPageNumber();
			long count;
			string paerSql = dbHelper.GetPaerSql(stringBuilder.ToString(), pageSize, pageNumber, out count, list.ToArray());
			pager = Tools.GetPagerHtml(count, pageSize, pageNumber, query);
			MySqlDataReader dataReader = dbHelper.GetDataReader(paerSql, list.ToArray());
			List<RoadFlow.Data.Model.ShortMessage> result = DataReaderToList(dataReader);
			((DbDataReader)dataReader).Close();
			return result;
		}

		public List<RoadFlow.Data.Model.ShortMessage> GetList(out long count, int[] status, int size, int number, string title = "", string contents = "", string senderID = "", string date1 = "", string date2 = "", string receiveID = "", string order = "")
		{
			//IL_0063: Unknown result type (might be due to invalid IL or missing references)
			//IL_006d: Expected O, but got Unknown
			//IL_008a: Unknown result type (might be due to invalid IL or missing references)
			//IL_0094: Expected O, but got Unknown
			//IL_00b1: Unknown result type (might be due to invalid IL or missing references)
			//IL_00bb: Expected O, but got Unknown
			//IL_00f9: Unknown result type (might be due to invalid IL or missing references)
			//IL_0103: Expected O, but got Unknown
			//IL_013c: Unknown result type (might be due to invalid IL or missing references)
			//IL_0146: Expected O, but got Unknown
			List<MySqlParameter> list = new List<MySqlParameter>();
			string value = string.Empty;
			if (status.Length == 1 && status[0] == 0)
			{
				value = "SELECT *,0 AS Status FROM ShortMessage WHERE 1=1";
			}
			else if (status.Length == 1 && status[0] == 1)
			{
				value = "SELECT *,1 AS Status FROM ShortMessage1 WHERE 1=1";
			}
			else if (status.Length == 2)
			{
				value = "SELECT * FROM(SELECT *,0 AS Status FROM ShortMessage WHERE 1=1 UNION ALL SELECT *,1 AS Status FROM ShortMessage1 WHERE 1=1) temp WHERE 1=1";
			}
			StringBuilder stringBuilder = new StringBuilder(value);
			if (receiveID.IsGuid())
			{
				stringBuilder.Append(" AND ReceiveUserID=@ReceiveUserID");
				list.Add(new MySqlParameter("@ReceiveUserID", (object)receiveID));
			}
			if (!title.IsNullOrEmpty())
			{
				stringBuilder.Append(" AND INSTR(Title,@Title)>0");
				list.Add(new MySqlParameter("@Title", (object)title));
			}
			if (!contents.IsNullOrEmpty())
			{
				stringBuilder.Append(" AND INSTR(Contents,@Contents)>0");
				list.Add(new MySqlParameter("@Contents", (object)contents));
			}
			if (!senderID.IsNullOrEmpty())
			{
				stringBuilder.AppendFormat(" AND SendUserID IN({0})", senderID);
			}
			if (date1.IsDateTime())
			{
				stringBuilder.Append(" AND SendTime>=@SendTime");
				list.Add(new MySqlParameter("@SendTime", (object)date1.ToDateTime()));
			}
			if (date2.IsDateTime())
			{
				stringBuilder.Append(" AND SendTime<=@SendTime1");
				list.Add(new MySqlParameter("@SendTime1", (object)date2.ToDateTime().AddDays(1.0).ToDateString()));
			}
			stringBuilder.Append(" ORDER BY " + (order.IsNullOrEmpty() ? "SendTime DESC" : order));
			string paerSql = dbHelper.GetPaerSql(stringBuilder.ToString(), size, number, out count, list.ToArray());
			MySqlDataReader dataReader = dbHelper.GetDataReader(paerSql, list.ToArray());
			List<RoadFlow.Data.Model.ShortMessage> result = DataReaderToList(dataReader);
			((DbDataReader)dataReader).Close();
			return result;
		}

		public int Delete(string linkID, int Type)
		{
			//IL_0018: Unknown result type (might be due to invalid IL or missing references)
			//IL_001d: Unknown result type (might be due to invalid IL or missing references)
			//IL_0024: Expected O, but got Unknown
			//IL_0025: Expected O, but got Unknown
			//IL_002d: Unknown result type (might be due to invalid IL or missing references)
			//IL_0032: Unknown result type (might be due to invalid IL or missing references)
			//IL_003e: Expected O, but got Unknown
			//IL_003f: Expected O, but got Unknown
			string sql = "DELETE FROM ShortMessage WHERE LinkID=@LinkID AND Type=@Type";
			MySqlParameter[] obj = new MySqlParameter[2];
			MySqlParameter val = new MySqlParameter("@LinkID", 253);
			((DbParameter)val).Value = linkID;
			obj[0] = val;
			MySqlParameter val2 = new MySqlParameter("@Type", 3);
			((DbParameter)val2).Value = Type;
			obj[1] = val2;
			MySqlParameter[] parameter = (MySqlParameter[])obj;
			return dbHelper.Execute(sql, parameter);
		}
	}
}
