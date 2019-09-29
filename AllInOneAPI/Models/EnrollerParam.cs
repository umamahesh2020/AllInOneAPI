namespace AllInOneAPI.Models
{
    public class EnrollerParam
    {
        public string Id { get; set; } = string.Empty;
        public string Body { get; set; } = string.Empty;
        public int UserId { get; set; } = 0;

        public int EnrolllerType { get; set; } = 1;
        public EnrollementModel Enrollement { get; set; } = new EnrollementModel();
        public string Email { get; set; }
        public string MobileNumber { get; set; }
    }
}
