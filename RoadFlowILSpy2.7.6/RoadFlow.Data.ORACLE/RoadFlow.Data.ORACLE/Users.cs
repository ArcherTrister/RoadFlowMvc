using Oracle.ManagedDataAccess.Client;
using RoadFlow.Data.Interface;
using RoadFlow.Data.Model;
using RoadFlow.Utility;
using System;
using System.Collections.Generic;
using System.Data.Common;

namespace RoadFlow.Data.ORACLE
{
	public class Users : IUsers
	{
		private DBHelper dbHelper = new DBHelper();

		public int Add(RoadFlow.Data.Model.Users model)
		{
			//IL_0018: Unknown result type (might be due to invalid IL or missing references)
			//IL_001d: Unknown result type (might be due to invalid IL or missing references)
			//IL_002e: Expected O, but got Unknown
			//IL_002f: Expected O, but got Unknown
			//IL_003a: Unknown result type (might be due to invalid IL or missing references)
			//IL_003f: Unknown result type (might be due to invalid IL or missing references)
			//IL_004b: Expected O, but got Unknown
			//IL_004c: Expected O, but got Unknown
			//IL_005a: Unknown result type (might be due to invalid IL or missing references)
			//IL_005f: Unknown result type (might be due to invalid IL or missing references)
			//IL_006b: Expected O, but got Unknown
			//IL_006c: Expected O, but got Unknown
			//IL_007a: Unknown result type (might be due to invalid IL or missing references)
			//IL_007f: Unknown result type (might be due to invalid IL or missing references)
			//IL_008b: Expected O, but got Unknown
			//IL_008c: Expected O, but got Unknown
			//IL_0095: Unknown result type (might be due to invalid IL or missing references)
			//IL_009a: Unknown result type (might be due to invalid IL or missing references)
			//IL_00ab: Expected O, but got Unknown
			//IL_00ac: Expected O, but got Unknown
			//IL_00b5: Unknown result type (might be due to invalid IL or missing references)
			//IL_00ba: Unknown result type (might be due to invalid IL or missing references)
			//IL_00cb: Expected O, but got Unknown
			//IL_00cc: Expected O, but got Unknown
			//IL_00dd: Unknown result type (might be due to invalid IL or missing references)
			//IL_00e2: Unknown result type (might be due to invalid IL or missing references)
			//IL_00ee: Expected O, but got Unknown
			//IL_00f7: Unknown result type (might be due to invalid IL or missing references)
			//IL_00fc: Unknown result type (might be due to invalid IL or missing references)
			//IL_0107: Expected O, but got Unknown
			//IL_0108: Expected O, but got Unknown
			//IL_011b: Unknown result type (might be due to invalid IL or missing references)
			//IL_0120: Unknown result type (might be due to invalid IL or missing references)
			//IL_012c: Expected O, but got Unknown
			//IL_0137: Unknown result type (might be due to invalid IL or missing references)
			//IL_013c: Unknown result type (might be due to invalid IL or missing references)
			//IL_0147: Expected O, but got Unknown
			//IL_0148: Expected O, but got Unknown
			//IL_015e: Unknown result type (might be due to invalid IL or missing references)
			//IL_0163: Unknown result type (might be due to invalid IL or missing references)
			//IL_016f: Expected O, but got Unknown
			//IL_017d: Unknown result type (might be due to invalid IL or missing references)
			//IL_0182: Unknown result type (might be due to invalid IL or missing references)
			//IL_018d: Expected O, but got Unknown
			//IL_018e: Expected O, but got Unknown
			//IL_01a5: Unknown result type (might be due to invalid IL or missing references)
			//IL_01aa: Unknown result type (might be due to invalid IL or missing references)
			//IL_01b6: Expected O, but got Unknown
			//IL_01c4: Unknown result type (might be due to invalid IL or missing references)
			//IL_01c9: Unknown result type (might be due to invalid IL or missing references)
			//IL_01d4: Expected O, but got Unknown
			//IL_01d5: Expected O, but got Unknown
			//IL_01e9: Unknown result type (might be due to invalid IL or missing references)
			//IL_01ee: Unknown result type (might be due to invalid IL or missing references)
			//IL_01fa: Expected O, but got Unknown
			//IL_0205: Unknown result type (might be due to invalid IL or missing references)
			//IL_020a: Unknown result type (might be due to invalid IL or missing references)
			//IL_0215: Expected O, but got Unknown
			//IL_0216: Expected O, but got Unknown
			//IL_022d: Unknown result type (might be due to invalid IL or missing references)
			//IL_0232: Unknown result type (might be due to invalid IL or missing references)
			//IL_023e: Expected O, but got Unknown
			//IL_024c: Unknown result type (might be due to invalid IL or missing references)
			//IL_0251: Unknown result type (might be due to invalid IL or missing references)
			//IL_025c: Expected O, but got Unknown
			//IL_025d: Expected O, but got Unknown
			//IL_0271: Unknown result type (might be due to invalid IL or missing references)
			//IL_0276: Unknown result type (might be due to invalid IL or missing references)
			//IL_0282: Expected O, but got Unknown
			//IL_028d: Unknown result type (might be due to invalid IL or missing references)
			//IL_0292: Unknown result type (might be due to invalid IL or missing references)
			//IL_029d: Expected O, but got Unknown
			//IL_029e: Expected O, but got Unknown
			//IL_02b5: Unknown result type (might be due to invalid IL or missing references)
			//IL_02ba: Unknown result type (might be due to invalid IL or missing references)
			//IL_02c6: Expected O, but got Unknown
			//IL_02d4: Unknown result type (might be due to invalid IL or missing references)
			//IL_02d9: Unknown result type (might be due to invalid IL or missing references)
			//IL_02e4: Expected O, but got Unknown
			//IL_02e5: Expected O, but got Unknown
			//IL_02f9: Unknown result type (might be due to invalid IL or missing references)
			//IL_02fe: Unknown result type (might be due to invalid IL or missing references)
			//IL_030a: Expected O, but got Unknown
			//IL_0315: Unknown result type (might be due to invalid IL or missing references)
			//IL_031a: Unknown result type (might be due to invalid IL or missing references)
			//IL_0325: Expected O, but got Unknown
			//IL_0326: Expected O, but got Unknown
			//IL_0342: Unknown result type (might be due to invalid IL or missing references)
			//IL_0347: Unknown result type (might be due to invalid IL or missing references)
			//IL_0360: Expected O, but got Unknown
			//IL_0369: Unknown result type (might be due to invalid IL or missing references)
			//IL_036e: Unknown result type (might be due to invalid IL or missing references)
			//IL_0379: Expected O, but got Unknown
			//IL_037a: Expected O, but got Unknown
			string sql = "INSERT INTO Users\r\n\t\t\t\t(ID,Name,Account,Password,Status,Sort,Note,Mobile,Tel,OtherTel,Fax,Email,QQ,HeadImg,WeiXin,Sex) \r\n\t\t\t\tVALUES(:ID,:Name,:Account,:Password,:Status,:Sort,:Note,:Mobile,:Tel,:OtherTel,:Fax,:Email,:QQ,:HeadImg,:WeiXin,:Sex)";
			OracleParameter[] obj = new OracleParameter[16];
			OracleParameter val = new OracleParameter(":ID", 126, 40);
			((DbParameter)val).Value = model.ID;
			obj[0] = val;
			OracleParameter val2 = new OracleParameter(":Name", 119, 100);
			((DbParameter)val2).Value = model.Name;
			obj[1] = val2;
			OracleParameter val3 = new OracleParameter(":Account", 126, 255);
			((DbParameter)val3).Value = model.Account;
			obj[2] = val3;
			OracleParameter val4 = new OracleParameter(":Password", 126, 500);
			((DbParameter)val4).Value = model.Password;
			obj[3] = val4;
			OracleParameter val5 = new OracleParameter(":Status", 112);
			((DbParameter)val5).Value = model.Status;
			obj[4] = val5;
			OracleParameter val6 = new OracleParameter(":Sort", 112);
			((DbParameter)val6).Value = model.Sort;
			obj[5] = val6;
			_003F val7;
			if (model.Note != null)
			{
				val7 = new OracleParameter(":Note", 119);
				((DbParameter)val7).Value = model.Note;
			}
			else
			{
				val7 = new OracleParameter(":Note", 119);
				((DbParameter)val7).Value = DBNull.Value;
			}
			obj[6] = val7;
			_003F val8;
			if (model.Mobile != null)
			{
				val8 = new OracleParameter("@Mobile", 119, 50);
				((DbParameter)val8).Value = model.Mobile;
			}
			else
			{
				val8 = new OracleParameter("@Mobile", 119, 50);
				((DbParameter)val8).Value = DBNull.Value;
			}
			obj[7] = val8;
			_003F val9;
			if (model.Tel != null)
			{
				val9 = new OracleParameter("@Tel", 119, 500);
				((DbParameter)val9).Value = model.Tel;
			}
			else
			{
				val9 = new OracleParameter("@Tel", 119, 500);
				((DbParameter)val9).Value = DBNull.Value;
			}
			obj[8] = val9;
			_003F val10;
			if (model.OtherTel != null)
			{
				val10 = new OracleParameter("@OtherTel", 119, 500);
				((DbParameter)val10).Value = model.OtherTel;
			}
			else
			{
				val10 = new OracleParameter("@OtherTel", 119, 500);
				((DbParameter)val10).Value = DBNull.Value;
			}
			obj[9] = val10;
			_003F val11;
			if (model.Fax != null)
			{
				val11 = new OracleParameter("@Fax", 119, 50);
				((DbParameter)val11).Value = model.Fax;
			}
			else
			{
				val11 = new OracleParameter("@Fax", 119, 50);
				((DbParameter)val11).Value = DBNull.Value;
			}
			obj[10] = val11;
			_003F val12;
			if (model.Email != null)
			{
				val12 = new OracleParameter("@Email", 119, 500);
				((DbParameter)val12).Value = model.Email;
			}
			else
			{
				val12 = new OracleParameter("@Email", 119, 500);
				((DbParameter)val12).Value = DBNull.Value;
			}
			obj[11] = val12;
			_003F val13;
			if (model.QQ != null)
			{
				val13 = new OracleParameter("@QQ", 119, 50);
				((DbParameter)val13).Value = model.QQ;
			}
			else
			{
				val13 = new OracleParameter("@QQ", 119, 50);
				((DbParameter)val13).Value = DBNull.Value;
			}
			obj[12] = val13;
			_003F val14;
			if (model.HeadImg != null)
			{
				val14 = new OracleParameter("@HeadImg", 119, 500);
				((DbParameter)val14).Value = model.HeadImg;
			}
			else
			{
				val14 = new OracleParameter("@HeadImg", 119, 500);
				((DbParameter)val14).Value = DBNull.Value;
			}
			obj[13] = val14;
			_003F val15;
			if (model.WeiXin != null)
			{
				val15 = new OracleParameter("@WeiXin", 119, 50);
				((DbParameter)val15).Value = model.WeiXin;
			}
			else
			{
				val15 = new OracleParameter("@WeiXin", 119, 50);
				((DbParameter)val15).Value = DBNull.Value;
			}
			obj[14] = val15;
			_003F val16;
			if (model.Sex.HasValue)
			{
				val16 = new OracleParameter("@Sex", 112, 11);
				((DbParameter)val16).Value = model.Sex.Value;
			}
			else
			{
				val16 = new OracleParameter("@Sex", 112);
				((DbParameter)val16).Value = DBNull.Value;
			}
			obj[15] = val16;
			OracleParameter[] parameter = (OracleParameter[])obj;
			return dbHelper.Execute(sql, parameter);
		}

