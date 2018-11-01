// Decompiled with JetBrains decompiler
// Type: RoadFlow.Platform.DBConnection
// Assembly: RoadFlow.Platform, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 07F26AFD-DE3B-4003-89AF-01A62494BA58
// Assembly location: C:\inetpub\wwwroot\RoadFlowMvc\bin\RoadFlow.Platform.dll

using LitJson;
using MySql.Data.MySqlClient;
using Oracle.ManagedDataAccess.Client;
using RoadFlow.Cache.IO;
using RoadFlow.Data.Interface;
using RoadFlow.Utility;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;

namespace RoadFlow.Platform
{
  public class DBConnection
  {
    private IDBConnection dataDBConnection;

    public DBConnection()
    {
      this.dataDBConnection = RoadFlow.Data.Factory.Factory.GetDBConnection();
    }

    public int Add(RoadFlow.Data.Model.DBConnection model)
    {
      int num = this.dataDBConnection.Add(model);
      this.ClearCache();
      return num;
    }

    public int Update(RoadFlow.Data.Model.DBConnection model)
    {
      int num = this.dataDBConnection.Update(model);
      this.ClearCache();
      return num;
    }

    public List<RoadFlow.Data.Model.DBConnection> GetAll(bool fromCache = false)
    {
      if (!fromCache)
        return this.dataDBConnection.GetAll();
      string key = Keys.CacheKeys.DBConnnections.ToString();
      object obj = Opation.Get(key);
      if (obj != null && obj is List<RoadFlow.Data.Model.DBConnection>)
        return (List<RoadFlow.Data.Model.DBConnection>) obj;
      List<RoadFlow.Data.Model.DBConnection> all = this.dataDBConnection.GetAll();
      Opation.Set(key, (object) all);
      return all;
    }

    public RoadFlow.Data.Model.DBConnection Get(Guid id, bool fromCache = true)
    {
      if (fromCache)
        return this.GetAll(true).Find((Predicate<RoadFlow.Data.Model.DBConnection>) (p => p.ID == id)) ?? this.dataDBConnection.Get(id);
      return this.dataDBConnection.Get(id);
    }

    public int Delete(Guid id)
    {
      int num = this.dataDBConnection.Delete(id);
      this.ClearCache();
      return num;
    }

    public long GetCount()
    {
      return this.dataDBConnection.GetCount();
    }

    public string GetAllTypeOptions(string value = "")
    {
      StringBuilder stringBuilder = new StringBuilder();
      foreach (object obj in Enum.GetValues(typeof (DBConnection.ConnTypes)))
        stringBuilder.AppendFormat("<option value=\"{0}\" {1}>{0}</option>", obj, obj.ToString() == value ? (object) "selected=\"selected\"" : (object) "");
      return stringBuilder.ToString();
    }

    public string GetAllOptions(string value = "")
    {
      List<RoadFlow.Data.Model.DBConnection> all = this.GetAll(true);
      StringBuilder stringBuilder = new StringBuilder();
      foreach (RoadFlow.Data.Model.DBConnection dbConnection in (IEnumerable<RoadFlow.Data.Model.DBConnection>) all.OrderBy<RoadFlow.Data.Model.DBConnection, string>((Func<RoadFlow.Data.Model.DBConnection, string>) (p => p.Name)))
        stringBuilder.AppendFormat("<option value=\"{0}\" {1}>{2}</option>", (object) dbConnection.ID, string.Compare(dbConnection.ID.ToString(), value, true) == 0 ? (object) "selected=\"selected\"" : (object) "", (object) dbConnection.Name);
      return stringBuilder.ToString();
    }

    public void ClearCache()
    {
      Opation.Remove(Keys.CacheKeys.DBConnnections.ToString());
    }

    public List<string> GetTables(Guid id, int type = 0)
    {
      RoadFlow.Data.Model.DBConnection conn = this.GetAll(true).Find((Predicate<RoadFlow.Data.Model.DBConnection>) (p => p.ID == id));
      if (conn == null)
        return new List<string>();
      List<string> stringList = new List<string>();
      string type1 = conn.Type;
      if (!(type1 == "SqlServer"))
      {
        if (!(type1 == "Oracle"))
        {
          if (type1 == "MySql")
            stringList = this.getTables_MySql(conn, type);
        }
        else
          stringList = this.getTables_Oracle(conn, type);
      }
      else
        stringList = this.getTables_SqlServer(conn, type);
      return stringList;
    }

    public System.Collections.Generic.Dictionary<string, string> GetFields(Guid id, string table)
    {
      if (table.IsNullOrEmpty())
        return new System.Collections.Generic.Dictionary<string, string>();
      RoadFlow.Data.Model.DBConnection conn = this.GetAll(true).Find((Predicate<RoadFlow.Data.Model.DBConnection>) (p => p.ID == id));
      if (conn == null)
        return new System.Collections.Generic.Dictionary<string, string>();
      System.Collections.Generic.Dictionary<string, string> dictionary = new System.Collections.Generic.Dictionary<string, string>();
      string type = conn.Type;
      if (!(type == "SqlServer"))
      {
        if (!(type == "Oracle"))
        {
          if (type == "MySql")
            dictionary = this.getFields_MySql(conn, table);
        }
        else
          dictionary = this.getFields_Oracle(conn, table);
      }
      else
        dictionary = this.getFields_SqlServer(conn, table);
      return dictionary;
    }

    public string GetFieldValue(Guid connID, string sql, IDbDataParameter[] param = null)
    {
      RoadFlow.Data.Model.DBConnection dbConnection = this.Get(connID, true);
      if (dbConnection == null)
        return "";
      string lower = dbConnection.Type.ToLower();
      if (!(lower == "sqlserver"))
      {
        if (!(lower == "oracle"))
        {
          if (lower == "mysql")
          {
            using (MySqlConnection connection = new MySqlConnection(dbConnection.ConnectionString))
            {
              try
              {
                connection.Open();
                using (MySqlCommand mySqlCommand = new MySqlCommand(sql, connection))
                {
                  if (param != null && param.Length != 0)
                  {
                    foreach (IDbDataParameter dbDataParameter in param)
                      mySqlCommand.Parameters.Add((MySqlParameter) dbDataParameter);
                  }
                  object obj = mySqlCommand.ExecuteScalar();
                  mySqlCommand.Parameters.Clear();
                  return obj.ToString();
                }
              }
              catch
              {
              }
              finally
              {
                connection.Close();
                connection.Dispose();
              }
            }
          }
        }
        else
        {
          using (OracleConnection conn = new OracleConnection(dbConnection.ConnectionString))
          {
            try
            {
              conn.Open();
              using (OracleCommand oracleCommand = new OracleCommand(sql, conn))
              {
                if (param != null && param.Length != 0)
                {
                  foreach (IDbDataParameter dbDataParameter in param)
                    oracleCommand.Parameters.Add((OracleParameter) dbDataParameter);
                }
                object obj = oracleCommand.ExecuteScalar();
                oracleCommand.Parameters.Clear();
                return obj.ToString();
              }
            }
            catch
            {
            }
            finally
            {
              conn.Close();
              conn.Dispose();
            }
          }
        }
      }
      else
      {
        using (SqlConnection connection = new SqlConnection(dbConnection.ConnectionString))
        {
          try
          {
            connection.Open();
            using (SqlCommand sqlCommand = new SqlCommand(sql, connection))
            {
              if (param != null && param.Length != 0)
              {
                foreach (IDbDataParameter dbDataParameter in param)
                  sqlCommand.Parameters.Add((SqlParameter) dbDataParameter);
              }
              object obj = sqlCommand.ExecuteScalar();
              sqlCommand.Parameters.Clear();
              return obj.ToString();
            }
          }
          catch
          {
          }
          finally
          {
            connection.Close();
            connection.Dispose();
          }
        }
      }
      return "";
    }

    public string GetFieldValue(string link_table_field, System.Collections.Generic.Dictionary<string, string> pkFieldValue)
    {
      if (link_table_field.IsNullOrEmpty())
        return "";
      string[] strArray = link_table_field.Split('.');
      if (strArray.Length != 3)
        return "";
      string str1 = strArray[0];
      string table = strArray[1];
      string field = strArray[2];
      List<RoadFlow.Data.Model.DBConnection> all = this.GetAll(true);
      Guid linkid;
      if (!str1.IsGuid(out linkid))
        return "";
      RoadFlow.Data.Model.DBConnection conn = all.Find((Predicate<RoadFlow.Data.Model.DBConnection>) (p => p.ID == linkid));
      if (conn == null)
        return "";
      List<string> stringList = new List<string>();
      string str2 = string.Empty;
      string type = conn.Type;
      if (!(type == "SqlServer"))
      {
        if (!(type == "Oracle"))
        {
          if (type == "MySql")
            str2 = this.getFieldValue_MySql(conn, table, field, pkFieldValue);
        }
        else
          str2 = this.getFieldValue_Oracle(conn, table, field, pkFieldValue);
      }
      else
        str2 = this.getFieldValue_SqlServer(conn, table, field, pkFieldValue);
      return str2;
    }

    public string GetFieldValue(string link_table_field, string pkField, string pkFieldValue)
    {
      if (link_table_field.IsNullOrEmpty())
        return "";
      string[] strArray = link_table_field.Split('.');
      if (strArray.Length != 3)
        return "";
      string str1 = strArray[0];
      string table = strArray[1];
      string field = strArray[2];
      List<RoadFlow.Data.Model.DBConnection> all = this.GetAll(true);
      Guid linkid;
      if (!str1.IsGuid(out linkid))
        return "";
      RoadFlow.Data.Model.DBConnection conn = all.Find((Predicate<RoadFlow.Data.Model.DBConnection>) (p => p.ID == linkid));
      if (conn == null)
        return "";
      string str2 = string.Empty;
      string type = conn.Type;
      if (!(type == "SqlServer"))
      {
        if (!(type == "Oracle"))
        {
          if (type == "MySql")
            str2 = this.getFieldValue_MySql(conn, table, field, pkField, pkFieldValue);
        }
        else
          str2 = this.getFieldValue_Oracle(conn, table, field, pkField, pkFieldValue);
      }
      else
        str2 = this.getFieldValue_SqlServer(conn, table, field, pkField, pkFieldValue);
      return str2;
    }

