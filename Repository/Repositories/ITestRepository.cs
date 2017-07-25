using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Data.Models;

namespace Repository.Repositories
{
    public interface ITestRepository
    {
        Task<Test> FindById(int testId);
        Task<List<Test>> GetAll();
        Task<Test> Update(Test test);
        Task Delete(int testId);
        Task<Test> Add(Test test);
        Task SaveChanges();
    }
}
