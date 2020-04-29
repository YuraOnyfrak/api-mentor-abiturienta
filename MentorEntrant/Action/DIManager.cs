using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.DependencyInjection;
using UniversityInfo.BLL.Abstraction;
using UniversityInfo.BLL.Abstraction.Auth;
using UniversityInfo.BLL.Implementation;
using UniversityInfo.BLL.Implementation.Auth;
using UniversityInfo.BLL.Implementation.Common;
using UniversityInfo.DAL;
using UniversityInfo.DAL.Abstraction;
using UniversityInfo.DAL.Abstraction.Auth;
using UniversityInfo.DAL.Implementation;
using UniversityInfo.DAL.Implementation.Auth;
using UniversityInfo.Services.Abstractions;
using UniversityInfo.Services.Concrete;

namespace UniversityInfo.Action
{
  public static class DIManager
  {
    public static void Register(IServiceCollection services)
    {
      services.AddScoped<IStorage, Storage>();
      services.AddScoped<IStorageContext, UniversityInfoContext>();

      services.AddScoped<IUserRepository, UserRepository>();
      services.AddScoped<IValidationTicketRepository, ValidationTicketRepository>();
      services.AddScoped<ICityRepository, CityRepository>();
      services.AddScoped<IUniversityRepository, UniversityRepository>();
      services.AddScoped<IFacultyRepository, FacultyRepository>();
      services.AddScoped<ISpecialityRepository, SpecialityRepository>();
      services.AddScoped<ISpecializationRepository, SpecializationRepository>();
      services.AddScoped<IUserRepository, UserRepository>();
      services.AddScoped<IValidationTicketRepository, ValidationTicketRepository>();
      services.AddScoped<IRefreshTokenRepository, RefreshTokenRepository>();

      services.AddScoped<IAccessTokensService, AccessTokensService>();
      services.AddScoped<ISmsSender, DefaultSmsSender>();
      services.AddScoped<IEntrantService, EntrantService>();
      services.AddScoped<IStudentService, StudentService>();
      services.AddScoped<ICityService, CityService>();
      services.AddScoped<IUniversityService, UniversityService>();
      services.AddScoped<IFacultyService, FacultyService>();
      services.AddScoped<ISpecialityService, SpecialityService>();
      services.AddScoped<ISpecializationService, SpecializationService>();
      services.AddScoped<IAccessDispatcher, DefaultAccessDispatcher>();
      services.AddSingleton<IMemoryCacheService, MemoryCacheService>();
      services.AddScoped<IJwtService, JwtService>();
      services.AddScoped<IAccessProvider, AccessProvider>();
      services.AddSingleton<IHttpContextAccessor, HttpContextAccessor>();

    }
  }
}
