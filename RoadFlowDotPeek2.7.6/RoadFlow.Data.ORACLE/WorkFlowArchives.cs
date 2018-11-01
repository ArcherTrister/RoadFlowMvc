// Decompiled with JetBrains decompiler
// Type: RoadFlow.Data.ORACLE.WorkFlowArchives
// Assembly: RoadFlow.Data.ORACLE, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: C9018AA1-E48E-4231-92A9-CD6F0F275D11
// Assembly location: C:\inetpub\wwwroot\RoadFlowMvc\bin\RoadFlow.Data.ORACLE.dll

using Oracle.ManagedDataAccess.Client;
using RoadFlow.Data.Interface;
using RoadFlow.Utility;
using System;
using System.Collections.Generic;
using System.Data;
using System.Text;

namespace RoadFlow.Data.ORACLE
{
  public class WorkFlowArchives : IWorkFlowArchives
  {
    private DBHelper dbHelper = new DBHelper();

    public int Add(RoadFlow.Data.Model.WorkFlowArchives model)
    {
      string sql = "INSERT INTO WorkFlowArchives\r\n\t\t\t\t(ID,FlowID,StepID,FlowName,StepName,TaskID,GroupID,InstanceID,Title,Contents,Comments,WriteTime) \r\n\t\t\t\tVALUES(:ID,:FlowID,:StepID,:FlowName,:StepName,:TaskID,:GroupID,:InstanceID,:Title,:Contents,:Comments,:WriteTime)";
      OracleParameter[] oracleParameterArray = new OracleParameter[12];
      int index1 = 0;
      OracleParameter oracleParameter1 = new OracleParameter(":ID", OracleDbType.Varchar2, 40);
      oracleParameter1.Value = (object) model.ID;
      oracleParameterArray[index1] = oracleParameter1;
      int index2 = 1;
      OracleParameter oracleParameter2 = new OracleParameter(":FlowID", OracleDbType.Varchar2, 40);
      oracleParameter2.Value = (object) model.FlowID;
      oracleParameterArray[index2] = oracleParameter2;
      int index3 = 2;
      OracleParameter oracleParameter3 = new OracleParameter(":StepID", OracleDbType.Varchar2, 40);
      oracleParameter3.Value = (object) model.StepID;
      oracleParameterArray[index3] = oracleParameter3;
      int index4 = 3;
      OracleParameter oracleParameter4 = new OracleParameter(":FlowName", OracleDbType.NVarchar2, 1000);
      oracleParameter4.Value = (object) model.FlowName;
      oracleParameterArray[index4] = oracleParameter4;
      int index5 = 4;
      OracleParameter oracleParameter5 = new OracleParameter(":StepName", OracleDbType.NVarchar2, 1000);
      oracleParameter5.Value = (object) model.StepName;
      oracleParameterArray[index5] = oracleParameter5;
      int index6 = 5;
      OracleParameter oracleParameter6 = new OracleParameter(":TaskID", OracleDbType.Varchar2, 40);
      oracleParameter6.Value = (object) model.TaskID;
      oracleParameterArray[index6] = oracleParameter6;
      int index7 = 6;
      OracleParameter oracleParameter7 = new OracleParameter(":GroupID", OracleDbType.Varchar2, 40);
      oracleParameter7.Value = (object) model.GroupID;
      oracleParameterArray[index7] = oracleParameter7;
      int index8 = 7;
      OracleParameter oracleParameter8 = new OracleParameter(":InstanceID", OracleDbType.Varchar2, 500);
      oracleParameter8.Value = (object) model.InstanceID;
      oracleParameterArray[index8] = oracleParameter8;
      int index9 = 8;
      OracleParameter oracleParameter9 = new OracleParameter(":Title", OracleDbType.NVarchar2, 8000);
      oracleParameter9.Value = (object) model.Title;
      oracleParameterArray[index9] = oracleParameter9;
      int index10 = 9;
      OracleParameter oracleParameter10 = new OracleParameter(":Contents", OracleDbType.Clob);
      oracleParameter10.Value = (object) model.Contents;
      oracleParameterArray[index10] = oracleParameter10;
      int index11 = 10;
      OracleParameter oracleParameter11 = new OracleParameter(":Comments", OracleDbType.Clob);
      oracleParameter11.Value = (object) model.Comments;
      oracleParameterArray[index11] = oracleParameter11;
      int index12 = 11;
      OracleParameter oracleParameter12 = new OracleParameter(":WriteTime", OracleDbType.Date, 8);
      oracleParameter12.Value = (object) model.WriteTime;
      oracleParameterArray[index12] = oracleParameter12;
      OracleParameter[] parameter = oracleParameterArray;
      return this.dbHelper.Execute(sql, parameter);
    }

