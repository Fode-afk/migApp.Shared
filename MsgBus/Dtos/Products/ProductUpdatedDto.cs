using System;
using System.Collections.Generic;
using migApp.Shared.Dtos.Products;
using migApp.Shared.Enums.Product;
using migApp.Shared.MsgBus.Dtos.Product;

namespace migApp.Shared.MsgBus.Dtos.Products
{
    public class ProductUpdatedDto : ProductDtoClass
    {
        public override string ProductId { get; set; }
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
