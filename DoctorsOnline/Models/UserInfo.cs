using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace DoctorsOnline.Models
{
    public class UserInfo
    {
        public int Id { get; set; }
        [Display(Name = "First Name")]
        public string FirstName { get; set; }
        [Display(Name = "Last Name")]
        public string LastName { get; set; }
        [DataType(DataType.EmailAddress, ErrorMessage = "Email address is not valid")]
        public string Email { get; set; }
        [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}", ApplyFormatInEditMode = true)]
        [Display(Name = "Date of Birth")]
        public DateTime DateOfBirth { get; set; }
        public string Gender { get; set; }
        public virtual User User { get; set; }
    }
}