using Books.WebApi.Models;
using LiteDB;

namespace Books.WebApi.Repositories
{
    public class BooksRepository : IBooksRepository
    {
        private const string DatabaseFile = "Books.db";
        private const string CollectionName = "books";
        private readonly ILiteCollection<Book> _booksCollection;

        public BooksRepository()
        {
            var db = new LiteDatabase(DatabaseFile);
            _booksCollection = db.GetCollection<Book>(CollectionName);

            _booksCollection.EnsureIndex(b => b.Id, true);
        }

        public IEnumerable<Book> GetAll() => _booksCollection.FindAll();

        public Book GetById(int id) => _booksCollection.FindById(id);

        public void Add(Book book) => _booksCollection.Insert(book);

        public bool Update(Book book) => _booksCollection.Update(book);

        public bool Delete(int id) => _booksCollection.Delete(id);
    }
}
