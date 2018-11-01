using System;

namespace RoadFlow.Data.Model
{
	[Serializable]
	public class WorkFlowStart
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

		public string StartUsers
		{
			get;
			set;
		}

		public string Type
		{
			get;
			set;
		}

		public string InstallDate
		{
			get;
			set;
		}

		public string InstallUserName
		{
			get;
			set;
		}

		public int OpenMode
		{
			get;
			set;
		}

		public int WindowWidth
		{
			get;
			set;
		}

		public int WindowHeight
		{
			get;
			set;
		}

		public string Params
		{
			get;
			set;
		}
	}
}
