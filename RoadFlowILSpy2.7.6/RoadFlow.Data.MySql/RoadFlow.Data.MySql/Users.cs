using MySql.Data.MySqlClient;
using RoadFlow.Data.Interface;
using RoadFlow.Data.Model;
using RoadFlow.Utility;
using System;
using System.Collections.Generic;
using System.Data.Common;

namespace RoadFlow.Data.MySql
{
	public class Users : IUsers
	{
		private DBHelper dbHelper = new DBHelper();

		public int Add(RoadFlow.Data.Model.Users model)
		{
			//IL_001b: Unknown result type (might be due to invalid IL or missing references)
			//IL_0020: Unknown result type (might be due to invalid IL or missing references)
			//IL_0031: Expected O, but got Unknown
			//IL_0032: Expected O, but got Unknown
			//IL_0040: Unknown result type (might be due to invalid IL or missing references)
			//IL_0045: Unknown result type (might be due to invalid IL or missing references)
			//IL_0051: Expected O, but got Unknown
			//IL_0052: Expected O, but got Unknown
			//IL_0063: Unknown result type (might be due to invalid IL or missing references)
			//IL_0068: Unknown result type (might be due to invalid IL or missing references)
			//IL_0074: Expected O, but got Unknown
			//IL_0075: Expected O, but got Unknown
			//IL_0082: Unknown result type (might be due to invalid IL or missing references)
			//IL_0087: Unknown result type (might be due to invalid IL or missing references)
			//IL_0093: Expected O, but got Unknown
			//IL_0094: Expected O, but got Unknown
			//IL_009e: Unknown result type (might be due to invalid IL or missing references)
			//IL_00a3: Unknown result type (might be due to invalid IL or missing references)
			//IL_00b4: Expected O, but got Unknown
			//IL_00b5: Expected O, but got Unknown
			//IL_00bf: Unknown result type (might be due to invalid IL or missing references)
			//IL_00c4: Unknown result type (might be due to invalid IL or missing references)
			//IL_00d5: Expected O, but got Unknown
			//IL_00d6: Expected O, but got Unknown
			//IL_00eb: Unknown result type (might be due to invalid IL or missing references)
			//IL_00f0: Unknown result type (might be due to invalid IL or missing references)
			//IL_00fc: Expected O, but got Unknown
			//IL_0109: Unknown result type (might be due to invalid IL or missing references)
			//IL_010e: Unknown result type (might be due to invalid IL or missing references)
			//IL_0119: Expected O, but got Unknown
			//IL_011a: Expected O, but got Unknown
			//IL_0130: Unknown result type (might be due to invalid IL or missing references)
			//IL_0135: Unknown result type (might be due to invalid IL or missing references)
			//IL_0141: Expected O, but got Unknown
			//IL_014f: Unknown result type (might be due to invalid IL or missing references)
			//IL_0154: Unknown result type (might be due to invalid IL or missing references)
			//IL_015f: Expected O, but got Unknown
			//IL_0160: Expected O, but got Unknown
			//IL_0179: Unknown result type (might be due to invalid IL or missing references)
			//IL_017e: Unknown result type (might be due to invalid IL or missing references)
			//IL_018a: Expected O, but got Unknown
			//IL_019b: Unknown result type (might be due to invalid IL or missing references)
			//IL_01a0: Unknown result type (might be due to invalid IL or missing references)
			//IL_01ab: Expected O, but got Unknown
			//IL_01ac: Expected O, but got Unknown
			//IL_01c6: Unknown result type (might be due to invalid IL or missing references)
			//IL_01cb: Unknown result type (might be due to invalid IL or missing references)
			//IL_01d7: Expected O, but got Unknown
			//IL_01e8: Unknown result type (might be due to invalid IL or missing references)
			//IL_01ed: Unknown result type (might be due to invalid IL or missing references)
			//IL_01f8: Expected O, but got Unknown
			//IL_01f9: Expected O, but got Unknown
			//IL_0210: Unknown result type (might be due to invalid IL or missing references)
			//IL_0215: Unknown result type (might be due to invalid IL or missing references)
			//IL_0221: Expected O, but got Unknown
			//IL_022f: Unknown result type (might be due to invalid IL or missing references)
			//IL_0234: Unknown result type (might be due to invalid IL or missing references)
			//IL_023f: Expected O, but got Unknown
			//IL_0240: Expected O, but got Unknown
			//IL_025a: Unknown result type (might be due to invalid IL or missing references)
			//IL_025f: Unknown result type (might be due to invalid IL or missing references)
			//IL_026b: Expected O, but got Unknown
			//IL_027c: Unknown result type (might be due to invalid IL or missing references)
			//IL_0281: Unknown result type (might be due to invalid IL or missing references)
			//IL_028c: Expected O, but got Unknown
			//IL_028d: Expected O, but got Unknown
			//IL_02a4: Unknown result type (might be due to invalid IL or missing references)
			//IL_02a9: Unknown result type (might be due to invalid IL or missing references)
			//IL_02b5: Expected O, but got Unknown
			//IL_02c3: Unknown result type (might be due to invalid IL or missing references)
			//IL_02c8: Unknown result type (might be due to invalid IL or missing references)
			//IL_02d3: Expected O, but got Unknown
			//IL_02d4: Expected O, but got Unknown
			//IL_02ee: Unknown result type (might be due to invalid IL or missing references)
			//IL_02f3: Unknown result type (might be due to invalid IL or missing references)
			//IL_02ff: Expected O, but got Unknown
			//IL_0310: Unknown result type (might be due to invalid IL or missing references)
			//IL_0315: Unknown result type (might be due to invalid IL or missing references)
			//IL_0320: Expected O, but got Unknown
			//IL_0321: Expected O, but got Unknown
			//IL_0338: Unknown result type (might be due to invalid IL or missing references)
			//IL_033d: Unknown result type (might be due to invalid IL or missing references)
			//IL_0349: Expected O, but got Unknown
			//IL_0357: Unknown result type (might be due to invalid IL or missing references)
			//IL_035c: Unknown result type (might be due to invalid IL or missing references)
			//IL_0367: Expected O, but got Unknown
			//IL_0368: Expected O, but got Unknown
			//IL_0383: Unknown result type (might be due to invalid IL or missing references)
			//IL_0388: Unknown result type (might be due to invalid IL or missing references)
			//IL_03a1: Expected O, but got Unknown
			//IL_03ab: Unknown result type (might be due to invalid IL or missing references)
			//IL_03b0: Unknown result type (might be due to invalid IL or missing references)
			//IL_03bb: Expected O, but got Unknown
			//IL_03bc: Expected O, but got Unknown
			string sql = "INSERT INTO users\r\n\t\t\t\t(ID,Name,Account,Password,Status,Sort,Note,Mobile,Tel,OtherTel,Fax,Email,QQ,HeadImg,WeiXin,Sex) \r\n\t\t\t\tVALUES(@ID,@Name,@Account,@Password,@Status,@Sort,@Note,@Mobile,@Tel,@OtherTel,@Fax,@Email,@QQ,@HeadImg,@WeiXin,@Sex)";
			MySqlParameter[] obj = new MySqlParameter[16];
			MySqlParameter val = new MySqlParameter("@ID", 253, 36);
			((DbParameter)val).Value = model.ID;
			obj[0] = val;
			MySqlParameter val2 = new MySqlParameter("@Name", 253, 50);
			((DbParameter)val2).Value = model.Name;
			obj[1] = val2;
			MySqlParameter val3 = new MySqlParameter("@Account", 253, 255);
			((DbParameter)val3).Value = model.Account;
			obj[2] = val3;
			MySqlParameter val4 = new MySqlParameter("@Password", 752, -1);
			((DbParameter)val4).Value = model.Password;
			obj[3] = val4;
			MySqlParameter val5 = new MySqlParameter("@Status", 3, 11);
			((DbParameter)val5).Value = model.Status;
			obj[4] = val5;
			MySqlParameter val6 = new MySqlParameter("@Sort", 3, 11);
			((DbParameter)val6).Value = model.Sort;
			obj[5] = val6;
			_003F val7;
			if (model.Note != null)
			{
				val7 = new MySqlParameter("@Note", 751, -1);
				((DbParameter)val7).Value = model.Note;
			}
			else
			{
				val7 = new MySqlParameter("@Note", 751, -1);
				((DbParameter)val7).Value = DBNull.Value;
			}
			obj[6] = val7;
			_003F val8;
			if (model.Mobile != null)
			{
				val8 = new MySqlParameter("@Mobile", 253, 50);
				((DbParameter)val8).Value = model.Mobile;
			}
			else
			{
				val8 = new MySqlParameter("@Mobile", 253, 50);
				((DbParameter)val8).Value = DBNull.Value;
			}
			obj[7] = val8;
			_003F val9;
			if (model.Tel != null)
			{
				val9 = new MySqlParameter("@Tel", 253, 500);
				((DbParameter)val9).Value = model.Tel;
			}
			else
			{
				val9 = new MySqlParameter("@Tel", 253, 500);
				((DbParameter)val9).Value = DBNull.Value;
			}
			obj[8] = val9;
			_003F val10;
			if (model.OtherTel != null)
			{
				val10 = new MySqlParameter("@OtherTel", 253, 500);
				((DbParameter)val10).Value = model.OtherTel;
			}
			else
			{
				val10 = new MySqlParameter("@OtherTel", 253, 500);
				((DbParameter)val10).Value = DBNull.Value;
			}
			obj[9] = val10;
			_003F val11;
			if (model.Fax != null)
			{
				val11 = new MySqlParameter("@Fax", 253, 50);
				((DbParameter)val11).Value = model.Fax;
			}
			else
			{
				val11 = new MySqlParameter("@Fax", 253, 50);
				((DbParameter)val11).Value = DBNull.Value;
			}
			obj[10] = val11;
			_003F val12;
			if (model.Email != null)
			{
				val12 = new MySqlParameter("@Email", 253, 500);
				((DbParameter)val12).Value = model.Email;
			}
			else
			{
				val12 = new MySqlParameter("@Email", 253, 500);
				((DbParameter)val12).Value = DBNull.Value;
			}
			obj[11] = val12;
			_003F val13;
			if (model.QQ != null)
			{
				val13 = new MySqlParameter("@QQ", 253, 50);
				((DbParameter)val13).Value = model.QQ;
			}
			else
			{
				val13 = new MySqlParameter("@QQ", 253, 50);
				((DbParameter)val13).Value = DBNull.Value;
			}
			obj[12] = val13;
			_003F val14;
			if (model.HeadImg != null)
			{
				val14 = new MySqlParameter("@HeadImg", 253, 500);
				((DbParameter)val14).Value = model.HeadImg;
			}
			else
			{
				val14 = new MySqlParameter("@HeadImg", 253, 500);
				((DbParameter)val14).Value = DBNull.Value;
			}
			obj[13] = val14;
			_003F val15;
			if (model.WeiXin != null)
			{
				val15 = new MySqlParameter("@WeiXin", 253, 50);
				((DbParameter)val15).Value = model.WeiXin;
			}
			else
			{
				val15 = new MySqlParameter("@WeiXin", 253, 50);
				((DbParameter)val15).Value = DBNull.Value;
			}
			obj[14] = val15;
			_003F val16;
			if (model.Sex.HasValue)
			{
				val16 = new MySqlParameter("@Sex", 3, 11);
				((DbParameter)val16).Value = model.Sex.Value;
			}
			else
			{
				val16 = new MySqlParameter("@Sex", 3, 11);
				((DbParameter)val16).Value = DBNull.Value;
			}
			obj[15] = val16;
			MySqlParameter[] parameter = (MySqlParameter[])obj;
			return dbHelper.Execute(sql, parameter);
		}

