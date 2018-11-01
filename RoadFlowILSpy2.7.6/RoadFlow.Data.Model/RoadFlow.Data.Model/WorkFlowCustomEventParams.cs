using System;

namespace RoadFlow.Data.Model
{
	[Serializable]
	public struct WorkFlowCustomEventParams
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

		public Guid GroupID
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

		public object Other
		{
			get;
			set;
		}
	}
}
