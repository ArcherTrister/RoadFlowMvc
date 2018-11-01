using LitJson;
using RoadFlow.Data.Model;
using RoadFlow.Utility;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Data;
using System.IO;
using System.Linq;
using System.Text;
using System.Web;

namespace RoadFlow.Platform.WeiXin
{
	public class Organize
	{
		private delegate bool del_Save(RoadFlow.Data.Model.Organize organize);

		private delegate bool del_SaveUser(RoadFlow.Data.Model.Users user);

		private delegate bool del_SaveWorkGroup(RoadFlow.Data.Model.WorkGroup wg);

		private delegate bool del_Delete(int orgID);

		private delegate bool del_DeleteUser(string account);

		private delegate bool del_DeleteUser1(string[] account);

		private string secret = string.Empty;

		public static Guid CurrentUserID
		{
			get
			{
				try
				{
					object obj = HttpContext.Current.Session[0.ToString()];
					if (obj != null && obj.ToString().IsGuid())
					{
						return obj.ToString().ToGuid();
					}
					HttpCookie httpCookie = HttpContext.Current.Request.Cookies.Get("weixin_userid");
					if (httpCookie != null && httpCookie.Value.IsGuid())
					{
						return httpCookie.Value.ToGuid();
					}
					return Guid.Empty;
				}
				catch
				{
					return Guid.Empty;
				}
			}
		}

		public static string CurrentUserName
		{
			get
			{
				HttpCookie httpCookie = HttpContext.Current.Request.Cookies.Get("weixin_username");
				if (httpCookie != null)
				{
					return httpCookie.Value;
				}
				string name = new Users().GetName(CurrentUserID);
				HttpContext.Current.Response.Cookies.Add(new HttpCookie("weixin_username", name));
				return name;
			}
		}

		public static RoadFlow.Data.Model.Users CurrentUser
		{
			get
			{
				return new Users().Get(CurrentUserID);
			}
		}

		public Organize()
		{
			string text = Config.GetSecret("weixinagents_organize");
			secret = (text.IsNullOrEmpty() ? Config.OrganizeSecret : text);
		}

		public Organize(int agentId)
		{
			secret = Config.GetSecret(agentId);
		}

		public Organize(string agentCode)
		{
			secret = Config.GetSecret(agentCode);
		}

		private string GetAccessToken()
		{
			return Config.GetAccessToken(secret);
		}

		private string replaceName(string name)
		{
			if (!name.IsNullOrEmpty())
			{
				return name.Replace("\\", "").Replace(":", "").Replace("*", "")
					.Replace("?", "")
					.Replace("\"", "")
					.Replace("<", "")
					.Replace(">", "")
					.Replace("｜", "");
			}
			return name;
		}

		public bool AddDept(RoadFlow.Data.Model.Organize organize)
		{
			if (organize.IntID == 0)
			{
				organize = new RoadFlow.Platform.Organize().Get(organize.ID);
			}
			int num = 1;
			if (!organize.ParentID.IsEmptyGuid())
			{
				RoadFlow.Data.Model.Organize organize2 = new RoadFlow.Platform.Organize().Get(organize.ParentID);
				if (organize2 != null)
				{
					num = organize2.IntID;
				}
			}
			string url = "https://qyapi.weixin.qq.com/cgi-bin/department/create?access_token=" + GetAccessToken();
			string text = "{\"name\":\"" + replaceName(organize.Name) + "\",\"parentid\":" + num.ToString() + ",\"order\":" + organize.Sort.ToString() + ",\"id\":" + organize.IntID.ToString() + "}";
			string text2 = HttpHelper.SendPost(url, text);
			JsonData jsonData = JsonMapper.ToObject(text2);
			bool flag = jsonData.ContainsKey("errcode") && jsonData["errcode"].ToString().ToInt() == 0;
			Log.Add("调用了微信添加部门-" + organize.Name + "-" + (flag ? "成功" : "失败"), "返回：" + text2, Log.Types.微信企业号, organize.Serialize(), text);
			return flag;
		}

