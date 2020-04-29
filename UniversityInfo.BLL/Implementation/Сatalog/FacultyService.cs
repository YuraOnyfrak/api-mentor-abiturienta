﻿using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UniversityInfo.BLL.Abstraction;
using UniversityInfo.BLL.DTO.Catalog;
using UniversityInfo.DAL.Abstraction;

namespace UniversityInfo.BLL.Implementation
{
  public class FacultyService : IFacultyService
  {
    private readonly IFacultyRepository _facultyRepository;

    public FacultyService(IFacultyRepository facultyRepository)
    {
      _facultyRepository = facultyRepository;
    }

    public async Task<IEnumerable<IGrouping<char,FacultyDTO>>> GetByUniversityAsync(int universityId)
    {
      return (await _facultyRepository.Get()
        .Where(s => s.UniversityId == universityId)
        .OrderBy(s => s.Name)
        .ToListAsync())
        .Select(s => new FacultyDTO(s)).GroupBy(s=>s.Name.ToArray().First());
    }
  }
}
