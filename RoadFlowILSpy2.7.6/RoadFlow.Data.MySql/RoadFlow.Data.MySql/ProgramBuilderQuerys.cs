using MySql.Data.MySqlClient;
using RoadFlow.Data.Interface;
using RoadFlow.Data.Model;
using System;
using System.Collections.Generic;
using System.Data.Common;

namespace RoadFlow.Data.MySql
{
	public class ProgramBuilderQuerys : IProgramBuilderQuerys
	{
		private DBHelper dbHelper = new DBHelper();

		public int Add(RoadFlow.Data.Model.ProgramBuilderQuerys model)
		{
			//IL_001b: Unknown result type (might be due to invalid IL or missing references)
			//IL_0020: Unknown result type (might be due to invalid IL or missing references)
			//IL_0031: Expected O, but got Unknown
			//IL_0032: Expected O, but got Unknown
			//IL_0040: Unknown result type (might be due to invalid IL or missing references)
			//IL_0045: Unknown result type (might be due to invalid IL or missing references)
			//IL_0056: Expected O, but got Unknown
			//IL_0057: Expected O, but got Unknown
			//IL_0064: Unknown result type (might be due to invalid IL or missing references)
			//IL_0069: Unknown result type (might be due to invalid IL or missing references)
			//IL_0075: Expected O, but got Unknown
			//IL_0076: Expected O, but got Unknown
			//IL_0083: Unknown result type (might be due to invalid IL or missing references)
			//IL_0088: Unknown result type (might be due to invalid IL or missing references)
			//IL_0094: Expected O, but got Unknown
			//IL_0095: Expected O, but got Unknown
			//IL_00a3: Unknown result type (might be due to invalid IL or missing references)
			//IL_00a8: Unknown result type (might be due to invalid IL or missing references)
			//IL_00b4: Expected O, but got Unknown
			//IL_00b5: Expected O, but got Unknown
			//IL_00c3: Unknown result type (might be due to invalid IL or missing references)
			//IL_00c8: Unknown result type (might be due to invalid IL or missing references)
			//IL_00d4: Expected O, but got Unknown
			//IL_00d5: Expected O, but got Unknown
			//IL_00df: Unknown result type (might be due to invalid IL or missing references)
			//IL_00e4: Unknown result type (might be due to invalid IL or missing references)
			//IL_00f5: Expected O, but got Unknown
			//IL_00f6: Expected O, but got Unknown
			//IL_010c: Unknown result type (might be due to invalid IL or missing references)
			//IL_0111: Unknown result type (might be due to invalid IL or missing references)
			//IL_011d: Expected O, but got Unknown
			//IL_012b: Unknown result type (might be due to invalid IL or missing references)
			//IL_0130: Unknown result type (might be due to invalid IL or missing references)
			//IL_013b: Expected O, but got Unknown
			//IL_013c: Expected O, but got Unknown
			//IL_0146: Unknown result type (might be due to invalid IL or missing references)
			//IL_014b: Unknown result type (might be due to invalid IL or missing references)
			//IL_015c: Expected O, but got Unknown
			//IL_015d: Expected O, but got Unknown
			//IL_0178: Unknown result type (might be due to invalid IL or missing references)
			//IL_017d: Unknown result type (might be due to invalid IL or missing references)
			//IL_018e: Expected O, but got Unknown
			//IL_0198: Unknown result type (might be due to invalid IL or missing references)
			//IL_019d: Unknown result type (might be due to invalid IL or missing references)
			//IL_01a8: Expected O, but got Unknown
			//IL_01a9: Expected O, but got Unknown
			//IL_01bf: Unknown result type (might be due to invalid IL or missing references)
			//IL_01c4: Unknown result type (might be due to invalid IL or missing references)
			//IL_01d0: Expected O, but got Unknown
			//IL_01dd: Unknown result type (might be due to invalid IL or missing references)
			//IL_01e2: Unknown result type (might be due to invalid IL or missing references)
			//IL_01ed: Expected O, but got Unknown
			//IL_01ee: Expected O, but got Unknown
			//IL_0205: Unknown result type (might be due to invalid IL or missing references)
			//IL_020a: Unknown result type (might be due to invalid IL or missing references)
			//IL_0216: Expected O, but got Unknown
			//IL_0224: Unknown result type (might be due to invalid IL or missing references)
			//IL_0229: Unknown result type (might be due to invalid IL or missing references)
			//IL_0234: Expected O, but got Unknown
			//IL_0235: Expected O, but got Unknown
			//IL_0250: Unknown result type (might be due to invalid IL or missing references)
			//IL_0255: Unknown result type (might be due to invalid IL or missing references)
			//IL_0266: Expected O, but got Unknown
			//IL_0270: Unknown result type (might be due to invalid IL or missing references)
			//IL_0275: Unknown result type (might be due to invalid IL or missing references)
			//IL_0280: Expected O, but got Unknown
			//IL_0281: Expected O, but got Unknown
			//IL_0298: Unknown result type (might be due to invalid IL or missing references)
			//IL_029d: Unknown result type (might be due to invalid IL or missing references)
			//IL_02a9: Expected O, but got Unknown
			//IL_02b7: Unknown result type (might be due to invalid IL or missing references)
			//IL_02bc: Unknown result type (might be due to invalid IL or missing references)
			//IL_02c7: Expected O, but got Unknown
			//IL_02c8: Expected O, but got Unknown
			string sql = "INSERT INTO programbuilderquerys\r\n\t\t\t\t(ID,ProgramID,Field,ShowTitle,Operators,ControlName,InputType,Width,Sort,DataSource,DataSourceString,DataLinkID,IsQueryUsers,Value) \r\n\t\t\t\tVALUES(@ID,@ProgramID,@Field,@ShowTitle,@Operators,@ControlName,@InputType,@Width,@Sort,@DataSource,@DataSourceString,@DataLinkID,@IsQueryUsers,@Value)";
			MySqlParameter[] obj = new MySqlParameter[14];
			MySqlParameter val = new MySqlParameter("@ID", 253, 36);
			((DbParameter)val).Value = model.ID;
			obj[0] = val;
			MySqlParameter val2 = new MySqlParameter("@ProgramID", 253, 36);
			((DbParameter)val2).Value = model.ProgramID;
			obj[1] = val2;
			MySqlParameter val3 = new MySqlParameter("@Field", 752, -1);
			((DbParameter)val3).Value = model.Field;
			obj[2] = val3;
			MySqlParameter val4 = new MySqlParameter("@ShowTitle", 752, -1);
			((DbParameter)val4).Value = model.ShowTitle;
			obj[3] = val4;
			MySqlParameter val5 = new MySqlParameter("@Operators", 253, 50);
			((DbParameter)val5).Value = model.Operators;
			obj[4] = val5;
			MySqlParameter val6 = new MySqlParameter("@ControlName", 253, 50);
			((DbParameter)val6).Value = model.ControlName;
			obj[5] = val6;
			MySqlParameter val7 = new MySqlParameter("@InputType", 3, 11);
			((DbParameter)val7).Value = model.InputType;
			obj[6] = val7;
			_003F val8;
			if (model.Width != null)
			{
				val8 = new MySqlParameter("@Width", 253, 50);
				((DbParameter)val8).Value = model.Width;
			}
			else
			{
				val8 = new MySqlParameter("@Width", 253, 50);
				((DbParameter)val8).Value = DBNull.Value;
			}
			obj[7] = val8;
			MySqlParameter val9 = new MySqlParameter("@Sort", 3, 11);
			((DbParameter)val9).Value = model.Sort;
			obj[8] = val9;
			_003F val10;
			if (model.DataSource.HasValue)
			{
				val10 = new MySqlParameter("@DataSource", 3, 11);
				((DbParameter)val10).Value = model.DataSource;
			}
			else
			{
				val10 = new MySqlParameter("@DataSource", 3, 11);
				((DbParameter)val10).Value = DBNull.Value;
			}
			obj[9] = val10;
			_003F val11;
			if (model.DataSourceString != null)
			{
				val11 = new MySqlParameter("@DataSourceString", 751, -1);
				((DbParameter)val11).Value = model.DataSourceString;
			}
			else
			{
				val11 = new MySqlParameter("@DataSourceString", 751, -1);
				((DbParameter)val11).Value = DBNull.Value;
			}
			obj[10] = val11;
			_003F val12;
			if (model.DataLinkID != null)
			{
				val12 = new MySqlParameter("@DataLinkID", 253, 50);
				((DbParameter)val12).Value = model.DataLinkID;
			}
			else
			{
				val12 = new MySqlParameter("@DataLinkID", 253, 50);
				((DbParameter)val12).Value = DBNull.Value;
			}
			obj[11] = val12;
			_003F val13;
			if (model.IsQueryUsers.HasValue)
			{
				val13 = new MySqlParameter("@IsQueryUsers", 3, 11);
				((DbParameter)val13).Value = model.IsQueryUsers;
			}
			else
			{
				val13 = new MySqlParameter("@IsQueryUsers", 3, 11);
				((DbParameter)val13).Value = DBNull.Value;
			}
			obj[12] = val13;
			_003F val14;
			if (model.Value != null)
			{
				val14 = new MySqlParameter("@Value", 253, 50);
				((DbParameter)val14).Value = model.Value;
			}
			else
			{
				val14 = new MySqlParameter("@Value", 253, 50);
				((DbParameter)val14).Value = DBNull.Value;
			}
			obj[13] = val14;
			MySqlParameter[] parameter = (MySqlParameter[])obj;
			return dbHelper.Execute(sql, parameter);
		}

