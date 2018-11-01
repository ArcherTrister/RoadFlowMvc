// Decompiled with JetBrains decompiler
// Type: RoadFlow.Data.MySql.WorkGroup
// Assembly: RoadFlow.Data.MySql, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 29B652D7-5F6F-4A7D-AD1C-9F2C643FD784
// Assembly location: C:\inetpub\wwwroot\RoadFlowMvc\bin\RoadFlow.Data.MySql.dll

using MySql.Data.MySqlClient;
using RoadFlow.Data.Interface;
using System;
using System.Collections.Generic;

namespace RoadFlow.Data.MySql
{
  public class WorkGroup : IWorkGroup
  {
    private DBHelper dbHelper = new DBHelper();

    public int Add(RoadFlow.Data.Model.WorkGroup model)
    {
      string sql = "INSERT INTO workgroup\r\n\t\t\t\t(ID,Name,Members,Note,IntID) \r\n\t\t\t\tVALUES(@ID,@Name,@Members,@Note,@IntID)";
      MySqlParameter[] mySqlParameterArray = new MySqlParameter[5];
      int index1 = 0;
      MySqlParameter mySqlParameter1 = new MySqlParameter("@ID", MySqlDbType.VarChar, 36);
      mySqlParameter1.Value = (object) model.ID;
      mySqlParameterArray[index1] = mySqlParameter1;
      int index2 = 1;
      MySqlParameter mySqlParameter2 = new MySqlParameter("@Name", MySqlDbType.Text, -1);
      mySqlParameter2.Value = (object) model.Name;
      mySqlParameterArray[index2] = mySqlParameter2;
      int index3 = 2;
      MySqlParameter mySqlParameter3 = new MySqlParameter("@Members", MySqlDbType.LongText, -1);
      mySqlParameter3.Value = (object) model.Members;
      mySqlParameterArray[index3] = mySqlParameter3;
      int index4 = 3;
      MySqlParameter mySqlParameter4;
      if (model.Note != null)
      {
        MySqlParameter mySqlParameter5 = new MySqlParameter("@Note", MySqlDbType.LongText, -1);
        mySqlParameter5.Value = (object) model.Note;
        mySqlParameter4 = mySqlParameter5;
      }
      else
      {
        mySqlParameter4 = new MySqlParameter("@Note", MySqlDbType.LongText, -1);
        mySqlParameter4.Value = (object) DBNull.Value;
      }
      mySqlParameterArray[index4] = mySqlParameter4;
      int index5 = 4;
      MySqlParameter mySqlParameter6 = new MySqlParameter("@IntID", MySqlDbType.Int32, -1);
      mySqlParameter6.Value = (object) model.IntID;
      mySqlParameterArray[index5] = mySqlParameter6;
      MySqlParameter[] parameter = mySqlParameterArray;
      return this.dbHelper.Execute(sql, parameter, false);
    }

