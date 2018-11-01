// Decompiled with JetBrains decompiler
// Type: RoadFlow.Data.MSSQL.WorkFlow
// Assembly: RoadFlow.Data.MSSQL, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 5107CDC7-8F84-4EE0-AC6D-E80FE4695340
// Assembly location: C:\inetpub\wwwroot\RoadFlowMvc\bin\RoadFlow.Data.MSSQL.dll

using RoadFlow.Data.Interface;
using RoadFlow.Utility;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Text;

namespace RoadFlow.Data.MSSQL
{
  public class WorkFlow : IWorkFlow
  {
    private DBHelper dbHelper = new DBHelper();

    public int Add(RoadFlow.Data.Model.WorkFlow model)
    {
      string sql = "INSERT INTO WorkFlow\r\n\t\t\t\t(ID,Name,Type,Manager,InstanceManager,CreateDate,CreateUserID,DesignJSON,InstallDate,InstallUserID,RunJSON,Status) \r\n\t\t\t\tVALUES(@ID,@Name,@Type,@Manager,@InstanceManager,@CreateDate,@CreateUserID,@DesignJSON,@InstallDate,@InstallUserID,@RunJSON,@Status)";
      SqlParameter[] sqlParameterArray = new SqlParameter[12];
      int index1 = 0;
      SqlParameter sqlParameter1 = new SqlParameter("@ID", SqlDbType.UniqueIdentifier, -1);
      sqlParameter1.Value = (object) model.ID;
      sqlParameterArray[index1] = sqlParameter1;
      int index2 = 1;
      SqlParameter sqlParameter2 = new SqlParameter("@Name", SqlDbType.NVarChar, 1000);
      sqlParameter2.Value = (object) model.Name;
      sqlParameterArray[index2] = sqlParameter2;
      int index3 = 2;
      SqlParameter sqlParameter3 = new SqlParameter("@Type", SqlDbType.UniqueIdentifier, -1);
      sqlParameter3.Value = (object) model.Type;
      sqlParameterArray[index3] = sqlParameter3;
      int index4 = 3;
      SqlParameter sqlParameter4 = new SqlParameter("@Manager", SqlDbType.VarChar, 5000);
      sqlParameter4.Value = (object) model.Manager;
      sqlParameterArray[index4] = sqlParameter4;
      int index5 = 4;
      SqlParameter sqlParameter5 = new SqlParameter("@InstanceManager", SqlDbType.VarChar, 5000);
      sqlParameter5.Value = (object) model.InstanceManager;
      sqlParameterArray[index5] = sqlParameter5;
      int index6 = 5;
      SqlParameter sqlParameter6 = new SqlParameter("@CreateDate", SqlDbType.DateTime, 8);
      sqlParameter6.Value = (object) model.CreateDate;
      sqlParameterArray[index6] = sqlParameter6;
      int index7 = 6;
      SqlParameter sqlParameter7 = new SqlParameter("@CreateUserID", SqlDbType.UniqueIdentifier, -1);
      sqlParameter7.Value = (object) model.CreateUserID;
      sqlParameterArray[index7] = sqlParameter7;
      int index8 = 7;
      SqlParameter sqlParameter8;
      if (model.DesignJSON != null)
      {
        SqlParameter sqlParameter9 = new SqlParameter("@DesignJSON", SqlDbType.VarChar, -1);
        sqlParameter9.Value = (object) model.DesignJSON;
        sqlParameter8 = sqlParameter9;
      }
      else
      {
        sqlParameter8 = new SqlParameter("@DesignJSON", SqlDbType.VarChar, -1);
        sqlParameter8.Value = (object) DBNull.Value;
      }
      sqlParameterArray[index8] = sqlParameter8;
      int index9 = 8;
      SqlParameter sqlParameter10;
      if (model.InstallDate.HasValue)
      {
        SqlParameter sqlParameter9 = new SqlParameter("@InstallDate", SqlDbType.DateTime, 8);
        sqlParameter9.Value = (object) model.InstallDate;
        sqlParameter10 = sqlParameter9;
      }
      else
      {
        sqlParameter10 = new SqlParameter("@InstallDate", SqlDbType.DateTime, 8);
        sqlParameter10.Value = (object) DBNull.Value;
      }
      sqlParameterArray[index9] = sqlParameter10;
      int index10 = 9;
      SqlParameter sqlParameter11;
      if (model.InstallUserID.HasValue)
      {
        SqlParameter sqlParameter9 = new SqlParameter("@InstallUserID", SqlDbType.UniqueIdentifier, -1);
        sqlParameter9.Value = (object) model.InstallUserID;
        sqlParameter11 = sqlParameter9;
      }
      else
      {
        sqlParameter11 = new SqlParameter("@InstallUserID", SqlDbType.UniqueIdentifier, -1);
        sqlParameter11.Value = (object) DBNull.Value;
      }
      sqlParameterArray[index10] = sqlParameter11;
      int index11 = 10;
      SqlParameter sqlParameter12;
      if (model.RunJSON != null)
      {
        SqlParameter sqlParameter9 = new SqlParameter("@RunJSON", SqlDbType.VarChar, -1);
        sqlParameter9.Value = (object) model.RunJSON;
        sqlParameter12 = sqlParameter9;
      }
      else
      {
        sqlParameter12 = new SqlParameter("@RunJSON", SqlDbType.VarChar, -1);
        sqlParameter12.Value = (object) DBNull.Value;
      }
      sqlParameterArray[index11] = sqlParameter12;
      int index12 = 11;
      SqlParameter sqlParameter13 = new SqlParameter("@Status", SqlDbType.Int, -1);
      sqlParameter13.Value = (object) model.Status;
      sqlParameterArray[index12] = sqlParameter13;
      SqlParameter[] parameter = sqlParameterArray;
      return this.dbHelper.Execute(sql, parameter, false);
    }

