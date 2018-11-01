// Decompiled with JetBrains decompiler
// Type: RoadFlow.Data.MySql.Documents
// Assembly: RoadFlow.Data.MySql, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 29B652D7-5F6F-4A7D-AD1C-9F2C643FD784
// Assembly location: C:\inetpub\wwwroot\RoadFlowMvc\bin\RoadFlow.Data.MySql.dll

using MySql.Data.MySqlClient;
using RoadFlow.Data.Interface;
using RoadFlow.Utility;
using System;
using System.Collections.Generic;
using System.Data;
using System.Text;

namespace RoadFlow.Data.MySql
{
  public class Documents : IDocuments
  {
    private DBHelper dbHelper = new DBHelper();

    public int Add(RoadFlow.Data.Model.Documents model)
    {
      string sql = "INSERT INTO documents\r\n\t\t\t\t(ID,DirectoryID,DirectoryName,Title,Source,Contents,Files,WriteTime,WriteUserID,WriteUserName,EditTime,EditUserID,EditUserName,ReadUsers,ReadCount) \r\n\t\t\t\tVALUES(@ID,@DirectoryID,@DirectoryName,@Title,@Source,@Contents,@Files,@WriteTime,@WriteUserID,@WriteUserName,@EditTime,@EditUserID,@EditUserName,@ReadUsers,@ReadCount)";
      MySqlParameter[] mySqlParameterArray = new MySqlParameter[15];
      int index1 = 0;
      MySqlParameter mySqlParameter1 = new MySqlParameter("@ID", MySqlDbType.VarChar, 36);
      mySqlParameter1.Value = (object) model.ID;
      mySqlParameterArray[index1] = mySqlParameter1;
      int index2 = 1;
      MySqlParameter mySqlParameter2 = new MySqlParameter("@DirectoryID", MySqlDbType.VarChar, 36);
      mySqlParameter2.Value = (object) model.DirectoryID;
      mySqlParameterArray[index2] = mySqlParameter2;
      int index3 = 2;
      MySqlParameter mySqlParameter3 = new MySqlParameter("@DirectoryName", MySqlDbType.VarChar, 200);
      mySqlParameter3.Value = (object) model.DirectoryName;
      mySqlParameterArray[index3] = mySqlParameter3;
      int index4 = 3;
      MySqlParameter mySqlParameter4 = new MySqlParameter("@Title", MySqlDbType.Text, -1);
      mySqlParameter4.Value = (object) model.Title;
      mySqlParameterArray[index4] = mySqlParameter4;
      int index5 = 4;
      MySqlParameter mySqlParameter5 = new MySqlParameter("@Source", MySqlDbType.VarChar, 50);
      mySqlParameter5.Value = (object) model.Source;
      mySqlParameterArray[index5] = mySqlParameter5;
      int index6 = 5;
      MySqlParameter mySqlParameter6 = new MySqlParameter("@Contents", MySqlDbType.LongText, -1);
      mySqlParameter6.Value = (object) model.Contents;
      mySqlParameterArray[index6] = mySqlParameter6;
      int index7 = 6;
      MySqlParameter mySqlParameter7;
      if (model.Files != null)
      {
        MySqlParameter mySqlParameter8 = new MySqlParameter("@Files", MySqlDbType.LongText, -1);
        mySqlParameter8.Value = (object) model.Files;
        mySqlParameter7 = mySqlParameter8;
      }
      else
      {
        mySqlParameter7 = new MySqlParameter("@Files", MySqlDbType.LongText, -1);
        mySqlParameter7.Value = (object) DBNull.Value;
      }
      mySqlParameterArray[index7] = mySqlParameter7;
      int index8 = 7;
      MySqlParameter mySqlParameter9 = new MySqlParameter("@WriteTime", MySqlDbType.DateTime, -1);
      mySqlParameter9.Value = (object) model.WriteTime;
      mySqlParameterArray[index8] = mySqlParameter9;
      int index9 = 8;
      MySqlParameter mySqlParameter10 = new MySqlParameter("@WriteUserID", MySqlDbType.VarChar, 36);
      mySqlParameter10.Value = (object) model.WriteUserID;
      mySqlParameterArray[index9] = mySqlParameter10;
      int index10 = 9;
      MySqlParameter mySqlParameter11 = new MySqlParameter("@WriteUserName", MySqlDbType.VarChar, 50);
      mySqlParameter11.Value = (object) model.WriteUserName;
      mySqlParameterArray[index10] = mySqlParameter11;
      int index11 = 10;
      MySqlParameter mySqlParameter12;
      if (model.EditTime.HasValue)
      {
        MySqlParameter mySqlParameter8 = new MySqlParameter("@EditTime", MySqlDbType.DateTime, -1);
        mySqlParameter8.Value = (object) model.EditTime;
        mySqlParameter12 = mySqlParameter8;
      }
      else
      {
        mySqlParameter12 = new MySqlParameter("@EditTime", MySqlDbType.DateTime, -1);
        mySqlParameter12.Value = (object) DBNull.Value;
      }
      mySqlParameterArray[index11] = mySqlParameter12;
      int index12 = 11;
      MySqlParameter mySqlParameter13;
      if (model.EditUserID.HasValue)
      {
        MySqlParameter mySqlParameter8 = new MySqlParameter("@EditUserID", MySqlDbType.VarChar, 36);
        mySqlParameter8.Value = (object) model.EditUserID;
        mySqlParameter13 = mySqlParameter8;
      }
      else
      {
        mySqlParameter13 = new MySqlParameter("@EditUserID", MySqlDbType.VarChar, 36);
        mySqlParameter13.Value = (object) DBNull.Value;
      }
      mySqlParameterArray[index12] = mySqlParameter13;
      int index13 = 12;
      MySqlParameter mySqlParameter14;
      if (model.EditUserName != null)
      {
        MySqlParameter mySqlParameter8 = new MySqlParameter("@EditUserName", MySqlDbType.VarChar, 50);
        mySqlParameter8.Value = (object) model.EditUserName;
        mySqlParameter14 = mySqlParameter8;
      }
      else
      {
        mySqlParameter14 = new MySqlParameter("@EditUserName", MySqlDbType.VarChar, 50);
        mySqlParameter14.Value = (object) DBNull.Value;
      }
      mySqlParameterArray[index13] = mySqlParameter14;
      int index14 = 13;
      MySqlParameter mySqlParameter15;
      if (model.ReadUsers != null)
      {
        MySqlParameter mySqlParameter8 = new MySqlParameter("@ReadUsers", MySqlDbType.LongText, -1);
        mySqlParameter8.Value = (object) model.ReadUsers;
        mySqlParameter15 = mySqlParameter8;
      }
      else
      {
        mySqlParameter15 = new MySqlParameter("@ReadUsers", MySqlDbType.LongText, -1);
        mySqlParameter15.Value = (object) DBNull.Value;
      }
      mySqlParameterArray[index14] = mySqlParameter15;
      int index15 = 14;
      MySqlParameter mySqlParameter16 = new MySqlParameter("@ReadCount", MySqlDbType.Int32, 11);
      mySqlParameter16.Value = (object) model.ReadCount;
      mySqlParameterArray[index15] = mySqlParameter16;
      MySqlParameter[] parameter = mySqlParameterArray;
      return this.dbHelper.Execute(sql, parameter, false);
    }

