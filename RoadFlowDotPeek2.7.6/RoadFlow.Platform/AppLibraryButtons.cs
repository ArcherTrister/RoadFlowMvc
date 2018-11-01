// Decompiled with JetBrains decompiler
// Type: RoadFlow.Platform.AppLibraryButtons
// Assembly: RoadFlow.Platform, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 07F26AFD-DE3B-4003-89AF-01A62494BA58
// Assembly location: C:\inetpub\wwwroot\RoadFlowMvc\bin\RoadFlow.Platform.dll

using LitJson;
using RoadFlow.Data.Interface;
using RoadFlow.Utility;
using System;
using System.Collections.Generic;
using System.Text;

namespace RoadFlow.Platform
{
  public class AppLibraryButtons
  {
    private IAppLibraryButtons dataAppLibraryButtons;

    public AppLibraryButtons()
    {
      this.dataAppLibraryButtons = RoadFlow.Data.Factory.Factory.GetAppLibraryButtons();
    }

    public int Add(RoadFlow.Data.Model.AppLibraryButtons model)
    {
      return this.dataAppLibraryButtons.Add(model);
    }

    public int Update(RoadFlow.Data.Model.AppLibraryButtons model)
    {
      return this.dataAppLibraryButtons.Update(model);
    }

    public List<RoadFlow.Data.Model.AppLibraryButtons> GetAll()
    {
      return this.dataAppLibraryButtons.GetAll();
    }

    public RoadFlow.Data.Model.AppLibraryButtons Get(Guid id)
    {
      return this.dataAppLibraryButtons.Get(id);
    }

    public int Delete(Guid id)
    {
      return this.dataAppLibraryButtons.Delete(id);
    }

    public long GetCount()
    {
      return this.dataAppLibraryButtons.GetCount();
    }

    public List<RoadFlow.Data.Model.AppLibraryButtons> GetPagerData(out string pager, string query = "", string title = "")
    {
      return this.dataAppLibraryButtons.GetPagerData(out pager, query, Tools.GetPageSize(), Tools.GetPageNumber(), title);
    }

    public List<RoadFlow.Data.Model.AppLibraryButtons> GetPagerData(out long count, int size, int number, string title = "", string order = "")
    {
      return this.dataAppLibraryButtons.GetPagerData(out count, size, number, title, order);
    }

    public int GetMaxSort()
    {
      return this.dataAppLibraryButtons.GetMaxSort();
    }

    public string GetAllJson()
    {
      List<RoadFlow.Data.Model.AppLibraryButtons> all = this.GetAll();
      JsonData jsonData = new JsonData();
      foreach (RoadFlow.Data.Model.AppLibraryButtons appLibraryButtons in all)
        jsonData.Add((object) new JsonData()
        {
          ["id"] = (JsonData) appLibraryButtons.ID.ToString(),
          ["name"] = (JsonData) appLibraryButtons.Name,
          ["events"] = (JsonData) appLibraryButtons.Events,
          ["ico"] = (JsonData) appLibraryButtons.Ico,
          ["sort"] = (JsonData) appLibraryButtons.Sort
        });
      //return jsonData.ToJson(true);
            return jsonData.ToJson();
        }

    public string GetShowTypeOptions(string value = "")
    {
      System.Collections.Generic.Dictionary<int, string> dictionary = new System.Collections.Generic.Dictionary<int, string>();
      dictionary.Add(1, "普通按钮");
      dictionary.Add(0, "工具栏按钮");
      dictionary.Add(2, "列表按钮");
      StringBuilder stringBuilder = new StringBuilder();
      foreach (KeyValuePair<int, string> keyValuePair in dictionary)
        stringBuilder.Append("<option value=\"" + (object) keyValuePair.Key + "\"" + (keyValuePair.Key.ToString() == value ? (object) " selected=\"selected\"" : (object) "") + ">" + keyValuePair.Value + "</option>");
      return stringBuilder.ToString();
    }

    public string GetOptions(string value = "")
    {
      List<RoadFlow.Data.Model.AppLibraryButtons> all = this.GetAll();
      StringBuilder stringBuilder = new StringBuilder();
      stringBuilder.Append("<option value=\"\"></option>");
      foreach (RoadFlow.Data.Model.AppLibraryButtons appLibraryButtons in all)
        stringBuilder.Append("<option value=\"" + (object) appLibraryButtons.ID + "\"" + (appLibraryButtons.ID == value.ToGuid() ? (object) " selected=\"selected\"" : (object) "") + ">" + appLibraryButtons.Name + "</option>");
      return stringBuilder.ToString();
    }
  }
}
