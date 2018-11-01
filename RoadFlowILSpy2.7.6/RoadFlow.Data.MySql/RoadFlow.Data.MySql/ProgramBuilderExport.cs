using MySql.Data.MySqlClient;
using RoadFlow.Data.Interface;
using RoadFlow.Data.Model;
using System;
using System.Collections.Generic;
using System.Data.Common;

namespace RoadFlow.Data.MySql
{
	public class ProgramBuilderExport : IProgramBuilderExport
	{
		private DBHelper dbHelper = new DBHelper();

		public int Add(RoadFlow.Data.Model.ProgramBuilderExport model)
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
			//IL_008b: Unknown result type (might be due to invalid IL or missing references)
			//IL_0090: Unknown result type (might be due to invalid IL or missing references)
			//IL_009c: Expected O, but got Unknown
			//IL_00a9: Unknown result type (might be due to invalid IL or missing references)
			//IL_00ae: Unknown result type (might be due to invalid IL or missing references)
			//IL_00b9: Expected O, but got Unknown
			//IL_00ba: Expected O, but got Unknown
			//IL_00c4: Unknown result type (might be due to invalid IL or missing references)
			//IL_00c9: Unknown result type (might be due to invalid IL or missing references)
			//IL_00da: Expected O, but got Unknown
			//IL_00db: Expected O, but got Unknown
			//IL_00f5: Unknown result type (might be due to invalid IL or missing references)
			//IL_00fa: Unknown result type (might be due to invalid IL or missing references)
			//IL_010b: Expected O, but got Unknown
			//IL_0115: Unknown result type (might be due to invalid IL or missing references)
			//IL_011a: Unknown result type (might be due to invalid IL or missing references)
			//IL_0125: Expected O, but got Unknown
			//IL_0126: Expected O, but got Unknown
			//IL_0140: Unknown result type (might be due to invalid IL or missing references)
			//IL_0145: Unknown result type (might be due to invalid IL or missing references)
			//IL_0156: Expected O, but got Unknown
			//IL_0160: Unknown result type (might be due to invalid IL or missing references)
			//IL_0165: Unknown result type (might be due to invalid IL or missing references)
			//IL_0170: Expected O, but got Unknown
			//IL_0171: Expected O, but got Unknown
			//IL_018b: Unknown result type (might be due to invalid IL or missing references)
			//IL_0190: Unknown result type (might be due to invalid IL or missing references)
			//IL_01a1: Expected O, but got Unknown
			//IL_01ab: Unknown result type (might be due to invalid IL or missing references)
			//IL_01b0: Unknown result type (might be due to invalid IL or missing references)
			//IL_01bb: Expected O, but got Unknown
			//IL_01bc: Expected O, but got Unknown
			//IL_01d2: Unknown result type (might be due to invalid IL or missing references)
			//IL_01d7: Unknown result type (might be due to invalid IL or missing references)
			//IL_01e3: Expected O, but got Unknown
			//IL_01f1: Unknown result type (might be due to invalid IL or missing references)
			//IL_01f6: Unknown result type (might be due to invalid IL or missing references)
			//IL_0201: Expected O, but got Unknown
			//IL_0202: Expected O, but got Unknown
			//IL_0218: Unknown result type (might be due to invalid IL or missing references)
			//IL_021d: Unknown result type (might be due to invalid IL or missing references)
			//IL_0229: Expected O, but got Unknown
			//IL_0236: Unknown result type (might be due to invalid IL or missing references)
			//IL_023b: Unknown result type (might be due to invalid IL or missing references)
			//IL_0246: Expected O, but got Unknown
			//IL_0247: Expected O, but got Unknown
			//IL_0252: Unknown result type (might be due to invalid IL or missing references)
			//IL_0257: Unknown result type (might be due to invalid IL or missing references)
			//IL_0268: Expected O, but got Unknown
			//IL_0269: Expected O, but got Unknown
			string sql = "INSERT INTO programbuilderexport\r\n\t\t\t\t(ID,ProgramID,Field,ShowTitle,Align,Width,ShowType,DataType,ShowFormat,CustomString,Sort) \r\n\t\t\t\tVALUES(@ID,@ProgramID,@Field,@ShowTitle,@Align,@Width,@ShowType,@DataType,@ShowFormat,@CustomString,@Sort)";
			MySqlParameter[] obj = new MySqlParameter[11];
			MySqlParameter val = new MySqlParameter("@ID", 253, 36);
			((DbParameter)val).Value = model.ID;
			obj[0] = val;
			MySqlParameter val2 = new MySqlParameter("@ProgramID", 253, 36);
			((DbParameter)val2).Value = model.ProgramID;
			obj[1] = val2;
			MySqlParameter val3 = new MySqlParameter("@Field", 752, -1);
			((DbParameter)val3).Value = model.Field;
			obj[2] = val3;
			_003F val4;
			if (model.ShowTitle != null)
			{
				val4 = new MySqlParameter("@ShowTitle", 752, -1);
				((DbParameter)val4).Value = model.ShowTitle;
			}
			else
			{
				val4 = new MySqlParameter("@ShowTitle", 752, -1);
				((DbParameter)val4).Value = DBNull.Value;
			}
			obj[3] = val4;
			MySqlParameter val5 = new MySqlParameter("@Align", 3, 11);
			((DbParameter)val5).Value = model.Align;
			obj[4] = val5;
			_003F val6;
			if (model.Width.HasValue)
			{
				val6 = new MySqlParameter("@Width", 3, 11);
				((DbParameter)val6).Value = model.Width;
			}
			else
			{
				val6 = new MySqlParameter("@Width", 3, 11);
				((DbParameter)val6).Value = DBNull.Value;
			}
			obj[5] = val6;
			_003F val7;
			if (model.ShowType.HasValue)
			{
				val7 = new MySqlParameter("@ShowType", 3, 11);
				((DbParameter)val7).Value = model.ShowType;
			}
			else
			{
				val7 = new MySqlParameter("@ShowType", 3, 11);
				((DbParameter)val7).Value = DBNull.Value;
			}
			obj[6] = val7;
			_003F val8;
			if (model.DataType.HasValue)
			{
				val8 = new MySqlParameter("@DataType", 3, 11);
				((DbParameter)val8).Value = model.DataType;
			}
			else
			{
				val8 = new MySqlParameter("@DataType", 3, 11);
				((DbParameter)val8).Value = DBNull.Value;
			}
			obj[7] = val8;
			_003F val9;
			if (model.ShowFormat != null)
			{
				val9 = new MySqlParameter("@ShowFormat", 253, 50);
				((DbParameter)val9).Value = model.ShowFormat;
			}
			else
			{
				val9 = new MySqlParameter("@ShowFormat", 253, 50);
				((DbParameter)val9).Value = DBNull.Value;
			}
			obj[8] = val9;
			_003F val10;
			if (model.CustomString != null)
			{
				val10 = new MySqlParameter("@CustomString", 752, -1);
				((DbParameter)val10).Value = model.CustomString;
			}
			else
			{
				val10 = new MySqlParameter("@CustomString", 752, -1);
				((DbParameter)val10).Value = DBNull.Value;
			}
			obj[9] = val10;
			MySqlParameter val11 = new MySqlParameter("@Sort", 3, 11);
			((DbParameter)val11).Value = model.Sort;
			obj[10] = val11;
			MySqlParameter[] parameter = (MySqlParameter[])obj;
			return dbHelper.Execute(sql, parameter);
		}

