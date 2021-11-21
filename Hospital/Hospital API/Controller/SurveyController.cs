using AutoMapper;
using Hospital_API.DTO;
using Hospital_API.ImplService;
using Hospital_library.MedicalRecords.Model;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;

namespace Hospital_API.Controller
{
    [Route("api/[controller]")]
    [ApiController]
    public class SurveyController : ControllerBase
    {
        private SurveyService _surveyService;
        // Create a field to store the mapper object
        private readonly IMapper _mapper;


        // Assign the object in the constructor for dependency injection

        public SurveyController(SurveyService surveyService, IMapper mapper)
        {
            _surveyService = surveyService;
            _mapper = mapper;
        }

        [HttpGet]
        public IActionResult GetSurvey()
        {
            List<SurveyQuestion> survey = _surveyService.InitializeSurvey();
            return Ok("nice");
        }

        [HttpPost]
        public IActionResult TakeSurvey(SurveyQuestion surveyQuestion)
        {

            return Ok("nice");
        }
    }
}
