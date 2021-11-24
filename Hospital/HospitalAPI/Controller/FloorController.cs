using Microsoft.AspNetCore.Mvc;
using HospitalLibrary.GraphicalEditor.Model;
using HospitalLibrary.GraphicalEditor.Service;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HospitalAPI.Controller
{

    [Route("api/[controller]")]
    [ApiController]
    public class FloorController : ControllerBase
    {


        public FloorService floorService = new FloorService();


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
