using Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace DoctorsOnline.Models
{
    public class Location
    {
        public int Id { get; set; }
        public string LocationName { get; set; }
        public ICollection<Division> Divisions { get; set; }
        public ICollection<District> Districts { get; set; }
        public ICollection<Thana> Thanas { get; set; }
    }
}