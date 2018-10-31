// Decompiled with JetBrains decompiler
// Type: RoadFlow.Data.MySql.WorkFlowDelegation
// Assembly: RoadFlow.Data.MySql, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 29B652D7-5F6F-4A7D-AD1C-9F2C643FD784
// Assembly location: C:\inetpub\wwwroot\RoadFlowMvc\bin\RoadFlow.Data.MySql.dll

using MySql.Data.MySqlClient;
using RoadFlow.Data.Interface;
using RoadFlow.Utility;
using System;
using System.Collections.Generic;
using System.Text;

namespace RoadFlow.Data.MySql
{
  public class WorkFlowDelegation : IWorkFlowDelegation
  {
    private DBHelper dbHelper = new DBHelper();

    public int Add(RoadFlow.Data.Model.WorkFlowDelegation model)
    {
      string sql = "INSERT INTO workflowdelegation\r\n\t\t\t\t(ID,UserID,StartTime,EndTime,FlowID,ToUserID,WriteTime,Note) \r\n\t\t\t\tVALUES(@ID,@UserID,@StartTime,@EndTime,@FlowID,@ToUserID,@WriteTime,@Note)";
      MySqlParameter[] mySqlParameterArray = new MySqlParameter[8];
      int index1 = 0;
      MySqlParameter mySqlParameter1 = new MySqlParameter("@ID", MySqlDbType.VarChar, 36);
      mySqlParameter1.Value = (object) model.ID;
      mySqlParameterArray[index1] = mySqlParameter1;
      int index2 = 1;
      MySqlParameter mySqlParameter2 = new MySqlParameter("@UserID", MySqlDbType.VarChar, 36);
      mySqlParameter2.Value = (object) model.UserID;
      mySqlParameterArray[index2] = mySqlParameter2;
      int index3 = 2;
      MySqlParameter mySqlParameter3 = new MySqlParameter("@StartTime", MySqlDbType.DateTime, -1);
      mySqlParameter3.Value = (object) model.StartTime;
      mySqlParameterArray[index3] = mySqlParameter3;
      int index4 = 3;
      MySqlParameter mySqlParameter4 = new MySqlParameter("@EndTime", MySqlDbType.DateTime, -1);
      mySqlParameter4.Value = (object) model.EndTime;
      mySqlParameterArray[index4] = mySqlParameter4;
      int index5 = 4;
      MySqlParameter mySqlParameter5;
      if (model.FlowID.HasValue)
      {
        MySqlParameter mySqlParameter6 = new MySqlParameter("@FlowID", MySqlDbType.VarChar, 36);
        mySqlParameter6.Value = (object) model.FlowID;
        mySqlParameter5 = mySqlParameter6;
      }
      else
      {
        mySqlParameter5 = new MySqlParameter("@FlowID", MySqlDbType.VarChar, 36);
        mySqlParameter5.Value = (object) DBNull.Value;
      }
      mySqlParameterArray[index5] = mySqlParameter5;
      int index6 = 5;
      MySqlParameter mySqlParameter7 = new MySqlParameter("@ToUserID", MySqlDbType.VarChar, 36);
      mySqlParameter7.Value = (object) model.ToUserID;
      mySqlParameterArray[index6] = mySqlParameter7;
      int index7 = 6;
      MySqlParameter mySqlParameter8 = new MySqlParameter("@WriteTime", MySqlDbType.DateTime, -1);
      mySqlParameter8.Value = (object) model.WriteTime;
      mySqlParameterArray[index7] = mySqlParameter8;
      int index8 = 7;
      MySqlParameter mySqlParameter9;
      if (model.Note != null)
      {
        MySqlParameter mySqlParameter6 = new MySqlParameter("@Note", MySqlDbType.Text, -1);
        mySqlParameter6.Value = (object) model.Note;
        mySqlParameter9 = mySqlParameter6;
      }
      else
      {
        mySqlParameter9 = new MySqlParameter("@Note", MySqlDbType.Text, -1);
        mySqlParameter9.Value = (object) DBNull.Value;
      }
      mySqlParameterArray[index8] = mySqlParameter9;
      MySqlParameter[] parameter = mySqlParameterArray;
      return this.dbHelper.Execute(sql, parameter, false);
    }

