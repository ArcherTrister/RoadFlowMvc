// Decompiled with JetBrains decompiler
// Type: RoadFlow.Platform.WeiXin.Organize
// Assembly: RoadFlow.Platform, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 07F26AFD-DE3B-4003-89AF-01A62494BA58
// Assembly location: C:\inetpub\wwwroot\RoadFlowMvc\bin\RoadFlow.Platform.dll

using LitJson;
using RoadFlow.Utility;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Data;
using System.IO;
using System.Linq;
using System.Text;
using System.Web;

namespace RoadFlow.Platform.WeiXin
{
  public class Organize
  {
    private string secret = string.Empty;

    public Organize()
    {
      string secret = Config.GetSecret("weixinagents_organize");
      this.secret = secret.IsNullOrEmpty() ? Config.OrganizeSecret : secret;
    }

    public Organize(int agentId)
    {
      this.secret = Config.GetSecret(agentId);
    }

    public Organize(string agentCode)
    {
      this.secret = Config.GetSecret(agentCode);
    }

    private string GetAccessToken()
    {
      return Config.GetAccessToken(this.secret);
    }

    private string replaceName(string name)
    {
      if (!name.IsNullOrEmpty())
        return name.Replace("\\", "").Replace(":", "").Replace("*", "").Replace("?", "").Replace("\"", "").Replace("<", "").Replace(">", "").Replace("｜", "");
      return name;
    }

    public bool AddDept(RoadFlow.Data.Model.Organize organize)
    {
      if (organize.IntID == 0)
        organize = new RoadFlow.Platform.Organize().Get(organize.ID);
      int num = 1;
      if (!organize.ParentID.IsEmptyGuid())
      {
        RoadFlow.Data.Model.Organize organize1 = new RoadFlow.Platform.Organize().Get(organize.ParentID);
        if (organize1 != null)
          num = organize1.IntID;
      }
      string url = "https://qyapi.weixin.qq.com/cgi-bin/department/create?access_token=" + this.GetAccessToken();
      string str = "{\"name\":\"" + this.replaceName(organize.Name) + "\",\"parentid\":" + num.ToString() + ",\"order\":" + organize.Sort.ToString() + ",\"id\":" + organize.IntID.ToString() + "}";
      string json = HttpHelper.SendPost(url, str);
      JsonData jsonData = JsonMapper.ToObject(json);
      bool flag = jsonData.ContainsKey("errcode") && jsonData["errcode"].ToString().ToInt() == 0;
      RoadFlow.Platform.Log.Add("调用了微信添加部门-" + organize.Name + "-" + (flag ? "成功" : "失败"), "返回：" + json, RoadFlow.Platform.Log.Types.微信企业号, organize.Serialize(), str, (RoadFlow.Data.Model.Users) null);
      return flag;
    }

    public void AddDeptAsync(RoadFlow.Data.Model.Organize organize)
    {
      new Organize.del_Save(this.AddDept).BeginInvoke(organize, (AsyncCallback) null, (object) null);
    }

    public bool EditDept(RoadFlow.Data.Model.Organize organize)
    {
      int num = 1;
      if (!organize.ParentID.IsEmptyGuid())
      {
        RoadFlow.Data.Model.Organize organize1 = new RoadFlow.Platform.Organize().Get(organize.ParentID);
        if (organize1 != null)
          num = organize1.IntID;
      }
      string url = "https://qyapi.weixin.qq.com/cgi-bin/department/update?access_token=" + this.GetAccessToken();
      string str = "{\"id\":" + organize.IntID.ToString() + ",\"name\":\"" + this.replaceName(organize.Name) + "\",\"parentid\":" + num.ToString() + ",\"order\":" + organize.Sort.ToString() + "}";
      string json = HttpHelper.SendPost(url, str);
      JsonData jsonData = JsonMapper.ToObject(json);
      bool flag = jsonData.ContainsKey("errcode") && jsonData["errcode"].ToString().ToInt() == 0;
      RoadFlow.Platform.Log.Add("调用了微信修改部门-" + organize.Name + "-" + (flag ? "成功" : "失败"), "返回：" + json, RoadFlow.Platform.Log.Types.微信企业号, organize.Serialize(), str, (RoadFlow.Data.Model.Users) null);
      return flag;
    }

