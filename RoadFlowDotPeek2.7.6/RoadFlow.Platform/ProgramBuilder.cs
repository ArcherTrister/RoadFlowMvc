// Decompiled with JetBrains decompiler
// Type: RoadFlow.Platform.ProgramBuilder
// Assembly: RoadFlow.Platform, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 07F26AFD-DE3B-4003-89AF-01A62494BA58
// Assembly location: C:\inetpub\wwwroot\RoadFlowMvc\bin\RoadFlow.Platform.dll

using RoadFlow.Cache.IO;
using RoadFlow.Data.Interface;
using RoadFlow.Data.Model;
using RoadFlow.Utility;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Transactions;
using System.Web;

namespace RoadFlow.Platform
{
  public class ProgramBuilder
  {
    public static string exportCackeKey = "ExportToExcel_";
    private IProgramBuilder dataProgramBuilder;

    public ProgramBuilder()
    {
      this.dataProgramBuilder = RoadFlow.Data.Factory.Factory.GetProgramBuilder();
    }

    public int Add(RoadFlow.Data.Model.ProgramBuilder model)
    {
      return this.dataProgramBuilder.Add(model);
    }

    public int Update(RoadFlow.Data.Model.ProgramBuilder model)
    {
      return this.dataProgramBuilder.Update(model);
    }

    public List<RoadFlow.Data.Model.ProgramBuilder> GetAll()
    {
      return this.dataProgramBuilder.GetAll();
    }

    public RoadFlow.Data.Model.ProgramBuilder Get(Guid id)
    {
      return this.dataProgramBuilder.Get(id);
    }

    public int Delete(Guid id)
    {
      return this.dataProgramBuilder.Delete(id);
    }

    public long GetCount()
    {
      return this.dataProgramBuilder.GetCount();
    }

    public List<RoadFlow.Data.Model.ProgramBuilder> GetList(out string pager, string query = "", string name = "", string typeid = "")
    {
      if (typeid.IsGuid())
        typeid = new Dictionary().GetAllChildsIDString(typeid.ToGuid(), true);
      return this.dataProgramBuilder.GetList(out pager, query, name, typeid);
    }

    public List<string> GetFields(Guid id)
    {
      RoadFlow.Data.Model.ProgramBuilder programBuilder = this.Get(id);
      if (programBuilder == null)
        return new List<string>();
      return new DBConnection().GetFieldsBySQL(programBuilder.DBConnID, programBuilder.SQL);
    }

    public string GetFieldsOptions(Guid id, string value)
    {
      List<string> fields = this.GetFields(id);
      StringBuilder stringBuilder = new StringBuilder();
      foreach (string str in fields)
        stringBuilder.AppendFormat("<option value=\"{0}\" {1}>{2}</option>", (object) str, str == value ? (object) "selected=\"selected\"" : (object) "", (object) str);
      return stringBuilder.ToString();
    }

    public void DeleteAllSet(Guid id)
    {
      RoadFlow.Data.Model.ProgramBuilder model = this.Get(id);
      if (model == null)
        return;
      model.Status = 2;
      this.Update(model);
      Log.Add("删除了应用程序设计", id.ToString(), Log.Types.其它分类, "", "", (RoadFlow.Data.Model.Users) null);
    }

    public void AddToCache(ProgramBuilderCache pb)
    {
      Opation.Set(Keys.CacheKeys.ProgramBuilder.ToString() + pb.Program.ID.ToString("N"), (object) pb);
    }

    public ProgramBuilderCache GetSet(Guid id)
    {
      object obj = Opation.Get(Keys.CacheKeys.ProgramBuilder.ToString() + id.ToString("N"));
      if (obj != null)
        return (ProgramBuilderCache) obj;
      ProgramBuilderCache pb = new ProgramBuilderCache();
      RoadFlow.Data.Model.ProgramBuilder programBuilder = this.Get(id);
      if (programBuilder == null)
        return (ProgramBuilderCache) null;
      pb.Program = programBuilder;
      pb.Fields = new ProgramBuilderFields().GetAll(id).OrderBy<RoadFlow.Data.Model.ProgramBuilderFields, int>((Func<RoadFlow.Data.Model.ProgramBuilderFields, int>) (p => p.Sort)).ToList<RoadFlow.Data.Model.ProgramBuilderFields>();
      pb.Querys = new ProgramBuilderQuerys().GetAll(id).OrderBy<RoadFlow.Data.Model.ProgramBuilderQuerys, int>((Func<RoadFlow.Data.Model.ProgramBuilderQuerys, int>) (p => p.Sort)).ToList<RoadFlow.Data.Model.ProgramBuilderQuerys>();
      pb.Buttons = new ProgramBuilderButtons().GetAll(id).OrderBy<RoadFlow.Data.Model.ProgramBuilderButtons, int>((Func<RoadFlow.Data.Model.ProgramBuilderButtons, int>) (p => p.Sort)).ToList<RoadFlow.Data.Model.ProgramBuilderButtons>();
      pb.Validates = new ProgramBuilderValidates().GetAll(id);
      pb.Export = new ProgramBuilderExport().GetAll(id).OrderBy<RoadFlow.Data.Model.ProgramBuilderExport, int>((Func<RoadFlow.Data.Model.ProgramBuilderExport, int>) (p => p.Sort)).ToList<RoadFlow.Data.Model.ProgramBuilderExport>();
      this.AddToCache(pb);
      return pb;
    }

