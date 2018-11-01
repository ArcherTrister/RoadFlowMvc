// Decompiled with JetBrains decompiler
// Type: RoadFlow.Data.ORACLE.WorkFlowComment
// Assembly: RoadFlow.Data.ORACLE, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: C9018AA1-E48E-4231-92A9-CD6F0F275D11
// Assembly location: C:\inetpub\wwwroot\RoadFlowMvc\bin\RoadFlow.Data.ORACLE.dll

using Oracle.ManagedDataAccess.Client;
using RoadFlow.Data.Interface;
using System;
using System.Collections.Generic;

namespace RoadFlow.Data.ORACLE
{
  public class WorkFlowComment : IWorkFlowComment
  {
    private DBHelper dbHelper = new DBHelper();

    public int Add(RoadFlow.Data.Model.WorkFlowComment model)
    {
      string sql = "INSERT INTO WorkFlowComment\r\n\t\t\t\t(ID,MemberID,Comment1,Type,Sort) \r\n\t\t\t\tVALUES(:ID,:MemberID,:Comment1,:Type,:Sort)";
      OracleParameter[] oracleParameterArray = new OracleParameter[5];
      int index1 = 0;
      OracleParameter oracleParameter1 = new OracleParameter(":ID", OracleDbType.Varchar2);
      oracleParameter1.Value = (object) model.ID;
      oracleParameterArray[index1] = oracleParameter1;
      int index2 = 1;
      OracleParameter oracleParameter2;
      if (model.MemberID != null)
      {
        OracleParameter oracleParameter3 = new OracleParameter(":MemberID", OracleDbType.Clob);
        oracleParameter3.Value = (object) model.MemberID;
        oracleParameter2 = oracleParameter3;
      }
      else
      {
        oracleParameter2 = new OracleParameter(":MemberID", OracleDbType.Clob);
        oracleParameter2.Value = (object) DBNull.Value;
      }
      oracleParameterArray[index2] = oracleParameter2;
      int index3 = 2;
      OracleParameter oracleParameter4 = new OracleParameter(":Comment1", OracleDbType.NVarchar2);
      oracleParameter4.Value = (object) model.Comment;
      oracleParameterArray[index3] = oracleParameter4;
      int index4 = 3;
      OracleParameter oracleParameter5 = new OracleParameter(":Type", OracleDbType.Int32);
      oracleParameter5.Value = (object) model.Type;
      oracleParameterArray[index4] = oracleParameter5;
      int index5 = 4;
      OracleParameter oracleParameter6 = new OracleParameter(":Sort", OracleDbType.Int32);
      oracleParameter6.Value = (object) model.Sort;
      oracleParameterArray[index5] = oracleParameter6;
      OracleParameter[] parameter = oracleParameterArray;
      return this.dbHelper.Execute(sql, parameter);
    }

    public int Update(RoadFlow.Data.Model.WorkFlowComment model)
    {
      string sql = "UPDATE WorkFlowComment SET \r\n\t\t\t\tMemberID=:MemberID,Comment1=:Comment1,Type=:Type,Sort=:Sort\r\n\t\t\t\tWHERE ID=:ID";
      OracleParameter[] oracleParameterArray = new OracleParameter[5];
      int index1 = 0;
      OracleParameter oracleParameter1;
      if (model.MemberID != null)
      {
        OracleParameter oracleParameter2 = new OracleParameter(":MemberID", OracleDbType.Clob);
        oracleParameter2.Value = (object) model.MemberID;
        oracleParameter1 = oracleParameter2;
      }
      else
      {
        oracleParameter1 = new OracleParameter(":MemberID", OracleDbType.Clob);
        oracleParameter1.Value = (object) DBNull.Value;
      }
      oracleParameterArray[index1] = oracleParameter1;
      int index2 = 1;
      OracleParameter oracleParameter3 = new OracleParameter(":Comment1", OracleDbType.NVarchar2);
      oracleParameter3.Value = (object) model.Comment;
      oracleParameterArray[index2] = oracleParameter3;
      int index3 = 2;
      OracleParameter oracleParameter4 = new OracleParameter(":Type", OracleDbType.Int32);
      oracleParameter4.Value = (object) model.Type;
      oracleParameterArray[index3] = oracleParameter4;
      int index4 = 3;
      OracleParameter oracleParameter5 = new OracleParameter(":Sort", OracleDbType.Int32);
      oracleParameter5.Value = (object) model.Sort;
      oracleParameterArray[index4] = oracleParameter5;
      int index5 = 4;
      OracleParameter oracleParameter6 = new OracleParameter(":ID", OracleDbType.Varchar2);
      oracleParameter6.Value = (object) model.ID;
      oracleParameterArray[index5] = oracleParameter6;
      OracleParameter[] parameter = oracleParameterArray;
      return this.dbHelper.Execute(sql, parameter);
    }

