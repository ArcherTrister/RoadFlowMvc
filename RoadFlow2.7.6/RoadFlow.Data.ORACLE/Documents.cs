// Decompiled with JetBrains decompiler
// Type: RoadFlow.Data.ORACLE.Documents
// Assembly: RoadFlow.Data.ORACLE, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: C9018AA1-E48E-4231-92A9-CD6F0F275D11
// Assembly location: C:\inetpub\wwwroot\RoadFlowMvc\bin\RoadFlow.Data.ORACLE.dll

using Oracle.ManagedDataAccess.Client;
using RoadFlow.Data.Interface;
using RoadFlow.Utility;
using System;
using System.Collections.Generic;
using System.Data;
using System.Text;

namespace RoadFlow.Data.ORACLE
{
  public class Documents : IDocuments
  {
    private DBHelper dbHelper = new DBHelper();

    public int Add(RoadFlow.Data.Model.Documents model)
    {
      string sql = "INSERT INTO Documents\r\n\t\t\t\t(ID,DirectoryID,DirectoryName,Title,Source,Contents,Files,WriteTime,WriteUserID,WriteUserName,EditTime,EditUserID,EditUserName,ReadUsers,ReadCount) \r\n\t\t\t\tVALUES(:ID,:DirectoryID,:DirectoryName,:Title,:Source,:Contents,:Files,:WriteTime,:WriteUserID,:WriteUserName,:EditTime,:EditUserID,:EditUserName,:ReadUsers,:ReadCount)";
      OracleParameter[] oracleParameterArray = new OracleParameter[15];
      int index1 = 0;
      OracleParameter oracleParameter1 = new OracleParameter(":ID", OracleDbType.Varchar2);
      oracleParameter1.Value = (object) model.ID;
      oracleParameterArray[index1] = oracleParameter1;
      int index2 = 1;
      OracleParameter oracleParameter2 = new OracleParameter(":DirectoryID", OracleDbType.Varchar2);
      oracleParameter2.Value = (object) model.DirectoryID;
      oracleParameterArray[index2] = oracleParameter2;
      int index3 = 2;
      OracleParameter oracleParameter3 = new OracleParameter(":DirectoryName", OracleDbType.Varchar2);
      oracleParameter3.Value = (object) model.DirectoryName;
      oracleParameterArray[index3] = oracleParameter3;
      int index4 = 3;
      OracleParameter oracleParameter4 = new OracleParameter(":Title", OracleDbType.Varchar2);
      oracleParameter4.Value = (object) model.Title;
      oracleParameterArray[index4] = oracleParameter4;
      int index5 = 4;
      OracleParameter oracleParameter5 = new OracleParameter(":Source", OracleDbType.Varchar2);
      oracleParameter5.Value = (object) model.Source;
      oracleParameterArray[index5] = oracleParameter5;
      int index6 = 5;
      OracleParameter oracleParameter6 = new OracleParameter(":Contents", OracleDbType.Varchar2);
      oracleParameter6.Value = (object) model.Contents;
      oracleParameterArray[index6] = oracleParameter6;
      int index7 = 6;
      OracleParameter oracleParameter7;
      if (model.Files != null)
      {
        OracleParameter oracleParameter8 = new OracleParameter(":Files", OracleDbType.Varchar2);
        oracleParameter8.Value = (object) model.Files;
        oracleParameter7 = oracleParameter8;
      }
      else
      {
        oracleParameter7 = new OracleParameter(":Files", OracleDbType.Varchar2);
        oracleParameter7.Value = (object) DBNull.Value;
      }
      oracleParameterArray[index7] = oracleParameter7;
      int index8 = 7;
      OracleParameter oracleParameter9 = new OracleParameter(":WriteTime", OracleDbType.Date);
      oracleParameter9.Value = (object) model.WriteTime;
      oracleParameterArray[index8] = oracleParameter9;
      int index9 = 8;
      OracleParameter oracleParameter10 = new OracleParameter(":WriteUserID", OracleDbType.Varchar2);
      oracleParameter10.Value = (object) model.WriteUserID;
      oracleParameterArray[index9] = oracleParameter10;
      int index10 = 9;
      OracleParameter oracleParameter11 = new OracleParameter(":WriteUserName", OracleDbType.Varchar2);
      oracleParameter11.Value = (object) model.WriteUserName;
      oracleParameterArray[index10] = oracleParameter11;
      int index11 = 10;
      OracleParameter oracleParameter12;
      if (model.EditTime.HasValue)
      {
        OracleParameter oracleParameter8 = new OracleParameter(":EditTime", OracleDbType.Date);
        oracleParameter8.Value = (object) model.EditTime;
        oracleParameter12 = oracleParameter8;
      }
      else
      {
        oracleParameter12 = new OracleParameter(":EditTime", OracleDbType.Date);
        oracleParameter12.Value = (object) DBNull.Value;
      }
      oracleParameterArray[index11] = oracleParameter12;
      int index12 = 11;
      OracleParameter oracleParameter13;
      if (model.EditUserID.HasValue)
      {
        OracleParameter oracleParameter8 = new OracleParameter(":EditUserID", OracleDbType.Varchar2);
        oracleParameter8.Value = (object) model.EditUserID;
        oracleParameter13 = oracleParameter8;
      }
      else
      {
        oracleParameter13 = new OracleParameter(":EditUserID", OracleDbType.Varchar2);
        oracleParameter13.Value = (object) DBNull.Value;
      }
      oracleParameterArray[index12] = oracleParameter13;
      int index13 = 12;
      OracleParameter oracleParameter14;
      if (model.EditUserName != null)
      {
        OracleParameter oracleParameter8 = new OracleParameter(":EditUserName", OracleDbType.Varchar2);
        oracleParameter8.Value = (object) model.EditUserName;
        oracleParameter14 = oracleParameter8;
      }
      else
      {
        oracleParameter14 = new OracleParameter(":EditUserName", OracleDbType.Varchar2);
        oracleParameter14.Value = (object) DBNull.Value;
      }
      oracleParameterArray[index13] = oracleParameter14;
      int index14 = 13;
      OracleParameter oracleParameter15;
      if (model.ReadUsers != null)
      {
        OracleParameter oracleParameter8 = new OracleParameter(":ReadUsers", OracleDbType.Varchar2);
        oracleParameter8.Value = (object) model.ReadUsers;
        oracleParameter15 = oracleParameter8;
      }
      else
      {
        oracleParameter15 = new OracleParameter(":ReadUsers", OracleDbType.Varchar2);
        oracleParameter15.Value = (object) DBNull.Value;
      }
      oracleParameterArray[index14] = oracleParameter15;
      int index15 = 14;
      OracleParameter oracleParameter16 = new OracleParameter(":ReadCount", OracleDbType.Int32);
      oracleParameter16.Value = (object) model.ReadCount;
      oracleParameterArray[index15] = oracleParameter16;
      OracleParameter[] parameter = oracleParameterArray;
      return this.dbHelper.Execute(sql, parameter);
    }

