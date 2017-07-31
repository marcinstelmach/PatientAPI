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
    [Route("api/Test")]
    public class TestController : Controller
    {
        private readonly ITestService _testService;

        public TestController(ITestService testService)
        {
            _testService = testService;
        }

        [HttpGet]
        public async Task<IActionResult> Get()
        {
            var result = await _testService.Get();
            if (result == null)
            {
                return NotFound();
            }

            return Ok(result);
        }

        [HttpGet("{testId}")]
        public async Task<IActionResult> Get(int testId)
        {
            var result = await _testService.Get(testId);
            if (result == null)
            {
                return NotFound();
            }

            return Ok(result);
        }

        [HttpPost]
        public async Task<IActionResult> Post([FromBody] TestDto testDto)
        {
            try
            {
                await _testService.Post(testDto);
                return Ok(testDto);
            }
            catch (Exception e)
            {
                return BadRequest(e);
            }
            
        }

        [HttpPut]
        public async Task<IActionResult> Put(int testId, [FromBody] TestDto testDto)
        {
            try
            {
                await _testService.Put(testId, testDto);
                return Ok(testDto);
            }
            catch (Exception e)
            {
                return BadRequest(e);
            }
        }

        [HttpDelete("{testId}")]
        public async Task<IActionResult> Delete(int testId)
        {
            try
            {
                await _testService.Delete(testId);
                return Ok();
            }
            catch (Exception e)
            {
                return BadRequest(e);
            }
        }

        [HttpGet("{patientId}/{testId}")]
        public async Task<IActionResult> GetPTest(int patientId, int testId)
        {
            var result = await _testService.GetPatientTest(patientId, testId);
            if (result == null)
            {
                return NotFound();
            }

            return Ok(result);
        }

        [HttpGet("{patientId}")]
        public async Task<IActionResult> GetPTests(int patientId)
        {
            var result = await _testService.GetAllPatientTests(patientId);
            if (result==null)
            {
                return NotFound();
            }

            return Ok(result);
        }
    }
}