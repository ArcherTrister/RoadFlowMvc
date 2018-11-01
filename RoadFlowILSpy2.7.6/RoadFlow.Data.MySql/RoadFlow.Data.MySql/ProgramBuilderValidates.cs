using MySql.Data.MySqlClient;
using RoadFlow.Data.Interface;
using RoadFlow.Data.Model;
using System;
using System.Collections.Generic;
using System.Data.Common;

namespace RoadFlow.Data.MySql
{
	public class ProgramBuilderValidates : IProgramBuilderValidates
	{
		private DBHelper dbHelper = new DBHelper();

		public int Add(RoadFlow.Data.Model.ProgramBuilderValidates model)
		{
			//IL_001a: Unknown result type (might be due to invalid IL or missing references)
			//IL_001f: Unknown result type (might be due to invalid IL or missing references)
			//IL_0030: Expected O, but got Unknown
			//IL_0031: Expected O, but got Unknown
			//IL_003f: Unknown result type (might be due to invalid IL or missing references)
			//IL_0044: Unknown result type (might be due to invalid IL or missing references)
			//IL_0055: Expected O, but got Unknown
			//IL_0056: Expected O, but got Unknown
			//IL_0063: Unknown result type (might be due to invalid IL or missing references)
			//IL_0068: Unknown result type (might be due to invalid IL or missing references)
			//IL_0074: Expected O, but got Unknown
			//IL_0075: Expected O, but got Unknown
			//IL_0082: Unknown result type (might be due to invalid IL or missing references)
			//IL_0087: Unknown result type (might be due to invalid IL or missing references)
			//IL_0093: Expected O, but got Unknown
			//IL_0094: Expected O, but got Unknown
			//IL_00a9: Unknown result type (might be due to invalid IL or missing references)
			//IL_00ae: Unknown result type (might be due to invalid IL or missing references)
			//IL_00ba: Expected O, but got Unknown
			//IL_00c7: Unknown result type (might be due to invalid IL or missing references)
			//IL_00cc: Unknown result type (might be due to invalid IL or missing references)
			//IL_00d7: Expected O, but got Unknown
			//IL_00d8: Expected O, but got Unknown
			//IL_00e2: Unknown result type (might be due to invalid IL or missing references)
			//IL_00e7: Unknown result type (might be due to invalid IL or missing references)
			//IL_00f8: Expected O, but got Unknown
			//IL_00f9: Expected O, but got Unknown
			string sql = "INSERT INTO programbuildervalidates\r\n\t\t\t\t(ID,ProgramID,TableName,FieldName,FieldNote,Validate) \r\n\t\t\t\tVALUES(@ID,@ProgramID,@TableName,@FieldName,@FieldNote,@Validate)";
			MySqlParameter[] obj = new MySqlParameter[6];
			MySqlParameter val = new MySqlParameter("@ID", 253, 36);
			((DbParameter)val).Value = model.ID;
			obj[0] = val;
			MySqlParameter val2 = new MySqlParameter("@ProgramID", 253, 36);
			((DbParameter)val2).Value = model.ProgramID;
			obj[1] = val2;
			MySqlParameter val3 = new MySqlParameter("@TableName", 752, -1);
			((DbParameter)val3).Value = model.TableName;
			obj[2] = val3;
			MySqlParameter val4 = new MySqlParameter("@FieldName", 752, -1);
			((DbParameter)val4).Value = model.FieldName;
			obj[3] = val4;
			_003F val5;
			if (model.FieldNote != null)
			{
				val5 = new MySqlParameter("@FieldNote", 752, -1);
				((DbParameter)val5).Value = model.FieldNote;
			}
			else
			{
				val5 = new MySqlParameter("@FieldNote", 752, -1);
				((DbParameter)val5).Value = DBNull.Value;
			}
			obj[4] = val5;
			MySqlParameter val6 = new MySqlParameter("@Validate", 3, 11);
			((DbParameter)val6).Value = model.Validate;
			obj[5] = val6;
			MySqlParameter[] parameter = (MySqlParameter[])obj;
			return dbHelper.Execute(sql, parameter);
		}

