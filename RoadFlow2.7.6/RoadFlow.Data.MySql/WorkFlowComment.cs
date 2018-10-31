// Decompiled with JetBrains decompiler
// Type: RoadFlow.Data.MySql.WorkFlowComment
// Assembly: RoadFlow.Data.MySql, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 29B652D7-5F6F-4A7D-AD1C-9F2C643FD784
// Assembly location: C:\inetpub\wwwroot\RoadFlowMvc\bin\RoadFlow.Data.MySql.dll

using MySql.Data.MySqlClient;
using RoadFlow.Data.Interface;
using System;
using System.Collections.Generic;

namespace RoadFlow.Data.MySql
{
  public class WorkFlowComment : IWorkFlowComment
  {
    private DBHelper dbHelper = new DBHelper();

    public int Add(RoadFlow.Data.Model.WorkFlowComment model)
    {
      string sql = "INSERT INTO workflowcomment\r\n\t\t\t\t(ID,MemberID,Comment,Type,Sort) \r\n\t\t\t\tVALUES(@ID,@MemberID,@Comment,@Type,@Sort)";
      MySqlParameter[] mySqlParameterArray = new MySqlParameter[5];
      int index1 = 0;
      MySqlParameter mySqlParameter1 = new MySqlParameter("@ID", MySqlDbType.VarChar, 36);
      mySqlParameter1.Value = (object) model.ID;
      mySqlParameterArray[index1] = mySqlParameter1;
      int index2 = 1;
      MySqlParameter mySqlParameter2 = new MySqlParameter("@MemberID", MySqlDbType.LongText, -1);
      mySqlParameter2.Value = (object) model.MemberID;
      mySqlParameterArray[index2] = mySqlParameter2;
      int index3 = 2;
      MySqlParameter mySqlParameter3 = new MySqlParameter("@Comment", MySqlDbType.Text, -1);
      mySqlParameter3.Value = (object) model.Comment;
      mySqlParameterArray[index3] = mySqlParameter3;
      int index4 = 3;
      MySqlParameter mySqlParameter4 = new MySqlParameter("@Type", MySqlDbType.Int32, 11);
      mySqlParameter4.Value = (object) model.Type;
      mySqlParameterArray[index4] = mySqlParameter4;
      int index5 = 4;
      MySqlParameter mySqlParameter5 = new MySqlParameter("@Sort", MySqlDbType.Int32, 11);
      mySqlParameter5.Value = (object) model.Sort;
      mySqlParameterArray[index5] = mySqlParameter5;
      MySqlParameter[] parameter = mySqlParameterArray;
      return this.dbHelper.Execute(sql, parameter, false);
    }

    public int Update(RoadFlow.Data.Model.WorkFlowComment model)
    {
      string sql = "UPDATE workflowcomment SET \r\n\t\t\t\tMemberID=@MemberID,Comment=@Comment,Type=@Type,Sort=@Sort\r\n\t\t\t\tWHERE ID=@ID";
      MySqlParameter[] mySqlParameterArray = new MySqlParameter[5];
      int index1 = 0;
      MySqlParameter mySqlParameter1 = new MySqlParameter("@MemberID", MySqlDbType.LongText, -1);
      mySqlParameter1.Value = (object) model.MemberID;
      mySqlParameterArray[index1] = mySqlParameter1;
      int index2 = 1;
      MySqlParameter mySqlParameter2 = new MySqlParameter("@Comment", MySqlDbType.Text, -1);
      mySqlParameter2.Value = (object) model.Comment;
      mySqlParameterArray[index2] = mySqlParameter2;
      int index3 = 2;
      MySqlParameter mySqlParameter3 = new MySqlParameter("@Type", MySqlDbType.Int32, 11);
      mySqlParameter3.Value = (object) model.Type;
      mySqlParameterArray[index3] = mySqlParameter3;
      int index4 = 3;
      MySqlParameter mySqlParameter4 = new MySqlParameter("@Sort", MySqlDbType.Int32, 11);
      mySqlParameter4.Value = (object) model.Sort;
      mySqlParameterArray[index4] = mySqlParameter4;
      int index5 = 4;
      MySqlParameter mySqlParameter5 = new MySqlParameter("@ID", MySqlDbType.VarChar, 36);
      mySqlParameter5.Value = (object) model.ID;
      mySqlParameterArray[index5] = mySqlParameter5;
      MySqlParameter[] parameter = mySqlParameterArray;
      return this.dbHelper.Execute(sql, parameter, false);
    }

