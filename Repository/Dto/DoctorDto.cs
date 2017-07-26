using System;
using System.Collections.Generic;
using System.Text;

namespace Repository.Dto
{
    public class DoctorDto
    {
        public int DoctorId { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Specjalization { get; set; }
    }
}
