// Decompiled with JetBrains decompiler
// Type: RoadFlow.Data.MySql.DocumentsReadUsers
// Assembly: RoadFlow.Data.MySql, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 29B652D7-5F6F-4A7D-AD1C-9F2C643FD784
// Assembly location: C:\inetpub\wwwroot\RoadFlowMvc\bin\RoadFlow.Data.MySql.dll

using MySql.Data.MySqlClient;
using RoadFlow.Data.Interface;
using System;
using System.Collections.Generic;

namespace RoadFlow.Data.MySql
{
  public class DocumentsReadUsers : IDocumentsReadUsers
  {
    private DBHelper dbHelper = new DBHelper();

    public int Add(RoadFlow.Data.Model.DocumentsReadUsers model)
    {
      string sql = "INSERT INTO documentsreadusers\r\n\t\t\t\t(DocumentID,UserID,IsRead) \r\n\t\t\t\tVALUES(@DocumentID,@UserID,@IsRead)";
      MySqlParameter[] mySqlParameterArray = new MySqlParameter[3];
      int index1 = 0;
      MySqlParameter mySqlParameter1 = new MySqlParameter("@DocumentID", MySqlDbType.VarChar, 36);
      mySqlParameter1.Value = (object) model.DocumentID;
      mySqlParameterArray[index1] = mySqlParameter1;
      int index2 = 1;
      MySqlParameter mySqlParameter2 = new MySqlParameter("@UserID", MySqlDbType.VarChar, 36);
      mySqlParameter2.Value = (object) model.UserID;
      mySqlParameterArray[index2] = mySqlParameter2;
      int index3 = 2;
      MySqlParameter mySqlParameter3 = new MySqlParameter("@IsRead", MySqlDbType.Int32, 11);
      mySqlParameter3.Value = (object) model.IsRead;
      mySqlParameterArray[index3] = mySqlParameter3;
      MySqlParameter[] parameter = mySqlParameterArray;
      return this.dbHelper.Execute(sql, parameter, false);
    }

    public int Update(RoadFlow.Data.Model.DocumentsReadUsers model)
    {
      string sql = "UPDATE documentsreadusers SET \r\n\t\t\t\tIsRead=@IsRead\r\n\t\t\t\tWHERE DocumentID=@DocumentID and UserID=@UserID";
      MySqlParameter[] mySqlParameterArray = new MySqlParameter[3];
      int index1 = 0;
      MySqlParameter mySqlParameter1 = new MySqlParameter("@IsRead", MySqlDbType.Int32, 11);
      mySqlParameter1.Value = (object) model.IsRead;
      mySqlParameterArray[index1] = mySqlParameter1;
      int index2 = 1;
      MySqlParameter mySqlParameter2 = new MySqlParameter("@DocumentID", MySqlDbType.VarChar, 36);
      mySqlParameter2.Value = (object) model.DocumentID;
      mySqlParameterArray[index2] = mySqlParameter2;
      int index3 = 2;
      MySqlParameter mySqlParameter3 = new MySqlParameter("@UserID", MySqlDbType.VarChar, 36);
      mySqlParameter3.Value = (object) model.UserID;
      mySqlParameterArray[index3] = mySqlParameter3;
      MySqlParameter[] parameter = mySqlParameterArray;
      return this.dbHelper.Execute(sql, parameter, false);
    }

    public int Delete(Guid documentid, Guid userid)
    {
      string sql = "DELETE FROM documentsreadusers WHERE DocumentID=@DocumentID AND UserID=@UserID";
      MySqlParameter[] mySqlParameterArray = new MySqlParameter[2];
      int index1 = 0;
      MySqlParameter mySqlParameter1 = new MySqlParameter("@DocumentID", MySqlDbType.VarChar, 36);
      mySqlParameter1.Value = (object) documentid.ToString();
      mySqlParameterArray[index1] = mySqlParameter1;
      int index2 = 1;
      MySqlParameter mySqlParameter2 = new MySqlParameter("@UserID", MySqlDbType.VarChar, 36);
      mySqlParameter2.Value = (object) userid.ToString();
      mySqlParameterArray[index2] = mySqlParameter2;
      MySqlParameter[] parameter = mySqlParameterArray;
      return this.dbHelper.Execute(sql, parameter, false);
    }