		public int Update(RoadFlow.Data.Model.ProgramBuilderExport model)
		{
			//IL_001b: Unknown result type (might be due to invalid IL or missing references)
			//IL_0020: Unknown result type (might be due to invalid IL or missing references)
			//IL_0031: Expected O, but got Unknown
			//IL_0032: Expected O, but got Unknown
			//IL_003f: Unknown result type (might be due to invalid IL or missing references)
			//IL_0044: Unknown result type (might be due to invalid IL or missing references)
			//IL_0050: Expected O, but got Unknown
			//IL_0051: Expected O, but got Unknown
			//IL_0066: Unknown result type (might be due to invalid IL or missing references)
			//IL_006b: Unknown result type (might be due to invalid IL or missing references)
			//IL_0077: Expected O, but got Unknown
			//IL_0084: Unknown result type (might be due to invalid IL or missing references)
			//IL_0089: Unknown result type (might be due to invalid IL or missing references)
			//IL_0094: Expected O, but got Unknown
			//IL_0095: Expected O, but got Unknown
			//IL_009f: Unknown result type (might be due to invalid IL or missing references)
			//IL_00a4: Unknown result type (might be due to invalid IL or missing references)
			//IL_00b5: Expected O, but got Unknown
			//IL_00b6: Expected O, but got Unknown
			//IL_00d0: Unknown result type (might be due to invalid IL or missing references)
			//IL_00d5: Unknown result type (might be due to invalid IL or missing references)
			//IL_00e6: Expected O, but got Unknown
			//IL_00f0: Unknown result type (might be due to invalid IL or missing references)
			//IL_00f5: Unknown result type (might be due to invalid IL or missing references)
			//IL_0100: Expected O, but got Unknown
			//IL_0101: Expected O, but got Unknown
			//IL_011b: Unknown result type (might be due to invalid IL or missing references)
			//IL_0120: Unknown result type (might be due to invalid IL or missing references)
			//IL_0131: Expected O, but got Unknown
			//IL_013b: Unknown result type (might be due to invalid IL or missing references)
			//IL_0140: Unknown result type (might be due to invalid IL or missing references)
			//IL_014b: Expected O, but got Unknown
			//IL_014c: Expected O, but got Unknown
			//IL_0166: Unknown result type (might be due to invalid IL or missing references)
			//IL_016b: Unknown result type (might be due to invalid IL or missing references)
			//IL_017c: Expected O, but got Unknown
			//IL_0186: Unknown result type (might be due to invalid IL or missing references)
			//IL_018b: Unknown result type (might be due to invalid IL or missing references)
			//IL_0196: Expected O, but got Unknown
			//IL_0197: Expected O, but got Unknown
			//IL_01ad: Unknown result type (might be due to invalid IL or missing references)
			//IL_01b2: Unknown result type (might be due to invalid IL or missing references)
			//IL_01be: Expected O, but got Unknown
			//IL_01cc: Unknown result type (might be due to invalid IL or missing references)
			//IL_01d1: Unknown result type (might be due to invalid IL or missing references)
			//IL_01dc: Expected O, but got Unknown
			//IL_01dd: Expected O, but got Unknown
			//IL_01f2: Unknown result type (might be due to invalid IL or missing references)
			//IL_01f7: Unknown result type (might be due to invalid IL or missing references)
			//IL_0203: Expected O, but got Unknown
			//IL_0210: Unknown result type (might be due to invalid IL or missing references)
			//IL_0215: Unknown result type (might be due to invalid IL or missing references)
			//IL_0220: Expected O, but got Unknown
			//IL_0221: Expected O, but got Unknown
			//IL_022c: Unknown result type (might be due to invalid IL or missing references)
			//IL_0231: Unknown result type (might be due to invalid IL or missing references)
			//IL_0242: Expected O, but got Unknown
			//IL_0243: Expected O, but got Unknown
			//IL_0252: Unknown result type (might be due to invalid IL or missing references)
			//IL_0257: Unknown result type (might be due to invalid IL or missing references)
			//IL_0268: Expected O, but got Unknown
			//IL_0269: Expected O, but got Unknown
			string sql = "UPDATE programbuilderexport SET \r\n\t\t\t\tProgramID=@ProgramID,Field=@Field,ShowTitle=@ShowTitle,Align=@Align,Width=@Width,ShowType=@ShowType,DataType=@DataType,ShowFormat=@ShowFormat,CustomString=@CustomString,Sort=@Sort\r\n\t\t\t\tWHERE ID=@ID";
			MySqlParameter[] obj = new MySqlParameter[11];
			MySqlParameter val = new MySqlParameter("@ProgramID", 253, 36);
			((DbParameter)val).Value = model.ProgramID;
			obj[0] = val;
			MySqlParameter val2 = new MySqlParameter("@Field", 752, -1);
			((DbParameter)val2).Value = model.Field;
			obj[1] = val2;
			_003F val3;
			if (model.ShowTitle != null)
			{
				val3 = new MySqlParameter("@ShowTitle", 752, -1);
				((DbParameter)val3).Value = model.ShowTitle;
			}
			else
			{
				val3 = new MySqlParameter("@ShowTitle", 752, -1);
				((DbParameter)val3).Value = DBNull.Value;
			}
			obj[2] = val3;
			MySqlParameter val4 = new MySqlParameter("@Align", 3, 11);
			((DbParameter)val4).Value = model.Align;
			obj[3] = val4;
			_003F val5;
			if (model.Width.HasValue)
			{
				val5 = new MySqlParameter("@Width", 3, 11);
				((DbParameter)val5).Value = model.Width;
			}
			else
			{
				val5 = new MySqlParameter("@Width", 3, 11);
				((DbParameter)val5).Value = DBNull.Value;
			}
			obj[4] = val5;
			_003F val6;
			if (model.ShowType.HasValue)
			{
				val6 = new MySqlParameter("@ShowType", 3, 11);
				((DbParameter)val6).Value = model.ShowType;
			}
			else
			{
				val6 = new MySqlParameter("@ShowType", 3, 11);
				((DbParameter)val6).Value = DBNull.Value;
			}
			obj[5] = val6;
			_003F val7;
			if (model.DataType.HasValue)
			{
				val7 = new MySqlParameter("@DataType", 3, 11);
				((DbParameter)val7).Value = model.DataType;
			}
			else
			{
				val7 = new MySqlParameter("@DataType", 3, 11);
				((DbParameter)val7).Value = DBNull.Value;
			}
			obj[6] = val7;
			_003F val8;
			if (model.ShowFormat != null)
			{
				val8 = new MySqlParameter("@ShowFormat", 253, 50);
				((DbParameter)val8).Value = model.ShowFormat;
			}
			else
			{
				val8 = new MySqlParameter("@ShowFormat", 253, 50);
				((DbParameter)val8).Value = DBNull.Value;
			}
			obj[7] = val8;
			_003F val9;
			if (model.CustomString != null)
			{
				val9 = new MySqlParameter("@CustomString", 752, -1);
				((DbParameter)val9).Value = model.CustomString;
			}
			else
			{
				val9 = new MySqlParameter("@CustomString", 752, -1);
				((DbParameter)val9).Value = DBNull.Value;
			}
			obj[8] = val9;
			MySqlParameter val10 = new MySqlParameter("@Sort", 3, 11);
			((DbParameter)val10).Value = model.Sort;
			obj[9] = val10;
			MySqlParameter val11 = new MySqlParameter("@ID", 253, 36);
			((DbParameter)val11).Value = model.ID;
			obj[10] = val11;
			MySqlParameter[] parameter = (MySqlParameter[])obj;
			return dbHelper.Execute(sql, parameter);
		}

