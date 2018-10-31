// Decompiled with JetBrains decompiler
// Type: RoadFlow.Data.MySql.UsersRelation
// Assembly: RoadFlow.Data.MySql, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 29B652D7-5F6F-4A7D-AD1C-9F2C643FD784
// Assembly location: C:\inetpub\wwwroot\RoadFlowMvc\bin\RoadFlow.Data.MySql.dll

using MySql.Data.MySqlClient;
using RoadFlow.Data.Interface;
using System;
using System.Collections.Generic;

namespace RoadFlow.Data.MySql
{
  public class UsersRelation : IUsersRelation
  {
    private DBHelper dbHelper = new DBHelper();

    public int Add(RoadFlow.Data.Model.UsersRelation model)
    {
      string sql = "INSERT INTO usersrelation\r\n\t\t\t\t(UserID,OrganizeID,IsMain,Sort) \r\n\t\t\t\tVALUES(@UserID,@OrganizeID,@IsMain,@Sort)";
      MySqlParameter[] mySqlParameterArray = new MySqlParameter[4];
      int index1 = 0;
      MySqlParameter mySqlParameter1 = new MySqlParameter("@UserID", MySqlDbType.VarChar, 36);
      mySqlParameter1.Value = (object) model.UserID;
      mySqlParameterArray[index1] = mySqlParameter1;
      int index2 = 1;
      MySqlParameter mySqlParameter2 = new MySqlParameter("@OrganizeID", MySqlDbType.VarChar, 36);
      mySqlParameter2.Value = (object) model.OrganizeID;
      mySqlParameterArray[index2] = mySqlParameter2;
      int index3 = 2;
      MySqlParameter mySqlParameter3 = new MySqlParameter("@IsMain", MySqlDbType.Int32, 11);
      mySqlParameter3.Value = (object) model.IsMain;
      mySqlParameterArray[index3] = mySqlParameter3;
      int index4 = 3;
      MySqlParameter mySqlParameter4 = new MySqlParameter("@Sort", MySqlDbType.Int32, 11);
      mySqlParameter4.Value = (object) model.Sort;
      mySqlParameterArray[index4] = mySqlParameter4;
      MySqlParameter[] parameter = mySqlParameterArray;
      return this.dbHelper.Execute(sql, parameter, false);
    }

    public int Update(RoadFlow.Data.Model.UsersRelation model)
    {
      string sql = "UPDATE usersrelation SET \r\n\t\t\t\tIsMain=@IsMain,Sort=@Sort\r\n\t\t\t\tWHERE UserID=@UserID and OrganizeID=@OrganizeID";
      MySqlParameter[] mySqlParameterArray = new MySqlParameter[4];
      int index1 = 0;
      MySqlParameter mySqlParameter1 = new MySqlParameter("@IsMain", MySqlDbType.Int32, 11);
      mySqlParameter1.Value = (object) model.IsMain;
      mySqlParameterArray[index1] = mySqlParameter1;
      int index2 = 1;
      MySqlParameter mySqlParameter2 = new MySqlParameter("@Sort", MySqlDbType.Int32, 11);
      mySqlParameter2.Value = (object) model.Sort;
      mySqlParameterArray[index2] = mySqlParameter2;
      int index3 = 2;
      MySqlParameter mySqlParameter3 = new MySqlParameter("@UserID", MySqlDbType.VarChar, 36);
      mySqlParameter3.Value = (object) model.UserID;
      mySqlParameterArray[index3] = mySqlParameter3;
      int index4 = 3;
      MySqlParameter mySqlParameter4 = new MySqlParameter("@OrganizeID", MySqlDbType.VarChar, 36);
      mySqlParameter4.Value = (object) model.OrganizeID;
      mySqlParameterArray[index4] = mySqlParameter4;
      MySqlParameter[] parameter = mySqlParameterArray;
      return this.dbHelper.Execute(sql, parameter, false);
    }

