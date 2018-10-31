// Decompiled with JetBrains decompiler
// Type: RoadFlow.Data.MySql.WorkFlow
// Assembly: RoadFlow.Data.MySql, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 29B652D7-5F6F-4A7D-AD1C-9F2C643FD784
// Assembly location: C:\inetpub\wwwroot\RoadFlowMvc\bin\RoadFlow.Data.MySql.dll

using MySql.Data.MySqlClient;
using RoadFlow.Data.Interface;
using RoadFlow.Utility;
using System;
using System.Collections.Generic;
using System.Text;

namespace RoadFlow.Data.MySql
{
  public class WorkFlow : IWorkFlow
  {
    private DBHelper dbHelper = new DBHelper();

    public int Add(RoadFlow.Data.Model.WorkFlow model)
    {
      string sql = "INSERT INTO workflow\r\n\t\t\t\t(ID,Name,Type,Manager,InstanceManager,CreateDate,CreateUserID,DesignJSON,InstallDate,InstallUserID,RunJSON,Status) \r\n\t\t\t\tVALUES(@ID,@Name,@Type,@Manager,@InstanceManager,@CreateDate,@CreateUserID,@DesignJSON,@InstallDate,@InstallUserID,@RunJSON,@Status)";
      MySqlParameter[] mySqlParameterArray = new MySqlParameter[12];
      int index1 = 0;
      MySqlParameter mySqlParameter1 = new MySqlParameter("@ID", MySqlDbType.VarChar, 36);
      mySqlParameter1.Value = (object) model.ID;
      mySqlParameterArray[index1] = mySqlParameter1;
      int index2 = 1;
      MySqlParameter mySqlParameter2 = new MySqlParameter("@Name", MySqlDbType.Text, -1);
      mySqlParameter2.Value = (object) model.Name;
      mySqlParameterArray[index2] = mySqlParameter2;
      int index3 = 2;
      MySqlParameter mySqlParameter3 = new MySqlParameter("@Type", MySqlDbType.VarChar, 36);
      mySqlParameter3.Value = (object) model.Type;
      mySqlParameterArray[index3] = mySqlParameter3;
      int index4 = 3;
      MySqlParameter mySqlParameter4 = new MySqlParameter("@Manager", MySqlDbType.Text, -1);
      mySqlParameter4.Value = (object) model.Manager;
      mySqlParameterArray[index4] = mySqlParameter4;
      int index5 = 4;
      MySqlParameter mySqlParameter5 = new MySqlParameter("@InstanceManager", MySqlDbType.Text, -1);
      mySqlParameter5.Value = (object) model.InstanceManager;
      mySqlParameterArray[index5] = mySqlParameter5;
      int index6 = 5;
      MySqlParameter mySqlParameter6 = new MySqlParameter("@CreateDate", MySqlDbType.DateTime, -1);
      mySqlParameter6.Value = (object) model.CreateDate;
      mySqlParameterArray[index6] = mySqlParameter6;
      int index7 = 6;
      MySqlParameter mySqlParameter7 = new MySqlParameter("@CreateUserID", MySqlDbType.VarChar, 36);
      mySqlParameter7.Value = (object) model.CreateUserID;
      mySqlParameterArray[index7] = mySqlParameter7;
      int index8 = 7;
      MySqlParameter mySqlParameter8;
      if (model.DesignJSON != null)
      {
        MySqlParameter mySqlParameter9 = new MySqlParameter("@DesignJSON", MySqlDbType.LongText, -1);
        mySqlParameter9.Value = (object) model.DesignJSON;
        mySqlParameter8 = mySqlParameter9;
      }
      else
      {
        mySqlParameter8 = new MySqlParameter("@DesignJSON", MySqlDbType.LongText, -1);
        mySqlParameter8.Value = (object) DBNull.Value;
      }
      mySqlParameterArray[index8] = mySqlParameter8;
      int index9 = 8;
      MySqlParameter mySqlParameter10;
      if (model.InstallDate.HasValue)
      {
        MySqlParameter mySqlParameter9 = new MySqlParameter("@InstallDate", MySqlDbType.DateTime, -1);
        mySqlParameter9.Value = (object) model.InstallDate;
        mySqlParameter10 = mySqlParameter9;
      }
      else
      {
        mySqlParameter10 = new MySqlParameter("@InstallDate", MySqlDbType.DateTime, -1);
        mySqlParameter10.Value = (object) DBNull.Value;
      }
      mySqlParameterArray[index9] = mySqlParameter10;
      int index10 = 9;
      MySqlParameter mySqlParameter11;
      if (model.InstallUserID.HasValue)
      {
        MySqlParameter mySqlParameter9 = new MySqlParameter("@InstallUserID", MySqlDbType.VarChar, 36);
        mySqlParameter9.Value = (object) model.InstallUserID;
        mySqlParameter11 = mySqlParameter9;
      }
      else
      {
        mySqlParameter11 = new MySqlParameter("@InstallUserID", MySqlDbType.VarChar, 36);
        mySqlParameter11.Value = (object) DBNull.Value;
      }
      mySqlParameterArray[index10] = mySqlParameter11;
      int index11 = 10;
      MySqlParameter mySqlParameter12;
      if (model.RunJSON != null)
      {
        MySqlParameter mySqlParameter9 = new MySqlParameter("@RunJSON", MySqlDbType.LongText, -1);
        mySqlParameter9.Value = (object) model.RunJSON;
        mySqlParameter12 = mySqlParameter9;
      }
      else
      {
        mySqlParameter12 = new MySqlParameter("@RunJSON", MySqlDbType.LongText, -1);
        mySqlParameter12.Value = (object) DBNull.Value;
      }
      mySqlParameterArray[index11] = mySqlParameter12;
      int index12 = 11;
      MySqlParameter mySqlParameter13 = new MySqlParameter("@Status", MySqlDbType.Int32, 11);
      mySqlParameter13.Value = (object) model.Status;
      mySqlParameterArray[index12] = mySqlParameter13;
      MySqlParameter[] parameter = mySqlParameterArray;
      return this.dbHelper.Execute(sql, parameter, false);
    }

