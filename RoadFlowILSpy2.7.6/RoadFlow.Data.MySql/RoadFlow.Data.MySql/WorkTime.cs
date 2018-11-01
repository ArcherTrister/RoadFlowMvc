using MySql.Data.MySqlClient;
using RoadFlow.Data.Interface;
using RoadFlow.Data.Model;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Common;

namespace RoadFlow.Data.MySql
{
	public class WorkTime : IWorkTime
	{
		private DBHelper dbHelper = new DBHelper();

		public int Add(RoadFlow.Data.Model.WorkTime model)
		{
			//IL_001a: Unknown result type (might be due to invalid IL or missing references)
			//IL_001f: Unknown result type (might be due to invalid IL or missing references)
			//IL_0030: Expected O, but got Unknown
			//IL_0031: Expected O, but got Unknown
			//IL_0039: Unknown result type (might be due to invalid IL or missing references)
			//IL_003e: Unknown result type (might be due to invalid IL or missing references)
			//IL_004f: Expected O, but got Unknown
			//IL_0050: Expected O, but got Unknown
			//IL_0059: Unknown result type (might be due to invalid IL or missing references)
			//IL_005e: Unknown result type (might be due to invalid IL or missing references)
			//IL_006f: Expected O, but got Unknown
			//IL_0070: Expected O, but got Unknown
			//IL_0079: Unknown result type (might be due to invalid IL or missing references)
			//IL_007e: Unknown result type (might be due to invalid IL or missing references)
			//IL_008f: Expected O, but got Unknown
			//IL_0090: Expected O, but got Unknown
			//IL_009e: Unknown result type (might be due to invalid IL or missing references)
			//IL_00a3: Unknown result type (might be due to invalid IL or missing references)
			//IL_00af: Expected O, but got Unknown
			//IL_00b0: Expected O, but got Unknown
			//IL_00be: Unknown result type (might be due to invalid IL or missing references)
			//IL_00c3: Unknown result type (might be due to invalid IL or missing references)
			//IL_00cf: Expected O, but got Unknown
			//IL_00d0: Expected O, but got Unknown
			//IL_00de: Unknown result type (might be due to invalid IL or missing references)
			//IL_00e3: Unknown result type (might be due to invalid IL or missing references)
			//IL_00ef: Expected O, but got Unknown
			//IL_00f0: Expected O, but got Unknown
			//IL_00fe: Unknown result type (might be due to invalid IL or missing references)
			//IL_0103: Unknown result type (might be due to invalid IL or missing references)
			//IL_010f: Expected O, but got Unknown
			//IL_0110: Expected O, but got Unknown
			string sql = "INSERT INTO WorkTime\r\n\t\t\t\t(ID,Year,Date1,Date2,AmTime1,AmTime2,PmTime1,PmTime2) \r\n\t\t\t\tVALUES(@ID,@Year,@Date1,@Date2,@AmTime1,@AmTime2,@PmTime1,@PmTime2)";
			MySqlParameter[] obj = new MySqlParameter[8];
			MySqlParameter val = new MySqlParameter("@ID", 253, 50);
			((DbParameter)val).Value = model.ID;
			obj[0] = val;
			MySqlParameter val2 = new MySqlParameter("@Year", 3);
			((DbParameter)val2).Value = model.Year;
			obj[1] = val2;
			MySqlParameter val3 = new MySqlParameter("@Date1", 12);
			((DbParameter)val3).Value = model.Date1;
			obj[2] = val3;
			MySqlParameter val4 = new MySqlParameter("@Date2", 12);
			((DbParameter)val4).Value = model.Date2;
			obj[3] = val4;
			MySqlParameter val5 = new MySqlParameter("@AmTime1", 253, 50);
			((DbParameter)val5).Value = model.AmTime1;
			obj[4] = val5;
			MySqlParameter val6 = new MySqlParameter("@AmTime2", 253, 50);
			((DbParameter)val6).Value = model.AmTime2;
			obj[5] = val6;
			MySqlParameter val7 = new MySqlParameter("@PmTime1", 253, 50);
			((DbParameter)val7).Value = model.PmTime1;
			obj[6] = val7;
			MySqlParameter val8 = new MySqlParameter("@PmTime2", 253, 50);
			((DbParameter)val8).Value = model.PmTime2;
			obj[7] = val8;
			MySqlParameter[] parameter = (MySqlParameter[])obj;
			return dbHelper.Execute(sql, parameter);
		}

