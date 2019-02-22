﻿using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using System.Windows;
using WpfApp1908401.Models;

namespace WpfApp1908401
{
  /// <summary>
  /// Interaction logic for App.xaml
  /// </summary>
  public partial class App : Application
  {
    public static ApplicationSettings Settings { get; set; } = new ApplicationSettings();

    public App()
    {
      UpdateSettingsFromJson();
    }

    private void UpdateSettingsFromJson()
    {
      ApplicationSettings json = new ApplicationSettings();

      if (!Directory.Exists(json.ExecutableFolder))
      {
        return;
      }

      if (!File.Exists(json.ExecutableJsonFile))
      {
        return;
      }

      //Import the json
      using (StreamReader sr = File.OpenText(json.ExecutableJsonFile))
      {
        string jsonFile = sr.ReadToEnd();
        json = JsonConvert.DeserializeObject<ApplicationSettings>(jsonFile);
      }

      if (!string.IsNullOrEmpty(json.ServerName) && json.ServerName != App.Settings.ServerName)
      {
        App.Settings.ServerName = json.ServerName;
      }
      if (!string.IsNullOrEmpty(json.DatabaseName) && json.DatabaseName != App.Settings.DatabaseName)
      {
        App.Settings.DatabaseName = json.DatabaseName;
      }
      if (!string.IsNullOrEmpty(json.DriveBaseName) && json.DriveBaseName != App.Settings.DriveBaseName)
      {
        App.Settings.DriveBaseName = json.DriveBaseName;
      }
      if (!string.IsNullOrEmpty(json.FolderBaseName) && json.FolderBaseName != App.Settings.FolderBaseName)
      {
        App.Settings.FolderBaseName = json.FolderBaseName;
      }
    }
  }
}
