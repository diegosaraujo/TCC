using System;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Web;
using ProjetoDDD.Infra.CrossCutting.MvcFilters;
using System.Collections.Generic;
using ProjetoModelo_MVC.ViewModels;

namespace ProjetoDDD.Application.ViewModels
{
    public class ClienteLivroViewModel
    {
        public ClienteLivroViewModel()
        {
            ClienteId = Guid.NewGuid();
            LivroId = Guid.NewGuid();
        }

        [Key]
        public Guid ClienteId { get; set; }

        [Required(ErrorMessage = "Preencha o campo Nome")]
        [MaxLength(150, ErrorMessage = "Máximo {0} caracteres")]
        [MinLength(2, ErrorMessage = "Mínimo {0} caracteres")]
        public string Nome { get; set; }

        [Required(ErrorMessage = "Preencha o campo E-mail")]
        [MaxLength(100, ErrorMessage = "Máximo {0} caracteres")]
        [EmailAddress(ErrorMessage = "Preencha um E-mail válido")]
        [DisplayName("E-mail")]
        public string Email { get; set; }

        [Phone(ErrorMessage = "Preencha um telefone válido com DDD")]
        public string Telefone { get; set; }

        [FileSize(10240)]
        [FileTypes("jpg,jpeg,png")]
        public HttpPostedFileBase Foto { get; set; }


        [Display(Name = "Data de Nascimento")]
        [DisplayFormat(ApplyFormatInEditMode = true, DataFormatString = "{0:yyyy-MM-dd}")]
        [DataType(DataType.Date, ErrorMessage = "Data em formato inválido")]
        public DateTime DataNascimento { get; set; }

        [MaxLength(20, ErrorMessage = "Máximo {0} caracteres")]
        [MinLength(3, ErrorMessage = "Mínimo {0} caracteres")]
        public string Cidade { get; set; }

        [MaxLength(20, ErrorMessage = "Máximo {0} caracteres")]
        [MinLength(3, ErrorMessage = "Mínimo {0} caracteres")]
        public string Bairro { get; set; }

        [ScaffoldColumn(false)]
        public DateTime DataCadastro { get; set; }

        [ScaffoldColumn(false)]
        public bool Ativo { get; set; }

        [ScaffoldColumn(false)]
        public DomainValidation.Validation.ValidationResult ValidationResult { get; set; }

        // Livro

        [Key]
        public Guid LivroId { get; set; }

        [Required(ErrorMessage = "Preencha o campo Titulo")]
        [MaxLength(50, ErrorMessage = "Máximo {0} caracteres")]
        [MinLength(5, ErrorMessage = "Mínimo {0} caracteres")]
        public string Titulo { get; set; }

        [Required(ErrorMessage = "Preencha o campo Autor")]
        [MaxLength(50, ErrorMessage = "Máximo {0} caracteres")]
        [MinLength(2, ErrorMessage = "Mínimo {0} caracteres")]
        public string Autor { get; set; }

        [Required(ErrorMessage = "Preencha o campo Ano Letivo")]
        [MaxLength(2, ErrorMessage = "Máximo {0} caracteres")]
        [MinLength(1, ErrorMessage = "Mínimo {0} caracteres")]
        public int AnoLetivo { get; set; }

        [Required(ErrorMessage = "Preencha a disciplina correspondente: Portugês, matemática...etc")]
        [MaxLength(20, ErrorMessage = "Máximo {0} caracteres")]
        [MinLength(5, ErrorMessage = "Mínimo {0} caracteres")]
        public string Disciplina { get; set; }

        [DisplayName("Disponível?")]
        public bool Disponível { get; set; }
    }
}