    public int Delete(Guid id)
    {
      string sql = "DELETE FROM workflowcomment WHERE ID=@ID";
      MySqlParameter[] mySqlParameterArray = new MySqlParameter[1];
      int index = 0;
      MySqlParameter mySqlParameter = new MySqlParameter("@ID", MySqlDbType.VarChar, 36);
      mySqlParameter.Value = (object) id.ToString();
      mySqlParameterArray[index] = mySqlParameter;
      MySqlParameter[] parameter = mySqlParameterArray;
      return this.dbHelper.Execute(sql, parameter, false);
    }

    private List<RoadFlow.Data.Model.WorkFlowComment> DataReaderToList(MySqlDataReader dataReader)
    {
      List<RoadFlow.Data.Model.WorkFlowComment> workFlowCommentList = new List<RoadFlow.Data.Model.WorkFlowComment>();
      while (dataReader.Read())
        workFlowCommentList.Add(new RoadFlow.Data.Model.WorkFlowComment()
        {
          ID = dataReader.GetString(0).ToGuid(),
          MemberID = dataReader.GetString(1),
          Comment = dataReader.GetString(2),
          Type = dataReader.GetInt32(3),
          Sort = dataReader.GetInt32(4)
        });
      return workFlowCommentList;
    }

    public List<RoadFlow.Data.Model.WorkFlowComment> GetAll()
    {
      MySqlDataReader dataReader = this.dbHelper.GetDataReader("SELECT * FROM workflowcomment");
      List<RoadFlow.Data.Model.WorkFlowComment> list = this.DataReaderToList(dataReader);
      dataReader.Close();
      return list;
    }

    public long GetCount()
    {
      long result;
      if (!long.TryParse(this.dbHelper.GetFieldValue("SELECT COUNT(*) FROM workflowcomment"), out result))
        return 0;
      return result;
    }

    public RoadFlow.Data.Model.WorkFlowComment Get(Guid id)
    {
      string sql = "SELECT * FROM workflowcomment WHERE ID=@ID";
      MySqlParameter[] mySqlParameterArray = new MySqlParameter[1];
      int index = 0;
      MySqlParameter mySqlParameter = new MySqlParameter("@ID", MySqlDbType.VarChar, 36);
      mySqlParameter.Value = (object) id.ToString();
      mySqlParameterArray[index] = mySqlParameter;
      MySqlParameter[] parameter = mySqlParameterArray;
      MySqlDataReader dataReader = this.dbHelper.GetDataReader(sql, parameter);
      List<RoadFlow.Data.Model.WorkFlowComment> list = this.DataReaderToList(dataReader);
      dataReader.Close();
      if (list.Count <= 0)
        return (RoadFlow.Data.Model.WorkFlowComment) null;
      return list[0];
    }

    public List<RoadFlow.Data.Model.WorkFlowComment> GetManagerAll()
    {
      MySqlDataReader dataReader = this.dbHelper.GetDataReader("SELECT * FROM WorkFlowComment WHERE Type=0");
      List<RoadFlow.Data.Model.WorkFlowComment> list = this.DataReaderToList(dataReader);
      dataReader.Close();
      return list;
    }

    public int GetManagerMaxSort()
    {
      MySqlDataReader dataReader = this.dbHelper.GetDataReader("SELECT IFNULL(MAX(Sort)+1,1) FROM WorkFlowComment WHERE Type=0");
      if (!dataReader.HasRows)
        return 1;
      dataReader.Read();
      int int32 = dataReader.GetInt32(0);
      dataReader.Close();
      return int32;
    }

    public int GetUserMaxSort(Guid userID)
    {
      string sql = "SELECT IFNULL(MAX(Sort)+1,1) FROM WorkFlowComment WHERE MemberID=@MemberID";
      MySqlParameter[] mySqlParameterArray = new MySqlParameter[1];
      int index = 0;
      MySqlParameter mySqlParameter = new MySqlParameter("@MemberID", MySqlDbType.VarChar);
      mySqlParameter.Value = (object) userID.ToString();
      mySqlParameterArray[index] = mySqlParameter;
      MySqlParameter[] parameter = mySqlParameterArray;
      MySqlDataReader dataReader = this.dbHelper.GetDataReader(sql, parameter);
      if (!dataReader.HasRows)
        return 1;
      dataReader.Read();
      int int32 = dataReader.GetInt32(0);
      dataReader.Close();
      return int32;
    }
  }
}
