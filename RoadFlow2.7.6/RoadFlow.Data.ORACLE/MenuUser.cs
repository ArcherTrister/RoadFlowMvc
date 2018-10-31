// Decompiled with JetBrains decompiler
// Type: RoadFlow.Data.ORACLE.MenuUser
// Assembly: RoadFlow.Data.ORACLE, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: C9018AA1-E48E-4231-92A9-CD6F0F275D11
// Assembly location: C:\inetpub\wwwroot\RoadFlowMvc\bin\RoadFlow.Data.ORACLE.dll

using Oracle.ManagedDataAccess.Client;
using RoadFlow.Data.Interface;
using System;
using System.Collections.Generic;

namespace RoadFlow.Data.ORACLE
{
  public class MenuUser : IMenuUser
  {
    private DBHelper dbHelper = new DBHelper();

    public int Add(RoadFlow.Data.Model.MenuUser model)
    {
      string sql = "INSERT INTO MenuUser\r\n\t\t\t\t(ID,MenuID,SubPageID,Organizes,Users,Buttons) \r\n\t\t\t\tVALUES(:ID,:MenuID,:SubPageID,:Organizes,:Users,:Buttons)";
      OracleParameter[] oracleParameterArray = new OracleParameter[6];
      int index1 = 0;
      OracleParameter oracleParameter1 = new OracleParameter(":ID", OracleDbType.Varchar2);
      oracleParameter1.Value = (object) model.ID;
      oracleParameterArray[index1] = oracleParameter1;
      int index2 = 1;
      OracleParameter oracleParameter2 = new OracleParameter(":MenuID", OracleDbType.Varchar2);
      oracleParameter2.Value = (object) model.MenuID;
      oracleParameterArray[index2] = oracleParameter2;
      int index3 = 2;
      OracleParameter oracleParameter3 = new OracleParameter(":SubPageID", OracleDbType.Varchar2);
      oracleParameter3.Value = (object) model.SubPageID;
      oracleParameterArray[index3] = oracleParameter3;
      int index4 = 3;
      OracleParameter oracleParameter4 = new OracleParameter(":Organizes", OracleDbType.Varchar2);
      oracleParameter4.Value = (object) model.Organizes;
      oracleParameterArray[index4] = oracleParameter4;
      int index5 = 4;
      OracleParameter oracleParameter5 = new OracleParameter(":Users", OracleDbType.Varchar2);
      oracleParameter5.Value = (object) model.Users;
      oracleParameterArray[index5] = oracleParameter5;
      int index6 = 5;
      OracleParameter oracleParameter6;
      if (model.Buttons != null)
      {
        OracleParameter oracleParameter7 = new OracleParameter(":Buttons", OracleDbType.Varchar2);
        oracleParameter7.Value = (object) model.Buttons;
        oracleParameter6 = oracleParameter7;
      }
      else
      {
        oracleParameter6 = new OracleParameter(":Buttons", OracleDbType.Varchar2);
        oracleParameter6.Value = (object) DBNull.Value;
      }
      oracleParameterArray[index6] = oracleParameter6;
      OracleParameter[] parameter = oracleParameterArray;
      return this.dbHelper.Execute(sql, parameter);
    }

    public int Update(RoadFlow.Data.Model.MenuUser model)
    {
      string sql = "UPDATE MenuUser SET \r\n\t\t\t\tMenuID=:MenuID,SubPageID=:SubPageID,Organizes=:Organizes,Users=:Users,Buttons=:Buttons\r\n\t\t\t\tWHERE ID=:ID";
      OracleParameter[] oracleParameterArray = new OracleParameter[6];
      int index1 = 0;
      OracleParameter oracleParameter1 = new OracleParameter(":MenuID", OracleDbType.Varchar2);
      oracleParameter1.Value = (object) model.MenuID;
      oracleParameterArray[index1] = oracleParameter1;
      int index2 = 1;
      OracleParameter oracleParameter2 = new OracleParameter(":SubPageID", OracleDbType.Varchar2);
      oracleParameter2.Value = (object) model.SubPageID;
      oracleParameterArray[index2] = oracleParameter2;
      int index3 = 2;
      OracleParameter oracleParameter3 = new OracleParameter(":Organizes", OracleDbType.Varchar2);
      oracleParameter3.Value = (object) model.Organizes;
      oracleParameterArray[index3] = oracleParameter3;
      int index4 = 3;
      OracleParameter oracleParameter4 = new OracleParameter(":Users", OracleDbType.Varchar2);
      oracleParameter4.Value = (object) model.Users;
      oracleParameterArray[index4] = oracleParameter4;
      int index5 = 4;
      OracleParameter oracleParameter5;
      if (model.Buttons != null)
      {
        OracleParameter oracleParameter6 = new OracleParameter(":Buttons", OracleDbType.Varchar2);
        oracleParameter6.Value = (object) model.Buttons;
        oracleParameter5 = oracleParameter6;
      }
      else
      {
        oracleParameter5 = new OracleParameter(":Buttons", OracleDbType.Varchar2);
        oracleParameter5.Value = (object) DBNull.Value;
      }
      oracleParameterArray[index5] = oracleParameter5;
      int index6 = 5;
      OracleParameter oracleParameter7 = new OracleParameter(":ID", OracleDbType.Varchar2);
      oracleParameter7.Value = (object) model.ID;
      oracleParameterArray[index6] = oracleParameter7;
      OracleParameter[] parameter = oracleParameterArray;
      return this.dbHelper.Execute(sql, parameter);
    }

