using System;
using System.ComponentModel;

namespace RoadFlow.Data.Model
{
	[Serializable]
	public class AppLibraryButtons1
	{
		[DisplayName("ID")]
		public Guid ID
		{
			get;
			set;
		}

		[DisplayName("AppLibraryID")]
		public Guid AppLibraryID
		{
			get;
			set;
		}

		[DisplayName("按钮库ID")]
		public Guid? ButtonID
		{
			get;
			set;
		}

		[DisplayName("名称")]
		public string Name
		{
			get;
			set;
		}

		[DisplayName("执行脚本")]
		public string Events
		{
			get;
			set;
		}

		[DisplayName("图标")]
		public string Ico
		{
			get;
			set;
		}

		[DisplayName("排序")]
		public int Sort
		{
			get;
			set;
		}

		[DisplayName("类型0属于主页面1属于子页面")]
		public int Type
		{
			get;
			set;
		}

		[DisplayName("显示类型 0工具栏按钮 1普通按钮 2列表按键")]
		public int ShowType
		{
			get;
			set;
		}

		[DisplayName("是否验证权限，要验证则要在权限中授权了才能显示")]
		public int IsValidateShow
		{
			get;
			set;
		}
	}
}
