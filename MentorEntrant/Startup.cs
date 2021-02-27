using System.Collections.Generic;
using System.IO;
using System.Text;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.IdentityModel.Tokens;
using Microsoft.OpenApi.Models;
using MentorAbiturienta.Action;
using MentorAbiturienta.DAL;
using MentorAbiturienta.Shared.Options;

namespace MentorAbiturienta
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
      services.AddControllers();

      services.Configure<SmsSenderOptions>(Configuration.GetSection(nameof(SmsSenderOptions)));
      services.Configure<JwtOptions>(Configuration.GetSection(nameof(JwtOptions)));

      // services.AddMvc();

      string connectionString = Configuration.GetConnectionString("DefaultConnection");

      services.Configure<StorageContextOptions>(options =>
      {
        options.ConnectionString = connectionString;
      });

      services.AddDbContext<MentorAbiturientaContext>(options => options.UseSqlServer(connectionString));

      // Register the Swagger generator, defining 1 or more Swagger documents
      services.AddSwaggerGen(c =>
      {
        c.SwaggerDoc("v1", new OpenApiInfo
        {
          Title = "MentorAbiturienta API",
          Version = "v1"
        });

        c.AddSecurityDefinition("Bearer", new OpenApiSecurityScheme
        {
          In = ParameterLocation.Header,
          Description = "Please enter JWT with Bearer into field",
          Name = "Authorization",
          Type = SecuritySchemeType.ApiKey
        });

        c.AddSecurityRequirement(new OpenApiSecurityRequirement
        {
            {
                new OpenApiSecurityScheme
                {
                    Reference = new OpenApiReference { Type = ReferenceType.SecurityScheme, Id = "Bearer" }
                },
                new List<string>()
            }
        });

        //if (hostingEnvironment.IsDevelopment())
        // c.IncludeXmlComments(Path.Combine(System.AppContext.BaseDirectory, "MentorAbiturienta.Api.xml"));

        // else
        c.IncludeXmlComments(Path.Combine(System.AppContext.BaseDirectory, "MentorAbiturienta.xml"));

        c.CustomSchemaIds(x => x.FullName);
      });

      //services.AddMvc(options => options.OutputFormatters.Add(new XmlSerializerOutputFormatter()));
      string securityKey = "essXKYFUbXHVTMXT4PFkLMYvX5fbb3szfxnfnQyLfrNPpXfTX9KZcBZCz4ckxQaK";// services.GetService<IOptions<JwtOptions>>().Value.SecurityKey;

      services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme)
        .AddJwtBearer(JwtBearerDefaults.AuthenticationScheme, o =>
        {
          o.TokenValidationParameters = new TokenValidationParameters
          {
            ValidateAudience = false,
            ValidateIssuer = false,
            IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(securityKey))
          };
        }
      );

      //services.mv MvcOptions.EnableEndpointRouting = false;

      services
        .AddMvc()
        .AddJsonOptions(options =>
        {
          //options.SerializerSettings.ReferenceLoopHandling = Newtonsoft.Json.ReferenceLoopHandling.Ignore;
          //options.SerializerSettings.Converters.Add(new Newtonsoft.Json.Converters.StringEnumConverter());
          //options.SerializerSettings.NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore;
          //options.SerializerSettings.DateTimeZoneHandling = Newtonsoft.Json.DateTimeZoneHandling.Utc;
        });

      services.AddCors(
       ñ => ñ.AddPolicy("ClientPolicy", builder => builder
        .WithOrigins("http://localhost:65168", "http://localhost:4200", 
        "https://mentor-abiturient.imfast.io", "https://api-mentor-abiturienta.ck.ua", "https://mentor-abiturienta.imfast.io")
        .AllowAnyMethod()
        .AllowAnyHeader()
        .AllowCredentials()
        .WithExposedHeaders("Content-Disposition"))
        );


      DIManager.Register(services);
    }

    // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
    public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
    {
      //if (env.IsDevelopment())
      {
        app.UseDeveloperExceptionPage();
      }


      app.UseHttpsRedirection();

      app.UseRouting();

      app.UseCors("ClientPolicy");
      // Enable middleware to serve generated Swagger as a JSON endpoint.
      app.UseSwagger();

      // Enable middleware to serve swagger-ui (HTML, JS, CSS, etc.),
      // specifying the Swagger JSON endpoint.
      app.UseSwaggerUI(c =>
      {
        c.SwaggerEndpoint("/swagger/v1/swagger.json", "My API V1");
      });

      //if (env.IsDevelopment())
      app.Use(async (context, next) =>
      {
        if (context.Request.Path.Value == "/")
        {
          context.Response.Redirect("/swagger", true);
        }
        else await next();
      });


      app.UseAuthorization();

      app.UseEndpoints(endpoints =>
      {
        endpoints.MapControllers();
      });


    }
  }
}
