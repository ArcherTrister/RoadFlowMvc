// Decompiled with JetBrains decompiler
// Type: RoadFlow.Data.MSSQL.HastenLog
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
  public class HastenLog : IHastenLog
  {
    private DBHelper dbHelper = new DBHelper();

    public int Add(RoadFlow.Data.Model.HastenLog model)
    {
      string sql = "INSERT INTO HastenLog\r\n\t\t\t\t(ID,OthersParams,Users,Types,Contents,SendUser,SendUserName,SendTime) \r\n\t\t\t\tVALUES(@ID,@OthersParams,@Users,@Types,@Contents,@SendUser,@SendUserName,@SendTime)";
      SqlParameter[] sqlParameterArray = new SqlParameter[8];
      int index1 = 0;
      SqlParameter sqlParameter1 = new SqlParameter("@ID", SqlDbType.UniqueIdentifier, -1);
      sqlParameter1.Value = (object) model.ID;
      sqlParameterArray[index1] = sqlParameter1;
      int index2 = 1;
      SqlParameter sqlParameter2 = new SqlParameter("@OthersParams", SqlDbType.VarChar, 5000);
      sqlParameter2.Value = (object) model.OthersParams;
      sqlParameterArray[index2] = sqlParameter2;
      int index3 = 2;
      SqlParameter sqlParameter3 = new SqlParameter("@Users", SqlDbType.VarChar, 5000);
      sqlParameter3.Value = (object) model.Users;
      sqlParameterArray[index3] = sqlParameter3;
      int index4 = 3;
      SqlParameter sqlParameter4 = new SqlParameter("@Types", SqlDbType.VarChar, 500);
      sqlParameter4.Value = (object) model.Types;
      sqlParameterArray[index4] = sqlParameter4;
      int index5 = 4;
      SqlParameter sqlParameter5 = new SqlParameter("@Contents", SqlDbType.NVarChar, 1000);
      sqlParameter5.Value = (object) model.Contents;
      sqlParameterArray[index5] = sqlParameter5;
      int index6 = 5;
      SqlParameter sqlParameter6 = new SqlParameter("@SendUser", SqlDbType.UniqueIdentifier, -1);
      sqlParameter6.Value = (object) model.SendUser;
      sqlParameterArray[index6] = sqlParameter6;
      int index7 = 6;
      SqlParameter sqlParameter7 = new SqlParameter("@SendUserName", SqlDbType.NVarChar, 100);
      sqlParameter7.Value = (object) model.SendUserName;
      sqlParameterArray[index7] = sqlParameter7;
      int index8 = 7;
      SqlParameter sqlParameter8 = new SqlParameter("@SendTime", SqlDbType.DateTime, 8);
      sqlParameter8.Value = (object) model.SendTime;
      sqlParameterArray[index8] = sqlParameter8;
      SqlParameter[] parameter = sqlParameterArray;
      return this.dbHelper.Execute(sql, parameter, false);
    }

    public int Update(RoadFlow.Data.Model.HastenLog model)
    {
      string sql = "UPDATE HastenLog SET \r\n\t\t\t\tOthersParams=@OthersParams,Users=@Users,Types=@Types,Contents=@Contents,SendUser=@SendUser,SendUserName=@SendUserName,SendTime=@SendTime\r\n\t\t\t\tWHERE ID=@ID";
      SqlParameter[] sqlParameterArray = new SqlParameter[8];
      int index1 = 0;
      SqlParameter sqlParameter1 = new SqlParameter("@OthersParams", SqlDbType.VarChar, 5000);
      sqlParameter1.Value = (object) model.OthersParams;
      sqlParameterArray[index1] = sqlParameter1;
      int index2 = 1;
      SqlParameter sqlParameter2 = new SqlParameter("@Users", SqlDbType.VarChar, 5000);
      sqlParameter2.Value = (object) model.Users;
      sqlParameterArray[index2] = sqlParameter2;
      int index3 = 2;
      SqlParameter sqlParameter3 = new SqlParameter("@Types", SqlDbType.VarChar, 500);
      sqlParameter3.Value = (object) model.Types;
      sqlParameterArray[index3] = sqlParameter3;
      int index4 = 3;
      SqlParameter sqlParameter4 = new SqlParameter("@Contents", SqlDbType.NVarChar, 1000);
      sqlParameter4.Value = (object) model.Contents;
      sqlParameterArray[index4] = sqlParameter4;
      int index5 = 4;
      SqlParameter sqlParameter5 = new SqlParameter("@SendUser", SqlDbType.UniqueIdentifier, -1);
      sqlParameter5.Value = (object) model.SendUser;
      sqlParameterArray[index5] = sqlParameter5;
      int index6 = 5;
      SqlParameter sqlParameter6 = new SqlParameter("@SendUserName", SqlDbType.NVarChar, 100);
      sqlParameter6.Value = (object) model.SendUserName;
      sqlParameterArray[index6] = sqlParameter6;
      int index7 = 6;
      SqlParameter sqlParameter7 = new SqlParameter("@SendTime", SqlDbType.DateTime, 8);
      sqlParameter7.Value = (object) model.SendTime;
      sqlParameterArray[index7] = sqlParameter7;
      int index8 = 7;
      SqlParameter sqlParameter8 = new SqlParameter("@ID", SqlDbType.UniqueIdentifier, -1);
      sqlParameter8.Value = (object) model.ID;
      sqlParameterArray[index8] = sqlParameter8;
      SqlParameter[] parameter = sqlParameterArray;
      return this.dbHelper.Execute(sql, parameter, false);
    }

    public int Delete(Guid id)
    {
      string sql = "DELETE FROM HastenLog WHERE ID=@ID";
      SqlParameter[] sqlParameterArray = new SqlParameter[1];
      int index = 0;
      SqlParameter sqlParameter = new SqlParameter("@ID", SqlDbType.UniqueIdentifier);
      sqlParameter.Value = (object) id;
      sqlParameterArray[index] = sqlParameter;
      SqlParameter[] parameter = sqlParameterArray;
      return this.dbHelper.Execute(sql, parameter, false);
    }

    private List<RoadFlow.Data.Model.HastenLog> DataReaderToList(SqlDataReader dataReader)
    {
      List<RoadFlow.Data.Model.HastenLog> hastenLogList = new List<RoadFlow.Data.Model.HastenLog>();
      while (dataReader.Read())
        hastenLogList.Add(new RoadFlow.Data.Model.HastenLog()
        {
          ID = dataReader.GetGuid(0),
          OthersParams = dataReader.GetString(1),
          Users = dataReader.GetString(2),
          Types = dataReader.GetString(3),
          Contents = dataReader.GetString(4),
          SendUser = dataReader.GetGuid(5),
          SendUserName = dataReader.GetString(6),
          SendTime = dataReader.GetDateTime(7)
        });
      return hastenLogList;
    }

    public List<RoadFlow.Data.Model.HastenLog> GetAll()
    {
      SqlDataReader dataReader = this.dbHelper.GetDataReader("SELECT * FROM HastenLog");
      List<RoadFlow.Data.Model.HastenLog> list = this.DataReaderToList(dataReader);
      dataReader.Close();
      return list;
    }

    public long GetCount()
    {
      long result;
      if (!long.TryParse(this.dbHelper.GetFieldValue("SELECT COUNT(*) FROM HastenLog"), out result))
        return 0;
      return result;
    }

    public RoadFlow.Data.Model.HastenLog Get(Guid id)
    {
      string sql = "SELECT * FROM HastenLog WHERE ID=@ID";
      SqlParameter[] sqlParameterArray = new SqlParameter[1];
      int index = 0;
      SqlParameter sqlParameter = new SqlParameter("@ID", SqlDbType.UniqueIdentifier);
      sqlParameter.Value = (object) id;
      sqlParameterArray[index] = sqlParameter;
      SqlParameter[] parameter = sqlParameterArray;
      SqlDataReader dataReader = this.dbHelper.GetDataReader(sql, parameter);
      List<RoadFlow.Data.Model.HastenLog> list = this.DataReaderToList(dataReader);
      dataReader.Close();
      if (list.Count <= 0)
        return (RoadFlow.Data.Model.HastenLog) null;
      return list[0];
    }
  }
}