    public void EditDeptAsync(RoadFlow.Data.Model.Organize organize)
    {
      new Organize.del_Save(this.EditDept).BeginInvoke(organize, (AsyncCallback) null, (object) null);
    }

    public bool DeleteDept(int organizeIntID)
    {
      string str = "https://qyapi.weixin.qq.com/cgi-bin/department/delete?access_token=" + this.GetAccessToken() + "&id=" + organizeIntID.ToString();
      string json = HttpHelper.SendGet(str);
      RoadFlow.Platform.Log.Add("调用了微信删除部门", "返回：" + json, RoadFlow.Platform.Log.Types.微信企业号, str, "", (RoadFlow.Data.Model.Users) null);
      JsonData jsonData = JsonMapper.ToObject(json);
      if (jsonData.ContainsKey("errcode"))
        return jsonData["errcode"].ToString().ToInt() == 0;
      return false;
    }

    public void DeleteDeptAsync(int organizeIntID)
    {
      new Organize.del_Delete(this.DeleteDept).BeginInvoke(organizeIntID, (AsyncCallback) null, (object) null);
    }

    public string GetUser(string userAccount)
    {
      string json = HttpHelper.SendGet("https://qyapi.weixin.qq.com/cgi-bin/user/get?access_token=" + this.GetAccessToken() + "&userid=" + userAccount);
      JsonData jsonData = JsonMapper.ToObject(json);
      bool flag = jsonData.ContainsKey("errcode") && jsonData["errcode"].ToString().ToInt() == 0;
      RoadFlow.Platform.Log.Add("调用了微信查询人员-" + userAccount + "-" + (flag ? "成功" : "失败"), "返回：" + json, RoadFlow.Platform.Log.Types.微信企业号, "", "", (RoadFlow.Data.Model.Users) null);
      if (!flag)
        return "";
      return json;
    }

    public bool AddUser(RoadFlow.Data.Model.Users user)
    {
      if (user.Mobile.IsNullOrEmpty() && user.Email.IsNullOrEmpty() && user.WeiXin.IsNullOrEmpty())
        return false;
      string url = "https://qyapi.weixin.qq.com/cgi-bin/user/create?access_token=" + this.GetAccessToken();
      List<RoadFlow.Data.Model.UsersRelation> allByUserId = new RoadFlow.Platform.UsersRelation().GetAllByUserID(user.ID);
      RoadFlow.Platform.Organize organize1 = new RoadFlow.Platform.Organize();
      StringBuilder stringBuilder = new StringBuilder();
      foreach (RoadFlow.Data.Model.UsersRelation usersRelation in allByUserId)
      {
        RoadFlow.Data.Model.Organize organize2 = organize1.Get(usersRelation.OrganizeID);
        if (organize2 != null)
        {
          stringBuilder.Append(organize2.IntID);
          stringBuilder.Append(",");
        }
      }
      string[] strArray = new string[13]{ "{\"userid\":\"", user.Account, "\",\"name\":\"", this.replaceName(user.Name), "\",\"department\":[", stringBuilder.ToString().TrimEnd(','), "],\"position\":\"\",\"mobile\":\"", user.Mobile, "\",", null, null, null, null };
      int index = 9;
      int? sex = user.Sex;
      string str1;
      if (!sex.HasValue)
      {
        str1 = "";
      }
      else
      {
        string str2 = "\"gender\":\"";
        sex = user.Sex;
        string str3 = (sex.Value + 1).ToString();
        string str4 = "\",";
        str1 = str2 + str3 + str4;
      }
      strArray[index] = str1;
      strArray[10] = "\"weixinid\":\"";
      strArray[11] = user.WeiXin;
      strArray[12] = "\"}";
      string str5 = string.Concat(strArray);
      string json = HttpHelper.SendPost(url, str5);
      JsonData jsonData = JsonMapper.ToObject(json);
      bool flag = jsonData.ContainsKey("errcode") && jsonData["errcode"].ToString().ToInt() == 0;
      RoadFlow.Platform.Log.Add("调用了微信添加人员-" + user.Name + "-" + (flag ? "成功" : "失败"), "返回：" + json, RoadFlow.Platform.Log.Types.微信企业号, user.Serialize(), str5, (RoadFlow.Data.Model.Users) null);
      return flag;
    }

