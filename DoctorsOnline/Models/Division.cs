using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Model;
using System.ComponentModel.DataAnnotations.Schema;

namespace DoctorsOnline.Models
{
    public class Division
    {
        public int DivisionId { get; set; }
        public string DivisionName { get; set; }
        public virtual ICollection<District> Districts { get; set; }
        public int LocationId { get; set; }
        [ForeignKey("LocationId")]
        public Location Location { get; set; }
    }
}