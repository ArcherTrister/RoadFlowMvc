// Decompiled with JetBrains decompiler
// Type: UEConfig
// Assembly: WebMvc, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 43FD7615-6DC3-49FB-B263-7F7CC91AFA77
// Assembly location: C:\inetpub\wwwroot\RoadFlowMvc\bin\WebMvc.dll

using Newtonsoft.Json.Linq;
using System;
using System.IO;
using System.Linq;
using System.Web;

public static class UEConfig
{
  private static bool noCache = true;
  private static JObject _Items;

  private static JObject BuildItems()
  {
    return JObject.Parse(File.ReadAllText(HttpContext.Current.Server.MapPath("config.json")));
  }

  public static JObject Items
  {
    get
    {
      if (UEConfig.noCache || UEConfig._Items == null)
        UEConfig._Items = UEConfig.BuildItems();
      return UEConfig._Items;
    }
  }

  public static T GetValue<T>(string key)
  {
    return UEConfig.Items[key].Value<T>();
  }

  public static string[] GetStringList(string key)
  {
    return UEConfig.Items[key].Select<JToken, string>((Func<JToken, string>) (x => x.Value<string>())).ToArray<string>();
  }

  public static string GetString(string key)
  {
    return UEConfig.GetValue<string>(key);
  }

  public static int GetInt(string key)
  {
    return UEConfig.GetValue<int>(key);
  }
}
