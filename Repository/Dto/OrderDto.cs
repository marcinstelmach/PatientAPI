using System;
using System.Collections.Generic;
using System.Text;

namespace Repository.Dto
{
    public class OrderDto
    {
        public int OrderId { get; set; }
        public int StayId { get; set; }
        public int DoctorId { get; set; }
        public int TestId { get; set; }
        public string Date { get; set; }
    }
}