    public int Update(RoadFlow.Data.Model.WorkFlowDelegation model)
    {
      string sql = "UPDATE workflowdelegation SET \r\n\t\t\t\tUserID=@UserID,StartTime=@StartTime,EndTime=@EndTime,FlowID=@FlowID,ToUserID=@ToUserID,WriteTime=@WriteTime,Note=@Note\r\n\t\t\t\tWHERE ID=@ID";
      MySqlParameter[] mySqlParameterArray = new MySqlParameter[8];
      int index1 = 0;
      MySqlParameter mySqlParameter1 = new MySqlParameter("@UserID", MySqlDbType.VarChar, 36);
      mySqlParameter1.Value = (object) model.UserID;
      mySqlParameterArray[index1] = mySqlParameter1;
      int index2 = 1;
      MySqlParameter mySqlParameter2 = new MySqlParameter("@StartTime", MySqlDbType.DateTime, -1);
      mySqlParameter2.Value = (object) model.StartTime;
      mySqlParameterArray[index2] = mySqlParameter2;
      int index3 = 2;
      MySqlParameter mySqlParameter3 = new MySqlParameter("@EndTime", MySqlDbType.DateTime, -1);
      mySqlParameter3.Value = (object) model.EndTime;
      mySqlParameterArray[index3] = mySqlParameter3;
      int index4 = 3;
      MySqlParameter mySqlParameter4;
      if (model.FlowID.HasValue)
      {
        MySqlParameter mySqlParameter5 = new MySqlParameter("@FlowID", MySqlDbType.VarChar, 36);
        mySqlParameter5.Value = (object) model.FlowID;
        mySqlParameter4 = mySqlParameter5;
      }
      else
      {
        mySqlParameter4 = new MySqlParameter("@FlowID", MySqlDbType.VarChar, 36);
        mySqlParameter4.Value = (object) DBNull.Value;
      }
      mySqlParameterArray[index4] = mySqlParameter4;
      int index5 = 4;
      MySqlParameter mySqlParameter6 = new MySqlParameter("@ToUserID", MySqlDbType.VarChar, 36);
      mySqlParameter6.Value = (object) model.ToUserID;
      mySqlParameterArray[index5] = mySqlParameter6;
      int index6 = 5;
      MySqlParameter mySqlParameter7 = new MySqlParameter("@WriteTime", MySqlDbType.DateTime, -1);
      mySqlParameter7.Value = (object) model.WriteTime;
      mySqlParameterArray[index6] = mySqlParameter7;
      int index7 = 6;
      MySqlParameter mySqlParameter8;
      if (model.Note != null)
      {
        MySqlParameter mySqlParameter5 = new MySqlParameter("@Note", MySqlDbType.Text, -1);
        mySqlParameter5.Value = (object) model.Note;
        mySqlParameter8 = mySqlParameter5;
      }
      else
      {
        mySqlParameter8 = new MySqlParameter("@Note", MySqlDbType.Text, -1);
        mySqlParameter8.Value = (object) DBNull.Value;
      }
      mySqlParameterArray[index7] = mySqlParameter8;
      int index8 = 7;
      MySqlParameter mySqlParameter9 = new MySqlParameter("@ID", MySqlDbType.VarChar, 36);
      mySqlParameter9.Value = (object) model.ID;
      mySqlParameterArray[index8] = mySqlParameter9;
      MySqlParameter[] parameter = mySqlParameterArray;
      return this.dbHelper.Execute(sql, parameter, false);
    }

    public int Delete(Guid id)
    {
      string sql = "DELETE FROM workflowdelegation WHERE ID=@ID";
      MySqlParameter[] mySqlParameterArray = new MySqlParameter[1];
      int index = 0;
      MySqlParameter mySqlParameter = new MySqlParameter("@ID", MySqlDbType.VarChar, 36);
      mySqlParameter.Value = (object) id.ToString();
      mySqlParameterArray[index] = mySqlParameter;
      MySqlParameter[] parameter = mySqlParameterArray;
      return this.dbHelper.Execute(sql, parameter, false);
    }

