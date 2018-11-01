// Decompiled with JetBrains decompiler
// Type: RoadFlow.Platform.WeiXin.Message
// Assembly: RoadFlow.Platform, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 07F26AFD-DE3B-4003-89AF-01A62494BA58
// Assembly location: C:\inetpub\wwwroot\RoadFlowMvc\bin\RoadFlow.Platform.dll

using LitJson;
using RoadFlow.Utility;
using System;
using System.Collections.Generic;
using System.IO;
using System.Xml.Linq;

namespace RoadFlow.Platform.WeiXin
{
  public class Message
  {
    private string secret = string.Empty;
    private int agentId = -1;

    public Message()
    {
      this.secret = Config.OrganizeSecret;
    }

    public Message(int agentId)
    {
      this.secret = Config.GetSecret(agentId);
    }

    public Message(string agentCode)
    {
      this.secret = Config.GetSecret(agentCode);
    }

    private string GetAccessToken()
    {
      return Config.GetAccessToken(this.secret);
    }

    private string send(string data)
    {
      if (this.agentId != -1 && this.secret.IsNullOrEmpty())
        this.secret = Config.GetSecret(this.agentId);
      string str = "https://qyapi.weixin.qq.com/cgi-bin/message/send?access_token=" + this.GetAccessToken();
      string json = HttpHelper.SendPost(str, data);
      JsonData jsonData = JsonMapper.ToObject(json);
      if (jsonData.ContainsKey("errcode") && "0" == jsonData["errcode"].ToString())
      {
        RoadFlow.Platform.Log.Add("调用了微信发送消息", "返回：" + json, RoadFlow.Platform.Log.Types.微信企业号, str, data, (RoadFlow.Data.Model.Users) null);
        return "";
      }
      RoadFlow.Platform.Log.Add("调用了微信发送消息错误", "返回：" + json, RoadFlow.Platform.Log.Types.微信企业号, str, data, (RoadFlow.Data.Model.Users) null);
      return json;
    }

    private void sendAsync(string data)
    {
      new Message.delegate_send(this.send).BeginInvoke(data, (AsyncCallback) null, (object) null);
    }

    public string SendText(string contents, string userids = "", string depts = "", string groups = "", int safe = 0, int agentid = 0, bool async = false)
    {
      JsonData jsonData = new JsonData();
      jsonData["touser"] = (JsonData) userids;
      jsonData["toparty"] = (JsonData) depts;
      jsonData["totag"] = (JsonData) groups;
      jsonData["msgtype"] = (JsonData) "text";
      jsonData[nameof (agentid)] = (JsonData) agentid;
      jsonData["text"] = new JsonData()
      {
        ["content"] = (JsonData) contents
      };
      jsonData[nameof (safe)] = (JsonData) safe;
      this.agentId = agentid;
      string json = jsonData.ToJson(false);
            if (!async)
        return this.send(json);
      this.sendAsync(json);
      return "";
    }

    public string SendImg(string media_idOrImgPath, string userids = "", string depts = "", string groups = "", int safe = 0, int agentid = 0, bool async = false)
    {
      string str = string.Empty;
      if (File.Exists(media_idOrImgPath))
        str = new Media(agentid).UploadFormal(media_idOrImgPath, "image");
      if (str.IsNullOrEmpty())
        return "上传图片错误";
      JsonData jsonData = new JsonData();
      jsonData["touser"] = (JsonData) userids;
      jsonData["toparty"] = (JsonData) depts;
      jsonData["totag"] = (JsonData) groups;
      jsonData["msgtype"] = (JsonData) "image";
      jsonData[nameof (agentid)] = (JsonData) agentid;
      jsonData["image"] = new JsonData()
      {
        ["media_id"] = (JsonData) str
      };
      jsonData[nameof (safe)] = (JsonData) safe;
      this.agentId = agentid;
      string json = jsonData.ToJson(false);
            if (!async)
        return this.send(json);
      this.sendAsync(json);
      return "";
    }

