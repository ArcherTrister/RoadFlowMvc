using MySql.Data.MySqlClient;
using RoadFlow.Data.Interface;
using RoadFlow.Data.Model;
using System;
using System.Collections.Generic;
using System.Data.Common;

namespace RoadFlow.Data.MySql
{
	public class DocumentsReadUsers : IDocumentsReadUsers
	{
		private DBHelper dbHelper = new DBHelper();

		public int Add(RoadFlow.Data.Model.DocumentsReadUsers model)
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
			string sql = "INSERT INTO documentsreadusers\r\n\t\t\t\t(DocumentID,UserID,IsRead) \r\n\t\t\t\tVALUES(@DocumentID,@UserID,@IsRead)";
			MySqlParameter[] obj = new MySqlParameter[3];
			MySqlParameter val = new MySqlParameter("@DocumentID", 253, 36);
			((DbParameter)val).Value = model.DocumentID;
			obj[0] = val;
			MySqlParameter val2 = new MySqlParameter("@UserID", 253, 36);
			((DbParameter)val2).Value = model.UserID;
			obj[1] = val2;
			MySqlParameter val3 = new MySqlParameter("@IsRead", 3, 11);
			((DbParameter)val3).Value = model.IsRead;
			obj[2] = val3;
			MySqlParameter[] parameter = (MySqlParameter[])obj;
			return dbHelper.Execute(sql, parameter);
		}

		public int Update(RoadFlow.Data.Model.DocumentsReadUsers model)
		{
			//IL_0016: Unknown result type (might be due to invalid IL or missing references)
			//IL_001b: Unknown result type (might be due to invalid IL or missing references)
			//IL_002c: Expected O, but got Unknown
			//IL_002d: Expected O, but got Unknown
			//IL_003b: Unknown result type (might be due to invalid IL or missing references)
			//IL_0040: Unknown result type (might be due to invalid IL or missing references)
			//IL_0051: Expected O, but got Unknown
			//IL_0052: Expected O, but got Unknown
			//IL_0060: Unknown result type (might be due to invalid IL or missing references)
			//IL_0065: Unknown result type (might be due to invalid IL or missing references)
			//IL_0076: Expected O, but got Unknown
			//IL_0077: Expected O, but got Unknown
			string sql = "UPDATE documentsreadusers SET \r\n\t\t\t\tIsRead=@IsRead\r\n\t\t\t\tWHERE DocumentID=@DocumentID and UserID=@UserID";
			MySqlParameter[] obj = new MySqlParameter[3];
			MySqlParameter val = new MySqlParameter("@IsRead", 3, 11);
			((DbParameter)val).Value = model.IsRead;
			obj[0] = val;
			MySqlParameter val2 = new MySqlParameter("@DocumentID", 253, 36);
			((DbParameter)val2).Value = model.DocumentID;
			obj[1] = val2;
			MySqlParameter val3 = new MySqlParameter("@UserID", 253, 36);
			((DbParameter)val3).Value = model.UserID;
			obj[2] = val3;
			MySqlParameter[] parameter = (MySqlParameter[])obj;
			return dbHelper.Execute(sql, parameter);
		}

		public int Delete(Guid documentid, Guid userid)
		{
			//IL_001a: Unknown result type (might be due to invalid IL or missing references)
			//IL_001f: Unknown result type (might be due to invalid IL or missing references)
			//IL_0032: Expected O, but got Unknown
			//IL_0033: Expected O, but got Unknown
			//IL_0041: Unknown result type (might be due to invalid IL or missing references)
			//IL_0046: Unknown result type (might be due to invalid IL or missing references)
			//IL_0059: Expected O, but got Unknown
			//IL_005a: Expected O, but got Unknown
			string sql = "DELETE FROM documentsreadusers WHERE DocumentID=@DocumentID AND UserID=@UserID";
			MySqlParameter[] obj = new MySqlParameter[2];
			MySqlParameter val = new MySqlParameter("@DocumentID", 253, 36);
			((DbParameter)val).Value = documentid.ToString();
			obj[0] = val;
			MySqlParameter val2 = new MySqlParameter("@UserID", 253, 36);
			((DbParameter)val2).Value = userid.ToString();
			obj[1] = val2;
			MySqlParameter[] parameter = (MySqlParameter[])obj;
			return dbHelper.Execute(sql, parameter);
		}

