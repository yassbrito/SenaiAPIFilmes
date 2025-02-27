using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace api_filmes_senai.Domains
{
    [Table("Filme")]
    public class Filmes
    {
        [Key]
        public Guid IdFilmes { get; set; }

        [Column(TypeName = "VARCHAR(50)")]
        [Required(ErrorMessage = "O titulo do filme eh obrigatorio!")]
        public string? Titulo { get; set; }

        /// <summary>
        /// referencia da tabela genero
        /// </summary>
        public Guid IdGenero { get; set; }

        [ForeignKey("IdGenero")]
        public Genero? Genero { get; set; }
    }
}
