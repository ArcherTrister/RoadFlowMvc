// Decompiled with JetBrains decompiler
// Type: RoadFlow.Data.MSSQL.DocumentDirectory
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
  public class DocumentDirectory : IDocumentDirectory
  {
    private DBHelper dbHelper = new DBHelper();

    public int Add(RoadFlow.Data.Model.DocumentDirectory model)
    {
      string sql = "INSERT INTO DocumentDirectory\r\n\t\t\t\t(ID,ParentID,Name,ReadUsers,ManageUsers,PublishUsers,Sort) \r\n\t\t\t\tVALUES(@ID,@ParentID,@Name,@ReadUsers,@ManageUsers,@PublishUsers,@Sort)";
      SqlParameter[] sqlParameterArray = new SqlParameter[7];
      int index1 = 0;
      SqlParameter sqlParameter1 = new SqlParameter("@ID", SqlDbType.UniqueIdentifier, -1);
      sqlParameter1.Value = (object) model.ID;
      sqlParameterArray[index1] = sqlParameter1;
      int index2 = 1;
      SqlParameter sqlParameter2 = new SqlParameter("@ParentID", SqlDbType.UniqueIdentifier, -1);
      sqlParameter2.Value = (object) model.ParentID;
      sqlParameterArray[index2] = sqlParameter2;
      int index3 = 2;
      SqlParameter sqlParameter3 = new SqlParameter("@Name", SqlDbType.NVarChar, 1000);
      sqlParameter3.Value = (object) model.Name;
      sqlParameterArray[index3] = sqlParameter3;
      int index4 = 3;
      SqlParameter sqlParameter4;
      if (model.ReadUsers != null)
      {
        SqlParameter sqlParameter5 = new SqlParameter("@ReadUsers", SqlDbType.VarChar, -1);
        sqlParameter5.Value = (object) model.ReadUsers;
        sqlParameter4 = sqlParameter5;
      }
      else
      {
        sqlParameter4 = new SqlParameter("@ReadUsers", SqlDbType.VarChar, -1);
        sqlParameter4.Value = (object) DBNull.Value;
      }
      sqlParameterArray[index4] = sqlParameter4;
      int index5 = 4;
      SqlParameter sqlParameter6;
      if (model.ManageUsers != null)
      {
        SqlParameter sqlParameter5 = new SqlParameter("@ManageUsers", SqlDbType.VarChar, -1);
        sqlParameter5.Value = (object) model.ManageUsers;
        sqlParameter6 = sqlParameter5;
      }
      else
      {
        sqlParameter6 = new SqlParameter("@ManageUsers", SqlDbType.VarChar, -1);
        sqlParameter6.Value = (object) DBNull.Value;
      }
      sqlParameterArray[index5] = sqlParameter6;
      int index6 = 5;
      SqlParameter sqlParameter7;
      if (model.PublishUsers != null)
      {
        SqlParameter sqlParameter5 = new SqlParameter("@PublishUsers", SqlDbType.VarChar, -1);
        sqlParameter5.Value = (object) model.PublishUsers;
        sqlParameter7 = sqlParameter5;
      }
      else
      {
        sqlParameter7 = new SqlParameter("@PublishUsers", SqlDbType.VarChar, -1);
        sqlParameter7.Value = (object) DBNull.Value;
      }
      sqlParameterArray[index6] = sqlParameter7;
      int index7 = 6;
      SqlParameter sqlParameter8 = new SqlParameter("@Sort", SqlDbType.Int, -1);
      sqlParameter8.Value = (object) model.Sort;
      sqlParameterArray[index7] = sqlParameter8;
      SqlParameter[] parameter = sqlParameterArray;
      return this.dbHelper.Execute(sql, parameter, false);
    }

    public int Update(RoadFlow.Data.Model.DocumentDirectory model)
    {
      string sql = "UPDATE DocumentDirectory SET \r\n\t\t\t\tParentID=@ParentID,Name=@Name,ReadUsers=@ReadUsers,ManageUsers=@ManageUsers,PublishUsers=@PublishUsers,Sort=@Sort\r\n\t\t\t\tWHERE ID=@ID";
      SqlParameter[] sqlParameterArray = new SqlParameter[7];
      int index1 = 0;
      SqlParameter sqlParameter1 = new SqlParameter("@ParentID", SqlDbType.UniqueIdentifier, -1);
      sqlParameter1.Value = (object) model.ParentID;
      sqlParameterArray[index1] = sqlParameter1;
      int index2 = 1;
      SqlParameter sqlParameter2 = new SqlParameter("@Name", SqlDbType.NVarChar, 1000);
      sqlParameter2.Value = (object) model.Name;
      sqlParameterArray[index2] = sqlParameter2;
      int index3 = 2;
      SqlParameter sqlParameter3;
      if (model.ReadUsers != null)
      {
        SqlParameter sqlParameter4 = new SqlParameter("@ReadUsers", SqlDbType.VarChar, -1);
        sqlParameter4.Value = (object) model.ReadUsers;
        sqlParameter3 = sqlParameter4;
      }
      else
      {
        sqlParameter3 = new SqlParameter("@ReadUsers", SqlDbType.VarChar, -1);
        sqlParameter3.Value = (object) DBNull.Value;
      }
      sqlParameterArray[index3] = sqlParameter3;
      int index4 = 3;
      SqlParameter sqlParameter5;
      if (model.ManageUsers != null)
      {
        SqlParameter sqlParameter4 = new SqlParameter("@ManageUsers", SqlDbType.VarChar, -1);
        sqlParameter4.Value = (object) model.ManageUsers;
        sqlParameter5 = sqlParameter4;
      }
      else
      {
        sqlParameter5 = new SqlParameter("@ManageUsers", SqlDbType.VarChar, -1);
        sqlParameter5.Value = (object) DBNull.Value;
      }
      sqlParameterArray[index4] = sqlParameter5;
      int index5 = 4;
      SqlParameter sqlParameter6;
      if (model.PublishUsers != null)
      {
        SqlParameter sqlParameter4 = new SqlParameter("@PublishUsers", SqlDbType.VarChar, -1);
        sqlParameter4.Value = (object) model.PublishUsers;
        sqlParameter6 = sqlParameter4;
      }
      else
      {
        sqlParameter6 = new SqlParameter("@PublishUsers", SqlDbType.VarChar, -1);
        sqlParameter6.Value = (object) DBNull.Value;
      }
      sqlParameterArray[index5] = sqlParameter6;
      int index6 = 5;
      SqlParameter sqlParameter7 = new SqlParameter("@Sort", SqlDbType.Int, -1);
      sqlParameter7.Value = (object) model.Sort;
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
      string sql = "DELETE FROM DocumentDirectory WHERE ID=@ID";
      SqlParameter[] sqlParameterArray = new SqlParameter[1];
      int index = 0;
      SqlParameter sqlParameter = new SqlParameter("@ID", SqlDbType.UniqueIdentifier);
      sqlParameter.Value = (object) id;
      sqlParameterArray[index] = sqlParameter;
      SqlParameter[] parameter = sqlParameterArray;
      return this.dbHelper.Execute(sql, parameter, false);
    }

    private List<RoadFlow.Data.Model.DocumentDirectory> DataReaderToList(SqlDataReader dataReader)
    {
      List<RoadFlow.Data.Model.DocumentDirectory> documentDirectoryList = new List<RoadFlow.Data.Model.DocumentDirectory>();
      while (dataReader.Read())
      {
        RoadFlow.Data.Model.DocumentDirectory documentDirectory = new RoadFlow.Data.Model.DocumentDirectory();
        documentDirectory.ID = dataReader.GetGuid(0);
        documentDirectory.ParentID = dataReader.GetGuid(1);
        documentDirectory.Name = dataReader.GetString(2);
        if (!dataReader.IsDBNull(3))
          documentDirectory.ReadUsers = dataReader.GetString(3);
        if (!dataReader.IsDBNull(4))
          documentDirectory.ManageUsers = dataReader.GetString(4);
        if (!dataReader.IsDBNull(5))
          documentDirectory.PublishUsers = dataReader.GetString(5);
        documentDirectory.Sort = dataReader.GetInt32(6);
        documentDirectoryList.Add(documentDirectory);
      }
      return documentDirectoryList;
    }

    public List<RoadFlow.Data.Model.DocumentDirectory> GetAll()
    {
      SqlDataReader dataReader = this.dbHelper.GetDataReader("SELECT * FROM DocumentDirectory");
      List<RoadFlow.Data.Model.DocumentDirectory> list = this.DataReaderToList(dataReader);
      dataReader.Close();
      return list;
    }

    public long GetCount()
    {
      long result;
      if (!long.TryParse(this.dbHelper.GetFieldValue("SELECT COUNT(*) FROM DocumentDirectory"), out result))
        return 0;
      return result;
    }

    public RoadFlow.Data.Model.DocumentDirectory Get(Guid id)
    {
      string sql = "SELECT * FROM DocumentDirectory WHERE ID=@ID";
      SqlParameter[] sqlParameterArray = new SqlParameter[1];
      int index = 0;
      SqlParameter sqlParameter = new SqlParameter("@ID", SqlDbType.UniqueIdentifier);
      sqlParameter.Value = (object) id;
      sqlParameterArray[index] = sqlParameter;
      SqlParameter[] parameter = sqlParameterArray;
      SqlDataReader dataReader = this.dbHelper.GetDataReader(sql, parameter);
      List<RoadFlow.Data.Model.DocumentDirectory> list = this.DataReaderToList(dataReader);
      dataReader.Close();
      if (list.Count <= 0)
        return (RoadFlow.Data.Model.DocumentDirectory) null;
      return list[0];
    }

    public List<RoadFlow.Data.Model.DocumentDirectory> GetChilds(Guid id)
    {
      string sql = "SELECT * FROM DocumentDirectory WHERE ParentID=@ParentID ORDER BY Sort";
      SqlParameter[] sqlParameterArray = new SqlParameter[1];
      int index = 0;
      SqlParameter sqlParameter = new SqlParameter("@ParentID", SqlDbType.UniqueIdentifier);
      sqlParameter.Value = (object) id;
      sqlParameterArray[index] = sqlParameter;
      SqlParameter[] parameter = sqlParameterArray;
      SqlDataReader dataReader = this.dbHelper.GetDataReader(sql, parameter);
      List<RoadFlow.Data.Model.DocumentDirectory> list = this.DataReaderToList(dataReader);
      dataReader.Close();
      return list;
    }

    public int GetMaxSort(Guid dirID)
    {
      return this.dbHelper.GetFieldValue("SELECT (ISNULL(MAX(Sort),0)+5) Sort FROM DocumentDirectory WHERE ParentID=@ParentID ", new SqlParameter[1]{ new SqlParameter("@ParentID", (object) dirID) }).ToInt();
    }
  }
}
