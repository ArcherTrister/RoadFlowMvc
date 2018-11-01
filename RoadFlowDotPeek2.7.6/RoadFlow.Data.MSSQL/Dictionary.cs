// Decompiled with JetBrains decompiler
// Type: RoadFlow.Data.MSSQL.Dictionary
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
  public class Dictionary : IDictionary
  {
    private DBHelper dbHelper = new DBHelper();

    public int Add(RoadFlow.Data.Model.Dictionary model)
    {
      string sql = "INSERT INTO Dictionary\r\n\t\t\t\t(ID,ParentID,Title,Code,Value,Note,Other,Sort) \r\n\t\t\t\tVALUES(@ID,@ParentID,@Title,@Code,@Value,@Note,@Other,@Sort)";
      SqlParameter[] sqlParameterArray = new SqlParameter[8];
      int index1 = 0;
      SqlParameter sqlParameter1 = new SqlParameter("@ID", SqlDbType.UniqueIdentifier, -1);
      sqlParameter1.Value = (object) model.ID;
      sqlParameterArray[index1] = sqlParameter1;
      int index2 = 1;
      SqlParameter sqlParameter2 = new SqlParameter("@ParentID", SqlDbType.UniqueIdentifier, -1);
      sqlParameter2.Value = (object) model.ParentID;
      sqlParameterArray[index2] = sqlParameter2;
      int index3 = 2;
      SqlParameter sqlParameter3 = new SqlParameter("@Title", SqlDbType.NVarChar, -1);
      sqlParameter3.Value = (object) model.Title;
      sqlParameterArray[index3] = sqlParameter3;
      int index4 = 3;
      SqlParameter sqlParameter4;
      if (model.Code != null)
      {
        SqlParameter sqlParameter5 = new SqlParameter("@Code", SqlDbType.VarChar, 500);
        sqlParameter5.Value = (object) model.Code;
        sqlParameter4 = sqlParameter5;
      }
      else
      {
        sqlParameter4 = new SqlParameter("@Code", SqlDbType.VarChar, 500);
        sqlParameter4.Value = (object) DBNull.Value;
      }
      sqlParameterArray[index4] = sqlParameter4;
      int index5 = 4;
      SqlParameter sqlParameter6;
      if (model.Value != null)
      {
        SqlParameter sqlParameter5 = new SqlParameter("@Value", SqlDbType.VarChar, -1);
        sqlParameter5.Value = (object) model.Value;
        sqlParameter6 = sqlParameter5;
      }
      else
      {
        sqlParameter6 = new SqlParameter("@Value", SqlDbType.VarChar, -1);
        sqlParameter6.Value = (object) DBNull.Value;
      }
      sqlParameterArray[index5] = sqlParameter6;
      int index6 = 5;
      SqlParameter sqlParameter7;
      if (model.Note != null)
      {
        SqlParameter sqlParameter5 = new SqlParameter("@Note", SqlDbType.VarChar, -1);
        sqlParameter5.Value = (object) model.Note;
        sqlParameter7 = sqlParameter5;
      }
      else
      {
        sqlParameter7 = new SqlParameter("@Note", SqlDbType.VarChar, -1);
        sqlParameter7.Value = (object) DBNull.Value;
      }
      sqlParameterArray[index6] = sqlParameter7;
      int index7 = 6;
      SqlParameter sqlParameter8;
      if (model.Other != null)
      {
        SqlParameter sqlParameter5 = new SqlParameter("@Other", SqlDbType.VarChar, -1);
        sqlParameter5.Value = (object) model.Other;
        sqlParameter8 = sqlParameter5;
      }
      else
      {
        sqlParameter8 = new SqlParameter("@Other", SqlDbType.VarChar, -1);
        sqlParameter8.Value = (object) DBNull.Value;
      }
      sqlParameterArray[index7] = sqlParameter8;
      int index8 = 7;
      SqlParameter sqlParameter9 = new SqlParameter("@Sort", SqlDbType.Int, -1);
      sqlParameter9.Value = (object) model.Sort;
      sqlParameterArray[index8] = sqlParameter9;
      SqlParameter[] parameter = sqlParameterArray;
      return this.dbHelper.Execute(sql, parameter, false);
    }

    public int Update(RoadFlow.Data.Model.Dictionary model)
    {
      string sql = "UPDATE Dictionary SET \r\n\t\t\t\tParentID=@ParentID,Title=@Title,Code=@Code,Value=@Value,Note=@Note,Other=@Other,Sort=@Sort\r\n\t\t\t\tWHERE ID=@ID";
      SqlParameter[] sqlParameterArray = new SqlParameter[8];
      int index1 = 0;
      SqlParameter sqlParameter1 = new SqlParameter("@ParentID", SqlDbType.UniqueIdentifier, -1);
      sqlParameter1.Value = (object) model.ParentID;
      sqlParameterArray[index1] = sqlParameter1;
      int index2 = 1;
      SqlParameter sqlParameter2 = new SqlParameter("@Title", SqlDbType.NVarChar, -1);
      sqlParameter2.Value = (object) model.Title;
      sqlParameterArray[index2] = sqlParameter2;
      int index3 = 2;
      SqlParameter sqlParameter3;
      if (model.Code != null)
      {
        SqlParameter sqlParameter4 = new SqlParameter("@Code", SqlDbType.VarChar, 500);
        sqlParameter4.Value = (object) model.Code;
        sqlParameter3 = sqlParameter4;
      }
      else
      {
        sqlParameter3 = new SqlParameter("@Code", SqlDbType.VarChar, 500);
        sqlParameter3.Value = (object) DBNull.Value;
      }
      sqlParameterArray[index3] = sqlParameter3;
      int index4 = 3;
      SqlParameter sqlParameter5;
      if (model.Value != null)
      {
        SqlParameter sqlParameter4 = new SqlParameter("@Value", SqlDbType.VarChar, -1);
        sqlParameter4.Value = (object) model.Value;
        sqlParameter5 = sqlParameter4;
      }
      else
      {
        sqlParameter5 = new SqlParameter("@Value", SqlDbType.VarChar, -1);
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
      SqlParameter sqlParameter7;
      if (model.Other != null)
      {
        SqlParameter sqlParameter4 = new SqlParameter("@Other", SqlDbType.VarChar, -1);
        sqlParameter4.Value = (object) model.Other;
        sqlParameter7 = sqlParameter4;
      }
      else
      {
        sqlParameter7 = new SqlParameter("@Other", SqlDbType.VarChar, -1);
        sqlParameter7.Value = (object) DBNull.Value;
      }
      sqlParameterArray[index6] = sqlParameter7;
      int index7 = 6;
      SqlParameter sqlParameter8 = new SqlParameter("@Sort", SqlDbType.Int, -1);
      sqlParameter8.Value = (object) model.Sort;
      sqlParameterArray[index7] = sqlParameter8;
      int index8 = 7;
      SqlParameter sqlParameter9 = new SqlParameter("@ID", SqlDbType.UniqueIdentifier, -1);
      sqlParameter9.Value = (object) model.ID;
      sqlParameterArray[index8] = sqlParameter9;
      SqlParameter[] parameter = sqlParameterArray;
      return this.dbHelper.Execute(sql, parameter, false);
    }

    public int Delete(Guid id)
    {
      string sql = "DELETE FROM Dictionary WHERE ID=@ID";
      SqlParameter[] sqlParameterArray = new SqlParameter[1];
      int index = 0;
      SqlParameter sqlParameter = new SqlParameter("@ID", SqlDbType.UniqueIdentifier);
      sqlParameter.Value = (object) id;
      sqlParameterArray[index] = sqlParameter;
      SqlParameter[] parameter = sqlParameterArray;
      return this.dbHelper.Execute(sql, parameter, false);
    }

    private List<RoadFlow.Data.Model.Dictionary> DataReaderToList(SqlDataReader dataReader)
    {
      List<RoadFlow.Data.Model.Dictionary> dictionaryList = new List<RoadFlow.Data.Model.Dictionary>();
      while (dataReader.Read())
      {
        RoadFlow.Data.Model.Dictionary dictionary = new RoadFlow.Data.Model.Dictionary();
        dictionary.ID = dataReader.GetGuid(0);
        dictionary.ParentID = dataReader.GetGuid(1);
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
      SqlDataReader dataReader = this.dbHelper.GetDataReader("SELECT * FROM Dictionary");
      List<RoadFlow.Data.Model.Dictionary> list = this.DataReaderToList(dataReader);
      dataReader.Close();
      return list;
    }

    public long GetCount()
    {
      long result;
      if (!long.TryParse(this.dbHelper.GetFieldValue("SELECT COUNT(*) FROM Dictionary"), out result))
        return 0;
      return result;
    }

    public RoadFlow.Data.Model.Dictionary Get(Guid id)
    {
      string sql = "SELECT * FROM Dictionary WHERE ID=@ID";
      SqlParameter[] sqlParameterArray = new SqlParameter[1];
      int index = 0;
      SqlParameter sqlParameter = new SqlParameter("@ID", SqlDbType.UniqueIdentifier);
      sqlParameter.Value = (object) id;
      sqlParameterArray[index] = sqlParameter;
      SqlParameter[] parameter = sqlParameterArray;
      SqlDataReader dataReader = this.dbHelper.GetDataReader(sql, parameter);
      List<RoadFlow.Data.Model.Dictionary> list = this.DataReaderToList(dataReader);
      dataReader.Close();
      if (list.Count <= 0)
        return (RoadFlow.Data.Model.Dictionary) null;
      return list[0];
    }

    public RoadFlow.Data.Model.Dictionary GetRoot()
    {
      string sql = "SELECT * FROM Dictionary WHERE ParentID=@ParentID";
      SqlParameter[] sqlParameterArray = new SqlParameter[1];
      int index = 0;
      SqlParameter sqlParameter = new SqlParameter("@ParentID", SqlDbType.UniqueIdentifier);
      sqlParameter.Value = (object) Guid.Empty;
      sqlParameterArray[index] = sqlParameter;
      SqlParameter[] parameter = sqlParameterArray;
      SqlDataReader dataReader = this.dbHelper.GetDataReader(sql, parameter);
      List<RoadFlow.Data.Model.Dictionary> list = this.DataReaderToList(dataReader);
      dataReader.Close();
      if (list.Count <= 0)
        return (RoadFlow.Data.Model.Dictionary) null;
      return list[0];
    }

    public List<RoadFlow.Data.Model.Dictionary> GetChilds(Guid id)
    {
      string sql = "SELECT * FROM Dictionary WHERE ParentID=@ParentID ORDER BY Sort";
      SqlParameter[] sqlParameterArray = new SqlParameter[1];
      int index = 0;
      SqlParameter sqlParameter = new SqlParameter("@ParentID", SqlDbType.UniqueIdentifier);
      sqlParameter.Value = (object) id;
      sqlParameterArray[index] = sqlParameter;
      SqlParameter[] parameter = sqlParameterArray;
      SqlDataReader dataReader = this.dbHelper.GetDataReader(sql, parameter);
      List<RoadFlow.Data.Model.Dictionary> list = this.DataReaderToList(dataReader);
      dataReader.Close();
      return list;
    }

    public List<RoadFlow.Data.Model.Dictionary> GetChilds(string code)
    {
      string sql = "SELECT * FROM Dictionary WHERE ParentID=(SELECT ID FROM Dictionary WHERE Code=@Code) ORDER BY Sort";
      SqlParameter[] sqlParameterArray = new SqlParameter[1];
      int index = 0;
      SqlParameter sqlParameter = new SqlParameter("@Code", SqlDbType.VarChar);
      sqlParameter.Value = (object) code;
      sqlParameterArray[index] = sqlParameter;
      SqlParameter[] parameter = sqlParameterArray;
      SqlDataReader dataReader = this.dbHelper.GetDataReader(sql, parameter);
      List<RoadFlow.Data.Model.Dictionary> list = this.DataReaderToList(dataReader);
      dataReader.Close();
      return list;
    }

    public RoadFlow.Data.Model.Dictionary GetParent(Guid id)
    {
      string sql = "SELECT * FROM Dictionary WHERE ID=(SELECT ParentID FROM Dictionary WHERE ID=@ID)";
      SqlParameter[] sqlParameterArray = new SqlParameter[1];
      int index = 0;
      SqlParameter sqlParameter = new SqlParameter("@ID", SqlDbType.UniqueIdentifier);
      sqlParameter.Value = (object) id;
      sqlParameterArray[index] = sqlParameter;
      SqlParameter[] parameter = sqlParameterArray;
      SqlDataReader dataReader = this.dbHelper.GetDataReader(sql, parameter);
      List<RoadFlow.Data.Model.Dictionary> list = this.DataReaderToList(dataReader);
      dataReader.Close();
      if (list.Count <= 0)
        return (RoadFlow.Data.Model.Dictionary) null;
      return list[0];
    }

    public bool HasChilds(Guid id)
    {
      string sql = "SELECT ID FROM Dictionary WHERE ParentID=@ParentID";
      SqlParameter[] sqlParameterArray = new SqlParameter[1];
      int index = 0;
      SqlParameter sqlParameter = new SqlParameter("@ParentID", SqlDbType.UniqueIdentifier);
      sqlParameter.Value = (object) id;
      sqlParameterArray[index] = sqlParameter;
      SqlParameter[] parameter = sqlParameterArray;
      SqlDataReader dataReader = this.dbHelper.GetDataReader(sql, parameter);
      bool hasRows = dataReader.HasRows;
      dataReader.Close();
      return hasRows;
    }

    public int GetMaxSort(Guid id)
    {
      string sql = "SELECT MAX(Sort)+1 FROM Dictionary WHERE ParentID=@ParentID";
      SqlParameter[] sqlParameterArray = new SqlParameter[1];
      int index = 0;
      SqlParameter sqlParameter = new SqlParameter("@ParentID", SqlDbType.UniqueIdentifier);
      sqlParameter.Value = (object) id;
      sqlParameterArray[index] = sqlParameter;
      SqlParameter[] parameter = sqlParameterArray;
      int test;
      if (!this.dbHelper.GetFieldValue(sql, parameter).IsInt(out test))
        return 1;
      return test;
    }

    public int UpdateSort(Guid id, int sort)
    {
      string sql = "UPDATE Dictionary SET Sort=@Sort WHERE ID=@ID";
      SqlParameter[] sqlParameterArray = new SqlParameter[2];
      int index1 = 0;
      SqlParameter sqlParameter1 = new SqlParameter("@Sort", SqlDbType.Int);
      sqlParameter1.Value = (object) sort;
      sqlParameterArray[index1] = sqlParameter1;
      int index2 = 1;
      SqlParameter sqlParameter2 = new SqlParameter("@ID", SqlDbType.UniqueIdentifier);
      sqlParameter2.Value = (object) id;
      sqlParameterArray[index2] = sqlParameter2;
      SqlParameter[] parameter = sqlParameterArray;
      return this.dbHelper.Execute(sql, parameter, false);
    }

    public RoadFlow.Data.Model.Dictionary GetByCode(string code)
    {
      string sql = "SELECT * FROM Dictionary WHERE Code=@Code";
      SqlParameter[] sqlParameterArray = new SqlParameter[1];
      int index = 0;
      SqlParameter sqlParameter = new SqlParameter("@Code", SqlDbType.VarChar);
      sqlParameter.Value = (object) code;
      sqlParameterArray[index] = sqlParameter;
      SqlParameter[] parameter = sqlParameterArray;
      SqlDataReader dataReader = this.dbHelper.GetDataReader(sql, parameter);
      List<RoadFlow.Data.Model.Dictionary> list = this.DataReaderToList(dataReader);
      dataReader.Close();
      if (list.Count <= 0)
        return (RoadFlow.Data.Model.Dictionary) null;
      return list[0];
    }
  }
}