    public string Test(Guid connID)
    {
      RoadFlow.Data.Model.DBConnection conn = this.Get(connID, true);
      if (conn == null)
        return "未找到连接!";
      string type = conn.Type;
      if (type == "SqlServer")
        return this.test_SqlServer(conn);
      if (type == "Oracle")
        return this.test_Oracle(conn);
      if (type == "MySql")
        return this.test_MySql(conn);
      return "";
    }

    private string test_SqlServer(RoadFlow.Data.Model.DBConnection conn)
    {
      try
      {
        using (SqlConnection sqlConnection = new SqlConnection(conn.ConnectionString))
        {
          sqlConnection.Open();
          return "连接成功!";
        }
      }
      catch (SqlException ex)
      {
        return ex.Message;
      }
    }

    private string test_Oracle(RoadFlow.Data.Model.DBConnection conn)
    {
      try
      {
        using (OracleConnection oracleConnection = new OracleConnection(conn.ConnectionString))
        {
          oracleConnection.Open();
          return "连接成功!";
        }
      }
      catch (OracleException ex)
      {
        return ex.Message;
      }
    }

    private string test_MySql(RoadFlow.Data.Model.DBConnection conn)
    {
      try
      {
        using (MySqlConnection mySqlConnection = new MySqlConnection(conn.ConnectionString))
        {
          mySqlConnection.Open();
          return "连接成功!";
        }
      }
      catch (MySqlException ex)
      {
        return ex.Message;
      }
    }

    private string testSql_SqlServer(RoadFlow.Data.Model.DBConnection conn, string sql)
    {
      using (SqlConnection connection = new SqlConnection(conn.ConnectionString))
      {
        try
        {
          connection.Open();
        }
        catch (SqlException ex)
        {
          return ex.Message;
        }
        using (SqlCommand sqlCommand = new SqlCommand(sql, connection))
        {
          try
          {
            sqlCommand.ExecuteNonQuery();
          }
          catch (SqlException ex)
          {
            return ex.Message;
          }
        }
        return "";
      }
    }

    private string testSql_Oracle(RoadFlow.Data.Model.DBConnection conn, string sql)
    {
      using (OracleConnection conn1 = new OracleConnection(conn.ConnectionString))
      {
        try
        {
          conn1.Open();
        }
        catch (OracleException ex)
        {
          return ex.Message;
        }
        using (OracleCommand oracleCommand = new OracleCommand(sql, conn1))
        {
          try
          {
            oracleCommand.ExecuteNonQuery();
          }
          catch (OracleException ex)
          {
            return ex.Message;
          }
        }
        return "";
      }
    }

    private List<string> getTables_SqlServer(RoadFlow.Data.Model.DBConnection conn, int type)
    {
      using (SqlConnection connection = new SqlConnection(conn.ConnectionString))
      {
        try
        {
          connection.Open();
        }
        catch (SqlException ex)
        {
          Log.Add((Exception) ex);
          return new List<string>();
        }
        List<string> stringList = new List<string>();
        string str = string.Empty;
        switch (type)
        {
          case 0:
            str = "xtype='U' or xtype='V'";
            break;
          case 1:
            str = "xtype='U'";
            break;
          case 2:
            str = "xtype='V'";
            break;
        }
        using (SqlCommand sqlCommand = new SqlCommand("SELECT name FROM sysobjects WHERE " + str + " ORDER BY xtype, name", connection))
        {
          SqlDataReader sqlDataReader = sqlCommand.ExecuteReader();
          while (sqlDataReader.Read())
            stringList.Add(sqlDataReader.GetString(0));
          sqlDataReader.Close();
          return stringList;
        }
      }
    }

    private List<string> getTables_Oracle(RoadFlow.Data.Model.DBConnection conn, int type)
    {
      using (OracleConnection conn1 = new OracleConnection(conn.ConnectionString))
      {
        try
        {
          conn1.Open();
        }
        catch (OracleException ex)
        {
          Log.Add((Exception) ex);
          return new List<string>();
        }
        List<string> stringList = new List<string>();
        string str = string.Empty;
        switch (type)
        {
          case 0:
            str = "and TABTYPE='TABLE' or TABTYPE='VIEW'";
            break;
          case 1:
            str = "and TABTYPE='TABLE'";
            break;
          case 2:
            str = "and TABTYPE='VIEW'";
            break;
        }
        using (OracleCommand oracleCommand = new OracleCommand("select * from tab where instr(tname,'$',1,1)=0 " + str, conn1))
        {
          OracleDataReader oracleDataReader = oracleCommand.ExecuteReader();
          while (oracleDataReader.Read())
            stringList.Add(oracleDataReader.GetString(0));
          oracleDataReader.Close();
          return stringList;
        }
      }
    }

    private List<string> getTables_MySql(RoadFlow.Data.Model.DBConnection conn, int type)
    {
      using (MySqlConnection connection = new MySqlConnection(conn.ConnectionString))
      {
        try
        {
          connection.Open();
        }
        catch (MySqlException ex)
        {
          Log.Add((Exception) ex);
          return new List<string>();
        }
        List<string> stringList = new List<string>();
        string str = string.Empty;
        switch (type)
        {
          case 0:
            str = "table_type='BASE TABLE' or table_type='VIEW'";
            break;
          case 1:
            str = "table_type='BASE TABLE'";
            break;
          case 2:
            str = "table_type='VIEW'";
            break;
        }
        using (MySqlCommand mySqlCommand = new MySqlCommand(string.Format("show full tables from {0} where " + str, (object) connection.Database), connection))
        {
          MySqlDataReader mySqlDataReader = mySqlCommand.ExecuteReader();
          while (mySqlDataReader.Read())
            stringList.Add(mySqlDataReader.GetString(0));
          mySqlDataReader.Close();
          return stringList;
        }
      }
    }

    private System.Collections.Generic.Dictionary<string, string> getFields_SqlServer(RoadFlow.Data.Model.DBConnection conn, string table)
    {
      using (SqlConnection connection = new SqlConnection(conn.ConnectionString))
      {
        try
        {
          connection.Open();
        }
        catch (SqlException ex)
        {
          Log.Add((Exception) ex);
          return new System.Collections.Generic.Dictionary<string, string>();
        }
        System.Collections.Generic.Dictionary<string, string> dictionary = new System.Collections.Generic.Dictionary<string, string>();
        using (SqlCommand sqlCommand = new SqlCommand(string.Format("SELECT a.name as f_name, b.value from \r\nsys.syscolumns a LEFT JOIN sys.extended_properties b on a.id=b.major_id AND a.colid=b.minor_id AND b.name='MS_Description' \r\nWHERE object_id('{0}')=a.id ORDER BY a.colid", (object) table), connection))
        {
          SqlDataReader sqlDataReader = sqlCommand.ExecuteReader();
          while (sqlDataReader.Read())
            dictionary.Add(sqlDataReader.GetString(0), sqlDataReader.IsDBNull(1) ? "" : sqlDataReader.GetString(1).Replace1("\r\n", ""));
          sqlDataReader.Close();
          return dictionary;
        }
      }
    }

    private System.Collections.Generic.Dictionary<string, string> getFields_Oracle(RoadFlow.Data.Model.DBConnection conn, string table)
    {
      using (OracleConnection conn1 = new OracleConnection(conn.ConnectionString))
      {
        try
        {
          conn1.Open();
        }
        catch (OracleException ex)
        {
          Log.Add((Exception) ex);
          return new System.Collections.Generic.Dictionary<string, string>();
        }
        System.Collections.Generic.Dictionary<string, string> dictionary = new System.Collections.Generic.Dictionary<string, string>();
        using (OracleCommand oracleCommand = new OracleCommand(string.Format("select COLUMN_NAME,COMMENTS from user_col_comments where TABLE_NAME='{0}'", (object) table), conn1))
        {
          OracleDataReader oracleDataReader = oracleCommand.ExecuteReader();
          while (oracleDataReader.Read())
            dictionary.Add(oracleDataReader.GetString(0), oracleDataReader.IsDBNull(1) ? "" : oracleDataReader.GetString(1));
          oracleDataReader.Close();
          return dictionary;
        }
      }
    }

    private System.Collections.Generic.Dictionary<string, string> getFields_MySql(RoadFlow.Data.Model.DBConnection conn, string table)
    {
      using (MySqlConnection connection = new MySqlConnection(conn.ConnectionString))
      {
        try
        {
          connection.Open();
        }
        catch (MySqlException ex)
        {
          Log.Add((Exception) ex);
          return new System.Collections.Generic.Dictionary<string, string>();
        }
        System.Collections.Generic.Dictionary<string, string> dictionary = new System.Collections.Generic.Dictionary<string, string>();
        using (MySqlCommand mySqlCommand = new MySqlCommand(string.Format("show full fields from {0}", (object) table), connection))
        {
          MySqlDataReader mySqlDataReader = mySqlCommand.ExecuteReader();
          while (mySqlDataReader.Read())
            dictionary.Add(mySqlDataReader["Field"].ToString(), mySqlDataReader["Comment"].ToString());
          mySqlDataReader.Close();
          return dictionary;
        }
      }
    }