		public int Update(RoadFlow.Data.Model.WorkTime model)
		{
			//IL_0014: Unknown result type (might be due to invalid IL or missing references)
			//IL_0019: Unknown result type (might be due to invalid IL or missing references)
			//IL_002a: Expected O, but got Unknown
			//IL_002b: Expected O, but got Unknown
			//IL_0034: Unknown result type (might be due to invalid IL or missing references)
			//IL_0039: Unknown result type (might be due to invalid IL or missing references)
			//IL_004a: Expected O, but got Unknown
			//IL_004b: Expected O, but got Unknown
			//IL_0054: Unknown result type (might be due to invalid IL or missing references)
			//IL_0059: Unknown result type (might be due to invalid IL or missing references)
			//IL_006a: Expected O, but got Unknown
			//IL_006b: Expected O, but got Unknown
			//IL_0079: Unknown result type (might be due to invalid IL or missing references)
			//IL_007e: Unknown result type (might be due to invalid IL or missing references)
			//IL_008a: Expected O, but got Unknown
			//IL_008b: Expected O, but got Unknown
			//IL_0099: Unknown result type (might be due to invalid IL or missing references)
			//IL_009e: Unknown result type (might be due to invalid IL or missing references)
			//IL_00aa: Expected O, but got Unknown
			//IL_00ab: Expected O, but got Unknown
			//IL_00b9: Unknown result type (might be due to invalid IL or missing references)
			//IL_00be: Unknown result type (might be due to invalid IL or missing references)
			//IL_00ca: Expected O, but got Unknown
			//IL_00cb: Expected O, but got Unknown
			//IL_00d9: Unknown result type (might be due to invalid IL or missing references)
			//IL_00de: Unknown result type (might be due to invalid IL or missing references)
			//IL_00ea: Expected O, but got Unknown
			//IL_00eb: Expected O, but got Unknown
			//IL_00f9: Unknown result type (might be due to invalid IL or missing references)
			//IL_00fe: Unknown result type (might be due to invalid IL or missing references)
			//IL_010f: Expected O, but got Unknown
			//IL_0110: Expected O, but got Unknown
			string sql = "UPDATE WorkTime SET \r\n\t\t\t\tYear=@Year,Date1=@Date1,Date2=@Date2,AmTime1=@AmTime1,AmTime2=@AmTime2,PmTime1=@PmTime1,PmTime2=@PmTime2\r\n\t\t\t\tWHERE ID=@ID";
			MySqlParameter[] obj = new MySqlParameter[8];
			MySqlParameter val = new MySqlParameter("@Year", 3);
			((DbParameter)val).Value = model.Year;
			obj[0] = val;
			MySqlParameter val2 = new MySqlParameter("@Date1", 12);
			((DbParameter)val2).Value = model.Date1;
			obj[1] = val2;
			MySqlParameter val3 = new MySqlParameter("@Date2", 12);
			((DbParameter)val3).Value = model.Date2;
			obj[2] = val3;
			MySqlParameter val4 = new MySqlParameter("@AmTime1", 253, 50);
			((DbParameter)val4).Value = model.AmTime1;
			obj[3] = val4;
			MySqlParameter val5 = new MySqlParameter("@AmTime2", 253, 50);
			((DbParameter)val5).Value = model.AmTime2;
			obj[4] = val5;
			MySqlParameter val6 = new MySqlParameter("@PmTime1", 253, 50);
			((DbParameter)val6).Value = model.PmTime1;
			obj[5] = val6;
			MySqlParameter val7 = new MySqlParameter("@PmTime2", 253, 50);
			((DbParameter)val7).Value = model.PmTime2;
			obj[6] = val7;
			MySqlParameter val8 = new MySqlParameter("@ID", 253, 50);
			((DbParameter)val8).Value = model.ID;
			obj[7] = val8;
			MySqlParameter[] parameter = (MySqlParameter[])obj;
			return dbHelper.Execute(sql, parameter);
		}

		public int Delete(Guid id)
		{
			//IL_0018: Unknown result type (might be due to invalid IL or missing references)
			//IL_001d: Unknown result type (might be due to invalid IL or missing references)
			//IL_0029: Expected O, but got Unknown
			//IL_002a: Expected O, but got Unknown
			string sql = "DELETE FROM WorkTime WHERE ID=@ID";
			MySqlParameter[] obj = new MySqlParameter[1];
			MySqlParameter val = new MySqlParameter("@ID", 253);
			((DbParameter)val).Value = id;
			obj[0] = val;
			MySqlParameter[] parameter = (MySqlParameter[])obj;
			return dbHelper.Execute(sql, parameter);
		}

		private List<RoadFlow.Data.Model.WorkTime> DataReaderToList(MySqlDataReader dataReader)
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
			MySqlDataReader dataReader = dbHelper.GetDataReader(sql);
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
			//IL_0018: Unknown result type (might be due to invalid IL or missing references)
			//IL_001d: Unknown result type (might be due to invalid IL or missing references)
			//IL_0029: Expected O, but got Unknown
			//IL_002a: Expected O, but got Unknown
			string sql = "SELECT * FROM WorkTime WHERE ID=@ID";
			MySqlParameter[] obj = new MySqlParameter[1];
			MySqlParameter val = new MySqlParameter("@ID", 253);
			((DbParameter)val).Value = id;
			obj[0] = val;
			MySqlParameter[] parameter = (MySqlParameter[])obj;
			MySqlDataReader dataReader = dbHelper.GetDataReader(sql, parameter);
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
			MySqlDataReader dataReader = dbHelper.GetDataReader(sql);
			List<RoadFlow.Data.Model.WorkTime> result = DataReaderToList(dataReader);
			((DbDataReader)dataReader).Close();
			return result;
		}
	}
}
