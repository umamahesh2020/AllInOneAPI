using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AllInOneAPI.Models
{
    public class EnrollementModel
    {
        public string EnrollerID { get; set; }
        public string FirstName { get; set; }
        public string MiddleName { get; set; }
        public string LastName { get; set; }
        public int Age { get; set; }
        public DateTime DateOfBirth { get; set; }
        public string Gender { get; set; }
        public long MobileNumber { get; set; }
        public string Email { get; set; }
        public string Address { get; set; }
        public bool IsSMSNotifcationEnabled { get; set; }
        public bool IsEmailNotificationEnabled { get; set; }
        public string Identity { get; set; }
        public List<EnrollementImageModel> EnrollerImages { get; set; } = new List<EnrollementImageModel>();
    }
}
