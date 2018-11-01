using MySql.Data.MySqlClient;
using RoadFlow.Data.Interface;
using RoadFlow.Data.Model;
using RoadFlow.Utility;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Common;
using System.Text;

namespace RoadFlow.Data.MySql
{
	public class WorkFlowTask : IWorkFlowTask
	{
		private DBHelper dbHelper = new DBHelper();

		public int Add(RoadFlow.Data.Model.WorkFlowTask model)
		{
			//IL_001b: Unknown result type (might be due to invalid IL or missing references)
			//IL_0020: Unknown result type (might be due to invalid IL or missing references)
			//IL_0031: Expected O, but got Unknown
			//IL_0032: Expected O, but got Unknown
			//IL_0040: Unknown result type (might be due to invalid IL or missing references)
			//IL_0045: Unknown result type (might be due to invalid IL or missing references)
			//IL_0056: Expected O, but got Unknown
			//IL_0057: Expected O, but got Unknown
			//IL_0065: Unknown result type (might be due to invalid IL or missing references)
			//IL_006a: Unknown result type (might be due to invalid IL or missing references)
			//IL_007b: Expected O, but got Unknown
			//IL_007c: Expected O, but got Unknown
			//IL_008a: Unknown result type (might be due to invalid IL or missing references)
			//IL_008f: Unknown result type (might be due to invalid IL or missing references)
			//IL_00a0: Expected O, but got Unknown
			//IL_00a1: Expected O, but got Unknown
			//IL_00af: Unknown result type (might be due to invalid IL or missing references)
			//IL_00b4: Unknown result type (might be due to invalid IL or missing references)
			//IL_00c5: Expected O, but got Unknown
			//IL_00c6: Expected O, but got Unknown
			//IL_00d7: Unknown result type (might be due to invalid IL or missing references)
			//IL_00dc: Unknown result type (might be due to invalid IL or missing references)
			//IL_00e8: Expected O, but got Unknown
			//IL_00e9: Expected O, but got Unknown
			//IL_00f7: Unknown result type (might be due to invalid IL or missing references)
			//IL_00fc: Unknown result type (might be due to invalid IL or missing references)
			//IL_0108: Expected O, but got Unknown
			//IL_0109: Expected O, but got Unknown
			//IL_0117: Unknown result type (might be due to invalid IL or missing references)
			//IL_011c: Unknown result type (might be due to invalid IL or missing references)
			//IL_012d: Expected O, but got Unknown
			//IL_012e: Expected O, but got Unknown
			//IL_0138: Unknown result type (might be due to invalid IL or missing references)
			//IL_013d: Unknown result type (might be due to invalid IL or missing references)
			//IL_014e: Expected O, but got Unknown
			//IL_014f: Expected O, but got Unknown
			//IL_0161: Unknown result type (might be due to invalid IL or missing references)
			//IL_0166: Unknown result type (might be due to invalid IL or missing references)
			//IL_0172: Expected O, but got Unknown
			//IL_0173: Expected O, but got Unknown
			//IL_0182: Unknown result type (might be due to invalid IL or missing references)
			//IL_0187: Unknown result type (might be due to invalid IL or missing references)
			//IL_0198: Expected O, but got Unknown
			//IL_0199: Expected O, but got Unknown
			//IL_01a8: Unknown result type (might be due to invalid IL or missing references)
			//IL_01ad: Unknown result type (might be due to invalid IL or missing references)
			//IL_01b9: Expected O, but got Unknown
			//IL_01ba: Expected O, but got Unknown
			//IL_01c5: Unknown result type (might be due to invalid IL or missing references)
			//IL_01ca: Unknown result type (might be due to invalid IL or missing references)
			//IL_01db: Expected O, but got Unknown
			//IL_01dc: Expected O, but got Unknown
			//IL_01eb: Unknown result type (might be due to invalid IL or missing references)
			//IL_01f0: Unknown result type (might be due to invalid IL or missing references)
			//IL_0201: Expected O, but got Unknown
			//IL_0202: Expected O, but got Unknown
			//IL_0211: Unknown result type (might be due to invalid IL or missing references)
			//IL_0216: Unknown result type (might be due to invalid IL or missing references)
			//IL_0222: Expected O, but got Unknown
			//IL_0223: Expected O, but got Unknown
			//IL_022e: Unknown result type (might be due to invalid IL or missing references)
			//IL_0233: Unknown result type (might be due to invalid IL or missing references)
			//IL_0244: Expected O, but got Unknown
			//IL_0245: Expected O, but got Unknown
			//IL_0260: Unknown result type (might be due to invalid IL or missing references)
			//IL_0265: Unknown result type (might be due to invalid IL or missing references)
			//IL_0276: Expected O, but got Unknown
			//IL_0280: Unknown result type (might be due to invalid IL or missing references)
			//IL_0285: Unknown result type (might be due to invalid IL or missing references)
			//IL_0290: Expected O, but got Unknown
			//IL_0291: Expected O, but got Unknown
			//IL_02ac: Unknown result type (might be due to invalid IL or missing references)
			//IL_02b1: Unknown result type (might be due to invalid IL or missing references)
			//IL_02c2: Expected O, but got Unknown
			//IL_02cc: Unknown result type (might be due to invalid IL or missing references)
			//IL_02d1: Unknown result type (might be due to invalid IL or missing references)
			//IL_02dc: Expected O, but got Unknown
			//IL_02dd: Expected O, but got Unknown
			//IL_02f8: Unknown result type (might be due to invalid IL or missing references)
			//IL_02fd: Unknown result type (might be due to invalid IL or missing references)
			//IL_030e: Expected O, but got Unknown
			//IL_0318: Unknown result type (might be due to invalid IL or missing references)
			//IL_031d: Unknown result type (might be due to invalid IL or missing references)
			//IL_0328: Expected O, but got Unknown
			//IL_0329: Expected O, but got Unknown
			//IL_0343: Unknown result type (might be due to invalid IL or missing references)
			//IL_0348: Unknown result type (might be due to invalid IL or missing references)
			//IL_0354: Expected O, but got Unknown
			//IL_0365: Unknown result type (might be due to invalid IL or missing references)
			//IL_036a: Unknown result type (might be due to invalid IL or missing references)
			//IL_0375: Expected O, but got Unknown
			//IL_0376: Expected O, but got Unknown
			//IL_0391: Unknown result type (might be due to invalid IL or missing references)
			//IL_0396: Unknown result type (might be due to invalid IL or missing references)
			//IL_03a7: Expected O, but got Unknown
			//IL_03b1: Unknown result type (might be due to invalid IL or missing references)
			//IL_03b6: Unknown result type (might be due to invalid IL or missing references)
			//IL_03c1: Expected O, but got Unknown
			//IL_03c2: Expected O, but got Unknown
			//IL_03cd: Unknown result type (might be due to invalid IL or missing references)
			//IL_03d2: Unknown result type (might be due to invalid IL or missing references)
			//IL_03e3: Expected O, but got Unknown
			//IL_03e4: Expected O, but got Unknown
			//IL_03fe: Unknown result type (might be due to invalid IL or missing references)
			//IL_0403: Unknown result type (might be due to invalid IL or missing references)
			//IL_040f: Expected O, but got Unknown
			//IL_0420: Unknown result type (might be due to invalid IL or missing references)
			//IL_0425: Unknown result type (might be due to invalid IL or missing references)
			//IL_0430: Expected O, but got Unknown
			//IL_0431: Expected O, but got Unknown
			//IL_043c: Unknown result type (might be due to invalid IL or missing references)
			//IL_0441: Unknown result type (might be due to invalid IL or missing references)
			//IL_0452: Expected O, but got Unknown
			//IL_0453: Expected O, but got Unknown
			//IL_046d: Unknown result type (might be due to invalid IL or missing references)
			//IL_0472: Unknown result type (might be due to invalid IL or missing references)
			//IL_047e: Expected O, but got Unknown
			//IL_048f: Unknown result type (might be due to invalid IL or missing references)
			//IL_0494: Unknown result type (might be due to invalid IL or missing references)
			//IL_049f: Expected O, but got Unknown
			//IL_04a0: Expected O, but got Unknown
			//IL_04bb: Unknown result type (might be due to invalid IL or missing references)
			//IL_04c0: Unknown result type (might be due to invalid IL or missing references)
			//IL_04d1: Expected O, but got Unknown
			//IL_04db: Unknown result type (might be due to invalid IL or missing references)
			//IL_04e0: Unknown result type (might be due to invalid IL or missing references)
			//IL_04eb: Expected O, but got Unknown
			//IL_04ec: Expected O, but got Unknown
			//IL_0506: Unknown result type (might be due to invalid IL or missing references)
			//IL_050b: Unknown result type (might be due to invalid IL or missing references)
			//IL_0517: Expected O, but got Unknown
			//IL_0528: Unknown result type (might be due to invalid IL or missing references)
			//IL_052d: Unknown result type (might be due to invalid IL or missing references)
			//IL_0538: Expected O, but got Unknown
			//IL_0539: Expected O, but got Unknown
			//IL_0542: Unknown result type (might be due to invalid IL or missing references)
			//IL_0547: Unknown result type (might be due to invalid IL or missing references)
			//IL_0558: Expected O, but got Unknown
			//IL_0559: Expected O, but got Unknown
			//IL_0562: Unknown result type (might be due to invalid IL or missing references)
			//IL_0567: Unknown result type (might be due to invalid IL or missing references)
			//IL_0578: Expected O, but got Unknown
			//IL_0579: Expected O, but got Unknown
			string sql = "INSERT INTO workflowtask\r\n\t\t\t\t(ID,PrevID,PrevStepID,FlowID,StepID,StepName,InstanceID,GroupID,Type,Title,SenderID,SenderName,SenderTime,ReceiveID,ReceiveName,ReceiveTime,OpenTime,CompletedTime,CompletedTime1,Comment,IsSign,Status,Note,Sort,SubFlowGroupID,OtherType,Files,IsExpiredAutoSubmit,StepSort) \r\n\t\t\t\tVALUES(@ID,@PrevID,@PrevStepID,@FlowID,@StepID,@StepName,@InstanceID,@GroupID,@Type,@Title,@SenderID,@SenderName,@SenderTime,@ReceiveID,@ReceiveName,@ReceiveTime,@OpenTime,@CompletedTime,@CompletedTime1,@Comment,@IsSign,@Status,@Note,@Sort,@SubFlowGroupID,@OtherType,@Files,@IsExpiredAutoSubmit,@StepSort)";
			MySqlParameter[] obj = new MySqlParameter[29];
			MySqlParameter val = new MySqlParameter("@ID", 253, 36);
			((DbParameter)val).Value = model.ID;
			obj[0] = val;
			MySqlParameter val2 = new MySqlParameter("@PrevID", 253, 36);
			((DbParameter)val2).Value = model.PrevID;
			obj[1] = val2;
			MySqlParameter val3 = new MySqlParameter("@PrevStepID", 253, 36);
			((DbParameter)val3).Value = model.PrevStepID;
			obj[2] = val3;
			MySqlParameter val4 = new MySqlParameter("@FlowID", 253, 36);
			((DbParameter)val4).Value = model.FlowID;
			obj[3] = val4;
			MySqlParameter val5 = new MySqlParameter("@StepID", 253, 36);
			((DbParameter)val5).Value = model.StepID;
			obj[4] = val5;
			MySqlParameter val6 = new MySqlParameter("@StepName", 253, 255);
			((DbParameter)val6).Value = model.StepName;
			obj[5] = val6;
			MySqlParameter val7 = new MySqlParameter("@InstanceID", 253, 50);
			((DbParameter)val7).Value = model.InstanceID;
			obj[6] = val7;
			MySqlParameter val8 = new MySqlParameter("@GroupID", 253, 36);
			((DbParameter)val8).Value = model.GroupID;
			obj[7] = val8;
			MySqlParameter val9 = new MySqlParameter("@Type", 3, 11);
			((DbParameter)val9).Value = model.Type;
			obj[8] = val9;
			MySqlParameter val10 = new MySqlParameter("@Title", 253, 255);
			((DbParameter)val10).Value = model.Title;
			obj[9] = val10;
			MySqlParameter val11 = new MySqlParameter("@SenderID", 253, 36);
			((DbParameter)val11).Value = model.SenderID;
			obj[10] = val11;
			MySqlParameter val12 = new MySqlParameter("@SenderName", 253, 50);
			((DbParameter)val12).Value = model.SenderName;
			obj[11] = val12;
			MySqlParameter val13 = new MySqlParameter("@SenderTime", 12, -1);
			((DbParameter)val13).Value = model.SenderTime;
			obj[12] = val13;
			MySqlParameter val14 = new MySqlParameter("@ReceiveID", 253, 36);
			((DbParameter)val14).Value = model.ReceiveID;
			obj[13] = val14;
			MySqlParameter val15 = new MySqlParameter("@ReceiveName", 253, 50);
			((DbParameter)val15).Value = model.ReceiveName;
			obj[14] = val15;
			MySqlParameter val16 = new MySqlParameter("@ReceiveTime", 12, -1);
			((DbParameter)val16).Value = model.ReceiveTime;
			obj[15] = val16;
			_003F val17;
			if (model.OpenTime.HasValue)
			{
				val17 = new MySqlParameter("@OpenTime", 12, -1);
				((DbParameter)val17).Value = model.OpenTime;
			}
			else
			{
				val17 = new MySqlParameter("@OpenTime", 12, -1);
				((DbParameter)val17).Value = DBNull.Value;
			}
			obj[16] = val17;
			_003F val18;
			if (model.CompletedTime.HasValue)
			{
				val18 = new MySqlParameter("@CompletedTime", 12, -1);
				((DbParameter)val18).Value = model.CompletedTime;
			}
			else
			{
				val18 = new MySqlParameter("@CompletedTime", 12, -1);
				((DbParameter)val18).Value = DBNull.Value;
			}
			obj[17] = val18;
			_003F val19;
			if (model.CompletedTime1.HasValue)
			{
				val19 = new MySqlParameter("@CompletedTime1", 12, -1);
				((DbParameter)val19).Value = model.CompletedTime1;
			}
			else
			{
				val19 = new MySqlParameter("@CompletedTime1", 12, -1);
				((DbParameter)val19).Value = DBNull.Value;
			}
			obj[18] = val19;
			_003F val20;
			if (model.Comment != null)
			{
				val20 = new MySqlParameter("@Comment", 253, 255);
				((DbParameter)val20).Value = model.Comment;
			}
			else
			{
				val20 = new MySqlParameter("@Comment", 253, 255);
				((DbParameter)val20).Value = DBNull.Value;
			}
			obj[19] = val20;
			_003F val21;
			if (model.IsSign.HasValue)
			{
				val21 = new MySqlParameter("@IsSign", 3, 11);
				((DbParameter)val21).Value = model.IsSign;
			}
			else
			{
				val21 = new MySqlParameter("@IsSign", 3, 11);
				((DbParameter)val21).Value = DBNull.Value;
			}
			obj[20] = val21;
			MySqlParameter val22 = new MySqlParameter("@Status", 3, 11);
			((DbParameter)val22).Value = model.Status;
			obj[21] = val22;
			_003F val23;
			if (model.Note != null)
			{
				val23 = new MySqlParameter("@Note", 253, 255);
				((DbParameter)val23).Value = model.Note;
			}
			else
			{
				val23 = new MySqlParameter("@Note", 253, 255);
				((DbParameter)val23).Value = DBNull.Value;
			}
			obj[22] = val23;
			MySqlParameter val24 = new MySqlParameter("@Sort", 3, 11);
			((DbParameter)val24).Value = model.Sort;
			obj[23] = val24;
			_003F val25;
			if (model.SubFlowGroupID != null)
			{
				val25 = new MySqlParameter("@SubFlowGroupID", 253, 2000);
				((DbParameter)val25).Value = model.SubFlowGroupID;
			}
			else
			{
				val25 = new MySqlParameter("@SubFlowGroupID", 253, 2000);
				((DbParameter)val25).Value = DBNull.Value;
			}
			obj[24] = val25;
			_003F val26;
			if (model.OtherType.HasValue)
			{
				val26 = new MySqlParameter("@OtherType", 3, 11);
				((DbParameter)val26).Value = model.OtherType;
			}
			else
			{
				val26 = new MySqlParameter("@OtherType", 3, 11);
				((DbParameter)val26).Value = DBNull.Value;
			}
			obj[25] = val26;
			_003F val27;
			if (model.Files != null)
			{
				val27 = new MySqlParameter("@Files", 253, 4000);
				((DbParameter)val27).Value = model.Files;
			}
			else
			{
				val27 = new MySqlParameter("@Files", 253, 4000);
				((DbParameter)val27).Value = DBNull.Value;
			}
			obj[26] = val27;
			MySqlParameter val28 = new MySqlParameter("@IsExpiredAutoSubmit", 3);
			((DbParameter)val28).Value = model.IsExpiredAutoSubmit;
			obj[27] = val28;
			MySqlParameter val29 = new MySqlParameter("@StepSort", 3);
			((DbParameter)val29).Value = model.StepSort;
			obj[28] = val29;
			MySqlParameter[] parameter = (MySqlParameter[])obj;
			return dbHelper.Execute(sql, parameter);
		}

