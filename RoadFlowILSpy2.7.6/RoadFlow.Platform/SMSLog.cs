using RoadFlow.Data.Factory;
using RoadFlow.Data.Interface;
using RoadFlow.Data.Model;
using RoadFlow.Utility;
using System;
using System.Collections.Generic;

namespace RoadFlow.Platform
{
	public class SMSLog
	{
		private delegate void dgWriteLog(RoadFlow.Data.Model.SMSLog smsLog);

		private static ISMSLog dataSMSLog = Factory.GetSMSLog();

		public int Add(RoadFlow.Data.Model.SMSLog model)
		{
			return dataSMSLog.Add(model);
		}

		public int Update(RoadFlow.Data.Model.SMSLog model)
		{
			return dataSMSLog.Update(model);
		}

		public List<RoadFlow.Data.Model.SMSLog> GetAll()
		{
			return dataSMSLog.GetAll();
		}

		public RoadFlow.Data.Model.SMSLog Get(Guid id)
		{
			return dataSMSLog.Get(id);
		}

		public int Delete(Guid id)
		{
			return dataSMSLog.Delete(id);
		}

		public long GetCount()
		{
			return dataSMSLog.GetCount();
		}

		private static void add(RoadFlow.Data.Model.SMSLog model)
		{
			dataSMSLog.Add(model);
		}

		public static void AddSync(RoadFlow.Data.Model.SMSLog model)
		{
			new dgWriteLog(add).BeginInvoke(model, null, null);
		}

		public static void AddSync(string mobileNumber, string contents, int status, Guid sendUserID, string sendUserName = "", string note = "")
		{
			AddSync(new RoadFlow.Data.Model.SMSLog
			{
				Contents = contents,
				ID = Guid.NewGuid(),
				MobileNumber = mobileNumber,
				SendTime = DateTimeNew.Now,
				SendUserID = (sendUserID.IsEmptyGuid() ? Users.CurrentUserID : sendUserID),
				SendUserName = (sendUserName.IsNullOrEmpty() ? Users.CurrentUserName : sendUserName),
				Status = status,
				Note = note
			});
		}

		public static string SendSMS(string mobileNumber, string contents)
		{
			if (mobileNumber.IsNullOrEmpty() || contents.IsNullOrEmpty())
			{
				return "";
			}
			string[] array = mobileNumber.Split(',');
			for (int i = 0; i < array.Length; i++)
			{
				AddSync(array[i], contents, 1, Guid.Empty);
			}
			return "";
		}
	}
}
