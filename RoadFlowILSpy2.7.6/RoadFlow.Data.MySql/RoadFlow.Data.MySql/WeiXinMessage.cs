using MySql.Data.MySqlClient;
using RoadFlow.Data.Interface;
using RoadFlow.Data.Model;
using System;
using System.Collections.Generic;
using System.Data.Common;

namespace RoadFlow.Data.MySql
{
	public class WeiXinMessage : IWeiXinMessage
	{
		private DBHelper dbHelper = new DBHelper();

		public int Add(RoadFlow.Data.Model.WeiXinMessage model)
		{
			//IL_001b: Unknown result type (might be due to invalid IL or missing references)
			//IL_0020: Unknown result type (might be due to invalid IL or missing references)
			//IL_0031: Expected O, but got Unknown
			//IL_0032: Expected O, but got Unknown
			//IL_0043: Unknown result type (might be due to invalid IL or missing references)
			//IL_0048: Unknown result type (might be due to invalid IL or missing references)
			//IL_0054: Expected O, but got Unknown
			//IL_0055: Expected O, but got Unknown
			//IL_0066: Unknown result type (might be due to invalid IL or missing references)
			//IL_006b: Unknown result type (might be due to invalid IL or missing references)
			//IL_0077: Expected O, but got Unknown
			//IL_0078: Expected O, but got Unknown
			//IL_0081: Unknown result type (might be due to invalid IL or missing references)
			//IL_0086: Unknown result type (might be due to invalid IL or missing references)
			//IL_0097: Expected O, but got Unknown
			//IL_0098: Expected O, but got Unknown
			//IL_00a2: Unknown result type (might be due to invalid IL or missing references)
			//IL_00a7: Unknown result type (might be due to invalid IL or missing references)
			//IL_00b8: Expected O, but got Unknown
			//IL_00b9: Expected O, but got Unknown
			//IL_00c7: Unknown result type (might be due to invalid IL or missing references)
			//IL_00cc: Unknown result type (might be due to invalid IL or missing references)
			//IL_00d8: Expected O, but got Unknown
			//IL_00d9: Expected O, but got Unknown
			//IL_00e2: Unknown result type (might be due to invalid IL or missing references)
			//IL_00e7: Unknown result type (might be due to invalid IL or missing references)
			//IL_00f8: Expected O, but got Unknown
			//IL_00f9: Expected O, but got Unknown
			//IL_0102: Unknown result type (might be due to invalid IL or missing references)
			//IL_0107: Unknown result type (might be due to invalid IL or missing references)
			//IL_0118: Expected O, but got Unknown
			//IL_0119: Expected O, but got Unknown
			//IL_012e: Unknown result type (might be due to invalid IL or missing references)
			//IL_0133: Unknown result type (might be due to invalid IL or missing references)
			//IL_013f: Expected O, but got Unknown
			//IL_014c: Unknown result type (might be due to invalid IL or missing references)
			//IL_0151: Unknown result type (might be due to invalid IL or missing references)
			//IL_015c: Expected O, but got Unknown
			//IL_015d: Expected O, but got Unknown
			//IL_0177: Unknown result type (might be due to invalid IL or missing references)
			//IL_017c: Unknown result type (might be due to invalid IL or missing references)
			//IL_0188: Expected O, but got Unknown
			//IL_0199: Unknown result type (might be due to invalid IL or missing references)
			//IL_019e: Unknown result type (might be due to invalid IL or missing references)
			//IL_01a9: Expected O, but got Unknown
			//IL_01aa: Expected O, but got Unknown
			//IL_01c4: Unknown result type (might be due to invalid IL or missing references)
			//IL_01c9: Unknown result type (might be due to invalid IL or missing references)
			//IL_01d5: Expected O, but got Unknown
			//IL_01e6: Unknown result type (might be due to invalid IL or missing references)
			//IL_01eb: Unknown result type (might be due to invalid IL or missing references)
			//IL_01f6: Expected O, but got Unknown
			//IL_01f7: Expected O, but got Unknown
			//IL_020e: Unknown result type (might be due to invalid IL or missing references)
			//IL_0213: Unknown result type (might be due to invalid IL or missing references)
			//IL_021f: Expected O, but got Unknown
			//IL_022d: Unknown result type (might be due to invalid IL or missing references)
			//IL_0232: Unknown result type (might be due to invalid IL or missing references)
			//IL_023d: Expected O, but got Unknown
			//IL_023e: Expected O, but got Unknown
			//IL_0255: Unknown result type (might be due to invalid IL or missing references)
			//IL_025a: Unknown result type (might be due to invalid IL or missing references)
			//IL_0266: Expected O, but got Unknown
			//IL_0274: Unknown result type (might be due to invalid IL or missing references)
			//IL_0279: Unknown result type (might be due to invalid IL or missing references)
			//IL_0284: Expected O, but got Unknown
			//IL_0285: Expected O, but got Unknown
			//IL_029c: Unknown result type (might be due to invalid IL or missing references)
			//IL_02a1: Unknown result type (might be due to invalid IL or missing references)
			//IL_02ad: Expected O, but got Unknown
			//IL_02bb: Unknown result type (might be due to invalid IL or missing references)
			//IL_02c0: Unknown result type (might be due to invalid IL or missing references)
			//IL_02cb: Expected O, but got Unknown
			//IL_02cc: Expected O, but got Unknown
			//IL_02e3: Unknown result type (might be due to invalid IL or missing references)
			//IL_02e8: Unknown result type (might be due to invalid IL or missing references)
			//IL_02f4: Expected O, but got Unknown
			//IL_0302: Unknown result type (might be due to invalid IL or missing references)
			//IL_0307: Unknown result type (might be due to invalid IL or missing references)
			//IL_0312: Expected O, but got Unknown
			//IL_0313: Expected O, but got Unknown
			//IL_032a: Unknown result type (might be due to invalid IL or missing references)
			//IL_032f: Unknown result type (might be due to invalid IL or missing references)
			//IL_033b: Expected O, but got Unknown
			//IL_0349: Unknown result type (might be due to invalid IL or missing references)
			//IL_034e: Unknown result type (might be due to invalid IL or missing references)
			//IL_0359: Expected O, but got Unknown
			//IL_035a: Expected O, but got Unknown
			//IL_0374: Unknown result type (might be due to invalid IL or missing references)
			//IL_0379: Unknown result type (might be due to invalid IL or missing references)
			//IL_0385: Expected O, but got Unknown
			//IL_0396: Unknown result type (might be due to invalid IL or missing references)
			//IL_039b: Unknown result type (might be due to invalid IL or missing references)
			//IL_03a6: Expected O, but got Unknown
			//IL_03a7: Expected O, but got Unknown
			//IL_03c1: Unknown result type (might be due to invalid IL or missing references)
			//IL_03c6: Unknown result type (might be due to invalid IL or missing references)
			//IL_03d2: Expected O, but got Unknown
			//IL_03e3: Unknown result type (might be due to invalid IL or missing references)
			//IL_03e8: Unknown result type (might be due to invalid IL or missing references)
			//IL_03f3: Expected O, but got Unknown
			//IL_03f4: Expected O, but got Unknown
			//IL_040e: Unknown result type (might be due to invalid IL or missing references)
			//IL_0413: Unknown result type (might be due to invalid IL or missing references)
			//IL_041f: Expected O, but got Unknown
			//IL_0430: Unknown result type (might be due to invalid IL or missing references)
			//IL_0435: Unknown result type (might be due to invalid IL or missing references)
			//IL_0440: Expected O, but got Unknown
			//IL_0441: Expected O, but got Unknown
			//IL_044c: Unknown result type (might be due to invalid IL or missing references)
			//IL_0451: Unknown result type (might be due to invalid IL or missing references)
			//IL_0462: Expected O, but got Unknown
			//IL_0463: Expected O, but got Unknown
			string sql = "INSERT INTO WeiXinMessage\r\n\t\t\t\t(ID,ToUserName,FromUserName,CreateTime,CreateTime1,MsgType,MsgId,AgentID,Contents,PicUrl,MediaId,Format,ThumbMediaId,Location_X,Location_Y,Scale,Label,Title,Description,AddTime) \r\n\t\t\t\tVALUES(@ID,@ToUserName,@FromUserName,@CreateTime,@CreateTime1,@MsgType,@MsgId,@AgentID,@Contents,@PicUrl,@MediaId,@Format,@ThumbMediaId,@Location_X,@Location_Y,@Scale,@Label,@Title,@Description,@AddTime)";
			MySqlParameter[] obj = new MySqlParameter[20];
			MySqlParameter val = new MySqlParameter("@ID", 253, 36);
			((DbParameter)val).Value = model.ID;
			obj[0] = val;
			MySqlParameter val2 = new MySqlParameter("@ToUserName", 253, 200);
			((DbParameter)val2).Value = model.ToUserName;
			obj[1] = val2;
			MySqlParameter val3 = new MySqlParameter("@FromUserName", 253, 200);
			((DbParameter)val3).Value = model.FromUserName;
			obj[2] = val3;
			MySqlParameter val4 = new MySqlParameter("@CreateTime", 3, -1);
			((DbParameter)val4).Value = model.CreateTime;
			obj[3] = val4;
			MySqlParameter val5 = new MySqlParameter("@CreateTime1", 12, 8);
			((DbParameter)val5).Value = model.CreateTime1;
			obj[4] = val5;
			MySqlParameter val6 = new MySqlParameter("@MsgType", 253, 50);
			((DbParameter)val6).Value = model.MsgType;
			obj[5] = val6;
			MySqlParameter val7 = new MySqlParameter("@MsgId", 8, -1);
			((DbParameter)val7).Value = model.MsgId;
			obj[6] = val7;
			MySqlParameter val8 = new MySqlParameter("@AgentID", 3, -1);
			((DbParameter)val8).Value = model.AgentID;
			obj[7] = val8;
			_003F val9;
			if (model.Contents != null)
			{
				val9 = new MySqlParameter("@Contents", 253, -1);
				((DbParameter)val9).Value = model.Contents;
			}
			else
			{
				val9 = new MySqlParameter("@Contents", 253, -1);
				((DbParameter)val9).Value = DBNull.Value;
			}
			obj[8] = val9;
			_003F val10;
			if (model.PicUrl != null)
			{
				val10 = new MySqlParameter("@PicUrl", 253, 500);
				((DbParameter)val10).Value = model.PicUrl;
			}
			else
			{
				val10 = new MySqlParameter("@PicUrl", 253, 500);
				((DbParameter)val10).Value = DBNull.Value;
			}
			obj[9] = val10;
			_003F val11;
			if (model.MediaId != null)
			{
				val11 = new MySqlParameter("@MediaId", 253, 500);
				((DbParameter)val11).Value = model.MediaId;
			}
			else
			{
				val11 = new MySqlParameter("@MediaId", 253, 500);
				((DbParameter)val11).Value = DBNull.Value;
			}
			obj[10] = val11;
			_003F val12;
			if (model.Format != null)
			{
				val12 = new MySqlParameter("@Format", 253, 50);
				((DbParameter)val12).Value = model.Format;
			}
			else
			{
				val12 = new MySqlParameter("@Format", 253, 50);
				((DbParameter)val12).Value = DBNull.Value;
			}
			obj[11] = val12;
			_003F val13;
			if (model.ThumbMediaId != null)
			{
				val13 = new MySqlParameter("@ThumbMediaId", 253, 50);
				((DbParameter)val13).Value = model.ThumbMediaId;
			}
			else
			{
				val13 = new MySqlParameter("@ThumbMediaId", 253, 50);
				((DbParameter)val13).Value = DBNull.Value;
			}
			obj[12] = val13;
			_003F val14;
			if (model.Location_X != null)
			{
				val14 = new MySqlParameter("@Location_X", 253, 50);
				((DbParameter)val14).Value = model.Location_X;
			}
			else
			{
				val14 = new MySqlParameter("@Location_X", 253, 50);
				((DbParameter)val14).Value = DBNull.Value;
			}
			obj[13] = val14;
			_003F val15;
			if (model.Location_Y != null)
			{
				val15 = new MySqlParameter("@Location_Y", 253, 50);
				((DbParameter)val15).Value = model.Location_Y;
			}
			else
			{
				val15 = new MySqlParameter("@Location_Y", 253, 50);
				((DbParameter)val15).Value = DBNull.Value;
			}
			obj[14] = val15;
			_003F val16;
			if (model.Scale != null)
			{
				val16 = new MySqlParameter("@Scale", 253, 50);
				((DbParameter)val16).Value = model.Scale;
			}
			else
			{
				val16 = new MySqlParameter("@Scale", 253, 50);
				((DbParameter)val16).Value = DBNull.Value;
			}
			obj[15] = val16;
			_003F val17;
			if (model.Label != null)
			{
				val17 = new MySqlParameter("@Label", 253, 1000);
				((DbParameter)val17).Value = model.Label;
			}
			else
			{
				val17 = new MySqlParameter("@Label", 253, 1000);
				((DbParameter)val17).Value = DBNull.Value;
			}
			obj[16] = val17;
			_003F val18;
			if (model.Title != null)
			{
				val18 = new MySqlParameter("@Title", 253, 1000);
				((DbParameter)val18).Value = model.Title;
			}
			else
			{
				val18 = new MySqlParameter("@Title", 253, 1000);
				((DbParameter)val18).Value = DBNull.Value;
			}
			obj[17] = val18;
			_003F val19;
			if (model.Description != null)
			{
				val19 = new MySqlParameter("@Description", 253, 2000);
				((DbParameter)val19).Value = model.Description;
			}
			else
			{
				val19 = new MySqlParameter("@Description", 253, 2000);
				((DbParameter)val19).Value = DBNull.Value;
			}
			obj[18] = val19;
			MySqlParameter val20 = new MySqlParameter("@AddTime", 12, 8);
			((DbParameter)val20).Value = model.AddTime;
			obj[19] = val20;
			MySqlParameter[] parameter = (MySqlParameter[])obj;
			return dbHelper.Execute(sql, parameter);
		}

