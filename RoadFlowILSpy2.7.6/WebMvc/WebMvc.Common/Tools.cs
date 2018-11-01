using LitJson;
using RoadFlow.Data.Model;
using RoadFlow.Platform;
using RoadFlow.Utility;
using System;
using System.Collections.Generic;
using System.Timers;
using System.Web;
using System.Web.Routing;

namespace WebMvc.Common
{
	public class Tools
	{
		public static string IncludeFiles
		{
			get
			{
				return string.Format("<link href=\"{0}Content/Theme/Common.css\" rel=\"stylesheet\" type=\"text/css\" media=\"screen\"/>\r\n    <link href=\"{0}Content/Theme/{1}/Style/style.css\" id=\"style_style\" rel=\"stylesheet\" type=\"text/css\" media=\"screen\"/>\r\n    <link href=\"{0}Content/Theme/{1}/Style/ui.css\" id=\"style_ui\" rel=\"stylesheet\" type=\"text/css\" media=\"screen\"/> \r\n    <link href=\"{0}Content/Theme/{1}/jqgrid/ui.jqgrid.css\" id=\"style_style\" rel=\"stylesheet\" type=\"text/css\" media=\"screen\"/>\r\n    <link href=\"{0}Content/Theme/{1}/jqgrid/jquery-ui.css\" id=\"style_ui\" rel=\"stylesheet\" type=\"text/css\" media=\"screen\"/> \r\n    <link href=\"{0}Scripts/font-awesome/css/font-awesome.min.css\" rel=\"stylesheet\" />\r\n    <script type=\"text/javascript\" src=\"{0}Scripts/My97DatePicker/WdatePicker.js\"></script>\r\n    <script type=\"text/javascript\" src=\"{0}Scripts/jquery-1.12.4.min.js\"></script>\r\n    <script type=\"text/javascript\" src=\"{0}Scripts/jquery.cookie.js\"></script>\r\n    <script type=\"text/javascript\" src=\"{0}Scripts/json.js\"></script>\r\n    <script type=\"text/javascript\" src=\"{0}Scripts/roadui.core.js\"></script>\r\n    <script type=\"text/javascript\" src=\"{0}Scripts/roadui.button.js\"></script>\r\n    <script type=\"text/javascript\" src=\"{0}Scripts/roadui.calendar.js\"></script>\r\n    <script type=\"text/javascript\" src=\"{0}Scripts/roadui.file.js\"></script>\r\n    <script type=\"text/javascript\" src=\"{0}Scripts/roadui.member.js\"></script>\r\n    <script type=\"text/javascript\" src=\"{0}Scripts/roadui.dict.js\"></script>\r\n    <script type=\"text/javascript\" src=\"{0}Scripts/roadui.menu.js\"></script>\r\n    <script type=\"text/javascript\" src=\"{0}Scripts/roadui.select.js\"></script>\r\n    <script type=\"text/javascript\" src=\"{0}Scripts/roadui.combox.js\"></script>\r\n    <script type=\"text/javascript\" src=\"{0}Scripts/roadui.tab.js\"></script>\r\n    <script type=\"text/javascript\" src=\"{0}Scripts/roadui.text.js\"></script>\r\n    <script type=\"text/javascript\" src=\"{0}Scripts/roadui.textarea.js\"></script>\r\n    <script type=\"text/javascript\" src=\"{0}Scripts/roadui.editor.js\"></script>\r\n    <script type=\"text/javascript\" src=\"{0}Scripts/roadui.tree.js\"></script>\r\n    <script type=\"text/javascript\" src=\"{0}Scripts/roadui.validate.js\"></script>\r\n    <script type=\"text/javascript\" src=\"{0}Scripts/roadui.window.js\"></script>\r\n    <script type=\"text/javascript\" src=\"{0}Scripts/roadui.dragsort.js\"></script>\r\n    <script type=\"text/javascript\" src=\"{0}Scripts/roadui.selectico.js\"></script>\r\n    <script type=\"text/javascript\" src=\"{0}Scripts/roadui.selectdiv.js\"></script>\r\n    <script type=\"text/javascript\" src=\"{0}Scripts/roadui.accordion.js\"></script>\r\n    <script type=\"text/javascript\" src=\"{0}Scripts/roadui.grid.js\"></script>\r\n    <script type=\"text/javascript\" src=\"{0}Scripts/roadui.init.js\"></script>\r\n    <script type=\"text/javascript\" src=\"{0}Scripts/jqGrid/grid.locale-cn.js\"></script>\r\n    <script type=\"text/javascript\" src=\"{0}Scripts/jqGrid/jquery.jqGrid.min.js\"></script>\r\n    <script type=\"text/javascript\" src=\"{0}Scripts/jqGrid/jquery-ui.min.js\"></script>\r\n    <link href=\"{0}Scripts/select2/select2.css\" rel=\"stylesheet\" />\r\n    <script src=\"{0}Scripts/select2/select2.full.js\"></script>", BaseUrl + "/", RoadFlow.Utility.Config.Theme);
			}
		}

		public static string BaseUrl
		{
			get
			{
				return RoadFlow.Utility.Config.BaseUrl;
			}
		}

