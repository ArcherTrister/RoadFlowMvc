using Oracle.ManagedDataAccess.Client;
using RoadFlow.Data.Interface;
using RoadFlow.Data.Model;
using System;
using System.Collections.Generic;
using System.Data.Common;

namespace RoadFlow.Data.ORACLE
{
	public class UsersRelation : IUsersRelation
	{
		private DBHelper dbHelper = new DBHelper();

		public int Add(RoadFlow.Data.Model.UsersRelation model)
		{
			//IL_0017: Unknown result type (might be due to invalid IL or missing references)
			//IL_001c: Unknown result type (might be due to invalid IL or missing references)
			//IL_002d: Expected O, but got Unknown
			//IL_002e: Expected O, but got Unknown
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
			string sql = "INSERT INTO UsersRelation\r\n\t\t\t\t(UserID,OrganizeID,IsMain,Sort) \r\n\t\t\t\tVALUES(:UserID,:OrganizeID,:IsMain,:Sort)";
			OracleParameter[] obj = new OracleParameter[4];
			OracleParameter val = new OracleParameter(":UserID", 126, 40);
			((DbParameter)val).Value = model.UserID;
			obj[0] = val;
			OracleParameter val2 = new OracleParameter(":OrganizeID", 126, 40);
			((DbParameter)val2).Value = model.OrganizeID;
			obj[1] = val2;
			OracleParameter val3 = new OracleParameter(":IsMain", 112);
			((DbParameter)val3).Value = model.IsMain;
			obj[2] = val3;
			OracleParameter val4 = new OracleParameter(":Sort", 112);
			((DbParameter)val4).Value = model.Sort;
			obj[3] = val4;
			OracleParameter[] parameter = (OracleParameter[])obj;
			return dbHelper.Execute(sql, parameter);
		}

		public int Update(RoadFlow.Data.Model.UsersRelation model)
		{
			//IL_0015: Unknown result type (might be due to invalid IL or missing references)
			//IL_001a: Unknown result type (might be due to invalid IL or missing references)
			//IL_002b: Expected O, but got Unknown
			//IL_002c: Expected O, but got Unknown
			//IL_0035: Unknown result type (might be due to invalid IL or missing references)
			//IL_003a: Unknown result type (might be due to invalid IL or missing references)
			//IL_004b: Expected O, but got Unknown
			//IL_004c: Expected O, but got Unknown
			//IL_0057: Unknown result type (might be due to invalid IL or missing references)
			//IL_005c: Unknown result type (might be due to invalid IL or missing references)
			//IL_006d: Expected O, but got Unknown
			//IL_006e: Expected O, but got Unknown
			//IL_0079: Unknown result type (might be due to invalid IL or missing references)
			//IL_007e: Unknown result type (might be due to invalid IL or missing references)
			//IL_008f: Expected O, but got Unknown
			//IL_0090: Expected O, but got Unknown
			string sql = "UPDATE UsersRelation SET \r\n\t\t\t\tIsMain=:IsMain,Sort=:Sort\r\n\t\t\t\tWHERE UserID=:UserID and OrganizeID=:OrganizeID";
			OracleParameter[] obj = new OracleParameter[4];
			OracleParameter val = new OracleParameter(":IsMain", 112);
			((DbParameter)val).Value = model.IsMain;
			obj[0] = val;
			OracleParameter val2 = new OracleParameter(":Sort", 112);
			((DbParameter)val2).Value = model.Sort;
			obj[1] = val2;
			OracleParameter val3 = new OracleParameter(":UserID", 126, 40);
			((DbParameter)val3).Value = model.UserID;
			obj[2] = val3;
			OracleParameter val4 = new OracleParameter(":OrganizeID", 126, 40);
			((DbParameter)val4).Value = model.OrganizeID;
			obj[3] = val4;
			OracleParameter[] parameter = (OracleParameter[])obj;
			return dbHelper.Execute(sql, parameter);
		}

		public int Delete(Guid userid, Guid organizeid)
		{
			//IL_0015: Unknown result type (might be due to invalid IL or missing references)
			//IL_001a: Unknown result type (might be due to invalid IL or missing references)
			//IL_0026: Expected O, but got Unknown
			//IL_0027: Expected O, but got Unknown
			//IL_0030: Unknown result type (might be due to invalid IL or missing references)
			//IL_0035: Unknown result type (might be due to invalid IL or missing references)
			//IL_0041: Expected O, but got Unknown
			//IL_0042: Expected O, but got Unknown
			string sql = "DELETE FROM UsersRelation WHERE UserID=:UserID AND OrganizeID=:OrganizeID";
			OracleParameter[] obj = new OracleParameter[2];
			OracleParameter val = new OracleParameter(":UserID", 126);
			((DbParameter)val).Value = userid;
			obj[0] = val;
			OracleParameter val2 = new OracleParameter(":OrganizeID", 126);
			((DbParameter)val2).Value = organizeid;
			obj[1] = val2;
			OracleParameter[] parameter = (OracleParameter[])obj;
			return dbHelper.Execute(sql, parameter);
		}

