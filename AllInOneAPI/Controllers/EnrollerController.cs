using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using AllInOneAPI.Infrastructure;
using AllInOneAPI.Interfaces;
using AllInOneAPI.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace AllInOneAPI.Controllers
{
    [Produces("application/json")]
    [Route("api/[controller]")]
    [ApiController]
    public class EnrollerController : ControllerBase
    {
        private readonly IFRRepository _frRepository;

        public EnrollerController(IFRRepository frRepository)
        {
            _frRepository = frRepository;
        }

        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [NoCache]
        [HttpGet]
        public async Task<IEnumerable<EnrollerDetail>> Get()
        {
            return await _frRepository.GetAllEnrollerDetails();
        }

        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [HttpGet("{id}")]
        public async Task<EnrollerDetail> Get(string id)
        {
            return await _frRepository.GetEnrollerDetail(id) ?? new EnrollerDetail();
        }

        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        // GET api/notes/text/date/size
        // ex: http://localhost:53617/api/notes/Test/2018-01-01/10000
        [NoCache]
        [HttpGet(template: "{bodyText}/{updatedFrom}/{headerSizeLimit}")]
        public async Task<IEnumerable<EnrollerDetail>> Get(string bodyText,
                                                 DateTime updatedFrom,
                                                 long headerSizeLimit)
        {
            return await _frRepository.GetEnrollerDetail(bodyText, updatedFrom, headerSizeLimit)
                        ?? new List<EnrollerDetail>();
        }

        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [HttpPost]
        public void Post([FromBody] EnrollerParam enrollerParam)
        {
            _frRepository.AddFREnrollerDetails(new EnrollerDetail
            {
                Id = enrollerParam.Id,
                Body = enrollerParam.Body,
                UpdatedOn = DateTime.UtcNow,
                UserId = enrollerParam.UserId,
                EnrolllerType = enrollerParam.EnrolllerType,
                MobileNumber = enrollerParam.MobileNumber,
                Email = enrollerParam.Email
            });
        }

        [ProducesResponseType(StatusCodes.Status202Accepted)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        // PUT api/notes/5
        [HttpPut("{id}")]
        public void Put(string id, [FromBody]string value)
        {
            _frRepository.UpdateEnrollerDetail(id, value);
        }

        // DELETE api/notes/23243423
        [HttpDelete("{id}")]
        public void Delete(string id)
        {
            _frRepository.RemoveEnrollerDetail(id);
        }
    }
}