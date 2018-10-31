// Decompiled with JetBrains decompiler
// Type: WebMvc.Controllers.WorkFlowTasksController
// Assembly: WebMvc, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 43FD7615-6DC3-49FB-B263-7F7CC91AFA77
// Assembly location: C:\inetpub\wwwroot\RoadFlowMvc\bin\WebMvc.dll

using LitJson;
using Microsoft.CSharp.RuntimeBinder;
using RoadFlow.Data.Model;
using RoadFlow.Utility;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Web.Mvc;

namespace WebMvc.Controllers
{
    public class WorkFlowTasksController : MyController
    {
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult Instance()
        {
            return View();
        }

        public ActionResult InstanceTree()
        {
            return View();
        }

        public ActionResult InstanceList()
        {
            new RoadFlow.Platform.WorkFlowTask();
            RoadFlow.Platform.WorkFlow workFlow = new RoadFlow.Platform.WorkFlow();
            string text = base.Request.QueryString["typeid"];
            Dictionary<Guid, string> instanceManageFlowIDList = workFlow.GetInstanceManageFlowIDList(RoadFlow.Platform.Users.CurrentUserID, text);
            string options = workFlow.GetOptions(instanceManageFlowIDList, text);
            string text2 = string.Format("&appid={0}&tabid={1}&typeid={2}", base.Request.QueryString["appid"], base.Request.QueryString["tabid"], text);
            List<SelectListItem> list = new List<SelectListItem>();
            list.Add(new SelectListItem
            {
                Text = "==全部==",
                Value = "0"
            });
            list.Add(new SelectListItem
            {
                Text = "未完成",
                Value = "1"
            });
            list.Add(new SelectListItem
            {
                Text = "已完成",
                Value = "2"
            });
            base.ViewBag.Query = text2;
            base.ViewBag.StatusItems = list;
            base.ViewBag.FlowOptions = options;
            return View();
        }

        public ActionResult InstanceManage()
        {
            RoadFlow.Platform.WorkFlowTask workFlowTask = new RoadFlow.Platform.WorkFlowTask();
            RoadFlow.Platform.WorkFlow workFlow = new RoadFlow.Platform.WorkFlow();
            string text = base.Request.QueryString["flowid1"];
            string text2 = base.Request.QueryString["groupid"];
            WorkFlowInstalled workFlowRunModel = workFlow.GetWorkFlowRunModel(text);
            IOrderedEnumerable<RoadFlow.Data.Model.WorkFlowTask> orderedEnumerable = from p in workFlowTask.GetTaskList(MyExtensions.ToGuid(text), MyExtensions.ToGuid(text2))
                                                                                     orderby p.Sort
                                                                                     select p;
            JsonData jsonData = new JsonData();
            foreach (RoadFlow.Data.Model.WorkFlowTask item in orderedEnumerable)
            {
                StringBuilder stringBuilder = new StringBuilder();
                stringBuilder.Append("<a style=\"background:url(" + base.Url.Content("~/Images/ico/permission.gif") + ") no-repeat left center; padding-left:18px;\" href=\"javascript:void(0);\" onclick=\"cngStatus('" + item.ID + "');\">状态</a>");
                if (MyExtensions.In(item.Status, new int[2]
                {
                0,
                1
                }))
                {
                    stringBuilder.Append("<a style=\"background:url(" + base.Url.Content("~/Images/ico/arrow_medium_lower_left.png") + ") no-repeat left center; padding-left:16px;\" href=\"javascript:void(0);\" onclick=\"designate('" + item.ID + "');\">指派</a>");
                    stringBuilder.Append("<a style=\"background:url(" + base.Url.Content("~/Images/ico/arrow_medium_lower_right.png") + ") no-repeat left center; padding-left:16px;\" href=\"javascript:void(0);\" onclick=\"goTo('" + item.ID + "');\">跳转</a>");
                }
                JsonData jsonData2 = new JsonData();
                jsonData2["id"] = item.ID.ToString();
                jsonData2["StepID"] = workFlow.GetStepName(item.StepID, workFlowRunModel);
                jsonData2["SenderName"] = item.SenderName;
                jsonData2["ReceiveTime"] = MyExtensions.ToDateTimeStringS(item.ReceiveTime);
                jsonData2["ReceiveName"] = item.ReceiveName;
                jsonData2["CompletedTime1"] = (item.CompletedTime1.HasValue ? MyExtensions.ToDateTimeStringS(item.CompletedTime1.Value) : "");
                jsonData2["Status"] = workFlowTask.GetStatusTitle(item.Status);
                jsonData2["Comment"] = item.Comment;
                jsonData2["Opation"] = stringBuilder.ToString();
                jsonData.Add(jsonData2);
            }
            base.ViewBag.list = jsonData.ToJson();
            return View();
        }