		public int Update(RoadFlow.Data.Model.Users model)
		{
			//IL_0018: Unknown result type (might be due to invalid IL or missing references)
			//IL_001d: Unknown result type (might be due to invalid IL or missing references)
			//IL_0029: Expected O, but got Unknown
			//IL_002a: Expected O, but got Unknown
			//IL_0038: Unknown result type (might be due to invalid IL or missing references)
			//IL_003d: Unknown result type (might be due to invalid IL or missing references)
			//IL_0049: Expected O, but got Unknown
			//IL_004a: Expected O, but got Unknown
			//IL_0058: Unknown result type (might be due to invalid IL or missing references)
			//IL_005d: Unknown result type (might be due to invalid IL or missing references)
			//IL_0069: Expected O, but got Unknown
			//IL_006a: Expected O, but got Unknown
			//IL_0073: Unknown result type (might be due to invalid IL or missing references)
			//IL_0078: Unknown result type (might be due to invalid IL or missing references)
			//IL_0089: Expected O, but got Unknown
			//IL_008a: Expected O, but got Unknown
			//IL_0093: Unknown result type (might be due to invalid IL or missing references)
			//IL_0098: Unknown result type (might be due to invalid IL or missing references)
			//IL_00a9: Expected O, but got Unknown
			//IL_00aa: Expected O, but got Unknown
			//IL_00bb: Unknown result type (might be due to invalid IL or missing references)
			//IL_00c0: Unknown result type (might be due to invalid IL or missing references)
			//IL_00cc: Expected O, but got Unknown
			//IL_00d5: Unknown result type (might be due to invalid IL or missing references)
			//IL_00da: Unknown result type (might be due to invalid IL or missing references)
			//IL_00e5: Expected O, but got Unknown
			//IL_00e6: Expected O, but got Unknown
			//IL_00f9: Unknown result type (might be due to invalid IL or missing references)
			//IL_00fe: Unknown result type (might be due to invalid IL or missing references)
			//IL_010a: Expected O, but got Unknown
			//IL_0115: Unknown result type (might be due to invalid IL or missing references)
			//IL_011a: Unknown result type (might be due to invalid IL or missing references)
			//IL_0125: Expected O, but got Unknown
			//IL_0126: Expected O, but got Unknown
			//IL_013c: Unknown result type (might be due to invalid IL or missing references)
			//IL_0141: Unknown result type (might be due to invalid IL or missing references)
			//IL_014d: Expected O, but got Unknown
			//IL_015b: Unknown result type (might be due to invalid IL or missing references)
			//IL_0160: Unknown result type (might be due to invalid IL or missing references)
			//IL_016b: Expected O, but got Unknown
			//IL_016c: Expected O, but got Unknown
			//IL_0182: Unknown result type (might be due to invalid IL or missing references)
			//IL_0187: Unknown result type (might be due to invalid IL or missing references)
			//IL_0193: Expected O, but got Unknown
			//IL_01a1: Unknown result type (might be due to invalid IL or missing references)
			//IL_01a6: Unknown result type (might be due to invalid IL or missing references)
			//IL_01b1: Expected O, but got Unknown
			//IL_01b2: Expected O, but got Unknown
			//IL_01c6: Unknown result type (might be due to invalid IL or missing references)
			//IL_01cb: Unknown result type (might be due to invalid IL or missing references)
			//IL_01d7: Expected O, but got Unknown
			//IL_01e2: Unknown result type (might be due to invalid IL or missing references)
			//IL_01e7: Unknown result type (might be due to invalid IL or missing references)
			//IL_01f2: Expected O, but got Unknown
			//IL_01f3: Expected O, but got Unknown
			//IL_020a: Unknown result type (might be due to invalid IL or missing references)
			//IL_020f: Unknown result type (might be due to invalid IL or missing references)
			//IL_021b: Expected O, but got Unknown
			//IL_0229: Unknown result type (might be due to invalid IL or missing references)
			//IL_022e: Unknown result type (might be due to invalid IL or missing references)
			//IL_0239: Expected O, but got Unknown
			//IL_023a: Expected O, but got Unknown
			//IL_024e: Unknown result type (might be due to invalid IL or missing references)
			//IL_0253: Unknown result type (might be due to invalid IL or missing references)
			//IL_025f: Expected O, but got Unknown
			//IL_026a: Unknown result type (might be due to invalid IL or missing references)
			//IL_026f: Unknown result type (might be due to invalid IL or missing references)
			//IL_027a: Expected O, but got Unknown
			//IL_027b: Expected O, but got Unknown
			//IL_0292: Unknown result type (might be due to invalid IL or missing references)
			//IL_0297: Unknown result type (might be due to invalid IL or missing references)
			//IL_02a3: Expected O, but got Unknown
			//IL_02b1: Unknown result type (might be due to invalid IL or missing references)
			//IL_02b6: Unknown result type (might be due to invalid IL or missing references)
			//IL_02c1: Expected O, but got Unknown
			//IL_02c2: Expected O, but got Unknown
			//IL_02d6: Unknown result type (might be due to invalid IL or missing references)
			//IL_02db: Unknown result type (might be due to invalid IL or missing references)
			//IL_02e7: Expected O, but got Unknown
			//IL_02f2: Unknown result type (might be due to invalid IL or missing references)
			//IL_02f7: Unknown result type (might be due to invalid IL or missing references)
			//IL_0302: Expected O, but got Unknown
			//IL_0303: Expected O, but got Unknown
			//IL_031f: Unknown result type (might be due to invalid IL or missing references)
			//IL_0324: Unknown result type (might be due to invalid IL or missing references)
			//IL_033d: Expected O, but got Unknown
			//IL_0346: Unknown result type (might be due to invalid IL or missing references)
			//IL_034b: Unknown result type (might be due to invalid IL or missing references)
			//IL_0356: Expected O, but got Unknown
			//IL_0357: Expected O, but got Unknown
			//IL_0363: Unknown result type (might be due to invalid IL or missing references)
			//IL_0368: Unknown result type (might be due to invalid IL or missing references)
			//IL_0379: Expected O, but got Unknown
			//IL_037a: Expected O, but got Unknown
			string sql = "UPDATE Users SET \r\n\t\t\t\tName=:Name,Account=:Account,Password=:Password,Status=:Status,Sort=:Sort,Note=:Note,Mobile=:Mobile,Tel=:Tel,OtherTel=:OtherTel,Fax=:Fax,Email=:Email,QQ=:QQ,HeadImg=:HeadImg,WeiXin=:WeiXin,Sex=:Sex\r\n\t\t\t\tWHERE ID=:ID";
			OracleParameter[] obj = new OracleParameter[16];
			OracleParameter val = new OracleParameter(":Name", 119, 100);
			((DbParameter)val).Value = model.Name;
			obj[0] = val;
			OracleParameter val2 = new OracleParameter(":Account", 126, 255);
			((DbParameter)val2).Value = model.Account;
			obj[1] = val2;
			OracleParameter val3 = new OracleParameter(":Password", 126, 500);
			((DbParameter)val3).Value = model.Password;
			obj[2] = val3;
			OracleParameter val4 = new OracleParameter(":Status", 112);
			((DbParameter)val4).Value = model.Status;
			obj[3] = val4;
			OracleParameter val5 = new OracleParameter(":Sort", 112);
			((DbParameter)val5).Value = model.Sort;
			obj[4] = val5;
			_003F val6;
			if (model.Note != null)
			{
				val6 = new OracleParameter(":Note", 119);
				((DbParameter)val6).Value = model.Note;
			}
			else
			{
				val6 = new OracleParameter(":Note", 119);
				((DbParameter)val6).Value = DBNull.Value;
			}
			obj[5] = val6;
			_003F val7;
			if (model.Mobile != null)
			{
				val7 = new OracleParameter("@Mobile", 119, 50);
				((DbParameter)val7).Value = model.Mobile;
			}
			else
			{
				val7 = new OracleParameter("@Mobile", 119, 50);
				((DbParameter)val7).Value = DBNull.Value;
			}
			obj[6] = val7;
			_003F val8;
			if (model.Tel != null)
			{
				val8 = new OracleParameter("@Tel", 119, 500);
				((DbParameter)val8).Value = model.Tel;
			}
			else
			{
				val8 = new OracleParameter("@Tel", 119, 500);
				((DbParameter)val8).Value = DBNull.Value;
			}
			obj[7] = val8;
			_003F val9;
			if (model.OtherTel != null)
			{
				val9 = new OracleParameter("@OtherTel", 119, 500);
				((DbParameter)val9).Value = model.OtherTel;
			}
			else
			{
				val9 = new OracleParameter("@OtherTel", 119, 500);
				((DbParameter)val9).Value = DBNull.Value;
			}
			obj[8] = val9;
			_003F val10;
			if (model.Fax != null)
			{
				val10 = new OracleParameter("@Fax", 119, 50);
				((DbParameter)val10).Value = model.Fax;
			}
			else
			{
				val10 = new OracleParameter("@Fax", 119, 50);
				((DbParameter)val10).Value = DBNull.Value;
			}
			obj[9] = val10;
			_003F val11;
			if (model.Email != null)
			{
				val11 = new OracleParameter("@Email", 119, 500);
				((DbParameter)val11).Value = model.Email;
			}
			else
			{
				val11 = new OracleParameter("@Email", 119, 500);
				((DbParameter)val11).Value = DBNull.Value;
			}
			obj[10] = val11;
			_003F val12;
			if (model.QQ != null)
			{
				val12 = new OracleParameter("@QQ", 119, 50);
				((DbParameter)val12).Value = model.QQ;
			}
			else
			{
				val12 = new OracleParameter("@QQ", 119, 50);
				((DbParameter)val12).Value = DBNull.Value;
			}
			obj[11] = val12;
			_003F val13;
			if (model.HeadImg != null)
			{
				val13 = new OracleParameter("@HeadImg", 119, 500);
				((DbParameter)val13).Value = model.HeadImg;
			}
			else
			{
				val13 = new OracleParameter("@HeadImg", 119, 500);
				((DbParameter)val13).Value = DBNull.Value;
			}
			obj[12] = val13;
			_003F val14;
			if (model.WeiXin != null)
			{
				val14 = new OracleParameter("@WeiXin", 119, 50);
				((DbParameter)val14).Value = model.WeiXin;
			}
			else
			{
				val14 = new OracleParameter("@WeiXin", 119, 50);
				((DbParameter)val14).Value = DBNull.Value;
			}
			obj[13] = val14;
			_003F val15;
			if (model.Sex.HasValue)
			{
				val15 = new OracleParameter("@Sex", 112, 11);
				((DbParameter)val15).Value = model.Sex.Value;
			}
			else
			{
				val15 = new OracleParameter("@Sex", 112);
				((DbParameter)val15).Value = DBNull.Value;
			}
			obj[14] = val15;
			OracleParameter val16 = new OracleParameter(":ID", 126, 40);
			((DbParameter)val16).Value = model.ID;
			obj[15] = val16;
			OracleParameter[] parameter = (OracleParameter[])obj;
			return dbHelper.Execute(sql, parameter);
		}

