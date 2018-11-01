using System;
using System.ComponentModel;

namespace RoadFlow.Data.Model
{
	[Serializable]
	public class UserShortcut
	{
		[DisplayName("ID")]
		public Guid ID
		{
			get;
			set;
		}

		[DisplayName("MenuID")]
		public Guid MenuID
		{
			get;
			set;
		}

		[DisplayName("UserID")]
		public Guid UserID
		{
			get;
			set;
		}

		[DisplayName("Sort")]
		public int Sort
		{
			get;
			set;
		}
	}
}
