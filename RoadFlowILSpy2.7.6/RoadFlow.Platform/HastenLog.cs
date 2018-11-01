using RoadFlow.Data.Factory;
using RoadFlow.Data.Interface;
using RoadFlow.Data.Model;
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
			dataHastenLog = Factory.GetHastenLog();
		}

		public int Add(RoadFlow.Data.Model.HastenLog model)
		{
			return dataHastenLog.Add(model);
		}

		public int Update(RoadFlow.Data.Model.HastenLog model)
		{
			return dataHastenLog.Update(model);
		}

		public List<RoadFlow.Data.Model.HastenLog> GetAll()
		{
			return dataHastenLog.GetAll();
		}

		public RoadFlow.Data.Model.HastenLog Get(Guid id)
		{
			return dataHastenLog.Get(id);
		}

		public int Delete(Guid id)
		{
			return dataHastenLog.Delete(id);
		}

		public long GetCount()
		{
			return dataHastenLog.GetCount();
		}

		public static string GetHastenTypeCheckboxString(string name, string value)
		{
			List<ListItem> list = new List<ListItem>();
			Dictionary<int, string> dictionary = new Dictionary<int, string>();
			dictionary.Add(1, "手机短信");
			dictionary.Add(2, "邮件");
			dictionary.Add(3, "站内消息");
			if (RoadFlow.Platform.WeiXin.Config.IsUse)
			{
				dictionary.Add(4, "微信");
			}
			foreach (KeyValuePair<int, string> item in dictionary)
			{
				list.Add(new ListItem(item.Value, item.Key.ToString())
				{
					Selected = true
				});
			}
			return Tools.GetCheckBoxString(list.ToArray(), name, (value ?? "").Split(','), "validate='checkbox'");
		}

		public static void Hasten(string types, string users, string contents, RoadFlow.Data.Model.WorkFlowTask task, string othersParams = "")
		{
			if (!users.IsNullOrEmpty() && !types.IsNullOrEmpty() && task != null)
			{
				string[] array = users.Split(',');
				Guid guid = Guid.NewGuid();
				List<RoadFlow.Data.Model.WorkFlowTask> list = new WorkFlowTask().GetNextTaskList(task.ID).FindAll((RoadFlow.Data.Model.WorkFlowTask p) => p.Status.In(0, 1));
				string text = "";
				text = ((!(HttpContext.Current.Request.Url != null) || !HttpContext.Current.Request.Url.AbsolutePath.EndsWith(".aspx", StringComparison.CurrentCultureIgnoreCase)) ? "/WorkFlowRun/Index" : "/Platform/WorkFlowRun/Default.aspx");
				string[] array2 = types.Split(',');
				for (int i = 0; i < array2.Length; i++)
				{
					int test;
					if (array2[i].IsInt(out test))
					{
						string[] array3 = array;
						foreach (string id in array3)
						{
							Guid userGuid;
							if (Users.RemovePrefix(id).IsGuid(out userGuid))
							{
								RoadFlow.Data.Model.WorkFlowTask workFlowTask = list.Find((RoadFlow.Data.Model.WorkFlowTask p) => p.ReceiveID == userGuid);
								string linkUrl = (workFlowTask == null) ? "" : ("javascript:openApp('" + text + "?flowid=" + workFlowTask.FlowID + "&stepid=" + workFlowTask.StepID + "&instanceid=" + workFlowTask.InstanceID + "&taskid=" + workFlowTask.ID + "&groupid=" + workFlowTask.GroupID + "',0,'" + workFlowTask.Title.Replace1(",", "") + "','tab_" + workFlowTask.ID + "');closeMessage('" + guid + "');");
								switch (test)
								{
								case 1:
									SMSLog.SendSMS(new Users().GetMobileNumber(userGuid), contents);
									break;
								case 2:
									Email.Send(userGuid, "任务催办", contents);
									break;
								case 3:
								{
									RoadFlow.Data.Model.Users users3 = new Users().Get(userGuid);
									if (users3 != null)
									{
										ShortMessage.Send(users3.ID, users3.Name, "任务催办", contents, 0, linkUrl, task.ID.ToString(), guid.ToString());
									}
									break;
								}
								case 4:
								{
									RoadFlow.Data.Model.Users users2 = new Users().Get(userGuid);
									if (users2 != null)
									{
										new Message().SendText(contents, users2.Account, "", "", 0, new Agents().GetAgentIDByCode("weixinagents_waittasks"), true);
									}
									break;
								}
								}
							}
						}
					}
				}
				RoadFlow.Data.Model.HastenLog hastenLog = new RoadFlow.Data.Model.HastenLog();
				hastenLog.Contents = contents;
				hastenLog.ID = Guid.NewGuid();
				hastenLog.SendTime = DateTimeNew.Now;
				hastenLog.SendUser = Users.CurrentUserID;
				hastenLog.SendUserName = Users.CurrentUserName;
				hastenLog.OthersParams = (othersParams.IsNullOrEmpty() ? task.ID.ToString() : othersParams);
				hastenLog.Types = types;
				hastenLog.Users = users;
				new HastenLog().Add(hastenLog);
			}
		}
	}
}