    public int Update(RoadFlow.Data.Model.WorkFlow model)
    {
      string sql = "UPDATE WorkFlow SET \r\n\t\t\t\tName=@Name,Type=@Type,Manager=@Manager,InstanceManager=@InstanceManager,CreateDate=@CreateDate,CreateUserID=@CreateUserID,DesignJSON=@DesignJSON,InstallDate=@InstallDate,InstallUserID=@InstallUserID,RunJSON=@RunJSON,Status=@Status\r\n\t\t\t\tWHERE ID=@ID";
      SqlParameter[] sqlParameterArray = new SqlParameter[12];
      int index1 = 0;
      SqlParameter sqlParameter1 = new SqlParameter("@Name", SqlDbType.NVarChar, 1000);
      sqlParameter1.Value = (object) model.Name;
      sqlParameterArray[index1] = sqlParameter1;
      int index2 = 1;
      SqlParameter sqlParameter2 = new SqlParameter("@Type", SqlDbType.UniqueIdentifier, -1);
      sqlParameter2.Value = (object) model.Type;
      sqlParameterArray[index2] = sqlParameter2;
      int index3 = 2;
      SqlParameter sqlParameter3 = new SqlParameter("@Manager", SqlDbType.VarChar, 5000);
      sqlParameter3.Value = (object) model.Manager;
      sqlParameterArray[index3] = sqlParameter3;
      int index4 = 3;
      SqlParameter sqlParameter4 = new SqlParameter("@InstanceManager", SqlDbType.VarChar, 5000);
      sqlParameter4.Value = (object) model.InstanceManager;
      sqlParameterArray[index4] = sqlParameter4;
      int index5 = 4;
      SqlParameter sqlParameter5 = new SqlParameter("@CreateDate", SqlDbType.DateTime, 8);
      sqlParameter5.Value = (object) model.CreateDate;
      sqlParameterArray[index5] = sqlParameter5;
      int index6 = 5;
      SqlParameter sqlParameter6 = new SqlParameter("@CreateUserID", SqlDbType.UniqueIdentifier, -1);
      sqlParameter6.Value = (object) model.CreateUserID;
      sqlParameterArray[index6] = sqlParameter6;
      int index7 = 6;
      SqlParameter sqlParameter7;
      if (model.DesignJSON != null)
      {
        SqlParameter sqlParameter8 = new SqlParameter("@DesignJSON", SqlDbType.VarChar, -1);
        sqlParameter8.Value = (object) model.DesignJSON;
        sqlParameter7 = sqlParameter8;
      }
      else
      {
        sqlParameter7 = new SqlParameter("@DesignJSON", SqlDbType.VarChar, -1);
        sqlParameter7.Value = (object) DBNull.Value;
      }
      sqlParameterArray[index7] = sqlParameter7;
      int index8 = 7;
      SqlParameter sqlParameter9;
      if (model.InstallDate.HasValue)
      {
        SqlParameter sqlParameter8 = new SqlParameter("@InstallDate", SqlDbType.DateTime, 8);
        sqlParameter8.Value = (object) model.InstallDate;
        sqlParameter9 = sqlParameter8;
      }
      else
      {
        sqlParameter9 = new SqlParameter("@InstallDate", SqlDbType.DateTime, 8);
        sqlParameter9.Value = (object) DBNull.Value;
      }
      sqlParameterArray[index8] = sqlParameter9;
      int index9 = 8;
      SqlParameter sqlParameter10;
      if (model.InstallUserID.HasValue)
      {
        SqlParameter sqlParameter8 = new SqlParameter("@InstallUserID", SqlDbType.UniqueIdentifier, -1);
        sqlParameter8.Value = (object) model.InstallUserID;
        sqlParameter10 = sqlParameter8;
      }
      else
      {
        sqlParameter10 = new SqlParameter("@InstallUserID", SqlDbType.UniqueIdentifier, -1);
        sqlParameter10.Value = (object) DBNull.Value;
      }
      sqlParameterArray[index9] = sqlParameter10;
      int index10 = 9;
      SqlParameter sqlParameter11;
      if (model.RunJSON != null)
      {
        SqlParameter sqlParameter8 = new SqlParameter("@RunJSON", SqlDbType.VarChar, -1);
        sqlParameter8.Value = (object) model.RunJSON;
        sqlParameter11 = sqlParameter8;
      }
      else
      {
        sqlParameter11 = new SqlParameter("@RunJSON", SqlDbType.VarChar, -1);
        sqlParameter11.Value = (object) DBNull.Value;
      }
      sqlParameterArray[index10] = sqlParameter11;
      int index11 = 10;
      SqlParameter sqlParameter12 = new SqlParameter("@Status", SqlDbType.Int, -1);
      sqlParameter12.Value = (object) model.Status;
      sqlParameterArray[index11] = sqlParameter12;
      int index12 = 11;
      SqlParameter sqlParameter13 = new SqlParameter("@ID", SqlDbType.UniqueIdentifier, -1);
      sqlParameter13.Value = (object) model.ID;
      sqlParameterArray[index12] = sqlParameter13;
      SqlParameter[] parameter = sqlParameterArray;
      return this.dbHelper.Execute(sql, parameter, false);
    }

