// Decompiled with JetBrains decompiler
// Type: RoadFlow.Data.ORACLE.UsersRelation
// Assembly: RoadFlow.Data.ORACLE, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: C9018AA1-E48E-4231-92A9-CD6F0F275D11
// Assembly location: C:\inetpub\wwwroot\RoadFlowMvc\bin\RoadFlow.Data.ORACLE.dll

using Oracle.ManagedDataAccess.Client;
using RoadFlow.Data.Interface;
using System;
using System.Collections.Generic;

namespace RoadFlow.Data.ORACLE
{
  public class UsersRelation : IUsersRelation
  {
    private DBHelper dbHelper = new DBHelper();

    public int Add(RoadFlow.Data.Model.UsersRelation model)
    {
      string sql = "INSERT INTO UsersRelation\r\n\t\t\t\t(UserID,OrganizeID,IsMain,Sort) \r\n\t\t\t\tVALUES(:UserID,:OrganizeID,:IsMain,:Sort)";
      OracleParameter[] oracleParameterArray = new OracleParameter[4];
      int index1 = 0;
      OracleParameter oracleParameter1 = new OracleParameter(":UserID", OracleDbType.Varchar2, 40);
      oracleParameter1.Value = (object) model.UserID;
      oracleParameterArray[index1] = oracleParameter1;
      int index2 = 1;
      OracleParameter oracleParameter2 = new OracleParameter(":OrganizeID", OracleDbType.Varchar2, 40);
      oracleParameter2.Value = (object) model.OrganizeID;
      oracleParameterArray[index2] = oracleParameter2;
      int index3 = 2;
      OracleParameter oracleParameter3 = new OracleParameter(":IsMain", OracleDbType.Int32);
      oracleParameter3.Value = (object) model.IsMain;
      oracleParameterArray[index3] = oracleParameter3;
      int index4 = 3;
      OracleParameter oracleParameter4 = new OracleParameter(":Sort", OracleDbType.Int32);
      oracleParameter4.Value = (object) model.Sort;
      oracleParameterArray[index4] = oracleParameter4;
      OracleParameter[] parameter = oracleParameterArray;
      return this.dbHelper.Execute(sql, parameter);
    }

    public int Update(RoadFlow.Data.Model.UsersRelation model)
    {
      string sql = "UPDATE UsersRelation SET \r\n\t\t\t\tIsMain=:IsMain,Sort=:Sort\r\n\t\t\t\tWHERE UserID=:UserID and OrganizeID=:OrganizeID";
      OracleParameter[] oracleParameterArray = new OracleParameter[4];
      int index1 = 0;
      OracleParameter oracleParameter1 = new OracleParameter(":IsMain", OracleDbType.Int32);
      oracleParameter1.Value = (object) model.IsMain;
      oracleParameterArray[index1] = oracleParameter1;
      int index2 = 1;
      OracleParameter oracleParameter2 = new OracleParameter(":Sort", OracleDbType.Int32);
      oracleParameter2.Value = (object) model.Sort;
      oracleParameterArray[index2] = oracleParameter2;
      int index3 = 2;
      OracleParameter oracleParameter3 = new OracleParameter(":UserID", OracleDbType.Varchar2, 40);
      oracleParameter3.Value = (object) model.UserID;
      oracleParameterArray[index3] = oracleParameter3;
      int index4 = 3;
      OracleParameter oracleParameter4 = new OracleParameter(":OrganizeID", OracleDbType.Varchar2, 40);
      oracleParameter4.Value = (object) model.OrganizeID;
      oracleParameterArray[index4] = oracleParameter4;
      OracleParameter[] parameter = oracleParameterArray;
      return this.dbHelper.Execute(sql, parameter);
    }