    public bool Publish(Guid id, bool isMvc = false)
    {
      RoadFlow.Data.Model.ProgramBuilder model1 = this.Get(id);
      if (model1 == null || model1.Name.IsNullOrEmpty() || model1.SQL.IsNullOrEmpty())
        return false;
      AppLibrary appLibrary = new AppLibrary();
      RoadFlow.Data.Model.AppLibrary model2 = appLibrary.GetByCode(id.ToString(), true);
      bool flag1 = false;
      using (TransactionScope transactionScope = new TransactionScope())
      {
        if (model2 == null)
        {
          flag1 = true;
          model2 = new RoadFlow.Data.Model.AppLibrary();
          model2.ID = Guid.NewGuid();
        }
        model2.Address = !isMvc ? "/Platform/ProgramBuilder/Run.aspx?programid=" + id.ToString() : "/ProgramBuilder/Run?programid=" + id.ToString();
        model2.Code = id.ToString();
        model2.OpenMode = 0;
        model2.Title = model1.Name;
        model2.Type = model1.Type;
        if (flag1)
          appLibrary.Add(model2);
        else
          appLibrary.Update(model2);
        model1.Status = 1;
        this.Update(model1);
        List<RoadFlow.Data.Model.ProgramBuilderButtons> all = new ProgramBuilderButtons().GetAll(model1.ID);
        AppLibraryButtons1 appLibraryButtons1_1 = new AppLibraryButtons1();
        List<RoadFlow.Data.Model.AppLibraryButtons1> allByAppId = appLibraryButtons1_1.GetAllByAppID(model2.ID);
        List<RoadFlow.Data.Model.AppLibraryButtons1> appLibraryButtons1List = new List<RoadFlow.Data.Model.AppLibraryButtons1>();
        foreach (RoadFlow.Data.Model.ProgramBuilderButtons programBuilderButtons in all)
        {
          RoadFlow.Data.Model.ProgramBuilderButtons button = programBuilderButtons;
          RoadFlow.Data.Model.AppLibraryButtons1 model3 = allByAppId.Find((Predicate<RoadFlow.Data.Model.AppLibraryButtons1>) (p => p.ID == button.ID));
          bool flag2 = false;
          if (model3 == null)
          {
            model3 = new RoadFlow.Data.Model.AppLibraryButtons1();
            flag2 = true;
          }
          model3.AppLibraryID = model2.ID;
          model3.ButtonID = button.ButtonID;
          model3.Events = button.ClientScript;
          model3.Ico = button.Ico ?? "";
          model3.ID = button.ID;
          model3.Name = button.ButtonName;
          model3.ShowType = button.ShowType;
          model3.Sort = button.Sort;
          model3.Type = 0;
          model3.IsValidateShow = button.IsValidateShow;
          if (flag2)
            appLibraryButtons1_1.Add(model3);
          else
            appLibraryButtons1_1.Update(model3);
          appLibraryButtons1List.Add(model3);
        }
        foreach (RoadFlow.Data.Model.AppLibraryButtons1 appLibraryButtons1_2 in allByAppId)
        {
          RoadFlow.Data.Model.AppLibraryButtons1 button = appLibraryButtons1_2;
          if (appLibraryButtons1List.Find((Predicate<RoadFlow.Data.Model.AppLibraryButtons1>) (p => p.ID == button.ID)) == null)
            appLibraryButtons1_1.Delete(button.ID);
        }
        transactionScope.Complete();
      }
      new AppLibrary().ClearCache();
      new Menu().ClearAllDataTableCache();
      new AppLibraryButtons1().ClearCache();
      new AppLibrarySubPages().ClearCache();
      this.AddToCache(new ProgramBuilderCache()
      {
        Program = model1,
        Fields = new ProgramBuilderFields().GetAll(model1.ID).OrderBy<RoadFlow.Data.Model.ProgramBuilderFields, int>((Func<RoadFlow.Data.Model.ProgramBuilderFields, int>) (p => p.Sort)).ToList<RoadFlow.Data.Model.ProgramBuilderFields>(),
        Querys = new ProgramBuilderQuerys().GetAll(model1.ID).OrderBy<RoadFlow.Data.Model.ProgramBuilderQuerys, int>((Func<RoadFlow.Data.Model.ProgramBuilderQuerys, int>) (p => p.Sort)).ToList<RoadFlow.Data.Model.ProgramBuilderQuerys>(),
        Buttons = new ProgramBuilderButtons().GetAll(id).OrderBy<RoadFlow.Data.Model.ProgramBuilderButtons, int>((Func<RoadFlow.Data.Model.ProgramBuilderButtons, int>) (p => p.Sort)).ToList<RoadFlow.Data.Model.ProgramBuilderButtons>(),
        Validates = new ProgramBuilderValidates().GetAll(id),
        Export = new ProgramBuilderExport().GetAll(id).OrderBy<RoadFlow.Data.Model.ProgramBuilderExport, int>((Func<RoadFlow.Data.Model.ProgramBuilderExport, int>) (p => p.Sort)).ToList<RoadFlow.Data.Model.ProgramBuilderExport>()
      });
      return true;
    }

