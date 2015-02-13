using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model
{
    public class District
    {
        public int Id { get; set; }
        public string DistrictName { get; set; }
        public virtual ICollection<Thana> Thanas { get; set; }
    }

}
