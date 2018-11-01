using LitJson;
using RoadFlow.Data.Model;
using RoadFlow.Utility;
using System;
using System.Collections.Generic;
using System.IO;
using System.Xml.Linq;

namespace RoadFlow.Platform.WeiXin
{
	public class Message
	{
		private delegate string delegate_send(string data);

		private string secret = string.Empty;

		private int agentId = -1;

		public Message()
		{
			secret = Config.OrganizeSecret;
		}

		public Message(int agentId)
		{
			secret = Config.GetSecret(agentId);
		}

		public Message(string agentCode)
		{
			secret = Config.GetSecret(agentCode);
		}

		private string GetAccessToken()
		{
			return Config.GetAccessToken(secret);
		}

		private string send(string data)
		{
			if (agentId != -1 && secret.IsNullOrEmpty())
			{
				secret = Config.GetSecret(agentId);
			}
			string text = "https://qyapi.weixin.qq.com/cgi-bin/message/send?access_token=" + GetAccessToken();
			string text2 = HttpHelper.SendPost(text, data);
			JsonData jsonData = JsonMapper.ToObject(text2);
			if (jsonData.ContainsKey("errcode") && "0" == jsonData["errcode"].ToString())
			{
				Log.Add("调用了微信发送消息", "返回：" + text2, Log.Types.微信企业号, text, data);
				return "";
			}
			Log.Add("调用了微信发送消息错误", "返回：" + text2, Log.Types.微信企业号, text, data);
			return text2;
		}

		private void sendAsync(string data)
		{
			new delegate_send(send).BeginInvoke(data, null, null);
		}

		public string SendText(string contents, string userids = "", string depts = "", string groups = "", int safe = 0, int agentid = 0, bool async = false)
		{
			JsonData jsonData = new JsonData();
			jsonData["touser"] = userids;
			jsonData["toparty"] = depts;
			jsonData["totag"] = groups;
			jsonData["msgtype"] = "text";
			jsonData["agentid"] = agentid;
			JsonData jsonData2 = new JsonData();
			jsonData2["content"] = contents;
			jsonData["text"] = jsonData2;
			jsonData["safe"] = safe;
			agentId = agentid;
			string data = jsonData.ToJson(false);
			if (async)
			{
				sendAsync(data);
				return "";
			}
			return send(data);
		}

		public string SendImg(string media_idOrImgPath, string userids = "", string depts = "", string groups = "", int safe = 0, int agentid = 0, bool async = false)
		{
			string text = string.Empty;
			if (File.Exists(media_idOrImgPath))
			{
				text = new Media(agentid).UploadFormal(media_idOrImgPath, "image");
			}
			if (text.IsNullOrEmpty())
			{
				return "上传图片错误";
			}
			JsonData jsonData = new JsonData();
			jsonData["touser"] = userids;
			jsonData["toparty"] = depts;
			jsonData["totag"] = groups;
			jsonData["msgtype"] = "image";
			jsonData["agentid"] = agentid;
			JsonData jsonData2 = new JsonData();
			jsonData2["media_id"] = text;
			jsonData["image"] = jsonData2;
			jsonData["safe"] = safe;
			agentId = agentid;
			string data = jsonData.ToJson(false);
			if (async)
			{
				sendAsync(data);
				return "";
			}
			return send(data);
		}

		public string SendVoice(string media_idOrVoicePath, string userids = "", string depts = "", string groups = "", int safe = 0, int agentid = 0, bool async = false)
		{
			string text = string.Empty;
			if (File.Exists(media_idOrVoicePath))
			{
				text = new Media(agentid).UploadFormal(media_idOrVoicePath, "voice");
			}
			if (text.IsNullOrEmpty())
			{
				return "上传语音错误";
			}
			JsonData jsonData = new JsonData();
			jsonData["touser"] = userids;
			jsonData["toparty"] = depts;
			jsonData["totag"] = groups;
			jsonData["msgtype"] = "voice";
			jsonData["agentid"] = agentid;
			JsonData jsonData2 = new JsonData();
			jsonData2["media_id"] = text;
			jsonData["voice"] = jsonData2;
			jsonData["safe"] = safe;
			agentId = agentid;
			string data = jsonData.ToJson(false);
			if (async)
			{
				sendAsync(data);
				return "";
			}
			return send(data);
		}