    public int Delete(Guid userid, Guid organizeid)
    {
      string sql = "DELETE FROM usersrelation WHERE UserID=@UserID AND OrganizeID=@OrganizeID";
      MySqlParameter[] mySqlParameterArray = new MySqlParameter[2];
      int index1 = 0;
      MySqlParameter mySqlParameter1 = new MySqlParameter("@UserID", MySqlDbType.VarChar, 36);
      mySqlParameter1.Value = (object) userid.ToString();
      mySqlParameterArray[index1] = mySqlParameter1;
      int index2 = 1;
      MySqlParameter mySqlParameter2 = new MySqlParameter("@OrganizeID", MySqlDbType.VarChar, 36);
      mySqlParameter2.Value = (object) organizeid.ToString();
      mySqlParameterArray[index2] = mySqlParameter2;
      MySqlParameter[] parameter = mySqlParameterArray;
      return this.dbHelper.Execute(sql, parameter, false);
    }

    private List<RoadFlow.Data.Model.UsersRelation> DataReaderToList(MySqlDataReader dataReader)
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
      MySqlDataReader dataReader = this.dbHelper.GetDataReader("SELECT * FROM usersrelation");
      List<RoadFlow.Data.Model.UsersRelation> list = this.DataReaderToList(dataReader);
      dataReader.Close();
      return list;
    }

    public long GetCount()
    {
      long result;
      if (!long.TryParse(this.dbHelper.GetFieldValue("SELECT COUNT(*) FROM usersrelation"), out result))
        return 0;
      return result;
    }

    public RoadFlow.Data.Model.UsersRelation Get(Guid userid, Guid organizeid)
    {
      string sql = "SELECT * FROM usersrelation WHERE UserID=@UserID AND OrganizeID=@OrganizeID";
      MySqlParameter[] mySqlParameterArray = new MySqlParameter[2];
      int index1 = 0;
      MySqlParameter mySqlParameter1 = new MySqlParameter("@UserID", MySqlDbType.VarChar, 36);
      mySqlParameter1.Value = (object) userid.ToString();
      mySqlParameterArray[index1] = mySqlParameter1;
      int index2 = 1;
      MySqlParameter mySqlParameter2 = new MySqlParameter("@OrganizeID", MySqlDbType.VarChar, 36);
      mySqlParameter2.Value = (object) organizeid.ToString();
      mySqlParameterArray[index2] = mySqlParameter2;
      MySqlParameter[] parameter = mySqlParameterArray;
      MySqlDataReader dataReader = this.dbHelper.GetDataReader(sql, parameter);
      List<RoadFlow.Data.Model.UsersRelation> list = this.DataReaderToList(dataReader);
      dataReader.Close();
      if (list.Count <= 0)
        return (RoadFlow.Data.Model.UsersRelation) null;
      return list[0];
    }

    public List<RoadFlow.Data.Model.UsersRelation> GetAllByOrganizeID(Guid organizeID)
    {
      string sql = "SELECT * FROM UsersRelation WHERE OrganizeID=@OrganizeID";
      MySqlParameter[] mySqlParameterArray = new MySqlParameter[1];
      int index = 0;
      MySqlParameter mySqlParameter = new MySqlParameter("@OrganizeID", MySqlDbType.VarChar);
      mySqlParameter.Value = (object) organizeID.ToString();
      mySqlParameterArray[index] = mySqlParameter;
      MySqlParameter[] parameter = mySqlParameterArray;
      MySqlDataReader dataReader = this.dbHelper.GetDataReader(sql, parameter);
      List<RoadFlow.Data.Model.UsersRelation> list = this.DataReaderToList(dataReader);
      dataReader.Close();
      return list;
    }

