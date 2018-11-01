using Oracle.ManagedDataAccess.Client;
using RoadFlow.Data.Interface;
using RoadFlow.Data.Model;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Common;

namespace RoadFlow.Data.ORACLE
{
	public class WorkTime : IWorkTime
	{
		private DBHelper dbHelper = new DBHelper();

		public int Add(RoadFlow.Data.Model.WorkTime model)
		{
			//IL_0017: Unknown result type (might be due to invalid IL or missing references)
			//IL_001c: Unknown result type (might be due to invalid IL or missing references)
			//IL_002d: Expected O, but got Unknown
			//IL_002e: Expected O, but got Unknown
			//IL_0037: Unknown result type (might be due to invalid IL or missing references)
			//IL_003c: Unknown result type (might be due to invalid IL or missing references)
			//IL_004d: Expected O, but got Unknown
			//IL_004e: Expected O, but got Unknown
			//IL_0057: Unknown result type (might be due to invalid IL or missing references)
			//IL_005c: Unknown result type (might be due to invalid IL or missing references)
			//IL_006d: Expected O, but got Unknown
			//IL_006e: Expected O, but got Unknown
			//IL_0077: Unknown result type (might be due to invalid IL or missing references)
			//IL_007c: Unknown result type (might be due to invalid IL or missing references)
			//IL_008d: Expected O, but got Unknown
			//IL_008e: Expected O, but got Unknown
			//IL_0099: Unknown result type (might be due to invalid IL or missing references)
			//IL_009e: Unknown result type (might be due to invalid IL or missing references)
			//IL_00aa: Expected O, but got Unknown
			//IL_00ab: Expected O, but got Unknown
			//IL_00b6: Unknown result type (might be due to invalid IL or missing references)
			//IL_00bb: Unknown result type (might be due to invalid IL or missing references)
			//IL_00c7: Expected O, but got Unknown
			//IL_00c8: Expected O, but got Unknown
			//IL_00d3: Unknown result type (might be due to invalid IL or missing references)
			//IL_00d8: Unknown result type (might be due to invalid IL or missing references)
			//IL_00e4: Expected O, but got Unknown
			//IL_00e5: Expected O, but got Unknown
			//IL_00f0: Unknown result type (might be due to invalid IL or missing references)
			//IL_00f5: Unknown result type (might be due to invalid IL or missing references)
			//IL_0101: Expected O, but got Unknown
			//IL_0102: Expected O, but got Unknown
			string sql = "INSERT INTO WorkTime\r\n\t\t\t\t(ID,Year,Date1,Date2,AmTime1,AmTime2,PmTime1,PmTime2) \r\n\t\t\t\tVALUES(:ID,:Year,:Date1,:Date2,:AmTime1,:AmTime2,:PmTime1,:PmTime2)";
			OracleParameter[] obj = new OracleParameter[8];
			OracleParameter val = new OracleParameter(":ID", 126, 50);
			((DbParameter)val).Value = model.ID;
			obj[0] = val;
			OracleParameter val2 = new OracleParameter(":Year", 112);
			((DbParameter)val2).Value = model.Year;
			obj[1] = val2;
			OracleParameter val3 = new OracleParameter(":Date1", 106);
			((DbParameter)val3).Value = model.Date1;
			obj[2] = val3;
			OracleParameter val4 = new OracleParameter(":Date2", 106);
			((DbParameter)val4).Value = model.Date2;
			obj[3] = val4;
			OracleParameter val5 = new OracleParameter(":AmTime1", 126, 50);
			((DbParameter)val5).Value = model.AmTime1;
			obj[4] = val5;
			OracleParameter val6 = new OracleParameter(":AmTime2", 126, 50);
			((DbParameter)val6).Value = model.AmTime2;
			obj[5] = val6;
			OracleParameter val7 = new OracleParameter(":PmTime1", 126, 50);
			((DbParameter)val7).Value = model.PmTime1;
			obj[6] = val7;
			OracleParameter val8 = new OracleParameter(":PmTime2", 126, 50);
			((DbParameter)val8).Value = model.PmTime2;
			obj[7] = val8;
			OracleParameter[] parameter = (OracleParameter[])obj;
			return dbHelper.Execute(sql, parameter);
		}

