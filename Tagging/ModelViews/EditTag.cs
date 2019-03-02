using CHiDateTimeWeekNumber;
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

    private static List<string> Actions { get; set; } = new List<string>(GetActions());
    private static bool NewTag = false;
    private static bool SaveTag = false;

    private static List<string> GetActions()
    {
      return App.Tags
        .Select(x => x.Action)
        .Distinct()
        .OrderBy(x => x)
        .ToList();
    }

    /// <summary>
    /// Edit selected Tag
    /// </summary>
    /// <param name="parent"></param>
    /// <param name="sender"></param>
    public EditTag(MainWindow parent, object sender)
    {
      DataGrid dataGrid = sender as DataGrid;
      CurrentTag = (Tag)dataGrid.CurrentItem;

      NewTag = false;
      SaveTag = false;
      OpenTag(parent);
    }

    /// <summary>
    /// Create a new Tag
    /// </summary>
    /// <param name="parent"></param>
    public EditTag(MainWindow parent)
    {
      CurrentTag = new Tag();
      CurrentTag.Date = DateTime.Now;

      NewTag = true;
      SaveTag = false;
      CalculatTagID();
      OpenTag(parent);
    }

    private void OpenTag(MainWindow parent)
    {
      EditWindow window = new EditWindow(CalculatTagID, SaveTagAction);
      window.Left = parent.Left + (parent.Width - window.Width) / 2;
      window.Top = parent.Top + (parent.Height - window.Height) / 2;
      window.DataContext = CurrentTag;
      window.ActionComboBox.ItemsSource = Actions;

      window.ShowDialog();

      if (NewTag && SaveTag)
      {
        App.Tags.Add(CurrentTag);
      }
    }

    public void CalculatTagID()
    {
      if (!NewTag)
      {
        return;
      }

      DateTimeWeekNumber weekNumber = new DateTimeWeekNumber(CurrentTag.Date);
      string tagId = weekNumber.WeekNoCompact;

      int dayCount = 0;
      try
      {
        dayCount = App.Tags
          .Where(x => x.Date.Date == CurrentTag.Date.Date)
          .Select(x => x.DayCount)
          .Max();
      }
      catch { }
      dayCount++;

      CurrentTag.TagId = $"{tagId}{dayCount.ToString("D2")}";
    }

    public void SaveTagAction()
    {
      SaveTag = true;
    }
  }
}
