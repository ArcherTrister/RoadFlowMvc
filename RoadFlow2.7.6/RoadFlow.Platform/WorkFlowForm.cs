// Decompiled with JetBrains decompiler
// Type: RoadFlow.Platform.WorkFlowForm
// Assembly: RoadFlow.Platform, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 07F26AFD-DE3B-4003-89AF-01A62494BA58
// Assembly location: C:\inetpub\wwwroot\RoadFlowMvc\bin\RoadFlow.Platform.dll

using LitJson;
using RoadFlow.Data.Interface;
using RoadFlow.Data.Model;
using RoadFlow.Utility;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Data;
using System.IO;
using System.Linq;
using System.Text;
using System.Web;
using System.Web.UI.WebControls;
using System.Xml.Linq;

namespace RoadFlow.Platform
{
  public class WorkFlowForm
  {
    private IWorkFlowForm dataWorkFlowForm;

    public WorkFlowForm()
    {
      this.dataWorkFlowForm = RoadFlow.Data.Factory.Factory.GetWorkFlowForm();
    }

    public int Add(RoadFlow.Data.Model.WorkFlowForm model)
    {
      return this.dataWorkFlowForm.Add(model);
    }

    public int Update(RoadFlow.Data.Model.WorkFlowForm model)
    {
      return this.dataWorkFlowForm.Update(model);
    }

    public List<RoadFlow.Data.Model.WorkFlowForm> GetAll()
    {
      return this.dataWorkFlowForm.GetAll();
    }

    public RoadFlow.Data.Model.WorkFlowForm Get(Guid id)
    {
      return this.dataWorkFlowForm.Get(id);
    }

    public int Delete(Guid id)
    {
      return this.dataWorkFlowForm.Delete(id);
    }

    public long GetCount()
    {
      return this.dataWorkFlowForm.GetCount();
    }

    public string GetValidatePropTypeRadios(string name, string value, string att = "")
    {
      return Tools.GetRadioString(new ListItem[3]{ new ListItem("弹出(alert)", "0") { Selected = "0" == value }, new ListItem("图标和提示信息", "1") { Selected = "1" == value }, new ListItem("图标", "2") { Selected = "2" == value } }, name, att);
    }

    public string GetInputTypeRadios(string name, string value, string att = "")
    {
      return Tools.GetRadioString(new ListItem[2]{ new ListItem("明文", "text") { Selected = "0" == value }, new ListItem("密码", "password") { Selected = "1" == value } }, name, att);
    }

    public string GetEventOptions(string name, string value, string att = "")
    {
      return Tools.GetOptionsString(new ListItem[12]{ new ListItem("onclick", "onclick") { Selected = "onclick" == value }, new ListItem("onchange", "onchange") { Selected = "onchange" == value }, new ListItem("ondblclick", "ondblclick") { Selected = "ondblclick" == value }, new ListItem("onfocus", "onfocus") { Selected = "onfocus" == value }, new ListItem("onblur", "onblur") { Selected = "onblur" == value }, new ListItem("onkeydown", "onkeydown") { Selected = "onkeydown" == value }, new ListItem("onkeypress", "onkeypress") { Selected = "onkeypress" == value }, new ListItem("onkeyup", "onkeyup") { Selected = "onkeyup" == value }, new ListItem("onmousedown", "onmousedown") { Selected = "onmousedown" == value }, new ListItem("onmouseup", "onmouseup") { Selected = "onmouseup" == value }, new ListItem("onmouseover", "onmouseover") { Selected = "onmouseover" == value }, new ListItem("onmouseout", "onmouseout") { Selected = "onmouseout" == value } });
    }

    public string GetValueTypeOptions(string value)
    {
      return Tools.GetOptionsString(new ListItem[8]{ new ListItem("字符串", "0") { Selected = "0" == value }, new ListItem("整数", "1") { Selected = "1" == value }, new ListItem("实数", "2") { Selected = "2" == value }, new ListItem("正整数", "3") { Selected = "3" == value }, new ListItem("正实数", "4") { Selected = "4" == value }, new ListItem("负整数", "5") { Selected = "5" == value }, new ListItem("负实数", "6") { Selected = "6" == value }, new ListItem("手机号码", "7") { Selected = "7" == value } });
    }

