using Oracle.ManagedDataAccess.Client;
using RoadFlow.Data.Interface;
using RoadFlow.Data.Model;
using RoadFlow.Utility;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Common;
using System.Text;

namespace RoadFlow.Data.ORACLE
{
	public class WorkFlowTask : IWorkFlowTask
	{
		private DBHelper dbHelper = new DBHelper();

		public int Add(RoadFlow.Data.Model.WorkFlowTask model)
		{
			//IL_0018: Unknown result type (might be due to invalid IL or missing references)
			//IL_001d: Unknown result type (might be due to invalid IL or missing references)
			//IL_002e: Expected O, but got Unknown
			//IL_002f: Expected O, but got Unknown
			//IL_003a: Unknown result type (might be due to invalid IL or missing references)
			//IL_003f: Unknown result type (might be due to invalid IL or missing references)
			//IL_0050: Expected O, but got Unknown
			//IL_0051: Expected O, but got Unknown
			//IL_005c: Unknown result type (might be due to invalid IL or missing references)
			//IL_0061: Unknown result type (might be due to invalid IL or missing references)
			//IL_0072: Expected O, but got Unknown
			//IL_0073: Expected O, but got Unknown
			//IL_007e: Unknown result type (might be due to invalid IL or missing references)
			//IL_0083: Unknown result type (might be due to invalid IL or missing references)
			//IL_0094: Expected O, but got Unknown
			//IL_0095: Expected O, but got Unknown
			//IL_00a0: Unknown result type (might be due to invalid IL or missing references)
			//IL_00a5: Unknown result type (might be due to invalid IL or missing references)
			//IL_00b6: Expected O, but got Unknown
			//IL_00b7: Expected O, but got Unknown
			//IL_00c5: Unknown result type (might be due to invalid IL or missing references)
			//IL_00ca: Unknown result type (might be due to invalid IL or missing references)
			//IL_00d6: Expected O, but got Unknown
			//IL_00d7: Expected O, but got Unknown
			//IL_00e2: Unknown result type (might be due to invalid IL or missing references)
			//IL_00e7: Unknown result type (might be due to invalid IL or missing references)
			//IL_00f3: Expected O, but got Unknown
			//IL_00f4: Expected O, but got Unknown
			//IL_00ff: Unknown result type (might be due to invalid IL or missing references)
			//IL_0104: Unknown result type (might be due to invalid IL or missing references)
			//IL_0115: Expected O, but got Unknown
			//IL_0116: Expected O, but got Unknown
			//IL_011f: Unknown result type (might be due to invalid IL or missing references)
			//IL_0124: Unknown result type (might be due to invalid IL or missing references)
			//IL_0135: Expected O, but got Unknown
			//IL_0136: Expected O, but got Unknown
			//IL_0145: Unknown result type (might be due to invalid IL or missing references)
			//IL_014a: Unknown result type (might be due to invalid IL or missing references)
			//IL_0156: Expected O, but got Unknown
			//IL_0157: Expected O, but got Unknown
			//IL_0163: Unknown result type (might be due to invalid IL or missing references)
			//IL_0168: Unknown result type (might be due to invalid IL or missing references)
			//IL_0179: Expected O, but got Unknown
			//IL_017a: Expected O, but got Unknown
			//IL_0186: Unknown result type (might be due to invalid IL or missing references)
			//IL_018b: Unknown result type (might be due to invalid IL or missing references)
			//IL_0197: Expected O, but got Unknown
			//IL_0198: Expected O, but got Unknown
			//IL_01a3: Unknown result type (might be due to invalid IL or missing references)
			//IL_01a8: Unknown result type (might be due to invalid IL or missing references)
			//IL_01b9: Expected O, but got Unknown
			//IL_01ba: Expected O, but got Unknown
			//IL_01c6: Unknown result type (might be due to invalid IL or missing references)
			//IL_01cb: Unknown result type (might be due to invalid IL or missing references)
			//IL_01dc: Expected O, but got Unknown
			//IL_01dd: Expected O, but got Unknown
			//IL_01e9: Unknown result type (might be due to invalid IL or missing references)
			//IL_01ee: Unknown result type (might be due to invalid IL or missing references)
			//IL_01fa: Expected O, but got Unknown
			//IL_01fb: Expected O, but got Unknown
			//IL_0206: Unknown result type (might be due to invalid IL or missing references)
			//IL_020b: Unknown result type (might be due to invalid IL or missing references)
			//IL_021c: Expected O, but got Unknown
			//IL_021d: Expected O, but got Unknown
			//IL_0238: Unknown result type (might be due to invalid IL or missing references)
			//IL_023d: Unknown result type (might be due to invalid IL or missing references)
			//IL_024e: Expected O, but got Unknown
			//IL_0258: Unknown result type (might be due to invalid IL or missing references)
			//IL_025d: Unknown result type (might be due to invalid IL or missing references)
			//IL_0268: Expected O, but got Unknown
			//IL_0269: Expected O, but got Unknown
			//IL_0284: Unknown result type (might be due to invalid IL or missing references)
			//IL_0289: Unknown result type (might be due to invalid IL or missing references)
			//IL_029a: Expected O, but got Unknown
			//IL_02a4: Unknown result type (might be due to invalid IL or missing references)
			//IL_02a9: Unknown result type (might be due to invalid IL or missing references)
			//IL_02b4: Expected O, but got Unknown
			//IL_02b5: Expected O, but got Unknown
			//IL_02d0: Unknown result type (might be due to invalid IL or missing references)
			//IL_02d5: Unknown result type (might be due to invalid IL or missing references)
			//IL_02e6: Expected O, but got Unknown
			//IL_02f0: Unknown result type (might be due to invalid IL or missing references)
			//IL_02f5: Unknown result type (might be due to invalid IL or missing references)
			//IL_0300: Expected O, but got Unknown
			//IL_0301: Expected O, but got Unknown
			//IL_0313: Unknown result type (might be due to invalid IL or missing references)
			//IL_0318: Unknown result type (might be due to invalid IL or missing references)
			//IL_0324: Expected O, but got Unknown
			//IL_032d: Unknown result type (might be due to invalid IL or missing references)
			//IL_0332: Unknown result type (might be due to invalid IL or missing references)
			//IL_033d: Expected O, but got Unknown
			//IL_033e: Expected O, but got Unknown
			//IL_0358: Unknown result type (might be due to invalid IL or missing references)
			//IL_035d: Unknown result type (might be due to invalid IL or missing references)
			//IL_036e: Expected O, but got Unknown
			//IL_0377: Unknown result type (might be due to invalid IL or missing references)
			//IL_037c: Unknown result type (might be due to invalid IL or missing references)
			//IL_0387: Expected O, but got Unknown
			//IL_0388: Expected O, but got Unknown
			//IL_0392: Unknown result type (might be due to invalid IL or missing references)
			//IL_0397: Unknown result type (might be due to invalid IL or missing references)
			//IL_03a8: Expected O, but got Unknown
			//IL_03a9: Expected O, but got Unknown
			//IL_03bb: Unknown result type (might be due to invalid IL or missing references)
			//IL_03c0: Unknown result type (might be due to invalid IL or missing references)
			//IL_03cc: Expected O, but got Unknown
			//IL_03d5: Unknown result type (might be due to invalid IL or missing references)
			//IL_03da: Unknown result type (might be due to invalid IL or missing references)
			//IL_03e5: Expected O, but got Unknown
			//IL_03e6: Expected O, but got Unknown
			//IL_03f0: Unknown result type (might be due to invalid IL or missing references)
			//IL_03f5: Unknown result type (might be due to invalid IL or missing references)
			//IL_0406: Expected O, but got Unknown
			//IL_0407: Expected O, but got Unknown
			//IL_0419: Unknown result type (might be due to invalid IL or missing references)
			//IL_041e: Unknown result type (might be due to invalid IL or missing references)
			//IL_042a: Expected O, but got Unknown
			//IL_0433: Unknown result type (might be due to invalid IL or missing references)
			//IL_0438: Unknown result type (might be due to invalid IL or missing references)
			//IL_0443: Expected O, but got Unknown
			//IL_0444: Expected O, but got Unknown
			//IL_045e: Unknown result type (might be due to invalid IL or missing references)
			//IL_0463: Unknown result type (might be due to invalid IL or missing references)
			//IL_0474: Expected O, but got Unknown
			//IL_047d: Unknown result type (might be due to invalid IL or missing references)
			//IL_0482: Unknown result type (might be due to invalid IL or missing references)
			//IL_048d: Expected O, but got Unknown
			//IL_048e: Expected O, but got Unknown
			//IL_04a0: Unknown result type (might be due to invalid IL or missing references)
			//IL_04a5: Unknown result type (might be due to invalid IL or missing references)
			//IL_04b1: Expected O, but got Unknown
			//IL_04ba: Unknown result type (might be due to invalid IL or missing references)
			//IL_04bf: Unknown result type (might be due to invalid IL or missing references)
			//IL_04ca: Expected O, but got Unknown
			//IL_04cb: Expected O, but got Unknown
			//IL_04d5: Unknown result type (might be due to invalid IL or missing references)
			//IL_04da: Unknown result type (might be due to invalid IL or missing references)
			//IL_04eb: Expected O, but got Unknown
			//IL_04ec: Expected O, but got Unknown
			//IL_04f6: Unknown result type (might be due to invalid IL or missing references)
			//IL_04fb: Unknown result type (might be due to invalid IL or missing references)
			//IL_050c: Expected O, but got Unknown
			//IL_050d: Expected O, but got Unknown
			string sql = "INSERT INTO WorkFlowTask\r\n\t\t\t\t(ID,PrevID,PrevStepID,FlowID,StepID,StepName,InstanceID,GroupID,Type,Title,SenderID,SenderName,SenderTime,ReceiveID,ReceiveName,ReceiveTime,OpenTime,CompletedTime,CompletedTime1,Comment1,IsSign,Status,Note,Sort,SubFlowGroupID,OtherType,Files,IsExpiredAutoSubmit,StepSort) \r\n\t\t\t\tVALUES(:ID,:PrevID,:PrevStepID,:FlowID,:StepID,:StepName,:InstanceID,:GroupID,:Type,:Title,:SenderID,:SenderName,:SenderTime,:ReceiveID,:ReceiveName,:ReceiveTime,:OpenTime,:CompletedTime,:CompletedTime1,:Comment1,:IsSign,:Status,:Note,:Sort,:SubFlowGroupID,:OtherType,:Files,:IsExpiredAutoSubmit,:StepSort)";
			OracleParameter[] obj = new OracleParameter[29];
			OracleParameter val = new OracleParameter(":ID", 126, 40);
			((DbParameter)val).Value = model.ID;
			obj[0] = val;
			OracleParameter val2 = new OracleParameter(":PrevID", 126, 40);
			((DbParameter)val2).Value = model.PrevID;
			obj[1] = val2;
			OracleParameter val3 = new OracleParameter(":PrevStepID", 126, 40);
			((DbParameter)val3).Value = model.PrevStepID;
			obj[2] = val3;
			OracleParameter val4 = new OracleParameter(":FlowID", 126, 40);
			((DbParameter)val4).Value = model.FlowID;
			obj[3] = val4;
			OracleParameter val5 = new OracleParameter(":StepID", 126, 40);
			((DbParameter)val5).Value = model.StepID;
			obj[4] = val5;
			OracleParameter val6 = new OracleParameter(":StepName", 119, 1000);
			((DbParameter)val6).Value = model.StepName;
			obj[5] = val6;
			OracleParameter val7 = new OracleParameter(":InstanceID", 126, 50);
			((DbParameter)val7).Value = model.InstanceID;
			obj[6] = val7;
			OracleParameter val8 = new OracleParameter(":GroupID", 126, 40);
			((DbParameter)val8).Value = model.GroupID;
			obj[7] = val8;
			OracleParameter val9 = new OracleParameter(":Type", 112);
			((DbParameter)val9).Value = model.Type;
			obj[8] = val9;
			OracleParameter val10 = new OracleParameter(":Title", 119, 4000);
			((DbParameter)val10).Value = model.Title;
			obj[9] = val10;
			OracleParameter val11 = new OracleParameter(":SenderID", 126, 40);
			((DbParameter)val11).Value = model.SenderID;
			obj[10] = val11;
			OracleParameter val12 = new OracleParameter(":SenderName", 119, 100);
			((DbParameter)val12).Value = model.SenderName;
			obj[11] = val12;
			OracleParameter val13 = new OracleParameter(":SenderTime", 106, 8);
			((DbParameter)val13).Value = model.SenderTime;
			obj[12] = val13;
			OracleParameter val14 = new OracleParameter(":ReceiveID", 126, 40);
			((DbParameter)val14).Value = model.ReceiveID;
			obj[13] = val14;
			OracleParameter val15 = new OracleParameter(":ReceiveName", 119, 100);
			((DbParameter)val15).Value = model.ReceiveName;
			obj[14] = val15;
			OracleParameter val16 = new OracleParameter(":ReceiveTime", 106, 8);
			((DbParameter)val16).Value = model.ReceiveTime;
			obj[15] = val16;
			_003F val17;
			if (model.OpenTime.HasValue)
			{
				val17 = new OracleParameter(":OpenTime", 106, 8);
				((DbParameter)val17).Value = model.OpenTime;
			}
			else
			{
				val17 = new OracleParameter(":OpenTime", 106, 8);
				((DbParameter)val17).Value = DBNull.Value;
			}
			obj[16] = val17;
			_003F val18;
			if (model.CompletedTime.HasValue)
			{
				val18 = new OracleParameter(":CompletedTime", 106, 8);
				((DbParameter)val18).Value = model.CompletedTime;
			}
			else
			{
				val18 = new OracleParameter(":CompletedTime", 106, 8);
				((DbParameter)val18).Value = DBNull.Value;
			}
			obj[17] = val18;
			_003F val19;
			if (model.CompletedTime1.HasValue)
			{
				val19 = new OracleParameter(":CompletedTime1", 106, 8);
				((DbParameter)val19).Value = model.CompletedTime1;
			}
			else
			{
				val19 = new OracleParameter(":CompletedTime1", 106, 8);
				((DbParameter)val19).Value = DBNull.Value;
			}
			obj[18] = val19;
			_003F val20;
			if (model.Comment != null)
			{
				val20 = new OracleParameter(":Comment1", 119);
				((DbParameter)val20).Value = model.Comment;
			}
			else
			{
				val20 = new OracleParameter(":Comment1", 119);
				((DbParameter)val20).Value = DBNull.Value;
			}
			obj[19] = val20;
			_003F val21;
			if (model.IsSign.HasValue)
			{
				val21 = new OracleParameter(":IsSign", 112);
				((DbParameter)val21).Value = model.IsSign;
			}
			else
			{
				val21 = new OracleParameter(":IsSign", 112);
				((DbParameter)val21).Value = DBNull.Value;
			}
			obj[20] = val21;
			OracleParameter val22 = new OracleParameter(":Status", 112);
			((DbParameter)val22).Value = model.Status;
			obj[21] = val22;
			_003F val23;
			if (model.Note != null)
			{
				val23 = new OracleParameter(":Note", 119);
				((DbParameter)val23).Value = model.Note;
			}
			else
			{
				val23 = new OracleParameter(":Note", 119);
				((DbParameter)val23).Value = DBNull.Value;
			}
			obj[22] = val23;
			OracleParameter val24 = new OracleParameter(":Sort", 112);
			((DbParameter)val24).Value = model.Sort;
			obj[23] = val24;
			_003F val25;
			if (model.SubFlowGroupID != null)
			{
				val25 = new OracleParameter(":SubFlowGroupID", 126);
				((DbParameter)val25).Value = model.SubFlowGroupID;
			}
			else
			{
				val25 = new OracleParameter(":SubFlowGroupID", 126);
				((DbParameter)val25).Value = DBNull.Value;
			}
			obj[24] = val25;
			_003F val26;
			if (model.OtherType.HasValue)
			{
				val26 = new OracleParameter(":OtherType", 112);
				((DbParameter)val26).Value = model.OtherType;
			}
			else
			{
				val26 = new OracleParameter(":OtherType", 112);
				((DbParameter)val26).Value = DBNull.Value;
			}
			obj[25] = val26;
			_003F val27;
			if (model.Files != null)
			{
				val27 = new OracleParameter(":Files", 126);
				((DbParameter)val27).Value = model.Files;
			}
			else
			{
				val27 = new OracleParameter(":Files", 126);
				((DbParameter)val27).Value = DBNull.Value;
			}
			obj[26] = val27;
			OracleParameter val28 = new OracleParameter(":IsExpiredAutoSubmit", 112);
			((DbParameter)val28).Value = model.IsExpiredAutoSubmit;
			obj[27] = val28;
			OracleParameter val29 = new OracleParameter(":StepSort", 112);
			((DbParameter)val29).Value = model.StepSort;
			obj[28] = val29;
			OracleParameter[] parameter = (OracleParameter[])obj;
			return dbHelper.Execute(sql, parameter);
		}

