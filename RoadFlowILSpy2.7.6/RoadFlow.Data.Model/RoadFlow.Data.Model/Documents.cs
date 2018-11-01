using System;
using System.ComponentModel;

namespace RoadFlow.Data.Model
{
	[Serializable]
	public class Documents
	{
		[DisplayName("ID")]
		public Guid ID
		{
			get;
			set;
		}

		[DisplayName("DirectoryID")]
		public Guid DirectoryID
		{
			get;
			set;
		}

		[DisplayName("DirectoryName")]
		public string DirectoryName
		{
			get;
			set;
		}

		[DisplayName("Title")]
		public string Title
		{
			get;
			set;
		}

		[DisplayName("来源")]
		public string Source
		{
			get;
			set;
		}

		[DisplayName("Contents")]
		public string Contents
		{
			get;
			set;
		}

		[DisplayName("相关附件")]
		public string Files
		{
			get;
			set;
		}

		[DisplayName("WriteTime")]
		public DateTime WriteTime
		{
			get;
			set;
		}

		[DisplayName("WriteUserID")]
		public Guid WriteUserID
		{
			get;
			set;
		}

		[DisplayName("WriteUserName")]
		public string WriteUserName
		{
			get;
			set;
		}

		[DisplayName("最后修改时间")]
		public DateTime? EditTime
		{
			get;
			set;
		}

		[DisplayName("修改用户ID")]
		public Guid? EditUserID
		{
			get;
			set;
		}

		[DisplayName("修改人姓名")]
		public string EditUserName
		{
			get;
			set;
		}

		[DisplayName("阅读人员")]
		public string ReadUsers
		{
			get;
			set;
		}

		[DisplayName("阅读次数")]
		public int ReadCount
		{
			get;
			set;
		}
	}
}
