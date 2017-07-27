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

            return patients.Select(item => _mapper.ToDto(item)).ToList();
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

    }
}