    public int Update(RoadFlow.Data.Model.Documents model)
    {
      string sql = "UPDATE documents SET \r\n\t\t\t\tDirectoryID=@DirectoryID,DirectoryName=@DirectoryName,Title=@Title,Source=@Source,Contents=@Contents,Files=@Files,WriteTime=@WriteTime,WriteUserID=@WriteUserID,WriteUserName=@WriteUserName,EditTime=@EditTime,EditUserID=@EditUserID,EditUserName=@EditUserName,ReadUsers=@ReadUsers,ReadCount=@ReadCount\r\n\t\t\t\tWHERE ID=@ID";
      MySqlParameter[] mySqlParameterArray = new MySqlParameter[15];
      int index1 = 0;
      MySqlParameter mySqlParameter1 = new MySqlParameter("@DirectoryID", MySqlDbType.VarChar, 36);
      mySqlParameter1.Value = (object) model.DirectoryID;
      mySqlParameterArray[index1] = mySqlParameter1;
      int index2 = 1;
      MySqlParameter mySqlParameter2 = new MySqlParameter("@DirectoryName", MySqlDbType.VarChar, 200);
      mySqlParameter2.Value = (object) model.DirectoryName;
      mySqlParameterArray[index2] = mySqlParameter2;
      int index3 = 2;
      MySqlParameter mySqlParameter3 = new MySqlParameter("@Title", MySqlDbType.Text, -1);
      mySqlParameter3.Value = (object) model.Title;
      mySqlParameterArray[index3] = mySqlParameter3;
      int index4 = 3;
      MySqlParameter mySqlParameter4 = new MySqlParameter("@Source", MySqlDbType.VarChar, 50);
      mySqlParameter4.Value = (object) model.Source;
      mySqlParameterArray[index4] = mySqlParameter4;
      int index5 = 4;
      MySqlParameter mySqlParameter5 = new MySqlParameter("@Contents", MySqlDbType.LongText, -1);
      mySqlParameter5.Value = (object) model.Contents;
      mySqlParameterArray[index5] = mySqlParameter5;
      int index6 = 5;
      MySqlParameter mySqlParameter6;
      if (model.Files != null)
      {
        MySqlParameter mySqlParameter7 = new MySqlParameter("@Files", MySqlDbType.LongText, -1);
        mySqlParameter7.Value = (object) model.Files;
        mySqlParameter6 = mySqlParameter7;
      }
      else
      {
        mySqlParameter6 = new MySqlParameter("@Files", MySqlDbType.LongText, -1);
        mySqlParameter6.Value = (object) DBNull.Value;
      }
      mySqlParameterArray[index6] = mySqlParameter6;
      int index7 = 6;
      MySqlParameter mySqlParameter8 = new MySqlParameter("@WriteTime", MySqlDbType.DateTime, -1);
      mySqlParameter8.Value = (object) model.WriteTime;
      mySqlParameterArray[index7] = mySqlParameter8;
      int index8 = 7;
      MySqlParameter mySqlParameter9 = new MySqlParameter("@WriteUserID", MySqlDbType.VarChar, 36);
      mySqlParameter9.Value = (object) model.WriteUserID;
      mySqlParameterArray[index8] = mySqlParameter9;
      int index9 = 8;
      MySqlParameter mySqlParameter10 = new MySqlParameter("@WriteUserName", MySqlDbType.VarChar, 50);
      mySqlParameter10.Value = (object) model.WriteUserName;
      mySqlParameterArray[index9] = mySqlParameter10;
      int index10 = 9;
      MySqlParameter mySqlParameter11;
      if (model.EditTime.HasValue)
      {
        MySqlParameter mySqlParameter7 = new MySqlParameter("@EditTime", MySqlDbType.DateTime, -1);
        mySqlParameter7.Value = (object) model.EditTime;
        mySqlParameter11 = mySqlParameter7;
      }
      else
      {
        mySqlParameter11 = new MySqlParameter("@EditTime", MySqlDbType.DateTime, -1);
        mySqlParameter11.Value = (object) DBNull.Value;
      }
      mySqlParameterArray[index10] = mySqlParameter11;
      int index11 = 10;
      MySqlParameter mySqlParameter12;
      if (model.EditUserID.HasValue)
      {
        MySqlParameter mySqlParameter7 = new MySqlParameter("@EditUserID", MySqlDbType.VarChar, 36);
        mySqlParameter7.Value = (object) model.EditUserID;
        mySqlParameter12 = mySqlParameter7;
      }
      else
      {
        mySqlParameter12 = new MySqlParameter("@EditUserID", MySqlDbType.VarChar, 36);
        mySqlParameter12.Value = (object) DBNull.Value;
      }
      mySqlParameterArray[index11] = mySqlParameter12;
      int index12 = 11;
      MySqlParameter mySqlParameter13;
      if (model.EditUserName != null)
      {
        MySqlParameter mySqlParameter7 = new MySqlParameter("@EditUserName", MySqlDbType.VarChar, 50);
        mySqlParameter7.Value = (object) model.EditUserName;
        mySqlParameter13 = mySqlParameter7;
      }
      else
      {
        mySqlParameter13 = new MySqlParameter("@EditUserName", MySqlDbType.VarChar, 50);
        mySqlParameter13.Value = (object) DBNull.Value;
      }
      mySqlParameterArray[index12] = mySqlParameter13;
      int index13 = 12;
      MySqlParameter mySqlParameter14;
      if (model.ReadUsers != null)
      {
        MySqlParameter mySqlParameter7 = new MySqlParameter("@ReadUsers", MySqlDbType.LongText, -1);
        mySqlParameter7.Value = (object) model.ReadUsers;
        mySqlParameter14 = mySqlParameter7;
      }
      else
      {
        mySqlParameter14 = new MySqlParameter("@ReadUsers", MySqlDbType.LongText, -1);
        mySqlParameter14.Value = (object) DBNull.Value;
      }
      mySqlParameterArray[index13] = mySqlParameter14;
      int index14 = 13;
      MySqlParameter mySqlParameter15 = new MySqlParameter("@ReadCount", MySqlDbType.Int32, 11);
      mySqlParameter15.Value = (object) model.ReadCount;
      mySqlParameterArray[index14] = mySqlParameter15;
      int index15 = 14;
      MySqlParameter mySqlParameter16 = new MySqlParameter("@ID", MySqlDbType.VarChar, 36);
      mySqlParameter16.Value = (object) model.ID;
      mySqlParameterArray[index15] = mySqlParameter16;
      MySqlParameter[] parameter = mySqlParameterArray;
      return this.dbHelper.Execute(sql, parameter, false);
    }

