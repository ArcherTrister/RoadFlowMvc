// Decompiled with JetBrains decompiler
// Type: RoadFlow.Platform.WorkFlowTask
// Assembly: RoadFlow.Platform, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 07F26AFD-DE3B-4003-89AF-01A62494BA58
// Assembly location: C:\inetpub\wwwroot\RoadFlowMvc\bin\RoadFlow.Platform.dll

using LitJson;
using RoadFlow.Data.Interface;
using RoadFlow.Data.Model;
using RoadFlow.Data.Model.WorkFlowExecute;
using RoadFlow.Data.Model.WorkFlowInstalledSub;
using RoadFlow.Data.Model.WorkFlowInstalledSub.StepSet;
using RoadFlow.Platform.WeiXin;
using RoadFlow.Utility;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Data;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Transactions;
using System.Web;
using System.Web.UI.WebControls;

namespace RoadFlow.Platform
{
  public class WorkFlowTask : IEqualityComparer<RoadFlow.Data.Model.WorkFlowTask>
  {
    private static readonly object lockobj = new object();
    private WorkFlow bWorkFlow = new WorkFlow();
    private List<RoadFlow.Data.Model.WorkFlowTask> nextTasks = new List<RoadFlow.Data.Model.WorkFlowTask>();
    private IWorkFlowTask dataWorkFlowTask;
    private WorkFlowInstalled wfInstalled;
    private Result result;

    public WorkFlowTask()
    {
      this.dataWorkFlowTask = RoadFlow.Data.Factory.Factory.GetWorkFlowTask();
    }

    public int Add(RoadFlow.Data.Model.WorkFlowTask model)
    {
      return this.dataWorkFlowTask.Add(model);
    }

    public int Update(RoadFlow.Data.Model.WorkFlowTask model)
    {
      return this.dataWorkFlowTask.Update(model);
    }

    public List<RoadFlow.Data.Model.WorkFlowTask> GetAll()
    {
      return this.dataWorkFlowTask.GetAll();
    }

    public RoadFlow.Data.Model.WorkFlowTask Get(Guid id)
    {
      return this.dataWorkFlowTask.Get(id);
    }

    public int Delete(Guid id)
    {
      return this.dataWorkFlowTask.Delete(id);
    }

    public long GetCount()
    {
      return this.dataWorkFlowTask.GetCount();
    }

    public bool Equals(RoadFlow.Data.Model.WorkFlowTask task1, RoadFlow.Data.Model.WorkFlowTask task2)
    {
      if (task1.ReceiveID == task2.ReceiveID && task1.StepID == task2.StepID)
        return task1.Sort == task2.Sort;
      return false;
    }

    public int GetHashCode(RoadFlow.Data.Model.WorkFlowTask task)
    {
      return task.ToString().GetHashCode();
    }

    public void UpdateOpenTime(Guid id, DateTime openTime, bool isStatus = false)
    {
      this.dataWorkFlowTask.UpdateOpenTime(id, openTime, isStatus);
    }

    public Guid GetFirstSnderID(Guid flowID, Guid groupID, bool isDefault = false)
    {
      Guid firstSnderId = this.dataWorkFlowTask.GetFirstSnderID(flowID, groupID);
      if (!(firstSnderId.IsEmptyGuid() & isDefault))
        return firstSnderId;
      return Users.CurrentUserID;
    }

    public Guid GetFirstSnderDeptID(Guid flowID, Guid groupID)
    {
      if (flowID.IsEmptyGuid() || groupID.IsEmptyGuid())
        return Users.CurrentDeptID;
      RoadFlow.Data.Model.Organize deptByUserId = new Users().GetDeptByUserID(this.dataWorkFlowTask.GetFirstSnderID(flowID, groupID));
      if (deptByUserId != null)
        return deptByUserId.ID;
      return Guid.Empty;
    }

    public List<Guid> GetStepSnderID(Guid flowID, Guid stepID, Guid groupID)
    {
      return this.dataWorkFlowTask.GetStepSnderID(flowID, stepID, groupID);
    }

    public string GetStepSnderIDString(Guid flowID, Guid stepID, Guid groupID)
    {
      List<Guid> stepSnderId = this.GetStepSnderID(flowID, stepID, groupID);
      StringBuilder stringBuilder = new StringBuilder(stepSnderId.Count * 43);
      foreach (Guid guid in stepSnderId)
      {
        stringBuilder.Append("u_");
        stringBuilder.Append((object) guid);
        stringBuilder.Append(",");
      }
      return stringBuilder.ToString().TrimEnd(',');
    }

    public List<Guid> GetPrevSnderID(Guid flowID, Guid stepID, Guid groupID)
    {
      return this.dataWorkFlowTask.GetPrevSnderID(flowID, stepID, groupID);
    }

    public string GetPrevSnderIDString(Guid flowID, Guid stepID, Guid groupID)
    {
      List<Guid> prevSnderId = this.dataWorkFlowTask.GetPrevSnderID(flowID, stepID, groupID);
      StringBuilder stringBuilder = new StringBuilder(prevSnderId.Count * 43);
      foreach (Guid guid in prevSnderId)
      {
        stringBuilder.Append("u_");
        stringBuilder.Append((object) guid);
        stringBuilder.Append(",");
      }
      return stringBuilder.ToString().TrimEnd(',');
    }

    private Execute GetExecuteModel(string jsonString)
    {
      Execute execute = new Execute();
      Organize organize = new Organize();
      JsonData jsonData1 = JsonMapper.ToObject(jsonString);
      if (jsonData1 == null)
        return execute;
      execute.Comment = jsonData1["comment"].ToString();
      string lower = jsonData1["type"].ToString().ToLower();
      if (!(lower == "submit"))
      {
        if (!(lower == "save"))
        {
          if (lower == "back")
            execute.ExecuteType = EnumType.ExecuteType.Back;
        }
        else
          execute.ExecuteType = EnumType.ExecuteType.Save;
      }
      else
        execute.ExecuteType = EnumType.ExecuteType.Submit;
      execute.FlowID = jsonData1["flowid"].ToString().ToGuid();
      execute.GroupID = jsonData1["groupid"].ToString().ToGuid();
      execute.InstanceID = jsonData1["instanceid"].ToString();
      execute.IsSign = jsonData1["issign"].ToString().ToInt() == 1;
      execute.StepID = jsonData1["stepid"].ToString().ToGuid();
      execute.TaskID = jsonData1["taskid"].ToString().ToGuid();
      JsonData jsonData2 = jsonData1["steps"];
      System.Collections.Generic.Dictionary<Guid, List<RoadFlow.Data.Model.Users>> dictionary = new System.Collections.Generic.Dictionary<Guid, List<RoadFlow.Data.Model.Users>>();
      if (jsonData2.IsArray)
      {
        foreach (JsonData jsonData3 in (IEnumerable) jsonData2)
        {
          Guid guid = jsonData3["id"].ToString().ToGuid();
          string str = jsonData3["member"].ToString();
          if (!(guid == Guid.Empty) && !str.IsNullOrEmpty())
            dictionary.Add(guid, organize.GetAllUsers(str));
        }
      }
      execute.Steps = dictionary;
      return execute;
    }

    public Result Execute(string jsonString)
    {
      return this.Execute(this.GetExecuteModel(jsonString));
    }

    public bool StartFlow(Guid flowID, List<RoadFlow.Data.Model.Users> users, string title, string instanceID = "")
    {
      if (users.Count == 0)
        return false;
      try
      {
        foreach (RoadFlow.Data.Model.Users user in users)
          this.createFirstTask(new Execute()
          {
            ExecuteType = EnumType.ExecuteType.Save,
            FlowID = flowID,
            InstanceID = instanceID,
            Title = title,
            Sender = user
          }, false);
        return true;
      }
      catch (Exception ex)
      {
        Log.Add(ex);
        return false;
      }
    }

    public Result Execute(Execute executeModel)
    {
      this.result = new Result();
      this.nextTasks = new List<RoadFlow.Data.Model.WorkFlowTask>();
      if (executeModel.FlowID == Guid.Empty)
      {
        this.result.DebugMessages = "流程ID错误";
        this.result.IsSuccess = false;
        this.result.Messages = "执行参数错误";
        return this.result;
      }
      this.wfInstalled = this.bWorkFlow.GetWorkFlowRunModel(executeModel.FlowID, true);
      if (this.wfInstalled == null)
      {
        this.result.DebugMessages = "未找到流程运行时实体";
        this.result.IsSuccess = false;
        this.result.Messages = "流程运行时为空";
        return this.result;
      }
      lock (WorkFlowTask.lockobj)
      {
        switch (executeModel.ExecuteType)
        {
          case EnumType.ExecuteType.Submit:
          case EnumType.ExecuteType.Completed:
            this.executeSubmit(executeModel);
            break;
          case EnumType.ExecuteType.Save:
            this.executeSave(executeModel);
            break;
          case EnumType.ExecuteType.Back:
            this.executeBack(executeModel);
            break;
          case EnumType.ExecuteType.Redirect:
            this.executeRedirect(executeModel);
            break;
          case EnumType.ExecuteType.AddWrite:
            this.executeAddWrite(executeModel);
            break;
          case EnumType.ExecuteType.CopyforCompleted:
            this.executeCopyforComplete(executeModel);
            break;
          default:
            this.result.DebugMessages = "流程处理类型为空";
            this.result.IsSuccess = false;
            this.result.Messages = "流程处理类型为空";
            return this.result;
        }
        this.result.NextTasks = (IEnumerable<RoadFlow.Data.Model.WorkFlowTask>) this.nextTasks;
        if (executeModel.ExecuteType != EnumType.ExecuteType.Save && executeModel.ExecuteType != EnumType.ExecuteType.CopyforCompleted)
        {
          ShortMessage shortMessage = new ShortMessage();
          Users users = new Users();
          Agents agents = new Agents();
          string linkID = executeModel.TaskID.ToString();
          int type = 1;
          shortMessage.Delete(linkID, type);
          foreach (RoadFlow.Data.Model.WorkFlowTask workFlowTask in this.result.NextTasks.Where<RoadFlow.Data.Model.WorkFlowTask>((Func<RoadFlow.Data.Model.WorkFlowTask, bool>) (p => p.Status == 0)))
          {
            if (!workFlowTask.ReceiveID.IsEmptyGuid() && !(workFlowTask.ReceiveID == workFlowTask.SenderID))
            {
              string str = !(HttpContext.Current.Request.Url != (Uri) null) || !HttpContext.Current.Request.Url.AbsolutePath.EndsWith(".aspx", StringComparison.CurrentCultureIgnoreCase) ? "/WorkFlowRun/Index" : "/Platform/WorkFlowRun/Default.aspx";
              Guid guid = Guid.NewGuid();
              string contents = "您有一个新的待办任务，流程:" + this.wfInstalled.Name + "，步骤：" + workFlowTask.StepName + "。";
              string linkUrl = "javascript:openApp('" + str + "?flowid=" + (object) workFlowTask.FlowID + "&stepid=" + (object) workFlowTask.StepID + "&instanceid=" + workFlowTask.InstanceID + "&taskid=" + (object) workFlowTask.ID + "&groupid=" + (object) workFlowTask.GroupID + "',0,'" + workFlowTask.Title.RemoveHTML().RemovePunctuationOrEmpty() + "','tab_" + (object) workFlowTask.ID + "');closeMessage('" + (object) guid + "');";
              ShortMessage.Send(workFlowTask.ReceiveID, workFlowTask.ReceiveName, "流程待办提醒", contents, 1, linkUrl, workFlowTask.ID.ToString(), guid.ToString());
              if (RoadFlow.Platform.WeiXin.Config.IsUse)
                new Message().SendText(contents, users.GetAccountByID(workFlowTask.ReceiveID), "", "", 0, agents.GetAgentIDByCode("weixinagents_waittasks"), true);
            }
          }
        }
        return this.result;
      }
    }

