// Decompiled with JetBrains decompiler
// Type: RoadFlow.Data.Factory.Factory
// Assembly: RoadFlow.Data.Factory, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 9C0DAAC6-9FA4-46A8-901C-644AE3AA8AC2
// Assembly location: C:\inetpub\wwwroot\RoadFlowMvc\bin\RoadFlow.Data.Factory.dll

using RoadFlow.Data.Interface;
using RoadFlow.Data.MSSQL;

namespace RoadFlow.Data.Factory
{
  public class Factory
  {
    public static IDBHelper GetDBHelper()
    {
      return (IDBHelper) new DBHelper();
    }

    public static IAppLibrary GetAppLibrary()
    {
      return (IAppLibrary) new AppLibrary();
    }

    public static IDBConnection GetDBConnection()
    {
      return (IDBConnection) new DBConnection();
    }

    public static IDictionary GetDictionary()
    {
      return (IDictionary) new Dictionary();
    }

    public static ILog GetLog()
    {
      return (ILog) new Log();
    }

    public static IOrganize GetOrganize()
    {
      return (IOrganize) new Organize();
    }

    public static IUsers GetUsers()
    {
      return (IUsers) new Users();
    }

    public static IUsersRelation GetUsersRelation()
    {
      return (IUsersRelation) new UsersRelation();
    }

    public static IWorkFlow GetWorkFlow()
    {
      return (IWorkFlow) new WorkFlow();
    }

    public static IWorkFlowArchives GetWorkFlowArchives()
    {
      return (IWorkFlowArchives) new WorkFlowArchives();
    }

    public static IWorkFlowButtons GetWorkFlowButtons()
    {
      return (IWorkFlowButtons) new WorkFlowButtons();
    }

    public static IWorkFlowComment GetWorkFlowComment()
    {
      return (IWorkFlowComment) new WorkFlowComment();
    }

    public static IWorkFlowData GetWorkFlowData()
    {
      return (IWorkFlowData) new WorkFlowData();
    }

    public static IWorkFlowDelegation GetWorkFlowDelegation()
    {
      return (IWorkFlowDelegation) new WorkFlowDelegation();
    }

    public static IWorkFlowForm GetWorkFlowForm()
    {
      return (IWorkFlowForm) new WorkFlowForm();
    }

    public static IWorkFlowTask GetWorkFlowTask()
    {
      return (IWorkFlowTask) new WorkFlowTask();
    }

    public static IWorkGroup GetWorkGroup()
    {
      return (IWorkGroup) new WorkGroup();
    }

    public static IShortMessage GetShortMessage()
    {
      return (IShortMessage) new ShortMessage();
    }

    public static ISMSLog GetSMSLog()
    {
      return (ISMSLog) new SMSLog();
    }

    public static IHastenLog GetHastenLog()
    {
      return (IHastenLog) new HastenLog();
    }

    public static IProgramBuilder GetProgramBuilder()
    {
      return (IProgramBuilder) new ProgramBuilder();
    }

    public static IProgramBuilderFields GetProgramBuilderFields()
    {
      return (IProgramBuilderFields) new ProgramBuilderFields();
    }

    public static IProgramBuilderQuerys GetProgramBuilderQuerys()
    {
      return (IProgramBuilderQuerys) new ProgramBuilderQuerys();
    }

    public static IProgramBuilderButtons GetProgramBuilderButtons()
    {
      return (IProgramBuilderButtons) new ProgramBuilderButtons();
    }

    public static IProgramBuilderValidates GetProgramBuilderValidates()
    {
      return (IProgramBuilderValidates) new ProgramBuilderValidates();
    }

    public static IProgramBuilderExport GetProgramBuilderExport()
    {
      return (IProgramBuilderExport) new ProgramBuilderExport();
    }

    public static IDocumentDirectory GetDocumentDirectory()
    {
      return (IDocumentDirectory) new DocumentDirectory();
    }

    public static IDocuments GetDocuments()
    {
      return (IDocuments) new Documents();
    }

    public static IDocumentsReadUsers GetDocumentsReadUsers()
    {
      return (IDocumentsReadUsers) new DocumentsReadUsers();
    }

    public static IAppLibraryButtons GetAppLibraryButtons()
    {
      return (IAppLibraryButtons) new AppLibraryButtons();
    }

    public static IAppLibraryButtons1 GetAppLibraryButtons1()
    {
      return (IAppLibraryButtons1) new AppLibraryButtons1();
    }

    public static IAppLibrarySubPages GetAppLibrarySubPages()
    {
      return (IAppLibrarySubPages) new AppLibrarySubPages();
    }

    public static IMenu GetMenu()
    {
      return (IMenu) new Menu();
    }

    public static IMenuUser GetMenuUser()
    {
      return (IMenuUser) new MenuUser();
    }

    public static IWorkCalendar GetWorkCalendar()
    {
      return (IWorkCalendar) new WorkCalendar();
    }

    public static IHomeItems GetHomeItems()
    {
      return (IHomeItems) new HomeItems();
    }

    public static IUserShortcut GetUserShortcut()
    {
      return (IUserShortcut) new UserShortcut();
    }

    public static IWorkTime GetWorkTime()
    {
      return (IWorkTime) new WorkTime();
    }

    public static IWeiXinMessage GetWeiXinMessage()
    {
      return (IWeiXinMessage) new WeiXinMessage();
    }
  }
}
