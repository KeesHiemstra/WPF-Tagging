using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tagging.Models
{
  public enum TagActions
  {
    Action,
    Application,
    Archive
  }

  public class Tag
  {
    public DateTime Date { get; set; }
    public string TagId { get; set; }
    public TagActions Action { get; set; }
    public string Subject { get; set; }
    public string Description { get; set; }
  }
}
