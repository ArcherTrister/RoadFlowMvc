// Decompiled with JetBrains decompiler
// Type: RoadFlow.Data.MySql.AppLibraryButtons
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
    public class AppLibraryButtons : IAppLibraryButtons
    {
        private DBHelper dbHelper = new DBHelper();

        public int Add(RoadFlow.Data.Model.AppLibraryButtons model)
        {
            string sql = "INSERT INTO applibrarybuttons(ID,Name,Events,Ico,Sort,Note) VALUES(@ID,@Name,@Events,@Ico,@Sort,@Note)";
            MySqlParameter[] mySqlParameterArray = new MySqlParameter[6];
            MySqlParameter mySqlParameter1 = new MySqlParameter("@ID", MySqlDbType.VarChar, 36);
            mySqlParameter1.Value = (object)model.ID;
            mySqlParameterArray[0] = mySqlParameter1;
            MySqlParameter mySqlParameter2 = new MySqlParameter("@Name", MySqlDbType.VarChar, 50);
            mySqlParameter2.Value = (object)model.Name;
            mySqlParameterArray[1] = mySqlParameter2;
            MySqlParameter mySqlParameter3 = new MySqlParameter("@Events", MySqlDbType.Text, -1);
            mySqlParameter3.Value = (object)model.Events;
            mySqlParameterArray[2] = mySqlParameter3;
            MySqlParameter mySqlParameter4;
            if (model.Ico != null)
            {
                MySqlParameter mySqlParameter5 = new MySqlParameter("@Ico", MySqlDbType.Text, -1);
                mySqlParameter5.Value = (object)model.Ico;
                mySqlParameter4 = mySqlParameter5;
            }
            else
            {
                mySqlParameter4 = new MySqlParameter("@Ico", MySqlDbType.Text, -1);
                mySqlParameter4.Value = (object)DBNull.Value;
            }
            mySqlParameterArray[3] = mySqlParameter4;
            MySqlParameter mySqlParameter6 = new MySqlParameter("@Sort", MySqlDbType.Int32, 11);
            mySqlParameter6.Value = (object)model.Sort;
            mySqlParameterArray[4] = mySqlParameter6;
            MySqlParameter mySqlParameter7;
            if (model.Note != null)
            {
                MySqlParameter mySqlParameter5 = new MySqlParameter("@Note", MySqlDbType.Text, -1);
                mySqlParameter5.Value = (object)model.Note;
                mySqlParameter7 = mySqlParameter5;
            }
            else
            {
                mySqlParameter7 = new MySqlParameter("@Note", MySqlDbType.Text, -1);
                mySqlParameter7.Value = (object)DBNull.Value;
            }
            mySqlParameterArray[5] = mySqlParameter7;
            MySqlParameter[] parameter = mySqlParameterArray;
            return this.dbHelper.Execute(sql, parameter, false);
        }

        public int Update(RoadFlow.Data.Model.AppLibraryButtons model)
        {
            string sql = "UPDATE applibrarybuttons SET Name=@Name,Events=@Events,Ico=@Ico,Sort=@Sort,Note=@Note WHERE ID=@ID";
            MySqlParameter[] mySqlParameterArray = new MySqlParameter[6];
            MySqlParameter mySqlParameter1 = new MySqlParameter("@Name", MySqlDbType.VarChar, 50);
            mySqlParameter1.Value = (object)model.Name;
            mySqlParameterArray[0] = mySqlParameter1;
            MySqlParameter mySqlParameter2 = new MySqlParameter("@Events", MySqlDbType.Text, -1);
            mySqlParameter2.Value = (object)model.Events;
            mySqlParameterArray[1] = mySqlParameter2;
            MySqlParameter mySqlParameter3;
            if (model.Ico != null)
            {
                MySqlParameter mySqlParameter4 = new MySqlParameter("@Ico", MySqlDbType.Text, -1);
                mySqlParameter4.Value = (object)model.Ico;
                mySqlParameter3 = mySqlParameter4;
            }
            else
            {
                mySqlParameter3 = new MySqlParameter("@Ico", MySqlDbType.Text, -1);
                mySqlParameter3.Value = (object)DBNull.Value;
            }
            mySqlParameterArray[2] = mySqlParameter3;
            MySqlParameter mySqlParameter5 = new MySqlParameter("@Sort", MySqlDbType.Int32, 11);
            mySqlParameter5.Value = (object)model.Sort;
            mySqlParameterArray[3] = mySqlParameter5;
            MySqlParameter mySqlParameter6;
            if (model.Note != null)
            {
                MySqlParameter mySqlParameter4 = new MySqlParameter("@Note", MySqlDbType.Text, -1);
                mySqlParameter4.Value = (object)model.Note;
                mySqlParameter6 = mySqlParameter4;
            }
            else
            {
                mySqlParameter6 = new MySqlParameter("@Note", MySqlDbType.Text, -1);
                mySqlParameter6.Value = (object)DBNull.Value;
            }
            mySqlParameterArray[4] = mySqlParameter6;
            MySqlParameter mySqlParameter7 = new MySqlParameter("@ID", MySqlDbType.VarChar, 36);
            mySqlParameter7.Value = (object)model.ID;
            mySqlParameterArray[5] = mySqlParameter7;
            MySqlParameter[] parameter = mySqlParameterArray;
            return this.dbHelper.Execute(sql, parameter, false);
        }

        public int Delete(Guid id)
        {
            string sql = "DELETE FROM applibrarybuttons WHERE ID=@ID";
            MySqlParameter[] mySqlParameterArray = new MySqlParameter[1];
            MySqlParameter mySqlParameter = new MySqlParameter("@ID", MySqlDbType.VarChar, 36);
            mySqlParameter.Value = (object)id.ToString();
            mySqlParameterArray[0] = mySqlParameter;
            MySqlParameter[] parameter = mySqlParameterArray;
            return this.dbHelper.Execute(sql, parameter, false);
        }

        private List<RoadFlow.Data.Model.AppLibraryButtons> DataReaderToList(MySqlDataReader dataReader)
        {
            List<RoadFlow.Data.Model.AppLibraryButtons> appLibraryButtonsList = new List<RoadFlow.Data.Model.AppLibraryButtons>();
            while (dataReader.Read())
            {
                RoadFlow.Data.Model.AppLibraryButtons appLibraryButtons = new RoadFlow.Data.Model.AppLibraryButtons();
                appLibraryButtons.ID = dataReader.GetString(0).ToGuid();
                appLibraryButtons.Name = dataReader.GetString(1);
                appLibraryButtons.Events = dataReader.GetString(2);
                if (!dataReader.IsDBNull(3))
                    appLibraryButtons.Ico = dataReader.GetString(3);
                appLibraryButtons.Sort = dataReader.GetInt32(4);
                if (!dataReader.IsDBNull(5))
                    appLibraryButtons.Note = dataReader.GetString(5);
                appLibraryButtonsList.Add(appLibraryButtons);
            }
            return appLibraryButtonsList;
        }

        public List<RoadFlow.Data.Model.AppLibraryButtons> GetAll()
        {
            MySqlDataReader dataReader = this.dbHelper.GetDataReader("SELECT * FROM applibrarybuttons");
            List<RoadFlow.Data.Model.AppLibraryButtons> list = this.DataReaderToList(dataReader);
            dataReader.Close();
            return list;
        }

        public long GetCount()
        {
            long result;
            if (!long.TryParse(this.dbHelper.GetFieldValue("SELECT COUNT(*) FROM applibrarybuttons"), out result))
                return 0;
            return result;
        }

        public RoadFlow.Data.Model.AppLibraryButtons Get(Guid id)
        {
            string sql = "SELECT * FROM applibrarybuttons WHERE ID=@ID";
            MySqlParameter[] mySqlParameterArray = new MySqlParameter[1];
            int index = 0;
            MySqlParameter mySqlParameter = new MySqlParameter("@ID", MySqlDbType.VarChar, 36);
            mySqlParameter.Value = (object)id.ToString();
            mySqlParameterArray[index] = mySqlParameter;
            MySqlParameter[] parameter = mySqlParameterArray;
            MySqlDataReader dataReader = this.dbHelper.GetDataReader(sql, parameter);
            List<RoadFlow.Data.Model.AppLibraryButtons> list = this.DataReaderToList(dataReader);
            dataReader.Close();
            if (list.Count <= 0)
                return (RoadFlow.Data.Model.AppLibraryButtons)null;
            return list[0];
        }

        public List<RoadFlow.Data.Model.AppLibraryButtons> GetPagerData(out string pager, string query = "", int size = 15, int number = 1, string title = "")
        {
            StringBuilder stringBuilder = new StringBuilder();
            List<MySqlParameter> mySqlParameterList1 = new List<MySqlParameter>();
            if (!title.IsNullOrEmpty())
            {
                stringBuilder.Append("AND INSTR(Name,@Name)>0 ");
                List<MySqlParameter> mySqlParameterList2 = mySqlParameterList1;
                MySqlParameter mySqlParameter = new MySqlParameter("@Name", MySqlDbType.VarChar);
                mySqlParameter.Value = (object)title;
                mySqlParameterList2.Add(mySqlParameter);
            }
            long count;
            string paerSql = this.dbHelper.GetPaerSql("AppLibraryButtons", "*", stringBuilder.ToString(), "Sort DESC", size, number, out count, mySqlParameterList1.ToArray());
            pager = Tools.GetPagerHtml(count, size, number, query);
            MySqlDataReader dataReader = this.dbHelper.GetDataReader(paerSql, mySqlParameterList1.ToArray());
            List<RoadFlow.Data.Model.AppLibraryButtons> list = this.DataReaderToList(dataReader);
            dataReader.Close();
            return list;
        }

        public List<RoadFlow.Data.Model.AppLibraryButtons> GetPagerData(out long count, int size, int number, string title = "", string order = "")
        {
            StringBuilder stringBuilder = new StringBuilder();
            List<MySqlParameter> mySqlParameterList1 = new List<MySqlParameter>();
            if (!title.IsNullOrEmpty())
            {
                stringBuilder.Append("AND INSTR(Name,@Name)>0 ");
                List<MySqlParameter> mySqlParameterList2 = mySqlParameterList1;
                MySqlParameter mySqlParameter = new MySqlParameter("@Name", MySqlDbType.VarChar);
                mySqlParameter.Value = (object)title;
                mySqlParameterList2.Add(mySqlParameter);
            }
            MySqlDataReader dataReader = this.dbHelper.GetDataReader(this.dbHelper.GetPaerSql("AppLibraryButtons", "*", stringBuilder.ToString(), order.IsNullOrEmpty() ? "Sort DESC" : order, size, number, out count, mySqlParameterList1.ToArray()), mySqlParameterList1.ToArray());
            List<RoadFlow.Data.Model.AppLibraryButtons> list = this.DataReaderToList(dataReader);
            dataReader.Close();
            return list;
        }

        public int GetMaxSort()
        {
            return this.dbHelper.GetFieldValue("SELECT IFNULL(MAX(Sort),0)+5 FROM AppLibraryButtons").ToInt();
        }
    }
}