using RoadFlow.Data.Model;
using System;
using System.Collections.Generic;
using System.Data;

namespace RoadFlow.Data.Interface
{
	public interface IWorkFlowTask
	{
		int Add(WorkFlowTask model);

		int Update(WorkFlowTask model);

		List<WorkFlowTask> GetAll();

		WorkFlowTask Get(Guid id);

		int Delete(Guid id);

		int Delete(Guid flowID, Guid groupID);

		long GetCount();

		List<WorkFlowTask> GetTasks(Guid userID, out string pager, string query = "", string title = "", string flowid = "", string sender = "", string date1 = "", string date2 = "", int type = 0);

		List<WorkFlowTask> GetTasks(Guid userID, out long count, int size, int number, string title = "", string flowid = "", string sender = "", string date1 = "", string date2 = "", int type = 0, string order = "");

		List<WorkFlowTask> GetInstances(Guid[] flowID, Guid[] senderID, Guid[] receiveID, out string pager, string query = "", string title = "", string flowid = "", string date1 = "", string date2 = "", int status = 0);

		DataTable GetInstances1(Guid[] flowID, Guid[] senderID, Guid[] receiveID, out string pager, string query = "", string title = "", string flowid = "", string date1 = "", string date2 = "", int status = 0);

		DataTable GetInstances1(Guid[] flowID, Guid[] senderID, Guid[] receiveID, out long count, int size, int number, string title = "", string flowid = "", string date1 = "", string date2 = "", int status = 0, string order = "");

		void UpdateOpenTime(Guid id, DateTime openTime, bool isStatus = false);

		Guid GetFirstSnderID(Guid flowID, Guid groupID);

		List<Guid> GetStepSnderID(Guid flowID, Guid stepID, Guid groupID);

		List<Guid> GetPrevSnderID(Guid flowID, Guid stepID, Guid groupID);

		int Completed(Guid taskID, string comment = "", bool isSign = false, int status = 2, string note = "", string files = "");

		List<WorkFlowTask> GetTaskList(Guid flowID, Guid stepID, Guid groupID);

		List<WorkFlowTask> GetTaskList(Guid flowID, Guid groupID);

		List<WorkFlowTask> GetTaskList(Guid taskID, bool isStepID = true);

		List<WorkFlowTask> GetPrevTaskList(Guid taskID);

		List<WorkFlowTask> GetNextTaskList(Guid taskID);

		List<WorkFlowTask> GetUserTaskList(Guid flowID, Guid stepID, Guid groupID, Guid userID);

		int UpdateNextTaskStatus(Guid taskID, int status);

		bool HasTasks(Guid flowID);

		bool HasNoCompletedTasks(Guid flowID, Guid stepID, Guid groupID, Guid userID);

		int UpdateTempTasks(Guid flowID, Guid stepID, Guid groupID, DateTime? completedTime, DateTime receiveTime);

		int DeleteTempTasks(Guid flowID, Guid stepID, Guid groupID, Guid prevStepID);

		int GetTaskStatus(Guid taskID);

		List<WorkFlowTask> GetBySubFlowGroupID(Guid subflowGroupID);

		WorkFlowTask GetLastTask(Guid flowID, Guid groupID);

		List<WorkFlowTask> GetExpiredAutoSubmitTasks();
	}
}
