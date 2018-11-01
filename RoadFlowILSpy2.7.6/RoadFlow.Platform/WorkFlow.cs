using LitJson;
using MySql.Data.MySqlClient;
using Oracle.ManagedDataAccess.Client;
using RoadFlow.Cache.IO;
using RoadFlow.Data.Factory;
using RoadFlow.Data.Interface;
using RoadFlow.Data.Model;
using RoadFlow.Data.Model.WorkFlowInstalledSub;
using RoadFlow.Data.Model.WorkFlowInstalledSub.StepSet;
using RoadFlow.Utility;
using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.Common;
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
			dataWorkFlow = Factory.GetWorkFlow();
		}

		public int Add(RoadFlow.Data.Model.WorkFlow model)
		{
			return dataWorkFlow.Add(model);
		}

		public int Update(RoadFlow.Data.Model.WorkFlow model)
		{
			return dataWorkFlow.Update(model);
		}

		public List<RoadFlow.Data.Model.WorkFlow> GetAll()
		{
			return dataWorkFlow.GetAll();
		}

		public RoadFlow.Data.Model.WorkFlow Get(Guid id)
		{
			return dataWorkFlow.Get(id);
		}

		public int Delete(Guid id)
		{
			return dataWorkFlow.Delete(id);
		}

		public long GetCount()
		{
			return dataWorkFlow.GetCount();
		}

		public List<string> GetAllTypes()
		{
			return dataWorkFlow.GetAllTypes();
		}

		public string GetAllTypesOptions(string value = "")
		{
			List<string> allTypes = GetAllTypes();
			StringBuilder stringBuilder = new StringBuilder();
			foreach (string item in allTypes)
			{
				stringBuilder.AppendFormat("<option value=\"{0}\" {1}>{0}</option>", item, (item == value) ? "selected=\"selected\"" : "");
			}
			return stringBuilder.ToString();
		}

		public string GetStatusTitle(int status)
		{
			string result = string.Empty;
			switch (status)
			{
			case 1:
				result = "设计中";
				break;
			case 2:
				result = "已安装";
				break;
			case 3:
				result = "已卸载";
				break;
			case 4:
				result = "已删除";
				break;
			case 5:
				result = "等待他人处理";
				break;
			}
			return result;
		}

		public string SaveFlow(string jsonString)
		{
			JsonData jsonData = JsonMapper.ToObject(jsonString);
			string str = jsonData["id"].ToString();
			string text = jsonData["name"].ToString();
			string str2 = jsonData["type"].ToString();
			Guid test;
			if (!str.IsGuid(out test))
			{
				return "请先新建或打开流程!";
			}
			if (!text.IsNullOrEmpty())
			{
				WorkFlow workFlow = new WorkFlow();
				RoadFlow.Data.Model.WorkFlow workFlow2 = workFlow.Get(test);
				bool flag = false;
				if (workFlow2 == null)
				{
					workFlow2 = new RoadFlow.Data.Model.WorkFlow();
					flag = true;
					workFlow2.ID = test;
					workFlow2.CreateDate = DateTimeNew.Now;
					workFlow2.CreateUserID = Users.CurrentUserID;
					workFlow2.Status = 1;
				}
				workFlow2.DesignJSON = jsonString;
				workFlow2.InstanceManager = jsonData["instanceManager"].ToString();
				workFlow2.Manager = jsonData["manager"].ToString();
				workFlow2.Name = text.Trim();
				workFlow2.Type = (str2.IsGuid() ? str2.ToGuid() : new Dictionary().GetIDByCode("FlowTypes"));
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
			string text = SaveFlow(jsonString);
			if ("1" != text)
			{
				return text;
			}
			string errMsg;
			WorkFlowInstalled workFlowRunModel = GetWorkFlowRunModel(jsonString, out errMsg);
			if (workFlowRunModel == null)
			{
				return errMsg;
			}
			RoadFlow.Data.Model.WorkFlow workFlow = dataWorkFlow.Get(workFlowRunModel.ID);
			if (workFlow == null)
			{
				return "流程实体为空";
			}
			using (TransactionScope transactionScope = new TransactionScope())
			{
				workFlow.InstallDate = workFlowRunModel.InstallTime;
				workFlow.InstallUserID = workFlowRunModel.InstallUser.ToGuid();
				workFlow.RunJSON = workFlowRunModel.RunJSON;
				workFlow.Status = 2;
				dataWorkFlow.Update(workFlow);
				workFlowRunModel.Status = 2;
				AppLibrary appLibrary = new AppLibrary();
				RoadFlow.Data.Model.AppLibrary appLibrary2 = appLibrary.GetByCode(workFlowRunModel.ID.ToString());
				bool flag = false;
				if (appLibrary2 == null)
				{
					flag = true;
					appLibrary2 = new RoadFlow.Data.Model.AppLibrary();
					appLibrary2.ID = Guid.NewGuid();
				}
				appLibrary2.Address = (isMvc ? "/WorkFlowRun/Index" : "/Platform/WorkFlowRun/Default.aspx");
				appLibrary2.Code = workFlowRunModel.ID.ToString();
				appLibrary2.Note = "流程应用";
				appLibrary2.OpenMode = 0;
				appLibrary2.Params = "flowid=" + workFlowRunModel.ID.ToString();
				appLibrary2.Title = workFlowRunModel.Name;
				appLibrary2.Type = (workFlowRunModel.Type.IsGuid() ? workFlowRunModel.Type.ToGuid() : new Dictionary().GetIDByCode("FlowTypes"));
				if (flag)
				{
					appLibrary.Add(appLibrary2);
				}
				else
				{
					appLibrary.Update(appLibrary2);
				}
				appLibrary.ClearCache();
				Opation.Set(getCacheKey(workFlowRunModel.ID), workFlowRunModel);
				ClearStartFlowsCache();
				ClaearCache();
				transactionScope.Complete();
				return "1";
			}
		}

		public RoadFlow.Data.Model.WorkFlow SaveAs(Guid flowID, string newName)
		{
			RoadFlow.Data.Model.WorkFlow workFlow = dataWorkFlow.Get(flowID);
			if (workFlow == null || newName.IsNullOrEmpty())
			{
				return workFlow;
			}
			workFlow.ID = Guid.NewGuid();
			workFlow.Name = newName.Trim();
			workFlow.CreateDate = DateTimeNew.Now;
			workFlow.CreateUserID = Users.CurrentUserID;
			workFlow.InstallDate = null;
			workFlow.InstallUserID = null;
			workFlow.RunJSON = null;
			workFlow.Status = 1;
			if (!workFlow.DesignJSON.IsNullOrEmpty())
			{
				JsonData jsonData = JsonMapper.ToObject(workFlow.DesignJSON);
				jsonData["id"] = workFlow.ID.ToString();
				jsonData["name"] = workFlow.Name;
				JsonData jsonData2 = jsonData["steps"];
				JsonData jsonData3 = jsonData["lines"];
				foreach (JsonData item in (IEnumerable)jsonData2)
				{
					string b = item["id"].ToString();
					string data = Guid.NewGuid().ToString();
					item["id"] = data;
					foreach (JsonData item2 in (IEnumerable)jsonData3)
					{
						if (item2["from"].ToString() == b)
						{
							item2["from"] = data;
						}
						if (item2["to"].ToString() == b)
						{
							item2["to"] = data;
						}
					}
				}
				foreach (JsonData item3 in (IEnumerable)jsonData3)
				{
					item3["id"] = Guid.NewGuid().ToString();
				}
				workFlow.DesignJSON = jsonData.ToJson();
			}
			dataWorkFlow.Add(workFlow);
			ClaearCache();
			return workFlow;
		}

		private string getCacheKey(Guid flowID)
		{
			return 6.ToString() + flowID.ToString("N");
		}

		public WorkFlowInstalled GetWorkFlowRunModel(string flowID, bool cache = true)
		{
			Guid test;
			if (!flowID.IsGuid(out test))
			{
				return null;
			}
			return GetWorkFlowRunModel(test, cache);
		}

		public WorkFlowInstalled GetWorkFlowRunModel(Guid flowID, bool cache = true)
		{
			if (!cache)
			{
				return getWorkFlowRunFromDesign(flowID);
			}
			WorkFlowInstalled workFlowInstalled = null;
			string cacheKey = getCacheKey(flowID);
			try
			{
				object obj = Opation.Get(cacheKey);
				if (obj != null)
				{
					workFlowInstalled = (WorkFlowInstalled)obj;
				}
			}
			catch (Exception err)
			{
				workFlowInstalled = null;
				Log.Add(err);
			}
			if (workFlowInstalled == null)
			{
				workFlowInstalled = getWorkFlowRunFromDesign(flowID);
				Opation.Set(cacheKey, workFlowInstalled);
			}
			return workFlowInstalled;
		}

		private WorkFlowInstalled getWorkFlowRunFromDesign(Guid flowID)
		{
			RoadFlow.Data.Model.WorkFlow workFlow = GetFromCache(flowID);
			if (workFlow == null)
			{
				workFlow = Get(flowID);
			}
			if (workFlow == null || workFlow.RunJSON.IsNullOrEmpty())
			{
				return null;
			}
			string errMsg;
			return GetWorkFlowRunModel(workFlow.RunJSON, out errMsg);
		}

		public void ClearWorkFlowCache(Guid flowID)
		{
			Opation.Remove(getCacheKey(flowID));
		}

		public void RefreshWrokFlowCache(Guid flowID)
		{
			Opation.Set(getCacheKey(flowID), GetWorkFlowRunModel(flowID, false));
		}

		public RoadFlow.Data.Model.WorkFlow GetFromCache(Guid flowID)
		{
			return GetAllFromCache().Find((RoadFlow.Data.Model.WorkFlow p) => p.ID == flowID);
		}

		public List<RoadFlow.Data.Model.WorkFlow> GetAllFromCache()
		{
			List<RoadFlow.Data.Model.WorkFlow> list = null;
			string key = 6.ToString();
			object obj = Opation.Get(key);
			if (obj != null)
			{
				try
				{
					list = (List<RoadFlow.Data.Model.WorkFlow>)obj;
				}
				catch
				{
					list = null;
				}
			}
			if (list == null)
			{
				list = GetAll();
				Opation.Set(key, list);
			}
			return list;
		}

		public void ClaearCache()
		{
			Opation.Remove(6.ToString());
		}

		public WorkFlowInstalled GetWorkFlowRunModel(string jsonString, out string errMsg)
		{
			errMsg = "";
			WorkFlowInstalled workFlowInstalled = new WorkFlowInstalled();
			JsonData jsonData = JsonMapper.ToObject(jsonString);
			string str = jsonData["id"].ToString();
			if (!str.IsGuid())
			{
				errMsg = "流程ID错误";
				return null;
			}
			workFlowInstalled.ID = str.ToGuid();
			string text = jsonData["name"].ToString();
			if (text.IsNullOrEmpty())
			{
				errMsg = "流程名称为空";
				return null;
			}
			workFlowInstalled.Name = text.Trim();
			string text2 = jsonData["type"].ToString();
			workFlowInstalled.Type = (text2.IsNullOrEmpty() ? new Dictionary().GetIDByCode("FlowTypes").ToString() : text2.Trim());
			string text3 = jsonData["manager"].ToString();
			if (text3.IsNullOrEmpty())
			{
				errMsg = "流程管理者为空";
				return null;
			}
			workFlowInstalled.Manager = text3;
			string text4 = jsonData["instanceManager"].ToString();
			if (text4.IsNullOrEmpty())
			{
				errMsg = "流程实例管理者为空";
				return null;
			}
			workFlowInstalled.InstanceManager = text4;
			workFlowInstalled.RemoveCompleted = jsonData["removeCompleted"].ToString().ToInt();
			workFlowInstalled.Debug = jsonData["debug"].ToString().ToInt();
			workFlowInstalled.DebugUsers = new Organize().GetAllUsers(jsonData["debugUsers"].ToString());
			workFlowInstalled.Note = jsonData["note"].ToString();
			workFlowInstalled.FlowType = (jsonData.ContainsKey("flowType") ? jsonData["flowType"].ToString().ToInt() : 0);
			List<DataBases> list = new List<DataBases>();
			JsonData jsonData2 = jsonData["databases"];
			if (jsonData2.IsArray)
			{
				foreach (JsonData item in (IEnumerable)jsonData2)
				{
					list.Add(new DataBases
					{
						LinkID = item["link"].ToString().ToGuid(),
						LinkName = item["linkName"].ToString(),
						Table = item["table"].ToString(),
						PrimaryKey = item["primaryKey"].ToString()
					});
				}
			}
			workFlowInstalled.DataBases = list;
			JsonData jsonData4 = jsonData["titleField"];
			if (jsonData4.IsObject)
			{
				workFlowInstalled.TitleField = new TitleField
				{
					Field = jsonData4["field"].ToString(),
					LinkID = jsonData4["link"].ToString().ToGuid(),
					LinkName = "",
					Table = jsonData4["table"].ToString()
				};
			}
			List<Step> list2 = new List<Step>();
			JsonData jsonData5 = jsonData["steps"];
			if (jsonData5.IsArray)
			{
				foreach (JsonData item2 in (IEnumerable)jsonData5)
				{
					JsonData jsonData7 = item2["behavior"];
					Behavior behavior = new Behavior();
					if (jsonData7.IsObject)
					{
						behavior.BackModel = jsonData7["backModel"].ToString().ToInt();
						behavior.BackStepID = jsonData7["backStep"].ToString().ToGuid();
						behavior.BackType = jsonData7["backType"].ToString().ToInt();
						behavior.DefaultHandler = jsonData7["defaultHandler"].ToString();
						behavior.FlowType = jsonData7["flowType"].ToString().ToInt();
						behavior.HandlerStepID = jsonData7["handlerStep"].ToString().ToGuid();
						behavior.HandlerType = jsonData7["handlerType"].ToString().ToInt();
						behavior.HanlderModel = jsonData7["hanlderModel"].ToString().ToInt(3);
						behavior.Percentage = (jsonData7["percentage"].ToString().IsDecimal() ? jsonData7["percentage"].ToString().ToDecimal() : decimal.MinusOne);
						behavior.RunSelect = jsonData7["runSelect"].ToString().ToInt();
						behavior.SelectRange = jsonData7["selectRange"].ToString();
						behavior.ValueField = jsonData7["valueField"].ToString();
						behavior.Countersignature = (jsonData7.ContainsKey("countersignature") ? jsonData7["countersignature"].ToString().ToInt() : 0);
						behavior.CountersignaturePercentage = (jsonData7.ContainsKey("countersignaturePercentage") ? jsonData7["countersignaturePercentage"].ToString().ToDecimal() : decimal.MinusOne);
						behavior.SubFlowStrategy = (jsonData7.ContainsKey("subflowstrategy") ? jsonData7["subflowstrategy"].ToString().ToInt() : (-2147483648));
						behavior.CopyFor = (jsonData7.ContainsKey("copyFor") ? jsonData7["copyFor"].ToString() : "");
						behavior.ConcurrentModel = (jsonData7.ContainsKey("concurrentModel") ? jsonData7["concurrentModel"].ToString().ToInt(0) : 0);
						behavior.DefaultHandlerSqlOrMethod = (jsonData7.ContainsKey("defaultHandlerSqlOrMethod") ? jsonData7["defaultHandlerSqlOrMethod"].ToString() : "");
					}
					JsonData jsonData8 = item2["buttons"];
					List<RoadFlow.Data.Model.WorkFlowInstalledSub.StepSet.Button> list3 = new List<RoadFlow.Data.Model.WorkFlowInstalledSub.StepSet.Button>();
					if (jsonData8.IsArray)
					{
						foreach (JsonData item3 in (IEnumerable)jsonData8)
						{
							string text5 = item3["id"].ToString();
							if (text5.IsGuid())
							{
								RoadFlow.Data.Model.WorkFlowButtons workFlowButtons = new WorkFlowButtons().Get(text5.ToGuid(), true);
								if (workFlowButtons != null)
								{
									list3.Add(new RoadFlow.Data.Model.WorkFlowInstalledSub.StepSet.Button
									{
										ID = text5,
										Note = (workFlowButtons.Note.IsNullOrEmpty() ? "" : workFlowButtons.Note.Replace("\"", "'")),
										Sort = item3["sort"].ToString().ToInt(),
										ShowTitle = (item3.ContainsKey("showTitle") ? item3["showTitle"].ToString() : "")
									});
								}
							}
							else
							{
								list3.Add(new RoadFlow.Data.Model.WorkFlowInstalledSub.StepSet.Button
								{
									ID = text5,
									Note = "",
									Sort = item3["sort"].ToString().ToInt(),
									ShowTitle = (item3.ContainsKey("showTitle") ? item3["showTitle"].ToString() : "")
								});
							}
						}
					}
					int count = list3.Count;
					CopyFor copyFor = new CopyFor();
					if (item2.ContainsKey("copyFor"))
					{
						JsonData jsonData10 = item2["copyFor"];
						if (jsonData10.IsObject)
						{
							copyFor.handlerType = jsonData10["handlerType"].ToString();
							copyFor.MemberID = jsonData10["memberId"].ToString();
							copyFor.MethodOrSql = jsonData10["methodOrSql"].ToString();
							copyFor.steps = jsonData10["steps"].ToString();
						}
					}
					JsonData jsonData11 = item2["event"];
					Event @event = new Event();
					if (jsonData11.IsObject)
					{
						@event.BackAfter = jsonData11["backAfter"].ToString();
						@event.BackBefore = jsonData11["backBefore"].ToString();
						@event.SubmitAfter = jsonData11["submitAfter"].ToString();
						@event.SubmitBefore = jsonData11["submitBefore"].ToString();
						@event.SubFlowActivationBefore = (jsonData11.ContainsKey("subflowActivationBefore") ? jsonData11["subflowActivationBefore"].ToString() : "");
						@event.SubFlowCompletedBefore = (jsonData11.ContainsKey("subflowCompletedBefore") ? jsonData11["subflowCompletedBefore"].ToString() : "");
					}
					JsonData jsonData12 = item2["forms"];
					List<Form> list4 = new List<Form>();
					if (jsonData12.IsArray)
					{
						foreach (JsonData item4 in (IEnumerable)jsonData12)
						{
							list4.Add(new Form
							{
								ID = item4["id"].ToString().ToGuid(),
								Name = item4["name"].ToString(),
								IDApp = ((item4.ContainsKey("idApp") && item4["idApp"].ToString().IsGuid()) ? item4["idApp"].ToString().ToGuid() : Guid.Empty),
								NameApp = (item4.ContainsKey("nameApp") ? item4["nameApp"].ToString() : ""),
								Sort = item4["srot"].ToString().ToInt()
							});
						}
					}
					int count2 = list4.Count;
					JsonData jsonData14 = item2["fieldStatus"];
					List<FieldStatus> list5 = new List<FieldStatus>();
					if (jsonData14.IsArray)
					{
						foreach (JsonData item5 in (IEnumerable)jsonData14)
						{
							list5.Add(new FieldStatus
							{
								Check = item5["check"].ToString().ToInt(),
								Field = item5["field"].ToString(),
								Status1 = item5["status"].ToString().ToInt(1)
							});
						}
					}
					JsonData jsonData16 = item2["position"];
					decimal position_x = default(decimal);
					decimal position_y = default(decimal);
					if (jsonData16.IsObject)
					{
						position_x = jsonData16["x"].ToString().ToDecimal();
						position_y = jsonData16["y"].ToString().ToDecimal();
					}
					list2.Add(new Step
					{
						Archives = item2["archives"].ToString().ToInt(),
						ArchivesParams = item2["archivesParams"].ToString(),
						Behavior = behavior,
						Buttons = list3,
						DataSaveType = (item2.ContainsKey("dataSaveType") ? item2["dataSaveType"].ToString().ToInt(0) : 0),
						DataSaveTypeWhere = (item2.ContainsKey("dataSaveTypeWhere") ? item2["dataSaveTypeWhere"].ToString() : ""),
						Event = @event,
						CopyFor = copyFor,
						ExpiredPrompt = item2["expiredPrompt"].ToString().ToInt(),
						Forms = list4,
						FieldStatus = list5,
						ID = item2["id"].ToString().ToGuid(),
						Type = (item2.ContainsKey("type") ? item2["type"].ToString() : "normal"),
						LimitTime = item2["limitTime"].ToString().ToDecimal(),
						Name = item2["name"].ToString(),
						Note = item2["note"].ToString(),
						OpinionDisplay = item2["opinionDisplay"].ToString().ToInt(),
						OtherTime = item2["otherTime"].ToString().ToDecimal(),
						SignatureType = item2["signatureType"].ToString().ToInt(),
						WorkTime = item2["workTime"].ToString().ToDecimal(),
						SubFlowID = (item2.ContainsKey("subflow") ? item2["subflow"].ToString() : ""),
						SubFlowTaskType = (item2.ContainsKey("subflowTaskType") ? item2["subflowTaskType"].ToString().ToInt(0) : 0),
						Position_x = position_x,
						Position_y = position_y,
						SendShowMsg = (item2.ContainsKey("sendShowMsg") ? item2["sendShowMsg"].ToString() : ""),
						BackShowMsg = (item2.ContainsKey("backShowMsg") ? item2["backShowMsg"].ToString() : ""),
						SendSetWorkTime = (item2.ContainsKey("sendSetWorkTime") ? item2["sendSetWorkTime"].ToString().ToInt() : 0),
						TimeOutModel = (item2.ContainsKey("timeOutModel") ? item2["timeOutModel"].ToString().ToInt() : 0)
					});
				}
			}
			int flowType = workFlowInstalled.FlowType;
			workFlowInstalled.Steps = list2;
			if (list2.Count == 0)
			{
				errMsg = "流程至少需要一个步骤";
				return null;
			}
			List<Line> list6 = new List<Line>();
			JsonData jsonData17 = jsonData.ContainsKey("lines") ? jsonData["lines"] : null;
			if (jsonData17 != null && jsonData17.IsArray)
			{
				foreach (JsonData item6 in (IEnumerable)jsonData17)
				{
					list6.Add(new Line
					{
						ID = item6["id"].ToString().ToGuid(),
						FromID = item6["from"].ToString().ToGuid(),
						ToID = item6["to"].ToString().ToGuid(),
						CustomMethod = item6["customMethod"].ToString(),
						SqlWhere = item6["sql"].ToString(),
						NoAccordMsg = (item6.ContainsKey("noaccordMsg") ? item6["noaccordMsg"].ToString() : ""),
						Organize = (item6.ContainsKey("organize") ? item6["organize"].ToJson() : "")
					});
				}
			}
			workFlowInstalled.Lines = list6;
			List<Guid> list7 = new List<Guid>();
			foreach (Step step in workFlowInstalled.Steps)
			{
				if ((from p in workFlowInstalled.Lines
				where p.ToID == step.ID
				select p).Count() == 0)
				{
					list7.Add(step.ID);
				}
			}
			if (list7.Count == 0)
			{
				errMsg = "流程没有开始步骤";
				return null;
			}
			RoadFlow.Data.Model.WorkFlow workFlow = dataWorkFlow.Get(workFlowInstalled.ID);
			if (workFlow != null)
			{
				workFlowInstalled.CreateTime = workFlow.CreateDate;
				workFlowInstalled.CreateUser = workFlow.CreateUserID.ToString();
				workFlowInstalled.DesignJSON = workFlow.DesignJSON;
				workFlowInstalled.FirstStepID = list7.First();
				workFlowInstalled.InstallTime = DateTimeNew.Now;
				workFlowInstalled.InstallUser = Users.CurrentUserID.ToString();
				workFlowInstalled.RunJSON = jsonString;
				workFlowInstalled.Status = workFlow.Status;
			}
			return workFlowInstalled;
		}

		public List<Step> GetAllPrevSteps(Guid flowID, Guid stepID)
		{
			List<Step> list = new List<Step>();
			WorkFlowInstalled workFlowRunModel = GetWorkFlowRunModel(flowID);
			if (workFlowRunModel == null)
			{
				return list;
			}
			addPrevSteps(list, workFlowRunModel, stepID);
			return list.Distinct().ToList();
		}

		private void addPrevSteps(List<Step> list, WorkFlowInstalled wfInstalled, Guid stepID)
		{
			if (wfInstalled != null)
			{
				foreach (Line item in from p in wfInstalled.Lines
				where p.ToID == stepID
				select p)
				{
					IEnumerable<Step> source = wfInstalled.Steps.Where((Step p) => p.ID == item.FromID);
					if (source.Count() > 0)
					{
						list.Add(source.First());
						addPrevSteps(list, wfInstalled, source.First().ID);
					}
				}
			}
		}

		public List<Step> GetPrevSteps(Guid flowID, Guid stepID)
		{
			List<Step> list = new List<Step>();
			WorkFlowInstalled workFlowRunModel = GetWorkFlowRunModel(flowID);
			if (workFlowRunModel == null)
			{
				return list;
			}
			foreach (Line item in from p in workFlowRunModel.Lines
			where p.ToID == stepID
			select p)
			{
				IEnumerable<Step> source = workFlowRunModel.Steps.Where((Step p) => p.ID == item.FromID);
				if (source.Count() > 0)
				{
					list.Add(source.First());
				}
			}
			return list;
		}

		public List<Step> GetNextSteps(Guid flowID, Guid stepID)
		{
			List<Step> list = new List<Step>();
			WorkFlowInstalled workFlowRunModel = GetWorkFlowRunModel(flowID);
			if (workFlowRunModel == null)
			{
				return list;
			}
			foreach (Line item in from p in workFlowRunModel.Lines
			where p.FromID == stepID
			select p)
			{
				IEnumerable<Step> source = workFlowRunModel.Steps.Where((Step p) => p.ID == item.ToID);
				if (source.Count() > 0)
				{
					list.Add(source.First());
				}
			}
			return list;
		}

		public string GetStepName(Guid stepID, Guid flowID, out string flowName, bool defaultFirstStepName = false)
		{
			flowName = "";
			WorkFlowInstalled workFlowRunModel = GetWorkFlowRunModel(flowID);
			if (workFlowRunModel == null)
			{
				return "";
			}
			if (stepID == Guid.Empty && defaultFirstStepName)
			{
				stepID = workFlowRunModel.FirstStepID;
			}
			flowName = workFlowRunModel.Name;
			IEnumerable<Step> source = from p in workFlowRunModel.Steps
			where p.ID == stepID
			select p;
			if (source.Count() <= 0)
			{
				return "";
			}
			return source.First().Name;
		}

		public string GetStepName(Guid stepID, Guid flowID, bool defautFirstStepName = false)
		{
			string flowName;
			return GetStepName(stepID, flowID, out flowName, defautFirstStepName);
		}

		public string GetStepName(Guid stepID, WorkFlowInstalled wfinstalled, bool defautFirstStepName = false)
		{
			if (wfinstalled == null)
			{
				return "";
			}
			if (stepID == Guid.Empty && defautFirstStepName)
			{
				stepID = wfinstalled.FirstStepID;
			}
			IEnumerable<Step> source = from p in wfinstalled.Steps
			where p.ID == stepID
			select p;
			if (source.Count() <= 0)
			{
				return "";
			}
			return source.First().Name;
		}

		public string GetFlowName(Guid flowID)
		{
			RoadFlow.Data.Model.WorkFlow fromCache = GetFromCache(flowID);
			if (fromCache == null)
			{
				return "";
			}
			return fromCache.Name;
		}

		public Dictionary<Guid, string> GetAllIDAndName()
		{
			return dataWorkFlow.GetAllIDAndName();
		}

		public string GetOptions(string value = "")
		{
			Dictionary<Guid, string> allIDAndName = GetAllIDAndName();
			StringBuilder stringBuilder = new StringBuilder();
			foreach (KeyValuePair<Guid, string> item in from p in allIDAndName
			orderby p.Value
			select p)
			{
				stringBuilder.AppendFormat("<option value=\"{0}\" {1}>{2}</option>", item.Key, ("," + value + ",").Contains("," + item.Key.ToString() + ",") ? "selected=\"selected\"" : "", item.Value);
			}
			return stringBuilder.ToString();
		}

		public string GetOptions(Dictionary<Guid, string> flows, string typeid, string value = "")
		{
			StringBuilder stringBuilder = new StringBuilder();
			foreach (KeyValuePair<Guid, string> flow in flows)
			{
				stringBuilder.AppendFormat("<option value=\"{0}\" {1}>{2}</option>", flow.Key, (flow.Key.ToString() == value) ? "selected=\"selected\"" : "", flow.Value);
			}
			return stringBuilder.ToString();
		}

		public Dictionary<Guid, string> GetInstanceManageFlowIDList(Guid userID, string typeID = "")
		{
			List<RoadFlow.Data.Model.WorkFlow> allFromCache = GetAllFromCache();
			new Organize();
			Dictionary<Guid, string> dictionary = new Dictionary<Guid, string>();
			foreach (RoadFlow.Data.Model.WorkFlow item in allFromCache)
			{
				if ((!typeID.IsGuid() || GetAllChildsIDString(typeID.ToGuid()).Contains(item.Type.ToString(), StringComparison.CurrentCultureIgnoreCase)) && item.InstanceManager.Contains(userID.ToString(), StringComparison.CurrentCultureIgnoreCase))
				{
					dictionary.Add(item.ID, item.Name);
				}
			}
			return dictionary;
		}

		public Bitmap CreateSignImage(string UserName)
		{
			if (UserName.IsNullOrEmpty())
			{
				return null;
			}
			Random random = new Random(UserName.GetHashCode());
			Size empty = Size.Empty;
			Font font = new Font("隶书", 16f);
			using (Bitmap image = new Bitmap(5, 5))
			{
				using (Graphics graphics = Graphics.FromImage(image))
				{
					SizeF sizeF = graphics.MeasureString(UserName, font, 10000);
					empty.Width = (int)sizeF.Width + 4;
					empty.Height = (int)sizeF.Height;
				}
			}
			Bitmap bitmap = new Bitmap(empty.Width, empty.Height);
			using (Graphics graphics2 = Graphics.FromImage(bitmap))
			{
				graphics2.Clear(Color.White);
				using (StringFormat stringFormat = new StringFormat())
				{
					stringFormat.Alignment = StringAlignment.Center;
					stringFormat.LineAlignment = StringAlignment.Center;
					stringFormat.FormatFlags = StringFormatFlags.NoWrap;
					graphics2.DrawString(UserName, font, Brushes.Red, new RectangleF(0f, 0f, (float)empty.Width, (float)empty.Height), stringFormat);
				}
			}
			Color red = Color.Red;
			int num = empty.Width * empty.Height * 8 / 100;
			for (int i = 0; i < num; i++)
			{
				int x = random.Next(0, 4);
				int y = random.Next(empty.Height);
				bitmap.SetPixel(x, y, red);
				x = random.Next(empty.Width - 4, empty.Width);
				y = random.Next(empty.Height);
				bitmap.SetPixel(x, y, red);
			}
			int num2 = empty.Width * empty.Height * 20 / 100;
			for (int j = 0; j < num2; j++)
			{
				int x = random.Next(empty.Width);
				int y = random.Next(0, 4);
				bitmap.SetPixel(x, y, red);
				x = random.Next(empty.Width);
				y = random.Next(empty.Height - 4, empty.Height);
				bitmap.SetPixel(x, y, red);
			}
			int num3 = empty.Width * empty.Height / 150;
			for (int k = 0; k < num3; k++)
			{
				int x = random.Next(empty.Width);
				int y = random.Next(empty.Height);
				bitmap.SetPixel(x, y, red);
			}
			font.Dispose();
			return bitmap;
		}

		public string GetAutoTitle(string flowID, string stepID)
		{
			string flowName;
			string stepName = GetStepName(stepID.ToGuid(), flowID.ToGuid(), out flowName, true);
			return string.Format("<div class='flowautotitle'>{0} - {1}</div>", flowName, stepName);
		}

		public string GetAutoTaskTitle(string flowID, string stepID, string groupID = "")
		{
			WorkFlowInstalled workFlowRunModel = GetWorkFlowRunModel(flowID);
			if (workFlowRunModel == null)
			{
				return "";
			}
			string name = workFlowRunModel.Name;
			string text = "";
			Guid test;
			if (groupID.IsGuid(out test) || test == Guid.Empty)
			{
				Guid firstSnderID = new WorkFlowTask().GetFirstSnderID(flowID.ToGuid(), test);
				text = new Users().GetName(firstSnderID);
			}
			if (text.IsNullOrEmpty())
			{
				text = Users.CurrentUserName;
			}
			return name + "(" + text + ")";
		}

		public string SaveFromData(string instanceid, WorkFlowCustomEventParams eventParams)
		{
			//IL_02ae: Unknown result type (might be due to invalid IL or missing references)
			//IL_02b8: Expected O, but got Unknown
			//IL_02d1: Unknown result type (might be due to invalid IL or missing references)
			//IL_02db: Expected O, but got Unknown
			//IL_0a52: Unknown result type (might be due to invalid IL or missing references)
			//IL_0a5c: Expected O, but got Unknown
			//IL_0a57: Unknown result type (might be due to invalid IL or missing references)
			//IL_0a5e: Expected O, but got Unknown
			//IL_0a73: Unknown result type (might be due to invalid IL or missing references)
			//IL_0a7d: Expected O, but got Unknown
			//IL_0a78: Unknown result type (might be due to invalid IL or missing references)
			//IL_0a7f: Expected O, but got Unknown
			//IL_0b33: Unknown result type (might be due to invalid IL or missing references)
			//IL_0b3d: Expected O, but got Unknown
			//IL_0b38: Unknown result type (might be due to invalid IL or missing references)
			//IL_0b3f: Expected O, but got Unknown
			//IL_0b8a: Unknown result type (might be due to invalid IL or missing references)
			//IL_0b94: Expected O, but got Unknown
			//IL_0b8f: Unknown result type (might be due to invalid IL or missing references)
			//IL_0b96: Expected O, but got Unknown
			//IL_0da9: Unknown result type (might be due to invalid IL or missing references)
			//IL_0db3: Expected O, but got Unknown
			//IL_0dd3: Unknown result type (might be due to invalid IL or missing references)
			//IL_0ddd: Expected O, but got Unknown
			//IL_13ee: Unknown result type (might be due to invalid IL or missing references)
			//IL_13f8: Expected O, but got Unknown
			//IL_13f3: Unknown result type (might be due to invalid IL or missing references)
			//IL_13fa: Expected O, but got Unknown
			//IL_140f: Unknown result type (might be due to invalid IL or missing references)
			//IL_1419: Expected O, but got Unknown
			//IL_1414: Unknown result type (might be due to invalid IL or missing references)
			//IL_141b: Expected O, but got Unknown
			string text = HttpContext.Current.Request.Form["Form_CustomSaveMethod"];
			if (!text.IsNullOrEmpty())
			{
				return new WorkFlowTask().ExecuteFlowCustomEvent(text, eventParams).ToString();
			}
			if ("1" != HttpContext.Current.Request.Form["Form_AutoSaveData"])
			{
				return instanceid;
			}
			DBConnection dBConnection = new DBConnection();
			string dbconnid = HttpContext.Current.Request.Form["Form_DBConnID"];
			string text2 = HttpContext.Current.Request.Form["Form_DBTable"];
			string text3 = HttpContext.Current.Request.Form["Form_DBTablePk"];
			string text15 = HttpContext.Current.Request.Form["Form_DBTableTitle"];
			string text4 = HttpContext.Current.Request.Form["HasSerialNumber"];
			if (!dbconnid.IsGuid())
			{
				return instanceid;
			}
			List<FieldStatus> list = new List<FieldStatus>();
			int num = 0;
			string str = string.Empty;
			WorkFlowInstalled workFlowRunModel = GetWorkFlowRunModel(eventParams.FlowID);
			if (workFlowRunModel != null)
			{
				IEnumerable<Step> source = from p in workFlowRunModel.Steps
				where p.ID == eventParams.StepID
				select p;
				if (source.Count() > 0)
				{
					list = source.First().FieldStatus.ToList();
					num = source.First().DataSaveType;
					str = source.First().DataSaveTypeWhere;
				}
			}
			RoadFlow.Data.Model.DBConnection dBConnection2 = dBConnection.Get(dbconnid.ToGuid());
			if (dBConnection2 == null)
			{
				return instanceid;
			}
			using (IDbConnection dbConnection = dBConnection.GetConnection(dBConnection2))
			{
				if (dbConnection == null)
				{
					return instanceid;
				}
				try
				{
					dbConnection.Open();
				}
				catch (Exception ex)
				{
					HttpContext.Current.Response.Write("连接数据库出错：" + ex.Message);
					Log.Add(ex);
				}
				string cmdText = string.Empty;
				List<IDataParameter> list2 = new List<IDataParameter>();
				if (!instanceid.IsNullOrEmpty() && 1 != num)
				{
					switch (dBConnection2.Type)
					{
					case "SqlServer":
						cmdText = string.Format("SELECT * FROM {0} WHERE {1}=@pk", text2, text3);
						list2.Add(new SqlParameter("@pk", instanceid));
						break;
					case "Oracle":
						cmdText = string.Format("SELECT * FROM {0} WHERE {1}=:pk", text2, text3);
						list2.Add((IDataParameter)new OracleParameter(":pk", (object)instanceid));
						break;
					case "MySql":
						cmdText = string.Format("SELECT * FROM {0} WHERE {1}=@pk", text2, text3);
						list2.Add((IDataParameter)new MySqlParameter("@pk", (object)instanceid));
						break;
					}
				}
				else
				{
					cmdText = string.Format("SELECT * FROM {0} WHERE {1}", text2, str.IsNullOrEmpty() ? "1=0" : str.FilterWildcard());
				}
				IDbDataAdapter dataAdapter = dBConnection.GetDataAdapter(dbConnection, dBConnection2.Type, cmdText, list2.ToArray());
				DataSet dataSet = new DataSet();
				dataAdapter.Fill(dataSet);
				DataTable tableSchema = dBConnection.GetTableSchema(dbConnection, text2, dBConnection2.Type);
				DataTable dataTable = dataSet.Tables[0];
				bool flag = dataTable.Rows.Count == 0;
				if (flag)
				{
					dataTable.Rows.Add(dataTable.NewRow());
				}
				if (!instanceid.IsNullOrEmpty())
				{
					dataTable.Rows[0][text3] = instanceid;
				}
				string text5 = string.Empty;
				int maxNumber = 0;
				for (int i = 0; i < dataTable.Columns.Count; i++)
				{
					string columnName = dataTable.Columns[i].ColumnName;
					string name = text2 + "." + columnName;
					string text6 = HttpContext.Current.Request.Form[name];
					if (string.Compare(columnName, text3, true) == 0)
					{
						if (text6.IsNullOrEmpty())
						{
							continue;
						}
						instanceid = text6;
					}
					if (text6.IsNullOrEmpty() && !text4.IsNullOrEmpty() && ("," + text4 + ",").Contains(name, StringComparison.CurrentCultureIgnoreCase))
					{
						if (dataTable.Rows[0][columnName].ToString().IsNullOrEmpty())
						{
							string text7 = HttpContext.Current.Request.Form["HasSerialNumberConfig_" + name];
							if (!text7.IsNullOrEmpty())
							{
								JsonData jsonData = JsonMapper.ToObject(text7);
								text6 = dBConnection.GetSerialNumber(dbConnection, dBConnection2.Type, text2, columnName, jsonData, out maxNumber);
								text5 = (jsonData.ContainsKey("maxfiled") ? jsonData["maxfiled"].ToString() : "");
							}
						}
						else
						{
							text6 = dataTable.Rows[0][columnName].ToString();
						}
					}
					if (text6 == null && !flag)
					{
						FieldStatus fieldStatus = list.Find((FieldStatus p) => p.Field.Equals(dbconnid + "." + name, StringComparison.CurrentCultureIgnoreCase));
						if (fieldStatus == null || fieldStatus.Status1.In(1, 2))
						{
							continue;
						}
					}
					string fullName = dataTable.Columns[i].DataType.FullName;
					DataRow[] array = tableSchema.Select(string.Format("f_name='{0}'", columnName));
					bool flag2 = false;
					bool flag3 = false;
					object defaultValue;
					bool colnumIsValue = getColnumIsValue(fullName, text6, out defaultValue);
					object obj = string.Empty;
					switch (dBConnection2.Type)
					{
					case "SqlServer":
						flag2 = (array.Length != 0 && array[0]["cdefault"].ToString() != "0");
						flag3 = (array.Length != 0 && array[0]["is_null"].ToString() != "0");
						if (flag2 && !array[0]["defaultvalue"].ToString().IsNullOrEmpty())
						{
							obj = dBConnection.GetDbDefaultValue_SqlServer(array[0]["defaultvalue"].ToString().Trim1());
						}
						break;
					case "Oracle":
						flag2 = (array.Length != 0 && !array[0]["cdefault"].ToString().IsNullOrEmpty());
						flag3 = (array.Length != 0 && array[0]["is_null"].ToString() != "0");
						if (flag2 && !array[0]["defaultvalue"].ToString().IsNullOrEmpty())
						{
							obj = dBConnection.GetDbDefaultValue_Oracle(array[0]["defaultvalue"].ToString().Trim1());
						}
						break;
					case "MySql":
						flag2 = (array.Length != 0 && !array[0]["cdefault"].ToString().IsNullOrEmpty());
						flag3 = (array.Length != 0 && array[0]["is_null"].ToString() != "0");
						if (flag2 && !array[0]["defaultvalue"].ToString().IsNullOrEmpty())
						{
							obj = dBConnection.GetDbDefaultValue_MySql(array[0]["defaultvalue"].ToString().Trim1());
						}
						break;
					}
					if (text5.IsNullOrEmpty() || !columnName.Equals(text5, StringComparison.CurrentCultureIgnoreCase))
					{
						if (colnumIsValue)
						{
							dataTable.Rows[0][columnName] = text6;
						}
						else if (!flag2)
						{
							if (flag3)
							{
								dataTable.Rows[0][columnName] = DBNull.Value;
							}
							else
							{
								dataTable.Rows[0][columnName] = defaultValue;
							}
						}
						else if (obj != null)
						{
							try
							{
								dataTable.Rows[0][columnName] = obj;
							}
							catch
							{
							}
						}
					}
				}
				if (!text5.IsNullOrEmpty())
				{
					dataTable.Rows[0][text5] = maxNumber;
				}
				bool flag4 = false;
				if (flag && instanceid.IsNullOrEmpty())
				{
					DataColumn dataColumn = dataTable.Columns[text3];
					DataRow[] array2 = tableSchema.Select(string.Format("f_name='{0}'", text3));
					if (array2.Length != 0)
					{
						flag4 = false;
						bool flag5 = false;
						switch (dBConnection2.Type)
						{
						case "SqlServer":
						{
							flag4 = (array2[0]["isidentity"].ToString() == "1");
							bool flag12 = array2[0]["cdefault"].ToString() != "0";
							flag5 = (dataColumn.DataType.FullName == "System.Guid");
							break;
						}
						case "Oracle":
							flag4 = array2[0]["t_name"].ToString().Equals("NUMBER", StringComparison.CurrentCultureIgnoreCase);
							array2[0]["cdefault"].ToString().IsNullOrEmpty();
							flag5 = (dataColumn.DataType.FullName == "System.String");
							break;
						case "MySql":
							flag4 = (array2[0]["isidentity"].ToString() == "1");
							array2[0]["cdefault"].ToString().IsNullOrEmpty();
							flag5 = (dataColumn.DataType.FullName == "System.Guid" || dataColumn.DataType.FullName == "System.String");
							break;
						}
						if (!flag4 && flag5)
						{
							instanceid = Guid.NewGuid().ToString();
							dataTable.Rows[0][text3] = instanceid;
						}
					}
				}
				switch (dBConnection2.Type)
				{
				case "SqlServer":
				{
					SqlCommandBuilder sqlCommandBuilder = new SqlCommandBuilder((SqlDataAdapter)dataAdapter);
					dataAdapter.Update(dataSet);
					sqlCommandBuilder.Dispose();
					break;
				}
				case "Oracle":
				{
					OracleCommandBuilder val2 = new OracleCommandBuilder(dataAdapter);
					dataAdapter.Update(dataSet);
					((Component)val2).Dispose();
					break;
				}
				case "MySql":
				{
					MySqlCommandBuilder val = new MySqlCommandBuilder(dataAdapter);
					dataAdapter.Update(dataSet);
					((Component)val).Dispose();
					break;
				}
				}
				if (flag && flag4)
				{
					switch (dBConnection2.Type)
					{
					case "SqlServer":
						using (SqlCommand sqlCommand = new SqlCommand("SELECT @@IDENTITY", (SqlConnection)dbConnection))
						{
							object obj5 = sqlCommand.ExecuteScalar();
							if (obj5 != null)
							{
								instanceid = obj5.ToString();
								dataTable.Rows[0][text3] = instanceid;
							}
						}
						break;
					case "Oracle":
					{
						OracleCommand val4 = new OracleCommand(string.Format("SELECT {0}_{1}_SEQ.currval FROM dual", text2, text3), dbConnection);
						try
						{
							object obj4 = ((DbCommand)val4).ExecuteScalar();
							if (obj4 != null)
							{
								instanceid = obj4.ToString();
								dataTable.Rows[0][text3] = instanceid;
							}
						}
						finally
						{
							if (val4 != null)
							{
								((IDisposable)val4).Dispose();
							}
						}
						break;
					}
					case "MySql":
					{
						MySqlCommand val3 = new MySqlCommand(string.Format("select @@IDENTITY"), dbConnection);
						try
						{
							object obj3 = ((DbCommand)val3).ExecuteScalar();
							if (obj3 != null)
							{
								instanceid = obj3.ToString();
								dataTable.Rows[0][text3] = instanceid;
							}
						}
						finally
						{
							if (val3 != null)
							{
								((IDisposable)val3).Dispose();
							}
						}
						break;
					}
					}
				}
				string[] array3 = (HttpContext.Current.Request.Form["flowsubtable_id"] ?? "").Split(',');
				foreach (string text8 in array3)
				{
					string secondtable = HttpContext.Current.Request.Form["flowsubtable_" + text8 + "_secondtable"];
					string text9 = HttpContext.Current.Request.Form["flowsubtable_" + text8 + "_primarytablefiled"];
					string text10 = HttpContext.Current.Request.Form["flowsubtable_" + text8 + "_secondtableprimarykey"];
					string text11 = HttpContext.Current.Request.Form["flowsubtable_" + text8 + "_secondtablerelationfield"];
					if (!secondtable.IsNullOrEmpty() && !text9.IsNullOrEmpty() && !text10.IsNullOrEmpty() && !text11.IsNullOrEmpty())
					{
						string text12 = dataTable.Rows[0][text9].ToString();
						if (!text12.IsNullOrEmpty())
						{
							string cmdText2 = string.Empty;
							List<IDataParameter> list3 = new List<IDataParameter>();
							switch (dBConnection2.Type)
							{
							case "SqlServer":
								cmdText2 = string.Format("SELECT * FROM {0} WHERE {1}=@pk", secondtable, text11);
								list3.Add(new SqlParameter("@pk", text12));
								break;
							case "Oracle":
								cmdText2 = string.Format("SELECT * FROM {0} WHERE {1}=:pk", secondtable, text11);
								list3.Add((IDataParameter)new OracleParameter(":pk", (object)text12));
								break;
							case "MySql":
								cmdText2 = string.Format("SELECT * FROM {0} WHERE {1}=@pk", secondtable, text11);
								list3.Add((IDataParameter)new MySqlParameter("@pk", (object)text12));
								break;
							}
							string[] array4 = (HttpContext.Current.Request.Form["hidden_guid_" + text8] ?? "").Split(',');
							IDbDataAdapter dataAdapter2 = dBConnection.GetDataAdapter(dbConnection, dBConnection2.Type, cmdText2, list3.ToArray());
							DataSet dataSet2 = new DataSet();
							dataAdapter2.Fill(dataSet2);
							DataTable tableSchema2 = dBConnection.GetTableSchema(dbConnection, secondtable, dBConnection2.Type);
							DataTable dataTable2 = dataSet2.Tables[0];
							bool flag6 = dataTable2.Rows.Count == 0;
							string[] array5 = array4;
							foreach (string text13 in array5)
							{
								bool flag7 = true;
								DataRow dataRow = null;
								foreach (DataRow row in dataTable2.Rows)
								{
									if (string.Compare(row[text10].ToString(), text13, StringComparison.CurrentCulture) == 0)
									{
										dataRow = row;
										flag7 = false;
										break;
									}
								}
								if (flag7)
								{
									dataRow = dataTable2.NewRow();
									dataRow[text11] = text12;
									dataTable2.Rows.Add(dataRow);
									flag7 = true;
								}
								for (int l = 0; l < dataTable2.Columns.Count; l++)
								{
									string colnumName = dataTable2.Columns[l].ColumnName;
									if (string.Compare(colnumName, text10, true) != 0 && string.Compare(colnumName, text11, StringComparison.CurrentCulture) != 0)
									{
										string text14 = HttpContext.Current.Request.Form[text8 + "_" + text13 + "_" + secondtable + "_" + colnumName];
										if (text14 == null && !flag7)
										{
											FieldStatus fieldStatus2 = list.Find((FieldStatus p) => p.Field.Equals(dbconnid + "." + secondtable + "." + colnumName, StringComparison.CurrentCultureIgnoreCase));
											if (fieldStatus2 == null || fieldStatus2.Status1.In(1, 2))
											{
												continue;
											}
										}
										string fullName2 = dataTable2.Columns[l].DataType.FullName;
										object defaultValue2 = string.Empty;
										object obj6 = null;
										DataRow[] array6 = tableSchema2.Select(string.Format("f_name='{0}'", colnumName));
										bool flag8 = array6.Length != 0 && array6[0]["cdefault"].ToString() != "0";
										bool flag9 = array6.Length != 0 && array6[0]["is_null"].ToString() != "0";
										bool colnumIsValue2 = getColnumIsValue(fullName2, text14, out defaultValue2);
										if (flag8 && !array6[0]["defaultvalue"].ToString().IsNullOrEmpty())
										{
											switch (dBConnection2.Type)
											{
											case "SqlServer":
												obj6 = dBConnection.GetDbDefaultValue_SqlServer(array6[0]["defaultvalue"].ToString().Trim1());
												break;
											case "Oracle":
												obj6 = dBConnection.GetDbDefaultValue_Oracle(array6[0]["defaultvalue"].ToString().Trim1());
												break;
											case "MySql":
												obj6 = dBConnection.GetDbDefaultValue_MySql(array6[0]["defaultvalue"].ToString().Trim1());
												break;
											}
										}
										if (colnumIsValue2)
										{
											dataRow[colnumName] = text14;
										}
										else if (!flag8)
										{
											if (flag9)
											{
												dataRow[colnumName] = DBNull.Value;
											}
											else
											{
												dataRow[colnumName] = defaultValue2;
											}
										}
										else if (obj6 != null)
										{
											try
											{
												dataRow[colnumName] = obj6;
											}
											catch
											{
											}
										}
									}
								}
							}
							if (!flag6)
							{
								for (int m = 0; m < dataTable2.Rows.Count; m++)
								{
									bool flag10 = false;
									array5 = array4;
									foreach (string strB in array5)
									{
										if (dataTable2.Rows[m][text10].ToString().IsNullOrEmpty() || string.Compare(dataTable2.Rows[m][text10].ToString(), strB, StringComparison.CurrentCulture) == 0)
										{
											flag10 = true;
											break;
										}
									}
									if (!flag10)
									{
										dataTable2.Rows[m].Delete();
									}
								}
							}
							if ("Oracle".Equals(dBConnection2.Type) || "MySql".Equals(dBConnection2.Type))
							{
								DataRow[] array7 = tableSchema2.Select(string.Format("f_name='{0}'", text10));
								bool flag11 = array7.Length != 0 && array7[0]["isidentity"].ToString() == "1";
								if ("Oracle".Equals(dBConnection2.Type))
								{
									flag11 = array7[0]["t_name"].ToString().Equals("NUMBER", StringComparison.CurrentCultureIgnoreCase);
								}
								if (!flag11)
								{
									foreach (DataRow row2 in dataTable2.Rows)
									{
										if (row2.RowState == DataRowState.Added)
										{
											row2[text10] = Guid.NewGuid();
										}
									}
								}
							}
							switch (dBConnection2.Type)
							{
							case "SqlServer":
							{
								SqlCommandBuilder sqlCommandBuilder2 = new SqlCommandBuilder((SqlDataAdapter)dataAdapter2);
								dataAdapter2.Update(dataSet2);
								sqlCommandBuilder2.Dispose();
								break;
							}
							case "Oracle":
							{
								OracleCommandBuilder val6 = new OracleCommandBuilder(dataAdapter2);
								dataAdapter2.Update(dataSet2);
								((Component)val6).Dispose();
								break;
							}
							case "MySql":
							{
								MySqlCommandBuilder val5 = new MySqlCommandBuilder(dataAdapter2);
								dataAdapter2.Update(dataSet2);
								((Component)val5).Dispose();
								break;
							}
							}
						}
					}
				}
				return instanceid;
			}
		}

		private bool getColnumIsValue(string colnumDataType, string value, out object defaultValue)
		{
			bool result = false;
			defaultValue = null;
			switch (colnumDataType)
			{
			case "System.Int16":
			case "System.Int32":
			case "System.Int64":
			case "System.UInt16":
			case "System.UInt32":
			case "System.UInt64":
				result = value.IsInt();
				defaultValue = -2147483648;
				break;
			case "System.String":
				result = (value != null);
				defaultValue = "";
				break;
			case "System.Guid":
				result = value.IsGuid();
				defaultValue = Guid.Empty;
				break;
			case "System.Decimal":
				result = value.IsDecimal();
				defaultValue = decimal.MinValue;
				break;
			case "System.Double":
			case "System.Single":
				result = value.IsDouble();
				defaultValue = -1.7976931348623157E+308;
				break;
			case "System.DateTime":
				result = value.IsDateTime();
				defaultValue = DateTimeNew.Now;
				break;
			case "System.Object":
				result = (value != null);
				defaultValue = "";
				break;
			case "System.Boolean":
				result = (value != null && (value.ToString().ToLower() == "false" || value.ToString().ToLower() == "true"));
				defaultValue = 0;
				break;
			}
			return result;
		}

		public JsonData GetFormData(string connid, string table, string pk, string instanceid, string filedStatus = "", string formats = "", string taskID = "")
		{
			//IL_01d4: Unknown result type (might be due to invalid IL or missing references)
			//IL_01de: Expected O, but got Unknown
			//IL_01f7: Unknown result type (might be due to invalid IL or missing references)
			//IL_0201: Expected O, but got Unknown
			JsonData jsonData = new JsonData();
			if (instanceid.IsNullOrEmpty())
			{
				return jsonData;
			}
			DBConnection dBConnection = new DBConnection();
			RoadFlow.Data.Model.DBConnection dBConnection2 = dBConnection.Get(connid.ToGuid());
			if (dBConnection2 == null)
			{
				return "";
			}
			JsonData jsonData2 = null;
			if (!formats.IsNullOrEmpty())
			{
				jsonData2 = JsonMapper.ToObject(formats);
			}
			using (IDbConnection dbConnection = dBConnection.GetConnection(dBConnection2))
			{
				if (dbConnection == null)
				{
					return "";
				}
				try
				{
					dbConnection.Open();
				}
				catch (Exception ex)
				{
					HttpContext.Current.Response.Write("连接数据库出错：" + ex.Message);
					Log.Add(ex);
				}
				string cmdText = string.Empty;
				string str = string.Empty;
				int num = 0;
				List<IDataParameter> list = new List<IDataParameter>();
				if (taskID.IsGuid())
				{
					RoadFlow.Data.Model.WorkFlowTask task = new WorkFlowTask().Get(taskID.ToGuid());
					if (task != null)
					{
						WorkFlowInstalled workFlowRunModel = new WorkFlow().GetWorkFlowRunModel(task.FlowID);
						if (workFlowRunModel != null)
						{
							IEnumerable<Step> source = from p in workFlowRunModel.Steps
							where p.ID == task.StepID
							select p;
							if (source.Count() > 0)
							{
								num = source.First().DataSaveType;
								str = source.First().DataSaveTypeWhere;
							}
						}
					}
				}
				if (num != 1)
				{
					switch (dBConnection2.Type)
					{
					case "SqlServer":
						cmdText = string.Format("SELECT * FROM {0} WHERE {1}=@pk", table, pk);
						list.Add(new SqlParameter("@pk", instanceid));
						break;
					case "Oracle":
						cmdText = string.Format("SELECT * FROM {0} WHERE {1}=:pk", table, pk);
						list.Add((IDataParameter)new OracleParameter(":pk", (object)instanceid));
						break;
					case "MySql":
						cmdText = string.Format("SELECT * FROM {0} WHERE {1}=@pk", table, pk);
						list.Add((IDataParameter)new MySqlParameter("@pk", (object)instanceid));
						break;
					}
				}
				else
				{
					cmdText = string.Format("SELECT * FROM {0} WHERE {1}", table, str.FilterWildcard());
				}
				IDbDataAdapter dataAdapter = dBConnection.GetDataAdapter(dbConnection, dBConnection2.Type, cmdText, list.ToArray());
				DataSet dataSet = new DataSet();
				dataAdapter.Fill(dataSet);
				if (dataAdapter.SelectCommand != null)
				{
					dataAdapter.SelectCommand.Dispose();
				}
				DataTable dataTable = dataSet.Tables[0];
				JsonData jsonData3 = null;
				if (!filedStatus.IsNullOrEmpty())
				{
					jsonData3 = JsonMapper.ToObject(filedStatus);
				}
				if (dataTable.Rows.Count <= 0)
				{
					return jsonData;
				}
				DataRow dataRow = dataTable.Rows[0];
				for (int i = 0; i < dataTable.Columns.Count; i++)
				{
					bool flag = true;
					string text = (table + "_" + dataTable.Columns[i].ColumnName).ToLower();
					if (jsonData3 != null && jsonData3.ContainsKey(text))
					{
						string text2 = jsonData3[text].ToString();
						if (!text2.IsNullOrEmpty())
						{
							string[] array = text2.Split('_');
							if (array.Length == 2 && "2" == array[0])
							{
								flag = false;
							}
						}
					}
					string text3 = dataRow[dataTable.Columns[i].ColumnName].ToString();
					string text4 = (table + "." + dataTable.Columns[i].ColumnName).ToLower();
					if (jsonData2 != null && jsonData2.ContainsKey(text4))
					{
						string format = jsonData2[text4].ToString();
						if (text3.IsDecimal())
						{
							text3 = text3.ToDecimal().ToString(format);
						}
						else if (text3.IsDateTime())
						{
							text3 = text3.ToDateTime().ToString(format);
						}
					}
					if (flag)
					{
						jsonData[text] = text3;
					}
					else
					{
						jsonData[text] = "";
					}
				}
				return jsonData;
			}
		}

		public string GetFormDataJsonString(string connid, string table, string pk, string instanceid)
		{
			JsonData formData = GetFormData(connid, table, pk, instanceid);
			return GetFormDataJsonString(formData);
		}

		public string GetFormDataJsonString(JsonData jsonData)
		{
			string text = jsonData.ToJson();
			if (!text.IsNullOrEmpty())
			{
				return text;
			}
			return "{}";
		}

		public JsonData GetSubTableData(string connID, string secondTable, string relationField, string fieldValue, string sortField = "", string fieldFormat = "")
		{
			//IL_013d: Unknown result type (might be due to invalid IL or missing references)
			//IL_0147: Expected O, but got Unknown
			//IL_017c: Unknown result type (might be due to invalid IL or missing references)
			//IL_0186: Expected O, but got Unknown
			JsonData jsonData = new JsonData();
			if (fieldValue.IsNullOrEmpty())
			{
				return jsonData;
			}
			DBConnection dBConnection = new DBConnection();
			RoadFlow.Data.Model.DBConnection dBConnection2 = dBConnection.Get(connID.ToGuid());
			if (dBConnection2 == null)
			{
				return "";
			}
			using (IDbConnection dbConnection = dBConnection.GetConnection(dBConnection2))
			{
				if (dbConnection != null)
				{
					try
					{
						dbConnection.Open();
					}
					catch (Exception ex)
					{
						HttpContext.Current.Response.Write("连接数据库出错：" + ex.Message);
						Log.Add(ex);
					}
					string cmdText = string.Empty;
					List<IDataParameter> list = new List<IDataParameter>();
					switch (dBConnection2.Type)
					{
					case "SqlServer":
						cmdText = string.Format("SELECT * FROM {0} WHERE {1}=@fieldvalue {2}", secondTable, relationField, sortField.IsNullOrEmpty() ? "" : ("ORDER BY " + sortField));
						list.Add(new SqlParameter("@fieldvalue", fieldValue));
						break;
					case "Oracle":
						cmdText = string.Format("SELECT * FROM {0} WHERE {1}=:fieldvalue {2}", secondTable, relationField, sortField.IsNullOrEmpty() ? "" : ("ORDER BY " + sortField));
						list.Add((IDataParameter)new OracleParameter(":fieldvalue", (object)fieldValue));
						break;
					case "MySql":
						cmdText = string.Format("SELECT * FROM {0} WHERE {1}=@fieldvalue {2}", secondTable, relationField, sortField.IsNullOrEmpty() ? "" : ("ORDER BY " + sortField));
						list.Add((IDataParameter)new MySqlParameter("@fieldvalue", (object)fieldValue));
						break;
					}
					IDbDataAdapter dataAdapter = dBConnection.GetDataAdapter(dbConnection, dBConnection2.Type, cmdText, list.ToArray());
					DataSet dataSet = new DataSet();
					dataAdapter.Fill(dataSet);
					if (dataAdapter.SelectCommand != null)
					{
						dataAdapter.SelectCommand.Dispose();
					}
					DataTable dataTable = dataSet.Tables[0];
					JsonData jsonData2 = null;
					if (!fieldFormat.IsNullOrEmpty())
					{
						jsonData2 = JsonMapper.ToObject(fieldFormat);
					}
					{
						foreach (DataRow row in dataTable.Rows)
						{
							JsonData jsonData3 = new JsonData();
							for (int i = 0; i < dataTable.Columns.Count; i++)
							{
								string text = secondTable.ToLower() + "_" + dataTable.Columns[i].ColumnName.ToLower();
								string text2 = "";
								if (jsonData2 != null && jsonData2.IsArray)
								{
									foreach (JsonData item in (IEnumerable)jsonData2)
									{
										if (item.ContainsKey("fieldname") && item["fieldname"].ToString().Equals(text, StringComparison.CurrentCultureIgnoreCase))
										{
											text2 = item["format"].ToString();
											break;
										}
									}
								}
								string text3 = row[dataTable.Columns[i].ColumnName].ToString();
								if (!text2.IsNullOrEmpty())
								{
									if (text3.IsDecimal())
									{
										text3 = text3.ToDecimal().ToString(text2);
									}
									else if (text3.IsDateTime())
									{
										text3 = text3.ToDateTime().ToString(text2);
									}
								}
								jsonData3[text] = text3;
							}
							jsonData.Add(jsonData3);
						}
						return jsonData;
					}
				}
				return "";
			}
		}

		public string GetFromFieldData(JsonData jsonData, string table, string field)
		{
			string empty = string.Empty;
			if (jsonData == null || table.IsNullOrEmpty() || field.IsNullOrEmpty())
			{
				return empty;
			}
			string text = (table + "_" + field).ToLower();
			if (!jsonData.ContainsKey(text))
			{
				return empty;
			}
			return jsonData[text].ToString();
		}

		public string GetFieldStatus(string flowID, string stepID)
		{
			Guid test;
			if (!flowID.IsGuid(out test))
			{
				string str = HttpContext.Current.Request.QueryString["programid"];
				if (str.IsGuid())
				{
					return new ProgramBuilder().GetJsonString(str.ToGuid());
				}
				return "{}";
			}
			WorkFlowInstalled workFlowRunModel = GetWorkFlowRunModel(test);
			if (workFlowRunModel == null)
			{
				return "{}";
			}
			Guid sid;
			if (!stepID.IsGuid(out sid))
			{
				sid = workFlowRunModel.FirstStepID;
			}
			IEnumerable<Step> source = from p in workFlowRunModel.Steps
			where p.ID == sid
			select p;
			if (source.Count() == 0)
			{
				return "{}";
			}
			IEnumerable<FieldStatus> fieldStatus = source.First().FieldStatus;
			StringBuilder stringBuilder = new StringBuilder("{");
			int num = fieldStatus.Count();
			int num2 = 0;
			foreach (FieldStatus item in fieldStatus)
			{
				string[] array = item.Field.Split('.');
				if (array.Length == 3)
				{
					string text = array[1] + "_" + array[2];
					stringBuilder.AppendFormat("\"{0}\":\"{1}\"", text.ToLower(), item.Status1 + "_" + item.Check);
					if (num2++ < num - 1)
					{
						stringBuilder.Append(",");
					}
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
			return new Dictionary().GetOptionsByCode("FlowTypes", Dictionary.OptionValueField.ID, value);
		}

		public List<RoadFlow.Data.Model.WorkFlow> GetByTypes(string typeString)
		{
			return dataWorkFlow.GetByTypes(typeString);
		}

		public string GetFlowIDFromType(Guid typeID)
		{
			List<RoadFlow.Data.Model.WorkFlow> byTypes = GetByTypes(GetAllChildsIDString(typeID));
			StringBuilder stringBuilder = new StringBuilder();
			foreach (RoadFlow.Data.Model.WorkFlow item in byTypes)
			{
				stringBuilder.Append(item.ID);
				stringBuilder.Append(",");
			}
			return stringBuilder.ToString().TrimEnd(',');
		}

		public string GetFlowTypeOptions(string type)
		{
			return Tools.GetOptionsString(new List<ListItem>
			{
				new ListItem("常规流程", "0")
				{
					Selected = ("0" == type)
				},
				new ListItem("自由流程", "1")
				{
					Selected = ("1" == type)
				}
			}.ToArray());
		}

		public Step GetFreeFlowStep(WorkFlowInstalled wfInstalled)
		{
			Step result = new Step();
			IEnumerable<Step> source = from p in wfInstalled.Steps
			where p.ID == wfInstalled.FirstStepID
			select p;
			if (source.Count() == 0)
			{
				return result;
			}
			result = source.First();
			result.ID = Guid.NewGuid();
			result.Name = wfInstalled.Name + "-审核";
			result.Buttons = new List<RoadFlow.Data.Model.WorkFlowInstalledSub.StepSet.Button>
			{
				new RoadFlow.Data.Model.WorkFlowInstalledSub.StepSet.Button
				{
					ID = "3B271F67-0433-4082-AD1A-8DF1B967B879",
					Note = "保存",
					Sort = 0
				},
				new RoadFlow.Data.Model.WorkFlowInstalledSub.StepSet.Button
				{
					ID = "86B7FA6C-891F-4565-9309-81672D3BA80A",
					Note = "退回",
					Sort = 1
				},
				new RoadFlow.Data.Model.WorkFlowInstalledSub.StepSet.Button
				{
					ID = "8982B97C-ADBA-4A3A-AFD9-9A3EF6FF12D8",
					Note = "发送",
					Sort = 2
				},
				new RoadFlow.Data.Model.WorkFlowInstalledSub.StepSet.Button
				{
					ID = "other_splitline",
					Note = "",
					Sort = 3
				},
				new RoadFlow.Data.Model.WorkFlowInstalledSub.StepSet.Button
				{
					ID = "954EFFA8-03B8-461A-AAA8-8727D090DCB9",
					Note = "结束流程",
					Sort = 4
				}
			};
			return result;
		}

		public List<RoadFlow.Data.Model.WorkFlow> GetPagerData(out string pager, string query = "", string userid = "", string typeid = "", string name = "", int pagesize = 15)
		{
			return dataWorkFlow.GetPagerData(out pager, query, userid, typeid, name, pagesize);
		}

		public List<RoadFlow.Data.Model.WorkFlow> GetPagerData(out long count, int pageSize, int pageNumber, string userid = "", string typeid = "", string name = "", string order = "")
		{
			return dataWorkFlow.GetPagerData(out count, pageSize, pageNumber, userid, typeid, name, order);
		}

		public List<WorkFlowStart> GetUserStartFlows(Guid userID)
		{
			return GetAllStartFlows().FindAll(delegate(WorkFlowStart p)
			{
				if (!p.StartUsers.IsNullOrEmpty())
				{
					return p.StartUsers.Contains(userID.ToString(), StringComparison.CurrentCultureIgnoreCase);
				}
				return true;
			});
		}

		public List<WorkFlowStart> GetAllStartFlows()
		{
			string key = 6.ToString() + "_StartFlows";
			object obj = Opation.Get(key);
			if (obj != null && obj is List<WorkFlowStart>)
			{
				return (List<WorkFlowStart>)obj;
			}
			List<RoadFlow.Data.Model.WorkFlow> list = GetAllFromCache().FindAll((RoadFlow.Data.Model.WorkFlow p) => p.Status == 2);
			Organize organize = new Organize();
			Users users = new Users();
			Dictionary dictionary = new Dictionary();
			AppLibrary appLibrary = new AppLibrary();
			List<WorkFlowStart> list2 = new List<WorkFlowStart>();
			foreach (RoadFlow.Data.Model.WorkFlow item in list)
			{
				WorkFlowInstalled wfRunInstance = GetWorkFlowRunModel(item.ID);
				if (wfRunInstance != null)
				{
					IEnumerable<Step> source = from p in wfRunInstance.Steps
					where p.ID == wfRunInstance.FirstStepID
					select p;
					if (source.Count() != 0)
					{
						Step step = source.First();
						RoadFlow.Data.Model.AppLibrary byCode = appLibrary.GetByCode(item.ID.ToString());
						WorkFlowStart workFlowStart = new WorkFlowStart();
						workFlowStart.ID = item.ID;
						workFlowStart.Name = item.Name;
						workFlowStart.StartUsers = organize.GetAllUsersIdString(step.Behavior.DefaultHandler);
						workFlowStart.Type = dictionary.GetTitle(item.Type);
						workFlowStart.InstallDate = (item.InstallDate.HasValue ? item.InstallDate.Value.ToShortDateString() : "");
						workFlowStart.InstallUserName = (item.InstallUserID.HasValue ? users.GetName(item.InstallUserID.Value) : "");
						if (byCode != null)
						{
							workFlowStart.OpenMode = byCode.OpenMode;
							workFlowStart.WindowWidth = (byCode.Width.HasValue ? byCode.Width.Value : 0);
							workFlowStart.WindowHeight = (byCode.Height.HasValue ? byCode.Height.Value : 0);
							workFlowStart.Params = byCode.Params;
						}
						list2.Add(workFlowStart);
					}
				}
			}
			Opation.Set(key, list2);
			return list2;
		}

		public void ClearStartFlowsCache()
		{
			Opation.Remove(6.ToString() + "_StartFlows");
		}

		public string GetWorkFlowXml(Guid flowID)
		{
			RoadFlow.Data.Model.WorkFlow workFlow = Get(flowID);
			if (workFlow == null)
			{
				return "";
			}
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
			WorkFlowInstalled workFlowRunModel = GetWorkFlowRunModel(flowID);
			if (workFlowRunModel == null)
			{
				return "";
			}
			string name = workFlowRunModel.Name;
			string text = Config.FilePath + "WorkFlowExportFiles\\" + Guid.NewGuid().ToString("N") + "\\";
			if (!Directory.Exists(text))
			{
				Directory.CreateDirectory(text);
			}
			List<FileInfo> list = new List<FileInfo>();
			string text2 = text + "FlowDesigner_" + flowID.ToString() + ".xml";
			if (File.Exists(text2))
			{
				File.Delete(text2);
			}
			string workFlowXml = GetWorkFlowXml(flowID);
			FileStream fileStream = new FileStream(text2, FileMode.Append);
			StreamWriter streamWriter = new StreamWriter(fileStream, Encoding.UTF8);
			streamWriter.Write(workFlowXml);
			streamWriter.Flush();
			streamWriter.Close();
			fileStream.Close();
			list.Add(new FileInfo(text2));
			List<Form> list2 = new List<Form>();
			foreach (Step step in workFlowRunModel.Steps)
			{
				foreach (Form form in step.Forms)
				{
					if (list2.Find((Form p) => p.ID == form.ID) == null)
					{
						list2.Add(form);
					}
				}
			}
			WorkFlowForm workFlowForm = new WorkFlowForm();
			AppLibrary appLibrary = new AppLibrary();
			foreach (Form item in list2)
			{
				RoadFlow.Data.Model.AppLibrary appLibrary2 = appLibrary.Get(item.ID);
				if (appLibrary2 != null)
				{
					RoadFlow.Data.Model.WorkFlowForm workFlowForm2 = workFlowForm.Get(appLibrary2.Code.ToGuid());
					if (workFlowForm2 != null)
					{
						string text3 = text + "FlowFormDesigner_" + item.ID.ToString() + ".xml";
						if (File.Exists(text3))
						{
							File.Delete(text3);
						}
						string workFlowFormXml = workFlowForm.GetWorkFlowFormXml(workFlowForm2.ID, appLibrary2.ID.ToString());
						FileStream fileStream2 = new FileStream(text3, FileMode.Append);
						StreamWriter streamWriter2 = new StreamWriter(fileStream2, Encoding.UTF8);
						streamWriter2.Write(workFlowFormXml);
						streamWriter2.Flush();
						streamWriter2.Close();
						fileStream2.Close();
						list.Add(new FileInfo(text3));
						if (workFlowForm2.Status == 1)
						{
							string text4 = (type == 0) ? (HttpContext.Current.Server.MapPath("/Platform/WorkFlowFormDesigner/Forms/") + "\\" + workFlowForm2.ID.ToString() + ".aspx") : (HttpContext.Current.Server.MapPath("/Views/WorkFlowFormDesigner/Forms/") + "\\" + workFlowForm2.ID.ToString() + ".cshtml");
							if (File.Exists(text4))
							{
								list.Add(new FileInfo(text4));
							}
						}
					}
				}
			}
			string text5 = text + name + "_" + flowID + ".zip";
			if (FileCompression.CompressFile(list, text5, 0, false))
			{
				return text5;
			}
			return "";
		}

		public string Import(string zipFile, int type = 0)
		{
			string text = Path.GetDirectoryName(zipFile) + "\\";
			string text2 = FileCompression.Decompress(zipFile, text);
			if ("1" != text2)
			{
				Log.Add("解压文件出错-" + zipFile, text2);
				return "解压文件出错!";
			}
			string[] files = Directory.GetFiles(text);
			string text3 = string.Empty;
			IEnumerable<string> source = from p in files
			where Path.GetFileName(p).StartsWith("FlowDesigner_")
			select p;
			if (source.Count() > 0)
			{
				XElement root = XDocument.Load(source.First()).Root;
				Guid guid = (root.Element("ID") != null) ? root.Element("ID").Value.ToGuid() : Guid.Empty;
				text3 = ((root.Element("Name") != null) ? root.Element("Name").Value : "");
				if (root.Element("Type") == null)
				{
					Guid empty3 = Guid.Empty;
				}
				else
				{
					root.Element("Type").Value.ToGuid();
				}
				string manager = (root.Element("Manager") != null) ? root.Element("Manager").Value : "";
				string instanceManager = (root.Element("InstanceManager") != null) ? root.Element("InstanceManager").Value : "";
				string str = (root.Element("CreateDate") != null) ? root.Element("CreateDate").Value : "";
				string str2 = (root.Element("CreateUserID") != null) ? root.Element("CreateUserID").Value : "";
				string designJSON = (root.Element("DesignJSON") != null) ? root.Element("DesignJSON").Value : "";
				string str3 = (root.Element("InstallDate") != null) ? root.Element("InstallDate").Value : "";
				string str4 = (root.Element("InstallUserID") != null) ? root.Element("InstallUserID").Value : "";
				string runJSON = (root.Element("RunJSON") != null) ? root.Element("RunJSON").Value : "";
				int status = (root.Element("Status") == null) ? 1 : root.Element("Status").Value.ToInt();
				if (!guid.IsEmptyGuid() || !text3.IsNullOrEmpty())
				{
					RoadFlow.Data.Model.WorkFlow workFlow = Get(guid);
					bool flag = false;
					if (workFlow == null)
					{
						workFlow = new RoadFlow.Data.Model.WorkFlow();
						flag = true;
					}
					workFlow.CreateDate = (str.IsDateTime() ? str.ToDateTime() : DateTimeNew.Now);
					workFlow.CreateUserID = (str2.IsGuid() ? str2.ToGuid() : Users.CurrentUserID);
					workFlow.DesignJSON = designJSON;
					workFlow.ID = guid;
					workFlow.InstallDate = (str3.IsDateTime() ? str3.ToDateTime() : DateTimeNew.Now);
					if (str4.IsGuid())
					{
						workFlow.InstallUserID = str4.ToGuid();
					}
					workFlow.InstanceManager = instanceManager;
					workFlow.Manager = manager;
					workFlow.Name = text3;
					workFlow.RunJSON = runJSON;
					workFlow.Status = status;
					if (flag)
					{
						Add(workFlow);
					}
					else
					{
						Update(workFlow);
					}
				}
			}
			IEnumerable<string> enumerable = from p in files
			where Path.GetFileName(p).StartsWith("FlowFormDesigner_")
			select p;
			WorkFlowForm workFlowForm = new WorkFlowForm();
			foreach (string item in enumerable)
			{
				string[] array = Path.GetFileNameWithoutExtension(item).Split('_');
				string text4 = string.Empty;
				if (array.Length > 1)
				{
					text4 = array[1];
				}
				if (!text4.IsNullOrEmpty() && workFlowForm.AddFromXmlFile(item, type))
				{
					string empty = string.Empty;
					string empty2 = string.Empty;
					if (type == 0)
					{
						empty = Path.GetDirectoryName(item) + "\\" + text4 + ".aspx";
						empty2 = HttpContext.Current.Server.MapPath("/Platform/WorkFlowFormDesigner/Forms/") + "\\" + text4 + ".aspx";
					}
					else
					{
						empty = Path.GetDirectoryName(item) + "\\" + text4 + ".cshtml";
						empty2 = HttpContext.Current.Server.MapPath("/Views/WorkFlowFormDesigner/Forms/") + "\\" + text4 + ".cshtml";
					}
					if (File.Exists(empty))
					{
						File.Copy(empty, empty2, true);
					}
				}
			}
			Log.Add("导入了流程-" + text3, zipFile, Log.Types.流程相关);
			return "1";
		}

		public List<Step> getBetweenSteps(WorkFlowInstalled runModel, Guid stepID1, Guid stepID2)
		{
			List<Step> list = new List<Step>();
			addBetweenSteps(list, runModel, stepID1, stepID2);
			return list;
		}

		private void addBetweenSteps(List<Step> steps, WorkFlowInstalled runModel, Guid stepID1, Guid stepID2)
		{
			List<Step> list = runModel.Steps.ToList();
			foreach (Line line in runModel.Lines)
			{
				if (line.ToID == stepID2)
				{
					Step step = list.Find((Step p) => p.ID == line.FromID);
					if (step == null || !(step.ID != stepID1))
					{
						break;
					}
					steps.Add(step);
					addBetweenSteps(steps, runModel, stepID1, step.ID);
				}
			}
		}
	}
}
