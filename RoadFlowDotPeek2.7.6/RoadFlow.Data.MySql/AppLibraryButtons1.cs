// Decompiled with JetBrains decompiler
// Type: RoadFlow.Data.MySql.AppLibraryButtons1
// Assembly: RoadFlow.Data.MySql, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 29B652D7-5F6F-4A7D-AD1C-9F2C643FD784
// Assembly location: C:\inetpub\wwwroot\RoadFlowMvc\bin\RoadFlow.Data.MySql.dll

using MySql.Data.MySqlClient;
using RoadFlow.Data.Interface;
using System;
using System.Collections.Generic;

namespace RoadFlow.Data.MySql
{
  public class AppLibraryButtons1 : IAppLibraryButtons1
  {
    private DBHelper dbHelper = new DBHelper();

    public int Add(RoadFlow.Data.Model.AppLibraryButtons1 model)
    {
      string sql = "INSERT INTO applibrarybuttons1\r\n\t\t\t\t(ID,AppLibraryID,ButtonID,Name,Events,Ico,Sort,Type,ShowType,IsValidateShow) \r\n\t\t\t\tVALUES(@ID,@AppLibraryID,@ButtonID,@Name,@Events,@Ico,@Sort,@Type,@ShowType,@IsValidateShow)";
      MySqlParameter[] mySqlParameterArray = new MySqlParameter[10];
      int index1 = 0;
      MySqlParameter mySqlParameter1 = new MySqlParameter("@ID", MySqlDbType.VarChar, 36);
      mySqlParameter1.Value = (object) model.ID;
      mySqlParameterArray[index1] = mySqlParameter1;
      int index2 = 1;
      MySqlParameter mySqlParameter2 = new MySqlParameter("@AppLibraryID", MySqlDbType.VarChar, 36);
      mySqlParameter2.Value = (object) model.AppLibraryID;
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
      MySqlParameter mySqlParameter5 = new MySqlParameter("@Name", MySqlDbType.Text, -1);
      mySqlParameter5.Value = (object) model.Name;
      mySqlParameterArray[index4] = mySqlParameter5;
      int index5 = 4;
      MySqlParameter mySqlParameter6 = new MySqlParameter("@Events", MySqlDbType.Text, -1);
      mySqlParameter6.Value = (object) model.Events;
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
      MySqlParameter mySqlParameter8 = new MySqlParameter("@Sort", MySqlDbType.Int32, 11);
      mySqlParameter8.Value = (object) model.Sort;
      mySqlParameterArray[index7] = mySqlParameter8;
      int index8 = 7;
      MySqlParameter mySqlParameter9 = new MySqlParameter("@Type", MySqlDbType.Int32, 11);
      mySqlParameter9.Value = (object) model.Type;
      mySqlParameterArray[index8] = mySqlParameter9;
      int index9 = 8;
      MySqlParameter mySqlParameter10 = new MySqlParameter("@ShowType", MySqlDbType.Int32, 11);
      mySqlParameter10.Value = (object) model.ShowType;
      mySqlParameterArray[index9] = mySqlParameter10;
      int index10 = 9;
      MySqlParameter mySqlParameter11 = new MySqlParameter("@IsValidateShow", MySqlDbType.Int32, 11);
      mySqlParameter11.Value = (object) model.IsValidateShow;
      mySqlParameterArray[index10] = mySqlParameter11;
      MySqlParameter[] parameter = mySqlParameterArray;
      return this.dbHelper.Execute(sql, parameter, false);
    }

    public int Update(RoadFlow.Data.Model.AppLibraryButtons1 model)
    {
      string sql = "UPDATE applibrarybuttons1 SET \r\n\t\t\t\tAppLibraryID=@AppLibraryID,ButtonID=@ButtonID,Name=@Name,Events=@Events,Ico=@Ico,Sort=@Sort,Type=@Type,ShowType=@ShowType,IsValidateShow=@IsValidateShow\r\n\t\t\t\tWHERE ID=@ID";
      MySqlParameter[] mySqlParameterArray = new MySqlParameter[10];
      int index1 = 0;
      MySqlParameter mySqlParameter1 = new MySqlParameter("@AppLibraryID", MySqlDbType.VarChar, 36);
      mySqlParameter1.Value = (object) model.AppLibraryID;
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
      MySqlParameter mySqlParameter4 = new MySqlParameter("@Name", MySqlDbType.Text, -1);
      mySqlParameter4.Value = (object) model.Name;
      mySqlParameterArray[index3] = mySqlParameter4;
      int index4 = 3;
      MySqlParameter mySqlParameter5 = new MySqlParameter("@Events", MySqlDbType.Text, -1);
      mySqlParameter5.Value = (object) model.Events;
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
      MySqlParameter mySqlParameter7 = new MySqlParameter("@Sort", MySqlDbType.Int32, 11);
      mySqlParameter7.Value = (object) model.Sort;
      mySqlParameterArray[index6] = mySqlParameter7;
      int index7 = 6;
      MySqlParameter mySqlParameter8 = new MySqlParameter("@Type", MySqlDbType.Int32, 11);
      mySqlParameter8.Value = (object) model.Type;
      mySqlParameterArray[index7] = mySqlParameter8;
      int index8 = 7;
      MySqlParameter mySqlParameter9 = new MySqlParameter("@ShowType", MySqlDbType.Int32, 11);
      mySqlParameter9.Value = (object) model.ShowType;
      mySqlParameterArray[index8] = mySqlParameter9;
      int index9 = 8;
      MySqlParameter mySqlParameter10 = new MySqlParameter("@IsValidateShow", MySqlDbType.Int32, 11);
      mySqlParameter10.Value = (object) model.IsValidateShow;
      mySqlParameterArray[index9] = mySqlParameter10;
      int index10 = 9;
      MySqlParameter mySqlParameter11 = new MySqlParameter("@ID", MySqlDbType.VarChar, 36);
      mySqlParameter11.Value = (object) model.ID;
      mySqlParameterArray[index10] = mySqlParameter11;
      MySqlParameter[] parameter = mySqlParameterArray;
      return this.dbHelper.Execute(sql, parameter, false);
    }

