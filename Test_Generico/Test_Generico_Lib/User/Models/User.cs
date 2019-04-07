using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Test_Generico_Lib.User
{
   public class User
    {
        [Key]
        public int userId { get; set; }

 
        public string name { get; set; }

        public string lastName { get; set; }

        public string email { get; set; }

        public string password { get; set; }

        public bool active { get; set; }
    }
}
