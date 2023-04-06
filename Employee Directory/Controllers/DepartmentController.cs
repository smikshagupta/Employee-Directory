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
        private readonly ICategory categoryService;
        public DepartmentController(ICategory categoryService)
        {
            this.categoryService = categoryService;
        }

        [HttpGet]
        public IActionResult GetDepartments()
        {
            return Ok(categoryService.GetDetails<DepartmentConcern>());
        }

        [HttpPost]
        public  IActionResult AddDepartment(DepartmentConcern department)
        {
            bool isAdded=categoryService.AddDetails<DepartmentConcern>(department);
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
            bool isUpdated=categoryService.UpdateDetails<DepartmentConcern>(id, department);
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
            bool isDeleted=categoryService.DeleteDetails<DepartmentConcern>(id);
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
