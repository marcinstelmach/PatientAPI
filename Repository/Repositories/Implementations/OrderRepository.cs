using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Data.Models;
using Microsoft.EntityFrameworkCore;
using Repository.DAL;
using Repository.Repositories.Interfaces;

namespace Repository.Repositories.Implementations
{
    public class OrderRepository : IOrderRepository
    {
        private readonly ApplicationDbContext _db;

        public OrderRepository(ApplicationDbContext db)
        {
            _db = db;
        }

        public async Task<Order> FindById(int orderId)
        {
            return await _db.Orders.FirstOrDefaultAsync(s => s.OrderId == orderId);
        }

        public async Task<List<Order>> GetAll()
        {
            return await _db.Orders.ToListAsync();
        }

        public async Task<Order> Update(int orderId, Order order)
        {
            var result = await FindById(orderId);
            if (result==null)
            {
                throw new Exception($"Order with id: {orderId} not found");
            }

            var doctor = await _db.Doctors.FirstOrDefaultAsync(s => s.DoctorId == order.DoctorId);
            if (doctor == null)
            {
                throw new Exception($"Doctor with id: {order.DoctorId} not found");
            }

            var test = await _db.Tests.FirstOrDefaultAsync(s => s.TestId == order.TestId);
            if (test == null)
            {
                throw new Exception($"Test with id: {order.TestId} not found");
            }
            var stay = await _db.Stays.FirstOrDefaultAsync(s => s.StayId == order.StayId);
            if (stay == null)
            {
                throw new Exception($"Stay with id: {order.StayId} not found");
            }

            result.TestId = order.TestId;
            result.DoctorId = order.DoctorId;
            result.StayId = order.StayId;
            result.Date = order.Date;

            _db.Orders.Update(result);
            await SaveChanges();
            return result;

        }

        public async Task Delete(int orderId)
        {
            var toDelete = await FindById(orderId);
            if (toDelete==null)
            {
                throw new Exception($"Order with id: {orderId} not found");
            }

            _db.Orders.Remove(toDelete);
            await SaveChanges();
        }

        public async Task<Order> Add(Order order)
        {
            var doctor = await _db.Doctors.FirstOrDefaultAsync(s => s.DoctorId == order.DoctorId);
            if (doctor==null)
            {
                throw new Exception($"Doctor with id: {order.DoctorId} not found");
            }

            var test = await _db.Tests.FirstOrDefaultAsync(s => s.TestId == order.TestId);
            if (test==null)
            {
                throw new Exception($"Test with id: {order.TestId} not found");
            }
            var stay = await _db.Stays.FirstOrDefaultAsync(s => s.StayId == order.StayId);
            if (stay==null)
            {
                throw new Exception($"Stay with id: {order.StayId} not found");
            }
            await _db.AddAsync(order);
            await SaveChanges();
            return order;
        }

        public async Task SaveChanges()
        {
            await _db.SaveChangesAsync();
        }

        public async Task<Order> GetPatientOrder(int patientId, int orderId)
        {
            var result = await _db.Orders
                .Join(_db.Stays,
                    order => order.StayId,
                    stay => stay.StayId,
                    (order, stay) => new {Order = order, Stay = stay})
                .FirstOrDefaultAsync(s => s.Stay.PatientId == patientId && s.Order.OrderId == orderId);

            return  result.Order;
        }

        public async Task<List<Order>> GetAllPatientOrders(int patientId)
        {
            var result = await _db.Orders
                .Join(_db.Stays,
                    order => order.StayId,
                    stay => stay.StayId,
                    (order, stay) => new {Order = order, Stay = stay})
                .Where(s => s.Stay.PatientId == patientId)
                .Select(s => s.Order).ToListAsync();

            return result;
        }
    }
}
