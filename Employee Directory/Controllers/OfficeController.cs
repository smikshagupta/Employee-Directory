using Concerns;
using EmployeeDirectory.Services.Contracts;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Employee_Directory.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class OfficeController : ControllerBase
    {
        private readonly ICategory categoryService;

        public OfficeController(ICategory category) 
        {
            categoryService = category;
        }

        [HttpGet]
        public IActionResult GetOffice()
        {
            return Ok(categoryService.GetDetails<OfficeConcern>());
        }

        [HttpPost]
        public IActionResult AddOffice(OfficeConcern office)
        {
            bool isAdded = categoryService.AddDetails<OfficeConcern>(office);
            if (isAdded)
            {
                return Ok("Office added successfully");
            }
            return BadRequest();
        }

        [HttpPut]
        public IActionResult UpdateOffice(int id, OfficeConcern designation)
        {
            bool isUpdated = categoryService.UpdateDetails<OfficeConcern>(id, designation);
            if (isUpdated)
            {
                return Ok("Office updated");
            }
            return NotFound();
        }

        [HttpDelete]
        public IActionResult DeleteOffice(int id)
        {
            bool isDeleted = categoryService.DeleteDetails<OfficeConcern>(id);
            if (isDeleted)
            {
                return Ok("Office deleted");
            }
            return NotFound();
        }
    }
}
