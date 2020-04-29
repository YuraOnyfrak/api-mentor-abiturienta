using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Formatters;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.OpenApi.Models;

namespace UniversityInfo
{
  public class Startup
  {
    public Startup(IConfiguration configuration)
    {
      Configuration = configuration;
    }

    public IConfiguration Configuration { get; }

    public void ConfigureServices(IServiceCollection services)
    {

      //services.AddMiniProfiler(options =>
      //{
      //  options.RouteBasePath = "/profiler";
      //});//.AddEntityFramework();

      services.AddSwaggerGen(c =>
      {
        c.SwaggerDoc("v1", new OpenApiInfo
        {
          Title = "UniversityInfo API",
          Version = "v1"
        });

        //if (hostingEnvironment.IsDevelopment())
        //  c.IncludeXmlComments(Path.Combine(System.AppContext.BaseDirectory, "Salykmaster.Api.xml"));
        //else
         c.IncludeXmlComments(Path.Combine(System.AppContext.BaseDirectory, "UniversityInfo.Api.xml"));

        c.CustomSchemaIds(x => x.FullName);
      });

      services.AddMvc(options => options.OutputFormatters.Add(new XmlSerializerOutputFormatter()));

      services
        .AddMvc()
        .AddJsonOptions(options =>
        {
          options.SerializerSettings.ReferenceLoopHandling = Newtonsoft.Json.ReferenceLoopHandling.Ignore;
          options.SerializerSettings.Converters.Add(new Newtonsoft.Json.Converters.StringEnumConverter());
          options.SerializerSettings.NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore;
          options.SerializerSettings.DateTimeZoneHandling = Newtonsoft.Json.DateTimeZoneHandling.Utc;
        });


      //services.Configure<StorageContextOptions>(options =>
      //{
      //  options.ConnectionString = connectionString;
      //  options.MigrationsAssembly = typeof(MigrationStorageContextFactory).GetTypeInfo().Assembly.FullName;
      //});
      
      services.AddCors(
        с => с.AddPolicy("ClientPolicy", builder => builder
         .WithOrigins("http://localhost:5000", "http://localhost:4200", "https://accountant.salykmaster.kz", "https://dev-accountant.salykmaster.kz",
                      "https://test-accountant.salykmaster.kz", "https://stage-accountant.salykmaster.kz", "https://testaccountant.z6.web.core.windows.net")
         .AllowAnyMethod()
         .AllowAnyHeader()
         .AllowCredentials()
         .WithExposedHeaders("Content-Disposition"))
         );
    }

    public void Configure(IApplicationBuilder app, IHostingEnvironment env)
    {
      app.UseCors("ClientPolicy");

      if (env.IsDevelopment())
      {
        app.UseDeveloperExceptionPage();
       // app.UseMiniProfiler();
      }


      app.UseSwagger(c =>
      {
        //c.RouteTemplate = "api-docs/{documentName}/swagger.json";
      });
      app.UseSwaggerUI(c =>
      {
        c.SwaggerEndpoint("/api-docs/v1/swagger.json", "UniversityInfo API V1");
       // c.IndexStream = () => GetType().GetTypeInfo().Assembly.GetManifestResourceStream("UniversityInfo.Swagger.Index.html");
      });

      app.UseAuthentication();

      if (env.IsDevelopment())
        app.Use(async (context, next) =>
        {
          if (context.Request.Path.Value == "/")
          {
            context.Response.Redirect("/swagger", true);
          }
          else await next();
        });

    }

  }
}

