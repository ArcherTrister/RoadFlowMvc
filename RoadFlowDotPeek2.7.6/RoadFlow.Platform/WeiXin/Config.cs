// Decompiled with JetBrains decompiler
// Type: RoadFlow.Platform.WeiXin.Config
// Assembly: RoadFlow.Platform, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 07F26AFD-DE3B-4003-89AF-01A62494BA58
// Assembly location: C:\inetpub\wwwroot\RoadFlowMvc\bin\RoadFlow.Platform.dll

using LitJson;
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
        string appSetting = ConfigurationManager.AppSettings[nameof (WebUrl)];
        if (!appSetting.EndsWith("/"))
          return appSetting + "/";
        return appSetting;
      }
    }

    public static string GetAccessToken(string secret)
    {
      if (secret.IsNullOrEmpty())
        secret = Config.OrganizeSecret;
      if (secret.IsNullOrEmpty())
        return "";
      JsonData jsonData = JsonMapper.ToObject(HttpHelper.SendGet(string.Format("https://qyapi.weixin.qq.com/cgi-bin/gettoken?corpid={0}&corpsecret={1}", (object) Config.CorpID, (object) secret)));
      if (jsonData.ContainsKey("access_token"))
        return jsonData["access_token"].ToString();
      return "";
    }

    public static string GetAccountUrl
    {
      get
      {
        if (HttpContext.Current.Request.Url.AbsolutePath.Contains(".aspx", StringComparison.CurrentCultureIgnoreCase))
          return (Config.WebUrl + "Applications/WeiXin/GetUserAccount.ashx").UrlEncode();
        return (Config.WebUrl + "WeiXin/Common/GetUserAccount").UrlEncode();
      }
    }

    public static string GetSecret(string code)
    {
      RoadFlow.Data.Model.Dictionary byCode = new RoadFlow.Platform.Dictionary().GetByCode(code, true);
      if (byCode != null)
        return byCode.Note.Trim1();
      return "";
    }

    public static string GetSecret(int agentId)
    {
      RoadFlow.Data.Model.Dictionary dictionary = new RoadFlow.Platform.Dictionary().GetChilds("weixinagents", true).Find((Predicate<RoadFlow.Data.Model.Dictionary>) (p => p.Value.ToInt(-1) == agentId));
      if (dictionary != null)
        return dictionary.Note.Trim1();
      return "";
    }
  }
}
