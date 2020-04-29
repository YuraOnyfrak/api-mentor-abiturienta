﻿using System;
using System.Collections.Generic;
using System.Text;
using UniversityInfo.DAL.Abstraction;
using UniversityInfo.DAL.Domain;

namespace UniversityInfo.DAL.Implementation
{
  public class FacultyRepository : GenericRepository<Faculty>, IFacultyRepository
  {
    public FacultyRepository(IStorageContext context) : base(context)
    {
    }
  }
}