    public int Update(RoadFlow.Data.Model.WorkFlowArchives model)
    {
      string sql = "UPDATE WorkFlowArchives SET \r\n\t\t\t\tFlowID=:FlowID,StepID=:StepID,FlowName=:FlowName,StepName=:StepName,TaskID=:TaskID,GroupID=:GroupID,InstanceID=:InstanceID,Title=:Title,Contents=:Contents,Comments=:Comments,WriteTime=:WriteTime\r\n\t\t\t\tWHERE ID=:ID";
      OracleParameter[] oracleParameterArray = new OracleParameter[12];
      int index1 = 0;
      OracleParameter oracleParameter1 = new OracleParameter(":FlowID", OracleDbType.Varchar2, 40);
      oracleParameter1.Value = (object) model.FlowID;
      oracleParameterArray[index1] = oracleParameter1;
      int index2 = 1;
      OracleParameter oracleParameter2 = new OracleParameter(":StepID", OracleDbType.Varchar2, 40);
      oracleParameter2.Value = (object) model.StepID;
      oracleParameterArray[index2] = oracleParameter2;
      int index3 = 2;
      OracleParameter oracleParameter3 = new OracleParameter(":FlowName", OracleDbType.NVarchar2, 1000);
      oracleParameter3.Value = (object) model.FlowName;
      oracleParameterArray[index3] = oracleParameter3;
      int index4 = 3;
      OracleParameter oracleParameter4 = new OracleParameter(":StepName", OracleDbType.NVarchar2, 1000);
      oracleParameter4.Value = (object) model.StepName;
      oracleParameterArray[index4] = oracleParameter4;
      int index5 = 4;
      OracleParameter oracleParameter5 = new OracleParameter(":TaskID", OracleDbType.Varchar2, 40);
      oracleParameter5.Value = (object) model.TaskID;
      oracleParameterArray[index5] = oracleParameter5;
      int index6 = 5;
      OracleParameter oracleParameter6 = new OracleParameter(":GroupID", OracleDbType.Varchar2, 40);
      oracleParameter6.Value = (object) model.GroupID;
      oracleParameterArray[index6] = oracleParameter6;
      int index7 = 6;
      OracleParameter oracleParameter7 = new OracleParameter(":InstanceID", OracleDbType.Varchar2, 500);
      oracleParameter7.Value = (object) model.InstanceID;
      oracleParameterArray[index7] = oracleParameter7;
      int index8 = 7;
      OracleParameter oracleParameter8 = new OracleParameter(":Title", OracleDbType.NVarchar2, 8000);
      oracleParameter8.Value = (object) model.Title;
      oracleParameterArray[index8] = oracleParameter8;
      int index9 = 8;
      OracleParameter oracleParameter9 = new OracleParameter(":Contents", OracleDbType.Clob);
      oracleParameter9.Value = (object) model.Contents;
      oracleParameterArray[index9] = oracleParameter9;
      int index10 = 9;
      OracleParameter oracleParameter10 = new OracleParameter(":Comments", OracleDbType.Clob);
      oracleParameter10.Value = (object) model.Comments;
      oracleParameterArray[index10] = oracleParameter10;
      int index11 = 10;
      OracleParameter oracleParameter11 = new OracleParameter(":WriteTime", OracleDbType.Date, 8);
      oracleParameter11.Value = (object) model.WriteTime;
      oracleParameterArray[index11] = oracleParameter11;
      int index12 = 11;
      OracleParameter oracleParameter12 = new OracleParameter(":ID", OracleDbType.Varchar2, 40);
      oracleParameter12.Value = (object) model.ID;
      oracleParameterArray[index12] = oracleParameter12;
      OracleParameter[] parameter = oracleParameterArray;
      return this.dbHelper.Execute(sql, parameter);
    }

    public int Delete(Guid id)
    {
      string sql = "DELETE FROM WorkFlowArchives WHERE ID=:ID";
      OracleParameter[] oracleParameterArray = new OracleParameter[1];
      int index = 0;
      OracleParameter oracleParameter = new OracleParameter(":ID", OracleDbType.Varchar2);
      oracleParameter.Value = (object) id;
      oracleParameterArray[index] = oracleParameter;
      OracleParameter[] parameter = oracleParameterArray;
      return this.dbHelper.Execute(sql, parameter);
    }

    private List<RoadFlow.Data.Model.WorkFlowArchives> DataReaderToList(OracleDataReader dataReader)
    {
      List<RoadFlow.Data.Model.WorkFlowArchives> workFlowArchivesList = new List<RoadFlow.Data.Model.WorkFlowArchives>();
      while (dataReader.Read())
        workFlowArchivesList.Add(new RoadFlow.Data.Model.WorkFlowArchives()
        {
          ID = dataReader.GetString(0).ToGuid(),
          FlowID = dataReader.GetString(1).ToGuid(),
          StepID = dataReader.GetString(2).ToGuid(),
          FlowName = dataReader.GetString(3),
          StepName = dataReader.GetString(4),
          TaskID = dataReader.GetString(5).ToGuid(),
          GroupID = dataReader.GetString(6).ToGuid(),
          InstanceID = dataReader.GetString(7),
          Title = dataReader.GetString(8),
          Contents = dataReader.GetString(9),
          Comments = dataReader.GetString(10),
          WriteTime = dataReader.GetDateTime(11)
        });
      return workFlowArchivesList;
    }

