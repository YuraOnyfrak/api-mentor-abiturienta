using System;
using System.Collections.Generic;
using System.Text;
using MentorAbiturienta.DAL.Domain;

namespace MentorAbiturienta.BLL.DTO
{
    public class StudentDTO
    {        
        public int Id { get; set; }
        public string Firstname { get; set; }
        public string Lastname { get; set; }
        public bool IsNewUser { get; set; }
        public int? UniversityId { get; set; }
        public int? FacultyId { get; set; }
        public int? SpecialityByFacultyId { get; set; }
        public int? SpecializationId { get; set; }
        public int? CityId { get; set; }
        public int? Course { get; set; }
        public bool? CanHelp { get; set; }
        public string Username { get; set; }

        public StudentDTO(User user)
        {
            Id = user.Id;
            Firstname = user.Firstname;
            Lastname = user.Lastname;
            Username = user.Student?.TelegramUsername;
            IsNewUser = user.Student.CourseNumber == 0? true : false;
            UniversityId = user.Student?.UniversityId;
            FacultyId = user.Student?.FacultyId;
            SpecialityByFacultyId = user.Student?.SpecialityByFacultyId;
            SpecializationId = user.Student?.SpecializationId;
            Course = user.Student?.CourseNumber == 0? 1: user.Student?.CourseNumber;
            CanHelp = user.Student?.CanHelpWithDormitory;
            CityId = user.Student?.University?.CityId;
        }
    }
}