		public int Update(RoadFlow.Data.Model.ProgramBuilderQuerys model)
		{
			//IL_001b: Unknown result type (might be due to invalid IL or missing references)
			//IL_0020: Unknown result type (might be due to invalid IL or missing references)
			//IL_0031: Expected O, but got Unknown
			//IL_0032: Expected O, but got Unknown
			//IL_003f: Unknown result type (might be due to invalid IL or missing references)
			//IL_0044: Unknown result type (might be due to invalid IL or missing references)
			//IL_0050: Expected O, but got Unknown
			//IL_0051: Expected O, but got Unknown
			//IL_005e: Unknown result type (might be due to invalid IL or missing references)
			//IL_0063: Unknown result type (might be due to invalid IL or missing references)
			//IL_006f: Expected O, but got Unknown
			//IL_0070: Expected O, but got Unknown
			//IL_007e: Unknown result type (might be due to invalid IL or missing references)
			//IL_0083: Unknown result type (might be due to invalid IL or missing references)
			//IL_008f: Expected O, but got Unknown
			//IL_0090: Expected O, but got Unknown
			//IL_009e: Unknown result type (might be due to invalid IL or missing references)
			//IL_00a3: Unknown result type (might be due to invalid IL or missing references)
			//IL_00af: Expected O, but got Unknown
			//IL_00b0: Expected O, but got Unknown
			//IL_00ba: Unknown result type (might be due to invalid IL or missing references)
			//IL_00bf: Unknown result type (might be due to invalid IL or missing references)
			//IL_00d0: Expected O, but got Unknown
			//IL_00d1: Expected O, but got Unknown
			//IL_00e7: Unknown result type (might be due to invalid IL or missing references)
			//IL_00ec: Unknown result type (might be due to invalid IL or missing references)
			//IL_00f8: Expected O, but got Unknown
			//IL_0106: Unknown result type (might be due to invalid IL or missing references)
			//IL_010b: Unknown result type (might be due to invalid IL or missing references)
			//IL_0116: Expected O, but got Unknown
			//IL_0117: Expected O, but got Unknown
			//IL_0121: Unknown result type (might be due to invalid IL or missing references)
			//IL_0126: Unknown result type (might be due to invalid IL or missing references)
			//IL_0137: Expected O, but got Unknown
			//IL_0138: Expected O, but got Unknown
			//IL_0152: Unknown result type (might be due to invalid IL or missing references)
			//IL_0157: Unknown result type (might be due to invalid IL or missing references)
			//IL_0168: Expected O, but got Unknown
			//IL_0172: Unknown result type (might be due to invalid IL or missing references)
			//IL_0177: Unknown result type (might be due to invalid IL or missing references)
			//IL_0182: Expected O, but got Unknown
			//IL_0183: Expected O, but got Unknown
			//IL_0199: Unknown result type (might be due to invalid IL or missing references)
			//IL_019e: Unknown result type (might be due to invalid IL or missing references)
			//IL_01aa: Expected O, but got Unknown
			//IL_01b7: Unknown result type (might be due to invalid IL or missing references)
			//IL_01bc: Unknown result type (might be due to invalid IL or missing references)
			//IL_01c7: Expected O, but got Unknown
			//IL_01c8: Expected O, but got Unknown
			//IL_01df: Unknown result type (might be due to invalid IL or missing references)
			//IL_01e4: Unknown result type (might be due to invalid IL or missing references)
			//IL_01f0: Expected O, but got Unknown
			//IL_01fe: Unknown result type (might be due to invalid IL or missing references)
			//IL_0203: Unknown result type (might be due to invalid IL or missing references)
			//IL_020e: Expected O, but got Unknown
			//IL_020f: Expected O, but got Unknown
			//IL_022a: Unknown result type (might be due to invalid IL or missing references)
			//IL_022f: Unknown result type (might be due to invalid IL or missing references)
			//IL_0240: Expected O, but got Unknown
			//IL_024a: Unknown result type (might be due to invalid IL or missing references)
			//IL_024f: Unknown result type (might be due to invalid IL or missing references)
			//IL_025a: Expected O, but got Unknown
			//IL_025b: Expected O, but got Unknown
			//IL_0272: Unknown result type (might be due to invalid IL or missing references)
			//IL_0277: Unknown result type (might be due to invalid IL or missing references)
			//IL_0283: Expected O, but got Unknown
			//IL_0291: Unknown result type (might be due to invalid IL or missing references)
			//IL_0296: Unknown result type (might be due to invalid IL or missing references)
			//IL_02a1: Expected O, but got Unknown
			//IL_02a2: Expected O, but got Unknown
			//IL_02b1: Unknown result type (might be due to invalid IL or missing references)
			//IL_02b6: Unknown result type (might be due to invalid IL or missing references)
			//IL_02c7: Expected O, but got Unknown
			//IL_02c8: Expected O, but got Unknown
			string sql = "UPDATE programbuilderquerys SET \r\n\t\t\t\tProgramID=@ProgramID,Field=@Field,ShowTitle=@ShowTitle,Operators=@Operators,ControlName=@ControlName,InputType=@InputType,Width=@Width,Sort=@Sort,DataSource=@DataSource,DataSourceString=@DataSourceString,DataLinkID=@DataLinkID,IsQueryUsers=@IsQueryUsers,Value=@Value\r\n\t\t\t\tWHERE ID=@ID";
			MySqlParameter[] obj = new MySqlParameter[14];
			MySqlParameter val = new MySqlParameter("@ProgramID", 253, 36);
			((DbParameter)val).Value = model.ProgramID;
			obj[0] = val;
			MySqlParameter val2 = new MySqlParameter("@Field", 752, -1);
			((DbParameter)val2).Value = model.Field;
			obj[1] = val2;
			MySqlParameter val3 = new MySqlParameter("@ShowTitle", 752, -1);
			((DbParameter)val3).Value = model.ShowTitle;
			obj[2] = val3;
			MySqlParameter val4 = new MySqlParameter("@Operators", 253, 50);
			((DbParameter)val4).Value = model.Operators;
			obj[3] = val4;
			MySqlParameter val5 = new MySqlParameter("@ControlName", 253, 50);
			((DbParameter)val5).Value = model.ControlName;
			obj[4] = val5;
			MySqlParameter val6 = new MySqlParameter("@InputType", 3, 11);
			((DbParameter)val6).Value = model.InputType;
			obj[5] = val6;
			_003F val7;
			if (model.Width != null)
			{
				val7 = new MySqlParameter("@Width", 253, 50);
				((DbParameter)val7).Value = model.Width;
			}
			else
			{
				val7 = new MySqlParameter("@Width", 253, 50);
				((DbParameter)val7).Value = DBNull.Value;
			}
			obj[6] = val7;
			MySqlParameter val8 = new MySqlParameter("@Sort", 3, 11);
			((DbParameter)val8).Value = model.Sort;
			obj[7] = val8;
			_003F val9;
			if (model.DataSource.HasValue)
			{
				val9 = new MySqlParameter("@DataSource", 3, 11);
				((DbParameter)val9).Value = model.DataSource;
			}
			else
			{
				val9 = new MySqlParameter("@DataSource", 3, 11);
				((DbParameter)val9).Value = DBNull.Value;
			}
			obj[8] = val9;
			_003F val10;
			if (model.DataSourceString != null)
			{
				val10 = new MySqlParameter("@DataSourceString", 751, -1);
				((DbParameter)val10).Value = model.DataSourceString;
			}
			else
			{
				val10 = new MySqlParameter("@DataSourceString", 751, -1);
				((DbParameter)val10).Value = DBNull.Value;
			}
			obj[9] = val10;
			_003F val11;
			if (model.DataLinkID != null)
			{
				val11 = new MySqlParameter("@DataLinkID", 253, 50);
				((DbParameter)val11).Value = model.DataLinkID;
			}
			else
			{
				val11 = new MySqlParameter("@DataLinkID", 253, 50);
				((DbParameter)val11).Value = DBNull.Value;
			}
			obj[10] = val11;
			_003F val12;
			if (model.IsQueryUsers.HasValue)
			{
				val12 = new MySqlParameter("@IsQueryUsers", 3, 11);
				((DbParameter)val12).Value = model.IsQueryUsers;
			}
			else
			{
				val12 = new MySqlParameter("@IsQueryUsers", 3, 11);
				((DbParameter)val12).Value = DBNull.Value;
			}
			obj[11] = val12;
			_003F val13;
			if (model.Value != null)
			{
				val13 = new MySqlParameter("@Value", 253, 50);
				((DbParameter)val13).Value = model.Value;
			}
			else
			{
				val13 = new MySqlParameter("@Value", 253, 50);
				((DbParameter)val13).Value = DBNull.Value;
			}
			obj[12] = val13;
			MySqlParameter val14 = new MySqlParameter("@ID", 253, 36);
			((DbParameter)val14).Value = model.ID;
			obj[13] = val14;
			MySqlParameter[] parameter = (MySqlParameter[])obj;
			return dbHelper.Execute(sql, parameter);
		}

