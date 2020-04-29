using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using UniversityInfo.BLL.Abstraction;
using UniversityInfo.Model;

namespace UniversityInfo.Controllers
{
  [ApiController]
  [Route("api/[controller]")]
  public class EntrantController :  Controller
  {
    private readonly IEntrantService _entrantService;

    public EntrantController(IEntrantService entrantService)
    {
      _entrantService = entrantService;
    }    
  }
}