		public void AddDeptAsync(RoadFlow.Data.Model.Organize organize)
		{
			new del_Save(AddDept).BeginInvoke(organize, null, null);
		}

		public bool EditDept(RoadFlow.Data.Model.Organize organize)
		{
			int num = 1;
			if (!organize.ParentID.IsEmptyGuid())
			{
				RoadFlow.Data.Model.Organize organize2 = new RoadFlow.Platform.Organize().Get(organize.ParentID);
				if (organize2 != null)
				{
					num = organize2.IntID;
				}
			}
			string url = "https://qyapi.weixin.qq.com/cgi-bin/department/update?access_token=" + GetAccessToken();
			string text = "{\"id\":" + organize.IntID.ToString() + ",\"name\":\"" + replaceName(organize.Name) + "\",\"parentid\":" + num.ToString() + ",\"order\":" + organize.Sort.ToString() + "}";
			string text2 = HttpHelper.SendPost(url, text);
			JsonData jsonData = JsonMapper.ToObject(text2);
			bool flag = jsonData.ContainsKey("errcode") && jsonData["errcode"].ToString().ToInt() == 0;
			Log.Add("调用了微信修改部门-" + organize.Name + "-" + (flag ? "成功" : "失败"), "返回：" + text2, Log.Types.微信企业号, organize.Serialize(), text);
			return flag;
		}

		public void EditDeptAsync(RoadFlow.Data.Model.Organize organize)
		{
			new del_Save(EditDept).BeginInvoke(organize, null, null);
		}

		public bool DeleteDept(int organizeIntID)
		{
			string text = "https://qyapi.weixin.qq.com/cgi-bin/department/delete?access_token=" + GetAccessToken() + "&id=" + organizeIntID.ToString();
			string text2 = HttpHelper.SendGet(text);
			Log.Add("调用了微信删除部门", "返回：" + text2, Log.Types.微信企业号, text);
			JsonData jsonData = JsonMapper.ToObject(text2);
			if (jsonData.ContainsKey("errcode"))
			{
				return jsonData["errcode"].ToString().ToInt() == 0;
			}
			return false;
		}

		public void DeleteDeptAsync(int organizeIntID)
		{
			new del_Delete(DeleteDept).BeginInvoke(organizeIntID, null, null);
		}

		public string GetUser(string userAccount)
		{
			string text = HttpHelper.SendGet("https://qyapi.weixin.qq.com/cgi-bin/user/get?access_token=" + GetAccessToken() + "&userid=" + userAccount);
			JsonData jsonData = JsonMapper.ToObject(text);
			bool flag = jsonData.ContainsKey("errcode") && jsonData["errcode"].ToString().ToInt() == 0;
			Log.Add("调用了微信查询人员-" + userAccount + "-" + (flag ? "成功" : "失败"), "返回：" + text, Log.Types.微信企业号);
			if (!flag)
			{
				return "";
			}
			return text;
		}

		public bool AddUser(RoadFlow.Data.Model.Users user)
		{
			if (user.Mobile.IsNullOrEmpty() && user.Email.IsNullOrEmpty() && user.WeiXin.IsNullOrEmpty())
			{
				return false;
			}
			string url = "https://qyapi.weixin.qq.com/cgi-bin/user/create?access_token=" + GetAccessToken();
			List<RoadFlow.Data.Model.UsersRelation> allByUserID = new UsersRelation().GetAllByUserID(user.ID);
			RoadFlow.Platform.Organize organize = new RoadFlow.Platform.Organize();
			StringBuilder stringBuilder = new StringBuilder();
			foreach (RoadFlow.Data.Model.UsersRelation item in allByUserID)
			{
				RoadFlow.Data.Model.Organize organize2 = organize.Get(item.OrganizeID);
				if (organize2 != null)
				{
					stringBuilder.Append(organize2.IntID);
					stringBuilder.Append(",");
				}
			}
			string text = "{\"userid\":\"" + user.Account + "\",\"name\":\"" + replaceName(user.Name) + "\",\"department\":[" + stringBuilder.ToString().TrimEnd(',') + "],\"position\":\"\",\"mobile\":\"" + user.Mobile + "\"," + (user.Sex.HasValue ? ("\"gender\":\"" + (user.Sex.Value + 1).ToString() + "\",") : "") + "\"weixinid\":\"" + user.WeiXin + "\"}";
			string text2 = HttpHelper.SendPost(url, text);
			JsonData jsonData = JsonMapper.ToObject(text2);
			bool flag = jsonData.ContainsKey("errcode") && jsonData["errcode"].ToString().ToInt() == 0;
			Log.Add("调用了微信添加人员-" + user.Name + "-" + (flag ? "成功" : "失败"), "返回：" + text2, Log.Types.微信企业号, user.Serialize(), text);
			return flag;
		}

