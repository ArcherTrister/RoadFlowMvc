using MySql.Data.MySqlClient;
using RoadFlow.Data.Interface;
using RoadFlow.Data.Model;
using RoadFlow.Utility;
using System;
using System.Collections.Generic;
using System.Data.Common;
using System.Text;

namespace RoadFlow.Data.MySql
{
	public class HomeItems : IHomeItems
	{
		private DBHelper dbHelper = new DBHelper();

		public int Add(RoadFlow.Data.Model.HomeItems model)
		{
			//IL_001b: Unknown result type (might be due to invalid IL or missing references)
			//IL_0020: Unknown result type (might be due to invalid IL or missing references)
			//IL_0031: Expected O, but got Unknown
			//IL_0032: Expected O, but got Unknown
			//IL_003c: Unknown result type (might be due to invalid IL or missing references)
			//IL_0041: Unknown result type (might be due to invalid IL or missing references)
			//IL_0052: Expected O, but got Unknown
			//IL_0053: Expected O, but got Unknown
			//IL_0060: Unknown result type (might be due to invalid IL or missing references)
			//IL_0065: Unknown result type (might be due to invalid IL or missing references)
			//IL_0071: Expected O, but got Unknown
			//IL_0072: Expected O, but got Unknown
			//IL_007f: Unknown result type (might be due to invalid IL or missing references)
			//IL_0084: Unknown result type (might be due to invalid IL or missing references)
			//IL_0090: Expected O, but got Unknown
			//IL_0091: Expected O, but got Unknown
			//IL_009b: Unknown result type (might be due to invalid IL or missing references)
			//IL_00a0: Unknown result type (might be due to invalid IL or missing references)
			//IL_00b1: Expected O, but got Unknown
			//IL_00b2: Expected O, but got Unknown
			//IL_00c7: Unknown result type (might be due to invalid IL or missing references)
			//IL_00cc: Unknown result type (might be due to invalid IL or missing references)
			//IL_00d8: Expected O, but got Unknown
			//IL_00e5: Unknown result type (might be due to invalid IL or missing references)
			//IL_00ea: Unknown result type (might be due to invalid IL or missing references)
			//IL_00f5: Expected O, but got Unknown
			//IL_00f6: Expected O, but got Unknown
			//IL_010b: Unknown result type (might be due to invalid IL or missing references)
			//IL_0110: Unknown result type (might be due to invalid IL or missing references)
			//IL_011c: Expected O, but got Unknown
			//IL_0129: Unknown result type (might be due to invalid IL or missing references)
			//IL_012e: Unknown result type (might be due to invalid IL or missing references)
			//IL_0139: Expected O, but got Unknown
			//IL_013a: Expected O, but got Unknown
			//IL_0150: Unknown result type (might be due to invalid IL or missing references)
			//IL_0155: Unknown result type (might be due to invalid IL or missing references)
			//IL_0161: Expected O, but got Unknown
			//IL_016f: Unknown result type (might be due to invalid IL or missing references)
			//IL_0174: Unknown result type (might be due to invalid IL or missing references)
			//IL_017f: Expected O, but got Unknown
			//IL_0180: Expected O, but got Unknown
			//IL_0196: Unknown result type (might be due to invalid IL or missing references)
			//IL_019b: Unknown result type (might be due to invalid IL or missing references)
			//IL_01a7: Expected O, but got Unknown
			//IL_01b5: Unknown result type (might be due to invalid IL or missing references)
			//IL_01ba: Unknown result type (might be due to invalid IL or missing references)
			//IL_01c5: Expected O, but got Unknown
			//IL_01c6: Expected O, but got Unknown
			//IL_01e5: Unknown result type (might be due to invalid IL or missing references)
			//IL_01ea: Unknown result type (might be due to invalid IL or missing references)
			//IL_01fb: Expected O, but got Unknown
			//IL_0209: Unknown result type (might be due to invalid IL or missing references)
			//IL_020e: Unknown result type (might be due to invalid IL or missing references)
			//IL_0219: Expected O, but got Unknown
			//IL_021a: Expected O, but got Unknown
			//IL_0230: Unknown result type (might be due to invalid IL or missing references)
			//IL_0235: Unknown result type (might be due to invalid IL or missing references)
			//IL_0241: Expected O, but got Unknown
			//IL_024e: Unknown result type (might be due to invalid IL or missing references)
			//IL_0253: Unknown result type (might be due to invalid IL or missing references)
			//IL_025e: Expected O, but got Unknown
			//IL_025f: Expected O, but got Unknown
			//IL_0275: Unknown result type (might be due to invalid IL or missing references)
			//IL_027a: Unknown result type (might be due to invalid IL or missing references)
			//IL_0286: Expected O, but got Unknown
			//IL_0293: Unknown result type (might be due to invalid IL or missing references)
			//IL_0298: Unknown result type (might be due to invalid IL or missing references)
			//IL_02a3: Expected O, but got Unknown
			//IL_02a4: Expected O, but got Unknown
			//IL_02ba: Unknown result type (might be due to invalid IL or missing references)
			//IL_02bf: Unknown result type (might be due to invalid IL or missing references)
			//IL_02cb: Expected O, but got Unknown
			//IL_02d8: Unknown result type (might be due to invalid IL or missing references)
			//IL_02dd: Unknown result type (might be due to invalid IL or missing references)
			//IL_02e8: Expected O, but got Unknown
			//IL_02e9: Expected O, but got Unknown
			//IL_0304: Unknown result type (might be due to invalid IL or missing references)
			//IL_0309: Unknown result type (might be due to invalid IL or missing references)
			//IL_031a: Expected O, but got Unknown
			//IL_0324: Unknown result type (might be due to invalid IL or missing references)
			//IL_0329: Unknown result type (might be due to invalid IL or missing references)
			//IL_0334: Expected O, but got Unknown
			//IL_0335: Expected O, but got Unknown
			//IL_034b: Unknown result type (might be due to invalid IL or missing references)
			//IL_0350: Unknown result type (might be due to invalid IL or missing references)
			//IL_035c: Expected O, but got Unknown
			//IL_0369: Unknown result type (might be due to invalid IL or missing references)
			//IL_036e: Unknown result type (might be due to invalid IL or missing references)
			//IL_0379: Expected O, but got Unknown
			//IL_037a: Expected O, but got Unknown
			string sql = "INSERT INTO homeitems\r\n\t\t\t\t(ID,Type,Name,Title,DataSourceType,DataSource,Ico,BgColor,Color,DBConnID,LinkURL,UseOrganizes,UseUsers,Sort,Note) \r\n\t\t\t\tVALUES(@ID,@Type,@Name,@Title,@DataSourceType,@DataSource,@Ico,@BgColor,@Color,@DBConnID,@LinkURL,@UseOrganizes,@UseUsers,@Sort,@Note)";
			MySqlParameter[] obj = new MySqlParameter[15];
			MySqlParameter val = new MySqlParameter("@ID", 253, 36);
			((DbParameter)val).Value = model.ID;
			obj[0] = val;
			MySqlParameter val2 = new MySqlParameter("@Type", 3, 11);
			((DbParameter)val2).Value = model.Type;
			obj[1] = val2;
			MySqlParameter val3 = new MySqlParameter("@Name", 752, -1);
			((DbParameter)val3).Value = model.Name;
			obj[2] = val3;
			MySqlParameter val4 = new MySqlParameter("@Title", 752, -1);
			((DbParameter)val4).Value = model.Title;
			obj[3] = val4;
			MySqlParameter val5 = new MySqlParameter("@DataSourceType", 3, 11);
			((DbParameter)val5).Value = model.DataSourceType;
			obj[4] = val5;
			_003F val6;
			if (model.DataSource != null)
			{
				val6 = new MySqlParameter("@DataSource", 751, -1);
				((DbParameter)val6).Value = model.DataSource;
			}
			else
			{
				val6 = new MySqlParameter("@DataSource", 751, -1);
				((DbParameter)val6).Value = DBNull.Value;
			}
			obj[5] = val6;
			_003F val7;
			if (model.Ico != null)
			{
				val7 = new MySqlParameter("@Ico", 752, -1);
				((DbParameter)val7).Value = model.Ico;
			}
			else
			{
				val7 = new MySqlParameter("@Ico", 752, -1);
				((DbParameter)val7).Value = DBNull.Value;
			}
			obj[6] = val7;
			_003F val8;
			if (model.BgColor != null)
			{
				val8 = new MySqlParameter("@BgColor", 253, 50);
				((DbParameter)val8).Value = model.BgColor;
			}
			else
			{
				val8 = new MySqlParameter("@BgColor", 253, 50);
				((DbParameter)val8).Value = DBNull.Value;
			}
			obj[7] = val8;
			_003F val9;
			if (model.Color != null)
			{
				val9 = new MySqlParameter("@Color", 253, 50);
				((DbParameter)val9).Value = model.Color;
			}
			else
			{
				val9 = new MySqlParameter("@Color", 253, 50);
				((DbParameter)val9).Value = DBNull.Value;
			}
			obj[8] = val9;
			_003F val10;
			if (model.DBConnID.HasValue)
			{
				val10 = new MySqlParameter("@DBConnID", 253, 36);
				((DbParameter)val10).Value = model.DBConnID;
			}
			else
			{
				val10 = new MySqlParameter("@DBConnID", 253, 36);
				((DbParameter)val10).Value = DBNull.Value;
			}
			obj[9] = val10;
			_003F val11;
			if (model.LinkURL != null)
			{
				val11 = new MySqlParameter("@LinkURL", 752, -1);
				((DbParameter)val11).Value = model.LinkURL;
			}
			else
			{
				val11 = new MySqlParameter("@LinkURL", 752, -1);
				((DbParameter)val11).Value = DBNull.Value;
			}
			obj[10] = val11;
			_003F val12;
			if (model.UseOrganizes != null)
			{
				val12 = new MySqlParameter("@UseOrganizes", 751, -1);
				((DbParameter)val12).Value = model.UseOrganizes;
			}
			else
			{
				val12 = new MySqlParameter("@UseOrganizes", 751, -1);
				((DbParameter)val12).Value = DBNull.Value;
			}
			obj[11] = val12;
			_003F val13;
			if (model.UseUsers != null)
			{
				val13 = new MySqlParameter("@UseUsers", 751, -1);
				((DbParameter)val13).Value = model.UseUsers;
			}
			else
			{
				val13 = new MySqlParameter("@UseUsers", 751, -1);
				((DbParameter)val13).Value = DBNull.Value;
			}
			obj[12] = val13;
			_003F val14;
			if (model.Sort.HasValue)
			{
				val14 = new MySqlParameter("@Sort", 3, 11);
				((DbParameter)val14).Value = model.Sort;
			}
			else
			{
				val14 = new MySqlParameter("@Sort", 3, 11);
				((DbParameter)val14).Value = DBNull.Value;
			}
			obj[13] = val14;
			_003F val15;
			if (model.Note != null)
			{
				val15 = new MySqlParameter("@Note", 752, -1);
				((DbParameter)val15).Value = model.Note;
			}
			else
			{
				val15 = new MySqlParameter("@Note", 752, -1);
				((DbParameter)val15).Value = DBNull.Value;
			}
			obj[14] = val15;
			MySqlParameter[] parameter = (MySqlParameter[])obj;
			return dbHelper.Execute(sql, parameter);
		}