    public string GetDefaultValueSelect(string value)
    {
      StringBuilder stringBuilder = new StringBuilder(1000);
      stringBuilder.Append("<option value=\"\"></option>");
      stringBuilder.Append("<optgroup label=\"组织机构相关选项\"></optgroup>");
      stringBuilder.AppendFormat("<option value=\"u_@RoadFlow.Platform.Users.CurrentUserID.ToString()\" {0}>当前步骤用户ID</option>", "10" == value ? (object) "selected=\"selected\"" : (object) "");
      stringBuilder.AppendFormat("<option value=\"@(RoadFlow.Platform.Users.CurrentUserName)\" {0}>当前步骤用户姓名</option>", "11" == value ? (object) "selected=\"selected\"" : (object) "");
      stringBuilder.AppendFormat("<option value=\"@(RoadFlow.Platform.Users.CurrentDeptID)\" {0}>当前步骤用户部门ID</option>", "12" == value ? (object) "selected=\"selected\"" : (object) "");
      stringBuilder.AppendFormat("<option value=\"@(RoadFlow.Platform.Users.CurrentDeptName)\" {0}>当前步骤用户部门名称</option>", "13" == value ? (object) "selected=\"selected\"" : (object) "");
      stringBuilder.AppendFormat("<option value=\"u_@(new RoadFlow.Platform.WorkFlowTask().GetFirstSnderID(FlowID.ToGuid(), GroupID.ToGuid(), true))\" {0}>流程发起者ID</option>", "14" == value ? (object) "selected=\"selected\"" : (object) "");
      stringBuilder.AppendFormat("<option value=\"@(new RoadFlow.Platform.Users().GetName(new RoadFlow.Platform.WorkFlowTask().GetFirstSnderID(FlowID.ToGuid(), GroupID.ToGuid(), true)))\" {0}>流程发起者姓名</option>", "15" == value ? (object) "selected=\"selected\"" : (object) "");
      stringBuilder.AppendFormat("<option value=\"@(new RoadFlow.Platform.WorkFlowTask().GetFirstSnderDeptID(FlowID.ToGuid(), GroupID.ToGuid()))\" {0}>流程发起者部门ID</option>", "16" == value ? (object) "selected=\"selected\"" : (object) "");
      stringBuilder.AppendFormat("<option value=\"@(new RoadFlow.Platform.Organize().GetName(new RoadFlow.Platform.WorkFlowTask().GetFirstSnderDeptID(FlowID.ToGuid(), GroupID.ToGuid())))\" {0}>流程发起者部门名称</option>", "17" == value ? (object) "selected=\"selected\"" : (object) "");
      stringBuilder.Append("<optgroup label=\"日期时间相关选项\"></optgroup>");
      stringBuilder.AppendFormat("<option value=\"@(RoadFlow.Utility.DateTimeNew.ShortDate)\" {0}>短日期格式(2014-4-15)</option>", "20" == value ? (object) "selected=\"selected\"" : (object) "");
      stringBuilder.AppendFormat("<option value=\"@(RoadFlow.Utility.DateTimeNew.LongDate)\" {0}>长日期格式(2014年4月15日)</option>", "21" == value ? (object) "selected=\"selected\"" : (object) "");
      stringBuilder.AppendFormat("<option value=\"@(RoadFlow.Utility.DateTimeNew.ShortTime)\" {0}>短时间格式(23:59)</option>", "22" == value ? (object) "selected=\"selected\"" : (object) "");
      stringBuilder.AppendFormat("<option value=\"@(RoadFlow.Utility.DateTimeNew.LongTime)\" {0}>长时间格式(23时59分)</option>", "23" == value ? (object) "selected=\"selected\"" : (object) "");
      stringBuilder.AppendFormat("<option value=\"@(RoadFlow.Utility.DateTimeNew.ShortDateTime)\" {0}>短日期时间格式(2014-4-15 22:31)</option>", "24" == value ? (object) "selected=\"selected\"" : (object) "");
      stringBuilder.AppendFormat("<option value=\"@(RoadFlow.Utility.DateTimeNew.LongDateTime)\" {0}>长日期时间格式(2014年4月15日 22时31分)</option>", "25" == value ? (object) "selected=\"selected\"" : (object) "");
      stringBuilder.Append("<optgroup label=\"流程实例相关选项\"></optgroup>");
      stringBuilder.AppendFormat("<option value=\"@Html.Raw(BWorkFlow.GetFlowName(FlowID.ToGuid()))\" {0}>当前流程名称</option>", "30" == value ? (object) "selected=\"selected\"" : (object) "");
      stringBuilder.AppendFormat("<option value=\"@Html.Raw(BWorkFlow.GetStepName(StepID.ToGuid(), FlowID.ToGuid(), true))\" {0}>当前步骤名称</option>", "31" == value ? (object) "selected=\"selected\"" : (object) "");
      return stringBuilder.ToString();
    }

    public string GetDefaultValueSelectByAspx(string value)
    {
      StringBuilder stringBuilder = new StringBuilder(1000);
      stringBuilder.Append("<option value=\"\"></option>");
      stringBuilder.Append("<optgroup label=\"组织机构相关选项\"></optgroup>");
      stringBuilder.AppendFormat("<option value=\"u_<%=RoadFlow.Platform.Users.CurrentUserID.ToString()%>\" {0}>当前步骤用户ID</option>", "10" == value ? (object) "selected=\"selected\"" : (object) "");
      stringBuilder.AppendFormat("<option value=\"<%=RoadFlow.Platform.Users.CurrentUserName%>\" {0}>当前步骤用户姓名</option>", "11" == value ? (object) "selected=\"selected\"" : (object) "");
      stringBuilder.AppendFormat("<option value=\"<%=RoadFlow.Platform.Users.CurrentDeptID%>\" {0}>当前步骤用户部门ID</option>", "12" == value ? (object) "selected=\"selected\"" : (object) "");
      stringBuilder.AppendFormat("<option value=\"<%=RoadFlow.Platform.Users.CurrentDeptName%>\" {0}>当前步骤用户部门名称</option>", "13" == value ? (object) "selected=\"selected\"" : (object) "");
      stringBuilder.AppendFormat("<option value=\"u_<%=new RoadFlow.Platform.WorkFlowTask().GetFirstSnderID(FlowID.ToGuid(), GroupID.ToGuid(), true)%>\" {0}>流程发起者ID</option>", "14" == value ? (object) "selected=\"selected\"" : (object) "");
      stringBuilder.AppendFormat("<option value=\"<%=new RoadFlow.Platform.Users().GetName(new RoadFlow.Platform.WorkFlowTask().GetFirstSnderID(FlowID.ToGuid(), GroupID.ToGuid(), true))%>\" {0}>流程发起者姓名</option>", "15" == value ? (object) "selected=\"selected\"" : (object) "");
      stringBuilder.AppendFormat("<option value=\"<%=new RoadFlow.Platform.WorkFlowTask().GetFirstSnderDeptID(FlowID.ToGuid(), GroupID.ToGuid())%>\" {0}>流程发起者部门ID</option>", "16" == value ? (object) "selected=\"selected\"" : (object) "");
      stringBuilder.AppendFormat("<option value=\"<%=new RoadFlow.Platform.Organize().GetName(new RoadFlow.Platform.WorkFlowTask().GetFirstSnderDeptID(FlowID.ToGuid(), GroupID.ToGuid()))%>\" {0}>流程发起者部门名称</option>", "17" == value ? (object) "selected=\"selected\"" : (object) "");
      stringBuilder.Append("<optgroup label=\"日期时间相关选项\"></optgroup>");
      stringBuilder.AppendFormat("<option value=\"<%=RoadFlow.Utility.DateTimeNew.ShortDate%>\" {0}>短日期格式(2014-4-15)</option>", "20" == value ? (object) "selected=\"selected\"" : (object) "");
      stringBuilder.AppendFormat("<option value=\"<%=RoadFlow.Utility.DateTimeNew.LongDate%>\" {0}>长日期格式(2014年4月15日)</option>", "21" == value ? (object) "selected=\"selected\"" : (object) "");
      stringBuilder.AppendFormat("<option value=\"<%=RoadFlow.Utility.DateTimeNew.ShortTime%>\" {0}>短时间格式(23:59)</option>", "22" == value ? (object) "selected=\"selected\"" : (object) "");
      stringBuilder.AppendFormat("<option value=\"<%=RoadFlow.Utility.DateTimeNew.LongTime%>\" {0}>长时间格式(23时59分)</option>", "23" == value ? (object) "selected=\"selected\"" : (object) "");
      stringBuilder.AppendFormat("<option value=\"<%=RoadFlow.Utility.DateTimeNew.ShortDateTime%>\" {0}>短日期时间格式(2014-4-15 22:31)</option>", "24" == value ? (object) "selected=\"selected\"" : (object) "");
      stringBuilder.AppendFormat("<option value=\"<%=RoadFlow.Utility.DateTimeNew.LongDateTime%>\" {0}>长日期时间格式(2014年4月15日 22时31分)</option>", "25" == value ? (object) "selected=\"selected\"" : (object) "");
      stringBuilder.Append("<optgroup label=\"流程实例相关选项\"></optgroup>");
      stringBuilder.AppendFormat("<option value=\"<%=BWorkFlow.GetFlowName(FlowID.ToGuid())%>\" {0}>当前流程名称</option>", "30" == value ? (object) "selected=\"selected\"" : (object) "");
      stringBuilder.AppendFormat("<option value=\"<%=BWorkFlow.GetStepName(StepID.ToGuid(), FlowID.ToGuid(), true)%>\" {0}>当前步骤名称</option>", "31" == value ? (object) "selected=\"selected\"" : (object) "");
      return stringBuilder.ToString();
    }

