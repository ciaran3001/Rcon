// Decompiled with JetBrains decompiler
// Type: RconClient.ServerInformation
// Assembly: RconClient, Version=1.0.7348.19481, Culture=neutral, PublicKeyToken=null
// MVID: F3A46EEA-A1F9-45A6-9A44-5F80108FCF66
// Assembly location: C:\Users\Ciaran\Desktop\HLL_RCON 17th Feb 2020\RconClient.exe

namespace RconClient
{
  public struct ServerInformation
  {
    private RconGetter m_getter;
    private string[] m_data;

    public ServerInformation(RconGetter rconGetter, string[] dataArray)
    {
      this.m_getter = rconGetter;
      this.m_data = dataArray;
    }

    public string Name
    {
      get
      {
        return this.m_getter.DisplayName;
      }
    }

    public string Data
    {
      get
      {
        if (!this.m_getter.IsArray || this.m_data.Length <= 1)
          return this.m_data[0];
        string str1 = "";
        foreach (string str2 in this.m_data)
          str1 = str1 + str2 + "\n";
        return str1;
      }
    }
  }
}
