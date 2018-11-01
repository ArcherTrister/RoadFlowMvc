// Decompiled with JetBrains decompiler
// Type: RoadFlow.Data.MySql.AppLibrary
// Assembly: RoadFlow.Data.MySql, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 29B652D7-5F6F-4A7D-AD1C-9F2C643FD784
// Assembly location: C:\inetpub\wwwroot\RoadFlowMvc\bin\RoadFlow.Data.MySql.dll

using MySql.Data.MySqlClient;
using RoadFlow.Data.Interface;
using RoadFlow.Utility;
using System;
using System.Collections.Generic;
using System.Text;

namespace RoadFlow.Data.MySql
{
    public class AppLibrary : IAppLibrary
    {
        private DBHelper dbHelper = new DBHelper();

        public int Add(RoadFlow.Data.Model.AppLibrary model)
        {
            string sql = "INSERT INTO applibrary\r\n\t\t\t\t(ID,Title,Address,Type,OpenMode,Width,Height,Params,Manager,Note,Code,Ico,Color) \r\n\t\t\t\tVALUES(@ID,@Title,@Address,@Type,@OpenMode,@Width,@Height,@Params,@Manager,@Note,@Code,@Ico,@Color)";
            MySqlParameter[] mySqlParameterArray = new MySqlParameter[13];
            int index1 = 0;
            MySqlParameter mySqlParameter1 = new MySqlParameter("@ID", MySqlDbType.VarChar, 36);
            mySqlParameter1.Value = (object)model.ID;
            mySqlParameterArray[index1] = mySqlParameter1;
            int index2 = 1;
            MySqlParameter mySqlParameter2 = new MySqlParameter("@Title", MySqlDbType.VarChar, (int)byte.MaxValue);
            mySqlParameter2.Value = (object)model.Title;
            mySqlParameterArray[index2] = mySqlParameter2;
            int index3 = 2;
            MySqlParameter mySqlParameter3 = new MySqlParameter("@Address", MySqlDbType.Text, -1);
            mySqlParameter3.Value = (object)model.Address;
            mySqlParameterArray[index3] = mySqlParameter3;
            int index4 = 3;
            MySqlParameter mySqlParameter4 = new MySqlParameter("@Type", MySqlDbType.VarChar, 36);
            mySqlParameter4.Value = (object)model.Type;
            mySqlParameterArray[index4] = mySqlParameter4;
            int index5 = 4;
            MySqlParameter mySqlParameter5 = new MySqlParameter("@OpenMode", MySqlDbType.Int32, 11);
            mySqlParameter5.Value = (object)model.OpenMode;
            mySqlParameterArray[index5] = mySqlParameter5;
            int index6 = 5;
            MySqlParameter mySqlParameter6;
            if (model.Width.HasValue)
            {
                MySqlParameter mySqlParameter7 = new MySqlParameter("@Width", MySqlDbType.Int32, 11);
                mySqlParameter7.Value = (object)model.Width;
                mySqlParameter6 = mySqlParameter7;
            }
            else
            {
                mySqlParameter6 = new MySqlParameter("@Width", MySqlDbType.Int32, 11);
                mySqlParameter6.Value = (object)DBNull.Value;
            }
            mySqlParameterArray[index6] = mySqlParameter6;
            int index7 = 6;
            MySqlParameter mySqlParameter8;
            if (model.Height.HasValue)
            {
                MySqlParameter mySqlParameter7 = new MySqlParameter("@Height", MySqlDbType.Int32, 11);
                mySqlParameter7.Value = (object)model.Height;
                mySqlParameter8 = mySqlParameter7;
            }
            else
            {
                mySqlParameter8 = new MySqlParameter("@Height", MySqlDbType.Int32, 11);
                mySqlParameter8.Value = (object)DBNull.Value;
            }
            mySqlParameterArray[index7] = mySqlParameter8;
            int index8 = 7;
            MySqlParameter mySqlParameter9;
            if (model.Params != null)
            {
                MySqlParameter mySqlParameter7 = new MySqlParameter("@Params", MySqlDbType.LongText, -1);
                mySqlParameter7.Value = (object)model.Params;
                mySqlParameter9 = mySqlParameter7;
            }
            else
            {
                mySqlParameter9 = new MySqlParameter("@Params", MySqlDbType.LongText, -1);
                mySqlParameter9.Value = (object)DBNull.Value;
            }
            mySqlParameterArray[index8] = mySqlParameter9;
            int index9 = 8;
            MySqlParameter mySqlParameter10;
            if (model.Manager != null)
            {
                MySqlParameter mySqlParameter7 = new MySqlParameter("@Manager", MySqlDbType.LongText, -1);
                mySqlParameter7.Value = (object)model.Manager;
                mySqlParameter10 = mySqlParameter7;
            }
            else
            {
                mySqlParameter10 = new MySqlParameter("@Manager", MySqlDbType.LongText, -1);
                mySqlParameter10.Value = (object)DBNull.Value;
            }
            mySqlParameterArray[index9] = mySqlParameter10;
            int index10 = 9;
            MySqlParameter mySqlParameter11;
            if (model.Note != null)
            {
                MySqlParameter mySqlParameter7 = new MySqlParameter("@Note", MySqlDbType.LongText, -1);
                mySqlParameter7.Value = (object)model.Note;
                mySqlParameter11 = mySqlParameter7;
            }
            else
            {
                mySqlParameter11 = new MySqlParameter("@Note", MySqlDbType.LongText, -1);
                mySqlParameter11.Value = (object)DBNull.Value;
            }
            mySqlParameterArray[index10] = mySqlParameter11;
            int index11 = 10;
            MySqlParameter mySqlParameter12;
            if (model.Code != null)
            {
                MySqlParameter mySqlParameter7 = new MySqlParameter("@Code", MySqlDbType.VarChar, 50);
                mySqlParameter7.Value = (object)model.Code;
                mySqlParameter12 = mySqlParameter7;
            }
            else
            {
                mySqlParameter12 = new MySqlParameter("@Code", MySqlDbType.VarChar, 50);
                mySqlParameter12.Value = (object)DBNull.Value;
            }
            mySqlParameterArray[index11] = mySqlParameter12;
            int index12 = 11;
            MySqlParameter mySqlParameter13;
            if (model.Ico != null)
            {
                MySqlParameter mySqlParameter7 = new MySqlParameter("@Ico", MySqlDbType.Text, -1);
                mySqlParameter7.Value = (object)model.Ico;
                mySqlParameter13 = mySqlParameter7;
            }
            else
            {
                mySqlParameter13 = new MySqlParameter("@Ico", MySqlDbType.Text, -1);
                mySqlParameter13.Value = (object)DBNull.Value;
            }
            mySqlParameterArray[index12] = mySqlParameter13;
            int index13 = 12;
            MySqlParameter mySqlParameter14;
            if (model.Color != null)
            {
                MySqlParameter mySqlParameter7 = new MySqlParameter("@Color", MySqlDbType.VarChar, 50);
                mySqlParameter7.Value = (object)model.Color;
                mySqlParameter14 = mySqlParameter7;
            }
            else
            {
                mySqlParameter14 = new MySqlParameter("@Color", MySqlDbType.VarChar, 50);
                mySqlParameter14.Value = (object)DBNull.Value;
            }
            mySqlParameterArray[index13] = mySqlParameter14;
            MySqlParameter[] parameter = mySqlParameterArray;
            return this.dbHelper.Execute(sql, parameter, false);
        }

