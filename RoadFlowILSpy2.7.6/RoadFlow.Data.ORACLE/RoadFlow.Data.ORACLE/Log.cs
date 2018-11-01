using Oracle.ManagedDataAccess.Client;
using RoadFlow.Data.Interface;
using RoadFlow.Data.Model;
using RoadFlow.Utility;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Common;
using System.Text;

namespace RoadFlow.Data.ORACLE
{
	public class Log : ILog
	{
		private DBHelper dbHelper = new DBHelper();

		public int Add(RoadFlow.Data.Model.Log model)
		{
			//IL_0018: Unknown result type (might be due to invalid IL or missing references)
			//IL_001d: Unknown result type (might be due to invalid IL or missing references)
			//IL_002e: Expected O, but got Unknown
			//IL_002f: Expected O, but got Unknown
			//IL_0038: Unknown result type (might be due to invalid IL or missing references)
			//IL_003d: Unknown result type (might be due to invalid IL or missing references)
			//IL_0049: Expected O, but got Unknown
			//IL_004a: Expected O, but got Unknown
			//IL_0055: Unknown result type (might be due to invalid IL or missing references)
			//IL_005a: Unknown result type (might be due to invalid IL or missing references)
			//IL_0066: Expected O, but got Unknown
			//IL_0067: Expected O, but got Unknown
			//IL_0071: Unknown result type (might be due to invalid IL or missing references)
			//IL_0076: Unknown result type (might be due to invalid IL or missing references)
			//IL_0087: Expected O, but got Unknown
			//IL_0088: Expected O, but got Unknown
			//IL_00a3: Unknown result type (might be due to invalid IL or missing references)
			//IL_00a8: Unknown result type (might be due to invalid IL or missing references)
			//IL_00b9: Expected O, but got Unknown
			//IL_00c4: Unknown result type (might be due to invalid IL or missing references)
			//IL_00c9: Unknown result type (might be due to invalid IL or missing references)
			//IL_00d4: Expected O, but got Unknown
			//IL_00d5: Expected O, but got Unknown
			//IL_00e8: Unknown result type (might be due to invalid IL or missing references)
			//IL_00ed: Unknown result type (might be due to invalid IL or missing references)
			//IL_00f9: Expected O, but got Unknown
			//IL_0104: Unknown result type (might be due to invalid IL or missing references)
			//IL_0109: Unknown result type (might be due to invalid IL or missing references)
			//IL_0114: Expected O, but got Unknown
			//IL_0115: Expected O, but got Unknown
			//IL_0128: Unknown result type (might be due to invalid IL or missing references)
			//IL_012d: Unknown result type (might be due to invalid IL or missing references)
			//IL_0139: Expected O, but got Unknown
			//IL_0144: Unknown result type (might be due to invalid IL or missing references)
			//IL_0149: Unknown result type (might be due to invalid IL or missing references)
			//IL_0154: Expected O, but got Unknown
			//IL_0155: Expected O, but got Unknown
			//IL_0166: Unknown result type (might be due to invalid IL or missing references)
			//IL_016b: Unknown result type (might be due to invalid IL or missing references)
			//IL_0177: Expected O, but got Unknown
			//IL_0180: Unknown result type (might be due to invalid IL or missing references)
			//IL_0185: Unknown result type (might be due to invalid IL or missing references)
			//IL_0190: Expected O, but got Unknown
			//IL_0191: Expected O, but got Unknown
			//IL_01a2: Unknown result type (might be due to invalid IL or missing references)
			//IL_01a7: Unknown result type (might be due to invalid IL or missing references)
			//IL_01b3: Expected O, but got Unknown
			//IL_01bc: Unknown result type (might be due to invalid IL or missing references)
			//IL_01c1: Unknown result type (might be due to invalid IL or missing references)
			//IL_01cc: Expected O, but got Unknown
			//IL_01cd: Expected O, but got Unknown
			//IL_01df: Unknown result type (might be due to invalid IL or missing references)
			//IL_01e4: Unknown result type (might be due to invalid IL or missing references)
			//IL_01f0: Expected O, but got Unknown
			//IL_01f9: Unknown result type (might be due to invalid IL or missing references)
			//IL_01fe: Unknown result type (might be due to invalid IL or missing references)
			//IL_0209: Expected O, but got Unknown
			//IL_020a: Expected O, but got Unknown
			//IL_021c: Unknown result type (might be due to invalid IL or missing references)
			//IL_0221: Unknown result type (might be due to invalid IL or missing references)
			//IL_022d: Expected O, but got Unknown
			//IL_0236: Unknown result type (might be due to invalid IL or missing references)
			//IL_023b: Unknown result type (might be due to invalid IL or missing references)
			//IL_0246: Expected O, but got Unknown
			//IL_0247: Expected O, but got Unknown
			//IL_0259: Unknown result type (might be due to invalid IL or missing references)
			//IL_025e: Unknown result type (might be due to invalid IL or missing references)
			//IL_026a: Expected O, but got Unknown
			//IL_0273: Unknown result type (might be due to invalid IL or missing references)
			//IL_0278: Unknown result type (might be due to invalid IL or missing references)
			//IL_0283: Expected O, but got Unknown
			//IL_0284: Expected O, but got Unknown
			string sql = "INSERT INTO Log\r\n\t\t\t\t(ID,Title,Type,WriteTime,UserID,UserName,IPAddress,URL,Contents,Others,OldXml,NewXml) \r\n\t\t\t\tVALUES(:ID,:Title,:Type,:WriteTime,:UserID,:UserName,:IPAddress,:URL,:Contents,:Others,:OldXml,:NewXml)";
			OracleParameter[] obj = new OracleParameter[12];
			OracleParameter val = new OracleParameter(":ID", 126, 40);
			((DbParameter)val).Value = model.ID;
			obj[0] = val;
			OracleParameter val2 = new OracleParameter(":Title", 119);
			((DbParameter)val2).Value = model.Title;
			obj[1] = val2;
			OracleParameter val3 = new OracleParameter(":Type", 119, 100);
			((DbParameter)val3).Value = model.Type;
			obj[2] = val3;
			OracleParameter val4 = new OracleParameter(":WriteTime", 106, 8);
			((DbParameter)val4).Value = model.WriteTime;
			obj[3] = val4;
			_003F val5;
			if (model.UserID.HasValue)
			{
				val5 = new OracleParameter(":UserID", 126, 40);
				((DbParameter)val5).Value = model.UserID;
			}
			else
			{
				val5 = new OracleParameter(":UserID", 126, 40);
				((DbParameter)val5).Value = DBNull.Value;
			}
			obj[4] = val5;
			_003F val6;
			if (model.UserName != null)
			{
				val6 = new OracleParameter(":UserName", 119, 100);
				((DbParameter)val6).Value = model.UserName;
			}
			else
			{
				val6 = new OracleParameter(":UserName", 119, 100);
				((DbParameter)val6).Value = DBNull.Value;
			}
			obj[5] = val6;
			_003F val7;
			if (model.IPAddress != null)
			{
				val7 = new OracleParameter(":IPAddress", 126, 50);
				((DbParameter)val7).Value = model.IPAddress;
			}
			else
			{
				val7 = new OracleParameter(":IPAddress", 126, 50);
				((DbParameter)val7).Value = DBNull.Value;
			}
			obj[6] = val7;
			_003F val8;
			if (model.URL != null)
			{
				val8 = new OracleParameter(":URL", 105);
				((DbParameter)val8).Value = model.URL;
			}
			else
			{
				val8 = new OracleParameter(":URL", 105);
				((DbParameter)val8).Value = DBNull.Value;
			}
			obj[7] = val8;
			_003F val9;
			if (model.Contents != null)
			{
				val9 = new OracleParameter(":Contents", 105);
				((DbParameter)val9).Value = model.Contents;
			}
			else
			{
				val9 = new OracleParameter(":Contents", 105);
				((DbParameter)val9).Value = DBNull.Value;
			}
			obj[8] = val9;
			_003F val10;
			if (model.Others != null)
			{
				val10 = new OracleParameter(":Others", 105);
				((DbParameter)val10).Value = model.Others;
			}
			else
			{
				val10 = new OracleParameter(":Others", 105);
				((DbParameter)val10).Value = DBNull.Value;
			}
			obj[9] = val10;
			_003F val11;
			if (model.OldXml != null)
			{
				val11 = new OracleParameter(":OldXml", 105);
				((DbParameter)val11).Value = model.OldXml;
			}
			else
			{
				val11 = new OracleParameter(":OldXml", 105);
				((DbParameter)val11).Value = DBNull.Value;
			}
			obj[10] = val11;
			_003F val12;
			if (model.NewXml != null)
			{
				val12 = new OracleParameter(":NewXml", 105);
				((DbParameter)val12).Value = model.NewXml;
			}
			else
			{
				val12 = new OracleParameter(":NewXml", 105);
				((DbParameter)val12).Value = DBNull.Value;
			}
			obj[11] = val12;
			OracleParameter[] parameter = (OracleParameter[])obj;
			return dbHelper.Execute(sql, parameter);
		}

