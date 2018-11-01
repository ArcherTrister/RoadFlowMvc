// Decompiled with JetBrains decompiler
// Type: RoadFlow.Data.MySql.WorkFlowArchives
// Assembly: RoadFlow.Data.MySql, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 29B652D7-5F6F-4A7D-AD1C-9F2C643FD784
// Assembly location: C:\inetpub\wwwroot\RoadFlowMvc\bin\RoadFlow.Data.MySql.dll

using MySql.Data.MySqlClient;
using RoadFlow.Data.Interface;
using RoadFlow.Utility;
using System;
using System.Collections.Generic;
using System.Data;
using System.Text;

namespace RoadFlow.Data.MySql
{
  public class WorkFlowArchives : IWorkFlowArchives
  {
    private DBHelper dbHelper = new DBHelper();

    public int Add(RoadFlow.Data.Model.WorkFlowArchives model)
    {
      string sql = "INSERT INTO workflowarchives\r\n\t\t\t\t(ID,FlowID,StepID,FlowName,StepName,TaskID,GroupID,InstanceID,Title,Contents,Comments,WriteTime) \r\n\t\t\t\tVALUES(@ID,@FlowID,@StepID,@FlowName,@StepName,@TaskID,@GroupID,@InstanceID,@Title,@Contents,@Comments,@WriteTime)";
      MySqlParameter[] mySqlParameterArray = new MySqlParameter[12];
      int index1 = 0;
      MySqlParameter mySqlParameter1 = new MySqlParameter("@ID", MySqlDbType.VarChar, 36);
      mySqlParameter1.Value = (object) model.ID;
      mySqlParameterArray[index1] = mySqlParameter1;
      int index2 = 1;
      MySqlParameter mySqlParameter2 = new MySqlParameter("@FlowID", MySqlDbType.VarChar, 36);
      mySqlParameter2.Value = (object) model.FlowID;
      mySqlParameterArray[index2] = mySqlParameter2;
      int index3 = 2;
      MySqlParameter mySqlParameter3 = new MySqlParameter("@StepID", MySqlDbType.VarChar, 36);
      mySqlParameter3.Value = (object) model.StepID;
      mySqlParameterArray[index3] = mySqlParameter3;
      int index4 = 3;
      MySqlParameter mySqlParameter4 = new MySqlParameter("@FlowName", MySqlDbType.Text, -1);
      mySqlParameter4.Value = (object) model.FlowName;
      mySqlParameterArray[index4] = mySqlParameter4;
      int index5 = 4;
      MySqlParameter mySqlParameter5 = new MySqlParameter("@StepName", MySqlDbType.Text, -1);
      mySqlParameter5.Value = (object) model.StepName;
      mySqlParameterArray[index5] = mySqlParameter5;
      int index6 = 5;
      MySqlParameter mySqlParameter6 = new MySqlParameter("@TaskID", MySqlDbType.VarChar, 36);
      mySqlParameter6.Value = (object) model.TaskID;
      mySqlParameterArray[index6] = mySqlParameter6;
      int index7 = 6;
      MySqlParameter mySqlParameter7 = new MySqlParameter("@GroupID", MySqlDbType.VarChar, 36);
      mySqlParameter7.Value = (object) model.GroupID;
      mySqlParameterArray[index7] = mySqlParameter7;
      int index8 = 7;
      MySqlParameter mySqlParameter8 = new MySqlParameter("@InstanceID", MySqlDbType.Text, -1);
      mySqlParameter8.Value = (object) model.InstanceID;
      mySqlParameterArray[index8] = mySqlParameter8;
      int index9 = 8;
      MySqlParameter mySqlParameter9 = new MySqlParameter("@Title", MySqlDbType.Text, -1);
      mySqlParameter9.Value = (object) model.Title;
      mySqlParameterArray[index9] = mySqlParameter9;
      int index10 = 9;
      MySqlParameter mySqlParameter10 = new MySqlParameter("@Contents", MySqlDbType.LongText, -1);
      mySqlParameter10.Value = (object) model.Contents;
      mySqlParameterArray[index10] = mySqlParameter10;
      int index11 = 10;
      MySqlParameter mySqlParameter11 = new MySqlParameter("@Comments", MySqlDbType.LongText, -1);
      mySqlParameter11.Value = (object) model.Comments;
      mySqlParameterArray[index11] = mySqlParameter11;
      int index12 = 11;
      MySqlParameter mySqlParameter12 = new MySqlParameter("@WriteTime", MySqlDbType.DateTime, -1);
      mySqlParameter12.Value = (object) model.WriteTime;
      mySqlParameterArray[index12] = mySqlParameter12;
      MySqlParameter[] parameter = mySqlParameterArray;
      return this.dbHelper.Execute(sql, parameter, false);
    }

