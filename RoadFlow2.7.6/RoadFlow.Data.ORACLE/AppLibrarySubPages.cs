// Decompiled with JetBrains decompiler
// Type: RoadFlow.Data.ORACLE.AppLibrarySubPages
// Assembly: RoadFlow.Data.ORACLE, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: C9018AA1-E48E-4231-92A9-CD6F0F275D11
// Assembly location: C:\inetpub\wwwroot\RoadFlowMvc\bin\RoadFlow.Data.ORACLE.dll

using Oracle.ManagedDataAccess.Client;
using RoadFlow.Data.Interface;
using System;
using System.Collections.Generic;

namespace RoadFlow.Data.ORACLE
{
  public class AppLibrarySubPages : IAppLibrarySubPages
  {
    private DBHelper dbHelper = new DBHelper();

    public int Add(RoadFlow.Data.Model.AppLibrarySubPages model)
    {
      string sql = "INSERT INTO AppLibrarySubPages\r\n\t\t\t\t(ID,AppLibraryID,Name,Address,Ico,Sort,Note) \r\n\t\t\t\tVALUES(:ID,:AppLibraryID,:Name,:Address,:Ico,:Sort,:Note)";
      OracleParameter[] oracleParameterArray = new OracleParameter[7];
      int index1 = 0;
      OracleParameter oracleParameter1 = new OracleParameter(":ID", OracleDbType.Varchar2);
      oracleParameter1.Value = (object) model.ID;
      oracleParameterArray[index1] = oracleParameter1;
      int index2 = 1;
      OracleParameter oracleParameter2 = new OracleParameter(":AppLibraryID", OracleDbType.Varchar2);
      oracleParameter2.Value = (object) model.AppLibraryID;
      oracleParameterArray[index2] = oracleParameter2;
      int index3 = 2;
      OracleParameter oracleParameter3 = new OracleParameter(":Name", OracleDbType.Varchar2);
      oracleParameter3.Value = (object) model.Name;
      oracleParameterArray[index3] = oracleParameter3;
      int index4 = 3;
      OracleParameter oracleParameter4 = new OracleParameter(":Address", OracleDbType.Varchar2);
      oracleParameter4.Value = (object) model.Address;
      oracleParameterArray[index4] = oracleParameter4;
      int index5 = 4;
      OracleParameter oracleParameter5;
      if (model.Ico != null)
      {
        OracleParameter oracleParameter6 = new OracleParameter(":Ico", OracleDbType.Varchar2);
        oracleParameter6.Value = (object) model.Ico;
        oracleParameter5 = oracleParameter6;
      }
      else
      {
        oracleParameter5 = new OracleParameter(":Ico", OracleDbType.Varchar2);
        oracleParameter5.Value = (object) DBNull.Value;
      }
      oracleParameterArray[index5] = oracleParameter5;
      int index6 = 5;
      OracleParameter oracleParameter7 = new OracleParameter(":Sort", OracleDbType.Int32);
      oracleParameter7.Value = (object) model.Sort;
      oracleParameterArray[index6] = oracleParameter7;
      int index7 = 6;
      OracleParameter oracleParameter8;
      if (model.Note != null)
      {
        OracleParameter oracleParameter6 = new OracleParameter(":Note", OracleDbType.Varchar2);
        oracleParameter6.Value = (object) model.Note;
        oracleParameter8 = oracleParameter6;
      }
      else
      {
        oracleParameter8 = new OracleParameter(":Note", OracleDbType.Varchar2);
        oracleParameter8.Value = (object) DBNull.Value;
      }
      oracleParameterArray[index7] = oracleParameter8;
      OracleParameter[] parameter = oracleParameterArray;
      return this.dbHelper.Execute(sql, parameter);
    }

    public int Update(RoadFlow.Data.Model.AppLibrarySubPages model)
    {
      string sql = "UPDATE AppLibrarySubPages SET \r\n\t\t\t\tAppLibraryID=:AppLibraryID,Name=:Name,Address=:Address,Ico=:Ico,Sort=:Sort,Note=:Note\r\n\t\t\t\tWHERE ID=:ID";
      OracleParameter[] oracleParameterArray = new OracleParameter[7];
      int index1 = 0;
      OracleParameter oracleParameter1 = new OracleParameter(":AppLibraryID", OracleDbType.Varchar2);
      oracleParameter1.Value = (object) model.AppLibraryID;
      oracleParameterArray[index1] = oracleParameter1;
      int index2 = 1;
      OracleParameter oracleParameter2 = new OracleParameter(":Name", OracleDbType.Varchar2);
      oracleParameter2.Value = (object) model.Name;
      oracleParameterArray[index2] = oracleParameter2;
      int index3 = 2;
      OracleParameter oracleParameter3 = new OracleParameter(":Address", OracleDbType.Varchar2);
      oracleParameter3.Value = (object) model.Address;
      oracleParameterArray[index3] = oracleParameter3;
      int index4 = 3;
      OracleParameter oracleParameter4;
      if (model.Ico != null)
      {
        OracleParameter oracleParameter5 = new OracleParameter(":Ico", OracleDbType.Varchar2);
        oracleParameter5.Value = (object) model.Ico;
        oracleParameter4 = oracleParameter5;
      }
      else
      {
        oracleParameter4 = new OracleParameter(":Ico", OracleDbType.Varchar2);
        oracleParameter4.Value = (object) DBNull.Value;
      }
      oracleParameterArray[index4] = oracleParameter4;
      int index5 = 4;
      OracleParameter oracleParameter6 = new OracleParameter(":Sort", OracleDbType.Int32);
      oracleParameter6.Value = (object) model.Sort;
      oracleParameterArray[index5] = oracleParameter6;
      int index6 = 5;
      OracleParameter oracleParameter7;
      if (model.Note != null)
      {
        OracleParameter oracleParameter5 = new OracleParameter(":Note", OracleDbType.Varchar2);
        oracleParameter5.Value = (object) model.Note;
        oracleParameter7 = oracleParameter5;
      }
      else
      {
        oracleParameter7 = new OracleParameter(":Note", OracleDbType.Varchar2);
        oracleParameter7.Value = (object) DBNull.Value;
      }
      oracleParameterArray[index6] = oracleParameter7;
      int index7 = 6;
      OracleParameter oracleParameter8 = new OracleParameter(":ID", OracleDbType.Varchar2);
      oracleParameter8.Value = (object) model.ID;
      oracleParameterArray[index7] = oracleParameter8;
      OracleParameter[] parameter = oracleParameterArray;
      return this.dbHelper.Execute(sql, parameter);
    }

