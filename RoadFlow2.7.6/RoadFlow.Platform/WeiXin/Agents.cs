// Decompiled with JetBrains decompiler
// Type: RoadFlow.Platform.WeiXin.Agents
// Assembly: RoadFlow.Platform, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 07F26AFD-DE3B-4003-89AF-01A62494BA58
// Assembly location: C:\inetpub\wwwroot\RoadFlowMvc\bin\RoadFlow.Platform.dll

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
        private string cacheKey = Keys.CacheKeys.WeiXinAgents.ToString();

        private string GetAccessToken()
        {
            return Config.GetAccessToken(Config.OrganizeSecret);
        }

        public WeiXinAgent GetAgentInfo(int id)
        {
            string str = HttpHelper.SendGet("https://qyapi.weixin.qq.com/cgi-bin/agent/get?access_token=" + this.GetAccessToken() + "&agentid=" + id.ToString());
            JsonData jsonData1 = JsonMapper.ToObject(str);
            if (jsonData1.ContainsKey("errcode") && "0" != jsonData1["errcode"].ToString())
            {
                RoadFlow.Platform.Log.Add("微信获取应用详情-失败", str, RoadFlow.Platform.Log.Types.微信企业号, "", "", (RoadFlow.Data.Model.Users)null);
                return (WeiXinAgent)null;
            }
            WeiXinAgent weiXinAgent = new WeiXinAgent();
            weiXinAgent.agentid = jsonData1["agentid"].ToString().ToInt();
            weiXinAgent.name = jsonData1["name"].ToString();
            weiXinAgent.square_logo_url = jsonData1["square_logo_url"].ToString();
            weiXinAgent.round_logo_url = jsonData1["round_logo_url"].ToString();
            weiXinAgent.description = jsonData1["description"].ToString();
            weiXinAgent.close = jsonData1["close"].ToString().ToInt();
            weiXinAgent.redirect_domain = jsonData1["redirect_domain"].ToString();
            weiXinAgent.report_location_flag = jsonData1["report_location_flag"].ToString().ToInt();
            weiXinAgent.isreportuser = jsonData1["isreportuser"].ToString().ToInt();
            weiXinAgent.isreportenter = jsonData1["isreportenter"].ToString().ToInt();
            weiXinAgent.chat_extension_url = jsonData1["chat_extension_url"].ToString();
            weiXinAgent.type = jsonData1["type"].ToString().ToInt();
            if (jsonData1["allow_tags"].ContainsKey("tagid") && jsonData1["allow_tags"]["tagid"].IsArray)
            {
                StringBuilder stringBuilder = new StringBuilder();
                foreach (JsonData jsonData2 in (IEnumerable)jsonData1["allow_tags"]["tagid"])
                {
                    stringBuilder.Append(jsonData2.ToString());
                    stringBuilder.Append(",");
                }
                weiXinAgent.allow_tags = stringBuilder.ToString().TrimEnd(',');
            }
            if (jsonData1["allow_partys"].ContainsKey("partyid") && jsonData1["allow_partys"]["partyid"].IsArray)
            {
                StringBuilder stringBuilder = new StringBuilder();
                foreach (JsonData jsonData2 in (IEnumerable)jsonData1["allow_partys"]["partyid"])
                {
                    stringBuilder.Append(jsonData2.ToString());
                    stringBuilder.Append(",");
                }
                weiXinAgent.allow_partys = stringBuilder.ToString().TrimEnd(',');
            }
            if (jsonData1["allow_userinfos"].ContainsKey("user") && jsonData1["allow_userinfos"]["user"].IsArray)
            {
                List<Tuple<string, int>> tupleList = new List<Tuple<string, int>>();
                foreach (JsonData jsonData2 in (IEnumerable)jsonData1["allow_userinfos"]["user"])
                    tupleList.Add(new Tuple<string, int>(jsonData2["userid"].ToString(), jsonData2["status"].ToString().ToInt()));
                weiXinAgent.allow_userinfos = tupleList;
            }
            return weiXinAgent;
        }

        public bool SetAgentInfo(WeiXinAgent agent)
        {
            string url = "https://qyapi.weixin.qq.com/cgi-bin/agent/set?access_token=" + this.GetAccessToken();
            string json = new JsonData()
            {
                ["agentid"] = (JsonData)agent.agentid,
                ["report_location_flag"] = (JsonData)agent.report_location_flag,
                ["logo_mediaid"] = (JsonData)agent.logo_mediaid,
                ["name"] = (JsonData)agent.name,
                ["description"] = (JsonData)agent.description,
                ["redirect_domain"] = (JsonData)agent.redirect_domain,
                ["isreportuser"] = (JsonData)agent.isreportuser,
                ["isreportenter"] = (JsonData)agent.isreportenter,
                ["home_url"] = (JsonData)agent.home_url,
                ["chat_extension_url"] = (JsonData)agent.chat_extension_url
            }.ToJson(false);
            string data = json;
            string str = HttpHelper.SendPost(url, data);
            JsonData jsonData = JsonMapper.ToObject(str);
            if (jsonData.ContainsKey("errcode") && "0" != jsonData["errcode"].ToString())
            {
                RoadFlow.Platform.Log.Add("微信设置应用-失败", str, RoadFlow.Platform.Log.Types.微信企业号, json, "", (RoadFlow.Data.Model.Users)null);
                return false;
            }
            RoadFlow.Platform.Log.Add("微信设置应用-成功", str, RoadFlow.Platform.Log.Types.微信企业号, json, "", (RoadFlow.Data.Model.Users)null);
            return true;
        }

        public List<WeiXinAgent> GetAgents()
        {
            List<WeiXinAgent> weiXinAgentList = new List<WeiXinAgent>();
            string str = HttpHelper.SendGet("https://qyapi.weixin.qq.com/cgi-bin/agent/list?access_token=" + this.GetAccessToken());
            JsonData jsonData1 = JsonMapper.ToObject(str);
            if (jsonData1.ContainsKey("errcode") && "0" != jsonData1["errcode"].ToString())
            {
                RoadFlow.Platform.Log.Add("微信获取应用列表-失败", str, RoadFlow.Platform.Log.Types.微信企业号, "", "", (RoadFlow.Data.Model.Users)null);
                return weiXinAgentList;
            }
            if (jsonData1.ContainsKey("agentlist") && jsonData1["agentlist"].IsArray)
            {
                foreach (JsonData jsonData2 in (IEnumerable)jsonData1["agentlist"])
                    weiXinAgentList.Add(new WeiXinAgent()
                    {
                        agentid = jsonData2["agentid"].ToString().ToInt(),
                        name = jsonData2["name"].ToString(),
                        square_logo_url = jsonData2.ContainsKey("square_logo_url") ? jsonData2["square_logo_url"].ToString() : "",
                        round_logo_url = jsonData2.ContainsKey("round_logo_url") ? jsonData2["round_logo_url"].ToString() : ""
                    });
            }
            return weiXinAgentList;
        }

        public int GetAgentIDByCode(string code)
        {
            RoadFlow.Data.Model.Dictionary byCode = new RoadFlow.Platform.Dictionary().GetByCode(code, true);
            if (byCode != null)
                return byCode.Value.ToInt(-1);
            return -1;
        }
    }
}
