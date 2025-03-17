using Domain.Common;

namespace Domain.Entities;

public class ActivityType: EntityCatalog
{
    public bool Active { get; set; }

    public ActivityType(string name, bool active = true)
    {
        Name = name;
        Active = active;
    }
    
}