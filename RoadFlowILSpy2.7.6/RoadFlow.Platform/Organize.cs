using RoadFlow.Data.Factory;
using RoadFlow.Data.Interface;
using RoadFlow.Data.Model;
using RoadFlow.Platform.WeiXin;
using RoadFlow.Utility;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Transactions;

namespace RoadFlow.Platform
{
	public class Organize
	{
		private IOrganize dataOrganize;

		private Dictionary<int, string> types
		{
			get
			{
				return new Dictionary<int, string>
				{
					{
						1,
						"单位"
					},
					{
						2,
						"部门"
					},
					{
						3,
						"岗位"
					}
				};
			}
		}

		private Dictionary<int, string> status
		{
			get
			{
				return new Dictionary<int, string>
				{
					{
						0,
						"正常"
					},
					{
						1,
						"冻结"
					}
				};
			}
		}

		private Dictionary<int, string> sexs
		{
			get
			{
				return new Dictionary<int, string>
				{
					{
						0,
						"男"
					},
					{
						1,
						"女"
					}
				};
			}
		}

		public Organize()
		{
			dataOrganize = Factory.GetOrganize();
		}

		public int Add(RoadFlow.Data.Model.Organize model)
		{
			return dataOrganize.Add(model);
		}

		public int Update(RoadFlow.Data.Model.Organize model)
		{
			return dataOrganize.Update(model);
		}

		public List<RoadFlow.Data.Model.Organize> GetAll()
		{
			return dataOrganize.GetAll();
		}

		public RoadFlow.Data.Model.Organize Get(Guid id)
		{
			return dataOrganize.Get(id);
		}

		public int Delete(Guid id)
		{
			if (RoadFlow.Utility.Config.IsDemo)
			{
				return 0;
			}
			return dataOrganize.Delete(id);
		}

		public long GetCount()
		{
			return dataOrganize.GetCount();
		}

		public RoadFlow.Data.Model.Organize GetRoot()
		{
			return dataOrganize.GetRoot();
		}

		public List<RoadFlow.Data.Model.Organize> GetChilds(Guid ID)
		{
			return dataOrganize.GetChilds(ID);
		}

		public string GetTypeRadio(string name, string value = "", string attributes = "")
		{
			StringBuilder stringBuilder = new StringBuilder();
			foreach (KeyValuePair<int, string> type in types)
			{
				stringBuilder.AppendFormat("<input type=\"radio\" style=\"vertical-align:middle;\" value=\"{0}\" id=\"orgtypes_{0}\" {1} name=\"{2}\" {3} /><label style=\"vertical-align:middle;\" for=\"orgtypes_{0}\">{4}</label>", type.Key, (type.Key.ToString() == value) ? "checked=\"checked\"" : "", name, attributes, type.Value);
			}
			return stringBuilder.ToString();
		}

		public string GetStatusRadio(string name, string value = "", string attributes = "")
		{
			StringBuilder stringBuilder = new StringBuilder();
			foreach (KeyValuePair<int, string> item in status)
			{
				stringBuilder.AppendFormat("<input type=\"radio\" style=\"vertical-align:middle;\" value=\"{0}\" id=\"orgstatus_{0}\" {1} name=\"{2}\" {3}/><label style=\"vertical-align:middle;\" for=\"orgstatus_{0}\">{4}</label>", item.Key, (item.Key.ToString() == value) ? "checked=\"checked\"" : "", name, attributes, item.Value);
			}
			return stringBuilder.ToString();
		}

		public string GetSexRadio(string name, string value = "", string attributes = "")
		{
			StringBuilder stringBuilder = new StringBuilder();
			foreach (KeyValuePair<int, string> sex in sexs)
			{
				stringBuilder.AppendFormat("<input type=\"radio\" style=\"vertical-align:middle;\" value=\"{0}\" id=\"sexstatus_{0}\" {1} name=\"{2}\" {3}/><label style=\"vertical-align:middle;\" for=\"sexstatus_{0}\">{4}</label>", sex.Key, (sex.Key.ToString() == value) ? "checked=\"checked\"" : "", name, attributes, sex.Value);
			}
			return stringBuilder.ToString();
		}

