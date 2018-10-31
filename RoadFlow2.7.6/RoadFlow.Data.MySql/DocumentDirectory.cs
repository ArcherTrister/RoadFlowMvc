// Decompiled with JetBrains decompiler
// Type: RoadFlow.Data.MySql.DocumentDirectory
// Assembly: RoadFlow.Data.MySql, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 29B652D7-5F6F-4A7D-AD1C-9F2C643FD784
// Assembly location: C:\inetpub\wwwroot\RoadFlowMvc\bin\RoadFlow.Data.MySql.dll

using MySql.Data.MySqlClient;
using RoadFlow.Data.Interface;
using System;
using System.Collections.Generic;

namespace RoadFlow.Data.MySql
{
  public class DocumentDirectory : IDocumentDirectory
  {
    private DBHelper dbHelper = new DBHelper();

    public int Add(RoadFlow.Data.Model.DocumentDirectory model)
    {
      string sql = "INSERT INTO documentdirectory\r\n\t\t\t\t(ID,ParentID,Name,ReadUsers,ManageUsers,PublishUsers,Sort) \r\n\t\t\t\tVALUES(@ID,@ParentID,@Name,@ReadUsers,@ManageUsers,@PublishUsers,@Sort)";
      MySqlParameter[] mySqlParameterArray = new MySqlParameter[7];
      int index1 = 0;
      MySqlParameter mySqlParameter1 = new MySqlParameter("@ID", MySqlDbType.VarChar, 36);
      mySqlParameter1.Value = (object) model.ID;
      mySqlParameterArray[index1] = mySqlParameter1;
      int index2 = 1;
      MySqlParameter mySqlParameter2 = new MySqlParameter("@ParentID", MySqlDbType.VarChar, 36);
      mySqlParameter2.Value = (object) model.ParentID;
      mySqlParameterArray[index2] = mySqlParameter2;
      int index3 = 2;
      MySqlParameter mySqlParameter3 = new MySqlParameter("@Name", MySqlDbType.Text, -1);
      mySqlParameter3.Value = (object) model.Name;
      mySqlParameterArray[index3] = mySqlParameter3;
      int index4 = 3;
      MySqlParameter mySqlParameter4;
      if (model.ReadUsers != null)
      {
        MySqlParameter mySqlParameter5 = new MySqlParameter("@ReadUsers", MySqlDbType.LongText, -1);
        mySqlParameter5.Value = (object) model.ReadUsers;
        mySqlParameter4 = mySqlParameter5;
      }
      else
      {
        mySqlParameter4 = new MySqlParameter("@ReadUsers", MySqlDbType.LongText, -1);
        mySqlParameter4.Value = (object) DBNull.Value;
      }
      mySqlParameterArray[index4] = mySqlParameter4;
      int index5 = 4;
      MySqlParameter mySqlParameter6;
      if (model.ManageUsers != null)
      {
        MySqlParameter mySqlParameter5 = new MySqlParameter("@ManageUsers", MySqlDbType.LongText, -1);
        mySqlParameter5.Value = (object) model.ManageUsers;
        mySqlParameter6 = mySqlParameter5;
      }
      else
      {
        mySqlParameter6 = new MySqlParameter("@ManageUsers", MySqlDbType.LongText, -1);
        mySqlParameter6.Value = (object) DBNull.Value;
      }
      mySqlParameterArray[index5] = mySqlParameter6;
      int index6 = 5;
      MySqlParameter mySqlParameter7;
      if (model.PublishUsers != null)
      {
        MySqlParameter mySqlParameter5 = new MySqlParameter("@PublishUsers", MySqlDbType.LongText, -1);
        mySqlParameter5.Value = (object) model.PublishUsers;
        mySqlParameter7 = mySqlParameter5;
      }
      else
      {
        mySqlParameter7 = new MySqlParameter("@PublishUsers", MySqlDbType.LongText, -1);
        mySqlParameter7.Value = (object) DBNull.Value;
      }
      mySqlParameterArray[index6] = mySqlParameter7;
      int index7 = 6;
      MySqlParameter mySqlParameter8 = new MySqlParameter("@Sort", MySqlDbType.Int32, 11);
      mySqlParameter8.Value = (object) model.Sort;
      mySqlParameterArray[index7] = mySqlParameter8;
      MySqlParameter[] parameter = mySqlParameterArray;
      return this.dbHelper.Execute(sql, parameter, false);
    }