		public int Update(RoadFlow.Data.Model.WorkFlowTask model)
		{
			//IL_0018: Unknown result type (might be due to invalid IL or missing references)
			//IL_001d: Unknown result type (might be due to invalid IL or missing references)
			//IL_002e: Expected O, but got Unknown
			//IL_002f: Expected O, but got Unknown
			//IL_003a: Unknown result type (might be due to invalid IL or missing references)
			//IL_003f: Unknown result type (might be due to invalid IL or missing references)
			//IL_0050: Expected O, but got Unknown
			//IL_0051: Expected O, but got Unknown
			//IL_005c: Unknown result type (might be due to invalid IL or missing references)
			//IL_0061: Unknown result type (might be due to invalid IL or missing references)
			//IL_0072: Expected O, but got Unknown
			//IL_0073: Expected O, but got Unknown
			//IL_007e: Unknown result type (might be due to invalid IL or missing references)
			//IL_0083: Unknown result type (might be due to invalid IL or missing references)
			//IL_0094: Expected O, but got Unknown
			//IL_0095: Expected O, but got Unknown
			//IL_00a3: Unknown result type (might be due to invalid IL or missing references)
			//IL_00a8: Unknown result type (might be due to invalid IL or missing references)
			//IL_00b4: Expected O, but got Unknown
			//IL_00b5: Expected O, but got Unknown
			//IL_00c0: Unknown result type (might be due to invalid IL or missing references)
			//IL_00c5: Unknown result type (might be due to invalid IL or missing references)
			//IL_00d1: Expected O, but got Unknown
			//IL_00d2: Expected O, but got Unknown
			//IL_00dd: Unknown result type (might be due to invalid IL or missing references)
			//IL_00e2: Unknown result type (might be due to invalid IL or missing references)
			//IL_00f3: Expected O, but got Unknown
			//IL_00f4: Expected O, but got Unknown
			//IL_00fd: Unknown result type (might be due to invalid IL or missing references)
			//IL_0102: Unknown result type (might be due to invalid IL or missing references)
			//IL_0113: Expected O, but got Unknown
			//IL_0114: Expected O, but got Unknown
			//IL_0122: Unknown result type (might be due to invalid IL or missing references)
			//IL_0127: Unknown result type (might be due to invalid IL or missing references)
			//IL_0133: Expected O, but got Unknown
			//IL_0134: Expected O, but got Unknown
			//IL_0140: Unknown result type (might be due to invalid IL or missing references)
			//IL_0145: Unknown result type (might be due to invalid IL or missing references)
			//IL_0156: Expected O, but got Unknown
			//IL_0157: Expected O, but got Unknown
			//IL_0163: Unknown result type (might be due to invalid IL or missing references)
			//IL_0168: Unknown result type (might be due to invalid IL or missing references)
			//IL_0174: Expected O, but got Unknown
			//IL_0175: Expected O, but got Unknown
			//IL_0180: Unknown result type (might be due to invalid IL or missing references)
			//IL_0185: Unknown result type (might be due to invalid IL or missing references)
			//IL_0196: Expected O, but got Unknown
			//IL_0197: Expected O, but got Unknown
			//IL_01a3: Unknown result type (might be due to invalid IL or missing references)
			//IL_01a8: Unknown result type (might be due to invalid IL or missing references)
			//IL_01b9: Expected O, but got Unknown
			//IL_01ba: Expected O, but got Unknown
			//IL_01c6: Unknown result type (might be due to invalid IL or missing references)
			//IL_01cb: Unknown result type (might be due to invalid IL or missing references)
			//IL_01d7: Expected O, but got Unknown
			//IL_01d8: Expected O, but got Unknown
			//IL_01e3: Unknown result type (might be due to invalid IL or missing references)
			//IL_01e8: Unknown result type (might be due to invalid IL or missing references)
			//IL_01f9: Expected O, but got Unknown
			//IL_01fa: Expected O, but got Unknown
			//IL_0215: Unknown result type (might be due to invalid IL or missing references)
			//IL_021a: Unknown result type (might be due to invalid IL or missing references)
			//IL_022b: Expected O, but got Unknown
			//IL_0235: Unknown result type (might be due to invalid IL or missing references)
			//IL_023a: Unknown result type (might be due to invalid IL or missing references)
			//IL_0245: Expected O, but got Unknown
			//IL_0246: Expected O, but got Unknown
			//IL_0261: Unknown result type (might be due to invalid IL or missing references)
			//IL_0266: Unknown result type (might be due to invalid IL or missing references)
			//IL_0277: Expected O, but got Unknown
			//IL_0281: Unknown result type (might be due to invalid IL or missing references)
			//IL_0286: Unknown result type (might be due to invalid IL or missing references)
			//IL_0291: Expected O, but got Unknown
			//IL_0292: Expected O, but got Unknown
			//IL_02ad: Unknown result type (might be due to invalid IL or missing references)
			//IL_02b2: Unknown result type (might be due to invalid IL or missing references)
			//IL_02c3: Expected O, but got Unknown
			//IL_02cd: Unknown result type (might be due to invalid IL or missing references)
			//IL_02d2: Unknown result type (might be due to invalid IL or missing references)
			//IL_02dd: Expected O, but got Unknown
			//IL_02de: Expected O, but got Unknown
			//IL_02f0: Unknown result type (might be due to invalid IL or missing references)
			//IL_02f5: Unknown result type (might be due to invalid IL or missing references)
			//IL_0301: Expected O, but got Unknown
			//IL_030a: Unknown result type (might be due to invalid IL or missing references)
			//IL_030f: Unknown result type (might be due to invalid IL or missing references)
			//IL_031a: Expected O, but got Unknown
			//IL_031b: Expected O, but got Unknown
			//IL_0335: Unknown result type (might be due to invalid IL or missing references)
			//IL_033a: Unknown result type (might be due to invalid IL or missing references)
			//IL_034b: Expected O, but got Unknown
			//IL_0354: Unknown result type (might be due to invalid IL or missing references)
			//IL_0359: Unknown result type (might be due to invalid IL or missing references)
			//IL_0364: Expected O, but got Unknown
			//IL_0365: Expected O, but got Unknown
			//IL_036f: Unknown result type (might be due to invalid IL or missing references)
			//IL_0374: Unknown result type (might be due to invalid IL or missing references)
			//IL_0385: Expected O, but got Unknown
			//IL_0386: Expected O, but got Unknown
			//IL_0398: Unknown result type (might be due to invalid IL or missing references)
			//IL_039d: Unknown result type (might be due to invalid IL or missing references)
			//IL_03a9: Expected O, but got Unknown
			//IL_03b2: Unknown result type (might be due to invalid IL or missing references)
			//IL_03b7: Unknown result type (might be due to invalid IL or missing references)
			//IL_03c2: Expected O, but got Unknown
			//IL_03c3: Expected O, but got Unknown
			//IL_03cd: Unknown result type (might be due to invalid IL or missing references)
			//IL_03d2: Unknown result type (might be due to invalid IL or missing references)
			//IL_03e3: Expected O, but got Unknown
			//IL_03e4: Expected O, but got Unknown
			//IL_03f6: Unknown result type (might be due to invalid IL or missing references)
			//IL_03fb: Unknown result type (might be due to invalid IL or missing references)
			//IL_0407: Expected O, but got Unknown
			//IL_0410: Unknown result type (might be due to invalid IL or missing references)
			//IL_0415: Unknown result type (might be due to invalid IL or missing references)
			//IL_0420: Expected O, but got Unknown
			//IL_0421: Expected O, but got Unknown
			//IL_043b: Unknown result type (might be due to invalid IL or missing references)
			//IL_0440: Unknown result type (might be due to invalid IL or missing references)
			//IL_0451: Expected O, but got Unknown
			//IL_045a: Unknown result type (might be due to invalid IL or missing references)
			//IL_045f: Unknown result type (might be due to invalid IL or missing references)
			//IL_046a: Expected O, but got Unknown
			//IL_046b: Expected O, but got Unknown
			//IL_047d: Unknown result type (might be due to invalid IL or missing references)
			//IL_0482: Unknown result type (might be due to invalid IL or missing references)
			//IL_048e: Expected O, but got Unknown
			//IL_0497: Unknown result type (might be due to invalid IL or missing references)
			//IL_049c: Unknown result type (might be due to invalid IL or missing references)
			//IL_04a7: Expected O, but got Unknown
			//IL_04a8: Expected O, but got Unknown
			//IL_04b2: Unknown result type (might be due to invalid IL or missing references)
			//IL_04b7: Unknown result type (might be due to invalid IL or missing references)
			//IL_04c8: Expected O, but got Unknown
			//IL_04c9: Expected O, but got Unknown
			//IL_04d3: Unknown result type (might be due to invalid IL or missing references)
			//IL_04d8: Unknown result type (might be due to invalid IL or missing references)
			//IL_04e9: Expected O, but got Unknown
			//IL_04ea: Expected O, but got Unknown
			//IL_04f6: Unknown result type (might be due to invalid IL or missing references)
			//IL_04fb: Unknown result type (might be due to invalid IL or missing references)
			//IL_050c: Expected O, but got Unknown
			//IL_050d: Expected O, but got Unknown
			string sql = "UPDATE WorkFlowTask SET \r\n\t\t\t\tPrevID=:PrevID,PrevStepID=:PrevStepID,FlowID=:FlowID,StepID=:StepID,StepName=:StepName,InstanceID=:InstanceID,GroupID=:GroupID,Type=:Type,Title=:Title,SenderID=:SenderID,SenderName=:SenderName,SenderTime=:SenderTime,ReceiveID=:ReceiveID,ReceiveName=:ReceiveName,ReceiveTime=:ReceiveTime,OpenTime=:OpenTime,CompletedTime=:CompletedTime,CompletedTime1=:CompletedTime1,Comment1=:Comment1,IsSign=:IsSign,Status=:Status,Note=:Note,Sort=:Sort,SubFlowGroupID=:SubFlowGroupID,OtherType=:OtherType,Files=:Files,IsExpiredAutoSubmit=:IsExpiredAutoSubmit,StepSort=:StepSort  \r\n\t\t\t\tWHERE ID=:ID";
			OracleParameter[] obj = new OracleParameter[29];
			OracleParameter val = new OracleParameter(":PrevID", 126, 40);
			((DbParameter)val).Value = model.PrevID;
			obj[0] = val;
			OracleParameter val2 = new OracleParameter(":PrevStepID", 126, 40);
			((DbParameter)val2).Value = model.PrevStepID;
			obj[1] = val2;
			OracleParameter val3 = new OracleParameter(":FlowID", 126, 40);
			((DbParameter)val3).Value = model.FlowID;
			obj[2] = val3;
			OracleParameter val4 = new OracleParameter(":StepID", 126, 40);
			((DbParameter)val4).Value = model.StepID;
			obj[3] = val4;
			OracleParameter val5 = new OracleParameter(":StepName", 119, 1000);
			((DbParameter)val5).Value = model.StepName;
			obj[4] = val5;
			OracleParameter val6 = new OracleParameter(":InstanceID", 126, 50);
			((DbParameter)val6).Value = model.InstanceID;
			obj[5] = val6;
			OracleParameter val7 = new OracleParameter(":GroupID", 126, 40);
			((DbParameter)val7).Value = model.GroupID;
			obj[6] = val7;
			OracleParameter val8 = new OracleParameter(":Type", 112);
			((DbParameter)val8).Value = model.Type;
			obj[7] = val8;
			OracleParameter val9 = new OracleParameter(":Title", 119, 4000);
			((DbParameter)val9).Value = model.Title;
			obj[8] = val9;
			OracleParameter val10 = new OracleParameter(":SenderID", 126, 40);
			((DbParameter)val10).Value = model.SenderID;
			obj[9] = val10;
			OracleParameter val11 = new OracleParameter(":SenderName", 119, 100);
			((DbParameter)val11).Value = model.SenderName;
			obj[10] = val11;
			OracleParameter val12 = new OracleParameter(":SenderTime", 106, 8);
			((DbParameter)val12).Value = model.SenderTime;
			obj[11] = val12;
			OracleParameter val13 = new OracleParameter(":ReceiveID", 126, 40);
			((DbParameter)val13).Value = model.ReceiveID;
			obj[12] = val13;
			OracleParameter val14 = new OracleParameter(":ReceiveName", 119, 100);
			((DbParameter)val14).Value = model.ReceiveName;
			obj[13] = val14;
			OracleParameter val15 = new OracleParameter(":ReceiveTime", 106, 8);
			((DbParameter)val15).Value = model.ReceiveTime;
			obj[14] = val15;
			_003F val16;
			if (model.OpenTime.HasValue)
			{
				val16 = new OracleParameter(":OpenTime", 106, 8);
				((DbParameter)val16).Value = model.OpenTime;
			}
			else
			{
				val16 = new OracleParameter(":OpenTime", 106, 8);
				((DbParameter)val16).Value = DBNull.Value;
			}
			obj[15] = val16;
			_003F val17;
			if (model.CompletedTime.HasValue)
			{
				val17 = new OracleParameter(":CompletedTime", 106, 8);
				((DbParameter)val17).Value = model.CompletedTime;
			}
			else
			{
				val17 = new OracleParameter(":CompletedTime", 106, 8);
				((DbParameter)val17).Value = DBNull.Value;
			}
			obj[16] = val17;
			_003F val18;
			if (model.CompletedTime1.HasValue)
			{
				val18 = new OracleParameter(":CompletedTime1", 106, 8);
				((DbParameter)val18).Value = model.CompletedTime1;
			}
			else
			{
				val18 = new OracleParameter(":CompletedTime1", 106, 8);
				((DbParameter)val18).Value = DBNull.Value;
			}
			obj[17] = val18;
			_003F val19;
			if (model.Comment != null)
			{
				val19 = new OracleParameter(":Comment1", 119);
				((DbParameter)val19).Value = model.Comment;
			}
			else
			{
				val19 = new OracleParameter(":Comment1", 119);
				((DbParameter)val19).Value = DBNull.Value;
			}
			obj[18] = val19;
			_003F val20;
			if (model.IsSign.HasValue)
			{
				val20 = new OracleParameter(":IsSign", 112);
				((DbParameter)val20).Value = model.IsSign;
			}
			else
			{
				val20 = new OracleParameter(":IsSign", 112);
				((DbParameter)val20).Value = DBNull.Value;
			}
			obj[19] = val20;
			OracleParameter val21 = new OracleParameter(":Status", 112);
			((DbParameter)val21).Value = model.Status;
			obj[20] = val21;
			_003F val22;
			if (model.Note != null)
			{
				val22 = new OracleParameter(":Note", 119);
				((DbParameter)val22).Value = model.Note;
			}
			else
			{
				val22 = new OracleParameter(":Note", 119);
				((DbParameter)val22).Value = DBNull.Value;
			}
			obj[21] = val22;
			OracleParameter val23 = new OracleParameter(":Sort", 112);
			((DbParameter)val23).Value = model.Sort;
			obj[22] = val23;
			_003F val24;
			if (model.SubFlowGroupID != null)
			{
				val24 = new OracleParameter(":SubFlowGroupID", 126);
				((DbParameter)val24).Value = model.SubFlowGroupID;
			}
			else
			{
				val24 = new OracleParameter(":SubFlowGroupID", 126);
				((DbParameter)val24).Value = DBNull.Value;
			}
			obj[23] = val24;
			_003F val25;
			if (model.OtherType.HasValue)
			{
				val25 = new OracleParameter(":OtherType", 112);
				((DbParameter)val25).Value = model.OtherType;
			}
			else
			{
				val25 = new OracleParameter(":OtherType", 112);
				((DbParameter)val25).Value = DBNull.Value;
			}
			obj[24] = val25;
			_003F val26;
			if (model.Files != null)
			{
				val26 = new OracleParameter(":Files", 126);
				((DbParameter)val26).Value = model.Files;
			}
			else
			{
				val26 = new OracleParameter(":Files", 126);
				((DbParameter)val26).Value = DBNull.Value;
			}
			obj[25] = val26;
			OracleParameter val27 = new OracleParameter(":IsExpiredAutoSubmit", 112);
			((DbParameter)val27).Value = model.IsExpiredAutoSubmit;
			obj[26] = val27;
			OracleParameter val28 = new OracleParameter(":StepSort", 112);
			((DbParameter)val28).Value = model.StepSort;
			obj[27] = val28;
			OracleParameter val29 = new OracleParameter(":ID", 126, 40);
			((DbParameter)val29).Value = model.ID;
			obj[28] = val29;
			OracleParameter[] parameter = (OracleParameter[])obj;
			return dbHelper.Execute(sql, parameter);
		}

