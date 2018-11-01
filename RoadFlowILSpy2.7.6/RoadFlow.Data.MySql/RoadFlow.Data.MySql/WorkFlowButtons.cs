using MySql.Data.MySqlClient;
using RoadFlow.Data.Interface;
using RoadFlow.Data.Model;
using System;
using System.Collections.Generic;
using System.Data.Common;

namespace RoadFlow.Data.MySql
{
	public class WorkFlowButtons : IWorkFlowButtons
	{
		private DBHelper dbHelper = new DBHelper();

		public int Add(RoadFlow.Data.Model.WorkFlowButtons model)
		{
			//IL_001a: Unknown result type (might be due to invalid IL or missing references)
			//IL_001f: Unknown result type (might be due to invalid IL or missing references)
			//IL_0030: Expected O, but got Unknown
			//IL_0031: Expected O, but got Unknown
			//IL_003e: Unknown result type (might be due to invalid IL or missing references)
			//IL_0043: Unknown result type (might be due to invalid IL or missing references)
			//IL_004f: Expected O, but got Unknown
			//IL_0050: Expected O, but got Unknown
			//IL_0065: Unknown result type (might be due to invalid IL or missing references)
			//IL_006a: Unknown result type (might be due to invalid IL or missing references)
			//IL_0076: Expected O, but got Unknown
			//IL_0083: Unknown result type (might be due to invalid IL or missing references)
			//IL_0088: Unknown result type (might be due to invalid IL or missing references)
			//IL_0093: Expected O, but got Unknown
			//IL_0094: Expected O, but got Unknown
			//IL_00a9: Unknown result type (might be due to invalid IL or missing references)
			//IL_00ae: Unknown result type (might be due to invalid IL or missing references)
			//IL_00ba: Expected O, but got Unknown
			//IL_00c7: Unknown result type (might be due to invalid IL or missing references)
			//IL_00cc: Unknown result type (might be due to invalid IL or missing references)
			//IL_00d7: Expected O, but got Unknown
			//IL_00d8: Expected O, but got Unknown
			//IL_00ed: Unknown result type (might be due to invalid IL or missing references)
			//IL_00f2: Unknown result type (might be due to invalid IL or missing references)
			//IL_00fe: Expected O, but got Unknown
			//IL_010b: Unknown result type (might be due to invalid IL or missing references)
			//IL_0110: Unknown result type (might be due to invalid IL or missing references)
			//IL_011b: Expected O, but got Unknown
			//IL_011c: Expected O, but got Unknown
			//IL_0126: Unknown result type (might be due to invalid IL or missing references)
			//IL_012b: Unknown result type (might be due to invalid IL or missing references)
			//IL_013c: Expected O, but got Unknown
			//IL_013d: Expected O, but got Unknown
			string sql = "INSERT INTO workflowbuttons\r\n\t\t\t\t(ID,Title,Ico,Script,Note,Sort) \r\n\t\t\t\tVALUES(@ID,@Title,@Ico,@Script,@Note,@Sort)";
			MySqlParameter[] obj = new MySqlParameter[6];
			MySqlParameter val = new MySqlParameter("@ID", 253, 36);
			((DbParameter)val).Value = model.ID;
			obj[0] = val;
			MySqlParameter val2 = new MySqlParameter("@Title", 752, -1);
			((DbParameter)val2).Value = model.Title;
			obj[1] = val2;
			_003F val3;
			if (model.Ico != null)
			{
				val3 = new MySqlParameter("@Ico", 752, -1);
				((DbParameter)val3).Value = model.Ico;
			}
			else
			{
				val3 = new MySqlParameter("@Ico", 752, -1);
				((DbParameter)val3).Value = DBNull.Value;
			}
			obj[2] = val3;
			_003F val4;
			if (model.Script != null)
			{
				val4 = new MySqlParameter("@Script", 751, -1);
				((DbParameter)val4).Value = model.Script;
			}
			else
			{
				val4 = new MySqlParameter("@Script", 751, -1);
				((DbParameter)val4).Value = DBNull.Value;
			}
			obj[3] = val4;
			_003F val5;
			if (model.Note != null)
			{
				val5 = new MySqlParameter("@Note", 751, -1);
				((DbParameter)val5).Value = model.Note;
			}
			else
			{
				val5 = new MySqlParameter("@Note", 751, -1);
				((DbParameter)val5).Value = DBNull.Value;
			}
			obj[4] = val5;
			MySqlParameter val6 = new MySqlParameter("@Sort", 3, 11);
			((DbParameter)val6).Value = model.Sort;
			obj[5] = val6;
			MySqlParameter[] parameter = (MySqlParameter[])obj;
			return dbHelper.Execute(sql, parameter);
		}

