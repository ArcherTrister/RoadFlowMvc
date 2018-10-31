// Decompiled with JetBrains decompiler
// Type: RoadFlow.Data.ORACLE.AppLibraryButtons
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
  public class AppLibraryButtons : IAppLibraryButtons
  {
    private DBHelper dbHelper = new DBHelper();

    public int Add(RoadFlow.Data.Model.AppLibraryButtons model)
    {
      string sql = "INSERT INTO AppLibraryButtons\r\n\t\t\t\t(ID,Name,Events,Ico,Sort,Note) \r\n\t\t\t\tVALUES(:ID,:Name,:Events,:Ico,:Sort,:Note)";
      OracleParameter[] oracleParameterArray = new OracleParameter[6];
      int index1 = 0;
      OracleParameter oracleParameter1 = new OracleParameter(":ID", OracleDbType.Varchar2);
      oracleParameter1.Value = (object) model.ID;
      oracleParameterArray[index1] = oracleParameter1;
      int index2 = 1;
      OracleParameter oracleParameter2 = new OracleParameter(":Name", OracleDbType.Varchar2);
      oracleParameter2.Value = (object) model.Name;
      oracleParameterArray[index2] = oracleParameter2;
      int index3 = 2;
      OracleParameter oracleParameter3 = new OracleParameter(":Events", OracleDbType.Varchar2);
      oracleParameter3.Value = (object) model.Events;
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
      OracleParameter[] parameter = oracleParameterArray;
      return this.dbHelper.Execute(sql, parameter);
    }

    public int Update(RoadFlow.Data.Model.AppLibraryButtons model)
    {
      string sql = "UPDATE AppLibraryButtons SET \r\n\t\t\t\tName=:Name,Events=:Events,Ico=:Ico,Sort=:Sort,Note=:Note\r\n\t\t\t\tWHERE ID=:ID";
      OracleParameter[] oracleParameterArray = new OracleParameter[6];
      int index1 = 0;
      OracleParameter oracleParameter1 = new OracleParameter(":Name", OracleDbType.Varchar2);
      oracleParameter1.Value = (object) model.Name;
      oracleParameterArray[index1] = oracleParameter1;
      int index2 = 1;
      OracleParameter oracleParameter2 = new OracleParameter(":Events", OracleDbType.Varchar2);
      oracleParameter2.Value = (object) model.Events;
      oracleParameterArray[index2] = oracleParameter2;
      int index3 = 2;
      OracleParameter oracleParameter3;
      if (model.Ico != null)
      {
        OracleParameter oracleParameter4 = new OracleParameter(":Ico", OracleDbType.Varchar2);
        oracleParameter4.Value = (object) model.Ico;
        oracleParameter3 = oracleParameter4;
      }
      else
      {
        oracleParameter3 = new OracleParameter(":Ico", OracleDbType.Varchar2);
        oracleParameter3.Value = (object) DBNull.Value;
      }
      oracleParameterArray[index3] = oracleParameter3;
      int index4 = 3;
      OracleParameter oracleParameter5 = new OracleParameter(":Sort", OracleDbType.Int32);
      oracleParameter5.Value = (object) model.Sort;
      oracleParameterArray[index4] = oracleParameter5;
      int index5 = 4;
      OracleParameter oracleParameter6;
      if (model.Note != null)
      {
        OracleParameter oracleParameter4 = new OracleParameter(":Note", OracleDbType.Varchar2);
        oracleParameter4.Value = (object) model.Note;
        oracleParameter6 = oracleParameter4;
      }
      else
      {
        oracleParameter6 = new OracleParameter(":Note", OracleDbType.Varchar2);
        oracleParameter6.Value = (object) DBNull.Value;
      }
      oracleParameterArray[index5] = oracleParameter6;
      int index6 = 5;
      OracleParameter oracleParameter7 = new OracleParameter(":ID", OracleDbType.Varchar2);
      oracleParameter7.Value = (object) model.ID;
      oracleParameterArray[index6] = oracleParameter7;
      OracleParameter[] parameter = oracleParameterArray;
      return this.dbHelper.Execute(sql, parameter);
    }

    public int Delete(Guid id)
    {
      string sql = "DELETE FROM AppLibraryButtons WHERE ID=:ID";
      OracleParameter[] oracleParameterArray = new OracleParameter[1];
      int index = 0;
      OracleParameter oracleParameter = new OracleParameter(":ID", OracleDbType.Varchar2);
      oracleParameter.Value = (object) id;
      oracleParameterArray[index] = oracleParameter;
      OracleParameter[] parameter = oracleParameterArray;
      return this.dbHelper.Execute(sql, parameter);
    }

    private List<RoadFlow.Data.Model.AppLibraryButtons> DataReaderToList(OracleDataReader dataReader)
    {
      List<RoadFlow.Data.Model.AppLibraryButtons> appLibraryButtonsList = new List<RoadFlow.Data.Model.AppLibraryButtons>();
      while (dataReader.Read())
      {
        RoadFlow.Data.Model.AppLibraryButtons appLibraryButtons = new RoadFlow.Data.Model.AppLibraryButtons();
        appLibraryButtons.ID = dataReader.GetString(0).ToGuid();
        appLibraryButtons.Name = dataReader.GetString(1);
        appLibraryButtons.Events = dataReader.GetString(2);
        if (!dataReader.IsDBNull(3))
          appLibraryButtons.Ico = dataReader.GetString(3);
        appLibraryButtons.Sort = dataReader.GetInt32(4);
        if (!dataReader.IsDBNull(5))
          appLibraryButtons.Note = dataReader.GetString(5);
        appLibraryButtonsList.Add(appLibraryButtons);
      }
      return appLibraryButtonsList;
    }

    public List<RoadFlow.Data.Model.AppLibraryButtons> GetAll()
    {
      OracleDataReader dataReader = this.dbHelper.GetDataReader("SELECT * FROM AppLibraryButtons");
      List<RoadFlow.Data.Model.AppLibraryButtons> list = this.DataReaderToList(dataReader);
      dataReader.Close();
      return list;
    }

    public long GetCount()
    {
      long result;
      if (!long.TryParse(this.dbHelper.GetFieldValue("SELECT COUNT(*) FROM AppLibraryButtons"), out result))
        return 0;
      return result;
    }

    public RoadFlow.Data.Model.AppLibraryButtons Get(Guid id)
    {
      string sql = "SELECT * FROM AppLibraryButtons WHERE ID=:ID";
      OracleParameter[] oracleParameterArray = new OracleParameter[1];
      int index = 0;
      OracleParameter oracleParameter = new OracleParameter(":ID", OracleDbType.Varchar2);
      oracleParameter.Value = (object) id;
      oracleParameterArray[index] = oracleParameter;
      OracleParameter[] parameter = oracleParameterArray;
      OracleDataReader dataReader = this.dbHelper.GetDataReader(sql, parameter);
      List<RoadFlow.Data.Model.AppLibraryButtons> list = this.DataReaderToList(dataReader);
      dataReader.Close();
      if (list.Count <= 0)
        return (RoadFlow.Data.Model.AppLibraryButtons) null;
      return list[0];
    }

    public List<RoadFlow.Data.Model.AppLibraryButtons> GetPagerData(out string pager, string query = "", int size = 15, int number = 1, string title = "")
    {
      StringBuilder stringBuilder = new StringBuilder();
      List<OracleParameter> oracleParameterList1 = new List<OracleParameter>();
      if (!title.IsNullOrEmpty())
      {
        stringBuilder.Append("AND INSTR(Name,:Name,1,1)>0 ");
        List<OracleParameter> oracleParameterList2 = oracleParameterList1;
        OracleParameter oracleParameter = new OracleParameter(":Name", OracleDbType.Varchar2);
        oracleParameter.Value = (object) title;
        oracleParameterList2.Add(oracleParameter);
      }
      long count;
      string paerSql = this.dbHelper.GetPaerSql(nameof (AppLibraryButtons), "*", stringBuilder.ToString(), "Sort DESC", size, number, out count, oracleParameterList1.ToArray());
      pager = Tools.GetPagerHtml(count, size, number, query);
      OracleDataReader dataReader = this.dbHelper.GetDataReader(paerSql, oracleParameterList1.ToArray());
      List<RoadFlow.Data.Model.AppLibraryButtons> list = this.DataReaderToList(dataReader);
      dataReader.Close();
      return list;
    }

    public List<RoadFlow.Data.Model.AppLibraryButtons> GetPagerData(out long count, int size, int number, string title = "", string order = "")
    {
      StringBuilder stringBuilder = new StringBuilder();
      List<OracleParameter> oracleParameterList1 = new List<OracleParameter>();
      if (!title.IsNullOrEmpty())
      {
        stringBuilder.Append("AND INSTR(Name,:Name,1,1)>0 ");
        List<OracleParameter> oracleParameterList2 = oracleParameterList1;
        OracleParameter oracleParameter = new OracleParameter(":Name", OracleDbType.Varchar2);
        oracleParameter.Value = (object) title;
        oracleParameterList2.Add(oracleParameter);
      }
      OracleDataReader dataReader = this.dbHelper.GetDataReader(this.dbHelper.GetPaerSql(nameof (AppLibraryButtons), "*", stringBuilder.ToString(), order.IsNullOrEmpty() ? "Sort DESC" : order, size, number, out count, oracleParameterList1.ToArray()), oracleParameterList1.ToArray());
      List<RoadFlow.Data.Model.AppLibraryButtons> list = this.DataReaderToList(dataReader);
      dataReader.Close();
      return list;
    }

    public int GetMaxSort()
    {
      return this.dbHelper.GetFieldValue("SELECT MAX(Sort) FROM AppLibraryButtons").ToInt(0) + 5;
    }
  }
}
