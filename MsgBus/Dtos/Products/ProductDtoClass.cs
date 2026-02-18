using System.Text.Json.Serialization;

namespace migApp.Shared.MsgBus.Dtos.Products
{
    [JsonPolymorphic(TypeDiscriminatorPropertyName = "DtoType")]
    [JsonDerivedType(typeof(ProductPublishedDto), "Published")]
    [JsonDerivedType(typeof(ProductUpdatedDto), "Updated")]
    [JsonDerivedType(typeof(ProductArchivedDto), "Archived")]
    [JsonDerivedType(typeof(ProductUnarchivedDto), "Unarchived")]
    [JsonDerivedType(typeof(ProductDeletedDto), "Deleted")]
    [JsonDerivedType(typeof(ProductParentCardChangedDto), "ParentCardChanged")]
    public abstract class ProductDtoClass
    {
        public abstract string ProductId { get; set; }
    }
}
