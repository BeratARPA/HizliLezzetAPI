namespace HizliLezzetAPI.Application.Dtos
{
    public class RestaurantTableViewDto
    {
        public Guid RestaurantTableSectionId { get; set; }
        public string Name { get; set; }
        public string Title { get; set; }
        public string Thumbnail { get; set; }
    }
}
