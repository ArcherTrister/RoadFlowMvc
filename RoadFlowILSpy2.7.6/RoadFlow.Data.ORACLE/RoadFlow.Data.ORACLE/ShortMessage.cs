using Oracle.ManagedDataAccess.Client;
using RoadFlow.Data.Interface;
using RoadFlow.Data.Model;
using RoadFlow.Utility;
using System;
using System.Collections.Generic;
using System.Data.Common;
using System.Text;

namespace RoadFlow.Data.ORACLE
{
	public class ShortMessage : IShortMessage
	{
		private DBHelper dbHelper = new DBHelper();

		public int Add(RoadFlow.Data.Model.ShortMessage model)
		{
			//IL_0016: Unknown result type (might be due to invalid IL or missing references)
			//IL_001b: Unknown result type (might be due to invalid IL or missing references)
			//IL_002c: Expected O, but got Unknown
			//IL_002d: Expected O, but got Unknown
			//IL_0036: Unknown result type (might be due to invalid IL or missing references)
			//IL_003b: Unknown result type (might be due to invalid IL or missing references)
			//IL_0047: Expected O, but got Unknown
			//IL_0048: Expected O, but got Unknown
			//IL_0059: Unknown result type (might be due to invalid IL or missing references)
			//IL_005e: Unknown result type (might be due to invalid IL or missing references)
			//IL_006a: Expected O, but got Unknown
			//IL_0073: Unknown result type (might be due to invalid IL or missing references)
			//IL_0078: Unknown result type (might be due to invalid IL or missing references)
			//IL_0083: Expected O, but got Unknown
			//IL_0084: Expected O, but got Unknown
			//IL_008d: Unknown result type (might be due to invalid IL or missing references)
			//IL_0092: Unknown result type (might be due to invalid IL or missing references)
			//IL_00a3: Expected O, but got Unknown
			//IL_00a4: Expected O, but got Unknown
			//IL_00ad: Unknown result type (might be due to invalid IL or missing references)
			//IL_00b2: Unknown result type (might be due to invalid IL or missing references)
			//IL_00be: Expected O, but got Unknown
			//IL_00bf: Expected O, but got Unknown
			//IL_00c8: Unknown result type (might be due to invalid IL or missing references)
			//IL_00cd: Unknown result type (might be due to invalid IL or missing references)
			//IL_00de: Expected O, but got Unknown
			//IL_00df: Expected O, but got Unknown
			//IL_00e8: Unknown result type (might be due to invalid IL or missing references)
			//IL_00ed: Unknown result type (might be due to invalid IL or missing references)
			//IL_00f9: Expected O, but got Unknown
			//IL_00fa: Expected O, but got Unknown
			//IL_0103: Unknown result type (might be due to invalid IL or missing references)
			//IL_0108: Unknown result type (might be due to invalid IL or missing references)
			//IL_0119: Expected O, but got Unknown
			//IL_011a: Expected O, but got Unknown
			//IL_012b: Unknown result type (might be due to invalid IL or missing references)
			//IL_0130: Unknown result type (might be due to invalid IL or missing references)
			//IL_013c: Expected O, but got Unknown
			//IL_0145: Unknown result type (might be due to invalid IL or missing references)
			//IL_014a: Unknown result type (might be due to invalid IL or missing references)
			//IL_0155: Expected O, but got Unknown
			//IL_0156: Expected O, but got Unknown
			//IL_0168: Unknown result type (might be due to invalid IL or missing references)
			//IL_016d: Unknown result type (might be due to invalid IL or missing references)
			//IL_0179: Expected O, but got Unknown
			//IL_0182: Unknown result type (might be due to invalid IL or missing references)
			//IL_0187: Unknown result type (might be due to invalid IL or missing references)
			//IL_0192: Expected O, but got Unknown
			//IL_0193: Expected O, but got Unknown
			//IL_019d: Unknown result type (might be due to invalid IL or missing references)
			//IL_01a2: Unknown result type (might be due to invalid IL or missing references)
			//IL_01b3: Expected O, but got Unknown
			//IL_01b4: Expected O, but got Unknown
			//IL_01be: Unknown result type (might be due to invalid IL or missing references)
			//IL_01c3: Unknown result type (might be due to invalid IL or missing references)
			//IL_01cf: Expected O, but got Unknown
			//IL_01d0: Expected O, but got Unknown
			string sql = "INSERT INTO ShortMessage\r\n\t\t\t\t(ID,Title,Contents,SendUserID,SendUserName,ReceiveUserID,ReceiveUserName,SendTime,LinkUrl,LinkID,Type,Files) \r\n\t\t\t\tVALUES(:ID,:Title,:Contents,:SendUserID,:SendUserName,:ReceiveUserID,:ReceiveUserName,:SendTime,:LinkUrl,:LinkID,:Type,:Files)";
			OracleParameter[] obj = new OracleParameter[12];
			OracleParameter val = new OracleParameter(":ID", 126);
			((DbParameter)val).Value = model.ID;
			obj[0] = val;
			OracleParameter val2 = new OracleParameter(":Title", 119);
			((DbParameter)val2).Value = model.Title;
			obj[1] = val2;
			_003F val3;
			if (model.Contents != null)
			{
				val3 = new OracleParameter(":Contents", 119);
				((DbParameter)val3).Value = model.Contents;
			}
			else
			{
				val3 = new OracleParameter(":Contents", 119);
				((DbParameter)val3).Value = DBNull.Value;
			}
			obj[2] = val3;
			OracleParameter val4 = new OracleParameter(":SendUserID", 126);
			((DbParameter)val4).Value = model.SendUserID;
			obj[3] = val4;
			OracleParameter val5 = new OracleParameter(":SendUserName", 119);
			((DbParameter)val5).Value = model.SendUserName;
			obj[4] = val5;
			OracleParameter val6 = new OracleParameter(":ReceiveUserID", 126);
			((DbParameter)val6).Value = model.ReceiveUserID;
			obj[5] = val6;
			OracleParameter val7 = new OracleParameter(":ReceiveUserName", 119);
			((DbParameter)val7).Value = model.ReceiveUserName;
			obj[6] = val7;
			OracleParameter val8 = new OracleParameter(":SendTime", 106);
			((DbParameter)val8).Value = model.SendTime;
			obj[7] = val8;
			_003F val9;
			if (model.LinkUrl != null)
			{
				val9 = new OracleParameter(":LinkUrl", 126);
				((DbParameter)val9).Value = model.LinkUrl;
			}
			else
			{
				val9 = new OracleParameter(":LinkUrl", 126);
				((DbParameter)val9).Value = DBNull.Value;
			}
			obj[8] = val9;
			_003F val10;
			if (model.LinkID != null)
			{
				val10 = new OracleParameter(":LinkID", 126);
				((DbParameter)val10).Value = model.LinkID;
			}
			else
			{
				val10 = new OracleParameter(":LinkID", 126);
				((DbParameter)val10).Value = DBNull.Value;
			}
			obj[9] = val10;
			OracleParameter val11 = new OracleParameter(":Type", 112);
			((DbParameter)val11).Value = model.Type;
			obj[10] = val11;
			OracleParameter val12 = new OracleParameter(":Files", 126);
			((DbParameter)val12).Value = model.Files;
			obj[11] = val12;
			OracleParameter[] parameter = (OracleParameter[])obj;
			return dbHelper.Execute(sql, parameter);
		}

