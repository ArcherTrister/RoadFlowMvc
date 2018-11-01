// Decompiled with JetBrains decompiler
// Type: RoadFlow.Data.ORACLE.HastenLog
// Assembly: RoadFlow.Data.ORACLE, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: C9018AA1-E48E-4231-92A9-CD6F0F275D11
// Assembly location: C:\inetpub\wwwroot\RoadFlowMvc\bin\RoadFlow.Data.ORACLE.dll

using Oracle.ManagedDataAccess.Client;
using RoadFlow.Data.Interface;
using System;
using System.Collections.Generic;

namespace RoadFlow.Data.ORACLE
{
  public class HastenLog : IHastenLog
  {
    private DBHelper dbHelper = new DBHelper();

    public int Add(RoadFlow.Data.Model.HastenLog model)
    {
      string sql = "INSERT INTO HastenLog\r\n\t\t\t\t(ID,OthersParams,Users,Types,Contents,SendUser,SendUserName,SendTime) \r\n\t\t\t\tVALUES(:ID,:OthersParams,:Users,:Types,:Contents,:SendUser,:SendUserName,:SendTime)";
      OracleParameter[] oracleParameterArray = new OracleParameter[8];
      int index1 = 0;
      OracleParameter oracleParameter1 = new OracleParameter(":ID", OracleDbType.Varchar2);
      oracleParameter1.Value = (object) model.ID;
      oracleParameterArray[index1] = oracleParameter1;
      int index2 = 1;
      OracleParameter oracleParameter2 = new OracleParameter(":OthersParams", OracleDbType.Varchar2);
      oracleParameter2.Value = (object) model.OthersParams;
      oracleParameterArray[index2] = oracleParameter2;
      int index3 = 2;
      OracleParameter oracleParameter3 = new OracleParameter(":Users", OracleDbType.Varchar2);
      oracleParameter3.Value = (object) model.Users;
      oracleParameterArray[index3] = oracleParameter3;
      int index4 = 3;
      OracleParameter oracleParameter4 = new OracleParameter(":Types", OracleDbType.Varchar2);
      oracleParameter4.Value = (object) model.Types;
      oracleParameterArray[index4] = oracleParameter4;
      int index5 = 4;
      OracleParameter oracleParameter5 = new OracleParameter(":Contents", OracleDbType.NVarchar2);
      oracleParameter5.Value = (object) model.Contents;
      oracleParameterArray[index5] = oracleParameter5;
      int index6 = 5;
      OracleParameter oracleParameter6 = new OracleParameter(":SendUser", OracleDbType.Varchar2);
      oracleParameter6.Value = (object) model.SendUser;
      oracleParameterArray[index6] = oracleParameter6;
      int index7 = 6;
      OracleParameter oracleParameter7 = new OracleParameter(":SendUserName", OracleDbType.Varchar2);
      oracleParameter7.Value = (object) model.SendUserName;
      oracleParameterArray[index7] = oracleParameter7;
      int index8 = 7;
      OracleParameter oracleParameter8 = new OracleParameter(":SendTime", OracleDbType.Date);
      oracleParameter8.Value = (object) model.SendTime;
      oracleParameterArray[index8] = oracleParameter8;
      OracleParameter[] parameter = oracleParameterArray;
      return this.dbHelper.Execute(sql, parameter);
    }

    public int Update(RoadFlow.Data.Model.HastenLog model)
    {
      string sql = "UPDATE HastenLog SET \r\n\t\t\t\tOthersParams=:OthersParams,Users=:Users,Types=:Types,Contents=:Contents,SendUser=:SendUser,SendUserName=:SendUserName,SendTime=:SendTime\r\n\t\t\t\tWHERE ID=:ID";
      OracleParameter[] oracleParameterArray = new OracleParameter[8];
      int index1 = 0;
      OracleParameter oracleParameter1 = new OracleParameter(":OthersParams", OracleDbType.Varchar2);
      oracleParameter1.Value = (object) model.OthersParams;
      oracleParameterArray[index1] = oracleParameter1;
      int index2 = 1;
      OracleParameter oracleParameter2 = new OracleParameter(":Users", OracleDbType.Varchar2);
      oracleParameter2.Value = (object) model.Users;
      oracleParameterArray[index2] = oracleParameter2;
      int index3 = 2;
      OracleParameter oracleParameter3 = new OracleParameter(":Types", OracleDbType.Varchar2);
      oracleParameter3.Value = (object) model.Types;
      oracleParameterArray[index3] = oracleParameter3;
      int index4 = 3;
      OracleParameter oracleParameter4 = new OracleParameter(":Contents", OracleDbType.NVarchar2);
      oracleParameter4.Value = (object) model.Contents;
      oracleParameterArray[index4] = oracleParameter4;
      int index5 = 4;
      OracleParameter oracleParameter5 = new OracleParameter(":SendUser", OracleDbType.Varchar2);
      oracleParameter5.Value = (object) model.SendUser;
      oracleParameterArray[index5] = oracleParameter5;
      int index6 = 5;
      OracleParameter oracleParameter6 = new OracleParameter(":SendUserName", OracleDbType.Varchar2);
      oracleParameter6.Value = (object) model.SendUserName;
      oracleParameterArray[index6] = oracleParameter6;
      int index7 = 6;
      OracleParameter oracleParameter7 = new OracleParameter(":SendTime", OracleDbType.Date);
      oracleParameter7.Value = (object) model.SendTime;
      oracleParameterArray[index7] = oracleParameter7;
      int index8 = 7;
      OracleParameter oracleParameter8 = new OracleParameter(":ID", OracleDbType.Varchar2);
      oracleParameter8.Value = (object) model.ID;
      oracleParameterArray[index8] = oracleParameter8;
      OracleParameter[] parameter = oracleParameterArray;
      return this.dbHelper.Execute(sql, parameter);
    }

    public int Delete(Guid id)
    {
      string sql = "DELETE FROM HastenLog WHERE ID=:ID";
      OracleParameter[] oracleParameterArray = new OracleParameter[1];
      int index = 0;
      OracleParameter oracleParameter = new OracleParameter(":ID", OracleDbType.Varchar2);
      oracleParameter.Value = (object) id;
      oracleParameterArray[index] = oracleParameter;
      OracleParameter[] parameter = oracleParameterArray;
      return this.dbHelper.Execute(sql, parameter);
    }

    private List<RoadFlow.Data.Model.HastenLog> DataReaderToList(OracleDataReader dataReader)
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
      OracleDataReader dataReader = this.dbHelper.GetDataReader("SELECT * FROM HastenLog");
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
      string sql = "SELECT * FROM HastenLog WHERE ID=:ID";
      OracleParameter[] oracleParameterArray = new OracleParameter[1];
      int index = 0;
      OracleParameter oracleParameter = new OracleParameter(":ID", OracleDbType.Varchar2);
      oracleParameter.Value = (object) id;
      oracleParameterArray[index] = oracleParameter;
      OracleParameter[] parameter = oracleParameterArray;
      OracleDataReader dataReader = this.dbHelper.GetDataReader(sql, parameter);
      List<RoadFlow.Data.Model.HastenLog> list = this.DataReaderToList(dataReader);
      dataReader.Close();
      if (list.Count <= 0)
        return (RoadFlow.Data.Model.HastenLog) null;
      return list[0];
    }
  }
}
