// Decompiled with JetBrains decompiler
// Type: WebMvc.MyAttributeAttribute
// Assembly: WebMvc, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 43FD7615-6DC3-49FB-B263-7F7CC91AFA77
// Assembly location: C:\inetpub\wwwroot\RoadFlowMvc\bin\WebMvc.dll

using System;

namespace WebMvc
{
  public class MyAttributeAttribute : Attribute
  {
    private bool checkLogin = true;
    private bool checkApp = true;
    private bool checkUrl = true;

    public bool CheckLogin
    {
      get
      {
        return this.checkLogin;
      }
      set
      {
        this.checkLogin = value;
      }
    }

    public bool CheckApp
    {
      get
      {
        return this.checkApp;
      }
      set
      {
        this.checkApp = value;
      }
    }

    public bool CheckUrl
    {
      get
      {
        return this.checkUrl;
      }
      set
      {
        this.checkUrl = value;
      }
    }
  }
}
