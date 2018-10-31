// Decompiled with JetBrains decompiler
// Type: RoadFlow.Platform.Dictionary
// Assembly: RoadFlow.Platform, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 07F26AFD-DE3B-4003-89AF-01A62494BA58
// Assembly location: C:\inetpub\wwwroot\RoadFlowMvc\bin\RoadFlow.Platform.dll

using RoadFlow.Cache.IO;
using RoadFlow.Data.Interface;
using RoadFlow.Utility;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace RoadFlow.Platform
{
  public class Dictionary
  {
    private static string cacheKey = Keys.CacheKeys.Dictionary.ToString();
    private IDictionary dataDictionary;

    public Dictionary()
    {
      this.dataDictionary = RoadFlow.Data.Factory.Factory.GetDictionary();
    }

    public int Add(RoadFlow.Data.Model.Dictionary model)
    {
      return this.dataDictionary.Add(model);
    }

    public int Update(RoadFlow.Data.Model.Dictionary model)
    {
      return this.dataDictionary.Update(model);
    }

    public List<RoadFlow.Data.Model.Dictionary> GetAll(bool fromCache = false)
    {
      if (!fromCache)
        return this.dataDictionary.GetAll();
      List<RoadFlow.Data.Model.Dictionary> dictionaryList = new List<RoadFlow.Data.Model.Dictionary>();
      object obj = Opation.Get(Dictionary.cacheKey);
      if (obj != null && obj is List<RoadFlow.Data.Model.Dictionary>)
        dictionaryList = (List<RoadFlow.Data.Model.Dictionary>) obj;
      if (dictionaryList.Count > 0)
        return dictionaryList;
      List<RoadFlow.Data.Model.Dictionary> all = this.dataDictionary.GetAll();
      Opation.Set(Dictionary.cacheKey, (object) all);
      return all;
    }

    public RoadFlow.Data.Model.Dictionary Get(Guid id, bool fromCache = false)
    {
      if (fromCache)
        return this.GetAll(true).Find((Predicate<RoadFlow.Data.Model.Dictionary>) (p => p.ID == id)) ?? this.dataDictionary.Get(id);
      return this.dataDictionary.Get(id);
    }

    public int Delete(Guid id)
    {
      return this.dataDictionary.Delete(id);
    }

    public long GetCount()
    {
      return this.dataDictionary.GetCount();
    }

    public RoadFlow.Data.Model.Dictionary GetRoot()
    {
      return this.dataDictionary.GetRoot();
    }

    public List<RoadFlow.Data.Model.Dictionary> GetChilds(Guid id, bool fromCache = false)
    {
      if (!fromCache)
        return this.dataDictionary.GetChilds(id);
      return this.getChildsByIDFromCache(id);
    }

    public List<RoadFlow.Data.Model.Dictionary> GetChilds(string code, bool fromCache = false)
    {
      if (code.IsNullOrEmpty())
        return new List<RoadFlow.Data.Model.Dictionary>();
      if (!fromCache)
        return this.dataDictionary.GetChilds(code.Trim());
      return this.getChildsByCodeFromCache(code);
    }

    private List<RoadFlow.Data.Model.Dictionary> getChildsByCodeFromCache(string code)
    {
      List<RoadFlow.Data.Model.Dictionary> all = this.GetAll(true);
      RoadFlow.Data.Model.Dictionary dict = all.Find((Predicate<RoadFlow.Data.Model.Dictionary>) (p => string.Compare(p.Code, code, true) == 0));
      if (dict != null)
        return all.FindAll((Predicate<RoadFlow.Data.Model.Dictionary>) (p => p.ParentID == dict.ID)).OrderBy<RoadFlow.Data.Model.Dictionary, int>((Func<RoadFlow.Data.Model.Dictionary, int>) (p => p.Sort)).ToList<RoadFlow.Data.Model.Dictionary>();
      return new List<RoadFlow.Data.Model.Dictionary>();
    }

    private List<RoadFlow.Data.Model.Dictionary> getChildsByIDFromCache(Guid id)
    {
      return this.GetAll(true).FindAll((Predicate<RoadFlow.Data.Model.Dictionary>) (p => p.ParentID == id)).OrderBy<RoadFlow.Data.Model.Dictionary, int>((Func<RoadFlow.Data.Model.Dictionary, int>) (p => p.Sort)).ToList<RoadFlow.Data.Model.Dictionary>();
    }

    public List<RoadFlow.Data.Model.Dictionary> GetAllParents(Guid id, bool isMe = true)
    {
      List<RoadFlow.Data.Model.Dictionary> list = new List<RoadFlow.Data.Model.Dictionary>();
      RoadFlow.Data.Model.Dictionary dictionary = this.Get(id, false);
      if (dictionary == null)
        return list;
      if (isMe)
        list.Add(dictionary);
      this.addParent(list, dictionary.ParentID);
      return list;
    }

    private void addParent(List<RoadFlow.Data.Model.Dictionary> list, Guid id)
    {
      RoadFlow.Data.Model.Dictionary parent = this.GetParent(id);
      if (parent == null)
        return;
      list.Add(parent);
      this.addParent(list, parent.ParentID);
    }

    public string GetAllParentTitles(Guid id, bool isMe = true, int type = 0, string split = " \\ ")
    {
      List<RoadFlow.Data.Model.Dictionary> allParents = this.GetAllParents(id, isMe);
      StringBuilder stringBuilder = new StringBuilder();
      if (type == 0)
        allParents.Reverse();
      foreach (RoadFlow.Data.Model.Dictionary dictionary in allParents)
      {
        stringBuilder.Append(dictionary.Title);
        if (dictionary.ID != allParents.Last<RoadFlow.Data.Model.Dictionary>().ID)
          stringBuilder.Append(split);
      }
      return stringBuilder.ToString();
    }

    public List<RoadFlow.Data.Model.Dictionary> GetAllChilds(string code, bool fromCache)
    {
      if (code.IsNullOrEmpty())
        return new List<RoadFlow.Data.Model.Dictionary>();
      RoadFlow.Data.Model.Dictionary byCode = this.GetByCode(code, fromCache);
      if (byCode == null)
        return new List<RoadFlow.Data.Model.Dictionary>();
      return this.GetAllChilds(byCode.ID, fromCache);
    }

    public List<RoadFlow.Data.Model.Dictionary> GetAllChilds(Guid id, bool fromCache = false)
    {
      List<RoadFlow.Data.Model.Dictionary> list = new List<RoadFlow.Data.Model.Dictionary>();
      this.addChilds(list, id, fromCache);
      return list;
    }

    private void addChilds(List<RoadFlow.Data.Model.Dictionary> list, Guid id, bool fromCache = false)
    {
      foreach (RoadFlow.Data.Model.Dictionary dictionary in fromCache ? this.getChildsByIDFromCache(id) : this.GetChilds(id, false))
      {
        list.Add(dictionary);
        this.addChilds(list, dictionary.ID, fromCache);
      }
    }

    public string GetAllChildsIDString(Guid id, bool isSelf = true)
    {
      StringBuilder stringBuilder = new StringBuilder();
      if (isSelf)
      {
        stringBuilder.Append((object) id);
        stringBuilder.Append(",");
      }
      foreach (RoadFlow.Data.Model.Dictionary allChild in this.GetAllChilds(id, true))
      {
        stringBuilder.Append((object) allChild.ID);
        stringBuilder.Append(",");
      }
      return stringBuilder.ToString().TrimEnd(',');
    }

    public RoadFlow.Data.Model.Dictionary GetParent(Guid id)
    {
      return this.dataDictionary.GetParent(id);
    }

    public bool HasChilds(Guid id)
    {
      return this.dataDictionary.HasChilds(id);
    }

    public int GetMaxSort(Guid id)
    {
      return this.dataDictionary.GetMaxSort(id);
    }

    public int UpdateSort(Guid id, int sort)
    {
      return this.dataDictionary.UpdateSort(id, sort);
    }

    public RoadFlow.Data.Model.Dictionary GetByCode(string code, bool fromCache = false)
    {
      if (code.IsNullOrEmpty())
        return (RoadFlow.Data.Model.Dictionary) null;
      if (!fromCache)
        return this.dataDictionary.GetByCode(code.Trim());
      return this.GetAll(true).Find((Predicate<RoadFlow.Data.Model.Dictionary>) (p => string.Compare(p.Code, code, true) == 0));
    }

    public string GetOptionsByID(Guid id, Dictionary.OptionValueField valueField = Dictionary.OptionValueField.Value, string value = "", bool isChild = true)
    {
      if (id.IsEmptyGuid())
        return "";
      List<RoadFlow.Data.Model.Dictionary> dictList = isChild ? this.GetAllChilds(id, true) : this.GetChilds(id, true);
      StringBuilder stringBuilder1 = new StringBuilder(dictList.Count * 100);
      StringBuilder stringBuilder2 = new StringBuilder();
      foreach (RoadFlow.Data.Model.Dictionary dict in dictList)
      {
        stringBuilder2.Clear();
        int parentCount = this.getParentCount(dictList, dict);
        for (int index = 0; index < parentCount - 1; ++index)
          stringBuilder2.Append("&nbsp;&nbsp;");
        if (parentCount > 0)
          stringBuilder2.Append("┝");
        string optionsValue = this.getOptionsValue(valueField, dict);
        stringBuilder1.AppendFormat("<option value=\"{0}\"{1}>{2}{3}</option>", (object) optionsValue, optionsValue == value ? (object) " selected=\"selected\"" : (object) "", (object) stringBuilder2.ToString(), (object) dict.Title);
      }
      return stringBuilder1.ToString();
    }

    private int getParentCount(List<RoadFlow.Data.Model.Dictionary> dictList, RoadFlow.Data.Model.Dictionary dict)
    {
      int num = 0;
      RoadFlow.Data.Model.Dictionary parentDict = dictList.Find((Predicate<RoadFlow.Data.Model.Dictionary>) (p => p.ID == dict.ParentID));
      while (parentDict != null)
      {
        parentDict = dictList.Find((Predicate<RoadFlow.Data.Model.Dictionary>) (p => p.ID == parentDict.ParentID));
        ++num;
      }
      return num;
    }

    public string GetOptionsByCode(string code, Dictionary.OptionValueField valueField = Dictionary.OptionValueField.Value, string value = "", string attr = "", bool isChild = true)
    {
      return this.GetOptionsByID(this.GetIDByCode(code), valueField, value, isChild);
    }

    public string GetRadiosByID(Guid id, string name, Dictionary.OptionValueField valueField = Dictionary.OptionValueField.Value, string value = "", string attr = "")
    {
      return this.getRadios(this.GetChilds(id, true), name, valueField, value, attr);
    }

    public string GetRadiosByCode(string code, string name, Dictionary.OptionValueField valueField = Dictionary.OptionValueField.Value, string value = "", string attr = "")
    {
      if (code.IsNullOrEmpty())
        return "";
      return this.getRadios(this.GetChilds(code.Trim(), true), name, valueField, value, attr);
    }

    private string getRadios(List<RoadFlow.Data.Model.Dictionary> childs, string name, Dictionary.OptionValueField valueField = Dictionary.OptionValueField.Value, string value = "", string attr = "")
    {
      StringBuilder stringBuilder = new StringBuilder(childs.Count * 100);
      foreach (RoadFlow.Data.Model.Dictionary child in childs)
      {
        string optionsValue = this.getOptionsValue(valueField, child);
        stringBuilder.Append("<input type=\"radio\" style=\"vertical-align:middle;\" ");
        stringBuilder.AppendFormat("id=\"{0}_{1}\" ", (object) name, (object) child.ID.ToString("N"));
        stringBuilder.AppendFormat("name=\"{0}\" ", (object) name);
        stringBuilder.AppendFormat("value=\"{0}\" ", (object) optionsValue);
        stringBuilder.Append(string.Compare(value, optionsValue, true) == 0 ? "checked=\"checked\" " : "");
        stringBuilder.Append(attr);
        stringBuilder.Append("/>");
        stringBuilder.AppendFormat("<label style=\"vertical-align:middle;margin-right:3px;\" for=\"{0}_{1}\">{2}</label>", (object) name, (object) child.ID.ToString("N"), (object) child.Title);
      }
      return stringBuilder.ToString();
    }

    public string GetCheckboxsByID(Guid id, string name, Dictionary.OptionValueField valueField = Dictionary.OptionValueField.Value, string value = "", string attr = "")
    {
      return this.getCheckboxs(this.GetChilds(id, true), name, valueField, value, attr);
    }

    public string GetCheckboxsByCode(string code, string name, Dictionary.OptionValueField valueField = Dictionary.OptionValueField.Value, string value = "", string attr = "")
    {
      if (code.IsNullOrEmpty())
        return "";
      return this.getCheckboxs(this.GetChilds(code.Trim(), true), name, valueField, value, attr);
    }

    private string getCheckboxs(List<RoadFlow.Data.Model.Dictionary> childs, string name, Dictionary.OptionValueField valueField = Dictionary.OptionValueField.Value, string value = "", string attr = "")
    {
      StringBuilder stringBuilder = new StringBuilder(childs.Count * 100);
      foreach (RoadFlow.Data.Model.Dictionary child in childs)
      {
        string optionsValue = this.getOptionsValue(valueField, child);
        stringBuilder.Append("<input type=\"checkbox\" style=\"vertical-align:middle;\" ");
        stringBuilder.AppendFormat("id=\"{0}_{1}\" ", (object) name, (object) child.ID.ToString("N"));
        stringBuilder.AppendFormat("name=\"{0}\" ", (object) name);
        stringBuilder.AppendFormat("value=\"{0}\" ", (object) optionsValue);
        stringBuilder.Append(value.Contains(optionsValue) ? "checked=\"checked\"" : "");
        stringBuilder.Append(attr);
        stringBuilder.Append("/>");
        stringBuilder.AppendFormat("<label style=\"vertical-align:middle;margin-right:3px;\" for=\"{0}_{1}\">{2}</label>", (object) name, (object) child.ID.ToString("N"), (object) child.Title);
      }
      return stringBuilder.ToString();
    }

    private string getOptionsValue(Dictionary.OptionValueField valueField, RoadFlow.Data.Model.Dictionary dict)
    {
      string str = string.Empty;
      switch (valueField)
      {
        case Dictionary.OptionValueField.ID:
          str = dict.ID.ToString();
          break;
        case Dictionary.OptionValueField.Title:
          str = dict.Title;
          break;
        case Dictionary.OptionValueField.Code:
          str = dict.Code;
          break;
        case Dictionary.OptionValueField.Value:
          str = dict.Value;
          break;
        case Dictionary.OptionValueField.Other:
          str = dict.Other;
          break;
        case Dictionary.OptionValueField.Note:
          str = dict.Note;
          break;
      }
      return str;
    }

    public void RefreshCache()
    {
      Opation.Set(Dictionary.cacheKey, (object) this.GetAll(false));
    }

    public bool HasCode(string code, string id = "")
    {
      if (code.IsNullOrEmpty())
        return false;
      RoadFlow.Data.Model.Dictionary byCode = this.GetByCode(code.Trim(), false);
      Guid test;
      return byCode != null && (!id.IsGuid(out test) || !(byCode.ID == test));
    }

    public int DeleteAndAllChilds(Guid id)
    {
      int num = 0;
      foreach (RoadFlow.Data.Model.Dictionary allChild in this.GetAllChilds(id, false))
      {
        this.Delete(allChild.ID);
        ++num;
      }
      this.Delete(id);
      return num + 1;
    }

    public string GetTitle(Guid id)
    {
      RoadFlow.Data.Model.Dictionary dictionary = this.Get(id, true);
      if (dictionary != null)
        return dictionary.Title;
      return "";
    }

    public string GetTitle(string code)
    {
      if (code.IsNullOrEmpty())
        return "";
      RoadFlow.Data.Model.Dictionary byCode = this.GetByCode(code.Trim(), true);
      if (byCode != null)
        return byCode.Title;
      return "";
    }

    public string GetTitle(string code, string value)
    {
      if (code.IsNullOrEmpty())
        return "";
      RoadFlow.Data.Model.Dictionary dictionary = this.getChildsByCodeFromCache(code.Trim()).Find((Predicate<RoadFlow.Data.Model.Dictionary>) (p => p.Value == value));
      if (dictionary != null)
        return dictionary.Title;
      return "";
    }

    public Guid GetIDByCode(string code)
    {
      RoadFlow.Data.Model.Dictionary byCode = this.GetByCode(code, true);
      if (byCode != null)
        return byCode.ID;
      return Guid.Empty;
    }

    public string GetComboxTableHtmlByID(string id, Dictionary.OptionValueField valueField, string defaultValue)
    {
      if (!id.IsGuid())
        return "";
      List<RoadFlow.Data.Model.Dictionary> childs = this.GetChilds(id.ToGuid(), false);
      StringBuilder stringBuilder = new StringBuilder(2000);
      stringBuilder.Append("<table><thead><tr><th>标题</th><th>备注</th><th>其它</th></tr></thead><tbody>");
      foreach (RoadFlow.Data.Model.Dictionary dictionary in childs)
      {
        stringBuilder.Append("<tr>");
        stringBuilder.AppendFormat("<td value=\"{0}\"{1}>", (object) dictionary.ID, dictionary.ID.ToString().Equals(defaultValue, StringComparison.CurrentCultureIgnoreCase) ? (object) " selected=\"selected\"" : (object) "");
        stringBuilder.Append(dictionary.Title);
        stringBuilder.Append("</td>");
        stringBuilder.Append("<td>");
        stringBuilder.Append(dictionary.Note);
        stringBuilder.Append("</td>");
        stringBuilder.Append("<td>");
        stringBuilder.Append(dictionary.Other);
        stringBuilder.Append("</td>");
        stringBuilder.Append("</tr>");
      }
      stringBuilder.Append("</tbody>");
      stringBuilder.Append("</table>");
      return stringBuilder.ToString();
    }

    public enum OptionValueField
    {
      ID,
      Title,
      Code,
      Value,
      Other,
      Note,
    }
  }
}
