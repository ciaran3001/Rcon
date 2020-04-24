// Decompiled with JetBrains decompiler
// Type: RconClient.ServerConnectionDetails
// Assembly: RconClient, Version=1.0.7348.19481, Culture=neutral, PublicKeyToken=null
// MVID: F3A46EEA-A1F9-45A6-9A44-5F80108FCF66
// Assembly location: C:\Users\Ciaran\Desktop\HLL_RCON 17th Feb 2020\RconClient.exe

namespace RconClient
{
  public struct ServerConnectionDetails
  {
    public string ServerAddress { get; private set; }

    public int ServerPort { get; private set; }

    public string ServerPassword { get; private set; }

    public ServerConnectionDetails(string serverAddress, int serverPort, string serverPassword)
    {
      this.ServerAddress = serverAddress;
      this.ServerPort = serverPort;
      this.ServerPassword = serverPassword;
    }
  }
}