    private List<RoadFlow.Data.Model.DocumentsReadUsers> DataReaderToList(MySqlDataReader dataReader)
    {
      List<RoadFlow.Data.Model.DocumentsReadUsers> documentsReadUsersList = new List<RoadFlow.Data.Model.DocumentsReadUsers>();
      while (dataReader.Read())
        documentsReadUsersList.Add(new RoadFlow.Data.Model.DocumentsReadUsers()
        {
          DocumentID = dataReader.GetString(0).ToGuid(),
          UserID = dataReader.GetString(1).ToGuid(),
          IsRead = dataReader.GetInt32(2)
        });
      return documentsReadUsersList;
    }

    public List<RoadFlow.Data.Model.DocumentsReadUsers> GetAll()
    {
      MySqlDataReader dataReader = this.dbHelper.GetDataReader("SELECT * FROM documentsreadusers");
      List<RoadFlow.Data.Model.DocumentsReadUsers> list = this.DataReaderToList(dataReader);
      dataReader.Close();
      return list;
    }

    public long GetCount()
    {
      long result;
      if (!long.TryParse(this.dbHelper.GetFieldValue("SELECT COUNT(*) FROM documentsreadusers"), out result))
        return 0;
      return result;
    }

    public RoadFlow.Data.Model.DocumentsReadUsers Get(Guid documentid, Guid userid)
    {
      string sql = "SELECT * FROM documentsreadusers WHERE DocumentID=@DocumentID AND UserID=@UserID";
      MySqlParameter[] mySqlParameterArray = new MySqlParameter[2];
      int index1 = 0;
      MySqlParameter mySqlParameter1 = new MySqlParameter("@DocumentID", MySqlDbType.VarChar, 36);
      mySqlParameter1.Value = (object) documentid.ToString();
      mySqlParameterArray[index1] = mySqlParameter1;
      int index2 = 1;
      MySqlParameter mySqlParameter2 = new MySqlParameter("@UserID", MySqlDbType.VarChar, 36);
      mySqlParameter2.Value = (object) userid.ToString();
      mySqlParameterArray[index2] = mySqlParameter2;
      MySqlParameter[] parameter = mySqlParameterArray;
      MySqlDataReader dataReader = this.dbHelper.GetDataReader(sql, parameter);
      List<RoadFlow.Data.Model.DocumentsReadUsers> list = this.DataReaderToList(dataReader);
      dataReader.Close();
      if (list.Count <= 0)
        return (RoadFlow.Data.Model.DocumentsReadUsers) null;
      return list[0];
    }

    public int Delete(Guid documentid)
    {
      string sql = "DELETE FROM DocumentsReadUsers WHERE DocumentID=@DocumentID";
      MySqlParameter[] mySqlParameterArray = new MySqlParameter[1];
      int index = 0;
      MySqlParameter mySqlParameter = new MySqlParameter("@DocumentID", MySqlDbType.VarChar);
      mySqlParameter.Value = (object) documentid;
      mySqlParameterArray[index] = mySqlParameter;
      MySqlParameter[] parameter = mySqlParameterArray;
      return this.dbHelper.Execute(sql, parameter, false);
    }

    public void UpdateRead(Guid docID, Guid userID)
    {
      string sql = "UPDATE DocumentsReadUsers SET IsRead=1 WHERE DocumentID=@DocumentID AND UserID=@UserID";
      MySqlParameter[] mySqlParameterArray = new MySqlParameter[2];
      int index1 = 0;
      MySqlParameter mySqlParameter1 = new MySqlParameter("@DocumentID", MySqlDbType.VarChar);
      mySqlParameter1.Value = (object) docID;
      mySqlParameterArray[index1] = mySqlParameter1;
      int index2 = 1;
      MySqlParameter mySqlParameter2 = new MySqlParameter("@UserID", MySqlDbType.VarChar);
      mySqlParameter2.Value = (object) userID;
      mySqlParameterArray[index2] = mySqlParameter2;
      MySqlParameter[] parameter = mySqlParameterArray;
      this.dbHelper.Execute(sql, parameter, false);
    }
  }
}