    public int Delete(Guid id)
    {
      string sql = "DELETE FROM WorkFlow WHERE ID=@ID";
      SqlParameter[] sqlParameterArray = new SqlParameter[1];
      int index = 0;
      SqlParameter sqlParameter = new SqlParameter("@ID", SqlDbType.UniqueIdentifier);
      sqlParameter.Value = (object) id;
      sqlParameterArray[index] = sqlParameter;
      SqlParameter[] parameter = sqlParameterArray;
      return this.dbHelper.Execute(sql, parameter, false);
    }

    private List<RoadFlow.Data.Model.WorkFlow> DataReaderToList(SqlDataReader dataReader)
    {
      List<RoadFlow.Data.Model.WorkFlow> workFlowList = new List<RoadFlow.Data.Model.WorkFlow>();
      while (dataReader.Read())
      {
        RoadFlow.Data.Model.WorkFlow workFlow = new RoadFlow.Data.Model.WorkFlow();
        workFlow.ID = dataReader.GetGuid(0);
        workFlow.Name = dataReader.GetString(1);
        workFlow.Type = dataReader.GetGuid(2);
        workFlow.Manager = dataReader.GetString(3);
        workFlow.InstanceManager = dataReader.GetString(4);
        workFlow.CreateDate = dataReader.GetDateTime(5);
        workFlow.CreateUserID = dataReader.GetGuid(6);
        if (!dataReader.IsDBNull(7))
          workFlow.DesignJSON = dataReader.GetString(7);
        if (!dataReader.IsDBNull(8))
          workFlow.InstallDate = new DateTime?(dataReader.GetDateTime(8));
        if (!dataReader.IsDBNull(9))
          workFlow.InstallUserID = new Guid?(dataReader.GetGuid(9));
        if (!dataReader.IsDBNull(10))
          workFlow.RunJSON = dataReader.GetString(10);
        workFlow.Status = dataReader.GetInt32(11);
        workFlowList.Add(workFlow);
      }
      return workFlowList;
    }

