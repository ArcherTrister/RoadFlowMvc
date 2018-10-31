// Decompiled with JetBrains decompiler
// Type: RoadFlow.Data.MySql.Users
// Assembly: RoadFlow.Data.MySql, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 29B652D7-5F6F-4A7D-AD1C-9F2C643FD784
// Assembly location: C:\inetpub\wwwroot\RoadFlowMvc\bin\RoadFlow.Data.MySql.dll

using MySql.Data.MySqlClient;
using RoadFlow.Data.Interface;
using RoadFlow.Utility;
using System;
using System.Collections.Generic;

namespace RoadFlow.Data.MySql
{
  public class Users : IUsers
  {
    private DBHelper dbHelper = new DBHelper();

    public int Add(RoadFlow.Data.Model.Users model)
    {
      string sql = "INSERT INTO users\r\n\t\t\t\t(ID,Name,Account,Password,Status,Sort,Note,Mobile,Tel,OtherTel,Fax,Email,QQ,HeadImg,WeiXin,Sex) \r\n\t\t\t\tVALUES(@ID,@Name,@Account,@Password,@Status,@Sort,@Note,@Mobile,@Tel,@OtherTel,@Fax,@Email,@QQ,@HeadImg,@WeiXin,@Sex)";
      MySqlParameter[] mySqlParameterArray = new MySqlParameter[16];
      int index1 = 0;
      MySqlParameter mySqlParameter1 = new MySqlParameter("@ID", MySqlDbType.VarChar, 36);
      mySqlParameter1.Value = (object) model.ID;
      mySqlParameterArray[index1] = mySqlParameter1;
      int index2 = 1;
      MySqlParameter mySqlParameter2 = new MySqlParameter("@Name", MySqlDbType.VarChar, 50);
      mySqlParameter2.Value = (object) model.Name;
      mySqlParameterArray[index2] = mySqlParameter2;
      int index3 = 2;
      MySqlParameter mySqlParameter3 = new MySqlParameter("@Account", MySqlDbType.VarChar, (int) byte.MaxValue);
      mySqlParameter3.Value = (object) model.Account;
      mySqlParameterArray[index3] = mySqlParameter3;
      int index4 = 3;
      MySqlParameter mySqlParameter4 = new MySqlParameter("@Password", MySqlDbType.Text, -1);
      mySqlParameter4.Value = (object) model.Password;
      mySqlParameterArray[index4] = mySqlParameter4;
      int index5 = 4;
      MySqlParameter mySqlParameter5 = new MySqlParameter("@Status", MySqlDbType.Int32, 11);
      mySqlParameter5.Value = (object) model.Status;
      mySqlParameterArray[index5] = mySqlParameter5;
      int index6 = 5;
      MySqlParameter mySqlParameter6 = new MySqlParameter("@Sort", MySqlDbType.Int32, 11);
      mySqlParameter6.Value = (object) model.Sort;
      mySqlParameterArray[index6] = mySqlParameter6;
      int index7 = 6;
      MySqlParameter mySqlParameter7;
      if (model.Note != null)
      {
        MySqlParameter mySqlParameter8 = new MySqlParameter("@Note", MySqlDbType.LongText, -1);
        mySqlParameter8.Value = (object) model.Note;
        mySqlParameter7 = mySqlParameter8;
      }
      else
      {
        mySqlParameter7 = new MySqlParameter("@Note", MySqlDbType.LongText, -1);
        mySqlParameter7.Value = (object) DBNull.Value;
      }
      mySqlParameterArray[index7] = mySqlParameter7;
      int index8 = 7;
      MySqlParameter mySqlParameter9;
      if (model.Mobile != null)
      {
        MySqlParameter mySqlParameter8 = new MySqlParameter("@Mobile", MySqlDbType.VarChar, 50);
        mySqlParameter8.Value = (object) model.Mobile;
        mySqlParameter9 = mySqlParameter8;
      }
      else
      {
        mySqlParameter9 = new MySqlParameter("@Mobile", MySqlDbType.VarChar, 50);
        mySqlParameter9.Value = (object) DBNull.Value;
      }
      mySqlParameterArray[index8] = mySqlParameter9;
      int index9 = 8;
      MySqlParameter mySqlParameter10;
      if (model.Tel != null)
      {
        MySqlParameter mySqlParameter8 = new MySqlParameter("@Tel", MySqlDbType.VarChar, 500);
        mySqlParameter8.Value = (object) model.Tel;
        mySqlParameter10 = mySqlParameter8;
      }
      else
      {
        mySqlParameter10 = new MySqlParameter("@Tel", MySqlDbType.VarChar, 500);
        mySqlParameter10.Value = (object) DBNull.Value;
      }
      mySqlParameterArray[index9] = mySqlParameter10;
      int index10 = 9;
      MySqlParameter mySqlParameter11;
      if (model.OtherTel != null)
      {
        MySqlParameter mySqlParameter8 = new MySqlParameter("@OtherTel", MySqlDbType.VarChar, 500);
        mySqlParameter8.Value = (object) model.OtherTel;
        mySqlParameter11 = mySqlParameter8;
      }
      else
      {
        mySqlParameter11 = new MySqlParameter("@OtherTel", MySqlDbType.VarChar, 500);
        mySqlParameter11.Value = (object) DBNull.Value;
      }
      mySqlParameterArray[index10] = mySqlParameter11;
      int index11 = 10;
      MySqlParameter mySqlParameter12;
      if (model.Fax != null)
      {
        MySqlParameter mySqlParameter8 = new MySqlParameter("@Fax", MySqlDbType.VarChar, 50);
        mySqlParameter8.Value = (object) model.Fax;
        mySqlParameter12 = mySqlParameter8;
      }
      else
      {
        mySqlParameter12 = new MySqlParameter("@Fax", MySqlDbType.VarChar, 50);
        mySqlParameter12.Value = (object) DBNull.Value;
      }
      mySqlParameterArray[index11] = mySqlParameter12;
      int index12 = 11;
      MySqlParameter mySqlParameter13;
      if (model.Email != null)
      {
        MySqlParameter mySqlParameter8 = new MySqlParameter("@Email", MySqlDbType.VarChar, 500);
        mySqlParameter8.Value = (object) model.Email;
        mySqlParameter13 = mySqlParameter8;
      }
      else
      {
        mySqlParameter13 = new MySqlParameter("@Email", MySqlDbType.VarChar, 500);
        mySqlParameter13.Value = (object) DBNull.Value;
      }
      mySqlParameterArray[index12] = mySqlParameter13;
      int index13 = 12;
      MySqlParameter mySqlParameter14;
      if (model.QQ != null)
      {
        MySqlParameter mySqlParameter8 = new MySqlParameter("@QQ", MySqlDbType.VarChar, 50);
        mySqlParameter8.Value = (object) model.QQ;
        mySqlParameter14 = mySqlParameter8;
      }
      else
      {
        mySqlParameter14 = new MySqlParameter("@QQ", MySqlDbType.VarChar, 50);
        mySqlParameter14.Value = (object) DBNull.Value;
      }
      mySqlParameterArray[index13] = mySqlParameter14;
      int index14 = 13;
      MySqlParameter mySqlParameter15;
      if (model.HeadImg != null)
      {
        MySqlParameter mySqlParameter8 = new MySqlParameter("@HeadImg", MySqlDbType.VarChar, 500);
        mySqlParameter8.Value = (object) model.HeadImg;
        mySqlParameter15 = mySqlParameter8;
      }
      else
      {
        mySqlParameter15 = new MySqlParameter("@HeadImg", MySqlDbType.VarChar, 500);
        mySqlParameter15.Value = (object) DBNull.Value;
      }
      mySqlParameterArray[index14] = mySqlParameter15;
      int index15 = 14;
      MySqlParameter mySqlParameter16;
      if (model.WeiXin != null)
      {
        MySqlParameter mySqlParameter8 = new MySqlParameter("@WeiXin", MySqlDbType.VarChar, 50);
        mySqlParameter8.Value = (object) model.WeiXin;
        mySqlParameter16 = mySqlParameter8;
      }
      else
      {
        mySqlParameter16 = new MySqlParameter("@WeiXin", MySqlDbType.VarChar, 50);
        mySqlParameter16.Value = (object) DBNull.Value;
      }
      mySqlParameterArray[index15] = mySqlParameter16;
      int index16 = 15;
      int? sex = model.Sex;
      MySqlParameter mySqlParameter17;
      if (sex.HasValue)
      {
        MySqlParameter mySqlParameter8 = new MySqlParameter("@Sex", MySqlDbType.Int32, 11);
        sex = model.Sex;
        mySqlParameter8.Value = (object) sex.Value;
        mySqlParameter17 = mySqlParameter8;
      }
      else
      {
        mySqlParameter17 = new MySqlParameter("@Sex", MySqlDbType.Int32, 11);
        mySqlParameter17.Value = (object) DBNull.Value;
      }
      mySqlParameterArray[index16] = mySqlParameter17;
      MySqlParameter[] parameter = mySqlParameterArray;
      return this.dbHelper.Execute(sql, parameter, false);
    }

