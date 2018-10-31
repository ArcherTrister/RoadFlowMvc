// Decompiled with JetBrains decompiler
// Type: RoadFlow.Data.MySql.Dictionary
// Assembly: RoadFlow.Data.MySql, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 29B652D7-5F6F-4A7D-AD1C-9F2C643FD784
// Assembly location: C:\inetpub\wwwroot\RoadFlowMvc\bin\RoadFlow.Data.MySql.dll

using MySql.Data.MySqlClient;
using RoadFlow.Data.Interface;
using System;
using System.Collections.Generic;

namespace RoadFlow.Data.MySql
{
  public class Dictionary : IDictionary
  {
    private DBHelper dbHelper = new DBHelper();

    public int Add(RoadFlow.Data.Model.Dictionary model)
    {
      string sql = "INSERT INTO dictionary\r\n\t\t\t\t(ID,ParentID,Title,Code,Value,Note,Other,Sort) \r\n\t\t\t\tVALUES(@ID,@ParentID,@Title,@Code,@Value,@Note,@Other,@Sort)";
      MySqlParameter[] mySqlParameterArray = new MySqlParameter[8];
      int index1 = 0;
      MySqlParameter mySqlParameter1 = new MySqlParameter("@ID", MySqlDbType.VarChar, 36);
      mySqlParameter1.Value = (object) model.ID;
      mySqlParameterArray[index1] = mySqlParameter1;
      int index2 = 1;
      MySqlParameter mySqlParameter2 = new MySqlParameter("@ParentID", MySqlDbType.VarChar, 36);
      mySqlParameter2.Value = (object) model.ParentID;
      mySqlParameterArray[index2] = mySqlParameter2;
      int index3 = 2;
      MySqlParameter mySqlParameter3 = new MySqlParameter("@Title", MySqlDbType.LongText, -1);
      mySqlParameter3.Value = (object) model.Title;
      mySqlParameterArray[index3] = mySqlParameter3;
      int index4 = 3;
      MySqlParameter mySqlParameter4;
      if (model.Code != null)
      {
        MySqlParameter mySqlParameter5 = new MySqlParameter("@Code", MySqlDbType.Text, -1);
        mySqlParameter5.Value = (object) model.Code;
        mySqlParameter4 = mySqlParameter5;
      }
      else
      {
        mySqlParameter4 = new MySqlParameter("@Code", MySqlDbType.Text, -1);
        mySqlParameter4.Value = (object) DBNull.Value;
      }
      mySqlParameterArray[index4] = mySqlParameter4;
      int index5 = 4;
      MySqlParameter mySqlParameter6;
      if (model.Value != null)
      {
        MySqlParameter mySqlParameter5 = new MySqlParameter("@Value", MySqlDbType.LongText, -1);
        mySqlParameter5.Value = (object) model.Value;
        mySqlParameter6 = mySqlParameter5;
      }
      else
      {
        mySqlParameter6 = new MySqlParameter("@Value", MySqlDbType.LongText, -1);
        mySqlParameter6.Value = (object) DBNull.Value;
      }
      mySqlParameterArray[index5] = mySqlParameter6;
      int index6 = 5;
      MySqlParameter mySqlParameter7;
      if (model.Note != null)
      {
        MySqlParameter mySqlParameter5 = new MySqlParameter("@Note", MySqlDbType.LongText, -1);
        mySqlParameter5.Value = (object) model.Note;
        mySqlParameter7 = mySqlParameter5;
      }
      else
      {
        mySqlParameter7 = new MySqlParameter("@Note", MySqlDbType.LongText, -1);
        mySqlParameter7.Value = (object) DBNull.Value;
      }
      mySqlParameterArray[index6] = mySqlParameter7;
      int index7 = 6;
      MySqlParameter mySqlParameter8;
      if (model.Other != null)
      {
        MySqlParameter mySqlParameter5 = new MySqlParameter("@Other", MySqlDbType.LongText, -1);
        mySqlParameter5.Value = (object) model.Other;
        mySqlParameter8 = mySqlParameter5;
      }
      else
      {
        mySqlParameter8 = new MySqlParameter("@Other", MySqlDbType.LongText, -1);
        mySqlParameter8.Value = (object) DBNull.Value;
      }
      mySqlParameterArray[index7] = mySqlParameter8;
      int index8 = 7;
      MySqlParameter mySqlParameter9 = new MySqlParameter("@Sort", MySqlDbType.Int32, 11);
      mySqlParameter9.Value = (object) model.Sort;
      mySqlParameterArray[index8] = mySqlParameter9;
      MySqlParameter[] parameter = mySqlParameterArray;
      return this.dbHelper.Execute(sql, parameter, false);
    }

