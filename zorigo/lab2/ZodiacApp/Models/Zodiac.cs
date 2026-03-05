namespace ZodiacApp.Models
{
    public class Zodiac
    {
        public int Id { get; set; }

        public string? AnimalMN { get; set; }
        public string? AnimalENG { get; set; }

        public string? DescriptionMN { get; set; }
        public string? DescriptionENG { get; set; }

        public string? ImageURL { get; set; }

        public string? ElementMN { get; set; }
        public string? ElementENG { get; set; }
    }
}