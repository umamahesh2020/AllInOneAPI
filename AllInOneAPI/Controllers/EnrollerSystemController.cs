﻿using System;
using AllInOneAPI.Interfaces;
using AllInOneAPI.Models;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;

namespace AllInOneAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EnrollerSystemController : ControllerBase
    {
        private readonly IFRRepository _frRepository;

        public EnrollerSystemController(IFRRepository frRepository)
        {
            _frRepository = frRepository;
        }

        // Call an initialization - api/system/init
        [HttpGet("{setting}")]
        public string Get(string setting)
        {
            if (setting == "init")
            {
                _frRepository.RemoveAllEnrollerDetails();
                var name = _frRepository.CreateIndex();

                var enrollementDetails = new EnrollementModel
                {
                    EnrollerID = Guid.NewGuid().ToString(),
                    FirstName = "Sreekanth",
                    MiddleName = "Kanth",
                    LastName = "B",
                    Age = 25,
                    DateOfBirth = DateTime.Now,
                    Gender = "Male",
                    MobileNumber = 9742477979,
                    Email = "Sreekanth"
                };
                enrollementDetails.EnrollerImages.Add(new EnrollementImageModel { ImageSize = 10, ThumbnailUrl = "http://localhost/image2_small.png", UploadedImageCount = 10, Url = "http://localhost/image2_small.png" });
                string enrollerBody = JsonConvert.SerializeObject(enrollementDetails);




                _frRepository.AddFREnrollerDetails(new EnrollerDetail()
                {
                    Id = Guid.NewGuid().ToString(),
                    EnrolllerType = 1,
                    Body = enrollerBody,
                    UpdatedOn = DateTime.UtcNow,
                    UserId = 1,
                    HeaderImage = new EnrollerImage
                    {
                        Url = "http://localhost/image2.png",                       
                        UploadedImageCount = 10
                    }
                });

                _frRepository.AddFREnrollerDetails(new EnrollerDetail()
                {
                    Id = Guid.NewGuid().ToString(),
                    EnrolllerType = 2,
                    Body = enrollerBody,
                    UpdatedOn = DateTime.UtcNow,
                    UserId = 1,
                    HeaderImage = new EnrollerImage
                    {                      
                        Url = "http://localhost/image2.png",                      
                    }
                });

                _frRepository.AddFREnrollerDetails(new EnrollerDetail()
                {
                    Id = Guid.NewGuid().ToString(),
                    EnrolllerType = 3,
                    Body = enrollerBody,
                    UpdatedOn = DateTime.UtcNow,
                    UserId = 1,
                    HeaderImage = new EnrollerImage
                    {                       
                        Url = "http://localhost/image3.png",                        
                    }
                });

                _frRepository.AddFREnrollerDetails(new EnrollerDetail()
                {
                    Id = Guid.NewGuid().ToString(),
                    EnrolllerType = 4,
                    Body = enrollerBody,
                    UpdatedOn = DateTime.UtcNow,
                    UserId = 1,
                    HeaderImage = new EnrollerImage
                    {                        
                        Url = "http://localhost/image4.png",                      
                    }
                });

                return "Database FRDB was created, and collection 'Enroller' was filled with 4 sample items";
            }

            return "Unknown";
        }
    }
}