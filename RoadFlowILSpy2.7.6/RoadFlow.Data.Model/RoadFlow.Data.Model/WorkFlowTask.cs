using System;
using System.ComponentModel;

namespace RoadFlow.Data.Model
{
	[Serializable]
	public class WorkFlowTask
	{
		[DisplayName("ID")]
		public Guid ID
		{
			get;
			set;
		}

		[DisplayName("上一任务ID")]
		public Guid PrevID
		{
			get;
			set;
		}

		[DisplayName("上一步骤ID")]
		public Guid PrevStepID
		{
			get;
			set;
		}

		[DisplayName("流程ID")]
		public Guid FlowID
		{
			get;
			set;
		}

		[DisplayName("步骤ID")]
		public Guid StepID
		{
			get;
			set;
		}

		[DisplayName("步骤名称")]
		public string StepName
		{
			get;
			set;
		}

		[DisplayName("实例ID")]
		public string InstanceID
		{
			get;
			set;
		}

		[DisplayName("分组ID")]
		public Guid GroupID
		{
			get;
			set;
		}

		[DisplayName("任务类型 0正常 1指派 2委托 3转交 4退回 5抄送 6子流程 7加签")]
		public int Type
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

		[DisplayName("发送人")]
		public Guid SenderID
		{
			get;
			set;
		}

		[DisplayName("发送人姓名")]
		public string SenderName
		{
			get;
			set;
		}

		[DisplayName("发送时间")]
		public DateTime SenderTime
		{
			get;
			set;
		}

		[DisplayName("接收人员ID")]
		public Guid ReceiveID
		{
			get;
			set;
		}

		[DisplayName("接收人员姓名")]
		public string ReceiveName
		{
			get;
			set;
		}

		[DisplayName("接收时间")]
		public DateTime ReceiveTime
		{
			get;
			set;
		}

		[DisplayName("打开时间")]
		public DateTime? OpenTime
		{
			get;
			set;
		}

		[DisplayName("规定完成时间")]
		public DateTime? CompletedTime
		{
			get;
			set;
		}

		[DisplayName("实际完成时间")]
		public DateTime? CompletedTime1
		{
			get;
			set;
		}

		[DisplayName("意见")]
		public string Comment
		{
			get;
			set;
		}

		[DisplayName("是否签章 0未签 1已签")]
		public int? IsSign
		{
			get;
			set;
		}

		[DisplayName("状态 0 待处理 1打开 2完成 3退回 4他人已处理 5他人已退回 6终止 7他人已终止")]
		public int Status
		{
			get;
			set;
		}

		[DisplayName("其它说明")]
		public string Note
		{
			get;
			set;
		}

		[DisplayName("序号")]
		public int Sort
		{
			get;
			set;
		}

		[DisplayName("子流程实例分组ID")]
		public string SubFlowGroupID
		{
			get;
			set;
		}

		[DisplayName("其他类型 1.自由流程任务 2.子流程任务-完成后提交 3.子流程任务-发起即可提交 4.子流程任务的子流程实例任务")]
		public int? OtherType
		{
			get;
			set;
		}

		[DisplayName("相关附件")]
		public string Files
		{
			get;
			set;
		}

		[DisplayName("超时了是否自动提交")]
		public int IsExpiredAutoSubmit
		{
			get;
			set;
		}

		public int StepSort
		{
			get;
			set;
		}
	}
}
