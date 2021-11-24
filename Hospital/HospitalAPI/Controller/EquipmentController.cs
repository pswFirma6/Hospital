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
    public class EquipmentController : ControllerBase
    {


        public EquipmentService equipmentService;



        [HttpGet]
        public IActionResult GetAll()
        {
            return Ok(equipmentService.getAll());
        }

        [HttpPost]      // kreiranje  , put update
        public IActionResult Create(Equipment equipment)
        {
            equipmentService.create(equipment);
            return Ok();
        }


    }
}