    private void executeSubmit(Execute executeModel)
    {
      using (TransactionScope transactionScope = new TransactionScope())
      {
        RoadFlow.Data.Model.WorkFlowTask currentTask = (RoadFlow.Data.Model.WorkFlowTask) null;
        if ((!(executeModel.StepID == this.wfInstalled.FirstStepID) || !(executeModel.TaskID == Guid.Empty) ? 0 : (executeModel.GroupID == Guid.Empty ? 1 : 0)) != 0)
        {
          currentTask = this.createFirstTask(executeModel, false);
          executeModel.TaskID = currentTask.ID;
        }
        else
        {
          currentTask = this.Get(executeModel.TaskID);
          if (currentTask == null)
            throw new Exception("未找到要提交的任务");
          if (currentTask.InstanceID.IsNullOrEmpty() && !executeModel.InstanceID.IsNullOrEmpty())
          {
            currentTask.InstanceID = executeModel.InstanceID;
            this.Update(currentTask);
          }
        }
        if (currentTask == null)
        {
          this.result.DebugMessages = "未能创建或找到当前任务";
          this.result.IsSuccess = false;
          this.result.Messages = "未能创建或找到当前任务";
        }
        else if (currentTask.Status.In(2, 3, 4, 5, 6, 7))
        {
          this.result.DebugMessages = "当前任务已处理";
          this.result.IsSuccess = false;
          this.result.Messages = "当前任务已处理";
        }
        else if (currentTask.ReceiveID != Users.CurrentUserID && currentTask.ReceiveID != RoadFlow.Platform.WeiXin.Organize.CurrentUserID && currentTask.IsExpiredAutoSubmit == 0)
        {
          this.result.DebugMessages = "不能处理当前任务";
          this.result.IsSuccess = false;
          this.result.Messages = "不能处理当前任务";
        }
        else
        {
          IEnumerable<Step> source1 = this.wfInstalled.Steps.Where<Step>((Func<Step, bool>) (p => p.ID == executeModel.StepID));
          Step step1 = source1.Count<Step>() > 0 ? source1.First<Step>() : (Step) null;
          if (step1 == null)
          {
            this.result.DebugMessages = "未找到当前步骤";
            this.result.IsSuccess = false;
            this.result.Messages = "未找到当前步骤";
          }
          else
          {
            if (step1.Type == "subflow" && step1.SubFlowID.IsGuid() && (step1.Behavior.SubFlowStrategy == 0 && !currentTask.SubFlowGroupID.IsNullOrEmpty()))
            {
              string subFlowGroupId = currentTask.SubFlowGroupID;
              char[] chArray = new char[1]{ ',' };
              foreach (string str in subFlowGroupId.Split(chArray))
              {
                if (!this.GetInstanceIsCompleted(step1.SubFlowID.ToGuid(), str.ToGuid()))
                {
                  this.result.DebugMessages = "当前步骤的子流程实例未完成,子流程：" + step1.SubFlowID + ",实例组：" + currentTask.SubFlowGroupID.ToString();
                  this.result.IsSuccess = false;
                  this.result.Messages = "当前步骤的子流程未完成,不能提交!";
                  return;
                }
              }
            }
            int num1 = 0;
            bool flag1 = executeModel.ExecuteType == EnumType.ExecuteType.Completed || executeModel.Steps == null || executeModel.Steps.Count == 0;
            List<RoadFlow.Data.Model.WorkFlowTask> taskList = this.GetTaskList(currentTask.FlowID, currentTask.StepID, currentTask.GroupID);
            if (currentTask.StepID != this.wfInstalled.FirstStepID)
            {
              switch (step1.Behavior.HanlderModel)
              {
                case 0:
                  List<RoadFlow.Data.Model.WorkFlowTask> all1 = taskList.FindAll((Predicate<RoadFlow.Data.Model.WorkFlowTask>) (p =>
                  {
                    if (p.Sort == currentTask.Sort && p.Type != 5)
                      return p.Type != 7;
                    return false;
                  }));
                  if (all1.Count > 1 && all1.Where<RoadFlow.Data.Model.WorkFlowTask>((Func<RoadFlow.Data.Model.WorkFlowTask, bool>) (p => p.Status != 2)).Count<RoadFlow.Data.Model.WorkFlowTask>() - 1 > 0)
                    num1 = -1;
                  if (!flag1)
                  {
                    this.Completed(currentTask.ID, executeModel.Comment, executeModel.IsSign, 2, "", executeModel.Files);
                    break;
                  }
                  break;
                case 1:
                  using (List<RoadFlow.Data.Model.WorkFlowTask>.Enumerator enumerator = taskList.FindAll((Predicate<RoadFlow.Data.Model.WorkFlowTask>) (p =>
                  {
                    if (p.Sort == currentTask.Sort && p.Type != 5)
                      return p.Type != 7;
                    return false;
                  })).GetEnumerator())
                  {
                    while (enumerator.MoveNext())
                    {
                      RoadFlow.Data.Model.WorkFlowTask current = enumerator.Current;
                      if (current.ID != currentTask.ID)
                      {
                        if (current.Status.In(0, 1))
                          this.Completed(current.ID, "", false, 4, "", "");
                      }
                      else if (!flag1)
                        this.Completed(current.ID, executeModel.Comment, executeModel.IsSign, 2, "", executeModel.Files);
                    }
                    break;
                  }
                case 2:
                  List<RoadFlow.Data.Model.WorkFlowTask> all2 = taskList.FindAll((Predicate<RoadFlow.Data.Model.WorkFlowTask>) (p =>
                  {
                    if (p.Sort == currentTask.Sort && p.Type != 5)
                      return p.Type != 7;
                    return false;
                  }));
                  if (all2.Count > 1)
                  {
                    Decimal num2 = step1.Behavior.Percentage <= Decimal.Zero ? new Decimal(100) : step1.Behavior.Percentage;
                    if (global::MyExtensions.Round((Decimal) (all2.Where((Func<Data.Model.WorkFlowTask, bool>) (p => p.Status == 2)).Count() + 1) / (Decimal) all2.Count * new Decimal(100), 2) < num2)
                    {
                      num1 = -1;
                    }
                    else
                    {
                      foreach (RoadFlow.Data.Model.WorkFlowTask workFlowTask in all2)
                      {
                        if (workFlowTask.ID != currentTask.ID)
                        {
                          if (workFlowTask.Status.In(0, 1))
                            this.Completed(workFlowTask.ID, "", false, 4, "", "");
                        }
                      }
                    }
                  }
                  if (!flag1)
                  {
                    this.Completed(currentTask.ID, executeModel.Comment, executeModel.IsSign, 2, "", executeModel.Files);
                    break;
                  }
                  break;
                case 3:
                  if (!flag1)
                  {
                    this.Completed(currentTask.ID, executeModel.Comment, executeModel.IsSign, 2, "", executeModel.Files);
                    break;
                  }
                  break;
                case 4:
                  List<RoadFlow.Data.Model.WorkFlowTask> all3 = taskList.FindAll((Predicate<RoadFlow.Data.Model.WorkFlowTask>) (p =>
                  {
                    if (p.Sort == currentTask.Sort && p.Type != 5 && p.Type != 7)
                      return p.StepSort == currentTask.StepSort + 1;
                    return false;
                  }));
                  if (all3.Count > 0)
                  {
                    num1 = -3;
                    foreach (RoadFlow.Data.Model.WorkFlowTask model in all3)
                    {
                      model.Status = 0;
                      this.Update(model);
                    }
                  }
                  if (!flag1)
                  {
                    this.Completed(currentTask.ID, executeModel.Comment, executeModel.IsSign, 2, "", executeModel.Files);
                    break;
                  }
                  break;
              }
            }
            else if (!flag1)
              this.Completed(currentTask.ID, executeModel.Comment, executeModel.IsSign, 2, "", executeModel.Files);
            if (flag1)
            {
              this.executeComplete(executeModel, true);
              RoadFlow.Data.Model.WorkFlowTask workFlowTask1 = this.GetTaskList(Guid.Empty, currentTask.GroupID).Find((Predicate<RoadFlow.Data.Model.WorkFlowTask>) (p =>
              {
                int? otherType = p.OtherType;
                int num = 4;
                if (otherType.GetValueOrDefault() != num)
                  return false;
                return otherType.HasValue;
              }));
              if (workFlowTask1 != null)
              {
                List<RoadFlow.Data.Model.WorkFlowTask> bySubFlowGroupId = this.GetBySubFlowGroupID(workFlowTask1.GroupID);
                bool flag2 = true;
                foreach (RoadFlow.Data.Model.WorkFlowTask workFlowTask2 in bySubFlowGroupId)
                {
                  if (flag2)
                  {
                    string subFlowGroupId = workFlowTask2.SubFlowGroupID;
                    char[] chArray = new char[1]{ ',' };
                    foreach (string str in subFlowGroupId.Split(chArray))
                    {
                      if (!this.GetInstanceIsCompleted(workFlowTask1.FlowID, str.ToGuid()))
                      {
                        flag2 = false;
                        break;
                      }
                    }
                  }
                  else
                    break;
                }
                if (flag2)
                {
                  foreach (RoadFlow.Data.Model.WorkFlowTask task in bySubFlowGroupId)
                  {
                    Result result = this.AutoSubmit(task, false);
                    Log.Add("子流程完成后提交主流程步骤-" + task.Title, "是否成功：" + result.IsSuccess.ToString() + " 信息：" + result.DebugMessages, Log.Types.流程相关, "", "", (RoadFlow.Data.Model.Users) null);
                  }
                }
              }
              transactionScope.Complete();
            }
            else
            {
              foreach (RoadFlow.Data.Model.WorkFlowTask workFlowTask in taskList.FindAll((Predicate<RoadFlow.Data.Model.WorkFlowTask>) (p =>
              {
                if (p.Sort == currentTask.Sort && p.Type != 5)
                  return p.Type != 7;
                return false;
              })))
              {
                RoadFlow.Data.Model.WorkFlowTask noAddTask = workFlowTask;
                List<RoadFlow.Data.Model.WorkFlowTask> all4 = taskList.FindAll((Predicate<RoadFlow.Data.Model.WorkFlowTask>) (p =>
                {
                  if (p.PrevID == noAddTask.ID)
                    return p.Type == 7;
                  return false;
                }));
                if (noAddTask.ID == currentTask.ID && all4.Count > 0)
                {
                  foreach (RoadFlow.Data.Model.WorkFlowTask model in all4)
                  {
                    int? otherType = model.OtherType;
                    if (otherType.HasValue)
                    {
                      otherType = model.OtherType;
                      int num2 = otherType.Value;
                      int num3 = num2.ToString().Left(1).ToString().ToInt();
                      otherType = model.OtherType;
                      num2 = otherType.Value;
                      int i = num2.ToString().Right(1).ToString().ToInt();
                      int num4 = 2;
                      if (num3 == num4)
                      {
                        if (i.In(1, 2) || i == 3 && model.ReceiveID == all4.FindAll((Predicate<RoadFlow.Data.Model.WorkFlowTask>) (p => p.Status.In(-1, 0, 1))).OrderBy<RoadFlow.Data.Model.WorkFlowTask, DateTime>((Func<RoadFlow.Data.Model.WorkFlowTask, DateTime>) (p => p.ReceiveTime)).FirstOrDefault<RoadFlow.Data.Model.WorkFlowTask>().ReceiveID)
                        {
                          model.Status = 0;
                          this.Update(model);
                        }
                      }
                    }
                  }
                }
                List<RoadFlow.Data.Model.WorkFlowTask> nextTasks = new List<RoadFlow.Data.Model.WorkFlowTask>();
                if (all4.Count > 0 && !this.isPassingAddWrite(all4.FirstOrDefault<RoadFlow.Data.Model.WorkFlowTask>(), out nextTasks))
                {
                  num1 = -2;
                  break;
                }
              }
              if (num1 == -1 || num1 == -2 || num1 == -3)
              {
                List<RoadFlow.Data.Model.WorkFlowTask> tempTasks = this.createTempTasks(executeModel, currentTask);
                List<string> source2 = new List<string>();
                foreach (RoadFlow.Data.Model.WorkFlowTask workFlowTask in tempTasks)
                  source2.Add(workFlowTask.StepName);
                this.nextTasks.AddRange((IEnumerable<RoadFlow.Data.Model.WorkFlowTask>) tempTasks);
                string str1 = source2.Distinct<string>().ToArray<string>().Join1<string>(",");
                Result result1 = this.result;
                string debugMessages = result1.DebugMessages;
                string format1 = "已发送到:{0},{1},不创建后续任务";
                string str2 = str1;
                string str3;
                switch (num1)
                {
                  case -3:
                    str3 = "顺序处理的下一人处理";
                    break;
                  case -2:
                    str3 = "加签人未处理";
                    break;
                  default:
                    str3 = "其他人未处理";
                    break;
                }
                string str4 = string.Format(format1, (object) str2, (object) str3);
                result1.DebugMessages = debugMessages + str4;
                this.result.IsSuccess = true;
                Result result2 = this.result;
                string messages = result2.Messages;
                string format2 = "已发送到:{0}{1}!";
                string str5 = str1;
                string str6;
                switch (num1)
                {
                  case -3:
                    str6 = "";
                    break;
                  case -2:
                    str6 = ",等待加签人处理";
                    break;
                  default:
                    str6 = ",等待他人处理";
                    break;
                }
                string str7 = string.Format(format2, (object) str5, (object) str6);
                result2.Messages = messages + str7;
                this.result.NextTasks = (IEnumerable<RoadFlow.Data.Model.WorkFlowTask>) this.nextTasks;
                transactionScope.Complete();
              }
              else
              {
                List<RoadFlow.Data.Model.WorkFlowTask> workFlowTaskList = new List<RoadFlow.Data.Model.WorkFlowTask>();
                foreach (KeyValuePair<Guid, List<RoadFlow.Data.Model.Users>> step2 in executeModel.Steps)
                {
                  KeyValuePair<Guid, List<RoadFlow.Data.Model.Users>> step = step2;
                  Guid guid = Guid.NewGuid();
                  StringBuilder stringBuilder = new StringBuilder();
                  List<RoadFlow.Data.Model.WorkFlowTask> source2 = new List<RoadFlow.Data.Model.WorkFlowTask>();
                  int num2 = 0;
                  foreach (RoadFlow.Data.Model.Users users in step.Value)
                  {
                    if (this.wfInstalled == null)
                      this.wfInstalled = this.bWorkFlow.GetWorkFlowRunModel(executeModel.FlowID, true);
                    IEnumerable<Step> source3 = this.wfInstalled.Steps.Where<Step>((Func<Step, bool>) (p => p.ID == step.Key));
                    if (source3.Count<Step>() != 0)
                    {
                      Step step3 = source3.First<Step>();
                      bool flag2 = step3.Behavior.Countersignature == 0;
                      if (step3.Behavior.Countersignature != 0)
                      {
                        List<Step> prevSteps = this.bWorkFlow.GetPrevSteps(executeModel.FlowID, step3.ID);
                        if (prevSteps.Count > 1)
                        {
                          Guid prevStepId = currentTask.PrevStepID;
                          switch (step3.Behavior.Countersignature)
                          {
                            case 1:
                              flag2 = true;
                              using (List<Step>.Enumerator enumerator = prevSteps.GetEnumerator())
                              {
                                while (enumerator.MoveNext())
                                {
                                  if (!this.IsPassing(enumerator.Current, executeModel.FlowID, executeModel.GroupID, currentTask, prevStepId))
                                  {
                                    flag2 = false;
                                    break;
                                  }
                                }
                                break;
                              }
                            case 2:
                              flag2 = false;
                              using (List<Step>.Enumerator enumerator = prevSteps.GetEnumerator())
                              {
                                while (enumerator.MoveNext())
                                {
                                  if (this.IsPassing(enumerator.Current, executeModel.FlowID, executeModel.GroupID, currentTask, prevStepId))
                                  {
                                    flag2 = true;
                                    break;
                                  }
                                }
                                break;
                              }
                            case 3:
                              int num3 = 0;
                              if (prevSteps.Count == 0)
                              {
                                flag2 = true;
                                break;
                              }
                              foreach (Step step4 in prevSteps)
                              {
                                if (this.IsPassing(step4, executeModel.FlowID, executeModel.GroupID, currentTask, prevStepId))
                                  ++num3;
                              }
                              flag2 = global::MyExtensions.Round((Decimal) num3 / (Decimal) prevSteps.Count * new Decimal(100), 2) >= (step3.Behavior.CountersignaturePercentage <= decimal.Zero ? new Decimal(100) : step3.Behavior.CountersignaturePercentage);
                              break;
                          }
                        }
                        else
                          flag2 = true;
                        if (flag2)
                        {
                          foreach (RoadFlow.Data.Model.WorkFlowTask task in this.GetTaskList(currentTask.ID, false))
                          {
                            if (!(task.ID == currentTask.ID) && task.Type != 5)
                            {
                              if (!task.Status.In(2, 3, 4, 5, 6, 7))
                                this.Completed(task.ID, "", false, 4, "", "");
                            }
                          }
                        }
                      }
                      if (flag2)
                      {
                        RoadFlow.Data.Model.WorkFlowTask workFlowTask = new RoadFlow.Data.Model.WorkFlowTask();
                        if (executeModel.StepCompletedTimes.Keys.Contains<Guid>(step3.ID))
                          workFlowTask.CompletedTime = new DateTime?(executeModel.StepCompletedTimes[step3.ID]);
                        else if (step3.WorkTime > Decimal.Zero)
                          workFlowTask.CompletedTime = new DateTime?(new WorkCalendar().GetWorkDate((double) step3.WorkTime, DateTimeNew.Now));
                        workFlowTask.IsExpiredAutoSubmit = step3.TimeOutModel;
                        workFlowTask.FlowID = executeModel.FlowID;
                        workFlowTask.GroupID = currentTask != null ? currentTask.GroupID : executeModel.GroupID;
                        workFlowTask.ID = Guid.NewGuid();
                        workFlowTask.Type = 0;
                        workFlowTask.InstanceID = executeModel.InstanceID;
                        if (!executeModel.Note.IsNullOrEmpty())
                          workFlowTask.Note = executeModel.Note;
                        workFlowTask.PrevID = currentTask.ID;
                        workFlowTask.PrevStepID = currentTask.StepID;
                        workFlowTask.ReceiveID = users.ID;
                        workFlowTask.ReceiveName = users.Name;
                        workFlowTask.ReceiveTime = DateTimeNew.Now;
                        workFlowTask.SenderID = executeModel.Sender.ID;
                        workFlowTask.SenderName = executeModel.Sender.Name;
                        workFlowTask.SenderTime = workFlowTask.ReceiveTime;
                        workFlowTask.StepID = step.Key;
                        workFlowTask.StepName = step3.Name;
                        workFlowTask.Sort = currentTask.Sort + 1;
                        workFlowTask.Title = executeModel.Title.IsNullOrEmpty() ? currentTask.Title : executeModel.Title;
                        workFlowTask.OtherType = new int?(executeModel.OtherType);
                        workFlowTask.Status = 4 == step3.Behavior.HanlderModel ? (num2 == 0 ? 0 : -1) : num1;
                        workFlowTask.StepSort = num2++;
                        if (step3.Type == "subflow" && step3.SubFlowID.IsGuid())
                        {
                          Execute executeModel1 = (Execute) null;
                          if (!step3.Event.SubFlowActivationBefore.IsNullOrEmpty())
                          {
                            object obj = this.ExecuteFlowCustomEvent(step3.Event.SubFlowActivationBefore.Trim(), (object) new WorkFlowCustomEventParams() { FlowID = executeModel.FlowID, GroupID = currentTask.GroupID, InstanceID = currentTask.InstanceID, StepID = executeModel.StepID, TaskID = currentTask.ID }, "");
                            if (obj is Execute)
                              executeModel1 = (Execute) obj;
                          }
                          if (executeModel1 == null)
                            executeModel1 = new Execute();
                          executeModel1.ExecuteType = EnumType.ExecuteType.Save;
                          executeModel1.FlowID = step3.SubFlowID.ToGuid();
                          executeModel1.Sender = users;
                          if (executeModel1.Title.IsNullOrEmpty())
                            executeModel1.Title = this.bWorkFlow.GetFlowName(executeModel1.FlowID);
                          if (executeModel1.InstanceID.IsNullOrEmpty())
                            executeModel1.InstanceID = "";
                          if (step3.SubFlowTaskType == 0)
                          {
                            executeModel1.GroupID = guid;
                          }
                          else
                          {
                            executeModel1.GroupID = Guid.NewGuid();
                            stringBuilder.Append(executeModel1.GroupID.ToString());
                            stringBuilder.Append(",");
                          }
                          executeModel1.OtherType = 4;
                          this.createFirstTask(executeModel1, true);
                          workFlowTask.ReceiveID = currentTask.ReceiveID;
                          workFlowTask.ReceiveName = currentTask.ReceiveName;
                          workFlowTask.SubFlowGroupID = Guid.Empty.ToString();
                          workFlowTask.OtherType = new int?(step3.Behavior.SubFlowStrategy == 0 ? 2 : 3);
                          workFlowTask.Type = 6;
                        }
                        this.nextTasks.Add(workFlowTask);
                        source2.Add(workFlowTask);
                      }
                    }
                  }
                  foreach (RoadFlow.Data.Model.WorkFlowTask model in source2.Distinct<RoadFlow.Data.Model.WorkFlowTask>())
                  {
                    if (step1.Behavior.HanlderModel == 3 || !this.HasNoCompletedTasks(executeModel.FlowID, step.Key, currentTask.GroupID, model.ReceiveID))
                    {
                      if (model.Type == 6)
                      {
                        if (stringBuilder.Length == 0)
                          model.SubFlowGroupID = guid.ToString();
                        else
                          model.SubFlowGroupID = stringBuilder.ToString().TrimEnd(',');
                        this.Add(model);
                        int? otherType = model.OtherType;
                        int num3 = 3;
                        if ((otherType.GetValueOrDefault() == num3 ? (otherType.HasValue ? 1 : 0) : 0) != 0)
                          workFlowTaskList.Add(model);
                      }
                      else
                        this.Add(model);
                    }
                  }
                }
                if (this.nextTasks.Count > 0)
                {
                  IEnumerable<IGrouping<Guid, RoadFlow.Data.Model.WorkFlowTask>> groupings = this.nextTasks.GroupBy<RoadFlow.Data.Model.WorkFlowTask, Guid>((Func<RoadFlow.Data.Model.WorkFlowTask, Guid>) (p => p.StepID));
                  if (this.wfInstalled == null)
                    this.wfInstalled = this.bWorkFlow.GetWorkFlowRunModel(executeModel.FlowID, true);
                  foreach (IGrouping<Guid, RoadFlow.Data.Model.WorkFlowTask> grouping in groupings)
                  {
                    IGrouping<Guid, RoadFlow.Data.Model.WorkFlowTask> nextStep = grouping;
                    IEnumerable<Step> source2 = this.wfInstalled.Steps.Where<Step>((Func<Step, bool>) (p => p.ID == nextStep.Key));
                    if (source2.Count<Step>() != 0 && source2.First<Step>().Behavior.HanlderModel != 4)
                      this.dataWorkFlowTask.UpdateTempTasks(this.nextTasks.FirstOrDefault<RoadFlow.Data.Model.WorkFlowTask>().FlowID, nextStep.Key, this.nextTasks.FirstOrDefault<RoadFlow.Data.Model.WorkFlowTask>().GroupID, this.nextTasks.FirstOrDefault<RoadFlow.Data.Model.WorkFlowTask>().CompletedTime, this.nextTasks.FirstOrDefault<RoadFlow.Data.Model.WorkFlowTask>().ReceiveTime);
                  }
                  if (executeModel.OtherType != 1 && step1.Behavior.HanlderModel != 3 && step1.Behavior.HanlderModel != 4)
                  {
                    foreach (RoadFlow.Data.Model.WorkFlowTask task in this.GetTaskList(currentTask.FlowID, currentTask.StepID, currentTask.GroupID))
                    {
                      if (task.Status.In(-1, 0, 1) && task.Type != 5)
                      {
                        int? otherType = task.OtherType;
                        int num2 = 1;
                        if ((otherType.GetValueOrDefault() == num2 ? (!otherType.HasValue ? 1 : 0) : 1) != 0)
                          this.Completed(task.ID, "", false, 4, "", "");
                      }
                    }
                  }
                  if (this.wfInstalled == null)
                    this.wfInstalled = this.bWorkFlow.GetWorkFlowRunModel(executeModel.FlowID, true);
                  foreach (KeyValuePair<Guid, List<RoadFlow.Data.Model.Users>> step2 in executeModel.Steps)
                  {
                    KeyValuePair<Guid, List<RoadFlow.Data.Model.Users>> step = step2;
                    IEnumerable<Step> source2 = this.wfInstalled.Steps.Where<Step>((Func<Step, bool>) (p => p.ID == step.Key));
                    if (source2.Count<Step>() > 0)
                    {
                      Step step3 = source2.First<Step>();
                      foreach (RoadFlow.Data.Model.Users copyForUser in this.GetCopyForUsers(step3.CopyFor, currentTask))
                      {
                        RoadFlow.Data.Model.Users user = copyForUser;
                        if (this.nextTasks.Find((Predicate<RoadFlow.Data.Model.WorkFlowTask>) (p => p.ReceiveID == user.ID)) == null)
                        {
                          RoadFlow.Data.Model.WorkFlowTask model = new RoadFlow.Data.Model.WorkFlowTask();
                          if (executeModel.StepCompletedTimes.Keys.Contains<Guid>(step3.ID))
                            model.CompletedTime = new DateTime?(executeModel.StepCompletedTimes[step3.ID]);
                          else if (step3.WorkTime > Decimal.Zero)
                            model.CompletedTime = new DateTime?(new WorkCalendar().GetWorkDate((double) step3.WorkTime, DateTimeNew.Now));
                          model.FlowID = executeModel.FlowID;
                          model.GroupID = currentTask != null ? currentTask.GroupID : executeModel.GroupID;
                          model.ID = Guid.NewGuid();
                          model.Type = 5;
                          model.InstanceID = executeModel.InstanceID;
                          model.Note = executeModel.Note.IsNullOrEmpty() ? "抄送" : executeModel.Note + "(抄送)";
                          model.PrevID = currentTask.ID;
                          model.PrevStepID = currentTask.StepID;
                          model.ReceiveID = user.ID;
                          model.ReceiveName = user.Name;
                          model.ReceiveTime = DateTimeNew.Now;
                          model.SenderID = executeModel.Sender.ID;
                          model.SenderName = executeModel.Sender.Name;
                          model.SenderTime = model.ReceiveTime;
                          model.Status = num1;
                          model.StepID = step.Key;
                          model.StepName = step3.Name;
                          model.Sort = currentTask.Sort + 1;
                          model.StepSort = 0;
                          model.Title = executeModel.Title.IsNullOrEmpty() ? currentTask.Title : executeModel.Title;
                          if (!this.HasNoCompletedTasks(executeModel.FlowID, step.Key, currentTask.GroupID, user.ID))
                            this.Add(model);
                        }
                      }
                    }
                  }
                  List<string> source3 = new List<string>();
                  foreach (RoadFlow.Data.Model.WorkFlowTask nextTask in this.nextTasks)
                    source3.Add(nextTask.StepName);
                  string str = source3.Distinct<string>().ToArray<string>().Join1<string>(",");
                  this.result.DebugMessages += string.Format("已发送到:{0}", (object) str);
                  this.result.IsSuccess = true;
                  this.result.Messages += string.Format("已发送到:{0}", (object) str);
                  this.result.NextTasks = (IEnumerable<RoadFlow.Data.Model.WorkFlowTask>) this.nextTasks;
                }
                else
                {
                  List<RoadFlow.Data.Model.WorkFlowTask> tempTasks = this.createTempTasks(executeModel, currentTask);
                  List<string> source2 = new List<string>();
                  foreach (RoadFlow.Data.Model.WorkFlowTask workFlowTask in tempTasks)
                    source2.Add(workFlowTask.StepName);
                  this.nextTasks.AddRange((IEnumerable<RoadFlow.Data.Model.WorkFlowTask>) tempTasks);
                  string str = source2.Distinct<string>().ToArray<string>().Join1<string>(",");
                  this.result.DebugMessages += string.Format("已发到:{0},等待其它步骤处理", (object) str);
                  this.result.IsSuccess = true;
                  this.result.Messages += string.Format("已发送:{0},等待其它步骤处理", (object) str);
                  this.result.NextTasks = (IEnumerable<RoadFlow.Data.Model.WorkFlowTask>) this.nextTasks;
                }
                if (workFlowTaskList.Count > 0)
                {
                  foreach (RoadFlow.Data.Model.WorkFlowTask task in workFlowTaskList)
                    this.AutoSubmit(task, false);
                }
                transactionScope.Complete();
              }
            }
          }
        }
      }
    }

