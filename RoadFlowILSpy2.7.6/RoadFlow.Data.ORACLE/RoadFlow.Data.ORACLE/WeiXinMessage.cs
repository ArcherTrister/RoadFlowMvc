using Oracle.ManagedDataAccess.Client;
using RoadFlow.Data.Interface;
using RoadFlow.Data.Model;
using System;
using System.Collections.Generic;
using System.Data.Common;

namespace RoadFlow.Data.ORACLE
{
	public class WeiXinMessage : IWeiXinMessage
	{
		private DBHelper dbHelper = new DBHelper();

		public int Add(RoadFlow.Data.Model.WeiXinMessage model)
		{
			//IL_0018: Unknown result type (might be due to invalid IL or missing references)
			//IL_001d: Unknown result type (might be due to invalid IL or missing references)
			//IL_002e: Expected O, but got Unknown
			//IL_002f: Expected O, but got Unknown
			//IL_003d: Unknown result type (might be due to invalid IL or missing references)
			//IL_0042: Unknown result type (might be due to invalid IL or missing references)
			//IL_004e: Expected O, but got Unknown
			//IL_004f: Expected O, but got Unknown
			//IL_005d: Unknown result type (might be due to invalid IL or missing references)
			//IL_0062: Unknown result type (might be due to invalid IL or missing references)
			//IL_006e: Expected O, but got Unknown
			//IL_006f: Expected O, but got Unknown
			//IL_0079: Unknown result type (might be due to invalid IL or missing references)
			//IL_007e: Unknown result type (might be due to invalid IL or missing references)
			//IL_008f: Expected O, but got Unknown
			//IL_0090: Expected O, but got Unknown
			//IL_009a: Unknown result type (might be due to invalid IL or missing references)
			//IL_009f: Unknown result type (might be due to invalid IL or missing references)
			//IL_00b0: Expected O, but got Unknown
			//IL_00b1: Expected O, but got Unknown
			//IL_00bc: Unknown result type (might be due to invalid IL or missing references)
			//IL_00c1: Unknown result type (might be due to invalid IL or missing references)
			//IL_00cd: Expected O, but got Unknown
			//IL_00ce: Expected O, but got Unknown
			//IL_00d8: Unknown result type (might be due to invalid IL or missing references)
			//IL_00dd: Unknown result type (might be due to invalid IL or missing references)
			//IL_00ee: Expected O, but got Unknown
			//IL_00ef: Expected O, but got Unknown
			//IL_00f9: Unknown result type (might be due to invalid IL or missing references)
			//IL_00fe: Unknown result type (might be due to invalid IL or missing references)
			//IL_010f: Expected O, but got Unknown
			//IL_0110: Expected O, but got Unknown
			//IL_0122: Unknown result type (might be due to invalid IL or missing references)
			//IL_0127: Unknown result type (might be due to invalid IL or missing references)
			//IL_0133: Expected O, but got Unknown
			//IL_013d: Unknown result type (might be due to invalid IL or missing references)
			//IL_0142: Unknown result type (might be due to invalid IL or missing references)
			//IL_014d: Expected O, but got Unknown
			//IL_014e: Expected O, but got Unknown
			//IL_0165: Unknown result type (might be due to invalid IL or missing references)
			//IL_016a: Unknown result type (might be due to invalid IL or missing references)
			//IL_0176: Expected O, but got Unknown
			//IL_0184: Unknown result type (might be due to invalid IL or missing references)
			//IL_0189: Unknown result type (might be due to invalid IL or missing references)
			//IL_0194: Expected O, but got Unknown
			//IL_0195: Expected O, but got Unknown
			//IL_01ac: Unknown result type (might be due to invalid IL or missing references)
			//IL_01b1: Unknown result type (might be due to invalid IL or missing references)
			//IL_01bd: Expected O, but got Unknown
			//IL_01cb: Unknown result type (might be due to invalid IL or missing references)
			//IL_01d0: Unknown result type (might be due to invalid IL or missing references)
			//IL_01db: Expected O, but got Unknown
			//IL_01dc: Expected O, but got Unknown
			//IL_01f0: Unknown result type (might be due to invalid IL or missing references)
			//IL_01f5: Unknown result type (might be due to invalid IL or missing references)
			//IL_0201: Expected O, but got Unknown
			//IL_020c: Unknown result type (might be due to invalid IL or missing references)
			//IL_0211: Unknown result type (might be due to invalid IL or missing references)
			//IL_021c: Expected O, but got Unknown
			//IL_021d: Expected O, but got Unknown
			//IL_0231: Unknown result type (might be due to invalid IL or missing references)
			//IL_0236: Unknown result type (might be due to invalid IL or missing references)
			//IL_0242: Expected O, but got Unknown
			//IL_024d: Unknown result type (might be due to invalid IL or missing references)
			//IL_0252: Unknown result type (might be due to invalid IL or missing references)
			//IL_025d: Expected O, but got Unknown
			//IL_025e: Expected O, but got Unknown
			//IL_0272: Unknown result type (might be due to invalid IL or missing references)
			//IL_0277: Unknown result type (might be due to invalid IL or missing references)
			//IL_0283: Expected O, but got Unknown
			//IL_028e: Unknown result type (might be due to invalid IL or missing references)
			//IL_0293: Unknown result type (might be due to invalid IL or missing references)
			//IL_029e: Expected O, but got Unknown
			//IL_029f: Expected O, but got Unknown
			//IL_02b3: Unknown result type (might be due to invalid IL or missing references)
			//IL_02b8: Unknown result type (might be due to invalid IL or missing references)
			//IL_02c4: Expected O, but got Unknown
			//IL_02cf: Unknown result type (might be due to invalid IL or missing references)
			//IL_02d4: Unknown result type (might be due to invalid IL or missing references)
			//IL_02df: Expected O, but got Unknown
			//IL_02e0: Expected O, but got Unknown
			//IL_02f4: Unknown result type (might be due to invalid IL or missing references)
			//IL_02f9: Unknown result type (might be due to invalid IL or missing references)
			//IL_0305: Expected O, but got Unknown
			//IL_0310: Unknown result type (might be due to invalid IL or missing references)
			//IL_0315: Unknown result type (might be due to invalid IL or missing references)
			//IL_0320: Expected O, but got Unknown
			//IL_0321: Expected O, but got Unknown
			//IL_0338: Unknown result type (might be due to invalid IL or missing references)
			//IL_033d: Unknown result type (might be due to invalid IL or missing references)
			//IL_0349: Expected O, but got Unknown
			//IL_0357: Unknown result type (might be due to invalid IL or missing references)
			//IL_035c: Unknown result type (might be due to invalid IL or missing references)
			//IL_0367: Expected O, but got Unknown
			//IL_0368: Expected O, but got Unknown
			//IL_037f: Unknown result type (might be due to invalid IL or missing references)
			//IL_0384: Unknown result type (might be due to invalid IL or missing references)
			//IL_0390: Expected O, but got Unknown
			//IL_039e: Unknown result type (might be due to invalid IL or missing references)
			//IL_03a3: Unknown result type (might be due to invalid IL or missing references)
			//IL_03ae: Expected O, but got Unknown
			//IL_03af: Expected O, but got Unknown
			//IL_03c6: Unknown result type (might be due to invalid IL or missing references)
			//IL_03cb: Unknown result type (might be due to invalid IL or missing references)
			//IL_03d7: Expected O, but got Unknown
			//IL_03e5: Unknown result type (might be due to invalid IL or missing references)
			//IL_03ea: Unknown result type (might be due to invalid IL or missing references)
			//IL_03f5: Expected O, but got Unknown
			//IL_03f6: Expected O, but got Unknown
			//IL_0401: Unknown result type (might be due to invalid IL or missing references)
			//IL_0406: Unknown result type (might be due to invalid IL or missing references)
			//IL_0417: Expected O, but got Unknown
			//IL_0418: Expected O, but got Unknown
			string sql = "INSERT INTO WeiXinMessage\r\n\t\t\t\t(ID,ToUserName,FromUserName,CreateTime,CreateTime1,MsgType,MsgId,AgentID,Contents,PicUrl,MediaId,Format,ThumbMediaId,Location_X,Location_Y,Scale,Label,Title,Description,AddTime) \r\n\t\t\t\tVALUES(:ID,:ToUserName,:FromUserName,:CreateTime,:CreateTime1,:MsgType,:MsgId,:AgentID,:Contents,:PicUrl,:MediaId,:Format,:ThumbMediaId,:Location_X,:Location_Y,:Scale,:Label,:Title,:Description,:AddTime)";
			OracleParameter[] obj = new OracleParameter[20];
			OracleParameter val = new OracleParameter(":ID", 126, 36);
			((DbParameter)val).Value = model.ID;
			obj[0] = val;
			OracleParameter val2 = new OracleParameter(":ToUserName", 126, 200);
			((DbParameter)val2).Value = model.ToUserName;
			obj[1] = val2;
			OracleParameter val3 = new OracleParameter(":FromUserName", 126, 200);
			((DbParameter)val3).Value = model.FromUserName;
			obj[2] = val3;
			OracleParameter val4 = new OracleParameter(":CreateTime", 112, -1);
			((DbParameter)val4).Value = model.CreateTime;
			obj[3] = val4;
			OracleParameter val5 = new OracleParameter(":CreateTime1", 106, 8);
			((DbParameter)val5).Value = model.CreateTime1;
			obj[4] = val5;
			OracleParameter val6 = new OracleParameter(":MsgType", 126, 50);
			((DbParameter)val6).Value = model.MsgType;
			obj[5] = val6;
			OracleParameter val7 = new OracleParameter(":MsgId", 113, -1);
			((DbParameter)val7).Value = model.MsgId;
			obj[6] = val7;
			OracleParameter val8 = new OracleParameter(":AgentID", 112, -1);
			((DbParameter)val8).Value = model.AgentID;
			obj[7] = val8;
			_003F val9;
			if (model.Contents != null)
			{
				val9 = new OracleParameter(":Contents", 119, -1);
				((DbParameter)val9).Value = model.Contents;
			}
			else
			{
				val9 = new OracleParameter(":Contents", 119, -1);
				((DbParameter)val9).Value = DBNull.Value;
			}
			obj[8] = val9;
			_003F val10;
			if (model.PicUrl != null)
			{
				val10 = new OracleParameter(":PicUrl", 126, 500);
				((DbParameter)val10).Value = model.PicUrl;
			}
			else
			{
				val10 = new OracleParameter(":PicUrl", 126, 500);
				((DbParameter)val10).Value = DBNull.Value;
			}
			obj[9] = val10;
			_003F val11;
			if (model.MediaId != null)
			{
				val11 = new OracleParameter(":MediaId", 126, 500);
				((DbParameter)val11).Value = model.MediaId;
			}
			else
			{
				val11 = new OracleParameter(":MediaId", 126, 500);
				((DbParameter)val11).Value = DBNull.Value;
			}
			obj[10] = val11;
			_003F val12;
			if (model.Format != null)
			{
				val12 = new OracleParameter(":Format", 126, 50);
				((DbParameter)val12).Value = model.Format;
			}
			else
			{
				val12 = new OracleParameter(":Format", 126, 50);
				((DbParameter)val12).Value = DBNull.Value;
			}
			obj[11] = val12;
			_003F val13;
			if (model.ThumbMediaId != null)
			{
				val13 = new OracleParameter(":ThumbMediaId", 126, 50);
				((DbParameter)val13).Value = model.ThumbMediaId;
			}
			else
			{
				val13 = new OracleParameter(":ThumbMediaId", 126, 50);
				((DbParameter)val13).Value = DBNull.Value;
			}
			obj[12] = val13;
			_003F val14;
			if (model.Location_X != null)
			{
				val14 = new OracleParameter(":Location_X", 126, 50);
				((DbParameter)val14).Value = model.Location_X;
			}
			else
			{
				val14 = new OracleParameter(":Location_X", 126, 50);
				((DbParameter)val14).Value = DBNull.Value;
			}
			obj[13] = val14;
			_003F val15;
			if (model.Location_Y != null)
			{
				val15 = new OracleParameter(":Location_Y", 126, 50);
				((DbParameter)val15).Value = model.Location_Y;
			}
			else
			{
				val15 = new OracleParameter(":Location_Y", 126, 50);
				((DbParameter)val15).Value = DBNull.Value;
			}
			obj[14] = val15;
			_003F val16;
			if (model.Scale != null)
			{
				val16 = new OracleParameter(":Scale", 126, 50);
				((DbParameter)val16).Value = model.Scale;
			}
			else
			{
				val16 = new OracleParameter(":Scale", 126, 50);
				((DbParameter)val16).Value = DBNull.Value;
			}
			obj[15] = val16;
			_003F val17;
			if (model.Label != null)
			{
				val17 = new OracleParameter(":Label", 119, 1000);
				((DbParameter)val17).Value = model.Label;
			}
			else
			{
				val17 = new OracleParameter(":Label", 119, 1000);
				((DbParameter)val17).Value = DBNull.Value;
			}
			obj[16] = val17;
			_003F val18;
			if (model.Title != null)
			{
				val18 = new OracleParameter(":Title", 119, 1000);
				((DbParameter)val18).Value = model.Title;
			}
			else
			{
				val18 = new OracleParameter(":Title", 119, 1000);
				((DbParameter)val18).Value = DBNull.Value;
			}
			obj[17] = val18;
			_003F val19;
			if (model.Description != null)
			{
				val19 = new OracleParameter(":Description", 119, 2000);
				((DbParameter)val19).Value = model.Description;
			}
			else
			{
				val19 = new OracleParameter(":Description", 119, 2000);
				((DbParameter)val19).Value = DBNull.Value;
			}
			obj[18] = val19;
			OracleParameter val20 = new OracleParameter(":AddTime", 106, 8);
			((DbParameter)val20).Value = model.AddTime;
			obj[19] = val20;
			OracleParameter[] parameter = (OracleParameter[])obj;
			return dbHelper.Execute(sql, parameter);
		}

