using System;
using System.Collections.Generic;
using System.Text;
using Data.Models;
using Repository.Dto;

namespace Service.Services.Mappers
{
    public class PatientMapper : IMapper<Patient, PatientDto>
    {
        public Patient FromDto(PatientDto patientDto)
        {
            Patient patient = new Patient();
            patient.PatientId = patientDto.PatientId;
            patient.FirstName = patientDto.FirstName;
            patient.LastName = patientDto.LastName;
            patient.City = patientDto.City;
            patient.Street = patientDto.Street;

            return patient;
        }

        public PatientDto ToDto(Patient patient)
        {
            PatientDto patientDto = new PatientDto();
            patientDto.PatientId = patient.PatientId;
            patientDto.FirstName = patient.FirstName;
            patientDto.LastName = patient.LastName;
            patientDto.City = patient.City;
            patientDto.Street = patient.Street;

            return patientDto;
        }
    }
}
