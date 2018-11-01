using Oracle.ManagedDataAccess.Client;
using RoadFlow.Data.Interface;
using RoadFlow.Data.Model;
using System;
using System.Collections.Generic;
using System.Data.Common;

namespace RoadFlow.Data.ORACLE
{
	public class DocumentsReadUsers : IDocumentsReadUsers
	{
		private DBHelper dbHelper = new DBHelper();

		public int Add(RoadFlow.Data.Model.DocumentsReadUsers model)
		{
			//IL_0015: Unknown result type (might be due to invalid IL or missing references)
			//IL_001a: Unknown result type (might be due to invalid IL or missing references)
			//IL_002b: Expected O, but got Unknown
			//IL_002c: Expected O, but got Unknown
			//IL_0035: Unknown result type (might be due to invalid IL or missing references)
			//IL_003a: Unknown result type (might be due to invalid IL or missing references)
			//IL_004b: Expected O, but got Unknown
			//IL_004c: Expected O, but got Unknown
			//IL_0055: Unknown result type (might be due to invalid IL or missing references)
			//IL_005a: Unknown result type (might be due to invalid IL or missing references)
			//IL_006b: Expected O, but got Unknown
			//IL_006c: Expected O, but got Unknown
			string sql = "INSERT INTO DocumentsReadUsers\r\n\t\t\t\t(DocumentID,UserID,IsRead) \r\n\t\t\t\tVALUES(:DocumentID,:UserID,:IsRead)";
			OracleParameter[] obj = new OracleParameter[3];
			OracleParameter val = new OracleParameter(":DocumentID", 126);
			((DbParameter)val).Value = model.DocumentID;
			obj[0] = val;
			OracleParameter val2 = new OracleParameter(":UserID", 126);
			((DbParameter)val2).Value = model.UserID;
			obj[1] = val2;
			OracleParameter val3 = new OracleParameter(":IsRead", 112);
			((DbParameter)val3).Value = model.IsRead;
			obj[2] = val3;
			OracleParameter[] parameter = (OracleParameter[])obj;
			return dbHelper.Execute(sql, parameter);
		}

		public int Update(RoadFlow.Data.Model.DocumentsReadUsers model)
		{
			//IL_0015: Unknown result type (might be due to invalid IL or missing references)
			//IL_001a: Unknown result type (might be due to invalid IL or missing references)
			//IL_002b: Expected O, but got Unknown
			//IL_002c: Expected O, but got Unknown
			//IL_0035: Unknown result type (might be due to invalid IL or missing references)
			//IL_003a: Unknown result type (might be due to invalid IL or missing references)
			//IL_004b: Expected O, but got Unknown
			//IL_004c: Expected O, but got Unknown
			//IL_0055: Unknown result type (might be due to invalid IL or missing references)
			//IL_005a: Unknown result type (might be due to invalid IL or missing references)
			//IL_006b: Expected O, but got Unknown
			//IL_006c: Expected O, but got Unknown
			string sql = "UPDATE DocumentsReadUsers SET \r\n\t\t\t\tIsRead=:IsRead\r\n\t\t\t\tWHERE DocumentID=:DocumentID and UserID=:UserID";
			OracleParameter[] obj = new OracleParameter[3];
			OracleParameter val = new OracleParameter(":IsRead", 112);
			((DbParameter)val).Value = model.IsRead;
			obj[0] = val;
			OracleParameter val2 = new OracleParameter(":DocumentID", 126);
			((DbParameter)val2).Value = model.DocumentID;
			obj[1] = val2;
			OracleParameter val3 = new OracleParameter(":UserID", 126);
			((DbParameter)val3).Value = model.UserID;
			obj[2] = val3;
			OracleParameter[] parameter = (OracleParameter[])obj;
			return dbHelper.Execute(sql, parameter);
		}

		public int Delete(Guid documentid, Guid userid)
		{
			//IL_0015: Unknown result type (might be due to invalid IL or missing references)
			//IL_001a: Unknown result type (might be due to invalid IL or missing references)
			//IL_0026: Expected O, but got Unknown
			//IL_0027: Expected O, but got Unknown
			//IL_0030: Unknown result type (might be due to invalid IL or missing references)
			//IL_0035: Unknown result type (might be due to invalid IL or missing references)
			//IL_0041: Expected O, but got Unknown
			//IL_0042: Expected O, but got Unknown
			string sql = "DELETE FROM DocumentsReadUsers WHERE DocumentID=:DocumentID AND UserID=:UserID";
			OracleParameter[] obj = new OracleParameter[2];
			OracleParameter val = new OracleParameter(":DocumentID", 126);
			((DbParameter)val).Value = documentid;
			obj[0] = val;
			OracleParameter val2 = new OracleParameter(":UserID", 126);
			((DbParameter)val2).Value = userid;
			obj[1] = val2;
			OracleParameter[] parameter = (OracleParameter[])obj;
			return dbHelper.Execute(sql, parameter);
		}