		public int GetMaxSort(Guid id)
		{
			return dataOrganize.GetMaxSort(id);
		}

		public List<RoadFlow.Data.Model.Users> GetAllUsers(Guid id)
		{
			List<RoadFlow.Data.Model.Organize> allChilds = GetAllChilds(id);
			List<Guid> list = new List<Guid>
			{
				id
			};
			foreach (RoadFlow.Data.Model.Organize item in allChilds)
			{
				list.Add(item.ID);
			}
			return new Users().GetAllByOrganizeIDArray(list.ToArray());
		}

		public List<RoadFlow.Data.Model.Users> GetAllUsers(string idString)
		{
			if (idString.IsNullOrEmpty())
			{
				return new List<RoadFlow.Data.Model.Users>();
			}
			string[] array = idString.Split(new char[1]
			{
				','
			}, StringSplitOptions.RemoveEmptyEntries);
			List<RoadFlow.Data.Model.Users> list = new List<RoadFlow.Data.Model.Users>();
			Users users = new Users();
			new WorkGroup();
			string[] array2 = array;
			foreach (string text in array2)
			{
				if (text.StartsWith("u_"))
				{
					list.Add(users.Get(Users.RemovePrefix(text).ToGuid()));
				}
				else if (text.IsGuid())
				{
					list.AddRange(GetAllUsers(text.ToGuid()));
				}
				else if (text.StartsWith("w_"))
				{
					addWorkGroupUsers(list, WorkGroup.RemovePrefix(text).ToGuid());
				}
			}
			list.RemoveAll((RoadFlow.Data.Model.Users p) => p == null);
			return list.Distinct(new UsersEqualityComparer()).ToList();
		}

		private void addWorkGroupUsers(List<RoadFlow.Data.Model.Users> userList, Guid workGroupID)
		{
			RoadFlow.Data.Model.WorkGroup workGroup = new WorkGroup().Get(workGroupID);
			if (workGroup != null && !workGroup.Members.IsNullOrEmpty())
			{
				string[] array = workGroup.Members.Split(new char[1]
				{
					','
				}, StringSplitOptions.RemoveEmptyEntries);
				Users users = new Users();
				new WorkGroup();
				string[] array2 = array;
				foreach (string text in array2)
				{
					if (text.StartsWith("u_"))
					{
						userList.Add(users.Get(Users.RemovePrefix(text).ToGuid()));
					}
					else if (text.IsGuid())
					{
						userList.AddRange(GetAllUsers(text.ToGuid()));
					}
					else if (text.StartsWith("w_"))
					{
						addWorkGroupUsers(userList, WorkGroup.RemovePrefix(text).ToGuid());
					}
				}
			}
		}

		public List<Guid> GetAllUsersIdList(string idString)
		{
			List<RoadFlow.Data.Model.Users> allUsers = GetAllUsers(idString);
			List<Guid> list = new List<Guid>();
			foreach (RoadFlow.Data.Model.Users item in allUsers)
			{
				if (item != null)
				{
					list.Add(item.ID);
				}
			}
			return list;
		}

		public List<Guid> GetAllUsersIdList(Guid id)
		{
			List<RoadFlow.Data.Model.Users> allUsers = GetAllUsers(id);
			List<Guid> list = new List<Guid>();
			foreach (RoadFlow.Data.Model.Users item in allUsers)
			{
				if (item != null)
				{
					list.Add(item.ID);
				}
			}
			return list;
		}

		public string GetAllUsersIdString(Guid id)
		{
			StringBuilder stringBuilder = new StringBuilder();
			foreach (Guid allUsersId in GetAllUsersIdList(id))
			{
				stringBuilder.Append(allUsersId);
				stringBuilder.Append(",");
			}
			return stringBuilder.ToString().TrimEnd(',');
		}