    public int Delete(Guid id)
    {
      string sql = "DELETE FROM AppLibrarySubPages WHERE ID=:ID";
      OracleParameter[] oracleParameterArray = new OracleParameter[1];
      int index = 0;
      OracleParameter oracleParameter = new OracleParameter(":ID", OracleDbType.Varchar2);
      oracleParameter.Value = (object) id;
      oracleParameterArray[index] = oracleParameter;
      OracleParameter[] parameter = oracleParameterArray;
      return this.dbHelper.Execute(sql, parameter);
    }

    private List<RoadFlow.Data.Model.AppLibrarySubPages> DataReaderToList(OracleDataReader dataReader)
    {
      List<RoadFlow.Data.Model.AppLibrarySubPages> appLibrarySubPagesList = new List<RoadFlow.Data.Model.AppLibrarySubPages>();
      while (dataReader.Read())
      {
        RoadFlow.Data.Model.AppLibrarySubPages appLibrarySubPages = new RoadFlow.Data.Model.AppLibrarySubPages();
        appLibrarySubPages.ID = dataReader.GetString(0).ToGuid();
        appLibrarySubPages.AppLibraryID = dataReader.GetString(1).ToGuid();
        appLibrarySubPages.Name = dataReader.GetString(2);
        appLibrarySubPages.Address = dataReader.GetString(3);
        if (!dataReader.IsDBNull(4))
          appLibrarySubPages.Ico = dataReader.GetString(4);
        appLibrarySubPages.Sort = dataReader.GetInt32(5);
        if (!dataReader.IsDBNull(6))
          appLibrarySubPages.Note = dataReader.GetString(6);
        appLibrarySubPagesList.Add(appLibrarySubPages);
      }
      return appLibrarySubPagesList;
    }

    public List<RoadFlow.Data.Model.AppLibrarySubPages> GetAll()
    {
      OracleDataReader dataReader = this.dbHelper.GetDataReader("SELECT * FROM AppLibrarySubPages");
      List<RoadFlow.Data.Model.AppLibrarySubPages> list = this.DataReaderToList(dataReader);
      dataReader.Close();
      return list;
    }

    public long GetCount()
    {
      long result;
      if (!long.TryParse(this.dbHelper.GetFieldValue("SELECT COUNT(*) FROM AppLibrarySubPages"), out result))
        return 0;
      return result;
    }

    public RoadFlow.Data.Model.AppLibrarySubPages Get(Guid id)
    {
      string sql = "SELECT * FROM AppLibrarySubPages WHERE ID=:ID";
      OracleParameter[] oracleParameterArray = new OracleParameter[1];
      int index = 0;
      OracleParameter oracleParameter = new OracleParameter(":ID", OracleDbType.Varchar2);
      oracleParameter.Value = (object) id;
      oracleParameterArray[index] = oracleParameter;
      OracleParameter[] parameter = oracleParameterArray;
      OracleDataReader dataReader = this.dbHelper.GetDataReader(sql, parameter);
      List<RoadFlow.Data.Model.AppLibrarySubPages> list = this.DataReaderToList(dataReader);
      dataReader.Close();
      if (list.Count <= 0)
        return (RoadFlow.Data.Model.AppLibrarySubPages) null;
      return list[0];
    }

    public int DeleteByAppID(Guid id)
    {
      string sql = "DELETE FROM AppLibrarySubPages WHERE AppLibraryID=:ID";
      OracleParameter[] oracleParameterArray = new OracleParameter[1];
      int index = 0;
      OracleParameter oracleParameter = new OracleParameter(":ID", OracleDbType.Varchar2);
      oracleParameter.Value = (object) id;
      oracleParameterArray[index] = oracleParameter;
      OracleParameter[] parameter = oracleParameterArray;
      return this.dbHelper.Execute(sql, parameter);
    }

    public List<RoadFlow.Data.Model.AppLibrarySubPages> GetAllByAppID(Guid id)
    {
      string sql = "SELECT * FROM AppLibrarySubPages WHERE AppLibraryID=:ID";
      OracleParameter[] oracleParameterArray = new OracleParameter[1];
      int index = 0;
      OracleParameter oracleParameter = new OracleParameter(":ID", OracleDbType.Varchar2);
      oracleParameter.Value = (object) id;
      oracleParameterArray[index] = oracleParameter;
      OracleParameter[] parameter = oracleParameterArray;
      OracleDataReader dataReader = this.dbHelper.GetDataReader(sql, parameter);
      List<RoadFlow.Data.Model.AppLibrarySubPages> list = this.DataReaderToList(dataReader);
      dataReader.Close();
      return list;
    }
  }
}
