// Decompiled with JetBrains decompiler
// Type: RoadFlow.Platform.Users
// Assembly: RoadFlow.Platform, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 07F26AFD-DE3B-4003-89AF-01A62494BA58
// Assembly location: C:\inetpub\wwwroot\RoadFlowMvc\bin\RoadFlow.Platform.dll

using RoadFlow.Cache.IO;
using RoadFlow.Data.Interface;
using RoadFlow.Utility;
using System;
using System.Collections.Generic;
using System.Web;

namespace RoadFlow.Platform
{
  public class Users
  {
    public const string PREFIX = "u_";
    private IUsers dataUsers;

    public Users()
    {
      this.dataUsers = RoadFlow.Data.Factory.Factory.GetUsers();
    }

    public int Add(RoadFlow.Data.Model.Users model)
    {
      return this.dataUsers.Add(model);
    }

    public int Update(RoadFlow.Data.Model.Users model)
    {
      return this.dataUsers.Update(model);
    }

    public List<RoadFlow.Data.Model.Users> GetAll()
    {
      return this.dataUsers.GetAll();
    }

    public RoadFlow.Data.Model.Users Get(Guid id)
    {
      return this.dataUsers.Get(id);
    }

    public int Delete(Guid id)
    {
      if (RoadFlow.Utility.Config.IsDemo)
        return 0;
      return this.dataUsers.Delete(id);
    }

    public long GetCount()
    {
      return this.dataUsers.GetCount();
    }

    public RoadFlow.Data.Model.Users GetByAccount(string account)
    {
      if (!account.IsNullOrEmpty())
        return this.dataUsers.GetByAccount(account);
      return (RoadFlow.Data.Model.Users) null;
    }

    public string GetInitPassword()
    {
      return RoadFlow.Utility.Config.SystemInitPassword;
    }

    public string EncryptionPassword(string password)
    {
      if (password.IsNullOrEmpty())
        return "";
      HashEncrypt hashEncrypt = new HashEncrypt();
      return hashEncrypt.MD5System(hashEncrypt.MD5System(password));
    }

    public string GetUserEncryptionPassword(string userID, string password)
    {
      if (!password.IsNullOrEmpty() && !userID.IsNullOrEmpty())
        return this.EncryptionPassword(userID.Trim().ToLower() + password.Trim());
      return "";
    }

    public bool InitPassword(Guid userID)
    {
      return this.dataUsers.UpdatePassword(this.GetUserEncryptionPassword(userID.ToString(), this.GetInitPassword()), userID);
    }

    public List<RoadFlow.Data.Model.Users> GetAllByOrganizeID(Guid organizeID)
    {
      return this.dataUsers.GetAllByOrganizeID(organizeID);
    }

    public System.Collections.Generic.Dictionary<Guid, bool> GetAllStation(Guid userID)
    {
      List<RoadFlow.Data.Model.UsersRelation> allByUserId = new UsersRelation().GetAllByUserID(userID);
      System.Collections.Generic.Dictionary<Guid, bool> dictionary = new System.Collections.Generic.Dictionary<Guid, bool>();
      foreach (RoadFlow.Data.Model.UsersRelation usersRelation in allByUserId)
      {
        if (!dictionary.ContainsKey(usersRelation.OrganizeID))
          dictionary.Add(usersRelation.OrganizeID, usersRelation.IsMain == 1);
      }
      return dictionary;
    }

    public Guid GetMainStation(Guid userID)
    {
      RoadFlow.Data.Model.UsersRelation mainByUserId = new UsersRelation().GetMainByUserID(userID);
      if (mainByUserId != null)
        return mainByUserId.OrganizeID;
      return Guid.Empty;
    }

    public List<RoadFlow.Data.Model.Users> GetAllByOrganizeIDArray(Guid[] organizeIDArray)
    {
      return this.dataUsers.GetAllByOrganizeIDArray(organizeIDArray);
    }

    public RoadFlow.Data.Model.Organize GetUnitByUserID(Guid userID)
    {
      string key = Keys.CacheKeys.UserUnit.ToString();
      object obj = Opation.Get(key);
      System.Collections.Generic.Dictionary<Guid, RoadFlow.Data.Model.Organize> dictionary = new System.Collections.Generic.Dictionary<Guid, RoadFlow.Data.Model.Organize>();
      if (obj is System.Collections.Generic.Dictionary<Guid, RoadFlow.Data.Model.Organize>)
      {
        dictionary = (System.Collections.Generic.Dictionary<Guid, RoadFlow.Data.Model.Organize>) obj;
        if (dictionary.ContainsKey(userID))
          return dictionary[userID];
      }
      Guid mainStation = this.GetMainStation(userID);
      if (mainStation == Guid.Empty)
        return (RoadFlow.Data.Model.Organize) null;
      List<RoadFlow.Data.Model.Organize> allParent = new Organize().GetAllParent(mainStation);
      allParent.Reverse();
      foreach (RoadFlow.Data.Model.Organize organize in allParent)
      {
        if (organize.Type == 1)
        {
          dictionary.Add(userID, organize);
          Opation.Set(key, (object) dictionary);
          return organize;
        }
      }
      return (RoadFlow.Data.Model.Organize) null;
    }