		public int Update(RoadFlow.Data.Model.WorkFlowButtons model)
		{
			//IL_0019: Unknown result type (might be due to invalid IL or missing references)
			//IL_001e: Unknown result type (might be due to invalid IL or missing references)
			//IL_002a: Expected O, but got Unknown
			//IL_002b: Expected O, but got Unknown
			//IL_0040: Unknown result type (might be due to invalid IL or missing references)
			//IL_0045: Unknown result type (might be due to invalid IL or missing references)
			//IL_0051: Expected O, but got Unknown
			//IL_005e: Unknown result type (might be due to invalid IL or missing references)
			//IL_0063: Unknown result type (might be due to invalid IL or missing references)
			//IL_006e: Expected O, but got Unknown
			//IL_006f: Expected O, but got Unknown
			//IL_0084: Unknown result type (might be due to invalid IL or missing references)
			//IL_0089: Unknown result type (might be due to invalid IL or missing references)
			//IL_0095: Expected O, but got Unknown
			//IL_00a2: Unknown result type (might be due to invalid IL or missing references)
			//IL_00a7: Unknown result type (might be due to invalid IL or missing references)
			//IL_00b2: Expected O, but got Unknown
			//IL_00b3: Expected O, but got Unknown
			//IL_00c8: Unknown result type (might be due to invalid IL or missing references)
			//IL_00cd: Unknown result type (might be due to invalid IL or missing references)
			//IL_00d9: Expected O, but got Unknown
			//IL_00e6: Unknown result type (might be due to invalid IL or missing references)
			//IL_00eb: Unknown result type (might be due to invalid IL or missing references)
			//IL_00f6: Expected O, but got Unknown
			//IL_00f7: Expected O, but got Unknown
			//IL_0101: Unknown result type (might be due to invalid IL or missing references)
			//IL_0106: Unknown result type (might be due to invalid IL or missing references)
			//IL_0117: Expected O, but got Unknown
			//IL_0118: Expected O, but got Unknown
			//IL_0126: Unknown result type (might be due to invalid IL or missing references)
			//IL_012b: Unknown result type (might be due to invalid IL or missing references)
			//IL_013c: Expected O, but got Unknown
			//IL_013d: Expected O, but got Unknown
			string sql = "UPDATE workflowbuttons SET \r\n\t\t\t\tTitle=@Title,Ico=@Ico,Script=@Script,Note=@Note,Sort=@Sort\r\n\t\t\t\tWHERE ID=@ID";
			MySqlParameter[] obj = new MySqlParameter[6];
			MySqlParameter val = new MySqlParameter("@Title", 752, -1);
			((DbParameter)val).Value = model.Title;
			obj[0] = val;
			_003F val2;
			if (model.Ico != null)
			{
				val2 = new MySqlParameter("@Ico", 752, -1);
				((DbParameter)val2).Value = model.Ico;
			}
			else
			{
				val2 = new MySqlParameter("@Ico", 752, -1);
				((DbParameter)val2).Value = DBNull.Value;
			}
			obj[1] = val2;
			_003F val3;
			if (model.Script != null)
			{
				val3 = new MySqlParameter("@Script", 751, -1);
				((DbParameter)val3).Value = model.Script;
			}
			else
			{
				val3 = new MySqlParameter("@Script", 751, -1);
				((DbParameter)val3).Value = DBNull.Value;
			}
			obj[2] = val3;
			_003F val4;
			if (model.Note != null)
			{
				val4 = new MySqlParameter("@Note", 751, -1);
				((DbParameter)val4).Value = model.Note;
			}
			else
			{
				val4 = new MySqlParameter("@Note", 751, -1);
				((DbParameter)val4).Value = DBNull.Value;
			}
			obj[3] = val4;
			MySqlParameter val5 = new MySqlParameter("@Sort", 3, 11);
			((DbParameter)val5).Value = model.Sort;
			obj[4] = val5;
			MySqlParameter val6 = new MySqlParameter("@ID", 253, 36);
			((DbParameter)val6).Value = model.ID;
			obj[5] = val6;
			MySqlParameter[] parameter = (MySqlParameter[])obj;
			return dbHelper.Execute(sql, parameter);
		}

