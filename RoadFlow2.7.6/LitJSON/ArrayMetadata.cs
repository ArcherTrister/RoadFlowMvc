// Decompiled with JetBrains decompiler
// Type: LitJson.ArrayMetadata
// Assembly: LitJSON, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: BD8BB339-7767-43EF-A04A-8D9AAFD8D90B
// Assembly location: C:\inetpub\wwwroot\RoadFlowMvc\bin\LitJSON.dll

using System;

namespace LitJson
{
  internal struct ArrayMetadata
  {
    private Type element_type;
    private bool is_array;
    private bool is_list;

    public Type ElementType
    {
      get
      {
        if (this.element_type == (Type) null)
          return typeof (JsonData);
        return this.element_type;
      }
      set
      {
        this.element_type = value;
      }
    }

    public bool IsArray
    {
      get
      {
        return this.is_array;
      }
      set
      {
        this.is_array = value;
      }
    }

    public bool IsList
    {
      get
      {
        return this.is_list;
      }
      set
      {
        this.is_list = value;
      }
    }
  }
}
