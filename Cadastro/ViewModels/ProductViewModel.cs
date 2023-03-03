using Cadastro.Domain.Entities;
using Cadastro.Infrastructure.Extensions;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Cadastro.ViewModels
{
    public class ProductViewModel
    {

        [Key]
        public int Id { get; set; }

        [Display(Name = "Nome")]
        [Required(ErrorMessage = "O campo {0} é obrigatório")]
        public string Name { get; set; }

        [Display(Name = "Preço")]
        [Moeda]
        [Required(ErrorMessage = "O campo {0} é obrigatório")]
        public decimal Value { get; set; }


        [Display(Name = "Ativo?")]
        public bool Active { get; set; }

        [Display(Name = "Categoria")]
        [Required(ErrorMessage = "O campo {0} é obrigatório")]

        public int CategoryId { get; set; }

        [Display(Name = "Categoria")]
        public CategoryViewModel Category { get; set; }

        [Display(Name = "Cliente")]
        [Required(ErrorMessage = "O campo {0} é obrigatório")]

        public int ClienteId { get; set; }

        [Display(Name = "Cliente")]
        public ClientViewModel Client { get; set; }

        /*Create List for SELECT */
        public IEnumerable<CategoryViewModel> Categorys { get; set; }
        public IEnumerable<ClientViewModel> Clients { get; set; }



    }
}