		public int Update(RoadFlow.Data.Model.WeiXinMessage model)
		{
			//IL_001b: Unknown result type (might be due to invalid IL or missing references)
			//IL_0020: Unknown result type (might be due to invalid IL or missing references)
			//IL_002c: Expected O, but got Unknown
			//IL_002d: Expected O, but got Unknown
			//IL_003b: Unknown result type (might be due to invalid IL or missing references)
			//IL_0040: Unknown result type (might be due to invalid IL or missing references)
			//IL_004c: Expected O, but got Unknown
			//IL_004d: Expected O, but got Unknown
			//IL_0057: Unknown result type (might be due to invalid IL or missing references)
			//IL_005c: Unknown result type (might be due to invalid IL or missing references)
			//IL_006d: Expected O, but got Unknown
			//IL_006e: Expected O, but got Unknown
			//IL_0078: Unknown result type (might be due to invalid IL or missing references)
			//IL_007d: Unknown result type (might be due to invalid IL or missing references)
			//IL_008e: Expected O, but got Unknown
			//IL_008f: Expected O, but got Unknown
			//IL_009a: Unknown result type (might be due to invalid IL or missing references)
			//IL_009f: Unknown result type (might be due to invalid IL or missing references)
			//IL_00ab: Expected O, but got Unknown
			//IL_00ac: Expected O, but got Unknown
			//IL_00b6: Unknown result type (might be due to invalid IL or missing references)
			//IL_00bb: Unknown result type (might be due to invalid IL or missing references)
			//IL_00cc: Expected O, but got Unknown
			//IL_00cd: Expected O, but got Unknown
			//IL_00d7: Unknown result type (might be due to invalid IL or missing references)
			//IL_00dc: Unknown result type (might be due to invalid IL or missing references)
			//IL_00ed: Expected O, but got Unknown
			//IL_00ee: Expected O, but got Unknown
			//IL_0100: Unknown result type (might be due to invalid IL or missing references)
			//IL_0105: Unknown result type (might be due to invalid IL or missing references)
			//IL_0111: Expected O, but got Unknown
			//IL_011b: Unknown result type (might be due to invalid IL or missing references)
			//IL_0120: Unknown result type (might be due to invalid IL or missing references)
			//IL_012b: Expected O, but got Unknown
			//IL_012c: Expected O, but got Unknown
			//IL_0142: Unknown result type (might be due to invalid IL or missing references)
			//IL_0147: Unknown result type (might be due to invalid IL or missing references)
			//IL_0153: Expected O, but got Unknown
			//IL_0161: Unknown result type (might be due to invalid IL or missing references)
			//IL_0166: Unknown result type (might be due to invalid IL or missing references)
			//IL_0171: Expected O, but got Unknown
			//IL_0172: Expected O, but got Unknown
			//IL_0189: Unknown result type (might be due to invalid IL or missing references)
			//IL_018e: Unknown result type (might be due to invalid IL or missing references)
			//IL_019a: Expected O, but got Unknown
			//IL_01a8: Unknown result type (might be due to invalid IL or missing references)
			//IL_01ad: Unknown result type (might be due to invalid IL or missing references)
			//IL_01b8: Expected O, but got Unknown
			//IL_01b9: Expected O, but got Unknown
			//IL_01cd: Unknown result type (might be due to invalid IL or missing references)
			//IL_01d2: Unknown result type (might be due to invalid IL or missing references)
			//IL_01de: Expected O, but got Unknown
			//IL_01e9: Unknown result type (might be due to invalid IL or missing references)
			//IL_01ee: Unknown result type (might be due to invalid IL or missing references)
			//IL_01f9: Expected O, but got Unknown
			//IL_01fa: Expected O, but got Unknown
			//IL_020e: Unknown result type (might be due to invalid IL or missing references)
			//IL_0213: Unknown result type (might be due to invalid IL or missing references)
			//IL_021f: Expected O, but got Unknown
			//IL_022a: Unknown result type (might be due to invalid IL or missing references)
			//IL_022f: Unknown result type (might be due to invalid IL or missing references)
			//IL_023a: Expected O, but got Unknown
			//IL_023b: Expected O, but got Unknown
			//IL_024f: Unknown result type (might be due to invalid IL or missing references)
			//IL_0254: Unknown result type (might be due to invalid IL or missing references)
			//IL_0260: Expected O, but got Unknown
			//IL_026b: Unknown result type (might be due to invalid IL or missing references)
			//IL_0270: Unknown result type (might be due to invalid IL or missing references)
			//IL_027b: Expected O, but got Unknown
			//IL_027c: Expected O, but got Unknown
			//IL_0290: Unknown result type (might be due to invalid IL or missing references)
			//IL_0295: Unknown result type (might be due to invalid IL or missing references)
			//IL_02a1: Expected O, but got Unknown
			//IL_02ac: Unknown result type (might be due to invalid IL or missing references)
			//IL_02b1: Unknown result type (might be due to invalid IL or missing references)
			//IL_02bc: Expected O, but got Unknown
			//IL_02bd: Expected O, but got Unknown
			//IL_02d1: Unknown result type (might be due to invalid IL or missing references)
			//IL_02d6: Unknown result type (might be due to invalid IL or missing references)
			//IL_02e2: Expected O, but got Unknown
			//IL_02ed: Unknown result type (might be due to invalid IL or missing references)
			//IL_02f2: Unknown result type (might be due to invalid IL or missing references)
			//IL_02fd: Expected O, but got Unknown
			//IL_02fe: Expected O, but got Unknown
			//IL_0315: Unknown result type (might be due to invalid IL or missing references)
			//IL_031a: Unknown result type (might be due to invalid IL or missing references)
			//IL_0326: Expected O, but got Unknown
			//IL_0334: Unknown result type (might be due to invalid IL or missing references)
			//IL_0339: Unknown result type (might be due to invalid IL or missing references)
			//IL_0344: Expected O, but got Unknown
			//IL_0345: Expected O, but got Unknown
			//IL_035c: Unknown result type (might be due to invalid IL or missing references)
			//IL_0361: Unknown result type (might be due to invalid IL or missing references)
			//IL_036d: Expected O, but got Unknown
			//IL_037b: Unknown result type (might be due to invalid IL or missing references)
			//IL_0380: Unknown result type (might be due to invalid IL or missing references)
			//IL_038b: Expected O, but got Unknown
			//IL_038c: Expected O, but got Unknown
			//IL_03a3: Unknown result type (might be due to invalid IL or missing references)
			//IL_03a8: Unknown result type (might be due to invalid IL or missing references)
			//IL_03b4: Expected O, but got Unknown
			//IL_03c2: Unknown result type (might be due to invalid IL or missing references)
			//IL_03c7: Unknown result type (might be due to invalid IL or missing references)
			//IL_03d2: Expected O, but got Unknown
			//IL_03d3: Expected O, but got Unknown
			//IL_03de: Unknown result type (might be due to invalid IL or missing references)
			//IL_03e3: Unknown result type (might be due to invalid IL or missing references)
			//IL_03f4: Expected O, but got Unknown
			//IL_03f5: Expected O, but got Unknown
			//IL_0400: Unknown result type (might be due to invalid IL or missing references)
			//IL_0405: Unknown result type (might be due to invalid IL or missing references)
			//IL_0416: Expected O, but got Unknown
			//IL_0417: Expected O, but got Unknown
			string sql = "UPDATE WeiXinMessage SET \r\n\t\t\t\tToUserName=:ToUserName,FromUserName=:FromUserName,CreateTime=:CreateTime,CreateTime1=:CreateTime1,MsgType=:MsgType,MsgId=:MsgId,AgentID=:AgentID,Contents=:Contents,PicUrl=:PicUrl,MediaId=:MediaId,Format=:Format,ThumbMediaId=:ThumbMediaId,Location_X=:Location_X,Location_Y=:Location_Y,Scale=:Scale,Label=:Label,Title=:Title,Description=:Description,AddTime=:AddTime\r\n\t\t\t\tWHERE ID=:ID";
			OracleParameter[] obj = new OracleParameter[20];
			OracleParameter val = new OracleParameter(":ToUserName", 126, 200);
			((DbParameter)val).Value = model.ToUserName;
			obj[0] = val;
			OracleParameter val2 = new OracleParameter(":FromUserName", 126, 200);
			((DbParameter)val2).Value = model.FromUserName;
			obj[1] = val2;
			OracleParameter val3 = new OracleParameter(":CreateTime", 112, -1);
			((DbParameter)val3).Value = model.CreateTime;
			obj[2] = val3;
			OracleParameter val4 = new OracleParameter(":CreateTime1", 106, 8);
			((DbParameter)val4).Value = model.CreateTime1;
			obj[3] = val4;
			OracleParameter val5 = new OracleParameter(":MsgType", 126, 50);
			((DbParameter)val5).Value = model.MsgType;
			obj[4] = val5;
			OracleParameter val6 = new OracleParameter(":MsgId", 113, -1);
			((DbParameter)val6).Value = model.MsgId;
			obj[5] = val6;
			OracleParameter val7 = new OracleParameter(":AgentID", 112, -1);
			((DbParameter)val7).Value = model.AgentID;
			obj[6] = val7;
			_003F val8;
			if (model.Contents != null)
			{
				val8 = new OracleParameter(":Contents", 119, -1);
				((DbParameter)val8).Value = model.Contents;
			}
			else
			{
				val8 = new OracleParameter(":Contents", 119, -1);
				((DbParameter)val8).Value = DBNull.Value;
			}
			obj[7] = val8;
			_003F val9;
			if (model.PicUrl != null)
			{
				val9 = new OracleParameter(":PicUrl", 126, 500);
				((DbParameter)val9).Value = model.PicUrl;
			}
			else
			{
				val9 = new OracleParameter(":PicUrl", 126, 500);
				((DbParameter)val9).Value = DBNull.Value;
			}
			obj[8] = val9;
			_003F val10;
			if (model.MediaId != null)
			{
				val10 = new OracleParameter(":MediaId", 126, 500);
				((DbParameter)val10).Value = model.MediaId;
			}
			else
			{
				val10 = new OracleParameter(":MediaId", 126, 500);
				((DbParameter)val10).Value = DBNull.Value;
			}
			obj[9] = val10;
			_003F val11;
			if (model.Format != null)
			{
				val11 = new OracleParameter(":Format", 126, 50);
				((DbParameter)val11).Value = model.Format;
			}
			else
			{
				val11 = new OracleParameter(":Format", 126, 50);
				((DbParameter)val11).Value = DBNull.Value;
			}
			obj[10] = val11;
			_003F val12;
			if (model.ThumbMediaId != null)
			{
				val12 = new OracleParameter(":ThumbMediaId", 126, 50);
				((DbParameter)val12).Value = model.ThumbMediaId;
			}
			else
			{
				val12 = new OracleParameter(":ThumbMediaId", 126, 50);
				((DbParameter)val12).Value = DBNull.Value;
			}
			obj[11] = val12;
			_003F val13;
			if (model.Location_X != null)
			{
				val13 = new OracleParameter(":Location_X", 126, 50);
				((DbParameter)val13).Value = model.Location_X;
			}
			else
			{
				val13 = new OracleParameter(":Location_X", 126, 50);
				((DbParameter)val13).Value = DBNull.Value;
			}
			obj[12] = val13;
			_003F val14;
			if (model.Location_Y != null)
			{
				val14 = new OracleParameter(":Location_Y", 126, 50);
				((DbParameter)val14).Value = model.Location_Y;
			}
			else
			{
				val14 = new OracleParameter(":Location_Y", 126, 50);
				((DbParameter)val14).Value = DBNull.Value;
			}
			obj[13] = val14;
			_003F val15;
			if (model.Scale != null)
			{
				val15 = new OracleParameter(":Scale", 126, 50);
				((DbParameter)val15).Value = model.Scale;
			}
			else
			{
				val15 = new OracleParameter(":Scale", 126, 50);
				((DbParameter)val15).Value = DBNull.Value;
			}
			obj[14] = val15;
			_003F val16;
			if (model.Label != null)
			{
				val16 = new OracleParameter(":Label", 119, 1000);
				((DbParameter)val16).Value = model.Label;
			}
			else
			{
				val16 = new OracleParameter(":Label", 119, 1000);
				((DbParameter)val16).Value = DBNull.Value;
			}
			obj[15] = val16;
			_003F val17;
			if (model.Title != null)
			{
				val17 = new OracleParameter(":Title", 119, 1000);
				((DbParameter)val17).Value = model.Title;
			}
			else
			{
				val17 = new OracleParameter(":Title", 119, 1000);
				((DbParameter)val17).Value = DBNull.Value;
			}
			obj[16] = val17;
			_003F val18;
			if (model.Description != null)
			{
				val18 = new OracleParameter(":Description", 119, 2000);
				((DbParameter)val18).Value = model.Description;
			}
			else
			{
				val18 = new OracleParameter(":Description", 119, 2000);
				((DbParameter)val18).Value = DBNull.Value;
			}
			obj[17] = val18;
			OracleParameter val19 = new OracleParameter(":AddTime", 106, 8);
			((DbParameter)val19).Value = model.AddTime;
			obj[18] = val19;
			OracleParameter val20 = new OracleParameter(":ID", 126, -1);
			((DbParameter)val20).Value = model.ID;
			obj[19] = val20;
			OracleParameter[] parameter = (OracleParameter[])obj;
			return dbHelper.Execute(sql, parameter);
		}

