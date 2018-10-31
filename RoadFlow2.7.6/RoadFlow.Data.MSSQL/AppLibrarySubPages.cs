// Decompiled with JetBrains decompiler
// Type: RoadFlow.Data.MSSQL.AppLibrarySubPages
// Assembly: RoadFlow.Data.MSSQL, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 5107CDC7-8F84-4EE0-AC6D-E80FE4695340
// Assembly location: C:\inetpub\wwwroot\RoadFlowMvc\bin\RoadFlow.Data.MSSQL.dll

using RoadFlow.Data.Interface;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;

namespace RoadFlow.Data.MSSQL
{
  public class AppLibrarySubPages : IAppLibrarySubPages
  {
    private DBHelper dbHelper = new DBHelper();

    public int Add(RoadFlow.Data.Model.AppLibrarySubPages model)
    {
      string sql = "INSERT INTO AppLibrarySubPages\r\n\t\t\t\t(ID,AppLibraryID,Name,Address,Ico,Sort,Note) \r\n\t\t\t\tVALUES(@ID,@AppLibraryID,@Name,@Address,@Ico,@Sort,@Note)";
      SqlParameter[] sqlParameterArray = new SqlParameter[7];
      int index1 = 0;
      SqlParameter sqlParameter1 = new SqlParameter("@ID", SqlDbType.UniqueIdentifier, -1);
      sqlParameter1.Value = (object) model.ID;
      sqlParameterArray[index1] = sqlParameter1;
      int index2 = 1;
      SqlParameter sqlParameter2 = new SqlParameter("@AppLibraryID", SqlDbType.UniqueIdentifier, -1);
      sqlParameter2.Value = (object) model.AppLibraryID;
      sqlParameterArray[index2] = sqlParameter2;
      int index3 = 2;
      SqlParameter sqlParameter3 = new SqlParameter("@Name", SqlDbType.NVarChar, 1000);
      sqlParameter3.Value = (object) model.Name;
      sqlParameterArray[index3] = sqlParameter3;
      int index4 = 3;
      SqlParameter sqlParameter4 = new SqlParameter("@Address", SqlDbType.VarChar, 5000);
      sqlParameter4.Value = (object) model.Address;
      sqlParameterArray[index4] = sqlParameter4;
      int index5 = 4;
      SqlParameter sqlParameter5;
      if (model.Ico != null)
      {
        SqlParameter sqlParameter6 = new SqlParameter("@Ico", SqlDbType.VarChar, 5000);
        sqlParameter6.Value = (object) model.Ico;
        sqlParameter5 = sqlParameter6;
      }
      else
      {
        sqlParameter5 = new SqlParameter("@Ico", SqlDbType.VarChar, 5000);
        sqlParameter5.Value = (object) DBNull.Value;
      }
      sqlParameterArray[index5] = sqlParameter5;
      int index6 = 5;
      SqlParameter sqlParameter7 = new SqlParameter("@Sort", SqlDbType.Int, -1);
      sqlParameter7.Value = (object) model.Sort;
      sqlParameterArray[index6] = sqlParameter7;
      int index7 = 6;
      SqlParameter sqlParameter8;
      if (model.Note != null)
      {
        SqlParameter sqlParameter6 = new SqlParameter("@Note", SqlDbType.NVarChar, 4000);
        sqlParameter6.Value = (object) model.Note;
        sqlParameter8 = sqlParameter6;
      }
      else
      {
        sqlParameter8 = new SqlParameter("@Note", SqlDbType.NVarChar, 4000);
        sqlParameter8.Value = (object) DBNull.Value;
      }
      sqlParameterArray[index7] = sqlParameter8;
      SqlParameter[] parameter = sqlParameterArray;
      return this.dbHelper.Execute(sql, parameter, false);
    }

