// Decompiled with JetBrains decompiler
// Type: RoadFlow.Data.ORACLE.WorkFlowDelegation
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
  public class WorkFlowDelegation : IWorkFlowDelegation
  {
    private DBHelper dbHelper = new DBHelper();

    public int Add(RoadFlow.Data.Model.WorkFlowDelegation model)
    {
      string sql = "INSERT INTO WorkFlowDelegation\r\n\t\t\t\t(ID,UserID,StartTime,EndTime,FlowID,ToUserID,WriteTime,Note) \r\n\t\t\t\tVALUES(:ID,:UserID,:StartTime,:EndTime,:FlowID,:ToUserID,:WriteTime,:Note)";
      OracleParameter[] oracleParameterArray = new OracleParameter[8];
      int index1 = 0;
      OracleParameter oracleParameter1 = new OracleParameter(":ID", OracleDbType.Varchar2, 40);
      oracleParameter1.Value = (object) model.ID;
      oracleParameterArray[index1] = oracleParameter1;
      int index2 = 1;
      OracleParameter oracleParameter2 = new OracleParameter(":UserID", OracleDbType.Varchar2, 40);
      oracleParameter2.Value = (object) model.UserID;
      oracleParameterArray[index2] = oracleParameter2;
      int index3 = 2;
      OracleParameter oracleParameter3 = new OracleParameter(":StartTime", OracleDbType.Date, 8);
      oracleParameter3.Value = (object) model.StartTime;
      oracleParameterArray[index3] = oracleParameter3;
      int index4 = 3;
      OracleParameter oracleParameter4 = new OracleParameter(":EndTime", OracleDbType.Date, 8);
      oracleParameter4.Value = (object) model.EndTime;
      oracleParameterArray[index4] = oracleParameter4;
      int index5 = 4;
      OracleParameter oracleParameter5;
      if (model.FlowID.HasValue)
      {
        OracleParameter oracleParameter6 = new OracleParameter(":FlowID", OracleDbType.Varchar2, 40);
        oracleParameter6.Value = (object) model.FlowID;
        oracleParameter5 = oracleParameter6;
      }
      else
      {
        oracleParameter5 = new OracleParameter(":FlowID", OracleDbType.Varchar2, 40);
        oracleParameter5.Value = (object) DBNull.Value;
      }
      oracleParameterArray[index5] = oracleParameter5;
      int index6 = 5;
      OracleParameter oracleParameter7 = new OracleParameter(":ToUserID", OracleDbType.Varchar2, 40);
      oracleParameter7.Value = (object) model.ToUserID;
      oracleParameterArray[index6] = oracleParameter7;
      int index7 = 6;
      OracleParameter oracleParameter8 = new OracleParameter(":WriteTime", OracleDbType.Date, 8);
      oracleParameter8.Value = (object) model.WriteTime;
      oracleParameterArray[index7] = oracleParameter8;
      int index8 = 7;
      OracleParameter oracleParameter9;
      if (model.Note != null)
      {
        OracleParameter oracleParameter6 = new OracleParameter(":Note", OracleDbType.NVarchar2, 8000);
        oracleParameter6.Value = (object) model.Note;
        oracleParameter9 = oracleParameter6;
      }
      else
      {
        oracleParameter9 = new OracleParameter(":Note", OracleDbType.NVarchar2, 8000);
        oracleParameter9.Value = (object) DBNull.Value;
      }
      oracleParameterArray[index8] = oracleParameter9;
      OracleParameter[] parameter = oracleParameterArray;
      return this.dbHelper.Execute(sql, parameter);
    }

    public int Update(RoadFlow.Data.Model.WorkFlowDelegation model)
    {
      string sql = "UPDATE WorkFlowDelegation SET \r\n\t\t\t\tUserID=:UserID,StartTime=:StartTime,EndTime=:EndTime,FlowID=:FlowID,ToUserID=:ToUserID,WriteTime=:WriteTime,Note=:Note\r\n\t\t\t\tWHERE ID=:ID";
      OracleParameter[] oracleParameterArray = new OracleParameter[8];
      int index1 = 0;
      OracleParameter oracleParameter1 = new OracleParameter(":UserID", OracleDbType.Varchar2, 40);
      oracleParameter1.Value = (object) model.UserID;
      oracleParameterArray[index1] = oracleParameter1;
      int index2 = 1;
      OracleParameter oracleParameter2 = new OracleParameter(":StartTime", OracleDbType.Date, 8);
      oracleParameter2.Value = (object) model.StartTime;
      oracleParameterArray[index2] = oracleParameter2;
      int index3 = 2;
      OracleParameter oracleParameter3 = new OracleParameter(":EndTime", OracleDbType.Date, 8);
      oracleParameter3.Value = (object) model.EndTime;
      oracleParameterArray[index3] = oracleParameter3;
      int index4 = 3;
      OracleParameter oracleParameter4;
      if (model.FlowID.HasValue)
      {
        OracleParameter oracleParameter5 = new OracleParameter(":FlowID", OracleDbType.Varchar2, 40);
        oracleParameter5.Value = (object) model.FlowID;
        oracleParameter4 = oracleParameter5;
      }
      else
      {
        oracleParameter4 = new OracleParameter(":FlowID", OracleDbType.Varchar2, 40);
        oracleParameter4.Value = (object) DBNull.Value;
      }
      oracleParameterArray[index4] = oracleParameter4;
      int index5 = 4;
      OracleParameter oracleParameter6 = new OracleParameter(":ToUserID", OracleDbType.Varchar2, 40);
      oracleParameter6.Value = (object) model.ToUserID;
      oracleParameterArray[index5] = oracleParameter6;
      int index6 = 5;
      OracleParameter oracleParameter7 = new OracleParameter(":WriteTime", OracleDbType.Date, 8);
      oracleParameter7.Value = (object) model.WriteTime;
      oracleParameterArray[index6] = oracleParameter7;
      int index7 = 6;
      OracleParameter oracleParameter8;
      if (model.Note != null)
      {
        OracleParameter oracleParameter5 = new OracleParameter(":Note", OracleDbType.NVarchar2, 8000);
        oracleParameter5.Value = (object) model.Note;
        oracleParameter8 = oracleParameter5;
      }
      else
      {
        oracleParameter8 = new OracleParameter(":Note", OracleDbType.NVarchar2, 8000);
        oracleParameter8.Value = (object) DBNull.Value;
      }
      oracleParameterArray[index7] = oracleParameter8;
      int index8 = 7;
      OracleParameter oracleParameter9 = new OracleParameter(":ID", OracleDbType.Varchar2, 40);
      oracleParameter9.Value = (object) model.ID;
      oracleParameterArray[index8] = oracleParameter9;
      OracleParameter[] parameter = oracleParameterArray;
      return this.dbHelper.Execute(sql, parameter);
    }

    public int Delete(Guid id)
    {
      string sql = "DELETE FROM WorkFlowDelegation WHERE ID=:ID";
      OracleParameter[] oracleParameterArray = new OracleParameter[1];
      int index = 0;
      OracleParameter oracleParameter = new OracleParameter(":ID", OracleDbType.Varchar2);
      oracleParameter.Value = (object) id;
      oracleParameterArray[index] = oracleParameter;
      OracleParameter[] parameter = oracleParameterArray;
      return this.dbHelper.Execute(sql, parameter);
    }

    private List<RoadFlow.Data.Model.WorkFlowDelegation> DataReaderToList(OracleDataReader dataReader)
    {
      List<RoadFlow.Data.Model.WorkFlowDelegation> workFlowDelegationList = new List<RoadFlow.Data.Model.WorkFlowDelegation>();
      while (dataReader.Read())
      {
        RoadFlow.Data.Model.WorkFlowDelegation workFlowDelegation = new RoadFlow.Data.Model.WorkFlowDelegation();
        workFlowDelegation.ID = dataReader.GetString(0).ToGuid();
        workFlowDelegation.UserID = dataReader.GetString(1).ToGuid();
        workFlowDelegation.StartTime = dataReader.GetDateTime(2);
        workFlowDelegation.EndTime = dataReader.GetDateTime(3);
        if (!dataReader.IsDBNull(4))
          workFlowDelegation.FlowID = new Guid?(dataReader.GetString(4).ToGuid());
        workFlowDelegation.ToUserID = dataReader.GetString(5).ToGuid();
        workFlowDelegation.WriteTime = dataReader.GetDateTime(6);
        if (!dataReader.IsDBNull(7))
          workFlowDelegation.Note = dataReader.GetString(7);
        workFlowDelegationList.Add(workFlowDelegation);
      }
      return workFlowDelegationList;
    }

    public List<RoadFlow.Data.Model.WorkFlowDelegation> GetAll()
    {
      OracleDataReader dataReader = this.dbHelper.GetDataReader("SELECT * FROM WorkFlowDelegation");
      List<RoadFlow.Data.Model.WorkFlowDelegation> list = this.DataReaderToList(dataReader);
      dataReader.Close();
      return list;
    }

    public long GetCount()
    {
      long result;
      if (!long.TryParse(this.dbHelper.GetFieldValue("SELECT COUNT(*) FROM WorkFlowDelegation"), out result))
        return 0;
      return result;
    }

    public RoadFlow.Data.Model.WorkFlowDelegation Get(Guid id)
    {
      string sql = "SELECT * FROM WorkFlowDelegation WHERE ID=:ID";
      OracleParameter[] oracleParameterArray = new OracleParameter[1];
      int index = 0;
      OracleParameter oracleParameter = new OracleParameter(":ID", OracleDbType.Varchar2);
      oracleParameter.Value = (object) id;
      oracleParameterArray[index] = oracleParameter;
      OracleParameter[] parameter = oracleParameterArray;
      OracleDataReader dataReader = this.dbHelper.GetDataReader(sql, parameter);
      List<RoadFlow.Data.Model.WorkFlowDelegation> list = this.DataReaderToList(dataReader);
      dataReader.Close();
      if (list.Count <= 0)
        return (RoadFlow.Data.Model.WorkFlowDelegation) null;
      return list[0];
    }

    public List<RoadFlow.Data.Model.WorkFlowDelegation> GetByUserID(Guid userID)
    {
      string sql = "SELECT * FROM WorkFlowDelegation WHERE UserID=:UserID";
      OracleParameter[] oracleParameterArray = new OracleParameter[1];
      int index = 0;
      OracleParameter oracleParameter = new OracleParameter(":UserID", OracleDbType.Varchar2);
      oracleParameter.Value = (object) userID;
      oracleParameterArray[index] = oracleParameter;
      OracleParameter[] parameter = oracleParameterArray;
      OracleDataReader dataReader = this.dbHelper.GetDataReader(sql, parameter);
      List<RoadFlow.Data.Model.WorkFlowDelegation> list = this.DataReaderToList(dataReader);
      dataReader.Close();
      return list;
    }

    public List<RoadFlow.Data.Model.WorkFlowDelegation> GetPagerData(out string pager, string query = "", string userID = "", string startTime = "", string endTime = "")
    {
      StringBuilder stringBuilder = new StringBuilder();
      List<OracleParameter> oracleParameterList1 = new List<OracleParameter>();
      if (userID.IsGuid())
      {
        stringBuilder.Append("AND UserID=:UserID ");
        List<OracleParameter> oracleParameterList2 = oracleParameterList1;
        OracleParameter oracleParameter = new OracleParameter(":UserID", OracleDbType.Varchar2);
        oracleParameter.Value = (object) userID.ToGuid();
        oracleParameterList2.Add(oracleParameter);
      }
      DateTime dateTime;
      if (startTime.IsDateTime())
      {
        stringBuilder.Append("AND StartTime>=:StartTime ");
        List<OracleParameter> oracleParameterList2 = oracleParameterList1;
        OracleParameter oracleParameter = new OracleParameter(":StartTime", OracleDbType.Date);
        dateTime = startTime.ToDateTime();
        oracleParameter.Value = (object) dateTime.ToString("yyyy-MM-dd").ToDateTime();
        oracleParameterList2.Add(oracleParameter);
      }
      if (endTime.IsDateTime())
      {
        stringBuilder.Append("AND EndTime<=:EndTime ");
        List<OracleParameter> oracleParameterList2 = oracleParameterList1;
        OracleParameter oracleParameter = new OracleParameter(":EndTime", OracleDbType.Date);
        dateTime = endTime.ToDateTime();
        dateTime = dateTime.AddDays(1.0);
        oracleParameter.Value = (object) dateTime.ToString("yyyy-MM-dd").ToDateTime();
        oracleParameterList2.Add(oracleParameter);
      }
      int pageSize = Tools.GetPageSize();
      int pageNumber = Tools.GetPageNumber();
      long count;
      string paerSql = this.dbHelper.GetPaerSql(nameof (WorkFlowDelegation), "*", stringBuilder.ToString(), "WriteTime Desc", pageSize, pageNumber, out count, oracleParameterList1.ToArray());
      pager = Tools.GetPagerHtml(count, pageSize, pageNumber, query);
      OracleDataReader dataReader = this.dbHelper.GetDataReader(paerSql, oracleParameterList1.ToArray());
      List<RoadFlow.Data.Model.WorkFlowDelegation> list = this.DataReaderToList(dataReader);
      dataReader.Close();
      return list;
    }

    public List<RoadFlow.Data.Model.WorkFlowDelegation> GetPagerData(out long count, int pageSize, int pageNumber, string userID = "", string startTime = "", string endTime = "", string order = "")
    {
      StringBuilder stringBuilder = new StringBuilder();
      List<OracleParameter> oracleParameterList1 = new List<OracleParameter>();
      if (userID.IsGuid())
      {
        stringBuilder.Append("AND UserID=:UserID ");
        List<OracleParameter> oracleParameterList2 = oracleParameterList1;
        OracleParameter oracleParameter = new OracleParameter(":UserID", OracleDbType.Varchar2);
        oracleParameter.Value = (object) userID.ToGuid();
        oracleParameterList2.Add(oracleParameter);
      }
      DateTime dateTime;
      if (startTime.IsDateTime())
      {
        stringBuilder.Append("AND StartTime>=:StartTime ");
        List<OracleParameter> oracleParameterList2 = oracleParameterList1;
        OracleParameter oracleParameter = new OracleParameter(":StartTime", OracleDbType.Date);
        dateTime = startTime.ToDateTime();
        oracleParameter.Value = (object) dateTime.ToString("yyyy-MM-dd").ToDateTime();
        oracleParameterList2.Add(oracleParameter);
      }
      if (endTime.IsDateTime())
      {
        stringBuilder.Append("AND EndTime<=:EndTime ");
        List<OracleParameter> oracleParameterList2 = oracleParameterList1;
        OracleParameter oracleParameter = new OracleParameter(":EndTime", OracleDbType.Date);
        dateTime = endTime.ToDateTime();
        dateTime = dateTime.AddDays(1.0);
        oracleParameter.Value = (object) dateTime.ToString("yyyy-MM-dd").ToDateTime();
        oracleParameterList2.Add(oracleParameter);
      }
      OracleDataReader dataReader = this.dbHelper.GetDataReader(this.dbHelper.GetPaerSql(nameof (WorkFlowDelegation), "*", stringBuilder.ToString(), order.IsNullOrEmpty() ? "WriteTime Desc" : order, pageSize, pageNumber, out count, oracleParameterList1.ToArray()), oracleParameterList1.ToArray());
      List<RoadFlow.Data.Model.WorkFlowDelegation> list = this.DataReaderToList(dataReader);
      dataReader.Close();
      return list;
    }

    public List<RoadFlow.Data.Model.WorkFlowDelegation> GetNoExpiredList()
    {
      string sql = "SELECT * FROM WorkFlowDelegation WHERE EndTime>=:EndTime";
      OracleParameter[] oracleParameterArray = new OracleParameter[1];
      int index = 0;
      OracleParameter oracleParameter = new OracleParameter(":EndTime", OracleDbType.Date);
      oracleParameter.Value = (object) DateTimeNew.Now;
      oracleParameterArray[index] = oracleParameter;
      OracleParameter[] parameter = oracleParameterArray;
      OracleDataReader dataReader = this.dbHelper.GetDataReader(sql, parameter);
      List<RoadFlow.Data.Model.WorkFlowDelegation> list = this.DataReaderToList(dataReader);
      dataReader.Close();
      return list;
    }
  }
}