		public int Update(RoadFlow.Data.Model.Log model)
		{
			//IL_0016: Unknown result type (might be due to invalid IL or missing references)
			//IL_001b: Unknown result type (might be due to invalid IL or missing references)
			//IL_0027: Expected O, but got Unknown
			//IL_0028: Expected O, but got Unknown
			//IL_0033: Unknown result type (might be due to invalid IL or missing references)
			//IL_0038: Unknown result type (might be due to invalid IL or missing references)
			//IL_0044: Expected O, but got Unknown
			//IL_0045: Expected O, but got Unknown
			//IL_004f: Unknown result type (might be due to invalid IL or missing references)
			//IL_0054: Unknown result type (might be due to invalid IL or missing references)
			//IL_0065: Expected O, but got Unknown
			//IL_0066: Expected O, but got Unknown
			//IL_0081: Unknown result type (might be due to invalid IL or missing references)
			//IL_0086: Unknown result type (might be due to invalid IL or missing references)
			//IL_0097: Expected O, but got Unknown
			//IL_00a2: Unknown result type (might be due to invalid IL or missing references)
			//IL_00a7: Unknown result type (might be due to invalid IL or missing references)
			//IL_00b2: Expected O, but got Unknown
			//IL_00b3: Expected O, but got Unknown
			//IL_00c6: Unknown result type (might be due to invalid IL or missing references)
			//IL_00cb: Unknown result type (might be due to invalid IL or missing references)
			//IL_00d7: Expected O, but got Unknown
			//IL_00e2: Unknown result type (might be due to invalid IL or missing references)
			//IL_00e7: Unknown result type (might be due to invalid IL or missing references)
			//IL_00f2: Expected O, but got Unknown
			//IL_00f3: Expected O, but got Unknown
			//IL_0106: Unknown result type (might be due to invalid IL or missing references)
			//IL_010b: Unknown result type (might be due to invalid IL or missing references)
			//IL_0117: Expected O, but got Unknown
			//IL_0122: Unknown result type (might be due to invalid IL or missing references)
			//IL_0127: Unknown result type (might be due to invalid IL or missing references)
			//IL_0132: Expected O, but got Unknown
			//IL_0133: Expected O, but got Unknown
			//IL_0144: Unknown result type (might be due to invalid IL or missing references)
			//IL_0149: Unknown result type (might be due to invalid IL or missing references)
			//IL_0155: Expected O, but got Unknown
			//IL_015e: Unknown result type (might be due to invalid IL or missing references)
			//IL_0163: Unknown result type (might be due to invalid IL or missing references)
			//IL_016e: Expected O, but got Unknown
			//IL_016f: Expected O, but got Unknown
			//IL_0180: Unknown result type (might be due to invalid IL or missing references)
			//IL_0185: Unknown result type (might be due to invalid IL or missing references)
			//IL_0191: Expected O, but got Unknown
			//IL_019a: Unknown result type (might be due to invalid IL or missing references)
			//IL_019f: Unknown result type (might be due to invalid IL or missing references)
			//IL_01aa: Expected O, but got Unknown
			//IL_01ab: Expected O, but got Unknown
			//IL_01bc: Unknown result type (might be due to invalid IL or missing references)
			//IL_01c1: Unknown result type (might be due to invalid IL or missing references)
			//IL_01cd: Expected O, but got Unknown
			//IL_01d6: Unknown result type (might be due to invalid IL or missing references)
			//IL_01db: Unknown result type (might be due to invalid IL or missing references)
			//IL_01e6: Expected O, but got Unknown
			//IL_01e7: Expected O, but got Unknown
			//IL_01f9: Unknown result type (might be due to invalid IL or missing references)
			//IL_01fe: Unknown result type (might be due to invalid IL or missing references)
			//IL_020a: Expected O, but got Unknown
			//IL_0213: Unknown result type (might be due to invalid IL or missing references)
			//IL_0218: Unknown result type (might be due to invalid IL or missing references)
			//IL_0223: Expected O, but got Unknown
			//IL_0224: Expected O, but got Unknown
			//IL_0236: Unknown result type (might be due to invalid IL or missing references)
			//IL_023b: Unknown result type (might be due to invalid IL or missing references)
			//IL_0247: Expected O, but got Unknown
			//IL_0250: Unknown result type (might be due to invalid IL or missing references)
			//IL_0255: Unknown result type (might be due to invalid IL or missing references)
			//IL_0260: Expected O, but got Unknown
			//IL_0261: Expected O, but got Unknown
			//IL_026d: Unknown result type (might be due to invalid IL or missing references)
			//IL_0272: Unknown result type (might be due to invalid IL or missing references)
			//IL_0283: Expected O, but got Unknown
			//IL_0284: Expected O, but got Unknown
			string sql = "UPDATE Log SET \r\n\t\t\t\tTitle=:Title,Type=:Type,WriteTime=:WriteTime,UserID=:UserID,UserName=:UserName,IPAddress=:IPAddress,URL=:URL,Contents=:Contents,Others=:Others,OldXml=:OldXml,NewXml=:NewXml\r\n\t\t\t\tWHERE ID=:ID";
			OracleParameter[] obj = new OracleParameter[12];
			OracleParameter val = new OracleParameter(":Title", 119);
			((DbParameter)val).Value = model.Title;
			obj[0] = val;
			OracleParameter val2 = new OracleParameter(":Type", 119, 100);
			((DbParameter)val2).Value = model.Type;
			obj[1] = val2;
			OracleParameter val3 = new OracleParameter(":WriteTime", 106, 8);
			((DbParameter)val3).Value = model.WriteTime;
			obj[2] = val3;
			_003F val4;
			if (model.UserID.HasValue)
			{
				val4 = new OracleParameter(":UserID", 126, 40);
				((DbParameter)val4).Value = model.UserID;
			}
			else
			{
				val4 = new OracleParameter(":UserID", 126, 40);
				((DbParameter)val4).Value = DBNull.Value;
			}
			obj[3] = val4;
			_003F val5;
			if (model.UserName != null)
			{
				val5 = new OracleParameter(":UserName", 119, 100);
				((DbParameter)val5).Value = model.UserName;
			}
			else
			{
				val5 = new OracleParameter(":UserName", 119, 100);
				((DbParameter)val5).Value = DBNull.Value;
			}
			obj[4] = val5;
			_003F val6;
			if (model.IPAddress != null)
			{
				val6 = new OracleParameter(":IPAddress", 126, 50);
				((DbParameter)val6).Value = model.IPAddress;
			}
			else
			{
				val6 = new OracleParameter(":IPAddress", 126, 50);
				((DbParameter)val6).Value = DBNull.Value;
			}
			obj[5] = val6;
			_003F val7;
			if (model.URL != null)
			{
				val7 = new OracleParameter(":URL", 105);
				((DbParameter)val7).Value = model.URL;
			}
			else
			{
				val7 = new OracleParameter(":URL", 105);
				((DbParameter)val7).Value = DBNull.Value;
			}
			obj[6] = val7;
			_003F val8;
			if (model.Contents != null)
			{
				val8 = new OracleParameter(":Contents", 105);
				((DbParameter)val8).Value = model.Contents;
			}
			else
			{
				val8 = new OracleParameter(":Contents", 105);
				((DbParameter)val8).Value = DBNull.Value;
			}
			obj[7] = val8;
			_003F val9;
			if (model.Others != null)
			{
				val9 = new OracleParameter(":Others", 105);
				((DbParameter)val9).Value = model.Others;
			}
			else
			{
				val9 = new OracleParameter(":Others", 105);
				((DbParameter)val9).Value = DBNull.Value;
			}
			obj[8] = val9;
			_003F val10;
			if (model.OldXml != null)
			{
				val10 = new OracleParameter(":OldXml", 105);
				((DbParameter)val10).Value = model.OldXml;
			}
			else
			{
				val10 = new OracleParameter(":OldXml", 105);
				((DbParameter)val10).Value = DBNull.Value;
			}
			obj[9] = val10;
			_003F val11;
			if (model.NewXml != null)
			{
				val11 = new OracleParameter(":NewXml", 105);
				((DbParameter)val11).Value = model.NewXml;
			}
			else
			{
				val11 = new OracleParameter(":NewXml", 105);
				((DbParameter)val11).Value = DBNull.Value;
			}
			obj[10] = val11;
			OracleParameter val12 = new OracleParameter(":ID", 126, 40);
			((DbParameter)val12).Value = model.ID;
			obj[11] = val12;
			OracleParameter[] parameter = (OracleParameter[])obj;
			return dbHelper.Execute(sql, parameter);
		}

