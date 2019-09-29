using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AllInOneAPI.Interfaces;
using AllInOneAPI.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace AllInOneAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class FRImageResponseSystemController : ControllerBase
    {
        private readonly IFRImageResponseRespository _frImageResponseRespository;

        public FRImageResponseSystemController(IFRImageResponseRespository FRImageResponseRespository)
        {
            _frImageResponseRespository = FRImageResponseRespository;
        }

        
        [HttpGet("{setting}")]
        public string Get(string setting)
        {
            if (setting.ToLowerInvariant() == "init")
            {
                _frImageResponseRespository.RemoveAllImageResponseDetails();
                var name = _frImageResponseRespository.CreateIndex();

                var enrollementDetails = new ImageResponseParam
                {
                    EnrollementId = "5e80b5c4-a663-4b98-8f1c-3eb70015fa41",
                    Body = "{\"_id\":\"5d905c5727a23d41c8c9f0fc\",\"Id\":\"5e80b5c4-a663-4b98-8f1c-3eb70015fa41\",\"EnrolllerType\":1,\"Body\":\"{\\\"MobileNumber\\\":\\\"1122222222\\\",\\\"EnrollerID\\\":\\\"5e80b5c4-a663-4b98-8f1c-3eb70015fa41\\\",\\\"EnrollementType\\\":\\\"1\\\",\\\"FirstName\\\":\\\"sdfg\\\",\\\"MiddleName\\\":\\\"dsfg\\\",\\\"LastName\\\":\\\"dsfg\\\",\\\"Gender\\\":\\\"1\\\",\\\"Age\\\":0,\\\"DateOfBirth\\\":\\\"2019-09-02T18:30:00.000Z\\\",\\\"Identity\\\":\\\"fdsg\\\",\\\"Address\\\":\\\"klsghsdkjf\\\",\\\"Email\\\":\\\"sdfsd@daf.sdf\\\",\\\"IsSMSNotifcationEnabled\\\":true,\\\"IsEmailNotificationEnabled\\\":true,\\\"Title\\\":\\\"Student Registration Details\\\"}\",\"UpdatedOn\":\"2019-09-29T07:25:11.052Z\",\"HeaderImage\":null,\"UserId\":0,\"Email\":\"sdfsd@daf.sdf\",\"MobileNumber\":\"1122222222\"}",
                    UpdatedOn = DateTime.UtcNow,
                    EnrolllerType = 1,
                    MobileNumber = "9742477979",
                    Email = "Test@Test.Com"
                };

                _frImageResponseRespository.AddFRResponseDetail(new FRResponseDetail()
                {
                    EnrollementId = enrollementDetails.EnrollementId,
                    Body =enrollementDetails.Body,
                    UpdatedOn = DateTime.UtcNow,
                    EnrolllerType = 1,
                    MobileNumber = enrollementDetails.MobileNumber,
                    Email = enrollementDetails.Email
                });

                _frImageResponseRespository.AddFRResponseDetail(new FRResponseDetail()
                {
                    EnrollementId = enrollementDetails.EnrollementId,
                    Body = enrollementDetails.Body,
                    UpdatedOn = DateTime.UtcNow,
                    EnrolllerType = 2,
                    MobileNumber = enrollementDetails.MobileNumber,
                    Email = enrollementDetails.Email
                });

                _frImageResponseRespository.AddFRResponseDetail(new FRResponseDetail()
                {
                    EnrollementId = enrollementDetails.EnrollementId,
                    Body = enrollementDetails.Body,
                    UpdatedOn = DateTime.UtcNow,
                    EnrolllerType = 3,
                    MobileNumber = enrollementDetails.MobileNumber,
                    Email = enrollementDetails.Email
                });

                _frImageResponseRespository.AddFRResponseDetail(new FRResponseDetail()
                {
                    EnrollementId = enrollementDetails.EnrollementId,
                    Body = enrollementDetails.Body,
                    UpdatedOn = DateTime.UtcNow,
                    EnrolllerType = 4,
                    MobileNumber = enrollementDetails.MobileNumber,
                    Email = enrollementDetails.Email
                });

                return "Database FRDB was created, and collection 'Image Response' was filled with 4 sample items";
            }

            return "Unknown";
        }
    }
}