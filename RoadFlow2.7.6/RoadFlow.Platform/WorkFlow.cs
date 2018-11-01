// Decompiled with JetBrains decompiler
// Type: RoadFlow.Platform.WorkFlow
// Assembly: RoadFlow.Platform, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 07F26AFD-DE3B-4003-89AF-01A62494BA58
// Assembly location: C:\inetpub\wwwroot\RoadFlowMvc\bin\RoadFlow.Platform.dll

using LitJson;
using MySql.Data.MySqlClient;
using Oracle.ManagedDataAccess.Client;
using RoadFlow.Cache.IO;
using RoadFlow.Data.Interface;
using RoadFlow.Data.Model;
using RoadFlow.Data.Model.WorkFlowInstalledSub;
using RoadFlow.Data.Model.WorkFlowInstalledSub.StepSet;
using RoadFlow.Utility;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Transactions;
using System.Web;
using System.Web.UI.WebControls;
using System.Xml.Linq;

namespace RoadFlow.Platform
{
    public class WorkFlow
    {
        private IWorkFlow dataWorkFlow;

        public WorkFlow()
        {
            this.dataWorkFlow = RoadFlow.Data.Factory.Factory.GetWorkFlow();
        }

        public int Add(RoadFlow.Data.Model.WorkFlow model)
        {
            return this.dataWorkFlow.Add(model);
        }

        public int Update(RoadFlow.Data.Model.WorkFlow model)
        {
            return this.dataWorkFlow.Update(model);
        }

        public List<RoadFlow.Data.Model.WorkFlow> GetAll()
        {
            return this.dataWorkFlow.GetAll();
        }

        public RoadFlow.Data.Model.WorkFlow Get(Guid id)
        {
            return this.dataWorkFlow.Get(id);
        }

        public int Delete(Guid id)
        {
            return this.dataWorkFlow.Delete(id);
        }

        public long GetCount()
        {
            return this.dataWorkFlow.GetCount();
        }

        public List<string> GetAllTypes()
        {
            return this.dataWorkFlow.GetAllTypes();
        }

        public string GetAllTypesOptions(string value = "")
        {
            List<string> allTypes = this.GetAllTypes();
            StringBuilder stringBuilder = new StringBuilder();
            foreach (string str in allTypes)
                stringBuilder.AppendFormat("<option value=\"{0}\" {1}>{0}</option>", (object)str, str == value ? (object)"selected=\"selected\"" : (object)"");
            return stringBuilder.ToString();
        }

        public string GetStatusTitle(int status)
        {
            string str = string.Empty;
            switch (status)
            {
                case 1:
                    str = "设计中";
                    break;
                case 2:
                    str = "已安装";
                    break;
                case 3:
                    str = "已卸载";
                    break;
                case 4:
                    str = "已删除";
                    break;
                case 5:
                    str = "等待他人处理";
                    break;
            }
            return str;
        }

        public string SaveFlow(string jsonString)
        {
            //      JsonData jsonData = JsonMapper.ToObject(jsonString);
            //      string str1 = jsonData["id"].ToString();
            //      string str2 = jsonData["name"].ToString();
            //      string str3 = jsonData["type"].ToString();
            //      Guid id;
            //ref Guid local = ref id;
            //      if (!str1.IsGuid(out local))
            //          return "请先新建或打开流程!";
            //      if (str2.IsNullOrEmpty())
            //          return "流程名称不能为空!";
            //      WorkFlow workFlow = new WorkFlow();
            //      RoadFlow.Data.Model.WorkFlow model = workFlow.Get(id);
            //      bool flag = false;
            //      if (model == null)
            //      {
            //          model = new RoadFlow.Data.Model.WorkFlow();
            //          flag = true;
            //          model.ID = id;
            //          model.CreateDate = DateTimeNew.Now;
            //          model.CreateUserID = Users.CurrentUserID;
            //          model.Status = 1;
            //      }
            //      model.DesignJSON = jsonString;
            //      model.InstanceManager = jsonData["instanceManager"].ToString();
            //      model.Manager = jsonData["manager"].ToString();
            //      model.Name = str2.Trim();
            //      model.Type = str3.IsGuid() ? str3.ToGuid() : new Dictionary().GetIDByCode("FlowTypes");
            //      try
            //      {
            //          if (flag)
            //              workFlow.Add(model);
            //          else
            //              workFlow.Update(model);
            //          this.ClaearCache();
            //          return "1";
            //      }
            //      catch (Exception ex)
            //      {
            //          this.ClaearCache();
            //          return ex.Message;
            //      }
            JsonData jsonData = JsonMapper.ToObject(jsonString);
            string text = jsonData["id"].ToString();
            string text2 = jsonData["name"].ToString();
            string text3 = jsonData["type"].ToString();
            Guid guid = default(Guid);
            if (!global::MyExtensions.IsGuid(text, out guid))
            {
                return "请先新建或打开流程!";
            }
            if (!global::MyExtensions.IsNullOrEmpty(text2))
            {
                RoadFlow.Platform.WorkFlow workFlow = new RoadFlow.Platform.WorkFlow();
                RoadFlow.Data.Model.WorkFlow workFlow2 = workFlow.Get(guid);
                bool flag = false;
                if (workFlow2 == null)
                {
                    workFlow2 = new RoadFlow.Data.Model.WorkFlow();
                    flag = true;
                    workFlow2.ID = guid;
                    workFlow2.CreateDate = DateTimeNew.Now;
                    workFlow2.CreateUserID = RoadFlow.Platform.Users.CurrentUserID;
                    workFlow2.Status = 1;
                }
                workFlow2.DesignJSON = jsonString;
                workFlow2.InstanceManager = jsonData["instanceManager"].ToString();
                workFlow2.Manager = jsonData["manager"].ToString();
                workFlow2.Name = text2.Trim();
                workFlow2.Type = (global::MyExtensions.IsGuid(text3) ? global::MyExtensions.ToGuid(text3) : new RoadFlow.Platform.Dictionary().GetIDByCode("FlowTypes"));
                try
                {
                    if (flag)
                    {
                        workFlow.Add(workFlow2);
                    }
                    else
                    {
                        workFlow.Update(workFlow2);
                    }
                    ClaearCache();
                    return "1";
                }
                catch (Exception ex)
                {
                    ClaearCache();
                    return ex.Message;
                }
            }
            return "流程名称不能为空!";
        }

        public string InstallFlow(string jsonString, bool isMvc = true)
        {
            string str = this.SaveFlow(jsonString);
            if ("1" != str)
                return str;
            string errMsg;
            WorkFlowInstalled workFlowRunModel = this.GetWorkFlowRunModel(jsonString, out errMsg);
            if (workFlowRunModel == null)
                return errMsg;
            RoadFlow.Data.Model.WorkFlow model1 = this.dataWorkFlow.Get(workFlowRunModel.ID);
            if (model1 == null)
                return "流程实体为空";
            using (TransactionScope transactionScope = new TransactionScope())
            {
                model1.InstallDate = new DateTime?(workFlowRunModel.InstallTime);
                model1.InstallUserID = new Guid?(workFlowRunModel.InstallUser.ToGuid());
                model1.RunJSON = workFlowRunModel.RunJSON;
                model1.Status = 2;
                this.dataWorkFlow.Update(model1);
                workFlowRunModel.Status = 2;
                AppLibrary appLibrary = new AppLibrary();
                RoadFlow.Data.Model.AppLibrary model2 = appLibrary.GetByCode(workFlowRunModel.ID.ToString(), true);
                bool flag = false;
                if (model2 == null)
                {
                    flag = true;
                    model2 = new RoadFlow.Data.Model.AppLibrary();
                    model2.ID = Guid.NewGuid();
                }
                model2.Address = isMvc ? "/WorkFlowRun/Index" : "/Platform/WorkFlowRun/Default.aspx";
                model2.Code = workFlowRunModel.ID.ToString();
                model2.Note = "流程应用";
                model2.OpenMode = 0;
                model2.Params = "flowid=" + workFlowRunModel.ID.ToString();
                model2.Title = workFlowRunModel.Name;
                model2.Type = workFlowRunModel.Type.IsGuid() ? workFlowRunModel.Type.ToGuid() : new Dictionary().GetIDByCode("FlowTypes");
                if (flag)
                    appLibrary.Add(model2);
                else
                    appLibrary.Update(model2);
                appLibrary.ClearCache();
                Opation.Set(this.getCacheKey(workFlowRunModel.ID), (object)workFlowRunModel);
                this.ClearStartFlowsCache();
                this.ClaearCache();
                transactionScope.Complete();
                return "1";
            }
        }

        public RoadFlow.Data.Model.WorkFlow SaveAs(Guid flowID, string newName)
        {
            RoadFlow.Data.Model.WorkFlow model = this.dataWorkFlow.Get(flowID);
            if (model == null || newName.IsNullOrEmpty())
                return model;
            model.ID = Guid.NewGuid();
            model.Name = newName.Trim();
            model.CreateDate = DateTimeNew.Now;
            model.CreateUserID = Users.CurrentUserID;
            model.InstallDate = new DateTime?();
            model.InstallUserID = new Guid?();
            model.RunJSON = (string)null;
            model.Status = 1;
            if (!model.DesignJSON.IsNullOrEmpty())
            {
                JsonData jsonData1 = JsonMapper.ToObject(model.DesignJSON);
                JsonData jsonData2 = jsonData1;
                string index = "id";
                Guid guid = model.ID;
                JsonData jsonData3 = (JsonData)guid.ToString();
                jsonData2[index] = jsonData3;
                jsonData1["name"] = (JsonData)model.Name;
                JsonData jsonData4 = jsonData1["steps"];
                JsonData jsonData5 = jsonData1["lines"];
                foreach (JsonData jsonData6 in (IEnumerable)jsonData4)
                {
                    string str1 = jsonData6["id"].ToString();
                    guid = Guid.NewGuid();
                    string str2 = guid.ToString();
                    jsonData6["id"] = (JsonData)str2;
                    foreach (JsonData jsonData7 in (IEnumerable)jsonData5)
                    {
                        if (jsonData7["from"].ToString() == str1)
                            jsonData7["from"] = (JsonData)str2;
                        if (jsonData7["to"].ToString() == str1)
                            jsonData7["to"] = (JsonData)str2;
                    }
                }
                foreach (JsonData jsonData6 in (IEnumerable)jsonData5)
                    jsonData6["id"] = (JsonData)Guid.NewGuid().ToString();
                model.DesignJSON = jsonData1.ToJson(true);
            }
            this.dataWorkFlow.Add(model);
            this.ClaearCache();
            return model;
        }

        private string getCacheKey(Guid flowID)
        {
            return Keys.CacheKeys.WorkFlowInstalled_.ToString() + flowID.ToString("N");
        }

        public WorkFlowInstalled GetWorkFlowRunModel(string flowID, bool cache = true)
        {
            Guid test;
            if (!flowID.IsGuid(out test))
                return (WorkFlowInstalled)null;
            return this.GetWorkFlowRunModel(test, cache);
        }

        public WorkFlowInstalled GetWorkFlowRunModel(Guid flowID, bool cache = true)
        {
            if (!cache)
                return this.getWorkFlowRunFromDesign(flowID);
            WorkFlowInstalled workFlowInstalled = (WorkFlowInstalled)null;
            string cacheKey = this.getCacheKey(flowID);
            try
            {
                object obj = Opation.Get(cacheKey);
                if (obj != null)
                    workFlowInstalled = (WorkFlowInstalled)obj;
            }
            catch (Exception ex)
            {
                workFlowInstalled = (WorkFlowInstalled)null;
                Log.Add(ex);
            }
            if (workFlowInstalled == null)
            {
                workFlowInstalled = this.getWorkFlowRunFromDesign(flowID);
                Opation.Set(cacheKey, (object)workFlowInstalled);
            }
            return workFlowInstalled;
        }

