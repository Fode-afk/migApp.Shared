using migApp.Shared.Dtos.Products;
using migApp.Shared.Enums;
using System;
using System.Collections.Generic;

namespace migApp.Shared.EventDtos
{
    public class ProductPublishedDto
    {
        public string ProductId { get; set; }
        public string ParentCardId { get; set; }

        public ProductType Type { get; set; }

        public string Name { get; set; }

        public int Price { get; set; }

        public bool CanBeOrdered { get; set; }

        public int StockQuantity { get; set; }

        public List<string> ImageURLs { get; set; }

        public List<ProductAttributeDto> Attributes { get; set; }
        public DateTimeOffset UpdatedAt { get; set; }
        public DateTimeOffset CreatedAt { get; set; }
    }
}