    public string SendVoice(string media_idOrVoicePath, string userids = "", string depts = "", string groups = "", int safe = 0, int agentid = 0, bool async = false)
    {
      string str = string.Empty;
      if (File.Exists(media_idOrVoicePath))
        str = new Media(agentid).UploadFormal(media_idOrVoicePath, "voice");
      if (str.IsNullOrEmpty())
        return "上传语音错误";
      JsonData jsonData = new JsonData();
      jsonData["touser"] = (JsonData) userids;
      jsonData["toparty"] = (JsonData) depts;
      jsonData["totag"] = (JsonData) groups;
      jsonData["msgtype"] = (JsonData) "voice";
      jsonData[nameof (agentid)] = (JsonData) agentid;
      jsonData["voice"] = new JsonData()
      {
        ["media_id"] = (JsonData) str
      };
      jsonData[nameof (safe)] = (JsonData) safe;
      this.agentId = agentid;
      string json = jsonData.ToJson(false);
            if (!async)
        return this.send(json);
      this.sendAsync(json);
      return "";
    }

    public string SendVoice(string media_idOrVideoPath, string userids = "", string depts = "", string groups = "", int safe = 0, int agentid = 0, string title = "", string description = "", bool async = false)
    {
      string str = string.Empty;
      if (File.Exists(media_idOrVideoPath))
        str = new Media(agentid).UploadFormal(media_idOrVideoPath, "video");
      if (str.IsNullOrEmpty())
        return "上传视频错误";
      JsonData jsonData = new JsonData();
      jsonData["touser"] = (JsonData) userids;
      jsonData["toparty"] = (JsonData) depts;
      jsonData["totag"] = (JsonData) groups;
      jsonData["msgtype"] = (JsonData) "video";
      jsonData[nameof (agentid)] = (JsonData) agentid;
      jsonData["video"] = new JsonData()
      {
        ["media_id"] = (JsonData) str,
        [nameof (title)] = (JsonData) title,
        [nameof (description)] = (JsonData) description
      };
      jsonData[nameof (safe)] = (JsonData) safe;
      this.agentId = agentid;
      string json = jsonData.ToJson(false);
            if (!async)
        return this.send(json);
      this.sendAsync(json);
      return "";
    }

    public string SendFile(string media_idOrFilePath, string userids = "", string depts = "", string groups = "", int safe = 0, int agentid = 0, bool async = false)
    {
      string str = string.Empty;
      if (File.Exists(media_idOrFilePath))
        str = new Media(agentid).UploadFormal(media_idOrFilePath, "file");
      if (str.IsNullOrEmpty())
        return "上传文件错误";
      JsonData jsonData = new JsonData();
      jsonData["touser"] = (JsonData) userids;
      jsonData["toparty"] = (JsonData) depts;
      jsonData["totag"] = (JsonData) groups;
      jsonData["msgtype"] = (JsonData) "file";
      jsonData[nameof (agentid)] = (JsonData) agentid;
      jsonData["file"] = new JsonData()
      {
        ["media_id"] = (JsonData) str
      };
      jsonData[nameof (safe)] = (JsonData) safe;
      this.agentId = agentid;
      string json = jsonData.ToJson(false);
            if (!async)
        return this.send(json);
      this.sendAsync(json);
      return "";
    }

    public string SendNews(List<Tuple<string, string, string, string>> articleList, string userids = "", string depts = "", string groups = "", int agentid = 0, bool async = false)
    {
      JsonData jsonData1 = new JsonData();
      jsonData1["touser"] = (JsonData) userids;
      jsonData1["toparty"] = (JsonData) depts;
      jsonData1["totag"] = (JsonData) groups;
      jsonData1["msgtype"] = (JsonData) "news";
      jsonData1[nameof (agentid)] = (JsonData) agentid;
      JsonData jsonData2 = new JsonData();
      JsonData jsonData3 = new JsonData();
      foreach (Tuple<string, string, string, string> article in articleList)
      {
        JsonData jsonData4 = new JsonData();
        jsonData4["title"] = (JsonData) article.Item1;
        jsonData4["description"] = (JsonData) article.Item2;
        jsonData4["url"] = (JsonData) article.Item3;
        string str = article.Item4;
        if (!str.IsNullOrEmpty())
        {
          jsonData4["picurl"] = (JsonData) str;
          jsonData3.Add((object) jsonData4);
        }
      }
      jsonData2["articles"] = jsonData3;
      jsonData1["news"] = jsonData2;
      this.agentId = agentid;
      string json = jsonData1.ToJson(false);
            if (!async)
        return this.send(json);
      this.sendAsync(json);
      return "";
    }

