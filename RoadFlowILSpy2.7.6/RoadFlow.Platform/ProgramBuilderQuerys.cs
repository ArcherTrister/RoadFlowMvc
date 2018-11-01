using RoadFlow.Data.Factory;
using RoadFlow.Data.Interface;
using RoadFlow.Data.Model;
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
			dataProgramBuilderQuerys = Factory.GetProgramBuilderQuerys();
		}

		public int Add(RoadFlow.Data.Model.ProgramBuilderQuerys model)
		{
			return dataProgramBuilderQuerys.Add(model);
		}

		public int Update(RoadFlow.Data.Model.ProgramBuilderQuerys model)
		{
			return dataProgramBuilderQuerys.Update(model);
		}

		public List<RoadFlow.Data.Model.ProgramBuilderQuerys> GetAll()
		{
			return dataProgramBuilderQuerys.GetAll();
		}

		public RoadFlow.Data.Model.ProgramBuilderQuerys Get(Guid id)
		{
			return dataProgramBuilderQuerys.Get(id);
		}

		public int Delete(Guid id)
		{
			return dataProgramBuilderQuerys.Delete(id);
		}

		public long GetCount()
		{
			return dataProgramBuilderQuerys.GetCount();
		}

		public List<RoadFlow.Data.Model.ProgramBuilderQuerys> GetAll(Guid programID)
		{
			return dataProgramBuilderQuerys.GetAll(programID);
		}

		public int DeleteByProgramID(Guid id)
		{
			return dataProgramBuilderQuerys.DeleteByProgramID(id);
		}

		public string GetQueryShowHtml(List<RoadFlow.Data.Model.ProgramBuilderQuerys> querys)
		{
			StringBuilder stringBuilder = new StringBuilder();
			foreach (RoadFlow.Data.Model.ProgramBuilderQuerys query in querys)
			{
				stringBuilder.Append("<span style=\"margin-right:8px;\">");
				stringBuilder.AppendFormat("<span>{0}：</span>", query.ShowTitle);
				switch (query.InputType)
				{
				case 1:
					stringBuilder.AppendFormat("<span><input type=\"text\" class=\"mytext\" id=\"{0}\" name=\"{0}\" style=\"{1}\" value=\"{2}\"/></span>", query.ControlName, query.Width.IsNullOrEmpty() ? "" : query.Width, query.Value);
					break;
				case 2:
					stringBuilder.AppendFormat("<span><input type=\"text\" class=\"mycalendar\" id=\"{0}\" name=\"{0}\" style=\"{1}\" value=\"{2}\"/></span>", query.ControlName, query.Width.IsNullOrEmpty() ? "" : query.Width, query.Value.IsDateTime() ? query.Value.ToDateString() : "");
					break;
				case 3:
				{
					string[] array2 = query.Value.Split(',');
					stringBuilder.Append("<span>");
					stringBuilder.AppendFormat("<input type=\"text\" class=\"mycalendar\" id=\"{0}_start\" name=\"{0}_start\" style=\"{1}\" value=\"{2}\"/>", query.ControlName, query.Width.IsNullOrEmpty() ? "" : query.Width, array2[0].IsDateTime() ? array2[0].ToDateString() : "");
					stringBuilder.Append("<span style=\"margin:0 3px;\">至</span>");
					stringBuilder.AppendFormat("<input type=\"text\" class=\"mycalendar\" id=\"{0}_end\" name=\"{0}_end\" style=\"{1}\" value=\"{2}\"/>", query.ControlName, query.Width.IsNullOrEmpty() ? "" : query.Width, array2[1].IsDateTime() ? array2[1].ToDateString() : "");
					stringBuilder.Append("</span>");
					break;
				}
				case 4:
					stringBuilder.AppendFormat("<span><input type=\"text\" class=\"mycalendar\" istime=\"1\" id=\"{0}\" name=\"{0}\" style=\"{1}\" value=\"{2}\"/></span>", query.ControlName, query.Width.IsNullOrEmpty() ? "" : query.Width, query.Value.IsDateTime() ? query.Value.ToDateTimeString() : "");
					break;
				case 5:
				{
					string[] array = query.Value.Split(',');
					stringBuilder.Append("<span>");
					stringBuilder.AppendFormat("<input type=\"text\" class=\"mycalendar\" istime=\"1\" id=\"{0}_start\" name=\"{0}_start\" style=\"{1}\" value=\"{2}\"/>", query.ControlName, query.Width.IsNullOrEmpty() ? "" : query.Width, array[0].IsDateTime() ? array[0].ToDateTimeString() : "");
					stringBuilder.Append("<span style=\"margin:0 3px;\">至</span>");
					stringBuilder.AppendFormat("<input type=\"text\" class=\"mycalendar\" istime=\"1\" id=\"{0}_end\" name=\"{0}_end\" style=\"{1}\" value=\"{2}\"/>", query.ControlName, query.Width.IsNullOrEmpty() ? "" : query.Width, array[1].IsDateTime() ? array[1].ToDateTimeString() : "");
					stringBuilder.Append("</span>");
					break;
				}
				case 6:
					stringBuilder.AppendFormat("<span><select class=\"myselect\" id=\"{0}\" name=\"{0}\" style=\"max-width:300px;{1}\">{2}</select></span>", query.ControlName, query.Width.IsNullOrEmpty() ? "" : query.Width, GetSelectOptions(query.DataSource.HasValue ? query.DataSource.Value : 0, query.DataSourceString, query.Value, query.DataLinkID));
					break;
				case 7:
					stringBuilder.AppendFormat("<span><input type=\"text\" class=\"mymember\" id=\"{0}\" name=\"{0}\" style=\"{1}\"{2} value=\"{3}\"/></span>", query.ControlName, query.Width.IsNullOrEmpty() ? "" : query.Width, GetOrganizeAttrString(query.DataSourceString), query.Value);
					break;
				case 8:
					stringBuilder.AppendFormat("<span><input type=\"text\" class=\"mydict\" id=\"{0}\" name=\"{0}\" style=\"{1}\"{2} value=\"{3}\"/></span>", query.ControlName, query.Width.IsNullOrEmpty() ? "" : query.Width, "rootid=\"" + query.DataSourceString + "\"", query.Value);
					break;
				}
				stringBuilder.Append("</span>");
			}
			return stringBuilder.ToString();
		}

		private string GetSelectOptions(int dataSource, string soureString, string value, string linkID = "")
		{
			switch (dataSource)
			{
			case 1:
				return new WorkFlowForm().GetOptionsFromString(soureString, value);
			case 2:
				return "<option value=\"\"></option>" + new Dictionary().GetOptionsByID(soureString.ToGuid(), Dictionary.OptionValueField.ID, value);
			case 3:
				return "<option value=\"\"></option>" + new WorkFlowForm().GetOptionsFromSql(linkID, soureString, value);
			default:
				return "";
			}
		}

		private string GetOrganizeAttrString(string attrString)
		{
			if (attrString.IsNullOrEmpty())
			{
				return "";
			}
			string[] array = attrString.Split('|');
			StringBuilder stringBuilder = new StringBuilder();
			if (array.Length != 0)
			{
				stringBuilder.AppendFormat(" rootid=\"{0}\"", array[0]);
			}
			if (array.Length > 1)
			{
				stringBuilder.AppendFormat(" unit=\"{0}\"", ("1" == array[1]) ? "1" : "0");
			}
			if (array.Length > 2)
			{
				stringBuilder.AppendFormat(" dept=\"{0}\"", ("1" == array[2]) ? "1" : "0");
			}
			if (array.Length > 3)
			{
				stringBuilder.AppendFormat(" station=\"{0}\"", ("1" == array[3]) ? "1" : "0");
			}
			if (array.Length > 4)
			{
				stringBuilder.AppendFormat(" group=\"{0}\"", ("1" == array[4]) ? "1" : "0");
			}
			if (array.Length > 5)
			{
				stringBuilder.AppendFormat(" role=\"{0}\"", ("1" == array[5]) ? "1" : "0");
			}
			if (array.Length > 6)
			{
				stringBuilder.AppendFormat(" user=\"{0}\"", ("1" == array[6]) ? "1" : "0");
			}
			if (array.Length > 7)
			{
				stringBuilder.AppendFormat(" more=\"{0}\"", ("1" == array[7]) ? "1" : "0");
			}
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
			StringBuilder stringBuilder = new StringBuilder();
			StringBuilder stringBuilder2 = new StringBuilder();
			foreach (RoadFlow.Data.Model.ProgramBuilderButtons button in buttons)
			{
				string text = "fun_" + Guid.NewGuid().ToString("N") + "()";
				stringBuilder2.Append("function ");
				stringBuilder2.Append(text);
				stringBuilder2.Append("\r\n{\r\n");
				stringBuilder2.Append(button.ClientScript.FilterWildcard(Users.CurrentUserID.ToString()));
				stringBuilder2.Append("\r\n}\r\n");
				stringBuilder.AppendFormat("<input style=\"margin-left:8px;\" onclick=\"{0};\" type=\"button\" name=\"addbutton\" value=\"{1}\" class=\"mybutton\"/>", text, button.ButtonName);
			}
			stringBuilder.Append("<script type=\"text/javascript\">");
			stringBuilder.Append(stringBuilder2);
			stringBuilder.Append("</script>");
			return stringBuilder.ToString();
		}
	}
}
