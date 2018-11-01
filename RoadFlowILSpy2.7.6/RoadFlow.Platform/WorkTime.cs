using RoadFlow.Cache.IO;
using RoadFlow.Data.Factory;
using RoadFlow.Data.Interface;
using RoadFlow.Data.Model;
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
			dataWorkTime = Factory.GetWorkTime();
		}

		public int Add(RoadFlow.Data.Model.WorkTime model)
		{
			return dataWorkTime.Add(model);
		}

		public int Update(RoadFlow.Data.Model.WorkTime model)
		{
			return dataWorkTime.Update(model);
		}

		public List<RoadFlow.Data.Model.WorkTime> GetAll()
		{
			return dataWorkTime.GetAll();
		}

		public RoadFlow.Data.Model.WorkTime Get(Guid id)
		{
			return dataWorkTime.Get(id);
		}

		public int Delete(Guid id)
		{
			return dataWorkTime.Delete(id);
		}

		public long GetCount()
		{
			return dataWorkTime.GetCount();
		}

		public List<int> GetAllYear()
		{
			return dataWorkTime.GetAllYear();
		}

		public ListItem[] GetAllYearOptionItems(int defaultYear = 0)
		{
			if (defaultYear == 0)
			{
				defaultYear = DateTimeNew.Now.Year;
			}
			List<int> allYear = GetAllYear();
			List<ListItem> list = new List<ListItem>();
			foreach (int item in allYear)
			{
				ListItem listItem = new ListItem(item.ToString(), item.ToString());
				listItem.Selected = (list.Find((ListItem p) => p.Selected) == null && defaultYear == item);
				list.Add(listItem);
			}
			return list.ToArray();
		}

		public List<RoadFlow.Data.Model.WorkTime> GetAll(int year)
		{
			return dataWorkTime.GetAll(year);
		}

		public ListItem[] GetNumberOptionsItems(int start, int end, int defaultValue)
		{
			List<ListItem> list = new List<ListItem>();
			for (int i = start; i <= end; i++)
			{
				ListItem listItem = new ListItem(i.ToString(), i.ToString());
				listItem.Selected = (defaultValue == i);
				list.Add(listItem);
			}
			return list.ToArray();
		}

		public List<RoadFlow.Data.Model.WorkTime> GetYearFromCache(int year)
		{
			string key = 23.ToString() + "_" + year.ToString();
			object obj = Opation.Get(key);
			if (obj != null && obj is List<RoadFlow.Data.Model.WorkTime>)
			{
				return (List<RoadFlow.Data.Model.WorkTime>)obj;
			}
			List<RoadFlow.Data.Model.WorkTime> all = GetAll(year);
			Opation.Set(key, all);
			return all;
		}

		public void ClearYearCache(int year)
		{
			Opation.Remove(23.ToString() + "_" + year.ToString());
		}

		public Tuple<DateTime, DateTime, DateTime, DateTime> GetWorkAmPmTime(DateTime date)
		{
			Tuple<DateTime, DateTime, DateTime, DateTime> result = null;
			List<RoadFlow.Data.Model.WorkTime> yearFromCache = GetYearFromCache(date.Year);
			RoadFlow.Data.Model.WorkTime workTime = null;
			foreach (RoadFlow.Data.Model.WorkTime item5 in yearFromCache)
			{
				if (date >= item5.Date1 && date <= item5.Date2)
				{
					workTime = item5;
					break;
				}
			}
			if (workTime == null)
			{
				return result;
			}
			DateTime item = (date.ToDateString() + " " + workTime.AmTime1).ToDateTime();
			DateTime item2 = (date.ToDateString() + " " + workTime.AmTime2).ToDateTime();
			DateTime item3 = (date.ToDateString() + " " + workTime.PmTime1).ToDateTime();
			DateTime item4 = (date.ToDateString() + " " + workTime.PmTime2).ToDateTime();
			return new Tuple<DateTime, DateTime, DateTime, DateTime>(item, item2, item3, item4);
		}

		public double GetRestMinutes(DateTime date1, DateTime date2)
		{
			double num = 0.0;
			int days = (date2 - date1).Days;
			for (int i = 0; i < days; i++)
			{
				Tuple<DateTime, DateTime, DateTime, DateTime> workAmPmTime = GetWorkAmPmTime(date1.AddDays((double)i));
				if (workAmPmTime == null)
				{
					num += 1440.0;
				}
				else
				{
					DateTime item = workAmPmTime.Item1;
					DateTime item2 = workAmPmTime.Item2;
					DateTime item3 = workAmPmTime.Item3;
					DateTime item4 = workAmPmTime.Item4;
					num += (item - item.Date).TotalMinutes;
					num += ((item.Date.ToDateString() + " 23:59:59").ToDateTime() - item4).TotalMinutes;
					num += (item3 - item2).TotalMinutes;
				}
			}
			Tuple<DateTime, DateTime, DateTime, DateTime> workAmPmTime2 = GetWorkAmPmTime(date1);
			if (workAmPmTime2 != null && date1 < workAmPmTime2.Item1)
			{
				num += (workAmPmTime2.Item1 - date1).TotalMinutes;
			}
			Tuple<DateTime, DateTime, DateTime, DateTime> workAmPmTime3 = GetWorkAmPmTime(date2);
			if (workAmPmTime3 != null && date2 > workAmPmTime3.Item4)
			{
				num += (workAmPmTime3.Item1.AddDays(1.0) - workAmPmTime3.Item4).TotalMinutes;
			}
			return num;
		}

		public DateTime GetWorkDateTime(DateTime date, int hour)
		{
			DateTime date2 = date.AddHours((double)hour);
			return date2.AddMinutes(GetRestMinutes(date, date2));
		}
	}
}