        private WorkFlowInstalled getWorkFlowRunFromDesign(Guid flowID)
        {
            RoadFlow.Data.Model.WorkFlow workFlow = this.GetFromCache(flowID) ?? this.Get(flowID);
            if (workFlow == null || workFlow.RunJSON.IsNullOrEmpty())
                return (WorkFlowInstalled)null;
            string errMsg;
            return this.GetWorkFlowRunModel(workFlow.RunJSON, out errMsg);
        }

        public void ClearWorkFlowCache(Guid flowID)
        {
            Opation.Remove(this.getCacheKey(flowID));
        }

        public void RefreshWrokFlowCache(Guid flowID)
        {
            Opation.Set(this.getCacheKey(flowID), (object)this.GetWorkFlowRunModel(flowID, false));
        }

        public RoadFlow.Data.Model.WorkFlow GetFromCache(Guid flowID)
        {
            return this.GetAllFromCache().Find((Predicate<RoadFlow.Data.Model.WorkFlow>)(p => p.ID == flowID));
        }

        public List<RoadFlow.Data.Model.WorkFlow> GetAllFromCache()
        {
            List<RoadFlow.Data.Model.WorkFlow> workFlowList = (List<RoadFlow.Data.Model.WorkFlow>)null;
            string key = Keys.CacheKeys.WorkFlowInstalled_.ToString();
            object obj = Opation.Get(key);
            if (obj != null)
            {
                try
                {
                    workFlowList = (List<RoadFlow.Data.Model.WorkFlow>)obj;
                }
                catch
                {
                    workFlowList = (List<RoadFlow.Data.Model.WorkFlow>)null;
                }
            }
            if (workFlowList == null)
            {
                workFlowList = this.GetAll();
                Opation.Set(key, (object)workFlowList);
            }
            return workFlowList;
        }

        public void ClaearCache()
        {
            Opation.Remove(Keys.CacheKeys.WorkFlowInstalled_.ToString());
        }

        public WorkFlowInstalled GetWorkFlowRunModel(string jsonString, out string errMsg)
        {
            errMsg = "";
            WorkFlowInstalled workFlowInstalled = new WorkFlowInstalled();
            JsonData jsonData1 = JsonMapper.ToObject(jsonString);
            string str1 = jsonData1["id"].ToString();
            if (!str1.IsGuid())
            {
                errMsg = "流程ID错误";
                return (WorkFlowInstalled)null;
            }
            workFlowInstalled.ID = str1.ToGuid();
            string str2 = jsonData1["name"].ToString();
            if (str2.IsNullOrEmpty())
            {
                errMsg = "流程名称为空";
                return (WorkFlowInstalled)null;
            }
            workFlowInstalled.Name = str2.Trim();
            string str3 = jsonData1["type"].ToString();
            workFlowInstalled.Type = str3.IsNullOrEmpty() ? new Dictionary().GetIDByCode("FlowTypes").ToString() : str3.Trim();
            string str4 = jsonData1["manager"].ToString();
            if (str4.IsNullOrEmpty())
            {
                errMsg = "流程管理者为空";
                return (WorkFlowInstalled)null;
            }
            workFlowInstalled.Manager = str4;
            string str5 = jsonData1["instanceManager"].ToString();
            if (str5.IsNullOrEmpty())
            {
                errMsg = "流程实例管理者为空";
                return (WorkFlowInstalled)null;
            }
            workFlowInstalled.InstanceManager = str5;
            workFlowInstalled.RemoveCompleted = jsonData1["removeCompleted"].ToString().ToInt();
            workFlowInstalled.Debug = jsonData1["debug"].ToString().ToInt();
            workFlowInstalled.DebugUsers = new Organize().GetAllUsers(jsonData1["debugUsers"].ToString());
            workFlowInstalled.Note = jsonData1["note"].ToString();
            workFlowInstalled.FlowType = jsonData1.ContainsKey("flowType") ? jsonData1["flowType"].ToString().ToInt() : 0;
            List<DataBases> dataBasesList = new List<DataBases>();
            JsonData jsonData2 = jsonData1["databases"];
            if (jsonData2.IsArray)
            {
                foreach (JsonData jsonData3 in (IEnumerable)jsonData2)
                    dataBasesList.Add(new DataBases()
                    {
                        LinkID = jsonData3["link"].ToString().ToGuid(),
                        LinkName = jsonData3["linkName"].ToString(),
                        Table = jsonData3["table"].ToString(),
                        PrimaryKey = jsonData3["primaryKey"].ToString()
                    });
            }
            workFlowInstalled.DataBases = (IEnumerable<DataBases>)dataBasesList;
            JsonData jsonData4 = jsonData1["titleField"];
            if (jsonData4.IsObject)
                workFlowInstalled.TitleField = new TitleField()
                {
                    Field = jsonData4["field"].ToString(),
                    LinkID = jsonData4["link"].ToString().ToGuid(),
                    LinkName = "",
                    Table = jsonData4["table"].ToString()
                };
            List<Step> stepList = new List<Step>();
            JsonData jsonData5 = jsonData1["steps"];
            if (jsonData5.IsArray)
            {
                foreach (JsonData jsonData3 in (IEnumerable)jsonData5)
                {
                    JsonData jsonData6 = jsonData3["behavior"];
                    Behavior behavior = new Behavior();
                    if (jsonData6.IsObject)
                    {
                        behavior.BackModel = jsonData6["backModel"].ToString().ToInt();
                        behavior.BackStepID = jsonData6["backStep"].ToString().ToGuid();
                        behavior.BackType = jsonData6["backType"].ToString().ToInt();
                        behavior.DefaultHandler = jsonData6["defaultHandler"].ToString();
                        behavior.FlowType = jsonData6["flowType"].ToString().ToInt();
                        behavior.HandlerStepID = jsonData6["handlerStep"].ToString().ToGuid();
                        behavior.HandlerType = jsonData6["handlerType"].ToString().ToInt();
                        behavior.HanlderModel = jsonData6["hanlderModel"].ToString().ToInt(3);
                        behavior.Percentage = jsonData6["percentage"].ToString().IsDecimal() ? jsonData6["percentage"].ToString().ToDecimal() : Decimal.MinusOne;
                        behavior.RunSelect = jsonData6["runSelect"].ToString().ToInt();
                        behavior.SelectRange = jsonData6["selectRange"].ToString();
                        behavior.ValueField = jsonData6["valueField"].ToString();
                        behavior.Countersignature = jsonData6.ContainsKey("countersignature") ? jsonData6["countersignature"].ToString().ToInt() : 0;
                        behavior.CountersignaturePercentage = jsonData6.ContainsKey("countersignaturePercentage") ? jsonData6["countersignaturePercentage"].ToString().ToDecimal() : Decimal.MinusOne;
                        behavior.SubFlowStrategy = jsonData6.ContainsKey("subflowstrategy") ? jsonData6["subflowstrategy"].ToString().ToInt() : int.MinValue;
                        behavior.CopyFor = jsonData6.ContainsKey("copyFor") ? jsonData6["copyFor"].ToString() : "";
                        behavior.ConcurrentModel = jsonData6.ContainsKey("concurrentModel") ? jsonData6["concurrentModel"].ToString().ToInt(0) : 0;
                        behavior.DefaultHandlerSqlOrMethod = jsonData6.ContainsKey("defaultHandlerSqlOrMethod") ? jsonData6["defaultHandlerSqlOrMethod"].ToString() : "";
                    }
                    JsonData jsonData7 = jsonData3["buttons"];
                    List<RoadFlow.Data.Model.WorkFlowInstalledSub.StepSet.Button> buttonList = new List<RoadFlow.Data.Model.WorkFlowInstalledSub.StepSet.Button>();
                    if (jsonData7.IsArray)
                    {
                        foreach (JsonData jsonData8 in (IEnumerable)jsonData7)
                        {
                            string str6 = jsonData8["id"].ToString();
                            if (str6.IsGuid())
                            {
                                RoadFlow.Data.Model.WorkFlowButtons workFlowButtons = new WorkFlowButtons().Get(str6.ToGuid(), true);
                                if (workFlowButtons != null)
                                    buttonList.Add(new RoadFlow.Data.Model.WorkFlowInstalledSub.StepSet.Button()
                                    {
                                        ID = str6,
                                        Note = workFlowButtons.Note.IsNullOrEmpty() ? "" : workFlowButtons.Note.Replace("\"", "'"),
                                        Sort = jsonData8["sort"].ToString().ToInt(),
                                        ShowTitle = jsonData8.ContainsKey("showTitle") ? jsonData8["showTitle"].ToString() : ""
                                    });
                            }
                            else
                                buttonList.Add(new RoadFlow.Data.Model.WorkFlowInstalledSub.StepSet.Button()
                                {
                                    ID = str6,
                                    Note = "",
                                    Sort = jsonData8["sort"].ToString().ToInt(),
                                    ShowTitle = jsonData8.ContainsKey("showTitle") ? jsonData8["showTitle"].ToString() : ""
                                });
                        }
                    }
                    int count1 = buttonList.Count;
                    CopyFor copyFor = new CopyFor();
                    if (jsonData3.ContainsKey("copyFor"))
                    {
                        JsonData jsonData8 = jsonData3["copyFor"];
                        if (jsonData8.IsObject)
                        {
                            copyFor.handlerType = jsonData8["handlerType"].ToString();
                            copyFor.MemberID = jsonData8["memberId"].ToString();
                            copyFor.MethodOrSql = jsonData8["methodOrSql"].ToString();
                            copyFor.steps = jsonData8["steps"].ToString();
                        }
                    }
                    JsonData jsonData9 = jsonData3["event"];
                    Event @event = new Event();
                    if (jsonData9.IsObject)
                    {
                        @event.BackAfter = jsonData9["backAfter"].ToString();
                        @event.BackBefore = jsonData9["backBefore"].ToString();
                        @event.SubmitAfter = jsonData9["submitAfter"].ToString();
                        @event.SubmitBefore = jsonData9["submitBefore"].ToString();
                        @event.SubFlowActivationBefore = jsonData9.ContainsKey("subflowActivationBefore") ? jsonData9["subflowActivationBefore"].ToString() : "";
                        @event.SubFlowCompletedBefore = jsonData9.ContainsKey("subflowCompletedBefore") ? jsonData9["subflowCompletedBefore"].ToString() : "";
                    }
                    JsonData jsonData10 = jsonData3["forms"];
                    List<Form> formList = new List<Form>();
                    if (jsonData10.IsArray)
                    {
                        foreach (JsonData jsonData8 in (IEnumerable)jsonData10)
                            formList.Add(new Form()
                            {
                                ID = jsonData8["id"].ToString().ToGuid(),
                                Name = jsonData8["name"].ToString(),
                                IDApp = !jsonData8.ContainsKey("idApp") || !jsonData8["idApp"].ToString().IsGuid() ? Guid.Empty : jsonData8["idApp"].ToString().ToGuid(),
                                NameApp = jsonData8.ContainsKey("nameApp") ? jsonData8["nameApp"].ToString() : "",
                                Sort = jsonData8["srot"].ToString().ToInt()
                            });
                    }
                    int count2 = formList.Count;
                    JsonData jsonData11 = jsonData3["fieldStatus"];
                    List<FieldStatus> fieldStatusList = new List<FieldStatus>();
                    if (jsonData11.IsArray)
                    {
                        foreach (JsonData jsonData8 in (IEnumerable)jsonData11)
                            fieldStatusList.Add(new FieldStatus()
                            {
                                Check = jsonData8["check"].ToString().ToInt(),
                                Field = jsonData8["field"].ToString(),
                                Status1 = jsonData8["status"].ToString().ToInt(1)
                            });
                    }
                    JsonData jsonData12 = jsonData3["position"];
                    Decimal num1 = new Decimal();
                    Decimal num2 = new Decimal();
                    if (jsonData12.IsObject)
                    {
                        num1 = jsonData12["x"].ToString().ToDecimal();
                        num2 = jsonData12["y"].ToString().ToDecimal();
                    }
                    stepList.Add(new Step()
                    {
                        Archives = jsonData3["archives"].ToString().ToInt(),
                        ArchivesParams = jsonData3["archivesParams"].ToString(),
                        Behavior = behavior,
                        Buttons = (IEnumerable<RoadFlow.Data.Model.WorkFlowInstalledSub.StepSet.Button>)buttonList,
                        DataSaveType = jsonData3.ContainsKey("dataSaveType") ? jsonData3["dataSaveType"].ToString().ToInt(0) : 0,
                        DataSaveTypeWhere = jsonData3.ContainsKey("dataSaveTypeWhere") ? jsonData3["dataSaveTypeWhere"].ToString() : "",
                        Event = @event,
                        CopyFor = copyFor,
                        ExpiredPrompt = jsonData3["expiredPrompt"].ToString().ToInt(),
                        Forms = (IEnumerable<Form>)formList,
                        FieldStatus = (IEnumerable<FieldStatus>)fieldStatusList,
                        ID = jsonData3["id"].ToString().ToGuid(),
                        Type = jsonData3.ContainsKey("type") ? jsonData3["type"].ToString() : "normal",
                        LimitTime = jsonData3["limitTime"].ToString().ToDecimal(),
                        Name = jsonData3["name"].ToString(),
                        Note = jsonData3["note"].ToString(),
                        OpinionDisplay = jsonData3["opinionDisplay"].ToString().ToInt(),
                        OtherTime = jsonData3["otherTime"].ToString().ToDecimal(),
                        SignatureType = jsonData3["signatureType"].ToString().ToInt(),
                        WorkTime = jsonData3["workTime"].ToString().ToDecimal(),
                        SubFlowID = jsonData3.ContainsKey("subflow") ? jsonData3["subflow"].ToString() : "",
                        SubFlowTaskType = jsonData3.ContainsKey("subflowTaskType") ? jsonData3["subflowTaskType"].ToString().ToInt(0) : 0,
                        Position_x = num1,
                        Position_y = num2,
                        SendShowMsg = jsonData3.ContainsKey("sendShowMsg") ? jsonData3["sendShowMsg"].ToString() : "",
                        BackShowMsg = jsonData3.ContainsKey("backShowMsg") ? jsonData3["backShowMsg"].ToString() : "",
                        SendSetWorkTime = jsonData3.ContainsKey("sendSetWorkTime") ? jsonData3["sendSetWorkTime"].ToString().ToInt() : 0,
                        TimeOutModel = jsonData3.ContainsKey("timeOutModel") ? jsonData3["timeOutModel"].ToString().ToInt() : 0
                    });
                }
            }
            int flowType = workFlowInstalled.FlowType;
            workFlowInstalled.Steps = (IEnumerable<Step>)stepList;
            if (stepList.Count == 0)
            {
                errMsg = "流程至少需要一个步骤";
                return (WorkFlowInstalled)null;
            }
            List<Line> lineList = new List<Line>();
            JsonData jsonData13 = jsonData1.ContainsKey("lines") ? jsonData1["lines"] : (JsonData)null;
            if (jsonData13 != null && jsonData13.IsArray)
            {
                foreach (JsonData jsonData3 in (IEnumerable)jsonData13)
                    lineList.Add(new Line()
                    {
                        ID = jsonData3["id"].ToString().ToGuid(),
                        FromID = jsonData3["from"].ToString().ToGuid(),
                        ToID = jsonData3["to"].ToString().ToGuid(),
                        CustomMethod = jsonData3["customMethod"].ToString(),
                        SqlWhere = jsonData3["sql"].ToString(),
                        NoAccordMsg = jsonData3.ContainsKey("noaccordMsg") ? jsonData3["noaccordMsg"].ToString() : "",
                        Organize = jsonData3.ContainsKey("organize") ? jsonData3["organize"].ToJson(true) : ""
                    });
            }
            workFlowInstalled.Lines = (IEnumerable<Line>)lineList;
            List<Guid> source = new List<Guid>();
            foreach (Step step1 in workFlowInstalled.Steps)
            {
                Step step = step1;
                if (workFlowInstalled.Lines.Where<Line>((Func<Line, bool>)(p => p.ToID == step.ID)).Count<Line>() == 0)
                    source.Add(step.ID);
            }
            if (source.Count == 0)
            {
                errMsg = "流程没有开始步骤";
                return (WorkFlowInstalled)null;
            }
            RoadFlow.Data.Model.WorkFlow workFlow = this.dataWorkFlow.Get(workFlowInstalled.ID);
            if (workFlow != null)
            {
                workFlowInstalled.CreateTime = workFlow.CreateDate;
                workFlowInstalled.CreateUser = workFlow.CreateUserID.ToString();
                workFlowInstalled.DesignJSON = workFlow.DesignJSON;
                workFlowInstalled.FirstStepID = source.First<Guid>();
                workFlowInstalled.InstallTime = DateTimeNew.Now;
                workFlowInstalled.InstallUser = Users.CurrentUserID.ToString();
                workFlowInstalled.RunJSON = jsonString;
                workFlowInstalled.Status = workFlow.Status;
            }
            return workFlowInstalled;
        }