    public int Update(RoadFlow.Data.Model.DocumentDirectory model)
    {
      string sql = "UPDATE documentdirectory SET \r\n\t\t\t\tParentID=@ParentID,Name=@Name,ReadUsers=@ReadUsers,ManageUsers=@ManageUsers,PublishUsers=@PublishUsers,Sort=@Sort\r\n\t\t\t\tWHERE ID=@ID";
      MySqlParameter[] mySqlParameterArray = new MySqlParameter[7];
      int index1 = 0;
      MySqlParameter mySqlParameter1 = new MySqlParameter("@ParentID", MySqlDbType.VarChar, 36);
      mySqlParameter1.Value = (object) model.ParentID;
      mySqlParameterArray[index1] = mySqlParameter1;
      int index2 = 1;
      MySqlParameter mySqlParameter2 = new MySqlParameter("@Name", MySqlDbType.Text, -1);
      mySqlParameter2.Value = (object) model.Name;
      mySqlParameterArray[index2] = mySqlParameter2;
      int index3 = 2;
      MySqlParameter mySqlParameter3;
      if (model.ReadUsers != null)
      {
        MySqlParameter mySqlParameter4 = new MySqlParameter("@ReadUsers", MySqlDbType.LongText, -1);
        mySqlParameter4.Value = (object) model.ReadUsers;
        mySqlParameter3 = mySqlParameter4;
      }
      else
      {
        mySqlParameter3 = new MySqlParameter("@ReadUsers", MySqlDbType.LongText, -1);
        mySqlParameter3.Value = (object) DBNull.Value;
      }
      mySqlParameterArray[index3] = mySqlParameter3;
      int index4 = 3;
      MySqlParameter mySqlParameter5;
      if (model.ManageUsers != null)
      {
        MySqlParameter mySqlParameter4 = new MySqlParameter("@ManageUsers", MySqlDbType.LongText, -1);
        mySqlParameter4.Value = (object) model.ManageUsers;
        mySqlParameter5 = mySqlParameter4;
      }
      else
      {
        mySqlParameter5 = new MySqlParameter("@ManageUsers", MySqlDbType.LongText, -1);
        mySqlParameter5.Value = (object) DBNull.Value;
      }
      mySqlParameterArray[index4] = mySqlParameter5;
      int index5 = 4;
      MySqlParameter mySqlParameter6;
      if (model.PublishUsers != null)
      {
        MySqlParameter mySqlParameter4 = new MySqlParameter("@PublishUsers", MySqlDbType.LongText, -1);
        mySqlParameter4.Value = (object) model.PublishUsers;
        mySqlParameter6 = mySqlParameter4;
      }
      else
      {
        mySqlParameter6 = new MySqlParameter("@PublishUsers", MySqlDbType.LongText, -1);
        mySqlParameter6.Value = (object) DBNull.Value;
      }
      mySqlParameterArray[index5] = mySqlParameter6;
      int index6 = 5;
      MySqlParameter mySqlParameter7 = new MySqlParameter("@Sort", MySqlDbType.Int32, 11);
      mySqlParameter7.Value = (object) model.Sort;
      mySqlParameterArray[index6] = mySqlParameter7;
      int index7 = 6;
      MySqlParameter mySqlParameter8 = new MySqlParameter("@ID", MySqlDbType.VarChar, 36);
      mySqlParameter8.Value = (object) model.ID;
      mySqlParameterArray[index7] = mySqlParameter8;
      MySqlParameter[] parameter = mySqlParameterArray;
      return this.dbHelper.Execute(sql, parameter, false);
    }

