using Concerns;
using EmployeeDirectory.Services.Contracts;
using EmployeeDirectory.Services.Providers;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Employee_Directory.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EmployeeController : ControllerBase
    {
        private readonly IEmployee employeeService;

        public EmployeeController(IEmployee employeeService)
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
        public IActionResult UpdateEmployee( int empID,EmployeeConcern employee) 
        { 
            bool isUpdated=employeeService.UpdateEmployee(empID, employee);
            if( isUpdated )
            {
                return Ok("Updated Employee details.");
            }
            return NotFound("Employee ID not found.");
        }

        [HttpDelete]
        public IActionResult DeleteEmployee(int empID)
        {
            bool isDeleted=employeeService.DeleteEmployee(empID);
            if( isDeleted )
            {
                return Ok("Employee deleted successfully");
            }
            return NotFound("Employee ID not found.");
        }
    }
}
