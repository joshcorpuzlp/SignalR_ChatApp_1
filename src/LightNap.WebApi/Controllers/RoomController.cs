using LightNap.Core.ChatRoom.Service;
using LightNap.Core.Data.Entities.ChatEntities;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace LightNap.WebApi.Controllers
{
    [ApiController]
    [Authorize]
    [Route("api/[controller]")]
    public class RoomController : ControllerBase
    {
        private readonly IRoomService _roomService;
        public RoomController(IRoomService roomService)
        {
                _roomService = roomService;
        }
        // GET: api/<RoomsController>
        [HttpGet]
        public IEnumerable<string> Get()
        {
            return new string[] { "value1", "value2" };
        }

        // GET api/<RoomsController>/5
        [HttpGet("{id}")]
        public string Get(int id)
        {
            return "value";
        }

        [HttpGet("get-rooms")]
        public async Task<IEnumerable<RoomDto>> GetRooms()
        {
            return await _roomService.GetRooms();
        }

        // POST api/<RoomsController>
        [HttpPost("create-room/{roomName}")]
        public async Task Post(string roomName)
        {
            await _roomService.CreateRoom(roomName);
        }

        // PUT api/<RoomsController>/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
        }

        // DELETE api/<RoomsController>/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
