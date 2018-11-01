using MySql.Data.MySqlClient;
using RoadFlow.Data.Interface;
using RoadFlow.Data.Model;
using System;
using System.Collections.Generic;
using System.Data.Common;

namespace RoadFlow.Data.MySql
{
	public class UsersRelation : IUsersRelation
	{
		private DBHelper dbHelper = new DBHelper();

		public int Add(RoadFlow.Data.Model.UsersRelation model)
		{
			//IL_001a: Unknown result type (might be due to invalid IL or missing references)
			//IL_001f: Unknown result type (might be due to invalid IL or missing references)
			//IL_0030: Expected O, but got Unknown
			//IL_0031: Expected O, but got Unknown
			//IL_003f: Unknown result type (might be due to invalid IL or missing references)
			//IL_0044: Unknown result type (might be due to invalid IL or missing references)
			//IL_0055: Expected O, but got Unknown
			//IL_0056: Expected O, but got Unknown
			//IL_0060: Unknown result type (might be due to invalid IL or missing references)
			//IL_0065: Unknown result type (might be due to invalid IL or missing references)
			//IL_0076: Expected O, but got Unknown
			//IL_0077: Expected O, but got Unknown
			//IL_0081: Unknown result type (might be due to invalid IL or missing references)
			//IL_0086: Unknown result type (might be due to invalid IL or missing references)
			//IL_0097: Expected O, but got Unknown
			//IL_0098: Expected O, but got Unknown
			string sql = "INSERT INTO usersrelation\r\n\t\t\t\t(UserID,OrganizeID,IsMain,Sort) \r\n\t\t\t\tVALUES(@UserID,@OrganizeID,@IsMain,@Sort)";
			MySqlParameter[] obj = new MySqlParameter[4];
			MySqlParameter val = new MySqlParameter("@UserID", 253, 36);
			((DbParameter)val).Value = model.UserID;
			obj[0] = val;
			MySqlParameter val2 = new MySqlParameter("@OrganizeID", 253, 36);
			((DbParameter)val2).Value = model.OrganizeID;
			obj[1] = val2;
			MySqlParameter val3 = new MySqlParameter("@IsMain", 3, 11);
			((DbParameter)val3).Value = model.IsMain;
			obj[2] = val3;
			MySqlParameter val4 = new MySqlParameter("@Sort", 3, 11);
			((DbParameter)val4).Value = model.Sort;
			obj[3] = val4;
			MySqlParameter[] parameter = (MySqlParameter[])obj;
			return dbHelper.Execute(sql, parameter);
		}

		public int Update(RoadFlow.Data.Model.UsersRelation model)
		{
			//IL_0016: Unknown result type (might be due to invalid IL or missing references)
			//IL_001b: Unknown result type (might be due to invalid IL or missing references)
			//IL_002c: Expected O, but got Unknown
			//IL_002d: Expected O, but got Unknown
			//IL_0037: Unknown result type (might be due to invalid IL or missing references)
			//IL_003c: Unknown result type (might be due to invalid IL or missing references)
			//IL_004d: Expected O, but got Unknown
			//IL_004e: Expected O, but got Unknown
			//IL_005c: Unknown result type (might be due to invalid IL or missing references)
			//IL_0061: Unknown result type (might be due to invalid IL or missing references)
			//IL_0072: Expected O, but got Unknown
			//IL_0073: Expected O, but got Unknown
			//IL_0081: Unknown result type (might be due to invalid IL or missing references)
			//IL_0086: Unknown result type (might be due to invalid IL or missing references)
			//IL_0097: Expected O, but got Unknown
			//IL_0098: Expected O, but got Unknown
			string sql = "UPDATE usersrelation SET \r\n\t\t\t\tIsMain=@IsMain,Sort=@Sort\r\n\t\t\t\tWHERE UserID=@UserID and OrganizeID=@OrganizeID";
			MySqlParameter[] obj = new MySqlParameter[4];
			MySqlParameter val = new MySqlParameter("@IsMain", 3, 11);
			((DbParameter)val).Value = model.IsMain;
			obj[0] = val;
			MySqlParameter val2 = new MySqlParameter("@Sort", 3, 11);
			((DbParameter)val2).Value = model.Sort;
			obj[1] = val2;
			MySqlParameter val3 = new MySqlParameter("@UserID", 253, 36);
			((DbParameter)val3).Value = model.UserID;
			obj[2] = val3;
			MySqlParameter val4 = new MySqlParameter("@OrganizeID", 253, 36);
			((DbParameter)val4).Value = model.OrganizeID;
			obj[3] = val4;
			MySqlParameter[] parameter = (MySqlParameter[])obj;
			return dbHelper.Execute(sql, parameter);
		}