    public int Update(RoadFlow.Data.Model.WorkFlow model)
    {
      string sql = "UPDATE workflow SET \r\n\t\t\t\tName=@Name,Type=@Type,Manager=@Manager,InstanceManager=@InstanceManager,CreateDate=@CreateDate,CreateUserID=@CreateUserID,DesignJSON=@DesignJSON,InstallDate=@InstallDate,InstallUserID=@InstallUserID,RunJSON=@RunJSON,Status=@Status\r\n\t\t\t\tWHERE ID=@ID";
      MySqlParameter[] mySqlParameterArray = new MySqlParameter[12];
      int index1 = 0;
      MySqlParameter mySqlParameter1 = new MySqlParameter("@Name", MySqlDbType.Text, -1);
      mySqlParameter1.Value = (object) model.Name;
      mySqlParameterArray[index1] = mySqlParameter1;
      int index2 = 1;
      MySqlParameter mySqlParameter2 = new MySqlParameter("@Type", MySqlDbType.VarChar, 36);
      mySqlParameter2.Value = (object) model.Type;
      mySqlParameterArray[index2] = mySqlParameter2;
      int index3 = 2;
      MySqlParameter mySqlParameter3 = new MySqlParameter("@Manager", MySqlDbType.Text, -1);
      mySqlParameter3.Value = (object) model.Manager;
      mySqlParameterArray[index3] = mySqlParameter3;
      int index4 = 3;
      MySqlParameter mySqlParameter4 = new MySqlParameter("@InstanceManager", MySqlDbType.Text, -1);
      mySqlParameter4.Value = (object) model.InstanceManager;
      mySqlParameterArray[index4] = mySqlParameter4;
      int index5 = 4;
      MySqlParameter mySqlParameter5 = new MySqlParameter("@CreateDate", MySqlDbType.DateTime, -1);
      mySqlParameter5.Value = (object) model.CreateDate;
      mySqlParameterArray[index5] = mySqlParameter5;
      int index6 = 5;
      MySqlParameter mySqlParameter6 = new MySqlParameter("@CreateUserID", MySqlDbType.VarChar, 36);
      mySqlParameter6.Value = (object) model.CreateUserID;
      mySqlParameterArray[index6] = mySqlParameter6;
      int index7 = 6;
      MySqlParameter mySqlParameter7;
      if (model.DesignJSON != null)
      {
        MySqlParameter mySqlParameter8 = new MySqlParameter("@DesignJSON", MySqlDbType.LongText, -1);
        mySqlParameter8.Value = (object) model.DesignJSON;
        mySqlParameter7 = mySqlParameter8;
      }
      else
      {
        mySqlParameter7 = new MySqlParameter("@DesignJSON", MySqlDbType.LongText, -1);
        mySqlParameter7.Value = (object) DBNull.Value;
      }
      mySqlParameterArray[index7] = mySqlParameter7;
      int index8 = 7;
      MySqlParameter mySqlParameter9;
      if (model.InstallDate.HasValue)
      {
        MySqlParameter mySqlParameter8 = new MySqlParameter("@InstallDate", MySqlDbType.DateTime, -1);
        mySqlParameter8.Value = (object) model.InstallDate;
        mySqlParameter9 = mySqlParameter8;
      }
      else
      {
        mySqlParameter9 = new MySqlParameter("@InstallDate", MySqlDbType.DateTime, -1);
        mySqlParameter9.Value = (object) DBNull.Value;
      }
      mySqlParameterArray[index8] = mySqlParameter9;
      int index9 = 8;
      MySqlParameter mySqlParameter10;
      if (model.InstallUserID.HasValue)
      {
        MySqlParameter mySqlParameter8 = new MySqlParameter("@InstallUserID", MySqlDbType.VarChar, 36);
        mySqlParameter8.Value = (object) model.InstallUserID;
        mySqlParameter10 = mySqlParameter8;
      }
      else
      {
        mySqlParameter10 = new MySqlParameter("@InstallUserID", MySqlDbType.VarChar, 36);
        mySqlParameter10.Value = (object) DBNull.Value;
      }
      mySqlParameterArray[index9] = mySqlParameter10;
      int index10 = 9;
      MySqlParameter mySqlParameter11;
      if (model.RunJSON != null)
      {
        MySqlParameter mySqlParameter8 = new MySqlParameter("@RunJSON", MySqlDbType.LongText, -1);
        mySqlParameter8.Value = (object) model.RunJSON;
        mySqlParameter11 = mySqlParameter8;
      }
      else
      {
        mySqlParameter11 = new MySqlParameter("@RunJSON", MySqlDbType.LongText, -1);
        mySqlParameter11.Value = (object) DBNull.Value;
      }
      mySqlParameterArray[index10] = mySqlParameter11;
      int index11 = 10;
      MySqlParameter mySqlParameter12 = new MySqlParameter("@Status", MySqlDbType.Int32, 11);
      mySqlParameter12.Value = (object) model.Status;
      mySqlParameterArray[index11] = mySqlParameter12;
      int index12 = 11;
      MySqlParameter mySqlParameter13 = new MySqlParameter("@ID", MySqlDbType.VarChar, 36);
      mySqlParameter13.Value = (object) model.ID;
      mySqlParameterArray[index12] = mySqlParameter13;
      MySqlParameter[] parameter = mySqlParameterArray;
      return this.dbHelper.Execute(sql, parameter, false);
    }

