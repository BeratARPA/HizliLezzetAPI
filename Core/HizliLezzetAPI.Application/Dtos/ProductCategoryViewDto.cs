namespace HizliLezzetAPI.Application.Dtos
{
    public class ProductCategoryViewDto
    {
        public Guid Id { get; set; }
        public Guid RestaurantId { get; set; }
        public bool PreperationType { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public string Thumbnail { get; set; }
    }
}
