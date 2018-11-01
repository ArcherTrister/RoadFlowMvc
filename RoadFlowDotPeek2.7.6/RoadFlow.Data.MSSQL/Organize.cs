// Decompiled with JetBrains decompiler
// Type: RoadFlow.Data.MSSQL.Organize
// Assembly: RoadFlow.Data.MSSQL, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 5107CDC7-8F84-4EE0-AC6D-E80FE4695340
// Assembly location: C:\inetpub\wwwroot\RoadFlowMvc\bin\RoadFlow.Data.MSSQL.dll

using RoadFlow.Data.Interface;
using RoadFlow.Utility;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;

namespace RoadFlow.Data.MSSQL
{
  public class Organize : IOrganize
  {
    private DBHelper dbHelper = new DBHelper();

    public int Add(RoadFlow.Data.Model.Organize model)
    {
      string sql = "INSERT INTO Organize\r\n\t\t\t\t(ID,Name,Number,Type,Status,ParentID,Sort,Depth,ChildsLength,ChargeLeader,Leader,Note,IntID) \r\n\t\t\t\tVALUES(@ID,@Name,@Number,@Type,@Status,@ParentID,@Sort,@Depth,@ChildsLength,@ChargeLeader,@Leader,@Note,@IntID)";
      SqlParameter[] sqlParameterArray = new SqlParameter[13];
      int index1 = 0;
      SqlParameter sqlParameter1 = new SqlParameter("@ID", SqlDbType.UniqueIdentifier, -1);
      sqlParameter1.Value = (object) model.ID;
      sqlParameterArray[index1] = sqlParameter1;
      int index2 = 1;
      SqlParameter sqlParameter2 = new SqlParameter("@Name", SqlDbType.VarChar, 2000);
      sqlParameter2.Value = (object) model.Name;
      sqlParameterArray[index2] = sqlParameter2;
      int index3 = 2;
      SqlParameter sqlParameter3 = new SqlParameter("@Number", SqlDbType.VarChar, 900);
      sqlParameter3.Value = (object) model.Number;
      sqlParameterArray[index3] = sqlParameter3;
      int index4 = 3;
      SqlParameter sqlParameter4 = new SqlParameter("@Type", SqlDbType.Int, -1);
      sqlParameter4.Value = (object) model.Type;
      sqlParameterArray[index4] = sqlParameter4;
      int index5 = 4;
      SqlParameter sqlParameter5 = new SqlParameter("@Status", SqlDbType.Int, -1);
      sqlParameter5.Value = (object) model.Status;
      sqlParameterArray[index5] = sqlParameter5;
      int index6 = 5;
      SqlParameter sqlParameter6 = new SqlParameter("@ParentID", SqlDbType.UniqueIdentifier, -1);
      sqlParameter6.Value = (object) model.ParentID;
      sqlParameterArray[index6] = sqlParameter6;
      int index7 = 6;
      SqlParameter sqlParameter7 = new SqlParameter("@Sort", SqlDbType.Int, -1);
      sqlParameter7.Value = (object) model.Sort;
      sqlParameterArray[index7] = sqlParameter7;
      int index8 = 7;
      SqlParameter sqlParameter8 = new SqlParameter("@Depth", SqlDbType.Int, -1);
      sqlParameter8.Value = (object) model.Depth;
      sqlParameterArray[index8] = sqlParameter8;
      int index9 = 8;
      SqlParameter sqlParameter9 = new SqlParameter("@ChildsLength", SqlDbType.Int, -1);
      sqlParameter9.Value = (object) model.ChildsLength;
      sqlParameterArray[index9] = sqlParameter9;
      int index10 = 9;
      SqlParameter sqlParameter10;
      if (model.ChargeLeader != null)
      {
        SqlParameter sqlParameter11 = new SqlParameter("@ChargeLeader", SqlDbType.VarChar, 200);
        sqlParameter11.Value = (object) model.ChargeLeader;
        sqlParameter10 = sqlParameter11;
      }
      else
      {
        sqlParameter10 = new SqlParameter("@ChargeLeader", SqlDbType.VarChar, 200);
        sqlParameter10.Value = (object) DBNull.Value;
      }
      sqlParameterArray[index10] = sqlParameter10;
      int index11 = 10;
      SqlParameter sqlParameter12;
      if (model.Leader != null)
      {
        SqlParameter sqlParameter11 = new SqlParameter("@Leader", SqlDbType.VarChar, 200);
        sqlParameter11.Value = (object) model.Leader;
        sqlParameter12 = sqlParameter11;
      }
      else
      {
        sqlParameter12 = new SqlParameter("@Leader", SqlDbType.VarChar, 200);
        sqlParameter12.Value = (object) DBNull.Value;
      }
      sqlParameterArray[index11] = sqlParameter12;
      int index12 = 11;
      SqlParameter sqlParameter13;
      if (model.Note != null)
      {
        SqlParameter sqlParameter11 = new SqlParameter("@Note", SqlDbType.NVarChar, -1);
        sqlParameter11.Value = (object) model.Note;
        sqlParameter13 = sqlParameter11;
      }
      else
      {
        sqlParameter13 = new SqlParameter("@Note", SqlDbType.NVarChar, -1);
        sqlParameter13.Value = (object) DBNull.Value;
      }
      sqlParameterArray[index12] = sqlParameter13;
      int index13 = 12;
      SqlParameter sqlParameter14 = new SqlParameter("@IntID", SqlDbType.Int, -1);
      sqlParameter14.Value = (object) model.IntID;
      sqlParameterArray[index13] = sqlParameter14;
      SqlParameter[] parameter = sqlParameterArray;
      return this.dbHelper.Execute(sql, parameter, false);
    }

