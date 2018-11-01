using System;
using System.ComponentModel;

namespace RoadFlow.Data.Model
{
	[Serializable]
	public class WorkFlowData
	{
		[DisplayName("ID")]
		public Guid ID
		{
			get;
			set;
		}

		[DisplayName("InstanceID")]
		public Guid InstanceID
		{
			get;
			set;
		}

		[DisplayName("连接ID")]
		public Guid LinkID
		{
			get;
			set;
		}

		[DisplayName("表名")]
		public string TableName
		{
			get;
			set;
		}

		[DisplayName("字段名")]
		public string FieldName
		{
			get;
			set;
		}

		[DisplayName("主键值")]
		public string Value
		{
			get;
			set;
		}
	}
}
