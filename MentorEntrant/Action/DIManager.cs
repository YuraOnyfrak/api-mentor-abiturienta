using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.DependencyInjection;
using MentorAbiturienta.BLL.Abstraction;
using MentorAbiturienta.BLL.Abstraction.Auth;
using MentorAbiturienta.BLL.Implementation;
using MentorAbiturienta.BLL.Implementation.Auth;
using MentorAbiturienta.BLL.Implementation.Common;
using MentorAbiturienta.DAL;
using MentorAbiturienta.DAL.Abstraction;
using MentorAbiturienta.DAL.Abstraction.Auth;
using MentorAbiturienta.DAL.Implementation;
using MentorAbiturienta.DAL.Implementation.Auth;
using MentorAbiturienta.Services.Abstractions;
using MentorAbiturienta.Services.Concrete;

namespace MentorAbiturienta.Action
{
  public static class DIManager
  {
    public static void Register(IServiceCollection services)
    {
      services.AddScoped<IStorage, Storage>();
      services.AddScoped<IStorageContext, MentorAbiturientaContext>();

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
