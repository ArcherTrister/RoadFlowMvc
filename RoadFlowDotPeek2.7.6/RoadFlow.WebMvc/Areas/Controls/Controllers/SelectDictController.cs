// Decompiled with JetBrains decompiler
// Type: WebMvc.Areas.Controls.Controllers.SelectDictController
// Assembly: WebMvc, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 43FD7615-6DC3-49FB-B263-7F7CC91AFA77
// Assembly location: C:\inetpub\wwwroot\RoadFlowMvc\bin\WebMvc.dll

using Microsoft.CSharp.RuntimeBinder;
using System;
using System.Collections.Generic;
using System.Data;
using System.IO;
using System.Runtime.CompilerServices;
using System.Text;
using System.Web.Mvc;
using WebMvc.Common;

namespace WebMvc.Areas.Controls.Controllers
{
    public class SelectDictController : Controller
    {
        public ActionResult Index()
        {
            RoadFlow.Platform.Dictionary dictionary = new RoadFlow.Platform.Dictionary();
            string obj = base.Request.QueryString["values"] ?? "";
            string text12 = base.Request.QueryString["rootid"];
            string text = base.Request.QueryString["datasource"];
            string text2 = base.Request.QueryString["sql"];
            DataTable dataTable = new DataTable();
            if ("1" == text)
            {
                string text3 = base.Request.QueryString["dbconn"];
                RoadFlow.Platform.DBConnection dBConnection = new RoadFlow.Platform.DBConnection();
                RoadFlow.Data.Model.DBConnection dbconn = dBConnection.Get(MyExtensions.ToGuid(text3));
                dataTable = dBConnection.GetDataTable(dbconn, MyExtensions.ReplaceSelectSql(MyExtensions.UrlDecode(text2).FilterWildcard()));
            }
            StringBuilder stringBuilder = new StringBuilder();
            string[] array = obj.Split(',');
            foreach (string text4 in array)
            {
                if (!MyExtensions.IsNullOrEmpty(text4))
                {
                    if (!(text == "0"))
                    {
                        if (text == "1")
                        {
                            string value = string.Empty;
                            foreach (DataRow row in dataTable.Rows)
                            {
                                if (text4 == row[0].ToString())
                                {
                                    value = ((dataTable.Columns.Count > 1) ? row[1].ToString() : text4);
                                    break;
                                }
                            }
                            stringBuilder.AppendFormat("<div onclick=\"currentDel=this;showinfo('{0}');\" class=\"selectorDiv\" ondblclick=\"currentDel=this;del();\" value=\"{0}\">", text4);
                            stringBuilder.Append(value);
                            stringBuilder.Append("</div>");
                            continue;
                        }
                        if (text == "2")
                        {
                            string text5 = base.Request.QueryString["url2"];
                            if (!MyExtensions.IsNullOrEmpty(text5))
                            {
                                text5 = ((text5.IndexOf('?') >= 0) ? (text5 + "&values=" + text4) : (text5 + "?values=" + text4));
                                StringBuilder stringBuilder2 = new StringBuilder();
                                try
                                {
                                    TextWriter writer = new StringWriter(stringBuilder2);
                                    base.Server.Execute(text5, writer);
                                }
                                catch
                                {
                                }
                                stringBuilder.AppendFormat("<div onclick=\"currentDel=this;showinfo('{0}');\" class=\"selectorDiv\" ondblclick=\"currentDel=this;del();\" value=\"{0}\">", text4);
                                stringBuilder.Append(stringBuilder2.ToString());
                                stringBuilder.Append("</div>");
                            }
                            continue;
                        }
                        if (text == "3")
                        {
                            string text6 = base.Request.QueryString["dbconn"];
                            string text7 = base.Request.QueryString["dbtable"];
                            string text8 = base.Request.QueryString["valuefield"];
                            string text9 = base.Request.QueryString["titlefield"];
                            string text13 = base.Request.QueryString["parentfield"];
                            string text10 = base.Request.QueryString["where1"];
                            RoadFlow.Platform.DBConnection dBConnection2 = new RoadFlow.Platform.DBConnection();
                            RoadFlow.Data.Model.DBConnection dbconn2 = dBConnection2.Get(MyExtensions.ToGuid(text6));
                            string text11 = "select " + text9 + " from " + text7 + " where " + text8 + "='" + text4 + "'";
                            DataTable dataTable2 = dBConnection2.GetDataTable(dbconn2, MyExtensions.ReplaceSelectSql(text11));
                            string value2 = string.Empty;
                            if (dataTable2.Rows.Count > 0)
                            {
                                value2 = dataTable2.Rows[0][0].ToString();
                            }
                            stringBuilder.AppendFormat("<div onclick=\"currentDel=this;showinfo('{0}');\" class=\"selectorDiv\" ondblclick=\"currentDel=this;del();\" value=\"{0}\">", text4);
                            stringBuilder.Append(value2);
                            stringBuilder.Append("</div>");
                            base.ViewBag.where = MyExtensions.UrlEncode(text10);
                            continue;
                        }
                    }
                    Guid id = default(Guid);
                    if (MyExtensions.IsGuid(text4, ref id))
                    {
                        stringBuilder.AppendFormat("<div onclick=\"currentDel=this;showinfo('{0}');\" class=\"selectorDiv\" ondblclick=\"currentDel=this;del();\" value=\"{0}\">", text4);
                        stringBuilder.Append(dictionary.GetTitle(id));
                        stringBuilder.Append("</div>");
                    }
                }
            }
            base.ViewBag.defaultValuesString = MyExtensions.Trim1(stringBuilder.ToString());
            return View();
        }

