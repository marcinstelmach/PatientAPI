using System;
using System.Collections.Generic;
using System.Text;

namespace Repository.Repositories.Dto
{
    public class PatientDto
    {
        public int PatientId { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string City { get; set; }
        public string Street { get; set; }
    }
}