		public int Update(RoadFlow.Data.Model.WorkTime model)
		{
			//IL_0017: Unknown result type (might be due to invalid IL or missing references)
			//IL_001c: Unknown result type (might be due to invalid IL or missing references)
			//IL_002d: Expected O, but got Unknown
			//IL_002e: Expected O, but got Unknown
			//IL_0037: Unknown result type (might be due to invalid IL or missing references)
			//IL_003c: Unknown result type (might be due to invalid IL or missing references)
			//IL_004d: Expected O, but got Unknown
			//IL_004e: Expected O, but got Unknown
			//IL_0057: Unknown result type (might be due to invalid IL or missing references)
			//IL_005c: Unknown result type (might be due to invalid IL or missing references)
			//IL_006d: Expected O, but got Unknown
			//IL_006e: Expected O, but got Unknown
			//IL_0079: Unknown result type (might be due to invalid IL or missing references)
			//IL_007e: Unknown result type (might be due to invalid IL or missing references)
			//IL_008a: Expected O, but got Unknown
			//IL_008b: Expected O, but got Unknown
			//IL_0096: Unknown result type (might be due to invalid IL or missing references)
			//IL_009b: Unknown result type (might be due to invalid IL or missing references)
			//IL_00a7: Expected O, but got Unknown
			//IL_00a8: Expected O, but got Unknown
			//IL_00b3: Unknown result type (might be due to invalid IL or missing references)
			//IL_00b8: Unknown result type (might be due to invalid IL or missing references)
			//IL_00c4: Expected O, but got Unknown
			//IL_00c5: Expected O, but got Unknown
			//IL_00d0: Unknown result type (might be due to invalid IL or missing references)
			//IL_00d5: Unknown result type (might be due to invalid IL or missing references)
			//IL_00e1: Expected O, but got Unknown
			//IL_00e2: Expected O, but got Unknown
			//IL_00ed: Unknown result type (might be due to invalid IL or missing references)
			//IL_00f2: Unknown result type (might be due to invalid IL or missing references)
			//IL_0103: Expected O, but got Unknown
			//IL_0104: Expected O, but got Unknown
			string sql = "UPDATE WorkTime SET \r\n\t\t\t\tYear=:Year,Date1=:Date1,Date2=:Date2,AmTime1=:AmTime1,AmTime2=:AmTime2,PmTime1=:PmTime1,PmTime2=:PmTime2\r\n\t\t\t\tWHERE ID=:ID";
			OracleParameter[] obj = new OracleParameter[8];
			OracleParameter val = new OracleParameter(":Year", 126, 50);
			((DbParameter)val).Value = model.Year;
			obj[0] = val;
			OracleParameter val2 = new OracleParameter(":Date1", 106);
			((DbParameter)val2).Value = model.Date1;
			obj[1] = val2;
			OracleParameter val3 = new OracleParameter(":Date2", 106);
			((DbParameter)val3).Value = model.Date2;
			obj[2] = val3;
			OracleParameter val4 = new OracleParameter(":AmTime1", 126, 50);
			((DbParameter)val4).Value = model.AmTime1;
			obj[3] = val4;
			OracleParameter val5 = new OracleParameter(":AmTime2", 126, 50);
			((DbParameter)val5).Value = model.AmTime2;
			obj[4] = val5;
			OracleParameter val6 = new OracleParameter(":PmTime1", 126, 50);
			((DbParameter)val6).Value = model.PmTime1;
			obj[5] = val6;
			OracleParameter val7 = new OracleParameter(":PmTime2", 126, 50);
			((DbParameter)val7).Value = model.PmTime2;
			obj[6] = val7;
			OracleParameter val8 = new OracleParameter(":ID", 126, 50);
			((DbParameter)val8).Value = model.ID;
			obj[7] = val8;
			OracleParameter[] parameter = (OracleParameter[])obj;
			return dbHelper.Execute(sql, parameter);
		}

