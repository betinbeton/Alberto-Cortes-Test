using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Test_Generico_Lib.User.Db.SqlMsg
{
    /// <summary>
    /// This class is only to get a result or message form sql for example the last inserted id
    /// </summary>
    class SqlMsg
    {
        [Key]
        public string Message { get; set; }
    }
}
