using System;
using System.ComponentModel;

namespace RoadFlow.Data.Model
{
	[Serializable]
	public class HastenLog
	{
		[DisplayName("ID")]
		public Guid ID
		{
			get;
			set;
		}

		[DisplayName("其它参数")]
		public string OthersParams
		{
			get;
			set;
		}

		[DisplayName("被催办人员")]
		public string Users
		{
			get;
			set;
		}

		[DisplayName("催办方式")]
		public string Types
		{
			get;
			set;
		}

		[DisplayName("催办内容")]
		public string Contents
		{
			get;
			set;
		}

		[DisplayName("发送人员")]
		public Guid SendUser
		{
			get;
			set;
		}

		[DisplayName("发送人员姓名")]
		public string SendUserName
		{
			get;
			set;
		}

		[DisplayName("发送时间")]
		public DateTime SendTime
		{
			get;
			set;
		}
	}
}
