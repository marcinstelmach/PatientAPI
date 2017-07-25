using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace Data.Models
{
    public class Stay
    {
        [Key]
        public int StayId { get; set; }
        public DateTime From { get; set; }
        public DateTime To { get; set; }
        [Required(ErrorMessage = "Set Room")]
        public string Room { get; set; }
        [Required(ErrorMessage = "Set Department")]
        public string Department { get; set; }

        public int PatientId { get; set; }
        public virtual Patient Patient { get; set; }
        public virtual ICollection<Order> Orders { get; set; }
    }
}
