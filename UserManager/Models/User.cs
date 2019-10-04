using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace UserManager.Models
{
    public class User
    {
        [Required]
        public int Id { get; set; }

        [Required]
        [MinLength(4)]
        public string Name { get; set; }

        [Required]
        [DataType(DataType.Date)]
        public DateTime Birthday { get; set; }
        
        public string Address { get; set; }

        [Required]
        [DataType(DataType.PhoneNumber)]
        public string Phone { get; set; }
    }
}
