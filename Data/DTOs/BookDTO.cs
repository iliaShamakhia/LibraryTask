using Data.Entities;

namespace Data.DTOs
{
    public class BookDTO
    {
        public int Id { get; set; }
        public string Title { get; set; } = string.Empty;
        public string Description { get; set; } = string.Empty;
        public string ImageUrl { get; set; } = string.Empty;
        public double Rating { get; set; }
        public DateTime PublishDate { get; set; }
        public bool IsAvailable { get; set; }
        public ICollection<AuthorDTO> Authors { get; set; }
    }
}
