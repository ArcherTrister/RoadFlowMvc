using System;

namespace RoadFlow.Data.Model.WorkFlowInstalledSub.StepSet
{
	[Serializable]
	public class FieldStatus
	{
		public string Field
		{
			get;
			set;
		}

		public int Status1
		{
			get;
			set;
		}

		public int Check
		{
			get;
			set;
		}
	}
}
