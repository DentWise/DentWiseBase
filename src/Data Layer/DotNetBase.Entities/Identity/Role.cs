using DotNetBase.Entities.Abstract;

namespace DotNetBase.Entities.Identity
{
    public class Role : BaseEntity
    {
        public string Name { get; set; }


        // Navigation property
        public ICollection<User> Users { get; set; }

    }
}
