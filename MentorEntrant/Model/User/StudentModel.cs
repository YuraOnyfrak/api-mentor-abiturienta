using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using UniversityInfo.BLL.DTO;

namespace MentorEntrant.Model
{
    public class StudentModel
    {
        public int Id { get; set; }
        public string Firstname { get; set; }
        public string Lastname { get; set; }
        public string Username { get; set; }
        public bool IsNewUser { get; set; }
        public int? UniversityId { get; set; }
        public int? FacultyId { get; set; }
        public int? SpecialityByFacultyId { get; set; }
        public int? SpecializationId { get; set; }
        public int? CityId { get; set; }
        public int? Course { get; set; }
        public bool? CanHelp { get; set; }

        public StudentModel(StudentDTO studentDTO)
        {
            Id = studentDTO.Id;
            Firstname = studentDTO.Firstname;
            Lastname = studentDTO.Lastname;
            Username = studentDTO.Username;
            IsNewUser = studentDTO.IsNewUser;
            UniversityId = studentDTO.UniversityId;
            FacultyId = studentDTO.FacultyId;
            SpecialityByFacultyId = studentDTO.SpecialityByFacultyId;
            SpecializationId = studentDTO.SpecializationId;
            Course = studentDTO.Course;
            CanHelp = studentDTO.CanHelp;
            CityId = studentDTO.CityId;
        }
    }
}