    public int Delete(Guid id)
    {
      string sql = "DELETE FROM applibrarybuttons1 WHERE ID=@ID";
      MySqlParameter[] mySqlParameterArray = new MySqlParameter[1];
      int index = 0;
      MySqlParameter mySqlParameter = new MySqlParameter("@ID", MySqlDbType.VarChar, 36);
      mySqlParameter.Value = (object) id.ToString();
      mySqlParameterArray[index] = mySqlParameter;
      MySqlParameter[] parameter = mySqlParameterArray;
      return this.dbHelper.Execute(sql, parameter, false);
    }

    private List<RoadFlow.Data.Model.AppLibraryButtons1> DataReaderToList(MySqlDataReader dataReader)
    {
      List<RoadFlow.Data.Model.AppLibraryButtons1> appLibraryButtons1List = new List<RoadFlow.Data.Model.AppLibraryButtons1>();
      while (dataReader.Read())
      {
        RoadFlow.Data.Model.AppLibraryButtons1 appLibraryButtons1 = new RoadFlow.Data.Model.AppLibraryButtons1();
        appLibraryButtons1.ID = dataReader.GetString(0).ToGuid();
        appLibraryButtons1.AppLibraryID = dataReader.GetString(1).ToGuid();
        if (!dataReader.IsDBNull(2))
          appLibraryButtons1.ButtonID = new Guid?(dataReader.GetString(2).ToGuid());
        appLibraryButtons1.Name = dataReader.GetString(3);
        appLibraryButtons1.Events = dataReader.GetString(4);
        if (!dataReader.IsDBNull(5))
          appLibraryButtons1.Ico = dataReader.GetString(5);
        appLibraryButtons1.Sort = dataReader.GetInt32(6);
        appLibraryButtons1.Type = dataReader.GetInt32(7);
        appLibraryButtons1.ShowType = dataReader.GetInt32(8);
        appLibraryButtons1.IsValidateShow = dataReader.GetInt32(9);
        appLibraryButtons1List.Add(appLibraryButtons1);
      }
      return appLibraryButtons1List;
    }

    public List<RoadFlow.Data.Model.AppLibraryButtons1> GetAll()
    {
      MySqlDataReader dataReader = this.dbHelper.GetDataReader("SELECT * FROM applibrarybuttons1");
      List<RoadFlow.Data.Model.AppLibraryButtons1> list = this.DataReaderToList(dataReader);
      dataReader.Close();
      return list;
    }

    public long GetCount()
    {
      long result;
      if (!long.TryParse(this.dbHelper.GetFieldValue("SELECT COUNT(*) FROM applibrarybuttons1"), out result))
        return 0;
      return result;
    }

    public RoadFlow.Data.Model.AppLibraryButtons1 Get(Guid id)
    {
      string sql = "SELECT * FROM applibrarybuttons1 WHERE ID=@ID";
      MySqlParameter[] mySqlParameterArray = new MySqlParameter[1];
      int index = 0;
      MySqlParameter mySqlParameter = new MySqlParameter("@ID", MySqlDbType.VarChar, 36);
      mySqlParameter.Value = (object) id.ToString();
      mySqlParameterArray[index] = mySqlParameter;
      MySqlParameter[] parameter = mySqlParameterArray;
      MySqlDataReader dataReader = this.dbHelper.GetDataReader(sql, parameter);
      List<RoadFlow.Data.Model.AppLibraryButtons1> list = this.DataReaderToList(dataReader);
      dataReader.Close();
      if (list.Count <= 0)
        return (RoadFlow.Data.Model.AppLibraryButtons1) null;
      return list[0];
    }

    public int DeleteByAppID(Guid id)
    {
      string sql = "DELETE FROM AppLibraryButtons1 WHERE AppLibraryID=@ID";
      MySqlParameter[] mySqlParameterArray = new MySqlParameter[1];
      int index = 0;
      MySqlParameter mySqlParameter = new MySqlParameter("@ID", MySqlDbType.VarChar);
      mySqlParameter.Value = (object) id;
      mySqlParameterArray[index] = mySqlParameter;
      MySqlParameter[] parameter = mySqlParameterArray;
      return this.dbHelper.Execute(sql, parameter, false);
    }

    public List<RoadFlow.Data.Model.AppLibraryButtons1> GetAllByAppID(Guid id)
    {
      string sql = "SELECT * FROM AppLibraryButtons1 WHERE AppLibraryID=@ID";
      MySqlParameter[] mySqlParameterArray = new MySqlParameter[1];
      int index = 0;
      MySqlParameter mySqlParameter = new MySqlParameter("@ID", MySqlDbType.VarChar);
      mySqlParameter.Value = (object) id;
      mySqlParameterArray[index] = mySqlParameter;
      MySqlParameter[] parameter = mySqlParameterArray;
      MySqlDataReader dataReader = this.dbHelper.GetDataReader(sql, parameter);
      List<RoadFlow.Data.Model.AppLibraryButtons1> list = this.DataReaderToList(dataReader);
      dataReader.Close();
      return list;
    }
  }
}