    public void AddUserAsync(RoadFlow.Data.Model.Users user)
    {
      new Organize.del_SaveUser(this.AddUser).BeginInvoke(user, (AsyncCallback) null, (object) null);
    }

    public bool EditUser(RoadFlow.Data.Model.Users user)
    {
      if (user.Mobile.IsNullOrEmpty() && user.Email.IsNullOrEmpty() && user.WeiXin.IsNullOrEmpty())
        return false;
      if (this.GetUser(user.Account).IsNullOrEmpty())
        return this.AddUser(user);
      string url = "https://qyapi.weixin.qq.com/cgi-bin/user/update?access_token=" + this.GetAccessToken();
      List<RoadFlow.Data.Model.UsersRelation> allByUserId = new RoadFlow.Platform.UsersRelation().GetAllByUserID(user.ID);
      RoadFlow.Platform.Organize organize1 = new RoadFlow.Platform.Organize();
      StringBuilder stringBuilder = new StringBuilder();
      foreach (RoadFlow.Data.Model.UsersRelation usersRelation in allByUserId)
      {
        RoadFlow.Data.Model.Organize organize2 = organize1.Get(usersRelation.OrganizeID);
        if (organize2 != null)
        {
          stringBuilder.Append(organize2.IntID);
          stringBuilder.Append(",");
        }
      }
      string str = "{\"userid\":\"" + user.Account + "\",\"name\":\"" + this.replaceName(user.Name) + "\",\"department\":[" + stringBuilder.ToString().TrimEnd(',') + "],\"position\":\"\",\"mobile\":\"" + user.Mobile + "\"," + (user.Sex.HasValue ? "\"gender\":\"" + (user.Sex.Value + 1).ToString() + "\"," : "") + "\"email\":\"" + user.Email + "\",\"weixinid\":\"" + user.WeiXin + "\",\"enable\":" + (user.Status == 0 ? 1 : 0).ToString() + "}";
      string json = HttpHelper.SendPost(url, str);
      JsonData jsonData = JsonMapper.ToObject(json);
      bool flag = jsonData.ContainsKey("errcode") && jsonData["errcode"].ToString().ToInt() == 0;
      RoadFlow.Platform.Log.Add("调用了微信修改人员-" + user.Name + "-" + (flag ? "成功" : "失败"), "返回：" + json, RoadFlow.Platform.Log.Types.微信企业号, user.Serialize(), str, (RoadFlow.Data.Model.Users) null);
      return flag;
    }

    public void EditUserAsync(RoadFlow.Data.Model.Users user)
    {
      new Organize.del_SaveUser(this.EditUser).BeginInvoke(user, (AsyncCallback) null, (object) null);
    }

    public bool DeleteUser(string userAccount)
    {
      string str = "https://qyapi.weixin.qq.com/cgi-bin/user/delete?access_token=" + this.GetAccessToken() + "&userid=" + userAccount;
      string json = HttpHelper.SendGet(str);
      JsonData jsonData = JsonMapper.ToObject(json);
      bool flag = jsonData.ContainsKey("errcode") && jsonData["errcode"].ToString().ToInt() == 0;
      RoadFlow.Platform.Log.Add("调用了微信删除人员-" + userAccount + "-" + (flag ? "成功" : "失败"), "返回：" + json, RoadFlow.Platform.Log.Types.微信企业号, str, "", (RoadFlow.Data.Model.Users) null);
      return flag;
    }

