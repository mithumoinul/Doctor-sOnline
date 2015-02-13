using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model
{
    public class Area
    {
        public int Id { get; set; }
        public string AreaName { get; set; }
        public virtual Thana Thana { get; set; }
        public virtual ICollection<Hospital> Hospitals { get; set; }
    }

}
