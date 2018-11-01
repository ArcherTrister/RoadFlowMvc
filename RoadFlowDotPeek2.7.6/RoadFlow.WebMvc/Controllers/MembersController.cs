// Decompiled with JetBrains decompiler
// Type: WebMvc.Controllers.MembersController
// Assembly: WebMvc, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 43FD7615-6DC3-49FB-B263-7F7CC91AFA77
// Assembly location: C:\inetpub\wwwroot\RoadFlowMvc\bin\WebMvc.dll

using Microsoft.CSharp.RuntimeBinder;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Transactions;
using System.Web.Mvc;
using WebMvc.Common;

namespace WebMvc.Controllers
{
  public class MembersController : MyController
  {
    public ActionResult Index()
    {
      return (ActionResult) this.View();
    }

    [MyAttribute(CheckApp = false)]
    public ActionResult Tree()
    {
      return (ActionResult) this.View();
    }

    [MyAttribute(CheckApp = false, CheckLogin = false, CheckUrl = false)]
    public string Tree1()
    {
      string msg;
      if (!Tools.CheckLogin(out msg) && !RoadFlow.Platform.WeiXin.Organize.CheckLogin())
        return "";
      string str1 = this.Request.QueryString["rootid"] ?? "";
      string str2 = this.Request.QueryString["showtype"] ?? "";
      string searchword = this.Request.QueryString["searchword"] ?? "";
      RoadFlow.Platform.Organize organize1 = new RoadFlow.Platform.Organize();
      RoadFlow.Platform.WorkGroup workGroup1 = new RoadFlow.Platform.WorkGroup();
      RoadFlow.Platform.Users users1 = new RoadFlow.Platform.Users();
      StringBuilder stringBuilder = new StringBuilder("[", 1000);
      if (!searchword.IsNullOrEmpty())
      {
        if ("1" == str2)
        {
          List<RoadFlow.Data.Model.WorkGroup> all = workGroup1.GetAll().FindAll((Predicate<RoadFlow.Data.Model.WorkGroup>) (p => p.Name.Contains(searchword, StringComparison.CurrentCultureIgnoreCase)));
          stringBuilder.Append("{");
          stringBuilder.AppendFormat("\"id\":\"{0}\",", (object) Guid.Empty);
          stringBuilder.AppendFormat("\"parentID\":\"{0}\",", (object) Guid.Empty);
          stringBuilder.AppendFormat("\"title\":\"查询“{0}”的结果\",", (object) searchword);
          stringBuilder.AppendFormat("\"ico\":\"{0}\",", (object) this.Url.Content("~/images/ico/search.png"));
          stringBuilder.AppendFormat("\"link\":\"{0}\",", (object) "");
          stringBuilder.AppendFormat("\"type\":\"{0}\",", (object) 1);
          stringBuilder.AppendFormat("\"hasChilds\":\"{0}\",", (object) all.Count);
          stringBuilder.Append("\"childs\":[");
          int count = all.Count;
          int num = 0;
          foreach (RoadFlow.Data.Model.WorkGroup workGroup2 in all)
          {
            stringBuilder.Append("{");
            stringBuilder.AppendFormat("\"id\":\"{0}\",", (object) workGroup2.ID);
            stringBuilder.AppendFormat("\"parentID\":\"{0}\",", (object) Guid.Empty);
            stringBuilder.AppendFormat("\"title\":\"{0}\",", (object) workGroup2.Name);
            stringBuilder.AppendFormat("\"ico\":\"{0}\",", (object) "");
            stringBuilder.AppendFormat("\"link\":\"{0}\",", (object) "");
            stringBuilder.AppendFormat("\"type\":\"{0}\",", (object) 5);
            stringBuilder.AppendFormat("\"hasChilds\":\"{0}\",", (object) 0);
            stringBuilder.Append("\"childs\":[");
            stringBuilder.Append("]");
            stringBuilder.Append("}");
            if (num++ < count - 1)
              stringBuilder.Append(",");
          }
        }
        else
        {
          List<RoadFlow.Data.Model.Organize> all1 = organize1.GetAll().FindAll((Predicate<RoadFlow.Data.Model.Organize>) (p => p.Name.Contains(searchword, StringComparison.CurrentCultureIgnoreCase)));
          List<RoadFlow.Data.Model.Users> all2 = users1.GetAll().FindAll((Predicate<RoadFlow.Data.Model.Users>) (p => p.Name.Contains(searchword, StringComparison.CurrentCultureIgnoreCase)));
          stringBuilder.Append("{");
          stringBuilder.AppendFormat("\"id\":\"{0}\",", (object) Guid.Empty);
          stringBuilder.AppendFormat("\"parentID\":\"{0}\",", (object) Guid.Empty);
          stringBuilder.AppendFormat("\"title\":\"查询“{0}”的结果\",", (object) searchword);
          stringBuilder.AppendFormat("\"ico\":\"{0}\",", (object) this.Url.Content("~/images/ico/search.png"));
          stringBuilder.AppendFormat("\"link\":\"{0}\",", (object) "");
          stringBuilder.AppendFormat("\"type\":\"{0}\",", (object) 1);
          stringBuilder.AppendFormat("\"hasChilds\":\"{0}\",", (object) (all1.Count + all2.Count));
          stringBuilder.Append("\"childs\":[");
          foreach (RoadFlow.Data.Model.Organize organize2 in all1)
          {
            stringBuilder.Append("{");
            stringBuilder.AppendFormat("\"id\":\"{0}\",", (object) organize2.ID);
            stringBuilder.AppendFormat("\"parentID\":\"{0}\",", (object) Guid.Empty);
            stringBuilder.AppendFormat("\"title\":\"{0}\",", (object) organize2.Name);
            stringBuilder.AppendFormat("\"ico\":\"{0}\",", (object) "");
            stringBuilder.AppendFormat("\"link\":\"{0}\",", (object) "");
            stringBuilder.AppendFormat("\"type\":\"{0}\",", (object) organize2.Type);
            stringBuilder.AppendFormat("\"hasChilds\":\"{0}\",", (object) organize2.ChildsLength);
            stringBuilder.Append("\"childs\":[");
            stringBuilder.Append("]");
            stringBuilder.Append("}");
            if (organize2.ID != all1.Last<RoadFlow.Data.Model.Organize>().ID || all2.Count > 0)
              stringBuilder.Append(",");
          }
          foreach (RoadFlow.Data.Model.Users users2 in all2)
          {
            stringBuilder.Append("{");
            stringBuilder.AppendFormat("\"id\":\"{0}\",", (object) users2.ID);
            stringBuilder.AppendFormat("\"parentID\":\"{0}\",", (object) Guid.Empty);
            stringBuilder.AppendFormat("\"title\":\"{0}\",", (object) users2.Name);
            stringBuilder.AppendFormat("\"ico\":\"{0}\",", (object) this.Url.Content("~/images/ico/contact_grey.png"));
            stringBuilder.AppendFormat("\"link\":\"{0}\",", (object) "");
            stringBuilder.AppendFormat("\"type\":\"{0}\",", (object) "4");
            stringBuilder.AppendFormat("\"hasChilds\":\"{0}\",", (object) "0");
            stringBuilder.Append("\"childs\":[");
            stringBuilder.Append("]");
            stringBuilder.Append("}");
            if (users2.ID != all2.Last<RoadFlow.Data.Model.Users>().ID)
              stringBuilder.Append(",");
          }
        }
        stringBuilder.Append("]}]");
        return stringBuilder.ToString();
      }
      if ("1" == str2)
      {
        List<RoadFlow.Data.Model.WorkGroup> all = workGroup1.GetAll();
        stringBuilder.Append("{");
        stringBuilder.AppendFormat("\"id\":\"{0}\",", (object) Guid.Empty);
        stringBuilder.AppendFormat("\"parentID\":\"{0}\",", (object) Guid.Empty);
        stringBuilder.AppendFormat("\"title\":\"{0}\",", (object) "角色组");
        stringBuilder.AppendFormat("\"ico\":\"{0}\",", (object) this.Url.Content("~/images/ico/group.gif"));
        stringBuilder.AppendFormat("\"link\":\"{0}\",", (object) "");
        stringBuilder.AppendFormat("\"type\":\"{0}\",", (object) 5);
        stringBuilder.AppendFormat("\"hasChilds\":\"{0}\",", (object) all.Count);
        stringBuilder.Append("\"childs\":[");
        int count = all.Count;
        int num = 0;
        foreach (RoadFlow.Data.Model.WorkGroup workGroup2 in all)
        {
          List<RoadFlow.Data.Model.Users> allUsers = organize1.GetAllUsers("w_" + workGroup2.ID.ToString());
          stringBuilder.Append("{");
          stringBuilder.AppendFormat("\"id\":\"{0}\",", (object) workGroup2.ID);
          stringBuilder.AppendFormat("\"parentID\":\"{0}\",", (object) Guid.Empty);
          stringBuilder.AppendFormat("\"title\":\"{0}\",", (object) workGroup2.Name);
          stringBuilder.AppendFormat("\"ico\":\"{0}\",", (object) "");
          stringBuilder.AppendFormat("\"link\":\"{0}\",", (object) "");
          stringBuilder.AppendFormat("\"type\":\"{0}\",", (object) 5);
          stringBuilder.AppendFormat("\"hasChilds\":\"{0}\",", (object) allUsers.Count);
          stringBuilder.Append("\"childs\":[");
          stringBuilder.Append("]");
          stringBuilder.Append("}");
          if (num++ < count - 1)
            stringBuilder.Append(",");
        }
        stringBuilder.Append("]");
        stringBuilder.Append("}");
        stringBuilder.Append("]");
        this.Response.Write(stringBuilder.ToString());
        this.Response.End();
        return "";
      }
      if (str1.IsNullOrEmpty())
        str1 = organize1.GetRoot().ID.ToString();
      string[] strArray = str1.Split(new string[1]{ "," }, StringSplitOptions.RemoveEmptyEntries);
      int num1 = 0;
      foreach (string str3 in strArray)
      {
        List<RoadFlow.Data.Model.Users> usersList = new List<RoadFlow.Data.Model.Users>();
        Guid test = Guid.Empty;
        if (str3.IsGuid(out test))
        {
          RoadFlow.Data.Model.Organize organize2 = organize1.Get(test);
          if (organize2 != null)
          {
            usersList = users1.GetAllByOrganizeID(test);
            stringBuilder.Append("{");
            stringBuilder.AppendFormat("\"id\":\"{0}\",", (object) organize2.ID);
            stringBuilder.AppendFormat("\"parentID\":\"{0}\",", (object) organize2.ParentID);
            stringBuilder.AppendFormat("\"title\":\"{0}\",", (object) organize2.Name);
            stringBuilder.AppendFormat("\"ico\":\"{0}\",", strArray.Length == 1 ? (object) this.Url.Content("~/images/ico/icon_site.gif") : (object) "");
            stringBuilder.AppendFormat("\"link\":\"{0}\",", (object) "");
            stringBuilder.AppendFormat("\"type\":\"{0}\",", (object) organize2.Type);
            stringBuilder.AppendFormat("\"hasChilds\":\"{0}\",", organize2.ChildsLength != 0 || usersList.Count != 0 ? (object) "1" : (object) "0");
            stringBuilder.Append("\"childs\":[");
          }
        }
        else if (str3.StartsWith("u_"))
        {
          RoadFlow.Data.Model.Users users2 = users1.Get(users1.RemovePrefix1(str3).ToGuid());
          if (users2 != null)
          {
            stringBuilder.Append("{");
            stringBuilder.AppendFormat("\"id\":\"{0}\",", (object) users2.ID);
            stringBuilder.AppendFormat("\"parentID\":\"{0}\",", (object) Guid.Empty);
            stringBuilder.AppendFormat("\"title\":\"{0}\",", (object) users2.Name);
            stringBuilder.AppendFormat("\"ico\":\"{0}\",", (object) this.Url.Content("~/images/ico/contact_grey.png"));
            stringBuilder.AppendFormat("\"link\":\"{0}\",", (object) "");
            stringBuilder.AppendFormat("\"type\":\"{0}\",", (object) "4");
            stringBuilder.AppendFormat("\"hasChilds\":\"{0}\",", (object) "0");
            stringBuilder.Append("\"childs\":[");
          }
        }
        else if (str3.StartsWith("w_"))
        {
          RoadFlow.Data.Model.WorkGroup workGroup2 = workGroup1.Get(workGroup1.RemovePrefix1(str3).ToGuid());
          if (workGroup2 != null)
          {
            usersList = organize1.GetAllUsers(str3);
            stringBuilder.Append("{");
            stringBuilder.AppendFormat("\"id\":\"{0}\",", (object) workGroup2.ID);
            stringBuilder.AppendFormat("\"parentID\":\"{0}\",", (object) Guid.Empty);
            stringBuilder.AppendFormat("\"title\":\"{0}\",", (object) workGroup2.Name);
            stringBuilder.AppendFormat("\"ico\":\"{0}\",", (object) "");
            stringBuilder.AppendFormat("\"link\":\"{0}\",", (object) "");
            stringBuilder.AppendFormat("\"type\":\"{0}\",", (object) "5");
            stringBuilder.AppendFormat("\"hasChilds\":\"{0}\",", usersList.Count > 0 ? (object) "1" : (object) "0");
            stringBuilder.Append("\"childs\":[");
          }
        }
        if (strArray.Length == 1)
        {
          List<RoadFlow.Data.Model.Organize> organizeList = str3.IsGuid() ? organize1.GetChilds(test) : new List<RoadFlow.Data.Model.Organize>();
          int count1 = organizeList.Count;
          int num2 = 0;
          foreach (RoadFlow.Data.Model.Organize organize2 in organizeList)
          {
            stringBuilder.Append("{");
            stringBuilder.AppendFormat("\"id\":\"{0}\",", (object) organize2.ID);
            stringBuilder.AppendFormat("\"parentID\":\"{0}\",", (object) organize2.ParentID);
            stringBuilder.AppendFormat("\"title\":\"{0}\",", (object) organize2.Name);
            stringBuilder.AppendFormat("\"ico\":\"{0}\",", (object) "");
            stringBuilder.AppendFormat("\"link\":\"{0}\",", (object) "");
            stringBuilder.AppendFormat("\"type\":\"{0}\",", (object) organize2.Type);
            stringBuilder.AppendFormat("\"hasChilds\":\"{0}\",", (object) organize2.ChildsLength);
            stringBuilder.Append("\"childs\":[");
            stringBuilder.Append("]");
            stringBuilder.Append("}");
            if (num2++ < count1 - 1 || usersList.Count > 0)
              stringBuilder.Append(",");
          }
          if (usersList.Count > 0)
          {
            List<RoadFlow.Data.Model.UsersRelation> allByOrganizeId = new RoadFlow.Platform.UsersRelation().GetAllByOrganizeID(test);
            int count2 = usersList.Count;
            int num3 = 0;
            foreach (RoadFlow.Data.Model.Users users2 in usersList)
            {
              RoadFlow.Data.Model.Users user = users2;
              RoadFlow.Data.Model.UsersRelation usersRelation = allByOrganizeId.Find((Predicate<RoadFlow.Data.Model.UsersRelation>) (p => p.UserID == user.ID));
              stringBuilder.Append("{");
              stringBuilder.AppendFormat("\"id\":\"{0}\",", (object) user.ID);
              stringBuilder.AppendFormat("\"parentID\":\"{0}\",", (object) test);
              stringBuilder.AppendFormat("\"title\":\"{0}{1}\",", (object) user.Name, usersRelation == null || usersRelation.IsMain != 0 ? (object) "" : (object) "<span style='color:#999;'>[兼任]</span>");
              stringBuilder.AppendFormat("\"ico\":\"{0}\",", (object) this.Url.Content("~/images/ico/contact_grey.png"));
              stringBuilder.AppendFormat("\"link\":\"{0}\",", (object) "");
              stringBuilder.AppendFormat("\"type\":\"{0}\",", (object) "4");
              stringBuilder.AppendFormat("\"hasChilds\":\"{0}\",", (object) "0");
              stringBuilder.Append("\"childs\":[");
              stringBuilder.Append("]");
              stringBuilder.Append("}");
              if (num3++ < count2 - 1)
                stringBuilder.Append(",");
            }
          }
        }
        stringBuilder.Append("]");
        stringBuilder.Append("}");
        if (num1++ < strArray.Length - 1)
          stringBuilder.Append(",");
      }
      stringBuilder.Append("]");
      return stringBuilder.ToString();
    }

