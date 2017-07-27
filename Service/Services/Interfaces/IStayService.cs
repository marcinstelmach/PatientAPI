using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Repository.Dto;

namespace Service.Services.Interfaces
{
    public interface IStayService
    {
        Task<List<StayDto>> Get();
        Task<StayDto> Get(int stayId);
        Task<StayDto> Post(StayDto stayDto);
        Task<StayDto> Put(int stayId, StayDto stayDto);
        Task Delete(int stayId);
        Task<StayDto> GetPatientStay(int patientId, int stayId);
        Task<List<StayDto>> GetAllPatientStays(int patientId);
    }
}