    public int Update(RoadFlow.Data.Model.Organize model)
    {
      string sql = "UPDATE Organize SET \r\n\t\t\t\tName=@Name,Number=@Number,Type=@Type,Status=@Status,ParentID=@ParentID,Sort=@Sort,Depth=@Depth,ChildsLength=@ChildsLength,ChargeLeader=@ChargeLeader,Leader=@Leader,Note=@Note,IntID=@IntID \r\n\t\t\t\tWHERE ID=@ID";
      SqlParameter[] sqlParameterArray = new SqlParameter[13];
      int index1 = 0;
      SqlParameter sqlParameter1 = new SqlParameter("@Name", SqlDbType.VarChar, 2000);
      sqlParameter1.Value = (object) model.Name;
      sqlParameterArray[index1] = sqlParameter1;
      int index2 = 1;
      SqlParameter sqlParameter2 = new SqlParameter("@Number", SqlDbType.VarChar, 900);
      sqlParameter2.Value = (object) model.Number;
      sqlParameterArray[index2] = sqlParameter2;
      int index3 = 2;
      SqlParameter sqlParameter3 = new SqlParameter("@Type", SqlDbType.Int, -1);
      sqlParameter3.Value = (object) model.Type;
      sqlParameterArray[index3] = sqlParameter3;
      int index4 = 3;
      SqlParameter sqlParameter4 = new SqlParameter("@Status", SqlDbType.Int, -1);
      sqlParameter4.Value = (object) model.Status;
      sqlParameterArray[index4] = sqlParameter4;
      int index5 = 4;
      SqlParameter sqlParameter5 = new SqlParameter("@ParentID", SqlDbType.UniqueIdentifier, -1);
      sqlParameter5.Value = (object) model.ParentID;
      sqlParameterArray[index5] = sqlParameter5;
      int index6 = 5;
      SqlParameter sqlParameter6 = new SqlParameter("@Sort", SqlDbType.Int, -1);
      sqlParameter6.Value = (object) model.Sort;
      sqlParameterArray[index6] = sqlParameter6;
      int index7 = 6;
      SqlParameter sqlParameter7 = new SqlParameter("@Depth", SqlDbType.Int, -1);
      sqlParameter7.Value = (object) model.Depth;
      sqlParameterArray[index7] = sqlParameter7;
      int index8 = 7;
      SqlParameter sqlParameter8 = new SqlParameter("@ChildsLength", SqlDbType.Int, -1);
      sqlParameter8.Value = (object) model.ChildsLength;
      sqlParameterArray[index8] = sqlParameter8;
      int index9 = 8;
      SqlParameter sqlParameter9;
      if (model.ChargeLeader != null)
      {
        SqlParameter sqlParameter10 = new SqlParameter("@ChargeLeader", SqlDbType.VarChar, 200);
        sqlParameter10.Value = (object) model.ChargeLeader;
        sqlParameter9 = sqlParameter10;
      }
      else
      {
        sqlParameter9 = new SqlParameter("@ChargeLeader", SqlDbType.VarChar, 200);
        sqlParameter9.Value = (object) DBNull.Value;
      }
      sqlParameterArray[index9] = sqlParameter9;
      int index10 = 9;
      SqlParameter sqlParameter11;
      if (model.Leader != null)
      {
        SqlParameter sqlParameter10 = new SqlParameter("@Leader", SqlDbType.VarChar, 200);
        sqlParameter10.Value = (object) model.Leader;
        sqlParameter11 = sqlParameter10;
      }
      else
      {
        sqlParameter11 = new SqlParameter("@Leader", SqlDbType.VarChar, 200);
        sqlParameter11.Value = (object) DBNull.Value;
      }
      sqlParameterArray[index10] = sqlParameter11;
      int index11 = 10;
      SqlParameter sqlParameter12;
      if (model.Note != null)
      {
        SqlParameter sqlParameter10 = new SqlParameter("@Note", SqlDbType.NVarChar, -1);
        sqlParameter10.Value = (object) model.Note;
        sqlParameter12 = sqlParameter10;
      }
      else
      {
        sqlParameter12 = new SqlParameter("@Note", SqlDbType.NVarChar, -1);
        sqlParameter12.Value = (object) DBNull.Value;
      }
      sqlParameterArray[index11] = sqlParameter12;
      int index12 = 11;
      SqlParameter sqlParameter13 = new SqlParameter("@IntID", SqlDbType.Int, -1);
      sqlParameter13.Value = (object) model.IntID;
      sqlParameterArray[index12] = sqlParameter13;
      int index13 = 12;
      SqlParameter sqlParameter14 = new SqlParameter("@ID", SqlDbType.UniqueIdentifier, -1);
      sqlParameter14.Value = (object) model.ID;
      sqlParameterArray[index13] = sqlParameter14;
      SqlParameter[] parameter = sqlParameterArray;
      return this.dbHelper.Execute(sql, parameter, false);
    }

