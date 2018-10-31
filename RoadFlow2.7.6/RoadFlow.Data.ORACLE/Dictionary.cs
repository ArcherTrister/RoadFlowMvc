// Decompiled with JetBrains decompiler
// Type: RoadFlow.Data.ORACLE.Dictionary
// Assembly: RoadFlow.Data.ORACLE, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: C9018AA1-E48E-4231-92A9-CD6F0F275D11
// Assembly location: C:\inetpub\wwwroot\RoadFlowMvc\bin\RoadFlow.Data.ORACLE.dll

using Oracle.ManagedDataAccess.Client;
using RoadFlow.Data.Interface;
using System;
using System.Collections.Generic;

namespace RoadFlow.Data.ORACLE
{
  public class Dictionary : IDictionary
  {
    private DBHelper dbHelper = new DBHelper();

    public int Add(RoadFlow.Data.Model.Dictionary model)
    {
      string sql = "INSERT INTO Dictionary\r\n\t\t\t\t(ID,ParentID,Title,Code,Value,Note,Other,Sort) \r\n\t\t\t\tVALUES(:ID,:ParentID,:Title,:Code,:Value,:Note,:Other,:Sort)";
      OracleParameter[] oracleParameterArray = new OracleParameter[8];
      int index1 = 0;
      OracleParameter oracleParameter1 = new OracleParameter(":ID", OracleDbType.Varchar2, 40);
      oracleParameter1.Value = (object) model.ID;
      oracleParameterArray[index1] = oracleParameter1;
      int index2 = 1;
      OracleParameter oracleParameter2 = new OracleParameter(":ParentID", OracleDbType.Varchar2, 40);
      oracleParameter2.Value = (object) model.ParentID;
      oracleParameterArray[index2] = oracleParameter2;
      int index3 = 2;
      OracleParameter oracleParameter3 = new OracleParameter(":Title", OracleDbType.NVarchar2);
      oracleParameter3.Value = (object) model.Title;
      oracleParameterArray[index3] = oracleParameter3;
      int index4 = 3;
      OracleParameter oracleParameter4;
      if (model.Code != null)
      {
        OracleParameter oracleParameter5 = new OracleParameter(":Code", OracleDbType.Varchar2, 500);
        oracleParameter5.Value = (object) model.Code;
        oracleParameter4 = oracleParameter5;
      }
      else
      {
        oracleParameter4 = new OracleParameter(":Code", OracleDbType.Varchar2, 500);
        oracleParameter4.Value = (object) DBNull.Value;
      }
      oracleParameterArray[index4] = oracleParameter4;
      int index5 = 4;
      OracleParameter oracleParameter6;
      if (model.Value != null)
      {
        OracleParameter oracleParameter5 = new OracleParameter(":Value", OracleDbType.Clob);
        oracleParameter5.Value = (object) model.Value;
        oracleParameter6 = oracleParameter5;
      }
      else
      {
        oracleParameter6 = new OracleParameter(":Value", OracleDbType.Clob);
        oracleParameter6.Value = (object) DBNull.Value;
      }
      oracleParameterArray[index5] = oracleParameter6;
      int index6 = 5;
      OracleParameter oracleParameter7;
      if (model.Note != null)
      {
        OracleParameter oracleParameter5 = new OracleParameter(":Note", OracleDbType.Clob);
        oracleParameter5.Value = (object) model.Note;
        oracleParameter7 = oracleParameter5;
      }
      else
      {
        oracleParameter7 = new OracleParameter(":Note", OracleDbType.Clob);
        oracleParameter7.Value = (object) DBNull.Value;
      }
      oracleParameterArray[index6] = oracleParameter7;
      int index7 = 6;
      OracleParameter oracleParameter8;
      if (model.Other != null)
      {
        OracleParameter oracleParameter5 = new OracleParameter(":Other", OracleDbType.Clob);
        oracleParameter5.Value = (object) model.Other;
        oracleParameter8 = oracleParameter5;
      }
      else
      {
        oracleParameter8 = new OracleParameter(":Other", OracleDbType.Clob);
        oracleParameter8.Value = (object) DBNull.Value;
      }
      oracleParameterArray[index7] = oracleParameter8;
      int index8 = 7;
      OracleParameter oracleParameter9 = new OracleParameter(":Sort", OracleDbType.Int32);
      oracleParameter9.Value = (object) model.Sort;
      oracleParameterArray[index8] = oracleParameter9;
      OracleParameter[] parameter = oracleParameterArray;
      return this.dbHelper.Execute(sql, parameter);
    }

