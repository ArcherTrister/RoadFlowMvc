// Decompiled with JetBrains decompiler
// Type: RoadFlow.Data.MSSQL.DocumentsReadUsers
// Assembly: RoadFlow.Data.MSSQL, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 5107CDC7-8F84-4EE0-AC6D-E80FE4695340
// Assembly location: C:\inetpub\wwwroot\RoadFlowMvc\bin\RoadFlow.Data.MSSQL.dll

using RoadFlow.Data.Interface;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;

namespace RoadFlow.Data.MSSQL
{
  public class DocumentsReadUsers : IDocumentsReadUsers
  {
    private DBHelper dbHelper = new DBHelper();

    public int Add(RoadFlow.Data.Model.DocumentsReadUsers model)
    {
      string sql = "INSERT INTO DocumentsReadUsers\r\n\t\t\t\t(DocumentID,UserID,IsRead) \r\n\t\t\t\tVALUES(@DocumentID,@UserID,@IsRead)";
      SqlParameter[] sqlParameterArray = new SqlParameter[3];
      int index1 = 0;
      SqlParameter sqlParameter1 = new SqlParameter("@DocumentID", SqlDbType.UniqueIdentifier, -1);
      sqlParameter1.Value = (object) model.DocumentID;
      sqlParameterArray[index1] = sqlParameter1;
      int index2 = 1;
      SqlParameter sqlParameter2 = new SqlParameter("@UserID", SqlDbType.UniqueIdentifier, -1);
      sqlParameter2.Value = (object) model.UserID;
      sqlParameterArray[index2] = sqlParameter2;
      int index3 = 2;
      SqlParameter sqlParameter3 = new SqlParameter("@IsRead", SqlDbType.Int, -1);
      sqlParameter3.Value = (object) model.IsRead;
      sqlParameterArray[index3] = sqlParameter3;
      SqlParameter[] parameter = sqlParameterArray;
      return this.dbHelper.Execute(sql, parameter, false);
    }

    public int Update(RoadFlow.Data.Model.DocumentsReadUsers model)
    {
      string sql = "UPDATE DocumentsReadUsers SET \r\n\t\t\t\tIsRead=@IsRead\r\n\t\t\t\tWHERE DocumentID=@DocumentID and UserID=@UserID";
      SqlParameter[] sqlParameterArray = new SqlParameter[3];
      int index1 = 0;
      SqlParameter sqlParameter1 = new SqlParameter("@IsRead", SqlDbType.Int, -1);
      sqlParameter1.Value = (object) model.IsRead;
      sqlParameterArray[index1] = sqlParameter1;
      int index2 = 1;
      SqlParameter sqlParameter2 = new SqlParameter("@DocumentID", SqlDbType.UniqueIdentifier, -1);
      sqlParameter2.Value = (object) model.DocumentID;
      sqlParameterArray[index2] = sqlParameter2;
      int index3 = 2;
      SqlParameter sqlParameter3 = new SqlParameter("@UserID", SqlDbType.UniqueIdentifier, -1);
      sqlParameter3.Value = (object) model.UserID;
      sqlParameterArray[index3] = sqlParameter3;
      SqlParameter[] parameter = sqlParameterArray;
      return this.dbHelper.Execute(sql, parameter, false);
    }

    public int Delete(Guid documentid, Guid userid)
    {
      string sql = "DELETE FROM DocumentsReadUsers WHERE DocumentID=@DocumentID AND UserID=@UserID";
      SqlParameter[] sqlParameterArray = new SqlParameter[2];
      int index1 = 0;
      SqlParameter sqlParameter1 = new SqlParameter("@DocumentID", SqlDbType.UniqueIdentifier);
      sqlParameter1.Value = (object) documentid;
      sqlParameterArray[index1] = sqlParameter1;
      int index2 = 1;
      SqlParameter sqlParameter2 = new SqlParameter("@UserID", SqlDbType.UniqueIdentifier);
      sqlParameter2.Value = (object) userid;
      sqlParameterArray[index2] = sqlParameter2;
      SqlParameter[] parameter = sqlParameterArray;
      return this.dbHelper.Execute(sql, parameter, false);
    }

