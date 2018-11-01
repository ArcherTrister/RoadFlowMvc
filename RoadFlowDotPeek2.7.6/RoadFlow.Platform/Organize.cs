// Decompiled with JetBrains decompiler
// Type: RoadFlow.Platform.Organize
// Assembly: RoadFlow.Platform, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 07F26AFD-DE3B-4003-89AF-01A62494BA58
// Assembly location: C:\inetpub\wwwroot\RoadFlowMvc\bin\RoadFlow.Platform.dll

using RoadFlow.Data.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Transactions;

namespace RoadFlow.Platform
{
  public class Organize
  {
    private IOrganize dataOrganize;

    public Organize()
    {
      this.dataOrganize = RoadFlow.Data.Factory.Factory.GetOrganize();
    }

    public int Add(RoadFlow.Data.Model.Organize model)
    {
      return this.dataOrganize.Add(model);
    }

    public int Update(RoadFlow.Data.Model.Organize model)
    {
      return this.dataOrganize.Update(model);
    }

    public List<RoadFlow.Data.Model.Organize> GetAll()
    {
      return this.dataOrganize.GetAll();
    }

    public RoadFlow.Data.Model.Organize Get(Guid id)
    {
      return this.dataOrganize.Get(id);
    }

    public int Delete(Guid id)
    {
      if (RoadFlow.Utility.Config.IsDemo)
        return 0;
      return this.dataOrganize.Delete(id);
    }

    public long GetCount()
    {
      return this.dataOrganize.GetCount();
    }

    public RoadFlow.Data.Model.Organize GetRoot()
    {
      return this.dataOrganize.GetRoot();
    }

    public List<RoadFlow.Data.Model.Organize> GetChilds(Guid ID)
    {
      return this.dataOrganize.GetChilds(ID);
    }

    private System.Collections.Generic.Dictionary<int, string> types
    {
      get
      {
        return new System.Collections.Generic.Dictionary<int, string>() { { 1, "单位" }, { 2, "部门" }, { 3, "岗位" } };
      }
    }

    private System.Collections.Generic.Dictionary<int, string> status
    {
      get
      {
        return new System.Collections.Generic.Dictionary<int, string>() { { 0, "正常" }, { 1, "冻结" } };
      }
    }

    private System.Collections.Generic.Dictionary<int, string> sexs
    {
      get
      {
        return new System.Collections.Generic.Dictionary<int, string>() { { 0, "男" }, { 1, "女" } };
      }
    }

    public string GetTypeRadio(string name, string value = "", string attributes = "")
    {
      StringBuilder stringBuilder = new StringBuilder();
      foreach (KeyValuePair<int, string> type in this.types)
        stringBuilder.AppendFormat("<input type=\"radio\" style=\"vertical-align:middle;\" value=\"{0}\" id=\"orgtypes_{0}\" {1} name=\"{2}\" {3} /><label style=\"vertical-align:middle;\" for=\"orgtypes_{0}\">{4}</label>", (object) type.Key, type.Key.ToString() == value ? (object) "checked=\"checked\"" : (object) "", (object) name, (object) attributes, (object) type.Value);
      return stringBuilder.ToString();
    }

    public string GetStatusRadio(string name, string value = "", string attributes = "")
    {
      StringBuilder stringBuilder = new StringBuilder();
      foreach (KeyValuePair<int, string> statu in this.status)
        stringBuilder.AppendFormat("<input type=\"radio\" style=\"vertical-align:middle;\" value=\"{0}\" id=\"orgstatus_{0}\" {1} name=\"{2}\" {3}/><label style=\"vertical-align:middle;\" for=\"orgstatus_{0}\">{4}</label>", (object) statu.Key, statu.Key.ToString() == value ? (object) "checked=\"checked\"" : (object) "", (object) name, (object) attributes, (object) statu.Value);
      return stringBuilder.ToString();
    }

