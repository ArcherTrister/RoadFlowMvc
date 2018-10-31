// Decompiled with JetBrains decompiler
// Type: RoadFlow.Data.MySql.AppLibrarySubPages
// Assembly: RoadFlow.Data.MySql, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 29B652D7-5F6F-4A7D-AD1C-9F2C643FD784
// Assembly location: C:\inetpub\wwwroot\RoadFlowMvc\bin\RoadFlow.Data.MySql.dll

using MySql.Data.MySqlClient;
using RoadFlow.Data.Interface;
using System;
using System.Collections.Generic;

namespace RoadFlow.Data.MySql
{
  public class AppLibrarySubPages : IAppLibrarySubPages
  {
    private DBHelper dbHelper = new DBHelper();

    public int Add(RoadFlow.Data.Model.AppLibrarySubPages model)
    {
      string sql = "INSERT INTO applibrarysubpages\r\n\t\t\t\t(ID,AppLibraryID,Name,Address,Ico,Sort,Note) \r\n\t\t\t\tVALUES(@ID,@AppLibraryID,@Name,@Address,@Ico,@Sort,@Note)";
      MySqlParameter[] mySqlParameterArray = new MySqlParameter[7];
      int index1 = 0;
      MySqlParameter mySqlParameter1 = new MySqlParameter("@ID", MySqlDbType.VarChar, 36);
      mySqlParameter1.Value = (object) model.ID;
      mySqlParameterArray[index1] = mySqlParameter1;
      int index2 = 1;
      MySqlParameter mySqlParameter2 = new MySqlParameter("@AppLibraryID", MySqlDbType.VarChar, 36);
      mySqlParameter2.Value = (object) model.AppLibraryID;
      mySqlParameterArray[index2] = mySqlParameter2;
      int index3 = 2;
      MySqlParameter mySqlParameter3 = new MySqlParameter("@Name", MySqlDbType.Text, -1);
      mySqlParameter3.Value = (object) model.Name;
      mySqlParameterArray[index3] = mySqlParameter3;
      int index4 = 3;
      MySqlParameter mySqlParameter4 = new MySqlParameter("@Address", MySqlDbType.Text, -1);
      mySqlParameter4.Value = (object) model.Address;
      mySqlParameterArray[index4] = mySqlParameter4;
      int index5 = 4;
      MySqlParameter mySqlParameter5;
      if (model.Ico != null)
      {
        MySqlParameter mySqlParameter6 = new MySqlParameter("@Ico", MySqlDbType.Text, -1);
        mySqlParameter6.Value = (object) model.Ico;
        mySqlParameter5 = mySqlParameter6;
      }
      else
      {
        mySqlParameter5 = new MySqlParameter("@Ico", MySqlDbType.Text, -1);
        mySqlParameter5.Value = (object) DBNull.Value;
      }
      mySqlParameterArray[index5] = mySqlParameter5;
      int index6 = 5;
      MySqlParameter mySqlParameter7 = new MySqlParameter("@Sort", MySqlDbType.Int32, 11);
      mySqlParameter7.Value = (object) model.Sort;
      mySqlParameterArray[index6] = mySqlParameter7;
      int index7 = 6;
      MySqlParameter mySqlParameter8;
      if (model.Note != null)
      {
        MySqlParameter mySqlParameter6 = new MySqlParameter("@Note", MySqlDbType.Text, -1);
        mySqlParameter6.Value = (object) model.Note;
        mySqlParameter8 = mySqlParameter6;
      }
      else
      {
        mySqlParameter8 = new MySqlParameter("@Note", MySqlDbType.Text, -1);
        mySqlParameter8.Value = (object) DBNull.Value;
      }
      mySqlParameterArray[index7] = mySqlParameter8;
      MySqlParameter[] parameter = mySqlParameterArray;
      return this.dbHelper.Execute(sql, parameter, false);
    }

