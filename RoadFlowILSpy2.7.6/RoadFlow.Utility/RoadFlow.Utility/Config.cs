using System;
using System.Collections.Generic;
using System.Configuration;
using System.Web;

namespace RoadFlow.Utility
{
	public class Config
	{
		public static string PlatformConnectionStringMSSQL
		{
			get
			{
				return ConfigurationManager.ConnectionStrings["PlatformConnection"].ConnectionString;
			}
		}

		public static string PlatformConnectionStringORACLE
		{
			get
			{
				return ConfigurationManager.ConnectionStrings["PlatformConnectionOracle"].ConnectionString;
			}
		}

		public static string PlatformConnectionStringMySql
		{
			get
			{
				return ConfigurationManager.ConnectionStrings["PlatformConnectionMySql"].ConnectionString;
			}
		}

		public static string DataBaseType
		{
			get
			{
				string text = ConfigurationManager.AppSettings["DatabaseType"];
				if (!text.IsNullOrEmpty())
				{
					return text.ToUpper();
				}
				return "MSSQL";
			}
		}

		public static string SystemInitPassword
		{
			get
			{
				string text = ConfigurationManager.AppSettings["InitPassword"];
				if (!text.IsNullOrEmpty())
				{
					return text.Trim();
				}
				return "111";
			}
		}

		public static string FilePath
		{
			get
			{
				string text = ConfigurationManager.AppSettings["FilePath"];
				if (!text.IsNullOrEmpty())
				{
					if (!text.EndsWith("\\"))
					{
						return text + "\\";
					}
					return text;
				}
				return "d:\\RoadFlowFiles\\";
			}
		}

		public static string Theme
		{
			get
			{
				HttpCookie httpCookie = HttpContext.Current.Request.Cookies["theme_platform"];
				if (httpCookie == null || httpCookie.Value.IsNullOrEmpty())
				{
					return "Blue";
				}
				return httpCookie.Value;
			}
		}

		public static string UploadFileType
		{
			get
			{
				return ConfigurationManager.AppSettings["UploadFileType"];
			}
		}

		public static bool IsDemo
		{
			get
			{
				return "1".Equals(ConfigurationManager.AppSettings["IsDemo"]);
			}
		}

		public static string DateFormat
		{
			get
			{
				return "yyyy-MM-dd";
			}
		}

		public static string DateTimeFormat
		{
			get
			{
				return "yyyy-MM-dd HH:mm";
			}
		}

		public static string DateTimeFormatS
		{
			get
			{
				return "yyyy-MM-dd HH:mm:ss";
			}
		}

		public static List<string> SystemDataTables
		{
			get
			{
				List<string> list = new List<string>();
				string text = ConfigurationManager.AppSettings["SystemTables"];
				if (text.IsNullOrEmpty())
				{
					return list;
				}
				string[] array = text.Split(',');
				foreach (string text2 in array)
				{
					if (!text2.IsNullOrEmpty())
					{
						list.Add(text2);
					}
				}
				return list;
			}
		}

		public static string BaseUrl
		{
			get
			{
				string appDomainAppVirtualPath = HttpRuntime.AppDomainAppVirtualPath;
				if (!(appDomainAppVirtualPath == "/"))
				{
					return appDomainAppVirtualPath;
				}
				return "";
			}
		}

		public static string GetTokenByUserId(Guid userID)
		{
			Guid guid = Guid.NewGuid();
			return (userID.ToString() + "|" + guid.ToString()).DesEncrypt();
		}

		public static Guid? GetUserIdByToken(string token)
		{
			if (token.IsNullOrEmpty())
			{
				return null;
			}
			string text = token.DesDecrypt();
			if (text.IsNullOrEmpty())
			{
				return null;
			}
			string[] array = text.Split('|');
			if (array == null || array.Length != 2)
			{
				return null;
			}
			string str = array[0];
			if (!str.IsGuid())
			{
				return null;
			}
			return str.ToGuid();
		}
	}
}
