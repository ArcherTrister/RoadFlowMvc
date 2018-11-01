// Decompiled with JetBrains decompiler
// Type: RoadFlow.Data.MSSQL.WorkFlowForm
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
  public class WorkFlowForm : IWorkFlowForm
  {
    private DBHelper dbHelper = new DBHelper();

    public int Add(RoadFlow.Data.Model.WorkFlowForm model)
    {
      string sql = "INSERT INTO WorkFlowForm\r\n\t\t\t\t(ID,Name,Type,CreateUserID,CreateUserName,CreateTime,LastModifyTime,Html,SubTableJson,EventsJson,Attribute,Status) \r\n\t\t\t\tVALUES(@ID,@Name,@Type,@CreateUserID,@CreateUserName,@CreateTime,@LastModifyTime,@Html,@SubTableJson,@EventsJson,@Attribute,@Status)";
      SqlParameter[] sqlParameterArray = new SqlParameter[12];
      int index1 = 0;
      SqlParameter sqlParameter1 = new SqlParameter("@ID", SqlDbType.UniqueIdentifier, -1);
      sqlParameter1.Value = (object) model.ID;
      sqlParameterArray[index1] = sqlParameter1;
      int index2 = 1;
      SqlParameter sqlParameter2 = new SqlParameter("@Name", SqlDbType.NVarChar, 1000);
      sqlParameter2.Value = (object) model.Name;
      sqlParameterArray[index2] = sqlParameter2;
      int index3 = 2;
      SqlParameter sqlParameter3 = new SqlParameter("@Type", SqlDbType.UniqueIdentifier, -1);
      sqlParameter3.Value = (object) model.Type;
      sqlParameterArray[index3] = sqlParameter3;
      int index4 = 3;
      SqlParameter sqlParameter4 = new SqlParameter("@CreateUserID", SqlDbType.UniqueIdentifier, -1);
      sqlParameter4.Value = (object) model.CreateUserID;
      sqlParameterArray[index4] = sqlParameter4;
      int index5 = 4;
      SqlParameter sqlParameter5 = new SqlParameter("@CreateUserName", SqlDbType.NVarChar, 100);
      sqlParameter5.Value = (object) model.CreateUserName;
      sqlParameterArray[index5] = sqlParameter5;
      int index6 = 5;
      SqlParameter sqlParameter6 = new SqlParameter("@CreateTime", SqlDbType.DateTime, 8);
      sqlParameter6.Value = (object) model.CreateTime;
      sqlParameterArray[index6] = sqlParameter6;
      int index7 = 6;
      SqlParameter sqlParameter7 = new SqlParameter("@LastModifyTime", SqlDbType.DateTime, 8);
      sqlParameter7.Value = (object) model.LastModifyTime;
      sqlParameterArray[index7] = sqlParameter7;
      int index8 = 7;
      SqlParameter sqlParameter8;
      if (model.Html != null)
      {
        SqlParameter sqlParameter9 = new SqlParameter("@Html", SqlDbType.Text, -1);
        sqlParameter9.Value = (object) model.Html;
        sqlParameter8 = sqlParameter9;
      }
      else
      {
        sqlParameter8 = new SqlParameter("@Html", SqlDbType.Text, -1);
        sqlParameter8.Value = (object) DBNull.Value;
      }
      sqlParameterArray[index8] = sqlParameter8;
      int index9 = 8;
      SqlParameter sqlParameter10;
      if (model.SubTableJson != null)
      {
        SqlParameter sqlParameter9 = new SqlParameter("@SubTableJson", SqlDbType.Text, -1);
        sqlParameter9.Value = (object) model.SubTableJson;
        sqlParameter10 = sqlParameter9;
      }
      else
      {
        sqlParameter10 = new SqlParameter("@SubTableJson", SqlDbType.Text, -1);
        sqlParameter10.Value = (object) DBNull.Value;
      }
      sqlParameterArray[index9] = sqlParameter10;
      int index10 = 9;
      SqlParameter sqlParameter11;
      if (model.EventsJson != null)
      {
        SqlParameter sqlParameter9 = new SqlParameter("@EventsJson", SqlDbType.Text, -1);
        sqlParameter9.Value = (object) model.EventsJson;
        sqlParameter11 = sqlParameter9;
      }
      else
      {
        sqlParameter11 = new SqlParameter("@EventsJson", SqlDbType.Text, -1);
        sqlParameter11.Value = (object) DBNull.Value;
      }
      sqlParameterArray[index10] = sqlParameter11;
      int index11 = 10;
      SqlParameter sqlParameter12;
      if (model.Attribute != null)
      {
        SqlParameter sqlParameter9 = new SqlParameter("@Attribute", SqlDbType.VarChar, -1);
        sqlParameter9.Value = (object) model.Attribute;
        sqlParameter12 = sqlParameter9;
      }
      else
      {
        sqlParameter12 = new SqlParameter("@Attribute", SqlDbType.VarChar, -1);
        sqlParameter12.Value = (object) DBNull.Value;
      }
      sqlParameterArray[index11] = sqlParameter12;
      int index12 = 11;
      SqlParameter sqlParameter13 = new SqlParameter("@Status", SqlDbType.Int, -1);
      sqlParameter13.Value = (object) model.Status;
      sqlParameterArray[index12] = sqlParameter13;
      SqlParameter[] parameter = sqlParameterArray;
      return this.dbHelper.Execute(sql, parameter, false);
    }

    public int Update(RoadFlow.Data.Model.WorkFlowForm model)
    {
      string sql = "UPDATE WorkFlowForm SET \r\n\t\t\t\tName=@Name,Type=@Type,CreateUserID=@CreateUserID,CreateUserName=@CreateUserName,CreateTime=@CreateTime,LastModifyTime=@LastModifyTime,Html=@Html,SubTableJson=@SubTableJson,EventsJson=@EventsJson,Attribute=@Attribute,Status=@Status\r\n\t\t\t\tWHERE ID=@ID";
      SqlParameter[] sqlParameterArray = new SqlParameter[12];
      int index1 = 0;
      SqlParameter sqlParameter1 = new SqlParameter("@Name", SqlDbType.NVarChar, 1000);
      sqlParameter1.Value = (object) model.Name;
      sqlParameterArray[index1] = sqlParameter1;
      int index2 = 1;
      SqlParameter sqlParameter2 = new SqlParameter("@Type", SqlDbType.UniqueIdentifier, -1);
      sqlParameter2.Value = (object) model.Type;
      sqlParameterArray[index2] = sqlParameter2;
      int index3 = 2;
      SqlParameter sqlParameter3 = new SqlParameter("@CreateUserID", SqlDbType.UniqueIdentifier, -1);
      sqlParameter3.Value = (object) model.CreateUserID;
      sqlParameterArray[index3] = sqlParameter3;
      int index4 = 3;
      SqlParameter sqlParameter4 = new SqlParameter("@CreateUserName", SqlDbType.NVarChar, 100);
      sqlParameter4.Value = (object) model.CreateUserName;
      sqlParameterArray[index4] = sqlParameter4;
      int index5 = 4;
      SqlParameter sqlParameter5 = new SqlParameter("@CreateTime", SqlDbType.DateTime, 8);
      sqlParameter5.Value = (object) model.CreateTime;
      sqlParameterArray[index5] = sqlParameter5;
      int index6 = 5;
      SqlParameter sqlParameter6 = new SqlParameter("@LastModifyTime", SqlDbType.DateTime, 8);
      sqlParameter6.Value = (object) model.LastModifyTime;
      sqlParameterArray[index6] = sqlParameter6;
      int index7 = 6;
      SqlParameter sqlParameter7;
      if (model.Html != null)
      {
        SqlParameter sqlParameter8 = new SqlParameter("@Html", SqlDbType.Text, -1);
        sqlParameter8.Value = (object) model.Html;
        sqlParameter7 = sqlParameter8;
      }
      else
      {
        sqlParameter7 = new SqlParameter("@Html", SqlDbType.Text, -1);
        sqlParameter7.Value = (object) DBNull.Value;
      }
      sqlParameterArray[index7] = sqlParameter7;
      int index8 = 7;
      SqlParameter sqlParameter9;
      if (model.SubTableJson != null)
      {
        SqlParameter sqlParameter8 = new SqlParameter("@SubTableJson", SqlDbType.Text, -1);
        sqlParameter8.Value = (object) model.SubTableJson;
        sqlParameter9 = sqlParameter8;
      }
      else
      {
        sqlParameter9 = new SqlParameter("@SubTableJson", SqlDbType.Text, -1);
        sqlParameter9.Value = (object) DBNull.Value;
      }
      sqlParameterArray[index8] = sqlParameter9;
      int index9 = 8;
      SqlParameter sqlParameter10;
      if (model.EventsJson != null)
      {
        SqlParameter sqlParameter8 = new SqlParameter("@EventsJson", SqlDbType.Text, -1);
        sqlParameter8.Value = (object) model.EventsJson;
        sqlParameter10 = sqlParameter8;
      }
      else
      {
        sqlParameter10 = new SqlParameter("@EventsJson", SqlDbType.Text, -1);
        sqlParameter10.Value = (object) DBNull.Value;
      }
      sqlParameterArray[index9] = sqlParameter10;
      int index10 = 9;
      SqlParameter sqlParameter11;
      if (model.Attribute != null)
      {
        SqlParameter sqlParameter8 = new SqlParameter("@Attribute", SqlDbType.VarChar, -1);
        sqlParameter8.Value = (object) model.Attribute;
        sqlParameter11 = sqlParameter8;
      }
      else
      {
        sqlParameter11 = new SqlParameter("@Attribute", SqlDbType.VarChar, -1);
        sqlParameter11.Value = (object) DBNull.Value;
      }
      sqlParameterArray[index10] = sqlParameter11;
      int index11 = 10;
      SqlParameter sqlParameter12 = new SqlParameter("@Status", SqlDbType.Int, -1);
      sqlParameter12.Value = (object) model.Status;
      sqlParameterArray[index11] = sqlParameter12;
      int index12 = 11;
      SqlParameter sqlParameter13 = new SqlParameter("@ID", SqlDbType.UniqueIdentifier, -1);
      sqlParameter13.Value = (object) model.ID;
      sqlParameterArray[index12] = sqlParameter13;
      SqlParameter[] parameter = sqlParameterArray;
      return this.dbHelper.Execute(sql, parameter, false);
    }

    public int Delete(Guid id)
    {
      string sql = "DELETE FROM WorkFlowForm WHERE ID=@ID";
      SqlParameter[] sqlParameterArray = new SqlParameter[1];
      int index = 0;
      SqlParameter sqlParameter = new SqlParameter("@ID", SqlDbType.UniqueIdentifier);
      sqlParameter.Value = (object) id;
      sqlParameterArray[index] = sqlParameter;
      SqlParameter[] parameter = sqlParameterArray;
      return this.dbHelper.Execute(sql, parameter, false);
    }

    private List<RoadFlow.Data.Model.WorkFlowForm> DataReaderToList(SqlDataReader dataReader)
    {
      List<RoadFlow.Data.Model.WorkFlowForm> workFlowFormList = new List<RoadFlow.Data.Model.WorkFlowForm>();
      while (dataReader.Read())
      {
        RoadFlow.Data.Model.WorkFlowForm workFlowForm = new RoadFlow.Data.Model.WorkFlowForm();
        workFlowForm.ID = dataReader.GetGuid(0);
        workFlowForm.Name = dataReader.GetString(1);
        workFlowForm.Type = dataReader.GetGuid(2);
        workFlowForm.CreateUserID = dataReader.GetGuid(3);
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
      SqlDataReader dataReader = this.dbHelper.GetDataReader("SELECT * FROM WorkFlowForm");
      List<RoadFlow.Data.Model.WorkFlowForm> list = this.DataReaderToList(dataReader);
      dataReader.Close();
      return list;
    }

    public long GetCount()
    {
      long result;
      if (!long.TryParse(this.dbHelper.GetFieldValue("SELECT COUNT(*) FROM WorkFlowForm"), out result))
        return 0;
      return result;
    }

    public RoadFlow.Data.Model.WorkFlowForm Get(Guid id)
    {
      string sql = "SELECT * FROM WorkFlowForm WHERE ID=@ID";
      SqlParameter[] sqlParameterArray = new SqlParameter[1];
      int index = 0;
      SqlParameter sqlParameter = new SqlParameter("@ID", SqlDbType.UniqueIdentifier);
      sqlParameter.Value = (object) id;
      sqlParameterArray[index] = sqlParameter;
      SqlParameter[] parameter = sqlParameterArray;
      SqlDataReader dataReader = this.dbHelper.GetDataReader(sql, parameter);
      List<RoadFlow.Data.Model.WorkFlowForm> list = this.DataReaderToList(dataReader);
      dataReader.Close();
      if (list.Count <= 0)
        return (RoadFlow.Data.Model.WorkFlowForm) null;
      return list[0];
    }

    public List<RoadFlow.Data.Model.WorkFlowForm> GetAllByType(string types)
    {
      SqlDataReader dataReader = this.dbHelper.GetDataReader("SELECT ID, Name, Type, CreateUserID, CreateUserName, CreateTime, LastModifyTime, '' as Html, '' as SubTableJson, '' as EventsJson, '' as Attribute, Status FROM WorkFlowForm where Type IN(" + Tools.GetSqlInString(types, true, ",") + ")");
      List<RoadFlow.Data.Model.WorkFlowForm> list = this.DataReaderToList(dataReader);
      dataReader.Close();
      return list;
    }

    public List<RoadFlow.Data.Model.WorkFlowForm> GetPagerData(out string pager, string query = "", string userid = "", string typeid = "", string name = "", int pagesize = 15)
    {
      StringBuilder stringBuilder = new StringBuilder("AND Status IN(0,1) ");
      List<SqlParameter> sqlParameterList1 = new List<SqlParameter>();
      if (!userid.IsNullOrEmpty())
      {
        stringBuilder.Append("AND CreateUserID=@CreateUserID ");
        List<SqlParameter> sqlParameterList2 = sqlParameterList1;
        SqlParameter sqlParameter = new SqlParameter("@CreateUserID", SqlDbType.UniqueIdentifier);
        sqlParameter.Value = (object) userid;
        sqlParameterList2.Add(sqlParameter);
      }
      if (!name.IsNullOrEmpty())
      {
        stringBuilder.Append("AND CHARINDEX(@Name,Name)>0 ");
        List<SqlParameter> sqlParameterList2 = sqlParameterList1;
        SqlParameter sqlParameter = new SqlParameter("@Name", SqlDbType.VarChar);
        sqlParameter.Value = (object) name;
        sqlParameterList2.Add(sqlParameter);
      }
      if (!typeid.IsNullOrEmpty())
        stringBuilder.Append("AND Type IN (" + Tools.GetSqlInString(typeid, true, ",") + ")");
      int num = pagesize;
      int pageNumber = Tools.GetPageNumber();
      long count;
      string paerSql = this.dbHelper.GetPaerSql(nameof (WorkFlowForm), "ID,Name,Type,CreateUserID,CreateUserName,CreateTime,LastModifyTime,'' Html,'' SubTableJson,'' EventsJson,'' Attribute,Status", stringBuilder.ToString(), "CreateTime DESC", num, pageNumber, out count, sqlParameterList1.ToArray());
      pager = Tools.GetPagerHtml(count, num, pageNumber, query);
      SqlDataReader dataReader = this.dbHelper.GetDataReader(paerSql, sqlParameterList1.ToArray());
      List<RoadFlow.Data.Model.WorkFlowForm> list = this.DataReaderToList(dataReader);
      dataReader.Close();
      return list;
    }

    public List<RoadFlow.Data.Model.WorkFlowForm> GetPagerData(out long count, int pageSize, int pageNumber, string userid = "", string typeid = "", string name = "", string order = "")
    {
      StringBuilder stringBuilder = new StringBuilder("AND Status IN(0,1) ");
      List<SqlParameter> sqlParameterList1 = new List<SqlParameter>();
      if (!userid.IsNullOrEmpty())
      {
        stringBuilder.Append("AND CreateUserID=@CreateUserID ");
        List<SqlParameter> sqlParameterList2 = sqlParameterList1;
        SqlParameter sqlParameter = new SqlParameter("@CreateUserID", SqlDbType.UniqueIdentifier);
        sqlParameter.Value = (object) userid;
        sqlParameterList2.Add(sqlParameter);
      }
      if (!name.IsNullOrEmpty())
      {
        stringBuilder.Append("AND CHARINDEX(@Name,Name)>0 ");
        List<SqlParameter> sqlParameterList2 = sqlParameterList1;
        SqlParameter sqlParameter = new SqlParameter("@Name", SqlDbType.VarChar);
        sqlParameter.Value = (object) name;
        sqlParameterList2.Add(sqlParameter);
      }
      if (!typeid.IsNullOrEmpty())
        stringBuilder.Append("AND Type IN (" + Tools.GetSqlInString(typeid, true, ",") + ")");
      SqlDataReader dataReader = this.dbHelper.GetDataReader(this.dbHelper.GetPaerSql(nameof (WorkFlowForm), "ID,Name,Type,CreateUserID,CreateUserName,CreateTime,LastModifyTime,'' Html,'' SubTableJson,'' EventsJson,'' Attribute,Status", stringBuilder.ToString(), order.IsNullOrEmpty() ? "CreateTime DESC" : order, pageSize, pageNumber, out count, sqlParameterList1.ToArray()), sqlParameterList1.ToArray());
      List<RoadFlow.Data.Model.WorkFlowForm> list = this.DataReaderToList(dataReader);
      dataReader.Close();
      return list;
    }
  }
}
