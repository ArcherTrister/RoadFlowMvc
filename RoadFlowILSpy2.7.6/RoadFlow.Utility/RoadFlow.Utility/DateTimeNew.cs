using System;

namespace RoadFlow.Utility
{
	public class DateTimeNew
	{
		public static DateTime Now
		{
			get
			{
				return DateTime.Now;
			}
		}

		public static string ShortDate
		{
			get
			{
				return Now.ToString(Config.DateFormat);
			}
		}

		public static string LongDate
		{
			get
			{
				return Now.ToString("yyyy年MM月dd日");
			}
		}

		public static string ShortDateTime
		{
			get
			{
				return Now.ToString(Config.DateTimeFormat);
			}
		}

		public static string ShortDateTimeS
		{
			get
			{
				return Now.ToString(Config.DateTimeFormatS);
			}
		}

		public static string LongDateTime
		{
			get
			{
				return Now.ToString("yyyy年MM月dd日 HH时mm分");
			}
		}

		public static string LongDateTimeS
		{
			get
			{
				return Now.ToString("yyyy年MM月dd日 HH时mm分ss秒");
			}
		}

		public static string LongTime
		{
			get
			{
				return Now.ToString("HH时mm分");
			}
		}

		public static string ShortTime
		{
			get
			{
				return Now.ToString("HH:mm");
			}
		}
	}
}