    public string GetTextareaModelRadios(string name, string value, string att = "")
    {
      return Tools.GetRadioString(new ListItem[2]{ new ListItem("普通", "default") { Selected = "default" == value }, new ListItem("HTML", "html") { Selected = "html" == value } }, name, att);
    }

    public string GetDataSourceRadios(string name, string value, string att = "")
    {
      return Tools.GetRadioString(new ListItem[3]{ new ListItem("数据字典", "0") { Selected = "0" == value }, new ListItem("自定义", "1") { Selected = "1" == value }, new ListItem("SQL语句", "2") { Selected = "2" == value } }, name, att);
    }

    public string GetOrgRangeRadios(string name, string value, string att = "")
    {
      return Tools.GetRadioString(new ListItem[2]{ new ListItem("发起者部门", "0") { Selected = "0" == value }, new ListItem("处理者部门", "1") { Selected = "1" == value } }, name, att);
    }

    public string GetOrgSelectTypeCheckboxs(string name, string value, string att = "")
    {
      return Tools.GetCheckBoxString(new ListItem[5]{ new ListItem("部门", "0") { Selected = "0" == value }, new ListItem("岗位", "1") { Selected = "1" == value }, new ListItem("人员", "2") { Selected = "2" == value }, new ListItem("工作组", "3") { Selected = "3" == value }, new ListItem("单位", "4") { Selected = "4" == value } }, name, value.Split(','), att);
    }

    public string GetEditmodeOptions(string value)
    {
      return Tools.GetOptionsString(new ListItem[10]{ new ListItem("无", "") { Selected = "" == value }, new ListItem("文本框", "text") { Selected = "text" == value }, new ListItem("文本域", "textarea") { Selected = "textarea" == value }, new ListItem("下拉列表", "select") { Selected = "select" == value }, new ListItem("复选框", "checkbox") { Selected = "checkbox" == value }, new ListItem("单选框", "radio") { Selected = "radio" == value }, new ListItem("日期时间", "datetime") { Selected = "datetime" == value }, new ListItem("组织机构选择", "org") { Selected = "org" == value }, new ListItem("数据字典选择", "dict") { Selected = "dict" == value }, new ListItem("附件", "files") { Selected = "files" == value } });
    }

    public string GetDisplayModeOptions(string value)
    {
      return Tools.GetOptionsString(new ListItem[18]{ new ListItem("常规", "normal") { Selected = "normal" == value }, new ListItem("数据字典ID显示为标题", "dict_id_title") { Selected = "dict_id_title" == value }, new ListItem("数据字典ID显示为代码", "dict_id_code") { Selected = "dict_id_code" == value }, new ListItem("数据字典ID显示为值", "dict_id_value") { Selected = "dict_id_value" == value }, new ListItem("数据字典ID显示为备注", "dict_id_note") { Selected = "dict_id_note" == value }, new ListItem("数据字典ID显示为其它", "dict_id_other") { Selected = "dict_id_other" == value }, new ListItem("数据字典唯一代码显示为标题", "dict_code_title") { Selected = "dict_code_title" == value }, new ListItem("数据字典唯一代码显示为ID", "dict_code_id") { Selected = "dict_code_id" == value }, new ListItem("数据字典唯一代码显示为值", "dict_code_value") { Selected = "dict_code_value" == value }, new ListItem("数据字典唯一代码显示为备注", "dict_code_note") { Selected = "dict_code_note" == value }, new ListItem("数据字典唯一代码显示为其它", "dict_code_other") { Selected = "dict_code_other" == value }, new ListItem("组织机构ID显示为名称", "organize_id_name") { Selected = "organize_id_name" == value }, new ListItem("附件显示为连接", "files_link") { Selected = "files_link" == value }, new ListItem("附件显示为图片", "files_img") { Selected = "files_img" == value }, new ListItem("日期时间显示为指定格式", "datetime_format") { Selected = "datetime_format" == value }, new ListItem("数字显示为指定格式", "number_format") { Selected = "number_format" == value }, new ListItem("字符串时间显示为指定格式", "string_format") { Selected = "string_format" == value }, new ListItem("关联显示为其它表字段值", "table_fieldvalue") { Selected = "table_fieldvalue" == value } });
    }

