using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace Data.Models
{
    public class Doctor
    {
        [Key]
        public int DoctorId { get; set; }
        [Required(ErrorMessage = "Set first name")]
        public string FirstName { get; set; }
        [Required(ErrorMessage = "Set Last Name")]
        public string LastName { get; set; }
        [Required(ErrorMessage = "Set specjalization")]
        public string Specjalization { get; set; }

        public virtual ICollection<Order> Orders { get; set; }
    }
}
