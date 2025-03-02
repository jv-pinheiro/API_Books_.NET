using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace API_Books.Model
{
    [Table("book")]
    public class Book
    {
        [Key]
        public int id { get; private set; }

        [Column("nome")]
        public string? nome { get; private set; }

        [Column("autor")]
        public string? autor { get; private set; }

        [Column("status")]
        public string? status { get; private set; }



        public Book(string nome, string autor, string status)
        {
            this.nome = nome;
            this.autor = autor;
            this.status = status;
        }

        //PARA O MÉTODO PUT
        public void AtualizarDados(string nome, string autor, string status)
        {
            this.nome = nome;
            this.autor = autor;
            this.status = status;
        }

    }
}