		public int Delete(Guid id)
		{
			//IL_0015: Unknown result type (might be due to invalid IL or missing references)
			//IL_001a: Unknown result type (might be due to invalid IL or missing references)
			//IL_0026: Expected O, but got Unknown
			//IL_0027: Expected O, but got Unknown
			string sql = "DELETE FROM WorkTime WHERE ID=:ID";
			OracleParameter[] obj = new OracleParameter[1];
			OracleParameter val = new OracleParameter(":ID", 126);
			((DbParameter)val).Value = id;
			obj[0] = val;
			OracleParameter[] parameter = (OracleParameter[])obj;
			return dbHelper.Execute(sql, parameter);
		}

		private List<RoadFlow.Data.Model.WorkTime> DataReaderToList(OracleDataReader dataReader)
		{
			List<RoadFlow.Data.Model.WorkTime> list = new List<RoadFlow.Data.Model.WorkTime>();
			RoadFlow.Data.Model.WorkTime workTime = null;
			while (((DbDataReader)dataReader).Read())
			{
				workTime = new RoadFlow.Data.Model.WorkTime();
				workTime.ID = ((DbDataReader)dataReader).GetGuid(0);
				workTime.Year = ((DbDataReader)dataReader).GetInt32(1);
				workTime.Date1 = ((DbDataReader)dataReader).GetDateTime(2);
				workTime.Date2 = ((DbDataReader)dataReader).GetDateTime(3);
				workTime.AmTime1 = ((DbDataReader)dataReader).GetString(4);
				workTime.AmTime2 = ((DbDataReader)dataReader).GetString(5);
				workTime.PmTime1 = ((DbDataReader)dataReader).GetString(6);
				workTime.PmTime2 = ((DbDataReader)dataReader).GetString(7);
				list.Add(workTime);
			}
			return list;
		}

		public List<RoadFlow.Data.Model.WorkTime> GetAll()
		{
			string sql = "SELECT * FROM WorkTime";
			OracleDataReader dataReader = dbHelper.GetDataReader(sql);
			List<RoadFlow.Data.Model.WorkTime> result = DataReaderToList(dataReader);
			((DbDataReader)dataReader).Close();
			return result;
		}

		public long GetCount()
		{
			string sql = "SELECT COUNT(*) FROM WorkTime";
			long result;
			if (!long.TryParse(dbHelper.GetFieldValue(sql), out result))
			{
				return 0L;
			}
			return result;
		}

		public RoadFlow.Data.Model.WorkTime Get(Guid id)
		{
			//IL_0015: Unknown result type (might be due to invalid IL or missing references)
			//IL_001a: Unknown result type (might be due to invalid IL or missing references)
			//IL_0026: Expected O, but got Unknown
			//IL_0027: Expected O, but got Unknown
			string sql = "SELECT * FROM WorkTime WHERE ID=:ID";
			OracleParameter[] obj = new OracleParameter[1];
			OracleParameter val = new OracleParameter(":ID", 126);
			((DbParameter)val).Value = id;
			obj[0] = val;
			OracleParameter[] parameter = (OracleParameter[])obj;
			OracleDataReader dataReader = dbHelper.GetDataReader(sql, parameter);
			List<RoadFlow.Data.Model.WorkTime> list = DataReaderToList(dataReader);
			((DbDataReader)dataReader).Close();
			if (list.Count <= 0)
			{
				return null;
			}
			return list[0];
		}

		public List<int> GetAllYear()
		{
			string sql = "SELECT DISTINCT Year FROM WorkTime";
			DataTable dataTable = dbHelper.GetDataTable(sql);
			List<int> list = new List<int>();
			foreach (DataRow row in dataTable.Rows)
			{
				list.Add(row[0].ToString().ToInt());
			}
			return list;
		}

		public List<RoadFlow.Data.Model.WorkTime> GetAll(int year)
		{
			string sql = "SELECT * FROM WorkTime WHERE Year=" + year;
			OracleDataReader dataReader = dbHelper.GetDataReader(sql);
			List<RoadFlow.Data.Model.WorkTime> result = DataReaderToList(dataReader);
			((DbDataReader)dataReader).Close();
			return result;
		}
	}
}