		public int Delete(Guid id)
		{
			//IL_0015: Unknown result type (might be due to invalid IL or missing references)
			//IL_001a: Unknown result type (might be due to invalid IL or missing references)
			//IL_0026: Expected O, but got Unknown
			//IL_0027: Expected O, but got Unknown
			string sql = "DELETE FROM WeiXinMessage WHERE ID=:ID";
			OracleParameter[] obj = new OracleParameter[1];
			OracleParameter val = new OracleParameter(":ID", 126);
			((DbParameter)val).Value = id;
			obj[0] = val;
			OracleParameter[] parameter = (OracleParameter[])obj;
			return dbHelper.Execute(sql, parameter);
		}

		private List<RoadFlow.Data.Model.WeiXinMessage> DataReaderToList(OracleDataReader dataReader)
		{
			List<RoadFlow.Data.Model.WeiXinMessage> list = new List<RoadFlow.Data.Model.WeiXinMessage>();
			RoadFlow.Data.Model.WeiXinMessage weiXinMessage = null;
			while (((DbDataReader)dataReader).Read())
			{
				weiXinMessage = new RoadFlow.Data.Model.WeiXinMessage();
				weiXinMessage.ID = ((DbDataReader)dataReader).GetGuid(0);
				weiXinMessage.ToUserName = ((DbDataReader)dataReader).GetString(1);
				weiXinMessage.CreateTime = ((DbDataReader)dataReader).GetInt32(3);
				weiXinMessage.CreateTime1 = ((DbDataReader)dataReader).GetDateTime(4);
				weiXinMessage.MsgType = ((DbDataReader)dataReader).GetString(5);
				weiXinMessage.MsgId = ((DbDataReader)dataReader).GetInt64(6);
				weiXinMessage.AgentID = ((DbDataReader)dataReader).GetInt32(7);
				if (!((DbDataReader)dataReader).IsDBNull(8))
				{
					weiXinMessage.Contents = ((DbDataReader)dataReader).GetString(8);
				}
				if (!((DbDataReader)dataReader).IsDBNull(9))
				{
					weiXinMessage.PicUrl = ((DbDataReader)dataReader).GetString(9);
				}
				if (!((DbDataReader)dataReader).IsDBNull(10))
				{
					weiXinMessage.MediaId = ((DbDataReader)dataReader).GetString(10);
				}
				if (!((DbDataReader)dataReader).IsDBNull(11))
				{
					weiXinMessage.Format = ((DbDataReader)dataReader).GetString(11);
				}
				if (!((DbDataReader)dataReader).IsDBNull(12))
				{
					weiXinMessage.ThumbMediaId = ((DbDataReader)dataReader).GetString(12);
				}
				if (!((DbDataReader)dataReader).IsDBNull(13))
				{
					weiXinMessage.Location_X = ((DbDataReader)dataReader).GetString(13);
				}
				if (!((DbDataReader)dataReader).IsDBNull(14))
				{
					weiXinMessage.Location_Y = ((DbDataReader)dataReader).GetString(14);
				}
				if (!((DbDataReader)dataReader).IsDBNull(15))
				{
					weiXinMessage.Scale = ((DbDataReader)dataReader).GetString(15);
				}
				if (!((DbDataReader)dataReader).IsDBNull(16))
				{
					weiXinMessage.Label = ((DbDataReader)dataReader).GetString(16);
				}
				if (!((DbDataReader)dataReader).IsDBNull(17))
				{
					weiXinMessage.Title = ((DbDataReader)dataReader).GetString(17);
				}
				if (!((DbDataReader)dataReader).IsDBNull(18))
				{
					weiXinMessage.Description = ((DbDataReader)dataReader).GetString(18);
				}
				weiXinMessage.AddTime = ((DbDataReader)dataReader).GetDateTime(19);
				list.Add(weiXinMessage);
			}
			return list;
		}

