using System;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace ProjetoModelo_MVC.ViewModels
{
    public class LivroViewModel
    {
        public LivroViewModel()
        {
            LivroId = Guid.NewGuid();
        }


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

        [ScaffoldColumn(false)]
        public Guid ClienteId { get; set; }
    }
}