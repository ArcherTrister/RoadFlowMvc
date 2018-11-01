// Decompiled with JetBrains decompiler
// Type: RoadFlow.Data.ORACLE.Users
// Assembly: RoadFlow.Data.ORACLE, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: C9018AA1-E48E-4231-92A9-CD6F0F275D11
// Assembly location: C:\inetpub\wwwroot\RoadFlowMvc\bin\RoadFlow.Data.ORACLE.dll

using Oracle.ManagedDataAccess.Client;
using RoadFlow.Data.Interface;
using RoadFlow.Utility;
using System;
using System.Collections.Generic;

namespace RoadFlow.Data.ORACLE
{
  public class Users : IUsers
  {
    private DBHelper dbHelper = new DBHelper();

    public int Add(RoadFlow.Data.Model.Users model)
    {
      string sql = "INSERT INTO Users\r\n\t\t\t\t(ID,Name,Account,Password,Status,Sort,Note,Mobile,Tel,OtherTel,Fax,Email,QQ,HeadImg,WeiXin,Sex) \r\n\t\t\t\tVALUES(:ID,:Name,:Account,:Password,:Status,:Sort,:Note,:Mobile,:Tel,:OtherTel,:Fax,:Email,:QQ,:HeadImg,:WeiXin,:Sex)";
      OracleParameter[] oracleParameterArray = new OracleParameter[16];
      int index1 = 0;
      OracleParameter oracleParameter1 = new OracleParameter(":ID", OracleDbType.Varchar2, 40);
      oracleParameter1.Value = (object) model.ID;
      oracleParameterArray[index1] = oracleParameter1;
      int index2 = 1;
      OracleParameter oracleParameter2 = new OracleParameter(":Name", OracleDbType.NVarchar2, 100);
      oracleParameter2.Value = (object) model.Name;
      oracleParameterArray[index2] = oracleParameter2;
      int index3 = 2;
      OracleParameter oracleParameter3 = new OracleParameter(":Account", OracleDbType.Varchar2, (int) byte.MaxValue);
      oracleParameter3.Value = (object) model.Account;
      oracleParameterArray[index3] = oracleParameter3;
      int index4 = 3;
      OracleParameter oracleParameter4 = new OracleParameter(":Password", OracleDbType.Varchar2, 500);
      oracleParameter4.Value = (object) model.Password;
      oracleParameterArray[index4] = oracleParameter4;
      int index5 = 4;
      OracleParameter oracleParameter5 = new OracleParameter(":Status", OracleDbType.Int32);
      oracleParameter5.Value = (object) model.Status;
      oracleParameterArray[index5] = oracleParameter5;
      int index6 = 5;
      OracleParameter oracleParameter6 = new OracleParameter(":Sort", OracleDbType.Int32);
      oracleParameter6.Value = (object) model.Sort;
      oracleParameterArray[index6] = oracleParameter6;
      int index7 = 6;
      OracleParameter oracleParameter7;
      if (model.Note != null)
      {
        OracleParameter oracleParameter8 = new OracleParameter(":Note", OracleDbType.NVarchar2);
        oracleParameter8.Value = (object) model.Note;
        oracleParameter7 = oracleParameter8;
      }
      else
      {
        oracleParameter7 = new OracleParameter(":Note", OracleDbType.NVarchar2);
        oracleParameter7.Value = (object) DBNull.Value;
      }
      oracleParameterArray[index7] = oracleParameter7;
      int index8 = 7;
      OracleParameter oracleParameter9;
      if (model.Mobile != null)
      {
        OracleParameter oracleParameter8 = new OracleParameter("@Mobile", OracleDbType.NVarchar2, 50);
        oracleParameter8.Value = (object) model.Mobile;
        oracleParameter9 = oracleParameter8;
      }
      else
      {
        oracleParameter9 = new OracleParameter("@Mobile", OracleDbType.NVarchar2, 50);
        oracleParameter9.Value = (object) DBNull.Value;
      }
      oracleParameterArray[index8] = oracleParameter9;
      int index9 = 8;
      OracleParameter oracleParameter10;
      if (model.Tel != null)
      {
        OracleParameter oracleParameter8 = new OracleParameter("@Tel", OracleDbType.NVarchar2, 500);
        oracleParameter8.Value = (object) model.Tel;
        oracleParameter10 = oracleParameter8;
      }
      else
      {
        oracleParameter10 = new OracleParameter("@Tel", OracleDbType.NVarchar2, 500);
        oracleParameter10.Value = (object) DBNull.Value;
      }
      oracleParameterArray[index9] = oracleParameter10;
      int index10 = 9;
      OracleParameter oracleParameter11;
      if (model.OtherTel != null)
      {
        OracleParameter oracleParameter8 = new OracleParameter("@OtherTel", OracleDbType.NVarchar2, 500);
        oracleParameter8.Value = (object) model.OtherTel;
        oracleParameter11 = oracleParameter8;
      }
      else
      {
        oracleParameter11 = new OracleParameter("@OtherTel", OracleDbType.NVarchar2, 500);
        oracleParameter11.Value = (object) DBNull.Value;
      }
      oracleParameterArray[index10] = oracleParameter11;
      int index11 = 10;
      OracleParameter oracleParameter12;
      if (model.Fax != null)
      {
        OracleParameter oracleParameter8 = new OracleParameter("@Fax", OracleDbType.NVarchar2, 50);
        oracleParameter8.Value = (object) model.Fax;
        oracleParameter12 = oracleParameter8;
      }
      else
      {
        oracleParameter12 = new OracleParameter("@Fax", OracleDbType.NVarchar2, 50);
        oracleParameter12.Value = (object) DBNull.Value;
      }
      oracleParameterArray[index11] = oracleParameter12;
      int index12 = 11;
      OracleParameter oracleParameter13;
      if (model.Email != null)
      {
        OracleParameter oracleParameter8 = new OracleParameter("@Email", OracleDbType.NVarchar2, 500);
        oracleParameter8.Value = (object) model.Email;
        oracleParameter13 = oracleParameter8;
      }
      else
      {
        oracleParameter13 = new OracleParameter("@Email", OracleDbType.NVarchar2, 500);
        oracleParameter13.Value = (object) DBNull.Value;
      }
      oracleParameterArray[index12] = oracleParameter13;
      int index13 = 12;
      OracleParameter oracleParameter14;
      if (model.QQ != null)
      {
        OracleParameter oracleParameter8 = new OracleParameter("@QQ", OracleDbType.NVarchar2, 50);
        oracleParameter8.Value = (object) model.QQ;
        oracleParameter14 = oracleParameter8;
      }
      else
      {
        oracleParameter14 = new OracleParameter("@QQ", OracleDbType.NVarchar2, 50);
        oracleParameter14.Value = (object) DBNull.Value;
      }
      oracleParameterArray[index13] = oracleParameter14;
      int index14 = 13;
      OracleParameter oracleParameter15;
      if (model.HeadImg != null)
      {
        OracleParameter oracleParameter8 = new OracleParameter("@HeadImg", OracleDbType.NVarchar2, 500);
        oracleParameter8.Value = (object) model.HeadImg;
        oracleParameter15 = oracleParameter8;
      }
      else
      {
        oracleParameter15 = new OracleParameter("@HeadImg", OracleDbType.NVarchar2, 500);
        oracleParameter15.Value = (object) DBNull.Value;
      }
      oracleParameterArray[index14] = oracleParameter15;
      int index15 = 14;
      OracleParameter oracleParameter16;
      if (model.WeiXin != null)
      {
        OracleParameter oracleParameter8 = new OracleParameter("@WeiXin", OracleDbType.NVarchar2, 50);
        oracleParameter8.Value = (object) model.WeiXin;
        oracleParameter16 = oracleParameter8;
      }
      else
      {
        oracleParameter16 = new OracleParameter("@WeiXin", OracleDbType.NVarchar2, 50);
        oracleParameter16.Value = (object) DBNull.Value;
      }
      oracleParameterArray[index15] = oracleParameter16;
      int index16 = 15;
      int? sex = model.Sex;
      OracleParameter oracleParameter17;
      if (sex.HasValue)
      {
        OracleParameter oracleParameter8 = new OracleParameter("@Sex", OracleDbType.Int32, 11);
        sex = model.Sex;
        oracleParameter8.Value = (object) sex.Value;
        oracleParameter17 = oracleParameter8;
      }
      else
      {
        oracleParameter17 = new OracleParameter("@Sex", OracleDbType.Int32);
        oracleParameter17.Value = (object) DBNull.Value;
      }
      oracleParameterArray[index16] = oracleParameter17;
      OracleParameter[] parameter = oracleParameterArray;
      return this.dbHelper.Execute(sql, parameter);
    }