		public int Update(RoadFlow.Data.Model.WeiXinMessage model)
		{
			//IL_001e: Unknown result type (might be due to invalid IL or missing references)
			//IL_0023: Unknown result type (might be due to invalid IL or missing references)
			//IL_002f: Expected O, but got Unknown
			//IL_0030: Expected O, but got Unknown
			//IL_0041: Unknown result type (might be due to invalid IL or missing references)
			//IL_0046: Unknown result type (might be due to invalid IL or missing references)
			//IL_0052: Expected O, but got Unknown
			//IL_0053: Expected O, but got Unknown
			//IL_005c: Unknown result type (might be due to invalid IL or missing references)
			//IL_0061: Unknown result type (might be due to invalid IL or missing references)
			//IL_0072: Expected O, but got Unknown
			//IL_0073: Expected O, but got Unknown
			//IL_007d: Unknown result type (might be due to invalid IL or missing references)
			//IL_0082: Unknown result type (might be due to invalid IL or missing references)
			//IL_0093: Expected O, but got Unknown
			//IL_0094: Expected O, but got Unknown
			//IL_00a2: Unknown result type (might be due to invalid IL or missing references)
			//IL_00a7: Unknown result type (might be due to invalid IL or missing references)
			//IL_00b3: Expected O, but got Unknown
			//IL_00b4: Expected O, but got Unknown
			//IL_00bd: Unknown result type (might be due to invalid IL or missing references)
			//IL_00c2: Unknown result type (might be due to invalid IL or missing references)
			//IL_00d3: Expected O, but got Unknown
			//IL_00d4: Expected O, but got Unknown
			//IL_00dd: Unknown result type (might be due to invalid IL or missing references)
			//IL_00e2: Unknown result type (might be due to invalid IL or missing references)
			//IL_00f3: Expected O, but got Unknown
			//IL_00f4: Expected O, but got Unknown
			//IL_0109: Unknown result type (might be due to invalid IL or missing references)
			//IL_010e: Unknown result type (might be due to invalid IL or missing references)
			//IL_011a: Expected O, but got Unknown
			//IL_0127: Unknown result type (might be due to invalid IL or missing references)
			//IL_012c: Unknown result type (might be due to invalid IL or missing references)
			//IL_0137: Expected O, but got Unknown
			//IL_0138: Expected O, but got Unknown
			//IL_0151: Unknown result type (might be due to invalid IL or missing references)
			//IL_0156: Unknown result type (might be due to invalid IL or missing references)
			//IL_0162: Expected O, but got Unknown
			//IL_0173: Unknown result type (might be due to invalid IL or missing references)
			//IL_0178: Unknown result type (might be due to invalid IL or missing references)
			//IL_0183: Expected O, but got Unknown
			//IL_0184: Expected O, but got Unknown
			//IL_019e: Unknown result type (might be due to invalid IL or missing references)
			//IL_01a3: Unknown result type (might be due to invalid IL or missing references)
			//IL_01af: Expected O, but got Unknown
			//IL_01c0: Unknown result type (might be due to invalid IL or missing references)
			//IL_01c5: Unknown result type (might be due to invalid IL or missing references)
			//IL_01d0: Expected O, but got Unknown
			//IL_01d1: Expected O, but got Unknown
			//IL_01e8: Unknown result type (might be due to invalid IL or missing references)
			//IL_01ed: Unknown result type (might be due to invalid IL or missing references)
			//IL_01f9: Expected O, but got Unknown
			//IL_0207: Unknown result type (might be due to invalid IL or missing references)
			//IL_020c: Unknown result type (might be due to invalid IL or missing references)
			//IL_0217: Expected O, but got Unknown
			//IL_0218: Expected O, but got Unknown
			//IL_022f: Unknown result type (might be due to invalid IL or missing references)
			//IL_0234: Unknown result type (might be due to invalid IL or missing references)
			//IL_0240: Expected O, but got Unknown
			//IL_024e: Unknown result type (might be due to invalid IL or missing references)
			//IL_0253: Unknown result type (might be due to invalid IL or missing references)
			//IL_025e: Expected O, but got Unknown
			//IL_025f: Expected O, but got Unknown
			//IL_0276: Unknown result type (might be due to invalid IL or missing references)
			//IL_027b: Unknown result type (might be due to invalid IL or missing references)
			//IL_0287: Expected O, but got Unknown
			//IL_0295: Unknown result type (might be due to invalid IL or missing references)
			//IL_029a: Unknown result type (might be due to invalid IL or missing references)
			//IL_02a5: Expected O, but got Unknown
			//IL_02a6: Expected O, but got Unknown
			//IL_02bd: Unknown result type (might be due to invalid IL or missing references)
			//IL_02c2: Unknown result type (might be due to invalid IL or missing references)
			//IL_02ce: Expected O, but got Unknown
			//IL_02dc: Unknown result type (might be due to invalid IL or missing references)
			//IL_02e1: Unknown result type (might be due to invalid IL or missing references)
			//IL_02ec: Expected O, but got Unknown
			//IL_02ed: Expected O, but got Unknown
			//IL_0304: Unknown result type (might be due to invalid IL or missing references)
			//IL_0309: Unknown result type (might be due to invalid IL or missing references)
			//IL_0315: Expected O, but got Unknown
			//IL_0323: Unknown result type (might be due to invalid IL or missing references)
			//IL_0328: Unknown result type (might be due to invalid IL or missing references)
			//IL_0333: Expected O, but got Unknown
			//IL_0334: Expected O, but got Unknown
			//IL_034e: Unknown result type (might be due to invalid IL or missing references)
			//IL_0353: Unknown result type (might be due to invalid IL or missing references)
			//IL_035f: Expected O, but got Unknown
			//IL_0370: Unknown result type (might be due to invalid IL or missing references)
			//IL_0375: Unknown result type (might be due to invalid IL or missing references)
			//IL_0380: Expected O, but got Unknown
			//IL_0381: Expected O, but got Unknown
			//IL_039b: Unknown result type (might be due to invalid IL or missing references)
			//IL_03a0: Unknown result type (might be due to invalid IL or missing references)
			//IL_03ac: Expected O, but got Unknown
			//IL_03bd: Unknown result type (might be due to invalid IL or missing references)
			//IL_03c2: Unknown result type (might be due to invalid IL or missing references)
			//IL_03cd: Expected O, but got Unknown
			//IL_03ce: Expected O, but got Unknown
			//IL_03e8: Unknown result type (might be due to invalid IL or missing references)
			//IL_03ed: Unknown result type (might be due to invalid IL or missing references)
			//IL_03f9: Expected O, but got Unknown
			//IL_040a: Unknown result type (might be due to invalid IL or missing references)
			//IL_040f: Unknown result type (might be due to invalid IL or missing references)
			//IL_041a: Expected O, but got Unknown
			//IL_041b: Expected O, but got Unknown
			//IL_0426: Unknown result type (might be due to invalid IL or missing references)
			//IL_042b: Unknown result type (might be due to invalid IL or missing references)
			//IL_043c: Expected O, but got Unknown
			//IL_043d: Expected O, but got Unknown
			//IL_044b: Unknown result type (might be due to invalid IL or missing references)
			//IL_0450: Unknown result type (might be due to invalid IL or missing references)
			//IL_0461: Expected O, but got Unknown
			//IL_0462: Expected O, but got Unknown
			string sql = "UPDATE WeiXinMessage SET \r\n\t\t\t\tToUserName=@ToUserName,FromUserName=@FromUserName,CreateTime=@CreateTime,CreateTime1=@CreateTime1,MsgType=@MsgType,MsgId=@MsgId,AgentID=@AgentID,Contents=@Contents,PicUrl=@PicUrl,MediaId=@MediaId,Format=@Format,ThumbMediaId=@ThumbMediaId,Location_X=@Location_X,Location_Y=@Location_Y,Scale=@Scale,Label=@Label,Title=@Title,Description=@Description,AddTime=@AddTime\r\n\t\t\t\tWHERE ID=@ID";
			MySqlParameter[] obj = new MySqlParameter[20];
			MySqlParameter val = new MySqlParameter("@ToUserName", 253, 200);
			((DbParameter)val).Value = model.ToUserName;
			obj[0] = val;
			MySqlParameter val2 = new MySqlParameter("@FromUserName", 253, 200);
			((DbParameter)val2).Value = model.FromUserName;
			obj[1] = val2;
			MySqlParameter val3 = new MySqlParameter("@CreateTime", 3, -1);
			((DbParameter)val3).Value = model.CreateTime;
			obj[2] = val3;
			MySqlParameter val4 = new MySqlParameter("@CreateTime1", 12, 8);
			((DbParameter)val4).Value = model.CreateTime1;
			obj[3] = val4;
			MySqlParameter val5 = new MySqlParameter("@MsgType", 253, 50);
			((DbParameter)val5).Value = model.MsgType;
			obj[4] = val5;
			MySqlParameter val6 = new MySqlParameter("@MsgId", 8, -1);
			((DbParameter)val6).Value = model.MsgId;
			obj[5] = val6;
			MySqlParameter val7 = new MySqlParameter("@AgentID", 3, -1);
			((DbParameter)val7).Value = model.AgentID;
			obj[6] = val7;
			_003F val8;
			if (model.Contents != null)
			{
				val8 = new MySqlParameter("@Contents", 253, -1);
				((DbParameter)val8).Value = model.Contents;
			}
			else
			{
				val8 = new MySqlParameter("@Contents", 253, -1);
				((DbParameter)val8).Value = DBNull.Value;
			}
			obj[7] = val8;
			_003F val9;
			if (model.PicUrl != null)
			{
				val9 = new MySqlParameter("@PicUrl", 253, 500);
				((DbParameter)val9).Value = model.PicUrl;
			}
			else
			{
				val9 = new MySqlParameter("@PicUrl", 253, 500);
				((DbParameter)val9).Value = DBNull.Value;
			}
			obj[8] = val9;
			_003F val10;
			if (model.MediaId != null)
			{
				val10 = new MySqlParameter("@MediaId", 253, 500);
				((DbParameter)val10).Value = model.MediaId;
			}
			else
			{
				val10 = new MySqlParameter("@MediaId", 253, 500);
				((DbParameter)val10).Value = DBNull.Value;
			}
			obj[9] = val10;
			_003F val11;
			if (model.Format != null)
			{
				val11 = new MySqlParameter("@Format", 253, 50);
				((DbParameter)val11).Value = model.Format;
			}
			else
			{
				val11 = new MySqlParameter("@Format", 253, 50);
				((DbParameter)val11).Value = DBNull.Value;
			}
			obj[10] = val11;
			_003F val12;
			if (model.ThumbMediaId != null)
			{
				val12 = new MySqlParameter("@ThumbMediaId", 253, 50);
				((DbParameter)val12).Value = model.ThumbMediaId;
			}
			else
			{
				val12 = new MySqlParameter("@ThumbMediaId", 253, 50);
				((DbParameter)val12).Value = DBNull.Value;
			}
			obj[11] = val12;
			_003F val13;
			if (model.Location_X != null)
			{
				val13 = new MySqlParameter("@Location_X", 253, 50);
				((DbParameter)val13).Value = model.Location_X;
			}
			else
			{
				val13 = new MySqlParameter("@Location_X", 253, 50);
				((DbParameter)val13).Value = DBNull.Value;
			}
			obj[12] = val13;
			_003F val14;
			if (model.Location_Y != null)
			{
				val14 = new MySqlParameter("@Location_Y", 253, 50);
				((DbParameter)val14).Value = model.Location_Y;
			}
			else
			{
				val14 = new MySqlParameter("@Location_Y", 253, 50);
				((DbParameter)val14).Value = DBNull.Value;
			}
			obj[13] = val14;
			_003F val15;
			if (model.Scale != null)
			{
				val15 = new MySqlParameter("@Scale", 253, 50);
				((DbParameter)val15).Value = model.Scale;
			}
			else
			{
				val15 = new MySqlParameter("@Scale", 253, 50);
				((DbParameter)val15).Value = DBNull.Value;
			}
			obj[14] = val15;
			_003F val16;
			if (model.Label != null)
			{
				val16 = new MySqlParameter("@Label", 253, 1000);
				((DbParameter)val16).Value = model.Label;
			}
			else
			{
				val16 = new MySqlParameter("@Label", 253, 1000);
				((DbParameter)val16).Value = DBNull.Value;
			}
			obj[15] = val16;
			_003F val17;
			if (model.Title != null)
			{
				val17 = new MySqlParameter("@Title", 253, 1000);
				((DbParameter)val17).Value = model.Title;
			}
			else
			{
				val17 = new MySqlParameter("@Title", 253, 1000);
				((DbParameter)val17).Value = DBNull.Value;
			}
			obj[16] = val17;
			_003F val18;
			if (model.Description != null)
			{
				val18 = new MySqlParameter("@Description", 253, 2000);
				((DbParameter)val18).Value = model.Description;
			}
			else
			{
				val18 = new MySqlParameter("@Description", 253, 2000);
				((DbParameter)val18).Value = DBNull.Value;
			}
			obj[17] = val18;
			MySqlParameter val19 = new MySqlParameter("@AddTime", 12, 8);
			((DbParameter)val19).Value = model.AddTime;
			obj[18] = val19;
			MySqlParameter val20 = new MySqlParameter("@ID", 253, -1);
			((DbParameter)val20).Value = model.ID;
			obj[19] = val20;
			MySqlParameter[] parameter = (MySqlParameter[])obj;
			return dbHelper.Execute(sql, parameter);
		}