    public void DeleteUserAsync(string userAccount)
    {
      new Organize.del_DeleteUser(this.DeleteUser).BeginInvoke(userAccount, (AsyncCallback) null, (object) null);
    }

    public bool DeleteUser(string[] userAccountList)
    {
      string url = "https://qyapi.weixin.qq.com/cgi-bin/user/batchdelete?access_token=" + this.GetAccessToken();
      string oldXML = "{\"useridlist\":[" + Tools.GetSqlInString<string>(userAccountList, true).Replace("'", "\"") + "]}";
      string data = oldXML;
      string json = HttpHelper.SendPost(url, data);
      JsonData jsonData = JsonMapper.ToObject(json);
      bool flag = jsonData.ContainsKey("errcode") && jsonData["errcode"].ToString().ToInt() == 0;
      RoadFlow.Platform.Log.Add("调用了微信批量删除人员-" + (flag ? "成功" : "失败"), "返回：" + json, RoadFlow.Platform.Log.Types.微信企业号, oldXML, "", (RoadFlow.Data.Model.Users) null);
      return flag;
    }

    public void DeleteUserAsync(string[] userAccountList)
    {
      new Organize.del_DeleteUser1(this.DeleteUser).BeginInvoke(userAccountList, (AsyncCallback) null, (object) null);
    }

    public bool AddGroup(RoadFlow.Data.Model.WorkGroup group)
    {
      if (group == null)
        return false;
      string url = "https://qyapi.weixin.qq.com/cgi-bin/tag/create?access_token=" + this.GetAccessToken();
      string str = "{\"tagname\":\"" + this.replaceName(group.Name) + "\",\"tagid\":" + group.IntID.ToString() + "}";
      string json = HttpHelper.SendPost(url, str);
      JsonData jsonData = JsonMapper.ToObject(json);
      bool flag = jsonData.ContainsKey("errcode") && jsonData["errcode"].ToString().ToInt() == 0;
      RoadFlow.Platform.Log.Add("调用了微信添加标签-" + (flag ? "成功" : "失败"), "返回：" + json, RoadFlow.Platform.Log.Types.微信企业号, str, "", (RoadFlow.Data.Model.Users) null);
      if (flag && !this.AddGroupUser(group))
        return false;
      return flag;
    }

    public void AddGroupAsync(RoadFlow.Data.Model.WorkGroup group)
    {
      new Organize.del_SaveWorkGroup(this.AddGroup).BeginInvoke(group, (AsyncCallback) null, (object) null);
    }

    public bool EditGroup(RoadFlow.Data.Model.WorkGroup group)
    {
      if (group == null)
        return false;
      string url = "https://qyapi.weixin.qq.com/cgi-bin/tag/update?access_token=" + this.GetAccessToken();
      string str = "{\"tagid\":" + group.IntID.ToString() + ",\"tagname\":\"" + this.replaceName(group.Name) + "\"}";
      string json = HttpHelper.SendPost(url, str);
      JsonData jsonData = JsonMapper.ToObject(json);
      bool flag = jsonData.ContainsKey("errcode") && jsonData["errcode"].ToString().ToInt() == 0;
      RoadFlow.Platform.Log.Add("调用了微信修改标签-" + (flag ? "成功" : "失败"), "返回：" + json, RoadFlow.Platform.Log.Types.微信企业号, str, "", (RoadFlow.Data.Model.Users) null);
      return flag;
    }

    public void EditGroupAsync(RoadFlow.Data.Model.WorkGroup group)
    {
      new Organize.del_SaveWorkGroup(this.EditGroup).BeginInvoke(group, (AsyncCallback) null, (object) null);
    }