		public int Delete(Guid id)
		{
			//IL_0015: Unknown result type (might be due to invalid IL or missing references)
			//IL_001a: Unknown result type (might be due to invalid IL or missing references)
			//IL_0026: Expected O, but got Unknown
			//IL_0027: Expected O, but got Unknown
			string sql = "DELETE FROM Log WHERE ID=:ID";
			OracleParameter[] obj = new OracleParameter[1];
			OracleParameter val = new OracleParameter(":ID", 126);
			((DbParameter)val).Value = id;
			obj[0] = val;
			OracleParameter[] parameter = (OracleParameter[])obj;
			return dbHelper.Execute(sql, parameter);
		}

		private List<RoadFlow.Data.Model.Log> DataReaderToList(OracleDataReader dataReader)
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
			string sql = "SELECT * FROM Log";
			OracleDataReader dataReader = dbHelper.GetDataReader(sql);
			List<RoadFlow.Data.Model.Log> result = DataReaderToList(dataReader);
			((DbDataReader)dataReader).Close();
			return result;
		}

		public long GetCount()
		{
			string sql = "SELECT COUNT(*) FROM Log";
			long result;
			if (!long.TryParse(dbHelper.GetFieldValue(sql), out result))
			{
				return 0L;
			}
			return result;
		}

