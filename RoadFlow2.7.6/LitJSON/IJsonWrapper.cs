// Decompiled with JetBrains decompiler
// Type: LitJson.IJsonWrapper
// Assembly: LitJSON, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: BD8BB339-7767-43EF-A04A-8D9AAFD8D90B
// Assembly location: C:\inetpub\wwwroot\RoadFlowMvc\bin\LitJSON.dll

using System.Collections;
using System.Collections.Specialized;

namespace LitJson
{
  public interface IJsonWrapper : IList, ICollection, IEnumerable, IOrderedDictionary, IDictionary
  {
    bool IsArray { get; }

    bool IsBoolean { get; }

    bool IsDouble { get; }

    bool IsInt { get; }

    bool IsLong { get; }

    bool IsObject { get; }

    bool IsString { get; }

    bool GetBoolean();

    double GetDouble();

    int GetInt();

    JsonType GetJsonType();

    long GetLong();

    string GetString();

    void SetBoolean(bool val);

    void SetDouble(double val);

    void SetInt(int val);

    void SetJsonType(JsonType type);

    void SetLong(long val);

    void SetString(string val);

    string ToJson();

    void ToJson(JsonWriter writer);
  }
}