    [MyAttribute(CheckApp = false, CheckLogin = false, CheckUrl = false)]
    public string TreeRefresh()
    {
      string msg;
      if (!Tools.CheckLogin(out msg) && !RoadFlow.Platform.WeiXin.Organize.CheckLogin())
        return "";
      string str1 = this.Request.QueryString["refreshid"] ?? "";
      string str2 = this.Request.QueryString["showtype"] ?? "";
      string str3 = this.Request.QueryString["type"] ?? "";
      RoadFlow.Platform.Organize organize1 = new RoadFlow.Platform.Organize();
      StringBuilder stringBuilder = new StringBuilder("[", 1000);
      if ("1" == str2)
      {
        List<RoadFlow.Data.Model.Users> allUsers = organize1.GetAllUsers("w_" + str1);
        foreach (RoadFlow.Data.Model.Users users in allUsers)
        {
          stringBuilder.Append("{");
          stringBuilder.AppendFormat("\"id\":\"{0}\",", (object) users.ID);
          stringBuilder.AppendFormat("\"parentID\":\"w_{0}\",", (object) str1);
          stringBuilder.AppendFormat("\"title\":\"{0}\",", (object) users.Name);
          stringBuilder.AppendFormat("\"ico\":\"{0}\",", (object) this.Url.Content("~/images/ico/contact_grey.png"));
          stringBuilder.AppendFormat("\"link\":\"{0}\",", (object) "");
          stringBuilder.AppendFormat("\"type\":\"{0}\",", (object) "4");
          stringBuilder.AppendFormat("\"hasChilds\":\"{0}\",", (object) "0");
          stringBuilder.Append("\"childs\":[");
          stringBuilder.Append("]");
          stringBuilder.Append("}");
          if (users.ID != allUsers.Last<RoadFlow.Data.Model.Users>().ID)
            stringBuilder.Append(",");
        }
        stringBuilder.Append("]");
        this.Response.Write(stringBuilder.ToString());
        this.Response.End();
        return "";
      }
      Guid test;
      if (!str1.IsGuid(out test))
      {
        stringBuilder.Append("]");
        return stringBuilder.ToString();
      }
      List<RoadFlow.Data.Model.Organize> childs = organize1.GetChilds(test);
      int count1 = childs.Count;
      int num1 = 0;
      foreach (RoadFlow.Data.Model.Organize organize2 in childs)
      {
        stringBuilder.Append("{");
        stringBuilder.AppendFormat("\"id\":\"{0}\",", (object) organize2.ID);
        stringBuilder.AppendFormat("\"parentID\":\"{0}\",", (object) str1);
        stringBuilder.AppendFormat("\"title\":\"{0}\",", (object) organize2.Name);
        stringBuilder.AppendFormat("\"ico\":\"{0}\",", (object) "");
        stringBuilder.AppendFormat("\"link\":\"{0}\",", (object) "");
        stringBuilder.AppendFormat("\"type\":\"{0}\",", (object) organize2.Type);
        stringBuilder.AppendFormat("\"hasChilds\":\"{0}\",", (object) organize2.ChildsLength);
        stringBuilder.Append("\"childs\":[");
        stringBuilder.Append("]");
        stringBuilder.Append("}");
        if (num1++ < count1 - 1)
          stringBuilder.Append(",");
      }
      List<RoadFlow.Data.Model.UsersRelation> allByOrganizeId = new RoadFlow.Platform.UsersRelation().GetAllByOrganizeID(test);
      List<RoadFlow.Data.Model.Users> usersList = "5" == str3 ? organize1.GetAllUsers("w_" + str1) : new RoadFlow.Platform.Users().GetAllByOrganizeID(test);
      int count2 = usersList.Count;
      if (count2 > 0 && count1 > 0)
        stringBuilder.Append(",");
      int num2 = 0;
      foreach (RoadFlow.Data.Model.Users users in usersList)
      {
        RoadFlow.Data.Model.Users user = users;
        RoadFlow.Data.Model.UsersRelation usersRelation = allByOrganizeId.Find((Predicate<RoadFlow.Data.Model.UsersRelation>) (p => p.UserID == user.ID));
        stringBuilder.Append("{");
        stringBuilder.AppendFormat("\"id\":\"{0}\",", (object) user.ID);
        stringBuilder.AppendFormat("\"parentID\":\"{0}\",", (object) str1);
        stringBuilder.AppendFormat("\"title\":\"{0}{1}\",", (object) user.Name, usersRelation == null || usersRelation.IsMain != 0 ? (object) "" : (object) "<span style='color:#999;'>[兼任]</span>");
        stringBuilder.AppendFormat("\"ico\":\"{0}\",", (object) this.Url.Content("~/images/ico/contact_grey.png"));
        stringBuilder.AppendFormat("\"link\":\"{0}\",", (object) "");
        stringBuilder.AppendFormat("\"type\":\"{0}\",", (object) "4");
        stringBuilder.AppendFormat("\"hasChilds\":\"{0}\",", (object) "0");
        stringBuilder.Append("\"childs\":[");
        stringBuilder.Append("]");
        stringBuilder.Append("}");
        if (num2++ < count2 - 1)
          stringBuilder.Append(",");
      }
      stringBuilder.Append("]");
      return stringBuilder.ToString();
    }

