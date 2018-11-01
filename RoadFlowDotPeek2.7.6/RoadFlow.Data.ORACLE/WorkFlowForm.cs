// Decompiled with JetBrains decompiler
// Type: RoadFlow.Data.ORACLE.WorkFlowForm
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
  public class WorkFlowForm : IWorkFlowForm
  {
    private DBHelper dbHelper = new DBHelper();

    public int Add(RoadFlow.Data.Model.WorkFlowForm model)
    {
      string sql = "INSERT INTO WorkFlowForm\r\n\t\t\t\t(ID,Name,Type,CreateUserID,CreateUserName,CreateTime,LastModifyTime,Html,SubTableJson,EventsJson,Attribute,Status) \r\n\t\t\t\tVALUES(:ID,:Name,:Type,:CreateUserID,:CreateUserName,:CreateTime,:LastModifyTime,:Html,:SubTableJson,:EventsJson,:Attribute,:Status)";
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
      OracleParameter oracleParameter4 = new OracleParameter(":CreateUserID", OracleDbType.Varchar2, 40);
      oracleParameter4.Value = (object) model.CreateUserID;
      oracleParameterArray[index4] = oracleParameter4;
      int index5 = 4;
      OracleParameter oracleParameter5 = new OracleParameter(":CreateUserName", OracleDbType.NVarchar2, 100);
      oracleParameter5.Value = (object) model.CreateUserName;
      oracleParameterArray[index5] = oracleParameter5;
      int index6 = 5;
      OracleParameter oracleParameter6 = new OracleParameter(":CreateTime", OracleDbType.Date, 8);
      oracleParameter6.Value = (object) model.CreateTime;
      oracleParameterArray[index6] = oracleParameter6;
      int index7 = 6;
      OracleParameter oracleParameter7 = new OracleParameter(":LastModifyTime", OracleDbType.Date, 8);
      oracleParameter7.Value = (object) model.LastModifyTime;
      oracleParameterArray[index7] = oracleParameter7;
      int index8 = 7;
      OracleParameter oracleParameter8;
      if (model.Html != null)
      {
        OracleParameter oracleParameter9 = new OracleParameter(":Html", OracleDbType.Clob);
        oracleParameter9.Value = (object) model.Html;
        oracleParameter8 = oracleParameter9;
      }
      else
      {
        oracleParameter8 = new OracleParameter(":Html", OracleDbType.Clob);
        oracleParameter8.Value = (object) DBNull.Value;
      }
      oracleParameterArray[index8] = oracleParameter8;
      int index9 = 8;
      OracleParameter oracleParameter10;
      if (model.SubTableJson != null)
      {
        OracleParameter oracleParameter9 = new OracleParameter(":SubTableJson", OracleDbType.Clob);
        oracleParameter9.Value = (object) model.SubTableJson;
        oracleParameter10 = oracleParameter9;
      }
      else
      {
        oracleParameter10 = new OracleParameter(":SubTableJson", OracleDbType.Clob);
        oracleParameter10.Value = (object) DBNull.Value;
      }
      oracleParameterArray[index9] = oracleParameter10;
      int index10 = 9;
      OracleParameter oracleParameter11;
      if (model.EventsJson != null)
      {
        OracleParameter oracleParameter9 = new OracleParameter(":EventsJson", OracleDbType.Clob);
        oracleParameter9.Value = (object) model.EventsJson;
        oracleParameter11 = oracleParameter9;
      }
      else
      {
        oracleParameter11 = new OracleParameter(":EventsJson", OracleDbType.Clob);
        oracleParameter11.Value = (object) DBNull.Value;
      }
      oracleParameterArray[index10] = oracleParameter11;
      int index11 = 10;
      OracleParameter oracleParameter12;
      if (model.Attribute != null)
      {
        OracleParameter oracleParameter9 = new OracleParameter(":Attribute", OracleDbType.Clob);
        oracleParameter9.Value = (object) model.Attribute;
        oracleParameter12 = oracleParameter9;
      }
      else
      {
        oracleParameter12 = new OracleParameter(":Attribute", OracleDbType.Clob);
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

    public int Update(RoadFlow.Data.Model.WorkFlowForm model)
    {
      string sql = "UPDATE WorkFlowForm SET \r\n\t\t\t\tName=:Name,Type=:Type,CreateUserID=:CreateUserID,CreateUserName=:CreateUserName,CreateTime=:CreateTime,LastModifyTime=:LastModifyTime,Html=:Html,SubTableJson=:SubTableJson,EventsJson=:EventsJson,Attribute=:Attribute,Status=:Status\r\n\t\t\t\tWHERE ID=:ID";
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
      OracleParameter oracleParameter3 = new OracleParameter(":CreateUserID", OracleDbType.Varchar2, 40);
      oracleParameter3.Value = (object) model.CreateUserID;
      oracleParameterArray[index3] = oracleParameter3;
      int index4 = 3;
      OracleParameter oracleParameter4 = new OracleParameter(":CreateUserName", OracleDbType.NVarchar2, 100);
      oracleParameter4.Value = (object) model.CreateUserName;
      oracleParameterArray[index4] = oracleParameter4;
      int index5 = 4;
      OracleParameter oracleParameter5 = new OracleParameter(":CreateTime", OracleDbType.Date, 8);
      oracleParameter5.Value = (object) model.CreateTime;
      oracleParameterArray[index5] = oracleParameter5;
      int index6 = 5;
      OracleParameter oracleParameter6 = new OracleParameter(":LastModifyTime", OracleDbType.Date, 8);
      oracleParameter6.Value = (object) model.LastModifyTime;
      oracleParameterArray[index6] = oracleParameter6;
      int index7 = 6;
      OracleParameter oracleParameter7;
      if (model.Html != null)
      {
        OracleParameter oracleParameter8 = new OracleParameter(":Html", OracleDbType.Clob);
        oracleParameter8.Value = (object) model.Html;
        oracleParameter7 = oracleParameter8;
      }
      else
      {
        oracleParameter7 = new OracleParameter(":Html", OracleDbType.Clob);
        oracleParameter7.Value = (object) DBNull.Value;
      }
      oracleParameterArray[index7] = oracleParameter7;
      int index8 = 7;
      OracleParameter oracleParameter9;
      if (model.SubTableJson != null)
      {
        OracleParameter oracleParameter8 = new OracleParameter(":SubTableJson", OracleDbType.Clob);
        oracleParameter8.Value = (object) model.SubTableJson;
        oracleParameter9 = oracleParameter8;
      }
      else
      {
        oracleParameter9 = new OracleParameter(":SubTableJson", OracleDbType.Clob);
        oracleParameter9.Value = (object) DBNull.Value;
      }
      oracleParameterArray[index8] = oracleParameter9;
      int index9 = 8;
      OracleParameter oracleParameter10;
      if (model.EventsJson != null)
      {
        OracleParameter oracleParameter8 = new OracleParameter(":EventsJson", OracleDbType.Clob);
        oracleParameter8.Value = (object) model.EventsJson;
        oracleParameter10 = oracleParameter8;
      }
      else
      {
        oracleParameter10 = new OracleParameter(":EventsJson", OracleDbType.Clob);
        oracleParameter10.Value = (object) DBNull.Value;
      }
      oracleParameterArray[index9] = oracleParameter10;
      int index10 = 9;
      OracleParameter oracleParameter11;
      if (model.Attribute != null)
      {
        OracleParameter oracleParameter8 = new OracleParameter(":Attribute", OracleDbType.Clob);
        oracleParameter8.Value = (object) model.Attribute;
        oracleParameter11 = oracleParameter8;
      }
      else
      {
        oracleParameter11 = new OracleParameter(":Attribute", OracleDbType.Clob);
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
      string sql = "DELETE FROM WorkFlowForm WHERE ID=:ID";
      OracleParameter[] oracleParameterArray = new OracleParameter[1];
      int index = 0;
      OracleParameter oracleParameter = new OracleParameter(":ID", OracleDbType.Varchar2);
      oracleParameter.Value = (object) id;
      oracleParameterArray[index] = oracleParameter;
      OracleParameter[] parameter = oracleParameterArray;
      return this.dbHelper.Execute(sql, parameter);
    }

    private List<RoadFlow.Data.Model.WorkFlowForm> DataReaderToList(OracleDataReader dataReader)
    {
      List<RoadFlow.Data.Model.WorkFlowForm> workFlowFormList = new List<RoadFlow.Data.Model.WorkFlowForm>();
      while (dataReader.Read())
      {
        RoadFlow.Data.Model.WorkFlowForm workFlowForm = new RoadFlow.Data.Model.WorkFlowForm();
        workFlowForm.ID = dataReader.GetString(0).ToGuid();
        workFlowForm.Name = dataReader.GetString(1);
        workFlowForm.Type = dataReader.GetString(2).ToGuid();
        workFlowForm.CreateUserID = dataReader.GetString(3).ToGuid();
        workFlowForm.CreateUserName = dataReader.GetString(4);
        workFlowForm.CreateTime = dataReader.GetDateTime(5);
        workFlowForm.LastModifyTime = dataReader.GetDateTime(6);
        if (!dataReader.IsDBNull(7))
          workFlowForm.Html = dataReader.GetString(7);
        if (!dataReader.IsDBNull(8))
          workFlowForm.SubTableJson = dataReader.GetString(8);
        if (!dataReader.IsDBNull(9))
          workFlowForm.EventsJson = dataReader.GetString(9);
        if (!dataReader.IsDBNull(10))
          workFlowForm.Attribute = dataReader.GetString(10);
        workFlowForm.Status = dataReader.GetInt32(11);
        workFlowFormList.Add(workFlowForm);
      }
      return workFlowFormList;
    }

    public List<RoadFlow.Data.Model.WorkFlowForm> GetAll()
    {
      OracleDataReader dataReader = this.dbHelper.GetDataReader("SELECT * FROM WorkFlowForm");
      List<RoadFlow.Data.Model.WorkFlowForm> list = this.DataReaderToList(dataReader);
      dataReader.Close();
      return list;
    }

    public long GetCount()
    {
      long result;
      if (!long.TryParse(this.dbHelper.GetFieldValue("SELECT COUNT(*) FROM WorkFlowForm"), out result))
        return 0;
      return result;
    }

    public RoadFlow.Data.Model.WorkFlowForm Get(Guid id)
    {
      string sql = "SELECT * FROM WorkFlowForm WHERE ID=:ID";
      OracleParameter[] oracleParameterArray = new OracleParameter[1];
      int index = 0;
      OracleParameter oracleParameter = new OracleParameter(":ID", OracleDbType.Varchar2);
      oracleParameter.Value = (object) id;
      oracleParameterArray[index] = oracleParameter;
      OracleParameter[] parameter = oracleParameterArray;
      OracleDataReader dataReader = this.dbHelper.GetDataReader(sql, parameter);
      List<RoadFlow.Data.Model.WorkFlowForm> list = this.DataReaderToList(dataReader);
      dataReader.Close();
      if (list.Count <= 0)
        return (RoadFlow.Data.Model.WorkFlowForm) null;
      return list[0];
    }

    public List<RoadFlow.Data.Model.WorkFlowForm> GetAllByType(string types)
    {
      OracleDataReader dataReader = this.dbHelper.GetDataReader("SELECT * FROM WorkFlowForm where Type IN(" + Tools.GetSqlInString(types, true, ",") + ")");
      List<RoadFlow.Data.Model.WorkFlowForm> list = this.DataReaderToList(dataReader);
      dataReader.Close();
      return list;
    }

    public List<RoadFlow.Data.Model.WorkFlowForm> GetPagerData(out string pager, string query = "", string userid = "", string typeid = "", string name = "", int pagesize = 15)
    {
      StringBuilder stringBuilder = new StringBuilder("AND Status IN(0,1) ");
      List<OracleParameter> oracleParameterList1 = new List<OracleParameter>();
      if (!userid.IsNullOrEmpty())
      {
        stringBuilder.Append("AND CreateUserID=:CreateUserID ");
        List<OracleParameter> oracleParameterList2 = oracleParameterList1;
        OracleParameter oracleParameter = new OracleParameter(":CreateUserID", OracleDbType.Varchar2);
        oracleParameter.Value = (object) userid;
        oracleParameterList2.Add(oracleParameter);
      }
      if (!name.IsNullOrEmpty())
      {
        stringBuilder.Append("AND CHARINDEX(:Name,Name)>0 ");
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
      string paerSql = this.dbHelper.GetPaerSql(nameof (WorkFlowForm), "ID,Name,Type,CreateUserID,CreateUserName,CreateTime,LastModifyTime,'' Html,'' SubTableJson,'' EventsJson,'' Attribute,Status", stringBuilder.ToString(), "CreateTime DESC", num, pageNumber, out count, oracleParameterList1.ToArray());
      pager = Tools.GetPagerHtml(count, num, pageNumber, query);
      OracleDataReader dataReader = this.dbHelper.GetDataReader(paerSql, oracleParameterList1.ToArray());
      List<RoadFlow.Data.Model.WorkFlowForm> list = this.DataReaderToList(dataReader);
      dataReader.Close();
      return list;
    }

    public List<RoadFlow.Data.Model.WorkFlowForm> GetPagerData(out long count, int pageSize, int pageNumber, string userid = "", string typeid = "", string name = "", string order = "")
    {
      StringBuilder stringBuilder = new StringBuilder("AND Status IN(0,1) ");
      List<OracleParameter> oracleParameterList1 = new List<OracleParameter>();
      if (!userid.IsNullOrEmpty())
      {
        stringBuilder.Append("AND CreateUserID=:CreateUserID ");
        List<OracleParameter> oracleParameterList2 = oracleParameterList1;
        OracleParameter oracleParameter = new OracleParameter(":CreateUserID", OracleDbType.Varchar2);
        oracleParameter.Value = (object) userid;
        oracleParameterList2.Add(oracleParameter);
      }
      if (!name.IsNullOrEmpty())
      {
        stringBuilder.Append("AND CHARINDEX(:Name,Name)>0 ");
        List<OracleParameter> oracleParameterList2 = oracleParameterList1;
        OracleParameter oracleParameter = new OracleParameter(":Name", OracleDbType.Varchar2);
        oracleParameter.Value = (object) name;
        oracleParameterList2.Add(oracleParameter);
      }
      if (!typeid.IsNullOrEmpty())
        stringBuilder.Append("AND Type IN (" + Tools.GetSqlInString(typeid, true, ",") + ")");
      OracleDataReader dataReader = this.dbHelper.GetDataReader(this.dbHelper.GetPaerSql(nameof (WorkFlowForm), "ID,Name,Type,CreateUserID,CreateUserName,CreateTime,LastModifyTime,'' Html,'' SubTableJson,'' EventsJson,'' Attribute,Status", stringBuilder.ToString(), order.IsNullOrEmpty() ? "CreateTime DESC" : order, pageSize, pageNumber, out count, oracleParameterList1.ToArray()), oracleParameterList1.ToArray());
      List<RoadFlow.Data.Model.WorkFlowForm> list = this.DataReaderToList(dataReader);
      dataReader.Close();
      return list;
    }
  }
}
