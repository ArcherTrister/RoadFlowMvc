// Decompiled with JetBrains decompiler
// Type: RoadFlow.Data.ORACLE.DocumentDirectory
// Assembly: RoadFlow.Data.ORACLE, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: C9018AA1-E48E-4231-92A9-CD6F0F275D11
// Assembly location: C:\inetpub\wwwroot\RoadFlowMvc\bin\RoadFlow.Data.ORACLE.dll

using Oracle.ManagedDataAccess.Client;
using RoadFlow.Data.Interface;
using System;
using System.Collections.Generic;

namespace RoadFlow.Data.ORACLE
{
    public class DocumentDirectory : IDocumentDirectory
    {
        private DBHelper dbHelper = new DBHelper();

        public int Add(RoadFlow.Data.Model.DocumentDirectory model)
        {
            string sql = "INSERT INTO DocumentDirectory\r\n\t\t\t\t(ID,ParentID,Name,ReadUsers,ManageUsers,PublishUsers,Sort) \r\n\t\t\t\tVALUES(:ID,:ParentID,:Name,:ReadUsers,:ManageUsers,:PublishUsers,:Sort)";
            OracleParameter[] oracleParameterArray = new OracleParameter[7];
            int index1 = 0;
            OracleParameter oracleParameter1 = new OracleParameter(":ID", OracleDbType.Varchar2);
            oracleParameter1.Value = (object)model.ID;
            oracleParameterArray[index1] = oracleParameter1;
            int index2 = 1;
            OracleParameter oracleParameter2 = new OracleParameter(":ParentID", OracleDbType.Varchar2);
            oracleParameter2.Value = (object)model.ParentID;
            oracleParameterArray[index2] = oracleParameter2;
            int index3 = 2;
            OracleParameter oracleParameter3 = new OracleParameter(":Name", OracleDbType.Varchar2);
            oracleParameter3.Value = (object)model.Name;
            oracleParameterArray[index3] = oracleParameter3;
            int index4 = 3;
            OracleParameter oracleParameter4;
            if (model.ReadUsers != null)
            {
                OracleParameter oracleParameter5 = new OracleParameter(":ReadUsers", OracleDbType.Varchar2);
                oracleParameter5.Value = (object)model.ReadUsers;
                oracleParameter4 = oracleParameter5;
            }
            else
            {
                oracleParameter4 = new OracleParameter(":ReadUsers", OracleDbType.Varchar2);
                oracleParameter4.Value = (object)DBNull.Value;
            }
            oracleParameterArray[index4] = oracleParameter4;
            int index5 = 4;
            OracleParameter oracleParameter6;
            if (model.ManageUsers != null)
            {
                OracleParameter oracleParameter5 = new OracleParameter(":ManageUsers", OracleDbType.Varchar2);
                oracleParameter5.Value = (object)model.ManageUsers;
                oracleParameter6 = oracleParameter5;
            }
            else
            {
                oracleParameter6 = new OracleParameter(":ManageUsers", OracleDbType.Varchar2);
                oracleParameter6.Value = (object)DBNull.Value;
            }
            oracleParameterArray[index5] = oracleParameter6;
            int index6 = 5;
            OracleParameter oracleParameter7;
            if (model.PublishUsers != null)
            {
                OracleParameter oracleParameter5 = new OracleParameter(":PublishUsers", OracleDbType.Varchar2);
                oracleParameter5.Value = (object)model.PublishUsers;
                oracleParameter7 = oracleParameter5;
            }
            else
            {
                oracleParameter7 = new OracleParameter(":PublishUsers", OracleDbType.Varchar2);
                oracleParameter7.Value = (object)DBNull.Value;
            }
            oracleParameterArray[index6] = oracleParameter7;
            int index7 = 6;
            OracleParameter oracleParameter8 = new OracleParameter(":Sort", OracleDbType.Int32);
            oracleParameter8.Value = (object)model.Sort;
            oracleParameterArray[index7] = oracleParameter8;
            OracleParameter[] parameter = oracleParameterArray;
            return this.dbHelper.Execute(sql, parameter);
        }

