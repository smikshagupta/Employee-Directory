using Concerns;
using EmployeeDirectory.Services.Contracts;
using EmployeeDirectory.Services.Providers;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Employee_Directory.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize]

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
        [Authorize]
        [HttpPost]

        public async Task<ActionResult> AddEmployee(EmployeeConcern employee)
        {
            bool isAdded=await employeeService.AddEmployee(employee);
            if(isAdded)
            {
                return Ok();
            }
            return BadRequest();
        }

        [HttpPut]
        public async Task<ActionResult> UpdateEmployee( int id,EmployeeConcern employee) 
        { 
            bool isUpdated=await employeeService.UpdateEmployee(id, employee);
            if( isUpdated )
            {
                return Ok();
            }
            return NotFound("Employee ID not found.");
        }

        [HttpDelete]
        public async Task<ActionResult> DeleteEmployee(int id)
        {
            bool isDeleted=await employeeService.DeleteEmployee(id);
            if( isDeleted )
            {
                return Ok();
            }
            return NotFound("Employee ID not found.");
        }
    }
}
