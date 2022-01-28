using Microsoft.AspNetCore.Mvc;
using RestSharp;
using System.Collections.Generic;

namespace HospitalAPI.Controller
{
    [Route("api/[controller]")]
    [ApiController]
    public class AdsController : ControllerBase
    {
        public AdsController()
        {
        }

        [HttpGet]
        public IActionResult GetAds()
        {
            var client = new RestClient("http://localhost:44317/getOffers");
            var request = new RestRequest();

            IRestResponse response = client.Execute(request);

            if (response.StatusCode == System.Net.HttpStatusCode.OK)
                return Ok(response.Content);
            return NotFound();
        }
    }
}