		public int Update(RoadFlow.Data.Model.WorkFlowTask model)
		{
			//IL_001b: Unknown result type (might be due to invalid IL or missing references)
			//IL_0020: Unknown result type (might be due to invalid IL or missing references)
			//IL_0031: Expected O, but got Unknown
			//IL_0032: Expected O, but got Unknown
			//IL_0040: Unknown result type (might be due to invalid IL or missing references)
			//IL_0045: Unknown result type (might be due to invalid IL or missing references)
			//IL_0056: Expected O, but got Unknown
			//IL_0057: Expected O, but got Unknown
			//IL_0065: Unknown result type (might be due to invalid IL or missing references)
			//IL_006a: Unknown result type (might be due to invalid IL or missing references)
			//IL_007b: Expected O, but got Unknown
			//IL_007c: Expected O, but got Unknown
			//IL_008a: Unknown result type (might be due to invalid IL or missing references)
			//IL_008f: Unknown result type (might be due to invalid IL or missing references)
			//IL_00a0: Expected O, but got Unknown
			//IL_00a1: Expected O, but got Unknown
			//IL_00b2: Unknown result type (might be due to invalid IL or missing references)
			//IL_00b7: Unknown result type (might be due to invalid IL or missing references)
			//IL_00c3: Expected O, but got Unknown
			//IL_00c4: Expected O, but got Unknown
			//IL_00d2: Unknown result type (might be due to invalid IL or missing references)
			//IL_00d7: Unknown result type (might be due to invalid IL or missing references)
			//IL_00e3: Expected O, but got Unknown
			//IL_00e4: Expected O, but got Unknown
			//IL_00f2: Unknown result type (might be due to invalid IL or missing references)
			//IL_00f7: Unknown result type (might be due to invalid IL or missing references)
			//IL_0108: Expected O, but got Unknown
			//IL_0109: Expected O, but got Unknown
			//IL_0113: Unknown result type (might be due to invalid IL or missing references)
			//IL_0118: Unknown result type (might be due to invalid IL or missing references)
			//IL_0129: Expected O, but got Unknown
			//IL_012a: Expected O, but got Unknown
			//IL_013b: Unknown result type (might be due to invalid IL or missing references)
			//IL_0140: Unknown result type (might be due to invalid IL or missing references)
			//IL_014c: Expected O, but got Unknown
			//IL_014d: Expected O, but got Unknown
			//IL_015c: Unknown result type (might be due to invalid IL or missing references)
			//IL_0161: Unknown result type (might be due to invalid IL or missing references)
			//IL_0172: Expected O, but got Unknown
			//IL_0173: Expected O, but got Unknown
			//IL_0182: Unknown result type (might be due to invalid IL or missing references)
			//IL_0187: Unknown result type (might be due to invalid IL or missing references)
			//IL_0193: Expected O, but got Unknown
			//IL_0194: Expected O, but got Unknown
			//IL_019f: Unknown result type (might be due to invalid IL or missing references)
			//IL_01a4: Unknown result type (might be due to invalid IL or missing references)
			//IL_01b5: Expected O, but got Unknown
			//IL_01b6: Expected O, but got Unknown
			//IL_01c5: Unknown result type (might be due to invalid IL or missing references)
			//IL_01ca: Unknown result type (might be due to invalid IL or missing references)
			//IL_01db: Expected O, but got Unknown
			//IL_01dc: Expected O, but got Unknown
			//IL_01eb: Unknown result type (might be due to invalid IL or missing references)
			//IL_01f0: Unknown result type (might be due to invalid IL or missing references)
			//IL_01fc: Expected O, but got Unknown
			//IL_01fd: Expected O, but got Unknown
			//IL_0208: Unknown result type (might be due to invalid IL or missing references)
			//IL_020d: Unknown result type (might be due to invalid IL or missing references)
			//IL_021e: Expected O, but got Unknown
			//IL_021f: Expected O, but got Unknown
			//IL_023a: Unknown result type (might be due to invalid IL or missing references)
			//IL_023f: Unknown result type (might be due to invalid IL or missing references)
			//IL_0250: Expected O, but got Unknown
			//IL_025a: Unknown result type (might be due to invalid IL or missing references)
			//IL_025f: Unknown result type (might be due to invalid IL or missing references)
			//IL_026a: Expected O, but got Unknown
			//IL_026b: Expected O, but got Unknown
			//IL_0286: Unknown result type (might be due to invalid IL or missing references)
			//IL_028b: Unknown result type (might be due to invalid IL or missing references)
			//IL_029c: Expected O, but got Unknown
			//IL_02a6: Unknown result type (might be due to invalid IL or missing references)
			//IL_02ab: Unknown result type (might be due to invalid IL or missing references)
			//IL_02b6: Expected O, but got Unknown
			//IL_02b7: Expected O, but got Unknown
			//IL_02d2: Unknown result type (might be due to invalid IL or missing references)
			//IL_02d7: Unknown result type (might be due to invalid IL or missing references)
			//IL_02e8: Expected O, but got Unknown
			//IL_02f2: Unknown result type (might be due to invalid IL or missing references)
			//IL_02f7: Unknown result type (might be due to invalid IL or missing references)
			//IL_0302: Expected O, but got Unknown
			//IL_0303: Expected O, but got Unknown
			//IL_031d: Unknown result type (might be due to invalid IL or missing references)
			//IL_0322: Unknown result type (might be due to invalid IL or missing references)
			//IL_032e: Expected O, but got Unknown
			//IL_033f: Unknown result type (might be due to invalid IL or missing references)
			//IL_0344: Unknown result type (might be due to invalid IL or missing references)
			//IL_034f: Expected O, but got Unknown
			//IL_0350: Expected O, but got Unknown
			//IL_036b: Unknown result type (might be due to invalid IL or missing references)
			//IL_0370: Unknown result type (might be due to invalid IL or missing references)
			//IL_0381: Expected O, but got Unknown
			//IL_038b: Unknown result type (might be due to invalid IL or missing references)
			//IL_0390: Unknown result type (might be due to invalid IL or missing references)
			//IL_039b: Expected O, but got Unknown
			//IL_039c: Expected O, but got Unknown
			//IL_03a7: Unknown result type (might be due to invalid IL or missing references)
			//IL_03ac: Unknown result type (might be due to invalid IL or missing references)
			//IL_03bd: Expected O, but got Unknown
			//IL_03be: Expected O, but got Unknown
			//IL_03d8: Unknown result type (might be due to invalid IL or missing references)
			//IL_03dd: Unknown result type (might be due to invalid IL or missing references)
			//IL_03e9: Expected O, but got Unknown
			//IL_03fa: Unknown result type (might be due to invalid IL or missing references)
			//IL_03ff: Unknown result type (might be due to invalid IL or missing references)
			//IL_040a: Expected O, but got Unknown
			//IL_040b: Expected O, but got Unknown
			//IL_0416: Unknown result type (might be due to invalid IL or missing references)
			//IL_041b: Unknown result type (might be due to invalid IL or missing references)
			//IL_042c: Expected O, but got Unknown
			//IL_042d: Expected O, but got Unknown
			//IL_0447: Unknown result type (might be due to invalid IL or missing references)
			//IL_044c: Unknown result type (might be due to invalid IL or missing references)
			//IL_0458: Expected O, but got Unknown
			//IL_0469: Unknown result type (might be due to invalid IL or missing references)
			//IL_046e: Unknown result type (might be due to invalid IL or missing references)
			//IL_0479: Expected O, but got Unknown
			//IL_047a: Expected O, but got Unknown
			//IL_0495: Unknown result type (might be due to invalid IL or missing references)
			//IL_049a: Unknown result type (might be due to invalid IL or missing references)
			//IL_04ab: Expected O, but got Unknown
			//IL_04b5: Unknown result type (might be due to invalid IL or missing references)
			//IL_04ba: Unknown result type (might be due to invalid IL or missing references)
			//IL_04c5: Expected O, but got Unknown
			//IL_04c6: Expected O, but got Unknown
			//IL_04e0: Unknown result type (might be due to invalid IL or missing references)
			//IL_04e5: Unknown result type (might be due to invalid IL or missing references)
			//IL_04f1: Expected O, but got Unknown
			//IL_0502: Unknown result type (might be due to invalid IL or missing references)
			//IL_0507: Unknown result type (might be due to invalid IL or missing references)
			//IL_0512: Expected O, but got Unknown
			//IL_0513: Expected O, but got Unknown
			//IL_051c: Unknown result type (might be due to invalid IL or missing references)
			//IL_0521: Unknown result type (might be due to invalid IL or missing references)
			//IL_0532: Expected O, but got Unknown
			//IL_0533: Expected O, but got Unknown
			//IL_053c: Unknown result type (might be due to invalid IL or missing references)
			//IL_0541: Unknown result type (might be due to invalid IL or missing references)
			//IL_0552: Expected O, but got Unknown
			//IL_0553: Expected O, but got Unknown
			//IL_0562: Unknown result type (might be due to invalid IL or missing references)
			//IL_0567: Unknown result type (might be due to invalid IL or missing references)
			//IL_0578: Expected O, but got Unknown
			//IL_0579: Expected O, but got Unknown
			string sql = "UPDATE workflowtask SET \r\n\t\t\t\tPrevID=@PrevID,PrevStepID=@PrevStepID,FlowID=@FlowID,StepID=@StepID,StepName=@StepName,InstanceID=@InstanceID,GroupID=@GroupID,Type=@Type,Title=@Title,SenderID=@SenderID,SenderName=@SenderName,SenderTime=@SenderTime,ReceiveID=@ReceiveID,ReceiveName=@ReceiveName,ReceiveTime=@ReceiveTime,OpenTime=@OpenTime,CompletedTime=@CompletedTime,CompletedTime1=@CompletedTime1,Comment=@Comment,IsSign=@IsSign,Status=@Status,Note=@Note,Sort=@Sort,SubFlowGroupID=@SubFlowGroupID,OtherType=@OtherType,Files=@Files,IsExpiredAutoSubmit=@IsExpiredAutoSubmit,StepSort=@StepSort  \r\n\t\t\t\tWHERE ID=@ID";
			MySqlParameter[] obj = new MySqlParameter[29];
			MySqlParameter val = new MySqlParameter("@PrevID", 253, 36);
			((DbParameter)val).Value = model.PrevID;
			obj[0] = val;
			MySqlParameter val2 = new MySqlParameter("@PrevStepID", 253, 36);
			((DbParameter)val2).Value = model.PrevStepID;
			obj[1] = val2;
			MySqlParameter val3 = new MySqlParameter("@FlowID", 253, 36);
			((DbParameter)val3).Value = model.FlowID;
			obj[2] = val3;
			MySqlParameter val4 = new MySqlParameter("@StepID", 253, 36);
			((DbParameter)val4).Value = model.StepID;
			obj[3] = val4;
			MySqlParameter val5 = new MySqlParameter("@StepName", 253, 255);
			((DbParameter)val5).Value = model.StepName;
			obj[4] = val5;
			MySqlParameter val6 = new MySqlParameter("@InstanceID", 253, 50);
			((DbParameter)val6).Value = model.InstanceID;
			obj[5] = val6;
			MySqlParameter val7 = new MySqlParameter("@GroupID", 253, 36);
			((DbParameter)val7).Value = model.GroupID;
			obj[6] = val7;
			MySqlParameter val8 = new MySqlParameter("@Type", 3, 11);
			((DbParameter)val8).Value = model.Type;
			obj[7] = val8;
			MySqlParameter val9 = new MySqlParameter("@Title", 253, 255);
			((DbParameter)val9).Value = model.Title;
			obj[8] = val9;
			MySqlParameter val10 = new MySqlParameter("@SenderID", 253, 36);
			((DbParameter)val10).Value = model.SenderID;
			obj[9] = val10;
			MySqlParameter val11 = new MySqlParameter("@SenderName", 253, 50);
			((DbParameter)val11).Value = model.SenderName;
			obj[10] = val11;
			MySqlParameter val12 = new MySqlParameter("@SenderTime", 12, -1);
			((DbParameter)val12).Value = model.SenderTime;
			obj[11] = val12;
			MySqlParameter val13 = new MySqlParameter("@ReceiveID", 253, 36);
			((DbParameter)val13).Value = model.ReceiveID;
			obj[12] = val13;
			MySqlParameter val14 = new MySqlParameter("@ReceiveName", 253, 50);
			((DbParameter)val14).Value = model.ReceiveName;
			obj[13] = val14;
			MySqlParameter val15 = new MySqlParameter("@ReceiveTime", 12, -1);
			((DbParameter)val15).Value = model.ReceiveTime;
			obj[14] = val15;
			_003F val16;
			if (model.OpenTime.HasValue)
			{
				val16 = new MySqlParameter("@OpenTime", 12, -1);
				((DbParameter)val16).Value = model.OpenTime;
			}
			else
			{
				val16 = new MySqlParameter("@OpenTime", 12, -1);
				((DbParameter)val16).Value = DBNull.Value;
			}
			obj[15] = val16;
			_003F val17;
			if (model.CompletedTime.HasValue)
			{
				val17 = new MySqlParameter("@CompletedTime", 12, -1);
				((DbParameter)val17).Value = model.CompletedTime;
			}
			else
			{
				val17 = new MySqlParameter("@CompletedTime", 12, -1);
				((DbParameter)val17).Value = DBNull.Value;
			}
			obj[16] = val17;
			_003F val18;
			if (model.CompletedTime1.HasValue)
			{
				val18 = new MySqlParameter("@CompletedTime1", 12, -1);
				((DbParameter)val18).Value = model.CompletedTime1;
			}
			else
			{
				val18 = new MySqlParameter("@CompletedTime1", 12, -1);
				((DbParameter)val18).Value = DBNull.Value;
			}
			obj[17] = val18;
			_003F val19;
			if (model.Comment != null)
			{
				val19 = new MySqlParameter("@Comment", 253, 255);
				((DbParameter)val19).Value = model.Comment;
			}
			else
			{
				val19 = new MySqlParameter("@Comment", 253, 255);
				((DbParameter)val19).Value = DBNull.Value;
			}
			obj[18] = val19;
			_003F val20;
			if (model.IsSign.HasValue)
			{
				val20 = new MySqlParameter("@IsSign", 3, 11);
				((DbParameter)val20).Value = model.IsSign;
			}
			else
			{
				val20 = new MySqlParameter("@IsSign", 3, 11);
				((DbParameter)val20).Value = DBNull.Value;
			}
			obj[19] = val20;
			MySqlParameter val21 = new MySqlParameter("@Status", 3, 11);
			((DbParameter)val21).Value = model.Status;
			obj[20] = val21;
			_003F val22;
			if (model.Note != null)
			{
				val22 = new MySqlParameter("@Note", 253, 255);
				((DbParameter)val22).Value = model.Note;
			}
			else
			{
				val22 = new MySqlParameter("@Note", 253, 255);
				((DbParameter)val22).Value = DBNull.Value;
			}
			obj[21] = val22;
			MySqlParameter val23 = new MySqlParameter("@Sort", 3, 11);
			((DbParameter)val23).Value = model.Sort;
			obj[22] = val23;
			_003F val24;
			if (model.SubFlowGroupID != null)
			{
				val24 = new MySqlParameter("@SubFlowGroupID", 253, 2000);
				((DbParameter)val24).Value = model.SubFlowGroupID;
			}
			else
			{
				val24 = new MySqlParameter("@SubFlowGroupID", 253, 2000);
				((DbParameter)val24).Value = DBNull.Value;
			}
			obj[23] = val24;
			_003F val25;
			if (model.OtherType.HasValue)
			{
				val25 = new MySqlParameter("@OtherType", 3, 11);
				((DbParameter)val25).Value = model.OtherType;
			}
			else
			{
				val25 = new MySqlParameter("@OtherType", 3, 11);
				((DbParameter)val25).Value = DBNull.Value;
			}
			obj[24] = val25;
			_003F val26;
			if (model.Files != null)
			{
				val26 = new MySqlParameter("@Files", 253, 4000);
				((DbParameter)val26).Value = model.Files;
			}
			else
			{
				val26 = new MySqlParameter("@Files", 253, 4000);
				((DbParameter)val26).Value = DBNull.Value;
			}
			obj[25] = val26;
			MySqlParameter val27 = new MySqlParameter("@IsExpiredAutoSubmit", 3);
			((DbParameter)val27).Value = model.IsExpiredAutoSubmit;
			obj[26] = val27;
			MySqlParameter val28 = new MySqlParameter("@StepSort", 3);
			((DbParameter)val28).Value = model.StepSort;
			obj[27] = val28;
			MySqlParameter val29 = new MySqlParameter("@ID", 253, 36);
			((DbParameter)val29).Value = model.ID;
			obj[28] = val29;
			MySqlParameter[] parameter = (MySqlParameter[])obj;
			return dbHelper.Execute(sql, parameter);
		}