    public int Update(RoadFlow.Data.Model.Dictionary model)
    {
      string sql = "UPDATE Dictionary SET \r\n\t\t\t\tParentID=:ParentID,Title=:Title,Code=:Code,Value=:Value,Note=:Note,Other=:Other,Sort=:Sort\r\n\t\t\t\tWHERE ID=:ID";
      OracleParameter[] oracleParameterArray = new OracleParameter[8];
      int index1 = 0;
      OracleParameter oracleParameter1 = new OracleParameter(":ParentID", OracleDbType.Varchar2, 40);
      oracleParameter1.Value = (object) model.ParentID;
      oracleParameterArray[index1] = oracleParameter1;
      int index2 = 1;
      OracleParameter oracleParameter2 = new OracleParameter(":Title", OracleDbType.NVarchar2);
      oracleParameter2.Value = (object) model.Title;
      oracleParameterArray[index2] = oracleParameter2;
      int index3 = 2;
      OracleParameter oracleParameter3;
      if (model.Code != null)
      {
        OracleParameter oracleParameter4 = new OracleParameter(":Code", OracleDbType.Varchar2, 500);
        oracleParameter4.Value = (object) model.Code;
        oracleParameter3 = oracleParameter4;
      }
      else
      {
        oracleParameter3 = new OracleParameter(":Code", OracleDbType.Varchar2, 500);
        oracleParameter3.Value = (object) DBNull.Value;
      }
      oracleParameterArray[index3] = oracleParameter3;
      int index4 = 3;
      OracleParameter oracleParameter5;
      if (model.Value != null)
      {
        OracleParameter oracleParameter4 = new OracleParameter(":Value", OracleDbType.Clob);
        oracleParameter4.Value = (object) model.Value;
        oracleParameter5 = oracleParameter4;
      }
      else
      {
        oracleParameter5 = new OracleParameter(":Value", OracleDbType.Clob);
        oracleParameter5.Value = (object) DBNull.Value;
      }
      oracleParameterArray[index4] = oracleParameter5;
      int index5 = 4;
      OracleParameter oracleParameter6;
      if (model.Note != null)
      {
        OracleParameter oracleParameter4 = new OracleParameter(":Note", OracleDbType.Clob);
        oracleParameter4.Value = (object) model.Note;
        oracleParameter6 = oracleParameter4;
      }
      else
      {
        oracleParameter6 = new OracleParameter(":Note", OracleDbType.Clob);
        oracleParameter6.Value = (object) DBNull.Value;
      }
      oracleParameterArray[index5] = oracleParameter6;
      int index6 = 5;
      OracleParameter oracleParameter7;
      if (model.Other != null)
      {
        OracleParameter oracleParameter4 = new OracleParameter(":Other", OracleDbType.Clob);
        oracleParameter4.Value = (object) model.Other;
        oracleParameter7 = oracleParameter4;
      }
      else
      {
        oracleParameter7 = new OracleParameter(":Other", OracleDbType.Clob);
        oracleParameter7.Value = (object) DBNull.Value;
      }
      oracleParameterArray[index6] = oracleParameter7;
      int index7 = 6;
      OracleParameter oracleParameter8 = new OracleParameter(":Sort", OracleDbType.Int32);
      oracleParameter8.Value = (object) model.Sort;
      oracleParameterArray[index7] = oracleParameter8;
      int index8 = 7;
      OracleParameter oracleParameter9 = new OracleParameter(":ID", OracleDbType.Varchar2, 40);
      oracleParameter9.Value = (object) model.ID;
      oracleParameterArray[index8] = oracleParameter9;
      OracleParameter[] parameter = oracleParameterArray;
      return this.dbHelper.Execute(sql, parameter);
    }

