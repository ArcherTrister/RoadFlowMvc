// Decompiled with JetBrains decompiler
// Type: WebMvc.Areas.WeiXin.Controllers.CommonController
// Assembly: WebMvc, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 43FD7615-6DC3-49FB-B263-7F7CC91AFA77
// Assembly location: C:\inetpub\wwwroot\RoadFlowMvc\bin\WebMvc.dll

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
      return (ActionResult) this.View();
    }

    public void ReceiveMessage()
    {
      if (this.Request.HttpMethod.ToUpper() == "GET")
      {
        this.Auth();
      }
      else
      {
        if (!(this.Request.HttpMethod.ToUpper() == "POST"))
          return;
        string str1 = this.Request.QueryString["msg_signature"];
        string str2 = this.Request.QueryString["timestamp"];
        string str3 = this.Request.QueryString["nonce"];
        WXBizMsgCrypt wxBizMsgCrypt = new WXBizMsgCrypt(this.token, this.encodingAESKey, this.corpId);
        Stream inputStream = HttpContext.Current.Request.InputStream;
        byte[] numArray = new byte[inputStream.Length];
        inputStream.Read(numArray, 0, (int) inputStream.Length);
        string contents = Encoding.UTF8.GetString(numArray);
        string xml = "";
        string sMsgSignature = str1;
        string sTimeStamp = str2;
        string sNonce = str3;
        string sPostData = contents;
        ref string local = ref xml;
        if (wxBizMsgCrypt.DecryptMsg(sMsgSignature, sTimeStamp, sNonce, sPostData, ref local) == 0)
          new Message().Receive(xml);
        else
          RoadFlow.Platform.Log.Add("消息解密失败", contents, RoadFlow.Platform.Log.Types.微信企业号, "", "", (RoadFlow.Data.Model.Users) null);
      }
    }

    private void Auth()
    {
      string echostr = this.Request.QueryString["echoStr"];
      string signature = this.Request.QueryString["msg_signature"];
      string timestamp = this.Request.QueryString["timestamp"];
      string nonce = this.Request.QueryString["nonce"];
      string retEchostr = "";
      if (!this.CheckSignature(this.token, signature, timestamp, nonce, this.corpId, this.encodingAESKey, echostr, ref retEchostr) || string.IsNullOrEmpty(retEchostr))
        return;
      this.Response.Write(retEchostr);
      this.Response.End();
    }

    public bool CheckSignature(string token, string signature, string timestamp, string nonce, string corpId, string encodingAESKey, string echostr, ref string retEchostr)
    {
      return new WXBizMsgCrypt(token, encodingAESKey, corpId).VerifyURL(signature, timestamp, nonce, echostr, ref retEchostr) == 0;
    }

    public void GetUserAccount()
    {
      string str1 = this.Request.QueryString["code"];
      if (str1.IsNullOrEmpty())
      {
        this.Response.Write("身份验证失败");
        this.Response.End();
      }
      else
      {
        string userAccountByCode = new RoadFlow.Platform.WeiXin.Organize().GetUserAccountByCode(str1);
        if (userAccountByCode.IsNullOrEmpty())
        {
          this.Response.Write("身份验证失败");
          this.Response.End();
        }
        else
        {
          RoadFlow.Data.Model.Users byAccount = new RoadFlow.Platform.Users().GetByAccount(userAccountByCode);
          if (byAccount == null)
          {
            this.Response.Write("未找到帐号对应的人员");
            this.Response.End();
          }
          else
          {
            HttpContext.Current.Response.Cookies.Add(new HttpCookie("weixin_userid", byAccount.ID.ToString())
            {
              Expires = DateTimeNew.Now.AddYears(10)
            });
            HttpContext.Current.Session.Add(Keys.SessionKeys.UserID.ToString(), (object) byAccount.ID.ToString());
            HttpCookie httpCookie = this.Request.Cookies.Get("LastURL");
            string str2 = httpCookie == null ? "" : httpCookie.Value;
            if (str2.IsNullOrEmpty())
              return;
            this.Response.Redirect(str2);
          }
        }
      }
    }
  }
}
