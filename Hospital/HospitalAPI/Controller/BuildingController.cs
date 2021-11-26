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
    public class BuildingController : ControllerBase
    {


        public BuildingService buildingService;

        public BuildingController(BuildingService buildingService)
        {
            this.buildingService = buildingService;
        }




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
