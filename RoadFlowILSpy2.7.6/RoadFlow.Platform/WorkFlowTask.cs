using LitJson;
using RoadFlow.Data.Factory;
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
		private WorkFlow bWorkFlow = new WorkFlow();

		private IWorkFlowTask dataWorkFlowTask;

		private WorkFlowInstalled wfInstalled;

		private Result result;

		private List<RoadFlow.Data.Model.WorkFlowTask> nextTasks = new List<RoadFlow.Data.Model.WorkFlowTask>();

		private static readonly object lockobj = new object();

		public WorkFlowTask()
		{
			dataWorkFlowTask = Factory.GetWorkFlowTask();
		}

		public int Add(RoadFlow.Data.Model.WorkFlowTask model)
		{
			return dataWorkFlowTask.Add(model);
		}

		public int Update(RoadFlow.Data.Model.WorkFlowTask model)
		{
			return dataWorkFlowTask.Update(model);
		}

		public List<RoadFlow.Data.Model.WorkFlowTask> GetAll()
		{
			return dataWorkFlowTask.GetAll();
		}

		public RoadFlow.Data.Model.WorkFlowTask Get(Guid id)
		{
			return dataWorkFlowTask.Get(id);
		}

		public int Delete(Guid id)
		{
			return dataWorkFlowTask.Delete(id);
		}

		public long GetCount()
		{
			return dataWorkFlowTask.GetCount();
		}

		public bool Equals(RoadFlow.Data.Model.WorkFlowTask task1, RoadFlow.Data.Model.WorkFlowTask task2)
		{
			if (task1.ReceiveID == task2.ReceiveID && task1.StepID == task2.StepID)
			{
				return task1.Sort == task2.Sort;
			}
			return false;
		}

		public int GetHashCode(RoadFlow.Data.Model.WorkFlowTask task)
		{
			return task.ToString().GetHashCode();
		}

		public void UpdateOpenTime(Guid id, DateTime openTime, bool isStatus = false)
		{
			dataWorkFlowTask.UpdateOpenTime(id, openTime, isStatus);
		}

		public Guid GetFirstSnderID(Guid flowID, Guid groupID, bool isDefault = false)
		{
			Guid firstSnderID = dataWorkFlowTask.GetFirstSnderID(flowID, groupID);
			if (!firstSnderID.IsEmptyGuid() || !isDefault)
			{
				return firstSnderID;
			}
			return Users.CurrentUserID;
		}

		public Guid GetFirstSnderDeptID(Guid flowID, Guid groupID)
		{
			if (flowID.IsEmptyGuid() || groupID.IsEmptyGuid())
			{
				return Users.CurrentDeptID;
			}
			Guid firstSnderID = dataWorkFlowTask.GetFirstSnderID(flowID, groupID);
			RoadFlow.Data.Model.Organize deptByUserID = new Users().GetDeptByUserID(firstSnderID);
			if (deptByUserID != null)
			{
				return deptByUserID.ID;
			}
			return Guid.Empty;
		}

		public List<Guid> GetStepSnderID(Guid flowID, Guid stepID, Guid groupID)
		{
			return dataWorkFlowTask.GetStepSnderID(flowID, stepID, groupID);
		}

		public string GetStepSnderIDString(Guid flowID, Guid stepID, Guid groupID)
		{
			List<Guid> stepSnderID = GetStepSnderID(flowID, stepID, groupID);
			StringBuilder stringBuilder = new StringBuilder(stepSnderID.Count * 43);
			foreach (Guid item in stepSnderID)
			{
				stringBuilder.Append("u_");
				stringBuilder.Append(item);
				stringBuilder.Append(",");
			}
			return stringBuilder.ToString().TrimEnd(',');
		}

		public List<Guid> GetPrevSnderID(Guid flowID, Guid stepID, Guid groupID)
		{
			return dataWorkFlowTask.GetPrevSnderID(flowID, stepID, groupID);
		}

		public string GetPrevSnderIDString(Guid flowID, Guid stepID, Guid groupID)
		{
			List<Guid> prevSnderID = dataWorkFlowTask.GetPrevSnderID(flowID, stepID, groupID);
			StringBuilder stringBuilder = new StringBuilder(prevSnderID.Count * 43);
			foreach (Guid item in prevSnderID)
			{
				stringBuilder.Append("u_");
				stringBuilder.Append(item);
				stringBuilder.Append(",");
			}
			return stringBuilder.ToString().TrimEnd(',');
		}

		private Execute GetExecuteModel(string jsonString)
		{
			Execute execute = new Execute();
			Organize organize = new Organize();
			JsonData jsonData = JsonMapper.ToObject(jsonString);
			if (jsonData == null)
			{
				return execute;
			}
			execute.Comment = jsonData["comment"].ToString();
			switch (jsonData["type"].ToString().ToLower())
			{
			case "submit":
				execute.ExecuteType = EnumType.ExecuteType.Submit;
				break;
			case "save":
				execute.ExecuteType = EnumType.ExecuteType.Save;
				break;
			case "back":
				execute.ExecuteType = EnumType.ExecuteType.Back;
				break;
			}
			execute.FlowID = jsonData["flowid"].ToString().ToGuid();
			execute.GroupID = jsonData["groupid"].ToString().ToGuid();
			execute.InstanceID = jsonData["instanceid"].ToString();
			execute.IsSign = (jsonData["issign"].ToString().ToInt() == 1);
			execute.StepID = jsonData["stepid"].ToString().ToGuid();
			execute.TaskID = jsonData["taskid"].ToString().ToGuid();
			JsonData jsonData2 = jsonData["steps"];
			Dictionary<Guid, List<RoadFlow.Data.Model.Users>> dictionary = new Dictionary<Guid, List<RoadFlow.Data.Model.Users>>();
			if (jsonData2.IsArray)
			{
				foreach (JsonData item in (IEnumerable)jsonData2)
				{
					Guid guid = item["id"].ToString().ToGuid();
					string text = item["member"].ToString();
					if (!(guid == Guid.Empty) && !text.IsNullOrEmpty())
					{
						dictionary.Add(guid, organize.GetAllUsers(text));
					}
				}
			}
			execute.Steps = dictionary;
			return execute;
		}

		public Result Execute(string jsonString)
		{
			return Execute(GetExecuteModel(jsonString));
		}

		public bool StartFlow(Guid flowID, List<RoadFlow.Data.Model.Users> users, string title, string instanceID = "")
		{
			if (users.Count != 0)
			{
				try
				{
					foreach (RoadFlow.Data.Model.Users user in users)
					{
						Execute execute = new Execute();
						execute.ExecuteType = EnumType.ExecuteType.Save;
						execute.FlowID = flowID;
						execute.InstanceID = instanceID;
						execute.Title = title;
						execute.Sender = user;
						createFirstTask(execute);
					}
					return true;
				}
				catch (Exception err)
				{
					Log.Add(err);
					return false;
				}
			}
			return false;
		}

		public Result Execute(Execute executeModel)
		{
			result = new Result();
			nextTasks = new List<RoadFlow.Data.Model.WorkFlowTask>();
			if (executeModel.FlowID == Guid.Empty)
			{
				result.DebugMessages = "流程ID错误";
				result.IsSuccess = false;
				result.Messages = "执行参数错误";
				return result;
			}
			wfInstalled = bWorkFlow.GetWorkFlowRunModel(executeModel.FlowID);
			if (wfInstalled == null)
			{
				result.DebugMessages = "未找到流程运行时实体";
				result.IsSuccess = false;
				result.Messages = "流程运行时为空";
				return result;
			}
			lock (lockobj)
			{
				switch (executeModel.ExecuteType)
				{
				case EnumType.ExecuteType.Back:
					executeBack(executeModel);
					break;
				case EnumType.ExecuteType.Save:
					executeSave(executeModel);
					break;
				case EnumType.ExecuteType.Submit:
				case EnumType.ExecuteType.Completed:
					executeSubmit(executeModel);
					break;
				case EnumType.ExecuteType.Redirect:
					executeRedirect(executeModel);
					break;
				case EnumType.ExecuteType.AddWrite:
					executeAddWrite(executeModel);
					break;
				case EnumType.ExecuteType.CopyforCompleted:
					executeCopyforComplete(executeModel);
					break;
				default:
					result.DebugMessages = "流程处理类型为空";
					result.IsSuccess = false;
					result.Messages = "流程处理类型为空";
					return result;
				}
				result.NextTasks = nextTasks;
				if (executeModel.ExecuteType != EnumType.ExecuteType.Save && executeModel.ExecuteType != EnumType.ExecuteType.CopyforCompleted)
				{
					ShortMessage shortMessage = new ShortMessage();
					Users users = new Users();
					Agents agents = new Agents();
					shortMessage.Delete(executeModel.TaskID.ToString(), 1);
					foreach (RoadFlow.Data.Model.WorkFlowTask item in from p in result.NextTasks
					where p.Status == 0
					select p)
					{
						if (!item.ReceiveID.IsEmptyGuid() && !(item.ReceiveID == item.SenderID))
						{
							string text = "";
							text = ((!(HttpContext.Current.Request.Url != null) || !HttpContext.Current.Request.Url.AbsolutePath.EndsWith(".aspx", StringComparison.CurrentCultureIgnoreCase)) ? "/WorkFlowRun/Index" : "/Platform/WorkFlowRun/Default.aspx");
							Guid guid = Guid.NewGuid();
							string contents = "您有一个新的待办任务，流程:" + wfInstalled.Name + "，步骤：" + item.StepName + "。";
							string linkUrl = "javascript:openApp('" + text + "?flowid=" + item.FlowID + "&stepid=" + item.StepID + "&instanceid=" + item.InstanceID + "&taskid=" + item.ID + "&groupid=" + item.GroupID + "',0,'" + item.Title.RemoveHTML().RemovePunctuationOrEmpty() + "','tab_" + item.ID + "');closeMessage('" + guid + "');";
							ShortMessage.Send(item.ReceiveID, item.ReceiveName, "流程待办提醒", contents, 1, linkUrl, item.ID.ToString(), guid.ToString());
							if (RoadFlow.Platform.WeiXin.Config.IsUse)
							{
								new Message().SendText(contents, users.GetAccountByID(item.ReceiveID), "", "", 0, agents.GetAgentIDByCode("weixinagents_waittasks"), true);
							}
						}
					}
				}
				return result;
			}
		}

		private void executeSubmit(Execute executeModel)
		{
			using (TransactionScope transactionScope = new TransactionScope())
			{
				RoadFlow.Data.Model.WorkFlowTask currentTask = null;
				if (executeModel.StepID == wfInstalled.FirstStepID && executeModel.TaskID == Guid.Empty && executeModel.GroupID == Guid.Empty)
				{
					currentTask = createFirstTask(executeModel);
					executeModel.TaskID = currentTask.ID;
				}
				else
				{
					currentTask = Get(executeModel.TaskID);
					if (currentTask == null)
					{
						throw new Exception("未找到要提交的任务");
					}
					if (currentTask.InstanceID.IsNullOrEmpty() && !executeModel.InstanceID.IsNullOrEmpty())
					{
						currentTask.InstanceID = executeModel.InstanceID;
						Update(currentTask);
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
					IEnumerable<Step> source = from p in wfInstalled.Steps
					where p.ID == executeModel.StepID
					select p;
					Step step3 = (source.Count() > 0) ? source.First() : null;
					if (step3 == null)
					{
						this.result.DebugMessages = "未找到当前步骤";
						this.result.IsSuccess = false;
						this.result.Messages = "未找到当前步骤";
					}
					else
					{
						if (step3.Type == "subflow" && step3.SubFlowID.IsGuid() && step3.Behavior.SubFlowStrategy == 0 && !currentTask.SubFlowGroupID.IsNullOrEmpty())
						{
							string[] array = currentTask.SubFlowGroupID.Split(',');
							foreach (string str in array)
							{
								if (!GetInstanceIsCompleted(step3.SubFlowID.ToGuid(), str.ToGuid()))
								{
									this.result.DebugMessages = "当前步骤的子流程实例未完成,子流程：" + step3.SubFlowID + ",实例组：" + currentTask.SubFlowGroupID.ToString();
									this.result.IsSuccess = false;
									this.result.Messages = "当前步骤的子流程未完成,不能提交!";
									return;
								}
							}
						}
						int num = 0;
						bool flag = executeModel.ExecuteType == EnumType.ExecuteType.Completed || executeModel.Steps == null || executeModel.Steps.Count == 0;
						List<RoadFlow.Data.Model.WorkFlowTask> taskList = GetTaskList(currentTask.FlowID, currentTask.StepID, currentTask.GroupID);
						if (currentTask.StepID != wfInstalled.FirstStepID)
						{
							switch (step3.Behavior.HanlderModel)
							{
							case 0:
							{
								List<RoadFlow.Data.Model.WorkFlowTask> list3 = taskList.FindAll(delegate(RoadFlow.Data.Model.WorkFlowTask p)
								{
									if (p.Sort == currentTask.Sort && p.Type != 5)
									{
										return p.Type != 7;
									}
									return false;
								});
								if (list3.Count > 1 && (from p in list3
								where p.Status != 2
								select p).Count() - 1 > 0)
								{
									num = -1;
								}
								if (!flag)
								{
									Completed(currentTask.ID, executeModel.Comment, executeModel.IsSign, 2, "", executeModel.Files);
								}
								break;
							}
							case 1:
								foreach (RoadFlow.Data.Model.WorkFlowTask item in taskList.FindAll(delegate(RoadFlow.Data.Model.WorkFlowTask p)
								{
									if (p.Sort == currentTask.Sort && p.Type != 5)
									{
										return p.Type != 7;
									}
									return false;
								}))
								{
									if (item.ID != currentTask.ID)
									{
										if (item.Status.In(0, 1))
										{
											Completed(item.ID, "", false, 4);
										}
									}
									else if (!flag)
									{
										Completed(item.ID, executeModel.Comment, executeModel.IsSign, 2, "", executeModel.Files);
									}
								}
								break;
							case 2:
							{
								List<RoadFlow.Data.Model.WorkFlowTask> list2 = taskList.FindAll(delegate(RoadFlow.Data.Model.WorkFlowTask p)
								{
									if (p.Sort == currentTask.Sort && p.Type != 5)
									{
										return p.Type != 7;
									}
									return false;
								});
								if (list2.Count > 1)
								{
									decimal d = (step3.Behavior.Percentage <= decimal.Zero) ? 100m : step3.Behavior.Percentage;
									if (((decimal)((from p in list2
									where p.Status == 2
									select p).Count() + 1) / (decimal)list2.Count * 100m).Round() < d)
									{
										num = -1;
									}
									else
									{
										foreach (RoadFlow.Data.Model.WorkFlowTask item2 in list2)
										{
											if (item2.ID != currentTask.ID && item2.Status.In(0, 1))
											{
												Completed(item2.ID, "", false, 4);
											}
										}
									}
								}
								if (!flag)
								{
									Completed(currentTask.ID, executeModel.Comment, executeModel.IsSign, 2, "", executeModel.Files);
								}
								break;
							}
							case 3:
								if (!flag)
								{
									Completed(currentTask.ID, executeModel.Comment, executeModel.IsSign, 2, "", executeModel.Files);
								}
								break;
							case 4:
							{
								List<RoadFlow.Data.Model.WorkFlowTask> list = taskList.FindAll(delegate(RoadFlow.Data.Model.WorkFlowTask p)
								{
									if (p.Sort == currentTask.Sort && p.Type != 5 && p.Type != 7)
									{
										return p.StepSort == currentTask.StepSort + 1;
									}
									return false;
								});
								if (list.Count > 0)
								{
									num = -3;
									foreach (RoadFlow.Data.Model.WorkFlowTask item3 in list)
									{
										item3.Status = 0;
										Update(item3);
									}
								}
								if (!flag)
								{
									Completed(currentTask.ID, executeModel.Comment, executeModel.IsSign, 2, "", executeModel.Files);
								}
								break;
							}
							}
						}
						else if (!flag)
						{
							Completed(currentTask.ID, executeModel.Comment, executeModel.IsSign, 2, "", executeModel.Files);
						}
						if (flag)
						{
							executeComplete(executeModel);
							RoadFlow.Data.Model.WorkFlowTask workFlowTask = GetTaskList(Guid.Empty, currentTask.GroupID).Find((RoadFlow.Data.Model.WorkFlowTask p) => p.OtherType == 4);
							if (workFlowTask != null)
							{
								List<RoadFlow.Data.Model.WorkFlowTask> bySubFlowGroupID = GetBySubFlowGroupID(workFlowTask.GroupID);
								bool flag2 = true;
								foreach (RoadFlow.Data.Model.WorkFlowTask item4 in bySubFlowGroupID)
								{
									if (!flag2)
									{
										break;
									}
									string[] array = item4.SubFlowGroupID.Split(',');
									foreach (string str2 in array)
									{
										if (!GetInstanceIsCompleted(workFlowTask.FlowID, str2.ToGuid()))
										{
											flag2 = false;
											break;
										}
									}
								}
								if (flag2)
								{
									foreach (RoadFlow.Data.Model.WorkFlowTask item5 in bySubFlowGroupID)
									{
										Result result = AutoSubmit(item5);
										Log.Add("子流程完成后提交主流程步骤-" + item5.Title, "是否成功：" + result.IsSuccess.ToString() + " 信息：" + result.DebugMessages, Log.Types.流程相关);
									}
								}
							}
							transactionScope.Complete();
						}
						else
						{
							foreach (RoadFlow.Data.Model.WorkFlowTask item6 in taskList.FindAll(delegate(RoadFlow.Data.Model.WorkFlowTask p)
							{
								if (p.Sort == currentTask.Sort && p.Type != 5)
								{
									return p.Type != 7;
								}
								return false;
							}))
							{
								List<RoadFlow.Data.Model.WorkFlowTask> list4 = taskList.FindAll(delegate(RoadFlow.Data.Model.WorkFlowTask p)
								{
									if (p.PrevID == item6.ID)
									{
										return p.Type == 7;
									}
									return false;
								});
								if (item6.ID == currentTask.ID && list4.Count > 0)
								{
									foreach (RoadFlow.Data.Model.WorkFlowTask item7 in list4)
									{
										if (item7.OtherType.HasValue)
										{
											int num2 = item7.OtherType.Value.ToString().Left(1).ToString()
												.ToInt();
											int num3 = item7.OtherType.Value.ToString().Right(1).ToString()
												.ToInt();
											if (num2 == 2 && (num3.In(1, 2) || (num3 == 3 && item7.ReceiveID == (from p in list4.FindAll((RoadFlow.Data.Model.WorkFlowTask p) => p.Status.In(-1, 0, 1))
											orderby p.ReceiveTime
											select p).FirstOrDefault().ReceiveID)))
											{
												item7.Status = 0;
												Update(item7);
											}
										}
									}
								}
								List<RoadFlow.Data.Model.WorkFlowTask> list5 = new List<RoadFlow.Data.Model.WorkFlowTask>();
								if (list4.Count > 0 && !isPassingAddWrite(list4.FirstOrDefault(), out list5))
								{
									num = -2;
									break;
								}
							}
							if (num == -1 || num == -2 || num == -3)
							{
								List<RoadFlow.Data.Model.WorkFlowTask> list6 = createTempTasks(executeModel, currentTask);
								List<string> list7 = new List<string>();
								foreach (RoadFlow.Data.Model.WorkFlowTask item8 in list6)
								{
									list7.Add(item8.StepName);
								}
								nextTasks.AddRange(list6);
								string text = list7.Distinct().ToArray().Join1();
								Result obj = this.result;
								string debugMessages = obj.DebugMessages;
								string arg = text;
								object arg2;
								switch (num)
								{
								default:
									arg2 = "其他人未处理";
									break;
								case -3:
									arg2 = "顺序处理的下一人处理";
									break;
								case -2:
									arg2 = "加签人未处理";
									break;
								}
								obj.DebugMessages = debugMessages + string.Format("已发送到:{0},{1},不创建后续任务", arg, arg2);
								this.result.IsSuccess = true;
								Result obj2 = this.result;
								string messages = obj2.Messages;
								string arg3 = text;
								object arg4;
								switch (num)
								{
								default:
									arg4 = ",等待他人处理";
									break;
								case -3:
									arg4 = "";
									break;
								case -2:
									arg4 = ",等待加签人处理";
									break;
								}
								obj2.Messages = messages + string.Format("已发送到:{0}{1}!", arg3, arg4);
								this.result.NextTasks = nextTasks;
								transactionScope.Complete();
							}
							else
							{
								List<RoadFlow.Data.Model.WorkFlowTask> list8 = new List<RoadFlow.Data.Model.WorkFlowTask>();
								foreach (KeyValuePair<Guid, List<RoadFlow.Data.Model.Users>> step6 in executeModel.Steps)
								{
									Guid groupID = Guid.NewGuid();
									StringBuilder stringBuilder = new StringBuilder();
									List<RoadFlow.Data.Model.WorkFlowTask> list9 = new List<RoadFlow.Data.Model.WorkFlowTask>();
									int num4 = 0;
									foreach (RoadFlow.Data.Model.Users item9 in step6.Value)
									{
										if (wfInstalled == null)
										{
											wfInstalled = bWorkFlow.GetWorkFlowRunModel(executeModel.FlowID);
										}
										IEnumerable<Step> source2 = from p in wfInstalled.Steps
										where p.ID == step6.Key
										select p;
										if (source2.Count() != 0)
										{
											Step step4 = source2.First();
											bool flag3 = step4.Behavior.Countersignature == 0;
											if (step4.Behavior.Countersignature != 0)
											{
												List<Step> prevSteps = bWorkFlow.GetPrevSteps(executeModel.FlowID, step4.ID);
												if (prevSteps.Count > 1)
												{
													Guid prevStepID = currentTask.PrevStepID;
													switch (step4.Behavior.Countersignature)
													{
													case 1:
														flag3 = true;
														foreach (Step item10 in prevSteps)
														{
															if (!IsPassing(item10, executeModel.FlowID, executeModel.GroupID, currentTask, prevStepID))
															{
																flag3 = false;
																break;
															}
														}
														break;
													case 2:
														flag3 = false;
														foreach (Step item11 in prevSteps)
														{
															if (IsPassing(item11, executeModel.FlowID, executeModel.GroupID, currentTask, prevStepID))
															{
																flag3 = true;
																break;
															}
														}
														break;
													case 3:
													{
														int num5 = 0;
														if (prevSteps.Count == 0)
														{
															flag3 = true;
														}
														else
														{
															foreach (Step item12 in prevSteps)
															{
																if (IsPassing(item12, executeModel.FlowID, executeModel.GroupID, currentTask, prevStepID))
																{
																	num5++;
																}
															}
															flag3 = (((decimal)num5 / (decimal)prevSteps.Count * 100m).Round() >= ((step4.Behavior.CountersignaturePercentage <= decimal.Zero) ? 100m : step4.Behavior.CountersignaturePercentage));
														}
														break;
													}
													}
												}
												else
												{
													flag3 = true;
												}
												if (flag3)
												{
													foreach (RoadFlow.Data.Model.WorkFlowTask task in GetTaskList(currentTask.ID, false))
													{
														if (!(task.ID == currentTask.ID) && task.Type != 5 && !task.Status.In(2, 3, 4, 5, 6, 7))
														{
															Completed(task.ID, "", false, 4);
														}
													}
												}
											}
											if (flag3)
											{
												RoadFlow.Data.Model.WorkFlowTask workFlowTask2 = new RoadFlow.Data.Model.WorkFlowTask();
												if (executeModel.StepCompletedTimes.Keys.Contains(step4.ID))
												{
													workFlowTask2.CompletedTime = executeModel.StepCompletedTimes[step4.ID];
												}
												else if (step4.WorkTime > decimal.Zero)
												{
													workFlowTask2.CompletedTime = new WorkCalendar().GetWorkDate((double)step4.WorkTime, DateTimeNew.Now);
												}
												workFlowTask2.IsExpiredAutoSubmit = step4.TimeOutModel;
												workFlowTask2.FlowID = executeModel.FlowID;
												workFlowTask2.GroupID = ((currentTask != null) ? currentTask.GroupID : executeModel.GroupID);
												workFlowTask2.ID = Guid.NewGuid();
												workFlowTask2.Type = 0;
												workFlowTask2.InstanceID = executeModel.InstanceID;
												if (!executeModel.Note.IsNullOrEmpty())
												{
													workFlowTask2.Note = executeModel.Note;
												}
												workFlowTask2.PrevID = currentTask.ID;
												workFlowTask2.PrevStepID = currentTask.StepID;
												workFlowTask2.ReceiveID = item9.ID;
												workFlowTask2.ReceiveName = item9.Name;
												workFlowTask2.ReceiveTime = DateTimeNew.Now;
												workFlowTask2.SenderID = executeModel.Sender.ID;
												workFlowTask2.SenderName = executeModel.Sender.Name;
												workFlowTask2.SenderTime = workFlowTask2.ReceiveTime;
												workFlowTask2.StepID = step6.Key;
												workFlowTask2.StepName = step4.Name;
												workFlowTask2.Sort = currentTask.Sort + 1;
												workFlowTask2.Title = (executeModel.Title.IsNullOrEmpty() ? currentTask.Title : executeModel.Title);
												workFlowTask2.OtherType = executeModel.OtherType;
												if (4 != step4.Behavior.HanlderModel)
												{
													workFlowTask2.Status = num;
												}
												else
												{
													workFlowTask2.Status = ((num4 != 0) ? (-1) : 0);
												}
												workFlowTask2.StepSort = num4++;
												if (step4.Type == "subflow" && step4.SubFlowID.IsGuid())
												{
													Execute execute = null;
													if (!step4.Event.SubFlowActivationBefore.IsNullOrEmpty())
													{
														object obj3 = ExecuteFlowCustomEvent(step4.Event.SubFlowActivationBefore.Trim(), new WorkFlowCustomEventParams
														{
															FlowID = executeModel.FlowID,
															GroupID = currentTask.GroupID,
															InstanceID = currentTask.InstanceID,
															StepID = executeModel.StepID,
															TaskID = currentTask.ID
														});
														if (obj3 is Execute)
														{
															execute = (Execute)obj3;
														}
													}
													if (execute == null)
													{
														execute = new Execute();
													}
													execute.ExecuteType = EnumType.ExecuteType.Save;
													execute.FlowID = step4.SubFlowID.ToGuid();
													execute.Sender = item9;
													if (execute.Title.IsNullOrEmpty())
													{
														execute.Title = bWorkFlow.GetFlowName(execute.FlowID);
													}
													if (execute.InstanceID.IsNullOrEmpty())
													{
														execute.InstanceID = "";
													}
													if (step4.SubFlowTaskType == 0)
													{
														execute.GroupID = groupID;
													}
													else
													{
														execute.GroupID = Guid.NewGuid();
														stringBuilder.Append(execute.GroupID.ToString());
														stringBuilder.Append(",");
													}
													execute.OtherType = 4;
													createFirstTask(execute, true);
													workFlowTask2.ReceiveID = currentTask.ReceiveID;
													workFlowTask2.ReceiveName = currentTask.ReceiveName;
													workFlowTask2.SubFlowGroupID = Guid.Empty.ToString();
													workFlowTask2.OtherType = ((step4.Behavior.SubFlowStrategy == 0) ? 2 : 3);
													workFlowTask2.Type = 6;
												}
												nextTasks.Add(workFlowTask2);
												list9.Add(workFlowTask2);
											}
										}
									}
									foreach (RoadFlow.Data.Model.WorkFlowTask item13 in list9.Distinct())
									{
										if (step3.Behavior.HanlderModel == 3 || !HasNoCompletedTasks(executeModel.FlowID, step6.Key, currentTask.GroupID, item13.ReceiveID))
										{
											if (item13.Type == 6)
											{
												if (stringBuilder.Length == 0)
												{
													item13.SubFlowGroupID = groupID.ToString();
												}
												else
												{
													item13.SubFlowGroupID = stringBuilder.ToString().TrimEnd(',');
												}
												Add(item13);
												if (item13.OtherType == 3)
												{
													list8.Add(item13);
												}
											}
											else
											{
												Add(item13);
											}
										}
									}
								}
								if (nextTasks.Count > 0)
								{
									IEnumerable<IGrouping<Guid, RoadFlow.Data.Model.WorkFlowTask>> enumerable = from p in nextTasks
									group p by p.StepID;
									if (wfInstalled == null)
									{
										wfInstalled = bWorkFlow.GetWorkFlowRunModel(executeModel.FlowID);
									}
									foreach (IGrouping<Guid, RoadFlow.Data.Model.WorkFlowTask> item14 in enumerable)
									{
										IEnumerable<Step> source3 = from p in wfInstalled.Steps
										where p.ID == item14.Key
										select p;
										if (source3.Count() != 0 && source3.First().Behavior.HanlderModel != 4)
										{
											dataWorkFlowTask.UpdateTempTasks(nextTasks.FirstOrDefault().FlowID, item14.Key, nextTasks.FirstOrDefault().GroupID, nextTasks.FirstOrDefault().CompletedTime, nextTasks.FirstOrDefault().ReceiveTime);
										}
									}
									if (executeModel.OtherType != 1 && step3.Behavior.HanlderModel != 3 && step3.Behavior.HanlderModel != 4)
									{
										foreach (RoadFlow.Data.Model.WorkFlowTask task2 in GetTaskList(currentTask.FlowID, currentTask.StepID, currentTask.GroupID))
										{
											if (task2.Status.In(-1, 0, 1) && task2.Type != 5 && task2.OtherType != 1)
											{
												Completed(task2.ID, "", false, 4);
											}
										}
									}
									if (wfInstalled == null)
									{
										wfInstalled = bWorkFlow.GetWorkFlowRunModel(executeModel.FlowID);
									}
									foreach (KeyValuePair<Guid, List<RoadFlow.Data.Model.Users>> step7 in executeModel.Steps)
									{
										IEnumerable<Step> source4 = from p in wfInstalled.Steps
										where p.ID == step7.Key
										select p;
										if (source4.Count() > 0)
										{
											Step step5 = source4.First();
											foreach (RoadFlow.Data.Model.Users copyForUser in GetCopyForUsers(step5.CopyFor, currentTask))
											{
												if (nextTasks.Find((RoadFlow.Data.Model.WorkFlowTask p) => p.ReceiveID == copyForUser.ID) == null)
												{
													RoadFlow.Data.Model.WorkFlowTask workFlowTask3 = new RoadFlow.Data.Model.WorkFlowTask();
													if (executeModel.StepCompletedTimes.Keys.Contains(step5.ID))
													{
														workFlowTask3.CompletedTime = executeModel.StepCompletedTimes[step5.ID];
													}
													else if (step5.WorkTime > decimal.Zero)
													{
														workFlowTask3.CompletedTime = new WorkCalendar().GetWorkDate((double)step5.WorkTime, DateTimeNew.Now);
													}
													workFlowTask3.FlowID = executeModel.FlowID;
													workFlowTask3.GroupID = ((currentTask != null) ? currentTask.GroupID : executeModel.GroupID);
													workFlowTask3.ID = Guid.NewGuid();
													workFlowTask3.Type = 5;
													workFlowTask3.InstanceID = executeModel.InstanceID;
													workFlowTask3.Note = (executeModel.Note.IsNullOrEmpty() ? "抄送" : (executeModel.Note + "(抄送)"));
													workFlowTask3.PrevID = currentTask.ID;
													workFlowTask3.PrevStepID = currentTask.StepID;
													workFlowTask3.ReceiveID = copyForUser.ID;
													workFlowTask3.ReceiveName = copyForUser.Name;
													workFlowTask3.ReceiveTime = DateTimeNew.Now;
													workFlowTask3.SenderID = executeModel.Sender.ID;
													workFlowTask3.SenderName = executeModel.Sender.Name;
													workFlowTask3.SenderTime = workFlowTask3.ReceiveTime;
													workFlowTask3.Status = num;
													workFlowTask3.StepID = step7.Key;
													workFlowTask3.StepName = step5.Name;
													workFlowTask3.Sort = currentTask.Sort + 1;
													workFlowTask3.StepSort = 0;
													workFlowTask3.Title = (executeModel.Title.IsNullOrEmpty() ? currentTask.Title : executeModel.Title);
													if (!HasNoCompletedTasks(executeModel.FlowID, step7.Key, currentTask.GroupID, copyForUser.ID))
													{
														Add(workFlowTask3);
													}
												}
											}
										}
									}
									List<string> list10 = new List<string>();
									foreach (RoadFlow.Data.Model.WorkFlowTask nextTask in nextTasks)
									{
										list10.Add(nextTask.StepName);
									}
									string arg5 = list10.Distinct().ToArray().Join1();
									this.result.DebugMessages += string.Format("已发送到:{0}", arg5);
									this.result.IsSuccess = true;
									this.result.Messages += string.Format("已发送到:{0}", arg5);
									this.result.NextTasks = nextTasks;
								}
								else
								{
									List<RoadFlow.Data.Model.WorkFlowTask> list11 = createTempTasks(executeModel, currentTask);
									List<string> list12 = new List<string>();
									foreach (RoadFlow.Data.Model.WorkFlowTask item15 in list11)
									{
										list12.Add(item15.StepName);
									}
									nextTasks.AddRange(list11);
									string arg6 = list12.Distinct().ToArray().Join1();
									this.result.DebugMessages += string.Format("已发到:{0},等待其它步骤处理", arg6);
									this.result.IsSuccess = true;
									this.result.Messages += string.Format("已发送:{0},等待其它步骤处理", arg6);
									this.result.NextTasks = nextTasks;
								}
								if (list8.Count > 0)
								{
									foreach (RoadFlow.Data.Model.WorkFlowTask item16 in list8)
									{
										AutoSubmit(item16);
									}
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
			RoadFlow.Data.Model.WorkFlowTask currentTask = Get(executeModel.TaskID);
			if (currentTask == null)
			{
				result.DebugMessages = "未能找到当前任务";
				result.IsSuccess = false;
				result.Messages = "未能找到当前任务";
			}
			else if (currentTask.Status.In(2, 3, 4, 5, 6, 7))
			{
				result.DebugMessages = "当前任务已处理";
				result.IsSuccess = false;
				result.Messages = "当前任务已处理";
			}
			else if (currentTask.ReceiveID != Users.CurrentUserID && currentTask.ReceiveID != RoadFlow.Platform.WeiXin.Organize.CurrentUserID && currentTask.IsExpiredAutoSubmit == 0)
			{
				result.DebugMessages = "不能处理当前任务";
				result.IsSuccess = false;
				result.Messages = "不能处理当前任务";
			}
			else
			{
				IEnumerable<Step> source = from p in wfInstalled.Steps
				where p.ID == currentTask.StepID
				select p;
				Step step = (source.Count() > 0) ? source.First() : null;
				if (step == null)
				{
					result.DebugMessages = "未能找到当前步骤";
					result.IsSuccess = false;
					result.Messages = "未能找到当前步骤";
				}
				else if (currentTask.StepID == wfInstalled.FirstStepID)
				{
					result.DebugMessages = "当前任务是流程第一步,不能退回";
					result.IsSuccess = false;
					result.Messages = "当前任务是流程第一步,不能退回";
				}
				else
				{
					if (step.Behavior.HanlderModel == 4)
					{
						List<RoadFlow.Data.Model.WorkFlowTask> taskList = GetTaskList(currentTask.ID);
						if (currentTask.StepSort == 0)
						{
							foreach (RoadFlow.Data.Model.WorkFlowTask item in taskList)
							{
								if (item.ID != currentTask.ID && item.Status == -1)
								{
									Delete(item.ID);
								}
							}
						}
						RoadFlow.Data.Model.WorkFlowTask workFlowTask = taskList.Find((RoadFlow.Data.Model.WorkFlowTask p) => p.StepSort == currentTask.StepSort - 1);
						if (workFlowTask != null)
						{
							using (TransactionScope transactionScope = new TransactionScope())
							{
								Completed(currentTask.ID, executeModel.Comment, executeModel.IsSign, 3, "", executeModel.Files);
								workFlowTask.Status = 0;
								workFlowTask.Type = 4;
								workFlowTask.Comment = "";
								workFlowTask.CompletedTime1 = null;
								workFlowTask.IsSign = 0;
								workFlowTask.Note = "";
								Update(workFlowTask);
								transactionScope.Complete();
								nextTasks.Add(workFlowTask);
								result.DebugMessages = "已退回到：" + workFlowTask.StepName + "(" + workFlowTask.ReceiveName + ")";
								result.IsSuccess = true;
								result.Messages = "已退回到：" + workFlowTask.StepName + "(" + workFlowTask.ReceiveName + ")";
								result.NextTasks = nextTasks;
							}
							return;
						}
					}
					if (currentTask.Type == 7 && currentTask.OtherType.HasValue)
					{
						int num = currentTask.OtherType.Value.ToString().Left(1).ToInt();
						int num2 = currentTask.OtherType.Value.ToString().Right(1).ToInt();
						List<RoadFlow.Data.Model.WorkFlowTask> list = GetTaskList(currentTask.FlowID, currentTask.StepID, currentTask.GroupID).FindAll(delegate(RoadFlow.Data.Model.WorkFlowTask p)
						{
							if (p.PrevID == currentTask.PrevID)
							{
								return p.Type == 7;
							}
							return false;
						});
						bool flag = false;
						using (TransactionScope transactionScope2 = new TransactionScope())
						{
							switch (num2)
							{
							case 1:
							case 3:
								foreach (RoadFlow.Data.Model.WorkFlowTask item2 in list)
								{
									if (item2.ID == currentTask.ID)
									{
										Completed(currentTask.ID, executeModel.Comment, executeModel.IsSign, 3, "", executeModel.Files);
									}
									else if (item2.Status.In(-1, 0, 1))
									{
										item2.Status = 5;
										Update(item2);
									}
								}
								flag = true;
								break;
							case 2:
								Completed(currentTask.ID, executeModel.Comment, executeModel.IsSign, 3, "", executeModel.Files);
								if (list.FindAll(delegate(RoadFlow.Data.Model.WorkFlowTask p)
								{
									if (p.Status.In(-1, 0, 1))
									{
										return p.ID != currentTask.ID;
									}
									return false;
								}).Count == 0)
								{
									flag = true;
								}
								break;
							}
							if (flag)
							{
								RoadFlow.Data.Model.WorkFlowTask workFlowTask2 = Get(currentTask.PrevID);
								if (workFlowTask2 != null)
								{
									if (num == 2)
									{
										foreach (RoadFlow.Data.Model.WorkFlowTask nextTask in GetNextTaskList(workFlowTask2.ID))
										{
											if (nextTask.Status == -1)
											{
												Delete(nextTask.ID);
											}
										}
									}
									workFlowTask2.Status = 0;
									Update(workFlowTask2);
									nextTasks.Add(workFlowTask2);
									Result obj = result;
									obj.DebugMessages = obj.DebugMessages + "已退回到" + workFlowTask2.ReceiveName;
									result.IsSuccess = true;
									result.Messages += result.DebugMessages;
									result.NextTasks = nextTasks;
								}
								else
								{
									result.DebugMessages += "未找到前一任务";
									result.IsSuccess = false;
									result.Messages += result.DebugMessages;
									result.NextTasks = nextTasks;
								}
							}
							else
							{
								result.DebugMessages += "已退回,等待他人处理";
								result.IsSuccess = true;
								result.Messages += result.DebugMessages;
								result.NextTasks = nextTasks;
							}
							transactionScope2.Complete();
						}
					}
					else if (4 == step.Behavior.BackModel)
					{
						RoadFlow.Data.Model.WorkFlowTask workFlowTask3 = Get(currentTask.PrevID);
						if (workFlowTask3 != null)
						{
							workFlowTask3.ID = Guid.NewGuid();
							workFlowTask3.PrevID = currentTask.ID;
							workFlowTask3.Note = "退回任务";
							workFlowTask3.ReceiveTime = DateTimeNew.Now;
							workFlowTask3.SenderID = currentTask.ReceiveID;
							workFlowTask3.SenderName = currentTask.ReceiveName;
							workFlowTask3.SenderTime = workFlowTask3.ReceiveTime;
							workFlowTask3.Sort = currentTask.Sort + 1;
							workFlowTask3.Status = 0;
							workFlowTask3.Type = 4;
							workFlowTask3.Comment = "";
							workFlowTask3.OpenTime = null;
							if (step.WorkTime > decimal.Zero)
							{
								workFlowTask3.CompletedTime = new WorkCalendar().GetWorkDate((double)step.WorkTime, DateTimeNew.Now);
							}
							else
							{
								workFlowTask3.CompletedTime = null;
							}
							workFlowTask3.CompletedTime1 = null;
							using (TransactionScope transactionScope3 = new TransactionScope())
							{
								Add(workFlowTask3);
								nextTasks.Add(workFlowTask3);
								Completed(currentTask.ID, executeModel.Comment, executeModel.IsSign, 3, "", executeModel.Files);
								transactionScope3.Complete();
							}
							List<string> list2 = new List<string>();
							foreach (RoadFlow.Data.Model.WorkFlowTask nextTask2 in nextTasks)
							{
								list2.Add(nextTask2.StepName);
							}
							string text = string.Format("已退回到:{0}", workFlowTask3.ReceiveName);
							result.DebugMessages += text;
							result.IsSuccess = true;
							result.Messages += text;
							result.NextTasks = nextTasks;
						}
						else
						{
							string text2 = string.Format("未找到发送者");
							result.DebugMessages += text2;
							result.IsSuccess = true;
							result.Messages += text2;
							result.NextTasks = nextTasks;
						}
					}
					else
					{
						using (TransactionScope transactionScope4 = new TransactionScope())
						{
							List<RoadFlow.Data.Model.WorkFlowTask> list3 = new List<RoadFlow.Data.Model.WorkFlowTask>();
							int num3 = 0;
							int num4 = step.Behavior.BackModel;
							int num5 = step.Behavior.HanlderModel;
							switch (num4)
							{
							case 2:
								num4 = 1;
								num5 = 0;
								break;
							case 3:
								num4 = 1;
								num5 = 1;
								break;
							}
							switch (num4)
							{
							case 0:
								result.DebugMessages = "当前步骤设置为不能退回";
								result.IsSuccess = false;
								result.Messages = "当前步骤设置为不能退回";
								return;
							case 1:
								switch (num5)
								{
								case 0:
									foreach (RoadFlow.Data.Model.WorkFlowTask item3 in GetTaskList(currentTask.FlowID, currentTask.StepID, currentTask.GroupID).FindAll(delegate(RoadFlow.Data.Model.WorkFlowTask p)
									{
										if (p.Sort == currentTask.Sort)
										{
											return p.Type != 5;
										}
										return false;
									}))
									{
										if (item3.ID != currentTask.ID)
										{
											if (item3.Status.In(0, 1))
											{
												Completed(item3.ID, "", false, 5);
											}
										}
										else
										{
											Completed(item3.ID, executeModel.Comment, executeModel.IsSign, 3, "", executeModel.Files);
										}
									}
									break;
								case 1:
								{
									List<RoadFlow.Data.Model.WorkFlowTask> list5 = GetTaskList(currentTask.FlowID, currentTask.StepID, currentTask.GroupID).FindAll(delegate(RoadFlow.Data.Model.WorkFlowTask p)
									{
										if (p.Sort == currentTask.Sort)
										{
											return p.Type != 5;
										}
										return false;
									});
									if (list5.Count > 1 && (from p in list5
									where p.Status != 3
									select p).Count() - 1 > 0)
									{
										num3 = -1;
									}
									Completed(currentTask.ID, executeModel.Comment, executeModel.IsSign, 3, "", executeModel.Files);
									break;
								}
								case 2:
								{
									List<RoadFlow.Data.Model.WorkFlowTask> list4 = GetTaskList(currentTask.FlowID, currentTask.StepID, currentTask.GroupID).FindAll(delegate(RoadFlow.Data.Model.WorkFlowTask p)
									{
										if (p.Sort == currentTask.Sort)
										{
											return p.Type != 5;
										}
										return false;
									});
									if (list4.Count > 1)
									{
										decimal d = (step.Behavior.Percentage <= decimal.Zero) ? 100m : step.Behavior.Percentage;
										if (((decimal)((from p in list4
										where p.Status == 3
										select p).Count() + 1) / (decimal)list4.Count * 100m).Round() < 100m - d)
										{
											num3 = -1;
										}
										else
										{
											foreach (RoadFlow.Data.Model.WorkFlowTask item4 in list4)
											{
												if (item4.ID != currentTask.ID && item4.Status.In(0, 1))
												{
													Completed(item4.ID, "", false, 5);
												}
											}
										}
									}
									Completed(currentTask.ID, executeModel.Comment, executeModel.IsSign, 3, "", executeModel.Files);
									break;
								}
								case 3:
									Completed(currentTask.ID, executeModel.Comment, executeModel.IsSign, 3, "", executeModel.Files);
									break;
								}
								list3.Add(currentTask);
								break;
							}
							if (num3 == -1)
							{
								result.DebugMessages += "已退回,等待他人处理";
								result.IsSuccess = true;
								result.Messages += "已退回,等待他人处理!";
								result.NextTasks = nextTasks;
								transactionScope4.Complete();
								return;
							}
							foreach (RoadFlow.Data.Model.WorkFlowTask item5 in list3)
							{
								if (!item5.Status.In(2, 3))
								{
									if (item5.ID == currentTask.ID)
									{
										Completed(item5.ID, executeModel.Comment, executeModel.IsSign, 3, "", executeModel.Files);
									}
									else
									{
										Completed(item5.ID, "", false, 5, "他人已退回");
									}
								}
							}
							List<RoadFlow.Data.Model.WorkFlowTask> list6 = new List<RoadFlow.Data.Model.WorkFlowTask>();
							foreach (KeyValuePair<Guid, List<RoadFlow.Data.Model.Users>> step3 in executeModel.Steps)
							{
								List<RoadFlow.Data.Model.WorkFlowTask> list7 = GetTaskList(executeModel.FlowID, step3.Key, executeModel.GroupID).FindAll((RoadFlow.Data.Model.WorkFlowTask p) => p.Type != 7);
								if (list7.Count > 0)
								{
									list7 = (from p in list7
									orderby p.Sort descending
									select p).ToList();
									int maxSort = list7.First().Sort;
									list6.AddRange(list7.FindAll((RoadFlow.Data.Model.WorkFlowTask p) => p.Sort == maxSort));
								}
							}
							Step step2 = bWorkFlow.GetNextSteps(executeModel.FlowID, executeModel.StepID).Find((Step p) => p.Behavior.Countersignature != 0);
							bool flag2 = step2 != null;
							bool flag3 = true;
							if (flag2)
							{
								List<Step> prevSteps = bWorkFlow.GetPrevSteps(executeModel.FlowID, step2.ID);
								switch (step2.Behavior.Countersignature)
								{
								case 1:
									flag3 = false;
									foreach (Step item6 in prevSteps)
									{
										if (IsBack(item6, executeModel.FlowID, currentTask.GroupID, currentTask.PrevID, currentTask.Sort))
										{
											flag3 = true;
											break;
										}
									}
									break;
								case 2:
									flag3 = true;
									foreach (Step item7 in prevSteps)
									{
										if (!IsBack(item7, executeModel.FlowID, currentTask.GroupID, currentTask.PrevID, currentTask.Sort))
										{
											flag3 = false;
											break;
										}
									}
									break;
								case 3:
								{
									int num6 = 0;
									foreach (Step item8 in prevSteps)
									{
										if (IsBack(item8, executeModel.FlowID, currentTask.GroupID, currentTask.PrevID, currentTask.Sort))
										{
											num6++;
										}
									}
									flag3 = (((decimal)num6 / (decimal)prevSteps.Count * 100m).Round() >= ((step2.Behavior.CountersignaturePercentage <= decimal.Zero) ? 100m : step2.Behavior.CountersignaturePercentage));
									break;
								}
								}
								if (flag3)
								{
									foreach (RoadFlow.Data.Model.WorkFlowTask task in GetTaskList(currentTask.ID, false))
									{
										if (!(task.ID == currentTask.ID) && !task.Status.In(2, 3, 4, 5, 6, 7))
										{
											Completed(task.ID, "", false, 5);
										}
									}
								}
							}
							if (step.Type == "subflow" && step.SubFlowID.IsGuid() && !currentTask.SubFlowGroupID.IsNullOrEmpty())
							{
								string[] array = currentTask.SubFlowGroupID.Split(',');
								foreach (string str in array)
								{
									DeleteInstance(step.SubFlowID.ToGuid(), str.ToGuid(), true);
								}
							}
							if (flag3)
							{
								IEnumerable<RoadFlow.Data.Model.WorkFlowTask> enumerable = list6.Distinct(this);
								if (enumerable.Count() == 0)
								{
									Completed(currentTask.ID, "", false, 0);
									result.DebugMessages += "没有接收人,退回失败!";
									result.IsSuccess = false;
									result.Messages += "没有接收人,退回失败!";
									result.NextTasks = nextTasks;
									transactionScope4.Complete();
									return;
								}
								foreach (RoadFlow.Data.Model.WorkFlowTask item9 in enumerable)
								{
									if (item9 != null)
									{
										if (item9.Type == 5)
										{
											Delete(item9.ID);
										}
										else if (item9.OtherType == 1)
										{
											RoadFlow.Data.Model.WorkFlowTask workFlowTask4 = Get(item9.PrevID);
											if (workFlowTask4 != null)
											{
												workFlowTask4.OpenTime = null;
												workFlowTask4.Status = 0;
												Update(workFlowTask4);
												Delete(item9.ID);
												nextTasks.Add(workFlowTask4);
											}
										}
										else
										{
											RoadFlow.Data.Model.WorkFlowTask workFlowTask5 = item9;
											workFlowTask5.ID = Guid.NewGuid();
											workFlowTask5.PrevID = currentTask.ID;
											workFlowTask5.Note = "退回任务";
											workFlowTask5.ReceiveTime = DateTimeNew.Now;
											workFlowTask5.SenderID = currentTask.ReceiveID;
											workFlowTask5.SenderName = currentTask.ReceiveName;
											workFlowTask5.SenderTime = DateTimeNew.Now;
											workFlowTask5.Sort = currentTask.Sort + 1;
											workFlowTask5.Status = 0;
											workFlowTask5.Type = 4;
											workFlowTask5.Comment = "";
											workFlowTask5.OpenTime = null;
											if (step.WorkTime > decimal.Zero)
											{
												workFlowTask5.CompletedTime = new WorkCalendar().GetWorkDate((double)step.WorkTime, DateTimeNew.Now);
											}
											else
											{
												workFlowTask5.CompletedTime = null;
											}
											workFlowTask5.CompletedTime1 = null;
											Add(workFlowTask5);
											nextTasks.Add(workFlowTask5);
										}
									}
								}
								foreach (Step nextStep in bWorkFlow.GetNextSteps(executeModel.FlowID, executeModel.StepID))
								{
									dataWorkFlowTask.DeleteTempTasks(currentTask.FlowID, nextStep.ID, currentTask.GroupID, flag2 ? Guid.Empty : step.ID);
								}
							}
							transactionScope4.Complete();
						}
						if (nextTasks.Count > 0)
						{
							foreach (IGrouping<Guid, RoadFlow.Data.Model.WorkFlowTask> item10 in from p in nextTasks
							group p by p.StepID)
							{
								if (item10.Count() > 0 && item10.First().StepSort != item10.Last().StepSort)
								{
									int num7 = item10.Max((RoadFlow.Data.Model.WorkFlowTask p) => p.StepSort);
									foreach (RoadFlow.Data.Model.WorkFlowTask item11 in item10)
									{
										if (item11.StepSort != num7)
										{
											item11.Status = -1;
											nextTasks.Remove(item11);
											Update(item11);
										}
									}
								}
							}
							List<string> list8 = new List<string>();
							foreach (RoadFlow.Data.Model.WorkFlowTask nextTask3 in nextTasks)
							{
								list8.Add(nextTask3.StepName);
							}
							string text3 = string.Format("已退回到:{0}", list8.Distinct().ToArray().Join1());
							result.DebugMessages += text3;
							result.IsSuccess = true;
							result.Messages += text3;
							result.NextTasks = nextTasks;
						}
						else
						{
							result.DebugMessages += "已退回,等待其它步骤处理";
							result.IsSuccess = true;
							result.Messages += "已退回,等待其它步骤处理";
							result.NextTasks = nextTasks;
						}
					}
				}
			}
		}

		private void executeSave(Execute executeModel)
		{
			RoadFlow.Data.Model.WorkFlowTask workFlowTask = null;
			bool flag = executeModel.StepID == wfInstalled.FirstStepID && executeModel.TaskID == Guid.Empty && executeModel.GroupID == Guid.Empty;
			workFlowTask = ((!flag) ? Get(executeModel.TaskID) : createFirstTask(executeModel));
			if (workFlowTask == null)
			{
				result.DebugMessages = "未能创建或找到当前任务";
				result.IsSuccess = false;
				result.Messages = "未能创建或找到当前任务";
			}
			else if (workFlowTask.Status.In(2, 3, 4, 5, 6, 7))
			{
				result.DebugMessages = "当前任务已处理";
				result.IsSuccess = false;
				result.Messages = "当前任务已处理";
			}
			else if (workFlowTask.ReceiveID != Users.CurrentUserID && workFlowTask.ReceiveID != RoadFlow.Platform.WeiXin.Organize.CurrentUserID && workFlowTask.IsExpiredAutoSubmit == 0)
			{
				result.DebugMessages = "不能处理当前任务";
				result.IsSuccess = false;
				result.Messages = "不能处理当前任务";
			}
			else
			{
				workFlowTask.InstanceID = executeModel.InstanceID;
				nextTasks.Add(workFlowTask);
				if (!flag && !executeModel.Title.IsNullOrEmpty())
				{
					workFlowTask.Title = executeModel.Title;
					Update(workFlowTask);
				}
				result.DebugMessages = "保存成功";
				result.IsSuccess = true;
				result.Messages = "保存成功";
			}
		}

		private void executeCopyforComplete(Execute executeModel)
		{
			if (executeModel.TaskID == Guid.Empty || executeModel.FlowID == Guid.Empty)
			{
				result.DebugMessages = "完成流程参数错误";
				result.IsSuccess = false;
				result.Messages = "完成流程参数错误";
			}
			else
			{
				RoadFlow.Data.Model.WorkFlowTask workFlowTask = Get(executeModel.TaskID);
				if (workFlowTask == null)
				{
					result.DebugMessages = "未找到当前任务";
					result.IsSuccess = false;
					result.Messages = "未找到当前任务";
				}
				else if (workFlowTask.Status.In(2, 3, 4, 5, 6, 7))
				{
					result.DebugMessages = "当前任务已处理";
					result.IsSuccess = false;
					result.Messages = "当前任务已处理";
				}
				else
				{
					Completed(workFlowTask.ID, executeModel.Comment, executeModel.IsSign, 2, workFlowTask.Note, executeModel.Files);
					result.DebugMessages += "已完成";
					result.IsSuccess = true;
					result.Messages += "已完成";
				}
			}
		}

		private void executeComplete(Execute executeModel, bool isCompleteTask = true)
		{
			if (executeModel.TaskID == Guid.Empty || executeModel.FlowID == Guid.Empty)
			{
				result.DebugMessages = "完成流程参数错误";
				result.IsSuccess = false;
				result.Messages = "完成流程参数错误";
			}
			else
			{
				RoadFlow.Data.Model.WorkFlowTask workFlowTask = Get(executeModel.TaskID);
				if (workFlowTask == null)
				{
					result.DebugMessages = "未找到当前任务";
					result.IsSuccess = false;
					result.Messages = "未找到当前任务";
				}
				else if (isCompleteTask && workFlowTask.Status.In(2, 3, 4, 5, 6, 7))
				{
					result.DebugMessages = "当前任务已处理";
					result.IsSuccess = false;
					result.Messages = "当前任务已处理";
				}
				else
				{
					if (wfInstalled.TitleField != null && wfInstalled.TitleField.LinkID != Guid.Empty && !wfInstalled.TitleField.Table.IsNullOrEmpty() && !wfInstalled.TitleField.Field.IsNullOrEmpty() && wfInstalled.DataBases.Count() > 0)
					{
						DataBases dataBases = wfInstalled.DataBases.First();
						try
						{
							string sql = string.Format("UPDATE {0} SET {1}='{2}' WHERE {3}", wfInstalled.TitleField.Table, wfInstalled.TitleField.Field, "1", string.Format("{0}='{1}'", dataBases.PrimaryKey, workFlowTask.InstanceID));
							Factory.GetDBHelper().Execute(sql);
						}
						catch (Exception ex)
						{
							Log.Add("更新流程完成标题发生了错误-" + workFlowTask.Title, ex.Message + ex.StackTrace, Log.Types.系统错误, executeModel.Serialize());
						}
					}
					if (isCompleteTask)
					{
						Completed(workFlowTask.ID, executeModel.Comment, executeModel.IsSign, 2, "", executeModel.Files);
					}
					List<RoadFlow.Data.Model.WorkFlowTask> bySubFlowGroupID = GetBySubFlowGroupID(workFlowTask.GroupID);
					if (bySubFlowGroupID.Count > 0)
					{
						RoadFlow.Data.Model.WorkFlowTask parentTask = bySubFlowGroupID.First();
						WorkFlowInstalled workFlowRunModel = bWorkFlow.GetWorkFlowRunModel(parentTask.FlowID);
						if (workFlowRunModel != null)
						{
							IEnumerable<Step> source = from p in workFlowRunModel.Steps
							where p.ID == parentTask.StepID
							select p;
							if (source.Count() > 0 && !source.First().Event.SubFlowCompletedBefore.IsNullOrEmpty())
							{
								ExecuteFlowCustomEvent(source.First().Event.SubFlowCompletedBefore.Trim(), new WorkFlowCustomEventParams
								{
									FlowID = parentTask.FlowID,
									GroupID = parentTask.GroupID,
									InstanceID = parentTask.InstanceID,
									StepID = parentTask.StepID,
									TaskID = parentTask.ID
								});
							}
						}
					}
					result.DebugMessages += "已完成";
					result.IsSuccess = true;
					result.Messages += "已完成";
				}
			}
		}

		private void executeRedirect(Execute executeModel)
		{
			RoadFlow.Data.Model.WorkFlowTask workFlowTask = Get(executeModel.TaskID);
			if (workFlowTask == null)
			{
				result.DebugMessages = "未能创建或找到当前任务";
				result.IsSuccess = false;
				result.Messages = "未能创建或找到当前任务";
			}
			else if (workFlowTask.Status.In(2, 3, 4, 5, 6, 7))
			{
				result.DebugMessages = "当前任务已处理";
				result.IsSuccess = false;
				result.Messages = "当前任务已处理";
			}
			else if (workFlowTask.ReceiveID != Users.CurrentUserID && workFlowTask.ReceiveID != RoadFlow.Platform.WeiXin.Organize.CurrentUserID && workFlowTask.IsExpiredAutoSubmit == 0)
			{
				result.DebugMessages = "不能处理当前任务";
				result.IsSuccess = false;
				result.Messages = "不能处理当前任务";
			}
			else if (workFlowTask.Status == -1)
			{
				result.DebugMessages = "当前任务正在等待他人处理";
				result.IsSuccess = false;
				result.Messages = "当前任务正在等待他人处理";
			}
			else if (executeModel.Steps.First().Value.Count == 0)
			{
				result.DebugMessages = "未设置转交人员";
				result.IsSuccess = false;
				result.Messages = "未设置转交人员";
			}
			else
			{
				string receiveName = workFlowTask.ReceiveName;
				using (TransactionScope transactionScope = new TransactionScope())
				{
					foreach (RoadFlow.Data.Model.Users item in executeModel.Steps.First().Value)
					{
						workFlowTask.ID = Guid.NewGuid();
						workFlowTask.ReceiveID = item.ID;
						workFlowTask.ReceiveName = item.Name;
						workFlowTask.OpenTime = null;
						workFlowTask.Status = 0;
						workFlowTask.IsSign = 0;
						workFlowTask.Type = 3;
						workFlowTask.Note = string.Format("该任务由{0}转交", receiveName);
						if (!HasNoCompletedTasks(workFlowTask.FlowID, workFlowTask.StepID, workFlowTask.GroupID, item.ID))
						{
							Add(workFlowTask);
						}
						nextTasks.Add(workFlowTask);
					}
					Completed(executeModel.TaskID, executeModel.Comment, executeModel.IsSign, 2, "已转交他人处理");
					transactionScope.Complete();
				}
				List<string> list = new List<string>();
				foreach (RoadFlow.Data.Model.Users item2 in executeModel.Steps.First().Value)
				{
					list.Add(item2.Name);
				}
				string str = list.Distinct().ToArray().Join1();
				result.DebugMessages = "已转交给:" + str;
				result.IsSuccess = true;
				result.Messages = "已转交给:" + str;
			}
		}

		private void executeAddWrite(Execute executeModel)
		{
			if (executeModel.TaskID.IsEmptyGuid())
			{
				result.DebugMessages = "未找到当前任务";
				result.IsSuccess = false;
				result.Messages = "未找到当前任务";
			}
			else
			{
				RoadFlow.Data.Model.WorkFlowTask task = Get(executeModel.TaskID);
				if (task == null)
				{
					result.DebugMessages = "未找到当前任务";
					result.IsSuccess = false;
					result.Messages = "未找到当前任务";
				}
				else if (task.ReceiveID != Users.CurrentUserID && task.ReceiveID != RoadFlow.Platform.WeiXin.Organize.CurrentUserID && task.IsExpiredAutoSubmit == 0)
				{
					result.DebugMessages = "不能处理当前任务";
					result.IsSuccess = false;
					result.Messages = "不能处理当前任务";
				}
				else if (task.OtherType.ToString().Length != 2)
				{
					result.DebugMessages = "未找到加签类型和审批类型!";
					result.IsSuccess = false;
					result.Messages = "加签参数错误";
				}
				else
				{
					int num = task.OtherType.ToString().Left(1).ToInt();
					int num2 = task.OtherType.ToString().Right(1).ToInt();
					List<RoadFlow.Data.Model.WorkFlowTask> list = GetTaskList(task.FlowID, task.StepID, task.GroupID).FindAll(delegate(RoadFlow.Data.Model.WorkFlowTask p)
					{
						if (p.PrevID == task.PrevID)
						{
							return p.Type == 7;
						}
						return false;
					});
					List<RoadFlow.Data.Model.WorkFlowTask> list2 = new List<RoadFlow.Data.Model.WorkFlowTask>();
					switch (num2)
					{
					case 1:
						Completed(task.ID, executeModel.Comment, executeModel.IsSign, 2, "", executeModel.Files);
						break;
					case 2:
						foreach (RoadFlow.Data.Model.WorkFlowTask item in list.FindAll((RoadFlow.Data.Model.WorkFlowTask p) => p.Status.In(-1, 0, 1)))
						{
							if (item.ID == task.ID)
							{
								Completed(task.ID, executeModel.Comment, executeModel.IsSign, 2, "", executeModel.Files);
							}
							else
							{
								Completed(item.ID, "", false, 4);
							}
						}
						break;
					case 3:
					{
						Completed(task.ID, executeModel.Comment, executeModel.IsSign, 2, "", executeModel.Files);
						IOrderedEnumerable<RoadFlow.Data.Model.WorkFlowTask> source = from p in list.FindAll(delegate(RoadFlow.Data.Model.WorkFlowTask p)
						{
							if (p.Status.In(-1, 0, 1))
							{
								return p.ID != task.ID;
							}
							return false;
						})
						orderby p.ReceiveTime
						select p;
						if (source.Count() > 0)
						{
							RoadFlow.Data.Model.WorkFlowTask workFlowTask = source.FirstOrDefault();
							workFlowTask.Status = 0;
							Update(workFlowTask);
							list2.Add(workFlowTask);
						}
						break;
					}
					}
					List<RoadFlow.Data.Model.WorkFlowTask> list3 = new List<RoadFlow.Data.Model.WorkFlowTask>();
					if (isPassingAddWrite(task, out list3) && list3.Count > 0)
					{
						if (num != 1)
						{
							if ((uint)(num - 2) <= 1u)
							{
								foreach (RoadFlow.Data.Model.WorkFlowTask item2 in GetNextTaskList(list3.FirstOrDefault().ID).FindAll((RoadFlow.Data.Model.WorkFlowTask p) => p.Status == -1))
								{
									item2.Status = 0;
									Update(item2);
									list2.Add(item2);
								}
							}
						}
						else
						{
							foreach (RoadFlow.Data.Model.WorkFlowTask item3 in list3)
							{
								item3.Status = 1;
								Update(item3);
								list2.Add(item3);
							}
						}
					}
					StringBuilder stringBuilder = new StringBuilder();
					foreach (RoadFlow.Data.Model.WorkFlowTask item4 in list2)
					{
						stringBuilder.Append(item4.ReceiveName);
						stringBuilder.Append(",");
					}
					result.DebugMessages = "已发送" + ((stringBuilder.Length > 0) ? ("到" + stringBuilder.ToString().TrimEnd(',')) : "");
					result.IsSuccess = true;
					result.NextTasks = list2;
					result.Messages = result.DebugMessages;
				}
			}
		}

		private bool isPassingAddWrite(RoadFlow.Data.Model.WorkFlowTask addWriteTask, out List<RoadFlow.Data.Model.WorkFlowTask> nextTasks)
		{
			nextTasks = new List<RoadFlow.Data.Model.WorkFlowTask>();
			if (addWriteTask == null)
			{
				return true;
			}
			List<RoadFlow.Data.Model.WorkFlowTask> taskList = GetTaskList(addWriteTask.FlowID, addWriteTask.StepID, addWriteTask.GroupID);
			if (taskList.Count == 0)
			{
				return true;
			}
			RoadFlow.Data.Model.WorkFlowTask task = taskList.Find((RoadFlow.Data.Model.WorkFlowTask p) => p.ID == addWriteTask.PrevID);
			if (task == null)
			{
				return true;
			}
			List<RoadFlow.Data.Model.WorkFlowTask> list = nextTasks = taskList.FindAll(delegate(RoadFlow.Data.Model.WorkFlowTask p)
			{
				if (p.Sort == task.Sort)
				{
					return p.Type != 7;
				}
				return false;
			});
			List<RoadFlow.Data.Model.WorkFlowTask> list2 = new List<RoadFlow.Data.Model.WorkFlowTask>();
			foreach (RoadFlow.Data.Model.WorkFlowTask item in list)
			{
				list2.AddRange(taskList.FindAll(delegate(RoadFlow.Data.Model.WorkFlowTask p)
				{
					if (p.PrevID == item.ID)
					{
						return p.Type == 7;
					}
					return false;
				}));
			}
			foreach (IGrouping<Guid, RoadFlow.Data.Model.WorkFlowTask> item2 in from p in list2
			group p by p.PrevID)
			{
				switch (item2.FirstOrDefault().OtherType.ToString().Right(1).ToInt())
				{
				case 1:
				case 3:
					if (item2.Where((RoadFlow.Data.Model.WorkFlowTask p) => p.Status.In(0, 1, -1)).Count() > 0)
					{
						return false;
					}
					break;
				case 2:
					if (item2.Where((RoadFlow.Data.Model.WorkFlowTask p) => p.Status.In(2)).Count() == 0)
					{
						return false;
					}
					break;
				}
			}
			return true;
		}

		private List<RoadFlow.Data.Model.WorkFlowTask> createTempTasks(Execute executeModel, RoadFlow.Data.Model.WorkFlowTask currentTask)
		{
			List<RoadFlow.Data.Model.WorkFlowTask> list = new List<RoadFlow.Data.Model.WorkFlowTask>();
			foreach (KeyValuePair<Guid, List<RoadFlow.Data.Model.Users>> step3 in executeModel.Steps)
			{
				int num = 0;
				foreach (RoadFlow.Data.Model.Users item in step3.Value)
				{
					IEnumerable<Step> source = from p in wfInstalled.Steps
					where p.ID == step3.Key
					select p;
					if (source.Count() != 0)
					{
						Step step2 = source.First();
						RoadFlow.Data.Model.WorkFlowTask workFlowTask = new RoadFlow.Data.Model.WorkFlowTask();
						if (executeModel.StepCompletedTimes.Keys.Contains(step2.ID))
						{
							workFlowTask.CompletedTime = executeModel.StepCompletedTimes[step2.ID];
						}
						else if (step2.WorkTime > decimal.Zero)
						{
							workFlowTask.CompletedTime = new WorkCalendar().GetWorkDate((double)step2.WorkTime, DateTimeNew.Now);
						}
						workFlowTask.FlowID = executeModel.FlowID;
						workFlowTask.GroupID = ((currentTask != null) ? currentTask.GroupID : executeModel.GroupID);
						workFlowTask.ID = Guid.NewGuid();
						workFlowTask.Type = 0;
						workFlowTask.InstanceID = executeModel.InstanceID;
						if (!executeModel.Note.IsNullOrEmpty())
						{
							workFlowTask.Note = executeModel.Note;
						}
						workFlowTask.PrevID = currentTask.ID;
						workFlowTask.PrevStepID = currentTask.StepID;
						workFlowTask.ReceiveID = item.ID;
						workFlowTask.ReceiveName = item.Name;
						workFlowTask.ReceiveTime = DateTimeNew.Now;
						workFlowTask.SenderID = executeModel.Sender.ID;
						workFlowTask.SenderName = executeModel.Sender.Name;
						workFlowTask.SenderTime = workFlowTask.ReceiveTime;
						workFlowTask.Status = -1;
						workFlowTask.StepID = step3.Key;
						workFlowTask.StepName = step2.Name;
						workFlowTask.Sort = currentTask.Sort + 1;
						workFlowTask.Title = (executeModel.Title.IsNullOrEmpty() ? currentTask.Title : executeModel.Title);
						workFlowTask.OtherType = executeModel.OtherType;
						workFlowTask.StepSort = num++;
						if (!HasNoCompletedTasks(executeModel.FlowID, step3.Key, currentTask.GroupID, item.ID))
						{
							Add(workFlowTask);
						}
						list.Add(workFlowTask);
					}
				}
			}
			return list;
		}

		private bool IsPassing(Step step, Guid flowID, Guid groupID, RoadFlow.Data.Model.WorkFlowTask currentTask, Guid currentPrevStep)
		{
			List<RoadFlow.Data.Model.WorkFlowTask> list = GetTaskList(flowID, step.ID, groupID).FindAll((RoadFlow.Data.Model.WorkFlowTask p) => p.Type != 7);
			int maxSort = (list.Count > 0) ? list.Max((RoadFlow.Data.Model.WorkFlowTask p) => p.Sort) : (-1);
			list = list.FindAll(delegate(RoadFlow.Data.Model.WorkFlowTask p)
			{
				if (p.Sort == maxSort)
				{
					return p.Type != 5;
				}
				return false;
			});
			if (list.Count == 0)
			{
				foreach (Step betweenStep in new WorkFlow().getBetweenSteps(new WorkFlow().GetWorkFlowRunModel(flowID), currentTask.PrevStepID, step.ID))
				{
					List<RoadFlow.Data.Model.WorkFlowTask> list2 = GetTaskList(flowID, betweenStep.ID, groupID).FindAll(delegate(RoadFlow.Data.Model.WorkFlowTask p)
					{
						if (p.Type != 7)
						{
							return p.Type != 5;
						}
						return false;
					});
					int maxsort = (list2.Count > 0) ? list2.Max((RoadFlow.Data.Model.WorkFlowTask p) => p.Sort) : (-1);
					if (list2.Find((RoadFlow.Data.Model.WorkFlowTask p) => p.Sort == maxsort) != null)
					{
						return false;
					}
				}
				return true;
			}
			bool flag = true;
			switch (step.Behavior.HanlderModel)
			{
			case 0:
			case 3:
				flag = ((from p in list
				where p.Status != 2
				select p).Count() == 0);
				break;
			case 1:
				flag = ((from p in list
				where p.Status == 2
				select p).Count() > 0);
				break;
			case 2:
				flag = (((decimal)((from p in list
				where p.Status == 2
				select p).Count() + 1) / (decimal)list.Count * 100m).Round() >= ((step.Behavior.Percentage <= decimal.Zero) ? 100m : step.Behavior.Percentage));
				break;
			}
			if (flag)
			{
				List<RoadFlow.Data.Model.WorkFlowTask> list3 = new List<RoadFlow.Data.Model.WorkFlowTask>();
				flag = isPassingAddWrite(list.FirstOrDefault(), out list3);
			}
			return flag;
		}

		private bool IsBack(Step step, Guid flowID, Guid groupID, Guid taskID, int sort)
		{
			List<RoadFlow.Data.Model.WorkFlowTask> list = GetTaskList(flowID, step.ID, groupID).FindAll(delegate(RoadFlow.Data.Model.WorkFlowTask p)
			{
				if (p.Sort == sort)
				{
					return p.Type != 5;
				}
				return false;
			});
			if (list.Count == 0)
			{
				return false;
			}
			bool flag = true;
			switch (step.Behavior.HanlderModel)
			{
			case 0:
			case 3:
				flag = ((from p in list
				where p.Status.In(3, 5)
				select p).Count() > 0);
				break;
			case 1:
				flag = ((from p in list
				where p.Status.In(2, 4)
				select p).Count() == 0);
				break;
			case 2:
				flag = (((decimal)((from p in list
				where p.Status.In(3, 5)
				select p).Count() + 1) / (decimal)list.Count * 100m).Round() >= 100m - ((step.Behavior.Percentage <= decimal.Zero) ? 100m : step.Behavior.Percentage));
				break;
			}
			return flag;
		}

		private RoadFlow.Data.Model.WorkFlowTask createFirstTask(Execute executeModel, bool isSubFlow = false)
		{
			if ((wfInstalled == null) | isSubFlow)
			{
				wfInstalled = bWorkFlow.GetWorkFlowRunModel(executeModel.FlowID);
			}
			IEnumerable<Step> source = from p in wfInstalled.Steps
			where p.ID == wfInstalled.FirstStepID
			select p;
			if (source.Count() == 0)
			{
				return null;
			}
			RoadFlow.Data.Model.WorkFlowTask workFlowTask = new RoadFlow.Data.Model.WorkFlowTask();
			if (source.First().WorkTime > decimal.Zero)
			{
				workFlowTask.CompletedTime = new WorkCalendar().GetWorkDate((double)source.First().WorkTime, DateTimeNew.Now);
			}
			workFlowTask.FlowID = executeModel.FlowID;
			workFlowTask.GroupID = (executeModel.GroupID.IsEmptyGuid() ? Guid.NewGuid() : executeModel.GroupID);
			workFlowTask.ID = Guid.NewGuid();
			workFlowTask.Type = 0;
			workFlowTask.InstanceID = executeModel.InstanceID;
			if (!executeModel.Note.IsNullOrEmpty())
			{
				workFlowTask.Note = executeModel.Note;
			}
			workFlowTask.PrevID = Guid.Empty;
			workFlowTask.PrevStepID = Guid.Empty;
			workFlowTask.ReceiveID = executeModel.Sender.ID;
			workFlowTask.ReceiveName = executeModel.Sender.Name;
			workFlowTask.ReceiveTime = DateTimeNew.Now;
			workFlowTask.SenderID = executeModel.Sender.ID;
			workFlowTask.SenderName = executeModel.Sender.Name;
			workFlowTask.SenderTime = workFlowTask.ReceiveTime;
			workFlowTask.Status = 0;
			workFlowTask.StepID = wfInstalled.FirstStepID;
			workFlowTask.StepName = source.First().Name;
			workFlowTask.Sort = 1;
			workFlowTask.StepSort = 0;
			workFlowTask.OtherType = executeModel.OtherType;
			workFlowTask.Title = (executeModel.Title.IsNullOrEmpty() ? (wfInstalled.Name + "-" + workFlowTask.StepName + "-" + workFlowTask.SenderName) : executeModel.Title);
			Add(workFlowTask);
			if (isSubFlow)
			{
				wfInstalled = null;
			}
			return workFlowTask;
		}

		public List<RoadFlow.Data.Model.WorkFlowTask> GetTasks(Guid userID, out string pager, string query = "", string title = "", string flowid = "", string sender = "", string date1 = "", string date2 = "", int type = 0)
		{
			return dataWorkFlowTask.GetTasks(userID, out pager, query, title, flowid, Users.RemovePrefix(sender), date1, date2, type);
		}

		public List<RoadFlow.Data.Model.WorkFlowTask> GetTasks(Guid userID, out long count, int size, int number, string title = "", string flowid = "", string sender = "", string date1 = "", string date2 = "", int type = 0, string order = "")
		{
			return dataWorkFlowTask.GetTasks(userID, out count, size, number, title, flowid, Users.RemovePrefix(sender), date1, date2, type, order);
		}

		public List<RoadFlow.Data.Model.WorkFlowTask> GetInstances(Guid[] flowID, Guid[] senderID, Guid[] receiveID, out string pager, string query = "", string title = "", string flowid = "", string date1 = "", string date2 = "", int status = 0)
		{
			return dataWorkFlowTask.GetInstances(flowID, senderID, receiveID, out pager, query, title, flowid, date1, date2, status);
		}

		public DataTable GetInstances1(Guid[] flowID, Guid[] senderID, Guid[] receiveID, out string pager, string query = "", string title = "", string flowid = "", string date1 = "", string date2 = "", int status = 0)
		{
			return dataWorkFlowTask.GetInstances1(flowID, senderID, receiveID, out pager, query, title, flowid, date1, date2, status);
		}

		public DataTable GetInstances1(Guid[] flowID, Guid[] senderID, Guid[] receiveID, out long count, int size, int number, string title = "", string flowid = "", string date1 = "", string date2 = "", int status = 0, string order = "")
		{
			return dataWorkFlowTask.GetInstances1(flowID, senderID, receiveID, out count, size, number, title, flowid, date1, date2, status, order);
		}

		public object ExecuteFlowCustomEvent(string eventName, object eventParams, string dllName = "")
		{
			if (dllName.IsNullOrEmpty())
			{
				dllName = eventName.Substring(0, eventName.IndexOf('.'));
			}
			Assembly assembly = Assembly.Load(dllName);
			string fileNameWithoutExtension = Path.GetFileNameWithoutExtension(eventName);
			string text = eventName.Substring(fileNameWithoutExtension.Length + 1);
			Type type = assembly.GetType(fileNameWithoutExtension, true);
			object obj = Activator.CreateInstance(type, false);
			MethodInfo method = type.GetMethod(text);
			if (method != null)
			{
				return method.Invoke(obj, new object[1]
				{
					eventParams
				});
			}
			throw new MissingMethodException(fileNameWithoutExtension, text);
		}

		public int DeleteInstance(Guid flowID, Guid groupID, bool hasInstanceData = false)
		{
			if (hasInstanceData)
			{
				List<RoadFlow.Data.Model.WorkFlowTask> taskList = GetTaskList(flowID, groupID);
				if (taskList.Count > 0 && !taskList.First().InstanceID.IsNullOrEmpty())
				{
					WorkFlowInstalled workFlowRunModel = bWorkFlow.GetWorkFlowRunModel(flowID);
					if (workFlowRunModel != null && workFlowRunModel.DataBases.Count() > 0)
					{
						DataBases dataBases = workFlowRunModel.DataBases.First();
						new DBConnection().DeleteData(dataBases.LinkID, dataBases.Table, dataBases.PrimaryKey, taskList.First().InstanceID);
					}
				}
			}
			return dataWorkFlowTask.Delete(flowID, groupID);
		}

		public int Completed(Guid taskID, string comment = "", bool isSign = false, int status = 2, string note = "", string files = "")
		{
			return dataWorkFlowTask.Completed(taskID, comment, isSign, status, note, files);
		}

		public List<RoadFlow.Data.Model.WorkFlowTask> GetTaskList(Guid flowID, Guid stepID, Guid groupID)
		{
			return dataWorkFlowTask.GetTaskList(flowID, stepID, groupID);
		}

		public List<RoadFlow.Data.Model.WorkFlowTask> GetTaskList(Guid flowID, Guid groupID)
		{
			return dataWorkFlowTask.GetTaskList(flowID, groupID);
		}

		public List<RoadFlow.Data.Model.WorkFlowTask> GetTaskList(Guid taskID, bool isStepID = true)
		{
			return dataWorkFlowTask.GetTaskList(taskID, isStepID);
		}

		public List<RoadFlow.Data.Model.WorkFlowTask> GetTaskListByStepID(Guid taskID, Guid stepID)
		{
			return dataWorkFlowTask.GetTaskList(taskID).FindAll((RoadFlow.Data.Model.WorkFlowTask p) => p.StepID == stepID);
		}

		public List<RoadFlow.Data.Model.WorkFlowTask> GetPrevTaskList(Guid taskID)
		{
			return dataWorkFlowTask.GetPrevTaskList(taskID);
		}

		public List<RoadFlow.Data.Model.WorkFlowTask> GetNextTaskList(Guid taskID)
		{
			return dataWorkFlowTask.GetNextTaskList(taskID);
		}

		public Dictionary<Guid, string> GetBackSteps(Guid taskID, int backType, Guid stepID, WorkFlowInstalled wfInstalled)
		{
			Dictionary<Guid, string> dictionary = new Dictionary<Guid, string>();
			IEnumerable<Step> source = from p in wfInstalled.Steps
			where p.ID == stepID
			select p;
			if (source.Count() == 0)
			{
				return dictionary;
			}
			Step step = source.First();
			RoadFlow.Data.Model.WorkFlowTask task = Get(taskID);
			if (step.Behavior.HanlderModel == 4 && task.StepSort > 0)
			{
				RoadFlow.Data.Model.WorkFlowTask workFlowTask = GetTaskList(taskID).Find((RoadFlow.Data.Model.WorkFlowTask p) => p.StepSort == task.StepSort - 1);
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
				IEnumerable<Step> source2 = from p in wfInstalled.Steps
				where p.ID == task.PrevStepID
				select p;
				dictionary.Add(Guid.Empty, (source2.Count() > 0) ? (source2.First().Name + "(" + task.SenderName + ")") : task.SenderName);
				return dictionary;
			}
			switch (backType)
			{
			case 0:
				if (task != null)
				{
					if (step.Behavior.Countersignature != 0)
					{
						foreach (Step prevStep in bWorkFlow.GetPrevSteps(task.FlowID, step.ID))
						{
							dictionary.Add(prevStep.ID, prevStep.Name);
						}
						return dictionary;
					}
					dictionary.Add(task.PrevStepID, bWorkFlow.GetStepName(task.PrevStepID, wfInstalled));
				}
				break;
			case 1:
				dictionary.Add(wfInstalled.FirstStepID, bWorkFlow.GetStepName(wfInstalled.FirstStepID, wfInstalled));
				break;
			case 2:
				if (step.Behavior.BackType == 2 && step.Behavior.BackStepID != Guid.Empty)
				{
					dictionary.Add(step.Behavior.BackStepID, bWorkFlow.GetStepName(step.Behavior.BackStepID, wfInstalled));
				}
				else if (task != null)
				{
					foreach (RoadFlow.Data.Model.WorkFlowTask item in from p in GetTaskList(task.FlowID, task.GroupID)
					where p.Status.In(2, 3, 4)
					orderby p.Sort
					orderby p.CompletedTime1 descending
					select p)
					{
						if (!dictionary.Keys.Contains(item.StepID) && item.StepID != stepID)
						{
							dictionary.Add(item.StepID, bWorkFlow.GetStepName(item.StepID, wfInstalled));
						}
					}
					return dictionary;
				}
				break;
			}
			return dictionary;
		}

		public int UpdateNextTaskStatus(Guid taskID, int status)
		{
			int num = 0;
			foreach (RoadFlow.Data.Model.WorkFlowTask task in GetTaskList(taskID))
			{
				num += dataWorkFlowTask.UpdateNextTaskStatus(task.ID, status);
			}
			return num;
		}

		public bool HasTasks(Guid flowID)
		{
			return dataWorkFlowTask.HasTasks(flowID);
		}

		public bool HasNoCompletedTasks(Guid flowID, Guid stepID, Guid groupID, Guid userID)
		{
			return dataWorkFlowTask.HasNoCompletedTasks(flowID, stepID, groupID, userID);
		}

		public string GetStatusTitle(int status)
		{
			string empty = string.Empty;
			switch (status)
			{
			case -1:
				return "等待中";
			case 0:
				return "待处理";
			case 1:
				return "处理中";
			case 2:
				return "已完成";
			case 3:
				return "已退回";
			case 4:
				return "他人已处理";
			case 5:
				return "他人已退回";
			case 6:
				return "终止";
			case 7:
				return "他人已终止";
			default:
				return "其它";
			}
		}

		public List<RoadFlow.Data.Model.WorkFlowTask> GetUserTaskList(Guid flowID, Guid stepID, Guid groupID, Guid userID)
		{
			return dataWorkFlowTask.GetUserTaskList(flowID, stepID, groupID, userID);
		}

		public bool HasWithdraw(Guid taskID)
		{
			RoadFlow.Data.Model.WorkFlowTask currentTask = Get(taskID);
			RoadFlow.Data.Model.WorkFlowTask workFlowTask = GetTaskList(taskID).Find((RoadFlow.Data.Model.WorkFlowTask p) => p.StepSort == currentTask.StepSort + 1);
			if (workFlowTask != null)
			{
				return workFlowTask.Status == 0;
			}
			List<RoadFlow.Data.Model.WorkFlowTask> nextTaskList = GetNextTaskList(taskID);
			if (nextTaskList.Count == 0)
			{
				return false;
			}
			foreach (RoadFlow.Data.Model.WorkFlowTask item in nextTaskList)
			{
				if (item.Status != 0 && item.Status != -1)
				{
					return false;
				}
			}
			return true;
		}

		public bool HasWithdraw(Guid taskID, out bool isHasten)
		{
			isHasten = false;
			RoadFlow.Data.Model.WorkFlowTask currentTask = Get(taskID);
			RoadFlow.Data.Model.WorkFlowTask workFlowTask = GetTaskList(taskID).Find((RoadFlow.Data.Model.WorkFlowTask p) => p.StepSort == currentTask.StepSort + 1);
			if (workFlowTask != null)
			{
				if (workFlowTask.Status.In(0, 1))
				{
					isHasten = true;
				}
				return workFlowTask.Status == 0;
			}
			List<RoadFlow.Data.Model.WorkFlowTask> nextTaskList = GetNextTaskList(taskID);
			if (nextTaskList.Count == 0)
			{
				return false;
			}
			foreach (RoadFlow.Data.Model.WorkFlowTask item in nextTaskList)
			{
				if (item.Status.In(0, 1))
				{
					isHasten = true;
					break;
				}
			}
			foreach (RoadFlow.Data.Model.WorkFlowTask item2 in nextTaskList)
			{
				if (item2.Status != 0 && item2.Status != -1)
				{
					return false;
				}
			}
			return true;
		}

		public bool WithdrawTask(Guid taskID)
		{
			RoadFlow.Data.Model.WorkFlowTask currentTask = Get(taskID);
			if (currentTask == null)
			{
				return false;
			}
			List<RoadFlow.Data.Model.WorkFlowTask> taskList = GetTaskList(taskID);
			RoadFlow.Data.Model.WorkFlowTask workFlowTask = taskList.Find((RoadFlow.Data.Model.WorkFlowTask p) => p.StepSort == currentTask.StepSort + 1);
			if (workFlowTask != null)
			{
				using (TransactionScope transactionScope = new TransactionScope())
				{
					Completed(workFlowTask.ID, "", false, -1);
					Completed(taskID, "", false, 1);
					transactionScope.Complete();
					return true;
				}
			}
			ShortMessage shortMessage = new ShortMessage();
			using (TransactionScope transactionScope2 = new TransactionScope())
			{
				foreach (RoadFlow.Data.Model.WorkFlowTask item in taskList)
				{
					foreach (RoadFlow.Data.Model.WorkFlowTask nextTask in GetNextTaskList(item.ID))
					{
						if (nextTask.Status.In(-1, 0, 1, 5))
						{
							Delete(nextTask.ID);
							shortMessage.Delete(nextTask.ID.ToString(), 1);
						}
						if (!nextTask.SubFlowGroupID.IsNullOrEmpty())
						{
							string[] array = nextTask.SubFlowGroupID.Split(',');
							foreach (string str in array)
							{
								DeleteInstance(Guid.Empty, str.ToGuid());
							}
						}
					}
					if (item.ID == taskID || item.Status == 4)
					{
						Completed(item.ID, "", false, 1);
					}
				}
				transactionScope2.Complete();
				return true;
			}
		}

		public string DesignateTask(Guid taskID, RoadFlow.Data.Model.Users user)
		{
			RoadFlow.Data.Model.WorkFlowTask workFlowTask = Get(taskID);
			if (workFlowTask == null)
			{
				return "未找到任务";
			}
			if (workFlowTask.Status.In(2, 3, 4, 5, 6, 7))
			{
				return "该任务已处理";
			}
			string receiveName = workFlowTask.ReceiveName;
			workFlowTask.ReceiveID = user.ID;
			workFlowTask.ReceiveName = user.Name;
			workFlowTask.OpenTime = null;
			workFlowTask.Status = 0;
			workFlowTask.Note = string.Format("该任务由{0}指派", receiveName);
			Update(workFlowTask);
			return "指派成功";
		}

		public string BackTask(Guid taskID)
		{
			RoadFlow.Data.Model.WorkFlowTask task = Get(taskID);
			if (task == null)
			{
				return "未找到任务";
			}
			if (task.Status.In(2, 3, 4, 5, 6, 7))
			{
				return "该任务已处理";
			}
			if (wfInstalled == null)
			{
				wfInstalled = bWorkFlow.GetWorkFlowRunModel(task.FlowID);
			}
			Execute execute = new Execute();
			execute.ExecuteType = EnumType.ExecuteType.Back;
			execute.FlowID = task.FlowID;
			execute.GroupID = task.GroupID;
			execute.InstanceID = task.InstanceID;
			execute.Note = "管理员退回";
			execute.Sender = new Users().Get(task.ReceiveID);
			execute.StepID = task.StepID;
			execute.TaskID = task.ID;
			execute.Title = task.Title;
			IEnumerable<Step> source = from p in wfInstalled.Steps
			where p.ID == task.StepID
			select p;
			if (source.Count() == 0)
			{
				return "未找到步骤";
			}
			if (source.First().Behavior.BackType == 2 && source.First().Behavior.BackStepID == Guid.Empty)
			{
				return "未设置退回步骤";
			}
			Dictionary<Guid, List<RoadFlow.Data.Model.Users>> dictionary = new Dictionary<Guid, List<RoadFlow.Data.Model.Users>>();
			foreach (KeyValuePair<Guid, string> backStep in GetBackSteps(taskID, source.First().Behavior.BackType, task.StepID, wfInstalled))
			{
				dictionary.Add(backStep.Key, new List<RoadFlow.Data.Model.Users>());
			}
			execute.Steps = dictionary;
			return Execute(execute).Messages;
		}

		public List<RoadFlow.Data.Model.WorkFlowTask> Sort(List<RoadFlow.Data.Model.WorkFlowTask> tasks)
		{
			return (from p in tasks
			orderby p.Sort
			select p).ToList();
		}

		public int GetTaskStatus(Guid taskID)
		{
			return dataWorkFlowTask.GetTaskStatus(taskID);
		}

		public bool IsExecute(Guid taskID)
		{
			return GetTaskStatus(taskID) <= 1;
		}

		public bool TestLineSql(Guid linkID, string table, string tablepk, string instabceID, string where)
		{
			if (instabceID.IsNullOrEmpty())
			{
				return false;
			}
			DBConnection dBConnection = new DBConnection();
			RoadFlow.Data.Model.DBConnection dBConnection2 = dBConnection.Get(linkID);
			if (dBConnection2 == null)
			{
				return false;
			}
			string sql = "SELECT * FROM " + table + " WHERE " + tablepk + "='" + instabceID + "' AND (" + where.FilterWildcard() + ")".ReplaceSelectSql();
			if (!dBConnection.TestSql(dBConnection2, sql))
			{
				return false;
			}
			return dBConnection.GetDataTable(dBConnection2, sql).Rows.Count > 0;
		}

		public bool GetInstanceIsCompleted(Guid flowID, Guid groupID)
		{
			return GetTaskList(Guid.Empty, groupID).Find(delegate(RoadFlow.Data.Model.WorkFlowTask p)
			{
				if (p.Type != 5)
				{
					return p.Status.In(0, 1);
				}
				return false;
			}) == null;
		}

		public List<RoadFlow.Data.Model.WorkFlowTask> GetBySubFlowGroupID(Guid subflowGroupID)
		{
			return dataWorkFlowTask.GetBySubFlowGroupID(subflowGroupID);
		}

		public string GetStatusListItems(string value)
		{
			StringBuilder stringBuilder = new StringBuilder();
			foreach (KeyValuePair<int, string> item in new Dictionary<int, string>
			{
				{
					0,
					"待处理"
				},
				{
					1,
					"处理中"
				},
				{
					2,
					"已完成"
				},
				{
					3,
					"已退回"
				},
				{
					4,
					"他人已处理"
				},
				{
					5,
					"他人已退回"
				}
			})
			{
				stringBuilder.AppendFormat("<option value='{0}'{1}>{2}</option>", item.Key, (item.Key.ToString() == value) ? "selected='selected'" : "", item.Value);
			}
			return stringBuilder.ToString();
		}

		public string GetHastenUsersCheckboxString(Guid taskID, string name, string value = "")
		{
			List<RoadFlow.Data.Model.WorkFlowTask> nextTaskList = GetNextTaskList(taskID);
			List<ListItem> list = new List<ListItem>();
			foreach (RoadFlow.Data.Model.WorkFlowTask item in nextTaskList)
			{
				if (item.Status.In(0, 1))
				{
					list.Add(new ListItem(item.ReceiveName, item.ReceiveID.ToString())
					{
						Selected = true
					});
				}
			}
			return Tools.GetCheckBoxString(list.ToArray(), name, (value ?? "").Split(','), "validate='checkbox'");
		}

		public string EndTask(Guid taskID)
		{
			RoadFlow.Data.Model.WorkFlowTask workFlowTask = Get(taskID);
			if (workFlowTask == null)
			{
				return "未找到当前任务";
			}
			List<RoadFlow.Data.Model.WorkFlowTask> taskList = GetTaskList(workFlowTask.FlowID, workFlowTask.GroupID);
			using (TransactionScope transactionScope = new TransactionScope())
			{
				try
				{
					foreach (RoadFlow.Data.Model.WorkFlowTask item in taskList)
					{
						if (item.Status < 2)
						{
							item.Status = ((item.ID == workFlowTask.ID) ? 6 : 7);
							Update(item);
						}
					}
					if (wfInstalled == null)
					{
						wfInstalled = new WorkFlow().GetWorkFlowRunModel(workFlowTask.FlowID);
					}
					if (wfInstalled.TitleField != null && wfInstalled.TitleField.LinkID != Guid.Empty && !wfInstalled.TitleField.Table.IsNullOrEmpty() && !wfInstalled.TitleField.Field.IsNullOrEmpty() && wfInstalled.DataBases.Count() > 0)
					{
						DataBases dataBases = wfInstalled.DataBases.First();
						string sql = string.Format("UPDATE {0} SET {1}='{2}' WHERE {3}", wfInstalled.TitleField.Table, wfInstalled.TitleField.Field, "2", string.Format("{0}='{1}'", dataBases.PrimaryKey, workFlowTask.InstanceID));
						Factory.GetDBHelper().Execute(sql);
					}
					transactionScope.Complete();
				}
				catch (Exception err)
				{
					Log.Add(err);
				}
			}
			return "1";
		}

		public bool GoToTask(RoadFlow.Data.Model.WorkFlowTask task, Dictionary<Guid, string> gotoSteps)
		{
			WorkFlowInstalled workFlowRunModel = bWorkFlow.GetWorkFlowRunModel(task.FlowID);
			if (workFlowRunModel == null)
			{
				return false;
			}
			using (TransactionScope transactionScope = new TransactionScope())
			{
				try
				{
					foreach (KeyValuePair<Guid, string> gotoStep in gotoSteps)
					{
						IEnumerable<Step> source = from p in workFlowRunModel.Steps
						where p.ID == gotoStep.Key
						select p;
						if (source.Count() != 0)
						{
							Step step = source.First();
							foreach (RoadFlow.Data.Model.Users allUser in new Organize().GetAllUsers(gotoStep.Value))
							{
								RoadFlow.Data.Model.WorkFlowTask workFlowTask = new RoadFlow.Data.Model.WorkFlowTask();
								workFlowTask.Comment = "";
								workFlowTask.FlowID = task.FlowID;
								workFlowTask.GroupID = task.GroupID;
								workFlowTask.ID = Guid.NewGuid();
								workFlowTask.InstanceID = task.InstanceID;
								workFlowTask.OtherType = task.OtherType;
								workFlowTask.PrevID = task.ID;
								workFlowTask.PrevStepID = task.StepID;
								workFlowTask.ReceiveID = allUser.ID;
								workFlowTask.ReceiveName = allUser.Name;
								workFlowTask.ReceiveTime = DateTimeNew.Now;
								workFlowTask.SenderID = task.ReceiveID;
								workFlowTask.SenderName = task.ReceiveName;
								workFlowTask.SenderTime = workFlowTask.ReceiveTime;
								workFlowTask.Sort = task.Sort + 1;
								workFlowTask.Status = 0;
								workFlowTask.StepID = gotoStep.Key;
								workFlowTask.StepName = step.Name;
								workFlowTask.SubFlowGroupID = task.SubFlowGroupID;
								workFlowTask.Title = task.Title;
								workFlowTask.Type = task.Type;
								Add(workFlowTask);
							}
						}
					}
					task.Status = 2;
					Update(task);
					transactionScope.Complete();
					Log.Add("跳转了流程任务", gotoSteps.Serialize(), Log.Types.流程相关, task.Serialize());
					return true;
				}
				catch (Exception err)
				{
					Log.Add(err);
					return false;
				}
			}
		}

		public string GetDefultMember(Guid flowID, Guid stepID, Guid groupID, Guid currentStepID, string instanceid, out string selectType, out string selectRange)
		{
			string text = string.Empty;
			selectType = "";
			selectRange = "";
			WorkFlowInstalled workFlowRunModel = bWorkFlow.GetWorkFlowRunModel(flowID);
			if (workFlowRunModel == null)
			{
				return text;
			}
			IEnumerable<Step> source = from p in workFlowRunModel.Steps
			where p.ID == stepID
			select p;
			if (source.Count() == 0)
			{
				return text;
			}
			Step step = source.First();
			Users users = new Users();
			if ((workFlowRunModel.Debug != 1 && workFlowRunModel.Debug != 2) || !workFlowRunModel.DebugUsers.Exists((RoadFlow.Data.Model.Users p) => p.ID == Users.CurrentUserID))
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
				{
					Guid firstSnderID = GetFirstSnderID(workFlowRunModel.ID, groupID);
					if (firstSnderID != Guid.Empty)
					{
						text = "u_" + firstSnderID.ToString();
					}
					if (text.IsNullOrEmpty() && currentStepID == workFlowRunModel.FirstStepID)
					{
						text = "u_" + Users.CurrentUserID.ToString();
					}
					break;
				}
				case 6:
					text = GetStepSnderIDString(flowID, currentStepID, groupID);
					if (text.IsNullOrEmpty() && currentStepID == wfInstalled.FirstStepID)
					{
						text = "u_" + Users.CurrentUserID.ToString();
					}
					break;
				case 7:
					text = GetStepSnderIDString(workFlowRunModel.ID, step.Behavior.HandlerStepID, groupID);
					if (text.IsNullOrEmpty() && step.Behavior.HandlerStepID == workFlowRunModel.FirstStepID)
					{
						text = "u_" + Users.CurrentUserID.ToString();
					}
					break;
				case 8:
				{
					string valueField = step.Behavior.ValueField;
					if (!valueField.IsNullOrEmpty() && !instanceid.IsNullOrEmpty() && workFlowRunModel.DataBases.Count() > 0)
					{
						text = new DBConnection().GetFieldValue(valueField, workFlowRunModel.DataBases.First().PrimaryKey, instanceid);
					}
					break;
				}
				case 9:
				{
					Guid guid5 = GetFirstSnderID(workFlowRunModel.ID, groupID);
					if (guid5.IsEmptyGuid() && currentStepID == workFlowRunModel.FirstStepID)
					{
						guid5 = Users.CurrentUserID;
					}
					if (!guid5.IsEmptyGuid())
					{
						text = users.GetLeader(guid5);
					}
					break;
				}
				case 10:
				{
					Guid guid4 = GetFirstSnderID(workFlowRunModel.ID, groupID);
					if (guid4.IsEmptyGuid() && currentStepID == workFlowRunModel.FirstStepID)
					{
						guid4 = Users.CurrentUserID;
					}
					if (!guid4.IsEmptyGuid())
					{
						text = users.GetChargeLeader(guid4);
					}
					break;
				}
				case 11:
					text = users.GetLeader(Users.CurrentUserID);
					break;
				case 12:
					text = users.GetChargeLeader(Users.CurrentUserID);
					break;
				case 13:
				{
					Guid guid2 = GetFirstSnderID(workFlowRunModel.ID, groupID);
					if (guid2.IsEmptyGuid() && currentStepID == workFlowRunModel.FirstStepID)
					{
						guid2 = Users.CurrentUserID;
					}
					if (!guid2.IsEmptyGuid())
					{
						text = users.GetParentDeptLeader(guid2);
					}
					break;
				}
				case 14:
					text = users.GetParentDeptLeader(Users.CurrentUserID);
					break;
				case 15:
				{
					string text2 = GetStepSnderIDString(workFlowRunModel.ID, currentStepID, groupID);
					if (text2.IsNullOrEmpty() && step.Behavior.HandlerStepID == workFlowRunModel.FirstStepID)
					{
						text2 = "u_" + Users.CurrentUserID.ToString();
					}
					StringBuilder stringBuilder2 = new StringBuilder();
					string[] array = (text2 ?? "").Split(',');
					foreach (string id in array)
					{
						RoadFlow.Data.Model.Organize deptByUserID2 = new Users().GetDeptByUserID(Users.RemovePrefix(id).ToGuid());
						if (deptByUserID2 != null)
						{
							foreach (RoadFlow.Data.Model.Users allUser in new Organize().GetAllUsers(deptByUserID2.ID))
							{
								stringBuilder2.Append("u_");
								stringBuilder2.Append(allUser.ID);
								stringBuilder2.Append(",");
							}
						}
					}
					text = stringBuilder2.ToString().TrimEnd(',');
					break;
				}
				case 16:
				{
					Guid guid3 = GetFirstSnderID(workFlowRunModel.ID, groupID);
					if (guid3.IsEmptyGuid() && currentStepID == workFlowRunModel.FirstStepID)
					{
						guid3 = Users.CurrentUserID;
					}
					StringBuilder stringBuilder = new StringBuilder();
					RoadFlow.Data.Model.Organize deptByUserID = new Users().GetDeptByUserID(guid3);
					if (deptByUserID != null)
					{
						foreach (RoadFlow.Data.Model.Users allUser2 in new Organize().GetAllUsers(deptByUserID.ID))
						{
							stringBuilder.Append("u_");
							stringBuilder.Append(allUser2.ID);
							stringBuilder.Append(",");
						}
					}
					text = stringBuilder.ToString().TrimEnd(',');
					break;
				}
				case 17:
				{
					Guid guid = GetFirstSnderID(workFlowRunModel.ID, groupID);
					if (guid.IsEmptyGuid() && currentStepID == workFlowRunModel.FirstStepID)
					{
						guid = Users.CurrentUserID;
					}
					text = new Users().GetAllParentsDeptLeader(guid).ToArray().Join1();
					break;
				}
				case 18:
					text = new Users().GetAllParentsDeptLeader(Users.CurrentUserID).ToArray().Join1();
					break;
				}
			}
			else
			{
				text = "u_" + Users.CurrentUserID.ToString();
			}
			if (!text.IsNullOrEmpty())
			{
				text = text.Split(',').Distinct().ToArray()
					.Join1();
			}
			if (step.Behavior.HandlerType.In(9, 10, 11, 12, 13, 14, 15, 16, 17, 18))
			{
				selectRange = "rootid=\"" + text + "\"";
			}
			if (text.IsNullOrEmpty())
			{
				text = step.Behavior.DefaultHandler;
				if (!step.Behavior.DefaultHandlerSqlOrMethod.IsNullOrEmpty())
				{
					string text3 = step.Behavior.DefaultHandlerSqlOrMethod.Trim1();
					StringBuilder stringBuilder3 = new StringBuilder();
					if (text3.StartsWith("select", StringComparison.CurrentCultureIgnoreCase))
					{
						if (workFlowRunModel.DataBases.Count() > 0)
						{
							string sql = Wildcard.FilterWildcard(text3, Users.CurrentUserID.ToString()).ReplaceSelectSql();
							DataTable dataTable = new DBConnection().GetDataTable(workFlowRunModel.DataBases.First().LinkID, sql);
							if (dataTable != null && dataTable.Columns.Count > 0)
							{
								foreach (DataRow row in dataTable.Rows)
								{
									stringBuilder3.Append(row[0].ToString());
									stringBuilder3.Append(",");
								}
							}
						}
					}
					else
					{
						WorkFlowCustomEventParams workFlowCustomEventParams = default(WorkFlowCustomEventParams);
						workFlowCustomEventParams.FlowID = flowID;
						workFlowCustomEventParams.GroupID = groupID;
						workFlowCustomEventParams.StepID = stepID;
						workFlowCustomEventParams.TaskID = Guid.Empty;
						workFlowCustomEventParams.InstanceID = instanceid;
						object obj = ExecuteFlowCustomEvent(text3, workFlowCustomEventParams);
						if (obj != null)
						{
							stringBuilder3.Append(obj.ToString());
						}
					}
					text = text + "," + stringBuilder3.ToString();
				}
			}
			if (!text.IsNullOrEmpty())
			{
				return text.TrimStart(',').TrimEnd(',');
			}
			return "";
		}

		public RoadFlow.Data.Model.WorkFlowTask GetLastTask(Guid flowID, Guid groupID)
		{
			return dataWorkFlowTask.GetLastTask(flowID, groupID);
		}

		public Result AutoSubmit(Guid taskID)
		{
			return AutoSubmit(Get(taskID));
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
			WorkFlowInstalled workFlowRunModel = new WorkFlow().GetWorkFlowRunModel(task.FlowID);
			if (workFlowRunModel == null)
			{
				result.DebugMessages = "未找到流程运行时";
				result.IsSuccess = false;
				result.Messages = "未找到流程运行时";
				return result;
			}
			IEnumerable<Step> source = from p in workFlowRunModel.Steps
			where p.ID == task.StepID
			select p;
			if (source.Count() == 0)
			{
				result.DebugMessages = "未找到当前步骤";
				result.IsSuccess = false;
				result.Messages = "未找到当前步骤";
				return result;
			}
			Step currentStep = source.First();
			Execute execute = new Execute();
			List<Step> nextSteps = bWorkFlow.GetNextSteps(task.FlowID, task.StepID);
			WorkFlowTask workFlowTask = new WorkFlowTask();
			Users users = new Users();
			Organize organize = new Organize();
			if (currentStep.Behavior.FlowType == 0 && nextSteps.Count() > 0 && task.Type != 7)
			{
				List<Guid> list = new List<Guid>();
				WorkFlowCustomEventParams workFlowCustomEventParams = default(WorkFlowCustomEventParams);
				workFlowCustomEventParams.FlowID = task.FlowID;
				workFlowCustomEventParams.GroupID = task.GroupID;
				workFlowCustomEventParams.StepID = currentStep.ID;
				workFlowCustomEventParams.TaskID = task.ID;
				workFlowCustomEventParams.InstanceID = task.InstanceID;
				StringBuilder stringBuilder = new StringBuilder();
				foreach (Step item in nextSteps)
				{
					IEnumerable<Line> source2 = wfInstalled.Lines.Where(delegate(Line p)
					{
						if (p.ToID == item.ID)
						{
							return p.FromID == currentStep.ID;
						}
						return false;
					});
					if (source2.Count() > 0)
					{
						Line line = source2.First();
						if (!line.SqlWhere.IsNullOrEmpty())
						{
							if (wfInstalled.DataBases.Count() == 0)
							{
								list.Add(item.ID);
							}
							else if (!workFlowTask.TestLineSql(wfInstalled.DataBases.First().LinkID, wfInstalled.DataBases.First().Table, wfInstalled.DataBases.First().PrimaryKey, task.InstanceID, line.SqlWhere))
							{
								list.Add(item.ID);
							}
						}
						if (!line.CustomMethod.IsNullOrEmpty())
						{
							object obj = workFlowTask.ExecuteFlowCustomEvent(line.CustomMethod.Trim(), workFlowCustomEventParams);
							Type type = obj.GetType();
							Type typeFromHandle = typeof(bool);
							if (type != typeFromHandle && "1" != obj.ToString())
							{
								list.Add(item.ID);
								stringBuilder.Append(obj.ToString());
								stringBuilder.Append("\\n");
							}
							else if (type == typeFromHandle && !(bool)obj)
							{
								list.Add(item.ID);
								stringBuilder.Append(obj.ToString());
								stringBuilder.Append("\\n");
							}
						}
						Guid currentUserID = Users.CurrentUserID;
						Guid empty = Guid.Empty;
						empty = ((!(currentStep.ID == wfInstalled.FirstStepID)) ? workFlowTask.GetFirstSnderID(workFlowCustomEventParams.FlowID, workFlowCustomEventParams.GroupID) : currentUserID);
						StringBuilder stringBuilder2 = new StringBuilder();
						if (!line.Organize.IsNullOrEmpty())
						{
							JsonData jsonData = JsonMapper.ToObject(line.Organize);
							foreach (JsonData item2 in (IEnumerable)jsonData)
							{
								if (jsonData.Count != 0)
								{
									string b = item2["usertype"].ToString();
									string b2 = item2.ContainsKey("in1") ? item2["in1"].ToString() : "";
									string b3 = item2["users"].ToString();
									string text = item2["selectorganize"].ToString();
									string value = item2["tjand"].ToString();
									string text2 = item2["khleft"].ToString();
									string text3 = item2["khright"].ToString();
									Guid userID = ("0" == b) ? currentUserID : empty;
									string memberString = "";
									bool flag = false;
									if ("0" == b3)
									{
										memberString = text;
									}
									else if ("1" == b3)
									{
										memberString = users.GetLeader(userID);
									}
									else if ("2" == b3)
									{
										memberString = users.GetChargeLeader(userID);
									}
									if ("0" == b2)
									{
										flag = users.IsContains(userID, memberString);
									}
									else if ("1" == b2)
									{
										flag = !users.IsContains(userID, memberString);
									}
									if (!text2.IsNullOrEmpty())
									{
										stringBuilder2.Append(text2);
									}
									stringBuilder2.Append(flag ? " true " : " false ");
									if (!text3.IsNullOrEmpty())
									{
										stringBuilder2.Append(text3);
									}
									stringBuilder2.Append(value);
								}
							}
							object obj2 = Tools.ExecuteCsharpCode("bool testbool=" + stringBuilder2.ToString() + ";return testbool;");
							if (obj2 != null && !(bool)obj2)
							{
								list.Add(item.ID);
							}
						}
					}
				}
				foreach (Guid item3 in list)
				{
					nextSteps.RemoveAll((Step p) => p.ID == item3);
				}
				if (nextSteps.Count == 0)
				{
					result.DebugMessages = "后续步骤条件均不符合,任务不能提交";
					result.IsSuccess = false;
					result.Messages = "后续步骤条件均不符合,任务不能提交";
					return result;
				}
			}
			if (nextSteps.Count == 0)
			{
				execute.ExecuteType = EnumType.ExecuteType.Completed;
			}
			else
			{
				execute.ExecuteType = EnumType.ExecuteType.Submit;
			}
			Dictionary<Guid, List<RoadFlow.Data.Model.Users>> dictionary = new Dictionary<Guid, List<RoadFlow.Data.Model.Users>>();
			foreach (Step item4 in nextSteps)
			{
				string selectType;
				string selectRange;
				string defultMember = GetDefultMember(task.FlowID, item4.ID, task.GroupID, task.StepID, task.InstanceID, out selectType, out selectRange);
				if (!defultMember.IsNullOrEmpty())
				{
					List<RoadFlow.Data.Model.Users> allUsers = organize.GetAllUsers(defultMember);
					if (allUsers.Count != 0 && item4.SendSetWorkTime != 1)
					{
						dictionary.Add(item4.ID, allUsers);
					}
				}
			}
			if (dictionary.Count > 0 || nextSteps.Count == 0)
			{
				execute.FlowID = task.FlowID;
				execute.GroupID = task.GroupID;
				execute.InstanceID = task.InstanceID;
				execute.Sender = new Users().Get(task.ReceiveID);
				execute.StepID = task.StepID;
				execute.Steps = dictionary;
				execute.TaskID = task.ID;
				execute.Title = task.Title;
				execute.IsSign = false;
				execute.OtherType = 0;
				if (isExpired)
				{
					execute.Note = "";
				}
				return Execute(execute);
			}
			result.DebugMessages = "后续步骤未找到接收人";
			result.IsSuccess = false;
			result.Messages = "后续步骤未找到接收人";
			return result;
		}

		public List<Step> GetAddWriteSteps(Guid taskID)
		{
			List<Step> list = new List<Step>();
			RoadFlow.Data.Model.WorkFlowTask task = Get(taskID);
			if (task == null || !task.OtherType.HasValue)
			{
				return list;
			}
			int num = task.OtherType.Value.ToString().Left(1).ToInt();
			task.OtherType.Value.ToString().Right(1).ToInt();
			WorkFlowInstalled workFlowRunModel = new WorkFlow().GetWorkFlowRunModel(task.FlowID);
			if (num == 2)
			{
				List<RoadFlow.Data.Model.WorkFlowTask> nextTasks = GetNextTaskList(task.PrevID);
				if (nextTasks.Count > 0)
				{
					IEnumerable<Step> source = from p in workFlowRunModel.Steps
					where p.ID == nextTasks.FirstOrDefault().StepID
					select p;
					if (source.Count() > 0)
					{
						list.Add(source.FirstOrDefault());
					}
				}
			}
			else
			{
				IEnumerable<Step> source2 = from p in workFlowRunModel.Steps
				where p.ID == task.StepID
				select p;
				if (source2.Count() > 0)
				{
					list.Add(source2.FirstOrDefault());
				}
			}
			return list;
		}

		public string GetAddWriteMembers(Guid taskID)
		{
			RoadFlow.Data.Model.WorkFlowTask task = Get(taskID);
			if (task == null || !task.OtherType.HasValue)
			{
				return "";
			}
			string str = string.Empty;
			int num = task.OtherType.Value.ToString().Left(1).ToInt();
			if (task.OtherType.Value.ToString().Right(1).ToInt() == 3)
			{
				IOrderedEnumerable<RoadFlow.Data.Model.WorkFlowTask> source = from p in GetTaskList(task.FlowID, task.StepID, task.GroupID).FindAll(delegate(RoadFlow.Data.Model.WorkFlowTask p)
				{
					if (p.PrevID == task.PrevID && p.Type == 7 && p.ID != task.ID)
					{
						return p.Status.In(-1, 0, 1);
					}
					return false;
				})
				orderby p.ReceiveTime
				select p;
				if (source.Count() > 0)
				{
					str = "u_" + source.FirstOrDefault().ReceiveID.ToString();
				}
			}
			if (str.IsNullOrEmpty())
			{
				switch (num)
				{
				case 1:
					str = "u_" + task.SenderID.ToString();
					break;
				case 2:
				{
					List<RoadFlow.Data.Model.WorkFlowTask> list = GetNextTaskList(task.PrevID).FindAll((RoadFlow.Data.Model.WorkFlowTask p) => p.StepID != task.StepID);
					StringBuilder stringBuilder = new StringBuilder();
					foreach (RoadFlow.Data.Model.WorkFlowTask item in list)
					{
						stringBuilder.Append("u_" + item.ReceiveID.ToString());
						stringBuilder.Append(",");
					}
					str = stringBuilder.ToString().TrimEnd(',');
					break;
				}
				case 3:
					str = "u_" + task.SenderID.ToString();
					break;
				}
			}
			return str;
		}

		public bool AddWrite(Guid taskID, int addType, int writeType, string writeUsers, string note, out string msg)
		{
			WorkFlowTask workFlowTask = new WorkFlowTask();
			Organize organize = new Organize();
			msg = "";
			RoadFlow.Data.Model.WorkFlowTask workFlowTask2 = workFlowTask.Get(taskID);
			if (workFlowTask2 == null)
			{
				msg = "未找到当前任务,不能加签!";
				return false;
			}
			List<RoadFlow.Data.Model.Users> allUsers = organize.GetAllUsers(writeUsers);
			int num = 0;
			foreach (RoadFlow.Data.Model.Users item in allUsers)
			{
				RoadFlow.Data.Model.WorkFlowTask workFlowTask3 = new RoadFlow.Data.Model.WorkFlowTask();
				workFlowTask3.FlowID = workFlowTask2.FlowID;
				workFlowTask3.GroupID = workFlowTask2.GroupID;
				workFlowTask3.ID = Guid.NewGuid();
				workFlowTask3.InstanceID = workFlowTask2.InstanceID;
				workFlowTask3.Note = note;
				workFlowTask3.PrevID = workFlowTask2.ID;
				workFlowTask3.PrevStepID = workFlowTask2.PrevStepID;
				workFlowTask3.ReceiveID = item.ID;
				workFlowTask3.ReceiveName = item.Name;
				workFlowTask3.SenderTime = DateTimeNew.Now;
				workFlowTask3.ReceiveTime = workFlowTask3.SenderTime.AddSeconds((double)num++);
				workFlowTask3.SenderID = workFlowTask2.ReceiveID;
				workFlowTask3.SenderName = workFlowTask2.ReceiveName;
				workFlowTask3.Sort = workFlowTask2.Sort + 1;
				workFlowTask3.StepID = workFlowTask2.StepID;
				workFlowTask3.StepName = workFlowTask2.StepName;
				workFlowTask3.Title = workFlowTask2.Title;
				workFlowTask3.OtherType = (addType.ToString() + writeType.ToString()).ToInt();
				workFlowTask3.Type = 7;
				if ((addType == 1 && writeType == 3 && item.ID != allUsers.FirstOrDefault().ID) || addType == 2)
				{
					workFlowTask3.Status = -1;
				}
				else
				{
					workFlowTask3.Status = 0;
				}
				if (!HasNoCompletedTasks(workFlowTask2.FlowID, workFlowTask2.StepID, workFlowTask2.GroupID, item.ID))
				{
					workFlowTask.Add(workFlowTask3);
				}
			}
			if (addType == 1)
			{
				foreach (RoadFlow.Data.Model.WorkFlowTask task in workFlowTask.GetTaskList(taskID))
				{
					task.Status = -1;
					workFlowTask.Update(task);
				}
			}
			return true;
		}

		public void ExpiredAutoSubmit()
		{
			List<RoadFlow.Data.Model.WorkFlowTask> expiredAutoSubmitTasks = dataWorkFlowTask.GetExpiredAutoSubmitTasks();
			WorkFlowTask workFlowTask = new WorkFlowTask();
			foreach (RoadFlow.Data.Model.WorkFlowTask item in expiredAutoSubmitTasks)
			{
				try
				{
					workFlowTask.AutoSubmit(item, true);
				}
				catch (Exception err)
				{
					Log.Add(err);
				}
			}
		}

		public List<RoadFlow.Data.Model.Users> GetCopyForUsers(CopyFor copyFor, RoadFlow.Data.Model.WorkFlowTask currentTask)
		{
			List<RoadFlow.Data.Model.Users> list = new List<RoadFlow.Data.Model.Users>();
			if (copyFor == null)
			{
				return list;
			}
			Organize organize = new Organize();
			Users users = new Users();
			if (!copyFor.MemberID.IsNullOrEmpty())
			{
				list.AddRange(organize.GetAllUsers(copyFor.MemberID));
			}
			if (!copyFor.MethodOrSql.IsNullOrEmpty())
			{
				WorkFlowInstalled workFlowRunModel = bWorkFlow.GetWorkFlowRunModel(currentTask.FlowID);
				string text = copyFor.MethodOrSql.Trim1();
				StringBuilder stringBuilder = new StringBuilder();
				if (text.StartsWith("select", StringComparison.CurrentCultureIgnoreCase))
				{
					if (workFlowRunModel.DataBases.Count() > 0)
					{
						string sql = Wildcard.FilterWildcard(text, Users.CurrentUserID.ToString()).ReplaceSelectSql();
						DataTable dataTable = new DBConnection().GetDataTable(workFlowRunModel.DataBases.First().LinkID, sql);
						if (dataTable != null && dataTable.Columns.Count > 0)
						{
							foreach (DataRow row in dataTable.Rows)
							{
								stringBuilder.Append(row[0].ToString());
								stringBuilder.Append(",");
							}
						}
					}
				}
				else
				{
					WorkFlowCustomEventParams workFlowCustomEventParams = default(WorkFlowCustomEventParams);
					workFlowCustomEventParams.FlowID = currentTask.FlowID;
					workFlowCustomEventParams.GroupID = currentTask.GroupID;
					workFlowCustomEventParams.StepID = currentTask.StepID;
					workFlowCustomEventParams.TaskID = currentTask.ID;
					workFlowCustomEventParams.InstanceID = currentTask.InstanceID;
					object obj = ExecuteFlowCustomEvent(text, workFlowCustomEventParams);
					if (obj != null)
					{
						stringBuilder.Append(obj.ToString());
					}
				}
				list.AddRange(organize.GetAllUsers(stringBuilder.ToString()));
			}
			if (!copyFor.handlerType.IsNullOrEmpty())
			{
				string[] array = copyFor.handlerType.Split(new string[1]
				{
					","
				}, StringSplitOptions.RemoveEmptyEntries);
				for (int i = 0; i < array.Length; i++)
				{
					switch (array[i].ToInt())
					{
					case 0:
						list.Add(users.Get(GetFirstSnderID(currentTask.FlowID, currentTask.GroupID)));
						break;
					case 1:
						list.AddRange(organize.GetAllUsers(GetStepSnderIDString(currentTask.FlowID, currentTask.PrevStepID, currentTask.GroupID)));
						break;
					case 2:
						list.AddRange(organize.GetAllUsers(users.GetLeader(GetFirstSnderID(currentTask.FlowID, currentTask.GroupID))));
						break;
					case 3:
						list.AddRange(organize.GetAllUsers(users.GetChargeLeader(GetFirstSnderID(currentTask.FlowID, currentTask.GroupID))));
						break;
					case 4:
						list.AddRange(organize.GetAllUsers(users.GetParentDeptLeader(GetFirstSnderID(currentTask.FlowID, currentTask.GroupID))));
						break;
					case 5:
					{
						RoadFlow.Data.Model.Organize deptByUserID = users.GetDeptByUserID(GetFirstSnderID(currentTask.FlowID, currentTask.GroupID));
						list.AddRange(organize.GetAllUsers(deptByUserID.ID));
						break;
					}
					case 6:
						list.AddRange(organize.GetAllUsers(users.GetAllParentsDeptLeader(GetFirstSnderID(currentTask.FlowID, currentTask.GroupID)).ToArray().Join1()));
						break;
					case 7:
						list.AddRange(organize.GetAllUsers(users.GetLeader(Users.CurrentUserID)));
						break;
					case 8:
						list.AddRange(organize.GetAllUsers(users.GetChargeLeader(Users.CurrentUserID)));
						break;
					case 9:
						list.AddRange(organize.GetAllUsers(users.GetParentDeptLeader(Users.CurrentUserID)));
						break;
					case 10:
						list.AddRange(organize.GetAllUsers(Users.CurrentDeptID));
						break;
					}
				}
			}
			if (!copyFor.steps.IsNullOrEmpty())
			{
				string[] array = copyFor.steps.Split(new string[1]
				{
					","
				}, StringSplitOptions.RemoveEmptyEntries);
				foreach (string str in array)
				{
					list.AddRange(organize.GetAllUsers(GetStepSnderIDString(currentTask.FlowID, str.ToGuid(), currentTask.GroupID)));
				}
			}
			list.Distinct(new UsersEqualityComparer());
			return list;
		}
	}
}
