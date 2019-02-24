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
using Tagging.ModelViews;

namespace Tagging.Views
{
  /// <summary>
  /// Interaction logic for TagIdToDateWindow.xaml
  /// </summary>
  public partial class TagIdToDateWindow : Window
  {
    private static TagIdToDate tagIdToDate = new TagIdToDate();

    public TagIdToDateWindow(double WindowLeft, double WindowTop)
    {
      InitializeComponent();

      TagIdTextBox.Focus();
      Left = WindowLeft + 20;
      Top = WindowTop + 20;
    }

    private void GetDate_Click(object sender, RoutedEventArgs e)
    {
      DateTextBlock.Text = tagIdToDate.CalculateTagIdToDate(TagIdTextBox.Text);
    }

    private void OK_Click(object sender, RoutedEventArgs e)
    {
      Close();
    }
  }
}
