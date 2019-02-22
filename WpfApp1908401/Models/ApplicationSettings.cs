using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace WpfApp1908401.Models
{
  public class ApplicationSettings : INotifyPropertyChanged
  {
    private static bool changed = false;
    private static string serverName;
    private static string databaseName;
    private static string driveBaseName;
    private static string folderBaseName;
    private static string importOpenFolder;

    public string ServerName
    {
      get => serverName;
      set
      {
        if (serverName != value)
        {
          serverName = value;
          OnPropertyChanged("ServerName");
          changed = true;
        }
      }
    }

    public string DatabaseName
    {
      get => databaseName;
      set
      {
        if (databaseName != value)
        {
          databaseName = value;
          OnPropertyChanged("DatabaseName");
          changed = true;
        }
      }
    }

    public string DriveBaseName
    {
      get => driveBaseName;
      set
      {
        if (driveBaseName != value)
        {
          driveBaseName = value.Replace("System.Windows.Controls.ComboBoxItem: ", "");
          OnPropertyChanged("DriveBaseName");
          changed = true;
        }
      }
    }

    public string FolderBaseName
    {
      get => folderBaseName;
      set
      {
        if (folderBaseName != value)
        {
          folderBaseName = value;
          OnPropertyChanged("FolderBaseName");
          changed = true;
        }
      }
    }

    [JsonIgnore]
    public bool IsChanged
    {
      get => changed;
    }

    [JsonIgnore]
    public bool IsChangedAndReset
    {
      get
      {
        bool reset = changed;
        changed = false;
        return reset;
      }
    }

    [JsonIgnore]
    public string ExecutableFolder
    {
      get
      {
        return Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location);
      }
    }

    [JsonIgnore]
    public string ExecutableName
    {
      get
      {
        return Path.GetFileName(Assembly.GetExecutingAssembly().Location)
          .Replace(Path.GetExtension(Assembly.GetExecutingAssembly().Location), "");
      }
    }

    [JsonIgnore]
    public string ExecutableJsonFile
    {
      get
      {
        return $"{ExecutableFolder}\\{ExecutableName}.json";
      }
    }

    [JsonIgnore]
    public string ImportOpenFolder
    {
      get
      {
        if (DriveBaseName == "%OneDrive%")
        {
          importOpenFolder = Environment.GetEnvironmentVariable("OneDrive");
        }
        else
        {
          importOpenFolder = DriveBaseName;
        }

        return $"{importOpenFolder}\\{FolderBaseName}";
      }
    }

    public void Save()
    {
      string json = JsonConvert.SerializeObject(this, Formatting.Indented);
      using (StreamWriter stream = new StreamWriter(ExecutableJsonFile))
      {
        stream.Write(json);
      }
    }

    public ApplicationSettings()
    {
      ServerName = "(Local)";
      DatabaseName = "Banking";
      DriveBaseName = @"%OneDrive%";
      FolderBaseName = @"\Documents";

      changed = false;
    }

    public event PropertyChangedEventHandler PropertyChanged;
    protected void OnPropertyChanged(string propertyName) =>
      PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));

  }
}