    private List<RoadFlow.Data.Model.DocumentsReadUsers> DataReaderToList(SqlDataReader dataReader)
    {
      List<RoadFlow.Data.Model.DocumentsReadUsers> documentsReadUsersList = new List<RoadFlow.Data.Model.DocumentsReadUsers>();
      while (dataReader.Read())
        documentsReadUsersList.Add(new RoadFlow.Data.Model.DocumentsReadUsers()
        {
          DocumentID = dataReader.GetGuid(0),
          UserID = dataReader.GetGuid(1),
          IsRead = dataReader.GetInt32(2)
        });
      return documentsReadUsersList;
    }

    public List<RoadFlow.Data.Model.DocumentsReadUsers> GetAll()
    {
      SqlDataReader dataReader = this.dbHelper.GetDataReader("SELECT * FROM DocumentsReadUsers");
      List<RoadFlow.Data.Model.DocumentsReadUsers> list = this.DataReaderToList(dataReader);
      dataReader.Close();
      return list;
    }

    public long GetCount()
    {
      long result;
      if (!long.TryParse(this.dbHelper.GetFieldValue("SELECT COUNT(*) FROM DocumentsReadUsers"), out result))
        return 0;
      return result;
    }

    public RoadFlow.Data.Model.DocumentsReadUsers Get(Guid documentid, Guid userid)
    {
      string sql = "SELECT * FROM DocumentsReadUsers WHERE DocumentID=@DocumentID AND UserID=@UserID";
      SqlParameter[] sqlParameterArray = new SqlParameter[2];
      int index1 = 0;
      SqlParameter sqlParameter1 = new SqlParameter("@DocumentID", SqlDbType.UniqueIdentifier);
      sqlParameter1.Value = (object) documentid;
      sqlParameterArray[index1] = sqlParameter1;
      int index2 = 1;
      SqlParameter sqlParameter2 = new SqlParameter("@UserID", SqlDbType.UniqueIdentifier);
      sqlParameter2.Value = (object) userid;
      sqlParameterArray[index2] = sqlParameter2;
      SqlParameter[] parameter = sqlParameterArray;
      SqlDataReader dataReader = this.dbHelper.GetDataReader(sql, parameter);
      List<RoadFlow.Data.Model.DocumentsReadUsers> list = this.DataReaderToList(dataReader);
      dataReader.Close();
      if (list.Count <= 0)
        return (RoadFlow.Data.Model.DocumentsReadUsers) null;
      return list[0];
    }

    public int Delete(Guid documentid)
    {
      string sql = "DELETE FROM DocumentsReadUsers WHERE DocumentID=@DocumentID";
      SqlParameter[] sqlParameterArray = new SqlParameter[1];
      int index = 0;
      SqlParameter sqlParameter = new SqlParameter("@DocumentID", SqlDbType.UniqueIdentifier);
      sqlParameter.Value = (object) documentid;
      sqlParameterArray[index] = sqlParameter;
      SqlParameter[] parameter = sqlParameterArray;
      return this.dbHelper.Execute(sql, parameter, false);
    }

    public void UpdateRead(Guid docID, Guid userID)
    {
      string sql = "UPDATE DocumentsReadUsers SET IsRead=1 WHERE DocumentID=@DocumentID AND UserID=@UserID";
      SqlParameter[] sqlParameterArray = new SqlParameter[2];
      int index1 = 0;
      SqlParameter sqlParameter1 = new SqlParameter("@DocumentID", SqlDbType.UniqueIdentifier);
      sqlParameter1.Value = (object) docID;
      sqlParameterArray[index1] = sqlParameter1;
      int index2 = 1;
      SqlParameter sqlParameter2 = new SqlParameter("@UserID", SqlDbType.UniqueIdentifier);
      sqlParameter2.Value = (object) userID;
      sqlParameterArray[index2] = sqlParameter2;
      SqlParameter[] parameter = sqlParameterArray;
      this.dbHelper.Execute(sql, parameter, false);
    }
  }
}
