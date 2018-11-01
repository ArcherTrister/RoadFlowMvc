using RoadFlow.Cache.IO;
using RoadFlow.Data.Factory;
using RoadFlow.Data.Interface;
using RoadFlow.Data.Model;
using RoadFlow.Platform.WeiXin;
using RoadFlow.Utility;
using System;
using System.Collections.Generic;
using System.Web;

namespace RoadFlow.Platform
{
	public class Users
	{
		public const string PREFIX = "u_";

		private IUsers dataUsers;

		public static RoadFlow.Data.Model.Organize CurrentUnit
		{
			get
			{
				return new Users().GetUnitByUserID(CurrentUserID);
			}
		}

		public static Guid CurrentUnitID
		{
			get
			{
				RoadFlow.Data.Model.Organize unitByUserID = new Users().GetUnitByUserID(CurrentUserID);
				if (unitByUserID != null)
				{
					return unitByUserID.ID;
				}
				return Guid.Empty;
			}
		}

		public static string CurrentUnitName
		{
			get
			{
				RoadFlow.Data.Model.Organize unitByUserID = new Users().GetUnitByUserID(CurrentUserID);
				if (unitByUserID != null)
				{
					return unitByUserID.Name;
				}
				return "";
			}
		}

		public static RoadFlow.Data.Model.Organize CurrentDept
		{
			get
			{
				return new Users().GetDeptByUserID(CurrentUserID);
			}
		}

		public static Guid CurrentDeptID
		{
			get
			{
				RoadFlow.Data.Model.Organize deptByUserID = new Users().GetDeptByUserID(CurrentUserID);
				if (deptByUserID != null)
				{
					return deptByUserID.ID;
				}
				return Guid.Empty;
			}
		}

		public static string CurrentDeptName
		{
			get
			{
				RoadFlow.Data.Model.Organize deptByUserID = new Users().GetDeptByUserID(CurrentUserID);
				if (deptByUserID != null)
				{
					return deptByUserID.Name;
				}
				return "";
			}
		}

		public static Guid CurrentUserID
		{
			get
			{
				try
				{
					object obj = HttpContext.Current.Session[0.ToString()];
					return (obj == null) ? RoadFlow.Platform.WeiXin.Organize.CurrentUserID : obj.ToString().ToGuid();
				}
				catch
				{
					return Guid.Empty;
				}
			}
		}

		public static RoadFlow.Data.Model.Users CurrentUser
		{
			get
			{
				Guid currentUserID = CurrentUserID;
				if (currentUserID == Guid.Empty)
				{
					return null;
				}
				return new Users().Get(currentUserID);
			}
		}

		public static string CurrentUserName
		{
			get
			{
				string name = 1.ToString();
				object obj = HttpContext.Current.Session[name];
				string empty = string.Empty;
				if (obj == null)
				{
					empty = ((CurrentUser == null) ? "" : CurrentUser.Name);
					HttpContext.Current.Session[name] = empty;
				}
				else
				{
					empty = obj.ToString();
				}
				if (empty.IsNullOrEmpty())
				{
					empty = RoadFlow.Platform.WeiXin.Organize.CurrentUserName;
				}
				return empty;
			}
		}

		public static string CurrentUserAccount
		{
			get
			{
				if (CurrentUser != null)
				{
					return CurrentUser.Account;
				}
				return "";
			}
		}

		public Users()
		{
			dataUsers = Factory.GetUsers();
		}

		public int Add(RoadFlow.Data.Model.Users model)
		{
			return dataUsers.Add(model);
		}

		public int Update(RoadFlow.Data.Model.Users model)
		{
			return dataUsers.Update(model);
		}

		public List<RoadFlow.Data.Model.Users> GetAll()
		{
			return dataUsers.GetAll();
		}

		public RoadFlow.Data.Model.Users Get(Guid id)
		{
			return dataUsers.Get(id);
		}

		public int Delete(Guid id)
		{
			if (RoadFlow.Utility.Config.IsDemo)
			{
				return 0;
			}
			return dataUsers.Delete(id);
		}

		public long GetCount()
		{
			return dataUsers.GetCount();
		}

		public RoadFlow.Data.Model.Users GetByAccount(string account)
		{
			if (!account.IsNullOrEmpty())
			{
				return dataUsers.GetByAccount(account);
			}
			return null;
		}

		public string GetInitPassword()
		{
			return RoadFlow.Utility.Config.SystemInitPassword;
		}

		public string EncryptionPassword(string password)
		{
			if (password.IsNullOrEmpty())
			{
				return "";
			}
			HashEncrypt hashEncrypt = new HashEncrypt();
			return hashEncrypt.MD5System(hashEncrypt.MD5System(password));
		}