		public int Delete(Guid id)
		{
			//IL_0015: Unknown result type (might be due to invalid IL or missing references)
			//IL_001a: Unknown result type (might be due to invalid IL or missing references)
			//IL_0026: Expected O, but got Unknown
			//IL_0027: Expected O, but got Unknown
			string sql = "DELETE FROM WorkFlowTask WHERE ID=:ID";
			OracleParameter[] obj = new OracleParameter[1];
			OracleParameter val = new OracleParameter(":ID", 126);
			((DbParameter)val).Value = id;
			obj[0] = val;
			OracleParameter[] parameter = (OracleParameter[])obj;
			return dbHelper.Execute(sql, parameter);
		}

		private List<RoadFlow.Data.Model.WorkFlowTask> DataReaderToList(OracleDataReader dataReader)
		{
			List<RoadFlow.Data.Model.WorkFlowTask> list = new List<RoadFlow.Data.Model.WorkFlowTask>();
			RoadFlow.Data.Model.WorkFlowTask workFlowTask = null;
			while (((DbDataReader)dataReader).Read())
			{
				workFlowTask = new RoadFlow.Data.Model.WorkFlowTask();
				workFlowTask.ID = ((DbDataReader)dataReader).GetString(0).ToGuid();
				workFlowTask.PrevID = ((DbDataReader)dataReader).GetString(1).ToGuid();
				workFlowTask.PrevStepID = ((DbDataReader)dataReader).GetString(2).ToGuid();
				workFlowTask.FlowID = ((DbDataReader)dataReader).GetString(3).ToGuid();
				workFlowTask.StepID = ((DbDataReader)dataReader).GetString(4).ToGuid();
				workFlowTask.StepName = ((DbDataReader)dataReader).GetString(5);
				workFlowTask.InstanceID = ((DbDataReader)dataReader).GetString(6);
				workFlowTask.GroupID = ((DbDataReader)dataReader).GetString(7).ToGuid();
				workFlowTask.Type = ((DbDataReader)dataReader).GetInt32(8);
				workFlowTask.Title = ((DbDataReader)dataReader).GetString(9);
				workFlowTask.SenderID = ((DbDataReader)dataReader).GetString(10).ToGuid();
				workFlowTask.SenderName = ((DbDataReader)dataReader).GetString(11);
				workFlowTask.SenderTime = ((DbDataReader)dataReader).GetDateTime(12);
				workFlowTask.ReceiveID = ((DbDataReader)dataReader).GetString(13).ToGuid();
				workFlowTask.ReceiveName = ((DbDataReader)dataReader).GetString(14);
				workFlowTask.ReceiveTime = ((DbDataReader)dataReader).GetDateTime(15);
				if (!((DbDataReader)dataReader).IsDBNull(16))
				{
					workFlowTask.OpenTime = ((DbDataReader)dataReader).GetDateTime(16);
				}
				if (!((DbDataReader)dataReader).IsDBNull(17))
				{
					workFlowTask.CompletedTime = ((DbDataReader)dataReader).GetDateTime(17);
				}
				if (!((DbDataReader)dataReader).IsDBNull(18))
				{
					workFlowTask.CompletedTime1 = ((DbDataReader)dataReader).GetDateTime(18);
				}
				if (!((DbDataReader)dataReader).IsDBNull(19))
				{
					workFlowTask.Comment = ((DbDataReader)dataReader).GetString(19);
				}
				if (!((DbDataReader)dataReader).IsDBNull(20))
				{
					workFlowTask.IsSign = ((DbDataReader)dataReader).GetInt32(20);
				}
				workFlowTask.Status = ((DbDataReader)dataReader).GetInt32(21);
				if (!((DbDataReader)dataReader).IsDBNull(22))
				{
					workFlowTask.Note = ((DbDataReader)dataReader).GetString(22);
				}
				workFlowTask.Sort = ((DbDataReader)dataReader).GetInt32(23);
				if (!((DbDataReader)dataReader).IsDBNull(24))
				{
					workFlowTask.SubFlowGroupID = ((DbDataReader)dataReader).GetString(24);
				}
				if (!((DbDataReader)dataReader).IsDBNull(25))
				{
					workFlowTask.OtherType = ((DbDataReader)dataReader).GetInt32(25);
				}
				if (!((DbDataReader)dataReader).IsDBNull(26))
				{
					workFlowTask.Files = ((DbDataReader)dataReader).GetString(26);
				}
				workFlowTask.IsExpiredAutoSubmit = ((DbDataReader)dataReader).GetInt32(27);
				workFlowTask.StepSort = ((DbDataReader)dataReader).GetInt32(28);
				list.Add(workFlowTask);
			}
			return list;
		}

		public List<RoadFlow.Data.Model.WorkFlowTask> GetAll()
		{
			string sql = "SELECT * FROM WorkFlowTask";
			OracleDataReader dataReader = dbHelper.GetDataReader(sql);
			List<RoadFlow.Data.Model.WorkFlowTask> result = DataReaderToList(dataReader);
			((DbDataReader)dataReader).Close();
			return result;
		}

		public long GetCount()
		{
			string sql = "SELECT COUNT(*) FROM WorkFlowTask";
			long result;
			if (!long.TryParse(dbHelper.GetFieldValue(sql), out result))
			{
				return 0L;
			}
			return result;
		}

