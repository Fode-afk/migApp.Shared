using System.Collections.Generic;

namespace migApp.Shared.MsgBus.Dtos.Products
{
    public class ProductDeletedDto : ProductDtoClass
    {
        public override string ProductId { get; set; }
        public string ParentCardId { get; set; }
        public string OwnerId { get; set; }
        public List<string> ImageURLs { get; set; }
    }
}
