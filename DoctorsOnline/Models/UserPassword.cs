using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model
{
    public class UserPassword
    {
        public int Id { get; set; }
        public int SlNo { get; set; }
        public string Password { get; set; }
        public DateTime CreateDate { get; set; }
        
    }

}
