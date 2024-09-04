using System.ComponentModel.DataAnnotations;

namespace Domain.Models
{
    public class Pessoa : BaseEntity
    {
        public Pessoa(string nome, string email)
        {
            Nome = nome;
            Email = email;
        }

        [Required(ErrorMessage = "Nome é obrigatório!")]
        public string Nome { get;  set; } = string.Empty;


        [Required(ErrorMessage = "Email é obrigatório!")]

        public string Email { get; set; } = string.Empty;

    }
}