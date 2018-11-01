// Decompiled with JetBrains decompiler
// Type: RoadFlow.Data.MSSQL.WorkFlowDelegation
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
  public class WorkFlowDelegation : IWorkFlowDelegation
  {
    private DBHelper dbHelper = new DBHelper();

    public int Add(RoadFlow.Data.Model.WorkFlowDelegation model)
    {
      string sql = "INSERT INTO WorkFlowDelegation\r\n\t\t\t\t(ID,UserID,StartTime,EndTime,FlowID,ToUserID,WriteTime,Note) \r\n\t\t\t\tVALUES(@ID,@UserID,@StartTime,@EndTime,@FlowID,@ToUserID,@WriteTime,@Note)";
      SqlParameter[] sqlParameterArray = new SqlParameter[8];
      int index1 = 0;
      SqlParameter sqlParameter1 = new SqlParameter("@ID", SqlDbType.UniqueIdentifier, -1);
      sqlParameter1.Value = (object) model.ID;
      sqlParameterArray[index1] = sqlParameter1;
      int index2 = 1;
      SqlParameter sqlParameter2 = new SqlParameter("@UserID", SqlDbType.UniqueIdentifier, -1);
      sqlParameter2.Value = (object) model.UserID;
      sqlParameterArray[index2] = sqlParameter2;
      int index3 = 2;
      SqlParameter sqlParameter3 = new SqlParameter("@StartTime", SqlDbType.DateTime, 8);
      sqlParameter3.Value = (object) model.StartTime;
      sqlParameterArray[index3] = sqlParameter3;
      int index4 = 3;
      SqlParameter sqlParameter4 = new SqlParameter("@EndTime", SqlDbType.DateTime, 8);
      sqlParameter4.Value = (object) model.EndTime;
      sqlParameterArray[index4] = sqlParameter4;
      int index5 = 4;
      SqlParameter sqlParameter5;
      if (model.FlowID.HasValue)
      {
        SqlParameter sqlParameter6 = new SqlParameter("@FlowID", SqlDbType.UniqueIdentifier, -1);
        sqlParameter6.Value = (object) model.FlowID;
        sqlParameter5 = sqlParameter6;
      }
      else
      {
        sqlParameter5 = new SqlParameter("@FlowID", SqlDbType.UniqueIdentifier, -1);
        sqlParameter5.Value = (object) DBNull.Value;
      }
      sqlParameterArray[index5] = sqlParameter5;
      int index6 = 5;
      SqlParameter sqlParameter7 = new SqlParameter("@ToUserID", SqlDbType.UniqueIdentifier, -1);
      sqlParameter7.Value = (object) model.ToUserID;
      sqlParameterArray[index6] = sqlParameter7;
      int index7 = 6;
      SqlParameter sqlParameter8 = new SqlParameter("@WriteTime", SqlDbType.DateTime, 8);
      sqlParameter8.Value = (object) model.WriteTime;
      sqlParameterArray[index7] = sqlParameter8;
      int index8 = 7;
      SqlParameter sqlParameter9;
      if (model.Note != null)
      {
        SqlParameter sqlParameter6 = new SqlParameter("@Note", SqlDbType.NVarChar, 8000);
        sqlParameter6.Value = (object) model.Note;
        sqlParameter9 = sqlParameter6;
      }
      else
      {
        sqlParameter9 = new SqlParameter("@Note", SqlDbType.NVarChar, 8000);
        sqlParameter9.Value = (object) DBNull.Value;
      }
      sqlParameterArray[index8] = sqlParameter9;
      SqlParameter[] parameter = sqlParameterArray;
      return this.dbHelper.Execute(sql, parameter, false);
    }

    public int Update(RoadFlow.Data.Model.WorkFlowDelegation model)
    {
      string sql = "UPDATE WorkFlowDelegation SET \r\n\t\t\t\tUserID=@UserID,StartTime=@StartTime,EndTime=@EndTime,FlowID=@FlowID,ToUserID=@ToUserID,WriteTime=@WriteTime,Note=@Note\r\n\t\t\t\tWHERE ID=@ID";
      SqlParameter[] sqlParameterArray = new SqlParameter[8];
      int index1 = 0;
      SqlParameter sqlParameter1 = new SqlParameter("@UserID", SqlDbType.UniqueIdentifier, -1);
      sqlParameter1.Value = (object) model.UserID;
      sqlParameterArray[index1] = sqlParameter1;
      int index2 = 1;
      SqlParameter sqlParameter2 = new SqlParameter("@StartTime", SqlDbType.DateTime, 8);
      sqlParameter2.Value = (object) model.StartTime;
      sqlParameterArray[index2] = sqlParameter2;
      int index3 = 2;
      SqlParameter sqlParameter3 = new SqlParameter("@EndTime", SqlDbType.DateTime, 8);
      sqlParameter3.Value = (object) model.EndTime;
      sqlParameterArray[index3] = sqlParameter3;
      int index4 = 3;
      SqlParameter sqlParameter4;
      if (model.FlowID.HasValue)
      {
        SqlParameter sqlParameter5 = new SqlParameter("@FlowID", SqlDbType.UniqueIdentifier, -1);
        sqlParameter5.Value = (object) model.FlowID;
        sqlParameter4 = sqlParameter5;
      }
      else
      {
        sqlParameter4 = new SqlParameter("@FlowID", SqlDbType.UniqueIdentifier, -1);
        sqlParameter4.Value = (object) DBNull.Value;
      }
      sqlParameterArray[index4] = sqlParameter4;
      int index5 = 4;
      SqlParameter sqlParameter6 = new SqlParameter("@ToUserID", SqlDbType.UniqueIdentifier, -1);
      sqlParameter6.Value = (object) model.ToUserID;
      sqlParameterArray[index5] = sqlParameter6;
      int index6 = 5;
      SqlParameter sqlParameter7 = new SqlParameter("@WriteTime", SqlDbType.DateTime, 8);
      sqlParameter7.Value = (object) model.WriteTime;
      sqlParameterArray[index6] = sqlParameter7;
      int index7 = 6;
      SqlParameter sqlParameter8;
      if (model.Note != null)
      {
        SqlParameter sqlParameter5 = new SqlParameter("@Note", SqlDbType.NVarChar, 8000);
        sqlParameter5.Value = (object) model.Note;
        sqlParameter8 = sqlParameter5;
      }
      else
      {
        sqlParameter8 = new SqlParameter("@Note", SqlDbType.NVarChar, 8000);
        sqlParameter8.Value = (object) DBNull.Value;
      }
      sqlParameterArray[index7] = sqlParameter8;
      int index8 = 7;
      SqlParameter sqlParameter9 = new SqlParameter("@ID", SqlDbType.UniqueIdentifier, -1);
      sqlParameter9.Value = (object) model.ID;
      sqlParameterArray[index8] = sqlParameter9;
      SqlParameter[] parameter = sqlParameterArray;
      return this.dbHelper.Execute(sql, parameter, false);
    }

    public int Delete(Guid id)
    {
      string sql = "DELETE FROM WorkFlowDelegation WHERE ID=@ID";
      SqlParameter[] sqlParameterArray = new SqlParameter[1];
      int index = 0;
      SqlParameter sqlParameter = new SqlParameter("@ID", SqlDbType.UniqueIdentifier);
      sqlParameter.Value = (object) id;
      sqlParameterArray[index] = sqlParameter;
      SqlParameter[] parameter = sqlParameterArray;
      return this.dbHelper.Execute(sql, parameter, false);
    }

    private List<RoadFlow.Data.Model.WorkFlowDelegation> DataReaderToList(SqlDataReader dataReader)
    {
      List<RoadFlow.Data.Model.WorkFlowDelegation> workFlowDelegationList = new List<RoadFlow.Data.Model.WorkFlowDelegation>();
      while (dataReader.Read())
      {
        RoadFlow.Data.Model.WorkFlowDelegation workFlowDelegation = new RoadFlow.Data.Model.WorkFlowDelegation();
        workFlowDelegation.ID = dataReader.GetGuid(0);
        workFlowDelegation.UserID = dataReader.GetGuid(1);
        workFlowDelegation.StartTime = dataReader.GetDateTime(2);
        workFlowDelegation.EndTime = dataReader.GetDateTime(3);
        if (!dataReader.IsDBNull(4))
          workFlowDelegation.FlowID = new Guid?(dataReader.GetGuid(4));
        workFlowDelegation.ToUserID = dataReader.GetGuid(5);
        workFlowDelegation.WriteTime = dataReader.GetDateTime(6);
        if (!dataReader.IsDBNull(7))
          workFlowDelegation.Note = dataReader.GetString(7);
        workFlowDelegationList.Add(workFlowDelegation);
      }
      return workFlowDelegationList;
    }

    public List<RoadFlow.Data.Model.WorkFlowDelegation> GetAll()
    {
      SqlDataReader dataReader = this.dbHelper.GetDataReader("SELECT * FROM WorkFlowDelegation");
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
      string sql = "SELECT * FROM WorkFlowDelegation WHERE ID=@ID";
      SqlParameter[] sqlParameterArray = new SqlParameter[1];
      int index = 0;
      SqlParameter sqlParameter = new SqlParameter("@ID", SqlDbType.UniqueIdentifier);
      sqlParameter.Value = (object) id;
      sqlParameterArray[index] = sqlParameter;
      SqlParameter[] parameter = sqlParameterArray;
      SqlDataReader dataReader = this.dbHelper.GetDataReader(sql, parameter);
      List<RoadFlow.Data.Model.WorkFlowDelegation> list = this.DataReaderToList(dataReader);
      dataReader.Close();
      if (list.Count <= 0)
        return (RoadFlow.Data.Model.WorkFlowDelegation) null;
      return list[0];
    }

    public List<RoadFlow.Data.Model.WorkFlowDelegation> GetByUserID(Guid userID)
    {
      string sql = "SELECT * FROM WorkFlowDelegation WHERE UserID=@UserID";
      SqlParameter[] sqlParameterArray = new SqlParameter[1];
      int index = 0;
      SqlParameter sqlParameter = new SqlParameter("@UserID", SqlDbType.UniqueIdentifier);
      sqlParameter.Value = (object) userID;
      sqlParameterArray[index] = sqlParameter;
      SqlParameter[] parameter = sqlParameterArray;
      SqlDataReader dataReader = this.dbHelper.GetDataReader(sql, parameter);
      List<RoadFlow.Data.Model.WorkFlowDelegation> list = this.DataReaderToList(dataReader);
      dataReader.Close();
      return list;
    }

    public List<RoadFlow.Data.Model.WorkFlowDelegation> GetPagerData(out string pager, string query = "", string userID = "", string startTime = "", string endTime = "")
    {
      StringBuilder stringBuilder = new StringBuilder();
      List<SqlParameter> sqlParameterList1 = new List<SqlParameter>();
      if (userID.IsGuid())
      {
        stringBuilder.Append("AND UserID=@UserID ");
        List<SqlParameter> sqlParameterList2 = sqlParameterList1;
        SqlParameter sqlParameter = new SqlParameter("@UserID", SqlDbType.UniqueIdentifier);
        sqlParameter.Value = (object) userID.ToGuid();
        sqlParameterList2.Add(sqlParameter);
      }
      DateTime dateTime;
      if (startTime.IsDateTime())
      {
        stringBuilder.Append("AND StartTime>=@StartTime ");
        List<SqlParameter> sqlParameterList2 = sqlParameterList1;
        SqlParameter sqlParameter = new SqlParameter("@StartTime", SqlDbType.DateTime);
        dateTime = startTime.ToDateTime();
        sqlParameter.Value = (object) dateTime.ToString("yyyy-MM-dd").ToDateTime();
        sqlParameterList2.Add(sqlParameter);
      }
      if (endTime.IsDateTime())
      {
        stringBuilder.Append("AND EndTime<=@EndTime ");
        List<SqlParameter> sqlParameterList2 = sqlParameterList1;
        SqlParameter sqlParameter = new SqlParameter("@EndTime", SqlDbType.DateTime);
        dateTime = endTime.ToDateTime();
        dateTime = dateTime.AddDays(1.0);
        sqlParameter.Value = (object) dateTime.ToString("yyyy-MM-dd").ToDateTime();
        sqlParameterList2.Add(sqlParameter);
      }
      int pageSize = Tools.GetPageSize();
      int pageNumber = Tools.GetPageNumber();
      long count;
      string paerSql = this.dbHelper.GetPaerSql(nameof (WorkFlowDelegation), "*", stringBuilder.ToString(), "WriteTime Desc", pageSize, pageNumber, out count, sqlParameterList1.ToArray());
      pager = Tools.GetPagerHtml(count, pageSize, pageNumber, query);
      SqlDataReader dataReader = this.dbHelper.GetDataReader(paerSql, sqlParameterList1.ToArray());
      List<RoadFlow.Data.Model.WorkFlowDelegation> list = this.DataReaderToList(dataReader);
      dataReader.Close();
      return list;
    }

    public List<RoadFlow.Data.Model.WorkFlowDelegation> GetPagerData(out long count, int pageSize, int pageNumber, string userID = "", string startTime = "", string endTime = "", string order = "")
    {
      StringBuilder stringBuilder = new StringBuilder();
      List<SqlParameter> sqlParameterList1 = new List<SqlParameter>();
      if (userID.IsGuid())
      {
        stringBuilder.Append("AND UserID=@UserID ");
        List<SqlParameter> sqlParameterList2 = sqlParameterList1;
        SqlParameter sqlParameter = new SqlParameter("@UserID", SqlDbType.UniqueIdentifier);
        sqlParameter.Value = (object) userID.ToGuid();
        sqlParameterList2.Add(sqlParameter);
      }
      DateTime dateTime;
      if (startTime.IsDateTime())
      {
        stringBuilder.Append("AND StartTime>=@StartTime ");
        List<SqlParameter> sqlParameterList2 = sqlParameterList1;
        SqlParameter sqlParameter = new SqlParameter("@StartTime", SqlDbType.DateTime);
        dateTime = startTime.ToDateTime();
        sqlParameter.Value = (object) dateTime.ToString("yyyy-MM-dd").ToDateTime();
        sqlParameterList2.Add(sqlParameter);
      }
      if (endTime.IsDateTime())
      {
        stringBuilder.Append("AND EndTime<=@EndTime ");
        List<SqlParameter> sqlParameterList2 = sqlParameterList1;
        SqlParameter sqlParameter = new SqlParameter("@EndTime", SqlDbType.DateTime);
        dateTime = endTime.ToDateTime();
        dateTime = dateTime.AddDays(1.0);
        sqlParameter.Value = (object) dateTime.ToString("yyyy-MM-dd").ToDateTime();
        sqlParameterList2.Add(sqlParameter);
      }
      SqlDataReader dataReader = this.dbHelper.GetDataReader(this.dbHelper.GetPaerSql(nameof (WorkFlowDelegation), "*", stringBuilder.ToString(), order.IsNullOrEmpty() ? "WriteTime Desc" : order, pageSize, pageNumber, out count, sqlParameterList1.ToArray()), sqlParameterList1.ToArray());
      List<RoadFlow.Data.Model.WorkFlowDelegation> list = this.DataReaderToList(dataReader);
      dataReader.Close();
      return list;
    }

    public List<RoadFlow.Data.Model.WorkFlowDelegation> GetNoExpiredList()
    {
      string sql = "SELECT * FROM WorkFlowDelegation WHERE EndTime>=@EndTime";
      SqlParameter[] sqlParameterArray = new SqlParameter[1];
      int index = 0;
      SqlParameter sqlParameter = new SqlParameter("@EndTime", SqlDbType.DateTime);
      sqlParameter.Value = (object) DateTimeNew.Now;
      sqlParameterArray[index] = sqlParameter;
      SqlParameter[] parameter = sqlParameterArray;
      SqlDataReader dataReader = this.dbHelper.GetDataReader(sql, parameter);
      List<RoadFlow.Data.Model.WorkFlowDelegation> list = this.DataReaderToList(dataReader);
      dataReader.Close();
      return list;
    }
  }
}
