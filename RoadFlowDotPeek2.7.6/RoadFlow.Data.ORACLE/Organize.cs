// Decompiled with JetBrains decompiler
// Type: RoadFlow.Data.ORACLE.Organize
// Assembly: RoadFlow.Data.ORACLE, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: C9018AA1-E48E-4231-92A9-CD6F0F275D11
// Assembly location: C:\inetpub\wwwroot\RoadFlowMvc\bin\RoadFlow.Data.ORACLE.dll

using Oracle.ManagedDataAccess.Client;
using RoadFlow.Data.Interface;
using RoadFlow.Utility;
using System;
using System.Collections.Generic;

namespace RoadFlow.Data.ORACLE
{
  public class Organize : IOrganize
  {
    private DBHelper dbHelper = new DBHelper();

    public int Add(RoadFlow.Data.Model.Organize model)
    {
      string sql = "INSERT INTO Organize\r\n\t\t\t\t(ID,Name,Number1,Type,Status,ParentID,Sort,Depth,ChildsLength,ChargeLeader,Leader,Note,IntID) \r\n\t\t\t\tVALUES(:ID,:Name,:Number1,:Type,:Status,:ParentID,:Sort,:Depth,:ChildsLength,:ChargeLeader,:Leader,:Note,:IntID)";
      OracleParameter[] oracleParameterArray = new OracleParameter[13];
      int index1 = 0;
      OracleParameter oracleParameter1 = new OracleParameter(":ID", OracleDbType.Varchar2, 40);
      oracleParameter1.Value = (object) model.ID;
      oracleParameterArray[index1] = oracleParameter1;
      int index2 = 1;
      OracleParameter oracleParameter2 = new OracleParameter(":Name", OracleDbType.Varchar2, 2000);
      oracleParameter2.Value = (object) model.Name;
      oracleParameterArray[index2] = oracleParameter2;
      int index3 = 2;
      OracleParameter oracleParameter3 = new OracleParameter(":Number1", OracleDbType.Varchar2, 900);
      oracleParameter3.Value = (object) model.Number;
      oracleParameterArray[index3] = oracleParameter3;
      int index4 = 3;
      OracleParameter oracleParameter4 = new OracleParameter(":Type", OracleDbType.Int32);
      oracleParameter4.Value = (object) model.Type;
      oracleParameterArray[index4] = oracleParameter4;
      int index5 = 4;
      OracleParameter oracleParameter5 = new OracleParameter(":Status", OracleDbType.Int32);
      oracleParameter5.Value = (object) model.Status;
      oracleParameterArray[index5] = oracleParameter5;
      int index6 = 5;
      OracleParameter oracleParameter6 = new OracleParameter(":ParentID", OracleDbType.Varchar2, 40);
      oracleParameter6.Value = (object) model.ParentID;
      oracleParameterArray[index6] = oracleParameter6;
      int index7 = 6;
      OracleParameter oracleParameter7 = new OracleParameter(":Sort", OracleDbType.Int32);
      oracleParameter7.Value = (object) model.Sort;
      oracleParameterArray[index7] = oracleParameter7;
      int index8 = 7;
      OracleParameter oracleParameter8 = new OracleParameter(":Depth", OracleDbType.Int32);
      oracleParameter8.Value = (object) model.Depth;
      oracleParameterArray[index8] = oracleParameter8;
      int index9 = 8;
      OracleParameter oracleParameter9 = new OracleParameter(":ChildsLength", OracleDbType.Int32);
      oracleParameter9.Value = (object) model.ChildsLength;
      oracleParameterArray[index9] = oracleParameter9;
      int index10 = 9;
      OracleParameter oracleParameter10;
      if (model.ChargeLeader != null)
      {
        OracleParameter oracleParameter11 = new OracleParameter(":ChargeLeader", OracleDbType.Varchar2, 200);
        oracleParameter11.Value = (object) model.ChargeLeader;
        oracleParameter10 = oracleParameter11;
      }
      else
      {
        oracleParameter10 = new OracleParameter(":ChargeLeader", OracleDbType.Varchar2, 200);
        oracleParameter10.Value = (object) DBNull.Value;
      }
      oracleParameterArray[index10] = oracleParameter10;
      int index11 = 10;
      OracleParameter oracleParameter12;
      if (model.Leader != null)
      {
        OracleParameter oracleParameter11 = new OracleParameter(":Leader", OracleDbType.Varchar2, 200);
        oracleParameter11.Value = (object) model.Leader;
        oracleParameter12 = oracleParameter11;
      }
      else
      {
        oracleParameter12 = new OracleParameter(":Leader", OracleDbType.Varchar2, 200);
        oracleParameter12.Value = (object) DBNull.Value;
      }
      oracleParameterArray[index11] = oracleParameter12;
      int index12 = 11;
      OracleParameter oracleParameter13;
      if (model.Note != null)
      {
        OracleParameter oracleParameter11 = new OracleParameter(":Note", OracleDbType.NVarchar2);
        oracleParameter11.Value = (object) model.Note;
        oracleParameter13 = oracleParameter11;
      }
      else
      {
        oracleParameter13 = new OracleParameter(":Note", OracleDbType.NVarchar2);
        oracleParameter13.Value = (object) DBNull.Value;
      }
      oracleParameterArray[index12] = oracleParameter13;
      int index13 = 12;
      OracleParameter oracleParameter14 = new OracleParameter(":IntID", OracleDbType.Int32);
      oracleParameter14.Value = (object) model.IntID;
      oracleParameterArray[index13] = oracleParameter14;
      OracleParameter[] parameter = oracleParameterArray;
      return this.dbHelper.Execute(sql, parameter);
    }