        public int Update(RoadFlow.Data.Model.DocumentDirectory model)
        {
            string sql = "UPDATE DocumentDirectory SET \r\n\t\t\t\tParentID=:ParentID,Name=:Name,ReadUsers=:ReadUsers,ManageUsers=:ManageUsers,PublishUsers=:PublishUsers,Sort=:Sort\r\n\t\t\t\tWHERE ID=:ID";
            OracleParameter[] oracleParameterArray = new OracleParameter[7];
            int index1 = 0;
            OracleParameter oracleParameter1 = new OracleParameter(":ParentID", OracleDbType.Varchar2);
            oracleParameter1.Value = (object)model.ParentID;
            oracleParameterArray[index1] = oracleParameter1;
            int index2 = 1;
            OracleParameter oracleParameter2 = new OracleParameter(":Name", OracleDbType.Varchar2);
            oracleParameter2.Value = (object)model.Name;
            oracleParameterArray[index2] = oracleParameter2;
            int index3 = 2;
            OracleParameter oracleParameter3;
            if (model.ReadUsers != null)
            {
                OracleParameter oracleParameter4 = new OracleParameter(":ReadUsers", OracleDbType.Varchar2);
                oracleParameter4.Value = (object)model.ReadUsers;
                oracleParameter3 = oracleParameter4;
            }
            else
            {
                oracleParameter3 = new OracleParameter(":ReadUsers", OracleDbType.Varchar2);
                oracleParameter3.Value = (object)DBNull.Value;
            }
            oracleParameterArray[index3] = oracleParameter3;
            int index4 = 3;
            OracleParameter oracleParameter5;
            if (model.ManageUsers != null)
            {
                OracleParameter oracleParameter4 = new OracleParameter(":ManageUsers", OracleDbType.Varchar2);
                oracleParameter4.Value = (object)model.ManageUsers;
                oracleParameter5 = oracleParameter4;
            }
            else
            {
                oracleParameter5 = new OracleParameter(":ManageUsers", OracleDbType.Varchar2);
                oracleParameter5.Value = (object)DBNull.Value;
            }
            oracleParameterArray[index4] = oracleParameter5;
            int index5 = 4;
            OracleParameter oracleParameter6;
            if (model.PublishUsers != null)
            {
                OracleParameter oracleParameter4 = new OracleParameter(":PublishUsers", OracleDbType.Varchar2);
                oracleParameter4.Value = (object)model.PublishUsers;
                oracleParameter6 = oracleParameter4;
            }
            else
            {
                oracleParameter6 = new OracleParameter(":PublishUsers", OracleDbType.Varchar2);
                oracleParameter6.Value = (object)DBNull.Value;
            }
            oracleParameterArray[index5] = oracleParameter6;
            int index6 = 5;
            OracleParameter oracleParameter7 = new OracleParameter(":Sort", OracleDbType.Int32);
            oracleParameter7.Value = (object)model.Sort;
            oracleParameterArray[index6] = oracleParameter7;
            int index7 = 6;
            OracleParameter oracleParameter8 = new OracleParameter(":ID", OracleDbType.Varchar2);
            oracleParameter8.Value = (object)model.ID;
            oracleParameterArray[index7] = oracleParameter8;
            OracleParameter[] parameter = oracleParameterArray;
            return this.dbHelper.Execute(sql, parameter);
        }

        public int Delete(Guid id)
        {
            string sql = "DELETE FROM DocumentDirectory WHERE ID=:ID";
            OracleParameter[] oracleParameterArray = new OracleParameter[1];
            int index = 0;
            OracleParameter oracleParameter = new OracleParameter(":ID", OracleDbType.Varchar2);
            oracleParameter.Value = (object)id;
            oracleParameterArray[index] = oracleParameter;
            OracleParameter[] parameter = oracleParameterArray;
            return this.dbHelper.Execute(sql, parameter);
        }

        private List<RoadFlow.Data.Model.DocumentDirectory> DataReaderToList(OracleDataReader dataReader)
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
            OracleDataReader dataReader = this.dbHelper.GetDataReader("SELECT * FROM DocumentDirectory");
            List<RoadFlow.Data.Model.DocumentDirectory> list = this.DataReaderToList(dataReader);
            dataReader.Close();
            return list;
        }

        public long GetCount()
        {
            long result;
            if (!long.TryParse(this.dbHelper.GetFieldValue("SELECT COUNT(*) FROM DocumentDirectory"), out result))
                return 0;
            return result;
        }

        public RoadFlow.Data.Model.DocumentDirectory Get(Guid id)
        {
            string sql = "SELECT * FROM DocumentDirectory WHERE ID=:ID";
            OracleParameter[] oracleParameterArray = new OracleParameter[1];
            int index = 0;
            OracleParameter oracleParameter = new OracleParameter(":ID", OracleDbType.Varchar2);
            oracleParameter.Value = (object)id.ToString();
            oracleParameterArray[index] = oracleParameter;
            OracleParameter[] parameter = oracleParameterArray;
            OracleDataReader dataReader = this.dbHelper.GetDataReader(sql, parameter);
            List<RoadFlow.Data.Model.DocumentDirectory> list = this.DataReaderToList(dataReader);
            dataReader.Close();
            if (list.Count <= 0)
                return (RoadFlow.Data.Model.DocumentDirectory)null;
            return list[0];
        }

        public List<RoadFlow.Data.Model.DocumentDirectory> GetChilds(Guid id)
        {
            string sql = "SELECT * FROM DocumentDirectory WHERE ParentID=:ParentID ORDER BY Sort";
            OracleParameter[] oracleParameterArray = new OracleParameter[1];
            int index = 0;
            OracleParameter oracleParameter = new OracleParameter(":ParentID", OracleDbType.Varchar2);
            oracleParameter.Value = (object)id.ToString();
            oracleParameterArray[index] = oracleParameter;
            OracleParameter[] parameter = oracleParameterArray;
            OracleDataReader dataReader = this.dbHelper.GetDataReader(sql, parameter);
            List<RoadFlow.Data.Model.DocumentDirectory> list = this.DataReaderToList(dataReader);
            dataReader.Close();
            return list;
        }

        public int GetMaxSort(Guid dirID)
        {
            string sql = "SELECT MAX(Sort) Sort FROM DocumentDirectory WHERE ParentID=:ParentID ";
            OracleParameter[] oracleParameterArray = new OracleParameter[1];
            int index = 0;
            OracleParameter oracleParameter = new OracleParameter(":ParentID", OracleDbType.Varchar2);
            oracleParameter.Value = (object)dirID.ToString();
            oracleParameterArray[index] = oracleParameter;
            OracleParameter[] parameter = oracleParameterArray;
            return this.dbHelper.GetFieldValue(sql, parameter).ToInt(0) + 5;
        }
    }
}