    private void executeBack(Execute executeModel)
    {
      RoadFlow.Data.Model.WorkFlowTask currentTask = this.Get(executeModel.TaskID);
      if (currentTask == null)
      {
        this.result.DebugMessages = "未能找到当前任务";
        this.result.IsSuccess = false;
        this.result.Messages = "未能找到当前任务";
      }
      else if (currentTask.Status.In(2, 3, 4, 5, 6, 7))
      {
        this.result.DebugMessages = "当前任务已处理";
        this.result.IsSuccess = false;
        this.result.Messages = "当前任务已处理";
      }
      else if (currentTask.ReceiveID != Users.CurrentUserID && currentTask.ReceiveID != RoadFlow.Platform.WeiXin.Organize.CurrentUserID && currentTask.IsExpiredAutoSubmit == 0)
      {
        this.result.DebugMessages = "不能处理当前任务";
        this.result.IsSuccess = false;
        this.result.Messages = "不能处理当前任务";
      }
      else
      {
        IEnumerable<Step> source1 = this.wfInstalled.Steps.Where<Step>((Func<Step, bool>) (p => p.ID == currentTask.StepID));
        Step step1 = source1.Count<Step>() > 0 ? source1.First<Step>() : (Step) null;
        if (step1 == null)
        {
          this.result.DebugMessages = "未能找到当前步骤";
          this.result.IsSuccess = false;
          this.result.Messages = "未能找到当前步骤";
        }
        else if (currentTask.StepID == this.wfInstalled.FirstStepID)
        {
          this.result.DebugMessages = "当前任务是流程第一步,不能退回";
          this.result.IsSuccess = false;
          this.result.Messages = "当前任务是流程第一步,不能退回";
        }
        else
        {
          if (step1.Behavior.HanlderModel == 4)
          {
            List<RoadFlow.Data.Model.WorkFlowTask> taskList = this.GetTaskList(currentTask.ID, true);
            if (currentTask.StepSort == 0)
            {
              foreach (RoadFlow.Data.Model.WorkFlowTask workFlowTask in taskList)
              {
                if (workFlowTask.ID != currentTask.ID && workFlowTask.Status == -1)
                  this.Delete(workFlowTask.ID);
              }
            }
            RoadFlow.Data.Model.WorkFlowTask model = taskList.Find((Predicate<RoadFlow.Data.Model.WorkFlowTask>) (p => p.StepSort == currentTask.StepSort - 1));
            if (model != null)
            {
              using (TransactionScope transactionScope = new TransactionScope())
              {
                this.Completed(currentTask.ID, executeModel.Comment, executeModel.IsSign, 3, "", executeModel.Files);
                model.Status = 0;
                model.Type = 4;
                model.Comment = "";
                model.CompletedTime1 = new DateTime?();
                model.IsSign = new int?(0);
                model.Note = "";
                this.Update(model);
                transactionScope.Complete();
                this.nextTasks.Add(model);
                this.result.DebugMessages = "已退回到：" + model.StepName + "(" + model.ReceiveName + ")";
                this.result.IsSuccess = true;
                this.result.Messages = "已退回到：" + model.StepName + "(" + model.ReceiveName + ")";
                this.result.NextTasks = (IEnumerable<RoadFlow.Data.Model.WorkFlowTask>) this.nextTasks;
                return;
              }
            }
          }
          if (currentTask.Type == 7 && currentTask.OtherType.HasValue)
          {
            int num1 = currentTask.OtherType.Value;
            int num2 = num1.ToString().Left(1).ToInt();
            num1 = currentTask.OtherType.Value;
            int num3 = num1.ToString().Right(1).ToInt();
            List<RoadFlow.Data.Model.WorkFlowTask> all = this.GetTaskList(currentTask.FlowID, currentTask.StepID, currentTask.GroupID).FindAll((Predicate<RoadFlow.Data.Model.WorkFlowTask>) (p =>
            {
              if (p.PrevID == currentTask.PrevID)
                return p.Type == 7;
              return false;
            }));
            bool flag = false;
            using (TransactionScope transactionScope = new TransactionScope())
            {
              switch (num3)
              {
                case 1:
                case 3:
                  foreach (RoadFlow.Data.Model.WorkFlowTask model in all)
                  {
                    if (model.ID == currentTask.ID)
                      this.Completed(currentTask.ID, executeModel.Comment, executeModel.IsSign, 3, "", executeModel.Files);
                    else if (model.Status.In(-1, 0, 1))
                    {
                      model.Status = 5;
                      this.Update(model);
                    }
                  }
                  flag = true;
                  break;
                case 2:
                  this.Completed(currentTask.ID, executeModel.Comment, executeModel.IsSign, 3, "", executeModel.Files);
                  if (all.FindAll((Predicate<RoadFlow.Data.Model.WorkFlowTask>) (p =>
                  {
                    if (p.Status.In(-1, 0, 1))
                      return p.ID != currentTask.ID;
                    return false;
                  })).Count == 0)
                  {
                    flag = true;
                    break;
                  }
                  break;
              }
              if (flag)
              {
                RoadFlow.Data.Model.WorkFlowTask model = this.Get(currentTask.PrevID);
                if (model != null)
                {
                  if (num2 == 2)
                  {
                    foreach (RoadFlow.Data.Model.WorkFlowTask nextTask in this.GetNextTaskList(model.ID))
                    {
                      if (nextTask.Status == -1)
                        this.Delete(nextTask.ID);
                    }
                  }
                  model.Status = 0;
                  this.Update(model);
                  this.nextTasks.Add(model);
                  Result result = this.result;
                  result.DebugMessages = result.DebugMessages + "已退回到" + model.ReceiveName;
                  this.result.IsSuccess = true;
                  this.result.Messages += this.result.DebugMessages;
                  this.result.NextTasks = (IEnumerable<RoadFlow.Data.Model.WorkFlowTask>) this.nextTasks;
                }
                else
                {
                  this.result.DebugMessages += "未找到前一任务";
                  this.result.IsSuccess = false;
                  this.result.Messages += this.result.DebugMessages;
                  this.result.NextTasks = (IEnumerable<RoadFlow.Data.Model.WorkFlowTask>) this.nextTasks;
                }
              }
              else
              {
                this.result.DebugMessages += "已退回,等待他人处理";
                this.result.IsSuccess = true;
                this.result.Messages += this.result.DebugMessages;
                this.result.NextTasks = (IEnumerable<RoadFlow.Data.Model.WorkFlowTask>) this.nextTasks;
              }
              transactionScope.Complete();
            }
          }
          else if (4 == step1.Behavior.BackModel)
          {
            RoadFlow.Data.Model.WorkFlowTask model = this.Get(currentTask.PrevID);
            if (model != null)
            {
              model.ID = Guid.NewGuid();
              model.PrevID = currentTask.ID;
              model.Note = "退回任务";
              model.ReceiveTime = DateTimeNew.Now;
              model.SenderID = currentTask.ReceiveID;
              model.SenderName = currentTask.ReceiveName;
              model.SenderTime = model.ReceiveTime;
              model.Sort = currentTask.Sort + 1;
              model.Status = 0;
              model.Type = 4;
              model.Comment = "";
              model.OpenTime = new DateTime?();
              model.CompletedTime = !(step1.WorkTime > Decimal.Zero) ? new DateTime?() : new DateTime?(new WorkCalendar().GetWorkDate((double) step1.WorkTime, DateTimeNew.Now));
              model.CompletedTime1 = new DateTime?();
              using (TransactionScope transactionScope = new TransactionScope())
              {
                this.Add(model);
                this.nextTasks.Add(model);
                this.Completed(currentTask.ID, executeModel.Comment, executeModel.IsSign, 3, "", executeModel.Files);
                transactionScope.Complete();
              }
              List<string> stringList = new List<string>();
              foreach (RoadFlow.Data.Model.WorkFlowTask nextTask in this.nextTasks)
                stringList.Add(nextTask.StepName);
              string str = string.Format("已退回到:{0}", (object) model.ReceiveName);
              this.result.DebugMessages += str;
              this.result.IsSuccess = true;
              this.result.Messages += str;
              this.result.NextTasks = (IEnumerable<RoadFlow.Data.Model.WorkFlowTask>) this.nextTasks;
            }
            else
            {
              string str = string.Format("未找到发送者");
              this.result.DebugMessages += str;
              this.result.IsSuccess = true;
              this.result.Messages += str;
              this.result.NextTasks = (IEnumerable<RoadFlow.Data.Model.WorkFlowTask>) this.nextTasks;
            }
          }
          else
          {
            using (TransactionScope transactionScope = new TransactionScope())
            {
              List<RoadFlow.Data.Model.WorkFlowTask> workFlowTaskList = new List<RoadFlow.Data.Model.WorkFlowTask>();
              int num1 = 0;
              int num2 = step1.Behavior.BackModel;
              int num3 = step1.Behavior.HanlderModel;
              if (num2 == 2)
              {
                num2 = 1;
                num3 = 0;
              }
              else if (num2 == 3)
              {
                num2 = 1;
                num3 = 1;
              }
              if (num2 != 0)
              {
                if (num2 == 1)
                {
                  switch (num3)
                  {
                    case 0:
                      using (List<RoadFlow.Data.Model.WorkFlowTask>.Enumerator enumerator = this.GetTaskList(currentTask.FlowID, currentTask.StepID, currentTask.GroupID).FindAll((Predicate<RoadFlow.Data.Model.WorkFlowTask>) (p =>
                      {
                        if (p.Sort == currentTask.Sort)
                          return p.Type != 5;
                        return false;
                      })).GetEnumerator())
                      {
                        while (enumerator.MoveNext())
                        {
                          RoadFlow.Data.Model.WorkFlowTask current = enumerator.Current;
                          if (current.ID != currentTask.ID)
                          {
                            if (current.Status.In(0, 1))
                              this.Completed(current.ID, "", false, 5, "", "");
                          }
                          else
                            this.Completed(current.ID, executeModel.Comment, executeModel.IsSign, 3, "", executeModel.Files);
                        }
                        break;
                      }
                    case 1:
                      List<RoadFlow.Data.Model.WorkFlowTask> all1 = this.GetTaskList(currentTask.FlowID, currentTask.StepID, currentTask.GroupID).FindAll((Predicate<RoadFlow.Data.Model.WorkFlowTask>) (p =>
                      {
                        if (p.Sort == currentTask.Sort)
                          return p.Type != 5;
                        return false;
                      }));
                      if (all1.Count > 1 && all1.Where<RoadFlow.Data.Model.WorkFlowTask>((Func<RoadFlow.Data.Model.WorkFlowTask, bool>) (p => p.Status != 3)).Count<RoadFlow.Data.Model.WorkFlowTask>() - 1 > 0)
                        num1 = -1;
                      this.Completed(currentTask.ID, executeModel.Comment, executeModel.IsSign, 3, "", executeModel.Files);
                      break;
                    case 2:
                      List<RoadFlow.Data.Model.WorkFlowTask> all2 = this.GetTaskList(currentTask.FlowID, currentTask.StepID, currentTask.GroupID).FindAll((Predicate<RoadFlow.Data.Model.WorkFlowTask>) (p =>
                      {
                        if (p.Sort == currentTask.Sort)
                          return p.Type != 5;
                        return false;
                      }));
                      if (all2.Count > 1)
                      {
                        Decimal num4 = step1.Behavior.Percentage <= Decimal.Zero ? new Decimal(100) : step1.Behavior.Percentage;
                        if (global::MyExtensions.Round((Decimal) (all2.Where((Func<Data.Model.WorkFlowTask, bool>) (p => p.Status == 3)).Count() + 1) / (Decimal) all2.Count * new Decimal(100), 2) < new Decimal(100) - num4)
                        {
                          num1 = -1;
                        }
                        else
                        {
                          foreach (RoadFlow.Data.Model.WorkFlowTask workFlowTask in all2)
                          {
                            if (workFlowTask.ID != currentTask.ID)
                            {
                              if (workFlowTask.Status.In(0, 1))
                                this.Completed(workFlowTask.ID, "", false, 5, "", "");
                            }
                          }
                        }
                      }
                      this.Completed(currentTask.ID, executeModel.Comment, executeModel.IsSign, 3, "", executeModel.Files);
                      break;
                    case 3:
                      this.Completed(currentTask.ID, executeModel.Comment, executeModel.IsSign, 3, "", executeModel.Files);
                      break;
                  }
                  workFlowTaskList.Add(currentTask);
                }
                if (num1 == -1)
                {
                  this.result.DebugMessages += "已退回,等待他人处理";
                  this.result.IsSuccess = true;
                  this.result.Messages += "已退回,等待他人处理!";
                  this.result.NextTasks = (IEnumerable<RoadFlow.Data.Model.WorkFlowTask>) this.nextTasks;
                  transactionScope.Complete();
                  return;
                }
                foreach (RoadFlow.Data.Model.WorkFlowTask workFlowTask in workFlowTaskList)
                {
                  if (!workFlowTask.Status.In(2, 3))
                  {
                    if (workFlowTask.ID == currentTask.ID)
                      this.Completed(workFlowTask.ID, executeModel.Comment, executeModel.IsSign, 3, "", executeModel.Files);
                    else
                      this.Completed(workFlowTask.ID, "", false, 5, "他人已退回", "");
                  }
                }
                List<RoadFlow.Data.Model.WorkFlowTask> source2 = new List<RoadFlow.Data.Model.WorkFlowTask>();
                foreach (KeyValuePair<Guid, List<RoadFlow.Data.Model.Users>> step2 in executeModel.Steps)
                {
                  List<RoadFlow.Data.Model.WorkFlowTask> all = this.GetTaskList(executeModel.FlowID, step2.Key, executeModel.GroupID).FindAll((Predicate<RoadFlow.Data.Model.WorkFlowTask>) (p => p.Type != 7));
                  if (all.Count > 0)
                  {
                    List<RoadFlow.Data.Model.WorkFlowTask> list = all.OrderByDescending<RoadFlow.Data.Model.WorkFlowTask, int>((Func<RoadFlow.Data.Model.WorkFlowTask, int>) (p => p.Sort)).ToList<RoadFlow.Data.Model.WorkFlowTask>();
                    int maxSort = list.First<RoadFlow.Data.Model.WorkFlowTask>().Sort;
                    source2.AddRange((IEnumerable<RoadFlow.Data.Model.WorkFlowTask>) list.FindAll((Predicate<RoadFlow.Data.Model.WorkFlowTask>) (p => p.Sort == maxSort)));
                  }
                }
                Step step3 = this.bWorkFlow.GetNextSteps(executeModel.FlowID, executeModel.StepID).Find((Predicate<Step>) (p => (uint) p.Behavior.Countersignature > 0U));
                bool flag1 = step3 != null;
                bool flag2 = true;
                if (flag1)
                {
                  List<Step> prevSteps = this.bWorkFlow.GetPrevSteps(executeModel.FlowID, step3.ID);
                  switch (step3.Behavior.Countersignature)
                  {
                    case 1:
                      flag2 = false;
                      using (List<Step>.Enumerator enumerator = prevSteps.GetEnumerator())
                      {
                        while (enumerator.MoveNext())
                        {
                          if (this.IsBack(enumerator.Current, executeModel.FlowID, currentTask.GroupID, currentTask.PrevID, currentTask.Sort))
                          {
                            flag2 = true;
                            break;
                          }
                        }
                        break;
                      }
                    case 2:
                      flag2 = true;
                      using (List<Step>.Enumerator enumerator = prevSteps.GetEnumerator())
                      {
                        while (enumerator.MoveNext())
                        {
                          if (!this.IsBack(enumerator.Current, executeModel.FlowID, currentTask.GroupID, currentTask.PrevID, currentTask.Sort))
                          {
                            flag2 = false;
                            break;
                          }
                        }
                        break;
                      }
                    case 3:
                      int num4 = 0;
                      foreach (Step step2 in prevSteps)
                      {
                        if (this.IsBack(step2, executeModel.FlowID, currentTask.GroupID, currentTask.PrevID, currentTask.Sort))
                          ++num4;
                      }
                      flag2 = global::MyExtensions.Round((Decimal) num4 / (Decimal) prevSteps.Count * new Decimal(100), 2) >= (step3.Behavior.CountersignaturePercentage <= decimal.Zero ? new Decimal(100) : step3.Behavior.CountersignaturePercentage);
                      break;
                  }
                  if (flag2)
                  {
                    foreach (RoadFlow.Data.Model.WorkFlowTask task in this.GetTaskList(currentTask.ID, false))
                    {
                      if (!(task.ID == currentTask.ID))
                      {
                        if (!task.Status.In(2, 3, 4, 5, 6, 7))
                          this.Completed(task.ID, "", false, 5, "", "");
                      }
                    }
                  }
                }
                if (step1.Type == "subflow" && step1.SubFlowID.IsGuid() && !currentTask.SubFlowGroupID.IsNullOrEmpty())
                {
                  string subFlowGroupId = currentTask.SubFlowGroupID;
                  char[] chArray = new char[1]{ ',' };
                  foreach (string str in subFlowGroupId.Split(chArray))
                    this.DeleteInstance(step1.SubFlowID.ToGuid(), str.ToGuid(), true);
                }
                if (flag2)
                {
                  IEnumerable<RoadFlow.Data.Model.WorkFlowTask> source3 = source2.Distinct<RoadFlow.Data.Model.WorkFlowTask>((IEqualityComparer<RoadFlow.Data.Model.WorkFlowTask>) this);
                  if (source3.Count<RoadFlow.Data.Model.WorkFlowTask>() == 0)
                  {
                    this.Completed(currentTask.ID, "", false, 0, "", "");
                    this.result.DebugMessages += "没有接收人,退回失败!";
                    this.result.IsSuccess = false;
                    this.result.Messages += "没有接收人,退回失败!";
                    this.result.NextTasks = (IEnumerable<RoadFlow.Data.Model.WorkFlowTask>) this.nextTasks;
                    transactionScope.Complete();
                    return;
                  }
                  foreach (RoadFlow.Data.Model.WorkFlowTask workFlowTask in source3)
                  {
                    if (workFlowTask != null)
                    {
                      if (workFlowTask.Type == 5)
                      {
                        this.Delete(workFlowTask.ID);
                      }
                      else
                      {
                        int? otherType = workFlowTask.OtherType;
                        int num4 = 1;
                        if ((otherType.GetValueOrDefault() == num4 ? (otherType.HasValue ? 1 : 0) : 0) != 0)
                        {
                          RoadFlow.Data.Model.WorkFlowTask model = this.Get(workFlowTask.PrevID);
                          if (model != null)
                          {
                            model.OpenTime = new DateTime?();
                            model.Status = 0;
                            this.Update(model);
                            this.Delete(workFlowTask.ID);
                            this.nextTasks.Add(model);
                          }
                        }
                        else
                        {
                          RoadFlow.Data.Model.WorkFlowTask model = workFlowTask;
                          model.ID = Guid.NewGuid();
                          model.PrevID = currentTask.ID;
                          model.Note = "退回任务";
                          model.ReceiveTime = DateTimeNew.Now;
                          model.SenderID = currentTask.ReceiveID;
                          model.SenderName = currentTask.ReceiveName;
                          model.SenderTime = DateTimeNew.Now;
                          model.Sort = currentTask.Sort + 1;
                          model.Status = 0;
                          model.Type = 4;
                          model.Comment = "";
                          model.OpenTime = new DateTime?();
                          model.CompletedTime = !(step1.WorkTime > Decimal.Zero) ? new DateTime?() : new DateTime?(new WorkCalendar().GetWorkDate((double) step1.WorkTime, DateTimeNew.Now));
                          model.CompletedTime1 = new DateTime?();
                          this.Add(model);
                          this.nextTasks.Add(model);
                        }
                      }
                    }
                  }
                  foreach (Step nextStep in this.bWorkFlow.GetNextSteps(executeModel.FlowID, executeModel.StepID))
                    this.dataWorkFlowTask.DeleteTempTasks(currentTask.FlowID, nextStep.ID, currentTask.GroupID, flag1 ? Guid.Empty : step1.ID);
                }
                transactionScope.Complete();
              }
              else
              {
                this.result.DebugMessages = "当前步骤设置为不能退回";
                this.result.IsSuccess = false;
                this.result.Messages = "当前步骤设置为不能退回";
                return;
              }
            }
            if (this.nextTasks.Count > 0)
            {
              foreach (IGrouping<Guid, RoadFlow.Data.Model.WorkFlowTask> source2 in this.nextTasks.GroupBy<RoadFlow.Data.Model.WorkFlowTask, Guid>((Func<RoadFlow.Data.Model.WorkFlowTask, Guid>) (p => p.StepID)))
              {
                if (source2.Count<RoadFlow.Data.Model.WorkFlowTask>() > 0 && source2.First<RoadFlow.Data.Model.WorkFlowTask>().StepSort != source2.Last<RoadFlow.Data.Model.WorkFlowTask>().StepSort)
                {
                  int num = source2.Max<RoadFlow.Data.Model.WorkFlowTask>((Func<RoadFlow.Data.Model.WorkFlowTask, int>) (p => p.StepSort));
                  foreach (RoadFlow.Data.Model.WorkFlowTask model in (IEnumerable<RoadFlow.Data.Model.WorkFlowTask>) source2)
                  {
                    if (model.StepSort != num)
                    {
                      model.Status = -1;
                      this.nextTasks.Remove(model);
                      this.Update(model);
                    }
                  }
                }
              }
              List<string> source3 = new List<string>();
              foreach (RoadFlow.Data.Model.WorkFlowTask nextTask in this.nextTasks)
                source3.Add(nextTask.StepName);
              string str = string.Format("已退回到:{0}", (object) source3.Distinct<string>().ToArray<string>().Join1<string>(","));
              this.result.DebugMessages += str;
              this.result.IsSuccess = true;
              this.result.Messages += str;
              this.result.NextTasks = (IEnumerable<RoadFlow.Data.Model.WorkFlowTask>) this.nextTasks;
            }
            else
            {
              this.result.DebugMessages += "已退回,等待其它步骤处理";
              this.result.IsSuccess = true;
              this.result.Messages += "已退回,等待其它步骤处理";
              this.result.NextTasks = (IEnumerable<RoadFlow.Data.Model.WorkFlowTask>) this.nextTasks;
            }
          }
        }
      }
    }

