using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.IO;
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
using System.Windows.Navigation;
using System.Windows.Shapes;
using Tagging.Models;
using Tagging.ModelViews;
using Tagging.Views;

namespace Tagging
{
  /// <summary>
  /// Interaction logic for MainWindow.xaml
  /// </summary>
  public partial class MainWindow : Window
  { 
    public static ObservableCollection<Tag> Tags { get; set; } = 
      new ObservableCollection<Tag>(App.Tags.OrderByDescending(x => x.TagId));

    public MainWindow()
    {
      InitializeComponent();

      TagsDataGrid.ItemsSource = Tags;
    }

    private void ExitCommand_CanExecute(object sender, CanExecuteRoutedEventArgs e)
    {
      e.CanExecute = true;
    }

    private void ExitCommand_Execute(object sender, ExecutedRoutedEventArgs e)
    {
      Application.Current.Shutdown();
    }

    private void NewCommand_CanExecute(object sender, CanExecuteRoutedEventArgs e)
    {
      e.CanExecute = true;
    }

    private void NewCommand_Execute(object sender, ExecutedRoutedEventArgs e)
    {
      MessageBox.Show("Not build yet");
    }

    private void Window_Closing(object sender, System.ComponentModel.CancelEventArgs e)
    {
      
    }

    private void SaveCommand_CanExecute(object sender, CanExecuteRoutedEventArgs e)
    {
      e.CanExecute = true;
    }

    private void SaveCommand_Execute(object sender, ExecutedRoutedEventArgs e)
    {
      string JsonFileName = @"%OneDrive%\Data\Tagging.json";
      string oneDrive = Environment.GetEnvironmentVariable("OneDrive");
      JsonFileName = JsonFileName.Replace("%OneDrive%", oneDrive);

      string json = JsonConvert.SerializeObject(Tags, Formatting.Indented);
      using (StreamWriter stream = new StreamWriter(JsonFileName))
      {
        stream.Write(json);
      }

    }

    private void TagIdToDateCommand_CanExecute(object sender, CanExecuteRoutedEventArgs e)
    {
      e.CanExecute = true;
    }

    private void TagIdToDateCommand_Execute(object sender, ExecutedRoutedEventArgs e)
    {
      TagIdToDateWindow window = new TagIdToDateWindow(Left, Top);
      window.ShowDialog();
    }

    private void TagsDataGrid_MouseDoubleClick(object sender, MouseButtonEventArgs e)
    {
      EditTag editTag = new EditTag(this, sender);
    }
  }
}
