// Decompiled with JetBrains decompiler
// Type: RoadFlow.Data.ORACLE.WorkFlow
// Assembly: RoadFlow.Data.ORACLE, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: C9018AA1-E48E-4231-92A9-CD6F0F275D11
// Assembly location: C:\inetpub\wwwroot\RoadFlowMvc\bin\RoadFlow.Data.ORACLE.dll

using Oracle.ManagedDataAccess.Client;
using RoadFlow.Data.Interface;
using RoadFlow.Utility;
using System;
using System.Collections.Generic;
using System.Text;

namespace RoadFlow.Data.ORACLE
{
  public class WorkFlow : IWorkFlow
  {
    private DBHelper dbHelper = new DBHelper();

    public int Add(RoadFlow.Data.Model.WorkFlow model)
    {
      string sql = "INSERT INTO WorkFlow\r\n\t\t\t\t(ID,Name,Type,Manager,InstanceManager,CreateDate,CreateUserID,DesignJSON,InstallDate,InstallUserID,RunJSON,Status) \r\n\t\t\t\tVALUES(:ID,:Name,:Type,:Manager,:InstanceManager,:CreateDate,:CreateUserID,:DesignJSON,:InstallDate,:InstallUserID,:RunJSON,:Status)";
      OracleParameter[] oracleParameterArray = new OracleParameter[12];
      int index1 = 0;
      OracleParameter oracleParameter1 = new OracleParameter(":ID", OracleDbType.Varchar2, 40);
      oracleParameter1.Value = (object) model.ID;
      oracleParameterArray[index1] = oracleParameter1;
      int index2 = 1;
      OracleParameter oracleParameter2 = new OracleParameter(":Name", OracleDbType.NVarchar2, 1000);
      oracleParameter2.Value = (object) model.Name;
      oracleParameterArray[index2] = oracleParameter2;
      int index3 = 2;
      OracleParameter oracleParameter3 = new OracleParameter(":Type", OracleDbType.Varchar2, 40);
      oracleParameter3.Value = (object) model.Type;
      oracleParameterArray[index3] = oracleParameter3;
      int index4 = 3;
      OracleParameter oracleParameter4 = new OracleParameter(":Manager", OracleDbType.Varchar2, 5000);
      oracleParameter4.Value = (object) model.Manager;
      oracleParameterArray[index4] = oracleParameter4;
      int index5 = 4;
      OracleParameter oracleParameter5 = new OracleParameter(":InstanceManager", OracleDbType.Varchar2, 5000);
      oracleParameter5.Value = (object) model.InstanceManager;
      oracleParameterArray[index5] = oracleParameter5;
      int index6 = 5;
      OracleParameter oracleParameter6 = new OracleParameter(":CreateDate", OracleDbType.Date, 8);
      oracleParameter6.Value = (object) model.CreateDate;
      oracleParameterArray[index6] = oracleParameter6;
      int index7 = 6;
      OracleParameter oracleParameter7 = new OracleParameter(":CreateUserID", OracleDbType.Varchar2, 40);
      oracleParameter7.Value = (object) model.CreateUserID;
      oracleParameterArray[index7] = oracleParameter7;
      int index8 = 7;
      OracleParameter oracleParameter8;
      if (model.DesignJSON != null)
      {
        OracleParameter oracleParameter9 = new OracleParameter(":DesignJSON", OracleDbType.Clob);
        oracleParameter9.Value = (object) model.DesignJSON;
        oracleParameter8 = oracleParameter9;
      }
      else
      {
        oracleParameter8 = new OracleParameter(":DesignJSON", OracleDbType.Clob);
        oracleParameter8.Value = (object) DBNull.Value;
      }
      oracleParameterArray[index8] = oracleParameter8;
      int index9 = 8;
      OracleParameter oracleParameter10;
      if (model.InstallDate.HasValue)
      {
        OracleParameter oracleParameter9 = new OracleParameter(":InstallDate", OracleDbType.Date, 8);
        oracleParameter9.Value = (object) model.InstallDate;
        oracleParameter10 = oracleParameter9;
      }
      else
      {
        oracleParameter10 = new OracleParameter(":InstallDate", OracleDbType.Date, 8);
        oracleParameter10.Value = (object) DBNull.Value;
      }
      oracleParameterArray[index9] = oracleParameter10;
      int index10 = 9;
      OracleParameter oracleParameter11;
      if (model.InstallUserID.HasValue)
      {
        OracleParameter oracleParameter9 = new OracleParameter(":InstallUserID", OracleDbType.Varchar2, 40);
        oracleParameter9.Value = (object) model.InstallUserID;
        oracleParameter11 = oracleParameter9;
      }
      else
      {
        oracleParameter11 = new OracleParameter(":InstallUserID", OracleDbType.Varchar2, 40);
        oracleParameter11.Value = (object) DBNull.Value;
      }
      oracleParameterArray[index10] = oracleParameter11;
      int index11 = 10;
      OracleParameter oracleParameter12;
      if (model.RunJSON != null)
      {
        OracleParameter oracleParameter9 = new OracleParameter(":RunJSON", OracleDbType.Clob);
        oracleParameter9.Value = (object) model.RunJSON;
        oracleParameter12 = oracleParameter9;
      }
      else
      {
        oracleParameter12 = new OracleParameter(":RunJSON", OracleDbType.Clob);
        oracleParameter12.Value = (object) DBNull.Value;
      }
      oracleParameterArray[index11] = oracleParameter12;
      int index12 = 11;
      OracleParameter oracleParameter13 = new OracleParameter(":Status", OracleDbType.Int32);
      oracleParameter13.Value = (object) model.Status;
      oracleParameterArray[index12] = oracleParameter13;
      OracleParameter[] parameter = oracleParameterArray;
      return this.dbHelper.Execute(sql, parameter);
    }

