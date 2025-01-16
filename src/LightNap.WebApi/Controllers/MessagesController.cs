using LightNap.Core.ChatRoom.Services;
using LightNap.Core.Data.Entities.ChatEntities;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace LightNap.WebApi.Controllers
{
    [Authorize]
    [ApiController]
    [Route("api/[controller]")]
    public class MessagesController : ControllerBase
    {
        private readonly IMessageService _messageService;
        public MessagesController(IMessageService messageService)
        {
            _messageService = messageService;
        }

        [HttpGet("get-message-history/{roomId}")]
        public async Task<IEnumerable<Message>> GetMessageHistory(int roomId)
        {
            return await _messageService.GetMessageHistory(roomId);
        }
    }
}
