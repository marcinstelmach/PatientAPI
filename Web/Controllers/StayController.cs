using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Repository.Dto;
using Service.Services.Interfaces;

namespace Web.Controllers
{
    [Produces("application/json")]
    [Route("api/Stay")]
    public class StayController : Controller
    {
        private readonly IStayService _stayService;

        public StayController(IStayService stayService)
        {
            _stayService = stayService;
        }


        [HttpGet]
        public async Task<IActionResult> Get()
        {
            var result = await _stayService.Get();
            if (result == null)
            {
                return NotFound();
            }

            return Ok(result);
        }

        [HttpGet("{stayId")]
        public async Task<IActionResult> Get(int stayId)
        {
            var result = await _stayService.Get(stayId);
            if (result == null)
            {
                return NotFound();
            }

            return Ok(result);
        }

        [HttpPost]
        public async Task<IActionResult> Post([FromBody] StayDto stayDto)
        {
            try
            {
                await _stayService.Post(stayDto);
                return Ok(stayDto);
            }
            catch (Exception e)
            {
                return BadRequest(e);
            }
        }

        [HttpPut]
        public async Task<IActionResult> Put(int stayId, [FromBody] StayDto stayDto)
        {
            try
            {
                await _stayService.Put(stayId, stayDto);
                return Ok(stayDto);
            }
            catch (Exception e)
            {
                return BadRequest(e);
            }
        }

        [HttpDelete("{stayId}")]
        public async Task<IActionResult> Delete(int stayId)
        {
            try
            {
                await _stayService.Delete(stayId);
                return Ok();
            }
            catch (Exception e)
            {
                return BadRequest(e);
            }
        }

        [HttpGet("{stayId}")]
        public async Task<IActionResult> GetPStays(int patientId)
        {
            var result = await _stayService.GetAllPatientStays(patientId);
            if (result == null)
            {
                return NotFound();
            }

            return Ok(result);
        }

        [HttpGet("{patientId}/{stayId}")]
        public async Task<IActionResult> GetPStay(int patientId, int stayId)
        {
            var result = await _stayService.GetPatientStay(patientId, stayId);
            if (result == null)
            {
                return NotFound();
            }

            return Ok(result);
        }

    }
}