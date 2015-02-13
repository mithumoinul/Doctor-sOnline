using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model
{
    public class Thana
    {
        public int Id { get; set; }

        public string ThanaName { get; set; }

        public int DistrictId { get; set; }
        [ForeignKey("DistrictId")]

        public virtual District District { get; set; }

        public virtual ICollection<Area> Areas { get; set; }
    }

}
