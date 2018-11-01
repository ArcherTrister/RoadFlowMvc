using MySql.Data.MySqlClient;
using RoadFlow.Data.Interface;
using RoadFlow.Data.Model;
using System;
using System.Collections.Generic;
using System.Data.Common;

namespace RoadFlow.Data.MySql
{
	public class HastenLog : IHastenLog
	{
		private DBHelper dbHelper = new DBHelper();

		public int Add(RoadFlow.Data.Model.HastenLog model)
		{
			//IL_001a: Unknown result type (might be due to invalid IL or missing references)
			//IL_001f: Unknown result type (might be due to invalid IL or missing references)
			//IL_0030: Expected O, but got Unknown
			//IL_0031: Expected O, but got Unknown
			//IL_003e: Unknown result type (might be due to invalid IL or missing references)
			//IL_0043: Unknown result type (might be due to invalid IL or missing references)
			//IL_004f: Expected O, but got Unknown
			//IL_0050: Expected O, but got Unknown
			//IL_005d: Unknown result type (might be due to invalid IL or missing references)
			//IL_0062: Unknown result type (might be due to invalid IL or missing references)
			//IL_006e: Expected O, but got Unknown
			//IL_006f: Expected O, but got Unknown
			//IL_007c: Unknown result type (might be due to invalid IL or missing references)
			//IL_0081: Unknown result type (might be due to invalid IL or missing references)
			//IL_008d: Expected O, but got Unknown
			//IL_008e: Expected O, but got Unknown
			//IL_009b: Unknown result type (might be due to invalid IL or missing references)
			//IL_00a0: Unknown result type (might be due to invalid IL or missing references)
			//IL_00ac: Expected O, but got Unknown
			//IL_00ad: Expected O, but got Unknown
			//IL_00bb: Unknown result type (might be due to invalid IL or missing references)
			//IL_00c0: Unknown result type (might be due to invalid IL or missing references)
			//IL_00d1: Expected O, but got Unknown
			//IL_00d2: Expected O, but got Unknown
			//IL_00e0: Unknown result type (might be due to invalid IL or missing references)
			//IL_00e5: Unknown result type (might be due to invalid IL or missing references)
			//IL_00f1: Expected O, but got Unknown
			//IL_00f2: Expected O, but got Unknown
			//IL_00fc: Unknown result type (might be due to invalid IL or missing references)
			//IL_0101: Unknown result type (might be due to invalid IL or missing references)
			//IL_0112: Expected O, but got Unknown
			//IL_0113: Expected O, but got Unknown
			string sql = "INSERT INTO hastenlog\r\n\t\t\t\t(ID,OthersParams,Users,Types,Contents,SendUser,SendUserName,SendTime) \r\n\t\t\t\tVALUES(@ID,@OthersParams,@Users,@Types,@Contents,@SendUser,@SendUserName,@SendTime)";
			MySqlParameter[] obj = new MySqlParameter[8];
			MySqlParameter val = new MySqlParameter("@ID", 253, 36);
			((DbParameter)val).Value = model.ID;
			obj[0] = val;
			MySqlParameter val2 = new MySqlParameter("@OthersParams", 752, -1);
			((DbParameter)val2).Value = model.OthersParams;
			obj[1] = val2;
			MySqlParameter val3 = new MySqlParameter("@Users", 752, -1);
			((DbParameter)val3).Value = model.Users;
			obj[2] = val3;
			MySqlParameter val4 = new MySqlParameter("@Types", 752, -1);
			((DbParameter)val4).Value = model.Types;
			obj[3] = val4;
			MySqlParameter val5 = new MySqlParameter("@Contents", 752, -1);
			((DbParameter)val5).Value = model.Contents;
			obj[4] = val5;
			MySqlParameter val6 = new MySqlParameter("@SendUser", 253, 36);
			((DbParameter)val6).Value = model.SendUser;
			obj[5] = val6;
			MySqlParameter val7 = new MySqlParameter("@SendUserName", 253, 50);
			((DbParameter)val7).Value = model.SendUserName;
			obj[6] = val7;
			MySqlParameter val8 = new MySqlParameter("@SendTime", 12, -1);
			((DbParameter)val8).Value = model.SendTime;
			obj[7] = val8;
			MySqlParameter[] parameter = (MySqlParameter[])obj;
			return dbHelper.Execute(sql, parameter);
		}