    public int Update(RoadFlow.Data.Model.Documents model)
    {
      string sql = "UPDATE Documents SET \r\n\t\t\t\tDirectoryID=:DirectoryID,DirectoryName=:DirectoryName,Title=:Title,Source=:Source,Contents=:Contents,Files=:Files,WriteTime=:WriteTime,WriteUserID=:WriteUserID,WriteUserName=:WriteUserName,EditTime=:EditTime,EditUserID=:EditUserID,EditUserName=:EditUserName,ReadUsers=:ReadUsers,ReadCount=:ReadCount\r\n\t\t\t\tWHERE ID=:ID";
      OracleParameter[] oracleParameterArray = new OracleParameter[15];
      int index1 = 0;
      OracleParameter oracleParameter1 = new OracleParameter(":DirectoryID", OracleDbType.Varchar2);
      oracleParameter1.Value = (object) model.DirectoryID;
      oracleParameterArray[index1] = oracleParameter1;
      int index2 = 1;
      OracleParameter oracleParameter2 = new OracleParameter(":DirectoryName", OracleDbType.Varchar2);
      oracleParameter2.Value = (object) model.DirectoryName;
      oracleParameterArray[index2] = oracleParameter2;
      int index3 = 2;
      OracleParameter oracleParameter3 = new OracleParameter(":Title", OracleDbType.Varchar2);
      oracleParameter3.Value = (object) model.Title;
      oracleParameterArray[index3] = oracleParameter3;
      int index4 = 3;
      OracleParameter oracleParameter4 = new OracleParameter(":Source", OracleDbType.Varchar2);
      oracleParameter4.Value = (object) model.Source;
      oracleParameterArray[index4] = oracleParameter4;
      int index5 = 4;
      OracleParameter oracleParameter5 = new OracleParameter(":Contents", OracleDbType.Varchar2);
      oracleParameter5.Value = (object) model.Contents;
      oracleParameterArray[index5] = oracleParameter5;
      int index6 = 5;
      OracleParameter oracleParameter6;
      if (model.Files != null)
      {
        OracleParameter oracleParameter7 = new OracleParameter(":Files", OracleDbType.Varchar2);
        oracleParameter7.Value = (object) model.Files;
        oracleParameter6 = oracleParameter7;
      }
      else
      {
        oracleParameter6 = new OracleParameter(":Files", OracleDbType.Varchar2);
        oracleParameter6.Value = (object) DBNull.Value;
      }
      oracleParameterArray[index6] = oracleParameter6;
      int index7 = 6;
      OracleParameter oracleParameter8 = new OracleParameter(":WriteTime", OracleDbType.Date);
      oracleParameter8.Value = (object) model.WriteTime;
      oracleParameterArray[index7] = oracleParameter8;
      int index8 = 7;
      OracleParameter oracleParameter9 = new OracleParameter(":WriteUserID", OracleDbType.Varchar2);
      oracleParameter9.Value = (object) model.WriteUserID;
      oracleParameterArray[index8] = oracleParameter9;
      int index9 = 8;
      OracleParameter oracleParameter10 = new OracleParameter(":WriteUserName", OracleDbType.Varchar2);
      oracleParameter10.Value = (object) model.WriteUserName;
      oracleParameterArray[index9] = oracleParameter10;
      int index10 = 9;
      OracleParameter oracleParameter11;
      if (model.EditTime.HasValue)
      {
        OracleParameter oracleParameter7 = new OracleParameter(":EditTime", OracleDbType.Date);
        oracleParameter7.Value = (object) model.EditTime;
        oracleParameter11 = oracleParameter7;
      }
      else
      {
        oracleParameter11 = new OracleParameter(":EditTime", OracleDbType.Date);
        oracleParameter11.Value = (object) DBNull.Value;
      }
      oracleParameterArray[index10] = oracleParameter11;
      int index11 = 10;
      OracleParameter oracleParameter12;
      if (model.EditUserID.HasValue)
      {
        OracleParameter oracleParameter7 = new OracleParameter(":EditUserID", OracleDbType.Varchar2);
        oracleParameter7.Value = (object) model.EditUserID;
        oracleParameter12 = oracleParameter7;
      }
      else
      {
        oracleParameter12 = new OracleParameter(":EditUserID", OracleDbType.Varchar2);
        oracleParameter12.Value = (object) DBNull.Value;
      }
      oracleParameterArray[index11] = oracleParameter12;
      int index12 = 11;
      OracleParameter oracleParameter13;
      if (model.EditUserName != null)
      {
        OracleParameter oracleParameter7 = new OracleParameter(":EditUserName", OracleDbType.Varchar2);
        oracleParameter7.Value = (object) model.EditUserName;
        oracleParameter13 = oracleParameter7;
      }
      else
      {
        oracleParameter13 = new OracleParameter(":EditUserName", OracleDbType.Varchar2);
        oracleParameter13.Value = (object) DBNull.Value;
      }
      oracleParameterArray[index12] = oracleParameter13;
      int index13 = 12;
      OracleParameter oracleParameter14;
      if (model.ReadUsers != null)
      {
        OracleParameter oracleParameter7 = new OracleParameter(":ReadUsers", OracleDbType.Varchar2);
        oracleParameter7.Value = (object) model.ReadUsers;
        oracleParameter14 = oracleParameter7;
      }
      else
      {
        oracleParameter14 = new OracleParameter(":ReadUsers", OracleDbType.Varchar2);
        oracleParameter14.Value = (object) DBNull.Value;
      }
      oracleParameterArray[index13] = oracleParameter14;
      int index14 = 13;
      OracleParameter oracleParameter15 = new OracleParameter(":ReadCount", OracleDbType.Int32);
      oracleParameter15.Value = (object) model.ReadCount;
      oracleParameterArray[index14] = oracleParameter15;
      int index15 = 14;
      OracleParameter oracleParameter16 = new OracleParameter(":ID", OracleDbType.Varchar2);
      oracleParameter16.Value = (object) model.ID;
      oracleParameterArray[index15] = oracleParameter16;
      OracleParameter[] parameter = oracleParameterArray;
      return this.dbHelper.Execute(sql, parameter);
    }

