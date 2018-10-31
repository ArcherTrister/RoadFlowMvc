// Decompiled with JetBrains decompiler
// Type: RoadFlow.Data.ORACLE.AppLibraryButtons1
// Assembly: RoadFlow.Data.ORACLE, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: C9018AA1-E48E-4231-92A9-CD6F0F275D11
// Assembly location: C:\inetpub\wwwroot\RoadFlowMvc\bin\RoadFlow.Data.ORACLE.dll

using Oracle.ManagedDataAccess.Client;
using RoadFlow.Data.Interface;
using System;
using System.Collections.Generic;

namespace RoadFlow.Data.ORACLE
{
  public class AppLibraryButtons1 : IAppLibraryButtons1
  {
    private DBHelper dbHelper = new DBHelper();

    public int Add(RoadFlow.Data.Model.AppLibraryButtons1 model)
    {
      string sql = "INSERT INTO AppLibraryButtons1\r\n\t\t\t\t(ID,AppLibraryID,ButtonID,Name,Events,Ico,Sort,Type,ShowType,IsValidateShow) \r\n\t\t\t\tVALUES(:ID,:AppLibraryID,:ButtonID,:Name,:Events,:Ico,:Sort,:Type,:ShowType,:IsValidateShow)";
      OracleParameter[] oracleParameterArray = new OracleParameter[10];
      int index1 = 0;
      OracleParameter oracleParameter1 = new OracleParameter(":ID", OracleDbType.Varchar2);
      oracleParameter1.Value = (object) model.ID;
      oracleParameterArray[index1] = oracleParameter1;
      int index2 = 1;
      OracleParameter oracleParameter2 = new OracleParameter(":AppLibraryID", OracleDbType.Varchar2);
      oracleParameter2.Value = (object) model.AppLibraryID;
      oracleParameterArray[index2] = oracleParameter2;
      int index3 = 2;
      OracleParameter oracleParameter3;
      if (model.ButtonID.HasValue)
      {
        OracleParameter oracleParameter4 = new OracleParameter(":ButtonID", OracleDbType.Varchar2);
        oracleParameter4.Value = (object) model.ButtonID;
        oracleParameter3 = oracleParameter4;
      }
      else
      {
        oracleParameter3 = new OracleParameter(":ButtonID", OracleDbType.Varchar2);
        oracleParameter3.Value = (object) DBNull.Value;
      }
      oracleParameterArray[index3] = oracleParameter3;
      int index4 = 3;
      OracleParameter oracleParameter5 = new OracleParameter(":Name", OracleDbType.Varchar2);
      oracleParameter5.Value = (object) model.Name;
      oracleParameterArray[index4] = oracleParameter5;
      int index5 = 4;
      OracleParameter oracleParameter6 = new OracleParameter(":Events", OracleDbType.Varchar2);
      oracleParameter6.Value = (object) model.Events;
      oracleParameterArray[index5] = oracleParameter6;
      int index6 = 5;
      OracleParameter oracleParameter7 = new OracleParameter(":Ico", OracleDbType.Varchar2);
      oracleParameter7.Value = (object) model.Ico;
      oracleParameterArray[index6] = oracleParameter7;
      int index7 = 6;
      OracleParameter oracleParameter8 = new OracleParameter(":Sort", OracleDbType.Int32);
      oracleParameter8.Value = (object) model.Sort;
      oracleParameterArray[index7] = oracleParameter8;
      int index8 = 7;
      OracleParameter oracleParameter9 = new OracleParameter(":Type", OracleDbType.Int32);
      oracleParameter9.Value = (object) model.Type;
      oracleParameterArray[index8] = oracleParameter9;
      int index9 = 8;
      OracleParameter oracleParameter10 = new OracleParameter(":ShowType", OracleDbType.Int32);
      oracleParameter10.Value = (object) model.ShowType;
      oracleParameterArray[index9] = oracleParameter10;
      int index10 = 9;
      OracleParameter oracleParameter11 = new OracleParameter(":IsValidateShow", OracleDbType.Int32);
      oracleParameter11.Value = (object) model.IsValidateShow;
      oracleParameterArray[index10] = oracleParameter11;
      OracleParameter[] parameter = oracleParameterArray;
      return this.dbHelper.Execute(sql, parameter);
    }

