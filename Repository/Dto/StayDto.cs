using System;
using System.Collections.Generic;
using System.Text;

namespace Repository.Repositories.Dto
{
    public class StayDto
    {
        public int StayId { get; set; }
        public DateTime From { get; set; }
        public DateTime To { get; set; }
        public string Room { get; set; }
        public string Department { get; set; }
    }
}