		public int Delete(Guid id)
		{
			//IL_001a: Unknown result type (might be due to invalid IL or missing references)
			//IL_001f: Unknown result type (might be due to invalid IL or missing references)
			//IL_0032: Expected O, but got Unknown
			//IL_0033: Expected O, but got Unknown
			string sql = "DELETE FROM workflowtask WHERE ID=@ID";
			MySqlParameter[] obj = new MySqlParameter[1];
			MySqlParameter val = new MySqlParameter("@ID", 253, 36);
			((DbParameter)val).Value = id.ToString();
			obj[0] = val;
			MySqlParameter[] parameter = (MySqlParameter[])obj;
			return dbHelper.Execute(sql, parameter);
		}

		private List<RoadFlow.Data.Model.WorkFlowTask> DataReaderToList(MySqlDataReader dataReader)
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
			string sql = "SELECT * FROM workflowtask";
			MySqlDataReader dataReader = dbHelper.GetDataReader(sql);
			List<RoadFlow.Data.Model.WorkFlowTask> result = DataReaderToList(dataReader);
			((DbDataReader)dataReader).Close();
			return result;
		}

		public long GetCount()
		{
			string sql = "SELECT COUNT(*) FROM workflowtask";
			long result;
			if (!long.TryParse(dbHelper.GetFieldValue(sql), out result))
			{
				return 0L;
			}
			return result;
		}