        public int Update(RoadFlow.Data.Model.AppLibrary model)
        {
            string sql = "UPDATE applibrary SET \r\n\t\t\t\tTitle=@Title,Address=@Address,Type=@Type,OpenMode=@OpenMode,Width=@Width,Height=@Height,Params=@Params,Manager=@Manager,Note=@Note,Code=@Code,Ico=@Ico,Color=@Color\r\n\t\t\t\tWHERE ID=@ID";
            MySqlParameter[] mySqlParameterArray = new MySqlParameter[13];
            int index1 = 0;
            MySqlParameter mySqlParameter1 = new MySqlParameter("@Title", MySqlDbType.VarChar, (int)byte.MaxValue);
            mySqlParameter1.Value = (object)model.Title;
            mySqlParameterArray[index1] = mySqlParameter1;
            int index2 = 1;
            MySqlParameter mySqlParameter2 = new MySqlParameter("@Address", MySqlDbType.Text, -1);
            mySqlParameter2.Value = (object)model.Address;
            mySqlParameterArray[index2] = mySqlParameter2;
            int index3 = 2;
            MySqlParameter mySqlParameter3 = new MySqlParameter("@Type", MySqlDbType.VarChar, 36);
            mySqlParameter3.Value = (object)model.Type;
            mySqlParameterArray[index3] = mySqlParameter3;
            int index4 = 3;
            MySqlParameter mySqlParameter4 = new MySqlParameter("@OpenMode", MySqlDbType.Int32, 11);
            mySqlParameter4.Value = (object)model.OpenMode;
            mySqlParameterArray[index4] = mySqlParameter4;
            int index5 = 4;
            MySqlParameter mySqlParameter5;
            if (model.Width.HasValue)
            {
                MySqlParameter mySqlParameter6 = new MySqlParameter("@Width", MySqlDbType.Int32, 11);
                mySqlParameter6.Value = (object)model.Width;
                mySqlParameter5 = mySqlParameter6;
            }
            else
            {
                mySqlParameter5 = new MySqlParameter("@Width", MySqlDbType.Int32, 11);
                mySqlParameter5.Value = (object)DBNull.Value;
            }
            mySqlParameterArray[index5] = mySqlParameter5;
            int index6 = 5;
            MySqlParameter mySqlParameter7;
            if (model.Height.HasValue)
            {
                MySqlParameter mySqlParameter6 = new MySqlParameter("@Height", MySqlDbType.Int32, 11);
                mySqlParameter6.Value = (object)model.Height;
                mySqlParameter7 = mySqlParameter6;
            }
            else
            {
                mySqlParameter7 = new MySqlParameter("@Height", MySqlDbType.Int32, 11);
                mySqlParameter7.Value = (object)DBNull.Value;
            }
            mySqlParameterArray[index6] = mySqlParameter7;
            int index7 = 6;
            MySqlParameter mySqlParameter8;
            if (model.Params != null)
            {
                MySqlParameter mySqlParameter6 = new MySqlParameter("@Params", MySqlDbType.LongText, -1);
                mySqlParameter6.Value = (object)model.Params;
                mySqlParameter8 = mySqlParameter6;
            }
            else
            {
                mySqlParameter8 = new MySqlParameter("@Params", MySqlDbType.LongText, -1);
                mySqlParameter8.Value = (object)DBNull.Value;
            }
            mySqlParameterArray[index7] = mySqlParameter8;
            int index8 = 7;
            MySqlParameter mySqlParameter9;
            if (model.Manager != null)
            {
                MySqlParameter mySqlParameter6 = new MySqlParameter("@Manager", MySqlDbType.LongText, -1);
                mySqlParameter6.Value = (object)model.Manager;
                mySqlParameter9 = mySqlParameter6;
            }
            else
            {
                mySqlParameter9 = new MySqlParameter("@Manager", MySqlDbType.LongText, -1);
                mySqlParameter9.Value = (object)DBNull.Value;
            }
            mySqlParameterArray[index8] = mySqlParameter9;
            int index9 = 8;
            MySqlParameter mySqlParameter10;
            if (model.Note != null)
            {
                MySqlParameter mySqlParameter6 = new MySqlParameter("@Note", MySqlDbType.LongText, -1);
                mySqlParameter6.Value = (object)model.Note;
                mySqlParameter10 = mySqlParameter6;
            }
            else
            {
                mySqlParameter10 = new MySqlParameter("@Note", MySqlDbType.LongText, -1);
                mySqlParameter10.Value = (object)DBNull.Value;
            }
            mySqlParameterArray[index9] = mySqlParameter10;
            int index10 = 9;
            MySqlParameter mySqlParameter11;
            if (model.Code != null)
            {
                MySqlParameter mySqlParameter6 = new MySqlParameter("@Code", MySqlDbType.VarChar, 50);
                mySqlParameter6.Value = (object)model.Code;
                mySqlParameter11 = mySqlParameter6;
            }
            else
            {
                mySqlParameter11 = new MySqlParameter("@Code", MySqlDbType.VarChar, 50);
                mySqlParameter11.Value = (object)DBNull.Value;
            }
            mySqlParameterArray[index10] = mySqlParameter11;
            int index11 = 10;
            MySqlParameter mySqlParameter12;
            if (model.Ico != null)
            {
                MySqlParameter mySqlParameter6 = new MySqlParameter("@Ico", MySqlDbType.Text, -1);
                mySqlParameter6.Value = (object)model.Ico;
                mySqlParameter12 = mySqlParameter6;
            }
            else
            {
                mySqlParameter12 = new MySqlParameter("@Ico", MySqlDbType.Text, -1);
                mySqlParameter12.Value = (object)DBNull.Value;
            }
            mySqlParameterArray[index11] = mySqlParameter12;
            int index12 = 11;
            MySqlParameter mySqlParameter13;
            if (model.Color != null)
            {
                MySqlParameter mySqlParameter6 = new MySqlParameter("@Color", MySqlDbType.VarChar, 50);
                mySqlParameter6.Value = (object)model.Color;
                mySqlParameter13 = mySqlParameter6;
            }
            else
            {
                mySqlParameter13 = new MySqlParameter("@Color", MySqlDbType.VarChar, 50);
                mySqlParameter13.Value = (object)DBNull.Value;
            }
            mySqlParameterArray[index12] = mySqlParameter13;
            int index13 = 12;
            MySqlParameter mySqlParameter14 = new MySqlParameter("@ID", MySqlDbType.VarChar, 36);
            mySqlParameter14.Value = (object)model.ID;
            mySqlParameterArray[index13] = mySqlParameter14;
            MySqlParameter[] parameter = mySqlParameterArray;
            return this.dbHelper.Execute(sql, parameter, false);
        }

