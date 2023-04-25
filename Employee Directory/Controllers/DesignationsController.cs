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

    public class DesignationsController : ControllerBase
    {
        private readonly IDesignationContract designationContract;

        public DesignationsController(IDesignationContract designationContract)
        {
            this.designationContract = designationContract;
        }

        [HttpGet]
        public async Task<ActionResult> GetDesignation()
        {
            return Ok(await designationContract.GetDetails<DesignationConcern>());
        }

        [HttpGet]
        [Route("designation")]
        public async Task<ActionResult> GetDesignationByID(int id)
        {
            return Ok(await designationContract.GetDetailsByID<DesignationConcern>(id));
        }

        [HttpPost]
        public async Task<ActionResult> AddDesignation(DesignationConcern designation)
        {
            bool isAdded=await designationContract.AddDetails<DesignationConcern>(designation);
            if(isAdded)
            {
                return Ok();
            }
            return BadRequest();
        }

        [HttpPut]
        public async Task<ActionResult> UpdateDesignation(int id, DesignationConcern designation)
        {
            bool isUpdated = await designationContract.UpdateDetails<DesignationConcern>(id, designation);
            if (isUpdated)
            {
                return Ok();
            }
            return NotFound();
        }

        [HttpDelete]
        public async Task<ActionResult> DeleteDesignation(int id)
        {
            bool isDeleted = await designationContract.DeleteDetails<DesignationConcern>(id);
            if (isDeleted)
            {
                return Ok();
            }
            return NotFound("Department not found");
            
        }

    }
}