    public string SendMPNews(List<Tuple<string, string, string, string, string, string, string>> articleList, string userids = "", string depts = "", string groups = "", int agentid = 0, bool async = false)
    {
      JsonData jsonData1 = new JsonData();
      jsonData1["touser"] = (JsonData) userids;
      jsonData1["toparty"] = (JsonData) depts;
      jsonData1["totag"] = (JsonData) groups;
      jsonData1["msgtype"] = (JsonData) "mpnews";
      jsonData1[nameof (agentid)] = (JsonData) agentid;
      JsonData jsonData2 = new JsonData();
      JsonData jsonData3 = new JsonData();
      foreach (Tuple<string, string, string, string, string, string, string> article in articleList)
      {
        JsonData jsonData4 = new JsonData();
        jsonData4["title"] = (JsonData) article.Item1;
        string str = article.Item2;
        if (File.Exists(article.Item2))
          str = new Media(agentid).UploadFormal(article.Item2, "image");
        jsonData4["thumb_media_id"] = (JsonData) str;
        jsonData4["author"] = (JsonData) article.Item3;
        jsonData4["content_source_url"] = (JsonData) article.Item4;
        jsonData4["content"] = (JsonData) article.Item5;
        jsonData4["digest"] = (JsonData) article.Item6;
        jsonData4["show_cover_pic"] = (JsonData) article.Item7;
        jsonData3.Add((object) jsonData4);
      }
      jsonData2["articles"] = jsonData3;
      jsonData1["mpnews"] = jsonData2;
      this.agentId = agentid;
      string json = jsonData1.ToJson(false);
            if (!async)
        return this.send(json);
      this.sendAsync(json);
      return "";
    }

    public void Receive(string xml)
    {
      XElement root = XDocument.Parse(xml).Root;
      string str1 = root.Element((XName) "ToUserName").Value;
      string str2 = root.Element((XName) "FromUserName").Value;
      string str3 = root.Element((XName) "CreateTime").Value;
      string str4 = root.Element((XName) "MsgType").Value;
      string str5 = root.Element((XName) "MsgId").Value;
      string str6 = root.Element((XName) "AgentID").Value;
      RoadFlow.Platform.WeiXinMessage weiXinMessage = new RoadFlow.Platform.WeiXinMessage();
      RoadFlow.Data.Model.WeiXinMessage model = new RoadFlow.Data.Model.WeiXinMessage() { ID = Guid.NewGuid(), AddTime = DateTimeNew.Now, AgentID = str6.ToInt(), CreateTime = str3.ToInt() };
      model.CreateTime1 = Tools.JavaLongToDateTime(model.CreateTime);
      model.MsgType = str4;
      model.MsgId = str5.ToLong();
      model.ToUserName = str1;
      model.FromUserName = str2;
      switch (str4)
      {
        case "image":
          model.PicUrl = root.Element((XName) "PicUrl").Value;
          model.MediaId = root.Element((XName) "MediaId").Value;
          break;
        case "link":
          model.Title = root.Element((XName) "Title").Value;
          model.Description = root.Element((XName) "Description").Value;
          model.PicUrl = root.Element((XName) "PicUrl").Value;
          break;
        case "location":
          model.Location_X = root.Element((XName) "Location_X").Value;
          model.Location_Y = root.Element((XName) "Location_Y").Value;
          model.Scale = root.Element((XName) "Scale").Value;
          model.Label = root.Element((XName) "Label").Value;
          break;
        case "shortvideo":
          model.ThumbMediaId = root.Element((XName) "ThumbMediaId").Value;
          model.MediaId = root.Element((XName) "MediaId").Value;
          break;
        case "text":
          model.Contents = root.Element((XName) "Content").Value;
          break;
        case "video":
          model.ThumbMediaId = root.Element((XName) "ThumbMediaId").Value;
          model.MediaId = root.Element((XName) "MediaId").Value;
          break;
        case "voice":
          model.Format = root.Element((XName) "Format").Value;
          model.MediaId = root.Element((XName) "MediaId").Value;
          break;
      }
      weiXinMessage.Add(model);
    }

    private delegate string delegate_send(string data);
  }
}
