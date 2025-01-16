using LightNap.Core.Data;
using LightNap.Core.Data.Entities.ChatEntities;
using LightNap.Core.Interfaces;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LightNap.Core.ChatRoom.Services
{
    public interface IMessageService 
    {
        Task<IEnumerable<Message>> GetMessageHistory(int roomId);
    }

    public class MessageService : IMessageService
    {

        private readonly ApplicationDbContext _context;

        public MessageService(ApplicationDbContext context, IUserContext userContext)
        {
            _context = context;
        }

        public async Task<IEnumerable<Message>> GetMessageHistory(int roomId)
        {
            var messages = await _context.Messages.Where(x => x.RoomId == roomId).ToListAsync();
            return messages;
        }


    }
}
