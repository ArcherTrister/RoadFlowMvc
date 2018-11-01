// Decompiled with JetBrains decompiler
// Type: RoadFlow.Data.MSSQL.UsersRelation
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
  public class UsersRelation : IUsersRelation
  {
    private DBHelper dbHelper = new DBHelper();

    public int Add(RoadFlow.Data.Model.UsersRelation model)
    {
      string sql = "INSERT INTO UsersRelation\r\n\t\t\t\t(UserID,OrganizeID,IsMain,Sort) \r\n\t\t\t\tVALUES(@UserID,@OrganizeID,@IsMain,@Sort)";
      SqlParameter[] sqlParameterArray = new SqlParameter[4];
      int index1 = 0;
      SqlParameter sqlParameter1 = new SqlParameter("@UserID", SqlDbType.UniqueIdentifier, -1);
      sqlParameter1.Value = (object) model.UserID;
      sqlParameterArray[index1] = sqlParameter1;
      int index2 = 1;
      SqlParameter sqlParameter2 = new SqlParameter("@OrganizeID", SqlDbType.UniqueIdentifier, -1);
      sqlParameter2.Value = (object) model.OrganizeID;
      sqlParameterArray[index2] = sqlParameter2;
      int index3 = 2;
      SqlParameter sqlParameter3 = new SqlParameter("@IsMain", SqlDbType.Int, -1);
      sqlParameter3.Value = (object) model.IsMain;
      sqlParameterArray[index3] = sqlParameter3;
      int index4 = 3;
      SqlParameter sqlParameter4 = new SqlParameter("@Sort", SqlDbType.Int, -1);
      sqlParameter4.Value = (object) model.Sort;
      sqlParameterArray[index4] = sqlParameter4;
      SqlParameter[] parameter = sqlParameterArray;
      return this.dbHelper.Execute(sql, parameter, false);
    }

    public int Update(RoadFlow.Data.Model.UsersRelation model)
    {
      string sql = "UPDATE UsersRelation SET \r\n\t\t\t\tIsMain=@IsMain,Sort=@Sort\r\n\t\t\t\tWHERE UserID=@UserID and OrganizeID=@OrganizeID";
      SqlParameter[] sqlParameterArray = new SqlParameter[4];
      int index1 = 0;
      SqlParameter sqlParameter1 = new SqlParameter("@IsMain", SqlDbType.Int, -1);
      sqlParameter1.Value = (object) model.IsMain;
      sqlParameterArray[index1] = sqlParameter1;
      int index2 = 1;
      SqlParameter sqlParameter2 = new SqlParameter("@Sort", SqlDbType.Int, -1);
      sqlParameter2.Value = (object) model.Sort;
      sqlParameterArray[index2] = sqlParameter2;
      int index3 = 2;
      SqlParameter sqlParameter3 = new SqlParameter("@UserID", SqlDbType.UniqueIdentifier, -1);
      sqlParameter3.Value = (object) model.UserID;
      sqlParameterArray[index3] = sqlParameter3;
      int index4 = 3;
      SqlParameter sqlParameter4 = new SqlParameter("@OrganizeID", SqlDbType.UniqueIdentifier, -1);
      sqlParameter4.Value = (object) model.OrganizeID;
      sqlParameterArray[index4] = sqlParameter4;
      SqlParameter[] parameter = sqlParameterArray;
      return this.dbHelper.Execute(sql, parameter, false);
    }

    public int Delete(Guid userid, Guid organizeid)
    {
      string sql = "DELETE FROM UsersRelation WHERE UserID=@UserID AND OrganizeID=@OrganizeID";
      SqlParameter[] sqlParameterArray = new SqlParameter[2];
      int index1 = 0;
      SqlParameter sqlParameter1 = new SqlParameter("@UserID", SqlDbType.UniqueIdentifier);
      sqlParameter1.Value = (object) userid;
      sqlParameterArray[index1] = sqlParameter1;
      int index2 = 1;
      SqlParameter sqlParameter2 = new SqlParameter("@OrganizeID", SqlDbType.UniqueIdentifier);
      sqlParameter2.Value = (object) organizeid;
      sqlParameterArray[index2] = sqlParameter2;
      SqlParameter[] parameter = sqlParameterArray;
      return this.dbHelper.Execute(sql, parameter, false);
    }

    private List<RoadFlow.Data.Model.UsersRelation> DataReaderToList(SqlDataReader dataReader)
    {
      List<RoadFlow.Data.Model.UsersRelation> usersRelationList = new List<RoadFlow.Data.Model.UsersRelation>();
      while (dataReader.Read())
        usersRelationList.Add(new RoadFlow.Data.Model.UsersRelation()
        {
          UserID = dataReader.GetGuid(0),
          OrganizeID = dataReader.GetGuid(1),
          IsMain = dataReader.GetInt32(2),
          Sort = dataReader.GetInt32(3)
        });
      return usersRelationList;
    }

    public List<RoadFlow.Data.Model.UsersRelation> GetAll()
    {
      SqlDataReader dataReader = this.dbHelper.GetDataReader("SELECT * FROM UsersRelation");
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
      string sql = "SELECT * FROM UsersRelation WHERE UserID=@UserID AND OrganizeID=@OrganizeID";
      SqlParameter[] sqlParameterArray = new SqlParameter[2];
      int index1 = 0;
      SqlParameter sqlParameter1 = new SqlParameter("@UserID", SqlDbType.UniqueIdentifier);
      sqlParameter1.Value = (object) userid;
      sqlParameterArray[index1] = sqlParameter1;
      int index2 = 1;
      SqlParameter sqlParameter2 = new SqlParameter("@OrganizeID", SqlDbType.UniqueIdentifier);
      sqlParameter2.Value = (object) organizeid;
      sqlParameterArray[index2] = sqlParameter2;
      SqlParameter[] parameter = sqlParameterArray;
      SqlDataReader dataReader = this.dbHelper.GetDataReader(sql, parameter);
      List<RoadFlow.Data.Model.UsersRelation> list = this.DataReaderToList(dataReader);
      dataReader.Close();
      if (list.Count <= 0)
        return (RoadFlow.Data.Model.UsersRelation) null;
      return list[0];
    }

    public List<RoadFlow.Data.Model.UsersRelation> GetAllByOrganizeID(Guid organizeID)
    {
      string sql = "SELECT * FROM UsersRelation WHERE OrganizeID=@OrganizeID";
      SqlParameter[] sqlParameterArray = new SqlParameter[1];
      int index = 0;
      SqlParameter sqlParameter = new SqlParameter("@OrganizeID", SqlDbType.UniqueIdentifier);
      sqlParameter.Value = (object) organizeID;
      sqlParameterArray[index] = sqlParameter;
      SqlParameter[] parameter = sqlParameterArray;
      SqlDataReader dataReader = this.dbHelper.GetDataReader(sql, parameter);
      List<RoadFlow.Data.Model.UsersRelation> list = this.DataReaderToList(dataReader);
      dataReader.Close();
      return list;
    }

    public List<RoadFlow.Data.Model.UsersRelation> GetAllByUserID(Guid userID)
    {
      string sql = "SELECT * FROM UsersRelation WHERE UserID=@UserID";
      SqlParameter[] sqlParameterArray = new SqlParameter[1];
      int index = 0;
      SqlParameter sqlParameter = new SqlParameter("@UserID", SqlDbType.UniqueIdentifier);
      sqlParameter.Value = (object) userID;
      sqlParameterArray[index] = sqlParameter;
      SqlParameter[] parameter = sqlParameterArray;
      SqlDataReader dataReader = this.dbHelper.GetDataReader(sql, parameter);
      List<RoadFlow.Data.Model.UsersRelation> list = this.DataReaderToList(dataReader);
      dataReader.Close();
      return list;
    }

    public RoadFlow.Data.Model.UsersRelation GetMainByUserID(Guid userID)
    {
      string sql = "SELECT * FROM UsersRelation WHERE UserID=@UserID AND IsMain=1";
      SqlParameter[] sqlParameterArray = new SqlParameter[1];
      int index = 0;
      SqlParameter sqlParameter = new SqlParameter("@UserID", SqlDbType.UniqueIdentifier);
      sqlParameter.Value = (object) userID;
      sqlParameterArray[index] = sqlParameter;
      SqlParameter[] parameter = sqlParameterArray;
      SqlDataReader dataReader = this.dbHelper.GetDataReader(sql, parameter);
      List<RoadFlow.Data.Model.UsersRelation> list = this.DataReaderToList(dataReader);
      dataReader.Close();
      if (list.Count <= 0)
        return (RoadFlow.Data.Model.UsersRelation) null;
      return list[0];
    }

    public int DeleteByUserID(Guid userID)
    {
      string sql = "DELETE FROM UsersRelation WHERE UserID=@UserID";
      SqlParameter[] sqlParameterArray = new SqlParameter[1];
      int index = 0;
      SqlParameter sqlParameter = new SqlParameter("@UserID", SqlDbType.UniqueIdentifier);
      sqlParameter.Value = (object) userID;
      sqlParameterArray[index] = sqlParameter;
      SqlParameter[] parameter = sqlParameterArray;
      return this.dbHelper.Execute(sql, parameter, false);
    }

    public int DeleteNotIsMainByUserID(Guid userID)
    {
      string sql = "DELETE FROM UsersRelation WHERE IsMain=0 AND UserID=@UserID";
      SqlParameter[] sqlParameterArray = new SqlParameter[1];
      int index = 0;
      SqlParameter sqlParameter = new SqlParameter("@UserID", SqlDbType.UniqueIdentifier);
      sqlParameter.Value = (object) userID;
      sqlParameterArray[index] = sqlParameter;
      SqlParameter[] parameter = sqlParameterArray;
      return this.dbHelper.Execute(sql, parameter, false);
    }

    public int DeleteByOrganizeID(Guid organizeID)
    {
      string sql = "DELETE FROM UsersRelation WHERE OrganizeID=@OrganizeID";
      SqlParameter[] sqlParameterArray = new SqlParameter[1];
      int index = 0;
      SqlParameter sqlParameter = new SqlParameter("@OrganizeID", SqlDbType.UniqueIdentifier);
      sqlParameter.Value = (object) organizeID;
      sqlParameterArray[index] = sqlParameter;
      SqlParameter[] parameter = sqlParameterArray;
      return this.dbHelper.Execute(sql, parameter, false);
    }

    public int GetMaxSort(Guid organizeID)
    {
      string sql = "SELECT ISNULL(MAX(Sort),0)+1 FROM UsersRelation WHERE OrganizeID=@OrganizeID";
      SqlParameter[] sqlParameterArray = new SqlParameter[1];
      int index = 0;
      SqlParameter sqlParameter = new SqlParameter("@OrganizeID", SqlDbType.UniqueIdentifier);
      sqlParameter.Value = (object) organizeID;
      sqlParameterArray[index] = sqlParameter;
      SqlParameter[] parameter = sqlParameterArray;
      return new DBHelper().GetFieldValue(sql, parameter).ToInt();
    }
  }
}
