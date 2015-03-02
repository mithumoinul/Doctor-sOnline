using System;
using System.ComponentModel.DataAnnotations;
using Microsoft.AspNet.Identity.EntityFramework;

namespace DoctorsOnline.Models
{
    // You can add profile data for the user by adding more properties to your ApplicationUser class, please visit http://go.microsoft.com/fwlink/?LinkID=317594 to learn more.
    public class ApplicationUser : IdentityUser
    {
    //    [Display(Name = "First Name")]
    //    public string FirstName { get; set; }
    //    [Display(Name="Last Name")]
    //    public string LastName { get; set; }
    //    [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}",ApplyFormatInEditMode = true)]
    //    [Display(Name="Date of Birth")]
    //    public DateTime DateOfBirth { get; set; }
    //    [DataType(DataType.EmailAddress,ErrorMessage = "Email address is not valid")]
    //    public string  Email { get; set; }

    }

    public class ApplicationDbContext : IdentityDbContext<ApplicationUser>
    {
        public ApplicationDbContext()
            : base("DefaultConnection")
        {
        }
    }
}