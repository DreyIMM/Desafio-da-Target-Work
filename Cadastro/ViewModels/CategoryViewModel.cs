using System.ComponentModel.DataAnnotations;
using System;

namespace Cadastro.ViewModels
{
    public class CategoryViewModel
    {

        [Key]
        public int Id { get; set; }

        [Required(ErrorMessage = "O campo {0} é obrigatório")]
        public string Name { get; set; }
    }
}
