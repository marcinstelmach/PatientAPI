using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace Data.Models
{
    public class Order
    {
        [Key]
        public int OrderId { get; set; }

        [ForeignKey("Stay")]
        public int StayId { get; set; }

        [ForeignKey("Doctor")]
        public int DoctorId { get; set; }

        [ForeignKey("Test")]
        public int TestId { get; set; }
        public DateTime Date { get; set; }

        public virtual Stay Stay { get; set; }
        public virtual Doctor Doctor { get; set; }
        public virtual Test Test { get; set; }
    }
}
