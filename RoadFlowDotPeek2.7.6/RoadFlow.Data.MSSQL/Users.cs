// Decompiled with JetBrains decompiler
// Type: RoadFlow.Data.MSSQL.Users
// Assembly: RoadFlow.Data.MSSQL, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 5107CDC7-8F84-4EE0-AC6D-E80FE4695340
// Assembly location: C:\inetpub\wwwroot\RoadFlowMvc\bin\RoadFlow.Data.MSSQL.dll

using RoadFlow.Data.Interface;
using RoadFlow.Utility;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;

namespace RoadFlow.Data.MSSQL
{
  public class Users : IUsers
  {
    private DBHelper dbHelper = new DBHelper();

    public int Add(RoadFlow.Data.Model.Users model)
    {
      string sql = "INSERT INTO Users\r\n\t\t\t\t(ID,Name,Account,Password,Status,Sort,Note,Mobile,Tel,OtherTel,Fax,Email,QQ,HeadImg,WeiXin,Sex) \r\n\t\t\t\tVALUES(@ID,@Name,@Account,@Password,@Status,@Sort,@Note,@Mobile,@Tel,@OtherTel,@Fax,@Email,@QQ,@HeadImg,@WeiXin,@Sex)";
      SqlParameter[] sqlParameterArray = new SqlParameter[16];
      int index1 = 0;
      SqlParameter sqlParameter1 = new SqlParameter("@ID", SqlDbType.UniqueIdentifier, -1);
      sqlParameter1.Value = (object) model.ID;
      sqlParameterArray[index1] = sqlParameter1;
      int index2 = 1;
      SqlParameter sqlParameter2 = new SqlParameter("@Name", SqlDbType.NVarChar, 100);
      sqlParameter2.Value = (object) model.Name;
      sqlParameterArray[index2] = sqlParameter2;
      int index3 = 2;
      SqlParameter sqlParameter3 = new SqlParameter("@Account", SqlDbType.VarChar, (int) byte.MaxValue);
      sqlParameter3.Value = (object) model.Account;
      sqlParameterArray[index3] = sqlParameter3;
      int index4 = 3;
      SqlParameter sqlParameter4 = new SqlParameter("@Password", SqlDbType.VarChar, 500);
      sqlParameter4.Value = (object) model.Password;
      sqlParameterArray[index4] = sqlParameter4;
      int index5 = 4;
      SqlParameter sqlParameter5 = new SqlParameter("@Status", SqlDbType.Int, -1);
      sqlParameter5.Value = (object) model.Status;
      sqlParameterArray[index5] = sqlParameter5;
      int index6 = 5;
      SqlParameter sqlParameter6 = new SqlParameter("@Sort", SqlDbType.Int, -1);
      sqlParameter6.Value = (object) model.Sort;
      sqlParameterArray[index6] = sqlParameter6;
      int index7 = 6;
      SqlParameter sqlParameter7;
      if (model.Note != null)
      {
        SqlParameter sqlParameter8 = new SqlParameter("@Note", SqlDbType.NVarChar, -1);
        sqlParameter8.Value = (object) model.Note;
        sqlParameter7 = sqlParameter8;
      }
      else
      {
        sqlParameter7 = new SqlParameter("@Note", SqlDbType.NVarChar, -1);
        sqlParameter7.Value = (object) DBNull.Value;
      }
      sqlParameterArray[index7] = sqlParameter7;
      int index8 = 7;
      SqlParameter sqlParameter9;
      if (model.Mobile != null)
      {
        SqlParameter sqlParameter8 = new SqlParameter("@Mobile", SqlDbType.VarChar, 50);
        sqlParameter8.Value = (object) model.Mobile;
        sqlParameter9 = sqlParameter8;
      }
      else
      {
        sqlParameter9 = new SqlParameter("@Mobile", SqlDbType.VarChar, 50);
        sqlParameter9.Value = (object) DBNull.Value;
      }
      sqlParameterArray[index8] = sqlParameter9;
      int index9 = 8;
      SqlParameter sqlParameter10;
      if (model.Tel != null)
      {
        SqlParameter sqlParameter8 = new SqlParameter("@Tel", SqlDbType.VarChar, 500);
        sqlParameter8.Value = (object) model.Tel;
        sqlParameter10 = sqlParameter8;
      }
      else
      {
        sqlParameter10 = new SqlParameter("@Tel", SqlDbType.VarChar, 500);
        sqlParameter10.Value = (object) DBNull.Value;
      }
      sqlParameterArray[index9] = sqlParameter10;
      int index10 = 9;
      SqlParameter sqlParameter11;
      if (model.OtherTel != null)
      {
        SqlParameter sqlParameter8 = new SqlParameter("@OtherTel", SqlDbType.VarChar, 500);
        sqlParameter8.Value = (object) model.OtherTel;
        sqlParameter11 = sqlParameter8;
      }
      else
      {
        sqlParameter11 = new SqlParameter("@OtherTel", SqlDbType.VarChar, 500);
        sqlParameter11.Value = (object) DBNull.Value;
      }
      sqlParameterArray[index10] = sqlParameter11;
      int index11 = 10;
      SqlParameter sqlParameter12;
      if (model.Fax != null)
      {
        SqlParameter sqlParameter8 = new SqlParameter("@Fax", SqlDbType.VarChar, 50);
        sqlParameter8.Value = (object) model.Fax;
        sqlParameter12 = sqlParameter8;
      }
      else
      {
        sqlParameter12 = new SqlParameter("@Fax", SqlDbType.VarChar, 50);
        sqlParameter12.Value = (object) DBNull.Value;
      }
      sqlParameterArray[index11] = sqlParameter12;
      int index12 = 11;
      SqlParameter sqlParameter13;
      if (model.Email != null)
      {
        SqlParameter sqlParameter8 = new SqlParameter("@Email", SqlDbType.VarChar, 500);
        sqlParameter8.Value = (object) model.Email;
        sqlParameter13 = sqlParameter8;
      }
      else
      {
        sqlParameter13 = new SqlParameter("@Email", SqlDbType.VarChar, 500);
        sqlParameter13.Value = (object) DBNull.Value;
      }
      sqlParameterArray[index12] = sqlParameter13;
      int index13 = 12;
      SqlParameter sqlParameter14;
      if (model.QQ != null)
      {
        SqlParameter sqlParameter8 = new SqlParameter("@QQ", SqlDbType.VarChar, 50);
        sqlParameter8.Value = (object) model.QQ;
        sqlParameter14 = sqlParameter8;
      }
      else
      {
        sqlParameter14 = new SqlParameter("@QQ", SqlDbType.VarChar, 50);
        sqlParameter14.Value = (object) DBNull.Value;
      }
      sqlParameterArray[index13] = sqlParameter14;
      int index14 = 13;
      SqlParameter sqlParameter15;
      if (model.HeadImg != null)
      {
        SqlParameter sqlParameter8 = new SqlParameter("@HeadImg", SqlDbType.VarChar, 500);
        sqlParameter8.Value = (object) model.HeadImg;
        sqlParameter15 = sqlParameter8;
      }
      else
      {
        sqlParameter15 = new SqlParameter("@HeadImg", SqlDbType.VarChar, 500);
        sqlParameter15.Value = (object) DBNull.Value;
      }
      sqlParameterArray[index14] = sqlParameter15;
      int index15 = 14;
      SqlParameter sqlParameter16;
      if (model.WeiXin != null)
      {
        SqlParameter sqlParameter8 = new SqlParameter("@WeiXin", SqlDbType.VarChar, 50);
        sqlParameter8.Value = (object) model.WeiXin;
        sqlParameter16 = sqlParameter8;
      }
      else
      {
        sqlParameter16 = new SqlParameter("@WeiXin", SqlDbType.VarChar, 50);
        sqlParameter16.Value = (object) DBNull.Value;
      }
      sqlParameterArray[index15] = sqlParameter16;
      int index16 = 15;
      SqlParameter sqlParameter17;
      if (model.Sex.HasValue)
      {
        SqlParameter sqlParameter8 = new SqlParameter("@Sex", SqlDbType.Int, -1);
        sqlParameter8.Value = (object) model.Sex;
        sqlParameter17 = sqlParameter8;
      }
      else
      {
        sqlParameter17 = new SqlParameter("@Sex", SqlDbType.Int, -1);
        sqlParameter17.Value = (object) DBNull.Value;
      }
      sqlParameterArray[index16] = sqlParameter17;
      SqlParameter[] parameter = sqlParameterArray;
      return this.dbHelper.Execute(sql, parameter, false);
    }

