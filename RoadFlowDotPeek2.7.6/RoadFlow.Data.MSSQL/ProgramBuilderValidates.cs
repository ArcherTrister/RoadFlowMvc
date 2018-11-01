// Decompiled with JetBrains decompiler
// Type: RoadFlow.Data.MSSQL.ProgramBuilderValidates
// Assembly: RoadFlow.Data.MSSQL, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 5107CDC7-8F84-4EE0-AC6D-E80FE4695340
// Assembly location: C:\inetpub\wwwroot\RoadFlowMvc\bin\RoadFlow.Data.MSSQL.dll

using RoadFlow.Data.Interface;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;

namespace RoadFlow.Data.MSSQL
{
  public class ProgramBuilderValidates : IProgramBuilderValidates
  {
    private DBHelper dbHelper = new DBHelper();

    public int Add(RoadFlow.Data.Model.ProgramBuilderValidates model)
    {
      string sql = "INSERT INTO ProgramBuilderValidates\r\n\t\t\t\t(ID,ProgramID,TableName,FieldName,FieldNote,Validate) \r\n\t\t\t\tVALUES(@ID,@ProgramID,@TableName,@FieldName,@FieldNote,@Validate)";
      SqlParameter[] sqlParameterArray = new SqlParameter[6];
      int index1 = 0;
      SqlParameter sqlParameter1 = new SqlParameter("@ID", SqlDbType.UniqueIdentifier, -1);
      sqlParameter1.Value = (object) model.ID;
      sqlParameterArray[index1] = sqlParameter1;
      int index2 = 1;
      SqlParameter sqlParameter2 = new SqlParameter("@ProgramID", SqlDbType.UniqueIdentifier, -1);
      sqlParameter2.Value = (object) model.ProgramID;
      sqlParameterArray[index2] = sqlParameter2;
      int index3 = 2;
      SqlParameter sqlParameter3 = new SqlParameter("@TableName", SqlDbType.VarChar, 500);
      sqlParameter3.Value = (object) model.TableName;
      sqlParameterArray[index3] = sqlParameter3;
      int index4 = 3;
      SqlParameter sqlParameter4 = new SqlParameter("@FieldName", SqlDbType.VarChar, 500);
      sqlParameter4.Value = (object) model.FieldName;
      sqlParameterArray[index4] = sqlParameter4;
      int index5 = 4;
      SqlParameter sqlParameter5;
      if (model.FieldNote != null)
      {
        SqlParameter sqlParameter6 = new SqlParameter("@FieldNote", SqlDbType.NVarChar, 1000);
        sqlParameter6.Value = (object) model.FieldNote;
        sqlParameter5 = sqlParameter6;
      }
      else
      {
        sqlParameter5 = new SqlParameter("@FieldNote", SqlDbType.NVarChar, 1000);
        sqlParameter5.Value = (object) DBNull.Value;
      }
      sqlParameterArray[index5] = sqlParameter5;
      int index6 = 5;
      SqlParameter sqlParameter7 = new SqlParameter("@Validate", SqlDbType.Int, -1);
      sqlParameter7.Value = (object) model.Validate;
      sqlParameterArray[index6] = sqlParameter7;
      SqlParameter[] parameter = sqlParameterArray;
      return this.dbHelper.Execute(sql, parameter, false);
    }

    public int Update(RoadFlow.Data.Model.ProgramBuilderValidates model)
    {
      string sql = "UPDATE ProgramBuilderValidates SET \r\n\t\t\t\tProgramID=@ProgramID,TableName=@TableName,FieldName=@FieldName,FieldNote=@FieldNote,Validate=@Validate\r\n\t\t\t\tWHERE ID=@ID";
      SqlParameter[] sqlParameterArray = new SqlParameter[6];
      int index1 = 0;
      SqlParameter sqlParameter1 = new SqlParameter("@ProgramID", SqlDbType.UniqueIdentifier, -1);
      sqlParameter1.Value = (object) model.ProgramID;
      sqlParameterArray[index1] = sqlParameter1;
      int index2 = 1;
      SqlParameter sqlParameter2 = new SqlParameter("@TableName", SqlDbType.VarChar, 500);
      sqlParameter2.Value = (object) model.TableName;
      sqlParameterArray[index2] = sqlParameter2;
      int index3 = 2;
      SqlParameter sqlParameter3 = new SqlParameter("@FieldName", SqlDbType.VarChar, 500);
      sqlParameter3.Value = (object) model.FieldName;
      sqlParameterArray[index3] = sqlParameter3;
      int index4 = 3;
      SqlParameter sqlParameter4;
      if (model.FieldNote != null)
      {
        SqlParameter sqlParameter5 = new SqlParameter("@FieldNote", SqlDbType.NVarChar, 1000);
        sqlParameter5.Value = (object) model.FieldNote;
        sqlParameter4 = sqlParameter5;
      }
      else
      {
        sqlParameter4 = new SqlParameter("@FieldNote", SqlDbType.NVarChar, 1000);
        sqlParameter4.Value = (object) DBNull.Value;
      }
      sqlParameterArray[index4] = sqlParameter4;
      int index5 = 4;
      SqlParameter sqlParameter6 = new SqlParameter("@Validate", SqlDbType.Int, -1);
      sqlParameter6.Value = (object) model.Validate;
      sqlParameterArray[index5] = sqlParameter6;
      int index6 = 5;
      SqlParameter sqlParameter7 = new SqlParameter("@ID", SqlDbType.UniqueIdentifier, -1);
      sqlParameter7.Value = (object) model.ID;
      sqlParameterArray[index6] = sqlParameter7;
      SqlParameter[] parameter = sqlParameterArray;
      return this.dbHelper.Execute(sql, parameter, false);
    }