    public int Delete(Guid id)
    {
      string sql = "DELETE FROM MenuUser WHERE ID=:ID";
      OracleParameter[] oracleParameterArray = new OracleParameter[1];
      int index = 0;
      OracleParameter oracleParameter = new OracleParameter(":ID", OracleDbType.Varchar2);
      oracleParameter.Value = (object) id;
      oracleParameterArray[index] = oracleParameter;
      OracleParameter[] parameter = oracleParameterArray;
      return this.dbHelper.Execute(sql, parameter);
    }

    private List<RoadFlow.Data.Model.MenuUser> DataReaderToList(OracleDataReader dataReader)
    {
      List<RoadFlow.Data.Model.MenuUser> menuUserList = new List<RoadFlow.Data.Model.MenuUser>();
      while (dataReader.Read())
      {
        RoadFlow.Data.Model.MenuUser menuUser = new RoadFlow.Data.Model.MenuUser();
        menuUser.ID = dataReader.GetString(0).ToGuid();
        menuUser.MenuID = dataReader.GetString(1).ToGuid();
        menuUser.SubPageID = dataReader.GetString(2).ToGuid();
        menuUser.Organizes = dataReader.GetString(3);
        menuUser.Users = dataReader.GetString(4);
        if (!dataReader.IsDBNull(5))
          menuUser.Buttons = dataReader.GetString(5);
        menuUserList.Add(menuUser);
      }
      return menuUserList;
    }

    public List<RoadFlow.Data.Model.MenuUser> GetAll()
    {
      OracleDataReader dataReader = this.dbHelper.GetDataReader("SELECT * FROM MenuUser");
      List<RoadFlow.Data.Model.MenuUser> list = this.DataReaderToList(dataReader);
      dataReader.Close();
      return list;
    }

    public long GetCount()
    {
      long result;
      if (!long.TryParse(this.dbHelper.GetFieldValue("SELECT COUNT(*) FROM MenuUser"), out result))
        return 0;
      return result;
    }

    public RoadFlow.Data.Model.MenuUser Get(Guid id)
    {
      string sql = "SELECT * FROM MenuUser WHERE ID=:ID";
      OracleParameter[] oracleParameterArray = new OracleParameter[1];
      int index = 0;
      OracleParameter oracleParameter = new OracleParameter(":ID", OracleDbType.Varchar2);
      oracleParameter.Value = (object) id;
      oracleParameterArray[index] = oracleParameter;
      OracleParameter[] parameter = oracleParameterArray;
      OracleDataReader dataReader = this.dbHelper.GetDataReader(sql, parameter);
      List<RoadFlow.Data.Model.MenuUser> list = this.DataReaderToList(dataReader);
      dataReader.Close();
      if (list.Count <= 0)
        return (RoadFlow.Data.Model.MenuUser) null;
      return list[0];
    }

    public int DeleteByOrganizes(string organizes)
    {
      string sql = "DELETE FROM MenuUser WHERE Organizes=:Organizes";
      OracleParameter[] oracleParameterArray = new OracleParameter[1];
      int index = 0;
      OracleParameter oracleParameter = new OracleParameter(":Organizes", OracleDbType.Varchar2);
      oracleParameter.Value = (object) organizes;
      oracleParameterArray[index] = oracleParameter;
      OracleParameter[] parameter = oracleParameterArray;
      return this.dbHelper.Execute(sql, parameter);
    }

    public int DeleteByMenuID(Guid menuID)
    {
      string sql = "DELETE FROM MenuUser WHERE MenuID=:MenuID";
      OracleParameter[] oracleParameterArray = new OracleParameter[1];
      int index = 0;
      OracleParameter oracleParameter = new OracleParameter(":MenuID", OracleDbType.Varchar2);
      oracleParameter.Value = (object) menuID.ToString();
      oracleParameterArray[index] = oracleParameter;
      OracleParameter[] parameter = oracleParameterArray;
      return this.dbHelper.Execute(sql, parameter);
    }
  }
}
