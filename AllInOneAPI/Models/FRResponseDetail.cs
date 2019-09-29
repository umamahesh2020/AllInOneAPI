using MongoDB.Bson.Serialization.Attributes;
using System;

namespace AllInOneAPI.Models
{
    public class FRResponseDetail
    {
        public string EnrollementId { get; set; }
        public string Body { get; set; } = string.Empty;

        [BsonDateTimeOptions]
        public DateTime UpdatedOn { get; set; } = DateTime.UtcNow;

        public int EnrolllerType { get; set; }
        public string Email { get; set; }
        public string MobileNumber { get; set; }

    }
}
