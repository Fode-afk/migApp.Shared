using migApp.Shared.MsgBus.Dtos.Products;
using System.Text.Json.Serialization;

namespace migApp.Shared.MsgBus.Dtos.Product
{
    [JsonPolymorphic(TypeDiscriminatorPropertyName = "$type")]
    [JsonDerivedType(typeof(ProductPublishedDto), "Published")]
    [JsonDerivedType(typeof(ProductUpdatePublishedDto), "Updated")]
    [JsonDerivedType(typeof(ProductArchivedDto), "Archived")]
    [JsonDerivedType(typeof(ProductUnarchivedDto), "Unarchived")]
    [JsonDerivedType(typeof(ProductParentCardChangedDto), "ParentCardChanged")]
    public abstract class ProductDtoClass
    {
        public abstract string ProductId { get; set; }
    }
}