    public int Delete(Guid id)
    {
      string sql = "DELETE FROM documents WHERE ID=@ID";
      MySqlParameter[] mySqlParameterArray = new MySqlParameter[1];
      int index = 0;
      MySqlParameter mySqlParameter = new MySqlParameter("@ID", MySqlDbType.VarChar, 36);
      mySqlParameter.Value = (object) id.ToString();
      mySqlParameterArray[index] = mySqlParameter;
      MySqlParameter[] parameter = mySqlParameterArray;
      return this.dbHelper.Execute(sql, parameter, false);
    }

    private List<RoadFlow.Data.Model.Documents> DataReaderToList(MySqlDataReader dataReader)
    {
      List<RoadFlow.Data.Model.Documents> documentsList = new List<RoadFlow.Data.Model.Documents>();
      while (dataReader.Read())
      {
        RoadFlow.Data.Model.Documents documents = new RoadFlow.Data.Model.Documents();
        documents.ID = dataReader.GetString(0).ToGuid();
        documents.DirectoryID = dataReader.GetString(1).ToGuid();
        documents.DirectoryName = dataReader.GetString(2);
        documents.Title = dataReader.GetString(3);
        documents.Source = dataReader.GetString(4);
        documents.Contents = dataReader.GetString(5);
        if (!dataReader.IsDBNull(6))
          documents.Files = dataReader.GetString(6);
        documents.WriteTime = dataReader.GetDateTime(7);
        documents.WriteUserID = dataReader.GetString(8).ToGuid();
        documents.WriteUserName = dataReader.GetString(9);
        if (!dataReader.IsDBNull(10))
          documents.EditTime = new DateTime?(dataReader.GetDateTime(10));
        if (!dataReader.IsDBNull(11))
          documents.EditUserID = new Guid?(dataReader.GetString(11).ToGuid());
        if (!dataReader.IsDBNull(12))
          documents.EditUserName = dataReader.GetString(12);
        if (!dataReader.IsDBNull(13))
          documents.ReadUsers = dataReader.GetString(13);
        documents.ReadCount = dataReader.GetInt32(14);
        documentsList.Add(documents);
      }
      return documentsList;
    }

