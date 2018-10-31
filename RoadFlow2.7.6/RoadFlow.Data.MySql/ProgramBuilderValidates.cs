// Decompiled with JetBrains decompiler
// Type: RoadFlow.Data.MySql.ProgramBuilderValidates
// Assembly: RoadFlow.Data.MySql, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 29B652D7-5F6F-4A7D-AD1C-9F2C643FD784
// Assembly location: C:\inetpub\wwwroot\RoadFlowMvc\bin\RoadFlow.Data.MySql.dll

using MySql.Data.MySqlClient;
using RoadFlow.Data.Interface;
using System;
using System.Collections.Generic;

namespace RoadFlow.Data.MySql
{
  public class ProgramBuilderValidates : IProgramBuilderValidates
  {
    private DBHelper dbHelper = new DBHelper();

    public int Add(RoadFlow.Data.Model.ProgramBuilderValidates model)
    {
      string sql = "INSERT INTO programbuildervalidates\r\n\t\t\t\t(ID,ProgramID,TableName,FieldName,FieldNote,Validate) \r\n\t\t\t\tVALUES(@ID,@ProgramID,@TableName,@FieldName,@FieldNote,@Validate)";
      MySqlParameter[] mySqlParameterArray = new MySqlParameter[6];
      int index1 = 0;
      MySqlParameter mySqlParameter1 = new MySqlParameter("@ID", MySqlDbType.VarChar, 36);
      mySqlParameter1.Value = (object) model.ID;
      mySqlParameterArray[index1] = mySqlParameter1;
      int index2 = 1;
      MySqlParameter mySqlParameter2 = new MySqlParameter("@ProgramID", MySqlDbType.VarChar, 36);
      mySqlParameter2.Value = (object) model.ProgramID;
      mySqlParameterArray[index2] = mySqlParameter2;
      int index3 = 2;
      MySqlParameter mySqlParameter3 = new MySqlParameter("@TableName", MySqlDbType.Text, -1);
      mySqlParameter3.Value = (object) model.TableName;
      mySqlParameterArray[index3] = mySqlParameter3;
      int index4 = 3;
      MySqlParameter mySqlParameter4 = new MySqlParameter("@FieldName", MySqlDbType.Text, -1);
      mySqlParameter4.Value = (object) model.FieldName;
      mySqlParameterArray[index4] = mySqlParameter4;
      int index5 = 4;
      MySqlParameter mySqlParameter5;
      if (model.FieldNote != null)
      {
        MySqlParameter mySqlParameter6 = new MySqlParameter("@FieldNote", MySqlDbType.Text, -1);
        mySqlParameter6.Value = (object) model.FieldNote;
        mySqlParameter5 = mySqlParameter6;
      }
      else
      {
        mySqlParameter5 = new MySqlParameter("@FieldNote", MySqlDbType.Text, -1);
        mySqlParameter5.Value = (object) DBNull.Value;
      }
      mySqlParameterArray[index5] = mySqlParameter5;
      int index6 = 5;
      MySqlParameter mySqlParameter7 = new MySqlParameter("@Validate", MySqlDbType.Int32, 11);
      mySqlParameter7.Value = (object) model.Validate;
      mySqlParameterArray[index6] = mySqlParameter7;
      MySqlParameter[] parameter = mySqlParameterArray;
      return this.dbHelper.Execute(sql, parameter, false);
    }

    public int Update(RoadFlow.Data.Model.ProgramBuilderValidates model)
    {
      string sql = "UPDATE programbuildervalidates SET \r\n\t\t\t\tProgramID=@ProgramID,TableName=@TableName,FieldName=@FieldName,FieldNote=@FieldNote,Validate=@Validate\r\n\t\t\t\tWHERE ID=@ID";
      MySqlParameter[] mySqlParameterArray = new MySqlParameter[6];
      int index1 = 0;
      MySqlParameter mySqlParameter1 = new MySqlParameter("@ProgramID", MySqlDbType.VarChar, 36);
      mySqlParameter1.Value = (object) model.ProgramID;
      mySqlParameterArray[index1] = mySqlParameter1;
      int index2 = 1;
      MySqlParameter mySqlParameter2 = new MySqlParameter("@TableName", MySqlDbType.Text, -1);
      mySqlParameter2.Value = (object) model.TableName;
      mySqlParameterArray[index2] = mySqlParameter2;
      int index3 = 2;
      MySqlParameter mySqlParameter3 = new MySqlParameter("@FieldName", MySqlDbType.Text, -1);
      mySqlParameter3.Value = (object) model.FieldName;
      mySqlParameterArray[index3] = mySqlParameter3;
      int index4 = 3;
      MySqlParameter mySqlParameter4;
      if (model.FieldNote != null)
      {
        MySqlParameter mySqlParameter5 = new MySqlParameter("@FieldNote", MySqlDbType.Text, -1);
        mySqlParameter5.Value = (object) model.FieldNote;
        mySqlParameter4 = mySqlParameter5;
      }
      else
      {
        mySqlParameter4 = new MySqlParameter("@FieldNote", MySqlDbType.Text, -1);
        mySqlParameter4.Value = (object) DBNull.Value;
      }
      mySqlParameterArray[index4] = mySqlParameter4;
      int index5 = 4;
      MySqlParameter mySqlParameter6 = new MySqlParameter("@Validate", MySqlDbType.Int32, 11);
      mySqlParameter6.Value = (object) model.Validate;
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
      string sql = "DELETE FROM programbuildervalidates WHERE ID=@ID";
      MySqlParameter[] mySqlParameterArray = new MySqlParameter[1];
      int index = 0;
      MySqlParameter mySqlParameter = new MySqlParameter("@ID", MySqlDbType.VarChar, 36);
      mySqlParameter.Value = (object) id.ToString();
      mySqlParameterArray[index] = mySqlParameter;
      MySqlParameter[] parameter = mySqlParameterArray;
      return this.dbHelper.Execute(sql, parameter, false);
    }