    public int Delete(Guid id)
    {
      string sql = "DELETE FROM workflow WHERE ID=@ID";
      MySqlParameter[] mySqlParameterArray = new MySqlParameter[1];
      int index = 0;
      MySqlParameter mySqlParameter = new MySqlParameter("@ID", MySqlDbType.VarChar, 36);
      mySqlParameter.Value = (object) id.ToString();
      mySqlParameterArray[index] = mySqlParameter;
      MySqlParameter[] parameter = mySqlParameterArray;
      return this.dbHelper.Execute(sql, parameter, false);
    }

    private List<RoadFlow.Data.Model.WorkFlow> DataReaderToList(MySqlDataReader dataReader)
    {
      List<RoadFlow.Data.Model.WorkFlow> workFlowList = new List<RoadFlow.Data.Model.WorkFlow>();
      while (dataReader.Read())
      {
        RoadFlow.Data.Model.WorkFlow workFlow = new RoadFlow.Data.Model.WorkFlow();
        workFlow.ID = dataReader.GetString(0).ToGuid();
        workFlow.Name = dataReader.GetString(1);
        workFlow.Type = dataReader.GetString(2).ToGuid();
        workFlow.Manager = dataReader.GetString(3);
        workFlow.InstanceManager = dataReader.GetString(4);
        workFlow.CreateDate = dataReader.GetDateTime(5);
        workFlow.CreateUserID = dataReader.GetString(6).ToGuid();
        if (!dataReader.IsDBNull(7))
          workFlow.DesignJSON = dataReader.GetString(7);
        if (!dataReader.IsDBNull(8))
          workFlow.InstallDate = new DateTime?(dataReader.GetDateTime(8));
        if (!dataReader.IsDBNull(9))
          workFlow.InstallUserID = new Guid?(dataReader.GetString(9).ToGuid());
        if (!dataReader.IsDBNull(10))
          workFlow.RunJSON = dataReader.GetString(10);
        workFlow.Status = dataReader.GetInt32(11);
        workFlowList.Add(workFlow);
      }
      return workFlowList;
    }

