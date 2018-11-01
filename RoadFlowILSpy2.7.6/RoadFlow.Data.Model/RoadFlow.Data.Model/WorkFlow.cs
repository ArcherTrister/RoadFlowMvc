using System;
using System.ComponentModel;

namespace RoadFlow.Data.Model
{
	[Serializable]
	public class WorkFlow
	{
		[DisplayName("ID")]
		public Guid ID
		{
			get;
			set;
		}

		[DisplayName("流程名称")]
		public string Name
		{
			get;
			set;
		}

		[DisplayName("流程分类")]
		public Guid Type
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

		[DisplayName("实例管理人员")]
		public string InstanceManager
		{
			get;
			set;
		}

		[DisplayName("创建日期")]
		public DateTime CreateDate
		{
			get;
			set;
		}

		[DisplayName("创建人")]
		public Guid CreateUserID
		{
			get;
			set;
		}

		[DisplayName("设计时")]
		public string DesignJSON
		{
			get;
			set;
		}

		[DisplayName("安装日期")]
		public DateTime? InstallDate
		{
			get;
			set;
		}

		[DisplayName("安装人员")]
		public Guid? InstallUserID
		{
			get;
			set;
		}

		[DisplayName("运行时")]
		public string RunJSON
		{
			get;
			set;
		}

		[DisplayName("状态 1:设计中 2:已安装 3:已卸载 4:已删除")]
		public int Status
		{
			get;
			set;
		}
	}
}
