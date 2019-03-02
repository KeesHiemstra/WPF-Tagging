using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace Tagging.Commands
{
  public static class MainWindowCommands
  {
    public static readonly RoutedUICommand Exit = new RoutedUICommand
      (
        "E_xit",
        "Exit",
        typeof(MainWindowCommands),
        new InputGestureCollection()
        {
          new KeyGesture(Key.F4, ModifierKeys.Alt)
        }
      );

    public static readonly RoutedUICommand New = new RoutedUICommand
      (
        "_New",
        "New",
        typeof(MainWindowCommands),
        new InputGestureCollection()
        {
          new KeyGesture(Key.N, ModifierKeys.Control)
        }
      );

    public static readonly RoutedUICommand Save = new RoutedUICommand
      (
        "_Save",
        "Save",
        typeof(MainWindowCommands),
        new InputGestureCollection()
        {
          new KeyGesture(Key.S, ModifierKeys.Control)
        }
      );

    public static readonly RoutedUICommand TagIdToDate = new RoutedUICommand
      (
        "Tag ID to _Date",
        "TagIdToDate",
        typeof(MainWindowCommands),
        new InputGestureCollection()
        {
          new KeyGesture(Key.D, ModifierKeys.Alt)
        }
      );
  }
}