        [MyAttribute(CheckApp = false, CheckLogin = false)]
        public ActionResult Designate()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        [MyAttribute(CheckApp = false, CheckLogin = false)]
        public ActionResult Designate(FormCollection collection)
        {
            Guid guid = default(Guid);
            if (MyExtensions.IsGuid(base.Request.QueryString["taskid"], ref guid))
            {
                string idString = base.Request.Form["user"];
                string text = base.Request.QueryString["openerid"];
                RoadFlow.Platform.WorkFlowTask workFlowTask = new RoadFlow.Platform.WorkFlowTask();
                List<RoadFlow.Data.Model.Users> allUsers = new RoadFlow.Platform.Organize().GetAllUsers(idString);
                StringBuilder stringBuilder = new StringBuilder();
                foreach (RoadFlow.Data.Model.Users item in allUsers)
                {
                    workFlowTask.DesignateTask(guid, item);
                    RoadFlow.Platform.Log.Add("管理员指派了流程任务", "将任务" + guid + "指派给了：" + item.Name + item.ID, RoadFlow.Platform.Log.Types.流程相关);
                    stringBuilder.Append(item.Name);
                    stringBuilder.Append(",");
                }
                string str = stringBuilder.ToString().TrimEnd(',');
                base.ViewBag.Script = "alert('已成功指派给：" + str + "!');new RoadUI.Window().reloadOpener();new RoadUI.Window().close();";
            }
            return View();
        }

        public string Delete()
        {
            string text = base.Request.QueryString["flowid1"];
            string text2 = base.Request.QueryString["groupid"];
            Guid flowID = default(Guid);
            Guid groupID = default(Guid);
            if (MyExtensions.IsGuid(text, ref flowID) && MyExtensions.IsGuid(text2, ref groupID))
            {
                StringBuilder stringBuilder = new StringBuilder();
                foreach (RoadFlow.Data.Model.WorkFlowTask task in new RoadFlow.Platform.WorkFlowTask().GetTaskList(flowID, groupID))
                {
                    stringBuilder.Append(MyExtensions.Serialize((object)task));
                }
                new RoadFlow.Platform.WorkFlowTask().DeleteInstance(flowID, groupID);
                RoadFlow.Platform.Log.Add("管理员删除了流程实例", stringBuilder.ToString(), RoadFlow.Platform.Log.Types.流程相关);
                return "删除成功!";
            }
            return "参数错误!";
        }

        [MyAttribute(CheckApp = false)]
        public ActionResult WaitList()
        {
            RoadFlow.Platform.WorkFlow workFlow = new RoadFlow.Platform.WorkFlow();
            base.ViewBag.flowOptions = workFlow.GetOptions();
            string text = string.Format("&appid={0}&tabid={1}", base.Request.QueryString["appid"], base.Request.QueryString["tabid"]);
            base.ViewBag.query = text;
            return View();
        }

        [MyAttribute(CheckApp = false)]
        public ActionResult CompletedList()
        {
            new RoadFlow.Platform.WorkFlowTask();
            RoadFlow.Platform.WorkFlow workFlow = new RoadFlow.Platform.WorkFlow();
            string text = string.Format("&appid={0}&tabid={1}", base.Request.QueryString["appid"], base.Request.QueryString["tabid"]);
            base.ViewBag.flowOptions = workFlow.GetOptions();
            base.ViewBag.query = text;
            return View();
        }

