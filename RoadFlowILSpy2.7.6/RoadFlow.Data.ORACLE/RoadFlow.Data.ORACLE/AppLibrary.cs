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
	public class AppLibrary : IAppLibrary
	{
		private DBHelper dbHelper = new DBHelper();

		public int Add(RoadFlow.Data.Model.AppLibrary model)
		{
			//IL_0018: Unknown result type (might be due to invalid IL or missing references)
			//IL_001d: Unknown result type (might be due to invalid IL or missing references)
			//IL_002e: Expected O, but got Unknown
			//IL_002f: Expected O, but got Unknown
			//IL_003d: Unknown result type (might be due to invalid IL or missing references)
			//IL_0042: Unknown result type (might be due to invalid IL or missing references)
			//IL_004e: Expected O, but got Unknown
			//IL_004f: Expected O, but got Unknown
			//IL_005d: Unknown result type (might be due to invalid IL or missing references)
			//IL_0062: Unknown result type (might be due to invalid IL or missing references)
			//IL_006e: Expected O, but got Unknown
			//IL_006f: Expected O, but got Unknown
			//IL_007a: Unknown result type (might be due to invalid IL or missing references)
			//IL_007f: Unknown result type (might be due to invalid IL or missing references)
			//IL_0090: Expected O, but got Unknown
			//IL_0091: Expected O, but got Unknown
			//IL_009a: Unknown result type (might be due to invalid IL or missing references)
			//IL_009f: Unknown result type (might be due to invalid IL or missing references)
			//IL_00b0: Expected O, but got Unknown
			//IL_00b1: Expected O, but got Unknown
			//IL_00ca: Unknown result type (might be due to invalid IL or missing references)
			//IL_00cf: Unknown result type (might be due to invalid IL or missing references)
			//IL_00e0: Expected O, but got Unknown
			//IL_00e9: Unknown result type (might be due to invalid IL or missing references)
			//IL_00ee: Unknown result type (might be due to invalid IL or missing references)
			//IL_00f9: Expected O, but got Unknown
			//IL_00fa: Expected O, but got Unknown
			//IL_0113: Unknown result type (might be due to invalid IL or missing references)
			//IL_0118: Unknown result type (might be due to invalid IL or missing references)
			//IL_0129: Expected O, but got Unknown
			//IL_0132: Unknown result type (might be due to invalid IL or missing references)
			//IL_0137: Unknown result type (might be due to invalid IL or missing references)
			//IL_0142: Expected O, but got Unknown
			//IL_0143: Expected O, but got Unknown
			//IL_0154: Unknown result type (might be due to invalid IL or missing references)
			//IL_0159: Unknown result type (might be due to invalid IL or missing references)
			//IL_0165: Expected O, but got Unknown
			//IL_016e: Unknown result type (might be due to invalid IL or missing references)
			//IL_0173: Unknown result type (might be due to invalid IL or missing references)
			//IL_017e: Expected O, but got Unknown
			//IL_017f: Expected O, but got Unknown
			//IL_0190: Unknown result type (might be due to invalid IL or missing references)
			//IL_0195: Unknown result type (might be due to invalid IL or missing references)
			//IL_01a1: Expected O, but got Unknown
			//IL_01aa: Unknown result type (might be due to invalid IL or missing references)
			//IL_01af: Unknown result type (might be due to invalid IL or missing references)
			//IL_01ba: Expected O, but got Unknown
			//IL_01bb: Expected O, but got Unknown
			//IL_01cd: Unknown result type (might be due to invalid IL or missing references)
			//IL_01d2: Unknown result type (might be due to invalid IL or missing references)
			//IL_01de: Expected O, but got Unknown
			//IL_01e7: Unknown result type (might be due to invalid IL or missing references)
			//IL_01ec: Unknown result type (might be due to invalid IL or missing references)
			//IL_01f7: Expected O, but got Unknown
			//IL_01f8: Expected O, but got Unknown
			//IL_020c: Unknown result type (might be due to invalid IL or missing references)
			//IL_0211: Unknown result type (might be due to invalid IL or missing references)
			//IL_021d: Expected O, but got Unknown
			//IL_0228: Unknown result type (might be due to invalid IL or missing references)
			//IL_022d: Unknown result type (might be due to invalid IL or missing references)
			//IL_0238: Expected O, but got Unknown
			//IL_0239: Expected O, but got Unknown
			//IL_024b: Unknown result type (might be due to invalid IL or missing references)
			//IL_0250: Unknown result type (might be due to invalid IL or missing references)
			//IL_025c: Expected O, but got Unknown
			//IL_0265: Unknown result type (might be due to invalid IL or missing references)
			//IL_026a: Unknown result type (might be due to invalid IL or missing references)
			//IL_0275: Expected O, but got Unknown
			//IL_0276: Expected O, but got Unknown
			//IL_0288: Unknown result type (might be due to invalid IL or missing references)
			//IL_028d: Unknown result type (might be due to invalid IL or missing references)
			//IL_0299: Expected O, but got Unknown
			//IL_02a2: Unknown result type (might be due to invalid IL or missing references)
			//IL_02a7: Unknown result type (might be due to invalid IL or missing references)
			//IL_02b2: Expected O, but got Unknown
			//IL_02b3: Expected O, but got Unknown
			string sql = "INSERT INTO AppLibrary\r\n\t\t\t\t(ID,Title,Address,Type,OpenMode,Width,Height,Params,Manager,Note,Code,Ico,Color) \r\n\t\t\t\tVALUES(:ID,:Title,:Address,:Type,:OpenMode,:Width,:Height,:Params,:Manager,:Note,:Code,:Ico,:Color)";
			OracleParameter[] obj = new OracleParameter[13];
			OracleParameter val = new OracleParameter(":ID", 126, 40);
			((DbParameter)val).Value = model.ID;
			obj[0] = val;
			OracleParameter val2 = new OracleParameter(":Title", 119, 510);
			((DbParameter)val2).Value = model.Title;
			obj[1] = val2;
			OracleParameter val3 = new OracleParameter(":Address", 126, 200);
			((DbParameter)val3).Value = model.Address;
			obj[2] = val3;
			OracleParameter val4 = new OracleParameter(":Type", 126, 40);
			((DbParameter)val4).Value = model.Type;
			obj[3] = val4;
			OracleParameter val5 = new OracleParameter(":OpenMode", 112);
			((DbParameter)val5).Value = model.OpenMode;
			obj[4] = val5;
			_003F val6;
			if (model.Width.HasValue)
			{
				val6 = new OracleParameter(":Width", 112);
				((DbParameter)val6).Value = model.Width;
			}
			else
			{
				val6 = new OracleParameter(":Width", 112);
				((DbParameter)val6).Value = DBNull.Value;
			}
			obj[5] = val6;
			_003F val7;
			if (model.Height.HasValue)
			{
				val7 = new OracleParameter(":Height", 112);
				((DbParameter)val7).Value = model.Height;
			}
			else
			{
				val7 = new OracleParameter(":Height", 112);
				((DbParameter)val7).Value = DBNull.Value;
			}
			obj[6] = val7;
			_003F val8;
			if (model.Params != null)
			{
				val8 = new OracleParameter(":Params", 105);
				((DbParameter)val8).Value = model.Params;
			}
			else
			{
				val8 = new OracleParameter(":Params", 105);
				((DbParameter)val8).Value = DBNull.Value;
			}
			obj[7] = val8;
			_003F val9;
			if (model.Manager != null)
			{
				val9 = new OracleParameter(":Manager", 105);
				((DbParameter)val9).Value = model.Manager;
			}
			else
			{
				val9 = new OracleParameter(":Manager", 105);
				((DbParameter)val9).Value = DBNull.Value;
			}
			obj[8] = val9;
			_003F val10;
			if (model.Note != null)
			{
				val10 = new OracleParameter(":Note", 105);
				((DbParameter)val10).Value = model.Note;
			}
			else
			{
				val10 = new OracleParameter(":Note", 105);
				((DbParameter)val10).Value = DBNull.Value;
			}
			obj[9] = val10;
			_003F val11;
			if (model.Code != null)
			{
				val11 = new OracleParameter(":Code", 126, 50);
				((DbParameter)val11).Value = model.Code;
			}
			else
			{
				val11 = new OracleParameter(":Code", 126, 50);
				((DbParameter)val11).Value = DBNull.Value;
			}
			obj[10] = val11;
			_003F val12;
			if (model.Ico != null)
			{
				val12 = new OracleParameter(":Ico", 126);
				((DbParameter)val12).Value = model.Ico;
			}
			else
			{
				val12 = new OracleParameter(":Ico", 126);
				((DbParameter)val12).Value = DBNull.Value;
			}
			obj[11] = val12;
			_003F val13;
			if (model.Color != null)
			{
				val13 = new OracleParameter(":Color", 126);
				((DbParameter)val13).Value = model.Color;
			}
			else
			{
				val13 = new OracleParameter(":Color", 126);
				((DbParameter)val13).Value = DBNull.Value;
			}
			obj[12] = val13;
			OracleParameter[] parameter = (OracleParameter[])obj;
			return dbHelper.Execute(sql, parameter);
		}

		public int Update(RoadFlow.Data.Model.AppLibrary model)
		{
			//IL_001b: Unknown result type (might be due to invalid IL or missing references)
			//IL_0020: Unknown result type (might be due to invalid IL or missing references)
			//IL_002c: Expected O, but got Unknown
			//IL_002d: Expected O, but got Unknown
			//IL_003b: Unknown result type (might be due to invalid IL or missing references)
			//IL_0040: Unknown result type (might be due to invalid IL or missing references)
			//IL_004c: Expected O, but got Unknown
			//IL_004d: Expected O, but got Unknown
			//IL_0058: Unknown result type (might be due to invalid IL or missing references)
			//IL_005d: Unknown result type (might be due to invalid IL or missing references)
			//IL_006e: Expected O, but got Unknown
			//IL_006f: Expected O, but got Unknown
			//IL_0078: Unknown result type (might be due to invalid IL or missing references)
			//IL_007d: Unknown result type (might be due to invalid IL or missing references)
			//IL_008e: Expected O, but got Unknown
			//IL_008f: Expected O, but got Unknown
			//IL_00a8: Unknown result type (might be due to invalid IL or missing references)
			//IL_00ad: Unknown result type (might be due to invalid IL or missing references)
			//IL_00be: Expected O, but got Unknown
			//IL_00c7: Unknown result type (might be due to invalid IL or missing references)
			//IL_00cc: Unknown result type (might be due to invalid IL or missing references)
			//IL_00d7: Expected O, but got Unknown
			//IL_00d8: Expected O, but got Unknown
			//IL_00f1: Unknown result type (might be due to invalid IL or missing references)
			//IL_00f6: Unknown result type (might be due to invalid IL or missing references)
			//IL_0107: Expected O, but got Unknown
			//IL_0110: Unknown result type (might be due to invalid IL or missing references)
			//IL_0115: Unknown result type (might be due to invalid IL or missing references)
			//IL_0120: Expected O, but got Unknown
			//IL_0121: Expected O, but got Unknown
			//IL_0132: Unknown result type (might be due to invalid IL or missing references)
			//IL_0137: Unknown result type (might be due to invalid IL or missing references)
			//IL_0143: Expected O, but got Unknown
			//IL_014c: Unknown result type (might be due to invalid IL or missing references)
			//IL_0151: Unknown result type (might be due to invalid IL or missing references)
			//IL_015c: Expected O, but got Unknown
			//IL_015d: Expected O, but got Unknown
			//IL_016e: Unknown result type (might be due to invalid IL or missing references)
			//IL_0173: Unknown result type (might be due to invalid IL or missing references)
			//IL_017f: Expected O, but got Unknown
			//IL_0188: Unknown result type (might be due to invalid IL or missing references)
			//IL_018d: Unknown result type (might be due to invalid IL or missing references)
			//IL_0198: Expected O, but got Unknown
			//IL_0199: Expected O, but got Unknown
			//IL_01aa: Unknown result type (might be due to invalid IL or missing references)
			//IL_01af: Unknown result type (might be due to invalid IL or missing references)
			//IL_01bb: Expected O, but got Unknown
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
			//IL_0228: Unknown result type (might be due to invalid IL or missing references)
			//IL_022d: Unknown result type (might be due to invalid IL or missing references)
			//IL_0239: Expected O, but got Unknown
			//IL_0242: Unknown result type (might be due to invalid IL or missing references)
			//IL_0247: Unknown result type (might be due to invalid IL or missing references)
			//IL_0252: Expected O, but got Unknown
			//IL_0253: Expected O, but got Unknown
			//IL_0265: Unknown result type (might be due to invalid IL or missing references)
			//IL_026a: Unknown result type (might be due to invalid IL or missing references)
			//IL_0276: Expected O, but got Unknown
			//IL_027f: Unknown result type (might be due to invalid IL or missing references)
			//IL_0284: Unknown result type (might be due to invalid IL or missing references)
			//IL_028f: Expected O, but got Unknown
			//IL_0290: Expected O, but got Unknown
			//IL_029c: Unknown result type (might be due to invalid IL or missing references)
			//IL_02a1: Unknown result type (might be due to invalid IL or missing references)
			//IL_02b2: Expected O, but got Unknown
			//IL_02b3: Expected O, but got Unknown
			string sql = "UPDATE AppLibrary SET \r\n\t\t\t\tTitle=:Title,Address=:Address,Type=:Type,OpenMode=:OpenMode,Width=:Width,Height=:Height,Params=:Params,Manager=:Manager,Note=:Note,Code=:Code,Ico=:Ico,Color=:Color\r\n\t\t\t\tWHERE ID=:ID";
			OracleParameter[] obj = new OracleParameter[13];
			OracleParameter val = new OracleParameter(":Title", 119, 510);
			((DbParameter)val).Value = model.Title;
			obj[0] = val;
			OracleParameter val2 = new OracleParameter(":Address", 126, 200);
			((DbParameter)val2).Value = model.Address;
			obj[1] = val2;
			OracleParameter val3 = new OracleParameter(":Type", 126, 40);
			((DbParameter)val3).Value = model.Type;
			obj[2] = val3;
			OracleParameter val4 = new OracleParameter(":OpenMode", 112);
			((DbParameter)val4).Value = model.OpenMode;
			obj[3] = val4;
			_003F val5;
			if (model.Width.HasValue)
			{
				val5 = new OracleParameter(":Width", 112);
				((DbParameter)val5).Value = model.Width;
			}
			else
			{
				val5 = new OracleParameter(":Width", 112);
				((DbParameter)val5).Value = DBNull.Value;
			}
			obj[4] = val5;
			_003F val6;
			if (model.Height.HasValue)
			{
				val6 = new OracleParameter(":Height", 112);
				((DbParameter)val6).Value = model.Height;
			}
			else
			{
				val6 = new OracleParameter(":Height", 112);
				((DbParameter)val6).Value = DBNull.Value;
			}
			obj[5] = val6;
			_003F val7;
			if (model.Params != null)
			{
				val7 = new OracleParameter(":Params", 105);
				((DbParameter)val7).Value = model.Params;
			}
			else
			{
				val7 = new OracleParameter(":Params", 105);
				((DbParameter)val7).Value = DBNull.Value;
			}
			obj[6] = val7;
			_003F val8;
			if (model.Manager != null)
			{
				val8 = new OracleParameter(":Manager", 105);
				((DbParameter)val8).Value = model.Manager;
			}
			else
			{
				val8 = new OracleParameter(":Manager", 105);
				((DbParameter)val8).Value = DBNull.Value;
			}
			obj[7] = val8;
			_003F val9;
			if (model.Note != null)
			{
				val9 = new OracleParameter(":Note", 105);
				((DbParameter)val9).Value = model.Note;
			}
			else
			{
				val9 = new OracleParameter(":Note", 105);
				((DbParameter)val9).Value = DBNull.Value;
			}
			obj[8] = val9;
			_003F val10;
			if (model.Code != null)
			{
				val10 = new OracleParameter(":Code", 126, 50);
				((DbParameter)val10).Value = model.Code;
			}
			else
			{
				val10 = new OracleParameter(":Code", 126, 50);
				((DbParameter)val10).Value = DBNull.Value;
			}
			obj[9] = val10;
			_003F val11;
			if (model.Ico != null)
			{
				val11 = new OracleParameter(":Ico", 126);
				((DbParameter)val11).Value = model.Ico;
			}
			else
			{
				val11 = new OracleParameter(":Ico", 126);
				((DbParameter)val11).Value = DBNull.Value;
			}
			obj[10] = val11;
			_003F val12;
			if (model.Color != null)
			{
				val12 = new OracleParameter(":Color", 126);
				((DbParameter)val12).Value = model.Color;
			}
			else
			{
				val12 = new OracleParameter(":Color", 126);
				((DbParameter)val12).Value = DBNull.Value;
			}
			obj[11] = val12;
			OracleParameter val13 = new OracleParameter(":ID", 126, 40);
			((DbParameter)val13).Value = model.ID;
			obj[12] = val13;
			OracleParameter[] parameter = (OracleParameter[])obj;
			return dbHelper.Execute(sql, parameter);
		}

		public int Delete(Guid id)
		{
			//IL_0015: Unknown result type (might be due to invalid IL or missing references)
			//IL_001a: Unknown result type (might be due to invalid IL or missing references)
			//IL_0026: Expected O, but got Unknown
			//IL_0027: Expected O, but got Unknown
			string sql = "DELETE FROM AppLibrary WHERE ID=:ID";
			OracleParameter[] obj = new OracleParameter[1];
			OracleParameter val = new OracleParameter(":ID", 126);
			((DbParameter)val).Value = id;
			obj[0] = val;
			OracleParameter[] parameter = (OracleParameter[])obj;
			return dbHelper.Execute(sql, parameter);
		}

		private List<RoadFlow.Data.Model.AppLibrary> DataReaderToList(OracleDataReader dataReader)
		{
			List<RoadFlow.Data.Model.AppLibrary> list = new List<RoadFlow.Data.Model.AppLibrary>();
			RoadFlow.Data.Model.AppLibrary appLibrary = null;
			while (((DbDataReader)dataReader).Read())
			{
				appLibrary = new RoadFlow.Data.Model.AppLibrary();
				appLibrary.ID = ((DbDataReader)dataReader).GetString(0).ToGuid();
				appLibrary.Title = ((DbDataReader)dataReader).GetString(1);
				appLibrary.Address = ((DbDataReader)dataReader).GetString(2);
				appLibrary.Type = ((DbDataReader)dataReader).GetString(3).ToGuid();
				appLibrary.OpenMode = ((DbDataReader)dataReader).GetInt32(4);
				if (!((DbDataReader)dataReader).IsDBNull(5))
				{
					appLibrary.Width = ((DbDataReader)dataReader).GetInt32(5);
				}
				if (!((DbDataReader)dataReader).IsDBNull(6))
				{
					appLibrary.Height = ((DbDataReader)dataReader).GetInt32(6);
				}
				if (!((DbDataReader)dataReader).IsDBNull(7))
				{
					appLibrary.Params = ((DbDataReader)dataReader).GetString(7);
				}
				if (!((DbDataReader)dataReader).IsDBNull(8))
				{
					appLibrary.Manager = ((DbDataReader)dataReader).GetString(8);
				}
				if (!((DbDataReader)dataReader).IsDBNull(9))
				{
					appLibrary.Note = ((DbDataReader)dataReader).GetString(9);
				}
				if (!((DbDataReader)dataReader).IsDBNull(10))
				{
					appLibrary.Code = ((DbDataReader)dataReader).GetString(10);
				}
				if (!((DbDataReader)dataReader).IsDBNull(11))
				{
					appLibrary.Ico = ((DbDataReader)dataReader).GetString(11);
				}
				if (!((DbDataReader)dataReader).IsDBNull(12))
				{
					appLibrary.Color = ((DbDataReader)dataReader).GetString(12);
				}
				list.Add(appLibrary);
			}
			return list;
		}

		public List<RoadFlow.Data.Model.AppLibrary> GetAll()
		{
			string sql = "SELECT * FROM AppLibrary";
			OracleDataReader dataReader = dbHelper.GetDataReader(sql);
			List<RoadFlow.Data.Model.AppLibrary> result = DataReaderToList(dataReader);
			((DbDataReader)dataReader).Close();
			return result;
		}

		public long GetCount()
		{
			string sql = "SELECT COUNT(*) FROM AppLibrary";
			long result;
			if (!long.TryParse(dbHelper.GetFieldValue(sql), out result))
			{
				return 0L;
			}
			return result;
		}

		public RoadFlow.Data.Model.AppLibrary Get(Guid id)
		{
			//IL_0015: Unknown result type (might be due to invalid IL or missing references)
			//IL_001a: Unknown result type (might be due to invalid IL or missing references)
			//IL_0026: Expected O, but got Unknown
			//IL_0027: Expected O, but got Unknown
			string sql = "SELECT * FROM AppLibrary WHERE ID=:ID";
			OracleParameter[] obj = new OracleParameter[1];
			OracleParameter val = new OracleParameter(":ID", 126);
			((DbParameter)val).Value = id;
			obj[0] = val;
			OracleParameter[] parameter = (OracleParameter[])obj;
			OracleDataReader dataReader = dbHelper.GetDataReader(sql, parameter);
			List<RoadFlow.Data.Model.AppLibrary> list = DataReaderToList(dataReader);
			((DbDataReader)dataReader).Close();
			if (list.Count <= 0)
			{
				return null;
			}
			return list[0];
		}

		public List<RoadFlow.Data.Model.AppLibrary> GetPagerData(out string pager, string query = "", string order = "Type,Title", int size = 15, int number = 1, string title = "", string type = "", string address = "")
		{
			//IL_0029: Unknown result type (might be due to invalid IL or missing references)
			//IL_002e: Unknown result type (might be due to invalid IL or missing references)
			//IL_0036: Expected O, but got Unknown
			//IL_003b: Expected O, but got Unknown
			//IL_007a: Unknown result type (might be due to invalid IL or missing references)
			//IL_007f: Unknown result type (might be due to invalid IL or missing references)
			//IL_0087: Expected O, but got Unknown
			//IL_008c: Expected O, but got Unknown
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
				stringBuilder.AppendFormat("AND Type IN({0}) ", Tools.GetSqlInString(type));
			}
			if (!address.IsNullOrEmpty())
			{
				stringBuilder.Append("AND INSTR(Address,:Address,1,1)>0 ");
				List<OracleParameter> list3 = list;
				OracleParameter val2 = new OracleParameter(":Address", 126);
				((DbParameter)val2).Value = address;
				list3.Add(val2);
			}
			long count;
			string paerSql = dbHelper.GetPaerSql("AppLibrary", "*", stringBuilder.ToString(), order, size, number, out count, list.ToArray());
			pager = Tools.GetPagerHtml(count, size, number, query);
			OracleDataReader dataReader = dbHelper.GetDataReader(paerSql, list.ToArray());
			List<RoadFlow.Data.Model.AppLibrary> result = DataReaderToList(dataReader);
			((DbDataReader)dataReader).Close();
			return result;
		}

		public List<RoadFlow.Data.Model.AppLibrary> GetPagerData(out long count, int size = 15, int number = 1, string title = "", string type = "", string address = "", string order = "")
		{
			//IL_0029: Unknown result type (might be due to invalid IL or missing references)
			//IL_002e: Unknown result type (might be due to invalid IL or missing references)
			//IL_0036: Expected O, but got Unknown
			//IL_003b: Expected O, but got Unknown
			//IL_007a: Unknown result type (might be due to invalid IL or missing references)
			//IL_007f: Unknown result type (might be due to invalid IL or missing references)
			//IL_0087: Expected O, but got Unknown
			//IL_008c: Expected O, but got Unknown
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
				stringBuilder.AppendFormat("AND Type IN({0}) ", Tools.GetSqlInString(type));
			}
			if (!address.IsNullOrEmpty())
			{
				stringBuilder.Append("AND INSTR(Address,:Address,1,1)>0 ");
				List<OracleParameter> list3 = list;
				OracleParameter val2 = new OracleParameter(":Address", 126);
				((DbParameter)val2).Value = address;
				list3.Add(val2);
			}
			string paerSql = dbHelper.GetPaerSql("AppLibrary", "*", stringBuilder.ToString(), order.IsNullOrEmpty() ? "Type,Title" : order, size, number, out count, list.ToArray());
			OracleDataReader dataReader = dbHelper.GetDataReader(paerSql, list.ToArray());
			List<RoadFlow.Data.Model.AppLibrary> result = DataReaderToList(dataReader);
			((DbDataReader)dataReader).Close();
			return result;
		}

		public List<RoadFlow.Data.Model.AppLibrary> GetAllByType(string types)
		{
			string sql = "SELECT * FROM AppLibrary WHERE Type IN(" + Tools.GetSqlInString(types) + ")";
			OracleDataReader dataReader = dbHelper.GetDataReader(sql);
			List<RoadFlow.Data.Model.AppLibrary> result = DataReaderToList(dataReader);
			((DbDataReader)dataReader).Close();
			return result;
		}

		public int Delete(string[] idArray)
		{
			string sql = "DELETE FROM AppLibrary WHERE ID IN(" + Tools.GetSqlInString(idArray) + ")";
			return dbHelper.Execute(sql);
		}

		public RoadFlow.Data.Model.AppLibrary GetByCode(string code)
		{
			//IL_0017: Unknown result type (might be due to invalid IL or missing references)
			//IL_001c: Unknown result type (might be due to invalid IL or missing references)
			//IL_0023: Expected O, but got Unknown
			//IL_0024: Expected O, but got Unknown
			string sql = "SELECT * FROM AppLibrary WHERE Code=:Code";
			OracleParameter[] obj = new OracleParameter[1];
			OracleParameter val = new OracleParameter(":Code", 126, 50);
			((DbParameter)val).Value = code;
			obj[0] = val;
			OracleParameter[] parameter = (OracleParameter[])obj;
			OracleDataReader dataReader = dbHelper.GetDataReader(sql, parameter);
			List<RoadFlow.Data.Model.AppLibrary> list = DataReaderToList(dataReader);
			((DbDataReader)dataReader).Close();
			if (list.Count <= 0)
			{
				return null;
			}
			return list[0];
		}
	}
}