    private void executeSave(Execute executeModel)
    {
      bool flag = executeModel.StepID == this.wfInstalled.FirstStepID && executeModel.TaskID == Guid.Empty && executeModel.GroupID == Guid.Empty;
      RoadFlow.Data.Model.WorkFlowTask model = !flag ? this.Get(executeModel.TaskID) : this.createFirstTask(executeModel, false);
      if (model == null)
      {
        this.result.DebugMessages = "未能创建或找到当前任务";
        this.result.IsSuccess = false;
        this.result.Messages = "未能创建或找到当前任务";
      }
      else if (model.Status.In(2, 3, 4, 5, 6, 7))
      {
        this.result.DebugMessages = "当前任务已处理";
        this.result.IsSuccess = false;
        this.result.Messages = "当前任务已处理";
      }
      else if (model.ReceiveID != Users.CurrentUserID && model.ReceiveID != RoadFlow.Platform.WeiXin.Organize.CurrentUserID && model.IsExpiredAutoSubmit == 0)
      {
        this.result.DebugMessages = "不能处理当前任务";
        this.result.IsSuccess = false;
        this.result.Messages = "不能处理当前任务";
      }
      else
      {
        model.InstanceID = executeModel.InstanceID;
        this.nextTasks.Add(model);
        if (!flag && !executeModel.Title.IsNullOrEmpty())
        {
          model.Title = executeModel.Title;
          this.Update(model);
        }
        this.result.DebugMessages = "保存成功";
        this.result.IsSuccess = true;
        this.result.Messages = "保存成功";
      }
    }

    private void executeCopyforComplete(Execute executeModel)
    {
      if (executeModel.TaskID == Guid.Empty || executeModel.FlowID == Guid.Empty)
      {
        this.result.DebugMessages = "完成流程参数错误";
        this.result.IsSuccess = false;
        this.result.Messages = "完成流程参数错误";
      }
      else
      {
        RoadFlow.Data.Model.WorkFlowTask workFlowTask = this.Get(executeModel.TaskID);
        if (workFlowTask == null)
        {
          this.result.DebugMessages = "未找到当前任务";
          this.result.IsSuccess = false;
          this.result.Messages = "未找到当前任务";
        }
        else if (workFlowTask.Status.In(2, 3, 4, 5, 6, 7))
        {
          this.result.DebugMessages = "当前任务已处理";
          this.result.IsSuccess = false;
          this.result.Messages = "当前任务已处理";
        }
        else
        {
          this.Completed(workFlowTask.ID, executeModel.Comment, executeModel.IsSign, 2, workFlowTask.Note, executeModel.Files);
          this.result.DebugMessages += "已完成";
          this.result.IsSuccess = true;
          this.result.Messages += "已完成";
        }
      }
    }

    private void executeComplete(Execute executeModel, bool isCompleteTask = true)
    {
      if (executeModel.TaskID == Guid.Empty || executeModel.FlowID == Guid.Empty)
      {
        this.result.DebugMessages = "完成流程参数错误";
        this.result.IsSuccess = false;
        this.result.Messages = "完成流程参数错误";
      }
      else
      {
        RoadFlow.Data.Model.WorkFlowTask workFlowTask = this.Get(executeModel.TaskID);
        if (workFlowTask == null)
        {
          this.result.DebugMessages = "未找到当前任务";
          this.result.IsSuccess = false;
          this.result.Messages = "未找到当前任务";
        }
        else
        {
          if (isCompleteTask)
          {
            if (workFlowTask.Status.In(2, 3, 4, 5, 6, 7))
            {
              this.result.DebugMessages = "当前任务已处理";
              this.result.IsSuccess = false;
              this.result.Messages = "当前任务已处理";
              return;
            }
          }
          if (this.wfInstalled.TitleField != null && this.wfInstalled.TitleField.LinkID != Guid.Empty && (!this.wfInstalled.TitleField.Table.IsNullOrEmpty() && !this.wfInstalled.TitleField.Field.IsNullOrEmpty()) && this.wfInstalled.DataBases.Count<DataBases>() > 0)
          {
            DataBases dataBases = this.wfInstalled.DataBases.First<DataBases>();
            try
            {
              RoadFlow.Data.Factory.Factory.GetDBHelper().Execute(string.Format("UPDATE {0} SET {1}='{2}' WHERE {3}", (object) this.wfInstalled.TitleField.Table, (object) this.wfInstalled.TitleField.Field, (object) "1", (object) string.Format("{0}='{1}'", (object) dataBases.PrimaryKey, (object) workFlowTask.InstanceID)));
            }
            catch (Exception ex)
            {
              Log.Add("更新流程完成标题发生了错误-" + workFlowTask.Title, ex.Message + ex.StackTrace, Log.Types.系统错误, executeModel.Serialize(), "", (RoadFlow.Data.Model.Users) null);
            }
          }
          if (isCompleteTask)
            this.Completed(workFlowTask.ID, executeModel.Comment, executeModel.IsSign, 2, "", executeModel.Files);
          List<RoadFlow.Data.Model.WorkFlowTask> bySubFlowGroupId = this.GetBySubFlowGroupID(workFlowTask.GroupID);
          if (bySubFlowGroupId.Count > 0)
          {
            RoadFlow.Data.Model.WorkFlowTask parentTask = bySubFlowGroupId.First<RoadFlow.Data.Model.WorkFlowTask>();
            WorkFlowInstalled workFlowRunModel = this.bWorkFlow.GetWorkFlowRunModel(parentTask.FlowID, true);
            if (workFlowRunModel != null)
            {
              IEnumerable<Step> source = workFlowRunModel.Steps.Where<Step>((Func<Step, bool>) (p => p.ID == parentTask.StepID));
              if (source.Count<Step>() > 0 && !source.First<Step>().Event.SubFlowCompletedBefore.IsNullOrEmpty())
                this.ExecuteFlowCustomEvent(source.First<Step>().Event.SubFlowCompletedBefore.Trim(), (object) new WorkFlowCustomEventParams()
                {
                  FlowID = parentTask.FlowID,
                  GroupID = parentTask.GroupID,
                  InstanceID = parentTask.InstanceID,
                  StepID = parentTask.StepID,
                  TaskID = parentTask.ID
                }, "");
            }
          }
          this.result.DebugMessages += "已完成";
          this.result.IsSuccess = true;
          this.result.Messages += "已完成";
        }
      }
    }

    private void executeRedirect(Execute executeModel)
    {
      RoadFlow.Data.Model.WorkFlowTask model = this.Get(executeModel.TaskID);
      if (model == null)
      {
        this.result.DebugMessages = "未能创建或找到当前任务";
        this.result.IsSuccess = false;
        this.result.Messages = "未能创建或找到当前任务";
      }
      else if (model.Status.In(2, 3, 4, 5, 6, 7))
      {
        this.result.DebugMessages = "当前任务已处理";
        this.result.IsSuccess = false;
        this.result.Messages = "当前任务已处理";
      }
      else if (model.ReceiveID != Users.CurrentUserID && model.ReceiveID != RoadFlow.Platform.WeiXin.Organize.CurrentUserID && model.IsExpiredAutoSubmit == 0)
      {
        this.result.DebugMessages = "不能处理当前任务";
        this.result.IsSuccess = false;
        this.result.Messages = "不能处理当前任务";
      }
      else if (model.Status == -1)
      {
        this.result.DebugMessages = "当前任务正在等待他人处理";
        this.result.IsSuccess = false;
        this.result.Messages = "当前任务正在等待他人处理";
      }
      else
      {
        KeyValuePair<Guid, List<RoadFlow.Data.Model.Users>> keyValuePair = executeModel.Steps.First<KeyValuePair<Guid, List<RoadFlow.Data.Model.Users>>>();
        if (keyValuePair.Value.Count == 0)
        {
          this.result.DebugMessages = "未设置转交人员";
          this.result.IsSuccess = false;
          this.result.Messages = "未设置转交人员";
        }
        else
        {
          string receiveName = model.ReceiveName;
          using (TransactionScope transactionScope = new TransactionScope())
          {
            keyValuePair = executeModel.Steps.First<KeyValuePair<Guid, List<RoadFlow.Data.Model.Users>>>();
            foreach (RoadFlow.Data.Model.Users users in keyValuePair.Value)
            {
              model.ID = Guid.NewGuid();
              model.ReceiveID = users.ID;
              model.ReceiveName = users.Name;
              model.OpenTime = new DateTime?();
              model.Status = 0;
              model.IsSign = new int?(0);
              model.Type = 3;
              model.Note = string.Format("该任务由{0}转交", (object) receiveName);
              if (!this.HasNoCompletedTasks(model.FlowID, model.StepID, model.GroupID, users.ID))
                this.Add(model);
              this.nextTasks.Add(model);
            }
            this.Completed(executeModel.TaskID, executeModel.Comment, executeModel.IsSign, 2, "已转交他人处理", "");
            transactionScope.Complete();
          }
          List<string> source = new List<string>();
          foreach (RoadFlow.Data.Model.Users users in executeModel.Steps.First<KeyValuePair<Guid, List<RoadFlow.Data.Model.Users>>>().Value)
            source.Add(users.Name);
          string str = source.Distinct<string>().ToArray<string>().Join1<string>(",");
          this.result.DebugMessages = "已转交给:" + str;
          this.result.IsSuccess = true;
          this.result.Messages = "已转交给:" + str;
        }
      }
    }

