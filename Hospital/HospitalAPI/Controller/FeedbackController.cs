using AutoMapper;
using HospitalAPI.DTO;
using HospitalAPI.Validation;
using HospitalLibrary.MedicalRecords.Model;
using HospitalLibrary.MedicalRecords.Service;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;

namespace HospitalAPI.Controller
{
    [Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme)]
    [Route("api/[controller]")]
    [ApiController]
    public class FeedbackController : ControllerBase
    {
        private readonly IFeedbackService _feedbackService;

        private readonly IMapper _mapper;

        private FeedbackValidation _feedbackValidation;

        public FeedbackController(IFeedbackService feedbackService, IMapper mapper, FeedbackValidation feedbackValidation)
        {
            _feedbackService = feedbackService;
            _mapper = mapper;
            _feedbackValidation = feedbackValidation;
        }

        [Authorize(Roles  = "patient")]
        [HttpGet]
        [Route("{Approved}")]
        public IActionResult GetApprovedFeedbacks()
        {
            return Ok(_feedbackService.GetAllApproved());
        }

        [Authorize(Roles = "patient")]
        [HttpPost]
        [Route("{leave}")]
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
            var model = _mapper.Map<Feedback>(dto);
            _feedbackService.ChangeState(model.Id, dto.State);
            return Ok();
        } 
    }
}