    public string GetSexRadio(string name, string value = "", string attributes = "")
    {
      StringBuilder stringBuilder = new StringBuilder();
      foreach (KeyValuePair<int, string> sex in this.sexs)
        stringBuilder.AppendFormat("<input type=\"radio\" style=\"vertical-align:middle;\" value=\"{0}\" id=\"sexstatus_{0}\" {1} name=\"{2}\" {3}/><label style=\"vertical-align:middle;\" for=\"sexstatus_{0}\">{4}</label>", (object) sex.Key, sex.Key.ToString() == value ? (object) "checked=\"checked\"" : (object) "", (object) name, (object) attributes, (object) sex.Value);
      return stringBuilder.ToString();
    }

    public int GetMaxSort(Guid id)
    {
      return this.dataOrganize.GetMaxSort(id);
    }

    public List<RoadFlow.Data.Model.Users> GetAllUsers(Guid id)
    {
      List<RoadFlow.Data.Model.Organize> allChilds = this.GetAllChilds(id);
      List<Guid> guidList = new List<Guid>();
      guidList.Add(id);
      foreach (RoadFlow.Data.Model.Organize organize in allChilds)
        guidList.Add(organize.ID);
      return new Users().GetAllByOrganizeIDArray(guidList.ToArray());
    }

    public List<RoadFlow.Data.Model.Users> GetAllUsers(string idString)
    {
      if (idString.IsNullOrEmpty())
        return new List<RoadFlow.Data.Model.Users>();
      string[] strArray = idString.Split(new char[1]{ ',' }, StringSplitOptions.RemoveEmptyEntries);
      List<RoadFlow.Data.Model.Users> usersList = new List<RoadFlow.Data.Model.Users>();
      Users users = new Users();
      WorkGroup workGroup = new WorkGroup();
      foreach (string str in strArray)
      {
        if (str.StartsWith("u_"))
          usersList.Add(users.Get(Users.RemovePrefix(str).ToGuid()));
        else if (str.IsGuid())
          usersList.AddRange((IEnumerable<RoadFlow.Data.Model.Users>) this.GetAllUsers(str.ToGuid()));
        else if (str.StartsWith("w_"))
          this.addWorkGroupUsers(usersList, WorkGroup.RemovePrefix(str).ToGuid());
      }
      usersList.RemoveAll((Predicate<RoadFlow.Data.Model.Users>) (p => p == null));
      return usersList.Distinct<RoadFlow.Data.Model.Users>((IEqualityComparer<RoadFlow.Data.Model.Users>) new UsersEqualityComparer()).ToList<RoadFlow.Data.Model.Users>();
    }

    private void addWorkGroupUsers(List<RoadFlow.Data.Model.Users> userList, Guid workGroupID)
    {
      RoadFlow.Data.Model.WorkGroup workGroup1 = new WorkGroup().Get(workGroupID);
      if (workGroup1 == null || workGroup1.Members.IsNullOrEmpty())
        return;
      string[] strArray = workGroup1.Members.Split(new char[1]{ ',' }, StringSplitOptions.RemoveEmptyEntries);
      Users users = new Users();
      WorkGroup workGroup2 = new WorkGroup();
      foreach (string str in strArray)
      {
        if (str.StartsWith("u_"))
          userList.Add(users.Get(Users.RemovePrefix(str).ToGuid()));
        else if (str.IsGuid())
          userList.AddRange((IEnumerable<RoadFlow.Data.Model.Users>) this.GetAllUsers(str.ToGuid()));
        else if (str.StartsWith("w_"))
          this.addWorkGroupUsers(userList, WorkGroup.RemovePrefix(str).ToGuid());
      }
    }

    public List<Guid> GetAllUsersIdList(string idString)
    {
      List<RoadFlow.Data.Model.Users> allUsers = this.GetAllUsers(idString);
      List<Guid> guidList = new List<Guid>();
      foreach (RoadFlow.Data.Model.Users users in allUsers)
      {
        if (users != null)
          guidList.Add(users.ID);
      }
      return guidList;
    }

    public List<Guid> GetAllUsersIdList(Guid id)
    {
      List<RoadFlow.Data.Model.Users> allUsers = this.GetAllUsers(id);
      List<Guid> guidList = new List<Guid>();
      foreach (RoadFlow.Data.Model.Users users in allUsers)
      {
        if (users != null)
          guidList.Add(users.ID);
      }
      return guidList;
    }

