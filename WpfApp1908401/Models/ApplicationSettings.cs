using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WpfApp1908401.Models
{
  public class ApplicationSettings
  {
    public string ServerName { get; set; }
    public string DatabaseName { get; set; }
    public string DriveBaseName { get; set; }
    public string FolderBaseName { get; set; }

    public ApplicationSettings()
    {
      ServerName = "(Local)";
      DatabaseName = "Banking";
      DriveBaseName = @"%OneDrive%";
      FolderBaseName = @"\Documents";
    }
  }
}
