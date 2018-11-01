using System;

namespace RoadFlow.Data.Model.WorkFlowInstalledSub.StepSet
{
	[Serializable]
	public class Event
	{
		public string SubmitBefore
		{
			get;
			set;
		}

		public string SubmitAfter
		{
			get;
			set;
		}

		public string BackBefore
		{
			get;
			set;
		}

		public string BackAfter
		{
			get;
			set;
		}

		public string SubFlowActivationBefore
		{
			get;
			set;
		}

		public string SubFlowCompletedBefore
		{
			get;
			set;
		}
	}
}
