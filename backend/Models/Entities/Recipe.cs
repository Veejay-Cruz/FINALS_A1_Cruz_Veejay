﻿namespace backend.Models
{
    public class Recipe
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string? ImageUrl { get; set; }
        public string Ingredients { get; set; }
        public string Instructions { get; set; }
    }
}
