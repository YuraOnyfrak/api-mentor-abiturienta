﻿using Microsoft.AspNetCore.Hosting;
using System;
using System.Collections.Generic;
using System.Text;
using UniversityInfo.BLL.Abstraction;
using UniversityInfo.BLL.Abstraction.Auth;
using UniversityInfo.DAL;
using UniversityInfo.DAL.Abstraction;
using UniversityInfo.DAL.Abstraction.Auth;
using UniversityInfo.DAL.Domain;
using UniversityInfo.Shared;

namespace UniversityInfo.BLL.Implementation.Auth
{
  public class AccessTokensService : IAccessTokensService
  {
    private readonly IValidationTicketRepository _validationTicketRepository;
    private readonly IHostingEnvironment _hostingEnvironment;
    private readonly ISmsSender _smsSender;
    private readonly IUserRepository _userRepository;
    private readonly IStorage _storage;

    public AccessTokensService
      (
      IValidationTicketRepository validationTicketRepository,
      IHostingEnvironment hostingEnvironment,
      ISmsSender smsSender,
      IUserRepository userRepository,
      IStorage storage
      )
    {
      _validationTicketRepository = validationTicketRepository;
      _hostingEnvironment = hostingEnvironment;
      _smsSender = smsSender;
      _userRepository = userRepository;
      _storage = storage;
    }
    
    public Guid GenerateValidationTicket(string phoneNumber, string IpAddress)
    {
      User user = _userRepository.GetByPhone(phoneNumber);      

      return GenerateValidationTicket(phoneNumber, IpAddress, user);
    }

    private Guid GenerateValidationTicket(string phoneNumber, string IpAddress, User user)
    {
     /// IValidationTicketRepository validationTicketRepository = _storage.IValidationTicketRepository>();


      if (_validationTicketRepository.IsExistByPhoneNumber(phoneNumber, out ValidationTicket oldTicket))
        _validationTicketRepository.DeleteAsync(oldTicket.Id);

      ValidationTicket ticket = new ValidationTicket
      {
        Created = DateTime.UtcNow,
        Pin = GeneratePin(),
        IpAddress = IpAddress,
        PhoneNumber = phoneNumber
      };

      if (user != null)
      {
        if (ChangedUsersList.ChangedUsers.ContainsThreadSafe(user.Id))
          ChangedUsersList.ChangedUsers.RemoveThreadSafe(user.Id);
      }

      _validationTicketRepository.AddAsync(ticket);
      _storage.SaveAsync();

      // if (_hostingEnvironment.IsProduction() || _hostingEnvironment.IsStaging())
      //{
       var result = _smsSender.SendSms(phoneNumber, $"Код подтверждения: {1}");// { ticket.Pin}");
      // }

      // return result.ToString();

      return ticket.Id;
    }

    private string GeneratePin()
    {
      if (_hostingEnvironment.IsProduction() || _hostingEnvironment.IsStaging())
        return new Random().Next(0000, 9999).ToString("0000");
      else
        return "1234";
    }

  }
}
