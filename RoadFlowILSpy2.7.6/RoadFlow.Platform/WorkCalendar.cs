using RoadFlow.Cache.IO;
using RoadFlow.Data.Factory;
using RoadFlow.Data.Interface;
using RoadFlow.Data.Model;
using System;
using System.Collections.Generic;

namespace RoadFlow.Platform
{
	public class WorkCalendar
	{
		private IWorkCalendar dataWorkCalendar;

		public WorkCalendar()
		{
			dataWorkCalendar = Factory.GetWorkCalendar();
		}

		public int Add(RoadFlow.Data.Model.WorkCalendar model)
		{
			return dataWorkCalendar.Add(model);
		}

		public int Update(RoadFlow.Data.Model.WorkCalendar model)
		{
			return dataWorkCalendar.Update(model);
		}

		public List<RoadFlow.Data.Model.WorkCalendar> GetAll()
		{
			return dataWorkCalendar.GetAll();
		}

		public RoadFlow.Data.Model.WorkCalendar Get(DateTime workdate)
		{
			return dataWorkCalendar.Get(workdate);
		}

		public int Delete(DateTime workdate)
		{
			return dataWorkCalendar.Delete(workdate);
		}

		public long GetCount()
		{
			return dataWorkCalendar.GetCount();
		}

		public int Delete(int year)
		{
			return dataWorkCalendar.Delete(year);
		}

		public List<RoadFlow.Data.Model.WorkCalendar> GetAll(int year, bool cache = true)
		{
			string key = "WorkCalendar_" + year.ToString();
			if (!cache)
			{
				return dataWorkCalendar.GetAll(year);
			}
			object obj = Opation.Get(key);
			if (obj == null)
			{
				List<RoadFlow.Data.Model.WorkCalendar> all = dataWorkCalendar.GetAll(year);
				Opation.Set(key, all);
				return all;
			}
			return (List<RoadFlow.Data.Model.WorkCalendar>)obj;
		}

		public DateTime GetWorkDate(double day, DateTime dt)
		{
			DateTime dateTime = dt.AddDays(day);
			List<RoadFlow.Data.Model.WorkCalendar> all = GetAll(dt.Year);
			if (dt.Year != dateTime.Year)
			{
				all.AddRange(GetAll(dateTime.Year));
			}
			if (all == null || all.Count == 0)
			{
				return dt.AddDays(day);
			}
			for (int i = 0; (double)i <= day; i++)
			{
				if (all.Find(delegate(RoadFlow.Data.Model.WorkCalendar p)
				{
					if (p.WorkDate.Year == dt.Year && p.WorkDate.Month == dt.Month)
					{
						return p.WorkDate.Day == dt.Day;
					}
					return false;
				}) == null)
				{
					day += 1.0;
				}
				dt = dt.AddDays(1.0);
			}
			return dt.AddDays(-1.0 + (day - (double)(int)Math.Floor(day)));
		}
	}
}
