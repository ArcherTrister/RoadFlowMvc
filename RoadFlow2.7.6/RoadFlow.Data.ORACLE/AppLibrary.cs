// Decompiled with JetBrains decompiler
// Type: RoadFlow.Data.ORACLE.AppLibrary
// Assembly: RoadFlow.Data.ORACLE, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: C9018AA1-E48E-4231-92A9-CD6F0F275D11
// Assembly location: C:\inetpub\wwwroot\RoadFlowMvc\bin\RoadFlow.Data.ORACLE.dll

using Oracle.ManagedDataAccess.Client;
using RoadFlow.Data.Interface;
using RoadFlow.Utility;
using System;
using System.Collections.Generic;
using System.Text;

namespace RoadFlow.Data.ORACLE
{
  public class AppLibrary : IAppLibrary
  {
    private DBHelper dbHelper = new DBHelper();

    public int Add(RoadFlow.Data.Model.AppLibrary model)
    {
      string sql = "INSERT INTO AppLibrary\r\n\t\t\t\t(ID,Title,Address,Type,OpenMode,Width,Height,Params,Manager,Note,Code,Ico,Color) \r\n\t\t\t\tVALUES(:ID,:Title,:Address,:Type,:OpenMode,:Width,:Height,:Params,:Manager,:Note,:Code,:Ico,:Color)";
      OracleParameter[] oracleParameterArray = new OracleParameter[13];
      int index1 = 0;
      OracleParameter oracleParameter1 = new OracleParameter(":ID", OracleDbType.Varchar2, 40);
      oracleParameter1.Value = (object) model.ID;
      oracleParameterArray[index1] = oracleParameter1;
      int index2 = 1;
      OracleParameter oracleParameter2 = new OracleParameter(":Title", OracleDbType.NVarchar2, 510);
      oracleParameter2.Value = (object) model.Title;
      oracleParameterArray[index2] = oracleParameter2;
      int index3 = 2;
      OracleParameter oracleParameter3 = new OracleParameter(":Address", OracleDbType.Varchar2, 200);
      oracleParameter3.Value = (object) model.Address;
      oracleParameterArray[index3] = oracleParameter3;
      int index4 = 3;
      OracleParameter oracleParameter4 = new OracleParameter(":Type", OracleDbType.Varchar2, 40);
      oracleParameter4.Value = (object) model.Type;
      oracleParameterArray[index4] = oracleParameter4;
      int index5 = 4;
      OracleParameter oracleParameter5 = new OracleParameter(":OpenMode", OracleDbType.Int32);
      oracleParameter5.Value = (object) model.OpenMode;
      oracleParameterArray[index5] = oracleParameter5;
      int index6 = 5;
      OracleParameter oracleParameter6;
      if (model.Width.HasValue)
      {
        OracleParameter oracleParameter7 = new OracleParameter(":Width", OracleDbType.Int32);
        oracleParameter7.Value = (object) model.Width;
        oracleParameter6 = oracleParameter7;
      }
      else
      {
        oracleParameter6 = new OracleParameter(":Width", OracleDbType.Int32);
        oracleParameter6.Value = (object) DBNull.Value;
      }
      oracleParameterArray[index6] = oracleParameter6;
      int index7 = 6;
      OracleParameter oracleParameter8;
      if (model.Height.HasValue)
      {
        OracleParameter oracleParameter7 = new OracleParameter(":Height", OracleDbType.Int32);
        oracleParameter7.Value = (object) model.Height;
        oracleParameter8 = oracleParameter7;
      }
      else
      {
        oracleParameter8 = new OracleParameter(":Height", OracleDbType.Int32);
        oracleParameter8.Value = (object) DBNull.Value;
      }
      oracleParameterArray[index7] = oracleParameter8;
      int index8 = 7;
      OracleParameter oracleParameter9;
      if (model.Params != null)
      {
        OracleParameter oracleParameter7 = new OracleParameter(":Params", OracleDbType.Clob);
        oracleParameter7.Value = (object) model.Params;
        oracleParameter9 = oracleParameter7;
      }
      else
      {
        oracleParameter9 = new OracleParameter(":Params", OracleDbType.Clob);
        oracleParameter9.Value = (object) DBNull.Value;
      }
      oracleParameterArray[index8] = oracleParameter9;
      int index9 = 8;
      OracleParameter oracleParameter10;
      if (model.Manager != null)
      {
        OracleParameter oracleParameter7 = new OracleParameter(":Manager", OracleDbType.Clob);
        oracleParameter7.Value = (object) model.Manager;
        oracleParameter10 = oracleParameter7;
      }
      else
      {
        oracleParameter10 = new OracleParameter(":Manager", OracleDbType.Clob);
        oracleParameter10.Value = (object) DBNull.Value;
      }
      oracleParameterArray[index9] = oracleParameter10;
      int index10 = 9;
      OracleParameter oracleParameter11;
      if (model.Note != null)
      {
        OracleParameter oracleParameter7 = new OracleParameter(":Note", OracleDbType.Clob);
        oracleParameter7.Value = (object) model.Note;
        oracleParameter11 = oracleParameter7;
      }
      else
      {
        oracleParameter11 = new OracleParameter(":Note", OracleDbType.Clob);
        oracleParameter11.Value = (object) DBNull.Value;
      }
      oracleParameterArray[index10] = oracleParameter11;
      int index11 = 10;
      OracleParameter oracleParameter12;
      if (model.Code != null)
      {
        OracleParameter oracleParameter7 = new OracleParameter(":Code", OracleDbType.Varchar2, 50);
        oracleParameter7.Value = (object) model.Code;
        oracleParameter12 = oracleParameter7;
      }
      else
      {
        oracleParameter12 = new OracleParameter(":Code", OracleDbType.Varchar2, 50);
        oracleParameter12.Value = (object) DBNull.Value;
      }
      oracleParameterArray[index11] = oracleParameter12;
      int index12 = 11;
      OracleParameter oracleParameter13;
      if (model.Ico != null)
      {
        OracleParameter oracleParameter7 = new OracleParameter(":Ico", OracleDbType.Varchar2);
        oracleParameter7.Value = (object) model.Ico;
        oracleParameter13 = oracleParameter7;
      }
      else
      {
        oracleParameter13 = new OracleParameter(":Ico", OracleDbType.Varchar2);
        oracleParameter13.Value = (object) DBNull.Value;
      }
      oracleParameterArray[index12] = oracleParameter13;
      int index13 = 12;
      OracleParameter oracleParameter14;
      if (model.Color != null)
      {
        OracleParameter oracleParameter7 = new OracleParameter(":Color", OracleDbType.Varchar2);
        oracleParameter7.Value = (object) model.Color;
        oracleParameter14 = oracleParameter7;
      }
      else
      {
        oracleParameter14 = new OracleParameter(":Color", OracleDbType.Varchar2);
        oracleParameter14.Value = (object) DBNull.Value;
      }
      oracleParameterArray[index13] = oracleParameter14;
      OracleParameter[] parameter = oracleParameterArray;
      return this.dbHelper.Execute(sql, parameter);
    }

