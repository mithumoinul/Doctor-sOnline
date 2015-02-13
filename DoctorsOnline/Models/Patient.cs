using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model
{
    public class Patient
    {
        public int Id { get; set; }
        public string PatientName { get; set; }
        public DateTime CreateDate { get; set; }
        public DateTime ActionDate { get; set; }
        public bool IsActive { get; set; }
        //public virtual Hospital Hospital { get; set; }
        //public virtual Appointment Appointment { get; set; }

    }

}
