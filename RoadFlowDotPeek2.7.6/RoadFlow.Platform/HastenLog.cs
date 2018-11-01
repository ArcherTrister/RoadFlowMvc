// Decompiled with JetBrains decompiler
// Type: RoadFlow.Platform.HastenLog
// Assembly: RoadFlow.Platform, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 07F26AFD-DE3B-4003-89AF-01A62494BA58
// Assembly location: C:\inetpub\wwwroot\RoadFlowMvc\bin\RoadFlow.Platform.dll

using RoadFlow.Data.Interface;
using RoadFlow.Platform.WeiXin;
using RoadFlow.Utility;
using System;
using System.Collections.Generic;
using System.Web;
using System.Web.UI.WebControls;

namespace RoadFlow.Platform
{
  public class HastenLog
  {
    private IHastenLog dataHastenLog;

    public HastenLog()
    {
      this.dataHastenLog = RoadFlow.Data.Factory.Factory.GetHastenLog();
    }

    public int Add(RoadFlow.Data.Model.HastenLog model)
    {
      return this.dataHastenLog.Add(model);
    }

    public int Update(RoadFlow.Data.Model.HastenLog model)
    {
      return this.dataHastenLog.Update(model);
    }

    public List<RoadFlow.Data.Model.HastenLog> GetAll()
    {
      return this.dataHastenLog.GetAll();
    }

    public RoadFlow.Data.Model.HastenLog Get(Guid id)
    {
      return this.dataHastenLog.Get(id);
    }

    public int Delete(Guid id)
    {
      return this.dataHastenLog.Delete(id);
    }

    public long GetCount()
    {
      return this.dataHastenLog.GetCount();
    }

    public static string GetHastenTypeCheckboxString(string name, string value)
    {
      List<ListItem> listItemList = new List<ListItem>();
      System.Collections.Generic.Dictionary<int, string> dictionary = new System.Collections.Generic.Dictionary<int, string>();
      dictionary.Add(1, "手机短信");
      dictionary.Add(2, "邮件");
      dictionary.Add(3, "站内消息");
      if (RoadFlow.Platform.WeiXin.Config.IsUse)
        dictionary.Add(4, "微信");
      foreach (KeyValuePair<int, string> keyValuePair in dictionary)
        listItemList.Add(new ListItem(keyValuePair.Value, keyValuePair.Key.ToString())
        {
          Selected = true
        });
      return Tools.GetCheckBoxString(listItemList.ToArray(), name, (value ?? "").Split(','), "validate='checkbox'");
    }

    public static void Hasten(string types, string users, string contents, RoadFlow.Data.Model.WorkFlowTask task, string othersParams = "")
    {
      if (users.IsNullOrEmpty() || types.IsNullOrEmpty() || task == null)
        return;
      string[] strArray = users.Split(',');
      Guid guid = Guid.NewGuid();
      List<RoadFlow.Data.Model.WorkFlowTask> all = new WorkFlowTask().GetNextTaskList(task.ID).FindAll((Predicate<RoadFlow.Data.Model.WorkFlowTask>) (p => p.Status.In(0, 1)));
      string str1 = !(HttpContext.Current.Request.Url != (Uri) null) || !HttpContext.Current.Request.Url.AbsolutePath.EndsWith(".aspx", StringComparison.CurrentCultureIgnoreCase) ? "/WorkFlowRun/Index" : "/Platform/WorkFlowRun/Default.aspx";
      string str2 = types;
      char[] chArray = new char[1]{ ',' };
      foreach (string str3 in str2.Split(chArray))
      {
        int test;
        if (str3.IsInt(out test))
        {
          foreach (string id in strArray)
          {
            Guid userGuid;
            if (Users.RemovePrefix(id).IsGuid(out userGuid))
            {
              RoadFlow.Data.Model.WorkFlowTask workFlowTask = all.Find((Predicate<RoadFlow.Data.Model.WorkFlowTask>) (p => p.ReceiveID == userGuid));
              string str4;
              if (workFlowTask != null)
                str4 = "javascript:openApp('" + str1 + "?flowid=" + (object) workFlowTask.FlowID + "&stepid=" + (object) workFlowTask.StepID + "&instanceid=" + workFlowTask.InstanceID + "&taskid=" + (object) workFlowTask.ID + "&groupid=" + (object) workFlowTask.GroupID + "',0,'" + workFlowTask.Title.Replace1(",", "") + "','tab_" + (object) workFlowTask.ID + "');closeMessage('" + (object) guid + "');";
              else
                str4 = "";
              string linkUrl = str4;
              switch (test)
              {
                case 1:
                  SMSLog.SendSMS(new Users().GetMobileNumber(userGuid), contents);
                  continue;
                case 2:
                  Email.Send(userGuid, "任务催办", contents, "");
                  continue;
                case 3:
                  RoadFlow.Data.Model.Users users1 = new Users().Get(userGuid);
                  if (users1 != null)
                  {
                    ShortMessage.Send(users1.ID, users1.Name, "任务催办", contents, 0, linkUrl, task.ID.ToString(), guid.ToString());
                    continue;
                  }
                  continue;
                case 4:
                  RoadFlow.Data.Model.Users users2 = new Users().Get(userGuid);
                  if (users2 != null)
                  {
                    new Message().SendText(contents, users2.Account, "", "", 0, new Agents().GetAgentIDByCode("weixinagents_waittasks"), true);
                    continue;
                  }
                  continue;
                default:
                  continue;
              }
            }
          }
        }
      }
      new HastenLog().Add(new RoadFlow.Data.Model.HastenLog()
      {
        Contents = contents,
        ID = Guid.NewGuid(),
        SendTime = DateTimeNew.Now,
        SendUser = Users.CurrentUserID,
        SendUserName = Users.CurrentUserName,
        OthersParams = othersParams.IsNullOrEmpty() ? task.ID.ToString() : othersParams,
        Types = types,
        Users = users
      });
    }
  }
}
