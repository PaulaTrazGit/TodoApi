using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace TodoApi.Backend.Models
{
    public class Usuario
    {
        public Usuario()
        {
            Tarefas = new List<Tarefa>();
        }

        [Key]
        public Guid Id { get; set; }

        [Required(ErrorMessage = "O nome completo do usuário é obrigatório.")]
        public string NomeCompleto { get; set; }

        [Required(ErrorMessage = "O login do usuário é obrigatório.")]
        public string Login { get; set; }

        [Required(ErrorMessage = "A senha do usuário é obrigatória.")]
        public string Senha { get; set; }

        [Required(ErrorMessage = "O email do usuário é obrigatório.")]
        [EmailAddress(ErrorMessage = "O email do usuário não é válido.")]
        public string Email { get; set; }

        public DateTime DataCriacao { get; set; }

        public List<Tarefa> Tarefas { get; set; }
    }
}
