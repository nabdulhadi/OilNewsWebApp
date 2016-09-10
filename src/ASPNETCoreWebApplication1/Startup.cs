using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using Microsoft.EntityFrameworkCore;
using ASPNETCoreWebApplication1.Models;

namespace ASPNETCoreWebApplication1
{
  public class Startup
  {
    public Startup(IHostingEnvironment env)
    {
      var builder = new ConfigurationBuilder()
          .SetBasePath(env.ContentRootPath)
          .AddJsonFile("appsettings.json", optional: true, reloadOnChange: true)
          .AddJsonFile($"appsettings.{env.EnvironmentName}.json", optional: true);

      if (env.IsDevelopment())
      {
        builder.AddUserSecrets();
      }

      builder.AddEnvironmentVariables();
      Configuration = builder.Build();
    }

    public IConfigurationRoot Configuration { get; }

    public void ConfigureServices(IServiceCollection services)
    {
      services.AddDbContext<OilsAppContext>(options =>
        options.UseSqlServer(Configuration.GetConnectionString("DefaultConnection"))
       );

      services.AddDbContext<MoviesAppContext>(options =>
        options.UseSqlServer(Configuration.GetConnectionString("DefaultConnection"))
       );

      services.AddLogging();
      services.AddMvc();
    }

    public void Configure(IApplicationBuilder app, IHostingEnvironment env, ILoggerFactory loggerFactory)
    {
      loggerFactory.AddConsole(Configuration.GetSection("Logging"));
      loggerFactory.AddDebug();

      if (env.IsDevelopment())
      {
        app.UseDeveloperExceptionPage();
        //app.UseBrowserLink();
      }
      else
      {
        app.UseExceptionHandler("/Error");
      }

      app.UseStaticFiles();

      app.UseMvc();

      app.Use(async (context, next) =>
      {
        await next();

        // Rewrite request to use app root
        if (context.Response.StatusCode == 404 && !Path.HasExtension(context.Request.Path.Value))
        {
          context.Request.Path = "/index.html";
          await next();
        }
      });

      // Serve wwwroot as root
      app.UseFileServer();
    }
  }
}
