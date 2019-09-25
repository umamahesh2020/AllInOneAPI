namespace AllInOneAPI.Models
{
    public class EnrollerImage
    {
        public string Url { get; set; } = string.Empty;
        public string ThumbnailUrl { get; set; } = string.Empty;
        public long ImageSize { get; set; } = 0L;
        public int UploadedImageCount { get; set; }
    }
}