		public int Update(RoadFlow.Data.Model.Users model)
		{
			//IL_001b: Unknown result type (might be due to invalid IL or missing references)
			//IL_0020: Unknown result type (might be due to invalid IL or missing references)
			//IL_002c: Expected O, but got Unknown
			//IL_002d: Expected O, but got Unknown
			//IL_003e: Unknown result type (might be due to invalid IL or missing references)
			//IL_0043: Unknown result type (might be due to invalid IL or missing references)
			//IL_004f: Expected O, but got Unknown
			//IL_0050: Expected O, but got Unknown
			//IL_005d: Unknown result type (might be due to invalid IL or missing references)
			//IL_0062: Unknown result type (might be due to invalid IL or missing references)
			//IL_006e: Expected O, but got Unknown
			//IL_006f: Expected O, but got Unknown
			//IL_0079: Unknown result type (might be due to invalid IL or missing references)
			//IL_007e: Unknown result type (might be due to invalid IL or missing references)
			//IL_008f: Expected O, but got Unknown
			//IL_0090: Expected O, but got Unknown
			//IL_009a: Unknown result type (might be due to invalid IL or missing references)
			//IL_009f: Unknown result type (might be due to invalid IL or missing references)
			//IL_00b0: Expected O, but got Unknown
			//IL_00b1: Expected O, but got Unknown
			//IL_00c6: Unknown result type (might be due to invalid IL or missing references)
			//IL_00cb: Unknown result type (might be due to invalid IL or missing references)
			//IL_00d7: Expected O, but got Unknown
			//IL_00e4: Unknown result type (might be due to invalid IL or missing references)
			//IL_00e9: Unknown result type (might be due to invalid IL or missing references)
			//IL_00f4: Expected O, but got Unknown
			//IL_00f5: Expected O, but got Unknown
			//IL_010b: Unknown result type (might be due to invalid IL or missing references)
			//IL_0110: Unknown result type (might be due to invalid IL or missing references)
			//IL_011c: Expected O, but got Unknown
			//IL_012a: Unknown result type (might be due to invalid IL or missing references)
			//IL_012f: Unknown result type (might be due to invalid IL or missing references)
			//IL_013a: Expected O, but got Unknown
			//IL_013b: Expected O, but got Unknown
			//IL_0154: Unknown result type (might be due to invalid IL or missing references)
			//IL_0159: Unknown result type (might be due to invalid IL or missing references)
			//IL_0165: Expected O, but got Unknown
			//IL_0176: Unknown result type (might be due to invalid IL or missing references)
			//IL_017b: Unknown result type (might be due to invalid IL or missing references)
			//IL_0186: Expected O, but got Unknown
			//IL_0187: Expected O, but got Unknown
			//IL_01a0: Unknown result type (might be due to invalid IL or missing references)
			//IL_01a5: Unknown result type (might be due to invalid IL or missing references)
			//IL_01b1: Expected O, but got Unknown
			//IL_01c2: Unknown result type (might be due to invalid IL or missing references)
			//IL_01c7: Unknown result type (might be due to invalid IL or missing references)
			//IL_01d2: Expected O, but got Unknown
			//IL_01d3: Expected O, but got Unknown
			//IL_01ea: Unknown result type (might be due to invalid IL or missing references)
			//IL_01ef: Unknown result type (might be due to invalid IL or missing references)
			//IL_01fb: Expected O, but got Unknown
			//IL_0209: Unknown result type (might be due to invalid IL or missing references)
			//IL_020e: Unknown result type (might be due to invalid IL or missing references)
			//IL_0219: Expected O, but got Unknown
			//IL_021a: Expected O, but got Unknown
			//IL_0234: Unknown result type (might be due to invalid IL or missing references)
			//IL_0239: Unknown result type (might be due to invalid IL or missing references)
			//IL_0245: Expected O, but got Unknown
			//IL_0256: Unknown result type (might be due to invalid IL or missing references)
			//IL_025b: Unknown result type (might be due to invalid IL or missing references)
			//IL_0266: Expected O, but got Unknown
			//IL_0267: Expected O, but got Unknown
			//IL_027e: Unknown result type (might be due to invalid IL or missing references)
			//IL_0283: Unknown result type (might be due to invalid IL or missing references)
			//IL_028f: Expected O, but got Unknown
			//IL_029d: Unknown result type (might be due to invalid IL or missing references)
			//IL_02a2: Unknown result type (might be due to invalid IL or missing references)
			//IL_02ad: Expected O, but got Unknown
			//IL_02ae: Expected O, but got Unknown
			//IL_02c8: Unknown result type (might be due to invalid IL or missing references)
			//IL_02cd: Unknown result type (might be due to invalid IL or missing references)
			//IL_02d9: Expected O, but got Unknown
			//IL_02ea: Unknown result type (might be due to invalid IL or missing references)
			//IL_02ef: Unknown result type (might be due to invalid IL or missing references)
			//IL_02fa: Expected O, but got Unknown
			//IL_02fb: Expected O, but got Unknown
			//IL_0312: Unknown result type (might be due to invalid IL or missing references)
			//IL_0317: Unknown result type (might be due to invalid IL or missing references)
			//IL_0323: Expected O, but got Unknown
			//IL_0331: Unknown result type (might be due to invalid IL or missing references)
			//IL_0336: Unknown result type (might be due to invalid IL or missing references)
			//IL_0341: Expected O, but got Unknown
			//IL_0342: Expected O, but got Unknown
			//IL_035d: Unknown result type (might be due to invalid IL or missing references)
			//IL_0362: Unknown result type (might be due to invalid IL or missing references)
			//IL_037b: Expected O, but got Unknown
			//IL_0385: Unknown result type (might be due to invalid IL or missing references)
			//IL_038a: Unknown result type (might be due to invalid IL or missing references)
			//IL_0395: Expected O, but got Unknown
			//IL_0396: Expected O, but got Unknown
			//IL_03a5: Unknown result type (might be due to invalid IL or missing references)
			//IL_03aa: Unknown result type (might be due to invalid IL or missing references)
			//IL_03bb: Expected O, but got Unknown
			//IL_03bc: Expected O, but got Unknown
			string sql = "UPDATE Users SET \r\n\t\t\t\tName=@Name,Account=@Account,Password=@Password,Status=@Status,Sort=@Sort,Note=@Note,Mobile=@Mobile,Tel=@Tel,OtherTel=@OtherTel,Fax=@Fax,Email=@Email,QQ=@QQ,HeadImg=@HeadImg,WeiXin=@WeiXin,Sex=@Sex\r\n\t\t\t\tWHERE ID=@ID";
			MySqlParameter[] obj = new MySqlParameter[16];
			MySqlParameter val = new MySqlParameter("@Name", 253, 50);
			((DbParameter)val).Value = model.Name;
			obj[0] = val;
			MySqlParameter val2 = new MySqlParameter("@Account", 253, 255);
			((DbParameter)val2).Value = model.Account;
			obj[1] = val2;
			MySqlParameter val3 = new MySqlParameter("@Password", 752, -1);
			((DbParameter)val3).Value = model.Password;
			obj[2] = val3;
			MySqlParameter val4 = new MySqlParameter("@Status", 3, 11);
			((DbParameter)val4).Value = model.Status;
			obj[3] = val4;
			MySqlParameter val5 = new MySqlParameter("@Sort", 3, 11);
			((DbParameter)val5).Value = model.Sort;
			obj[4] = val5;
			_003F val6;
			if (model.Note != null)
			{
				val6 = new MySqlParameter("@Note", 751, -1);
				((DbParameter)val6).Value = model.Note;
			}
			else
			{
				val6 = new MySqlParameter("@Note", 751, -1);
				((DbParameter)val6).Value = DBNull.Value;
			}
			obj[5] = val6;
			_003F val7;
			if (model.Mobile != null)
			{
				val7 = new MySqlParameter("@Mobile", 253, 50);
				((DbParameter)val7).Value = model.Mobile;
			}
			else
			{
				val7 = new MySqlParameter("@Mobile", 253, 50);
				((DbParameter)val7).Value = DBNull.Value;
			}
			obj[6] = val7;
			_003F val8;
			if (model.Tel != null)
			{
				val8 = new MySqlParameter("@Tel", 253, 500);
				((DbParameter)val8).Value = model.Tel;
			}
			else
			{
				val8 = new MySqlParameter("@Tel", 253, 500);
				((DbParameter)val8).Value = DBNull.Value;
			}
			obj[7] = val8;
			_003F val9;
			if (model.OtherTel != null)
			{
				val9 = new MySqlParameter("@OtherTel", 253, 500);
				((DbParameter)val9).Value = model.OtherTel;
			}
			else
			{
				val9 = new MySqlParameter("@OtherTel", 253, 500);
				((DbParameter)val9).Value = DBNull.Value;
			}
			obj[8] = val9;
			_003F val10;
			if (model.Fax != null)
			{
				val10 = new MySqlParameter("@Fax", 253, 50);
				((DbParameter)val10).Value = model.Fax;
			}
			else
			{
				val10 = new MySqlParameter("@Fax", 253, 50);
				((DbParameter)val10).Value = DBNull.Value;
			}
			obj[9] = val10;
			_003F val11;
			if (model.Email != null)
			{
				val11 = new MySqlParameter("@Email", 253, 500);
				((DbParameter)val11).Value = model.Email;
			}
			else
			{
				val11 = new MySqlParameter("@Email", 253, 500);
				((DbParameter)val11).Value = DBNull.Value;
			}
			obj[10] = val11;
			_003F val12;
			if (model.QQ != null)
			{
				val12 = new MySqlParameter("@QQ", 253, 50);
				((DbParameter)val12).Value = model.QQ;
			}
			else
			{
				val12 = new MySqlParameter("@QQ", 253, 50);
				((DbParameter)val12).Value = DBNull.Value;
			}
			obj[11] = val12;
			_003F val13;
			if (model.HeadImg != null)
			{
				val13 = new MySqlParameter("@HeadImg", 253, 500);
				((DbParameter)val13).Value = model.HeadImg;
			}
			else
			{
				val13 = new MySqlParameter("@HeadImg", 253, 500);
				((DbParameter)val13).Value = DBNull.Value;
			}
			obj[12] = val13;
			_003F val14;
			if (model.WeiXin != null)
			{
				val14 = new MySqlParameter("@WeiXin", 253, 50);
				((DbParameter)val14).Value = model.WeiXin;
			}
			else
			{
				val14 = new MySqlParameter("@WeiXin", 253, 50);
				((DbParameter)val14).Value = DBNull.Value;
			}
			obj[13] = val14;
			_003F val15;
			if (model.Sex.HasValue)
			{
				val15 = new MySqlParameter("@Sex", 3, 11);
				((DbParameter)val15).Value = model.Sex.Value;
			}
			else
			{
				val15 = new MySqlParameter("@Sex", 3, 11);
				((DbParameter)val15).Value = DBNull.Value;
			}
			obj[14] = val15;
			MySqlParameter val16 = new MySqlParameter("@ID", 253, 36);
			((DbParameter)val16).Value = model.ID;
			obj[15] = val16;
			MySqlParameter[] parameter = (MySqlParameter[])obj;
			return dbHelper.Execute(sql, parameter);
		}