        public int Delete(Guid id)
        {
            string sql = "DELETE FROM applibrary WHERE ID=@ID";
            MySqlParameter[] mySqlParameterArray = new MySqlParameter[1];
            int index = 0;
            MySqlParameter mySqlParameter = new MySqlParameter("@ID", MySqlDbType.VarChar, 36);
            mySqlParameter.Value = (object)id.ToString();
            mySqlParameterArray[index] = mySqlParameter;
            MySqlParameter[] parameter = mySqlParameterArray;
            return this.dbHelper.Execute(sql, parameter, false);
        }

        private List<RoadFlow.Data.Model.AppLibrary> DataReaderToList(MySqlDataReader dataReader)
        {
            List<RoadFlow.Data.Model.AppLibrary> appLibraryList = new List<RoadFlow.Data.Model.AppLibrary>();
            while (dataReader.Read())
            {
                RoadFlow.Data.Model.AppLibrary appLibrary = new RoadFlow.Data.Model.AppLibrary();
                appLibrary.ID = dataReader.GetString(0).ToGuid();
                appLibrary.Title = dataReader.GetString(1);
                appLibrary.Address = dataReader.GetString(2);
                appLibrary.Type = dataReader.GetString(3).ToGuid();
                appLibrary.OpenMode = dataReader.GetInt32(4);
                if (!dataReader.IsDBNull(5))
                    appLibrary.Width = new int?(dataReader.GetInt32(5));
                if (!dataReader.IsDBNull(6))
                    appLibrary.Height = new int?(dataReader.GetInt32(6));
                if (!dataReader.IsDBNull(7))
                    appLibrary.Params = dataReader.GetString(7);
                if (!dataReader.IsDBNull(8))
                    appLibrary.Manager = dataReader.GetString(8);
                if (!dataReader.IsDBNull(9))
                    appLibrary.Note = dataReader.GetString(9);
                if (!dataReader.IsDBNull(10))
                    appLibrary.Code = dataReader.GetString(10);
                if (!dataReader.IsDBNull(11))
                    appLibrary.Ico = dataReader.GetString(11);
                if (!dataReader.IsDBNull(12))
                    appLibrary.Color = dataReader.GetString(12);
                appLibraryList.Add(appLibrary);
            }
            return appLibraryList;
        }

