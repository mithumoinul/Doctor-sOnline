using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model
{
    public enum Role
    {
        Client, Doctor, Admin, HospitalManager
    }
    public class UserRole
    {
        public int Id { get; set; }
        public Role? RoleName { get; set; }
        public DateTime CreateDate { get; set; }
        public DateTime ActionDate { get; set; }
        public bool IsActive { get; set; }
        public User User { get; set; }

    }

}
