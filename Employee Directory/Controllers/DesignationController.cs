using Concerns;
using EmployeeDirectory.Services.Contracts;
using EmployeeDirectory.Services.Providers;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Employee_Directory.Controllers
{
    [Route("api/designations")]
    [ApiController]
    public class DesignationController : ControllerBase
    {
        private readonly IDesignationContract designationContract;

        public DesignationController(IDesignationContract designationContract)
        {
            this.designationContract = designationContract;
        }

        [HttpGet]
        public IActionResult GetDesignation()
        {
            return Ok(designationContract.GetDetails<DesignationConcern>());
        }

        [HttpGet]
        [Route("designation")]
        public IActionResult GetDesignationByID(int id)
        {
            return Ok(designationContract.GetDetailsByID<DesignationConcern>(id));
        }

        [HttpPost]
        public IActionResult AddDesignation(DesignationConcern designation)
        {
            bool isAdded=designationContract.AddDetails<DesignationConcern>(designation);
            if(isAdded)
            {
                return Ok();
            }
            return BadRequest();
        }

        [HttpPut]
        public IActionResult UpdateDesignation(int id, DesignationConcern designation)
        {
            bool isUpdated = designationContract.UpdateDetails<DesignationConcern>(id, designation);
            if (isUpdated)
            {
                return Ok();
            }
            return NotFound();
        }

        [HttpDelete]
        public IActionResult DeleteDesignation(int id)
        {
            bool isDeleted = designationContract.DeleteDetails<DesignationConcern>(id);
            if (isDeleted)
            {
                return Ok();
            }
            return NotFound("Department not found");
            
        }

    }
}
