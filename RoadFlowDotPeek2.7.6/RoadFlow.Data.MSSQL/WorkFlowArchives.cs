// Decompiled with JetBrains decompiler
// Type: RoadFlow.Data.MSSQL.WorkFlowArchives
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
  public class WorkFlowArchives : IWorkFlowArchives
  {
    private DBHelper dbHelper = new DBHelper();

    public int Add(RoadFlow.Data.Model.WorkFlowArchives model)
    {
      string sql = "INSERT INTO WorkFlowArchives\r\n\t\t\t\t(ID,FlowID,StepID,FlowName,StepName,TaskID,GroupID,InstanceID,Title,Contents,Comments,WriteTime) \r\n\t\t\t\tVALUES(@ID,@FlowID,@StepID,@FlowName,@StepName,@TaskID,@GroupID,@InstanceID,@Title,@Contents,@Comments,@WriteTime)";
      SqlParameter[] sqlParameterArray = new SqlParameter[12];
      int index1 = 0;
      SqlParameter sqlParameter1 = new SqlParameter("@ID", SqlDbType.UniqueIdentifier, -1);
      sqlParameter1.Value = (object) model.ID;
      sqlParameterArray[index1] = sqlParameter1;
      int index2 = 1;
      SqlParameter sqlParameter2 = new SqlParameter("@FlowID", SqlDbType.UniqueIdentifier, -1);
      sqlParameter2.Value = (object) model.FlowID;
      sqlParameterArray[index2] = sqlParameter2;
      int index3 = 2;
      SqlParameter sqlParameter3 = new SqlParameter("@StepID", SqlDbType.UniqueIdentifier, -1);
      sqlParameter3.Value = (object) model.StepID;
      sqlParameterArray[index3] = sqlParameter3;
      int index4 = 3;
      SqlParameter sqlParameter4 = new SqlParameter("@FlowName", SqlDbType.NVarChar, 1000);
      sqlParameter4.Value = (object) model.FlowName;
      sqlParameterArray[index4] = sqlParameter4;
      int index5 = 4;
      SqlParameter sqlParameter5 = new SqlParameter("@StepName", SqlDbType.NVarChar, 1000);
      sqlParameter5.Value = (object) model.StepName;
      sqlParameterArray[index5] = sqlParameter5;
      int index6 = 5;
      SqlParameter sqlParameter6 = new SqlParameter("@TaskID", SqlDbType.UniqueIdentifier, -1);
      sqlParameter6.Value = (object) model.TaskID;
      sqlParameterArray[index6] = sqlParameter6;
      int index7 = 6;
      SqlParameter sqlParameter7 = new SqlParameter("@GroupID", SqlDbType.UniqueIdentifier, -1);
      sqlParameter7.Value = (object) model.GroupID;
      sqlParameterArray[index7] = sqlParameter7;
      int index8 = 7;
      SqlParameter sqlParameter8 = new SqlParameter("@InstanceID", SqlDbType.VarChar, 500);
      sqlParameter8.Value = (object) model.InstanceID;
      sqlParameterArray[index8] = sqlParameter8;
      int index9 = 8;
      SqlParameter sqlParameter9 = new SqlParameter("@Title", SqlDbType.NVarChar, 8000);
      sqlParameter9.Value = (object) model.Title;
      sqlParameterArray[index9] = sqlParameter9;
      int index10 = 9;
      SqlParameter sqlParameter10 = new SqlParameter("@Contents", SqlDbType.Text, -1);
      sqlParameter10.Value = (object) model.Contents;
      sqlParameterArray[index10] = sqlParameter10;
      int index11 = 10;
      SqlParameter sqlParameter11 = new SqlParameter("@Comments", SqlDbType.Text, -1);
      sqlParameter11.Value = (object) model.Comments;
      sqlParameterArray[index11] = sqlParameter11;
      int index12 = 11;
      SqlParameter sqlParameter12 = new SqlParameter("@WriteTime", SqlDbType.DateTime, 8);
      sqlParameter12.Value = (object) model.WriteTime;
      sqlParameterArray[index12] = sqlParameter12;
      SqlParameter[] parameter = sqlParameterArray;
      return this.dbHelper.Execute(sql, parameter, false);
    }

    public int Update(RoadFlow.Data.Model.WorkFlowArchives model)
    {
      string sql = "UPDATE WorkFlowArchives SET \r\n\t\t\t\tFlowID=@FlowID,StepID=@StepID,FlowName=@FlowName,StepName=@StepName,TaskID=@TaskID,GroupID=@GroupID,InstanceID=@InstanceID,Title=@Title,Contents=@Contents,Comments=@Comments,WriteTime=@WriteTime\r\n\t\t\t\tWHERE ID=@ID";
      SqlParameter[] sqlParameterArray = new SqlParameter[12];
      int index1 = 0;
      SqlParameter sqlParameter1 = new SqlParameter("@FlowID", SqlDbType.UniqueIdentifier, -1);
      sqlParameter1.Value = (object) model.FlowID;
      sqlParameterArray[index1] = sqlParameter1;
      int index2 = 1;
      SqlParameter sqlParameter2 = new SqlParameter("@StepID", SqlDbType.UniqueIdentifier, -1);
      sqlParameter2.Value = (object) model.StepID;
      sqlParameterArray[index2] = sqlParameter2;
      int index3 = 2;
      SqlParameter sqlParameter3 = new SqlParameter("@FlowName", SqlDbType.NVarChar, 1000);
      sqlParameter3.Value = (object) model.FlowName;
      sqlParameterArray[index3] = sqlParameter3;
      int index4 = 3;
      SqlParameter sqlParameter4 = new SqlParameter("@StepName", SqlDbType.NVarChar, 1000);
      sqlParameter4.Value = (object) model.StepName;
      sqlParameterArray[index4] = sqlParameter4;
      int index5 = 4;
      SqlParameter sqlParameter5 = new SqlParameter("@TaskID", SqlDbType.UniqueIdentifier, -1);
      sqlParameter5.Value = (object) model.TaskID;
      sqlParameterArray[index5] = sqlParameter5;
      int index6 = 5;
      SqlParameter sqlParameter6 = new SqlParameter("@GroupID", SqlDbType.UniqueIdentifier, -1);
      sqlParameter6.Value = (object) model.GroupID;
      sqlParameterArray[index6] = sqlParameter6;
      int index7 = 6;
      SqlParameter sqlParameter7 = new SqlParameter("@InstanceID", SqlDbType.VarChar, 500);
      sqlParameter7.Value = (object) model.InstanceID;
      sqlParameterArray[index7] = sqlParameter7;
      int index8 = 7;
      SqlParameter sqlParameter8 = new SqlParameter("@Title", SqlDbType.NVarChar, 8000);
      sqlParameter8.Value = (object) model.Title;
      sqlParameterArray[index8] = sqlParameter8;
      int index9 = 8;
      SqlParameter sqlParameter9 = new SqlParameter("@Contents", SqlDbType.Text, -1);
      sqlParameter9.Value = (object) model.Contents;
      sqlParameterArray[index9] = sqlParameter9;
      int index10 = 9;
      SqlParameter sqlParameter10 = new SqlParameter("@Comments", SqlDbType.Text, -1);
      sqlParameter10.Value = (object) model.Comments;
      sqlParameterArray[index10] = sqlParameter10;
      int index11 = 10;
      SqlParameter sqlParameter11 = new SqlParameter("@WriteTime", SqlDbType.DateTime, 8);
      sqlParameter11.Value = (object) model.WriteTime;
      sqlParameterArray[index11] = sqlParameter11;
      int index12 = 11;
      SqlParameter sqlParameter12 = new SqlParameter("@ID", SqlDbType.UniqueIdentifier, -1);
      sqlParameter12.Value = (object) model.ID;
      sqlParameterArray[index12] = sqlParameter12;
      SqlParameter[] parameter = sqlParameterArray;
      return this.dbHelper.Execute(sql, parameter, false);
    }

    public int Delete(Guid id)
    {
      string sql = "DELETE FROM WorkFlowArchives WHERE ID=@ID";
      SqlParameter[] sqlParameterArray = new SqlParameter[1];
      int index = 0;
      SqlParameter sqlParameter = new SqlParameter("@ID", SqlDbType.UniqueIdentifier);
      sqlParameter.Value = (object) id;
      sqlParameterArray[index] = sqlParameter;
      SqlParameter[] parameter = sqlParameterArray;
      return this.dbHelper.Execute(sql, parameter, false);
    }

    private List<RoadFlow.Data.Model.WorkFlowArchives> DataReaderToList(SqlDataReader dataReader)
    {
      List<RoadFlow.Data.Model.WorkFlowArchives> workFlowArchivesList = new List<RoadFlow.Data.Model.WorkFlowArchives>();
      while (dataReader.Read())
        workFlowArchivesList.Add(new RoadFlow.Data.Model.WorkFlowArchives()
        {
          ID = dataReader.GetGuid(0),
          FlowID = dataReader.GetGuid(1),
          StepID = dataReader.GetGuid(2),
          FlowName = dataReader.GetString(3),
          StepName = dataReader.GetString(4),
          TaskID = dataReader.GetGuid(5),
          GroupID = dataReader.GetGuid(6),
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
      SqlDataReader dataReader = this.dbHelper.GetDataReader("SELECT * FROM WorkFlowArchives");
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
      string sql = "SELECT * FROM WorkFlowArchives WHERE ID=@ID";
      SqlParameter[] sqlParameterArray = new SqlParameter[1];
      int index = 0;
      SqlParameter sqlParameter = new SqlParameter("@ID", SqlDbType.UniqueIdentifier);
      sqlParameter.Value = (object) id;
      sqlParameterArray[index] = sqlParameter;
      SqlParameter[] parameter = sqlParameterArray;
      SqlDataReader dataReader = this.dbHelper.GetDataReader(sql, parameter);
      List<RoadFlow.Data.Model.WorkFlowArchives> list = this.DataReaderToList(dataReader);
      dataReader.Close();
      if (list.Count <= 0)
        return (RoadFlow.Data.Model.WorkFlowArchives) null;
      return list[0];
    }

    public DataTable GetPagerData(out string pager, string query = "", string title = "", string flowIDString = "")
    {
      StringBuilder stringBuilder = new StringBuilder();
      List<SqlParameter> sqlParameterList1 = new List<SqlParameter>();
      if (!title.IsNullOrEmpty())
      {
        stringBuilder.Append("AND CHARINDEX(@Title,Title)>0 ");
        List<SqlParameter> sqlParameterList2 = sqlParameterList1;
        SqlParameter sqlParameter = new SqlParameter("@Title", SqlDbType.NVarChar);
        sqlParameter.Value = (object) title;
        sqlParameterList2.Add(sqlParameter);
      }
      if (!flowIDString.IsNullOrEmpty())
        stringBuilder.AppendFormat("AND FlowID IN({0}) ", (object) Tools.GetSqlInString(flowIDString, true, ","));
      int pageSize = Tools.GetPageSize();
      int pageNumber = Tools.GetPageNumber();
      long count;
      string paerSql = this.dbHelper.GetPaerSql(nameof (WorkFlowArchives), "*", stringBuilder.ToString(), "WriteTime DESC", pageSize, pageNumber, out count, sqlParameterList1.ToArray());
      pager = Tools.GetPagerHtml(count, pageSize, pageNumber, query);
      return this.dbHelper.GetDataTable(paerSql, sqlParameterList1.ToArray());
    }

    public DataTable GetPagerData(out long count, int pageSize, int pageNumber, string title = "", string flowIDString = "", string date1 = "", string date2 = "", string order = "")
    {
      StringBuilder stringBuilder = new StringBuilder();
      List<SqlParameter> sqlParameterList1 = new List<SqlParameter>();
      if (!title.IsNullOrEmpty())
      {
        stringBuilder.Append("AND CHARINDEX(@Title,Title)>0 ");
        List<SqlParameter> sqlParameterList2 = sqlParameterList1;
        SqlParameter sqlParameter = new SqlParameter("@Title", SqlDbType.NVarChar);
        sqlParameter.Value = (object) title;
        sqlParameterList2.Add(sqlParameter);
      }
      if (flowIDString.IsGuid())
      {
        stringBuilder.Append("AND FlowID=@FlowID ");
        sqlParameterList1.Add(new SqlParameter("@FlowID", (object) flowIDString));
      }
      if (date1.IsDateTime())
      {
        stringBuilder.Append("AND WriteTime>=@WriteTime1 ");
        sqlParameterList1.Add(new SqlParameter("@WriteTime1", (object) date1));
      }
      if (date2.IsDateTime())
      {
        stringBuilder.Append("AND WriteTime<=@WriteTime2 ");
        sqlParameterList1.Add(new SqlParameter("@WriteTime2", (object) date2.ToDateTime().ToString("yyyy-MM-dd 23:59:59")));
      }
      return this.dbHelper.GetDataTable(this.dbHelper.GetPaerSql(nameof (WorkFlowArchives), "ID,FlowName,StepName,Title,WriteTime", stringBuilder.ToString(), order.IsNullOrEmpty() ? "WriteTime DESC" : order, pageSize, pageNumber, out count, sqlParameterList1.ToArray()), sqlParameterList1.ToArray());
    }
  }
}
