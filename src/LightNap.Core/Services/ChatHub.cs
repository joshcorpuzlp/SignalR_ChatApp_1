using LightNap.Core.Data;
using LightNap.Core.Data.Entities.ChatEntities;
using LightNap.Core.Interfaces;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Routing.Patterns;
using Microsoft.AspNetCore.SignalR;
using Microsoft.EntityFrameworkCore;
using static Microsoft.EntityFrameworkCore.DbLoggerCategory.Database;

namespace LightNap.Core.Services;

public class ChatHub : Hub
{
    private readonly ApplicationDbContext _context;
    //private readonly IUserContext _userContext;

    public ChatHub(
        ApplicationDbContext context
        //,IUserContext userContext
        ) 
    {
        _context = context;
        //_userContext = userContext;
    }

    private string _userId;

    // how do we let signalR know about existing rooms and the connections there in.

    public async Task JoinRoom(string userId, string roomName) 
    {
        var room = _context.Rooms.FirstOrDefault(r => r.Name == roomName);
        if (room == null) 
        {
            room = new Room { Name = roomName };
            _context.Rooms.Add(room);
        }

        var user = _context.Users.FirstOrDefault(u => u.Id == userId);

        var userRoom = await _context.UserRooms.FirstOrDefaultAsync(c => c.UserId == userId && c.RoomId == room.Id && c.ConnectionId == Context.ConnectionId);
        if (userRoom == null) 
        {
            userRoom = new  UserRoom  
            {
                UserId = userId,
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


    public async Task SendMessage(string message, int roomId, string userId) 
    {
        var room = _context.Rooms.FirstOrDefault(r => r.Id == roomId);
        await Clients.Group(room!.Name).SendAsync("ReceiveMessage", "System", message, DateTime.Now);
        _context.Messages.Add(new Message 
        {
            ChatMessage = message,
            RoomId = roomId,
            SentByUserId = userId,
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
        var user = _context.Users.FirstOrDefault(u => u.Id == userRoom.UserId);
        _context.UserRooms.Remove(userRoom);
        _context.SaveChanges();
        
        Groups.RemoveFromGroupAsync(userRoom.ConnectionId, room.Name);


        if (user != null && room != null)
        {
            if (_context.UserRooms.FirstOrDefault(x => x.UserId == user.Id && x.RoomId == room.Id) == null)
            {
                Clients.Group(room!.Name).SendAsync("ReceiveMessage", "System", $"{user!.UserName} has left the room", DateTime.UtcNow);
            }

            var task = Task.Run(async () =>
            {
                await SendConnectedUsers(room);
            });
        }

        return base.OnDisconnectedAsync(exception);
    }

    public async Task LeaveRoom(int roomId, string userId) 
    {
        var userConnectionsInRoom = await _context.UserRooms.Where(ur => ur.UserId == userId && ur.RoomId == roomId).ToListAsync();
        var room = _context.Rooms.FirstOrDefault(x => x.Id == roomId);
        var user = _context.Users.FirstOrDefault(u => u.Id == userId);
        if (userConnectionsInRoom.Count > 0 && room != null)
        {

            foreach(var connection in userConnectionsInRoom)
            {
                await Groups.RemoveFromGroupAsync(connection.ConnectionId, room.Name);
            }

            await Clients.Group(room!.Name).SendAsync("ReceiveMessage", "System", $"{user!.UserName} has left the room", DateTime.UtcNow);
            await _context.UserRooms.Where(ur => ur.UserId == user.Id && ur.RoomId == roomId).ExecuteDeleteAsync();
            _context.SaveChanges();

            await SendConnectedUsers(room);
        }
    }

    public async Task SendConnectedUsers(Room room) 
    {
        var userRoomUserIds = await _context.UserRooms.Where(ur => ur.RoomId == room.Id).Select(x => x.UserId).ToListAsync();
        var users = await _context.Users.Where(x => userRoomUserIds.Contains(x.Id)).Select(x => new
        {
            UserId = x.Id,
            Name = x.UserName
        }).ToListAsync();
        await Clients.Group(room!.Name).SendAsync("ConnectedUser", users);
    }
    
}
