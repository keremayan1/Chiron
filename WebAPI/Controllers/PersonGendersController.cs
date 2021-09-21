using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Business.Abstract;
using Entities.Concrete;

namespace WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PersonGendersController : ControllerBase
    {
        private IPersonGenderService _personGenderService;

        public PersonGendersController(IPersonGenderService personGenderService)
        {
            _personGenderService = personGenderService;
        }
        [HttpGet("getall")]
        public IActionResult GetAll()
        {
            var result =  _personGenderService.GetByPersonGenderDetails();
            if (result.Success)
            {
                return Ok(result.Data);
            }

            return BadRequest(result);
        }

        [HttpPost("add")]
        public async Task<IActionResult> Add(PersonGender personGender)
        {
            var result = await _personGenderService.Add(personGender);
            if (result.Success)
            {
                return Ok(result);
            }

            return BadRequest(result);
        }
    }
}
