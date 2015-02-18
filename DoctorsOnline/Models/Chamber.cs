using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;
using Model;

namespace DoctorsOnline.Models
{
    public class Chamber
    {
        public int Id { get; set; }
        public string ChamberName { get; set; }
        public string Phone { get; set; }
        public string Email { get; set; }
        public virtual Location Location { get; set; }
        public virtual ICollection<DoctorsInfo> DoctorsInfos { get; set; }
        public virtual ICollection<Appointment> Appointments { get; set; }
    }
}