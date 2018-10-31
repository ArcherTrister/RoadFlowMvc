// Decompiled with JetBrains decompiler
// Type: RoadFlow.Platform.WeiXin.Media
// Assembly: RoadFlow.Platform, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 07F26AFD-DE3B-4003-89AF-01A62494BA58
// Assembly location: C:\inetpub\wwwroot\RoadFlowMvc\bin\RoadFlow.Platform.dll

using LitJson;
using RoadFlow.Utility;
using System.IO;
using System.Web;

namespace RoadFlow.Platform.WeiXin
{
  public class Media
  {
    private string secret = string.Empty;

    public Media()
    {
      this.secret = Config.OrganizeSecret;
    }

    public Media(int agentId)
    {
      this.secret = Config.GetSecret(agentId);
    }

    public Media(string secret)
    {
      this.secret = secret;
    }

    private string GetAccessToken()
    {
      return Config.GetAccessToken(this.secret);
    }

    public string UploadTemp(string file, string type)
    {
      string str1 = "https://qyapi.weixin.qq.com/cgi-bin/media/upload?access_token=" + this.GetAccessToken() + "&type=" + type;
      FileStream fileStream = new FileStream(file, FileMode.Open);
      byte[] numArray = new byte[fileStream.Length];
      fileStream.Read(numArray, 0, numArray.Length);
      fileStream.Close();
      string json = HttpHelper.SendFile(str1, file, numArray);
      JsonData jsonData = JsonMapper.ToObject(json);
      if (jsonData.ContainsKey("media_id"))
      {
        string str2 = jsonData["media_id"].ToString();
        if (!str2.IsNullOrEmpty())
          return str2;
        RoadFlow.Platform.Log.Add("调用了微信上传临时素材错误-" + file, "返回：" + json, RoadFlow.Platform.Log.Types.微信企业号, str1, "", (RoadFlow.Data.Model.Users) null);
        return str2;
      }
      RoadFlow.Platform.Log.Add("调用了微信上传临时素材错误-" + file, "返回：" + json, RoadFlow.Platform.Log.Types.微信企业号, str1, "", (RoadFlow.Data.Model.Users) null);
      return "";
    }

    public string UploadTemp(HttpPostedFile postedFile, string type)
    {
      string str1 = "https://qyapi.weixin.qq.com/cgi-bin/media/upload?access_token=" + this.GetAccessToken() + "&type=" + type;
      string json = HttpHelper.SendFile(str1, postedFile);
      JsonData jsonData = JsonMapper.ToObject(json);
      if (jsonData.ContainsKey("media_id"))
      {
        string str2 = jsonData["media_id"].ToString();
        if (!str2.IsNullOrEmpty())
          return str2;
        RoadFlow.Platform.Log.Add("调用了微信上传临时素材错误-" + postedFile.FileName, "返回：" + json, RoadFlow.Platform.Log.Types.微信企业号, str1, "", (RoadFlow.Data.Model.Users) null);
        return str2;
      }
      RoadFlow.Platform.Log.Add("调用了微信上传临时素材错误-" + postedFile.FileName, "返回：" + json, RoadFlow.Platform.Log.Types.微信企业号, str1, "", (RoadFlow.Data.Model.Users) null);
      return "";
    }

    public string DownladTemp(string media_id, string savePath)
    {
      string str = "https://qyapi.weixin.qq.com/cgi-bin/media/get?access_token=" + this.GetAccessToken() + "&media_id=" + media_id;
      return "";
    }

    public string UploadFormal(string file, string type)
    {
      string str1 = "https://qyapi.weixin.qq.com/cgi-bin/material/add_material?access_token=" + this.GetAccessToken() + "&type=" + type;
      FileStream fileStream = new FileStream(file, FileMode.Open);
      byte[] numArray = new byte[fileStream.Length];
      fileStream.Read(numArray, 0, numArray.Length);
      fileStream.Close();
      string json = HttpHelper.SendFile(str1, file, numArray);
      JsonData jsonData = JsonMapper.ToObject(json);
      if (jsonData.ContainsKey("errcode") && "0" == jsonData["errcode"].ToString() && jsonData.ContainsKey("media_id"))
      {
        string str2 = jsonData["media_id"].ToString();
        if (!str2.IsNullOrEmpty())
          return str2;
        RoadFlow.Platform.Log.Add("调用了微信上传永久素材错误-" + file, "返回：" + json, RoadFlow.Platform.Log.Types.微信企业号, str1, "", (RoadFlow.Data.Model.Users) null);
        return str2;
      }
      RoadFlow.Platform.Log.Add("调用了微信上传永久素材错误-" + file, "返回：" + json, RoadFlow.Platform.Log.Types.微信企业号, str1, "", (RoadFlow.Data.Model.Users) null);
      return "";
    }

