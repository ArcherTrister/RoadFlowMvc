using System;
using System.ComponentModel;

namespace RoadFlow.Data.Model
{
	[Serializable]
	public class WorkGroup
	{
		[DisplayName("ID")]
		public Guid ID
		{
			get;
			set;
		}

		[DisplayName("工作组名称")]
		public string Name
		{
			get;
			set;
		}

		[DisplayName("工作组成员")]
		public string Members
		{
			get;
			set;
		}

		[DisplayName("备注")]
		public string Note
		{
			get;
			set;
		}

		[DisplayName("数字ID，用于微信")]
		public int IntID
		{
			get;
			set;
		}
	}
}
