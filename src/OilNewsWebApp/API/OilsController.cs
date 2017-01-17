using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Text;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Newtonsoft.Json.Linq;
using Newtonsoft.Json;
using OilNewsWebApp.Models;

namespace OilNewsWebApp.API
{
  [Route("api/[controller]")]
  public class OilsController : Controller
  {
    ILogger<OilsController> logger;
    private readonly OilsAppContext dbContext;

    public OilsController(OilsAppContext dbContext, ILogger<OilsController> logger)
    {
      this.dbContext = dbContext;
      this.logger = logger;
    }

    // GET: api/oils
    [HttpGet]
    public IEnumerable<Oil> Get()
    {
      return this.dbContext.Oils.OrderByDescending(o => o.Timestamp).Take(50);
    }

    // GET api/oils/5
    [HttpGet("{id}")]
    public IActionResult Get(int id)
    {
      var movie = dbContext.Oils.FirstOrDefault(m => m.Id == id);
      if (movie == null)
      {
        return new NotFoundResult();
      }
      else
      {
        return new ObjectResult(movie);
      }
    }

    // PUT api/oils
    [HttpPut]
    public IActionResult Put([FromBody] JObject oil)
    {
      var original = dbContext.Oils.FirstOrDefault(o => o.Id.ToString() == oil["id"].ToString());
      original.Description = oil["description"].ToString();
      string raw = JsonConvert.SerializeObject(oil["raw"], Formatting.Indented);
      original.Raw = raw;
      original.Timestamp = DateTime.Now;
      dbContext.SaveChanges();
      return new ObjectResult(original);
    }

    // POST api/oils
    [HttpPost]
    public IActionResult Post([FromBody] JObject data)
    {
      string raw = JsonConvert.SerializeObject(data["raw"], Formatting.Indented);
      Oil oil = new Oil{ Description = data["description"].ToString(), Raw = raw, Timestamp = DateTime.Now };

      dbContext.Oils.Add(oil);
      dbContext.SaveChanges();
      return new ObjectResult(oil);
    }

    // DELETE api/oils/5
    [HttpDelete("{id}")]
    public IActionResult Delete(int id)
    {
      var oil = dbContext.Oils.FirstOrDefault(o => o.Id == id);
      dbContext.Oils.Remove(oil);
      dbContext.SaveChanges();
      return new StatusCodeResult(200);
    }
  }
}