    public static RoadFlow.Data.Model.Organize CurrentUnit
    {
      get
      {
        return new Users().GetUnitByUserID(Users.CurrentUserID);
      }
    }

    public static Guid CurrentUnitID
    {
      get
      {
        RoadFlow.Data.Model.Organize unitByUserId = new Users().GetUnitByUserID(Users.CurrentUserID);
        if (unitByUserId != null)
          return unitByUserId.ID;
        return Guid.Empty;
      }
    }

    public static string CurrentUnitName
    {
      get
      {
        RoadFlow.Data.Model.Organize unitByUserId = new Users().GetUnitByUserID(Users.CurrentUserID);
        if (unitByUserId != null)
          return unitByUserId.Name;
        return "";
      }
    }

    public RoadFlow.Data.Model.Organize GetDeptByUserID(Guid userID)
    {
      string key = Keys.CacheKeys.UserDept.ToString();
      object obj = Opation.Get(key);
      System.Collections.Generic.Dictionary<Guid, RoadFlow.Data.Model.Organize> dictionary = new System.Collections.Generic.Dictionary<Guid, RoadFlow.Data.Model.Organize>();
      if (obj is System.Collections.Generic.Dictionary<Guid, RoadFlow.Data.Model.Organize>)
      {
        dictionary = (System.Collections.Generic.Dictionary<Guid, RoadFlow.Data.Model.Organize>) obj;
        if (dictionary.ContainsKey(userID))
          return dictionary[userID];
      }
      Guid mainStation = this.GetMainStation(userID);
      if (mainStation == Guid.Empty)
        return (RoadFlow.Data.Model.Organize) null;
      List<RoadFlow.Data.Model.Organize> allParent = new Organize().GetAllParent(mainStation);
      allParent.Reverse();
      foreach (RoadFlow.Data.Model.Organize organize in allParent)
      {
        if (organize.Type == 2)
        {
          dictionary.Add(userID, organize);
          Opation.Set(key, (object) dictionary);
          return organize;
        }
      }
      return (RoadFlow.Data.Model.Organize) null;
    }

    public static RoadFlow.Data.Model.Organize CurrentDept
    {
      get
      {
        return new Users().GetDeptByUserID(Users.CurrentUserID);
      }
    }

    public static Guid CurrentDeptID
    {
      get
      {
        RoadFlow.Data.Model.Organize deptByUserId = new Users().GetDeptByUserID(Users.CurrentUserID);
        if (deptByUserId != null)
          return deptByUserId.ID;
        return Guid.Empty;
      }
    }

    public static string CurrentDeptName
    {
      get
      {
        RoadFlow.Data.Model.Organize deptByUserId = new Users().GetDeptByUserID(Users.CurrentUserID);
        if (deptByUserId != null)
          return deptByUserId.Name;
        return "";
      }
    }

    public bool HasAccount(string account, string userID = "")
    {
      if (!account.IsNullOrEmpty())
        return this.dataUsers.HasAccount(account.Trim(), userID);
      return false;
    }

    public bool UpdatePassword(string password, Guid userID)
    {
      if (RoadFlow.Utility.Config.IsDemo)
        return true;
      if (!password.IsNullOrEmpty())
        return this.dataUsers.UpdatePassword(this.GetUserEncryptionPassword(userID.ToString(), password.Trim()), userID);
      return false;
    }

    public static Guid CurrentUserID
    {
      get
      {
        try
        {
          object obj = HttpContext.Current.Session[Keys.SessionKeys.UserID.ToString()];
          return obj == null ? RoadFlow.Platform.WeiXin.Organize.CurrentUserID : obj.ToString().ToGuid();
        }
        catch
        {
          return Guid.Empty;
        }
      }
    }

    public static RoadFlow.Data.Model.Users CurrentUser
    {
      get
      {
        Guid currentUserId = Users.CurrentUserID;
        if (currentUserId == Guid.Empty)
          return (RoadFlow.Data.Model.Users) null;
        return new Users().Get(currentUserId);
      }
    }

    public static string CurrentUserName
    {
      get
      {
        string index = Keys.SessionKeys.UserName.ToString();
        object obj = HttpContext.Current.Session[index];
        string empty = string.Empty;
        string str;
        if (obj == null)
        {
          str = Users.CurrentUser == null ? "" : Users.CurrentUser.Name;
          HttpContext.Current.Session[index] = (object) str;
        }
        else
          str = obj.ToString();
        if (str.IsNullOrEmpty())
          str = RoadFlow.Platform.WeiXin.Organize.CurrentUserName;
        return str;
      }
    }

    public static string CurrentUserAccount
    {
      get
      {
        if (Users.CurrentUser != null)
          return Users.CurrentUser.Account;
        return "";
      }
    }