		public int Delete(Guid id)
		{
			//IL_001a: Unknown result type (might be due to invalid IL or missing references)
			//IL_001f: Unknown result type (might be due to invalid IL or missing references)
			//IL_0032: Expected O, but got Unknown
			//IL_0033: Expected O, but got Unknown
			string sql = "DELETE FROM workflowbuttons WHERE ID=@ID";
			MySqlParameter[] obj = new MySqlParameter[1];
			MySqlParameter val = new MySqlParameter("@ID", 253, 36);
			((DbParameter)val).Value = id.ToString();
			obj[0] = val;
			MySqlParameter[] parameter = (MySqlParameter[])obj;
			return dbHelper.Execute(sql, parameter);
		}

		private List<RoadFlow.Data.Model.WorkFlowButtons> DataReaderToList(MySqlDataReader dataReader)
		{
			List<RoadFlow.Data.Model.WorkFlowButtons> list = new List<RoadFlow.Data.Model.WorkFlowButtons>();
			RoadFlow.Data.Model.WorkFlowButtons workFlowButtons = null;
			while (((DbDataReader)dataReader).Read())
			{
				workFlowButtons = new RoadFlow.Data.Model.WorkFlowButtons();
				workFlowButtons.ID = ((DbDataReader)dataReader).GetString(0).ToGuid();
				workFlowButtons.Title = ((DbDataReader)dataReader).GetString(1);
				if (!((DbDataReader)dataReader).IsDBNull(2))
				{
					workFlowButtons.Ico = ((DbDataReader)dataReader).GetString(2);
				}
				if (!((DbDataReader)dataReader).IsDBNull(3))
				{
					workFlowButtons.Script = ((DbDataReader)dataReader).GetString(3);
				}
				if (!((DbDataReader)dataReader).IsDBNull(4))
				{
					workFlowButtons.Note = ((DbDataReader)dataReader).GetString(4);
				}
				workFlowButtons.Sort = ((DbDataReader)dataReader).GetInt32(5);
				list.Add(workFlowButtons);
			}
			return list;
		}

		public List<RoadFlow.Data.Model.WorkFlowButtons> GetAll()
		{
			string sql = "SELECT * FROM workflowbuttons";
			MySqlDataReader dataReader = dbHelper.GetDataReader(sql);
			List<RoadFlow.Data.Model.WorkFlowButtons> result = DataReaderToList(dataReader);
			((DbDataReader)dataReader).Close();
			return result;
		}

		public long GetCount()
		{
			string sql = "SELECT COUNT(*) FROM workflowbuttons";
			long result;
			if (!long.TryParse(dbHelper.GetFieldValue(sql), out result))
			{
				return 0L;
			}
			return result;
		}

		public RoadFlow.Data.Model.WorkFlowButtons Get(Guid id)
		{
			//IL_001a: Unknown result type (might be due to invalid IL or missing references)
			//IL_001f: Unknown result type (might be due to invalid IL or missing references)
			//IL_0032: Expected O, but got Unknown
			//IL_0033: Expected O, but got Unknown
			string sql = "SELECT * FROM workflowbuttons WHERE ID=@ID";
			MySqlParameter[] obj = new MySqlParameter[1];
			MySqlParameter val = new MySqlParameter("@ID", 253, 36);
			((DbParameter)val).Value = id.ToString();
			obj[0] = val;
			MySqlParameter[] parameter = (MySqlParameter[])obj;
			MySqlDataReader dataReader = dbHelper.GetDataReader(sql, parameter);
			List<RoadFlow.Data.Model.WorkFlowButtons> list = DataReaderToList(dataReader);
			((DbDataReader)dataReader).Close();
			if (list.Count <= 0)
			{
				return null;
			}
			return list[0];
		}

		public int GetMaxSort()
		{
			string sql = "SELECT IFNULL(MAX(Sort),0)+1 FROM WorkFlowButtons";
			string fieldValue = dbHelper.GetFieldValue(sql);
			if (!fieldValue.IsInt())
			{
				return 1;
			}
			return fieldValue.ToInt();
		}
	}
}