    public int Delete(Guid userid, Guid organizeid)
    {
      string sql = "DELETE FROM UsersRelation WHERE UserID=:UserID AND OrganizeID=:OrganizeID";
      OracleParameter[] oracleParameterArray = new OracleParameter[2];
      int index1 = 0;
      OracleParameter oracleParameter1 = new OracleParameter(":UserID", OracleDbType.Varchar2);
      oracleParameter1.Value = (object) userid;
      oracleParameterArray[index1] = oracleParameter1;
      int index2 = 1;
      OracleParameter oracleParameter2 = new OracleParameter(":OrganizeID", OracleDbType.Varchar2);
      oracleParameter2.Value = (object) organizeid;
      oracleParameterArray[index2] = oracleParameter2;
      OracleParameter[] parameter = oracleParameterArray;
      return this.dbHelper.Execute(sql, parameter);
    }

    private List<RoadFlow.Data.Model.UsersRelation> DataReaderToList(OracleDataReader dataReader)
    {
      List<RoadFlow.Data.Model.UsersRelation> usersRelationList = new List<RoadFlow.Data.Model.UsersRelation>();
      while (dataReader.Read())
        usersRelationList.Add(new RoadFlow.Data.Model.UsersRelation()
        {
          UserID = dataReader.GetString(0).ToGuid(),
          OrganizeID = dataReader.GetString(1).ToGuid(),
          IsMain = dataReader.GetInt32(2),
          Sort = dataReader.GetInt32(3)
        });
      return usersRelationList;
    }

    public List<RoadFlow.Data.Model.UsersRelation> GetAll()
    {
      OracleDataReader dataReader = this.dbHelper.GetDataReader("SELECT * FROM UsersRelation");
      List<RoadFlow.Data.Model.UsersRelation> list = this.DataReaderToList(dataReader);
      dataReader.Close();
      return list;
    }

    public long GetCount()
    {
      long result;
      if (!long.TryParse(this.dbHelper.GetFieldValue("SELECT COUNT(*) FROM UsersRelation"), out result))
        return 0;
      return result;
    }

    public RoadFlow.Data.Model.UsersRelation Get(Guid userid, Guid organizeid)
    {
      string sql = "SELECT * FROM UsersRelation WHERE UserID=:UserID AND OrganizeID=:OrganizeID";
      OracleParameter[] oracleParameterArray = new OracleParameter[2];
      int index1 = 0;
      OracleParameter oracleParameter1 = new OracleParameter(":UserID", OracleDbType.Varchar2);
      oracleParameter1.Value = (object) userid;
      oracleParameterArray[index1] = oracleParameter1;
      int index2 = 1;
      OracleParameter oracleParameter2 = new OracleParameter(":OrganizeID", OracleDbType.Varchar2);
      oracleParameter2.Value = (object) organizeid;
      oracleParameterArray[index2] = oracleParameter2;
      OracleParameter[] parameter = oracleParameterArray;
      OracleDataReader dataReader = this.dbHelper.GetDataReader(sql, parameter);
      List<RoadFlow.Data.Model.UsersRelation> list = this.DataReaderToList(dataReader);
      dataReader.Close();
      if (list.Count <= 0)
        return (RoadFlow.Data.Model.UsersRelation) null;
      return list[0];
    }

    public List<RoadFlow.Data.Model.UsersRelation> GetAllByOrganizeID(Guid organizeID)
    {
      string sql = "SELECT * FROM UsersRelation WHERE OrganizeID=:OrganizeID";
      OracleParameter[] oracleParameterArray = new OracleParameter[1];
      int index = 0;
      OracleParameter oracleParameter = new OracleParameter(":OrganizeID", OracleDbType.Varchar2);
      oracleParameter.Value = (object) organizeID;
      oracleParameterArray[index] = oracleParameter;
      OracleParameter[] parameter = oracleParameterArray;
      OracleDataReader dataReader = this.dbHelper.GetDataReader(sql, parameter);
      List<RoadFlow.Data.Model.UsersRelation> list = this.DataReaderToList(dataReader);
      dataReader.Close();
      return list;
    }

