using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.EntityFrameworkCore;
using StarterKit.Services;
using Microsoft.Extensions.Configuration;
using StarterKit.Data;

namespace StarterKit
{

  public class Startup
  {

    public Startup(IConfiguration configuration)
    {
      Configuration = configuration;
    }

    public IConfiguration Configuration { get; }

    readonly string MyAllowSpecificOrigins = "_myAllowSpecificOrigins";
    // This method gets called by the runtime. Use this method to add services to the container.
    // For more information on how to configure your application, visit https://go.microsoft.com/fwlink/?LinkID=398940
    public void ConfigureServices(IServiceCollection services)
    {
      services.AddMvc().SetCompatibilityVersion(CompatibilityVersion.Version_2_1);
      var connetion = "Server=LocalHost\\SQLEXPRESS;Database=SampleDB;User Id=sa;password=Illusion02;Trusted_Connection=False;MultipleActiveResultSets=true;";
      services.AddDbContext<SampleItemData>(option => option.UseSqlServer(connetion));
      services.AddTransient<ISampleServices, SampleServices>();
    }

    // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
    public void Configure(IApplicationBuilder app, IHostingEnvironment env)
    {
      if (env.IsDevelopment())
      {
        app.UseDeveloperExceptionPage();
      }
      else
      {
        app.UseHsts();
      }

      app.UseCors(builder => builder
          .AllowAnyOrigin()
          .AllowAnyMethod()
          .AllowAnyHeader()
          .AllowCredentials());
      app.UseHttpsRedirection();
      app.UseMvc();
    }
  }
}