		public int Update(RoadFlow.Data.Model.ProgramBuilderValidates model)
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
			//IL_0084: Unknown result type (might be due to invalid IL or missing references)
			//IL_0089: Unknown result type (might be due to invalid IL or missing references)
			//IL_0095: Expected O, but got Unknown
			//IL_00a2: Unknown result type (might be due to invalid IL or missing references)
			//IL_00a7: Unknown result type (might be due to invalid IL or missing references)
			//IL_00b2: Expected O, but got Unknown
			//IL_00b3: Expected O, but got Unknown
			//IL_00bd: Unknown result type (might be due to invalid IL or missing references)
			//IL_00c2: Unknown result type (might be due to invalid IL or missing references)
			//IL_00d3: Expected O, but got Unknown
			//IL_00d4: Expected O, but got Unknown
			//IL_00e2: Unknown result type (might be due to invalid IL or missing references)
			//IL_00e7: Unknown result type (might be due to invalid IL or missing references)
			//IL_00f8: Expected O, but got Unknown
			//IL_00f9: Expected O, but got Unknown
			string sql = "UPDATE programbuildervalidates SET \r\n\t\t\t\tProgramID=@ProgramID,TableName=@TableName,FieldName=@FieldName,FieldNote=@FieldNote,Validate=@Validate\r\n\t\t\t\tWHERE ID=@ID";
			MySqlParameter[] obj = new MySqlParameter[6];
			MySqlParameter val = new MySqlParameter("@ProgramID", 253, 36);
			((DbParameter)val).Value = model.ProgramID;
			obj[0] = val;
			MySqlParameter val2 = new MySqlParameter("@TableName", 752, -1);
			((DbParameter)val2).Value = model.TableName;
			obj[1] = val2;
			MySqlParameter val3 = new MySqlParameter("@FieldName", 752, -1);
			((DbParameter)val3).Value = model.FieldName;
			obj[2] = val3;
			_003F val4;
			if (model.FieldNote != null)
			{
				val4 = new MySqlParameter("@FieldNote", 752, -1);
				((DbParameter)val4).Value = model.FieldNote;
			}
			else
			{
				val4 = new MySqlParameter("@FieldNote", 752, -1);
				((DbParameter)val4).Value = DBNull.Value;
			}
			obj[3] = val4;
			MySqlParameter val5 = new MySqlParameter("@Validate", 3, 11);
			((DbParameter)val5).Value = model.Validate;
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
			string sql = "DELETE FROM programbuildervalidates WHERE ID=@ID";
			MySqlParameter[] obj = new MySqlParameter[1];
			MySqlParameter val = new MySqlParameter("@ID", 253, 36);
			((DbParameter)val).Value = id.ToString();
			obj[0] = val;
			MySqlParameter[] parameter = (MySqlParameter[])obj;
			return dbHelper.Execute(sql, parameter);
		}

		private List<RoadFlow.Data.Model.ProgramBuilderValidates> DataReaderToList(MySqlDataReader dataReader)
		{
			List<RoadFlow.Data.Model.ProgramBuilderValidates> list = new List<RoadFlow.Data.Model.ProgramBuilderValidates>();
			RoadFlow.Data.Model.ProgramBuilderValidates programBuilderValidates = null;
			while (((DbDataReader)dataReader).Read())
			{
				programBuilderValidates = new RoadFlow.Data.Model.ProgramBuilderValidates();
				programBuilderValidates.ID = ((DbDataReader)dataReader).GetString(0).ToGuid();
				programBuilderValidates.ProgramID = ((DbDataReader)dataReader).GetString(1).ToGuid();
				programBuilderValidates.TableName = ((DbDataReader)dataReader).GetString(2);
				programBuilderValidates.FieldName = ((DbDataReader)dataReader).GetString(3);
				if (!((DbDataReader)dataReader).IsDBNull(4))
				{
					programBuilderValidates.FieldNote = ((DbDataReader)dataReader).GetString(4);
				}
				programBuilderValidates.Validate = ((DbDataReader)dataReader).GetInt32(5);
				list.Add(programBuilderValidates);
			}
			return list;
		}

