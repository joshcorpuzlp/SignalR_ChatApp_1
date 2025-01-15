using LightNap.Core.Data;
using LightNap.Core.Data.Entities.ChatEntities;
using LightNap.Core.Interfaces;
using Microsoft.AspNetCore.SignalR;
using Microsoft.EntityFrameworkCore;

namespace LightNap.Core.Services;

public class ChatHub : Hub
{
    private readonly ApplicationDbContext _context;
    private readonly IUserContext _userContext;

    public ChatHub(ApplicationDbContext context, IUserContext userContext) 
    {
        _context = context;
        _userContext = userContext;
    }

    public async Task JoinRoom(string roomName) 
    {
        var room = _context.Rooms.FirstOrDefault(r => r.Name == roomName);
        if (room == null) 
        {
            room = new Room { Name = roomName };
            _context.Rooms.Add(room);
        }

        var user = _context.Users.FirstOrDefault(u => u.Id == _userContext.GetUserId());

        var userRoom = _context.UserRooms.FirstOrDefault(c => c.UserId == user!.Id && c.RoomId == room.Id && Context.ConnectionId == c.ConnectionId);
        if (userRoom == null) 
        {
            userRoom = new UserRoom 
            {
                UserId = _userContext.GetUserId(),
                RoomId = room.Id,
                ConnectionId = Context.ConnectionId,
                CreatedDate = DateTime.UtcNow
            };
            _context.UserRooms.Add(userRoom);
            await _context.SaveChangesAsync();
        }

        await Groups.AddToGroupAsync(userRoom.ConnectionId, roomName);
        await Clients.Group(roomName).SendAsync("ReceiveMessage", "System", $"{user!.UserName} has joined the room.");
        await SendConnectedUsers(room);
    }

    // public async Task SendMessage(string message) 
    // {
    //     var userRoom = _context.UserRooms.FirstOrDefault(ur => ur.ConnectionId == Context.ConnectionId);
    //     if (userRoom != null) 
    //     {
    //         var room = _context.Rooms.FirstOrDefault(r => r.Id == userRoom.RoomId);
    //         await Clients.Group(room!.Name).SendAsync("ReceiveMessage", "System", message, DateTime.Now);
    //         _context.Messages.Add(new Message 
    //         {
    //             ChatMessage = message,
    //             RoomId = room.Id,
    //             SentByUserId = _userContext.GetUserId(),
    //             CreateDate = DateTime.UtcNow,
    //         });
    //         await _context.SaveChangesAsync();
    //     }
    //     return;
    // }

    public async Task SendMessage(string message, int roomId) 
    {
        var room = _context.Rooms.FirstOrDefault(r => r.Id == roomId);
        await Clients.Group(room!.Name).SendAsync("ReceiveMessage", "System", message, DateTime.Now);
        _context.Messages.Add(new Message 
        {
            ChatMessage = message,
            RoomId = roomId,
            SentByUserId = _userContext.GetUserId(),
            CreateDate = DateTime.UtcNow,
        });
        await _context.SaveChangesAsync();
        return;
    }

    public override Task OnDisconnectedAsync(Exception? exception)
    {
        var userRoom = _context.UserRooms.FirstOrDefault(ur => ur.ConnectionId == Context.ConnectionId);
        if (userRoom == null) 
        {
            return base.OnDisconnectedAsync(exception);
        }
        var room = _context.Rooms.FirstOrDefault(r => r.Id == userRoom.RoomId);
        var user = _context.Users.FirstOrDefault(u => u.Id == _userContext.GetUserId());

        Clients.Group(room!.Name).SendAsync("ReceiveMessage", "System", $"{user!.UserName} has left the room", DateTime.UtcNow);
        _context.UserRooms.Remove(userRoom);
        _context.SaveChanges();
        
        SendConnectedUsers(room);
        return base.OnDisconnectedAsync(exception);
    }

    public async Task LeaveRoom(int roomId) 
    {
        var userRoom = _context.UserRooms.FirstOrDefault(ur => ur.UserId == _userContext.GetUserId() && ur.RoomId == roomId);
        if (userRoom != null) 
        {
            var room = _context.Rooms.FirstOrDefault(r => r.Id == userRoom.RoomId);
            var user = _context.Users.FirstOrDefault(u => u.Id == _userContext.GetUserId());

            await Clients.Group(room!.Name).SendAsync("ReceiveMessage", "System", $"{user!.UserName} has left the room", DateTime.UtcNow);
            await _context.UserRooms.Where(ur => ur.UserId == user.Id && ur.RoomId == roomId).ExecuteDeleteAsync();
            _context.SaveChanges();
            
            await SendConnectedUsers(room);
        }
    }

    public Task SendConnectedUsers(Room room) 
    {
        // var room = _context.Rooms.FirstOrDefault(r => r.Id == roomId);
        var userRoomUserIds = _context.UserRooms.Where(ur => ur.RoomId == room.Id).Select(u => u.UserId);
        var users = _context.Users.Where(u => userRoomUserIds.Contains(u.Id)).ToList();

        return Clients.Group(room!.Name).SendAsync("ConnectedUser", users);
    }
    
}
