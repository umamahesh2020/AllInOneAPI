using MongoDB.Bson.Serialization.Attributes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AllInOneAPI.Models
{
    public class ImageResponseParam
    {

        public List<Datum> Data { get; set; }
    }
    public class Datum
    {
        public string Body { get; set; }
        public string OCRDateTime { get; set; }
        public string ImageReLocation { get; set; }
        public string ImageFTPPath { get; set; }
        public string CameraIpAddress { get; set; }
        public string CameraName { get; set; }
    }
}
