using System;

namespace migApp.Shared.Dtos.Review_Rating
{
    public class VendorReplyDto
    {
        public string ReviewId { get; set; }
        public string VendorId { get; set; }
        public string Body { get; set; }
        public DateTimeOffset CreatedAt { get; set; }
    }
}