		public int Delete(Guid id)
		{
			//IL_001a: Unknown result type (might be due to invalid IL or missing references)
			//IL_001f: Unknown result type (might be due to invalid IL or missing references)
			//IL_0032: Expected O, but got Unknown
			//IL_0033: Expected O, but got Unknown
			string sql = "DELETE FROM users WHERE ID=@ID";
			MySqlParameter[] obj = new MySqlParameter[1];
			MySqlParameter val = new MySqlParameter("@ID", 253, 36);
			((DbParameter)val).Value = id.ToString();
			obj[0] = val;
			MySqlParameter[] parameter = (MySqlParameter[])obj;
			return dbHelper.Execute(sql, parameter);
		}

		private List<RoadFlow.Data.Model.Users> DataReaderToList(MySqlDataReader dataReader)
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
			string sql = "SELECT * FROM users";
			MySqlDataReader dataReader = dbHelper.GetDataReader(sql);
			List<RoadFlow.Data.Model.Users> result = DataReaderToList(dataReader);
			((DbDataReader)dataReader).Close();
			return result;
		}

		public long GetCount()
		{
			string sql = "SELECT COUNT(*) FROM users";
			long result;
			if (!long.TryParse(dbHelper.GetFieldValue(sql), out result))
			{
				return 0L;
			}
			return result;
		}

