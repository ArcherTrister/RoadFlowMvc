// Decompiled with JetBrains decompiler
// Type: RoadFlow.Platform.WorkFlowComment
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
  public class WorkFlowComment
  {
    private IWorkFlowComment dataWorkFlowComment;

    public WorkFlowComment()
    {
      this.dataWorkFlowComment = RoadFlow.Data.Factory.Factory.GetWorkFlowComment();
    }

    public int Add(RoadFlow.Data.Model.WorkFlowComment model)
    {
      return this.dataWorkFlowComment.Add(model);
    }

    public int Update(RoadFlow.Data.Model.WorkFlowComment model)
    {
      return this.dataWorkFlowComment.Update(model);
    }

    public List<RoadFlow.Data.Model.WorkFlowComment> GetAll()
    {
      return this.dataWorkFlowComment.GetAll();
    }

    public RoadFlow.Data.Model.WorkFlowComment Get(Guid id)
    {
      return this.dataWorkFlowComment.Get(id);
    }

    public int Delete(Guid id)
    {
      return this.dataWorkFlowComment.Delete(id);
    }

    public long GetCount()
    {
      return this.dataWorkFlowComment.GetCount();
    }

    public List<RoadFlow.Data.Model.WorkFlowComment> GetManagerAll()
    {
      return this.dataWorkFlowComment.GetManagerAll();
    }

    public int GetManagerMaxSort()
    {
      return this.dataWorkFlowComment.GetManagerMaxSort();
    }

    public int GetUserMaxSort(Guid userID)
    {
      return this.dataWorkFlowComment.GetUserMaxSort(userID);
    }

    private List<Tuple<Guid, string, int, int, List<Guid>>> GetAllList(bool fromCache = true)
    {
      string key = Keys.CacheKeys.WorkFlowComments.ToString();
      if (!fromCache)
        return this.getAllListByDb();
      object obj = Opation.Get(key);
      if (obj != null)
        return (List<Tuple<Guid, string, int, int, List<Guid>>>) obj;
      List<Tuple<Guid, string, int, int, List<Guid>>> allListByDb = this.getAllListByDb();
      Opation.Set(key, (object) allListByDb);
      return allListByDb;
    }

    private List<Tuple<Guid, string, int, int, List<Guid>>> getAllListByDb()
    {
      List<RoadFlow.Data.Model.WorkFlowComment> all = this.GetAll();
      Organize organize = new Organize();
      List<Tuple<Guid, string, int, int, List<Guid>>> tupleList = new List<Tuple<Guid, string, int, int, List<Guid>>>();
      foreach (RoadFlow.Data.Model.WorkFlowComment workFlowComment in all)
      {
        List<Guid> guidList = new List<Guid>();
        if (!workFlowComment.MemberID.IsNullOrEmpty())
        {
          foreach (RoadFlow.Data.Model.Users allUser in organize.GetAllUsers(workFlowComment.MemberID))
            guidList.Add(allUser.ID);
        }
        Tuple<Guid, string, int, int, List<Guid>> tuple = new Tuple<Guid, string, int, int, List<Guid>>(workFlowComment.ID, workFlowComment.Comment, workFlowComment.Type, workFlowComment.Sort, guidList);
        tupleList.Add(tuple);
      }
      return tupleList;
    }

    public void ClearCache()
    {
      Opation.Remove(Keys.CacheKeys.WorkFlowComments.ToString());
    }

    public void RefreshCache()
    {
      Opation.Set(Keys.CacheKeys.WorkFlowComments.ToString(), (object) this.getAllListByDb());
    }

    public List<string> GetListByUserID(Guid userID)
    {
      IOrderedEnumerable<Tuple<Guid, string, int, int, List<Guid>>> source = this.GetAllList(true).Where<Tuple<Guid, string, int, int, List<Guid>>>((Func<Tuple<Guid, string, int, int, List<Guid>>, bool>) (p =>
      {
        if (p.Item5.Count != 0)
          return p.Item5.Exists((Predicate<Guid>) (q => q == userID));
        return true;
      })).OrderByDescending<Tuple<Guid, string, int, int, List<Guid>>, int>((Func<Tuple<Guid, string, int, int, List<Guid>>, int>) (p => p.Item3)).ThenBy<Tuple<Guid, string, int, int, List<Guid>>, int>((Func<Tuple<Guid, string, int, int, List<Guid>>, int>) (p => p.Item4));
      List<string> stringList = new List<string>();
      foreach (Tuple<Guid, string, int, int, List<Guid>> tuple in (IEnumerable<Tuple<Guid, string, int, int, List<Guid>>>) source.OrderBy<Tuple<Guid, string, int, int, List<Guid>>, int>((Func<Tuple<Guid, string, int, int, List<Guid>>, int>) (p => p.Item3)).ThenBy<Tuple<Guid, string, int, int, List<Guid>>, int>((Func<Tuple<Guid, string, int, int, List<Guid>>, int>) (p => p.Item4)))
      {
        if (!stringList.Contains(tuple.Item2))
          stringList.Add(tuple.Item2);
      }
      return stringList;
    }

    public string GetOptionsStringByUserID(Guid userID)
    {
      List<string> listByUserId = this.GetListByUserID(userID);
      StringBuilder stringBuilder = new StringBuilder();
      foreach (string str in listByUserId)
        stringBuilder.AppendFormat("<option value=\"{0}\">{0}</option>", (object) str);
      return stringBuilder.ToString();
    }
  }
}
