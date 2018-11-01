// Decompiled with JetBrains decompiler
// Type: RoadFlow.Data.MSSQL.WorkFlowComment
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
  public class WorkFlowComment : IWorkFlowComment
  {
    private DBHelper dbHelper = new DBHelper();

    public int Add(RoadFlow.Data.Model.WorkFlowComment model)
    {
      string sql = "INSERT INTO WorkFlowComment\r\n\t\t\t\t(ID,MemberID,Comment,Type,Sort) \r\n\t\t\t\tVALUES(@ID,@MemberID,@Comment,@Type,@Sort)";
      SqlParameter[] sqlParameterArray = new SqlParameter[5];
      int index1 = 0;
      SqlParameter sqlParameter1 = new SqlParameter("@ID", SqlDbType.UniqueIdentifier, -1);
      sqlParameter1.Value = (object) model.ID;
      sqlParameterArray[index1] = sqlParameter1;
      int index2 = 1;
      SqlParameter sqlParameter2 = new SqlParameter("@MemberID", SqlDbType.VarChar, -1);
      sqlParameter2.Value = (object) model.MemberID;
      sqlParameterArray[index2] = sqlParameter2;
      int index3 = 2;
      SqlParameter sqlParameter3 = new SqlParameter("@Comment", SqlDbType.NVarChar, 1000);
      sqlParameter3.Value = (object) model.Comment;
      sqlParameterArray[index3] = sqlParameter3;
      int index4 = 3;
      SqlParameter sqlParameter4 = new SqlParameter("@Type", SqlDbType.Int, -1);
      sqlParameter4.Value = (object) model.Type;
      sqlParameterArray[index4] = sqlParameter4;
      int index5 = 4;
      SqlParameter sqlParameter5 = new SqlParameter("@Sort", SqlDbType.Int, -1);
      sqlParameter5.Value = (object) model.Sort;
      sqlParameterArray[index5] = sqlParameter5;
      SqlParameter[] parameter = sqlParameterArray;
      return this.dbHelper.Execute(sql, parameter, false);
    }

    public int Update(RoadFlow.Data.Model.WorkFlowComment model)
    {
      string sql = "UPDATE WorkFlowComment SET \r\n\t\t\t\tMemberID=@MemberID,Comment=@Comment,Type=@Type,Sort=@Sort\r\n\t\t\t\tWHERE ID=@ID";
      SqlParameter[] sqlParameterArray = new SqlParameter[5];
      int index1 = 0;
      SqlParameter sqlParameter1 = new SqlParameter("@MemberID", SqlDbType.VarChar, -1);
      sqlParameter1.Value = (object) model.MemberID;
      sqlParameterArray[index1] = sqlParameter1;
      int index2 = 1;
      SqlParameter sqlParameter2 = new SqlParameter("@Comment", SqlDbType.NVarChar, 1000);
      sqlParameter2.Value = (object) model.Comment;
      sqlParameterArray[index2] = sqlParameter2;
      int index3 = 2;
      SqlParameter sqlParameter3 = new SqlParameter("@Type", SqlDbType.Int, -1);
      sqlParameter3.Value = (object) model.Type;
      sqlParameterArray[index3] = sqlParameter3;
      int index4 = 3;
      SqlParameter sqlParameter4 = new SqlParameter("@Sort", SqlDbType.Int, -1);
      sqlParameter4.Value = (object) model.Sort;
      sqlParameterArray[index4] = sqlParameter4;
      int index5 = 4;
      SqlParameter sqlParameter5 = new SqlParameter("@ID", SqlDbType.UniqueIdentifier, -1);
      sqlParameter5.Value = (object) model.ID;
      sqlParameterArray[index5] = sqlParameter5;
      SqlParameter[] parameter = sqlParameterArray;
      return this.dbHelper.Execute(sql, parameter, false);
    }

    public int Delete(Guid id)
    {
      string sql = "DELETE FROM WorkFlowComment WHERE ID=@ID";
      SqlParameter[] sqlParameterArray = new SqlParameter[1];
      int index = 0;
      SqlParameter sqlParameter = new SqlParameter("@ID", SqlDbType.UniqueIdentifier);
      sqlParameter.Value = (object) id;
      sqlParameterArray[index] = sqlParameter;
      SqlParameter[] parameter = sqlParameterArray;
      return this.dbHelper.Execute(sql, parameter, false);
    }

    private List<RoadFlow.Data.Model.WorkFlowComment> DataReaderToList(SqlDataReader dataReader)
    {
      List<RoadFlow.Data.Model.WorkFlowComment> workFlowCommentList = new List<RoadFlow.Data.Model.WorkFlowComment>();
      while (dataReader.Read())
      {
        RoadFlow.Data.Model.WorkFlowComment workFlowComment = new RoadFlow.Data.Model.WorkFlowComment();
        workFlowComment.ID = dataReader.GetGuid(0);
        if (!dataReader.IsDBNull(1))
          workFlowComment.MemberID = dataReader.GetString(1);
        workFlowComment.Comment = dataReader.GetString(2);
        workFlowComment.Type = dataReader.GetInt32(3);
        workFlowComment.Sort = dataReader.GetInt32(4);
        workFlowCommentList.Add(workFlowComment);
      }
      return workFlowCommentList;
    }

    public List<RoadFlow.Data.Model.WorkFlowComment> GetAll()
    {
      SqlDataReader dataReader = this.dbHelper.GetDataReader("SELECT * FROM WorkFlowComment");
      List<RoadFlow.Data.Model.WorkFlowComment> list = this.DataReaderToList(dataReader);
      dataReader.Close();
      return list;
    }

    public long GetCount()
    {
      long result;
      if (!long.TryParse(this.dbHelper.GetFieldValue("SELECT COUNT(*) FROM WorkFlowComment"), out result))
        return 0;
      return result;
    }

    public RoadFlow.Data.Model.WorkFlowComment Get(Guid id)
    {
      string sql = "SELECT * FROM WorkFlowComment WHERE ID=@ID";
      SqlParameter[] sqlParameterArray = new SqlParameter[1];
      int index = 0;
      SqlParameter sqlParameter = new SqlParameter("@ID", SqlDbType.UniqueIdentifier);
      sqlParameter.Value = (object) id;
      sqlParameterArray[index] = sqlParameter;
      SqlParameter[] parameter = sqlParameterArray;
      SqlDataReader dataReader = this.dbHelper.GetDataReader(sql, parameter);
      List<RoadFlow.Data.Model.WorkFlowComment> list = this.DataReaderToList(dataReader);
      dataReader.Close();
      if (list.Count <= 0)
        return (RoadFlow.Data.Model.WorkFlowComment) null;
      return list[0];
    }

    public List<RoadFlow.Data.Model.WorkFlowComment> GetManagerAll()
    {
      SqlDataReader dataReader = this.dbHelper.GetDataReader("SELECT * FROM WorkFlowComment WHERE Type=0");
      List<RoadFlow.Data.Model.WorkFlowComment> list = this.DataReaderToList(dataReader);
      dataReader.Close();
      return list;
    }

    public int GetManagerMaxSort()
    {
      SqlDataReader dataReader = this.dbHelper.GetDataReader("SELECT ISNULL(MAX(Sort)+1,1) FROM WorkFlowComment WHERE Type=0");
      if (!dataReader.HasRows)
        return 1;
      dataReader.Read();
      int int32 = dataReader.GetInt32(0);
      dataReader.Close();
      return int32;
    }

    public int GetUserMaxSort(Guid userID)
    {
      string sql = "SELECT ISNULL(MAX(Sort)+1,1) FROM WorkFlowComment WHERE MemberID=@MemberID";
      SqlParameter[] sqlParameterArray = new SqlParameter[1];
      int index = 0;
      SqlParameter sqlParameter = new SqlParameter("@MemberID", SqlDbType.UniqueIdentifier);
      sqlParameter.Value = (object) userID;
      sqlParameterArray[index] = sqlParameter;
      SqlParameter[] parameter = sqlParameterArray;
      SqlDataReader dataReader = this.dbHelper.GetDataReader(sql, parameter);
      if (!dataReader.HasRows)
        return 1;
      dataReader.Read();
      int int32 = dataReader.GetInt32(0);
      dataReader.Close();
      return int32;
    }
  }
}
