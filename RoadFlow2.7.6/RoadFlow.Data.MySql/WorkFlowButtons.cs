// Decompiled with JetBrains decompiler
// Type: RoadFlow.Data.MySql.WorkFlowButtons
// Assembly: RoadFlow.Data.MySql, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 29B652D7-5F6F-4A7D-AD1C-9F2C643FD784
// Assembly location: C:\inetpub\wwwroot\RoadFlowMvc\bin\RoadFlow.Data.MySql.dll

using MySql.Data.MySqlClient;
using RoadFlow.Data.Interface;
using System;
using System.Collections.Generic;

namespace RoadFlow.Data.MySql
{
  public class WorkFlowButtons : IWorkFlowButtons
  {
    private DBHelper dbHelper = new DBHelper();

    public int Add(RoadFlow.Data.Model.WorkFlowButtons model)
    {
      string sql = "INSERT INTO workflowbuttons\r\n\t\t\t\t(ID,Title,Ico,Script,Note,Sort) \r\n\t\t\t\tVALUES(@ID,@Title,@Ico,@Script,@Note,@Sort)";
      MySqlParameter[] mySqlParameterArray = new MySqlParameter[6];
      int index1 = 0;
      MySqlParameter mySqlParameter1 = new MySqlParameter("@ID", MySqlDbType.VarChar, 36);
      mySqlParameter1.Value = (object) model.ID;
      mySqlParameterArray[index1] = mySqlParameter1;
      int index2 = 1;
      MySqlParameter mySqlParameter2 = new MySqlParameter("@Title", MySqlDbType.Text, -1);
      mySqlParameter2.Value = (object) model.Title;
      mySqlParameterArray[index2] = mySqlParameter2;
      int index3 = 2;
      MySqlParameter mySqlParameter3;
      if (model.Ico != null)
      {
        MySqlParameter mySqlParameter4 = new MySqlParameter("@Ico", MySqlDbType.Text, -1);
        mySqlParameter4.Value = (object) model.Ico;
        mySqlParameter3 = mySqlParameter4;
      }
      else
      {
        mySqlParameter3 = new MySqlParameter("@Ico", MySqlDbType.Text, -1);
        mySqlParameter3.Value = (object) DBNull.Value;
      }
      mySqlParameterArray[index3] = mySqlParameter3;
      int index4 = 3;
      MySqlParameter mySqlParameter5;
      if (model.Script != null)
      {
        MySqlParameter mySqlParameter4 = new MySqlParameter("@Script", MySqlDbType.LongText, -1);
        mySqlParameter4.Value = (object) model.Script;
        mySqlParameter5 = mySqlParameter4;
      }
      else
      {
        mySqlParameter5 = new MySqlParameter("@Script", MySqlDbType.LongText, -1);
        mySqlParameter5.Value = (object) DBNull.Value;
      }
      mySqlParameterArray[index4] = mySqlParameter5;
      int index5 = 4;
      MySqlParameter mySqlParameter6;
      if (model.Note != null)
      {
        MySqlParameter mySqlParameter4 = new MySqlParameter("@Note", MySqlDbType.LongText, -1);
        mySqlParameter4.Value = (object) model.Note;
        mySqlParameter6 = mySqlParameter4;
      }
      else
      {
        mySqlParameter6 = new MySqlParameter("@Note", MySqlDbType.LongText, -1);
        mySqlParameter6.Value = (object) DBNull.Value;
      }
      mySqlParameterArray[index5] = mySqlParameter6;
      int index6 = 5;
      MySqlParameter mySqlParameter7 = new MySqlParameter("@Sort", MySqlDbType.Int32, 11);
      mySqlParameter7.Value = (object) model.Sort;
      mySqlParameterArray[index6] = mySqlParameter7;
      MySqlParameter[] parameter = mySqlParameterArray;
      return this.dbHelper.Execute(sql, parameter, false);
    }

