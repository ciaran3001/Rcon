// Decompiled with JetBrains decompiler
// Type: RconClient.RconCommandParameter
// Assembly: RconClient, Version=1.0.7348.19481, Culture=neutral, PublicKeyToken=null
// MVID: F3A46EEA-A1F9-45A6-9A44-5F80108FCF66
// Assembly location: C:\Users\Ciaran\Desktop\HLL_RCON 17th Feb 2020\RconClient.exe

using System;
using System.Linq;
using System.Xml.Linq;

namespace RconClient
{
  public class RconCommandParameter
  {
    public string Hint { get; private set; }

    public string Type { get; private set; }

    public bool Quoted { get; private set; }

    public bool Optional { get; private set; }

    public string GetterToUse { get; private set; }

    public RconCommandParameter(XElement parameterNode)
    {
      this.Hint = (string) parameterNode.Attribute((XName) "hint");
      this.Type = (string) parameterNode.Attribute((XName) "type");
      this.GetterToUse = (string) parameterNode.Attribute((XName) "usegetter");
      this.Quoted = (string) parameterNode.Attribute((XName) "quoted") == "true";
      this.Optional = (string) parameterNode.Attribute((XName) "optional") == "true";
    }

    public bool VerifyUserInput(string userInput)
    {
      if (string.IsNullOrEmpty(userInput) && !this.Optional)
        return false;
      string type = this.Type;
      if (type == "int")
      {
        int result;
        return int.TryParse(userInput, out result);
      }
      if (type == "bool" || type == "string")
        return true;
      if (type == "password")
        return !userInput.Any<char>(new Func<char, bool>(char.IsWhiteSpace));
      return false;
    }
  }
}