		public int Delete(Guid id)
		{
			//IL_001a: Unknown result type (might be due to invalid IL or missing references)
			//IL_001f: Unknown result type (might be due to invalid IL or missing references)
			//IL_0032: Expected O, but got Unknown
			//IL_0033: Expected O, but got Unknown
			string sql = "DELETE FROM programbuilderquerys WHERE ID=@ID";
			MySqlParameter[] obj = new MySqlParameter[1];
			MySqlParameter val = new MySqlParameter("@ID", 253, 36);
			((DbParameter)val).Value = id.ToString();
			obj[0] = val;
			MySqlParameter[] parameter = (MySqlParameter[])obj;
			return dbHelper.Execute(sql, parameter);
		}

		private List<RoadFlow.Data.Model.ProgramBuilderQuerys> DataReaderToList(MySqlDataReader dataReader)
		{
			List<RoadFlow.Data.Model.ProgramBuilderQuerys> list = new List<RoadFlow.Data.Model.ProgramBuilderQuerys>();
			RoadFlow.Data.Model.ProgramBuilderQuerys programBuilderQuerys = null;
			while (((DbDataReader)dataReader).Read())
			{
				programBuilderQuerys = new RoadFlow.Data.Model.ProgramBuilderQuerys();
				programBuilderQuerys.ID = ((DbDataReader)dataReader).GetString(0).ToGuid();
				programBuilderQuerys.ProgramID = ((DbDataReader)dataReader).GetString(1).ToGuid();
				programBuilderQuerys.Field = ((DbDataReader)dataReader).GetString(2);
				programBuilderQuerys.ShowTitle = ((DbDataReader)dataReader).GetString(3);
				programBuilderQuerys.Operators = ((DbDataReader)dataReader).GetString(4);
				programBuilderQuerys.ControlName = ((DbDataReader)dataReader).GetString(5);
				programBuilderQuerys.InputType = ((DbDataReader)dataReader).GetInt32(6);
				if (!((DbDataReader)dataReader).IsDBNull(7))
				{
					programBuilderQuerys.Width = ((DbDataReader)dataReader).GetString(7);
				}
				programBuilderQuerys.Sort = ((DbDataReader)dataReader).GetInt32(8);
				if (!((DbDataReader)dataReader).IsDBNull(9))
				{
					programBuilderQuerys.DataSource = ((DbDataReader)dataReader).GetInt32(9);
				}
				if (!((DbDataReader)dataReader).IsDBNull(10))
				{
					programBuilderQuerys.DataSourceString = ((DbDataReader)dataReader).GetString(10);
				}
				if (!((DbDataReader)dataReader).IsDBNull(11))
				{
					programBuilderQuerys.DataLinkID = ((DbDataReader)dataReader).GetString(11);
				}
				if (!((DbDataReader)dataReader).IsDBNull(12))
				{
					programBuilderQuerys.IsQueryUsers = ((DbDataReader)dataReader).GetInt32(12);
				}
				if (!((DbDataReader)dataReader).IsDBNull(13))
				{
					programBuilderQuerys.Value = ((DbDataReader)dataReader).GetString(13);
				}
				list.Add(programBuilderQuerys);
			}
			return list;
		}