    public string UploadMPNews(string title, string thumb_media_id, string content, string author = "", string content_source_url = "", string digest = "", int show_cover_pic = 0, string edit_media_id = "")
    {
      string empty = string.Empty;
      if (File.Exists(thumb_media_id))
      {
        thumb_media_id = this.UploadFormal(thumb_media_id, "image");
        if (thumb_media_id.IsNullOrEmpty())
          return empty;
      }
      int num = !edit_media_id.IsNullOrEmpty() ? 1 : 0;
      string url = num != 0 ? "https://qyapi.weixin.qq.com/cgi-bin/material/update_mpnews?access_token=" + this.GetAccessToken() : "https://qyapi.weixin.qq.com/cgi-bin/material/add_mpnews?access_token=" + this.GetAccessToken();
      JsonData jsonData1 = new JsonData();
      JsonData jsonData2 = new JsonData();
      JsonData jsonData3 = new JsonData();
      JsonData jsonData4 = new JsonData();
      if (num != 0)
        jsonData1["media_id"] = (JsonData) edit_media_id;
      jsonData4[nameof (title)] = (JsonData) title;
      jsonData4[nameof (thumb_media_id)] = (JsonData) thumb_media_id;
      jsonData4[nameof (content_source_url)] = (JsonData) content_source_url;
      jsonData4[nameof (content)] = (JsonData) content;
      jsonData4[nameof (digest)] = (JsonData) digest;
      jsonData4[nameof (show_cover_pic)] = (JsonData) show_cover_pic;
      jsonData3.Add((object) jsonData4);
      jsonData2["articles"] = jsonData3;
      jsonData1["mpnews"] = jsonData2;
      //string json1 = jsonData1.ToJson(true);
            string json1 = jsonData1.ToJson();
            string json2 = HttpHelper.SendPost(url, json1);
      JsonData jsonData5 = JsonMapper.ToObject(json2);
      if (jsonData5.ContainsKey("errcode") && "0" == jsonData5["errcode"].ToString() && jsonData5.ContainsKey("media_id"))
      {
        empty = jsonData5["media_id"].ToString();
        RoadFlow.Platform.Log.Add("调用了微信上传永久图文素材-" + title, "返回：" + json2, RoadFlow.Platform.Log.Types.微信企业号, json1, "", (RoadFlow.Data.Model.Users) null);
      }
      else
        RoadFlow.Platform.Log.Add("调用了微信上传永久图文素材错误-" + title, "返回：" + json2, RoadFlow.Platform.Log.Types.微信企业号, json1, "", (RoadFlow.Data.Model.Users) null);
      return empty;
    }

    public bool DeleteMPNews(string media_id)
    {
      string json = HttpHelper.SendGet("https://qyapi.weixin.qq.com/cgi-bin/material/del?access_token=" + this.GetAccessToken() + "&media_id=" + media_id);
      JsonData jsonData = JsonMapper.ToObject(json);
      RoadFlow.Platform.Log.Add("调用了微信删除永久图文素材-" + media_id, "返回：" + json, RoadFlow.Platform.Log.Types.微信企业号, "", "", (RoadFlow.Data.Model.Users) null);
      return jsonData.ContainsKey("errcode") && "0" == jsonData["errcode"].ToString();
    }

    public string UploadImg(string file)
    {
      string str = "https://qyapi.weixin.qq.com/cgi-bin/media/uploadimg?access_token=" + this.GetAccessToken();
      FileStream fileStream = new FileStream(file, FileMode.Open);
      byte[] numArray = new byte[fileStream.Length];
      fileStream.Read(numArray, 0, numArray.Length);
      fileStream.Close();
      string json = HttpHelper.SendFile(str, file, numArray);
      JsonData jsonData = JsonMapper.ToObject(json);
      if (jsonData.ContainsKey("url"))
        return jsonData["url"].ToString();
      RoadFlow.Platform.Log.Add("调用了微信上传图文消息内的图片错误-" + file, "返回：" + json, RoadFlow.Platform.Log.Types.微信企业号, str, "", (RoadFlow.Data.Model.Users) null);
      return "";
    }

    public string Download(string media_id)
    {
      string str1 = "https://qyapi.weixin.qq.com/cgi-bin/material/get?access_token=" + this.GetAccessToken() + "&media_id=" + media_id;
      string str2 = HttpHelper.DownloadFile(str1, "D:\\sdfsdf.mp4");
      RoadFlow.Platform.Log.Add("调用了微信下载素材", "返回：" + str2, RoadFlow.Platform.Log.Types.微信企业号, str1, "", (RoadFlow.Data.Model.Users) null);
      return str2;
    }
  }
}