		public RoadFlow.Data.Model.Users Get(Guid id)
		{
			//IL_001a: Unknown result type (might be due to invalid IL or missing references)
			//IL_001f: Unknown result type (might be due to invalid IL or missing references)
			//IL_0032: Expected O, but got Unknown
			//IL_0033: Expected O, but got Unknown
			string sql = "SELECT * FROM users WHERE ID=@ID";
			MySqlParameter[] obj = new MySqlParameter[1];
			MySqlParameter val = new MySqlParameter("@ID", 253, 36);
			((DbParameter)val).Value = id.ToString();
			obj[0] = val;
			MySqlParameter[] parameter = (MySqlParameter[])obj;
			MySqlDataReader dataReader = dbHelper.GetDataReader(sql, parameter);
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
			//IL_001d: Unknown result type (might be due to invalid IL or missing references)
			//IL_0022: Unknown result type (might be due to invalid IL or missing references)
			//IL_0029: Expected O, but got Unknown
			//IL_002a: Expected O, but got Unknown
			string sql = "SELECT * FROM Users WHERE Account=@Account";
			MySqlParameter[] obj = new MySqlParameter[1];
			MySqlParameter val = new MySqlParameter("@Account", 253, 255);
			((DbParameter)val).Value = account;
			obj[0] = val;
			MySqlParameter[] parameter = (MySqlParameter[])obj;
			MySqlDataReader dataReader = dbHelper.GetDataReader(sql, parameter);
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
			//IL_0018: Unknown result type (might be due to invalid IL or missing references)
			//IL_001d: Unknown result type (might be due to invalid IL or missing references)
			//IL_0030: Expected O, but got Unknown
			//IL_0031: Expected O, but got Unknown
			string sql = "SELECT * FROM Users WHERE ID in(SELECT UserID FROM UsersRelation WHERE OrganizeID=@OrganizeID) ORDER BY Sort";
			MySqlParameter[] obj = new MySqlParameter[1];
			MySqlParameter val = new MySqlParameter("@OrganizeID", 253);
			((DbParameter)val).Value = organizeID.ToString();
			obj[0] = val;
			MySqlParameter[] parameter = (MySqlParameter[])obj;
			MySqlDataReader dataReader = dbHelper.GetDataReader(sql, parameter);
			List<RoadFlow.Data.Model.Users> result = DataReaderToList(dataReader);
			((DbDataReader)dataReader).Close();
			return result;
		}