		public int Delete(Guid id)
		{
			//IL_0015: Unknown result type (might be due to invalid IL or missing references)
			//IL_001a: Unknown result type (might be due to invalid IL or missing references)
			//IL_0026: Expected O, but got Unknown
			//IL_0027: Expected O, but got Unknown
			string sql = "DELETE FROM Users WHERE ID=:ID";
			OracleParameter[] obj = new OracleParameter[1];
			OracleParameter val = new OracleParameter(":ID", 126);
			((DbParameter)val).Value = id;
			obj[0] = val;
			OracleParameter[] parameter = (OracleParameter[])obj;
			return dbHelper.Execute(sql, parameter);
		}

		private List<RoadFlow.Data.Model.Users> DataReaderToList(OracleDataReader dataReader)
		{
			List<RoadFlow.Data.Model.Users> list = new List<RoadFlow.Data.Model.Users>();
			RoadFlow.Data.Model.Users users = null;
			while (((DbDataReader)dataReader).Read())
			{
				users = new RoadFlow.Data.Model.Users();
				users.ID = ((DbDataReader)dataReader).GetString(0).ToGuid();
				users.Name = ((DbDataReader)dataReader).GetString(1);
				users.Account = ((DbDataReader)dataReader).GetString(2);
				users.Password = ((DbDataReader)dataReader).GetString(3);
				users.Status = ((DbDataReader)dataReader).GetInt32(4);
				users.Sort = ((DbDataReader)dataReader).GetInt32(5);
				if (!((DbDataReader)dataReader).IsDBNull(6))
				{
					users.Note = ((DbDataReader)dataReader).GetString(6);
				}
				if (!((DbDataReader)dataReader).IsDBNull(7))
				{
					users.Mobile = ((DbDataReader)dataReader).GetString(7);
				}
				if (!((DbDataReader)dataReader).IsDBNull(8))
				{
					users.Tel = ((DbDataReader)dataReader).GetString(8);
				}
				if (!((DbDataReader)dataReader).IsDBNull(9))
				{
					users.OtherTel = ((DbDataReader)dataReader).GetString(9);
				}
				if (!((DbDataReader)dataReader).IsDBNull(10))
				{
					users.Fax = ((DbDataReader)dataReader).GetString(10);
				}
				if (!((DbDataReader)dataReader).IsDBNull(11))
				{
					users.Email = ((DbDataReader)dataReader).GetString(11);
				}
				if (!((DbDataReader)dataReader).IsDBNull(12))
				{
					users.QQ = ((DbDataReader)dataReader).GetString(12);
				}
				if (!((DbDataReader)dataReader).IsDBNull(13))
				{
					users.HeadImg = ((DbDataReader)dataReader).GetString(13);
				}
				if (!((DbDataReader)dataReader).IsDBNull(14))
				{
					users.WeiXin = ((DbDataReader)dataReader).GetString(14);
				}
				if (!((DbDataReader)dataReader).IsDBNull(15))
				{
					users.Sex = ((DbDataReader)dataReader).GetInt32(15);
				}
				list.Add(users);
			}
			return list;
		}