		public List<RoadFlow.Data.Model.WeiXinMessage> GetAll()
		{
			string sql = "SELECT * FROM WeiXinMessage";
			OracleDataReader dataReader = dbHelper.GetDataReader(sql);
			List<RoadFlow.Data.Model.WeiXinMessage> result = DataReaderToList(dataReader);
			((DbDataReader)dataReader).Close();
			return result;
		}

		public long GetCount()
		{
			string sql = "SELECT COUNT(*) FROM WeiXinMessage";
			long result;
			if (!long.TryParse(dbHelper.GetFieldValue(sql), out result))
			{
				return 0L;
			}
			return result;
		}

		public RoadFlow.Data.Model.WeiXinMessage Get(Guid id)
		{
			//IL_0015: Unknown result type (might be due to invalid IL or missing references)
			//IL_001a: Unknown result type (might be due to invalid IL or missing references)
			//IL_0026: Expected O, but got Unknown
			//IL_0027: Expected O, but got Unknown
			string sql = "SELECT * FROM WeiXinMessage WHERE ID=:ID";
			OracleParameter[] obj = new OracleParameter[1];
			OracleParameter val = new OracleParameter(":ID", 126);
			((DbParameter)val).Value = id;
			obj[0] = val;
			OracleParameter[] parameter = (OracleParameter[])obj;
			OracleDataReader dataReader = dbHelper.GetDataReader(sql, parameter);
			List<RoadFlow.Data.Model.WeiXinMessage> list = DataReaderToList(dataReader);
			((DbDataReader)dataReader).Close();
			if (list.Count <= 0)
			{
				return null;
			}
			return list[0];
		}
	}
}