    public string GetDisplayString(string value, string displayModel, string format = "", string dbconnID = "", string sql = "")
    {
      string empty = string.Empty;
      string str1;
      switch ((displayModel ?? "").ToLower())
      {
        case "datetime_format":
          str1 = value.ToDateTime().ToString(format ?? Config.DateFormat);
          break;
        case "dict_code_id":
          RoadFlow.Data.Model.Dictionary byCode1 = new Dictionary().GetByCode(value, false);
          str1 = byCode1 == null ? "" : byCode1.ID.ToString();
          break;
        case "dict_code_note":
          RoadFlow.Data.Model.Dictionary byCode2 = new Dictionary().GetByCode(value, false);
          str1 = byCode2 == null ? "" : byCode2.Note;
          break;
        case "dict_code_other":
          RoadFlow.Data.Model.Dictionary byCode3 = new Dictionary().GetByCode(value, false);
          str1 = byCode3 == null ? "" : byCode3.Other;
          break;
        case "dict_code_title":
          RoadFlow.Data.Model.Dictionary byCode4 = new Dictionary().GetByCode(value, false);
          str1 = byCode4 == null ? "" : byCode4.Title;
          break;
        case "dict_code_value":
          RoadFlow.Data.Model.Dictionary byCode5 = new Dictionary().GetByCode(value, false);
          str1 = byCode5 == null ? "" : byCode5.Value;
          break;
        case "dict_id_code":
          RoadFlow.Data.Model.Dictionary dictionary1 = new Dictionary().Get(value.ToGuid(), false);
          str1 = dictionary1 == null ? "" : dictionary1.Code;
          break;
        case "dict_id_note":
          RoadFlow.Data.Model.Dictionary dictionary2 = new Dictionary().Get(value.ToGuid(), false);
          str1 = dictionary2 == null ? "" : dictionary2.Note;
          break;
        case "dict_id_other":
          RoadFlow.Data.Model.Dictionary dictionary3 = new Dictionary().Get(value.ToGuid(), false);
          str1 = dictionary3 == null ? "" : dictionary3.Other;
          break;
        case "dict_id_title":
          RoadFlow.Data.Model.Dictionary dictionary4 = new Dictionary().Get(value.ToGuid(), false);
          str1 = dictionary4 == null ? "" : dictionary4.Title;
          break;
        case "dict_id_value":
          RoadFlow.Data.Model.Dictionary dictionary5 = new Dictionary().Get(value.ToGuid(), false);
          str1 = dictionary5 == null ? "" : dictionary5.Value;
          break;
        case "files_img":
          string[] strArray1 = value.Split('|');
          StringBuilder stringBuilder1 = new StringBuilder();
          foreach (string str2 in strArray1)
            stringBuilder1.AppendFormat("<img src=\"{0}\" />", (object) str2);
          str1 = stringBuilder1.ToString();
          break;
        case "files_link":
          string[] strArray2 = value.Split('|');
          StringBuilder stringBuilder2 = new StringBuilder();
          foreach (string path in strArray2)
            stringBuilder2.AppendFormat("<a target=\"_blank\" class=\"blue\" href=\"{0}\">{1}</a><br/>", (object) path, (object) Path.GetFileName(path));
          str1 = stringBuilder2.ToString();
          break;
        case "number_format":
          str1 = value.ToDecimal().ToString(format);
          break;
        case "organize_id_name":
          str1 = new Organize().GetNames(value, ",");
          break;
        case "table_fieldvalue":
          DBConnection dbConnection = new DBConnection();
          DataTable dataTable = dbConnection.GetDataTable(dbConnection.Get(dbconnID.ToGuid(), true), sql + "'" + value + "'", (IDataParameter[]) null);
          str1 = dataTable.Rows.Count <= 0 || dataTable.Columns.Count <= 0 ? "" : dataTable.Rows[0][0].ToString();
          break;
        default:
          str1 = value;
          break;
      }
      return str1;
    }

    public string GetStatusTitle(int status)
    {
      string str = string.Empty;
      switch (status)
      {
        case 0:
          str = "已保存";
          break;
        case 1:
          str = "已发布";
          break;
        case 2:
          str = "已作废";
          break;
      }
      return str;
    }

    public string GetHeadHtml(string serverScript)
    {
      return "";
    }

    public string GetOptionsFromUrl(string url, string value)
    {
      string str = url + (url.IndexOf('?') >= 0 ? "&" : "?") + "values=" + value;
      if (!str.Contains("http", StringComparison.CurrentCultureIgnoreCase) && !str.Contains("https", StringComparison.CurrentCultureIgnoreCase))
      {
        Uri url1 = HttpContext.Current.Request.Url;
        str = url1.ToString().Substring(0, url1.ToString().IndexOf("//") + 2) + url1.Authority + str;
      }
      try
      {
        return HttpHelper.SendGet(str);
      }
      catch (Exception ex)
      {
        return ex.Message;
      }
    }

    public string GetOptionsFromString(string str, string value, bool isEmpty = true)
    {
      if (str.IsNullOrEmpty())
        return "";
      string[] strArray1 = str.Split(';');
      StringBuilder stringBuilder = new StringBuilder();
      if (isEmpty)
        stringBuilder.Append("<option value=\"\"></option>");
      foreach (string str1 in strArray1)
      {
        char[] chArray = new char[1]{ ',' };
        string[] strArray2 = str1.Split(chArray);
        string empty1 = string.Empty;
        string empty2 = string.Empty;
        if (strArray2.Length != 0)
          empty1 = strArray2[0];
        string str2 = strArray2.Length <= 1 ? empty1 : strArray2[1];
        stringBuilder.AppendFormat("<option value=\"{0}\"{1}>{2}</option>", (object) empty1, empty1.Equals(value, StringComparison.CurrentCultureIgnoreCase) ? (object) " selected=\"selected\"" : (object) "", (object) str2);
      }
      return stringBuilder.ToString();
    }

