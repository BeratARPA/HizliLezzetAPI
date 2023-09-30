using HizliLezzetAPI.Domain.Common;

namespace HizliLezzetAPI.Domain.Entities
{
    public class Product : BaseEntity
    {
        public Guid RestaurantId { get; set; }
        public Guid ProductCategoryId { get; set; }
        public decimal Kcal { get; set; }
        public string PreperationTime { get; set; }
        public string Title { get; set; }
        public decimal Price { get; set; }
        public decimal Rating { get; set; }
        public string Thumbnail { get; set; }
        public bool IsActiveWeb { get; set; }
        public bool IsActiveLocal { get; set; }
        public bool IsActiveGetirYemek { get; set; }
        public bool IsActiveYemekSepeti { get; set; }
        public bool IsActiveMigrosYemek { get; set; }
        public bool IsActiveTrendyolYemek { get; set; }

        public virtual ProductCategory ProductCategory { get; set; }

        public virtual ICollection<ProductMaterial> ProductMaterials { get; set; }
        public virtual ICollection<SpecialProduct> SpecialProducts { get; set; }
    }
}
