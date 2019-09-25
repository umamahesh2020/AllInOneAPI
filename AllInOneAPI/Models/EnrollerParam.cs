namespace AllInOneAPI.Models
{
    public class EnrollerParam
    {
        public string Id { get; set; } = string.Empty;
        public string Body { get; set; } = string.Empty;
        public int UserId { get; set; } = 0;
        public EnrollementModel Enrollement { get; set; } = new EnrollementModel();
    }
}
