// Decompiled with JetBrains decompiler
// Type: RoadFlow.Data.MySql.ProgramBuilderButtons
// Assembly: RoadFlow.Data.MySql, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 29B652D7-5F6F-4A7D-AD1C-9F2C643FD784
// Assembly location: C:\inetpub\wwwroot\RoadFlowMvc\bin\RoadFlow.Data.MySql.dll

using MySql.Data.MySqlClient;
using RoadFlow.Data.Interface;
using System;
using System.Collections.Generic;

namespace RoadFlow.Data.MySql
{
  public class ProgramBuilderButtons : IProgramBuilderButtons
  {
    private DBHelper dbHelper = new DBHelper();

    public int Add(RoadFlow.Data.Model.ProgramBuilderButtons model)
    {
      string sql = "INSERT INTO programbuilderbuttons\r\n\t\t\t\t(ID,ProgramID,ButtonID,ButtonName,ClientScript,Ico,ShowType,Sort,IsValidateShow) \r\n\t\t\t\tVALUES(@ID,@ProgramID,@ButtonID,@ButtonName,@ClientScript,@Ico,@ShowType,@Sort,@IsValidateShow)";
      MySqlParameter[] mySqlParameterArray = new MySqlParameter[9];
      int index1 = 0;
      MySqlParameter mySqlParameter1 = new MySqlParameter("@ID", MySqlDbType.VarChar, 36);
      mySqlParameter1.Value = (object) model.ID;
      mySqlParameterArray[index1] = mySqlParameter1;
      int index2 = 1;
      MySqlParameter mySqlParameter2 = new MySqlParameter("@ProgramID", MySqlDbType.VarChar, 36);
      mySqlParameter2.Value = (object) model.ProgramID;
      mySqlParameterArray[index2] = mySqlParameter2;
      int index3 = 2;
      MySqlParameter mySqlParameter3;
      if (model.ButtonID.HasValue)
      {
        MySqlParameter mySqlParameter4 = new MySqlParameter("@ButtonID", MySqlDbType.VarChar, 36);
        mySqlParameter4.Value = (object) model.ButtonID;
        mySqlParameter3 = mySqlParameter4;
      }
      else
      {
        mySqlParameter3 = new MySqlParameter("@ButtonID", MySqlDbType.VarChar, 36);
        mySqlParameter3.Value = (object) DBNull.Value;
      }
      mySqlParameterArray[index3] = mySqlParameter3;
      int index4 = 3;
      MySqlParameter mySqlParameter5 = new MySqlParameter("@ButtonName", MySqlDbType.VarChar, 200);
      mySqlParameter5.Value = (object) model.ButtonName;
      mySqlParameterArray[index4] = mySqlParameter5;
      int index5 = 4;
      MySqlParameter mySqlParameter6;
      if (model.ClientScript != null)
      {
        MySqlParameter mySqlParameter4 = new MySqlParameter("@ClientScript", MySqlDbType.LongText, -1);
        mySqlParameter4.Value = (object) model.ClientScript;
        mySqlParameter6 = mySqlParameter4;
      }
      else
      {
        mySqlParameter6 = new MySqlParameter("@ClientScript", MySqlDbType.LongText, -1);
        mySqlParameter6.Value = (object) DBNull.Value;
      }
      mySqlParameterArray[index5] = mySqlParameter6;
      int index6 = 5;
      MySqlParameter mySqlParameter7;
      if (model.Ico != null)
      {
        MySqlParameter mySqlParameter4 = new MySqlParameter("@Ico", MySqlDbType.Text, -1);
        mySqlParameter4.Value = (object) model.Ico;
        mySqlParameter7 = mySqlParameter4;
      }
      else
      {
        mySqlParameter7 = new MySqlParameter("@Ico", MySqlDbType.Text, -1);
        mySqlParameter7.Value = (object) DBNull.Value;
      }
      mySqlParameterArray[index6] = mySqlParameter7;
      int index7 = 6;
      MySqlParameter mySqlParameter8 = new MySqlParameter("@ShowType", MySqlDbType.Int32, 11);
      mySqlParameter8.Value = (object) model.ShowType;
      mySqlParameterArray[index7] = mySqlParameter8;
      int index8 = 7;
      MySqlParameter mySqlParameter9 = new MySqlParameter("@Sort", MySqlDbType.Int32, 11);
      mySqlParameter9.Value = (object) model.Sort;
      mySqlParameterArray[index8] = mySqlParameter9;
      int index9 = 8;
      MySqlParameter mySqlParameter10 = new MySqlParameter("@IsValidateShow", MySqlDbType.Int32, 11);
      mySqlParameter10.Value = (object) model.IsValidateShow;
      mySqlParameterArray[index9] = mySqlParameter10;
      MySqlParameter[] parameter = mySqlParameterArray;
      return this.dbHelper.Execute(sql, parameter, false);
    }

