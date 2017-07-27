using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Data.Models;

namespace Repository.Repositories.Interfaces
{
    public interface IOrderRepository
    {
        Task<Order> FindById(int orderId);
        Task<List<Order>> GetAll();
        Task<Order> Update(int orderId, Order order);
        Task Delete(int orderId);
        Task<Order> Add(Order order);
        Task SaveChanges();
        Task<Order> GetPatientOrder(int patientId, int orderId);
        Task<List<Order>> GetAllPatientOrders(int patientId);
    }
}
