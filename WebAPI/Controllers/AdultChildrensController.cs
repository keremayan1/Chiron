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
    public class AdultChildrensController : ControllerBase
    {
        private IAdultChildrenService _adultChildrenService;

        public AdultChildrensController(IAdultChildrenService adultChildrenService)
        {
            _adultChildrenService = adultChildrenService;
        }
        [HttpGet("getall")]
        public async Task<IActionResult> GetAll()
        {
            var result = await _adultChildrenService.GetAll();
            if (result.Success)
            {
                return Ok(result);
            }

            return BadRequest(result);
        }

        [HttpPost("add")]
        public async Task<IActionResult> Add(List<AdultChildrenDetailDto> adultChildrenDetail)
        {
            var result = await _adultChildrenService.MultipleAddAdultChildrenList(adultChildrenDetail);
            if (result.Success)
            {
                return Ok(result);
            }

            return BadRequest(result);
        }
        [HttpPost("addadultchildrendetail")]
        public async Task<IActionResult> Add(AdultChildrenDetailDto adultChildrenDetail)
        {
            var result = await _adultChildrenService.AddAdultChildrenDetail(adultChildrenDetail);
            if (result.Success)
            {
                return Ok(result);
            }

            return BadRequest(result);
        }
    }
}
