// Decompiled with JetBrains decompiler
// Type: RoadFlow.Data.ORACLE.ProgramBuilder
// Assembly: RoadFlow.Data.ORACLE, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: C9018AA1-E48E-4231-92A9-CD6F0F275D11
// Assembly location: C:\inetpub\wwwroot\RoadFlowMvc\bin\RoadFlow.Data.ORACLE.dll

using Oracle.ManagedDataAccess.Client;
using RoadFlow.Data.Interface;
using RoadFlow.Utility;
using System;
using System.Collections.Generic;
using System.Text;

namespace RoadFlow.Data.ORACLE
{
    public class ProgramBuilder : IProgramBuilder
    {
        private DBHelper dbHelper = new DBHelper();

        public int Add(RoadFlow.Data.Model.ProgramBuilder model)
        {
            string sql = "INSERT INTO ProgramBuilder\r\n\t\t\t\t(ID,Name,Type,CreateTime,PublishTime,CreateUser,SQL,IsAdd,DBConnID,Status,FormID,EditModel,Width,Height,ButtonLocation,IsPager,ClientScript,ExportTemplate,ExportHeaderText,ExportFileName,TableStyle,TableHead,TableName,InDataNumberFiledName) \r\n\t\t\t\tVALUES(:ID,:Name,:Type,:CreateTime,:PublishTime,:CreateUser,:SQL,:IsAdd,:DBConnID,:Status,:FormID,:EditModel,:Width,:Height,:ButtonLocation,:IsPager,:ClientScript,:ExportTemplate,:ExportHeaderText,:ExportFileName,:TableStyle,:TableHead,:TableName,:InDataNumberFiledName)";
            OracleParameter[] oracleParameterArray = new OracleParameter[24];
            int index1 = 0;
            OracleParameter oracleParameter1 = new OracleParameter(":ID", OracleDbType.Varchar2);
            oracleParameter1.Value = (object)model.ID;
            oracleParameterArray[index1] = oracleParameter1;
            int index2 = 1;
            OracleParameter oracleParameter2 = new OracleParameter(":Name", OracleDbType.Varchar2);
            oracleParameter2.Value = (object)model.Name;
            oracleParameterArray[index2] = oracleParameter2;
            int index3 = 2;
            OracleParameter oracleParameter3 = new OracleParameter(":Type", OracleDbType.Varchar2);
            oracleParameter3.Value = (object)model.Type;
            oracleParameterArray[index3] = oracleParameter3;
            int index4 = 3;
            OracleParameter oracleParameter4 = new OracleParameter(":CreateTime", OracleDbType.Date);
            oracleParameter4.Value = (object)model.CreateTime;
            oracleParameterArray[index4] = oracleParameter4;
            int index5 = 4;
            OracleParameter oracleParameter5;
            if (model.PublishTime.HasValue)
            {
                OracleParameter oracleParameter6 = new OracleParameter(":PublishTime", OracleDbType.Date);
                oracleParameter6.Value = (object)model.PublishTime;
                oracleParameter5 = oracleParameter6;
            }
            else
            {
                oracleParameter5 = new OracleParameter(":PublishTime", OracleDbType.Date);
                oracleParameter5.Value = (object)DBNull.Value;
            }
            oracleParameterArray[index5] = oracleParameter5;
            int index6 = 5;
            OracleParameter oracleParameter7 = new OracleParameter(":CreateUser", OracleDbType.Varchar2);
            oracleParameter7.Value = (object)model.CreateUser;
            oracleParameterArray[index6] = oracleParameter7;
            int index7 = 6;
            OracleParameter oracleParameter8 = new OracleParameter(":SQL", OracleDbType.Varchar2);
            oracleParameter8.Value = (object)model.SQL;
            oracleParameterArray[index7] = oracleParameter8;
            int index8 = 7;
            OracleParameter oracleParameter9 = new OracleParameter(":IsAdd", OracleDbType.Int32);
            oracleParameter9.Value = (object)model.IsAdd;
            oracleParameterArray[index8] = oracleParameter9;
            int index9 = 8;
            OracleParameter oracleParameter10 = new OracleParameter(":DBConnID", OracleDbType.Varchar2);
            oracleParameter10.Value = (object)model.DBConnID;
            oracleParameterArray[index9] = oracleParameter10;
            int index10 = 9;
            OracleParameter oracleParameter11 = new OracleParameter(":Status", OracleDbType.Int32);
            oracleParameter11.Value = (object)model.Status;
            oracleParameterArray[index10] = oracleParameter11;
            int index11 = 10;
            OracleParameter oracleParameter12;
            if (model.FormID != null)
            {
                OracleParameter oracleParameter6 = new OracleParameter(":FormID", OracleDbType.Varchar2);
                oracleParameter6.Value = (object)model.FormID;
                oracleParameter12 = oracleParameter6;
            }
            else
            {
                oracleParameter12 = new OracleParameter(":FormID", OracleDbType.Varchar2);
                oracleParameter12.Value = (object)DBNull.Value;
            }
            oracleParameterArray[index11] = oracleParameter12;
            int index12 = 11;
            int? nullable = model.EditModel;
            OracleParameter oracleParameter13;
            if (nullable.HasValue)
            {
                OracleParameter oracleParameter6 = new OracleParameter(":EditModel", OracleDbType.Int32);
                oracleParameter6.Value = (object)model.EditModel;
                oracleParameter13 = oracleParameter6;
            }
            else
            {
                oracleParameter13 = new OracleParameter(":EditModel", OracleDbType.Int32);
                oracleParameter13.Value = (object)DBNull.Value;
            }
            oracleParameterArray[index12] = oracleParameter13;
            int index13 = 12;
            OracleParameter oracleParameter14;
            if (model.Width != null)
            {
                OracleParameter oracleParameter6 = new OracleParameter(":Width", OracleDbType.Varchar2);
                oracleParameter6.Value = (object)model.Width;
                oracleParameter14 = oracleParameter6;
            }
            else
            {
                oracleParameter14 = new OracleParameter(":Width", OracleDbType.Varchar2);
                oracleParameter14.Value = (object)DBNull.Value;
            }
            oracleParameterArray[index13] = oracleParameter14;
            int index14 = 13;
            OracleParameter oracleParameter15;
            if (model.Height != null)
            {
                OracleParameter oracleParameter6 = new OracleParameter(":Height", OracleDbType.Varchar2);
                oracleParameter6.Value = (object)model.Height;
                oracleParameter15 = oracleParameter6;
            }
            else
            {
                oracleParameter15 = new OracleParameter(":Height", OracleDbType.Varchar2);
                oracleParameter15.Value = (object)DBNull.Value;
            }
            oracleParameterArray[index14] = oracleParameter15;
            int index15 = 14;
            nullable = model.ButtonLocation;
            OracleParameter oracleParameter16;
            if (nullable.HasValue)
            {
                OracleParameter oracleParameter6 = new OracleParameter(":ButtonLocation", OracleDbType.Int32);
                oracleParameter6.Value = (object)model.ButtonLocation;
                oracleParameter16 = oracleParameter6;
            }
            else
            {
                oracleParameter16 = new OracleParameter(":ButtonLocation", OracleDbType.Int32);
                oracleParameter16.Value = (object)DBNull.Value;
            }
            oracleParameterArray[index15] = oracleParameter16;
            int index16 = 15;
            nullable = model.IsPager;
            OracleParameter oracleParameter17;
            if (nullable.HasValue)
            {
                OracleParameter oracleParameter6 = new OracleParameter(":IsPager", OracleDbType.Int32);
                oracleParameter6.Value = (object)model.IsPager;
                oracleParameter17 = oracleParameter6;
            }
            else
            {
                oracleParameter17 = new OracleParameter(":IsPager", OracleDbType.Int32);
                oracleParameter17.Value = (object)DBNull.Value;
            }
            oracleParameterArray[index16] = oracleParameter17;
            int index17 = 16;
            OracleParameter oracleParameter18;
            if (model.ClientScript != null)
            {
                OracleParameter oracleParameter6 = new OracleParameter(":ClientScript", OracleDbType.Varchar2);
                oracleParameter6.Value = (object)model.ClientScript;
                oracleParameter18 = oracleParameter6;
            }
            else
            {
                oracleParameter18 = new OracleParameter(":ClientScript", OracleDbType.Varchar2);
                oracleParameter18.Value = (object)DBNull.Value;
            }
            oracleParameterArray[index17] = oracleParameter18;
            int index18 = 17;
            OracleParameter oracleParameter19;
            if (model.ExportTemplate != null)
            {
                OracleParameter oracleParameter6 = new OracleParameter(":ExportTemplate", OracleDbType.Varchar2, 4000);
                oracleParameter6.Value = (object)model.ExportTemplate;
                oracleParameter19 = oracleParameter6;
            }
            else
            {
                oracleParameter19 = new OracleParameter(":ExportTemplate", OracleDbType.Varchar2, 4000);
                oracleParameter19.Value = (object)DBNull.Value;
            }
            oracleParameterArray[index18] = oracleParameter19;
            int index19 = 18;
            OracleParameter oracleParameter20;
            if (model.ExportHeaderText != null)
            {
                OracleParameter oracleParameter6 = new OracleParameter(":ExportHeaderText", OracleDbType.NVarchar2, 500);
                oracleParameter6.Value = (object)model.ExportHeaderText;
                oracleParameter20 = oracleParameter6;
            }
            else
            {
                oracleParameter20 = new OracleParameter(":ExportHeaderText", OracleDbType.NVarchar2, 500);
                oracleParameter20.Value = (object)DBNull.Value;
            }
            oracleParameterArray[index19] = oracleParameter20;
            int index20 = 19;
            OracleParameter oracleParameter21;
            if (model.ExportFileName != null)
            {
                OracleParameter oracleParameter6 = new OracleParameter(":ExportFileName", OracleDbType.Varchar2, 500);
                oracleParameter6.Value = (object)model.ExportFileName;
                oracleParameter21 = oracleParameter6;
            }
            else
            {
                oracleParameter21 = new OracleParameter(":ExportFileName", OracleDbType.Varchar2, 500);
                oracleParameter21.Value = (object)DBNull.Value;
            }
            oracleParameterArray[index20] = oracleParameter21;
            int index21 = 20;
            OracleParameter oracleParameter22;
            if (model.TableStyle != null)
            {
                OracleParameter oracleParameter6 = new OracleParameter(":TableStyle", OracleDbType.Varchar2, (int)byte.MaxValue);
                oracleParameter6.Value = (object)model.TableStyle;
                oracleParameter22 = oracleParameter6;
            }
            else
            {
                oracleParameter22 = new OracleParameter(":TableStyle", OracleDbType.Varchar2, (int)byte.MaxValue);
                oracleParameter22.Value = (object)DBNull.Value;
            }
            oracleParameterArray[index21] = oracleParameter22;
            int index22 = 21;
            OracleParameter oracleParameter23;
            if (model.TableHead != null)
            {
                OracleParameter oracleParameter6 = new OracleParameter(":TableHead", OracleDbType.Varchar2, 4000);
                oracleParameter6.Value = (object)model.TableHead;
                oracleParameter23 = oracleParameter6;
            }
            else
            {
                oracleParameter23 = new OracleParameter(":TableHead", OracleDbType.Varchar2, 4000);
                oracleParameter23.Value = (object)DBNull.Value;
            }
            oracleParameterArray[index22] = oracleParameter23;
            int index23 = 22;
            OracleParameter oracleParameter24;
            if (model.TableName != null)
            {
                OracleParameter oracleParameter6 = new OracleParameter(":TableName", OracleDbType.Varchar2, 500);
                oracleParameter6.Value = (object)model.TableName;
                oracleParameter24 = oracleParameter6;
            }
            else
            {
                oracleParameter24 = new OracleParameter(":TableName", OracleDbType.Varchar2, 500);
                oracleParameter24.Value = (object)DBNull.Value;
            }
            oracleParameterArray[index23] = oracleParameter24;
            int index24 = 23;
            OracleParameter oracleParameter25;
            if (model.InDataNumberFiledName != null)
            {
                OracleParameter oracleParameter6 = new OracleParameter(":InDataNumberFiledName", OracleDbType.Varchar2, 500);
                oracleParameter6.Value = (object)model.InDataNumberFiledName;
                oracleParameter25 = oracleParameter6;
            }
            else
            {
                oracleParameter25 = new OracleParameter(":InDataNumberFiledName", OracleDbType.Varchar2, 500);
                oracleParameter25.Value = (object)DBNull.Value;
            }
            oracleParameterArray[index24] = oracleParameter25;
            OracleParameter[] parameter = oracleParameterArray;
            return this.dbHelper.Execute(sql, parameter);
        }

