using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.CodeAnalysis.CSharp.Syntax;
using Repository.Dto;
using Service.Services.Interfaces;

namespace Web.Controllers
{
    [Produces("application/json")]
    [Route("api/[controller]")]
    public class PatientController : Controller
    {
        private readonly IPatientService _patientService;

        public PatientController(IPatientService patientService)
        {
            _patientService = patientService;
        }

        [HttpGet]
        public async Task<IActionResult> Get()
        {
            var result = await _patientService.Get();

            if (result.Count <= 0)
            {
                return NotFound();
            }

            return Ok(result);
        }

        [HttpGet("{patientId}")]
        public async Task<IActionResult> Get(int patientId)
        {
            var result = await _patientService.Get(patientId);

            if (result==null)
            {
                return NotFound();
            }

            return Ok(result);
        }

        [HttpPost]
        public async Task<IActionResult> Post([FromBody] PatientDto patientDto)
        {
            try
            {
                await _patientService.Post(patientDto);
                return Ok(patientDto);
            }
            catch (Exception e)
            {
                return BadRequest(e);
            }
        }

        [HttpPut]
        public async Task<IActionResult> Put(int patientId, [FromBody] PatientDto patientDto)
        {
            try
            {
                await _patientService.Put(patientId, patientDto);
                return Ok(patientDto);
            }
            catch (Exception e)
            {
                return BadRequest(e);
            }
        }

        [HttpDelete("{patientId}")]
        public async Task<IActionResult> Delete(int patientId)
        {
            try
            {
                await _patientService.Delete(patientId);
                return Ok();
            }
            catch (Exception e)
            {
                return BadRequest(e);
            }
        }
    }
}