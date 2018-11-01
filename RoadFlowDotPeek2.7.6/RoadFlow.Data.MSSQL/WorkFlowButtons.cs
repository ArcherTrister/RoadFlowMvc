// Decompiled with JetBrains decompiler
// Type: RoadFlow.Data.MSSQL.WorkFlowButtons
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
  public class WorkFlowButtons : IWorkFlowButtons
  {
    private DBHelper dbHelper = new DBHelper();

    public int Add(RoadFlow.Data.Model.WorkFlowButtons model)
    {
      string sql = "INSERT INTO WorkFlowButtons\r\n\t\t\t\t(ID,Title,Ico,Script,Note,Sort) \r\n\t\t\t\tVALUES(@ID,@Title,@Ico,@Script,@Note,@Sort)";
      SqlParameter[] sqlParameterArray = new SqlParameter[6];
      int index1 = 0;
      SqlParameter sqlParameter1 = new SqlParameter("@ID", SqlDbType.UniqueIdentifier, -1);
      sqlParameter1.Value = (object) model.ID;
      sqlParameterArray[index1] = sqlParameter1;
      int index2 = 1;
      SqlParameter sqlParameter2 = new SqlParameter("@Title", SqlDbType.NVarChar, 1000);
      sqlParameter2.Value = (object) model.Title;
      sqlParameterArray[index2] = sqlParameter2;
      int index3 = 2;
      SqlParameter sqlParameter3;
      if (model.Ico != null)
      {
        SqlParameter sqlParameter4 = new SqlParameter("@Ico", SqlDbType.VarChar, 500);
        sqlParameter4.Value = (object) model.Ico;
        sqlParameter3 = sqlParameter4;
      }
      else
      {
        sqlParameter3 = new SqlParameter("@Ico", SqlDbType.VarChar, 500);
        sqlParameter3.Value = (object) DBNull.Value;
      }
      sqlParameterArray[index3] = sqlParameter3;
      int index4 = 3;
      SqlParameter sqlParameter5;
      if (model.Script != null)
      {
        SqlParameter sqlParameter4 = new SqlParameter("@Script", SqlDbType.VarChar, -1);
        sqlParameter4.Value = (object) model.Script;
        sqlParameter5 = sqlParameter4;
      }
      else
      {
        sqlParameter5 = new SqlParameter("@Script", SqlDbType.VarChar, -1);
        sqlParameter5.Value = (object) DBNull.Value;
      }
      sqlParameterArray[index4] = sqlParameter5;
      int index5 = 4;
      SqlParameter sqlParameter6;
      if (model.Note != null)
      {
        SqlParameter sqlParameter4 = new SqlParameter("@Note", SqlDbType.VarChar, -1);
        sqlParameter4.Value = (object) model.Note;
        sqlParameter6 = sqlParameter4;
      }
      else
      {
        sqlParameter6 = new SqlParameter("@Note", SqlDbType.VarChar, -1);
        sqlParameter6.Value = (object) DBNull.Value;
      }
      sqlParameterArray[index5] = sqlParameter6;
      int index6 = 5;
      SqlParameter sqlParameter7 = new SqlParameter("@Sort", SqlDbType.Int, -1);
      sqlParameter7.Value = (object) model.Sort;
      sqlParameterArray[index6] = sqlParameter7;
      SqlParameter[] parameter = sqlParameterArray;
      return this.dbHelper.Execute(sql, parameter, false);
    }

    public int Update(RoadFlow.Data.Model.WorkFlowButtons model)
    {
      string sql = "UPDATE WorkFlowButtons SET \r\n\t\t\t\tTitle=@Title,Ico=@Ico,Script=@Script,Note=@Note,Sort=@Sort\r\n\t\t\t\tWHERE ID=@ID";
      SqlParameter[] sqlParameterArray = new SqlParameter[6];
      int index1 = 0;
      SqlParameter sqlParameter1 = new SqlParameter("@Title", SqlDbType.NVarChar, 1000);
      sqlParameter1.Value = (object) model.Title;
      sqlParameterArray[index1] = sqlParameter1;
      int index2 = 1;
      SqlParameter sqlParameter2;
      if (model.Ico != null)
      {
        SqlParameter sqlParameter3 = new SqlParameter("@Ico", SqlDbType.VarChar, 500);
        sqlParameter3.Value = (object) model.Ico;
        sqlParameter2 = sqlParameter3;
      }
      else
      {
        sqlParameter2 = new SqlParameter("@Ico", SqlDbType.VarChar, 500);
        sqlParameter2.Value = (object) DBNull.Value;
      }
      sqlParameterArray[index2] = sqlParameter2;
      int index3 = 2;
      SqlParameter sqlParameter4;
      if (model.Script != null)
      {
        SqlParameter sqlParameter3 = new SqlParameter("@Script", SqlDbType.VarChar, -1);
        sqlParameter3.Value = (object) model.Script;
        sqlParameter4 = sqlParameter3;
      }
      else
      {
        sqlParameter4 = new SqlParameter("@Script", SqlDbType.VarChar, -1);
        sqlParameter4.Value = (object) DBNull.Value;
      }
      sqlParameterArray[index3] = sqlParameter4;
      int index4 = 3;
      SqlParameter sqlParameter5;
      if (model.Note != null)
      {
        SqlParameter sqlParameter3 = new SqlParameter("@Note", SqlDbType.VarChar, -1);
        sqlParameter3.Value = (object) model.Note;
        sqlParameter5 = sqlParameter3;
      }
      else
      {
        sqlParameter5 = new SqlParameter("@Note", SqlDbType.VarChar, -1);
        sqlParameter5.Value = (object) DBNull.Value;
      }
      sqlParameterArray[index4] = sqlParameter5;
      int index5 = 4;
      SqlParameter sqlParameter6 = new SqlParameter("@Sort", SqlDbType.Int, -1);
      sqlParameter6.Value = (object) model.Sort;
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
      string sql = "DELETE FROM WorkFlowButtons WHERE ID=@ID";
      SqlParameter[] sqlParameterArray = new SqlParameter[1];
      int index = 0;
      SqlParameter sqlParameter = new SqlParameter("@ID", SqlDbType.UniqueIdentifier);
      sqlParameter.Value = (object) id;
      sqlParameterArray[index] = sqlParameter;
      SqlParameter[] parameter = sqlParameterArray;
      return this.dbHelper.Execute(sql, parameter, false);
    }

    private List<RoadFlow.Data.Model.WorkFlowButtons> DataReaderToList(SqlDataReader dataReader)
    {
      List<RoadFlow.Data.Model.WorkFlowButtons> workFlowButtonsList = new List<RoadFlow.Data.Model.WorkFlowButtons>();
      while (dataReader.Read())
      {
        RoadFlow.Data.Model.WorkFlowButtons workFlowButtons = new RoadFlow.Data.Model.WorkFlowButtons();
        workFlowButtons.ID = dataReader.GetGuid(0);
        workFlowButtons.Title = dataReader.GetString(1);
        if (!dataReader.IsDBNull(2))
          workFlowButtons.Ico = dataReader.GetString(2);
        if (!dataReader.IsDBNull(3))
          workFlowButtons.Script = dataReader.GetString(3);
        if (!dataReader.IsDBNull(4))
          workFlowButtons.Note = dataReader.GetString(4);
        workFlowButtons.Sort = dataReader.GetInt32(5);
        workFlowButtonsList.Add(workFlowButtons);
      }
      return workFlowButtonsList;
    }

    public List<RoadFlow.Data.Model.WorkFlowButtons> GetAll()
    {
      SqlDataReader dataReader = this.dbHelper.GetDataReader("SELECT * FROM WorkFlowButtons");
      List<RoadFlow.Data.Model.WorkFlowButtons> list = this.DataReaderToList(dataReader);
      dataReader.Close();
      return list;
    }

    public long GetCount()
    {
      long result;
      if (!long.TryParse(this.dbHelper.GetFieldValue("SELECT COUNT(*) FROM WorkFlowButtons"), out result))
        return 0;
      return result;
    }

    public RoadFlow.Data.Model.WorkFlowButtons Get(Guid id)
    {
      string sql = "SELECT * FROM WorkFlowButtons WHERE ID=@ID";
      SqlParameter[] sqlParameterArray = new SqlParameter[1];
      int index = 0;
      SqlParameter sqlParameter = new SqlParameter("@ID", SqlDbType.UniqueIdentifier);
      sqlParameter.Value = (object) id;
      sqlParameterArray[index] = sqlParameter;
      SqlParameter[] parameter = sqlParameterArray;
      SqlDataReader dataReader = this.dbHelper.GetDataReader(sql, parameter);
      List<RoadFlow.Data.Model.WorkFlowButtons> list = this.DataReaderToList(dataReader);
      dataReader.Close();
      if (list.Count <= 0)
        return (RoadFlow.Data.Model.WorkFlowButtons) null;
      return list[0];
    }

    public int GetMaxSort()
    {
      string fieldValue = this.dbHelper.GetFieldValue("SELECT ISNULL(MAX(Sort),0)+1 FROM WorkFlowButtons");
      if (!fieldValue.IsInt())
        return 1;
      return fieldValue.ToInt();
    }
  }
}