    public string GetOptionsFromSql(string connID, string sql, string value)
    {
      Guid test;
      if (!connID.IsGuid(out test))
        return "";
      DBConnection dbConnection = new DBConnection();
      RoadFlow.Data.Model.DBConnection dbconn = dbConnection.Get(test, true);
      if (dbconn == null)
        return "";
      DataTable dataTable = dbConnection.GetDataTable(dbconn, sql.Replace(" ", " ").FilterWildcard("").ReplaceSelectSql(), (IDataParameter[]) null);
      if (dataTable.Rows.Count == 0)
        return "";
      List<ListItem> listItemList = new List<ListItem>();
      foreach (DataRow row in (InternalDataCollectionBase) dataTable.Rows)
      {
        if (dataTable.Columns.Count != 0)
        {
          string str = row[0].ToString();
          string text = str;
          if (dataTable.Columns.Count > 1)
            text = row[1].ToString();
          listItemList.Add(new ListItem(text, str)
          {
            Selected = value == str
          });
        }
      }
      return Tools.GetOptionsString(listItemList.ToArray());
    }

    public string GetRadioFromSql(string connID, string sql, string name, string value, string attr = "")
    {
      Guid test;
      if (!connID.IsGuid(out test))
        return "";
      DBConnection dbConnection = new DBConnection();
      RoadFlow.Data.Model.DBConnection dbconn = dbConnection.Get(test, true);
      if (dbconn == null)
        return "";
      DataTable dataTable = dbConnection.GetDataTable(dbconn, sql.Replace(" ", " ").FilterWildcard("").ReplaceSelectSql(), (IDataParameter[]) null);
      if (dataTable.Rows.Count == 0)
        return "";
      List<ListItem> listItemList = new List<ListItem>();
      foreach (DataRow row in (InternalDataCollectionBase) dataTable.Rows)
      {
        if (dataTable.Columns.Count != 0)
        {
          string str = row[0].ToString();
          string text = str;
          if (dataTable.Columns.Count > 1)
            text = row[1].ToString();
          listItemList.Add(new ListItem(text, str)
          {
            Selected = value == str
          });
        }
      }
      return Tools.GetRadioString(listItemList.ToArray(), name, attr);
    }

    public string GetCheckboxFromSql(string connID, string sql, string name, string value, string attr = "")
    {
      Guid test;
      if (!connID.IsGuid(out test))
        return "";
      DBConnection dbConnection = new DBConnection();
      RoadFlow.Data.Model.DBConnection dbconn = dbConnection.Get(test, true);
      if (dbconn == null)
        return "";
      DataTable dataTable = dbConnection.GetDataTable(dbconn, sql.Replace(" ", " ").FilterWildcard("").ReplaceSelectSql(), (IDataParameter[]) null);
      if (dataTable.Rows.Count == 0)
        return "";
      List<ListItem> listItemList = new List<ListItem>();
      foreach (DataRow row in (InternalDataCollectionBase) dataTable.Rows)
      {
        if (dataTable.Columns.Count != 0)
        {
          string str = row[0].ToString();
          string text = str;
          if (dataTable.Columns.Count > 1)
            text = row[1].ToString();
          listItemList.Add(new ListItem(text, str));
        }
      }
      return Tools.GetCheckBoxString(listItemList.ToArray(), name, (value ?? "").Split(','), attr);
    }

    public string GetFormGridHtml(string connID, string dataFormat, string dataSource, string dataSource1, string params1 = "")
    {
      if (!dataFormat.IsInt() || !dataSource.IsInt() || dataSource1.IsNullOrEmpty())
        return "";
      if (!(dataSource == "0"))
      {
        if (!(dataSource == "1"))
        {
          if (!(dataSource == "2"))
            return "";
          WorkFlowCustomEventParams customEventParams = new WorkFlowCustomEventParams();
          customEventParams.FlowID = (HttpContext.Current.Request.QueryString["FlowID"] ?? "").ToGuid();
          customEventParams.GroupID = (HttpContext.Current.Request.QueryString["GroupID"] ?? "").ToGuid();
          customEventParams.StepID = (HttpContext.Current.Request.QueryString["StepID"] ?? "").ToGuid();
          customEventParams.TaskID = (HttpContext.Current.Request.QueryString["TaskID"] ?? "").ToGuid();
          customEventParams.InstanceID = HttpContext.Current.Request.QueryString["InstanceID"] ?? "";
          customEventParams.Other = (object) params1;
          try
          {
            object obj = new WorkFlowTask().ExecuteFlowCustomEvent(dataSource1, (object) customEventParams, "");
            if (dataFormat == "0")
              return this.dataTableToHtml((DataTable) obj);
            if (dataFormat == "1")
              return obj.ToString();
            if (dataFormat == "2")
              return this.jsonToHtml(obj.ToString());
            return "";
          }
          catch
          {
            return "";
          }
        }
        else
        {
          string empty = string.Empty;
          try
          {
            string jsonStr = HttpHelper.SendGet(dataSource1 + params1);
            if (dataFormat == "0" || dataFormat == "1")
              return jsonStr;
            if (dataFormat == "2")
              return this.jsonToHtml(jsonStr);
            return "";
          }
          catch
          {
            return "";
          }
        }
      }
      else
      {
        DBConnection dbConnection = new DBConnection();
        RoadFlow.Data.Model.DBConnection dbconn = dbConnection.Get(connID.ToGuid(), true);
        if (dbconn == null)
          return "";
        DataTable dataTable = dbConnection.GetDataTable(dbconn, (dataSource1.Replace(" ", " ") + " " + params1).ReplaceSelectSql(), (IDataParameter[]) null);
        if (dataFormat == "0")
          return this.dataTableToHtml(dataTable);
        if (!(dataFormat == "1"))
        {
          if (dataFormat == "2" && dataTable.Rows.Count > 0)
            return this.jsonToHtml(dataTable.Rows[0][0].ToString());
          return "";
        }
        if (dataTable.Rows.Count <= 0)
          return "";
        return dataTable.Rows[0][0].ToString();
      }
    }

