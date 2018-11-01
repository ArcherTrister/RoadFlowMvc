using System;

namespace RoadFlow.Data.Model.WorkFlowInstalledSub
{
	[Serializable]
	public class DataBases
	{
		public Guid LinkID
		{
			get;
			set;
		}

		public string LinkName
		{
			get;
			set;
		}

		public string Table
		{
			get;
			set;
		}

		public string PrimaryKey
		{
			get;
			set;
		}
	}
}