    public int Delete(Guid id)
    {
      string sql = "DELETE FROM Dictionary WHERE ID=:ID";
      OracleParameter[] oracleParameterArray = new OracleParameter[1];
      int index = 0;
      OracleParameter oracleParameter = new OracleParameter(":ID", OracleDbType.Varchar2);
      oracleParameter.Value = (object) id;
      oracleParameterArray[index] = oracleParameter;
      OracleParameter[] parameter = oracleParameterArray;
      return this.dbHelper.Execute(sql, parameter);
    }

    private List<RoadFlow.Data.Model.Dictionary> DataReaderToList(OracleDataReader dataReader)
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
      OracleDataReader dataReader = this.dbHelper.GetDataReader("SELECT * FROM Dictionary");
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
      string sql = "SELECT * FROM Dictionary WHERE ID=:ID";
      OracleParameter[] oracleParameterArray = new OracleParameter[1];
      int index = 0;
      OracleParameter oracleParameter = new OracleParameter(":ID", OracleDbType.Varchar2);
      oracleParameter.Value = (object) id;
      oracleParameterArray[index] = oracleParameter;
      OracleParameter[] parameter = oracleParameterArray;
      OracleDataReader dataReader = this.dbHelper.GetDataReader(sql, parameter);
      List<RoadFlow.Data.Model.Dictionary> list = this.DataReaderToList(dataReader);
      dataReader.Close();
      if (list.Count <= 0)
        return (RoadFlow.Data.Model.Dictionary) null;
      return list[0];
    }

    public RoadFlow.Data.Model.Dictionary GetRoot()
    {
      string sql = "SELECT * FROM Dictionary WHERE ParentID=:ParentID";
      OracleParameter[] oracleParameterArray = new OracleParameter[1];
      int index = 0;
      OracleParameter oracleParameter = new OracleParameter(":ParentID", OracleDbType.Varchar2);
      oracleParameter.Value = (object) Guid.Empty;
      oracleParameterArray[index] = oracleParameter;
      OracleParameter[] parameter = oracleParameterArray;
      OracleDataReader dataReader = this.dbHelper.GetDataReader(sql, parameter);
      List<RoadFlow.Data.Model.Dictionary> list = this.DataReaderToList(dataReader);
      dataReader.Close();
      if (list.Count <= 0)
        return (RoadFlow.Data.Model.Dictionary) null;
      return list[0];
    }

    public List<RoadFlow.Data.Model.Dictionary> GetChilds(Guid id)
    {
      string sql = "SELECT * FROM Dictionary WHERE ParentID=:ParentID ORDER BY Sort";
      OracleParameter[] oracleParameterArray = new OracleParameter[1];
      int index = 0;
      OracleParameter oracleParameter = new OracleParameter(":ParentID", OracleDbType.Varchar2);
      oracleParameter.Value = (object) id;
      oracleParameterArray[index] = oracleParameter;
      OracleParameter[] parameter = oracleParameterArray;
      OracleDataReader dataReader = this.dbHelper.GetDataReader(sql, parameter);
      List<RoadFlow.Data.Model.Dictionary> list = this.DataReaderToList(dataReader);
      dataReader.Close();
      return list;
    }

    public List<RoadFlow.Data.Model.Dictionary> GetChilds(string code)
    {
      string sql = "SELECT * FROM Dictionary WHERE ParentID=(SELECT ID FROM Dictionary WHERE Code=:Code) ORDER BY Sort";
      OracleParameter[] oracleParameterArray = new OracleParameter[1];
      int index = 0;
      OracleParameter oracleParameter = new OracleParameter(":Code", OracleDbType.Varchar2);
      oracleParameter.Value = (object) code;
      oracleParameterArray[index] = oracleParameter;
      OracleParameter[] parameter = oracleParameterArray;
      OracleDataReader dataReader = this.dbHelper.GetDataReader(sql, parameter);
      List<RoadFlow.Data.Model.Dictionary> list = this.DataReaderToList(dataReader);
      dataReader.Close();
      return list;
    }

