using System;
using System.Collections.Generic;

namespace RoadFlow.Data.Model
{
	[Serializable]
	public class ProgramBuilderCache
	{
		public ProgramBuilder Program
		{
			get;
			set;
		}

		public List<ProgramBuilderFields> Fields
		{
			get;
			set;
		}

		public List<ProgramBuilderQuerys> Querys
		{
			get;
			set;
		}

		public List<ProgramBuilderButtons> Buttons
		{
			get;
			set;
		}

		public List<ProgramBuilderValidates> Validates
		{
			get;
			set;
		}

		public List<ProgramBuilderExport> Export
		{
			get;
			set;
		}
	}
}
