using System.Collections.Generic;
using System.Threading.Tasks;
using MentorAbiturienta.DAL.Domain;
using MentorAbiturienta.DAL.DTO;
using MentorAbiturienta.Model;

namespace MentorAbiturienta.DAL.Abstraction
{
    public interface IUserRepository : IGenericRepository<User>, IRepository
  {
        User GetByPhone(string phoneNumber);
        bool IsExist(string phoneNumber);
        Task<IEnumerable<SearchStudentDto>> SearchAsync(SearchStudentModel searchStudentModel);
    }
}