    private string dataTableToHtml(DataTable dt)
    {
      StringBuilder stringBuilder = new StringBuilder(2000);
      stringBuilder.Append("<table border=\"1\" style=\"border-collapse:collapse;width:100%;\">");
      stringBuilder.Append("<thead><tr style=\"height:25px;\">");
      foreach (DataColumn column in (InternalDataCollectionBase) dt.Columns)
        stringBuilder.AppendFormat("<th>{0}</th>", (object) column.ColumnName);
      stringBuilder.Append("</tr></thead>");
      stringBuilder.Append("<tbody>");
      foreach (DataRow row in (InternalDataCollectionBase) dt.Rows)
      {
        stringBuilder.Append("<tr style=\"height:22px;\">");
        for (int index = 0; index < dt.Columns.Count; ++index)
          stringBuilder.AppendFormat("<td>{0}</td>", (object) row[index].ToString().HtmlEncode());
        stringBuilder.Append("</tr>");
      }
      stringBuilder.Append("</tbody>");
      stringBuilder.Append("</table>");
      return stringBuilder.ToString();
    }

    private string jsonToHtml(string jsonStr)
    {
      JsonData jsonData1 = JsonMapper.ToObject(jsonStr);
      if (!jsonData1.IsArray)
        return "";
      StringBuilder stringBuilder = new StringBuilder(2000);
      stringBuilder.Append("<table border=\"1\" style=\"border-collapse:collapse;width:100%;\">");
      stringBuilder.Append("<tbody><tr style=\"height:25px;\">");
      foreach (JsonData jsonData2 in (IEnumerable) jsonData1)
      {
        stringBuilder.Append("<tr style=\"height:22px;\">");
        foreach (JsonData jsonData3 in (IEnumerable) jsonData2)
          stringBuilder.AppendFormat("<td>{0}</td>", (object) jsonData3.ToString());
        stringBuilder.Append("</tr>");
      }
      stringBuilder.Append("</tbody>");
      stringBuilder.Append("</table>");
      return stringBuilder.ToString();
    }

    public string GetAllChildsIDString(Guid id, bool isSelf = true)
    {
      return new Dictionary().GetAllChildsIDString(id, true);
    }

    public List<RoadFlow.Data.Model.WorkFlowForm> GetAllByType(Guid id)
    {
      return this.dataWorkFlowForm.GetAllByType(this.GetAllChildsIDString(id, true));
    }

    public string GetTypeOptions(string value = "")
    {
      return new Dictionary().GetOptionsByCode("FormTypes", Dictionary.OptionValueField.ID, value, "", true);
    }

    public string GetComboxTableHtmlFromSql(string connID, string sql, string value)
    {
      Guid test;
      if (!connID.IsGuid(out test))
        return "";
      DBConnection dbConnection = new DBConnection();
      RoadFlow.Data.Model.DBConnection dbconn = dbConnection.Get(test, true);
      if (dbconn == null)
        return "";
      DataTable dataTable = dbConnection.GetDataTable(dbconn, sql.Replace(" ", " ").FilterWildcard("").ReplaceSelectSql(), (IDataParameter[]) null);
      if (dataTable.Rows.Count == 0)
        return "";
      StringBuilder stringBuilder = new StringBuilder(2000);
      stringBuilder.Append("<table><thead><tr>");
      for (int index = 0; index < dataTable.Columns.Count; ++index)
      {
        if (dataTable.Columns.Count <= 1 || index != 0)
        {
          stringBuilder.Append("<th>");
          stringBuilder.Append(dataTable.Columns[index].ColumnName);
          stringBuilder.Append("</th>");
        }
      }
      stringBuilder.Append("</thead>");
      stringBuilder.Append("<tbody>");
      for (int index1 = 0; index1 < dataTable.Rows.Count; ++index1)
      {
        stringBuilder.Append("<tr>");
        for (int index2 = 0; index2 < dataTable.Columns.Count; ++index2)
        {
          if (dataTable.Columns.Count <= 1 || index2 != 0)
          {
            stringBuilder.AppendFormat("<td value=\"{0}\"{1}>", dataTable.Rows[index1][0], dataTable.Rows[index1][0].ToString().Equals(value, StringComparison.CurrentCultureIgnoreCase) ? (object) " selected=\"selected\"" : (object) "");
            stringBuilder.Append(dataTable.Rows[index1][index2]);
            stringBuilder.Append("</td>");
          }
        }
        stringBuilder.Append("</tr>");
      }
      stringBuilder.Append("</tr></tbody></table>");
      return stringBuilder.ToString();
    }

    public string GetArchivesString(string formHtml, string commentHtml)
    {
      return "<link href=\"" + Config.BaseUrl + "/Platform/WorkFlowRun/Scripts/Forms/flowform_print.css\" rel=\"stylesheet\" />        <style type=\"text/css\" media=\"print\">            .Noprint { display: none; }        </style>        <link href=\"" + Config.BaseUrl + "/Platform/WorkFlowRun/Scripts/Forms/flowform.css\" rel=\"stylesheet\" type=\"text/css\" />        <script src=\"" + Config.BaseUrl + "/Platform/WorkFlowRun/Scripts/Forms/common.js\" type=\"text/javascript\" ></script><div style=\"width:98%; margin:-10px auto 0 auto;\">" + formHtml + "<script type=\"text/javascript\">fieldStatus ={};displayModel='1';</script>" + "</div>";
    }

