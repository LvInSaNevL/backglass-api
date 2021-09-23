using System;

namespace USER_API
{
    public class UserInfo
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }
        public string Phone { get; set; }
        public string Password { get; set; }
        public string Home { get; set; }
    }

    public class UserIFPAStats 
    {
        public string PlayerID { get; set; }
        public string City { get; set; }
        public string State { get; set; }
        public string Country { get; set; }
        public string Rank { get; set; }
    }
}