		public int Update(RoadFlow.Data.Model.HastenLog model)
		{
			//IL_0019: Unknown result type (might be due to invalid IL or missing references)
			//IL_001e: Unknown result type (might be due to invalid IL or missing references)
			//IL_002a: Expected O, but got Unknown
			//IL_002b: Expected O, but got Unknown
			//IL_0038: Unknown result type (might be due to invalid IL or missing references)
			//IL_003d: Unknown result type (might be due to invalid IL or missing references)
			//IL_0049: Expected O, but got Unknown
			//IL_004a: Expected O, but got Unknown
			//IL_0057: Unknown result type (might be due to invalid IL or missing references)
			//IL_005c: Unknown result type (might be due to invalid IL or missing references)
			//IL_0068: Expected O, but got Unknown
			//IL_0069: Expected O, but got Unknown
			//IL_0076: Unknown result type (might be due to invalid IL or missing references)
			//IL_007b: Unknown result type (might be due to invalid IL or missing references)
			//IL_0087: Expected O, but got Unknown
			//IL_0088: Expected O, but got Unknown
			//IL_0096: Unknown result type (might be due to invalid IL or missing references)
			//IL_009b: Unknown result type (might be due to invalid IL or missing references)
			//IL_00ac: Expected O, but got Unknown
			//IL_00ad: Expected O, but got Unknown
			//IL_00bb: Unknown result type (might be due to invalid IL or missing references)
			//IL_00c0: Unknown result type (might be due to invalid IL or missing references)
			//IL_00cc: Expected O, but got Unknown
			//IL_00cd: Expected O, but got Unknown
			//IL_00d7: Unknown result type (might be due to invalid IL or missing references)
			//IL_00dc: Unknown result type (might be due to invalid IL or missing references)
			//IL_00ed: Expected O, but got Unknown
			//IL_00ee: Expected O, but got Unknown
			//IL_00fc: Unknown result type (might be due to invalid IL or missing references)
			//IL_0101: Unknown result type (might be due to invalid IL or missing references)
			//IL_0112: Expected O, but got Unknown
			//IL_0113: Expected O, but got Unknown
			string sql = "UPDATE hastenlog SET \r\n\t\t\t\tOthersParams=@OthersParams,Users=@Users,Types=@Types,Contents=@Contents,SendUser=@SendUser,SendUserName=@SendUserName,SendTime=@SendTime\r\n\t\t\t\tWHERE ID=@ID";
			MySqlParameter[] obj = new MySqlParameter[8];
			MySqlParameter val = new MySqlParameter("@OthersParams", 752, -1);
			((DbParameter)val).Value = model.OthersParams;
			obj[0] = val;
			MySqlParameter val2 = new MySqlParameter("@Users", 752, -1);
			((DbParameter)val2).Value = model.Users;
			obj[1] = val2;
			MySqlParameter val3 = new MySqlParameter("@Types", 752, -1);
			((DbParameter)val3).Value = model.Types;
			obj[2] = val3;
			MySqlParameter val4 = new MySqlParameter("@Contents", 752, -1);
			((DbParameter)val4).Value = model.Contents;
			obj[3] = val4;
			MySqlParameter val5 = new MySqlParameter("@SendUser", 253, 36);
			((DbParameter)val5).Value = model.SendUser;
			obj[4] = val5;
			MySqlParameter val6 = new MySqlParameter("@SendUserName", 253, 50);
			((DbParameter)val6).Value = model.SendUserName;
			obj[5] = val6;
			MySqlParameter val7 = new MySqlParameter("@SendTime", 12, -1);
			((DbParameter)val7).Value = model.SendTime;
			obj[6] = val7;
			MySqlParameter val8 = new MySqlParameter("@ID", 253, 36);
			((DbParameter)val8).Value = model.ID;
			obj[7] = val8;
			MySqlParameter[] parameter = (MySqlParameter[])obj;
			return dbHelper.Execute(sql, parameter);
		}

