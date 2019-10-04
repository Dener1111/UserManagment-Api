using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace UserManager.Models
{
    public class UserModel : User
    {
        public int Age { get => (new DateTime(1, 1, 1) + (DateTime.Now - Birthday)).Year - 1 ; }
        
        [DataType(DataType.Date)]
        public int CreationTime { get; set; }
    }
}
