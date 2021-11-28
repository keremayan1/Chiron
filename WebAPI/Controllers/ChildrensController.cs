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
    public class ChildrensController : ControllerBase
    {
        private IChildrenService _childrenService;

        public ChildrensController(IChildrenService childrenService)
        {
            _childrenService = childrenService;
        }
        [HttpGet("getall")]
        public async Task<IActionResult> GetAll()
        {
            var result =await  _childrenService.GetChildrenDetails();
            if (result.Success)
            {
                return Ok(result);
            }

            return BadRequest(result);
        }

        [HttpPost("add")]
        public async Task<IActionResult> Add(ChildrenDetail children)
        {
            var result = await _childrenService.MultipleChildrenDetailAdd(children);
            if (result.Success)
            {
                return Ok(result);
            }

            return BadRequest(result);
        }
       

    }
}