    public int Update(RoadFlow.Data.Model.Users model)
    {
      string sql = "UPDATE Users SET \r\n\t\t\t\tName=@Name,Account=@Account,Password=@Password,Status=@Status,Sort=@Sort,Note=@Note,Mobile=@Mobile,Tel=@Tel,OtherTel=@OtherTel,Fax=@Fax,Email=@Email,QQ=@QQ,HeadImg=@HeadImg,WeiXin=@WeiXin,Sex=@Sex\r\n\t\t\t\tWHERE ID=@ID";
      SqlParameter[] sqlParameterArray = new SqlParameter[16];
      int index1 = 0;
      SqlParameter sqlParameter1 = new SqlParameter("@Name", SqlDbType.NVarChar, 100);
      sqlParameter1.Value = (object) model.Name;
      sqlParameterArray[index1] = sqlParameter1;
      int index2 = 1;
      SqlParameter sqlParameter2 = new SqlParameter("@Account", SqlDbType.VarChar, (int) byte.MaxValue);
      sqlParameter2.Value = (object) model.Account;
      sqlParameterArray[index2] = sqlParameter2;
      int index3 = 2;
      SqlParameter sqlParameter3 = new SqlParameter("@Password", SqlDbType.VarChar, 500);
      sqlParameter3.Value = (object) model.Password;
      sqlParameterArray[index3] = sqlParameter3;
      int index4 = 3;
      SqlParameter sqlParameter4 = new SqlParameter("@Status", SqlDbType.Int, -1);
      sqlParameter4.Value = (object) model.Status;
      sqlParameterArray[index4] = sqlParameter4;
      int index5 = 4;
      SqlParameter sqlParameter5 = new SqlParameter("@Sort", SqlDbType.Int, -1);
      sqlParameter5.Value = (object) model.Sort;
      sqlParameterArray[index5] = sqlParameter5;
      int index6 = 5;
      SqlParameter sqlParameter6;
      if (model.Note != null)
      {
        SqlParameter sqlParameter7 = new SqlParameter("@Note", SqlDbType.NVarChar, -1);
        sqlParameter7.Value = (object) model.Note;
        sqlParameter6 = sqlParameter7;
      }
      else
      {
        sqlParameter6 = new SqlParameter("@Note", SqlDbType.NVarChar, -1);
        sqlParameter6.Value = (object) DBNull.Value;
      }
      sqlParameterArray[index6] = sqlParameter6;
      int index7 = 6;
      SqlParameter sqlParameter8;
      if (model.Mobile != null)
      {
        SqlParameter sqlParameter7 = new SqlParameter("@Mobile", SqlDbType.VarChar, 50);
        sqlParameter7.Value = (object) model.Mobile;
        sqlParameter8 = sqlParameter7;
      }
      else
      {
        sqlParameter8 = new SqlParameter("@Mobile", SqlDbType.VarChar, 50);
        sqlParameter8.Value = (object) DBNull.Value;
      }
      sqlParameterArray[index7] = sqlParameter8;
      int index8 = 7;
      SqlParameter sqlParameter9;
      if (model.Tel != null)
      {
        SqlParameter sqlParameter7 = new SqlParameter("@Tel", SqlDbType.VarChar, 500);
        sqlParameter7.Value = (object) model.Tel;
        sqlParameter9 = sqlParameter7;
      }
      else
      {
        sqlParameter9 = new SqlParameter("@Tel", SqlDbType.VarChar, 500);
        sqlParameter9.Value = (object) DBNull.Value;
      }
      sqlParameterArray[index8] = sqlParameter9;
      int index9 = 8;
      SqlParameter sqlParameter10;
      if (model.OtherTel != null)
      {
        SqlParameter sqlParameter7 = new SqlParameter("@OtherTel", SqlDbType.VarChar, 500);
        sqlParameter7.Value = (object) model.OtherTel;
        sqlParameter10 = sqlParameter7;
      }
      else
      {
        sqlParameter10 = new SqlParameter("@OtherTel", SqlDbType.VarChar, 500);
        sqlParameter10.Value = (object) DBNull.Value;
      }
      sqlParameterArray[index9] = sqlParameter10;
      int index10 = 9;
      SqlParameter sqlParameter11;
      if (model.Fax != null)
      {
        SqlParameter sqlParameter7 = new SqlParameter("@Fax", SqlDbType.VarChar, 50);
        sqlParameter7.Value = (object) model.Fax;
        sqlParameter11 = sqlParameter7;
      }
      else
      {
        sqlParameter11 = new SqlParameter("@Fax", SqlDbType.VarChar, 50);
        sqlParameter11.Value = (object) DBNull.Value;
      }
      sqlParameterArray[index10] = sqlParameter11;
      int index11 = 10;
      SqlParameter sqlParameter12;
      if (model.Email != null)
      {
        SqlParameter sqlParameter7 = new SqlParameter("@Email", SqlDbType.VarChar, 500);
        sqlParameter7.Value = (object) model.Email;
        sqlParameter12 = sqlParameter7;
      }
      else
      {
        sqlParameter12 = new SqlParameter("@Email", SqlDbType.VarChar, 500);
        sqlParameter12.Value = (object) DBNull.Value;
      }
      sqlParameterArray[index11] = sqlParameter12;
      int index12 = 11;
      SqlParameter sqlParameter13;
      if (model.QQ != null)
      {
        SqlParameter sqlParameter7 = new SqlParameter("@QQ", SqlDbType.VarChar, 50);
        sqlParameter7.Value = (object) model.QQ;
        sqlParameter13 = sqlParameter7;
      }
      else
      {
        sqlParameter13 = new SqlParameter("@QQ", SqlDbType.VarChar, 50);
        sqlParameter13.Value = (object) DBNull.Value;
      }
      sqlParameterArray[index12] = sqlParameter13;
      int index13 = 12;
      SqlParameter sqlParameter14;
      if (model.HeadImg != null)
      {
        SqlParameter sqlParameter7 = new SqlParameter("@HeadImg", SqlDbType.VarChar, 500);
        sqlParameter7.Value = (object) model.HeadImg;
        sqlParameter14 = sqlParameter7;
      }
      else
      {
        sqlParameter14 = new SqlParameter("@HeadImg", SqlDbType.VarChar, 500);
        sqlParameter14.Value = (object) DBNull.Value;
      }
      sqlParameterArray[index13] = sqlParameter14;
      int index14 = 13;
      SqlParameter sqlParameter15;
      if (model.WeiXin != null)
      {
        SqlParameter sqlParameter7 = new SqlParameter("@WeiXin", SqlDbType.VarChar, 50);
        sqlParameter7.Value = (object) model.WeiXin;
        sqlParameter15 = sqlParameter7;
      }
      else
      {
        sqlParameter15 = new SqlParameter("@WeiXin", SqlDbType.VarChar, 50);
        sqlParameter15.Value = (object) DBNull.Value;
      }
      sqlParameterArray[index14] = sqlParameter15;
      int index15 = 14;
      SqlParameter sqlParameter16;
      if (model.Sex.HasValue)
      {
        SqlParameter sqlParameter7 = new SqlParameter("@Sex", SqlDbType.Int, -1);
        sqlParameter7.Value = (object) model.Sex;
        sqlParameter16 = sqlParameter7;
      }
      else
      {
        sqlParameter16 = new SqlParameter("@Sex", SqlDbType.Int, -1);
        sqlParameter16.Value = (object) DBNull.Value;
      }
      sqlParameterArray[index15] = sqlParameter16;
      int index16 = 15;
      SqlParameter sqlParameter17 = new SqlParameter("@ID", SqlDbType.UniqueIdentifier, -1);
      sqlParameter17.Value = (object) model.ID;
      sqlParameterArray[index16] = sqlParameter17;
      SqlParameter[] parameter = sqlParameterArray;
      return this.dbHelper.Execute(sql, parameter, false);
    }