    public int Update(RoadFlow.Data.Model.AppLibrary model)
    {
      string sql = "UPDATE AppLibrary SET \r\n\t\t\t\tTitle=:Title,Address=:Address,Type=:Type,OpenMode=:OpenMode,Width=:Width,Height=:Height,Params=:Params,Manager=:Manager,Note=:Note,Code=:Code,Ico=:Ico,Color=:Color\r\n\t\t\t\tWHERE ID=:ID";
      OracleParameter[] oracleParameterArray = new OracleParameter[13];
      int index1 = 0;
      OracleParameter oracleParameter1 = new OracleParameter(":Title", OracleDbType.NVarchar2, 510);
      oracleParameter1.Value = (object) model.Title;
      oracleParameterArray[index1] = oracleParameter1;
      int index2 = 1;
      OracleParameter oracleParameter2 = new OracleParameter(":Address", OracleDbType.Varchar2, 200);
      oracleParameter2.Value = (object) model.Address;
      oracleParameterArray[index2] = oracleParameter2;
      int index3 = 2;
      OracleParameter oracleParameter3 = new OracleParameter(":Type", OracleDbType.Varchar2, 40);
      oracleParameter3.Value = (object) model.Type;
      oracleParameterArray[index3] = oracleParameter3;
      int index4 = 3;
      OracleParameter oracleParameter4 = new OracleParameter(":OpenMode", OracleDbType.Int32);
      oracleParameter4.Value = (object) model.OpenMode;
      oracleParameterArray[index4] = oracleParameter4;
      int index5 = 4;
      OracleParameter oracleParameter5;
      if (model.Width.HasValue)
      {
        OracleParameter oracleParameter6 = new OracleParameter(":Width", OracleDbType.Int32);
        oracleParameter6.Value = (object) model.Width;
        oracleParameter5 = oracleParameter6;
      }
      else
      {
        oracleParameter5 = new OracleParameter(":Width", OracleDbType.Int32);
        oracleParameter5.Value = (object) DBNull.Value;
      }
      oracleParameterArray[index5] = oracleParameter5;
      int index6 = 5;
      OracleParameter oracleParameter7;
      if (model.Height.HasValue)
      {
        OracleParameter oracleParameter6 = new OracleParameter(":Height", OracleDbType.Int32);
        oracleParameter6.Value = (object) model.Height;
        oracleParameter7 = oracleParameter6;
      }
      else
      {
        oracleParameter7 = new OracleParameter(":Height", OracleDbType.Int32);
        oracleParameter7.Value = (object) DBNull.Value;
      }
      oracleParameterArray[index6] = oracleParameter7;
      int index7 = 6;
      OracleParameter oracleParameter8;
      if (model.Params != null)
      {
        OracleParameter oracleParameter6 = new OracleParameter(":Params", OracleDbType.Clob);
        oracleParameter6.Value = (object) model.Params;
        oracleParameter8 = oracleParameter6;
      }
      else
      {
        oracleParameter8 = new OracleParameter(":Params", OracleDbType.Clob);
        oracleParameter8.Value = (object) DBNull.Value;
      }
      oracleParameterArray[index7] = oracleParameter8;
      int index8 = 7;
      OracleParameter oracleParameter9;
      if (model.Manager != null)
      {
        OracleParameter oracleParameter6 = new OracleParameter(":Manager", OracleDbType.Clob);
        oracleParameter6.Value = (object) model.Manager;
        oracleParameter9 = oracleParameter6;
      }
      else
      {
        oracleParameter9 = new OracleParameter(":Manager", OracleDbType.Clob);
        oracleParameter9.Value = (object) DBNull.Value;
      }
      oracleParameterArray[index8] = oracleParameter9;
      int index9 = 8;
      OracleParameter oracleParameter10;
      if (model.Note != null)
      {
        OracleParameter oracleParameter6 = new OracleParameter(":Note", OracleDbType.Clob);
        oracleParameter6.Value = (object) model.Note;
        oracleParameter10 = oracleParameter6;
      }
      else
      {
        oracleParameter10 = new OracleParameter(":Note", OracleDbType.Clob);
        oracleParameter10.Value = (object) DBNull.Value;
      }
      oracleParameterArray[index9] = oracleParameter10;
      int index10 = 9;
      OracleParameter oracleParameter11;
      if (model.Code != null)
      {
        OracleParameter oracleParameter6 = new OracleParameter(":Code", OracleDbType.Varchar2, 50);
        oracleParameter6.Value = (object) model.Code;
        oracleParameter11 = oracleParameter6;
      }
      else
      {
        oracleParameter11 = new OracleParameter(":Code", OracleDbType.Varchar2, 50);
        oracleParameter11.Value = (object) DBNull.Value;
      }
      oracleParameterArray[index10] = oracleParameter11;
      int index11 = 10;
      OracleParameter oracleParameter12;
      if (model.Ico != null)
      {
        OracleParameter oracleParameter6 = new OracleParameter(":Ico", OracleDbType.Varchar2);
        oracleParameter6.Value = (object) model.Ico;
        oracleParameter12 = oracleParameter6;
      }
      else
      {
        oracleParameter12 = new OracleParameter(":Ico", OracleDbType.Varchar2);
        oracleParameter12.Value = (object) DBNull.Value;
      }
      oracleParameterArray[index11] = oracleParameter12;
      int index12 = 11;
      OracleParameter oracleParameter13;
      if (model.Color != null)
      {
        OracleParameter oracleParameter6 = new OracleParameter(":Color", OracleDbType.Varchar2);
        oracleParameter6.Value = (object) model.Color;
        oracleParameter13 = oracleParameter6;
      }
      else
      {
        oracleParameter13 = new OracleParameter(":Color", OracleDbType.Varchar2);
        oracleParameter13.Value = (object) DBNull.Value;
      }
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
      string sql = "DELETE FROM AppLibrary WHERE ID=:ID";
      OracleParameter[] oracleParameterArray = new OracleParameter[1];
      int index = 0;
      OracleParameter oracleParameter = new OracleParameter(":ID", OracleDbType.Varchar2);
      oracleParameter.Value = (object) id;
      oracleParameterArray[index] = oracleParameter;
      OracleParameter[] parameter = oracleParameterArray;
      return this.dbHelper.Execute(sql, parameter);
    }

