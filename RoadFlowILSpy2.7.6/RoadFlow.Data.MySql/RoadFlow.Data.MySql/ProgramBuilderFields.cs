using MySql.Data.MySqlClient;
using RoadFlow.Data.Interface;
using RoadFlow.Data.Model;
using System;
using System.Collections.Generic;
using System.Data.Common;

namespace RoadFlow.Data.MySql
{
	public class ProgramBuilderFields : IProgramBuilderFields
	{
		private DBHelper dbHelper = new DBHelper();

		public int Add(RoadFlow.Data.Model.ProgramBuilderFields model)
		{
			//IL_001b: Unknown result type (might be due to invalid IL or missing references)
			//IL_0020: Unknown result type (might be due to invalid IL or missing references)
			//IL_0031: Expected O, but got Unknown
			//IL_0032: Expected O, but got Unknown
			//IL_0040: Unknown result type (might be due to invalid IL or missing references)
			//IL_0045: Unknown result type (might be due to invalid IL or missing references)
			//IL_0056: Expected O, but got Unknown
			//IL_0057: Expected O, but got Unknown
			//IL_006c: Unknown result type (might be due to invalid IL or missing references)
			//IL_0071: Unknown result type (might be due to invalid IL or missing references)
			//IL_007d: Expected O, but got Unknown
			//IL_008a: Unknown result type (might be due to invalid IL or missing references)
			//IL_008f: Unknown result type (might be due to invalid IL or missing references)
			//IL_009a: Expected O, but got Unknown
			//IL_009b: Expected O, but got Unknown
			//IL_00a8: Unknown result type (might be due to invalid IL or missing references)
			//IL_00ad: Unknown result type (might be due to invalid IL or missing references)
			//IL_00b9: Expected O, but got Unknown
			//IL_00ba: Expected O, but got Unknown
			//IL_00c8: Unknown result type (might be due to invalid IL or missing references)
			//IL_00cd: Unknown result type (might be due to invalid IL or missing references)
			//IL_00d9: Expected O, but got Unknown
			//IL_00da: Expected O, but got Unknown
			//IL_00f0: Unknown result type (might be due to invalid IL or missing references)
			//IL_00f5: Unknown result type (might be due to invalid IL or missing references)
			//IL_0101: Expected O, but got Unknown
			//IL_010f: Unknown result type (might be due to invalid IL or missing references)
			//IL_0114: Unknown result type (might be due to invalid IL or missing references)
			//IL_011f: Expected O, but got Unknown
			//IL_0120: Expected O, but got Unknown
			//IL_012a: Unknown result type (might be due to invalid IL or missing references)
			//IL_012f: Unknown result type (might be due to invalid IL or missing references)
			//IL_0140: Expected O, but got Unknown
			//IL_0141: Expected O, but got Unknown
			//IL_0157: Unknown result type (might be due to invalid IL or missing references)
			//IL_015c: Unknown result type (might be due to invalid IL or missing references)
			//IL_0168: Expected O, but got Unknown
			//IL_0176: Unknown result type (might be due to invalid IL or missing references)
			//IL_017b: Unknown result type (might be due to invalid IL or missing references)
			//IL_0186: Expected O, but got Unknown
			//IL_0187: Expected O, but got Unknown
			//IL_019c: Unknown result type (might be due to invalid IL or missing references)
			//IL_01a1: Unknown result type (might be due to invalid IL or missing references)
			//IL_01ad: Expected O, but got Unknown
			//IL_01ba: Unknown result type (might be due to invalid IL or missing references)
			//IL_01bf: Unknown result type (might be due to invalid IL or missing references)
			//IL_01ca: Expected O, but got Unknown
			//IL_01cb: Expected O, but got Unknown
			//IL_01d6: Unknown result type (might be due to invalid IL or missing references)
			//IL_01db: Unknown result type (might be due to invalid IL or missing references)
			//IL_01ec: Expected O, but got Unknown
			//IL_01ed: Expected O, but got Unknown
			string sql = "INSERT INTO programbuilderfields\r\n\t\t\t\t(ID,ProgramID,Field,ShowTitle,Align,Width,ShowType,ShowFormat,CustomString,Sort) \r\n\t\t\t\tVALUES(@ID,@ProgramID,@Field,@ShowTitle,@Align,@Width,@ShowType,@ShowFormat,@CustomString,@Sort)";
			MySqlParameter[] obj = new MySqlParameter[10];
			MySqlParameter val = new MySqlParameter("@ID", 253, 36);
			((DbParameter)val).Value = model.ID;
			obj[0] = val;
			MySqlParameter val2 = new MySqlParameter("@ProgramID", 253, 36);
			((DbParameter)val2).Value = model.ProgramID;
			obj[1] = val2;
			_003F val3;
			if (model.Field != null)
			{
				val3 = new MySqlParameter("@Field", 752, -1);
				((DbParameter)val3).Value = model.Field;
			}
			else
			{
				val3 = new MySqlParameter("@Field", 752, -1);
				((DbParameter)val3).Value = DBNull.Value;
			}
			obj[2] = val3;
			MySqlParameter val4 = new MySqlParameter("@ShowTitle", 751, -1);
			((DbParameter)val4).Value = model.ShowTitle;
			obj[3] = val4;
			MySqlParameter val5 = new MySqlParameter("@Align", 253, 50);
			((DbParameter)val5).Value = model.Align;
			obj[4] = val5;
			_003F val6;
			if (model.Width != null)
			{
				val6 = new MySqlParameter("@Width", 253, 50);
				((DbParameter)val6).Value = model.Width;
			}
			else
			{
				val6 = new MySqlParameter("@Width", 253, 50);
				((DbParameter)val6).Value = DBNull.Value;
			}
			obj[5] = val6;
			MySqlParameter val7 = new MySqlParameter("@ShowType", 3, 11);
			((DbParameter)val7).Value = model.ShowType;
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
				val9 = new MySqlParameter("@CustomString", 751, -1);
				((DbParameter)val9).Value = model.CustomString;
			}
			else
			{
				val9 = new MySqlParameter("@CustomString", 751, -1);
				((DbParameter)val9).Value = DBNull.Value;
			}
			obj[8] = val9;
			MySqlParameter val10 = new MySqlParameter("@Sort", 3, 11);
			((DbParameter)val10).Value = model.Sort;
			obj[9] = val10;
			MySqlParameter[] parameter = (MySqlParameter[])obj;
			return dbHelper.Execute(sql, parameter);
		}