		public List<RoadFlow.Data.Model.Users> GetAll()
		{
			string sql = "SELECT * FROM Users";
			OracleDataReader dataReader = dbHelper.GetDataReader(sql);
			List<RoadFlow.Data.Model.Users> result = DataReaderToList(dataReader);
			((DbDataReader)dataReader).Close();
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
			//IL_0015: Unknown result type (might be due to invalid IL or missing references)
			//IL_001a: Unknown result type (might be due to invalid IL or missing references)
			//IL_0026: Expected O, but got Unknown
			//IL_0027: Expected O, but got Unknown
			string sql = "SELECT * FROM Users WHERE ID=:ID";
			OracleParameter[] obj = new OracleParameter[1];
			OracleParameter val = new OracleParameter(":ID", 126);
			((DbParameter)val).Value = id;
			obj[0] = val;
			OracleParameter[] parameter = (OracleParameter[])obj;
			OracleDataReader dataReader = dbHelper.GetDataReader(sql, parameter);
			List<RoadFlow.Data.Model.Users> list = DataReaderToList(dataReader);
			((DbDataReader)dataReader).Close();
			if (list.Count <= 0)
			{
				return null;
			}
			return list[0];
		}

		public RoadFlow.Data.Model.Users GetByAccount(string account)
		{
			//IL_001a: Unknown result type (might be due to invalid IL or missing references)
			//IL_001f: Unknown result type (might be due to invalid IL or missing references)
			//IL_0026: Expected O, but got Unknown
			//IL_0027: Expected O, but got Unknown
			string sql = "SELECT * FROM Users WHERE Account=:Account";
			OracleParameter[] obj = new OracleParameter[1];
			OracleParameter val = new OracleParameter(":Account", 126, 255);
			((DbParameter)val).Value = account;
			obj[0] = val;
			OracleParameter[] parameter = (OracleParameter[])obj;
			OracleDataReader dataReader = dbHelper.GetDataReader(sql, parameter);
			List<RoadFlow.Data.Model.Users> list = DataReaderToList(dataReader);
			((DbDataReader)dataReader).Close();
			if (list.Count <= 0)
			{
				return null;
			}
			return list[0];
		}