    public bool DeleteGroup(RoadFlow.Data.Model.WorkGroup group)
    {
      if (group == null || !this.DeleteGroupUser(group.IntID))
        return false;
      string json = HttpHelper.SendGet("https://qyapi.weixin.qq.com/cgi-bin/tag/delete?access_token=" + this.GetAccessToken() + "&tagid=" + group.IntID.ToString());
      JsonData jsonData = JsonMapper.ToObject(json);
      bool flag = jsonData.ContainsKey("errcode") && jsonData["errcode"].ToString().ToInt() == 0;
      RoadFlow.Platform.Log.Add("调用了微信删除标签-" + group.Name + "-" + (flag ? "成功" : "失败"), "返回：" + json, RoadFlow.Platform.Log.Types.微信企业号, group.Serialize(), "", (RoadFlow.Data.Model.Users) null);
      return flag;
    }

    public void DeleteGroupAsync(RoadFlow.Data.Model.WorkGroup group)
    {
      new Organize.del_SaveWorkGroup(this.DeleteGroup).BeginInvoke(group, (AsyncCallback) null, (object) null);
    }

    public List<Tuple<string, string>> GetGroupUsers(int groupIntID)
    {
      string json = HttpHelper.SendGet("https://qyapi.weixin.qq.com/cgi-bin/tag/get?access_token=" + this.GetAccessToken() + "&tagid=" + groupIntID.ToString());
      JsonData jsonData1 = JsonMapper.ToObject(json);
      bool flag = jsonData1.ContainsKey("errcode") && jsonData1["errcode"].ToString().ToInt() == 0;
      List<Tuple<string, string>> tupleList = new List<Tuple<string, string>>();
      RoadFlow.Platform.Log.Add("调用了微信获取标签成员-" + (object) groupIntID + "-" + (flag ? (object) "成功" : (object) "失败"), "返回：" + json, RoadFlow.Platform.Log.Types.微信企业号, "", "", (RoadFlow.Data.Model.Users) null);
      if (flag)
      {
        JsonData jsonData2 = jsonData1["userlist"];
        if (jsonData2.IsArray)
        {
          foreach (JsonData jsonData3 in (IEnumerable) jsonData2)
          {
            string str1 = jsonData3["userid"].ToString();
            string str2 = jsonData3["name"].ToString();
            if (!str1.IsNullOrEmpty() && !str2.IsNullOrEmpty())
              tupleList.Add(new Tuple<string, string>(str1, str2));
          }
        }
      }
      return tupleList;
    }

    public bool AddGroupUser(RoadFlow.Data.Model.WorkGroup group)
    {
      string url = "https://qyapi.weixin.qq.com/cgi-bin/tag/addtagusers?access_token=" + this.GetAccessToken();
      if (group.Members.IsNullOrEmpty())
        return true;
      List<RoadFlow.Data.Model.Users> allUsers = new RoadFlow.Platform.Organize().GetAllUsers(group.Members);
      List<string> stringList = new List<string>();
      foreach (RoadFlow.Data.Model.Users users in allUsers)
        stringList.Add(users.Account);
      string userAccounts = Tools.GetSqlInString<string>(stringList.ToArray(), true).Replace("'", "\"");
      if (!this.DeleteGroupUser(group.IntID, userAccounts))
        return false;
      string str = "{\"tagid\":" + group.IntID.ToString() + ",\"userlist\":[" + userAccounts + "]}";
      string json = HttpHelper.SendPost(url, str);
      JsonData jsonData = JsonMapper.ToObject(json);
      bool flag = jsonData.ContainsKey("errcode") && jsonData["errcode"].ToString().ToInt() == 0;
      RoadFlow.Platform.Log.Add("调用了微信更新标签成员-" + (flag ? "成功" : "失败"), "返回：" + json, RoadFlow.Platform.Log.Types.微信企业号, str, "", (RoadFlow.Data.Model.Users) null);
      return flag;
    }

    public void AddGroupUserAsync(RoadFlow.Data.Model.WorkGroup group)
    {
      new Organize.del_SaveWorkGroup(this.AddGroupUser).BeginInvoke(group, (AsyncCallback) null, (object) null);
    }

