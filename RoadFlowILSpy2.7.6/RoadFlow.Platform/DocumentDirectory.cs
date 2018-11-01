using RoadFlow.Cache.IO;
using RoadFlow.Data.Factory;
using RoadFlow.Data.Interface;
using RoadFlow.Data.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace RoadFlow.Platform
{
	public class DocumentDirectory
	{
		private IDocumentDirectory dataDocumentDirectory;

		private string DocumentsDirectoryCacheKey = 16.ToString();

		private string DocumentsDirectoryManageUsers = 19.ToString();

		private string DocumentsDirectoryPublishUsers = 18.ToString();

		private string DocumentsDirectoryReadUsers = 17.ToString();

		public DocumentDirectory()
		{
			dataDocumentDirectory = Factory.GetDocumentDirectory();
		}

		public int Add(RoadFlow.Data.Model.DocumentDirectory model)
		{
			return dataDocumentDirectory.Add(model);
		}

		public int Update(RoadFlow.Data.Model.DocumentDirectory model)
		{
			return dataDocumentDirectory.Update(model);
		}

		public List<RoadFlow.Data.Model.DocumentDirectory> GetAll(bool fromCache = true)
		{
			if (!fromCache)
			{
				return dataDocumentDirectory.GetAll();
			}
			object obj = Opation.Get(DocumentsDirectoryCacheKey);
			if (obj is List<RoadFlow.Data.Model.DocumentDirectory>)
			{
				return (List<RoadFlow.Data.Model.DocumentDirectory>)obj;
			}
			List<RoadFlow.Data.Model.DocumentDirectory> all = dataDocumentDirectory.GetAll();
			Opation.Set(DocumentsDirectoryCacheKey, all);
			return all;
		}

		public RoadFlow.Data.Model.DocumentDirectory Get(Guid id)
		{
			return GetAll().Find((RoadFlow.Data.Model.DocumentDirectory p) => p.ID == id);
		}

		public int Delete(Guid id)
		{
			return dataDocumentDirectory.Delete(id);
		}

		public long GetCount()
		{
			return dataDocumentDirectory.GetCount();
		}

		public void ClearCache()
		{
			Opation.Remove(DocumentsDirectoryCacheKey);
		}

		public List<RoadFlow.Data.Model.DocumentDirectory> GetChilds(Guid id)
		{
			return (from p in GetAll().FindAll((RoadFlow.Data.Model.DocumentDirectory p) => p.ParentID == id)
			orderby p.Sort
			select p).ToList();
		}

		public List<RoadFlow.Data.Model.DocumentDirectory> GetDisplayChilds(Guid id, Guid userID)
		{
			List<RoadFlow.Data.Model.DocumentDirectory> list = (from p in GetAll().FindAll((RoadFlow.Data.Model.DocumentDirectory p) => p.ParentID == id)
			orderby p.Sort
			select p).ToList();
			List<RoadFlow.Data.Model.DocumentDirectory> list2 = new List<RoadFlow.Data.Model.DocumentDirectory>();
			foreach (RoadFlow.Data.Model.DocumentDirectory item in list)
			{
				if (HasDisplay(item, userID))
				{
					list2.Add(item);
				}
			}
			return list2;
		}

		public string GetAllChildIdString(Guid id)
		{
			List<RoadFlow.Data.Model.DocumentDirectory> allChilds = GetAllChilds(id);
			StringBuilder stringBuilder = new StringBuilder();
			foreach (RoadFlow.Data.Model.DocumentDirectory item in allChilds)
			{
				stringBuilder.Append(item.ID);
				stringBuilder.Append(",");
			}
			return stringBuilder.ToString().TrimEnd(',');
		}

		public string GetAllChildIdString(Guid id, Guid userID)
		{
			List<RoadFlow.Data.Model.DocumentDirectory> allChilds = GetAllChilds(id);
			StringBuilder stringBuilder = new StringBuilder();
			foreach (RoadFlow.Data.Model.DocumentDirectory item in allChilds)
			{
				if (HasRead(item.ID, userID))
				{
					stringBuilder.Append(item.ID);
					stringBuilder.Append(",");
				}
			}
			return stringBuilder.ToString().TrimEnd(',');
		}

		public List<RoadFlow.Data.Model.DocumentDirectory> GetAllParents(Guid id, bool isMe = false)
		{
			List<RoadFlow.Data.Model.DocumentDirectory> list = new List<RoadFlow.Data.Model.DocumentDirectory>();
			RoadFlow.Data.Model.DocumentDirectory documentDirectory = Get(id);
			if (documentDirectory == null)
			{
				return list;
			}
			if (isMe)
			{
				list.Add(documentDirectory);
			}
			addParent(list, documentDirectory.ParentID);
			return list;
		}

		private void addParent(List<RoadFlow.Data.Model.DocumentDirectory> list, Guid id)
		{
			if (!id.IsEmptyGuid())
			{
				RoadFlow.Data.Model.DocumentDirectory documentDirectory = Get(id);
				if (documentDirectory != null)
				{
					list.Add(documentDirectory);
					addParent(list, documentDirectory.ParentID);
				}
			}
		}

		public string GetAllParentsName(Guid id, bool isMe = true, bool isRoot = true)
		{
			List<RoadFlow.Data.Model.DocumentDirectory> list = GetAllParents(id, isMe).FindAll((RoadFlow.Data.Model.DocumentDirectory p) => !p.ParentID.IsEmptyGuid());
			StringBuilder stringBuilder = new StringBuilder();
			foreach (RoadFlow.Data.Model.DocumentDirectory item in list)
			{
				stringBuilder.Append(item.Name);
				stringBuilder.Append(" / ");
			}
			return stringBuilder.ToString().TrimEnd('/', ' ');
		}

		public List<RoadFlow.Data.Model.DocumentDirectory> GetAllChilds(Guid id, bool isMe = true)
		{
			List<RoadFlow.Data.Model.DocumentDirectory> list = new List<RoadFlow.Data.Model.DocumentDirectory>();
			RoadFlow.Data.Model.DocumentDirectory documentDirectory = Get(id);
			if (documentDirectory != null)
			{
				if (isMe)
				{
					list.Add(documentDirectory);
				}
				addChilds(list, id);
			}
			return list;
		}

		private void addChilds(List<RoadFlow.Data.Model.DocumentDirectory> list, Guid id)
		{
			foreach (RoadFlow.Data.Model.DocumentDirectory child in GetChilds(id))
			{
				list.Add(child);
				addChilds(list, child.ID);
			}
		}

		public int GetMaxSort(Guid dirID)
		{
			return dataDocumentDirectory.GetMaxSort(dirID);
		}

		public RoadFlow.Data.Model.DocumentDirectory GetRoot()
		{
			return GetAll().Find((RoadFlow.Data.Model.DocumentDirectory p) => p.ParentID == Guid.Empty);
		}

		public string GetName(Guid id)
		{
			RoadFlow.Data.Model.DocumentDirectory documentDirectory = Get(id);
			if (documentDirectory != null)
			{
				return documentDirectory.Name;
			}
			return "";
		}

		public List<RoadFlow.Data.Model.Users> GetReadUsers(Guid dirID)
		{
			object obj = Opation.Get(DocumentsDirectoryReadUsers + dirID.ToString("N"));
			if (obj is List<RoadFlow.Data.Model.Users>)
			{
				return (List<RoadFlow.Data.Model.Users>)obj;
			}
			RoadFlow.Data.Model.DocumentDirectory documentDirectory = Get(dirID);
			if (documentDirectory == null)
			{
				return new List<RoadFlow.Data.Model.Users>();
			}
			if (!documentDirectory.ReadUsers.IsNullOrEmpty())
			{
				List<RoadFlow.Data.Model.Users> allUsers = new Organize().GetAllUsers(documentDirectory.ReadUsers);
				Opation.Set(DocumentsDirectoryReadUsers + dirID.ToString("N"), allUsers);
				return allUsers;
			}
			foreach (RoadFlow.Data.Model.DocumentDirectory allParent in GetAllParents(dirID))
			{
				if (!allParent.ReadUsers.IsNullOrEmpty())
				{
					List<RoadFlow.Data.Model.Users> allUsers2 = new Organize().GetAllUsers(allParent.ReadUsers);
					Opation.Set(DocumentsDirectoryReadUsers + dirID.ToString("N"), allUsers2);
					return allUsers2;
				}
			}
			return new List<RoadFlow.Data.Model.Users>();
		}

		public List<RoadFlow.Data.Model.Users> GetPublishUsers(Guid dirID)
		{
			object obj = Opation.Get(DocumentsDirectoryPublishUsers + dirID.ToString("N"));
			if (obj is List<RoadFlow.Data.Model.Users>)
			{
				return (List<RoadFlow.Data.Model.Users>)obj;
			}
			RoadFlow.Data.Model.DocumentDirectory documentDirectory = Get(dirID);
			if (documentDirectory == null)
			{
				return new List<RoadFlow.Data.Model.Users>();
			}
			if (!documentDirectory.PublishUsers.IsNullOrEmpty())
			{
				List<RoadFlow.Data.Model.Users> allUsers = new Organize().GetAllUsers(documentDirectory.PublishUsers);
				Opation.Set(DocumentsDirectoryPublishUsers + dirID.ToString("N"), allUsers);
				return allUsers;
			}
			foreach (RoadFlow.Data.Model.DocumentDirectory allParent in GetAllParents(dirID))
			{
				if (!allParent.PublishUsers.IsNullOrEmpty())
				{
					List<RoadFlow.Data.Model.Users> allUsers2 = new Organize().GetAllUsers(allParent.PublishUsers);
					Opation.Set(DocumentsDirectoryPublishUsers + dirID.ToString("N"), allUsers2);
					return allUsers2;
				}
			}
			return new List<RoadFlow.Data.Model.Users>();
		}

		public List<RoadFlow.Data.Model.Users> GetManageUsers(Guid dirID)
		{
			object obj = Opation.Get(DocumentsDirectoryManageUsers + dirID.ToString("N"));
			if (obj is List<RoadFlow.Data.Model.Users>)
			{
				return (List<RoadFlow.Data.Model.Users>)obj;
			}
			RoadFlow.Data.Model.DocumentDirectory documentDirectory = Get(dirID);
			if (documentDirectory == null)
			{
				return new List<RoadFlow.Data.Model.Users>();
			}
			if (!documentDirectory.ManageUsers.IsNullOrEmpty())
			{
				List<RoadFlow.Data.Model.Users> allUsers = new Organize().GetAllUsers(documentDirectory.ManageUsers);
				Opation.Set(DocumentsDirectoryManageUsers + dirID.ToString("N"), allUsers);
				return allUsers;
			}
			foreach (RoadFlow.Data.Model.DocumentDirectory allParent in GetAllParents(dirID))
			{
				if (!allParent.ManageUsers.IsNullOrEmpty())
				{
					List<RoadFlow.Data.Model.Users> allUsers2 = new Organize().GetAllUsers(allParent.ManageUsers);
					Opation.Set(DocumentsDirectoryManageUsers + dirID.ToString("N"), allUsers2);
					return allUsers2;
				}
			}
			return new List<RoadFlow.Data.Model.Users>();
		}

		public void ClearDirUsersCache(Guid dirID)
		{
			Opation.Remove(DocumentsDirectoryReadUsers + dirID.ToString("N"));
			Opation.Remove(DocumentsDirectoryPublishUsers + dirID.ToString("N"));
			Opation.Remove(DocumentsDirectoryManageUsers + dirID.ToString("N"));
		}

		public void ClearAllDirUsersCache()
		{
			foreach (RoadFlow.Data.Model.DocumentDirectory item in GetAll())
			{
				ClearDirUsersCache(item.ID);
			}
		}

		public bool HasRead(Guid dirID, Guid userID)
		{
			return GetReadUsers(dirID).Find((RoadFlow.Data.Model.Users p) => p.ID == userID) != null;
		}

		public bool HasPublish(Guid dirID, Guid userID)
		{
			return GetPublishUsers(dirID).Find((RoadFlow.Data.Model.Users p) => p.ID == userID) != null;
		}

		public bool HasManage(Guid dirID, Guid userID)
		{
			return GetManageUsers(dirID).Find((RoadFlow.Data.Model.Users p) => p.ID == userID) != null;
		}

		public bool HasDisplay(RoadFlow.Data.Model.DocumentDirectory dir, Guid userID)
		{
			if (dir == null)
			{
				return false;
			}
			if (HasManage(dir.ID, userID) || HasRead(dir.ID, userID) || HasPublish(dir.ID, userID))
			{
				return true;
			}
			foreach (RoadFlow.Data.Model.DocumentDirectory allChild in GetAllChilds(dir.ID))
			{
				if (HasManage(allChild.ID, userID) || HasRead(allChild.ID, userID) || HasPublish(allChild.ID, userID))
				{
					return true;
				}
			}
			return false;
		}

		public Dictionary<Guid, string> GetDirs(Guid userID)
		{
			List<RoadFlow.Data.Model.DocumentDirectory> all = GetAll();
			Dictionary<Guid, string> dictionary = new Dictionary<Guid, string>();
			foreach (RoadFlow.Data.Model.DocumentDirectory item in all)
			{
				if (HasDisplay(item, userID))
				{
					dictionary.Add(item.ID, GetAllParentsName(item.ID, true, false));
				}
			}
			return dictionary;
		}

		public string GetTreeJsonString()
		{
			List<RoadFlow.Data.Model.DocumentDirectory> childs = GetChilds(Guid.Empty);
			StringBuilder stringBuilder = new StringBuilder();
			foreach (RoadFlow.Data.Model.DocumentDirectory item in childs)
			{
				List<RoadFlow.Data.Model.DocumentDirectory> displayChilds = GetDisplayChilds(item.ID, Users.CurrentUserID);
				stringBuilder.Append("{");
				stringBuilder.AppendFormat("\"id\":\"{0}\",", item.ID);
				stringBuilder.AppendFormat("\"parentID\":\"{0}\",", item.ParentID);
				stringBuilder.AppendFormat("\"title\":\"{0}\",", item.Name.Replace1("\"", "'"));
				stringBuilder.AppendFormat("\"type\":\"{0}\",", "2");
				stringBuilder.AppendFormat("\"ico\":\"{0}\",", "");
				stringBuilder.AppendFormat("\"hasChilds\":\"{0}\",", (displayChilds.Count > 0) ? "1" : "0");
				stringBuilder.Append("\"childs\":[");
				foreach (RoadFlow.Data.Model.DocumentDirectory item2 in displayChilds)
				{
					List<RoadFlow.Data.Model.DocumentDirectory> childs2 = GetChilds(item2.ID);
					stringBuilder.Append("{");
					stringBuilder.AppendFormat("\"id\":\"{0}\",", item2.ID);
					stringBuilder.AppendFormat("\"parentID\":\"{0}\",", item2.ParentID);
					stringBuilder.AppendFormat("\"title\":\"{0}\",", item2.Name.Replace1("\"", "'"));
					stringBuilder.AppendFormat("\"type\":\"{0}\",", "2");
					stringBuilder.AppendFormat("\"ico\":\"{0}\",", "");
					stringBuilder.AppendFormat("\"hasChilds\":\"{0}\",", (childs2.Count > 0) ? "1" : "0");
					stringBuilder.Append("\"childs\":[");
					stringBuilder.Append("]}");
					if (item2.ID != displayChilds.Last().ID)
					{
						stringBuilder.Append(",");
					}
				}
				stringBuilder.Append("]},");
			}
			return "[" + stringBuilder.ToString().TrimEnd(',') + "]";
		}

		public string GetTreeRefreshJsonString(Guid refreshID)
		{
			List<RoadFlow.Data.Model.DocumentDirectory> displayChilds = GetDisplayChilds(refreshID, Users.CurrentUserID);
			StringBuilder stringBuilder = new StringBuilder();
			foreach (RoadFlow.Data.Model.DocumentDirectory item in displayChilds)
			{
				List<RoadFlow.Data.Model.DocumentDirectory> displayChilds2 = GetDisplayChilds(item.ID, Users.CurrentUserID);
				stringBuilder.Append("{");
				stringBuilder.AppendFormat("\"id\":\"{0}\",", item.ID);
				stringBuilder.AppendFormat("\"parentID\":\"{0}\",", item.ParentID);
				stringBuilder.AppendFormat("\"title\":\"{0}\",", item.Name.Replace1("\"", "'"));
				stringBuilder.AppendFormat("\"type\":\"{0}\",", "2");
				stringBuilder.AppendFormat("\"ico\":\"{0}\",", "");
				stringBuilder.AppendFormat("\"hasChilds\":\"{0}\",", (displayChilds2.Count > 0) ? "1" : "0");
				stringBuilder.Append("\"childs\":[");
				stringBuilder.Append("]},");
			}
			return "[" + stringBuilder.ToString().TrimEnd(',') + "]";
		}
	}
}
