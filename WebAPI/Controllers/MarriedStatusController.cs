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
    public class MarriedStatusController : ControllerBase
    {
        private IMarriedStatusService _marriedStatusService;

        public MarriedStatusController(IMarriedStatusService marriedStatusService)
        {
            _marriedStatusService = marriedStatusService;
        }
        [HttpGet("getall")]
        public async Task<IActionResult> GetAll()
        {
            var result = await _marriedStatusService.GetAll();
            if (result.Success)
            {
                return Ok(result);
            }

            return BadRequest(result);
        }

        [HttpGet("getbyid")]
        public async Task<IActionResult> GetByJobId(int marriedStatusId)
        {
            var result = await _marriedStatusService.GetById(marriedStatusId);
            if (result.Success)
            {
                return Ok(result);
            }

            return BadRequest(result);
        }
        [HttpPost("add")]
        public async Task<IActionResult> Add(MarriedStatus marriedStatus)
        {
            var result = await _marriedStatusService.Add(marriedStatus);
            if (result.Success)
            {
                return Ok(result);
            }

            return BadRequest(result);
        }
    }
}