    public bool DeleteGroupUser(int groupIntID, string userAccounts)
    {
      string url = "https://qyapi.weixin.qq.com/cgi-bin/tag/deltagusers?access_token=" + this.GetAccessToken();
      if (userAccounts.IsNullOrEmpty())
        return true;
      string str = "{\"tagid\":" + groupIntID.ToString() + ",\"userlist\":[" + userAccounts + "]}";
      string json = HttpHelper.SendPost(url, str);
      JsonData jsonData = JsonMapper.ToObject(json);
      bool flag = jsonData.ContainsKey("errcode") && jsonData["errcode"].ToString().ToInt() == 0;
      RoadFlow.Platform.Log.Add("调用了微信删除标签成员-" + (flag ? "成功" : "失败"), "返回：" + json, RoadFlow.Platform.Log.Types.微信企业号, str, "", (RoadFlow.Data.Model.Users) null);
      return flag;
    }

    public bool DeleteGroupUser(int groupIntID)
    {
      List<Tuple<string, string>> groupUsers = this.GetGroupUsers(groupIntID);
      if (groupUsers.Count <= 0)
        return true;
      StringBuilder stringBuilder = new StringBuilder();
      foreach (Tuple<string, string> tuple in groupUsers)
        stringBuilder.Append("\"" + tuple.Item1 + "\",");
      string url = "https://qyapi.weixin.qq.com/cgi-bin/tag/deltagusers?access_token=" + this.GetAccessToken();
      string str = "{\"tagid\":" + groupIntID.ToString() + ",\"userlist\":[" + stringBuilder.ToString().TrimEnd(',') + "]}";
      string json = HttpHelper.SendPost(url, str);
      JsonData jsonData = JsonMapper.ToObject(json);
      bool flag = jsonData.ContainsKey("errcode") && jsonData["errcode"].ToString().ToInt() == 0;
      RoadFlow.Platform.Log.Add("调用了微信删除标签成员-" + (flag ? "成功" : "失败"), "返回：" + json, RoadFlow.Platform.Log.Types.微信企业号, str, "", (RoadFlow.Data.Model.Users) null);
      return flag;
    }

    public List<Tuple<int, string>> GetGroups()
    {
      string json = HttpHelper.SendGet("https://qyapi.weixin.qq.com/cgi-bin/tag/list?access_token=" + this.GetAccessToken());
      JsonData jsonData1 = JsonMapper.ToObject(json);
      bool flag = jsonData1.ContainsKey("errcode") && jsonData1["errcode"].ToString().ToInt() == 0;
      RoadFlow.Platform.Log.Add("调用了微信所有标签-" + (flag ? "成功" : "失败"), "返回：" + json, RoadFlow.Platform.Log.Types.微信企业号, "", "", (RoadFlow.Data.Model.Users) null);
      List<Tuple<int, string>> tupleList = new List<Tuple<int, string>>();
      if (flag)
      {
        JsonData jsonData2 = jsonData1["taglist"];
        if (jsonData2.IsArray)
        {
          foreach (JsonData jsonData3 in (IEnumerable) jsonData2)
          {
            string str1 = jsonData3["tagid"].ToString();
            string str2 = jsonData3["tagname"].ToString();
            if (str1.IsInt() && !str2.IsNullOrEmpty())
              tupleList.Add(new Tuple<int, string>(str1.ToInt(), str2));
          }
        }
      }
      return tupleList;
    }

