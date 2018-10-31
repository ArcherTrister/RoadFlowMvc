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
                    if (MyExtensions.IsGuid(text4, out id))
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
                    if (MyExtensions.IsGuid(text4, out id))
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
      string str1 = this.Request.QueryString["values"] ?? "";
      RoadFlow.Platform.Dictionary dictionary1 = new RoadFlow.Platform.Dictionary();
      StringBuilder stringBuilder = new StringBuilder();
      char[] chArray = new char[1]{ ',' };
      foreach (string str2 in str1.Split(chArray))
      {
        RoadFlow.Data.Model.Dictionary dictionary2 = dictionary1.Get(str2.ToGuid(), true);
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
            if (MyExtensions.IsGuid(text, out id))
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
      string str1 = this.Request.QueryString["dbconn"];
      string str2 = this.Request.QueryString["sql"];
      RoadFlow.Platform.DBConnection dbConnection = new RoadFlow.Platform.DBConnection();
      DataTable dataTable = dbConnection.GetDataTable(dbConnection.Get(str1.ToGuid(), true), str2.UrlDecode().FilterWildcard("").ReplaceSelectSql(), (IDataParameter[]) null);
      string str3 = this.Request.QueryString["values"] ?? "";
      StringBuilder stringBuilder = new StringBuilder();
      char[] chArray = new char[1]{ ',' };
      foreach (string str4 in str3.Split(chArray))
      {
        string empty = string.Empty;
        string str5 = string.Empty;
        foreach (DataRow row in (InternalDataCollectionBase) dataTable.Rows)
        {
          string str6 = row[0].ToString();
          if (str4 == str6)
          {
            str5 = dataTable.Columns.Count > 1 ? row[1].ToString() : str6;
            break;
          }
        }
        stringBuilder.Append(str5);
        stringBuilder.Append(',');
      }
      return stringBuilder.ToString().TrimEnd(',');
    }

    public string GetJson_SQL()
    {
      if (!Tools.CheckLogin(false))
        return "{}";
      string str1 = this.Request.QueryString["dbconn"];
      string str2 = this.Request.QueryString["sql"];
      RoadFlow.Platform.DBConnection dbConnection = new RoadFlow.Platform.DBConnection();
      DataTable dataTable = dbConnection.GetDataTable(dbConnection.Get(str1.ToGuid(), true), str2.UrlDecode().FilterWildcard("").ReplaceSelectSql(), (IDataParameter[]) null);
      StringBuilder stringBuilder = new StringBuilder(1000);
      foreach (DataRow row in (InternalDataCollectionBase) dataTable.Rows)
      {
        string str3 = row[0].ToString();
        string str4 = dataTable.Columns.Count > 1 ? row[1].ToString() : str3;
        stringBuilder.Append("{");
        stringBuilder.AppendFormat("\"id\":\"{0}\",", (object) str3);
        stringBuilder.AppendFormat("\"parentID\":\"{0}\",", (object) Guid.Empty.ToString());
        stringBuilder.AppendFormat("\"title\":\"{0}\",", (object) str4);
        stringBuilder.AppendFormat("\"type\":\"{0}\",", (object) "2");
        stringBuilder.AppendFormat("\"ico\":\"{0}\",", (object) "");
        stringBuilder.AppendFormat("\"hasChilds\":\"{0}\",", (object) "0");
        stringBuilder.Append("\"childs\":[]},");
      }
      return "[" + stringBuilder.ToString().TrimEnd(',') + "]";
    }

    public string GetJson_Table()
    {
      string str1 = this.Request.QueryString["dbconn"];
      string str2 = this.Request.QueryString["dbtable"];
      string str3 = this.Request.QueryString["valuefield"];
      string str4 = this.Request.QueryString["titlefield"];
      string str5 = this.Request.QueryString["parentfield"];
      string str6 = (this.Request.QueryString["where"] ?? "").UrlDecode();
      RoadFlow.Platform.DBConnection dbConnection = new RoadFlow.Platform.DBConnection();
      RoadFlow.Data.Model.DBConnection dbconn = dbConnection.Get(str1.ToGuid(), true);
      string str7 = "select " + str3 + "," + str4 + " from " + str2 + (str6.IsNullOrEmpty() ? "" : " where " + str6.FilterWildcard(""));
      DataTable dataTable = dbConnection.GetDataTable(dbconn, str7.ReplaceSelectSql(), (IDataParameter[]) null);
      StringBuilder stringBuilder = new StringBuilder(1000);
      foreach (DataRow row in (InternalDataCollectionBase) dataTable.Rows)
      {
        string str8 = row[0].ToString();
        string str9 = dataTable.Columns.Count > 1 ? row[1].ToString() : str8;
        string str10 = "select * from " + str2 + " where " + str5 + "='" + str8 + "'";
        bool flag = dbConnection.GetDataTable(dbconn, str10.ReplaceSelectSql(), (IDataParameter[]) null).Rows.Count > 0;
        stringBuilder.Append("{");
        stringBuilder.AppendFormat("\"id\":\"{0}\",", (object) str8);
        stringBuilder.AppendFormat("\"parentID\":\"{0}\",", (object) Guid.Empty.ToString());
        stringBuilder.AppendFormat("\"title\":\"{0}\",", (object) str9);
        stringBuilder.AppendFormat("\"type\":\"{0}\",", flag ? (object) "1" : (object) "2");
        stringBuilder.AppendFormat("\"ico\":\"{0}\",", (object) "");
        stringBuilder.AppendFormat("\"hasChilds\":\"{0}\",", flag ? (object) "1" : (object) "0");
        stringBuilder.Append("\"childs\":[]},");
      }
      return "[" + stringBuilder.ToString().TrimEnd(',') + "]";
    }

    public string GetJson_TableRefresh()
    {
      string str1 = this.Request.QueryString["dbconn"];
      string str2 = this.Request.QueryString["dbtable"];
      string str3 = this.Request.QueryString["valuefield"];
      string str4 = this.Request.QueryString["titlefield"];
      string str5 = this.Request.QueryString["parentfield"];
      string str6 = this.Request.QueryString["where"];
      string str7 = this.Request.QueryString["refreshid"];
      RoadFlow.Platform.DBConnection dbConnection = new RoadFlow.Platform.DBConnection();
      RoadFlow.Data.Model.DBConnection dbconn = dbConnection.Get(str1.ToGuid(), true);
      string str8 = "select " + str3 + "," + str4 + " from " + str2 + " where " + str5 + "='" + str7 + "'";
      DataTable dataTable = dbConnection.GetDataTable(dbconn, str8.ReplaceSelectSql(), (IDataParameter[]) null);
      StringBuilder stringBuilder = new StringBuilder(1000);
      foreach (DataRow row in (InternalDataCollectionBase) dataTable.Rows)
      {
        string str9 = row[0].ToString();
        string str10 = dataTable.Columns.Count > 1 ? row[1].ToString() : str9;
        string str11 = "select * from " + str2 + " where " + str5 + "='" + str9 + "'";
        bool flag = dbConnection.GetDataTable(dbconn, str11.ReplaceSelectSql(), (IDataParameter[]) null).Rows.Count > 0;
        stringBuilder.Append("{");
        stringBuilder.AppendFormat("\"id\":\"{0}\",", (object) str9);
        stringBuilder.AppendFormat("\"parentID\":\"{0}\",", (object) Guid.Empty.ToString());
        stringBuilder.AppendFormat("\"title\":\"{0}\",", (object) str10);
        stringBuilder.AppendFormat("\"type\":\"{0}\",", flag ? (object) "1" : (object) "2");
        stringBuilder.AppendFormat("\"ico\":\"{0}\",", (object) "");
        stringBuilder.AppendFormat("\"hasChilds\":\"{0}\",", flag ? (object) "1" : (object) "0");
        stringBuilder.Append("\"childs\":[]},");
      }
      return "[" + stringBuilder.ToString().TrimEnd(',') + "]";
    }

    public string GetNames_Table()
    {
      string str1 = this.Request.QueryString["dbconn"];
      string str2 = this.Request.QueryString["dbtable"];
      string str3 = this.Request.QueryString["valuefield"];
      string str4 = this.Request.QueryString["titlefield"];
      string str5 = this.Request.QueryString["parentfield"];
      string str6 = this.Request.QueryString["where"];
      string str7 = this.Request.QueryString["values"] ?? "";
      RoadFlow.Platform.DBConnection dbConnection = new RoadFlow.Platform.DBConnection();
      RoadFlow.Data.Model.DBConnection dbconn = dbConnection.Get(str1.ToGuid(), true);
      StringBuilder stringBuilder = new StringBuilder();
      char[] chArray = new char[1]{ ',' };
      foreach (string str8 in str7.Split(chArray))
      {
        if (!str8.IsNullOrEmpty())
        {
          string str9 = "select " + str4 + " from " + str2 + " where " + str3 + "='" + str8 + "'";
          DataTable dataTable = dbConnection.GetDataTable(dbconn, str9.ReplaceSelectSql(), (IDataParameter[]) null);
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
