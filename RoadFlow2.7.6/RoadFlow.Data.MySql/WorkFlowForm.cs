// Decompiled with JetBrains decompiler
// Type: RoadFlow.Data.MySql.WorkFlowForm
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
  public class WorkFlowForm : IWorkFlowForm
  {
    private DBHelper dbHelper = new DBHelper();

    public int Add(RoadFlow.Data.Model.WorkFlowForm model)
    {
      string sql = "INSERT INTO workflowform\r\n\t\t\t\t(ID,Name,Type,CreateUserID,CreateUserName,CreateTime,LastModifyTime,Html,SubTableJson,EventsJson,Attribute,Status) \r\n\t\t\t\tVALUES(@ID,@Name,@Type,@CreateUserID,@CreateUserName,@CreateTime,@LastModifyTime,@Html,@SubTableJson,@EventsJson,@Attribute,@Status)";
      MySqlParameter[] mySqlParameterArray = new MySqlParameter[12];
      int index1 = 0;
      MySqlParameter mySqlParameter1 = new MySqlParameter("@ID", MySqlDbType.VarChar, 36);
      mySqlParameter1.Value = (object) model.ID;
      mySqlParameterArray[index1] = mySqlParameter1;
      int index2 = 1;
      MySqlParameter mySqlParameter2 = new MySqlParameter("@Name", MySqlDbType.Text, -1);
      mySqlParameter2.Value = (object) model.Name;
      mySqlParameterArray[index2] = mySqlParameter2;
      int index3 = 2;
      MySqlParameter mySqlParameter3 = new MySqlParameter("@Type", MySqlDbType.VarChar, 36);
      mySqlParameter3.Value = (object) model.Type;
      mySqlParameterArray[index3] = mySqlParameter3;
      int index4 = 3;
      MySqlParameter mySqlParameter4 = new MySqlParameter("@CreateUserID", MySqlDbType.VarChar, 36);
      mySqlParameter4.Value = (object) model.CreateUserID;
      mySqlParameterArray[index4] = mySqlParameter4;
      int index5 = 4;
      MySqlParameter mySqlParameter5 = new MySqlParameter("@CreateUserName", MySqlDbType.VarChar, 50);
      mySqlParameter5.Value = (object) model.CreateUserName;
      mySqlParameterArray[index5] = mySqlParameter5;
      int index6 = 5;
      MySqlParameter mySqlParameter6 = new MySqlParameter("@CreateTime", MySqlDbType.DateTime, -1);
      mySqlParameter6.Value = (object) model.CreateTime;
      mySqlParameterArray[index6] = mySqlParameter6;
      int index7 = 6;
      MySqlParameter mySqlParameter7 = new MySqlParameter("@LastModifyTime", MySqlDbType.DateTime, -1);
      mySqlParameter7.Value = (object) model.LastModifyTime;
      mySqlParameterArray[index7] = mySqlParameter7;
      int index8 = 7;
      MySqlParameter mySqlParameter8;
      if (model.Html != null)
      {
        MySqlParameter mySqlParameter9 = new MySqlParameter("@Html", MySqlDbType.LongText, -1);
        mySqlParameter9.Value = (object) model.Html;
        mySqlParameter8 = mySqlParameter9;
      }
      else
      {
        mySqlParameter8 = new MySqlParameter("@Html", MySqlDbType.LongText, -1);
        mySqlParameter8.Value = (object) DBNull.Value;
      }
      mySqlParameterArray[index8] = mySqlParameter8;
      int index9 = 8;
      MySqlParameter mySqlParameter10;
      if (model.SubTableJson != null)
      {
        MySqlParameter mySqlParameter9 = new MySqlParameter("@SubTableJson", MySqlDbType.LongText, -1);
        mySqlParameter9.Value = (object) model.SubTableJson;
        mySqlParameter10 = mySqlParameter9;
      }
      else
      {
        mySqlParameter10 = new MySqlParameter("@SubTableJson", MySqlDbType.LongText, -1);
        mySqlParameter10.Value = (object) DBNull.Value;
      }
      mySqlParameterArray[index9] = mySqlParameter10;
      int index10 = 9;
      MySqlParameter mySqlParameter11;
      if (model.EventsJson != null)
      {
        MySqlParameter mySqlParameter9 = new MySqlParameter("@EventsJson", MySqlDbType.LongText, -1);
        mySqlParameter9.Value = (object) model.EventsJson;
        mySqlParameter11 = mySqlParameter9;
      }
      else
      {
        mySqlParameter11 = new MySqlParameter("@EventsJson", MySqlDbType.LongText, -1);
        mySqlParameter11.Value = (object) DBNull.Value;
      }
      mySqlParameterArray[index10] = mySqlParameter11;
      int index11 = 10;
      MySqlParameter mySqlParameter12;
      if (model.Attribute != null)
      {
        MySqlParameter mySqlParameter9 = new MySqlParameter("@Attribute", MySqlDbType.LongText, -1);
        mySqlParameter9.Value = (object) model.Attribute;
        mySqlParameter12 = mySqlParameter9;
      }
      else
      {
        mySqlParameter12 = new MySqlParameter("@Attribute", MySqlDbType.LongText, -1);
        mySqlParameter12.Value = (object) DBNull.Value;
      }
      mySqlParameterArray[index11] = mySqlParameter12;
      int index12 = 11;
      MySqlParameter mySqlParameter13 = new MySqlParameter("@Status", MySqlDbType.Int32, 11);
      mySqlParameter13.Value = (object) model.Status;
      mySqlParameterArray[index12] = mySqlParameter13;
      MySqlParameter[] parameter = mySqlParameterArray;
      return this.dbHelper.Execute(sql, parameter, false);
    }

    public int Update(RoadFlow.Data.Model.WorkFlowForm model)
    {
      string sql = "UPDATE workflowform SET \r\n\t\t\t\tName=@Name,Type=@Type,CreateUserID=@CreateUserID,CreateUserName=@CreateUserName,CreateTime=@CreateTime,LastModifyTime=@LastModifyTime,Html=@Html,SubTableJson=@SubTableJson,EventsJson=@EventsJson,Attribute=@Attribute,Status=@Status\r\n\t\t\t\tWHERE ID=@ID";
      MySqlParameter[] mySqlParameterArray = new MySqlParameter[12];
      int index1 = 0;
      MySqlParameter mySqlParameter1 = new MySqlParameter("@Name", MySqlDbType.Text, -1);
      mySqlParameter1.Value = (object) model.Name;
      mySqlParameterArray[index1] = mySqlParameter1;
      int index2 = 1;
      MySqlParameter mySqlParameter2 = new MySqlParameter("@Type", MySqlDbType.VarChar, 36);
      mySqlParameter2.Value = (object) model.Type;
      mySqlParameterArray[index2] = mySqlParameter2;
      int index3 = 2;
      MySqlParameter mySqlParameter3 = new MySqlParameter("@CreateUserID", MySqlDbType.VarChar, 36);
      mySqlParameter3.Value = (object) model.CreateUserID;
      mySqlParameterArray[index3] = mySqlParameter3;
      int index4 = 3;
      MySqlParameter mySqlParameter4 = new MySqlParameter("@CreateUserName", MySqlDbType.VarChar, 50);
      mySqlParameter4.Value = (object) model.CreateUserName;
      mySqlParameterArray[index4] = mySqlParameter4;
      int index5 = 4;
      MySqlParameter mySqlParameter5 = new MySqlParameter("@CreateTime", MySqlDbType.DateTime, -1);
      mySqlParameter5.Value = (object) model.CreateTime;
      mySqlParameterArray[index5] = mySqlParameter5;
      int index6 = 5;
      MySqlParameter mySqlParameter6 = new MySqlParameter("@LastModifyTime", MySqlDbType.DateTime, -1);
      mySqlParameter6.Value = (object) model.LastModifyTime;
      mySqlParameterArray[index6] = mySqlParameter6;
      int index7 = 6;
      MySqlParameter mySqlParameter7;
      if (model.Html != null)
      {
        MySqlParameter mySqlParameter8 = new MySqlParameter("@Html", MySqlDbType.LongText, -1);
        mySqlParameter8.Value = (object) model.Html;
        mySqlParameter7 = mySqlParameter8;
      }
      else
      {
        mySqlParameter7 = new MySqlParameter("@Html", MySqlDbType.LongText, -1);
        mySqlParameter7.Value = (object) DBNull.Value;
      }
      mySqlParameterArray[index7] = mySqlParameter7;
      int index8 = 7;
      MySqlParameter mySqlParameter9;
      if (model.SubTableJson != null)
      {
        MySqlParameter mySqlParameter8 = new MySqlParameter("@SubTableJson", MySqlDbType.LongText, -1);
        mySqlParameter8.Value = (object) model.SubTableJson;
        mySqlParameter9 = mySqlParameter8;
      }
      else
      {
        mySqlParameter9 = new MySqlParameter("@SubTableJson", MySqlDbType.LongText, -1);
        mySqlParameter9.Value = (object) DBNull.Value;
      }
      mySqlParameterArray[index8] = mySqlParameter9;
      int index9 = 8;
      MySqlParameter mySqlParameter10;
      if (model.EventsJson != null)
      {
        MySqlParameter mySqlParameter8 = new MySqlParameter("@EventsJson", MySqlDbType.LongText, -1);
        mySqlParameter8.Value = (object) model.EventsJson;
        mySqlParameter10 = mySqlParameter8;
      }
      else
      {
        mySqlParameter10 = new MySqlParameter("@EventsJson", MySqlDbType.LongText, -1);
        mySqlParameter10.Value = (object) DBNull.Value;
      }
      mySqlParameterArray[index9] = mySqlParameter10;
      int index10 = 9;
      MySqlParameter mySqlParameter11;
      if (model.Attribute != null)
      {
        MySqlParameter mySqlParameter8 = new MySqlParameter("@Attribute", MySqlDbType.LongText, -1);
        mySqlParameter8.Value = (object) model.Attribute;
        mySqlParameter11 = mySqlParameter8;
      }
      else
      {
        mySqlParameter11 = new MySqlParameter("@Attribute", MySqlDbType.LongText, -1);
        mySqlParameter11.Value = (object) DBNull.Value;
      }
      mySqlParameterArray[index10] = mySqlParameter11;
      int index11 = 10;
      MySqlParameter mySqlParameter12 = new MySqlParameter("@Status", MySqlDbType.Int32, 11);
      mySqlParameter12.Value = (object) model.Status;
      mySqlParameterArray[index11] = mySqlParameter12;
      int index12 = 11;
      MySqlParameter mySqlParameter13 = new MySqlParameter("@ID", MySqlDbType.VarChar, 36);
      mySqlParameter13.Value = (object) model.ID;
      mySqlParameterArray[index12] = mySqlParameter13;
      MySqlParameter[] parameter = mySqlParameterArray;
      return this.dbHelper.Execute(sql, parameter, false);
    }

    public int Delete(Guid id)
    {
      string sql = "DELETE FROM workflowform WHERE ID=@ID";
      MySqlParameter[] mySqlParameterArray = new MySqlParameter[1];
      int index = 0;
      MySqlParameter mySqlParameter = new MySqlParameter("@ID", MySqlDbType.VarChar, 36);
      mySqlParameter.Value = (object) id.ToString();
      mySqlParameterArray[index] = mySqlParameter;
      MySqlParameter[] parameter = mySqlParameterArray;
      return this.dbHelper.Execute(sql, parameter, false);
    }

    private List<RoadFlow.Data.Model.WorkFlowForm> DataReaderToList(MySqlDataReader dataReader)
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
      MySqlDataReader dataReader = this.dbHelper.GetDataReader("SELECT * FROM workflowform");
      List<RoadFlow.Data.Model.WorkFlowForm> list = this.DataReaderToList(dataReader);
      dataReader.Close();
      return list;
    }

    public long GetCount()
    {
      long result;
      if (!long.TryParse(this.dbHelper.GetFieldValue("SELECT COUNT(*) FROM workflowform"), out result))
        return 0;
      return result;
    }

    public RoadFlow.Data.Model.WorkFlowForm Get(Guid id)
    {
      string sql = "SELECT * FROM workflowform WHERE ID=@ID";
      MySqlParameter[] mySqlParameterArray = new MySqlParameter[1];
      int index = 0;
      MySqlParameter mySqlParameter = new MySqlParameter("@ID", MySqlDbType.VarChar, 36);
      mySqlParameter.Value = (object) id.ToString();
      mySqlParameterArray[index] = mySqlParameter;
      MySqlParameter[] parameter = mySqlParameterArray;
      MySqlDataReader dataReader = this.dbHelper.GetDataReader(sql, parameter);
      List<RoadFlow.Data.Model.WorkFlowForm> list = this.DataReaderToList(dataReader);
      dataReader.Close();
      if (list.Count <= 0)
        return (RoadFlow.Data.Model.WorkFlowForm) null;
      return list[0];
    }

    public List<RoadFlow.Data.Model.WorkFlowForm> GetAllByType(string types)
    {
      MySqlDataReader dataReader = this.dbHelper.GetDataReader("SELECT ID, Name, Type, CreateUserID, CreateUserName, CreateTime, LastModifyTime, '' as Html, '' as SubTableJson, '' as EventsJson, '' as Attribute, Status FROM WorkFlowForm where Type IN(" + Tools.GetSqlInString(types, true, ",") + ")");
      List<RoadFlow.Data.Model.WorkFlowForm> list = this.DataReaderToList(dataReader);
      dataReader.Close();
      return list;
    }

    public List<RoadFlow.Data.Model.WorkFlowForm> GetPagerData(out string pager, string query = "", string userid = "", string typeid = "", string name = "", int pagesize = 15)
    {
      StringBuilder stringBuilder = new StringBuilder("AND Status IN(0,1) ");
      List<MySqlParameter> mySqlParameterList1 = new List<MySqlParameter>();
      if (!userid.IsNullOrEmpty())
      {
        stringBuilder.Append("AND CreateUserID=@CreateUserID ");
        List<MySqlParameter> mySqlParameterList2 = mySqlParameterList1;
        MySqlParameter mySqlParameter = new MySqlParameter("@CreateUserID", MySqlDbType.VarChar);
        mySqlParameter.Value = (object) userid;
        mySqlParameterList2.Add(mySqlParameter);
      }
      if (!name.IsNullOrEmpty())
      {
        stringBuilder.Append("AND INSTR(Name,@Name)>0 ");
        List<MySqlParameter> mySqlParameterList2 = mySqlParameterList1;
        MySqlParameter mySqlParameter = new MySqlParameter("@Name", MySqlDbType.VarChar);
        mySqlParameter.Value = (object) name;
        mySqlParameterList2.Add(mySqlParameter);
      }
      if (!typeid.IsNullOrEmpty())
        stringBuilder.Append("AND Type IN (" + Tools.GetSqlInString(typeid, true, ",") + ")");
      int num = pagesize;
      int pageNumber = Tools.GetPageNumber();
      long count;
      string paerSql = this.dbHelper.GetPaerSql(nameof (WorkFlowForm), "ID,Name,Type,CreateUserID,CreateUserName,CreateTime,LastModifyTime,'' Html,'' SubTableJson,'' EventsJson,'' Attribute,Status", stringBuilder.ToString(), "CreateTime DESC", num, pageNumber, out count, mySqlParameterList1.ToArray());
      pager = Tools.GetPagerHtml(count, num, pageNumber, query);
      MySqlDataReader dataReader = this.dbHelper.GetDataReader(paerSql, mySqlParameterList1.ToArray());
      List<RoadFlow.Data.Model.WorkFlowForm> list = this.DataReaderToList(dataReader);
      dataReader.Close();
      return list;
    }

    public List<RoadFlow.Data.Model.WorkFlowForm> GetPagerData(out long count, int pageSize, int pageNumber, string userid = "", string typeid = "", string name = "", string order = "")
    {
      StringBuilder stringBuilder = new StringBuilder("AND Status IN(0,1) ");
      List<MySqlParameter> mySqlParameterList1 = new List<MySqlParameter>();
      if (!userid.IsNullOrEmpty())
      {
        stringBuilder.Append("AND CreateUserID=@CreateUserID ");
        List<MySqlParameter> mySqlParameterList2 = mySqlParameterList1;
        MySqlParameter mySqlParameter = new MySqlParameter("@CreateUserID", MySqlDbType.VarChar);
        mySqlParameter.Value = (object) userid;
        mySqlParameterList2.Add(mySqlParameter);
      }
      if (!name.IsNullOrEmpty())
      {
        stringBuilder.Append("AND INSTR(Name,@Name)>0 ");
        List<MySqlParameter> mySqlParameterList2 = mySqlParameterList1;
        MySqlParameter mySqlParameter = new MySqlParameter("@Name", MySqlDbType.VarChar);
        mySqlParameter.Value = (object) name;
        mySqlParameterList2.Add(mySqlParameter);
      }
      if (!typeid.IsNullOrEmpty())
        stringBuilder.Append("AND Type IN (" + Tools.GetSqlInString(typeid, true, ",") + ")");
      MySqlDataReader dataReader = this.dbHelper.GetDataReader(this.dbHelper.GetPaerSql(nameof (WorkFlowForm), "ID,Name,Type,CreateUserID,CreateUserName,CreateTime,LastModifyTime,'' Html,'' SubTableJson,'' EventsJson,'' Attribute,Status", stringBuilder.ToString(), order.IsNullOrEmpty() ? "CreateTime DESC" : order, pageSize, pageNumber, out count, mySqlParameterList1.ToArray()), mySqlParameterList1.ToArray());
      List<RoadFlow.Data.Model.WorkFlowForm> list = this.DataReaderToList(dataReader);
      dataReader.Close();
      return list;
    }
  }
}