		public string SendVoice(string media_idOrVideoPath, string userids = "", string depts = "", string groups = "", int safe = 0, int agentid = 0, string title = "", string description = "", bool async = false)
		{
			string text = string.Empty;
			if (File.Exists(media_idOrVideoPath))
			{
				text = new Media(agentid).UploadFormal(media_idOrVideoPath, "video");
			}
			if (text.IsNullOrEmpty())
			{
				return "上传视频错误";
			}
			JsonData jsonData = new JsonData();
			jsonData["touser"] = userids;
			jsonData["toparty"] = depts;
			jsonData["totag"] = groups;
			jsonData["msgtype"] = "video";
			jsonData["agentid"] = agentid;
			JsonData jsonData2 = new JsonData();
			jsonData2["media_id"] = text;
			jsonData2["title"] = title;
			jsonData2["description"] = description;
			jsonData["video"] = jsonData2;
			jsonData["safe"] = safe;
			agentId = agentid;
			string data = jsonData.ToJson(false);
			if (async)
			{
				sendAsync(data);
				return "";
			}
			return send(data);
		}

		public string SendFile(string media_idOrFilePath, string userids = "", string depts = "", string groups = "", int safe = 0, int agentid = 0, bool async = false)
		{
			string text = string.Empty;
			if (File.Exists(media_idOrFilePath))
			{
				text = new Media(agentid).UploadFormal(media_idOrFilePath, "file");
			}
			if (text.IsNullOrEmpty())
			{
				return "上传文件错误";
			}
			JsonData jsonData = new JsonData();
			jsonData["touser"] = userids;
			jsonData["toparty"] = depts;
			jsonData["totag"] = groups;
			jsonData["msgtype"] = "file";
			jsonData["agentid"] = agentid;
			JsonData jsonData2 = new JsonData();
			jsonData2["media_id"] = text;
			jsonData["file"] = jsonData2;
			jsonData["safe"] = safe;
			agentId = agentid;
			string data = jsonData.ToJson(false);
			if (async)
			{
				sendAsync(data);
				return "";
			}
			return send(data);
		}

		public string SendNews(List<Tuple<string, string, string, string>> articleList, string userids = "", string depts = "", string groups = "", int agentid = 0, bool async = false)
		{
			JsonData jsonData = new JsonData();
			jsonData["touser"] = userids;
			jsonData["toparty"] = depts;
			jsonData["totag"] = groups;
			jsonData["msgtype"] = "news";
			jsonData["agentid"] = agentid;
			JsonData jsonData2 = new JsonData();
			JsonData jsonData3 = new JsonData();
			foreach (Tuple<string, string, string, string> article in articleList)
			{
				JsonData jsonData4 = new JsonData();
				jsonData4["title"] = article.Item1;
				jsonData4["description"] = article.Item2;
				jsonData4["url"] = article.Item3;
				string item = article.Item4;
				if (!item.IsNullOrEmpty())
				{
					jsonData4["picurl"] = item;
					jsonData3.Add(jsonData4);
				}
			}
			jsonData2["articles"] = jsonData3;
			jsonData["news"] = jsonData2;
			agentId = agentid;
			string data = jsonData.ToJson(false);
			if (async)
			{
				sendAsync(data);
				return "";
			}
			return send(data);
		}