    public int Update(RoadFlow.Data.Model.AppLibraryButtons1 model)
    {
      string sql = "UPDATE AppLibraryButtons1 SET \r\n\t\t\t\tAppLibraryID=:AppLibraryID,ButtonID=:ButtonID,Name=:Name,Events=:Events,Ico=:Ico,Sort=:Sort,Type=:Type,ShowType=:ShowType,IsValidateShow=:IsValidateShow\r\n\t\t\t\tWHERE ID=:ID";
      OracleParameter[] oracleParameterArray = new OracleParameter[10];
      int index1 = 0;
      OracleParameter oracleParameter1 = new OracleParameter(":AppLibraryID", OracleDbType.Varchar2);
      oracleParameter1.Value = (object) model.AppLibraryID;
      oracleParameterArray[index1] = oracleParameter1;
      int index2 = 1;
      OracleParameter oracleParameter2;
      if (model.ButtonID.HasValue)
      {
        OracleParameter oracleParameter3 = new OracleParameter(":ButtonID", OracleDbType.Varchar2);
        oracleParameter3.Value = (object) model.ButtonID;
        oracleParameter2 = oracleParameter3;
      }
      else
      {
        oracleParameter2 = new OracleParameter(":ButtonID", OracleDbType.Varchar2);
        oracleParameter2.Value = (object) DBNull.Value;
      }
      oracleParameterArray[index2] = oracleParameter2;
      int index3 = 2;
      OracleParameter oracleParameter4 = new OracleParameter(":Name", OracleDbType.Varchar2);
      oracleParameter4.Value = (object) model.Name;
      oracleParameterArray[index3] = oracleParameter4;
      int index4 = 3;
      OracleParameter oracleParameter5 = new OracleParameter(":Events", OracleDbType.Varchar2);
      oracleParameter5.Value = (object) model.Events;
      oracleParameterArray[index4] = oracleParameter5;
      int index5 = 4;
      OracleParameter oracleParameter6 = new OracleParameter(":Ico", OracleDbType.Varchar2);
      oracleParameter6.Value = (object) model.Ico;
      oracleParameterArray[index5] = oracleParameter6;
      int index6 = 5;
      OracleParameter oracleParameter7 = new OracleParameter(":Sort", OracleDbType.Int32);
      oracleParameter7.Value = (object) model.Sort;
      oracleParameterArray[index6] = oracleParameter7;
      int index7 = 6;
      OracleParameter oracleParameter8 = new OracleParameter(":Type", OracleDbType.Int32);
      oracleParameter8.Value = (object) model.Type;
      oracleParameterArray[index7] = oracleParameter8;
      int index8 = 7;
      OracleParameter oracleParameter9 = new OracleParameter(":ShowType", OracleDbType.Int32);
      oracleParameter9.Value = (object) model.ShowType;
      oracleParameterArray[index8] = oracleParameter9;
      int index9 = 8;
      OracleParameter oracleParameter10 = new OracleParameter(":IsValidateShow", OracleDbType.Int32);
      oracleParameter10.Value = (object) model.IsValidateShow;
      oracleParameterArray[index9] = oracleParameter10;
      int index10 = 9;
      OracleParameter oracleParameter11 = new OracleParameter(":ID", OracleDbType.Varchar2);
      oracleParameter11.Value = (object) model.ID;
      oracleParameterArray[index10] = oracleParameter11;
      OracleParameter[] parameter = oracleParameterArray;
      return this.dbHelper.Execute(sql, parameter);
    }

    public int Delete(Guid id)
    {
      string sql = "DELETE FROM AppLibraryButtons1 WHERE ID=:ID";
      OracleParameter[] oracleParameterArray = new OracleParameter[1];
      int index = 0;
      OracleParameter oracleParameter = new OracleParameter(":ID", OracleDbType.Varchar2);
      oracleParameter.Value = (object) id;
      oracleParameterArray[index] = oracleParameter;
      OracleParameter[] parameter = oracleParameterArray;
      return this.dbHelper.Execute(sql, parameter);
    }