        public ActionResult Index_App()
        {
            RoadFlow.Platform.Dictionary dictionary = new RoadFlow.Platform.Dictionary();
            string obj = base.Request.QueryString["values"] ?? "";
            string text12 = base.Request.QueryString["rootid"];
            string text = base.Request.QueryString["datasource"];
            string text2 = base.Request.QueryString["sql"];
            DataTable dataTable = new DataTable();
            if ("1" == text)
            {
                string text3 = base.Request.QueryString["dbconn"];
                RoadFlow.Platform.DBConnection dBConnection = new RoadFlow.Platform.DBConnection();
                RoadFlow.Data.Model.DBConnection dbconn = dBConnection.Get(MyExtensions.ToGuid(text3));
                dataTable = dBConnection.GetDataTable(dbconn, MyExtensions.ReplaceSelectSql(MyExtensions.UrlDecode(text2).FilterWildcard()));
            }
            StringBuilder stringBuilder = new StringBuilder();
            string[] array = obj.Split(',');
            foreach (string text4 in array)
            {
                if (!MyExtensions.IsNullOrEmpty(text4))
                {
                    if (!(text == "0"))
                    {
                        if (text == "1")
                        {
                            string value = string.Empty;
                            foreach (DataRow row in dataTable.Rows)
                            {
                                if (text4 == row[0].ToString())
                                {
                                    value = ((dataTable.Columns.Count > 1) ? row[1].ToString() : text4);
                                    break;
                                }
                            }
                            stringBuilder.AppendFormat("<div onclick=\"currentDel=this;showinfo('{0}');\" class=\"selectorDiv\" ondblclick=\"currentDel=this;del();\" value=\"{0}\">", text4);
                            stringBuilder.Append(value);
                            stringBuilder.Append("</div>");
                            continue;
                        }
                        if (text == "2")
                        {
                            string text5 = base.Request.QueryString["url2"];
                            if (!MyExtensions.IsNullOrEmpty(text5))
                            {
                                text5 = ((text5.IndexOf('?') >= 0) ? (text5 + "&values=" + text4) : (text5 + "?values=" + text4));
                                StringBuilder stringBuilder2 = new StringBuilder();
                                try
                                {
                                    TextWriter writer = new StringWriter(stringBuilder2);
                                    base.Server.Execute(text5, writer);
                                }
                                catch
                                {
                                }
                                stringBuilder.AppendFormat("<div onclick=\"currentDel=this;showinfo('{0}');\" class=\"selectorDiv\" ondblclick=\"currentDel=this;del();\" value=\"{0}\">", text4);
                                stringBuilder.Append(stringBuilder2.ToString());
                                stringBuilder.Append("</div>");
                            }
                            continue;
                        }
                        if (text == "3")
                        {
                            string text6 = base.Request.QueryString["dbconn"];
                            string text7 = base.Request.QueryString["dbtable"];
                            string text8 = base.Request.QueryString["valuefield"];
                            string text9 = base.Request.QueryString["titlefield"];
                            string text13 = base.Request.QueryString["parentfield"];
                            string text10 = base.Request.QueryString["where1"];
                            RoadFlow.Platform.DBConnection dBConnection2 = new RoadFlow.Platform.DBConnection();
                            RoadFlow.Data.Model.DBConnection dbconn2 = dBConnection2.Get(MyExtensions.ToGuid(text6));
                            string text11 = "select " + text9 + " from " + text7 + " where " + text8 + "='" + text4 + "'";
                            DataTable dataTable2 = dBConnection2.GetDataTable(dbconn2, MyExtensions.ReplaceSelectSql(text11));
                            string value2 = string.Empty;
                            if (dataTable2.Rows.Count > 0)
                            {
                                value2 = dataTable2.Rows[0][0].ToString();
                            }
                            stringBuilder.AppendFormat("<div onclick=\"currentDel=this;showinfo('{0}');\" class=\"selectorDiv\" ondblclick=\"currentDel=this;del();\" value=\"{0}\">", text4);
                            stringBuilder.Append(value2);
                            stringBuilder.Append("</div>");
                            base.ViewBag.where = MyExtensions.UrlEncode(text10);
                            continue;
                        }
                    }
                    Guid id = default(Guid);
                    if (MyExtensions.IsGuid(text4, ref id))
                    {
                        stringBuilder.AppendFormat("<div onclick=\"currentDel=this;showinfo('{0}');\" class=\"selectorDiv\" ondblclick=\"currentDel=this;del();\" value=\"{0}\">", text4);
                        stringBuilder.Append(dictionary.GetTitle(id));
                        stringBuilder.Append("</div>");
                    }
                }
            }
            base.ViewBag.defaultValuesString = MyExtensions.Trim1(stringBuilder.ToString());
            return View();
        }

