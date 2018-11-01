using System;
using System.ComponentModel;

namespace RoadFlow.Data.Model
{
	[Serializable]
	public class WorkCalendar
	{
		[DisplayName("WorkDate")]
		public DateTime WorkDate
		{
			get;
			set;
		}
	}
}
