using RoadFlow.Data.Model;
using RoadFlow.Platform;
using RoadFlow.Platform.WeiXin;
using RoadFlow.Utility;
using System.IO;
using System.Text;
using System.Web;
using System.Web.Mvc;

namespace WebMvc.Areas.WeiXin.Controllers
{
	public class CommonController : Controller
	{
		private string token = "iTak7rMl7ItStvRFbDqA6wDdTeDOOoqX";

		private string encodingAESKey = "J6B1ZF1bAx77hVYHhd6aNs6Yyha2BsNxtZq1dprOX2v";

		private string corpId = RoadFlow.Platform.WeiXin.Config.CorpID;

		public ActionResult Index()
		{
			return View();
		}

		public void ReceiveMessage()
		{
			if (base.Request.HttpMethod.ToUpper() == "GET")
			{
				Auth();
			}
			else if (base.Request.HttpMethod.ToUpper() == "POST")
			{
				string sMsgSignature = base.Request.QueryString["msg_signature"];
				string sTimeStamp = base.Request.QueryString["timestamp"];
				string sNonce = base.Request.QueryString["nonce"];
				WXBizMsgCrypt wXBizMsgCrypt = new WXBizMsgCrypt(token, encodingAESKey, corpId);
				Stream inputStream = System.Web.HttpContext.Current.Request.InputStream;
				byte[] array = new byte[inputStream.Length];
				inputStream.Read(array, 0, (int)inputStream.Length);
				string @string = Encoding.UTF8.GetString(array);
				string sMsg = "";
				if (wXBizMsgCrypt.DecryptMsg(sMsgSignature, sTimeStamp, sNonce, @string, ref sMsg) == 0)
				{
					new Message().Receive(sMsg);
				}
				else
				{
					RoadFlow.Platform.Log.Add("消息解密失败", @string, RoadFlow.Platform.Log.Types.微信企业号);
				}
			}
		}

		private void Auth()
		{
			string echostr = base.Request.QueryString["echoStr"];
			string signature = base.Request.QueryString["msg_signature"];
			string timestamp = base.Request.QueryString["timestamp"];
			string nonce = base.Request.QueryString["nonce"];
			string retEchostr = "";
			if (CheckSignature(token, signature, timestamp, nonce, corpId, encodingAESKey, echostr, ref retEchostr) && !string.IsNullOrEmpty(retEchostr))
			{
				base.Response.Write(retEchostr);
				base.Response.End();
			}
		}

		public bool CheckSignature(string token, string signature, string timestamp, string nonce, string corpId, string encodingAESKey, string echostr, ref string retEchostr)
		{
			if (new WXBizMsgCrypt(token, encodingAESKey, corpId).VerifyURL(signature, timestamp, nonce, echostr, ref retEchostr) != 0)
			{
				return false;
			}
			return true;
		}

		public void GetUserAccount()
		{
			string text = base.Request.QueryString["code"];
			if (text.IsNullOrEmpty())
			{
				base.Response.Write("身份验证失败");
				base.Response.End();
			}
			else
			{
				string userAccountByCode = new RoadFlow.Platform.WeiXin.Organize().GetUserAccountByCode(text);
				if (userAccountByCode.IsNullOrEmpty())
				{
					base.Response.Write("身份验证失败");
					base.Response.End();
				}
				else
				{
					RoadFlow.Data.Model.Users byAccount = new RoadFlow.Platform.Users().GetByAccount(userAccountByCode);
					if (byAccount == null)
					{
						base.Response.Write("未找到帐号对应的人员");
						base.Response.End();
					}
					else
					{
						System.Web.HttpContext.Current.Response.Cookies.Add(new HttpCookie("weixin_userid", byAccount.ID.ToString())
						{
							Expires = DateTimeNew.Now.AddYears(10)
						});
						System.Web.HttpContext.Current.Session.Add(0.ToString(), byAccount.ID.ToString());
						HttpCookie httpCookie = base.Request.Cookies.Get("LastURL");
						string text2 = (httpCookie == null) ? "" : httpCookie.Value;
						if (!text2.IsNullOrEmpty())
						{
							base.Response.Redirect(text2);
						}
					}
				}
			}
		}
	}
}