        public string GetNames()
        {
            string obj = base.Request.QueryString["values"] ?? "";
            RoadFlow.Platform.Dictionary dictionary = new RoadFlow.Platform.Dictionary();
            StringBuilder stringBuilder = new StringBuilder();
            string[] array = obj.Split(',');
            foreach (string text in array)
            {
                RoadFlow.Data.Model.Dictionary dictionary2 = dictionary.Get(MyExtensions.ToGuid(text), fromCache: true);
                if (dictionary2 != null)
                {
                    stringBuilder.Append(dictionary2.Title);
                    stringBuilder.Append(',');
                }
            }
            return stringBuilder.ToString().TrimEnd(',');
        }

        public string GetNote()
        {
            string text = base.Request.QueryString["id"];
            string result = "";
            Guid id = default(Guid);
            if (MyExtensions.IsGuid(text, ref id))
            {
                RoadFlow.Data.Model.Dictionary dictionary = new RoadFlow.Platform.Dictionary().Get(id, fromCache: true);
                if (dictionary != null)
                {
                    result = dictionary.Note;
                }
            }
            return result;
        }

        public string GetNames_SQL()
        {
            string text = base.Request.QueryString["dbconn"];
            string text2 = base.Request.QueryString["sql"];
            RoadFlow.Platform.DBConnection dBConnection = new RoadFlow.Platform.DBConnection();
            RoadFlow.Data.Model.DBConnection dbconn = dBConnection.Get(MyExtensions.ToGuid(text));
            DataTable dataTable = dBConnection.GetDataTable(dbconn, MyExtensions.ReplaceSelectSql(MyExtensions.UrlDecode(text2).FilterWildcard()));
            string obj = base.Request.QueryString["values"] ?? "";
            StringBuilder stringBuilder = new StringBuilder();
            string[] array = obj.Split(',');
            foreach (string a in array)
            {
                string empty = string.Empty;
                string value = string.Empty;
                foreach (DataRow row in dataTable.Rows)
                {
                    empty = row[0].ToString();
                    if (a == empty)
                    {
                        value = ((dataTable.Columns.Count > 1) ? row[1].ToString() : empty);
                        break;
                    }
                }
                stringBuilder.Append(value);
                stringBuilder.Append(',');
            }
            return stringBuilder.ToString().TrimEnd(',');
        }

