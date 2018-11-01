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
	public class ProgramBuilder : IProgramBuilder
	{
		private DBHelper dbHelper = new DBHelper();

		public int Add(RoadFlow.Data.Model.ProgramBuilder model)
		{
			//IL_001b: Unknown result type (might be due to invalid IL or missing references)
			//IL_0020: Unknown result type (might be due to invalid IL or missing references)
			//IL_0031: Expected O, but got Unknown
			//IL_0032: Expected O, but got Unknown
			//IL_003f: Unknown result type (might be due to invalid IL or missing references)
			//IL_0044: Unknown result type (might be due to invalid IL or missing references)
			//IL_0050: Expected O, but got Unknown
			//IL_0051: Expected O, but got Unknown
			//IL_005f: Unknown result type (might be due to invalid IL or missing references)
			//IL_0064: Unknown result type (might be due to invalid IL or missing references)
			//IL_0075: Expected O, but got Unknown
			//IL_0076: Expected O, but got Unknown
			//IL_0080: Unknown result type (might be due to invalid IL or missing references)
			//IL_0085: Unknown result type (might be due to invalid IL or missing references)
			//IL_0096: Expected O, but got Unknown
			//IL_0097: Expected O, but got Unknown
			//IL_00b1: Unknown result type (might be due to invalid IL or missing references)
			//IL_00b6: Unknown result type (might be due to invalid IL or missing references)
			//IL_00c7: Expected O, but got Unknown
			//IL_00d1: Unknown result type (might be due to invalid IL or missing references)
			//IL_00d6: Unknown result type (might be due to invalid IL or missing references)
			//IL_00e1: Expected O, but got Unknown
			//IL_00e2: Expected O, but got Unknown
			//IL_00f0: Unknown result type (might be due to invalid IL or missing references)
			//IL_00f5: Unknown result type (might be due to invalid IL or missing references)
			//IL_0106: Expected O, but got Unknown
			//IL_0107: Expected O, but got Unknown
			//IL_0114: Unknown result type (might be due to invalid IL or missing references)
			//IL_0119: Unknown result type (might be due to invalid IL or missing references)
			//IL_0125: Expected O, but got Unknown
			//IL_0126: Expected O, but got Unknown
			//IL_0130: Unknown result type (might be due to invalid IL or missing references)
			//IL_0135: Unknown result type (might be due to invalid IL or missing references)
			//IL_0146: Expected O, but got Unknown
			//IL_0147: Expected O, but got Unknown
			//IL_0155: Unknown result type (might be due to invalid IL or missing references)
			//IL_015a: Unknown result type (might be due to invalid IL or missing references)
			//IL_016b: Expected O, but got Unknown
			//IL_016c: Expected O, but got Unknown
			//IL_0177: Unknown result type (might be due to invalid IL or missing references)
			//IL_017c: Unknown result type (might be due to invalid IL or missing references)
			//IL_018d: Expected O, but got Unknown
			//IL_018e: Expected O, but got Unknown
			//IL_01a4: Unknown result type (might be due to invalid IL or missing references)
			//IL_01a9: Unknown result type (might be due to invalid IL or missing references)
			//IL_01b5: Expected O, but got Unknown
			//IL_01c2: Unknown result type (might be due to invalid IL or missing references)
			//IL_01c7: Unknown result type (might be due to invalid IL or missing references)
			//IL_01d2: Expected O, but got Unknown
			//IL_01d3: Expected O, but got Unknown
			//IL_01ee: Unknown result type (might be due to invalid IL or missing references)
			//IL_01f3: Unknown result type (might be due to invalid IL or missing references)
			//IL_0204: Expected O, but got Unknown
			//IL_020e: Unknown result type (might be due to invalid IL or missing references)
			//IL_0213: Unknown result type (might be due to invalid IL or missing references)
			//IL_021e: Expected O, but got Unknown
			//IL_021f: Expected O, but got Unknown
			//IL_0236: Unknown result type (might be due to invalid IL or missing references)
			//IL_023b: Unknown result type (might be due to invalid IL or missing references)
			//IL_0247: Expected O, but got Unknown
			//IL_0255: Unknown result type (might be due to invalid IL or missing references)
			//IL_025a: Unknown result type (might be due to invalid IL or missing references)
			//IL_0265: Expected O, but got Unknown
			//IL_0266: Expected O, but got Unknown
			//IL_027d: Unknown result type (might be due to invalid IL or missing references)
			//IL_0282: Unknown result type (might be due to invalid IL or missing references)
			//IL_028e: Expected O, but got Unknown
			//IL_029c: Unknown result type (might be due to invalid IL or missing references)
			//IL_02a1: Unknown result type (might be due to invalid IL or missing references)
			//IL_02ac: Expected O, but got Unknown
			//IL_02ad: Expected O, but got Unknown
			//IL_02c8: Unknown result type (might be due to invalid IL or missing references)
			//IL_02cd: Unknown result type (might be due to invalid IL or missing references)
			//IL_02de: Expected O, but got Unknown
			//IL_02e8: Unknown result type (might be due to invalid IL or missing references)
			//IL_02ed: Unknown result type (might be due to invalid IL or missing references)
			//IL_02f8: Expected O, but got Unknown
			//IL_02f9: Expected O, but got Unknown
			//IL_0314: Unknown result type (might be due to invalid IL or missing references)
			//IL_0319: Unknown result type (might be due to invalid IL or missing references)
			//IL_032a: Expected O, but got Unknown
			//IL_0334: Unknown result type (might be due to invalid IL or missing references)
			//IL_0339: Unknown result type (might be due to invalid IL or missing references)
			//IL_0344: Expected O, but got Unknown
			//IL_0345: Expected O, but got Unknown
			//IL_035b: Unknown result type (might be due to invalid IL or missing references)
			//IL_0360: Unknown result type (might be due to invalid IL or missing references)
			//IL_036c: Expected O, but got Unknown
			//IL_0379: Unknown result type (might be due to invalid IL or missing references)
			//IL_037e: Unknown result type (might be due to invalid IL or missing references)
			//IL_0389: Expected O, but got Unknown
			//IL_038a: Expected O, but got Unknown
			//IL_03a0: Unknown result type (might be due to invalid IL or missing references)
			//IL_03a5: Unknown result type (might be due to invalid IL or missing references)
			//IL_03b1: Expected O, but got Unknown
			//IL_03be: Unknown result type (might be due to invalid IL or missing references)
			//IL_03c3: Unknown result type (might be due to invalid IL or missing references)
			//IL_03ce: Expected O, but got Unknown
			//IL_03cf: Expected O, but got Unknown
			//IL_03e5: Unknown result type (might be due to invalid IL or missing references)
			//IL_03ea: Unknown result type (might be due to invalid IL or missing references)
			//IL_03f6: Expected O, but got Unknown
			//IL_0403: Unknown result type (might be due to invalid IL or missing references)
			//IL_0408: Unknown result type (might be due to invalid IL or missing references)
			//IL_0413: Expected O, but got Unknown
			//IL_0414: Expected O, but got Unknown
			//IL_042a: Unknown result type (might be due to invalid IL or missing references)
			//IL_042f: Unknown result type (might be due to invalid IL or missing references)
			//IL_043b: Expected O, but got Unknown
			//IL_0448: Unknown result type (might be due to invalid IL or missing references)
			//IL_044d: Unknown result type (might be due to invalid IL or missing references)
			//IL_0458: Expected O, but got Unknown
			//IL_0459: Expected O, but got Unknown
			//IL_0473: Unknown result type (might be due to invalid IL or missing references)
			//IL_0478: Unknown result type (might be due to invalid IL or missing references)
			//IL_0484: Expected O, but got Unknown
			//IL_0495: Unknown result type (might be due to invalid IL or missing references)
			//IL_049a: Unknown result type (might be due to invalid IL or missing references)
			//IL_04a5: Expected O, but got Unknown
			//IL_04a6: Expected O, but got Unknown
			//IL_04bc: Unknown result type (might be due to invalid IL or missing references)
			//IL_04c1: Unknown result type (might be due to invalid IL or missing references)
			//IL_04cd: Expected O, but got Unknown
			//IL_04da: Unknown result type (might be due to invalid IL or missing references)
			//IL_04df: Unknown result type (might be due to invalid IL or missing references)
			//IL_04ea: Expected O, but got Unknown
			//IL_04eb: Expected O, but got Unknown
			//IL_0505: Unknown result type (might be due to invalid IL or missing references)
			//IL_050a: Unknown result type (might be due to invalid IL or missing references)
			//IL_0516: Expected O, but got Unknown
			//IL_0527: Unknown result type (might be due to invalid IL or missing references)
			//IL_052c: Unknown result type (might be due to invalid IL or missing references)
			//IL_0537: Expected O, but got Unknown
			//IL_0538: Expected O, but got Unknown
			//IL_0552: Unknown result type (might be due to invalid IL or missing references)
			//IL_0557: Unknown result type (might be due to invalid IL or missing references)
			//IL_0563: Expected O, but got Unknown
			//IL_0574: Unknown result type (might be due to invalid IL or missing references)
			//IL_0579: Unknown result type (might be due to invalid IL or missing references)
			//IL_0584: Expected O, but got Unknown
			//IL_0585: Expected O, but got Unknown
			string sql = "INSERT INTO programbuilder\r\n\t\t\t\t(ID,Name,Type,CreateTime,PublishTime,CreateUser,`SQL`,IsAdd,DBConnID,Status,FormID,EditModel,Width,Height,ButtonLocation,IsPager,ClientScript,ExportTemplate,ExportHeaderText,ExportFileName,TableStyle,TableHead,`TableName`,InDataNumberFiledName) \r\n\t\t\t\tVALUES(@ID,@Name,@Type,@CreateTime,@PublishTime,@CreateUser,@SQL,@IsAdd,@DBConnID,@Status,@FormID,@EditModel,@Width,@Height,@ButtonLocation,@IsPager,@ClientScript,@ExportTemplate,@ExportHeaderText,@ExportFileName,@TableStyle,@TableHead,@TableName,@InDataNumberFiledName)";
			MySqlParameter[] obj = new MySqlParameter[24];
			MySqlParameter val = new MySqlParameter("@ID", 253, 36);
			((DbParameter)val).Value = model.ID;
			obj[0] = val;
			MySqlParameter val2 = new MySqlParameter("@Name", 752, -1);
			((DbParameter)val2).Value = model.Name;
			obj[1] = val2;
			MySqlParameter val3 = new MySqlParameter("@Type", 253, 36);
			((DbParameter)val3).Value = model.Type;
			obj[2] = val3;
			MySqlParameter val4 = new MySqlParameter("@CreateTime", 12, -1);
			((DbParameter)val4).Value = model.CreateTime;
			obj[3] = val4;
			_003F val5;
			if (model.PublishTime.HasValue)
			{
				val5 = new MySqlParameter("@PublishTime", 12, -1);
				((DbParameter)val5).Value = model.PublishTime;
			}
			else
			{
				val5 = new MySqlParameter("@PublishTime", 12, -1);
				((DbParameter)val5).Value = DBNull.Value;
			}
			obj[4] = val5;
			MySqlParameter val6 = new MySqlParameter("@CreateUser", 253, 36);
			((DbParameter)val6).Value = model.CreateUser;
			obj[5] = val6;
			MySqlParameter val7 = new MySqlParameter("@SQL", 751, -1);
			((DbParameter)val7).Value = model.SQL;
			obj[6] = val7;
			MySqlParameter val8 = new MySqlParameter("@IsAdd", 3, 11);
			((DbParameter)val8).Value = model.IsAdd;
			obj[7] = val8;
			MySqlParameter val9 = new MySqlParameter("@DBConnID", 253, 36);
			((DbParameter)val9).Value = model.DBConnID;
			obj[8] = val9;
			MySqlParameter val10 = new MySqlParameter("@Status", 3, 11);
			((DbParameter)val10).Value = model.Status;
			obj[9] = val10;
			_003F val11;
			if (model.FormID != null)
			{
				val11 = new MySqlParameter("@FormID", 752, -1);
				((DbParameter)val11).Value = model.FormID;
			}
			else
			{
				val11 = new MySqlParameter("@FormID", 752, -1);
				((DbParameter)val11).Value = DBNull.Value;
			}
			obj[10] = val11;
			_003F val12;
			if (model.EditModel.HasValue)
			{
				val12 = new MySqlParameter("@EditModel", 3, 11);
				((DbParameter)val12).Value = model.EditModel;
			}
			else
			{
				val12 = new MySqlParameter("@EditModel", 3, 11);
				((DbParameter)val12).Value = DBNull.Value;
			}
			obj[11] = val12;
			_003F val13;
			if (model.Width != null)
			{
				val13 = new MySqlParameter("@Width", 253, 50);
				((DbParameter)val13).Value = model.Width;
			}
			else
			{
				val13 = new MySqlParameter("@Width", 253, 50);
				((DbParameter)val13).Value = DBNull.Value;
			}
			obj[12] = val13;
			_003F val14;
			if (model.Height != null)
			{
				val14 = new MySqlParameter("@Height", 253, 50);
				((DbParameter)val14).Value = model.Height;
			}
			else
			{
				val14 = new MySqlParameter("@Height", 253, 50);
				((DbParameter)val14).Value = DBNull.Value;
			}
			obj[13] = val14;
			_003F val15;
			if (model.ButtonLocation.HasValue)
			{
				val15 = new MySqlParameter("@ButtonLocation", 3, 11);
				((DbParameter)val15).Value = model.ButtonLocation;
			}
			else
			{
				val15 = new MySqlParameter("@ButtonLocation", 3, 11);
				((DbParameter)val15).Value = DBNull.Value;
			}
			obj[14] = val15;
			_003F val16;
			if (model.IsPager.HasValue)
			{
				val16 = new MySqlParameter("@IsPager", 3, 11);
				((DbParameter)val16).Value = model.IsPager;
			}
			else
			{
				val16 = new MySqlParameter("@IsPager", 3, 11);
				((DbParameter)val16).Value = DBNull.Value;
			}
			obj[15] = val16;
			_003F val17;
			if (model.ClientScript != null)
			{
				val17 = new MySqlParameter("@ClientScript", 751, -1);
				((DbParameter)val17).Value = model.ClientScript;
			}
			else
			{
				val17 = new MySqlParameter("@ClientScript", 751, -1);
				((DbParameter)val17).Value = DBNull.Value;
			}
			obj[16] = val17;
			_003F val18;
			if (model.ExportTemplate != null)
			{
				val18 = new MySqlParameter("@ExportTemplate", 752, -1);
				((DbParameter)val18).Value = model.ExportTemplate;
			}
			else
			{
				val18 = new MySqlParameter("@ExportTemplate", 752, -1);
				((DbParameter)val18).Value = DBNull.Value;
			}
			obj[17] = val18;
			_003F val19;
			if (model.ExportHeaderText != null)
			{
				val19 = new MySqlParameter("@ExportHeaderText", 752, -1);
				((DbParameter)val19).Value = model.ExportHeaderText;
			}
			else
			{
				val19 = new MySqlParameter("@ExportHeaderText", 752, -1);
				((DbParameter)val19).Value = DBNull.Value;
			}
			obj[18] = val19;
			_003F val20;
			if (model.ExportFileName != null)
			{
				val20 = new MySqlParameter("@ExportFileName", 752, -1);
				((DbParameter)val20).Value = model.ExportFileName;
			}
			else
			{
				val20 = new MySqlParameter("@ExportFileName", 752, -1);
				((DbParameter)val20).Value = DBNull.Value;
			}
			obj[19] = val20;
			_003F val21;
			if (model.TableStyle != null)
			{
				val21 = new MySqlParameter("@TableStyle", 253, 255);
				((DbParameter)val21).Value = model.TableStyle;
			}
			else
			{
				val21 = new MySqlParameter("@TableStyle", 253, 255);
				((DbParameter)val21).Value = DBNull.Value;
			}
			obj[20] = val21;
			_003F val22;
			if (model.TableHead != null)
			{
				val22 = new MySqlParameter("@TableHead", 752, -1);
				((DbParameter)val22).Value = model.TableHead;
			}
			else
			{
				val22 = new MySqlParameter("@TableHead", 752, -1);
				((DbParameter)val22).Value = DBNull.Value;
			}
			obj[21] = val22;
			_003F val23;
			if (model.TableName != null)
			{
				val23 = new MySqlParameter("@TableName", 253, 255);
				((DbParameter)val23).Value = model.TableName;
			}
			else
			{
				val23 = new MySqlParameter("@TableName", 253, 255);
				((DbParameter)val23).Value = DBNull.Value;
			}
			obj[22] = val23;
			_003F val24;
			if (model.InDataNumberFiledName != null)
			{
				val24 = new MySqlParameter("@InDataNumberFiledName", 253, 255);
				((DbParameter)val24).Value = model.InDataNumberFiledName;
			}
			else
			{
				val24 = new MySqlParameter("@InDataNumberFiledName", 253, 255);
				((DbParameter)val24).Value = DBNull.Value;
			}
			obj[23] = val24;
			MySqlParameter[] parameter = (MySqlParameter[])obj;
			return dbHelper.Execute(sql, parameter);
		}

		public int Update(RoadFlow.Data.Model.ProgramBuilder model)
		{
			//IL_001a: Unknown result type (might be due to invalid IL or missing references)
			//IL_001f: Unknown result type (might be due to invalid IL or missing references)
			//IL_002b: Expected O, but got Unknown
			//IL_002c: Expected O, but got Unknown
			//IL_003a: Unknown result type (might be due to invalid IL or missing references)
			//IL_003f: Unknown result type (might be due to invalid IL or missing references)
			//IL_0050: Expected O, but got Unknown
			//IL_0051: Expected O, but got Unknown
			//IL_005b: Unknown result type (might be due to invalid IL or missing references)
			//IL_0060: Unknown result type (might be due to invalid IL or missing references)
			//IL_0071: Expected O, but got Unknown
			//IL_0072: Expected O, but got Unknown
			//IL_008c: Unknown result type (might be due to invalid IL or missing references)
			//IL_0091: Unknown result type (might be due to invalid IL or missing references)
			//IL_00a2: Expected O, but got Unknown
			//IL_00ac: Unknown result type (might be due to invalid IL or missing references)
			//IL_00b1: Unknown result type (might be due to invalid IL or missing references)
			//IL_00bc: Expected O, but got Unknown
			//IL_00bd: Expected O, but got Unknown
			//IL_00cb: Unknown result type (might be due to invalid IL or missing references)
			//IL_00d0: Unknown result type (might be due to invalid IL or missing references)
			//IL_00e1: Expected O, but got Unknown
			//IL_00e2: Expected O, but got Unknown
			//IL_00ef: Unknown result type (might be due to invalid IL or missing references)
			//IL_00f4: Unknown result type (might be due to invalid IL or missing references)
			//IL_0100: Expected O, but got Unknown
			//IL_0101: Expected O, but got Unknown
			//IL_010b: Unknown result type (might be due to invalid IL or missing references)
			//IL_0110: Unknown result type (might be due to invalid IL or missing references)
			//IL_0121: Expected O, but got Unknown
			//IL_0122: Expected O, but got Unknown
			//IL_0130: Unknown result type (might be due to invalid IL or missing references)
			//IL_0135: Unknown result type (might be due to invalid IL or missing references)
			//IL_0146: Expected O, but got Unknown
			//IL_0147: Expected O, but got Unknown
			//IL_0151: Unknown result type (might be due to invalid IL or missing references)
			//IL_0156: Unknown result type (might be due to invalid IL or missing references)
			//IL_0167: Expected O, but got Unknown
			//IL_0168: Expected O, but got Unknown
			//IL_017e: Unknown result type (might be due to invalid IL or missing references)
			//IL_0183: Unknown result type (might be due to invalid IL or missing references)
			//IL_018f: Expected O, but got Unknown
			//IL_019c: Unknown result type (might be due to invalid IL or missing references)
			//IL_01a1: Unknown result type (might be due to invalid IL or missing references)
			//IL_01ac: Expected O, but got Unknown
			//IL_01ad: Expected O, but got Unknown
			//IL_01c8: Unknown result type (might be due to invalid IL or missing references)
			//IL_01cd: Unknown result type (might be due to invalid IL or missing references)
			//IL_01de: Expected O, but got Unknown
			//IL_01e8: Unknown result type (might be due to invalid IL or missing references)
			//IL_01ed: Unknown result type (might be due to invalid IL or missing references)
			//IL_01f8: Expected O, but got Unknown
			//IL_01f9: Expected O, but got Unknown
			//IL_0210: Unknown result type (might be due to invalid IL or missing references)
			//IL_0215: Unknown result type (might be due to invalid IL or missing references)
			//IL_0221: Expected O, but got Unknown
			//IL_022f: Unknown result type (might be due to invalid IL or missing references)
			//IL_0234: Unknown result type (might be due to invalid IL or missing references)
			//IL_023f: Expected O, but got Unknown
			//IL_0240: Expected O, but got Unknown
			//IL_0257: Unknown result type (might be due to invalid IL or missing references)
			//IL_025c: Unknown result type (might be due to invalid IL or missing references)
			//IL_0268: Expected O, but got Unknown
			//IL_0276: Unknown result type (might be due to invalid IL or missing references)
			//IL_027b: Unknown result type (might be due to invalid IL or missing references)
			//IL_0286: Expected O, but got Unknown
			//IL_0287: Expected O, but got Unknown
			//IL_02a2: Unknown result type (might be due to invalid IL or missing references)
			//IL_02a7: Unknown result type (might be due to invalid IL or missing references)
			//IL_02b8: Expected O, but got Unknown
			//IL_02c2: Unknown result type (might be due to invalid IL or missing references)
			//IL_02c7: Unknown result type (might be due to invalid IL or missing references)
			//IL_02d2: Expected O, but got Unknown
			//IL_02d3: Expected O, but got Unknown
			//IL_02ee: Unknown result type (might be due to invalid IL or missing references)
			//IL_02f3: Unknown result type (might be due to invalid IL or missing references)
			//IL_0304: Expected O, but got Unknown
			//IL_030e: Unknown result type (might be due to invalid IL or missing references)
			//IL_0313: Unknown result type (might be due to invalid IL or missing references)
			//IL_031e: Expected O, but got Unknown
			//IL_031f: Expected O, but got Unknown
			//IL_0335: Unknown result type (might be due to invalid IL or missing references)
			//IL_033a: Unknown result type (might be due to invalid IL or missing references)
			//IL_0346: Expected O, but got Unknown
			//IL_0353: Unknown result type (might be due to invalid IL or missing references)
			//IL_0358: Unknown result type (might be due to invalid IL or missing references)
			//IL_0363: Expected O, but got Unknown
			//IL_0364: Expected O, but got Unknown
			//IL_037a: Unknown result type (might be due to invalid IL or missing references)
			//IL_037f: Unknown result type (might be due to invalid IL or missing references)
			//IL_038b: Expected O, but got Unknown
			//IL_0398: Unknown result type (might be due to invalid IL or missing references)
			//IL_039d: Unknown result type (might be due to invalid IL or missing references)
			//IL_03a8: Expected O, but got Unknown
			//IL_03a9: Expected O, but got Unknown
			//IL_03bf: Unknown result type (might be due to invalid IL or missing references)
			//IL_03c4: Unknown result type (might be due to invalid IL or missing references)
			//IL_03d0: Expected O, but got Unknown
			//IL_03dd: Unknown result type (might be due to invalid IL or missing references)
			//IL_03e2: Unknown result type (might be due to invalid IL or missing references)
			//IL_03ed: Expected O, but got Unknown
			//IL_03ee: Expected O, but got Unknown
			//IL_0404: Unknown result type (might be due to invalid IL or missing references)
			//IL_0409: Unknown result type (might be due to invalid IL or missing references)
			//IL_0415: Expected O, but got Unknown
			//IL_0422: Unknown result type (might be due to invalid IL or missing references)
			//IL_0427: Unknown result type (might be due to invalid IL or missing references)
			//IL_0432: Expected O, but got Unknown
			//IL_0433: Expected O, but got Unknown
			//IL_044d: Unknown result type (might be due to invalid IL or missing references)
			//IL_0452: Unknown result type (might be due to invalid IL or missing references)
			//IL_045e: Expected O, but got Unknown
			//IL_046f: Unknown result type (might be due to invalid IL or missing references)
			//IL_0474: Unknown result type (might be due to invalid IL or missing references)
			//IL_047f: Expected O, but got Unknown
			//IL_0480: Expected O, but got Unknown
			//IL_0496: Unknown result type (might be due to invalid IL or missing references)
			//IL_049b: Unknown result type (might be due to invalid IL or missing references)
			//IL_04a7: Expected O, but got Unknown
			//IL_04b4: Unknown result type (might be due to invalid IL or missing references)
			//IL_04b9: Unknown result type (might be due to invalid IL or missing references)
			//IL_04c4: Expected O, but got Unknown
			//IL_04c5: Expected O, but got Unknown
			//IL_04df: Unknown result type (might be due to invalid IL or missing references)
			//IL_04e4: Unknown result type (might be due to invalid IL or missing references)
			//IL_04f0: Expected O, but got Unknown
			//IL_0501: Unknown result type (might be due to invalid IL or missing references)
			//IL_0506: Unknown result type (might be due to invalid IL or missing references)
			//IL_0511: Expected O, but got Unknown
			//IL_0512: Expected O, but got Unknown
			//IL_052c: Unknown result type (might be due to invalid IL or missing references)
			//IL_0531: Unknown result type (might be due to invalid IL or missing references)
			//IL_053d: Expected O, but got Unknown
			//IL_054e: Unknown result type (might be due to invalid IL or missing references)
			//IL_0553: Unknown result type (might be due to invalid IL or missing references)
			//IL_055e: Expected O, but got Unknown
			//IL_055f: Expected O, but got Unknown
			//IL_056e: Unknown result type (might be due to invalid IL or missing references)
			//IL_0573: Unknown result type (might be due to invalid IL or missing references)
			//IL_0584: Expected O, but got Unknown
			//IL_0585: Expected O, but got Unknown
			string sql = "UPDATE programbuilder SET \r\n\t\t\t\tName=@Name,Type=@Type,CreateTime=@CreateTime,PublishTime=@PublishTime,CreateUser=@CreateUser,`SQL`=@SQL,IsAdd=@IsAdd,DBConnID=@DBConnID,Status=@Status,FormID=@FormID,EditModel=@EditModel,Width=@Width,Height=@Height,ButtonLocation=@ButtonLocation,IsPager=@IsPager,ClientScript=@ClientScript,ExportTemplate=@ExportTemplate,ExportHeaderText=@ExportHeaderText,ExportFileName=@ExportFileName,TableStyle=@TableStyle,TableHead=@TableHead,TableName=@TableName,InDataNumberFiledName=@InDataNumberFiledName    \r\n\t\t\t\tWHERE ID=@ID";
			MySqlParameter[] obj = new MySqlParameter[24];
			MySqlParameter val = new MySqlParameter("@Name", 752, -1);
			((DbParameter)val).Value = model.Name;
			obj[0] = val;
			MySqlParameter val2 = new MySqlParameter("@Type", 253, 36);
			((DbParameter)val2).Value = model.Type;
			obj[1] = val2;
			MySqlParameter val3 = new MySqlParameter("@CreateTime", 12, -1);
			((DbParameter)val3).Value = model.CreateTime;
			obj[2] = val3;
			_003F val4;
			if (model.PublishTime.HasValue)
			{
				val4 = new MySqlParameter("@PublishTime", 12, -1);
				((DbParameter)val4).Value = model.PublishTime;
			}
			else
			{
				val4 = new MySqlParameter("@PublishTime", 12, -1);
				((DbParameter)val4).Value = DBNull.Value;
			}
			obj[3] = val4;
			MySqlParameter val5 = new MySqlParameter("@CreateUser", 253, 36);
			((DbParameter)val5).Value = model.CreateUser;
			obj[4] = val5;
			MySqlParameter val6 = new MySqlParameter("@SQL", 751, -1);
			((DbParameter)val6).Value = model.SQL;
			obj[5] = val6;
			MySqlParameter val7 = new MySqlParameter("@IsAdd", 3, 11);
			((DbParameter)val7).Value = model.IsAdd;
			obj[6] = val7;
			MySqlParameter val8 = new MySqlParameter("@DBConnID", 253, 36);
			((DbParameter)val8).Value = model.DBConnID;
			obj[7] = val8;
			MySqlParameter val9 = new MySqlParameter("@Status", 3, 11);
			((DbParameter)val9).Value = model.Status;
			obj[8] = val9;
			_003F val10;
			if (model.FormID != null)
			{
				val10 = new MySqlParameter("@FormID", 752, -1);
				((DbParameter)val10).Value = model.FormID;
			}
			else
			{
				val10 = new MySqlParameter("@FormID", 752, -1);
				((DbParameter)val10).Value = DBNull.Value;
			}
			obj[9] = val10;
			_003F val11;
			if (model.EditModel.HasValue)
			{
				val11 = new MySqlParameter("@EditModel", 3, 11);
				((DbParameter)val11).Value = model.EditModel;
			}
			else
			{
				val11 = new MySqlParameter("@EditModel", 3, 11);
				((DbParameter)val11).Value = DBNull.Value;
			}
			obj[10] = val11;
			_003F val12;
			if (model.Width != null)
			{
				val12 = new MySqlParameter("@Width", 253, 50);
				((DbParameter)val12).Value = model.Width;
			}
			else
			{
				val12 = new MySqlParameter("@Width", 253, 50);
				((DbParameter)val12).Value = DBNull.Value;
			}
			obj[11] = val12;
			_003F val13;
			if (model.Height != null)
			{
				val13 = new MySqlParameter("@Height", 253, 50);
				((DbParameter)val13).Value = model.Height;
			}
			else
			{
				val13 = new MySqlParameter("@Height", 253, 50);
				((DbParameter)val13).Value = DBNull.Value;
			}
			obj[12] = val13;
			_003F val14;
			if (model.ButtonLocation.HasValue)
			{
				val14 = new MySqlParameter("@ButtonLocation", 3, 11);
				((DbParameter)val14).Value = model.ButtonLocation;
			}
			else
			{
				val14 = new MySqlParameter("@ButtonLocation", 3, 11);
				((DbParameter)val14).Value = DBNull.Value;
			}
			obj[13] = val14;
			_003F val15;
			if (model.IsPager.HasValue)
			{
				val15 = new MySqlParameter("@IsPager", 3, 11);
				((DbParameter)val15).Value = model.IsPager;
			}
			else
			{
				val15 = new MySqlParameter("@IsPager", 3, 11);
				((DbParameter)val15).Value = DBNull.Value;
			}
			obj[14] = val15;
			_003F val16;
			if (model.ClientScript != null)
			{
				val16 = new MySqlParameter("@ClientScript", 751, -1);
				((DbParameter)val16).Value = model.ClientScript;
			}
			else
			{
				val16 = new MySqlParameter("@ClientScript", 751, -1);
				((DbParameter)val16).Value = DBNull.Value;
			}
			obj[15] = val16;
			_003F val17;
			if (model.ExportTemplate != null)
			{
				val17 = new MySqlParameter("@ExportTemplate", 752, -1);
				((DbParameter)val17).Value = model.ExportTemplate;
			}
			else
			{
				val17 = new MySqlParameter("@ExportTemplate", 752, -1);
				((DbParameter)val17).Value = DBNull.Value;
			}
			obj[16] = val17;
			_003F val18;
			if (model.ExportHeaderText != null)
			{
				val18 = new MySqlParameter("@ExportHeaderText", 752, -1);
				((DbParameter)val18).Value = model.ExportHeaderText;
			}
			else
			{
				val18 = new MySqlParameter("@ExportHeaderText", 752, -1);
				((DbParameter)val18).Value = DBNull.Value;
			}
			obj[17] = val18;
			_003F val19;
			if (model.ExportFileName != null)
			{
				val19 = new MySqlParameter("@ExportFileName", 752, -1);
				((DbParameter)val19).Value = model.ExportFileName;
			}
			else
			{
				val19 = new MySqlParameter("@ExportFileName", 752, -1);
				((DbParameter)val19).Value = DBNull.Value;
			}
			obj[18] = val19;
			_003F val20;
			if (model.TableStyle != null)
			{
				val20 = new MySqlParameter("@TableStyle", 253, 255);
				((DbParameter)val20).Value = model.TableStyle;
			}
			else
			{
				val20 = new MySqlParameter("@TableStyle", 253, 255);
				((DbParameter)val20).Value = DBNull.Value;
			}
			obj[19] = val20;
			_003F val21;
			if (model.TableHead != null)
			{
				val21 = new MySqlParameter("@TableHead", 752, -1);
				((DbParameter)val21).Value = model.TableHead;
			}
			else
			{
				val21 = new MySqlParameter("@TableHead", 752, -1);
				((DbParameter)val21).Value = DBNull.Value;
			}
			obj[20] = val21;
			_003F val22;
			if (model.TableName != null)
			{
				val22 = new MySqlParameter("@TableName", 253, 255);
				((DbParameter)val22).Value = model.TableName;
			}
			else
			{
				val22 = new MySqlParameter("@TableName", 253, 255);
				((DbParameter)val22).Value = DBNull.Value;
			}
			obj[21] = val22;
			_003F val23;
			if (model.InDataNumberFiledName != null)
			{
				val23 = new MySqlParameter("@InDataNumberFiledName", 253, 255);
				((DbParameter)val23).Value = model.InDataNumberFiledName;
			}
			else
			{
				val23 = new MySqlParameter("@InDataNumberFiledName", 253, 255);
				((DbParameter)val23).Value = DBNull.Value;
			}
			obj[22] = val23;
			MySqlParameter val24 = new MySqlParameter("@ID", 253, 36);
			((DbParameter)val24).Value = model.ID;
			obj[23] = val24;
			MySqlParameter[] parameter = (MySqlParameter[])obj;
			return dbHelper.Execute(sql, parameter);
		}

		public int Delete(Guid id)
		{
			//IL_001a: Unknown result type (might be due to invalid IL or missing references)
			//IL_001f: Unknown result type (might be due to invalid IL or missing references)
			//IL_0032: Expected O, but got Unknown
			//IL_0033: Expected O, but got Unknown
			string sql = "DELETE FROM programbuilder WHERE ID=@ID";
			MySqlParameter[] obj = new MySqlParameter[1];
			MySqlParameter val = new MySqlParameter("@ID", 253, 36);
			((DbParameter)val).Value = id.ToString();
			obj[0] = val;
			MySqlParameter[] parameter = (MySqlParameter[])obj;
			return dbHelper.Execute(sql, parameter);
		}

		private List<RoadFlow.Data.Model.ProgramBuilder> DataReaderToList(MySqlDataReader dataReader)
		{
			List<RoadFlow.Data.Model.ProgramBuilder> list = new List<RoadFlow.Data.Model.ProgramBuilder>();
			RoadFlow.Data.Model.ProgramBuilder programBuilder = null;
			while (((DbDataReader)dataReader).Read())
			{
				programBuilder = new RoadFlow.Data.Model.ProgramBuilder();
				programBuilder.ID = ((DbDataReader)dataReader).GetString(0).ToGuid();
				programBuilder.Name = ((DbDataReader)dataReader).GetString(1);
				programBuilder.Type = ((DbDataReader)dataReader).GetString(2).ToGuid();
				programBuilder.CreateTime = ((DbDataReader)dataReader).GetDateTime(3);
				if (!((DbDataReader)dataReader).IsDBNull(4))
				{
					programBuilder.PublishTime = ((DbDataReader)dataReader).GetDateTime(4);
				}
				programBuilder.CreateUser = ((DbDataReader)dataReader).GetString(5).ToGuid();
				programBuilder.SQL = ((DbDataReader)dataReader).GetString(6);
				programBuilder.IsAdd = ((DbDataReader)dataReader).GetInt32(7);
				programBuilder.DBConnID = ((DbDataReader)dataReader).GetString(8).ToGuid();
				programBuilder.Status = ((DbDataReader)dataReader).GetInt32(9);
				if (!((DbDataReader)dataReader).IsDBNull(10))
				{
					programBuilder.FormID = ((DbDataReader)dataReader).GetString(10);
				}
				if (!((DbDataReader)dataReader).IsDBNull(11))
				{
					programBuilder.EditModel = ((DbDataReader)dataReader).GetInt32(11);
				}
				if (!((DbDataReader)dataReader).IsDBNull(12))
				{
					programBuilder.Width = ((DbDataReader)dataReader).GetString(12);
				}
				if (!((DbDataReader)dataReader).IsDBNull(13))
				{
					programBuilder.Height = ((DbDataReader)dataReader).GetString(13);
				}
				if (!((DbDataReader)dataReader).IsDBNull(14))
				{
					programBuilder.ButtonLocation = ((DbDataReader)dataReader).GetInt32(14);
				}
				if (!((DbDataReader)dataReader).IsDBNull(15))
				{
					programBuilder.IsPager = ((DbDataReader)dataReader).GetInt32(15);
				}
				if (!((DbDataReader)dataReader).IsDBNull(16))
				{
					programBuilder.ClientScript = ((DbDataReader)dataReader).GetString(16);
				}
				if (!((DbDataReader)dataReader).IsDBNull(17))
				{
					programBuilder.ExportTemplate = ((DbDataReader)dataReader).GetString(17);
				}
				if (!((DbDataReader)dataReader).IsDBNull(18))
				{
					programBuilder.ExportHeaderText = ((DbDataReader)dataReader).GetString(18);
				}
				if (!((DbDataReader)dataReader).IsDBNull(19))
				{
					programBuilder.ExportFileName = ((DbDataReader)dataReader).GetString(19);
				}
				if (!((DbDataReader)dataReader).IsDBNull(20))
				{
					programBuilder.TableStyle = ((DbDataReader)dataReader).GetString(20);
				}
				if (!((DbDataReader)dataReader).IsDBNull(21))
				{
					programBuilder.TableHead = ((DbDataReader)dataReader).GetString(21);
				}
				if (!((DbDataReader)dataReader).IsDBNull(22))
				{
					programBuilder.TableName = ((DbDataReader)dataReader).GetString(22);
				}
				if (!((DbDataReader)dataReader).IsDBNull(23))
				{
					programBuilder.InDataNumberFiledName = ((DbDataReader)dataReader).GetString(23);
				}
				list.Add(programBuilder);
			}
			return list;
		}

		public List<RoadFlow.Data.Model.ProgramBuilder> GetAll()
		{
			string sql = "SELECT * FROM programbuilder";
			MySqlDataReader dataReader = dbHelper.GetDataReader(sql);
			List<RoadFlow.Data.Model.ProgramBuilder> result = DataReaderToList(dataReader);
			((DbDataReader)dataReader).Close();
			return result;
		}

		public long GetCount()
		{
			string sql = "SELECT COUNT(*) FROM programbuilder";
			long result;
			if (!long.TryParse(dbHelper.GetFieldValue(sql), out result))
			{
				return 0L;
			}
			return result;
		}

		public RoadFlow.Data.Model.ProgramBuilder Get(Guid id)
		{
			//IL_001a: Unknown result type (might be due to invalid IL or missing references)
			//IL_001f: Unknown result type (might be due to invalid IL or missing references)
			//IL_0032: Expected O, but got Unknown
			//IL_0033: Expected O, but got Unknown
			string sql = "SELECT * FROM programbuilder WHERE ID=@ID";
			MySqlParameter[] obj = new MySqlParameter[1];
			MySqlParameter val = new MySqlParameter("@ID", 253, 36);
			((DbParameter)val).Value = id.ToString();
			obj[0] = val;
			MySqlParameter[] parameter = (MySqlParameter[])obj;
			MySqlDataReader dataReader = dbHelper.GetDataReader(sql, parameter);
			List<RoadFlow.Data.Model.ProgramBuilder> list = DataReaderToList(dataReader);
			((DbDataReader)dataReader).Close();
			if (list.Count <= 0)
			{
				return null;
			}
			return list[0];
		}

		public List<RoadFlow.Data.Model.ProgramBuilder> GetList(out string pager, string query = "", string name = "", string typeid = "")
		{
			//IL_002c: Unknown result type (might be due to invalid IL or missing references)
			//IL_0036: Expected O, but got Unknown
			List<MySqlParameter> list = new List<MySqlParameter>();
			StringBuilder stringBuilder = new StringBuilder("SELECT * FROM ProgramBuilder WHERE Status<>2 ");
			if (!name.IsNullOrEmpty())
			{
				stringBuilder.Append(" AND INSTR(Name,@Name)>0");
				list.Add(new MySqlParameter("@Name", (object)name));
			}
			if (!typeid.IsNullOrEmpty())
			{
				stringBuilder.Append(" AND Type IN(" + Tools.GetSqlInString(typeid) + ")");
			}
			stringBuilder.Append(" ORDER BY CreateTime DESC");
			int pageSize = Tools.GetPageSize();
			int pageNumber = Tools.GetPageNumber();
			long count;
			string paerSql = dbHelper.GetPaerSql(stringBuilder.ToString(), pageSize, pageNumber, out count, list.ToArray());
			pager = Tools.GetPagerHtml(count, pageSize, pageNumber, query);
			MySqlDataReader dataReader = dbHelper.GetDataReader(paerSql, list.ToArray());
			List<RoadFlow.Data.Model.ProgramBuilder> result = DataReaderToList(dataReader);
			((DbDataReader)dataReader).Close();
			return result;
		}
	}
}
