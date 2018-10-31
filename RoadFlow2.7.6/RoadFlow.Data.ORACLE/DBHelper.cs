// Decompiled with JetBrains decompiler
// Type: RoadFlow.Data.ORACLE.DBHelper
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
  public class DBHelper : IDBHelper
  {
    private string connectionString;

    public DBHelper()
    {
      this.connectionString = Config.PlatformConnectionStringORACLE;
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

    public OracleDataReader GetDataReader(string sql)
    {
      OracleConnection conn = new OracleConnection(this.ConnectionString);
      conn.Open();
      using (OracleCommand oracleCommand = new OracleCommand(sql, conn))
      {
        oracleCommand.Prepare();
        return oracleCommand.ExecuteReader(CommandBehavior.CloseConnection);
      }
    }

    public OracleDataReader GetDataReader(string sql, OracleParameter[] parameter)
    {
      OracleConnection conn = new OracleConnection(this.ConnectionString);
      conn.Open();
      using (OracleCommand oracleCommand = new OracleCommand(sql, conn))
      {
        if (parameter != null && parameter.Length != 0)
          oracleCommand.Parameters.AddRange((Array) parameter);
        OracleDataReader oracleDataReader = oracleCommand.ExecuteReader(CommandBehavior.CloseConnection);
        oracleCommand.Parameters.Clear();
        oracleCommand.Prepare();
        return oracleDataReader;
      }
    }

    public DataTable GetDataTable(string sql)
    {
      using (OracleConnection selectConnection = new OracleConnection(this.ConnectionString))
      {
        selectConnection.Open();
        using (OracleDataAdapter oracleDataAdapter = new OracleDataAdapter(sql, selectConnection))
        {
          DataTable dataTable = new DataTable();
          oracleDataAdapter.Fill(dataTable);
          oracleDataAdapter.Dispose();
          return dataTable;
        }
      }
    }

    public DataTable GetDataTable(string sql, OracleParameter[] parameter)
    {
      using (OracleConnection conn = new OracleConnection(this.ConnectionString))
      {
        conn.Open();
        using (OracleCommand selectCommand = new OracleCommand(sql, conn))
        {
          if (parameter != null && parameter.Length != 0)
            selectCommand.Parameters.AddRange((Array) parameter);
          selectCommand.CommandTimeout = 180;
          using (OracleDataAdapter oracleDataAdapter = new OracleDataAdapter(selectCommand))
          {
            DataTable dataTable = new DataTable();
            oracleDataAdapter.Fill(dataTable);
            oracleDataAdapter.Dispose();
            selectCommand.Parameters.Clear();
            selectCommand.Prepare();
            return dataTable;
          }
        }
      }
    }

    public DataSet GetDataSet(string sql)
    {
      using (OracleConnection selectConnection = new OracleConnection(this.ConnectionString))
      {
        selectConnection.Open();
        using (OracleDataAdapter oracleDataAdapter = new OracleDataAdapter(sql, selectConnection))
        {
          DataSet dataSet = new DataSet();
          oracleDataAdapter.Fill(dataSet);
          return dataSet;
        }
      }
    }

    public int Execute(string sql)
    {
      using (OracleConnection conn = new OracleConnection(this.ConnectionString))
      {
        conn.Open();
        using (OracleCommand oracleCommand = new OracleCommand(sql, conn))
        {
          oracleCommand.Prepare();
          return oracleCommand.ExecuteNonQuery();
        }
      }
    }

    public int Execute(List<string> sqlList)
    {
      using (OracleConnection oracleConnection = new OracleConnection(this.ConnectionString))
      {
        oracleConnection.Open();
        using (OracleCommand oracleCommand = new OracleCommand())
        {
          int num = 0;
          oracleCommand.Connection = oracleConnection;
          foreach (string sql in sqlList)
          {
            oracleCommand.CommandType = CommandType.Text;
            oracleCommand.CommandText = sql;
            oracleCommand.Prepare();
            num += oracleCommand.ExecuteNonQuery();
          }
          return num;
        }
      }
    }

    public int Execute(string sql, OracleParameter[] parameter)
    {
      using (OracleConnection conn = new OracleConnection(this.ConnectionString))
      {
        conn.Open();
        using (OracleCommand oracleCommand = new OracleCommand(sql, conn))
        {
          if (parameter != null && parameter.Length != 0)
            oracleCommand.Parameters.AddRange((Array) parameter);
          int num = oracleCommand.ExecuteNonQuery();
          oracleCommand.Parameters.Clear();
          oracleCommand.Prepare();
          return num;
        }
      }
    }

    public int Execute(List<string> sqlList, List<OracleParameter[]> parameterList)
    {
      if (sqlList.Count > parameterList.Count)
        throw new Exception("参数错误");
      using (OracleConnection oracleConnection = new OracleConnection(this.ConnectionString))
      {
        oracleConnection.Open();
        using (OracleCommand oracleCommand = new OracleCommand())
        {
          int num = 0;
          oracleCommand.Connection = oracleConnection;
          for (int index = 0; index < sqlList.Count; ++index)
          {
            oracleCommand.CommandType = CommandType.Text;
            oracleCommand.CommandText = sqlList[index];
            if (parameterList[index] != null && parameterList[index].Length != 0)
              oracleCommand.Parameters.AddRange((Array) parameterList[index]);
            num += oracleCommand.ExecuteNonQuery();
            oracleCommand.Parameters.Clear();
            oracleCommand.Prepare();
          }
          return num;
        }
      }
    }

    public string ExecuteScalar(string sql)
    {
      using (OracleConnection conn = new OracleConnection(this.ConnectionString))
      {
        conn.Open();
        using (OracleCommand oracleCommand = new OracleCommand(sql, conn))
        {
          object obj = oracleCommand.ExecuteScalar();
          oracleCommand.Prepare();
          return obj != null ? obj.ToString() : string.Empty;
        }
      }
    }

    public string ExecuteScalar(string sql, OracleParameter[] parameter)
    {
      using (OracleConnection conn = new OracleConnection(this.ConnectionString))
      {
        conn.Open();
        using (OracleCommand oracleCommand = new OracleCommand(sql, conn))
        {
          if (parameter != null && parameter.Length != 0)
            oracleCommand.Parameters.AddRange((Array) parameter);
          object obj = oracleCommand.ExecuteScalar();
          oracleCommand.Parameters.Clear();
          oracleCommand.Prepare();
          return obj != null ? obj.ToString() : string.Empty;
        }
      }
    }

    public string GetFieldValue(string sql)
    {
      return this.ExecuteScalar(sql);
    }

    public string GetFieldValue(string sql, OracleParameter[] parameter)
    {
      return this.ExecuteScalar(sql, parameter);
    }

    public string GetFields(string sql, OracleParameter[] param)
    {
      using (OracleConnection conn = new OracleConnection(this.ConnectionString))
      {
        conn.Open();
        StringBuilder stringBuilder = new StringBuilder(500);
        using (OracleCommand oracleCommand = new OracleCommand(sql, conn))
        {
          if (param != null && param.Length != 0)
            oracleCommand.Parameters.AddRange((Array) param);
          OracleDataReader oracleDataReader = oracleCommand.ExecuteReader(CommandBehavior.SchemaOnly);
          for (int ordinal = 0; ordinal < oracleDataReader.FieldCount; ++ordinal)
            stringBuilder.Append("[" + oracleDataReader.GetName(ordinal) + "]" + (ordinal < oracleDataReader.FieldCount - 1 ? "," : string.Empty));
          oracleCommand.Parameters.Clear();
          oracleDataReader.Close();
          oracleDataReader.Dispose();
          oracleCommand.Prepare();
          return stringBuilder.ToString();
        }
      }
    }

    public string GetFields(string sql, OracleParameter[] param, out string tableName)
    {
      using (OracleConnection conn = new OracleConnection(this.ConnectionString))
      {
        conn.Open();
        StringBuilder stringBuilder = new StringBuilder(500);
        using (OracleCommand oracleCommand = new OracleCommand(sql, conn))
        {
          if (param != null && param.Length != 0)
            oracleCommand.Parameters.AddRange((Array) param);
          OracleDataReader oracleDataReader = oracleCommand.ExecuteReader(CommandBehavior.SchemaOnly);
          tableName = oracleDataReader.GetSchemaTable().TableName;
          for (int ordinal = 0; ordinal < oracleDataReader.FieldCount; ++ordinal)
            stringBuilder.Append("[" + oracleDataReader.GetName(ordinal) + "]" + (ordinal < oracleDataReader.FieldCount - 1 ? "," : string.Empty));
          oracleCommand.Parameters.Clear();
          oracleDataReader.Close();
          oracleDataReader.Dispose();
          oracleCommand.Prepare();
          return stringBuilder.ToString();
        }
      }
    }

    public string GetPaerSql(string sql, int size, int number, out long count, OracleParameter[] param = null)
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
        stringBuilder.AppendFormat(" WHERE PagerAutoRowNumber BETWEEN {0} AND {1}", (object) (number * size - size + 1), (object) (number * size));
      return stringBuilder.ToString();
    }

    public string GetPaerSql(string table, string fileds, string where, string order, int size, int number, out long count, OracleParameter[] param = null)
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
      string str3 = string.Format("SELECT PagerTempTable.*,ROWNUM AS PagerAutoRowNumber FROM (SELECT {0} FROM {1} {2} ORDER BY {3}) PagerTempTable", (object) fileds, (object) table, (object) str2, (object) order);
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
        stringBuilder.AppendFormat(" WHERE PagerAutoRowNumber BETWEEN {0} AND {1}", (object) (number * size - size + 1), (object) (number * size));
      return stringBuilder.ToString();
    }

    public int DataTableToDB(DataTable dt)
    {
      using (OracleConnection selectConnection = new OracleConnection(this.ConnectionString))
      {
        try
        {
          selectConnection.Open();
          using (OracleDataAdapter dataAdapter = new OracleDataAdapter("select * from " + dt.TableName + " where 1=0", selectConnection))
          {
            DataTable dataTable = new DataTable();
            dataAdapter.Fill(dataTable);
            foreach (DataRow row in (InternalDataCollectionBase) dt.Rows)
              dataTable.ImportRow(row);
            OracleCommandBuilder oracleCommandBuilder = new OracleCommandBuilder(dataAdapter);
            return dataAdapter.Update(dataTable);
          }
        }
        catch (OracleException ex)
        {
          throw ex;
        }
      }
    }
  }
}