		public int Update(RoadFlow.Data.Model.ShortMessage model)
		{
			//IL_0016: Unknown result type (might be due to invalid IL or missing references)
			//IL_001b: Unknown result type (might be due to invalid IL or missing references)
			//IL_0027: Expected O, but got Unknown
			//IL_0028: Expected O, but got Unknown
			//IL_0039: Unknown result type (might be due to invalid IL or missing references)
			//IL_003e: Unknown result type (might be due to invalid IL or missing references)
			//IL_004a: Expected O, but got Unknown
			//IL_0053: Unknown result type (might be due to invalid IL or missing references)
			//IL_0058: Unknown result type (might be due to invalid IL or missing references)
			//IL_0063: Expected O, but got Unknown
			//IL_0064: Expected O, but got Unknown
			//IL_006d: Unknown result type (might be due to invalid IL or missing references)
			//IL_0072: Unknown result type (might be due to invalid IL or missing references)
			//IL_0083: Expected O, but got Unknown
			//IL_0084: Expected O, but got Unknown
			//IL_008d: Unknown result type (might be due to invalid IL or missing references)
			//IL_0092: Unknown result type (might be due to invalid IL or missing references)
			//IL_009e: Expected O, but got Unknown
			//IL_009f: Expected O, but got Unknown
			//IL_00a8: Unknown result type (might be due to invalid IL or missing references)
			//IL_00ad: Unknown result type (might be due to invalid IL or missing references)
			//IL_00be: Expected O, but got Unknown
			//IL_00bf: Expected O, but got Unknown
			//IL_00c8: Unknown result type (might be due to invalid IL or missing references)
			//IL_00cd: Unknown result type (might be due to invalid IL or missing references)
			//IL_00d9: Expected O, but got Unknown
			//IL_00da: Expected O, but got Unknown
			//IL_00e3: Unknown result type (might be due to invalid IL or missing references)
			//IL_00e8: Unknown result type (might be due to invalid IL or missing references)
			//IL_00f9: Expected O, but got Unknown
			//IL_00fa: Expected O, but got Unknown
			//IL_010b: Unknown result type (might be due to invalid IL or missing references)
			//IL_0110: Unknown result type (might be due to invalid IL or missing references)
			//IL_011c: Expected O, but got Unknown
			//IL_0125: Unknown result type (might be due to invalid IL or missing references)
			//IL_012a: Unknown result type (might be due to invalid IL or missing references)
			//IL_0135: Expected O, but got Unknown
			//IL_0136: Expected O, but got Unknown
			//IL_0147: Unknown result type (might be due to invalid IL or missing references)
			//IL_014c: Unknown result type (might be due to invalid IL or missing references)
			//IL_0158: Expected O, but got Unknown
			//IL_0161: Unknown result type (might be due to invalid IL or missing references)
			//IL_0166: Unknown result type (might be due to invalid IL or missing references)
			//IL_0171: Expected O, but got Unknown
			//IL_0172: Expected O, but got Unknown
			//IL_017c: Unknown result type (might be due to invalid IL or missing references)
			//IL_0181: Unknown result type (might be due to invalid IL or missing references)
			//IL_0192: Expected O, but got Unknown
			//IL_0193: Expected O, but got Unknown
			//IL_019d: Unknown result type (might be due to invalid IL or missing references)
			//IL_01a2: Unknown result type (might be due to invalid IL or missing references)
			//IL_01ae: Expected O, but got Unknown
			//IL_01af: Expected O, but got Unknown
			//IL_01b9: Unknown result type (might be due to invalid IL or missing references)
			//IL_01be: Unknown result type (might be due to invalid IL or missing references)
			//IL_01cf: Expected O, but got Unknown
			//IL_01d0: Expected O, but got Unknown
			string sql = "UPDATE ShortMessage SET \r\n\t\t\t\tTitle=:Title,Contents=:Contents,SendUserID=:SendUserID,SendUserName=:SendUserName,ReceiveUserID=:ReceiveUserID,ReceiveUserName=:ReceiveUserName,SendTime=:SendTime,LinkUrl=:LinkUrl,LinkID=:LinkID,Type=:Type,Files=:Files\r\n\t\t\t\tWHERE ID=:ID";
			OracleParameter[] obj = new OracleParameter[12];
			OracleParameter val = new OracleParameter(":Title", 119);
			((DbParameter)val).Value = model.Title;
			obj[0] = val;
			_003F val2;
			if (model.Contents != null)
			{
				val2 = new OracleParameter(":Contents", 126);
				((DbParameter)val2).Value = model.Contents;
			}
			else
			{
				val2 = new OracleParameter(":Contents", 119);
				((DbParameter)val2).Value = DBNull.Value;
			}
			obj[1] = val2;
			OracleParameter val3 = new OracleParameter(":SendUserID", 126);
			((DbParameter)val3).Value = model.SendUserID;
			obj[2] = val3;
			OracleParameter val4 = new OracleParameter(":SendUserName", 119);
			((DbParameter)val4).Value = model.SendUserName;
			obj[3] = val4;
			OracleParameter val5 = new OracleParameter(":ReceiveUserID", 126);
			((DbParameter)val5).Value = model.ReceiveUserID;
			obj[4] = val5;
			OracleParameter val6 = new OracleParameter(":ReceiveUserName", 119);
			((DbParameter)val6).Value = model.ReceiveUserName;
			obj[5] = val6;
			OracleParameter val7 = new OracleParameter(":SendTime", 106);
			((DbParameter)val7).Value = model.SendTime;
			obj[6] = val7;
			_003F val8;
			if (model.LinkUrl != null)
			{
				val8 = new OracleParameter(":LinkUrl", 126);
				((DbParameter)val8).Value = model.LinkUrl;
			}
			else
			{
				val8 = new OracleParameter(":LinkUrl", 126);
				((DbParameter)val8).Value = DBNull.Value;
			}
			obj[7] = val8;
			_003F val9;
			if (model.LinkID != null)
			{
				val9 = new OracleParameter(":LinkID", 126);
				((DbParameter)val9).Value = model.LinkID;
			}
			else
			{
				val9 = new OracleParameter(":LinkID", 126);
				((DbParameter)val9).Value = DBNull.Value;
			}
			obj[8] = val9;
			OracleParameter val10 = new OracleParameter(":Type", 112);
			((DbParameter)val10).Value = model.Type;
			obj[9] = val10;
			OracleParameter val11 = new OracleParameter(":Files", 126);
			((DbParameter)val11).Value = model.Files;
			obj[10] = val11;
			OracleParameter val12 = new OracleParameter(":ID", 126);
			((DbParameter)val12).Value = model.ID;
			obj[11] = val12;
			OracleParameter[] parameter = (OracleParameter[])obj;
			return dbHelper.Execute(sql, parameter);
		}

