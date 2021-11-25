using Microsoft.AspNetCore.Mvc;
using HospitalLibrary.GraphicalEditor.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using HospitalAPI.EditorService;

namespace HospitalAPI.Controller
{
    [Route("api/[controller]")]
    [ApiController]
    public class RoomController : ControllerBase
    {


        public RoomService roomService;
        public RoomController(RoomService roomService)
        {
            this.roomService = roomService;
        }


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