		public void AddUserAsync(RoadFlow.Data.Model.Users user)
		{
			new del_SaveUser(AddUser).BeginInvoke(user, null, null);
		}

		public bool EditUser(RoadFlow.Data.Model.Users user)
		{
			if (user.Mobile.IsNullOrEmpty() && user.Email.IsNullOrEmpty() && user.WeiXin.IsNullOrEmpty())
			{
				return false;
			}
			if (GetUser(user.Account).IsNullOrEmpty())
			{
				return AddUser(user);
			}
			string url = "https://qyapi.weixin.qq.com/cgi-bin/user/update?access_token=" + GetAccessToken();
			List<RoadFlow.Data.Model.UsersRelation> allByUserID = new UsersRelation().GetAllByUserID(user.ID);
			RoadFlow.Platform.Organize organize = new RoadFlow.Platform.Organize();
			StringBuilder stringBuilder = new StringBuilder();
			foreach (RoadFlow.Data.Model.UsersRelation item in allByUserID)
			{
				RoadFlow.Data.Model.Organize organize2 = organize.Get(item.OrganizeID);
				if (organize2 != null)
				{
					stringBuilder.Append(organize2.IntID);
					stringBuilder.Append(",");
				}
			}
			string text = "{\"userid\":\"" + user.Account + "\",\"name\":\"" + replaceName(user.Name) + "\",\"department\":[" + stringBuilder.ToString().TrimEnd(',') + "],\"position\":\"\",\"mobile\":\"" + user.Mobile + "\"," + (user.Sex.HasValue ? ("\"gender\":\"" + (user.Sex.Value + 1).ToString() + "\",") : "") + "\"email\":\"" + user.Email + "\",\"weixinid\":\"" + user.WeiXin + "\",\"enable\":" + ((user.Status == 0) ? 1 : 0).ToString() + "}";
			string text2 = HttpHelper.SendPost(url, text);
			JsonData jsonData = JsonMapper.ToObject(text2);
			bool flag = jsonData.ContainsKey("errcode") && jsonData["errcode"].ToString().ToInt() == 0;
			Log.Add("调用了微信修改人员-" + user.Name + "-" + (flag ? "成功" : "失败"), "返回：" + text2, Log.Types.微信企业号, user.Serialize(), text);
			return flag;
		}

		public void EditUserAsync(RoadFlow.Data.Model.Users user)
		{
			new del_SaveUser(EditUser).BeginInvoke(user, null, null);
		}

		public bool DeleteUser(string userAccount)
		{
			string text = "https://qyapi.weixin.qq.com/cgi-bin/user/delete?access_token=" + GetAccessToken() + "&userid=" + userAccount;
			string text2 = HttpHelper.SendGet(text);
			JsonData jsonData = JsonMapper.ToObject(text2);
			bool flag = jsonData.ContainsKey("errcode") && jsonData["errcode"].ToString().ToInt() == 0;
			Log.Add("调用了微信删除人员-" + userAccount + "-" + (flag ? "成功" : "失败"), "返回：" + text2, Log.Types.微信企业号, text);
			return flag;
		}

		public void DeleteUserAsync(string userAccount)
		{
			new del_DeleteUser(DeleteUser).BeginInvoke(userAccount, null, null);
		}