        public List<Step> GetAllPrevSteps(Guid flowID, Guid stepID)
        {
            List<Step> stepList = new List<Step>();
            WorkFlowInstalled workFlowRunModel = this.GetWorkFlowRunModel(flowID, true);
            if (workFlowRunModel == null)
                return stepList;
            this.addPrevSteps(stepList, workFlowRunModel, stepID);
            return stepList.Distinct<Step>().ToList<Step>();
        }

        private void addPrevSteps(List<Step> list, WorkFlowInstalled wfInstalled, Guid stepID)
        {
            if (wfInstalled == null)
                return;
            foreach (Line line1 in wfInstalled.Lines.Where<Line>((Func<Line, bool>)(p => p.ToID == stepID)))
            {
                Line line = line1;
                IEnumerable<Step> source = wfInstalled.Steps.Where<Step>((Func<Step, bool>)(p => p.ID == line.FromID));
                if (source.Count<Step>() > 0)
                {
                    list.Add(source.First<Step>());
                    this.addPrevSteps(list, wfInstalled, source.First<Step>().ID);
                }
            }
        }

        public List<Step> GetPrevSteps(Guid flowID, Guid stepID)
        {
            List<Step> stepList = new List<Step>();
            WorkFlowInstalled workFlowRunModel = this.GetWorkFlowRunModel(flowID, true);
            if (workFlowRunModel == null)
                return stepList;
            foreach (Line line1 in workFlowRunModel.Lines.Where<Line>((Func<Line, bool>)(p => p.ToID == stepID)))
            {
                Line line = line1;
                IEnumerable<Step> source = workFlowRunModel.Steps.Where<Step>((Func<Step, bool>)(p => p.ID == line.FromID));
                if (source.Count<Step>() > 0)
                    stepList.Add(source.First<Step>());
            }
            return stepList;
        }

        public List<Step> GetNextSteps(Guid flowID, Guid stepID)
        {
            List<Step> stepList = new List<Step>();
            WorkFlowInstalled workFlowRunModel = this.GetWorkFlowRunModel(flowID, true);
            if (workFlowRunModel == null)
                return stepList;
            foreach (Line line1 in workFlowRunModel.Lines.Where<Line>((Func<Line, bool>)(p => p.FromID == stepID)))
            {
                Line line = line1;
                IEnumerable<Step> source = workFlowRunModel.Steps.Where<Step>((Func<Step, bool>)(p => p.ID == line.ToID));
                if (source.Count<Step>() > 0)
                    stepList.Add(source.First<Step>());
            }
            return stepList;
        }

        public string GetStepName(Guid stepID, Guid flowID, out string flowName, bool defaultFirstStepName = false)
        {
            flowName = "";
            WorkFlowInstalled workFlowRunModel = this.GetWorkFlowRunModel(flowID, true);
            if (workFlowRunModel == null)
                return "";
            if (stepID == Guid.Empty & defaultFirstStepName)
                stepID = workFlowRunModel.FirstStepID;
            flowName = workFlowRunModel.Name;
            IEnumerable<Step> source = workFlowRunModel.Steps.Where<Step>((Func<Step, bool>)(p => p.ID == stepID));
            if (source.Count<Step>() <= 0)
                return "";
            return source.First<Step>().Name;
        }

        public string GetStepName(Guid stepID, Guid flowID, bool defautFirstStepName = false)
        {
            string flowName;
            return this.GetStepName(stepID, flowID, out flowName, defautFirstStepName);
        }

        public string GetStepName(Guid stepID, WorkFlowInstalled wfinstalled, bool defautFirstStepName = false)
        {
            if (wfinstalled == null)
                return "";
            if (stepID == Guid.Empty & defautFirstStepName)
                stepID = wfinstalled.FirstStepID;
            IEnumerable<Step> source = wfinstalled.Steps.Where<Step>((Func<Step, bool>)(p => p.ID == stepID));
            if (source.Count<Step>() <= 0)
                return "";
            return source.First<Step>().Name;
        }

        public string GetFlowName(Guid flowID)
        {
            RoadFlow.Data.Model.WorkFlow fromCache = this.GetFromCache(flowID);
            if (fromCache == null)
                return "";
            return fromCache.Name;
        }

        public System.Collections.Generic.Dictionary<Guid, string> GetAllIDAndName()
        {
            return this.dataWorkFlow.GetAllIDAndName();
        }

        public string GetOptions(string value = "")
        {
            System.Collections.Generic.Dictionary<Guid, string> allIdAndName = this.GetAllIDAndName();
            StringBuilder stringBuilder = new StringBuilder();
            foreach (KeyValuePair<Guid, string> keyValuePair in (IEnumerable<KeyValuePair<Guid, string>>)allIdAndName.OrderBy<KeyValuePair<Guid, string>, string>((Func<KeyValuePair<Guid, string>, string>)(p => p.Value)))
                stringBuilder.AppendFormat("<option value=\"{0}\" {1}>{2}</option>", (object)keyValuePair.Key, ("," + value + ",").Contains("," + keyValuePair.Key.ToString() + ",") ? (object)"selected=\"selected\"" : (object)"", (object)keyValuePair.Value);
            return stringBuilder.ToString();
        }

        public string GetOptions(System.Collections.Generic.Dictionary<Guid, string> flows, string typeid, string value = "")
        {
            System.Collections.Generic.Dictionary<Guid, string> dictionary = flows;
            StringBuilder stringBuilder = new StringBuilder();
            foreach (KeyValuePair<Guid, string> keyValuePair in dictionary)
                stringBuilder.AppendFormat("<option value=\"{0}\" {1}>{2}</option>", (object)keyValuePair.Key, keyValuePair.Key.ToString() == value ? (object)"selected=\"selected\"" : (object)"", (object)keyValuePair.Value);
            return stringBuilder.ToString();
        }

