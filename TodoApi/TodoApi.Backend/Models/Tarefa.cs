using System;
using System.ComponentModel.DataAnnotations;

namespace TodoApi.Backend.Models
{
    public class Tarefa
    {
        [Key]
        public Guid Id { get; set; }

        [Required(ErrorMessage = "O título da tarefa é obrigatório.")]
        [MaxLength(100, ErrorMessage = "O título da tarefa deve ter no máximo 100 caracteres.")]
        public string Titulo { get; set; }

        [Required(ErrorMessage = "A descrição da tarefa é obrigatória.")]
        public string Descricao { get; set; }

        public DateTime DataCriacao { get; set; }

        public DateTime? DataConclusao { get; set; }

        public Guid UsuarioId { get; set; }
    }
}
