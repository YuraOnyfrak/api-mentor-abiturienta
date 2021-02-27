using Microsoft.EntityFrameworkCore;
using System.Linq;
using System.Threading.Tasks;
using MentorAbiturienta.BLL.Abstraction;
using MentorAbiturienta.BLL.Abstraction.Auth;
using MentorAbiturienta.BLL.DTO;
using MentorAbiturienta.DAL;
using MentorAbiturienta.DAL.Abstraction;
using MentorAbiturienta.DAL.Domain;
using MentorAbiturienta.Shared.Exceptions;
using MentorAbiturienta.Model;
using System.Collections.Generic;

namespace MentorAbiturienta.BLL.Implementation
{
  public class StudentService : IStudentService
  {
    private readonly IStorage _storage;
    private readonly IUserRepository _userRepository;
    private readonly IAccessProvider _accessProvider;

        public StudentService
          (
          IStorage storage,
          IUserRepository userRepository,
          IAccessProvider accessProvider
          )
        {
          _storage = storage;
          _userRepository = userRepository;
          _accessProvider = accessProvider;
        }

        public async Task<CreatedStudentDTO> CreateAsync(CreateStudentDTO student)
        {
          User user = _userRepository.Get().Include(s => s.Student)
                          .FirstOrDefault(s => s.Student.TelegramId == student.TelegramId);

          if (user is null)
          {
            user = new User()
            {
              Firstname = student.Firstname,
              Lastname = student.Lastname,
              Student = new Student
              {
                TelegramId = student.TelegramId,
                TelegramPhotoUrl = student.TelegramPhotoUrl,
                TelegramUsername = student.TelegramUsername
              }
            };

            await _userRepository.AddAsync(user);
            await _storage.SaveAsync();
          }

          return new CreatedStudentDTO(user);
        }

        public async Task<StudentDTO> GetAsync()
        {
            if (!_accessProvider.CurrentUserId.HasValue)
                throw new ForbiddenException($"The current user doesn't access for document.");

            User user = _userRepository.Get(_accessProvider.CurrentUserId.Value)
                              .Include(s => s.Student)
                                .ThenInclude(s=>s.University)
                              .FirstOrDefault(s => s.Id == _accessProvider.CurrentUserId.Value);

            return new StudentDTO(user);
        }

        public async Task<StudentDTO> SearchAsync(SearchStudentModel searchStudentModel)
        {
            IEnumerable<User> user =  await _userRepository.SearchAsync(searchStudentModel);

            return new StudentDTO(user.First());
        }

        public async Task<CreatedStudentDTO> UpdateAsync(UpdateStudentDTO student)
        {
              if (!_accessProvider.CurrentUserId.HasValue)
                throw new ForbiddenException($"The current user doesn't access for document.");

              User user =  _userRepository.Get(_accessProvider.CurrentUserId.Value)
                              .Include(s=>s.Student)
                              .FirstOrDefault(s =>s.Id == _accessProvider.CurrentUserId.Value);

              if (user is null)
                throw new NotFoundException($"User with {_accessProvider.CurrentUserId.Value} dont found");

              user.Firstname = student.Name;
              user.Lastname = student.Lastname;
              user.Student.FacultyId = student.FacultyId;
              user.Student.SpecialityByFacultyId = student.SpecialityByFacultyId;
              user.Student.SpecializationId = student.SpecializationId;
              user.Student.UniversityId = student.UniversityId;
              user.Student.CanHelpWithDormitory = student.CanHelp;
              user.Student.CourseNumber = student.Course;
              _userRepository.Update(user);
              await _storage.SaveAsync();

              return new CreatedStudentDTO(user);
        }
  }
}