    public int Delete(Guid id)
    {
      string sql = "DELETE FROM documentdirectory WHERE ID=@ID";
      MySqlParameter[] mySqlParameterArray = new MySqlParameter[1];
      int index = 0;
      MySqlParameter mySqlParameter = new MySqlParameter("@ID", MySqlDbType.VarChar, 36);
      mySqlParameter.Value = (object) id.ToString();
      mySqlParameterArray[index] = mySqlParameter;
      MySqlParameter[] parameter = mySqlParameterArray;
      return this.dbHelper.Execute(sql, parameter, false);
    }

    private List<RoadFlow.Data.Model.DocumentDirectory> DataReaderToList(MySqlDataReader dataReader)
    {
      List<RoadFlow.Data.Model.DocumentDirectory> documentDirectoryList = new List<RoadFlow.Data.Model.DocumentDirectory>();
      while (dataReader.Read())
      {
        RoadFlow.Data.Model.DocumentDirectory documentDirectory = new RoadFlow.Data.Model.DocumentDirectory();
        documentDirectory.ID = dataReader.GetString(0).ToGuid();
        documentDirectory.ParentID = dataReader.GetString(1).ToGuid();
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
      MySqlDataReader dataReader = this.dbHelper.GetDataReader("SELECT * FROM documentdirectory");
      List<RoadFlow.Data.Model.DocumentDirectory> list = this.DataReaderToList(dataReader);
      dataReader.Close();
      return list;
    }

    public long GetCount()
    {
      long result;
      if (!long.TryParse(this.dbHelper.GetFieldValue("SELECT COUNT(*) FROM documentdirectory"), out result))
        return 0;
      return result;
    }

    public RoadFlow.Data.Model.DocumentDirectory Get(Guid id)
    {
      string sql = "SELECT * FROM documentdirectory WHERE ID=@ID";
      MySqlParameter[] mySqlParameterArray = new MySqlParameter[1];
      int index = 0;
      MySqlParameter mySqlParameter = new MySqlParameter("@ID", MySqlDbType.VarChar, 36);
      mySqlParameter.Value = (object) id.ToString();
      mySqlParameterArray[index] = mySqlParameter;
      MySqlParameter[] parameter = mySqlParameterArray;
      MySqlDataReader dataReader = this.dbHelper.GetDataReader(sql, parameter);
      List<RoadFlow.Data.Model.DocumentDirectory> list = this.DataReaderToList(dataReader);
      dataReader.Close();
      if (list.Count <= 0)
        return (RoadFlow.Data.Model.DocumentDirectory) null;
      return list[0];
    }

    public List<RoadFlow.Data.Model.DocumentDirectory> GetChilds(Guid id)
    {
      string sql = "SELECT * FROM DocumentDirectory WHERE ParentID=@ParentID ORDER BY Sort";
      MySqlParameter[] mySqlParameterArray = new MySqlParameter[1];
      int index = 0;
      MySqlParameter mySqlParameter = new MySqlParameter("@ParentID", MySqlDbType.VarChar);
      mySqlParameter.Value = (object) id;
      mySqlParameterArray[index] = mySqlParameter;
      MySqlParameter[] parameter = mySqlParameterArray;
      MySqlDataReader dataReader = this.dbHelper.GetDataReader(sql, parameter);
      List<RoadFlow.Data.Model.DocumentDirectory> list = this.DataReaderToList(dataReader);
      dataReader.Close();
      return list;
    }

    public int GetMaxSort(Guid dirID)
    {
      return this.dbHelper.GetFieldValue("SELECT (IFNULL(MAX(Sort),0)+5) Sort FROM DocumentDirectory WHERE ParentID=@ParentID ", new MySqlParameter[1]{ new MySqlParameter("@ParentID", (object) dirID) }).ToInt();
    }
  }
}