		public List<RoadFlow.Data.Model.Users> GetAllByOrganizeIDArray(Guid[] organizeIDArray)
		{
			if (organizeIDArray != null && organizeIDArray.Length != 0)
			{
				string sql = "SELECT * FROM Users WHERE ID in(SELECT UserID FROM UsersRelation WHERE OrganizeID in(" + Tools.GetSqlInString(organizeIDArray) + ")) ORDER BY Sort";
				MySqlDataReader dataReader = dbHelper.GetDataReader(sql);
				List<RoadFlow.Data.Model.Users> result = DataReaderToList(dataReader);
				((DbDataReader)dataReader).Close();
				return result;
			}
			return new List<RoadFlow.Data.Model.Users>();
		}

		public bool HasAccount(string account, string userID = "")
		{
			//IL_0017: Unknown result type (might be due to invalid IL or missing references)
			//IL_001c: Unknown result type (might be due to invalid IL or missing references)
			//IL_0023: Expected O, but got Unknown
			//IL_0028: Expected O, but got Unknown
			//IL_0047: Unknown result type (might be due to invalid IL or missing references)
			//IL_004c: Unknown result type (might be due to invalid IL or missing references)
			//IL_0053: Expected O, but got Unknown
			//IL_0058: Expected O, but got Unknown
			string text = "SELECT ID FROM Users WHERE Account=@Account";
			List<MySqlParameter> list = new List<MySqlParameter>();
			List<MySqlParameter> list2 = list;
			MySqlParameter val = new MySqlParameter("@Account", 253);
			((DbParameter)val).Value = account;
			list2.Add(val);
			if (userID.IsGuid())
			{
				text += " and ID<>@ID";
				List<MySqlParameter> list3 = list;
				MySqlParameter val2 = new MySqlParameter("@ID", 253);
				((DbParameter)val2).Value = userID;
				list3.Add(val2);
			}
			MySqlDataReader dataReader = dbHelper.GetDataReader(text, list.ToArray());
			bool hasRows = ((DbDataReader)dataReader).HasRows;
			((DbDataReader)dataReader).Close();
			return hasRows;
		}

