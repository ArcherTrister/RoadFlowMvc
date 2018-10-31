// Decompiled with JetBrains decompiler
// Type: RoadFlow.Data.MySql.HastenLog
// Assembly: RoadFlow.Data.MySql, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 29B652D7-5F6F-4A7D-AD1C-9F2C643FD784
// Assembly location: C:\inetpub\wwwroot\RoadFlowMvc\bin\RoadFlow.Data.MySql.dll

using MySql.Data.MySqlClient;
using RoadFlow.Data.Interface;
using System;
using System.Collections.Generic;

namespace RoadFlow.Data.MySql
{
  public class HastenLog : IHastenLog
  {
    private DBHelper dbHelper = new DBHelper();

    public int Add(RoadFlow.Data.Model.HastenLog model)
    {
      string sql = "INSERT INTO hastenlog\r\n\t\t\t\t(ID,OthersParams,Users,Types,Contents,SendUser,SendUserName,SendTime) \r\n\t\t\t\tVALUES(@ID,@OthersParams,@Users,@Types,@Contents,@SendUser,@SendUserName,@SendTime)";
      MySqlParameter[] mySqlParameterArray = new MySqlParameter[8];
      int index1 = 0;
      MySqlParameter mySqlParameter1 = new MySqlParameter("@ID", MySqlDbType.VarChar, 36);
      mySqlParameter1.Value = (object) model.ID;
      mySqlParameterArray[index1] = mySqlParameter1;
      int index2 = 1;
      MySqlParameter mySqlParameter2 = new MySqlParameter("@OthersParams", MySqlDbType.Text, -1);
      mySqlParameter2.Value = (object) model.OthersParams;
      mySqlParameterArray[index2] = mySqlParameter2;
      int index3 = 2;
      MySqlParameter mySqlParameter3 = new MySqlParameter("@Users", MySqlDbType.Text, -1);
      mySqlParameter3.Value = (object) model.Users;
      mySqlParameterArray[index3] = mySqlParameter3;
      int index4 = 3;
      MySqlParameter mySqlParameter4 = new MySqlParameter("@Types", MySqlDbType.Text, -1);
      mySqlParameter4.Value = (object) model.Types;
      mySqlParameterArray[index4] = mySqlParameter4;
      int index5 = 4;
      MySqlParameter mySqlParameter5 = new MySqlParameter("@Contents", MySqlDbType.Text, -1);
      mySqlParameter5.Value = (object) model.Contents;
      mySqlParameterArray[index5] = mySqlParameter5;
      int index6 = 5;
      MySqlParameter mySqlParameter6 = new MySqlParameter("@SendUser", MySqlDbType.VarChar, 36);
      mySqlParameter6.Value = (object) model.SendUser;
      mySqlParameterArray[index6] = mySqlParameter6;
      int index7 = 6;
      MySqlParameter mySqlParameter7 = new MySqlParameter("@SendUserName", MySqlDbType.VarChar, 50);
      mySqlParameter7.Value = (object) model.SendUserName;
      mySqlParameterArray[index7] = mySqlParameter7;
      int index8 = 7;
      MySqlParameter mySqlParameter8 = new MySqlParameter("@SendTime", MySqlDbType.DateTime, -1);
      mySqlParameter8.Value = (object) model.SendTime;
      mySqlParameterArray[index8] = mySqlParameter8;
      MySqlParameter[] parameter = mySqlParameterArray;
      return this.dbHelper.Execute(sql, parameter, false);
    }

