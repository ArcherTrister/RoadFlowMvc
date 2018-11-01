using System;

namespace RoadFlow.Data.Model.WorkFlowInstalledSub.StepSet
{
	[Serializable]
	public class Button
	{
		public string ID
		{
			get;
			set;
		}

		public string Note
		{
			get;
			set;
		}

		public int Sort
		{
			get;
			set;
		}

		public string ShowTitle
		{
			get;
			set;
		}
	}
}
