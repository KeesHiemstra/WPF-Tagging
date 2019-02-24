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
  }
}
