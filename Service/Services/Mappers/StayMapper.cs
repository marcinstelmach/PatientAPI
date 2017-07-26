using System;
using System.Collections.Generic;
using System.Text;
using Data.Models;
using Repository.Dto;

namespace Service.Services.Mappers
{
    public class StayMapper : IMapper<Stay, StayDto>
    {
        public Stay FromDto(StayDto stayDto)
        {
            Stay stay = new Stay();
            stay.StayId = stayDto.StayId;
            stay.Department = stayDto.Department;
            stay.PatientId = stayDto.PatientId;
            stay.From = DateTime.Parse(stayDto.From);
            stay.To = DateTime.Parse(stayDto.To);
            stay.Room = stayDto.Room;

            return stay;
        }

        public StayDto ToDto(Stay stay)
        {
            StayDto stayDto = new StayDto();
            stayDto.StayId = stay.StayId;
            stayDto.Department = stay.Department;
            stayDto.PatientId = stay.PatientId;
            stayDto.From = stay.From.ToString("d");
            stayDto.To = stay.To.ToString("d");
            stayDto.Room = stay.Room;

            return stayDto;
        }
    }
}
