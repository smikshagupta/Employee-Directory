using Concerns;
using EmployeeDirectory.Services.Contracts;
using EmployeeDirectory.Services.Providers;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Employee_Directory.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DesignationController : ControllerBase
    {
        private readonly ICategory categoryService;

        public DesignationController(ICategory category)
        {
            categoryService = category;
        }

        [HttpGet]
        public IActionResult GetDesignation()
        {
            return Ok(categoryService.GetDetails<DesignationConcern>());
        }

        [HttpPost]
        public IActionResult AddDesignation(DesignationConcern designation)
        {
            bool isAdded=categoryService.AddDetails<DesignationConcern>(designation);
            if(isAdded)
            {
                return Ok("Designation added successfully");
            }
            return BadRequest();
        }

        [HttpPut]
        public IActionResult UpdateDesignation(int id, DesignationConcern designation)
        {
            bool isUpdated = categoryService.UpdateDetails<DesignationConcern>(id, designation);
            if (isUpdated)
            {
                return Ok("Designation updated");
            }
            return NotFound();
        }

        [HttpDelete]
        public IActionResult DeleteDesignation(int id)
        {
            bool isDeleted = categoryService.DeleteDetails<DesignationConcern>(id);
            if (isDeleted)
            {
                return Ok("Department deleted successfully");
            }
            return NotFound("Department not found");
            
        }

    }
}