    public string GetAllUsersIdString(Guid id)
    {
      StringBuilder stringBuilder = new StringBuilder();
      foreach (Guid allUsersId in this.GetAllUsersIdList(id))
      {
        stringBuilder.Append((object) allUsersId);
        stringBuilder.Append(",");
      }
      return stringBuilder.ToString().TrimEnd(',');
    }

    public string GetAllUsersIdString(string idString)
    {
      StringBuilder stringBuilder = new StringBuilder();
      foreach (Guid allUsersId in this.GetAllUsersIdList(idString))
      {
        stringBuilder.Append((object) allUsersId);
        stringBuilder.Append(",");
      }
      return stringBuilder.ToString().TrimEnd(',');
    }

    public int UpdateChildsLength(Guid id)
    {
      int num = 0;
      if (this.Get(id) == null)
        return num;
      int length = this.GetChilds(id).Count + this.GetAllUsers(id).Count;
      this.dataOrganize.UpdateChildsLength(id, length);
      return length;
    }

    public int UpdateSort(Guid id, int sort)
    {
      return this.dataOrganize.UpdateSort(id, sort);
    }

    public List<RoadFlow.Data.Model.Organize> GetAllParent(string number)
    {
      if (!number.IsNullOrEmpty())
        return this.dataOrganize.GetAllParent(number);
      return new List<RoadFlow.Data.Model.Organize>();
    }

    public List<RoadFlow.Data.Model.Organize> GetAllParent(Guid id)
    {
      RoadFlow.Data.Model.Organize organize = this.Get(id);
      if (organize == null)
        return new List<RoadFlow.Data.Model.Organize>();
      return this.dataOrganize.GetAllParent(organize.Number);
    }

    public List<RoadFlow.Data.Model.Organize> GetAllChilds(string number)
    {
      if (!number.IsNullOrEmpty())
        return this.dataOrganize.GetAllChild(number);
      return new List<RoadFlow.Data.Model.Organize>();
    }

    public List<RoadFlow.Data.Model.Organize> GetAllChilds(Guid id)
    {
      RoadFlow.Data.Model.Organize organize = this.Get(id);
      if (organize == null)
        return new List<RoadFlow.Data.Model.Organize>();
      return this.dataOrganize.GetAllChild(organize.Number);
    }

    public string GetAllParentNames(Guid id, bool reverse = false, string split = " / ")
    {
      List<RoadFlow.Data.Model.Organize> allParent = this.GetAllParent(id);
      if (reverse)
        allParent.Reverse();
      StringBuilder stringBuilder = new StringBuilder(allParent.Count * 100);
      int num = 0;
      foreach (RoadFlow.Data.Model.Organize organize in allParent)
      {
        stringBuilder.Append(organize.Name);
        if (num++ < allParent.Count - 1)
          stringBuilder.Append(split);
      }
      return stringBuilder.ToString();
    }

    public bool Move(Guid fromID, Guid toID)
    {
      RoadFlow.Data.Model.Organize organize1 = this.Get(fromID);
      RoadFlow.Data.Model.Organize organize2 = this.Get(toID);
      if (organize1 == null || organize2 == null || organize2.Number.StartsWith(organize1.Number, StringComparison.CurrentCultureIgnoreCase))
        return false;
      using (TransactionScope transactionScope = new TransactionScope())
      {
        Guid parentId = organize1.ParentID;
        organize1.ParentID = toID;
        organize1.Depth = organize2.Depth + 1;
        organize1.Number = organize2.Number + "," + organize1.ID.ToString();
        this.Update(organize1);
        if (RoadFlow.Platform.WeiXin.Config.IsUse)
          new RoadFlow.Platform.WeiXin.Organize().EditDept(organize1);
        foreach (RoadFlow.Data.Model.Organize model in (IEnumerable<RoadFlow.Data.Model.Organize>) this.GetAllChilds(fromID).OrderBy<RoadFlow.Data.Model.Organize, int>((Func<RoadFlow.Data.Model.Organize, int>) (p => p.Depth)))
        {
          model.Number = this.Get(model.ParentID).Number + "," + model.ID.ToString();
          model.Depth = model.Number.Split(',').Length - 1;
          this.Update(model);
        }
        this.UpdateChildsLength(toID);
        this.UpdateChildsLength(parentId);
        transactionScope.Complete();
        return true;
      }
    }