    public string GetAccount(string account)
    {
      if (account.IsNullOrEmpty())
        return "";
      string account1 = account.Trim();
      int num = 0;
      while (this.HasAccount(account1, ""))
        account1 += (++num).ToString();
      return account1;
    }

    public int UpdateSort(Guid userID, int sort)
    {
      return this.dataUsers.UpdateSort(userID, sort);
    }

    public string GetName(Guid id)
    {
      RoadFlow.Data.Model.Users users = this.Get(id);
      if (users != null)
        return users.Name;
      return "";
    }

    public static string RemovePrefix(string id)
    {
      if (id.IsNullOrEmpty())
        return "";
      if (id.StartsWith("u_"))
        return id.Replace("u_", "");
      return id;
    }

    public string RemovePrefix1(string id)
    {
      if (!id.IsNullOrEmpty())
        return id.Replace("u_", "");
      return "";
    }

    public string GetLeader(Guid userID)
    {
      Guid mainStation = this.GetMainStation(userID);
      Organize organize1 = new Organize();
      RoadFlow.Data.Model.Organize organize2 = organize1.Get(mainStation);
      if (organize2 == null)
        return "";
      if (!organize2.Leader.IsNullOrEmpty())
        return organize2.Leader;
      foreach (RoadFlow.Data.Model.Organize organize3 in organize1.GetAllParent(organize2.Number))
      {
        if (!organize3.Leader.IsNullOrEmpty())
          return organize3.Leader;
      }
      return "";
    }

    public string GetChargeLeader(Guid userID)
    {
      Guid mainStation = this.GetMainStation(userID);
      Organize organize1 = new Organize();
      RoadFlow.Data.Model.Organize organize2 = organize1.Get(mainStation);
      if (organize2 == null)
        return "";
      if (!organize2.ChargeLeader.IsNullOrEmpty())
        return organize2.ChargeLeader;
      foreach (RoadFlow.Data.Model.Organize organize3 in organize1.GetAllParent(organize2.Number))
      {
        if (!organize3.ChargeLeader.IsNullOrEmpty())
          return organize3.ChargeLeader;
      }
      return "";
    }

    public string GetParentDeptLeader(Guid userID)
    {
      Guid mainStation = this.GetMainStation(userID);
      Organize organize1 = new Organize();
      RoadFlow.Data.Model.Organize organize2 = organize1.Get(mainStation);
      if (organize2 == null)
        return "";
      foreach (RoadFlow.Data.Model.Organize organize3 in organize1.GetAllParent(organize2.Number))
      {
        if (!organize3.Leader.IsNullOrEmpty())
          return organize3.Leader;
      }
      return "";
    }

    public bool IsLeader(Guid userID)
    {
      return this.GetLeader(userID).Contains(userID.ToString(), StringComparison.CurrentCultureIgnoreCase);
    }

    public bool IsChargeLeader(Guid userID)
    {
      return this.GetChargeLeader(userID).Contains(userID.ToString(), StringComparison.CurrentCultureIgnoreCase);
    }

    public bool IsContains(Guid userID, string memberString)
    {
      if (memberString.IsNullOrEmpty())
        return false;
      return new Organize().GetAllUsers(memberString).Find((Predicate<RoadFlow.Data.Model.Users>) (p => p.ID == userID)) != null;
    }

    public string GetMobileNumber(Guid userID)
    {
      RoadFlow.Data.Model.Users users = new Users().Get(userID);
      if (users == null)
        return "";
      return users.Mobile;
    }

    public List<RoadFlow.Data.Model.Users> GetAllByIDString(string idString)
    {
      if (idString.IsNullOrEmpty())
        return new List<RoadFlow.Data.Model.Users>();
      return this.dataUsers.GetAllByIDString(idString);
    }

    public List<RoadFlow.Data.Model.Users> GetAllByWorkGroupID(Guid workgroupid)
    {
      return this.dataUsers.GetAllByWorkGroupID(workgroupid);
    }

    public string GetAccountByID(Guid id)
    {
      RoadFlow.Data.Model.Users users = this.Get(id);
      if (users != null)
        return users.Account;
      return "";
    }

    public List<string> GetAllParentsDeptLeader(Guid userID)
    {
      List<string> stringList = new List<string>();
      Guid mainStation = this.GetMainStation(userID);
      if (mainStation.IsEmptyGuid())
        return stringList;
      RoadFlow.Data.Model.Organize organize1 = new Organize().Get(mainStation);
      if (organize1 == null)
        return stringList;
      if (!organize1.Leader.IsNullOrEmpty())
        stringList.Add(organize1.Leader);
      foreach (RoadFlow.Data.Model.Organize organize2 in new Organize().GetAllParent(mainStation))
      {
        if (!organize2.Leader.IsNullOrEmpty())
          stringList.Add(organize2.Leader);
      }
      return stringList;
    }
  }
}