    public int Update(RoadFlow.Data.Model.Users model)
    {
      string sql = "UPDATE Users SET \r\n\t\t\t\tName=:Name,Account=:Account,Password=:Password,Status=:Status,Sort=:Sort,Note=:Note,Mobile=:Mobile,Tel=:Tel,OtherTel=:OtherTel,Fax=:Fax,Email=:Email,QQ=:QQ,HeadImg=:HeadImg,WeiXin=:WeiXin,Sex=:Sex\r\n\t\t\t\tWHERE ID=:ID";
      OracleParameter[] oracleParameterArray = new OracleParameter[16];
      int index1 = 0;
      OracleParameter oracleParameter1 = new OracleParameter(":Name", OracleDbType.NVarchar2, 100);
      oracleParameter1.Value = (object) model.Name;
      oracleParameterArray[index1] = oracleParameter1;
      int index2 = 1;
      OracleParameter oracleParameter2 = new OracleParameter(":Account", OracleDbType.Varchar2, (int) byte.MaxValue);
      oracleParameter2.Value = (object) model.Account;
      oracleParameterArray[index2] = oracleParameter2;
      int index3 = 2;
      OracleParameter oracleParameter3 = new OracleParameter(":Password", OracleDbType.Varchar2, 500);
      oracleParameter3.Value = (object) model.Password;
      oracleParameterArray[index3] = oracleParameter3;
      int index4 = 3;
      OracleParameter oracleParameter4 = new OracleParameter(":Status", OracleDbType.Int32);
      oracleParameter4.Value = (object) model.Status;
      oracleParameterArray[index4] = oracleParameter4;
      int index5 = 4;
      OracleParameter oracleParameter5 = new OracleParameter(":Sort", OracleDbType.Int32);
      oracleParameter5.Value = (object) model.Sort;
      oracleParameterArray[index5] = oracleParameter5;
      int index6 = 5;
      OracleParameter oracleParameter6;
      if (model.Note != null)
      {
        OracleParameter oracleParameter7 = new OracleParameter(":Note", OracleDbType.NVarchar2);
        oracleParameter7.Value = (object) model.Note;
        oracleParameter6 = oracleParameter7;
      }
      else
      {
        oracleParameter6 = new OracleParameter(":Note", OracleDbType.NVarchar2);
        oracleParameter6.Value = (object) DBNull.Value;
      }
      oracleParameterArray[index6] = oracleParameter6;
      int index7 = 6;
      OracleParameter oracleParameter8;
      if (model.Mobile != null)
      {
        OracleParameter oracleParameter7 = new OracleParameter("@Mobile", OracleDbType.NVarchar2, 50);
        oracleParameter7.Value = (object) model.Mobile;
        oracleParameter8 = oracleParameter7;
      }
      else
      {
        oracleParameter8 = new OracleParameter("@Mobile", OracleDbType.NVarchar2, 50);
        oracleParameter8.Value = (object) DBNull.Value;
      }
      oracleParameterArray[index7] = oracleParameter8;
      int index8 = 7;
      OracleParameter oracleParameter9;
      if (model.Tel != null)
      {
        OracleParameter oracleParameter7 = new OracleParameter("@Tel", OracleDbType.NVarchar2, 500);
        oracleParameter7.Value = (object) model.Tel;
        oracleParameter9 = oracleParameter7;
      }
      else
      {
        oracleParameter9 = new OracleParameter("@Tel", OracleDbType.NVarchar2, 500);
        oracleParameter9.Value = (object) DBNull.Value;
      }
      oracleParameterArray[index8] = oracleParameter9;
      int index9 = 8;
      OracleParameter oracleParameter10;
      if (model.OtherTel != null)
      {
        OracleParameter oracleParameter7 = new OracleParameter("@OtherTel", OracleDbType.NVarchar2, 500);
        oracleParameter7.Value = (object) model.OtherTel;
        oracleParameter10 = oracleParameter7;
      }
      else
      {
        oracleParameter10 = new OracleParameter("@OtherTel", OracleDbType.NVarchar2, 500);
        oracleParameter10.Value = (object) DBNull.Value;
      }
      oracleParameterArray[index9] = oracleParameter10;
      int index10 = 9;
      OracleParameter oracleParameter11;
      if (model.Fax != null)
      {
        OracleParameter oracleParameter7 = new OracleParameter("@Fax", OracleDbType.NVarchar2, 50);
        oracleParameter7.Value = (object) model.Fax;
        oracleParameter11 = oracleParameter7;
      }
      else
      {
        oracleParameter11 = new OracleParameter("@Fax", OracleDbType.NVarchar2, 50);
        oracleParameter11.Value = (object) DBNull.Value;
      }
      oracleParameterArray[index10] = oracleParameter11;
      int index11 = 10;
      OracleParameter oracleParameter12;
      if (model.Email != null)
      {
        OracleParameter oracleParameter7 = new OracleParameter("@Email", OracleDbType.NVarchar2, 500);
        oracleParameter7.Value = (object) model.Email;
        oracleParameter12 = oracleParameter7;
      }
      else
      {
        oracleParameter12 = new OracleParameter("@Email", OracleDbType.NVarchar2, 500);
        oracleParameter12.Value = (object) DBNull.Value;
      }
      oracleParameterArray[index11] = oracleParameter12;
      int index12 = 11;
      OracleParameter oracleParameter13;
      if (model.QQ != null)
      {
        OracleParameter oracleParameter7 = new OracleParameter("@QQ", OracleDbType.NVarchar2, 50);
        oracleParameter7.Value = (object) model.QQ;
        oracleParameter13 = oracleParameter7;
      }
      else
      {
        oracleParameter13 = new OracleParameter("@QQ", OracleDbType.NVarchar2, 50);
        oracleParameter13.Value = (object) DBNull.Value;
      }
      oracleParameterArray[index12] = oracleParameter13;
      int index13 = 12;
      OracleParameter oracleParameter14;
      if (model.HeadImg != null)
      {
        OracleParameter oracleParameter7 = new OracleParameter("@HeadImg", OracleDbType.NVarchar2, 500);
        oracleParameter7.Value = (object) model.HeadImg;
        oracleParameter14 = oracleParameter7;
      }
      else
      {
        oracleParameter14 = new OracleParameter("@HeadImg", OracleDbType.NVarchar2, 500);
        oracleParameter14.Value = (object) DBNull.Value;
      }
      oracleParameterArray[index13] = oracleParameter14;
      int index14 = 13;
      OracleParameter oracleParameter15;
      if (model.WeiXin != null)
      {
        OracleParameter oracleParameter7 = new OracleParameter("@WeiXin", OracleDbType.NVarchar2, 50);
        oracleParameter7.Value = (object) model.WeiXin;
        oracleParameter15 = oracleParameter7;
      }
      else
      {
        oracleParameter15 = new OracleParameter("@WeiXin", OracleDbType.NVarchar2, 50);
        oracleParameter15.Value = (object) DBNull.Value;
      }
      oracleParameterArray[index14] = oracleParameter15;
      int index15 = 14;
      int? sex = model.Sex;
      OracleParameter oracleParameter16;
      if (sex.HasValue)
      {
        OracleParameter oracleParameter7 = new OracleParameter("@Sex", OracleDbType.Int32, 11);
        sex = model.Sex;
        oracleParameter7.Value = (object) sex.Value;
        oracleParameter16 = oracleParameter7;
      }
      else
      {
        oracleParameter16 = new OracleParameter("@Sex", OracleDbType.Int32);
        oracleParameter16.Value = (object) DBNull.Value;
      }
      oracleParameterArray[index15] = oracleParameter16;
      int index16 = 15;
      OracleParameter oracleParameter17 = new OracleParameter(":ID", OracleDbType.Varchar2, 40);
      oracleParameter17.Value = (object) model.ID;
      oracleParameterArray[index16] = oracleParameter17;
      OracleParameter[] parameter = oracleParameterArray;
      return this.dbHelper.Execute(sql, parameter);
    }

