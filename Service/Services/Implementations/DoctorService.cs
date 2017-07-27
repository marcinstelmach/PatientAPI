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
    public class DoctorService : IDoctorService
    {
        private readonly IMapper<Doctor, DoctorDto> _mapper;
        private readonly IDoctorRepository _doctorRepository;

        public DoctorService(IMapper<Doctor, DoctorDto> mapper, IDoctorRepository doctorRepository)
        {
            _mapper = mapper;
            _doctorRepository = doctorRepository;
        }

        public async Task<List<DoctorDto>> Get()
        {
            var result = await _doctorRepository.GetAll();
            return result.Select(s => _mapper.ToDto(s)).ToList();
        }

        public async Task<DoctorDto> Get(int doctorId)
        {
            return _mapper.ToDto(await _doctorRepository.FindById(doctorId));
        }

        public async Task<DoctorDto> Post(DoctorDto doctorDto)
        {
            return _mapper.ToDto(await _doctorRepository.Add(_mapper.FromDto(doctorDto)));
        }

        public async Task<DoctorDto> Put(int doctorId, DoctorDto doctorDto)
        {
            return _mapper.ToDto(await _doctorRepository.Update(doctorId, _mapper.FromDto(doctorDto)));
        }

        public async Task Delete(int doctorId)
        {
            await _doctorRepository.Delete(doctorId);
        }

        public async Task<DoctorDto> GetPatientDoctor(int patientId, int doctorId)
        {
            return _mapper.ToDto(await _doctorRepository.GetPatientDoctor(patientId, doctorId));
        }

        public async Task<List<DoctorDto>> GetAllPatientDoctors(int patientId)
        {
            var result = await _doctorRepository.GetPatientDoctors(patientId);
            return result.Select(s => _mapper.ToDto(s)).ToList();
        }
    }
}