    public List<RoadFlow.Data.Model.WorkFlow> GetAll()
    {
      MySqlDataReader dataReader = this.dbHelper.GetDataReader("SELECT * FROM workflow");
      List<RoadFlow.Data.Model.WorkFlow> list = this.DataReaderToList(dataReader);
      dataReader.Close();
      return list;
    }

    public long GetCount()
    {
      long result;
      if (!long.TryParse(this.dbHelper.GetFieldValue("SELECT COUNT(*) FROM workflow"), out result))
        return 0;
      return result;
    }

    public RoadFlow.Data.Model.WorkFlow Get(Guid id)
    {
      string sql = "SELECT * FROM workflow WHERE ID=@ID";
      MySqlParameter[] mySqlParameterArray = new MySqlParameter[1];
      int index = 0;
      MySqlParameter mySqlParameter = new MySqlParameter("@ID", MySqlDbType.VarChar, 36);
      mySqlParameter.Value = (object) id.ToString();
      mySqlParameterArray[index] = mySqlParameter;
      MySqlParameter[] parameter = mySqlParameterArray;
      MySqlDataReader dataReader = this.dbHelper.GetDataReader(sql, parameter);
      List<RoadFlow.Data.Model.WorkFlow> list = this.DataReaderToList(dataReader);
      dataReader.Close();
      if (list.Count <= 0)
        return (RoadFlow.Data.Model.WorkFlow) null;
      return list[0];
    }

    public List<string> GetAllTypes()
    {
      string sql = "SELECT Type FROM WorkFlow GROUP BY Type";
      List<string> stringList = new List<string>();
      MySqlDataReader dataReader = this.dbHelper.GetDataReader(sql);
      while (dataReader.Read())
        stringList.Add(dataReader.GetString(0));
      dataReader.Close();
      return stringList;
    }

    public System.Collections.Generic.Dictionary<Guid, string> GetAllIDAndName()
    {
      string sql = "SELECT ID,Name FROM WorkFlow WHERE Status<4 ORDER BY Name";
      System.Collections.Generic.Dictionary<Guid, string> dictionary = new System.Collections.Generic.Dictionary<Guid, string>();
      MySqlDataReader dataReader = this.dbHelper.GetDataReader(sql);
      while (dataReader.Read())
        dictionary.Add(dataReader.GetGuid(0), dataReader.GetString(1));
      dataReader.Close();
      return dictionary;
    }

    public List<RoadFlow.Data.Model.WorkFlow> GetByTypes(string typeString)
    {
      MySqlDataReader dataReader = this.dbHelper.GetDataReader("SELECT * FROM WorkFlow where Type IN(" + Tools.GetSqlInString(typeString, true, ",") + ")");
      List<RoadFlow.Data.Model.WorkFlow> list = this.DataReaderToList(dataReader);
      dataReader.Close();
      return list;
    }

