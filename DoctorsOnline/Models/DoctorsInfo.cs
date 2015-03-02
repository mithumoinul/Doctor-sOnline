using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DoctorsOnline.Models;

namespace Model
{
    public class DoctorsInfo
    {
     
        [Key]
        //[ScaffoldColumn(false)]
        public int Id { get; set; }
        [Required(ErrorMessage = "Doctor's name required")]
        [DisplayName("Doctor's Name :")]
        public string DoctorName { get; set; }
        public string Qualification { get; set; }
        public string Designation { get; set; }
        [DisplayName("Specialist In :")]
        public string Specialist { get; set; }
        public string Experience { get; set; }
        public string Gender { get; set; }
        [StringLength(12,ErrorMessage = "Phone number is not valid")]
        public string Phone { get; set; }
        [Required(ErrorMessage = "Please enter a valid e-mail address")]
        [DataType(DataType.EmailAddress)]
        public string Email { get; set; }
        
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
        public int ChamberId { get; set; }
        [ForeignKey("ChamberId")]
        public virtual Chamber Chamber { get; set; }
        public ICollection<Location> Locations { get; set; }
        public virtual ICollection<Appointment> Appointments { get; set; }


    }

}
