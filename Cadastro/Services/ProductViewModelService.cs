using AutoMapper;
using Cadastro.Domain.Entities;
using Cadastro.Domain.Interfaces;
using Cadastro.Infrastructure.Data.Repositories;
using Cadastro.Interfaces;
using Cadastro.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Cadastro.Services
{
    public class ProductViewModelService : IProductViewModelService
    {
        private readonly IProductRepository _productRepository;
        private readonly IClientRepository _clientRepository;
        private readonly ICategoryRepository _categoryRepository;
        private readonly IMapper _mapper;

        public ProductViewModelService(IProductRepository productRepository, IMapper mapper, IClientRepository clientRepository, ICategoryRepository categoryRepository)
        {
            _productRepository = productRepository;
            _mapper = mapper;
            _clientRepository = clientRepository;
            _categoryRepository = categoryRepository;
        }

        public void Delete(int id)
        {
            _productRepository.Delete(id);
        }

        public ProductViewModel Get(int id)
        {
            var entity = _productRepository.Get(id);
            if (entity == null)
                return null;

            return _mapper.Map<ProductViewModel>(entity);

         }

        public async Task<IEnumerable<ProductViewModel>> GetAll()
        {
            var list = _productRepository.GetAll();
            if (list == null)
                return new ProductViewModel[] { };

            return _mapper.Map<IEnumerable<ProductViewModel>>(list);

        }

        public void Insert(ProductViewModel viewModel)
        {
            var entity = _mapper.Map<Product>(viewModel);

            _productRepository.Insert(entity);
        }

        

        public async Task<IEnumerable<ProductViewModel>> ObterProdutClient()
        {
            return _mapper.Map<IEnumerable<ProductViewModel>>(await _productRepository.ObterProductClient());
        }

        public void Update(ProductViewModel viewModel)
        {
            var entity = _mapper.Map<Product>(viewModel);

            _productRepository.Update(entity);
        }

        public IEnumerable<ClientViewModel> ObterTodosClientes()
        {
            var clientes = _mapper.Map<IEnumerable<ClientViewModel>>(_clientRepository.GetAll());

            return clientes;
        }

        public IEnumerable<CategoryViewModel> ObterTodosCategorias()
        {
            var category = _mapper.Map<IEnumerable<CategoryViewModel>>(_categoryRepository.GetAll());

            return category;
        }

        public async Task<ProductViewModel> ObterProdutClientAndCategory(int id)
        {
            var product =  _mapper.Map<ProductViewModel > (await _productRepository.ObterProductClientAndCliente(id));
            
            product.Clients = ObterTodosClientes();
            product.Categorys = ObterTodosCategorias();

            return product; 

        }
    }
}
