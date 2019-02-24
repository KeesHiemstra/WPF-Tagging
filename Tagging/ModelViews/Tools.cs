using CHiDateTimeWeekNumber;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tagging.ModelViews
{
  public class TagIdToDate
  {
    public string CalculateTagIdToDate(string tagId)
    {
      DateTime? result = DateTime.Now;

      if (String.IsNullOrEmpty(tagId) || tagId.Length < 5)
      {
        return "n/a";
      }

      result = DateTimeWeekNumber.WeekNoCompactToDate(tagId);

      if (result == null)
      {
        return "Error";
      }

      return result.Value.ToString("yyyy-MM-dd");
    }
  }
}