    public int Delete(Guid id)
    {
      string sql = "DELETE FROM Users WHERE ID=@ID";
      SqlParameter[] sqlParameterArray = new SqlParameter[1];
      int index = 0;
      SqlParameter sqlParameter = new SqlParameter("@ID", SqlDbType.UniqueIdentifier);
      sqlParameter.Value = (object) id;
      sqlParameterArray[index] = sqlParameter;
      SqlParameter[] parameter = sqlParameterArray;
      return this.dbHelper.Execute(sql, parameter, false);
    }

    private List<RoadFlow.Data.Model.Users> DataReaderToList(SqlDataReader dataReader)
    {
      List<RoadFlow.Data.Model.Users> usersList = new List<RoadFlow.Data.Model.Users>();
      while (dataReader.Read())
      {
        RoadFlow.Data.Model.Users users = new RoadFlow.Data.Model.Users();
        users.ID = dataReader.GetGuid(0);
        users.Name = dataReader.GetString(1);
        users.Account = dataReader.GetString(2);
        users.Password = dataReader.GetString(3);
        users.Status = dataReader.GetInt32(4);
        users.Sort = dataReader.GetInt32(5);
        if (!dataReader.IsDBNull(6))
          users.Note = dataReader.GetString(6);
        if (!dataReader.IsDBNull(7))
          users.Mobile = dataReader.GetString(7);
        if (!dataReader.IsDBNull(8))
          users.Tel = dataReader.GetString(8);
        if (!dataReader.IsDBNull(9))
          users.OtherTel = dataReader.GetString(9);
        if (!dataReader.IsDBNull(10))
          users.Fax = dataReader.GetString(10);
        if (!dataReader.IsDBNull(11))
          users.Email = dataReader.GetString(11);
        if (!dataReader.IsDBNull(12))
          users.QQ = dataReader.GetString(12);
        if (!dataReader.IsDBNull(13))
          users.HeadImg = dataReader.GetString(13);
        if (!dataReader.IsDBNull(14))
          users.WeiXin = dataReader.GetString(14);
        if (!dataReader.IsDBNull(15))
          users.Sex = new int?(dataReader.GetInt32(15));
        usersList.Add(users);
      }
      return usersList;
    }

