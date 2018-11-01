using System;
using System.Collections.Generic;

namespace RoadFlow.Data.Model.WorkFlowExecute
{
	[Serializable]
	public class Execute
	{
		public Guid FlowID
		{
			get;
			set;
		}

		public Guid StepID
		{
			get;
			set;
		}

		public Guid TaskID
		{
			get;
			set;
		}

		public string InstanceID
		{
			get;
			set;
		}

		public Guid GroupID
		{
			get;
			set;
		}

		public string Title
		{
			get;
			set;
		}

		public EnumType.ExecuteType ExecuteType
		{
			get;
			set;
		}

		public Users Sender
		{
			get;
			set;
		}

		public Dictionary<Guid, List<Users>> Steps
		{
			get;
			set;
		}

		public Dictionary<Guid, DateTime> StepCompletedTimes
		{
			get;
			set;
		}

		public string Comment
		{
			get;
			set;
		}

		public bool IsSign
		{
			get;
			set;
		}

		public string Note
		{
			get;
			set;
		}

		public int OtherType
		{
			get;
			set;
		}

		public string Files
		{
			get;
			set;
		}

		public Execute()
		{
			Steps = new Dictionary<Guid, List<Users>>();
			StepCompletedTimes = new Dictionary<Guid, DateTime>();
			OtherType = 0;
		}
	}
}
