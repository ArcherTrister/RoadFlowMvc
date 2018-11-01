using System;
using System.ComponentModel;

namespace RoadFlow.Data.Model
{
	[Serializable]
	public class MenuUser
	{
		[DisplayName("ID")]
		public Guid ID
		{
			get;
			set;
		}

		[DisplayName("菜单ID")]
		public Guid MenuID
		{
			get;
			set;
		}

		[DisplayName("可使用的子页面")]
		public Guid SubPageID
		{
			get;
			set;
		}

		[DisplayName("使用对象（组织机构ID）")]
		public string Organizes
		{
			get;
			set;
		}

		[DisplayName("Users")]
		public string Users
		{
			get;
			set;
		}

		[DisplayName("可使用的按钮")]
		public string Buttons
		{
			get;
			set;
		}

		[DisplayName("参数")]
		public string Params
		{
			get;
			set;
		}
	}
}
