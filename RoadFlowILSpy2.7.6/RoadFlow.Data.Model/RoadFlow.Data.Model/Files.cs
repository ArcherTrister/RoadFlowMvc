using System;

namespace RoadFlow.Data.Model
{
	public class Files
	{
		public string Name
		{
			get;
			set;
		}

		public string FullName
		{
			get;
			set;
		}

		public int Type
		{
			get;
			set;
		}

		public DateTime CreateTime
		{
			get;
			set;
		}

		public DateTime ModifyTime
		{
			get;
			set;
		}

		public decimal? Length
		{
			get;
			set;
		}

		public int? FileLength
		{
			get;
			set;
		}
	}
}