    public int Update(RoadFlow.Data.Model.Organize model)
    {
      string sql = "UPDATE Organize SET \r\n\t\t\t\tName=:Name,Number1=:Number1,Type=:Type,Status=:Status,ParentID=:ParentID,Sort=:Sort,Depth=:Depth,ChildsLength=:ChildsLength,ChargeLeader=:ChargeLeader,Leader=:Leader,Note=:Note,IntID=:IntID\r\n\t\t\t\tWHERE ID=:ID";
      OracleParameter[] oracleParameterArray = new OracleParameter[13];
      int index1 = 0;
      OracleParameter oracleParameter1 = new OracleParameter(":Name", OracleDbType.Varchar2, 2000);
      oracleParameter1.Value = (object) model.Name;
      oracleParameterArray[index1] = oracleParameter1;
      int index2 = 1;
      OracleParameter oracleParameter2 = new OracleParameter(":Number1", OracleDbType.Varchar2, 900);
      oracleParameter2.Value = (object) model.Number;
      oracleParameterArray[index2] = oracleParameter2;
      int index3 = 2;
      OracleParameter oracleParameter3 = new OracleParameter(":Type", OracleDbType.Int32);
      oracleParameter3.Value = (object) model.Type;
      oracleParameterArray[index3] = oracleParameter3;
      int index4 = 3;
      OracleParameter oracleParameter4 = new OracleParameter(":Status", OracleDbType.Int32);
      oracleParameter4.Value = (object) model.Status;
      oracleParameterArray[index4] = oracleParameter4;
      int index5 = 4;
      OracleParameter oracleParameter5 = new OracleParameter(":ParentID", OracleDbType.Varchar2, 40);
      oracleParameter5.Value = (object) model.ParentID;
      oracleParameterArray[index5] = oracleParameter5;
      int index6 = 5;
      OracleParameter oracleParameter6 = new OracleParameter(":Sort", OracleDbType.Int32);
      oracleParameter6.Value = (object) model.Sort;
      oracleParameterArray[index6] = oracleParameter6;
      int index7 = 6;
      OracleParameter oracleParameter7 = new OracleParameter(":Depth", OracleDbType.Int32);
      oracleParameter7.Value = (object) model.Depth;
      oracleParameterArray[index7] = oracleParameter7;
      int index8 = 7;
      OracleParameter oracleParameter8 = new OracleParameter(":ChildsLength", OracleDbType.Int32);
      oracleParameter8.Value = (object) model.ChildsLength;
      oracleParameterArray[index8] = oracleParameter8;
      int index9 = 8;
      OracleParameter oracleParameter9;
      if (model.ChargeLeader != null)
      {
        OracleParameter oracleParameter10 = new OracleParameter(":ChargeLeader", OracleDbType.Varchar2, 200);
        oracleParameter10.Value = (object) model.ChargeLeader;
        oracleParameter9 = oracleParameter10;
      }
      else
      {
        oracleParameter9 = new OracleParameter(":ChargeLeader", OracleDbType.Varchar2, 200);
        oracleParameter9.Value = (object) DBNull.Value;
      }
      oracleParameterArray[index9] = oracleParameter9;
      int index10 = 9;
      OracleParameter oracleParameter11;
      if (model.Leader != null)
      {
        OracleParameter oracleParameter10 = new OracleParameter(":Leader", OracleDbType.Varchar2, 200);
        oracleParameter10.Value = (object) model.Leader;
        oracleParameter11 = oracleParameter10;
      }
      else
      {
        oracleParameter11 = new OracleParameter(":Leader", OracleDbType.Varchar2, 200);
        oracleParameter11.Value = (object) DBNull.Value;
      }
      oracleParameterArray[index10] = oracleParameter11;
      int index11 = 10;
      OracleParameter oracleParameter12;
      if (model.Note != null)
      {
        OracleParameter oracleParameter10 = new OracleParameter(":Note", OracleDbType.NVarchar2);
        oracleParameter10.Value = (object) model.Note;
        oracleParameter12 = oracleParameter10;
      }
      else
      {
        oracleParameter12 = new OracleParameter(":Note", OracleDbType.NVarchar2);
        oracleParameter12.Value = (object) DBNull.Value;
      }
      oracleParameterArray[index11] = oracleParameter12;
      int index12 = 11;
      OracleParameter oracleParameter13 = new OracleParameter(":IntID", OracleDbType.Int32);
      oracleParameter13.Value = (object) model.IntID;
      oracleParameterArray[index12] = oracleParameter13;
      int index13 = 12;
      OracleParameter oracleParameter14 = new OracleParameter(":ID", OracleDbType.Varchar2, 40);
      oracleParameter14.Value = (object) model.ID;
      oracleParameterArray[index13] = oracleParameter14;
      OracleParameter[] parameter = oracleParameterArray;
      return this.dbHelper.Execute(sql, parameter);
    }

