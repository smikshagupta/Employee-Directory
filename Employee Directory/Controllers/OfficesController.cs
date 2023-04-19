using Concerns;
using EmployeeDirectory.Services.Contracts;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Employee_Directory.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class OfficesController : ControllerBase
    {
        private readonly IOfficeContract officeContract;

        public OfficesController(IOfficeContract officeContract) 
        {
            this.officeContract = officeContract;
        }

        [HttpGet]
        public IActionResult GetOffice()
        {
            return Ok(officeContract.GetDetails<OfficeConcern>());
        }

        [HttpGet]
        [Route("office")]
        public IActionResult GetOfficeByID(int id)
        {
            return Ok(officeContract.GetDetailsByID<OfficeConcern>(id));
        }

        [HttpPost]
        public IActionResult AddOffice(OfficeConcern office)
        {
            bool isAdded = officeContract.AddDetails<OfficeConcern>(office);
            if (isAdded)
            {
                return Ok();
            }
            return BadRequest();
        }

        [HttpPut]
        public IActionResult UpdateOffice(int id, OfficeConcern designation)
        {
            bool isUpdated = officeContract.UpdateDetails<OfficeConcern>(id, designation);
            if (isUpdated)
            {
                return Ok();
            }
            return NotFound();
        }

        [HttpDelete]
        public IActionResult DeleteOffice(int id)
        {
            bool isDeleted = officeContract.DeleteDetails<OfficeConcern>(id);
            if (isDeleted)
            {
                return Ok();
            }
            return NotFound();
        }
    }
}