    public int Delete(Guid id)
    {
      string sql = "DELETE FROM Documents WHERE ID=:ID";
      OracleParameter[] oracleParameterArray = new OracleParameter[1];
      int index = 0;
      OracleParameter oracleParameter = new OracleParameter(":ID", OracleDbType.Varchar2);
      oracleParameter.Value = (object) id;
      oracleParameterArray[index] = oracleParameter;
      OracleParameter[] parameter = oracleParameterArray;
      return this.dbHelper.Execute(sql, parameter);
    }

    private List<RoadFlow.Data.Model.Documents> DataReaderToList(OracleDataReader dataReader)
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
      OracleDataReader dataReader = this.dbHelper.GetDataReader("SELECT * FROM Documents");
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
      string sql = "SELECT * FROM Documents WHERE ID=:ID";
      OracleParameter[] oracleParameterArray = new OracleParameter[1];
      int index = 0;
      OracleParameter oracleParameter = new OracleParameter(":ID", OracleDbType.Varchar2);
      oracleParameter.Value = (object) id;
      oracleParameterArray[index] = oracleParameter;
      OracleParameter[] parameter = oracleParameterArray;
      OracleDataReader dataReader = this.dbHelper.GetDataReader(sql, parameter);
      List<RoadFlow.Data.Model.Documents> list = this.DataReaderToList(dataReader);
      dataReader.Close();
      if (list.Count <= 0)
        return (RoadFlow.Data.Model.Documents) null;
      return list[0];
    }