    public List<RoadFlow.Data.Model.Users> GetAll()
    {
      SqlDataReader dataReader = this.dbHelper.GetDataReader("SELECT * FROM Users");
      List<RoadFlow.Data.Model.Users> list = this.DataReaderToList(dataReader);
      dataReader.Close();
      return list;
    }

    public long GetCount()
    {
      long result;
      if (!long.TryParse(this.dbHelper.GetFieldValue("SELECT COUNT(*) FROM Users"), out result))
        return 0;
      return result;
    }

    public RoadFlow.Data.Model.Users Get(Guid id)
    {
      string sql = "SELECT * FROM Users WHERE ID=@ID";
      SqlParameter[] sqlParameterArray = new SqlParameter[1];
      int index = 0;
      SqlParameter sqlParameter = new SqlParameter("@ID", SqlDbType.UniqueIdentifier);
      sqlParameter.Value = (object) id;
      sqlParameterArray[index] = sqlParameter;
      SqlParameter[] parameter = sqlParameterArray;
      SqlDataReader dataReader = this.dbHelper.GetDataReader(sql, parameter);
      List<RoadFlow.Data.Model.Users> list = this.DataReaderToList(dataReader);
      dataReader.Close();
      if (list.Count <= 0)
        return (RoadFlow.Data.Model.Users) null;
      return list[0];
    }

