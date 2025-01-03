using LightNap.Core.Data.Entities;

namespace LightNap.Core.Data.Entiies.ChatEntities;

public class Room
{
    public int Id { get; set; }

    public string Name { get; set; } = string.Empty;

    public ICollection<ApplicationUser> Users { get; set; } = [];
}