    private void executeAddWrite(Execute executeModel)
    {
      if (executeModel.TaskID.IsEmptyGuid())
      {
        this.result.DebugMessages = "未找到当前任务";
        this.result.IsSuccess = false;
        this.result.Messages = "未找到当前任务";
      }
      else
      {
        RoadFlow.Data.Model.WorkFlowTask task = this.Get(executeModel.TaskID);
        if (task == null)
        {
          this.result.DebugMessages = "未找到当前任务";
          this.result.IsSuccess = false;
          this.result.Messages = "未找到当前任务";
        }
        else if (task.ReceiveID != Users.CurrentUserID && task.ReceiveID != RoadFlow.Platform.WeiXin.Organize.CurrentUserID && task.IsExpiredAutoSubmit == 0)
        {
          this.result.DebugMessages = "不能处理当前任务";
          this.result.IsSuccess = false;
          this.result.Messages = "不能处理当前任务";
        }
        else if (task.OtherType.ToString().Length != 2)
        {
          this.result.DebugMessages = "未找到加签类型和审批类型!";
          this.result.IsSuccess = false;
          this.result.Messages = "加签参数错误";
        }
        else
        {
          int num1 = task.OtherType.ToString().Left(1).ToInt();
          int num2 = task.OtherType.ToString().Right(1).ToInt();
          List<RoadFlow.Data.Model.WorkFlowTask> all = this.GetTaskList(task.FlowID, task.StepID, task.GroupID).FindAll((Predicate<RoadFlow.Data.Model.WorkFlowTask>) (p =>
          {
            if (p.PrevID == task.PrevID)
              return p.Type == 7;
            return false;
          }));
          List<RoadFlow.Data.Model.WorkFlowTask> workFlowTaskList = new List<RoadFlow.Data.Model.WorkFlowTask>();
          switch (num2)
          {
            case 1:
              this.Completed(task.ID, executeModel.Comment, executeModel.IsSign, 2, "", executeModel.Files);
              break;
            case 2:
              using (List<RoadFlow.Data.Model.WorkFlowTask>.Enumerator enumerator = all.FindAll((Predicate<RoadFlow.Data.Model.WorkFlowTask>) (p => p.Status.In(-1, 0, 1))).GetEnumerator())
              {
                while (enumerator.MoveNext())
                {
                  RoadFlow.Data.Model.WorkFlowTask current = enumerator.Current;
                  if (current.ID == task.ID)
                    this.Completed(task.ID, executeModel.Comment, executeModel.IsSign, 2, "", executeModel.Files);
                  else
                    this.Completed(current.ID, "", false, 4, "", "");
                }
                break;
              }
            case 3:
              this.Completed(task.ID, executeModel.Comment, executeModel.IsSign, 2, "", executeModel.Files);
              IOrderedEnumerable<RoadFlow.Data.Model.WorkFlowTask> source = all.FindAll((Predicate<RoadFlow.Data.Model.WorkFlowTask>) (p =>
              {
                if (p.Status.In(-1, 0, 1))
                  return p.ID != task.ID;
                return false;
              })).OrderBy<RoadFlow.Data.Model.WorkFlowTask, DateTime>((Func<RoadFlow.Data.Model.WorkFlowTask, DateTime>) (p => p.ReceiveTime));
              if (source.Count<RoadFlow.Data.Model.WorkFlowTask>() > 0)
              {
                RoadFlow.Data.Model.WorkFlowTask model = source.FirstOrDefault<RoadFlow.Data.Model.WorkFlowTask>();
                model.Status = 0;
                this.Update(model);
                workFlowTaskList.Add(model);
                break;
              }
              break;
          }
          List<RoadFlow.Data.Model.WorkFlowTask> nextTasks = new List<RoadFlow.Data.Model.WorkFlowTask>();
          if (this.isPassingAddWrite(task, out nextTasks) && nextTasks.Count > 0)
          {
            switch (num1)
            {
              case 1:
                using (List<RoadFlow.Data.Model.WorkFlowTask>.Enumerator enumerator = nextTasks.GetEnumerator())
                {
                  while (enumerator.MoveNext())
                  {
                    RoadFlow.Data.Model.WorkFlowTask current = enumerator.Current;
                    current.Status = 1;
                    this.Update(current);
                    workFlowTaskList.Add(current);
                  }
                  break;
                }
              case 2:
              case 3:
                using (List<RoadFlow.Data.Model.WorkFlowTask>.Enumerator enumerator = this.GetNextTaskList(nextTasks.FirstOrDefault<RoadFlow.Data.Model.WorkFlowTask>().ID).FindAll((Predicate<RoadFlow.Data.Model.WorkFlowTask>) (p => p.Status == -1)).GetEnumerator())
                {
                  while (enumerator.MoveNext())
                  {
                    RoadFlow.Data.Model.WorkFlowTask current = enumerator.Current;
                    current.Status = 0;
                    this.Update(current);
                    workFlowTaskList.Add(current);
                  }
                  break;
                }
            }
          }
          StringBuilder stringBuilder = new StringBuilder();
          foreach (RoadFlow.Data.Model.WorkFlowTask workFlowTask in workFlowTaskList)
          {
            stringBuilder.Append(workFlowTask.ReceiveName);
            stringBuilder.Append(",");
          }
          Result result = this.result;
          string str1 = "已发送";
          string str2;
          if (stringBuilder.Length <= 0)
            str2 = "";
          else
            str2 = "到" + stringBuilder.ToString().TrimEnd(',');
          string str3 = str1 + str2;
          result.DebugMessages = str3;
          this.result.IsSuccess = true;
          this.result.NextTasks = (IEnumerable<RoadFlow.Data.Model.WorkFlowTask>) workFlowTaskList;
          this.result.Messages = this.result.DebugMessages;
        }
      }
    }

    private bool isPassingAddWrite(RoadFlow.Data.Model.WorkFlowTask addWriteTask, out List<RoadFlow.Data.Model.WorkFlowTask> nextTasks)
    {
      nextTasks = new List<RoadFlow.Data.Model.WorkFlowTask>();
      if (addWriteTask == null)
        return true;
      List<RoadFlow.Data.Model.WorkFlowTask> taskList = this.GetTaskList(addWriteTask.FlowID, addWriteTask.StepID, addWriteTask.GroupID);
      if (taskList.Count == 0)
        return true;
      RoadFlow.Data.Model.WorkFlowTask task1 = taskList.Find((Predicate<RoadFlow.Data.Model.WorkFlowTask>) (p => p.ID == addWriteTask.PrevID));
      if (task1 == null)
        return true;
      List<RoadFlow.Data.Model.WorkFlowTask> all = taskList.FindAll((Predicate<RoadFlow.Data.Model.WorkFlowTask>) (p =>
      {
        if (p.Sort == task1.Sort)
          return p.Type != 7;
        return false;
      }));
      nextTasks = all;
      List<RoadFlow.Data.Model.WorkFlowTask> source1 = new List<RoadFlow.Data.Model.WorkFlowTask>();
      foreach (RoadFlow.Data.Model.WorkFlowTask workFlowTask in all)
      {
        RoadFlow.Data.Model.WorkFlowTask t = workFlowTask;
        source1.AddRange((IEnumerable<RoadFlow.Data.Model.WorkFlowTask>) taskList.FindAll((Predicate<RoadFlow.Data.Model.WorkFlowTask>) (p =>
        {
          if (p.PrevID == t.ID)
            return p.Type == 7;
          return false;
        })));
      }
      foreach (IGrouping<Guid, RoadFlow.Data.Model.WorkFlowTask> source2 in source1.GroupBy<RoadFlow.Data.Model.WorkFlowTask, Guid>((Func<RoadFlow.Data.Model.WorkFlowTask, Guid>) (p => p.PrevID)))
      {
        switch (source2.FirstOrDefault<RoadFlow.Data.Model.WorkFlowTask>().OtherType.ToString().Right(1).ToInt())
        {
          case 1:
          case 3:
            if (source2.Where<RoadFlow.Data.Model.WorkFlowTask>((Func<RoadFlow.Data.Model.WorkFlowTask, bool>) (p => p.Status.In(0, 1, -1))).Count<RoadFlow.Data.Model.WorkFlowTask>() > 0)
              return false;
            continue;
          case 2:
            if (source2.Where<RoadFlow.Data.Model.WorkFlowTask>((Func<RoadFlow.Data.Model.WorkFlowTask, bool>) (p => p.Status.In(2))).Count<RoadFlow.Data.Model.WorkFlowTask>() == 0)
              return false;
            continue;
          default:
            continue;
        }
      }
      return true;
    }

    private List<RoadFlow.Data.Model.WorkFlowTask> createTempTasks(Execute executeModel, RoadFlow.Data.Model.WorkFlowTask currentTask)
    {
      List<RoadFlow.Data.Model.WorkFlowTask> workFlowTaskList = new List<RoadFlow.Data.Model.WorkFlowTask>();
      foreach (KeyValuePair<Guid, List<RoadFlow.Data.Model.Users>> step1 in executeModel.Steps)
      {
        KeyValuePair<Guid, List<RoadFlow.Data.Model.Users>> step = step1;
        int num = 0;
        foreach (RoadFlow.Data.Model.Users users in step.Value)
        {
          IEnumerable<Step> source = this.wfInstalled.Steps.Where<Step>((Func<Step, bool>) (p => p.ID == step.Key));
          if (source.Count<Step>() != 0)
          {
            Step step2 = source.First<Step>();
            RoadFlow.Data.Model.WorkFlowTask model = new RoadFlow.Data.Model.WorkFlowTask();
            if (executeModel.StepCompletedTimes.Keys.Contains<Guid>(step2.ID))
              model.CompletedTime = new DateTime?(executeModel.StepCompletedTimes[step2.ID]);
            else if (step2.WorkTime > Decimal.Zero)
              model.CompletedTime = new DateTime?(new WorkCalendar().GetWorkDate((double) step2.WorkTime, DateTimeNew.Now));
            model.FlowID = executeModel.FlowID;
            model.GroupID = currentTask != null ? currentTask.GroupID : executeModel.GroupID;
            model.ID = Guid.NewGuid();
            model.Type = 0;
            model.InstanceID = executeModel.InstanceID;
            if (!executeModel.Note.IsNullOrEmpty())
              model.Note = executeModel.Note;
            model.PrevID = currentTask.ID;
            model.PrevStepID = currentTask.StepID;
            model.ReceiveID = users.ID;
            model.ReceiveName = users.Name;
            model.ReceiveTime = DateTimeNew.Now;
            model.SenderID = executeModel.Sender.ID;
            model.SenderName = executeModel.Sender.Name;
            model.SenderTime = model.ReceiveTime;
            model.Status = -1;
            model.StepID = step.Key;
            model.StepName = step2.Name;
            model.Sort = currentTask.Sort + 1;
            model.Title = executeModel.Title.IsNullOrEmpty() ? currentTask.Title : executeModel.Title;
            model.OtherType = new int?(executeModel.OtherType);
            model.StepSort = num++;
            if (!this.HasNoCompletedTasks(executeModel.FlowID, step.Key, currentTask.GroupID, users.ID))
              this.Add(model);
            workFlowTaskList.Add(model);
          }
        }
      }
      return workFlowTaskList;
    }

    private bool IsPassing(Step step, Guid flowID, Guid groupID, RoadFlow.Data.Model.WorkFlowTask currentTask, Guid currentPrevStep)
    {
      List<RoadFlow.Data.Model.WorkFlowTask> all1 = this.GetTaskList(flowID, step.ID, groupID).FindAll((Predicate<RoadFlow.Data.Model.WorkFlowTask>) (p => p.Type != 7));
      int maxSort = all1.Count > 0 ? all1.Max<RoadFlow.Data.Model.WorkFlowTask>((Func<RoadFlow.Data.Model.WorkFlowTask, int>) (p => p.Sort)) : -1;
      List<RoadFlow.Data.Model.WorkFlowTask> all2 = all1.FindAll((Predicate<RoadFlow.Data.Model.WorkFlowTask>) (p =>
      {
        if (p.Sort == maxSort)
          return p.Type != 5;
        return false;
      }));
      if (all2.Count == 0)
      {
        foreach (Step betweenStep in new WorkFlow().getBetweenSteps(new WorkFlow().GetWorkFlowRunModel(flowID, true), currentTask.PrevStepID, step.ID))
        {
          List<RoadFlow.Data.Model.WorkFlowTask> all3 = this.GetTaskList(flowID, betweenStep.ID, groupID).FindAll((Predicate<RoadFlow.Data.Model.WorkFlowTask>) (p =>
          {
            if (p.Type != 7)
              return p.Type != 5;
            return false;
          }));
          int maxsort1 = all3.Count > 0 ? all3.Max<RoadFlow.Data.Model.WorkFlowTask>((Func<RoadFlow.Data.Model.WorkFlowTask, int>) (p => p.Sort)) : -1;
          if (all3.Find((Predicate<RoadFlow.Data.Model.WorkFlowTask>) (p => p.Sort == maxsort1)) != null)
            return false;
        }
        return true;
      }
      bool flag = true;
      switch (step.Behavior.HanlderModel)
      {
        case 0:
        case 3:
          flag = all2.Where<RoadFlow.Data.Model.WorkFlowTask>((Func<RoadFlow.Data.Model.WorkFlowTask, bool>) (p => p.Status != 2)).Count<RoadFlow.Data.Model.WorkFlowTask>() == 0;
          break;
        case 1:
          flag = all2.Where<RoadFlow.Data.Model.WorkFlowTask>((Func<RoadFlow.Data.Model.WorkFlowTask, bool>) (p => p.Status == 2)).Count<RoadFlow.Data.Model.WorkFlowTask>() > 0;
          break;
        case 2:
          flag = global::MyExtensions.Round((Decimal) (all2.Where((Func<Data.Model.WorkFlowTask, bool>) (p => p.Status == 2)).Count() + 1) / (Decimal) all2.Count * new Decimal(100), 2) >= (step.Behavior.Percentage <= decimal.Zero ? new Decimal(100) : step.Behavior.Percentage);
          break;
      }
      if (flag)
      {
        List<RoadFlow.Data.Model.WorkFlowTask> nextTasks = new List<RoadFlow.Data.Model.WorkFlowTask>();
        flag = this.isPassingAddWrite(all2.FirstOrDefault<RoadFlow.Data.Model.WorkFlowTask>(), out nextTasks);
      }
      return flag;
    }

    private bool IsBack(Step step, Guid flowID, Guid groupID, Guid taskID, int sort)
    {
      List<RoadFlow.Data.Model.WorkFlowTask> all = this.GetTaskList(flowID, step.ID, groupID).FindAll((Predicate<RoadFlow.Data.Model.WorkFlowTask>) (p =>
      {
        if (p.Sort == sort)
          return p.Type != 5;
        return false;
      }));
      if (all.Count == 0)
        return false;
      bool flag = true;
      switch (step.Behavior.HanlderModel)
      {
        case 0:
        case 3:
          flag = all.Where<RoadFlow.Data.Model.WorkFlowTask>((Func<RoadFlow.Data.Model.WorkFlowTask, bool>) (p => p.Status.In(3, 5))).Count<RoadFlow.Data.Model.WorkFlowTask>() > 0;
          break;
        case 1:
          flag = all.Where<RoadFlow.Data.Model.WorkFlowTask>((Func<RoadFlow.Data.Model.WorkFlowTask, bool>) (p => p.Status.In(2, 4))).Count<RoadFlow.Data.Model.WorkFlowTask>() == 0;
          break;
        case 2:
          flag = global::MyExtensions.Round((Decimal) (all.Where((Func<Data.Model.WorkFlowTask, bool>) (p => p.Status.In(3, 5))).Count() + 1) / (Decimal) all.Count * new Decimal(100), 2) >= new Decimal(100) - (step.Behavior.Percentage <= decimal.Zero ? new Decimal(100) : step.Behavior.Percentage);
          break;
      }
      return flag;
    }

    private RoadFlow.Data.Model.WorkFlowTask createFirstTask(Execute executeModel, bool isSubFlow = false)
    {
      if (this.wfInstalled == null | isSubFlow)
        this.wfInstalled = this.bWorkFlow.GetWorkFlowRunModel(executeModel.FlowID, true);
      IEnumerable<Step> source = this.wfInstalled.Steps.Where<Step>((Func<Step, bool>) (p => p.ID == this.wfInstalled.FirstStepID));
      if (source.Count<Step>() == 0)
        return (RoadFlow.Data.Model.WorkFlowTask) null;
      RoadFlow.Data.Model.WorkFlowTask model = new RoadFlow.Data.Model.WorkFlowTask();
      if (source.First<Step>().WorkTime > Decimal.Zero)
        model.CompletedTime = new DateTime?(new WorkCalendar().GetWorkDate((double) source.First<Step>().WorkTime, DateTimeNew.Now));
      model.FlowID = executeModel.FlowID;
      model.GroupID = executeModel.GroupID.IsEmptyGuid() ? Guid.NewGuid() : executeModel.GroupID;
      model.ID = Guid.NewGuid();
      model.Type = 0;
      model.InstanceID = executeModel.InstanceID;
      if (!executeModel.Note.IsNullOrEmpty())
        model.Note = executeModel.Note;
      model.PrevID = Guid.Empty;
      model.PrevStepID = Guid.Empty;
      model.ReceiveID = executeModel.Sender.ID;
      model.ReceiveName = executeModel.Sender.Name;
      model.ReceiveTime = DateTimeNew.Now;
      model.SenderID = executeModel.Sender.ID;
      model.SenderName = executeModel.Sender.Name;
      model.SenderTime = model.ReceiveTime;
      model.Status = 0;
      model.StepID = this.wfInstalled.FirstStepID;
      model.StepName = source.First<Step>().Name;
      model.Sort = 1;
      model.StepSort = 0;
      model.OtherType = new int?(executeModel.OtherType);
      RoadFlow.Data.Model.WorkFlowTask workFlowTask = model;
      string str;
      if (!executeModel.Title.IsNullOrEmpty())
        str = executeModel.Title;
      else
        str = this.wfInstalled.Name + "-" + model.StepName + "-" + model.SenderName;
      workFlowTask.Title = str;
      this.Add(model);
      if (isSubFlow)
        this.wfInstalled = (WorkFlowInstalled) null;
      return model;
    }