    public string GetJsonString(Guid id)
    {
      ProgramBuilderCache set = this.GetSet(id);
      if (set == null || set.Validates == null)
        return "{}";
      StringBuilder stringBuilder = new StringBuilder();
      foreach (RoadFlow.Data.Model.ProgramBuilderValidates validate in set.Validates)
      {
        string str = validate.TableName + "_" + validate.FieldName;
        stringBuilder.AppendFormat("\"{0}\":\"{1}\"", (object) str.ToLower(), (object) ("0_" + (object) validate.Validate));
        stringBuilder.Append(",");
      }
      return "{" + stringBuilder.ToString().TrimEnd(',') + "}";
    }

    public void AddToExportCache(Guid programID, Guid dbConnID, string querySql, List<IDbDataParameter> parList)
    {
      string str = ProgramBuilder.exportCackeKey + programID.ToString("N") + HttpContext.Current.Session.SessionID;
      Opation.Set(str + "_DbConnID", (object) dbConnID);
      Opation.Set(str + "_QuerySql", (object) querySql);
      Opation.Set(str + "_QueryParameter", (object) parList);
    }

    public Guid GetExportCache(Guid programID, out string querySql, out List<IDbDataParameter> parList)
    {
      querySql = "";
      parList = new List<IDbDataParameter>();
      string str = ProgramBuilder.exportCackeKey + programID.ToString("N") + HttpContext.Current.Session.SessionID;
      object obj1 = Opation.Get(str + "_QuerySql");
      if (obj1 != null)
        querySql = obj1.ToString();
      object obj2 = Opation.Get(str + "_QueryParameter");
      if (obj2 != null)
        parList = (List<IDbDataParameter>) obj2;
      object obj3 = Opation.Get(str + "_DbConnID");
      if (obj3 != null)
        return obj3.ToString().ToGuid();
      return Guid.Empty;
    }

    public DataTable GetExportDataTable(Guid programID, out string template, out string headerText, out string fileName)
    {
      template = "";
      headerText = "";
      fileName = "";
      ProgramBuilderCache set = this.GetSet(programID);
      if (set == null)
        return new DataTable();
      template = Files.FilePath + set.Program.ExportTemplate.DesDecrypt();
      headerText = set.Program.ExportHeaderText;
      fileName = set.Program.ExportFileName;
      string querySql;
      List<IDbDataParameter> parList;
      DataTable dataTable1 = new DBConnection().GetDataTable(this.GetExportCache(programID, out querySql, out parList), querySql, (IDataParameter[]) parList.ToArray());
      List<RoadFlow.Data.Model.ProgramBuilderExport> export = set.Export;
      DataTable dataTable2 = new DataTable();
      foreach (RoadFlow.Data.Model.ProgramBuilderExport programBuilderExport in export)
      {
        string showTitle = programBuilderExport.ShowTitle;
        int? nullable = programBuilderExport.DataType;
        int type;
        if (!nullable.HasValue)
        {
          type = 0;
        }
        else
        {
          nullable = programBuilderExport.DataType;
          type = nullable.Value;
        }
        Type exportColumnsType = this.GetExportColumnsType(type);
        DataColumn column = new DataColumn(showTitle, exportColumnsType);
        DataColumn dataColumn = column;
        nullable = programBuilderExport.Width;
        string str = nullable.ToString();
        dataColumn.Caption = str;
        dataTable2.Columns.Add(column);
      }
      int num = 1;
      Dictionary dictionary = new Dictionary();
      Organize organize = new Organize();
      foreach (DataRow row1 in (InternalDataCollectionBase) dataTable1.Rows)
      {
        DataRow row2 = dataTable2.NewRow();
        foreach (RoadFlow.Data.Model.ProgramBuilderExport programBuilderExport in export)
        {
          object empty = (object) string.Empty;
          object obj1 = programBuilderExport.Field.IsNullOrEmpty() ? (object) "" : row1[programBuilderExport.Field];
          int? showType = programBuilderExport.ShowType;
          object obj2;
          if (showType.HasValue)
          {
            switch (showType.GetValueOrDefault())
            {
              case 0:
                obj2 = obj1;
                goto label_24;
              case 1:
                obj2 = (object) num.ToString();
                goto label_24;
              case 2:
                obj2 = (object) obj1.ToString().ToDateTime().ToString(programBuilderExport.ShowFormat);
                goto label_24;
              case 3:
                obj2 = (object) obj1.ToString().ToDecimal().ToString(programBuilderExport.ShowFormat);
                goto label_24;
              case 4:
                obj2 = (object) dictionary.GetTitle(obj1.ToString().ToGuid());
                goto label_24;
              case 5:
                obj2 = (object) organize.GetNames(obj1.ToString(), ",");
                goto label_24;
              case 6:
                obj2 = (object) programBuilderExport.CustomString;
                goto label_24;
            }
          }
          obj2 = obj1;
label_24:
          row2[programBuilderExport.ShowTitle] = obj2;
        }
        ++num;
        dataTable2.Rows.Add(row2);
      }
      return dataTable2;
    }

