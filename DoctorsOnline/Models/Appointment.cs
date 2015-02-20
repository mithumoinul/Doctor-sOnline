using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations.Schema;
using DoctorsOnline.Models;
using System.ComponentModel.DataAnnotations;
using System.Globalization;


namespace Model
{
    public class Appointment
    {
        [DatabaseGeneratedAttribute(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }

        public int AppointmentNo { get; set; }


        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}", ApplyFormatInEditMode = true)]
        public Nullable<System.DateTime> AppointmentDate { get; set; }
        // public DateTime AppointmentTime { get; set; }
        [DataType(DataType.Time)]
        [DisplayFormat(ApplyFormatInEditMode = true, DataFormatString = "{0:H:mm}")]
        [Display(Name = "AppointmentTime")]
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
