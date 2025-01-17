using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using LightNap.Core.Data;
using LightNap.Core.Interfaces;
using LightNap.Core.Data.Entities.ChatEntities;
using Microsoft.EntityFrameworkCore;
using LightNap.Core.Api;

namespace LightNap.Core.ChatRoom.Service
{
    public interface IRoomService
    {
        Task<IEnumerable<RoomDto>> GetRooms();
        Task CreateRoom(string name);
    }


    public class RoomService : IRoomService
    {
        private readonly ApplicationDbContext _context;
        public RoomService(ApplicationDbContext context, IUserContext userContext)
        {
            _context = context;
        }
        public async Task<IEnumerable<RoomDto>> GetRooms()
        {
            var roomDtos = await _context.Rooms.Select(x => new RoomDto()
            {
               Id = x.Id,
               Name = x.Name
            }).ToListAsync();
            return roomDtos;
        }

        /// <summary>
        /// Adds a room.
        /// </summary>
        /// <param name="name">The name of the room.</param>
        public async Task CreateRoom(string name)
        {
            var room = await _context.Rooms.Where(x => x.Name == name).FirstOrDefaultAsync();
            if (room == null)
            {
                var newRoom = new Room
                {
                    Name = name
                };
                await _context.Rooms.AddAsync(newRoom);
                _context.SaveChanges();
            }
            else
            {
                throw new UserFriendlyApiException($"Room with the given name {name} already exists");
            }
        }
    }
}