    private string getFieldValue_SqlServer(RoadFlow.Data.Model.DBConnection conn, string table, string field, System.Collections.Generic.Dictionary<string, string> pkFieldValue)
    {
      using (SqlConnection connection = new SqlConnection(conn.ConnectionString))
      {
        try
        {
          connection.Open();
        }
        catch (SqlException ex)
        {
          Log.Add((Exception) ex);
          return "";
        }
        List<string> stringList = new List<string>();
        StringBuilder stringBuilder = new StringBuilder();
        stringBuilder.AppendFormat("select {0} from {1} where 1=1", (object) field, (object) table);
        foreach (KeyValuePair<string, string> keyValuePair in pkFieldValue)
          stringBuilder.AppendFormat(" and {0}='{1}'", (object) keyValuePair.Key, (object) keyValuePair.Value);
        using (SqlCommand sqlCommand = new SqlCommand(stringBuilder.ToString(), connection))
        {
          SqlDataReader sqlDataReader = sqlCommand.ExecuteReader();
          string empty = string.Empty;
          if (sqlDataReader.HasRows)
          {
            sqlDataReader.Read();
            empty = sqlDataReader.GetString(0);
          }
          sqlDataReader.Close();
          return empty;
        }
      }
    }

    private string getFieldValue_Oracle(RoadFlow.Data.Model.DBConnection conn, string table, string field, System.Collections.Generic.Dictionary<string, string> pkFieldValue)
    {
      using (OracleConnection conn1 = new OracleConnection(conn.ConnectionString))
      {
        try
        {
          conn1.Open();
        }
        catch (OracleException ex)
        {
          Log.Add((Exception) ex);
          return "";
        }
        List<string> stringList = new List<string>();
        StringBuilder stringBuilder = new StringBuilder();
        stringBuilder.AppendFormat("select {0} from {1} where 1=1", (object) field, (object) table);
        foreach (KeyValuePair<string, string> keyValuePair in pkFieldValue)
          stringBuilder.AppendFormat(" and {0}='{1}'", (object) keyValuePair.Key, (object) keyValuePair.Value);
        using (OracleCommand oracleCommand = new OracleCommand(stringBuilder.ToString(), conn1))
        {
          OracleDataReader oracleDataReader = oracleCommand.ExecuteReader();
          string empty = string.Empty;
          if (oracleDataReader.HasRows)
          {
            oracleDataReader.Read();
            empty = oracleDataReader.GetString(0);
          }
          oracleDataReader.Close();
          return empty;
        }
      }
    }

    private string getFieldValue_MySql(RoadFlow.Data.Model.DBConnection conn, string table, string field, System.Collections.Generic.Dictionary<string, string> pkFieldValue)
    {
      using (MySqlConnection connection = new MySqlConnection(conn.ConnectionString))
      {
        try
        {
          connection.Open();
        }
        catch (MySqlException ex)
        {
          Log.Add((Exception) ex);
          return "";
        }
        List<string> stringList = new List<string>();
        StringBuilder stringBuilder = new StringBuilder();
        stringBuilder.AppendFormat("select {0} from {1} where 1=1", (object) field, (object) table);
        foreach (KeyValuePair<string, string> keyValuePair in pkFieldValue)
          stringBuilder.AppendFormat(" and {0}='{1}'", (object) keyValuePair.Key, (object) keyValuePair.Value);
        using (MySqlCommand mySqlCommand = new MySqlCommand(stringBuilder.ToString(), connection))
        {
          MySqlDataReader mySqlDataReader = mySqlCommand.ExecuteReader();
          string empty = string.Empty;
          if (mySqlDataReader.HasRows)
          {
            mySqlDataReader.Read();
            empty = mySqlDataReader.GetString(0);
          }
          mySqlDataReader.Close();
          return empty;
        }
      }
    }

    private string getFieldValue_SqlServer(RoadFlow.Data.Model.DBConnection conn, string table, string field, string pkField, string pkFieldValue)
    {
      string str = "";
      using (SqlConnection selectConnection = new SqlConnection(conn.ConnectionString))
      {
        try
        {
          selectConnection.Open();
        }
        catch (SqlException ex)
        {
          Log.Add((Exception) ex);
          return "";
        }
        using (SqlDataAdapter sqlDataAdapter = new SqlDataAdapter(string.Format("SELECT {0} FROM {1} WHERE {2} = '{3}'", (object) field, (object) table, (object) pkField, (object) pkFieldValue), selectConnection))
        {
          try
          {
            DataTable dataTable = new DataTable();
            sqlDataAdapter.Fill(dataTable);
            if (dataTable.Rows.Count > 0)
              str = dataTable.Rows[0][0].ToString();
          }
          catch (SqlException ex)
          {
            Log.Add((Exception) ex);
          }
          return str;
        }
      }
    }

    private string getFieldValue_Oracle(RoadFlow.Data.Model.DBConnection conn, string table, string field, string pkField, string pkFieldValue)
    {
      string str = "";
      using (OracleConnection selectConnection = new OracleConnection(conn.ConnectionString))
      {
        try
        {
          selectConnection.Open();
        }
        catch (OracleException ex)
        {
          Log.Add((Exception) ex);
          return "";
        }
        using (OracleDataAdapter oracleDataAdapter = new OracleDataAdapter(string.Format("SELECT {0} FROM {1} WHERE {2} = '{3}'", (object) field, (object) table, (object) pkField, (object) pkFieldValue), selectConnection))
        {
          try
          {
            DataTable dataTable = new DataTable();
            oracleDataAdapter.Fill(dataTable);
            if (dataTable.Rows.Count > 0)
              str = dataTable.Rows[0][0].ToString();
          }
          catch (OracleException ex)
          {
            Log.Add((Exception) ex);
          }
          return str;
        }
      }
    }

    private string getFieldValue_MySql(RoadFlow.Data.Model.DBConnection conn, string table, string field, string pkField, string pkFieldValue)
    {
      string str = "";
      using (MySqlConnection connection = new MySqlConnection(conn.ConnectionString))
      {
        try
        {
          connection.Open();
        }
        catch (MySqlException ex)
        {
          Log.Add((Exception) ex);
          return "";
        }
        using (MySqlDataAdapter mySqlDataAdapter = new MySqlDataAdapter(string.Format("SELECT {0} FROM {1} WHERE {2} = '{3}'", (object) field, (object) table, (object) pkField, (object) pkFieldValue), connection))
        {
          try
          {
            DataTable dataTable = new DataTable();
            mySqlDataAdapter.Fill(dataTable);
            if (dataTable.Rows.Count > 0)
              str = dataTable.Rows[0][0].ToString();
          }
          catch (MySqlException ex)
          {
            Log.Add((Exception) ex);
          }
          return str;
        }
      }
    }

    public IDbConnection GetConnection(RoadFlow.Data.Model.DBConnection dbconn)
    {
      if (dbconn == null || dbconn.Type.IsNullOrEmpty() || dbconn.ConnectionString.IsNullOrEmpty())
        return (IDbConnection) null;
      IDbConnection dbConnection = (IDbConnection) null;
      try
      {
        string type = dbconn.Type;
        if (!(type == "SqlServer"))
        {
          if (!(type == "Oracle"))
          {
            if (type == "MySql")
              dbConnection = (IDbConnection) new MySqlConnection(dbconn.ConnectionString);
          }
          else
            dbConnection = (IDbConnection) new OracleConnection(dbconn.ConnectionString);
        }
        else
          dbConnection = (IDbConnection) new SqlConnection(dbconn.ConnectionString);
      }
      catch (Exception ex)
      {
        Log.Add(ex);
      }
      return dbConnection;
    }

    public IDbDataAdapter GetDataAdapter(IDbConnection conn, string connType, string cmdText, IDataParameter[] parArray)
    {
      IDbDataAdapter dbDataAdapter = (IDbDataAdapter) null;
      if (!(connType == "SqlServer"))
      {
        if (!(connType == "Oracle"))
        {
          if (connType == "MySql")
          {
            MySqlCommand selectCommand = new MySqlCommand(cmdText, (MySqlConnection) conn);
            if (parArray != null && parArray.Length != 0)
              selectCommand.Parameters.AddRange((Array) parArray);
            dbDataAdapter = (IDbDataAdapter) new MySqlDataAdapter(selectCommand);
          }
        }
        else
        {
          OracleCommand selectCommand = new OracleCommand(cmdText, (OracleConnection) conn);
          if (parArray != null && parArray.Length != 0)
            selectCommand.Parameters.AddRange((Array) parArray);
          dbDataAdapter = (IDbDataAdapter) new OracleDataAdapter(selectCommand);
        }
      }
      else
      {
        using (SqlCommand selectCommand = new SqlCommand(cmdText, (SqlConnection) conn))
        {
          if (parArray != null && parArray.Length != 0)
            selectCommand.Parameters.AddRange((Array) parArray);
          dbDataAdapter = (IDbDataAdapter) new SqlDataAdapter(selectCommand);
        }
      }
      return dbDataAdapter;
    }