		public int Delete(Guid userid, Guid organizeid)
		{
			//IL_001a: Unknown result type (might be due to invalid IL or missing references)
			//IL_001f: Unknown result type (might be due to invalid IL or missing references)
			//IL_0032: Expected O, but got Unknown
			//IL_0033: Expected O, but got Unknown
			//IL_0041: Unknown result type (might be due to invalid IL or missing references)
			//IL_0046: Unknown result type (might be due to invalid IL or missing references)
			//IL_0059: Expected O, but got Unknown
			//IL_005a: Expected O, but got Unknown
			string sql = "DELETE FROM usersrelation WHERE UserID=@UserID AND OrganizeID=@OrganizeID";
			MySqlParameter[] obj = new MySqlParameter[2];
			MySqlParameter val = new MySqlParameter("@UserID", 253, 36);
			((DbParameter)val).Value = userid.ToString();
			obj[0] = val;
			MySqlParameter val2 = new MySqlParameter("@OrganizeID", 253, 36);
			((DbParameter)val2).Value = organizeid.ToString();
			obj[1] = val2;
			MySqlParameter[] parameter = (MySqlParameter[])obj;
			return dbHelper.Execute(sql, parameter);
		}

		private List<RoadFlow.Data.Model.UsersRelation> DataReaderToList(MySqlDataReader dataReader)
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
			string sql = "SELECT * FROM usersrelation";
			MySqlDataReader dataReader = dbHelper.GetDataReader(sql);
			List<RoadFlow.Data.Model.UsersRelation> result = DataReaderToList(dataReader);
			((DbDataReader)dataReader).Close();
			return result;
		}

		public long GetCount()
		{
			string sql = "SELECT COUNT(*) FROM usersrelation";
			long result;
			if (!long.TryParse(dbHelper.GetFieldValue(sql), out result))
			{
				return 0L;
			}
			return result;
		}

		public RoadFlow.Data.Model.UsersRelation Get(Guid userid, Guid organizeid)
		{
			//IL_001a: Unknown result type (might be due to invalid IL or missing references)
			//IL_001f: Unknown result type (might be due to invalid IL or missing references)
			//IL_0032: Expected O, but got Unknown
			//IL_0033: Expected O, but got Unknown
			//IL_0041: Unknown result type (might be due to invalid IL or missing references)
			//IL_0046: Unknown result type (might be due to invalid IL or missing references)
			//IL_0059: Expected O, but got Unknown
			//IL_005a: Expected O, but got Unknown
			string sql = "SELECT * FROM usersrelation WHERE UserID=@UserID AND OrganizeID=@OrganizeID";
			MySqlParameter[] obj = new MySqlParameter[2];
			MySqlParameter val = new MySqlParameter("@UserID", 253, 36);
			((DbParameter)val).Value = userid.ToString();
			obj[0] = val;
			MySqlParameter val2 = new MySqlParameter("@OrganizeID", 253, 36);
			((DbParameter)val2).Value = organizeid.ToString();
			obj[1] = val2;
			MySqlParameter[] parameter = (MySqlParameter[])obj;
			MySqlDataReader dataReader = dbHelper.GetDataReader(sql, parameter);
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
			//IL_0018: Unknown result type (might be due to invalid IL or missing references)
			//IL_001d: Unknown result type (might be due to invalid IL or missing references)
			//IL_0030: Expected O, but got Unknown
			//IL_0031: Expected O, but got Unknown
			string sql = "SELECT * FROM UsersRelation WHERE OrganizeID=@OrganizeID";
			MySqlParameter[] obj = new MySqlParameter[1];
			MySqlParameter val = new MySqlParameter("@OrganizeID", 253);
			((DbParameter)val).Value = organizeID.ToString();
			obj[0] = val;
			MySqlParameter[] parameter = (MySqlParameter[])obj;
			MySqlDataReader dataReader = dbHelper.GetDataReader(sql, parameter);
			List<RoadFlow.Data.Model.UsersRelation> result = DataReaderToList(dataReader);
			((DbDataReader)dataReader).Close();
			return result;
		}