    public List<RoadFlow.Data.Model.UsersRelation> GetAllByUserID(Guid userID)
    {
      string sql = "SELECT * FROM UsersRelation WHERE UserID=:UserID";
      OracleParameter[] oracleParameterArray = new OracleParameter[1];
      int index = 0;
      OracleParameter oracleParameter = new OracleParameter(":UserID", OracleDbType.Varchar2);
      oracleParameter.Value = (object) userID;
      oracleParameterArray[index] = oracleParameter;
      OracleParameter[] parameter = oracleParameterArray;
      OracleDataReader dataReader = this.dbHelper.GetDataReader(sql, parameter);
      List<RoadFlow.Data.Model.UsersRelation> list = this.DataReaderToList(dataReader);
      dataReader.Close();
      return list;
    }

    public RoadFlow.Data.Model.UsersRelation GetMainByUserID(Guid userID)
    {
      string sql = "SELECT * FROM UsersRelation WHERE UserID=:UserID AND IsMain=1";
      OracleParameter[] oracleParameterArray = new OracleParameter[1];
      int index = 0;
      OracleParameter oracleParameter = new OracleParameter(":UserID", OracleDbType.Varchar2);
      oracleParameter.Value = (object) userID;
      oracleParameterArray[index] = oracleParameter;
      OracleParameter[] parameter = oracleParameterArray;
      OracleDataReader dataReader = this.dbHelper.GetDataReader(sql, parameter);
      List<RoadFlow.Data.Model.UsersRelation> list = this.DataReaderToList(dataReader);
      dataReader.Close();
      if (list.Count <= 0)
        return (RoadFlow.Data.Model.UsersRelation) null;
      return list[0];
    }

    public int DeleteByUserID(Guid userID)
    {
      string sql = "DELETE FROM UsersRelation WHERE UserID=:UserID";
      OracleParameter[] oracleParameterArray = new OracleParameter[1];
      int index = 0;
      OracleParameter oracleParameter = new OracleParameter(":UserID", OracleDbType.Varchar2);
      oracleParameter.Value = (object) userID;
      oracleParameterArray[index] = oracleParameter;
      OracleParameter[] parameter = oracleParameterArray;
      return this.dbHelper.Execute(sql, parameter);
    }

    public int DeleteNotIsMainByUserID(Guid userID)
    {
      string sql = "DELETE FROM UsersRelation WHERE IsMain=0 AND UserID=:UserID";
      OracleParameter[] oracleParameterArray = new OracleParameter[1];
      int index = 0;
      OracleParameter oracleParameter = new OracleParameter(":UserID", OracleDbType.Varchar2);
      oracleParameter.Value = (object) userID;
      oracleParameterArray[index] = oracleParameter;
      OracleParameter[] parameter = oracleParameterArray;
      return this.dbHelper.Execute(sql, parameter);
    }

    public int DeleteByOrganizeID(Guid organizeID)
    {
      string sql = "DELETE FROM UsersRelation WHERE OrganizeID=:OrganizeID";
      OracleParameter[] oracleParameterArray = new OracleParameter[1];
      int index = 0;
      OracleParameter oracleParameter = new OracleParameter(":OrganizeID", OracleDbType.Varchar2);
      oracleParameter.Value = (object) organizeID;
      oracleParameterArray[index] = oracleParameter;
      OracleParameter[] parameter = oracleParameterArray;
      return this.dbHelper.Execute(sql, parameter);
    }

    public int GetMaxSort(Guid organizeID)
    {
      string sql = "SELECT nvl(MAX(Sort),0)+1 FROM UsersRelation WHERE OrganizeID=:OrganizeID";
      OracleParameter[] oracleParameterArray = new OracleParameter[1];
      int index = 0;
      OracleParameter oracleParameter = new OracleParameter(":OrganizeID", OracleDbType.Varchar2);
      oracleParameter.Value = (object) organizeID;
      oracleParameterArray[index] = oracleParameter;
      OracleParameter[] parameter = oracleParameterArray;
      return new DBHelper().GetFieldValue(sql, parameter).ToInt();
    }
  }
}
