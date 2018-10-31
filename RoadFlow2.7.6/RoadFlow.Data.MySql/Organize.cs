// Decompiled with JetBrains decompiler
// Type: RoadFlow.Data.MySql.Organize
// Assembly: RoadFlow.Data.MySql, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 29B652D7-5F6F-4A7D-AD1C-9F2C643FD784
// Assembly location: C:\inetpub\wwwroot\RoadFlowMvc\bin\RoadFlow.Data.MySql.dll

using MySql.Data.MySqlClient;
using RoadFlow.Data.Interface;
using RoadFlow.Utility;
using System;
using System.Collections.Generic;

namespace RoadFlow.Data.MySql
{
  public class Organize : IOrganize
  {
    private DBHelper dbHelper = new DBHelper();

    public int Add(RoadFlow.Data.Model.Organize model)
    {
      string sql = "INSERT INTO organize\r\n\t\t\t\t(ID,Name,Number,Type,Status,ParentID,Sort,Depth,ChildsLength,ChargeLeader,Leader,Note,IntID) \r\n\t\t\t\tVALUES(@ID,@Name,@Number,@Type,@Status,@ParentID,@Sort,@Depth,@ChildsLength,@ChargeLeader,@Leader,@Note,@IntID)";
      MySqlParameter[] mySqlParameterArray = new MySqlParameter[13];
      int index1 = 0;
      MySqlParameter mySqlParameter1 = new MySqlParameter("@ID", MySqlDbType.VarChar, 36);
      mySqlParameter1.Value = (object) model.ID;
      mySqlParameterArray[index1] = mySqlParameter1;
      int index2 = 1;
      MySqlParameter mySqlParameter2 = new MySqlParameter("@Name", MySqlDbType.Text, -1);
      mySqlParameter2.Value = (object) model.Name;
      mySqlParameterArray[index2] = mySqlParameter2;
      int index3 = 2;
      MySqlParameter mySqlParameter3 = new MySqlParameter("@Number", MySqlDbType.Text, -1);
      mySqlParameter3.Value = (object) model.Number;
      mySqlParameterArray[index3] = mySqlParameter3;
      int index4 = 3;
      MySqlParameter mySqlParameter4 = new MySqlParameter("@Type", MySqlDbType.Int32, 11);
      mySqlParameter4.Value = (object) model.Type;
      mySqlParameterArray[index4] = mySqlParameter4;
      int index5 = 4;
      MySqlParameter mySqlParameter5 = new MySqlParameter("@Status", MySqlDbType.Int32, 11);
      mySqlParameter5.Value = (object) model.Status;
      mySqlParameterArray[index5] = mySqlParameter5;
      int index6 = 5;
      MySqlParameter mySqlParameter6 = new MySqlParameter("@ParentID", MySqlDbType.VarChar, 36);
      mySqlParameter6.Value = (object) model.ParentID;
      mySqlParameterArray[index6] = mySqlParameter6;
      int index7 = 6;
      MySqlParameter mySqlParameter7 = new MySqlParameter("@Sort", MySqlDbType.Int32, 11);
      mySqlParameter7.Value = (object) model.Sort;
      mySqlParameterArray[index7] = mySqlParameter7;
      int index8 = 7;
      MySqlParameter mySqlParameter8 = new MySqlParameter("@Depth", MySqlDbType.Int32, 11);
      mySqlParameter8.Value = (object) model.Depth;
      mySqlParameterArray[index8] = mySqlParameter8;
      int index9 = 8;
      MySqlParameter mySqlParameter9 = new MySqlParameter("@ChildsLength", MySqlDbType.Int32, 11);
      mySqlParameter9.Value = (object) model.ChildsLength;
      mySqlParameterArray[index9] = mySqlParameter9;
      int index10 = 9;
      MySqlParameter mySqlParameter10;
      if (model.ChargeLeader != null)
      {
        MySqlParameter mySqlParameter11 = new MySqlParameter("@ChargeLeader", MySqlDbType.VarChar, 200);
        mySqlParameter11.Value = (object) model.ChargeLeader;
        mySqlParameter10 = mySqlParameter11;
      }
      else
      {
        mySqlParameter10 = new MySqlParameter("@ChargeLeader", MySqlDbType.VarChar, 200);
        mySqlParameter10.Value = (object) DBNull.Value;
      }
      mySqlParameterArray[index10] = mySqlParameter10;
      int index11 = 10;
      MySqlParameter mySqlParameter12;
      if (model.Leader != null)
      {
        MySqlParameter mySqlParameter11 = new MySqlParameter("@Leader", MySqlDbType.VarChar, 200);
        mySqlParameter11.Value = (object) model.Leader;
        mySqlParameter12 = mySqlParameter11;
      }
      else
      {
        mySqlParameter12 = new MySqlParameter("@Leader", MySqlDbType.VarChar, 200);
        mySqlParameter12.Value = (object) DBNull.Value;
      }
      mySqlParameterArray[index11] = mySqlParameter12;
      int index12 = 11;
      MySqlParameter mySqlParameter13;
      if (model.Note != null)
      {
        MySqlParameter mySqlParameter11 = new MySqlParameter("@Note", MySqlDbType.LongText, -1);
        mySqlParameter11.Value = (object) model.Note;
        mySqlParameter13 = mySqlParameter11;
      }
      else
      {
        mySqlParameter13 = new MySqlParameter("@Note", MySqlDbType.LongText, -1);
        mySqlParameter13.Value = (object) DBNull.Value;
      }
      mySqlParameterArray[index12] = mySqlParameter13;
      int index13 = 12;
      MySqlParameter mySqlParameter14 = new MySqlParameter("@IntID", MySqlDbType.Int32, 11);
      mySqlParameter14.Value = (object) model.IntID;
      mySqlParameterArray[index13] = mySqlParameter14;
      MySqlParameter[] parameter = mySqlParameterArray;
      return this.dbHelper.Execute(sql, parameter, false);
    }