        public int Update(RoadFlow.Data.Model.ProgramBuilder model)
        {
            string sql = "UPDATE ProgramBuilder SET \r\n\t\t\t\tName=:Name,Type=:Type,CreateTime=:CreateTime,PublishTime=:PublishTime,CreateUser=:CreateUser,SQL=:SQL,IsAdd=:IsAdd,DBConnID=:DBConnID,Status=:Status,FormID=:FormID,EditModel=:EditModel,Width=:Width,Height=:Height,ButtonLocation=:ButtonLocation,IsPager=:IsPager,ClientScript=:ClientScript,ExportTemplate=:ExportTemplate,ExportHeaderText=:ExportHeaderText,ExportFileName=:ExportFileName,TableStyle=:TableStyle,TableHead=:TableHead,TableName=:TableName,InDataNumberFiledName=:InDataNumberFiledName   \r\n\t\t\t\tWHERE ID=:ID";
            OracleParameter[] oracleParameterArray = new OracleParameter[24];
            int index1 = 0;
            OracleParameter oracleParameter1 = new OracleParameter(":Name", OracleDbType.Varchar2);
            oracleParameter1.Value = (object)model.Name;
            oracleParameterArray[index1] = oracleParameter1;
            int index2 = 1;
            OracleParameter oracleParameter2 = new OracleParameter(":Type", OracleDbType.Varchar2);
            oracleParameter2.Value = (object)model.Type;
            oracleParameterArray[index2] = oracleParameter2;
            int index3 = 2;
            OracleParameter oracleParameter3 = new OracleParameter(":CreateTime", OracleDbType.Date);
            oracleParameter3.Value = (object)model.CreateTime;
            oracleParameterArray[index3] = oracleParameter3;
            int index4 = 3;
            OracleParameter oracleParameter4;
            if (model.PublishTime.HasValue)
            {
                OracleParameter oracleParameter5 = new OracleParameter(":PublishTime", OracleDbType.Date);
                oracleParameter5.Value = (object)model.PublishTime;
                oracleParameter4 = oracleParameter5;
            }
            else
            {
                oracleParameter4 = new OracleParameter(":PublishTime", OracleDbType.Date);
                oracleParameter4.Value = (object)DBNull.Value;
            }
            oracleParameterArray[index4] = oracleParameter4;
            int index5 = 4;
            OracleParameter oracleParameter6 = new OracleParameter(":CreateUser", OracleDbType.Varchar2);
            oracleParameter6.Value = (object)model.CreateUser;
            oracleParameterArray[index5] = oracleParameter6;
            int index6 = 5;
            OracleParameter oracleParameter7 = new OracleParameter(":SQL", OracleDbType.Varchar2);
            oracleParameter7.Value = (object)model.SQL;
            oracleParameterArray[index6] = oracleParameter7;
            int index7 = 6;
            OracleParameter oracleParameter8 = new OracleParameter(":IsAdd", OracleDbType.Int32);
            oracleParameter8.Value = (object)model.IsAdd;
            oracleParameterArray[index7] = oracleParameter8;
            int index8 = 7;
            OracleParameter oracleParameter9 = new OracleParameter(":DBConnID", OracleDbType.Varchar2);
            oracleParameter9.Value = (object)model.DBConnID;
            oracleParameterArray[index8] = oracleParameter9;
            int index9 = 8;
            OracleParameter oracleParameter10 = new OracleParameter(":Status", OracleDbType.Int32);
            oracleParameter10.Value = (object)model.Status;
            oracleParameterArray[index9] = oracleParameter10;
            int index10 = 9;
            OracleParameter oracleParameter11;
            if (model.FormID != null)
            {
                OracleParameter oracleParameter5 = new OracleParameter(":FormID", OracleDbType.Varchar2);
                oracleParameter5.Value = (object)model.FormID;
                oracleParameter11 = oracleParameter5;
            }
            else
            {
                oracleParameter11 = new OracleParameter(":FormID", OracleDbType.Varchar2);
                oracleParameter11.Value = (object)DBNull.Value;
            }
            oracleParameterArray[index10] = oracleParameter11;
            int index11 = 10;
            int? nullable = model.EditModel;
            OracleParameter oracleParameter12;
            if (nullable.HasValue)
            {
                OracleParameter oracleParameter5 = new OracleParameter(":EditModel", OracleDbType.Int32);
                oracleParameter5.Value = (object)model.EditModel;
                oracleParameter12 = oracleParameter5;
            }
            else
            {
                oracleParameter12 = new OracleParameter(":EditModel", OracleDbType.Int32);
                oracleParameter12.Value = (object)DBNull.Value;
            }
            oracleParameterArray[index11] = oracleParameter12;
            int index12 = 11;
            OracleParameter oracleParameter13;
            if (model.Width != null)
            {
                OracleParameter oracleParameter5 = new OracleParameter(":Width", OracleDbType.Varchar2);
                oracleParameter5.Value = (object)model.Width;
                oracleParameter13 = oracleParameter5;
            }
            else
            {
                oracleParameter13 = new OracleParameter(":Width", OracleDbType.Varchar2);
                oracleParameter13.Value = (object)DBNull.Value;
            }
            oracleParameterArray[index12] = oracleParameter13;
            int index13 = 12;
            OracleParameter oracleParameter14;
            if (model.Height != null)
            {
                OracleParameter oracleParameter5 = new OracleParameter(":Height", OracleDbType.Varchar2);
                oracleParameter5.Value = (object)model.Height;
                oracleParameter14 = oracleParameter5;
            }
            else
            {
                oracleParameter14 = new OracleParameter(":Height", OracleDbType.Varchar2);
                oracleParameter14.Value = (object)DBNull.Value;
            }
            oracleParameterArray[index13] = oracleParameter14;
            int index14 = 13;
            nullable = model.ButtonLocation;
            OracleParameter oracleParameter15;
            if (nullable.HasValue)
            {
                OracleParameter oracleParameter5 = new OracleParameter(":ButtonLocation", OracleDbType.Int32);
                oracleParameter5.Value = (object)model.ButtonLocation;
                oracleParameter15 = oracleParameter5;
            }
            else
            {
                oracleParameter15 = new OracleParameter(":ButtonLocation", OracleDbType.Int32);
                oracleParameter15.Value = (object)DBNull.Value;
            }
            oracleParameterArray[index14] = oracleParameter15;
            int index15 = 14;
            nullable = model.IsPager;
            OracleParameter oracleParameter16;
            if (nullable.HasValue)
            {
                OracleParameter oracleParameter5 = new OracleParameter(":IsPager", OracleDbType.Int32);
                oracleParameter5.Value = (object)model.IsPager;
                oracleParameter16 = oracleParameter5;
            }
            else
            {
                oracleParameter16 = new OracleParameter(":IsPager", OracleDbType.Int32);
                oracleParameter16.Value = (object)DBNull.Value;
            }
            oracleParameterArray[index15] = oracleParameter16;
            int index16 = 15;
            OracleParameter oracleParameter17;
            if (model.ClientScript != null)
            {
                OracleParameter oracleParameter5 = new OracleParameter(":ClientScript", OracleDbType.Varchar2);
                oracleParameter5.Value = (object)model.ClientScript;
                oracleParameter17 = oracleParameter5;
            }
            else
            {
                oracleParameter17 = new OracleParameter(":ClientScript", OracleDbType.Varchar2);
                oracleParameter17.Value = (object)DBNull.Value;
            }
            oracleParameterArray[index16] = oracleParameter17;
            int index17 = 16;
            OracleParameter oracleParameter18;
            if (model.ExportTemplate != null)
            {
                OracleParameter oracleParameter5 = new OracleParameter(":ExportTemplate", OracleDbType.Varchar2, 4000);
                oracleParameter5.Value = (object)model.ExportTemplate;
                oracleParameter18 = oracleParameter5;
            }
            else
            {
                oracleParameter18 = new OracleParameter(":ExportTemplate", OracleDbType.Varchar2, 4000);
                oracleParameter18.Value = (object)DBNull.Value;
            }
            oracleParameterArray[index17] = oracleParameter18;
            int index18 = 17;
            OracleParameter oracleParameter19;
            if (model.ExportHeaderText != null)
            {
                OracleParameter oracleParameter5 = new OracleParameter(":ExportHeaderText", OracleDbType.NVarchar2, 500);
                oracleParameter5.Value = (object)model.ExportHeaderText;
                oracleParameter19 = oracleParameter5;
            }
            else
            {
                oracleParameter19 = new OracleParameter(":ExportHeaderText", OracleDbType.NVarchar2, 500);
                oracleParameter19.Value = (object)DBNull.Value;
            }
            oracleParameterArray[index18] = oracleParameter19;
            int index19 = 18;
            OracleParameter oracleParameter20;
            if (model.ExportFileName != null)
            {
                OracleParameter oracleParameter5 = new OracleParameter(":ExportFileName", OracleDbType.Varchar2, 500);
                oracleParameter5.Value = (object)model.ExportFileName;
                oracleParameter20 = oracleParameter5;
            }
            else
            {
                oracleParameter20 = new OracleParameter(":ExportFileName", OracleDbType.Varchar2, 500);
                oracleParameter20.Value = (object)DBNull.Value;
            }
            oracleParameterArray[index19] = oracleParameter20;
            int index20 = 19;
            OracleParameter oracleParameter21;
            if (model.TableStyle != null)
            {
                OracleParameter oracleParameter5 = new OracleParameter(":TableStyle", OracleDbType.Varchar2, (int)byte.MaxValue);
                oracleParameter5.Value = (object)model.TableStyle;
                oracleParameter21 = oracleParameter5;
            }
            else
            {
                oracleParameter21 = new OracleParameter(":TableStyle", OracleDbType.Varchar2, (int)byte.MaxValue);
                oracleParameter21.Value = (object)DBNull.Value;
            }
            oracleParameterArray[index20] = oracleParameter21;
            int index21 = 20;
            OracleParameter oracleParameter22;
            if (model.TableHead != null)
            {
                OracleParameter oracleParameter5 = new OracleParameter(":TableHead", OracleDbType.Varchar2, 4000);
                oracleParameter5.Value = (object)model.TableHead;
                oracleParameter22 = oracleParameter5;
            }
            else
            {
                oracleParameter22 = new OracleParameter(":TableHead", OracleDbType.Varchar2, 4000);
                oracleParameter22.Value = (object)DBNull.Value;
            }
            oracleParameterArray[index21] = oracleParameter22;
            int index22 = 21;
            OracleParameter oracleParameter23;
            if (model.TableName != null)
            {
                OracleParameter oracleParameter5 = new OracleParameter(":TableName", OracleDbType.Varchar2, 500);
                oracleParameter5.Value = (object)model.TableName;
                oracleParameter23 = oracleParameter5;
            }
            else
            {
                oracleParameter23 = new OracleParameter(":TableName", OracleDbType.Varchar2, 500);
                oracleParameter23.Value = (object)DBNull.Value;
            }
            oracleParameterArray[index22] = oracleParameter23;
            int index23 = 22;
            OracleParameter oracleParameter24;
            if (model.InDataNumberFiledName != null)
            {
                OracleParameter oracleParameter5 = new OracleParameter(":InDataNumberFiledName", OracleDbType.Varchar2, 500);
                oracleParameter5.Value = (object)model.InDataNumberFiledName;
                oracleParameter24 = oracleParameter5;
            }
            else
            {
                oracleParameter24 = new OracleParameter(":InDataNumberFiledName", OracleDbType.Varchar2, 500);
                oracleParameter24.Value = (object)DBNull.Value;
            }
            oracleParameterArray[index23] = oracleParameter24;
            int index24 = 23;
            OracleParameter oracleParameter25 = new OracleParameter(":ID", OracleDbType.Varchar2);
            oracleParameter25.Value = (object)model.ID;
            oracleParameterArray[index24] = oracleParameter25;
            OracleParameter[] parameter = oracleParameterArray;
            return this.dbHelper.Execute(sql, parameter);
        }

