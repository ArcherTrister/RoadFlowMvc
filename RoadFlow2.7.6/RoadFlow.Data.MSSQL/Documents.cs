// Decompiled with JetBrains decompiler
// Type: RoadFlow.Data.MSSQL.Documents
// Assembly: RoadFlow.Data.MSSQL, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 5107CDC7-8F84-4EE0-AC6D-E80FE4695340
// Assembly location: C:\inetpub\wwwroot\RoadFlowMvc\bin\RoadFlow.Data.MSSQL.dll

using RoadFlow.Data.Interface;
using RoadFlow.Utility;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Text;

namespace RoadFlow.Data.MSSQL
{
  public class Documents : IDocuments
  {
    private DBHelper dbHelper = new DBHelper();

    public int Add(RoadFlow.Data.Model.Documents model)
    {
      string sql = "INSERT INTO Documents\r\n\t\t\t\t(ID,DirectoryID,DirectoryName,Title,Source,Contents,Files,WriteTime,WriteUserID,WriteUserName,EditTime,EditUserID,EditUserName,ReadUsers,ReadCount) \r\n\t\t\t\tVALUES(@ID,@DirectoryID,@DirectoryName,@Title,@Source,@Contents,@Files,@WriteTime,@WriteUserID,@WriteUserName,@EditTime,@EditUserID,@EditUserName,@ReadUsers,@ReadCount)";
      SqlParameter[] sqlParameterArray = new SqlParameter[15];
      int index1 = 0;
      SqlParameter sqlParameter1 = new SqlParameter("@ID", SqlDbType.UniqueIdentifier, -1);
      sqlParameter1.Value = (object) model.ID;
      sqlParameterArray[index1] = sqlParameter1;
      int index2 = 1;
      SqlParameter sqlParameter2 = new SqlParameter("@DirectoryID", SqlDbType.UniqueIdentifier, -1);
      sqlParameter2.Value = (object) model.DirectoryID;
      sqlParameterArray[index2] = sqlParameter2;
      int index3 = 2;
      SqlParameter sqlParameter3 = new SqlParameter("@DirectoryName", SqlDbType.NVarChar, 400);
      sqlParameter3.Value = (object) model.DirectoryName;
      sqlParameterArray[index3] = sqlParameter3;
      int index4 = 3;
      SqlParameter sqlParameter4 = new SqlParameter("@Title", SqlDbType.NVarChar, 600);
      sqlParameter4.Value = (object) model.Title;
      sqlParameterArray[index4] = sqlParameter4;
      int index5 = 4;
      SqlParameter sqlParameter5 = new SqlParameter("@Source", SqlDbType.NVarChar, 100);
      sqlParameter5.Value = (object) model.Source;
      sqlParameterArray[index5] = sqlParameter5;
      int index6 = 5;
      SqlParameter sqlParameter6 = new SqlParameter("@Contents", SqlDbType.VarChar, -1);
      sqlParameter6.Value = (object) model.Contents;
      sqlParameterArray[index6] = sqlParameter6;
      int index7 = 6;
      SqlParameter sqlParameter7;
      if (model.Files != null)
      {
        SqlParameter sqlParameter8 = new SqlParameter("@Files", SqlDbType.VarChar, -1);
        sqlParameter8.Value = (object) model.Files;
        sqlParameter7 = sqlParameter8;
      }
      else
      {
        sqlParameter7 = new SqlParameter("@Files", SqlDbType.VarChar, -1);
        sqlParameter7.Value = (object) DBNull.Value;
      }
      sqlParameterArray[index7] = sqlParameter7;
      int index8 = 7;
      SqlParameter sqlParameter9 = new SqlParameter("@WriteTime", SqlDbType.DateTime, 8);
      sqlParameter9.Value = (object) model.WriteTime;
      sqlParameterArray[index8] = sqlParameter9;
      int index9 = 8;
      SqlParameter sqlParameter10 = new SqlParameter("@WriteUserID", SqlDbType.UniqueIdentifier, -1);
      sqlParameter10.Value = (object) model.WriteUserID;
      sqlParameterArray[index9] = sqlParameter10;
      int index10 = 9;
      SqlParameter sqlParameter11 = new SqlParameter("@WriteUserName", SqlDbType.NVarChar, 100);
      sqlParameter11.Value = (object) model.WriteUserName;
      sqlParameterArray[index10] = sqlParameter11;
      int index11 = 10;
      SqlParameter sqlParameter12;
      if (model.EditTime.HasValue)
      {
        SqlParameter sqlParameter8 = new SqlParameter("@EditTime", SqlDbType.DateTime, 8);
        sqlParameter8.Value = (object) model.EditTime;
        sqlParameter12 = sqlParameter8;
      }
      else
      {
        sqlParameter12 = new SqlParameter("@EditTime", SqlDbType.DateTime, 8);
        sqlParameter12.Value = (object) DBNull.Value;
      }
      sqlParameterArray[index11] = sqlParameter12;
      int index12 = 11;
      SqlParameter sqlParameter13;
      if (model.EditUserID.HasValue)
      {
        SqlParameter sqlParameter8 = new SqlParameter("@EditUserID", SqlDbType.UniqueIdentifier, -1);
        sqlParameter8.Value = (object) model.EditUserID;
        sqlParameter13 = sqlParameter8;
      }
      else
      {
        sqlParameter13 = new SqlParameter("@EditUserID", SqlDbType.UniqueIdentifier, -1);
        sqlParameter13.Value = (object) DBNull.Value;
      }
      sqlParameterArray[index12] = sqlParameter13;
      int index13 = 12;
      SqlParameter sqlParameter14;
      if (model.EditUserName != null)
      {
        SqlParameter sqlParameter8 = new SqlParameter("@EditUserName", SqlDbType.NVarChar, 100);
        sqlParameter8.Value = (object) model.EditUserName;
        sqlParameter14 = sqlParameter8;
      }
      else
      {
        sqlParameter14 = new SqlParameter("@EditUserName", SqlDbType.NVarChar, 100);
        sqlParameter14.Value = (object) DBNull.Value;
      }
      sqlParameterArray[index13] = sqlParameter14;
      int index14 = 13;
      SqlParameter sqlParameter15;
      if (model.ReadUsers != null)
      {
        SqlParameter sqlParameter8 = new SqlParameter("@ReadUsers", SqlDbType.VarChar, -1);
        sqlParameter8.Value = (object) model.ReadUsers;
        sqlParameter15 = sqlParameter8;
      }
      else
      {
        sqlParameter15 = new SqlParameter("@ReadUsers", SqlDbType.VarChar, -1);
        sqlParameter15.Value = (object) DBNull.Value;
      }
      sqlParameterArray[index14] = sqlParameter15;
      int index15 = 14;
      SqlParameter sqlParameter16 = new SqlParameter("@ReadCount", SqlDbType.Int, -1);
      sqlParameter16.Value = (object) model.ReadCount;
      sqlParameterArray[index15] = sqlParameter16;
      SqlParameter[] parameter = sqlParameterArray;
      return this.dbHelper.Execute(sql, parameter, false);
    }

