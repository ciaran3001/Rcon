// Decompiled with JetBrains decompiler
// Type: RconClient.Properties.Settings
// Assembly: RconClient, Version=1.0.7348.19481, Culture=neutral, PublicKeyToken=null
// MVID: F3A46EEA-A1F9-45A6-9A44-5F80108FCF66
// Assembly location: C:\Users\Ciaran\Desktop\HLL_RCON 17th Feb 2020\RconClient.exe

using System.CodeDom.Compiler;
using System.Configuration;
using System.Diagnostics;
using System.Runtime.CompilerServices;

namespace RconClient.Properties
{
  [CompilerGenerated]
  [GeneratedCode("Microsoft.VisualStudio.Editors.SettingsDesigner.SettingsSingleFileGenerator", "15.9.0.0")]
  internal sealed class Settings : ApplicationSettingsBase
  {
    private static Settings defaultInstance = (Settings) SettingsBase.Synchronized((SettingsBase) new Settings());

    public static Settings Default
    {
      get
      {
        return Settings.defaultInstance;
      }
    }

    [UserScopedSetting]
    [DebuggerNonUserCode]
    [DefaultSettingValue("")]
    public string LastUsedServerAddress
    {
      get
      {
        return (string) this[nameof (LastUsedServerAddress)];
      }
      set
      {
        this[nameof (LastUsedServerAddress)] = (object) value;
      }
    }

    [UserScopedSetting]
    [DebuggerNonUserCode]
    [DefaultSettingValue("27029")]
    public int LastUsedServerPort
    {
      get
      {
        return (int) this[nameof (LastUsedServerPort)];
      }
      set
      {
        this[nameof (LastUsedServerPort)] = (object) value;
      }
    }
  }
}