		public int Update(RoadFlow.Data.Model.HomeItems model)
		{
			//IL_0017: Unknown result type (might be due to invalid IL or missing references)
			//IL_001c: Unknown result type (might be due to invalid IL or missing references)
			//IL_002d: Expected O, but got Unknown
			//IL_002e: Expected O, but got Unknown
			//IL_003b: Unknown result type (might be due to invalid IL or missing references)
			//IL_0040: Unknown result type (might be due to invalid IL or missing references)
			//IL_004c: Expected O, but got Unknown
			//IL_004d: Expected O, but got Unknown
			//IL_005a: Unknown result type (might be due to invalid IL or missing references)
			//IL_005f: Unknown result type (might be due to invalid IL or missing references)
			//IL_006b: Expected O, but got Unknown
			//IL_006c: Expected O, but got Unknown
			//IL_0076: Unknown result type (might be due to invalid IL or missing references)
			//IL_007b: Unknown result type (might be due to invalid IL or missing references)
			//IL_008c: Expected O, but got Unknown
			//IL_008d: Expected O, but got Unknown
			//IL_00a2: Unknown result type (might be due to invalid IL or missing references)
			//IL_00a7: Unknown result type (might be due to invalid IL or missing references)
			//IL_00b3: Expected O, but got Unknown
			//IL_00c0: Unknown result type (might be due to invalid IL or missing references)
			//IL_00c5: Unknown result type (might be due to invalid IL or missing references)
			//IL_00d0: Expected O, but got Unknown
			//IL_00d1: Expected O, but got Unknown
			//IL_00e6: Unknown result type (might be due to invalid IL or missing references)
			//IL_00eb: Unknown result type (might be due to invalid IL or missing references)
			//IL_00f7: Expected O, but got Unknown
			//IL_0104: Unknown result type (might be due to invalid IL or missing references)
			//IL_0109: Unknown result type (might be due to invalid IL or missing references)
			//IL_0114: Expected O, but got Unknown
			//IL_0115: Expected O, but got Unknown
			//IL_012b: Unknown result type (might be due to invalid IL or missing references)
			//IL_0130: Unknown result type (might be due to invalid IL or missing references)
			//IL_013c: Expected O, but got Unknown
			//IL_014a: Unknown result type (might be due to invalid IL or missing references)
			//IL_014f: Unknown result type (might be due to invalid IL or missing references)
			//IL_015a: Expected O, but got Unknown
			//IL_015b: Expected O, but got Unknown
			//IL_0171: Unknown result type (might be due to invalid IL or missing references)
			//IL_0176: Unknown result type (might be due to invalid IL or missing references)
			//IL_0182: Expected O, but got Unknown
			//IL_0190: Unknown result type (might be due to invalid IL or missing references)
			//IL_0195: Unknown result type (might be due to invalid IL or missing references)
			//IL_01a0: Expected O, but got Unknown
			//IL_01a1: Expected O, but got Unknown
			//IL_01bf: Unknown result type (might be due to invalid IL or missing references)
			//IL_01c4: Unknown result type (might be due to invalid IL or missing references)
			//IL_01d5: Expected O, but got Unknown
			//IL_01e3: Unknown result type (might be due to invalid IL or missing references)
			//IL_01e8: Unknown result type (might be due to invalid IL or missing references)
			//IL_01f3: Expected O, but got Unknown
			//IL_01f4: Expected O, but got Unknown
			//IL_020a: Unknown result type (might be due to invalid IL or missing references)
			//IL_020f: Unknown result type (might be due to invalid IL or missing references)
			//IL_021b: Expected O, but got Unknown
			//IL_0228: Unknown result type (might be due to invalid IL or missing references)
			//IL_022d: Unknown result type (might be due to invalid IL or missing references)
			//IL_0238: Expected O, but got Unknown
			//IL_0239: Expected O, but got Unknown
			//IL_024f: Unknown result type (might be due to invalid IL or missing references)
			//IL_0254: Unknown result type (might be due to invalid IL or missing references)
			//IL_0260: Expected O, but got Unknown
			//IL_026d: Unknown result type (might be due to invalid IL or missing references)
			//IL_0272: Unknown result type (might be due to invalid IL or missing references)
			//IL_027d: Expected O, but got Unknown
			//IL_027e: Expected O, but got Unknown
			//IL_0294: Unknown result type (might be due to invalid IL or missing references)
			//IL_0299: Unknown result type (might be due to invalid IL or missing references)
			//IL_02a5: Expected O, but got Unknown
			//IL_02b2: Unknown result type (might be due to invalid IL or missing references)
			//IL_02b7: Unknown result type (might be due to invalid IL or missing references)
			//IL_02c2: Expected O, but got Unknown
			//IL_02c3: Expected O, but got Unknown
			//IL_02de: Unknown result type (might be due to invalid IL or missing references)
			//IL_02e3: Unknown result type (might be due to invalid IL or missing references)
			//IL_02f4: Expected O, but got Unknown
			//IL_02fe: Unknown result type (might be due to invalid IL or missing references)
			//IL_0303: Unknown result type (might be due to invalid IL or missing references)
			//IL_030e: Expected O, but got Unknown
			//IL_030f: Expected O, but got Unknown
			//IL_0325: Unknown result type (might be due to invalid IL or missing references)
			//IL_032a: Unknown result type (might be due to invalid IL or missing references)
			//IL_0336: Expected O, but got Unknown
			//IL_0343: Unknown result type (might be due to invalid IL or missing references)
			//IL_0348: Unknown result type (might be due to invalid IL or missing references)
			//IL_0353: Expected O, but got Unknown
			//IL_0354: Expected O, but got Unknown
			//IL_0363: Unknown result type (might be due to invalid IL or missing references)
			//IL_0368: Unknown result type (might be due to invalid IL or missing references)
			//IL_0379: Expected O, but got Unknown
			//IL_037a: Expected O, but got Unknown
			string sql = "UPDATE homeitems SET \r\n\t\t\t\tType=@Type,Name=@Name,Title=@Title,DataSourceType=@DataSourceType,DataSource=@DataSource,Ico=@Ico,BgColor=@BgColor,Color=@Color,DBConnID=@DBConnID,LinkURL=@LinkURL,UseOrganizes=@UseOrganizes,UseUsers=@UseUsers,Sort=@Sort,Note=@Note\r\n\t\t\t\tWHERE ID=@ID";
			MySqlParameter[] obj = new MySqlParameter[15];
			MySqlParameter val = new MySqlParameter("@Type", 3, 11);
			((DbParameter)val).Value = model.Type;
			obj[0] = val;
			MySqlParameter val2 = new MySqlParameter("@Name", 752, -1);
			((DbParameter)val2).Value = model.Name;
			obj[1] = val2;
			MySqlParameter val3 = new MySqlParameter("@Title", 752, -1);
			((DbParameter)val3).Value = model.Title;
			obj[2] = val3;
			MySqlParameter val4 = new MySqlParameter("@DataSourceType", 3, 11);
			((DbParameter)val4).Value = model.DataSourceType;
			obj[3] = val4;
			_003F val5;
			if (model.DataSource != null)
			{
				val5 = new MySqlParameter("@DataSource", 751, -1);
				((DbParameter)val5).Value = model.DataSource;
			}
			else
			{
				val5 = new MySqlParameter("@DataSource", 751, -1);
				((DbParameter)val5).Value = DBNull.Value;
			}
			obj[4] = val5;
			_003F val6;
			if (model.Ico != null)
			{
				val6 = new MySqlParameter("@Ico", 752, -1);
				((DbParameter)val6).Value = model.Ico;
			}
			else
			{
				val6 = new MySqlParameter("@Ico", 752, -1);
				((DbParameter)val6).Value = DBNull.Value;
			}
			obj[5] = val6;
			_003F val7;
			if (model.BgColor != null)
			{
				val7 = new MySqlParameter("@BgColor", 253, 50);
				((DbParameter)val7).Value = model.BgColor;
			}
			else
			{
				val7 = new MySqlParameter("@BgColor", 253, 50);
				((DbParameter)val7).Value = DBNull.Value;
			}
			obj[6] = val7;
			_003F val8;
			if (model.Color != null)
			{
				val8 = new MySqlParameter("@Color", 253, 50);
				((DbParameter)val8).Value = model.Color;
			}
			else
			{
				val8 = new MySqlParameter("@Color", 253, 50);
				((DbParameter)val8).Value = DBNull.Value;
			}
			obj[7] = val8;
			_003F val9;
			if (model.DBConnID.HasValue)
			{
				val9 = new MySqlParameter("@DBConnID", 253, 36);
				((DbParameter)val9).Value = model.DBConnID;
			}
			else
			{
				val9 = new MySqlParameter("@DBConnID", 253, 36);
				((DbParameter)val9).Value = DBNull.Value;
			}
			obj[8] = val9;
			_003F val10;
			if (model.LinkURL != null)
			{
				val10 = new MySqlParameter("@LinkURL", 752, -1);
				((DbParameter)val10).Value = model.LinkURL;
			}
			else
			{
				val10 = new MySqlParameter("@LinkURL", 752, -1);
				((DbParameter)val10).Value = DBNull.Value;
			}
			obj[9] = val10;
			_003F val11;
			if (model.UseOrganizes != null)
			{
				val11 = new MySqlParameter("@UseOrganizes", 751, -1);
				((DbParameter)val11).Value = model.UseOrganizes;
			}
			else
			{
				val11 = new MySqlParameter("@UseOrganizes", 751, -1);
				((DbParameter)val11).Value = DBNull.Value;
			}
			obj[10] = val11;
			_003F val12;
			if (model.UseUsers != null)
			{
				val12 = new MySqlParameter("@UseUsers", 751, -1);
				((DbParameter)val12).Value = model.UseUsers;
			}
			else
			{
				val12 = new MySqlParameter("@UseUsers", 751, -1);
				((DbParameter)val12).Value = DBNull.Value;
			}
			obj[11] = val12;
			_003F val13;
			if (model.Sort.HasValue)
			{
				val13 = new MySqlParameter("@Sort", 3, 11);
				((DbParameter)val13).Value = model.Sort;
			}
			else
			{
				val13 = new MySqlParameter("@Sort", 3, 11);
				((DbParameter)val13).Value = DBNull.Value;
			}
			obj[12] = val13;
			_003F val14;
			if (model.Note != null)
			{
				val14 = new MySqlParameter("@Note", 752, -1);
				((DbParameter)val14).Value = model.Note;
			}
			else
			{
				val14 = new MySqlParameter("@Note", 752, -1);
				((DbParameter)val14).Value = DBNull.Value;
			}
			obj[13] = val14;
			MySqlParameter val15 = new MySqlParameter("@ID", 253, 36);
			((DbParameter)val15).Value = model.ID;
			obj[14] = val15;
			MySqlParameter[] parameter = (MySqlParameter[])obj;
			return dbHelper.Execute(sql, parameter);
		}

