// Decompiled with JetBrains decompiler
// Type: RconClient.RconCommand
// Assembly: RconClient, Version=1.0.7348.19481, Culture=neutral, PublicKeyToken=null
// MVID: F3A46EEA-A1F9-45A6-9A44-5F80108FCF66
// Assembly location: C:\Users\Ciaran\Desktop\HLL_RCON 17th Feb 2020\RconClient.exe

using System.Collections.Generic;
using System.Xml.Linq;

namespace RconClient
{
  public class RconCommand
  {
    private List<RconCommandParameter> m_parameters = new List<RconCommandParameter>();
    private string m_messageTemplate;

    public string m_name { get; private set; }

    public RconCommand(XElement commandNode)
    {
      this.m_name = (string) commandNode.Attribute((XName) "name");
      this.m_messageTemplate = (string) commandNode.Attribute((XName) "messagetemplate");
      foreach (XElement element in commandNode.Elements((XName) "Parameter"))
        this.m_parameters.Add(new RconCommandParameter(element));
    }

    public void StartExecuting(ServerSession serverSession)
    {
      List<string> stringList = new List<string>();
      if (this.m_parameters.Count > 0)
      {
        ParameterDialog parameterDialog = new ParameterDialog(this.m_parameters, serverSession);
        bool? nullable = parameterDialog.ShowDialog();
        bool flag = false;
        if ((nullable.GetValueOrDefault() == flag ? (nullable.HasValue ? 1 : 0) : 0) != 0)
          return;
        foreach (RconCommandParameter parameter in this.m_parameters)
        {
          string s = parameterDialog.ParameterToUserInput[parameter].Text;
          if (parameter.Quoted)
            s = RconCommand.QuoteString(s);
          stringList.Add(s);
        }
      }
      if (!serverSession.SendMessage(string.Format(this.m_messageTemplate, (object[]) stringList.ToArray()), true))
        return;
      string receivedMessage = "";
      serverSession.ReceiveMessage(out receivedMessage, true, true);
    }

    public static string QuoteString(string s)
    {
      string str = "\"";
      for (int index = 0; index < s.Length; ++index)
        str = s[index] != '"' ? (s[index] != '\\' ? str + s[index].ToString() : str + "\\\\") : str + "\\\"";
      return str + "\"";
    }
  }
}
