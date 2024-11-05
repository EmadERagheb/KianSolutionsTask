using Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.DTOs
{
    public class PutEmployeeDTO
    {
        public int Id { get; set; }
        public required string FirstName { get; set; }

        public required string LastName { get; set; }

        public required string UserName { get; set; }

        public bool Active { get; set; }

        public static explicit operator Employee(PutEmployeeDTO putEmployeeDTO)
        {
            return new Employee
            {
                Id = putEmployeeDTO.Id,
                FirstName = putEmployeeDTO.FirstName,
                LastName = putEmployeeDTO.LastName,
                UserName = putEmployeeDTO.UserName,
                Active = putEmployeeDTO.Active
            };
        }
    }
}