		public bool DeleteUser(string[] userAccountList)
		{
			string url = "https://qyapi.weixin.qq.com/cgi-bin/user/batchdelete?access_token=" + GetAccessToken();
			string text = "{\"useridlist\":[" + Tools.GetSqlInString(userAccountList).Replace("'", "\"") + "]}";
			string text2 = HttpHelper.SendPost(url, text);
			JsonData jsonData = JsonMapper.ToObject(text2);
			bool flag = jsonData.ContainsKey("errcode") && jsonData["errcode"].ToString().ToInt() == 0;
			Log.Add("调用了微信批量删除人员-" + (flag ? "成功" : "失败"), "返回：" + text2, Log.Types.微信企业号, text);
			return flag;
		}

		public void DeleteUserAsync(string[] userAccountList)
		{
			new del_DeleteUser1(DeleteUser).BeginInvoke(userAccountList, null, null);
		}

		public bool AddGroup(RoadFlow.Data.Model.WorkGroup group)
		{
			if (group == null)
			{
				return false;
			}
			string url = "https://qyapi.weixin.qq.com/cgi-bin/tag/create?access_token=" + GetAccessToken();
			string text = "{\"tagname\":\"" + replaceName(group.Name) + "\",\"tagid\":" + group.IntID.ToString() + "}";
			string text2 = HttpHelper.SendPost(url, text);
			JsonData jsonData = JsonMapper.ToObject(text2);
			bool flag = jsonData.ContainsKey("errcode") && jsonData["errcode"].ToString().ToInt() == 0;
			Log.Add("调用了微信添加标签-" + (flag ? "成功" : "失败"), "返回：" + text2, Log.Types.微信企业号, text);
			if (flag && !AddGroupUser(group))
			{
				return false;
			}
			return flag;
		}

		public void AddGroupAsync(RoadFlow.Data.Model.WorkGroup group)
		{
			new del_SaveWorkGroup(AddGroup).BeginInvoke(group, null, null);
		}

		public bool EditGroup(RoadFlow.Data.Model.WorkGroup group)
		{
			if (group == null)
			{
				return false;
			}
			string url = "https://qyapi.weixin.qq.com/cgi-bin/tag/update?access_token=" + GetAccessToken();
			string text = "{\"tagid\":" + group.IntID.ToString() + ",\"tagname\":\"" + replaceName(group.Name) + "\"}";
			string text2 = HttpHelper.SendPost(url, text);
			JsonData jsonData = JsonMapper.ToObject(text2);
			bool flag = jsonData.ContainsKey("errcode") && jsonData["errcode"].ToString().ToInt() == 0;
			Log.Add("调用了微信修改标签-" + (flag ? "成功" : "失败"), "返回：" + text2, Log.Types.微信企业号, text);
			return flag;
		}

		public void EditGroupAsync(RoadFlow.Data.Model.WorkGroup group)
		{
			new del_SaveWorkGroup(EditGroup).BeginInvoke(group, null, null);
		}

		public bool DeleteGroup(RoadFlow.Data.Model.WorkGroup group)
		{
			if (group == null)
			{
				return false;
			}
			if (DeleteGroupUser(group.IntID))
			{
				string text = HttpHelper.SendGet("https://qyapi.weixin.qq.com/cgi-bin/tag/delete?access_token=" + GetAccessToken() + "&tagid=" + group.IntID.ToString());
				JsonData jsonData = JsonMapper.ToObject(text);
				bool flag = jsonData.ContainsKey("errcode") && jsonData["errcode"].ToString().ToInt() == 0;
				Log.Add("调用了微信删除标签-" + group.Name + "-" + (flag ? "成功" : "失败"), "返回：" + text, Log.Types.微信企业号, group.Serialize());
				return flag;
			}
			return false;
		}

		public void DeleteGroupAsync(RoadFlow.Data.Model.WorkGroup group)
		{
			new del_SaveWorkGroup(DeleteGroup).BeginInvoke(group, null, null);
		}

