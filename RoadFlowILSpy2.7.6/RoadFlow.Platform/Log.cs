using RoadFlow.Data.Factory;
using RoadFlow.Data.Interface;
using RoadFlow.Data.Model;
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
			其它分类
		}

		private ILog dataLog;

		private static ILog dataLog1 = Factory.GetLog();

		public Log()
		{
			dataLog = dataLog1;
		}

		public int Update(RoadFlow.Data.Model.Log model)
		{
			return dataLog.Update(model);
		}

		public List<RoadFlow.Data.Model.Log> GetAll()
		{
			return dataLog.GetAll();
		}

		public RoadFlow.Data.Model.Log Get(Guid id)
		{
			return dataLog.Get(id);
		}

		public int Delete(Guid id)
		{
			return dataLog.Delete(id);
		}

		public long GetCount()
		{
			return dataLog.GetCount();
		}

		private static void add(RoadFlow.Data.Model.Log model)
		{
			dataLog1.Add(model);
		}

		public static void Add(RoadFlow.Data.Model.Log model)
		{
			new dgWriteLog(add).BeginInvoke(model, null, null);
		}

		public static void Add(string title, string contents, Types type = Types.其它分类, string oldXML = "", string newXML = "", RoadFlow.Data.Model.Users user = null)
		{
			RoadFlow.Data.Model.Log log = new RoadFlow.Data.Model.Log();
			log.Contents = contents;
			log.ID = Guid.NewGuid();
			log.Title = title;
			log.OldXml = (oldXML.IsNullOrEmpty() ? null : oldXML);
			log.NewXml = (newXML.IsNullOrEmpty() ? null : newXML);
			log.Type = type.ToString();
			try
			{
				if (user == null)
				{
					user = Users.CurrentUser;
				}
				if (user != null)
				{
					log.UserID = user.ID;
					log.UserName = user.Name;
				}
				log.IPAddress = Tools.GetIPAddress();
				log.Others = string.Format("操作系统：{0} 浏览器：{1}", Tools.GetOSName(), Tools.GetBrowse());
				log.URL = HttpContext.Current.Request.Url.ToString();
			}
			catch
			{
			}
			log.WriteTime = DateTimeNew.Now;
			Add(log);
		}

		public static void Add(Exception err)
		{
			Add(err.Message, err.Source + err.StackTrace, Types.系统错误);
		}

		public string GetTypeOptions(string value = "")
		{
			StringBuilder stringBuilder = new StringBuilder();
			foreach (object value2 in Enum.GetValues(typeof(Types)))
			{
				stringBuilder.AppendFormat("<option value=\"{0}\" {1}>{0}</option>", value2, (value2.ToString() == value) ? "selected=\"selected\"" : "");
			}
			return stringBuilder.ToString();
		}

		public DataTable GetPagerData(out string pager, string query = "", string title = "", string type = "", string date1 = "", string date2 = "", string userID = "")
		{
			return dataLog.GetPagerData(out pager, query, Tools.GetPageSize(), Tools.GetPageNumber(), title, type, date1, date2, Users.RemovePrefix(userID));
		}

		public DataTable GetPagerData(out long count, int size = 15, int number = 1, string title = "", string type = "", string date1 = "", string date2 = "", string userID = "", string order = "")
		{
			return dataLog.GetPagerData(out count, size, number, title, type, date1, date2, Users.RemovePrefix(userID), order);
		}
	}
}