		public int Delete(Guid id)
		{
			//IL_0018: Unknown result type (might be due to invalid IL or missing references)
			//IL_001d: Unknown result type (might be due to invalid IL or missing references)
			//IL_0029: Expected O, but got Unknown
			//IL_002a: Expected O, but got Unknown
			string sql = "DELETE FROM WeiXinMessage WHERE ID=@ID";
			MySqlParameter[] obj = new MySqlParameter[1];
			MySqlParameter val = new MySqlParameter("@ID", 253);
			((DbParameter)val).Value = id;
			obj[0] = val;
			MySqlParameter[] parameter = (MySqlParameter[])obj;
			return dbHelper.Execute(sql, parameter);
		}

		private List<RoadFlow.Data.Model.WeiXinMessage> DataReaderToList(MySqlDataReader dataReader)
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
			MySqlDataReader dataReader = dbHelper.GetDataReader(sql);
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
			//IL_0018: Unknown result type (might be due to invalid IL or missing references)
			//IL_001d: Unknown result type (might be due to invalid IL or missing references)
			//IL_0029: Expected O, but got Unknown
			//IL_002a: Expected O, but got Unknown
			string sql = "SELECT * FROM WeiXinMessage WHERE ID=@ID";
			MySqlParameter[] obj = new MySqlParameter[1];
			MySqlParameter val = new MySqlParameter("@ID", 253);
			((DbParameter)val).Value = id;
			obj[0] = val;
			MySqlParameter[] parameter = (MySqlParameter[])obj;
			MySqlDataReader dataReader = dbHelper.GetDataReader(sql, parameter);
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