    public int Update(RoadFlow.Data.Model.WorkFlow model)
    {
      string sql = "UPDATE WorkFlow SET \r\n\t\t\t\tName=:Name,Type=:Type,Manager=:Manager,InstanceManager=:InstanceManager,CreateDate=:CreateDate,CreateUserID=:CreateUserID,DesignJSON=:DesignJSON,InstallDate=:InstallDate,InstallUserID=:InstallUserID,RunJSON=:RunJSON,Status=:Status\r\n\t\t\t\tWHERE ID=:ID";
      OracleParameter[] oracleParameterArray = new OracleParameter[12];
      int index1 = 0;
      OracleParameter oracleParameter1 = new OracleParameter(":Name", OracleDbType.NVarchar2, 1000);
      oracleParameter1.Value = (object) model.Name;
      oracleParameterArray[index1] = oracleParameter1;
      int index2 = 1;
      OracleParameter oracleParameter2 = new OracleParameter(":Type", OracleDbType.Varchar2, 40);
      oracleParameter2.Value = (object) model.Type;
      oracleParameterArray[index2] = oracleParameter2;
      int index3 = 2;
      OracleParameter oracleParameter3 = new OracleParameter(":Manager", OracleDbType.Varchar2, 5000);
      oracleParameter3.Value = (object) model.Manager;
      oracleParameterArray[index3] = oracleParameter3;
      int index4 = 3;
      OracleParameter oracleParameter4 = new OracleParameter(":InstanceManager", OracleDbType.Varchar2, 5000);
      oracleParameter4.Value = (object) model.InstanceManager;
      oracleParameterArray[index4] = oracleParameter4;
      int index5 = 4;
      OracleParameter oracleParameter5 = new OracleParameter(":CreateDate", OracleDbType.Date, 8);
      oracleParameter5.Value = (object) model.CreateDate;
      oracleParameterArray[index5] = oracleParameter5;
      int index6 = 5;
      OracleParameter oracleParameter6 = new OracleParameter(":CreateUserID", OracleDbType.Varchar2, 40);
      oracleParameter6.Value = (object) model.CreateUserID;
      oracleParameterArray[index6] = oracleParameter6;
      int index7 = 6;
      OracleParameter oracleParameter7;
      if (model.DesignJSON != null)
      {
        OracleParameter oracleParameter8 = new OracleParameter(":DesignJSON", OracleDbType.Clob);
        oracleParameter8.Value = (object) model.DesignJSON;
        oracleParameter7 = oracleParameter8;
      }
      else
      {
        oracleParameter7 = new OracleParameter(":DesignJSON", OracleDbType.Clob);
        oracleParameter7.Value = (object) DBNull.Value;
      }
      oracleParameterArray[index7] = oracleParameter7;
      int index8 = 7;
      OracleParameter oracleParameter9;
      if (model.InstallDate.HasValue)
      {
        OracleParameter oracleParameter8 = new OracleParameter(":InstallDate", OracleDbType.Date, 8);
        oracleParameter8.Value = (object) model.InstallDate;
        oracleParameter9 = oracleParameter8;
      }
      else
      {
        oracleParameter9 = new OracleParameter(":InstallDate", OracleDbType.Date, 8);
        oracleParameter9.Value = (object) DBNull.Value;
      }
      oracleParameterArray[index8] = oracleParameter9;
      int index9 = 8;
      OracleParameter oracleParameter10;
      if (model.InstallUserID.HasValue)
      {
        OracleParameter oracleParameter8 = new OracleParameter(":InstallUserID", OracleDbType.Varchar2, 40);
        oracleParameter8.Value = (object) model.InstallUserID;
        oracleParameter10 = oracleParameter8;
      }
      else
      {
        oracleParameter10 = new OracleParameter(":InstallUserID", OracleDbType.Varchar2, 40);
        oracleParameter10.Value = (object) DBNull.Value;
      }
      oracleParameterArray[index9] = oracleParameter10;
      int index10 = 9;
      OracleParameter oracleParameter11;
      if (model.RunJSON != null)
      {
        OracleParameter oracleParameter8 = new OracleParameter(":RunJSON", OracleDbType.Clob);
        oracleParameter8.Value = (object) model.RunJSON;
        oracleParameter11 = oracleParameter8;
      }
      else
      {
        oracleParameter11 = new OracleParameter(":RunJSON", OracleDbType.Clob);
        oracleParameter11.Value = (object) DBNull.Value;
      }
      oracleParameterArray[index10] = oracleParameter11;
      int index11 = 10;
      OracleParameter oracleParameter12 = new OracleParameter(":Status", OracleDbType.Int32);
      oracleParameter12.Value = (object) model.Status;
      oracleParameterArray[index11] = oracleParameter12;
      int index12 = 11;
      OracleParameter oracleParameter13 = new OracleParameter(":ID", OracleDbType.Varchar2, 40);
      oracleParameter13.Value = (object) model.ID;
      oracleParameterArray[index12] = oracleParameter13;
      OracleParameter[] parameter = oracleParameterArray;
      return this.dbHelper.Execute(sql, parameter);
    }