    public int Delete(Guid id)
    {
      string sql = "DELETE FROM ProgramBuilderValidates WHERE ID=@ID";
      SqlParameter[] sqlParameterArray = new SqlParameter[1];
      int index = 0;
      SqlParameter sqlParameter = new SqlParameter("@ID", SqlDbType.UniqueIdentifier);
      sqlParameter.Value = (object) id;
      sqlParameterArray[index] = sqlParameter;
      SqlParameter[] parameter = sqlParameterArray;
      return this.dbHelper.Execute(sql, parameter, false);
    }

    private List<RoadFlow.Data.Model.ProgramBuilderValidates> DataReaderToList(SqlDataReader dataReader)
    {
      List<RoadFlow.Data.Model.ProgramBuilderValidates> builderValidatesList = new List<RoadFlow.Data.Model.ProgramBuilderValidates>();
      while (dataReader.Read())
      {
        RoadFlow.Data.Model.ProgramBuilderValidates builderValidates = new RoadFlow.Data.Model.ProgramBuilderValidates();
        builderValidates.ID = dataReader.GetGuid(0);
        builderValidates.ProgramID = dataReader.GetGuid(1);
        builderValidates.TableName = dataReader.GetString(2);
        builderValidates.FieldName = dataReader.GetString(3);
        if (!dataReader.IsDBNull(4))
          builderValidates.FieldNote = dataReader.GetString(4);
        builderValidates.Validate = dataReader.GetInt32(5);
        builderValidatesList.Add(builderValidates);
      }
      return builderValidatesList;
    }

    public List<RoadFlow.Data.Model.ProgramBuilderValidates> GetAll()
    {
      SqlDataReader dataReader = this.dbHelper.GetDataReader("SELECT * FROM ProgramBuilderValidates");
      List<RoadFlow.Data.Model.ProgramBuilderValidates> list = this.DataReaderToList(dataReader);
      dataReader.Close();
      return list;
    }

    public long GetCount()
    {
      long result;
      if (!long.TryParse(this.dbHelper.GetFieldValue("SELECT COUNT(*) FROM ProgramBuilderValidates"), out result))
        return 0;
      return result;
    }

    public RoadFlow.Data.Model.ProgramBuilderValidates Get(Guid id)
    {
      string sql = "SELECT * FROM ProgramBuilderValidates WHERE ID=@ID";
      SqlParameter[] sqlParameterArray = new SqlParameter[1];
      int index = 0;
      SqlParameter sqlParameter = new SqlParameter("@ID", SqlDbType.UniqueIdentifier);
      sqlParameter.Value = (object) id;
      sqlParameterArray[index] = sqlParameter;
      SqlParameter[] parameter = sqlParameterArray;
      SqlDataReader dataReader = this.dbHelper.GetDataReader(sql, parameter);
      List<RoadFlow.Data.Model.ProgramBuilderValidates> list = this.DataReaderToList(dataReader);
      dataReader.Close();
      if (list.Count <= 0)
        return (RoadFlow.Data.Model.ProgramBuilderValidates) null;
      return list[0];
    }

    public List<RoadFlow.Data.Model.ProgramBuilderValidates> GetAll(Guid programID)
    {
      string sql = "SELECT * FROM ProgramBuilderValidates WHERE ProgramID=@ProgramID";
      SqlParameter[] sqlParameterArray = new SqlParameter[1];
      int index = 0;
      SqlParameter sqlParameter = new SqlParameter("@ProgramID", SqlDbType.UniqueIdentifier);
      sqlParameter.Value = (object) programID;
      sqlParameterArray[index] = sqlParameter;
      SqlParameter[] parameter = sqlParameterArray;
      SqlDataReader dataReader = this.dbHelper.GetDataReader(sql, parameter);
      List<RoadFlow.Data.Model.ProgramBuilderValidates> list = this.DataReaderToList(dataReader);
      dataReader.Close();
      return list;
    }

    public int DeleteByProgramID(Guid id)
    {
      string sql = "DELETE FROM ProgramBuilderValidates WHERE ProgramID=@ProgramID";
      SqlParameter[] sqlParameterArray = new SqlParameter[1];
      int index = 0;
      SqlParameter sqlParameter = new SqlParameter("@ProgramID", SqlDbType.UniqueIdentifier);
      sqlParameter.Value = (object) id;
      sqlParameterArray[index] = sqlParameter;
      SqlParameter[] parameter = sqlParameterArray;
      return this.dbHelper.Execute(sql, parameter, false);
    }
  }
}