    public List<RoadFlow.Data.Model.WorkFlowTask> GetTasks(Guid userID, out string pager, string query = "", string title = "", string flowid = "", string sender = "", string date1 = "", string date2 = "", int type = 0)
    {
      return this.dataWorkFlowTask.GetTasks(userID, out pager, query, title, flowid, Users.RemovePrefix(sender), date1, date2, type);
    }

    public List<RoadFlow.Data.Model.WorkFlowTask> GetTasks(Guid userID, out long count, int size, int number, string title = "", string flowid = "", string sender = "", string date1 = "", string date2 = "", int type = 0, string order = "")
    {
      return this.dataWorkFlowTask.GetTasks(userID, out count, size, number, title, flowid, Users.RemovePrefix(sender), date1, date2, type, order);
    }

    public List<RoadFlow.Data.Model.WorkFlowTask> GetInstances(Guid[] flowID, Guid[] senderID, Guid[] receiveID, out string pager, string query = "", string title = "", string flowid = "", string date1 = "", string date2 = "", int status = 0)
    {
      return this.dataWorkFlowTask.GetInstances(flowID, senderID, receiveID, out pager, query, title, flowid, date1, date2, status);
    }

    public DataTable GetInstances1(Guid[] flowID, Guid[] senderID, Guid[] receiveID, out string pager, string query = "", string title = "", string flowid = "", string date1 = "", string date2 = "", int status = 0)
    {
      return this.dataWorkFlowTask.GetInstances1(flowID, senderID, receiveID, out pager, query, title, flowid, date1, date2, status);
    }

    public DataTable GetInstances1(Guid[] flowID, Guid[] senderID, Guid[] receiveID, out long count, int size, int number, string title = "", string flowid = "", string date1 = "", string date2 = "", int status = 0, string order = "")
    {
      return this.dataWorkFlowTask.GetInstances1(flowID, senderID, receiveID, out count, size, number, title, flowid, date1, date2, status, order);
    }

    public object ExecuteFlowCustomEvent(string eventName, object eventParams, string dllName = "")
    {
      if (dllName.IsNullOrEmpty())
        dllName = eventName.Substring(0, eventName.IndexOf('.'));
      Assembly assembly = Assembly.Load(dllName);
      string withoutExtension = Path.GetFileNameWithoutExtension(eventName);
      string str = eventName.Substring(withoutExtension.Length + 1);
      string name = withoutExtension;
      int num = 1;
      Type type = assembly.GetType(name, num != 0);
      object instance = Activator.CreateInstance(type, false);
      MethodInfo method = type.GetMethod(str);
      if (!(method != (MethodInfo) null))
        throw new MissingMethodException(withoutExtension, str);
      return method.Invoke(instance, new object[1]{ eventParams });
    }

    public int DeleteInstance(Guid flowID, Guid groupID, bool hasInstanceData = false)
    {
      if (hasInstanceData)
      {
        List<RoadFlow.Data.Model.WorkFlowTask> taskList = this.GetTaskList(flowID, groupID);
        if (taskList.Count > 0 && !taskList.First<RoadFlow.Data.Model.WorkFlowTask>().InstanceID.IsNullOrEmpty())
        {
          WorkFlowInstalled workFlowRunModel = this.bWorkFlow.GetWorkFlowRunModel(flowID, true);
          if (workFlowRunModel != null && workFlowRunModel.DataBases.Count<DataBases>() > 0)
          {
            DataBases dataBases = workFlowRunModel.DataBases.First<DataBases>();
            new DBConnection().DeleteData(dataBases.LinkID, dataBases.Table, dataBases.PrimaryKey, taskList.First<RoadFlow.Data.Model.WorkFlowTask>().InstanceID);
          }
        }
      }
      return this.dataWorkFlowTask.Delete(flowID, groupID);
    }

    public int Completed(Guid taskID, string comment = "", bool isSign = false, int status = 2, string note = "", string files = "")
    {
      return this.dataWorkFlowTask.Completed(taskID, comment, isSign, status, note, files);
    }

    public List<RoadFlow.Data.Model.WorkFlowTask> GetTaskList(Guid flowID, Guid stepID, Guid groupID)
    {
      return this.dataWorkFlowTask.GetTaskList(flowID, stepID, groupID);
    }

    public List<RoadFlow.Data.Model.WorkFlowTask> GetTaskList(Guid flowID, Guid groupID)
    {
      return this.dataWorkFlowTask.GetTaskList(flowID, groupID);
    }

    public List<RoadFlow.Data.Model.WorkFlowTask> GetTaskList(Guid taskID, bool isStepID = true)
    {
      return this.dataWorkFlowTask.GetTaskList(taskID, isStepID);
    }

    public List<RoadFlow.Data.Model.WorkFlowTask> GetTaskListByStepID(Guid taskID, Guid stepID)
    {
      return this.dataWorkFlowTask.GetTaskList(taskID, true).FindAll((Predicate<RoadFlow.Data.Model.WorkFlowTask>) (p => p.StepID == stepID));
    }

    public List<RoadFlow.Data.Model.WorkFlowTask> GetPrevTaskList(Guid taskID)
    {
      return this.dataWorkFlowTask.GetPrevTaskList(taskID);
    }

    public List<RoadFlow.Data.Model.WorkFlowTask> GetNextTaskList(Guid taskID)
    {
      return this.dataWorkFlowTask.GetNextTaskList(taskID);
    }

    public System.Collections.Generic.Dictionary<Guid, string> GetBackSteps(Guid taskID, int backType, Guid stepID, WorkFlowInstalled wfInstalled)
    {
      System.Collections.Generic.Dictionary<Guid, string> dictionary = new System.Collections.Generic.Dictionary<Guid, string>();
      IEnumerable<Step> source1 = wfInstalled.Steps.Where<Step>((Func<Step, bool>) (p => p.ID == stepID));
      if (source1.Count<Step>() == 0)
        return dictionary;
      Step step = source1.First<Step>();
      RoadFlow.Data.Model.WorkFlowTask task = this.Get(taskID);
      if (step.Behavior.HanlderModel == 4 && task.StepSort > 0)
      {
        RoadFlow.Data.Model.WorkFlowTask workFlowTask = this.GetTaskList(taskID, true).Find((Predicate<RoadFlow.Data.Model.WorkFlowTask>) (p => p.StepSort == task.StepSort - 1));
        if (workFlowTask != null)
        {
          dictionary.Add(Guid.Empty, step.Name + "(" + workFlowTask.ReceiveName + ")");
          return dictionary;
        }
      }
      if (task != null && task.Type == 7)
      {
        dictionary.Add(Guid.Empty, task.SenderName);
        return dictionary;
      }
      if (task != null && 4 == step.Behavior.BackModel)
      {
        IEnumerable<Step> source2 = wfInstalled.Steps.Where<Step>((Func<Step, bool>) (p => p.ID == task.PrevStepID));
        dictionary.Add(Guid.Empty, source2.Count<Step>() > 0 ? source2.First<Step>().Name + "(" + task.SenderName + ")" : task.SenderName);
        return dictionary;
      }
      switch (backType)
      {
        case 0:
          if (task != null)
          {
            if (step.Behavior.Countersignature != 0)
            {
              using (List<Step>.Enumerator enumerator = this.bWorkFlow.GetPrevSteps(task.FlowID, step.ID).GetEnumerator())
              {
                while (enumerator.MoveNext())
                {
                  Step current = enumerator.Current;
                  dictionary.Add(current.ID, current.Name);
                }
                break;
              }
            }
            else
            {
              dictionary.Add(task.PrevStepID, this.bWorkFlow.GetStepName(task.PrevStepID, wfInstalled, false));
              break;
            }
          }
          else
            break;
        case 1:
          dictionary.Add(wfInstalled.FirstStepID, this.bWorkFlow.GetStepName(wfInstalled.FirstStepID, wfInstalled, false));
          break;
        case 2:
          if (step.Behavior.BackType == 2 && step.Behavior.BackStepID != Guid.Empty)
          {
            dictionary.Add(step.Behavior.BackStepID, this.bWorkFlow.GetStepName(step.Behavior.BackStepID, wfInstalled, false));
            break;
          }
          if (task != null)
          {
            using (IEnumerator<RoadFlow.Data.Model.WorkFlowTask> enumerator = this.GetTaskList(task.FlowID, task.GroupID).Where<RoadFlow.Data.Model.WorkFlowTask>((Func<RoadFlow.Data.Model.WorkFlowTask, bool>) (p => p.Status.In(2, 3, 4))).OrderBy<RoadFlow.Data.Model.WorkFlowTask, int>((Func<RoadFlow.Data.Model.WorkFlowTask, int>) (p => p.Sort)).OrderByDescending<RoadFlow.Data.Model.WorkFlowTask, DateTime?>((Func<RoadFlow.Data.Model.WorkFlowTask, DateTime?>) (p => p.CompletedTime1)).GetEnumerator())
            {
              while (enumerator.MoveNext())
              {
                RoadFlow.Data.Model.WorkFlowTask current = enumerator.Current;
                if (!dictionary.Keys.Contains<Guid>(current.StepID) && current.StepID != stepID)
                  dictionary.Add(current.StepID, this.bWorkFlow.GetStepName(current.StepID, wfInstalled, false));
              }
              break;
            }
          }
          else
            break;
      }
      return dictionary;
    }

    public int UpdateNextTaskStatus(Guid taskID, int status)
    {
      int num = 0;
      foreach (RoadFlow.Data.Model.WorkFlowTask task in this.GetTaskList(taskID, true))
        num += this.dataWorkFlowTask.UpdateNextTaskStatus(task.ID, status);
      return num;
    }

    public bool HasTasks(Guid flowID)
    {
      return this.dataWorkFlowTask.HasTasks(flowID);
    }

    public bool HasNoCompletedTasks(Guid flowID, Guid stepID, Guid groupID, Guid userID)
    {
      return this.dataWorkFlowTask.HasNoCompletedTasks(flowID, stepID, groupID, userID);
    }

    public string GetStatusTitle(int status)
    {
      string empty = string.Empty;
      string str;
      switch (status)
      {
        case -1:
          str = "等待中";
          break;
        case 0:
          str = "待处理";
          break;
        case 1:
          str = "处理中";
          break;
        case 2:
          str = "已完成";
          break;
        case 3:
          str = "已退回";
          break;
        case 4:
          str = "他人已处理";
          break;
        case 5:
          str = "他人已退回";
          break;
        case 6:
          str = "终止";
          break;
        case 7:
          str = "他人已终止";
          break;
        default:
          str = "其它";
          break;
      }
      return str;
    }

    public List<RoadFlow.Data.Model.WorkFlowTask> GetUserTaskList(Guid flowID, Guid stepID, Guid groupID, Guid userID)
    {
      return this.dataWorkFlowTask.GetUserTaskList(flowID, stepID, groupID, userID);
    }

    public bool HasWithdraw(Guid taskID)
    {
      RoadFlow.Data.Model.WorkFlowTask currentTask = this.Get(taskID);
      RoadFlow.Data.Model.WorkFlowTask workFlowTask1 = this.GetTaskList(taskID, true).Find((Predicate<RoadFlow.Data.Model.WorkFlowTask>) (p => p.StepSort == currentTask.StepSort + 1));
      if (workFlowTask1 != null)
        return workFlowTask1.Status == 0;
      List<RoadFlow.Data.Model.WorkFlowTask> nextTaskList = this.GetNextTaskList(taskID);
      if (nextTaskList.Count == 0)
        return false;
      foreach (RoadFlow.Data.Model.WorkFlowTask workFlowTask2 in nextTaskList)
      {
        if (workFlowTask2.Status != 0 && workFlowTask2.Status != -1)
          return false;
      }
      return true;
    }

    public bool HasWithdraw(Guid taskID, out bool isHasten)
    {
      isHasten = false;
      RoadFlow.Data.Model.WorkFlowTask currentTask = this.Get(taskID);
      RoadFlow.Data.Model.WorkFlowTask workFlowTask1 = this.GetTaskList(taskID, true).Find((Predicate<RoadFlow.Data.Model.WorkFlowTask>) (p => p.StepSort == currentTask.StepSort + 1));
      if (workFlowTask1 != null)
      {
        if (workFlowTask1.Status.In(0, 1))
          isHasten = true;
        return workFlowTask1.Status == 0;
      }
      List<RoadFlow.Data.Model.WorkFlowTask> nextTaskList = this.GetNextTaskList(taskID);
      if (nextTaskList.Count == 0)
        return false;
      foreach (RoadFlow.Data.Model.WorkFlowTask workFlowTask2 in nextTaskList)
      {
        if (workFlowTask2.Status.In(0, 1))
        {
          isHasten = true;
          break;
        }
      }
      foreach (RoadFlow.Data.Model.WorkFlowTask workFlowTask2 in nextTaskList)
      {
        if (workFlowTask2.Status != 0 && workFlowTask2.Status != -1)
          return false;
      }
      return true;
    }

    public bool WithdrawTask(Guid taskID)
    {
      RoadFlow.Data.Model.WorkFlowTask currentTask = this.Get(taskID);
      if (currentTask == null)
        return false;
      List<RoadFlow.Data.Model.WorkFlowTask> taskList = this.GetTaskList(taskID, true);
      RoadFlow.Data.Model.WorkFlowTask workFlowTask1 = taskList.Find((Predicate<RoadFlow.Data.Model.WorkFlowTask>) (p => p.StepSort == currentTask.StepSort + 1));
      if (workFlowTask1 != null)
      {
        using (TransactionScope transactionScope = new TransactionScope())
        {
          this.Completed(workFlowTask1.ID, "", false, -1, "", "");
          this.Completed(taskID, "", false, 1, "", "");
          transactionScope.Complete();
          return true;
        }
      }
      else
      {
        ShortMessage shortMessage = new ShortMessage();
        using (TransactionScope transactionScope = new TransactionScope())
        {
          foreach (RoadFlow.Data.Model.WorkFlowTask workFlowTask2 in taskList)
          {
            foreach (RoadFlow.Data.Model.WorkFlowTask nextTask in this.GetNextTaskList(workFlowTask2.ID))
            {
              if (nextTask.Status.In(-1, 0, 1, 5))
              {
                this.Delete(nextTask.ID);
                shortMessage.Delete(nextTask.ID.ToString(), 1);
              }
              if (!nextTask.SubFlowGroupID.IsNullOrEmpty())
              {
                string subFlowGroupId = nextTask.SubFlowGroupID;
                char[] chArray = new char[1]{ ',' };
                foreach (string str in subFlowGroupId.Split(chArray))
                  this.DeleteInstance(Guid.Empty, str.ToGuid(), false);
              }
            }
            if (workFlowTask2.ID == taskID || workFlowTask2.Status == 4)
              this.Completed(workFlowTask2.ID, "", false, 1, "", "");
          }
          transactionScope.Complete();
          return true;
        }
      }
    }

    public string DesignateTask(Guid taskID, RoadFlow.Data.Model.Users user)
    {
      RoadFlow.Data.Model.WorkFlowTask model = this.Get(taskID);
      if (model == null)
        return "未找到任务";
      if (model.Status.In(2, 3, 4, 5, 6, 7))
        return "该任务已处理";
      string receiveName = model.ReceiveName;
      model.ReceiveID = user.ID;
      model.ReceiveName = user.Name;
      model.OpenTime = new DateTime?();
      model.Status = 0;
      model.Note = string.Format("该任务由{0}指派", (object) receiveName);
      this.Update(model);
      return "指派成功";
    }

    public string BackTask(Guid taskID)
    {
      RoadFlow.Data.Model.WorkFlowTask task = this.Get(taskID);
      if (task == null)
        return "未找到任务";
      if (task.Status.In(2, 3, 4, 5, 6, 7))
        return "该任务已处理";
      if (this.wfInstalled == null)
        this.wfInstalled = this.bWorkFlow.GetWorkFlowRunModel(task.FlowID, true);
      Execute executeModel = new Execute();
      executeModel.ExecuteType = EnumType.ExecuteType.Back;
      executeModel.FlowID = task.FlowID;
      executeModel.GroupID = task.GroupID;
      executeModel.InstanceID = task.InstanceID;
      executeModel.Note = "管理员退回";
      executeModel.Sender = new Users().Get(task.ReceiveID);
      executeModel.StepID = task.StepID;
      executeModel.TaskID = task.ID;
      executeModel.Title = task.Title;
      IEnumerable<Step> source = this.wfInstalled.Steps.Where<Step>((Func<Step, bool>) (p => p.ID == task.StepID));
      if (source.Count<Step>() == 0)
        return "未找到步骤";
      if (source.First<Step>().Behavior.BackType == 2 && source.First<Step>().Behavior.BackStepID == Guid.Empty)
        return "未设置退回步骤";
      System.Collections.Generic.Dictionary<Guid, List<RoadFlow.Data.Model.Users>> dictionary = new System.Collections.Generic.Dictionary<Guid, List<RoadFlow.Data.Model.Users>>();
      foreach (KeyValuePair<Guid, string> backStep in this.GetBackSteps(taskID, source.First<Step>().Behavior.BackType, task.StepID, this.wfInstalled))
        dictionary.Add(backStep.Key, new List<RoadFlow.Data.Model.Users>());
      executeModel.Steps = dictionary;
      return this.Execute(executeModel).Messages;
    }

    public List<RoadFlow.Data.Model.WorkFlowTask> Sort(List<RoadFlow.Data.Model.WorkFlowTask> tasks)
    {
      return tasks.OrderBy<RoadFlow.Data.Model.WorkFlowTask, int>((Func<RoadFlow.Data.Model.WorkFlowTask, int>) (p => p.Sort)).ToList<RoadFlow.Data.Model.WorkFlowTask>();
    }