		public List<RoadFlow.Data.Model.ProgramBuilderQuerys> GetAll()
		{
			string sql = "SELECT * FROM programbuilderquerys";
			MySqlDataReader dataReader = dbHelper.GetDataReader(sql);
			List<RoadFlow.Data.Model.ProgramBuilderQuerys> result = DataReaderToList(dataReader);
			((DbDataReader)dataReader).Close();
			return result;
		}

		public long GetCount()
		{
			string sql = "SELECT COUNT(*) FROM programbuilderquerys";
			long result;
			if (!long.TryParse(dbHelper.GetFieldValue(sql), out result))
			{
				return 0L;
			}
			return result;
		}

		public RoadFlow.Data.Model.ProgramBuilderQuerys Get(Guid id)
		{
			//IL_001a: Unknown result type (might be due to invalid IL or missing references)
			//IL_001f: Unknown result type (might be due to invalid IL or missing references)
			//IL_0032: Expected O, but got Unknown
			//IL_0033: Expected O, but got Unknown
			string sql = "SELECT * FROM programbuilderquerys WHERE ID=@ID";
			MySqlParameter[] obj = new MySqlParameter[1];
			MySqlParameter val = new MySqlParameter("@ID", 253, 36);
			((DbParameter)val).Value = id.ToString();
			obj[0] = val;
			MySqlParameter[] parameter = (MySqlParameter[])obj;
			MySqlDataReader dataReader = dbHelper.GetDataReader(sql, parameter);
			List<RoadFlow.Data.Model.ProgramBuilderQuerys> list = DataReaderToList(dataReader);
			((DbDataReader)dataReader).Close();
			if (list.Count <= 0)
			{
				return null;
			}
			return list[0];
		}

