using System;
using System.Collections.Generic;
using System.Text;
using Data.Models;
using Repository.Dto;

namespace Service.Services.Mappers
{
    public class TestMapper : IMapper<Test, TestDto>
    {
        public Test FromDto(TestDto testDto)
        {
            Test test = new Test();
            test.TestId = testDto.TestId;
            test.Name = testDto.Name;
            test.Result = testDto.Result;
            test.Date = DateTime.Parse(testDto.Date);

            return test;
        }

        public TestDto ToDto(Test test)
        {
            TestDto testDto = new TestDto();
            testDto.TestId = test.TestId;
            testDto.Name = test.Name;
            testDto.Result = testDto.Result;
            testDto.Date = test.Date.ToString("d");

            return testDto;
        }
    }
}
