using System;
using System.ComponentModel;

namespace RoadFlow.Data.Model
{
	[Serializable]
	public class ProgramBuilderQuerys
	{
		[DisplayName("ID")]
		public Guid ID
		{
			get;
			set;
		}

		[DisplayName("ProgramID")]
		public Guid ProgramID
		{
			get;
			set;
		}

		[DisplayName("字段")]
		public string Field
		{
			get;
			set;
		}

		[DisplayName("显示名称")]
		public string ShowTitle
		{
			get;
			set;
		}

		[DisplayName("操作符")]
		public string Operators
		{
			get;
			set;
		}

		[DisplayName("控件名称")]
		public string ControlName
		{
			get;
			set;
		}

		[DisplayName("输入类型 1文本 2日期 3日期范围 4日期时间 5日期时间范围 6下拉选择 7组织机构 8数据字典")]
		public int InputType
		{
			get;
			set;
		}

		[DisplayName("宽度")]
		public string Width
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

		[DisplayName("数据来源 1.字符串表达式 2.数据字典 3.SQL")]
		public int? DataSource
		{
			get;
			set;
		}

		[DisplayName("DataSourceString")]
		public string DataSourceString
		{
			get;
			set;
		}

		[DisplayName("数据连接ID")]
		public string DataLinkID
		{
			get;
			set;
		}

		[DisplayName("组织机构查询时是否将选择转换为人员")]
		public int? IsQueryUsers
		{
			get;
			set;
		}

		[DisplayName("查询时的值")]
		public string Value
		{
			get;
			set;
		}
	}
}