		public int Update(RoadFlow.Data.Model.ProgramBuilderFields model)
		{
			//IL_001b: Unknown result type (might be due to invalid IL or missing references)
			//IL_0020: Unknown result type (might be due to invalid IL or missing references)
			//IL_0031: Expected O, but got Unknown
			//IL_0032: Expected O, but got Unknown
			//IL_0047: Unknown result type (might be due to invalid IL or missing references)
			//IL_004c: Unknown result type (might be due to invalid IL or missing references)
			//IL_0058: Expected O, but got Unknown
			//IL_0065: Unknown result type (might be due to invalid IL or missing references)
			//IL_006a: Unknown result type (might be due to invalid IL or missing references)
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
			//IL_00cb: Unknown result type (might be due to invalid IL or missing references)
			//IL_00d0: Unknown result type (might be due to invalid IL or missing references)
			//IL_00dc: Expected O, but got Unknown
			//IL_00ea: Unknown result type (might be due to invalid IL or missing references)
			//IL_00ef: Unknown result type (might be due to invalid IL or missing references)
			//IL_00fa: Expected O, but got Unknown
			//IL_00fb: Expected O, but got Unknown
			//IL_0105: Unknown result type (might be due to invalid IL or missing references)
			//IL_010a: Unknown result type (might be due to invalid IL or missing references)
			//IL_011b: Expected O, but got Unknown
			//IL_011c: Expected O, but got Unknown
			//IL_0132: Unknown result type (might be due to invalid IL or missing references)
			//IL_0137: Unknown result type (might be due to invalid IL or missing references)
			//IL_0143: Expected O, but got Unknown
			//IL_0151: Unknown result type (might be due to invalid IL or missing references)
			//IL_0156: Unknown result type (might be due to invalid IL or missing references)
			//IL_0161: Expected O, but got Unknown
			//IL_0162: Expected O, but got Unknown
			//IL_0177: Unknown result type (might be due to invalid IL or missing references)
			//IL_017c: Unknown result type (might be due to invalid IL or missing references)
			//IL_0188: Expected O, but got Unknown
			//IL_0195: Unknown result type (might be due to invalid IL or missing references)
			//IL_019a: Unknown result type (might be due to invalid IL or missing references)
			//IL_01a5: Expected O, but got Unknown
			//IL_01a6: Expected O, but got Unknown
			//IL_01b0: Unknown result type (might be due to invalid IL or missing references)
			//IL_01b5: Unknown result type (might be due to invalid IL or missing references)
			//IL_01c6: Expected O, but got Unknown
			//IL_01c7: Expected O, but got Unknown
			//IL_01d6: Unknown result type (might be due to invalid IL or missing references)
			//IL_01db: Unknown result type (might be due to invalid IL or missing references)
			//IL_01ec: Expected O, but got Unknown
			//IL_01ed: Expected O, but got Unknown
			string sql = "UPDATE programbuilderfields SET \r\n\t\t\t\tProgramID=@ProgramID,Field=@Field,ShowTitle=@ShowTitle,Align=@Align,Width=@Width,ShowType=@ShowType,ShowFormat=@ShowFormat,CustomString=@CustomString,Sort=@Sort\r\n\t\t\t\tWHERE ID=@ID";
			MySqlParameter[] obj = new MySqlParameter[10];
			MySqlParameter val = new MySqlParameter("@ProgramID", 253, 36);
			((DbParameter)val).Value = model.ProgramID;
			obj[0] = val;
			_003F val2;
			if (model.Field != null)
			{
				val2 = new MySqlParameter("@Field", 752, -1);
				((DbParameter)val2).Value = model.Field;
			}
			else
			{
				val2 = new MySqlParameter("@Field", 752, -1);
				((DbParameter)val2).Value = DBNull.Value;
			}
			obj[1] = val2;
			MySqlParameter val3 = new MySqlParameter("@ShowTitle", 751, -1);
			((DbParameter)val3).Value = model.ShowTitle;
			obj[2] = val3;
			MySqlParameter val4 = new MySqlParameter("@Align", 253, 50);
			((DbParameter)val4).Value = model.Align;
			obj[3] = val4;
			_003F val5;
			if (model.Width != null)
			{
				val5 = new MySqlParameter("@Width", 253, 50);
				((DbParameter)val5).Value = model.Width;
			}
			else
			{
				val5 = new MySqlParameter("@Width", 253, 50);
				((DbParameter)val5).Value = DBNull.Value;
			}
			obj[4] = val5;
			MySqlParameter val6 = new MySqlParameter("@ShowType", 3, 11);
			((DbParameter)val6).Value = model.ShowType;
			obj[5] = val6;
			_003F val7;
			if (model.ShowFormat != null)
			{
				val7 = new MySqlParameter("@ShowFormat", 253, 50);
				((DbParameter)val7).Value = model.ShowFormat;
			}
			else
			{
				val7 = new MySqlParameter("@ShowFormat", 253, 50);
				((DbParameter)val7).Value = DBNull.Value;
			}
			obj[6] = val7;
			_003F val8;
			if (model.CustomString != null)
			{
				val8 = new MySqlParameter("@CustomString", 751, -1);
				((DbParameter)val8).Value = model.CustomString;
			}
			else
			{
				val8 = new MySqlParameter("@CustomString", 751, -1);
				((DbParameter)val8).Value = DBNull.Value;
			}
			obj[7] = val8;
			MySqlParameter val9 = new MySqlParameter("@Sort", 3, 11);
			((DbParameter)val9).Value = model.Sort;
			obj[8] = val9;
			MySqlParameter val10 = new MySqlParameter("@ID", 253, 36);
			((DbParameter)val10).Value = model.ID;
			obj[9] = val10;
			MySqlParameter[] parameter = (MySqlParameter[])obj;
			return dbHelper.Execute(sql, parameter);
		}

