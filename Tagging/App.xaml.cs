using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
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
      //InitialRecord();
      //WriteJson();
    }

    private void InitialRecord()
    {
      Tags.Add(new Tag
      {
        Date = new DateTime(2019, 2, 24, 10, 03, 18),
        TagId = "1908701",
        Action = "Reference",
        Subject = "Test",
        Description = "Show the working"
      });
    }

    private void WriteJson()
    {
      string json = JsonConvert.SerializeObject(Tags, Formatting.Indented);
      using (StreamWriter stream = new StreamWriter(JsonFileName))
      {
        stream.Write(json);
      }
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
