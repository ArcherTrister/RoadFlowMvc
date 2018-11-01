// Decompiled with JetBrains decompiler
// Type: RoadFlow.Platform.ProgramBuilderQuerys
// Assembly: RoadFlow.Platform, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 07F26AFD-DE3B-4003-89AF-01A62494BA58
// Assembly location: C:\inetpub\wwwroot\RoadFlowMvc\bin\RoadFlow.Platform.dll

using RoadFlow.Data.Interface;
using System;
using System.Collections.Generic;
using System.Text;

namespace RoadFlow.Platform
{
  public class ProgramBuilderQuerys
  {
    private IProgramBuilderQuerys dataProgramBuilderQuerys;

    public ProgramBuilderQuerys()
    {
      this.dataProgramBuilderQuerys = RoadFlow.Data.Factory.Factory.GetProgramBuilderQuerys();
    }

    public int Add(RoadFlow.Data.Model.ProgramBuilderQuerys model)
    {
      return this.dataProgramBuilderQuerys.Add(model);
    }

    public int Update(RoadFlow.Data.Model.ProgramBuilderQuerys model)
    {
      return this.dataProgramBuilderQuerys.Update(model);
    }

    public List<RoadFlow.Data.Model.ProgramBuilderQuerys> GetAll()
    {
      return this.dataProgramBuilderQuerys.GetAll();
    }

    public RoadFlow.Data.Model.ProgramBuilderQuerys Get(Guid id)
    {
      return this.dataProgramBuilderQuerys.Get(id);
    }

    public int Delete(Guid id)
    {
      return this.dataProgramBuilderQuerys.Delete(id);
    }

    public long GetCount()
    {
      return this.dataProgramBuilderQuerys.GetCount();
    }

    public List<RoadFlow.Data.Model.ProgramBuilderQuerys> GetAll(Guid programID)
    {
      return this.dataProgramBuilderQuerys.GetAll(programID);
    }

    public int DeleteByProgramID(Guid id)
    {
      return this.dataProgramBuilderQuerys.DeleteByProgramID(id);
    }