        public System.Collections.Generic.Dictionary<Guid, string> GetInstanceManageFlowIDList(Guid userID, string typeID = "")
        {
            List<RoadFlow.Data.Model.WorkFlow> allFromCache = this.GetAllFromCache();
            Organize organize = new Organize();
            System.Collections.Generic.Dictionary<Guid, string> dictionary = new System.Collections.Generic.Dictionary<Guid, string>();
            foreach (RoadFlow.Data.Model.WorkFlow workFlow in allFromCache)
            {
                if ((!typeID.IsGuid() || this.GetAllChildsIDString(typeID.ToGuid(), true).Contains(workFlow.Type.ToString(), StringComparison.CurrentCultureIgnoreCase)) && workFlow.InstanceManager.Contains(userID.ToString(), StringComparison.CurrentCultureIgnoreCase))
                    dictionary.Add(workFlow.ID, workFlow.Name);
            }
            return dictionary;
        }

        public Bitmap CreateSignImage(string UserName)
        {
            if (UserName.IsNullOrEmpty())
                return (Bitmap)null;
            Random random = new Random(UserName.GetHashCode());
            Size empty = Size.Empty;
            Font font = new Font("隶书", 16f);
            using (Bitmap bitmap = new Bitmap(5, 5))
            {
                using (Graphics graphics = Graphics.FromImage((System.Drawing.Image)bitmap))
                {
                    SizeF sizeF = graphics.MeasureString(UserName, font, 10000);
                    empty.Width = (int)sizeF.Width + 4;
                    empty.Height = (int)sizeF.Height;
                }
            }
            Bitmap bitmap1 = new Bitmap(empty.Width, empty.Height);
            using (Graphics graphics = Graphics.FromImage((System.Drawing.Image)bitmap1))
            {
                graphics.Clear(Color.White);
                using (StringFormat format = new StringFormat())
                {
                    format.Alignment = StringAlignment.Center;
                    format.LineAlignment = StringAlignment.Center;
                    format.FormatFlags = StringFormatFlags.NoWrap;
                    graphics.DrawString(UserName, font, Brushes.Red, new RectangleF(0.0f, 0.0f, (float)empty.Width, (float)empty.Height), format);
                }
            }
            Color red = Color.Red;
            int num1 = empty.Width * empty.Height * 8 / 100;
            for (int index = 0; index < num1; ++index)
            {
                int x1 = random.Next(0, 4);
                int y1 = random.Next(empty.Height);
                bitmap1.SetPixel(x1, y1, red);
                int x2 = random.Next(empty.Width - 4, empty.Width);
                int y2 = random.Next(empty.Height);
                bitmap1.SetPixel(x2, y2, red);
            }
            int num2 = empty.Width * empty.Height * 20 / 100;
            for (int index = 0; index < num2; ++index)
            {
                int x1 = random.Next(empty.Width);
                int y1 = random.Next(0, 4);
                bitmap1.SetPixel(x1, y1, red);
                int x2 = random.Next(empty.Width);
                int y2 = random.Next(empty.Height - 4, empty.Height);
                bitmap1.SetPixel(x2, y2, red);
            }
            int num3 = empty.Width * empty.Height / 150;
            for (int index = 0; index < num3; ++index)
            {
                int x = random.Next(empty.Width);
                int y = random.Next(empty.Height);
                bitmap1.SetPixel(x, y, red);
            }
            font.Dispose();
            return bitmap1;
        }

        public string GetAutoTitle(string flowID, string stepID)
        {
            string flowName;
            string stepName = this.GetStepName(stepID.ToGuid(), flowID.ToGuid(), out flowName, true);
            return string.Format("<div class='flowautotitle'>{0} - {1}</div>", (object)flowName, (object)stepName);
        }

        public string GetAutoTaskTitle(string flowID, string stepID, string groupID = "")
        {
            WorkFlowInstalled workFlowRunModel = this.GetWorkFlowRunModel(flowID, true);
            if (workFlowRunModel == null)
                return "";
            string name = workFlowRunModel.Name;
            string str1 = "";
            Guid test;
            if (groupID.IsGuid(out test) || test == Guid.Empty)
                str1 = new Users().GetName(new WorkFlowTask().GetFirstSnderID(flowID.ToGuid(), test, false));
            if (str1.IsNullOrEmpty())
                str1 = Users.CurrentUserName;
            string str2 = "(";
            string str3 = str1;
            string str4 = ")";
            return name + str2 + str3 + str4;
        }

