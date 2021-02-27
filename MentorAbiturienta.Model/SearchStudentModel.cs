using System;
using System.Collections.Generic;
using System.Text;

namespace MentorAbiturienta.Model
{
    public class SearchStudentModel
    {
        public int UniversityId { get; set; }
        public int? FacultyId { get; set; }
        public int? SpecialityByFacultyId { get; set; }
        public int? SpecializationId { get; set; }
        //public int Course { get; set; }
        //public bool CanHelp { get; set; }
    }
}