    public ActionResult Empty()
    {
      return (ActionResult) this.View();
    }

    public ActionResult Body()
    {
      return this.Body((FormCollection) null);
    }

    [HttpPost]
    [ValidateAntiForgeryToken]
    public ActionResult Body(FormCollection collection)
    {
      RoadFlow.Data.Model.Organize organize1 = (RoadFlow.Data.Model.Organize) null;
      RoadFlow.Platform.Organize organize2 = new RoadFlow.Platform.Organize();
      string str1 = this.Request.QueryString["id"];
      if (str1.IsGuid())
        organize1 = organize2.Get(str1.ToGuid());
      Guid guid;
      if (!this.Request.Form["Save"].IsNullOrEmpty() && organize1 != null)
      {
        string str2 = this.Request.Form["Name"];
        string str3 = this.Request.Form["Type"];
        string str4 = this.Request.Form["Status"];
        string str5 = this.Request.Form["ChargeLeader"];
        string str6 = this.Request.Form["Leader"];
        string str7 = this.Request.Form["note"];
        string oldXML = organize1.Serialize();
        organize1.Name = str2.Trim();
        organize1.Type = str3.ToInt(1);
        organize1.Status = str4.ToInt(0);
        organize1.ChargeLeader = str5;
        organize1.Leader = str6;
        organize1.Note = str7.IsNullOrEmpty() ? (string) null : str7.Trim();
        organize2.Update(organize1);
        if (RoadFlow.Platform.WeiXin.Config.IsUse)
          new RoadFlow.Platform.WeiXin.Organize().EditDeptAsync(organize1);
        new RoadFlow.Platform.MenuUser().ClearCache();
        RoadFlow.Platform.Log.Add("修改了组织机构", "", RoadFlow.Platform.Log.Types.组织机构, oldXML, organize1.Serialize(), (RoadFlow.Data.Model.Users) null);
        string str8;
        if (!(organize1.ParentID == Guid.Empty))
        {
          guid = organize1.ParentID;
          str8 = guid.ToString();
        }
        else
        {
          guid = organize1.ID;
          str8 = guid.ToString();
        }
        string str9 = str8;
        // ISSUE: reference to a compiler-generated field
        if (MembersController.\u003C\u003Eo__6.\u003C\u003Ep__0 == null)
        {
          // ISSUE: reference to a compiler-generated field
          MembersController.\u003C\u003Eo__6.\u003C\u003Ep__0 = CallSite<Func<CallSite, object, string, object>>.Create(Binder.SetMember(CSharpBinderFlags.None, "Script", typeof (MembersController), (IEnumerable<CSharpArgumentInfo>) new CSharpArgumentInfo[2]
          {
            CSharpArgumentInfo.Create(CSharpArgumentInfoFlags.None, (string) null),
            CSharpArgumentInfo.Create(CSharpArgumentInfoFlags.UseCompileTimeType, (string) null)
          }));
        }
        // ISSUE: reference to a compiler-generated field
        // ISSUE: reference to a compiler-generated field
        object obj = MembersController.\u003C\u003Eo__6.\u003C\u003Ep__0.Target((CallSite) MembersController.\u003C\u003Eo__6.\u003C\u003Ep__0, this.ViewBag, "alert('保存成功!');parent.frames[0].reLoad('" + str9 + "');");
      }
      if (!this.Request.Form["Move1"].IsNullOrEmpty() && organize1 != null)
      {
        string str2 = this.Request.Form["deptmove"];
        Guid test;
        if (str2.IsGuid(out test) && organize2.Move(organize1.ID, test))
        {
          new RoadFlow.Platform.MenuUser().ClearCache();
          new RoadFlow.Platform.HomeItems().ClearCache();
          RoadFlow.Platform.Log.Add("移动了组织机构", "将机构：" + (object) organize1.ID + "移动到了：" + (object) test, RoadFlow.Platform.Log.Types.组织机构, "", "", (RoadFlow.Data.Model.Users) null);
          string str3;
          if (!(organize1.ParentID == Guid.Empty))
          {
            guid = organize1.ParentID;
            str3 = guid.ToString();
          }
          else
          {
            guid = organize1.ID;
            str3 = guid.ToString();
          }
          string str4 = str3;
          // ISSUE: reference to a compiler-generated field
          if (MembersController.\u003C\u003Eo__6.\u003C\u003Ep__1 == null)
          {
            // ISSUE: reference to a compiler-generated field
            MembersController.\u003C\u003Eo__6.\u003C\u003Ep__1 = CallSite<Func<CallSite, object, string, object>>.Create(Binder.SetMember(CSharpBinderFlags.None, "Script", typeof (MembersController), (IEnumerable<CSharpArgumentInfo>) new CSharpArgumentInfo[2]
            {
              CSharpArgumentInfo.Create(CSharpArgumentInfoFlags.None, (string) null),
              CSharpArgumentInfo.Create(CSharpArgumentInfoFlags.UseCompileTimeType, (string) null)
            }));
          }
          // ISSUE: reference to a compiler-generated field
          // ISSUE: reference to a compiler-generated field
          object obj = MembersController.\u003C\u003Eo__6.\u003C\u003Ep__1.Target((CallSite) MembersController.\u003C\u003Eo__6.\u003C\u003Ep__1, this.ViewBag, "alert('移动成功!');parent.frames[0].reLoad('" + str4 + "');parent.frames[0].reLoad('" + str2 + "')");
        }
        else
        {
          // ISSUE: reference to a compiler-generated field
          if (MembersController.\u003C\u003Eo__6.\u003C\u003Ep__2 == null)
          {
            // ISSUE: reference to a compiler-generated field
            MembersController.\u003C\u003Eo__6.\u003C\u003Ep__2 = CallSite<Func<CallSite, object, string, object>>.Create(Binder.SetMember(CSharpBinderFlags.None, "Script", typeof (MembersController), (IEnumerable<CSharpArgumentInfo>) new CSharpArgumentInfo[2]
            {
              CSharpArgumentInfo.Create(CSharpArgumentInfoFlags.None, (string) null),
              CSharpArgumentInfo.Create(CSharpArgumentInfoFlags.UseCompileTimeType | CSharpArgumentInfoFlags.Constant, (string) null)
            }));
          }
          // ISSUE: reference to a compiler-generated field
          // ISSUE: reference to a compiler-generated field
          object obj = MembersController.\u003C\u003Eo__6.\u003C\u003Ep__2.Target((CallSite) MembersController.\u003C\u003Eo__6.\u003C\u003Ep__2, this.ViewBag, "alert('移动失败!');");
        }
      }
      if (!this.Request.Form["Delete"].IsNullOrEmpty())
      {
        int num = organize2.DeleteAndAllChilds(organize1.ID);
        new RoadFlow.Platform.MenuUser().ClearCache();
        new RoadFlow.Platform.HomeItems().ClearCache();
        RoadFlow.Platform.Log.Add("删除了组织机构及其所有下级共" + num.ToString() + "项", organize1.Serialize(), RoadFlow.Platform.Log.Types.组织机构, "", "", (RoadFlow.Data.Model.Users) null);
        string str2;
        if (!(organize1.ParentID == Guid.Empty))
        {
          guid = organize1.ParentID;
          str2 = guid.ToString();
        }
        else
        {
          guid = organize1.ID;
          str2 = guid.ToString();
        }
        string str3 = str2;
        // ISSUE: reference to a compiler-generated field
        if (MembersController.\u003C\u003Eo__6.\u003C\u003Ep__3 == null)
        {
          // ISSUE: reference to a compiler-generated field
          MembersController.\u003C\u003Eo__6.\u003C\u003Ep__3 = CallSite<Func<CallSite, object, string, object>>.Create(Binder.SetMember(CSharpBinderFlags.None, "Script", typeof (MembersController), (IEnumerable<CSharpArgumentInfo>) new CSharpArgumentInfo[2]
          {
            CSharpArgumentInfo.Create(CSharpArgumentInfoFlags.None, (string) null),
            CSharpArgumentInfo.Create(CSharpArgumentInfoFlags.UseCompileTimeType, (string) null)
          }));
        }
        // ISSUE: reference to a compiler-generated field
        // ISSUE: reference to a compiler-generated field
        object obj = MembersController.\u003C\u003Eo__6.\u003C\u003Ep__3.Target((CallSite) MembersController.\u003C\u003Eo__6.\u003C\u003Ep__3, this.ViewBag, "alert('共删除了" + num.ToString() + "项!');parent.frames[0].reLoad('" + str3 + "');");
      }
      if (!this.Request.Form["ToWeiXin"].IsNullOrEmpty())
      {
        RoadFlow.Platform.WeiXin.Organize organize3 = new RoadFlow.Platform.WeiXin.Organize();
        organize3.UpdateAllOrganize();
        organize3.UpdateAllUsers();
        // ISSUE: reference to a compiler-generated field
        if (MembersController.\u003C\u003Eo__6.\u003C\u003Ep__4 == null)
        {
          // ISSUE: reference to a compiler-generated field
          MembersController.\u003C\u003Eo__6.\u003C\u003Ep__4 = CallSite<Func<CallSite, object, string, object>>.Create(Binder.SetMember(CSharpBinderFlags.None, "script", typeof (MembersController), (IEnumerable<CSharpArgumentInfo>) new CSharpArgumentInfo[2]
          {
            CSharpArgumentInfo.Create(CSharpArgumentInfoFlags.None, (string) null),
            CSharpArgumentInfo.Create(CSharpArgumentInfoFlags.UseCompileTimeType | CSharpArgumentInfoFlags.Constant, (string) null)
          }));
        }
        // ISSUE: reference to a compiler-generated field
        // ISSUE: reference to a compiler-generated field
        object obj = MembersController.\u003C\u003Eo__6.\u003C\u003Ep__4.Target((CallSite) MembersController.\u003C\u003Eo__6.\u003C\u003Ep__4, this.ViewBag, "alert('同步完成!');window.location=window.location;");
      }
      if (organize1 == null)
        organize1 = new RoadFlow.Data.Model.Organize();
      // ISSUE: reference to a compiler-generated field
      if (MembersController.\u003C\u003Eo__6.\u003C\u003Ep__5 == null)
      {
        // ISSUE: reference to a compiler-generated field
        MembersController.\u003C\u003Eo__6.\u003C\u003Ep__5 = CallSite<Func<CallSite, object, string, object>>.Create(Binder.SetMember(CSharpBinderFlags.None, "TypeRadios", typeof (MembersController), (IEnumerable<CSharpArgumentInfo>) new CSharpArgumentInfo[2]
        {
          CSharpArgumentInfo.Create(CSharpArgumentInfoFlags.None, (string) null),
          CSharpArgumentInfo.Create(CSharpArgumentInfoFlags.UseCompileTimeType, (string) null)
        }));
      }
      // ISSUE: reference to a compiler-generated field
      // ISSUE: reference to a compiler-generated field
      object obj1 = MembersController.\u003C\u003Eo__6.\u003C\u003Ep__5.Target((CallSite) MembersController.\u003C\u003Eo__6.\u003C\u003Ep__5, this.ViewBag, organize2.GetTypeRadio("Type", organize1.Type.ToString(), "validate=\"radio\""));
      // ISSUE: reference to a compiler-generated field
      if (MembersController.\u003C\u003Eo__6.\u003C\u003Ep__6 == null)
      {
        // ISSUE: reference to a compiler-generated field
        MembersController.\u003C\u003Eo__6.\u003C\u003Ep__6 = CallSite<Func<CallSite, object, string, object>>.Create(Binder.SetMember(CSharpBinderFlags.None, "StatusRadios", typeof (MembersController), (IEnumerable<CSharpArgumentInfo>) new CSharpArgumentInfo[2]
        {
          CSharpArgumentInfo.Create(CSharpArgumentInfoFlags.None, (string) null),
          CSharpArgumentInfo.Create(CSharpArgumentInfoFlags.UseCompileTimeType, (string) null)
        }));
      }
      // ISSUE: reference to a compiler-generated field
      // ISSUE: reference to a compiler-generated field
      object obj2 = MembersController.\u003C\u003Eo__6.\u003C\u003Ep__6.Target((CallSite) MembersController.\u003C\u003Eo__6.\u003C\u003Ep__6, this.ViewBag, organize2.GetStatusRadio("Status", organize1.Status.ToString(), "validate=\"radio\""));
      return (ActionResult) this.View((object) organize1);
    }

