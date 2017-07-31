using System;
using System.Collections.Generic;
using System.Text;
using Data.Models;
using Repository.Dto;

namespace Service.Services.Mappers
{
    public class DoctorMapper : IMapper<Doctor, DoctorDto>
    {
        public Doctor FromDto(DoctorDto doctorDto)
        {
            Doctor doctor = new Doctor();
            doctor.DoctorId = doctorDto.DoctorId;
            doctor.FirstName = doctorDto.FirstName;
            doctor.LastName = doctorDto.LastName;
            doctor.Specjalization = doctorDto.Specjalization;

            return doctor;
        }

        public DoctorDto ToDto(Doctor doctor)
        {
            DoctorDto doctorDto= new DoctorDto();
            doctorDto.DoctorId = doctor.DoctorId;
            doctorDto.FirstName = doctor.FirstName;
            doctorDto.LastName = doctor.LastName;
            doctorDto.Specjalization = doctor.Specjalization;

            return doctorDto;
        }
    }
}