        public string GetJson_SQL()
        {
            if (!Tools.CheckLogin(redirect: false))
            {
                return "{}";
            }
            string text = base.Request.QueryString["dbconn"];
            string text2 = base.Request.QueryString["sql"];
            RoadFlow.Platform.DBConnection dBConnection = new RoadFlow.Platform.DBConnection();
            RoadFlow.Data.Model.DBConnection dbconn = dBConnection.Get(MyExtensions.ToGuid(text));
            DataTable dataTable = dBConnection.GetDataTable(dbconn, MyExtensions.ReplaceSelectSql(MyExtensions.UrlDecode(text2).FilterWildcard()));
            StringBuilder stringBuilder = new StringBuilder(1000);
            foreach (DataRow row in dataTable.Rows)
            {
                string text3 = row[0].ToString();
                string arg = (dataTable.Columns.Count > 1) ? row[1].ToString() : text3;
                stringBuilder.Append("{");
                stringBuilder.AppendFormat("\"id\":\"{0}\",", text3);
                stringBuilder.AppendFormat("\"parentID\":\"{0}\",", Guid.Empty.ToString());
                stringBuilder.AppendFormat("\"title\":\"{0}\",", arg);
                stringBuilder.AppendFormat("\"type\":\"{0}\",", "2");
                stringBuilder.AppendFormat("\"ico\":\"{0}\",", "");
                stringBuilder.AppendFormat("\"hasChilds\":\"{0}\",", "0");
                stringBuilder.Append("\"childs\":[]},");
            }
            return "[" + stringBuilder.ToString().TrimEnd(',') + "]";
        }

        public string GetJson_Table()
        {
            string text = base.Request.QueryString["dbconn"];
            string text2 = base.Request.QueryString["dbtable"];
            string text3 = base.Request.QueryString["valuefield"];
            string text4 = base.Request.QueryString["titlefield"];
            string text5 = base.Request.QueryString["parentfield"];
            string text6 = MyExtensions.UrlDecode(base.Request.QueryString["where"] ?? "");
            RoadFlow.Platform.DBConnection dBConnection = new RoadFlow.Platform.DBConnection();
            RoadFlow.Data.Model.DBConnection dbconn = dBConnection.Get(MyExtensions.ToGuid(text));
            string text7 = "select " + text3 + "," + text4 + " from " + text2 + (MyExtensions.IsNullOrEmpty(text6) ? "" : (" where " + text6.FilterWildcard()));
            DataTable dataTable = dBConnection.GetDataTable(dbconn, MyExtensions.ReplaceSelectSql(text7));
            StringBuilder stringBuilder = new StringBuilder(1000);
            foreach (DataRow row in dataTable.Rows)
            {
                string text8 = row[0].ToString();
                string arg = (dataTable.Columns.Count > 1) ? row[1].ToString() : text8;
                string text9 = "select * from " + text2 + " where " + text5 + "='" + text8 + "'";
                bool flag = dBConnection.GetDataTable(dbconn, MyExtensions.ReplaceSelectSql(text9)).Rows.Count > 0;
                stringBuilder.Append("{");
                stringBuilder.AppendFormat("\"id\":\"{0}\",", text8);
                stringBuilder.AppendFormat("\"parentID\":\"{0}\",", Guid.Empty.ToString());
                stringBuilder.AppendFormat("\"title\":\"{0}\",", arg);
                stringBuilder.AppendFormat("\"type\":\"{0}\",", flag ? "1" : "2");
                stringBuilder.AppendFormat("\"ico\":\"{0}\",", "");
                stringBuilder.AppendFormat("\"hasChilds\":\"{0}\",", flag ? "1" : "0");
                stringBuilder.Append("\"childs\":[]},");
            }
            return "[" + stringBuilder.ToString().TrimEnd(',') + "]";
        }