		public int Delete(Guid id)
		{
			//IL_0015: Unknown result type (might be due to invalid IL or missing references)
			//IL_001a: Unknown result type (might be due to invalid IL or missing references)
			//IL_002d: Expected O, but got Unknown
			//IL_002e: Expected O, but got Unknown
			string sql = "DELETE FROM ShortMessage WHERE ID=:ID";
			OracleParameter[] obj = new OracleParameter[1];
			OracleParameter val = new OracleParameter(":ID", 126);
			((DbParameter)val).Value = id.ToString();
			obj[0] = val;
			OracleParameter[] parameter = (OracleParameter[])obj;
			return dbHelper.Execute(sql, parameter);
		}

		private List<RoadFlow.Data.Model.ShortMessage> DataReaderToList(OracleDataReader dataReader)
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
			string sql = "SELECT ID,Title,Contents,SendUserID,SendUserName,ReceiveUserID,ReceiveUserName,SendTime,LinkUrl,LinkID,Type,Files,0 AS Status FROM ShortMessage";
			OracleDataReader dataReader = dbHelper.GetDataReader(sql);
			List<RoadFlow.Data.Model.ShortMessage> result = DataReaderToList(dataReader);
			((DbDataReader)dataReader).Close();
			return result;
		}

		public long GetCount()
		{
			string sql = "SELECT COUNT(*) FROM ShortMessage";
			long result;
			if (!long.TryParse(dbHelper.GetFieldValue(sql), out result))
			{
				return 0L;
			}
			return result;
		}

