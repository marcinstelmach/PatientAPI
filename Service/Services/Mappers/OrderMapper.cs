using System;
using System.Collections.Generic;
using System.Text;
using Data.Models;
using Repository.Dto;

namespace Service.Services.Mappers
{
    public class OrderMapper : IMapper<Order, OrderDto>
    {
        public Order FromDto(OrderDto orderDto)
        {
            Order order = new Order();
            order.OrderId = orderDto.OrderId;
            order.Date = DateTime.Parse(orderDto.Date);
            order.TestId = orderDto.TestId;
            order.DoctorId = orderDto.DoctorId;
            order.StayId = orderDto.StayId;

            return order;
        }

        public OrderDto ToDto(Order order)
        {
            OrderDto orderDto= new OrderDto();
            orderDto.OrderId = order.OrderId;
            orderDto.DoctorId = order.DoctorId;
            orderDto.StayId = order.StayId;
            orderDto.TestId = order.TestId;
            orderDto.Date = order.Date.ToString("d");

            return orderDto;
        }
    }
}
