// Decompiled with JetBrains decompiler
// Type: RconClient.RconStaticLibrary
// Assembly: RconClient, Version=1.0.7348.19481, Culture=neutral, PublicKeyToken=null
// MVID: F3A46EEA-A1F9-45A6-9A44-5F80108FCF66
// Assembly location: C:\Users\Ciaran\Desktop\HLL_RCON 17th Feb 2020\RconClient.exe

using System;
using System.Collections.Generic;
using System.Linq;
using System.Xml.Linq;

namespace RconClient
{
  internal class RconStaticLibrary
  {
    private static string s_rconSuccessReply = "SUCCESS";
    private static string s_rconFailReply = "FAIL";
    private static string s_commandsFilename = "Commands.xml";
    private static List<RconCommand> s_rconCommands = new List<RconCommand>();
    private static List<RconGetter> s_rconGetters = new List<RconGetter>();

    public static List<RconCommand> AvailableCommands
    {
      get
      {
        return RconStaticLibrary.s_rconCommands;
      }
    }

    public static List<RconGetter> AvailableGetters
    {
      get
      {
        return RconStaticLibrary.s_rconGetters;
      }
    }

    public static void UpdateAvailableCommandsAndGetters()
    {
      XElement xelement = XElement.Load(RconStaticLibrary.s_commandsFilename);
      foreach (XElement element in xelement.Elements((XName) "Commands").Elements<XElement>())
        RconStaticLibrary.s_rconCommands.Add(new RconCommand(element));
      foreach (XElement element in xelement.Elements((XName) "Getters").Elements<XElement>())
        RconStaticLibrary.s_rconGetters.Add(new RconGetter(element));
    }

    public static RconGetter FindGetterByName(string name)
    {
      try
      {
        return RconStaticLibrary.s_rconGetters.Where<RconGetter>((Func<RconGetter, bool>) (getter => getter.Name.Equals(name))).First<RconGetter>();
      }
      catch (Exception ex)
      {
        return (RconGetter) null;
      }
    }

    public static bool IsSuccessReply(string reply)
    {
      return reply.Equals(RconStaticLibrary.s_rconSuccessReply);
    }

    public static bool IsFailReply(string reply)
    {
      return reply.Equals(RconStaticLibrary.s_rconFailReply);
    }
  }
}