		public List<RoadFlow.Data.Model.Users> GetAllByOrganizeID(Guid organizeID)
		{
			//IL_0015: Unknown result type (might be due to invalid IL or missing references)
			//IL_001a: Unknown result type (might be due to invalid IL or missing references)
			//IL_0026: Expected O, but got Unknown
			//IL_0027: Expected O, but got Unknown
			string sql = "SELECT * FROM Users WHERE ID in(SELECT UserID FROM UsersRelation WHERE OrganizeID=:OrganizeID) ORDER BY Sort";
			OracleParameter[] obj = new OracleParameter[1];
			OracleParameter val = new OracleParameter(":OrganizeID", 126);
			((DbParameter)val).Value = organizeID;
			obj[0] = val;
			OracleParameter[] parameter = (OracleParameter[])obj;
			OracleDataReader dataReader = dbHelper.GetDataReader(sql, parameter);
			List<RoadFlow.Data.Model.Users> result = DataReaderToList(dataReader);
			((DbDataReader)dataReader).Close();
			return result;
		}

		public List<RoadFlow.Data.Model.Users> GetAllByOrganizeIDArray(Guid[] organizeIDArray)
		{
			if (organizeIDArray != null && organizeIDArray.Length != 0)
			{
				string sql = "SELECT * FROM Users WHERE ID in(SELECT UserID FROM UsersRelation WHERE OrganizeID in(" + Tools.GetSqlInString(organizeIDArray) + ")) ORDER BY Sort";
				OracleDataReader dataReader = dbHelper.GetDataReader(sql);
				List<RoadFlow.Data.Model.Users> result = DataReaderToList(dataReader);
				((DbDataReader)dataReader).Close();
				return result;
			}
			return new List<RoadFlow.Data.Model.Users>();
		}

