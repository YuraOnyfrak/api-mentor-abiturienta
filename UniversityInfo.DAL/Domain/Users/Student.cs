using System.Collections.Generic;
using MentorAbiturienta.DAL.Domain.Common;
using MentorAbiturienta.Shared.Enums;

namespace MentorAbiturienta.DAL.Domain
{
  public class Student : Identifiable
  {
    public int Id { get; set; }
    public string TelegramId { get; set; }   
    public string TelegramUsername { get; set; }
    public string TelegramPhotoUrl { get; set; }
    public string InstagramLink { get; set; }    

    public int? UniversityId { get; set; }
    public int? FacultyId { get; set; }
    public int? SpecialityByFacultyId { get; set; }
    public int? SpecializationId { get; set; }
    public int CourseNumber { get; set; }
    public bool CanHelpWithDormitory { get; set; }

    public University University { get; set; }
    public Faculty Faculty { get; set; }
    public SpecialityByFaculty SpecialityByFaculty { get; set; }
    public Specialization Specialization { get; set; }
    public User User { get; set; }
  }
}
