﻿namespace HizliLezzetAPI.Application.Dtos
{
    public class RestaurantTableSectionViewDto
    {
        public Guid Id { get; set; }
        public Guid RestaurantId { get; set; }
        public char TableKeyword { get; set; }
        public string Title { get; set; }
        public string Thumbnail { get; set; }
    }
}
