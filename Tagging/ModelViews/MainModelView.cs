using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tagging.ModelViews
{
  public class MainModelView
  {
    private static MainWindow window { get; set; };

    public int ItemSourceCount
    {
      get
      {
        return 99;
        //window.TagsDataGrid.ItemsSource
      }
    }

    public MainModelView(MainWindow Window)
    {
      window = Window;
    }
  }
}
