// Decompiled with JetBrains decompiler
// Type: RoadFlow.Data.ORACLE.DocumentsReadUsers
// Assembly: RoadFlow.Data.ORACLE, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: C9018AA1-E48E-4231-92A9-CD6F0F275D11
// Assembly location: C:\inetpub\wwwroot\RoadFlowMvc\bin\RoadFlow.Data.ORACLE.dll

using Oracle.ManagedDataAccess.Client;
using RoadFlow.Data.Interface;
using System;
using System.Collections.Generic;

namespace RoadFlow.Data.ORACLE
{
  public class DocumentsReadUsers : IDocumentsReadUsers
  {
    private DBHelper dbHelper = new DBHelper();

    public int Add(RoadFlow.Data.Model.DocumentsReadUsers model)
    {
      string sql = "INSERT INTO DocumentsReadUsers\r\n\t\t\t\t(DocumentID,UserID,IsRead) \r\n\t\t\t\tVALUES(:DocumentID,:UserID,:IsRead)";
      OracleParameter[] oracleParameterArray = new OracleParameter[3];
      int index1 = 0;
      OracleParameter oracleParameter1 = new OracleParameter(":DocumentID", OracleDbType.Varchar2);
      oracleParameter1.Value = (object) model.DocumentID;
      oracleParameterArray[index1] = oracleParameter1;
      int index2 = 1;
      OracleParameter oracleParameter2 = new OracleParameter(":UserID", OracleDbType.Varchar2);
      oracleParameter2.Value = (object) model.UserID;
      oracleParameterArray[index2] = oracleParameter2;
      int index3 = 2;
      OracleParameter oracleParameter3 = new OracleParameter(":IsRead", OracleDbType.Int32);
      oracleParameter3.Value = (object) model.IsRead;
      oracleParameterArray[index3] = oracleParameter3;
      OracleParameter[] parameter = oracleParameterArray;
      return this.dbHelper.Execute(sql, parameter);
    }

    public int Update(RoadFlow.Data.Model.DocumentsReadUsers model)
    {
      string sql = "UPDATE DocumentsReadUsers SET \r\n\t\t\t\tIsRead=:IsRead\r\n\t\t\t\tWHERE DocumentID=:DocumentID and UserID=:UserID";
      OracleParameter[] oracleParameterArray = new OracleParameter[3];
      int index1 = 0;
      OracleParameter oracleParameter1 = new OracleParameter(":IsRead", OracleDbType.Int32);
      oracleParameter1.Value = (object) model.IsRead;
      oracleParameterArray[index1] = oracleParameter1;
      int index2 = 1;
      OracleParameter oracleParameter2 = new OracleParameter(":DocumentID", OracleDbType.Varchar2);
      oracleParameter2.Value = (object) model.DocumentID;
      oracleParameterArray[index2] = oracleParameter2;
      int index3 = 2;
      OracleParameter oracleParameter3 = new OracleParameter(":UserID", OracleDbType.Varchar2);
      oracleParameter3.Value = (object) model.UserID;
      oracleParameterArray[index3] = oracleParameter3;
      OracleParameter[] parameter = oracleParameterArray;
      return this.dbHelper.Execute(sql, parameter);
    }

    public int Delete(Guid documentid, Guid userid)
    {
      string sql = "DELETE FROM DocumentsReadUsers WHERE DocumentID=:DocumentID AND UserID=:UserID";
      OracleParameter[] oracleParameterArray = new OracleParameter[2];
      int index1 = 0;
      OracleParameter oracleParameter1 = new OracleParameter(":DocumentID", OracleDbType.Varchar2);
      oracleParameter1.Value = (object) documentid;
      oracleParameterArray[index1] = oracleParameter1;
      int index2 = 1;
      OracleParameter oracleParameter2 = new OracleParameter(":UserID", OracleDbType.Varchar2);
      oracleParameter2.Value = (object) userid;
      oracleParameterArray[index2] = oracleParameter2;
      OracleParameter[] parameter = oracleParameterArray;
      return this.dbHelper.Execute(sql, parameter);
    }

    private List<RoadFlow.Data.Model.DocumentsReadUsers> DataReaderToList(OracleDataReader dataReader)
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
      OracleDataReader dataReader = this.dbHelper.GetDataReader("SELECT * FROM DocumentsReadUsers");
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
      string sql = "SELECT * FROM DocumentsReadUsers WHERE DocumentID=:DocumentID AND UserID=:UserID";
      OracleParameter[] oracleParameterArray = new OracleParameter[2];
      int index1 = 0;
      OracleParameter oracleParameter1 = new OracleParameter(":DocumentID", OracleDbType.Varchar2);
      oracleParameter1.Value = (object) documentid;
      oracleParameterArray[index1] = oracleParameter1;
      int index2 = 1;
      OracleParameter oracleParameter2 = new OracleParameter(":UserID", OracleDbType.Varchar2);
      oracleParameter2.Value = (object) userid;
      oracleParameterArray[index2] = oracleParameter2;
      OracleParameter[] parameter = oracleParameterArray;
      OracleDataReader dataReader = this.dbHelper.GetDataReader(sql, parameter);
      List<RoadFlow.Data.Model.DocumentsReadUsers> list = this.DataReaderToList(dataReader);
      dataReader.Close();
      if (list.Count <= 0)
        return (RoadFlow.Data.Model.DocumentsReadUsers) null;
      return list[0];
    }

    public int Delete(Guid documentid)
    {
      string sql = "DELETE FROM DocumentsReadUsers WHERE DocumentID=:DocumentID";
      OracleParameter[] oracleParameterArray = new OracleParameter[1];
      int index = 0;
      OracleParameter oracleParameter = new OracleParameter(":DocumentID", OracleDbType.Varchar2);
      oracleParameter.Value = (object) documentid;
      oracleParameterArray[index] = oracleParameter;
      OracleParameter[] parameter = oracleParameterArray;
      return this.dbHelper.Execute(sql, parameter);
    }

    public void UpdateRead(Guid docID, Guid userID)
    {
      string sql = "UPDATE DocumentsReadUsers SET IsRead=1 WHERE DocumentID=:DocumentID AND UserID=:UserID";
      OracleParameter[] oracleParameterArray = new OracleParameter[2];
      int index1 = 0;
      OracleParameter oracleParameter1 = new OracleParameter(":DocumentID", OracleDbType.Varchar2);
      oracleParameter1.Value = (object) docID;
      oracleParameterArray[index1] = oracleParameter1;
      int index2 = 1;
      OracleParameter oracleParameter2 = new OracleParameter(":UserID", OracleDbType.Varchar2);
      oracleParameter2.Value = (object) userID;
      oracleParameterArray[index2] = oracleParameter2;
      OracleParameter[] parameter = oracleParameterArray;
      this.dbHelper.Execute(sql, parameter);
    }
  }
}
