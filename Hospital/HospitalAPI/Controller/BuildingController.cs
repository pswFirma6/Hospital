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
    public class BuildingController : ControllerBase
    {


        public BuildingService buildingService = new BuildingService();



        [HttpGet]
        public IActionResult GetAll()
        {
            return Ok(buildingService.getAll());
        }

        [HttpPost]      // kreiranje  , put update
        public IActionResult Create(Building building)
        {
            buildingService.create(building);
            return Ok();
        }


    }
}