    public string GetName(Guid id)
    {
      RoadFlow.Data.Model.Organize organize = this.Get(id);
      if (organize != null)
        return organize.Name;
      return "";
    }

    public string GetName(string id)
    {
      string empty = string.Empty;
      if (id.IsGuid())
        return this.GetName(id.ToGuid());
      if (id.StartsWith("u_"))
      {
        Guid test;
        if (!Users.RemovePrefix(id).IsGuid(out test))
          return "";
        return new Users().GetName(test);
      }
      Guid test1;
      if (id.StartsWith("w_") && WorkGroup.RemovePrefix(id).IsGuid(out test1))
        return new WorkGroup().GetName(test1);
      return "";
    }

    public string GetNames(string idString, string split = ",")
    {
      if (idString.IsNullOrEmpty())
        return "";
      string[] strArray = idString.Split(',');
      StringBuilder stringBuilder = new StringBuilder(strArray.Length * 50);
      int num1 = 0;
      int num2 = 1;
      foreach (string str in strArray)
      {
        if (str.IsNullOrEmpty())
        {
          ++num2;
        }
        else
        {
          string name = this.GetName(str);
          if (name.IsNullOrEmpty())
          {
            ++num2;
          }
          else
          {
            stringBuilder.Append(name);
            if (num1++ < strArray.Length - num2)
              stringBuilder.Append(split);
          }
        }
      }
      return stringBuilder.ToString();
    }

    public int DeleteAndAllChilds(Guid orgID)
    {
      int num = 0;
      using (TransactionScope transactionScope = new TransactionScope())
      {
        UsersRelation usersRelation1 = new UsersRelation();
        Users users1 = new Users();
        List<RoadFlow.Data.Model.Organize> allChilds = this.GetAllChilds(orgID);
        List<string> stringList = new List<string>();
        List<RoadFlow.Data.Model.Organize> organizeList = new List<RoadFlow.Data.Model.Organize>();
        foreach (RoadFlow.Data.Model.Organize organize in allChilds)
        {
          foreach (RoadFlow.Data.Model.UsersRelation usersRelation2 in usersRelation1.GetAllByOrganizeID(organize.ID).FindAll((Predicate<RoadFlow.Data.Model.UsersRelation>) (p => p.IsMain == 1)))
          {
            RoadFlow.Data.Model.Users users2 = users1.Get(usersRelation2.UserID);
            usersRelation1.Delete(usersRelation2.UserID, usersRelation2.OrganizeID);
            num += users1.Delete(usersRelation2.UserID);
            if (users2 != null)
              stringList.Add(users2.Account);
          }
          num += this.Delete(organize.ID);
          organizeList.Add(organize);
        }
        foreach (RoadFlow.Data.Model.UsersRelation usersRelation2 in usersRelation1.GetAllByOrganizeID(orgID).FindAll((Predicate<RoadFlow.Data.Model.UsersRelation>) (p => p.IsMain == 1)))
        {
          usersRelation1.Delete(usersRelation2.UserID, usersRelation2.OrganizeID);
          num += users1.Delete(usersRelation2.UserID);
          RoadFlow.Data.Model.Users users2 = users1.Get(usersRelation2.UserID);
          if (users2 != null)
            stringList.Add(users2.Account);
        }
        num += this.Delete(orgID);
        RoadFlow.Data.Model.Organize organize1 = this.Get(orgID);
        if (organize1 != null)
          organizeList.Add(organize1);
        if (RoadFlow.Platform.WeiXin.Config.IsUse)
        {
          RoadFlow.Platform.WeiXin.Organize organize2 = new RoadFlow.Platform.WeiXin.Organize();
          if (stringList.Count > 0)
            organize2.DeleteUserAsync(stringList.ToArray());
          foreach (RoadFlow.Data.Model.Organize organize3 in organizeList)
            organize2.DeleteDeptAsync(organize3.IntID);
        }
        transactionScope.Complete();
      }
      return num;
    }
  }
}