    public RoadFlow.Data.Model.Users GetByAccount(string account)
    {
      string sql = "SELECT * FROM Users WHERE Account=@Account";
      SqlParameter[] sqlParameterArray = new SqlParameter[1];
      int index = 0;
      SqlParameter sqlParameter = new SqlParameter("@Account", SqlDbType.VarChar, (int) byte.MaxValue);
      sqlParameter.Value = (object) account;
      sqlParameterArray[index] = sqlParameter;
      SqlParameter[] parameter = sqlParameterArray;
      SqlDataReader dataReader = this.dbHelper.GetDataReader(sql, parameter);
      List<RoadFlow.Data.Model.Users> list = this.DataReaderToList(dataReader);
      dataReader.Close();
      if (list.Count <= 0)
        return (RoadFlow.Data.Model.Users) null;
      return list[0];
    }

    public List<RoadFlow.Data.Model.Users> GetAllByOrganizeID(Guid organizeID)
    {
      string sql = "SELECT * FROM Users WHERE ID in(SELECT UserID FROM UsersRelation WHERE OrganizeID=@OrganizeID) ORDER BY Sort";
      SqlParameter[] sqlParameterArray = new SqlParameter[1];
      int index = 0;
      SqlParameter sqlParameter = new SqlParameter("@OrganizeID", SqlDbType.UniqueIdentifier);
      sqlParameter.Value = (object) organizeID;
      sqlParameterArray[index] = sqlParameter;
      SqlParameter[] parameter = sqlParameterArray;
      SqlDataReader dataReader = this.dbHelper.GetDataReader(sql, parameter);
      List<RoadFlow.Data.Model.Users> list = this.DataReaderToList(dataReader);
      dataReader.Close();
      return list;
    }