		public RoadFlow.Data.Model.WorkFlowTask Get(Guid id)
		{
			//IL_0015: Unknown result type (might be due to invalid IL or missing references)
			//IL_001a: Unknown result type (might be due to invalid IL or missing references)
			//IL_0026: Expected O, but got Unknown
			//IL_0027: Expected O, but got Unknown
			string sql = "SELECT * FROM WorkFlowTask WHERE ID=:ID";
			OracleParameter[] obj = new OracleParameter[1];
			OracleParameter val = new OracleParameter(":ID", 126);
			((DbParameter)val).Value = id;
			obj[0] = val;
			OracleParameter[] parameter = (OracleParameter[])obj;
			OracleDataReader dataReader = dbHelper.GetDataReader(sql, parameter);
			List<RoadFlow.Data.Model.WorkFlowTask> list = DataReaderToList(dataReader);
			((DbDataReader)dataReader).Close();
			if (list.Count <= 0)
			{
				return null;
			}
			return list[0];
		}

		public int Delete(Guid flowID, Guid groupID)
		{
			//IL_0013: Unknown result type (might be due to invalid IL or missing references)
			//IL_0018: Unknown result type (might be due to invalid IL or missing references)
			//IL_0024: Expected O, but got Unknown
			//IL_0029: Expected O, but got Unknown
			//IL_0046: Unknown result type (might be due to invalid IL or missing references)
			//IL_004b: Unknown result type (might be due to invalid IL or missing references)
			//IL_0057: Expected O, but got Unknown
			//IL_005c: Expected O, but got Unknown
			string text = "DELETE FROM WorkFlowTask WHERE GroupID=:GroupID";
			List<OracleParameter> list = new List<OracleParameter>();
			OracleParameter val = new OracleParameter(":GroupID", 126);
			((DbParameter)val).Value = groupID;
			list.Add(val);
			List<OracleParameter> list2 = list;
			if (!flowID.IsEmptyGuid())
			{
				text += " AND FlowID=:FlowID";
				List<OracleParameter> list3 = list2;
				OracleParameter val2 = new OracleParameter(":FlowID", 126);
				((DbParameter)val2).Value = flowID;
				list3.Add(val2);
			}
			return dbHelper.Execute(text, list2.ToArray());
		}

		public void UpdateOpenTime(Guid id, DateTime openTime, bool isStatus = false)
		{
			//IL_003b: Unknown result type (might be due to invalid IL or missing references)
			//IL_0040: Unknown result type (might be due to invalid IL or missing references)
			//IL_004c: Expected O, but got Unknown
			//IL_0055: Unknown result type (might be due to invalid IL or missing references)
			//IL_005a: Unknown result type (might be due to invalid IL or missing references)
			//IL_0065: Expected O, but got Unknown
			//IL_0066: Expected O, but got Unknown
			//IL_006f: Unknown result type (might be due to invalid IL or missing references)
			//IL_0074: Unknown result type (might be due to invalid IL or missing references)
			//IL_0080: Expected O, but got Unknown
			//IL_0081: Expected O, but got Unknown
			string sql = "UPDATE WorkFlowTask SET OpenTime=:OpenTime " + (isStatus ? ", Status=1" : "") + " WHERE ID=:ID AND OpenTime IS NULL";
			OracleParameter[] obj = new OracleParameter[2];
			_003F val;
			if (!(openTime == DateTime.MinValue))
			{
				val = new OracleParameter(":OpenTime", 106);
				((DbParameter)val).Value = openTime;
			}
			else
			{
				val = new OracleParameter(":OpenTime", 106);
				((DbParameter)val).Value = DBNull.Value;
			}
			obj[0] = val;
			OracleParameter val2 = new OracleParameter(":ID", 126);
			((DbParameter)val2).Value = id;
			obj[1] = val2;
			OracleParameter[] parameter = (OracleParameter[])obj;
			dbHelper.Execute(sql, parameter);
		}

		public List<RoadFlow.Data.Model.WorkFlowTask> GetTasks(Guid userID, out string pager, string query = "", string title = "", string flowid = "", string sender = "", string date1 = "", string date2 = "", int type = 0)
		{
			//IL_0030: Unknown result type (might be due to invalid IL or missing references)
			//IL_0035: Unknown result type (might be due to invalid IL or missing references)
			//IL_0041: Expected O, but got Unknown
			//IL_0046: Expected O, but got Unknown
			//IL_0068: Unknown result type (might be due to invalid IL or missing references)
			//IL_006d: Unknown result type (might be due to invalid IL or missing references)
			//IL_0075: Expected O, but got Unknown
			//IL_007a: Expected O, but got Unknown
			//IL_0097: Unknown result type (might be due to invalid IL or missing references)
			//IL_009c: Unknown result type (might be due to invalid IL or missing references)
			//IL_00ae: Expected O, but got Unknown
			//IL_00b3: Expected O, but got Unknown
			//IL_010a: Unknown result type (might be due to invalid IL or missing references)
			//IL_010f: Unknown result type (might be due to invalid IL or missing references)
			//IL_0121: Expected O, but got Unknown
			//IL_0126: Expected O, but got Unknown
			//IL_0143: Unknown result type (might be due to invalid IL or missing references)
			//IL_0148: Unknown result type (might be due to invalid IL or missing references)
			//IL_0163: Expected O, but got Unknown
			//IL_0168: Expected O, but got Unknown
			//IL_0185: Unknown result type (might be due to invalid IL or missing references)
			//IL_018a: Unknown result type (might be due to invalid IL or missing references)
			//IL_01b7: Expected O, but got Unknown
			//IL_01bc: Expected O, but got Unknown
			List<OracleParameter> list = new List<OracleParameter>();
			StringBuilder stringBuilder = new StringBuilder("SELECT PagerTempTable.*,ROWNUM AS PagerAutoRowNumber FROM(SELECT * FROM WorkFlowTask WHERE ReceiveID=:ReceiveID ");
			stringBuilder.Append((type == 0) ? " AND Status IN(0,1)" : " AND Status IN(2,3,4,5)");
			List<OracleParameter> list2 = list;
			OracleParameter val = new OracleParameter(":ReceiveID", 126);
			((DbParameter)val).Value = userID;
			list2.Add(val);
			if (!title.IsNullOrEmpty())
			{
				stringBuilder.Append(" AND INSTR(Title,:Title,1,1)>0");
				List<OracleParameter> list3 = list;
				OracleParameter val2 = new OracleParameter(":Title", 119, 2000);
				((DbParameter)val2).Value = title;
				list3.Add(val2);
			}
			if (flowid.IsGuid())
			{
				stringBuilder.Append(" AND FlowID=:FlowID");
				List<OracleParameter> list4 = list;
				OracleParameter val3 = new OracleParameter(":FlowID", 126);
				((DbParameter)val3).Value = flowid.ToGuid();
				list4.Add(val3);
			}
			else if (!flowid.IsNullOrEmpty() && flowid.IndexOf(',') >= 0)
			{
				stringBuilder.Append(" AND FlowID IN(" + Tools.GetSqlInString(flowid) + ")");
			}
			if (sender.IsGuid())
			{
				stringBuilder.Append(" AND SenderID=:SenderID");
				List<OracleParameter> list5 = list;
				OracleParameter val4 = new OracleParameter(":SenderID", 126);
				((DbParameter)val4).Value = sender.ToGuid();
				list5.Add(val4);
			}
			if (date1.IsDateTime())
			{
				stringBuilder.Append(" AND ReceiveTime>=:ReceiveTime");
				List<OracleParameter> list6 = list;
				OracleParameter val5 = new OracleParameter(":ReceiveTime", 106);
				((DbParameter)val5).Value = date1.ToDateTime().Date;
				list6.Add(val5);
			}
			if (date2.IsDateTime())
			{
				stringBuilder.Append(" AND ReceiveTime<=:ReceiveTime1");
				List<OracleParameter> list7 = list;
				OracleParameter val6 = new OracleParameter(":ReceiveTime1", 106);
				((DbParameter)val6).Value = date2.ToDateTime().AddDays(1.0).Date;
				list7.Add(val6);
			}
			stringBuilder.Append(" ORDER BY " + ((type == 0) ? "ReceiveTime DESC" : "CompletedTime1 DESC") + ") PagerTempTable");
			int pageSize = Tools.GetPageSize();
			int pageNumber = Tools.GetPageNumber();
			long count;
			string paerSql = dbHelper.GetPaerSql(stringBuilder.ToString(), pageSize, pageNumber, out count, list.ToArray());
			pager = Tools.GetPagerHtml(count, pageSize, pageNumber, query);
			OracleDataReader dataReader = dbHelper.GetDataReader(paerSql, list.ToArray());
			List<RoadFlow.Data.Model.WorkFlowTask> result = DataReaderToList(dataReader);
			((DbDataReader)dataReader).Close();
			return result;
		}

		public List<RoadFlow.Data.Model.WorkFlowTask> GetTasks(Guid userID, out long count, int size, int number, string title = "", string flowid = "", string sender = "", string date1 = "", string date2 = "", int type = 0, string order = "")
		{
			//IL_0030: Unknown result type (might be due to invalid IL or missing references)
			//IL_0035: Unknown result type (might be due to invalid IL or missing references)
			//IL_0041: Expected O, but got Unknown
			//IL_0046: Expected O, but got Unknown
			//IL_0068: Unknown result type (might be due to invalid IL or missing references)
			//IL_006d: Unknown result type (might be due to invalid IL or missing references)
			//IL_0075: Expected O, but got Unknown
			//IL_007a: Expected O, but got Unknown
			//IL_0097: Unknown result type (might be due to invalid IL or missing references)
			//IL_009c: Unknown result type (might be due to invalid IL or missing references)
			//IL_00ae: Expected O, but got Unknown
			//IL_00b3: Expected O, but got Unknown
			//IL_010a: Unknown result type (might be due to invalid IL or missing references)
			//IL_010f: Unknown result type (might be due to invalid IL or missing references)
			//IL_0121: Expected O, but got Unknown
			//IL_0126: Expected O, but got Unknown
			//IL_0143: Unknown result type (might be due to invalid IL or missing references)
			//IL_0148: Unknown result type (might be due to invalid IL or missing references)
			//IL_0163: Expected O, but got Unknown
			//IL_0168: Expected O, but got Unknown
			//IL_0185: Unknown result type (might be due to invalid IL or missing references)
			//IL_018a: Unknown result type (might be due to invalid IL or missing references)
			//IL_01b7: Expected O, but got Unknown
			//IL_01bc: Expected O, but got Unknown
			List<OracleParameter> list = new List<OracleParameter>();
			StringBuilder stringBuilder = new StringBuilder("SELECT PagerTempTable.*,ROWNUM AS PagerAutoRowNumber FROM(SELECT * FROM WorkFlowTask WHERE ReceiveID=:ReceiveID ");
			stringBuilder.Append((type == 0) ? " AND Status IN(0,1)" : " AND Status IN(2,3,4,5)");
			List<OracleParameter> list2 = list;
			OracleParameter val = new OracleParameter(":ReceiveID", 126);
			((DbParameter)val).Value = userID;
			list2.Add(val);
			if (!title.IsNullOrEmpty())
			{
				stringBuilder.Append(" AND INSTR(Title,:Title,1,1)>0");
				List<OracleParameter> list3 = list;
				OracleParameter val2 = new OracleParameter(":Title", 119, 2000);
				((DbParameter)val2).Value = title;
				list3.Add(val2);
			}
			if (flowid.IsGuid())
			{
				stringBuilder.Append(" AND FlowID=:FlowID");
				List<OracleParameter> list4 = list;
				OracleParameter val3 = new OracleParameter(":FlowID", 126);
				((DbParameter)val3).Value = flowid.ToGuid();
				list4.Add(val3);
			}
			else if (!flowid.IsNullOrEmpty() && flowid.IndexOf(',') >= 0)
			{
				stringBuilder.Append(" AND FlowID IN(" + Tools.GetSqlInString(flowid) + ")");
			}
			if (sender.IsGuid())
			{
				stringBuilder.Append(" AND SenderID=:SenderID");
				List<OracleParameter> list5 = list;
				OracleParameter val4 = new OracleParameter(":SenderID", 126);
				((DbParameter)val4).Value = sender.ToGuid();
				list5.Add(val4);
			}
			if (date1.IsDateTime())
			{
				stringBuilder.Append(" AND ReceiveTime>=:ReceiveTime");
				List<OracleParameter> list6 = list;
				OracleParameter val5 = new OracleParameter(":ReceiveTime", 106);
				((DbParameter)val5).Value = date1.ToDateTime().Date;
				list6.Add(val5);
			}
			if (date2.IsDateTime())
			{
				stringBuilder.Append(" AND ReceiveTime<=:ReceiveTime1");
				List<OracleParameter> list7 = list;
				OracleParameter val6 = new OracleParameter(":ReceiveTime1", 106);
				((DbParameter)val6).Value = date2.ToDateTime().AddDays(1.0).Date;
				list7.Add(val6);
			}
			stringBuilder.Append(" ORDER BY " + ((!order.IsNullOrEmpty()) ? order : ((type == 0) ? "ReceiveTime DESC" : "CompletedTime1 DESC")) + ") PagerTempTable");
			string paerSql = dbHelper.GetPaerSql(stringBuilder.ToString(), size, number, out count, list.ToArray());
			OracleDataReader dataReader = dbHelper.GetDataReader(paerSql, list.ToArray());
			List<RoadFlow.Data.Model.WorkFlowTask> result = DataReaderToList(dataReader);
			((DbDataReader)dataReader).Close();
			return result;
		}

