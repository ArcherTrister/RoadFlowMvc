using MySql.Data.MySqlClient;
using RoadFlow.Data.Interface;
using RoadFlow.Data.Model;
using System;
using System.Collections.Generic;
using System.Data.Common;

namespace RoadFlow.Data.MySql
{
	public class ProgramBuilderButtons : IProgramBuilderButtons
	{
		private DBHelper dbHelper = new DBHelper();

		public int Add(RoadFlow.Data.Model.ProgramBuilderButtons model)
		{
			//IL_001b: Unknown result type (might be due to invalid IL or missing references)
			//IL_0020: Unknown result type (might be due to invalid IL or missing references)
			//IL_0031: Expected O, but got Unknown
			//IL_0032: Expected O, but got Unknown
			//IL_0040: Unknown result type (might be due to invalid IL or missing references)
			//IL_0045: Unknown result type (might be due to invalid IL or missing references)
			//IL_0056: Expected O, but got Unknown
			//IL_0057: Expected O, but got Unknown
			//IL_0075: Unknown result type (might be due to invalid IL or missing references)
			//IL_007a: Unknown result type (might be due to invalid IL or missing references)
			//IL_008b: Expected O, but got Unknown
			//IL_0099: Unknown result type (might be due to invalid IL or missing references)
			//IL_009e: Unknown result type (might be due to invalid IL or missing references)
			//IL_00a9: Expected O, but got Unknown
			//IL_00aa: Expected O, but got Unknown
			//IL_00bb: Unknown result type (might be due to invalid IL or missing references)
			//IL_00c0: Unknown result type (might be due to invalid IL or missing references)
			//IL_00cc: Expected O, but got Unknown
			//IL_00cd: Expected O, but got Unknown
			//IL_00e2: Unknown result type (might be due to invalid IL or missing references)
			//IL_00e7: Unknown result type (might be due to invalid IL or missing references)
			//IL_00f3: Expected O, but got Unknown
			//IL_0100: Unknown result type (might be due to invalid IL or missing references)
			//IL_0105: Unknown result type (might be due to invalid IL or missing references)
			//IL_0110: Expected O, but got Unknown
			//IL_0111: Expected O, but got Unknown
			//IL_0126: Unknown result type (might be due to invalid IL or missing references)
			//IL_012b: Unknown result type (might be due to invalid IL or missing references)
			//IL_0137: Expected O, but got Unknown
			//IL_0144: Unknown result type (might be due to invalid IL or missing references)
			//IL_0149: Unknown result type (might be due to invalid IL or missing references)
			//IL_0154: Expected O, but got Unknown
			//IL_0155: Expected O, but got Unknown
			//IL_015f: Unknown result type (might be due to invalid IL or missing references)
			//IL_0164: Unknown result type (might be due to invalid IL or missing references)
			//IL_0175: Expected O, but got Unknown
			//IL_0176: Expected O, but got Unknown
			//IL_0180: Unknown result type (might be due to invalid IL or missing references)
			//IL_0185: Unknown result type (might be due to invalid IL or missing references)
			//IL_0196: Expected O, but got Unknown
			//IL_0197: Expected O, but got Unknown
			//IL_01a1: Unknown result type (might be due to invalid IL or missing references)
			//IL_01a6: Unknown result type (might be due to invalid IL or missing references)
			//IL_01b7: Expected O, but got Unknown
			//IL_01b8: Expected O, but got Unknown
			string sql = "INSERT INTO programbuilderbuttons\r\n\t\t\t\t(ID,ProgramID,ButtonID,ButtonName,ClientScript,Ico,ShowType,Sort,IsValidateShow) \r\n\t\t\t\tVALUES(@ID,@ProgramID,@ButtonID,@ButtonName,@ClientScript,@Ico,@ShowType,@Sort,@IsValidateShow)";
			MySqlParameter[] obj = new MySqlParameter[9];
			MySqlParameter val = new MySqlParameter("@ID", 253, 36);
			((DbParameter)val).Value = model.ID;
			obj[0] = val;
			MySqlParameter val2 = new MySqlParameter("@ProgramID", 253, 36);
			((DbParameter)val2).Value = model.ProgramID;
			obj[1] = val2;
			_003F val3;
			if (model.ButtonID.HasValue)
			{
				val3 = new MySqlParameter("@ButtonID", 253, 36);
				((DbParameter)val3).Value = model.ButtonID;
			}
			else
			{
				val3 = new MySqlParameter("@ButtonID", 253, 36);
				((DbParameter)val3).Value = DBNull.Value;
			}
			obj[2] = val3;
			MySqlParameter val4 = new MySqlParameter("@ButtonName", 253, 200);
			((DbParameter)val4).Value = model.ButtonName;
			obj[3] = val4;
			_003F val5;
			if (model.ClientScript != null)
			{
				val5 = new MySqlParameter("@ClientScript", 751, -1);
				((DbParameter)val5).Value = model.ClientScript;
			}
			else
			{
				val5 = new MySqlParameter("@ClientScript", 751, -1);
				((DbParameter)val5).Value = DBNull.Value;
			}
			obj[4] = val5;
			_003F val6;
			if (model.Ico != null)
			{
				val6 = new MySqlParameter("@Ico", 752, -1);
				((DbParameter)val6).Value = model.Ico;
			}
			else
			{
				val6 = new MySqlParameter("@Ico", 752, -1);
				((DbParameter)val6).Value = DBNull.Value;
			}
			obj[5] = val6;
			MySqlParameter val7 = new MySqlParameter("@ShowType", 3, 11);
			((DbParameter)val7).Value = model.ShowType;
			obj[6] = val7;
			MySqlParameter val8 = new MySqlParameter("@Sort", 3, 11);
			((DbParameter)val8).Value = model.Sort;
			obj[7] = val8;
			MySqlParameter val9 = new MySqlParameter("@IsValidateShow", 3, 11);
			((DbParameter)val9).Value = model.IsValidateShow;
			obj[8] = val9;
			MySqlParameter[] parameter = (MySqlParameter[])obj;
			return dbHelper.Execute(sql, parameter);
		}