		public string GetUserEncryptionPassword(string userID, string password)
		{
			if (!password.IsNullOrEmpty() && !userID.IsNullOrEmpty())
			{
				return EncryptionPassword(userID.Trim().ToLower() + password.Trim());
			}
			return "";
		}

		public bool InitPassword(Guid userID)
		{
			return dataUsers.UpdatePassword(GetUserEncryptionPassword(userID.ToString(), GetInitPassword()), userID);
		}

		public List<RoadFlow.Data.Model.Users> GetAllByOrganizeID(Guid organizeID)
		{
			return dataUsers.GetAllByOrganizeID(organizeID);
		}

		public Dictionary<Guid, bool> GetAllStation(Guid userID)
		{
			List<RoadFlow.Data.Model.UsersRelation> allByUserID = new UsersRelation().GetAllByUserID(userID);
			Dictionary<Guid, bool> dictionary = new Dictionary<Guid, bool>();
			foreach (RoadFlow.Data.Model.UsersRelation item in allByUserID)
			{
				if (!dictionary.ContainsKey(item.OrganizeID))
				{
					dictionary.Add(item.OrganizeID, item.IsMain == 1);
				}
			}
			return dictionary;
		}

		public Guid GetMainStation(Guid userID)
		{
			RoadFlow.Data.Model.UsersRelation mainByUserID = new UsersRelation().GetMainByUserID(userID);
			if (mainByUserID != null)
			{
				return mainByUserID.OrganizeID;
			}
			return Guid.Empty;
		}

		public List<RoadFlow.Data.Model.Users> GetAllByOrganizeIDArray(Guid[] organizeIDArray)
		{
			return dataUsers.GetAllByOrganizeIDArray(organizeIDArray);
		}

		public RoadFlow.Data.Model.Organize GetUnitByUserID(Guid userID)
		{
			string key = 14.ToString();
			object obj = Opation.Get(key);
			Dictionary<Guid, RoadFlow.Data.Model.Organize> dictionary = new Dictionary<Guid, RoadFlow.Data.Model.Organize>();
			if (obj is Dictionary<Guid, RoadFlow.Data.Model.Organize>)
			{
				dictionary = (Dictionary<Guid, RoadFlow.Data.Model.Organize>)obj;
				if (dictionary.ContainsKey(userID))
				{
					return dictionary[userID];
				}
			}
			Guid mainStation = GetMainStation(userID);
			if (mainStation == Guid.Empty)
			{
				return null;
			}
			List<RoadFlow.Data.Model.Organize> allParent = new Organize().GetAllParent(mainStation);
			allParent.Reverse();
			foreach (RoadFlow.Data.Model.Organize item in allParent)
			{
				if (item.Type == 1)
				{
					dictionary.Add(userID, item);
					Opation.Set(key, dictionary);
					return item;
				}
			}
			return null;
		}

		public RoadFlow.Data.Model.Organize GetDeptByUserID(Guid userID)
		{
			string key = 13.ToString();
			object obj = Opation.Get(key);
			Dictionary<Guid, RoadFlow.Data.Model.Organize> dictionary = new Dictionary<Guid, RoadFlow.Data.Model.Organize>();
			if (obj is Dictionary<Guid, RoadFlow.Data.Model.Organize>)
			{
				dictionary = (Dictionary<Guid, RoadFlow.Data.Model.Organize>)obj;
				if (dictionary.ContainsKey(userID))
				{
					return dictionary[userID];
				}
			}
			Guid mainStation = GetMainStation(userID);
			if (mainStation == Guid.Empty)
			{
				return null;
			}
			List<RoadFlow.Data.Model.Organize> allParent = new Organize().GetAllParent(mainStation);
			allParent.Reverse();
			foreach (RoadFlow.Data.Model.Organize item in allParent)
			{
				if (item.Type == 2)
				{
					dictionary.Add(userID, item);
					Opation.Set(key, dictionary);
					return item;
				}
			}
			return null;
		}

		public bool HasAccount(string account, string userID = "")
		{
			if (!account.IsNullOrEmpty())
			{
				return dataUsers.HasAccount(account.Trim(), userID);
			}
			return false;
		}

		public bool UpdatePassword(string password, Guid userID)
		{
			if (RoadFlow.Utility.Config.IsDemo)
			{
				return true;
			}
			if (!password.IsNullOrEmpty())
			{
				return dataUsers.UpdatePassword(GetUserEncryptionPassword(userID.ToString(), password.Trim()), userID);
			}
			return false;
		}

		public string GetAccount(string account)
		{
			if (account.IsNullOrEmpty())
			{
				return "";
			}
			string text = account.Trim();
			int num = 0;
			while (HasAccount(text))
			{
				string str = text;
				int num2 = ++num;
				text = str + num2.ToString();
			}
			return text;
		}