    public int Delete(Guid id)
    {
      string sql = "DELETE FROM Organize WHERE ID=@ID";
      SqlParameter[] sqlParameterArray = new SqlParameter[1];
      int index = 0;
      SqlParameter sqlParameter = new SqlParameter("@ID", SqlDbType.UniqueIdentifier);
      sqlParameter.Value = (object) id;
      sqlParameterArray[index] = sqlParameter;
      SqlParameter[] parameter = sqlParameterArray;
      return this.dbHelper.Execute(sql, parameter, false);
    }

    private List<RoadFlow.Data.Model.Organize> DataReaderToList(SqlDataReader dataReader)
    {
      List<RoadFlow.Data.Model.Organize> organizeList = new List<RoadFlow.Data.Model.Organize>();
      while (dataReader.Read())
      {
        RoadFlow.Data.Model.Organize organize = new RoadFlow.Data.Model.Organize();
        organize.ID = dataReader.GetGuid(0);
        organize.Name = dataReader.GetString(1);
        organize.Number = dataReader.GetString(2);
        organize.Type = dataReader.GetInt32(3);
        organize.Status = dataReader.GetInt32(4);
        organize.ParentID = dataReader.GetGuid(5);
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
      SqlDataReader dataReader = this.dbHelper.GetDataReader("SELECT * FROM Organize");
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
      string sql = "SELECT * FROM Organize WHERE ID=@ID";
      SqlParameter[] sqlParameterArray = new SqlParameter[1];
      int index = 0;
      SqlParameter sqlParameter = new SqlParameter("@ID", SqlDbType.UniqueIdentifier);
      sqlParameter.Value = (object) id;
      sqlParameterArray[index] = sqlParameter;
      SqlParameter[] parameter = sqlParameterArray;
      SqlDataReader dataReader = this.dbHelper.GetDataReader(sql, parameter);
      List<RoadFlow.Data.Model.Organize> list = this.DataReaderToList(dataReader);
      dataReader.Close();
      if (list.Count <= 0)
        return (RoadFlow.Data.Model.Organize) null;
      return list[0];
    }

    public RoadFlow.Data.Model.Organize GetRoot()
    {
      string sql = "SELECT * FROM Organize WHERE ParentID=@ParentID";
      SqlParameter[] sqlParameterArray = new SqlParameter[1];
      int index = 0;
      SqlParameter sqlParameter = new SqlParameter("@ParentID", SqlDbType.UniqueIdentifier);
      sqlParameter.Value = (object) Guid.Empty;
      sqlParameterArray[index] = sqlParameter;
      SqlParameter[] parameter = sqlParameterArray;
      SqlDataReader dataReader = this.dbHelper.GetDataReader(sql, parameter);
      List<RoadFlow.Data.Model.Organize> list = this.DataReaderToList(dataReader);
      dataReader.Close();
      if (list.Count <= 0)
        return (RoadFlow.Data.Model.Organize) null;
      return list[0];
    }

    public List<RoadFlow.Data.Model.Organize> GetChilds(Guid ID)
    {
      string sql = "SELECT * FROM Organize WHERE ParentID=@ParentID ORDER BY Sort";
      SqlParameter[] sqlParameterArray = new SqlParameter[1];
      int index = 0;
      SqlParameter sqlParameter = new SqlParameter("@ParentID", SqlDbType.UniqueIdentifier);
      sqlParameter.Value = (object) ID;
      sqlParameterArray[index] = sqlParameter;
      SqlParameter[] parameter = sqlParameterArray;
      SqlDataReader dataReader = this.dbHelper.GetDataReader(sql, parameter);
      List<RoadFlow.Data.Model.Organize> list = this.DataReaderToList(dataReader);
      dataReader.Close();
      return list;
    }

    public int GetMaxSort(Guid id)
    {
      string sql = "SELECT ISNULL(MAX(Sort),0)+1 FROM Organize WHERE ParentID=@ParentID";
      SqlParameter[] sqlParameterArray = new SqlParameter[1];
      int index = 0;
      SqlParameter sqlParameter = new SqlParameter("@ParentID", SqlDbType.UniqueIdentifier);
      sqlParameter.Value = (object) id;
      sqlParameterArray[index] = sqlParameter;
      SqlParameter[] parameter = sqlParameterArray;
      return this.dbHelper.GetFieldValue(sql, parameter).ToInt();
    }

    public int UpdateChildsLength(Guid id, int length)
    {
      string sql = "UPDATE Organize SET ChildsLength=@ChildsLength WHERE ID=@ID";
      SqlParameter[] sqlParameterArray = new SqlParameter[2];
      int index1 = 0;
      SqlParameter sqlParameter1 = new SqlParameter("@ChildsLength", SqlDbType.Int);
      sqlParameter1.Value = (object) length;
      sqlParameterArray[index1] = sqlParameter1;
      int index2 = 1;
      SqlParameter sqlParameter2 = new SqlParameter("@ID", SqlDbType.UniqueIdentifier);
      sqlParameter2.Value = (object) id;
      sqlParameterArray[index2] = sqlParameter2;
      SqlParameter[] parameter = sqlParameterArray;
      return this.dbHelper.Execute(sql, parameter, false);
    }

    public int UpdateSort(Guid id, int sort)
    {
      string sql = "UPDATE Organize SET Sort=@Sort WHERE ID=@ID";
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

    public List<RoadFlow.Data.Model.Organize> GetAllParent(string number)
    {
      SqlDataReader dataReader = this.dbHelper.GetDataReader("SELECT * FROM Organize WHERE ID IN(" + Tools.GetSqlInString(number, true, ",") + ") ORDER BY Depth");
      List<RoadFlow.Data.Model.Organize> list = this.DataReaderToList(dataReader);
      dataReader.Close();
      return list;
    }

    public List<RoadFlow.Data.Model.Organize> GetAllChild(string number)
    {
      SqlDataReader dataReader = this.dbHelper.GetDataReader("SELECT * FROM Organize WHERE Number LIKE '" + number.ReplaceSql() + "%' ORDER BY Sort");
      List<RoadFlow.Data.Model.Organize> list = this.DataReaderToList(dataReader);
      dataReader.Close();
      return list;
    }
  }
}