    public List<RoadFlow.Data.Model.WorkFlow> GetPagerData(out string pager, string query = "", string userid = "", string typeid = "", string name = "", int pagesize = 15)
    {
      StringBuilder stringBuilder = new StringBuilder("AND Status<>4 ");
      List<MySqlParameter> mySqlParameterList1 = new List<MySqlParameter>();
      if (!userid.IsNullOrEmpty())
      {
        stringBuilder.Append("AND INSTR(Manager,@Manager)>0 ");
        List<MySqlParameter> mySqlParameterList2 = mySqlParameterList1;
        MySqlParameter mySqlParameter = new MySqlParameter("@Manager", MySqlDbType.VarChar);
        mySqlParameter.Value = (object) userid;
        mySqlParameterList2.Add(mySqlParameter);
      }
      if (!name.IsNullOrEmpty())
      {
        stringBuilder.Append("AND INSTR(Name,@Name)>0 ");
        List<MySqlParameter> mySqlParameterList2 = mySqlParameterList1;
        MySqlParameter mySqlParameter = new MySqlParameter("@Name", MySqlDbType.VarChar);
        mySqlParameter.Value = (object) name;
        mySqlParameterList2.Add(mySqlParameter);
      }
      if (!typeid.IsNullOrEmpty())
        stringBuilder.Append("AND Type IN (" + Tools.GetSqlInString(typeid, true, ",") + ")");
      int num = pagesize;
      int pageNumber = Tools.GetPageNumber();
      long count;
      string paerSql = this.dbHelper.GetPaerSql(nameof (WorkFlow), "ID,Name,Type,Manager,InstanceManager,CreateDate,CreateUserID,'' DesignJSON,InstallDate,InstallUserID,'' RunJSON,Status", stringBuilder.ToString(), "CreateDate DESC", num, pageNumber, out count, mySqlParameterList1.ToArray());
      pager = Tools.GetPagerHtml(count, num, pageNumber, query);
      MySqlDataReader dataReader = this.dbHelper.GetDataReader(paerSql, mySqlParameterList1.ToArray());
      List<RoadFlow.Data.Model.WorkFlow> list = this.DataReaderToList(dataReader);
      dataReader.Close();
      return list;
    }

    public List<RoadFlow.Data.Model.WorkFlow> GetPagerData(out long count, int pageSize, int pageNumber, string userid = "", string typeid = "", string name = "", string order = "")
    {
      StringBuilder stringBuilder = new StringBuilder("AND Status<>4 ");
      List<MySqlParameter> mySqlParameterList1 = new List<MySqlParameter>();
      if (!userid.IsNullOrEmpty())
      {
        stringBuilder.Append("AND INSTR(Manager,@Manager)>0 ");
        List<MySqlParameter> mySqlParameterList2 = mySqlParameterList1;
        MySqlParameter mySqlParameter = new MySqlParameter("@Manager", MySqlDbType.VarChar);
        mySqlParameter.Value = (object) userid;
        mySqlParameterList2.Add(mySqlParameter);
      }
      if (!name.IsNullOrEmpty())
      {
        stringBuilder.Append("AND INSTR(Name,@Name)>0 ");
        List<MySqlParameter> mySqlParameterList2 = mySqlParameterList1;
        MySqlParameter mySqlParameter = new MySqlParameter("@Name", MySqlDbType.VarChar);
        mySqlParameter.Value = (object) name;
        mySqlParameterList2.Add(mySqlParameter);
      }
      if (!typeid.IsNullOrEmpty())
        stringBuilder.Append("AND Type IN (" + Tools.GetSqlInString(typeid, true, ",") + ")");
      MySqlDataReader dataReader = this.dbHelper.GetDataReader(this.dbHelper.GetPaerSql(nameof (WorkFlow), "ID,Name,Type,Manager,InstanceManager,CreateDate,CreateUserID,'' DesignJSON,InstallDate,InstallUserID,'' RunJSON,Status", stringBuilder.ToString(), order.IsNullOrEmpty() ? "CreateDate DESC" : order, pageSize, pageNumber, out count, mySqlParameterList1.ToArray()), mySqlParameterList1.ToArray());
      List<RoadFlow.Data.Model.WorkFlow> list = this.DataReaderToList(dataReader);
      dataReader.Close();
      return list;
    }
  }
}
