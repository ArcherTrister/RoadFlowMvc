using LitJson;
using RoadFlow.Data.Factory;
using RoadFlow.Data.Interface;
using RoadFlow.Data.Model;
using RoadFlow.Utility;
using System;
using System.Collections.Generic;
using System.Text;

namespace RoadFlow.Platform
{
	public class AppLibraryButtons
	{
		private IAppLibraryButtons dataAppLibraryButtons;

		public AppLibraryButtons()
		{
			dataAppLibraryButtons = Factory.GetAppLibraryButtons();
		}

		public int Add(RoadFlow.Data.Model.AppLibraryButtons model)
		{
			return dataAppLibraryButtons.Add(model);
		}

		public int Update(RoadFlow.Data.Model.AppLibraryButtons model)
		{
			return dataAppLibraryButtons.Update(model);
		}

		public List<RoadFlow.Data.Model.AppLibraryButtons> GetAll()
		{
			return dataAppLibraryButtons.GetAll();
		}

		public RoadFlow.Data.Model.AppLibraryButtons Get(Guid id)
		{
			return dataAppLibraryButtons.Get(id);
		}

		public int Delete(Guid id)
		{
			return dataAppLibraryButtons.Delete(id);
		}

		public long GetCount()
		{
			return dataAppLibraryButtons.GetCount();
		}

		public List<RoadFlow.Data.Model.AppLibraryButtons> GetPagerData(out string pager, string query = "", string title = "")
		{
			return dataAppLibraryButtons.GetPagerData(out pager, query, Tools.GetPageSize(), Tools.GetPageNumber(), title);
		}

		public List<RoadFlow.Data.Model.AppLibraryButtons> GetPagerData(out long count, int size, int number, string title = "", string order = "")
		{
			return dataAppLibraryButtons.GetPagerData(out count, size, number, title, order);
		}

		public int GetMaxSort()
		{
			return dataAppLibraryButtons.GetMaxSort();
		}

		public string GetAllJson()
		{
			List<RoadFlow.Data.Model.AppLibraryButtons> all = GetAll();
			JsonData jsonData = new JsonData();
			foreach (RoadFlow.Data.Model.AppLibraryButtons item in all)
			{
				JsonData jsonData2 = new JsonData();
				jsonData2["id"] = item.ID.ToString();
				jsonData2["name"] = item.Name;
				jsonData2["events"] = item.Events;
				jsonData2["ico"] = item.Ico;
				jsonData2["sort"] = item.Sort;
				jsonData.Add(jsonData2);
			}
			return jsonData.ToJson();
		}

		public string GetShowTypeOptions(string value = "")
		{
			Dictionary<int, string> obj = new Dictionary<int, string>
			{
				{
					1,
					"普通按钮"
				},
				{
					0,
					"工具栏按钮"
				},
				{
					2,
					"列表按钮"
				}
			};
			StringBuilder stringBuilder = new StringBuilder();
			foreach (KeyValuePair<int, string> item in obj)
			{
				stringBuilder.Append("<option value=\"" + item.Key + "\"" + ((item.Key.ToString() == value) ? " selected=\"selected\"" : "") + ">" + item.Value + "</option>");
			}
			return stringBuilder.ToString();
		}

		public string GetOptions(string value = "")
		{
			List<RoadFlow.Data.Model.AppLibraryButtons> all = GetAll();
			StringBuilder stringBuilder = new StringBuilder();
			stringBuilder.Append("<option value=\"\"></option>");
			foreach (RoadFlow.Data.Model.AppLibraryButtons item in all)
			{
				stringBuilder.Append("<option value=\"" + item.ID + "\"" + ((item.ID == value.ToGuid()) ? " selected=\"selected\"" : "") + ">" + item.Name + "</option>");
			}
			return stringBuilder.ToString();
		}
	}
}
