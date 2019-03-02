using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;

namespace Tagging.Models
{
  public class Tag
  {
    public DateTime Date { get; set; }
    public string TagId { get; set; }
    public string Action { get; set; }
    public string Subject { get; set; }
    public string Description { get; set; }

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

  }
}
