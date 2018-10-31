// Decompiled with JetBrains decompiler
// Type: RoadFlow.Data.Interface.IDBHelper
// Assembly: RoadFlow.Data.Interface, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 2109DD37-8E2D-4F7C-8293-6084646C162F
// Assembly location: C:\inetpub\wwwroot\RoadFlowMvc\bin\RoadFlow.Data.Interface.dll

using System.Collections.Generic;
using System.Data;

namespace RoadFlow.Data.Interface
{
  public interface IDBHelper
  {
    DataTable GetDataTable(string sql);

    DataSet GetDataSet(string sql);

    int Execute(string sql);

    int Execute(List<string> sqlList);

    string ExecuteScalar(string sql);

    string GetFieldValue(string sql);
  }
}