    public void UpdateReadCount(Guid id)
    {
      string sql = "UPDATE Documents SET ReadCount=ReadCount+1 WHERE ID=:ID";
      OracleParameter[] oracleParameterArray = new OracleParameter[1];
      int index = 0;
      OracleParameter oracleParameter = new OracleParameter(":ID", OracleDbType.Varchar2);
      oracleParameter.Value = (object) id;
      oracleParameterArray[index] = oracleParameter;
      OracleParameter[] parameter = oracleParameterArray;
      this.dbHelper.Execute(sql, parameter);
    }

    public DataTable GetList(out string pager, string dirID, string userID, string query = "", string title = "", string date1 = "", string date2 = "", bool isNoRead = false)
    {
      List<OracleParameter> oracleParameterList1 = new List<OracleParameter>();
      StringBuilder stringBuilder = new StringBuilder("SELECT ID,DirectoryID,DirectoryName,Title,WriteTime,WriteUserName,IsRead,ReadCount,ROWNUM AS PagerAutoRowNumber FROM Documents a LEFT JOIN DocumentsReadUsers b ON a.ID=b.DocumentID WHERE b.UserID=:UserID");
      List<OracleParameter> oracleParameterList2 = oracleParameterList1;
      OracleParameter oracleParameter1 = new OracleParameter(":UserID", OracleDbType.Varchar2);
      oracleParameter1.Value = (object) userID.ToGuid();
      oracleParameterList2.Add(oracleParameter1);
      if (isNoRead)
        stringBuilder.Append(" AND IsRead=0");
      if (!dirID.IsNullOrEmpty())
        stringBuilder.Append(" AND DirectoryID IN(" + Tools.GetSqlInString(dirID, true, ",") + ")");
      else
        stringBuilder.Append(isNoRead ? " AND IsRead=0" : " AND 1=0");
      if (!title.IsNullOrEmpty())
      {
        stringBuilder.Append(" AND INSTR(Title,:Title,1,1)>0");
        List<OracleParameter> oracleParameterList3 = oracleParameterList1;
        OracleParameter oracleParameter2 = new OracleParameter(":Title", OracleDbType.Varchar2);
        oracleParameter2.Value = (object) title;
        oracleParameterList3.Add(oracleParameter2);
      }
      if (date1.IsDateTime())
      {
        stringBuilder.Append(" AND WriteTime>=:WriteTime");
        List<OracleParameter> oracleParameterList3 = oracleParameterList1;
        OracleParameter oracleParameter2 = new OracleParameter(":WriteTime", OracleDbType.Date);
        oracleParameter2.Value = (object) date1.ToDateTime().Date;
        oracleParameterList3.Add(oracleParameter2);
      }
      if (date2.IsDateTime())
      {
        stringBuilder.Append(" AND WriteTime<=:WriteTime1");
        List<OracleParameter> oracleParameterList3 = oracleParameterList1;
        OracleParameter oracleParameter2 = new OracleParameter(":WriteTime1", OracleDbType.Date);
        oracleParameter2.Value = (object) date2.ToDateTime().AddDays(1.0).Date;
        oracleParameterList3.Add(oracleParameter2);
      }
      stringBuilder.Append(" ORDER BY WriteTime DESC");
      int pageSize = Tools.GetPageSize();
      int pageNumber = Tools.GetPageNumber();
      long count;
      string paerSql = this.dbHelper.GetPaerSql(stringBuilder.ToString(), pageSize, pageNumber, out count, oracleParameterList1.ToArray());
      pager = Tools.GetPagerHtml(count, pageSize, pageNumber, query);
      return this.dbHelper.GetDataTable(paerSql, oracleParameterList1.ToArray());
    }

