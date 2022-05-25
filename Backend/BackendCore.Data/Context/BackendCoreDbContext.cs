using BackendCore.Common.Services;
using BackendCore.Data.Configuration;
using BackendCore.Data.DataInitializer;
using BackendCore.Entities.Entities;
using Microsoft.EntityFrameworkCore;

namespace BackendCore.Data.Context
{
    public partial class BackendCoreDbContext : DbContext
    {
        private readonly IDataInitializer _dataInitializer;
        private readonly IClaimService _claimService;
        public BackendCoreDbContext(DbContextOptions<BackendCoreDbContext> options, IDataInitializer dataInitializer, IClaimService claimService) : base(options)
        {
            _dataInitializer = dataInitializer;
            _claimService = claimService;
        }

        public virtual DbSet<Employee> Employees { get; set; }
        public virtual DbSet<Region> Region { get; set; }

        #region Overriden Methods
        /// <summary>
        /// On Model Creating
        /// </summary>
        /// <param name="modelBuilder"></param>
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            #region Configuration
            modelBuilder.ApplyConfiguration(new RegionConfig());
            #endregion

            #region Seed
            modelBuilder.Entity<User>().HasData(_dataInitializer.SeedUsers());
            #endregion
            base.OnModelCreating(modelBuilder);
        }


        #endregion

        #region Private Methods
        #endregion

    }
}
