namespace LightNap.Core.Data.Entities.ChatEntities;

public class UserRoom
{
    public string UserId { get; set; }
    public int RoomId { get; set; }
    public string ConnectionId { get; set; }
    public DateTime CreatedDate { get; set; } = DateTime.UtcNow;
}