		public List<RoadFlow.Data.Model.WorkFlowTask> GetInstances(Guid[] flowID, Guid[] senderID, Guid[] receiveID, out string pager, string query = "", string title = "", string flowid = "", string date1 = "", string date2 = "", int status = 0)
		{
			//IL_0079: Unknown result type (might be due to invalid IL or missing references)
			//IL_007e: Unknown result type (might be due to invalid IL or missing references)
			//IL_0090: Expected O, but got Unknown
			//IL_0095: Expected O, but got Unknown
			//IL_00d0: Unknown result type (might be due to invalid IL or missing references)
			//IL_00d5: Unknown result type (might be due to invalid IL or missing references)
			//IL_00e7: Expected O, but got Unknown
			//IL_00ec: Expected O, but got Unknown
			//IL_0128: Unknown result type (might be due to invalid IL or missing references)
			//IL_012d: Unknown result type (might be due to invalid IL or missing references)
			//IL_0135: Expected O, but got Unknown
			//IL_013a: Expected O, but got Unknown
			//IL_0157: Unknown result type (might be due to invalid IL or missing references)
			//IL_015c: Unknown result type (might be due to invalid IL or missing references)
			//IL_016e: Expected O, but got Unknown
			//IL_0173: Expected O, but got Unknown
			//IL_01ca: Unknown result type (might be due to invalid IL or missing references)
			//IL_01cf: Unknown result type (might be due to invalid IL or missing references)
			//IL_01ea: Expected O, but got Unknown
			//IL_01ef: Expected O, but got Unknown
			//IL_020c: Unknown result type (might be due to invalid IL or missing references)
			//IL_0211: Unknown result type (might be due to invalid IL or missing references)
			//IL_023e: Expected O, but got Unknown
			//IL_0243: Expected O, but got Unknown
			List<OracleParameter> list = new List<OracleParameter>();
			StringBuilder stringBuilder = new StringBuilder("SELECT a.*,ROW_NUMBER() OVER(ORDER BY a.SenderTime DESC) PagerAutoRowNumber FROM WorkFlowTask a\r\n                WHERE a.ID=(SELECT ID FROM RF_WORKFLOWTASK WHERE GroupID=a.GroupID AND sort=(select MAX(sort) from RF_WORKFLOWTASK where GroupID=a.GROUPID) AND ROWNUM=1)");
			switch (status)
			{
			case 1:
				stringBuilder.Append(" AND a.Status IN(0,1,5)");
				break;
			case 2:
				stringBuilder.Append(" AND a.Status IN(2,3,4)");
				break;
			}
			if (flowID != null && flowID.Length != 0)
			{
				stringBuilder.Append(string.Format(" AND a.FlowID IN({0})", Tools.GetSqlInString(flowID)));
			}
			if (senderID != null && senderID.Length != 0)
			{
				if (senderID.Length == 1)
				{
					stringBuilder.Append(" AND a.SenderID=:SenderID");
					List<OracleParameter> list2 = list;
					OracleParameter val = new OracleParameter(":SenderID", 126);
					((DbParameter)val).Value = senderID[0];
					list2.Add(val);
				}
				else
				{
					stringBuilder.Append(string.Format(" AND a.SenderID IN({0})", Tools.GetSqlInString(senderID)));
				}
			}
			if (receiveID != null && receiveID.Length != 0)
			{
				if (senderID.Length == 1)
				{
					stringBuilder.Append(" AND a.ReceiveID=:ReceiveID");
					List<OracleParameter> list3 = list;
					OracleParameter val2 = new OracleParameter(":ReceiveID", 126);
					((DbParameter)val2).Value = receiveID[0];
					list3.Add(val2);
				}
				else
				{
					stringBuilder.Append(string.Format(" AND a.ReceiveID IN({0})", Tools.GetSqlInString(receiveID)));
				}
			}
			if (!title.IsNullOrEmpty())
			{
				stringBuilder.Append(" AND INSTR(a.Title,:Title,1,1)>0");
				List<OracleParameter> list4 = list;
				OracleParameter val3 = new OracleParameter(":Title", 119, 2000);
				((DbParameter)val3).Value = title;
				list4.Add(val3);
			}
			if (flowid.IsGuid())
			{
				stringBuilder.Append(" AND a.FlowID=:FlowID");
				List<OracleParameter> list5 = list;
				OracleParameter val4 = new OracleParameter(":FlowID", 126);
				((DbParameter)val4).Value = flowid.ToGuid();
				list5.Add(val4);
			}
			else if (!flowid.IsNullOrEmpty() && flowid.IndexOf(',') >= 0)
			{
				stringBuilder.Append(" AND a.FlowID IN(" + Tools.GetSqlInString(flowid) + ")");
			}
			if (date1.IsDateTime())
			{
				stringBuilder.Append(" AND a.SenderTime>=:SenderTime");
				List<OracleParameter> list6 = list;
				OracleParameter val5 = new OracleParameter(":SenderTime", 106);
				((DbParameter)val5).Value = date1.ToDateTime().Date;
				list6.Add(val5);
			}
			if (date2.IsDateTime())
			{
				stringBuilder.Append(" AND a.SenderTime<=:SenderTime1");
				List<OracleParameter> list7 = list;
				OracleParameter val6 = new OracleParameter(":SenderTime1", 106);
				((DbParameter)val6).Value = date2.ToDateTime().AddDays(1.0).Date;
				list7.Add(val6);
			}
			stringBuilder.Append(" AND ROWNUM<=1) ORDER BY Sort DESC) PagerTempTable");
			int pageSize = Tools.GetPageSize();
			int pageNumber = Tools.GetPageNumber();
			long count;
			string paerSql = dbHelper.GetPaerSql(stringBuilder.ToString(), pageSize, pageNumber, out count, list.ToArray());
			pager = Tools.GetPagerHtml(count, pageSize, pageNumber, query);
			OracleDataReader dataReader = dbHelper.GetDataReader(paerSql, list.ToArray());
			List<RoadFlow.Data.Model.WorkFlowTask> result = DataReaderToList(dataReader);
			((DbDataReader)dataReader).Close();
			return result;
		}

		public DataTable GetInstances1(Guid[] flowID, Guid[] senderID, Guid[] receiveID, out string pager, string query = "", string title = "", string flowid = "", string date1 = "", string date2 = "", int status = 0)
		{
			//IL_0074: Unknown result type (might be due to invalid IL or missing references)
			//IL_0079: Unknown result type (might be due to invalid IL or missing references)
			//IL_008b: Expected O, but got Unknown
			//IL_0090: Expected O, but got Unknown
			//IL_00cb: Unknown result type (might be due to invalid IL or missing references)
			//IL_00d0: Unknown result type (might be due to invalid IL or missing references)
			//IL_00e2: Expected O, but got Unknown
			//IL_00e7: Expected O, but got Unknown
			//IL_0123: Unknown result type (might be due to invalid IL or missing references)
			//IL_0128: Unknown result type (might be due to invalid IL or missing references)
			//IL_0130: Expected O, but got Unknown
			//IL_0135: Expected O, but got Unknown
			//IL_0152: Unknown result type (might be due to invalid IL or missing references)
			//IL_0157: Unknown result type (might be due to invalid IL or missing references)
			//IL_0169: Expected O, but got Unknown
			//IL_016e: Expected O, but got Unknown
			//IL_01c5: Unknown result type (might be due to invalid IL or missing references)
			//IL_01ca: Unknown result type (might be due to invalid IL or missing references)
			//IL_01e5: Expected O, but got Unknown
			//IL_01ea: Expected O, but got Unknown
			//IL_0207: Unknown result type (might be due to invalid IL or missing references)
			//IL_020c: Unknown result type (might be due to invalid IL or missing references)
			//IL_0239: Expected O, but got Unknown
			//IL_023e: Expected O, but got Unknown
			List<OracleParameter> list = new List<OracleParameter>();
			StringBuilder stringBuilder = new StringBuilder();
			switch (status)
			{
			case 1:
				stringBuilder.Append(" AND Status IN(0,1,5)");
				break;
			case 2:
				stringBuilder.Append(" AND Status IN(2,3,4)");
				break;
			}
			if (flowID != null && flowID.Length != 0)
			{
				stringBuilder.Append(string.Format(" AND FlowID IN({0})", Tools.GetSqlInString(flowID)));
			}
			if (senderID != null && senderID.Length != 0)
			{
				if (senderID.Length == 1)
				{
					stringBuilder.Append(" AND SenderID=:SenderID");
					List<OracleParameter> list2 = list;
					OracleParameter val = new OracleParameter(":SenderID", 126);
					((DbParameter)val).Value = senderID[0];
					list2.Add(val);
				}
				else
				{
					stringBuilder.Append(string.Format(" AND SenderID IN({0})", Tools.GetSqlInString(senderID)));
				}
			}
			if (receiveID != null && receiveID.Length != 0)
			{
				if (senderID.Length == 1)
				{
					stringBuilder.Append(" AND ReceiveID=:ReceiveID");
					List<OracleParameter> list3 = list;
					OracleParameter val2 = new OracleParameter(":ReceiveID", 126);
					((DbParameter)val2).Value = receiveID[0];
					list3.Add(val2);
				}
				else
				{
					stringBuilder.Append(string.Format(" AND ReceiveID IN({0})", Tools.GetSqlInString(receiveID)));
				}
			}
			if (!title.IsNullOrEmpty())
			{
				stringBuilder.Append(" AND INSTR(Title,:Title,1,1)>0");
				List<OracleParameter> list4 = list;
				OracleParameter val3 = new OracleParameter(":Title", 119, 2000);
				((DbParameter)val3).Value = title;
				list4.Add(val3);
			}
			if (flowid.IsGuid())
			{
				stringBuilder.Append(" AND FlowID=:FlowID");
				List<OracleParameter> list5 = list;
				OracleParameter val4 = new OracleParameter(":FlowID", 126);
				((DbParameter)val4).Value = flowid.ToGuid();
				list5.Add(val4);
			}
			else if (!flowid.IsNullOrEmpty() && flowid.IndexOf(',') >= 0)
			{
				stringBuilder.Append(" AND FlowID IN(" + Tools.GetSqlInString(flowid) + ")");
			}
			if (date1.IsDateTime())
			{
				stringBuilder.Append(" AND SenderTime>=:SenderTime");
				List<OracleParameter> list6 = list;
				OracleParameter val5 = new OracleParameter(":SenderTime", 106);
				((DbParameter)val5).Value = date1.ToDateTime().Date;
				list6.Add(val5);
			}
			if (date2.IsDateTime())
			{
				stringBuilder.Append(" AND SenderTime<=:SenderTime1");
				List<OracleParameter> list7 = list;
				OracleParameter val6 = new OracleParameter(":SenderTime1", 106);
				((DbParameter)val6).Value = date2.ToDateTime().AddDays(1.0).Date;
				list7.Add(val6);
			}
			string sql = string.Format("select PagerTempTable.*,ROWNUM AS PagerAutoRowNumber FROM(\r\nselect flowid,groupid,MAX(SenderTime) SenderTime from WorkFlowTask where 1=1 {0} group by FlowID, GroupID\r\n) PagerTempTable", stringBuilder.ToString());
			int pageSize = Tools.GetPageSize();
			int pageNumber = Tools.GetPageNumber();
			long count;
			string paerSql = dbHelper.GetPaerSql(sql, pageSize, pageNumber, out count, list.ToArray());
			pager = Tools.GetPagerHtml(count, pageSize, pageNumber, query);
			return dbHelper.GetDataTable(paerSql, list.ToArray());
		}

