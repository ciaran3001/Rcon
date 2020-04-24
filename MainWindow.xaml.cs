// Decompiled with JetBrains decompiler
// Type: RconClient.MainWindow
// Assembly: RconClient, Version=1.0.7348.19481, Culture=neutral, PublicKeyToken=null
// MVID: F3A46EEA-A1F9-45A6-9A44-5F80108FCF66
// Assembly location: C:\Users\Ciaran\Desktop\HLL_RCON 17th Feb 2020\RconClient.exe

using System;
using System.CodeDom.Compiler;
using System.ComponentModel;
using System.Diagnostics;
using System.Reflection;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Markup;

namespace RconClient
{
  public partial class MainWindow : Window, IComponentConnector
  {
    internal DockPanel MainWindowContainer;
    private bool _contentLoaded;

    public MainWindow()
    {
      this.InitializeComponent();
      this.Title = this.Title + " v" + this.VersionString();
      RconStaticLibrary.UpdateAvailableCommandsAndGetters();
      ConnectDialog connectDialog = new ConnectDialog(new ServerConnectionDetails());
      bool? nullable = connectDialog.ShowDialog();
      bool flag = false;
      if ((nullable.GetValueOrDefault() == flag ? (nullable.HasValue ? 1 : 0) : 0) != 0)
        this.Close();
      Task.Run((Action) (() => this.StartNewSessionAndCreateUI(connectDialog)));
    }

    private void StartNewSessionAndCreateUI(ConnectDialog connectDialog)
    {
      ServerSession newSession = new ServerSession(connectDialog.ConnectionDetails);
      this.Dispatcher.Invoke((Action) (() => this.MainWindowContainer.Children.Add((UIElement) new ServerControl(newSession))));
    }

    public void OnNewSessionStarted(ConnectDialog connectDialog)
    {
      this.MainWindowContainer.Children.Clear();
      this.StartNewSessionAndCreateUI(connectDialog);
    }

    protected string VersionString()
    {
      string[] strArray = Assembly.GetExecutingAssembly().GetName().Version.ToString().Split('.');
      string str = "$Change: 615836 $";
      return string.Join(".", strArray[0], strArray[1], str.Substring(9).TrimEnd('$'));
    }

    [DebuggerNonUserCode]
    [GeneratedCode("PresentationBuildTasks", "4.0.0.0")]
    public void InitializeComponent()
    {
      if (this._contentLoaded)
        return;
      this._contentLoaded = true;
      Application.LoadComponent((object) this, new Uri("/RconClient;component/mainwindow.xaml", UriKind.Relative));
    }

    [DebuggerNonUserCode]
    [GeneratedCode("PresentationBuildTasks", "4.0.0.0")]
    [EditorBrowsable(EditorBrowsableState.Never)]
    void IComponentConnector.Connect(int connectionId, object target)
    {
      if (connectionId == 1)
        this.MainWindowContainer = (DockPanel) target;
      else
        this._contentLoaded = true;
    }
  }
}