		public int Update(RoadFlow.Data.Model.ProgramBuilderButtons model)
		{
			//IL_001b: Unknown result type (might be due to invalid IL or missing references)
			//IL_0020: Unknown result type (might be due to invalid IL or missing references)
			//IL_0031: Expected O, but got Unknown
			//IL_0032: Expected O, but got Unknown
			//IL_0050: Unknown result type (might be due to invalid IL or missing references)
			//IL_0055: Unknown result type (might be due to invalid IL or missing references)
			//IL_0066: Expected O, but got Unknown
			//IL_0074: Unknown result type (might be due to invalid IL or missing references)
			//IL_0079: Unknown result type (might be due to invalid IL or missing references)
			//IL_0084: Expected O, but got Unknown
			//IL_0085: Expected O, but got Unknown
			//IL_0096: Unknown result type (might be due to invalid IL or missing references)
			//IL_009b: Unknown result type (might be due to invalid IL or missing references)
			//IL_00a7: Expected O, but got Unknown
			//IL_00a8: Expected O, but got Unknown
			//IL_00bd: Unknown result type (might be due to invalid IL or missing references)
			//IL_00c2: Unknown result type (might be due to invalid IL or missing references)
			//IL_00ce: Expected O, but got Unknown
			//IL_00db: Unknown result type (might be due to invalid IL or missing references)
			//IL_00e0: Unknown result type (might be due to invalid IL or missing references)
			//IL_00eb: Expected O, but got Unknown
			//IL_00ec: Expected O, but got Unknown
			//IL_0101: Unknown result type (might be due to invalid IL or missing references)
			//IL_0106: Unknown result type (might be due to invalid IL or missing references)
			//IL_0112: Expected O, but got Unknown
			//IL_011f: Unknown result type (might be due to invalid IL or missing references)
			//IL_0124: Unknown result type (might be due to invalid IL or missing references)
			//IL_012f: Expected O, but got Unknown
			//IL_0130: Expected O, but got Unknown
			//IL_013a: Unknown result type (might be due to invalid IL or missing references)
			//IL_013f: Unknown result type (might be due to invalid IL or missing references)
			//IL_0150: Expected O, but got Unknown
			//IL_0151: Expected O, but got Unknown
			//IL_015b: Unknown result type (might be due to invalid IL or missing references)
			//IL_0160: Unknown result type (might be due to invalid IL or missing references)
			//IL_0171: Expected O, but got Unknown
			//IL_0172: Expected O, but got Unknown
			//IL_017c: Unknown result type (might be due to invalid IL or missing references)
			//IL_0181: Unknown result type (might be due to invalid IL or missing references)
			//IL_0192: Expected O, but got Unknown
			//IL_0193: Expected O, but got Unknown
			//IL_01a1: Unknown result type (might be due to invalid IL or missing references)
			//IL_01a6: Unknown result type (might be due to invalid IL or missing references)
			//IL_01b7: Expected O, but got Unknown
			//IL_01b8: Expected O, but got Unknown
			string sql = "UPDATE programbuilderbuttons SET \r\n\t\t\t\tProgramID=@ProgramID,ButtonID=@ButtonID,ButtonName=@ButtonName,ClientScript=@ClientScript,Ico=@Ico,ShowType=@ShowType,Sort=@Sort,IsValidateShow=@IsValidateShow\r\n\t\t\t\tWHERE ID=@ID";
			MySqlParameter[] obj = new MySqlParameter[9];
			MySqlParameter val = new MySqlParameter("@ProgramID", 253, 36);
			((DbParameter)val).Value = model.ProgramID;
			obj[0] = val;
			_003F val2;
			if (model.ButtonID.HasValue)
			{
				val2 = new MySqlParameter("@ButtonID", 253, 36);
				((DbParameter)val2).Value = model.ButtonID;
			}
			else
			{
				val2 = new MySqlParameter("@ButtonID", 253, 36);
				((DbParameter)val2).Value = DBNull.Value;
			}
			obj[1] = val2;
			MySqlParameter val3 = new MySqlParameter("@ButtonName", 253, 200);
			((DbParameter)val3).Value = model.ButtonName;
			obj[2] = val3;
			_003F val4;
			if (model.ClientScript != null)
			{
				val4 = new MySqlParameter("@ClientScript", 751, -1);
				((DbParameter)val4).Value = model.ClientScript;
			}
			else
			{
				val4 = new MySqlParameter("@ClientScript", 751, -1);
				((DbParameter)val4).Value = DBNull.Value;
			}
			obj[3] = val4;
			_003F val5;
			if (model.Ico != null)
			{
				val5 = new MySqlParameter("@Ico", 752, -1);
				((DbParameter)val5).Value = model.Ico;
			}
			else
			{
				val5 = new MySqlParameter("@Ico", 752, -1);
				((DbParameter)val5).Value = DBNull.Value;
			}
			obj[4] = val5;
			MySqlParameter val6 = new MySqlParameter("@ShowType", 3, 11);
			((DbParameter)val6).Value = model.ShowType;
			obj[5] = val6;
			MySqlParameter val7 = new MySqlParameter("@Sort", 3, 11);
			((DbParameter)val7).Value = model.Sort;
			obj[6] = val7;
			MySqlParameter val8 = new MySqlParameter("@IsValidateShow", 3, 11);
			((DbParameter)val8).Value = model.IsValidateShow;
			obj[7] = val8;
			MySqlParameter val9 = new MySqlParameter("@ID", 253, 36);
			((DbParameter)val9).Value = model.ID;
			obj[8] = val9;
			MySqlParameter[] parameter = (MySqlParameter[])obj;
			return dbHelper.Execute(sql, parameter);
		}

