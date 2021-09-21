using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Business.Abstract;
using Entities.Concrete;
using Entities.Concrete.Dto;

namespace WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PersonInformationsController : ControllerBase
    {
        private IPersonInformationService _personInformationService;

        public PersonInformationsController(IPersonInformationService personInformationService)
        {
            _personInformationService = personInformationService;
        }

        [HttpGet("getall")]
        public async Task<IActionResult> GetAll()
        {
            var result =await _personInformationService.GetPersonInformationDetailAsync();
            if (result.Success)
            {
                return Ok(result);
            }

            return BadRequest(result);
        }

        [HttpPost("add")]
        public async Task<IActionResult> Add(PersonInformation personInformation)
        {
            var result = await _personInformationService.AddAsync(personInformation);
            if (result.Success)
            {
                return Ok(result);
            }

            return BadRequest(result);
        }
    }
}
