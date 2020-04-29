using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using UniversityInfo.DAL.Domain;

namespace UniversityInfo.BLL.DTO
{
    public class CreatedStudentDTO
    {
        public int Id { get; set; }
        public string Firstname { get; set; }
        public string Lastname { get; set; }    
        public CreatedStudentDTO() { }

        public CreatedStudentDTO(User user)
        {
            Id = user.Id;
            Firstname = user.Firstname;
            Lastname = user.Lastname;
        }

    }
}
