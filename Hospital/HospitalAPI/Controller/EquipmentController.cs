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
    public class EquipmentController : ControllerBase
    {
        public EquipmentService equipmentService;

        public EquipmentController(EquipmentService equipmentService)
        {
            this.equipmentService = equipmentService;
        }




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