		public List<RoadFlow.Data.Model.ProgramBuilderQuerys> GetAll(Guid programID)
		{
			//IL_0018: Unknown result type (might be due to invalid IL or missing references)
			//IL_001d: Unknown result type (might be due to invalid IL or missing references)
			//IL_0030: Expected O, but got Unknown
			//IL_0031: Expected O, but got Unknown
			string sql = "SELECT * FROM ProgramBuilderQuerys WHERE ProgramID=@ProgramID";
			MySqlParameter[] obj = new MySqlParameter[1];
			MySqlParameter val = new MySqlParameter("@ProgramID", 253);
			((DbParameter)val).Value = programID.ToString();
			obj[0] = val;
			MySqlParameter[] parameter = (MySqlParameter[])obj;
			MySqlDataReader dataReader = dbHelper.GetDataReader(sql, parameter);
			List<RoadFlow.Data.Model.ProgramBuilderQuerys> result = DataReaderToList(dataReader);
			((DbDataReader)dataReader).Close();
			return result;
		}

		public int DeleteByProgramID(Guid id)
		{
			//IL_0018: Unknown result type (might be due to invalid IL or missing references)
			//IL_001d: Unknown result type (might be due to invalid IL or missing references)
			//IL_0030: Expected O, but got Unknown
			//IL_0031: Expected O, but got Unknown
			string sql = "DELETE FROM ProgramBuilderQuerys WHERE ProgramID=@ProgramID";
			MySqlParameter[] obj = new MySqlParameter[1];
			MySqlParameter val = new MySqlParameter("@ProgramID", 253);
			((DbParameter)val).Value = id.ToString();
			obj[0] = val;
			MySqlParameter[] parameter = (MySqlParameter[])obj;
			return dbHelper.Execute(sql, parameter);
		}
	}
}