    public int Update(RoadFlow.Data.Model.AppLibrarySubPages model)
    {
      string sql = "UPDATE AppLibrarySubPages SET \r\n\t\t\t\tAppLibraryID=@AppLibraryID,Name=@Name,Address=@Address,Ico=@Ico,Sort=@Sort,Note=@Note\r\n\t\t\t\tWHERE ID=@ID";
      SqlParameter[] sqlParameterArray = new SqlParameter[7];
      int index1 = 0;
      SqlParameter sqlParameter1 = new SqlParameter("@AppLibraryID", SqlDbType.UniqueIdentifier, -1);
      sqlParameter1.Value = (object) model.AppLibraryID;
      sqlParameterArray[index1] = sqlParameter1;
      int index2 = 1;
      SqlParameter sqlParameter2 = new SqlParameter("@Name", SqlDbType.NVarChar, 1000);
      sqlParameter2.Value = (object) model.Name;
      sqlParameterArray[index2] = sqlParameter2;
      int index3 = 2;
      SqlParameter sqlParameter3 = new SqlParameter("@Address", SqlDbType.VarChar, 5000);
      sqlParameter3.Value = (object) model.Address;
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
        SqlParameter sqlParameter5 = new SqlParameter("@Note", SqlDbType.NVarChar, 4000);
        sqlParameter5.Value = (object) model.Note;
        sqlParameter7 = sqlParameter5;
      }
      else
      {
        sqlParameter7 = new SqlParameter("@Note", SqlDbType.NVarChar, 4000);
        sqlParameter7.Value = (object) DBNull.Value;
      }
      sqlParameterArray[index6] = sqlParameter7;
      int index7 = 6;
      SqlParameter sqlParameter8 = new SqlParameter("@ID", SqlDbType.UniqueIdentifier, -1);
      sqlParameter8.Value = (object) model.ID;
      sqlParameterArray[index7] = sqlParameter8;
      SqlParameter[] parameter = sqlParameterArray;
      return this.dbHelper.Execute(sql, parameter, false);
    }

    public int Delete(Guid id)
    {
      string sql = "DELETE FROM AppLibrarySubPages WHERE ID=@ID";
      SqlParameter[] sqlParameterArray = new SqlParameter[1];
      int index = 0;
      SqlParameter sqlParameter = new SqlParameter("@ID", SqlDbType.UniqueIdentifier);
      sqlParameter.Value = (object) id;
      sqlParameterArray[index] = sqlParameter;
      SqlParameter[] parameter = sqlParameterArray;
      return this.dbHelper.Execute(sql, parameter, false);
    }

    private List<RoadFlow.Data.Model.AppLibrarySubPages> DataReaderToList(SqlDataReader dataReader)
    {
      List<RoadFlow.Data.Model.AppLibrarySubPages> appLibrarySubPagesList = new List<RoadFlow.Data.Model.AppLibrarySubPages>();
      while (dataReader.Read())
      {
        RoadFlow.Data.Model.AppLibrarySubPages appLibrarySubPages = new RoadFlow.Data.Model.AppLibrarySubPages();
        appLibrarySubPages.ID = dataReader.GetGuid(0);
        appLibrarySubPages.AppLibraryID = dataReader.GetGuid(1);
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
      SqlDataReader dataReader = this.dbHelper.GetDataReader("SELECT * FROM AppLibrarySubPages");
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
      string sql = "SELECT * FROM AppLibrarySubPages WHERE ID=@ID";
      SqlParameter[] sqlParameterArray = new SqlParameter[1];
      int index = 0;
      SqlParameter sqlParameter = new SqlParameter("@ID", SqlDbType.UniqueIdentifier);
      sqlParameter.Value = (object) id;
      sqlParameterArray[index] = sqlParameter;
      SqlParameter[] parameter = sqlParameterArray;
      SqlDataReader dataReader = this.dbHelper.GetDataReader(sql, parameter);
      List<RoadFlow.Data.Model.AppLibrarySubPages> list = this.DataReaderToList(dataReader);
      dataReader.Close();
      if (list.Count <= 0)
        return (RoadFlow.Data.Model.AppLibrarySubPages) null;
      return list[0];
    }

    public int DeleteByAppID(Guid id)
    {
      string sql = "DELETE FROM AppLibrarySubPages WHERE AppLibraryID=@ID";
      SqlParameter[] sqlParameterArray = new SqlParameter[1];
      int index = 0;
      SqlParameter sqlParameter = new SqlParameter("@ID", SqlDbType.UniqueIdentifier);
      sqlParameter.Value = (object) id;
      sqlParameterArray[index] = sqlParameter;
      SqlParameter[] parameter = sqlParameterArray;
      return this.dbHelper.Execute(sql, parameter, false);
    }

    public List<RoadFlow.Data.Model.AppLibrarySubPages> GetAllByAppID(Guid id)
    {
      string sql = "SELECT * FROM AppLibrarySubPages WHERE AppLibraryID=@ID";
      SqlParameter[] sqlParameterArray = new SqlParameter[1];
      int index = 0;
      SqlParameter sqlParameter = new SqlParameter("@ID", SqlDbType.UniqueIdentifier);
      sqlParameter.Value = (object) id;
      sqlParameterArray[index] = sqlParameter;
      SqlParameter[] parameter = sqlParameterArray;
      SqlDataReader dataReader = this.dbHelper.GetDataReader(sql, parameter);
      List<RoadFlow.Data.Model.AppLibrarySubPages> list = this.DataReaderToList(dataReader);
      dataReader.Close();
      return list;
    }
  }
}
