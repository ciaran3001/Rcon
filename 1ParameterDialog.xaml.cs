// Decompiled with JetBrains decompiler
// Type: RconClient.ParameterDialog
// Assembly: RconClient, Version=1.0.7348.19481, Culture=neutral, PublicKeyToken=null
// MVID: F3A46EEA-A1F9-45A6-9A44-5F80108FCF66
// Assembly location: C:\Users\Ciaran\Desktop\HLL_RCON 17th Feb 2020\RconClient.exe

using System;
using System.CodeDom.Compiler;
using System.Collections.Generic;
using System.ComponentModel;
using System.Diagnostics;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Markup;
using System.Windows.Media;

namespace RconClient
{
  public class ParameterDialog : Window, IComponentConnector
  {
    private UIElement m_elementToFocus;
    internal DockPanel ParameterDockPanel;
    internal Button btnDialogOk;
    private bool _contentLoaded;

    public Dictionary<RconCommandParameter, InputBox> ParameterToUserInput { get; private set; }

    public ParameterDialog(List<RconCommandParameter> parameters, ServerSession serverSession)
    {
      this.InitializeComponent();
      this.ParameterToUserInput = new Dictionary<RconCommandParameter, InputBox>();
      foreach (RconCommandParameter parameter in parameters)
        this.CreateAndBindInputField(parameter, serverSession);
      if (this.m_elementToFocus == null)
        return;
      this.m_elementToFocus.Focus();
    }

    private void CreateAndBindInputField(
      RconCommandParameter parameter,
      ServerSession serverSession)
    {
      WrapPanel wrapPanel1 = new WrapPanel();
      wrapPanel1.Orientation = Orientation.Vertical;
      wrapPanel1.HorizontalAlignment = HorizontalAlignment.Left;
      WrapPanel wrapPanel2 = wrapPanel1;
      Label label1 = new Label();
      label1.Padding = new Thickness(0.0, 5.0, 5.0, 5.0);
      label1.Content = (object) parameter.Hint;
      Label label2 = label1;
      wrapPanel2.Children.Add((UIElement) label2);
      InputBox inputBox = new InputBox(parameter, serverSession);
      wrapPanel2.Children.Add((UIElement) inputBox.ControlBox);
      DockPanel.SetDock((UIElement) wrapPanel2, Dock.Top);
      this.ParameterDockPanel.Children.Add((UIElement) wrapPanel2);
      this.ParameterToUserInput.Add(parameter, inputBox);
      if (this.m_elementToFocus != null)
        return;
      this.m_elementToFocus = (UIElement) inputBox.ControlBox;
    }

    private void BtnDialogOk_Click(object sender, RoutedEventArgs e)
    {
      foreach (RconCommandParameter key in this.ParameterToUserInput.Keys)
      {
        if (!key.VerifyUserInput(this.ParameterToUserInput[key].Text))
        {
          this.ParameterToUserInput[key].ControlBox.BorderBrush = (Brush) Brushes.Red;
          return;
        }
        this.ParameterToUserInput[key].ControlBox.BorderBrush = (Brush) Brushes.Gray;
      }
      this.DialogResult = new bool?(true);
    }

    [DebuggerNonUserCode]
    [GeneratedCode("PresentationBuildTasks", "4.0.0.0")]
    public void InitializeComponent()
    {
      if (this._contentLoaded)
        return;
      this._contentLoaded = true;
      Application.LoadComponent((object) this, new Uri("/RconClient;component/parameterdialog.xaml", UriKind.Relative));
    }

    [DebuggerNonUserCode]
    [GeneratedCode("PresentationBuildTasks", "4.0.0.0")]
    [EditorBrowsable(EditorBrowsableState.Never)]
    void IComponentConnector.Connect(int connectionId, object target)
    {
      if (connectionId != 1)
      {
        if (connectionId == 2)
        {
          this.btnDialogOk = (Button) target;
          this.btnDialogOk.Click += new RoutedEventHandler(this.BtnDialogOk_Click);
        }
        else
          this._contentLoaded = true;
      }
      else
        this.ParameterDockPanel = (DockPanel) target;
    }
  }
}