		public List<Tuple<string, string>> GetGroupUsers(int groupIntID)
		{
			string text = HttpHelper.SendGet("https://qyapi.weixin.qq.com/cgi-bin/tag/get?access_token=" + GetAccessToken() + "&tagid=" + groupIntID.ToString());
			JsonData jsonData = JsonMapper.ToObject(text);
			bool flag = jsonData.ContainsKey("errcode") && jsonData["errcode"].ToString().ToInt() == 0;
			List<Tuple<string, string>> list = new List<Tuple<string, string>>();
			Log.Add("调用了微信获取标签成员-" + groupIntID + "-" + (flag ? "成功" : "失败"), "返回：" + text, Log.Types.微信企业号);
			if (flag)
			{
				JsonData jsonData2 = jsonData["userlist"];
				if (jsonData2.IsArray)
				{
					foreach (JsonData item in (IEnumerable)jsonData2)
					{
						string text2 = item["userid"].ToString();
						string text3 = item["name"].ToString();
						if (!text2.IsNullOrEmpty() && !text3.IsNullOrEmpty())
						{
							list.Add(new Tuple<string, string>(text2, text3));
						}
					}
					return list;
				}
			}
			return list;
		}

		public bool AddGroupUser(RoadFlow.Data.Model.WorkGroup group)
		{
			string url = "https://qyapi.weixin.qq.com/cgi-bin/tag/addtagusers?access_token=" + GetAccessToken();
			if (group.Members.IsNullOrEmpty())
			{
				return true;
			}
			List<RoadFlow.Data.Model.Users> allUsers = new RoadFlow.Platform.Organize().GetAllUsers(group.Members);
			List<string> list = new List<string>();
			foreach (RoadFlow.Data.Model.Users item in allUsers)
			{
				list.Add(item.Account);
			}
			string text = Tools.GetSqlInString(list.ToArray()).Replace("'", "\"");
			if (!DeleteGroupUser(group.IntID, text))
			{
				return false;
			}
			string text2 = "{\"tagid\":" + group.IntID.ToString() + ",\"userlist\":[" + text + "]}";
			string text3 = HttpHelper.SendPost(url, text2);
			JsonData jsonData = JsonMapper.ToObject(text3);
			bool flag = jsonData.ContainsKey("errcode") && jsonData["errcode"].ToString().ToInt() == 0;
			Log.Add("调用了微信更新标签成员-" + (flag ? "成功" : "失败"), "返回：" + text3, Log.Types.微信企业号, text2);
			return flag;
		}

		public void AddGroupUserAsync(RoadFlow.Data.Model.WorkGroup group)
		{
			new del_SaveWorkGroup(AddGroupUser).BeginInvoke(group, null, null);
		}

		public bool DeleteGroupUser(int groupIntID, string userAccounts)
		{
			string url = "https://qyapi.weixin.qq.com/cgi-bin/tag/deltagusers?access_token=" + GetAccessToken();
			if (userAccounts.IsNullOrEmpty())
			{
				return true;
			}
			string text = "{\"tagid\":" + groupIntID.ToString() + ",\"userlist\":[" + userAccounts + "]}";
			string text2 = HttpHelper.SendPost(url, text);
			JsonData jsonData = JsonMapper.ToObject(text2);
			bool flag = jsonData.ContainsKey("errcode") && jsonData["errcode"].ToString().ToInt() == 0;
			Log.Add("调用了微信删除标签成员-" + (flag ? "成功" : "失败"), "返回：" + text2, Log.Types.微信企业号, text);
			return flag;
		}