		public int Delete(Guid id)
		{
			//IL_001a: Unknown result type (might be due to invalid IL or missing references)
			//IL_001f: Unknown result type (might be due to invalid IL or missing references)
			//IL_0032: Expected O, but got Unknown
			//IL_0033: Expected O, but got Unknown
			string sql = "DELETE FROM programbuilderexport WHERE ID=@ID";
			MySqlParameter[] obj = new MySqlParameter[1];
			MySqlParameter val = new MySqlParameter("@ID", 253, 36);
			((DbParameter)val).Value = id.ToString();
			obj[0] = val;
			MySqlParameter[] parameter = (MySqlParameter[])obj;
			return dbHelper.Execute(sql, parameter);
		}

		private List<RoadFlow.Data.Model.ProgramBuilderExport> DataReaderToList(MySqlDataReader dataReader)
		{
			List<RoadFlow.Data.Model.ProgramBuilderExport> list = new List<RoadFlow.Data.Model.ProgramBuilderExport>();
			RoadFlow.Data.Model.ProgramBuilderExport programBuilderExport = null;
			while (((DbDataReader)dataReader).Read())
			{
				programBuilderExport = new RoadFlow.Data.Model.ProgramBuilderExport();
				programBuilderExport.ID = ((DbDataReader)dataReader).GetString(0).ToGuid();
				programBuilderExport.ProgramID = ((DbDataReader)dataReader).GetString(1).ToGuid();
				programBuilderExport.Field = ((DbDataReader)dataReader).GetString(2);
				if (!((DbDataReader)dataReader).IsDBNull(3))
				{
					programBuilderExport.ShowTitle = ((DbDataReader)dataReader).GetString(3);
				}
				programBuilderExport.Align = ((DbDataReader)dataReader).GetInt32(4);
				if (!((DbDataReader)dataReader).IsDBNull(5))
				{
					programBuilderExport.Width = ((DbDataReader)dataReader).GetInt32(5);
				}
				if (!((DbDataReader)dataReader).IsDBNull(6))
				{
					programBuilderExport.ShowType = ((DbDataReader)dataReader).GetInt32(6);
				}
				if (!((DbDataReader)dataReader).IsDBNull(7))
				{
					programBuilderExport.DataType = ((DbDataReader)dataReader).GetInt32(7);
				}
				if (!((DbDataReader)dataReader).IsDBNull(8))
				{
					programBuilderExport.ShowFormat = ((DbDataReader)dataReader).GetString(8);
				}
				if (!((DbDataReader)dataReader).IsDBNull(9))
				{
					programBuilderExport.CustomString = ((DbDataReader)dataReader).GetString(9);
				}
				programBuilderExport.Sort = ((DbDataReader)dataReader).GetInt32(10);
				list.Add(programBuilderExport);
			}
			return list;
		}

