// Decompiled with JetBrains decompiler
// Type: RoadFlow.Data.ORACLE.Menu
// Assembly: RoadFlow.Data.ORACLE, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: C9018AA1-E48E-4231-92A9-CD6F0F275D11
// Assembly location: C:\inetpub\wwwroot\RoadFlowMvc\bin\RoadFlow.Data.ORACLE.dll

using Oracle.ManagedDataAccess.Client;
using RoadFlow.Data.Interface;
using System;
using System.Collections.Generic;
using System.Data;

namespace RoadFlow.Data.ORACLE
{
    public class Menu : IMenu
    {
        private DBHelper dbHelper = new DBHelper();

        public int Add(RoadFlow.Data.Model.Menu model)
        {
            string sql = "INSERT INTO Menu\r\n\t\t\t\t(ID,ParentID,AppLibraryID,Title,Params,Ico,Sort,IcoColor) \r\n\t\t\t\tVALUES(:ID,:ParentID,:AppLibraryID,:Title,:Params,:Ico,:Sort,:IcoColor)";
            OracleParameter[] oracleParameterArray = new OracleParameter[8];
            int index1 = 0;
            OracleParameter oracleParameter1 = new OracleParameter(":ID", OracleDbType.Varchar2);
            oracleParameter1.Value = (object)model.ID;
            oracleParameterArray[index1] = oracleParameter1;
            int index2 = 1;
            OracleParameter oracleParameter2 = new OracleParameter(":ParentID", OracleDbType.Varchar2);
            oracleParameter2.Value = (object)model.ParentID;
            oracleParameterArray[index2] = oracleParameter2;
            int index3 = 2;
            OracleParameter oracleParameter3;
            if (model.AppLibraryID.HasValue)
            {
                OracleParameter oracleParameter4 = new OracleParameter(":AppLibraryID", OracleDbType.Varchar2);
                oracleParameter4.Value = (object)model.AppLibraryID;
                oracleParameter3 = oracleParameter4;
            }
            else
            {
                oracleParameter3 = new OracleParameter(":AppLibraryID", OracleDbType.Varchar2);
                oracleParameter3.Value = (object)DBNull.Value;
            }
            oracleParameterArray[index3] = oracleParameter3;
            int index4 = 3;
            OracleParameter oracleParameter5 = new OracleParameter(":Title", OracleDbType.Varchar2);
            oracleParameter5.Value = (object)model.Title;
            oracleParameterArray[index4] = oracleParameter5;
            int index5 = 4;
            OracleParameter oracleParameter6;
            if (model.Params != null)
            {
                OracleParameter oracleParameter4 = new OracleParameter(":Params", OracleDbType.Varchar2);
                oracleParameter4.Value = (object)model.Params;
                oracleParameter6 = oracleParameter4;
            }
            else
            {
                oracleParameter6 = new OracleParameter(":Params", OracleDbType.Varchar2);
                oracleParameter6.Value = (object)DBNull.Value;
            }
            oracleParameterArray[index5] = oracleParameter6;
            int index6 = 5;
            OracleParameter oracleParameter7;
            if (model.Ico != null)
            {
                OracleParameter oracleParameter4 = new OracleParameter(":Ico", OracleDbType.Varchar2);
                oracleParameter4.Value = (object)model.Ico;
                oracleParameter7 = oracleParameter4;
            }
            else
            {
                oracleParameter7 = new OracleParameter(":Ico", OracleDbType.Varchar2);
                oracleParameter7.Value = (object)DBNull.Value;
            }
            oracleParameterArray[index6] = oracleParameter7;
            int index7 = 6;
            OracleParameter oracleParameter8 = new OracleParameter(":Sort", OracleDbType.Int32);
            oracleParameter8.Value = (object)model.Sort;
            oracleParameterArray[index7] = oracleParameter8;
            int index8 = 7;
            OracleParameter oracleParameter9;
            if (model.IcoColor != null)
            {
                OracleParameter oracleParameter4 = new OracleParameter(":IcoColor", OracleDbType.Varchar2);
                oracleParameter4.Value = (object)model.IcoColor;
                oracleParameter9 = oracleParameter4;
            }
            else
            {
                oracleParameter9 = new OracleParameter(":IcoColor", OracleDbType.Varchar2);
                oracleParameter9.Value = (object)DBNull.Value;
            }
            oracleParameterArray[index8] = oracleParameter9;
            OracleParameter[] parameter = oracleParameterArray;
            return this.dbHelper.Execute(sql, parameter);
        }