		public int Delete(Guid id)
		{
			//IL_001a: Unknown result type (might be due to invalid IL or missing references)
			//IL_001f: Unknown result type (might be due to invalid IL or missing references)
			//IL_0032: Expected O, but got Unknown
			//IL_0033: Expected O, but got Unknown
			string sql = "DELETE FROM hastenlog WHERE ID=@ID";
			MySqlParameter[] obj = new MySqlParameter[1];
			MySqlParameter val = new MySqlParameter("@ID", 253, 36);
			((DbParameter)val).Value = id.ToString();
			obj[0] = val;
			MySqlParameter[] parameter = (MySqlParameter[])obj;
			return dbHelper.Execute(sql, parameter);
		}

		private List<RoadFlow.Data.Model.HastenLog> DataReaderToList(MySqlDataReader dataReader)
		{
			List<RoadFlow.Data.Model.HastenLog> list = new List<RoadFlow.Data.Model.HastenLog>();
			RoadFlow.Data.Model.HastenLog hastenLog = null;
			while (((DbDataReader)dataReader).Read())
			{
				hastenLog = new RoadFlow.Data.Model.HastenLog();
				hastenLog.ID = ((DbDataReader)dataReader).GetString(0).ToGuid();
				hastenLog.OthersParams = ((DbDataReader)dataReader).GetString(1);
				hastenLog.Users = ((DbDataReader)dataReader).GetString(2);
				hastenLog.Types = ((DbDataReader)dataReader).GetString(3);
				hastenLog.Contents = ((DbDataReader)dataReader).GetString(4);
				hastenLog.SendUser = ((DbDataReader)dataReader).GetString(5).ToGuid();
				hastenLog.SendUserName = ((DbDataReader)dataReader).GetString(6);
				hastenLog.SendTime = ((DbDataReader)dataReader).GetDateTime(7);
				list.Add(hastenLog);
			}
			return list;
		}

		public List<RoadFlow.Data.Model.HastenLog> GetAll()
		{
			string sql = "SELECT * FROM hastenlog";
			MySqlDataReader dataReader = dbHelper.GetDataReader(sql);
			List<RoadFlow.Data.Model.HastenLog> result = DataReaderToList(dataReader);
			((DbDataReader)dataReader).Close();
			return result;
		}

		public long GetCount()
		{
			string sql = "SELECT COUNT(*) FROM hastenlog";
			long result;
			if (!long.TryParse(dbHelper.GetFieldValue(sql), out result))
			{
				return 0L;
			}
			return result;
		}

		public RoadFlow.Data.Model.HastenLog Get(Guid id)
		{
			//IL_001a: Unknown result type (might be due to invalid IL or missing references)
			//IL_001f: Unknown result type (might be due to invalid IL or missing references)
			//IL_0032: Expected O, but got Unknown
			//IL_0033: Expected O, but got Unknown
			string sql = "SELECT * FROM hastenlog WHERE ID=@ID";
			MySqlParameter[] obj = new MySqlParameter[1];
			MySqlParameter val = new MySqlParameter("@ID", 253, 36);
			((DbParameter)val).Value = id.ToString();
			obj[0] = val;
			MySqlParameter[] parameter = (MySqlParameter[])obj;
			MySqlDataReader dataReader = dbHelper.GetDataReader(sql, parameter);
			List<RoadFlow.Data.Model.HastenLog> list = DataReaderToList(dataReader);
			((DbDataReader)dataReader).Close();
			if (list.Count <= 0)
			{
				return null;
			}
			return list[0];
		}
	}
}
