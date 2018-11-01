// Decompiled with JetBrains decompiler
// Type: LitJson.ObjectMetadata
// Assembly: LitJSON, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: BD8BB339-7767-43EF-A04A-8D9AAFD8D90B
// Assembly location: C:\inetpub\wwwroot\RoadFlowMvc\bin\LitJSON.dll

using System;
using System.Collections.Generic;

namespace LitJson
{
  internal struct ObjectMetadata
  {
    private Type element_type;
    private bool is_dictionary;
    private IDictionary<string, PropertyMetadata> properties;

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

    public bool IsDictionary
    {
      get
      {
        return this.is_dictionary;
      }
      set
      {
        this.is_dictionary = value;
      }
    }

    public IDictionary<string, PropertyMetadata> Properties
    {
      get
      {
        return this.properties;
      }
      set
      {
        this.properties = value;
      }
    }
  }
}
