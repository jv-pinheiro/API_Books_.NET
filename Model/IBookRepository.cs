using API_Books.Model;

namespace API_Books.Model
{
    public interface IBookRepository
    {
        void Add(Book book); //POST

        List<Book> Get(); //GET

        Book? GetById(int id); //GET by ID
        void Update(Book book); //PUT
        void Delete(Book book); //DELETE
     }
}