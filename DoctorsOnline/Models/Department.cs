using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DoctorsOnline.Models;

namespace Model
{
    public class Department
    {
        public int Id { get; set; }
        public string DepartmentName { get; set; }
        public virtual Organization Organization { get; set; }
        public virtual Hospital Hospital { get; set; }
        public virtual ICollection<DoctorsInfo> DoctorsInfos { get; set; }

    }

}