    public int Delete(Guid id)
    {
      string sql = "DELETE FROM Users WHERE ID=:ID";
      OracleParameter[] oracleParameterArray = new OracleParameter[1];
      int index = 0;
      OracleParameter oracleParameter = new OracleParameter(":ID", OracleDbType.Varchar2);
      oracleParameter.Value = (object) id;
      oracleParameterArray[index] = oracleParameter;
      OracleParameter[] parameter = oracleParameterArray;
      return this.dbHelper.Execute(sql, parameter);
    }

    private List<RoadFlow.Data.Model.Users> DataReaderToList(OracleDataReader dataReader)
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
      OracleDataReader dataReader = this.dbHelper.GetDataReader("SELECT * FROM Users");
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
      string sql = "SELECT * FROM Users WHERE ID=:ID";
      OracleParameter[] oracleParameterArray = new OracleParameter[1];
      int index = 0;
      OracleParameter oracleParameter = new OracleParameter(":ID", OracleDbType.Varchar2);
      oracleParameter.Value = (object) id;
      oracleParameterArray[index] = oracleParameter;
      OracleParameter[] parameter = oracleParameterArray;
      OracleDataReader dataReader = this.dbHelper.GetDataReader(sql, parameter);
      List<RoadFlow.Data.Model.Users> list = this.DataReaderToList(dataReader);
      dataReader.Close();
      if (list.Count <= 0)
        return (RoadFlow.Data.Model.Users) null;
      return list[0];
    }

