using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace DoctorsOnline.Models
{
    public class User
    {
        public int Id { get; set; }
        public string UserName { get; set; }
        public int UserInfoId { get; set; }
        [ForeignKey("UserInfoId")]
        public virtual UserInfo UserInfos { get; set; }
    }
}