// Decompiled with JetBrains decompiler
// Type: RoadFlow.Data.MSSQL.ProgramBuilder
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
  public class ProgramBuilder : IProgramBuilder
  {
    private DBHelper dbHelper = new DBHelper();

    public int Add(RoadFlow.Data.Model.ProgramBuilder model)
    {
      string sql = "INSERT INTO ProgramBuilder\r\n\t\t\t\t(ID,Name,Type,CreateTime,PublishTime,CreateUser,SQL,IsAdd,DBConnID,Status,FormID,EditModel,Width,Height,ButtonLocation,IsPager,ClientScript,ExportTemplate,ExportHeaderText,ExportFileName,TableStyle,TableHead,TableName,InDataNumberFiledName) \r\n\t\t\t\tVALUES(@ID,@Name,@Type,@CreateTime,@PublishTime,@CreateUser,@SQL,@IsAdd,@DBConnID,@Status,@FormID,@EditModel,@Width,@Height,@ButtonLocation,@IsPager,@ClientScript,@ExportTemplate,@ExportHeaderText,@ExportFileName,@TableStyle,@TableHead,@TableName,@InDataNumberFiledName)";
      SqlParameter[] sqlParameterArray = new SqlParameter[24];
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
      SqlParameter sqlParameter4 = new SqlParameter("@CreateTime", SqlDbType.DateTime, 8);
      sqlParameter4.Value = (object) model.CreateTime;
      sqlParameterArray[index4] = sqlParameter4;
      int index5 = 4;
      SqlParameter sqlParameter5;
      if (model.PublishTime.HasValue)
      {
        SqlParameter sqlParameter6 = new SqlParameter("@PublishTime", SqlDbType.DateTime, 8);
        sqlParameter6.Value = (object) model.PublishTime;
        sqlParameter5 = sqlParameter6;
      }
      else
      {
        sqlParameter5 = new SqlParameter("@PublishTime", SqlDbType.DateTime, 8);
        sqlParameter5.Value = (object) DBNull.Value;
      }
      sqlParameterArray[index5] = sqlParameter5;
      int index6 = 5;
      SqlParameter sqlParameter7 = new SqlParameter("@CreateUser", SqlDbType.UniqueIdentifier, -1);
      sqlParameter7.Value = (object) model.CreateUser;
      sqlParameterArray[index6] = sqlParameter7;
      int index7 = 6;
      SqlParameter sqlParameter8 = new SqlParameter("@SQL", SqlDbType.VarChar, -1);
      sqlParameter8.Value = (object) model.SQL;
      sqlParameterArray[index7] = sqlParameter8;
      int index8 = 7;
      SqlParameter sqlParameter9 = new SqlParameter("@IsAdd", SqlDbType.Int, -1);
      sqlParameter9.Value = (object) model.IsAdd;
      sqlParameterArray[index8] = sqlParameter9;
      int index9 = 8;
      SqlParameter sqlParameter10 = new SqlParameter("@DBConnID", SqlDbType.UniqueIdentifier, -1);
      sqlParameter10.Value = (object) model.DBConnID;
      sqlParameterArray[index9] = sqlParameter10;
      int index10 = 9;
      SqlParameter sqlParameter11 = new SqlParameter("@Status", SqlDbType.Int, -1);
      sqlParameter11.Value = (object) model.Status;
      sqlParameterArray[index10] = sqlParameter11;
      int index11 = 10;
      SqlParameter sqlParameter12;
      if (model.FormID != null)
      {
        SqlParameter sqlParameter6 = new SqlParameter("@FormID", SqlDbType.VarChar, 500);
        sqlParameter6.Value = (object) model.FormID;
        sqlParameter12 = sqlParameter6;
      }
      else
      {
        sqlParameter12 = new SqlParameter("@FormID", SqlDbType.VarChar, 500);
        sqlParameter12.Value = (object) DBNull.Value;
      }
      sqlParameterArray[index11] = sqlParameter12;
      int index12 = 11;
      int? nullable = model.EditModel;
      SqlParameter sqlParameter13;
      if (nullable.HasValue)
      {
        SqlParameter sqlParameter6 = new SqlParameter("@EditModel", SqlDbType.Int, -1);
        sqlParameter6.Value = (object) model.EditModel;
        sqlParameter13 = sqlParameter6;
      }
      else
      {
        sqlParameter13 = new SqlParameter("@EditModel", SqlDbType.Int, -1);
        sqlParameter13.Value = (object) DBNull.Value;
      }
      sqlParameterArray[index12] = sqlParameter13;
      int index13 = 12;
      SqlParameter sqlParameter14;
      if (model.Width != null)
      {
        SqlParameter sqlParameter6 = new SqlParameter("@Width", SqlDbType.VarChar, 50);
        sqlParameter6.Value = (object) model.Width;
        sqlParameter14 = sqlParameter6;
      }
      else
      {
        sqlParameter14 = new SqlParameter("@Width", SqlDbType.VarChar, 50);
        sqlParameter14.Value = (object) DBNull.Value;
      }
      sqlParameterArray[index13] = sqlParameter14;
      int index14 = 13;
      SqlParameter sqlParameter15;
      if (model.Height != null)
      {
        SqlParameter sqlParameter6 = new SqlParameter("@Height", SqlDbType.VarChar, 50);
        sqlParameter6.Value = (object) model.Height;
        sqlParameter15 = sqlParameter6;
      }
      else
      {
        sqlParameter15 = new SqlParameter("@Height", SqlDbType.VarChar, 50);
        sqlParameter15.Value = (object) DBNull.Value;
      }
      sqlParameterArray[index14] = sqlParameter15;
      int index15 = 14;
      nullable = model.ButtonLocation;
      SqlParameter sqlParameter16;
      if (nullable.HasValue)
      {
        SqlParameter sqlParameter6 = new SqlParameter("@ButtonLocation", SqlDbType.Int, -1);
        sqlParameter6.Value = (object) model.ButtonLocation;
        sqlParameter16 = sqlParameter6;
      }
      else
      {
        sqlParameter16 = new SqlParameter("@ButtonLocation", SqlDbType.Int, -1);
        sqlParameter16.Value = (object) DBNull.Value;
      }
      sqlParameterArray[index15] = sqlParameter16;
      int index16 = 15;
      nullable = model.IsPager;
      SqlParameter sqlParameter17;
      if (nullable.HasValue)
      {
        SqlParameter sqlParameter6 = new SqlParameter("@IsPager", SqlDbType.Int, -1);
        sqlParameter6.Value = (object) model.IsPager;
        sqlParameter17 = sqlParameter6;
      }
      else
      {
        sqlParameter17 = new SqlParameter("@IsPager", SqlDbType.Int, -1);
        sqlParameter17.Value = (object) DBNull.Value;
      }
      sqlParameterArray[index16] = sqlParameter17;
      int index17 = 16;
      SqlParameter sqlParameter18;
      if (model.ClientScript != null)
      {
        SqlParameter sqlParameter6 = new SqlParameter("@ClientScript", SqlDbType.VarChar, -1);
        sqlParameter6.Value = (object) model.ClientScript;
        sqlParameter18 = sqlParameter6;
      }
      else
      {
        sqlParameter18 = new SqlParameter("@ClientScript", SqlDbType.VarChar, -1);
        sqlParameter18.Value = (object) DBNull.Value;
      }
      sqlParameterArray[index17] = sqlParameter18;
      int index18 = 17;
      SqlParameter sqlParameter19;
      if (model.ExportTemplate != null)
      {
        SqlParameter sqlParameter6 = new SqlParameter("@ExportTemplate", SqlDbType.VarChar, 4000);
        sqlParameter6.Value = (object) model.ExportTemplate;
        sqlParameter19 = sqlParameter6;
      }
      else
      {
        sqlParameter19 = new SqlParameter("@ExportTemplate", SqlDbType.VarChar, 4000);
        sqlParameter19.Value = (object) DBNull.Value;
      }
      sqlParameterArray[index18] = sqlParameter19;
      int index19 = 18;
      SqlParameter sqlParameter20;
      if (model.ExportHeaderText != null)
      {
        SqlParameter sqlParameter6 = new SqlParameter("@ExportHeaderText", SqlDbType.NVarChar, 1000);
        sqlParameter6.Value = (object) model.ExportHeaderText;
        sqlParameter20 = sqlParameter6;
      }
      else
      {
        sqlParameter20 = new SqlParameter("@ExportHeaderText", SqlDbType.NVarChar, 1000);
        sqlParameter20.Value = (object) DBNull.Value;
      }
      sqlParameterArray[index19] = sqlParameter20;
      int index20 = 19;
      SqlParameter sqlParameter21;
      if (model.ExportFileName != null)
      {
        SqlParameter sqlParameter6 = new SqlParameter("@ExportFileName", SqlDbType.VarChar, 500);
        sqlParameter6.Value = (object) model.ExportFileName;
        sqlParameter21 = sqlParameter6;
      }
      else
      {
        sqlParameter21 = new SqlParameter("@ExportFileName", SqlDbType.VarChar, 500);
        sqlParameter21.Value = (object) DBNull.Value;
      }
      sqlParameterArray[index20] = sqlParameter21;
      int index21 = 20;
      SqlParameter sqlParameter22;
      if (model.TableStyle != null)
      {
        SqlParameter sqlParameter6 = new SqlParameter("@TableStyle", SqlDbType.VarChar, (int) byte.MaxValue);
        sqlParameter6.Value = (object) model.TableStyle;
        sqlParameter22 = sqlParameter6;
      }
      else
      {
        sqlParameter22 = new SqlParameter("@TableStyle", SqlDbType.VarChar, (int) byte.MaxValue);
        sqlParameter22.Value = (object) DBNull.Value;
      }
      sqlParameterArray[index21] = sqlParameter22;
      int index22 = 21;
      SqlParameter sqlParameter23;
      if (model.TableHead != null)
      {
        SqlParameter sqlParameter6 = new SqlParameter("@TableHead", SqlDbType.VarChar, (int) byte.MaxValue);
        sqlParameter6.Value = (object) model.TableHead;
        sqlParameter23 = sqlParameter6;
      }
      else
      {
        sqlParameter23 = new SqlParameter("@TableHead", SqlDbType.VarChar, (int) byte.MaxValue);
        sqlParameter23.Value = (object) DBNull.Value;
      }
      sqlParameterArray[index22] = sqlParameter23;
      int index23 = 22;
      SqlParameter sqlParameter24;
      if (model.TableName != null)
      {
        SqlParameter sqlParameter6 = new SqlParameter("@TableName", SqlDbType.VarChar, 500);
        sqlParameter6.Value = (object) model.TableName;
        sqlParameter24 = sqlParameter6;
      }
      else
      {
        sqlParameter24 = new SqlParameter("@TableName", SqlDbType.VarChar, 500);
        sqlParameter24.Value = (object) DBNull.Value;
      }
      sqlParameterArray[index23] = sqlParameter24;
      int index24 = 23;
      SqlParameter sqlParameter25;
      if (model.InDataNumberFiledName != null)
      {
        SqlParameter sqlParameter6 = new SqlParameter("@InDataNumberFiledName", SqlDbType.VarChar, 500);
        sqlParameter6.Value = (object) model.InDataNumberFiledName;
        sqlParameter25 = sqlParameter6;
      }
      else
      {
        sqlParameter25 = new SqlParameter("@InDataNumberFiledName", SqlDbType.VarChar, 500);
        sqlParameter25.Value = (object) DBNull.Value;
      }
      sqlParameterArray[index24] = sqlParameter25;
      SqlParameter[] parameter = sqlParameterArray;
      return this.dbHelper.Execute(sql, parameter, false);
    }

    public int Update(RoadFlow.Data.Model.ProgramBuilder model)
    {
      string sql = "UPDATE ProgramBuilder SET \r\n\t\t\t\tName=@Name,Type=@Type,CreateTime=@CreateTime,PublishTime=@PublishTime,CreateUser=@CreateUser,SQL=@SQL,IsAdd=@IsAdd,DBConnID=@DBConnID,Status=@Status,FormID=@FormID,EditModel=@EditModel,Width=@Width,Height=@Height,ButtonLocation=@ButtonLocation,IsPager=@IsPager,ClientScript=@ClientScript,ExportTemplate=@ExportTemplate,ExportHeaderText=@ExportHeaderText,ExportFileName=@ExportFileName,TableStyle=@TableStyle,TableHead=@TableHead,TableName=@TableName,InDataNumberFiledName=@InDataNumberFiledName    \r\n\t\t\t\tWHERE ID=@ID";
      SqlParameter[] sqlParameterArray = new SqlParameter[24];
      int index1 = 0;
      SqlParameter sqlParameter1 = new SqlParameter("@Name", SqlDbType.NVarChar, 1000);
      sqlParameter1.Value = (object) model.Name;
      sqlParameterArray[index1] = sqlParameter1;
      int index2 = 1;
      SqlParameter sqlParameter2 = new SqlParameter("@Type", SqlDbType.UniqueIdentifier, -1);
      sqlParameter2.Value = (object) model.Type;
      sqlParameterArray[index2] = sqlParameter2;
      int index3 = 2;
      SqlParameter sqlParameter3 = new SqlParameter("@CreateTime", SqlDbType.DateTime, 8);
      sqlParameter3.Value = (object) model.CreateTime;
      sqlParameterArray[index3] = sqlParameter3;
      int index4 = 3;
      SqlParameter sqlParameter4;
      if (model.PublishTime.HasValue)
      {
        SqlParameter sqlParameter5 = new SqlParameter("@PublishTime", SqlDbType.DateTime, 8);
        sqlParameter5.Value = (object) model.PublishTime;
        sqlParameter4 = sqlParameter5;
      }
      else
      {
        sqlParameter4 = new SqlParameter("@PublishTime", SqlDbType.DateTime, 8);
        sqlParameter4.Value = (object) DBNull.Value;
      }
      sqlParameterArray[index4] = sqlParameter4;
      int index5 = 4;
      SqlParameter sqlParameter6 = new SqlParameter("@CreateUser", SqlDbType.UniqueIdentifier, -1);
      sqlParameter6.Value = (object) model.CreateUser;
      sqlParameterArray[index5] = sqlParameter6;
      int index6 = 5;
      SqlParameter sqlParameter7 = new SqlParameter("@SQL", SqlDbType.VarChar, -1);
      sqlParameter7.Value = (object) model.SQL;
      sqlParameterArray[index6] = sqlParameter7;
      int index7 = 6;
      SqlParameter sqlParameter8 = new SqlParameter("@IsAdd", SqlDbType.Int, -1);
      sqlParameter8.Value = (object) model.IsAdd;
      sqlParameterArray[index7] = sqlParameter8;
      int index8 = 7;
      SqlParameter sqlParameter9 = new SqlParameter("@DBConnID", SqlDbType.UniqueIdentifier, -1);
      sqlParameter9.Value = (object) model.DBConnID;
      sqlParameterArray[index8] = sqlParameter9;
      int index9 = 8;
      SqlParameter sqlParameter10 = new SqlParameter("@Status", SqlDbType.Int, -1);
      sqlParameter10.Value = (object) model.Status;
      sqlParameterArray[index9] = sqlParameter10;
      int index10 = 9;
      SqlParameter sqlParameter11;
      if (model.FormID != null)
      {
        SqlParameter sqlParameter5 = new SqlParameter("@FormID", SqlDbType.VarChar, 500);
        sqlParameter5.Value = (object) model.FormID;
        sqlParameter11 = sqlParameter5;
      }
      else
      {
        sqlParameter11 = new SqlParameter("@FormID", SqlDbType.VarChar, 500);
        sqlParameter11.Value = (object) DBNull.Value;
      }
      sqlParameterArray[index10] = sqlParameter11;
      int index11 = 10;
      int? nullable = model.EditModel;
      SqlParameter sqlParameter12;
      if (nullable.HasValue)
      {
        SqlParameter sqlParameter5 = new SqlParameter("@EditModel", SqlDbType.Int, -1);
        sqlParameter5.Value = (object) model.EditModel;
        sqlParameter12 = sqlParameter5;
      }
      else
      {
        sqlParameter12 = new SqlParameter("@EditModel", SqlDbType.Int, -1);
        sqlParameter12.Value = (object) DBNull.Value;
      }
      sqlParameterArray[index11] = sqlParameter12;
      int index12 = 11;
      SqlParameter sqlParameter13;
      if (model.Width != null)
      {
        SqlParameter sqlParameter5 = new SqlParameter("@Width", SqlDbType.VarChar, 50);
        sqlParameter5.Value = (object) model.Width;
        sqlParameter13 = sqlParameter5;
      }
      else
      {
        sqlParameter13 = new SqlParameter("@Width", SqlDbType.VarChar, 50);
        sqlParameter13.Value = (object) DBNull.Value;
      }
      sqlParameterArray[index12] = sqlParameter13;
      int index13 = 12;
      SqlParameter sqlParameter14;
      if (model.Height != null)
      {
        SqlParameter sqlParameter5 = new SqlParameter("@Height", SqlDbType.VarChar, 50);
        sqlParameter5.Value = (object) model.Height;
        sqlParameter14 = sqlParameter5;
      }
      else
      {
        sqlParameter14 = new SqlParameter("@Height", SqlDbType.VarChar, 50);
        sqlParameter14.Value = (object) DBNull.Value;
      }
      sqlParameterArray[index13] = sqlParameter14;
      int index14 = 13;
      nullable = model.ButtonLocation;
      SqlParameter sqlParameter15;
      if (nullable.HasValue)
      {
        SqlParameter sqlParameter5 = new SqlParameter("@ButtonLocation", SqlDbType.Int, -1);
        sqlParameter5.Value = (object) model.ButtonLocation;
        sqlParameter15 = sqlParameter5;
      }
      else
      {
        sqlParameter15 = new SqlParameter("@ButtonLocation", SqlDbType.Int, -1);
        sqlParameter15.Value = (object) DBNull.Value;
      }
      sqlParameterArray[index14] = sqlParameter15;
      int index15 = 14;
      nullable = model.IsPager;
      SqlParameter sqlParameter16;
      if (nullable.HasValue)
      {
        SqlParameter sqlParameter5 = new SqlParameter("@IsPager", SqlDbType.Int, -1);
        sqlParameter5.Value = (object) model.IsPager;
        sqlParameter16 = sqlParameter5;
      }
      else
      {
        sqlParameter16 = new SqlParameter("@IsPager", SqlDbType.Int, -1);
        sqlParameter16.Value = (object) DBNull.Value;
      }
      sqlParameterArray[index15] = sqlParameter16;
      int index16 = 15;
      SqlParameter sqlParameter17;
      if (model.ClientScript != null)
      {
        SqlParameter sqlParameter5 = new SqlParameter("@ClientScript", SqlDbType.VarChar, -1);
        sqlParameter5.Value = (object) model.ClientScript;
        sqlParameter17 = sqlParameter5;
      }
      else
      {
        sqlParameter17 = new SqlParameter("@ClientScript", SqlDbType.VarChar, -1);
        sqlParameter17.Value = (object) DBNull.Value;
      }
      sqlParameterArray[index16] = sqlParameter17;
      int index17 = 16;
      SqlParameter sqlParameter18;
      if (model.ExportTemplate != null)
      {
        SqlParameter sqlParameter5 = new SqlParameter("@ExportTemplate", SqlDbType.VarChar, 4000);
        sqlParameter5.Value = (object) model.ExportTemplate;
        sqlParameter18 = sqlParameter5;
      }
      else
      {
        sqlParameter18 = new SqlParameter("@ExportTemplate", SqlDbType.VarChar, 4000);
        sqlParameter18.Value = (object) DBNull.Value;
      }
      sqlParameterArray[index17] = sqlParameter18;
      int index18 = 17;
      SqlParameter sqlParameter19;
      if (model.ExportHeaderText != null)
      {
        SqlParameter sqlParameter5 = new SqlParameter("@ExportHeaderText", SqlDbType.NVarChar, 1000);
        sqlParameter5.Value = (object) model.ExportHeaderText;
        sqlParameter19 = sqlParameter5;
      }
      else
      {
        sqlParameter19 = new SqlParameter("@ExportHeaderText", SqlDbType.NVarChar, 1000);
        sqlParameter19.Value = (object) DBNull.Value;
      }
      sqlParameterArray[index18] = sqlParameter19;
      int index19 = 18;
      SqlParameter sqlParameter20;
      if (model.ExportFileName != null)
      {
        SqlParameter sqlParameter5 = new SqlParameter("@ExportFileName", SqlDbType.VarChar, 500);
        sqlParameter5.Value = (object) model.ExportFileName;
        sqlParameter20 = sqlParameter5;
      }
      else
      {
        sqlParameter20 = new SqlParameter("@ExportFileName", SqlDbType.VarChar, 500);
        sqlParameter20.Value = (object) DBNull.Value;
      }
      sqlParameterArray[index19] = sqlParameter20;
      int index20 = 19;
      SqlParameter sqlParameter21;
      if (model.TableStyle != null)
      {
        SqlParameter sqlParameter5 = new SqlParameter("@TableStyle", SqlDbType.VarChar, (int) byte.MaxValue);
        sqlParameter5.Value = (object) model.TableStyle;
        sqlParameter21 = sqlParameter5;
      }
      else
      {
        sqlParameter21 = new SqlParameter("@TableStyle", SqlDbType.VarChar, (int) byte.MaxValue);
        sqlParameter21.Value = (object) DBNull.Value;
      }
      sqlParameterArray[index20] = sqlParameter21;
      int index21 = 20;
      SqlParameter sqlParameter22;
      if (model.TableHead != null)
      {
        SqlParameter sqlParameter5 = new SqlParameter("@TableHead", SqlDbType.VarChar, -1);
        sqlParameter5.Value = (object) model.TableHead;
        sqlParameter22 = sqlParameter5;
      }
      else
      {
        sqlParameter22 = new SqlParameter("@TableHead", SqlDbType.VarChar, -1);
        sqlParameter22.Value = (object) DBNull.Value;
      }
      sqlParameterArray[index21] = sqlParameter22;
      int index22 = 21;
      SqlParameter sqlParameter23;
      if (model.TableName != null)
      {
        SqlParameter sqlParameter5 = new SqlParameter("@TableName", SqlDbType.VarChar, 500);
        sqlParameter5.Value = (object) model.TableName;
        sqlParameter23 = sqlParameter5;
      }
      else
      {
        sqlParameter23 = new SqlParameter("@TableName", SqlDbType.VarChar, 500);
        sqlParameter23.Value = (object) DBNull.Value;
      }
      sqlParameterArray[index22] = sqlParameter23;
      int index23 = 22;
      SqlParameter sqlParameter24;
      if (model.InDataNumberFiledName != null)
      {
        SqlParameter sqlParameter5 = new SqlParameter("@InDataNumberFiledName", SqlDbType.VarChar, 500);
        sqlParameter5.Value = (object) model.InDataNumberFiledName;
        sqlParameter24 = sqlParameter5;
      }
      else
      {
        sqlParameter24 = new SqlParameter("@InDataNumberFiledName", SqlDbType.VarChar, 500);
        sqlParameter24.Value = (object) DBNull.Value;
      }
      sqlParameterArray[index23] = sqlParameter24;
      int index24 = 23;
      SqlParameter sqlParameter25 = new SqlParameter("@ID", SqlDbType.UniqueIdentifier, -1);
      sqlParameter25.Value = (object) model.ID;
      sqlParameterArray[index24] = sqlParameter25;
      SqlParameter[] parameter = sqlParameterArray;
      return this.dbHelper.Execute(sql, parameter, false);
    }

    public int Delete(Guid id)
    {
      string sql = "DELETE FROM ProgramBuilder WHERE ID=@ID";
      SqlParameter[] sqlParameterArray = new SqlParameter[1];
      int index = 0;
      SqlParameter sqlParameter = new SqlParameter("@ID", SqlDbType.UniqueIdentifier);
      sqlParameter.Value = (object) id;
      sqlParameterArray[index] = sqlParameter;
      SqlParameter[] parameter = sqlParameterArray;
      return this.dbHelper.Execute(sql, parameter, false);
    }

    private List<RoadFlow.Data.Model.ProgramBuilder> DataReaderToList(SqlDataReader dataReader)
    {
      List<RoadFlow.Data.Model.ProgramBuilder> programBuilderList = new List<RoadFlow.Data.Model.ProgramBuilder>();
      while (dataReader.Read())
      {
        RoadFlow.Data.Model.ProgramBuilder programBuilder = new RoadFlow.Data.Model.ProgramBuilder();
        programBuilder.ID = dataReader.GetGuid(0);
        programBuilder.Name = dataReader.GetString(1);
        programBuilder.Type = dataReader.GetGuid(2);
        programBuilder.CreateTime = dataReader.GetDateTime(3);
        if (!dataReader.IsDBNull(4))
          programBuilder.PublishTime = new DateTime?(dataReader.GetDateTime(4));
        programBuilder.CreateUser = dataReader.GetGuid(5);
        programBuilder.SQL = dataReader.GetString(6);
        programBuilder.IsAdd = dataReader.GetInt32(7);
        programBuilder.DBConnID = dataReader.GetGuid(8);
        programBuilder.Status = dataReader.GetInt32(9);
        if (!dataReader.IsDBNull(10))
          programBuilder.FormID = dataReader.GetString(10);
        if (!dataReader.IsDBNull(11))
          programBuilder.EditModel = new int?(dataReader.GetInt32(11));
        if (!dataReader.IsDBNull(12))
          programBuilder.Width = dataReader.GetString(12);
        if (!dataReader.IsDBNull(13))
          programBuilder.Height = dataReader.GetString(13);
        if (!dataReader.IsDBNull(14))
          programBuilder.ButtonLocation = new int?(dataReader.GetInt32(14));
        if (!dataReader.IsDBNull(15))
          programBuilder.IsPager = new int?(dataReader.GetInt32(15));
        if (!dataReader.IsDBNull(16))
          programBuilder.ClientScript = dataReader.GetString(16);
        if (!dataReader.IsDBNull(17))
          programBuilder.ExportTemplate = dataReader.GetString(17);
        if (!dataReader.IsDBNull(18))
          programBuilder.ExportHeaderText = dataReader.GetString(18);
        if (!dataReader.IsDBNull(19))
          programBuilder.ExportFileName = dataReader.GetString(19);
        if (!dataReader.IsDBNull(20))
          programBuilder.TableStyle = dataReader.GetString(20);
        if (!dataReader.IsDBNull(21))
          programBuilder.TableHead = dataReader.GetString(21);
        if (!dataReader.IsDBNull(22))
          programBuilder.TableName = dataReader.GetString(22);
        if (!dataReader.IsDBNull(23))
          programBuilder.InDataNumberFiledName = dataReader.GetString(23);
        programBuilderList.Add(programBuilder);
      }
      return programBuilderList;
    }

    public List<RoadFlow.Data.Model.ProgramBuilder> GetAll()
    {
      SqlDataReader dataReader = this.dbHelper.GetDataReader("SELECT * FROM ProgramBuilder");
      List<RoadFlow.Data.Model.ProgramBuilder> list = this.DataReaderToList(dataReader);
      dataReader.Close();
      return list;
    }

    public long GetCount()
    {
      long result;
      if (!long.TryParse(this.dbHelper.GetFieldValue("SELECT COUNT(*) FROM ProgramBuilder"), out result))
        return 0;
      return result;
    }

    public RoadFlow.Data.Model.ProgramBuilder Get(Guid id)
    {
      string sql = "SELECT * FROM ProgramBuilder WHERE ID=@ID";
      SqlParameter[] sqlParameterArray = new SqlParameter[1];
      int index = 0;
      SqlParameter sqlParameter = new SqlParameter("@ID", SqlDbType.UniqueIdentifier);
      sqlParameter.Value = (object) id;
      sqlParameterArray[index] = sqlParameter;
      SqlParameter[] parameter = sqlParameterArray;
      SqlDataReader dataReader = this.dbHelper.GetDataReader(sql, parameter);
      List<RoadFlow.Data.Model.ProgramBuilder> list = this.DataReaderToList(dataReader);
      dataReader.Close();
      if (list.Count <= 0)
        return (RoadFlow.Data.Model.ProgramBuilder) null;
      return list[0];
    }

    public List<RoadFlow.Data.Model.ProgramBuilder> GetList(out string pager, string query = "", string name = "", string typeid = "")
    {
      List<SqlParameter> sqlParameterList = new List<SqlParameter>();
      StringBuilder stringBuilder = new StringBuilder("SELECT *,ROW_NUMBER() OVER(ORDER BY CreateTime DESC) AS PagerAutoRowNumber FROM ProgramBuilder WHERE Status<>2 ");
      if (!name.IsNullOrEmpty())
      {
        stringBuilder.Append(" AND CHARINDEX(@Name,Name)>0");
        sqlParameterList.Add(new SqlParameter("@Name", (object) name));
      }
      if (!typeid.IsNullOrEmpty())
        stringBuilder.Append(" AND Type IN(" + Tools.GetSqlInString(typeid, true, ",") + ")");
      int pageSize = Tools.GetPageSize();
      int pageNumber = Tools.GetPageNumber();
      long count;
      string paerSql = this.dbHelper.GetPaerSql(stringBuilder.ToString(), pageSize, pageNumber, out count, sqlParameterList.ToArray());
      pager = Tools.GetPagerHtml(count, pageSize, pageNumber, query);
      SqlDataReader dataReader = this.dbHelper.GetDataReader(paerSql, sqlParameterList.ToArray());
      List<RoadFlow.Data.Model.ProgramBuilder> list = this.DataReaderToList(dataReader);
      dataReader.Close();
      return list;
    }
  }
}