    public int Delete(Guid id)
    {
      string sql = "DELETE FROM Organize WHERE ID=:ID";
      OracleParameter[] oracleParameterArray = new OracleParameter[1];
      int index = 0;
      OracleParameter oracleParameter = new OracleParameter(":ID", OracleDbType.Varchar2);
      oracleParameter.Value = (object) id;
      oracleParameterArray[index] = oracleParameter;
      OracleParameter[] parameter = oracleParameterArray;
      return this.dbHelper.Execute(sql, parameter);
    }

    private List<RoadFlow.Data.Model.Organize> DataReaderToList(OracleDataReader dataReader)
    {
      List<RoadFlow.Data.Model.Organize> organizeList = new List<RoadFlow.Data.Model.Organize>();
      while (dataReader.Read())
      {
        RoadFlow.Data.Model.Organize organize = new RoadFlow.Data.Model.Organize();
        organize.ID = dataReader.GetString(0).ToGuid();
        organize.Name = dataReader.GetString(1);
        organize.Number = dataReader.GetString(2);
        organize.Type = dataReader.GetInt32(3);
        organize.Status = dataReader.GetInt32(4);
        organize.ParentID = dataReader.GetString(5).ToGuid();
        organize.Sort = dataReader.GetInt32(6);
        organize.Depth = dataReader.GetInt32(7);
        organize.ChildsLength = dataReader.GetInt32(8);
        if (!dataReader.IsDBNull(9))
          organize.ChargeLeader = dataReader.GetString(9);
        if (!dataReader.IsDBNull(10))
          organize.Leader = dataReader.GetString(10);
        if (!dataReader.IsDBNull(11))
          organize.Note = dataReader.GetString(11);
        organize.IntID = dataReader.GetInt32(12);
        organizeList.Add(organize);
      }
      return organizeList;
    }

    public List<RoadFlow.Data.Model.Organize> GetAll()
    {
      OracleDataReader dataReader = this.dbHelper.GetDataReader("SELECT * FROM Organize");
      List<RoadFlow.Data.Model.Organize> list = this.DataReaderToList(dataReader);
      dataReader.Close();
      return list;
    }

    public long GetCount()
    {
      long result;
      if (!long.TryParse(this.dbHelper.GetFieldValue("SELECT COUNT(*) FROM Organize"), out result))
        return 0;
      return result;
    }

    public RoadFlow.Data.Model.Organize Get(Guid id)
    {
      string sql = "SELECT * FROM Organize WHERE ID=:ID";
      OracleParameter[] oracleParameterArray = new OracleParameter[1];
      int index = 0;
      OracleParameter oracleParameter = new OracleParameter(":ID", OracleDbType.Varchar2);
      oracleParameter.Value = (object) id;
      oracleParameterArray[index] = oracleParameter;
      OracleParameter[] parameter = oracleParameterArray;
      OracleDataReader dataReader = this.dbHelper.GetDataReader(sql, parameter);
      List<RoadFlow.Data.Model.Organize> list = this.DataReaderToList(dataReader);
      dataReader.Close();
      if (list.Count <= 0)
        return (RoadFlow.Data.Model.Organize) null;
      return list[0];
    }

