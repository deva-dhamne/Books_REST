using Books.WebApi.Models;

namespace Books.WebApi.Services
{
    public interface IBookService
    {
        IEnumerable<Book> GetAll();

        void Add(Book book);

        Book GetById(int id);

        void Update(Book book);

        bool UpdatePrice(int id, decimal price);

        void Delete(int id);
    }
}