		public int Delete(Guid id)
		{
			//IL_001a: Unknown result type (might be due to invalid IL or missing references)
			//IL_001f: Unknown result type (might be due to invalid IL or missing references)
			//IL_0032: Expected O, but got Unknown
			//IL_0033: Expected O, but got Unknown
			string sql = "DELETE FROM homeitems WHERE ID=@ID";
			MySqlParameter[] obj = new MySqlParameter[1];
			MySqlParameter val = new MySqlParameter("@ID", 253, 36);
			((DbParameter)val).Value = id.ToString();
			obj[0] = val;
			MySqlParameter[] parameter = (MySqlParameter[])obj;
			return dbHelper.Execute(sql, parameter);
		}

		private List<RoadFlow.Data.Model.HomeItems> DataReaderToList(MySqlDataReader dataReader)
		{
			List<RoadFlow.Data.Model.HomeItems> list = new List<RoadFlow.Data.Model.HomeItems>();
			RoadFlow.Data.Model.HomeItems homeItems = null;
			while (((DbDataReader)dataReader).Read())
			{
				homeItems = new RoadFlow.Data.Model.HomeItems();
				homeItems.ID = ((DbDataReader)dataReader).GetString(0).ToGuid();
				homeItems.Type = ((DbDataReader)dataReader).GetInt32(1);
				homeItems.Name = ((DbDataReader)dataReader).GetString(2);
				homeItems.Title = ((DbDataReader)dataReader).GetString(3);
				homeItems.DataSourceType = ((DbDataReader)dataReader).GetInt32(4);
				if (!((DbDataReader)dataReader).IsDBNull(5))
				{
					homeItems.DataSource = ((DbDataReader)dataReader).GetString(5);
				}
				if (!((DbDataReader)dataReader).IsDBNull(6))
				{
					homeItems.Ico = ((DbDataReader)dataReader).GetString(6);
				}
				if (!((DbDataReader)dataReader).IsDBNull(7))
				{
					homeItems.BgColor = ((DbDataReader)dataReader).GetString(7);
				}
				if (!((DbDataReader)dataReader).IsDBNull(8))
				{
					homeItems.Color = ((DbDataReader)dataReader).GetString(8);
				}
				if (!((DbDataReader)dataReader).IsDBNull(9))
				{
					homeItems.DBConnID = ((DbDataReader)dataReader).GetString(9).ToGuid();
				}
				if (!((DbDataReader)dataReader).IsDBNull(10))
				{
					homeItems.LinkURL = ((DbDataReader)dataReader).GetString(10);
				}
				if (!((DbDataReader)dataReader).IsDBNull(11))
				{
					homeItems.UseOrganizes = ((DbDataReader)dataReader).GetString(11);
				}
				if (!((DbDataReader)dataReader).IsDBNull(12))
				{
					homeItems.UseUsers = ((DbDataReader)dataReader).GetString(12);
				}
				if (!((DbDataReader)dataReader).IsDBNull(13))
				{
					homeItems.Sort = ((DbDataReader)dataReader).GetInt32(13);
				}
				if (!((DbDataReader)dataReader).IsDBNull(14))
				{
					homeItems.Note = ((DbDataReader)dataReader).GetString(14);
				}
				list.Add(homeItems);
			}
			return list;
		}