		public List<RoadFlow.Data.Model.ProgramBuilderValidates> GetAll()
		{
			string sql = "SELECT * FROM programbuildervalidates";
			MySqlDataReader dataReader = dbHelper.GetDataReader(sql);
			List<RoadFlow.Data.Model.ProgramBuilderValidates> result = DataReaderToList(dataReader);
			((DbDataReader)dataReader).Close();
			return result;
		}

		public long GetCount()
		{
			string sql = "SELECT COUNT(*) FROM programbuildervalidates";
			long result;
			if (!long.TryParse(dbHelper.GetFieldValue(sql), out result))
			{
				return 0L;
			}
			return result;
		}

		public RoadFlow.Data.Model.ProgramBuilderValidates Get(Guid id)
		{
			//IL_001a: Unknown result type (might be due to invalid IL or missing references)
			//IL_001f: Unknown result type (might be due to invalid IL or missing references)
			//IL_0032: Expected O, but got Unknown
			//IL_0033: Expected O, but got Unknown
			string sql = "SELECT * FROM programbuildervalidates WHERE ID=@ID";
			MySqlParameter[] obj = new MySqlParameter[1];
			MySqlParameter val = new MySqlParameter("@ID", 253, 36);
			((DbParameter)val).Value = id.ToString();
			obj[0] = val;
			MySqlParameter[] parameter = (MySqlParameter[])obj;
			MySqlDataReader dataReader = dbHelper.GetDataReader(sql, parameter);
			List<RoadFlow.Data.Model.ProgramBuilderValidates> list = DataReaderToList(dataReader);
			((DbDataReader)dataReader).Close();
			if (list.Count <= 0)
			{
				return null;
			}
			return list[0];
		}

		public List<RoadFlow.Data.Model.ProgramBuilderValidates> GetAll(Guid programID)
		{
			//IL_0018: Unknown result type (might be due to invalid IL or missing references)
			//IL_001d: Unknown result type (might be due to invalid IL or missing references)
			//IL_0030: Expected O, but got Unknown
			//IL_0031: Expected O, but got Unknown
			string sql = "SELECT * FROM ProgramBuilderValidates WHERE ProgramID=@ProgramID";
			MySqlParameter[] obj = new MySqlParameter[1];
			MySqlParameter val = new MySqlParameter("@ProgramID", 253);
			((DbParameter)val).Value = programID.ToString();
			obj[0] = val;
			MySqlParameter[] parameter = (MySqlParameter[])obj;
			MySqlDataReader dataReader = dbHelper.GetDataReader(sql, parameter);
			List<RoadFlow.Data.Model.ProgramBuilderValidates> result = DataReaderToList(dataReader);
			((DbDataReader)dataReader).Close();
			return result;
		}

		public int DeleteByProgramID(Guid id)
		{
			//IL_0018: Unknown result type (might be due to invalid IL or missing references)
			//IL_001d: Unknown result type (might be due to invalid IL or missing references)
			//IL_0030: Expected O, but got Unknown
			//IL_0031: Expected O, but got Unknown
			string sql = "DELETE FROM ProgramBuilderValidates WHERE ProgramID=@ProgramID";
			MySqlParameter[] obj = new MySqlParameter[1];
			MySqlParameter val = new MySqlParameter("@ProgramID", 253);
			((DbParameter)val).Value = id.ToString();
			obj[0] = val;
			MySqlParameter[] parameter = (MySqlParameter[])obj;
			return dbHelper.Execute(sql, parameter);
		}
	}
}
