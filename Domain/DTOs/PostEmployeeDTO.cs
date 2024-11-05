using Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.DTOs
{
    public class PostEmployeeDTO
    {
        public required string FirstName { get; set; }

        public required string LastName { get; set; }

        public required string UserName { get; set; }

        public bool Active { get; set; }


        public static explicit operator Employee(PostEmployeeDTO postEmployeeDTO)
        {
            return new Employee
            {
                FirstName = postEmployeeDTO.FirstName,
                LastName = postEmployeeDTO.LastName,
                UserName = postEmployeeDTO.UserName,
                Active = postEmployeeDTO.Active
            };
        }

    }
}
