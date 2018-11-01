// Decompiled with JetBrains decompiler
// Type: RoadFlow.Platform.Log
// Assembly: RoadFlow.Platform, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 07F26AFD-DE3B-4003-89AF-01A62494BA58
// Assembly location: C:\inetpub\wwwroot\RoadFlowMvc\bin\RoadFlow.Platform.dll

using RoadFlow.Data.Interface;
using RoadFlow.Utility;
using System;
using System.Collections.Generic;
using System.Data;
using System.Text;
using System.Web;

namespace RoadFlow.Platform
{
  public class Log
  {
    private static ILog dataLog1 = RoadFlow.Data.Factory.Factory.GetLog();
    private ILog dataLog;

    public Log()
    {
      this.dataLog = Log.dataLog1;
    }

    public int Update(RoadFlow.Data.Model.Log model)
    {
      return this.dataLog.Update(model);
    }

    public List<RoadFlow.Data.Model.Log> GetAll()
    {
      return this.dataLog.GetAll();
    }

    public RoadFlow.Data.Model.Log Get(Guid id)
    {
      return this.dataLog.Get(id);
    }

    public int Delete(Guid id)
    {
      return this.dataLog.Delete(id);
    }

    public long GetCount()
    {
      return this.dataLog.GetCount();
    }

    private static void add(RoadFlow.Data.Model.Log model)
    {
      Log.dataLog1.Add(model);
    }

    public static void Add(RoadFlow.Data.Model.Log model)
    {
      new Log.dgWriteLog(Log.add).BeginInvoke(model, (AsyncCallback) null, (object) null);
    }

    public static void Add(string title, string contents, Log.Types type = Log.Types.其它分类, string oldXML = "", string newXML = "", RoadFlow.Data.Model.Users user = null)
    {
      RoadFlow.Data.Model.Log model = new RoadFlow.Data.Model.Log();
      model.Contents = contents;
      model.ID = Guid.NewGuid();
      model.Title = title;
      model.OldXml = oldXML.IsNullOrEmpty() ? (string) null : oldXML;
      model.NewXml = newXML.IsNullOrEmpty() ? (string) null : newXML;
      model.Type = type.ToString();
      try
      {
        if (user == null)
          user = Users.CurrentUser;
        if (user != null)
        {
          model.UserID = new Guid?(user.ID);
          model.UserName = user.Name;
        }
        model.IPAddress = Tools.GetIPAddress();
        model.Others = string.Format("操作系统：{0} 浏览器：{1}", (object) Tools.GetOSName(), (object) Tools.GetBrowse());
        model.URL = HttpContext.Current.Request.Url.ToString();
      }
      catch
      {
      }
      model.WriteTime = DateTimeNew.Now;
      Log.Add(model);
    }

    public static void Add(Exception err)
    {
      Log.Add(err.Message, err.Source + err.StackTrace, Log.Types.系统错误, "", "", (RoadFlow.Data.Model.Users) null);
    }

    public string GetTypeOptions(string value = "")
    {
      StringBuilder stringBuilder = new StringBuilder();
      foreach (object obj in Enum.GetValues(typeof (Log.Types)))
        stringBuilder.AppendFormat("<option value=\"{0}\" {1}>{0}</option>", obj, obj.ToString() == value ? (object) "selected=\"selected\"" : (object) "");
      return stringBuilder.ToString();
    }

    public DataTable GetPagerData(out string pager, string query = "", string title = "", string type = "", string date1 = "", string date2 = "", string userID = "")
    {
      return this.dataLog.GetPagerData(out pager, query, Tools.GetPageSize(), Tools.GetPageNumber(), title, type, date1, date2, Users.RemovePrefix(userID));
    }

    public DataTable GetPagerData(out long count, int size = 15, int number = 1, string title = "", string type = "", string date1 = "", string date2 = "", string userID = "", string order = "")
    {
      return this.dataLog.GetPagerData(out count, size, number, title, type, date1, date2, Users.RemovePrefix(userID), order);
    }

    private delegate void dgWriteLog(RoadFlow.Data.Model.Log log);

    public enum Types
    {
      组织机构,
      用户登录,
      菜单权限,
      数据字典,
      流程相关,
      系统错误,
      信息管理,
      系统管理,
      文档中心,
      数据连接,
      微信企业号,
      任务调度,
      其它分类,
    }
  }
}
