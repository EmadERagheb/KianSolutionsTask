using Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Domain.DTOs
{
    public class GetEmployeeDTO
    {
        public int Id { get; set; }
        public required string FirstName { get; set; }

        public required string LastName { get; set; }

        public required string UserName { get; set; }

        public bool Active { get; set; }

        public static Expression<Func<Employee, GetEmployeeDTO>> Projection
        {
            get
            {
                return employee => new GetEmployeeDTO
                {
                    Id = employee.Id,
                    FirstName = employee.FirstName,
                    LastName = employee.LastName,
                    UserName = employee.UserName,
                    Active = employee.Active
                };

            }
        }
    }
}