    private List<RoadFlow.Data.Model.AppLibrary> DataReaderToList(OracleDataReader dataReader)
    {
      List<RoadFlow.Data.Model.AppLibrary> appLibraryList = new List<RoadFlow.Data.Model.AppLibrary>();
      while (dataReader.Read())
      {
        RoadFlow.Data.Model.AppLibrary appLibrary = new RoadFlow.Data.Model.AppLibrary();
        appLibrary.ID = dataReader.GetString(0).ToGuid();
        appLibrary.Title = dataReader.GetString(1);
        appLibrary.Address = dataReader.GetString(2);
        appLibrary.Type = dataReader.GetString(3).ToGuid();
        appLibrary.OpenMode = dataReader.GetInt32(4);
        if (!dataReader.IsDBNull(5))
          appLibrary.Width = new int?(dataReader.GetInt32(5));
        if (!dataReader.IsDBNull(6))
          appLibrary.Height = new int?(dataReader.GetInt32(6));
        if (!dataReader.IsDBNull(7))
          appLibrary.Params = dataReader.GetString(7);
        if (!dataReader.IsDBNull(8))
          appLibrary.Manager = dataReader.GetString(8);
        if (!dataReader.IsDBNull(9))
          appLibrary.Note = dataReader.GetString(9);
        if (!dataReader.IsDBNull(10))
          appLibrary.Code = dataReader.GetString(10);
        if (!dataReader.IsDBNull(11))
          appLibrary.Ico = dataReader.GetString(11);
        if (!dataReader.IsDBNull(12))
          appLibrary.Color = dataReader.GetString(12);
        appLibraryList.Add(appLibrary);
      }
      return appLibraryList;
    }