    public List<RoadFlow.Data.Model.Users> GetAllByOrganizeIDArray(Guid[] organizeIDArray)
    {
      if (organizeIDArray == null || organizeIDArray.Length == 0)
        return new List<RoadFlow.Data.Model.Users>();
      SqlDataReader dataReader = this.dbHelper.GetDataReader("SELECT * FROM Users WHERE ID in(SELECT UserID FROM UsersRelation WHERE OrganizeID in(" + Tools.GetSqlInString<Guid>(organizeIDArray, true) + ")) ORDER BY Sort");
      List<RoadFlow.Data.Model.Users> list = this.DataReaderToList(dataReader);
      dataReader.Close();
      return list;
    }

    public bool HasAccount(string account, string userID = "")
    {
      string sql = "SELECT ID FROM Users WHERE Account=@Account";
      List<SqlParameter> sqlParameterList1 = new List<SqlParameter>();
      List<SqlParameter> sqlParameterList2 = sqlParameterList1;
      SqlParameter sqlParameter1 = new SqlParameter("@Account", SqlDbType.VarChar);
      sqlParameter1.Value = (object) account;
      sqlParameterList2.Add(sqlParameter1);
      if (userID.IsGuid())
      {
        sql += " and ID<>@ID";
        List<SqlParameter> sqlParameterList3 = sqlParameterList1;
        SqlParameter sqlParameter2 = new SqlParameter("@ID", SqlDbType.UniqueIdentifier);
        sqlParameter2.Value = (object) userID.ToGuid();
        sqlParameterList3.Add(sqlParameter2);
      }
      SqlDataReader dataReader = this.dbHelper.GetDataReader(sql, sqlParameterList1.ToArray());
      bool hasRows = dataReader.HasRows;
      dataReader.Close();
      return hasRows;
    }

    public bool UpdatePassword(string password, Guid userID)
    {
      string sql = "UPDATE Users SET Password=@Password WHERE ID=@ID";
      SqlParameter[] sqlParameterArray = new SqlParameter[2];
      int index1 = 0;
      SqlParameter sqlParameter1 = new SqlParameter("@Password", SqlDbType.VarChar);
      sqlParameter1.Value = (object) password;
      sqlParameterArray[index1] = sqlParameter1;
      int index2 = 1;
      SqlParameter sqlParameter2 = new SqlParameter("@ID", SqlDbType.UniqueIdentifier);
      sqlParameter2.Value = (object) userID;
      sqlParameterArray[index2] = sqlParameter2;
      SqlParameter[] parameter = sqlParameterArray;
      return this.dbHelper.Execute(sql, parameter, false) == 1;
    }

    public int UpdateSort(Guid userID, int sort)
    {
      string sql = "UPDATE Users SET Sort=@Sort WHERE ID=@ID";
      SqlParameter[] sqlParameterArray = new SqlParameter[2];
      int index1 = 0;
      SqlParameter sqlParameter1 = new SqlParameter("@Sort", SqlDbType.Int);
      sqlParameter1.Value = (object) sort;
      sqlParameterArray[index1] = sqlParameter1;
      int index2 = 1;
      SqlParameter sqlParameter2 = new SqlParameter("@ID", SqlDbType.UniqueIdentifier);
      sqlParameter2.Value = (object) userID;
      sqlParameterArray[index2] = sqlParameter2;
      SqlParameter[] parameter = sqlParameterArray;
      return this.dbHelper.Execute(sql, parameter, false);
    }

    public List<RoadFlow.Data.Model.Users> GetAllByIDString(string idString)
    {
      SqlDataReader dataReader = this.dbHelper.GetDataReader("SELECT * FROM Users WHERE ID IN(" + Tools.GetSqlInString(idString, true, ",") + ")");
      List<RoadFlow.Data.Model.Users> list = this.DataReaderToList(dataReader);
      dataReader.Close();
      return list;
    }

    public List<RoadFlow.Data.Model.Users> GetAllByWorkGroupID(Guid workgroupid)
    {
      SqlDataReader dataReader = this.dbHelper.GetDataReader("SELECT * FROM Users WHERE ID IN(SELECT UserID FROM WorkGroupUsers WHERE WorkGroupID='" + (object) workgroupid + "')");
      List<RoadFlow.Data.Model.Users> list = this.DataReaderToList(dataReader);
      dataReader.Close();
      return list;
    }
  }
}
