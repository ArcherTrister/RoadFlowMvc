// Decompiled with JetBrains decompiler
// Type: UploadConfig
// Assembly: WebMvc, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 43FD7615-6DC3-49FB-B263-7F7CC91AFA77
// Assembly location: C:\inetpub\wwwroot\RoadFlowMvc\bin\WebMvc.dll

public class UploadConfig
{
  public string PathFormat { get; set; }

  public string UploadFieldName { get; set; }

  public int SizeLimit { get; set; }

  public string[] AllowExtensions { get; set; }

  public bool Base64 { get; set; }

  public string Base64Filename { get; set; }
}