    public RoadFlow.Data.Model.Organize GetRoot()
    {
      string sql = "SELECT * FROM Organize WHERE ParentID=:ParentID";
      OracleParameter[] oracleParameterArray = new OracleParameter[1];
      int index = 0;
      OracleParameter oracleParameter = new OracleParameter(":ParentID", OracleDbType.Varchar2);
      oracleParameter.Value = (object) Guid.Empty;
      oracleParameterArray[index] = oracleParameter;
      OracleParameter[] parameter = oracleParameterArray;
      OracleDataReader dataReader = this.dbHelper.GetDataReader(sql, parameter);
      List<RoadFlow.Data.Model.Organize> list = this.DataReaderToList(dataReader);
      dataReader.Close();
      if (list.Count <= 0)
        return (RoadFlow.Data.Model.Organize) null;
      return list[0];
    }

    public List<RoadFlow.Data.Model.Organize> GetChilds(Guid ID)
    {
      string sql = "SELECT * FROM Organize WHERE ParentID=:ParentID ORDER BY Sort";
      OracleParameter[] oracleParameterArray = new OracleParameter[1];
      int index = 0;
      OracleParameter oracleParameter = new OracleParameter(":ParentID", OracleDbType.Varchar2);
      oracleParameter.Value = (object) ID;
      oracleParameterArray[index] = oracleParameter;
      OracleParameter[] parameter = oracleParameterArray;
      OracleDataReader dataReader = this.dbHelper.GetDataReader(sql, parameter);
      List<RoadFlow.Data.Model.Organize> list = this.DataReaderToList(dataReader);
      dataReader.Close();
      return list;
    }

    public int GetMaxSort(Guid id)
    {
      string sql = "SELECT nvl(MAX(Sort),0)+1 FROM Organize WHERE ParentID=:ParentID";
      OracleParameter[] oracleParameterArray = new OracleParameter[1];
      int index = 0;
      OracleParameter oracleParameter = new OracleParameter(":ParentID", OracleDbType.Varchar2);
      oracleParameter.Value = (object) id;
      oracleParameterArray[index] = oracleParameter;
      OracleParameter[] parameter = oracleParameterArray;
      return this.dbHelper.GetFieldValue(sql, parameter).ToInt();
    }

    public int UpdateChildsLength(Guid id, int length)
    {
      string sql = "UPDATE Organize SET ChildsLength=:ChildsLength WHERE ID=:ID";
      OracleParameter[] oracleParameterArray = new OracleParameter[2];
      int index1 = 0;
      OracleParameter oracleParameter1 = new OracleParameter(":ChildsLength", OracleDbType.Int32);
      oracleParameter1.Value = (object) length;
      oracleParameterArray[index1] = oracleParameter1;
      int index2 = 1;
      OracleParameter oracleParameter2 = new OracleParameter(":ID", OracleDbType.Varchar2);
      oracleParameter2.Value = (object) id;
      oracleParameterArray[index2] = oracleParameter2;
      OracleParameter[] parameter = oracleParameterArray;
      return this.dbHelper.Execute(sql, parameter);
    }

    public int UpdateSort(Guid id, int sort)
    {
      string sql = "UPDATE Organize SET Sort=:Sort WHERE ID=:ID";
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

    public List<RoadFlow.Data.Model.Organize> GetAllParent(string number)
    {
      OracleDataReader dataReader = this.dbHelper.GetDataReader("SELECT * FROM Organize WHERE ID IN(" + Tools.GetSqlInString(number, true, ",") + ") ORDER BY Depth");
      List<RoadFlow.Data.Model.Organize> list = this.DataReaderToList(dataReader);
      dataReader.Close();
      return list;
    }

    public List<RoadFlow.Data.Model.Organize> GetAllChild(string number)
    {
      OracleDataReader dataReader = this.dbHelper.GetDataReader("SELECT * FROM Organize WHERE NUMBER1 LIKE '" + number.ReplaceSql() + "%' ORDER BY Sort");
      List<RoadFlow.Data.Model.Organize> list = this.DataReaderToList(dataReader);
      dataReader.Close();
      return list;
    }
  }
}
