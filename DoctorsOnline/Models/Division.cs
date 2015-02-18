using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Model;

namespace DoctorsOnline.Models
{
    public class Division
    {
        public int DivisionId { get; set; }
        public string DivisionName { get; set; }
        public virtual ICollection<District> Districts { get; set; }
    }
}