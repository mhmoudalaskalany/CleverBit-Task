using System;
using BackendCore.Common.Core;

namespace BackendCore.Common.DTO.User
{
    public class AddUserDto : IEntityDto<Guid?>
    {
        public Guid? Id { get; set; }
        public string UserName { get; set; }
        public string Password { get; set; }
        public string Email { get; set; }
    }
}
