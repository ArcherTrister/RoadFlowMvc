// Decompiled with JetBrains decompiler
// Type: RoadFlow.Data.ORACLE.WorkFlowTask
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
  public class WorkFlowTask : IWorkFlowTask
  {
    private DBHelper dbHelper = new DBHelper();

    public int Add(RoadFlow.Data.Model.WorkFlowTask model)
    {
      string sql = "INSERT INTO WorkFlowTask\r\n\t\t\t\t(ID,PrevID,PrevStepID,FlowID,StepID,StepName,InstanceID,GroupID,Type,Title,SenderID,SenderName,SenderTime,ReceiveID,ReceiveName,ReceiveTime,OpenTime,CompletedTime,CompletedTime1,Comment1,IsSign,Status,Note,Sort,SubFlowGroupID,OtherType,Files,IsExpiredAutoSubmit,StepSort) \r\n\t\t\t\tVALUES(:ID,:PrevID,:PrevStepID,:FlowID,:StepID,:StepName,:InstanceID,:GroupID,:Type,:Title,:SenderID,:SenderName,:SenderTime,:ReceiveID,:ReceiveName,:ReceiveTime,:OpenTime,:CompletedTime,:CompletedTime1,:Comment1,:IsSign,:Status,:Note,:Sort,:SubFlowGroupID,:OtherType,:Files,:IsExpiredAutoSubmit,:StepSort)";
      OracleParameter[] oracleParameterArray = new OracleParameter[29];
      int index1 = 0;
      OracleParameter oracleParameter1 = new OracleParameter(":ID", OracleDbType.Varchar2, 40);
      oracleParameter1.Value = (object) model.ID;
      oracleParameterArray[index1] = oracleParameter1;
      int index2 = 1;
      OracleParameter oracleParameter2 = new OracleParameter(":PrevID", OracleDbType.Varchar2, 40);
      oracleParameter2.Value = (object) model.PrevID;
      oracleParameterArray[index2] = oracleParameter2;
      int index3 = 2;
      OracleParameter oracleParameter3 = new OracleParameter(":PrevStepID", OracleDbType.Varchar2, 40);
      oracleParameter3.Value = (object) model.PrevStepID;
      oracleParameterArray[index3] = oracleParameter3;
      int index4 = 3;
      OracleParameter oracleParameter4 = new OracleParameter(":FlowID", OracleDbType.Varchar2, 40);
      oracleParameter4.Value = (object) model.FlowID;
      oracleParameterArray[index4] = oracleParameter4;
      int index5 = 4;
      OracleParameter oracleParameter5 = new OracleParameter(":StepID", OracleDbType.Varchar2, 40);
      oracleParameter5.Value = (object) model.StepID;
      oracleParameterArray[index5] = oracleParameter5;
      int index6 = 5;
      OracleParameter oracleParameter6 = new OracleParameter(":StepName", OracleDbType.NVarchar2, 1000);
      oracleParameter6.Value = (object) model.StepName;
      oracleParameterArray[index6] = oracleParameter6;
      int index7 = 6;
      OracleParameter oracleParameter7 = new OracleParameter(":InstanceID", OracleDbType.Varchar2, 50);
      oracleParameter7.Value = (object) model.InstanceID;
      oracleParameterArray[index7] = oracleParameter7;
      int index8 = 7;
      OracleParameter oracleParameter8 = new OracleParameter(":GroupID", OracleDbType.Varchar2, 40);
      oracleParameter8.Value = (object) model.GroupID;
      oracleParameterArray[index8] = oracleParameter8;
      int index9 = 8;
      OracleParameter oracleParameter9 = new OracleParameter(":Type", OracleDbType.Int32);
      oracleParameter9.Value = (object) model.Type;
      oracleParameterArray[index9] = oracleParameter9;
      int index10 = 9;
      OracleParameter oracleParameter10 = new OracleParameter(":Title", OracleDbType.NVarchar2, 4000);
      oracleParameter10.Value = (object) model.Title;
      oracleParameterArray[index10] = oracleParameter10;
      int index11 = 10;
      OracleParameter oracleParameter11 = new OracleParameter(":SenderID", OracleDbType.Varchar2, 40);
      oracleParameter11.Value = (object) model.SenderID;
      oracleParameterArray[index11] = oracleParameter11;
      int index12 = 11;
      OracleParameter oracleParameter12 = new OracleParameter(":SenderName", OracleDbType.NVarchar2, 100);
      oracleParameter12.Value = (object) model.SenderName;
      oracleParameterArray[index12] = oracleParameter12;
      int index13 = 12;
      OracleParameter oracleParameter13 = new OracleParameter(":SenderTime", OracleDbType.Date, 8);
      oracleParameter13.Value = (object) model.SenderTime;
      oracleParameterArray[index13] = oracleParameter13;
      int index14 = 13;
      OracleParameter oracleParameter14 = new OracleParameter(":ReceiveID", OracleDbType.Varchar2, 40);
      oracleParameter14.Value = (object) model.ReceiveID;
      oracleParameterArray[index14] = oracleParameter14;
      int index15 = 14;
      OracleParameter oracleParameter15 = new OracleParameter(":ReceiveName", OracleDbType.NVarchar2, 100);
      oracleParameter15.Value = (object) model.ReceiveName;
      oracleParameterArray[index15] = oracleParameter15;
      int index16 = 15;
      OracleParameter oracleParameter16 = new OracleParameter(":ReceiveTime", OracleDbType.Date, 8);
      oracleParameter16.Value = (object) model.ReceiveTime;
      oracleParameterArray[index16] = oracleParameter16;
      int index17 = 16;
      OracleParameter oracleParameter17;
      if (model.OpenTime.HasValue)
      {
        OracleParameter oracleParameter18 = new OracleParameter(":OpenTime", OracleDbType.Date, 8);
        oracleParameter18.Value = (object) model.OpenTime;
        oracleParameter17 = oracleParameter18;
      }
      else
      {
        oracleParameter17 = new OracleParameter(":OpenTime", OracleDbType.Date, 8);
        oracleParameter17.Value = (object) DBNull.Value;
      }
      oracleParameterArray[index17] = oracleParameter17;
      int index18 = 17;
      DateTime? nullable1 = model.CompletedTime;
      OracleParameter oracleParameter19;
      if (nullable1.HasValue)
      {
        OracleParameter oracleParameter18 = new OracleParameter(":CompletedTime", OracleDbType.Date, 8);
        oracleParameter18.Value = (object) model.CompletedTime;
        oracleParameter19 = oracleParameter18;
      }
      else
      {
        oracleParameter19 = new OracleParameter(":CompletedTime", OracleDbType.Date, 8);
        oracleParameter19.Value = (object) DBNull.Value;
      }
      oracleParameterArray[index18] = oracleParameter19;
      int index19 = 18;
      nullable1 = model.CompletedTime1;
      OracleParameter oracleParameter20;
      if (nullable1.HasValue)
      {
        OracleParameter oracleParameter18 = new OracleParameter(":CompletedTime1", OracleDbType.Date, 8);
        oracleParameter18.Value = (object) model.CompletedTime1;
        oracleParameter20 = oracleParameter18;
      }
      else
      {
        oracleParameter20 = new OracleParameter(":CompletedTime1", OracleDbType.Date, 8);
        oracleParameter20.Value = (object) DBNull.Value;
      }
      oracleParameterArray[index19] = oracleParameter20;
      int index20 = 19;
      OracleParameter oracleParameter21;
      if (model.Comment != null)
      {
        OracleParameter oracleParameter18 = new OracleParameter(":Comment1", OracleDbType.NVarchar2);
        oracleParameter18.Value = (object) model.Comment;
        oracleParameter21 = oracleParameter18;
      }
      else
      {
        oracleParameter21 = new OracleParameter(":Comment1", OracleDbType.NVarchar2);
        oracleParameter21.Value = (object) DBNull.Value;
      }
      oracleParameterArray[index20] = oracleParameter21;
      int index21 = 20;
      int? nullable2 = model.IsSign;
      OracleParameter oracleParameter22;
      if (nullable2.HasValue)
      {
        OracleParameter oracleParameter18 = new OracleParameter(":IsSign", OracleDbType.Int32);
        oracleParameter18.Value = (object) model.IsSign;
        oracleParameter22 = oracleParameter18;
      }
      else
      {
        oracleParameter22 = new OracleParameter(":IsSign", OracleDbType.Int32);
        oracleParameter22.Value = (object) DBNull.Value;
      }
      oracleParameterArray[index21] = oracleParameter22;
      int index22 = 21;
      OracleParameter oracleParameter23 = new OracleParameter(":Status", OracleDbType.Int32);
      oracleParameter23.Value = (object) model.Status;
      oracleParameterArray[index22] = oracleParameter23;
      int index23 = 22;
      OracleParameter oracleParameter24;
      if (model.Note != null)
      {
        OracleParameter oracleParameter18 = new OracleParameter(":Note", OracleDbType.NVarchar2);
        oracleParameter18.Value = (object) model.Note;
        oracleParameter24 = oracleParameter18;
      }
      else
      {
        oracleParameter24 = new OracleParameter(":Note", OracleDbType.NVarchar2);
        oracleParameter24.Value = (object) DBNull.Value;
      }
      oracleParameterArray[index23] = oracleParameter24;
      int index24 = 23;
      OracleParameter oracleParameter25 = new OracleParameter(":Sort", OracleDbType.Int32);
      oracleParameter25.Value = (object) model.Sort;
      oracleParameterArray[index24] = oracleParameter25;
      int index25 = 24;
      OracleParameter oracleParameter26;
      if (model.SubFlowGroupID != null)
      {
        OracleParameter oracleParameter18 = new OracleParameter(":SubFlowGroupID", OracleDbType.Varchar2);
        oracleParameter18.Value = (object) model.SubFlowGroupID;
        oracleParameter26 = oracleParameter18;
      }
      else
      {
        oracleParameter26 = new OracleParameter(":SubFlowGroupID", OracleDbType.Varchar2);
        oracleParameter26.Value = (object) DBNull.Value;
      }
      oracleParameterArray[index25] = oracleParameter26;
      int index26 = 25;
      nullable2 = model.OtherType;
      OracleParameter oracleParameter27;
      if (nullable2.HasValue)
      {
        OracleParameter oracleParameter18 = new OracleParameter(":OtherType", OracleDbType.Int32);
        oracleParameter18.Value = (object) model.OtherType;
        oracleParameter27 = oracleParameter18;
      }
      else
      {
        oracleParameter27 = new OracleParameter(":OtherType", OracleDbType.Int32);
        oracleParameter27.Value = (object) DBNull.Value;
      }
      oracleParameterArray[index26] = oracleParameter27;
      int index27 = 26;
      OracleParameter oracleParameter28;
      if (model.Files != null)
      {
        OracleParameter oracleParameter18 = new OracleParameter(":Files", OracleDbType.Varchar2);
        oracleParameter18.Value = (object) model.Files;
        oracleParameter28 = oracleParameter18;
      }
      else
      {
        oracleParameter28 = new OracleParameter(":Files", OracleDbType.Varchar2);
        oracleParameter28.Value = (object) DBNull.Value;
      }
      oracleParameterArray[index27] = oracleParameter28;
      int index28 = 27;
      OracleParameter oracleParameter29 = new OracleParameter(":IsExpiredAutoSubmit", OracleDbType.Int32);
      oracleParameter29.Value = (object) model.IsExpiredAutoSubmit;
      oracleParameterArray[index28] = oracleParameter29;
      int index29 = 28;
      OracleParameter oracleParameter30 = new OracleParameter(":StepSort", OracleDbType.Int32);
      oracleParameter30.Value = (object) model.StepSort;
      oracleParameterArray[index29] = oracleParameter30;
      OracleParameter[] parameter = oracleParameterArray;
      return this.dbHelper.Execute(sql, parameter);
    }

    public int Update(RoadFlow.Data.Model.WorkFlowTask model)
    {
      string sql = "UPDATE WorkFlowTask SET \r\n\t\t\t\tPrevID=:PrevID,PrevStepID=:PrevStepID,FlowID=:FlowID,StepID=:StepID,StepName=:StepName,InstanceID=:InstanceID,GroupID=:GroupID,Type=:Type,Title=:Title,SenderID=:SenderID,SenderName=:SenderName,SenderTime=:SenderTime,ReceiveID=:ReceiveID,ReceiveName=:ReceiveName,ReceiveTime=:ReceiveTime,OpenTime=:OpenTime,CompletedTime=:CompletedTime,CompletedTime1=:CompletedTime1,Comment1=:Comment1,IsSign=:IsSign,Status=:Status,Note=:Note,Sort=:Sort,SubFlowGroupID=:SubFlowGroupID,OtherType=:OtherType,Files=:Files,IsExpiredAutoSubmit=:IsExpiredAutoSubmit,StepSort=:StepSort  \r\n\t\t\t\tWHERE ID=:ID";
      OracleParameter[] oracleParameterArray = new OracleParameter[29];
      int index1 = 0;
      OracleParameter oracleParameter1 = new OracleParameter(":PrevID", OracleDbType.Varchar2, 40);
      oracleParameter1.Value = (object) model.PrevID;
      oracleParameterArray[index1] = oracleParameter1;
      int index2 = 1;
      OracleParameter oracleParameter2 = new OracleParameter(":PrevStepID", OracleDbType.Varchar2, 40);
      oracleParameter2.Value = (object) model.PrevStepID;
      oracleParameterArray[index2] = oracleParameter2;
      int index3 = 2;
      OracleParameter oracleParameter3 = new OracleParameter(":FlowID", OracleDbType.Varchar2, 40);
      oracleParameter3.Value = (object) model.FlowID;
      oracleParameterArray[index3] = oracleParameter3;
      int index4 = 3;
      OracleParameter oracleParameter4 = new OracleParameter(":StepID", OracleDbType.Varchar2, 40);
      oracleParameter4.Value = (object) model.StepID;
      oracleParameterArray[index4] = oracleParameter4;
      int index5 = 4;
      OracleParameter oracleParameter5 = new OracleParameter(":StepName", OracleDbType.NVarchar2, 1000);
      oracleParameter5.Value = (object) model.StepName;
      oracleParameterArray[index5] = oracleParameter5;
      int index6 = 5;
      OracleParameter oracleParameter6 = new OracleParameter(":InstanceID", OracleDbType.Varchar2, 50);
      oracleParameter6.Value = (object) model.InstanceID;
      oracleParameterArray[index6] = oracleParameter6;
      int index7 = 6;
      OracleParameter oracleParameter7 = new OracleParameter(":GroupID", OracleDbType.Varchar2, 40);
      oracleParameter7.Value = (object) model.GroupID;
      oracleParameterArray[index7] = oracleParameter7;
      int index8 = 7;
      OracleParameter oracleParameter8 = new OracleParameter(":Type", OracleDbType.Int32);
      oracleParameter8.Value = (object) model.Type;
      oracleParameterArray[index8] = oracleParameter8;
      int index9 = 8;
      OracleParameter oracleParameter9 = new OracleParameter(":Title", OracleDbType.NVarchar2, 4000);
      oracleParameter9.Value = (object) model.Title;
      oracleParameterArray[index9] = oracleParameter9;
      int index10 = 9;
      OracleParameter oracleParameter10 = new OracleParameter(":SenderID", OracleDbType.Varchar2, 40);
      oracleParameter10.Value = (object) model.SenderID;
      oracleParameterArray[index10] = oracleParameter10;
      int index11 = 10;
      OracleParameter oracleParameter11 = new OracleParameter(":SenderName", OracleDbType.NVarchar2, 100);
      oracleParameter11.Value = (object) model.SenderName;
      oracleParameterArray[index11] = oracleParameter11;
      int index12 = 11;
      OracleParameter oracleParameter12 = new OracleParameter(":SenderTime", OracleDbType.Date, 8);
      oracleParameter12.Value = (object) model.SenderTime;
      oracleParameterArray[index12] = oracleParameter12;
      int index13 = 12;
      OracleParameter oracleParameter13 = new OracleParameter(":ReceiveID", OracleDbType.Varchar2, 40);
      oracleParameter13.Value = (object) model.ReceiveID;
      oracleParameterArray[index13] = oracleParameter13;
      int index14 = 13;
      OracleParameter oracleParameter14 = new OracleParameter(":ReceiveName", OracleDbType.NVarchar2, 100);
      oracleParameter14.Value = (object) model.ReceiveName;
      oracleParameterArray[index14] = oracleParameter14;
      int index15 = 14;
      OracleParameter oracleParameter15 = new OracleParameter(":ReceiveTime", OracleDbType.Date, 8);
      oracleParameter15.Value = (object) model.ReceiveTime;
      oracleParameterArray[index15] = oracleParameter15;
      int index16 = 15;
      OracleParameter oracleParameter16;
      if (model.OpenTime.HasValue)
      {
        OracleParameter oracleParameter17 = new OracleParameter(":OpenTime", OracleDbType.Date, 8);
        oracleParameter17.Value = (object) model.OpenTime;
        oracleParameter16 = oracleParameter17;
      }
      else
      {
        oracleParameter16 = new OracleParameter(":OpenTime", OracleDbType.Date, 8);
        oracleParameter16.Value = (object) DBNull.Value;
      }
      oracleParameterArray[index16] = oracleParameter16;
      int index17 = 16;
      DateTime? nullable1 = model.CompletedTime;
      OracleParameter oracleParameter18;
      if (nullable1.HasValue)
      {
        OracleParameter oracleParameter17 = new OracleParameter(":CompletedTime", OracleDbType.Date, 8);
        oracleParameter17.Value = (object) model.CompletedTime;
        oracleParameter18 = oracleParameter17;
      }
      else
      {
        oracleParameter18 = new OracleParameter(":CompletedTime", OracleDbType.Date, 8);
        oracleParameter18.Value = (object) DBNull.Value;
      }
      oracleParameterArray[index17] = oracleParameter18;
      int index18 = 17;
      nullable1 = model.CompletedTime1;
      OracleParameter oracleParameter19;
      if (nullable1.HasValue)
      {
        OracleParameter oracleParameter17 = new OracleParameter(":CompletedTime1", OracleDbType.Date, 8);
        oracleParameter17.Value = (object) model.CompletedTime1;
        oracleParameter19 = oracleParameter17;
      }
      else
      {
        oracleParameter19 = new OracleParameter(":CompletedTime1", OracleDbType.Date, 8);
        oracleParameter19.Value = (object) DBNull.Value;
      }
      oracleParameterArray[index18] = oracleParameter19;
      int index19 = 18;
      OracleParameter oracleParameter20;
      if (model.Comment != null)
      {
        OracleParameter oracleParameter17 = new OracleParameter(":Comment1", OracleDbType.NVarchar2);
        oracleParameter17.Value = (object) model.Comment;
        oracleParameter20 = oracleParameter17;
      }
      else
      {
        oracleParameter20 = new OracleParameter(":Comment1", OracleDbType.NVarchar2);
        oracleParameter20.Value = (object) DBNull.Value;
      }
      oracleParameterArray[index19] = oracleParameter20;
      int index20 = 19;
      int? nullable2 = model.IsSign;
      OracleParameter oracleParameter21;
      if (nullable2.HasValue)
      {
        OracleParameter oracleParameter17 = new OracleParameter(":IsSign", OracleDbType.Int32);
        oracleParameter17.Value = (object) model.IsSign;
        oracleParameter21 = oracleParameter17;
      }
      else
      {
        oracleParameter21 = new OracleParameter(":IsSign", OracleDbType.Int32);
        oracleParameter21.Value = (object) DBNull.Value;
      }
      oracleParameterArray[index20] = oracleParameter21;
      int index21 = 20;
      OracleParameter oracleParameter22 = new OracleParameter(":Status", OracleDbType.Int32);
      oracleParameter22.Value = (object) model.Status;
      oracleParameterArray[index21] = oracleParameter22;
      int index22 = 21;
      OracleParameter oracleParameter23;
      if (model.Note != null)
      {
        OracleParameter oracleParameter17 = new OracleParameter(":Note", OracleDbType.NVarchar2);
        oracleParameter17.Value = (object) model.Note;
        oracleParameter23 = oracleParameter17;
      }
      else
      {
        oracleParameter23 = new OracleParameter(":Note", OracleDbType.NVarchar2);
        oracleParameter23.Value = (object) DBNull.Value;
      }
      oracleParameterArray[index22] = oracleParameter23;
      int index23 = 22;
      OracleParameter oracleParameter24 = new OracleParameter(":Sort", OracleDbType.Int32);
      oracleParameter24.Value = (object) model.Sort;
      oracleParameterArray[index23] = oracleParameter24;
      int index24 = 23;
      OracleParameter oracleParameter25;
      if (model.SubFlowGroupID != null)
      {
        OracleParameter oracleParameter17 = new OracleParameter(":SubFlowGroupID", OracleDbType.Varchar2);
        oracleParameter17.Value = (object) model.SubFlowGroupID;
        oracleParameter25 = oracleParameter17;
      }
      else
      {
        oracleParameter25 = new OracleParameter(":SubFlowGroupID", OracleDbType.Varchar2);
        oracleParameter25.Value = (object) DBNull.Value;
      }
      oracleParameterArray[index24] = oracleParameter25;
      int index25 = 24;
      nullable2 = model.OtherType;
      OracleParameter oracleParameter26;
      if (nullable2.HasValue)
      {
        OracleParameter oracleParameter17 = new OracleParameter(":OtherType", OracleDbType.Int32);
        oracleParameter17.Value = (object) model.OtherType;
        oracleParameter26 = oracleParameter17;
      }
      else
      {
        oracleParameter26 = new OracleParameter(":OtherType", OracleDbType.Int32);
        oracleParameter26.Value = (object) DBNull.Value;
      }
      oracleParameterArray[index25] = oracleParameter26;
      int index26 = 25;
      OracleParameter oracleParameter27;
      if (model.Files != null)
      {
        OracleParameter oracleParameter17 = new OracleParameter(":Files", OracleDbType.Varchar2);
        oracleParameter17.Value = (object) model.Files;
        oracleParameter27 = oracleParameter17;
      }
      else
      {
        oracleParameter27 = new OracleParameter(":Files", OracleDbType.Varchar2);
        oracleParameter27.Value = (object) DBNull.Value;
      }
      oracleParameterArray[index26] = oracleParameter27;
      int index27 = 26;
      OracleParameter oracleParameter28 = new OracleParameter(":IsExpiredAutoSubmit", OracleDbType.Int32);
      oracleParameter28.Value = (object) model.IsExpiredAutoSubmit;
      oracleParameterArray[index27] = oracleParameter28;
      int index28 = 27;
      OracleParameter oracleParameter29 = new OracleParameter(":StepSort", OracleDbType.Int32);
      oracleParameter29.Value = (object) model.StepSort;
      oracleParameterArray[index28] = oracleParameter29;
      int index29 = 28;
      OracleParameter oracleParameter30 = new OracleParameter(":ID", OracleDbType.Varchar2, 40);
      oracleParameter30.Value = (object) model.ID;
      oracleParameterArray[index29] = oracleParameter30;
      OracleParameter[] parameter = oracleParameterArray;
      return this.dbHelper.Execute(sql, parameter);
    }

    public int Delete(Guid id)
    {
      string sql = "DELETE FROM WorkFlowTask WHERE ID=:ID";
      OracleParameter[] oracleParameterArray = new OracleParameter[1];
      int index = 0;
      OracleParameter oracleParameter = new OracleParameter(":ID", OracleDbType.Varchar2);
      oracleParameter.Value = (object) id;
      oracleParameterArray[index] = oracleParameter;
      OracleParameter[] parameter = oracleParameterArray;
      return this.dbHelper.Execute(sql, parameter);
    }

    private List<RoadFlow.Data.Model.WorkFlowTask> DataReaderToList(OracleDataReader dataReader)
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
      OracleDataReader dataReader = this.dbHelper.GetDataReader("SELECT * FROM WorkFlowTask");
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
      string sql = "SELECT * FROM WorkFlowTask WHERE ID=:ID";
      OracleParameter[] oracleParameterArray = new OracleParameter[1];
      int index = 0;
      OracleParameter oracleParameter = new OracleParameter(":ID", OracleDbType.Varchar2);
      oracleParameter.Value = (object) id;
      oracleParameterArray[index] = oracleParameter;
      OracleParameter[] parameter = oracleParameterArray;
      OracleDataReader dataReader = this.dbHelper.GetDataReader(sql, parameter);
      List<RoadFlow.Data.Model.WorkFlowTask> list = this.DataReaderToList(dataReader);
      dataReader.Close();
      if (list.Count <= 0)
        return (RoadFlow.Data.Model.WorkFlowTask) null;
      return list[0];
    }

    public int Delete(Guid flowID, Guid groupID)
    {
      string sql = "DELETE FROM WorkFlowTask WHERE GroupID=:GroupID";
      List<OracleParameter> oracleParameterList1 = new List<OracleParameter>();
      OracleParameter oracleParameter1 = new OracleParameter(":GroupID", OracleDbType.Varchar2);
      oracleParameter1.Value = (object) groupID;
      oracleParameterList1.Add(oracleParameter1);
      List<OracleParameter> oracleParameterList2 = oracleParameterList1;
      if (!flowID.IsEmptyGuid())
      {
        sql += " AND FlowID=:FlowID";
        List<OracleParameter> oracleParameterList3 = oracleParameterList2;
        OracleParameter oracleParameter2 = new OracleParameter(":FlowID", OracleDbType.Varchar2);
        oracleParameter2.Value = (object) flowID;
        oracleParameterList3.Add(oracleParameter2);
      }
      return this.dbHelper.Execute(sql, oracleParameterList2.ToArray());
    }

    public void UpdateOpenTime(Guid id, DateTime openTime, bool isStatus = false)
    {
      string sql = "UPDATE WorkFlowTask SET OpenTime=:OpenTime " + (isStatus ? ", Status=1" : "") + " WHERE ID=:ID AND OpenTime IS NULL";
      OracleParameter[] oracleParameterArray = new OracleParameter[2];
      int index1 = 0;
      OracleParameter oracleParameter1;
      if (!(openTime == DateTime.MinValue))
      {
        OracleParameter oracleParameter2 = new OracleParameter(":OpenTime", OracleDbType.Date);
        oracleParameter2.Value = (object) openTime;
        oracleParameter1 = oracleParameter2;
      }
      else
      {
        oracleParameter1 = new OracleParameter(":OpenTime", OracleDbType.Date);
        oracleParameter1.Value = (object) DBNull.Value;
      }
      oracleParameterArray[index1] = oracleParameter1;
      int index2 = 1;
      OracleParameter oracleParameter3 = new OracleParameter(":ID", OracleDbType.Varchar2);
      oracleParameter3.Value = (object) id;
      oracleParameterArray[index2] = oracleParameter3;
      OracleParameter[] parameter = oracleParameterArray;
      this.dbHelper.Execute(sql, parameter);
    }

    public List<RoadFlow.Data.Model.WorkFlowTask> GetTasks(Guid userID, out string pager, string query = "", string title = "", string flowid = "", string sender = "", string date1 = "", string date2 = "", int type = 0)
    {
      List<OracleParameter> oracleParameterList1 = new List<OracleParameter>();
      StringBuilder stringBuilder = new StringBuilder("SELECT PagerTempTable.*,ROWNUM AS PagerAutoRowNumber FROM(SELECT * FROM WorkFlowTask WHERE ReceiveID=:ReceiveID ");
      stringBuilder.Append(type == 0 ? " AND Status IN(0,1)" : " AND Status IN(2,3,4,5)");
      List<OracleParameter> oracleParameterList2 = oracleParameterList1;
      OracleParameter oracleParameter1 = new OracleParameter(":ReceiveID", OracleDbType.Varchar2);
      oracleParameter1.Value = (object) userID;
      oracleParameterList2.Add(oracleParameter1);
      if (!title.IsNullOrEmpty())
      {
        stringBuilder.Append(" AND INSTR(Title,:Title,1,1)>0");
        List<OracleParameter> oracleParameterList3 = oracleParameterList1;
        OracleParameter oracleParameter2 = new OracleParameter(":Title", OracleDbType.NVarchar2, 2000);
        oracleParameter2.Value = (object) title;
        oracleParameterList3.Add(oracleParameter2);
      }
      if (flowid.IsGuid())
      {
        stringBuilder.Append(" AND FlowID=:FlowID");
        List<OracleParameter> oracleParameterList3 = oracleParameterList1;
        OracleParameter oracleParameter2 = new OracleParameter(":FlowID", OracleDbType.Varchar2);
        oracleParameter2.Value = (object) flowid.ToGuid();
        oracleParameterList3.Add(oracleParameter2);
      }
      else if (!flowid.IsNullOrEmpty() && flowid.IndexOf(',') >= 0)
        stringBuilder.Append(" AND FlowID IN(" + Tools.GetSqlInString(flowid, true, ",") + ")");
      if (sender.IsGuid())
      {
        stringBuilder.Append(" AND SenderID=:SenderID");
        List<OracleParameter> oracleParameterList3 = oracleParameterList1;
        OracleParameter oracleParameter2 = new OracleParameter(":SenderID", OracleDbType.Varchar2);
        oracleParameter2.Value = (object) sender.ToGuid();
        oracleParameterList3.Add(oracleParameter2);
      }
      DateTime dateTime;
      if (date1.IsDateTime())
      {
        stringBuilder.Append(" AND ReceiveTime>=:ReceiveTime");
        List<OracleParameter> oracleParameterList3 = oracleParameterList1;
        OracleParameter oracleParameter2 = new OracleParameter(":ReceiveTime", OracleDbType.Date);
        dateTime = date1.ToDateTime();
        oracleParameter2.Value = (object) dateTime.Date;
        oracleParameterList3.Add(oracleParameter2);
      }
      if (date2.IsDateTime())
      {
        stringBuilder.Append(" AND ReceiveTime<=:ReceiveTime1");
        List<OracleParameter> oracleParameterList3 = oracleParameterList1;
        OracleParameter oracleParameter2 = new OracleParameter(":ReceiveTime1", OracleDbType.Date);
        dateTime = date2.ToDateTime();
        dateTime = dateTime.AddDays(1.0);
        oracleParameter2.Value = (object) dateTime.Date;
        oracleParameterList3.Add(oracleParameter2);
      }
      stringBuilder.Append(" ORDER BY " + (type == 0 ? "ReceiveTime DESC" : "CompletedTime1 DESC") + ") PagerTempTable");
      int pageSize = Tools.GetPageSize();
      int pageNumber = Tools.GetPageNumber();
      long count;
      string paerSql = this.dbHelper.GetPaerSql(stringBuilder.ToString(), pageSize, pageNumber, out count, oracleParameterList1.ToArray());
      pager = Tools.GetPagerHtml(count, pageSize, pageNumber, query);
      OracleDataReader dataReader = this.dbHelper.GetDataReader(paerSql, oracleParameterList1.ToArray());
      List<RoadFlow.Data.Model.WorkFlowTask> list = this.DataReaderToList(dataReader);
      dataReader.Close();
      return list;
    }

    public List<RoadFlow.Data.Model.WorkFlowTask> GetTasks(Guid userID, out long count, int size, int number, string title = "", string flowid = "", string sender = "", string date1 = "", string date2 = "", int type = 0, string order = "")
    {
      List<OracleParameter> oracleParameterList1 = new List<OracleParameter>();
      StringBuilder stringBuilder = new StringBuilder("SELECT PagerTempTable.*,ROWNUM AS PagerAutoRowNumber FROM(SELECT * FROM WorkFlowTask WHERE ReceiveID=:ReceiveID ");
      stringBuilder.Append(type == 0 ? " AND Status IN(0,1)" : " AND Status IN(2,3,4,5)");
      List<OracleParameter> oracleParameterList2 = oracleParameterList1;
      OracleParameter oracleParameter1 = new OracleParameter(":ReceiveID", OracleDbType.Varchar2);
      oracleParameter1.Value = (object) userID;
      oracleParameterList2.Add(oracleParameter1);
      if (!title.IsNullOrEmpty())
      {
        stringBuilder.Append(" AND INSTR(Title,:Title,1,1)>0");
        List<OracleParameter> oracleParameterList3 = oracleParameterList1;
        OracleParameter oracleParameter2 = new OracleParameter(":Title", OracleDbType.NVarchar2, 2000);
        oracleParameter2.Value = (object) title;
        oracleParameterList3.Add(oracleParameter2);
      }
      if (flowid.IsGuid())
      {
        stringBuilder.Append(" AND FlowID=:FlowID");
        List<OracleParameter> oracleParameterList3 = oracleParameterList1;
        OracleParameter oracleParameter2 = new OracleParameter(":FlowID", OracleDbType.Varchar2);
        oracleParameter2.Value = (object) flowid.ToGuid();
        oracleParameterList3.Add(oracleParameter2);
      }
      else if (!flowid.IsNullOrEmpty() && flowid.IndexOf(',') >= 0)
        stringBuilder.Append(" AND FlowID IN(" + Tools.GetSqlInString(flowid, true, ",") + ")");
      if (sender.IsGuid())
      {
        stringBuilder.Append(" AND SenderID=:SenderID");
        List<OracleParameter> oracleParameterList3 = oracleParameterList1;
        OracleParameter oracleParameter2 = new OracleParameter(":SenderID", OracleDbType.Varchar2);
        oracleParameter2.Value = (object) sender.ToGuid();
        oracleParameterList3.Add(oracleParameter2);
      }
      DateTime dateTime;
      if (date1.IsDateTime())
      {
        stringBuilder.Append(" AND ReceiveTime>=:ReceiveTime");
        List<OracleParameter> oracleParameterList3 = oracleParameterList1;
        OracleParameter oracleParameter2 = new OracleParameter(":ReceiveTime", OracleDbType.Date);
        dateTime = date1.ToDateTime();
        oracleParameter2.Value = (object) dateTime.Date;
        oracleParameterList3.Add(oracleParameter2);
      }
      if (date2.IsDateTime())
      {
        stringBuilder.Append(" AND ReceiveTime<=:ReceiveTime1");
        List<OracleParameter> oracleParameterList3 = oracleParameterList1;
        OracleParameter oracleParameter2 = new OracleParameter(":ReceiveTime1", OracleDbType.Date);
        dateTime = date2.ToDateTime();
        dateTime = dateTime.AddDays(1.0);
        oracleParameter2.Value = (object) dateTime.Date;
        oracleParameterList3.Add(oracleParameter2);
      }
      stringBuilder.Append(" ORDER BY " + (order.IsNullOrEmpty() ? (type == 0 ? "ReceiveTime DESC" : "CompletedTime1 DESC") : order) + ") PagerTempTable");
      OracleDataReader dataReader = this.dbHelper.GetDataReader(this.dbHelper.GetPaerSql(stringBuilder.ToString(), size, number, out count, oracleParameterList1.ToArray()), oracleParameterList1.ToArray());
      List<RoadFlow.Data.Model.WorkFlowTask> list = this.DataReaderToList(dataReader);
      dataReader.Close();
      return list;
    }

    public List<RoadFlow.Data.Model.WorkFlowTask> GetInstances(Guid[] flowID, Guid[] senderID, Guid[] receiveID, out string pager, string query = "", string title = "", string flowid = "", string date1 = "", string date2 = "", int status = 0)
    {
      List<OracleParameter> oracleParameterList1 = new List<OracleParameter>();
      StringBuilder stringBuilder = new StringBuilder("SELECT a.*,ROW_NUMBER() OVER(ORDER BY a.SenderTime DESC) PagerAutoRowNumber FROM WorkFlowTask a\r\n                WHERE a.ID=(SELECT ID FROM RF_WORKFLOWTASK WHERE GroupID=a.GroupID AND sort=(select MAX(sort) from RF_WORKFLOWTASK where GroupID=a.GROUPID) AND ROWNUM=1)");
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
          stringBuilder.Append(" AND a.SenderID=:SenderID");
          List<OracleParameter> oracleParameterList2 = oracleParameterList1;
          OracleParameter oracleParameter = new OracleParameter(":SenderID", OracleDbType.Varchar2);
          oracleParameter.Value = (object) senderID[0];
          oracleParameterList2.Add(oracleParameter);
        }
        else
          stringBuilder.Append(string.Format(" AND a.SenderID IN({0})", (object) Tools.GetSqlInString<Guid>(senderID, true)));
      }
      if (receiveID != null && receiveID.Length != 0)
      {
        if (senderID.Length == 1)
        {
          stringBuilder.Append(" AND a.ReceiveID=:ReceiveID");
          List<OracleParameter> oracleParameterList2 = oracleParameterList1;
          OracleParameter oracleParameter = new OracleParameter(":ReceiveID", OracleDbType.Varchar2);
          oracleParameter.Value = (object) receiveID[0];
          oracleParameterList2.Add(oracleParameter);
        }
        else
          stringBuilder.Append(string.Format(" AND a.ReceiveID IN({0})", (object) Tools.GetSqlInString<Guid>(receiveID, true)));
      }
      if (!title.IsNullOrEmpty())
      {
        stringBuilder.Append(" AND INSTR(a.Title,:Title,1,1)>0");
        List<OracleParameter> oracleParameterList2 = oracleParameterList1;
        OracleParameter oracleParameter = new OracleParameter(":Title", OracleDbType.NVarchar2, 2000);
        oracleParameter.Value = (object) title;
        oracleParameterList2.Add(oracleParameter);
      }
      if (flowid.IsGuid())
      {
        stringBuilder.Append(" AND a.FlowID=:FlowID");
        List<OracleParameter> oracleParameterList2 = oracleParameterList1;
        OracleParameter oracleParameter = new OracleParameter(":FlowID", OracleDbType.Varchar2);
        oracleParameter.Value = (object) flowid.ToGuid();
        oracleParameterList2.Add(oracleParameter);
      }
      else if (!flowid.IsNullOrEmpty() && flowid.IndexOf(',') >= 0)
        stringBuilder.Append(" AND a.FlowID IN(" + Tools.GetSqlInString(flowid, true, ",") + ")");
      if (date1.IsDateTime())
      {
        stringBuilder.Append(" AND a.SenderTime>=:SenderTime");
        List<OracleParameter> oracleParameterList2 = oracleParameterList1;
        OracleParameter oracleParameter = new OracleParameter(":SenderTime", OracleDbType.Date);
        oracleParameter.Value = (object) date1.ToDateTime().Date;
        oracleParameterList2.Add(oracleParameter);
      }
      if (date2.IsDateTime())
      {
        stringBuilder.Append(" AND a.SenderTime<=:SenderTime1");
        List<OracleParameter> oracleParameterList2 = oracleParameterList1;
        OracleParameter oracleParameter = new OracleParameter(":SenderTime1", OracleDbType.Date);
        oracleParameter.Value = (object) date2.ToDateTime().AddDays(1.0).Date;
        oracleParameterList2.Add(oracleParameter);
      }
      stringBuilder.Append(" AND ROWNUM<=1) ORDER BY Sort DESC) PagerTempTable");
      int pageSize = Tools.GetPageSize();
      int pageNumber = Tools.GetPageNumber();
      long count;
      string paerSql = this.dbHelper.GetPaerSql(stringBuilder.ToString(), pageSize, pageNumber, out count, oracleParameterList1.ToArray());
      pager = Tools.GetPagerHtml(count, pageSize, pageNumber, query);
      OracleDataReader dataReader = this.dbHelper.GetDataReader(paerSql, oracleParameterList1.ToArray());
      List<RoadFlow.Data.Model.WorkFlowTask> list = this.DataReaderToList(dataReader);
      dataReader.Close();
      return list;
    }

    public DataTable GetInstances1(Guid[] flowID, Guid[] senderID, Guid[] receiveID, out string pager, string query = "", string title = "", string flowid = "", string date1 = "", string date2 = "", int status = 0)
    {
      List<OracleParameter> oracleParameterList1 = new List<OracleParameter>();
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
          stringBuilder.Append(" AND SenderID=:SenderID");
          List<OracleParameter> oracleParameterList2 = oracleParameterList1;
          OracleParameter oracleParameter = new OracleParameter(":SenderID", OracleDbType.Varchar2);
          oracleParameter.Value = (object) senderID[0];
          oracleParameterList2.Add(oracleParameter);
        }
        else
          stringBuilder.Append(string.Format(" AND SenderID IN({0})", (object) Tools.GetSqlInString<Guid>(senderID, true)));
      }
      if (receiveID != null && receiveID.Length != 0)
      {
        if (senderID.Length == 1)
        {
          stringBuilder.Append(" AND ReceiveID=:ReceiveID");
          List<OracleParameter> oracleParameterList2 = oracleParameterList1;
          OracleParameter oracleParameter = new OracleParameter(":ReceiveID", OracleDbType.Varchar2);
          oracleParameter.Value = (object) receiveID[0];
          oracleParameterList2.Add(oracleParameter);
        }
        else
          stringBuilder.Append(string.Format(" AND ReceiveID IN({0})", (object) Tools.GetSqlInString<Guid>(receiveID, true)));
      }
      if (!title.IsNullOrEmpty())
      {
        stringBuilder.Append(" AND INSTR(Title,:Title,1,1)>0");
        List<OracleParameter> oracleParameterList2 = oracleParameterList1;
        OracleParameter oracleParameter = new OracleParameter(":Title", OracleDbType.NVarchar2, 2000);
        oracleParameter.Value = (object) title;
        oracleParameterList2.Add(oracleParameter);
      }
      if (flowid.IsGuid())
      {
        stringBuilder.Append(" AND FlowID=:FlowID");
        List<OracleParameter> oracleParameterList2 = oracleParameterList1;
        OracleParameter oracleParameter = new OracleParameter(":FlowID", OracleDbType.Varchar2);
        oracleParameter.Value = (object) flowid.ToGuid();
        oracleParameterList2.Add(oracleParameter);
      }
      else if (!flowid.IsNullOrEmpty() && flowid.IndexOf(',') >= 0)
        stringBuilder.Append(" AND FlowID IN(" + Tools.GetSqlInString(flowid, true, ",") + ")");
      DateTime dateTime;
      if (date1.IsDateTime())
      {
        stringBuilder.Append(" AND SenderTime>=:SenderTime");
        List<OracleParameter> oracleParameterList2 = oracleParameterList1;
        OracleParameter oracleParameter = new OracleParameter(":SenderTime", OracleDbType.Date);
        dateTime = date1.ToDateTime();
        oracleParameter.Value = (object) dateTime.Date;
        oracleParameterList2.Add(oracleParameter);
      }
      if (date2.IsDateTime())
      {
        stringBuilder.Append(" AND SenderTime<=:SenderTime1");
        List<OracleParameter> oracleParameterList2 = oracleParameterList1;
        OracleParameter oracleParameter = new OracleParameter(":SenderTime1", OracleDbType.Date);
        dateTime = date2.ToDateTime();
        dateTime = dateTime.AddDays(1.0);
        oracleParameter.Value = (object) dateTime.Date;
        oracleParameterList2.Add(oracleParameter);
      }
      string sql = string.Format("select PagerTempTable.*,ROWNUM AS PagerAutoRowNumber FROM(\r\nselect flowid,groupid,MAX(SenderTime) SenderTime from WorkFlowTask where 1=1 {0} group by FlowID, GroupID\r\n) PagerTempTable", (object) stringBuilder.ToString());
      int pageSize = Tools.GetPageSize();
      int pageNumber = Tools.GetPageNumber();
      long count;
      string paerSql = this.dbHelper.GetPaerSql(sql, pageSize, pageNumber, out count, oracleParameterList1.ToArray());
      pager = Tools.GetPagerHtml(count, pageSize, pageNumber, query);
      return this.dbHelper.GetDataTable(paerSql, oracleParameterList1.ToArray());
    }

    public DataTable GetInstances1(Guid[] flowID, Guid[] senderID, Guid[] receiveID, out long count, int size, int number, string title = "", string flowid = "", string date1 = "", string date2 = "", int status = 0, string order = "")
    {
      List<OracleParameter> oracleParameterList1 = new List<OracleParameter>();
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
          stringBuilder.Append(" AND SenderID=:SenderID");
          List<OracleParameter> oracleParameterList2 = oracleParameterList1;
          OracleParameter oracleParameter = new OracleParameter(":SenderID", OracleDbType.Varchar2);
          oracleParameter.Value = (object) senderID[0];
          oracleParameterList2.Add(oracleParameter);
        }
        else
          stringBuilder.Append(string.Format(" AND SenderID IN({0})", (object) Tools.GetSqlInString<Guid>(senderID, true)));
      }
      if (receiveID != null && receiveID.Length != 0)
      {
        if (senderID.Length == 1)
        {
          stringBuilder.Append(" AND ReceiveID=:ReceiveID");
          List<OracleParameter> oracleParameterList2 = oracleParameterList1;
          OracleParameter oracleParameter = new OracleParameter(":ReceiveID", OracleDbType.Varchar2);
          oracleParameter.Value = (object) receiveID[0];
          oracleParameterList2.Add(oracleParameter);
        }
        else
          stringBuilder.Append(string.Format(" AND ReceiveID IN({0})", (object) Tools.GetSqlInString<Guid>(receiveID, true)));
      }
      if (!title.IsNullOrEmpty())
      {
        stringBuilder.Append(" AND INSTR(Title,:Title,1,1)>0");
        List<OracleParameter> oracleParameterList2 = oracleParameterList1;
        OracleParameter oracleParameter = new OracleParameter(":Title", OracleDbType.NVarchar2, 2000);
        oracleParameter.Value = (object) title;
        oracleParameterList2.Add(oracleParameter);
      }
      if (flowid.IsGuid())
      {
        stringBuilder.Append(" AND FlowID=:FlowID");
        List<OracleParameter> oracleParameterList2 = oracleParameterList1;
        OracleParameter oracleParameter = new OracleParameter(":FlowID", OracleDbType.Varchar2);
        oracleParameter.Value = (object) flowid.ToGuid();
        oracleParameterList2.Add(oracleParameter);
      }
      else if (!flowid.IsNullOrEmpty() && flowid.IndexOf(',') >= 0)
        stringBuilder.Append(" AND FlowID IN(" + Tools.GetSqlInString(flowid, true, ",") + ")");
      DateTime dateTime;
      if (date1.IsDateTime())
      {
        stringBuilder.Append(" AND SenderTime>=:SenderTime");
        List<OracleParameter> oracleParameterList2 = oracleParameterList1;
        OracleParameter oracleParameter = new OracleParameter(":SenderTime", OracleDbType.Date);
        dateTime = date1.ToDateTime();
        oracleParameter.Value = (object) dateTime.Date;
        oracleParameterList2.Add(oracleParameter);
      }
      if (date2.IsDateTime())
      {
        stringBuilder.Append(" AND SenderTime<=:SenderTime1");
        List<OracleParameter> oracleParameterList2 = oracleParameterList1;
        OracleParameter oracleParameter = new OracleParameter(":SenderTime1", OracleDbType.Date);
        dateTime = date2.ToDateTime();
        dateTime = dateTime.AddDays(1.0);
        oracleParameter.Value = (object) dateTime.Date;
        oracleParameterList2.Add(oracleParameter);
      }
      return this.dbHelper.GetDataTable(this.dbHelper.GetPaerSql(string.Format("select PagerTempTable.*,ROWNUM AS PagerAutoRowNumber FROM(select flowid,groupid,MAX(SenderTime) SenderTime \r\n            from WorkFlowTask where 1=1 {0} group by FlowID, GroupID ORDER BY " + (order.IsNullOrEmpty() ? "SenderTime DESC" : order) + ") PagerTempTable", (object) stringBuilder.ToString()), size, number, out count, oracleParameterList1.ToArray()), oracleParameterList1.ToArray());
    }

    public Guid GetFirstSnderID(Guid flowID, Guid groupID)
    {
      string sql = "SELECT SenderID FROM WorkFlowTask WHERE FlowID=:FlowID AND GroupID=:GroupID AND PrevID=:PrevID";
      OracleParameter[] oracleParameterArray = new OracleParameter[3];
      int index1 = 0;
      OracleParameter oracleParameter1 = new OracleParameter(":FlowID", OracleDbType.Varchar2);
      oracleParameter1.Value = (object) flowID;
      oracleParameterArray[index1] = oracleParameter1;
      int index2 = 1;
      OracleParameter oracleParameter2 = new OracleParameter(":GroupID", OracleDbType.Varchar2);
      oracleParameter2.Value = (object) groupID;
      oracleParameterArray[index2] = oracleParameter2;
      int index3 = 2;
      OracleParameter oracleParameter3 = new OracleParameter(":PrevID", OracleDbType.Varchar2);
      oracleParameter3.Value = (object) Guid.Empty;
      oracleParameterArray[index3] = oracleParameter3;
      OracleParameter[] parameter = oracleParameterArray;
      return this.dbHelper.GetFieldValue(sql, parameter).ToGuid();
    }

    public List<Guid> GetStepSnderID(Guid flowID, Guid stepID, Guid groupID)
    {
      string sql = "SELECT ReceiveID FROM WorkFlowTask WHERE FlowID=:FlowID AND StepID=:StepID AND GroupID=:GroupID AND Sort=(SELECT ISNULL(MAX(Sort),0) FROM WorkFlowTask WHERE FlowID=:FlowID AND StepID=:StepID AND GroupID=:GroupID)";
      OracleParameter[] oracleParameterArray = new OracleParameter[3];
      int index1 = 0;
      OracleParameter oracleParameter1 = new OracleParameter(":FlowID", OracleDbType.Varchar2);
      oracleParameter1.Value = (object) flowID;
      oracleParameterArray[index1] = oracleParameter1;
      int index2 = 1;
      OracleParameter oracleParameter2 = new OracleParameter(":StepID", OracleDbType.Varchar2);
      oracleParameter2.Value = (object) stepID;
      oracleParameterArray[index2] = oracleParameter2;
      int index3 = 2;
      OracleParameter oracleParameter3 = new OracleParameter(":GroupID", OracleDbType.Varchar2);
      oracleParameter3.Value = (object) groupID;
      oracleParameterArray[index3] = oracleParameter3;
      OracleParameter[] parameter = oracleParameterArray;
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
      string sql = "SELECT ReceiveID FROM WorkFlowTask WHERE ID=(SELECT PrevID FROM WorkFlowTask WHERE FlowID=:FlowID AND StepID=:StepID AND GroupID=:GroupID)";
      OracleParameter[] oracleParameterArray = new OracleParameter[3];
      int index1 = 0;
      OracleParameter oracleParameter1 = new OracleParameter(":FlowID", OracleDbType.Varchar2);
      oracleParameter1.Value = (object) flowID;
      oracleParameterArray[index1] = oracleParameter1;
      int index2 = 1;
      OracleParameter oracleParameter2 = new OracleParameter(":StepID", OracleDbType.Varchar2);
      oracleParameter2.Value = (object) stepID;
      oracleParameterArray[index2] = oracleParameter2;
      int index3 = 2;
      OracleParameter oracleParameter3 = new OracleParameter(":GroupID", OracleDbType.Varchar2);
      oracleParameter3.Value = (object) groupID;
      oracleParameterArray[index3] = oracleParameter3;
      OracleParameter[] parameter = oracleParameterArray;
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
      string sql = "UPDATE WorkFlowTask SET Comment1=:Comment1,CompletedTime1=:CompletedTime1,IsSign=:IsSign,Status=:Status,Note=:Note,Files=:Files WHERE ID=:ID";
      OracleParameter[] oracleParameterArray = new OracleParameter[7];
      int index1 = 0;
      OracleParameter oracleParameter1;
      if (!comment.IsNullOrEmpty())
      {
        OracleParameter oracleParameter2 = new OracleParameter(":Comment1", OracleDbType.Varchar2);
        oracleParameter2.Value = (object) comment;
        oracleParameter1 = oracleParameter2;
      }
      else
      {
        oracleParameter1 = new OracleParameter(":Comment1", OracleDbType.Varchar2);
        oracleParameter1.Value = (object) DBNull.Value;
      }
      oracleParameterArray[index1] = oracleParameter1;
      int index2 = 1;
      OracleParameter oracleParameter3 = new OracleParameter(":CompletedTime1", OracleDbType.Date);
      oracleParameter3.Value = (object) DateTimeNew.Now;
      oracleParameterArray[index2] = oracleParameter3;
      int index3 = 2;
      OracleParameter oracleParameter4 = new OracleParameter(":IsSign", OracleDbType.Int32);
      oracleParameter4.Value = (object) (isSign ? 1 : 0);
      oracleParameterArray[index3] = oracleParameter4;
      int index4 = 3;
      OracleParameter oracleParameter5 = new OracleParameter(":Status", OracleDbType.Int32);
      oracleParameter5.Value = (object) status;
      oracleParameterArray[index4] = oracleParameter5;
      int index5 = 4;
      OracleParameter oracleParameter6;
      if (!note.IsNullOrEmpty())
      {
        OracleParameter oracleParameter2 = new OracleParameter(":Note", OracleDbType.NVarchar2);
        oracleParameter2.Value = (object) note;
        oracleParameter6 = oracleParameter2;
      }
      else
      {
        oracleParameter6 = new OracleParameter(":Note", OracleDbType.NVarchar2);
        oracleParameter6.Value = (object) DBNull.Value;
      }
      oracleParameterArray[index5] = oracleParameter6;
      int index6 = 5;
      OracleParameter oracleParameter7;
      if (!files.IsNullOrEmpty())
      {
        OracleParameter oracleParameter2 = new OracleParameter(":Files", OracleDbType.Varchar2);
        oracleParameter2.Value = (object) files;
        oracleParameter7 = oracleParameter2;
      }
      else
      {
        oracleParameter7 = new OracleParameter(":Files", OracleDbType.Varchar2);
        oracleParameter7.Value = (object) DBNull.Value;
      }
      oracleParameterArray[index6] = oracleParameter7;
      int index7 = 6;
      OracleParameter oracleParameter8 = new OracleParameter(":ID", OracleDbType.Varchar2);
      oracleParameter8.Value = (object) taskID;
      oracleParameterArray[index7] = oracleParameter8;
      OracleParameter[] parameter = oracleParameterArray;
      return this.dbHelper.Execute(sql, parameter);
    }

    public int UpdateNextTaskStatus(Guid taskID, int status)
    {
      string sql = "UPDATE WorkFlowTask SET Status=:Status WHERE PrevID=:PrevID";
      OracleParameter[] oracleParameterArray = new OracleParameter[2];
      int index1 = 0;
      OracleParameter oracleParameter1 = new OracleParameter(":Status", OracleDbType.Int32);
      oracleParameter1.Value = (object) status;
      oracleParameterArray[index1] = oracleParameter1;
      int index2 = 1;
      OracleParameter oracleParameter2 = new OracleParameter(":PrevID", OracleDbType.Varchar2);
      oracleParameter2.Value = (object) taskID;
      oracleParameterArray[index2] = oracleParameter2;
      OracleParameter[] parameter = oracleParameterArray;
      return this.dbHelper.Execute(sql, parameter);
    }

    public List<RoadFlow.Data.Model.WorkFlowTask> GetTaskList(Guid flowID, Guid stepID, Guid groupID)
    {
      string sql = "SELECT * FROM WorkFlowTask WHERE FlowID=:FlowID AND StepID=:StepID AND GroupID=:GroupID";
      OracleParameter[] oracleParameterArray = new OracleParameter[3];
      int index1 = 0;
      OracleParameter oracleParameter1 = new OracleParameter(":FlowID", OracleDbType.Varchar2);
      oracleParameter1.Value = (object) flowID;
      oracleParameterArray[index1] = oracleParameter1;
      int index2 = 1;
      OracleParameter oracleParameter2 = new OracleParameter(":StepID", OracleDbType.Varchar2);
      oracleParameter2.Value = (object) stepID;
      oracleParameterArray[index2] = oracleParameter2;
      int index3 = 2;
      OracleParameter oracleParameter3 = new OracleParameter(":GroupID", OracleDbType.Varchar2);
      oracleParameter3.Value = (object) groupID;
      oracleParameterArray[index3] = oracleParameter3;
      OracleParameter[] parameter = oracleParameterArray;
      OracleDataReader dataReader = this.dbHelper.GetDataReader(sql, parameter);
      List<RoadFlow.Data.Model.WorkFlowTask> list = this.DataReaderToList(dataReader);
      dataReader.Close();
      return list;
    }

    public List<RoadFlow.Data.Model.WorkFlowTask> GetUserTaskList(Guid flowID, Guid stepID, Guid groupID, Guid userID)
    {
      string sql = "SELECT * FROM WorkFlowTask WHERE FlowID=:FlowID AND StepID=:StepID AND GroupID=:GroupID AND ReceiveID=:ReceiveID";
      OracleParameter[] oracleParameterArray = new OracleParameter[4];
      int index1 = 0;
      OracleParameter oracleParameter1 = new OracleParameter(":FlowID", OracleDbType.Varchar2);
      oracleParameter1.Value = (object) flowID;
      oracleParameterArray[index1] = oracleParameter1;
      int index2 = 1;
      OracleParameter oracleParameter2 = new OracleParameter(":StepID", OracleDbType.Varchar2);
      oracleParameter2.Value = (object) stepID;
      oracleParameterArray[index2] = oracleParameter2;
      int index3 = 2;
      OracleParameter oracleParameter3 = new OracleParameter(":GroupID", OracleDbType.Varchar2);
      oracleParameter3.Value = (object) groupID;
      oracleParameterArray[index3] = oracleParameter3;
      int index4 = 3;
      OracleParameter oracleParameter4 = new OracleParameter(":ReceiveID", OracleDbType.Varchar2);
      oracleParameter4.Value = (object) userID;
      oracleParameterArray[index4] = oracleParameter4;
      OracleParameter[] parameter = oracleParameterArray;
      OracleDataReader dataReader = this.dbHelper.GetDataReader(sql, parameter);
      List<RoadFlow.Data.Model.WorkFlowTask> list = this.DataReaderToList(dataReader);
      dataReader.Close();
      return list;
    }

    public List<RoadFlow.Data.Model.WorkFlowTask> GetTaskList(Guid flowID, Guid groupID)
    {
      string empty = string.Empty;
      string sql;
      OracleParameter[] parameter;
      if (flowID.IsEmptyGuid())
      {
        sql = "SELECT * FROM WorkFlowTask WHERE GroupID=:GroupID";
        OracleParameter[] oracleParameterArray = new OracleParameter[1];
        int index = 0;
        OracleParameter oracleParameter = new OracleParameter(":GroupID", OracleDbType.Varchar2);
        oracleParameter.Value = (object) groupID;
        oracleParameterArray[index] = oracleParameter;
        parameter = oracleParameterArray;
      }
      else
      {
        sql = "SELECT * FROM WorkFlowTask WHERE FlowID=:FlowID AND GroupID=:GroupID";
        OracleParameter[] oracleParameterArray = new OracleParameter[2];
        int index1 = 0;
        OracleParameter oracleParameter1 = new OracleParameter(":FlowID", OracleDbType.Varchar2);
        oracleParameter1.Value = (object) flowID;
        oracleParameterArray[index1] = oracleParameter1;
        int index2 = 1;
        OracleParameter oracleParameter2 = new OracleParameter(":GroupID", OracleDbType.Varchar2);
        oracleParameter2.Value = (object) groupID;
        oracleParameterArray[index2] = oracleParameter2;
        parameter = oracleParameterArray;
      }
      OracleDataReader dataReader = this.dbHelper.GetDataReader(sql, parameter);
      List<RoadFlow.Data.Model.WorkFlowTask> list = this.DataReaderToList(dataReader);
      dataReader.Close();
      return list;
    }

    public List<RoadFlow.Data.Model.WorkFlowTask> GetTaskList(Guid taskID, bool isStepID = true)
    {
      RoadFlow.Data.Model.WorkFlowTask workFlowTask = this.Get(taskID);
      if (workFlowTask == null)
        return new List<RoadFlow.Data.Model.WorkFlowTask>();
      string sql = string.Format("SELECT * FROM WorkFlowTask WHERE FlowID=:FlowID AND GroupID=:GroupID AND PrevID=:PrevID AND {0}", isStepID ? (object) "StepID=:StepID" : (object) "PrevStepID=:StepID");
      OracleParameter[] oracleParameterArray = new OracleParameter[4];
      int index1 = 0;
      OracleParameter oracleParameter1 = new OracleParameter(":FlowID", OracleDbType.Varchar2);
      oracleParameter1.Value = (object) workFlowTask.FlowID;
      oracleParameterArray[index1] = oracleParameter1;
      int index2 = 1;
      OracleParameter oracleParameter2 = new OracleParameter(":GroupID", OracleDbType.Varchar2);
      oracleParameter2.Value = (object) workFlowTask.GroupID;
      oracleParameterArray[index2] = oracleParameter2;
      int index3 = 2;
      OracleParameter oracleParameter3 = new OracleParameter(":PrevID", OracleDbType.Varchar2);
      oracleParameter3.Value = (object) workFlowTask.PrevID;
      oracleParameterArray[index3] = oracleParameter3;
      int index4 = 3;
      OracleParameter oracleParameter4 = new OracleParameter(":StepID", OracleDbType.Varchar2);
      oracleParameter4.Value = (object) (isStepID ? workFlowTask.StepID : workFlowTask.PrevStepID);
      oracleParameterArray[index4] = oracleParameter4;
      OracleParameter[] parameter = oracleParameterArray;
      OracleDataReader dataReader = this.dbHelper.GetDataReader(sql, parameter);
      List<RoadFlow.Data.Model.WorkFlowTask> list = this.DataReaderToList(dataReader);
      dataReader.Close();
      return list;
    }

    public List<RoadFlow.Data.Model.WorkFlowTask> GetPrevTaskList(Guid taskID)
    {
      string sql = "SELECT * FROM WorkFlowTask WHERE ID=(SELECT PrevID FROM WorkFlowTask WHERE ID=:ID)";
      OracleParameter[] oracleParameterArray = new OracleParameter[1];
      int index = 0;
      OracleParameter oracleParameter = new OracleParameter(":ID", OracleDbType.Varchar2);
      oracleParameter.Value = (object) taskID;
      oracleParameterArray[index] = oracleParameter;
      OracleParameter[] parameter = oracleParameterArray;
      OracleDataReader dataReader = this.dbHelper.GetDataReader(sql, parameter);
      List<RoadFlow.Data.Model.WorkFlowTask> list = this.DataReaderToList(dataReader);
      dataReader.Close();
      return list;
    }

    public List<RoadFlow.Data.Model.WorkFlowTask> GetNextTaskList(Guid taskID)
    {
      string sql = "SELECT * FROM WorkFlowTask WHERE PrevID=:PrevID";
      OracleParameter[] oracleParameterArray = new OracleParameter[1];
      int index = 0;
      OracleParameter oracleParameter = new OracleParameter(":PrevID", OracleDbType.Varchar2);
      oracleParameter.Value = (object) taskID;
      oracleParameterArray[index] = oracleParameter;
      OracleParameter[] parameter = oracleParameterArray;
      OracleDataReader dataReader = this.dbHelper.GetDataReader(sql, parameter);
      List<RoadFlow.Data.Model.WorkFlowTask> list = this.DataReaderToList(dataReader);
      dataReader.Close();
      return list;
    }

    public bool HasTasks(Guid flowID)
    {
      string sql = "SELECT ID FROM WorkFlowTask WHERE FlowID=:FlowID AND ROWNUM<=1";
      OracleParameter[] oracleParameterArray = new OracleParameter[1];
      int index = 0;
      OracleParameter oracleParameter = new OracleParameter(":FlowID", OracleDbType.Varchar2);
      oracleParameter.Value = (object) flowID;
      oracleParameterArray[index] = oracleParameter;
      OracleParameter[] parameter = oracleParameterArray;
      OracleDataReader dataReader = this.dbHelper.GetDataReader(sql, parameter);
      bool hasRows = dataReader.HasRows;
      dataReader.Close();
      return hasRows;
    }

    public bool HasNoCompletedTasks(Guid flowID, Guid stepID, Guid groupID, Guid userID)
    {
      string sql = "SELECT ID FROM WorkFlowTask WHERE FlowID=:FlowID AND StepID=:StepID AND GroupID=:GroupID AND ReceiveID=:ReceiveID AND Status IN(-1,0,1) AND ROWNUM<=1";
      OracleParameter[] oracleParameterArray = new OracleParameter[4];
      int index1 = 0;
      OracleParameter oracleParameter1 = new OracleParameter(":FlowID", OracleDbType.Varchar2);
      oracleParameter1.Value = (object) flowID;
      oracleParameterArray[index1] = oracleParameter1;
      int index2 = 1;
      OracleParameter oracleParameter2 = new OracleParameter(":StepID", OracleDbType.Varchar2);
      oracleParameter2.Value = (object) stepID;
      oracleParameterArray[index2] = oracleParameter2;
      int index3 = 2;
      OracleParameter oracleParameter3 = new OracleParameter(":GroupID", OracleDbType.Varchar2);
      oracleParameter3.Value = (object) groupID;
      oracleParameterArray[index3] = oracleParameter3;
      int index4 = 3;
      OracleParameter oracleParameter4 = new OracleParameter(":ReceiveID", OracleDbType.Varchar2);
      oracleParameter4.Value = (object) userID;
      oracleParameterArray[index4] = oracleParameter4;
      OracleParameter[] parameter = oracleParameterArray;
      OracleDataReader dataReader = this.dbHelper.GetDataReader(sql, parameter);
      bool hasRows = dataReader.HasRows;
      dataReader.Close();
      return hasRows;
    }

    public int UpdateTempTasks(Guid flowID, Guid stepID, Guid groupID, DateTime? completedTime, DateTime receiveTime)
    {
      string sql = "UPDATE WorkFlowTask SET CompletedTime=:CompletedTime,ReceiveTime=:ReceiveTime,SenderTime=:SenderTime,Status=0 WHERE FlowID=:FlowID AND StepID=:StepID AND GroupID=:GroupID AND Status=-1";
      OracleParameter[] oracleParameterArray = new OracleParameter[6];
      int index1 = 0;
      OracleParameter oracleParameter1;
      if (completedTime.HasValue)
      {
        OracleParameter oracleParameter2 = new OracleParameter(":CompletedTime", OracleDbType.Date);
        oracleParameter2.Value = (object) completedTime.Value;
        oracleParameter1 = oracleParameter2;
      }
      else
      {
        oracleParameter1 = new OracleParameter(":CompletedTime", OracleDbType.Date);
        oracleParameter1.Value = (object) DBNull.Value;
      }
      oracleParameterArray[index1] = oracleParameter1;
      int index2 = 1;
      OracleParameter oracleParameter3 = new OracleParameter(":ReceiveTime", OracleDbType.Date);
      oracleParameter3.Value = (object) receiveTime;
      oracleParameterArray[index2] = oracleParameter3;
      int index3 = 2;
      OracleParameter oracleParameter4 = new OracleParameter(":SenderTime", OracleDbType.Date);
      oracleParameter4.Value = (object) receiveTime;
      oracleParameterArray[index3] = oracleParameter4;
      int index4 = 3;
      OracleParameter oracleParameter5 = new OracleParameter(":FlowID", OracleDbType.Varchar2);
      oracleParameter5.Value = (object) flowID;
      oracleParameterArray[index4] = oracleParameter5;
      int index5 = 4;
      OracleParameter oracleParameter6 = new OracleParameter(":StepID", OracleDbType.Varchar2);
      oracleParameter6.Value = (object) stepID;
      oracleParameterArray[index5] = oracleParameter6;
      int index6 = 5;
      OracleParameter oracleParameter7 = new OracleParameter(":GroupID", OracleDbType.Varchar2);
      oracleParameter7.Value = (object) groupID;
      oracleParameterArray[index6] = oracleParameter7;
      OracleParameter[] parameter = oracleParameterArray;
      return this.dbHelper.Execute(sql, parameter);
    }

    public int DeleteTempTasks(Guid flowID, Guid stepID, Guid groupID, Guid prevStepID)
    {
      string sql = "DELETE WorkFlowTask WHERE FlowID=:FlowID AND StepID=:StepID AND GroupID=:GroupID AND Status=-1";
      List<OracleParameter> oracleParameterList1 = new List<OracleParameter>();
      OracleParameter oracleParameter1 = new OracleParameter(":FlowID", OracleDbType.Varchar2);
      oracleParameter1.Value = (object) flowID;
      oracleParameterList1.Add(oracleParameter1);
      OracleParameter oracleParameter2 = new OracleParameter(":StepID", OracleDbType.Varchar2);
      oracleParameter2.Value = (object) stepID;
      oracleParameterList1.Add(oracleParameter2);
      OracleParameter oracleParameter3 = new OracleParameter(":GroupID", OracleDbType.Varchar2);
      oracleParameter3.Value = (object) groupID;
      oracleParameterList1.Add(oracleParameter3);
      List<OracleParameter> oracleParameterList2 = oracleParameterList1;
      if (!prevStepID.IsEmptyGuid())
      {
        sql += " AND PrevStepID=:PrevStepID";
        List<OracleParameter> oracleParameterList3 = oracleParameterList2;
        OracleParameter oracleParameter4 = new OracleParameter(":PrevStepID", OracleDbType.Varchar2);
        oracleParameter4.Value = (object) prevStepID;
        oracleParameterList3.Add(oracleParameter4);
      }
      return this.dbHelper.Execute(sql, oracleParameterList2.ToArray());
    }

    public int GetTaskStatus(Guid taskID)
    {
      string sql = "SELECT Status FROM WorkFlowTask WHERE ID=:ID";
      OracleParameter[] oracleParameterArray = new OracleParameter[1];
      int index = 0;
      OracleParameter oracleParameter = new OracleParameter(":ID", OracleDbType.Varchar2);
      oracleParameter.Value = (object) taskID;
      oracleParameterArray[index] = oracleParameter;
      OracleParameter[] parameter = oracleParameterArray;
      int test;
      if (!this.dbHelper.GetFieldValue(sql, parameter).IsInt(out test))
        return -1;
      return test;
    }

    public List<RoadFlow.Data.Model.WorkFlowTask> GetBySubFlowGroupID(Guid subflowGroupID)
    {
      string sql = "SELECT * FROM WorkFlowTask WHERE INSTR(SubFlowGroupID,:SubFlowGroupID,1,1)>0";
      OracleParameter[] oracleParameterArray = new OracleParameter[1];
      int index = 0;
      OracleParameter oracleParameter = new OracleParameter(":SubFlowGroupID", OracleDbType.Varchar2);
      oracleParameter.Value = (object) subflowGroupID.ToString();
      oracleParameterArray[index] = oracleParameter;
      OracleParameter[] parameter = oracleParameterArray;
      OracleDataReader dataReader = this.dbHelper.GetDataReader(sql, parameter);
      List<RoadFlow.Data.Model.WorkFlowTask> list = this.DataReaderToList(dataReader);
      dataReader.Close();
      return list;
    }

    public RoadFlow.Data.Model.WorkFlowTask GetLastTask(Guid flowID, Guid groupID)
    {
      string sql = "SELECT * FROM WorkFlowTask WHERE ROWNUM=1 AND FlowID=:FlowID AND GroupID=:GroupID ORDER BY Sort DESC";
      OracleParameter[] oracleParameterArray = new OracleParameter[2];
      int index1 = 0;
      OracleParameter oracleParameter1 = new OracleParameter(":FlowID", OracleDbType.Varchar2);
      oracleParameter1.Value = (object) flowID.ToString();
      oracleParameterArray[index1] = oracleParameter1;
      int index2 = 1;
      OracleParameter oracleParameter2 = new OracleParameter(":GroupID", OracleDbType.Varchar2);
      oracleParameter2.Value = (object) groupID.ToString();
      oracleParameterArray[index2] = oracleParameter2;
      OracleParameter[] parameter = oracleParameterArray;
      OracleDataReader dataReader = this.dbHelper.GetDataReader(sql, parameter);
      List<RoadFlow.Data.Model.WorkFlowTask> list = this.DataReaderToList(dataReader);
      dataReader.Close();
      if (list.Count <= 0)
        return (RoadFlow.Data.Model.WorkFlowTask) null;
      return list[0];
    }

    public List<RoadFlow.Data.Model.WorkFlowTask> GetExpiredAutoSubmitTasks()
    {
      OracleDataReader dataReader = this.dbHelper.GetDataReader("SELECT * FROM WorkFlowTask WHERE CompletedTime<'" + DateTimeNew.Now.ToDateTimeStringS() + "' AND IsExpiredAutoSubmit=1 AND Status IN(0,1)");
      List<RoadFlow.Data.Model.WorkFlowTask> list = this.DataReaderToList(dataReader);
      dataReader.Close();
      return list;
    }
  }
}