		public int Delete(Guid id)
		{
			//IL_001a: Unknown result type (might be due to invalid IL or missing references)
			//IL_001f: Unknown result type (might be due to invalid IL or missing references)
			//IL_0032: Expected O, but got Unknown
			//IL_0033: Expected O, but got Unknown
			string sql = "DELETE FROM programbuilderbuttons WHERE ID=@ID";
			MySqlParameter[] obj = new MySqlParameter[1];
			MySqlParameter val = new MySqlParameter("@ID", 253, 36);
			((DbParameter)val).Value = id.ToString();
			obj[0] = val;
			MySqlParameter[] parameter = (MySqlParameter[])obj;
			return dbHelper.Execute(sql, parameter);
		}

		private List<RoadFlow.Data.Model.ProgramBuilderButtons> DataReaderToList(MySqlDataReader dataReader)
		{
			List<RoadFlow.Data.Model.ProgramBuilderButtons> list = new List<RoadFlow.Data.Model.ProgramBuilderButtons>();
			RoadFlow.Data.Model.ProgramBuilderButtons programBuilderButtons = null;
			while (((DbDataReader)dataReader).Read())
			{
				programBuilderButtons = new RoadFlow.Data.Model.ProgramBuilderButtons();
				programBuilderButtons.ID = ((DbDataReader)dataReader).GetString(0).ToGuid();
				programBuilderButtons.ProgramID = ((DbDataReader)dataReader).GetString(1).ToGuid();
				if (!((DbDataReader)dataReader).IsDBNull(2))
				{
					programBuilderButtons.ButtonID = ((DbDataReader)dataReader).GetString(2).ToGuid();
				}
				programBuilderButtons.ButtonName = ((DbDataReader)dataReader).GetString(3);
				if (!((DbDataReader)dataReader).IsDBNull(4))
				{
					programBuilderButtons.ClientScript = ((DbDataReader)dataReader).GetString(4);
				}
				if (!((DbDataReader)dataReader).IsDBNull(5))
				{
					programBuilderButtons.Ico = ((DbDataReader)dataReader).GetString(5);
				}
				programBuilderButtons.ShowType = ((DbDataReader)dataReader).GetInt32(6);
				programBuilderButtons.Sort = ((DbDataReader)dataReader).GetInt32(7);
				programBuilderButtons.IsValidateShow = ((DbDataReader)dataReader).GetInt32(8);
				list.Add(programBuilderButtons);
			}
			return list;
		}

