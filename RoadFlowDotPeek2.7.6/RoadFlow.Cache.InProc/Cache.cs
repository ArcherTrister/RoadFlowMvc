// Decompiled with JetBrains decompiler
// Type: RoadFlow.Cache.InProc.Cache
// Assembly: RoadFlow.Cache.InProc, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 31A026C2-246E-448C-98B9-B90B3BB0E269
// Assembly location: C:\inetpub\wwwroot\RoadFlowMvc\bin\RoadFlow.Cache.InProc.dll

using RoadFlow.Cache.Interface;
using System;
using System.Web;
using System.Web.Caching;

namespace RoadFlow.Cache.InProc
{
  public class Cache : ICache
  {
    private static readonly object lockobj = new object();
    private static System.Web.Caching.Cache _cache;

    private static System.Web.Caching.Cache cache
    {
      get
      {
        if (RoadFlow.Cache.InProc.Cache._cache != null)
          return RoadFlow.Cache.InProc.Cache._cache;
        if (HttpContext.Current == null)
          return (System.Web.Caching.Cache) null;
        RoadFlow.Cache.InProc.Cache._cache = HttpContext.Current.Cache;
        return RoadFlow.Cache.InProc.Cache._cache;
      }
    }

    public bool Insert(string key, object obj)
    {
      if (obj == null || RoadFlow.Cache.InProc.Cache.cache == null)
        return false;
      lock (RoadFlow.Cache.InProc.Cache.lockobj)
        RoadFlow.Cache.InProc.Cache.cache.Insert(key, obj, (CacheDependency) null, System.Web.Caching.Cache.NoAbsoluteExpiration, System.Web.Caching.Cache.NoSlidingExpiration);
      return true;
    }

    public bool Insert(string key, object obj, DateTime expiry)
    {
      if (obj == null || RoadFlow.Cache.InProc.Cache.cache == null)
        return false;
      lock (RoadFlow.Cache.InProc.Cache.lockobj)
        RoadFlow.Cache.InProc.Cache.cache.Insert(key, obj, (CacheDependency) null, expiry, System.Web.Caching.Cache.NoSlidingExpiration, CacheItemPriority.Normal, (CacheItemRemovedCallback) null);
      return true;
    }

    public object Get(string key)
    {
      if (RoadFlow.Cache.InProc.Cache.cache == null)
        return (object) null;
      return RoadFlow.Cache.InProc.Cache.cache.Get(key);
    }

    public bool Remove(string key)
    {
      if (RoadFlow.Cache.InProc.Cache.cache == null)
        return false;
      lock (RoadFlow.Cache.InProc.Cache.lockobj)
        RoadFlow.Cache.InProc.Cache.cache.Remove(key);
      return true;
    }

    public void RemoveAll()
    {
      int num = 0;
      while (num < RoadFlow.Cache.InProc.Cache.cache.Count)
        ++num;
    }
  }
}
