using Concerns;
using EmployeeDirectory.Services.Contracts;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Employee_Directory.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DepartmentController : ControllerBase
    {
        private readonly IDepartment departmentService;
        public DepartmentController(IDepartment department)
        {
            departmentService = department;
        }

        [HttpGet]
        public IActionResult GetDepartments()
        {
            return Ok(departmentService.GetDepartments());
        }

        [HttpPost]
        public  IActionResult AddDepartment(DepartmentConcern department)
        {
            bool isAdded=departmentService.AddDepartment(department);
            if(isAdded)
            {
                return Ok("Department added successfully");
            }
            else
            {
                return BadRequest("Something went wrong");
            }
        }

        [HttpPut]
        public IActionResult UpdateDepartment(int id,DepartmentConcern department)
        {
            bool isUpdated=departmentService.UpdateDepartment(id, department);
            if(isUpdated)
            {
                return Ok("Department details updated successfully");
            }
            else
            {
                return NotFound("Department not found");
            }
        }

        [HttpDelete]
        public IActionResult DeleteDepartment(int id)
        {
            bool isDeleted=departmentService.DeleteDepartment(id);
            if (isDeleted)
            {
                return Ok("Department deleted successfully");
            }
            else
            {
                return NotFound("Department not found");
            }
        }
    }
}
