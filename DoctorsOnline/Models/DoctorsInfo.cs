using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
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
        [DataType(DataType.Time)]
        [DisplayFormat(ApplyFormatInEditMode = true, DataFormatString = "{0:H:mm}")]
        [Display(Name="Visit Start")]
        public DateTime VisitStartTime { get; set; }
        
        [DataType(DataType.Time)]
        [DisplayFormat(ApplyFormatInEditMode = true, DataFormatString = "{0:H:mm}")]
        [Display(Name="Visit End")]
        public DateTime VisitEndTime { get; set; }

        public int HospitalId { get; set; }
        [ForeignKey("HospitalId")]
        public virtual Hospital Hospital { get; set; }
        public int DepartmentId { get; set; }
        [ForeignKey("DepartmentId")]
        public virtual Department Department { get; set; }
        public virtual ICollection<Appointment> Appointments { get; set; }

    }

}
