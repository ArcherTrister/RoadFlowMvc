using LitJson;
using RoadFlow.Data.Model;
using RoadFlow.Utility;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;

namespace RoadFlow.Platform.WeiXin
{
	public class Agents
	{
		private string cacheKey = 24.ToString();

		private string GetAccessToken()
		{
			return Config.GetAccessToken(Config.OrganizeSecret);
		}

		public WeiXinAgent GetAgentInfo(int id)
		{
			string text = HttpHelper.SendGet("https://qyapi.weixin.qq.com/cgi-bin/agent/get?access_token=" + GetAccessToken() + "&agentid=" + id.ToString());
			JsonData jsonData = JsonMapper.ToObject(text);
			if (jsonData.ContainsKey("errcode") && "0" != jsonData["errcode"].ToString())
			{
				Log.Add("微信获取应用详情-失败", text, Log.Types.微信企业号);
				return null;
			}
			WeiXinAgent weiXinAgent = new WeiXinAgent();
			weiXinAgent.agentid = jsonData["agentid"].ToString().ToInt();
			weiXinAgent.name = jsonData["name"].ToString();
			weiXinAgent.square_logo_url = jsonData["square_logo_url"].ToString();
			weiXinAgent.round_logo_url = jsonData["round_logo_url"].ToString();
			weiXinAgent.description = jsonData["description"].ToString();
			weiXinAgent.close = jsonData["close"].ToString().ToInt();
			weiXinAgent.redirect_domain = jsonData["redirect_domain"].ToString();
			weiXinAgent.report_location_flag = jsonData["report_location_flag"].ToString().ToInt();
			weiXinAgent.isreportuser = jsonData["isreportuser"].ToString().ToInt();
			weiXinAgent.isreportenter = jsonData["isreportenter"].ToString().ToInt();
			weiXinAgent.chat_extension_url = jsonData["chat_extension_url"].ToString();
			weiXinAgent.type = jsonData["type"].ToString().ToInt();
			if (jsonData["allow_tags"].ContainsKey("tagid") && jsonData["allow_tags"]["tagid"].IsArray)
			{
				StringBuilder stringBuilder = new StringBuilder();
				foreach (JsonData item in (IEnumerable)jsonData["allow_tags"]["tagid"])
				{
					stringBuilder.Append(item.ToString());
					stringBuilder.Append(",");
				}
				weiXinAgent.allow_tags = stringBuilder.ToString().TrimEnd(',');
			}
			if (jsonData["allow_partys"].ContainsKey("partyid") && jsonData["allow_partys"]["partyid"].IsArray)
			{
				StringBuilder stringBuilder2 = new StringBuilder();
				foreach (JsonData item2 in (IEnumerable)jsonData["allow_partys"]["partyid"])
				{
					stringBuilder2.Append(item2.ToString());
					stringBuilder2.Append(",");
				}
				weiXinAgent.allow_partys = stringBuilder2.ToString().TrimEnd(',');
			}
			if (jsonData["allow_userinfos"].ContainsKey("user") && jsonData["allow_userinfos"]["user"].IsArray)
			{
				List<Tuple<string, int>> list = new List<Tuple<string, int>>();
				foreach (JsonData item3 in (IEnumerable)jsonData["allow_userinfos"]["user"])
				{
					list.Add(new Tuple<string, int>(item3["userid"].ToString(), item3["status"].ToString().ToInt()));
				}
				weiXinAgent.allow_userinfos = list;
			}
			return weiXinAgent;
		}

		public bool SetAgentInfo(WeiXinAgent agent)
		{
			string url = "https://qyapi.weixin.qq.com/cgi-bin/agent/set?access_token=" + GetAccessToken();
			JsonData jsonData = new JsonData();
			jsonData["agentid"] = agent.agentid;
			jsonData["report_location_flag"] = agent.report_location_flag;
			jsonData["logo_mediaid"] = agent.logo_mediaid;
			jsonData["name"] = agent.name;
			jsonData["description"] = agent.description;
			jsonData["redirect_domain"] = agent.redirect_domain;
			jsonData["isreportuser"] = agent.isreportuser;
			jsonData["isreportenter"] = agent.isreportenter;
			jsonData["home_url"] = agent.home_url;
			jsonData["chat_extension_url"] = agent.chat_extension_url;
			string text = jsonData.ToJson(false);
			string text2 = HttpHelper.SendPost(url, text);
			JsonData jsonData2 = JsonMapper.ToObject(text2);
			if (jsonData2.ContainsKey("errcode") && "0" != jsonData2["errcode"].ToString())
			{
				Log.Add("微信设置应用-失败", text2, Log.Types.微信企业号, text);
				return false;
			}
			Log.Add("微信设置应用-成功", text2, Log.Types.微信企业号, text);
			return true;
		}

		public List<WeiXinAgent> GetAgents()
		{
			List<WeiXinAgent> list = new List<WeiXinAgent>();
			string text = HttpHelper.SendGet("https://qyapi.weixin.qq.com/cgi-bin/agent/list?access_token=" + GetAccessToken());
			JsonData jsonData = JsonMapper.ToObject(text);
			if (jsonData.ContainsKey("errcode") && "0" != jsonData["errcode"].ToString())
			{
				Log.Add("微信获取应用列表-失败", text, Log.Types.微信企业号);
				return list;
			}
			if (jsonData.ContainsKey("agentlist") && jsonData["agentlist"].IsArray)
			{
				foreach (JsonData item in (IEnumerable)jsonData["agentlist"])
				{
					WeiXinAgent weiXinAgent = new WeiXinAgent();
					weiXinAgent.agentid = item["agentid"].ToString().ToInt();
					weiXinAgent.name = item["name"].ToString();
					weiXinAgent.square_logo_url = (item.ContainsKey("square_logo_url") ? item["square_logo_url"].ToString() : "");
					weiXinAgent.round_logo_url = (item.ContainsKey("round_logo_url") ? item["round_logo_url"].ToString() : "");
					list.Add(weiXinAgent);
				}
				return list;
			}
			return list;
		}

		public int GetAgentIDByCode(string code)
		{
			RoadFlow.Data.Model.Dictionary byCode = new Dictionary().GetByCode(code, true);
			if (byCode != null)
			{
				return byCode.Value.ToInt(-1);
			}
			return -1;
		}
	}
}
