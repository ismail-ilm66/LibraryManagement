using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LibraryManagement.Models
{
    public class Member
    {
        public int MemberId { get; set; }
        public string Name { get; set; }
        public string MembershipID { get; set; }
        public string Password { get; set; }
        public string PhoneNumber { get; set; }
        public string Address { get; set; }

        public string Role { get; set; } // "Staff" or "Member"
    }
}
