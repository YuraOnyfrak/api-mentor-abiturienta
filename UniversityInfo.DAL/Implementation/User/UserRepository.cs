using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MentorAbiturienta.DAL.Abstraction;
using MentorAbiturienta.DAL.Domain;
using MentorAbiturienta.DAL.DTO;
using MentorAbiturienta.Model;
using Microsoft.EntityFrameworkCore;

namespace MentorAbiturienta.DAL.Implementation
{
  public class UserRepository : GenericRepository<User>, IUserRepository
  {
        public UserRepository(IStorageContext context) : base(context)
        {
        }

        public User GetByPhone(string phoneNumber)
        {
          return null;//this.Context.Users.FirstOrDefault(s =>s.Phone.Equals(phoneNumber));
        }

        public bool IsExist(string phoneNumber)
        {
          return true;//this.Context.Users.Any(s => s.Phone.Equals(phoneNumber));
        }

        public async Task<IEnumerable<SearchStudentDto>> SearchAsync(SearchStudentModel searchStudentModel)
        {
            var query = this.Context.Students
                          .Include(s => s.Faculty)
                          .Include(s => s.University)
                          .Include(s => s.SpecialityByFaculty)
                          .ThenInclude(s => s.Speciality)
                          .Include(s => s.Specialization)
                          .Include(s => s)
                          .Where(s => s.UniversityId == searchStudentModel.UniversityId);

            if (searchStudentModel.FacultyId.HasValue)
            {
                query.Where(s => s.FacultyId == searchStudentModel.FacultyId);
            }

            if (searchStudentModel.SpecialityByFacultyId.HasValue)
            {
                query.Where(s => s.SpecialityByFacultyId == searchStudentModel.SpecialityByFacultyId);
            }

            if (searchStudentModel.SpecializationId.HasValue)
            {
                query.Where(s => s.SpecializationId == searchStudentModel.SpecializationId);
            }

            return await query.Select(s => new SearchStudentDto
            {
                Name = s.User.Firstname,
                University = s.University.Name
            })
            .ToListAsync();
        }
    }
}