    public ActionResult BodyAdd()
    {
      return this.BodyAdd((FormCollection) null);
    }

    [HttpPost]
    [ValidateAntiForgeryToken]
    public ActionResult BodyAdd(FormCollection collection)
    {
      RoadFlow.Platform.Organize organize1 = new RoadFlow.Platform.Organize();
      RoadFlow.Data.Model.Organize organize2 = (RoadFlow.Data.Model.Organize) null;
      string str1 = this.Request.QueryString["id"];
      string empty1 = string.Empty;
      string empty2 = string.Empty;
      string empty3 = string.Empty;
      string empty4 = string.Empty;
      Guid test;
      if (str1.IsGuid(out test))
        organize2 = organize1.Get(test);
      if (collection != null && organize2 != null)
      {
        string str2 = this.Request.Form["Name"];
        empty2 = this.Request.Form["Type"];
        string str3 = this.Request.Form["Status"];
        string str4 = this.Request.Form["note"];
        RoadFlow.Data.Model.Organize organize3 = new RoadFlow.Data.Model.Organize();
        Guid guid = Guid.NewGuid();
        organize3.ID = guid;
        organize3.Name = str2.Trim();
        organize3.Note = str4.IsNullOrEmpty() ? (string) null : str4.Trim();
        organize3.Number = organize2.Number + "," + guid.ToString().ToLower();
        organize3.ParentID = organize2.ID;
        organize3.Sort = organize1.GetMaxSort(organize2.ID);
        organize3.Status = str3.IsInt() ? str3.ToInt() : 0;
        organize3.Type = empty2.ToInt();
        organize3.Depth = organize2.Depth + 1;
        organize3.IntID = guid.ToInt32();
        using (TransactionScope transactionScope = new TransactionScope())
        {
          organize1.Add(organize3);
          organize1.UpdateChildsLength(organize2.ID);
          transactionScope.Complete();
        }
        if (RoadFlow.Platform.WeiXin.Config.IsUse)
          new RoadFlow.Platform.WeiXin.Organize().AddDeptAsync(organize3);
        new RoadFlow.Platform.MenuUser().ClearCache();
        RoadFlow.Platform.Log.Add("添加了组织机构", organize3.Serialize(), RoadFlow.Platform.Log.Types.组织机构, "", "", (RoadFlow.Data.Model.Users) null);
        // ISSUE: reference to a compiler-generated field
        if (MembersController.\u003C\u003Eo__8.\u003C\u003Ep__0 == null)
        {
          // ISSUE: reference to a compiler-generated field
          MembersController.\u003C\u003Eo__8.\u003C\u003Ep__0 = CallSite<Func<CallSite, object, string, object>>.Create(Binder.SetMember(CSharpBinderFlags.None, "Script", typeof (MembersController), (IEnumerable<CSharpArgumentInfo>) new CSharpArgumentInfo[2]
          {
            CSharpArgumentInfo.Create(CSharpArgumentInfoFlags.None, (string) null),
            CSharpArgumentInfo.Create(CSharpArgumentInfoFlags.UseCompileTimeType, (string) null)
          }));
        }
        // ISSUE: reference to a compiler-generated field
        // ISSUE: reference to a compiler-generated field
        object obj = MembersController.\u003C\u003Eo__8.\u003C\u003Ep__0.Target((CallSite) MembersController.\u003C\u003Eo__8.\u003C\u003Ep__0, this.ViewBag, "alert('添加成功!');parent.frames[0].reLoad('" + str1 + "');window.location=window.location;");
      }
      // ISSUE: reference to a compiler-generated field
      if (MembersController.\u003C\u003Eo__8.\u003C\u003Ep__1 == null)
      {
        // ISSUE: reference to a compiler-generated field
        MembersController.\u003C\u003Eo__8.\u003C\u003Ep__1 = CallSite<Func<CallSite, object, string, object>>.Create(Binder.SetMember(CSharpBinderFlags.None, "TypeRadios", typeof (MembersController), (IEnumerable<CSharpArgumentInfo>) new CSharpArgumentInfo[2]
        {
          CSharpArgumentInfo.Create(CSharpArgumentInfoFlags.None, (string) null),
          CSharpArgumentInfo.Create(CSharpArgumentInfoFlags.UseCompileTimeType, (string) null)
        }));
      }
      // ISSUE: reference to a compiler-generated field
      // ISSUE: reference to a compiler-generated field
      object obj1 = MembersController.\u003C\u003Eo__8.\u003C\u003Ep__1.Target((CallSite) MembersController.\u003C\u003Eo__8.\u003C\u003Ep__1, this.ViewBag, organize1.GetTypeRadio("Type", empty2, "validate=\"radio\""));
      // ISSUE: reference to a compiler-generated field
      if (MembersController.\u003C\u003Eo__8.\u003C\u003Ep__2 == null)
      {
        // ISSUE: reference to a compiler-generated field
        MembersController.\u003C\u003Eo__8.\u003C\u003Ep__2 = CallSite<Func<CallSite, object, string, object>>.Create(Binder.SetMember(CSharpBinderFlags.None, "StatusRadios", typeof (MembersController), (IEnumerable<CSharpArgumentInfo>) new CSharpArgumentInfo[2]
        {
          CSharpArgumentInfo.Create(CSharpArgumentInfoFlags.None, (string) null),
          CSharpArgumentInfo.Create(CSharpArgumentInfoFlags.UseCompileTimeType, (string) null)
        }));
      }
      // ISSUE: reference to a compiler-generated field
      // ISSUE: reference to a compiler-generated field
      object obj2 = MembersController.\u003C\u003Eo__8.\u003C\u003Ep__2.Target((CallSite) MembersController.\u003C\u003Eo__8.\u003C\u003Ep__2, this.ViewBag, organize1.GetStatusRadio("Status", "0", "validate=\"radio\""));
      return (ActionResult) this.View();
    }

    public ActionResult UserAdd()
    {
      return this.UserAdd((FormCollection) null);
    }

    [HttpPost]
    [ValidateAntiForgeryToken]
    public ActionResult UserAdd(FormCollection collection)
    {
      RoadFlow.Platform.Organize organize = new RoadFlow.Platform.Organize();
      RoadFlow.Platform.Users users1 = new RoadFlow.Platform.Users();
      string str1 = this.Request.QueryString["id"];
      string empty1 = string.Empty;
      string empty2 = string.Empty;
      string empty3 = string.Empty;
      string empty4 = string.Empty;
      string empty5 = string.Empty;
      Guid test;
      if (collection != null && str1.IsGuid(out test))
      {
        string str2 = this.Request.Form["Name"];
        string str3 = this.Request.Form["Account"];
        string str4 = this.Request.Form["Status"];
        string str5 = this.Request.Form["Note"];
        string str6 = this.Request.Form["Tel"];
        string str7 = this.Request.Form["Mobile"];
        string str8 = this.Request.Form["WeiXin"];
        string str9 = this.Request.Form["Email"];
        string str10 = this.Request.Form["Fax"];
        string str11 = this.Request.Form["QQ"];
        string str12 = this.Request.Form["OtherTel"];
        string str13 = this.Request.Form["Sex"];
        Guid guid = Guid.NewGuid();
        string contents = string.Empty;
        using (TransactionScope transactionScope = new TransactionScope())
        {
          RoadFlow.Data.Model.Users users2 = new RoadFlow.Data.Model.Users() { Account = str3.Trim(), Name = str2.Trim(), Note = str5.IsNullOrEmpty() ? (string) null : str5, Password = users1.GetUserEncryptionPassword(guid.ToString(), users1.GetInitPassword()), Sort = 1, Status = str4.IsInt() ? str4.ToInt() : 0, ID = guid, Tel = str6.Trim1(), Mobile = str7.Trim1(), WeiXin = str8.Trim1() };
          users2.WeiXin = str8.Trim1();
          users2.Email = str9.Trim1();
          users2.Fax = str10.Trim1();
          users2.QQ = str11.Trim1();
          users2.OtherTel = str12.Trim1();
          if (str13.IsInt())
            users2.Sex = new int?(str13.ToInt());
          users1.Add(users2);
          new RoadFlow.Platform.UsersRelation().Add(new RoadFlow.Data.Model.UsersRelation()
          {
            IsMain = 1,
            OrganizeID = test,
            Sort = new RoadFlow.Platform.UsersRelation().GetMaxSort(test),
            UserID = guid
          });
          organize.UpdateChildsLength(test);
          if (RoadFlow.Platform.WeiXin.Config.IsUse)
            new RoadFlow.Platform.WeiXin.Organize().AddUserAsync(users2);
          contents = users2.Serialize();
          transactionScope.Complete();
        }
        new RoadFlow.Platform.MenuUser().ClearCache();
        new RoadFlow.Platform.HomeItems().ClearCache();
        new RoadFlow.Platform.DocumentDirectory().ClearAllDirUsersCache();
        RoadFlow.Platform.Log.Add("添加了人员", contents, RoadFlow.Platform.Log.Types.组织机构, "", "", (RoadFlow.Data.Model.Users) null);
        // ISSUE: reference to a compiler-generated field
        if (MembersController.\u003C\u003Eo__10.\u003C\u003Ep__0 == null)
        {
          // ISSUE: reference to a compiler-generated field
          MembersController.\u003C\u003Eo__10.\u003C\u003Ep__0 = CallSite<Func<CallSite, object, string, object>>.Create(Binder.SetMember(CSharpBinderFlags.None, "Script", typeof (MembersController), (IEnumerable<CSharpArgumentInfo>) new CSharpArgumentInfo[2]
          {
            CSharpArgumentInfo.Create(CSharpArgumentInfoFlags.None, (string) null),
            CSharpArgumentInfo.Create(CSharpArgumentInfoFlags.UseCompileTimeType, (string) null)
          }));
        }
        // ISSUE: reference to a compiler-generated field
        // ISSUE: reference to a compiler-generated field
        object obj = MembersController.\u003C\u003Eo__10.\u003C\u003Ep__0.Target((CallSite) MembersController.\u003C\u003Eo__10.\u003C\u003Ep__0, this.ViewBag, "alert('添加成功!');parent.frames[0].reLoad('" + str1 + "');window.location=window.location;");
      }
      // ISSUE: reference to a compiler-generated field
      if (MembersController.\u003C\u003Eo__10.\u003C\u003Ep__1 == null)
      {
        // ISSUE: reference to a compiler-generated field
        MembersController.\u003C\u003Eo__10.\u003C\u003Ep__1 = CallSite<Func<CallSite, object, string, object>>.Create(Binder.SetMember(CSharpBinderFlags.None, "StatusRadios", typeof (MembersController), (IEnumerable<CSharpArgumentInfo>) new CSharpArgumentInfo[2]
        {
          CSharpArgumentInfo.Create(CSharpArgumentInfoFlags.None, (string) null),
          CSharpArgumentInfo.Create(CSharpArgumentInfoFlags.UseCompileTimeType, (string) null)
        }));
      }
      // ISSUE: reference to a compiler-generated field
      // ISSUE: reference to a compiler-generated field
      object obj1 = MembersController.\u003C\u003Eo__10.\u003C\u003Ep__1.Target((CallSite) MembersController.\u003C\u003Eo__10.\u003C\u003Ep__1, this.ViewBag, organize.GetStatusRadio("Status", "0", "validate=\"radio\""));
      // ISSUE: reference to a compiler-generated field
      if (MembersController.\u003C\u003Eo__10.\u003C\u003Ep__2 == null)
      {
        // ISSUE: reference to a compiler-generated field
        MembersController.\u003C\u003Eo__10.\u003C\u003Ep__2 = CallSite<Func<CallSite, object, string, object>>.Create(Binder.SetMember(CSharpBinderFlags.None, "SexRadios", typeof (MembersController), (IEnumerable<CSharpArgumentInfo>) new CSharpArgumentInfo[2]
        {
          CSharpArgumentInfo.Create(CSharpArgumentInfoFlags.None, (string) null),
          CSharpArgumentInfo.Create(CSharpArgumentInfoFlags.UseCompileTimeType, (string) null)
        }));
      }
      // ISSUE: reference to a compiler-generated field
      // ISSUE: reference to a compiler-generated field
      object obj2 = MembersController.\u003C\u003Eo__10.\u003C\u003Ep__2.Target((CallSite) MembersController.\u003C\u003Eo__10.\u003C\u003Ep__2, this.ViewBag, organize.GetSexRadio("Sex", "", "validate=\"radio\""));
      return (ActionResult) this.View();
    }

