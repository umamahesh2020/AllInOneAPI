using System.Collections.Generic;
using System.Threading.Tasks;
using AllInOneAPI.Infrastructure;
using AllInOneAPI.Interfaces;
using AllInOneAPI.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace AllInOneAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class FRImageResponseController : ControllerBase
    {
        private readonly IFRImageResponseRespository _frImageResponseRespository;

        public FRImageResponseController(IFRImageResponseRespository FRImageResponseRespository)
        {
            _frImageResponseRespository = FRImageResponseRespository;
        }

        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [NoCache]
        [HttpGet]
        public async Task<IEnumerable<FRResponseDetail>> Get()
        {
            return await _frImageResponseRespository.GetAllFRResponseDetail();
        }

        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [HttpPost]
        public void Post([FromBody] ImageResponseParam imageResponse)
        {
            _frImageResponseRespository.AddFRResponseDetail(new FRResponseDetail
            {
               EnrollementId = imageResponse.EnrollementId,
               Body = imageResponse.Body,
               UpdatedOn = imageResponse.UpdatedOn,
               EnrolllerType = imageResponse.EnrolllerType,
               MobileNumber = imageResponse.MobileNumber,
               Email = imageResponse.Email,
               ProcessedImageLocation = imageResponse.ProcessedImageLocation
               
            });
        }
    }
}