    public string GetQueryShowHtml(List<RoadFlow.Data.Model.ProgramBuilderQuerys> querys)
    {
      StringBuilder stringBuilder1 = new StringBuilder();
      foreach (RoadFlow.Data.Model.ProgramBuilderQuerys query in querys)
      {
        stringBuilder1.Append("<span style=\"margin-right:8px;\">");
        stringBuilder1.AppendFormat("<span>{0}：</span>", (object) query.ShowTitle);
        switch (query.InputType)
        {
          case 1:
            stringBuilder1.AppendFormat("<span><input type=\"text\" class=\"mytext\" id=\"{0}\" name=\"{0}\" style=\"{1}\" value=\"{2}\"/></span>", (object) query.ControlName, query.Width.IsNullOrEmpty() ? (object) "" : (object) query.Width, (object) query.Value);
            break;
          case 2:
            stringBuilder1.AppendFormat("<span><input type=\"text\" class=\"mycalendar\" id=\"{0}\" name=\"{0}\" style=\"{1}\" value=\"{2}\"/></span>", (object) query.ControlName, query.Width.IsNullOrEmpty() ? (object) "" : (object) query.Width, query.Value.IsDateTime() ? (object) query.Value.ToDateString() : (object) "");
            break;
          case 3:
            string[] strArray1 = query.Value.Split(',');
            stringBuilder1.Append("<span>");
            stringBuilder1.AppendFormat("<input type=\"text\" class=\"mycalendar\" id=\"{0}_start\" name=\"{0}_start\" style=\"{1}\" value=\"{2}\"/>", (object) query.ControlName, query.Width.IsNullOrEmpty() ? (object) "" : (object) query.Width, strArray1[0].IsDateTime() ? (object) strArray1[0].ToDateString() : (object) "");
            stringBuilder1.Append("<span style=\"margin:0 3px;\">至</span>");
            stringBuilder1.AppendFormat("<input type=\"text\" class=\"mycalendar\" id=\"{0}_end\" name=\"{0}_end\" style=\"{1}\" value=\"{2}\"/>", (object) query.ControlName, query.Width.IsNullOrEmpty() ? (object) "" : (object) query.Width, strArray1[1].IsDateTime() ? (object) strArray1[1].ToDateString() : (object) "");
            stringBuilder1.Append("</span>");
            break;
          case 4:
            stringBuilder1.AppendFormat("<span><input type=\"text\" class=\"mycalendar\" istime=\"1\" id=\"{0}\" name=\"{0}\" style=\"{1}\" value=\"{2}\"/></span>", (object) query.ControlName, query.Width.IsNullOrEmpty() ? (object) "" : (object) query.Width, query.Value.IsDateTime() ? (object) query.Value.ToDateTimeString() : (object) "");
            break;
          case 5:
            string[] strArray2 = query.Value.Split(',');
            stringBuilder1.Append("<span>");
            stringBuilder1.AppendFormat("<input type=\"text\" class=\"mycalendar\" istime=\"1\" id=\"{0}_start\" name=\"{0}_start\" style=\"{1}\" value=\"{2}\"/>", (object) query.ControlName, query.Width.IsNullOrEmpty() ? (object) "" : (object) query.Width, strArray2[0].IsDateTime() ? (object) strArray2[0].ToDateTimeString() : (object) "");
            stringBuilder1.Append("<span style=\"margin:0 3px;\">至</span>");
            stringBuilder1.AppendFormat("<input type=\"text\" class=\"mycalendar\" istime=\"1\" id=\"{0}_end\" name=\"{0}_end\" style=\"{1}\" value=\"{2}\"/>", (object) query.ControlName, query.Width.IsNullOrEmpty() ? (object) "" : (object) query.Width, strArray2[1].IsDateTime() ? (object) strArray2[1].ToDateTimeString() : (object) "");
            stringBuilder1.Append("</span>");
            break;
          case 6:
            StringBuilder stringBuilder2 = stringBuilder1;
            string format = "<span><select class=\"myselect\" id=\"{0}\" name=\"{0}\" style=\"max-width:300px;{1}\">{2}</select></span>";
            string controlName = query.ControlName;
            string str1 = query.Width.IsNullOrEmpty() ? "" : query.Width;
            int? dataSource1 = query.DataSource;
            int dataSource2;
            if (!dataSource1.HasValue)
            {
              dataSource2 = 0;
            }
            else
            {
              dataSource1 = query.DataSource;
              dataSource2 = dataSource1.Value;
            }
            string dataSourceString = query.DataSourceString;
            string str2 = query.Value;
            string dataLinkId = query.DataLinkID;
            string selectOptions = this.GetSelectOptions(dataSource2, dataSourceString, str2, dataLinkId);
            stringBuilder2.AppendFormat(format, (object) controlName, (object) str1, (object) selectOptions);
            break;
          case 7:
            stringBuilder1.AppendFormat("<span><input type=\"text\" class=\"mymember\" id=\"{0}\" name=\"{0}\" style=\"{1}\"{2} value=\"{3}\"/></span>", (object) query.ControlName, query.Width.IsNullOrEmpty() ? (object) "" : (object) query.Width, (object) this.GetOrganizeAttrString(query.DataSourceString), (object) query.Value);
            break;
          case 8:
            stringBuilder1.AppendFormat("<span><input type=\"text\" class=\"mydict\" id=\"{0}\" name=\"{0}\" style=\"{1}\"{2} value=\"{3}\"/></span>", (object) query.ControlName, query.Width.IsNullOrEmpty() ? (object) "" : (object) query.Width, (object) ("rootid=\"" + query.DataSourceString + "\""), (object) query.Value);
            break;
        }
        stringBuilder1.Append("</span>");
      }
      return stringBuilder1.ToString();
    }