		private List<RoadFlow.Data.Model.UsersRelation> DataReaderToList(OracleDataReader dataReader)
		{
			List<RoadFlow.Data.Model.UsersRelation> list = new List<RoadFlow.Data.Model.UsersRelation>();
			RoadFlow.Data.Model.UsersRelation usersRelation = null;
			while (((DbDataReader)dataReader).Read())
			{
				usersRelation = new RoadFlow.Data.Model.UsersRelation();
				usersRelation.UserID = ((DbDataReader)dataReader).GetString(0).ToGuid();
				usersRelation.OrganizeID = ((DbDataReader)dataReader).GetString(1).ToGuid();
				usersRelation.IsMain = ((DbDataReader)dataReader).GetInt32(2);
				usersRelation.Sort = ((DbDataReader)dataReader).GetInt32(3);
				list.Add(usersRelation);
			}
			return list;
		}

		public List<RoadFlow.Data.Model.UsersRelation> GetAll()
		{
			string sql = "SELECT * FROM UsersRelation";
			OracleDataReader dataReader = dbHelper.GetDataReader(sql);
			List<RoadFlow.Data.Model.UsersRelation> result = DataReaderToList(dataReader);
			((DbDataReader)dataReader).Close();
			return result;
		}

		public long GetCount()
		{
			string sql = "SELECT COUNT(*) FROM UsersRelation";
			long result;
			if (!long.TryParse(dbHelper.GetFieldValue(sql), out result))
			{
				return 0L;
			}
			return result;
		}

		public RoadFlow.Data.Model.UsersRelation Get(Guid userid, Guid organizeid)
		{
			//IL_0015: Unknown result type (might be due to invalid IL or missing references)
			//IL_001a: Unknown result type (might be due to invalid IL or missing references)
			//IL_0026: Expected O, but got Unknown
			//IL_0027: Expected O, but got Unknown
			//IL_0030: Unknown result type (might be due to invalid IL or missing references)
			//IL_0035: Unknown result type (might be due to invalid IL or missing references)
			//IL_0041: Expected O, but got Unknown
			//IL_0042: Expected O, but got Unknown
			string sql = "SELECT * FROM UsersRelation WHERE UserID=:UserID AND OrganizeID=:OrganizeID";
			OracleParameter[] obj = new OracleParameter[2];
			OracleParameter val = new OracleParameter(":UserID", 126);
			((DbParameter)val).Value = userid;
			obj[0] = val;
			OracleParameter val2 = new OracleParameter(":OrganizeID", 126);
			((DbParameter)val2).Value = organizeid;
			obj[1] = val2;
			OracleParameter[] parameter = (OracleParameter[])obj;
			OracleDataReader dataReader = dbHelper.GetDataReader(sql, parameter);
			List<RoadFlow.Data.Model.UsersRelation> list = DataReaderToList(dataReader);
			((DbDataReader)dataReader).Close();
			if (list.Count <= 0)
			{
				return null;
			}
			return list[0];
		}

		public List<RoadFlow.Data.Model.UsersRelation> GetAllByOrganizeID(Guid organizeID)
		{
			//IL_0015: Unknown result type (might be due to invalid IL or missing references)
			//IL_001a: Unknown result type (might be due to invalid IL or missing references)
			//IL_0026: Expected O, but got Unknown
			//IL_0027: Expected O, but got Unknown
			string sql = "SELECT * FROM UsersRelation WHERE OrganizeID=:OrganizeID";
			OracleParameter[] obj = new OracleParameter[1];
			OracleParameter val = new OracleParameter(":OrganizeID", 126);
			((DbParameter)val).Value = organizeID;
			obj[0] = val;
			OracleParameter[] parameter = (OracleParameter[])obj;
			OracleDataReader dataReader = dbHelper.GetDataReader(sql, parameter);
			List<RoadFlow.Data.Model.UsersRelation> result = DataReaderToList(dataReader);
			((DbDataReader)dataReader).Close();
			return result;
		}