    private List<RoadFlow.Data.Model.WorkFlowDelegation> DataReaderToList(MySqlDataReader dataReader)
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
      MySqlDataReader dataReader = this.dbHelper.GetDataReader("SELECT * FROM workflowdelegation");
      List<RoadFlow.Data.Model.WorkFlowDelegation> list = this.DataReaderToList(dataReader);
      dataReader.Close();
      return list;
    }

    public long GetCount()
    {
      long result;
      if (!long.TryParse(this.dbHelper.GetFieldValue("SELECT COUNT(*) FROM workflowdelegation"), out result))
        return 0;
      return result;
    }

    public RoadFlow.Data.Model.WorkFlowDelegation Get(Guid id)
    {
      string sql = "SELECT * FROM workflowdelegation WHERE ID=@ID";
      MySqlParameter[] mySqlParameterArray = new MySqlParameter[1];
      int index = 0;
      MySqlParameter mySqlParameter = new MySqlParameter("@ID", MySqlDbType.VarChar, 36);
      mySqlParameter.Value = (object) id.ToString();
      mySqlParameterArray[index] = mySqlParameter;
      MySqlParameter[] parameter = mySqlParameterArray;
      MySqlDataReader dataReader = this.dbHelper.GetDataReader(sql, parameter);
      List<RoadFlow.Data.Model.WorkFlowDelegation> list = this.DataReaderToList(dataReader);
      dataReader.Close();
      if (list.Count <= 0)
        return (RoadFlow.Data.Model.WorkFlowDelegation) null;
      return list[0];
    }

    public List<RoadFlow.Data.Model.WorkFlowDelegation> GetByUserID(Guid userID)
    {
      string sql = "SELECT * FROM WorkFlowDelegation WHERE UserID=@UserID";
      MySqlParameter[] mySqlParameterArray = new MySqlParameter[1];
      int index = 0;
      MySqlParameter mySqlParameter = new MySqlParameter("@UserID", MySqlDbType.VarChar);
      mySqlParameter.Value = (object) userID;
      mySqlParameterArray[index] = mySqlParameter;
      MySqlParameter[] parameter = mySqlParameterArray;
      MySqlDataReader dataReader = this.dbHelper.GetDataReader(sql, parameter);
      List<RoadFlow.Data.Model.WorkFlowDelegation> list = this.DataReaderToList(dataReader);
      dataReader.Close();
      return list;
    }

    public List<RoadFlow.Data.Model.WorkFlowDelegation> GetPagerData(out string pager, string query = "", string userID = "", string startTime = "", string endTime = "")
    {
      StringBuilder stringBuilder = new StringBuilder();
      List<MySqlParameter> mySqlParameterList1 = new List<MySqlParameter>();
      if (userID.IsGuid())
      {
        stringBuilder.Append("AND UserID=@UserID ");
        List<MySqlParameter> mySqlParameterList2 = mySqlParameterList1;
        MySqlParameter mySqlParameter = new MySqlParameter("@UserID", MySqlDbType.VarChar);
        mySqlParameter.Value = (object) userID;
        mySqlParameterList2.Add(mySqlParameter);
      }
      if (startTime.IsDateTime())
      {
        stringBuilder.Append("AND StartTime>=@StartTime ");
        List<MySqlParameter> mySqlParameterList2 = mySqlParameterList1;
        MySqlParameter mySqlParameter = new MySqlParameter("@StartTime", MySqlDbType.DateTime);
        mySqlParameter.Value = (object) startTime.ToDateTime().ToString("yyyy-MM-dd").ToDateTime();
        mySqlParameterList2.Add(mySqlParameter);
      }
      if (endTime.IsDateTime())
      {
        stringBuilder.Append("AND EndTime<=@EndTime ");
        List<MySqlParameter> mySqlParameterList2 = mySqlParameterList1;
        MySqlParameter mySqlParameter = new MySqlParameter("@EndTime", MySqlDbType.DateTime);
        DateTime dateTime = endTime.ToDateTime();
        dateTime = dateTime.AddDays(1.0);
        mySqlParameter.Value = (object) dateTime.ToString("yyyy-MM-dd").ToDateTime();
        mySqlParameterList2.Add(mySqlParameter);
      }
      int pageSize = Tools.GetPageSize();
      int pageNumber = Tools.GetPageNumber();
      long count;
      string paerSql = this.dbHelper.GetPaerSql(nameof (WorkFlowDelegation), "*", stringBuilder.ToString(), "WriteTime Desc", pageSize, pageNumber, out count, mySqlParameterList1.ToArray());
      pager = Tools.GetPagerHtml(count, pageSize, pageNumber, query);
      MySqlDataReader dataReader = this.dbHelper.GetDataReader(paerSql, mySqlParameterList1.ToArray());
      List<RoadFlow.Data.Model.WorkFlowDelegation> list = this.DataReaderToList(dataReader);
      dataReader.Close();
      return list;
    }