    public int Update(RoadFlow.Data.Model.ProgramBuilderButtons model)
    {
      string sql = "UPDATE programbuilderbuttons SET \r\n\t\t\t\tProgramID=@ProgramID,ButtonID=@ButtonID,ButtonName=@ButtonName,ClientScript=@ClientScript,Ico=@Ico,ShowType=@ShowType,Sort=@Sort,IsValidateShow=@IsValidateShow\r\n\t\t\t\tWHERE ID=@ID";
      MySqlParameter[] mySqlParameterArray = new MySqlParameter[9];
      int index1 = 0;
      MySqlParameter mySqlParameter1 = new MySqlParameter("@ProgramID", MySqlDbType.VarChar, 36);
      mySqlParameter1.Value = (object) model.ProgramID;
      mySqlParameterArray[index1] = mySqlParameter1;
      int index2 = 1;
      MySqlParameter mySqlParameter2;
      if (model.ButtonID.HasValue)
      {
        MySqlParameter mySqlParameter3 = new MySqlParameter("@ButtonID", MySqlDbType.VarChar, 36);
        mySqlParameter3.Value = (object) model.ButtonID;
        mySqlParameter2 = mySqlParameter3;
      }
      else
      {
        mySqlParameter2 = new MySqlParameter("@ButtonID", MySqlDbType.VarChar, 36);
        mySqlParameter2.Value = (object) DBNull.Value;
      }
      mySqlParameterArray[index2] = mySqlParameter2;
      int index3 = 2;
      MySqlParameter mySqlParameter4 = new MySqlParameter("@ButtonName", MySqlDbType.VarChar, 200);
      mySqlParameter4.Value = (object) model.ButtonName;
      mySqlParameterArray[index3] = mySqlParameter4;
      int index4 = 3;
      MySqlParameter mySqlParameter5;
      if (model.ClientScript != null)
      {
        MySqlParameter mySqlParameter3 = new MySqlParameter("@ClientScript", MySqlDbType.LongText, -1);
        mySqlParameter3.Value = (object) model.ClientScript;
        mySqlParameter5 = mySqlParameter3;
      }
      else
      {
        mySqlParameter5 = new MySqlParameter("@ClientScript", MySqlDbType.LongText, -1);
        mySqlParameter5.Value = (object) DBNull.Value;
      }
      mySqlParameterArray[index4] = mySqlParameter5;
      int index5 = 4;
      MySqlParameter mySqlParameter6;
      if (model.Ico != null)
      {
        MySqlParameter mySqlParameter3 = new MySqlParameter("@Ico", MySqlDbType.Text, -1);
        mySqlParameter3.Value = (object) model.Ico;
        mySqlParameter6 = mySqlParameter3;
      }
      else
      {
        mySqlParameter6 = new MySqlParameter("@Ico", MySqlDbType.Text, -1);
        mySqlParameter6.Value = (object) DBNull.Value;
      }
      mySqlParameterArray[index5] = mySqlParameter6;
      int index6 = 5;
      MySqlParameter mySqlParameter7 = new MySqlParameter("@ShowType", MySqlDbType.Int32, 11);
      mySqlParameter7.Value = (object) model.ShowType;
      mySqlParameterArray[index6] = mySqlParameter7;
      int index7 = 6;
      MySqlParameter mySqlParameter8 = new MySqlParameter("@Sort", MySqlDbType.Int32, 11);
      mySqlParameter8.Value = (object) model.Sort;
      mySqlParameterArray[index7] = mySqlParameter8;
      int index8 = 7;
      MySqlParameter mySqlParameter9 = new MySqlParameter("@IsValidateShow", MySqlDbType.Int32, 11);
      mySqlParameter9.Value = (object) model.IsValidateShow;
      mySqlParameterArray[index8] = mySqlParameter9;
      int index9 = 8;
      MySqlParameter mySqlParameter10 = new MySqlParameter("@ID", MySqlDbType.VarChar, 36);
      mySqlParameter10.Value = (object) model.ID;
      mySqlParameterArray[index9] = mySqlParameter10;
      MySqlParameter[] parameter = mySqlParameterArray;
      return this.dbHelper.Execute(sql, parameter, false);
    }

