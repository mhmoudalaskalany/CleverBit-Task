using BackendCore.Entities.Entities;
using Microsoft.EntityFrameworkCore;

namespace BackendCore.Data.Context
{
    public partial class BackendCoreDbContext
    {
        #region Identity Entities
        public virtual DbSet<User> Users { get; set; }
        #endregion

    }
}
