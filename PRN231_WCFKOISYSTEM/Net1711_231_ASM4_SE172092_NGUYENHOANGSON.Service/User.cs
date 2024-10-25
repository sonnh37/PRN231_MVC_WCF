using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Net1711_231_ASM4_SE172092_NGUYENHOANGSON.Service
{
    public class User
    {
        public Guid Id { get; set; }

        public string Image { get; set; }

        public string Firstname { get; set; }

        public string Lastname { get; set; }

        public string Address { get; set; }

        public string Gender { get; set; }

        public string Role { get; set; }

        public string Username { get; set; }

        public string Password { get; set; }

        public string Phone { get; set; }

        public string Email { get; set; }

        public string CreatedBy { get; set; }

        public DateTime CreatedDate { get; set; }

        public string UpdatedBy { get; set; }

        public DateTime UpdatedDate { get; set; }

        public bool IsDeleted { get; set; }

        public string Note { get; set; }
    }
}