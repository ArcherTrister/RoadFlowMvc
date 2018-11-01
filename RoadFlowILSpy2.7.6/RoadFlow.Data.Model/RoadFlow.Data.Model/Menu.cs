using System;
using System.ComponentModel;

namespace RoadFlow.Data.Model
{
	[Serializable]
	public class Menu
	{
		[DisplayName("ID")]
		public Guid ID
		{
			get;
			set;
		}

		[DisplayName("ParentID")]
		public Guid ParentID
		{
			get;
			set;
		}

		[DisplayName("AppLibraryID")]
		public Guid? AppLibraryID
		{
			get;
			set;
		}

		[DisplayName("Title")]
		public string Title
		{
			get;
			set;
		}

		[DisplayName("Params")]
		public string Params
		{
			get;
			set;
		}

		[DisplayName("Ico")]
		public string Ico
		{
			get;
			set;
		}

		[DisplayName("Sort")]
		public int Sort
		{
			get;
			set;
		}

		[DisplayName("IcoColor")]
		public string IcoColor
		{
			get;
			set;
		}
	}
}