    public int GetTaskStatus(Guid taskID)
    {
      return this.dataWorkFlowTask.GetTaskStatus(taskID);
    }

    public bool IsExecute(Guid taskID)
    {
      return this.GetTaskStatus(taskID) <= 1;
    }

    public bool TestLineSql(Guid linkID, string table, string tablepk, string instabceID, string where)
    {
      if (instabceID.IsNullOrEmpty())
        return false;
      DBConnection dbConnection = new DBConnection();
      RoadFlow.Data.Model.DBConnection dbconn = dbConnection.Get(linkID, true);
      if (dbconn == null)
        return false;
      string sql = "SELECT * FROM " + table + " WHERE " + tablepk + "='" + instabceID + "' AND (" + where.FilterWildcard("") + ")".ReplaceSelectSql();
      if (!dbConnection.TestSql(dbconn, sql, true))
        return false;
      return dbConnection.GetDataTable(dbconn, sql, (IDataParameter[]) null).Rows.Count > 0;
    }

    public bool GetInstanceIsCompleted(Guid flowID, Guid groupID)
    {
      return this.GetTaskList(Guid.Empty, groupID).Find((Predicate<RoadFlow.Data.Model.WorkFlowTask>) (p =>
      {
        if (p.Type == 5)
          return false;
        return p.Status.In(0, 1);
      })) == null;
    }

    public List<RoadFlow.Data.Model.WorkFlowTask> GetBySubFlowGroupID(Guid subflowGroupID)
    {
      return this.dataWorkFlowTask.GetBySubFlowGroupID(subflowGroupID);
    }

    public string GetStatusListItems(string value)
    {
      StringBuilder stringBuilder = new StringBuilder();
      foreach (KeyValuePair<int, string> keyValuePair in new System.Collections.Generic.Dictionary<int, string>() { { 0, "待处理" }, { 1, "处理中" }, { 2, "已完成" }, { 3, "已退回" }, { 4, "他人已处理" }, { 5, "他人已退回" } })
        stringBuilder.AppendFormat("<option value='{0}'{1}>{2}</option>", (object) keyValuePair.Key, keyValuePair.Key.ToString() == value ? (object) "selected='selected'" : (object) "", (object) keyValuePair.Value);
      return stringBuilder.ToString();
    }

    public string GetHastenUsersCheckboxString(Guid taskID, string name, string value = "")
    {
      List<RoadFlow.Data.Model.WorkFlowTask> nextTaskList = this.GetNextTaskList(taskID);
      List<ListItem> listItemList = new List<ListItem>();
      foreach (RoadFlow.Data.Model.WorkFlowTask workFlowTask in nextTaskList)
      {
        if (workFlowTask.Status.In(0, 1))
          listItemList.Add(new ListItem(workFlowTask.ReceiveName, workFlowTask.ReceiveID.ToString())
          {
            Selected = true
          });
      }
      return Tools.GetCheckBoxString(listItemList.ToArray(), name, (value ?? "").Split(','), "validate='checkbox'");
    }

    public string EndTask(Guid taskID)
    {
      RoadFlow.Data.Model.WorkFlowTask workFlowTask = this.Get(taskID);
      if (workFlowTask == null)
        return "未找到当前任务";
      List<RoadFlow.Data.Model.WorkFlowTask> taskList = this.GetTaskList(workFlowTask.FlowID, workFlowTask.GroupID);
      using (TransactionScope transactionScope = new TransactionScope())
      {
        try
        {
          foreach (RoadFlow.Data.Model.WorkFlowTask model in taskList)
          {
            if (model.Status < 2)
            {
              model.Status = model.ID == workFlowTask.ID ? 6 : 7;
              this.Update(model);
            }
          }
          if (this.wfInstalled == null)
            this.wfInstalled = new WorkFlow().GetWorkFlowRunModel(workFlowTask.FlowID, true);
          if (this.wfInstalled.TitleField != null && this.wfInstalled.TitleField.LinkID != Guid.Empty && (!this.wfInstalled.TitleField.Table.IsNullOrEmpty() && !this.wfInstalled.TitleField.Field.IsNullOrEmpty()) && this.wfInstalled.DataBases.Count<DataBases>() > 0)
            RoadFlow.Data.Factory.Factory.GetDBHelper().Execute(string.Format("UPDATE {0} SET {1}='{2}' WHERE {3}", (object) this.wfInstalled.TitleField.Table, (object) this.wfInstalled.TitleField.Field, (object) "2", (object) string.Format("{0}='{1}'", (object) this.wfInstalled.DataBases.First<DataBases>().PrimaryKey, (object) workFlowTask.InstanceID)));
          transactionScope.Complete();
        }
        catch (Exception ex)
        {
          Log.Add(ex);
        }
      }
      return "1";
    }

    public bool GoToTask(RoadFlow.Data.Model.WorkFlowTask task, System.Collections.Generic.Dictionary<Guid, string> gotoSteps)
    {
      WorkFlowInstalled workFlowRunModel = this.bWorkFlow.GetWorkFlowRunModel(task.FlowID, true);
      if (workFlowRunModel == null)
        return false;
      using (TransactionScope transactionScope = new TransactionScope())
      {
        try
        {
          foreach (KeyValuePair<Guid, string> gotoStep in gotoSteps)
          {
            KeyValuePair<Guid, string> dict = gotoStep;
            IEnumerable<Step> source = workFlowRunModel.Steps.Where<Step>((Func<Step, bool>) (p => p.ID == dict.Key));
            if (source.Count<Step>() != 0)
            {
              Step step = source.First<Step>();
              foreach (RoadFlow.Data.Model.Users allUser in new Organize().GetAllUsers(dict.Value))
              {
                RoadFlow.Data.Model.WorkFlowTask model = new RoadFlow.Data.Model.WorkFlowTask() { Comment = "", FlowID = task.FlowID, GroupID = task.GroupID, ID = Guid.NewGuid(), InstanceID = task.InstanceID, OtherType = task.OtherType, PrevID = task.ID, PrevStepID = task.StepID, ReceiveID = allUser.ID, ReceiveName = allUser.Name, ReceiveTime = DateTimeNew.Now, SenderID = task.ReceiveID, SenderName = task.ReceiveName };
                model.SenderTime = model.ReceiveTime;
                model.Sort = task.Sort + 1;
                model.Status = 0;
                model.StepID = dict.Key;
                model.StepName = step.Name;
                model.SubFlowGroupID = task.SubFlowGroupID;
                model.Title = task.Title;
                model.Type = task.Type;
                this.Add(model);
              }
            }
          }
          task.Status = 2;
          this.Update(task);
          transactionScope.Complete();
          Log.Add("跳转了流程任务", gotoSteps.Serialize(), Log.Types.流程相关, task.Serialize(), "", (RoadFlow.Data.Model.Users) null);
          return true;
        }
        catch (Exception ex)
        {
          Log.Add(ex);
          return false;
        }
      }
    }

    public string GetDefultMember(Guid flowID, Guid stepID, Guid groupID, Guid currentStepID, string instanceid, out string selectType, out string selectRange)
    {
      string str1 = string.Empty;
      selectType = "";
      selectRange = "";
      WorkFlowInstalled workFlowRunModel = this.bWorkFlow.GetWorkFlowRunModel(flowID, true);
      if (workFlowRunModel == null)
        return str1;
      IEnumerable<Step> source = workFlowRunModel.Steps.Where<Step>((Func<Step, bool>) (p => p.ID == stepID));
      if (source.Count<Step>() == 0)
        return str1;
      Step step = source.First<Step>();
      Users users = new Users();
      if ((workFlowRunModel.Debug == 1 || workFlowRunModel.Debug == 2) && workFlowRunModel.DebugUsers.Exists((Predicate<RoadFlow.Data.Model.Users>) (p => p.ID == Users.CurrentUserID)))
      {
        str1 = "u_" + Users.CurrentUserID.ToString();
      }
      else
      {
        switch (step.Behavior.HandlerType)
        {
          case 0:
            selectType = "unit='1' dept='1' station='1' workgroup='1' user='1'";
            break;
          case 1:
            selectType = "unit='0' dept='1' station='0' workgroup='0' user='0'";
            break;
          case 2:
            selectType = "unit='0' dept='0' station='1' workgroup='0' user='0'";
            break;
          case 3:
            selectType = "unit='0' dept='0' station='0' workgroup='1' user='0'";
            break;
          case 4:
            selectType = "unit='0' dept='0' station='0' workgroup='0' user='1'";
            break;
          case 5:
            Guid firstSnderId = this.GetFirstSnderID(workFlowRunModel.ID, groupID, false);
            if (firstSnderId != Guid.Empty)
              str1 = "u_" + firstSnderId.ToString();
            if (str1.IsNullOrEmpty() && currentStepID == workFlowRunModel.FirstStepID)
            {
              str1 = "u_" + Users.CurrentUserID.ToString();
              break;
            }
            break;
          case 6:
            str1 = this.GetStepSnderIDString(flowID, currentStepID, groupID);
            if (str1.IsNullOrEmpty() && currentStepID == this.wfInstalled.FirstStepID)
            {
              str1 = "u_" + Users.CurrentUserID.ToString();
              break;
            }
            break;
          case 7:
            str1 = this.GetStepSnderIDString(workFlowRunModel.ID, step.Behavior.HandlerStepID, groupID);
            if (str1.IsNullOrEmpty() && step.Behavior.HandlerStepID == workFlowRunModel.FirstStepID)
            {
              str1 = "u_" + Users.CurrentUserID.ToString();
              break;
            }
            break;
          case 8:
            string valueField = step.Behavior.ValueField;
            if (!valueField.IsNullOrEmpty() && !instanceid.IsNullOrEmpty() && workFlowRunModel.DataBases.Count<DataBases>() > 0)
            {
              str1 = new DBConnection().GetFieldValue(valueField, workFlowRunModel.DataBases.First<DataBases>().PrimaryKey, instanceid);
              break;
            }
            break;
          case 9:
            Guid guid1 = this.GetFirstSnderID(workFlowRunModel.ID, groupID, false);
            if (guid1.IsEmptyGuid() && currentStepID == workFlowRunModel.FirstStepID)
              guid1 = Users.CurrentUserID;
            if (!guid1.IsEmptyGuid())
            {
              str1 = users.GetLeader(guid1);
              break;
            }
            break;
          case 10:
            Guid guid2 = this.GetFirstSnderID(workFlowRunModel.ID, groupID, false);
            if (guid2.IsEmptyGuid() && currentStepID == workFlowRunModel.FirstStepID)
              guid2 = Users.CurrentUserID;
            if (!guid2.IsEmptyGuid())
            {
              str1 = users.GetChargeLeader(guid2);
              break;
            }
            break;
          case 11:
            str1 = users.GetLeader(Users.CurrentUserID);
            break;
          case 12:
            str1 = users.GetChargeLeader(Users.CurrentUserID);
            break;
          case 13:
            Guid guid3 = this.GetFirstSnderID(workFlowRunModel.ID, groupID, false);
            if (guid3.IsEmptyGuid() && currentStepID == workFlowRunModel.FirstStepID)
              guid3 = Users.CurrentUserID;
            if (!guid3.IsEmptyGuid())
            {
              str1 = users.GetParentDeptLeader(guid3);
              break;
            }
            break;
          case 14:
            str1 = users.GetParentDeptLeader(Users.CurrentUserID);
            break;
          case 15:
            string str2 = this.GetStepSnderIDString(workFlowRunModel.ID, currentStepID, groupID);
            if (str2.IsNullOrEmpty() && step.Behavior.HandlerStepID == workFlowRunModel.FirstStepID)
              str2 = "u_" + Users.CurrentUserID.ToString();
            StringBuilder stringBuilder1 = new StringBuilder();
            string str3 = str2 ?? "";
            char[] chArray = new char[1]{ ',' };
            foreach (string id in str3.Split(chArray))
            {
              RoadFlow.Data.Model.Organize deptByUserId = new Users().GetDeptByUserID(Users.RemovePrefix(id).ToGuid());
              if (deptByUserId != null)
              {
                foreach (RoadFlow.Data.Model.Users allUser in new Organize().GetAllUsers(deptByUserId.ID))
                {
                  stringBuilder1.Append("u_");
                  stringBuilder1.Append((object) allUser.ID);
                  stringBuilder1.Append(",");
                }
              }
            }
            str1 = stringBuilder1.ToString().TrimEnd(',');
            break;
          case 16:
            Guid guid4 = this.GetFirstSnderID(workFlowRunModel.ID, groupID, false);
            if (guid4.IsEmptyGuid() && currentStepID == workFlowRunModel.FirstStepID)
              guid4 = Users.CurrentUserID;
            StringBuilder stringBuilder2 = new StringBuilder();
            RoadFlow.Data.Model.Organize deptByUserId1 = new Users().GetDeptByUserID(guid4);
            if (deptByUserId1 != null)
            {
              foreach (RoadFlow.Data.Model.Users allUser in new Organize().GetAllUsers(deptByUserId1.ID))
              {
                stringBuilder2.Append("u_");
                stringBuilder2.Append((object) allUser.ID);
                stringBuilder2.Append(",");
              }
            }
            str1 = stringBuilder2.ToString().TrimEnd(',');
            break;
          case 17:
            Guid guid5 = this.GetFirstSnderID(workFlowRunModel.ID, groupID, false);
            if (guid5.IsEmptyGuid() && currentStepID == workFlowRunModel.FirstStepID)
              guid5 = Users.CurrentUserID;
            str1 = new Users().GetAllParentsDeptLeader(guid5).ToArray().Join1<string>(",");
            break;
          case 18:
            str1 = new Users().GetAllParentsDeptLeader(Users.CurrentUserID).ToArray().Join1<string>(",");
            break;
        }
      }
      if (!str1.IsNullOrEmpty())
        str1 = ((IEnumerable<string>) str1.Split(',')).Distinct<string>().ToArray<string>().Join1<string>(",");
      if (step.Behavior.HandlerType.In(9, 10, 11, 12, 13, 14, 15, 16, 17, 18))
        selectRange = "rootid=\"" + str1 + "\"";
      if (str1.IsNullOrEmpty())
      {
        str1 = step.Behavior.DefaultHandler;
        if (!step.Behavior.DefaultHandlerSqlOrMethod.IsNullOrEmpty())
        {
          string str4 = step.Behavior.DefaultHandlerSqlOrMethod.Trim1();
          StringBuilder stringBuilder3 = new StringBuilder();
          if (str4.StartsWith("select", StringComparison.CurrentCultureIgnoreCase))
          {
            if (workFlowRunModel.DataBases.Count<DataBases>() > 0)
            {
              string sql = Wildcard.FilterWildcard(str4, Users.CurrentUserID.ToString(), (object) null).ReplaceSelectSql();
              DataTable dataTable = new DBConnection().GetDataTable(workFlowRunModel.DataBases.First<DataBases>().LinkID, sql, (IDataParameter[]) null);
              if (dataTable != null && dataTable.Columns.Count > 0)
              {
                foreach (DataRow row in (InternalDataCollectionBase) dataTable.Rows)
                {
                  stringBuilder3.Append(row[0].ToString());
                  stringBuilder3.Append(",");
                }
              }
            }
          }
          else
          {
            object obj = this.ExecuteFlowCustomEvent(str4, (object) new WorkFlowCustomEventParams() { FlowID = flowID, GroupID = groupID, StepID = stepID, TaskID = Guid.Empty, InstanceID = instanceid }, "");
            if (obj != null)
              stringBuilder3.Append(obj.ToString());
          }
          str1 = str1 + "," + stringBuilder3.ToString();
        }
      }
      if (str1.IsNullOrEmpty())
        return "";
      return str1.TrimStart(',').TrimEnd(',');
    }

    public RoadFlow.Data.Model.WorkFlowTask GetLastTask(Guid flowID, Guid groupID)
    {
      return this.dataWorkFlowTask.GetLastTask(flowID, groupID);
    }

    public Result AutoSubmit(Guid taskID)
    {
      return this.AutoSubmit(this.Get(taskID), false);
    }

