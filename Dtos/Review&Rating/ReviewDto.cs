using migApp.Shared.Dtos.Review_Rating;

namespace migApp.Shared.Dtos.Review
{
    public class ReviewDto
    {     
        public string ReviewId { get; set; }
        public string UserId { get; set; }
        public string ProductId { get; set; }
        public int Rating { get; set; }
        public string Body { get; set; }
        public List<string> ImageURLs { get; set; } = [];
        public VendorReplyDto Reply { get; set; }
        public DateTimeOffset CreatedAt { get; set; }
    }
}