        [MyAttribute(CheckApp = false, CheckLogin = false)]
        public ActionResult Detail()
        {
            RoadFlow.Platform.WorkFlowTask workFlowTask = new RoadFlow.Platform.WorkFlowTask();
            RoadFlow.Platform.WorkFlow workFlow = new RoadFlow.Platform.WorkFlow();
            string text = base.Request.QueryString["flowid1"] ?? base.Request.QueryString["flowid"];
            string text2 = base.Request.QueryString["groupid"];
            string text3 = base.Request.QueryString["displaymodel"];
            WorkFlowInstalled workFlowRunModel = workFlow.GetWorkFlowRunModel(text);
            IOrderedEnumerable<RoadFlow.Data.Model.WorkFlowTask> orderedEnumerable = from p in workFlowTask.GetTaskList(MyExtensions.ToGuid(text), MyExtensions.ToGuid(text2))
                                                                                     where p.Status != -1
                                                                                     orderby p.Sort, p.StepSort
                                                                                     select p;
            string text4 = string.Format("&flowid1={0}&groupid={1}&appid={2}&tabid={3}&iframeid={4}&openerid={5}", text, text2, base.Request.QueryString["appid"], base.Request.QueryString["tabid"], base.Request.QueryString["iframeid"], base.Request.QueryString["openerid"]);
            string text5 = string.Format("&groupid={0}&appid={1}&tabid={2}&ismobile={3}", text2, base.Request.QueryString["appid"], base.Request.QueryString["tabid"], base.Request.QueryString["ismobile"]);
            base.ViewBag.flowid = text;
            base.ViewBag.groupid = text2;
            base.ViewBag.displayModel = text3;
            base.ViewBag.wfInstall = workFlowRunModel;
            base.ViewBag.query = text4;
            base.ViewBag.query1 = text5;
            JsonData jsonData = new JsonData();
            foreach (RoadFlow.Data.Model.WorkFlowTask item in orderedEnumerable)
            {
                JsonData jsonData2 = new JsonData();
                jsonData2["StepName"] = item.StepName;
                jsonData2["SenderName"] = item.SenderName;
                jsonData2["SenderTime"] = MyExtensions.ToDateTimeStringS(item.SenderTime);
                jsonData2["ReceiveName"] = item.ReceiveName;
                jsonData2["CompletedTime1"] = (item.CompletedTime1.HasValue ? MyExtensions.ToDateTimeStringS(item.CompletedTime1.Value) : "");
                jsonData2["StatusTitle"] = workFlowTask.GetStatusTitle(item.Status);
                jsonData2["Comment"] = item.Comment;
                jsonData2["Note"] = item.Note;
                jsonData.Add(jsonData2);
            }
            base.ViewBag.list = (jsonData.IsArray ? jsonData.ToJson() : "{}");
            return View(orderedEnumerable);
        }

        [MyAttribute(CheckApp = false, CheckLogin = false)]
        public ActionResult DetailSubFlow()
        {
            RoadFlow.Platform.WorkFlowTask workFlowTask = new RoadFlow.Platform.WorkFlowTask();
            RoadFlow.Platform.WorkFlow workFlow = new RoadFlow.Platform.WorkFlow();
            string text = string.Format("&flowid1={0}&groupid={1}&appid={2}&tabid={3}&title={4}&flowid={5}&sender={6}&date1={7}&date2={8}&iframeid={9}&openerid={10}&taskid={11}", base.Request.QueryString["flowid"], base.Request.QueryString["groupid"], base.Request.QueryString["appid"], base.Request.QueryString["tabid"], MyExtensions.UrlEncode(base.Request.QueryString["title"]), base.Request.QueryString["flowid"], base.Request.QueryString["sender"], base.Request.QueryString["date1"], base.Request.QueryString["date2"], base.Request.QueryString["iframeid"], base.Request.QueryString["openerid"], base.Request.QueryString["taskid"]);
            base.ViewBag.flowid = base.Request.QueryString["flowid"];
            base.ViewBag.groupid = base.Request.QueryString["groupid"];
            base.ViewBag.displayModel = base.Request.QueryString["displaymodel"];
            base.ViewBag.wfInstall = null;
            base.ViewBag.query = text;
            string text2 = base.Request.QueryString["taskid"];
            string text4 = base.Request.QueryString["displaymodel"];
            if (!MyExtensions.IsGuid(text2))
            {
                return View(new List<RoadFlow.Data.Model.WorkFlowTask>());
            }
            RoadFlow.Data.Model.WorkFlowTask workFlowTask2 = workFlowTask.Get(MyExtensions.ToGuid(text2));
            if (workFlowTask2 == null || MyExtensions.IsNullOrEmpty(workFlowTask2.SubFlowGroupID))
            {
                return View(new List<RoadFlow.Data.Model.WorkFlowTask>());
            }
            List<RoadFlow.Data.Model.WorkFlowTask> list = new List<RoadFlow.Data.Model.WorkFlowTask>();
            string[] array = workFlowTask2.SubFlowGroupID.Split(',');
            foreach (string text3 in array)
            {
                list.AddRange(workFlowTask.GetTaskList(Guid.Empty, MyExtensions.ToGuid(text3)));
            }
            if (list.Count == 0)
            {
                base.Response.Write("未找到任务");
                base.Response.End();
                return null;
            }
            WorkFlowInstalled workFlowRunModel = workFlow.GetWorkFlowRunModel(list.FirstOrDefault().FlowID);
            base.ViewBag.wfInstall = workFlowRunModel;
            base.ViewBag.flowid = list.FirstOrDefault().FlowID.ToString();
            return View(list);
        }