    public List<RoadFlow.Data.Model.WorkFlowArchives> GetAll()
    {
      OracleDataReader dataReader = this.dbHelper.GetDataReader("SELECT * FROM WorkFlowArchives");
      List<RoadFlow.Data.Model.WorkFlowArchives> list = this.DataReaderToList(dataReader);
      dataReader.Close();
      return list;
    }

    public long GetCount()
    {
      long result;
      if (!long.TryParse(this.dbHelper.GetFieldValue("SELECT COUNT(*) FROM WorkFlowArchives"), out result))
        return 0;
      return result;
    }

    public RoadFlow.Data.Model.WorkFlowArchives Get(Guid id)
    {
      string sql = "SELECT * FROM WorkFlowArchives WHERE ID=:ID";
      OracleParameter[] oracleParameterArray = new OracleParameter[1];
      int index = 0;
      OracleParameter oracleParameter = new OracleParameter(":ID", OracleDbType.Varchar2);
      oracleParameter.Value = (object) id;
      oracleParameterArray[index] = oracleParameter;
      OracleParameter[] parameter = oracleParameterArray;
      OracleDataReader dataReader = this.dbHelper.GetDataReader(sql, parameter);
      List<RoadFlow.Data.Model.WorkFlowArchives> list = this.DataReaderToList(dataReader);
      dataReader.Close();
      if (list.Count <= 0)
        return (RoadFlow.Data.Model.WorkFlowArchives) null;
      return list[0];
    }

    public DataTable GetPagerData(out string pager, string query = "", string title = "", string flowIDString = "")
    {
      StringBuilder stringBuilder = new StringBuilder();
      List<OracleParameter> oracleParameterList1 = new List<OracleParameter>();
      if (!title.IsNullOrEmpty())
      {
        stringBuilder.Append("AND INSTR(Title,:Title,1,1)>0 ");
        List<OracleParameter> oracleParameterList2 = oracleParameterList1;
        OracleParameter oracleParameter = new OracleParameter(":Title", OracleDbType.NVarchar2);
        oracleParameter.Value = (object) title;
        oracleParameterList2.Add(oracleParameter);
      }
      if (!flowIDString.IsNullOrEmpty())
        stringBuilder.AppendFormat("AND FlowID IN({0}) ", (object) Tools.GetSqlInString(flowIDString, true, ","));
      int pageSize = Tools.GetPageSize();
      int pageNumber = Tools.GetPageNumber();
      long count;
      string paerSql = this.dbHelper.GetPaerSql(nameof (WorkFlowArchives), "*", stringBuilder.ToString(), "WriteTime DESC", pageSize, pageNumber, out count, oracleParameterList1.ToArray());
      pager = Tools.GetPagerHtml(count, pageSize, pageNumber, query);
      return this.dbHelper.GetDataTable(paerSql, oracleParameterList1.ToArray());
    }

    public DataTable GetPagerData(out long count, int pageSize, int pageNumber, string title = "", string flowIDString = "", string date1 = "", string date2 = "", string order = "")
    {
      StringBuilder stringBuilder = new StringBuilder();
      List<OracleParameter> oracleParameterList1 = new List<OracleParameter>();
      if (!title.IsNullOrEmpty())
      {
        stringBuilder.Append("AND INSTR(Title,:Title,1,1)>0 ");
        List<OracleParameter> oracleParameterList2 = oracleParameterList1;
        OracleParameter oracleParameter = new OracleParameter(":Title", OracleDbType.NVarchar2);
        oracleParameter.Value = (object) title;
        oracleParameterList2.Add(oracleParameter);
      }
      if (flowIDString.IsGuid())
      {
        stringBuilder.Append("AND FlowID=:FlowID ");
        oracleParameterList1.Add(new OracleParameter(":FlowID", (object) flowIDString));
      }
      if (date1.IsDateTime())
      {
        stringBuilder.Append("AND WriteTime>=:WriteTime1 ");
        oracleParameterList1.Add(new OracleParameter(":WriteTime1", (object) date1));
      }
      if (date2.IsDateTime())
      {
        stringBuilder.Append("AND WriteTime<=:WriteTime2 ");
        oracleParameterList1.Add(new OracleParameter(":WriteTime2", (object) date2.ToDateTime().ToString("yyyy-MM-dd 23:59:59")));
      }
      return this.dbHelper.GetDataTable(this.dbHelper.GetPaerSql(nameof (WorkFlowArchives), "ID,FlowName,StepName,Title,WriteTime", stringBuilder.ToString(), order.IsNullOrEmpty() ? "WriteTime DESC" : order, pageSize, pageNumber, out count, oracleParameterList1.ToArray()), oracleParameterList1.ToArray());
    }
  }
}