		public List<RoadFlow.Data.Model.ProgramBuilderButtons> GetAll()
		{
			string sql = "SELECT * FROM programbuilderbuttons";
			MySqlDataReader dataReader = dbHelper.GetDataReader(sql);
			List<RoadFlow.Data.Model.ProgramBuilderButtons> result = DataReaderToList(dataReader);
			((DbDataReader)dataReader).Close();
			return result;
		}

		public long GetCount()
		{
			string sql = "SELECT COUNT(*) FROM programbuilderbuttons";
			long result;
			if (!long.TryParse(dbHelper.GetFieldValue(sql), out result))
			{
				return 0L;
			}
			return result;
		}

		public RoadFlow.Data.Model.ProgramBuilderButtons Get(Guid id)
		{
			//IL_001a: Unknown result type (might be due to invalid IL or missing references)
			//IL_001f: Unknown result type (might be due to invalid IL or missing references)
			//IL_0032: Expected O, but got Unknown
			//IL_0033: Expected O, but got Unknown
			string sql = "SELECT * FROM programbuilderbuttons WHERE ID=@ID";
			MySqlParameter[] obj = new MySqlParameter[1];
			MySqlParameter val = new MySqlParameter("@ID", 253, 36);
			((DbParameter)val).Value = id.ToString();
			obj[0] = val;
			MySqlParameter[] parameter = (MySqlParameter[])obj;
			MySqlDataReader dataReader = dbHelper.GetDataReader(sql, parameter);
			List<RoadFlow.Data.Model.ProgramBuilderButtons> list = DataReaderToList(dataReader);
			((DbDataReader)dataReader).Close();
			if (list.Count <= 0)
			{
				return null;
			}
			return list[0];
		}

		public List<RoadFlow.Data.Model.ProgramBuilderButtons> GetAll(Guid id)
		{
			//IL_0018: Unknown result type (might be due to invalid IL or missing references)
			//IL_001d: Unknown result type (might be due to invalid IL or missing references)
			//IL_0030: Expected O, but got Unknown
			//IL_0031: Expected O, but got Unknown
			string sql = "SELECT * FROM ProgramBuilderButtons WHERE ProgramID=@ProgramID";
			MySqlParameter[] obj = new MySqlParameter[1];
			MySqlParameter val = new MySqlParameter("@ProgramID", 253);
			((DbParameter)val).Value = id.ToString();
			obj[0] = val;
			MySqlParameter[] parameter = (MySqlParameter[])obj;
			MySqlDataReader dataReader = dbHelper.GetDataReader(sql, parameter);
			List<RoadFlow.Data.Model.ProgramBuilderButtons> result = DataReaderToList(dataReader);
			((DbDataReader)dataReader).Close();
			return result;
		}
	}
}
