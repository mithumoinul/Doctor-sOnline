using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations.Schema;
using DoctorsOnline.Models;

namespace Model
{
    public class Appointment
    {
        public int Id { get; set; }
        public int AppointmentNo { get; set; }
        public DateTime AppointmentTime { get; set; }
        public bool IsActive { get; set; }
        //public virtual DoctorsInfo DoctorsInfo { get; set; }
        public int HospitalId { get; set; }
        [ForeignKey("HospitalId")]
        public virtual Hospital Hospital { get; set; }
        public int ChamberId { get; set; }
        [ForeignKey("ChamberId")]
        public virtual Chamber Chamber { get; set; }

    }

}