		public RoadFlow.Data.Model.ShortMessage Get(Guid id)
		{
			//IL_0015: Unknown result type (might be due to invalid IL or missing references)
			//IL_001a: Unknown result type (might be due to invalid IL or missing references)
			//IL_002d: Expected O, but got Unknown
			//IL_002e: Expected O, but got Unknown
			string sql = "SELECT ID,Title,Contents,SendUserID,SendUserName,ReceiveUserID,ReceiveUserName,SendTime,LinkUrl,LinkID,Type,Files,0 AS Status FROM ShortMessage WHERE ID=:ID";
			OracleParameter[] obj = new OracleParameter[1];
			OracleParameter val = new OracleParameter(":ID", 126);
			((DbParameter)val).Value = id.ToString();
			obj[0] = val;
			OracleParameter[] parameter = (OracleParameter[])obj;
			OracleDataReader dataReader = dbHelper.GetDataReader(sql, parameter);
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
			//IL_0015: Unknown result type (might be due to invalid IL or missing references)
			//IL_001a: Unknown result type (might be due to invalid IL or missing references)
			//IL_002d: Expected O, but got Unknown
			//IL_002e: Expected O, but got Unknown
			string sql = "SELECT ID,Title,Contents,SendUserID,SendUserName,ReceiveUserID,ReceiveUserName,SendTime,LinkUrl,LinkID,Type,Files,0 AS Status FROM ShortMessage1 WHERE ID=:ID";
			OracleParameter[] obj = new OracleParameter[1];
			OracleParameter val = new OracleParameter(":ID", 126);
			((DbParameter)val).Value = id.ToString();
			obj[0] = val;
			OracleParameter[] parameter = (OracleParameter[])obj;
			OracleDataReader dataReader = dbHelper.GetDataReader(sql, parameter);
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
			string sql = "SELECT ID,Title,Contents,SendUserID,SendUserName,ReceiveUserID,ReceiveUserName,SendTime,LinkUrl,LinkID,Type,Files,0 AS Status FROM ShortMessage";
			OracleDataReader dataReader = dbHelper.GetDataReader(sql);
			List<RoadFlow.Data.Model.ShortMessage> result = DataReaderToList(dataReader);
			((DbDataReader)dataReader).Close();
			return result;
		}

