// Decompiled with JetBrains decompiler
// Type: RoadFlow.Data.MSSQL.DBHelper
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
  public class DBHelper : IDBHelper
  {
    private string connectionString;

    public DBHelper()
    {
      this.connectionString = Config.PlatformConnectionStringMSSQL;
    }

    public DBHelper(string connString)
    {
      this.connectionString = connString;
    }

    public string ConnectionString
    {
      get
      {
        return this.connectionString;
      }
    }

    public void Dispose()
    {
    }

    public SqlDataReader GetDataReader(string sql)
    {
      SqlConnection connection = new SqlConnection(this.ConnectionString);
      connection.Open();
      using (SqlCommand sqlCommand = new SqlCommand(sql, connection))
      {
        sqlCommand.CommandTimeout = 180;
        sqlCommand.Prepare();
        return sqlCommand.ExecuteReader(CommandBehavior.CloseConnection);
      }
    }

    public SqlDataReader GetDataReader(string sql, SqlParameter[] parameter)
    {
      SqlConnection connection = new SqlConnection(this.ConnectionString);
      connection.Open();
      using (SqlCommand sqlCommand = new SqlCommand(sql, connection))
      {
        sqlCommand.CommandTimeout = 180;
        if (parameter != null && parameter.Length != 0)
          sqlCommand.Parameters.AddRange(parameter);
        SqlDataReader sqlDataReader = sqlCommand.ExecuteReader(CommandBehavior.CloseConnection);
        sqlCommand.Parameters.Clear();
        sqlCommand.Prepare();
        return sqlDataReader;
      }
    }

    public DataTable GetDataTable(string sql)
    {
      using (SqlConnection selectConnection = new SqlConnection(this.ConnectionString))
      {
        selectConnection.Open();
        using (SqlDataAdapter sqlDataAdapter = new SqlDataAdapter(sql, selectConnection))
        {
          DataTable dataTable = new DataTable();
          sqlDataAdapter.Fill(dataTable);
          sqlDataAdapter.Dispose();
          return dataTable;
        }
      }
    }

    public DataTable GetDataTable(string sql, SqlParameter[] parameter)
    {
      using (SqlConnection connection = new SqlConnection(this.ConnectionString))
      {
        connection.Open();
        using (SqlCommand selectCommand = new SqlCommand(sql, connection))
        {
          if (parameter != null && parameter.Length != 0)
            selectCommand.Parameters.AddRange(parameter);
          selectCommand.CommandTimeout = 180;
          using (SqlDataAdapter sqlDataAdapter = new SqlDataAdapter(selectCommand))
          {
            DataTable dataTable = new DataTable();
            sqlDataAdapter.Fill(dataTable);
            sqlDataAdapter.Dispose();
            selectCommand.Parameters.Clear();
            selectCommand.Prepare();
            return dataTable;
          }
        }
      }
    }

    public DataSet GetDataSet(string sql)
    {
      using (SqlConnection selectConnection = new SqlConnection(this.ConnectionString))
      {
        selectConnection.Open();
        using (SqlDataAdapter sqlDataAdapter = new SqlDataAdapter(sql, selectConnection))
        {
          DataSet dataSet = new DataSet();
          sqlDataAdapter.Fill(dataSet);
          return dataSet;
        }
      }
    }

    public int Execute(string sql)
    {
      using (SqlConnection connection = new SqlConnection(this.ConnectionString))
      {
        connection.Open();
        using (SqlCommand sqlCommand = new SqlCommand(sql, connection))
        {
          sqlCommand.Prepare();
          return sqlCommand.ExecuteNonQuery();
        }
      }
    }

    public int Execute(List<string> sqlList)
    {
      using (SqlConnection sqlConnection = new SqlConnection(this.ConnectionString))
      {
        sqlConnection.Open();
        using (SqlCommand sqlCommand = new SqlCommand())
        {
          int num = 0;
          sqlCommand.Connection = sqlConnection;
          foreach (string sql in sqlList)
          {
            sqlCommand.CommandType = CommandType.Text;
            sqlCommand.CommandText = sql;
            sqlCommand.Prepare();
            num += sqlCommand.ExecuteNonQuery();
          }
          return num;
        }
      }
    }

    public int Execute(string sql, SqlParameter[] parameter, bool returnIdentity = false)
    {
      using (SqlConnection connection = new SqlConnection(this.ConnectionString))
      {
        connection.Open();
        using (SqlCommand sqlCommand = new SqlCommand(sql, connection))
        {
          if (parameter != null && parameter.Length != 0)
            sqlCommand.Parameters.AddRange(parameter);
          int defaultValue = sqlCommand.ExecuteNonQuery();
          sqlCommand.Parameters.Clear();
          sqlCommand.Prepare();
          if (returnIdentity)
          {
            sqlCommand.CommandText = "select @@IDENTITY";
            object obj = sqlCommand.ExecuteScalar();
            defaultValue = obj == null ? defaultValue : obj.ToString().ToInt(defaultValue);
          }
          return defaultValue;
        }
      }
    }

    public int Execute(List<string> sqlList, List<SqlParameter[]> parameterList)
    {
      if (sqlList.Count > parameterList.Count)
        throw new Exception("参数错误");
      using (SqlConnection sqlConnection = new SqlConnection(this.ConnectionString))
      {
        sqlConnection.Open();
        using (SqlCommand sqlCommand = new SqlCommand())
        {
          int num = 0;
          sqlCommand.Connection = sqlConnection;
          for (int index = 0; index < sqlList.Count; ++index)
          {
            sqlCommand.CommandType = CommandType.Text;
            sqlCommand.CommandText = sqlList[index];
            if (parameterList[index] != null && parameterList[index].Length != 0)
              sqlCommand.Parameters.AddRange(parameterList[index]);
            num += sqlCommand.ExecuteNonQuery();
            sqlCommand.Parameters.Clear();
            sqlCommand.Prepare();
          }
          return num;
        }
      }
    }

    public string ExecuteScalar(string sql)
    {
      using (SqlConnection connection = new SqlConnection(this.ConnectionString))
      {
        connection.Open();
        using (SqlCommand sqlCommand = new SqlCommand(sql, connection))
        {
          object obj = sqlCommand.ExecuteScalar();
          sqlCommand.Prepare();
          return obj != null ? obj.ToString() : string.Empty;
        }
      }
    }

    public string ExecuteScalar(string sql, SqlParameter[] parameter)
    {
      using (SqlConnection connection = new SqlConnection(this.ConnectionString))
      {
        connection.Open();
        using (SqlCommand sqlCommand = new SqlCommand(sql, connection))
        {
          if (parameter != null && parameter.Length != 0)
            sqlCommand.Parameters.AddRange(parameter);
          object obj = sqlCommand.ExecuteScalar();
          sqlCommand.Parameters.Clear();
          sqlCommand.Prepare();
          return obj != null ? obj.ToString() : string.Empty;
        }
      }
    }

    public string GetFieldValue(string sql)
    {
      return this.ExecuteScalar(sql);
    }

    public string GetFieldValue(string sql, SqlParameter[] parameter)
    {
      return this.ExecuteScalar(sql, parameter);
    }

    public string GetFields(string sql, SqlParameter[] param)
    {
      using (SqlConnection connection = new SqlConnection(this.ConnectionString))
      {
        connection.Open();
        StringBuilder stringBuilder = new StringBuilder(500);
        using (SqlCommand sqlCommand = new SqlCommand(sql, connection))
        {
          if (param != null && param.Length != 0)
            sqlCommand.Parameters.AddRange(param);
          SqlDataReader sqlDataReader = sqlCommand.ExecuteReader(CommandBehavior.SchemaOnly);
          for (int ordinal = 0; ordinal < sqlDataReader.FieldCount; ++ordinal)
            stringBuilder.Append("[" + sqlDataReader.GetName(ordinal) + "]" + (ordinal < sqlDataReader.FieldCount - 1 ? "," : string.Empty));
          sqlCommand.Parameters.Clear();
          sqlDataReader.Close();
          sqlDataReader.Dispose();
          sqlCommand.Prepare();
          return stringBuilder.ToString();
        }
      }
    }

    public string GetFields(string sql, SqlParameter[] param, out string tableName)
    {
      using (SqlConnection connection = new SqlConnection(this.ConnectionString))
      {
        connection.Open();
        StringBuilder stringBuilder = new StringBuilder(500);
        using (SqlCommand sqlCommand = new SqlCommand(sql, connection))
        {
          if (param != null && param.Length != 0)
            sqlCommand.Parameters.AddRange(param);
          SqlDataReader sqlDataReader = sqlCommand.ExecuteReader(CommandBehavior.SchemaOnly);
          tableName = sqlDataReader.GetSchemaTable().TableName;
          for (int ordinal = 0; ordinal < sqlDataReader.FieldCount; ++ordinal)
            stringBuilder.Append("[" + sqlDataReader.GetName(ordinal) + "]" + (ordinal < sqlDataReader.FieldCount - 1 ? "," : string.Empty));
          sqlCommand.Parameters.Clear();
          sqlDataReader.Close();
          sqlDataReader.Dispose();
          sqlCommand.Prepare();
          return stringBuilder.ToString();
        }
      }
    }

    public string GetPaerSql(string sql, int size, int number, out long count, SqlParameter[] param = null)
    {
      string fieldValue = this.GetFieldValue(string.Format("select count(*) from ({0}) as PagerCountTemp", (object) sql), param);
      long test;
      count = fieldValue.IsLong(out test) ? test : 0L;
      if (count < (long) (number * size - size + 1))
        number = 1;
      StringBuilder stringBuilder = new StringBuilder();
      stringBuilder.Append("SELECT * FROM (");
      stringBuilder.Append(sql);
      stringBuilder.AppendFormat(") AS PagerTempTable");
      stringBuilder.AppendFormat(" WHERE PagerAutoRowNumber BETWEEN {0} AND {1}", (object) (number * size - size + 1), (object) (number * size));
      return stringBuilder.ToString();
    }

    public string GetPaerSql(string table, string fileds, string where, string order, int size, int number, out long count, SqlParameter[] param = null)
    {
      string empty = string.Empty;
      string str1;
      if (where.IsNullOrEmpty())
      {
        str1 = "";
      }
      else
      {
        str1 = where.Trim();
        if (str1.StartsWith("and", StringComparison.CurrentCultureIgnoreCase))
          str1 = str1.Substring(3);
      }
      string str2 = str1.IsNullOrEmpty() ? "" : "WHERE " + str1;
      string str3 = string.Format("select {0},ROW_NUMBER() OVER(ORDER BY {1}) as PagerAutoRowNumber from {2} {3}", (object) fileds, (object) order, (object) table, (object) str2);
      string fieldValue = this.GetFieldValue(string.Format("select COUNT(*) FROM {0} {1}", (object) table, (object) str2), param);
      long test;
      count = fieldValue.IsLong(out test) ? test : 0L;
      if (count < (long) (number * size - size + 1))
        number = 1;
      StringBuilder stringBuilder = new StringBuilder();
      stringBuilder.AppendFormat("SELECT * FROM (");
      stringBuilder.Append(str3);
      stringBuilder.AppendFormat(") as PagerTempTable");
      if (count > (long) size)
        stringBuilder.AppendFormat(" WHERE PagerAutoRowNumber BETWEEN {0} AND {1}", (object) (number * size - size + 1), (object) (number * size));
      return stringBuilder.ToString();
    }

    public int DataTableToDB(DataTable dt)
    {
      using (SqlConnection selectConnection = new SqlConnection(this.ConnectionString))
      {
        try
        {
          selectConnection.Open();
          using (SqlDataAdapter adapter = new SqlDataAdapter("select * from " + dt.TableName + " where 1=0", selectConnection))
          {
            DataTable dataTable = new DataTable();
            adapter.Fill(dataTable);
            foreach (DataRow row in (InternalDataCollectionBase) dt.Rows)
              dataTable.ImportRow(row);
            SqlCommandBuilder sqlCommandBuilder = new SqlCommandBuilder(adapter);
            return adapter.Update(dataTable);
          }
        }
        catch (SqlException ex)
        {
          throw ex;
        }
      }
    }
  }
}
