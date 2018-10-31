// Decompiled with JetBrains decompiler
// Type: RoadFlow.Data.MySql.DBHelper
// Assembly: RoadFlow.Data.MySql, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 29B652D7-5F6F-4A7D-AD1C-9F2C643FD784
// Assembly location: C:\inetpub\wwwroot\RoadFlowMvc\bin\RoadFlow.Data.MySql.dll

using MySql.Data.MySqlClient;
using RoadFlow.Data.Interface;
using RoadFlow.Utility;
using System;
using System.Collections.Generic;
using System.Data;
using System.Text;

namespace RoadFlow.Data.MySql
{
  public class DBHelper : IDBHelper
  {
    private string connectionString;

    public DBHelper()
    {
      this.connectionString = Config.PlatformConnectionStringMySql;
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

    public MySqlDataReader GetDataReader(string sql)
    {
      MySqlConnection connection = new MySqlConnection(this.ConnectionString);
      connection.Open();
      using (MySqlCommand mySqlCommand = new MySqlCommand(sql, connection))
      {
        mySqlCommand.CommandTimeout = 180;
        mySqlCommand.Prepare();
        return mySqlCommand.ExecuteReader(CommandBehavior.CloseConnection);
      }
    }

    public MySqlDataReader GetDataReader(string sql, MySqlParameter[] parameter)
    {
      MySqlConnection connection = new MySqlConnection(this.ConnectionString);
      connection.Open();
      using (MySqlCommand mySqlCommand = new MySqlCommand(sql, connection))
      {
        mySqlCommand.CommandTimeout = 180;
        if (parameter != null && parameter.Length != 0)
          mySqlCommand.Parameters.AddRange((Array) parameter);
        MySqlDataReader mySqlDataReader = mySqlCommand.ExecuteReader(CommandBehavior.CloseConnection);
        mySqlCommand.Parameters.Clear();
        mySqlCommand.Prepare();
        return mySqlDataReader;
      }
    }

    public DataTable GetDataTable(string sql)
    {
      using (MySqlConnection connection = new MySqlConnection(this.ConnectionString))
      {
        connection.Open();
        using (MySqlDataAdapter mySqlDataAdapter = new MySqlDataAdapter(sql, connection))
        {
          DataTable dataTable = new DataTable();
          mySqlDataAdapter.Fill(dataTable);
          mySqlDataAdapter.Dispose();
          return dataTable;
        }
      }
    }

    public DataTable GetDataTable(string sql, MySqlParameter[] parameter)
    {
      using (MySqlConnection connection = new MySqlConnection(this.ConnectionString))
      {
        connection.Open();
        using (MySqlCommand selectCommand = new MySqlCommand(sql, connection))
        {
          if (parameter != null && parameter.Length != 0)
            selectCommand.Parameters.AddRange((Array) parameter);
          selectCommand.CommandTimeout = 180;
          using (MySqlDataAdapter mySqlDataAdapter = new MySqlDataAdapter(selectCommand))
          {
            DataTable dataTable = new DataTable();
            mySqlDataAdapter.Fill(dataTable);
            mySqlDataAdapter.Dispose();
            selectCommand.Parameters.Clear();
            selectCommand.Prepare();
            return dataTable;
          }
        }
      }
    }

    public DataSet GetDataSet(string sql)
    {
      using (MySqlConnection connection = new MySqlConnection(this.ConnectionString))
      {
        connection.Open();
        using (MySqlDataAdapter mySqlDataAdapter = new MySqlDataAdapter(sql, connection))
        {
          DataSet dataSet = new DataSet();
          mySqlDataAdapter.Fill(dataSet);
          return dataSet;
        }
      }
    }

    public int Execute(string sql)
    {
      using (MySqlConnection connection = new MySqlConnection(this.ConnectionString))
      {
        connection.Open();
        using (MySqlCommand mySqlCommand = new MySqlCommand(sql, connection))
        {
          mySqlCommand.Prepare();
          return mySqlCommand.ExecuteNonQuery();
        }
      }
    }

    public int Execute(List<string> sqlList)
    {
      using (MySqlConnection mySqlConnection = new MySqlConnection(this.ConnectionString))
      {
        mySqlConnection.Open();
        using (MySqlCommand mySqlCommand = new MySqlCommand())
        {
          int num = 0;
          mySqlCommand.Connection = mySqlConnection;
          foreach (string sql in sqlList)
          {
            mySqlCommand.CommandType = CommandType.Text;
            mySqlCommand.CommandText = sql;
            mySqlCommand.Prepare();
            num += mySqlCommand.ExecuteNonQuery();
          }
          return num;
        }
      }
    }

    public int Execute(string sql, MySqlParameter[] parameter, bool returnIdentity = false)
    {
      using (MySqlConnection connection = new MySqlConnection(this.ConnectionString))
      {
        connection.Open();
        using (MySqlCommand mySqlCommand = new MySqlCommand(sql, connection))
        {
          if (parameter != null && parameter.Length != 0)
            mySqlCommand.Parameters.AddRange((Array) parameter);
          int defaultValue = mySqlCommand.ExecuteNonQuery();
          mySqlCommand.Parameters.Clear();
          mySqlCommand.Prepare();
          if (returnIdentity)
          {
            mySqlCommand.CommandText = "select @@IDENTITY";
            object obj = mySqlCommand.ExecuteScalar();
            defaultValue = obj == null ? defaultValue : obj.ToString().ToInt(defaultValue);
          }
          return defaultValue;
        }
      }
    }

    public int Execute(List<string> sqlList, List<MySqlParameter[]> parameterList)
    {
      if (sqlList.Count > parameterList.Count)
        throw new Exception("参数错误");
      using (MySqlConnection mySqlConnection = new MySqlConnection(this.ConnectionString))
      {
        mySqlConnection.Open();
        using (MySqlCommand mySqlCommand = new MySqlCommand())
        {
          int num = 0;
          mySqlCommand.Connection = mySqlConnection;
          for (int index = 0; index < sqlList.Count; ++index)
          {
            mySqlCommand.CommandType = CommandType.Text;
            mySqlCommand.CommandText = sqlList[index];
            if (parameterList[index] != null && parameterList[index].Length != 0)
              mySqlCommand.Parameters.AddRange((Array) parameterList[index]);
            num += mySqlCommand.ExecuteNonQuery();
            mySqlCommand.Parameters.Clear();
            mySqlCommand.Prepare();
          }
          return num;
        }
      }
    }

    public string ExecuteScalar(string sql)
    {
      using (MySqlConnection connection = new MySqlConnection(this.ConnectionString))
      {
        connection.Open();
        using (MySqlCommand mySqlCommand = new MySqlCommand(sql, connection))
        {
          object obj = mySqlCommand.ExecuteScalar();
          mySqlCommand.Prepare();
          return obj != null ? obj.ToString() : string.Empty;
        }
      }
    }

    public string ExecuteScalar(string sql, MySqlParameter[] parameter)
    {
      using (MySqlConnection connection = new MySqlConnection(this.ConnectionString))
      {
        connection.Open();
        using (MySqlCommand mySqlCommand = new MySqlCommand(sql, connection))
        {
          if (parameter != null && parameter.Length != 0)
            mySqlCommand.Parameters.AddRange((Array) parameter);
          object obj = mySqlCommand.ExecuteScalar();
          mySqlCommand.Parameters.Clear();
          mySqlCommand.Prepare();
          return obj != null ? obj.ToString() : string.Empty;
        }
      }
    }

    public string GetFieldValue(string sql)
    {
      return this.ExecuteScalar(sql);
    }

    public string GetFieldValue(string sql, MySqlParameter[] parameter)
    {
      return this.ExecuteScalar(sql, parameter);
    }

    public string GetFields(string sql, MySqlParameter[] param)
    {
      using (MySqlConnection connection = new MySqlConnection(this.ConnectionString))
      {
        connection.Open();
        StringBuilder stringBuilder = new StringBuilder(500);
        using (MySqlCommand mySqlCommand = new MySqlCommand(sql, connection))
        {
          if (param != null && param.Length != 0)
            mySqlCommand.Parameters.AddRange((Array) param);
          MySqlDataReader mySqlDataReader = mySqlCommand.ExecuteReader(CommandBehavior.SchemaOnly);
          for (int ordinal = 0; ordinal < mySqlDataReader.FieldCount; ++ordinal)
            stringBuilder.Append("[" + mySqlDataReader.GetName(ordinal) + "]" + (ordinal < mySqlDataReader.FieldCount - 1 ? "," : string.Empty));
          mySqlCommand.Parameters.Clear();
          mySqlDataReader.Close();
          mySqlDataReader.Dispose();
          mySqlCommand.Prepare();
          return stringBuilder.ToString();
        }
      }
    }

    public string GetFields(string sql, MySqlParameter[] param, out string tableName)
    {
      using (MySqlConnection connection = new MySqlConnection(this.ConnectionString))
      {
        connection.Open();
        StringBuilder stringBuilder = new StringBuilder(500);
        using (MySqlCommand mySqlCommand = new MySqlCommand(sql, connection))
        {
          if (param != null && param.Length != 0)
            mySqlCommand.Parameters.AddRange((Array) param);
          MySqlDataReader mySqlDataReader = mySqlCommand.ExecuteReader(CommandBehavior.SchemaOnly);
          tableName = mySqlDataReader.GetSchemaTable().TableName;
          for (int ordinal = 0; ordinal < mySqlDataReader.FieldCount; ++ordinal)
            stringBuilder.Append("[" + mySqlDataReader.GetName(ordinal) + "]" + (ordinal < mySqlDataReader.FieldCount - 1 ? "," : string.Empty));
          mySqlCommand.Parameters.Clear();
          mySqlDataReader.Close();
          mySqlDataReader.Dispose();
          mySqlCommand.Prepare();
          return stringBuilder.ToString();
        }
      }
    }

    public string GetPaerSql(string sql, int size, int number, out long count, MySqlParameter[] param = null)
    {
      string fieldValue = this.GetFieldValue(string.Format("select count(*) from ({0}) PagerCountTemp", (object) sql), param);
      long test;
      count = fieldValue.IsLong(out test) ? test : 0L;
      if (count < (long) (number * size - size + 1))
        number = 1;
      StringBuilder stringBuilder = new StringBuilder();
      stringBuilder.Append("select * from (");
      stringBuilder.Append(sql);
      stringBuilder.AppendFormat(") PagerTempTable");
      if (count > (long) size)
        stringBuilder.AppendFormat(" LIMIT {0},{1}", (object) (number * size - size), (object) size);
      return stringBuilder.ToString();
    }

    public string GetPaerSql(string table, string fileds, string where, string order, int size, int number, out long count, MySqlParameter[] param = null)
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
      string str3 = string.Format("SELECT PagerTempTable.* FROM (SELECT {0} FROM {1} {2} ORDER BY {3}) PagerTempTable", (object) fileds, (object) table, (object) str2, (object) order);
      string fieldValue = this.GetFieldValue(string.Format("SELECT COUNT(*) FROM {0} {1}", (object) table, (object) str2), param);
      long test;
      count = fieldValue.IsLong(out test) ? test : 0L;
      if (count < (long) (number * size - size + 1))
        number = 1;
      StringBuilder stringBuilder = new StringBuilder();
      stringBuilder.Append("SELECT * FROM (");
      stringBuilder.Append(str3);
      stringBuilder.AppendFormat(") PagerTempTable");
      if (count > (long) size)
        stringBuilder.AppendFormat(" LIMIT {0},{1}", (object) (number * size - size), (object) size);
      return stringBuilder.ToString();
    }

    public int DataTableToDB(DataTable dt)
    {
      using (MySqlConnection connection = new MySqlConnection(this.ConnectionString))
      {
        try
        {
          connection.Open();
          using (MySqlDataAdapter adapter = new MySqlDataAdapter("select * from " + dt.TableName + " where 1=0", connection))
          {
            DataTable dataTable = new DataTable();
            adapter.Fill(dataTable);
            foreach (DataRow row in (InternalDataCollectionBase) dt.Rows)
              dataTable.ImportRow(row);
            MySqlCommandBuilder sqlCommandBuilder = new MySqlCommandBuilder(adapter);
            return adapter.Update(dataTable);
          }
        }
        catch (MySqlException ex)
        {
          throw ex;
        }
      }
    }
  }
}
