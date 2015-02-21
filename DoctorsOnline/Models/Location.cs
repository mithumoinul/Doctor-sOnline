using System.ComponentModel.DataAnnotations.Schema;
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
        public int DoctorsInfoId { get; set; }
        [ForeignKey("DoctorsInfoId")]
        public DoctorsInfo DoctorsInfo { get; set; }

        public int DivisionId { get; set; }
        [ForeignKey("DivisionId")]
        public Division Divisions { get; set; }

        public int DistrictId { get; set; }
        [ForeignKey("DistrictId")]
        public District Districts { get; set; }

        public int ThanaId { get; set; }
        [ForeignKey("ThanaId")]
        public Thana Thanas { get; set; }
    }
}