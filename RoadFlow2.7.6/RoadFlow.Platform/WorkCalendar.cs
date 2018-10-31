// Decompiled with JetBrains decompiler
// Type: RoadFlow.Platform.WorkCalendar
// Assembly: RoadFlow.Platform, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 07F26AFD-DE3B-4003-89AF-01A62494BA58
// Assembly location: C:\inetpub\wwwroot\RoadFlowMvc\bin\RoadFlow.Platform.dll

using RoadFlow.Cache.IO;
using RoadFlow.Data.Interface;
using System;
using System.Collections.Generic;

namespace RoadFlow.Platform
{
  public class WorkCalendar
  {
    private IWorkCalendar dataWorkCalendar;

    public WorkCalendar()
    {
      this.dataWorkCalendar = RoadFlow.Data.Factory.Factory.GetWorkCalendar();
    }

    public int Add(RoadFlow.Data.Model.WorkCalendar model)
    {
      return this.dataWorkCalendar.Add(model);
    }

    public int Update(RoadFlow.Data.Model.WorkCalendar model)
    {
      return this.dataWorkCalendar.Update(model);
    }

    public List<RoadFlow.Data.Model.WorkCalendar> GetAll()
    {
      return this.dataWorkCalendar.GetAll();
    }

    public RoadFlow.Data.Model.WorkCalendar Get(DateTime workdate)
    {
      return this.dataWorkCalendar.Get(workdate);
    }

    public int Delete(DateTime workdate)
    {
      return this.dataWorkCalendar.Delete(workdate);
    }

    public long GetCount()
    {
      return this.dataWorkCalendar.GetCount();
    }

    public int Delete(int year)
    {
      return this.dataWorkCalendar.Delete(year);
    }

    public List<RoadFlow.Data.Model.WorkCalendar> GetAll(int year, bool cache = true)
    {
      string key = "WorkCalendar_" + year.ToString();
      if (!cache)
        return this.dataWorkCalendar.GetAll(year);
      object obj = Opation.Get(key);
      if (obj != null)
        return (List<RoadFlow.Data.Model.WorkCalendar>) obj;
      List<RoadFlow.Data.Model.WorkCalendar> all = this.dataWorkCalendar.GetAll(year);
      Opation.Set(key, (object) all);
      return all;
    }

    public DateTime GetWorkDate(double day, DateTime dt)
    {
      DateTime dateTime = dt.AddDays(day);
      List<RoadFlow.Data.Model.WorkCalendar> all = this.GetAll(dt.Year, true);
      if (dt.Year != dateTime.Year)
        all.AddRange((IEnumerable<RoadFlow.Data.Model.WorkCalendar>) this.GetAll(dateTime.Year, true));
      if (all == null || all.Count == 0)
        return dt.AddDays(day);
      DateTime dt2 = dt;
      for (int index = 0; (double) index <= day; ++index)
      {
        if (all.Find((Predicate<RoadFlow.Data.Model.WorkCalendar>) (p =>
        {
          if (p.WorkDate.Year == dt2.Year && p.WorkDate.Month == dt2.Month)
            return p.WorkDate.Day == dt2.Day;
          return false;
        })) == null)
          ++day;
        dt2 = dt2.AddDays(1.0);
      }
      return dt2.AddDays(day - (double) (int) Math.Floor(day) - 1.0);
    }
  }
}
