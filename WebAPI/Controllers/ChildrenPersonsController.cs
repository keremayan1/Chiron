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
    public class ChildrenPersonsController : ControllerBase
    {
        private IChildrenPersonService _childrenPersonService;

        public ChildrenPersonsController(IChildrenPersonService childrenPersonService)
        {
            _childrenPersonService = childrenPersonService;
        }


        [HttpGet("getall")]
        public async Task<IActionResult> GetAll()
        {
            var result = await _childrenPersonService.GetChildrenPersonDetails();
            if (result.Success)
            {
                return Ok(result);
            }

            return BadRequest(result);
        }

        [HttpPost("add")]
        public async Task<IActionResult> Add( ChildrenPersonDetail childrenPersonDetail)
        {
            var result = await  _childrenPersonService.AddAsync(childrenPersonDetail);
            if (result.Success)
            {
                return Ok(result);
            }

            return BadRequest(result);
        }
      
    }
}