        public string GetJson_TableRefresh()
        {
            string text = base.Request.QueryString["dbconn"];
            string text2 = base.Request.QueryString["dbtable"];
            string text3 = base.Request.QueryString["valuefield"];
            string text4 = base.Request.QueryString["titlefield"];
            string text5 = base.Request.QueryString["parentfield"];
            string text10 = base.Request.QueryString["where"];
            string text6 = base.Request.QueryString["refreshid"];
            RoadFlow.Platform.DBConnection dBConnection = new RoadFlow.Platform.DBConnection();
            RoadFlow.Data.Model.DBConnection dbconn = dBConnection.Get(MyExtensions.ToGuid(text));
            string text7 = "select " + text3 + "," + text4 + " from " + text2 + " where " + text5 + "='" + text6 + "'";
            DataTable dataTable = dBConnection.GetDataTable(dbconn, MyExtensions.ReplaceSelectSql(text7));
            StringBuilder stringBuilder = new StringBuilder(1000);
            foreach (DataRow row in dataTable.Rows)
            {
                string text8 = row[0].ToString();
                string arg = (dataTable.Columns.Count > 1) ? row[1].ToString() : text8;
                string text9 = "select * from " + text2 + " where " + text5 + "='" + text8 + "'";
                bool flag = dBConnection.GetDataTable(dbconn, MyExtensions.ReplaceSelectSql(text9)).Rows.Count > 0;
                stringBuilder.Append("{");
                stringBuilder.AppendFormat("\"id\":\"{0}\",", text8);
                stringBuilder.AppendFormat("\"parentID\":\"{0}\",", Guid.Empty.ToString());
                stringBuilder.AppendFormat("\"title\":\"{0}\",", arg);
                stringBuilder.AppendFormat("\"type\":\"{0}\",", flag ? "1" : "2");
                stringBuilder.AppendFormat("\"ico\":\"{0}\",", "");
                stringBuilder.AppendFormat("\"hasChilds\":\"{0}\",", flag ? "1" : "0");
                stringBuilder.Append("\"childs\":[]},");
            }
            return "[" + stringBuilder.ToString().TrimEnd(',') + "]";
        }

        public string GetNames_Table()
        {
            string text = base.Request.QueryString["dbconn"];
            string text2 = base.Request.QueryString["dbtable"];
            string text3 = base.Request.QueryString["valuefield"];
            string text4 = base.Request.QueryString["titlefield"];
            string text7 = base.Request.QueryString["parentfield"];
            string text8 = base.Request.QueryString["where"];
            string obj = base.Request.QueryString["values"] ?? "";
            RoadFlow.Platform.DBConnection dBConnection = new RoadFlow.Platform.DBConnection();
            RoadFlow.Data.Model.DBConnection dbconn = dBConnection.Get(MyExtensions.ToGuid(text));
            StringBuilder stringBuilder = new StringBuilder();
            string[] array = obj.Split(',');
            foreach (string text5 in array)
            {
                if (!MyExtensions.IsNullOrEmpty(text5))
                {
                    string text6 = "select " + text4 + " from " + text2 + " where " + text3 + "='" + text5 + "'";
                    DataTable dataTable = dBConnection.GetDataTable(dbconn, MyExtensions.ReplaceSelectSql(text6));
                    if (dataTable.Rows.Count > 0)
                    {
                        stringBuilder.Append(dataTable.Rows[0][0].ToString());
                        stringBuilder.Append(",");
                    }
                }
            }
            return stringBuilder.ToString().TrimEnd(',');
        }
    }
}