		public bool UpdatePassword(string password, Guid userID)
		{
			//IL_0018: Unknown result type (might be due to invalid IL or missing references)
			//IL_001d: Unknown result type (might be due to invalid IL or missing references)
			//IL_0024: Expected O, but got Unknown
			//IL_0025: Expected O, but got Unknown
			//IL_0031: Unknown result type (might be due to invalid IL or missing references)
			//IL_0036: Unknown result type (might be due to invalid IL or missing references)
			//IL_0049: Expected O, but got Unknown
			//IL_004a: Expected O, but got Unknown
			string sql = "UPDATE Users SET Password=@Password WHERE ID=@ID";
			MySqlParameter[] obj = new MySqlParameter[2];
			MySqlParameter val = new MySqlParameter("@Password", 253);
			((DbParameter)val).Value = password;
			obj[0] = val;
			MySqlParameter val2 = new MySqlParameter("@ID", 253);
			((DbParameter)val2).Value = userID.ToString();
			obj[1] = val2;
			MySqlParameter[] parameter = (MySqlParameter[])obj;
			return dbHelper.Execute(sql, parameter) == 1;
		}

		public int UpdateSort(Guid userID, int sort)
		{
			//IL_0014: Unknown result type (might be due to invalid IL or missing references)
			//IL_0019: Unknown result type (might be due to invalid IL or missing references)
			//IL_0025: Expected O, but got Unknown
			//IL_0026: Expected O, but got Unknown
			//IL_0032: Unknown result type (might be due to invalid IL or missing references)
			//IL_0037: Unknown result type (might be due to invalid IL or missing references)
			//IL_004a: Expected O, but got Unknown
			//IL_004b: Expected O, but got Unknown
			string sql = "UPDATE Users SET Sort=@Sort WHERE ID=@ID";
			MySqlParameter[] obj = new MySqlParameter[2];
			MySqlParameter val = new MySqlParameter("@Sort", 3);
			((DbParameter)val).Value = sort;
			obj[0] = val;
			MySqlParameter val2 = new MySqlParameter("@ID", 253);
			((DbParameter)val2).Value = userID.ToString();
			obj[1] = val2;
			MySqlParameter[] parameter = (MySqlParameter[])obj;
			return dbHelper.Execute(sql, parameter);
		}

		public List<RoadFlow.Data.Model.Users> GetAllByIDString(string idString)
		{
			string sql = "SELECT * FROM Users WHERE ID IN(" + Tools.GetSqlInString(idString) + ")";
			MySqlDataReader dataReader = dbHelper.GetDataReader(sql);
			List<RoadFlow.Data.Model.Users> result = DataReaderToList(dataReader);
			((DbDataReader)dataReader).Close();
			return result;
		}

		public List<RoadFlow.Data.Model.Users> GetAllByWorkGroupID(Guid workgroupid)
		{
			string sql = "SELECT * FROM Users WHERE ID IN(SELECT UserID FROM WorkGroupUsers WHERE WorkGroupID='" + workgroupid + "')";
			MySqlDataReader dataReader = dbHelper.GetDataReader(sql);
			List<RoadFlow.Data.Model.Users> result = DataReaderToList(dataReader);
			((DbDataReader)dataReader).Close();
			return result;
		}
	}
}