    private List<RoadFlow.Data.Model.ProgramBuilderValidates> DataReaderToList(MySqlDataReader dataReader)
    {
      List<RoadFlow.Data.Model.ProgramBuilderValidates> builderValidatesList = new List<RoadFlow.Data.Model.ProgramBuilderValidates>();
      while (dataReader.Read())
      {
        RoadFlow.Data.Model.ProgramBuilderValidates builderValidates = new RoadFlow.Data.Model.ProgramBuilderValidates();
        builderValidates.ID = dataReader.GetString(0).ToGuid();
        builderValidates.ProgramID = dataReader.GetString(1).ToGuid();
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
      MySqlDataReader dataReader = this.dbHelper.GetDataReader("SELECT * FROM programbuildervalidates");
      List<RoadFlow.Data.Model.ProgramBuilderValidates> list = this.DataReaderToList(dataReader);
      dataReader.Close();
      return list;
    }

    public long GetCount()
    {
      long result;
      if (!long.TryParse(this.dbHelper.GetFieldValue("SELECT COUNT(*) FROM programbuildervalidates"), out result))
        return 0;
      return result;
    }

    public RoadFlow.Data.Model.ProgramBuilderValidates Get(Guid id)
    {
      string sql = "SELECT * FROM programbuildervalidates WHERE ID=@ID";
      MySqlParameter[] mySqlParameterArray = new MySqlParameter[1];
      int index = 0;
      MySqlParameter mySqlParameter = new MySqlParameter("@ID", MySqlDbType.VarChar, 36);
      mySqlParameter.Value = (object) id.ToString();
      mySqlParameterArray[index] = mySqlParameter;
      MySqlParameter[] parameter = mySqlParameterArray;
      MySqlDataReader dataReader = this.dbHelper.GetDataReader(sql, parameter);
      List<RoadFlow.Data.Model.ProgramBuilderValidates> list = this.DataReaderToList(dataReader);
      dataReader.Close();
      if (list.Count <= 0)
        return (RoadFlow.Data.Model.ProgramBuilderValidates) null;
      return list[0];
    }

    public List<RoadFlow.Data.Model.ProgramBuilderValidates> GetAll(Guid programID)
    {
      string sql = "SELECT * FROM ProgramBuilderValidates WHERE ProgramID=@ProgramID";
      MySqlParameter[] mySqlParameterArray = new MySqlParameter[1];
      int index = 0;
      MySqlParameter mySqlParameter = new MySqlParameter("@ProgramID", MySqlDbType.VarChar);
      mySqlParameter.Value = (object) programID.ToString();
      mySqlParameterArray[index] = mySqlParameter;
      MySqlParameter[] parameter = mySqlParameterArray;
      MySqlDataReader dataReader = this.dbHelper.GetDataReader(sql, parameter);
      List<RoadFlow.Data.Model.ProgramBuilderValidates> list = this.DataReaderToList(dataReader);
      dataReader.Close();
      return list;
    }

    public int DeleteByProgramID(Guid id)
    {
      string sql = "DELETE FROM ProgramBuilderValidates WHERE ProgramID=@ProgramID";
      MySqlParameter[] mySqlParameterArray = new MySqlParameter[1];
      int index = 0;
      MySqlParameter mySqlParameter = new MySqlParameter("@ProgramID", MySqlDbType.VarChar);
      mySqlParameter.Value = (object) id.ToString();
      mySqlParameterArray[index] = mySqlParameter;
      MySqlParameter[] parameter = mySqlParameterArray;
      return this.dbHelper.Execute(sql, parameter, false);
    }
  }
}