    public List<RoadFlow.Data.Model.Documents> GetAll()
    {
      MySqlDataReader dataReader = this.dbHelper.GetDataReader("SELECT * FROM documents");
      List<RoadFlow.Data.Model.Documents> list = this.DataReaderToList(dataReader);
      dataReader.Close();
      return list;
    }

    public long GetCount()
    {
      long result;
      if (!long.TryParse(this.dbHelper.GetFieldValue("SELECT COUNT(*) FROM documents"), out result))
        return 0;
      return result;
    }

    public RoadFlow.Data.Model.Documents Get(Guid id)
    {
      string sql = "SELECT * FROM documents WHERE ID=@ID";
      MySqlParameter[] mySqlParameterArray = new MySqlParameter[1];
      int index = 0;
      MySqlParameter mySqlParameter = new MySqlParameter("@ID", MySqlDbType.VarChar, 36);
      mySqlParameter.Value = (object) id.ToString();
      mySqlParameterArray[index] = mySqlParameter;
      MySqlParameter[] parameter = mySqlParameterArray;
      MySqlDataReader dataReader = this.dbHelper.GetDataReader(sql, parameter);
      List<RoadFlow.Data.Model.Documents> list = this.DataReaderToList(dataReader);
      dataReader.Close();
      if (list.Count <= 0)
        return (RoadFlow.Data.Model.Documents) null;
      return list[0];
    }

