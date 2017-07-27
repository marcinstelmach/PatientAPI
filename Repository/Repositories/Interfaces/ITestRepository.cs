using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Data.Models;

namespace Repository.Repositories.Interfaces
{
    public interface ITestRepository
    {
        Task<Test> FindById(int testId);
        Task<List<Test>> GetAll();
        Task<Test> Update(int testId, Test test);
        Task Delete(int testId);
        Task<Test> Add(Test test);
        Task SaveChanges();
        Task<Test> GetPatientTest(int patientId, int testId);
        Task<List<Test>> GetAllPatientTests(int patientId);
    }
}
