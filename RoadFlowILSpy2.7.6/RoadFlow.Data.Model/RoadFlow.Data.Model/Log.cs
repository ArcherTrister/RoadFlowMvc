using System;
using System.ComponentModel;

namespace RoadFlow.Data.Model
{
	[Serializable]
	public class Log
	{
		[DisplayName("ID")]
		public Guid ID
		{
			get;
			set;
		}

		[DisplayName("标题")]
		public string Title
		{
			get;
			set;
		}

		[DisplayName("类型")]
		public string Type
		{
			get;
			set;
		}

		[DisplayName("写入时间")]
		public DateTime WriteTime
		{
			get;
			set;
		}

		[DisplayName("用户ID")]
		public Guid? UserID
		{
			get;
			set;
		}

		[DisplayName("用户姓名")]
		public string UserName
		{
			get;
			set;
		}

		[DisplayName("IP")]
		public string IPAddress
		{
			get;
			set;
		}

		[DisplayName("发生URL")]
		public string URL
		{
			get;
			set;
		}

		[DisplayName("内容")]
		public string Contents
		{
			get;
			set;
		}

		[DisplayName("其它")]
		public string Others
		{
			get;
			set;
		}

		[DisplayName("更改前")]
		public string OldXml
		{
			get;
			set;
		}

		[DisplayName("更改后")]
		public string NewXml
		{
			get;
			set;
		}
	}
}