        public string SaveFromData(string instanceid, WorkFlowCustomEventParams eventParams)
        {
            string str1 = HttpContext.Current.Request.Form["Form_CustomSaveMethod"];
            if (!str1.IsNullOrEmpty())
                return new WorkFlowTask().ExecuteFlowCustomEvent(str1, (object)eventParams, "").ToString();
            if ("1" != HttpContext.Current.Request.Form["Form_AutoSaveData"])
                return instanceid;
            DBConnection dbConnection = new DBConnection();
            string dbconnid = HttpContext.Current.Request.Form["Form_DBConnID"];
            string str2 = HttpContext.Current.Request.Form["Form_DBTable"];
            string strB1 = HttpContext.Current.Request.Form["Form_DBTablePk"];
            string str3 = HttpContext.Current.Request.Form["Form_DBTableTitle"];
            string str4 = HttpContext.Current.Request.Form["HasSerialNumber"];
            if (!dbconnid.IsGuid())
                return instanceid;
            List<FieldStatus> fieldStatusList = new List<FieldStatus>();
            int num1 = 0;
            string str5 = string.Empty;
            WorkFlowInstalled workFlowRunModel = this.GetWorkFlowRunModel(eventParams.FlowID, true);
            if (workFlowRunModel != null)
            {
                IEnumerable<Step> source = workFlowRunModel.Steps.Where<Step>((Func<Step, bool>)(p => p.ID == eventParams.StepID));
                if (source.Count<Step>() > 0)
                {
                    fieldStatusList = source.First<Step>().FieldStatus.ToList<FieldStatus>();
                    num1 = source.First<Step>().DataSaveType;
                    str5 = source.First<Step>().DataSaveTypeWhere;
                }
            }
            RoadFlow.Data.Model.DBConnection dbconn = dbConnection.Get(dbconnid.ToGuid(), true);
            if (dbconn == null)
                return instanceid;
            using (IDbConnection connection = dbConnection.GetConnection(dbconn))
            {
                if (connection == null)
                    return instanceid;
                try
                {
                    connection.Open();
                }
                catch (Exception ex)
                {
                    HttpContext.Current.Response.Write("连接数据库出错：" + ex.Message);
                    Log.Add(ex);
                }
                string cmdText1 = string.Empty;
                List<IDataParameter> dataParameterList1 = new List<IDataParameter>();
                if (instanceid.IsNullOrEmpty() || 1 == num1)
                {
                    cmdText1 = string.Format("SELECT * FROM {0} WHERE {1}", (object)str2, str5.IsNullOrEmpty() ? (object)"1=0" : (object)str5.FilterWildcard(""));
                }
                else
                {
                    string type = dbconn.Type;
                    if (!(type == "SqlServer"))
                    {
                        if (!(type == "Oracle"))
                        {
                            if (type == "MySql")
                            {
                                cmdText1 = string.Format("SELECT * FROM {0} WHERE {1}=@pk", (object)str2, (object)strB1);
                                dataParameterList1.Add((IDataParameter)new MySqlParameter("@pk", (object)instanceid));
                            }
                        }
                        else
                        {
                            cmdText1 = string.Format("SELECT * FROM {0} WHERE {1}=:pk", (object)str2, (object)strB1);
                            dataParameterList1.Add((IDataParameter)new OracleParameter(":pk", (object)instanceid));
                        }
                    }
                    else
                    {
                        cmdText1 = string.Format("SELECT * FROM {0} WHERE {1}=@pk", (object)str2, (object)strB1);
                        dataParameterList1.Add((IDataParameter)new SqlParameter("@pk", (object)instanceid));
                    }
                }
                IDbDataAdapter dataAdapter1 = dbConnection.GetDataAdapter(connection, dbconn.Type, cmdText1, dataParameterList1.ToArray());
                DataSet dataSet1 = new DataSet();
                dataAdapter1.Fill(dataSet1);
                DataTable tableSchema1 = dbConnection.GetTableSchema(connection, str2, dbconn.Type);
                DataTable table1 = dataSet1.Tables[0];
                bool flag1 = table1.Rows.Count == 0;
                if (flag1)
                    table1.Rows.Add(table1.NewRow());
                if (!instanceid.IsNullOrEmpty())
                    table1.Rows[0][strB1] = (object)instanceid;
                string str6 = string.Empty;
                int maxNumber = 0;
                for (int index = 0; index < table1.Columns.Count; ++index)
                {
                    string columnName = table1.Columns[index].ColumnName;
                    string name = str2 + "." + columnName;
                    string serialNumber = HttpContext.Current.Request.Form[name];
                    if (string.Compare(columnName, strB1, true) == 0)
                    {
                        if (!serialNumber.IsNullOrEmpty())
                            instanceid = serialNumber;
                        else
                            continue;
                    }
                    if (serialNumber.IsNullOrEmpty() && !str4.IsNullOrEmpty() && ("," + str4 + ",").Contains(name, StringComparison.CurrentCultureIgnoreCase))
                    {
                        if (table1.Rows[0][columnName].ToString().IsNullOrEmpty())
                        {
                            string str7 = HttpContext.Current.Request.Form["HasSerialNumberConfig_" + name];
                            if (!str7.IsNullOrEmpty())
                            {
                                JsonData serialNumberJson = JsonMapper.ToObject(str7);
                                serialNumber = dbConnection.GetSerialNumber(connection, dbconn.Type, str2, columnName, serialNumberJson, out maxNumber);
                                str6 = serialNumberJson.ContainsKey("maxfiled") ? serialNumberJson["maxfiled"].ToString() : "";
                            }
                        }
                        else
                            serialNumber = table1.Rows[0][columnName].ToString();
                    }
                    if (serialNumber == null && !flag1)
                    {
                        FieldStatus fieldStatus = fieldStatusList.Find((Predicate<FieldStatus>)(p => p.Field.Equals(dbconnid + "." + name, StringComparison.CurrentCultureIgnoreCase)));
                        if (fieldStatus != null)
                        {
                            if (fieldStatus.Status1.In(1, 2))
                                continue;
                        }
                        else
                            continue;
                    }
                    string fullName = table1.Columns[index].DataType.FullName;
                    DataRow[] dataRowArray = tableSchema1.Select(string.Format("f_name='{0}'", (object)columnName));
                    bool flag2 = false;
                    bool flag3 = false;
                    object defaultValue;
                    bool colnumIsValue = this.getColnumIsValue(fullName, serialNumber, out defaultValue);
                    object obj = (object)string.Empty;
                    string type = dbconn.Type;
                    if (!(type == "SqlServer"))
                    {
                        if (!(type == "Oracle"))
                        {
                            if (type == "MySql")
                            {
                                flag2 = dataRowArray.Length != 0 && !dataRowArray[0]["cdefault"].ToString().IsNullOrEmpty();
                                flag3 = dataRowArray.Length != 0 && dataRowArray[0]["is_null"].ToString() != "0";
                                if (flag2 && !dataRowArray[0]["defaultvalue"].ToString().IsNullOrEmpty())
                                    obj = dbConnection.GetDbDefaultValue_MySql(dataRowArray[0]["defaultvalue"].ToString().Trim1());
                            }
                        }
                        else
                        {
                            flag2 = dataRowArray.Length != 0 && !dataRowArray[0]["cdefault"].ToString().IsNullOrEmpty();
                            flag3 = dataRowArray.Length != 0 && dataRowArray[0]["is_null"].ToString() != "0";
                            if (flag2 && !dataRowArray[0]["defaultvalue"].ToString().IsNullOrEmpty())
                                obj = dbConnection.GetDbDefaultValue_Oracle(dataRowArray[0]["defaultvalue"].ToString().Trim1());
                        }
                    }
                    else
                    {
                        flag2 = dataRowArray.Length != 0 && dataRowArray[0]["cdefault"].ToString() != "0";
                        flag3 = dataRowArray.Length != 0 && dataRowArray[0]["is_null"].ToString() != "0";
                        if (flag2 && !dataRowArray[0]["defaultvalue"].ToString().IsNullOrEmpty())
                            obj = dbConnection.GetDbDefaultValue_SqlServer(dataRowArray[0]["defaultvalue"].ToString().Trim1());
                    }
                    if (str6.IsNullOrEmpty() || !columnName.Equals(str6, StringComparison.CurrentCultureIgnoreCase))
                    {
                        if (colnumIsValue)
                            table1.Rows[0][columnName] = (object)serialNumber;
                        else if (!flag2)
                            table1.Rows[0][columnName] = !flag3 ? defaultValue : (object)DBNull.Value;
                        else if (obj != null)
                        {
                            try
                            {
                                table1.Rows[0][columnName] = obj;
                            }
                            catch
                            {
                            }
                        }
                    }
                }
                if (!str6.IsNullOrEmpty())
                    table1.Rows[0][str6] = (object)maxNumber;
                bool flag4 = false;
                if (flag1 && instanceid.IsNullOrEmpty())
                {
                    DataColumn column = table1.Columns[strB1];
                    DataRow[] dataRowArray = tableSchema1.Select(string.Format("f_name='{0}'", (object)strB1));
                    if (dataRowArray.Length != 0)
                    {
                        flag4 = false;
                        bool flag2 = false;
                        string type = dbconn.Type;
                        if (!(type == "SqlServer"))
                        {
                            if (!(type == "Oracle"))
                            {
                                if (type == "MySql")
                                {
                                    flag4 = dataRowArray[0]["isidentity"].ToString() == "1";
                                    dataRowArray[0]["cdefault"].ToString().IsNullOrEmpty();
                                    flag2 = column.DataType.FullName == "System.Guid" || column.DataType.FullName == "System.String";
                                }
                            }
                            else
                            {
                                flag4 = dataRowArray[0]["t_name"].ToString().Equals("NUMBER", StringComparison.CurrentCultureIgnoreCase);
                                dataRowArray[0]["cdefault"].ToString().IsNullOrEmpty();
                                flag2 = column.DataType.FullName == "System.String";
                            }
                        }
                        else
                        {
                            flag4 = dataRowArray[0]["isidentity"].ToString() == "1";
                            int num2 = dataRowArray[0]["cdefault"].ToString() != "0" ? 1 : 0;
                            flag2 = column.DataType.FullName == "System.Guid";
                        }
                        if (!flag4 & flag2)
                        {
                            instanceid = Guid.NewGuid().ToString();
                            table1.Rows[0][strB1] = (object)instanceid;
                        }
                    }
                }
                string type1 = dbconn.Type;
                if (!(type1 == "SqlServer"))
                {
                    if (!(type1 == "Oracle"))
                    {
                        if (type1 == "MySql")
                        {
                            MySqlCommandBuilder sqlCommandBuilder = new MySqlCommandBuilder((MySqlDataAdapter)dataAdapter1);
                            dataAdapter1.Update(dataSet1);
                            sqlCommandBuilder.Dispose();
                        }
                    }
                    else
                    {
                        OracleCommandBuilder oracleCommandBuilder = new OracleCommandBuilder((OracleDataAdapter)dataAdapter1);
                        dataAdapter1.Update(dataSet1);
                        oracleCommandBuilder.Dispose();
                    }
                }
                else
                {
                    SqlCommandBuilder sqlCommandBuilder = new SqlCommandBuilder((SqlDataAdapter)dataAdapter1);
                    dataAdapter1.Update(dataSet1);
                    sqlCommandBuilder.Dispose();
                }
                if (flag1 & flag4)
                {
                    string type2 = dbconn.Type;
                    if (!(type2 == "SqlServer"))
                    {
                        if (!(type2 == "Oracle"))
                        {
                            if (type2 == "MySql")
                            {
                                using (MySqlCommand mySqlCommand = new MySqlCommand(string.Format("select @@IDENTITY"), (MySqlConnection)connection))
                                {
                                    object obj = mySqlCommand.ExecuteScalar();
                                    if (obj != null)
                                    {
                                        instanceid = obj.ToString();
                                        table1.Rows[0][strB1] = (object)instanceid;
                                    }
                                }
                            }
                        }
                        else
                        {
                            using (OracleCommand oracleCommand = new OracleCommand(string.Format("SELECT {0}_{1}_SEQ.currval FROM dual", (object)str2, (object)strB1), (OracleConnection)connection))
                            {
                                object obj = oracleCommand.ExecuteScalar();
                                if (obj != null)
                                {
                                    instanceid = obj.ToString();
                                    table1.Rows[0][strB1] = (object)instanceid;
                                }
                            }
                        }
                    }
                    else
                    {
                        using (SqlCommand sqlCommand = new SqlCommand("SELECT @@IDENTITY", (SqlConnection)connection))
                        {
                            object obj = sqlCommand.ExecuteScalar();
                            if (obj != null)
                            {
                                instanceid = obj.ToString();
                                table1.Rows[0][strB1] = (object)instanceid;
                            }
                        }
                    }
                }
                string str8 = HttpContext.Current.Request.Form["flowsubtable_id"] ?? "";
                char[] chArray = new char[1] { ',' };
                foreach (string str7 in str8.Split(chArray))
                {
                    string secondtable = HttpContext.Current.Request.Form["flowsubtable_" + str7 + "_secondtable"];
                    string str9 = HttpContext.Current.Request.Form["flowsubtable_" + str7 + "_primarytablefiled"];
                    string index1 = HttpContext.Current.Request.Form["flowsubtable_" + str7 + "_secondtableprimarykey"];
                    string index2 = HttpContext.Current.Request.Form["flowsubtable_" + str7 + "_secondtablerelationfield"];
                    if (!secondtable.IsNullOrEmpty() && !str9.IsNullOrEmpty() && (!index1.IsNullOrEmpty() && !index2.IsNullOrEmpty()))
                    {
                        string str10 = table1.Rows[0][str9].ToString();
                        if (!str10.IsNullOrEmpty())
                        {
                            string cmdText2 = string.Empty;
                            List<IDataParameter> dataParameterList2 = new List<IDataParameter>();
                            string type2 = dbconn.Type;
                            if (!(type2 == "SqlServer"))
                            {
                                if (!(type2 == "Oracle"))
                                {
                                    if (type2 == "MySql")
                                    {
                                        cmdText2 = string.Format("SELECT * FROM {0} WHERE {1}=@pk", (object)secondtable, (object)index2);
                                        dataParameterList2.Add((IDataParameter)new MySqlParameter("@pk", (object)str10));
                                    }
                                }
                                else
                                {
                                    cmdText2 = string.Format("SELECT * FROM {0} WHERE {1}=:pk", (object)secondtable, (object)index2);
                                    dataParameterList2.Add((IDataParameter)new OracleParameter(":pk", (object)str10));
                                }
                            }
                            else
                            {
                                cmdText2 = string.Format("SELECT * FROM {0} WHERE {1}=@pk", (object)secondtable, (object)index2);
                                dataParameterList2.Add((IDataParameter)new SqlParameter("@pk", (object)str10));
                            }
                            string[] strArray = (HttpContext.Current.Request.Form["hidden_guid_" + str7] ?? "").Split(',');
                            IDbDataAdapter dataAdapter2 = dbConnection.GetDataAdapter(connection, dbconn.Type, cmdText2, dataParameterList2.ToArray());
                            DataSet dataSet2 = new DataSet();
                            dataAdapter2.Fill(dataSet2);
                            DataTable tableSchema2 = dbConnection.GetTableSchema(connection, secondtable, dbconn.Type);
                            DataTable table2 = dataSet2.Tables[0];
                            bool flag2 = table2.Rows.Count == 0;
                            foreach (string strB2 in strArray)
                            {
                                bool flag3 = true;
                                DataRow row1 = (DataRow)null;
                                foreach (DataRow row2 in (InternalDataCollectionBase)table2.Rows)
                                {
                                    if (string.Compare(row2[index1].ToString(), strB2, StringComparison.CurrentCulture) == 0)
                                    {
                                        row1 = row2;
                                        flag3 = false;
                                        break;
                                    }
                                }
                                if (flag3)
                                {
                                    row1 = table2.NewRow();
                                    row1[index2] = (object)str10;
                                    table2.Rows.Add(row1);
                                    flag3 = true;
                                }
                                for (int index3 = 0; index3 < table2.Columns.Count; ++index3)
                                {
                                    string colnumName1 = table2.Columns[index3].ColumnName;
                                    if (string.Compare(colnumName1, index1, true) != 0 && string.Compare(colnumName1, index2, StringComparison.CurrentCulture) != 0)
                                    {
                                        string str11 = HttpContext.Current.Request.Form[str7 + "_" + strB2 + "_" + secondtable + "_" + colnumName1];
                                        if (str11 == null && !flag3)
                                        {
                                            FieldStatus fieldStatus = fieldStatusList.Find((Predicate<FieldStatus>)(p => p.Field.Equals(dbconnid + "." + secondtable + "." + colnumName1, StringComparison.CurrentCultureIgnoreCase)));
                                            if (fieldStatus != null)
                                            {
                                                if (fieldStatus.Status1.In(1, 2))
                                                    continue;
                                            }
                                            else
                                                continue;
                                        }
                                        string fullName = table2.Columns[index3].DataType.FullName;
                                        object defaultValue = (object)string.Empty;
                                        object obj = (object)null;
                                        DataRow[] dataRowArray = tableSchema2.Select(string.Format("f_name='{0}'", (object)colnumName1));
                                        bool flag5 = dataRowArray.Length != 0 && dataRowArray[0]["cdefault"].ToString() != "0";
                                        bool flag6 = dataRowArray.Length != 0 && dataRowArray[0]["is_null"].ToString() != "0";
                                        bool colnumIsValue = this.getColnumIsValue(fullName, str11, out defaultValue);
                                        if (flag5 && !dataRowArray[0]["defaultvalue"].ToString().IsNullOrEmpty())
                                        {
                                            string type3 = dbconn.Type;
                                            if (!(type3 == "SqlServer"))
                                            {
                                                if (!(type3 == "Oracle"))
                                                {
                                                    if (type3 == "MySql")
                                                        obj = dbConnection.GetDbDefaultValue_MySql(dataRowArray[0]["defaultvalue"].ToString().Trim1());
                                                }
                                                else
                                                    obj = dbConnection.GetDbDefaultValue_Oracle(dataRowArray[0]["defaultvalue"].ToString().Trim1());
                                            }
                                            else
                                                obj = dbConnection.GetDbDefaultValue_SqlServer(dataRowArray[0]["defaultvalue"].ToString().Trim1());
                                        }
                                        if (colnumIsValue)
                                            row1[colnumName1] = (object)str11;
                                        else if (!flag5)
                                            row1[colnumName1] = !flag6 ? defaultValue : (object)DBNull.Value;
                                        else if (obj != null)
                                        {
                                            try
                                            {
                                                row1[colnumName1] = obj;
                                            }
                                            catch
                                            {
                                            }
                                        }
                                    }
                                }
                            }
                            if (!flag2)
                            {
                                for (int index3 = 0; index3 < table2.Rows.Count; ++index3)
                                {
                                    bool flag3 = false;
                                    foreach (string strB2 in strArray)
                                    {
                                        if (table2.Rows[index3][index1].ToString().IsNullOrEmpty() || string.Compare(table2.Rows[index3][index1].ToString(), strB2, StringComparison.CurrentCulture) == 0)
                                        {
                                            flag3 = true;
                                            break;
                                        }
                                    }
                                    if (!flag3)
                                        table2.Rows[index3].Delete();
                                }
                            }
                            if ("Oracle".Equals(dbconn.Type) || "MySql".Equals(dbconn.Type))
                            {
                                DataRow[] dataRowArray = tableSchema2.Select(string.Format("f_name='{0}'", (object)index1));
                                bool flag3 = dataRowArray.Length != 0 && dataRowArray[0]["isidentity"].ToString() == "1";
                                if ("Oracle".Equals(dbconn.Type))
                                    flag3 = dataRowArray[0]["t_name"].ToString().Equals("NUMBER", StringComparison.CurrentCultureIgnoreCase);
                                if (!flag3)
                                {
                                    foreach (DataRow row in (InternalDataCollectionBase)table2.Rows)
                                    {
                                        if (row.RowState == DataRowState.Added)
                                            row[index1] = (object)Guid.NewGuid();
                                    }
                                }
                            }
                            string type4 = dbconn.Type;
                            if (!(type4 == "SqlServer"))
                            {
                                if (!(type4 == "Oracle"))
                                {
                                    if (type4 == "MySql")
                                    {
                                        MySqlCommandBuilder sqlCommandBuilder = new MySqlCommandBuilder((MySqlDataAdapter)dataAdapter2);
                                        dataAdapter2.Update(dataSet2);
                                        sqlCommandBuilder.Dispose();
                                    }
                                }
                                else
                                {
                                    OracleCommandBuilder oracleCommandBuilder = new OracleCommandBuilder((OracleDataAdapter)dataAdapter2);
                                    dataAdapter2.Update(dataSet2);
                                    oracleCommandBuilder.Dispose();
                                }
                            }
                            else
                            {
                                SqlCommandBuilder sqlCommandBuilder = new SqlCommandBuilder((SqlDataAdapter)dataAdapter2);
                                dataAdapter2.Update(dataSet2);
                                sqlCommandBuilder.Dispose();
                            }
                        }
                    }
                }
                return instanceid;
            }
        }