    public int Update(RoadFlow.Data.Model.WorkFlowButtons model)
    {
      string sql = "UPDATE workflowbuttons SET \r\n\t\t\t\tTitle=@Title,Ico=@Ico,Script=@Script,Note=@Note,Sort=@Sort\r\n\t\t\t\tWHERE ID=@ID";
      MySqlParameter[] mySqlParameterArray = new MySqlParameter[6];
      int index1 = 0;
      MySqlParameter mySqlParameter1 = new MySqlParameter("@Title", MySqlDbType.Text, -1);
      mySqlParameter1.Value = (object) model.Title;
      mySqlParameterArray[index1] = mySqlParameter1;
      int index2 = 1;
      MySqlParameter mySqlParameter2;
      if (model.Ico != null)
      {
        MySqlParameter mySqlParameter3 = new MySqlParameter("@Ico", MySqlDbType.Text, -1);
        mySqlParameter3.Value = (object) model.Ico;
        mySqlParameter2 = mySqlParameter3;
      }
      else
      {
        mySqlParameter2 = new MySqlParameter("@Ico", MySqlDbType.Text, -1);
        mySqlParameter2.Value = (object) DBNull.Value;
      }
      mySqlParameterArray[index2] = mySqlParameter2;
      int index3 = 2;
      MySqlParameter mySqlParameter4;
      if (model.Script != null)
      {
        MySqlParameter mySqlParameter3 = new MySqlParameter("@Script", MySqlDbType.LongText, -1);
        mySqlParameter3.Value = (object) model.Script;
        mySqlParameter4 = mySqlParameter3;
      }
      else
      {
        mySqlParameter4 = new MySqlParameter("@Script", MySqlDbType.LongText, -1);
        mySqlParameter4.Value = (object) DBNull.Value;
      }
      mySqlParameterArray[index3] = mySqlParameter4;
      int index4 = 3;
      MySqlParameter mySqlParameter5;
      if (model.Note != null)
      {
        MySqlParameter mySqlParameter3 = new MySqlParameter("@Note", MySqlDbType.LongText, -1);
        mySqlParameter3.Value = (object) model.Note;
        mySqlParameter5 = mySqlParameter3;
      }
      else
      {
        mySqlParameter5 = new MySqlParameter("@Note", MySqlDbType.LongText, -1);
        mySqlParameter5.Value = (object) DBNull.Value;
      }
      mySqlParameterArray[index4] = mySqlParameter5;
      int index5 = 4;
      MySqlParameter mySqlParameter6 = new MySqlParameter("@Sort", MySqlDbType.Int32, 11);
      mySqlParameter6.Value = (object) model.Sort;
      mySqlParameterArray[index5] = mySqlParameter6;
      int index6 = 5;
      MySqlParameter mySqlParameter7 = new MySqlParameter("@ID", MySqlDbType.VarChar, 36);
      mySqlParameter7.Value = (object) model.ID;
      mySqlParameterArray[index6] = mySqlParameter7;
      MySqlParameter[] parameter = mySqlParameterArray;
      return this.dbHelper.Execute(sql, parameter, false);
    }

    public int Delete(Guid id)
    {
      string sql = "DELETE FROM workflowbuttons WHERE ID=@ID";
      MySqlParameter[] mySqlParameterArray = new MySqlParameter[1];
      int index = 0;
      MySqlParameter mySqlParameter = new MySqlParameter("@ID", MySqlDbType.VarChar, 36);
      mySqlParameter.Value = (object) id.ToString();
      mySqlParameterArray[index] = mySqlParameter;
      MySqlParameter[] parameter = mySqlParameterArray;
      return this.dbHelper.Execute(sql, parameter, false);
    }

    private List<RoadFlow.Data.Model.WorkFlowButtons> DataReaderToList(MySqlDataReader dataReader)
    {
      List<RoadFlow.Data.Model.WorkFlowButtons> workFlowButtonsList = new List<RoadFlow.Data.Model.WorkFlowButtons>();
      while (dataReader.Read())
      {
        RoadFlow.Data.Model.WorkFlowButtons workFlowButtons = new RoadFlow.Data.Model.WorkFlowButtons();
        workFlowButtons.ID = dataReader.GetString(0).ToGuid();
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
      MySqlDataReader dataReader = this.dbHelper.GetDataReader("SELECT * FROM workflowbuttons");
      List<RoadFlow.Data.Model.WorkFlowButtons> list = this.DataReaderToList(dataReader);
      dataReader.Close();
      return list;
    }

    public long GetCount()
    {
      long result;
      if (!long.TryParse(this.dbHelper.GetFieldValue("SELECT COUNT(*) FROM workflowbuttons"), out result))
        return 0;
      return result;
    }

    public RoadFlow.Data.Model.WorkFlowButtons Get(Guid id)
    {
      string sql = "SELECT * FROM workflowbuttons WHERE ID=@ID";
      MySqlParameter[] mySqlParameterArray = new MySqlParameter[1];
      int index = 0;
      MySqlParameter mySqlParameter = new MySqlParameter("@ID", MySqlDbType.VarChar, 36);
      mySqlParameter.Value = (object) id.ToString();
      mySqlParameterArray[index] = mySqlParameter;
      MySqlParameter[] parameter = mySqlParameterArray;
      MySqlDataReader dataReader = this.dbHelper.GetDataReader(sql, parameter);
      List<RoadFlow.Data.Model.WorkFlowButtons> list = this.DataReaderToList(dataReader);
      dataReader.Close();
      if (list.Count <= 0)
        return (RoadFlow.Data.Model.WorkFlowButtons) null;
      return list[0];
    }

    public int GetMaxSort()
    {
      string fieldValue = this.dbHelper.GetFieldValue("SELECT IFNULL(MAX(Sort),0)+1 FROM WorkFlowButtons");
      if (!fieldValue.IsInt())
        return 1;
      return fieldValue.ToInt();
    }
  }
}
