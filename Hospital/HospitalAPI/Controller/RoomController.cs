using Microsoft.AspNetCore.Mvc;
using project.Model;
using project.Service;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace project.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class RoomController : ControllerBase
    {


        public RoomService roomService = new RoomService();



        [HttpGet]
        public IActionResult GetAll()
        {
            return Ok(roomService.getAll());
        }

        [HttpPost]      // kreiranje  , put update
        public IActionResult Create(Room room)
        {
            roomService.create(room);
            return Ok();
        }

    }
}