    public int Update(RoadFlow.Data.Model.HastenLog model)
    {
      string sql = "UPDATE hastenlog SET \r\n\t\t\t\tOthersParams=@OthersParams,Users=@Users,Types=@Types,Contents=@Contents,SendUser=@SendUser,SendUserName=@SendUserName,SendTime=@SendTime\r\n\t\t\t\tWHERE ID=@ID";
      MySqlParameter[] mySqlParameterArray = new MySqlParameter[8];
      int index1 = 0;
      MySqlParameter mySqlParameter1 = new MySqlParameter("@OthersParams", MySqlDbType.Text, -1);
      mySqlParameter1.Value = (object) model.OthersParams;
      mySqlParameterArray[index1] = mySqlParameter1;
      int index2 = 1;
      MySqlParameter mySqlParameter2 = new MySqlParameter("@Users", MySqlDbType.Text, -1);
      mySqlParameter2.Value = (object) model.Users;
      mySqlParameterArray[index2] = mySqlParameter2;
      int index3 = 2;
      MySqlParameter mySqlParameter3 = new MySqlParameter("@Types", MySqlDbType.Text, -1);
      mySqlParameter3.Value = (object) model.Types;
      mySqlParameterArray[index3] = mySqlParameter3;
      int index4 = 3;
      MySqlParameter mySqlParameter4 = new MySqlParameter("@Contents", MySqlDbType.Text, -1);
      mySqlParameter4.Value = (object) model.Contents;
      mySqlParameterArray[index4] = mySqlParameter4;
      int index5 = 4;
      MySqlParameter mySqlParameter5 = new MySqlParameter("@SendUser", MySqlDbType.VarChar, 36);
      mySqlParameter5.Value = (object) model.SendUser;
      mySqlParameterArray[index5] = mySqlParameter5;
      int index6 = 5;
      MySqlParameter mySqlParameter6 = new MySqlParameter("@SendUserName", MySqlDbType.VarChar, 50);
      mySqlParameter6.Value = (object) model.SendUserName;
      mySqlParameterArray[index6] = mySqlParameter6;
      int index7 = 6;
      MySqlParameter mySqlParameter7 = new MySqlParameter("@SendTime", MySqlDbType.DateTime, -1);
      mySqlParameter7.Value = (object) model.SendTime;
      mySqlParameterArray[index7] = mySqlParameter7;
      int index8 = 7;
      MySqlParameter mySqlParameter8 = new MySqlParameter("@ID", MySqlDbType.VarChar, 36);
      mySqlParameter8.Value = (object) model.ID;
      mySqlParameterArray[index8] = mySqlParameter8;
      MySqlParameter[] parameter = mySqlParameterArray;
      return this.dbHelper.Execute(sql, parameter, false);
    }

    public int Delete(Guid id)
    {
      string sql = "DELETE FROM hastenlog WHERE ID=@ID";
      MySqlParameter[] mySqlParameterArray = new MySqlParameter[1];
      int index = 0;
      MySqlParameter mySqlParameter = new MySqlParameter("@ID", MySqlDbType.VarChar, 36);
      mySqlParameter.Value = (object) id.ToString();
      mySqlParameterArray[index] = mySqlParameter;
      MySqlParameter[] parameter = mySqlParameterArray;
      return this.dbHelper.Execute(sql, parameter, false);
    }

    private List<RoadFlow.Data.Model.HastenLog> DataReaderToList(MySqlDataReader dataReader)
    {
      List<RoadFlow.Data.Model.HastenLog> hastenLogList = new List<RoadFlow.Data.Model.HastenLog>();
      while (dataReader.Read())
        hastenLogList.Add(new RoadFlow.Data.Model.HastenLog()
        {
          ID = dataReader.GetString(0).ToGuid(),
          OthersParams = dataReader.GetString(1),
          Users = dataReader.GetString(2),
          Types = dataReader.GetString(3),
          Contents = dataReader.GetString(4),
          SendUser = dataReader.GetString(5).ToGuid(),
          SendUserName = dataReader.GetString(6),
          SendTime = dataReader.GetDateTime(7)
        });
      return hastenLogList;
    }

    public List<RoadFlow.Data.Model.HastenLog> GetAll()
    {
      MySqlDataReader dataReader = this.dbHelper.GetDataReader("SELECT * FROM hastenlog");
      List<RoadFlow.Data.Model.HastenLog> list = this.DataReaderToList(dataReader);
      dataReader.Close();
      return list;
    }

    public long GetCount()
    {
      long result;
      if (!long.TryParse(this.dbHelper.GetFieldValue("SELECT COUNT(*) FROM hastenlog"), out result))
        return 0;
      return result;
    }

    public RoadFlow.Data.Model.HastenLog Get(Guid id)
    {
      string sql = "SELECT * FROM hastenlog WHERE ID=@ID";
      MySqlParameter[] mySqlParameterArray = new MySqlParameter[1];
      int index = 0;
      MySqlParameter mySqlParameter = new MySqlParameter("@ID", MySqlDbType.VarChar, 36);
      mySqlParameter.Value = (object) id.ToString();
      mySqlParameterArray[index] = mySqlParameter;
      MySqlParameter[] parameter = mySqlParameterArray;
      MySqlDataReader dataReader = this.dbHelper.GetDataReader(sql, parameter);
      List<RoadFlow.Data.Model.HastenLog> list = this.DataReaderToList(dataReader);
      dataReader.Close();
      if (list.Count <= 0)
        return (RoadFlow.Data.Model.HastenLog) null;
      return list[0];
    }
  }
}