    public int Update(RoadFlow.Data.Model.Dictionary model)
    {
      string sql = "UPDATE dictionary SET \r\n\t\t\t\tParentID=@ParentID,Title=@Title,Code=@Code,Value=@Value,Note=@Note,Other=@Other,Sort=@Sort\r\n\t\t\t\tWHERE ID=@ID";
      MySqlParameter[] mySqlParameterArray = new MySqlParameter[8];
      int index1 = 0;
      MySqlParameter mySqlParameter1 = new MySqlParameter("@ParentID", MySqlDbType.VarChar, 36);
      mySqlParameter1.Value = (object) model.ParentID;
      mySqlParameterArray[index1] = mySqlParameter1;
      int index2 = 1;
      MySqlParameter mySqlParameter2 = new MySqlParameter("@Title", MySqlDbType.LongText, -1);
      mySqlParameter2.Value = (object) model.Title;
      mySqlParameterArray[index2] = mySqlParameter2;
      int index3 = 2;
      MySqlParameter mySqlParameter3;
      if (model.Code != null)
      {
        MySqlParameter mySqlParameter4 = new MySqlParameter("@Code", MySqlDbType.Text, -1);
        mySqlParameter4.Value = (object) model.Code;
        mySqlParameter3 = mySqlParameter4;
      }
      else
      {
        mySqlParameter3 = new MySqlParameter("@Code", MySqlDbType.Text, -1);
        mySqlParameter3.Value = (object) DBNull.Value;
      }
      mySqlParameterArray[index3] = mySqlParameter3;
      int index4 = 3;
      MySqlParameter mySqlParameter5;
      if (model.Value != null)
      {
        MySqlParameter mySqlParameter4 = new MySqlParameter("@Value", MySqlDbType.LongText, -1);
        mySqlParameter4.Value = (object) model.Value;
        mySqlParameter5 = mySqlParameter4;
      }
      else
      {
        mySqlParameter5 = new MySqlParameter("@Value", MySqlDbType.LongText, -1);
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
      MySqlParameter mySqlParameter7;
      if (model.Other != null)
      {
        MySqlParameter mySqlParameter4 = new MySqlParameter("@Other", MySqlDbType.LongText, -1);
        mySqlParameter4.Value = (object) model.Other;
        mySqlParameter7 = mySqlParameter4;
      }
      else
      {
        mySqlParameter7 = new MySqlParameter("@Other", MySqlDbType.LongText, -1);
        mySqlParameter7.Value = (object) DBNull.Value;
      }
      mySqlParameterArray[index6] = mySqlParameter7;
      int index7 = 6;
      MySqlParameter mySqlParameter8 = new MySqlParameter("@Sort", MySqlDbType.Int32, 11);
      mySqlParameter8.Value = (object) model.Sort;
      mySqlParameterArray[index7] = mySqlParameter8;
      int index8 = 7;
      MySqlParameter mySqlParameter9 = new MySqlParameter("@ID", MySqlDbType.VarChar, 36);
      mySqlParameter9.Value = (object) model.ID;
      mySqlParameterArray[index8] = mySqlParameter9;
      MySqlParameter[] parameter = mySqlParameterArray;
      return this.dbHelper.Execute(sql, parameter, false);
    }

    public int Delete(Guid id)
    {
      string sql = "DELETE FROM dictionary WHERE ID=@ID";
      MySqlParameter[] mySqlParameterArray = new MySqlParameter[1];
      int index = 0;
      MySqlParameter mySqlParameter = new MySqlParameter("@ID", MySqlDbType.VarChar, 36);
      mySqlParameter.Value = (object) id.ToString();
      mySqlParameterArray[index] = mySqlParameter;
      MySqlParameter[] parameter = mySqlParameterArray;
      return this.dbHelper.Execute(sql, parameter, false);
    }

    private List<RoadFlow.Data.Model.Dictionary> DataReaderToList(MySqlDataReader dataReader)
    {
      List<RoadFlow.Data.Model.Dictionary> dictionaryList = new List<RoadFlow.Data.Model.Dictionary>();
      while (dataReader.Read())
      {
        RoadFlow.Data.Model.Dictionary dictionary = new RoadFlow.Data.Model.Dictionary();
        dictionary.ID = dataReader.GetString(0).ToGuid();
        dictionary.ParentID = dataReader.GetString(1).ToGuid();
        dictionary.Title = dataReader.GetString(2);
        if (!dataReader.IsDBNull(3))
          dictionary.Code = dataReader.GetString(3);
        if (!dataReader.IsDBNull(4))
          dictionary.Value = dataReader.GetString(4);
        if (!dataReader.IsDBNull(5))
          dictionary.Note = dataReader.GetString(5);
        if (!dataReader.IsDBNull(6))
          dictionary.Other = dataReader.GetString(6);
        dictionary.Sort = dataReader.GetInt32(7);
        dictionaryList.Add(dictionary);
      }
      return dictionaryList;
    }

    public List<RoadFlow.Data.Model.Dictionary> GetAll()
    {
      MySqlDataReader dataReader = this.dbHelper.GetDataReader("SELECT * FROM dictionary");
      List<RoadFlow.Data.Model.Dictionary> list = this.DataReaderToList(dataReader);
      dataReader.Close();
      return list;
    }

    public long GetCount()
    {
      long result;
      if (!long.TryParse(this.dbHelper.GetFieldValue("SELECT COUNT(*) FROM dictionary"), out result))
        return 0;
      return result;
    }

    public RoadFlow.Data.Model.Dictionary Get(Guid id)
    {
      string sql = "SELECT * FROM dictionary WHERE ID=@ID";
      MySqlParameter[] mySqlParameterArray = new MySqlParameter[1];
      int index = 0;
      MySqlParameter mySqlParameter = new MySqlParameter("@ID", MySqlDbType.VarChar, 36);
      mySqlParameter.Value = (object) id.ToString();
      mySqlParameterArray[index] = mySqlParameter;
      MySqlParameter[] parameter = mySqlParameterArray;
      MySqlDataReader dataReader = this.dbHelper.GetDataReader(sql, parameter);
      List<RoadFlow.Data.Model.Dictionary> list = this.DataReaderToList(dataReader);
      dataReader.Close();
      if (list.Count <= 0)
        return (RoadFlow.Data.Model.Dictionary) null;
      return list[0];
    }

    public RoadFlow.Data.Model.Dictionary GetRoot()
    {
      string sql = "SELECT * FROM Dictionary WHERE ParentID=@ParentID";
      MySqlParameter[] mySqlParameterArray = new MySqlParameter[1];
      int index = 0;
      MySqlParameter mySqlParameter = new MySqlParameter("@ParentID", MySqlDbType.VarChar);
      mySqlParameter.Value = (object) Guid.Empty;
      mySqlParameterArray[index] = mySqlParameter;
      MySqlParameter[] parameter = mySqlParameterArray;
      MySqlDataReader dataReader = this.dbHelper.GetDataReader(sql, parameter);
      List<RoadFlow.Data.Model.Dictionary> list = this.DataReaderToList(dataReader);
      dataReader.Close();
      if (list.Count <= 0)
        return (RoadFlow.Data.Model.Dictionary) null;
      return list[0];
    }

    public List<RoadFlow.Data.Model.Dictionary> GetChilds(Guid id)
    {
      string sql = "SELECT * FROM Dictionary WHERE ParentID=@ParentID ORDER BY Sort";
      MySqlParameter[] mySqlParameterArray = new MySqlParameter[1];
      int index = 0;
      MySqlParameter mySqlParameter = new MySqlParameter("@ParentID", MySqlDbType.VarChar);
      mySqlParameter.Value = (object) id;
      mySqlParameterArray[index] = mySqlParameter;
      MySqlParameter[] parameter = mySqlParameterArray;
      MySqlDataReader dataReader = this.dbHelper.GetDataReader(sql, parameter);
      List<RoadFlow.Data.Model.Dictionary> list = this.DataReaderToList(dataReader);
      dataReader.Close();
      return list;
    }

    public List<RoadFlow.Data.Model.Dictionary> GetChilds(string code)
    {
      string sql = "SELECT * FROM Dictionary WHERE ParentID=(SELECT ID FROM Dictionary WHERE Code=@Code) ORDER BY Sort";
      MySqlParameter[] mySqlParameterArray = new MySqlParameter[1];
      int index = 0;
      MySqlParameter mySqlParameter = new MySqlParameter("@Code", MySqlDbType.VarChar);
      mySqlParameter.Value = (object) code;
      mySqlParameterArray[index] = mySqlParameter;
      MySqlParameter[] parameter = mySqlParameterArray;
      MySqlDataReader dataReader = this.dbHelper.GetDataReader(sql, parameter);
      List<RoadFlow.Data.Model.Dictionary> list = this.DataReaderToList(dataReader);
      dataReader.Close();
      return list;
    }

    public RoadFlow.Data.Model.Dictionary GetParent(Guid id)
    {
      string sql = "SELECT * FROM Dictionary WHERE ID=(SELECT ParentID FROM Dictionary WHERE ID=@ID)";
      MySqlParameter[] mySqlParameterArray = new MySqlParameter[1];
      int index = 0;
      MySqlParameter mySqlParameter = new MySqlParameter("@ID", MySqlDbType.VarChar);
      mySqlParameter.Value = (object) id;
      mySqlParameterArray[index] = mySqlParameter;
      MySqlParameter[] parameter = mySqlParameterArray;
      MySqlDataReader dataReader = this.dbHelper.GetDataReader(sql, parameter);
      List<RoadFlow.Data.Model.Dictionary> list = this.DataReaderToList(dataReader);
      dataReader.Close();
      if (list.Count <= 0)
        return (RoadFlow.Data.Model.Dictionary) null;
      return list[0];
    }

    public bool HasChilds(Guid id)
    {
      string sql = "SELECT ID FROM Dictionary WHERE ParentID=@ParentID";
      MySqlParameter[] mySqlParameterArray = new MySqlParameter[1];
      int index = 0;
      MySqlParameter mySqlParameter = new MySqlParameter("@ParentID", MySqlDbType.VarChar);
      mySqlParameter.Value = (object) id;
      mySqlParameterArray[index] = mySqlParameter;
      MySqlParameter[] parameter = mySqlParameterArray;
      MySqlDataReader dataReader = this.dbHelper.GetDataReader(sql, parameter);
      bool hasRows = dataReader.HasRows;
      dataReader.Close();
      return hasRows;
    }

    public int GetMaxSort(Guid id)
    {
      string sql = "SELECT MAX(Sort)+1 FROM Dictionary WHERE ParentID=@ParentID";
      MySqlParameter[] mySqlParameterArray = new MySqlParameter[1];
      int index = 0;
      MySqlParameter mySqlParameter = new MySqlParameter("@ParentID", MySqlDbType.VarChar);
      mySqlParameter.Value = (object) id;
      mySqlParameterArray[index] = mySqlParameter;
      MySqlParameter[] parameter = mySqlParameterArray;
      int test;
      if (!this.dbHelper.GetFieldValue(sql, parameter).IsInt(out test))
        return 1;
      return test;
    }

    public int UpdateSort(Guid id, int sort)
    {
      string sql = "UPDATE Dictionary SET Sort=@Sort WHERE ID=@ID";
      MySqlParameter[] mySqlParameterArray = new MySqlParameter[2];
      int index1 = 0;
      MySqlParameter mySqlParameter1 = new MySqlParameter("@Sort", MySqlDbType.Int32);
      mySqlParameter1.Value = (object) sort;
      mySqlParameterArray[index1] = mySqlParameter1;
      int index2 = 1;
      MySqlParameter mySqlParameter2 = new MySqlParameter("@ID", MySqlDbType.VarChar);
      mySqlParameter2.Value = (object) id;
      mySqlParameterArray[index2] = mySqlParameter2;
      MySqlParameter[] parameter = mySqlParameterArray;
      return this.dbHelper.Execute(sql, parameter, false);
    }

    public RoadFlow.Data.Model.Dictionary GetByCode(string code)
    {
      string sql = "SELECT * FROM Dictionary WHERE Code=@Code";
      MySqlParameter[] mySqlParameterArray = new MySqlParameter[1];
      int index = 0;
      MySqlParameter mySqlParameter = new MySqlParameter("@Code", MySqlDbType.VarChar);
      mySqlParameter.Value = (object) code;
      mySqlParameterArray[index] = mySqlParameter;
      MySqlParameter[] parameter = mySqlParameterArray;
      MySqlDataReader dataReader = this.dbHelper.GetDataReader(sql, parameter);
      List<RoadFlow.Data.Model.Dictionary> list = this.DataReaderToList(dataReader);
      dataReader.Close();
      if (list.Count <= 0)
        return (RoadFlow.Data.Model.Dictionary) null;
      return list[0];
    }
  }
}
