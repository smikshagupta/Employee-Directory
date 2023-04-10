﻿using Concerns;
using EmployeeDirectory.Services.Contracts;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Employee_Directory.Controllers
{
    [Route("api/offices")]
    [ApiController]
    public class OfficeController : ControllerBase
    {
        private readonly IOfficeContract officeContract;

        public OfficeController(IOfficeContract officeContract) 
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
                return Ok("Office added successfully");
            }
            return BadRequest();
        }

        [HttpPut]
        public IActionResult UpdateOffice(int id, OfficeConcern designation)
        {
            bool isUpdated = officeContract.UpdateDetails<OfficeConcern>(id, designation);
            if (isUpdated)
            {
                return Ok("Office updated");
            }
            return NotFound();
        }

        [HttpDelete]
        public IActionResult DeleteOffice(int id)
        {
            bool isDeleted = officeContract.DeleteDetails<OfficeConcern>(id);
            if (isDeleted)
            {
                return Ok("Office deleted");
            }
            return NotFound();
        }
    }
}
