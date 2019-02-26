using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;
using Tagging.Models;
using Tagging.Views;

namespace Tagging.ModelViews
{
  public class EditTag
  {
    public static Tag CurrentTag { get; set; }

    public EditTag(MainWindow parent, object sender)
    {
      DataGrid dataGrid = sender as DataGrid;
      CurrentTag = (Tag)dataGrid.CurrentItem;

      OpenTag(parent);
    }

    /// <summary>
    /// Create a new Tag
    /// </summary>
    /// <param name="parent"></param>
    public EditTag(MainWindow parent)
    {
      CurrentTag = new Tag();

      OpenTag(parent);
    }

    private void OpenTag(MainWindow parent)
    {
      EditWindow window = new EditWindow();
      window.Left = parent.Left + (window.Width / 2);
      window.Top = parent.Top + (window.Height / 2);
      window.DataContext = CurrentTag;

      window.ShowDialog();
    }
  }
}
