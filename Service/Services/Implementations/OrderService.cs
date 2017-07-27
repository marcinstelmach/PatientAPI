using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Data.Models;
using Repository.Dto;
using Repository.Repositories.Interfaces;
using Service.Services.Interfaces;
using Service.Services.Mappers;

namespace Service.Services.Implementations
{
    public class OrderService : IOrderService
    {
        private readonly IMapper<Order, OrderDto> _mapper;
        private readonly IOrderRepository _orderRepository;

        public OrderService(IMapper<Order, OrderDto> mapper, IOrderRepository orderRepository)
        {
            _mapper = mapper;
            _orderRepository = orderRepository;
        }

        public async Task<List<OrderDto>> Get()
        {
            var result = await _orderRepository.GetAll();
            return result.Select(s => _mapper.ToDto(s)).ToList();
        }

        public async Task<OrderDto> Get(int orderId)
        {
            return _mapper.ToDto(await _orderRepository.FindById(orderId));
        }

        public async Task<OrderDto> Post(OrderDto orderDto)
        {
            return _mapper.ToDto(await _orderRepository.Add(_mapper.FromDto(orderDto)));
        }

        public async Task<OrderDto> Put(int orderId, OrderDto orderDto)
        {
            return _mapper.ToDto(await _orderRepository.Update(orderId, _mapper.FromDto(orderDto)));
        }

        public async Task Delete(int orderId)
        {
            await _orderRepository.Delete(orderId);
        }

        public async Task<OrderDto> GetPatientOrder(int patientId, int orderId)
        {
            return _mapper.ToDto(await _orderRepository.GetPatientOrder(patientId, orderId));
        }

        public async Task<List<OrderDto>> GetAllPatientOrders(int patientId)
        {
            var result = await _orderRepository.GetAllPatientOrders(patientId);
            return result.Select(s => _mapper.ToDto(s)).ToList();
        }
    }
}
