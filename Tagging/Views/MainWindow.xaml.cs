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
    //public ObservableCollection<Tag> ViewTags { get; set; } = 
    //App.Tags;
    //new ObservableCollection<Tag>(App.Tags.OrderByDescending(x => x.TagId));

    public MainWindow()
    {
      InitializeComponent();

      //TagsDataGrid.ItemsSource = ViewBags;
      //TagsDataGrid.ItemsSource = App.Tags.OrderByDescending(x => x.TagId);
      TagsDataGrid.ItemsSource = App.Tags;
    }

    private void TagsDataGrid_MouseDoubleClick(object sender, MouseButtonEventArgs e)
    {
      EditTag editTag = new EditTag(this, sender);
    }

    private void Window_Closing(object sender, System.ComponentModel.CancelEventArgs e)
    {
    }

    #region Exit command
    private void ExitCommand_CanExecute(object sender, CanExecuteRoutedEventArgs e)
    {
      e.CanExecute = true;
    }

    private void ExitCommand_Execute(object sender, ExecutedRoutedEventArgs e)
    {
      Application.Current.Shutdown();
    }
    #endregion

    #region New command
    private void NewCommand_CanExecute(object sender, CanExecuteRoutedEventArgs e)
    {
      e.CanExecute = true;
    }

    private void NewCommand_Execute(object sender, ExecutedRoutedEventArgs e)
    {
      EditTag editTag = new EditTag(this);
    }
    #endregion

    #region Save command
    private void SaveCommand_CanExecute(object sender, CanExecuteRoutedEventArgs e)
    {
      e.CanExecute = true;
    }

    private void SaveCommand_Execute(object sender, ExecutedRoutedEventArgs e)
    {
      string JsonFileName = @"%OneDrive%\Data\Tagging.json";
      string oneDrive = Environment.GetEnvironmentVariable("OneDrive");
      JsonFileName = JsonFileName.Replace("%OneDrive%", oneDrive);

      //Save the original App.Tags list
      string json = JsonConvert.SerializeObject(App.Tags.OrderByDescending(x => x.TagId), Formatting.Indented);
      using (StreamWriter stream = new StreamWriter(JsonFileName))
      {
        stream.Write(json);
      }

    }
    #endregion

    #region TagID to date command
    private void TagIdToDateCommand_CanExecute(object sender, CanExecuteRoutedEventArgs e)
    {
      e.CanExecute = true;
    }

    private void TagIdToDateCommand_Execute(object sender, ExecutedRoutedEventArgs e)
    {
      TagIdToDateWindow window = new TagIdToDateWindow(Left, Top);
      window.ShowDialog();
    }
    #endregion
  }
}