		private List<RoadFlow.Data.Model.DocumentsReadUsers> DataReaderToList(MySqlDataReader dataReader)
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
			string sql = "SELECT * FROM documentsreadusers";
			MySqlDataReader dataReader = dbHelper.GetDataReader(sql);
			List<RoadFlow.Data.Model.DocumentsReadUsers> result = DataReaderToList(dataReader);
			((DbDataReader)dataReader).Close();
			return result;
		}

		public long GetCount()
		{
			string sql = "SELECT COUNT(*) FROM documentsreadusers";
			long result;
			if (!long.TryParse(dbHelper.GetFieldValue(sql), out result))
			{
				return 0L;
			}
			return result;
		}

		public RoadFlow.Data.Model.DocumentsReadUsers Get(Guid documentid, Guid userid)
		{
			//IL_001a: Unknown result type (might be due to invalid IL or missing references)
			//IL_001f: Unknown result type (might be due to invalid IL or missing references)
			//IL_0032: Expected O, but got Unknown
			//IL_0033: Expected O, but got Unknown
			//IL_0041: Unknown result type (might be due to invalid IL or missing references)
			//IL_0046: Unknown result type (might be due to invalid IL or missing references)
			//IL_0059: Expected O, but got Unknown
			//IL_005a: Expected O, but got Unknown
			string sql = "SELECT * FROM documentsreadusers WHERE DocumentID=@DocumentID AND UserID=@UserID";
			MySqlParameter[] obj = new MySqlParameter[2];
			MySqlParameter val = new MySqlParameter("@DocumentID", 253, 36);
			((DbParameter)val).Value = documentid.ToString();
			obj[0] = val;
			MySqlParameter val2 = new MySqlParameter("@UserID", 253, 36);
			((DbParameter)val2).Value = userid.ToString();
			obj[1] = val2;
			MySqlParameter[] parameter = (MySqlParameter[])obj;
			MySqlDataReader dataReader = dbHelper.GetDataReader(sql, parameter);
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
			//IL_0018: Unknown result type (might be due to invalid IL or missing references)
			//IL_001d: Unknown result type (might be due to invalid IL or missing references)
			//IL_0029: Expected O, but got Unknown
			//IL_002a: Expected O, but got Unknown
			string sql = "DELETE FROM DocumentsReadUsers WHERE DocumentID=@DocumentID";
			MySqlParameter[] obj = new MySqlParameter[1];
			MySqlParameter val = new MySqlParameter("@DocumentID", 253);
			((DbParameter)val).Value = documentid;
			obj[0] = val;
			MySqlParameter[] parameter = (MySqlParameter[])obj;
			return dbHelper.Execute(sql, parameter);
		}

		public void UpdateRead(Guid docID, Guid userID)
		{
			//IL_0018: Unknown result type (might be due to invalid IL or missing references)
			//IL_001d: Unknown result type (might be due to invalid IL or missing references)
			//IL_0029: Expected O, but got Unknown
			//IL_002a: Expected O, but got Unknown
			//IL_0036: Unknown result type (might be due to invalid IL or missing references)
			//IL_003b: Unknown result type (might be due to invalid IL or missing references)
			//IL_0047: Expected O, but got Unknown
			//IL_0048: Expected O, but got Unknown
			string sql = "UPDATE DocumentsReadUsers SET IsRead=1 WHERE DocumentID=@DocumentID AND UserID=@UserID";
			MySqlParameter[] obj = new MySqlParameter[2];
			MySqlParameter val = new MySqlParameter("@DocumentID", 253);
			((DbParameter)val).Value = docID;
			obj[0] = val;
			MySqlParameter val2 = new MySqlParameter("@UserID", 253);
			((DbParameter)val2).Value = userID;
			obj[1] = val2;
			MySqlParameter[] parameter = (MySqlParameter[])obj;
			dbHelper.Execute(sql, parameter);
		}
	}
}
