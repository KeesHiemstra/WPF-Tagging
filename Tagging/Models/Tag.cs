using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;

namespace Tagging.Models
{
  public class Tag : INotifyPropertyChanged
  {
    private DateTime _date;
    private string _tagId;
    private string _action;
    private string _subject;
    private string _description;

    public DateTime Date { get => _date; set => _date = value; }
    public string TagId
    {
      get => _tagId;
      set
      {
        if (_tagId != value)
        {
          _tagId = value;
          NotifyPropertyChanged("TagId");
        }
      }
    }
    public string Action { get => _action; set => _action = value; }
    public string Subject { get => _subject; set => _subject = value; }
    public string Description { get => _description; set => _description = value; }

    [JsonIgnore]
    public string WeekNo
    {
      get
      {
        if (string.IsNullOrEmpty(TagId) || TagId.Length < 5)
        {
          return string.Empty;
        }
        else
        {
          return TagId.Substring(0, 5);
        }
      }
    }

    [JsonIgnore]
    public int DayCount
    {
      get
      {
        if (string.IsNullOrEmpty(TagId) || TagId.Length < 7)
        {
          return 0;
        }
        else
        {
          if (int.TryParse(TagId.Substring(5, 2), out int result))
          {
            return result;
          }
          else
          {
            return 0;
          }
        }
      }
    }

    public event PropertyChangedEventHandler PropertyChanged;
    public void NotifyPropertyChanged(string propName)
    {
      if (this.PropertyChanged != null)
        this.PropertyChanged(this, new PropertyChangedEventArgs(propName));
    }
  }
}
