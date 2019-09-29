using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AllInOneAPI.Models
{
    public class EnrollementImageModel
    {
        public string Url { get; set; } = string.Empty;
        public string ThumbnailUrl { get; set; } = string.Empty;
        public long ImageSize { get; set; } = 0L;
        public int UploadedImageCount { get; set; }
        public string EnrollementId { get; set; }
        public int EnrollementTypeId { get; set; }
        public string ImagePath { get; set; }
    }
}
