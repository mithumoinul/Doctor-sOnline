using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model
{
    public class Hospital
    {
        public int Id { get; set; }
        public string HospitalName { get; set; }
        public int TotalDoctor { get; set; }
        public string Address { get; set; }
        public string Phone { get; set; }
        public int AreaId { get; set; }
        [ForeignKey("AreaId")]
        public virtual Area Area { get; set; }
        public virtual ICollection<DoctorsInfo> DoctorsInfos { get; set; }
        public virtual ICollection<Patient> Patients { get; set; }
        public virtual ICollection<Department> Departments { get; set; }

    }

}
