// Decompiled with JetBrains decompiler
// Type: RconClient.StatusToBrushConverter
// Assembly: RconClient, Version=1.0.7348.19481, Culture=neutral, PublicKeyToken=null
// MVID: F3A46EEA-A1F9-45A6-9A44-5F80108FCF66
// Assembly location: C:\Users\Ciaran\Desktop\HLL_RCON 17th Feb 2020\RconClient.exe

using System;
using System.Globalization;
using System.Windows.Data;
using System.Windows.Media;

namespace RconClient
{
  [ValueConversion(typeof (Status), typeof (SolidColorBrush))]
  public partial class StatusToBrushConverter : IValueConverter
  {
    public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
    {
      switch ((Status) value)
      {
        case Status.Ok:
          return (object) Brushes.ForestGreen;
        case Status.Warning:
          return (object) Brushes.Yellow;
        case Status.Error:
          return (object) Brushes.OrangeRed;
        default:
          return (object) null;
      }
    }

    public object ConvertBack(
      object value,
      Type targetType,
      object parameter,
      CultureInfo culture)
    {
      return (object) null;
    }
  }
}