    public int Update(RoadFlow.Data.Model.WorkFlowArchives model)
    {
      string sql = "UPDATE workflowarchives SET \r\n\t\t\t\tFlowID=@FlowID,StepID=@StepID,FlowName=@FlowName,StepName=@StepName,TaskID=@TaskID,GroupID=@GroupID,InstanceID=@InstanceID,Title=@Title,Contents=@Contents,Comments=@Comments,WriteTime=@WriteTime\r\n\t\t\t\tWHERE ID=@ID";
      MySqlParameter[] mySqlParameterArray = new MySqlParameter[12];
      int index1 = 0;
      MySqlParameter mySqlParameter1 = new MySqlParameter("@FlowID", MySqlDbType.VarChar, 36);
      mySqlParameter1.Value = (object) model.FlowID;
      mySqlParameterArray[index1] = mySqlParameter1;
      int index2 = 1;
      MySqlParameter mySqlParameter2 = new MySqlParameter("@StepID", MySqlDbType.VarChar, 36);
      mySqlParameter2.Value = (object) model.StepID;
      mySqlParameterArray[index2] = mySqlParameter2;
      int index3 = 2;
      MySqlParameter mySqlParameter3 = new MySqlParameter("@FlowName", MySqlDbType.Text, -1);
      mySqlParameter3.Value = (object) model.FlowName;
      mySqlParameterArray[index3] = mySqlParameter3;
      int index4 = 3;
      MySqlParameter mySqlParameter4 = new MySqlParameter("@StepName", MySqlDbType.Text, -1);
      mySqlParameter4.Value = (object) model.StepName;
      mySqlParameterArray[index4] = mySqlParameter4;
      int index5 = 4;
      MySqlParameter mySqlParameter5 = new MySqlParameter("@TaskID", MySqlDbType.VarChar, 36);
      mySqlParameter5.Value = (object) model.TaskID;
      mySqlParameterArray[index5] = mySqlParameter5;
      int index6 = 5;
      MySqlParameter mySqlParameter6 = new MySqlParameter("@GroupID", MySqlDbType.VarChar, 36);
      mySqlParameter6.Value = (object) model.GroupID;
      mySqlParameterArray[index6] = mySqlParameter6;
      int index7 = 6;
      MySqlParameter mySqlParameter7 = new MySqlParameter("@InstanceID", MySqlDbType.Text, -1);
      mySqlParameter7.Value = (object) model.InstanceID;
      mySqlParameterArray[index7] = mySqlParameter7;
      int index8 = 7;
      MySqlParameter mySqlParameter8 = new MySqlParameter("@Title", MySqlDbType.Text, -1);
      mySqlParameter8.Value = (object) model.Title;
      mySqlParameterArray[index8] = mySqlParameter8;
      int index9 = 8;
      MySqlParameter mySqlParameter9 = new MySqlParameter("@Contents", MySqlDbType.LongText, -1);
      mySqlParameter9.Value = (object) model.Contents;
      mySqlParameterArray[index9] = mySqlParameter9;
      int index10 = 9;
      MySqlParameter mySqlParameter10 = new MySqlParameter("@Comments", MySqlDbType.LongText, -1);
      mySqlParameter10.Value = (object) model.Comments;
      mySqlParameterArray[index10] = mySqlParameter10;
      int index11 = 10;
      MySqlParameter mySqlParameter11 = new MySqlParameter("@WriteTime", MySqlDbType.DateTime, -1);
      mySqlParameter11.Value = (object) model.WriteTime;
      mySqlParameterArray[index11] = mySqlParameter11;
      int index12 = 11;
      MySqlParameter mySqlParameter12 = new MySqlParameter("@ID", MySqlDbType.VarChar, 36);
      mySqlParameter12.Value = (object) model.ID;
      mySqlParameterArray[index12] = mySqlParameter12;
      MySqlParameter[] parameter = mySqlParameterArray;
      return this.dbHelper.Execute(sql, parameter, false);
    }

    public int Delete(Guid id)
    {
      string sql = "DELETE FROM workflowarchives WHERE ID=@ID";
      MySqlParameter[] mySqlParameterArray = new MySqlParameter[1];
      int index = 0;
      MySqlParameter mySqlParameter = new MySqlParameter("@ID", MySqlDbType.VarChar, 36);
      mySqlParameter.Value = (object) id.ToString();
      mySqlParameterArray[index] = mySqlParameter;
      MySqlParameter[] parameter = mySqlParameterArray;
      return this.dbHelper.Execute(sql, parameter, false);
    }

