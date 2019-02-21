using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Threading.Tasks;
using System.Windows;
using WpfApp1908401.Models;

namespace WpfApp1908401
{
  /// <summary>
  /// Interaction logic for App.xaml
  /// </summary>
  public partial class App : Application
  {
    private static ApplicationSettings settings { get; set; } = new ApplicationSettings();

    public App()
    {
      //MessageBox.Show($"Database name: {settings.DatabaseName}");
    }
  }
}
