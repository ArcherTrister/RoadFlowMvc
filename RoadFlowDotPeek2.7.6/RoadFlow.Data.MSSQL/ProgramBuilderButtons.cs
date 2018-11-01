// Decompiled with JetBrains decompiler
// Type: RoadFlow.Data.MSSQL.ProgramBuilderButtons
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
  public class ProgramBuilderButtons : IProgramBuilderButtons
  {
    private DBHelper dbHelper = new DBHelper();

    public int Add(RoadFlow.Data.Model.ProgramBuilderButtons model)
    {
      string sql = "INSERT INTO ProgramBuilderButtons\r\n\t\t\t\t(ID,ProgramID,ButtonID,ButtonName,ClientScript,Ico,ShowType,Sort,IsValidateShow) \r\n\t\t\t\tVALUES(@ID,@ProgramID,@ButtonID,@ButtonName,@ClientScript,@Ico,@ShowType,@Sort,@IsValidateShow)";
      SqlParameter[] sqlParameterArray = new SqlParameter[9];
      int index1 = 0;
      SqlParameter sqlParameter1 = new SqlParameter("@ID", SqlDbType.UniqueIdentifier, -1);
      sqlParameter1.Value = (object) model.ID;
      sqlParameterArray[index1] = sqlParameter1;
      int index2 = 1;
      SqlParameter sqlParameter2 = new SqlParameter("@ProgramID", SqlDbType.UniqueIdentifier, -1);
      sqlParameter2.Value = (object) model.ProgramID;
      sqlParameterArray[index2] = sqlParameter2;
      int index3 = 2;
      SqlParameter sqlParameter3;
      if (model.ButtonID.HasValue)
      {
        SqlParameter sqlParameter4 = new SqlParameter("@ButtonID", SqlDbType.UniqueIdentifier, -1);
        sqlParameter4.Value = (object) model.ButtonID;
        sqlParameter3 = sqlParameter4;
      }
      else
      {
        sqlParameter3 = new SqlParameter("@ButtonID", SqlDbType.UniqueIdentifier, -1);
        sqlParameter3.Value = (object) DBNull.Value;
      }
      sqlParameterArray[index3] = sqlParameter3;
      int index4 = 3;
      SqlParameter sqlParameter5 = new SqlParameter("@ButtonName", SqlDbType.NVarChar, 400);
      sqlParameter5.Value = (object) model.ButtonName;
      sqlParameterArray[index4] = sqlParameter5;
      int index5 = 4;
      SqlParameter sqlParameter6;
      if (model.ClientScript != null)
      {
        SqlParameter sqlParameter4 = new SqlParameter("@ClientScript", SqlDbType.VarChar, -1);
        sqlParameter4.Value = (object) model.ClientScript;
        sqlParameter6 = sqlParameter4;
      }
      else
      {
        sqlParameter6 = new SqlParameter("@ClientScript", SqlDbType.VarChar, -1);
        sqlParameter6.Value = (object) DBNull.Value;
      }
      sqlParameterArray[index5] = sqlParameter6;
      int index6 = 5;
      SqlParameter sqlParameter7;
      if (model.Ico != null)
      {
        SqlParameter sqlParameter4 = new SqlParameter("@Ico", SqlDbType.VarChar, 500);
        sqlParameter4.Value = (object) model.Ico;
        sqlParameter7 = sqlParameter4;
      }
      else
      {
        sqlParameter7 = new SqlParameter("@Ico", SqlDbType.VarChar, 500);
        sqlParameter7.Value = (object) DBNull.Value;
      }
      sqlParameterArray[index6] = sqlParameter7;
      int index7 = 6;
      SqlParameter sqlParameter8 = new SqlParameter("@ShowType", SqlDbType.Int, -1);
      sqlParameter8.Value = (object) model.ShowType;
      sqlParameterArray[index7] = sqlParameter8;
      int index8 = 7;
      SqlParameter sqlParameter9 = new SqlParameter("@Sort", SqlDbType.Int, -1);
      sqlParameter9.Value = (object) model.Sort;
      sqlParameterArray[index8] = sqlParameter9;
      int index9 = 8;
      SqlParameter sqlParameter10 = new SqlParameter("@IsValidateShow", SqlDbType.Int, -1);
      sqlParameter10.Value = (object) model.IsValidateShow;
      sqlParameterArray[index9] = sqlParameter10;
      SqlParameter[] parameter = sqlParameterArray;
      return this.dbHelper.Execute(sql, parameter, false);
    }

    public int Update(RoadFlow.Data.Model.ProgramBuilderButtons model)
    {
      string sql = "UPDATE ProgramBuilderButtons SET \r\n\t\t\t\tProgramID=@ProgramID,ButtonID=@ButtonID,ButtonName=@ButtonName,ClientScript=@ClientScript,Ico=@Ico,ShowType=@ShowType,Sort=@Sort,IsValidateShow=@IsValidateShow\r\n\t\t\t\tWHERE ID=@ID";
      SqlParameter[] sqlParameterArray = new SqlParameter[9];
      int index1 = 0;
      SqlParameter sqlParameter1 = new SqlParameter("@ProgramID", SqlDbType.UniqueIdentifier, -1);
      sqlParameter1.Value = (object) model.ProgramID;
      sqlParameterArray[index1] = sqlParameter1;
      int index2 = 1;
      SqlParameter sqlParameter2;
      if (model.ButtonID.HasValue)
      {
        SqlParameter sqlParameter3 = new SqlParameter("@ButtonID", SqlDbType.UniqueIdentifier, -1);
        sqlParameter3.Value = (object) model.ButtonID;
        sqlParameter2 = sqlParameter3;
      }
      else
      {
        sqlParameter2 = new SqlParameter("@ButtonID", SqlDbType.UniqueIdentifier, -1);
        sqlParameter2.Value = (object) DBNull.Value;
      }
      sqlParameterArray[index2] = sqlParameter2;
      int index3 = 2;
      SqlParameter sqlParameter4 = new SqlParameter("@ButtonName", SqlDbType.NVarChar, 400);
      sqlParameter4.Value = (object) model.ButtonName;
      sqlParameterArray[index3] = sqlParameter4;
      int index4 = 3;
      SqlParameter sqlParameter5;
      if (model.ClientScript != null)
      {
        SqlParameter sqlParameter3 = new SqlParameter("@ClientScript", SqlDbType.VarChar, -1);
        sqlParameter3.Value = (object) model.ClientScript;
        sqlParameter5 = sqlParameter3;
      }
      else
      {
        sqlParameter5 = new SqlParameter("@ClientScript", SqlDbType.VarChar, -1);
        sqlParameter5.Value = (object) DBNull.Value;
      }
      sqlParameterArray[index4] = sqlParameter5;
      int index5 = 4;
      SqlParameter sqlParameter6;
      if (model.Ico != null)
      {
        SqlParameter sqlParameter3 = new SqlParameter("@Ico", SqlDbType.VarChar, 500);
        sqlParameter3.Value = (object) model.Ico;
        sqlParameter6 = sqlParameter3;
      }
      else
      {
        sqlParameter6 = new SqlParameter("@Ico", SqlDbType.VarChar, 500);
        sqlParameter6.Value = (object) DBNull.Value;
      }
      sqlParameterArray[index5] = sqlParameter6;
      int index6 = 5;
      SqlParameter sqlParameter7 = new SqlParameter("@ShowType", SqlDbType.Int, -1);
      sqlParameter7.Value = (object) model.ShowType;
      sqlParameterArray[index6] = sqlParameter7;
      int index7 = 6;
      SqlParameter sqlParameter8 = new SqlParameter("@Sort", SqlDbType.Int, -1);
      sqlParameter8.Value = (object) model.Sort;
      sqlParameterArray[index7] = sqlParameter8;
      int index8 = 7;
      SqlParameter sqlParameter9 = new SqlParameter("@IsValidateShow", SqlDbType.Int, -1);
      sqlParameter9.Value = (object) model.IsValidateShow;
      sqlParameterArray[index8] = sqlParameter9;
      int index9 = 8;
      SqlParameter sqlParameter10 = new SqlParameter("@ID", SqlDbType.UniqueIdentifier, -1);
      sqlParameter10.Value = (object) model.ID;
      sqlParameterArray[index9] = sqlParameter10;
      SqlParameter[] parameter = sqlParameterArray;
      return this.dbHelper.Execute(sql, parameter, false);
    }

    public int Delete(Guid id)
    {
      string sql = "DELETE FROM ProgramBuilderButtons WHERE ID=@ID";
      SqlParameter[] sqlParameterArray = new SqlParameter[1];
      int index = 0;
      SqlParameter sqlParameter = new SqlParameter("@ID", SqlDbType.UniqueIdentifier);
      sqlParameter.Value = (object) id;
      sqlParameterArray[index] = sqlParameter;
      SqlParameter[] parameter = sqlParameterArray;
      return this.dbHelper.Execute(sql, parameter, false);
    }

    private List<RoadFlow.Data.Model.ProgramBuilderButtons> DataReaderToList(SqlDataReader dataReader)
    {
      List<RoadFlow.Data.Model.ProgramBuilderButtons> programBuilderButtonsList = new List<RoadFlow.Data.Model.ProgramBuilderButtons>();
      while (dataReader.Read())
      {
        RoadFlow.Data.Model.ProgramBuilderButtons programBuilderButtons = new RoadFlow.Data.Model.ProgramBuilderButtons();
        programBuilderButtons.ID = dataReader.GetGuid(0);
        programBuilderButtons.ProgramID = dataReader.GetGuid(1);
        if (!dataReader.IsDBNull(2))
          programBuilderButtons.ButtonID = new Guid?(dataReader.GetGuid(2));
        programBuilderButtons.ButtonName = dataReader.GetString(3);
        if (!dataReader.IsDBNull(4))
          programBuilderButtons.ClientScript = dataReader.GetString(4);
        if (!dataReader.IsDBNull(5))
          programBuilderButtons.Ico = dataReader.GetString(5);
        programBuilderButtons.ShowType = dataReader.GetInt32(6);
        programBuilderButtons.Sort = dataReader.GetInt32(7);
        programBuilderButtons.IsValidateShow = dataReader.GetInt32(8);
        programBuilderButtonsList.Add(programBuilderButtons);
      }
      return programBuilderButtonsList;
    }

    public List<RoadFlow.Data.Model.ProgramBuilderButtons> GetAll()
    {
      SqlDataReader dataReader = this.dbHelper.GetDataReader("SELECT * FROM ProgramBuilderButtons");
      List<RoadFlow.Data.Model.ProgramBuilderButtons> list = this.DataReaderToList(dataReader);
      dataReader.Close();
      return list;
    }

    public long GetCount()
    {
      long result;
      if (!long.TryParse(this.dbHelper.GetFieldValue("SELECT COUNT(*) FROM ProgramBuilderButtons"), out result))
        return 0;
      return result;
    }

    public RoadFlow.Data.Model.ProgramBuilderButtons Get(Guid id)
    {
      string sql = "SELECT * FROM ProgramBuilderButtons WHERE ID=@ID";
      SqlParameter[] sqlParameterArray = new SqlParameter[1];
      int index = 0;
      SqlParameter sqlParameter = new SqlParameter("@ID", SqlDbType.UniqueIdentifier);
      sqlParameter.Value = (object) id;
      sqlParameterArray[index] = sqlParameter;
      SqlParameter[] parameter = sqlParameterArray;
      SqlDataReader dataReader = this.dbHelper.GetDataReader(sql, parameter);
      List<RoadFlow.Data.Model.ProgramBuilderButtons> list = this.DataReaderToList(dataReader);
      dataReader.Close();
      if (list.Count <= 0)
        return (RoadFlow.Data.Model.ProgramBuilderButtons) null;
      return list[0];
    }

    public List<RoadFlow.Data.Model.ProgramBuilderButtons> GetAll(Guid id)
    {
      string sql = "SELECT * FROM ProgramBuilderButtons WHERE ProgramID=@ProgramID";
      SqlParameter[] sqlParameterArray = new SqlParameter[1];
      int index = 0;
      SqlParameter sqlParameter = new SqlParameter("@ProgramID", SqlDbType.UniqueIdentifier);
      sqlParameter.Value = (object) id;
      sqlParameterArray[index] = sqlParameter;
      SqlParameter[] parameter = sqlParameterArray;
      SqlDataReader dataReader = this.dbHelper.GetDataReader(sql, parameter);
      List<RoadFlow.Data.Model.ProgramBuilderButtons> list = this.DataReaderToList(dataReader);
      dataReader.Close();
      return list;
    }
  }
}