		public bool HasAccount(string account, string userID = "")
		{
			//IL_0014: Unknown result type (might be due to invalid IL or missing references)
			//IL_0019: Unknown result type (might be due to invalid IL or missing references)
			//IL_0020: Expected O, but got Unknown
			//IL_0025: Expected O, but got Unknown
			//IL_0041: Unknown result type (might be due to invalid IL or missing references)
			//IL_0046: Unknown result type (might be due to invalid IL or missing references)
			//IL_0057: Expected O, but got Unknown
			//IL_005c: Expected O, but got Unknown
			string text = "SELECT ID FROM Users WHERE Account=:Account";
			List<OracleParameter> list = new List<OracleParameter>();
			List<OracleParameter> list2 = list;
			OracleParameter val = new OracleParameter(":Account", 126);
			((DbParameter)val).Value = account;
			list2.Add(val);
			if (userID.IsGuid())
			{
				text += " and ID<>:ID";
				List<OracleParameter> list3 = list;
				OracleParameter val2 = new OracleParameter(":ID", 126);
				((DbParameter)val2).Value = userID.ToGuid();
				list3.Add(val2);
			}
			OracleDataReader dataReader = dbHelper.GetDataReader(text, list.ToArray());
			bool hasRows = ((DbDataReader)dataReader).HasRows;
			((DbDataReader)dataReader).Close();
			return hasRows;
		}

