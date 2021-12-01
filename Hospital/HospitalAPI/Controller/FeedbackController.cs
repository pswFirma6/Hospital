using AutoMapper;
using HospitalAPI.DTO;
using HospitalAPI.Service;
using HospitalAPI.Validation;
using HospitalLibrary.MedicalRecords.Model;
using HospitalLibrary.MedicalRecords.Service;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;

namespace HospitalAPI.Controller
{
    [Route("api/[controller]")]
    [ApiController]
    public class FeedbackController : ControllerBase
    {
        private IFeedbackService _feedbackService;

        private readonly IMapper _mapper;

        private FeedbackValidation _feedbackValidation;

        public FeedbackController(IFeedbackService feedbackService, IMapper mapper, FeedbackValidation feedbackValidation)
        {
            _feedbackService = feedbackService;
            _mapper = mapper;
            _feedbackValidation = feedbackValidation;
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
            if (!_feedbackValidation.IsValid(dto)) 
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