		private List<RoadFlow.Data.Model.DocumentsReadUsers> DataReaderToList(OracleDataReader dataReader)
		{
			List<RoadFlow.Data.Model.DocumentsReadUsers> list = new List<RoadFlow.Data.Model.DocumentsReadUsers>();
			RoadFlow.Data.Model.DocumentsReadUsers documentsReadUsers = null;
			while (((DbDataReader)dataReader).Read())
			{
				documentsReadUsers = new RoadFlow.Data.Model.DocumentsReadUsers();
				documentsReadUsers.DocumentID = ((DbDataReader)dataReader).GetString(0).ToGuid();
				documentsReadUsers.UserID = ((DbDataReader)dataReader).GetString(1).ToGuid();
				documentsReadUsers.IsRead = ((DbDataReader)dataReader).GetInt32(2);
				list.Add(documentsReadUsers);
			}
			return list;
		}

		public List<RoadFlow.Data.Model.DocumentsReadUsers> GetAll()
		{
			string sql = "SELECT * FROM DocumentsReadUsers";
			OracleDataReader dataReader = dbHelper.GetDataReader(sql);
			List<RoadFlow.Data.Model.DocumentsReadUsers> result = DataReaderToList(dataReader);
			((DbDataReader)dataReader).Close();
			return result;
		}

		public long GetCount()
		{
			string sql = "SELECT COUNT(*) FROM DocumentsReadUsers";
			long result;
			if (!long.TryParse(dbHelper.GetFieldValue(sql), out result))
			{
				return 0L;
			}
			return result;
		}

		public RoadFlow.Data.Model.DocumentsReadUsers Get(Guid documentid, Guid userid)
		{
			//IL_0015: Unknown result type (might be due to invalid IL or missing references)
			//IL_001a: Unknown result type (might be due to invalid IL or missing references)
			//IL_0026: Expected O, but got Unknown
			//IL_0027: Expected O, but got Unknown
			//IL_0030: Unknown result type (might be due to invalid IL or missing references)
			//IL_0035: Unknown result type (might be due to invalid IL or missing references)
			//IL_0041: Expected O, but got Unknown
			//IL_0042: Expected O, but got Unknown
			string sql = "SELECT * FROM DocumentsReadUsers WHERE DocumentID=:DocumentID AND UserID=:UserID";
			OracleParameter[] obj = new OracleParameter[2];
			OracleParameter val = new OracleParameter(":DocumentID", 126);
			((DbParameter)val).Value = documentid;
			obj[0] = val;
			OracleParameter val2 = new OracleParameter(":UserID", 126);
			((DbParameter)val2).Value = userid;
			obj[1] = val2;
			OracleParameter[] parameter = (OracleParameter[])obj;
			OracleDataReader dataReader = dbHelper.GetDataReader(sql, parameter);
			List<RoadFlow.Data.Model.DocumentsReadUsers> list = DataReaderToList(dataReader);
			((DbDataReader)dataReader).Close();
			if (list.Count <= 0)
			{
				return null;
			}
			return list[0];
		}

		public int Delete(Guid documentid)
		{
			//IL_0015: Unknown result type (might be due to invalid IL or missing references)
			//IL_001a: Unknown result type (might be due to invalid IL or missing references)
			//IL_0026: Expected O, but got Unknown
			//IL_0027: Expected O, but got Unknown
			string sql = "DELETE FROM DocumentsReadUsers WHERE DocumentID=:DocumentID";
			OracleParameter[] obj = new OracleParameter[1];
			OracleParameter val = new OracleParameter(":DocumentID", 126);
			((DbParameter)val).Value = documentid;
			obj[0] = val;
			OracleParameter[] parameter = (OracleParameter[])obj;
			return dbHelper.Execute(sql, parameter);
		}

		public void UpdateRead(Guid docID, Guid userID)
		{
			//IL_0015: Unknown result type (might be due to invalid IL or missing references)
			//IL_001a: Unknown result type (might be due to invalid IL or missing references)
			//IL_0026: Expected O, but got Unknown
			//IL_0027: Expected O, but got Unknown
			//IL_0030: Unknown result type (might be due to invalid IL or missing references)
			//IL_0035: Unknown result type (might be due to invalid IL or missing references)
			//IL_0041: Expected O, but got Unknown
			//IL_0042: Expected O, but got Unknown
			string sql = "UPDATE DocumentsReadUsers SET IsRead=1 WHERE DocumentID=:DocumentID AND UserID=:UserID";
			OracleParameter[] obj = new OracleParameter[2];
			OracleParameter val = new OracleParameter(":DocumentID", 126);
			((DbParameter)val).Value = docID;
			obj[0] = val;
			OracleParameter val2 = new OracleParameter(":UserID", 126);
			((DbParameter)val2).Value = userID;
			obj[1] = val2;
			OracleParameter[] parameter = (OracleParameter[])obj;
			dbHelper.Execute(sql, parameter);
		}
	}
}
