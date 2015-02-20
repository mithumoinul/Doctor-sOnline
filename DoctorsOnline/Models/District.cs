using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DoctorsOnline.Models;

namespace Model
{
    public class District
    {
        public int Id { get; set; }
        public string DistrictName { get; set; }
        public int DivisionId { get; set; }
        [ForeignKey("DivisionId")]
        public Division Division { get; set; }
        public virtual ICollection<Thana> Thanas { get; set; }
        //public int LocationId { get; set; }
        //[ForeignKey("LocationId")]
        ////public virtual Location Location { get; set; }
    }

}