		public bool DeleteGroupUser(int groupIntID)
		{
			List<Tuple<string, string>> groupUsers = GetGroupUsers(groupIntID);
			if (groupUsers.Count > 0)
			{
				StringBuilder stringBuilder = new StringBuilder();
				foreach (Tuple<string, string> item in groupUsers)
				{
					stringBuilder.Append("\"" + item.Item1 + "\",");
				}
				string url = "https://qyapi.weixin.qq.com/cgi-bin/tag/deltagusers?access_token=" + GetAccessToken();
				string text = "{\"tagid\":" + groupIntID.ToString() + ",\"userlist\":[" + stringBuilder.ToString().TrimEnd(',') + "]}";
				string text2 = HttpHelper.SendPost(url, text);
				JsonData jsonData = JsonMapper.ToObject(text2);
				bool flag = jsonData.ContainsKey("errcode") && jsonData["errcode"].ToString().ToInt() == 0;
				Log.Add("调用了微信删除标签成员-" + (flag ? "成功" : "失败"), "返回：" + text2, Log.Types.微信企业号, text);
				return flag;
			}
			return true;
		}

		public List<Tuple<int, string>> GetGroups()
		{
			string text = HttpHelper.SendGet("https://qyapi.weixin.qq.com/cgi-bin/tag/list?access_token=" + GetAccessToken());
			JsonData jsonData = JsonMapper.ToObject(text);
			bool flag = jsonData.ContainsKey("errcode") && jsonData["errcode"].ToString().ToInt() == 0;
			Log.Add("调用了微信所有标签-" + (flag ? "成功" : "失败"), "返回：" + text, Log.Types.微信企业号);
			List<Tuple<int, string>> list = new List<Tuple<int, string>>();
			if (flag)
			{
				JsonData jsonData2 = jsonData["taglist"];
				if (jsonData2.IsArray)
				{
					foreach (JsonData item in (IEnumerable)jsonData2)
					{
						string str = item["tagid"].ToString();
						string text2 = item["tagname"].ToString();
						if (str.IsInt() && !text2.IsNullOrEmpty())
						{
							list.Add(new Tuple<int, string>(str.ToInt(), text2));
						}
					}
					return list;
				}
			}
			return list;
		}

		public void UpdateAllOrganize()
		{
			RoadFlow.Platform.Organize organize = new RoadFlow.Platform.Organize();
			List<RoadFlow.Data.Model.Organize> all = organize.GetAll();
			DataTable dataTable = new DataTable
			{
				Columns = 
				{
					{
						"部门名称",
						"".GetType()
					},
					{
						"部门ID",
						1.GetType()
					},
					{
						"父部门ID",
						1.GetType()
					},
					{
						"排序",
						1.GetType()
					}
				}
			};
			foreach (RoadFlow.Data.Model.Organize item in all)
			{
				int num = -1;
				if (item.ParentID.IsEmptyGuid())
				{
					num = 1;
				}
				else
				{
					RoadFlow.Data.Model.Organize organize2 = organize.Get(item.ParentID);
					if (organize2 != null)
					{
						num = organize2.IntID;
					}
				}
				if (num != -1)
				{
					DataRow dataRow = dataTable.NewRow();
					dataRow["部门名称"] = replaceName(item.Name);
					dataRow["部门ID"] = item.IntID;
					dataRow["父部门ID"] = num;
					dataRow["排序"] = item.Sort;
					dataTable.Rows.Add(dataRow);
				}
			}
			string text = Files.FilePath + "WeiXinCsv\\";
			if (!Directory.Exists(text))
			{
				Directory.CreateDirectory(text);
			}
			string text2 = text + Guid.NewGuid().ToString("N") + ".csv";
			NPOIHelper.ExportCSV(dataTable, text2);
			string text3 = new Media(Config.GetSecret("weixinagents_organize")).UploadTemp(text2, "file");
			if (!text3.IsNullOrEmpty())
			{
				string url = "https://qyapi.weixin.qq.com/cgi-bin/batch/replaceparty?access_token=" + GetAccessToken();
				string text4 = "{\"media_id\":\"" + text3 + "\"}";
				string str = HttpHelper.SendPost(url, text4);
				Log.Add("调用了微信同步整个组织架构", "返回：" + str, Log.Types.微信企业号, text4);
			}
		}