    public int Delete(Guid id)
    {
      string sql = "DELETE FROM WorkFlow WHERE ID=:ID";
      OracleParameter[] oracleParameterArray = new OracleParameter[1];
      int index = 0;
      OracleParameter oracleParameter = new OracleParameter(":ID", OracleDbType.Varchar2);
      oracleParameter.Value = (object) id;
      oracleParameterArray[index] = oracleParameter;
      OracleParameter[] parameter = oracleParameterArray;
      return this.dbHelper.Execute(sql, parameter);
    }

    private List<RoadFlow.Data.Model.WorkFlow> DataReaderToList(OracleDataReader dataReader)
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
      OracleDataReader dataReader = this.dbHelper.GetDataReader("SELECT * FROM WorkFlow");
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
      string sql = "SELECT * FROM WorkFlow WHERE ID=:ID";
      OracleParameter[] oracleParameterArray = new OracleParameter[1];
      int index = 0;
      OracleParameter oracleParameter = new OracleParameter(":ID", OracleDbType.Varchar2);
      oracleParameter.Value = (object) id;
      oracleParameterArray[index] = oracleParameter;
      OracleParameter[] parameter = oracleParameterArray;
      OracleDataReader dataReader = this.dbHelper.GetDataReader(sql, parameter);
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
      OracleDataReader dataReader = this.dbHelper.GetDataReader(sql);
      while (dataReader.Read())
        stringList.Add(dataReader.GetString(0));
      dataReader.Close();
      return stringList;
    }

    public System.Collections.Generic.Dictionary<Guid, string> GetAllIDAndName()
    {
      string sql = "SELECT ID,Name FROM WorkFlow WHERE Status<4 ORDER BY Name";
      System.Collections.Generic.Dictionary<Guid, string> dictionary = new System.Collections.Generic.Dictionary<Guid, string>();
      OracleDataReader dataReader = this.dbHelper.GetDataReader(sql);
      while (dataReader.Read())
        dictionary.Add(dataReader.GetString(0).ToGuid(), dataReader.GetString(1));
      dataReader.Close();
      return dictionary;
    }

    public List<RoadFlow.Data.Model.WorkFlow> GetByTypes(string typeString)
    {
      OracleDataReader dataReader = this.dbHelper.GetDataReader("SELECT * FROM WorkFlow where Type IN(" + Tools.GetSqlInString(typeString, true, ",") + ")");
      List<RoadFlow.Data.Model.WorkFlow> list = this.DataReaderToList(dataReader);
      dataReader.Close();
      return list;
    }

