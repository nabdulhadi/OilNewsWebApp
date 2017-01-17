using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

using OilNewsWebApp.Models;

namespace OilNewsWebApp.API
{
  [Route("api/[controller]")]
  public class MoviesController : Controller
  {
    ILogger<MoviesController> logger;
    private readonly MoviesAppContext dbContext;

    public MoviesController(MoviesAppContext dbContext, ILogger<MoviesController> logger)
    {
      this.dbContext = dbContext;
      this.logger = logger;
    }

    [HttpGet]
    public IEnumerable<Movie> Get()
    {
      return dbContext.Movies;
    }
    
    [HttpGet("{id:int}")]
    public IActionResult Get(int id)
    {
      var movie = dbContext.Movies.FirstOrDefault(m => m.Id == id);
      if (movie == null)
      {
        return new NotFoundResult();
      }
      else
      {
        return new ObjectResult(movie);
      }
    }
    
    [HttpPost]
    public IActionResult Post([FromBody]Movie movie)
    {
      if (movie.Id == 0)
      {
        dbContext.Movies.Add(movie);
        dbContext.SaveChanges();
        return new ObjectResult(movie);
      }
      else
      {
        var original = dbContext.Movies.FirstOrDefault(m => m.Id == movie.Id);
        original.Title = movie.Title;
        original.Director = movie.Director;
        dbContext.SaveChanges();
        return new ObjectResult(original);
      }
    }
    
    [HttpDelete("{id:int}")]
    public IActionResult Delete(int id)
    {
      var movie = dbContext.Movies.FirstOrDefault(m => m.Id == id);
      dbContext.Movies.Remove(movie);
      dbContext.SaveChanges();
      return new StatusCodeResult(200);
    }


  }

}