    public List<RoadFlow.Data.Model.WorkFlow> GetAll()
    {
      SqlDataReader dataReader = this.dbHelper.GetDataReader("SELECT * FROM WorkFlow");
      List<RoadFlow.Data.Model.WorkFlow> list = this.DataReaderToList(dataReader);
      dataReader.Close();
      return list;
    }

    public long GetCount()
    {
      long result;
      if (!long.TryParse(this.dbHelper.GetFieldValue("SELECT COUNT(*) FROM WorkFlow"), out result))
        return 0;
      return result;
    }

    public RoadFlow.Data.Model.WorkFlow Get(Guid id)
    {
      string sql = "SELECT * FROM WorkFlow WHERE ID=@ID";
      SqlParameter[] sqlParameterArray = new SqlParameter[1];
      int index = 0;
      SqlParameter sqlParameter = new SqlParameter("@ID", SqlDbType.UniqueIdentifier);
      sqlParameter.Value = (object) id;
      sqlParameterArray[index] = sqlParameter;
      SqlParameter[] parameter = sqlParameterArray;
      SqlDataReader dataReader = this.dbHelper.GetDataReader(sql, parameter);
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
      SqlDataReader dataReader = this.dbHelper.GetDataReader(sql);
      while (dataReader.Read())
        stringList.Add(dataReader.GetString(0));
      dataReader.Close();
      return stringList;
    }

    public System.Collections.Generic.Dictionary<Guid, string> GetAllIDAndName()
    {
      string sql = "SELECT ID,Name FROM WorkFlow WHERE Status<4 ORDER BY Name";
      System.Collections.Generic.Dictionary<Guid, string> dictionary = new System.Collections.Generic.Dictionary<Guid, string>();
      SqlDataReader dataReader = this.dbHelper.GetDataReader(sql);
      while (dataReader.Read())
        dictionary.Add(dataReader.GetGuid(0), dataReader.GetString(1));
      dataReader.Close();
      return dictionary;
    }

    public List<RoadFlow.Data.Model.WorkFlow> GetByTypes(string typeString)
    {
      SqlDataReader dataReader = this.dbHelper.GetDataReader("SELECT * FROM WorkFlow where Type IN(" + Tools.GetSqlInString(typeString, true, ",") + ")");
      List<RoadFlow.Data.Model.WorkFlow> list = this.DataReaderToList(dataReader);
      dataReader.Close();
      return list;
    }

