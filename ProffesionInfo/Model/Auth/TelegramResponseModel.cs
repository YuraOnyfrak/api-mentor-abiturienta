﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using UniversityInfo.BLL.DTO;

namespace UniversityInfo.Model
{
  public class TelegramResponseModel
  {
    public string Id { get; set; }
    public string First_name { get; set; }
    public string Last_name { get; set; }
    public string username { get; set; }
    public string photo_url { get; set; }
    public string auth_date { get; set; }
    public string hash { get; set; }

    public CreateStudentDTO Map()
      => new CreateStudentDTO()
      {
        Firstname = this.First_name,
        Lastname = this.Last_name,
        TelegramId = this.Id,
        TelegramPhotoUrl = this.photo_url,
        TelegramUsername = this.username
      };
  }
}