		public List<RoadFlow.Data.Model.ProgramBuilderExport> GetAll()
		{
			string sql = "SELECT * FROM programbuilderexport";
			MySqlDataReader dataReader = dbHelper.GetDataReader(sql);
			List<RoadFlow.Data.Model.ProgramBuilderExport> result = DataReaderToList(dataReader);
			((DbDataReader)dataReader).Close();
			return result;
		}

		public long GetCount()
		{
			string sql = "SELECT COUNT(*) FROM programbuilderexport";
			long result;
			if (!long.TryParse(dbHelper.GetFieldValue(sql), out result))
			{
				return 0L;
			}
			return result;
		}

		public RoadFlow.Data.Model.ProgramBuilderExport Get(Guid id)
		{
			//IL_001a: Unknown result type (might be due to invalid IL or missing references)
			//IL_001f: Unknown result type (might be due to invalid IL or missing references)
			//IL_0032: Expected O, but got Unknown
			//IL_0033: Expected O, but got Unknown
			string sql = "SELECT * FROM programbuilderexport WHERE ID=@ID";
			MySqlParameter[] obj = new MySqlParameter[1];
			MySqlParameter val = new MySqlParameter("@ID", 253, 36);
			((DbParameter)val).Value = id.ToString();
			obj[0] = val;
			MySqlParameter[] parameter = (MySqlParameter[])obj;
			MySqlDataReader dataReader = dbHelper.GetDataReader(sql, parameter);
			List<RoadFlow.Data.Model.ProgramBuilderExport> list = DataReaderToList(dataReader);
			((DbDataReader)dataReader).Close();
			if (list.Count <= 0)
			{
				return null;
			}
			return list[0];
		}

		public List<RoadFlow.Data.Model.ProgramBuilderExport> GetAll(Guid programID)
		{
			//IL_0018: Unknown result type (might be due to invalid IL or missing references)
			//IL_001d: Unknown result type (might be due to invalid IL or missing references)
			//IL_0030: Expected O, but got Unknown
			//IL_0031: Expected O, but got Unknown
			string sql = "SELECT * FROM ProgramBuilderExport WHERE ProgramID=@ProgramID";
			MySqlParameter[] obj = new MySqlParameter[1];
			MySqlParameter val = new MySqlParameter("@ProgramID", 253);
			((DbParameter)val).Value = programID.ToString();
			obj[0] = val;
			MySqlParameter[] parameter = (MySqlParameter[])obj;
			MySqlDataReader dataReader = dbHelper.GetDataReader(sql, parameter);
			List<RoadFlow.Data.Model.ProgramBuilderExport> result = DataReaderToList(dataReader);
			((DbDataReader)dataReader).Close();
			return result;
		}
	}
}