        public int Delete(Guid id)
        {
            string sql = "DELETE FROM ProgramBuilder WHERE ID=:ID";
            OracleParameter[] oracleParameterArray = new OracleParameter[1];
            int index = 0;
            OracleParameter oracleParameter = new OracleParameter(":ID", OracleDbType.Varchar2);
            oracleParameter.Value = (object)id;
            oracleParameterArray[index] = oracleParameter;
            OracleParameter[] parameter = oracleParameterArray;
            return this.dbHelper.Execute(sql, parameter);
        }

        private List<RoadFlow.Data.Model.ProgramBuilder> DataReaderToList(OracleDataReader dataReader)
        {
            List<RoadFlow.Data.Model.ProgramBuilder> programBuilderList = new List<RoadFlow.Data.Model.ProgramBuilder>();
            while (dataReader.Read())
            {
                RoadFlow.Data.Model.ProgramBuilder programBuilder = new RoadFlow.Data.Model.ProgramBuilder();
                programBuilder.ID = dataReader.GetString(0).ToGuid();
                programBuilder.Name = dataReader.GetString(1);
                programBuilder.Type = dataReader.GetString(2).ToGuid();
                programBuilder.CreateTime = dataReader.GetDateTime(3);
                if (!dataReader.IsDBNull(4))
                    programBuilder.PublishTime = new DateTime?(dataReader.GetDateTime(4));
                programBuilder.CreateUser = dataReader.GetString(5).ToGuid();
                programBuilder.SQL = dataReader.GetString(6);
                programBuilder.IsAdd = dataReader.GetInt32(7);
                programBuilder.DBConnID = dataReader.GetString(8).ToGuid();
                programBuilder.Status = dataReader.GetInt32(9);
                if (!dataReader.IsDBNull(10))
                    programBuilder.FormID = dataReader.GetString(10);
                if (!dataReader.IsDBNull(11))
                    programBuilder.EditModel = new int?(dataReader.GetInt32(11));
                if (!dataReader.IsDBNull(12))
                    programBuilder.Width = dataReader.GetString(12);
                if (!dataReader.IsDBNull(13))
                    programBuilder.Height = dataReader.GetString(13);
                if (!dataReader.IsDBNull(14))
                    programBuilder.ButtonLocation = new int?(dataReader.GetInt32(14));
                if (!dataReader.IsDBNull(15))
                    programBuilder.IsPager = new int?(dataReader.GetInt32(15));
                if (!dataReader.IsDBNull(16))
                    programBuilder.ClientScript = dataReader.GetString(16);
                if (!dataReader.IsDBNull(17))
                    programBuilder.ExportTemplate = dataReader.GetString(17);
                if (!dataReader.IsDBNull(18))
                    programBuilder.ExportHeaderText = dataReader.GetString(18);
                if (!dataReader.IsDBNull(19))
                    programBuilder.ExportFileName = dataReader.GetString(19);
                if (!dataReader.IsDBNull(20))
                    programBuilder.TableStyle = dataReader.GetString(20);
                if (!dataReader.IsDBNull(21))
                    programBuilder.TableHead = dataReader.GetString(21);
                if (!dataReader.IsDBNull(22))
                    programBuilder.TableName = dataReader.GetString(22);
                if (!dataReader.IsDBNull(23))
                    programBuilder.InDataNumberFiledName = dataReader.GetString(23);
                programBuilderList.Add(programBuilder);
            }
            return programBuilderList;
        }

