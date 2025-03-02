using API_Books.Model;
using Microsoft.EntityFrameworkCore;

namespace API_Books.Persistence
{
    public class BookRepository : IBookRepository
    {
        private readonly ConnectionContext _context;

        public BookRepository(ConnectionContext context)
        {
            _context = context;
        }

        // Método para adicionar um livro
        public void Add(Book book)
        {
            _context.Books.Add(book);
            _context.SaveChanges();
        }

        // Método para obter todos os livros
        public List<Book> Get()
        {
            return _context.Books.ToList();
        }

        // Método para obter um livro por ID
        public Book? GetById(int id)
        {
            return _context.Books.Find(id); // Retorna o livro com o ID fornecido
        }

        // Método para atualizar um livro
        public void Update(Book book)
        {
            _context.Books.Update(book);
            _context.SaveChanges();
        }

        // Método para excluir um livro
        public void Delete(Book book)
        {
            _context.Books.Remove(book);
            _context.SaveChanges();
        }
    }
}