        private bool getColnumIsValue(string colnumDataType, string value, out object defaultValue)
        {
            bool flag = false;
            defaultValue = (object)null;
            switch (colnumDataType)
            {
                case "System.Boolean":
                    flag = value != null && (value.ToString().ToLower() == "false" || value.ToString().ToLower() == "true");
                    defaultValue = (object)0;
                    break;
                case "System.DateTime":
                    flag = value.IsDateTime();
                    defaultValue = (object)DateTimeNew.Now;
                    break;
                case "System.Decimal":
                    flag = value.IsDecimal();
                    defaultValue = (object)new Decimal(-1, -1, -1, true, (byte)0);
                    break;
                case "System.Double":
                case "System.Single":
                    flag = value.IsDouble();
                    defaultValue = (object)double.MinValue;
                    break;
                case "System.Guid":
                    flag = value.IsGuid();
                    defaultValue = (object)Guid.Empty;
                    break;
                case "System.Int16":
                case "System.Int32":
                case "System.Int64":
                case "System.UInt16":
                case "System.UInt32":
                case "System.UInt64":
                    flag = value.IsInt();
                    defaultValue = (object)int.MinValue;
                    break;
                case "System.Object":
                    flag = value != null;
                    defaultValue = (object)"";
                    break;
                case "System.String":
                    flag = value != null;
                    defaultValue = (object)"";
                    break;
            }
            return flag;
        }

        public JsonData GetFormData(string connid, string table, string pk, string instanceid, string filedStatus = "", string formats = "", string taskID = "")
        {
            JsonData jsonData1 = new JsonData();
            if (instanceid.IsNullOrEmpty())
                return jsonData1;
            DBConnection dbConnection = new DBConnection();
            RoadFlow.Data.Model.DBConnection dbconn = dbConnection.Get(connid.ToGuid(), true);
            if (dbconn == null)
                return (JsonData)"";
            JsonData jsonData2 = (JsonData)null;
            if (!formats.IsNullOrEmpty())
                jsonData2 = JsonMapper.ToObject(formats);
            using (IDbConnection connection = dbConnection.GetConnection(dbconn))
            {
                if (connection == null)
                    return (JsonData)"";
                try
                {
                    connection.Open();
                }
                catch (Exception ex)
                {
                    HttpContext.Current.Response.Write("连接数据库出错：" + ex.Message);
                    Log.Add(ex);
                }
                string cmdText = string.Empty;
                string str1 = string.Empty;
                int num = 0;
                List<IDataParameter> dataParameterList = new List<IDataParameter>();
                if (taskID.IsGuid())
                {
                    RoadFlow.Data.Model.WorkFlowTask task = new WorkFlowTask().Get(taskID.ToGuid());
                    if (task != null)
                    {
                        WorkFlowInstalled workFlowRunModel = new WorkFlow().GetWorkFlowRunModel(task.FlowID, true);
                        if (workFlowRunModel != null)
                        {
                            IEnumerable<Step> source = workFlowRunModel.Steps.Where<Step>((Func<Step, bool>)(p => p.ID == task.StepID));
                            if (source.Count<Step>() > 0)
                            {
                                num = source.First<Step>().DataSaveType;
                                str1 = source.First<Step>().DataSaveTypeWhere;
                            }
                        }
                    }
                }
                if (num == 1)
                {
                    cmdText = string.Format("SELECT * FROM {0} WHERE {1}", (object)table, (object)str1.FilterWildcard(""));
                }
                else
                {
                    string type = dbconn.Type;
                    if (!(type == "SqlServer"))
                    {
                        if (!(type == "Oracle"))
                        {
                            if (type == "MySql")
                            {
                                cmdText = string.Format("SELECT * FROM {0} WHERE {1}=@pk", (object)table, (object)pk);
                                dataParameterList.Add((IDataParameter)new MySqlParameter("@pk", (object)instanceid));
                            }
                        }
                        else
                        {
                            cmdText = string.Format("SELECT * FROM {0} WHERE {1}=:pk", (object)table, (object)pk);
                            dataParameterList.Add((IDataParameter)new OracleParameter(":pk", (object)instanceid));
                        }
                    }
                    else
                    {
                        cmdText = string.Format("SELECT * FROM {0} WHERE {1}=@pk", (object)table, (object)pk);
                        dataParameterList.Add((IDataParameter)new SqlParameter("@pk", (object)instanceid));
                    }
                }
                IDbDataAdapter dataAdapter = dbConnection.GetDataAdapter(connection, dbconn.Type, cmdText, dataParameterList.ToArray());
                DataSet dataSet = new DataSet();
                dataAdapter.Fill(dataSet);
                if (dataAdapter.SelectCommand != null)
                    dataAdapter.SelectCommand.Dispose();
                DataTable table1 = dataSet.Tables[0];
                JsonData jsonData3 = (JsonData)null;
                if (!filedStatus.IsNullOrEmpty())
                    jsonData3 = JsonMapper.ToObject(filedStatus);
                if (table1.Rows.Count > 0)
                {
                    DataRow row = table1.Rows[0];
                    for (int index = 0; index < table1.Columns.Count; ++index)
                    {
                        bool flag = true;
                        string lower1 = (table + "_" + table1.Columns[index].ColumnName).ToLower();
                        if (jsonData3 != null && jsonData3.ContainsKey(lower1))
                        {
                            string str2 = jsonData3[lower1].ToString();
                            if (!str2.IsNullOrEmpty())
                            {
                                string[] strArray = str2.Split('_');
                                if (strArray.Length == 2 && "2" == strArray[0])
                                    flag = false;
                            }
                        }
                        string str3 = row[table1.Columns[index].ColumnName].ToString();
                        string lower2 = (table + "." + table1.Columns[index].ColumnName).ToLower();
                        if (jsonData2 != null && jsonData2.ContainsKey(lower2))
                        {
                            string format = jsonData2[lower2].ToString();
                            if (str3.IsDecimal())
                                str3 = str3.ToDecimal().ToString(format);
                            else if (str3.IsDateTime())
                                str3 = str3.ToDateTime().ToString(format);
                        }
                        jsonData1[lower1] = !flag ? (JsonData)"" : (JsonData)str3;
                    }
                }
            }
            return jsonData1;
        }

        public string GetFormDataJsonString(string connid, string table, string pk, string instanceid)
        {
            return this.GetFormDataJsonString(this.GetFormData(connid, table, pk, instanceid, "", "", ""));
        }

        public string GetFormDataJsonString(JsonData jsonData)
        {
            string json = jsonData.ToJson(true);
            if (!json.IsNullOrEmpty())
                return json;
            return "{}";
        }