    public List<RoadFlow.Data.Model.UsersRelation> GetAllByUserID(Guid userID)
    {
      string sql = "SELECT * FROM UsersRelation WHERE UserID=@UserID";
      MySqlParameter[] mySqlParameterArray = new MySqlParameter[1];
      int index = 0;
      MySqlParameter mySqlParameter = new MySqlParameter("@UserID", MySqlDbType.VarChar);
      mySqlParameter.Value = (object) userID.ToString();
      mySqlParameterArray[index] = mySqlParameter;
      MySqlParameter[] parameter = mySqlParameterArray;
      MySqlDataReader dataReader = this.dbHelper.GetDataReader(sql, parameter);
      List<RoadFlow.Data.Model.UsersRelation> list = this.DataReaderToList(dataReader);
      dataReader.Close();
      return list;
    }

    public RoadFlow.Data.Model.UsersRelation GetMainByUserID(Guid userID)
    {
      string sql = "SELECT * FROM UsersRelation WHERE UserID=@UserID AND IsMain=1";
      MySqlParameter[] mySqlParameterArray = new MySqlParameter[1];
      int index = 0;
      MySqlParameter mySqlParameter = new MySqlParameter("@UserID", MySqlDbType.VarChar);
      mySqlParameter.Value = (object) userID.ToString();
      mySqlParameterArray[index] = mySqlParameter;
      MySqlParameter[] parameter = mySqlParameterArray;
      MySqlDataReader dataReader = this.dbHelper.GetDataReader(sql, parameter);
      List<RoadFlow.Data.Model.UsersRelation> list = this.DataReaderToList(dataReader);
      dataReader.Close();
      if (list.Count <= 0)
        return (RoadFlow.Data.Model.UsersRelation) null;
      return list[0];
    }

    public int DeleteByUserID(Guid userID)
    {
      string sql = "DELETE FROM UsersRelation WHERE UserID=@UserID";
      MySqlParameter[] mySqlParameterArray = new MySqlParameter[1];
      int index = 0;
      MySqlParameter mySqlParameter = new MySqlParameter("@UserID", MySqlDbType.VarChar);
      mySqlParameter.Value = (object) userID.ToString();
      mySqlParameterArray[index] = mySqlParameter;
      MySqlParameter[] parameter = mySqlParameterArray;
      return this.dbHelper.Execute(sql, parameter, false);
    }

    public int DeleteNotIsMainByUserID(Guid userID)
    {
      string sql = "DELETE FROM UsersRelation WHERE IsMain=0 AND UserID=@UserID";
      MySqlParameter[] mySqlParameterArray = new MySqlParameter[1];
      int index = 0;
      MySqlParameter mySqlParameter = new MySqlParameter("@UserID", MySqlDbType.VarChar);
      mySqlParameter.Value = (object) userID.ToString();
      mySqlParameterArray[index] = mySqlParameter;
      MySqlParameter[] parameter = mySqlParameterArray;
      return this.dbHelper.Execute(sql, parameter, false);
    }

    public int DeleteByOrganizeID(Guid organizeID)
    {
      string sql = "DELETE FROM UsersRelation WHERE OrganizeID=@OrganizeID";
      MySqlParameter[] mySqlParameterArray = new MySqlParameter[1];
      int index = 0;
      MySqlParameter mySqlParameter = new MySqlParameter("@OrganizeID", MySqlDbType.VarChar);
      mySqlParameter.Value = (object) organizeID.ToString();
      mySqlParameterArray[index] = mySqlParameter;
      MySqlParameter[] parameter = mySqlParameterArray;
      return this.dbHelper.Execute(sql, parameter, false);
    }

    public int GetMaxSort(Guid organizeID)
    {
      string sql = "SELECT IFNULL(MAX(Sort),0)+1 FROM UsersRelation WHERE OrganizeID=@OrganizeID";
      MySqlParameter[] mySqlParameterArray = new MySqlParameter[1];
      int index = 0;
      MySqlParameter mySqlParameter = new MySqlParameter("@OrganizeID", MySqlDbType.VarChar);
      mySqlParameter.Value = (object) organizeID.ToString();
      mySqlParameterArray[index] = mySqlParameter;
      MySqlParameter[] parameter = mySqlParameterArray;
      return new DBHelper().GetFieldValue(sql, parameter).ToInt();
    }
  }
}
