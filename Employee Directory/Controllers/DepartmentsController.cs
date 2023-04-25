using Concerns;
using EmployeeDirectory.Services.Contracts;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Employee_Directory.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize]
    public class DepartmentsController : ControllerBase
    {
        private readonly IDepartmentContract departmentContract;
        public DepartmentsController(IDepartmentContract departmentContract)
        {
            this.departmentContract = departmentContract;
        }

        [HttpGet]
        public async Task<ActionResult> GetDepartments()
        {
            return Ok(await departmentContract.GetDetails<DepartmentConcern>());
        }
        [HttpGet]
        [Route("department")]
        public async Task<ActionResult> GetDepartmentByID(int id)
        {
            return Ok(await departmentContract.GetDetailsByID<DepartmentConcern>(id));
        }

        [HttpPost]
        public  async Task<ActionResult> AddDepartment(DepartmentConcern department)
        {
            bool isAdded=await departmentContract.AddDetails<DepartmentConcern>(department);
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
        public async Task<ActionResult> UpdateDepartment(int id,DepartmentConcern department)
        {
            bool isUpdated=await departmentContract.UpdateDetails<DepartmentConcern>(id, department);
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
        public async Task<ActionResult> DeleteDepartment(int id)
        {
            bool isDeleted=await departmentContract.DeleteDetails<DepartmentConcern>(id);
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