    public RoadFlow.Data.Model.Users GetByAccount(string account)
    {
      string sql = "SELECT * FROM Users WHERE Account=:Account";
      OracleParameter[] oracleParameterArray = new OracleParameter[1];
      int index = 0;
      OracleParameter oracleParameter = new OracleParameter(":Account", OracleDbType.Varchar2, (int) byte.MaxValue);
      oracleParameter.Value = (object) account;
      oracleParameterArray[index] = oracleParameter;
      OracleParameter[] parameter = oracleParameterArray;
      OracleDataReader dataReader = this.dbHelper.GetDataReader(sql, parameter);
      List<RoadFlow.Data.Model.Users> list = this.DataReaderToList(dataReader);
      dataReader.Close();
      if (list.Count <= 0)
        return (RoadFlow.Data.Model.Users) null;
      return list[0];
    }

    public List<RoadFlow.Data.Model.Users> GetAllByOrganizeID(Guid organizeID)
    {
      string sql = "SELECT * FROM Users WHERE ID in(SELECT UserID FROM UsersRelation WHERE OrganizeID=:OrganizeID) ORDER BY Sort";
      OracleParameter[] oracleParameterArray = new OracleParameter[1];
      int index = 0;
      OracleParameter oracleParameter = new OracleParameter(":OrganizeID", OracleDbType.Varchar2);
      oracleParameter.Value = (object) organizeID;
      oracleParameterArray[index] = oracleParameter;
      OracleParameter[] parameter = oracleParameterArray;
      OracleDataReader dataReader = this.dbHelper.GetDataReader(sql, parameter);
      List<RoadFlow.Data.Model.Users> list = this.DataReaderToList(dataReader);
      dataReader.Close();
      return list;
    }

