using migApp.Shared.MsgBus.Dtos.Product;

namespace migApp.Shared.MsgBus.Dtos.Products
{
    public class ProductArchivedDto : ProductDtoClass
    {
        public override string ProductId { get; set; }
        public string CardId { get; set; }
    }
}
