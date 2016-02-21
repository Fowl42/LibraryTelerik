using System.Data;

namespace TelerikLibrary.Models
{
    public class Book
    {
        public long Id { get; set; }
        public string Name { get; set; }
        public string Publisher { get; set; }
        public long Year { get; set; }
        public string Category { get; set; }
        public string Description { get; set; }
        public string Author { get; set; }

        public static Book FromRow(DataRow row)
        {
            var book = new Book();
            book.Id = row.Field<long>("Id");
            book.Name = row.Field<string>("BookName");
            book.Publisher = row.Field<string>("Publisher");
            book.Year = row.Field<long>("PublishYear");
            book.Category = row.Field<string>("Category");
            book.Description = row.Field<string>("DESCRIPTION");
            book.Author = $"{row.Field<string>("LastName")} {row.Field<string>("FirstName")}";
            return book;
        }
    }
}