    private string GetSelectOptions(int dataSource, string soureString, string value, string linkID = "")
    {
      switch (dataSource)
      {
        case 1:
          return new WorkFlowForm().GetOptionsFromString(soureString, value, true);
        case 2:
          return "<option value=\"\"></option>" + new Dictionary().GetOptionsByID(soureString.ToGuid(), Dictionary.OptionValueField.ID, value, true);
        case 3:
          return "<option value=\"\"></option>" + new WorkFlowForm().GetOptionsFromSql(linkID, soureString, value);
        default:
          return "";
      }
    }

    private string GetOrganizeAttrString(string attrString)
    {
      if (attrString.IsNullOrEmpty())
        return "";
      string[] strArray = attrString.Split('|');
      StringBuilder stringBuilder = new StringBuilder();
      if (strArray.Length != 0)
        stringBuilder.AppendFormat(" rootid=\"{0}\"", (object) strArray[0]);
      if (strArray.Length > 1)
        stringBuilder.AppendFormat(" unit=\"{0}\"", "1" == strArray[1] ? (object) "1" : (object) "0");
      if (strArray.Length > 2)
        stringBuilder.AppendFormat(" dept=\"{0}\"", "1" == strArray[2] ? (object) "1" : (object) "0");
      if (strArray.Length > 3)
        stringBuilder.AppendFormat(" station=\"{0}\"", "1" == strArray[3] ? (object) "1" : (object) "0");
      if (strArray.Length > 4)
        stringBuilder.AppendFormat(" group=\"{0}\"", "1" == strArray[4] ? (object) "1" : (object) "0");
      if (strArray.Length > 5)
        stringBuilder.AppendFormat(" role=\"{0}\"", "1" == strArray[5] ? (object) "1" : (object) "0");
      if (strArray.Length > 6)
        stringBuilder.AppendFormat(" user=\"{0}\"", "1" == strArray[6] ? (object) "1" : (object) "0");
      if (strArray.Length > 7)
        stringBuilder.AppendFormat(" more=\"{0}\"", "1" == strArray[7] ? (object) "1" : (object) "0");
      return stringBuilder.ToString();
    }

    public string GetQueryButtonHtml(RoadFlow.Data.Model.ProgramBuilder pb)
    {
      StringBuilder stringBuilder = new StringBuilder();
      stringBuilder.Append("<input type=\"submit\" name=\"searchbutton\" value=\" 查 询 \" class=\"mybutton\"/>");
      return stringBuilder.ToString();
    }

    public string GetButtonHtml(List<RoadFlow.Data.Model.ProgramBuilderButtons> buttons)
    {
      StringBuilder stringBuilder1 = new StringBuilder();
      StringBuilder stringBuilder2 = new StringBuilder();
      foreach (RoadFlow.Data.Model.ProgramBuilderButtons button in buttons)
      {
        string str1 = "fun_";
        Guid guid = Guid.NewGuid();
        string str2 = guid.ToString("N");
        string str3 = "()";
        string str4 = str1 + str2 + str3;
        stringBuilder2.Append("function ");
        stringBuilder2.Append(str4);
        stringBuilder2.Append("\r\n{\r\n");
        StringBuilder stringBuilder3 = stringBuilder2;
        string clientScript = button.ClientScript;
        guid = Users.CurrentUserID;
        string userID = guid.ToString();
        string str5 = clientScript.FilterWildcard(userID);
        stringBuilder3.Append(str5);
        stringBuilder2.Append("\r\n}\r\n");
        stringBuilder1.AppendFormat("<input style=\"margin-left:8px;\" onclick=\"{0};\" type=\"button\" name=\"addbutton\" value=\"{1}\" class=\"mybutton\"/>", (object) str4, (object) button.ButtonName);
      }
      stringBuilder1.Append("<script type=\"text/javascript\">");
      stringBuilder1.Append((object) stringBuilder2);
      stringBuilder1.Append("</script>");
      return stringBuilder1.ToString();
    }
  }
}
