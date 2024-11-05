using Data.Contracts;
using Data.DbContexts;
using Domain.DTOs;
using Domain.Models;
using Microsoft.AspNetCore.Mvc;
using WebApi.Helper;

namespace WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EmployeesController(IUnitOfWork<ApplicationDbContext> unitOfWork) : ControllerBase
    {

        // GET: api/Employees
        [HttpGet]
        public async Task<ActionResult<Paging<GetEmployeeDTO>>> GetEmployees([FromQuery] BasePagingQueryParams queryParams)
        {
            IEnumerable<GetEmployeeDTO> employees = await unitOfWork.GetRepository<Employee>().GetAllAsync(queryParams.PageNumber, queryParams.PageSize, GetEmployeeDTO.Projection,order:c=>c.Id);
            var totalCount = await unitOfWork.GetRepository<Employee>().GetCountAsync();
            return new Paging<GetEmployeeDTO>(employees, totalCount, queryParams.PageNumber, queryParams.PageSize);


        }

        // GET: api/Employees/5
        [HttpGet("{id}")]
        public async Task<ActionResult<GetEmployeeDTO>> GetEmployee(int id)
        {
            var employee = await unitOfWork.GetRepository<Employee>().GetAsync(e => e.Id == id, GetEmployeeDTO.Projection);
            if (employee is null)
            {
                return NotFound(new CommonResponseDTO(404, "Couldn't find this employee"));
            }
            else
            {
                return Ok(employee);
            }
        }


        [HttpPut("{id}")]
        public async Task<IActionResult> PutEmployee(int id, PutEmployeeDTO employeeDTO)
        {
            if (id != employeeDTO.Id)
            {
                return BadRequest(new CommonResponseDTO(400));
            }
            var employee = await unitOfWork.GetRepository<Employee>().GetAsync<Employee>(e => e.Id == id);

            if (employee is null)
            {
                return NotFound(new CommonResponseDTO(404, "Employee Not Found"));
            }
            employee.FirstName = employeeDTO.FirstName;
            employee.LastName = employeeDTO.LastName;
            employee.UserName = employeeDTO.UserName;
            employee.Active = employeeDTO.Active;

            unitOfWork.GetRepository<Employee>().Modify(employee);
            try
            {
                if (await unitOfWork.SaveChangesAsync() > 0)
                    return NoContent();
                else
                    return BadRequest(new CommonResponseDTO(400, "Couldn't update the employee"));
            }
            catch (Exception ex)
            {
                return BadRequest(new CommonResponseDTO(400, ex.Message));
            }

        }

        // POST: api/Employees
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<GetEmployeeDTO>> PostEmployee(PostEmployeeDTO employeeDTO)
        {
            Employee employee = (Employee)employeeDTO;
            unitOfWork.GetRepository<Employee>().Add(employee);
            if (await unitOfWork.SaveChangesAsync() > 0)
            {
                return CreatedAtAction("GetEmployee", new { id = employee.Id }, employee);

            }
            else
            {
                return BadRequest(new CommonResponseDTO(400, "Couldn't add the employee"));
            }

        }


        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteEmployee(int id)
        {
            var employee = await unitOfWork.GetRepository<Employee>().GetAsync<Employee>(x => x.Id == id);
            if (employee is null)
            {
                return NotFound(new CommonResponseDTO(400, $"Employee of id {id} is not exist"));
            }
            unitOfWork.GetRepository<Employee>().Remove(employee);

            if (await unitOfWork.SaveChangesAsync() > 0)
            {
                return NoContent();
            }
            else
            {
                return BadRequest(new CommonResponseDTO(400, "Couldn't delete the employee"));
            }


        }

        //private bool EmployeeExists(int id)
        //    {
        //        return _context.Employees.Any(e => e.Id == id);
        //    }
    }
}