    public string GetSerialNumber(IDbConnection conn, string connType, string table, string field, JsonData serialNumberJson, out int maxNumber)
    {
      maxNumber = 0;
      if (serialNumberJson == null)
        return "";
      string str1 = serialNumberJson.ContainsKey("formatstring") ? serialNumberJson["formatstring"].ToString() : "";
      string str2 = serialNumberJson.ContainsKey("sqlwhere") ? serialNumberJson["sqlwhere"].ToString().UrlDecode() : "";
      int totalWidth = serialNumberJson.ContainsKey("length") ? serialNumberJson["length"].ToString().ToInt() : 0;
      string str3 = serialNumberJson.ContainsKey("maxfiled") ? serialNumberJson["maxfiled"].ToString() : "";
      string newString = string.Empty;
      if (!str2.IsNullOrEmpty())
      {
        str2.FilterWildcard(Users.CurrentUserID.ToString());
        if (!str2.Trim1().StartsWith("and", StringComparison.CurrentCultureIgnoreCase))
          str2 = "AND " + str2;
      }
      bool flag = str1.Contains("$serialnumber$", StringComparison.CurrentCultureIgnoreCase);
      string str4 = str1.FilterWildcard(Users.CurrentUserID.ToString());
      if (str3.IsNullOrEmpty())
      {
        string empty1 = string.Empty;
        string empty2 = string.Empty;
        string str5 = flag ? str4.Substring(str4.IndexOf("$serialnumber$")).Replace1("$serialnumber$", "") : "";
        string str6 = flag ? str4.Substring(0, str4.IndexOf("$serialnumber$")) : "";
        if (!(connType == "SqlServer"))
        {
          if (!(connType == "Oracle"))
          {
            if (connType == "MySql")
            {
              string str7;
              if (!flag)
                str7 = "IFNULL(MAX(RIGHT(" + field + "," + (object) totalWidth + ")),0)+1";
              else
                str7 = "IFNULL(MAX(REPLACE(REPLACE(" + field + ",'" + str5 + "',''),'" + str6 + "','')),0)+1";
              using (MySqlCommand mySqlCommand = new MySqlCommand("SELECT " + str7 + " FROM " + table + " WHERE 1=1 " + str2, (MySqlConnection) conn))
              {
                try
                {
                  newString = mySqlCommand.ExecuteScalar().ToString().PadLeft(totalWidth, '0');
                }
                catch
                {
                  newString = "1".PadLeft(totalWidth, '0');
                }
              }
            }
          }
          else
          {
            string str7;
            if (!flag)
              str7 = "NVL(MAX(CAST(SUBSTR(" + field + ",LENGTH(" + field + ")-" + (object) (totalWidth - 1) + "," + (object) totalWidth + ") as INT)),0)+1";
            else
              str7 = "NVL(MAX(CAST(REPLACE(REPLACE(" + field + ",'" + str5 + "',''),'" + str6 + "','') as INT)),0)+1";
            using (OracleCommand oracleCommand = new OracleCommand("SELECT " + str7 + " FROM " + table + " WHERE 1=1 " + str2, (OracleConnection) conn))
            {
              try
              {
                newString = oracleCommand.ExecuteScalar().ToString().PadLeft(totalWidth, '0');
              }
              catch
              {
                newString = "1".PadLeft(totalWidth, '0');
              }
            }
          }
        }
        else
        {
          string str7;
          if (!flag)
            str7 = "ISNULL(MAX(CAST(RIGHT(" + field + "," + (object) totalWidth + ") as INT)),0)+1";
          else
            str7 = "ISNULL(MAX(CAST(REPLACE(REPLACE(" + field + ",'" + str5 + "',''),'" + str6 + "','') as INT)),0)+1";
          using (SqlCommand sqlCommand = new SqlCommand("SELECT " + str7 + " FROM " + table + " WHERE 1=1 " + str2, (SqlConnection) conn))
          {
            try
            {
              newString = sqlCommand.ExecuteScalar().ToString().PadLeft(totalWidth, '0');
            }
            catch
            {
              newString = "1".PadLeft(totalWidth, '0');
            }
          }
        }
      }
      else
      {
        string empty = string.Empty;
        if (!(connType == "SqlServer"))
        {
          if (!(connType == "Oracle"))
          {
            if (connType == "MySql")
            {
              using (MySqlCommand mySqlCommand = new MySqlCommand("SELECT IFNULL(MAX(" + str3 + "),0) FROM " + table + " WHERE 1=1 " + str2, (MySqlConnection) conn))
              {
                try
                {
                  maxNumber = mySqlCommand.ExecuteScalar().ToString().ToInt(0) + 1;
                  newString = maxNumber.ToString().PadLeft(totalWidth, '0');
                }
                catch
                {
                  newString = "1".PadLeft(totalWidth, '0');
                }
              }
            }
          }
          else
          {
            using (OracleCommand oracleCommand = new OracleCommand("SELECT NVL(MAX(" + str3 + "),0) FROM " + table + " WHERE 1=1 " + str2, (OracleConnection) conn))
            {
              try
              {
                maxNumber = oracleCommand.ExecuteScalar().ToString().ToInt(0) + 1;
                newString = maxNumber.ToString().PadLeft(totalWidth, '0');
              }
              catch
              {
                newString = "1".PadLeft(totalWidth, '0');
              }
            }
          }
        }
        else
        {
          using (SqlCommand sqlCommand = new SqlCommand("SELECT ISNULL(MAX(" + str3 + "),0) FROM " + table + " WHERE 1=1 " + str2, (SqlConnection) conn))
          {
            try
            {
              maxNumber = sqlCommand.ExecuteScalar().ToString().ToInt(0) + 1;
              newString = maxNumber.ToString().PadLeft(totalWidth, '0');
            }
            catch
            {
              newString = "1".PadLeft(totalWidth, '0');
            }
          }
        }
      }
      return flag ? str4.Replace1("$serialnumber$", newString) : str4 + newString;
    }

    public bool TestSql(RoadFlow.Data.Model.DBConnection dbconn, string sql, bool replaceSql = true)
    {
      if (dbconn == null)
        return false;
      if (replaceSql)
        sql = sql.ReplaceSelectSql().FilterWildcard(Users.CurrentUserID.ToString());
      string lower = dbconn.Type.ToLower();
      if (!(lower == "sqlserver"))
      {
        if (!(lower == "oracle"))
        {
          if (!(lower == "mysql"))
            return false;
          using (MySqlConnection connection = new MySqlConnection(dbconn.ConnectionString))
          {
            try
            {
              connection.Open();
            }
            catch (MySqlException ex)
            {
              Log.Add((Exception) ex);
              return false;
            }
            using (MySqlCommand mySqlCommand = new MySqlCommand(sql, connection))
            {
              try
              {
                mySqlCommand.ExecuteNonQuery();
                return true;
              }
              catch (MySqlException ex)
              {
                Log.Add("执行MySql语句发生了错误", ex.Message + ex.StackTrace, Log.Types.数据连接, sql, "", (RoadFlow.Data.Model.Users) null);
                return false;
              }
            }
          }
        }
        else
        {
          using (OracleConnection conn = new OracleConnection(dbconn.ConnectionString))
          {
            try
            {
              conn.Open();
            }
            catch (OracleException ex)
            {
              Log.Add((Exception) ex);
              return false;
            }
            using (OracleCommand oracleCommand = new OracleCommand(sql, conn))
            {
              try
              {
                oracleCommand.ExecuteNonQuery();
                return true;
              }
              catch (OracleException ex)
              {
                Log.Add("执行Oracle语句发生了错误", ex.Message + ex.StackTrace, Log.Types.数据连接, sql, "", (RoadFlow.Data.Model.Users) null);
                return false;
              }
            }
          }
        }
      }
      else
      {
        using (SqlConnection connection = new SqlConnection(dbconn.ConnectionString))
        {
          try
          {
            connection.Open();
          }
          catch (SqlException ex)
          {
            Log.Add((Exception) ex);
            return false;
          }
          using (SqlCommand sqlCommand = new SqlCommand(sql, connection))
          {
            try
            {
              sqlCommand.ExecuteNonQuery();
              return true;
            }
            catch (SqlException ex)
            {
              Log.Add("执行SqlServer语句发生了错误", ex.Message + ex.StackTrace, Log.Types.数据连接, sql, "", (RoadFlow.Data.Model.Users) null);
              return false;
            }
          }
        }
      }
    }

    public bool TestSql(RoadFlow.Data.Model.DBConnection dbconn, string sql, out string msg, bool replaceSql = true)
    {
      msg = "";
      if (dbconn == null)
        return false;
      if (replaceSql)
        sql = sql.ReplaceSelectSql().FilterWildcard(Users.CurrentUserID.ToString());
      string lower = dbconn.Type.ToLower();
      if (!(lower == "sqlserver"))
      {
        if (!(lower == "oracle"))
        {
          if (!(lower == "mysql"))
            return false;
          using (MySqlConnection connection = new MySqlConnection(dbconn.ConnectionString))
          {
            try
            {
              connection.Open();
            }
            catch (MySqlException ex)
            {
              Log.Add((Exception) ex);
              return false;
            }
            using (MySqlCommand mySqlCommand = new MySqlCommand(sql, connection))
            {
              try
              {
                mySqlCommand.ExecuteNonQuery();
                return true;
              }
              catch (MySqlException ex)
              {
                msg = ex.Message;
                Log.Add("执行MySql语句发生了错误", ex.Message + ex.StackTrace, Log.Types.数据连接, sql, "", (RoadFlow.Data.Model.Users) null);
                return false;
              }
            }
          }
        }
        else
        {
          using (OracleConnection conn = new OracleConnection(dbconn.ConnectionString))
          {
            try
            {
              conn.Open();
            }
            catch (OracleException ex)
            {
              Log.Add((Exception) ex);
              return false;
            }
            using (OracleCommand oracleCommand = new OracleCommand(sql, conn))
            {
              try
              {
                oracleCommand.ExecuteNonQuery();
                return true;
              }
              catch (OracleException ex)
              {
                msg = ex.Message;
                Log.Add("执行Oracle语句发生了错误", ex.Message + ex.StackTrace, Log.Types.数据连接, sql, "", (RoadFlow.Data.Model.Users) null);
                return false;
              }
            }
          }
        }
      }
      else
      {
        using (SqlConnection connection = new SqlConnection(dbconn.ConnectionString))
        {
          try
          {
            connection.Open();
          }
          catch (SqlException ex)
          {
            Log.Add((Exception) ex);
            return false;
          }
          using (SqlCommand sqlCommand = new SqlCommand(sql, connection))
          {
            try
            {
              sqlCommand.ExecuteNonQuery();
              return true;
            }
            catch (SqlException ex)
            {
              msg = ex.Message;
              Log.Add("执行SqlServer语句发生了错误", ex.Message + ex.StackTrace, Log.Types.数据连接, sql, "", (RoadFlow.Data.Model.Users) null);
              return false;
            }
          }
        }
      }
    }

