// Decompiled with JetBrains decompiler
// Type: RoadFlow.Data.MSSQL.AppLibraryButtons
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
  public class AppLibraryButtons : IAppLibraryButtons
  {
    private DBHelper dbHelper = new DBHelper();

    public int Add(RoadFlow.Data.Model.AppLibraryButtons model)
    {
      string sql = "INSERT INTO AppLibraryButtons\r\n\t\t\t\t(ID,Name,Events,Ico,Sort,Note) \r\n\t\t\t\tVALUES(@ID,@Name,@Events,@Ico,@Sort,@Note)";
      SqlParameter[] sqlParameterArray = new SqlParameter[6];
      int index1 = 0;
      SqlParameter sqlParameter1 = new SqlParameter("@ID", SqlDbType.UniqueIdentifier, -1);
      sqlParameter1.Value = (object) model.ID;
      sqlParameterArray[index1] = sqlParameter1;
      int index2 = 1;
      SqlParameter sqlParameter2 = new SqlParameter("@Name", SqlDbType.NVarChar, 100);
      sqlParameter2.Value = (object) model.Name;
      sqlParameterArray[index2] = sqlParameter2;
      int index3 = 2;
      SqlParameter sqlParameter3 = new SqlParameter("@Events", SqlDbType.VarChar, 5000);
      sqlParameter3.Value = (object) model.Events;
      sqlParameterArray[index3] = sqlParameter3;
      int index4 = 3;
      SqlParameter sqlParameter4;
      if (model.Ico != null)
      {
        SqlParameter sqlParameter5 = new SqlParameter("@Ico", SqlDbType.VarChar, 5000);
        sqlParameter5.Value = (object) model.Ico;
        sqlParameter4 = sqlParameter5;
      }
      else
      {
        sqlParameter4 = new SqlParameter("@Ico", SqlDbType.VarChar, 5000);
        sqlParameter4.Value = (object) DBNull.Value;
      }
      sqlParameterArray[index4] = sqlParameter4;
      int index5 = 4;
      SqlParameter sqlParameter6 = new SqlParameter("@Sort", SqlDbType.Int, -1);
      sqlParameter6.Value = (object) model.Sort;
      sqlParameterArray[index5] = sqlParameter6;
      int index6 = 5;
      SqlParameter sqlParameter7;
      if (model.Note != null)
      {
        SqlParameter sqlParameter5 = new SqlParameter("@Note", SqlDbType.NVarChar, 1000);
        sqlParameter5.Value = (object) model.Note;
        sqlParameter7 = sqlParameter5;
      }
      else
      {
        sqlParameter7 = new SqlParameter("@Note", SqlDbType.NVarChar, 1000);
        sqlParameter7.Value = (object) DBNull.Value;
      }
      sqlParameterArray[index6] = sqlParameter7;
      SqlParameter[] parameter = sqlParameterArray;
      return this.dbHelper.Execute(sql, parameter, false);
    }

    public int Update(RoadFlow.Data.Model.AppLibraryButtons model)
    {
      string sql = "UPDATE AppLibraryButtons SET \r\n\t\t\t\tName=@Name,Events=@Events,Ico=@Ico,Sort=@Sort,Note=@Note\r\n\t\t\t\tWHERE ID=@ID";
      SqlParameter[] sqlParameterArray = new SqlParameter[6];
      int index1 = 0;
      SqlParameter sqlParameter1 = new SqlParameter("@Name", SqlDbType.NVarChar, 100);
      sqlParameter1.Value = (object) model.Name;
      sqlParameterArray[index1] = sqlParameter1;
      int index2 = 1;
      SqlParameter sqlParameter2 = new SqlParameter("@Events", SqlDbType.VarChar, 5000);
      sqlParameter2.Value = (object) model.Events;
      sqlParameterArray[index2] = sqlParameter2;
      int index3 = 2;
      SqlParameter sqlParameter3;
      if (model.Ico != null)
      {
        SqlParameter sqlParameter4 = new SqlParameter("@Ico", SqlDbType.VarChar, 5000);
        sqlParameter4.Value = (object) model.Ico;
        sqlParameter3 = sqlParameter4;
      }
      else
      {
        sqlParameter3 = new SqlParameter("@Ico", SqlDbType.VarChar, 5000);
        sqlParameter3.Value = (object) DBNull.Value;
      }
      sqlParameterArray[index3] = sqlParameter3;
      int index4 = 3;
      SqlParameter sqlParameter5 = new SqlParameter("@Sort", SqlDbType.Int, -1);
      sqlParameter5.Value = (object) model.Sort;
      sqlParameterArray[index4] = sqlParameter5;
      int index5 = 4;
      SqlParameter sqlParameter6;
      if (model.Note != null)
      {
        SqlParameter sqlParameter4 = new SqlParameter("@Note", SqlDbType.NVarChar, 1000);
        sqlParameter4.Value = (object) model.Note;
        sqlParameter6 = sqlParameter4;
      }
      else
      {
        sqlParameter6 = new SqlParameter("@Note", SqlDbType.NVarChar, 1000);
        sqlParameter6.Value = (object) DBNull.Value;
      }
      sqlParameterArray[index5] = sqlParameter6;
      int index6 = 5;
      SqlParameter sqlParameter7 = new SqlParameter("@ID", SqlDbType.UniqueIdentifier, -1);
      sqlParameter7.Value = (object) model.ID;
      sqlParameterArray[index6] = sqlParameter7;
      SqlParameter[] parameter = sqlParameterArray;
      return this.dbHelper.Execute(sql, parameter, false);
    }

    public int Delete(Guid id)
    {
      string sql = "DELETE FROM AppLibraryButtons WHERE ID=@ID";
      SqlParameter[] sqlParameterArray = new SqlParameter[1];
      int index = 0;
      SqlParameter sqlParameter = new SqlParameter("@ID", SqlDbType.UniqueIdentifier);
      sqlParameter.Value = (object) id;
      sqlParameterArray[index] = sqlParameter;
      SqlParameter[] parameter = sqlParameterArray;
      return this.dbHelper.Execute(sql, parameter, false);
    }

    private List<RoadFlow.Data.Model.AppLibraryButtons> DataReaderToList(SqlDataReader dataReader)
    {
      List<RoadFlow.Data.Model.AppLibraryButtons> appLibraryButtonsList = new List<RoadFlow.Data.Model.AppLibraryButtons>();
      while (dataReader.Read())
      {
        RoadFlow.Data.Model.AppLibraryButtons appLibraryButtons = new RoadFlow.Data.Model.AppLibraryButtons();
        appLibraryButtons.ID = dataReader.GetGuid(0);
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
      SqlDataReader dataReader = this.dbHelper.GetDataReader("SELECT * FROM AppLibraryButtons");
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
      string sql = "SELECT * FROM AppLibraryButtons WHERE ID=@ID";
      SqlParameter[] sqlParameterArray = new SqlParameter[1];
      int index = 0;
      SqlParameter sqlParameter = new SqlParameter("@ID", SqlDbType.UniqueIdentifier);
      sqlParameter.Value = (object) id;
      sqlParameterArray[index] = sqlParameter;
      SqlParameter[] parameter = sqlParameterArray;
      SqlDataReader dataReader = this.dbHelper.GetDataReader(sql, parameter);
      List<RoadFlow.Data.Model.AppLibraryButtons> list = this.DataReaderToList(dataReader);
      dataReader.Close();
      if (list.Count <= 0)
        return (RoadFlow.Data.Model.AppLibraryButtons) null;
      return list[0];
    }

    public List<RoadFlow.Data.Model.AppLibraryButtons> GetPagerData(out string pager, string query = "", int size = 15, int number = 1, string title = "")
    {
      StringBuilder stringBuilder = new StringBuilder();
      List<SqlParameter> sqlParameterList1 = new List<SqlParameter>();
      if (!title.IsNullOrEmpty())
      {
        stringBuilder.Append("AND CHARINDEX(@Name,Name)>0 ");
        List<SqlParameter> sqlParameterList2 = sqlParameterList1;
        SqlParameter sqlParameter = new SqlParameter("@Name", SqlDbType.NVarChar);
        sqlParameter.Value = (object) title;
        sqlParameterList2.Add(sqlParameter);
      }
      long count;
      string paerSql = this.dbHelper.GetPaerSql(nameof (AppLibraryButtons), "*", stringBuilder.ToString(), "Sort DESC", size, number, out count, sqlParameterList1.ToArray());
      pager = Tools.GetPagerHtml(count, size, number, query);
      SqlDataReader dataReader = this.dbHelper.GetDataReader(paerSql, sqlParameterList1.ToArray());
      List<RoadFlow.Data.Model.AppLibraryButtons> list = this.DataReaderToList(dataReader);
      dataReader.Close();
      return list;
    }

    public List<RoadFlow.Data.Model.AppLibraryButtons> GetPagerData(out long count, int size, int number, string title = "", string order = "")
    {
      StringBuilder stringBuilder = new StringBuilder();
      List<SqlParameter> sqlParameterList1 = new List<SqlParameter>();
      if (!title.IsNullOrEmpty())
      {
        stringBuilder.Append("AND CHARINDEX(@Name,Name)>0 ");
        List<SqlParameter> sqlParameterList2 = sqlParameterList1;
        SqlParameter sqlParameter = new SqlParameter("@Name", SqlDbType.NVarChar);
        sqlParameter.Value = (object) title;
        sqlParameterList2.Add(sqlParameter);
      }
      SqlDataReader dataReader = this.dbHelper.GetDataReader(this.dbHelper.GetPaerSql(nameof (AppLibraryButtons), "*", stringBuilder.ToString(), order.IsNullOrEmpty() ? "Sort DESC" : order, size, number, out count, sqlParameterList1.ToArray()), sqlParameterList1.ToArray());
      List<RoadFlow.Data.Model.AppLibraryButtons> list = this.DataReaderToList(dataReader);
      dataReader.Close();
      return list;
    }

    public int GetMaxSort()
    {
      return this.dbHelper.GetFieldValue("SELECT ISNULL(MAX(Sort),0)+5 FROM AppLibraryButtons").ToInt();
    }
  }
}