    private Type GetExportColumnsType(int type)
    {
      Type type1 = "".GetType();
      switch (type)
      {
        case 0:
        case 1:
          type1 = "".GetType();
          break;
        case 2:
          type1 = new Decimal(-1, -1, -1, false, (byte) 0).GetType();
          break;
        case 3:
          type1 = DateTime.Now.GetType();
          break;
      }
      return type1;
    }

    public int InDataFormExcel(Guid programID, string table, string file, out string msg, string numberFiled = "")
    {
      int num = 0;
      msg = "";
      if (table.IsNullOrEmpty())
      {
        msg = "没有选择表";
        return num;
      }
      DBConnection dbConnection = new DBConnection();
      RoadFlow.Data.Model.ProgramBuilder programBuilder = this.Get(programID);
      if (programBuilder == null)
      {
        msg = "未找到应用程序设计";
        return num;
      }
      RoadFlow.Data.Model.DBConnection conn = dbConnection.Get(programBuilder.DBConnID, true);
      if (conn == null)
      {
        msg = "未找到相应的数据库连接";
        return num;
      }
      List<RoadFlow.Data.Model.ProgramBuilderFields> all = new ProgramBuilderFields().GetAll(programID);
      if (all.Count == 0)
      {
        msg = "应用程序未设置列表字段";
        return num;
      }
      try
      {
        DataTable dataTable = NPOIHelper.ReadToDataTable(file, 1);
        if (dataTable.Rows.Count == 0)
        {
          msg = "未发现要导入的数据";
          return num;
        }
        List<string> fieldsBySql = dbConnection.GetFieldsBySQL(programBuilder.DBConnID, "select * from " + table + " where 1=0");
        DataTable dt = new DataTable(table);
        string str = DateTimeNew.Now.ToString("yyyyMMddHHmmssfffff");
        foreach (RoadFlow.Data.Model.ProgramBuilderFields programBuilderFields in all)
        {
          RoadFlow.Data.Model.ProgramBuilderFields filed = programBuilderFields;
          if (!filed.Field.IsNullOrEmpty() && fieldsBySql.Find((Predicate<string>) (p => p.Equals(filed.Field, StringComparison.CurrentCultureIgnoreCase))) != null)
            dt.Columns.Add(filed.Field);
        }
        if (!numberFiled.IsNullOrEmpty())
          dt.Columns.Add(numberFiled);
        foreach (DataRow row1 in (InternalDataCollectionBase) dataTable.Rows)
        {
          DataRow row2 = dt.NewRow();
          foreach (DataColumn column in (InternalDataCollectionBase) dt.Columns)
          {
            DataColumn col = column;
            RoadFlow.Data.Model.ProgramBuilderFields programBuilderFields = all.Find((Predicate<RoadFlow.Data.Model.ProgramBuilderFields>) (p => p.Field.Equals(col.ColumnName)));
            if (programBuilderFields != null)
              row2[col.ColumnName] = row1[programBuilderFields.ShowTitle];
          }
          if (!numberFiled.IsNullOrEmpty())
            row2[numberFiled] = (object) str;
          dt.Rows.Add(row2);
        }
        num = dbConnection.DataTableToDB(conn, dt);
        Log.Add("通过应用程序导入了数据-表(" + table + ")标识(" + str + ")", file, Log.Types.其它分类, "", "", (RoadFlow.Data.Model.Users) null);
        return num;
      }
      catch (Exception ex)
      {
        msg = ex.Message;
        return num;
      }
    }
  }
}
