using BackendCore.Entities.Entities.Base;

namespace BackendCore.Entities.Entities
{
    public class Employee : BaseEntity<int>
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public int RegionId { get; set; }
        public virtual Region Region { get; set; }

    }
}
