using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace Data.Models
{
    public class Test
    {
        [Key]
        public int TestId { get; set; }
        [Required(ErrorMessage = "Test name can not be empty.")]
        public string Name { get; set; }
        public string Result { get; set; }
        public DateTime Date { get; set; }

        public virtual Order Order { get; set; }
    }
}