		public string SendMPNews(List<Tuple<string, string, string, string, string, string, string>> articleList, string userids = "", string depts = "", string groups = "", int agentid = 0, bool async = false)
		{
			JsonData jsonData = new JsonData();
			jsonData["touser"] = userids;
			jsonData["toparty"] = depts;
			jsonData["totag"] = groups;
			jsonData["msgtype"] = "mpnews";
			jsonData["agentid"] = agentid;
			JsonData jsonData2 = new JsonData();
			JsonData jsonData3 = new JsonData();
			foreach (Tuple<string, string, string, string, string, string, string> article in articleList)
			{
				JsonData jsonData4 = new JsonData();
				jsonData4["title"] = article.Item1;
				string data = article.Item2;
				if (File.Exists(article.Item2))
				{
					data = new Media(agentid).UploadFormal(article.Item2, "image");
				}
				jsonData4["thumb_media_id"] = data;
				jsonData4["author"] = article.Item3;
				jsonData4["content_source_url"] = article.Item4;
				jsonData4["content"] = article.Item5;
				jsonData4["digest"] = article.Item6;
				jsonData4["show_cover_pic"] = article.Item7;
				jsonData3.Add(jsonData4);
			}
			jsonData2["articles"] = jsonData3;
			jsonData["mpnews"] = jsonData2;
			agentId = agentid;
			string data2 = jsonData.ToJson(false);
			if (async)
			{
				sendAsync(data2);
				return "";
			}
			return send(data2);
		}

		public void Receive(string xml)
		{
			XElement root = XDocument.Parse(xml).Root;
			string value = root.Element("ToUserName").Value;
			string value2 = root.Element("FromUserName").Value;
			string value3 = root.Element("CreateTime").Value;
			string value4 = root.Element("MsgType").Value;
			string value5 = root.Element("MsgId").Value;
			string value6 = root.Element("AgentID").Value;
			WeiXinMessage weiXinMessage = new WeiXinMessage();
			RoadFlow.Data.Model.WeiXinMessage weiXinMessage2 = new RoadFlow.Data.Model.WeiXinMessage();
			weiXinMessage2.ID = Guid.NewGuid();
			weiXinMessage2.AddTime = DateTimeNew.Now;
			weiXinMessage2.AgentID = value6.ToInt();
			weiXinMessage2.CreateTime = value3.ToInt();
			weiXinMessage2.CreateTime1 = Tools.JavaLongToDateTime(weiXinMessage2.CreateTime);
			weiXinMessage2.MsgType = value4;
			weiXinMessage2.MsgId = value5.ToLong();
			weiXinMessage2.ToUserName = value;
			weiXinMessage2.FromUserName = value2;
			switch (value4)
			{
			case "text":
				weiXinMessage2.Contents = root.Element("Content").Value;
				break;
			case "image":
				weiXinMessage2.PicUrl = root.Element("PicUrl").Value;
				weiXinMessage2.MediaId = root.Element("MediaId").Value;
				break;
			case "voice":
				weiXinMessage2.Format = root.Element("Format").Value;
				weiXinMessage2.MediaId = root.Element("MediaId").Value;
				break;
			case "video":
				weiXinMessage2.ThumbMediaId = root.Element("ThumbMediaId").Value;
				weiXinMessage2.MediaId = root.Element("MediaId").Value;
				break;
			case "shortvideo":
				weiXinMessage2.ThumbMediaId = root.Element("ThumbMediaId").Value;
				weiXinMessage2.MediaId = root.Element("MediaId").Value;
				break;
			case "location":
				weiXinMessage2.Location_X = root.Element("Location_X").Value;
				weiXinMessage2.Location_Y = root.Element("Location_Y").Value;
				weiXinMessage2.Scale = root.Element("Scale").Value;
				weiXinMessage2.Label = root.Element("Label").Value;
				break;
			case "link":
				weiXinMessage2.Title = root.Element("Title").Value;
				weiXinMessage2.Description = root.Element("Description").Value;
				weiXinMessage2.PicUrl = root.Element("PicUrl").Value;
				break;
			}
			weiXinMessage.Add(weiXinMessage2);
		}
	}
}