    public void UpdateReadCount(Guid id)
    {
      string sql = "UPDATE Documents SET ReadCount=ReadCount+1 WHERE ID=@ID";
      MySqlParameter[] mySqlParameterArray = new MySqlParameter[1];
      int index = 0;
      MySqlParameter mySqlParameter = new MySqlParameter("@ID", MySqlDbType.VarChar);
      mySqlParameter.Value = (object) id;
      mySqlParameterArray[index] = mySqlParameter;
      MySqlParameter[] parameter = mySqlParameterArray;
      this.dbHelper.Execute(sql, parameter, false);
    }

    public DataTable GetList(out string pager, string dirID, string userID, string query = "", string title = "", string date1 = "", string date2 = "", bool isNoRead = false)
    {
      List<MySqlParameter> mySqlParameterList1 = new List<MySqlParameter>();
      StringBuilder stringBuilder = new StringBuilder("SELECT ID,DirectoryID,DirectoryName,Title,WriteTime,WriteUserName,IsRead,ReadCount FROM Documents a LEFT JOIN DocumentsReadUsers b ON a.ID=b.DocumentID WHERE b.UserID=@UserID");
      List<MySqlParameter> mySqlParameterList2 = mySqlParameterList1;
      MySqlParameter mySqlParameter1 = new MySqlParameter("@UserID", MySqlDbType.VarChar);
      mySqlParameter1.Value = (object) userID.ToGuid();
      mySqlParameterList2.Add(mySqlParameter1);
      if (isNoRead)
        stringBuilder.Append(" AND IsRead=0");
      if (!dirID.IsNullOrEmpty())
        stringBuilder.Append(" AND DirectoryID IN(" + Tools.GetSqlInString(dirID, true, ",") + ")");
      else
        stringBuilder.Append(isNoRead ? " AND IsRead=0" : " AND 1=0");
      if (!title.IsNullOrEmpty())
      {
        stringBuilder.Append(" AND INSTR(Title,@Title)>0");
        List<MySqlParameter> mySqlParameterList3 = mySqlParameterList1;
        MySqlParameter mySqlParameter2 = new MySqlParameter("@Title", MySqlDbType.VarChar);
        mySqlParameter2.Value = (object) title;
        mySqlParameterList3.Add(mySqlParameter2);
      }
      if (date1.IsDateTime())
      {
        stringBuilder.Append(" AND WriteTime>=@WriteTime");
        List<MySqlParameter> mySqlParameterList3 = mySqlParameterList1;
        MySqlParameter mySqlParameter2 = new MySqlParameter("@WriteTime", MySqlDbType.DateTime);
        mySqlParameter2.Value = (object) date1.ToDateTime().Date;
        mySqlParameterList3.Add(mySqlParameter2);
      }
      if (date2.IsDateTime())
      {
        stringBuilder.Append(" AND WriteTime<=@WriteTime1");
        List<MySqlParameter> mySqlParameterList3 = mySqlParameterList1;
        MySqlParameter mySqlParameter2 = new MySqlParameter("@WriteTime1", MySqlDbType.DateTime);
        mySqlParameter2.Value = (object) date2.ToDateTime().AddDays(1.0).Date;
        mySqlParameterList3.Add(mySqlParameter2);
      }
      stringBuilder.Append(" ORDER BY WriteTime DESC");
      int pageSize = Tools.GetPageSize();
      int pageNumber = Tools.GetPageNumber();
      long count;
      string paerSql = this.dbHelper.GetPaerSql(stringBuilder.ToString(), pageSize, pageNumber, out count, mySqlParameterList1.ToArray());
      pager = Tools.GetPagerHtml(count, pageSize, pageNumber, query);
      return this.dbHelper.GetDataTable(paerSql, mySqlParameterList1.ToArray());
    }