    public int Delete(Guid id)
    {
      string sql = "DELETE FROM WorkFlowComment WHERE ID=:ID";
      OracleParameter[] oracleParameterArray = new OracleParameter[1];
      int index = 0;
      OracleParameter oracleParameter = new OracleParameter(":ID", OracleDbType.Varchar2);
      oracleParameter.Value = (object) id;
      oracleParameterArray[index] = oracleParameter;
      OracleParameter[] parameter = oracleParameterArray;
      return this.dbHelper.Execute(sql, parameter);
    }

    private List<RoadFlow.Data.Model.WorkFlowComment> DataReaderToList(OracleDataReader dataReader)
    {
      List<RoadFlow.Data.Model.WorkFlowComment> workFlowCommentList = new List<RoadFlow.Data.Model.WorkFlowComment>();
      while (dataReader.Read())
      {
        RoadFlow.Data.Model.WorkFlowComment workFlowComment = new RoadFlow.Data.Model.WorkFlowComment();
        workFlowComment.ID = dataReader.GetString(0).ToGuid();
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
      OracleDataReader dataReader = this.dbHelper.GetDataReader("SELECT * FROM WorkFlowComment");
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
      string sql = "SELECT * FROM WorkFlowComment WHERE ID=:ID";
      OracleParameter[] oracleParameterArray = new OracleParameter[1];
      int index = 0;
      OracleParameter oracleParameter = new OracleParameter(":ID", OracleDbType.Varchar2);
      oracleParameter.Value = (object) id;
      oracleParameterArray[index] = oracleParameter;
      OracleParameter[] parameter = oracleParameterArray;
      OracleDataReader dataReader = this.dbHelper.GetDataReader(sql, parameter);
      List<RoadFlow.Data.Model.WorkFlowComment> list = this.DataReaderToList(dataReader);
      dataReader.Close();
      if (list.Count <= 0)
        return (RoadFlow.Data.Model.WorkFlowComment) null;
      return list[0];
    }

    public List<RoadFlow.Data.Model.WorkFlowComment> GetManagerAll()
    {
      OracleDataReader dataReader = this.dbHelper.GetDataReader("SELECT * FROM WorkFlowComment WHERE Type=0");
      List<RoadFlow.Data.Model.WorkFlowComment> list = this.DataReaderToList(dataReader);
      dataReader.Close();
      return list;
    }

    public int GetManagerMaxSort()
    {
      OracleDataReader dataReader = this.dbHelper.GetDataReader("SELECT nvl(MAX(Sort)+1,1) FROM WorkFlowComment WHERE Type=0");
      if (!dataReader.HasRows)
        return 1;
      dataReader.Read();
      int int32 = dataReader.GetInt32(0);
      dataReader.Close();
      return int32;
    }

    public int GetUserMaxSort(Guid userID)
    {
      string sql = "SELECT nvl(MAX(Sort)+1,1) FROM WorkFlowComment WHERE MemberID=:MemberID";
      OracleParameter[] oracleParameterArray = new OracleParameter[1];
      int index = 0;
      OracleParameter oracleParameter = new OracleParameter(":MemberID", OracleDbType.Varchar2);
      oracleParameter.Value = (object) userID;
      oracleParameterArray[index] = oracleParameter;
      OracleParameter[] parameter = oracleParameterArray;
      OracleDataReader dataReader = this.dbHelper.GetDataReader(sql, parameter);
      if (!dataReader.HasRows)
        return 1;
      dataReader.Read();
      int int32 = dataReader.GetInt32(0);
      dataReader.Close();
      return int32;
    }
  }
}