		public void UpdateAllUsers()
		{
			RoadFlow.Platform.Organize organize = new RoadFlow.Platform.Organize();
			UsersRelation usersRelation = new UsersRelation();
			List<RoadFlow.Data.Model.Users> all = new Users().GetAll();
			DataTable dataTable = new DataTable
			{
				Columns = 
				{
					{
						"姓名",
						"".GetType()
					},
					{
						"帐号",
						"".GetType()
					},
					{
						"微信号",
						"".GetType()
					},
					{
						"手机号",
						"".GetType()
					},
					{
						"邮箱",
						"".GetType()
					},
					{
						"所在部门",
						"".GetType()
					},
					{
						"职位",
						"".GetType()
					}
				}
			};
			foreach (RoadFlow.Data.Model.Users item in all)
			{
				StringBuilder stringBuilder = new StringBuilder();
				foreach (RoadFlow.Data.Model.UsersRelation item2 in usersRelation.GetAllByUserID(item.ID))
				{
					RoadFlow.Data.Model.Organize organize2 = organize.Get(item2.OrganizeID);
					if (organize2 != null)
					{
						stringBuilder.Append(organize2.IntID);
						stringBuilder.Append(",");
					}
				}
				DataRow dataRow = dataTable.NewRow();
				dataRow["姓名"] = replaceName(item.Name);
				dataRow["帐号"] = item.Account;
				dataRow["微信号"] = item.WeiXin;
				dataRow["手机号"] = item.Mobile;
				dataRow["邮箱"] = item.Email;
				dataRow["所在部门"] = stringBuilder.ToString().TrimEnd(',');
				dataRow["职位"] = "";
				dataTable.Rows.Add(dataRow);
			}
			string text = Files.FilePath + "WeiXinCsv\\";
			if (!Directory.Exists(text))
			{
				Directory.CreateDirectory(text);
			}
			string text2 = text + Guid.NewGuid().ToString("N") + ".csv";
			NPOIHelper.ExportCSV(dataTable, text2);
			string text3 = new Media(Config.GetSecret("weixinagents_organize")).UploadTemp(text2, "file");
			if (!text3.IsNullOrEmpty())
			{
				string url = "https://qyapi.weixin.qq.com/cgi-bin/batch/replaceuser?access_token=" + GetAccessToken();
				string text4 = "{\"media_id\":\"" + text3 + "\"}";
				string str = HttpHelper.SendPost(url, text4);
				Log.Add("调用了微信同步所有人员", "返回：" + str, Log.Types.微信企业号, text4);
			}
		}

		public static bool CheckLogin()
		{
			if (CurrentUserID.IsEmptyGuid())
			{
				if (Config.IsUse)
				{
					HttpContext.Current.Response.Cookies.Add(new HttpCookie("LastURL", HttpContext.Current.Request.Url.PathAndQuery));
					string url = "https://open.weixin.qq.com/connect/oauth2/authorize?appid=" + Config.CorpID + "&redirect_uri=" + Config.GetAccountUrl + "&response_type=code&scope=snsapi_base&state=a#wechat_redirect";
					HttpContext.Current.Response.Redirect(url);
				}
				return false;
			}
			return true;
		}

		public string GetUserAccountByCode(string code)
		{
			if (Config.OrganizeSecret.IsNullOrEmpty())
			{
				List<RoadFlow.Data.Model.Dictionary> childs = new Dictionary().GetChilds("weixinagents");
				if (childs.Count == 0)
				{
					return "";
				}
				secret = (from p in childs
				orderby p.Sort
				select p).First().Note.Trim1();
			}
			else
			{
				secret = Config.OrganizeSecret;
			}
			string text = "https://qyapi.weixin.qq.com/cgi-bin/user/getuserinfo?access_token=" + GetAccessToken() + "&code=" + code;
			string text2 = HttpHelper.SendGet(text);
			JsonData jsonData = JsonMapper.ToObject(text2);
			string result = jsonData.ContainsKey("UserId") ? jsonData["UserId"].ToString() : "";
			Log.Add("调用了微信获取人员帐号", text, Log.Types.微信企业号, text2);
			return result;
		}
	}
}