        public List<RoadFlow.Data.Model.ProgramBuilder> GetAll()
        {
            OracleDataReader dataReader = this.dbHelper.GetDataReader("SELECT * FROM ProgramBuilder");
            List<RoadFlow.Data.Model.ProgramBuilder> list = this.DataReaderToList(dataReader);
            dataReader.Close();
            return list;
        }

        public long GetCount()
        {
            long result;
            if (!long.TryParse(this.dbHelper.GetFieldValue("SELECT COUNT(*) FROM ProgramBuilder"), out result))
                return 0;
            return result;
        }

        public RoadFlow.Data.Model.ProgramBuilder Get(Guid id)
        {
            string sql = "SELECT * FROM ProgramBuilder WHERE ID=:ID";
            OracleParameter[] oracleParameterArray = new OracleParameter[1];
            int index = 0;
            OracleParameter oracleParameter = new OracleParameter(":ID", OracleDbType.Varchar2);
            oracleParameter.Value = (object)id;
            oracleParameterArray[index] = oracleParameter;
            OracleParameter[] parameter = oracleParameterArray;
            OracleDataReader dataReader = this.dbHelper.GetDataReader(sql, parameter);
            List<RoadFlow.Data.Model.ProgramBuilder> list = this.DataReaderToList(dataReader);
            dataReader.Close();
            if (list.Count <= 0)
                return (RoadFlow.Data.Model.ProgramBuilder)null;
            return list[0];
        }