    public int Update(RoadFlow.Data.Model.AppLibrarySubPages model)
    {
      string sql = "UPDATE applibrarysubpages SET \r\n\t\t\t\tAppLibraryID=@AppLibraryID,Name=@Name,Address=@Address,Ico=@Ico,Sort=@Sort,Note=@Note\r\n\t\t\t\tWHERE ID=@ID";
      MySqlParameter[] mySqlParameterArray = new MySqlParameter[7];
      int index1 = 0;
      MySqlParameter mySqlParameter1 = new MySqlParameter("@AppLibraryID", MySqlDbType.VarChar, 36);
      mySqlParameter1.Value = (object) model.AppLibraryID;
      mySqlParameterArray[index1] = mySqlParameter1;
      int index2 = 1;
      MySqlParameter mySqlParameter2 = new MySqlParameter("@Name", MySqlDbType.Text, -1);
      mySqlParameter2.Value = (object) model.Name;
      mySqlParameterArray[index2] = mySqlParameter2;
      int index3 = 2;
      MySqlParameter mySqlParameter3 = new MySqlParameter("@Address", MySqlDbType.Text, -1);
      mySqlParameter3.Value = (object) model.Address;
      mySqlParameterArray[index3] = mySqlParameter3;
      int index4 = 3;
      MySqlParameter mySqlParameter4;
      if (model.Ico != null)
      {
        MySqlParameter mySqlParameter5 = new MySqlParameter("@Ico", MySqlDbType.Text, -1);
        mySqlParameter5.Value = (object) model.Ico;
        mySqlParameter4 = mySqlParameter5;
      }
      else
      {
        mySqlParameter4 = new MySqlParameter("@Ico", MySqlDbType.Text, -1);
        mySqlParameter4.Value = (object) DBNull.Value;
      }
      mySqlParameterArray[index4] = mySqlParameter4;
      int index5 = 4;
      MySqlParameter mySqlParameter6 = new MySqlParameter("@Sort", MySqlDbType.Int32, 11);
      mySqlParameter6.Value = (object) model.Sort;
      mySqlParameterArray[index5] = mySqlParameter6;
      int index6 = 5;
      MySqlParameter mySqlParameter7;
      if (model.Note != null)
      {
        MySqlParameter mySqlParameter5 = new MySqlParameter("@Note", MySqlDbType.Text, -1);
        mySqlParameter5.Value = (object) model.Note;
        mySqlParameter7 = mySqlParameter5;
      }
      else
      {
        mySqlParameter7 = new MySqlParameter("@Note", MySqlDbType.Text, -1);
        mySqlParameter7.Value = (object) DBNull.Value;
      }
      mySqlParameterArray[index6] = mySqlParameter7;
      int index7 = 6;
      MySqlParameter mySqlParameter8 = new MySqlParameter("@ID", MySqlDbType.VarChar, 36);
      mySqlParameter8.Value = (object) model.ID;
      mySqlParameterArray[index7] = mySqlParameter8;
      MySqlParameter[] parameter = mySqlParameterArray;
      return this.dbHelper.Execute(sql, parameter, false);
    }

    public int Delete(Guid id)
    {
      string sql = "DELETE FROM applibrarysubpages WHERE ID=@ID";
      MySqlParameter[] mySqlParameterArray = new MySqlParameter[1];
      int index = 0;
      MySqlParameter mySqlParameter = new MySqlParameter("@ID", MySqlDbType.VarChar, 36);
      mySqlParameter.Value = (object) id.ToString();
      mySqlParameterArray[index] = mySqlParameter;
      MySqlParameter[] parameter = mySqlParameterArray;
      return this.dbHelper.Execute(sql, parameter, false);
    }