        public List<RoadFlow.Data.Model.AppLibrary> GetAll()
        {
            MySqlDataReader dataReader = this.dbHelper.GetDataReader("SELECT * FROM applibrary");
            List<RoadFlow.Data.Model.AppLibrary> list = this.DataReaderToList(dataReader);
            dataReader.Close();
            return list;
        }

        public long GetCount()
        {
            long result;
            if (!long.TryParse(this.dbHelper.GetFieldValue("SELECT COUNT(*) FROM applibrary"), out result))
                return 0;
            return result;
        }

        public RoadFlow.Data.Model.AppLibrary Get(Guid id)
        {
            string sql = "SELECT * FROM applibrary WHERE ID=@ID";
            MySqlParameter[] mySqlParameterArray = new MySqlParameter[1];
            int index = 0;
            MySqlParameter mySqlParameter = new MySqlParameter("@ID", MySqlDbType.VarChar, 36);
            mySqlParameter.Value = (object)id.ToString();
            mySqlParameterArray[index] = mySqlParameter;
            MySqlParameter[] parameter = mySqlParameterArray;
            MySqlDataReader dataReader = this.dbHelper.GetDataReader(sql, parameter);
            List<RoadFlow.Data.Model.AppLibrary> list = this.DataReaderToList(dataReader);
            dataReader.Close();
            if (list.Count <= 0)
                return (RoadFlow.Data.Model.AppLibrary)null;
            return list[0];
        }