    public DataTable GetDataTable(string dbconn, string table, string field, string fieldValue, string sortString = "")
    {
      if (dbconn.IsNullOrEmpty() || table.IsNullOrEmpty() || (field.IsNullOrEmpty() || fieldValue.IsNullOrEmpty()))
        return new DataTable();
      string str = sortString.IsNullOrEmpty() ? field : sortString;
      RoadFlow.Data.Model.DBConnection dbconn1 = this.Get(dbconn.ToGuid(), true);
      if (dbconn1 == null)
        return new DataTable();
      if (dbconn1.Type == "SqlServer")
      {
        string sql = "SELECT * FROM " + table + " WHERE " + field + " = @" + field + " ORDER BY " + str;
        IDataParameter[] parameterArray = (IDataParameter[]) new SqlParameter[1]{ new SqlParameter("@" + field, (object) fieldValue) };
        return this.GetDataTable(dbconn1, sql, parameterArray);
      }
      if (dbconn1.Type == "Oracle")
      {
        string sql = "SELECT * FROM " + table + " WHERE " + field + " = :" + field + " ORDER BY " + str;
        IDataParameter[] parameterArray = (IDataParameter[]) new OracleParameter[1]{ new OracleParameter(":" + field, (object) fieldValue) };
        return this.GetDataTable(dbconn1, sql, parameterArray);
      }
      if (!(dbconn1.Type == "MySql"))
        return new DataTable();
      string sql1 = "SELECT * FROM " + table + " WHERE " + field + " = @" + field + " ORDER BY " + str;
      IDataParameter[] parameterArray1 = (IDataParameter[]) new MySqlParameter[1]{ new MySqlParameter("@" + field, (object) fieldValue) };
      return this.GetDataTable(dbconn1, sql1, parameterArray1);
    }

    public DataTable GetDataTable(RoadFlow.Data.Model.DBConnection dbconn, string sql, IDataParameter[] parameterArray = null)
    {
      if (dbconn == null || dbconn.Type.IsNullOrEmpty() || dbconn.ConnectionString.IsNullOrEmpty())
        return (DataTable) null;
      DataTable dataTable = new DataTable();
      string type = dbconn.Type;
      if (!(type == "SqlServer"))
      {
        if (!(type == "Oracle"))
        {
          if (type == "MySql")
          {
            using (MySqlConnection connection = new MySqlConnection(dbconn.ConnectionString))
            {
              try
              {
                connection.Open();
                using (MySqlCommand selectCommand = new MySqlCommand(sql, connection))
                {
                  if (parameterArray != null && parameterArray.Length != 0)
                    selectCommand.Parameters.AddRange((Array) parameterArray);
                  using (MySqlDataAdapter mySqlDataAdapter = new MySqlDataAdapter(selectCommand))
                  {
                    mySqlDataAdapter.Fill(dataTable);
                    selectCommand.Parameters.Clear();
                  }
                }
              }
              catch (MySqlException ex)
              {
                Log.Add("获取DataTable发生了错误", ex.Message + ex.StackTrace + (object) ex.TargetSite, Log.Types.数据连接, sql, "", (RoadFlow.Data.Model.Users) null);
              }
            }
          }
        }
        else
        {
          using (OracleConnection conn = new OracleConnection(dbconn.ConnectionString))
          {
            try
            {
              conn.Open();
              using (OracleCommand selectCommand = new OracleCommand(sql, conn))
              {
                if (parameterArray != null && parameterArray.Length != 0)
                  selectCommand.Parameters.AddRange((Array) parameterArray);
                using (OracleDataAdapter oracleDataAdapter = new OracleDataAdapter(selectCommand))
                {
                  oracleDataAdapter.Fill(dataTable);
                  selectCommand.Parameters.Clear();
                }
              }
            }
            catch (OracleException ex)
            {
              Log.Add("获取DataTable发生了错误", ex.Message + ex.StackTrace + (object) ex.TargetSite, Log.Types.数据连接, sql, "", (RoadFlow.Data.Model.Users) null);
            }
          }
        }
      }
      else
      {
        using (SqlConnection connection = new SqlConnection(dbconn.ConnectionString))
        {
          try
          {
            connection.Open();
            using (SqlCommand selectCommand = new SqlCommand(sql, connection))
            {
              if (parameterArray != null && parameterArray.Length != 0)
                selectCommand.Parameters.AddRange((SqlParameter[]) parameterArray);
              using (SqlDataAdapter sqlDataAdapter = new SqlDataAdapter(selectCommand))
              {
                sqlDataAdapter.Fill(dataTable);
                selectCommand.Parameters.Clear();
              }
            }
          }
          catch (SqlException ex)
          {
            Log.Add("获取DataTable发生了错误", ex.Message + ex.StackTrace + (object) ex.TargetSite, Log.Types.数据连接, sql, "", (RoadFlow.Data.Model.Users) null);
          }
        }
      }
      return dataTable;
    }

    public DataTable GetDataTable(Guid connID, string sql, IDataParameter[] param = null)
    {
      RoadFlow.Data.Model.DBConnection dbConnection = this.Get(connID, true);
      if (dbConnection == null)
        return new DataTable();
      string str = "Table_" + Guid.NewGuid().ToString("N");
      string lower = dbConnection.Type.ToLower();
      if (!(lower == "sqlserver"))
      {
        if (!(lower == "oracle"))
        {
          if (lower == "mysql")
          {
            using (MySqlConnection connection = new MySqlConnection(dbConnection.ConnectionString))
            {
              try
              {
                connection.Open();
                using (MySqlCommand selectCommand = new MySqlCommand(sql, connection))
                {
                  if (param != null && param.Length != 0)
                  {
                    foreach (IDbDataParameter dbDataParameter in param)
                      selectCommand.Parameters.Add(new MySqlParameter(dbDataParameter.ParameterName, dbDataParameter.Value));
                  }
                  using (MySqlDataAdapter mySqlDataAdapter = new MySqlDataAdapter(selectCommand))
                  {
                    DataTable dataTable = new DataTable();
                    dataTable.TableName = str;
                    mySqlDataAdapter.Fill(dataTable);
                    selectCommand.Parameters.Clear();
                    return dataTable;
                  }
                }
              }
              catch (MySqlException ex)
              {
                Log.Add((Exception) ex);
              }
              finally
              {
                connection.Close();
                connection.Dispose();
              }
            }
          }
        }
        else
        {
          using (OracleConnection conn = new OracleConnection(dbConnection.ConnectionString))
          {
            try
            {
              conn.Open();
              using (OracleCommand selectCommand = new OracleCommand(sql, conn))
              {
                if (param != null && param.Length != 0)
                {
                  foreach (IDbDataParameter dbDataParameter in param)
                    selectCommand.Parameters.Add(new OracleParameter(dbDataParameter.ParameterName, dbDataParameter.Value));
                }
                using (OracleDataAdapter oracleDataAdapter = new OracleDataAdapter(selectCommand))
                {
                  DataTable dataTable = new DataTable();
                  dataTable.TableName = str;
                  oracleDataAdapter.Fill(dataTable);
                  selectCommand.Parameters.Clear();
                  return dataTable;
                }
              }
            }
            catch (OracleException ex)
            {
              Log.Add((Exception) ex);
            }
            finally
            {
              conn.Close();
              conn.Dispose();
            }
          }
        }
      }
      else
      {
        using (SqlConnection connection = new SqlConnection(dbConnection.ConnectionString))
        {
          try
          {
            connection.Open();
            using (SqlCommand selectCommand = new SqlCommand(sql, connection))
            {
              if (param != null && param.Length != 0)
              {
                foreach (IDbDataParameter dbDataParameter in param)
                  selectCommand.Parameters.Add(new SqlParameter(dbDataParameter.ParameterName, dbDataParameter.Value));
              }
              using (SqlDataAdapter sqlDataAdapter = new SqlDataAdapter(selectCommand))
              {
                DataTable dataTable = new DataTable();
                dataTable.TableName = str;
                sqlDataAdapter.Fill(dataTable);
                selectCommand.Parameters.Clear();
                return dataTable;
              }
            }
          }
          catch (SqlException ex)
          {
            Log.Add((Exception) ex);
          }
          finally
          {
            connection.Close();
            connection.Dispose();
          }
        }
      }
      return new DataTable();
    }

    public List<string> GetFieldsBySQL(Guid connID, string sql)
    {
      RoadFlow.Data.Model.DBConnection dbConnection = this.Get(connID, true);
      if (dbConnection == null)
        return new List<string>();
      List<string> stringList = new List<string>();
      string type = dbConnection.Type;
      if (!(type == "SqlServer"))
      {
        if (!(type == "Oracle"))
        {
          if (type == "MySql")
          {
            using (MySqlConnection connection = new MySqlConnection(dbConnection.ConnectionString))
            {
              connection.Open();
              using (MySqlDataAdapter mySqlDataAdapter = new MySqlDataAdapter(sql.FilterWildcard("").ReplaceSelectSql(), connection))
              {
                DataTable dataTable = new DataTable();
                mySqlDataAdapter.FillSchema(dataTable, SchemaType.Source);
                foreach (DataColumn column in (InternalDataCollectionBase) dataTable.Columns)
                  stringList.Add(column.ColumnName);
              }
            }
          }
        }
        else
        {
          using (OracleConnection selectConnection = new OracleConnection(dbConnection.ConnectionString))
          {
            selectConnection.Open();
            using (OracleDataAdapter oracleDataAdapter = new OracleDataAdapter(sql.FilterWildcard("").ReplaceSelectSql(), selectConnection))
            {
              DataTable dataTable = new DataTable();
              oracleDataAdapter.FillSchema(dataTable, SchemaType.Source);
              foreach (DataColumn column in (InternalDataCollectionBase) dataTable.Columns)
                stringList.Add(column.ColumnName);
            }
          }
        }
      }
      else
      {
        using (SqlConnection selectConnection = new SqlConnection(dbConnection.ConnectionString))
        {
          selectConnection.Open();
          using (SqlDataAdapter sqlDataAdapter = new SqlDataAdapter(sql.FilterWildcard("").ReplaceSelectSql(), selectConnection))
          {
            DataTable dataTable = new DataTable();
            sqlDataAdapter.FillSchema(dataTable, SchemaType.Source);
            foreach (DataColumn column in (InternalDataCollectionBase) dataTable.Columns)
              stringList.Add(column.ColumnName);
          }
        }
      }
      return stringList;
    }

