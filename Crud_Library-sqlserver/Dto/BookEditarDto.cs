namespace Crud_Library_sqlserver.Dto
{
    public class BookEditarDto
    {
        public int Id { get; init; }
        public string Title { get; set; }
        public string Author { get; set; }
        public int Year { get; set; }
        public bool Available { get; set; }
    }
}
