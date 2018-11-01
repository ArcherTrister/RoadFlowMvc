using RoadFlow.Cache.IO;
using RoadFlow.Data.Factory;
using RoadFlow.Data.Interface;
using RoadFlow.Data.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace RoadFlow.Platform
{
	public class Dictionary
	{
		public enum OptionValueField
		{
			ID,
			Title,
			Code,
			Value,
			Other,
			Note
		}

		private IDictionary dataDictionary;

		private static string cacheKey = 3.ToString();

		public Dictionary()
		{
			dataDictionary = Factory.GetDictionary();
		}

		public int Add(RoadFlow.Data.Model.Dictionary model)
		{
			return dataDictionary.Add(model);
		}

		public int Update(RoadFlow.Data.Model.Dictionary model)
		{
			return dataDictionary.Update(model);
		}

		public List<RoadFlow.Data.Model.Dictionary> GetAll(bool fromCache = false)
		{
			if (!fromCache)
			{
				return dataDictionary.GetAll();
			}
			List<RoadFlow.Data.Model.Dictionary> list = new List<RoadFlow.Data.Model.Dictionary>();
			object obj = Opation.Get(cacheKey);
			if (obj != null && obj is List<RoadFlow.Data.Model.Dictionary>)
			{
				list = (List<RoadFlow.Data.Model.Dictionary>)obj;
			}
			if (list.Count > 0)
			{
				return list;
			}
			list = dataDictionary.GetAll();
			Opation.Set(cacheKey, list);
			return list;
		}

		public RoadFlow.Data.Model.Dictionary Get(Guid id, bool fromCache = false)
		{
			if (fromCache)
			{
				RoadFlow.Data.Model.Dictionary dictionary = GetAll(true).Find((RoadFlow.Data.Model.Dictionary p) => p.ID == id);
				if (dictionary != null)
				{
					return dictionary;
				}
				return dataDictionary.Get(id);
			}
			return dataDictionary.Get(id);
		}

		public int Delete(Guid id)
		{
			return dataDictionary.Delete(id);
		}

		public long GetCount()
		{
			return dataDictionary.GetCount();
		}

		public RoadFlow.Data.Model.Dictionary GetRoot()
		{
			return dataDictionary.GetRoot();
		}

		public List<RoadFlow.Data.Model.Dictionary> GetChilds(Guid id, bool fromCache = false)
		{
			if (!fromCache)
			{
				return dataDictionary.GetChilds(id);
			}
			return getChildsByIDFromCache(id);
		}

		public List<RoadFlow.Data.Model.Dictionary> GetChilds(string code, bool fromCache = false)
		{
			if (!code.IsNullOrEmpty())
			{
				if (!fromCache)
				{
					return dataDictionary.GetChilds(code.Trim());
				}
				return getChildsByCodeFromCache(code);
			}
			return new List<RoadFlow.Data.Model.Dictionary>();
		}

		private List<RoadFlow.Data.Model.Dictionary> getChildsByCodeFromCache(string code)
		{
			List<RoadFlow.Data.Model.Dictionary> all = GetAll(true);
			RoadFlow.Data.Model.Dictionary dict = all.Find((RoadFlow.Data.Model.Dictionary p) => string.Compare(p.Code, code, true) == 0);
			if (dict != null)
			{
				return (from p in all.FindAll((RoadFlow.Data.Model.Dictionary p) => p.ParentID == dict.ID)
				orderby p.Sort
				select p).ToList();
			}
			return new List<RoadFlow.Data.Model.Dictionary>();
		}

		private List<RoadFlow.Data.Model.Dictionary> getChildsByIDFromCache(Guid id)
		{
			return (from p in GetAll(true).FindAll((RoadFlow.Data.Model.Dictionary p) => p.ParentID == id)
			orderby p.Sort
			select p).ToList();
		}

		public List<RoadFlow.Data.Model.Dictionary> GetAllParents(Guid id, bool isMe = true)
		{
			List<RoadFlow.Data.Model.Dictionary> list = new List<RoadFlow.Data.Model.Dictionary>();
			RoadFlow.Data.Model.Dictionary dictionary = Get(id);
			if (dictionary == null)
			{
				return list;
			}
			if (isMe)
			{
				list.Add(dictionary);
			}
			addParent(list, dictionary.ParentID);
			return list;
		}

		private void addParent(List<RoadFlow.Data.Model.Dictionary> list, Guid id)
		{
			RoadFlow.Data.Model.Dictionary parent = GetParent(id);
			if (parent != null)
			{
				list.Add(parent);
				addParent(list, parent.ParentID);
			}
		}

		public string GetAllParentTitles(Guid id, bool isMe = true, int type = 0, string split = " \\ ")
		{
			List<RoadFlow.Data.Model.Dictionary> allParents = GetAllParents(id, isMe);
			StringBuilder stringBuilder = new StringBuilder();
			if (type == 0)
			{
				allParents.Reverse();
			}
			foreach (RoadFlow.Data.Model.Dictionary item in allParents)
			{
				stringBuilder.Append(item.Title);
				if (item.ID != allParents.Last().ID)
				{
					stringBuilder.Append(split);
				}
			}
			return stringBuilder.ToString();
		}

		public List<RoadFlow.Data.Model.Dictionary> GetAllChilds(string code, bool fromCache)
		{
			if (code.IsNullOrEmpty())
			{
				return new List<RoadFlow.Data.Model.Dictionary>();
			}
			RoadFlow.Data.Model.Dictionary byCode = GetByCode(code, fromCache);
			if (byCode == null)
			{
				return new List<RoadFlow.Data.Model.Dictionary>();
			}
			return GetAllChilds(byCode.ID, fromCache);
		}

		public List<RoadFlow.Data.Model.Dictionary> GetAllChilds(Guid id, bool fromCache = false)
		{
			List<RoadFlow.Data.Model.Dictionary> list = new List<RoadFlow.Data.Model.Dictionary>();
			addChilds(list, id, fromCache);
			return list;
		}

		private void addChilds(List<RoadFlow.Data.Model.Dictionary> list, Guid id, bool fromCache = false)
		{
			foreach (RoadFlow.Data.Model.Dictionary item in fromCache ? getChildsByIDFromCache(id) : GetChilds(id))
			{
				list.Add(item);
				addChilds(list, item.ID, fromCache);
			}
		}

		public string GetAllChildsIDString(Guid id, bool isSelf = true)
		{
			StringBuilder stringBuilder = new StringBuilder();
			if (isSelf)
			{
				stringBuilder.Append(id);
				stringBuilder.Append(",");
			}
			foreach (RoadFlow.Data.Model.Dictionary allChild in GetAllChilds(id, true))
			{
				stringBuilder.Append(allChild.ID);
				stringBuilder.Append(",");
			}
			return stringBuilder.ToString().TrimEnd(',');
		}

		public RoadFlow.Data.Model.Dictionary GetParent(Guid id)
		{
			return dataDictionary.GetParent(id);
		}

		public bool HasChilds(Guid id)
		{
			return dataDictionary.HasChilds(id);
		}

		public int GetMaxSort(Guid id)
		{
			return dataDictionary.GetMaxSort(id);
		}

		public int UpdateSort(Guid id, int sort)
		{
			return dataDictionary.UpdateSort(id, sort);
		}

		public RoadFlow.Data.Model.Dictionary GetByCode(string code, bool fromCache = false)
		{
			if (!code.IsNullOrEmpty())
			{
				if (!fromCache)
				{
					return dataDictionary.GetByCode(code.Trim());
				}
				return GetAll(true).Find((RoadFlow.Data.Model.Dictionary p) => string.Compare(p.Code, code, true) == 0);
			}
			return null;
		}

		public string GetOptionsByID(Guid id, OptionValueField valueField = OptionValueField.Value, string value = "", bool isChild = true)
		{
			if (id.IsEmptyGuid())
			{
				return "";
			}
			List<RoadFlow.Data.Model.Dictionary> list = isChild ? GetAllChilds(id, true) : GetChilds(id, true);
			StringBuilder stringBuilder = new StringBuilder(list.Count * 100);
			StringBuilder stringBuilder2 = new StringBuilder();
			foreach (RoadFlow.Data.Model.Dictionary item in list)
			{
				stringBuilder2.Clear();
				int parentCount = getParentCount(list, item);
				for (int i = 0; i < parentCount - 1; i++)
				{
					stringBuilder2.Append("&nbsp;&nbsp;");
				}
				if (parentCount > 0)
				{
					stringBuilder2.Append("┝");
				}
				string optionsValue = getOptionsValue(valueField, item);
				stringBuilder.AppendFormat("<option value=\"{0}\"{1}>{2}{3}</option>", optionsValue, (optionsValue == value) ? " selected=\"selected\"" : "", stringBuilder2.ToString(), item.Title);
			}
			return stringBuilder.ToString();
		}

		private int getParentCount(List<RoadFlow.Data.Model.Dictionary> dictList, RoadFlow.Data.Model.Dictionary dict)
		{
			int num = 0;
			RoadFlow.Data.Model.Dictionary parentDict = dictList.Find((RoadFlow.Data.Model.Dictionary p) => p.ID == dict.ParentID);
			while (parentDict != null)
			{
				parentDict = dictList.Find((RoadFlow.Data.Model.Dictionary p) => p.ID == parentDict.ParentID);
				num++;
			}
			return num;
		}

		public string GetOptionsByCode(string code, OptionValueField valueField = OptionValueField.Value, string value = "", string attr = "", bool isChild = true)
		{
			return GetOptionsByID(GetIDByCode(code), valueField, value, isChild);
		}

		public string GetRadiosByID(Guid id, string name, OptionValueField valueField = OptionValueField.Value, string value = "", string attr = "")
		{
			List<RoadFlow.Data.Model.Dictionary> childs = GetChilds(id, true);
			return getRadios(childs, name, valueField, value, attr);
		}

		public string GetRadiosByCode(string code, string name, OptionValueField valueField = OptionValueField.Value, string value = "", string attr = "")
		{
			if (code.IsNullOrEmpty())
			{
				return "";
			}
			List<RoadFlow.Data.Model.Dictionary> childs = GetChilds(code.Trim(), true);
			return getRadios(childs, name, valueField, value, attr);
		}

		private string getRadios(List<RoadFlow.Data.Model.Dictionary> childs, string name, OptionValueField valueField = OptionValueField.Value, string value = "", string attr = "")
		{
			StringBuilder stringBuilder = new StringBuilder(childs.Count * 100);
			foreach (RoadFlow.Data.Model.Dictionary child in childs)
			{
				string optionsValue = getOptionsValue(valueField, child);
				stringBuilder.Append("<input type=\"radio\" style=\"vertical-align:middle;\" ");
				stringBuilder.AppendFormat("id=\"{0}_{1}\" ", name, child.ID.ToString("N"));
				stringBuilder.AppendFormat("name=\"{0}\" ", name);
				stringBuilder.AppendFormat("value=\"{0}\" ", optionsValue);
				stringBuilder.Append((string.Compare(value, optionsValue, true) == 0) ? "checked=\"checked\" " : "");
				stringBuilder.Append(attr);
				stringBuilder.Append("/>");
				stringBuilder.AppendFormat("<label style=\"vertical-align:middle;margin-right:3px;\" for=\"{0}_{1}\">{2}</label>", name, child.ID.ToString("N"), child.Title);
			}
			return stringBuilder.ToString();
		}

		public string GetCheckboxsByID(Guid id, string name, OptionValueField valueField = OptionValueField.Value, string value = "", string attr = "")
		{
			List<RoadFlow.Data.Model.Dictionary> childs = GetChilds(id, true);
			return getCheckboxs(childs, name, valueField, value, attr);
		}

		public string GetCheckboxsByCode(string code, string name, OptionValueField valueField = OptionValueField.Value, string value = "", string attr = "")
		{
			if (code.IsNullOrEmpty())
			{
				return "";
			}
			List<RoadFlow.Data.Model.Dictionary> childs = GetChilds(code.Trim(), true);
			return getCheckboxs(childs, name, valueField, value, attr);
		}

		private string getCheckboxs(List<RoadFlow.Data.Model.Dictionary> childs, string name, OptionValueField valueField = OptionValueField.Value, string value = "", string attr = "")
		{
			StringBuilder stringBuilder = new StringBuilder(childs.Count * 100);
			foreach (RoadFlow.Data.Model.Dictionary child in childs)
			{
				string optionsValue = getOptionsValue(valueField, child);
				stringBuilder.Append("<input type=\"checkbox\" style=\"vertical-align:middle;\" ");
				stringBuilder.AppendFormat("id=\"{0}_{1}\" ", name, child.ID.ToString("N"));
				stringBuilder.AppendFormat("name=\"{0}\" ", name);
				stringBuilder.AppendFormat("value=\"{0}\" ", optionsValue);
				stringBuilder.Append(value.Contains(optionsValue) ? "checked=\"checked\"" : "");
				stringBuilder.Append(attr);
				stringBuilder.Append("/>");
				stringBuilder.AppendFormat("<label style=\"vertical-align:middle;margin-right:3px;\" for=\"{0}_{1}\">{2}</label>", name, child.ID.ToString("N"), child.Title);
			}
			return stringBuilder.ToString();
		}

		private string getOptionsValue(OptionValueField valueField, RoadFlow.Data.Model.Dictionary dict)
		{
			string result = string.Empty;
			switch (valueField)
			{
			case OptionValueField.Code:
				result = dict.Code;
				break;
			case OptionValueField.ID:
				result = dict.ID.ToString();
				break;
			case OptionValueField.Note:
				result = dict.Note;
				break;
			case OptionValueField.Other:
				result = dict.Other;
				break;
			case OptionValueField.Title:
				result = dict.Title;
				break;
			case OptionValueField.Value:
				result = dict.Value;
				break;
			}
			return result;
		}

		public void RefreshCache()
		{
			Opation.Set(cacheKey, GetAll());
		}

		public bool HasCode(string code, string id = "")
		{
			if (code.IsNullOrEmpty())
			{
				return false;
			}
			RoadFlow.Data.Model.Dictionary byCode = GetByCode(code.Trim());
			if (byCode == null)
			{
				return false;
			}
			Guid test;
			if (id.IsGuid(out test) && byCode.ID == test)
			{
				return false;
			}
			return true;
		}

		public int DeleteAndAllChilds(Guid id)
		{
			int num = 0;
			foreach (RoadFlow.Data.Model.Dictionary allChild in GetAllChilds(id))
			{
				Delete(allChild.ID);
				num++;
			}
			Delete(id);
			return num + 1;
		}

		public string GetTitle(Guid id)
		{
			RoadFlow.Data.Model.Dictionary dictionary = Get(id, true);
			if (dictionary != null)
			{
				return dictionary.Title;
			}
			return "";
		}

		public string GetTitle(string code)
		{
			if (code.IsNullOrEmpty())
			{
				return "";
			}
			RoadFlow.Data.Model.Dictionary byCode = GetByCode(code.Trim(), true);
			if (byCode != null)
			{
				return byCode.Title;
			}
			return "";
		}

		public string GetTitle(string code, string value)
		{
			if (code.IsNullOrEmpty())
			{
				return "";
			}
			RoadFlow.Data.Model.Dictionary dictionary = getChildsByCodeFromCache(code.Trim()).Find((RoadFlow.Data.Model.Dictionary p) => p.Value == value);
			if (dictionary != null)
			{
				return dictionary.Title;
			}
			return "";
		}

		public Guid GetIDByCode(string code)
		{
			RoadFlow.Data.Model.Dictionary byCode = GetByCode(code, true);
			if (byCode != null)
			{
				return byCode.ID;
			}
			return Guid.Empty;
		}

		public string GetComboxTableHtmlByID(string id, OptionValueField valueField, string defaultValue)
		{
			if (!id.IsGuid())
			{
				return "";
			}
			List<RoadFlow.Data.Model.Dictionary> childs = GetChilds(id.ToGuid());
			StringBuilder stringBuilder = new StringBuilder(2000);
			stringBuilder.Append("<table><thead><tr><th>标题</th><th>备注</th><th>其它</th></tr></thead><tbody>");
			foreach (RoadFlow.Data.Model.Dictionary item in childs)
			{
				stringBuilder.Append("<tr>");
				stringBuilder.AppendFormat("<td value=\"{0}\"{1}>", item.ID, item.ID.ToString().Equals(defaultValue, StringComparison.CurrentCultureIgnoreCase) ? " selected=\"selected\"" : "");
				stringBuilder.Append(item.Title);
				stringBuilder.Append("</td>");
				stringBuilder.Append("<td>");
				stringBuilder.Append(item.Note);
				stringBuilder.Append("</td>");
				stringBuilder.Append("<td>");
				stringBuilder.Append(item.Other);
				stringBuilder.Append("</td>");
				stringBuilder.Append("</tr>");
			}
			stringBuilder.Append("</tbody>");
			stringBuilder.Append("</table>");
			return stringBuilder.ToString();
		}
	}
}
