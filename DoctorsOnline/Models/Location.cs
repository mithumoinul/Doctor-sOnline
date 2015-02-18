using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Model;

namespace DoctorsOnline.Models
{
    public class Location
    {
        public int Id { get; set; }
        public string LocationName { get; set; }
        public virtual Thana Thana { get; set; }
        public virtual District District { get; set; }
        public virtual ICollection<Organization> Organizations { get; set; }
        public virtual ICollection<Hospital> Hospitals { get; set; }
        public virtual ICollection<Chamber> Chambers { get; set; } 
    }
}