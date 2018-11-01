using System;

namespace RoadFlow.Data.Model.WorkFlowInstalledSub.StepSet
{
	[Serializable]
	public class Form
	{
		public Guid ID
		{
			get;
			set;
		}

		public string Name
		{
			get;
			set;
		}

		public Guid IDApp
		{
			get;
			set;
		}

		public string NameApp
		{
			get;
			set;
		}

		public int Sort
		{
			get;
			set;
		}
	}
}
