using Repository.Dto;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Service.Services.Interfaces
{
    public interface IOrderService
    {
        Task<List<OrderDto>> Get();
        Task<OrderDto> Get(int orderId);
        Task<OrderDto> Post(OrderDto orderDto);
        Task<OrderDto> Put(int orderId, OrderDto orderDto);
        Task Delete(int orderId);
        Task<OrderDto> GetPatientOrder(int patientId, int orderId);
        Task<List<OrderDto>> GetAllPatientOrders(int patientId);
    }
}
