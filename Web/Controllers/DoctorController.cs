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
    [Route("api/Doctor")]
    public class DoctorController : Controller
    {
        private readonly IDoctorService _doctorService;

        public DoctorController(IDoctorService doctorService)
        {
            _doctorService = doctorService;
        }

        [HttpGet]
        public async Task<IActionResult> Get()
        {
            var result = await _doctorService.Get();
            if (result==null)
            {
                return NotFound();
            }
            return Ok(result);
        }

        [HttpGet("{doctorId}")]
        public async Task<IActionResult> Get(int doctorId)
        {
            var result = await _doctorService.Get(doctorId);
            if (result==null)
            {
                return NotFound();
            }

            return Ok(result);
        }

        [HttpPost]
        public async Task<IActionResult> Post([FromBody] DoctorDto doctorDto)
        {
            try
            {        
                return Ok(await _doctorService.Post(doctorDto));
            }
            catch (Exception e)
            {
                return BadRequest(e);
            }
        }

        [HttpPut]
        public async Task<IActionResult> Put(int doctorId, [FromBody] DoctorDto doctorDto)
        {
            try
            {
                return Ok(await _doctorService.Put(doctorId, doctorDto));
            }
            catch (Exception e)
            {
                return BadRequest(e);
            }
        }

        [HttpDelete("{doctorId}")]
        public async Task<IActionResult> Delete(int doctorId)
        {
            try
            {
                await _doctorService.Delete(doctorId);
                return Ok();
            }
            catch (Exception e)
            {
                return BadRequest(e);
            }
        }

        [HttpGet("GetPatientDoctor/{patientId}/{doctorId}")]
        public async Task<IActionResult> GetPDoctor(int patientId, int doctorId)
        {
            var result = await _doctorService.GetPatientDoctor(patientId, doctorId);
            if (result==null)
            {
                return NotFound();
            }

            return Ok(result);
        }

        [HttpGet("GetPatientDoctors/{patientId}")]
        public async Task<IActionResult> GetPDoctors(int patientId)
        {
            var result = await _doctorService.GetAllPatientDoctors(patientId);
            if (result==null)
            {
                return NotFound();
            }

            return Ok(result);
        }
    }
}