		public List<RoadFlow.Data.Model.HomeItems> GetAll()
		{
			string sql = "SELECT * FROM homeitems";
			MySqlDataReader dataReader = dbHelper.GetDataReader(sql);
			List<RoadFlow.Data.Model.HomeItems> result = DataReaderToList(dataReader);
			((DbDataReader)dataReader).Close();
			return result;
		}

		public long GetCount()
		{
			string sql = "SELECT COUNT(*) FROM homeitems";
			long result;
			if (!long.TryParse(dbHelper.GetFieldValue(sql), out result))
			{
				return 0L;
			}
			return result;
		}

		public RoadFlow.Data.Model.HomeItems Get(Guid id)
		{
			//IL_001a: Unknown result type (might be due to invalid IL or missing references)
			//IL_001f: Unknown result type (might be due to invalid IL or missing references)
			//IL_0032: Expected O, but got Unknown
			//IL_0033: Expected O, but got Unknown
			string sql = "SELECT * FROM homeitems WHERE ID=@ID";
			MySqlParameter[] obj = new MySqlParameter[1];
			MySqlParameter val = new MySqlParameter("@ID", 253, 36);
			((DbParameter)val).Value = id.ToString();
			obj[0] = val;
			MySqlParameter[] parameter = (MySqlParameter[])obj;
			MySqlDataReader dataReader = dbHelper.GetDataReader(sql, parameter);
			List<RoadFlow.Data.Model.HomeItems> list = DataReaderToList(dataReader);
			((DbDataReader)dataReader).Close();
			if (list.Count <= 0)
			{
				return null;
			}
			return list[0];
		}

