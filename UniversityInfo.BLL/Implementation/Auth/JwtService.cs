using Microsoft.Extensions.Options;
using System;
using System.Collections.Generic;
using System.Text;
using MentorAbiturienta.BLL.Abstraction;
using MentorAbiturienta.Shared.Options;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System.Security.Claims;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;

namespace MentorAbiturienta.BLL.Implementation.Auth
{
  public class JwtService : IJwtService
  {
    private readonly JwtOptions _options;
    public JwtService(IOptions<JwtOptions> options)
    {
      this._options = options.Value;
    }

    public string Generate(IEnumerable<Claim> claims)
    {
      SigningCredentials signingCredentials = new SigningCredentials(this.CreateSecurityKey(), SecurityAlgorithms.HmacSha256);
      JwtSecurityToken jwt = new JwtSecurityToken(
        claims: claims,
        expires: DateTime.Now.AddMinutes(GetExpireTimeInMinutes()),
        signingCredentials: signingCredentials
      );

      return new JwtSecurityTokenHandler().WriteToken(jwt);
    }

    public ClaimsPrincipal Validate(string accessToken)
    {
      TokenValidationParameters tokenValidationParameters = new TokenValidationParameters
      {
        ValidateAudience = false,
        ValidateIssuer = false,
        IssuerSigningKey = this.CreateSecurityKey()
      };
      return new JwtSecurityTokenHandler().ValidateToken(
        accessToken, tokenValidationParameters, out _
      );
    }

    public SecurityKey CreateSecurityKey()
    {
      return new SymmetricSecurityKey(Encoding.ASCII.GetBytes(GetSecret()));
    }

    private string GetSecret()
    {
      return _options.SecurityKey;
    }

    private int GetExpireTimeInMinutes()
    {
      return _options.ExpiresInMinutes;
    }
  }

}
