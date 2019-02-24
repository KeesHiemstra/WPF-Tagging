using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using WpfApp1908401.Views;

namespace WpfApp1908401
{
  /// <summary>
  /// Interaction logic for MainWindow.xaml
  /// </summary>
  public partial class MainWindow : Window
  {
    public MainWindow()
    {
      InitializeComponent();
    }

    //ToDo: Remove useless method
    private void Window_Loaded(object sender, RoutedEventArgs e)
    {
    }

    /// <summary>
    /// Close the MainWindow
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    private void FileExitMenu_Click(object sender, RoutedEventArgs e)
    {
      Close();
    }

    private void ExitCommand_CanExecute(object sender, CanExecuteRoutedEventArgs e)
    {
      e.CanExecute = true;
    }

    private void ExitCommand_Execute(object sender, ExecutedRoutedEventArgs e)
    {
      Application.Current.Shutdown();
    }

    private void SettingsCommand_CanExecute(object sender, CanExecuteRoutedEventArgs e)
    {
      e.CanExecute = true;
    }

    private void SettingsCommand_Execute(object sender, ExecutedRoutedEventArgs e)
    {
      Settings settings = new Settings(Left, Top);
      settings.ShowDialog();
    }
  }
}