    public List<RoadFlow.Data.Model.WorkFlowDelegation> GetPagerData(out long count, int pageSize, int pageNumber, string userID = "", string startTime = "", string endTime = "", string order = "")
    {
      StringBuilder stringBuilder = new StringBuilder();
      List<MySqlParameter> mySqlParameterList1 = new List<MySqlParameter>();
      if (userID.IsGuid())
      {
        stringBuilder.Append("AND UserID=@UserID ");
        List<MySqlParameter> mySqlParameterList2 = mySqlParameterList1;
        MySqlParameter mySqlParameter = new MySqlParameter("@UserID", MySqlDbType.VarChar);
        mySqlParameter.Value = (object) userID;
        mySqlParameterList2.Add(mySqlParameter);
      }
      if (startTime.IsDateTime())
      {
        stringBuilder.Append("AND StartTime>=@StartTime ");
        List<MySqlParameter> mySqlParameterList2 = mySqlParameterList1;
        MySqlParameter mySqlParameter = new MySqlParameter("@StartTime", MySqlDbType.DateTime);
        mySqlParameter.Value = (object) startTime.ToDateTime().ToString("yyyy-MM-dd").ToDateTime();
        mySqlParameterList2.Add(mySqlParameter);
      }
      if (endTime.IsDateTime())
      {
        stringBuilder.Append("AND EndTime<=@EndTime ");
        List<MySqlParameter> mySqlParameterList2 = mySqlParameterList1;
        MySqlParameter mySqlParameter = new MySqlParameter("@EndTime", MySqlDbType.DateTime);
        DateTime dateTime = endTime.ToDateTime();
        dateTime = dateTime.AddDays(1.0);
        mySqlParameter.Value = (object) dateTime.ToString("yyyy-MM-dd").ToDateTime();
        mySqlParameterList2.Add(mySqlParameter);
      }
      MySqlDataReader dataReader = this.dbHelper.GetDataReader(this.dbHelper.GetPaerSql(nameof (WorkFlowDelegation), "*", stringBuilder.ToString(), order.IsNullOrEmpty() ? "WriteTime Desc" : order, pageSize, pageNumber, out count, mySqlParameterList1.ToArray()), mySqlParameterList1.ToArray());
      List<RoadFlow.Data.Model.WorkFlowDelegation> list = this.DataReaderToList(dataReader);
      dataReader.Close();
      return list;
    }

    public List<RoadFlow.Data.Model.WorkFlowDelegation> GetNoExpiredList()
    {
      string sql = "SELECT * FROM WorkFlowDelegation WHERE EndTime>=@EndTime";
      MySqlParameter[] mySqlParameterArray = new MySqlParameter[1];
      int index = 0;
      MySqlParameter mySqlParameter = new MySqlParameter("@EndTime", MySqlDbType.DateTime);
      mySqlParameter.Value = (object) DateTimeNew.Now;
      mySqlParameterArray[index] = mySqlParameter;
      MySqlParameter[] parameter = mySqlParameterArray;
      MySqlDataReader dataReader = this.dbHelper.GetDataReader(sql, parameter);
      List<RoadFlow.Data.Model.WorkFlowDelegation> list = this.DataReaderToList(dataReader);
      dataReader.Close();
      return list;
    }
  }
}
