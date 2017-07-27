using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices.ComTypes;
using System.Text;
using System.Threading.Tasks;
using Data.Models;
using Microsoft.EntityFrameworkCore;
using Repository.DAL;
using Repository.Repositories.Interfaces;

namespace Repository.Repositories.Implementations
{
    public class TestRepository : ITestRepository
    {
        private readonly ApplicationDbContext _db;

        public TestRepository(ApplicationDbContext db)
        {
            _db = db;
        }

        public async Task<Test> FindById(int testId)
        {
            return await _db.Tests.FirstOrDefaultAsync(s => s.TestId == testId);
        }

        public async Task<List<Test>> GetAll()
        {
            return await _db.Tests.ToListAsync();
        }

        public async Task<Test> Update(int testId, Test test)
        {
            var result = await FindById(testId);
            if (result==null)
            {
                throw new Exception($"Test with id:{testId} not found");
            }

            _db.Tests.Update(test);
            await SaveChanges();
            return test;
        }

        public async Task Delete(int testId)
        {
            var result = await FindById(testId);
            if (result==null)
            {
                throw new Exception($"Test with id:{testId} not found");
            }

            _db.Tests.Remove(result);
            await SaveChanges();
        }

        public async Task<Test> Add(Test test)
        {
            await _db.Tests.AddAsync(test);
            await SaveChanges();
            return test;
        }

        public async Task SaveChanges()
        {
            await _db.SaveChangesAsync();
        }

        public async Task<Test> GetPatientTest(int patientId, int testId)
        {
            var result = await _db.Tests
                .Join(_db.Orders,
                    test => test.TestId,
                    order => order.TestId,
                    (test, order) => new {Test = test, Order = order})
                .Where(s => s.Test.TestId == testId)
                .Join(_db.Stays,
                    orderTest => orderTest.Order.StayId,
                    stay => stay.StayId,
                    (orderTest, stay) => new {OrderTest = orderTest, Stay = stay})
                .FirstOrDefaultAsync(s => s.Stay.PatientId == patientId);

            return result.OrderTest.Test;
        }

        public async Task<List<Test>> GetAllPatientTests(int patientId)
        {
            var result = await _db.Tests
                .Join(_db.Orders,
                    test => test.TestId,
                    order => order.TestId,
                    (test, order) => new {Test = test, Order = order})
                .Join(_db.Stays,
                    orderTest => orderTest.Order.StayId,
                    stay => stay.StayId,
                    (orderTest, stay) => new {OrderTest = orderTest, Stay = stay})
                .Where(s => s.Stay.PatientId == patientId)
                .Select(s =>s.OrderTest.Test)
                .ToListAsync();
            return result;
        }
    }
}