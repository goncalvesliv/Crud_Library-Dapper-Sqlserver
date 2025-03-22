namespace Crud_Library_sqlserver.Dto
{
    public class BookListarDto
    {
        public int Id { get; init; }
        public string Title { get; set; }
        public string Author { get; set; }
        public int Year { get; set; }
        public bool Available { get; set; }
    }
}