    public int Update(RoadFlow.Data.Model.Organize model)
    {
      string sql = "UPDATE organize SET \r\n\t\t\t\tName=@Name,Number=@Number,Type=@Type,Status=@Status,ParentID=@ParentID,Sort=@Sort,Depth=@Depth,ChildsLength=@ChildsLength,ChargeLeader=@ChargeLeader,Leader=@Leader,Note=@Note,IntID=@IntID \r\n\t\t\t\tWHERE ID=@ID";
      MySqlParameter[] mySqlParameterArray = new MySqlParameter[13];
      int index1 = 0;
      MySqlParameter mySqlParameter1 = new MySqlParameter("@Name", MySqlDbType.Text, -1);
      mySqlParameter1.Value = (object) model.Name;
      mySqlParameterArray[index1] = mySqlParameter1;
      int index2 = 1;
      MySqlParameter mySqlParameter2 = new MySqlParameter("@Number", MySqlDbType.Text, -1);
      mySqlParameter2.Value = (object) model.Number;
      mySqlParameterArray[index2] = mySqlParameter2;
      int index3 = 2;
      MySqlParameter mySqlParameter3 = new MySqlParameter("@Type", MySqlDbType.Int32, 11);
      mySqlParameter3.Value = (object) model.Type;
      mySqlParameterArray[index3] = mySqlParameter3;
      int index4 = 3;
      MySqlParameter mySqlParameter4 = new MySqlParameter("@Status", MySqlDbType.Int32, 11);
      mySqlParameter4.Value = (object) model.Status;
      mySqlParameterArray[index4] = mySqlParameter4;
      int index5 = 4;
      MySqlParameter mySqlParameter5 = new MySqlParameter("@ParentID", MySqlDbType.VarChar, 36);
      mySqlParameter5.Value = (object) model.ParentID;
      mySqlParameterArray[index5] = mySqlParameter5;
      int index6 = 5;
      MySqlParameter mySqlParameter6 = new MySqlParameter("@Sort", MySqlDbType.Int32, 11);
      mySqlParameter6.Value = (object) model.Sort;
      mySqlParameterArray[index6] = mySqlParameter6;
      int index7 = 6;
      MySqlParameter mySqlParameter7 = new MySqlParameter("@Depth", MySqlDbType.Int32, 11);
      mySqlParameter7.Value = (object) model.Depth;
      mySqlParameterArray[index7] = mySqlParameter7;
      int index8 = 7;
      MySqlParameter mySqlParameter8 = new MySqlParameter("@ChildsLength", MySqlDbType.Int32, 11);
      mySqlParameter8.Value = (object) model.ChildsLength;
      mySqlParameterArray[index8] = mySqlParameter8;
      int index9 = 8;
      MySqlParameter mySqlParameter9;
      if (model.ChargeLeader != null)
      {
        MySqlParameter mySqlParameter10 = new MySqlParameter("@ChargeLeader", MySqlDbType.VarChar, 200);
        mySqlParameter10.Value = (object) model.ChargeLeader;
        mySqlParameter9 = mySqlParameter10;
      }
      else
      {
        mySqlParameter9 = new MySqlParameter("@ChargeLeader", MySqlDbType.VarChar, 200);
        mySqlParameter9.Value = (object) DBNull.Value;
      }
      mySqlParameterArray[index9] = mySqlParameter9;
      int index10 = 9;
      MySqlParameter mySqlParameter11;
      if (model.Leader != null)
      {
        MySqlParameter mySqlParameter10 = new MySqlParameter("@Leader", MySqlDbType.VarChar, 200);
        mySqlParameter10.Value = (object) model.Leader;
        mySqlParameter11 = mySqlParameter10;
      }
      else
      {
        mySqlParameter11 = new MySqlParameter("@Leader", MySqlDbType.VarChar, 200);
        mySqlParameter11.Value = (object) DBNull.Value;
      }
      mySqlParameterArray[index10] = mySqlParameter11;
      int index11 = 10;
      MySqlParameter mySqlParameter12;
      if (model.Note != null)
      {
        MySqlParameter mySqlParameter10 = new MySqlParameter("@Note", MySqlDbType.LongText, -1);
        mySqlParameter10.Value = (object) model.Note;
        mySqlParameter12 = mySqlParameter10;
      }
      else
      {
        mySqlParameter12 = new MySqlParameter("@Note", MySqlDbType.LongText, -1);
        mySqlParameter12.Value = (object) DBNull.Value;
      }
      mySqlParameterArray[index11] = mySqlParameter12;
      int index12 = 11;
      MySqlParameter mySqlParameter13 = new MySqlParameter("@IntID", MySqlDbType.Int32, 11);
      mySqlParameter13.Value = (object) model.IntID;
      mySqlParameterArray[index12] = mySqlParameter13;
      int index13 = 12;
      MySqlParameter mySqlParameter14 = new MySqlParameter("@ID", MySqlDbType.VarChar, 36);
      mySqlParameter14.Value = (object) model.ID;
      mySqlParameterArray[index13] = mySqlParameter14;
      MySqlParameter[] parameter = mySqlParameterArray;
      return this.dbHelper.Execute(sql, parameter, false);
    }

