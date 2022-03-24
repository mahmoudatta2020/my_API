using System;
using System.Collections.Generic;

namespace my_API.Models
{
    public partial class UserInfo1
    {
        public int UserId { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string UserName { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
        public DateTime CreateDateTime { get; set; }
    }
}