		public DataTable GetInstances1(Guid[] flowID, Guid[] senderID, Guid[] receiveID, out long count, int size, int number, string title = "", string flowid = "", string date1 = "", string date2 = "", int status = 0, string order = "")
		{
			//IL_0074: Unknown result type (might be due to invalid IL or missing references)
			//IL_0079: Unknown result type (might be due to invalid IL or missing references)
			//IL_008b: Expected O, but got Unknown
			//IL_0090: Expected O, but got Unknown
			//IL_00cb: Unknown result type (might be due to invalid IL or missing references)
			//IL_00d0: Unknown result type (might be due to invalid IL or missing references)
			//IL_00e2: Expected O, but got Unknown
			//IL_00e7: Expected O, but got Unknown
			//IL_0123: Unknown result type (might be due to invalid IL or missing references)
			//IL_0128: Unknown result type (might be due to invalid IL or missing references)
			//IL_0130: Expected O, but got Unknown
			//IL_0135: Expected O, but got Unknown
			//IL_0152: Unknown result type (might be due to invalid IL or missing references)
			//IL_0157: Unknown result type (might be due to invalid IL or missing references)
			//IL_0169: Expected O, but got Unknown
			//IL_016e: Expected O, but got Unknown
			//IL_01c5: Unknown result type (might be due to invalid IL or missing references)
			//IL_01ca: Unknown result type (might be due to invalid IL or missing references)
			//IL_01e5: Expected O, but got Unknown
			//IL_01ea: Expected O, but got Unknown
			//IL_0207: Unknown result type (might be due to invalid IL or missing references)
			//IL_020c: Unknown result type (might be due to invalid IL or missing references)
			//IL_0239: Expected O, but got Unknown
			//IL_023e: Expected O, but got Unknown
			List<OracleParameter> list = new List<OracleParameter>();
			StringBuilder stringBuilder = new StringBuilder();
			switch (status)
			{
			case 1:
				stringBuilder.Append(" AND Status IN(0,1,5)");
				break;
			case 2:
				stringBuilder.Append(" AND Status IN(2,3,4)");
				break;
			}
			if (flowID != null && flowID.Length != 0)
			{
				stringBuilder.Append(string.Format(" AND FlowID IN({0})", Tools.GetSqlInString(flowID)));
			}
			if (senderID != null && senderID.Length != 0)
			{
				if (senderID.Length == 1)
				{
					stringBuilder.Append(" AND SenderID=:SenderID");
					List<OracleParameter> list2 = list;
					OracleParameter val = new OracleParameter(":SenderID", 126);
					((DbParameter)val).Value = senderID[0];
					list2.Add(val);
				}
				else
				{
					stringBuilder.Append(string.Format(" AND SenderID IN({0})", Tools.GetSqlInString(senderID)));
				}
			}
			if (receiveID != null && receiveID.Length != 0)
			{
				if (senderID.Length == 1)
				{
					stringBuilder.Append(" AND ReceiveID=:ReceiveID");
					List<OracleParameter> list3 = list;
					OracleParameter val2 = new OracleParameter(":ReceiveID", 126);
					((DbParameter)val2).Value = receiveID[0];
					list3.Add(val2);
				}
				else
				{
					stringBuilder.Append(string.Format(" AND ReceiveID IN({0})", Tools.GetSqlInString(receiveID)));
				}
			}
			if (!title.IsNullOrEmpty())
			{
				stringBuilder.Append(" AND INSTR(Title,:Title,1,1)>0");
				List<OracleParameter> list4 = list;
				OracleParameter val3 = new OracleParameter(":Title", 119, 2000);
				((DbParameter)val3).Value = title;
				list4.Add(val3);
			}
			if (flowid.IsGuid())
			{
				stringBuilder.Append(" AND FlowID=:FlowID");
				List<OracleParameter> list5 = list;
				OracleParameter val4 = new OracleParameter(":FlowID", 126);
				((DbParameter)val4).Value = flowid.ToGuid();
				list5.Add(val4);
			}
			else if (!flowid.IsNullOrEmpty() && flowid.IndexOf(',') >= 0)
			{
				stringBuilder.Append(" AND FlowID IN(" + Tools.GetSqlInString(flowid) + ")");
			}
			if (date1.IsDateTime())
			{
				stringBuilder.Append(" AND SenderTime>=:SenderTime");
				List<OracleParameter> list6 = list;
				OracleParameter val5 = new OracleParameter(":SenderTime", 106);
				((DbParameter)val5).Value = date1.ToDateTime().Date;
				list6.Add(val5);
			}
			if (date2.IsDateTime())
			{
				stringBuilder.Append(" AND SenderTime<=:SenderTime1");
				List<OracleParameter> list7 = list;
				OracleParameter val6 = new OracleParameter(":SenderTime1", 106);
				((DbParameter)val6).Value = date2.ToDateTime().AddDays(1.0).Date;
				list7.Add(val6);
			}
			string sql = string.Format("select PagerTempTable.*,ROWNUM AS PagerAutoRowNumber FROM(select flowid,groupid,MAX(SenderTime) SenderTime \r\n            from WorkFlowTask where 1=1 {0} group by FlowID, GroupID ORDER BY " + (order.IsNullOrEmpty() ? "SenderTime DESC" : order) + ") PagerTempTable", stringBuilder.ToString());
			string paerSql = dbHelper.GetPaerSql(sql, size, number, out count, list.ToArray());
			return dbHelper.GetDataTable(paerSql, list.ToArray());
		}

		public Guid GetFirstSnderID(Guid flowID, Guid groupID)
		{
			//IL_0015: Unknown result type (might be due to invalid IL or missing references)
			//IL_001a: Unknown result type (might be due to invalid IL or missing references)
			//IL_0026: Expected O, but got Unknown
			//IL_0027: Expected O, but got Unknown
			//IL_0030: Unknown result type (might be due to invalid IL or missing references)
			//IL_0035: Unknown result type (might be due to invalid IL or missing references)
			//IL_0041: Expected O, but got Unknown
			//IL_0042: Expected O, but got Unknown
			//IL_004b: Unknown result type (might be due to invalid IL or missing references)
			//IL_0050: Unknown result type (might be due to invalid IL or missing references)
			//IL_0060: Expected O, but got Unknown
			//IL_0061: Expected O, but got Unknown
			string sql = "SELECT SenderID FROM WorkFlowTask WHERE FlowID=:FlowID AND GroupID=:GroupID AND PrevID=:PrevID";
			OracleParameter[] obj = new OracleParameter[3];
			OracleParameter val = new OracleParameter(":FlowID", 126);
			((DbParameter)val).Value = flowID;
			obj[0] = val;
			OracleParameter val2 = new OracleParameter(":GroupID", 126);
			((DbParameter)val2).Value = groupID;
			obj[1] = val2;
			OracleParameter val3 = new OracleParameter(":PrevID", 126);
			((DbParameter)val3).Value = Guid.Empty;
			obj[2] = val3;
			OracleParameter[] parameter = (OracleParameter[])obj;
			return dbHelper.GetFieldValue(sql, parameter).ToGuid();
		}

		public List<Guid> GetStepSnderID(Guid flowID, Guid stepID, Guid groupID)
		{
			//IL_0015: Unknown result type (might be due to invalid IL or missing references)
			//IL_001a: Unknown result type (might be due to invalid IL or missing references)
			//IL_0026: Expected O, but got Unknown
			//IL_0027: Expected O, but got Unknown
			//IL_0030: Unknown result type (might be due to invalid IL or missing references)
			//IL_0035: Unknown result type (might be due to invalid IL or missing references)
			//IL_0041: Expected O, but got Unknown
			//IL_0042: Expected O, but got Unknown
			//IL_004b: Unknown result type (might be due to invalid IL or missing references)
			//IL_0050: Unknown result type (might be due to invalid IL or missing references)
			//IL_005c: Expected O, but got Unknown
			//IL_005d: Expected O, but got Unknown
			string sql = "SELECT ReceiveID FROM WorkFlowTask WHERE FlowID=:FlowID AND StepID=:StepID AND GroupID=:GroupID AND Sort=(SELECT ISNULL(MAX(Sort),0) FROM WorkFlowTask WHERE FlowID=:FlowID AND StepID=:StepID AND GroupID=:GroupID)";
			OracleParameter[] obj = new OracleParameter[3];
			OracleParameter val = new OracleParameter(":FlowID", 126);
			((DbParameter)val).Value = flowID;
			obj[0] = val;
			OracleParameter val2 = new OracleParameter(":StepID", 126);
			((DbParameter)val2).Value = stepID;
			obj[1] = val2;
			OracleParameter val3 = new OracleParameter(":GroupID", 126);
			((DbParameter)val3).Value = groupID;
			obj[2] = val3;
			OracleParameter[] parameter = (OracleParameter[])obj;
			DataTable dataTable = dbHelper.GetDataTable(sql, parameter);
			List<Guid> list = new List<Guid>();
			foreach (DataRow row in dataTable.Rows)
			{
				Guid result;
				if (Guid.TryParse(row[0].ToString(), out result))
				{
					list.Add(result);
				}
			}
			return list;
		}

		public List<Guid> GetPrevSnderID(Guid flowID, Guid stepID, Guid groupID)
		{
			//IL_0015: Unknown result type (might be due to invalid IL or missing references)
			//IL_001a: Unknown result type (might be due to invalid IL or missing references)
			//IL_0026: Expected O, but got Unknown
			//IL_0027: Expected O, but got Unknown
			//IL_0030: Unknown result type (might be due to invalid IL or missing references)
			//IL_0035: Unknown result type (might be due to invalid IL or missing references)
			//IL_0041: Expected O, but got Unknown
			//IL_0042: Expected O, but got Unknown
			//IL_004b: Unknown result type (might be due to invalid IL or missing references)
			//IL_0050: Unknown result type (might be due to invalid IL or missing references)
			//IL_005c: Expected O, but got Unknown
			//IL_005d: Expected O, but got Unknown
			string sql = "SELECT ReceiveID FROM WorkFlowTask WHERE ID=(SELECT PrevID FROM WorkFlowTask WHERE FlowID=:FlowID AND StepID=:StepID AND GroupID=:GroupID)";
			OracleParameter[] obj = new OracleParameter[3];
			OracleParameter val = new OracleParameter(":FlowID", 126);
			((DbParameter)val).Value = flowID;
			obj[0] = val;
			OracleParameter val2 = new OracleParameter(":StepID", 126);
			((DbParameter)val2).Value = stepID;
			obj[1] = val2;
			OracleParameter val3 = new OracleParameter(":GroupID", 126);
			((DbParameter)val3).Value = groupID;
			obj[2] = val3;
			OracleParameter[] parameter = (OracleParameter[])obj;
			DataTable dataTable = dbHelper.GetDataTable(sql, parameter);
			List<Guid> list = new List<Guid>();
			foreach (DataRow row in dataTable.Rows)
			{
				Guid result;
				if (Guid.TryParse(row[0].ToString(), out result))
				{
					list.Add(result);
				}
			}
			return list;
		}

		public int Completed(Guid taskID, string comment = "", bool isSign = false, int status = 2, string note = "", string files = "")
		{
			//IL_001d: Unknown result type (might be due to invalid IL or missing references)
			//IL_0022: Unknown result type (might be due to invalid IL or missing references)
			//IL_0029: Expected O, but got Unknown
			//IL_0032: Unknown result type (might be due to invalid IL or missing references)
			//IL_0037: Unknown result type (might be due to invalid IL or missing references)
			//IL_0042: Expected O, but got Unknown
			//IL_0043: Expected O, but got Unknown
			//IL_004c: Unknown result type (might be due to invalid IL or missing references)
			//IL_0051: Unknown result type (might be due to invalid IL or missing references)
			//IL_0061: Expected O, but got Unknown
			//IL_0062: Expected O, but got Unknown
			//IL_006b: Unknown result type (might be due to invalid IL or missing references)
			//IL_0070: Unknown result type (might be due to invalid IL or missing references)
			//IL_0082: Expected O, but got Unknown
			//IL_0083: Expected O, but got Unknown
			//IL_008c: Unknown result type (might be due to invalid IL or missing references)
			//IL_0091: Unknown result type (might be due to invalid IL or missing references)
			//IL_009e: Expected O, but got Unknown
			//IL_009f: Expected O, but got Unknown
			//IL_00b1: Unknown result type (might be due to invalid IL or missing references)
			//IL_00b6: Unknown result type (might be due to invalid IL or missing references)
			//IL_00be: Expected O, but got Unknown
			//IL_00c7: Unknown result type (might be due to invalid IL or missing references)
			//IL_00cc: Unknown result type (might be due to invalid IL or missing references)
			//IL_00d7: Expected O, but got Unknown
			//IL_00d8: Expected O, but got Unknown
			//IL_00ea: Unknown result type (might be due to invalid IL or missing references)
			//IL_00ef: Unknown result type (might be due to invalid IL or missing references)
			//IL_00f7: Expected O, but got Unknown
			//IL_0100: Unknown result type (might be due to invalid IL or missing references)
			//IL_0105: Unknown result type (might be due to invalid IL or missing references)
			//IL_0110: Expected O, but got Unknown
			//IL_0111: Expected O, but got Unknown
			//IL_011a: Unknown result type (might be due to invalid IL or missing references)
			//IL_011f: Unknown result type (might be due to invalid IL or missing references)
			//IL_012b: Expected O, but got Unknown
			//IL_012c: Expected O, but got Unknown
			string sql = "UPDATE WorkFlowTask SET Comment1=:Comment1,CompletedTime1=:CompletedTime1,IsSign=:IsSign,Status=:Status,Note=:Note,Files=:Files WHERE ID=:ID";
			OracleParameter[] obj = new OracleParameter[7];
			_003F val;
			if (!comment.IsNullOrEmpty())
			{
				val = new OracleParameter(":Comment1", 126);
				((DbParameter)val).Value = comment;
			}
			else
			{
				val = new OracleParameter(":Comment1", 126);
				((DbParameter)val).Value = DBNull.Value;
			}
			obj[0] = val;
			OracleParameter val2 = new OracleParameter(":CompletedTime1", 106);
			((DbParameter)val2).Value = DateTimeNew.Now;
			obj[1] = val2;
			OracleParameter val3 = new OracleParameter(":IsSign", 112);
			((DbParameter)val3).Value = (isSign ? 1 : 0);
			obj[2] = val3;
			OracleParameter val4 = new OracleParameter(":Status", 112);
			((DbParameter)val4).Value = status;
			obj[3] = val4;
			_003F val5;
			if (!note.IsNullOrEmpty())
			{
				val5 = new OracleParameter(":Note", 119);
				((DbParameter)val5).Value = note;
			}
			else
			{
				val5 = new OracleParameter(":Note", 119);
				((DbParameter)val5).Value = DBNull.Value;
			}
			obj[4] = val5;
			_003F val6;
			if (!files.IsNullOrEmpty())
			{
				val6 = new OracleParameter(":Files", 126);
				((DbParameter)val6).Value = files;
			}
			else
			{
				val6 = new OracleParameter(":Files", 126);
				((DbParameter)val6).Value = DBNull.Value;
			}
			obj[5] = val6;
			OracleParameter val7 = new OracleParameter(":ID", 126);
			((DbParameter)val7).Value = taskID;
			obj[6] = val7;
			OracleParameter[] parameter = (OracleParameter[])obj;
			return dbHelper.Execute(sql, parameter);
		}