    public ActionResult User()
    {
      return this.User((FormCollection) null);
    }

    [HttpPost]
    [ValidateAntiForgeryToken]
    public ActionResult User(FormCollection collection)
    {
      RoadFlow.Platform.Organize organize1 = new RoadFlow.Platform.Organize();
      RoadFlow.Platform.Users users1 = new RoadFlow.Platform.Users();
      RoadFlow.Platform.UsersRelation usersRelation1 = new RoadFlow.Platform.UsersRelation();
      RoadFlow.Data.Model.Users users2 = (RoadFlow.Data.Model.Users) null;
      RoadFlow.Data.Model.Organize organize2 = (RoadFlow.Data.Model.Organize) null;
      string str1 = this.Request.QueryString["id"];
      string str2 = this.Request.QueryString["parentid"];
      string str3 = string.Empty;
      string str4 = string.Empty;
      string empty1 = string.Empty;
      string str5 = string.Empty;
      string empty2 = string.Empty;
      string empty3 = string.Empty;
      Guid id;
      ref Guid local = ref id;
      if (str1.IsGuid(out local))
      {
        users2 = users1.Get(id);
        if (users2 != null)
        {
          str3 = users2.Name;
          str4 = users2.Account;
          empty1 = users2.Status.ToString();
          str5 = users2.Note;
          empty2 = users2.Sex.ToString();
          StringBuilder stringBuilder = new StringBuilder();
          foreach (RoadFlow.Data.Model.UsersRelation usersRelation2 in (IEnumerable<RoadFlow.Data.Model.UsersRelation>) usersRelation1.GetAllByUserID(users2.ID).OrderByDescending<RoadFlow.Data.Model.UsersRelation, int>((Func<RoadFlow.Data.Model.UsersRelation, int>) (p => p.IsMain)))
          {
            stringBuilder.Append("<div style='margin:3px 0;'>");
            stringBuilder.Append(organize1.GetAllParentNames(usersRelation2.OrganizeID, true, " / "));
            if (usersRelation2.IsMain == 0)
              stringBuilder.Append("<span style='color:#999'> [兼任]</span>");
            stringBuilder.Append("</div>");
          }
          // ISSUE: reference to a compiler-generated field
          if (MembersController.\u003C\u003Eo__12.\u003C\u003Ep__0 == null)
          {
            // ISSUE: reference to a compiler-generated field
            MembersController.\u003C\u003Eo__12.\u003C\u003Ep__0 = CallSite<Func<CallSite, object, string, object>>.Create(Binder.SetMember(CSharpBinderFlags.None, "ParentString", typeof (MembersController), (IEnumerable<CSharpArgumentInfo>) new CSharpArgumentInfo[2]
            {
              CSharpArgumentInfo.Create(CSharpArgumentInfoFlags.None, (string) null),
              CSharpArgumentInfo.Create(CSharpArgumentInfoFlags.UseCompileTimeType, (string) null)
            }));
          }
          // ISSUE: reference to a compiler-generated field
          // ISSUE: reference to a compiler-generated field
          object obj1 = MembersController.\u003C\u003Eo__12.\u003C\u003Ep__0.Target((CallSite) MembersController.\u003C\u003Eo__12.\u003C\u003Ep__0, this.ViewBag, stringBuilder.ToString());
          // ISSUE: reference to a compiler-generated field
          if (MembersController.\u003C\u003Eo__12.\u003C\u003Ep__1 == null)
          {
            // ISSUE: reference to a compiler-generated field
            MembersController.\u003C\u003Eo__12.\u003C\u003Ep__1 = CallSite<Func<CallSite, object, string, object>>.Create(Binder.SetMember(CSharpBinderFlags.None, "RoleString", typeof (MembersController), (IEnumerable<CSharpArgumentInfo>) new CSharpArgumentInfo[2]
            {
              CSharpArgumentInfo.Create(CSharpArgumentInfoFlags.None, (string) null),
              CSharpArgumentInfo.Create(CSharpArgumentInfoFlags.UseCompileTimeType, (string) null)
            }));
          }
          // ISSUE: reference to a compiler-generated field
          // ISSUE: reference to a compiler-generated field
          object obj2 = MembersController.\u003C\u003Eo__12.\u003C\u003Ep__1.Target((CallSite) MembersController.\u003C\u003Eo__12.\u003C\u003Ep__1, this.ViewBag, new RoadFlow.Platform.WorkGroup().GetAllNamesByUserID(users2.ID));
        }
      }
      Guid test1;
      if (str2.IsGuid(out test1))
        organize2 = organize1.Get(test1);
      if (collection != null)
      {
        if (!this.Request.Form["Save"].IsNullOrEmpty() && users2 != null)
        {
          string str6 = this.Request.Form["Name"];
          string str7 = this.Request.Form["Account"];
          empty1 = this.Request.Form["Status"];
          string str8 = this.Request.Form["Note"];
          string str9 = this.Request.Form["Tel"];
          string str10 = this.Request.Form["Mobile"];
          string str11 = this.Request.Form["WeiXin"];
          string str12 = this.Request.Form["Email"];
          string str13 = this.Request.Form["Fax"];
          string str14 = this.Request.Form["QQ"];
          string str15 = this.Request.Form["OtherTel"];
          empty2 = this.Request.Form["Sex"];
          string oldXML = users2.Serialize();
          users2.Name = str6.Trim();
          users2.Account = str7.Trim();
          users2.Status = empty1.ToInt(1);
          users2.Note = str8.IsNullOrEmpty() ? (string) null : str8.Trim();
          users2.Tel = str9.Trim1();
          users2.Mobile = str10.Trim1();
          users2.WeiXin = str11.Trim1();
          users2.WeiXin = str11.Trim1();
          users2.Email = str12.Trim1();
          users2.Fax = str13.Trim1();
          users2.QQ = str14.Trim1();
          users2.OtherTel = str15.Trim1();
          if (empty2.IsInt())
            users2.Sex = new int?(empty2.ToInt());
          users1.Update(users2);
          if (RoadFlow.Platform.WeiXin.Config.IsUse)
            new RoadFlow.Platform.WeiXin.Organize().EditUserAsync(users2);
          new RoadFlow.Platform.MenuUser().ClearCache();
          RoadFlow.Platform.Log.Add("修改了用户", "", RoadFlow.Platform.Log.Types.组织机构, oldXML, users2.Serialize(), (RoadFlow.Data.Model.Users) null);
          // ISSUE: reference to a compiler-generated field
          if (MembersController.\u003C\u003Eo__12.\u003C\u003Ep__2 == null)
          {
            // ISSUE: reference to a compiler-generated field
            MembersController.\u003C\u003Eo__12.\u003C\u003Ep__2 = CallSite<Func<CallSite, object, string, object>>.Create(Binder.SetMember(CSharpBinderFlags.None, "Script", typeof (MembersController), (IEnumerable<CSharpArgumentInfo>) new CSharpArgumentInfo[2]
            {
              CSharpArgumentInfo.Create(CSharpArgumentInfoFlags.None, (string) null),
              CSharpArgumentInfo.Create(CSharpArgumentInfoFlags.UseCompileTimeType, (string) null)
            }));
          }
          // ISSUE: reference to a compiler-generated field
          // ISSUE: reference to a compiler-generated field
          object obj = MembersController.\u003C\u003Eo__12.\u003C\u003Ep__2.Target((CallSite) MembersController.\u003C\u003Eo__12.\u003C\u003Ep__2, this.ViewBag, "alert('保存成功!');parent.frames[0].reLoad('" + str2 + "');");
        }
        if (!this.Request.Form["DeleteBut"].IsNullOrEmpty() && users2 != null && organize2 != null)
        {
          using (TransactionScope transactionScope = new TransactionScope())
          {
            List<RoadFlow.Data.Model.UsersRelation> allByUserId = usersRelation1.GetAllByUserID(users2.ID);
            users1.Delete(users2.ID);
            usersRelation1.DeleteByUserID(users2.ID);
            foreach (RoadFlow.Data.Model.UsersRelation usersRelation2 in allByUserId)
              organize1.UpdateChildsLength(usersRelation2.OrganizeID);
            if (RoadFlow.Platform.WeiXin.Config.IsUse)
              new RoadFlow.Platform.WeiXin.Organize().DeleteUserAsync(users2.Account);
            transactionScope.Complete();
          }
          new RoadFlow.Platform.MenuUser().ClearCache();
          new RoadFlow.Platform.HomeItems().ClearCache();
          string idString = str2;
          string str6 = string.Empty;
          List<RoadFlow.Data.Model.Users> allUsers = organize1.GetAllUsers(idString);
          if (allUsers.Count > 0)
            str6 = "User?id=" + (object) allUsers.Last<RoadFlow.Data.Model.Users>().ID + "&appid=" + this.Request.QueryString["appid"] + "&tabid=" + this.Request.QueryString["tabid"] + "&parentid=" + str2;
          else if (organize2 != null)
          {
            idString = organize2.ParentID == Guid.Empty ? organize2.ID.ToString() : organize2.ParentID.ToString();
            str6 = "Body?id=" + str2 + "&appid=" + this.Request.QueryString["appid"] + "&tabid=" + this.Request.QueryString["tabid"] + "&parentid=" + (object) organize2.ParentID;
          }
          RoadFlow.Platform.Log.Add("删除了用户", users2.Serialize(), RoadFlow.Platform.Log.Types.组织机构, "", "", (RoadFlow.Data.Model.Users) null);
          // ISSUE: reference to a compiler-generated field
          if (MembersController.\u003C\u003Eo__12.\u003C\u003Ep__3 == null)
          {
            // ISSUE: reference to a compiler-generated field
            MembersController.\u003C\u003Eo__12.\u003C\u003Ep__3 = CallSite<Func<CallSite, object, string, object>>.Create(Binder.SetMember(CSharpBinderFlags.None, "Script", typeof (MembersController), (IEnumerable<CSharpArgumentInfo>) new CSharpArgumentInfo[2]
            {
              CSharpArgumentInfo.Create(CSharpArgumentInfoFlags.None, (string) null),
              CSharpArgumentInfo.Create(CSharpArgumentInfoFlags.UseCompileTimeType, (string) null)
            }));
          }
          // ISSUE: reference to a compiler-generated field
          // ISSUE: reference to a compiler-generated field
          object obj = MembersController.\u003C\u003Eo__12.\u003C\u003Ep__3.Target((CallSite) MembersController.\u003C\u003Eo__12.\u003C\u003Ep__3, this.ViewBag, "alert('删除成功');parent.frames[0].reLoad('" + idString + "');window.location='" + str6 + "'");
        }
        if (!this.Request.Form["InitPass"].IsNullOrEmpty() && users2 != null)
        {
          string initPassword = users1.GetInitPassword();
          users1.InitPassword(users2.ID);
          RoadFlow.Platform.Log.Add("初始化了用户密码", users2.Serialize(), RoadFlow.Platform.Log.Types.组织机构, "", "", (RoadFlow.Data.Model.Users) null);
          // ISSUE: reference to a compiler-generated field
          if (MembersController.\u003C\u003Eo__12.\u003C\u003Ep__4 == null)
          {
            // ISSUE: reference to a compiler-generated field
            MembersController.\u003C\u003Eo__12.\u003C\u003Ep__4 = CallSite<Func<CallSite, object, string, object>>.Create(Binder.SetMember(CSharpBinderFlags.None, "Script", typeof (MembersController), (IEnumerable<CSharpArgumentInfo>) new CSharpArgumentInfo[2]
            {
              CSharpArgumentInfo.Create(CSharpArgumentInfoFlags.None, (string) null),
              CSharpArgumentInfo.Create(CSharpArgumentInfoFlags.UseCompileTimeType, (string) null)
            }));
          }
          // ISSUE: reference to a compiler-generated field
          // ISSUE: reference to a compiler-generated field
          object obj = MembersController.\u003C\u003Eo__12.\u003C\u003Ep__4.Target((CallSite) MembersController.\u003C\u003Eo__12.\u003C\u003Ep__4, this.ViewBag, "alert('密码已初始化为：" + initPassword + "');");
        }
        if (!this.Request.Form["Move1"].IsNullOrEmpty() && users2 != null)
        {
          string str6 = this.Request.Form["movetostation"];
          string str7 = this.Request.Form["movetostationjz"];
          Guid test2;
          if (str6.IsGuid(out test2))
          {
            using (TransactionScope transactionScope = new TransactionScope())
            {
              List<RoadFlow.Data.Model.UsersRelation> allByUserId = usersRelation1.GetAllByUserID(users2.ID);
              if ("1" != str7)
                usersRelation1.DeleteByUserID(users2.ID);
              usersRelation1.Add(new RoadFlow.Data.Model.UsersRelation()
              {
                UserID = users2.ID,
                OrganizeID = test2,
                IsMain = "1" == str7 ? 0 : 1,
                Sort = usersRelation1.GetMaxSort(test2)
              });
              foreach (RoadFlow.Data.Model.UsersRelation usersRelation2 in allByUserId)
                organize1.UpdateChildsLength(usersRelation2.OrganizeID);
              organize1.UpdateChildsLength(test1);
              organize1.UpdateChildsLength(test2);
              new RoadFlow.Platform.MenuUser().ClearCache();
              new RoadFlow.Platform.HomeItems().ClearCache();
              new RoadFlow.Platform.DocumentDirectory().ClearAllDirUsersCache();
              if (RoadFlow.Platform.WeiXin.Config.IsUse)
                new RoadFlow.Platform.WeiXin.Organize().EditUserAsync(users2);
              transactionScope.Complete();
              // ISSUE: reference to a compiler-generated field
              if (MembersController.\u003C\u003Eo__12.\u003C\u003Ep__5 == null)
              {
                // ISSUE: reference to a compiler-generated field
                MembersController.\u003C\u003Eo__12.\u003C\u003Ep__5 = CallSite<Func<CallSite, object, string, object>>.Create(Binder.SetMember(CSharpBinderFlags.None, "Script", typeof (MembersController), (IEnumerable<CSharpArgumentInfo>) new CSharpArgumentInfo[2]
                {
                  CSharpArgumentInfo.Create(CSharpArgumentInfoFlags.None, (string) null),
                  CSharpArgumentInfo.Create(CSharpArgumentInfoFlags.UseCompileTimeType, (string) null)
                }));
              }
              // ISSUE: reference to a compiler-generated field
              // ISSUE: reference to a compiler-generated field
              object obj = MembersController.\u003C\u003Eo__12.\u003C\u003Ep__5.Target((CallSite) MembersController.\u003C\u003Eo__12.\u003C\u003Ep__5, this.ViewBag, "alert('调动成功!');parent.frames[0].reLoad('" + str2 + "');parent.frames[0].reLoad('" + str6 + "')");
            }
            RoadFlow.Platform.Log.Add(("1" == str7 ? "兼职" : "全职") + "调动了人员的岗位", "将人员调往岗位(" + str6 + ")", RoadFlow.Platform.Log.Types.组织机构, "", "", (RoadFlow.Data.Model.Users) null);
          }
        }
      }
      // ISSUE: reference to a compiler-generated field
      if (MembersController.\u003C\u003Eo__12.\u003C\u003Ep__6 == null)
      {
        // ISSUE: reference to a compiler-generated field
        MembersController.\u003C\u003Eo__12.\u003C\u003Ep__6 = CallSite<Func<CallSite, object, string, object>>.Create(Binder.SetMember(CSharpBinderFlags.None, "StatusRadios", typeof (MembersController), (IEnumerable<CSharpArgumentInfo>) new CSharpArgumentInfo[2]
        {
          CSharpArgumentInfo.Create(CSharpArgumentInfoFlags.None, (string) null),
          CSharpArgumentInfo.Create(CSharpArgumentInfoFlags.UseCompileTimeType, (string) null)
        }));
      }
      // ISSUE: reference to a compiler-generated field
      // ISSUE: reference to a compiler-generated field
      object obj3 = MembersController.\u003C\u003Eo__12.\u003C\u003Ep__6.Target((CallSite) MembersController.\u003C\u003Eo__12.\u003C\u003Ep__6, this.ViewBag, organize1.GetStatusRadio("Status", empty1, "validate=\"radio\""));
      // ISSUE: reference to a compiler-generated field
      if (MembersController.\u003C\u003Eo__12.\u003C\u003Ep__7 == null)
      {
        // ISSUE: reference to a compiler-generated field
        MembersController.\u003C\u003Eo__12.\u003C\u003Ep__7 = CallSite<Func<CallSite, object, string, object>>.Create(Binder.SetMember(CSharpBinderFlags.None, "SexRadios", typeof (MembersController), (IEnumerable<CSharpArgumentInfo>) new CSharpArgumentInfo[2]
        {
          CSharpArgumentInfo.Create(CSharpArgumentInfoFlags.None, (string) null),
          CSharpArgumentInfo.Create(CSharpArgumentInfoFlags.UseCompileTimeType, (string) null)
        }));
      }
      // ISSUE: reference to a compiler-generated field
      // ISSUE: reference to a compiler-generated field
      object obj4 = MembersController.\u003C\u003Eo__12.\u003C\u003Ep__7.Target((CallSite) MembersController.\u003C\u003Eo__12.\u003C\u003Ep__7, this.ViewBag, organize1.GetSexRadio("Sex", empty2, "validate=\"radio\""));
      return (ActionResult) this.View((object) users2);
    }

