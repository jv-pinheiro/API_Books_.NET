using Microsoft.AspNetCore.Mvc;
using API_Books.Model;
using API_Books.View;

namespace API_Books.Controllers
{
    [ApiController]
    [Route("api/v0/book")]
    public class BookController : ControllerBase
    {
        private readonly IBookRepository _bookRepository;

        public BookController(IBookRepository bookRepository)
        {
            _bookRepository = bookRepository ?? throw new ArgumentNullException(nameof(bookRepository));
        }

        [HttpPost]
        public IActionResult Add(BookView bookView)
        {
            var book = new Book(bookView.nome, bookView.autor, bookView.status);
            _bookRepository.Add(book);
            return Ok();
        }

        [HttpGet]
        public IActionResult Get()
        {
            var books = _bookRepository.Get();
            return Ok(books);
        }

        [HttpGet("{id}")]
        public IActionResult GetById(int id)
        {
            var book = _bookRepository.GetById(id);
            if (book == null)
            {
                return NotFound(); // Retorna 404 caso o livro não seja encontrado
            }
            return Ok(book); // Retorna o livro encontrado
        }


        [HttpPut("{id}")]
        public IActionResult Update(int id, BookView bookView)
        {
            var book = _bookRepository.GetById(id); // Método para buscar o livro pelo id
            if (book == null)
            {
                return NotFound(); // Retorna erro 404 se o livro não for encontrado
            }

            // Atualiza os valores do livro
            book.AtualizarDados(bookView.nome, bookView.autor, bookView.status); // Método Update pode ser definido no modelo Book

            _bookRepository.Update(book); // Método para atualizar o livro no repositório
            return Ok(book); // Retorna o livro atualizado
        }

        [HttpPatch("{id}")]
        public IActionResult Patch(int id, BookView bookView)
        {
            var book = _bookRepository.GetById(id);
            if (book == null)
            {
                return NotFound();
            }

            book.AtualizarDados(
               bookView.nome ?? book.nome,
               bookView.autor ?? book.autor,
               bookView.status ?? book.status
            );

            _bookRepository.Update(book);
            return Ok(book);
        }

        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            var book = _bookRepository.GetById(id);
            if (book == null)
            {
                return NotFound(); // Se o livro não existir, retorna 404
            }

            _bookRepository.Delete(book); // Método que deleta o livro
            return NoContent(); // Retorna 204 No Content, sem corpo
        }

        [HttpHead("{id}")]
        public IActionResult Head(int id)
        {
            var book = _bookRepository.GetById(id);
            if (book == null)
            {
                return NotFound(); // Se o livro não existir, retorna 404
            }

            return Ok(); // Apenas retorna os cabeçalhos (sem corpo)
        }

        [HttpOptions]
        public IActionResult Options()
        {
            Response.Headers.Add("Allow", "GET, POST, PUT, PATCH, DELETE, OPTIONS");
            return Ok();
        }

        [HttpOptions("{id}")]
        public IActionResult Options(int id)
        {
            return Ok(); // Retorna os métodos permitidos (geralmente configurado automaticamente no servidor)
        }

    }
}