    public List<RoadFlow.Data.Model.WorkFlow> GetPagerData(out string pager, string query = "", string userid = "", string typeid = "", string name = "", int pagesize = 15)
    {
      StringBuilder stringBuilder = new StringBuilder("AND Status!=4 ");
      List<OracleParameter> oracleParameterList1 = new List<OracleParameter>();
      if (!userid.IsNullOrEmpty())
      {
        stringBuilder.Append("AND INSTR(Manager,:Manager,1,1)>0 ");
        List<OracleParameter> oracleParameterList2 = oracleParameterList1;
        OracleParameter oracleParameter = new OracleParameter(":Manager", OracleDbType.Varchar2);
        oracleParameter.Value = (object) userid;
        oracleParameterList2.Add(oracleParameter);
      }
      if (!name.IsNullOrEmpty())
      {
        stringBuilder.Append("AND INSTR(Name,:Name,1,1)>0 ");
        List<OracleParameter> oracleParameterList2 = oracleParameterList1;
        OracleParameter oracleParameter = new OracleParameter(":Name", OracleDbType.Varchar2);
        oracleParameter.Value = (object) name;
        oracleParameterList2.Add(oracleParameter);
      }
      if (!typeid.IsNullOrEmpty())
        stringBuilder.Append("AND Type IN (" + Tools.GetSqlInString(typeid, true, ",") + ")");
      int num = pagesize;
      int pageNumber = Tools.GetPageNumber();
      long count;
      string paerSql = this.dbHelper.GetPaerSql(nameof (WorkFlow), "ID,Name,Type,Manager,InstanceManager,CreateDate,CreateUserID,'' DesignJSON,InstallDate,InstallUserID,'' RunJSON,Status", stringBuilder.ToString(), "CreateDate DESC", num, pageNumber, out count, oracleParameterList1.ToArray());
      pager = Tools.GetPagerHtml(count, num, pageNumber, query);
      OracleDataReader dataReader = this.dbHelper.GetDataReader(paerSql, oracleParameterList1.ToArray());
      List<RoadFlow.Data.Model.WorkFlow> list = this.DataReaderToList(dataReader);
      dataReader.Close();
      return list;
    }

    public List<RoadFlow.Data.Model.WorkFlow> GetPagerData(out long count, int pageSize, int pageNumber, string userid = "", string typeid = "", string name = "", string order = "")
    {
      StringBuilder stringBuilder = new StringBuilder("AND Status!=4 ");
      List<OracleParameter> oracleParameterList1 = new List<OracleParameter>();
      if (!userid.IsNullOrEmpty())
      {
        stringBuilder.Append("AND INSTR(Manager,:Manager,1,1)>0 ");
        List<OracleParameter> oracleParameterList2 = oracleParameterList1;
        OracleParameter oracleParameter = new OracleParameter(":Manager", OracleDbType.Varchar2);
        oracleParameter.Value = (object) userid;
        oracleParameterList2.Add(oracleParameter);
      }
      if (!name.IsNullOrEmpty())
      {
        stringBuilder.Append("AND INSTR(Name,:Name,1,1)>0 ");
        List<OracleParameter> oracleParameterList2 = oracleParameterList1;
        OracleParameter oracleParameter = new OracleParameter(":Name", OracleDbType.Varchar2);
        oracleParameter.Value = (object) name;
        oracleParameterList2.Add(oracleParameter);
      }
      if (!typeid.IsNullOrEmpty())
        stringBuilder.Append("AND Type IN (" + Tools.GetSqlInString(typeid, true, ",") + ")");
      OracleDataReader dataReader = this.dbHelper.GetDataReader(this.dbHelper.GetPaerSql(nameof (WorkFlow), "ID,Name,Type,Manager,InstanceManager,CreateDate,CreateUserID,'' DesignJSON,InstallDate,InstallUserID,'' RunJSON,Status", stringBuilder.ToString(), order.IsNullOrEmpty() ? "CreateDate DESC" : order, pageSize, pageNumber, out count, oracleParameterList1.ToArray()), oracleParameterList1.ToArray());
      List<RoadFlow.Data.Model.WorkFlow> list = this.DataReaderToList(dataReader);
      dataReader.Close();
      return list;
    }
  }
}
