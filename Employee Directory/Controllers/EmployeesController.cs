using Concerns;
using EmployeeDirectory.Services.Contracts;
using EmployeeDirectory.Services.Providers;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Employee_Directory.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EmployeesController : ControllerBase
    {
        private readonly IEmployeeContract employeeService;

        public EmployeesController(IEmployeeContract employeeService)
        {
            this.employeeService = employeeService;
        }

        [HttpGet]
        public IActionResult GetEmployees()
        {
            return Ok(employeeService.GetEmployees());
        }

        [HttpPost]

        public IActionResult AddEmployee(EmployeeConcern employee)
        {
            bool isAdded=employeeService.AddEmployee(employee);
            if(isAdded)
            {
                return Ok();
            }
            return BadRequest();
        }

        [HttpPut]
        public IActionResult UpdateEmployee( int id,EmployeeConcern employee) 
        { 
            bool isUpdated=employeeService.UpdateEmployee(id, employee);
            if( isUpdated )
            {
                return Ok();
            }
            return NotFound("Employee ID not found.");
        }

        [HttpDelete]
        public IActionResult DeleteEmployee(int id)
        {
            bool isDeleted=employeeService.DeleteEmployee(id);
            if( isDeleted )
            {
                return Ok();
            }
            return NotFound("Employee ID not found.");
        }
    }
}
