using System;

namespace RoadFlow.Data.Model.WorkFlowInstalledSub
{
	public class Line
	{
		public Guid ID
		{
			get;
			set;
		}

		public Guid FromID
		{
			get;
			set;
		}

		public Guid ToID
		{
			get;
			set;
		}

		public string CustomMethod
		{
			get;
			set;
		}

		public string SqlWhere
		{
			get;
			set;
		}

		public string NoAccordMsg
		{
			get;
			set;
		}

		public string Organize
		{
			get;
			set;
		}
	}
}