    public DataTable GetList(out long count, int size, int number, string dirID, string userID, string title = "", string date1 = "", string date2 = "", bool isNoRead = false, string order = "")
    {
      List<MySqlParameter> mySqlParameterList1 = new List<MySqlParameter>();
      StringBuilder stringBuilder = new StringBuilder("SELECT ID,DirectoryID,DirectoryName,Title,WriteTime,WriteUserName,IsRead,ReadCount FROM Documents a LEFT JOIN DocumentsReadUsers b ON a.ID=b.DocumentID WHERE b.UserID=@UserID");
      List<MySqlParameter> mySqlParameterList2 = mySqlParameterList1;
      MySqlParameter mySqlParameter1 = new MySqlParameter("@UserID", MySqlDbType.VarChar);
      mySqlParameter1.Value = (object) userID.ToGuid();
      mySqlParameterList2.Add(mySqlParameter1);
      if (isNoRead)
        stringBuilder.Append(" AND IsRead=0");
      if (!dirID.IsNullOrEmpty())
        stringBuilder.Append(" AND DirectoryID IN(" + Tools.GetSqlInString(dirID, true, ",") + ")");
      else
        stringBuilder.Append(isNoRead ? " AND IsRead=0" : " AND 1=0");
      if (!title.IsNullOrEmpty())
      {
        stringBuilder.Append(" AND INSTR(Title,@Title)>0");
        List<MySqlParameter> mySqlParameterList3 = mySqlParameterList1;
        MySqlParameter mySqlParameter2 = new MySqlParameter("@Title", MySqlDbType.VarChar);
        mySqlParameter2.Value = (object) title;
        mySqlParameterList3.Add(mySqlParameter2);
      }
      if (date1.IsDateTime())
      {
        stringBuilder.Append(" AND WriteTime>=@WriteTime");
        List<MySqlParameter> mySqlParameterList3 = mySqlParameterList1;
        MySqlParameter mySqlParameter2 = new MySqlParameter("@WriteTime", MySqlDbType.DateTime);
        mySqlParameter2.Value = (object) date1.ToDateTime().Date;
        mySqlParameterList3.Add(mySqlParameter2);
      }
      if (date2.IsDateTime())
      {
        stringBuilder.Append(" AND WriteTime<=@WriteTime1");
        List<MySqlParameter> mySqlParameterList3 = mySqlParameterList1;
        MySqlParameter mySqlParameter2 = new MySqlParameter("@WriteTime1", MySqlDbType.DateTime);
        mySqlParameter2.Value = (object) date2.ToDateTime().AddDays(1.0).Date;
        mySqlParameterList3.Add(mySqlParameter2);
      }
      stringBuilder.Append(" ORDER BY " + (order.IsNullOrEmpty() ? "WriteTime DESC" : order));
      return this.dbHelper.GetDataTable(this.dbHelper.GetPaerSql(stringBuilder.ToString(), size, number, out count, mySqlParameterList1.ToArray()), mySqlParameterList1.ToArray());
    }

    public int DeleteByDirectoryID(Guid directoryID)
    {
      string sql = "DELETE FROM Documents WHERE DirectoryID=@DirectoryID";
      MySqlParameter[] mySqlParameterArray = new MySqlParameter[1];
      int index = 0;
      MySqlParameter mySqlParameter = new MySqlParameter("@DirectoryID", MySqlDbType.VarChar);
      mySqlParameter.Value = (object) directoryID;
      mySqlParameterArray[index] = mySqlParameter;
      MySqlParameter[] parameter = mySqlParameterArray;
      return this.dbHelper.Execute(sql, parameter, false);
    }
  }
}
