using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace Tagging.Commands
{
  public static class EditWindowCommands
  {
    public static readonly RoutedUICommand Okay = new RoutedUICommand
      (
        "Okay",
        "Okay",
        typeof(EditWindowCommands),
        new InputGestureCollection()
        {
        }
      );

  }
}
