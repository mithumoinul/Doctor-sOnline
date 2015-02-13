using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model
{
    public class DoctorsInfo
    {
        public int Id { get; set; }
        public string DoctorName { get; set; }
        public string Qualification { get; set; }
        public string Specialist { get; set; }
        public string Gender { get; set; }
        public DateTime VisitingTime { get; set; }
        public virtual Hospital Hospital { get; set; }
        public virtual Department Department { get; set; }
        public virtual ICollection<Appointment> Appointments { get; set; }

    }

}