		public List<RoadFlow.Data.Model.UsersRelation> GetAllByUserID(Guid userID)
		{
			//IL_0018: Unknown result type (might be due to invalid IL or missing references)
			//IL_001d: Unknown result type (might be due to invalid IL or missing references)
			//IL_0030: Expected O, but got Unknown
			//IL_0031: Expected O, but got Unknown
			string sql = "SELECT * FROM UsersRelation WHERE UserID=@UserID";
			MySqlParameter[] obj = new MySqlParameter[1];
			MySqlParameter val = new MySqlParameter("@UserID", 253);
			((DbParameter)val).Value = userID.ToString();
			obj[0] = val;
			MySqlParameter[] parameter = (MySqlParameter[])obj;
			MySqlDataReader dataReader = dbHelper.GetDataReader(sql, parameter);
			List<RoadFlow.Data.Model.UsersRelation> result = DataReaderToList(dataReader);
			((DbDataReader)dataReader).Close();
			return result;
		}

		public RoadFlow.Data.Model.UsersRelation GetMainByUserID(Guid userID)
		{
			//IL_0018: Unknown result type (might be due to invalid IL or missing references)
			//IL_001d: Unknown result type (might be due to invalid IL or missing references)
			//IL_0030: Expected O, but got Unknown
			//IL_0031: Expected O, but got Unknown
			string sql = "SELECT * FROM UsersRelation WHERE UserID=@UserID AND IsMain=1";
			MySqlParameter[] obj = new MySqlParameter[1];
			MySqlParameter val = new MySqlParameter("@UserID", 253);
			((DbParameter)val).Value = userID.ToString();
			obj[0] = val;
			MySqlParameter[] parameter = (MySqlParameter[])obj;
			MySqlDataReader dataReader = dbHelper.GetDataReader(sql, parameter);
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
			//IL_0018: Unknown result type (might be due to invalid IL or missing references)
			//IL_001d: Unknown result type (might be due to invalid IL or missing references)
			//IL_0030: Expected O, but got Unknown
			//IL_0031: Expected O, but got Unknown
			string sql = "DELETE FROM UsersRelation WHERE UserID=@UserID";
			MySqlParameter[] obj = new MySqlParameter[1];
			MySqlParameter val = new MySqlParameter("@UserID", 253);
			((DbParameter)val).Value = userID.ToString();
			obj[0] = val;
			MySqlParameter[] parameter = (MySqlParameter[])obj;
			return dbHelper.Execute(sql, parameter);
		}

		public int DeleteNotIsMainByUserID(Guid userID)
		{
			//IL_0018: Unknown result type (might be due to invalid IL or missing references)
			//IL_001d: Unknown result type (might be due to invalid IL or missing references)
			//IL_0030: Expected O, but got Unknown
			//IL_0031: Expected O, but got Unknown
			string sql = "DELETE FROM UsersRelation WHERE IsMain=0 AND UserID=@UserID";
			MySqlParameter[] obj = new MySqlParameter[1];
			MySqlParameter val = new MySqlParameter("@UserID", 253);
			((DbParameter)val).Value = userID.ToString();
			obj[0] = val;
			MySqlParameter[] parameter = (MySqlParameter[])obj;
			return dbHelper.Execute(sql, parameter);
		}

		public int DeleteByOrganizeID(Guid organizeID)
		{
			//IL_0018: Unknown result type (might be due to invalid IL or missing references)
			//IL_001d: Unknown result type (might be due to invalid IL or missing references)
			//IL_0030: Expected O, but got Unknown
			//IL_0031: Expected O, but got Unknown
			string sql = "DELETE FROM UsersRelation WHERE OrganizeID=@OrganizeID";
			MySqlParameter[] obj = new MySqlParameter[1];
			MySqlParameter val = new MySqlParameter("@OrganizeID", 253);
			((DbParameter)val).Value = organizeID.ToString();
			obj[0] = val;
			MySqlParameter[] parameter = (MySqlParameter[])obj;
			return dbHelper.Execute(sql, parameter);
		}

		public int GetMaxSort(Guid organizeID)
		{
			//IL_0018: Unknown result type (might be due to invalid IL or missing references)
			//IL_001d: Unknown result type (might be due to invalid IL or missing references)
			//IL_0030: Expected O, but got Unknown
			//IL_0031: Expected O, but got Unknown
			string sql = "SELECT IFNULL(MAX(Sort),0)+1 FROM UsersRelation WHERE OrganizeID=@OrganizeID";
			MySqlParameter[] obj = new MySqlParameter[1];
			MySqlParameter val = new MySqlParameter("@OrganizeID", 253);
			((DbParameter)val).Value = organizeID.ToString();
			obj[0] = val;
			MySqlParameter[] parameter = (MySqlParameter[])obj;
			return new DBHelper().GetFieldValue(sql, parameter).ToInt();
		}
	}
}