    public Result AutoSubmit(RoadFlow.Data.Model.WorkFlowTask task, bool isExpired = false)
    {
      Result result = new Result();
      if (task == null)
      {
        result.DebugMessages = "未找到任务";
        result.IsSuccess = false;
        result.Messages = "未找到任务";
        return result;
      }
      if (!task.Status.In(-1, 0, 1))
      {
        result.DebugMessages = "任务已完成";
        result.IsSuccess = false;
        result.Messages = "任务已完成";
        return result;
      }
      WorkFlowInstalled workFlowRunModel = new WorkFlow().GetWorkFlowRunModel(task.FlowID, true);
      if (workFlowRunModel == null)
      {
        result.DebugMessages = "未找到流程运行时";
        result.IsSuccess = false;
        result.Messages = "未找到流程运行时";
        return result;
      }
      IEnumerable<Step> source1 = workFlowRunModel.Steps.Where<Step>((Func<Step, bool>) (p => p.ID == task.StepID));
      if (source1.Count<Step>() == 0)
      {
        result.DebugMessages = "未找到当前步骤";
        result.IsSuccess = false;
        result.Messages = "未找到当前步骤";
        return result;
      }
      Step currentStep = source1.First<Step>();
      Execute executeModel = new Execute();
      List<Step> nextSteps = this.bWorkFlow.GetNextSteps(task.FlowID, task.StepID);
      WorkFlowTask workFlowTask = new WorkFlowTask();
      Users users = new Users();
      Organize organize = new Organize();
      if (currentStep.Behavior.FlowType == 0 && nextSteps.Count<Step>() > 0 && task.Type != 7)
      {
        List<Guid> guidList = new List<Guid>();
        WorkFlowCustomEventParams customEventParams = new WorkFlowCustomEventParams();
        customEventParams.FlowID = task.FlowID;
        customEventParams.GroupID = task.GroupID;
        customEventParams.StepID = currentStep.ID;
        customEventParams.TaskID = task.ID;
        customEventParams.InstanceID = task.InstanceID;
        StringBuilder stringBuilder1 = new StringBuilder();
        foreach (Step step1 in nextSteps)
        {
          Step step = step1;
          IEnumerable<Line> source2 = this.wfInstalled.Lines.Where<Line>((Func<Line, bool>) (p =>
          {
            if (p.ToID == step.ID)
              return p.FromID == currentStep.ID;
            return false;
          }));
          if (source2.Count<Line>() > 0)
          {
            Line line = source2.First<Line>();
            if (!line.SqlWhere.IsNullOrEmpty())
            {
              if (this.wfInstalled.DataBases.Count<DataBases>() == 0)
                guidList.Add(step.ID);
              else if (!workFlowTask.TestLineSql(this.wfInstalled.DataBases.First<DataBases>().LinkID, this.wfInstalled.DataBases.First<DataBases>().Table, this.wfInstalled.DataBases.First<DataBases>().PrimaryKey, task.InstanceID, line.SqlWhere))
                guidList.Add(step.ID);
            }
            if (!line.CustomMethod.IsNullOrEmpty())
            {
              object obj = workFlowTask.ExecuteFlowCustomEvent(line.CustomMethod.Trim(), (object) customEventParams, "");
              Type type1 = obj.GetType();
              Type type2 = typeof (bool);
              if (type1 != type2 && "1" != obj.ToString())
              {
                guidList.Add(step.ID);
                stringBuilder1.Append(obj.ToString());
                stringBuilder1.Append("\\n");
              }
              else if (type1 == type2 && !(bool) obj)
              {
                guidList.Add(step.ID);
                stringBuilder1.Append(obj.ToString());
                stringBuilder1.Append("\\n");
              }
            }
            Guid currentUserId = Users.CurrentUserID;
            Guid empty = Guid.Empty;
            Guid guid = !(currentStep.ID == this.wfInstalled.FirstStepID) ? workFlowTask.GetFirstSnderID(customEventParams.FlowID, customEventParams.GroupID, false) : currentUserId;
            StringBuilder stringBuilder2 = new StringBuilder();
            if (!line.Organize.IsNullOrEmpty())
            {
              JsonData jsonData1 = JsonMapper.ToObject(line.Organize);
              foreach (JsonData jsonData2 in (IEnumerable) jsonData1)
              {
                if (jsonData1.Count != 0)
                {
                  string str1 = jsonData2["usertype"].ToString();
                  string str2 = jsonData2.ContainsKey("in1") ? jsonData2["in1"].ToString() : "";
                  string str3 = jsonData2["users"].ToString();
                  string str4 = jsonData2["selectorganize"].ToString();
                  string str5 = jsonData2["tjand"].ToString();
                  string str6 = jsonData2["khleft"].ToString();
                  string str7 = jsonData2["khright"].ToString();
                  Guid userID = "0" == str1 ? currentUserId : guid;
                  string memberString = "";
                  bool flag = false;
                  if ("0" == str3)
                    memberString = str4;
                  else if ("1" == str3)
                    memberString = users.GetLeader(userID);
                  else if ("2" == str3)
                    memberString = users.GetChargeLeader(userID);
                  if ("0" == str2)
                    flag = users.IsContains(userID, memberString);
                  else if ("1" == str2)
                    flag = !users.IsContains(userID, memberString);
                  if (!str6.IsNullOrEmpty())
                    stringBuilder2.Append(str6);
                  stringBuilder2.Append(flag ? " true " : " false ");
                  if (!str7.IsNullOrEmpty())
                    stringBuilder2.Append(str7);
                  stringBuilder2.Append(str5);
                }
              }
              object obj = Tools.ExecuteCsharpCode("bool testbool=" + stringBuilder2.ToString() + ";return testbool;");
              if (obj != null && !(bool) obj)
                guidList.Add(step.ID);
            }
          }
        }
        foreach (Guid guid in guidList)
        {
          Guid rid = guid;
          nextSteps.RemoveAll((Predicate<Step>) (p => p.ID == rid));
        }
        if (nextSteps.Count == 0)
        {
          result.DebugMessages = "后续步骤条件均不符合,任务不能提交";
          result.IsSuccess = false;
          result.Messages = "后续步骤条件均不符合,任务不能提交";
          return result;
        }
      }
      executeModel.ExecuteType = nextSteps.Count != 0 ? EnumType.ExecuteType.Submit : EnumType.ExecuteType.Completed;
      System.Collections.Generic.Dictionary<Guid, List<RoadFlow.Data.Model.Users>> dictionary = new System.Collections.Generic.Dictionary<Guid, List<RoadFlow.Data.Model.Users>>();
      foreach (Step step in nextSteps)
      {
        string selectType;
        string selectRange;
        string defultMember = this.GetDefultMember(task.FlowID, step.ID, task.GroupID, task.StepID, task.InstanceID, out selectType, out selectRange);
        if (!defultMember.IsNullOrEmpty())
        {
          List<RoadFlow.Data.Model.Users> allUsers = organize.GetAllUsers(defultMember);
          if (allUsers.Count != 0 && step.SendSetWorkTime != 1)
            dictionary.Add(step.ID, allUsers);
        }
      }
      if (dictionary.Count > 0 || nextSteps.Count == 0)
      {
        executeModel.FlowID = task.FlowID;
        executeModel.GroupID = task.GroupID;
        executeModel.InstanceID = task.InstanceID;
        executeModel.Sender = new Users().Get(task.ReceiveID);
        executeModel.StepID = task.StepID;
        executeModel.Steps = dictionary;
        executeModel.TaskID = task.ID;
        executeModel.Title = task.Title;
        executeModel.IsSign = false;
        executeModel.OtherType = 0;
        if (isExpired)
          executeModel.Note = "";
        return this.Execute(executeModel);
      }
      result.DebugMessages = "后续步骤未找到接收人";
      result.IsSuccess = false;
      result.Messages = "后续步骤未找到接收人";
      return result;
    }

    public List<Step> GetAddWriteSteps(Guid taskID)
    {
      List<Step> stepList = new List<Step>();
      RoadFlow.Data.Model.WorkFlowTask task = this.Get(taskID);
      if (task != null)
      {
        int? otherType = task.OtherType;
        if (otherType.HasValue)
        {
          otherType = task.OtherType;
          int num1 = otherType.Value.ToString().Left(1).ToInt();
          otherType = task.OtherType;
          otherType.Value.ToString().Right(1).ToInt();
          WorkFlowInstalled workFlowRunModel = new WorkFlow().GetWorkFlowRunModel(task.FlowID, true);
          int num2 = 2;
          if (num1 == num2)
          {
            List<RoadFlow.Data.Model.WorkFlowTask> nextTasks = this.GetNextTaskList(task.PrevID);
            if (nextTasks.Count > 0)
            {
              IEnumerable<Step> source = workFlowRunModel.Steps.Where<Step>((Func<Step, bool>) (p => p.ID == nextTasks.FirstOrDefault<RoadFlow.Data.Model.WorkFlowTask>().StepID));
              if (source.Count<Step>() > 0)
                stepList.Add(source.FirstOrDefault<Step>());
            }
          }
          else
          {
            IEnumerable<Step> source = workFlowRunModel.Steps.Where<Step>((Func<Step, bool>) (p => p.ID == task.StepID));
            if (source.Count<Step>() > 0)
              stepList.Add(source.FirstOrDefault<Step>());
          }
          return stepList;
        }
      }
      return stepList;
    }

    public string GetAddWriteMembers(Guid taskID)
    {
      RoadFlow.Data.Model.WorkFlowTask task = this.Get(taskID);
      if (task == null || !task.OtherType.HasValue)
        return "";
      string str = string.Empty;
      int? otherType = task.OtherType;
      int num1 = otherType.Value;
      int num2 = num1.ToString().Left(1).ToInt();
      otherType = task.OtherType;
      num1 = otherType.Value;
      if (num1.ToString().Right(1).ToInt() == 3)
      {
        IOrderedEnumerable<RoadFlow.Data.Model.WorkFlowTask> source = this.GetTaskList(task.FlowID, task.StepID, task.GroupID).FindAll((Predicate<RoadFlow.Data.Model.WorkFlowTask>) (p =>
        {
          if (!(p.PrevID == task.PrevID) || p.Type != 7 || !(p.ID != task.ID))
            return false;
          return p.Status.In(-1, 0, 1);
        })).OrderBy<RoadFlow.Data.Model.WorkFlowTask, DateTime>((Func<RoadFlow.Data.Model.WorkFlowTask, DateTime>) (p => p.ReceiveTime));
        if (source.Count<RoadFlow.Data.Model.WorkFlowTask>() > 0)
          str = "u_" + source.FirstOrDefault<RoadFlow.Data.Model.WorkFlowTask>().ReceiveID.ToString();
      }
      if (str.IsNullOrEmpty())
      {
        switch (num2)
        {
          case 1:
            str = "u_" + task.SenderID.ToString();
            break;
          case 2:
            List<RoadFlow.Data.Model.WorkFlowTask> all = this.GetNextTaskList(task.PrevID).FindAll((Predicate<RoadFlow.Data.Model.WorkFlowTask>) (p => p.StepID != task.StepID));
            StringBuilder stringBuilder = new StringBuilder();
            foreach (RoadFlow.Data.Model.WorkFlowTask workFlowTask in all)
            {
              stringBuilder.Append("u_" + workFlowTask.ReceiveID.ToString());
              stringBuilder.Append(",");
            }
            str = stringBuilder.ToString().TrimEnd(',');
            break;
          case 3:
            str = "u_" + task.SenderID.ToString();
            break;
        }
      }
      return str;
    }

    public bool AddWrite(Guid taskID, int addType, int writeType, string writeUsers, string note, out string msg)
    {
      WorkFlowTask workFlowTask1 = new WorkFlowTask();
      Organize organize = new Organize();
      msg = "";
      RoadFlow.Data.Model.WorkFlowTask workFlowTask2 = workFlowTask1.Get(taskID);
      if (workFlowTask2 == null)
      {
        msg = "未找到当前任务,不能加签!";
        return false;
      }
      List<RoadFlow.Data.Model.Users> allUsers = organize.GetAllUsers(writeUsers);
      int num = 0;
      foreach (RoadFlow.Data.Model.Users users in allUsers)
      {
        RoadFlow.Data.Model.WorkFlowTask model = new RoadFlow.Data.Model.WorkFlowTask() { FlowID = workFlowTask2.FlowID, GroupID = workFlowTask2.GroupID, ID = Guid.NewGuid(), InstanceID = workFlowTask2.InstanceID, Note = note, PrevID = workFlowTask2.ID, PrevStepID = workFlowTask2.PrevStepID, ReceiveID = users.ID, ReceiveName = users.Name, SenderTime = DateTimeNew.Now };
        model.ReceiveTime = model.SenderTime.AddSeconds((double) num++);
        model.SenderID = workFlowTask2.ReceiveID;
        model.SenderName = workFlowTask2.ReceiveName;
        model.Sort = workFlowTask2.Sort + 1;
        model.StepID = workFlowTask2.StepID;
        model.StepName = workFlowTask2.StepName;
        model.Title = workFlowTask2.Title;
        model.OtherType = new int?((addType.ToString() + writeType.ToString()).ToInt());
        model.Type = 7;
        model.Status = addType == 1 && writeType == 3 && users.ID != allUsers.FirstOrDefault<RoadFlow.Data.Model.Users>().ID || addType == 2 ? -1 : 0;
        if (!this.HasNoCompletedTasks(workFlowTask2.FlowID, workFlowTask2.StepID, workFlowTask2.GroupID, users.ID))
          workFlowTask1.Add(model);
      }
      if (addType == 1)
      {
        foreach (RoadFlow.Data.Model.WorkFlowTask task in workFlowTask1.GetTaskList(taskID, true))
        {
          task.Status = -1;
          workFlowTask1.Update(task);
        }
      }
      return true;
    }

    public void ExpiredAutoSubmit()
    {
      List<RoadFlow.Data.Model.WorkFlowTask> expiredAutoSubmitTasks = this.dataWorkFlowTask.GetExpiredAutoSubmitTasks();
      WorkFlowTask workFlowTask = new WorkFlowTask();
      foreach (RoadFlow.Data.Model.WorkFlowTask task in expiredAutoSubmitTasks)
      {
        try
        {
          workFlowTask.AutoSubmit(task, true);
        }
        catch (Exception ex)
        {
          Log.Add(ex);
        }
      }
    }

    public List<RoadFlow.Data.Model.Users> GetCopyForUsers(CopyFor copyFor, RoadFlow.Data.Model.WorkFlowTask currentTask)
    {
      List<RoadFlow.Data.Model.Users> source = new List<RoadFlow.Data.Model.Users>();
      if (copyFor == null)
        return source;
      Organize organize = new Organize();
      Users users = new Users();
      if (!copyFor.MemberID.IsNullOrEmpty())
        source.AddRange((IEnumerable<RoadFlow.Data.Model.Users>) organize.GetAllUsers(copyFor.MemberID));
      if (!copyFor.MethodOrSql.IsNullOrEmpty())
      {
        WorkFlowInstalled workFlowRunModel = this.bWorkFlow.GetWorkFlowRunModel(currentTask.FlowID, true);
        string str = copyFor.MethodOrSql.Trim1();
        StringBuilder stringBuilder = new StringBuilder();
        if (str.StartsWith("select", StringComparison.CurrentCultureIgnoreCase))
        {
          if (workFlowRunModel.DataBases.Count<DataBases>() > 0)
          {
            string sql = Wildcard.FilterWildcard(str, Users.CurrentUserID.ToString(), (object) null).ReplaceSelectSql();
            DataTable dataTable = new DBConnection().GetDataTable(workFlowRunModel.DataBases.First<DataBases>().LinkID, sql, (IDataParameter[]) null);
            if (dataTable != null && dataTable.Columns.Count > 0)
            {
              foreach (DataRow row in (InternalDataCollectionBase) dataTable.Rows)
              {
                stringBuilder.Append(row[0].ToString());
                stringBuilder.Append(",");
              }
            }
          }
        }
        else
        {
          object obj = this.ExecuteFlowCustomEvent(str, (object) new WorkFlowCustomEventParams() { FlowID = currentTask.FlowID, GroupID = currentTask.GroupID, StepID = currentTask.StepID, TaskID = currentTask.ID, InstanceID = currentTask.InstanceID }, "");
          if (obj != null)
            stringBuilder.Append(obj.ToString());
        }
        source.AddRange((IEnumerable<RoadFlow.Data.Model.Users>) organize.GetAllUsers(stringBuilder.ToString()));
      }
      if (!copyFor.handlerType.IsNullOrEmpty())
      {
        string handlerType = copyFor.handlerType;
        string[] separator = new string[1]{ "," };
        int num = 1;
        foreach (string str in handlerType.Split(separator, (StringSplitOptions) num))
        {
          switch (str.ToInt())
          {
            case 0:
              source.Add(users.Get(this.GetFirstSnderID(currentTask.FlowID, currentTask.GroupID, false)));
              break;
            case 1:
              source.AddRange((IEnumerable<RoadFlow.Data.Model.Users>) organize.GetAllUsers(this.GetStepSnderIDString(currentTask.FlowID, currentTask.PrevStepID, currentTask.GroupID)));
              break;
            case 2:
              source.AddRange((IEnumerable<RoadFlow.Data.Model.Users>) organize.GetAllUsers(users.GetLeader(this.GetFirstSnderID(currentTask.FlowID, currentTask.GroupID, false))));
              break;
            case 3:
              source.AddRange((IEnumerable<RoadFlow.Data.Model.Users>) organize.GetAllUsers(users.GetChargeLeader(this.GetFirstSnderID(currentTask.FlowID, currentTask.GroupID, false))));
              break;
            case 4:
              source.AddRange((IEnumerable<RoadFlow.Data.Model.Users>) organize.GetAllUsers(users.GetParentDeptLeader(this.GetFirstSnderID(currentTask.FlowID, currentTask.GroupID, false))));
              break;
            case 5:
              RoadFlow.Data.Model.Organize deptByUserId = users.GetDeptByUserID(this.GetFirstSnderID(currentTask.FlowID, currentTask.GroupID, false));
              source.AddRange((IEnumerable<RoadFlow.Data.Model.Users>) organize.GetAllUsers(deptByUserId.ID));
              break;
            case 6:
              source.AddRange((IEnumerable<RoadFlow.Data.Model.Users>) organize.GetAllUsers(users.GetAllParentsDeptLeader(this.GetFirstSnderID(currentTask.FlowID, currentTask.GroupID, false)).ToArray().Join1<string>(",")));
              break;
            case 7:
              source.AddRange((IEnumerable<RoadFlow.Data.Model.Users>) organize.GetAllUsers(users.GetLeader(Users.CurrentUserID)));
              break;
            case 8:
              source.AddRange((IEnumerable<RoadFlow.Data.Model.Users>) organize.GetAllUsers(users.GetChargeLeader(Users.CurrentUserID)));
              break;
            case 9:
              source.AddRange((IEnumerable<RoadFlow.Data.Model.Users>) organize.GetAllUsers(users.GetParentDeptLeader(Users.CurrentUserID)));
              break;
            case 10:
              source.AddRange((IEnumerable<RoadFlow.Data.Model.Users>) organize.GetAllUsers(Users.CurrentDeptID));
              break;
          }
        }
      }
      if (!copyFor.steps.IsNullOrEmpty())
      {
        string steps = copyFor.steps;
        string[] separator = new string[1]{ "," };
        int num = 1;
        foreach (string str in steps.Split(separator, (StringSplitOptions) num))
          source.AddRange((IEnumerable<RoadFlow.Data.Model.Users>) organize.GetAllUsers(this.GetStepSnderIDString(currentTask.FlowID, str.ToGuid(), currentTask.GroupID)));
      }
      source.Distinct<RoadFlow.Data.Model.Users>((IEqualityComparer<RoadFlow.Data.Model.Users>) new UsersEqualityComparer());
      return source;
    }
  }
}