    public ActionResult Sort()
    {
      return this.Sort((FormCollection) null);
    }

    [HttpPost]
    [ValidateAntiForgeryToken]
    public ActionResult Sort(FormCollection collection)
    {
      string str = this.Request.QueryString["parentid"];
      if (collection != null)
      {
        string[] strArray = (this.Request.Form["sort"] ?? "").Split(',');
        RoadFlow.Platform.Organize organize = new RoadFlow.Platform.Organize();
        for (int index = 0; index < strArray.Length; ++index)
        {
          Guid test;
          if (strArray[index].IsGuid(out test))
            organize.UpdateSort(test, index + 1);
        }
        // ISSUE: reference to a compiler-generated field
        if (MembersController.\u003C\u003Eo__14.\u003C\u003Ep__0 == null)
        {
          // ISSUE: reference to a compiler-generated field
          MembersController.\u003C\u003Eo__14.\u003C\u003Ep__0 = CallSite<Func<CallSite, object, string, object>>.Create(Binder.SetMember(CSharpBinderFlags.None, "Script", typeof (MembersController), (IEnumerable<CSharpArgumentInfo>) new CSharpArgumentInfo[2]
          {
            CSharpArgumentInfo.Create(CSharpArgumentInfoFlags.None, (string) null),
            CSharpArgumentInfo.Create(CSharpArgumentInfoFlags.UseCompileTimeType, (string) null)
          }));
        }
        // ISSUE: reference to a compiler-generated field
        // ISSUE: reference to a compiler-generated field
        object obj = MembersController.\u003C\u003Eo__14.\u003C\u003Ep__0.Target((CallSite) MembersController.\u003C\u003Eo__14.\u003C\u003Ep__0, this.ViewBag, "parent.frames[0].reLoad('" + str + "');");
      }
      return (ActionResult) this.View((object) new RoadFlow.Platform.Organize().GetChilds(str.ToGuid()));
    }