    public int Update(RoadFlow.Data.Model.Users model)
    {
      string sql = "UPDATE Users SET \r\n\t\t\t\tName=@Name,Account=@Account,Password=@Password,Status=@Status,Sort=@Sort,Note=@Note,Mobile=@Mobile,Tel=@Tel,OtherTel=@OtherTel,Fax=@Fax,Email=@Email,QQ=@QQ,HeadImg=@HeadImg,WeiXin=@WeiXin,Sex=@Sex\r\n\t\t\t\tWHERE ID=@ID";
      MySqlParameter[] mySqlParameterArray = new MySqlParameter[16];
      int index1 = 0;
      MySqlParameter mySqlParameter1 = new MySqlParameter("@Name", MySqlDbType.VarChar, 50);
      mySqlParameter1.Value = (object) model.Name;
      mySqlParameterArray[index1] = mySqlParameter1;
      int index2 = 1;
      MySqlParameter mySqlParameter2 = new MySqlParameter("@Account", MySqlDbType.VarChar, (int) byte.MaxValue);
      mySqlParameter2.Value = (object) model.Account;
      mySqlParameterArray[index2] = mySqlParameter2;
      int index3 = 2;
      MySqlParameter mySqlParameter3 = new MySqlParameter("@Password", MySqlDbType.Text, -1);
      mySqlParameter3.Value = (object) model.Password;
      mySqlParameterArray[index3] = mySqlParameter3;
      int index4 = 3;
      MySqlParameter mySqlParameter4 = new MySqlParameter("@Status", MySqlDbType.Int32, 11);
      mySqlParameter4.Value = (object) model.Status;
      mySqlParameterArray[index4] = mySqlParameter4;
      int index5 = 4;
      MySqlParameter mySqlParameter5 = new MySqlParameter("@Sort", MySqlDbType.Int32, 11);
      mySqlParameter5.Value = (object) model.Sort;
      mySqlParameterArray[index5] = mySqlParameter5;
      int index6 = 5;
      MySqlParameter mySqlParameter6;
      if (model.Note != null)
      {
        MySqlParameter mySqlParameter7 = new MySqlParameter("@Note", MySqlDbType.LongText, -1);
        mySqlParameter7.Value = (object) model.Note;
        mySqlParameter6 = mySqlParameter7;
      }
      else
      {
        mySqlParameter6 = new MySqlParameter("@Note", MySqlDbType.LongText, -1);
        mySqlParameter6.Value = (object) DBNull.Value;
      }
      mySqlParameterArray[index6] = mySqlParameter6;
      int index7 = 6;
      MySqlParameter mySqlParameter8;
      if (model.Mobile != null)
      {
        MySqlParameter mySqlParameter7 = new MySqlParameter("@Mobile", MySqlDbType.VarChar, 50);
        mySqlParameter7.Value = (object) model.Mobile;
        mySqlParameter8 = mySqlParameter7;
      }
      else
      {
        mySqlParameter8 = new MySqlParameter("@Mobile", MySqlDbType.VarChar, 50);
        mySqlParameter8.Value = (object) DBNull.Value;
      }
      mySqlParameterArray[index7] = mySqlParameter8;
      int index8 = 7;
      MySqlParameter mySqlParameter9;
      if (model.Tel != null)
      {
        MySqlParameter mySqlParameter7 = new MySqlParameter("@Tel", MySqlDbType.VarChar, 500);
        mySqlParameter7.Value = (object) model.Tel;
        mySqlParameter9 = mySqlParameter7;
      }
      else
      {
        mySqlParameter9 = new MySqlParameter("@Tel", MySqlDbType.VarChar, 500);
        mySqlParameter9.Value = (object) DBNull.Value;
      }
      mySqlParameterArray[index8] = mySqlParameter9;
      int index9 = 8;
      MySqlParameter mySqlParameter10;
      if (model.OtherTel != null)
      {
        MySqlParameter mySqlParameter7 = new MySqlParameter("@OtherTel", MySqlDbType.VarChar, 500);
        mySqlParameter7.Value = (object) model.OtherTel;
        mySqlParameter10 = mySqlParameter7;
      }
      else
      {
        mySqlParameter10 = new MySqlParameter("@OtherTel", MySqlDbType.VarChar, 500);
        mySqlParameter10.Value = (object) DBNull.Value;
      }
      mySqlParameterArray[index9] = mySqlParameter10;
      int index10 = 9;
      MySqlParameter mySqlParameter11;
      if (model.Fax != null)
      {
        MySqlParameter mySqlParameter7 = new MySqlParameter("@Fax", MySqlDbType.VarChar, 50);
        mySqlParameter7.Value = (object) model.Fax;
        mySqlParameter11 = mySqlParameter7;
      }
      else
      {
        mySqlParameter11 = new MySqlParameter("@Fax", MySqlDbType.VarChar, 50);
        mySqlParameter11.Value = (object) DBNull.Value;
      }
      mySqlParameterArray[index10] = mySqlParameter11;
      int index11 = 10;
      MySqlParameter mySqlParameter12;
      if (model.Email != null)
      {
        MySqlParameter mySqlParameter7 = new MySqlParameter("@Email", MySqlDbType.VarChar, 500);
        mySqlParameter7.Value = (object) model.Email;
        mySqlParameter12 = mySqlParameter7;
      }
      else
      {
        mySqlParameter12 = new MySqlParameter("@Email", MySqlDbType.VarChar, 500);
        mySqlParameter12.Value = (object) DBNull.Value;
      }
      mySqlParameterArray[index11] = mySqlParameter12;
      int index12 = 11;
      MySqlParameter mySqlParameter13;
      if (model.QQ != null)
      {
        MySqlParameter mySqlParameter7 = new MySqlParameter("@QQ", MySqlDbType.VarChar, 50);
        mySqlParameter7.Value = (object) model.QQ;
        mySqlParameter13 = mySqlParameter7;
      }
      else
      {
        mySqlParameter13 = new MySqlParameter("@QQ", MySqlDbType.VarChar, 50);
        mySqlParameter13.Value = (object) DBNull.Value;
      }
      mySqlParameterArray[index12] = mySqlParameter13;
      int index13 = 12;
      MySqlParameter mySqlParameter14;
      if (model.HeadImg != null)
      {
        MySqlParameter mySqlParameter7 = new MySqlParameter("@HeadImg", MySqlDbType.VarChar, 500);
        mySqlParameter7.Value = (object) model.HeadImg;
        mySqlParameter14 = mySqlParameter7;
      }
      else
      {
        mySqlParameter14 = new MySqlParameter("@HeadImg", MySqlDbType.VarChar, 500);
        mySqlParameter14.Value = (object) DBNull.Value;
      }
      mySqlParameterArray[index13] = mySqlParameter14;
      int index14 = 13;
      MySqlParameter mySqlParameter15;
      if (model.WeiXin != null)
      {
        MySqlParameter mySqlParameter7 = new MySqlParameter("@WeiXin", MySqlDbType.VarChar, 50);
        mySqlParameter7.Value = (object) model.WeiXin;
        mySqlParameter15 = mySqlParameter7;
      }
      else
      {
        mySqlParameter15 = new MySqlParameter("@WeiXin", MySqlDbType.VarChar, 50);
        mySqlParameter15.Value = (object) DBNull.Value;
      }
      mySqlParameterArray[index14] = mySqlParameter15;
      int index15 = 14;
      int? sex = model.Sex;
      MySqlParameter mySqlParameter16;
      if (sex.HasValue)
      {
        MySqlParameter mySqlParameter7 = new MySqlParameter("@Sex", MySqlDbType.Int32, 11);
        sex = model.Sex;
        mySqlParameter7.Value = (object) sex.Value;
        mySqlParameter16 = mySqlParameter7;
      }
      else
      {
        mySqlParameter16 = new MySqlParameter("@Sex", MySqlDbType.Int32, 11);
        mySqlParameter16.Value = (object) DBNull.Value;
      }
      mySqlParameterArray[index15] = mySqlParameter16;
      int index16 = 15;
      MySqlParameter mySqlParameter17 = new MySqlParameter("@ID", MySqlDbType.VarChar, 36);
      mySqlParameter17.Value = (object) model.ID;
      mySqlParameterArray[index16] = mySqlParameter17;
      MySqlParameter[] parameter = mySqlParameterArray;
      return this.dbHelper.Execute(sql, parameter, false);
    }