		public List<RoadFlow.Data.Model.ShortMessage> GetAllNoReadByUserID(Guid userID)
		{
			//IL_0015: Unknown result type (might be due to invalid IL or missing references)
			//IL_001a: Unknown result type (might be due to invalid IL or missing references)
			//IL_002d: Expected O, but got Unknown
			//IL_002e: Expected O, but got Unknown
			string sql = "SELECT ID,Title,Contents,SendUserID,SendUserName,ReceiveUserID,ReceiveUserName,SendTime,LinkUrl,LinkID,Type,Files,0 AS Status FROM ShortMessage WHERE ReceiveUserID=:ReceiveUserID";
			OracleParameter[] obj = new OracleParameter[1];
			OracleParameter val = new OracleParameter(":ReceiveUserID", 126);
			((DbParameter)val).Value = userID.ToString();
			obj[0] = val;
			OracleParameter[] parameter = (OracleParameter[])obj;
			OracleDataReader dataReader = dbHelper.GetDataReader(sql, parameter);
			List<RoadFlow.Data.Model.ShortMessage> result = DataReaderToList(dataReader);
			((DbDataReader)dataReader).Close();
			return result;
		}

		public int UpdateStatus(Guid id)
		{
			//IL_0015: Unknown result type (might be due to invalid IL or missing references)
			//IL_001a: Unknown result type (might be due to invalid IL or missing references)
			//IL_0026: Expected O, but got Unknown
			//IL_0027: Expected O, but got Unknown
			string sql = "BEGIN INSERT INTO ShortMessage1 SELECT * FROM ShortMessage WHERE ID=:ID; DELETE FROM ShortMessage WHERE ID=:ID; END;";
			OracleParameter[] obj = new OracleParameter[1];
			OracleParameter val = new OracleParameter(":ID", 126);
			((DbParameter)val).Value = id;
			obj[0] = val;
			OracleParameter[] parameter = (OracleParameter[])obj;
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
			List<OracleParameter> list = new List<OracleParameter>();
			string value = string.Empty;
			if (status.Length == 1 && status[0] == 0)
			{
				value = "SELECT ID,Title,Contents,SendUserID,SendUserName,ReceiveUserID,ReceiveUserName,SendTime,LinkUrl,LinkID,Type,Files,0 AS Status FROM ShortMessage WHERE 1=1";
			}
			else if (status.Length == 1 && status[0] == 1)
			{
				value = "SELECT ID,Title,Contents,SendUserID,SendUserName,ReceiveUserID,ReceiveUserName,SendTime,LinkUrl,LinkID,Type,Files,1 AS Status FROM ShortMessage1 WHERE 1=1";
			}
			else if (status.Length == 2)
			{
				value = "SELECT * FROM(SELECT ID,Title,Contents,SendUserID,SendUserName,ReceiveUserID,ReceiveUserName,SendTime,LinkUrl,LinkID,Type,Files,0 AS Status FROM ShortMessage WHERE 1=1 UNION ALL SELECT ID,Title,Contents,SendUserID,SendUserName,ReceiveUserID,ReceiveUserName,SendTime,LinkUrl,LinkID,Type,Files,1 AS Status FROM ShortMessage1 WHERE 1=1) temp WHERE 1=1";
			}
			StringBuilder stringBuilder = new StringBuilder(value);
			if (receiveID.IsGuid())
			{
				stringBuilder.Append(" AND ReceiveUserID=:ReceiveUserID");
				list.Add(new OracleParameter(":ReceiveUserID", (object)receiveID));
			}
			if (!title.IsNullOrEmpty())
			{
				stringBuilder.Append(" AND INSTR(Title,:Title,1,1)>0");
				list.Add(new OracleParameter(":Title", (object)title));
			}
			if (!contents.IsNullOrEmpty())
			{
				stringBuilder.Append(" AND INSTR(Contents,:Contents,1,1)>0");
				list.Add(new OracleParameter(":Contents", (object)contents));
			}
			if (!senderID.IsNullOrEmpty())
			{
				stringBuilder.AppendFormat(" AND SendUserID IN({0})", senderID);
			}
			if (date1.IsDateTime())
			{
				stringBuilder.Append(" AND SendTime>=:SendTime");
				list.Add(new OracleParameter(":SendTime", (object)date1.ToDateTime()));
			}
			if (date2.IsDateTime())
			{
				stringBuilder.Append(" AND SendTime<=:SendTime1");
				list.Add(new OracleParameter(":SendTime1", (object)date2.ToDateTime().AddDays(1.0).ToDateString()));
			}
			int pageSize = Tools.GetPageSize();
			int pageNumber = Tools.GetPageNumber();
			long count;
			string paerSql = dbHelper.GetPaerSql(stringBuilder.ToString(), pageSize, pageNumber, out count, list.ToArray());
			pager = Tools.GetPagerHtml(count, pageSize, pageNumber, query);
			OracleDataReader dataReader = dbHelper.GetDataReader(paerSql, list.ToArray());
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
			List<OracleParameter> list = new List<OracleParameter>();
			string value = string.Empty;
			if (status.Length == 1 && status[0] == 0)
			{
				value = "SELECT ID,Title,Contents,SendUserID,SendUserName,ReceiveUserID,ReceiveUserName,SendTime,LinkUrl,LinkID,Type,Files,0 AS Status FROM ShortMessage WHERE 1=1";
			}
			else if (status.Length == 1 && status[0] == 1)
			{
				value = "SELECT ID,Title,Contents,SendUserID,SendUserName,ReceiveUserID,ReceiveUserName,SendTime,LinkUrl,LinkID,Type,Files,1 AS Status FROM ShortMessage1 WHERE 1=1";
			}
			else if (status.Length == 2)
			{
				value = "SELECT * FROM(SELECT ID,Title,Contents,SendUserID,SendUserName,ReceiveUserID,ReceiveUserName,SendTime,LinkUrl,LinkID,Type,Files,0 AS Status FROM ShortMessage WHERE 1=1 UNION ALL SELECT ID,Title,Contents,SendUserID,SendUserName,ReceiveUserID,ReceiveUserName,SendTime,LinkUrl,LinkID,Type,Files,1 AS Status FROM ShortMessage1 WHERE 1=1) temp WHERE 1=1";
			}
			StringBuilder stringBuilder = new StringBuilder(value);
			if (receiveID.IsGuid())
			{
				stringBuilder.Append(" AND ReceiveUserID=:ReceiveUserID");
				list.Add(new OracleParameter(":ReceiveUserID", (object)receiveID));
			}
			if (!title.IsNullOrEmpty())
			{
				stringBuilder.Append(" AND INSTR(Title,:Title,1,1)>0");
				list.Add(new OracleParameter(":Title", (object)title));
			}
			if (!contents.IsNullOrEmpty())
			{
				stringBuilder.Append(" AND INSTR(Contents,:Contents,1,1)>0");
				list.Add(new OracleParameter(":Contents", (object)contents));
			}
			if (!senderID.IsNullOrEmpty())
			{
				stringBuilder.AppendFormat(" AND SendUserID IN({0})", senderID);
			}
			if (date1.IsDateTime())
			{
				stringBuilder.Append(" AND SendTime>=:SendTime");
				list.Add(new OracleParameter(":SendTime", (object)date1.ToDateTime()));
			}
			if (date2.IsDateTime())
			{
				stringBuilder.Append(" AND SendTime<=:SendTime1");
				list.Add(new OracleParameter(":SendTime1", (object)date2.ToDateTime().AddDays(1.0).ToDateString()));
			}
			stringBuilder.Append(" ORDER BY " + (order.IsNullOrEmpty() ? "SendTime DESC" : order));
			string paerSql = dbHelper.GetPaerSql(stringBuilder.ToString(), size, number, out count, list.ToArray());
			OracleDataReader dataReader = dbHelper.GetDataReader(paerSql, list.ToArray());
			List<RoadFlow.Data.Model.ShortMessage> result = DataReaderToList(dataReader);
			((DbDataReader)dataReader).Close();
			return result;
		}

		public int Delete(string linkID, int Type)
		{
			//IL_0015: Unknown result type (might be due to invalid IL or missing references)
			//IL_001a: Unknown result type (might be due to invalid IL or missing references)
			//IL_0021: Expected O, but got Unknown
			//IL_0022: Expected O, but got Unknown
			//IL_002b: Unknown result type (might be due to invalid IL or missing references)
			//IL_0030: Unknown result type (might be due to invalid IL or missing references)
			//IL_003c: Expected O, but got Unknown
			//IL_003d: Expected O, but got Unknown
			string sql = "DELETE FROM ShortMessage WHERE LinkID=:LinkID AND Type=:Type";
			OracleParameter[] obj = new OracleParameter[2];
			OracleParameter val = new OracleParameter(":LinkID", 126);
			((DbParameter)val).Value = linkID;
			obj[0] = val;
			OracleParameter val2 = new OracleParameter(":Type", 112);
			((DbParameter)val2).Value = Type;
			obj[1] = val2;
			OracleParameter[] parameter = (OracleParameter[])obj;
			return dbHelper.Execute(sql, parameter);
		}
	}
}
