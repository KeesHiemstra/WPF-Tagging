using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Configuration;
using System.Data;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using System.Windows;
using Tagging.Models;

namespace Tagging
{
  /// <summary>
  /// Interaction logic for App.xaml
  /// </summary>
  public partial class App : Application
  {
    private static string JsonFileName = @"%OneDrive%\Data\Tagging.json";
    public static ObservableCollection<Tag> Tags { get; set; } = new ObservableCollection<Tag>();

    public App()
    {
      string oneDrive = Environment.GetEnvironmentVariable("OneDrive");
      JsonFileName = JsonFileName.Replace("%OneDrive%", oneDrive);

      ReadJson();
    }

    private void ReadJson()
    {
      if (!File.Exists(JsonFileName))
      {
        return;
      }

      //Import tags
      using (StreamReader sr = File.OpenText(JsonFileName))
      {
        string jsonFile = sr.ReadToEnd();
        Tags = JsonConvert.DeserializeObject<ObservableCollection<Tag>>(jsonFile);
      }

    }
  }
}
