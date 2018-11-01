using System;
using System.ComponentModel;

namespace RoadFlow.Data.Model
{
	[Serializable]
	public class AppLibraryButtons
	{
		[DisplayName("ID")]
		public Guid ID
		{
			get;
			set;
		}

		[DisplayName("按钮名称")]
		public string Name
		{
			get;
			set;
		}

		[DisplayName("按钮事件")]
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

		[DisplayName("显示顺序")]
		public int Sort
		{
			get;
			set;
		}

		[DisplayName("说明")]
		public string Note
		{
			get;
			set;
		}
	}
}
