
namespace LightNap.Core.Data.Entities.ChatEntities;
public class Room
{
    public int Id { get; set; }

    public string Name { get; set; } = string.Empty;

    public ICollection<ApplicationUser> Users { get; set; } = [];
}

public class RoomDto
{
    public int Id { get; set; }
    public string Name { get; set; } = string.Empty;
}
