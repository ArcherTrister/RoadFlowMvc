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
	public class Documents : IDocuments
	{
		private DBHelper dbHelper = new DBHelper();

		public int Add(RoadFlow.Data.Model.Documents model)
		{
			//IL_001b: Unknown result type (might be due to invalid IL or missing references)
			//IL_0020: Unknown result type (might be due to invalid IL or missing references)
			//IL_0031: Expected O, but got Unknown
			//IL_0032: Expected O, but got Unknown
			//IL_0040: Unknown result type (might be due to invalid IL or missing references)
			//IL_0045: Unknown result type (might be due to invalid IL or missing references)
			//IL_0056: Expected O, but got Unknown
			//IL_0057: Expected O, but got Unknown
			//IL_0068: Unknown result type (might be due to invalid IL or missing references)
			//IL_006d: Unknown result type (might be due to invalid IL or missing references)
			//IL_0079: Expected O, but got Unknown
			//IL_007a: Expected O, but got Unknown
			//IL_0087: Unknown result type (might be due to invalid IL or missing references)
			//IL_008c: Unknown result type (might be due to invalid IL or missing references)
			//IL_0098: Expected O, but got Unknown
			//IL_0099: Expected O, but got Unknown
			//IL_00a7: Unknown result type (might be due to invalid IL or missing references)
			//IL_00ac: Unknown result type (might be due to invalid IL or missing references)
			//IL_00b8: Expected O, but got Unknown
			//IL_00b9: Expected O, but got Unknown
			//IL_00c6: Unknown result type (might be due to invalid IL or missing references)
			//IL_00cb: Unknown result type (might be due to invalid IL or missing references)
			//IL_00d7: Expected O, but got Unknown
			//IL_00d8: Expected O, but got Unknown
			//IL_00ed: Unknown result type (might be due to invalid IL or missing references)
			//IL_00f2: Unknown result type (might be due to invalid IL or missing references)
			//IL_00fe: Expected O, but got Unknown
			//IL_010b: Unknown result type (might be due to invalid IL or missing references)
			//IL_0110: Unknown result type (might be due to invalid IL or missing references)
			//IL_011b: Expected O, but got Unknown
			//IL_011c: Expected O, but got Unknown
			//IL_0126: Unknown result type (might be due to invalid IL or missing references)
			//IL_012b: Unknown result type (might be due to invalid IL or missing references)
			//IL_013c: Expected O, but got Unknown
			//IL_013d: Expected O, but got Unknown
			//IL_014b: Unknown result type (might be due to invalid IL or missing references)
			//IL_0150: Unknown result type (might be due to invalid IL or missing references)
			//IL_0161: Expected O, but got Unknown
			//IL_0162: Expected O, but got Unknown
			//IL_0171: Unknown result type (might be due to invalid IL or missing references)
			//IL_0176: Unknown result type (might be due to invalid IL or missing references)
			//IL_0182: Expected O, but got Unknown
			//IL_0183: Expected O, but got Unknown
			//IL_019e: Unknown result type (might be due to invalid IL or missing references)
			//IL_01a3: Unknown result type (might be due to invalid IL or missing references)
			//IL_01b4: Expected O, but got Unknown
			//IL_01be: Unknown result type (might be due to invalid IL or missing references)
			//IL_01c3: Unknown result type (might be due to invalid IL or missing references)
			//IL_01ce: Expected O, but got Unknown
			//IL_01cf: Expected O, but got Unknown
			//IL_01ee: Unknown result type (might be due to invalid IL or missing references)
			//IL_01f3: Unknown result type (might be due to invalid IL or missing references)
			//IL_0204: Expected O, but got Unknown
			//IL_0212: Unknown result type (might be due to invalid IL or missing references)
			//IL_0217: Unknown result type (might be due to invalid IL or missing references)
			//IL_0222: Expected O, but got Unknown
			//IL_0223: Expected O, but got Unknown
			//IL_023a: Unknown result type (might be due to invalid IL or missing references)
			//IL_023f: Unknown result type (might be due to invalid IL or missing references)
			//IL_024b: Expected O, but got Unknown
			//IL_0259: Unknown result type (might be due to invalid IL or missing references)
			//IL_025e: Unknown result type (might be due to invalid IL or missing references)
			//IL_0269: Expected O, but got Unknown
			//IL_026a: Expected O, but got Unknown
			//IL_0280: Unknown result type (might be due to invalid IL or missing references)
			//IL_0285: Unknown result type (might be due to invalid IL or missing references)
			//IL_0291: Expected O, but got Unknown
			//IL_029e: Unknown result type (might be due to invalid IL or missing references)
			//IL_02a3: Unknown result type (might be due to invalid IL or missing references)
			//IL_02ae: Expected O, but got Unknown
			//IL_02af: Expected O, but got Unknown
			//IL_02ba: Unknown result type (might be due to invalid IL or missing references)
			//IL_02bf: Unknown result type (might be due to invalid IL or missing references)
			//IL_02d0: Expected O, but got Unknown
			//IL_02d1: Expected O, but got Unknown
			string sql = "INSERT INTO documents\r\n\t\t\t\t(ID,DirectoryID,DirectoryName,Title,Source,Contents,Files,WriteTime,WriteUserID,WriteUserName,EditTime,EditUserID,EditUserName,ReadUsers,ReadCount) \r\n\t\t\t\tVALUES(@ID,@DirectoryID,@DirectoryName,@Title,@Source,@Contents,@Files,@WriteTime,@WriteUserID,@WriteUserName,@EditTime,@EditUserID,@EditUserName,@ReadUsers,@ReadCount)";
			MySqlParameter[] obj = new MySqlParameter[15];
			MySqlParameter val = new MySqlParameter("@ID", 253, 36);
			((DbParameter)val).Value = model.ID;
			obj[0] = val;
			MySqlParameter val2 = new MySqlParameter("@DirectoryID", 253, 36);
			((DbParameter)val2).Value = model.DirectoryID;
			obj[1] = val2;
			MySqlParameter val3 = new MySqlParameter("@DirectoryName", 253, 200);
			((DbParameter)val3).Value = model.DirectoryName;
			obj[2] = val3;
			MySqlParameter val4 = new MySqlParameter("@Title", 752, -1);
			((DbParameter)val4).Value = model.Title;
			obj[3] = val4;
			MySqlParameter val5 = new MySqlParameter("@Source", 253, 50);
			((DbParameter)val5).Value = model.Source;
			obj[4] = val5;
			MySqlParameter val6 = new MySqlParameter("@Contents", 751, -1);
			((DbParameter)val6).Value = model.Contents;
			obj[5] = val6;
			_003F val7;
			if (model.Files != null)
			{
				val7 = new MySqlParameter("@Files", 751, -1);
				((DbParameter)val7).Value = model.Files;
			}
			else
			{
				val7 = new MySqlParameter("@Files", 751, -1);
				((DbParameter)val7).Value = DBNull.Value;
			}
			obj[6] = val7;
			MySqlParameter val8 = new MySqlParameter("@WriteTime", 12, -1);
			((DbParameter)val8).Value = model.WriteTime;
			obj[7] = val8;
			MySqlParameter val9 = new MySqlParameter("@WriteUserID", 253, 36);
			((DbParameter)val9).Value = model.WriteUserID;
			obj[8] = val9;
			MySqlParameter val10 = new MySqlParameter("@WriteUserName", 253, 50);
			((DbParameter)val10).Value = model.WriteUserName;
			obj[9] = val10;
			_003F val11;
			if (model.EditTime.HasValue)
			{
				val11 = new MySqlParameter("@EditTime", 12, -1);
				((DbParameter)val11).Value = model.EditTime;
			}
			else
			{
				val11 = new MySqlParameter("@EditTime", 12, -1);
				((DbParameter)val11).Value = DBNull.Value;
			}
			obj[10] = val11;
			_003F val12;
			if (model.EditUserID.HasValue)
			{
				val12 = new MySqlParameter("@EditUserID", 253, 36);
				((DbParameter)val12).Value = model.EditUserID;
			}
			else
			{
				val12 = new MySqlParameter("@EditUserID", 253, 36);
				((DbParameter)val12).Value = DBNull.Value;
			}
			obj[11] = val12;
			_003F val13;
			if (model.EditUserName != null)
			{
				val13 = new MySqlParameter("@EditUserName", 253, 50);
				((DbParameter)val13).Value = model.EditUserName;
			}
			else
			{
				val13 = new MySqlParameter("@EditUserName", 253, 50);
				((DbParameter)val13).Value = DBNull.Value;
			}
			obj[12] = val13;
			_003F val14;
			if (model.ReadUsers != null)
			{
				val14 = new MySqlParameter("@ReadUsers", 751, -1);
				((DbParameter)val14).Value = model.ReadUsers;
			}
			else
			{
				val14 = new MySqlParameter("@ReadUsers", 751, -1);
				((DbParameter)val14).Value = DBNull.Value;
			}
			obj[13] = val14;
			MySqlParameter val15 = new MySqlParameter("@ReadCount", 3, 11);
			((DbParameter)val15).Value = model.ReadCount;
			obj[14] = val15;
			MySqlParameter[] parameter = (MySqlParameter[])obj;
			return dbHelper.Execute(sql, parameter);
		}

		public int Update(RoadFlow.Data.Model.Documents model)
		{
			//IL_001b: Unknown result type (might be due to invalid IL or missing references)
			//IL_0020: Unknown result type (might be due to invalid IL or missing references)
			//IL_0031: Expected O, but got Unknown
			//IL_0032: Expected O, but got Unknown
			//IL_0043: Unknown result type (might be due to invalid IL or missing references)
			//IL_0048: Unknown result type (might be due to invalid IL or missing references)
			//IL_0054: Expected O, but got Unknown
			//IL_0055: Expected O, but got Unknown
			//IL_0062: Unknown result type (might be due to invalid IL or missing references)
			//IL_0067: Unknown result type (might be due to invalid IL or missing references)
			//IL_0073: Expected O, but got Unknown
			//IL_0074: Expected O, but got Unknown
			//IL_0082: Unknown result type (might be due to invalid IL or missing references)
			//IL_0087: Unknown result type (might be due to invalid IL or missing references)
			//IL_0093: Expected O, but got Unknown
			//IL_0094: Expected O, but got Unknown
			//IL_00a1: Unknown result type (might be due to invalid IL or missing references)
			//IL_00a6: Unknown result type (might be due to invalid IL or missing references)
			//IL_00b2: Expected O, but got Unknown
			//IL_00b3: Expected O, but got Unknown
			//IL_00c8: Unknown result type (might be due to invalid IL or missing references)
			//IL_00cd: Unknown result type (might be due to invalid IL or missing references)
			//IL_00d9: Expected O, but got Unknown
			//IL_00e6: Unknown result type (might be due to invalid IL or missing references)
			//IL_00eb: Unknown result type (might be due to invalid IL or missing references)
			//IL_00f6: Expected O, but got Unknown
			//IL_00f7: Expected O, but got Unknown
			//IL_0101: Unknown result type (might be due to invalid IL or missing references)
			//IL_0106: Unknown result type (might be due to invalid IL or missing references)
			//IL_0117: Expected O, but got Unknown
			//IL_0118: Expected O, but got Unknown
			//IL_0126: Unknown result type (might be due to invalid IL or missing references)
			//IL_012b: Unknown result type (might be due to invalid IL or missing references)
			//IL_013c: Expected O, but got Unknown
			//IL_013d: Expected O, but got Unknown
			//IL_014b: Unknown result type (might be due to invalid IL or missing references)
			//IL_0150: Unknown result type (might be due to invalid IL or missing references)
			//IL_015c: Expected O, but got Unknown
			//IL_015d: Expected O, but got Unknown
			//IL_0178: Unknown result type (might be due to invalid IL or missing references)
			//IL_017d: Unknown result type (might be due to invalid IL or missing references)
			//IL_018e: Expected O, but got Unknown
			//IL_0198: Unknown result type (might be due to invalid IL or missing references)
			//IL_019d: Unknown result type (might be due to invalid IL or missing references)
			//IL_01a8: Expected O, but got Unknown
			//IL_01a9: Expected O, but got Unknown
			//IL_01c8: Unknown result type (might be due to invalid IL or missing references)
			//IL_01cd: Unknown result type (might be due to invalid IL or missing references)
			//IL_01de: Expected O, but got Unknown
			//IL_01ec: Unknown result type (might be due to invalid IL or missing references)
			//IL_01f1: Unknown result type (might be due to invalid IL or missing references)
			//IL_01fc: Expected O, but got Unknown
			//IL_01fd: Expected O, but got Unknown
			//IL_0214: Unknown result type (might be due to invalid IL or missing references)
			//IL_0219: Unknown result type (might be due to invalid IL or missing references)
			//IL_0225: Expected O, but got Unknown
			//IL_0233: Unknown result type (might be due to invalid IL or missing references)
			//IL_0238: Unknown result type (might be due to invalid IL or missing references)
			//IL_0243: Expected O, but got Unknown
			//IL_0244: Expected O, but got Unknown
			//IL_025a: Unknown result type (might be due to invalid IL or missing references)
			//IL_025f: Unknown result type (might be due to invalid IL or missing references)
			//IL_026b: Expected O, but got Unknown
			//IL_0278: Unknown result type (might be due to invalid IL or missing references)
			//IL_027d: Unknown result type (might be due to invalid IL or missing references)
			//IL_0288: Expected O, but got Unknown
			//IL_0289: Expected O, but got Unknown
			//IL_0294: Unknown result type (might be due to invalid IL or missing references)
			//IL_0299: Unknown result type (might be due to invalid IL or missing references)
			//IL_02aa: Expected O, but got Unknown
			//IL_02ab: Expected O, but got Unknown
			//IL_02ba: Unknown result type (might be due to invalid IL or missing references)
			//IL_02bf: Unknown result type (might be due to invalid IL or missing references)
			//IL_02d0: Expected O, but got Unknown
			//IL_02d1: Expected O, but got Unknown
			string sql = "UPDATE documents SET \r\n\t\t\t\tDirectoryID=@DirectoryID,DirectoryName=@DirectoryName,Title=@Title,Source=@Source,Contents=@Contents,Files=@Files,WriteTime=@WriteTime,WriteUserID=@WriteUserID,WriteUserName=@WriteUserName,EditTime=@EditTime,EditUserID=@EditUserID,EditUserName=@EditUserName,ReadUsers=@ReadUsers,ReadCount=@ReadCount\r\n\t\t\t\tWHERE ID=@ID";
			MySqlParameter[] obj = new MySqlParameter[15];
			MySqlParameter val = new MySqlParameter("@DirectoryID", 253, 36);
			((DbParameter)val).Value = model.DirectoryID;
			obj[0] = val;
			MySqlParameter val2 = new MySqlParameter("@DirectoryName", 253, 200);
			((DbParameter)val2).Value = model.DirectoryName;
			obj[1] = val2;
			MySqlParameter val3 = new MySqlParameter("@Title", 752, -1);
			((DbParameter)val3).Value = model.Title;
			obj[2] = val3;
			MySqlParameter val4 = new MySqlParameter("@Source", 253, 50);
			((DbParameter)val4).Value = model.Source;
			obj[3] = val4;
			MySqlParameter val5 = new MySqlParameter("@Contents", 751, -1);
			((DbParameter)val5).Value = model.Contents;
			obj[4] = val5;
			_003F val6;
			if (model.Files != null)
			{
				val6 = new MySqlParameter("@Files", 751, -1);
				((DbParameter)val6).Value = model.Files;
			}
			else
			{
				val6 = new MySqlParameter("@Files", 751, -1);
				((DbParameter)val6).Value = DBNull.Value;
			}
			obj[5] = val6;
			MySqlParameter val7 = new MySqlParameter("@WriteTime", 12, -1);
			((DbParameter)val7).Value = model.WriteTime;
			obj[6] = val7;
			MySqlParameter val8 = new MySqlParameter("@WriteUserID", 253, 36);
			((DbParameter)val8).Value = model.WriteUserID;
			obj[7] = val8;
			MySqlParameter val9 = new MySqlParameter("@WriteUserName", 253, 50);
			((DbParameter)val9).Value = model.WriteUserName;
			obj[8] = val9;
			_003F val10;
			if (model.EditTime.HasValue)
			{
				val10 = new MySqlParameter("@EditTime", 12, -1);
				((DbParameter)val10).Value = model.EditTime;
			}
			else
			{
				val10 = new MySqlParameter("@EditTime", 12, -1);
				((DbParameter)val10).Value = DBNull.Value;
			}
			obj[9] = val10;
			_003F val11;
			if (model.EditUserID.HasValue)
			{
				val11 = new MySqlParameter("@EditUserID", 253, 36);
				((DbParameter)val11).Value = model.EditUserID;
			}
			else
			{
				val11 = new MySqlParameter("@EditUserID", 253, 36);
				((DbParameter)val11).Value = DBNull.Value;
			}
			obj[10] = val11;
			_003F val12;
			if (model.EditUserName != null)
			{
				val12 = new MySqlParameter("@EditUserName", 253, 50);
				((DbParameter)val12).Value = model.EditUserName;
			}
			else
			{
				val12 = new MySqlParameter("@EditUserName", 253, 50);
				((DbParameter)val12).Value = DBNull.Value;
			}
			obj[11] = val12;
			_003F val13;
			if (model.ReadUsers != null)
			{
				val13 = new MySqlParameter("@ReadUsers", 751, -1);
				((DbParameter)val13).Value = model.ReadUsers;
			}
			else
			{
				val13 = new MySqlParameter("@ReadUsers", 751, -1);
				((DbParameter)val13).Value = DBNull.Value;
			}
			obj[12] = val13;
			MySqlParameter val14 = new MySqlParameter("@ReadCount", 3, 11);
			((DbParameter)val14).Value = model.ReadCount;
			obj[13] = val14;
			MySqlParameter val15 = new MySqlParameter("@ID", 253, 36);
			((DbParameter)val15).Value = model.ID;
			obj[14] = val15;
			MySqlParameter[] parameter = (MySqlParameter[])obj;
			return dbHelper.Execute(sql, parameter);
		}

		public int Delete(Guid id)
		{
			//IL_001a: Unknown result type (might be due to invalid IL or missing references)
			//IL_001f: Unknown result type (might be due to invalid IL or missing references)
			//IL_0032: Expected O, but got Unknown
			//IL_0033: Expected O, but got Unknown
			string sql = "DELETE FROM documents WHERE ID=@ID";
			MySqlParameter[] obj = new MySqlParameter[1];
			MySqlParameter val = new MySqlParameter("@ID", 253, 36);
			((DbParameter)val).Value = id.ToString();
			obj[0] = val;
			MySqlParameter[] parameter = (MySqlParameter[])obj;
			return dbHelper.Execute(sql, parameter);
		}

		private List<RoadFlow.Data.Model.Documents> DataReaderToList(MySqlDataReader dataReader)
		{
			List<RoadFlow.Data.Model.Documents> list = new List<RoadFlow.Data.Model.Documents>();
			RoadFlow.Data.Model.Documents documents = null;
			while (((DbDataReader)dataReader).Read())
			{
				documents = new RoadFlow.Data.Model.Documents();
				documents.ID = ((DbDataReader)dataReader).GetString(0).ToGuid();
				documents.DirectoryID = ((DbDataReader)dataReader).GetString(1).ToGuid();
				documents.DirectoryName = ((DbDataReader)dataReader).GetString(2);
				documents.Title = ((DbDataReader)dataReader).GetString(3);
				documents.Source = ((DbDataReader)dataReader).GetString(4);
				documents.Contents = ((DbDataReader)dataReader).GetString(5);
				if (!((DbDataReader)dataReader).IsDBNull(6))
				{
					documents.Files = ((DbDataReader)dataReader).GetString(6);
				}
				documents.WriteTime = ((DbDataReader)dataReader).GetDateTime(7);
				documents.WriteUserID = ((DbDataReader)dataReader).GetString(8).ToGuid();
				documents.WriteUserName = ((DbDataReader)dataReader).GetString(9);
				if (!((DbDataReader)dataReader).IsDBNull(10))
				{
					documents.EditTime = ((DbDataReader)dataReader).GetDateTime(10);
				}
				if (!((DbDataReader)dataReader).IsDBNull(11))
				{
					documents.EditUserID = ((DbDataReader)dataReader).GetString(11).ToGuid();
				}
				if (!((DbDataReader)dataReader).IsDBNull(12))
				{
					documents.EditUserName = ((DbDataReader)dataReader).GetString(12);
				}
				if (!((DbDataReader)dataReader).IsDBNull(13))
				{
					documents.ReadUsers = ((DbDataReader)dataReader).GetString(13);
				}
				documents.ReadCount = ((DbDataReader)dataReader).GetInt32(14);
				list.Add(documents);
			}
			return list;
		}

		public List<RoadFlow.Data.Model.Documents> GetAll()
		{
			string sql = "SELECT * FROM documents";
			MySqlDataReader dataReader = dbHelper.GetDataReader(sql);
			List<RoadFlow.Data.Model.Documents> result = DataReaderToList(dataReader);
			((DbDataReader)dataReader).Close();
			return result;
		}

		public long GetCount()
		{
			string sql = "SELECT COUNT(*) FROM documents";
			long result;
			if (!long.TryParse(dbHelper.GetFieldValue(sql), out result))
			{
				return 0L;
			}
			return result;
		}

		public RoadFlow.Data.Model.Documents Get(Guid id)
		{
			//IL_001a: Unknown result type (might be due to invalid IL or missing references)
			//IL_001f: Unknown result type (might be due to invalid IL or missing references)
			//IL_0032: Expected O, but got Unknown
			//IL_0033: Expected O, but got Unknown
			string sql = "SELECT * FROM documents WHERE ID=@ID";
			MySqlParameter[] obj = new MySqlParameter[1];
			MySqlParameter val = new MySqlParameter("@ID", 253, 36);
			((DbParameter)val).Value = id.ToString();
			obj[0] = val;
			MySqlParameter[] parameter = (MySqlParameter[])obj;
			MySqlDataReader dataReader = dbHelper.GetDataReader(sql, parameter);
			List<RoadFlow.Data.Model.Documents> list = DataReaderToList(dataReader);
			((DbDataReader)dataReader).Close();
			if (list.Count <= 0)
			{
				return null;
			}
			return list[0];
		}

		public void UpdateReadCount(Guid id)
		{
			//IL_0018: Unknown result type (might be due to invalid IL or missing references)
			//IL_001d: Unknown result type (might be due to invalid IL or missing references)
			//IL_0029: Expected O, but got Unknown
			//IL_002a: Expected O, but got Unknown
			string sql = "UPDATE Documents SET ReadCount=ReadCount+1 WHERE ID=@ID";
			MySqlParameter[] obj = new MySqlParameter[1];
			MySqlParameter val = new MySqlParameter("@ID", 253);
			((DbParameter)val).Value = id;
			obj[0] = val;
			MySqlParameter[] parameter = (MySqlParameter[])obj;
			dbHelper.Execute(sql, parameter);
		}

		public DataTable GetList(out string pager, string dirID, string userID, string query = "", string title = "", string date1 = "", string date2 = "", bool isNoRead = false)
		{
			//IL_001c: Unknown result type (might be due to invalid IL or missing references)
			//IL_0021: Unknown result type (might be due to invalid IL or missing references)
			//IL_0032: Expected O, but got Unknown
			//IL_0037: Expected O, but got Unknown
			//IL_00aa: Unknown result type (might be due to invalid IL or missing references)
			//IL_00af: Unknown result type (might be due to invalid IL or missing references)
			//IL_00b7: Expected O, but got Unknown
			//IL_00bc: Expected O, but got Unknown
			//IL_00d9: Unknown result type (might be due to invalid IL or missing references)
			//IL_00de: Unknown result type (might be due to invalid IL or missing references)
			//IL_00f9: Expected O, but got Unknown
			//IL_00fe: Expected O, but got Unknown
			//IL_011b: Unknown result type (might be due to invalid IL or missing references)
			//IL_0120: Unknown result type (might be due to invalid IL or missing references)
			//IL_014d: Expected O, but got Unknown
			//IL_0152: Expected O, but got Unknown
			List<MySqlParameter> list = new List<MySqlParameter>();
			StringBuilder stringBuilder = new StringBuilder("SELECT ID,DirectoryID,DirectoryName,Title,WriteTime,WriteUserName,IsRead,ReadCount FROM Documents a LEFT JOIN DocumentsReadUsers b ON a.ID=b.DocumentID WHERE b.UserID=@UserID");
			List<MySqlParameter> list2 = list;
			MySqlParameter val = new MySqlParameter("@UserID", 253);
			((DbParameter)val).Value = userID.ToGuid();
			list2.Add(val);
			if (isNoRead)
			{
				stringBuilder.Append(" AND IsRead=0");
			}
			if (!dirID.IsNullOrEmpty())
			{
				stringBuilder.Append(" AND DirectoryID IN(" + Tools.GetSqlInString(dirID) + ")");
			}
			else
			{
				stringBuilder.Append(isNoRead ? " AND IsRead=0" : " AND 1=0");
			}
			if (!title.IsNullOrEmpty())
			{
				stringBuilder.Append(" AND INSTR(Title,@Title)>0");
				List<MySqlParameter> list3 = list;
				MySqlParameter val2 = new MySqlParameter("@Title", 253);
				((DbParameter)val2).Value = title;
				list3.Add(val2);
			}
			if (date1.IsDateTime())
			{
				stringBuilder.Append(" AND WriteTime>=@WriteTime");
				List<MySqlParameter> list4 = list;
				MySqlParameter val3 = new MySqlParameter("@WriteTime", 12);
				((DbParameter)val3).Value = date1.ToDateTime().Date;
				list4.Add(val3);
			}
			if (date2.IsDateTime())
			{
				stringBuilder.Append(" AND WriteTime<=@WriteTime1");
				List<MySqlParameter> list5 = list;
				MySqlParameter val4 = new MySqlParameter("@WriteTime1", 12);
				((DbParameter)val4).Value = date2.ToDateTime().AddDays(1.0).Date;
				list5.Add(val4);
			}
			stringBuilder.Append(" ORDER BY WriteTime DESC");
			int pageSize = Tools.GetPageSize();
			int pageNumber = Tools.GetPageNumber();
			long count;
			string paerSql = dbHelper.GetPaerSql(stringBuilder.ToString(), pageSize, pageNumber, out count, list.ToArray());
			pager = Tools.GetPagerHtml(count, pageSize, pageNumber, query);
			return dbHelper.GetDataTable(paerSql, list.ToArray());
		}

		public DataTable GetList(out long count, int size, int number, string dirID, string userID, string title = "", string date1 = "", string date2 = "", bool isNoRead = false, string order = "")
		{
			//IL_001c: Unknown result type (might be due to invalid IL or missing references)
			//IL_0021: Unknown result type (might be due to invalid IL or missing references)
			//IL_0033: Expected O, but got Unknown
			//IL_0038: Expected O, but got Unknown
			//IL_00ad: Unknown result type (might be due to invalid IL or missing references)
			//IL_00b2: Unknown result type (might be due to invalid IL or missing references)
			//IL_00ba: Expected O, but got Unknown
			//IL_00bf: Expected O, but got Unknown
			//IL_00dc: Unknown result type (might be due to invalid IL or missing references)
			//IL_00e1: Unknown result type (might be due to invalid IL or missing references)
			//IL_00fb: Expected O, but got Unknown
			//IL_0100: Expected O, but got Unknown
			//IL_011d: Unknown result type (might be due to invalid IL or missing references)
			//IL_0122: Unknown result type (might be due to invalid IL or missing references)
			//IL_014d: Expected O, but got Unknown
			//IL_0152: Expected O, but got Unknown
			List<MySqlParameter> list = new List<MySqlParameter>();
			StringBuilder stringBuilder = new StringBuilder("SELECT ID,DirectoryID,DirectoryName,Title,WriteTime,WriteUserName,IsRead,ReadCount FROM Documents a LEFT JOIN DocumentsReadUsers b ON a.ID=b.DocumentID WHERE b.UserID=@UserID");
			List<MySqlParameter> list2 = list;
			MySqlParameter val = new MySqlParameter("@UserID", 253);
			((DbParameter)val).Value = userID.ToGuid();
			list2.Add(val);
			if (isNoRead)
			{
				stringBuilder.Append(" AND IsRead=0");
			}
			if (!dirID.IsNullOrEmpty())
			{
				stringBuilder.Append(" AND DirectoryID IN(" + Tools.GetSqlInString(dirID) + ")");
			}
			else
			{
				stringBuilder.Append(isNoRead ? " AND IsRead=0" : " AND 1=0");
			}
			if (!title.IsNullOrEmpty())
			{
				stringBuilder.Append(" AND INSTR(Title,@Title)>0");
				List<MySqlParameter> list3 = list;
				MySqlParameter val2 = new MySqlParameter("@Title", 253);
				((DbParameter)val2).Value = title;
				list3.Add(val2);
			}
			if (date1.IsDateTime())
			{
				stringBuilder.Append(" AND WriteTime>=@WriteTime");
				List<MySqlParameter> list4 = list;
				MySqlParameter val3 = new MySqlParameter("@WriteTime", 12);
				((DbParameter)val3).Value = date1.ToDateTime().Date;
				list4.Add(val3);
			}
			if (date2.IsDateTime())
			{
				stringBuilder.Append(" AND WriteTime<=@WriteTime1");
				List<MySqlParameter> list5 = list;
				MySqlParameter val4 = new MySqlParameter("@WriteTime1", 12);
				((DbParameter)val4).Value = date2.ToDateTime().AddDays(1.0).Date;
				list5.Add(val4);
			}
			stringBuilder.Append(" ORDER BY " + (order.IsNullOrEmpty() ? "WriteTime DESC" : order));
			string paerSql = dbHelper.GetPaerSql(stringBuilder.ToString(), size, number, out count, list.ToArray());
			return dbHelper.GetDataTable(paerSql, list.ToArray());
		}

		public int DeleteByDirectoryID(Guid directoryID)
		{
			//IL_0018: Unknown result type (might be due to invalid IL or missing references)
			//IL_001d: Unknown result type (might be due to invalid IL or missing references)
			//IL_0029: Expected O, but got Unknown
			//IL_002a: Expected O, but got Unknown
			string sql = "DELETE FROM Documents WHERE DirectoryID=@DirectoryID";
			MySqlParameter[] obj = new MySqlParameter[1];
			MySqlParameter val = new MySqlParameter("@DirectoryID", 253);
			((DbParameter)val).Value = directoryID;
			obj[0] = val;
			MySqlParameter[] parameter = (MySqlParameter[])obj;
			return dbHelper.Execute(sql, parameter);
		}
	}
}
