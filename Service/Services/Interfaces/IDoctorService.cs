using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Repository.Dto;

namespace Service.Services.Interfaces
{
    public interface IDoctorService
    {
        Task<List<DoctorDto>> Get();
        Task<DoctorDto> Get(int doctorId);
        Task<DoctorDto> Post(DoctorDto doctorDto);
        Task<DoctorDto> Put(int doctorId, DoctorDto doctorDto);
        Task Delete(int doctorId);
    }
}