        public JsonData GetSubTableData(string connID, string secondTable, string relationField, string fieldValue, string sortField = "", string fieldFormat = "")
        {
            JsonData jsonData1 = new JsonData();
            if (fieldValue.IsNullOrEmpty())
                return jsonData1;
            DBConnection dbConnection = new DBConnection();
            RoadFlow.Data.Model.DBConnection dbconn = dbConnection.Get(connID.ToGuid(), true);
            if (dbconn == null)
                return (JsonData)"";
            using (IDbConnection connection = dbConnection.GetConnection(dbconn))
            {
                if (connection == null)
                    return (JsonData)"";
                try
                {
                    connection.Open();
                }
                catch (Exception ex)
                {
                    HttpContext.Current.Response.Write("连接数据库出错：" + ex.Message);
                    Log.Add(ex);
                }
                string cmdText = string.Empty;
                List<IDataParameter> dataParameterList = new List<IDataParameter>();
                string type = dbconn.Type;
                if (!(type == "SqlServer"))
                {
                    if (!(type == "Oracle"))
                    {
                        if (type == "MySql")
                        {
                            cmdText = string.Format("SELECT * FROM {0} WHERE {1}=@fieldvalue {2}", (object)secondTable, (object)relationField, sortField.IsNullOrEmpty() ? (object)"" : (object)("ORDER BY " + sortField));
                            dataParameterList.Add((IDataParameter)new MySqlParameter("@fieldvalue", (object)fieldValue));
                        }
                    }
                    else
                    {
                        cmdText = string.Format("SELECT * FROM {0} WHERE {1}=:fieldvalue {2}", (object)secondTable, (object)relationField, sortField.IsNullOrEmpty() ? (object)"" : (object)("ORDER BY " + sortField));
                        dataParameterList.Add((IDataParameter)new OracleParameter(":fieldvalue", (object)fieldValue));
                    }
                }
                else
                {
                    cmdText = string.Format("SELECT * FROM {0} WHERE {1}=@fieldvalue {2}", (object)secondTable, (object)relationField, sortField.IsNullOrEmpty() ? (object)"" : (object)("ORDER BY " + sortField));
                    dataParameterList.Add((IDataParameter)new SqlParameter("@fieldvalue", (object)fieldValue));
                }
                IDbDataAdapter dataAdapter = dbConnection.GetDataAdapter(connection, dbconn.Type, cmdText, dataParameterList.ToArray());
                DataSet dataSet = new DataSet();
                dataAdapter.Fill(dataSet);
                if (dataAdapter.SelectCommand != null)
                    dataAdapter.SelectCommand.Dispose();
                DataTable table = dataSet.Tables[0];
                JsonData jsonData2 = (JsonData)null;
                if (!fieldFormat.IsNullOrEmpty())
                    jsonData2 = JsonMapper.ToObject(fieldFormat);
                foreach (DataRow row in (InternalDataCollectionBase)table.Rows)
                {
                    JsonData jsonData3 = new JsonData();
                    for (int index1 = 0; index1 < table.Columns.Count; ++index1)
                    {
                        string index2 = secondTable.ToLower() + "_" + table.Columns[index1].ColumnName.ToLower();
                        string str1 = "";
                        if (jsonData2 != null && jsonData2.IsArray)
                        {
                            foreach (JsonData jsonData4 in (IEnumerable)jsonData2)
                            {
                                if (jsonData4.ContainsKey("fieldname") && jsonData4["fieldname"].ToString().Equals(index2, StringComparison.CurrentCultureIgnoreCase))
                                {
                                    str1 = jsonData4["format"].ToString();
                                    break;
                                }
                            }
                        }
                        string str2 = row[table.Columns[index1].ColumnName].ToString();
                        if (!str1.IsNullOrEmpty())
                        {
                            if (str2.IsDecimal())
                                str2 = str2.ToDecimal().ToString(str1);
                            else if (str2.IsDateTime())
                                str2 = str2.ToDateTime().ToString(str1);
                        }
                        jsonData3[index2] = (JsonData)str2;
                    }
                    jsonData1.Add((object)jsonData3);
                }
            }
            return jsonData1;
        }

        public string GetFromFieldData(JsonData jsonData, string table, string field)
        {
            string empty = string.Empty;
            if (jsonData == null || table.IsNullOrEmpty() || field.IsNullOrEmpty())
                return empty;
            string lower = (table + "_" + field).ToLower();
            if (!jsonData.ContainsKey(lower))
                return empty;
            return jsonData[lower].ToString();
        }

        public string GetFieldStatus(string flowID, string stepID)
        {
            Guid test;
            if (!flowID.IsGuid(out test))
            {
                string str = HttpContext.Current.Request.QueryString["programid"];
                if (str.IsGuid())
                    return new ProgramBuilder().GetJsonString(str.ToGuid());
                return "{}";
            }
            WorkFlowInstalled workFlowRunModel = this.GetWorkFlowRunModel(test, true);
            if (workFlowRunModel == null)
                return "{}";
            Guid sid;
            if (!stepID.IsGuid(out sid))
                sid = workFlowRunModel.FirstStepID;
            IEnumerable<Step> source = workFlowRunModel.Steps.Where<Step>((Func<Step, bool>)(p => p.ID == sid));
            if (source.Count<Step>() == 0)
                return "{}";
            IEnumerable<FieldStatus> fieldStatus1 = source.First<Step>().FieldStatus;
            StringBuilder stringBuilder = new StringBuilder("{");
            int num1 = fieldStatus1.Count<FieldStatus>();
            int num2 = 0;
            foreach (FieldStatus fieldStatus2 in fieldStatus1)
            {
                string[] strArray = fieldStatus2.Field.Split('.');
                if (strArray.Length == 3)
                {
                    string str = strArray[1] + "_" + strArray[2];
                    stringBuilder.AppendFormat("\"{0}\":\"{1}\"", (object)str.ToLower(), (object)(fieldStatus2.Status1.ToString() + "_" + (object)fieldStatus2.Check));
                    if (num2++ < num1 - 1)
                        stringBuilder.Append(",");
                }
            }
            return stringBuilder.ToString() + "}";
        }

        public string GetAllChildsIDString(Guid id, bool isSelf = true)
        {
            return new Dictionary().GetAllChildsIDString(id, isSelf);
        }

        public string GetTypeOptions(string value = "")
        {
            return new Dictionary().GetOptionsByCode("FlowTypes", Dictionary.OptionValueField.ID, value, "", true);
        }

        public List<RoadFlow.Data.Model.WorkFlow> GetByTypes(string typeString)
        {
            return this.dataWorkFlow.GetByTypes(typeString);
        }

        public string GetFlowIDFromType(Guid typeID)
        {
            List<RoadFlow.Data.Model.WorkFlow> byTypes = this.GetByTypes(this.GetAllChildsIDString(typeID, true));
            StringBuilder stringBuilder = new StringBuilder();
            foreach (RoadFlow.Data.Model.WorkFlow workFlow in byTypes)
            {
                stringBuilder.Append((object)workFlow.ID);
                stringBuilder.Append(",");
            }
            return stringBuilder.ToString().TrimEnd(',');
        }

        public string GetFlowTypeOptions(string type)
        {
            return Tools.GetOptionsString(new List<ListItem>() { new ListItem("常规流程", "0") { Selected = "0" == type }, new ListItem("自由流程", "1") { Selected = "1" == type } }.ToArray());
        }

        public Step GetFreeFlowStep(WorkFlowInstalled wfInstalled)
        {
            Step step1 = new Step();
            IEnumerable<Step> source = wfInstalled.Steps.Where<Step>((Func<Step, bool>)(p => p.ID == wfInstalled.FirstStepID));
            if (source.Count<Step>() == 0)
                return step1;
            Step step2 = source.First<Step>();
            step2.ID = Guid.NewGuid();
            step2.Name = wfInstalled.Name + "-审核";
            step2.Buttons = (IEnumerable<RoadFlow.Data.Model.WorkFlowInstalledSub.StepSet.Button>)new List<RoadFlow.Data.Model.WorkFlowInstalledSub.StepSet.Button>()
      {
        new RoadFlow.Data.Model.WorkFlowInstalledSub.StepSet.Button()
        {
          ID = "3B271F67-0433-4082-AD1A-8DF1B967B879",
          Note = "保存",
          Sort = 0
        },
        new RoadFlow.Data.Model.WorkFlowInstalledSub.StepSet.Button()
        {
          ID = "86B7FA6C-891F-4565-9309-81672D3BA80A",
          Note = "退回",
          Sort = 1
        },
        new RoadFlow.Data.Model.WorkFlowInstalledSub.StepSet.Button()
        {
          ID = "8982B97C-ADBA-4A3A-AFD9-9A3EF6FF12D8",
          Note = "发送",
          Sort = 2
        },
        new RoadFlow.Data.Model.WorkFlowInstalledSub.StepSet.Button() { ID = "other_splitline", Note = "", Sort = 3 },
        new RoadFlow.Data.Model.WorkFlowInstalledSub.StepSet.Button()
        {
          ID = "954EFFA8-03B8-461A-AAA8-8727D090DCB9",
          Note = "结束流程",
          Sort = 4
        }
      };
            return step2;
        }

        public List<RoadFlow.Data.Model.WorkFlow> GetPagerData(out string pager, string query = "", string userid = "", string typeid = "", string name = "", int pagesize = 15)
        {
            return this.dataWorkFlow.GetPagerData(out pager, query, userid, typeid, name, pagesize);
        }

        public List<RoadFlow.Data.Model.WorkFlow> GetPagerData(out long count, int pageSize, int pageNumber, string userid = "", string typeid = "", string name = "", string order = "")
        {
            return this.dataWorkFlow.GetPagerData(out count, pageSize, pageNumber, userid, typeid, name, order);
        }

        public List<WorkFlowStart> GetUserStartFlows(Guid userID)
        {
            return this.GetAllStartFlows().FindAll((Predicate<WorkFlowStart>)(p =>
            {
                if (!p.StartUsers.IsNullOrEmpty())
                    return p.StartUsers.Contains(userID.ToString(), StringComparison.CurrentCultureIgnoreCase);
                return true;
            }));
        }

        public List<WorkFlowStart> GetAllStartFlows()
        {
            string key = Keys.CacheKeys.WorkFlowInstalled_.ToString() + "_StartFlows";
            object obj = Opation.Get(key);
            if (obj != null && obj is List<WorkFlowStart>)
                return (List<WorkFlowStart>)obj;
            List<RoadFlow.Data.Model.WorkFlow> all = this.GetAllFromCache().FindAll((Predicate<RoadFlow.Data.Model.WorkFlow>)(p => p.Status == 2));
            Organize organize = new Organize();
            Users users1 = new Users();
            Dictionary dictionary = new Dictionary();
            AppLibrary appLibrary = new AppLibrary();
            List<WorkFlowStart> workFlowStartList = new List<WorkFlowStart>();
            foreach (RoadFlow.Data.Model.WorkFlow workFlow in all)
            {
                WorkFlowInstalled wfRunInstance = this.GetWorkFlowRunModel(workFlow.ID, true);
                if (wfRunInstance != null)
                {
                    IEnumerable<Step> source = wfRunInstance.Steps.Where<Step>((Func<Step, bool>)(p => p.ID == wfRunInstance.FirstStepID));
                    if (source.Count<Step>() != 0)
                    {
                        Step step = source.First<Step>();
                        RoadFlow.Data.Model.AppLibrary byCode = appLibrary.GetByCode(workFlow.ID.ToString(), true);
                        WorkFlowStart workFlowStart1 = new WorkFlowStart();
                        workFlowStart1.ID = workFlow.ID;
                        workFlowStart1.Name = workFlow.Name;
                        workFlowStart1.StartUsers = organize.GetAllUsersIdString(step.Behavior.DefaultHandler);
                        workFlowStart1.Type = dictionary.GetTitle(workFlow.Type);
                        workFlowStart1.InstallDate = workFlow.InstallDate.HasValue ? workFlow.InstallDate.Value.ToShortDateString() : "";
                        WorkFlowStart workFlowStart2 = workFlowStart1;
                        Guid? installUserId = workFlow.InstallUserID;
                        string str;
                        if (!installUserId.HasValue)
                        {
                            str = "";
                        }
                        else
                        {
                            Users users2 = users1;
                            installUserId = workFlow.InstallUserID;
                            Guid id = installUserId.Value;
                            str = users2.GetName(id);
                        }
                        workFlowStart2.InstallUserName = str;
                        if (byCode != null)
                        {
                            workFlowStart1.OpenMode = byCode.OpenMode;
                            WorkFlowStart workFlowStart3 = workFlowStart1;
                            int? nullable = byCode.Width;
                            int num1;
                            if (!nullable.HasValue)
                            {
                                num1 = 0;
                            }
                            else
                            {
                                nullable = byCode.Width;
                                num1 = nullable.Value;
                            }
                            workFlowStart3.WindowWidth = num1;
                            WorkFlowStart workFlowStart4 = workFlowStart1;
                            nullable = byCode.Height;
                            int num2;
                            if (!nullable.HasValue)
                            {
                                num2 = 0;
                            }
                            else
                            {
                                nullable = byCode.Height;
                                num2 = nullable.Value;
                            }
                            workFlowStart4.WindowHeight = num2;
                            workFlowStart1.Params = byCode.Params;
                        }
                        workFlowStartList.Add(workFlowStart1);
                    }
                }
            }
            Opation.Set(key, (object)workFlowStartList);
            return workFlowStartList;
        }

