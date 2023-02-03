using Data.Entities;

namespace Data.DTOs
{
    public class AuthorDTO
    {
        public int Id { get; set; }
        public string Name { get; set; } = string.Empty;
        public string Surname { get; set; } = string.Empty;
        public DateTime BirthYear { get; set; }
    }
}
