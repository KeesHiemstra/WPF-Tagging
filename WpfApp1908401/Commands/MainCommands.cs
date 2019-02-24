using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace WpfApp1908401.Commands
{
  public static class MainCommands
  {
    public static readonly RoutedUICommand Exit = new RoutedUICommand
      (
        "E_xit",
        "Exit",
        typeof(MainCommands),
        new InputGestureCollection()
        {
          new KeyGesture(Key.F4, ModifierKeys.Alt)
        }
      );

    public static readonly RoutedUICommand Settings = new RoutedUICommand
      (
        "Settings",
        "Settings",
        typeof(MainCommands),
        new InputGestureCollection() { }
      );
  }
}