		public string GetAllUsersIdString(string idString)
		{
			StringBuilder stringBuilder = new StringBuilder();
			foreach (Guid allUsersId in GetAllUsersIdList(idString))
			{
				stringBuilder.Append(allUsersId);
				stringBuilder.Append(",");
			}
			return stringBuilder.ToString().TrimEnd(',');
		}

		public int UpdateChildsLength(Guid id)
		{
			int result = 0;
			if (Get(id) == null)
			{
				return result;
			}
			result = GetChilds(id).Count;
			result += GetAllUsers(id).Count;
			dataOrganize.UpdateChildsLength(id, result);
			return result;
		}

		public int UpdateSort(Guid id, int sort)
		{
			return dataOrganize.UpdateSort(id, sort);
		}

		public List<RoadFlow.Data.Model.Organize> GetAllParent(string number)
		{
			if (!number.IsNullOrEmpty())
			{
				return dataOrganize.GetAllParent(number);
			}
			return new List<RoadFlow.Data.Model.Organize>();
		}

		public List<RoadFlow.Data.Model.Organize> GetAllParent(Guid id)
		{
			RoadFlow.Data.Model.Organize organize = Get(id);
			if (organize == null)
			{
				return new List<RoadFlow.Data.Model.Organize>();
			}
			return dataOrganize.GetAllParent(organize.Number);
		}

		public List<RoadFlow.Data.Model.Organize> GetAllChilds(string number)
		{
			if (!number.IsNullOrEmpty())
			{
				return dataOrganize.GetAllChild(number);
			}
			return new List<RoadFlow.Data.Model.Organize>();
		}

		public List<RoadFlow.Data.Model.Organize> GetAllChilds(Guid id)
		{
			RoadFlow.Data.Model.Organize organize = Get(id);
			if (organize == null)
			{
				return new List<RoadFlow.Data.Model.Organize>();
			}
			return dataOrganize.GetAllChild(organize.Number);
		}

		public string GetAllParentNames(Guid id, bool reverse = false, string split = " / ")
		{
			List<RoadFlow.Data.Model.Organize> allParent = GetAllParent(id);
			if (reverse)
			{
				allParent.Reverse();
			}
			StringBuilder stringBuilder = new StringBuilder(allParent.Count * 100);
			int num = 0;
			foreach (RoadFlow.Data.Model.Organize item in allParent)
			{
				stringBuilder.Append(item.Name);
				if (num++ < allParent.Count - 1)
				{
					stringBuilder.Append(split);
				}
			}
			return stringBuilder.ToString();
		}

		public bool Move(Guid fromID, Guid toID)
		{
			RoadFlow.Data.Model.Organize organize = Get(fromID);
			RoadFlow.Data.Model.Organize organize2 = Get(toID);
			if (organize == null || organize2 == null)
			{
				return false;
			}
			if (organize2.Number.StartsWith(organize.Number, StringComparison.CurrentCultureIgnoreCase))
			{
				return false;
			}
			using (TransactionScope transactionScope = new TransactionScope())
			{
				Guid parentID = organize.ParentID;
				organize.ParentID = toID;
				organize.Depth = organize2.Depth + 1;
				organize.Number = organize2.Number + "," + organize.ID.ToString();
				Update(organize);
				if (RoadFlow.Platform.WeiXin.Config.IsUse)
				{
					new RoadFlow.Platform.WeiXin.Organize().EditDept(organize);
				}
				foreach (RoadFlow.Data.Model.Organize item in from p in GetAllChilds(fromID)
				orderby p.Depth
				select p)
				{
					item.Number = Get(item.ParentID).Number + "," + item.ID.ToString();
					item.Depth = item.Number.Split(',').Length - 1;
					Update(item);
				}
				UpdateChildsLength(toID);
				UpdateChildsLength(parentID);
				transactionScope.Complete();
				return true;
			}
		}