    public List<RoadFlow.Data.Model.Users> GetAllByOrganizeIDArray(Guid[] organizeIDArray)
    {
      if (organizeIDArray == null || organizeIDArray.Length == 0)
        return new List<RoadFlow.Data.Model.Users>();
      OracleDataReader dataReader = this.dbHelper.GetDataReader("SELECT * FROM Users WHERE ID in(SELECT UserID FROM UsersRelation WHERE OrganizeID in(" + Tools.GetSqlInString<Guid>(organizeIDArray, true) + ")) ORDER BY Sort");
      List<RoadFlow.Data.Model.Users> list = this.DataReaderToList(dataReader);
      dataReader.Close();
      return list;
    }

    public bool HasAccount(string account, string userID = "")
    {
      string sql = "SELECT ID FROM Users WHERE Account=:Account";
      List<OracleParameter> oracleParameterList1 = new List<OracleParameter>();
      List<OracleParameter> oracleParameterList2 = oracleParameterList1;
      OracleParameter oracleParameter1 = new OracleParameter(":Account", OracleDbType.Varchar2);
      oracleParameter1.Value = (object) account;
      oracleParameterList2.Add(oracleParameter1);
      if (userID.IsGuid())
      {
        sql += " and ID<>:ID";
        List<OracleParameter> oracleParameterList3 = oracleParameterList1;
        OracleParameter oracleParameter2 = new OracleParameter(":ID", OracleDbType.Varchar2);
        oracleParameter2.Value = (object) userID.ToGuid();
        oracleParameterList3.Add(oracleParameter2);
      }
      OracleDataReader dataReader = this.dbHelper.GetDataReader(sql, oracleParameterList1.ToArray());
      bool hasRows = dataReader.HasRows;
      dataReader.Close();
      return hasRows;
    }

