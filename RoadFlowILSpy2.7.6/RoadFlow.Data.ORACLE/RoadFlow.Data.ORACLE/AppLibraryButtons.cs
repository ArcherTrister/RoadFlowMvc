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
	public class AppLibraryButtons : IAppLibraryButtons
	{
		private DBHelper dbHelper = new DBHelper();

		public int Add(RoadFlow.Data.Model.AppLibraryButtons model)
		{
			//IL_0015: Unknown result type (might be due to invalid IL or missing references)
			//IL_001a: Unknown result type (might be due to invalid IL or missing references)
			//IL_002b: Expected O, but got Unknown
			//IL_002c: Expected O, but got Unknown
			//IL_0035: Unknown result type (might be due to invalid IL or missing references)
			//IL_003a: Unknown result type (might be due to invalid IL or missing references)
			//IL_0046: Expected O, but got Unknown
			//IL_0047: Expected O, but got Unknown
			//IL_0050: Unknown result type (might be due to invalid IL or missing references)
			//IL_0055: Unknown result type (might be due to invalid IL or missing references)
			//IL_0061: Expected O, but got Unknown
			//IL_0062: Expected O, but got Unknown
			//IL_0073: Unknown result type (might be due to invalid IL or missing references)
			//IL_0078: Unknown result type (might be due to invalid IL or missing references)
			//IL_0084: Expected O, but got Unknown
			//IL_008d: Unknown result type (might be due to invalid IL or missing references)
			//IL_0092: Unknown result type (might be due to invalid IL or missing references)
			//IL_009d: Expected O, but got Unknown
			//IL_009e: Expected O, but got Unknown
			//IL_00a7: Unknown result type (might be due to invalid IL or missing references)
			//IL_00ac: Unknown result type (might be due to invalid IL or missing references)
			//IL_00bd: Expected O, but got Unknown
			//IL_00be: Expected O, but got Unknown
			//IL_00cf: Unknown result type (might be due to invalid IL or missing references)
			//IL_00d4: Unknown result type (might be due to invalid IL or missing references)
			//IL_00e0: Expected O, but got Unknown
			//IL_00e9: Unknown result type (might be due to invalid IL or missing references)
			//IL_00ee: Unknown result type (might be due to invalid IL or missing references)
			//IL_00f9: Expected O, but got Unknown
			//IL_00fa: Expected O, but got Unknown
			string sql = "INSERT INTO AppLibraryButtons\r\n\t\t\t\t(ID,Name,Events,Ico,Sort,Note) \r\n\t\t\t\tVALUES(:ID,:Name,:Events,:Ico,:Sort,:Note)";
			OracleParameter[] obj = new OracleParameter[6];
			OracleParameter val = new OracleParameter(":ID", 126);
			((DbParameter)val).Value = model.ID;
			obj[0] = val;
			OracleParameter val2 = new OracleParameter(":Name", 126);
			((DbParameter)val2).Value = model.Name;
			obj[1] = val2;
			OracleParameter val3 = new OracleParameter(":Events", 126);
			((DbParameter)val3).Value = model.Events;
			obj[2] = val3;
			_003F val4;
			if (model.Ico != null)
			{
				val4 = new OracleParameter(":Ico", 126);
				((DbParameter)val4).Value = model.Ico;
			}
			else
			{
				val4 = new OracleParameter(":Ico", 126);
				((DbParameter)val4).Value = DBNull.Value;
			}
			obj[3] = val4;
			OracleParameter val5 = new OracleParameter(":Sort", 112);
			((DbParameter)val5).Value = model.Sort;
			obj[4] = val5;
			_003F val6;
			if (model.Note != null)
			{
				val6 = new OracleParameter(":Note", 126);
				((DbParameter)val6).Value = model.Note;
			}
			else
			{
				val6 = new OracleParameter(":Note", 126);
				((DbParameter)val6).Value = DBNull.Value;
			}
			obj[5] = val6;
			OracleParameter[] parameter = (OracleParameter[])obj;
			return dbHelper.Execute(sql, parameter);
		}

		public int Update(RoadFlow.Data.Model.AppLibraryButtons model)
		{
			//IL_0015: Unknown result type (might be due to invalid IL or missing references)
			//IL_001a: Unknown result type (might be due to invalid IL or missing references)
			//IL_0026: Expected O, but got Unknown
			//IL_0027: Expected O, but got Unknown
			//IL_0030: Unknown result type (might be due to invalid IL or missing references)
			//IL_0035: Unknown result type (might be due to invalid IL or missing references)
			//IL_0041: Expected O, but got Unknown
			//IL_0042: Expected O, but got Unknown
			//IL_0053: Unknown result type (might be due to invalid IL or missing references)
			//IL_0058: Unknown result type (might be due to invalid IL or missing references)
			//IL_0064: Expected O, but got Unknown
			//IL_006d: Unknown result type (might be due to invalid IL or missing references)
			//IL_0072: Unknown result type (might be due to invalid IL or missing references)
			//IL_007d: Expected O, but got Unknown
			//IL_007e: Expected O, but got Unknown
			//IL_0087: Unknown result type (might be due to invalid IL or missing references)
			//IL_008c: Unknown result type (might be due to invalid IL or missing references)
			//IL_009d: Expected O, but got Unknown
			//IL_009e: Expected O, but got Unknown
			//IL_00af: Unknown result type (might be due to invalid IL or missing references)
			//IL_00b4: Unknown result type (might be due to invalid IL or missing references)
			//IL_00c0: Expected O, but got Unknown
			//IL_00c9: Unknown result type (might be due to invalid IL or missing references)
			//IL_00ce: Unknown result type (might be due to invalid IL or missing references)
			//IL_00d9: Expected O, but got Unknown
			//IL_00da: Expected O, but got Unknown
			//IL_00e3: Unknown result type (might be due to invalid IL or missing references)
			//IL_00e8: Unknown result type (might be due to invalid IL or missing references)
			//IL_00f9: Expected O, but got Unknown
			//IL_00fa: Expected O, but got Unknown
			string sql = "UPDATE AppLibraryButtons SET \r\n\t\t\t\tName=:Name,Events=:Events,Ico=:Ico,Sort=:Sort,Note=:Note\r\n\t\t\t\tWHERE ID=:ID";
			OracleParameter[] obj = new OracleParameter[6];
			OracleParameter val = new OracleParameter(":Name", 126);
			((DbParameter)val).Value = model.Name;
			obj[0] = val;
			OracleParameter val2 = new OracleParameter(":Events", 126);
			((DbParameter)val2).Value = model.Events;
			obj[1] = val2;
			_003F val3;
			if (model.Ico != null)
			{
				val3 = new OracleParameter(":Ico", 126);
				((DbParameter)val3).Value = model.Ico;
			}
			else
			{
				val3 = new OracleParameter(":Ico", 126);
				((DbParameter)val3).Value = DBNull.Value;
			}
			obj[2] = val3;
			OracleParameter val4 = new OracleParameter(":Sort", 112);
			((DbParameter)val4).Value = model.Sort;
			obj[3] = val4;
			_003F val5;
			if (model.Note != null)
			{
				val5 = new OracleParameter(":Note", 126);
				((DbParameter)val5).Value = model.Note;
			}
			else
			{
				val5 = new OracleParameter(":Note", 126);
				((DbParameter)val5).Value = DBNull.Value;
			}
			obj[4] = val5;
			OracleParameter val6 = new OracleParameter(":ID", 126);
			((DbParameter)val6).Value = model.ID;
			obj[5] = val6;
			OracleParameter[] parameter = (OracleParameter[])obj;
			return dbHelper.Execute(sql, parameter);
		}

		public int Delete(Guid id)
		{
			//IL_0015: Unknown result type (might be due to invalid IL or missing references)
			//IL_001a: Unknown result type (might be due to invalid IL or missing references)
			//IL_0026: Expected O, but got Unknown
			//IL_0027: Expected O, but got Unknown
			string sql = "DELETE FROM AppLibraryButtons WHERE ID=:ID";
			OracleParameter[] obj = new OracleParameter[1];
			OracleParameter val = new OracleParameter(":ID", 126);
			((DbParameter)val).Value = id;
			obj[0] = val;
			OracleParameter[] parameter = (OracleParameter[])obj;
			return dbHelper.Execute(sql, parameter);
		}

		private List<RoadFlow.Data.Model.AppLibraryButtons> DataReaderToList(OracleDataReader dataReader)
		{
			List<RoadFlow.Data.Model.AppLibraryButtons> list = new List<RoadFlow.Data.Model.AppLibraryButtons>();
			RoadFlow.Data.Model.AppLibraryButtons appLibraryButtons = null;
			while (((DbDataReader)dataReader).Read())
			{
				appLibraryButtons = new RoadFlow.Data.Model.AppLibraryButtons();
				appLibraryButtons.ID = ((DbDataReader)dataReader).GetString(0).ToGuid();
				appLibraryButtons.Name = ((DbDataReader)dataReader).GetString(1);
				appLibraryButtons.Events = ((DbDataReader)dataReader).GetString(2);
				if (!((DbDataReader)dataReader).IsDBNull(3))
				{
					appLibraryButtons.Ico = ((DbDataReader)dataReader).GetString(3);
				}
				appLibraryButtons.Sort = ((DbDataReader)dataReader).GetInt32(4);
				if (!((DbDataReader)dataReader).IsDBNull(5))
				{
					appLibraryButtons.Note = ((DbDataReader)dataReader).GetString(5);
				}
				list.Add(appLibraryButtons);
			}
			return list;
		}

		public List<RoadFlow.Data.Model.AppLibraryButtons> GetAll()
		{
			string sql = "SELECT * FROM AppLibraryButtons";
			OracleDataReader dataReader = dbHelper.GetDataReader(sql);
			List<RoadFlow.Data.Model.AppLibraryButtons> result = DataReaderToList(dataReader);
			((DbDataReader)dataReader).Close();
			return result;
		}

		public long GetCount()
		{
			string sql = "SELECT COUNT(*) FROM AppLibraryButtons";
			long result;
			if (!long.TryParse(dbHelper.GetFieldValue(sql), out result))
			{
				return 0L;
			}
			return result;
		}

		public RoadFlow.Data.Model.AppLibraryButtons Get(Guid id)
		{
			//IL_0015: Unknown result type (might be due to invalid IL or missing references)
			//IL_001a: Unknown result type (might be due to invalid IL or missing references)
			//IL_0026: Expected O, but got Unknown
			//IL_0027: Expected O, but got Unknown
			string sql = "SELECT * FROM AppLibraryButtons WHERE ID=:ID";
			OracleParameter[] obj = new OracleParameter[1];
			OracleParameter val = new OracleParameter(":ID", 126);
			((DbParameter)val).Value = id;
			obj[0] = val;
			OracleParameter[] parameter = (OracleParameter[])obj;
			OracleDataReader dataReader = dbHelper.GetDataReader(sql, parameter);
			List<RoadFlow.Data.Model.AppLibraryButtons> list = DataReaderToList(dataReader);
			((DbDataReader)dataReader).Close();
			if (list.Count <= 0)
			{
				return null;
			}
			return list[0];
		}

		public List<RoadFlow.Data.Model.AppLibraryButtons> GetPagerData(out string pager, string query = "", int size = 15, int number = 1, string title = "")
		{
			//IL_0029: Unknown result type (might be due to invalid IL or missing references)
			//IL_002e: Unknown result type (might be due to invalid IL or missing references)
			//IL_0036: Expected O, but got Unknown
			//IL_003b: Expected O, but got Unknown
			StringBuilder stringBuilder = new StringBuilder();
			List<OracleParameter> list = new List<OracleParameter>();
			if (!title.IsNullOrEmpty())
			{
				stringBuilder.Append("AND INSTR(Name,:Name,1,1)>0 ");
				List<OracleParameter> list2 = list;
				OracleParameter val = new OracleParameter(":Name", 126);
				((DbParameter)val).Value = title;
				list2.Add(val);
			}
			long count;
			string paerSql = dbHelper.GetPaerSql("AppLibraryButtons", "*", stringBuilder.ToString(), "Sort DESC", size, number, out count, list.ToArray());
			pager = Tools.GetPagerHtml(count, size, number, query);
			OracleDataReader dataReader = dbHelper.GetDataReader(paerSql, list.ToArray());
			List<RoadFlow.Data.Model.AppLibraryButtons> result = DataReaderToList(dataReader);
			((DbDataReader)dataReader).Close();
			return result;
		}

		public List<RoadFlow.Data.Model.AppLibraryButtons> GetPagerData(out long count, int size, int number, string title = "", string order = "")
		{
			//IL_0029: Unknown result type (might be due to invalid IL or missing references)
			//IL_002e: Unknown result type (might be due to invalid IL or missing references)
			//IL_0036: Expected O, but got Unknown
			//IL_003b: Expected O, but got Unknown
			StringBuilder stringBuilder = new StringBuilder();
			List<OracleParameter> list = new List<OracleParameter>();
			if (!title.IsNullOrEmpty())
			{
				stringBuilder.Append("AND INSTR(Name,:Name,1,1)>0 ");
				List<OracleParameter> list2 = list;
				OracleParameter val = new OracleParameter(":Name", 126);
				((DbParameter)val).Value = title;
				list2.Add(val);
			}
			string paerSql = dbHelper.GetPaerSql("AppLibraryButtons", "*", stringBuilder.ToString(), order.IsNullOrEmpty() ? "Sort DESC" : order, size, number, out count, list.ToArray());
			OracleDataReader dataReader = dbHelper.GetDataReader(paerSql, list.ToArray());
			List<RoadFlow.Data.Model.AppLibraryButtons> result = DataReaderToList(dataReader);
			((DbDataReader)dataReader).Close();
			return result;
		}

		public int GetMaxSort()
		{
			string sql = "SELECT MAX(Sort) FROM AppLibraryButtons";
			return dbHelper.GetFieldValue(sql).ToInt(0) + 5;
		}
	}
}