        public void ClearStartFlowsCache()
        {
            Opation.Remove(Keys.CacheKeys.WorkFlowInstalled_.ToString() + "_StartFlows");
        }

        public string GetWorkFlowXml(Guid flowID)
        {
            RoadFlow.Data.Model.WorkFlow workFlow = this.Get(flowID);
            if (workFlow == null)
                return "";
            StringBuilder stringBuilder = new StringBuilder();
            stringBuilder.Append("<?xml version=\"1.0\" encoding=\"UTF-8\"?>");
            stringBuilder.Append("<WorkFlow>");
            stringBuilder.Append("<ID>" + workFlow.ID.ToString() + "</ID>");
            stringBuilder.Append("<Name><![CDATA[" + workFlow.Name + "]]></Name>");
            stringBuilder.Append("<Type>" + workFlow.Type.ToString() + "</Type>");
            stringBuilder.Append("<Manager>" + workFlow.Manager + "</Manager>");
            stringBuilder.Append("<InstanceManager>" + workFlow.Manager + "</InstanceManager>");
            stringBuilder.Append("<CreateDate>" + workFlow.CreateDate.ToDateTimeStringS() + "</CreateDate>");
            stringBuilder.Append("<CreateUserID>" + workFlow.CreateUserID.ToString() + "</CreateUserID>");
            stringBuilder.Append("<DesignJSON><![CDATA[" + workFlow.DesignJSON + "]]></DesignJSON>");
            stringBuilder.Append("<InstallDate>" + (workFlow.InstallDate.HasValue ? workFlow.InstallDate.Value.ToDateTimeStringS() : "") + "</InstallDate>");
            stringBuilder.Append("<InstallUserID>" + workFlow.InstallUserID.ToString() + "</InstallUserID>");
            stringBuilder.Append("<RunJSON><![CDATA[" + workFlow.RunJSON + "]]></RunJSON>");
            stringBuilder.Append("<Status>" + workFlow.Status.ToString() + "</Status>");
            stringBuilder.Append("</WorkFlow>");
            return stringBuilder.ToString();
        }

        public string Export(Guid flowID, int type = 0)
        {
            WorkFlowInstalled workFlowRunModel = this.GetWorkFlowRunModel(flowID, true);
            if (workFlowRunModel == null)
                return "";
            string name = workFlowRunModel.Name;
            string path = Config.FilePath + "WorkFlowExportFiles\\" + Guid.NewGuid().ToString("N") + "\\";
            if (!Directory.Exists(path))
                Directory.CreateDirectory(path);
            List<FileInfo> fileNames = new List<FileInfo>();
            string str1 = path + "FlowDesigner_" + flowID.ToString() + ".xml";
            if (File.Exists(str1))
                File.Delete(str1);
            string workFlowXml = this.GetWorkFlowXml(flowID);
            FileStream fileStream1 = new FileStream(str1, FileMode.Append);
            StreamWriter streamWriter1 = new StreamWriter((Stream)fileStream1, Encoding.UTF8);
            streamWriter1.Write(workFlowXml);
            streamWriter1.Flush();
            streamWriter1.Close();
            fileStream1.Close();
            fileNames.Add(new FileInfo(str1));
            List<Form> formList = new List<Form>();
            foreach (Step step in workFlowRunModel.Steps)
            {
                foreach (Form form1 in step.Forms)
                {
                    Form form = form1;
                    if (formList.Find((Predicate<Form>)(p => p.ID == form.ID)) == null)
                        formList.Add(form);
                }
            }
            WorkFlowForm workFlowForm1 = new WorkFlowForm();
            AppLibrary appLibrary1 = new AppLibrary();
            foreach (Form form in formList)
            {
                RoadFlow.Data.Model.AppLibrary appLibrary2 = appLibrary1.Get(form.ID, false);
                if (appLibrary2 != null)
                {
                    RoadFlow.Data.Model.WorkFlowForm workFlowForm2 = workFlowForm1.Get(appLibrary2.Code.ToGuid());
                    if (workFlowForm2 != null)
                    {
                        string str2 = path;
                        string str3 = "FlowFormDesigner_";
                        Guid id1 = form.ID;
                        string str4 = id1.ToString();
                        string str5 = ".xml";
                        string str6 = str2 + str3 + str4 + str5;
                        if (File.Exists(str6))
                            File.Delete(str6);
                        WorkFlowForm workFlowForm3 = workFlowForm1;
                        Guid id2 = workFlowForm2.ID;
                        id1 = appLibrary2.ID;
                        string applibaryID = id1.ToString();
                        string workFlowFormXml = workFlowForm3.GetWorkFlowFormXml(id2, applibaryID);
                        FileStream fileStream2 = new FileStream(str6, FileMode.Append);
                        StreamWriter streamWriter2 = new StreamWriter((Stream)fileStream2, Encoding.UTF8);
                        streamWriter2.Write(workFlowFormXml);
                        streamWriter2.Flush();
                        streamWriter2.Close();
                        fileStream2.Close();
                        fileNames.Add(new FileInfo(str6));
                        if (workFlowForm2.Status == 1)
                        {
                            string str7;
                            if (type != 0)
                            {
                                string str8 = HttpContext.Current.Server.MapPath("/Views/WorkFlowFormDesigner/Forms/");
                                string str9 = "\\";
                                id1 = workFlowForm2.ID;
                                string str10 = id1.ToString();
                                string str11 = ".cshtml";
                                str7 = str8 + str9 + str10 + str11;
                            }
                            else
                            {
                                string str8 = HttpContext.Current.Server.MapPath("/Platform/WorkFlowFormDesigner/Forms/");
                                string str9 = "\\";
                                id1 = workFlowForm2.ID;
                                string str10 = id1.ToString();
                                string str11 = ".aspx";
                                str7 = str8 + str9 + str10 + str11;
                            }
                            string str12 = str7;
                            if (File.Exists(str12))
                                fileNames.Add(new FileInfo(str12));
                        }
                    }
                }
            }
            string GzipFileName = path + name + "_" + (object)flowID + ".zip";
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
                Log.Add("解压文件出错-" + zipFile, contents, Log.Types.其它分类, "", "", (RoadFlow.Data.Model.Users)null);
                return "解压文件出错!";
            }
            string[] files = Directory.GetFiles(str1);
            string str2 = string.Empty;
            IEnumerable<string> source = ((IEnumerable<string>)files).Where<string>((Func<string, bool>)(p => Path.GetFileName(p).StartsWith("FlowDesigner_")));
            if (source.Count<string>() > 0)
            {
                XElement root = XDocument.Load(source.First<string>()).Root;
                Guid guid = root.Element((XName)"ID") != null ? root.Element((XName)"ID").Value.ToGuid() : Guid.Empty;
                str2 = root.Element((XName)"Name") != null ? root.Element((XName)"Name").Value : "";
                if (root.Element((XName)"Type") == null)
                {
                    Guid empty = Guid.Empty;
                }
                else
                    root.Element((XName)"Type").Value.ToGuid();
                string str3 = root.Element((XName)"Manager") != null ? root.Element((XName)"Manager").Value : "";
                string str4 = root.Element((XName)"InstanceManager") != null ? root.Element((XName)"InstanceManager").Value : "";
                string str5 = root.Element((XName)"CreateDate") != null ? root.Element((XName)"CreateDate").Value : "";
                string str6 = root.Element((XName)"CreateUserID") != null ? root.Element((XName)"CreateUserID").Value : "";
                string str7 = root.Element((XName)"DesignJSON") != null ? root.Element((XName)"DesignJSON").Value : "";
                string str8 = root.Element((XName)"InstallDate") != null ? root.Element((XName)"InstallDate").Value : "";
                string str9 = root.Element((XName)"InstallUserID") != null ? root.Element((XName)"InstallUserID").Value : "";
                string str10 = root.Element((XName)"RunJSON") != null ? root.Element((XName)"RunJSON").Value : "";
                int num = root.Element((XName)"Status") != null ? root.Element((XName)"Status").Value.ToInt() : 1;
                if (!guid.IsEmptyGuid() || !str2.IsNullOrEmpty())
                {
                    RoadFlow.Data.Model.WorkFlow model = this.Get(guid);
                    bool flag = false;
                    if (model == null)
                    {
                        model = new RoadFlow.Data.Model.WorkFlow();
                        flag = true;
                    }
                    model.CreateDate = str5.IsDateTime() ? str5.ToDateTime() : DateTimeNew.Now;
                    model.CreateUserID = str6.IsGuid() ? str6.ToGuid() : Users.CurrentUserID;
                    model.DesignJSON = str7;
                    model.ID = guid;
                    model.InstallDate = new DateTime?(str8.IsDateTime() ? str8.ToDateTime() : DateTimeNew.Now);
                    if (str9.IsGuid())
                        model.InstallUserID = new Guid?(str9.ToGuid());
                    model.InstanceManager = str4;
                    model.Manager = str3;
                    model.Name = str2;
                    model.RunJSON = str10;
                    model.Status = num;
                    if (flag)
                        this.Add(model);
                    else
                        this.Update(model);
                }
            }
            IEnumerable<string> strings = ((IEnumerable<string>)files).Where<string>((Func<string, bool>)(p => Path.GetFileName(p).StartsWith("FlowFormDesigner_")));
            WorkFlowForm workFlowForm = new WorkFlowForm();
            foreach (string str3 in strings)
            {
                string[] strArray = Path.GetFileNameWithoutExtension(str3).Split('_');
                string empty1 = string.Empty;
                if (strArray.Length > 1)
                    empty1 = strArray[1];
                if (!empty1.IsNullOrEmpty() && workFlowForm.AddFromXmlFile(str3, type))
                {
                    string empty2 = string.Empty;
                    string empty3 = string.Empty;
                    string str4;
                    string destFileName;
                    if (type == 0)
                    {
                        str4 = Path.GetDirectoryName(str3) + "\\" + empty1 + ".aspx";
                        destFileName = HttpContext.Current.Server.MapPath("/Platform/WorkFlowFormDesigner/Forms/") + "\\" + empty1 + ".aspx";
                    }
                    else
                    {
                        str4 = Path.GetDirectoryName(str3) + "\\" + empty1 + ".cshtml";
                        destFileName = HttpContext.Current.Server.MapPath("/Views/WorkFlowFormDesigner/Forms/") + "\\" + empty1 + ".cshtml";
                    }
                    if (File.Exists(str4))
                        File.Copy(str4, destFileName, true);
                }
            }
            Log.Add("导入了流程-" + str2, zipFile, Log.Types.流程相关, "", "", (RoadFlow.Data.Model.Users)null);
            return "1";
        }

        public List<Step> getBetweenSteps(WorkFlowInstalled runModel, Guid stepID1, Guid stepID2)
        {
            List<Step> steps = new List<Step>();
            this.addBetweenSteps(steps, runModel, stepID1, stepID2);
            return steps;
        }

        private void addBetweenSteps(List<Step> steps, WorkFlowInstalled runModel, Guid stepID1, Guid stepID2)
        {
            List<Step> list = runModel.Steps.ToList<Step>();
            foreach (Line line1 in runModel.Lines)
            {
                Line line = line1;
                if (line.ToID == stepID2)
                {
                    Step step = list.Find((Predicate<Step>)(p => p.ID == line.FromID));
                    if (step == null || !(step.ID != stepID1))
                        break;
                    steps.Add(step);
                    this.addBetweenSteps(steps, runModel, stepID1, step.ID);
                }
            }
        }
    }
}