		public RoadFlow.Data.Model.Log Get(Guid id)
		{
			//IL_0015: Unknown result type (might be due to invalid IL or missing references)
			//IL_001a: Unknown result type (might be due to invalid IL or missing references)
			//IL_0026: Expected O, but got Unknown
			//IL_0027: Expected O, but got Unknown
			string sql = "SELECT * FROM Log WHERE ID=:ID";
			OracleParameter[] obj = new OracleParameter[1];
			OracleParameter val = new OracleParameter(":ID", 126);
			((DbParameter)val).Value = id;
			obj[0] = val;
			OracleParameter[] parameter = (OracleParameter[])obj;
			OracleDataReader dataReader = dbHelper.GetDataReader(sql, parameter);
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
			//IL_0029: Unknown result type (might be due to invalid IL or missing references)
			//IL_002e: Unknown result type (might be due to invalid IL or missing references)
			//IL_0036: Expected O, but got Unknown
			//IL_003b: Expected O, but got Unknown
			//IL_0058: Unknown result type (might be due to invalid IL or missing references)
			//IL_005d: Unknown result type (might be due to invalid IL or missing references)
			//IL_0065: Expected O, but got Unknown
			//IL_006a: Expected O, but got Unknown
			//IL_0087: Unknown result type (might be due to invalid IL or missing references)
			//IL_008c: Unknown result type (might be due to invalid IL or missing references)
			//IL_00b1: Expected O, but got Unknown
			//IL_00b6: Expected O, but got Unknown
			//IL_00d3: Unknown result type (might be due to invalid IL or missing references)
			//IL_00d8: Unknown result type (might be due to invalid IL or missing references)
			//IL_010f: Expected O, but got Unknown
			//IL_0114: Expected O, but got Unknown
			//IL_0131: Unknown result type (might be due to invalid IL or missing references)
			//IL_0136: Unknown result type (might be due to invalid IL or missing references)
			//IL_0148: Expected O, but got Unknown
			//IL_014d: Expected O, but got Unknown
			StringBuilder stringBuilder = new StringBuilder();
			List<OracleParameter> list = new List<OracleParameter>();
			if (!title.IsNullOrEmpty())
			{
				stringBuilder.Append("AND INSTR(Title,:Title,1,1)>0 ");
				List<OracleParameter> list2 = list;
				OracleParameter val = new OracleParameter(":Title", 119);
				((DbParameter)val).Value = title;
				list2.Add(val);
			}
			if (!type.IsNullOrEmpty())
			{
				stringBuilder.Append("AND Type=:Type ");
				List<OracleParameter> list3 = list;
				OracleParameter val2 = new OracleParameter(":Type", 119);
				((DbParameter)val2).Value = type;
				list3.Add(val2);
			}
			if (date1.IsDateTime())
			{
				stringBuilder.Append("AND WriteTime>=:Date1 ");
				List<OracleParameter> list4 = list;
				OracleParameter val3 = new OracleParameter(":Date1", 106);
				((DbParameter)val3).Value = date1.ToDateTime().ToString("yyyy-MM-dd 00:00:00").ToDateTime();
				list4.Add(val3);
			}
			if (date2.IsDateTime())
			{
				stringBuilder.Append("AND WriteTime<=:Date2 ");
				List<OracleParameter> list5 = list;
				OracleParameter val4 = new OracleParameter(":Date2", 106);
				((DbParameter)val4).Value = date2.ToDateTime().AddDays(1.0).ToString("yyyy-MM-dd 00:00:00")
					.ToDateTime();
				list5.Add(val4);
			}
			if (userID.IsGuid())
			{
				stringBuilder.Append("AND UserID=:UserID ");
				List<OracleParameter> list6 = list;
				OracleParameter val5 = new OracleParameter(":UserID", 126);
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
			//IL_0029: Unknown result type (might be due to invalid IL or missing references)
			//IL_002e: Unknown result type (might be due to invalid IL or missing references)
			//IL_0036: Expected O, but got Unknown
			//IL_003b: Expected O, but got Unknown
			//IL_0058: Unknown result type (might be due to invalid IL or missing references)
			//IL_005d: Unknown result type (might be due to invalid IL or missing references)
			//IL_0065: Expected O, but got Unknown
			//IL_006a: Expected O, but got Unknown
			//IL_0087: Unknown result type (might be due to invalid IL or missing references)
			//IL_008c: Unknown result type (might be due to invalid IL or missing references)
			//IL_00b0: Expected O, but got Unknown
			//IL_00b5: Expected O, but got Unknown
			//IL_00d2: Unknown result type (might be due to invalid IL or missing references)
			//IL_00d7: Unknown result type (might be due to invalid IL or missing references)
			//IL_010c: Expected O, but got Unknown
			//IL_0111: Expected O, but got Unknown
			//IL_012e: Unknown result type (might be due to invalid IL or missing references)
			//IL_0133: Unknown result type (might be due to invalid IL or missing references)
			//IL_013b: Expected O, but got Unknown
			//IL_0140: Expected O, but got Unknown
			StringBuilder stringBuilder = new StringBuilder();
			List<OracleParameter> list = new List<OracleParameter>();
			if (!title.IsNullOrEmpty())
			{
				stringBuilder.Append("AND INSTR(Title,:Title,1,1)>0 ");
				List<OracleParameter> list2 = list;
				OracleParameter val = new OracleParameter(":Title", 119);
				((DbParameter)val).Value = title;
				list2.Add(val);
			}
			if (!type.IsNullOrEmpty())
			{
				stringBuilder.Append("AND Type=:Type ");
				List<OracleParameter> list3 = list;
				OracleParameter val2 = new OracleParameter(":Type", 119);
				((DbParameter)val2).Value = type;
				list3.Add(val2);
			}
			if (date1.IsDateTime())
			{
				stringBuilder.Append("AND WriteTime>=:Date1 ");
				List<OracleParameter> list4 = list;
				OracleParameter val3 = new OracleParameter(":Date1", 106);
				((DbParameter)val3).Value = date1.ToDateTime().ToString("yyyy-MM-dd 00:00:00").ToDateTime();
				list4.Add(val3);
			}
			if (date2.IsDateTime())
			{
				stringBuilder.Append("AND WriteTime<=:Date2 ");
				List<OracleParameter> list5 = list;
				OracleParameter val4 = new OracleParameter(":Date2", 106);
				((DbParameter)val4).Value = date2.ToDateTime().AddDays(1.0).ToString("yyyy-MM-dd 00:00:00")
					.ToDateTime();
				list5.Add(val4);
			}
			if (userID.IsGuid())
			{
				stringBuilder.Append("AND UserID=:UserID ");
				List<OracleParameter> list6 = list;
				OracleParameter val5 = new OracleParameter(":UserID", 126);
				((DbParameter)val5).Value = userID;
				list6.Add(val5);
			}
			string paerSql = dbHelper.GetPaerSql("Log", "ID,Title,Type,WriteTime,UserName,IPAddress", stringBuilder.ToString(), order.IsNullOrEmpty() ? "WriteTime DESC" : order, size, number, out count, list.ToArray());
			return dbHelper.GetDataTable(paerSql.ToString(), list.ToArray());
		}
	}
}
