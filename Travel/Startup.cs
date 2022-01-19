using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.EntityFrameworkCore;
using Microsoft.OpenApi.Models;
using Travel.Models;
using System;

namespace Travel
{
  public class Startup
  {
    public Startup(IConfiguration configuration)
    {
      Configuration = configuration;
    }

    public IConfiguration Configuration { get; }

    // This method gets called by the runtime. Use this method to add services to the container.
    public void ConfigureServices(IServiceCollection services)
    {

      services.AddDbContext<TravelContext>(opt =>
          opt.UseMySql(Configuration["ConnectionStrings:DefaultConnection"], ServerVersion.AutoDetect(Configuration["ConnectionStrings:DefaultConnection"])));
      services.AddControllers();


      //swagger
      services.AddSwaggerGen(options =>
      {
        options.SwaggerDoc("v1", new OpenApiInfo
        {
          Version = "v1",
          Title = "Travel",
          Description = "An ASP.NET Core Web API for managing Travel items",
          TermsOfService = new Uri("https://example.com/terms"),
          Contact = new OpenApiContact
          {
            Name = "AlbertJeff",
            Url = new Uri("https://example.com/contact")
          },
          License = new OpenApiLicense
          {
            Name = "new OpenAPILicense",
            Url = new Uri("https://example.com/license")
          }
        });
      });
    }

    // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
    public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
    {
      if (env.IsDevelopment())
      {
        app.UseDeveloperExceptionPage();
      }

      // app.UseHttpsRedirection();
      app.UseSwagger();

      app.UseSwaggerUI(options =>
      {
        options.SwaggerEndpoint("/swagger/v1/swagger.json", "v1");
        options.RoutePrefix = string.Empty;
      });

      app.UseRouting();

      app.UseAuthorization();

      app.UseEndpoints(endpoints =>
      {
        endpoints.MapControllers();
      });
    }
  }
}