		public List<RoadFlow.Data.Model.HomeItems> GetList(out string pager, string query = "", string name = "", string title = "", string type = "")
		{
			//IL_002c: Unknown result type (might be due to invalid IL or missing references)
			//IL_0036: Expected O, but got Unknown
			//IL_0053: Unknown result type (might be due to invalid IL or missing references)
			//IL_005d: Expected O, but got Unknown
			//IL_007a: Unknown result type (might be due to invalid IL or missing references)
			//IL_0084: Expected O, but got Unknown
			List<MySqlParameter> list = new List<MySqlParameter>();
			StringBuilder stringBuilder = new StringBuilder("SELECT * FROM HomeItems WHERE 1=1 ");
			if (!name.IsNullOrEmpty())
			{
				stringBuilder.Append(" AND INSTR(Name,@Name)>0");
				list.Add(new MySqlParameter("@Name", (object)name));
			}
			if (!title.IsNullOrEmpty())
			{
				stringBuilder.Append(" AND INSTR(Title,@Title)>0");
				list.Add(new MySqlParameter("@Title", (object)title));
			}
			if (!type.IsNullOrEmpty())
			{
				stringBuilder.Append(" AND Type=@Type");
				list.Add(new MySqlParameter("@Type", (object)type));
			}
			stringBuilder.Append(" ORDER BY Type,Sort");
			int pageSize = Tools.GetPageSize();
			int pageNumber = Tools.GetPageNumber();
			long count;
			string paerSql = dbHelper.GetPaerSql(stringBuilder.ToString(), pageSize, pageNumber, out count, list.ToArray());
			pager = Tools.GetPagerHtml(count, pageSize, pageNumber, query);
			MySqlDataReader dataReader = dbHelper.GetDataReader(paerSql, list.ToArray());
			List<RoadFlow.Data.Model.HomeItems> result = DataReaderToList(dataReader);
			((DbDataReader)dataReader).Close();
			return result;
		}