    private List<RoadFlow.Data.Model.WorkFlowArchives> DataReaderToList(MySqlDataReader dataReader)
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
      MySqlDataReader dataReader = this.dbHelper.GetDataReader("SELECT * FROM workflowarchives");
      List<RoadFlow.Data.Model.WorkFlowArchives> list = this.DataReaderToList(dataReader);
      dataReader.Close();
      return list;
    }

    public long GetCount()
    {
      long result;
      if (!long.TryParse(this.dbHelper.GetFieldValue("SELECT COUNT(*) FROM workflowarchives"), out result))
        return 0;
      return result;
    }

    public RoadFlow.Data.Model.WorkFlowArchives Get(Guid id)
    {
      string sql = "SELECT * FROM workflowarchives WHERE ID=@ID";
      MySqlParameter[] mySqlParameterArray = new MySqlParameter[1];
      int index = 0;
      MySqlParameter mySqlParameter = new MySqlParameter("@ID", MySqlDbType.VarChar, 36);
      mySqlParameter.Value = (object) id.ToString();
      mySqlParameterArray[index] = mySqlParameter;
      MySqlParameter[] parameter = mySqlParameterArray;
      MySqlDataReader dataReader = this.dbHelper.GetDataReader(sql, parameter);
      List<RoadFlow.Data.Model.WorkFlowArchives> list = this.DataReaderToList(dataReader);
      dataReader.Close();
      if (list.Count <= 0)
        return (RoadFlow.Data.Model.WorkFlowArchives) null;
      return list[0];
    }

    public DataTable GetPagerData(out string pager, string query = "", string title = "", string flowIDString = "")
    {
      StringBuilder stringBuilder = new StringBuilder();
      List<MySqlParameter> mySqlParameterList1 = new List<MySqlParameter>();
      if (!title.IsNullOrEmpty())
      {
        stringBuilder.Append("AND INSTR(Title,@Title)>0 ");
        List<MySqlParameter> mySqlParameterList2 = mySqlParameterList1;
        MySqlParameter mySqlParameter = new MySqlParameter("@Title", MySqlDbType.VarChar);
        mySqlParameter.Value = (object) title;
        mySqlParameterList2.Add(mySqlParameter);
      }
      if (!flowIDString.IsNullOrEmpty())
        stringBuilder.AppendFormat("AND FlowID IN({0}) ", (object) Tools.GetSqlInString(flowIDString, true, ","));
      int pageSize = Tools.GetPageSize();
      int pageNumber = Tools.GetPageNumber();
      long count;
      string paerSql = this.dbHelper.GetPaerSql(nameof (WorkFlowArchives), "*", stringBuilder.ToString(), "WriteTime DESC", pageSize, pageNumber, out count, mySqlParameterList1.ToArray());
      pager = Tools.GetPagerHtml(count, pageSize, pageNumber, query);
      return this.dbHelper.GetDataTable(paerSql, mySqlParameterList1.ToArray());
    }

    public DataTable GetPagerData(out long count, int pageSize, int pageNumber, string title = "", string flowIDString = "", string date1 = "", string date2 = "", string order = "")
    {
      StringBuilder stringBuilder = new StringBuilder();
      List<MySqlParameter> mySqlParameterList1 = new List<MySqlParameter>();
      if (!title.IsNullOrEmpty())
      {
        stringBuilder.Append("AND INSTR(Title,@Title)>0 ");
        List<MySqlParameter> mySqlParameterList2 = mySqlParameterList1;
        MySqlParameter mySqlParameter = new MySqlParameter("@Title", MySqlDbType.VarChar);
        mySqlParameter.Value = (object) title;
        mySqlParameterList2.Add(mySqlParameter);
      }
      if (flowIDString.IsGuid())
      {
        stringBuilder.Append("AND FlowID=@FlowID ");
        mySqlParameterList1.Add(new MySqlParameter("@FlowID", (object) flowIDString));
      }
      if (date1.IsDateTime())
      {
        stringBuilder.Append("AND WriteTime>=@WriteTime1 ");
        mySqlParameterList1.Add(new MySqlParameter("@WriteTime1", (object) date1));
      }
      if (date2.IsDateTime())
      {
        stringBuilder.Append("AND WriteTime<=@WriteTime2 ");
        mySqlParameterList1.Add(new MySqlParameter("@WriteTime2", (object) date2.ToDateTime().ToString("yyyy-MM-dd 23:59:59")));
      }
      return this.dbHelper.GetDataTable(this.dbHelper.GetPaerSql(nameof (WorkFlowArchives), "ID,FlowName,StepName,Title,WriteTime", stringBuilder.ToString(), order.IsNullOrEmpty() ? "WriteTime DESC" : order, pageSize, pageNumber, out count, mySqlParameterList1.ToArray()), mySqlParameterList1.ToArray());
    }
  }
}
