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
			secret = Config.OrganizeSecret;
		}

		public Media(int agentId)
		{
			secret = Config.GetSecret(agentId);
		}

		public Media(string secret)
		{
			this.secret = secret;
		}

		private string GetAccessToken()
		{
			return Config.GetAccessToken(secret);
		}

		public string UploadTemp(string file, string type)
		{
			string text = "https://qyapi.weixin.qq.com/cgi-bin/media/upload?access_token=" + GetAccessToken() + "&type=" + type;
			FileStream fileStream = new FileStream(file, FileMode.Open);
			byte[] array = new byte[fileStream.Length];
			fileStream.Read(array, 0, array.Length);
			fileStream.Close();
			string text2 = HttpHelper.SendFile(text, file, array);
			JsonData jsonData = JsonMapper.ToObject(text2);
			if (jsonData.ContainsKey("media_id"))
			{
				string text3 = jsonData["media_id"].ToString();
				if (text3.IsNullOrEmpty())
				{
					Log.Add("调用了微信上传临时素材错误-" + file, "返回：" + text2, Log.Types.微信企业号, text);
				}
				return text3;
			}
			Log.Add("调用了微信上传临时素材错误-" + file, "返回：" + text2, Log.Types.微信企业号, text);
			return "";
		}

		public string UploadTemp(HttpPostedFile postedFile, string type)
		{
			string text = "https://qyapi.weixin.qq.com/cgi-bin/media/upload?access_token=" + GetAccessToken() + "&type=" + type;
			string text2 = HttpHelper.SendFile(text, postedFile);
			JsonData jsonData = JsonMapper.ToObject(text2);
			if (jsonData.ContainsKey("media_id"))
			{
				string text3 = jsonData["media_id"].ToString();
				if (text3.IsNullOrEmpty())
				{
					Log.Add("调用了微信上传临时素材错误-" + postedFile.FileName, "返回：" + text2, Log.Types.微信企业号, text);
				}
				return text3;
			}
			Log.Add("调用了微信上传临时素材错误-" + postedFile.FileName, "返回：" + text2, Log.Types.微信企业号, text);
			return "";
		}

		public string DownladTemp(string media_id, string savePath)
		{
			string text = "https://qyapi.weixin.qq.com/cgi-bin/media/get?access_token=" + GetAccessToken() + "&media_id=" + media_id;
			return "";
		}

		public string UploadFormal(string file, string type)
		{
			string text = "https://qyapi.weixin.qq.com/cgi-bin/material/add_material?access_token=" + GetAccessToken() + "&type=" + type;
			FileStream fileStream = new FileStream(file, FileMode.Open);
			byte[] array = new byte[fileStream.Length];
			fileStream.Read(array, 0, array.Length);
			fileStream.Close();
			string text2 = HttpHelper.SendFile(text, file, array);
			JsonData jsonData = JsonMapper.ToObject(text2);
			if (jsonData.ContainsKey("errcode") && "0" == jsonData["errcode"].ToString() && jsonData.ContainsKey("media_id"))
			{
				string text3 = jsonData["media_id"].ToString();
				if (text3.IsNullOrEmpty())
				{
					Log.Add("调用了微信上传永久素材错误-" + file, "返回：" + text2, Log.Types.微信企业号, text);
				}
				return text3;
			}
			Log.Add("调用了微信上传永久素材错误-" + file, "返回：" + text2, Log.Types.微信企业号, text);
			return "";
		}

		public string UploadMPNews(string title, string thumb_media_id, string content, string author = "", string content_source_url = "", string digest = "", int show_cover_pic = 0, string edit_media_id = "")
		{
			string result = string.Empty;
			if (File.Exists(thumb_media_id))
			{
				thumb_media_id = UploadFormal(thumb_media_id, "image");
				if (thumb_media_id.IsNullOrEmpty())
				{
					return result;
				}
			}
			bool num = !edit_media_id.IsNullOrEmpty();
			string url = num ? ("https://qyapi.weixin.qq.com/cgi-bin/material/update_mpnews?access_token=" + GetAccessToken()) : ("https://qyapi.weixin.qq.com/cgi-bin/material/add_mpnews?access_token=" + GetAccessToken());
			JsonData jsonData = new JsonData();
			JsonData jsonData2 = new JsonData();
			JsonData jsonData3 = new JsonData();
			JsonData jsonData4 = new JsonData();
			if (num)
			{
				jsonData["media_id"] = edit_media_id;
			}
			jsonData4["title"] = title;
			jsonData4["thumb_media_id"] = thumb_media_id;
			jsonData4["content_source_url"] = content_source_url;
			jsonData4["content"] = content;
			jsonData4["digest"] = digest;
			jsonData4["show_cover_pic"] = show_cover_pic;
			jsonData3.Add(jsonData4);
			jsonData2["articles"] = jsonData3;
			jsonData["mpnews"] = jsonData2;
			string text = jsonData.ToJson();
			string text2 = HttpHelper.SendPost(url, text);
			JsonData jsonData5 = JsonMapper.ToObject(text2);
			if (jsonData5.ContainsKey("errcode") && "0" == jsonData5["errcode"].ToString() && jsonData5.ContainsKey("media_id"))
			{
				result = jsonData5["media_id"].ToString();
				Log.Add("调用了微信上传永久图文素材-" + title, "返回：" + text2, Log.Types.微信企业号, text);
			}
			else
			{
				Log.Add("调用了微信上传永久图文素材错误-" + title, "返回：" + text2, Log.Types.微信企业号, text);
			}
			return result;
		}

		public bool DeleteMPNews(string media_id)
		{
			string text = HttpHelper.SendGet("https://qyapi.weixin.qq.com/cgi-bin/material/del?access_token=" + GetAccessToken() + "&media_id=" + media_id);
			JsonData jsonData = JsonMapper.ToObject(text);
			Log.Add("调用了微信删除永久图文素材-" + media_id, "返回：" + text, Log.Types.微信企业号);
			if (jsonData.ContainsKey("errcode") && "0" == jsonData["errcode"].ToString())
			{
				return true;
			}
			return false;
		}

		public string UploadImg(string file)
		{
			string text = "https://qyapi.weixin.qq.com/cgi-bin/media/uploadimg?access_token=" + GetAccessToken();
			FileStream fileStream = new FileStream(file, FileMode.Open);
			byte[] array = new byte[fileStream.Length];
			fileStream.Read(array, 0, array.Length);
			fileStream.Close();
			string text2 = HttpHelper.SendFile(text, file, array);
			JsonData jsonData = JsonMapper.ToObject(text2);
			if (jsonData.ContainsKey("url"))
			{
				return jsonData["url"].ToString();
			}
			Log.Add("调用了微信上传图文消息内的图片错误-" + file, "返回：" + text2, Log.Types.微信企业号, text);
			return "";
		}

		public string Download(string media_id)
		{
			string text = "https://qyapi.weixin.qq.com/cgi-bin/material/get?access_token=" + GetAccessToken() + "&media_id=" + media_id;
			string text2 = HttpHelper.DownloadFile(text, "D:\\sdfsdf.mp4");
			Log.Add("调用了微信下载素材", "返回：" + text2, Log.Types.微信企业号, text);
			return text2;
		}
	}
}
