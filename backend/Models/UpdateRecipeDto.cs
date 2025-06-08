namespace backend.Models
{
    public class UpdateRecipeDto
    {
        public string Name { get; set; }
        public string? ImageUrl { get; set; }
        public string Ingredients { get; set; }
        public string Instructions { get; set; }
    }
}
