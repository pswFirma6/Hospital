using AutoMapper;
using Hospital_API.DTO.SurveyDTO;
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
        [Route("InitializeSurvey")]
        public IActionResult InitializeSurvey()
        {
            TakeSurveyDTO surveyQuestionHospital1 = new TakeSurveyDTO("HospitalQuestion1", Hospital_library.MedicalRecords.Model.Enums.SurveyQuestionCategory.hospital);
            TakeSurveyDTO surveyQuestionHospital2 = new TakeSurveyDTO("HospitalQuestion2", Hospital_library.MedicalRecords.Model.Enums.SurveyQuestionCategory.hospital);
            TakeSurveyDTO surveyQuestionHospital3 = new TakeSurveyDTO("HospitalQuestion3", Hospital_library.MedicalRecords.Model.Enums.SurveyQuestionCategory.hospital);
            TakeSurveyDTO surveyQuestionHospital4 = new TakeSurveyDTO("HospitalQuestion4", Hospital_library.MedicalRecords.Model.Enums.SurveyQuestionCategory.hospital);
            TakeSurveyDTO surveyQuestionHospital5 = new TakeSurveyDTO("HospitalQuestion5", Hospital_library.MedicalRecords.Model.Enums.SurveyQuestionCategory.hospital);

            TakeSurveyDTO surveyQuestionStaff1 = new TakeSurveyDTO("StaffQuestion1", Hospital_library.MedicalRecords.Model.Enums.SurveyQuestionCategory.staff);
            TakeSurveyDTO surveyQuestionStaff2 = new TakeSurveyDTO("StaffQuestion2", Hospital_library.MedicalRecords.Model.Enums.SurveyQuestionCategory.staff);
            TakeSurveyDTO surveyQuestionStaff3 = new TakeSurveyDTO("StaffQuestion3", Hospital_library.MedicalRecords.Model.Enums.SurveyQuestionCategory.staff);
            TakeSurveyDTO surveyQuestionStaff4 = new TakeSurveyDTO("StaffQuestion4", Hospital_library.MedicalRecords.Model.Enums.SurveyQuestionCategory.staff);
            TakeSurveyDTO surveyQuestionStaff5 = new TakeSurveyDTO("StaffQuestion5", Hospital_library.MedicalRecords.Model.Enums.SurveyQuestionCategory.staff);

            TakeSurveyDTO surveyQuestionApplication1 = new TakeSurveyDTO("ApplicationQuestion1", Hospital_library.MedicalRecords.Model.Enums.SurveyQuestionCategory.application);
            TakeSurveyDTO surveyQuestionApplication2 = new TakeSurveyDTO("ApplicationQuestion2", Hospital_library.MedicalRecords.Model.Enums.SurveyQuestionCategory.application);
            TakeSurveyDTO surveyQuestionApplication3 = new TakeSurveyDTO("ApplicationQuestion3", Hospital_library.MedicalRecords.Model.Enums.SurveyQuestionCategory.application);
            TakeSurveyDTO surveyQuestionApplication4 = new TakeSurveyDTO("ApplicationQuestion4", Hospital_library.MedicalRecords.Model.Enums.SurveyQuestionCategory.application);
            TakeSurveyDTO surveyQuestionApplication5 = new TakeSurveyDTO("ApplicationQuestion5", Hospital_library.MedicalRecords.Model.Enums.SurveyQuestionCategory.application);

            List<TakeSurveyDTO> survey = new List<TakeSurveyDTO>();
            survey.AddRange(new List<TakeSurveyDTO>() {
                surveyQuestionHospital1,
                surveyQuestionHospital2,
                surveyQuestionHospital3,
                surveyQuestionHospital4,
                surveyQuestionHospital5,

                surveyQuestionStaff1,
                surveyQuestionStaff2,
                surveyQuestionStaff3,
                surveyQuestionStaff4,
                surveyQuestionStaff5,

                surveyQuestionApplication1,
                surveyQuestionApplication2,
                surveyQuestionApplication3,
                surveyQuestionApplication4,
                surveyQuestionApplication5
            });
            return Ok(survey);
        }

        [HttpPost]
        [Route("TakeSurvey")]
        public IActionResult TakeSurvey(List<TakeSurveyDTO> surveyQuestions)
        {
            foreach(TakeSurveyDTO question in surveyQuestions)
            {
                if(question.Rate == 0)
                {
                    return BadRequest();
                }
            }
            return Ok();
        }
    }
}