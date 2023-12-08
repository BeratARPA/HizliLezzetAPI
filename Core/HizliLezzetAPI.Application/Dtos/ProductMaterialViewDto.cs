namespace HizliLezzetAPI.Application.Dtos
{
    public class ProductMaterialViewDto
    {
        public Guid RestaurantId { get; set; }
        public Guid ProductId { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public decimal Price { get; set; }
        public string Thumbnail { get; set; }
        public bool IsDefault { get; set; }
        public decimal Quantity { get; set; }
    }
}
