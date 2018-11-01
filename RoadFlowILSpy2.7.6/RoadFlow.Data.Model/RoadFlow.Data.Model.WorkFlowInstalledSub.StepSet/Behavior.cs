using System;

namespace RoadFlow.Data.Model.WorkFlowInstalledSub.StepSet
{
	[Serializable]
	public class Behavior
	{
		public int FlowType
		{
			get;
			set;
		}

		public int RunSelect
		{
			get;
			set;
		}

		public int HandlerType
		{
			get;
			set;
		}

		public string SelectRange
		{
			get;
			set;
		}

		public Guid HandlerStepID
		{
			get;
			set;
		}

		public string ValueField
		{
			get;
			set;
		}

		public string DefaultHandler
		{
			get;
			set;
		}

		public int BackModel
		{
			get;
			set;
		}

		public int HanlderModel
		{
			get;
			set;
		}

		public int BackType
		{
			get;
			set;
		}

		public decimal Percentage
		{
			get;
			set;
		}

		public Guid BackStepID
		{
			get;
			set;
		}

		public int Countersignature
		{
			get;
			set;
		}

		public decimal CountersignaturePercentage
		{
			get;
			set;
		}

		public int SubFlowStrategy
		{
			get;
			set;
		}

		public string CopyFor
		{
			get;
			set;
		}

		public int ConcurrentModel
		{
			get;
			set;
		}

		public string DefaultHandlerSqlOrMethod
		{
			get;
			set;
		}
	}
}
