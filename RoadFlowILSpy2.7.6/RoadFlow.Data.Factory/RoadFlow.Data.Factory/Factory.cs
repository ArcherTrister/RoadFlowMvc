using RoadFlow.Data.Interface;
using RoadFlow.Data.MSSQL;

namespace RoadFlow.Data.Factory
{
	public class Factory
	{
		public static IDBHelper GetDBHelper()
		{
			return new DBHelper();
		}

		public static IAppLibrary GetAppLibrary()
		{
			return new AppLibrary();
		}

		public static IDBConnection GetDBConnection()
		{
			return new DBConnection();
		}

		public static IDictionary GetDictionary()
		{
			return new Dictionary();
		}

		public static ILog GetLog()
		{
			return new Log();
		}

		public static IOrganize GetOrganize()
		{
			return new Organize();
		}

		public static IUsers GetUsers()
		{
			return new Users();
		}

		public static IUsersRelation GetUsersRelation()
		{
			return new UsersRelation();
		}

		public static IWorkFlow GetWorkFlow()
		{
			return new WorkFlow();
		}

		public static IWorkFlowArchives GetWorkFlowArchives()
		{
			return new WorkFlowArchives();
		}

		public static IWorkFlowButtons GetWorkFlowButtons()
		{
			return new WorkFlowButtons();
		}

		public static IWorkFlowComment GetWorkFlowComment()
		{
			return new WorkFlowComment();
		}

		public static IWorkFlowData GetWorkFlowData()
		{
			return new WorkFlowData();
		}

		public static IWorkFlowDelegation GetWorkFlowDelegation()
		{
			return new WorkFlowDelegation();
		}

		public static IWorkFlowForm GetWorkFlowForm()
		{
			return new WorkFlowForm();
		}

		public static IWorkFlowTask GetWorkFlowTask()
		{
			return new WorkFlowTask();
		}

		public static IWorkGroup GetWorkGroup()
		{
			return new WorkGroup();
		}

		public static IShortMessage GetShortMessage()
		{
			return new ShortMessage();
		}

		public static ISMSLog GetSMSLog()
		{
			return new SMSLog();
		}

		public static IHastenLog GetHastenLog()
		{
			return new HastenLog();
		}

		public static IProgramBuilder GetProgramBuilder()
		{
			return new ProgramBuilder();
		}

		public static IProgramBuilderFields GetProgramBuilderFields()
		{
			return new ProgramBuilderFields();
		}

		public static IProgramBuilderQuerys GetProgramBuilderQuerys()
		{
			return new ProgramBuilderQuerys();
		}

		public static IProgramBuilderButtons GetProgramBuilderButtons()
		{
			return new ProgramBuilderButtons();
		}

		public static IProgramBuilderValidates GetProgramBuilderValidates()
		{
			return new ProgramBuilderValidates();
		}

		public static IProgramBuilderExport GetProgramBuilderExport()
		{
			return new ProgramBuilderExport();
		}

		public static IDocumentDirectory GetDocumentDirectory()
		{
			return new DocumentDirectory();
		}

		public static IDocuments GetDocuments()
		{
			return new Documents();
		}

		public static IDocumentsReadUsers GetDocumentsReadUsers()
		{
			return new DocumentsReadUsers();
		}

		public static IAppLibraryButtons GetAppLibraryButtons()
		{
			return new AppLibraryButtons();
		}

		public static IAppLibraryButtons1 GetAppLibraryButtons1()
		{
			return new AppLibraryButtons1();
		}

		public static IAppLibrarySubPages GetAppLibrarySubPages()
		{
			return new AppLibrarySubPages();
		}

		public static IMenu GetMenu()
		{
			return new Menu();
		}

		public static IMenuUser GetMenuUser()
		{
			return new MenuUser();
		}

		public static IWorkCalendar GetWorkCalendar()
		{
			return new WorkCalendar();
		}

		public static IHomeItems GetHomeItems()
		{
			return new HomeItems();
		}

		public static IUserShortcut GetUserShortcut()
		{
			return new UserShortcut();
		}

		public static IWorkTime GetWorkTime()
		{
			return new WorkTime();
		}

		public static IWeiXinMessage GetWeiXinMessage()
		{
			return new WeiXinMessage();
		}
	}
}