		public List<RoadFlow.Data.Model.UsersRelation> GetAllByUserID(Guid userID)
		{
			//IL_0015: Unknown result type (might be due to invalid IL or missing references)
			//IL_001a: Unknown result type (might be due to invalid IL or missing references)
			//IL_0026: Expected O, but got Unknown
			//IL_0027: Expected O, but got Unknown
			string sql = "SELECT * FROM UsersRelation WHERE UserID=:UserID";
			OracleParameter[] obj = new OracleParameter[1];
			OracleParameter val = new OracleParameter(":UserID", 126);
			((DbParameter)val).Value = userID;
			obj[0] = val;
			OracleParameter[] parameter = (OracleParameter[])obj;
			OracleDataReader dataReader = dbHelper.GetDataReader(sql, parameter);
			List<RoadFlow.Data.Model.UsersRelation> result = DataReaderToList(dataReader);
			((DbDataReader)dataReader).Close();
			return result;
		}

		public RoadFlow.Data.Model.UsersRelation GetMainByUserID(Guid userID)
		{
			//IL_0015: Unknown result type (might be due to invalid IL or missing references)
			//IL_001a: Unknown result type (might be due to invalid IL or missing references)
			//IL_0026: Expected O, but got Unknown
			//IL_0027: Expected O, but got Unknown
			string sql = "SELECT * FROM UsersRelation WHERE UserID=:UserID AND IsMain=1";
			OracleParameter[] obj = new OracleParameter[1];
			OracleParameter val = new OracleParameter(":UserID", 126);
			((DbParameter)val).Value = userID;
			obj[0] = val;
			OracleParameter[] parameter = (OracleParameter[])obj;
			OracleDataReader dataReader = dbHelper.GetDataReader(sql, parameter);
			List<RoadFlow.Data.Model.UsersRelation> list = DataReaderToList(dataReader);
			((DbDataReader)dataReader).Close();
			if (list.Count <= 0)
			{
				return null;
			}
			return list[0];
		}

		public int DeleteByUserID(Guid userID)
		{
			//IL_0015: Unknown result type (might be due to invalid IL or missing references)
			//IL_001a: Unknown result type (might be due to invalid IL or missing references)
			//IL_0026: Expected O, but got Unknown
			//IL_0027: Expected O, but got Unknown
			string sql = "DELETE FROM UsersRelation WHERE UserID=:UserID";
			OracleParameter[] obj = new OracleParameter[1];
			OracleParameter val = new OracleParameter(":UserID", 126);
			((DbParameter)val).Value = userID;
			obj[0] = val;
			OracleParameter[] parameter = (OracleParameter[])obj;
			return dbHelper.Execute(sql, parameter);
		}

		public int DeleteNotIsMainByUserID(Guid userID)
		{
			//IL_0015: Unknown result type (might be due to invalid IL or missing references)
			//IL_001a: Unknown result type (might be due to invalid IL or missing references)
			//IL_0026: Expected O, but got Unknown
			//IL_0027: Expected O, but got Unknown
			string sql = "DELETE FROM UsersRelation WHERE IsMain=0 AND UserID=:UserID";
			OracleParameter[] obj = new OracleParameter[1];
			OracleParameter val = new OracleParameter(":UserID", 126);
			((DbParameter)val).Value = userID;
			obj[0] = val;
			OracleParameter[] parameter = (OracleParameter[])obj;
			return dbHelper.Execute(sql, parameter);
		}

		public int DeleteByOrganizeID(Guid organizeID)
		{
			//IL_0015: Unknown result type (might be due to invalid IL or missing references)
			//IL_001a: Unknown result type (might be due to invalid IL or missing references)
			//IL_0026: Expected O, but got Unknown
			//IL_0027: Expected O, but got Unknown
			string sql = "DELETE FROM UsersRelation WHERE OrganizeID=:OrganizeID";
			OracleParameter[] obj = new OracleParameter[1];
			OracleParameter val = new OracleParameter(":OrganizeID", 126);
			((DbParameter)val).Value = organizeID;
			obj[0] = val;
			OracleParameter[] parameter = (OracleParameter[])obj;
			return dbHelper.Execute(sql, parameter);
		}

		public int GetMaxSort(Guid organizeID)
		{
			//IL_0015: Unknown result type (might be due to invalid IL or missing references)
			//IL_001a: Unknown result type (might be due to invalid IL or missing references)
			//IL_0026: Expected O, but got Unknown
			//IL_0027: Expected O, but got Unknown
			string sql = "SELECT nvl(MAX(Sort),0)+1 FROM UsersRelation WHERE OrganizeID=:OrganizeID";
			OracleParameter[] obj = new OracleParameter[1];
			OracleParameter val = new OracleParameter(":OrganizeID", 126);
			((DbParameter)val).Value = organizeID;
			obj[0] = val;
			OracleParameter[] parameter = (OracleParameter[])obj;
			return new DBHelper().GetFieldValue(sql, parameter).ToInt();
		}
	}
}