		public List<RoadFlow.Data.Model.HomeItems> GetList(out long count, int size, int number, string name = "", string title = "", string type = "", string order = "")
		{
			//IL_002e: Unknown result type (might be due to invalid IL or missing references)
			//IL_0038: Expected O, but got Unknown
			//IL_0055: Unknown result type (might be due to invalid IL or missing references)
			//IL_005f: Expected O, but got Unknown
			//IL_007c: Unknown result type (might be due to invalid IL or missing references)
			//IL_0086: Expected O, but got Unknown
			List<MySqlParameter> list = new List<MySqlParameter>();
			StringBuilder stringBuilder = new StringBuilder("SELECT * FROM HomeItems WHERE 1=1 ");
			if (!name.IsNullOrEmpty())
			{
				stringBuilder.Append(" AND INSTR(Name,@Name)>0");
				list.Add(new MySqlParameter("@Name", (object)name));
			}
			if (!title.IsNullOrEmpty())
			{
				stringBuilder.Append(" AND INSTR(Title,@Title)>0");
				list.Add(new MySqlParameter("@Title", (object)title));
			}
			if (!type.IsNullOrEmpty())
			{
				stringBuilder.Append(" AND Type=@Type");
				list.Add(new MySqlParameter("@Type", (object)type));
			}
			stringBuilder.Append(order.IsNullOrEmpty() ? " ORDER BY Type,Sort" : (" ORDER BY " + order));
			string paerSql = dbHelper.GetPaerSql(stringBuilder.ToString(), size, number, out count, list.ToArray());
			MySqlDataReader dataReader = dbHelper.GetDataReader(paerSql, list.ToArray());
			List<RoadFlow.Data.Model.HomeItems> result = DataReaderToList(dataReader);
			((DbDataReader)dataReader).Close();
			return result;
		}

		public int GetMaxSort(int type)
		{
			string sql = "SELECT MAX(Sort) FROM HomeItems WHERE Type=" + type;
			return dbHelper.GetFieldValue(sql).ToInt(0) + 5;
		}
	}
}