    public void UpdateAllOrganize()
    {
      RoadFlow.Platform.Organize organize1 = new RoadFlow.Platform.Organize();
      List<RoadFlow.Data.Model.Organize> all = organize1.GetAll();
      DataTable dt = new DataTable();
      dt.Columns.Add("部门名称", "".GetType());
      dt.Columns.Add("部门ID", 1.GetType());
      dt.Columns.Add("父部门ID", 1.GetType());
      dt.Columns.Add("排序", 1.GetType());
      foreach (RoadFlow.Data.Model.Organize organize2 in all)
      {
        int num = -1;
        if (organize2.ParentID.IsEmptyGuid())
        {
          num = 1;
        }
        else
        {
          RoadFlow.Data.Model.Organize organize3 = organize1.Get(organize2.ParentID);
          if (organize3 != null)
            num = organize3.IntID;
        }
        if (num != -1)
        {
          DataRow row = dt.NewRow();
          row["部门名称"] = (object) this.replaceName(organize2.Name);
          row["部门ID"] = (object) organize2.IntID;
          row["父部门ID"] = (object) num;
          row["排序"] = (object) organize2.Sort;
          dt.Rows.Add(row);
        }
      }
      string path = RoadFlow.Platform.Files.FilePath + "WeiXinCsv\\";
      if (!Directory.Exists(path))
        Directory.CreateDirectory(path);
      string str1 = path + Guid.NewGuid().ToString("N") + ".csv";
      NPOIHelper.ExportCSV(dt, str1);
      string str2 = new Media(Config.GetSecret("weixinagents_organize")).UploadTemp(str1, "file");
      if (str2.IsNullOrEmpty())
        return;
      string url = "https://qyapi.weixin.qq.com/cgi-bin/batch/replaceparty?access_token=" + this.GetAccessToken();
      string oldXML = "{\"media_id\":\"" + str2 + "\"}";
      string data = oldXML;
      RoadFlow.Platform.Log.Add("调用了微信同步整个组织架构", "返回：" + HttpHelper.SendPost(url, data), RoadFlow.Platform.Log.Types.微信企业号, oldXML, "", (RoadFlow.Data.Model.Users) null);
    }

    public void UpdateAllUsers()
    {
      RoadFlow.Platform.Organize organize1 = new RoadFlow.Platform.Organize();
      RoadFlow.Platform.UsersRelation usersRelation1 = new RoadFlow.Platform.UsersRelation();
      List<RoadFlow.Data.Model.Users> all = new RoadFlow.Platform.Users().GetAll();
      DataTable dt = new DataTable();
      dt.Columns.Add("姓名", "".GetType());
      dt.Columns.Add("帐号", "".GetType());
      dt.Columns.Add("微信号", "".GetType());
      dt.Columns.Add("手机号", "".GetType());
      dt.Columns.Add("邮箱", "".GetType());
      dt.Columns.Add("所在部门", "".GetType());
      dt.Columns.Add("职位", "".GetType());
      foreach (RoadFlow.Data.Model.Users users in all)
      {
        StringBuilder stringBuilder = new StringBuilder();
        foreach (RoadFlow.Data.Model.UsersRelation usersRelation2 in usersRelation1.GetAllByUserID(users.ID))
        {
          RoadFlow.Data.Model.Organize organize2 = organize1.Get(usersRelation2.OrganizeID);
          if (organize2 != null)
          {
            stringBuilder.Append(organize2.IntID);
            stringBuilder.Append(",");
          }
        }
        DataRow row = dt.NewRow();
        row["姓名"] = (object) this.replaceName(users.Name);
        row["帐号"] = (object) users.Account;
        row["微信号"] = (object) users.WeiXin;
        row["手机号"] = (object) users.Mobile;
        row["邮箱"] = (object) users.Email;
        row["所在部门"] = (object) stringBuilder.ToString().TrimEnd(',');
        row["职位"] = (object) "";
        dt.Rows.Add(row);
      }
      string path = RoadFlow.Platform.Files.FilePath + "WeiXinCsv\\";
      if (!Directory.Exists(path))
        Directory.CreateDirectory(path);
      string str1 = path + Guid.NewGuid().ToString("N") + ".csv";
      NPOIHelper.ExportCSV(dt, str1);
      string str2 = new Media(Config.GetSecret("weixinagents_organize")).UploadTemp(str1, "file");
      if (str2.IsNullOrEmpty())
        return;
      string url = "https://qyapi.weixin.qq.com/cgi-bin/batch/replaceuser?access_token=" + this.GetAccessToken();
      string oldXML = "{\"media_id\":\"" + str2 + "\"}";
      string data = oldXML;
      RoadFlow.Platform.Log.Add("调用了微信同步所有人员", "返回：" + HttpHelper.SendPost(url, data), RoadFlow.Platform.Log.Types.微信企业号, oldXML, "", (RoadFlow.Data.Model.Users) null);
    }

