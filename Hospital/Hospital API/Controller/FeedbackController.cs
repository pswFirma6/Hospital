using AutoMapper;
using Hospital_API.DTO;
using Hospital_API.Service;
using Hospital_library.MedicalRecords.Model.Enums;
using Hospital_library.Model;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;

namespace Hospital_API.Controller
{
    [Route("api/[controller]")]
    [ApiController]
    public class FeedbackController : ControllerBase
    {
        private FeedbackService _feedbackService;

        // Create a field to store the mapper object
        private readonly IMapper _mapper;

        private List<FeedbackResponseDTO> feedbacks = new List<FeedbackResponseDTO>();

        // Assign the object in the constructor for dependency injection

        public FeedbackController(FeedbackService feedbackService, IMapper mapper)
        {
            _feedbackService = feedbackService;
            _mapper = mapper;
        }

        [HttpGet]
        [Route("{Approved}")]
        public IActionResult GetApprovedFeedbacks()
        {
            return Ok(_feedbackService.GetAllApproved());
        }

        [HttpPost]
        public IActionResult Add(FeedbackDTO dto) 
        {
            if (dto.Text.Length <= 0 || String.IsNullOrEmpty(dto.PersonId)) 
            {
                return BadRequest();   
            }
           
            var model = _mapper.Map<Feedback>(dto);
            _feedbackService.Add(model);
                
            return Ok();
        }

        [HttpGet]
        public IActionResult GetFeedbacks()
        {
            List<Feedback> feedbacks = _feedbackService.GetAll();
            return Ok(feedbacks);
        }
        [HttpPut]
        public IActionResult ApproveFeedback(FeedbackStateChangeDTO dto)
        {
            _feedbackService.ChangeState(dto.Id, dto.State);
            return Ok();
        } 
    }
}
