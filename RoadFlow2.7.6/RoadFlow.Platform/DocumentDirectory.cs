// Decompiled with JetBrains decompiler
// Type: RoadFlow.Platform.DocumentDirectory
// Assembly: RoadFlow.Platform, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 07F26AFD-DE3B-4003-89AF-01A62494BA58
// Assembly location: C:\inetpub\wwwroot\RoadFlowMvc\bin\RoadFlow.Platform.dll

using RoadFlow.Cache.IO;
using RoadFlow.Data.Interface;
using RoadFlow.Utility;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace RoadFlow.Platform
{
  public class DocumentDirectory
  {
    private string DocumentsDirectoryCacheKey = Keys.CacheKeys.DocumentsDirectory.ToString();
    private string DocumentsDirectoryManageUsers = Keys.CacheKeys.DocumentsDirectoryManageUsers.ToString();
    private string DocumentsDirectoryPublishUsers = Keys.CacheKeys.DocumentsDirectoryPublishUsers.ToString();
    private string DocumentsDirectoryReadUsers = Keys.CacheKeys.DocumentsDirectoryReadUsers.ToString();
    private IDocumentDirectory dataDocumentDirectory;

    public DocumentDirectory()
    {
      this.dataDocumentDirectory = RoadFlow.Data.Factory.Factory.GetDocumentDirectory();
    }

    public int Add(RoadFlow.Data.Model.DocumentDirectory model)
    {
      return this.dataDocumentDirectory.Add(model);
    }

    public int Update(RoadFlow.Data.Model.DocumentDirectory model)
    {
      return this.dataDocumentDirectory.Update(model);
    }

    public List<RoadFlow.Data.Model.DocumentDirectory> GetAll(bool fromCache = true)
    {
      if (!fromCache)
        return this.dataDocumentDirectory.GetAll();
      object obj = Opation.Get(this.DocumentsDirectoryCacheKey);
      if (obj is List<RoadFlow.Data.Model.DocumentDirectory>)
        return (List<RoadFlow.Data.Model.DocumentDirectory>) obj;
      List<RoadFlow.Data.Model.DocumentDirectory> all = this.dataDocumentDirectory.GetAll();
      Opation.Set(this.DocumentsDirectoryCacheKey, (object) all);
      return all;
    }

    public RoadFlow.Data.Model.DocumentDirectory Get(Guid id)
    {
      return this.GetAll(true).Find((Predicate<RoadFlow.Data.Model.DocumentDirectory>) (p => p.ID == id));
    }

    public int Delete(Guid id)
    {
      return this.dataDocumentDirectory.Delete(id);
    }

    public long GetCount()
    {
      return this.dataDocumentDirectory.GetCount();
    }

    public void ClearCache()
    {
      Opation.Remove(this.DocumentsDirectoryCacheKey);
    }

    public List<RoadFlow.Data.Model.DocumentDirectory> GetChilds(Guid id)
    {
      return this.GetAll(true).FindAll((Predicate<RoadFlow.Data.Model.DocumentDirectory>) (p => p.ParentID == id)).OrderBy<RoadFlow.Data.Model.DocumentDirectory, int>((Func<RoadFlow.Data.Model.DocumentDirectory, int>) (p => p.Sort)).ToList<RoadFlow.Data.Model.DocumentDirectory>();
    }

    public List<RoadFlow.Data.Model.DocumentDirectory> GetDisplayChilds(Guid id, Guid userID)
    {
      List<RoadFlow.Data.Model.DocumentDirectory> list = this.GetAll(true).FindAll((Predicate<RoadFlow.Data.Model.DocumentDirectory>) (p => p.ParentID == id)).OrderBy<RoadFlow.Data.Model.DocumentDirectory, int>((Func<RoadFlow.Data.Model.DocumentDirectory, int>) (p => p.Sort)).ToList<RoadFlow.Data.Model.DocumentDirectory>();
      List<RoadFlow.Data.Model.DocumentDirectory> documentDirectoryList = new List<RoadFlow.Data.Model.DocumentDirectory>();
      foreach (RoadFlow.Data.Model.DocumentDirectory dir in list)
      {
        if (this.HasDisplay(dir, userID))
          documentDirectoryList.Add(dir);
      }
      return documentDirectoryList;
    }

    public string GetAllChildIdString(Guid id)
    {
      List<RoadFlow.Data.Model.DocumentDirectory> allChilds = this.GetAllChilds(id, true);
      StringBuilder stringBuilder = new StringBuilder();
      foreach (RoadFlow.Data.Model.DocumentDirectory documentDirectory in allChilds)
      {
        stringBuilder.Append((object) documentDirectory.ID);
        stringBuilder.Append(",");
      }
      return stringBuilder.ToString().TrimEnd(',');
    }

    public string GetAllChildIdString(Guid id, Guid userID)
    {
      List<RoadFlow.Data.Model.DocumentDirectory> allChilds = this.GetAllChilds(id, true);
      StringBuilder stringBuilder = new StringBuilder();
      foreach (RoadFlow.Data.Model.DocumentDirectory documentDirectory in allChilds)
      {
        if (this.HasRead(documentDirectory.ID, userID))
        {
          stringBuilder.Append((object) documentDirectory.ID);
          stringBuilder.Append(",");
        }
      }
      return stringBuilder.ToString().TrimEnd(',');
    }

    public List<RoadFlow.Data.Model.DocumentDirectory> GetAllParents(Guid id, bool isMe = false)
    {
      List<RoadFlow.Data.Model.DocumentDirectory> list = new List<RoadFlow.Data.Model.DocumentDirectory>();
      RoadFlow.Data.Model.DocumentDirectory documentDirectory = this.Get(id);
      if (documentDirectory == null)
        return list;
      if (isMe)
        list.Add(documentDirectory);
      this.addParent(list, documentDirectory.ParentID);
      return list;
    }

    private void addParent(List<RoadFlow.Data.Model.DocumentDirectory> list, Guid id)
    {
      if (id.IsEmptyGuid())
        return;
      RoadFlow.Data.Model.DocumentDirectory documentDirectory = this.Get(id);
      if (documentDirectory == null)
        return;
      list.Add(documentDirectory);
      this.addParent(list, documentDirectory.ParentID);
    }

    public string GetAllParentsName(Guid id, bool isMe = true, bool isRoot = true)
    {
      List<RoadFlow.Data.Model.DocumentDirectory> all = this.GetAllParents(id, isMe).FindAll((Predicate<RoadFlow.Data.Model.DocumentDirectory>) (p => !p.ParentID.IsEmptyGuid()));
      StringBuilder stringBuilder = new StringBuilder();
      foreach (RoadFlow.Data.Model.DocumentDirectory documentDirectory in all)
      {
        stringBuilder.Append(documentDirectory.Name);
        stringBuilder.Append(" / ");
      }
      return stringBuilder.ToString().TrimEnd('/', ' ');
    }

    public List<RoadFlow.Data.Model.DocumentDirectory> GetAllChilds(Guid id, bool isMe = true)
    {
      List<RoadFlow.Data.Model.DocumentDirectory> list = new List<RoadFlow.Data.Model.DocumentDirectory>();
      RoadFlow.Data.Model.DocumentDirectory documentDirectory = this.Get(id);
      if (documentDirectory != null)
      {
        if (isMe)
          list.Add(documentDirectory);
        this.addChilds(list, id);
      }
      return list;
    }

    private void addChilds(List<RoadFlow.Data.Model.DocumentDirectory> list, Guid id)
    {
      foreach (RoadFlow.Data.Model.DocumentDirectory child in this.GetChilds(id))
      {
        list.Add(child);
        this.addChilds(list, child.ID);
      }
    }

    public int GetMaxSort(Guid dirID)
    {
      return this.dataDocumentDirectory.GetMaxSort(dirID);
    }

    public RoadFlow.Data.Model.DocumentDirectory GetRoot()
    {
      return this.GetAll(true).Find((Predicate<RoadFlow.Data.Model.DocumentDirectory>) (p => p.ParentID == Guid.Empty));
    }

    public string GetName(Guid id)
    {
      RoadFlow.Data.Model.DocumentDirectory documentDirectory = this.Get(id);
      if (documentDirectory != null)
        return documentDirectory.Name;
      return "";
    }

    public List<RoadFlow.Data.Model.Users> GetReadUsers(Guid dirID)
    {
      object obj = Opation.Get(this.DocumentsDirectoryReadUsers + dirID.ToString("N"));
      if (obj is List<RoadFlow.Data.Model.Users>)
        return (List<RoadFlow.Data.Model.Users>) obj;
      RoadFlow.Data.Model.DocumentDirectory documentDirectory = this.Get(dirID);
      if (documentDirectory == null)
        return new List<RoadFlow.Data.Model.Users>();
      if (!documentDirectory.ReadUsers.IsNullOrEmpty())
      {
        List<RoadFlow.Data.Model.Users> allUsers = new Organize().GetAllUsers(documentDirectory.ReadUsers);
        Opation.Set(this.DocumentsDirectoryReadUsers + dirID.ToString("N"), (object) allUsers);
        return allUsers;
      }
      foreach (RoadFlow.Data.Model.DocumentDirectory allParent in this.GetAllParents(dirID, false))
      {
        if (!allParent.ReadUsers.IsNullOrEmpty())
        {
          List<RoadFlow.Data.Model.Users> allUsers = new Organize().GetAllUsers(allParent.ReadUsers);
          Opation.Set(this.DocumentsDirectoryReadUsers + dirID.ToString("N"), (object) allUsers);
          return allUsers;
        }
      }
      return new List<RoadFlow.Data.Model.Users>();
    }

    public List<RoadFlow.Data.Model.Users> GetPublishUsers(Guid dirID)
    {
      object obj = Opation.Get(this.DocumentsDirectoryPublishUsers + dirID.ToString("N"));
      if (obj is List<RoadFlow.Data.Model.Users>)
        return (List<RoadFlow.Data.Model.Users>) obj;
      RoadFlow.Data.Model.DocumentDirectory documentDirectory = this.Get(dirID);
      if (documentDirectory == null)
        return new List<RoadFlow.Data.Model.Users>();
      if (!documentDirectory.PublishUsers.IsNullOrEmpty())
      {
        List<RoadFlow.Data.Model.Users> allUsers = new Organize().GetAllUsers(documentDirectory.PublishUsers);
        Opation.Set(this.DocumentsDirectoryPublishUsers + dirID.ToString("N"), (object) allUsers);
        return allUsers;
      }
      foreach (RoadFlow.Data.Model.DocumentDirectory allParent in this.GetAllParents(dirID, false))
      {
        if (!allParent.PublishUsers.IsNullOrEmpty())
        {
          List<RoadFlow.Data.Model.Users> allUsers = new Organize().GetAllUsers(allParent.PublishUsers);
          Opation.Set(this.DocumentsDirectoryPublishUsers + dirID.ToString("N"), (object) allUsers);
          return allUsers;
        }
      }
      return new List<RoadFlow.Data.Model.Users>();
    }

    public List<RoadFlow.Data.Model.Users> GetManageUsers(Guid dirID)
    {
      object obj = Opation.Get(this.DocumentsDirectoryManageUsers + dirID.ToString("N"));
      if (obj is List<RoadFlow.Data.Model.Users>)
        return (List<RoadFlow.Data.Model.Users>) obj;
      RoadFlow.Data.Model.DocumentDirectory documentDirectory = this.Get(dirID);
      if (documentDirectory == null)
        return new List<RoadFlow.Data.Model.Users>();
      if (!documentDirectory.ManageUsers.IsNullOrEmpty())
      {
        List<RoadFlow.Data.Model.Users> allUsers = new Organize().GetAllUsers(documentDirectory.ManageUsers);
        Opation.Set(this.DocumentsDirectoryManageUsers + dirID.ToString("N"), (object) allUsers);
        return allUsers;
      }
      foreach (RoadFlow.Data.Model.DocumentDirectory allParent in this.GetAllParents(dirID, false))
      {
        if (!allParent.ManageUsers.IsNullOrEmpty())
        {
          List<RoadFlow.Data.Model.Users> allUsers = new Organize().GetAllUsers(allParent.ManageUsers);
          Opation.Set(this.DocumentsDirectoryManageUsers + dirID.ToString("N"), (object) allUsers);
          return allUsers;
        }
      }
      return new List<RoadFlow.Data.Model.Users>();
    }

    public void ClearDirUsersCache(Guid dirID)
    {
      Opation.Remove(this.DocumentsDirectoryReadUsers + dirID.ToString("N"));
      Opation.Remove(this.DocumentsDirectoryPublishUsers + dirID.ToString("N"));
      Opation.Remove(this.DocumentsDirectoryManageUsers + dirID.ToString("N"));
    }

    public void ClearAllDirUsersCache()
    {
      foreach (RoadFlow.Data.Model.DocumentDirectory documentDirectory in this.GetAll(true))
        this.ClearDirUsersCache(documentDirectory.ID);
    }

    public bool HasRead(Guid dirID, Guid userID)
    {
      return this.GetReadUsers(dirID).Find((Predicate<RoadFlow.Data.Model.Users>) (p => p.ID == userID)) != null;
    }

    public bool HasPublish(Guid dirID, Guid userID)
    {
      return this.GetPublishUsers(dirID).Find((Predicate<RoadFlow.Data.Model.Users>) (p => p.ID == userID)) != null;
    }

    public bool HasManage(Guid dirID, Guid userID)
    {
      return this.GetManageUsers(dirID).Find((Predicate<RoadFlow.Data.Model.Users>) (p => p.ID == userID)) != null;
    }

    public bool HasDisplay(RoadFlow.Data.Model.DocumentDirectory dir, Guid userID)
    {
      if (dir == null)
        return false;
      if (this.HasManage(dir.ID, userID) || this.HasRead(dir.ID, userID) || this.HasPublish(dir.ID, userID))
        return true;
      foreach (RoadFlow.Data.Model.DocumentDirectory allChild in this.GetAllChilds(dir.ID, true))
      {
        if (this.HasManage(allChild.ID, userID) || this.HasRead(allChild.ID, userID) || this.HasPublish(allChild.ID, userID))
          return true;
      }
      return false;
    }

    public System.Collections.Generic.Dictionary<Guid, string> GetDirs(Guid userID)
    {
      List<RoadFlow.Data.Model.DocumentDirectory> all = this.GetAll(true);
      System.Collections.Generic.Dictionary<Guid, string> dictionary = new System.Collections.Generic.Dictionary<Guid, string>();
      foreach (RoadFlow.Data.Model.DocumentDirectory dir in all)
      {
        if (this.HasDisplay(dir, userID))
          dictionary.Add(dir.ID, this.GetAllParentsName(dir.ID, true, false));
      }
      return dictionary;
    }

    public string GetTreeJsonString()
    {
      List<RoadFlow.Data.Model.DocumentDirectory> childs1 = this.GetChilds(Guid.Empty);
      StringBuilder stringBuilder = new StringBuilder();
      foreach (RoadFlow.Data.Model.DocumentDirectory documentDirectory1 in childs1)
      {
        List<RoadFlow.Data.Model.DocumentDirectory> displayChilds = this.GetDisplayChilds(documentDirectory1.ID, Users.CurrentUserID);
        stringBuilder.Append("{");
        stringBuilder.AppendFormat("\"id\":\"{0}\",", (object) documentDirectory1.ID);
        stringBuilder.AppendFormat("\"parentID\":\"{0}\",", (object) documentDirectory1.ParentID);
        stringBuilder.AppendFormat("\"title\":\"{0}\",", (object) documentDirectory1.Name.Replace1("\"", "'"));
        stringBuilder.AppendFormat("\"type\":\"{0}\",", (object) "2");
        stringBuilder.AppendFormat("\"ico\":\"{0}\",", (object) "");
        stringBuilder.AppendFormat("\"hasChilds\":\"{0}\",", displayChilds.Count > 0 ? (object) "1" : (object) "0");
        stringBuilder.Append("\"childs\":[");
        foreach (RoadFlow.Data.Model.DocumentDirectory documentDirectory2 in displayChilds)
        {
          List<RoadFlow.Data.Model.DocumentDirectory> childs2 = this.GetChilds(documentDirectory2.ID);
          stringBuilder.Append("{");
          stringBuilder.AppendFormat("\"id\":\"{0}\",", (object) documentDirectory2.ID);
          stringBuilder.AppendFormat("\"parentID\":\"{0}\",", (object) documentDirectory2.ParentID);
          stringBuilder.AppendFormat("\"title\":\"{0}\",", (object) documentDirectory2.Name.Replace1("\"", "'"));
          stringBuilder.AppendFormat("\"type\":\"{0}\",", (object) "2");
          stringBuilder.AppendFormat("\"ico\":\"{0}\",", (object) "");
          stringBuilder.AppendFormat("\"hasChilds\":\"{0}\",", childs2.Count > 0 ? (object) "1" : (object) "0");
          stringBuilder.Append("\"childs\":[");
          stringBuilder.Append("]}");
          if (documentDirectory2.ID != displayChilds.Last<RoadFlow.Data.Model.DocumentDirectory>().ID)
            stringBuilder.Append(",");
        }
        stringBuilder.Append("]},");
      }
      return "[" + stringBuilder.ToString().TrimEnd(',') + "]";
    }

    public string GetTreeRefreshJsonString(Guid refreshID)
    {
      List<RoadFlow.Data.Model.DocumentDirectory> displayChilds1 = this.GetDisplayChilds(refreshID, Users.CurrentUserID);
      StringBuilder stringBuilder = new StringBuilder();
      foreach (RoadFlow.Data.Model.DocumentDirectory documentDirectory in displayChilds1)
      {
        List<RoadFlow.Data.Model.DocumentDirectory> displayChilds2 = this.GetDisplayChilds(documentDirectory.ID, Users.CurrentUserID);
        stringBuilder.Append("{");
        stringBuilder.AppendFormat("\"id\":\"{0}\",", (object) documentDirectory.ID);
        stringBuilder.AppendFormat("\"parentID\":\"{0}\",", (object) documentDirectory.ParentID);
        stringBuilder.AppendFormat("\"title\":\"{0}\",", (object) documentDirectory.Name.Replace1("\"", "'"));
        stringBuilder.AppendFormat("\"type\":\"{0}\",", (object) "2");
        stringBuilder.AppendFormat("\"ico\":\"{0}\",", (object) "");
        stringBuilder.AppendFormat("\"hasChilds\":\"{0}\",", displayChilds2.Count > 0 ? (object) "1" : (object) "0");
        stringBuilder.Append("\"childs\":[");
        stringBuilder.Append("]},");
      }
      return "[" + stringBuilder.ToString().TrimEnd(',') + "]";
    }
  }
}
