namespace Data.Entities
{
    public class Author
    {
        public int Id { get; set; }
        public string Name { get; set; } = string.Empty;
        public string Surname { get; set; } = string.Empty;
        public DateTime BirthYear { get; set; }
        public ICollection<BookAuthor> Books { get; set; }
    }
}