        [MyAttribute(CheckApp = false)]
        public string Withdraw()
        {
            if (!WebMvc.Common.Tools.CheckLogin(out string _) && !RoadFlow.Platform.WeiXin.Organize.CheckLogin())
            {
                return "";
            }
            string text = base.Request.QueryString["taskid"];
            Guid taskID = default(Guid);
            if (!MyExtensions.IsGuid(text, ref taskID))
            {
                return "参数错误!";
            }
            if (new RoadFlow.Platform.WorkFlowTask().HasWithdraw(taskID))
            {
                if (new RoadFlow.Platform.WorkFlowTask().WithdrawTask(taskID))
                {
                    RoadFlow.Platform.Log.Add("收回了任务", "任务ID：" + text, RoadFlow.Platform.Log.Types.流程相关);
                    return "收回成功!";
                }
                return "收回失败!";
            }
            return "该任务不能收回!";
        }

        [MyAttribute(CheckApp = false, CheckLogin = false)]
        public ActionResult ChangeStatus()
        {
            RoadFlow.Platform.WorkFlowTask workFlowTask = new RoadFlow.Platform.WorkFlowTask();
            RoadFlow.Data.Model.WorkFlowTask workFlowTask2 = null;
            string empty = string.Empty;
            empty = base.Request.QueryString["taskid"];
            if (MyExtensions.IsGuid(empty))
            {
                workFlowTask2 = workFlowTask.Get(MyExtensions.ToGuid(empty));
            }
            string text = "";
            if (workFlowTask2 != null)
            {
                text = workFlowTask2.Status.ToString();
            }
            base.ViewBag.Status = text;
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        [MyAttribute(CheckApp = false, CheckLogin = false)]
        public ActionResult ChangeStatus(FormCollection collection)
        {
            RoadFlow.Platform.WorkFlowTask workFlowTask = new RoadFlow.Platform.WorkFlowTask();
            RoadFlow.Data.Model.WorkFlowTask workFlowTask2 = null;
            string text = string.Empty;
            string empty = string.Empty;
            empty = base.Request.QueryString["taskid"];
            if (MyExtensions.IsGuid(empty))
            {
                workFlowTask2 = workFlowTask.Get(MyExtensions.ToGuid(empty));
            }
            if (workFlowTask2 != null)
            {
                text = base.Request.Form["Status"];
                if (MyExtensions.IsInt(text))
                {
                    string oldXML = MyExtensions.Serialize((object)workFlowTask2);
                    workFlowTask2.Status = MyExtensions.ToInt(text);
                    workFlowTask.Update(workFlowTask2);
                    RoadFlow.Platform.Log.Add("改变了流程任务状态", "改变了流程任务状态", RoadFlow.Platform.Log.Types.流程相关, oldXML, MyExtensions.Serialize((object)workFlowTask2));
                    base.ViewBag.Script = "alert('设置成功!');new RoadUI.Window().reloadOpener();new RoadUI.Window().close();";
                }
            }
            base.ViewBag.Status = text;
            return View();
        }

        [MyAttribute(CheckApp = false)]
        public ActionResult Hasten()
        {
            return Hasten(null);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        [MyAttribute(CheckApp = false)]
        public ActionResult Hasten(FormCollection collection)
        {
            if (collection != null)
            {
                string users = base.Request.Form["HastenUsers"];
                string types = base.Request.Form["HastenType"];
                string contents = base.Request.Form["Contents"];
                RoadFlow.Data.Model.WorkFlowTask task = new RoadFlow.Platform.WorkFlowTask().Get(MyExtensions.ToGuid(base.Request.QueryString["taskid"]));
                RoadFlow.Platform.HastenLog.Hasten(types, users, contents, task);
                base.ViewBag.script = "alert('催办成功!');new RoadUI.Window().close()";
            }
            return View();
        }

        [MyAttribute(CheckApp = false)]
        public ActionResult GoTo()
        {
            return GoTo(null);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        [MyAttribute(CheckApp = false)]
        public ActionResult GoTo(FormCollection collection)
        {
            if (collection != null)
            {
                string[] array = (base.Request.Form["step"] ?? "").Split(',');
                Dictionary<Guid, string> dictionary = new Dictionary<Guid, string>();
                string[] array2 = array;
                foreach (string text in array2)
                {
                    if (MyExtensions.IsGuid(text))
                    {
                        string text2 = base.Request.Form["member_" + text];
                        if (!MyExtensions.IsNullOrEmpty(text2))
                        {
                            dictionary.Add(MyExtensions.ToGuid(text), text2);
                        }
                    }
                }
                RoadFlow.Data.Model.WorkFlowTask workFlowTask = null;
                RoadFlow.Platform.WorkFlowTask workFlowTask2 = new RoadFlow.Platform.WorkFlowTask();
                string text3 = base.Request.QueryString["taskid"];
                workFlowTask = workFlowTask2.Get(MyExtensions.ToGuid(text3));
                bool flag = workFlowTask2.GoToTask(workFlowTask, dictionary);
                base.ViewBag.script = "alert('跳转" + (flag ? "成功" : "失败") + "');new RoadUI.Window().reloadOpener();new RoadUI.Window().close();";
            }
            return View();
        }

        [HttpPost]
        [MyAttribute(CheckApp = false)]
        public string deleteTask()
        {
            string text2 = base.Request.QueryString["flowid"];
            string text3 = base.Request.QueryString["groupid"];
            string text = base.Request.QueryString["taskid"];
            RoadFlow.Data.Model.WorkFlowTask workFlowTask = new RoadFlow.Platform.WorkFlowTask().Get(MyExtensions.ToGuid(text));
            if (workFlowTask == null)
            {
                return "未找到当前任务!";
            }
            new RoadFlow.Platform.WorkFlowTask().DeleteInstance(workFlowTask.FlowID, workFlowTask.GroupID);
            RoadFlow.Platform.Log.Add("作废了流程实例-" + workFlowTask.Title, MyExtensions.Serialize((object)workFlowTask), RoadFlow.Platform.Log.Types.流程相关);
            return "作废成功!";
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        [MyAttribute(CheckApp = false)]
        public string QueryWaitList()
        {
            RoadFlow.Platform.WorkFlowTask workFlowTask = new RoadFlow.Platform.WorkFlowTask();
            RoadFlow.Platform.WorkFlow workFlow = new RoadFlow.Platform.WorkFlow();
            RoadFlow.Platform.AppLibrary appLibrary = new RoadFlow.Platform.AppLibrary();
            string text = base.Request.Form["title"];
            string flowid = base.Request.Form["flowid"];
            string sender = base.Request.Form["sender"];
            string date = base.Request.Form["date1"];
            string date2 = base.Request.Form["date2"];
            string text2 = base.Request.Form["sidx"];
            string text3 = base.Request.Form["sord"];
            string text4 = "";
            int pageSize = RoadFlow.Utility.Tools.GetPageSize();
            int pageNumber = RoadFlow.Utility.Tools.GetPageNumber();
            long count;
            List<RoadFlow.Data.Model.WorkFlowTask> obj = workFlowTask.GetTasks(order: (MyExtensions.IsNullOrEmpty(text2) ? "ReceiveTime" : text2) + " " + (MyExtensions.IsNullOrEmpty(text3) ? "asc" : text3), userID: MyController.CurrentUserID, count: out count, size: pageSize, number: pageNumber, title: MyExtensions.Trim1(text), flowid: flowid, sender: sender, date1: date, date2: date2);
            JsonData jsonData = new JsonData();
            Guid currentUserID = MyController.CurrentUserID;
            foreach (RoadFlow.Data.Model.WorkFlowTask item in obj)
            {
                RoadFlow.Data.Model.AppLibrary byCode = appLibrary.GetByCode(item.FlowID.ToString());
                int num = 0;
                int num2 = 1000;
                int num3 = 500;
                if (byCode != null)
                {
                    num = byCode.OpenMode;
                    num2 = (byCode.Width.HasValue ? byCode.Width.Value : 1000);
                    num3 = (byCode.Height.HasValue ? byCode.Height.Value : 500);
                }
                WorkFlowInstalled workFlowRunModel = workFlow.GetWorkFlowRunModel(item.FlowID);
                JsonData jsonData2 = new JsonData();
                jsonData2["id"] = item.ID.ToString();
                jsonData2["FlowName"] = workFlow.GetFlowName(item.FlowID);
                jsonData2["StepName"] = item.StepName;
                jsonData2["Note"] = item.Note;
                jsonData2["ReceiveTime"] = MyExtensions.ToDateTimeString(item.ReceiveTime);
                jsonData2["SenderName"] = item.SenderName;
                if (item.CompletedTime.HasValue)
                {
                    if (item.CompletedTime.Value < DateTimeNew.get_Now())
                    {
                        jsonData2["StatusTitle"] = "<i title=\"已过期\" class=\"fa fa-bell\" style=\"color:red;font-weight:bold;\"><span title=\"要求完成时间：" + MyExtensions.ToDateTimeString(item.CompletedTime.Value) + "\">已过期</span></i>";
                    }
                    else if ((item.CompletedTime.Value - DateTimeNew.get_Now()).Days <= 3)
                    {
                        jsonData2["StatusTitle"] = "<i title=\"即将过期\" class=\"fa fa-bell\" style=\"color:#fd8a02;font-weight:bold;\"><span title=\"要求完成时间：" + MyExtensions.ToDateTimeString(item.CompletedTime.Value) + "\">即将到期</span></i>";
                    }
                    else
                    {
                        jsonData2["StatusTitle"] = "<i title=\"正常\" class=\"fa fa-bell\" style=\"color:#666;font-weight:bold;\"></i><span title=\"要求完成时间：" + MyExtensions.ToDateTimeString(item.CompletedTime.Value) + "\">正常</span></i>";
                    }
                }
                else
                {
                    jsonData2["StatusTitle"] = "<i title=\"正常\" class=\"fa fa-bell\" style=\"color:#666;font-weight:bold;\"></i><span title=\"要求完成时间：无时间要求\">正常</span></i>";
                }
                jsonData2["Title"] = "<a href=\"javascript:void(0);\" class=\"blue\" onclick=\"openTask('/WorkFlowRun/Index?" + $"flowid={item.FlowID}&stepid={item.StepID}&instanceid={item.InstanceID}&taskid={item.ID}&groupid={item.GroupID}&appid={text4}" + "','" + MyExtensions.UrlEncode(MyExtensions.RemoveHTML(item.Title)) + "','" + item.ID + "'," + num + "," + num2 + "," + num3 + ");return false;\">" + MyExtensions.HtmlEncode(item.Title) + "</a>";
                string text5 = "<a href=\"javascript:void(0);\" class=\"editlink\" onclick=\"openTask('/WorkFlowRun/Index?" + $"flowid={item.FlowID}&stepid={item.StepID}&instanceid={item.InstanceID}&taskid={item.ID}&groupid={item.GroupID}&appid={text4}" + "','" + MyExtensions.UrlEncode(MyExtensions.RemoveHTML(item.Title)) + "','" + item.ID + "'," + num + "," + num2 + "," + num3 + ");return false;\">处理</a>&nbsp;&nbsp;<a class=\"viewlink\" href=\"javascript:void(0);\" onclick=\"detail('" + item.FlowID + "','" + item.GroupID + "','" + item.ID + "');return false;\">查看</a>";
                if (workFlowRunModel != null && workFlowRunModel.FirstStepID == item.StepID && item.SenderID == currentUserID)
                {
                    text5 = text5 + "&nbsp;&nbsp;<a class=\"deletelink\" href=\"javascript:void(0);\" onclick=\"delTask('" + item.FlowID + "','" + item.GroupID + "','" + item.ID + "');return false;\">作废</a>";
                }
                jsonData2["Opation"] = text5;
                jsonData.Add(jsonData2);
            }
            return "{\"userdata\":{\"total\":" + count + ",\"pagesize\":" + pageSize + ",\"pagenumber\":" + pageNumber + "},\"rows\":" + jsonData.ToJson() + "}";
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        [MyAttribute(CheckApp = false)]
        public string QueryCompletedList()
        {
            RoadFlow.Platform.WorkFlowTask workFlowTask = new RoadFlow.Platform.WorkFlowTask();
            RoadFlow.Platform.WorkFlow workFlow = new RoadFlow.Platform.WorkFlow();
            RoadFlow.Platform.AppLibrary appLibrary = new RoadFlow.Platform.AppLibrary();
            string text = base.Request.Form["title"];
            string flowid = base.Request.Form["flowid"];
            string sender = base.Request.Form["sender"];
            string date = base.Request.Form["date1"];
            string date2 = base.Request.Form["date2"];
            string text2 = base.Request.Form["sidx"];
            string text3 = base.Request.Form["sord"];
            string text4 = "";
            int pageSize = RoadFlow.Utility.Tools.GetPageSize();
            int pageNumber = RoadFlow.Utility.Tools.GetPageNumber();
            string order = (MyExtensions.IsNullOrEmpty(text2) ? "CompletedTime1" : text2) + " " + (MyExtensions.IsNullOrEmpty(text3) ? "asc" : text3);
            long count;
            List<RoadFlow.Data.Model.WorkFlowTask> tasks = workFlowTask.GetTasks(MyController.CurrentUserID, out count, pageSize, pageNumber, MyExtensions.Trim1(text), flowid, sender, date, date2, 1, order);
            JsonData jsonData = new JsonData();
            foreach (RoadFlow.Data.Model.WorkFlowTask item in tasks)
            {
                bool isHasten = false;
                RoadFlow.Data.Model.AppLibrary byCode = appLibrary.GetByCode(item.FlowID.ToString());
                int num = 0;
                int num2 = 1000;
                int num3 = 500;
                if (byCode != null)
                {
                    num = byCode.OpenMode;
                    num2 = (byCode.Width.HasValue ? byCode.Width.Value : 1000);
                    num3 = (byCode.Height.HasValue ? byCode.Height.Value : 500);
                }
                StringBuilder stringBuilder = new StringBuilder();
                stringBuilder.Append("<a class=\"viewlink\" href=\"javascript:void(0);\" onclick=\"detail('" + item.FlowID + "','" + item.GroupID + "','" + item.ID + "');return false;\">查看</a>");
                if (item.Status == 2 && workFlowTask.HasWithdraw(item.ID, out isHasten))
                {
                    stringBuilder.Append("<a style=\"background:url(" + base.Url.Content("~/Images/ico/back.gif") + ") no-repeat left center; padding-left:18px;margin-left:5px;\" href=\"javascript:void(0);\" onclick=\"withdraw('" + item.ID + "');\">收回</a>");
                }
                if (isHasten)
                {
                    stringBuilder.Append("<a style=\"background:url(" + base.Url.Content("~/Images/ico/comment_reply.png") + ") no-repeat left center; padding-left:18px;margin-left:5px;\" href=\"javascript:void(0);\" onclick=\"hasten('" + item.ID + "');\">催办</a>");
                }
                JsonData jsonData2 = new JsonData();
                jsonData2["id"] = item.ID.ToString();
                jsonData2["FlowName"] = workFlow.GetFlowName(item.FlowID);
                jsonData2["Note"] = item.Note;
                jsonData2["ReceiveTime"] = MyExtensions.ToDateTimeString(item.ReceiveTime);
                jsonData2["CompletedTime"] = (item.CompletedTime1.HasValue ? MyExtensions.ToDateTimeString(item.CompletedTime1.Value) : "");
                jsonData2["SenderName"] = item.SenderName;
                jsonData2["StepName"] = item.StepName;
                jsonData2["Title"] = "<a href=\"javascript:void(0);\" onclick=\"openTask('/WorkFlowRun/Index?" + $"flowid={item.FlowID}&stepid={item.StepID}&instanceid={item.InstanceID}&taskid={item.ID}&groupid={item.GroupID}&appid={text4}&display=1" + "','" + MyExtensions.UrlEncode(MyExtensions.RemoveHTML(item.Title)) + "','" + item.ID + "'," + num + "," + num2 + "," + num3 + ");return false;\">" + MyExtensions.HtmlEncode(item.Title) + "</a>";
                jsonData2["Opation"] = stringBuilder.ToString();
                jsonData.Add(jsonData2);
            }
            return "{\"userdata\":{\"total\":" + count + ",\"pagesize\":" + pageSize + ",\"pagenumber\":" + pageNumber + "},\"rows\":" + jsonData.ToJson() + "}";
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public string QueryInstanceList()
        {
            RoadFlow.Platform.WorkFlowTask workFlowTask = new RoadFlow.Platform.WorkFlowTask();
            RoadFlow.Platform.WorkFlow workFlow = new RoadFlow.Platform.WorkFlow();
            string text = base.Request.Form["Title"];
            string flowid = base.Request.Form["FlowID"];
            string text2 = base.Request.Form["SenderID"];
            string date = base.Request.Form["Date1"];
            string date2 = base.Request.Form["Date2"];
            string text3 = base.Request.Form["Status"];
            string text4 = base.Request.Form["sidx"];
            string text5 = base.Request.Form["sord"];
            string typeID = base.Request.Form["typeid"];
            string text6 = base.Request.Form["appid"];
            Dictionary<Guid, string> instanceManageFlowIDList = workFlow.GetInstanceManageFlowIDList(RoadFlow.Platform.Users.CurrentUserID, typeID);
            List<Guid> list = new List<Guid>();
            foreach (KeyValuePair<Guid, string> item in from p in instanceManageFlowIDList
                                                        orderby p.Value
                                                        select p)
            {
                list.Add(item.Key);
            }
            Guid[] flowID = list.ToArray();
            int pageSize = RoadFlow.Utility.Tools.GetPageSize();
            int pageNumber = RoadFlow.Utility.Tools.GetPageNumber();
            string order = (MyExtensions.IsNullOrEmpty(text4) ? "SenderTime" : text4) + " " + (MyExtensions.IsNullOrEmpty(text5) ? "asc" : text5);
            long count;
            DataTable instances = workFlowTask.GetInstances1(flowID, new Guid[0], MyExtensions.IsNullOrEmpty(text2) ? new Guid[0] : new Guid[1]
            {
            MyExtensions.ToGuid(text2.Replace("u_", ""))
            }, out count, pageSize, pageNumber, MyExtensions.Trim1(text), flowid, date, date2, MyExtensions.ToInt(text3), order);
            JsonData jsonData = new JsonData();
            foreach (DataRow row in instances.Rows)
            {
                RoadFlow.Data.Model.WorkFlowTask lastTask = workFlowTask.GetLastTask(MyExtensions.ToGuid(row["FlowID"].ToString()), MyExtensions.ToGuid(row["GroupID"].ToString()));
                if (lastTask != null)
                {
                    string flowName;
                    string stepName = workFlow.GetStepName(lastTask.StepID, lastTask.FlowID, out flowName);
                    string text7 = $"flowid={lastTask.FlowID}&stepid={lastTask.StepID}&instanceid={lastTask.InstanceID}&taskid={lastTask.ID}&groupid={lastTask.GroupID}&appid={text6}&display=1";
                    StringBuilder stringBuilder = new StringBuilder();
                    stringBuilder.Append("<a style=\"margin-right:5px; background:url(" + base.Url.Content("~/Images/ico/mouse.png") + ") no-repeat left center; padding-left:18px;\" href=\"javascript:void(0);\" onclick=\"manage('" + lastTask.FlowID.ToString() + "','" + lastTask.GroupID.ToString() + "');\">管理</a>");
                    if (MyExtensions.In(lastTask.Status, new int[3]
                    {
                    -1,
                    0,
                    1
                    }))
                    {
                        stringBuilder.Append("<a style=\"background:url(" + base.Url.Content("~/Images/ico/trash.gif") + ") no-repeat left center; padding-left:18px;\" href=\"javascript:void(0);\" onclick=\"delete1('" + lastTask.FlowID.ToString() + "','" + lastTask.GroupID.ToString() + "');\">删除</a>");
                    }
                    JsonData jsonData2 = new JsonData();
                    jsonData2["id"] = lastTask.ID.ToString();
                    jsonData2["Title"] = "<a href=\"javascript:void(0);\" onclick=\"openTask('/WorkFlowRun/Index?" + text7 + "','" + MyExtensions.UrlEncode(MyExtensions.RemoveHTML(lastTask.Title)) + "','" + lastTask.ID + "');return false;\" class=\"blue\">" + MyExtensions.HtmlEncode(lastTask.Title) + "</a>";
                    jsonData2["FlowName"] = flowName;
                    jsonData2["StepName"] = stepName;
                    jsonData2["ReceiveName"] = lastTask.ReceiveName;
                    jsonData2["ReceiveTime"] = MyExtensions.ToDateTimeStringS(lastTask.ReceiveTime);
                    jsonData2["StatusTitle"] = lastTask.Status;
                    jsonData2["Opation"] = stringBuilder.ToString();
                    jsonData.Add(jsonData2);
                }
            }
            return "{\"userdata\":{\"total\":" + count + ",\"pagesize\":" + pageSize + ",\"pagenumber\":" + pageNumber + "},\"rows\":" + jsonData.ToJson() + "}";
        }
    }
}