		public static bool CheckLogin(out string msg)
		{
			msg = "";
			bool result = true;
			object obj = HttpContext.Current.Session[0.ToString()];
			Guid test;
			if (obj == null || !obj.ToString().IsGuid(out test) || test == Guid.Empty)
			{
				result = false;
			}
			return result;
		}

		public static bool CheckLogin(bool redirect = true)
		{
			string msg;
			if (!CheckLogin(out msg))
			{
				if (!redirect)
				{
					HttpContext.Current.Response.Write("登录验证失败!");
					HttpContext.Current.Response.End();
					return false;
				}
				if (!RoadFlow.Utility.Tools.IsPhoneAccess())
				{
					string pathAndQuery = HttpContext.Current.Request.Url.PathAndQuery;
					HttpContext.Current.Response.Write("<script>top.lastURL='" + pathAndQuery + "';top.currentWindow=window;top.login();</script>");
					HttpContext.Current.Response.End();
				}
				return false;
			}
			return true;
		}

		public static bool CheckReferrer(bool isEnd = true)
		{
			Uri urlReferrer = HttpContext.Current.Request.UrlReferrer;
			if (!(urlReferrer == null))
			{
				bool num = HttpContext.Current.Request.Url.Host.Equals(urlReferrer.Host, StringComparison.CurrentCultureIgnoreCase);
				if (!num && isEnd)
				{
					HttpContext.Current.Response.Clear();
					HttpContext.Current.Response.Write("访问地址错误!");
					HttpContext.Current.Response.End();
				}
				return num;
			}
			if (isEnd)
			{
				HttpContext.Current.Response.Clear();
				HttpContext.Current.Response.Write("访问地址错误!");
				HttpContext.Current.Response.End();
			}
			return false;
		}

		public static bool CheckApp(out string msg, string appid = "")
		{
			msg = "";
			Guid userID = RoadFlow.Platform.Users.CurrentUserID;
			if (userID.IsEmptyGuid())
			{
				msg = "<script>top.login();</script>";
				return false;
			}
			appid = (appid.IsNullOrEmpty() ? HttpContext.Current.Request["appid"] : appid);
			Guid appGuid;
			if (!appid.IsGuid(out appGuid))
			{
				return false;
			}
			List<RoadFlow.Data.Model.MenuUser> all = new RoadFlow.Platform.MenuUser().GetAll();
			string source;
			string @params;
			bool flag = new RoadFlow.Platform.Menu().HasUse(appGuid, userID, all, out source, out @params);
			if (!flag)
			{
				return false;
			}
			string url = HttpContext.Current.Request.ServerVariables["SCRIPT_NAME"].ToString();
			if (!url.IsNullOrEmpty())
			{
				url = url.TrimStart('/');
				if (!url.IsNullOrEmpty())
				{
					List<RoadFlow.Data.Model.AppLibrarySubPages> list = new RoadFlow.Platform.AppLibrarySubPages().GetAll().FindAll((RoadFlow.Data.Model.AppLibrarySubPages p) => p.Address.Contains(url, StringComparison.CurrentCultureIgnoreCase));
					if (list.Count > 0)
					{
						foreach (RoadFlow.Data.Model.AppLibrarySubPages item in list)
						{
							if (all.Find(delegate(RoadFlow.Data.Model.MenuUser p)
							{
								if (p.MenuID == appGuid && p.SubPageID == item.ID)
								{
									return p.Users.Contains(userID.ToString(), StringComparison.CurrentCultureIgnoreCase);
								}
								return false;
							}) != null)
							{
								return true;
							}
						}
						return false;
					}
				}
			}
			return flag;
		}

		public static RouteValueDictionary GetRouteValueDictionary()
		{
			Dictionary<string, object> dictionary = new Dictionary<string, object>();
			string query = HttpContext.Current.Request.Url.Query;
			if (query.IsNullOrEmpty())
			{
				return new RouteValueDictionary(dictionary);
			}
			string[] array = query.TrimStart('?').Split('&');
			for (int i = 0; i < array.Length; i++)
			{
				string[] array2 = array[i].Split('=');
				if (array2.Length >= 2)
				{
					dictionary.Add(array2[0], array2[1]);
				}
			}
			return new RouteValueDictionary(dictionary);
		}

		public static string SerializeObject(object obj)
		{
			return JsonMapper.ToJson(obj);
		}

		public static string GetAppButtonHtml(int showType, string appid = "", string subpageid = "")
		{
			if (appid.IsNullOrEmpty())
			{
				appid = HttpContext.Current.Request.QueryString["appid"];
			}
			return RoadFlow.Platform.MenuUser.getButtonsHtml(appid, subpageid)[showType];
		}

		public static Dictionary<int, string> GetAppButtonHtml(string appid = "", string subpageid = "")
		{
			if (appid.IsNullOrEmpty())
			{
				appid = HttpContext.Current.Request.QueryString["appid"];
			}
			return RoadFlow.Platform.MenuUser.getButtonsHtml(appid, subpageid, HttpContext.Current.Request.QueryString["programid"]);
		}

		public static void ExpiredAutoSubmit(object source, ElapsedEventArgs e)
		{
			new RoadFlow.Platform.WorkFlowTask().ExpiredAutoSubmit();
		}
	}
}
