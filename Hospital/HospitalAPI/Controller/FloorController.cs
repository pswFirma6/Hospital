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
    public class FloorController : ControllerBase
    {


        public FloorService floorService;
        public FloorController(FloorService floorService)
        {
            this.floorService = floorService;
        }

        [HttpGet]
        public IActionResult GetAll()
        {
            return Ok(floorService.getAll());
        }

        [HttpPost]      // kreiranje  , put update
        public IActionResult Create(Floor floor)
        {
            floorService.create(floor);
            return Ok();
        }


    }
}