    public List<RoadFlow.Data.Model.WorkFlowForm> GetPagerData(out string pager, string query = "", string userid = "", string typeid = "", string name = "", int pagesize = 15)
    {
      return this.dataWorkFlowForm.GetPagerData(out pager, query, userid, typeid, name, pagesize);
    }

    public List<RoadFlow.Data.Model.WorkFlowForm> GetPagerData(out long count, int pageSize, int pageNumber, string userid = "", string typeid = "", string name = "", string order = "")
    {
      return this.dataWorkFlowForm.GetPagerData(out count, pageSize, pageNumber, userid, typeid, name, order);
    }

    public string GetWorkFlowFormXml(Guid formID, string applibaryID = "")
    {
      RoadFlow.Data.Model.WorkFlowForm workFlowForm = this.Get(formID);
      if (workFlowForm == null)
        return "";
      StringBuilder stringBuilder = new StringBuilder();
      stringBuilder.Append("<?xml version=\"1.0\" encoding=\"UTF-8\"?>");
      stringBuilder.Append("<WorkFlowForm>");
      stringBuilder.Append("<ID>" + workFlowForm.ID.ToString() + "</ID>");
      stringBuilder.Append("<Name><![CDATA[" + workFlowForm.Name + "]]></Name>");
      stringBuilder.Append("<Type>" + workFlowForm.Type.ToString() + "</Type>");
      stringBuilder.Append("<CreateUserID>" + workFlowForm.CreateUserID.ToString() + "</CreateUserID>");
      stringBuilder.Append("<CreateUserName>" + workFlowForm.CreateUserName + "</CreateUserName>");
      stringBuilder.Append("<CreateTime>" + workFlowForm.CreateTime.ToDateTimeStringS() + "</CreateTime>");
      stringBuilder.Append("<LastModifyTime>" + workFlowForm.LastModifyTime.ToDateTimeStringS() + "</LastModifyTime>");
      stringBuilder.Append("<Html><![CDATA[" + workFlowForm.Html + "]]></Html>");
      stringBuilder.Append("<SubTableJson><![CDATA[" + workFlowForm.SubTableJson + "]]></SubTableJson>");
      stringBuilder.Append("<EventsJson><![CDATA[" + workFlowForm.EventsJson + "]]></EventsJson>");
      stringBuilder.Append("<Attribute><![CDATA[" + workFlowForm.Attribute + "]]></Attribute>");
      stringBuilder.Append("<Status>" + workFlowForm.Status.ToString() + "</Status>");
      stringBuilder.Append("<ApplibaryID>" + applibaryID + "</ApplibaryID>");
      stringBuilder.Append("</WorkFlowForm>");
      return stringBuilder.ToString();
    }

    public bool AddFromXmlFile(string xmlFile, int type = 0)
    {
      XElement root = XDocument.Load(xmlFile).Root;
      Guid id = root.Element((XName) "ID") != null ? root.Element((XName) "ID").Value.ToGuid() : Guid.Empty;
      string str1 = root.Element((XName) "Name") != null ? root.Element((XName) "Name").Value : "";
      Guid guid = root.Element((XName) "Type") != null ? root.Element((XName) "Type").Value.ToGuid() : Guid.Empty;
      string str2 = root.Element((XName) "CreateUserID") != null ? root.Element((XName) "CreateUserID").Value : "";
      string str3 = root.Element((XName) "CreateUserName") != null ? root.Element((XName) "CreateUserName").Value : "";
      string str4 = root.Element((XName) "CreateTime") != null ? root.Element((XName) "CreateTime").Value : "";
      string str5 = root.Element((XName) "LastModifyTime") != null ? root.Element((XName) "LastModifyTime").Value : "";
      string str6 = root.Element((XName) "Html") != null ? root.Element((XName) "Html").Value : "";
      string str7 = root.Element((XName) "SubTableJson") != null ? root.Element((XName) "SubTableJson").Value : "";
      string str8 = root.Element((XName) "EventsJson") != null ? root.Element((XName) "EventsJson").Value : "";
      string str9 = root.Element((XName) "Attribute") != null ? root.Element((XName) "Attribute").Value : "";
      string str10 = root.Element((XName) "Status") != null ? root.Element((XName) "Status").Value : "";
      string str11 = root.Element((XName) "ApplibaryID") != null ? root.Element((XName) "ApplibaryID").Value : "";
      bool flag1 = false;
      RoadFlow.Data.Model.WorkFlowForm model1 = this.Get(id);
      if (model1 == null)
      {
        model1 = new RoadFlow.Data.Model.WorkFlowForm();
        flag1 = true;
      }
      model1.Attribute = str9;
      model1.CreateTime = str4.IsDateTime() ? str4.ToDateTime() : DateTimeNew.Now;
      model1.CreateUserID = str2.IsGuid() ? str2.ToGuid() : Users.CurrentUserID;
      model1.CreateUserName = str3.IsNullOrEmpty() ? Users.CurrentUserName : str3;
      model1.EventsJson = str8;
      model1.Html = str6;
      model1.ID = id;
      model1.LastModifyTime = str5.IsDateTime() ? str5.ToDateTime() : DateTimeNew.Now;
      model1.Name = str1;
      model1.Status = str10.ToInt(0);
      model1.SubTableJson = str7;
      model1.Type = guid;
      if (flag1)
        this.Add(model1);
      else
        this.Update(model1);
      AppLibrary appLibrary = new AppLibrary();
      RoadFlow.Data.Model.AppLibrary model2 = appLibrary.GetByCode(id.ToString(), true);
      bool flag2 = false;
      if (model2 == null)
      {
        model2 = new RoadFlow.Data.Model.AppLibrary();
        flag2 = true;
      }
      model2.ID = str11.IsGuid() ? str11.ToGuid() : Guid.NewGuid();
      model2.Address = type == 0 ? "/Platform/WorkFlowFormDesigner/Forms/" + model1.ID.ToString() + ".aspx" : "/Views/WorkFlowFormDesigner/Forms/" + model1.ID.ToString() + ".cshtml";
      model2.Note = "流程表单";
      model2.OpenMode = 0;
      model2.Params = "";
      model2.Title = model1.Name;
      model2.Code = model1.ID.ToString();
      model2.Type = guid.IsEmptyGuid() ? new Dictionary().GetIDByCode("FormTypes") : guid;
      if (flag2)
        appLibrary.Add(model2);
      else
        appLibrary.Update(model2);
      appLibrary.ClearCache();
      return true;
    }