    public DataTable GetTableSchema(IDbConnection conn, string tableName, string dbType)
    {
      DataTable dataTable1 = new DataTable();
      if (!(dbType == "SqlServer"))
      {
        if (!(dbType == "Oracle"))
        {
          if (dbType == "MySql")
          {
            DataTable dataTable2 = new DataTable();
            new MySqlDataAdapter("show full fields from `" + tableName + "`", (MySqlConnection) conn).Fill(dataTable2);
            dataTable1.Columns.Add("f_name", "".GetType());
            dataTable1.Columns.Add("t_name", "".GetType());
            dataTable1.Columns.Add("length", "".GetType());
            dataTable1.Columns.Add("scale", 1.GetType());
            dataTable1.Columns.Add("is_null", 1.GetType());
            dataTable1.Columns.Add("cdefault", 1.GetType());
            dataTable1.Columns.Add("isidentity", 1.GetType());
            dataTable1.Columns.Add("defaultvalue", "".GetType());
            foreach (DataRow row1 in (InternalDataCollectionBase) dataTable2.Rows)
            {
              string str1 = row1["Type"].ToString();
              string str2 = row1["Type"].ToString();
              string str3 = "";
              if (str1.IndexOf("(") > 0)
              {
                str1 = str1.Substring(0, str1.IndexOf("("));
                try
                {
                  str3 = str2.Substring(str2.IndexOf("(") + 1, str2.IndexOf(")") - str2.IndexOf("(") - 1);
                }
                catch
                {
                  str3 = "";
                }
              }
              DataRow row2 = dataTable1.NewRow();
              row2["f_name"] = (object) row1["Field"].ToString();
              row2["t_name"] = (object) str1;
              row2["length"] = (object) str3;
              row2["scale"] = (object) 0;
              row2["is_null"] = (object) ("YES" == row1["Null"].ToString());
              row2["cdefault"] = (object) (row1["Default"].ToString().IsNullOrEmpty() ? 1 : 0);
              row2["isidentity"] = (object) ("auto_increment" == row1["Extra"].ToString());
              row2["defaultvalue"] = (object) row1["Default"].ToString();
              dataTable1.Rows.Add(row2);
            }
          }
        }
        else
          new OracleDataAdapter(string.Format("SELECT COLUMN_NAME as f_name,\r\n                    DATA_TYPE as t_name,\r\n                    CHAR_LENGTH AS length,\r\n                    (DATA_PRECISION||','||DATA_SCALE) AS scale,\r\n                    CASE NULLABLE WHEN 'Y' THEN 1 WHEN 'N' THEN 0 END AS is_null,\r\n                    DATA_DEFAULT AS cdefault,\r\n                    0 as isidentity,DATA_DEFAULT AS defaultvalue FROM user_tab_columns WHERE UPPER(TABLE_NAME)=UPPER('{0}') ORDER BY COLUMN_ID", (object) tableName), (OracleConnection) conn).Fill(dataTable1);
      }
      else
        new SqlDataAdapter(string.Format("select a.name as f_name,b.name as t_name,a.prec as [length],a.scale,a.isnullable as is_null, a.cdefault as cdefault,COLUMNPROPERTY( OBJECT_ID('{0}'),a.name,'IsIdentity') as isidentity, \r\n(select top 1 text from sysobjects d inner join syscolumns e on e.id=d.id inner join syscomments f on f.id=e.cdefault \r\nwhere d.name='{0}' and e.name=a.name) as defaultvalue from \r\n                    sys.syscolumns a inner join sys.types b on b.user_type_id=a.xtype \r\n                    where object_id('{0}')=id order by a.colid", (object) tableName), (SqlConnection) conn).Fill(dataTable1);
      return dataTable1;
    }

    public object GetDbDefaultValue_SqlServer(string text)
    {
      if (text.IsNullOrEmpty())
        return (object) null;
      object obj = (object) text;
      if (text.StartsWith("(("))
        obj = (object) text.Replace1("((", "").Replace1("))", "");
      else if (text.StartsWith("('"))
      {
        obj = (object) text.Replace1("('", "").Replace1("')", "");
      }
      else
      {
        string lower = text.ToLower();
        if (!(lower == "(getdate())"))
        {
          if (lower == "(newid())")
            obj = (object) Guid.NewGuid();
        }
        else
          obj = (object) DateTimeNew.Now;
      }
      return obj;
    }

    public object GetDbDefaultValue_Oracle(string text)
    {
      if (text.IsNullOrEmpty())
        return (object) null;
      object obj = (object) text;
      if (text.StartsWith("'"))
        obj = (object) text.Replace1("'", "");
      else if (text.ToLower() == "sysdate")
        obj = (object) DateTimeNew.Now;
      return obj;
    }

    public object GetDbDefaultValue_MySql(string text)
    {
      if (text.IsNullOrEmpty())
        return (object) null;
      object obj = (object) text;
      if (text.ToUpper() == "CURRENT_TIMESTAMP")
        obj = (object) DateTimeNew.Now;
      return obj;
    }

    public void UpdateFieldValue(Guid connID, string table, string field, string value, string where)
    {
      RoadFlow.Data.Model.DBConnection dbconn = this.Get(connID, true);
      if (dbconn == null)
        return;
      string type = dbconn.Type;
      if (!(type == "SqlServer"))
      {
        if (!(type == "Oracle"))
        {
          if (!(type == "MySql"))
            return;
          using (IDbConnection connection1 = this.GetConnection(dbconn))
          {
            try
            {
              connection1.Open();
            }
            catch (MySqlException ex)
            {
              Log.Add((Exception) ex);
            }
            string cmdText = string.Format("UPDATE {0} SET {1}=@value WHERE {2}", (object) table, (object) field, (object) where);
            MySqlParameter mySqlParameter = new MySqlParameter("@value", (object) value);
            MySqlConnection connection2 = (MySqlConnection) connection1;
            using (MySqlCommand mySqlCommand = new MySqlCommand(cmdText, connection2))
            {
              mySqlCommand.Parameters.Add(mySqlParameter);
              try
              {
                mySqlCommand.ExecuteNonQuery();
              }
              catch (MySqlException ex)
              {
                Log.Add((Exception) ex);
              }
            }
          }
        }
        else
        {
          using (IDbConnection connection = this.GetConnection(dbconn))
          {
            try
            {
              connection.Open();
            }
            catch (OracleException ex)
            {
              Log.Add((Exception) ex);
            }
            string cmdText = string.Format("UPDATE {0} SET {1}=:value WHERE {2}", (object) table, (object) field, (object) where);
            OracleParameter oracleParameter = new OracleParameter(":value", (object) value);
            OracleConnection conn = (OracleConnection) connection;
            using (OracleCommand oracleCommand = new OracleCommand(cmdText, conn))
            {
              oracleCommand.Parameters.Add(oracleParameter);
              try
              {
                oracleCommand.ExecuteNonQuery();
              }
              catch (OracleException ex)
              {
                Log.Add((Exception) ex);
              }
            }
          }
        }
      }
      else
      {
        using (IDbConnection connection1 = this.GetConnection(dbconn))
        {
          try
          {
            connection1.Open();
          }
          catch (SqlException ex)
          {
            Log.Add((Exception) ex);
          }
          string cmdText = string.Format("UPDATE {0} SET {1}=@value WHERE {2}", (object) table, (object) field, (object) where);
          SqlParameter sqlParameter = new SqlParameter("@value", (object) value);
          SqlConnection connection2 = (SqlConnection) connection1;
          using (SqlCommand sqlCommand = new SqlCommand(cmdText, connection2))
          {
            sqlCommand.Parameters.Add(sqlParameter);
            try
            {
              sqlCommand.ExecuteNonQuery();
            }
            catch (SqlException ex)
            {
              Log.Add((Exception) ex);
            }
          }
        }
      }
    }

    public int DeleteData(Guid connID, string table, string pkFiled, string pkValue)
    {
      int num = 0;
      RoadFlow.Data.Model.DBConnection dbconn = this.Get(connID, true);
      if (dbconn == null)
        return num;
      string type = dbconn.Type;
      if (!(type == "SqlServer"))
      {
        if (!(type == "Oracle"))
        {
          if (type == "MySql")
          {
            using (IDbConnection connection1 = this.GetConnection(dbconn))
            {
              try
              {
                connection1.Open();
              }
              catch (MySqlException ex)
              {
                Log.Add((Exception) ex);
              }
              string cmdText = string.Format("DELETE FROM {0} WHERE {1}=@{1}", (object) table, (object) pkFiled);
              MySqlParameter mySqlParameter = new MySqlParameter("@" + pkFiled, (object) pkValue);
              MySqlConnection connection2 = (MySqlConnection) connection1;
              using (MySqlCommand mySqlCommand = new MySqlCommand(cmdText, connection2))
              {
                mySqlCommand.Parameters.Add(mySqlParameter);
                try
                {
                  num = mySqlCommand.ExecuteNonQuery();
                }
                catch (MySqlException ex)
                {
                  Log.Add((Exception) ex);
                }
              }
            }
          }
        }
        else
        {
          using (IDbConnection connection = this.GetConnection(dbconn))
          {
            try
            {
              connection.Open();
            }
            catch (OracleException ex)
            {
              Log.Add((Exception) ex);
            }
            string cmdText = string.Format("DELETE FROM {0} WHERE {1}=:{1}", (object) table, (object) pkFiled);
            OracleParameter oracleParameter = new OracleParameter(":" + pkFiled, (object) pkValue);
            OracleConnection conn = (OracleConnection) connection;
            using (OracleCommand oracleCommand = new OracleCommand(cmdText, conn))
            {
              oracleCommand.Parameters.Add(oracleParameter);
              try
              {
                num = oracleCommand.ExecuteNonQuery();
              }
              catch (OracleException ex)
              {
                Log.Add((Exception) ex);
              }
            }
          }
        }
      }
      else
      {
        using (IDbConnection connection1 = this.GetConnection(dbconn))
        {
          try
          {
            connection1.Open();
          }
          catch (SqlException ex)
          {
            Log.Add((Exception) ex);
          }
          string cmdText = string.Format("DELETE FROM {0} WHERE {1}=@{1}", (object) table, (object) pkFiled);
          SqlParameter sqlParameter = new SqlParameter("@" + pkFiled, (object) pkValue);
          SqlConnection connection2 = (SqlConnection) connection1;
          using (SqlCommand sqlCommand = new SqlCommand(cmdText, connection2))
          {
            sqlCommand.Parameters.Add(sqlParameter);
            try
            {
              num = sqlCommand.ExecuteNonQuery();
            }
            catch (SqlException ex)
            {
              Log.Add((Exception) ex);
            }
          }
        }
      }
      return num;
    }

