using System.Collections.Generic;
using BackendCore.Entities.Entities;

namespace BackendCore.Data.DataInitializer
{
    public interface IDataInitializer
    {
        IEnumerable<User> SeedUsers();
    }
}