using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace DoctorsOnline.Models
{
    public class Prescription
    {
        public int PrescriptionId { get; set; }

        [Display(Name="User Name")]
        public string UserName { get; set; }

        [Display(Name = "Patient First Name")]
        public string PatientFirstName { get; set; }

        [Display(Name = "Patient Last Name")]
        public string PatientLastName { get; set; }

        [Display(Name="Date Of Birth")]
        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}", ApplyFormatInEditMode = true)]
        public DateTime PatientDOB { get; set; }

        [Display(Name="Symption of Patient")]
        public string PatientSymption { get; set; }

        [Display(Name="Others Information: Exp. Medicine")]
        public string OthersInfo { get; set; }

        [Display(Name="Request Submission Date")]
        [DataType(DataType.Date)]

        [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}")]
        public DateTime RequestDate { get; set; }

        [Display(Name="Doctor Prescrition")]
        public string  DocPrescrition { get; set; }

        [Display(Name="Submission Date")]
        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}")]
        public DateTime SubmissionDate { get; set; }
 
    }
}