        public List<RoadFlow.Data.Model.AppLibrary> GetPagerData(out string pager, string query = "", string order = "Type,Title", int size = 15, int number = 1, string title = "", string type = "", string address = "")
        {
            StringBuilder stringBuilder = new StringBuilder();
            List<MySqlParameter> mySqlParameterList1 = new List<MySqlParameter>();
            if (!title.IsNullOrEmpty())
            {
                stringBuilder.Append("AND INSTR(Title,@Title)>0 ");
                List<MySqlParameter> mySqlParameterList2 = mySqlParameterList1;
                MySqlParameter mySqlParameter = new MySqlParameter("@Title", MySqlDbType.VarChar);
                mySqlParameter.Value = (object)title;
                mySqlParameterList2.Add(mySqlParameter);
            }
            if (!type.IsNullOrEmpty())
                stringBuilder.AppendFormat("AND Type IN({0}) ", (object)Tools.GetSqlInString(type, true, ","));
            if (!address.IsNullOrEmpty())
            {
                stringBuilder.Append("AND INSTR(Address,@Address)>0 ");
                List<MySqlParameter> mySqlParameterList2 = mySqlParameterList1;
                MySqlParameter mySqlParameter = new MySqlParameter("@Address", MySqlDbType.VarChar);
                mySqlParameter.Value = (object)address;
                mySqlParameterList2.Add(mySqlParameter);
            }
            long count;
            string paerSql = this.dbHelper.GetPaerSql(nameof(AppLibrary), "*", stringBuilder.ToString(), order, size, number, out count, mySqlParameterList1.ToArray());
            pager = Tools.GetPagerHtml(count, size, number, query);
            MySqlDataReader dataReader = this.dbHelper.GetDataReader(paerSql, mySqlParameterList1.ToArray());
            List<RoadFlow.Data.Model.AppLibrary> list = this.DataReaderToList(dataReader);
            dataReader.Close();
            return list;
        }