    public int Delete(Guid id)
    {
      string sql = "DELETE FROM organize WHERE ID=@ID";
      MySqlParameter[] mySqlParameterArray = new MySqlParameter[1];
      int index = 0;
      MySqlParameter mySqlParameter = new MySqlParameter("@ID", MySqlDbType.VarChar, 36);
      mySqlParameter.Value = (object) id.ToString();
      mySqlParameterArray[index] = mySqlParameter;
      MySqlParameter[] parameter = mySqlParameterArray;
      return this.dbHelper.Execute(sql, parameter, false);
    }

    private List<RoadFlow.Data.Model.Organize> DataReaderToList(MySqlDataReader dataReader)
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
      MySqlDataReader dataReader = this.dbHelper.GetDataReader("SELECT * FROM organize");
      List<RoadFlow.Data.Model.Organize> list = this.DataReaderToList(dataReader);
      dataReader.Close();
      return list;
    }

    public long GetCount()
    {
      long result;
      if (!long.TryParse(this.dbHelper.GetFieldValue("SELECT COUNT(*) FROM organize"), out result))
        return 0;
      return result;
    }

    public RoadFlow.Data.Model.Organize Get(Guid id)
    {
      string sql = "SELECT * FROM organize WHERE ID=@ID";
      MySqlParameter[] mySqlParameterArray = new MySqlParameter[1];
      int index = 0;
      MySqlParameter mySqlParameter = new MySqlParameter("@ID", MySqlDbType.VarChar, 36);
      mySqlParameter.Value = (object) id.ToString();
      mySqlParameterArray[index] = mySqlParameter;
      MySqlParameter[] parameter = mySqlParameterArray;
      MySqlDataReader dataReader = this.dbHelper.GetDataReader(sql, parameter);
      List<RoadFlow.Data.Model.Organize> list = this.DataReaderToList(dataReader);
      dataReader.Close();
      if (list.Count <= 0)
        return (RoadFlow.Data.Model.Organize) null;
      return list[0];
    }

