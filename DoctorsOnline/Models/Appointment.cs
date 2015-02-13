using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations.Schema;
namespace Model
{
    public class Appointment
    {
        public int Id { get; set; }
        public int AppointmentNo { get; set; }
        public DateTime AppointmentTime { get; set; }
        public bool IsActive { get; set; }
        //public virtual DoctorsInfo DoctorsInfo { get; set; }
        public int PatientId { get; set; }
        [ForeignKey("PatientId")]
        public virtual Patient Patient { get; set; }

    }

}
