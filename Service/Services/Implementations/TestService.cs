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
    public class TestService : ITestService
    {
        private readonly IMapper<Test, TestDto> _mapper;
        private readonly ITestRepository _testRepository;

        public TestService(IMapper<Test, TestDto> mapper, ITestRepository testRepository)
        {
            _mapper = mapper;
            _testRepository = testRepository;
        }

        public async Task<List<TestDto>> Get()
        {
            var result = await _testRepository.GetAll();
            return result.Select(s => _mapper.ToDto(s)).ToList();
        }

        public async Task<TestDto> Get(int testId)
        {
            return _mapper.ToDto(await _testRepository.FindById(testId));
        }

        public async Task<TestDto> Post(TestDto testDto)
        {
            return _mapper.ToDto(await _testRepository.Add(_mapper.FromDto(testDto)));
        }

        public async Task<TestDto> Put(int testId, TestDto testDto)
        {
            return _mapper.ToDto(await _testRepository.Update(testId, _mapper.FromDto(testDto)));
        }

        public async Task Delete(int testId)
        {
            await _testRepository.Delete(testId);
        }

        public async Task<TestDto> GetPatientTest(int patientId, int testId)
        {
            return _mapper.ToDto(await _testRepository.GetPatientTest(patientId, testId));
        }

        public async Task<List<TestDto>> GetAllPatientTests(int patientId)
        {
            var result = await _testRepository.GetAllPatientTests(patientId);
            return result.Select(s => _mapper.ToDto(s)).ToList();
        }
    }
}