		public int UpdateSort(Guid userID, int sort)
		{
			return dataUsers.UpdateSort(userID, sort);
		}

		public string GetName(Guid id)
		{
			RoadFlow.Data.Model.Users users = Get(id);
			if (users != null)
			{
				return users.Name;
			}
			return "";
		}

		public static string RemovePrefix(string id)
		{
			if (id.IsNullOrEmpty())
			{
				return "";
			}
			if (id.StartsWith("u_"))
			{
				return id.Replace("u_", "");
			}
			return id;
		}

		public string RemovePrefix1(string id)
		{
			if (!id.IsNullOrEmpty())
			{
				return id.Replace("u_", "");
			}
			return "";
		}

		public string GetLeader(Guid userID)
		{
			Guid mainStation = GetMainStation(userID);
			Organize organize = new Organize();
			RoadFlow.Data.Model.Organize organize2 = organize.Get(mainStation);
			if (organize2 == null)
			{
				return "";
			}
			if (!organize2.Leader.IsNullOrEmpty())
			{
				return organize2.Leader;
			}
			foreach (RoadFlow.Data.Model.Organize item in organize.GetAllParent(organize2.Number))
			{
				if (!item.Leader.IsNullOrEmpty())
				{
					return item.Leader;
				}
			}
			return "";
		}

		public string GetChargeLeader(Guid userID)
		{
			Guid mainStation = GetMainStation(userID);
			Organize organize = new Organize();
			RoadFlow.Data.Model.Organize organize2 = organize.Get(mainStation);
			if (organize2 == null)
			{
				return "";
			}
			if (!organize2.ChargeLeader.IsNullOrEmpty())
			{
				return organize2.ChargeLeader;
			}
			foreach (RoadFlow.Data.Model.Organize item in organize.GetAllParent(organize2.Number))
			{
				if (!item.ChargeLeader.IsNullOrEmpty())
				{
					return item.ChargeLeader;
				}
			}
			return "";
		}

		public string GetParentDeptLeader(Guid userID)
		{
			Guid mainStation = GetMainStation(userID);
			Organize organize = new Organize();
			RoadFlow.Data.Model.Organize organize2 = organize.Get(mainStation);
			if (organize2 == null)
			{
				return "";
			}
			foreach (RoadFlow.Data.Model.Organize item in organize.GetAllParent(organize2.Number))
			{
				if (!item.Leader.IsNullOrEmpty())
				{
					return item.Leader;
				}
			}
			return "";
		}

		public bool IsLeader(Guid userID)
		{
			return GetLeader(userID).Contains(userID.ToString(), StringComparison.CurrentCultureIgnoreCase);
		}

		public bool IsChargeLeader(Guid userID)
		{
			return GetChargeLeader(userID).Contains(userID.ToString(), StringComparison.CurrentCultureIgnoreCase);
		}

		public bool IsContains(Guid userID, string memberString)
		{
			if (memberString.IsNullOrEmpty())
			{
				return false;
			}
			return new Organize().GetAllUsers(memberString).Find((RoadFlow.Data.Model.Users p) => p.ID == userID) != null;
		}

		public string GetMobileNumber(Guid userID)
		{
			RoadFlow.Data.Model.Users users = new Users().Get(userID);
			if (users == null)
			{
				return "";
			}
			return users.Mobile;
		}

		public List<RoadFlow.Data.Model.Users> GetAllByIDString(string idString)
		{
			if (idString.IsNullOrEmpty())
			{
				return new List<RoadFlow.Data.Model.Users>();
			}
			return dataUsers.GetAllByIDString(idString);
		}

		public List<RoadFlow.Data.Model.Users> GetAllByWorkGroupID(Guid workgroupid)
		{
			return dataUsers.GetAllByWorkGroupID(workgroupid);
		}

		public string GetAccountByID(Guid id)
		{
			RoadFlow.Data.Model.Users users = Get(id);
			if (users != null)
			{
				return users.Account;
			}
			return "";
		}

		public List<string> GetAllParentsDeptLeader(Guid userID)
		{
			List<string> list = new List<string>();
			Guid mainStation = GetMainStation(userID);
			if (mainStation.IsEmptyGuid())
			{
				return list;
			}
			RoadFlow.Data.Model.Organize organize = new Organize().Get(mainStation);
			if (organize == null)
			{
				return list;
			}
			if (!organize.Leader.IsNullOrEmpty())
			{
				list.Add(organize.Leader);
			}
			foreach (RoadFlow.Data.Model.Organize item in new Organize().GetAllParent(mainStation))
			{
				if (!item.Leader.IsNullOrEmpty())
				{
					list.Add(item.Leader);
				}
			}
			return list;
		}
	}
}
