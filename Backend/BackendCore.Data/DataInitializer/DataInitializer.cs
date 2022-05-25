using System;
using System.Collections.Generic;
using BackendCore.Common.Extensions;
using BackendCore.Entities.Entities;

namespace BackendCore.Data.DataInitializer
{
    public class DataInitializer : IDataInitializer
    {
        #region Public Methods
        
        /// <summary>
        /// Seed Users
        /// </summary>
        /// <returns></returns>
        public IEnumerable<User> SeedUsers()
        {
            var userList = new List<User>();
            userList.AddRange(new[]
            {
                new User
                {
                    Id =  Guid.Parse("abcc43c2-f7b8-4d70-8c1e-81bc61cb4518"),
                    Email = "Admin@admin.com",
                    IsDeleted = false,
                    UserName = "admin",
                    Password = CryptoHasher.HashPassword("123456"),
                    CreatedDate = new DateTime(2022, 5, 1),
                    ModifiedDate = new DateTime(2022, 5, 1)
                }

            });

            return userList.ToArray();
        }

        #endregion

    }
}