    public string Export(Guid formID, int type = 0)
    {
      RoadFlow.Data.Model.WorkFlowForm workFlowForm = this.Get(formID);
      if (workFlowForm == null)
        return "";
      List<FileInfo> fileNames = new List<FileInfo>();
      string path = Config.FilePath + "WorkFlowFormExportFiles\\" + Guid.NewGuid().ToString("N") + "\\";
      if (!Directory.Exists(path))
        Directory.CreateDirectory(path);
      string str1 = path + "FlowFormDesigner_" + formID.ToString() + ".xml";
      if (File.Exists(str1))
        File.Delete(str1);
      RoadFlow.Data.Model.AppLibrary byCode = new AppLibrary().GetByCode(formID.ToString(), true);
      Guid formID1 = formID;
      Guid id;
      string applibaryID;
      if (byCode != null)
      {
        id = byCode.ID;
        applibaryID = id.ToString();
      }
      else
        applibaryID = "";
      string workFlowFormXml = this.GetWorkFlowFormXml(formID1, applibaryID);
      FileStream fileStream = new FileStream(str1, FileMode.Append);
      StreamWriter streamWriter = new StreamWriter((Stream) fileStream, Encoding.UTF8);
      streamWriter.Write(workFlowFormXml);
      streamWriter.Flush();
      streamWriter.Close();
      fileStream.Close();
      fileNames.Add(new FileInfo(str1));
      if (workFlowForm.Status == 1)
      {
        string str2;
        if (type != 0)
        {
          string str3 = HttpContext.Current.Server.MapPath("/Views/WorkFlowFormDesigner/Forms/");
          string str4 = "\\";
          id = workFlowForm.ID;
          string str5 = id.ToString();
          string str6 = ".cshtml";
          str2 = str3 + str4 + str5 + str6;
        }
        else
        {
          string str3 = HttpContext.Current.Server.MapPath("/Platform/WorkFlowFormDesigner/Forms/");
          string str4 = "\\";
          id = workFlowForm.ID;
          string str5 = id.ToString();
          string str6 = ".aspx";
          str2 = str3 + str4 + str5 + str6;
        }
        string str7 = str2;
        if (File.Exists(str7))
          fileNames.Add(new FileInfo(str7));
      }
      string GzipFileName = path + "\\" + workFlowForm.Name + "_" + formID.ToString() + ".zip";
      if (FileCompression.CompressFile(fileNames, GzipFileName, 0, false))
        return GzipFileName;
      return "";
    }

    public string Import(string zipFile, int type = 0)
    {
      string str1 = Path.GetDirectoryName(zipFile) + "\\";
      string contents = FileCompression.Decompress(zipFile, str1);
      if ("1" != contents)
      {
        Log.Add("解压文件出错-" + zipFile, contents, Log.Types.其它分类, "", "", (RoadFlow.Data.Model.Users) null);
        return "解压文件出错!";
      }
      IEnumerable<string> strings = ((IEnumerable<string>) Directory.GetFiles(str1)).Where<string>((Func<string, bool>) (p => Path.GetFileName(p).StartsWith("FlowFormDesigner_")));
      WorkFlowForm workFlowForm = new WorkFlowForm();
      foreach (string str2 in strings)
      {
        string[] strArray = Path.GetFileNameWithoutExtension(str2).Split('_');
        string empty1 = string.Empty;
        if (strArray.Length > 1)
          empty1 = strArray[1];
        if (!empty1.IsNullOrEmpty() && workFlowForm.AddFromXmlFile(str2, type))
        {
          string empty2 = string.Empty;
          string empty3 = string.Empty;
          string str3;
          string destFileName;
          if (type == 0)
          {
            str3 = Path.GetDirectoryName(str2) + "\\" + empty1 + ".aspx";
            destFileName = HttpContext.Current.Server.MapPath("/Platform/WorkFlowFormDesigner/Forms/") + "\\" + empty1 + ".aspx";
          }
          else
          {
            str3 = Path.GetDirectoryName(str2) + "\\" + empty1 + ".cshtml";
            destFileName = HttpContext.Current.Server.MapPath("/Views/WorkFlowFormDesigner/Forms/") + "\\" + empty1 + ".cshtml";
          }
          if (File.Exists(str3))
            File.Copy(str3, destFileName, true);
        }
      }
      return "1";
    }

    public string ReplaceTitleExpression(string expression, string tableName, string instanceId, out bool isEmptyField)
    {
      List<string> stringList = new List<string>();
      string str1 = expression;
      char[] chArray = new char[1]{ '{' };
      foreach (string str2 in str1.Split(chArray))
      {
        if (str2.IndexOf('}') >= 0)
          stringList.Add(str2.Substring(0, str2.IndexOf('}')));
      }
      string str3 = expression;
      bool flag = false;
      foreach (string str2 in stringList)
      {
        string str4 = HttpContext.Current.Request.Form[tableName + "." + str2];
        if (str4.IsNullOrEmpty())
        {
          string pk = HttpContext.Current.Request.Form["Form_DBTablePk"];
          JsonData formData = new WorkFlow().GetFormData(HttpContext.Current.Request.Form["Form_DBConnID"], tableName, pk, instanceId, "", "", "");
          str4 = formData.ContainsKey((tableName + "_" + str2).ToLower()) ? formData[(tableName + "_" + str2).ToLower()].ToString() : "";
        }
        if (str4.IsNullOrEmpty() && !flag)
          flag = true;
        str3 = str3.Replace("{" + str2 + "}", str4);
      }
      isEmptyField = flag;
      return str3;
    }
  }
}