    public int Delete(Guid id)
    {
      string sql = "DELETE FROM programbuilderbuttons WHERE ID=@ID";
      MySqlParameter[] mySqlParameterArray = new MySqlParameter[1];
      int index = 0;
      MySqlParameter mySqlParameter = new MySqlParameter("@ID", MySqlDbType.VarChar, 36);
      mySqlParameter.Value = (object) id.ToString();
      mySqlParameterArray[index] = mySqlParameter;
      MySqlParameter[] parameter = mySqlParameterArray;
      return this.dbHelper.Execute(sql, parameter, false);
    }

    private List<RoadFlow.Data.Model.ProgramBuilderButtons> DataReaderToList(MySqlDataReader dataReader)
    {
      List<RoadFlow.Data.Model.ProgramBuilderButtons> programBuilderButtonsList = new List<RoadFlow.Data.Model.ProgramBuilderButtons>();
      while (dataReader.Read())
      {
        RoadFlow.Data.Model.ProgramBuilderButtons programBuilderButtons = new RoadFlow.Data.Model.ProgramBuilderButtons();
        programBuilderButtons.ID = dataReader.GetString(0).ToGuid();
        programBuilderButtons.ProgramID = dataReader.GetString(1).ToGuid();
        if (!dataReader.IsDBNull(2))
          programBuilderButtons.ButtonID = new Guid?(dataReader.GetString(2).ToGuid());
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
      MySqlDataReader dataReader = this.dbHelper.GetDataReader("SELECT * FROM programbuilderbuttons");
      List<RoadFlow.Data.Model.ProgramBuilderButtons> list = this.DataReaderToList(dataReader);
      dataReader.Close();
      return list;
    }

    public long GetCount()
    {
      long result;
      if (!long.TryParse(this.dbHelper.GetFieldValue("SELECT COUNT(*) FROM programbuilderbuttons"), out result))
        return 0;
      return result;
    }

    public RoadFlow.Data.Model.ProgramBuilderButtons Get(Guid id)
    {
      string sql = "SELECT * FROM programbuilderbuttons WHERE ID=@ID";
      MySqlParameter[] mySqlParameterArray = new MySqlParameter[1];
      int index = 0;
      MySqlParameter mySqlParameter = new MySqlParameter("@ID", MySqlDbType.VarChar, 36);
      mySqlParameter.Value = (object) id.ToString();
      mySqlParameterArray[index] = mySqlParameter;
      MySqlParameter[] parameter = mySqlParameterArray;
      MySqlDataReader dataReader = this.dbHelper.GetDataReader(sql, parameter);
      List<RoadFlow.Data.Model.ProgramBuilderButtons> list = this.DataReaderToList(dataReader);
      dataReader.Close();
      if (list.Count <= 0)
        return (RoadFlow.Data.Model.ProgramBuilderButtons) null;
      return list[0];
    }

    public List<RoadFlow.Data.Model.ProgramBuilderButtons> GetAll(Guid id)
    {
      string sql = "SELECT * FROM ProgramBuilderButtons WHERE ProgramID=@ProgramID";
      MySqlParameter[] mySqlParameterArray = new MySqlParameter[1];
      int index = 0;
      MySqlParameter mySqlParameter = new MySqlParameter("@ProgramID", MySqlDbType.VarChar);
      mySqlParameter.Value = (object) id.ToString();
      mySqlParameterArray[index] = mySqlParameter;
      MySqlParameter[] parameter = mySqlParameterArray;
      MySqlDataReader dataReader = this.dbHelper.GetDataReader(sql, parameter);
      List<RoadFlow.Data.Model.ProgramBuilderButtons> list = this.DataReaderToList(dataReader);
      dataReader.Close();
      return list;
    }
  }
}