		public bool UpdatePassword(string password, Guid userID)
		{
			//IL_0015: Unknown result type (might be due to invalid IL or missing references)
			//IL_001a: Unknown result type (might be due to invalid IL or missing references)
			//IL_0021: Expected O, but got Unknown
			//IL_0022: Expected O, but got Unknown
			//IL_002b: Unknown result type (might be due to invalid IL or missing references)
			//IL_0030: Unknown result type (might be due to invalid IL or missing references)
			//IL_003c: Expected O, but got Unknown
			//IL_003d: Expected O, but got Unknown
			string sql = "UPDATE Users SET Password=:Password WHERE ID=:ID";
			OracleParameter[] obj = new OracleParameter[2];
			OracleParameter val = new OracleParameter(":Password", 126);
			((DbParameter)val).Value = password;
			obj[0] = val;
			OracleParameter val2 = new OracleParameter(":ID", 126);
			((DbParameter)val2).Value = userID;
			obj[1] = val2;
			OracleParameter[] parameter = (OracleParameter[])obj;
			return dbHelper.Execute(sql, parameter) == 1;
		}

		public int UpdateSort(Guid userID, int sort)
		{
			//IL_0015: Unknown result type (might be due to invalid IL or missing references)
			//IL_001a: Unknown result type (might be due to invalid IL or missing references)
			//IL_0026: Expected O, but got Unknown
			//IL_0027: Expected O, but got Unknown
			//IL_0030: Unknown result type (might be due to invalid IL or missing references)
			//IL_0035: Unknown result type (might be due to invalid IL or missing references)
			//IL_0041: Expected O, but got Unknown
			//IL_0042: Expected O, but got Unknown
			string sql = "UPDATE Users SET Sort=:Sort WHERE ID=:ID";
			OracleParameter[] obj = new OracleParameter[2];
			OracleParameter val = new OracleParameter(":Sort", 112);
			((DbParameter)val).Value = sort;
			obj[0] = val;
			OracleParameter val2 = new OracleParameter(":ID", 126);
			((DbParameter)val2).Value = userID;
			obj[1] = val2;
			OracleParameter[] parameter = (OracleParameter[])obj;
			return dbHelper.Execute(sql, parameter);
		}

		public List<RoadFlow.Data.Model.Users> GetAllByIDString(string idString)
		{
			string sql = "SELECT * FROM Users WHERE ID IN(" + Tools.GetSqlInString(idString) + ")";
			OracleDataReader dataReader = dbHelper.GetDataReader(sql);
			List<RoadFlow.Data.Model.Users> result = DataReaderToList(dataReader);
			((DbDataReader)dataReader).Close();
			return result;
		}

		public List<RoadFlow.Data.Model.Users> GetAllByWorkGroupID(Guid workgroupid)
		{
			string sql = "SELECT * FROM Users WHERE ID IN(SELECT UserID FROM WorkGroupUsers WHERE WorkGroupID='" + workgroupid + "')";
			OracleDataReader dataReader = dbHelper.GetDataReader(sql);
			List<RoadFlow.Data.Model.Users> result = DataReaderToList(dataReader);
			((DbDataReader)dataReader).Close();
			return result;
		}
	}
}