    public ActionResult SortUsers()
    {
      return this.SortUsers((FormCollection) null);
    }

    [HttpPost]
    [ValidateAntiForgeryToken]
    public ActionResult SortUsers(FormCollection collection)
    {
      string str = this.Request.QueryString["parentid"];
      if (collection != null)
      {
        string[] strArray = (this.Request.Form["sort"] ?? "").Split(',');
        RoadFlow.Platform.Users users = new RoadFlow.Platform.Users();
        for (int index = 0; index < strArray.Length; ++index)
        {
          Guid test;
          if (strArray[index].IsGuid(out test))
            users.UpdateSort(test, index + 1);
        }
        // ISSUE: reference to a compiler-generated field
        if (MembersController.\u003C\u003Eo__16.\u003C\u003Ep__0 == null)
        {
          // ISSUE: reference to a compiler-generated field
          MembersController.\u003C\u003Eo__16.\u003C\u003Ep__0 = CallSite<Func<CallSite, object, string, object>>.Create(Binder.SetMember(CSharpBinderFlags.None, "Script", typeof (MembersController), (IEnumerable<CSharpArgumentInfo>) new CSharpArgumentInfo[2]
          {
            CSharpArgumentInfo.Create(CSharpArgumentInfoFlags.None, (string) null),
            CSharpArgumentInfo.Create(CSharpArgumentInfoFlags.UseCompileTimeType, (string) null)
          }));
        }
        // ISSUE: reference to a compiler-generated field
        // ISSUE: reference to a compiler-generated field
        object obj = MembersController.\u003C\u003Eo__16.\u003C\u003Ep__0.Target((CallSite) MembersController.\u003C\u003Eo__16.\u003C\u003Ep__0, this.ViewBag, "parent.frames[0].reLoad('" + str + "');");
      }
      return (ActionResult) this.View((object) new RoadFlow.Platform.Organize().GetAllUsers(str.ToGuid()));
    }

    [MyAttribute(CheckApp = false)]
    public string GetPy()
    {
      string chineseSpell = this.Request.Form["name"].ToChineseSpell();
      if (!chineseSpell.IsNullOrEmpty())
        return new RoadFlow.Platform.Users().GetAccount(chineseSpell.Trim());
      return "";
    }

    [MyAttribute(CheckApp = false)]
    public string CheckAccount()
    {
      string msg;
      if (!Tools.CheckLogin(out msg) && !RoadFlow.Platform.WeiXin.Organize.CheckLogin())
        return "";
      return !new RoadFlow.Platform.Users().HasAccount(this.Request.Form["value"], this.Request["id"]) ? "1" : "帐号已经被使用了";
    }

    [MyAttribute(CheckApp = false)]
    public string GetNames()
    {
      string msg;
      if (!Tools.CheckLogin(out msg) && !RoadFlow.Platform.WeiXin.Organize.CheckLogin())
        return "";
      return new RoadFlow.Platform.Organize().GetNames(this.Request.QueryString["values"], ",");
    }

    [MyAttribute(CheckApp = false)]
    public string GetNote()
    {
      string msg;
      if (!Tools.CheckLogin(out msg) && !RoadFlow.Platform.WeiXin.Organize.CheckLogin())
        return "";
      string str = this.Request.QueryString["id"];
      if (str.IsNullOrEmpty())
        return "";
      RoadFlow.Platform.Organize organize = new RoadFlow.Platform.Organize();
      RoadFlow.Platform.Users users = new RoadFlow.Platform.Users();
      if (str.StartsWith("u_"))
      {
        Guid guid = users.RemovePrefix1(str).ToGuid();
        return organize.GetAllParentNames(users.GetMainStation(guid), false, " / ") + " / " + users.GetName(guid);
      }
      if (str.StartsWith("w_"))
        return new RoadFlow.Platform.WorkGroup().GetUsersNames(RoadFlow.Platform.WorkGroup.RemovePrefix(str).ToGuid(), '、');
      Guid test;
      if (str.IsGuid(out test))
        return organize.GetAllParentNames(test, false, " / ");
      return "";
    }

    [MyAttribute(CheckApp = false)]
    public ActionResult EditPass()
    {
      return (ActionResult) this.View();
    }

    [HttpPost]
    [ValidateAntiForgeryToken]
    [MyAttribute(CheckApp = false)]
    public ActionResult EditPass(FormCollection collection)
    {
      string str1 = this.Request.Form["oldpass"];
      string str2 = this.Request.Form["newpass"];
      RoadFlow.Platform.Users users = new RoadFlow.Platform.Users();
      RoadFlow.Data.Model.Users currentUser = RoadFlow.Platform.Users.CurrentUser;
      if (currentUser != null)
      {
        if (string.Compare(currentUser.Password, users.GetUserEncryptionPassword(currentUser.ID.ToString(), str1.Trim()), false) != 0)
        {
          RoadFlow.Platform.Log.Add("修改密码失败", "用户：" + currentUser.Name + "(" + (object) currentUser.ID + ")修改密码失败,旧密码错误!", RoadFlow.Platform.Log.Types.用户登录, "", "", (RoadFlow.Data.Model.Users) null);
          // ISSUE: reference to a compiler-generated field
          if (MembersController.\u003C\u003Eo__22.\u003C\u003Ep__0 == null)
          {
            // ISSUE: reference to a compiler-generated field
            MembersController.\u003C\u003Eo__22.\u003C\u003Ep__0 = CallSite<Func<CallSite, object, string, object>>.Create(Binder.SetMember(CSharpBinderFlags.None, "Script", typeof (MembersController), (IEnumerable<CSharpArgumentInfo>) new CSharpArgumentInfo[2]
            {
              CSharpArgumentInfo.Create(CSharpArgumentInfoFlags.None, (string) null),
              CSharpArgumentInfo.Create(CSharpArgumentInfoFlags.UseCompileTimeType | CSharpArgumentInfoFlags.Constant, (string) null)
            }));
          }
          // ISSUE: reference to a compiler-generated field
          // ISSUE: reference to a compiler-generated field
          object obj = MembersController.\u003C\u003Eo__22.\u003C\u003Ep__0.Target((CallSite) MembersController.\u003C\u003Eo__22.\u003C\u003Ep__0, this.ViewBag, "alert('旧密码错误!');");
        }
        else
        {
          users.UpdatePassword(str2.Trim(), currentUser.ID);
          RoadFlow.Platform.Log.Add("修改密码成功", "用户：" + currentUser.Name + "(" + (object) currentUser.ID + ")修改密码成功!", RoadFlow.Platform.Log.Types.用户登录, "", "", (RoadFlow.Data.Model.Users) null);
          // ISSUE: reference to a compiler-generated field
          if (MembersController.\u003C\u003Eo__22.\u003C\u003Ep__1 == null)
          {
            // ISSUE: reference to a compiler-generated field
            MembersController.\u003C\u003Eo__22.\u003C\u003Ep__1 = CallSite<Func<CallSite, object, string, object>>.Create(Binder.SetMember(CSharpBinderFlags.None, "Script", typeof (MembersController), (IEnumerable<CSharpArgumentInfo>) new CSharpArgumentInfo[2]
            {
              CSharpArgumentInfo.Create(CSharpArgumentInfoFlags.None, (string) null),
              CSharpArgumentInfo.Create(CSharpArgumentInfoFlags.UseCompileTimeType | CSharpArgumentInfoFlags.Constant, (string) null)
            }));
          }
          // ISSUE: reference to a compiler-generated field
          // ISSUE: reference to a compiler-generated field
          object obj = MembersController.\u003C\u003Eo__22.\u003C\u003Ep__1.Target((CallSite) MembersController.\u003C\u003Eo__22.\u003C\u003Ep__1, this.ViewBag, "alert('密码修改成功!');new RoadUI.Window().close();");
        }
      }
      return (ActionResult) this.View();
    }

    public ActionResult WorkGroup()
    {
      return this.WorkGroup((FormCollection) null);
    }