    public RoadFlow.Data.Model.Dictionary GetParent(Guid id)
    {
      string sql = "SELECT * FROM Dictionary WHERE ID=(SELECT ParentID FROM Dictionary WHERE ID=:ID)";
      OracleParameter[] oracleParameterArray = new OracleParameter[1];
      int index = 0;
      OracleParameter oracleParameter = new OracleParameter(":ID", OracleDbType.Varchar2);
      oracleParameter.Value = (object) id;
      oracleParameterArray[index] = oracleParameter;
      OracleParameter[] parameter = oracleParameterArray;
      OracleDataReader dataReader = this.dbHelper.GetDataReader(sql, parameter);
      List<RoadFlow.Data.Model.Dictionary> list = this.DataReaderToList(dataReader);
      dataReader.Close();
      if (list.Count <= 0)
        return (RoadFlow.Data.Model.Dictionary) null;
      return list[0];
    }

    public bool HasChilds(Guid id)
    {
      string sql = "SELECT ID FROM Dictionary WHERE ParentID=:ParentID";
      OracleParameter[] oracleParameterArray = new OracleParameter[1];
      int index = 0;
      OracleParameter oracleParameter = new OracleParameter(":ParentID", OracleDbType.Varchar2);
      oracleParameter.Value = (object) id;
      oracleParameterArray[index] = oracleParameter;
      OracleParameter[] parameter = oracleParameterArray;
      OracleDataReader dataReader = this.dbHelper.GetDataReader(sql, parameter);
      bool hasRows = dataReader.HasRows;
      dataReader.Close();
      return hasRows;
    }

    public int GetMaxSort(Guid id)
    {
      string sql = "SELECT MAX(Sort)+1 FROM Dictionary WHERE ParentID=:ParentID";
      OracleParameter[] oracleParameterArray = new OracleParameter[1];
      int index = 0;
      OracleParameter oracleParameter = new OracleParameter(":ParentID", OracleDbType.Varchar2);
      oracleParameter.Value = (object) id;
      oracleParameterArray[index] = oracleParameter;
      OracleParameter[] parameter = oracleParameterArray;
      int test;
      if (!this.dbHelper.GetFieldValue(sql, parameter).IsInt(out test))
        return 1;
      return test;
    }

    public int UpdateSort(Guid id, int sort)
    {
      string sql = "UPDATE Dictionary SET Sort=:Sort WHERE ID=:ID";
      OracleParameter[] oracleParameterArray = new OracleParameter[2];
      int index1 = 0;
      OracleParameter oracleParameter1 = new OracleParameter(":Sort", OracleDbType.Int32);
      oracleParameter1.Value = (object) sort;
      oracleParameterArray[index1] = oracleParameter1;
      int index2 = 1;
      OracleParameter oracleParameter2 = new OracleParameter(":ID", OracleDbType.Varchar2);
      oracleParameter2.Value = (object) id;
      oracleParameterArray[index2] = oracleParameter2;
      OracleParameter[] parameter = oracleParameterArray;
      return this.dbHelper.Execute(sql, parameter);
    }

    public RoadFlow.Data.Model.Dictionary GetByCode(string code)
    {
      string sql = "SELECT * FROM Dictionary WHERE Code=:Code";
      OracleParameter[] oracleParameterArray = new OracleParameter[1];
      int index = 0;
      OracleParameter oracleParameter = new OracleParameter(":Code", OracleDbType.Varchar2);
      oracleParameter.Value = (object) code;
      oracleParameterArray[index] = oracleParameter;
      OracleParameter[] parameter = oracleParameterArray;
      OracleDataReader dataReader = this.dbHelper.GetDataReader(sql, parameter);
      List<RoadFlow.Data.Model.Dictionary> list = this.DataReaderToList(dataReader);
      dataReader.Close();
      if (list.Count <= 0)
        return (RoadFlow.Data.Model.Dictionary) null;
      return list[0];
    }
  }
}