    public int Update(RoadFlow.Data.Model.Documents model)
    {
      string sql = "UPDATE Documents SET \r\n\t\t\t\tDirectoryID=@DirectoryID,DirectoryName=@DirectoryName,Title=@Title,Source=@Source,Contents=@Contents,Files=@Files,WriteTime=@WriteTime,WriteUserID=@WriteUserID,WriteUserName=@WriteUserName,EditTime=@EditTime,EditUserID=@EditUserID,EditUserName=@EditUserName,ReadUsers=@ReadUsers,ReadCount=@ReadCount\r\n\t\t\t\tWHERE ID=@ID";
      SqlParameter[] sqlParameterArray = new SqlParameter[15];
      int index1 = 0;
      SqlParameter sqlParameter1 = new SqlParameter("@DirectoryID", SqlDbType.UniqueIdentifier, -1);
      sqlParameter1.Value = (object) model.DirectoryID;
      sqlParameterArray[index1] = sqlParameter1;
      int index2 = 1;
      SqlParameter sqlParameter2 = new SqlParameter("@DirectoryName", SqlDbType.NVarChar, 400);
      sqlParameter2.Value = (object) model.DirectoryName;
      sqlParameterArray[index2] = sqlParameter2;
      int index3 = 2;
      SqlParameter sqlParameter3 = new SqlParameter("@Title", SqlDbType.NVarChar, 600);
      sqlParameter3.Value = (object) model.Title;
      sqlParameterArray[index3] = sqlParameter3;
      int index4 = 3;
      SqlParameter sqlParameter4 = new SqlParameter("@Source", SqlDbType.NVarChar, 100);
      sqlParameter4.Value = (object) model.Source;
      sqlParameterArray[index4] = sqlParameter4;
      int index5 = 4;
      SqlParameter sqlParameter5 = new SqlParameter("@Contents", SqlDbType.VarChar, -1);
      sqlParameter5.Value = (object) model.Contents;
      sqlParameterArray[index5] = sqlParameter5;
      int index6 = 5;
      SqlParameter sqlParameter6;
      if (model.Files != null)
      {
        SqlParameter sqlParameter7 = new SqlParameter("@Files", SqlDbType.VarChar, -1);
        sqlParameter7.Value = (object) model.Files;
        sqlParameter6 = sqlParameter7;
      }
      else
      {
        sqlParameter6 = new SqlParameter("@Files", SqlDbType.VarChar, -1);
        sqlParameter6.Value = (object) DBNull.Value;
      }
      sqlParameterArray[index6] = sqlParameter6;
      int index7 = 6;
      SqlParameter sqlParameter8 = new SqlParameter("@WriteTime", SqlDbType.DateTime, 8);
      sqlParameter8.Value = (object) model.WriteTime;
      sqlParameterArray[index7] = sqlParameter8;
      int index8 = 7;
      SqlParameter sqlParameter9 = new SqlParameter("@WriteUserID", SqlDbType.UniqueIdentifier, -1);
      sqlParameter9.Value = (object) model.WriteUserID;
      sqlParameterArray[index8] = sqlParameter9;
      int index9 = 8;
      SqlParameter sqlParameter10 = new SqlParameter("@WriteUserName", SqlDbType.NVarChar, 100);
      sqlParameter10.Value = (object) model.WriteUserName;
      sqlParameterArray[index9] = sqlParameter10;
      int index10 = 9;
      SqlParameter sqlParameter11;
      if (model.EditTime.HasValue)
      {
        SqlParameter sqlParameter7 = new SqlParameter("@EditTime", SqlDbType.DateTime, 8);
        sqlParameter7.Value = (object) model.EditTime;
        sqlParameter11 = sqlParameter7;
      }
      else
      {
        sqlParameter11 = new SqlParameter("@EditTime", SqlDbType.DateTime, 8);
        sqlParameter11.Value = (object) DBNull.Value;
      }
      sqlParameterArray[index10] = sqlParameter11;
      int index11 = 10;
      SqlParameter sqlParameter12;
      if (model.EditUserID.HasValue)
      {
        SqlParameter sqlParameter7 = new SqlParameter("@EditUserID", SqlDbType.UniqueIdentifier, -1);
        sqlParameter7.Value = (object) model.EditUserID;
        sqlParameter12 = sqlParameter7;
      }
      else
      {
        sqlParameter12 = new SqlParameter("@EditUserID", SqlDbType.UniqueIdentifier, -1);
        sqlParameter12.Value = (object) DBNull.Value;
      }
      sqlParameterArray[index11] = sqlParameter12;
      int index12 = 11;
      SqlParameter sqlParameter13;
      if (model.EditUserName != null)
      {
        SqlParameter sqlParameter7 = new SqlParameter("@EditUserName", SqlDbType.NVarChar, 100);
        sqlParameter7.Value = (object) model.EditUserName;
        sqlParameter13 = sqlParameter7;
      }
      else
      {
        sqlParameter13 = new SqlParameter("@EditUserName", SqlDbType.NVarChar, 100);
        sqlParameter13.Value = (object) DBNull.Value;
      }
      sqlParameterArray[index12] = sqlParameter13;
      int index13 = 12;
      SqlParameter sqlParameter14;
      if (model.ReadUsers != null)
      {
        SqlParameter sqlParameter7 = new SqlParameter("@ReadUsers", SqlDbType.VarChar, -1);
        sqlParameter7.Value = (object) model.ReadUsers;
        sqlParameter14 = sqlParameter7;
      }
      else
      {
        sqlParameter14 = new SqlParameter("@ReadUsers", SqlDbType.VarChar, -1);
        sqlParameter14.Value = (object) DBNull.Value;
      }
      sqlParameterArray[index13] = sqlParameter14;
      int index14 = 13;
      SqlParameter sqlParameter15 = new SqlParameter("@ReadCount", SqlDbType.Int, -1);
      sqlParameter15.Value = (object) model.ReadCount;
      sqlParameterArray[index14] = sqlParameter15;
      int index15 = 14;
      SqlParameter sqlParameter16 = new SqlParameter("@ID", SqlDbType.UniqueIdentifier, -1);
      sqlParameter16.Value = (object) model.ID;
      sqlParameterArray[index15] = sqlParameter16;
      SqlParameter[] parameter = sqlParameterArray;
      return this.dbHelper.Execute(sql, parameter, false);
    }