        public List<RoadFlow.Data.Model.AppLibrary> GetPagerData(out long count, int size = 15, int number = 1, string title = "", string type = "", string address = "", string order = "")
        {
            StringBuilder stringBuilder = new StringBuilder();
            List<MySqlParameter> mySqlParameterList1 = new List<MySqlParameter>();
            if (!title.IsNullOrEmpty())
            {
                stringBuilder.Append("AND INSTR(Title,@Title)>0 ");
                List<MySqlParameter> mySqlParameterList2 = mySqlParameterList1;
                MySqlParameter mySqlParameter = new MySqlParameter("@Title", MySqlDbType.VarChar);
                mySqlParameter.Value = (object)title;
                mySqlParameterList2.Add(mySqlParameter);
            }
            if (!type.IsNullOrEmpty())
                stringBuilder.AppendFormat("AND Type IN({0}) ", (object)Tools.GetSqlInString(type, true, ","));
            if (!address.IsNullOrEmpty())
            {
                stringBuilder.Append("AND INSTR(Address,@Address)>0 ");
                List<MySqlParameter> mySqlParameterList2 = mySqlParameterList1;
                MySqlParameter mySqlParameter = new MySqlParameter("@Address", MySqlDbType.VarChar);
                mySqlParameter.Value = (object)address;
                mySqlParameterList2.Add(mySqlParameter);
            }
            MySqlDataReader dataReader = this.dbHelper.GetDataReader(this.dbHelper.GetPaerSql(nameof(AppLibrary), "*", stringBuilder.ToString(), order.IsNullOrEmpty() ? "Type,Title" : order, size, number, out count, mySqlParameterList1.ToArray()), mySqlParameterList1.ToArray());
            List<RoadFlow.Data.Model.AppLibrary> list = this.DataReaderToList(dataReader);
            dataReader.Close();
            return list;
        }

        public List<RoadFlow.Data.Model.AppLibrary> GetAllByType(string types)
        {
            MySqlDataReader dataReader = this.dbHelper.GetDataReader("SELECT * FROM AppLibrary WHERE Type IN(" + Tools.GetSqlInString(types, true, ",") + ")");
            List<RoadFlow.Data.Model.AppLibrary> list = this.DataReaderToList(dataReader);
            dataReader.Close();
            return list;
        }

        public int Delete(string[] idArray)
        {
            return this.dbHelper.Execute("DELETE FROM AppLibrary WHERE ID in(" + Tools.GetSqlInString<string>(idArray, true) + ")");
        }

        public RoadFlow.Data.Model.AppLibrary GetByCode(string code)
        {
            string sql = "SELECT * FROM AppLibrary WHERE Code=@Code";
            MySqlParameter[] mySqlParameterArray = new MySqlParameter[1];
            int index = 0;
            MySqlParameter mySqlParameter = new MySqlParameter("@Code", MySqlDbType.VarChar, 50);
            mySqlParameter.Value = (object)code;
            mySqlParameterArray[index] = mySqlParameter;
            MySqlParameter[] parameter = mySqlParameterArray;
            MySqlDataReader dataReader = this.dbHelper.GetDataReader(sql, parameter);
            List<RoadFlow.Data.Model.AppLibrary> list = this.DataReaderToList(dataReader);
            dataReader.Close();
            if (list.Count <= 0)
                return (RoadFlow.Data.Model.AppLibrary)null;
            return list[0];
        }
    }
}