using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ASPNETCoreWebApplication1.Models
{
  public class Oil
  {
    public int Id { get; set; }

    public string Description { get; set; }

    public string Raw { get; set; }

    public DateTime Timestamp { get; set; }
  }
}
