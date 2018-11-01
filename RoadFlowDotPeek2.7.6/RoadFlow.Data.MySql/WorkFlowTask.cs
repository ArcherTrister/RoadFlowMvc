// Decompiled with JetBrains decompiler
// Type: RoadFlow.Data.MySql.WorkFlowTask
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
  public class WorkFlowTask : IWorkFlowTask
  {
    private DBHelper dbHelper = new DBHelper();

    public int Add(RoadFlow.Data.Model.WorkFlowTask model)
    {
      string sql = "INSERT INTO workflowtask\r\n\t\t\t\t(ID,PrevID,PrevStepID,FlowID,StepID,StepName,InstanceID,GroupID,Type,Title,SenderID,SenderName,SenderTime,ReceiveID,ReceiveName,ReceiveTime,OpenTime,CompletedTime,CompletedTime1,Comment,IsSign,Status,Note,Sort,SubFlowGroupID,OtherType,Files,IsExpiredAutoSubmit,StepSort) \r\n\t\t\t\tVALUES(@ID,@PrevID,@PrevStepID,@FlowID,@StepID,@StepName,@InstanceID,@GroupID,@Type,@Title,@SenderID,@SenderName,@SenderTime,@ReceiveID,@ReceiveName,@ReceiveTime,@OpenTime,@CompletedTime,@CompletedTime1,@Comment,@IsSign,@Status,@Note,@Sort,@SubFlowGroupID,@OtherType,@Files,@IsExpiredAutoSubmit,@StepSort)";
      MySqlParameter[] mySqlParameterArray = new MySqlParameter[29];
      int index1 = 0;
      MySqlParameter mySqlParameter1 = new MySqlParameter("@ID", MySqlDbType.VarChar, 36);
      mySqlParameter1.Value = (object) model.ID;
      mySqlParameterArray[index1] = mySqlParameter1;
      int index2 = 1;
      MySqlParameter mySqlParameter2 = new MySqlParameter("@PrevID", MySqlDbType.VarChar, 36);
      mySqlParameter2.Value = (object) model.PrevID;
      mySqlParameterArray[index2] = mySqlParameter2;
      int index3 = 2;
      MySqlParameter mySqlParameter3 = new MySqlParameter("@PrevStepID", MySqlDbType.VarChar, 36);
      mySqlParameter3.Value = (object) model.PrevStepID;
      mySqlParameterArray[index3] = mySqlParameter3;
      int index4 = 3;
      MySqlParameter mySqlParameter4 = new MySqlParameter("@FlowID", MySqlDbType.VarChar, 36);
      mySqlParameter4.Value = (object) model.FlowID;
      mySqlParameterArray[index4] = mySqlParameter4;
      int index5 = 4;
      MySqlParameter mySqlParameter5 = new MySqlParameter("@StepID", MySqlDbType.VarChar, 36);
      mySqlParameter5.Value = (object) model.StepID;
      mySqlParameterArray[index5] = mySqlParameter5;
      int index6 = 5;
      MySqlParameter mySqlParameter6 = new MySqlParameter("@StepName", MySqlDbType.VarChar, (int) byte.MaxValue);
      mySqlParameter6.Value = (object) model.StepName;
      mySqlParameterArray[index6] = mySqlParameter6;
      int index7 = 6;
      MySqlParameter mySqlParameter7 = new MySqlParameter("@InstanceID", MySqlDbType.VarChar, 50);
      mySqlParameter7.Value = (object) model.InstanceID;
      mySqlParameterArray[index7] = mySqlParameter7;
      int index8 = 7;
      MySqlParameter mySqlParameter8 = new MySqlParameter("@GroupID", MySqlDbType.VarChar, 36);
      mySqlParameter8.Value = (object) model.GroupID;
      mySqlParameterArray[index8] = mySqlParameter8;
      int index9 = 8;
      MySqlParameter mySqlParameter9 = new MySqlParameter("@Type", MySqlDbType.Int32, 11);
      mySqlParameter9.Value = (object) model.Type;
      mySqlParameterArray[index9] = mySqlParameter9;
      int index10 = 9;
      MySqlParameter mySqlParameter10 = new MySqlParameter("@Title", MySqlDbType.VarChar, (int) byte.MaxValue);
      mySqlParameter10.Value = (object) model.Title;
      mySqlParameterArray[index10] = mySqlParameter10;
      int index11 = 10;
      MySqlParameter mySqlParameter11 = new MySqlParameter("@SenderID", MySqlDbType.VarChar, 36);
      mySqlParameter11.Value = (object) model.SenderID;
      mySqlParameterArray[index11] = mySqlParameter11;
      int index12 = 11;
      MySqlParameter mySqlParameter12 = new MySqlParameter("@SenderName", MySqlDbType.VarChar, 50);
      mySqlParameter12.Value = (object) model.SenderName;
      mySqlParameterArray[index12] = mySqlParameter12;
      int index13 = 12;
      MySqlParameter mySqlParameter13 = new MySqlParameter("@SenderTime", MySqlDbType.DateTime, -1);
      mySqlParameter13.Value = (object) model.SenderTime;
      mySqlParameterArray[index13] = mySqlParameter13;
      int index14 = 13;
      MySqlParameter mySqlParameter14 = new MySqlParameter("@ReceiveID", MySqlDbType.VarChar, 36);
      mySqlParameter14.Value = (object) model.ReceiveID;
      mySqlParameterArray[index14] = mySqlParameter14;
      int index15 = 14;
      MySqlParameter mySqlParameter15 = new MySqlParameter("@ReceiveName", MySqlDbType.VarChar, 50);
      mySqlParameter15.Value = (object) model.ReceiveName;
      mySqlParameterArray[index15] = mySqlParameter15;
      int index16 = 15;
      MySqlParameter mySqlParameter16 = new MySqlParameter("@ReceiveTime", MySqlDbType.DateTime, -1);
      mySqlParameter16.Value = (object) model.ReceiveTime;
      mySqlParameterArray[index16] = mySqlParameter16;
      int index17 = 16;
      MySqlParameter mySqlParameter17;
      if (model.OpenTime.HasValue)
      {
        MySqlParameter mySqlParameter18 = new MySqlParameter("@OpenTime", MySqlDbType.DateTime, -1);
        mySqlParameter18.Value = (object) model.OpenTime;
        mySqlParameter17 = mySqlParameter18;
      }
      else
      {
        mySqlParameter17 = new MySqlParameter("@OpenTime", MySqlDbType.DateTime, -1);
        mySqlParameter17.Value = (object) DBNull.Value;
      }
      mySqlParameterArray[index17] = mySqlParameter17;
      int index18 = 17;
      DateTime? nullable1 = model.CompletedTime;
      MySqlParameter mySqlParameter19;
      if (nullable1.HasValue)
      {
        MySqlParameter mySqlParameter18 = new MySqlParameter("@CompletedTime", MySqlDbType.DateTime, -1);
        mySqlParameter18.Value = (object) model.CompletedTime;
        mySqlParameter19 = mySqlParameter18;
      }
      else
      {
        mySqlParameter19 = new MySqlParameter("@CompletedTime", MySqlDbType.DateTime, -1);
        mySqlParameter19.Value = (object) DBNull.Value;
      }
      mySqlParameterArray[index18] = mySqlParameter19;
      int index19 = 18;
      nullable1 = model.CompletedTime1;
      MySqlParameter mySqlParameter20;
      if (nullable1.HasValue)
      {
        MySqlParameter mySqlParameter18 = new MySqlParameter("@CompletedTime1", MySqlDbType.DateTime, -1);
        mySqlParameter18.Value = (object) model.CompletedTime1;
        mySqlParameter20 = mySqlParameter18;
      }
      else
      {
        mySqlParameter20 = new MySqlParameter("@CompletedTime1", MySqlDbType.DateTime, -1);
        mySqlParameter20.Value = (object) DBNull.Value;
      }
      mySqlParameterArray[index19] = mySqlParameter20;
      int index20 = 19;
      MySqlParameter mySqlParameter21;
      if (model.Comment != null)
      {
        MySqlParameter mySqlParameter18 = new MySqlParameter("@Comment", MySqlDbType.VarChar, (int) byte.MaxValue);
        mySqlParameter18.Value = (object) model.Comment;
        mySqlParameter21 = mySqlParameter18;
      }
      else
      {
        mySqlParameter21 = new MySqlParameter("@Comment", MySqlDbType.VarChar, (int) byte.MaxValue);
        mySqlParameter21.Value = (object) DBNull.Value;
      }
      mySqlParameterArray[index20] = mySqlParameter21;
      int index21 = 20;
      int? nullable2 = model.IsSign;
      MySqlParameter mySqlParameter22;
      if (nullable2.HasValue)
      {
        MySqlParameter mySqlParameter18 = new MySqlParameter("@IsSign", MySqlDbType.Int32, 11);
        mySqlParameter18.Value = (object) model.IsSign;
        mySqlParameter22 = mySqlParameter18;
      }
      else
      {
        mySqlParameter22 = new MySqlParameter("@IsSign", MySqlDbType.Int32, 11);
        mySqlParameter22.Value = (object) DBNull.Value;
      }
      mySqlParameterArray[index21] = mySqlParameter22;
      int index22 = 21;
      MySqlParameter mySqlParameter23 = new MySqlParameter("@Status", MySqlDbType.Int32, 11);
      mySqlParameter23.Value = (object) model.Status;
      mySqlParameterArray[index22] = mySqlParameter23;
      int index23 = 22;
      MySqlParameter mySqlParameter24;
      if (model.Note != null)
      {
        MySqlParameter mySqlParameter18 = new MySqlParameter("@Note", MySqlDbType.VarChar, (int) byte.MaxValue);
        mySqlParameter18.Value = (object) model.Note;
        mySqlParameter24 = mySqlParameter18;
      }
      else
      {
        mySqlParameter24 = new MySqlParameter("@Note", MySqlDbType.VarChar, (int) byte.MaxValue);
        mySqlParameter24.Value = (object) DBNull.Value;
      }
      mySqlParameterArray[index23] = mySqlParameter24;
      int index24 = 23;
      MySqlParameter mySqlParameter25 = new MySqlParameter("@Sort", MySqlDbType.Int32, 11);
      mySqlParameter25.Value = (object) model.Sort;
      mySqlParameterArray[index24] = mySqlParameter25;
      int index25 = 24;
      MySqlParameter mySqlParameter26;
      if (model.SubFlowGroupID != null)
      {
        MySqlParameter mySqlParameter18 = new MySqlParameter("@SubFlowGroupID", MySqlDbType.VarChar, 2000);
        mySqlParameter18.Value = (object) model.SubFlowGroupID;
        mySqlParameter26 = mySqlParameter18;
      }
      else
      {
        mySqlParameter26 = new MySqlParameter("@SubFlowGroupID", MySqlDbType.VarChar, 2000);
        mySqlParameter26.Value = (object) DBNull.Value;
      }
      mySqlParameterArray[index25] = mySqlParameter26;
      int index26 = 25;
      nullable2 = model.OtherType;
      MySqlParameter mySqlParameter27;
      if (nullable2.HasValue)
      {
        MySqlParameter mySqlParameter18 = new MySqlParameter("@OtherType", MySqlDbType.Int32, 11);
        mySqlParameter18.Value = (object) model.OtherType;
        mySqlParameter27 = mySqlParameter18;
      }
      else
      {
        mySqlParameter27 = new MySqlParameter("@OtherType", MySqlDbType.Int32, 11);
        mySqlParameter27.Value = (object) DBNull.Value;
      }
      mySqlParameterArray[index26] = mySqlParameter27;
      int index27 = 26;
      MySqlParameter mySqlParameter28;
      if (model.Files != null)
      {
        MySqlParameter mySqlParameter18 = new MySqlParameter("@Files", MySqlDbType.VarChar, 4000);
        mySqlParameter18.Value = (object) model.Files;
        mySqlParameter28 = mySqlParameter18;
      }
      else
      {
        mySqlParameter28 = new MySqlParameter("@Files", MySqlDbType.VarChar, 4000);
        mySqlParameter28.Value = (object) DBNull.Value;
      }
      mySqlParameterArray[index27] = mySqlParameter28;
      int index28 = 27;
      MySqlParameter mySqlParameter29 = new MySqlParameter("@IsExpiredAutoSubmit", MySqlDbType.Int32);
      mySqlParameter29.Value = (object) model.IsExpiredAutoSubmit;
      mySqlParameterArray[index28] = mySqlParameter29;
      int index29 = 28;
      MySqlParameter mySqlParameter30 = new MySqlParameter("@StepSort", MySqlDbType.Int32);
      mySqlParameter30.Value = (object) model.StepSort;
      mySqlParameterArray[index29] = mySqlParameter30;
      MySqlParameter[] parameter = mySqlParameterArray;
      return this.dbHelper.Execute(sql, parameter, false);
    }

    public int Update(RoadFlow.Data.Model.WorkFlowTask model)
    {
      string sql = "UPDATE workflowtask SET \r\n\t\t\t\tPrevID=@PrevID,PrevStepID=@PrevStepID,FlowID=@FlowID,StepID=@StepID,StepName=@StepName,InstanceID=@InstanceID,GroupID=@GroupID,Type=@Type,Title=@Title,SenderID=@SenderID,SenderName=@SenderName,SenderTime=@SenderTime,ReceiveID=@ReceiveID,ReceiveName=@ReceiveName,ReceiveTime=@ReceiveTime,OpenTime=@OpenTime,CompletedTime=@CompletedTime,CompletedTime1=@CompletedTime1,Comment=@Comment,IsSign=@IsSign,Status=@Status,Note=@Note,Sort=@Sort,SubFlowGroupID=@SubFlowGroupID,OtherType=@OtherType,Files=@Files,IsExpiredAutoSubmit=@IsExpiredAutoSubmit,StepSort=@StepSort  \r\n\t\t\t\tWHERE ID=@ID";
      MySqlParameter[] mySqlParameterArray = new MySqlParameter[29];
      int index1 = 0;
      MySqlParameter mySqlParameter1 = new MySqlParameter("@PrevID", MySqlDbType.VarChar, 36);
      mySqlParameter1.Value = (object) model.PrevID;
      mySqlParameterArray[index1] = mySqlParameter1;
      int index2 = 1;
      MySqlParameter mySqlParameter2 = new MySqlParameter("@PrevStepID", MySqlDbType.VarChar, 36);
      mySqlParameter2.Value = (object) model.PrevStepID;
      mySqlParameterArray[index2] = mySqlParameter2;
      int index3 = 2;
      MySqlParameter mySqlParameter3 = new MySqlParameter("@FlowID", MySqlDbType.VarChar, 36);
      mySqlParameter3.Value = (object) model.FlowID;
      mySqlParameterArray[index3] = mySqlParameter3;
      int index4 = 3;
      MySqlParameter mySqlParameter4 = new MySqlParameter("@StepID", MySqlDbType.VarChar, 36);
      mySqlParameter4.Value = (object) model.StepID;
      mySqlParameterArray[index4] = mySqlParameter4;
      int index5 = 4;
      MySqlParameter mySqlParameter5 = new MySqlParameter("@StepName", MySqlDbType.VarChar, (int) byte.MaxValue);
      mySqlParameter5.Value = (object) model.StepName;
      mySqlParameterArray[index5] = mySqlParameter5;
      int index6 = 5;
      MySqlParameter mySqlParameter6 = new MySqlParameter("@InstanceID", MySqlDbType.VarChar, 50);
      mySqlParameter6.Value = (object) model.InstanceID;
      mySqlParameterArray[index6] = mySqlParameter6;
      int index7 = 6;
      MySqlParameter mySqlParameter7 = new MySqlParameter("@GroupID", MySqlDbType.VarChar, 36);
      mySqlParameter7.Value = (object) model.GroupID;
      mySqlParameterArray[index7] = mySqlParameter7;
      int index8 = 7;
      MySqlParameter mySqlParameter8 = new MySqlParameter("@Type", MySqlDbType.Int32, 11);
      mySqlParameter8.Value = (object) model.Type;
      mySqlParameterArray[index8] = mySqlParameter8;
      int index9 = 8;
      MySqlParameter mySqlParameter9 = new MySqlParameter("@Title", MySqlDbType.VarChar, (int) byte.MaxValue);
      mySqlParameter9.Value = (object) model.Title;
      mySqlParameterArray[index9] = mySqlParameter9;
      int index10 = 9;
      MySqlParameter mySqlParameter10 = new MySqlParameter("@SenderID", MySqlDbType.VarChar, 36);
      mySqlParameter10.Value = (object) model.SenderID;
      mySqlParameterArray[index10] = mySqlParameter10;
      int index11 = 10;
      MySqlParameter mySqlParameter11 = new MySqlParameter("@SenderName", MySqlDbType.VarChar, 50);
      mySqlParameter11.Value = (object) model.SenderName;
      mySqlParameterArray[index11] = mySqlParameter11;
      int index12 = 11;
      MySqlParameter mySqlParameter12 = new MySqlParameter("@SenderTime", MySqlDbType.DateTime, -1);
      mySqlParameter12.Value = (object) model.SenderTime;
      mySqlParameterArray[index12] = mySqlParameter12;
      int index13 = 12;
      MySqlParameter mySqlParameter13 = new MySqlParameter("@ReceiveID", MySqlDbType.VarChar, 36);
      mySqlParameter13.Value = (object) model.ReceiveID;
      mySqlParameterArray[index13] = mySqlParameter13;
      int index14 = 13;
      MySqlParameter mySqlParameter14 = new MySqlParameter("@ReceiveName", MySqlDbType.VarChar, 50);
      mySqlParameter14.Value = (object) model.ReceiveName;
      mySqlParameterArray[index14] = mySqlParameter14;
      int index15 = 14;
      MySqlParameter mySqlParameter15 = new MySqlParameter("@ReceiveTime", MySqlDbType.DateTime, -1);
      mySqlParameter15.Value = (object) model.ReceiveTime;
      mySqlParameterArray[index15] = mySqlParameter15;
      int index16 = 15;
      MySqlParameter mySqlParameter16;
      if (model.OpenTime.HasValue)
      {
        MySqlParameter mySqlParameter17 = new MySqlParameter("@OpenTime", MySqlDbType.DateTime, -1);
        mySqlParameter17.Value = (object) model.OpenTime;
        mySqlParameter16 = mySqlParameter17;
      }
      else
      {
        mySqlParameter16 = new MySqlParameter("@OpenTime", MySqlDbType.DateTime, -1);
        mySqlParameter16.Value = (object) DBNull.Value;
      }
      mySqlParameterArray[index16] = mySqlParameter16;
      int index17 = 16;
      DateTime? nullable1 = model.CompletedTime;
      MySqlParameter mySqlParameter18;
      if (nullable1.HasValue)
      {
        MySqlParameter mySqlParameter17 = new MySqlParameter("@CompletedTime", MySqlDbType.DateTime, -1);
        mySqlParameter17.Value = (object) model.CompletedTime;
        mySqlParameter18 = mySqlParameter17;
      }
      else
      {
        mySqlParameter18 = new MySqlParameter("@CompletedTime", MySqlDbType.DateTime, -1);
        mySqlParameter18.Value = (object) DBNull.Value;
      }
      mySqlParameterArray[index17] = mySqlParameter18;
      int index18 = 17;
      nullable1 = model.CompletedTime1;
      MySqlParameter mySqlParameter19;
      if (nullable1.HasValue)
      {
        MySqlParameter mySqlParameter17 = new MySqlParameter("@CompletedTime1", MySqlDbType.DateTime, -1);
        mySqlParameter17.Value = (object) model.CompletedTime1;
        mySqlParameter19 = mySqlParameter17;
      }
      else
      {
        mySqlParameter19 = new MySqlParameter("@CompletedTime1", MySqlDbType.DateTime, -1);
        mySqlParameter19.Value = (object) DBNull.Value;
      }
      mySqlParameterArray[index18] = mySqlParameter19;
      int index19 = 18;
      MySqlParameter mySqlParameter20;
      if (model.Comment != null)
      {
        MySqlParameter mySqlParameter17 = new MySqlParameter("@Comment", MySqlDbType.VarChar, (int) byte.MaxValue);
        mySqlParameter17.Value = (object) model.Comment;
        mySqlParameter20 = mySqlParameter17;
      }
      else
      {
        mySqlParameter20 = new MySqlParameter("@Comment", MySqlDbType.VarChar, (int) byte.MaxValue);
        mySqlParameter20.Value = (object) DBNull.Value;
      }
      mySqlParameterArray[index19] = mySqlParameter20;
      int index20 = 19;
      int? nullable2 = model.IsSign;
      MySqlParameter mySqlParameter21;
      if (nullable2.HasValue)
      {
        MySqlParameter mySqlParameter17 = new MySqlParameter("@IsSign", MySqlDbType.Int32, 11);
        mySqlParameter17.Value = (object) model.IsSign;
        mySqlParameter21 = mySqlParameter17;
      }
      else
      {
        mySqlParameter21 = new MySqlParameter("@IsSign", MySqlDbType.Int32, 11);
        mySqlParameter21.Value = (object) DBNull.Value;
      }
      mySqlParameterArray[index20] = mySqlParameter21;
      int index21 = 20;
      MySqlParameter mySqlParameter22 = new MySqlParameter("@Status", MySqlDbType.Int32, 11);
      mySqlParameter22.Value = (object) model.Status;
      mySqlParameterArray[index21] = mySqlParameter22;
      int index22 = 21;
      MySqlParameter mySqlParameter23;
      if (model.Note != null)
      {
        MySqlParameter mySqlParameter17 = new MySqlParameter("@Note", MySqlDbType.VarChar, (int) byte.MaxValue);
        mySqlParameter17.Value = (object) model.Note;
        mySqlParameter23 = mySqlParameter17;
      }
      else
      {
        mySqlParameter23 = new MySqlParameter("@Note", MySqlDbType.VarChar, (int) byte.MaxValue);
        mySqlParameter23.Value = (object) DBNull.Value;
      }
      mySqlParameterArray[index22] = mySqlParameter23;
      int index23 = 22;
      MySqlParameter mySqlParameter24 = new MySqlParameter("@Sort", MySqlDbType.Int32, 11);
      mySqlParameter24.Value = (object) model.Sort;
      mySqlParameterArray[index23] = mySqlParameter24;
      int index24 = 23;
      MySqlParameter mySqlParameter25;
      if (model.SubFlowGroupID != null)
      {
        MySqlParameter mySqlParameter17 = new MySqlParameter("@SubFlowGroupID", MySqlDbType.VarChar, 2000);
        mySqlParameter17.Value = (object) model.SubFlowGroupID;
        mySqlParameter25 = mySqlParameter17;
      }
      else
      {
        mySqlParameter25 = new MySqlParameter("@SubFlowGroupID", MySqlDbType.VarChar, 2000);
        mySqlParameter25.Value = (object) DBNull.Value;
      }
      mySqlParameterArray[index24] = mySqlParameter25;
      int index25 = 24;
      nullable2 = model.OtherType;
      MySqlParameter mySqlParameter26;
      if (nullable2.HasValue)
      {
        MySqlParameter mySqlParameter17 = new MySqlParameter("@OtherType", MySqlDbType.Int32, 11);
        mySqlParameter17.Value = (object) model.OtherType;
        mySqlParameter26 = mySqlParameter17;
      }
      else
      {
        mySqlParameter26 = new MySqlParameter("@OtherType", MySqlDbType.Int32, 11);
        mySqlParameter26.Value = (object) DBNull.Value;
      }
      mySqlParameterArray[index25] = mySqlParameter26;
      int index26 = 25;
      MySqlParameter mySqlParameter27;
      if (model.Files != null)
      {
        MySqlParameter mySqlParameter17 = new MySqlParameter("@Files", MySqlDbType.VarChar, 4000);
        mySqlParameter17.Value = (object) model.Files;
        mySqlParameter27 = mySqlParameter17;
      }
      else
      {
        mySqlParameter27 = new MySqlParameter("@Files", MySqlDbType.VarChar, 4000);
        mySqlParameter27.Value = (object) DBNull.Value;
      }
      mySqlParameterArray[index26] = mySqlParameter27;
      int index27 = 26;
      MySqlParameter mySqlParameter28 = new MySqlParameter("@IsExpiredAutoSubmit", MySqlDbType.Int32);
      mySqlParameter28.Value = (object) model.IsExpiredAutoSubmit;
      mySqlParameterArray[index27] = mySqlParameter28;
      int index28 = 27;
      MySqlParameter mySqlParameter29 = new MySqlParameter("@StepSort", MySqlDbType.Int32);
      mySqlParameter29.Value = (object) model.StepSort;
      mySqlParameterArray[index28] = mySqlParameter29;
      int index29 = 28;
      MySqlParameter mySqlParameter30 = new MySqlParameter("@ID", MySqlDbType.VarChar, 36);
      mySqlParameter30.Value = (object) model.ID;
      mySqlParameterArray[index29] = mySqlParameter30;
      MySqlParameter[] parameter = mySqlParameterArray;
      return this.dbHelper.Execute(sql, parameter, false);
    }

    public int Delete(Guid id)
    {
      string sql = "DELETE FROM workflowtask WHERE ID=@ID";
      MySqlParameter[] mySqlParameterArray = new MySqlParameter[1];
      int index = 0;
      MySqlParameter mySqlParameter = new MySqlParameter("@ID", MySqlDbType.VarChar, 36);
      mySqlParameter.Value = (object) id.ToString();
      mySqlParameterArray[index] = mySqlParameter;
      MySqlParameter[] parameter = mySqlParameterArray;
      return this.dbHelper.Execute(sql, parameter, false);
    }

    private List<RoadFlow.Data.Model.WorkFlowTask> DataReaderToList(MySqlDataReader dataReader)
    {
      List<RoadFlow.Data.Model.WorkFlowTask> workFlowTaskList = new List<RoadFlow.Data.Model.WorkFlowTask>();
      while (dataReader.Read())
      {
        RoadFlow.Data.Model.WorkFlowTask workFlowTask = new RoadFlow.Data.Model.WorkFlowTask();
        workFlowTask.ID = dataReader.GetString(0).ToGuid();
        workFlowTask.PrevID = dataReader.GetString(1).ToGuid();
        workFlowTask.PrevStepID = dataReader.GetString(2).ToGuid();
        workFlowTask.FlowID = dataReader.GetString(3).ToGuid();
        workFlowTask.StepID = dataReader.GetString(4).ToGuid();
        workFlowTask.StepName = dataReader.GetString(5);
        workFlowTask.InstanceID = dataReader.GetString(6);
        workFlowTask.GroupID = dataReader.GetString(7).ToGuid();
        workFlowTask.Type = dataReader.GetInt32(8);
        workFlowTask.Title = dataReader.GetString(9);
        workFlowTask.SenderID = dataReader.GetString(10).ToGuid();
        workFlowTask.SenderName = dataReader.GetString(11);
        workFlowTask.SenderTime = dataReader.GetDateTime(12);
        workFlowTask.ReceiveID = dataReader.GetString(13).ToGuid();
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
      MySqlDataReader dataReader = this.dbHelper.GetDataReader("SELECT * FROM workflowtask");
      List<RoadFlow.Data.Model.WorkFlowTask> list = this.DataReaderToList(dataReader);
      dataReader.Close();
      return list;
    }

    public long GetCount()
    {
      long result;
      if (!long.TryParse(this.dbHelper.GetFieldValue("SELECT COUNT(*) FROM workflowtask"), out result))
        return 0;
      return result;
    }

    public RoadFlow.Data.Model.WorkFlowTask Get(Guid id)
    {
      string sql = "SELECT * FROM workflowtask WHERE ID=@ID";
      MySqlParameter[] mySqlParameterArray = new MySqlParameter[1];
      int index = 0;
      MySqlParameter mySqlParameter = new MySqlParameter("@ID", MySqlDbType.VarChar, 36);
      mySqlParameter.Value = (object) id.ToString();
      mySqlParameterArray[index] = mySqlParameter;
      MySqlParameter[] parameter = mySqlParameterArray;
      MySqlDataReader dataReader = this.dbHelper.GetDataReader(sql, parameter);
      List<RoadFlow.Data.Model.WorkFlowTask> list = this.DataReaderToList(dataReader);
      dataReader.Close();
      if (list.Count <= 0)
        return (RoadFlow.Data.Model.WorkFlowTask) null;
      return list[0];
    }

    public int Delete(Guid flowID, Guid groupID)
    {
      string sql = "DELETE FROM WorkFlowTask WHERE GroupID=@GroupID";
      List<MySqlParameter> mySqlParameterList1 = new List<MySqlParameter>();
      MySqlParameter mySqlParameter1 = new MySqlParameter("@GroupID", MySqlDbType.VarChar);
      mySqlParameter1.Value = (object) groupID.ToString();
      mySqlParameterList1.Add(mySqlParameter1);
      List<MySqlParameter> mySqlParameterList2 = mySqlParameterList1;
      if (!flowID.IsEmptyGuid())
      {
        sql += " AND FlowID=@FlowID";
        List<MySqlParameter> mySqlParameterList3 = mySqlParameterList2;
        MySqlParameter mySqlParameter2 = new MySqlParameter("@FlowID", MySqlDbType.VarChar);
        mySqlParameter2.Value = (object) flowID.ToString();
        mySqlParameterList3.Add(mySqlParameter2);
      }
      return this.dbHelper.Execute(sql, mySqlParameterList2.ToArray(), false);
    }

    public void UpdateOpenTime(Guid id, DateTime openTime, bool isStatus = false)
    {
      string sql = "UPDATE WorkFlowTask SET OpenTime=@OpenTime " + (isStatus ? ", Status=1" : "") + " WHERE ID=@ID AND OpenTime IS NULL";
      MySqlParameter[] mySqlParameterArray = new MySqlParameter[2];
      int index1 = 0;
      MySqlParameter mySqlParameter1;
      if (!(openTime == DateTime.MinValue))
      {
        MySqlParameter mySqlParameter2 = new MySqlParameter("@OpenTime", MySqlDbType.DateTime);
        mySqlParameter2.Value = (object) openTime;
        mySqlParameter1 = mySqlParameter2;
      }
      else
      {
        mySqlParameter1 = new MySqlParameter("@OpenTime", MySqlDbType.DateTime);
        mySqlParameter1.Value = (object) DBNull.Value;
      }
      mySqlParameterArray[index1] = mySqlParameter1;
      int index2 = 1;
      MySqlParameter mySqlParameter3 = new MySqlParameter("@ID", MySqlDbType.VarChar);
      mySqlParameter3.Value = (object) id.ToString();
      mySqlParameterArray[index2] = mySqlParameter3;
      MySqlParameter[] parameter = mySqlParameterArray;
      this.dbHelper.Execute(sql, parameter, false);
    }

    public List<RoadFlow.Data.Model.WorkFlowTask> GetTasks(Guid userID, out string pager, string query = "", string title = "", string flowid = "", string sender = "", string date1 = "", string date2 = "", int type = 0)
    {
      List<MySqlParameter> mySqlParameterList1 = new List<MySqlParameter>();
      StringBuilder stringBuilder = new StringBuilder("SELECT * FROM WorkFlowTask WHERE ReceiveID=@ReceiveID");
      stringBuilder.Append(type == 0 ? " AND Status IN(0,1)" : " AND Status IN(2,3,4,5)");
      List<MySqlParameter> mySqlParameterList2 = mySqlParameterList1;
      MySqlParameter mySqlParameter1 = new MySqlParameter("@ReceiveID", MySqlDbType.VarChar);
      mySqlParameter1.Value = (object) userID.ToString();
      mySqlParameterList2.Add(mySqlParameter1);
      if (!title.IsNullOrEmpty())
      {
        stringBuilder.Append(" AND INSTR(Title,@Title)>0");
        List<MySqlParameter> mySqlParameterList3 = mySqlParameterList1;
        MySqlParameter mySqlParameter2 = new MySqlParameter("@Title", MySqlDbType.VarChar, 2000);
        mySqlParameter2.Value = (object) title;
        mySqlParameterList3.Add(mySqlParameter2);
      }
      if (flowid.IsGuid())
      {
        stringBuilder.Append(" AND FlowID=@FlowID");
        List<MySqlParameter> mySqlParameterList3 = mySqlParameterList1;
        MySqlParameter mySqlParameter2 = new MySqlParameter("@FlowID", MySqlDbType.VarChar);
        mySqlParameter2.Value = (object) flowid;
        mySqlParameterList3.Add(mySqlParameter2);
      }
      else if (!flowid.IsNullOrEmpty() && flowid.IndexOf(',') >= 0)
        stringBuilder.Append(" AND FlowID IN(" + Tools.GetSqlInString(flowid, true, ",") + ")");
      if (sender.IsGuid())
      {
        stringBuilder.Append(" AND SenderID=@SenderID");
        List<MySqlParameter> mySqlParameterList3 = mySqlParameterList1;
        MySqlParameter mySqlParameter2 = new MySqlParameter("@SenderID", MySqlDbType.VarChar);
        mySqlParameter2.Value = (object) sender;
        mySqlParameterList3.Add(mySqlParameter2);
      }
      DateTime dateTime;
      if (date1.IsDateTime())
      {
        stringBuilder.Append(" AND ReceiveTime>=@ReceiveTime");
        List<MySqlParameter> mySqlParameterList3 = mySqlParameterList1;
        MySqlParameter mySqlParameter2 = new MySqlParameter("@ReceiveTime", MySqlDbType.DateTime);
        dateTime = date1.ToDateTime();
        mySqlParameter2.Value = (object) dateTime.Date;
        mySqlParameterList3.Add(mySqlParameter2);
      }
      if (date2.IsDateTime())
      {
        stringBuilder.Append(" AND SenderTime<=@ReceiveTime1");
        List<MySqlParameter> mySqlParameterList3 = mySqlParameterList1;
        MySqlParameter mySqlParameter2 = new MySqlParameter("@ReceiveTime1", MySqlDbType.DateTime);
        dateTime = date2.ToDateTime();
        dateTime = dateTime.AddDays(1.0);
        mySqlParameter2.Value = (object) dateTime.Date;
        mySqlParameterList3.Add(mySqlParameter2);
      }
      stringBuilder.Append(" ORDER BY " + (type == 0 ? "SenderTime DESC" : "CompletedTime1 DESC"));
      int pageSize = Tools.GetPageSize();
      int pageNumber = Tools.GetPageNumber();
      long count;
      string paerSql = this.dbHelper.GetPaerSql(stringBuilder.ToString(), pageSize, pageNumber, out count, mySqlParameterList1.ToArray());
      pager = Tools.GetPagerHtml(count, pageSize, pageNumber, query);
      MySqlDataReader dataReader = this.dbHelper.GetDataReader(paerSql, mySqlParameterList1.ToArray());
      List<RoadFlow.Data.Model.WorkFlowTask> list = this.DataReaderToList(dataReader);
      dataReader.Close();
      return list;
    }

    public List<RoadFlow.Data.Model.WorkFlowTask> GetTasks(Guid userID, out long count, int size, int number, string title = "", string flowid = "", string sender = "", string date1 = "", string date2 = "", int type = 0, string order = "")
    {
      List<MySqlParameter> mySqlParameterList1 = new List<MySqlParameter>();
      StringBuilder stringBuilder = new StringBuilder("SELECT * FROM WorkFlowTask WHERE ReceiveID=@ReceiveID");
      stringBuilder.Append(type == 0 ? " AND Status IN(0,1)" : " AND Status IN(2,3,4,5)");
      List<MySqlParameter> mySqlParameterList2 = mySqlParameterList1;
      MySqlParameter mySqlParameter1 = new MySqlParameter("@ReceiveID", MySqlDbType.VarChar);
      mySqlParameter1.Value = (object) userID.ToString();
      mySqlParameterList2.Add(mySqlParameter1);
      if (!title.IsNullOrEmpty())
      {
        stringBuilder.Append(" AND INSTR(Title,@Title)>0");
        List<MySqlParameter> mySqlParameterList3 = mySqlParameterList1;
        MySqlParameter mySqlParameter2 = new MySqlParameter("@Title", MySqlDbType.VarChar, 2000);
        mySqlParameter2.Value = (object) title;
        mySqlParameterList3.Add(mySqlParameter2);
      }
      if (flowid.IsGuid())
      {
        stringBuilder.Append(" AND FlowID=@FlowID");
        List<MySqlParameter> mySqlParameterList3 = mySqlParameterList1;
        MySqlParameter mySqlParameter2 = new MySqlParameter("@FlowID", MySqlDbType.VarChar);
        mySqlParameter2.Value = (object) flowid;
        mySqlParameterList3.Add(mySqlParameter2);
      }
      else if (!flowid.IsNullOrEmpty() && flowid.IndexOf(',') >= 0)
        stringBuilder.Append(" AND FlowID IN(" + Tools.GetSqlInString(flowid, true, ",") + ")");
      if (sender.IsGuid())
      {
        stringBuilder.Append(" AND SenderID=@SenderID");
        List<MySqlParameter> mySqlParameterList3 = mySqlParameterList1;
        MySqlParameter mySqlParameter2 = new MySqlParameter("@SenderID", MySqlDbType.VarChar);
        mySqlParameter2.Value = (object) sender;
        mySqlParameterList3.Add(mySqlParameter2);
      }
      DateTime dateTime;
      if (date1.IsDateTime())
      {
        stringBuilder.Append(" AND ReceiveTime>=@ReceiveTime");
        List<MySqlParameter> mySqlParameterList3 = mySqlParameterList1;
        MySqlParameter mySqlParameter2 = new MySqlParameter("@ReceiveTime", MySqlDbType.DateTime);
        dateTime = date1.ToDateTime();
        mySqlParameter2.Value = (object) dateTime.Date;
        mySqlParameterList3.Add(mySqlParameter2);
      }
      if (date2.IsDateTime())
      {
        stringBuilder.Append(" AND SenderTime<=@ReceiveTime1");
        List<MySqlParameter> mySqlParameterList3 = mySqlParameterList1;
        MySqlParameter mySqlParameter2 = new MySqlParameter("@ReceiveTime1", MySqlDbType.DateTime);
        dateTime = date2.ToDateTime();
        dateTime = dateTime.AddDays(1.0);
        mySqlParameter2.Value = (object) dateTime.Date;
        mySqlParameterList3.Add(mySqlParameter2);
      }
      stringBuilder.Append("ORDER BY " + (order.IsNullOrEmpty() ? (type == 0 ? "SenderTime DESC" : "CompletedTime1 DESC") : order));
      MySqlDataReader dataReader = this.dbHelper.GetDataReader(this.dbHelper.GetPaerSql(stringBuilder.ToString(), size, number, out count, mySqlParameterList1.ToArray()), mySqlParameterList1.ToArray());
      List<RoadFlow.Data.Model.WorkFlowTask> list = this.DataReaderToList(dataReader);
      dataReader.Close();
      return list;
    }

    public List<RoadFlow.Data.Model.WorkFlowTask> GetInstances(Guid[] flowID, Guid[] senderID, Guid[] receiveID, out string pager, string query = "", string title = "", string flowid = "", string date1 = "", string date2 = "", int status = 0)
    {
      List<MySqlParameter> mySqlParameterList1 = new List<MySqlParameter>();
      StringBuilder stringBuilder = new StringBuilder("SELECT a.* FROM WorkFlowTask a\r\n                WHERE a.ID=(SELECT ID FROM WorkFlowTask WHERE FlowID=a.FlowID AND GroupID=a.GroupID ORDER BY Sort DESC LIMIT 0,1)");
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
          List<MySqlParameter> mySqlParameterList2 = mySqlParameterList1;
          MySqlParameter mySqlParameter = new MySqlParameter("@SenderID", MySqlDbType.VarChar);
          mySqlParameter.Value = (object) senderID[0].ToString();
          mySqlParameterList2.Add(mySqlParameter);
        }
        else
          stringBuilder.Append(string.Format(" AND a.SenderID IN({0})", (object) Tools.GetSqlInString<Guid>(senderID, true)));
      }
      if (receiveID != null && receiveID.Length != 0)
      {
        if (senderID.Length == 1)
        {
          stringBuilder.Append(" AND a.ReceiveID=@ReceiveID");
          List<MySqlParameter> mySqlParameterList2 = mySqlParameterList1;
          MySqlParameter mySqlParameter = new MySqlParameter("@ReceiveID", MySqlDbType.VarChar);
          mySqlParameter.Value = (object) receiveID[0].ToString();
          mySqlParameterList2.Add(mySqlParameter);
        }
        else
          stringBuilder.Append(string.Format(" AND a.ReceiveID IN({0})", (object) Tools.GetSqlInString<Guid>(receiveID, true)));
      }
      if (!title.IsNullOrEmpty())
      {
        stringBuilder.Append(" AND INSTR(a.Title,@Title)>0");
        List<MySqlParameter> mySqlParameterList2 = mySqlParameterList1;
        MySqlParameter mySqlParameter = new MySqlParameter("@Title", MySqlDbType.VarChar, 2000);
        mySqlParameter.Value = (object) title;
        mySqlParameterList2.Add(mySqlParameter);
      }
      if (flowid.IsGuid())
      {
        stringBuilder.Append(" AND a.FlowID=@FlowID");
        List<MySqlParameter> mySqlParameterList2 = mySqlParameterList1;
        MySqlParameter mySqlParameter = new MySqlParameter("@FlowID", MySqlDbType.VarChar);
        mySqlParameter.Value = (object) flowid;
        mySqlParameterList2.Add(mySqlParameter);
      }
      else if (!flowid.IsNullOrEmpty() && flowid.IndexOf(',') >= 0)
        stringBuilder.Append(" AND a.FlowID IN(" + Tools.GetSqlInString(flowid, true, ",") + ")");
      if (date1.IsDateTime())
      {
        stringBuilder.Append(" AND a.SenderTime>=@SenderTime");
        List<MySqlParameter> mySqlParameterList2 = mySqlParameterList1;
        MySqlParameter mySqlParameter = new MySqlParameter("@SenderTime", MySqlDbType.DateTime);
        mySqlParameter.Value = (object) date1.ToDateTime().Date;
        mySqlParameterList2.Add(mySqlParameter);
      }
      if (date2.IsDateTime())
      {
        stringBuilder.Append(" AND a.SenderTime<=@SenderTime1");
        List<MySqlParameter> mySqlParameterList2 = mySqlParameterList1;
        MySqlParameter mySqlParameter = new MySqlParameter("@SenderTime1", MySqlDbType.DateTime);
        mySqlParameter.Value = (object) date2.ToDateTime().AddDays(1.0).Date;
        mySqlParameterList2.Add(mySqlParameter);
      }
      stringBuilder.Append(" ORDER BY a.SenderTime DESC");
      int pageSize = Tools.GetPageSize();
      int pageNumber = Tools.GetPageNumber();
      long count;
      string paerSql = this.dbHelper.GetPaerSql(stringBuilder.ToString(), pageSize, pageNumber, out count, mySqlParameterList1.ToArray());
      pager = Tools.GetPagerHtml(count, pageSize, pageNumber, query);
      MySqlDataReader dataReader = this.dbHelper.GetDataReader(paerSql, mySqlParameterList1.ToArray());
      List<RoadFlow.Data.Model.WorkFlowTask> list = this.DataReaderToList(dataReader);
      dataReader.Close();
      return list;
    }

    public DataTable GetInstances1(Guid[] flowID, Guid[] senderID, Guid[] receiveID, out string pager, string query = "", string title = "", string flowid = "", string date1 = "", string date2 = "", int status = 0)
    {
      List<MySqlParameter> mySqlParameterList1 = new List<MySqlParameter>();
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
          List<MySqlParameter> mySqlParameterList2 = mySqlParameterList1;
          MySqlParameter mySqlParameter = new MySqlParameter("@SenderID", MySqlDbType.VarChar);
          mySqlParameter.Value = (object) senderID[0].ToString();
          mySqlParameterList2.Add(mySqlParameter);
        }
        else
          stringBuilder.Append(string.Format(" AND SenderID IN({0})", (object) Tools.GetSqlInString<Guid>(senderID, true)));
      }
      if (receiveID != null && receiveID.Length != 0)
      {
        if (senderID.Length == 1)
        {
          stringBuilder.Append(" AND ReceiveID=@ReceiveID");
          List<MySqlParameter> mySqlParameterList2 = mySqlParameterList1;
          MySqlParameter mySqlParameter = new MySqlParameter("@ReceiveID", MySqlDbType.VarChar);
          mySqlParameter.Value = (object) receiveID[0].ToString();
          mySqlParameterList2.Add(mySqlParameter);
        }
        else
          stringBuilder.Append(string.Format(" AND ReceiveID IN({0})", (object) Tools.GetSqlInString<Guid>(receiveID, true)));
      }
      if (!title.IsNullOrEmpty())
      {
        stringBuilder.Append(" AND INSTR(Title,@Title)>0");
        List<MySqlParameter> mySqlParameterList2 = mySqlParameterList1;
        MySqlParameter mySqlParameter = new MySqlParameter("@Title", MySqlDbType.VarChar, 2000);
        mySqlParameter.Value = (object) title;
        mySqlParameterList2.Add(mySqlParameter);
      }
      if (flowid.IsGuid())
      {
        stringBuilder.Append(" AND FlowID=@FlowID");
        List<MySqlParameter> mySqlParameterList2 = mySqlParameterList1;
        MySqlParameter mySqlParameter = new MySqlParameter("@FlowID", MySqlDbType.VarChar);
        mySqlParameter.Value = (object) flowid;
        mySqlParameterList2.Add(mySqlParameter);
      }
      else if (!flowid.IsNullOrEmpty() && flowid.IndexOf(',') >= 0)
        stringBuilder.Append(" AND FlowID IN(" + Tools.GetSqlInString(flowid, true, ",") + ")");
      DateTime dateTime;
      if (date1.IsDateTime())
      {
        stringBuilder.Append(" AND SenderTime>=@SenderTime");
        List<MySqlParameter> mySqlParameterList2 = mySqlParameterList1;
        MySqlParameter mySqlParameter = new MySqlParameter("@SenderTime", MySqlDbType.DateTime);
        dateTime = date1.ToDateTime();
        mySqlParameter.Value = (object) dateTime.Date;
        mySqlParameterList2.Add(mySqlParameter);
      }
      if (date2.IsDateTime())
      {
        stringBuilder.Append(" AND SenderTime<=@SenderTime1");
        List<MySqlParameter> mySqlParameterList2 = mySqlParameterList1;
        MySqlParameter mySqlParameter = new MySqlParameter("@SenderTime1", MySqlDbType.DateTime);
        dateTime = date2.ToDateTime();
        dateTime = dateTime.AddDays(1.0);
        mySqlParameter.Value = (object) dateTime.Date;
        mySqlParameterList2.Add(mySqlParameter);
      }
      string sql = string.Format("select * from(\r\nselect flowid,groupid,MAX(SenderTime) SenderTime from WorkFlowTask WHERE 1=1 {0} group by FlowID, GroupID\r\n) temp ORDER BY SenderTime DESC", (object) stringBuilder.ToString());
      int pageSize = Tools.GetPageSize();
      int pageNumber = Tools.GetPageNumber();
      long count;
      string paerSql = this.dbHelper.GetPaerSql(sql, pageSize, pageNumber, out count, mySqlParameterList1.ToArray());
      pager = Tools.GetPagerHtml(count, pageSize, pageNumber, query);
      return this.dbHelper.GetDataTable(paerSql, mySqlParameterList1.ToArray());
    }

    public DataTable GetInstances1(Guid[] flowID, Guid[] senderID, Guid[] receiveID, out long count, int size, int number, string title = "", string flowid = "", string date1 = "", string date2 = "", int status = 0, string order = "")
    {
      List<MySqlParameter> mySqlParameterList1 = new List<MySqlParameter>();
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
          List<MySqlParameter> mySqlParameterList2 = mySqlParameterList1;
          MySqlParameter mySqlParameter = new MySqlParameter("@SenderID", MySqlDbType.VarChar);
          mySqlParameter.Value = (object) senderID[0].ToString();
          mySqlParameterList2.Add(mySqlParameter);
        }
        else
          stringBuilder.Append(string.Format(" AND SenderID IN({0})", (object) Tools.GetSqlInString<Guid>(senderID, true)));
      }
      if (receiveID != null && receiveID.Length != 0)
      {
        if (senderID.Length == 1)
        {
          stringBuilder.Append(" AND ReceiveID=@ReceiveID");
          List<MySqlParameter> mySqlParameterList2 = mySqlParameterList1;
          MySqlParameter mySqlParameter = new MySqlParameter("@ReceiveID", MySqlDbType.VarChar);
          mySqlParameter.Value = (object) receiveID[0].ToString();
          mySqlParameterList2.Add(mySqlParameter);
        }
        else
          stringBuilder.Append(string.Format(" AND ReceiveID IN({0})", (object) Tools.GetSqlInString<Guid>(receiveID, true)));
      }
      if (!title.IsNullOrEmpty())
      {
        stringBuilder.Append(" AND INSTR(Title,@Title)>0");
        List<MySqlParameter> mySqlParameterList2 = mySqlParameterList1;
        MySqlParameter mySqlParameter = new MySqlParameter("@Title", MySqlDbType.VarChar, 2000);
        mySqlParameter.Value = (object) title;
        mySqlParameterList2.Add(mySqlParameter);
      }
      if (flowid.IsGuid())
      {
        stringBuilder.Append(" AND FlowID=@FlowID");
        List<MySqlParameter> mySqlParameterList2 = mySqlParameterList1;
        MySqlParameter mySqlParameter = new MySqlParameter("@FlowID", MySqlDbType.VarChar);
        mySqlParameter.Value = (object) flowid;
        mySqlParameterList2.Add(mySqlParameter);
      }
      else if (!flowid.IsNullOrEmpty() && flowid.IndexOf(',') >= 0)
        stringBuilder.Append(" AND FlowID IN(" + Tools.GetSqlInString(flowid, true, ",") + ")");
      DateTime dateTime;
      if (date1.IsDateTime())
      {
        stringBuilder.Append(" AND SenderTime>=@SenderTime");
        List<MySqlParameter> mySqlParameterList2 = mySqlParameterList1;
        MySqlParameter mySqlParameter = new MySqlParameter("@SenderTime", MySqlDbType.DateTime);
        dateTime = date1.ToDateTime();
        mySqlParameter.Value = (object) dateTime.Date;
        mySqlParameterList2.Add(mySqlParameter);
      }
      if (date2.IsDateTime())
      {
        stringBuilder.Append(" AND SenderTime<=@SenderTime1");
        List<MySqlParameter> mySqlParameterList2 = mySqlParameterList1;
        MySqlParameter mySqlParameter = new MySqlParameter("@SenderTime1", MySqlDbType.DateTime);
        dateTime = date2.ToDateTime();
        dateTime = dateTime.AddDays(1.0);
        mySqlParameter.Value = (object) dateTime.Date;
        mySqlParameterList2.Add(mySqlParameter);
      }
      return this.dbHelper.GetDataTable(this.dbHelper.GetPaerSql(string.Format("select * from(\r\nselect flowid,groupid,MAX(SenderTime) SenderTime from WorkFlowTask WHERE 1=1 {0} group by FlowID, GroupID\r\n) temp ORDER BY " + (order.IsNullOrEmpty() ? "SenderTime DESC" : order), (object) stringBuilder.ToString()), size, number, out count, mySqlParameterList1.ToArray()), mySqlParameterList1.ToArray());
    }

    public Guid GetFirstSnderID(Guid flowID, Guid groupID)
    {
      string sql = "SELECT SenderID FROM WorkFlowTask WHERE FlowID=@FlowID AND GroupID=@GroupID AND PrevID=@PrevID";
      MySqlParameter[] mySqlParameterArray = new MySqlParameter[3];
      int index1 = 0;
      MySqlParameter mySqlParameter1 = new MySqlParameter("@FlowID", MySqlDbType.VarChar);
      mySqlParameter1.Value = (object) flowID.ToString();
      mySqlParameterArray[index1] = mySqlParameter1;
      int index2 = 1;
      MySqlParameter mySqlParameter2 = new MySqlParameter("@GroupID", MySqlDbType.VarChar);
      mySqlParameter2.Value = (object) groupID.ToString();
      mySqlParameterArray[index2] = mySqlParameter2;
      int index3 = 2;
      MySqlParameter mySqlParameter3 = new MySqlParameter("@PrevID", MySqlDbType.VarChar);
      mySqlParameter3.Value = (object) Guid.Empty.ToString();
      mySqlParameterArray[index3] = mySqlParameter3;
      MySqlParameter[] parameter = mySqlParameterArray;
      return this.dbHelper.GetFieldValue(sql, parameter).ToGuid();
    }

    public List<Guid> GetStepSnderID(Guid flowID, Guid stepID, Guid groupID)
    {
      string sql = "SELECT ReceiveID, Sort FROM WorkFlowTask WHERE FlowID=@FlowID AND StepID=@StepID AND GroupID=@GroupID AND Sort=(SELECT IFNULL(MAX(Sort),0) FROM WorkFlowTask WHERE FlowID=@FlowID AND StepID=@StepID AND GroupID=@GroupID)";
      MySqlParameter[] mySqlParameterArray = new MySqlParameter[3];
      int index1 = 0;
      MySqlParameter mySqlParameter1 = new MySqlParameter("@FlowID", MySqlDbType.VarChar);
      mySqlParameter1.Value = (object) flowID.ToString();
      mySqlParameterArray[index1] = mySqlParameter1;
      int index2 = 1;
      MySqlParameter mySqlParameter2 = new MySqlParameter("@StepID", MySqlDbType.VarChar);
      mySqlParameter2.Value = (object) stepID.ToString();
      mySqlParameterArray[index2] = mySqlParameter2;
      int index3 = 2;
      MySqlParameter mySqlParameter3 = new MySqlParameter("@GroupID", MySqlDbType.VarChar);
      mySqlParameter3.Value = (object) groupID.ToString();
      mySqlParameterArray[index3] = mySqlParameter3;
      MySqlParameter[] parameter = mySqlParameterArray;
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
      MySqlParameter[] mySqlParameterArray = new MySqlParameter[3];
      int index1 = 0;
      MySqlParameter mySqlParameter1 = new MySqlParameter("@FlowID", MySqlDbType.VarChar);
      mySqlParameter1.Value = (object) flowID.ToString();
      mySqlParameterArray[index1] = mySqlParameter1;
      int index2 = 1;
      MySqlParameter mySqlParameter2 = new MySqlParameter("@StepID", MySqlDbType.VarChar);
      mySqlParameter2.Value = (object) stepID.ToString();
      mySqlParameterArray[index2] = mySqlParameter2;
      int index3 = 2;
      MySqlParameter mySqlParameter3 = new MySqlParameter("@GroupID", MySqlDbType.VarChar);
      mySqlParameter3.Value = (object) groupID.ToString();
      mySqlParameterArray[index3] = mySqlParameter3;
      MySqlParameter[] parameter = mySqlParameterArray;
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
      MySqlParameter[] mySqlParameterArray = new MySqlParameter[7];
      int index1 = 0;
      MySqlParameter mySqlParameter1;
      if (!comment.IsNullOrEmpty())
      {
        MySqlParameter mySqlParameter2 = new MySqlParameter("@Comment", MySqlDbType.VarChar);
        mySqlParameter2.Value = (object) comment;
        mySqlParameter1 = mySqlParameter2;
      }
      else
      {
        mySqlParameter1 = new MySqlParameter("@Comment", MySqlDbType.VarChar);
        mySqlParameter1.Value = (object) DBNull.Value;
      }
      mySqlParameterArray[index1] = mySqlParameter1;
      int index2 = 1;
      MySqlParameter mySqlParameter3 = new MySqlParameter("@CompletedTime1", MySqlDbType.DateTime);
      mySqlParameter3.Value = (object) DateTimeNew.Now;
      mySqlParameterArray[index2] = mySqlParameter3;
      int index3 = 2;
      MySqlParameter mySqlParameter4 = new MySqlParameter("@IsSign", MySqlDbType.Int32);
      mySqlParameter4.Value = (object) (isSign ? 1 : 0);
      mySqlParameterArray[index3] = mySqlParameter4;
      int index4 = 3;
      MySqlParameter mySqlParameter5 = new MySqlParameter("@Status", MySqlDbType.Int32);
      mySqlParameter5.Value = (object) status;
      mySqlParameterArray[index4] = mySqlParameter5;
      int index5 = 4;
      MySqlParameter mySqlParameter6;
      if (!note.IsNullOrEmpty())
      {
        MySqlParameter mySqlParameter2 = new MySqlParameter("@Note", MySqlDbType.VarChar);
        mySqlParameter2.Value = (object) note;
        mySqlParameter6 = mySqlParameter2;
      }
      else
      {
        mySqlParameter6 = new MySqlParameter("@Note", MySqlDbType.VarChar);
        mySqlParameter6.Value = (object) DBNull.Value;
      }
      mySqlParameterArray[index5] = mySqlParameter6;
      int index6 = 5;
      MySqlParameter mySqlParameter7;
      if (!files.IsNullOrEmpty())
      {
        MySqlParameter mySqlParameter2 = new MySqlParameter("@Files", MySqlDbType.VarChar);
        mySqlParameter2.Value = (object) files;
        mySqlParameter7 = mySqlParameter2;
      }
      else
      {
        mySqlParameter7 = new MySqlParameter("@Files", MySqlDbType.VarChar);
        mySqlParameter7.Value = (object) DBNull.Value;
      }
      mySqlParameterArray[index6] = mySqlParameter7;
      int index7 = 6;
      MySqlParameter mySqlParameter8 = new MySqlParameter("@ID", MySqlDbType.VarChar);
      mySqlParameter8.Value = (object) taskID.ToString();
      mySqlParameterArray[index7] = mySqlParameter8;
      MySqlParameter[] parameter = mySqlParameterArray;
      return this.dbHelper.Execute(sql, parameter, false);
    }

    public int UpdateNextTaskStatus(Guid taskID, int status)
    {
      string sql = "UPDATE WorkFlowTask SET Status=@Status WHERE PrevID=@PrevID";
      MySqlParameter[] mySqlParameterArray = new MySqlParameter[2];
      int index1 = 0;
      MySqlParameter mySqlParameter1 = new MySqlParameter("@Status", MySqlDbType.Int32);
      mySqlParameter1.Value = (object) status;
      mySqlParameterArray[index1] = mySqlParameter1;
      int index2 = 1;
      MySqlParameter mySqlParameter2 = new MySqlParameter("@PrevID", MySqlDbType.VarChar);
      mySqlParameter2.Value = (object) taskID.ToString();
      mySqlParameterArray[index2] = mySqlParameter2;
      MySqlParameter[] parameter = mySqlParameterArray;
      return this.dbHelper.Execute(sql, parameter, false);
    }

    public List<RoadFlow.Data.Model.WorkFlowTask> GetTaskList(Guid flowID, Guid stepID, Guid groupID)
    {
      string sql = "SELECT * FROM WorkFlowTask WHERE StepID=@StepID AND GroupID=@GroupID";
      MySqlParameter[] mySqlParameterArray = new MySqlParameter[2];
      int index1 = 0;
      MySqlParameter mySqlParameter1 = new MySqlParameter("@StepID", MySqlDbType.VarChar);
      mySqlParameter1.Value = (object) stepID.ToString();
      mySqlParameterArray[index1] = mySqlParameter1;
      int index2 = 1;
      MySqlParameter mySqlParameter2 = new MySqlParameter("@GroupID", MySqlDbType.VarChar);
      mySqlParameter2.Value = (object) groupID.ToString();
      mySqlParameterArray[index2] = mySqlParameter2;
      MySqlParameter[] parameter = mySqlParameterArray;
      MySqlDataReader dataReader = this.dbHelper.GetDataReader(sql, parameter);
      List<RoadFlow.Data.Model.WorkFlowTask> list = this.DataReaderToList(dataReader);
      dataReader.Close();
      return list;
    }

    public List<RoadFlow.Data.Model.WorkFlowTask> GetUserTaskList(Guid flowID, Guid stepID, Guid groupID, Guid userID)
    {
      string sql = "SELECT * FROM WorkFlowTask WHERE StepID=@StepID AND GroupID=@GroupID AND ReceiveID=@ReceiveID";
      MySqlParameter[] mySqlParameterArray = new MySqlParameter[3];
      int index1 = 0;
      MySqlParameter mySqlParameter1 = new MySqlParameter("@StepID", MySqlDbType.VarChar);
      mySqlParameter1.Value = (object) stepID.ToString();
      mySqlParameterArray[index1] = mySqlParameter1;
      int index2 = 1;
      MySqlParameter mySqlParameter2 = new MySqlParameter("@GroupID", MySqlDbType.VarChar);
      mySqlParameter2.Value = (object) groupID.ToString();
      mySqlParameterArray[index2] = mySqlParameter2;
      int index3 = 2;
      MySqlParameter mySqlParameter3 = new MySqlParameter("@ReceiveID", MySqlDbType.VarChar);
      mySqlParameter3.Value = (object) userID.ToString();
      mySqlParameterArray[index3] = mySqlParameter3;
      MySqlParameter[] parameter = mySqlParameterArray;
      MySqlDataReader dataReader = this.dbHelper.GetDataReader(sql, parameter);
      List<RoadFlow.Data.Model.WorkFlowTask> list = this.DataReaderToList(dataReader);
      dataReader.Close();
      return list;
    }

    public List<RoadFlow.Data.Model.WorkFlowTask> GetTaskList(Guid flowID, Guid groupID)
    {
      string empty = string.Empty;
      string sql;
      MySqlParameter[] parameter;
      if (flowID.IsEmptyGuid())
      {
        sql = "SELECT * FROM WorkFlowTask WHERE GroupID=@GroupID";
        MySqlParameter[] mySqlParameterArray = new MySqlParameter[1];
        int index = 0;
        MySqlParameter mySqlParameter = new MySqlParameter("@GroupID", MySqlDbType.VarChar);
        mySqlParameter.Value = (object) groupID.ToString();
        mySqlParameterArray[index] = mySqlParameter;
        parameter = mySqlParameterArray;
      }
      else
      {
        sql = "SELECT * FROM WorkFlowTask WHERE FlowID=@FlowID AND GroupID=@GroupID";
        MySqlParameter[] mySqlParameterArray = new MySqlParameter[2];
        int index1 = 0;
        MySqlParameter mySqlParameter1 = new MySqlParameter("@FlowID", MySqlDbType.VarChar);
        mySqlParameter1.Value = (object) flowID.ToString();
        mySqlParameterArray[index1] = mySqlParameter1;
        int index2 = 1;
        MySqlParameter mySqlParameter2 = new MySqlParameter("@GroupID", MySqlDbType.VarChar);
        mySqlParameter2.Value = (object) groupID.ToString();
        mySqlParameterArray[index2] = mySqlParameter2;
        parameter = mySqlParameterArray;
      }
      MySqlDataReader dataReader = this.dbHelper.GetDataReader(sql, parameter);
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
      MySqlParameter[] mySqlParameterArray = new MySqlParameter[4];
      int index1 = 0;
      MySqlParameter mySqlParameter1 = new MySqlParameter("@FlowID", MySqlDbType.VarChar);
      mySqlParameter1.Value = (object) workFlowTask.FlowID.ToString();
      mySqlParameterArray[index1] = mySqlParameter1;
      int index2 = 1;
      MySqlParameter mySqlParameter2 = new MySqlParameter("@GroupID", MySqlDbType.VarChar);
      mySqlParameter2.Value = (object) workFlowTask.GroupID.ToString();
      mySqlParameterArray[index2] = mySqlParameter2;
      int index3 = 2;
      MySqlParameter mySqlParameter3 = new MySqlParameter("@PrevID", MySqlDbType.VarChar);
      mySqlParameter3.Value = (object) workFlowTask.PrevID.ToString();
      mySqlParameterArray[index3] = mySqlParameter3;
      int index4 = 3;
      MySqlParameter mySqlParameter4 = new MySqlParameter("@StepID", MySqlDbType.VarChar);
      mySqlParameter4.Value = isStepID ? (object) workFlowTask.StepID.ToString() : (object) workFlowTask.PrevStepID.ToString();
      mySqlParameterArray[index4] = mySqlParameter4;
      MySqlParameter[] parameter = mySqlParameterArray;
      MySqlDataReader dataReader = this.dbHelper.GetDataReader(sql, parameter);
      List<RoadFlow.Data.Model.WorkFlowTask> list = this.DataReaderToList(dataReader);
      dataReader.Close();
      return list;
    }

    public List<RoadFlow.Data.Model.WorkFlowTask> GetPrevTaskList(Guid taskID)
    {
      string sql = "SELECT * FROM WorkFlowTask WHERE ID=(SELECT PrevID FROM WorkFlowTask WHERE ID=@ID)";
      MySqlParameter[] mySqlParameterArray = new MySqlParameter[1];
      int index = 0;
      MySqlParameter mySqlParameter = new MySqlParameter("@ID", MySqlDbType.VarChar);
      mySqlParameter.Value = (object) taskID.ToString();
      mySqlParameterArray[index] = mySqlParameter;
      MySqlParameter[] parameter = mySqlParameterArray;
      MySqlDataReader dataReader = this.dbHelper.GetDataReader(sql, parameter);
      List<RoadFlow.Data.Model.WorkFlowTask> list = this.DataReaderToList(dataReader);
      dataReader.Close();
      return list;
    }

    public List<RoadFlow.Data.Model.WorkFlowTask> GetNextTaskList(Guid taskID)
    {
      string sql = "SELECT * FROM WorkFlowTask WHERE PrevID=@PrevID";
      MySqlParameter[] mySqlParameterArray = new MySqlParameter[1];
      int index = 0;
      MySqlParameter mySqlParameter = new MySqlParameter("@PrevID", MySqlDbType.VarChar);
      mySqlParameter.Value = (object) taskID.ToString();
      mySqlParameterArray[index] = mySqlParameter;
      MySqlParameter[] parameter = mySqlParameterArray;
      MySqlDataReader dataReader = this.dbHelper.GetDataReader(sql, parameter);
      List<RoadFlow.Data.Model.WorkFlowTask> list = this.DataReaderToList(dataReader);
      dataReader.Close();
      return list;
    }

    public bool HasTasks(Guid flowID)
    {
      string sql = "SELECT ID FROM WorkFlowTask WHERE FlowID=@FlowID LIMIT 0,1";
      MySqlParameter[] mySqlParameterArray = new MySqlParameter[1];
      int index = 0;
      MySqlParameter mySqlParameter = new MySqlParameter("@FlowID", MySqlDbType.VarChar);
      mySqlParameter.Value = (object) flowID.ToString();
      mySqlParameterArray[index] = mySqlParameter;
      MySqlParameter[] parameter = mySqlParameterArray;
      MySqlDataReader dataReader = this.dbHelper.GetDataReader(sql, parameter);
      bool hasRows = dataReader.HasRows;
      dataReader.Close();
      return hasRows;
    }

    public bool HasNoCompletedTasks(Guid flowID, Guid stepID, Guid groupID, Guid userID)
    {
      string sql = "SELECT ID FROM WorkFlowTask WHERE FlowID=@FlowID AND StepID=@StepID AND GroupID=@GroupID AND ReceiveID=@ReceiveID AND Status IN(-1,0,1) LIMIT 0,1";
      MySqlParameter[] mySqlParameterArray = new MySqlParameter[4];
      int index1 = 0;
      MySqlParameter mySqlParameter1 = new MySqlParameter("@FlowID", MySqlDbType.VarChar);
      mySqlParameter1.Value = (object) flowID.ToString();
      mySqlParameterArray[index1] = mySqlParameter1;
      int index2 = 1;
      MySqlParameter mySqlParameter2 = new MySqlParameter("@StepID", MySqlDbType.VarChar);
      mySqlParameter2.Value = (object) stepID.ToString();
      mySqlParameterArray[index2] = mySqlParameter2;
      int index3 = 2;
      MySqlParameter mySqlParameter3 = new MySqlParameter("@GroupID", MySqlDbType.VarChar);
      mySqlParameter3.Value = (object) groupID.ToString();
      mySqlParameterArray[index3] = mySqlParameter3;
      int index4 = 3;
      MySqlParameter mySqlParameter4 = new MySqlParameter("@ReceiveID", MySqlDbType.VarChar);
      mySqlParameter4.Value = (object) userID.ToString();
      mySqlParameterArray[index4] = mySqlParameter4;
      MySqlParameter[] parameter = mySqlParameterArray;
      MySqlDataReader dataReader = this.dbHelper.GetDataReader(sql, parameter);
      bool hasRows = dataReader.HasRows;
      dataReader.Close();
      return hasRows;
    }

    public int UpdateTempTasks(Guid flowID, Guid stepID, Guid groupID, DateTime? completedTime, DateTime receiveTime)
    {
      string sql = "UPDATE WorkFlowTask SET CompletedTime=@CompletedTime,ReceiveTime=@ReceiveTime,SenderTime=@SenderTime,Status=0 WHERE FlowID=@FlowID AND StepID=@StepID AND GroupID=@GroupID AND Status=-1";
      MySqlParameter[] mySqlParameterArray = new MySqlParameter[6];
      int index1 = 0;
      MySqlParameter mySqlParameter1;
      if (completedTime.HasValue)
      {
        MySqlParameter mySqlParameter2 = new MySqlParameter("@CompletedTime", MySqlDbType.DateTime);
        mySqlParameter2.Value = (object) completedTime.Value;
        mySqlParameter1 = mySqlParameter2;
      }
      else
      {
        mySqlParameter1 = new MySqlParameter("@CompletedTime", MySqlDbType.DateTime);
        mySqlParameter1.Value = (object) DBNull.Value;
      }
      mySqlParameterArray[index1] = mySqlParameter1;
      int index2 = 1;
      MySqlParameter mySqlParameter3 = new MySqlParameter("@ReceiveTime", MySqlDbType.DateTime);
      mySqlParameter3.Value = (object) receiveTime;
      mySqlParameterArray[index2] = mySqlParameter3;
      int index3 = 2;
      MySqlParameter mySqlParameter4 = new MySqlParameter("@SenderTime", MySqlDbType.DateTime);
      mySqlParameter4.Value = (object) receiveTime;
      mySqlParameterArray[index3] = mySqlParameter4;
      int index4 = 3;
      MySqlParameter mySqlParameter5 = new MySqlParameter("@FlowID", MySqlDbType.VarChar);
      mySqlParameter5.Value = (object) flowID.ToString();
      mySqlParameterArray[index4] = mySqlParameter5;
      int index5 = 4;
      MySqlParameter mySqlParameter6 = new MySqlParameter("@StepID", MySqlDbType.VarChar);
      mySqlParameter6.Value = (object) stepID.ToString();
      mySqlParameterArray[index5] = mySqlParameter6;
      int index6 = 5;
      MySqlParameter mySqlParameter7 = new MySqlParameter("@GroupID", MySqlDbType.VarChar);
      mySqlParameter7.Value = (object) groupID.ToString();
      mySqlParameterArray[index6] = mySqlParameter7;
      MySqlParameter[] parameter = mySqlParameterArray;
      return this.dbHelper.Execute(sql, parameter, false);
    }

    public int DeleteTempTasks(Guid flowID, Guid stepID, Guid groupID, Guid prevStepID)
    {
      string sql = "DELETE WorkFlowTask WHERE FlowID=@FlowID AND StepID=@StepID AND GroupID=@GroupID AND Status=-1";
      List<MySqlParameter> mySqlParameterList1 = new List<MySqlParameter>();
      MySqlParameter mySqlParameter1 = new MySqlParameter("@FlowID", MySqlDbType.VarChar);
      mySqlParameter1.Value = (object) flowID.ToString();
      mySqlParameterList1.Add(mySqlParameter1);
      MySqlParameter mySqlParameter2 = new MySqlParameter("@StepID", MySqlDbType.VarChar);
      mySqlParameter2.Value = (object) stepID.ToString();
      mySqlParameterList1.Add(mySqlParameter2);
      MySqlParameter mySqlParameter3 = new MySqlParameter("@GroupID", MySqlDbType.VarChar);
      mySqlParameter3.Value = (object) groupID.ToString();
      mySqlParameterList1.Add(mySqlParameter3);
      List<MySqlParameter> mySqlParameterList2 = mySqlParameterList1;
      if (!prevStepID.IsEmptyGuid())
      {
        sql += " AND PrevStepID=@PrevStepID";
        List<MySqlParameter> mySqlParameterList3 = mySqlParameterList2;
        MySqlParameter mySqlParameter4 = new MySqlParameter("@PrevStepID", MySqlDbType.VarChar);
        mySqlParameter4.Value = (object) prevStepID.ToString();
        mySqlParameterList3.Add(mySqlParameter4);
      }
      return this.dbHelper.Execute(sql, mySqlParameterList2.ToArray(), false);
    }

    public int GetTaskStatus(Guid taskID)
    {
      string sql = "SELECT Status FROM WorkFlowTask WHERE ID=@ID";
      MySqlParameter[] mySqlParameterArray = new MySqlParameter[1];
      int index = 0;
      MySqlParameter mySqlParameter = new MySqlParameter("@ID", MySqlDbType.VarChar);
      mySqlParameter.Value = (object) taskID.ToString();
      mySqlParameterArray[index] = mySqlParameter;
      MySqlParameter[] parameter = mySqlParameterArray;
      int test;
      if (!this.dbHelper.GetFieldValue(sql, parameter).IsInt(out test))
        return -1;
      return test;
    }

    public List<RoadFlow.Data.Model.WorkFlowTask> GetBySubFlowGroupID(Guid subflowGroupID)
    {
      string sql = "SELECT * FROM WorkFlowTask WHERE INSTR(SubFlowGroupID,@SubFlowGroupID)>0";
      MySqlParameter[] mySqlParameterArray = new MySqlParameter[1];
      int index = 0;
      MySqlParameter mySqlParameter = new MySqlParameter("@SubFlowGroupID", MySqlDbType.VarChar);
      mySqlParameter.Value = (object) subflowGroupID.ToString();
      mySqlParameterArray[index] = mySqlParameter;
      MySqlParameter[] parameter = mySqlParameterArray;
      MySqlDataReader dataReader = this.dbHelper.GetDataReader(sql, parameter);
      List<RoadFlow.Data.Model.WorkFlowTask> list = this.DataReaderToList(dataReader);
      dataReader.Close();
      return list;
    }

    public RoadFlow.Data.Model.WorkFlowTask GetLastTask(Guid flowID, Guid groupID)
    {
      string sql = "SELECT * FROM WorkFlowTask WHERE FlowID=@FlowID AND GroupID=@GroupID ORDER BY Sort DESC LIMIT 0,1";
      MySqlParameter[] mySqlParameterArray = new MySqlParameter[2];
      int index1 = 0;
      MySqlParameter mySqlParameter1 = new MySqlParameter("@FlowID", MySqlDbType.VarChar);
      mySqlParameter1.Value = (object) flowID.ToString();
      mySqlParameterArray[index1] = mySqlParameter1;
      int index2 = 1;
      MySqlParameter mySqlParameter2 = new MySqlParameter("@GroupID", MySqlDbType.VarChar);
      mySqlParameter2.Value = (object) groupID.ToString();
      mySqlParameterArray[index2] = mySqlParameter2;
      MySqlParameter[] parameter = mySqlParameterArray;
      MySqlDataReader dataReader = this.dbHelper.GetDataReader(sql, parameter);
      List<RoadFlow.Data.Model.WorkFlowTask> list = this.DataReaderToList(dataReader);
      dataReader.Close();
      if (list.Count <= 0)
        return (RoadFlow.Data.Model.WorkFlowTask) null;
      return list[0];
    }

    public List<RoadFlow.Data.Model.WorkFlowTask> GetExpiredAutoSubmitTasks()
    {
      MySqlDataReader dataReader = this.dbHelper.GetDataReader("SELECT * FROM WorkFlowTask WHERE CompletedTime<'" + DateTimeNew.Now.ToDateTimeStringS() + "' AND IsExpiredAutoSubmit=1 AND Status IN(0,1)");
      List<RoadFlow.Data.Model.WorkFlowTask> list = this.DataReaderToList(dataReader);
      dataReader.Close();
      return list;
    }
  }
}
