using Concerns;
using EmployeeDirectory.Services.Contracts;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Employee_Directory.Controllers
{
    [Route("api/[controller]")]
    [ApiController]

    public class DepartmentsController : ControllerBase
    {
        private readonly IDepartmentContract departmentContract;
        public DepartmentsController(IDepartmentContract departmentContract)
        {
            this.departmentContract = departmentContract;
        }

        [HttpGet]
        public IActionResult GetDepartments()
        {
            return Ok(departmentContract.GetDetails<DepartmentConcern>());
        }
        [HttpGet]
        [Route("department")]
        public IActionResult GetDepartmentByID(int id)
        {
            return Ok(departmentContract.GetDetailsByID<DepartmentConcern>(id));
        }

        [HttpPost]
        public  IActionResult AddDepartment(DepartmentConcern department)
        {
            bool isAdded=departmentContract.AddDetails<DepartmentConcern>(department);
            if(isAdded)
            {
                return Ok();
            }
            else
            {
                return BadRequest("Something went wrong");
            }
        }

        [HttpPut]
        public IActionResult UpdateDepartment(int id,DepartmentConcern department)
        {
            bool isUpdated=departmentContract.UpdateDetails<DepartmentConcern>(id, department);
            if(isUpdated)
            {
                return Ok();
            }
            else
            {
                return NotFound("Department not found");
            }
        }

        [HttpDelete]
        public IActionResult DeleteDepartment(int id)
        {
            bool isDeleted=departmentContract.DeleteDetails<DepartmentConcern>(id);
            if (isDeleted)
            {
                return Ok();
            }
            else
            {
                return NotFound("Department not found");
            }
        }
    }
}
