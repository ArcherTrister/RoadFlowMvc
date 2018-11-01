using System;
using System.ComponentModel;

namespace RoadFlow.Data.Model
{
	[Serializable]
	public class AppLibrary
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

		[DisplayName("地址")]
		public string Address
		{
			get;
			set;
		}

		[DisplayName("分类ID")]
		public Guid Type
		{
			get;
			set;
		}

		[DisplayName("打开方式{0-默认,1-弹出模态窗口,2-弹出窗口,3-新窗口}")]
		public int OpenMode
		{
			get;
			set;
		}

		[DisplayName("弹出窗口宽度")]
		public int? Width
		{
			get;
			set;
		}

		[DisplayName("弹出窗口高度")]
		public int? Height
		{
			get;
			set;
		}

		[DisplayName("其它参数")]
		public string Params
		{
			get;
			set;
		}

		[DisplayName("管理人员")]
		public string Manager
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

		[DisplayName("唯一标识符，流程应用时为流程ID，表单应用时对应表单ID")]
		public string Code
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

		[DisplayName("图标颜色")]
		public string Color
		{
			get;
			set;
		}
	}
}