		public RoadFlow.Data.Model.WorkFlowTask Get(Guid id)
		{
			//IL_001a: Unknown result type (might be due to invalid IL or missing references)
			//IL_001f: Unknown result type (might be due to invalid IL or missing references)
			//IL_0032: Expected O, but got Unknown
			//IL_0033: Expected O, but got Unknown
			string sql = "SELECT * FROM workflowtask WHERE ID=@ID";
			MySqlParameter[] obj = new MySqlParameter[1];
			MySqlParameter val = new MySqlParameter("@ID", 253, 36);
			((DbParameter)val).Value = id.ToString();
			obj[0] = val;
			MySqlParameter[] parameter = (MySqlParameter[])obj;
			MySqlDataReader dataReader = dbHelper.GetDataReader(sql, parameter);
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
			//IL_0016: Unknown result type (might be due to invalid IL or missing references)
			//IL_001b: Unknown result type (might be due to invalid IL or missing references)
			//IL_002e: Expected O, but got Unknown
			//IL_0033: Expected O, but got Unknown
			//IL_0053: Unknown result type (might be due to invalid IL or missing references)
			//IL_0058: Unknown result type (might be due to invalid IL or missing references)
			//IL_006b: Expected O, but got Unknown
			//IL_0070: Expected O, but got Unknown
			string text = "DELETE FROM WorkFlowTask WHERE GroupID=@GroupID";
			List<MySqlParameter> list = new List<MySqlParameter>();
			MySqlParameter val = new MySqlParameter("@GroupID", 253);
			((DbParameter)val).Value = groupID.ToString();
			list.Add(val);
			List<MySqlParameter> list2 = list;
			if (!flowID.IsEmptyGuid())
			{
				text += " AND FlowID=@FlowID";
				List<MySqlParameter> list3 = list2;
				MySqlParameter val2 = new MySqlParameter("@FlowID", 253);
				((DbParameter)val2).Value = flowID.ToString();
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
			//IL_0072: Unknown result type (might be due to invalid IL or missing references)
			//IL_0077: Unknown result type (might be due to invalid IL or missing references)
			//IL_008a: Expected O, but got Unknown
			//IL_008b: Expected O, but got Unknown
			string sql = "UPDATE WorkFlowTask SET OpenTime=@OpenTime " + (isStatus ? ", Status=1" : "") + " WHERE ID=@ID AND OpenTime IS NULL";
			MySqlParameter[] obj = new MySqlParameter[2];
			_003F val;
			if (!(openTime == DateTime.MinValue))
			{
				val = new MySqlParameter("@OpenTime", 12);
				((DbParameter)val).Value = openTime;
			}
			else
			{
				val = new MySqlParameter("@OpenTime", 12);
				((DbParameter)val).Value = DBNull.Value;
			}
			obj[0] = val;
			MySqlParameter val2 = new MySqlParameter("@ID", 253);
			((DbParameter)val2).Value = id.ToString();
			obj[1] = val2;
			MySqlParameter[] parameter = (MySqlParameter[])obj;
			dbHelper.Execute(sql, parameter);
		}

		public List<RoadFlow.Data.Model.WorkFlowTask> GetTasks(Guid userID, out string pager, string query = "", string title = "", string flowid = "", string sender = "", string date1 = "", string date2 = "", int type = 0)
		{
			//IL_0033: Unknown result type (might be due to invalid IL or missing references)
			//IL_0038: Unknown result type (might be due to invalid IL or missing references)
			//IL_004b: Expected O, but got Unknown
			//IL_0050: Expected O, but got Unknown
			//IL_0075: Unknown result type (might be due to invalid IL or missing references)
			//IL_007a: Unknown result type (might be due to invalid IL or missing references)
			//IL_0082: Expected O, but got Unknown
			//IL_0087: Expected O, but got Unknown
			//IL_00a7: Unknown result type (might be due to invalid IL or missing references)
			//IL_00ac: Unknown result type (might be due to invalid IL or missing references)
			//IL_00b4: Expected O, but got Unknown
			//IL_00b9: Expected O, but got Unknown
			//IL_0113: Unknown result type (might be due to invalid IL or missing references)
			//IL_0118: Unknown result type (might be due to invalid IL or missing references)
			//IL_0120: Expected O, but got Unknown
			//IL_0125: Expected O, but got Unknown
			//IL_0142: Unknown result type (might be due to invalid IL or missing references)
			//IL_0147: Unknown result type (might be due to invalid IL or missing references)
			//IL_0162: Expected O, but got Unknown
			//IL_0167: Expected O, but got Unknown
			//IL_0184: Unknown result type (might be due to invalid IL or missing references)
			//IL_0189: Unknown result type (might be due to invalid IL or missing references)
			//IL_01b6: Expected O, but got Unknown
			//IL_01bb: Expected O, but got Unknown
			List<MySqlParameter> list = new List<MySqlParameter>();
			StringBuilder stringBuilder = new StringBuilder("SELECT * FROM WorkFlowTask WHERE ReceiveID=@ReceiveID");
			stringBuilder.Append((type == 0) ? " AND Status IN(0,1)" : " AND Status IN(2,3,4,5)");
			List<MySqlParameter> list2 = list;
			MySqlParameter val = new MySqlParameter("@ReceiveID", 253);
			((DbParameter)val).Value = userID.ToString();
			list2.Add(val);
			if (!title.IsNullOrEmpty())
			{
				stringBuilder.Append(" AND INSTR(Title,@Title)>0");
				List<MySqlParameter> list3 = list;
				MySqlParameter val2 = new MySqlParameter("@Title", 253, 2000);
				((DbParameter)val2).Value = title;
				list3.Add(val2);
			}
			if (flowid.IsGuid())
			{
				stringBuilder.Append(" AND FlowID=@FlowID");
				List<MySqlParameter> list4 = list;
				MySqlParameter val3 = new MySqlParameter("@FlowID", 253);
				((DbParameter)val3).Value = flowid;
				list4.Add(val3);
			}
			else if (!flowid.IsNullOrEmpty() && flowid.IndexOf(',') >= 0)
			{
				stringBuilder.Append(" AND FlowID IN(" + Tools.GetSqlInString(flowid) + ")");
			}
			if (sender.IsGuid())
			{
				stringBuilder.Append(" AND SenderID=@SenderID");
				List<MySqlParameter> list5 = list;
				MySqlParameter val4 = new MySqlParameter("@SenderID", 253);
				((DbParameter)val4).Value = sender;
				list5.Add(val4);
			}
			if (date1.IsDateTime())
			{
				stringBuilder.Append(" AND ReceiveTime>=@ReceiveTime");
				List<MySqlParameter> list6 = list;
				MySqlParameter val5 = new MySqlParameter("@ReceiveTime", 12);
				((DbParameter)val5).Value = date1.ToDateTime().Date;
				list6.Add(val5);
			}
			if (date2.IsDateTime())
			{
				stringBuilder.Append(" AND SenderTime<=@ReceiveTime1");
				List<MySqlParameter> list7 = list;
				MySqlParameter val6 = new MySqlParameter("@ReceiveTime1", 12);
				((DbParameter)val6).Value = date2.ToDateTime().AddDays(1.0).Date;
				list7.Add(val6);
			}
			stringBuilder.Append(" ORDER BY " + ((type == 0) ? "SenderTime DESC" : "CompletedTime1 DESC"));
			int pageSize = Tools.GetPageSize();
			int pageNumber = Tools.GetPageNumber();
			long count;
			string paerSql = dbHelper.GetPaerSql(stringBuilder.ToString(), pageSize, pageNumber, out count, list.ToArray());
			pager = Tools.GetPagerHtml(count, pageSize, pageNumber, query);
			MySqlDataReader dataReader = dbHelper.GetDataReader(paerSql, list.ToArray());
			List<RoadFlow.Data.Model.WorkFlowTask> result = DataReaderToList(dataReader);
			((DbDataReader)dataReader).Close();
			return result;
		}

		public List<RoadFlow.Data.Model.WorkFlowTask> GetTasks(Guid userID, out long count, int size, int number, string title = "", string flowid = "", string sender = "", string date1 = "", string date2 = "", int type = 0, string order = "")
		{
			//IL_0033: Unknown result type (might be due to invalid IL or missing references)
			//IL_0038: Unknown result type (might be due to invalid IL or missing references)
			//IL_004b: Expected O, but got Unknown
			//IL_0050: Expected O, but got Unknown
			//IL_0075: Unknown result type (might be due to invalid IL or missing references)
			//IL_007a: Unknown result type (might be due to invalid IL or missing references)
			//IL_0082: Expected O, but got Unknown
			//IL_0087: Expected O, but got Unknown
			//IL_00a7: Unknown result type (might be due to invalid IL or missing references)
			//IL_00ac: Unknown result type (might be due to invalid IL or missing references)
			//IL_00b4: Expected O, but got Unknown
			//IL_00b9: Expected O, but got Unknown
			//IL_0113: Unknown result type (might be due to invalid IL or missing references)
			//IL_0118: Unknown result type (might be due to invalid IL or missing references)
			//IL_0120: Expected O, but got Unknown
			//IL_0125: Expected O, but got Unknown
			//IL_0142: Unknown result type (might be due to invalid IL or missing references)
			//IL_0147: Unknown result type (might be due to invalid IL or missing references)
			//IL_0162: Expected O, but got Unknown
			//IL_0167: Expected O, but got Unknown
			//IL_0184: Unknown result type (might be due to invalid IL or missing references)
			//IL_0189: Unknown result type (might be due to invalid IL or missing references)
			//IL_01b6: Expected O, but got Unknown
			//IL_01bb: Expected O, but got Unknown
			List<MySqlParameter> list = new List<MySqlParameter>();
			StringBuilder stringBuilder = new StringBuilder("SELECT * FROM WorkFlowTask WHERE ReceiveID=@ReceiveID");
			stringBuilder.Append((type == 0) ? " AND Status IN(0,1)" : " AND Status IN(2,3,4,5)");
			List<MySqlParameter> list2 = list;
			MySqlParameter val = new MySqlParameter("@ReceiveID", 253);
			((DbParameter)val).Value = userID.ToString();
			list2.Add(val);
			if (!title.IsNullOrEmpty())
			{
				stringBuilder.Append(" AND INSTR(Title,@Title)>0");
				List<MySqlParameter> list3 = list;
				MySqlParameter val2 = new MySqlParameter("@Title", 253, 2000);
				((DbParameter)val2).Value = title;
				list3.Add(val2);
			}
			if (flowid.IsGuid())
			{
				stringBuilder.Append(" AND FlowID=@FlowID");
				List<MySqlParameter> list4 = list;
				MySqlParameter val3 = new MySqlParameter("@FlowID", 253);
				((DbParameter)val3).Value = flowid;
				list4.Add(val3);
			}
			else if (!flowid.IsNullOrEmpty() && flowid.IndexOf(',') >= 0)
			{
				stringBuilder.Append(" AND FlowID IN(" + Tools.GetSqlInString(flowid) + ")");
			}
			if (sender.IsGuid())
			{
				stringBuilder.Append(" AND SenderID=@SenderID");
				List<MySqlParameter> list5 = list;
				MySqlParameter val4 = new MySqlParameter("@SenderID", 253);
				((DbParameter)val4).Value = sender;
				list5.Add(val4);
			}
			if (date1.IsDateTime())
			{
				stringBuilder.Append(" AND ReceiveTime>=@ReceiveTime");
				List<MySqlParameter> list6 = list;
				MySqlParameter val5 = new MySqlParameter("@ReceiveTime", 12);
				((DbParameter)val5).Value = date1.ToDateTime().Date;
				list6.Add(val5);
			}
			if (date2.IsDateTime())
			{
				stringBuilder.Append(" AND SenderTime<=@ReceiveTime1");
				List<MySqlParameter> list7 = list;
				MySqlParameter val6 = new MySqlParameter("@ReceiveTime1", 12);
				((DbParameter)val6).Value = date2.ToDateTime().AddDays(1.0).Date;
				list7.Add(val6);
			}
			stringBuilder.Append("ORDER BY " + ((!order.IsNullOrEmpty()) ? order : ((type == 0) ? "SenderTime DESC" : "CompletedTime1 DESC")));
			string paerSql = dbHelper.GetPaerSql(stringBuilder.ToString(), size, number, out count, list.ToArray());
			MySqlDataReader dataReader = dbHelper.GetDataReader(paerSql, list.ToArray());
			List<RoadFlow.Data.Model.WorkFlowTask> result = DataReaderToList(dataReader);
			((DbDataReader)dataReader).Close();
			return result;
		}

		public List<RoadFlow.Data.Model.WorkFlowTask> GetInstances(Guid[] flowID, Guid[] senderID, Guid[] receiveID, out string pager, string query = "", string title = "", string flowid = "", string date1 = "", string date2 = "", int status = 0)
		{
			//IL_007c: Unknown result type (might be due to invalid IL or missing references)
			//IL_0081: Unknown result type (might be due to invalid IL or missing references)
			//IL_0099: Expected O, but got Unknown
			//IL_009e: Expected O, but got Unknown
			//IL_00dc: Unknown result type (might be due to invalid IL or missing references)
			//IL_00e1: Unknown result type (might be due to invalid IL or missing references)
			//IL_00f9: Expected O, but got Unknown
			//IL_00fe: Expected O, but got Unknown
			//IL_013d: Unknown result type (might be due to invalid IL or missing references)
			//IL_0142: Unknown result type (might be due to invalid IL or missing references)
			//IL_014a: Expected O, but got Unknown
			//IL_014f: Expected O, but got Unknown
			//IL_016f: Unknown result type (might be due to invalid IL or missing references)
			//IL_0174: Unknown result type (might be due to invalid IL or missing references)
			//IL_017c: Expected O, but got Unknown
			//IL_0181: Expected O, but got Unknown
			//IL_01d8: Unknown result type (might be due to invalid IL or missing references)
			//IL_01dd: Unknown result type (might be due to invalid IL or missing references)
			//IL_01f8: Expected O, but got Unknown
			//IL_01fd: Expected O, but got Unknown
			//IL_021a: Unknown result type (might be due to invalid IL or missing references)
			//IL_021f: Unknown result type (might be due to invalid IL or missing references)
			//IL_024c: Expected O, but got Unknown
			//IL_0251: Expected O, but got Unknown
			List<MySqlParameter> list = new List<MySqlParameter>();
			StringBuilder stringBuilder = new StringBuilder("SELECT a.* FROM WorkFlowTask a\r\n                WHERE a.ID=(SELECT ID FROM WorkFlowTask WHERE FlowID=a.FlowID AND GroupID=a.GroupID ORDER BY Sort DESC LIMIT 0,1)");
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
					stringBuilder.Append(" AND a.SenderID=@SenderID");
					List<MySqlParameter> list2 = list;
					MySqlParameter val = new MySqlParameter("@SenderID", 253);
					((DbParameter)val).Value = senderID[0].ToString();
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
					stringBuilder.Append(" AND a.ReceiveID=@ReceiveID");
					List<MySqlParameter> list3 = list;
					MySqlParameter val2 = new MySqlParameter("@ReceiveID", 253);
					((DbParameter)val2).Value = receiveID[0].ToString();
					list3.Add(val2);
				}
				else
				{
					stringBuilder.Append(string.Format(" AND a.ReceiveID IN({0})", Tools.GetSqlInString(receiveID)));
				}
			}
			if (!title.IsNullOrEmpty())
			{
				stringBuilder.Append(" AND INSTR(a.Title,@Title)>0");
				List<MySqlParameter> list4 = list;
				MySqlParameter val3 = new MySqlParameter("@Title", 253, 2000);
				((DbParameter)val3).Value = title;
				list4.Add(val3);
			}
			if (flowid.IsGuid())
			{
				stringBuilder.Append(" AND a.FlowID=@FlowID");
				List<MySqlParameter> list5 = list;
				MySqlParameter val4 = new MySqlParameter("@FlowID", 253);
				((DbParameter)val4).Value = flowid;
				list5.Add(val4);
			}
			else if (!flowid.IsNullOrEmpty() && flowid.IndexOf(',') >= 0)
			{
				stringBuilder.Append(" AND a.FlowID IN(" + Tools.GetSqlInString(flowid) + ")");
			}
			if (date1.IsDateTime())
			{
				stringBuilder.Append(" AND a.SenderTime>=@SenderTime");
				List<MySqlParameter> list6 = list;
				MySqlParameter val5 = new MySqlParameter("@SenderTime", 12);
				((DbParameter)val5).Value = date1.ToDateTime().Date;
				list6.Add(val5);
			}
			if (date2.IsDateTime())
			{
				stringBuilder.Append(" AND a.SenderTime<=@SenderTime1");
				List<MySqlParameter> list7 = list;
				MySqlParameter val6 = new MySqlParameter("@SenderTime1", 12);
				((DbParameter)val6).Value = date2.ToDateTime().AddDays(1.0).Date;
				list7.Add(val6);
			}
			stringBuilder.Append(" ORDER BY a.SenderTime DESC");
			int pageSize = Tools.GetPageSize();
			int pageNumber = Tools.GetPageNumber();
			long count;
			string paerSql = dbHelper.GetPaerSql(stringBuilder.ToString(), pageSize, pageNumber, out count, list.ToArray());
			pager = Tools.GetPagerHtml(count, pageSize, pageNumber, query);
			MySqlDataReader dataReader = dbHelper.GetDataReader(paerSql, list.ToArray());
			List<RoadFlow.Data.Model.WorkFlowTask> result = DataReaderToList(dataReader);
			((DbDataReader)dataReader).Close();
			return result;
		}

		public DataTable GetInstances1(Guid[] flowID, Guid[] senderID, Guid[] receiveID, out string pager, string query = "", string title = "", string flowid = "", string date1 = "", string date2 = "", int status = 0)
		{
			//IL_0077: Unknown result type (might be due to invalid IL or missing references)
			//IL_007c: Unknown result type (might be due to invalid IL or missing references)
			//IL_0094: Expected O, but got Unknown
			//IL_0099: Expected O, but got Unknown
			//IL_00d7: Unknown result type (might be due to invalid IL or missing references)
			//IL_00dc: Unknown result type (might be due to invalid IL or missing references)
			//IL_00f4: Expected O, but got Unknown
			//IL_00f9: Expected O, but got Unknown
			//IL_0138: Unknown result type (might be due to invalid IL or missing references)
			//IL_013d: Unknown result type (might be due to invalid IL or missing references)
			//IL_0145: Expected O, but got Unknown
			//IL_014a: Expected O, but got Unknown
			//IL_016a: Unknown result type (might be due to invalid IL or missing references)
			//IL_016f: Unknown result type (might be due to invalid IL or missing references)
			//IL_0177: Expected O, but got Unknown
			//IL_017c: Expected O, but got Unknown
			//IL_01d3: Unknown result type (might be due to invalid IL or missing references)
			//IL_01d8: Unknown result type (might be due to invalid IL or missing references)
			//IL_01f3: Expected O, but got Unknown
			//IL_01f8: Expected O, but got Unknown
			//IL_0215: Unknown result type (might be due to invalid IL or missing references)
			//IL_021a: Unknown result type (might be due to invalid IL or missing references)
			//IL_0247: Expected O, but got Unknown
			//IL_024c: Expected O, but got Unknown
			List<MySqlParameter> list = new List<MySqlParameter>();
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
					stringBuilder.Append(" AND SenderID=@SenderID");
					List<MySqlParameter> list2 = list;
					MySqlParameter val = new MySqlParameter("@SenderID", 253);
					((DbParameter)val).Value = senderID[0].ToString();
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
					stringBuilder.Append(" AND ReceiveID=@ReceiveID");
					List<MySqlParameter> list3 = list;
					MySqlParameter val2 = new MySqlParameter("@ReceiveID", 253);
					((DbParameter)val2).Value = receiveID[0].ToString();
					list3.Add(val2);
				}
				else
				{
					stringBuilder.Append(string.Format(" AND ReceiveID IN({0})", Tools.GetSqlInString(receiveID)));
				}
			}
			if (!title.IsNullOrEmpty())
			{
				stringBuilder.Append(" AND INSTR(Title,@Title)>0");
				List<MySqlParameter> list4 = list;
				MySqlParameter val3 = new MySqlParameter("@Title", 253, 2000);
				((DbParameter)val3).Value = title;
				list4.Add(val3);
			}
			if (flowid.IsGuid())
			{
				stringBuilder.Append(" AND FlowID=@FlowID");
				List<MySqlParameter> list5 = list;
				MySqlParameter val4 = new MySqlParameter("@FlowID", 253);
				((DbParameter)val4).Value = flowid;
				list5.Add(val4);
			}
			else if (!flowid.IsNullOrEmpty() && flowid.IndexOf(',') >= 0)
			{
				stringBuilder.Append(" AND FlowID IN(" + Tools.GetSqlInString(flowid) + ")");
			}
			if (date1.IsDateTime())
			{
				stringBuilder.Append(" AND SenderTime>=@SenderTime");
				List<MySqlParameter> list6 = list;
				MySqlParameter val5 = new MySqlParameter("@SenderTime", 12);
				((DbParameter)val5).Value = date1.ToDateTime().Date;
				list6.Add(val5);
			}
			if (date2.IsDateTime())
			{
				stringBuilder.Append(" AND SenderTime<=@SenderTime1");
				List<MySqlParameter> list7 = list;
				MySqlParameter val6 = new MySqlParameter("@SenderTime1", 12);
				((DbParameter)val6).Value = date2.ToDateTime().AddDays(1.0).Date;
				list7.Add(val6);
			}
			string sql = string.Format("select * from(\r\nselect flowid,groupid,MAX(SenderTime) SenderTime from WorkFlowTask WHERE 1=1 {0} group by FlowID, GroupID\r\n) temp ORDER BY SenderTime DESC", stringBuilder.ToString());
			int pageSize = Tools.GetPageSize();
			int pageNumber = Tools.GetPageNumber();
			long count;
			string paerSql = dbHelper.GetPaerSql(sql, pageSize, pageNumber, out count, list.ToArray());
			pager = Tools.GetPagerHtml(count, pageSize, pageNumber, query);
			return dbHelper.GetDataTable(paerSql, list.ToArray());
		}

		public DataTable GetInstances1(Guid[] flowID, Guid[] senderID, Guid[] receiveID, out long count, int size, int number, string title = "", string flowid = "", string date1 = "", string date2 = "", int status = 0, string order = "")
		{
			//IL_0077: Unknown result type (might be due to invalid IL or missing references)
			//IL_007c: Unknown result type (might be due to invalid IL or missing references)
			//IL_0094: Expected O, but got Unknown
			//IL_0099: Expected O, but got Unknown
			//IL_00d7: Unknown result type (might be due to invalid IL or missing references)
			//IL_00dc: Unknown result type (might be due to invalid IL or missing references)
			//IL_00f4: Expected O, but got Unknown
			//IL_00f9: Expected O, but got Unknown
			//IL_0138: Unknown result type (might be due to invalid IL or missing references)
			//IL_013d: Unknown result type (might be due to invalid IL or missing references)
			//IL_0145: Expected O, but got Unknown
			//IL_014a: Expected O, but got Unknown
			//IL_016a: Unknown result type (might be due to invalid IL or missing references)
			//IL_016f: Unknown result type (might be due to invalid IL or missing references)
			//IL_0177: Expected O, but got Unknown
			//IL_017c: Expected O, but got Unknown
			//IL_01d3: Unknown result type (might be due to invalid IL or missing references)
			//IL_01d8: Unknown result type (might be due to invalid IL or missing references)
			//IL_01f3: Expected O, but got Unknown
			//IL_01f8: Expected O, but got Unknown
			//IL_0215: Unknown result type (might be due to invalid IL or missing references)
			//IL_021a: Unknown result type (might be due to invalid IL or missing references)
			//IL_0247: Expected O, but got Unknown
			//IL_024c: Expected O, but got Unknown
			List<MySqlParameter> list = new List<MySqlParameter>();
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
					stringBuilder.Append(" AND SenderID=@SenderID");
					List<MySqlParameter> list2 = list;
					MySqlParameter val = new MySqlParameter("@SenderID", 253);
					((DbParameter)val).Value = senderID[0].ToString();
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
					stringBuilder.Append(" AND ReceiveID=@ReceiveID");
					List<MySqlParameter> list3 = list;
					MySqlParameter val2 = new MySqlParameter("@ReceiveID", 253);
					((DbParameter)val2).Value = receiveID[0].ToString();
					list3.Add(val2);
				}
				else
				{
					stringBuilder.Append(string.Format(" AND ReceiveID IN({0})", Tools.GetSqlInString(receiveID)));
				}
			}
			if (!title.IsNullOrEmpty())
			{
				stringBuilder.Append(" AND INSTR(Title,@Title)>0");
				List<MySqlParameter> list4 = list;
				MySqlParameter val3 = new MySqlParameter("@Title", 253, 2000);
				((DbParameter)val3).Value = title;
				list4.Add(val3);
			}
			if (flowid.IsGuid())
			{
				stringBuilder.Append(" AND FlowID=@FlowID");
				List<MySqlParameter> list5 = list;
				MySqlParameter val4 = new MySqlParameter("@FlowID", 253);
				((DbParameter)val4).Value = flowid;
				list5.Add(val4);
			}
			else if (!flowid.IsNullOrEmpty() && flowid.IndexOf(',') >= 0)
			{
				stringBuilder.Append(" AND FlowID IN(" + Tools.GetSqlInString(flowid) + ")");
			}
			if (date1.IsDateTime())
			{
				stringBuilder.Append(" AND SenderTime>=@SenderTime");
				List<MySqlParameter> list6 = list;
				MySqlParameter val5 = new MySqlParameter("@SenderTime", 12);
				((DbParameter)val5).Value = date1.ToDateTime().Date;
				list6.Add(val5);
			}
			if (date2.IsDateTime())
			{
				stringBuilder.Append(" AND SenderTime<=@SenderTime1");
				List<MySqlParameter> list7 = list;
				MySqlParameter val6 = new MySqlParameter("@SenderTime1", 12);
				((DbParameter)val6).Value = date2.ToDateTime().AddDays(1.0).Date;
				list7.Add(val6);
			}
			string sql = string.Format("select * from(\r\nselect flowid,groupid,MAX(SenderTime) SenderTime from WorkFlowTask WHERE 1=1 {0} group by FlowID, GroupID\r\n) temp ORDER BY " + (order.IsNullOrEmpty() ? "SenderTime DESC" : order), stringBuilder.ToString());
			string paerSql = dbHelper.GetPaerSql(sql, size, number, out count, list.ToArray());
			return dbHelper.GetDataTable(paerSql, list.ToArray());
		}

		public Guid GetFirstSnderID(Guid flowID, Guid groupID)
		{
			//IL_0018: Unknown result type (might be due to invalid IL or missing references)
			//IL_001d: Unknown result type (might be due to invalid IL or missing references)
			//IL_0030: Expected O, but got Unknown
			//IL_0031: Expected O, but got Unknown
			//IL_003d: Unknown result type (might be due to invalid IL or missing references)
			//IL_0042: Unknown result type (might be due to invalid IL or missing references)
			//IL_0055: Expected O, but got Unknown
			//IL_0056: Expected O, but got Unknown
			//IL_0062: Unknown result type (might be due to invalid IL or missing references)
			//IL_0067: Unknown result type (might be due to invalid IL or missing references)
			//IL_0080: Expected O, but got Unknown
			//IL_0081: Expected O, but got Unknown
			string sql = "SELECT SenderID FROM WorkFlowTask WHERE FlowID=@FlowID AND GroupID=@GroupID AND PrevID=@PrevID";
			MySqlParameter[] obj = new MySqlParameter[3];
			MySqlParameter val = new MySqlParameter("@FlowID", 253);
			((DbParameter)val).Value = flowID.ToString();
			obj[0] = val;
			MySqlParameter val2 = new MySqlParameter("@GroupID", 253);
			((DbParameter)val2).Value = groupID.ToString();
			obj[1] = val2;
			MySqlParameter val3 = new MySqlParameter("@PrevID", 253);
			((DbParameter)val3).Value = Guid.Empty.ToString();
			obj[2] = val3;
			MySqlParameter[] parameter = (MySqlParameter[])obj;
			return dbHelper.GetFieldValue(sql, parameter).ToGuid();
		}

		public List<Guid> GetStepSnderID(Guid flowID, Guid stepID, Guid groupID)
		{
			//IL_0018: Unknown result type (might be due to invalid IL or missing references)
			//IL_001d: Unknown result type (might be due to invalid IL or missing references)
			//IL_0030: Expected O, but got Unknown
			//IL_0031: Expected O, but got Unknown
			//IL_003d: Unknown result type (might be due to invalid IL or missing references)
			//IL_0042: Unknown result type (might be due to invalid IL or missing references)
			//IL_0055: Expected O, but got Unknown
			//IL_0056: Expected O, but got Unknown
			//IL_0062: Unknown result type (might be due to invalid IL or missing references)
			//IL_0067: Unknown result type (might be due to invalid IL or missing references)
			//IL_007a: Expected O, but got Unknown
			//IL_007b: Expected O, but got Unknown
			string sql = "SELECT ReceiveID, Sort FROM WorkFlowTask WHERE FlowID=@FlowID AND StepID=@StepID AND GroupID=@GroupID AND Sort=(SELECT IFNULL(MAX(Sort),0) FROM WorkFlowTask WHERE FlowID=@FlowID AND StepID=@StepID AND GroupID=@GroupID)";
			MySqlParameter[] obj = new MySqlParameter[3];
			MySqlParameter val = new MySqlParameter("@FlowID", 253);
			((DbParameter)val).Value = flowID.ToString();
			obj[0] = val;
			MySqlParameter val2 = new MySqlParameter("@StepID", 253);
			((DbParameter)val2).Value = stepID.ToString();
			obj[1] = val2;
			MySqlParameter val3 = new MySqlParameter("@GroupID", 253);
			((DbParameter)val3).Value = groupID.ToString();
			obj[2] = val3;
			MySqlParameter[] parameter = (MySqlParameter[])obj;
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
			//IL_0018: Unknown result type (might be due to invalid IL or missing references)
			//IL_001d: Unknown result type (might be due to invalid IL or missing references)
			//IL_0030: Expected O, but got Unknown
			//IL_0031: Expected O, but got Unknown
			//IL_003d: Unknown result type (might be due to invalid IL or missing references)
			//IL_0042: Unknown result type (might be due to invalid IL or missing references)
			//IL_0055: Expected O, but got Unknown
			//IL_0056: Expected O, but got Unknown
			//IL_0062: Unknown result type (might be due to invalid IL or missing references)
			//IL_0067: Unknown result type (might be due to invalid IL or missing references)
			//IL_007a: Expected O, but got Unknown
			//IL_007b: Expected O, but got Unknown
			string sql = "SELECT ReceiveID FROM WorkFlowTask WHERE ID=(SELECT PrevID FROM WorkFlowTask WHERE FlowID=@FlowID AND StepID=@StepID AND GroupID=@GroupID)";
			MySqlParameter[] obj = new MySqlParameter[3];
			MySqlParameter val = new MySqlParameter("@FlowID", 253);
			((DbParameter)val).Value = flowID.ToString();
			obj[0] = val;
			MySqlParameter val2 = new MySqlParameter("@StepID", 253);
			((DbParameter)val2).Value = stepID.ToString();
			obj[1] = val2;
			MySqlParameter val3 = new MySqlParameter("@GroupID", 253);
			((DbParameter)val3).Value = groupID.ToString();
			obj[2] = val3;
			MySqlParameter[] parameter = (MySqlParameter[])obj;
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
			//IL_0020: Unknown result type (might be due to invalid IL or missing references)
			//IL_0025: Unknown result type (might be due to invalid IL or missing references)
			//IL_002c: Expected O, but got Unknown
			//IL_0038: Unknown result type (might be due to invalid IL or missing references)
			//IL_003d: Unknown result type (might be due to invalid IL or missing references)
			//IL_0048: Expected O, but got Unknown
			//IL_0049: Expected O, but got Unknown
			//IL_0052: Unknown result type (might be due to invalid IL or missing references)
			//IL_0057: Unknown result type (might be due to invalid IL or missing references)
			//IL_0067: Expected O, but got Unknown
			//IL_0068: Expected O, but got Unknown
			//IL_0070: Unknown result type (might be due to invalid IL or missing references)
			//IL_0075: Unknown result type (might be due to invalid IL or missing references)
			//IL_0087: Expected O, but got Unknown
			//IL_0088: Expected O, but got Unknown
			//IL_0090: Unknown result type (might be due to invalid IL or missing references)
			//IL_0095: Unknown result type (might be due to invalid IL or missing references)
			//IL_00a2: Expected O, but got Unknown
			//IL_00a3: Expected O, but got Unknown
			//IL_00b8: Unknown result type (might be due to invalid IL or missing references)
			//IL_00bd: Unknown result type (might be due to invalid IL or missing references)
			//IL_00c5: Expected O, but got Unknown
			//IL_00d1: Unknown result type (might be due to invalid IL or missing references)
			//IL_00d6: Unknown result type (might be due to invalid IL or missing references)
			//IL_00e1: Expected O, but got Unknown
			//IL_00e2: Expected O, but got Unknown
			//IL_00f7: Unknown result type (might be due to invalid IL or missing references)
			//IL_00fc: Unknown result type (might be due to invalid IL or missing references)
			//IL_0104: Expected O, but got Unknown
			//IL_0110: Unknown result type (might be due to invalid IL or missing references)
			//IL_0115: Unknown result type (might be due to invalid IL or missing references)
			//IL_0120: Expected O, but got Unknown
			//IL_0121: Expected O, but got Unknown
			//IL_012d: Unknown result type (might be due to invalid IL or missing references)
			//IL_0132: Unknown result type (might be due to invalid IL or missing references)
			//IL_0145: Expected O, but got Unknown
			//IL_0146: Expected O, but got Unknown
			string sql = "UPDATE WorkFlowTask SET Comment=@Comment,CompletedTime1=@CompletedTime1,IsSign=@IsSign,Status=@Status,Note=@Note,Files=@Files WHERE ID=@ID";
			MySqlParameter[] obj = new MySqlParameter[7];
			_003F val;
			if (!comment.IsNullOrEmpty())
			{
				val = new MySqlParameter("@Comment", 253);
				((DbParameter)val).Value = comment;
			}
			else
			{
				val = new MySqlParameter("@Comment", 253);
				((DbParameter)val).Value = DBNull.Value;
			}
			obj[0] = val;
			MySqlParameter val2 = new MySqlParameter("@CompletedTime1", 12);
			((DbParameter)val2).Value = DateTimeNew.Now;
			obj[1] = val2;
			MySqlParameter val3 = new MySqlParameter("@IsSign", 3);
			((DbParameter)val3).Value = (isSign ? 1 : 0);
			obj[2] = val3;
			MySqlParameter val4 = new MySqlParameter("@Status", 3);
			((DbParameter)val4).Value = status;
			obj[3] = val4;
			_003F val5;
			if (!note.IsNullOrEmpty())
			{
				val5 = new MySqlParameter("@Note", 253);
				((DbParameter)val5).Value = note;
			}
			else
			{
				val5 = new MySqlParameter("@Note", 253);
				((DbParameter)val5).Value = DBNull.Value;
			}
			obj[4] = val5;
			_003F val6;
			if (!files.IsNullOrEmpty())
			{
				val6 = new MySqlParameter("@Files", 253);
				((DbParameter)val6).Value = files;
			}
			else
			{
				val6 = new MySqlParameter("@Files", 253);
				((DbParameter)val6).Value = DBNull.Value;
			}
			obj[5] = val6;
			MySqlParameter val7 = new MySqlParameter("@ID", 253);
			((DbParameter)val7).Value = taskID.ToString();
			obj[6] = val7;
			MySqlParameter[] parameter = (MySqlParameter[])obj;
			return dbHelper.Execute(sql, parameter);
		}

		public int UpdateNextTaskStatus(Guid taskID, int status)
		{
			//IL_0014: Unknown result type (might be due to invalid IL or missing references)
			//IL_0019: Unknown result type (might be due to invalid IL or missing references)
			//IL_0025: Expected O, but got Unknown
			//IL_0026: Expected O, but got Unknown
			//IL_0032: Unknown result type (might be due to invalid IL or missing references)
			//IL_0037: Unknown result type (might be due to invalid IL or missing references)
			//IL_004a: Expected O, but got Unknown
			//IL_004b: Expected O, but got Unknown
			string sql = "UPDATE WorkFlowTask SET Status=@Status WHERE PrevID=@PrevID";
			MySqlParameter[] obj = new MySqlParameter[2];
			MySqlParameter val = new MySqlParameter("@Status", 3);
			((DbParameter)val).Value = status;
			obj[0] = val;
			MySqlParameter val2 = new MySqlParameter("@PrevID", 253);
			((DbParameter)val2).Value = taskID.ToString();
			obj[1] = val2;
			MySqlParameter[] parameter = (MySqlParameter[])obj;
			return dbHelper.Execute(sql, parameter);
		}

		public List<RoadFlow.Data.Model.WorkFlowTask> GetTaskList(Guid flowID, Guid stepID, Guid groupID)
		{
			//IL_0018: Unknown result type (might be due to invalid IL or missing references)
			//IL_001d: Unknown result type (might be due to invalid IL or missing references)
			//IL_0030: Expected O, but got Unknown
			//IL_0031: Expected O, but got Unknown
			//IL_003d: Unknown result type (might be due to invalid IL or missing references)
			//IL_0042: Unknown result type (might be due to invalid IL or missing references)
			//IL_0055: Expected O, but got Unknown
			//IL_0056: Expected O, but got Unknown
			string sql = "SELECT * FROM WorkFlowTask WHERE StepID=@StepID AND GroupID=@GroupID";
			MySqlParameter[] obj = new MySqlParameter[2];
			MySqlParameter val = new MySqlParameter("@StepID", 253);
			((DbParameter)val).Value = stepID.ToString();
			obj[0] = val;
			MySqlParameter val2 = new MySqlParameter("@GroupID", 253);
			((DbParameter)val2).Value = groupID.ToString();
			obj[1] = val2;
			MySqlParameter[] parameter = (MySqlParameter[])obj;
			MySqlDataReader dataReader = dbHelper.GetDataReader(sql, parameter);
			List<RoadFlow.Data.Model.WorkFlowTask> result = DataReaderToList(dataReader);
			((DbDataReader)dataReader).Close();
			return result;
		}

		public List<RoadFlow.Data.Model.WorkFlowTask> GetUserTaskList(Guid flowID, Guid stepID, Guid groupID, Guid userID)
		{
			//IL_0018: Unknown result type (might be due to invalid IL or missing references)
			//IL_001d: Unknown result type (might be due to invalid IL or missing references)
			//IL_0030: Expected O, but got Unknown
			//IL_0031: Expected O, but got Unknown
			//IL_003d: Unknown result type (might be due to invalid IL or missing references)
			//IL_0042: Unknown result type (might be due to invalid IL or missing references)
			//IL_0055: Expected O, but got Unknown
			//IL_0056: Expected O, but got Unknown
			//IL_0062: Unknown result type (might be due to invalid IL or missing references)
			//IL_0067: Unknown result type (might be due to invalid IL or missing references)
			//IL_007a: Expected O, but got Unknown
			//IL_007b: Expected O, but got Unknown
			string sql = "SELECT * FROM WorkFlowTask WHERE StepID=@StepID AND GroupID=@GroupID AND ReceiveID=@ReceiveID";
			MySqlParameter[] obj = new MySqlParameter[3];
			MySqlParameter val = new MySqlParameter("@StepID", 253);
			((DbParameter)val).Value = stepID.ToString();
			obj[0] = val;
			MySqlParameter val2 = new MySqlParameter("@GroupID", 253);
			((DbParameter)val2).Value = groupID.ToString();
			obj[1] = val2;
			MySqlParameter val3 = new MySqlParameter("@ReceiveID", 253);
			((DbParameter)val3).Value = userID.ToString();
			obj[2] = val3;
			MySqlParameter[] parameter = (MySqlParameter[])obj;
			MySqlDataReader dataReader = dbHelper.GetDataReader(sql, parameter);
			List<RoadFlow.Data.Model.WorkFlowTask> result = DataReaderToList(dataReader);
			((DbDataReader)dataReader).Close();
			return result;
		}

		public List<RoadFlow.Data.Model.WorkFlowTask> GetTaskList(Guid flowID, Guid groupID)
		{
			//IL_0026: Unknown result type (might be due to invalid IL or missing references)
			//IL_002b: Unknown result type (might be due to invalid IL or missing references)
			//IL_003e: Expected O, but got Unknown
			//IL_003f: Expected O, but got Unknown
			//IL_005a: Unknown result type (might be due to invalid IL or missing references)
			//IL_005f: Unknown result type (might be due to invalid IL or missing references)
			//IL_0072: Expected O, but got Unknown
			//IL_0073: Expected O, but got Unknown
			//IL_007f: Unknown result type (might be due to invalid IL or missing references)
			//IL_0084: Unknown result type (might be due to invalid IL or missing references)
			//IL_0097: Expected O, but got Unknown
			//IL_0098: Expected O, but got Unknown
			string empty = string.Empty;
			MySqlParameter[] parameter;
			if (flowID.IsEmptyGuid())
			{
				empty = "SELECT * FROM WorkFlowTask WHERE GroupID=@GroupID";
				MySqlParameter[] obj = new MySqlParameter[1];
				MySqlParameter val = new MySqlParameter("@GroupID", 253);
				((DbParameter)val).Value = groupID.ToString();
				obj[0] = val;
				parameter = (MySqlParameter[])obj;
			}
			else
			{
				empty = "SELECT * FROM WorkFlowTask WHERE FlowID=@FlowID AND GroupID=@GroupID";
				MySqlParameter[] obj2 = new MySqlParameter[2];
				MySqlParameter val2 = new MySqlParameter("@FlowID", 253);
				((DbParameter)val2).Value = flowID.ToString();
				obj2[0] = val2;
				MySqlParameter val3 = new MySqlParameter("@GroupID", 253);
				((DbParameter)val3).Value = groupID.ToString();
				obj2[1] = val3;
				parameter = (MySqlParameter[])obj2;
			}
			MySqlDataReader dataReader = dbHelper.GetDataReader(empty, parameter);
			List<RoadFlow.Data.Model.WorkFlowTask> result = DataReaderToList(dataReader);
			((DbDataReader)dataReader).Close();
			return result;
		}

		public List<RoadFlow.Data.Model.WorkFlowTask> GetTaskList(Guid taskID, bool isStepID = true)
		{
			//IL_003d: Unknown result type (might be due to invalid IL or missing references)
			//IL_0042: Unknown result type (might be due to invalid IL or missing references)
			//IL_005d: Expected O, but got Unknown
			//IL_005e: Expected O, but got Unknown
			//IL_006a: Unknown result type (might be due to invalid IL or missing references)
			//IL_006f: Unknown result type (might be due to invalid IL or missing references)
			//IL_008a: Expected O, but got Unknown
			//IL_008b: Expected O, but got Unknown
			//IL_0097: Unknown result type (might be due to invalid IL or missing references)
			//IL_009c: Unknown result type (might be due to invalid IL or missing references)
			//IL_00b7: Expected O, but got Unknown
			//IL_00b8: Expected O, but got Unknown
			//IL_00c4: Unknown result type (might be due to invalid IL or missing references)
			//IL_00c9: Unknown result type (might be due to invalid IL or missing references)
			//IL_00fe: Expected O, but got Unknown
			//IL_00ff: Expected O, but got Unknown
			RoadFlow.Data.Model.WorkFlowTask workFlowTask = Get(taskID);
			if (workFlowTask != null)
			{
				string sql = string.Format("SELECT * FROM WorkFlowTask WHERE FlowID=@FlowID AND GroupID=@GroupID AND PrevID=@PrevID AND {0}", isStepID ? "StepID=@StepID" : "PrevStepID=@StepID");
				MySqlParameter[] obj = new MySqlParameter[4];
				MySqlParameter val = new MySqlParameter("@FlowID", 253);
				((DbParameter)val).Value = workFlowTask.FlowID.ToString();
				obj[0] = val;
				MySqlParameter val2 = new MySqlParameter("@GroupID", 253);
				((DbParameter)val2).Value = workFlowTask.GroupID.ToString();
				obj[1] = val2;
				MySqlParameter val3 = new MySqlParameter("@PrevID", 253);
				((DbParameter)val3).Value = workFlowTask.PrevID.ToString();
				obj[2] = val3;
				MySqlParameter val4 = new MySqlParameter("@StepID", 253);
				((DbParameter)val4).Value = (isStepID ? workFlowTask.StepID.ToString() : workFlowTask.PrevStepID.ToString());
				obj[3] = val4;
				MySqlParameter[] parameter = (MySqlParameter[])obj;
				MySqlDataReader dataReader = dbHelper.GetDataReader(sql, parameter);
				List<RoadFlow.Data.Model.WorkFlowTask> result = DataReaderToList(dataReader);
				((DbDataReader)dataReader).Close();
				return result;
			}
			return new List<RoadFlow.Data.Model.WorkFlowTask>();
		}

		public List<RoadFlow.Data.Model.WorkFlowTask> GetPrevTaskList(Guid taskID)
		{
			//IL_0018: Unknown result type (might be due to invalid IL or missing references)
			//IL_001d: Unknown result type (might be due to invalid IL or missing references)
			//IL_0030: Expected O, but got Unknown
			//IL_0031: Expected O, but got Unknown
			string sql = "SELECT * FROM WorkFlowTask WHERE ID=(SELECT PrevID FROM WorkFlowTask WHERE ID=@ID)";
			MySqlParameter[] obj = new MySqlParameter[1];
			MySqlParameter val = new MySqlParameter("@ID", 253);
			((DbParameter)val).Value = taskID.ToString();
			obj[0] = val;
			MySqlParameter[] parameter = (MySqlParameter[])obj;
			MySqlDataReader dataReader = dbHelper.GetDataReader(sql, parameter);
			List<RoadFlow.Data.Model.WorkFlowTask> result = DataReaderToList(dataReader);
			((DbDataReader)dataReader).Close();
			return result;
		}

		public List<RoadFlow.Data.Model.WorkFlowTask> GetNextTaskList(Guid taskID)
		{
			//IL_0018: Unknown result type (might be due to invalid IL or missing references)
			//IL_001d: Unknown result type (might be due to invalid IL or missing references)
			//IL_0030: Expected O, but got Unknown
			//IL_0031: Expected O, but got Unknown
			string sql = "SELECT * FROM WorkFlowTask WHERE PrevID=@PrevID";
			MySqlParameter[] obj = new MySqlParameter[1];
			MySqlParameter val = new MySqlParameter("@PrevID", 253);
			((DbParameter)val).Value = taskID.ToString();
			obj[0] = val;
			MySqlParameter[] parameter = (MySqlParameter[])obj;
			MySqlDataReader dataReader = dbHelper.GetDataReader(sql, parameter);
			List<RoadFlow.Data.Model.WorkFlowTask> result = DataReaderToList(dataReader);
			((DbDataReader)dataReader).Close();
			return result;
		}

		public bool HasTasks(Guid flowID)
		{
			//IL_0018: Unknown result type (might be due to invalid IL or missing references)
			//IL_001d: Unknown result type (might be due to invalid IL or missing references)
			//IL_0030: Expected O, but got Unknown
			//IL_0031: Expected O, but got Unknown
			string sql = "SELECT ID FROM WorkFlowTask WHERE FlowID=@FlowID LIMIT 0,1";
			MySqlParameter[] obj = new MySqlParameter[1];
			MySqlParameter val = new MySqlParameter("@FlowID", 253);
			((DbParameter)val).Value = flowID.ToString();
			obj[0] = val;
			MySqlParameter[] parameter = (MySqlParameter[])obj;
			MySqlDataReader dataReader = dbHelper.GetDataReader(sql, parameter);
			bool hasRows = ((DbDataReader)dataReader).HasRows;
			((DbDataReader)dataReader).Close();
			return hasRows;
		}

		public bool HasNoCompletedTasks(Guid flowID, Guid stepID, Guid groupID, Guid userID)
		{
			//IL_0018: Unknown result type (might be due to invalid IL or missing references)
			//IL_001d: Unknown result type (might be due to invalid IL or missing references)
			//IL_0030: Expected O, but got Unknown
			//IL_0031: Expected O, but got Unknown
			//IL_003d: Unknown result type (might be due to invalid IL or missing references)
			//IL_0042: Unknown result type (might be due to invalid IL or missing references)
			//IL_0055: Expected O, but got Unknown
			//IL_0056: Expected O, but got Unknown
			//IL_0062: Unknown result type (might be due to invalid IL or missing references)
			//IL_0067: Unknown result type (might be due to invalid IL or missing references)
			//IL_007a: Expected O, but got Unknown
			//IL_007b: Expected O, but got Unknown
			//IL_0087: Unknown result type (might be due to invalid IL or missing references)
			//IL_008c: Unknown result type (might be due to invalid IL or missing references)
			//IL_009f: Expected O, but got Unknown
			//IL_00a0: Expected O, but got Unknown
			string sql = "SELECT ID FROM WorkFlowTask WHERE FlowID=@FlowID AND StepID=@StepID AND GroupID=@GroupID AND ReceiveID=@ReceiveID AND Status IN(-1,0,1) LIMIT 0,1";
			MySqlParameter[] obj = new MySqlParameter[4];
			MySqlParameter val = new MySqlParameter("@FlowID", 253);
			((DbParameter)val).Value = flowID.ToString();
			obj[0] = val;
			MySqlParameter val2 = new MySqlParameter("@StepID", 253);
			((DbParameter)val2).Value = stepID.ToString();
			obj[1] = val2;
			MySqlParameter val3 = new MySqlParameter("@GroupID", 253);
			((DbParameter)val3).Value = groupID.ToString();
			obj[2] = val3;
			MySqlParameter val4 = new MySqlParameter("@ReceiveID", 253);
			((DbParameter)val4).Value = userID.ToString();
			obj[3] = val4;
			MySqlParameter[] parameter = (MySqlParameter[])obj;
			MySqlDataReader dataReader = dbHelper.GetDataReader(sql, parameter);
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
			//IL_0093: Unknown result type (might be due to invalid IL or missing references)
			//IL_0098: Unknown result type (might be due to invalid IL or missing references)
			//IL_00ab: Expected O, but got Unknown
			//IL_00ac: Expected O, but got Unknown
			//IL_00b8: Unknown result type (might be due to invalid IL or missing references)
			//IL_00bd: Unknown result type (might be due to invalid IL or missing references)
			//IL_00d0: Expected O, but got Unknown
			//IL_00d1: Expected O, but got Unknown
			//IL_00dd: Unknown result type (might be due to invalid IL or missing references)
			//IL_00e2: Unknown result type (might be due to invalid IL or missing references)
			//IL_00f5: Expected O, but got Unknown
			//IL_00f6: Expected O, but got Unknown
			string sql = "UPDATE WorkFlowTask SET CompletedTime=@CompletedTime,ReceiveTime=@ReceiveTime,SenderTime=@SenderTime,Status=0 WHERE FlowID=@FlowID AND StepID=@StepID AND GroupID=@GroupID AND Status=-1";
			MySqlParameter[] obj = new MySqlParameter[6];
			_003F val;
			if (completedTime.HasValue)
			{
				val = new MySqlParameter("@CompletedTime", 12);
				((DbParameter)val).Value = completedTime.Value;
			}
			else
			{
				val = new MySqlParameter("@CompletedTime", 12);
				((DbParameter)val).Value = DBNull.Value;
			}
			obj[0] = val;
			MySqlParameter val2 = new MySqlParameter("@ReceiveTime", 12);
			((DbParameter)val2).Value = receiveTime;
			obj[1] = val2;
			MySqlParameter val3 = new MySqlParameter("@SenderTime", 12);
			((DbParameter)val3).Value = receiveTime;
			obj[2] = val3;
			MySqlParameter val4 = new MySqlParameter("@FlowID", 253);
			((DbParameter)val4).Value = flowID.ToString();
			obj[3] = val4;
			MySqlParameter val5 = new MySqlParameter("@StepID", 253);
			((DbParameter)val5).Value = stepID.ToString();
			obj[4] = val5;
			MySqlParameter val6 = new MySqlParameter("@GroupID", 253);
			((DbParameter)val6).Value = groupID.ToString();
			obj[5] = val6;
			MySqlParameter[] parameter = (MySqlParameter[])obj;
			return dbHelper.Execute(sql, parameter);
		}

		public int DeleteTempTasks(Guid flowID, Guid stepID, Guid groupID, Guid prevStepID)
		{
			//IL_0016: Unknown result type (might be due to invalid IL or missing references)
			//IL_001b: Unknown result type (might be due to invalid IL or missing references)
			//IL_002e: Expected O, but got Unknown
			//IL_0033: Expected O, but got Unknown
			//IL_003e: Unknown result type (might be due to invalid IL or missing references)
			//IL_0043: Unknown result type (might be due to invalid IL or missing references)
			//IL_0056: Expected O, but got Unknown
			//IL_005b: Expected O, but got Unknown
			//IL_0066: Unknown result type (might be due to invalid IL or missing references)
			//IL_006b: Unknown result type (might be due to invalid IL or missing references)
			//IL_007e: Expected O, but got Unknown
			//IL_0083: Expected O, but got Unknown
			//IL_00a4: Unknown result type (might be due to invalid IL or missing references)
			//IL_00a9: Unknown result type (might be due to invalid IL or missing references)
			//IL_00bc: Expected O, but got Unknown
			//IL_00c1: Expected O, but got Unknown
			string text = "DELETE WorkFlowTask WHERE FlowID=@FlowID AND StepID=@StepID AND GroupID=@GroupID AND Status=-1";
			List<MySqlParameter> list = new List<MySqlParameter>();
			MySqlParameter val = new MySqlParameter("@FlowID", 253);
			((DbParameter)val).Value = flowID.ToString();
			list.Add(val);
			MySqlParameter val2 = new MySqlParameter("@StepID", 253);
			((DbParameter)val2).Value = stepID.ToString();
			list.Add(val2);
			MySqlParameter val3 = new MySqlParameter("@GroupID", 253);
			((DbParameter)val3).Value = groupID.ToString();
			list.Add(val3);
			List<MySqlParameter> list2 = list;
			if (!prevStepID.IsEmptyGuid())
			{
				text += " AND PrevStepID=@PrevStepID";
				List<MySqlParameter> list3 = list2;
				MySqlParameter val4 = new MySqlParameter("@PrevStepID", 253);
				((DbParameter)val4).Value = prevStepID.ToString();
				list3.Add(val4);
			}
			return dbHelper.Execute(text, list2.ToArray());
		}

		public int GetTaskStatus(Guid taskID)
		{
			//IL_0018: Unknown result type (might be due to invalid IL or missing references)
			//IL_001d: Unknown result type (might be due to invalid IL or missing references)
			//IL_0030: Expected O, but got Unknown
			//IL_0031: Expected O, but got Unknown
			string sql = "SELECT Status FROM WorkFlowTask WHERE ID=@ID";
			MySqlParameter[] obj = new MySqlParameter[1];
			MySqlParameter val = new MySqlParameter("@ID", 253);
			((DbParameter)val).Value = taskID.ToString();
			obj[0] = val;
			MySqlParameter[] parameter = (MySqlParameter[])obj;
			int test;
			if (!dbHelper.GetFieldValue(sql, parameter).IsInt(out test))
			{
				return -1;
			}
			return test;
		}

		public List<RoadFlow.Data.Model.WorkFlowTask> GetBySubFlowGroupID(Guid subflowGroupID)
		{
			//IL_0018: Unknown result type (might be due to invalid IL or missing references)
			//IL_001d: Unknown result type (might be due to invalid IL or missing references)
			//IL_0030: Expected O, but got Unknown
			//IL_0031: Expected O, but got Unknown
			string sql = "SELECT * FROM WorkFlowTask WHERE INSTR(SubFlowGroupID,@SubFlowGroupID)>0";
			MySqlParameter[] obj = new MySqlParameter[1];
			MySqlParameter val = new MySqlParameter("@SubFlowGroupID", 253);
			((DbParameter)val).Value = subflowGroupID.ToString();
			obj[0] = val;
			MySqlParameter[] parameter = (MySqlParameter[])obj;
			MySqlDataReader dataReader = dbHelper.GetDataReader(sql, parameter);
			List<RoadFlow.Data.Model.WorkFlowTask> result = DataReaderToList(dataReader);
			((DbDataReader)dataReader).Close();
			return result;
		}

		public RoadFlow.Data.Model.WorkFlowTask GetLastTask(Guid flowID, Guid groupID)
		{
			//IL_0018: Unknown result type (might be due to invalid IL or missing references)
			//IL_001d: Unknown result type (might be due to invalid IL or missing references)
			//IL_0030: Expected O, but got Unknown
			//IL_0031: Expected O, but got Unknown
			//IL_003d: Unknown result type (might be due to invalid IL or missing references)
			//IL_0042: Unknown result type (might be due to invalid IL or missing references)
			//IL_0055: Expected O, but got Unknown
			//IL_0056: Expected O, but got Unknown
			string sql = "SELECT * FROM WorkFlowTask WHERE FlowID=@FlowID AND GroupID=@GroupID ORDER BY Sort DESC LIMIT 0,1";
			MySqlParameter[] obj = new MySqlParameter[2];
			MySqlParameter val = new MySqlParameter("@FlowID", 253);
			((DbParameter)val).Value = flowID.ToString();
			obj[0] = val;
			MySqlParameter val2 = new MySqlParameter("@GroupID", 253);
			((DbParameter)val2).Value = groupID.ToString();
			obj[1] = val2;
			MySqlParameter[] parameter = (MySqlParameter[])obj;
			MySqlDataReader dataReader = dbHelper.GetDataReader(sql, parameter);
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
			MySqlDataReader dataReader = dbHelper.GetDataReader(sql);
			List<RoadFlow.Data.Model.WorkFlowTask> result = DataReaderToList(dataReader);
			((DbDataReader)dataReader).Close();
			return result;
		}
	}
}
