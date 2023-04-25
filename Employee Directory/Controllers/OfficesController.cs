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

    public class OfficesController : ControllerBase
    {
        private readonly IOfficeContract officeContract;

        public OfficesController(IOfficeContract officeContract) 
        {
            this.officeContract = officeContract;
        }

        [HttpGet]
        public async Task<ActionResult> GetOffice()
        {
            return Ok(await officeContract.GetDetails<OfficeConcern>());
        }

        [HttpGet]
        [Route("office")]
        public async Task<ActionResult> GetOfficeByID(int id)
        {
            return Ok(await officeContract.GetDetailsByID<OfficeConcern>(id));
        }

        [HttpPost]
        public async Task<ActionResult> AddOffice(OfficeConcern office)
        {
            bool isAdded = await officeContract.AddDetails<OfficeConcern>(office);
            if (isAdded)
            {
                return Ok();
            }
            return BadRequest();
        }

        [HttpPut]
        public async Task<ActionResult> UpdateOffice(int id, OfficeConcern designation)
        {
            bool isUpdated = await officeContract.UpdateDetails<OfficeConcern>(id, designation);
            if (isUpdated)
            {
                return Ok();
            }
            return NotFound();
        }

        [HttpDelete]
        public async Task<ActionResult> DeleteOffice(int id)
        {
            bool isDeleted = await officeContract.DeleteDetails<OfficeConcern>(id);
            if (isDeleted)
            {
                return Ok();
            }
            return NotFound();
        }
    }
}