    public List<RoadFlow.Data.Model.AppLibrary> GetAll()
    {
      OracleDataReader dataReader = this.dbHelper.GetDataReader("SELECT * FROM AppLibrary");
      List<RoadFlow.Data.Model.AppLibrary> list = this.DataReaderToList(dataReader);
      dataReader.Close();
      return list;
    }

    public long GetCount()
    {
      long result;
      if (!long.TryParse(this.dbHelper.GetFieldValue("SELECT COUNT(*) FROM AppLibrary"), out result))
        return 0;
      return result;
    }

    public RoadFlow.Data.Model.AppLibrary Get(Guid id)
    {
      string sql = "SELECT * FROM AppLibrary WHERE ID=:ID";
      OracleParameter[] oracleParameterArray = new OracleParameter[1];
      int index = 0;
      OracleParameter oracleParameter = new OracleParameter(":ID", OracleDbType.Varchar2);
      oracleParameter.Value = (object) id;
      oracleParameterArray[index] = oracleParameter;
      OracleParameter[] parameter = oracleParameterArray;
      OracleDataReader dataReader = this.dbHelper.GetDataReader(sql, parameter);
      List<RoadFlow.Data.Model.AppLibrary> list = this.DataReaderToList(dataReader);
      dataReader.Close();
      if (list.Count <= 0)
        return (RoadFlow.Data.Model.AppLibrary) null;
      return list[0];
    }

