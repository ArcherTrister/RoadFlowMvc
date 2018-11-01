using System;
using System.ComponentModel;

namespace RoadFlow.Data.Model
{
	[Serializable]
	public class WorkFlowButtons
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

		[DisplayName("图标")]
		public string Ico
		{
			get;
			set;
		}

		[DisplayName("脚本")]
		public string Script
		{
			get;
			set;
		}

		[DisplayName("备注说明")]
		public string Note
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
	}
}
