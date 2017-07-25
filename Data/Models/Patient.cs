using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace Data.Models
{
    public class Patient
    {
        [Key]
        public int PatientId { get; set; }
        [Required(ErrorMessage = "Set First Name")]
        public string FirstName { get; set; }
        [Required(ErrorMessage = "Set Last Name")]
        public string LastName { get; set; }
        [Required(ErrorMessage = "Set City")]
        public string City { get; set; }
        [Required(ErrorMessage = "Set Street")]
        public string Street { get; set; }

        public virtual ICollection<Stay> Stay { get; set; }
    }
}
