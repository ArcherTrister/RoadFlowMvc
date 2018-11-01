// Decompiled with JetBrains decompiler
// Type: RoadFlow.Platform.WorkTime
// Assembly: RoadFlow.Platform, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 07F26AFD-DE3B-4003-89AF-01A62494BA58
// Assembly location: C:\inetpub\wwwroot\RoadFlowMvc\bin\RoadFlow.Platform.dll

using RoadFlow.Cache.IO;
using RoadFlow.Data.Interface;
using RoadFlow.Utility;
using System;
using System.Collections.Generic;
using System.Web.UI.WebControls;

namespace RoadFlow.Platform
{
  public class WorkTime
  {
    private IWorkTime dataWorkTime;

    public WorkTime()
    {
      this.dataWorkTime = RoadFlow.Data.Factory.Factory.GetWorkTime();
    }

    public int Add(RoadFlow.Data.Model.WorkTime model)
    {
      return this.dataWorkTime.Add(model);
    }

    public int Update(RoadFlow.Data.Model.WorkTime model)
    {
      return this.dataWorkTime.Update(model);
    }

    public List<RoadFlow.Data.Model.WorkTime> GetAll()
    {
      return this.dataWorkTime.GetAll();
    }

    public RoadFlow.Data.Model.WorkTime Get(Guid id)
    {
      return this.dataWorkTime.Get(id);
    }

    public int Delete(Guid id)
    {
      return this.dataWorkTime.Delete(id);
    }

    public long GetCount()
    {
      return this.dataWorkTime.GetCount();
    }

    public List<int> GetAllYear()
    {
      return this.dataWorkTime.GetAllYear();
    }

    public ListItem[] GetAllYearOptionItems(int defaultYear = 0)
    {
      if (defaultYear == 0)
        defaultYear = DateTimeNew.Now.Year;
      List<int> allYear = this.GetAllYear();
      List<ListItem> listItemList = new List<ListItem>();
      foreach (int num in allYear)
        listItemList.Add(new ListItem(num.ToString(), num.ToString())
        {
          Selected = listItemList.Find((Predicate<ListItem>) (p => p.Selected)) == null && defaultYear == num
        });
      return listItemList.ToArray();
    }

    public List<RoadFlow.Data.Model.WorkTime> GetAll(int year)
    {
      return this.dataWorkTime.GetAll(year);
    }

    public ListItem[] GetNumberOptionsItems(int start, int end, int defaultValue)
    {
      List<ListItem> listItemList = new List<ListItem>();
      for (int index = start; index <= end; ++index)
        listItemList.Add(new ListItem(index.ToString(), index.ToString())
        {
          Selected = defaultValue == index
        });
      return listItemList.ToArray();
    }

    public List<RoadFlow.Data.Model.WorkTime> GetYearFromCache(int year)
    {
      string key = Keys.CacheKeys.WorkTime.ToString() + "_" + year.ToString();
      object obj = Opation.Get(key);
      if (obj != null && obj is List<RoadFlow.Data.Model.WorkTime>)
        return (List<RoadFlow.Data.Model.WorkTime>) obj;
      List<RoadFlow.Data.Model.WorkTime> all = this.GetAll(year);
      Opation.Set(key, (object) all);
      return all;
    }

    public void ClearYearCache(int year)
    {
      Opation.Remove(Keys.CacheKeys.WorkTime.ToString() + "_" + year.ToString());
    }

    public Tuple<DateTime, DateTime, DateTime, DateTime> GetWorkAmPmTime(DateTime date)
    {
      Tuple<DateTime, DateTime, DateTime, DateTime> tuple = (Tuple<DateTime, DateTime, DateTime, DateTime>) null;
      List<RoadFlow.Data.Model.WorkTime> yearFromCache = this.GetYearFromCache(date.Year);
      RoadFlow.Data.Model.WorkTime workTime1 = (RoadFlow.Data.Model.WorkTime) null;
      foreach (RoadFlow.Data.Model.WorkTime workTime2 in yearFromCache)
      {
        if (date >= workTime2.Date1 && date <= workTime2.Date2)
        {
          workTime1 = workTime2;
          break;
        }
      }
      if (workTime1 == null)
        return tuple;
      DateTime dateTime1 = (date.ToDateString() + " " + workTime1.AmTime1).ToDateTime();
      DateTime dateTime2 = (date.ToDateString() + " " + workTime1.AmTime2).ToDateTime();
      DateTime dateTime3 = (date.ToDateString() + " " + workTime1.PmTime1).ToDateTime();
      DateTime dateTime4 = (date.ToDateString() + " " + workTime1.PmTime2).ToDateTime();
      DateTime dateTime5 = dateTime2;
      DateTime dateTime6 = dateTime3;
      DateTime dateTime7 = dateTime4;
      return new Tuple<DateTime, DateTime, DateTime, DateTime>(dateTime1, dateTime5, dateTime6, dateTime7);
    }

    public double GetRestMinutes(DateTime date1, DateTime date2)
    {
      double num1 = 0.0;
      int days = (date2 - date1).Days;
      TimeSpan timeSpan;
      for (int index = 0; index < days; ++index)
      {
        Tuple<DateTime, DateTime, DateTime, DateTime> workAmPmTime = this.GetWorkAmPmTime(date1.AddDays((double) index));
        if (workAmPmTime == null)
        {
          num1 += 1440.0;
        }
        else
        {
          DateTime dateTime1 = workAmPmTime.Item1;
          DateTime dateTime2 = workAmPmTime.Item2;
          DateTime dateTime3 = workAmPmTime.Item3;
          DateTime dateTime4 = workAmPmTime.Item4;
          double num2 = num1;
          timeSpan = dateTime1 - dateTime1.Date;
          double totalMinutes1 = timeSpan.TotalMinutes;
          double num3 = num2 + totalMinutes1;
          timeSpan = (dateTime1.Date.ToDateString() + " 23:59:59").ToDateTime() - dateTime4;
          double totalMinutes2 = timeSpan.TotalMinutes;
          double num4 = num3 + totalMinutes2;
          timeSpan = dateTime3 - dateTime2;
          double totalMinutes3 = timeSpan.TotalMinutes;
          num1 = num4 + totalMinutes3;
        }
      }
      Tuple<DateTime, DateTime, DateTime, DateTime> workAmPmTime1 = this.GetWorkAmPmTime(date1);
      if (workAmPmTime1 != null && date1 < workAmPmTime1.Item1)
      {
        double num2 = num1;
        timeSpan = workAmPmTime1.Item1 - date1;
        double totalMinutes = timeSpan.TotalMinutes;
        num1 = num2 + totalMinutes;
      }
      Tuple<DateTime, DateTime, DateTime, DateTime> workAmPmTime2 = this.GetWorkAmPmTime(date2);
      if (workAmPmTime2 != null && date2 > workAmPmTime2.Item4)
      {
        double num2 = num1;
        timeSpan = workAmPmTime2.Item1.AddDays(1.0) - workAmPmTime2.Item4;
        double totalMinutes = timeSpan.TotalMinutes;
        num1 = num2 + totalMinutes;
      }
      return num1;
    }

    public DateTime GetWorkDateTime(DateTime date, int hour)
    {
      DateTime date2 = date.AddHours((double) hour);
      date2 = date2.AddMinutes(this.GetRestMinutes(date, date2));
      return date2;
    }
  }
}
