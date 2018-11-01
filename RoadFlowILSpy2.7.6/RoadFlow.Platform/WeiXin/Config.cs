using LitJson;
using RoadFlow.Data.Model;
using RoadFlow.Utility;
using System;
using System.Configuration;
using System.Web;

namespace RoadFlow.Platform.WeiXin
{
	public class Config
	{
		public static bool IsUse
		{
			get
			{
				return "1" == ConfigurationManager.AppSettings["wxqy_IsUse"];
			}
		}

		public static string CorpID
		{
			get
			{
				return ConfigurationManager.AppSettings["wxqy_CorpID"];
			}
		}

		public static string OrganizeSecret
		{
			get
			{
				return ConfigurationManager.AppSettings["wxqy_Secret"];
			}
		}

		public static string WebUrl
		{
			get
			{
				string text = ConfigurationManager.AppSettings["WebUrl"];
				if (!text.EndsWith("/"))
				{
					return text + "/";
				}
				return text;
			}
		}

		public static string GetAccountUrl
		{
			get
			{
				if (HttpContext.Current.Request.Url.AbsolutePath.Contains(".aspx", StringComparison.CurrentCultureIgnoreCase))
				{
					return (WebUrl + "Applications/WeiXin/GetUserAccount.ashx").UrlEncode();
				}
				return (WebUrl + "WeiXin/Common/GetUserAccount").UrlEncode();
			}
		}

		public static string GetAccessToken(string secret)
		{
			if (secret.IsNullOrEmpty())
			{
				secret = OrganizeSecret;
			}
			if (secret.IsNullOrEmpty())
			{
				return "";
			}
			JsonData jsonData = JsonMapper.ToObject(HttpHelper.SendGet(string.Format("https://qyapi.weixin.qq.com/cgi-bin/gettoken?corpid={0}&corpsecret={1}", CorpID, secret)));
			if (jsonData.ContainsKey("access_token"))
			{
				return jsonData["access_token"].ToString();
			}
			return "";
		}

		public static string GetSecret(string code)
		{
			RoadFlow.Data.Model.Dictionary byCode = new Dictionary().GetByCode(code, true);
			if (byCode != null)
			{
				return byCode.Note.Trim1();
			}
			return "";
		}

		public static string GetSecret(int agentId)
		{
			RoadFlow.Data.Model.Dictionary dictionary = new Dictionary().GetChilds("weixinagents", true).Find((RoadFlow.Data.Model.Dictionary p) => p.Value.ToInt(-1) == agentId);
			if (dictionary != null)
			{
				return dictionary.Note.Trim1();
			}
			return "";
		}
	}
}