    public int Delete(Guid id)
    {
      string sql = "DELETE FROM Documents WHERE ID=@ID";
      SqlParameter[] sqlParameterArray = new SqlParameter[1];
      int index = 0;
      SqlParameter sqlParameter = new SqlParameter("@ID", SqlDbType.UniqueIdentifier);
      sqlParameter.Value = (object) id;
      sqlParameterArray[index] = sqlParameter;
      SqlParameter[] parameter = sqlParameterArray;
      return this.dbHelper.Execute(sql, parameter, false);
    }

    private List<RoadFlow.Data.Model.Documents> DataReaderToList(SqlDataReader dataReader)
    {
      List<RoadFlow.Data.Model.Documents> documentsList = new List<RoadFlow.Data.Model.Documents>();
      while (dataReader.Read())
      {
        RoadFlow.Data.Model.Documents documents = new RoadFlow.Data.Model.Documents();
        documents.ID = dataReader.GetGuid(0);
        documents.DirectoryID = dataReader.GetGuid(1);
        documents.DirectoryName = dataReader.GetString(2);
        documents.Title = dataReader.GetString(3);
        documents.Source = dataReader.GetString(4);
        documents.Contents = dataReader.GetString(5);
        if (!dataReader.IsDBNull(6))
          documents.Files = dataReader.GetString(6);
        documents.WriteTime = dataReader.GetDateTime(7);
        documents.WriteUserID = dataReader.GetGuid(8);
        documents.WriteUserName = dataReader.GetString(9);
        if (!dataReader.IsDBNull(10))
          documents.EditTime = new DateTime?(dataReader.GetDateTime(10));
        if (!dataReader.IsDBNull(11))
          documents.EditUserID = new Guid?(dataReader.GetGuid(11));
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
      SqlDataReader dataReader = this.dbHelper.GetDataReader("SELECT * FROM Documents");
      List<RoadFlow.Data.Model.Documents> list = this.DataReaderToList(dataReader);
      dataReader.Close();
      return list;
    }

    public long GetCount()
    {
      long result;
      if (!long.TryParse(this.dbHelper.GetFieldValue("SELECT COUNT(*) FROM Documents"), out result))
        return 0;
      return result;
    }

    public RoadFlow.Data.Model.Documents Get(Guid id)
    {
      string sql = "SELECT * FROM Documents WHERE ID=@ID";
      SqlParameter[] sqlParameterArray = new SqlParameter[1];
      int index = 0;
      SqlParameter sqlParameter = new SqlParameter("@ID", SqlDbType.UniqueIdentifier);
      sqlParameter.Value = (object) id;
      sqlParameterArray[index] = sqlParameter;
      SqlParameter[] parameter = sqlParameterArray;
      SqlDataReader dataReader = this.dbHelper.GetDataReader(sql, parameter);
      List<RoadFlow.Data.Model.Documents> list = this.DataReaderToList(dataReader);
      dataReader.Close();
      if (list.Count <= 0)
        return (RoadFlow.Data.Model.Documents) null;
      return list[0];
    }

    public void UpdateReadCount(Guid id)
    {
      string sql = "UPDATE Documents SET ReadCount=ReadCount+1 WHERE ID=@ID";
      SqlParameter[] sqlParameterArray = new SqlParameter[1];
      int index = 0;
      SqlParameter sqlParameter = new SqlParameter("@ID", SqlDbType.UniqueIdentifier);
      sqlParameter.Value = (object) id;
      sqlParameterArray[index] = sqlParameter;
      SqlParameter[] parameter = sqlParameterArray;
      this.dbHelper.Execute(sql, parameter, false);
    }

    public DataTable GetList(out string pager, string dirID, string userID, string query = "", string title = "", string date1 = "", string date2 = "", bool isNoRead = false)
    {
      List<SqlParameter> sqlParameterList1 = new List<SqlParameter>();
      StringBuilder stringBuilder = new StringBuilder("SELECT ID,DirectoryID,DirectoryName,Title,WriteTime,WriteUserName,IsRead,ReadCount,ROW_NUMBER() OVER(ORDER BY WriteTime DESC) AS PagerAutoRowNumber FROM Documents a LEFT JOIN DocumentsReadUsers b ON a.ID=b.DocumentID WHERE b.UserID=@UserID");
      List<SqlParameter> sqlParameterList2 = sqlParameterList1;
      SqlParameter sqlParameter1 = new SqlParameter("@UserID", SqlDbType.UniqueIdentifier);
      sqlParameter1.Value = (object) userID.ToGuid();
      sqlParameterList2.Add(sqlParameter1);
      if (isNoRead)
        stringBuilder.Append(" AND IsRead=0");
      if (!dirID.IsNullOrEmpty())
        stringBuilder.Append(" AND DirectoryID IN(" + Tools.GetSqlInString(dirID, true, ",") + ")");
      else
        stringBuilder.Append(isNoRead ? "" : " AND 1=0");
      if (!title.IsNullOrEmpty())
      {
        stringBuilder.Append(" AND CHARINDEX(@Title,Title)>0");
        List<SqlParameter> sqlParameterList3 = sqlParameterList1;
        SqlParameter sqlParameter2 = new SqlParameter("@Title", SqlDbType.NVarChar);
        sqlParameter2.Value = (object) title;
        sqlParameterList3.Add(sqlParameter2);
      }
      if (date1.IsDateTime())
      {
        stringBuilder.Append(" AND WriteTime>=@WriteTime");
        List<SqlParameter> sqlParameterList3 = sqlParameterList1;
        SqlParameter sqlParameter2 = new SqlParameter("@WriteTime", SqlDbType.DateTime);
        sqlParameter2.Value = (object) date1.ToDateTime().Date;
        sqlParameterList3.Add(sqlParameter2);
      }
      if (date2.IsDateTime())
      {
        stringBuilder.Append(" AND WriteTime<=@WriteTime1");
        List<SqlParameter> sqlParameterList3 = sqlParameterList1;
        SqlParameter sqlParameter2 = new SqlParameter("@WriteTime1", SqlDbType.DateTime);
        sqlParameter2.Value = (object) date2.ToDateTime().AddDays(1.0).Date;
        sqlParameterList3.Add(sqlParameter2);
      }
      int pageSize = Tools.GetPageSize();
      int pageNumber = Tools.GetPageNumber();
      long count;
      string paerSql = this.dbHelper.GetPaerSql(stringBuilder.ToString(), pageSize, pageNumber, out count, sqlParameterList1.ToArray());
      pager = Tools.GetPagerHtml(count, pageSize, pageNumber, query);
      return this.dbHelper.GetDataTable(paerSql, sqlParameterList1.ToArray());
    }

    public DataTable GetList(out long count, int size, int number, string dirID, string userID, string title = "", string date1 = "", string date2 = "", bool isNoRead = false, string order = "")
    {
      List<SqlParameter> sqlParameterList1 = new List<SqlParameter>();
      StringBuilder stringBuilder = new StringBuilder("SELECT ID,DirectoryID,DirectoryName,Title,WriteTime,WriteUserName,IsRead,ReadCount,ROW_NUMBER() OVER(ORDER BY " + (order.IsNullOrEmpty() ? "WriteTime DESC" : order) + ") AS PagerAutoRowNumber FROM Documents a LEFT JOIN DocumentsReadUsers b ON a.ID=b.DocumentID WHERE b.UserID=@UserID");
      List<SqlParameter> sqlParameterList2 = sqlParameterList1;
      SqlParameter sqlParameter1 = new SqlParameter("@UserID", SqlDbType.UniqueIdentifier);
      sqlParameter1.Value = (object) userID.ToGuid();
      sqlParameterList2.Add(sqlParameter1);
      if (isNoRead)
        stringBuilder.Append(" AND IsRead=0");
      if (!dirID.IsNullOrEmpty())
        stringBuilder.Append(" AND DirectoryID IN(" + Tools.GetSqlInString(dirID, true, ",") + ")");
      else
        stringBuilder.Append(isNoRead ? "" : " AND 1=0");
      if (!title.IsNullOrEmpty())
      {
        stringBuilder.Append(" AND CHARINDEX(@Title,Title)>0");
        List<SqlParameter> sqlParameterList3 = sqlParameterList1;
        SqlParameter sqlParameter2 = new SqlParameter("@Title", SqlDbType.NVarChar);
        sqlParameter2.Value = (object) title;
        sqlParameterList3.Add(sqlParameter2);
      }
      DateTime dateTime;
      if (date1.IsDateTime())
      {
        stringBuilder.Append(" AND WriteTime>=@WriteTime");
        List<SqlParameter> sqlParameterList3 = sqlParameterList1;
        SqlParameter sqlParameter2 = new SqlParameter("@WriteTime", SqlDbType.DateTime);
        dateTime = date1.ToDateTime();
        sqlParameter2.Value = (object) dateTime.Date;
        sqlParameterList3.Add(sqlParameter2);
      }
      if (date2.IsDateTime())
      {
        stringBuilder.Append(" AND WriteTime<=@WriteTime1");
        List<SqlParameter> sqlParameterList3 = sqlParameterList1;
        SqlParameter sqlParameter2 = new SqlParameter("@WriteTime1", SqlDbType.DateTime);
        dateTime = date2.ToDateTime();
        dateTime = dateTime.AddDays(1.0);
        sqlParameter2.Value = (object) dateTime.Date;
        sqlParameterList3.Add(sqlParameter2);
      }
      return this.dbHelper.GetDataTable(this.dbHelper.GetPaerSql(stringBuilder.ToString(), size, number, out count, sqlParameterList1.ToArray()), sqlParameterList1.ToArray());
    }

    public int DeleteByDirectoryID(Guid directoryID)
    {
      string sql = "DELETE FROM Documents WHERE DirectoryID=@DirectoryID";
      SqlParameter[] sqlParameterArray = new SqlParameter[1];
      int index = 0;
      SqlParameter sqlParameter = new SqlParameter("@DirectoryID", SqlDbType.UniqueIdentifier);
      sqlParameter.Value = (object) directoryID;
      sqlParameterArray[index] = sqlParameter;
      SqlParameter[] parameter = sqlParameterArray;
      return this.dbHelper.Execute(sql, parameter, false);
    }
  }
}