    public static Guid CurrentUserID
    {
      get
      {
        try
        {
          object obj = HttpContext.Current.Session[Keys.SessionKeys.UserID.ToString()];
          if (obj != null && obj.ToString().IsGuid())
            return obj.ToString().ToGuid();
          HttpCookie httpCookie = HttpContext.Current.Request.Cookies.Get("weixin_userid");
          if (httpCookie != null && httpCookie.Value.IsGuid())
            return httpCookie.Value.ToGuid();
          return Guid.Empty;
        }
        catch
        {
          return Guid.Empty;
        }
      }
    }

    public static string CurrentUserName
    {
      get
      {
        HttpCookie httpCookie = HttpContext.Current.Request.Cookies.Get("weixin_username");
        if (httpCookie != null)
          return httpCookie.Value;
        string name = new RoadFlow.Platform.Users().GetName(Organize.CurrentUserID);
        HttpContext.Current.Response.Cookies.Add(new HttpCookie("weixin_username", name));
        return name;
      }
    }

    public static RoadFlow.Data.Model.Users CurrentUser
    {
      get
      {
        return new RoadFlow.Platform.Users().Get(Organize.CurrentUserID);
      }
    }

    public static bool CheckLogin()
    {
      if (!Organize.CurrentUserID.IsEmptyGuid())
        return true;
      if (Config.IsUse)
      {
        HttpContext.Current.Response.Cookies.Add(new HttpCookie("LastURL", HttpContext.Current.Request.Url.PathAndQuery));
        HttpContext.Current.Response.Redirect("https://open.weixin.qq.com/connect/oauth2/authorize?appid=" + Config.CorpID + "&redirect_uri=" + Config.GetAccountUrl + "&response_type=code&scope=snsapi_base&state=a#wechat_redirect");
      }
      return false;
    }

    public string GetUserAccountByCode(string code)
    {
      if (Config.OrganizeSecret.IsNullOrEmpty())
      {
        List<RoadFlow.Data.Model.Dictionary> childs = new RoadFlow.Platform.Dictionary().GetChilds("weixinagents", false);
        if (childs.Count == 0)
          return "";
        this.secret = childs.OrderBy<RoadFlow.Data.Model.Dictionary, int>((Func<RoadFlow.Data.Model.Dictionary, int>) (p => p.Sort)).First<RoadFlow.Data.Model.Dictionary>().Note.Trim1();
      }
      else
        this.secret = Config.OrganizeSecret;
      string str1 = "https://qyapi.weixin.qq.com/cgi-bin/user/getuserinfo?access_token=" + this.GetAccessToken() + "&code=" + code;
      string str2 = HttpHelper.SendGet(str1);
      JsonData jsonData = JsonMapper.ToObject(str2);
      string str3 = jsonData.ContainsKey("UserId") ? jsonData["UserId"].ToString() : "";
      RoadFlow.Platform.Log.Add("调用了微信获取人员帐号", str1, RoadFlow.Platform.Log.Types.微信企业号, str2, "", (RoadFlow.Data.Model.Users) null);
      return str3;
    }

    private delegate bool del_Save(RoadFlow.Data.Model.Organize organize);

    private delegate bool del_SaveUser(RoadFlow.Data.Model.Users user);

    private delegate bool del_SaveWorkGroup(RoadFlow.Data.Model.WorkGroup wg);

    private delegate bool del_Delete(int orgID);

    private delegate bool del_DeleteUser(string account);

    private delegate bool del_DeleteUser1(string[] account);
  }
}