    private List<RoadFlow.Data.Model.AppLibrarySubPages> DataReaderToList(MySqlDataReader dataReader)
    {
      List<RoadFlow.Data.Model.AppLibrarySubPages> appLibrarySubPagesList = new List<RoadFlow.Data.Model.AppLibrarySubPages>();
      while (dataReader.Read())
      {
        RoadFlow.Data.Model.AppLibrarySubPages appLibrarySubPages = new RoadFlow.Data.Model.AppLibrarySubPages();
        appLibrarySubPages.ID = dataReader.GetString(0).ToGuid();
        appLibrarySubPages.AppLibraryID = dataReader.GetString(1).ToGuid();
        appLibrarySubPages.Name = dataReader.GetString(2);
        appLibrarySubPages.Address = dataReader.GetString(3);
        if (!dataReader.IsDBNull(4))
          appLibrarySubPages.Ico = dataReader.GetString(4);
        appLibrarySubPages.Sort = dataReader.GetInt32(5);
        if (!dataReader.IsDBNull(6))
          appLibrarySubPages.Note = dataReader.GetString(6);
        appLibrarySubPagesList.Add(appLibrarySubPages);
      }
      return appLibrarySubPagesList;
    }

    public List<RoadFlow.Data.Model.AppLibrarySubPages> GetAll()
    {
      MySqlDataReader dataReader = this.dbHelper.GetDataReader("SELECT * FROM applibrarysubpages");
      List<RoadFlow.Data.Model.AppLibrarySubPages> list = this.DataReaderToList(dataReader);
      dataReader.Close();
      return list;
    }

    public long GetCount()
    {
      long result;
      if (!long.TryParse(this.dbHelper.GetFieldValue("SELECT COUNT(*) FROM applibrarysubpages"), out result))
        return 0;
      return result;
    }

    public RoadFlow.Data.Model.AppLibrarySubPages Get(Guid id)
    {
      string sql = "SELECT * FROM applibrarysubpages WHERE ID=@ID";
      MySqlParameter[] mySqlParameterArray = new MySqlParameter[1];
      int index = 0;
      MySqlParameter mySqlParameter = new MySqlParameter("@ID", MySqlDbType.VarChar, 36);
      mySqlParameter.Value = (object) id.ToString();
      mySqlParameterArray[index] = mySqlParameter;
      MySqlParameter[] parameter = mySqlParameterArray;
      MySqlDataReader dataReader = this.dbHelper.GetDataReader(sql, parameter);
      List<RoadFlow.Data.Model.AppLibrarySubPages> list = this.DataReaderToList(dataReader);
      dataReader.Close();
      if (list.Count <= 0)
        return (RoadFlow.Data.Model.AppLibrarySubPages) null;
      return list[0];
    }

    public int DeleteByAppID(Guid id)
    {
      string sql = "DELETE FROM AppLibrarySubPages WHERE AppLibraryID=@ID";
      MySqlParameter[] mySqlParameterArray = new MySqlParameter[1];
      int index = 0;
      MySqlParameter mySqlParameter = new MySqlParameter("@ID", MySqlDbType.VarChar);
      mySqlParameter.Value = (object) id;
      mySqlParameterArray[index] = mySqlParameter;
      MySqlParameter[] parameter = mySqlParameterArray;
      return this.dbHelper.Execute(sql, parameter, false);
    }

    public List<RoadFlow.Data.Model.AppLibrarySubPages> GetAllByAppID(Guid id)
    {
      string sql = "SELECT * FROM AppLibrarySubPages WHERE AppLibraryID=@ID";
      MySqlParameter[] mySqlParameterArray = new MySqlParameter[1];
      int index = 0;
      MySqlParameter mySqlParameter = new MySqlParameter("@ID", MySqlDbType.VarChar);
      mySqlParameter.Value = (object) id;
      mySqlParameterArray[index] = mySqlParameter;
      MySqlParameter[] parameter = mySqlParameterArray;
      MySqlDataReader dataReader = this.dbHelper.GetDataReader(sql, parameter);
      List<RoadFlow.Data.Model.AppLibrarySubPages> list = this.DataReaderToList(dataReader);
      dataReader.Close();
      return list;
    }
  }
}