    public DataTable GetDataTable(RoadFlow.Data.Model.DBConnection dbconn, string sql, out string pager, string query = "", List<IDbDataParameter> parList = null, int pageSize = 0)
    {
      pager = "";
      if (dbconn == null)
        return (DataTable) null;
      string str = string.Empty;
      string type = dbconn.Type;
      if (!(type == "SqlServer"))
      {
        if (!(type == "Oracle"))
        {
          if (!(type == "MySql"))
            return (DataTable) null;
          using (MySqlConnection connection = new MySqlConnection(dbconn.ConnectionString))
          {
            try
            {
              connection.Open();
              List<MySqlParameter> mySqlParameterList = new List<MySqlParameter>();
              if (parList != null && parList.Count > 0)
              {
                foreach (IDbDataParameter par in parList)
                  mySqlParameterList.Add(new MySqlParameter(par.ParameterName, par.Value));
              }
              DataTable dataTable = new DataTable();
              if (-1 == pageSize)
              {
                using (MySqlCommand selectCommand = new MySqlCommand(sql, connection))
                {
                  if (mySqlParameterList != null && mySqlParameterList.Count > 0)
                    selectCommand.Parameters.AddRange((Array) mySqlParameterList.ToArray());
                  using (MySqlDataAdapter mySqlDataAdapter = new MySqlDataAdapter(selectCommand))
                  {
                    mySqlDataAdapter.Fill(dataTable);
                    return dataTable;
                  }
                }
              }
              else
              {
                pageSize = pageSize == 0 ? Tools.GetPageSize() : pageSize;
                int pageNumber = Tools.GetPageNumber();
                long count;
                str = new RoadFlow.Data.MySql.DBHelper(dbconn.ConnectionString).GetPaerSql(sql, pageSize, pageNumber, out count, mySqlParameterList.ToArray());
                pager = Tools.GetPagerHtml(count, pageSize, pageNumber, query);
                using (MySqlCommand selectCommand = new MySqlCommand(str, connection))
                {
                  if (mySqlParameterList != null && mySqlParameterList.Count > 0)
                    selectCommand.Parameters.AddRange((Array) mySqlParameterList.ToArray());
                  using (MySqlDataAdapter mySqlDataAdapter = new MySqlDataAdapter(selectCommand))
                  {
                    mySqlDataAdapter.Fill(dataTable);
                    return dataTable;
                  }
                }
              }
            }
            catch (MySqlException ex)
            {
              Log.Add(ex.Message, ex.StackTrace, Log.Types.系统错误, sql, str, (RoadFlow.Data.Model.Users) null);
              return (DataTable) null;
            }
          }
        }
        else
        {
          using (OracleConnection conn = new OracleConnection(dbconn.ConnectionString))
          {
            try
            {
              conn.Open();
              List<OracleParameter> oracleParameterList = new List<OracleParameter>();
              if (parList != null && parList.Count > 0)
              {
                foreach (IDbDataParameter par in parList)
                  oracleParameterList.Add(new OracleParameter(par.ParameterName, par.Value));
              }
              DataTable dataTable = new DataTable();
              if (-1 == pageSize)
              {
                using (OracleCommand selectCommand = new OracleCommand(sql, conn))
                {
                  if (oracleParameterList != null && oracleParameterList.Count > 0)
                    selectCommand.Parameters.AddRange((Array) oracleParameterList.ToArray());
                  using (OracleDataAdapter oracleDataAdapter = new OracleDataAdapter(selectCommand))
                  {
                    oracleDataAdapter.Fill(dataTable);
                    return dataTable;
                  }
                }
              }
              else
              {
                pageSize = pageSize == 0 ? Tools.GetPageSize() : pageSize;
                int pageNumber = Tools.GetPageNumber();
                long count;
                str = new RoadFlow.Data.ORACLE.DBHelper(dbconn.ConnectionString).GetPaerSql(sql, pageSize, pageNumber, out count, oracleParameterList.ToArray());
                pager = Tools.GetPagerHtml(count, pageSize, pageNumber, query);
                using (OracleCommand selectCommand = new OracleCommand(str, conn))
                {
                  if (oracleParameterList != null && oracleParameterList.Count > 0)
                    selectCommand.Parameters.AddRange((Array) oracleParameterList.ToArray());
                  using (OracleDataAdapter oracleDataAdapter = new OracleDataAdapter(selectCommand))
                  {
                    oracleDataAdapter.Fill(dataTable);
                    return dataTable;
                  }
                }
              }
            }
            catch (OracleException ex)
            {
              Log.Add(ex.Message, ex.StackTrace, Log.Types.系统错误, sql, str, (RoadFlow.Data.Model.Users) null);
              return (DataTable) null;
            }
          }
        }
      }
      else
      {
        using (SqlConnection connection = new SqlConnection(dbconn.ConnectionString))
        {
          try
          {
            connection.Open();
            List<SqlParameter> sqlParameterList = new List<SqlParameter>();
            if (parList != null && parList.Count > 0)
            {
              foreach (IDbDataParameter par in parList)
                sqlParameterList.Add(new SqlParameter(par.ParameterName, par.Value));
            }
            DataTable dataTable = new DataTable();
            int num;
            switch (pageSize)
            {
              case -1:
                using (SqlCommand selectCommand = new SqlCommand(sql, connection))
                {
                  if (sqlParameterList != null && sqlParameterList.Count > 0)
                    selectCommand.Parameters.AddRange(sqlParameterList.ToArray());
                  using (SqlDataAdapter sqlDataAdapter = new SqlDataAdapter(selectCommand))
                  {
                    sqlDataAdapter.Fill(dataTable);
                    return dataTable;
                  }
                }
              case 0:
                num = Tools.GetPageSize();
                break;
              default:
                num = pageSize;
                break;
            }
            pageSize = num;
            int pageNumber = Tools.GetPageNumber();
            long count;
            str = new RoadFlow.Data.MSSQL.DBHelper(dbconn.ConnectionString).GetPaerSql(sql, pageSize, pageNumber, out count, sqlParameterList.ToArray());
            pager = Tools.GetPagerHtml(count, pageSize, pageNumber, query);
            using (SqlCommand selectCommand = new SqlCommand(str, connection))
            {
              if (sqlParameterList != null && sqlParameterList.Count > 0)
                selectCommand.Parameters.AddRange(sqlParameterList.ToArray());
              using (SqlDataAdapter sqlDataAdapter = new SqlDataAdapter(selectCommand))
              {
                sqlDataAdapter.Fill(dataTable);
                return dataTable;
              }
            }
          }
          catch (SqlException ex)
          {
            Log.Add(ex.Message, ex.StackTrace, Log.Types.系统错误, sql, str, (RoadFlow.Data.Model.Users) null);
            return (DataTable) null;
          }
        }
      }
    }

    public string GetOptionsFromSql(RoadFlow.Data.Model.DBConnection conn, string sql, IDbDataParameter[] parList = null, string value = "")
    {
      DataTable dataTable = this.GetDataTable(conn, sql.ReplaceSelectSql().FilterWildcard(Users.CurrentUserID.ToString()), (IDataParameter[]) parList);
      StringBuilder stringBuilder = new StringBuilder();
      if (dataTable.Columns.Count == 0)
        return "";
      foreach (DataRow row in (InternalDataCollectionBase) dataTable.Rows)
      {
        string str1 = row[0].ToString();
        string str2 = dataTable.Columns.Count > 1 ? row[1].ToString() : str1;
        stringBuilder.AppendFormat("<option value=\"{0}\"{1}>{2}</option>", (object) str1, str1.Equals(value, StringComparison.CurrentCultureIgnoreCase) ? (object) " selected=\"selected\"" : (object) "", (object) str2);
      }
      return stringBuilder.ToString();
    }

    public string GetOptionsFromSql(Guid connID, string sql, IDbDataParameter[] parList = null, string value = "")
    {
      RoadFlow.Data.Model.DBConnection conn = this.Get(connID, true);
      if (conn == null)
        return "";
      return this.GetOptionsFromSql(conn, sql, parList, value);
    }

    public string GetDatabaseName(RoadFlow.Data.Model.DBConnection dbConn)
    {
      if (dbConn == null)
        return string.Empty;
      string str = string.Empty;
      IDbConnection connection = this.GetConnection(dbConn);
      if (connection != null)
        str = connection.Database;
      return str;
    }

    public List<string> GetPrimaryKey(RoadFlow.Data.Model.DBConnection conn, string table)
    {
      string lower = conn.Type.ToLower();
      if (lower == "sqlserver")
        return this.getPrimaryKey_SqlServer(conn, table);
      if (lower == "oracle")
        return this.getPrimaryKey_Oracle(conn, table);
      if (lower == "mysql")
        return this.getPrimaryKey_MySql(conn, table);
      return new List<string>();
    }