		public int UpdateNextTaskStatus(Guid taskID, int status)
		{
			//IL_0015: Unknown result type (might be due to invalid IL or missing references)
			//IL_001a: Unknown result type (might be due to invalid IL or missing references)
			//IL_0026: Expected O, but got Unknown
			//IL_0027: Expected O, but got Unknown
			//IL_0030: Unknown result type (might be due to invalid IL or missing references)
			//IL_0035: Unknown result type (might be due to invalid IL or missing references)
			//IL_0041: Expected O, but got Unknown
			//IL_0042: Expected O, but got Unknown
			string sql = "UPDATE WorkFlowTask SET Status=:Status WHERE PrevID=:PrevID";
			OracleParameter[] obj = new OracleParameter[2];
			OracleParameter val = new OracleParameter(":Status", 112);
			((DbParameter)val).Value = status;
			obj[0] = val;
			OracleParameter val2 = new OracleParameter(":PrevID", 126);
			((DbParameter)val2).Value = taskID;
			obj[1] = val2;
			OracleParameter[] parameter = (OracleParameter[])obj;
			return dbHelper.Execute(sql, parameter);
		}

		public List<RoadFlow.Data.Model.WorkFlowTask> GetTaskList(Guid flowID, Guid stepID, Guid groupID)
		{
			//IL_0015: Unknown result type (might be due to invalid IL or missing references)
			//IL_001a: Unknown result type (might be due to invalid IL or missing references)
			//IL_0026: Expected O, but got Unknown
			//IL_0027: Expected O, but got Unknown
			//IL_0030: Unknown result type (might be due to invalid IL or missing references)
			//IL_0035: Unknown result type (might be due to invalid IL or missing references)
			//IL_0041: Expected O, but got Unknown
			//IL_0042: Expected O, but got Unknown
			//IL_004b: Unknown result type (might be due to invalid IL or missing references)
			//IL_0050: Unknown result type (might be due to invalid IL or missing references)
			//IL_005c: Expected O, but got Unknown
			//IL_005d: Expected O, but got Unknown
			string sql = "SELECT * FROM WorkFlowTask WHERE FlowID=:FlowID AND StepID=:StepID AND GroupID=:GroupID";
			OracleParameter[] obj = new OracleParameter[3];
			OracleParameter val = new OracleParameter(":FlowID", 126);
			((DbParameter)val).Value = flowID;
			obj[0] = val;
			OracleParameter val2 = new OracleParameter(":StepID", 126);
			((DbParameter)val2).Value = stepID;
			obj[1] = val2;
			OracleParameter val3 = new OracleParameter(":GroupID", 126);
			((DbParameter)val3).Value = groupID;
			obj[2] = val3;
			OracleParameter[] parameter = (OracleParameter[])obj;
			OracleDataReader dataReader = dbHelper.GetDataReader(sql, parameter);
			List<RoadFlow.Data.Model.WorkFlowTask> result = DataReaderToList(dataReader);
			((DbDataReader)dataReader).Close();
			return result;
		}

		public List<RoadFlow.Data.Model.WorkFlowTask> GetUserTaskList(Guid flowID, Guid stepID, Guid groupID, Guid userID)
		{
			//IL_0015: Unknown result type (might be due to invalid IL or missing references)
			//IL_001a: Unknown result type (might be due to invalid IL or missing references)
			//IL_0026: Expected O, but got Unknown
			//IL_0027: Expected O, but got Unknown
			//IL_0030: Unknown result type (might be due to invalid IL or missing references)
			//IL_0035: Unknown result type (might be due to invalid IL or missing references)
			//IL_0041: Expected O, but got Unknown
			//IL_0042: Expected O, but got Unknown
			//IL_004b: Unknown result type (might be due to invalid IL or missing references)
			//IL_0050: Unknown result type (might be due to invalid IL or missing references)
			//IL_005c: Expected O, but got Unknown
			//IL_005d: Expected O, but got Unknown
			//IL_0066: Unknown result type (might be due to invalid IL or missing references)
			//IL_006b: Unknown result type (might be due to invalid IL or missing references)
			//IL_0078: Expected O, but got Unknown
			//IL_0079: Expected O, but got Unknown
			string sql = "SELECT * FROM WorkFlowTask WHERE FlowID=:FlowID AND StepID=:StepID AND GroupID=:GroupID AND ReceiveID=:ReceiveID";
			OracleParameter[] obj = new OracleParameter[4];
			OracleParameter val = new OracleParameter(":FlowID", 126);
			((DbParameter)val).Value = flowID;
			obj[0] = val;
			OracleParameter val2 = new OracleParameter(":StepID", 126);
			((DbParameter)val2).Value = stepID;
			obj[1] = val2;
			OracleParameter val3 = new OracleParameter(":GroupID", 126);
			((DbParameter)val3).Value = groupID;
			obj[2] = val3;
			OracleParameter val4 = new OracleParameter(":ReceiveID", 126);
			((DbParameter)val4).Value = userID;
			obj[3] = val4;
			OracleParameter[] parameter = (OracleParameter[])obj;
			OracleDataReader dataReader = dbHelper.GetDataReader(sql, parameter);
			List<RoadFlow.Data.Model.WorkFlowTask> result = DataReaderToList(dataReader);
			((DbDataReader)dataReader).Close();
			return result;
		}

		public List<RoadFlow.Data.Model.WorkFlowTask> GetTaskList(Guid flowID, Guid groupID)
		{
			//IL_0023: Unknown result type (might be due to invalid IL or missing references)
			//IL_0028: Unknown result type (might be due to invalid IL or missing references)
			//IL_0034: Expected O, but got Unknown
			//IL_0035: Expected O, but got Unknown
			//IL_004d: Unknown result type (might be due to invalid IL or missing references)
			//IL_0052: Unknown result type (might be due to invalid IL or missing references)
			//IL_005e: Expected O, but got Unknown
			//IL_005f: Expected O, but got Unknown
			//IL_0068: Unknown result type (might be due to invalid IL or missing references)
			//IL_006d: Unknown result type (might be due to invalid IL or missing references)
			//IL_0079: Expected O, but got Unknown
			//IL_007a: Expected O, but got Unknown
			string empty = string.Empty;
			OracleParameter[] parameter;
			if (flowID.IsEmptyGuid())
			{
				empty = "SELECT * FROM WorkFlowTask WHERE GroupID=:GroupID";
				OracleParameter[] obj = new OracleParameter[1];
				OracleParameter val = new OracleParameter(":GroupID", 126);
				((DbParameter)val).Value = groupID;
				obj[0] = val;
				parameter = (OracleParameter[])obj;
			}
			else
			{
				empty = "SELECT * FROM WorkFlowTask WHERE FlowID=:FlowID AND GroupID=:GroupID";
				OracleParameter[] obj2 = new OracleParameter[2];
				OracleParameter val2 = new OracleParameter(":FlowID", 126);
				((DbParameter)val2).Value = flowID;
				obj2[0] = val2;
				OracleParameter val3 = new OracleParameter(":GroupID", 126);
				((DbParameter)val3).Value = groupID;
				obj2[1] = val3;
				parameter = (OracleParameter[])obj2;
			}
			OracleDataReader dataReader = dbHelper.GetDataReader(empty, parameter);
			List<RoadFlow.Data.Model.WorkFlowTask> result = DataReaderToList(dataReader);
			((DbDataReader)dataReader).Close();
			return result;
		}

		public List<RoadFlow.Data.Model.WorkFlowTask> GetTaskList(Guid taskID, bool isStepID = true)
		{
			//IL_003a: Unknown result type (might be due to invalid IL or missing references)
			//IL_003f: Unknown result type (might be due to invalid IL or missing references)
			//IL_0050: Expected O, but got Unknown
			//IL_0051: Expected O, but got Unknown
			//IL_005a: Unknown result type (might be due to invalid IL or missing references)
			//IL_005f: Unknown result type (might be due to invalid IL or missing references)
			//IL_0070: Expected O, but got Unknown
			//IL_0071: Expected O, but got Unknown
			//IL_007a: Unknown result type (might be due to invalid IL or missing references)
			//IL_007f: Unknown result type (might be due to invalid IL or missing references)
			//IL_0090: Expected O, but got Unknown
			//IL_0091: Expected O, but got Unknown
			//IL_009a: Unknown result type (might be due to invalid IL or missing references)
			//IL_009f: Unknown result type (might be due to invalid IL or missing references)
			//IL_00bb: Expected O, but got Unknown
			//IL_00bc: Expected O, but got Unknown
			RoadFlow.Data.Model.WorkFlowTask workFlowTask = Get(taskID);
			if (workFlowTask != null)
			{
				string sql = string.Format("SELECT * FROM WorkFlowTask WHERE FlowID=:FlowID AND GroupID=:GroupID AND PrevID=:PrevID AND {0}", isStepID ? "StepID=:StepID" : "PrevStepID=:StepID");
				OracleParameter[] obj = new OracleParameter[4];
				OracleParameter val = new OracleParameter(":FlowID", 126);
				((DbParameter)val).Value = workFlowTask.FlowID;
				obj[0] = val;
				OracleParameter val2 = new OracleParameter(":GroupID", 126);
				((DbParameter)val2).Value = workFlowTask.GroupID;
				obj[1] = val2;
				OracleParameter val3 = new OracleParameter(":PrevID", 126);
				((DbParameter)val3).Value = workFlowTask.PrevID;
				obj[2] = val3;
				OracleParameter val4 = new OracleParameter(":StepID", 126);
				((DbParameter)val4).Value = (isStepID ? workFlowTask.StepID : workFlowTask.PrevStepID);
				obj[3] = val4;
				OracleParameter[] parameter = (OracleParameter[])obj;
				OracleDataReader dataReader = dbHelper.GetDataReader(sql, parameter);
				List<RoadFlow.Data.Model.WorkFlowTask> result = DataReaderToList(dataReader);
				((DbDataReader)dataReader).Close();
				return result;
			}
			return new List<RoadFlow.Data.Model.WorkFlowTask>();
		}

		public List<RoadFlow.Data.Model.WorkFlowTask> GetPrevTaskList(Guid taskID)
		{
			//IL_0015: Unknown result type (might be due to invalid IL or missing references)
			//IL_001a: Unknown result type (might be due to invalid IL or missing references)
			//IL_0026: Expected O, but got Unknown
			//IL_0027: Expected O, but got Unknown
			string sql = "SELECT * FROM WorkFlowTask WHERE ID=(SELECT PrevID FROM WorkFlowTask WHERE ID=:ID)";
			OracleParameter[] obj = new OracleParameter[1];
			OracleParameter val = new OracleParameter(":ID", 126);
			((DbParameter)val).Value = taskID;
			obj[0] = val;
			OracleParameter[] parameter = (OracleParameter[])obj;
			OracleDataReader dataReader = dbHelper.GetDataReader(sql, parameter);
			List<RoadFlow.Data.Model.WorkFlowTask> result = DataReaderToList(dataReader);
			((DbDataReader)dataReader).Close();
			return result;
		}

		public List<RoadFlow.Data.Model.WorkFlowTask> GetNextTaskList(Guid taskID)
		{
			//IL_0015: Unknown result type (might be due to invalid IL or missing references)
			//IL_001a: Unknown result type (might be due to invalid IL or missing references)
			//IL_0026: Expected O, but got Unknown
			//IL_0027: Expected O, but got Unknown
			string sql = "SELECT * FROM WorkFlowTask WHERE PrevID=:PrevID";
			OracleParameter[] obj = new OracleParameter[1];
			OracleParameter val = new OracleParameter(":PrevID", 126);
			((DbParameter)val).Value = taskID;
			obj[0] = val;
			OracleParameter[] parameter = (OracleParameter[])obj;
			OracleDataReader dataReader = dbHelper.GetDataReader(sql, parameter);
			List<RoadFlow.Data.Model.WorkFlowTask> result = DataReaderToList(dataReader);
			((DbDataReader)dataReader).Close();
			return result;
		}

