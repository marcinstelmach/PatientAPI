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
    public class StayService : IStayService
    {
        private readonly IStayRepository _stayRepository;
        private readonly IMapper<Stay, StayDto> _mapper;

        public StayService(IStayRepository stayRepository, IMapper<Stay, StayDto> mapper)
        {
            _stayRepository = stayRepository;
            _mapper = mapper;
        }

        public async Task<List<StayDto>> Get()
        {
            var stays = await _stayRepository.GetAll();
            return stays.Select(s =>_mapper.ToDto(s)).ToList();
        }

        public async Task<StayDto> Get(int stayId)
        {
            return _mapper.ToDto(await _stayRepository.FindById(stayId));
        }

        public async Task<StayDto> Post(StayDto stayDto)
        {
            return _mapper.ToDto(await _stayRepository.Add(_mapper.FromDto(stayDto)));
        }

        public async Task<StayDto> Put(int stayId, StayDto stayDto)
        {
            return _mapper.ToDto(await _stayRepository.Update(stayId, _mapper.FromDto(stayDto)));
        }

        public async Task Delete(int stayId)
        {
            await _stayRepository.Delete(stayId);
        }

        public async Task<StayDto> GetPatientStay(int patientId, int stayId)
        {
            return _mapper.ToDto(await _stayRepository.GetPatientStay(patientId, stayId));
        }

        public async Task<List<StayDto>> GetAllPatientStays(int patientId)
        {
            var result = await _stayRepository.GetAllPatientStays(patientId);
            return result.Select(s => _mapper.ToDto(s)).ToList();
        }
    }
}