    private List<string> getPrimaryKey_SqlServer(RoadFlow.Data.Model.DBConnection conn, string table)
    {
      string sql = string.Format("select b.column_name\r\nfrom information_schema.table_constraints a\r\ninner join information_schema.constraint_column_usage b\r\non a.constraint_name = b.constraint_name\r\nwhere a.constraint_type = 'PRIMARY KEY' and a.table_name = '{0}'", (object) table);
      DataTable dataTable = this.GetDataTable(conn, sql, (IDataParameter[]) null);
      List<string> stringList = new List<string>();
      foreach (DataRow row in (InternalDataCollectionBase) dataTable.Rows)
        stringList.Add(row[0].ToString());
      return stringList;
    }

    private List<string> getPrimaryKey_Oracle(RoadFlow.Data.Model.DBConnection conn, string table)
    {
      string sql = string.Format("select b.column_name from user_constraints a, user_cons_columns b where a.constraint_name = b.constraint_name and a.constraint_type = 'P' and a.table_name = UPPER('{0}')", (object) table);
      DataTable dataTable = this.GetDataTable(conn, sql, (IDataParameter[]) null);
      List<string> stringList = new List<string>();
      foreach (DataRow row in (InternalDataCollectionBase) dataTable.Rows)
        stringList.Add(row[0].ToString());
      return stringList;
    }

    private List<string> getPrimaryKey_MySql(RoadFlow.Data.Model.DBConnection conn, string table)
    {
      string sql = string.Format("show full fields from `{0}`", (object) table);
      DataTable dataTable = this.GetDataTable(conn, sql, (IDataParameter[]) null);
      List<string> stringList = new List<string>();
      foreach (DataRow row in (InternalDataCollectionBase) dataTable.Rows)
      {
        if (row["key"].ToString().ToUpper() == "PRI")
          stringList.Add(row[0].ToString());
      }
      return stringList;
    }

    public string GetFieldDataTypeOptions(string value, string dbType)
    {
      string str = string.Empty;
      string lower = dbType.ToLower();
      if (!(lower == "sqlserver"))
      {
        if (!(lower == "oracle"))
        {
          if (lower == "mysql")
            str = this.getFieldDataTypeOptions_MySql(value);
        }
        else
          str = this.getFieldDataTypeOptions_Oracle(value);
      }
      else
        str = this.getFieldDataTypeOptions_SqlServer(value);
      return str;
    }

    private string getFieldDataTypeOptions_SqlServer(string value)
    {
      List<Tuple<string, string, string>> tupleList = new List<Tuple<string, string, string>>();
      tupleList.Add(new Tuple<string, string, string>("varchar", "英文字符串", "50"));
      tupleList.Add(new Tuple<string, string, string>("nvarchar", "中文字符串", "50"));
      tupleList.Add(new Tuple<string, string, string>("char", "字符", "10"));
      tupleList.Add(new Tuple<string, string, string>("datetime", "日期时间", ""));
      tupleList.Add(new Tuple<string, string, string>("text", "长文本", ""));
      tupleList.Add(new Tuple<string, string, string>("uniqueidentifier", "全局唯一ID", ""));
      tupleList.Add(new Tuple<string, string, string>("int", "整数", ""));
      tupleList.Add(new Tuple<string, string, string>("decimal", "小数", ""));
      tupleList.Add(new Tuple<string, string, string>("money", "货币", ""));
      tupleList.Add(new Tuple<string, string, string>("float", "浮点数", ""));
      StringBuilder stringBuilder = new StringBuilder();
      foreach (Tuple<string, string, string> tuple in tupleList)
        stringBuilder.Append("<option data-length=\"" + tuple.Item3 + "\" value=\"" + tuple.Item1 + "\"" + (tuple.Item1.Equals(value, StringComparison.CurrentCultureIgnoreCase) ? " selected=\"selected\"" : "") + ">" + tuple.Item2 + "</option>");
      return stringBuilder.ToString();
    }

    private string getFieldDataTypeOptions_Oracle(string value)
    {
      List<Tuple<string, string, string>> tupleList = new List<Tuple<string, string, string>>();
      tupleList.Add(new Tuple<string, string, string>("VARCHAR2", "英文字符串", "50"));
      tupleList.Add(new Tuple<string, string, string>("NVARCHAR2", "中文字符串", "50"));
      tupleList.Add(new Tuple<string, string, string>("CHAR", "字符", "10"));
      tupleList.Add(new Tuple<string, string, string>("DATE", "日期时间", ""));
      tupleList.Add(new Tuple<string, string, string>("CLOB", "长文本", ""));
      tupleList.Add(new Tuple<string, string, string>("NCLOB", "中文长文本", ""));
      tupleList.Add(new Tuple<string, string, string>("NUMBER", "数字", ""));
      tupleList.Add(new Tuple<string, string, string>("FLOAT", "浮点数", ""));
      StringBuilder stringBuilder = new StringBuilder();
      foreach (Tuple<string, string, string> tuple in tupleList)
        stringBuilder.Append("<option data-length=\"" + tuple.Item3 + "\" value=\"" + tuple.Item1 + "\"" + (tuple.Item1.Equals(value, StringComparison.CurrentCultureIgnoreCase) ? " selected=\"selected\"" : "") + ">" + tuple.Item2 + "</option>");
      return stringBuilder.ToString();
    }

    private string getFieldDataTypeOptions_MySql(string value)
    {
      List<Tuple<string, string, string>> tupleList = new List<Tuple<string, string, string>>();
      tupleList.Add(new Tuple<string, string, string>("varchar", "字符串", "255"));
      tupleList.Add(new Tuple<string, string, string>("char", "字符", "255"));
      tupleList.Add(new Tuple<string, string, string>("datetime", "日期时间", ""));
      tupleList.Add(new Tuple<string, string, string>("timestamp", "时间戳", ""));
      tupleList.Add(new Tuple<string, string, string>("text", "文本", ""));
      tupleList.Add(new Tuple<string, string, string>("longtext", "长文本", ""));
      tupleList.Add(new Tuple<string, string, string>("int", "整数", ""));
      tupleList.Add(new Tuple<string, string, string>("decimal", "小数", ""));
      tupleList.Add(new Tuple<string, string, string>("float", "浮点数", ""));
      StringBuilder stringBuilder = new StringBuilder();
      foreach (Tuple<string, string, string> tuple in tupleList)
        stringBuilder.Append("<option data-length=\"" + tuple.Item3 + "\" value=\"" + tuple.Item1 + "\"" + (tuple.Item1.Equals(value, StringComparison.CurrentCultureIgnoreCase) ? " selected=\"selected\"" : "") + ">" + tuple.Item2 + "</option>");
      return stringBuilder.ToString();
    }

    public List<string> GetConstraints(RoadFlow.Data.Model.DBConnection dbConn, string tableName)
    {
      List<string> stringList = new List<string>();
      string lower = dbConn.Type.ToLower();
      if (!(lower == "sqlserver"))
      {
        if (lower == "oracle" || lower == "mysql")
          ;
      }
      else
      {
        string sql = "select name from sysobjects where parent_obj=(select id from sysobjects where name='" + tableName + "' and type='U')";
        foreach (DataRow row in (InternalDataCollectionBase) this.GetDataTable(dbConn, sql, (IDataParameter[]) null).Rows)
          stringList.Add(row[0].ToString());
      }
      return stringList;
    }

    public bool CheckSql(string sql)
    {
      if (sql.Contains("delete", StringComparison.CurrentCultureIgnoreCase) || sql.Contains("drop", StringComparison.CurrentCultureIgnoreCase) || (sql.Contains("alter", StringComparison.CurrentCultureIgnoreCase) || sql.Contains("truncate", StringComparison.CurrentCultureIgnoreCase)))
      {
        foreach (string systemDataTable in Config.SystemDataTables)
        {
          string str1 = sql;
          char[] chArray = new char[1]{ ' ' };
          foreach (string str2 in str1.Split(chArray))
          {
            if (str2.Equals(systemDataTable, StringComparison.CurrentCultureIgnoreCase) || ("[" + str2 + "]").Equals("[" + systemDataTable + "]", StringComparison.CurrentCultureIgnoreCase))
              return false;
          }
        }
      }
      return true;
    }

    public string GetDefaultQuerySql(RoadFlow.Data.Model.DBConnection conn, string tableName)
    {
      string str = string.Empty;
      string lower = conn.Type.ToLower();
      if (!(lower == "sqlserver"))
      {
        if (!(lower == "mysql"))
        {
          if (lower == "oracle")
            str = "SELECT * FROM " + tableName + " WHERE ROWNUM BETWEEN 0 AND 50";
        }
        else
          str = "SELECT * FROM " + tableName + " LIMIT 0,50";
      }
      else
        str = "SELECT TOP 50 * FROM " + tableName;
      return str;
    }

    public int DataTableToDB(RoadFlow.Data.Model.DBConnection conn, DataTable dt)
    {
      int num = 0;
      string lower = conn.Type.ToLower();
      if (!(lower == "sqlserver"))
      {
        if (!(lower == "mysql"))
        {
          if (lower == "oracle")
            num = new RoadFlow.Data.ORACLE.DBHelper().DataTableToDB(dt);
        }
        else
          num = new RoadFlow.Data.MySql.DBHelper().DataTableToDB(dt);
      }
      else
        num = new RoadFlow.Data.MSSQL.DBHelper().DataTableToDB(dt);
      return num;
    }

    public string GetAllTableOptions(Guid connID, string value)
    {
      List<string> tables = this.GetTables(connID, 1);
      StringBuilder stringBuilder = new StringBuilder();
      foreach (string str in tables)
        stringBuilder.Append("<option value=\"" + str + "\"" + (str.Equals(value, StringComparison.CurrentCultureIgnoreCase) ? " selected=\"selected\"" : "") + ">" + str + "</option>");
      return stringBuilder.ToString();
    }

    public enum Types
    {
      SqlServer,
      Oracle,
    }

    public enum ConnTypes
    {
      SqlServer,
      Oracle,
      MySql,
    }
  }
}