		public string GetName(Guid id)
		{
			RoadFlow.Data.Model.Organize organize = Get(id);
			if (organize != null)
			{
				return organize.Name;
			}
			return "";
		}

		public string GetName(string id)
		{
			string empty = string.Empty;
			if (id.IsGuid())
			{
				return GetName(id.ToGuid());
			}
			if (id.StartsWith("u_"))
			{
				Guid test;
				if (!Users.RemovePrefix(id).IsGuid(out test))
				{
					return "";
				}
				return new Users().GetName(test);
			}
			if (id.StartsWith("w_"))
			{
				Guid test2;
				if (!WorkGroup.RemovePrefix(id).IsGuid(out test2))
				{
					return "";
				}
				return new WorkGroup().GetName(test2);
			}
			return "";
		}

		public string GetNames(string idString, string split = ",")
		{
			if (idString.IsNullOrEmpty())
			{
				return "";
			}
			string[] array = idString.Split(',');
			StringBuilder stringBuilder = new StringBuilder(array.Length * 50);
			int num = 0;
			int num2 = 1;
			string[] array2 = array;
			foreach (string text in array2)
			{
				if (text.IsNullOrEmpty())
				{
					num2++;
				}
				else
				{
					string name = GetName(text);
					if (name.IsNullOrEmpty())
					{
						num2++;
					}
					else
					{
						stringBuilder.Append(name);
						if (num++ < array.Length - num2)
						{
							stringBuilder.Append(split);
						}
					}
				}
			}
			return stringBuilder.ToString();
		}

		public int DeleteAndAllChilds(Guid orgID)
		{
			int num = 0;
			using (TransactionScope transactionScope = new TransactionScope())
			{
				UsersRelation usersRelation = new UsersRelation();
				Users users = new Users();
				List<RoadFlow.Data.Model.Organize> allChilds = GetAllChilds(orgID);
				List<string> list = new List<string>();
				List<RoadFlow.Data.Model.Organize> list2 = new List<RoadFlow.Data.Model.Organize>();
				foreach (RoadFlow.Data.Model.Organize item in allChilds)
				{
					foreach (RoadFlow.Data.Model.UsersRelation item2 in usersRelation.GetAllByOrganizeID(item.ID).FindAll((RoadFlow.Data.Model.UsersRelation p) => p.IsMain == 1))
					{
						RoadFlow.Data.Model.Users users2 = users.Get(item2.UserID);
						usersRelation.Delete(item2.UserID, item2.OrganizeID);
						num += users.Delete(item2.UserID);
						if (users2 != null)
						{
							list.Add(users2.Account);
						}
					}
					num += Delete(item.ID);
					list2.Add(item);
				}
				foreach (RoadFlow.Data.Model.UsersRelation item3 in usersRelation.GetAllByOrganizeID(orgID).FindAll((RoadFlow.Data.Model.UsersRelation p) => p.IsMain == 1))
				{
					usersRelation.Delete(item3.UserID, item3.OrganizeID);
					num += users.Delete(item3.UserID);
					RoadFlow.Data.Model.Users users3 = users.Get(item3.UserID);
					if (users3 != null)
					{
						list.Add(users3.Account);
					}
				}
				num += Delete(orgID);
				RoadFlow.Data.Model.Organize organize = Get(orgID);
				if (organize != null)
				{
					list2.Add(organize);
				}
				if (RoadFlow.Platform.WeiXin.Config.IsUse)
				{
					RoadFlow.Platform.WeiXin.Organize organize2 = new RoadFlow.Platform.WeiXin.Organize();
					if (list.Count > 0)
					{
						organize2.DeleteUserAsync(list.ToArray());
					}
					foreach (RoadFlow.Data.Model.Organize item4 in list2)
					{
						organize2.DeleteDeptAsync(item4.IntID);
					}
				}
				transactionScope.Complete();
				return num;
			}
		}
	}
}
