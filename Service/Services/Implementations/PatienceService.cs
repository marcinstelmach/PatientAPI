using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Data.Models;
using Repository.Dto;
using Repository.Repositories.Interfaces;
using Service.Services.Interfaces;
using Service.Services.Mappers;

namespace Service.Services.Implementations
{
    public class PatienceService : IPatientService
    {
        private readonly IPatientRepository _patientRepository;
        private readonly IMapper<Patient, PatientDto> _mapper;

        public PatienceService(IPatientRepository patientRepository, IMapper<Patient, PatientDto> mapper)
        {
            _patientRepository = patientRepository;
            _mapper = mapper;
        }

        public async Task<List<PatientDto>> Get()
        {
            var patients = await _patientRepository.GetAll();
            List<PatientDto> patientDto = new List<PatientDto>();
            foreach (var item in patients)
            {
                patientDto.Add(_mapper.ToDto(item));
            }

            return patientDto;
        }

        public async Task<PatientDto> Get(int patientId)
        {
            return _mapper.ToDto(await _patientRepository.FindById(patientId));
        }

        public async Task<PatientDto> Post(PatientDto patientDto)
        {
            return _mapper.ToDto(await _patientRepository.Add(_mapper.FromDto(patientDto)));
        }

        public async Task<PatientDto> Put(int patientId, PatientDto patientDto)
        {
            return _mapper.ToDto(await _patientRepository.Update(patientId, _mapper.FromDto(patientDto)));
        }

        public async Task Delete(int patientId)
        {
            await _patientRepository.Delete(patientId);
        }

        public async Task<StayDto> GetStay(int stayId)
        {
            throw new NotImplementedException();
        }

        public async Task<List<StayDto>> GetAllStays()
        {
            throw new NotImplementedException();
        }

        public async Task<OrderDto> GetOrder(int orderId)
        {
            throw new NotImplementedException();
        }

        public async Task<List<OrderDto>> GetAllOrders()
        {
            throw new NotImplementedException();
        }

        public async Task<DoctorDto> GetDoctor(int doctorId)
        {
            throw new NotImplementedException();
        }

        public async Task<List<DoctorDto>> GetAllDoctors()
        {
            throw new NotImplementedException();
        }

        public async Task<TestDto> GetTest(int testId)
        {
            throw new NotImplementedException();
        }

        public async Task<List<TestDto>> GetAllTests()
        {
            throw new NotImplementedException();
        }
    }
}