		public int Delete(Guid id)
		{
			//IL_001a: Unknown result type (might be due to invalid IL or missing references)
			//IL_001f: Unknown result type (might be due to invalid IL or missing references)
			//IL_0032: Expected O, but got Unknown
			//IL_0033: Expected O, but got Unknown
			string sql = "DELETE FROM programbuilderfields WHERE ID=@ID";
			MySqlParameter[] obj = new MySqlParameter[1];
			MySqlParameter val = new MySqlParameter("@ID", 253, 36);
			((DbParameter)val).Value = id.ToString();
			obj[0] = val;
			MySqlParameter[] parameter = (MySqlParameter[])obj;
			return dbHelper.Execute(sql, parameter);
		}

		private List<RoadFlow.Data.Model.ProgramBuilderFields> DataReaderToList(MySqlDataReader dataReader)
		{
			List<RoadFlow.Data.Model.ProgramBuilderFields> list = new List<RoadFlow.Data.Model.ProgramBuilderFields>();
			RoadFlow.Data.Model.ProgramBuilderFields programBuilderFields = null;
			while (((DbDataReader)dataReader).Read())
			{
				programBuilderFields = new RoadFlow.Data.Model.ProgramBuilderFields();
				programBuilderFields.ID = ((DbDataReader)dataReader).GetString(0).ToGuid();
				programBuilderFields.ProgramID = ((DbDataReader)dataReader).GetString(1).ToGuid();
				if (!((DbDataReader)dataReader).IsDBNull(2))
				{
					programBuilderFields.Field = ((DbDataReader)dataReader).GetString(2);
				}
				programBuilderFields.ShowTitle = ((DbDataReader)dataReader).GetString(3);
				programBuilderFields.Align = ((DbDataReader)dataReader).GetString(4);
				if (!((DbDataReader)dataReader).IsDBNull(5))
				{
					programBuilderFields.Width = ((DbDataReader)dataReader).GetString(5);
				}
				programBuilderFields.ShowType = ((DbDataReader)dataReader).GetInt32(6);
				if (!((DbDataReader)dataReader).IsDBNull(7))
				{
					programBuilderFields.ShowFormat = ((DbDataReader)dataReader).GetString(7);
				}
				if (!((DbDataReader)dataReader).IsDBNull(8))
				{
					programBuilderFields.CustomString = ((DbDataReader)dataReader).GetString(8);
				}
				programBuilderFields.Sort = ((DbDataReader)dataReader).GetInt32(9);
				list.Add(programBuilderFields);
			}
			return list;
		}

