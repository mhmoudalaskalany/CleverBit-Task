using System;

namespace BackendCore.Common.DTO.Login
{
    public class UserLoginReturn
    {
        public string Token { get; set; }
        public DateTime TokenValidTo { get; set; }
        public object UserId { get; set; }
        public string Name { get; set; }
    }
}