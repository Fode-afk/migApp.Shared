using System.Collections.Generic;
using migApp.Shared.Dtos.Products;
using migApp.Shared.Dtos.Review;
using migApp.Shared.Dtos.Review_Rating;
using System.Collections.Generic;

namespace migApp.Shared.Dtos.Cards
{
    public class CardDetailsDto
    {
        public string CardId { get; set; }
        public string CardName { get; set; }
        public List<ProductDto> Products { get; set; }
        public List<ReviewDto> Reviews { get; set; }
        public RatingDto ProductRating { get; set; }
        public RatingDto VendorRating { get; set; }
    }
}