    public DataTable GetList(out long count, int size, int number, string dirID, string userID, string title = "", string date1 = "", string date2 = "", bool isNoRead = false, string order = "")
    {
      List<OracleParameter> oracleParameterList1 = new List<OracleParameter>();
      StringBuilder stringBuilder = new StringBuilder("SELECT ID,DirectoryID,DirectoryName,Title,WriteTime,WriteUserName,IsRead,ReadCount,ROWNUM AS PagerAutoRowNumber FROM Documents a LEFT JOIN DocumentsReadUsers b ON a.ID=b.DocumentID WHERE b.UserID=:UserID");
      List<OracleParameter> oracleParameterList2 = oracleParameterList1;
      OracleParameter oracleParameter1 = new OracleParameter(":UserID", OracleDbType.Varchar2);
      oracleParameter1.Value = (object) userID.ToGuid();
      oracleParameterList2.Add(oracleParameter1);
      if (isNoRead)
        stringBuilder.Append(" AND IsRead=0");
      if (!dirID.IsNullOrEmpty())
        stringBuilder.Append(" AND DirectoryID IN(" + Tools.GetSqlInString(dirID, true, ",") + ")");
      else
        stringBuilder.Append(isNoRead ? " AND IsRead=0" : " AND 1=0");
      if (!title.IsNullOrEmpty())
      {
        stringBuilder.Append(" AND INSTR(Title,:Title,1,1)>0");
        List<OracleParameter> oracleParameterList3 = oracleParameterList1;
        OracleParameter oracleParameter2 = new OracleParameter(":Title", OracleDbType.Varchar2);
        oracleParameter2.Value = (object) title;
        oracleParameterList3.Add(oracleParameter2);
      }
      if (date1.IsDateTime())
      {
        stringBuilder.Append(" AND WriteTime>=:WriteTime");
        List<OracleParameter> oracleParameterList3 = oracleParameterList1;
        OracleParameter oracleParameter2 = new OracleParameter(":WriteTime", OracleDbType.Date);
        oracleParameter2.Value = (object) date1.ToDateTime().Date;
        oracleParameterList3.Add(oracleParameter2);
      }
      if (date2.IsDateTime())
      {
        stringBuilder.Append(" AND WriteTime<=:WriteTime1");
        List<OracleParameter> oracleParameterList3 = oracleParameterList1;
        OracleParameter oracleParameter2 = new OracleParameter(":WriteTime1", OracleDbType.Date);
        oracleParameter2.Value = (object) date2.ToDateTime().AddDays(1.0).Date;
        oracleParameterList3.Add(oracleParameter2);
      }
      stringBuilder.Append(" ORDER BY " + (order.IsNullOrEmpty() ? "WriteTime DESC" : order));
      return this.dbHelper.GetDataTable(this.dbHelper.GetPaerSql(stringBuilder.ToString(), size, number, out count, oracleParameterList1.ToArray()), oracleParameterList1.ToArray());
    }

    public int DeleteByDirectoryID(Guid directoryID)
    {
      string sql = "DELETE FROM Documents WHERE DirectoryID=:DirectoryID";
      OracleParameter[] oracleParameterArray = new OracleParameter[1];
      int index = 0;
      OracleParameter oracleParameter = new OracleParameter(":DirectoryID", OracleDbType.Varchar2);
      oracleParameter.Value = (object) directoryID;
      oracleParameterArray[index] = oracleParameter;
      OracleParameter[] parameter = oracleParameterArray;
      return this.dbHelper.Execute(sql, parameter);
    }
  }
}