    public int Update(RoadFlow.Data.Model.WorkGroup model)
    {
      string sql = "UPDATE workgroup SET \r\n\t\t\t\tName=@Name,Members=@Members,Note=@Note,IntID=@IntID \r\n\t\t\t\tWHERE ID=@ID";
      MySqlParameter[] mySqlParameterArray = new MySqlParameter[5];
      int index1 = 0;
      MySqlParameter mySqlParameter1 = new MySqlParameter("@Name", MySqlDbType.Text, -1);
      mySqlParameter1.Value = (object) model.Name;
      mySqlParameterArray[index1] = mySqlParameter1;
      int index2 = 1;
      MySqlParameter mySqlParameter2 = new MySqlParameter("@Members", MySqlDbType.LongText, -1);
      mySqlParameter2.Value = (object) model.Members;
      mySqlParameterArray[index2] = mySqlParameter2;
      int index3 = 2;
      MySqlParameter mySqlParameter3;
      if (model.Note != null)
      {
        MySqlParameter mySqlParameter4 = new MySqlParameter("@Note", MySqlDbType.LongText, -1);
        mySqlParameter4.Value = (object) model.Note;
        mySqlParameter3 = mySqlParameter4;
      }
      else
      {
        mySqlParameter3 = new MySqlParameter("@Note", MySqlDbType.LongText, -1);
        mySqlParameter3.Value = (object) DBNull.Value;
      }
      mySqlParameterArray[index3] = mySqlParameter3;
      int index4 = 3;
      MySqlParameter mySqlParameter5 = new MySqlParameter("@IntID", MySqlDbType.Int32, -1);
      mySqlParameter5.Value = (object) model.IntID;
      mySqlParameterArray[index4] = mySqlParameter5;
      int index5 = 4;
      MySqlParameter mySqlParameter6 = new MySqlParameter("@ID", MySqlDbType.VarChar, 36);
      mySqlParameter6.Value = (object) model.ID;
      mySqlParameterArray[index5] = mySqlParameter6;
      MySqlParameter[] parameter = mySqlParameterArray;
      return this.dbHelper.Execute(sql, parameter, false);
    }

    public int Delete(Guid id)
    {
      string sql = "DELETE FROM workgroup WHERE ID=@ID";
      MySqlParameter[] mySqlParameterArray = new MySqlParameter[1];
      int index = 0;
      MySqlParameter mySqlParameter = new MySqlParameter("@ID", MySqlDbType.VarChar, 36);
      mySqlParameter.Value = (object) id.ToString();
      mySqlParameterArray[index] = mySqlParameter;
      MySqlParameter[] parameter = mySqlParameterArray;
      return this.dbHelper.Execute(sql, parameter, false);
    }

    private List<RoadFlow.Data.Model.WorkGroup> DataReaderToList(MySqlDataReader dataReader)
    {
      List<RoadFlow.Data.Model.WorkGroup> workGroupList = new List<RoadFlow.Data.Model.WorkGroup>();
      while (dataReader.Read())
      {
        RoadFlow.Data.Model.WorkGroup workGroup = new RoadFlow.Data.Model.WorkGroup();
        workGroup.ID = dataReader.GetString(0).ToGuid();
        workGroup.Name = dataReader.GetString(1);
        workGroup.Members = dataReader.GetString(2);
        if (!dataReader.IsDBNull(3))
          workGroup.Note = dataReader.GetString(3);
        workGroup.IntID = dataReader.GetInt32(4);
        workGroupList.Add(workGroup);
      }
      return workGroupList;
    }

    public List<RoadFlow.Data.Model.WorkGroup> GetAll()
    {
      MySqlDataReader dataReader = this.dbHelper.GetDataReader("SELECT * FROM workgroup");
      List<RoadFlow.Data.Model.WorkGroup> list = this.DataReaderToList(dataReader);
      dataReader.Close();
      return list;
    }

    public long GetCount()
    {
      long result;
      if (!long.TryParse(this.dbHelper.GetFieldValue("SELECT COUNT(*) FROM workgroup"), out result))
        return 0;
      return result;
    }

    public RoadFlow.Data.Model.WorkGroup Get(Guid id)
    {
      string sql = "SELECT * FROM workgroup WHERE ID=@ID";
      MySqlParameter[] mySqlParameterArray = new MySqlParameter[1];
      int index = 0;
      MySqlParameter mySqlParameter = new MySqlParameter("@ID", MySqlDbType.VarChar, 36);
      mySqlParameter.Value = (object) id.ToString();
      mySqlParameterArray[index] = mySqlParameter;
      MySqlParameter[] parameter = mySqlParameterArray;
      MySqlDataReader dataReader = this.dbHelper.GetDataReader(sql, parameter);
      List<RoadFlow.Data.Model.WorkGroup> list = this.DataReaderToList(dataReader);
      dataReader.Close();
      if (list.Count <= 0)
        return (RoadFlow.Data.Model.WorkGroup) null;
      return list[0];
    }
  }
}