    public RoadFlow.Data.Model.Organize GetRoot()
    {
      string sql = "SELECT * FROM Organize WHERE ParentID=@ParentID";
      MySqlParameter[] mySqlParameterArray = new MySqlParameter[1];
      int index = 0;
      MySqlParameter mySqlParameter = new MySqlParameter("@ParentID", MySqlDbType.VarChar);
      mySqlParameter.Value = (object) Guid.Empty.ToString();
      mySqlParameterArray[index] = mySqlParameter;
      MySqlParameter[] parameter = mySqlParameterArray;
      MySqlDataReader dataReader = this.dbHelper.GetDataReader(sql, parameter);
      List<RoadFlow.Data.Model.Organize> list = this.DataReaderToList(dataReader);
      dataReader.Close();
      if (list.Count <= 0)
        return (RoadFlow.Data.Model.Organize) null;
      return list[0];
    }

    public List<RoadFlow.Data.Model.Organize> GetChilds(Guid ID)
    {
      string sql = "SELECT * FROM Organize WHERE ParentID=@ParentID ORDER BY Sort";
      MySqlParameter[] mySqlParameterArray = new MySqlParameter[1];
      int index = 0;
      MySqlParameter mySqlParameter = new MySqlParameter("@ParentID", MySqlDbType.VarChar);
      mySqlParameter.Value = (object) ID;
      mySqlParameterArray[index] = mySqlParameter;
      MySqlParameter[] parameter = mySqlParameterArray;
      MySqlDataReader dataReader = this.dbHelper.GetDataReader(sql, parameter);
      List<RoadFlow.Data.Model.Organize> list = this.DataReaderToList(dataReader);
      dataReader.Close();
      return list;
    }

    public int GetMaxSort(Guid id)
    {
      string sql = "SELECT IFNULL(MAX(Sort),0)+1 FROM Organize WHERE ParentID=@ParentID";
      MySqlParameter[] mySqlParameterArray = new MySqlParameter[1];
      int index = 0;
      MySqlParameter mySqlParameter = new MySqlParameter("@ParentID", MySqlDbType.VarChar);
      mySqlParameter.Value = (object) id;
      mySqlParameterArray[index] = mySqlParameter;
      MySqlParameter[] parameter = mySqlParameterArray;
      return this.dbHelper.GetFieldValue(sql, parameter).ToInt();
    }

    public int UpdateChildsLength(Guid id, int length)
    {
      string sql = "UPDATE Organize SET ChildsLength=@ChildsLength WHERE ID=@ID";
      MySqlParameter[] mySqlParameterArray = new MySqlParameter[2];
      int index1 = 0;
      MySqlParameter mySqlParameter1 = new MySqlParameter("@ChildsLength", MySqlDbType.Int32);
      mySqlParameter1.Value = (object) length;
      mySqlParameterArray[index1] = mySqlParameter1;
      int index2 = 1;
      MySqlParameter mySqlParameter2 = new MySqlParameter("@ID", MySqlDbType.VarChar);
      mySqlParameter2.Value = (object) id;
      mySqlParameterArray[index2] = mySqlParameter2;
      MySqlParameter[] parameter = mySqlParameterArray;
      return this.dbHelper.Execute(sql, parameter, false);
    }

    public int UpdateSort(Guid id, int sort)
    {
      string sql = "UPDATE Organize SET Sort=@Sort WHERE ID=@ID";
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

    public List<RoadFlow.Data.Model.Organize> GetAllParent(string number)
    {
      MySqlDataReader dataReader = this.dbHelper.GetDataReader("SELECT * FROM Organize WHERE ID IN(" + Tools.GetSqlInString(number, true, ",") + ") ORDER BY Depth");
      List<RoadFlow.Data.Model.Organize> list = this.DataReaderToList(dataReader);
      dataReader.Close();
      return list;
    }

    public List<RoadFlow.Data.Model.Organize> GetAllChild(string number)
    {
      MySqlDataReader dataReader = this.dbHelper.GetDataReader("SELECT * FROM Organize WHERE Number LIKE '" + number.ReplaceSql() + "%' ORDER BY Sort");
      List<RoadFlow.Data.Model.Organize> list = this.DataReaderToList(dataReader);
      dataReader.Close();
      return list;
    }
  }
}
