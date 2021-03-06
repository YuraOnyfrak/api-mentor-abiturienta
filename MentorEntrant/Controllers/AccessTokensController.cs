﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using MentorAbiturienta.BLL.Abstraction;
using MentorAbiturienta.BLL.Abstraction.Auth;
using MentorAbiturienta.BLL.DTO;
using MentorAbiturienta.DAL;
using MentorAbiturienta.DAL.Abstraction;
using MentorAbiturienta.DAL.Abstraction.Auth;
using MentorAbiturienta.DAL.Domain;
using MentorAbiturienta.Model;

namespace MentorAbiturienta.Controllers
{
  [AllowAnonymous]
  [Route("api/v1/accesstokens")]
  public class AccessTokensController : Controller
  {
    private readonly IAccessDispatcher _accessDispatcher;
    private readonly IValidationTicketRepository _validationTicketRepository;
    private readonly IStudentService _studentService;

    public AccessTokensController
      (
      IAccessDispatcher accessDispatcher,
      IValidationTicketRepository validationTicketRepository,
      IStudentService studentService
      )
    {
      _accessDispatcher = accessDispatcher;
      _validationTicketRepository = validationTicketRepository;
      _studentService = studentService;
    }    

    /// <summary>
    /// Обновить токен по рефрешу
    /// </summary>
    /// <param name="refreshTokenCheck">accessToken</param>   
    [HttpPut("refresh-token")]    
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    public async Task<Token> ValidateRefreshTokenAsync([FromBody]RefreshTokenCheckModel refreshTokenCheck)
    {
      return await _accessDispatcher.ValidateRefreshTokenAsync(refreshTokenCheck.RefreshToken);
    }   

    [HttpPost("telegram-authentication")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    public  async Task<ActionResult> TelegramAuthenticationAsync([FromBody]TelegramResponseModel model)
    {
      var student =  await _studentService.CreateAsync(model.Map());

      if (student is null)
        return  new BadRequestResult();

      CreatedStudentModel createdStudent = new CreatedStudentModel(student);

      return Json(new Token
      {
        Jwt = await _accessDispatcher.GenerateAccessTokenAsync(new User() { Id = createdStudent.Id }),
        Refresh = await _accessDispatcher.GenerateRefreshTokenAsync(createdStudent.Id)
      });
    }
  }
}