		public List<RoadFlow.Data.Model.ProgramBuilderFields> GetAll()
		{
			string sql = "SELECT * FROM programbuilderfields";
			MySqlDataReader dataReader = dbHelper.GetDataReader(sql);
			List<RoadFlow.Data.Model.ProgramBuilderFields> result = DataReaderToList(dataReader);
			((DbDataReader)dataReader).Close();
			return result;
		}

		public long GetCount()
		{
			string sql = "SELECT COUNT(*) FROM programbuilderfields";
			long result;
			if (!long.TryParse(dbHelper.GetFieldValue(sql), out result))
			{
				return 0L;
			}
			return result;
		}

		public RoadFlow.Data.Model.ProgramBuilderFields Get(Guid id)
		{
			//IL_001a: Unknown result type (might be due to invalid IL or missing references)
			//IL_001f: Unknown result type (might be due to invalid IL or missing references)
			//IL_0032: Expected O, but got Unknown
			//IL_0033: Expected O, but got Unknown
			string sql = "SELECT * FROM programbuilderfields WHERE ID=@ID";
			MySqlParameter[] obj = new MySqlParameter[1];
			MySqlParameter val = new MySqlParameter("@ID", 253, 36);
			((DbParameter)val).Value = id.ToString();
			obj[0] = val;
			MySqlParameter[] parameter = (MySqlParameter[])obj;
			MySqlDataReader dataReader = dbHelper.GetDataReader(sql, parameter);
			List<RoadFlow.Data.Model.ProgramBuilderFields> list = DataReaderToList(dataReader);
			((DbDataReader)dataReader).Close();
			if (list.Count <= 0)
			{
				return null;
			}
			return list[0];
		}

		public List<RoadFlow.Data.Model.ProgramBuilderFields> GetAll(Guid programID)
		{
			//IL_0018: Unknown result type (might be due to invalid IL or missing references)
			//IL_001d: Unknown result type (might be due to invalid IL or missing references)
			//IL_0030: Expected O, but got Unknown
			//IL_0031: Expected O, but got Unknown
			string sql = "SELECT * FROM ProgramBuilderFields WHERE ProgramID=@ProgramID";
			MySqlParameter[] obj = new MySqlParameter[1];
			MySqlParameter val = new MySqlParameter("@ProgramID", 253);
			((DbParameter)val).Value = programID.ToString();
			obj[0] = val;
			MySqlParameter[] parameter = (MySqlParameter[])obj;
			MySqlDataReader dataReader = dbHelper.GetDataReader(sql, parameter);
			List<RoadFlow.Data.Model.ProgramBuilderFields> result = DataReaderToList(dataReader);
			((DbDataReader)dataReader).Close();
			return result;
		}

		public int DeleteByProgramID(Guid id)
		{
			//IL_0018: Unknown result type (might be due to invalid IL or missing references)
			//IL_001d: Unknown result type (might be due to invalid IL or missing references)
			//IL_0030: Expected O, but got Unknown
			//IL_0031: Expected O, but got Unknown
			string sql = "DELETE FROM ProgramBuilderFields WHERE ProgramID=@ProgramID";
			MySqlParameter[] obj = new MySqlParameter[1];
			MySqlParameter val = new MySqlParameter("@ProgramID", 253);
			((DbParameter)val).Value = id.ToString();
			obj[0] = val;
			MySqlParameter[] parameter = (MySqlParameter[])obj;
			return dbHelper.Execute(sql, parameter);
		}
	}
}
