using System;
using BackendCore.Entities.Entities.Base;

namespace BackendCore.Entities.Entities
{
    public class User : BaseEntity<Guid>
    {
        public string UserName { get; set; }
        public string Password { get; set; }
        public string Email { get; set; }
    }
}