    public bool UpdatePassword(string password, Guid userID)
    {
      string sql = "UPDATE Users SET Password=:Password WHERE ID=:ID";
      OracleParameter[] oracleParameterArray = new OracleParameter[2];
      int index1 = 0;
      OracleParameter oracleParameter1 = new OracleParameter(":Password", OracleDbType.Varchar2);
      oracleParameter1.Value = (object) password;
      oracleParameterArray[index1] = oracleParameter1;
      int index2 = 1;
      OracleParameter oracleParameter2 = new OracleParameter(":ID", OracleDbType.Varchar2);
      oracleParameter2.Value = (object) userID;
      oracleParameterArray[index2] = oracleParameter2;
      OracleParameter[] parameter = oracleParameterArray;
      return this.dbHelper.Execute(sql, parameter) == 1;
    }

    public int UpdateSort(Guid userID, int sort)
    {
      string sql = "UPDATE Users SET Sort=:Sort WHERE ID=:ID";
      OracleParameter[] oracleParameterArray = new OracleParameter[2];
      int index1 = 0;
      OracleParameter oracleParameter1 = new OracleParameter(":Sort", OracleDbType.Int32);
      oracleParameter1.Value = (object) sort;
      oracleParameterArray[index1] = oracleParameter1;
      int index2 = 1;
      OracleParameter oracleParameter2 = new OracleParameter(":ID", OracleDbType.Varchar2);
      oracleParameter2.Value = (object) userID;
      oracleParameterArray[index2] = oracleParameter2;
      OracleParameter[] parameter = oracleParameterArray;
      return this.dbHelper.Execute(sql, parameter);
    }

    public List<RoadFlow.Data.Model.Users> GetAllByIDString(string idString)
    {
      OracleDataReader dataReader = this.dbHelper.GetDataReader("SELECT * FROM Users WHERE ID IN(" + Tools.GetSqlInString(idString, true, ",") + ")");
      List<RoadFlow.Data.Model.Users> list = this.DataReaderToList(dataReader);
      dataReader.Close();
      return list;
    }

    public List<RoadFlow.Data.Model.Users> GetAllByWorkGroupID(Guid workgroupid)
    {
      OracleDataReader dataReader = this.dbHelper.GetDataReader("SELECT * FROM Users WHERE ID IN(SELECT UserID FROM WorkGroupUsers WHERE WorkGroupID='" + (object) workgroupid + "')");
      List<RoadFlow.Data.Model.Users> list = this.DataReaderToList(dataReader);
      dataReader.Close();
      return list;
    }
  }
}
