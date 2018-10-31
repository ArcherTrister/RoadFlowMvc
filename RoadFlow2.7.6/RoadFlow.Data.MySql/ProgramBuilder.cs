// Decompiled with JetBrains decompiler
// Type: RoadFlow.Data.MySql.ProgramBuilder
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
  public class ProgramBuilder : IProgramBuilder
  {
    private DBHelper dbHelper = new DBHelper();

    public int Add(RoadFlow.Data.Model.ProgramBuilder model)
    {
      string sql = "INSERT INTO programbuilder\r\n\t\t\t\t(ID,Name,Type,CreateTime,PublishTime,CreateUser,`SQL`,IsAdd,DBConnID,Status,FormID,EditModel,Width,Height,ButtonLocation,IsPager,ClientScript,ExportTemplate,ExportHeaderText,ExportFileName,TableStyle,TableHead,`TableName`,InDataNumberFiledName) \r\n\t\t\t\tVALUES(@ID,@Name,@Type,@CreateTime,@PublishTime,@CreateUser,@SQL,@IsAdd,@DBConnID,@Status,@FormID,@EditModel,@Width,@Height,@ButtonLocation,@IsPager,@ClientScript,@ExportTemplate,@ExportHeaderText,@ExportFileName,@TableStyle,@TableHead,@TableName,@InDataNumberFiledName)";
      MySqlParameter[] mySqlParameterArray = new MySqlParameter[24];
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
      MySqlParameter mySqlParameter4 = new MySqlParameter("@CreateTime", MySqlDbType.DateTime, -1);
      mySqlParameter4.Value = (object) model.CreateTime;
      mySqlParameterArray[index4] = mySqlParameter4;
      int index5 = 4;
      MySqlParameter mySqlParameter5;
      if (model.PublishTime.HasValue)
      {
        MySqlParameter mySqlParameter6 = new MySqlParameter("@PublishTime", MySqlDbType.DateTime, -1);
        mySqlParameter6.Value = (object) model.PublishTime;
        mySqlParameter5 = mySqlParameter6;
      }
      else
      {
        mySqlParameter5 = new MySqlParameter("@PublishTime", MySqlDbType.DateTime, -1);
        mySqlParameter5.Value = (object) DBNull.Value;
      }
      mySqlParameterArray[index5] = mySqlParameter5;
      int index6 = 5;
      MySqlParameter mySqlParameter7 = new MySqlParameter("@CreateUser", MySqlDbType.VarChar, 36);
      mySqlParameter7.Value = (object) model.CreateUser;
      mySqlParameterArray[index6] = mySqlParameter7;
      int index7 = 6;
      MySqlParameter mySqlParameter8 = new MySqlParameter("@SQL", MySqlDbType.LongText, -1);
      mySqlParameter8.Value = (object) model.SQL;
      mySqlParameterArray[index7] = mySqlParameter8;
      int index8 = 7;
      MySqlParameter mySqlParameter9 = new MySqlParameter("@IsAdd", MySqlDbType.Int32, 11);
      mySqlParameter9.Value = (object) model.IsAdd;
      mySqlParameterArray[index8] = mySqlParameter9;
      int index9 = 8;
      MySqlParameter mySqlParameter10 = new MySqlParameter("@DBConnID", MySqlDbType.VarChar, 36);
      mySqlParameter10.Value = (object) model.DBConnID;
      mySqlParameterArray[index9] = mySqlParameter10;
      int index10 = 9;
      MySqlParameter mySqlParameter11 = new MySqlParameter("@Status", MySqlDbType.Int32, 11);
      mySqlParameter11.Value = (object) model.Status;
      mySqlParameterArray[index10] = mySqlParameter11;
      int index11 = 10;
      MySqlParameter mySqlParameter12;
      if (model.FormID != null)
      {
        MySqlParameter mySqlParameter6 = new MySqlParameter("@FormID", MySqlDbType.Text, -1);
        mySqlParameter6.Value = (object) model.FormID;
        mySqlParameter12 = mySqlParameter6;
      }
      else
      {
        mySqlParameter12 = new MySqlParameter("@FormID", MySqlDbType.Text, -1);
        mySqlParameter12.Value = (object) DBNull.Value;
      }
      mySqlParameterArray[index11] = mySqlParameter12;
      int index12 = 11;
      int? nullable = model.EditModel;
      MySqlParameter mySqlParameter13;
      if (nullable.HasValue)
      {
        MySqlParameter mySqlParameter6 = new MySqlParameter("@EditModel", MySqlDbType.Int32, 11);
        mySqlParameter6.Value = (object) model.EditModel;
        mySqlParameter13 = mySqlParameter6;
      }
      else
      {
        mySqlParameter13 = new MySqlParameter("@EditModel", MySqlDbType.Int32, 11);
        mySqlParameter13.Value = (object) DBNull.Value;
      }
      mySqlParameterArray[index12] = mySqlParameter13;
      int index13 = 12;
      MySqlParameter mySqlParameter14;
      if (model.Width != null)
      {
        MySqlParameter mySqlParameter6 = new MySqlParameter("@Width", MySqlDbType.VarChar, 50);
        mySqlParameter6.Value = (object) model.Width;
        mySqlParameter14 = mySqlParameter6;
      }
      else
      {
        mySqlParameter14 = new MySqlParameter("@Width", MySqlDbType.VarChar, 50);
        mySqlParameter14.Value = (object) DBNull.Value;
      }
      mySqlParameterArray[index13] = mySqlParameter14;
      int index14 = 13;
      MySqlParameter mySqlParameter15;
      if (model.Height != null)
      {
        MySqlParameter mySqlParameter6 = new MySqlParameter("@Height", MySqlDbType.VarChar, 50);
        mySqlParameter6.Value = (object) model.Height;
        mySqlParameter15 = mySqlParameter6;
      }
      else
      {
        mySqlParameter15 = new MySqlParameter("@Height", MySqlDbType.VarChar, 50);
        mySqlParameter15.Value = (object) DBNull.Value;
      }
      mySqlParameterArray[index14] = mySqlParameter15;
      int index15 = 14;
      nullable = model.ButtonLocation;
      MySqlParameter mySqlParameter16;
      if (nullable.HasValue)
      {
        MySqlParameter mySqlParameter6 = new MySqlParameter("@ButtonLocation", MySqlDbType.Int32, 11);
        mySqlParameter6.Value = (object) model.ButtonLocation;
        mySqlParameter16 = mySqlParameter6;
      }
      else
      {
        mySqlParameter16 = new MySqlParameter("@ButtonLocation", MySqlDbType.Int32, 11);
        mySqlParameter16.Value = (object) DBNull.Value;
      }
      mySqlParameterArray[index15] = mySqlParameter16;
      int index16 = 15;
      nullable = model.IsPager;
      MySqlParameter mySqlParameter17;
      if (nullable.HasValue)
      {
        MySqlParameter mySqlParameter6 = new MySqlParameter("@IsPager", MySqlDbType.Int32, 11);
        mySqlParameter6.Value = (object) model.IsPager;
        mySqlParameter17 = mySqlParameter6;
      }
      else
      {
        mySqlParameter17 = new MySqlParameter("@IsPager", MySqlDbType.Int32, 11);
        mySqlParameter17.Value = (object) DBNull.Value;
      }
      mySqlParameterArray[index16] = mySqlParameter17;
      int index17 = 16;
      MySqlParameter mySqlParameter18;
      if (model.ClientScript != null)
      {
        MySqlParameter mySqlParameter6 = new MySqlParameter("@ClientScript", MySqlDbType.LongText, -1);
        mySqlParameter6.Value = (object) model.ClientScript;
        mySqlParameter18 = mySqlParameter6;
      }
      else
      {
        mySqlParameter18 = new MySqlParameter("@ClientScript", MySqlDbType.LongText, -1);
        mySqlParameter18.Value = (object) DBNull.Value;
      }
      mySqlParameterArray[index17] = mySqlParameter18;
      int index18 = 17;
      MySqlParameter mySqlParameter19;
      if (model.ExportTemplate != null)
      {
        MySqlParameter mySqlParameter6 = new MySqlParameter("@ExportTemplate", MySqlDbType.Text, -1);
        mySqlParameter6.Value = (object) model.ExportTemplate;
        mySqlParameter19 = mySqlParameter6;
      }
      else
      {
        mySqlParameter19 = new MySqlParameter("@ExportTemplate", MySqlDbType.Text, -1);
        mySqlParameter19.Value = (object) DBNull.Value;
      }
      mySqlParameterArray[index18] = mySqlParameter19;
      int index19 = 18;
      MySqlParameter mySqlParameter20;
      if (model.ExportHeaderText != null)
      {
        MySqlParameter mySqlParameter6 = new MySqlParameter("@ExportHeaderText", MySqlDbType.Text, -1);
        mySqlParameter6.Value = (object) model.ExportHeaderText;
        mySqlParameter20 = mySqlParameter6;
      }
      else
      {
        mySqlParameter20 = new MySqlParameter("@ExportHeaderText", MySqlDbType.Text, -1);
        mySqlParameter20.Value = (object) DBNull.Value;
      }
      mySqlParameterArray[index19] = mySqlParameter20;
      int index20 = 19;
      MySqlParameter mySqlParameter21;
      if (model.ExportFileName != null)
      {
        MySqlParameter mySqlParameter6 = new MySqlParameter("@ExportFileName", MySqlDbType.Text, -1);
        mySqlParameter6.Value = (object) model.ExportFileName;
        mySqlParameter21 = mySqlParameter6;
      }
      else
      {
        mySqlParameter21 = new MySqlParameter("@ExportFileName", MySqlDbType.Text, -1);
        mySqlParameter21.Value = (object) DBNull.Value;
      }
      mySqlParameterArray[index20] = mySqlParameter21;
      int index21 = 20;
      MySqlParameter mySqlParameter22;
      if (model.TableStyle != null)
      {
        MySqlParameter mySqlParameter6 = new MySqlParameter("@TableStyle", MySqlDbType.VarChar, (int) byte.MaxValue);
        mySqlParameter6.Value = (object) model.TableStyle;
        mySqlParameter22 = mySqlParameter6;
      }
      else
      {
        mySqlParameter22 = new MySqlParameter("@TableStyle", MySqlDbType.VarChar, (int) byte.MaxValue);
        mySqlParameter22.Value = (object) DBNull.Value;
      }
      mySqlParameterArray[index21] = mySqlParameter22;
      int index22 = 21;
      MySqlParameter mySqlParameter23;
      if (model.TableHead != null)
      {
        MySqlParameter mySqlParameter6 = new MySqlParameter("@TableHead", MySqlDbType.Text, -1);
        mySqlParameter6.Value = (object) model.TableHead;
        mySqlParameter23 = mySqlParameter6;
      }
      else
      {
        mySqlParameter23 = new MySqlParameter("@TableHead", MySqlDbType.Text, -1);
        mySqlParameter23.Value = (object) DBNull.Value;
      }
      mySqlParameterArray[index22] = mySqlParameter23;
      int index23 = 22;
      MySqlParameter mySqlParameter24;
      if (model.TableName != null)
      {
        MySqlParameter mySqlParameter6 = new MySqlParameter("@TableName", MySqlDbType.VarChar, (int) byte.MaxValue);
        mySqlParameter6.Value = (object) model.TableName;
        mySqlParameter24 = mySqlParameter6;
      }
      else
      {
        mySqlParameter24 = new MySqlParameter("@TableName", MySqlDbType.VarChar, (int) byte.MaxValue);
        mySqlParameter24.Value = (object) DBNull.Value;
      }
      mySqlParameterArray[index23] = mySqlParameter24;
      int index24 = 23;
      MySqlParameter mySqlParameter25;
      if (model.InDataNumberFiledName != null)
      {
        MySqlParameter mySqlParameter6 = new MySqlParameter("@InDataNumberFiledName", MySqlDbType.VarChar, (int) byte.MaxValue);
        mySqlParameter6.Value = (object) model.InDataNumberFiledName;
        mySqlParameter25 = mySqlParameter6;
      }
      else
      {
        mySqlParameter25 = new MySqlParameter("@InDataNumberFiledName", MySqlDbType.VarChar, (int) byte.MaxValue);
        mySqlParameter25.Value = (object) DBNull.Value;
      }
      mySqlParameterArray[index24] = mySqlParameter25;
      MySqlParameter[] parameter = mySqlParameterArray;
      return this.dbHelper.Execute(sql, parameter, false);
    }

    public int Update(RoadFlow.Data.Model.ProgramBuilder model)
    {
      string sql = "UPDATE programbuilder SET \r\n\t\t\t\tName=@Name,Type=@Type,CreateTime=@CreateTime,PublishTime=@PublishTime,CreateUser=@CreateUser,`SQL`=@SQL,IsAdd=@IsAdd,DBConnID=@DBConnID,Status=@Status,FormID=@FormID,EditModel=@EditModel,Width=@Width,Height=@Height,ButtonLocation=@ButtonLocation,IsPager=@IsPager,ClientScript=@ClientScript,ExportTemplate=@ExportTemplate,ExportHeaderText=@ExportHeaderText,ExportFileName=@ExportFileName,TableStyle=@TableStyle,TableHead=@TableHead,TableName=@TableName,InDataNumberFiledName=@InDataNumberFiledName    \r\n\t\t\t\tWHERE ID=@ID";
      MySqlParameter[] mySqlParameterArray = new MySqlParameter[24];
      int index1 = 0;
      MySqlParameter mySqlParameter1 = new MySqlParameter("@Name", MySqlDbType.Text, -1);
      mySqlParameter1.Value = (object) model.Name;
      mySqlParameterArray[index1] = mySqlParameter1;
      int index2 = 1;
      MySqlParameter mySqlParameter2 = new MySqlParameter("@Type", MySqlDbType.VarChar, 36);
      mySqlParameter2.Value = (object) model.Type;
      mySqlParameterArray[index2] = mySqlParameter2;
      int index3 = 2;
      MySqlParameter mySqlParameter3 = new MySqlParameter("@CreateTime", MySqlDbType.DateTime, -1);
      mySqlParameter3.Value = (object) model.CreateTime;
      mySqlParameterArray[index3] = mySqlParameter3;
      int index4 = 3;
      MySqlParameter mySqlParameter4;
      if (model.PublishTime.HasValue)
      {
        MySqlParameter mySqlParameter5 = new MySqlParameter("@PublishTime", MySqlDbType.DateTime, -1);
        mySqlParameter5.Value = (object) model.PublishTime;
        mySqlParameter4 = mySqlParameter5;
      }
      else
      {
        mySqlParameter4 = new MySqlParameter("@PublishTime", MySqlDbType.DateTime, -1);
        mySqlParameter4.Value = (object) DBNull.Value;
      }
      mySqlParameterArray[index4] = mySqlParameter4;
      int index5 = 4;
      MySqlParameter mySqlParameter6 = new MySqlParameter("@CreateUser", MySqlDbType.VarChar, 36);
      mySqlParameter6.Value = (object) model.CreateUser;
      mySqlParameterArray[index5] = mySqlParameter6;
      int index6 = 5;
      MySqlParameter mySqlParameter7 = new MySqlParameter("@SQL", MySqlDbType.LongText, -1);
      mySqlParameter7.Value = (object) model.SQL;
      mySqlParameterArray[index6] = mySqlParameter7;
      int index7 = 6;
      MySqlParameter mySqlParameter8 = new MySqlParameter("@IsAdd", MySqlDbType.Int32, 11);
      mySqlParameter8.Value = (object) model.IsAdd;
      mySqlParameterArray[index7] = mySqlParameter8;
      int index8 = 7;
      MySqlParameter mySqlParameter9 = new MySqlParameter("@DBConnID", MySqlDbType.VarChar, 36);
      mySqlParameter9.Value = (object) model.DBConnID;
      mySqlParameterArray[index8] = mySqlParameter9;
      int index9 = 8;
      MySqlParameter mySqlParameter10 = new MySqlParameter("@Status", MySqlDbType.Int32, 11);
      mySqlParameter10.Value = (object) model.Status;
      mySqlParameterArray[index9] = mySqlParameter10;
      int index10 = 9;
      MySqlParameter mySqlParameter11;
      if (model.FormID != null)
      {
        MySqlParameter mySqlParameter5 = new MySqlParameter("@FormID", MySqlDbType.Text, -1);
        mySqlParameter5.Value = (object) model.FormID;
        mySqlParameter11 = mySqlParameter5;
      }
      else
      {
        mySqlParameter11 = new MySqlParameter("@FormID", MySqlDbType.Text, -1);
        mySqlParameter11.Value = (object) DBNull.Value;
      }
      mySqlParameterArray[index10] = mySqlParameter11;
      int index11 = 10;
      int? nullable = model.EditModel;
      MySqlParameter mySqlParameter12;
      if (nullable.HasValue)
      {
        MySqlParameter mySqlParameter5 = new MySqlParameter("@EditModel", MySqlDbType.Int32, 11);
        mySqlParameter5.Value = (object) model.EditModel;
        mySqlParameter12 = mySqlParameter5;
      }
      else
      {
        mySqlParameter12 = new MySqlParameter("@EditModel", MySqlDbType.Int32, 11);
        mySqlParameter12.Value = (object) DBNull.Value;
      }
      mySqlParameterArray[index11] = mySqlParameter12;
      int index12 = 11;
      MySqlParameter mySqlParameter13;
      if (model.Width != null)
      {
        MySqlParameter mySqlParameter5 = new MySqlParameter("@Width", MySqlDbType.VarChar, 50);
        mySqlParameter5.Value = (object) model.Width;
        mySqlParameter13 = mySqlParameter5;
      }
      else
      {
        mySqlParameter13 = new MySqlParameter("@Width", MySqlDbType.VarChar, 50);
        mySqlParameter13.Value = (object) DBNull.Value;
      }
      mySqlParameterArray[index12] = mySqlParameter13;
      int index13 = 12;
      MySqlParameter mySqlParameter14;
      if (model.Height != null)
      {
        MySqlParameter mySqlParameter5 = new MySqlParameter("@Height", MySqlDbType.VarChar, 50);
        mySqlParameter5.Value = (object) model.Height;
        mySqlParameter14 = mySqlParameter5;
      }
      else
      {
        mySqlParameter14 = new MySqlParameter("@Height", MySqlDbType.VarChar, 50);
        mySqlParameter14.Value = (object) DBNull.Value;
      }
      mySqlParameterArray[index13] = mySqlParameter14;
      int index14 = 13;
      nullable = model.ButtonLocation;
      MySqlParameter mySqlParameter15;
      if (nullable.HasValue)
      {
        MySqlParameter mySqlParameter5 = new MySqlParameter("@ButtonLocation", MySqlDbType.Int32, 11);
        mySqlParameter5.Value = (object) model.ButtonLocation;
        mySqlParameter15 = mySqlParameter5;
      }
      else
      {
        mySqlParameter15 = new MySqlParameter("@ButtonLocation", MySqlDbType.Int32, 11);
        mySqlParameter15.Value = (object) DBNull.Value;
      }
      mySqlParameterArray[index14] = mySqlParameter15;
      int index15 = 14;
      nullable = model.IsPager;
      MySqlParameter mySqlParameter16;
      if (nullable.HasValue)
      {
        MySqlParameter mySqlParameter5 = new MySqlParameter("@IsPager", MySqlDbType.Int32, 11);
        mySqlParameter5.Value = (object) model.IsPager;
        mySqlParameter16 = mySqlParameter5;
      }
      else
      {
        mySqlParameter16 = new MySqlParameter("@IsPager", MySqlDbType.Int32, 11);
        mySqlParameter16.Value = (object) DBNull.Value;
      }
      mySqlParameterArray[index15] = mySqlParameter16;
      int index16 = 15;
      MySqlParameter mySqlParameter17;
      if (model.ClientScript != null)
      {
        MySqlParameter mySqlParameter5 = new MySqlParameter("@ClientScript", MySqlDbType.LongText, -1);
        mySqlParameter5.Value = (object) model.ClientScript;
        mySqlParameter17 = mySqlParameter5;
      }
      else
      {
        mySqlParameter17 = new MySqlParameter("@ClientScript", MySqlDbType.LongText, -1);
        mySqlParameter17.Value = (object) DBNull.Value;
      }
      mySqlParameterArray[index16] = mySqlParameter17;
      int index17 = 16;
      MySqlParameter mySqlParameter18;
      if (model.ExportTemplate != null)
      {
        MySqlParameter mySqlParameter5 = new MySqlParameter("@ExportTemplate", MySqlDbType.Text, -1);
        mySqlParameter5.Value = (object) model.ExportTemplate;
        mySqlParameter18 = mySqlParameter5;
      }
      else
      {
        mySqlParameter18 = new MySqlParameter("@ExportTemplate", MySqlDbType.Text, -1);
        mySqlParameter18.Value = (object) DBNull.Value;
      }
      mySqlParameterArray[index17] = mySqlParameter18;
      int index18 = 17;
      MySqlParameter mySqlParameter19;
      if (model.ExportHeaderText != null)
      {
        MySqlParameter mySqlParameter5 = new MySqlParameter("@ExportHeaderText", MySqlDbType.Text, -1);
        mySqlParameter5.Value = (object) model.ExportHeaderText;
        mySqlParameter19 = mySqlParameter5;
      }
      else
      {
        mySqlParameter19 = new MySqlParameter("@ExportHeaderText", MySqlDbType.Text, -1);
        mySqlParameter19.Value = (object) DBNull.Value;
      }
      mySqlParameterArray[index18] = mySqlParameter19;
      int index19 = 18;
      MySqlParameter mySqlParameter20;
      if (model.ExportFileName != null)
      {
        MySqlParameter mySqlParameter5 = new MySqlParameter("@ExportFileName", MySqlDbType.Text, -1);
        mySqlParameter5.Value = (object) model.ExportFileName;
        mySqlParameter20 = mySqlParameter5;
      }
      else
      {
        mySqlParameter20 = new MySqlParameter("@ExportFileName", MySqlDbType.Text, -1);
        mySqlParameter20.Value = (object) DBNull.Value;
      }
      mySqlParameterArray[index19] = mySqlParameter20;
      int index20 = 19;
      MySqlParameter mySqlParameter21;
      if (model.TableStyle != null)
      {
        MySqlParameter mySqlParameter5 = new MySqlParameter("@TableStyle", MySqlDbType.VarChar, (int) byte.MaxValue);
        mySqlParameter5.Value = (object) model.TableStyle;
        mySqlParameter21 = mySqlParameter5;
      }
      else
      {
        mySqlParameter21 = new MySqlParameter("@TableStyle", MySqlDbType.VarChar, (int) byte.MaxValue);
        mySqlParameter21.Value = (object) DBNull.Value;
      }
      mySqlParameterArray[index20] = mySqlParameter21;
      int index21 = 20;
      MySqlParameter mySqlParameter22;
      if (model.TableHead != null)
      {
        MySqlParameter mySqlParameter5 = new MySqlParameter("@TableHead", MySqlDbType.Text, -1);
        mySqlParameter5.Value = (object) model.TableHead;
        mySqlParameter22 = mySqlParameter5;
      }
      else
      {
        mySqlParameter22 = new MySqlParameter("@TableHead", MySqlDbType.Text, -1);
        mySqlParameter22.Value = (object) DBNull.Value;
      }
      mySqlParameterArray[index21] = mySqlParameter22;
      int index22 = 21;
      MySqlParameter mySqlParameter23;
      if (model.TableName != null)
      {
        MySqlParameter mySqlParameter5 = new MySqlParameter("@TableName", MySqlDbType.VarChar, (int) byte.MaxValue);
        mySqlParameter5.Value = (object) model.TableName;
        mySqlParameter23 = mySqlParameter5;
      }
      else
      {
        mySqlParameter23 = new MySqlParameter("@TableName", MySqlDbType.VarChar, (int) byte.MaxValue);
        mySqlParameter23.Value = (object) DBNull.Value;
      }
      mySqlParameterArray[index22] = mySqlParameter23;
      int index23 = 22;
      MySqlParameter mySqlParameter24;
      if (model.InDataNumberFiledName != null)
      {
        MySqlParameter mySqlParameter5 = new MySqlParameter("@InDataNumberFiledName", MySqlDbType.VarChar, (int) byte.MaxValue);
        mySqlParameter5.Value = (object) model.InDataNumberFiledName;
        mySqlParameter24 = mySqlParameter5;
      }
      else
      {
        mySqlParameter24 = new MySqlParameter("@InDataNumberFiledName", MySqlDbType.VarChar, (int) byte.MaxValue);
        mySqlParameter24.Value = (object) DBNull.Value;
      }
      mySqlParameterArray[index23] = mySqlParameter24;
      int index24 = 23;
      MySqlParameter mySqlParameter25 = new MySqlParameter("@ID", MySqlDbType.VarChar, 36);
      mySqlParameter25.Value = (object) model.ID;
      mySqlParameterArray[index24] = mySqlParameter25;
      MySqlParameter[] parameter = mySqlParameterArray;
      return this.dbHelper.Execute(sql, parameter, false);
    }

    public int Delete(Guid id)
    {
      string sql = "DELETE FROM programbuilder WHERE ID=@ID";
      MySqlParameter[] mySqlParameterArray = new MySqlParameter[1];
      int index = 0;
      MySqlParameter mySqlParameter = new MySqlParameter("@ID", MySqlDbType.VarChar, 36);
      mySqlParameter.Value = (object) id.ToString();
      mySqlParameterArray[index] = mySqlParameter;
      MySqlParameter[] parameter = mySqlParameterArray;
      return this.dbHelper.Execute(sql, parameter, false);
    }

    private List<RoadFlow.Data.Model.ProgramBuilder> DataReaderToList(MySqlDataReader dataReader)
    {
      List<RoadFlow.Data.Model.ProgramBuilder> programBuilderList = new List<RoadFlow.Data.Model.ProgramBuilder>();
      while (dataReader.Read())
      {
        RoadFlow.Data.Model.ProgramBuilder programBuilder = new RoadFlow.Data.Model.ProgramBuilder();
        programBuilder.ID = dataReader.GetString(0).ToGuid();
        programBuilder.Name = dataReader.GetString(1);
        programBuilder.Type = dataReader.GetString(2).ToGuid();
        programBuilder.CreateTime = dataReader.GetDateTime(3);
        if (!dataReader.IsDBNull(4))
          programBuilder.PublishTime = new DateTime?(dataReader.GetDateTime(4));
        programBuilder.CreateUser = dataReader.GetString(5).ToGuid();
        programBuilder.SQL = dataReader.GetString(6);
        programBuilder.IsAdd = dataReader.GetInt32(7);
        programBuilder.DBConnID = dataReader.GetString(8).ToGuid();
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
      MySqlDataReader dataReader = this.dbHelper.GetDataReader("SELECT * FROM programbuilder");
      List<RoadFlow.Data.Model.ProgramBuilder> list = this.DataReaderToList(dataReader);
      dataReader.Close();
      return list;
    }

    public long GetCount()
    {
      long result;
      if (!long.TryParse(this.dbHelper.GetFieldValue("SELECT COUNT(*) FROM programbuilder"), out result))
        return 0;
      return result;
    }

    public RoadFlow.Data.Model.ProgramBuilder Get(Guid id)
    {
      string sql = "SELECT * FROM programbuilder WHERE ID=@ID";
      MySqlParameter[] mySqlParameterArray = new MySqlParameter[1];
      int index = 0;
      MySqlParameter mySqlParameter = new MySqlParameter("@ID", MySqlDbType.VarChar, 36);
      mySqlParameter.Value = (object) id.ToString();
      mySqlParameterArray[index] = mySqlParameter;
      MySqlParameter[] parameter = mySqlParameterArray;
      MySqlDataReader dataReader = this.dbHelper.GetDataReader(sql, parameter);
      List<RoadFlow.Data.Model.ProgramBuilder> list = this.DataReaderToList(dataReader);
      dataReader.Close();
      if (list.Count <= 0)
        return (RoadFlow.Data.Model.ProgramBuilder) null;
      return list[0];
    }

    public List<RoadFlow.Data.Model.ProgramBuilder> GetList(out string pager, string query = "", string name = "", string typeid = "")
    {
      List<MySqlParameter> mySqlParameterList = new List<MySqlParameter>();
      StringBuilder stringBuilder = new StringBuilder("SELECT * FROM ProgramBuilder WHERE Status<>2 ");
      if (!name.IsNullOrEmpty())
      {
        stringBuilder.Append(" AND INSTR(Name,@Name)>0");
        mySqlParameterList.Add(new MySqlParameter("@Name", (object) name));
      }
      if (!typeid.IsNullOrEmpty())
        stringBuilder.Append(" AND Type IN(" + Tools.GetSqlInString(typeid, true, ",") + ")");
      stringBuilder.Append(" ORDER BY CreateTime DESC");
      int pageSize = Tools.GetPageSize();
      int pageNumber = Tools.GetPageNumber();
      long count;
      string paerSql = this.dbHelper.GetPaerSql(stringBuilder.ToString(), pageSize, pageNumber, out count, mySqlParameterList.ToArray());
      pager = Tools.GetPagerHtml(count, pageSize, pageNumber, query);
      MySqlDataReader dataReader = this.dbHelper.GetDataReader(paerSql, mySqlParameterList.ToArray());
      List<RoadFlow.Data.Model.ProgramBuilder> list = this.DataReaderToList(dataReader);
      dataReader.Close();
      return list;
    }
  }
}
