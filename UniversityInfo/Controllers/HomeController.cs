using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using UniversityInfo.Models;

namespace UniversityInfo.Controllers
{
  [ApiController]
  public class HomeController : Controller
  {
    /// <summary>
    /// Test
    /// </summary>
    /// <returns></returns>
    [HttpGet]
    public IActionResult Index()
    {
      return View();
    }

    //public IActionResult Privacy()
    //{
    //  return View();
    //}

    //[ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
    //public IActionResult Error()
    //{
    //  return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
    //}
  }
}
