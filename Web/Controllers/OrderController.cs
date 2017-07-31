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
    [Route("api/Order")]
    public class OrderController : Controller
    {
        private readonly IOrderService _orderService;

        public OrderController(IOrderService orderService)
        {
            _orderService = orderService;
        }

        [HttpGet]
        public async Task<IActionResult> Get()
        {
            var result = await _orderService.Get();
            if (result == null)
            {
                return NotFound();
            }

            return Ok(result);
        }

        [HttpGet("{orderId}")]
        public async Task<IActionResult> Get(int orderId)
        {
            var result = await _orderService.Get(orderId);
            if (result == null)
            {
                return NotFound();
            }
            return Ok(result);
        }

        [HttpPost]
        public async Task<IActionResult> Post([FromBody] OrderDto orderDto)
        {
            try
            {
                return Ok(await _orderService.Post(orderDto));
            }
            catch (Exception e)
            {
                return BadRequest(e);
            }
        }


        [HttpPut("{orderId}")]
        public async Task<IActionResult> Put(int orderId, [FromBody] OrderDto orderDto)
        {
            try
            {
                return Ok(await _orderService.Put(orderId, orderDto));
            }
            catch (Exception e)
            {
                return BadRequest(e);
            }
        }

        [HttpDelete("{orderId}")]
        public async Task<IActionResult> Delete(int orderId)
        {
            try
            {
                await _orderService.Delete(orderId);
                return Ok();
            }
            catch (Exception e)
            {
                return BadRequest(e);
            }
        }

        [HttpGet("GetPatientOrders/{patientId}")]
        public async Task<IActionResult> GetPOrders(int patientId)
        {
            var result = await _orderService.GetAllPatientOrders(patientId);
            if (result == null)
            {
                return NotFound();
            }

            return Ok(result);
        }

        [HttpGet("GetPatientOrder/{patientId}/{orderId}")]
        public async Task<IActionResult> GetPOrder(int patientId, int orderId)
        {
            var result = await _orderService.GetPatientOrder(patientId, orderId);
            if (result == null)
            {
                return NotFound();
            }

            return Ok(result);
        }
    }
}