using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using TelerikLibrary.DA;

namespace TelerikLibrary.Models
{
    public class BooksService : IDisposable
    {
        const string BooksQuery = "SELECT * FROM BooksView";

        private IEnumerable<Book> _books;

        public BooksService()
        {
            var connector = new SqLiteConnector();
            _books = connector.LoadData(BooksQuery).Rows.OfType<DataRow>().
                Select(Book.FromRow).ToList();
            
        }

        public BooksService(IEnumerable<Book> books)
        {
            _books = books;
        }
        
        public IEnumerable<Book> Read()
        {
            return _books;
        }

        public void Create(Book product)
        {
            var entity = new Book
            {
                Id = product.Id,
                Author = product.Author,
                Description = product.Description,
                Category = product.Category,
                Name = product.Name,
                Publisher = product.Publisher,
                Year = product.Year
            };
            
            _books.ToList().Add(entity);
        }

        public void Update(Book product)
        {
            var entity = new Book
            {
                Id = product.Id,
                Author = product.Author,
                Description = product.Description,
                Category = product.Category,
                Name = product.Name,
                Publisher = product.Publisher,
                Year = product.Year
            };
            var updated = _books.FirstOrDefault(t => t.Id == entity.Id);
            if (updated != null)
            {
                //Update Action
            }
        }

        public void Destroy(Book product)
        {

            var entity = _books.FirstOrDefault(t => t.Id == product.Id);

            _books.ToList().Remove(entity);
        }

        public void Dispose()
        {
            _books = null;
        }
    }
}