    [HttpPost]
    [ValidateAntiForgeryToken]
    public ActionResult WorkGroup(FormCollection collection)
    {
      string str1 = this.Request.QueryString["id"];
      RoadFlow.Platform.WorkGroup workGroup1 = new RoadFlow.Platform.WorkGroup();
      string str2 = string.Empty;
      string str3 = string.Empty;
      string str4 = string.Empty;
      string empty = string.Empty;
      Guid id;
      ref Guid local = ref id;
      if (!str1.IsGuid(out local) || id == Guid.Empty)
      {
        this.Response.End();
        return (ActionResult) null;
      }
      RoadFlow.Data.Model.WorkGroup workGroup2 = workGroup1.Get(id);
      string str5 = string.Empty;
      if (workGroup2 != null)
      {
        str5 = workGroup2.Members;
        str2 = workGroup2.Name;
        str3 = workGroup2.Members;
        str4 = workGroup2.Note;
        workGroup1.GetUsersNames(workGroup2.Members, '、');
      }
      if (!this.Request.Form["Save"].IsNullOrEmpty() && collection != null && workGroup2 != null)
      {
        string oldXML = workGroup2.Serialize();
        string str6 = this.Request.Form["Name"];
        string str7 = this.Request.Form["Members"];
        string str8 = this.Request.Form["Note"];
        workGroup2.Name = str6.Trim();
        workGroup2.Members = str7;
        if (!str8.IsNullOrEmpty())
          workGroup2.Note = str8;
        workGroup2.IntID = workGroup2.ID.ToInt32();
        workGroup1.Update(workGroup2);
        if (RoadFlow.Platform.WeiXin.Config.IsUse)
        {
          RoadFlow.Platform.WeiXin.Organize organize = new RoadFlow.Platform.WeiXin.Organize();
          organize.EditGroupAsync(workGroup2);
          if (!str5.Equals(workGroup2.Members, StringComparison.CurrentCultureIgnoreCase))
            organize.AddGroupUserAsync(workGroup2);
        }
        new RoadFlow.Platform.MenuUser().ClearCache();
        new RoadFlow.Platform.HomeItems().ClearCache();
        workGroup1.GetUsersNames(workGroup2.Members, '、');
        string query = this.Request.Url.Query;
        RoadFlow.Platform.Log.Add("修改了工作组", "修改了工作组", RoadFlow.Platform.Log.Types.组织机构, oldXML, workGroup2.Serialize(), (RoadFlow.Data.Model.Users) null);
        // ISSUE: reference to a compiler-generated field
        if (MembersController.\u003C\u003Eo__24.\u003C\u003Ep__0 == null)
        {
          // ISSUE: reference to a compiler-generated field
          MembersController.\u003C\u003Eo__24.\u003C\u003Ep__0 = CallSite<Func<CallSite, object, string, object>>.Create(Binder.SetMember(CSharpBinderFlags.None, "Script", typeof (MembersController), (IEnumerable<CSharpArgumentInfo>) new CSharpArgumentInfo[2]
          {
            CSharpArgumentInfo.Create(CSharpArgumentInfoFlags.None, (string) null),
            CSharpArgumentInfo.Create(CSharpArgumentInfoFlags.UseCompileTimeType | CSharpArgumentInfoFlags.Constant, (string) null)
          }));
        }
        // ISSUE: reference to a compiler-generated field
        // ISSUE: reference to a compiler-generated field
        object obj = MembersController.\u003C\u003Eo__24.\u003C\u003Ep__0.Target((CallSite) MembersController.\u003C\u003Eo__24.\u003C\u003Ep__0, this.ViewBag, "alert('保存成功!');");
      }
      if (!this.Request.Form["DeleteBut"].IsNullOrEmpty() && collection != null && workGroup2 != null)
      {
        string contents = workGroup2.Serialize();
        workGroup1.Delete(workGroup2.ID);
        if (RoadFlow.Platform.WeiXin.Config.IsUse)
          new RoadFlow.Platform.WeiXin.Organize().DeleteGroupAsync(workGroup2);
        new RoadFlow.Platform.MenuUser().ClearCache();
        new RoadFlow.Platform.HomeItems().ClearCache();
        string query = this.Request.Url.Query;
        RoadFlow.Platform.Log.Add("删除了工作组", contents, RoadFlow.Platform.Log.Types.组织机构, "", "", (RoadFlow.Data.Model.Users) null);
        // ISSUE: reference to a compiler-generated field
        if (MembersController.\u003C\u003Eo__24.\u003C\u003Ep__1 == null)
        {
          // ISSUE: reference to a compiler-generated field
          MembersController.\u003C\u003Eo__24.\u003C\u003Ep__1 = CallSite<Func<CallSite, object, string, object>>.Create(Binder.SetMember(CSharpBinderFlags.None, "Script", typeof (MembersController), (IEnumerable<CSharpArgumentInfo>) new CSharpArgumentInfo[2]
          {
            CSharpArgumentInfo.Create(CSharpArgumentInfoFlags.None, (string) null),
            CSharpArgumentInfo.Create(CSharpArgumentInfoFlags.UseCompileTimeType, (string) null)
          }));
        }
        // ISSUE: reference to a compiler-generated field
        // ISSUE: reference to a compiler-generated field
        object obj = MembersController.\u003C\u003Eo__24.\u003C\u003Ep__1.Target((CallSite) MembersController.\u003C\u003Eo__24.\u003C\u003Ep__1, this.ViewBag, "parent.frames[0].treecng('1');alert('删除成功!');window.location = 'Empty' + '" + query + "';");
      }
      return (ActionResult) this.View((object) workGroup2);
    }

    public ActionResult WorkGroupAdd()
    {
      return this.WorkGroupAdd((FormCollection) null);
    }

    [HttpPost]
    [ValidateAntiForgeryToken]
    public ActionResult WorkGroupAdd(FormCollection collection)
    {
      RoadFlow.Platform.WorkGroup workGroup1 = new RoadFlow.Platform.WorkGroup();
      string empty1 = string.Empty;
      string empty2 = string.Empty;
      string empty3 = string.Empty;
      if (collection != null)
      {
        string str1 = this.Request.Form["Name"];
        string str2 = this.Request.Form["Members"];
        string str3 = this.Request.Form["Note"];
        RoadFlow.Data.Model.WorkGroup workGroup2 = new RoadFlow.Data.Model.WorkGroup();
        workGroup2.ID = Guid.NewGuid();
        workGroup2.Name = str1.Trim();
        workGroup2.Members = str2;
        if (!str3.IsNullOrEmpty())
          workGroup2.Note = str3;
        workGroup2.IntID = workGroup2.ID.ToInt32();
        workGroup1.Add(workGroup2);
        if (RoadFlow.Platform.WeiXin.Config.IsUse)
          new RoadFlow.Platform.WeiXin.Organize().AddGroupAsync(workGroup2);
        new RoadFlow.Platform.MenuUser().ClearCache();
        string query = this.Request.Url.Query;
        RoadFlow.Platform.Log.Add("添加了工作组", workGroup2.Serialize(), RoadFlow.Platform.Log.Types.组织机构, "", "", (RoadFlow.Data.Model.Users) null);
        // ISSUE: reference to a compiler-generated field
        if (MembersController.\u003C\u003Eo__26.\u003C\u003Ep__0 == null)
        {
          // ISSUE: reference to a compiler-generated field
          MembersController.\u003C\u003Eo__26.\u003C\u003Ep__0 = CallSite<Func<CallSite, object, string, object>>.Create(Binder.SetMember(CSharpBinderFlags.None, "Script", typeof (MembersController), (IEnumerable<CSharpArgumentInfo>) new CSharpArgumentInfo[2]
          {
            CSharpArgumentInfo.Create(CSharpArgumentInfoFlags.None, (string) null),
            CSharpArgumentInfo.Create(CSharpArgumentInfoFlags.UseCompileTimeType, (string) null)
          }));
        }
        // ISSUE: reference to a compiler-generated field
        // ISSUE: reference to a compiler-generated field
        object obj = MembersController.\u003C\u003Eo__26.\u003C\u003Ep__0.Target((CallSite) MembersController.\u003C\u003Eo__26.\u003C\u003Ep__0, this.ViewBag, "parent.frames[0].treecng('1');alert('添加成功!');window.location = 'WorkGroup' + '" + query + "';");
      }
      return (ActionResult) this.View();
    }

    public ActionResult SetMenu()
    {
      return this.SetMenu((FormCollection) null);
    }

    [HttpPost]
    [ValidateAntiForgeryToken]
    public ActionResult SetMenu(FormCollection collection)
    {
      RoadFlow.Platform.Menu menu = new RoadFlow.Platform.Menu();
      RoadFlow.Platform.MenuUser menuUser = new RoadFlow.Platform.MenuUser();
      string orgID = this.Request.QueryString["id"];
      string str1 = this.Request.QueryString["type"];
      string organizes = ("4" == str1 ? "u_" : ("5" == str1 ? "w_" : "")) + orgID;
      if (collection != null)
      {
        string str2 = this.Request.Form["menuid"] ?? "";
        RoadFlow.Platform.Organize organize = new RoadFlow.Platform.Organize();
        menuUser.ClearCache();
        string idString = organizes;
        string str3 = organize.GetAllUsersIdList(idString).ToArray().Join1<Guid>(",");
        using (TransactionScope transactionScope = new TransactionScope())
        {
          menuUser.DeleteByOrganizes(organizes);
          string str4 = str2;
          char[] chArray1 = new char[1]{ ',' };
          foreach (string str5 in str4.Split(chArray1))
          {
            if (str5.IsGuid())
            {
              RoadFlow.Data.Model.MenuUser model = new RoadFlow.Data.Model.MenuUser();
              model.Buttons = this.Request.Form["button_" + str5] ?? "";
              model.SubPageID = Guid.Empty;
              model.ID = Guid.NewGuid();
              model.MenuID = str5.ToGuid();
              model.Organizes = organizes;
              model.Users = str3;
              model.Params = (this.Request.Form["params_" + str5] ?? "").Replace("\"", "");
              menuUser.Add(model);
              string str6 = this.Request.Form["subpage_" + str5] ?? "";
              char[] chArray2 = new char[1]{ ',' };
              foreach (string str7 in str6.Split(chArray2))
              {
                if (str7.IsGuid())
                  menuUser.Add(new RoadFlow.Data.Model.MenuUser()
                  {
                    Buttons = this.Request.Form["button_" + str5 + "_" + str7] ?? "",
                    SubPageID = str7.ToGuid(),
                    ID = Guid.NewGuid(),
                    MenuID = model.MenuID,
                    Organizes = organizes,
                    Users = str3
                  });
              }
            }
          }
          transactionScope.Complete();
          // ISSUE: reference to a compiler-generated field
          if (MembersController.\u003C\u003Eo__28.\u003C\u003Ep__0 == null)
          {
            // ISSUE: reference to a compiler-generated field
            MembersController.\u003C\u003Eo__28.\u003C\u003Ep__0 = CallSite<Func<CallSite, object, string, object>>.Create(Binder.SetMember(CSharpBinderFlags.None, "script", typeof (MembersController), (IEnumerable<CSharpArgumentInfo>) new CSharpArgumentInfo[2]
            {
              CSharpArgumentInfo.Create(CSharpArgumentInfoFlags.None, (string) null),
              CSharpArgumentInfo.Create(CSharpArgumentInfoFlags.UseCompileTimeType | CSharpArgumentInfoFlags.Constant, (string) null)
            }));
          }
          // ISSUE: reference to a compiler-generated field
          // ISSUE: reference to a compiler-generated field
          object obj = MembersController.\u003C\u003Eo__28.\u003C\u003Ep__0.Target((CallSite) MembersController.\u003C\u003Eo__28.\u003C\u003Ep__0, this.ViewBag, "alert('保存成功!');window.location=window.location;");
        }
        menuUser.ClearCache();
      }
      string menuTreeTableHtml = menu.GetMenuTreeTableHtml(orgID, new Guid?());
      // ISSUE: reference to a compiler-generated field
      if (MembersController.\u003C\u003Eo__28.\u003C\u003Ep__1 == null)
      {
        // ISSUE: reference to a compiler-generated field
        MembersController.\u003C\u003Eo__28.\u003C\u003Ep__1 = CallSite<Func<CallSite, object, string, object>>.Create(Binder.SetMember(CSharpBinderFlags.None, "menuhtml", typeof (MembersController), (IEnumerable<CSharpArgumentInfo>) new CSharpArgumentInfo[2]
        {
          CSharpArgumentInfo.Create(CSharpArgumentInfoFlags.None, (string) null),
          CSharpArgumentInfo.Create(CSharpArgumentInfoFlags.UseCompileTimeType, (string) null)
        }));
      }
      // ISSUE: reference to a compiler-generated field
      // ISSUE: reference to a compiler-generated field
      object obj1 = MembersController.\u003C\u003Eo__28.\u003C\u003Ep__1.Target((CallSite) MembersController.\u003C\u003Eo__28.\u003C\u003Ep__1, this.ViewBag, menuTreeTableHtml);
      return (ActionResult) this.View();
    }

    public ActionResult ShowMenu()
    {
      return (ActionResult) this.View();
    }
  }
}