        public int Update(RoadFlow.Data.Model.Menu model)
        {
            string sql = "UPDATE Menu SET \r\n\t\t\t\tParentID=:ParentID,AppLibraryID=:AppLibraryID,Title=:Title,Params=:Params,Ico=:Ico,Sort=:Sort,IcoColor=:IcoColor \r\n\t\t\t\tWHERE ID=:ID";
            OracleParameter[] oracleParameterArray = new OracleParameter[8];
            int index1 = 0;
            OracleParameter oracleParameter1 = new OracleParameter(":ParentID", OracleDbType.Varchar2);
            oracleParameter1.Value = (object)model.ParentID;
            oracleParameterArray[index1] = oracleParameter1;
            int index2 = 1;
            OracleParameter oracleParameter2;
            if (model.AppLibraryID.HasValue)
            {
                OracleParameter oracleParameter3 = new OracleParameter(":AppLibraryID", OracleDbType.Varchar2);
                oracleParameter3.Value = (object)model.AppLibraryID;
                oracleParameter2 = oracleParameter3;
            }
            else
            {
                oracleParameter2 = new OracleParameter(":AppLibraryID", OracleDbType.Varchar2);
                oracleParameter2.Value = (object)DBNull.Value;
            }
            oracleParameterArray[index2] = oracleParameter2;
            int index3 = 2;
            OracleParameter oracleParameter4 = new OracleParameter(":Title", OracleDbType.Varchar2);
            oracleParameter4.Value = (object)model.Title;
            oracleParameterArray[index3] = oracleParameter4;
            int index4 = 3;
            OracleParameter oracleParameter5;
            if (model.Params != null)
            {
                OracleParameter oracleParameter3 = new OracleParameter(":Params", OracleDbType.Varchar2);
                oracleParameter3.Value = (object)model.Params;
                oracleParameter5 = oracleParameter3;
            }
            else
            {
                oracleParameter5 = new OracleParameter(":Params", OracleDbType.Varchar2);
                oracleParameter5.Value = (object)DBNull.Value;
            }
            oracleParameterArray[index4] = oracleParameter5;
            int index5 = 4;
            OracleParameter oracleParameter6;
            if (model.Ico != null)
            {
                OracleParameter oracleParameter3 = new OracleParameter(":Ico", OracleDbType.Varchar2);
                oracleParameter3.Value = (object)model.Ico;
                oracleParameter6 = oracleParameter3;
            }
            else
            {
                oracleParameter6 = new OracleParameter(":Ico", OracleDbType.Varchar2);
                oracleParameter6.Value = (object)DBNull.Value;
            }
            oracleParameterArray[index5] = oracleParameter6;
            int index6 = 5;
            OracleParameter oracleParameter7 = new OracleParameter(":Sort", OracleDbType.Int32);
            oracleParameter7.Value = (object)model.Sort;
            oracleParameterArray[index6] = oracleParameter7;
            int index7 = 6;
            OracleParameter oracleParameter8;
            if (model.IcoColor != null)
            {
                OracleParameter oracleParameter3 = new OracleParameter(":IcoColor", OracleDbType.Varchar2);
                oracleParameter3.Value = (object)model.IcoColor;
                oracleParameter8 = oracleParameter3;
            }
            else
            {
                oracleParameter8 = new OracleParameter(":IcoColor", OracleDbType.Varchar2);
                oracleParameter8.Value = (object)DBNull.Value;
            }
            oracleParameterArray[index7] = oracleParameter8;
            int index8 = 7;
            OracleParameter oracleParameter9 = new OracleParameter(":ID", OracleDbType.Varchar2);
            oracleParameter9.Value = (object)model.ID;
            oracleParameterArray[index8] = oracleParameter9;
            OracleParameter[] parameter = oracleParameterArray;
            return this.dbHelper.Execute(sql, parameter);
        }

        public int Delete(Guid id)
        {
            string sql = "DELETE FROM Menu WHERE ID=:ID";
            OracleParameter[] oracleParameterArray = new OracleParameter[1];
            int index = 0;
            OracleParameter oracleParameter = new OracleParameter(":ID", OracleDbType.Varchar2);
            oracleParameter.Value = (object)id;
            oracleParameterArray[index] = oracleParameter;
            OracleParameter[] parameter = oracleParameterArray;
            return this.dbHelper.Execute(sql, parameter);
        }

        private List<RoadFlow.Data.Model.Menu> DataReaderToList(OracleDataReader dataReader)
        {
            List<RoadFlow.Data.Model.Menu> menuList = new List<RoadFlow.Data.Model.Menu>();
            while (dataReader.Read())
            {
                RoadFlow.Data.Model.Menu menu = new RoadFlow.Data.Model.Menu();
                menu.ID = dataReader.GetString(0).ToGuid();
                menu.ParentID = dataReader.GetString(1).ToGuid();
                if (!dataReader.IsDBNull(2))
                    menu.AppLibraryID = new Guid?(dataReader.GetString(2).ToGuid());
                menu.Title = dataReader.GetString(3);
                if (!dataReader.IsDBNull(4))
                    menu.Params = dataReader.GetString(4);
                if (!dataReader.IsDBNull(5))
                    menu.Ico = dataReader.GetString(5);
                menu.Sort = dataReader.GetInt32(6);
                if (!dataReader.IsDBNull(7))
                    menu.IcoColor = dataReader.GetString(7);
                menuList.Add(menu);
            }
            return menuList;
        }

        public List<RoadFlow.Data.Model.Menu> GetAll()
        {
            OracleDataReader dataReader = this.dbHelper.GetDataReader("SELECT * FROM Menu");
            List<RoadFlow.Data.Model.Menu> list = this.DataReaderToList(dataReader);
            dataReader.Close();
            return list;
        }

