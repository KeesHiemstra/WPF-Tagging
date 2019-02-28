using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;
using Tagging.Models;
using Tagging.ModelViews;

namespace Tagging.Views
{
  /// <summary>
  /// Interaction logic for EditWindow.xaml
  /// </summary>
  public partial class EditWindow : Window
  {
    public EditWindow()
    {
      InitializeComponent();
    }

    private void OkayButton_CanExecute(object sender, CanExecuteRoutedEventArgs e)
    {
      e.CanExecute = !string.IsNullOrEmpty(EditTag.CurrentTag.Date.ToString()) &&
        !string.IsNullOrWhiteSpace(EditTag.CurrentTag.Action) &&
        !string.IsNullOrWhiteSpace(EditTag.CurrentTag.Subject);
    }

    private void OkayButton_Executed(object sender, ExecutedRoutedEventArgs e)
    {
      Close();
    }
  }
}