    public int Delete(Guid id)
    {
      string sql = "DELETE FROM users WHERE ID=@ID";
      MySqlParameter[] mySqlParameterArray = new MySqlParameter[1];
      int index = 0;
      MySqlParameter mySqlParameter = new MySqlParameter("@ID", MySqlDbType.VarChar, 36);
      mySqlParameter.Value = (object) id.ToString();
      mySqlParameterArray[index] = mySqlParameter;
      MySqlParameter[] parameter = mySqlParameterArray;
      return this.dbHelper.Execute(sql, parameter, false);
    }

    private List<RoadFlow.Data.Model.Users> DataReaderToList(MySqlDataReader dataReader)
    {
      List<RoadFlow.Data.Model.Users> usersList = new List<RoadFlow.Data.Model.Users>();
      while (dataReader.Read())
      {
        RoadFlow.Data.Model.Users users = new RoadFlow.Data.Model.Users();
        users.ID = dataReader.GetString(0).ToGuid();
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
      MySqlDataReader dataReader = this.dbHelper.GetDataReader("SELECT * FROM users");
      List<RoadFlow.Data.Model.Users> list = this.DataReaderToList(dataReader);
      dataReader.Close();
      return list;
    }

    public long GetCount()
    {
      long result;
      if (!long.TryParse(this.dbHelper.GetFieldValue("SELECT COUNT(*) FROM users"), out result))
        return 0;
      return result;
    }

    public RoadFlow.Data.Model.Users Get(Guid id)
    {
      string sql = "SELECT * FROM users WHERE ID=@ID";
      MySqlParameter[] mySqlParameterArray = new MySqlParameter[1];
      int index = 0;
      MySqlParameter mySqlParameter = new MySqlParameter("@ID", MySqlDbType.VarChar, 36);
      mySqlParameter.Value = (object) id.ToString();
      mySqlParameterArray[index] = mySqlParameter;
      MySqlParameter[] parameter = mySqlParameterArray;
      MySqlDataReader dataReader = this.dbHelper.GetDataReader(sql, parameter);
      List<RoadFlow.Data.Model.Users> list = this.DataReaderToList(dataReader);
      dataReader.Close();
      if (list.Count <= 0)
        return (RoadFlow.Data.Model.Users) null;
      return list[0];
    }

    public RoadFlow.Data.Model.Users GetByAccount(string account)
    {
      string sql = "SELECT * FROM Users WHERE Account=@Account";
      MySqlParameter[] mySqlParameterArray = new MySqlParameter[1];
      int index = 0;
      MySqlParameter mySqlParameter = new MySqlParameter("@Account", MySqlDbType.VarChar, (int) byte.MaxValue);
      mySqlParameter.Value = (object) account;
      mySqlParameterArray[index] = mySqlParameter;
      MySqlParameter[] parameter = mySqlParameterArray;
      MySqlDataReader dataReader = this.dbHelper.GetDataReader(sql, parameter);
      List<RoadFlow.Data.Model.Users> list = this.DataReaderToList(dataReader);
      dataReader.Close();
      if (list.Count <= 0)
        return (RoadFlow.Data.Model.Users) null;
      return list[0];
    }

    public List<RoadFlow.Data.Model.Users> GetAllByOrganizeID(Guid organizeID)
    {
      string sql = "SELECT * FROM Users WHERE ID in(SELECT UserID FROM UsersRelation WHERE OrganizeID=@OrganizeID) ORDER BY Sort";
      MySqlParameter[] mySqlParameterArray = new MySqlParameter[1];
      int index = 0;
      MySqlParameter mySqlParameter = new MySqlParameter("@OrganizeID", MySqlDbType.VarChar);
      mySqlParameter.Value = (object) organizeID.ToString();
      mySqlParameterArray[index] = mySqlParameter;
      MySqlParameter[] parameter = mySqlParameterArray;
      MySqlDataReader dataReader = this.dbHelper.GetDataReader(sql, parameter);
      List<RoadFlow.Data.Model.Users> list = this.DataReaderToList(dataReader);
      dataReader.Close();
      return list;
    }

    public List<RoadFlow.Data.Model.Users> GetAllByOrganizeIDArray(Guid[] organizeIDArray)
    {
      if (organizeIDArray == null || organizeIDArray.Length == 0)
        return new List<RoadFlow.Data.Model.Users>();
      MySqlDataReader dataReader = this.dbHelper.GetDataReader("SELECT * FROM Users WHERE ID in(SELECT UserID FROM UsersRelation WHERE OrganizeID in(" + Tools.GetSqlInString<Guid>(organizeIDArray, true) + ")) ORDER BY Sort");
      List<RoadFlow.Data.Model.Users> list = this.DataReaderToList(dataReader);
      dataReader.Close();
      return list;
    }

    public bool HasAccount(string account, string userID = "")
    {
      string sql = "SELECT ID FROM Users WHERE Account=@Account";
      List<MySqlParameter> mySqlParameterList1 = new List<MySqlParameter>();
      List<MySqlParameter> mySqlParameterList2 = mySqlParameterList1;
      MySqlParameter mySqlParameter1 = new MySqlParameter("@Account", MySqlDbType.VarChar);
      mySqlParameter1.Value = (object) account;
      mySqlParameterList2.Add(mySqlParameter1);
      if (userID.IsGuid())
      {
        sql += " and ID<>@ID";
        List<MySqlParameter> mySqlParameterList3 = mySqlParameterList1;
        MySqlParameter mySqlParameter2 = new MySqlParameter("@ID", MySqlDbType.VarChar);
        mySqlParameter2.Value = (object) userID;
        mySqlParameterList3.Add(mySqlParameter2);
      }
      MySqlDataReader dataReader = this.dbHelper.GetDataReader(sql, mySqlParameterList1.ToArray());
      bool hasRows = dataReader.HasRows;
      dataReader.Close();
      return hasRows;
    }

    public bool UpdatePassword(string password, Guid userID)
    {
      string sql = "UPDATE Users SET Password=@Password WHERE ID=@ID";
      MySqlParameter[] mySqlParameterArray = new MySqlParameter[2];
      int index1 = 0;
      MySqlParameter mySqlParameter1 = new MySqlParameter("@Password", MySqlDbType.VarChar);
      mySqlParameter1.Value = (object) password;
      mySqlParameterArray[index1] = mySqlParameter1;
      int index2 = 1;
      MySqlParameter mySqlParameter2 = new MySqlParameter("@ID", MySqlDbType.VarChar);
      mySqlParameter2.Value = (object) userID.ToString();
      mySqlParameterArray[index2] = mySqlParameter2;
      MySqlParameter[] parameter = mySqlParameterArray;
      return this.dbHelper.Execute(sql, parameter, false) == 1;
    }

    public int UpdateSort(Guid userID, int sort)
    {
      string sql = "UPDATE Users SET Sort=@Sort WHERE ID=@ID";
      MySqlParameter[] mySqlParameterArray = new MySqlParameter[2];
      int index1 = 0;
      MySqlParameter mySqlParameter1 = new MySqlParameter("@Sort", MySqlDbType.Int32);
      mySqlParameter1.Value = (object) sort;
      mySqlParameterArray[index1] = mySqlParameter1;
      int index2 = 1;
      MySqlParameter mySqlParameter2 = new MySqlParameter("@ID", MySqlDbType.VarChar);
      mySqlParameter2.Value = (object) userID.ToString();
      mySqlParameterArray[index2] = mySqlParameter2;
      MySqlParameter[] parameter = mySqlParameterArray;
      return this.dbHelper.Execute(sql, parameter, false);
    }

    public List<RoadFlow.Data.Model.Users> GetAllByIDString(string idString)
    {
      MySqlDataReader dataReader = this.dbHelper.GetDataReader("SELECT * FROM Users WHERE ID IN(" + Tools.GetSqlInString(idString, true, ",") + ")");
      List<RoadFlow.Data.Model.Users> list = this.DataReaderToList(dataReader);
      dataReader.Close();
      return list;
    }

    public List<RoadFlow.Data.Model.Users> GetAllByWorkGroupID(Guid workgroupid)
    {
      MySqlDataReader dataReader = this.dbHelper.GetDataReader("SELECT * FROM Users WHERE ID IN(SELECT UserID FROM WorkGroupUsers WHERE WorkGroupID='" + (object) workgroupid + "')");
      List<RoadFlow.Data.Model.Users> list = this.DataReaderToList(dataReader);
      dataReader.Close();
      return list;
    }
  }
}
