using System;
using System.Collections.Generic;
using System.Security.Claims;
using System.Threading.Tasks;
using MentorAbiturienta.BLL.Abstraction;
using MentorAbiturienta.BLL.DTO;
using MentorAbiturienta.DAL;
using MentorAbiturienta.DAL.Abstraction;
using MentorAbiturienta.DAL.Domain;
using MentorAbiturienta.Services.Abstractions;
using MentorAbiturienta.Shared;
using MentorAbiturienta.Shared.Exceptions;

namespace MentorAbiturienta.BLL.Implementation.Auth
{
  public class DefaultAccessDispatcher : IAccessDispatcher
  {
    private readonly IMemoryCacheService _memoryCache;
    private readonly IJwtService _jwtService;
    private readonly IRefreshTokenRepository _refreshTokenRepository;
    private readonly IStorage _storage;

    public DefaultAccessDispatcher
      (
      IMemoryCacheService memoryCache,
      IJwtService jwtService,
      IRefreshTokenRepository refreshTokenRepository,
      IStorage storage
      )
    {
      _memoryCache = memoryCache;
      _jwtService = jwtService;
      _refreshTokenRepository = refreshTokenRepository;
      _storage = storage;
    }

    public async Task<string> GenerateAccessTokenAsync(User user)
    {
      return _jwtService.Generate(await this.GetUserClaimsAsync(user));
    }

    public async Task<string> GenerateRefreshTokenAsync(int userId)
    {
      string token = new RefreshTokenGenerator().Generate();

      await _refreshTokenRepository.AddAsync(new RefreshToken
      {
        Id = token,
        Created = DateTime.UtcNow,
        UserId = userId
      });

      await _storage.SaveAsync();

      return token;
    }

    public ClaimsPrincipal Validate(string accessToken)
    {
      return _jwtService.Validate(accessToken);
    }

    private async Task<IEnumerable<Claim>> GetUserClaimsAsync(User user)
    {
      List<Claim> claims = new List<Claim>(); 
      claims.Add(new Claim(ClaimTypes.NameIdentifier, user.Id.ToString()));
      //claims.Add(new Claim(ClaimTypes.MobilePhone, user.Phone.ToString()));

      return claims;
    }

    public async Task<Token> ValidateRefreshTokenAsync(string refreshTokenId)
    {
      try
      {
        RefreshToken refreshToken = await _refreshTokenRepository.GetByIdAsync(refreshTokenId);

        if (refreshToken == null)
          throw new NotFoundException("refresh token not found");        

        Token token = new Token
        {
          Jwt = await GenerateAccessTokenAsync(refreshToken.User),
          Refresh = await GenerateRefreshTokenAsync(refreshToken.User.Id)
        };

        await _refreshTokenRepository.DeleteAsync(refreshToken.Id);
        _storage.Save();

        return token;

      }
      catch (Exception ex)
      {

        throw ex;
      }
    }
  }
}