		public bool HasTasks(Guid flowID)
		{
			//IL_0015: Unknown result type (might be due to invalid IL or missing references)
			//IL_001a: Unknown result type (might be due to invalid IL or missing references)
			//IL_0026: Expected O, but got Unknown
			//IL_0027: Expected O, but got Unknown
			string sql = "SELECT ID FROM WorkFlowTask WHERE FlowID=:FlowID AND ROWNUM<=1";
			OracleParameter[] obj = new OracleParameter[1];
			OracleParameter val = new OracleParameter(":FlowID", 126);
			((DbParameter)val).Value = flowID;
			obj[0] = val;
			OracleParameter[] parameter = (OracleParameter[])obj;
			OracleDataReader dataReader = dbHelper.GetDataReader(sql, parameter);
			bool hasRows = ((DbDataReader)dataReader).HasRows;
			((DbDataReader)dataReader).Close();
			return hasRows;
		}

		public bool HasNoCompletedTasks(Guid flowID, Guid stepID, Guid groupID, Guid userID)
		{
			//IL_0015: Unknown result type (might be due to invalid IL or missing references)
			//IL_001a: Unknown result type (might be due to invalid IL or missing references)
			//IL_0026: Expected O, but got Unknown
			//IL_0027: Expected O, but got Unknown
			//IL_0030: Unknown result type (might be due to invalid IL or missing references)
			//IL_0035: Unknown result type (might be due to invalid IL or missing references)
			//IL_0041: Expected O, but got Unknown
			//IL_0042: Expected O, but got Unknown
			//IL_004b: Unknown result type (might be due to invalid IL or missing references)
			//IL_0050: Unknown result type (might be due to invalid IL or missing references)
			//IL_005c: Expected O, but got Unknown
			//IL_005d: Expected O, but got Unknown
			//IL_0066: Unknown result type (might be due to invalid IL or missing references)
			//IL_006b: Unknown result type (might be due to invalid IL or missing references)
			//IL_0078: Expected O, but got Unknown
			//IL_0079: Expected O, but got Unknown
			string sql = "SELECT ID FROM WorkFlowTask WHERE FlowID=:FlowID AND StepID=:StepID AND GroupID=:GroupID AND ReceiveID=:ReceiveID AND Status IN(-1,0,1) AND ROWNUM<=1";
			OracleParameter[] obj = new OracleParameter[4];
			OracleParameter val = new OracleParameter(":FlowID", 126);
			((DbParameter)val).Value = flowID;
			obj[0] = val;
			OracleParameter val2 = new OracleParameter(":StepID", 126);
			((DbParameter)val2).Value = stepID;
			obj[1] = val2;
			OracleParameter val3 = new OracleParameter(":GroupID", 126);
			((DbParameter)val3).Value = groupID;
			obj[2] = val3;
			OracleParameter val4 = new OracleParameter(":ReceiveID", 126);
			((DbParameter)val4).Value = userID;
			obj[3] = val4;
			OracleParameter[] parameter = (OracleParameter[])obj;
			OracleDataReader dataReader = dbHelper.GetDataReader(sql, parameter);
			bool hasRows = ((DbDataReader)dataReader).HasRows;
			((DbDataReader)dataReader).Close();
			return hasRows;
		}

		public int UpdateTempTasks(Guid flowID, Guid stepID, Guid groupID, DateTime? completedTime, DateTime receiveTime)
		{
			//IL_001e: Unknown result type (might be due to invalid IL or missing references)
			//IL_0023: Unknown result type (might be due to invalid IL or missing references)
			//IL_0035: Expected O, but got Unknown
			//IL_003e: Unknown result type (might be due to invalid IL or missing references)
			//IL_0043: Unknown result type (might be due to invalid IL or missing references)
			//IL_004e: Expected O, but got Unknown
			//IL_004f: Expected O, but got Unknown
			//IL_0058: Unknown result type (might be due to invalid IL or missing references)
			//IL_005d: Unknown result type (might be due to invalid IL or missing references)
			//IL_006a: Expected O, but got Unknown
			//IL_006b: Expected O, but got Unknown
			//IL_0074: Unknown result type (might be due to invalid IL or missing references)
			//IL_0079: Unknown result type (might be due to invalid IL or missing references)
			//IL_0086: Expected O, but got Unknown
			//IL_0087: Expected O, but got Unknown
			//IL_0090: Unknown result type (might be due to invalid IL or missing references)
			//IL_0095: Unknown result type (might be due to invalid IL or missing references)
			//IL_00a1: Expected O, but got Unknown
			//IL_00a2: Expected O, but got Unknown
			//IL_00ab: Unknown result type (might be due to invalid IL or missing references)
			//IL_00b0: Unknown result type (might be due to invalid IL or missing references)
			//IL_00bc: Expected O, but got Unknown
			//IL_00bd: Expected O, but got Unknown
			//IL_00c6: Unknown result type (might be due to invalid IL or missing references)
			//IL_00cb: Unknown result type (might be due to invalid IL or missing references)
			//IL_00d7: Expected O, but got Unknown
			//IL_00d8: Expected O, but got Unknown
			string sql = "UPDATE WorkFlowTask SET CompletedTime=:CompletedTime,ReceiveTime=:ReceiveTime,SenderTime=:SenderTime,Status=0 WHERE FlowID=:FlowID AND StepID=:StepID AND GroupID=:GroupID AND Status=-1";
			OracleParameter[] obj = new OracleParameter[6];
			_003F val;
			if (completedTime.HasValue)
			{
				val = new OracleParameter(":CompletedTime", 106);
				((DbParameter)val).Value = completedTime.Value;
			}
			else
			{
				val = new OracleParameter(":CompletedTime", 106);
				((DbParameter)val).Value = DBNull.Value;
			}
			obj[0] = val;
			OracleParameter val2 = new OracleParameter(":ReceiveTime", 106);
			((DbParameter)val2).Value = receiveTime;
			obj[1] = val2;
			OracleParameter val3 = new OracleParameter(":SenderTime", 106);
			((DbParameter)val3).Value = receiveTime;
			obj[2] = val3;
			OracleParameter val4 = new OracleParameter(":FlowID", 126);
			((DbParameter)val4).Value = flowID;
			obj[3] = val4;
			OracleParameter val5 = new OracleParameter(":StepID", 126);
			((DbParameter)val5).Value = stepID;
			obj[4] = val5;
			OracleParameter val6 = new OracleParameter(":GroupID", 126);
			((DbParameter)val6).Value = groupID;
			obj[5] = val6;
			OracleParameter[] parameter = (OracleParameter[])obj;
			return dbHelper.Execute(sql, parameter);
		}

		public int DeleteTempTasks(Guid flowID, Guid stepID, Guid groupID, Guid prevStepID)
		{
			//IL_0013: Unknown result type (might be due to invalid IL or missing references)
			//IL_0018: Unknown result type (might be due to invalid IL or missing references)
			//IL_0024: Expected O, but got Unknown
			//IL_0029: Expected O, but got Unknown
			//IL_0031: Unknown result type (might be due to invalid IL or missing references)
			//IL_0036: Unknown result type (might be due to invalid IL or missing references)
			//IL_0042: Expected O, but got Unknown
			//IL_0047: Expected O, but got Unknown
			//IL_004f: Unknown result type (might be due to invalid IL or missing references)
			//IL_0054: Unknown result type (might be due to invalid IL or missing references)
			//IL_0060: Expected O, but got Unknown
			//IL_0065: Expected O, but got Unknown
			//IL_0083: Unknown result type (might be due to invalid IL or missing references)
			//IL_0088: Unknown result type (might be due to invalid IL or missing references)
			//IL_0095: Expected O, but got Unknown
			//IL_009a: Expected O, but got Unknown
			string text = "DELETE WorkFlowTask WHERE FlowID=:FlowID AND StepID=:StepID AND GroupID=:GroupID AND Status=-1";
			List<OracleParameter> list = new List<OracleParameter>();
			OracleParameter val = new OracleParameter(":FlowID", 126);
			((DbParameter)val).Value = flowID;
			list.Add(val);
			OracleParameter val2 = new OracleParameter(":StepID", 126);
			((DbParameter)val2).Value = stepID;
			list.Add(val2);
			OracleParameter val3 = new OracleParameter(":GroupID", 126);
			((DbParameter)val3).Value = groupID;
			list.Add(val3);
			List<OracleParameter> list2 = list;
			if (!prevStepID.IsEmptyGuid())
			{
				text += " AND PrevStepID=:PrevStepID";
				List<OracleParameter> list3 = list2;
				OracleParameter val4 = new OracleParameter(":PrevStepID", 126);
				((DbParameter)val4).Value = prevStepID;
				list3.Add(val4);
			}
			return dbHelper.Execute(text, list2.ToArray());
		}

		public int GetTaskStatus(Guid taskID)
		{
			//IL_0015: Unknown result type (might be due to invalid IL or missing references)
			//IL_001a: Unknown result type (might be due to invalid IL or missing references)
			//IL_0026: Expected O, but got Unknown
			//IL_0027: Expected O, but got Unknown
			string sql = "SELECT Status FROM WorkFlowTask WHERE ID=:ID";
			OracleParameter[] obj = new OracleParameter[1];
			OracleParameter val = new OracleParameter(":ID", 126);
			((DbParameter)val).Value = taskID;
			obj[0] = val;
			OracleParameter[] parameter = (OracleParameter[])obj;
			int test;
			if (!dbHelper.GetFieldValue(sql, parameter).IsInt(out test))
			{
				return -1;
			}
			return test;
		}

		public List<RoadFlow.Data.Model.WorkFlowTask> GetBySubFlowGroupID(Guid subflowGroupID)
		{
			//IL_0015: Unknown result type (might be due to invalid IL or missing references)
			//IL_001a: Unknown result type (might be due to invalid IL or missing references)
			//IL_002d: Expected O, but got Unknown
			//IL_002e: Expected O, but got Unknown
			string sql = "SELECT * FROM WorkFlowTask WHERE INSTR(SubFlowGroupID,:SubFlowGroupID,1,1)>0";
			OracleParameter[] obj = new OracleParameter[1];
			OracleParameter val = new OracleParameter(":SubFlowGroupID", 126);
			((DbParameter)val).Value = subflowGroupID.ToString();
			obj[0] = val;
			OracleParameter[] parameter = (OracleParameter[])obj;
			OracleDataReader dataReader = dbHelper.GetDataReader(sql, parameter);
			List<RoadFlow.Data.Model.WorkFlowTask> result = DataReaderToList(dataReader);
			((DbDataReader)dataReader).Close();
			return result;
		}

		public RoadFlow.Data.Model.WorkFlowTask GetLastTask(Guid flowID, Guid groupID)
		{
			//IL_0015: Unknown result type (might be due to invalid IL or missing references)
			//IL_001a: Unknown result type (might be due to invalid IL or missing references)
			//IL_002d: Expected O, but got Unknown
			//IL_002e: Expected O, but got Unknown
			//IL_0037: Unknown result type (might be due to invalid IL or missing references)
			//IL_003c: Unknown result type (might be due to invalid IL or missing references)
			//IL_004f: Expected O, but got Unknown
			//IL_0050: Expected O, but got Unknown
			string sql = "SELECT * FROM WorkFlowTask WHERE ROWNUM=1 AND FlowID=:FlowID AND GroupID=:GroupID ORDER BY Sort DESC";
			OracleParameter[] obj = new OracleParameter[2];
			OracleParameter val = new OracleParameter(":FlowID", 126);
			((DbParameter)val).Value = flowID.ToString();
			obj[0] = val;
			OracleParameter val2 = new OracleParameter(":GroupID", 126);
			((DbParameter)val2).Value = groupID.ToString();
			obj[1] = val2;
			OracleParameter[] parameter = (OracleParameter[])obj;
			OracleDataReader dataReader = dbHelper.GetDataReader(sql, parameter);
			List<RoadFlow.Data.Model.WorkFlowTask> list = DataReaderToList(dataReader);
			((DbDataReader)dataReader).Close();
			if (list.Count <= 0)
			{
				return null;
			}
			return list[0];
		}

		public List<RoadFlow.Data.Model.WorkFlowTask> GetExpiredAutoSubmitTasks()
		{
			string sql = "SELECT * FROM WorkFlowTask WHERE CompletedTime<'" + DateTimeNew.Now.ToDateTimeStringS() + "' AND IsExpiredAutoSubmit=1 AND Status IN(0,1)";
			OracleDataReader dataReader = dbHelper.GetDataReader(sql);
			List<RoadFlow.Data.Model.WorkFlowTask> result = DataReaderToList(dataReader);
			((DbDataReader)dataReader).Close();
			return result;
		}
	}
}
