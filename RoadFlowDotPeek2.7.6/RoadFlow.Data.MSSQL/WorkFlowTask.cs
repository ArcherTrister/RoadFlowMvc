// Decompiled with JetBrains decompiler
// Type: RoadFlow.Data.MSSQL.WorkFlowTask
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
  public class WorkFlowTask : IWorkFlowTask
  {
    private DBHelper dbHelper = new DBHelper();

    public int Add(RoadFlow.Data.Model.WorkFlowTask model)
    {
      string sql = "INSERT INTO WorkFlowTask\r\n\t\t\t\t(ID,PrevID,PrevStepID,FlowID,StepID,StepName,InstanceID,GroupID,Type,Title,SenderID,SenderName,SenderTime,ReceiveID,ReceiveName,ReceiveTime,OpenTime,CompletedTime,CompletedTime1,Comment,IsSign,Status,Note,Sort,SubFlowGroupID,OtherType,Files,IsExpiredAutoSubmit,StepSort) \r\n\t\t\t\tVALUES(@ID,@PrevID,@PrevStepID,@FlowID,@StepID,@StepName,@InstanceID,@GroupID,@Type,@Title,@SenderID,@SenderName,@SenderTime,@ReceiveID,@ReceiveName,@ReceiveTime,@OpenTime,@CompletedTime,@CompletedTime1,@Comment,@IsSign,@Status,@Note,@Sort,@SubFlowGroupID,@OtherType,@Files,@IsExpiredAutoSubmit,@StepSort)";
      SqlParameter[] sqlParameterArray = new SqlParameter[29];
      int index1 = 0;
      SqlParameter sqlParameter1 = new SqlParameter("@ID", SqlDbType.UniqueIdentifier, -1);
      sqlParameter1.Value = (object) model.ID;
      sqlParameterArray[index1] = sqlParameter1;
      int index2 = 1;
      SqlParameter sqlParameter2 = new SqlParameter("@PrevID", SqlDbType.UniqueIdentifier, -1);
      sqlParameter2.Value = (object) model.PrevID;
      sqlParameterArray[index2] = sqlParameter2;
      int index3 = 2;
      SqlParameter sqlParameter3 = new SqlParameter("@PrevStepID", SqlDbType.UniqueIdentifier, -1);
      sqlParameter3.Value = (object) model.PrevStepID;
      sqlParameterArray[index3] = sqlParameter3;
      int index4 = 3;
      SqlParameter sqlParameter4 = new SqlParameter("@FlowID", SqlDbType.UniqueIdentifier, -1);
      sqlParameter4.Value = (object) model.FlowID;
      sqlParameterArray[index4] = sqlParameter4;
      int index5 = 4;
      SqlParameter sqlParameter5 = new SqlParameter("@StepID", SqlDbType.UniqueIdentifier, -1);
      sqlParameter5.Value = (object) model.StepID;
      sqlParameterArray[index5] = sqlParameter5;
      int index6 = 5;
      SqlParameter sqlParameter6 = new SqlParameter("@StepName", SqlDbType.NVarChar, 1000);
      sqlParameter6.Value = (object) model.StepName;
      sqlParameterArray[index6] = sqlParameter6;
      int index7 = 6;
      SqlParameter sqlParameter7 = new SqlParameter("@InstanceID", SqlDbType.VarChar, 50);
      sqlParameter7.Value = (object) model.InstanceID;
      sqlParameterArray[index7] = sqlParameter7;
      int index8 = 7;
      SqlParameter sqlParameter8 = new SqlParameter("@GroupID", SqlDbType.UniqueIdentifier, -1);
      sqlParameter8.Value = (object) model.GroupID;
      sqlParameterArray[index8] = sqlParameter8;
      int index9 = 8;
      SqlParameter sqlParameter9 = new SqlParameter("@Type", SqlDbType.Int, -1);
      sqlParameter9.Value = (object) model.Type;
      sqlParameterArray[index9] = sqlParameter9;
      int index10 = 9;
      SqlParameter sqlParameter10 = new SqlParameter("@Title", SqlDbType.NVarChar, 1000);
      sqlParameter10.Value = (object) model.Title;
      sqlParameterArray[index10] = sqlParameter10;
      int index11 = 10;
      SqlParameter sqlParameter11 = new SqlParameter("@SenderID", SqlDbType.UniqueIdentifier, -1);
      sqlParameter11.Value = (object) model.SenderID;
      sqlParameterArray[index11] = sqlParameter11;
      int index12 = 11;
      SqlParameter sqlParameter12 = new SqlParameter("@SenderName", SqlDbType.NVarChar, 100);
      sqlParameter12.Value = (object) model.SenderName;
      sqlParameterArray[index12] = sqlParameter12;
      int index13 = 12;
      SqlParameter sqlParameter13 = new SqlParameter("@SenderTime", SqlDbType.DateTime, 8);
      sqlParameter13.Value = (object) model.SenderTime;
      sqlParameterArray[index13] = sqlParameter13;
      int index14 = 13;
      SqlParameter sqlParameter14 = new SqlParameter("@ReceiveID", SqlDbType.UniqueIdentifier, -1);
      sqlParameter14.Value = (object) model.ReceiveID;
      sqlParameterArray[index14] = sqlParameter14;
      int index15 = 14;
      SqlParameter sqlParameter15 = new SqlParameter("@ReceiveName", SqlDbType.NVarChar, 100);
      sqlParameter15.Value = (object) model.ReceiveName;
      sqlParameterArray[index15] = sqlParameter15;
      int index16 = 15;
      SqlParameter sqlParameter16 = new SqlParameter("@ReceiveTime", SqlDbType.DateTime, 8);
      sqlParameter16.Value = (object) model.ReceiveTime;
      sqlParameterArray[index16] = sqlParameter16;
      int index17 = 16;
      SqlParameter sqlParameter17;
      if (model.OpenTime.HasValue)
      {
        SqlParameter sqlParameter18 = new SqlParameter("@OpenTime", SqlDbType.DateTime, 8);
        sqlParameter18.Value = (object) model.OpenTime;
        sqlParameter17 = sqlParameter18;
      }
      else
      {
        sqlParameter17 = new SqlParameter("@OpenTime", SqlDbType.DateTime, 8);
        sqlParameter17.Value = (object) DBNull.Value;
      }
      sqlParameterArray[index17] = sqlParameter17;
      int index18 = 17;
      DateTime? nullable1 = model.CompletedTime;
      SqlParameter sqlParameter19;
      if (nullable1.HasValue)
      {
        SqlParameter sqlParameter18 = new SqlParameter("@CompletedTime", SqlDbType.DateTime, 8);
        sqlParameter18.Value = (object) model.CompletedTime;
        sqlParameter19 = sqlParameter18;
      }
      else
      {
        sqlParameter19 = new SqlParameter("@CompletedTime", SqlDbType.DateTime, 8);
        sqlParameter19.Value = (object) DBNull.Value;
      }
      sqlParameterArray[index18] = sqlParameter19;
      int index19 = 18;
      nullable1 = model.CompletedTime1;
      SqlParameter sqlParameter20;
      if (nullable1.HasValue)
      {
        SqlParameter sqlParameter18 = new SqlParameter("@CompletedTime1", SqlDbType.DateTime, 8);
        sqlParameter18.Value = (object) model.CompletedTime1;
        sqlParameter20 = sqlParameter18;
      }
      else
      {
        sqlParameter20 = new SqlParameter("@CompletedTime1", SqlDbType.DateTime, 8);
        sqlParameter20.Value = (object) DBNull.Value;
      }
      sqlParameterArray[index19] = sqlParameter20;
      int index20 = 19;
      SqlParameter sqlParameter21;
      if (model.Comment != null)
      {
        SqlParameter sqlParameter18 = new SqlParameter("@Comment", SqlDbType.VarChar, -1);
        sqlParameter18.Value = (object) model.Comment;
        sqlParameter21 = sqlParameter18;
      }
      else
      {
        sqlParameter21 = new SqlParameter("@Comment", SqlDbType.VarChar, -1);
        sqlParameter21.Value = (object) DBNull.Value;
      }
      sqlParameterArray[index20] = sqlParameter21;
      int index21 = 20;
      int? nullable2 = model.IsSign;
      SqlParameter sqlParameter22;
      if (nullable2.HasValue)
      {
        SqlParameter sqlParameter18 = new SqlParameter("@IsSign", SqlDbType.Int, -1);
        sqlParameter18.Value = (object) model.IsSign;
        sqlParameter22 = sqlParameter18;
      }
      else
      {
        sqlParameter22 = new SqlParameter("@IsSign", SqlDbType.Int, -1);
        sqlParameter22.Value = (object) DBNull.Value;
      }
      sqlParameterArray[index21] = sqlParameter22;
      int index22 = 21;
      SqlParameter sqlParameter23 = new SqlParameter("@Status", SqlDbType.Int, -1);
      sqlParameter23.Value = (object) model.Status;
      sqlParameterArray[index22] = sqlParameter23;
      int index23 = 22;
      SqlParameter sqlParameter24;
      if (model.Note != null)
      {
        SqlParameter sqlParameter18 = new SqlParameter("@Note", SqlDbType.NVarChar, -1);
        sqlParameter18.Value = (object) model.Note;
        sqlParameter24 = sqlParameter18;
      }
      else
      {
        sqlParameter24 = new SqlParameter("@Note", SqlDbType.NVarChar, -1);
        sqlParameter24.Value = (object) DBNull.Value;
      }
      sqlParameterArray[index23] = sqlParameter24;
      int index24 = 23;
      SqlParameter sqlParameter25 = new SqlParameter("@Sort", SqlDbType.Int, -1);
      sqlParameter25.Value = (object) model.Sort;
      sqlParameterArray[index24] = sqlParameter25;
      int index25 = 24;
      SqlParameter sqlParameter26;
      if (model.SubFlowGroupID != null)
      {
        SqlParameter sqlParameter18 = new SqlParameter("@SubFlowGroupID", SqlDbType.VarChar, -1);
        sqlParameter18.Value = (object) model.SubFlowGroupID;
        sqlParameter26 = sqlParameter18;
      }
      else
      {
        sqlParameter26 = new SqlParameter("@SubFlowGroupID", SqlDbType.VarChar, -1);
        sqlParameter26.Value = (object) DBNull.Value;
      }
      sqlParameterArray[index25] = sqlParameter26;
      int index26 = 25;
      nullable2 = model.OtherType;
      SqlParameter sqlParameter27;
      if (nullable2.HasValue)
      {
        SqlParameter sqlParameter18 = new SqlParameter("@OtherType", SqlDbType.Int, -1);
        sqlParameter18.Value = (object) model.OtherType;
        sqlParameter27 = sqlParameter18;
      }
      else
      {
        sqlParameter27 = new SqlParameter("@OtherType", SqlDbType.Int, -1);
        sqlParameter27.Value = (object) DBNull.Value;
      }
      sqlParameterArray[index26] = sqlParameter27;
      int index27 = 26;
      SqlParameter sqlParameter28;
      if (model.Files != null)
      {
        SqlParameter sqlParameter18 = new SqlParameter("@Files", SqlDbType.VarChar, -1);
        sqlParameter18.Value = (object) model.Files;
        sqlParameter28 = sqlParameter18;
      }
      else
      {
        sqlParameter28 = new SqlParameter("@Files", SqlDbType.VarChar, -1);
        sqlParameter28.Value = (object) DBNull.Value;
      }
      sqlParameterArray[index27] = sqlParameter28;
      int index28 = 27;
      SqlParameter sqlParameter29 = new SqlParameter("@IsExpiredAutoSubmit", SqlDbType.Int, -1);
      sqlParameter29.Value = (object) model.IsExpiredAutoSubmit;
      sqlParameterArray[index28] = sqlParameter29;
      int index29 = 28;
      SqlParameter sqlParameter30 = new SqlParameter("@StepSort", SqlDbType.Int, -1);
      sqlParameter30.Value = (object) model.StepSort;
      sqlParameterArray[index29] = sqlParameter30;
      SqlParameter[] parameter = sqlParameterArray;
      return this.dbHelper.Execute(sql, parameter, false);
    }

    public int Update(RoadFlow.Data.Model.WorkFlowTask model)
    {
      string sql = "UPDATE WorkFlowTask SET \r\n\t\t\t\tPrevID=@PrevID,PrevStepID=@PrevStepID,FlowID=@FlowID,StepID=@StepID,StepName=@StepName,InstanceID=@InstanceID,GroupID=@GroupID,Type=@Type,Title=@Title,SenderID=@SenderID,SenderName=@SenderName,SenderTime=@SenderTime,ReceiveID=@ReceiveID,ReceiveName=@ReceiveName,ReceiveTime=@ReceiveTime,OpenTime=@OpenTime,CompletedTime=@CompletedTime,CompletedTime1=@CompletedTime1,Comment=@Comment,IsSign=@IsSign,Status=@Status,Note=@Note,Sort=@Sort,SubFlowGroupID=@SubFlowGroupID,OtherType=@OtherType,Files=@Files,IsExpiredAutoSubmit=@IsExpiredAutoSubmit,StepSort=@StepSort  \r\n\t\t\t\tWHERE ID=@ID";
      SqlParameter[] sqlParameterArray = new SqlParameter[29];
      int index1 = 0;
      SqlParameter sqlParameter1 = new SqlParameter("@PrevID", SqlDbType.UniqueIdentifier, -1);
      sqlParameter1.Value = (object) model.PrevID;
      sqlParameterArray[index1] = sqlParameter1;
      int index2 = 1;
      SqlParameter sqlParameter2 = new SqlParameter("@PrevStepID", SqlDbType.UniqueIdentifier, -1);
      sqlParameter2.Value = (object) model.PrevStepID;
      sqlParameterArray[index2] = sqlParameter2;
      int index3 = 2;
      SqlParameter sqlParameter3 = new SqlParameter("@FlowID", SqlDbType.UniqueIdentifier, -1);
      sqlParameter3.Value = (object) model.FlowID;
      sqlParameterArray[index3] = sqlParameter3;
      int index4 = 3;
      SqlParameter sqlParameter4 = new SqlParameter("@StepID", SqlDbType.UniqueIdentifier, -1);
      sqlParameter4.Value = (object) model.StepID;
      sqlParameterArray[index4] = sqlParameter4;
      int index5 = 4;
      SqlParameter sqlParameter5 = new SqlParameter("@StepName", SqlDbType.NVarChar, 1000);
      sqlParameter5.Value = (object) model.StepName;
      sqlParameterArray[index5] = sqlParameter5;
      int index6 = 5;
      SqlParameter sqlParameter6 = new SqlParameter("@InstanceID", SqlDbType.VarChar, 50);
      sqlParameter6.Value = (object) model.InstanceID;
      sqlParameterArray[index6] = sqlParameter6;
      int index7 = 6;
      SqlParameter sqlParameter7 = new SqlParameter("@GroupID", SqlDbType.UniqueIdentifier, -1);
      sqlParameter7.Value = (object) model.GroupID;
      sqlParameterArray[index7] = sqlParameter7;
      int index8 = 7;
      SqlParameter sqlParameter8 = new SqlParameter("@Type", SqlDbType.Int, -1);
      sqlParameter8.Value = (object) model.Type;
      sqlParameterArray[index8] = sqlParameter8;
      int index9 = 8;
      SqlParameter sqlParameter9 = new SqlParameter("@Title", SqlDbType.NVarChar, 1000);
      sqlParameter9.Value = (object) model.Title;
      sqlParameterArray[index9] = sqlParameter9;
      int index10 = 9;
      SqlParameter sqlParameter10 = new SqlParameter("@SenderID", SqlDbType.UniqueIdentifier, -1);
      sqlParameter10.Value = (object) model.SenderID;
      sqlParameterArray[index10] = sqlParameter10;
      int index11 = 10;
      SqlParameter sqlParameter11 = new SqlParameter("@SenderName", SqlDbType.NVarChar, 100);
      sqlParameter11.Value = (object) model.SenderName;
      sqlParameterArray[index11] = sqlParameter11;
      int index12 = 11;
      SqlParameter sqlParameter12 = new SqlParameter("@SenderTime", SqlDbType.DateTime, 8);
      sqlParameter12.Value = (object) model.SenderTime;
      sqlParameterArray[index12] = sqlParameter12;
      int index13 = 12;
      SqlParameter sqlParameter13 = new SqlParameter("@ReceiveID", SqlDbType.UniqueIdentifier, -1);
      sqlParameter13.Value = (object) model.ReceiveID;
      sqlParameterArray[index13] = sqlParameter13;
      int index14 = 13;
      SqlParameter sqlParameter14 = new SqlParameter("@ReceiveName", SqlDbType.NVarChar, 100);
      sqlParameter14.Value = (object) model.ReceiveName;
      sqlParameterArray[index14] = sqlParameter14;
      int index15 = 14;
      SqlParameter sqlParameter15 = new SqlParameter("@ReceiveTime", SqlDbType.DateTime, 8);
      sqlParameter15.Value = (object) model.ReceiveTime;
      sqlParameterArray[index15] = sqlParameter15;
      int index16 = 15;
      SqlParameter sqlParameter16;
      if (model.OpenTime.HasValue)
      {
        SqlParameter sqlParameter17 = new SqlParameter("@OpenTime", SqlDbType.DateTime, 8);
        sqlParameter17.Value = (object) model.OpenTime;
        sqlParameter16 = sqlParameter17;
      }
      else
      {
        sqlParameter16 = new SqlParameter("@OpenTime", SqlDbType.DateTime, 8);
        sqlParameter16.Value = (object) DBNull.Value;
      }
      sqlParameterArray[index16] = sqlParameter16;
      int index17 = 16;
      DateTime? nullable1 = model.CompletedTime;
      SqlParameter sqlParameter18;
      if (nullable1.HasValue)
      {
        SqlParameter sqlParameter17 = new SqlParameter("@CompletedTime", SqlDbType.DateTime, 8);
        sqlParameter17.Value = (object) model.CompletedTime;
        sqlParameter18 = sqlParameter17;
      }
      else
      {
        sqlParameter18 = new SqlParameter("@CompletedTime", SqlDbType.DateTime, 8);
        sqlParameter18.Value = (object) DBNull.Value;
      }
      sqlParameterArray[index17] = sqlParameter18;
      int index18 = 17;
      nullable1 = model.CompletedTime1;
      SqlParameter sqlParameter19;
      if (nullable1.HasValue)
      {
        SqlParameter sqlParameter17 = new SqlParameter("@CompletedTime1", SqlDbType.DateTime, 8);
        sqlParameter17.Value = (object) model.CompletedTime1;
        sqlParameter19 = sqlParameter17;
      }
      else
      {
        sqlParameter19 = new SqlParameter("@CompletedTime1", SqlDbType.DateTime, 8);
        sqlParameter19.Value = (object) DBNull.Value;
      }
      sqlParameterArray[index18] = sqlParameter19;
      int index19 = 18;
      SqlParameter sqlParameter20;
      if (model.Comment != null)
      {
        SqlParameter sqlParameter17 = new SqlParameter("@Comment", SqlDbType.VarChar, -1);
        sqlParameter17.Value = (object) model.Comment;
        sqlParameter20 = sqlParameter17;
      }
      else
      {
        sqlParameter20 = new SqlParameter("@Comment", SqlDbType.VarChar, -1);
        sqlParameter20.Value = (object) DBNull.Value;
      }
      sqlParameterArray[index19] = sqlParameter20;
      int index20 = 19;
      int? nullable2 = model.IsSign;
      SqlParameter sqlParameter21;
      if (nullable2.HasValue)
      {
        SqlParameter sqlParameter17 = new SqlParameter("@IsSign", SqlDbType.Int, -1);
        sqlParameter17.Value = (object) model.IsSign;
        sqlParameter21 = sqlParameter17;
      }
      else
      {
        sqlParameter21 = new SqlParameter("@IsSign", SqlDbType.Int, -1);
        sqlParameter21.Value = (object) DBNull.Value;
      }
      sqlParameterArray[index20] = sqlParameter21;
      int index21 = 20;
      SqlParameter sqlParameter22 = new SqlParameter("@Status", SqlDbType.Int, -1);
      sqlParameter22.Value = (object) model.Status;
      sqlParameterArray[index21] = sqlParameter22;
      int index22 = 21;
      SqlParameter sqlParameter23;
      if (model.Note != null)
      {
        SqlParameter sqlParameter17 = new SqlParameter("@Note", SqlDbType.NVarChar, -1);
        sqlParameter17.Value = (object) model.Note;
        sqlParameter23 = sqlParameter17;
      }
      else
      {
        sqlParameter23 = new SqlParameter("@Note", SqlDbType.NVarChar, -1);
        sqlParameter23.Value = (object) DBNull.Value;
      }
      sqlParameterArray[index22] = sqlParameter23;
      int index23 = 22;
      SqlParameter sqlParameter24 = new SqlParameter("@Sort", SqlDbType.Int, -1);
      sqlParameter24.Value = (object) model.Sort;
      sqlParameterArray[index23] = sqlParameter24;
      int index24 = 23;
      SqlParameter sqlParameter25;
      if (model.SubFlowGroupID != null)
      {
        SqlParameter sqlParameter17 = new SqlParameter("@SubFlowGroupID", SqlDbType.VarChar, -1);
        sqlParameter17.Value = (object) model.SubFlowGroupID;
        sqlParameter25 = sqlParameter17;
      }
      else
      {
        sqlParameter25 = new SqlParameter("@SubFlowGroupID", SqlDbType.VarChar, -1);
        sqlParameter25.Value = (object) DBNull.Value;
      }
      sqlParameterArray[index24] = sqlParameter25;
      int index25 = 24;
      nullable2 = model.OtherType;
      SqlParameter sqlParameter26;
      if (nullable2.HasValue)
      {
        SqlParameter sqlParameter17 = new SqlParameter("@OtherType", SqlDbType.Int, -1);
        sqlParameter17.Value = (object) model.OtherType;
        sqlParameter26 = sqlParameter17;
      }
      else
      {
        sqlParameter26 = new SqlParameter("@OtherType", SqlDbType.Int, -1);
        sqlParameter26.Value = (object) DBNull.Value;
      }
      sqlParameterArray[index25] = sqlParameter26;
      int index26 = 25;
      SqlParameter sqlParameter27;
      if (model.Files != null)
      {
        SqlParameter sqlParameter17 = new SqlParameter("@Files", SqlDbType.VarChar, -1);
        sqlParameter17.Value = (object) model.Files;
        sqlParameter27 = sqlParameter17;
      }
      else
      {
        sqlParameter27 = new SqlParameter("@Files", SqlDbType.VarChar, -1);
        sqlParameter27.Value = (object) DBNull.Value;
      }
      sqlParameterArray[index26] = sqlParameter27;
      int index27 = 26;
      SqlParameter sqlParameter28 = new SqlParameter("@IsExpiredAutoSubmit", SqlDbType.Int, -1);
      sqlParameter28.Value = (object) model.IsExpiredAutoSubmit;
      sqlParameterArray[index27] = sqlParameter28;
      int index28 = 27;
      SqlParameter sqlParameter29 = new SqlParameter("@StepSort", SqlDbType.Int, -1);
      sqlParameter29.Value = (object) model.StepSort;
      sqlParameterArray[index28] = sqlParameter29;
      int index29 = 28;
      SqlParameter sqlParameter30 = new SqlParameter("@ID", SqlDbType.UniqueIdentifier, -1);
      sqlParameter30.Value = (object) model.ID;
      sqlParameterArray[index29] = sqlParameter30;
      SqlParameter[] parameter = sqlParameterArray;
      return this.dbHelper.Execute(sql, parameter, false);
    }

    public int Delete(Guid id)
    {
      string sql = "DELETE FROM WorkFlowTask WHERE ID=@ID";
      SqlParameter[] sqlParameterArray = new SqlParameter[1];
      int index = 0;
      SqlParameter sqlParameter = new SqlParameter("@ID", SqlDbType.UniqueIdentifier);
      sqlParameter.Value = (object) id;
      sqlParameterArray[index] = sqlParameter;
      SqlParameter[] parameter = sqlParameterArray;
      return this.dbHelper.Execute(sql, parameter, false);
    }

    private List<RoadFlow.Data.Model.WorkFlowTask> DataReaderToList(SqlDataReader dataReader)
    {
      List<RoadFlow.Data.Model.WorkFlowTask> workFlowTaskList = new List<RoadFlow.Data.Model.WorkFlowTask>();
      while (dataReader.Read())
      {
        RoadFlow.Data.Model.WorkFlowTask workFlowTask = new RoadFlow.Data.Model.WorkFlowTask();
        workFlowTask.ID = dataReader.GetGuid(0);
        workFlowTask.PrevID = dataReader.GetGuid(1);
        workFlowTask.PrevStepID = dataReader.GetGuid(2);
        workFlowTask.FlowID = dataReader.GetGuid(3);
        workFlowTask.StepID = dataReader.GetGuid(4);
        workFlowTask.StepName = dataReader.GetString(5);
        workFlowTask.InstanceID = dataReader.GetString(6);
        workFlowTask.GroupID = dataReader.GetGuid(7);
        workFlowTask.Type = dataReader.GetInt32(8);
        workFlowTask.Title = dataReader.GetString(9);
        workFlowTask.SenderID = dataReader.GetGuid(10);
        workFlowTask.SenderName = dataReader.GetString(11);
        workFlowTask.SenderTime = dataReader.GetDateTime(12);
        workFlowTask.ReceiveID = dataReader.GetGuid(13);
        workFlowTask.ReceiveName = dataReader.GetString(14);
        workFlowTask.ReceiveTime = dataReader.GetDateTime(15);
        if (!dataReader.IsDBNull(16))
          workFlowTask.OpenTime = new DateTime?(dataReader.GetDateTime(16));
        if (!dataReader.IsDBNull(17))
          workFlowTask.CompletedTime = new DateTime?(dataReader.GetDateTime(17));
        if (!dataReader.IsDBNull(18))
          workFlowTask.CompletedTime1 = new DateTime?(dataReader.GetDateTime(18));
        if (!dataReader.IsDBNull(19))
          workFlowTask.Comment = dataReader.GetString(19);
        if (!dataReader.IsDBNull(20))
          workFlowTask.IsSign = new int?(dataReader.GetInt32(20));
        workFlowTask.Status = dataReader.GetInt32(21);
        if (!dataReader.IsDBNull(22))
          workFlowTask.Note = dataReader.GetString(22);
        workFlowTask.Sort = dataReader.GetInt32(23);
        if (!dataReader.IsDBNull(24))
          workFlowTask.SubFlowGroupID = dataReader.GetString(24);
        if (!dataReader.IsDBNull(25))
          workFlowTask.OtherType = new int?(dataReader.GetInt32(25));
        if (!dataReader.IsDBNull(26))
          workFlowTask.Files = dataReader.GetString(26);
        workFlowTask.IsExpiredAutoSubmit = dataReader.GetInt32(27);
        workFlowTask.StepSort = dataReader.GetInt32(28);
        workFlowTaskList.Add(workFlowTask);
      }
      return workFlowTaskList;
    }

    public List<RoadFlow.Data.Model.WorkFlowTask> GetAll()
    {
      SqlDataReader dataReader = this.dbHelper.GetDataReader("SELECT * FROM WorkFlowTask");
      List<RoadFlow.Data.Model.WorkFlowTask> list = this.DataReaderToList(dataReader);
      dataReader.Close();
      return list;
    }

    public long GetCount()
    {
      long result;
      if (!long.TryParse(this.dbHelper.GetFieldValue("SELECT COUNT(*) FROM WorkFlowTask"), out result))
        return 0;
      return result;
    }

    public RoadFlow.Data.Model.WorkFlowTask Get(Guid id)
    {
      string sql = "SELECT * FROM WorkFlowTask WHERE ID=@ID";
      SqlParameter[] sqlParameterArray = new SqlParameter[1];
      int index = 0;
      SqlParameter sqlParameter = new SqlParameter("@ID", SqlDbType.UniqueIdentifier);
      sqlParameter.Value = (object) id;
      sqlParameterArray[index] = sqlParameter;
      SqlParameter[] parameter = sqlParameterArray;
      SqlDataReader dataReader = this.dbHelper.GetDataReader(sql, parameter);
      List<RoadFlow.Data.Model.WorkFlowTask> list = this.DataReaderToList(dataReader);
      dataReader.Close();
      if (list.Count <= 0)
        return (RoadFlow.Data.Model.WorkFlowTask) null;
      return list[0];
    }

    public int Delete(Guid flowID, Guid groupID)
    {
      string sql = "DELETE FROM WorkFlowTask WHERE GroupID=@GroupID";
      List<SqlParameter> sqlParameterList1 = new List<SqlParameter>();
      SqlParameter sqlParameter1 = new SqlParameter("@GroupID", SqlDbType.UniqueIdentifier);
      sqlParameter1.Value = (object) groupID;
      sqlParameterList1.Add(sqlParameter1);
      List<SqlParameter> sqlParameterList2 = sqlParameterList1;
      if (!flowID.IsEmptyGuid())
      {
        sql += " AND FlowID=@FlowID";
        List<SqlParameter> sqlParameterList3 = sqlParameterList2;
        SqlParameter sqlParameter2 = new SqlParameter("@FlowID", SqlDbType.UniqueIdentifier);
        sqlParameter2.Value = (object) flowID;
        sqlParameterList3.Add(sqlParameter2);
      }
      return this.dbHelper.Execute(sql, sqlParameterList2.ToArray(), false);
    }

    public void UpdateOpenTime(Guid id, DateTime openTime, bool isStatus = false)
    {
      string sql = "UPDATE WorkFlowTask SET OpenTime=@OpenTime " + (isStatus ? ", Status=1" : "") + " WHERE ID=@ID AND OpenTime IS NULL";
      SqlParameter[] sqlParameterArray = new SqlParameter[2];
      int index1 = 0;
      SqlParameter sqlParameter1;
      if (!(openTime == DateTime.MinValue))
      {
        SqlParameter sqlParameter2 = new SqlParameter("@OpenTime", SqlDbType.DateTime);
        sqlParameter2.Value = (object) openTime;
        sqlParameter1 = sqlParameter2;
      }
      else
      {
        sqlParameter1 = new SqlParameter("@OpenTime", SqlDbType.DateTime);
        sqlParameter1.Value = (object) DBNull.Value;
      }
      sqlParameterArray[index1] = sqlParameter1;
      int index2 = 1;
      SqlParameter sqlParameter3 = new SqlParameter("@ID", SqlDbType.UniqueIdentifier);
      sqlParameter3.Value = (object) id;
      sqlParameterArray[index2] = sqlParameter3;
      SqlParameter[] parameter = sqlParameterArray;
      this.dbHelper.Execute(sql, parameter, false);
    }

    public List<RoadFlow.Data.Model.WorkFlowTask> GetTasks(Guid userID, out string pager, string query = "", string title = "", string flowid = "", string sender = "", string date1 = "", string date2 = "", int type = 0)
    {
      List<SqlParameter> sqlParameterList1 = new List<SqlParameter>();
      StringBuilder stringBuilder = new StringBuilder("SELECT *,ROW_NUMBER() OVER(ORDER BY " + (type == 0 ? "SenderTime DESC" : "CompletedTime1 DESC") + ") AS PagerAutoRowNumber FROM WorkFlowTask WHERE ReceiveID=@ReceiveID");
      stringBuilder.Append(type == 0 ? " AND Status IN(0,1)" : " AND Status IN(2,3,4,5)");
      List<SqlParameter> sqlParameterList2 = sqlParameterList1;
      SqlParameter sqlParameter1 = new SqlParameter("@ReceiveID", SqlDbType.UniqueIdentifier);
      sqlParameter1.Value = (object) userID;
      sqlParameterList2.Add(sqlParameter1);
      if (!title.IsNullOrEmpty())
      {
        stringBuilder.Append(" AND CHARINDEX(@Title,Title)>0");
        List<SqlParameter> sqlParameterList3 = sqlParameterList1;
        SqlParameter sqlParameter2 = new SqlParameter("@Title", SqlDbType.NVarChar, 2000);
        sqlParameter2.Value = (object) title;
        sqlParameterList3.Add(sqlParameter2);
      }
      if (flowid.IsGuid())
      {
        stringBuilder.Append(" AND FlowID=@FlowID");
        List<SqlParameter> sqlParameterList3 = sqlParameterList1;
        SqlParameter sqlParameter2 = new SqlParameter("@FlowID", SqlDbType.UniqueIdentifier);
        sqlParameter2.Value = (object) flowid.ToGuid();
        sqlParameterList3.Add(sqlParameter2);
      }
      else if (!flowid.IsNullOrEmpty() && flowid.IndexOf(',') >= 0)
        stringBuilder.Append(" AND FlowID IN(" + Tools.GetSqlInString(flowid, true, ",") + ")");
      if (sender.IsGuid())
      {
        stringBuilder.Append(" AND SenderID=@SenderID");
        List<SqlParameter> sqlParameterList3 = sqlParameterList1;
        SqlParameter sqlParameter2 = new SqlParameter("@SenderID", SqlDbType.UniqueIdentifier);
        sqlParameter2.Value = (object) sender.ToGuid();
        sqlParameterList3.Add(sqlParameter2);
      }
      DateTime dateTime;
      if (date1.IsDateTime())
      {
        stringBuilder.Append(" AND ReceiveTime>=@ReceiveTime");
        List<SqlParameter> sqlParameterList3 = sqlParameterList1;
        SqlParameter sqlParameter2 = new SqlParameter("@ReceiveTime", SqlDbType.DateTime);
        dateTime = date1.ToDateTime();
        sqlParameter2.Value = (object) dateTime.Date;
        sqlParameterList3.Add(sqlParameter2);
      }
      if (date2.IsDateTime())
      {
        stringBuilder.Append(" AND SenderTime<=@ReceiveTime1");
        List<SqlParameter> sqlParameterList3 = sqlParameterList1;
        SqlParameter sqlParameter2 = new SqlParameter("@ReceiveTime1", SqlDbType.DateTime);
        dateTime = date2.ToDateTime();
        dateTime = dateTime.AddDays(1.0);
        sqlParameter2.Value = (object) dateTime.Date;
        sqlParameterList3.Add(sqlParameter2);
      }
      int pageSize = Tools.GetPageSize();
      int pageNumber = Tools.GetPageNumber();
      long count;
      string paerSql = this.dbHelper.GetPaerSql(stringBuilder.ToString(), pageSize, pageNumber, out count, sqlParameterList1.ToArray());
      pager = Tools.GetPagerHtml(count, pageSize, pageNumber, query);
      SqlDataReader dataReader = this.dbHelper.GetDataReader(paerSql, sqlParameterList1.ToArray());
      List<RoadFlow.Data.Model.WorkFlowTask> list = this.DataReaderToList(dataReader);
      dataReader.Close();
      return list;
    }

    public List<RoadFlow.Data.Model.WorkFlowTask> GetTasks(Guid userID, out long count, int size, int number, string title = "", string flowid = "", string sender = "", string date1 = "", string date2 = "", int type = 0, string order = "")
    {
      List<SqlParameter> sqlParameterList1 = new List<SqlParameter>();
      StringBuilder stringBuilder = new StringBuilder("SELECT *,ROW_NUMBER() OVER(ORDER BY " + (order.IsNullOrEmpty() ? (type == 0 ? "SenderTime DESC" : "CompletedTime1 DESC") : order) + ") AS PagerAutoRowNumber FROM WorkFlowTask WHERE ReceiveID=@ReceiveID");
      stringBuilder.Append(type == 0 ? " AND Status IN(0,1)" : " AND Status IN(2,3,4,5)");
      List<SqlParameter> sqlParameterList2 = sqlParameterList1;
      SqlParameter sqlParameter1 = new SqlParameter("@ReceiveID", SqlDbType.UniqueIdentifier);
      sqlParameter1.Value = (object) userID;
      sqlParameterList2.Add(sqlParameter1);
      if (!title.IsNullOrEmpty())
      {
        stringBuilder.Append(" AND CHARINDEX(@Title,Title)>0");
        List<SqlParameter> sqlParameterList3 = sqlParameterList1;
        SqlParameter sqlParameter2 = new SqlParameter("@Title", SqlDbType.NVarChar, 2000);
        sqlParameter2.Value = (object) title;
        sqlParameterList3.Add(sqlParameter2);
      }
      if (flowid.IsGuid())
      {
        stringBuilder.Append(" AND FlowID=@FlowID");
        List<SqlParameter> sqlParameterList3 = sqlParameterList1;
        SqlParameter sqlParameter2 = new SqlParameter("@FlowID", SqlDbType.UniqueIdentifier);
        sqlParameter2.Value = (object) flowid.ToGuid();
        sqlParameterList3.Add(sqlParameter2);
      }
      else if (!flowid.IsNullOrEmpty() && flowid.IndexOf(',') >= 0)
        stringBuilder.Append(" AND FlowID IN(" + Tools.GetSqlInString(flowid, true, ",") + ")");
      if (sender.IsGuid())
      {
        stringBuilder.Append(" AND SenderID=@SenderID");
        List<SqlParameter> sqlParameterList3 = sqlParameterList1;
        SqlParameter sqlParameter2 = new SqlParameter("@SenderID", SqlDbType.UniqueIdentifier);
        sqlParameter2.Value = (object) sender.ToGuid();
        sqlParameterList3.Add(sqlParameter2);
      }
      if (date1.IsDateTime())
      {
        stringBuilder.Append(" AND ReceiveTime>=@ReceiveTime");
        List<SqlParameter> sqlParameterList3 = sqlParameterList1;
        SqlParameter sqlParameter2 = new SqlParameter("@ReceiveTime", SqlDbType.DateTime);
        sqlParameter2.Value = (object) date1.ToDateTime().Date;
        sqlParameterList3.Add(sqlParameter2);
      }
      if (date2.IsDateTime())
      {
        stringBuilder.Append(" AND SenderTime<=@ReceiveTime1");
        List<SqlParameter> sqlParameterList3 = sqlParameterList1;
        SqlParameter sqlParameter2 = new SqlParameter("@ReceiveTime1", SqlDbType.DateTime);
        sqlParameter2.Value = (object) date2.ToDateTime().AddDays(1.0).Date;
        sqlParameterList3.Add(sqlParameter2);
      }
      SqlDataReader dataReader = this.dbHelper.GetDataReader(this.dbHelper.GetPaerSql(stringBuilder.ToString(), size, number, out count, sqlParameterList1.ToArray()), sqlParameterList1.ToArray());
      List<RoadFlow.Data.Model.WorkFlowTask> list = this.DataReaderToList(dataReader);
      dataReader.Close();
      return list;
    }

    public List<RoadFlow.Data.Model.WorkFlowTask> GetInstances(Guid[] flowID, Guid[] senderID, Guid[] receiveID, out string pager, string query = "", string title = "", string flowid = "", string date1 = "", string date2 = "", int status = 0)
    {
      List<SqlParameter> sqlParameterList1 = new List<SqlParameter>();
      StringBuilder stringBuilder = new StringBuilder("SELECT a.*,ROW_NUMBER() OVER(ORDER BY a.SenderTime DESC) AS PagerAutoRowNumber FROM WorkFlowTask a\r\n                WHERE a.ID=(SELECT TOP 1 ID FROM WorkFlowTask WHERE FlowID=a.FlowID AND GroupID=a.GroupID ORDER BY Sort DESC)");
      switch (status)
      {
        case 1:
          stringBuilder.Append(" AND a.Status IN(0,1,5)");
          break;
        case 2:
          stringBuilder.Append(" AND a.Status IN(2,3,4)");
          break;
      }
      if (flowID != null && flowID.Length != 0)
        stringBuilder.Append(string.Format(" AND a.FlowID IN({0})", (object) Tools.GetSqlInString<Guid>(flowID, true)));
      if (senderID != null && senderID.Length != 0)
      {
        if (senderID.Length == 1)
        {
          stringBuilder.Append(" AND a.SenderID=@SenderID");
          List<SqlParameter> sqlParameterList2 = sqlParameterList1;
          SqlParameter sqlParameter = new SqlParameter("@SenderID", SqlDbType.UniqueIdentifier);
          sqlParameter.Value = (object) senderID[0];
          sqlParameterList2.Add(sqlParameter);
        }
        else
          stringBuilder.Append(string.Format(" AND a.SenderID IN({0})", (object) Tools.GetSqlInString<Guid>(senderID, true)));
      }
      if (receiveID != null && receiveID.Length != 0)
      {
        if (senderID.Length == 1)
        {
          stringBuilder.Append(" AND a.ReceiveID=@ReceiveID");
          List<SqlParameter> sqlParameterList2 = sqlParameterList1;
          SqlParameter sqlParameter = new SqlParameter("@ReceiveID", SqlDbType.UniqueIdentifier);
          sqlParameter.Value = (object) receiveID[0];
          sqlParameterList2.Add(sqlParameter);
        }
        else
          stringBuilder.Append(string.Format(" AND a.ReceiveID IN({0})", (object) Tools.GetSqlInString<Guid>(receiveID, true)));
      }
      if (!title.IsNullOrEmpty())
      {
        stringBuilder.Append(" AND CHARINDEX(@Title,a.Title)>0");
        List<SqlParameter> sqlParameterList2 = sqlParameterList1;
        SqlParameter sqlParameter = new SqlParameter("@Title", SqlDbType.NVarChar, 2000);
        sqlParameter.Value = (object) title;
        sqlParameterList2.Add(sqlParameter);
      }
      if (flowid.IsGuid())
      {
        stringBuilder.Append(" AND a.FlowID=@FlowID");
        List<SqlParameter> sqlParameterList2 = sqlParameterList1;
        SqlParameter sqlParameter = new SqlParameter("@FlowID", SqlDbType.UniqueIdentifier);
        sqlParameter.Value = (object) flowid.ToGuid();
        sqlParameterList2.Add(sqlParameter);
      }
      else if (!flowid.IsNullOrEmpty() && flowid.IndexOf(',') >= 0)
        stringBuilder.Append(" AND a.FlowID IN(" + Tools.GetSqlInString(flowid, true, ",") + ")");
      if (date1.IsDateTime())
      {
        stringBuilder.Append(" AND a.SenderTime>=@SenderTime");
        List<SqlParameter> sqlParameterList2 = sqlParameterList1;
        SqlParameter sqlParameter = new SqlParameter("@SenderTime", SqlDbType.DateTime);
        sqlParameter.Value = (object) date1.ToDateTime().Date;
        sqlParameterList2.Add(sqlParameter);
      }
      if (date2.IsDateTime())
      {
        stringBuilder.Append(" AND a.SenderTime<=@SenderTime1");
        List<SqlParameter> sqlParameterList2 = sqlParameterList1;
        SqlParameter sqlParameter = new SqlParameter("@SenderTime1", SqlDbType.DateTime);
        sqlParameter.Value = (object) date2.ToDateTime().AddDays(1.0).Date;
        sqlParameterList2.Add(sqlParameter);
      }
      int pageSize = Tools.GetPageSize();
      int pageNumber = Tools.GetPageNumber();
      long count;
      string paerSql = this.dbHelper.GetPaerSql(stringBuilder.ToString(), pageSize, pageNumber, out count, sqlParameterList1.ToArray());
      pager = Tools.GetPagerHtml(count, pageSize, pageNumber, query);
      SqlDataReader dataReader = this.dbHelper.GetDataReader(paerSql, sqlParameterList1.ToArray());
      List<RoadFlow.Data.Model.WorkFlowTask> list = this.DataReaderToList(dataReader);
      dataReader.Close();
      return list;
    }

    public DataTable GetInstances1(Guid[] flowID, Guid[] senderID, Guid[] receiveID, out string pager, string query = "", string title = "", string flowid = "", string date1 = "", string date2 = "", int status = 0)
    {
      List<SqlParameter> sqlParameterList1 = new List<SqlParameter>();
      StringBuilder stringBuilder = new StringBuilder();
      switch (status)
      {
        case 1:
          stringBuilder.Append(" AND Status IN(0,1,5)");
          break;
        case 2:
          stringBuilder.Append(" AND Status IN(2,3,4)");
          break;
      }
      if (flowID != null && flowID.Length != 0)
        stringBuilder.Append(string.Format(" AND FlowID IN({0})", (object) Tools.GetSqlInString<Guid>(flowID, true)));
      if (senderID != null && senderID.Length != 0)
      {
        if (senderID.Length == 1)
        {
          stringBuilder.Append(" AND SenderID=@SenderID");
          List<SqlParameter> sqlParameterList2 = sqlParameterList1;
          SqlParameter sqlParameter = new SqlParameter("@SenderID", SqlDbType.UniqueIdentifier);
          sqlParameter.Value = (object) senderID[0];
          sqlParameterList2.Add(sqlParameter);
        }
        else
          stringBuilder.Append(string.Format(" AND SenderID IN({0})", (object) Tools.GetSqlInString<Guid>(senderID, true)));
      }
      if (receiveID != null && receiveID.Length != 0)
      {
        if (receiveID.Length == 1)
        {
          stringBuilder.Append(" AND ReceiveID=@ReceiveID");
          List<SqlParameter> sqlParameterList2 = sqlParameterList1;
          SqlParameter sqlParameter = new SqlParameter("@ReceiveID", SqlDbType.UniqueIdentifier);
          sqlParameter.Value = (object) receiveID[0];
          sqlParameterList2.Add(sqlParameter);
        }
        else
          stringBuilder.Append(string.Format(" AND ReceiveID IN({0})", (object) Tools.GetSqlInString<Guid>(receiveID, true)));
      }
      if (!title.IsNullOrEmpty())
      {
        stringBuilder.Append(" AND CHARINDEX(@Title,Title)>0");
        List<SqlParameter> sqlParameterList2 = sqlParameterList1;
        SqlParameter sqlParameter = new SqlParameter("@Title", SqlDbType.NVarChar, 2000);
        sqlParameter.Value = (object) title;
        sqlParameterList2.Add(sqlParameter);
      }
      if (flowid.IsGuid())
      {
        stringBuilder.Append(" AND FlowID=@FlowID");
        List<SqlParameter> sqlParameterList2 = sqlParameterList1;
        SqlParameter sqlParameter = new SqlParameter("@FlowID", SqlDbType.UniqueIdentifier);
        sqlParameter.Value = (object) flowid.ToGuid();
        sqlParameterList2.Add(sqlParameter);
      }
      else if (!flowid.IsNullOrEmpty() && flowid.IndexOf(',') >= 0)
        stringBuilder.Append(" AND FlowID IN(" + Tools.GetSqlInString(flowid, true, ",") + ")");
      DateTime dateTime;
      if (date1.IsDateTime())
      {
        stringBuilder.Append(" AND SenderTime>=@SenderTime");
        List<SqlParameter> sqlParameterList2 = sqlParameterList1;
        SqlParameter sqlParameter = new SqlParameter("@SenderTime", SqlDbType.DateTime);
        dateTime = date1.ToDateTime();
        sqlParameter.Value = (object) dateTime.Date;
        sqlParameterList2.Add(sqlParameter);
      }
      if (date2.IsDateTime())
      {
        stringBuilder.Append(" AND SenderTime<=@SenderTime1");
        List<SqlParameter> sqlParameterList2 = sqlParameterList1;
        SqlParameter sqlParameter = new SqlParameter("@SenderTime1", SqlDbType.DateTime);
        dateTime = date2.ToDateTime();
        dateTime = dateTime.AddDays(1.0);
        sqlParameter.Value = (object) dateTime.Date;
        sqlParameterList2.Add(sqlParameter);
      }
      string sql = string.Format("select *,ROW_NUMBER() OVER(ORDER BY SenderTime DESC) AS PagerAutoRowNumber from(\r\nselect flowid,groupid,MAX(SenderTime) SenderTime from WorkFlowTask WHERE 1=1 {0} group by FlowID, GroupID\r\n) temp", (object) stringBuilder.ToString());
      int pageSize = Tools.GetPageSize();
      int pageNumber = Tools.GetPageNumber();
      long count;
      string paerSql = this.dbHelper.GetPaerSql(sql, pageSize, pageNumber, out count, sqlParameterList1.ToArray());
      pager = Tools.GetPagerHtml(count, pageSize, pageNumber, query);
      return this.dbHelper.GetDataTable(paerSql, sqlParameterList1.ToArray());
    }

    public DataTable GetInstances1(Guid[] flowID, Guid[] senderID, Guid[] receiveID, out long count, int size, int number, string title = "", string flowid = "", string date1 = "", string date2 = "", int status = 0, string order = "")
    {
      List<SqlParameter> sqlParameterList1 = new List<SqlParameter>();
      StringBuilder stringBuilder = new StringBuilder();
      switch (status)
      {
        case 1:
          stringBuilder.Append(" AND Status IN(0,1,5)");
          break;
        case 2:
          stringBuilder.Append(" AND Status IN(2,3,4)");
          break;
      }
      if (flowID != null && flowID.Length != 0)
        stringBuilder.Append(string.Format(" AND FlowID IN({0})", (object) Tools.GetSqlInString<Guid>(flowID, true)));
      if (senderID != null && senderID.Length != 0)
      {
        if (senderID.Length == 1)
        {
          stringBuilder.Append(" AND SenderID=@SenderID");
          List<SqlParameter> sqlParameterList2 = sqlParameterList1;
          SqlParameter sqlParameter = new SqlParameter("@SenderID", SqlDbType.UniqueIdentifier);
          sqlParameter.Value = (object) senderID[0];
          sqlParameterList2.Add(sqlParameter);
        }
        else
          stringBuilder.Append(string.Format(" AND SenderID IN({0})", (object) Tools.GetSqlInString<Guid>(senderID, true)));
      }
      if (receiveID != null && receiveID.Length != 0)
      {
        if (receiveID.Length == 1)
        {
          stringBuilder.Append(" AND SenderID=@ReceiveID");
          List<SqlParameter> sqlParameterList2 = sqlParameterList1;
          SqlParameter sqlParameter = new SqlParameter("@ReceiveID", SqlDbType.UniqueIdentifier);
          sqlParameter.Value = (object) receiveID[0];
          sqlParameterList2.Add(sqlParameter);
        }
        else
          stringBuilder.Append(string.Format(" AND SenderID IN({0})", (object) Tools.GetSqlInString<Guid>(receiveID, true)));
      }
      if (!title.IsNullOrEmpty())
      {
        stringBuilder.Append(" AND CHARINDEX(@Title,Title)>0");
        List<SqlParameter> sqlParameterList2 = sqlParameterList1;
        SqlParameter sqlParameter = new SqlParameter("@Title", SqlDbType.NVarChar, 2000);
        sqlParameter.Value = (object) title;
        sqlParameterList2.Add(sqlParameter);
      }
      if (flowid.IsGuid())
      {
        stringBuilder.Append(" AND FlowID=@FlowID");
        List<SqlParameter> sqlParameterList2 = sqlParameterList1;
        SqlParameter sqlParameter = new SqlParameter("@FlowID", SqlDbType.UniqueIdentifier);
        sqlParameter.Value = (object) flowid.ToGuid();
        sqlParameterList2.Add(sqlParameter);
      }
      else if (!flowid.IsNullOrEmpty() && flowid.IndexOf(',') >= 0)
        stringBuilder.Append(" AND FlowID IN(" + Tools.GetSqlInString(flowid, true, ",") + ")");
      DateTime dateTime;
      if (date1.IsDateTime())
      {
        stringBuilder.Append(" AND SenderTime>=@SenderTime");
        List<SqlParameter> sqlParameterList2 = sqlParameterList1;
        SqlParameter sqlParameter = new SqlParameter("@SenderTime", SqlDbType.DateTime);
        dateTime = date1.ToDateTime();
        sqlParameter.Value = (object) dateTime.Date;
        sqlParameterList2.Add(sqlParameter);
      }
      if (date2.IsDateTime())
      {
        stringBuilder.Append(" AND SenderTime<=@SenderTime1");
        List<SqlParameter> sqlParameterList2 = sqlParameterList1;
        SqlParameter sqlParameter = new SqlParameter("@SenderTime1", SqlDbType.DateTime);
        dateTime = date2.ToDateTime();
        dateTime = dateTime.AddDays(1.0);
        sqlParameter.Value = (object) dateTime.Date;
        sqlParameterList2.Add(sqlParameter);
      }
      return this.dbHelper.GetDataTable(this.dbHelper.GetPaerSql(string.Format("select *,ROW_NUMBER() OVER(ORDER BY " + (order.IsNullOrEmpty() ? "SenderTime DESC" : order) + ") AS PagerAutoRowNumber from(select flowid,groupid,MAX(SenderTime) SenderTime from WorkFlowTask WHERE 1=1 {0} group by FlowID, GroupID) temp", (object) stringBuilder.ToString()), size, number, out count, sqlParameterList1.ToArray()), sqlParameterList1.ToArray());
    }

    public Guid GetFirstSnderID(Guid flowID, Guid groupID)
    {
      string sql = "SELECT SenderID FROM WorkFlowTask WHERE FlowID=@FlowID AND GroupID=@GroupID AND PrevID=@PrevID";
      SqlParameter[] sqlParameterArray = new SqlParameter[3];
      int index1 = 0;
      SqlParameter sqlParameter1 = new SqlParameter("@FlowID", SqlDbType.UniqueIdentifier);
      sqlParameter1.Value = (object) flowID;
      sqlParameterArray[index1] = sqlParameter1;
      int index2 = 1;
      SqlParameter sqlParameter2 = new SqlParameter("@GroupID", SqlDbType.UniqueIdentifier);
      sqlParameter2.Value = (object) groupID;
      sqlParameterArray[index2] = sqlParameter2;
      int index3 = 2;
      SqlParameter sqlParameter3 = new SqlParameter("@PrevID", SqlDbType.UniqueIdentifier);
      sqlParameter3.Value = (object) Guid.Empty;
      sqlParameterArray[index3] = sqlParameter3;
      SqlParameter[] parameter = sqlParameterArray;
      return this.dbHelper.GetFieldValue(sql, parameter).ToGuid();
    }

    public List<Guid> GetStepSnderID(Guid flowID, Guid stepID, Guid groupID)
    {
      string sql = "SELECT ReceiveID, Sort FROM WorkFlowTask WHERE FlowID=@FlowID AND StepID=@StepID AND GroupID=@GroupID AND Sort=(SELECT ISNULL(MAX(Sort),0) FROM WorkFlowTask WHERE FlowID=@FlowID AND StepID=@StepID AND GroupID=@GroupID)";
      SqlParameter[] sqlParameterArray = new SqlParameter[3];
      int index1 = 0;
      SqlParameter sqlParameter1 = new SqlParameter("@FlowID", SqlDbType.UniqueIdentifier);
      sqlParameter1.Value = (object) flowID;
      sqlParameterArray[index1] = sqlParameter1;
      int index2 = 1;
      SqlParameter sqlParameter2 = new SqlParameter("@StepID", SqlDbType.UniqueIdentifier);
      sqlParameter2.Value = (object) stepID;
      sqlParameterArray[index2] = sqlParameter2;
      int index3 = 2;
      SqlParameter sqlParameter3 = new SqlParameter("@GroupID", SqlDbType.UniqueIdentifier);
      sqlParameter3.Value = (object) groupID;
      sqlParameterArray[index3] = sqlParameter3;
      SqlParameter[] parameter = sqlParameterArray;
      DataTable dataTable = this.dbHelper.GetDataTable(sql, parameter);
      List<Guid> guidList = new List<Guid>();
      foreach (DataRow row in (InternalDataCollectionBase) dataTable.Rows)
      {
        Guid result;
        if (Guid.TryParse(row[0].ToString(), out result))
          guidList.Add(result);
      }
      return guidList;
    }

    public List<Guid> GetPrevSnderID(Guid flowID, Guid stepID, Guid groupID)
    {
      string sql = "SELECT ReceiveID FROM WorkFlowTask WHERE ID=(SELECT PrevID FROM WorkFlowTask WHERE FlowID=@FlowID AND StepID=@StepID AND GroupID=@GroupID)";
      SqlParameter[] sqlParameterArray = new SqlParameter[3];
      int index1 = 0;
      SqlParameter sqlParameter1 = new SqlParameter("@FlowID", SqlDbType.UniqueIdentifier);
      sqlParameter1.Value = (object) flowID;
      sqlParameterArray[index1] = sqlParameter1;
      int index2 = 1;
      SqlParameter sqlParameter2 = new SqlParameter("@StepID", SqlDbType.UniqueIdentifier);
      sqlParameter2.Value = (object) stepID;
      sqlParameterArray[index2] = sqlParameter2;
      int index3 = 2;
      SqlParameter sqlParameter3 = new SqlParameter("@GroupID", SqlDbType.UniqueIdentifier);
      sqlParameter3.Value = (object) groupID;
      sqlParameterArray[index3] = sqlParameter3;
      SqlParameter[] parameter = sqlParameterArray;
      DataTable dataTable = this.dbHelper.GetDataTable(sql, parameter);
      List<Guid> guidList = new List<Guid>();
      foreach (DataRow row in (InternalDataCollectionBase) dataTable.Rows)
      {
        Guid result;
        if (Guid.TryParse(row[0].ToString(), out result))
          guidList.Add(result);
      }
      return guidList;
    }

    public int Completed(Guid taskID, string comment = "", bool isSign = false, int status = 2, string note = "", string files = "")
    {
      string sql = "UPDATE WorkFlowTask SET Comment=@Comment,CompletedTime1=@CompletedTime1,IsSign=@IsSign,Status=@Status,Note=@Note,Files=@Files WHERE ID=@ID";
      SqlParameter[] sqlParameterArray = new SqlParameter[7];
      int index1 = 0;
      SqlParameter sqlParameter1;
      if (!comment.IsNullOrEmpty())
      {
        SqlParameter sqlParameter2 = new SqlParameter("@Comment", SqlDbType.VarChar);
        sqlParameter2.Value = (object) comment;
        sqlParameter1 = sqlParameter2;
      }
      else
      {
        sqlParameter1 = new SqlParameter("@Comment", SqlDbType.VarChar);
        sqlParameter1.Value = (object) DBNull.Value;
      }
      sqlParameterArray[index1] = sqlParameter1;
      int index2 = 1;
      SqlParameter sqlParameter3 = new SqlParameter("@CompletedTime1", SqlDbType.DateTime);
      sqlParameter3.Value = (object) DateTimeNew.Now;
      sqlParameterArray[index2] = sqlParameter3;
      int index3 = 2;
      SqlParameter sqlParameter4 = new SqlParameter("@IsSign", SqlDbType.Int);
      sqlParameter4.Value = (object) (isSign ? 1 : 0);
      sqlParameterArray[index3] = sqlParameter4;
      int index4 = 3;
      SqlParameter sqlParameter5 = new SqlParameter("@Status", SqlDbType.Int);
      sqlParameter5.Value = (object) status;
      sqlParameterArray[index4] = sqlParameter5;
      int index5 = 4;
      SqlParameter sqlParameter6;
      if (!note.IsNullOrEmpty())
      {
        SqlParameter sqlParameter2 = new SqlParameter("@Note", SqlDbType.NVarChar);
        sqlParameter2.Value = (object) note;
        sqlParameter6 = sqlParameter2;
      }
      else
      {
        sqlParameter6 = new SqlParameter("@Note", SqlDbType.NVarChar);
        sqlParameter6.Value = (object) DBNull.Value;
      }
      sqlParameterArray[index5] = sqlParameter6;
      int index6 = 5;
      SqlParameter sqlParameter7;
      if (!files.IsNullOrEmpty())
      {
        SqlParameter sqlParameter2 = new SqlParameter("@Files", SqlDbType.VarChar);
        sqlParameter2.Value = (object) files;
        sqlParameter7 = sqlParameter2;
      }
      else
      {
        sqlParameter7 = new SqlParameter("@Files", SqlDbType.VarChar);
        sqlParameter7.Value = (object) DBNull.Value;
      }
      sqlParameterArray[index6] = sqlParameter7;
      int index7 = 6;
      SqlParameter sqlParameter8 = new SqlParameter("@ID", SqlDbType.UniqueIdentifier);
      sqlParameter8.Value = (object) taskID;
      sqlParameterArray[index7] = sqlParameter8;
      SqlParameter[] parameter = sqlParameterArray;
      return this.dbHelper.Execute(sql, parameter, false);
    }

    public int UpdateNextTaskStatus(Guid taskID, int status)
    {
      string sql = "UPDATE WorkFlowTask SET Status=@Status WHERE PrevID=@PrevID";
      SqlParameter[] sqlParameterArray = new SqlParameter[2];
      int index1 = 0;
      SqlParameter sqlParameter1 = new SqlParameter("@Status", SqlDbType.Int);
      sqlParameter1.Value = (object) status;
      sqlParameterArray[index1] = sqlParameter1;
      int index2 = 1;
      SqlParameter sqlParameter2 = new SqlParameter("@PrevID", SqlDbType.UniqueIdentifier);
      sqlParameter2.Value = (object) taskID;
      sqlParameterArray[index2] = sqlParameter2;
      SqlParameter[] parameter = sqlParameterArray;
      return this.dbHelper.Execute(sql, parameter, false);
    }

    public List<RoadFlow.Data.Model.WorkFlowTask> GetTaskList(Guid flowID, Guid stepID, Guid groupID)
    {
      string sql = "SELECT * FROM WorkFlowTask WHERE StepID=@StepID AND GroupID=@GroupID";
      SqlParameter[] sqlParameterArray = new SqlParameter[2];
      int index1 = 0;
      SqlParameter sqlParameter1 = new SqlParameter("@StepID", SqlDbType.UniqueIdentifier);
      sqlParameter1.Value = (object) stepID;
      sqlParameterArray[index1] = sqlParameter1;
      int index2 = 1;
      SqlParameter sqlParameter2 = new SqlParameter("@GroupID", SqlDbType.UniqueIdentifier);
      sqlParameter2.Value = (object) groupID;
      sqlParameterArray[index2] = sqlParameter2;
      SqlParameter[] parameter = sqlParameterArray;
      SqlDataReader dataReader = this.dbHelper.GetDataReader(sql, parameter);
      List<RoadFlow.Data.Model.WorkFlowTask> list = this.DataReaderToList(dataReader);
      dataReader.Close();
      return list;
    }

    public List<RoadFlow.Data.Model.WorkFlowTask> GetUserTaskList(Guid flowID, Guid stepID, Guid groupID, Guid userID)
    {
      string sql = "SELECT * FROM WorkFlowTask WHERE StepID=@StepID AND GroupID=@GroupID AND ReceiveID=@ReceiveID";
      SqlParameter[] sqlParameterArray = new SqlParameter[3];
      int index1 = 0;
      SqlParameter sqlParameter1 = new SqlParameter("@StepID", SqlDbType.UniqueIdentifier);
      sqlParameter1.Value = (object) stepID;
      sqlParameterArray[index1] = sqlParameter1;
      int index2 = 1;
      SqlParameter sqlParameter2 = new SqlParameter("@GroupID", SqlDbType.UniqueIdentifier);
      sqlParameter2.Value = (object) groupID;
      sqlParameterArray[index2] = sqlParameter2;
      int index3 = 2;
      SqlParameter sqlParameter3 = new SqlParameter("@ReceiveID", SqlDbType.UniqueIdentifier);
      sqlParameter3.Value = (object) userID;
      sqlParameterArray[index3] = sqlParameter3;
      SqlParameter[] parameter = sqlParameterArray;
      SqlDataReader dataReader = this.dbHelper.GetDataReader(sql, parameter);
      List<RoadFlow.Data.Model.WorkFlowTask> list = this.DataReaderToList(dataReader);
      dataReader.Close();
      return list;
    }

    public List<RoadFlow.Data.Model.WorkFlowTask> GetTaskList(Guid flowID, Guid groupID)
    {
      string empty = string.Empty;
      string sql;
      SqlParameter[] parameter;
      if (flowID.IsEmptyGuid())
      {
        sql = "SELECT * FROM WorkFlowTask WHERE GroupID=@GroupID";
        SqlParameter[] sqlParameterArray = new SqlParameter[1];
        int index = 0;
        SqlParameter sqlParameter = new SqlParameter("@GroupID", SqlDbType.UniqueIdentifier);
        sqlParameter.Value = (object) groupID;
        sqlParameterArray[index] = sqlParameter;
        parameter = sqlParameterArray;
      }
      else
      {
        sql = "SELECT * FROM WorkFlowTask WHERE FlowID=@FlowID AND GroupID=@GroupID";
        SqlParameter[] sqlParameterArray = new SqlParameter[2];
        int index1 = 0;
        SqlParameter sqlParameter1 = new SqlParameter("@FlowID", SqlDbType.UniqueIdentifier);
        sqlParameter1.Value = (object) flowID;
        sqlParameterArray[index1] = sqlParameter1;
        int index2 = 1;
        SqlParameter sqlParameter2 = new SqlParameter("@GroupID", SqlDbType.UniqueIdentifier);
        sqlParameter2.Value = (object) groupID;
        sqlParameterArray[index2] = sqlParameter2;
        parameter = sqlParameterArray;
      }
      SqlDataReader dataReader = this.dbHelper.GetDataReader(sql, parameter);
      List<RoadFlow.Data.Model.WorkFlowTask> list = this.DataReaderToList(dataReader);
      dataReader.Close();
      return list;
    }

    public List<RoadFlow.Data.Model.WorkFlowTask> GetTaskList(Guid taskID, bool isStepID = true)
    {
      RoadFlow.Data.Model.WorkFlowTask workFlowTask = this.Get(taskID);
      if (workFlowTask == null)
        return new List<RoadFlow.Data.Model.WorkFlowTask>();
      string sql = string.Format("SELECT * FROM WorkFlowTask WHERE FlowID=@FlowID AND GroupID=@GroupID AND PrevID=@PrevID AND {0}", isStepID ? (object) "StepID=@StepID" : (object) "PrevStepID=@StepID");
      SqlParameter[] sqlParameterArray = new SqlParameter[4];
      int index1 = 0;
      SqlParameter sqlParameter1 = new SqlParameter("@FlowID", SqlDbType.UniqueIdentifier);
      sqlParameter1.Value = (object) workFlowTask.FlowID;
      sqlParameterArray[index1] = sqlParameter1;
      int index2 = 1;
      SqlParameter sqlParameter2 = new SqlParameter("@GroupID", SqlDbType.UniqueIdentifier);
      sqlParameter2.Value = (object) workFlowTask.GroupID;
      sqlParameterArray[index2] = sqlParameter2;
      int index3 = 2;
      SqlParameter sqlParameter3 = new SqlParameter("@PrevID", SqlDbType.UniqueIdentifier);
      sqlParameter3.Value = (object) workFlowTask.PrevID;
      sqlParameterArray[index3] = sqlParameter3;
      int index4 = 3;
      SqlParameter sqlParameter4 = new SqlParameter("@StepID", SqlDbType.UniqueIdentifier);
      sqlParameter4.Value = (object) (isStepID ? workFlowTask.StepID : workFlowTask.PrevStepID);
      sqlParameterArray[index4] = sqlParameter4;
      SqlParameter[] parameter = sqlParameterArray;
      SqlDataReader dataReader = this.dbHelper.GetDataReader(sql, parameter);
      List<RoadFlow.Data.Model.WorkFlowTask> list = this.DataReaderToList(dataReader);
      dataReader.Close();
      return list;
    }

    public List<RoadFlow.Data.Model.WorkFlowTask> GetPrevTaskList(Guid taskID)
    {
      string sql = "SELECT * FROM WorkFlowTask WHERE ID=(SELECT PrevID FROM WorkFlowTask WHERE ID=@ID)";
      SqlParameter[] sqlParameterArray = new SqlParameter[1];
      int index = 0;
      SqlParameter sqlParameter = new SqlParameter("@ID", SqlDbType.UniqueIdentifier);
      sqlParameter.Value = (object) taskID;
      sqlParameterArray[index] = sqlParameter;
      SqlParameter[] parameter = sqlParameterArray;
      SqlDataReader dataReader = this.dbHelper.GetDataReader(sql, parameter);
      List<RoadFlow.Data.Model.WorkFlowTask> list = this.DataReaderToList(dataReader);
      dataReader.Close();
      return list;
    }

    public List<RoadFlow.Data.Model.WorkFlowTask> GetNextTaskList(Guid taskID)
    {
      string sql = "SELECT * FROM WorkFlowTask WHERE PrevID=@PrevID";
      SqlParameter[] sqlParameterArray = new SqlParameter[1];
      int index = 0;
      SqlParameter sqlParameter = new SqlParameter("@PrevID", SqlDbType.UniqueIdentifier);
      sqlParameter.Value = (object) taskID;
      sqlParameterArray[index] = sqlParameter;
      SqlParameter[] parameter = sqlParameterArray;
      SqlDataReader dataReader = this.dbHelper.GetDataReader(sql, parameter);
      List<RoadFlow.Data.Model.WorkFlowTask> list = this.DataReaderToList(dataReader);
      dataReader.Close();
      return list;
    }

    public bool HasTasks(Guid flowID)
    {
      string sql = "SELECT TOP 1 ID FROM WorkFlowTask WHERE FlowID=@FlowID";
      SqlParameter[] sqlParameterArray = new SqlParameter[1];
      int index = 0;
      SqlParameter sqlParameter = new SqlParameter("@FlowID", SqlDbType.UniqueIdentifier);
      sqlParameter.Value = (object) flowID;
      sqlParameterArray[index] = sqlParameter;
      SqlParameter[] parameter = sqlParameterArray;
      SqlDataReader dataReader = this.dbHelper.GetDataReader(sql, parameter);
      bool hasRows = dataReader.HasRows;
      dataReader.Close();
      return hasRows;
    }

    public bool HasNoCompletedTasks(Guid flowID, Guid stepID, Guid groupID, Guid userID)
    {
      string sql = "SELECT TOP 1 ID FROM WorkFlowTask WHERE FlowID=@FlowID AND StepID=@StepID AND GroupID=@GroupID AND ReceiveID=@ReceiveID AND Status IN(-1,0,1)";
      SqlParameter[] sqlParameterArray = new SqlParameter[4];
      int index1 = 0;
      SqlParameter sqlParameter1 = new SqlParameter("@FlowID", SqlDbType.UniqueIdentifier);
      sqlParameter1.Value = (object) flowID;
      sqlParameterArray[index1] = sqlParameter1;
      int index2 = 1;
      SqlParameter sqlParameter2 = new SqlParameter("@StepID", SqlDbType.UniqueIdentifier);
      sqlParameter2.Value = (object) stepID;
      sqlParameterArray[index2] = sqlParameter2;
      int index3 = 2;
      SqlParameter sqlParameter3 = new SqlParameter("@GroupID", SqlDbType.UniqueIdentifier);
      sqlParameter3.Value = (object) groupID;
      sqlParameterArray[index3] = sqlParameter3;
      int index4 = 3;
      SqlParameter sqlParameter4 = new SqlParameter("@ReceiveID", SqlDbType.UniqueIdentifier);
      sqlParameter4.Value = (object) userID;
      sqlParameterArray[index4] = sqlParameter4;
      SqlParameter[] parameter = sqlParameterArray;
      SqlDataReader dataReader = this.dbHelper.GetDataReader(sql, parameter);
      bool hasRows = dataReader.HasRows;
      dataReader.Close();
      return hasRows;
    }

    public int UpdateTempTasks(Guid flowID, Guid stepID, Guid groupID, DateTime? completedTime, DateTime receiveTime)
    {
      string sql = "UPDATE WorkFlowTask SET CompletedTime=@CompletedTime,ReceiveTime=@ReceiveTime,SenderTime=@SenderTime,Status=0 WHERE FlowID=@FlowID AND StepID=@StepID AND GroupID=@GroupID AND Status=-1";
      SqlParameter[] sqlParameterArray = new SqlParameter[6];
      int index1 = 0;
      SqlParameter sqlParameter1;
      if (completedTime.HasValue)
      {
        SqlParameter sqlParameter2 = new SqlParameter("@CompletedTime", SqlDbType.DateTime);
        sqlParameter2.Value = (object) completedTime.Value;
        sqlParameter1 = sqlParameter2;
      }
      else
      {
        sqlParameter1 = new SqlParameter("@CompletedTime", SqlDbType.DateTime);
        sqlParameter1.Value = (object) DBNull.Value;
      }
      sqlParameterArray[index1] = sqlParameter1;
      int index2 = 1;
      SqlParameter sqlParameter3 = new SqlParameter("@ReceiveTime", SqlDbType.DateTime);
      sqlParameter3.Value = (object) receiveTime;
      sqlParameterArray[index2] = sqlParameter3;
      int index3 = 2;
      SqlParameter sqlParameter4 = new SqlParameter("@SenderTime", SqlDbType.DateTime);
      sqlParameter4.Value = (object) receiveTime;
      sqlParameterArray[index3] = sqlParameter4;
      int index4 = 3;
      SqlParameter sqlParameter5 = new SqlParameter("@FlowID", SqlDbType.UniqueIdentifier);
      sqlParameter5.Value = (object) flowID;
      sqlParameterArray[index4] = sqlParameter5;
      int index5 = 4;
      SqlParameter sqlParameter6 = new SqlParameter("@StepID", SqlDbType.UniqueIdentifier);
      sqlParameter6.Value = (object) stepID;
      sqlParameterArray[index5] = sqlParameter6;
      int index6 = 5;
      SqlParameter sqlParameter7 = new SqlParameter("@GroupID", SqlDbType.UniqueIdentifier);
      sqlParameter7.Value = (object) groupID;
      sqlParameterArray[index6] = sqlParameter7;
      SqlParameter[] parameter = sqlParameterArray;
      return this.dbHelper.Execute(sql, parameter, false);
    }

    public int DeleteTempTasks(Guid flowID, Guid stepID, Guid groupID, Guid prevStepID)
    {
      string sql = "DELETE WorkFlowTask WHERE FlowID=@FlowID AND StepID=@StepID AND GroupID=@GroupID AND Status=-1";
      List<SqlParameter> sqlParameterList1 = new List<SqlParameter>();
      SqlParameter sqlParameter1 = new SqlParameter("@FlowID", SqlDbType.UniqueIdentifier);
      sqlParameter1.Value = (object) flowID;
      sqlParameterList1.Add(sqlParameter1);
      SqlParameter sqlParameter2 = new SqlParameter("@StepID", SqlDbType.UniqueIdentifier);
      sqlParameter2.Value = (object) stepID;
      sqlParameterList1.Add(sqlParameter2);
      SqlParameter sqlParameter3 = new SqlParameter("@GroupID", SqlDbType.UniqueIdentifier);
      sqlParameter3.Value = (object) groupID;
      sqlParameterList1.Add(sqlParameter3);
      List<SqlParameter> sqlParameterList2 = sqlParameterList1;
      if (!prevStepID.IsEmptyGuid())
      {
        sql += " AND PrevStepID=@PrevStepID";
        List<SqlParameter> sqlParameterList3 = sqlParameterList2;
        SqlParameter sqlParameter4 = new SqlParameter("@PrevStepID", SqlDbType.UniqueIdentifier);
        sqlParameter4.Value = (object) prevStepID;
        sqlParameterList3.Add(sqlParameter4);
      }
      return this.dbHelper.Execute(sql, sqlParameterList2.ToArray(), false);
    }

    public int GetTaskStatus(Guid taskID)
    {
      string sql = "SELECT Status FROM WorkFlowTask WHERE ID=@ID";
      SqlParameter[] sqlParameterArray = new SqlParameter[1];
      int index = 0;
      SqlParameter sqlParameter = new SqlParameter("@ID", SqlDbType.UniqueIdentifier);
      sqlParameter.Value = (object) taskID;
      sqlParameterArray[index] = sqlParameter;
      SqlParameter[] parameter = sqlParameterArray;
      int test;
      if (!this.dbHelper.GetFieldValue(sql, parameter).IsInt(out test))
        return -1;
      return test;
    }

    public List<RoadFlow.Data.Model.WorkFlowTask> GetBySubFlowGroupID(Guid subflowGroupID)
    {
      string sql = "SELECT * FROM WorkFlowTask WHERE CHARINDEX(@SubFlowGroupID,SubFlowGroupID)>0";
      SqlParameter[] sqlParameterArray = new SqlParameter[1];
      int index = 0;
      SqlParameter sqlParameter = new SqlParameter("@SubFlowGroupID", SqlDbType.VarChar);
      sqlParameter.Value = (object) subflowGroupID.ToString();
      sqlParameterArray[index] = sqlParameter;
      SqlParameter[] parameter = sqlParameterArray;
      SqlDataReader dataReader = this.dbHelper.GetDataReader(sql, parameter);
      List<RoadFlow.Data.Model.WorkFlowTask> list = this.DataReaderToList(dataReader);
      dataReader.Close();
      return list;
    }

    public RoadFlow.Data.Model.WorkFlowTask GetLastTask(Guid flowID, Guid groupID)
    {
      string sql = "SELECT TOP 1 * FROM WorkFlowTask WHERE FlowID=@FlowID AND GroupID=@GroupID ORDER BY Sort DESC";
      SqlParameter[] sqlParameterArray = new SqlParameter[2];
      int index1 = 0;
      SqlParameter sqlParameter1 = new SqlParameter("@FlowID", SqlDbType.UniqueIdentifier);
      sqlParameter1.Value = (object) flowID;
      sqlParameterArray[index1] = sqlParameter1;
      int index2 = 1;
      SqlParameter sqlParameter2 = new SqlParameter("@GroupID", SqlDbType.UniqueIdentifier);
      sqlParameter2.Value = (object) groupID;
      sqlParameterArray[index2] = sqlParameter2;
      SqlParameter[] parameter = sqlParameterArray;
      SqlDataReader dataReader = this.dbHelper.GetDataReader(sql, parameter);
      List<RoadFlow.Data.Model.WorkFlowTask> list = this.DataReaderToList(dataReader);
      dataReader.Close();
      if (list.Count <= 0)
        return (RoadFlow.Data.Model.WorkFlowTask) null;
      return list[0];
    }

    public List<RoadFlow.Data.Model.WorkFlowTask> GetExpiredAutoSubmitTasks()
    {
      SqlDataReader dataReader = this.dbHelper.GetDataReader("SELECT * FROM WorkFlowTask WHERE CompletedTime<'" + DateTimeNew.Now.ToDateTimeStringS() + "' AND IsExpiredAutoSubmit=1 AND Status IN(0,1)");
      List<RoadFlow.Data.Model.WorkFlowTask> list = this.DataReaderToList(dataReader);
      dataReader.Close();
      return list;
    }
  }
}
