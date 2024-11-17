using Books.WebApi.Models;

namespace Books.WebApi.Repositories
{
    public interface IBooksRepository
    {
        IEnumerable<Book> GetAll();


        Book GetById(int id);


        void Add(Book book);


        bool Update(Book book);


        bool Delete(int id);
    }
}