        public long GetCount()
        {
            long result;
            if (!long.TryParse(this.dbHelper.GetFieldValue("SELECT COUNT(*) FROM Menu"), out result))
                return 0;
            return result;
        }

        public RoadFlow.Data.Model.Menu Get(Guid id)
        {
            string sql = "SELECT * FROM Menu WHERE ID=:ID";
            OracleParameter[] oracleParameterArray = new OracleParameter[1];
            int index = 0;
            OracleParameter oracleParameter = new OracleParameter(":ID", OracleDbType.Varchar2);
            oracleParameter.Value = (object)id;
            oracleParameterArray[index] = oracleParameter;
            OracleParameter[] parameter = oracleParameterArray;
            OracleDataReader dataReader = this.dbHelper.GetDataReader(sql, parameter);
            List<RoadFlow.Data.Model.Menu> list = this.DataReaderToList(dataReader);
            dataReader.Close();
            if (list.Count <= 0)
                return (RoadFlow.Data.Model.Menu)null;
            return list[0];
        }

        public DataTable GetAllDataTable()
        {
            return this.dbHelper.GetDataTable("SELECT a.*,b.Address,b.OpenMode,b.Width,b.Height,b.Params AS Params1,b.Ico AS AppIco,b.Color AS IcoColor1 FROM Menu a LEFT JOIN AppLibrary b ON a.AppLibraryID=b.ID ORDER BY a.Sort");
        }

        public List<RoadFlow.Data.Model.Menu> GetChild(Guid id)
        {
            string sql = "SELECT * FROM Menu WHERE ParentID=:ParentID ORDER BY Sort";
            OracleParameter[] oracleParameterArray = new OracleParameter[1];
            int index = 0;
            OracleParameter oracleParameter = new OracleParameter(":ParentID", OracleDbType.Varchar2);
            oracleParameter.Value = (object)id;
            oracleParameterArray[index] = oracleParameter;
            OracleParameter[] parameter = oracleParameterArray;
            OracleDataReader dataReader = this.dbHelper.GetDataReader(sql, parameter);
            List<RoadFlow.Data.Model.Menu> list = this.DataReaderToList(dataReader);
            dataReader.Close();
            return list;
        }

        public bool HasChild(Guid id)
        {
            string sql = "SELECT ID FROM Menu WHERE ROWNUM<=1 AND ParentID=:ParentID";
            OracleParameter[] oracleParameterArray = new OracleParameter[1];
            int index = 0;
            OracleParameter oracleParameter = new OracleParameter(":ParentID", OracleDbType.Varchar2);
            oracleParameter.Value = (object)id;
            oracleParameterArray[index] = oracleParameter;
            OracleParameter[] parameter = oracleParameterArray;
            OracleDataReader dataReader = this.dbHelper.GetDataReader(sql, parameter);
            bool hasRows = dataReader.HasRows;
            dataReader.Close();
            return hasRows;
        }

        public int UpdateSort(Guid id, int sort)
        {
            string sql = "UPDATE Menu SET Sort=:Sort WHERE ID=:ID";
            OracleParameter[] oracleParameterArray = new OracleParameter[2];
            int index1 = 0;
            OracleParameter oracleParameter1 = new OracleParameter(":Sort", OracleDbType.Int32);
            oracleParameter1.Value = (object)sort;
            oracleParameterArray[index1] = oracleParameter1;
            int index2 = 1;
            OracleParameter oracleParameter2 = new OracleParameter(":ID", OracleDbType.Varchar2);
            oracleParameter2.Value = (object)id;
            oracleParameterArray[index2] = oracleParameter2;
            OracleParameter[] parameter = oracleParameterArray;
            return this.dbHelper.Execute(sql, parameter);
        }

        public int GetMaxSort(Guid id)
        {
            string sql = "SELECT MAX(Sort) FROM Menu WHERE ParentID=:ParentID";
            OracleParameter[] oracleParameterArray = new OracleParameter[1];
            int index = 0;
            OracleParameter oracleParameter = new OracleParameter(":ParentID", OracleDbType.Varchar2);
            oracleParameter.Value = (object)id;
            oracleParameterArray[index] = oracleParameter;
            OracleParameter[] parameter = oracleParameterArray;
            return this.dbHelper.GetFieldValue(sql, parameter).ToInt(0) + 1;
        }

        public List<RoadFlow.Data.Model.Menu> GetAllByApplibaryID(Guid applibaryID)
        {
            string sql = "SELECT * FROM Menu WHERE AppLibraryID=:AppLibraryID";
            OracleParameter[] oracleParameterArray = new OracleParameter[1];
            int index = 0;
            OracleParameter oracleParameter = new OracleParameter(":AppLibraryID", OracleDbType.Varchar2);
            oracleParameter.Value = (object)applibaryID.ToString();
            oracleParameterArray[index] = oracleParameter;
            OracleParameter[] parameter = oracleParameterArray;
            OracleDataReader dataReader = this.dbHelper.GetDataReader(sql, parameter);
            List<RoadFlow.Data.Model.Menu> list = this.DataReaderToList(dataReader);
            dataReader.Close();
            return list;
        }
    }
}