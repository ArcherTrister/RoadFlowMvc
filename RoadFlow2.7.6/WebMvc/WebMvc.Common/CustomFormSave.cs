using RoadFlow.Data.Model;
using RoadFlow.Data.Model.WorkFlowExecute;
using RoadFlow.Data.MSSQL;
using RoadFlow.Platform;
using System.Web;

namespace WebMvc.Common
{
	public class CustomFormSave
	{
		public static object GetJson(WorkFlowCustomEventParams eventParams)
		{
			return new DBHelper().GetDataTable("select * from users");
		}

		public static string QianShi(WorkFlowCustomEventParams eventParams)
		{
			string str = HttpContext.Current.Request["TempTest.Title"];
			RoadFlow.Platform.Log.Add("获取值测试", str + "--");
			return "";
		}

		public static string GetMembers(WorkFlowCustomEventParams eventParams)
		{
			return "u_EB03262C-AB60-4BC6-A4C0-96E66A4229FE,u_8086D01F-7AE3-402E-B543-D34F1059F79A";
		}

		public static Execute SubFlowActivationBefore(WorkFlowCustomEventParams eventParams)
		{
			Execute result = new Execute();
			RoadFlow.Platform.Log.Add("执行了子流程激活前事件", "");
			return result;
		}

		public static void SubFlowCompletedBefore(WorkFlowCustomEventParams eventParams)
		{
			RoadFlow.Platform.Log.Add("执行了子流程结束后事件", "");
		}
	}
}
