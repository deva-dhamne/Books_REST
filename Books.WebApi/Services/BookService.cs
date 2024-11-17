using Books.WebApi.Models;
using Books.WebApi.Repositories;

namespace Books.WebApi.Services
{
    public class BookService : IBookService
    {
        private readonly IBooksRepository _booksRepository;

        public BookService(IBooksRepository booksRepository)
        {
            _booksRepository = booksRepository;
        }

        public IEnumerable<Book> GetAll() => _booksRepository.GetAll();

        public Book GetById(int id) => _booksRepository.GetById(id);

        public void Add(Book book) => _booksRepository.Add(book);

        public void Update(Book book) => _booksRepository.Update(book);

        public void Delete(int id) => _booksRepository.Delete(id);
    }
}