    private List<RoadFlow.Data.Model.AppLibraryButtons1> DataReaderToList(OracleDataReader dataReader)
    {
      List<RoadFlow.Data.Model.AppLibraryButtons1> appLibraryButtons1List = new List<RoadFlow.Data.Model.AppLibraryButtons1>();
      while (dataReader.Read())
      {
        RoadFlow.Data.Model.AppLibraryButtons1 appLibraryButtons1 = new RoadFlow.Data.Model.AppLibraryButtons1();
        appLibraryButtons1.ID = dataReader.GetString(0).ToGuid();
        appLibraryButtons1.AppLibraryID = dataReader.GetString(1).ToGuid();
        if (!dataReader.IsDBNull(2))
          appLibraryButtons1.ButtonID = new Guid?(dataReader.GetString(2).ToGuid());
        appLibraryButtons1.Name = dataReader.GetString(3);
        appLibraryButtons1.Events = dataReader.GetString(4);
        if (!dataReader.IsDBNull(5))
          appLibraryButtons1.Ico = dataReader.GetString(5);
        appLibraryButtons1.Sort = dataReader.GetInt32(6);
        appLibraryButtons1.Type = dataReader.GetInt32(7);
        appLibraryButtons1.ShowType = dataReader.GetInt32(8);
        appLibraryButtons1.IsValidateShow = dataReader.GetInt32(9);
        appLibraryButtons1List.Add(appLibraryButtons1);
      }
      return appLibraryButtons1List;
    }

    public List<RoadFlow.Data.Model.AppLibraryButtons1> GetAll()
    {
      OracleDataReader dataReader = this.dbHelper.GetDataReader("SELECT * FROM AppLibraryButtons1");
      List<RoadFlow.Data.Model.AppLibraryButtons1> list = this.DataReaderToList(dataReader);
      dataReader.Close();
      return list;
    }

    public long GetCount()
    {
      long result;
      if (!long.TryParse(this.dbHelper.GetFieldValue("SELECT COUNT(*) FROM AppLibraryButtons1"), out result))
        return 0;
      return result;
    }

    public RoadFlow.Data.Model.AppLibraryButtons1 Get(Guid id)
    {
      string sql = "SELECT * FROM AppLibraryButtons1 WHERE ID=:ID";
      OracleParameter[] oracleParameterArray = new OracleParameter[1];
      int index = 0;
      OracleParameter oracleParameter = new OracleParameter(":ID", OracleDbType.Varchar2);
      oracleParameter.Value = (object) id;
      oracleParameterArray[index] = oracleParameter;
      OracleParameter[] parameter = oracleParameterArray;
      OracleDataReader dataReader = this.dbHelper.GetDataReader(sql, parameter);
      List<RoadFlow.Data.Model.AppLibraryButtons1> list = this.DataReaderToList(dataReader);
      dataReader.Close();
      if (list.Count <= 0)
        return (RoadFlow.Data.Model.AppLibraryButtons1) null;
      return list[0];
    }

    public int DeleteByAppID(Guid id)
    {
      string sql = "DELETE FROM AppLibraryButtons1 WHERE AppLibraryID=:ID";
      OracleParameter[] oracleParameterArray = new OracleParameter[1];
      int index = 0;
      OracleParameter oracleParameter = new OracleParameter(":ID", OracleDbType.Varchar2);
      oracleParameter.Value = (object) id;
      oracleParameterArray[index] = oracleParameter;
      OracleParameter[] parameter = oracleParameterArray;
      return this.dbHelper.Execute(sql, parameter);
    }

    public List<RoadFlow.Data.Model.AppLibraryButtons1> GetAllByAppID(Guid id)
    {
      string sql = "SELECT * FROM AppLibraryButtons1 WHERE AppLibraryID=:ID";
      OracleParameter[] oracleParameterArray = new OracleParameter[1];
      int index = 0;
      OracleParameter oracleParameter = new OracleParameter(":ID", OracleDbType.Varchar2);
      oracleParameter.Value = (object) id;
      oracleParameterArray[index] = oracleParameter;
      OracleParameter[] parameter = oracleParameterArray;
      OracleDataReader dataReader = this.dbHelper.GetDataReader(sql, parameter);
      List<RoadFlow.Data.Model.AppLibraryButtons1> list = this.DataReaderToList(dataReader);
      dataReader.Close();
      return list;
    }
  }
}
