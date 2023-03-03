using Cadastro.Domain.Entities;
using Cadastro.ViewModels;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Cadastro.Interfaces
{
    public interface IProductViewModelService
    {
        ProductViewModel Get(int id);
        void Insert(ProductViewModel viewModel);
        void Update(ProductViewModel viewModel);
        void Delete(int id);

        Task<IEnumerable<ProductViewModel>> ObterProdutClient();

        Task<ProductViewModel> ObterProdutClientAndCategory(int id);


        IEnumerable<ClientViewModel> ObterTodosClientes();

        IEnumerable<CategoryViewModel> ObterTodosCategorias();


    }
}
