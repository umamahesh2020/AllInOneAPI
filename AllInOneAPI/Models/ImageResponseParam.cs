using MongoDB.Bson.Serialization.Attributes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AllInOneAPI.Models
{
    public class ImageResponseParam
    {
        public string EnrollementId { get; set; } = string.Empty;
        public string Body { get; set; } = string.Empty;

        [BsonDateTimeOptions]
        public DateTime UpdatedOn { get; set; } = DateTime.UtcNow;

        public int EnrolllerType { get; set; }
        public string Email { get; set; }
        public string MobileNumber { get; set; }
    }
}
