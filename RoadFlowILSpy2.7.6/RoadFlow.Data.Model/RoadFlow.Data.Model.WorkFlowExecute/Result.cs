using System;
using System.Collections.Generic;

namespace RoadFlow.Data.Model.WorkFlowExecute
{
	[Serializable]
	public class Result
	{
		public bool IsSuccess
		{
			get;
			set;
		}

		public string Messages
		{
			get;
			set;
		}

		public string DebugMessages
		{
			get;
			set;
		}

		public object[] Other
		{
			get;
			set;
		}

		public IEnumerable<WorkFlowTask> NextTasks
		{
			get;
			set;
		}
	}
}
