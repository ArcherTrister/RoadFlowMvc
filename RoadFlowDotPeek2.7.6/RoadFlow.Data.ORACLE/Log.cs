// Decompiled with JetBrains decompiler
// Type: RoadFlow.Data.ORACLE.Log
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
  public class Log : ILog
  {
    private DBHelper dbHelper = new DBHelper();

    public int Add(RoadFlow.Data.Model.Log model)
    {
      string sql = "INSERT INTO Log\r\n\t\t\t\t(ID,Title,Type,WriteTime,UserID,UserName,IPAddress,URL,Contents,Others,OldXml,NewXml) \r\n\t\t\t\tVALUES(:ID,:Title,:Type,:WriteTime,:UserID,:UserName,:IPAddress,:URL,:Contents,:Others,:OldXml,:NewXml)";
      OracleParameter[] oracleParameterArray = new OracleParameter[12];
      int index1 = 0;
      OracleParameter oracleParameter1 = new OracleParameter(":ID", OracleDbType.Varchar2, 40);
      oracleParameter1.Value = (object) model.ID;
      oracleParameterArray[index1] = oracleParameter1;
      int index2 = 1;
      OracleParameter oracleParameter2 = new OracleParameter(":Title", OracleDbType.NVarchar2);
      oracleParameter2.Value = (object) model.Title;
      oracleParameterArray[index2] = oracleParameter2;
      int index3 = 2;
      OracleParameter oracleParameter3 = new OracleParameter(":Type", OracleDbType.NVarchar2, 100);
      oracleParameter3.Value = (object) model.Type;
      oracleParameterArray[index3] = oracleParameter3;
      int index4 = 3;
      OracleParameter oracleParameter4 = new OracleParameter(":WriteTime", OracleDbType.Date, 8);
      oracleParameter4.Value = (object) model.WriteTime;
      oracleParameterArray[index4] = oracleParameter4;
      int index5 = 4;
      OracleParameter oracleParameter5;
      if (model.UserID.HasValue)
      {
        OracleParameter oracleParameter6 = new OracleParameter(":UserID", OracleDbType.Varchar2, 40);
        oracleParameter6.Value = (object) model.UserID;
        oracleParameter5 = oracleParameter6;
      }
      else
      {
        oracleParameter5 = new OracleParameter(":UserID", OracleDbType.Varchar2, 40);
        oracleParameter5.Value = (object) DBNull.Value;
      }
      oracleParameterArray[index5] = oracleParameter5;
      int index6 = 5;
      OracleParameter oracleParameter7;
      if (model.UserName != null)
      {
        OracleParameter oracleParameter6 = new OracleParameter(":UserName", OracleDbType.NVarchar2, 100);
        oracleParameter6.Value = (object) model.UserName;
        oracleParameter7 = oracleParameter6;
      }
      else
      {
        oracleParameter7 = new OracleParameter(":UserName", OracleDbType.NVarchar2, 100);
        oracleParameter7.Value = (object) DBNull.Value;
      }
      oracleParameterArray[index6] = oracleParameter7;
      int index7 = 6;
      OracleParameter oracleParameter8;
      if (model.IPAddress != null)
      {
        OracleParameter oracleParameter6 = new OracleParameter(":IPAddress", OracleDbType.Varchar2, 50);
        oracleParameter6.Value = (object) model.IPAddress;
        oracleParameter8 = oracleParameter6;
      }
      else
      {
        oracleParameter8 = new OracleParameter(":IPAddress", OracleDbType.Varchar2, 50);
        oracleParameter8.Value = (object) DBNull.Value;
      }
      oracleParameterArray[index7] = oracleParameter8;
      int index8 = 7;
      OracleParameter oracleParameter9;
      if (model.URL != null)
      {
        OracleParameter oracleParameter6 = new OracleParameter(":URL", OracleDbType.Clob);
        oracleParameter6.Value = (object) model.URL;
        oracleParameter9 = oracleParameter6;
      }
      else
      {
        oracleParameter9 = new OracleParameter(":URL", OracleDbType.Clob);
        oracleParameter9.Value = (object) DBNull.Value;
      }
      oracleParameterArray[index8] = oracleParameter9;
      int index9 = 8;
      OracleParameter oracleParameter10;
      if (model.Contents != null)
      {
        OracleParameter oracleParameter6 = new OracleParameter(":Contents", OracleDbType.Clob);
        oracleParameter6.Value = (object) model.Contents;
        oracleParameter10 = oracleParameter6;
      }
      else
      {
        oracleParameter10 = new OracleParameter(":Contents", OracleDbType.Clob);
        oracleParameter10.Value = (object) DBNull.Value;
      }
      oracleParameterArray[index9] = oracleParameter10;
      int index10 = 9;
      OracleParameter oracleParameter11;
      if (model.Others != null)
      {
        OracleParameter oracleParameter6 = new OracleParameter(":Others", OracleDbType.Clob);
        oracleParameter6.Value = (object) model.Others;
        oracleParameter11 = oracleParameter6;
      }
      else
      {
        oracleParameter11 = new OracleParameter(":Others", OracleDbType.Clob);
        oracleParameter11.Value = (object) DBNull.Value;
      }
      oracleParameterArray[index10] = oracleParameter11;
      int index11 = 10;
      OracleParameter oracleParameter12;
      if (model.OldXml != null)
      {
        OracleParameter oracleParameter6 = new OracleParameter(":OldXml", OracleDbType.Clob);
        oracleParameter6.Value = (object) model.OldXml;
        oracleParameter12 = oracleParameter6;
      }
      else
      {
        oracleParameter12 = new OracleParameter(":OldXml", OracleDbType.Clob);
        oracleParameter12.Value = (object) DBNull.Value;
      }
      oracleParameterArray[index11] = oracleParameter12;
      int index12 = 11;
      OracleParameter oracleParameter13;
      if (model.NewXml != null)
      {
        OracleParameter oracleParameter6 = new OracleParameter(":NewXml", OracleDbType.Clob);
        oracleParameter6.Value = (object) model.NewXml;
        oracleParameter13 = oracleParameter6;
      }
      else
      {
        oracleParameter13 = new OracleParameter(":NewXml", OracleDbType.Clob);
        oracleParameter13.Value = (object) DBNull.Value;
      }
      oracleParameterArray[index12] = oracleParameter13;
      OracleParameter[] parameter = oracleParameterArray;
      return this.dbHelper.Execute(sql, parameter);
    }

    public int Update(RoadFlow.Data.Model.Log model)
    {
      string sql = "UPDATE Log SET \r\n\t\t\t\tTitle=:Title,Type=:Type,WriteTime=:WriteTime,UserID=:UserID,UserName=:UserName,IPAddress=:IPAddress,URL=:URL,Contents=:Contents,Others=:Others,OldXml=:OldXml,NewXml=:NewXml\r\n\t\t\t\tWHERE ID=:ID";
      OracleParameter[] oracleParameterArray = new OracleParameter[12];
      int index1 = 0;
      OracleParameter oracleParameter1 = new OracleParameter(":Title", OracleDbType.NVarchar2);
      oracleParameter1.Value = (object) model.Title;
      oracleParameterArray[index1] = oracleParameter1;
      int index2 = 1;
      OracleParameter oracleParameter2 = new OracleParameter(":Type", OracleDbType.NVarchar2, 100);
      oracleParameter2.Value = (object) model.Type;
      oracleParameterArray[index2] = oracleParameter2;
      int index3 = 2;
      OracleParameter oracleParameter3 = new OracleParameter(":WriteTime", OracleDbType.Date, 8);
      oracleParameter3.Value = (object) model.WriteTime;
      oracleParameterArray[index3] = oracleParameter3;
      int index4 = 3;
      OracleParameter oracleParameter4;
      if (model.UserID.HasValue)
      {
        OracleParameter oracleParameter5 = new OracleParameter(":UserID", OracleDbType.Varchar2, 40);
        oracleParameter5.Value = (object) model.UserID;
        oracleParameter4 = oracleParameter5;
      }
      else
      {
        oracleParameter4 = new OracleParameter(":UserID", OracleDbType.Varchar2, 40);
        oracleParameter4.Value = (object) DBNull.Value;
      }
      oracleParameterArray[index4] = oracleParameter4;
      int index5 = 4;
      OracleParameter oracleParameter6;
      if (model.UserName != null)
      {
        OracleParameter oracleParameter5 = new OracleParameter(":UserName", OracleDbType.NVarchar2, 100);
        oracleParameter5.Value = (object) model.UserName;
        oracleParameter6 = oracleParameter5;
      }
      else
      {
        oracleParameter6 = new OracleParameter(":UserName", OracleDbType.NVarchar2, 100);
        oracleParameter6.Value = (object) DBNull.Value;
      }
      oracleParameterArray[index5] = oracleParameter6;
      int index6 = 5;
      OracleParameter oracleParameter7;
      if (model.IPAddress != null)
      {
        OracleParameter oracleParameter5 = new OracleParameter(":IPAddress", OracleDbType.Varchar2, 50);
        oracleParameter5.Value = (object) model.IPAddress;
        oracleParameter7 = oracleParameter5;
      }
      else
      {
        oracleParameter7 = new OracleParameter(":IPAddress", OracleDbType.Varchar2, 50);
        oracleParameter7.Value = (object) DBNull.Value;
      }
      oracleParameterArray[index6] = oracleParameter7;
      int index7 = 6;
      OracleParameter oracleParameter8;
      if (model.URL != null)
      {
        OracleParameter oracleParameter5 = new OracleParameter(":URL", OracleDbType.Clob);
        oracleParameter5.Value = (object) model.URL;
        oracleParameter8 = oracleParameter5;
      }
      else
      {
        oracleParameter8 = new OracleParameter(":URL", OracleDbType.Clob);
        oracleParameter8.Value = (object) DBNull.Value;
      }
      oracleParameterArray[index7] = oracleParameter8;
      int index8 = 7;
      OracleParameter oracleParameter9;
      if (model.Contents != null)
      {
        OracleParameter oracleParameter5 = new OracleParameter(":Contents", OracleDbType.Clob);
        oracleParameter5.Value = (object) model.Contents;
        oracleParameter9 = oracleParameter5;
      }
      else
      {
        oracleParameter9 = new OracleParameter(":Contents", OracleDbType.Clob);
        oracleParameter9.Value = (object) DBNull.Value;
      }
      oracleParameterArray[index8] = oracleParameter9;
      int index9 = 8;
      OracleParameter oracleParameter10;
      if (model.Others != null)
      {
        OracleParameter oracleParameter5 = new OracleParameter(":Others", OracleDbType.Clob);
        oracleParameter5.Value = (object) model.Others;
        oracleParameter10 = oracleParameter5;
      }
      else
      {
        oracleParameter10 = new OracleParameter(":Others", OracleDbType.Clob);
        oracleParameter10.Value = (object) DBNull.Value;
      }
      oracleParameterArray[index9] = oracleParameter10;
      int index10 = 9;
      OracleParameter oracleParameter11;
      if (model.OldXml != null)
      {
        OracleParameter oracleParameter5 = new OracleParameter(":OldXml", OracleDbType.Clob);
        oracleParameter5.Value = (object) model.OldXml;
        oracleParameter11 = oracleParameter5;
      }
      else
      {
        oracleParameter11 = new OracleParameter(":OldXml", OracleDbType.Clob);
        oracleParameter11.Value = (object) DBNull.Value;
      }
      oracleParameterArray[index10] = oracleParameter11;
      int index11 = 10;
      OracleParameter oracleParameter12;
      if (model.NewXml != null)
      {
        OracleParameter oracleParameter5 = new OracleParameter(":NewXml", OracleDbType.Clob);
        oracleParameter5.Value = (object) model.NewXml;
        oracleParameter12 = oracleParameter5;
      }
      else
      {
        oracleParameter12 = new OracleParameter(":NewXml", OracleDbType.Clob);
        oracleParameter12.Value = (object) DBNull.Value;
      }
      oracleParameterArray[index11] = oracleParameter12;
      int index12 = 11;
      OracleParameter oracleParameter13 = new OracleParameter(":ID", OracleDbType.Varchar2, 40);
      oracleParameter13.Value = (object) model.ID;
      oracleParameterArray[index12] = oracleParameter13;
      OracleParameter[] parameter = oracleParameterArray;
      return this.dbHelper.Execute(sql, parameter);
    }

    public int Delete(Guid id)
    {
      string sql = "DELETE FROM Log WHERE ID=:ID";
      OracleParameter[] oracleParameterArray = new OracleParameter[1];
      int index = 0;
      OracleParameter oracleParameter = new OracleParameter(":ID", OracleDbType.Varchar2);
      oracleParameter.Value = (object) id;
      oracleParameterArray[index] = oracleParameter;
      OracleParameter[] parameter = oracleParameterArray;
      return this.dbHelper.Execute(sql, parameter);
    }

    private List<RoadFlow.Data.Model.Log> DataReaderToList(OracleDataReader dataReader)
    {
      List<RoadFlow.Data.Model.Log> logList = new List<RoadFlow.Data.Model.Log>();
      while (dataReader.Read())
      {
        RoadFlow.Data.Model.Log log = new RoadFlow.Data.Model.Log();
        log.ID = dataReader.GetString(0).ToGuid();
        log.Title = dataReader.GetString(1);
        log.Type = dataReader.GetString(2);
        log.WriteTime = dataReader.GetDateTime(3);
        if (!dataReader.IsDBNull(4))
          log.UserID = new Guid?(dataReader.GetString(4).ToGuid());
        if (!dataReader.IsDBNull(5))
          log.UserName = dataReader.GetString(5);
        if (!dataReader.IsDBNull(6))
          log.IPAddress = dataReader.GetString(6);
        if (!dataReader.IsDBNull(7))
          log.URL = dataReader.GetString(7);
        if (!dataReader.IsDBNull(8))
          log.Contents = dataReader.GetString(8);
        if (!dataReader.IsDBNull(9))
          log.Others = dataReader.GetString(9);
        if (!dataReader.IsDBNull(10))
          log.OldXml = dataReader.GetString(10);
        if (!dataReader.IsDBNull(11))
          log.NewXml = dataReader.GetString(11);
        logList.Add(log);
      }
      return logList;
    }

    public List<RoadFlow.Data.Model.Log> GetAll()
    {
      OracleDataReader dataReader = this.dbHelper.GetDataReader("SELECT * FROM Log");
      List<RoadFlow.Data.Model.Log> list = this.DataReaderToList(dataReader);
      dataReader.Close();
      return list;
    }

    public long GetCount()
    {
      long result;
      if (!long.TryParse(this.dbHelper.GetFieldValue("SELECT COUNT(*) FROM Log"), out result))
        return 0;
      return result;
    }

    public RoadFlow.Data.Model.Log Get(Guid id)
    {
      string sql = "SELECT * FROM Log WHERE ID=:ID";
      OracleParameter[] oracleParameterArray = new OracleParameter[1];
      int index = 0;
      OracleParameter oracleParameter = new OracleParameter(":ID", OracleDbType.Varchar2);
      oracleParameter.Value = (object) id;
      oracleParameterArray[index] = oracleParameter;
      OracleParameter[] parameter = oracleParameterArray;
      OracleDataReader dataReader = this.dbHelper.GetDataReader(sql, parameter);
      List<RoadFlow.Data.Model.Log> list = this.DataReaderToList(dataReader);
      dataReader.Close();
      if (list.Count <= 0)
        return (RoadFlow.Data.Model.Log) null;
      return list[0];
    }

    public DataTable GetPagerData(out string pager, string query = "", int size = 15, int number = 1, string title = "", string type = "", string date1 = "", string date2 = "", string userID = "")
    {
      StringBuilder stringBuilder = new StringBuilder();
      List<OracleParameter> oracleParameterList1 = new List<OracleParameter>();
      if (!title.IsNullOrEmpty())
      {
        stringBuilder.Append("AND INSTR(Title,:Title,1,1)>0 ");
        List<OracleParameter> oracleParameterList2 = oracleParameterList1;
        OracleParameter oracleParameter = new OracleParameter(":Title", OracleDbType.NVarchar2);
        oracleParameter.Value = (object) title;
        oracleParameterList2.Add(oracleParameter);
      }
      if (!type.IsNullOrEmpty())
      {
        stringBuilder.Append("AND Type=:Type ");
        List<OracleParameter> oracleParameterList2 = oracleParameterList1;
        OracleParameter oracleParameter = new OracleParameter(":Type", OracleDbType.NVarchar2);
        oracleParameter.Value = (object) type;
        oracleParameterList2.Add(oracleParameter);
      }
      if (date1.IsDateTime())
      {
        stringBuilder.Append("AND WriteTime>=:Date1 ");
        List<OracleParameter> oracleParameterList2 = oracleParameterList1;
        OracleParameter oracleParameter = new OracleParameter(":Date1", OracleDbType.Date);
        oracleParameter.Value = (object) date1.ToDateTime().ToString("yyyy-MM-dd 00:00:00").ToDateTime();
        oracleParameterList2.Add(oracleParameter);
      }
      if (date2.IsDateTime())
      {
        stringBuilder.Append("AND WriteTime<=:Date2 ");
        List<OracleParameter> oracleParameterList2 = oracleParameterList1;
        OracleParameter oracleParameter = new OracleParameter(":Date2", OracleDbType.Date);
        DateTime dateTime = date2.ToDateTime();
        dateTime = dateTime.AddDays(1.0);
        oracleParameter.Value = (object) dateTime.ToString("yyyy-MM-dd 00:00:00").ToDateTime();
        oracleParameterList2.Add(oracleParameter);
      }
      if (userID.IsGuid())
      {
        stringBuilder.Append("AND UserID=:UserID ");
        List<OracleParameter> oracleParameterList2 = oracleParameterList1;
        OracleParameter oracleParameter = new OracleParameter(":UserID", OracleDbType.Varchar2);
        oracleParameter.Value = (object) userID.ToGuid();
        oracleParameterList2.Add(oracleParameter);
      }
      long count;
      string paerSql = this.dbHelper.GetPaerSql(nameof (Log), "ID,Title,Type,WriteTime,UserName,IPAddress", stringBuilder.ToString(), "WriteTime DESC", size, number, out count, oracleParameterList1.ToArray());
      pager = Tools.GetPagerHtml(count, size, number, query);
      return this.dbHelper.GetDataTable(paerSql.ToString(), oracleParameterList1.ToArray());
    }

    public DataTable GetPagerData(out long count, int size = 15, int number = 1, string title = "", string type = "", string date1 = "", string date2 = "", string userID = "", string order = "")
    {
      StringBuilder stringBuilder = new StringBuilder();
      List<OracleParameter> oracleParameterList1 = new List<OracleParameter>();
      if (!title.IsNullOrEmpty())
      {
        stringBuilder.Append("AND INSTR(Title,:Title,1,1)>0 ");
        List<OracleParameter> oracleParameterList2 = oracleParameterList1;
        OracleParameter oracleParameter = new OracleParameter(":Title", OracleDbType.NVarchar2);
        oracleParameter.Value = (object) title;
        oracleParameterList2.Add(oracleParameter);
      }
      if (!type.IsNullOrEmpty())
      {
        stringBuilder.Append("AND Type=:Type ");
        List<OracleParameter> oracleParameterList2 = oracleParameterList1;
        OracleParameter oracleParameter = new OracleParameter(":Type", OracleDbType.NVarchar2);
        oracleParameter.Value = (object) type;
        oracleParameterList2.Add(oracleParameter);
      }
      if (date1.IsDateTime())
      {
        stringBuilder.Append("AND WriteTime>=:Date1 ");
        List<OracleParameter> oracleParameterList2 = oracleParameterList1;
        OracleParameter oracleParameter = new OracleParameter(":Date1", OracleDbType.Date);
        oracleParameter.Value = (object) date1.ToDateTime().ToString("yyyy-MM-dd 00:00:00").ToDateTime();
        oracleParameterList2.Add(oracleParameter);
      }
      if (date2.IsDateTime())
      {
        stringBuilder.Append("AND WriteTime<=:Date2 ");
        List<OracleParameter> oracleParameterList2 = oracleParameterList1;
        OracleParameter oracleParameter = new OracleParameter(":Date2", OracleDbType.Date);
        DateTime dateTime = date2.ToDateTime();
        dateTime = dateTime.AddDays(1.0);
        oracleParameter.Value = (object) dateTime.ToString("yyyy-MM-dd 00:00:00").ToDateTime();
        oracleParameterList2.Add(oracleParameter);
      }
      if (userID.IsGuid())
      {
        stringBuilder.Append("AND UserID=:UserID ");
        List<OracleParameter> oracleParameterList2 = oracleParameterList1;
        OracleParameter oracleParameter = new OracleParameter(":UserID", OracleDbType.Varchar2);
        oracleParameter.Value = (object) userID;
        oracleParameterList2.Add(oracleParameter);
      }
      return this.dbHelper.GetDataTable(this.dbHelper.GetPaerSql(nameof (Log), "ID,Title,Type,WriteTime,UserName,IPAddress", stringBuilder.ToString(), order.IsNullOrEmpty() ? "WriteTime DESC" : order, size, number, out count, oracleParameterList1.ToArray()).ToString(), oracleParameterList1.ToArray());
    }
  }
}