    public List<RoadFlow.Data.Model.AppLibrary> GetPagerData(out string pager, string query = "", string order = "Type,Title", int size = 15, int number = 1, string title = "", string type = "", string address = "")
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
        stringBuilder.AppendFormat("AND Type IN({0}) ", (object) Tools.GetSqlInString(type, true, ","));
      if (!address.IsNullOrEmpty())
      {
        stringBuilder.Append("AND INSTR(Address,:Address,1,1)>0 ");
        List<OracleParameter> oracleParameterList2 = oracleParameterList1;
        OracleParameter oracleParameter = new OracleParameter(":Address", OracleDbType.Varchar2);
        oracleParameter.Value = (object) address;
        oracleParameterList2.Add(oracleParameter);
      }
      long count;
      string paerSql = this.dbHelper.GetPaerSql(nameof (AppLibrary), "*", stringBuilder.ToString(), order, size, number, out count, oracleParameterList1.ToArray());
      pager = Tools.GetPagerHtml(count, size, number, query);
      OracleDataReader dataReader = this.dbHelper.GetDataReader(paerSql, oracleParameterList1.ToArray());
      List<RoadFlow.Data.Model.AppLibrary> list = this.DataReaderToList(dataReader);
      dataReader.Close();
      return list;
    }

    public List<RoadFlow.Data.Model.AppLibrary> GetPagerData(out long count, int size = 15, int number = 1, string title = "", string type = "", string address = "", string order = "")
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
        stringBuilder.AppendFormat("AND Type IN({0}) ", (object) Tools.GetSqlInString(type, true, ","));
      if (!address.IsNullOrEmpty())
      {
        stringBuilder.Append("AND INSTR(Address,:Address,1,1)>0 ");
        List<OracleParameter> oracleParameterList2 = oracleParameterList1;
        OracleParameter oracleParameter = new OracleParameter(":Address", OracleDbType.Varchar2);
        oracleParameter.Value = (object) address;
        oracleParameterList2.Add(oracleParameter);
      }
      OracleDataReader dataReader = this.dbHelper.GetDataReader(this.dbHelper.GetPaerSql(nameof (AppLibrary), "*", stringBuilder.ToString(), order.IsNullOrEmpty() ? "Type,Title" : order, size, number, out count, oracleParameterList1.ToArray()), oracleParameterList1.ToArray());
      List<RoadFlow.Data.Model.AppLibrary> list = this.DataReaderToList(dataReader);
      dataReader.Close();
      return list;
    }

    public List<RoadFlow.Data.Model.AppLibrary> GetAllByType(string types)
    {
      OracleDataReader dataReader = this.dbHelper.GetDataReader("SELECT * FROM AppLibrary WHERE Type IN(" + Tools.GetSqlInString(types, true, ",") + ")");
      List<RoadFlow.Data.Model.AppLibrary> list = this.DataReaderToList(dataReader);
      dataReader.Close();
      return list;
    }

    public int Delete(string[] idArray)
    {
      return this.dbHelper.Execute("DELETE FROM AppLibrary WHERE ID IN(" + Tools.GetSqlInString<string>(idArray, true) + ")");
    }

    public RoadFlow.Data.Model.AppLibrary GetByCode(string code)
    {
      string sql = "SELECT * FROM AppLibrary WHERE Code=:Code";
      OracleParameter[] oracleParameterArray = new OracleParameter[1];
      int index = 0;
      OracleParameter oracleParameter = new OracleParameter(":Code", OracleDbType.Varchar2, 50);
      oracleParameter.Value = (object) code;
      oracleParameterArray[index] = oracleParameter;
      OracleParameter[] parameter = oracleParameterArray;
      OracleDataReader dataReader = this.dbHelper.GetDataReader(sql, parameter);
      List<RoadFlow.Data.Model.AppLibrary> list = this.DataReaderToList(dataReader);
      dataReader.Close();
      if (list.Count <= 0)
        return (RoadFlow.Data.Model.AppLibrary) null;
      return list[0];
    }
  }
}