        public List<RoadFlow.Data.Model.ProgramBuilder> GetList(out string pager, string query = "", string name = "", string typeid = "")
        {
            List<OracleParameter> oracleParameterList = new List<OracleParameter>();
            StringBuilder stringBuilder = new StringBuilder("SELECT PagerTempTable.*,ROWNUM AS PagerAutoRowNumber FROM (SELECT * FROM ProgramBuilder WHERE Status<>2 ");
            if (!name.IsNullOrEmpty())
            {
                stringBuilder.Append(" AND INSTR(Name,:Name,1,1)>0");
                oracleParameterList.Add(new OracleParameter(":Name", (object)name));
            }
            if (!typeid.IsNullOrEmpty())
                stringBuilder.Append(" AND Type IN(" + Tools.GetSqlInString(typeid, true, ",") + ")");
            stringBuilder.Append(" ORDER BY CreateTime DESC) PagerTempTable");
            int pageSize = Tools.GetPageSize();
            int pageNumber = Tools.GetPageNumber();
            long count;
            string paerSql = this.dbHelper.GetPaerSql(stringBuilder.ToString(), pageSize, pageNumber, out count, oracleParameterList.ToArray());
            pager = Tools.GetPagerHtml(count, pageSize, pageNumber, query);
            OracleDataReader dataReader = this.dbHelper.GetDataReader(paerSql, oracleParameterList.ToArray());
            List<RoadFlow.Data.Model.ProgramBuilder> list = this.DataReaderToList(dataReader);
            dataReader.Close();
            return list;
        }
    }
}