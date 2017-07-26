using Repository.Dto;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Service.Services.Interfaces
{
    public interface ITestService
    {
        Task<List<TestDto>> Get();
        Task<TestDto> Get(int testId);
        Task<TestDto> Post(TestDto testDto);
        Task<TestDto> Put(int testId, TestDto testDto);
        Task Delete(int testId);
    }
}
