using System.Collections.Generic;
using System.Collections.ObjectModel;
using BackendCore.Entities.Entities.Base;

namespace BackendCore.Entities.Entities
{
    public class Region : BaseEntity<int>
    {
        public string Name { get; set; }
        public int? ParentRegionId { get; set; }
        //public virtual Region ParentRegion { get; set; }
        //public virtual ICollection<Region> ChildRegions { get; set; } = new Collection<Region>();
        //public virtual ICollection<Employee> Employees { get; set; } = new Collection<Employee>();
    }
}