    public List<RoadFlow.Data.Model.WorkFlow> GetPagerData(out string pager, string query = "", string userid = "", string typeid = "", string name = "", int pagesize = 15)
    {
      StringBuilder stringBuilder = new StringBuilder("AND Status<>4 ");
      List<SqlParameter> sqlParameterList1 = new List<SqlParameter>();
      if (!userid.IsNullOrEmpty())
      {
        stringBuilder.Append("AND CHARINDEX(@Manager,Manager)>0 ");
        List<SqlParameter> sqlParameterList2 = sqlParameterList1;
        SqlParameter sqlParameter = new SqlParameter("@Manager", SqlDbType.VarChar);
        sqlParameter.Value = (object) userid;
        sqlParameterList2.Add(sqlParameter);
      }
      if (!name.IsNullOrEmpty())
      {
        stringBuilder.Append("AND CHARINDEX(@Name,Name)>0 ");
        List<SqlParameter> sqlParameterList2 = sqlParameterList1;
        SqlParameter sqlParameter = new SqlParameter("@Name", SqlDbType.VarChar);
        sqlParameter.Value = (object) name;
        sqlParameterList2.Add(sqlParameter);
      }
      if (!typeid.IsNullOrEmpty())
        stringBuilder.Append("AND Type IN (" + Tools.GetSqlInString(typeid, true, ",") + ")");
      int num = pagesize;
      int pageNumber = Tools.GetPageNumber();
      long count;
      string paerSql = this.dbHelper.GetPaerSql(nameof (WorkFlow), "ID,Name,Type,Manager,InstanceManager,CreateDate,CreateUserID,'' DesignJSON,InstallDate,InstallUserID,'' RunJSON,Status", stringBuilder.ToString(), "CreateDate DESC", num, pageNumber, out count, sqlParameterList1.ToArray());
      pager = Tools.GetPagerHtml(count, num, pageNumber, query);
      SqlDataReader dataReader = this.dbHelper.GetDataReader(paerSql, sqlParameterList1.ToArray());
      List<RoadFlow.Data.Model.WorkFlow> list = this.DataReaderToList(dataReader);
      dataReader.Close();
      return list;
    }

    public List<RoadFlow.Data.Model.WorkFlow> GetPagerData(out long count, int pageSize, int pageNumber, string userid = "", string typeid = "", string name = "", string order = "")
    {
      StringBuilder stringBuilder = new StringBuilder("AND Status<>4 ");
      List<SqlParameter> sqlParameterList1 = new List<SqlParameter>();
      if (!userid.IsNullOrEmpty())
      {
        stringBuilder.Append("AND CHARINDEX(@Manager,Manager)>0 ");
        List<SqlParameter> sqlParameterList2 = sqlParameterList1;
        SqlParameter sqlParameter = new SqlParameter("@Manager", SqlDbType.VarChar);
        sqlParameter.Value = (object) userid;
        sqlParameterList2.Add(sqlParameter);
      }
      if (!name.IsNullOrEmpty())
      {
        stringBuilder.Append("AND CHARINDEX(@Name,Name)>0 ");
        List<SqlParameter> sqlParameterList2 = sqlParameterList1;
        SqlParameter sqlParameter = new SqlParameter("@Name", SqlDbType.VarChar);
        sqlParameter.Value = (object) name;
        sqlParameterList2.Add(sqlParameter);
      }
      if (!typeid.IsNullOrEmpty())
        stringBuilder.Append("AND Type IN (" + Tools.GetSqlInString(typeid, true, ",") + ")");
      SqlDataReader dataReader = this.dbHelper.GetDataReader(this.dbHelper.GetPaerSql(nameof (WorkFlow), "ID,Name,Type,Manager,InstanceManager,CreateDate,CreateUserID,'' DesignJSON,InstallDate,InstallUserID,'' RunJSON,Status", stringBuilder.ToString(), order.IsNullOrEmpty() ? "CreateDate DESC" : order, pageSize, pageNumber, out count, sqlParameterList1.ToArray()), sqlParameterList1.ToArray());
      List<RoadFlow.Data.Model.WorkFlow> list = this.DataReaderToList(dataReader);
      dataReader.Close();
      return list;
    }
  }
}
