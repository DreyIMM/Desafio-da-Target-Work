using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Cadastro.Infrastructure.Data.Common;
using Cadastro.ViewModels;
using Cadastro.Interfaces;
using Cadastro.Domain.Interfaces;
using Cadastro.Domain.Entities;

namespace Cadastro.Controllers
{
    public class ProductsController : Controller
    {
        private readonly IProductViewModelService _productViewModelService;
        public ProductsController(IProductViewModelService productViewModelService)
        {
            _productViewModelService = productViewModelService;
        }

        // GET: Products
        public async Task<IActionResult> Index()
        {
            var ProductViewData = await _productViewModelService.ObterProdutClient();
            return View(ProductViewData);
        }

        // GET: Products/Create
        public IActionResult Create()
        {
            var ProdutViewModel = PopularityClientAndCategory(new ProductViewModel());
            return View(ProdutViewModel);
        }


        [HttpPost]
        public async Task<IActionResult> Create(ProductViewModel productViewModel)
        {
            if (!ModelState.IsValid) return View(productViewModel);

            productViewModel = PopularityClientAndCategory(productViewModel);

            _productViewModelService.Insert(productViewModel);

            return RedirectToAction(nameof(Index));
        }




        [Route("dados-produto/{id:int}")]
        public async Task<IActionResult> Details(int id)
        {
            var productViewModel = await _productViewModelService.ObterProdutClientAndCategory(id);

            if (productViewModel == null)
            {
                return NotFound();
            }

            return View(productViewModel);
        }

        [Route("editar-produto/{id:int}")]
        public async Task<IActionResult> Edit(int id)
        {

            var produtoViewModel =  await _productViewModelService.ObterProdutClientAndCategory(id);

            if (produtoViewModel == null)
            {
                return NotFound();
            }
            return View(produtoViewModel);
        }

        [Route("editar-produto/{id:int}")]
        [HttpPost]
        public async Task<IActionResult> Edit(int id, ProductViewModel produtoViewModel)
        {
            if (id != produtoViewModel.Id) return NotFound();

            var productUpdate = await _productViewModelService.ObterProdutClientAndCategory(id);

            //Deixei a categoria e Cliente não editaval, mas caso seja, um dos ajustes seria aqui:
            produtoViewModel.Category = productUpdate.Category;
            produtoViewModel.Client = productUpdate.Client;


            productUpdate.Name = produtoViewModel.Name;
            productUpdate.Value = produtoViewModel.Value;
            productUpdate.Active = produtoViewModel.Active;

            _productViewModelService.Update(productUpdate);

            return RedirectToAction("Index");


        }

        [Route("excluir-produto/{id:int}")]
        public async Task<IActionResult> Delete(int id)
        {
            var product = await _productViewModelService.ObterProdutClientAndCategory(id); 
            if (product == null) return NotFound();
            return View(product);
        }

        [Route("excluir-produto/{id:guid}")]
        [HttpPost, ActionName("Delete")]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var produto = await _productViewModelService.ObterProdutClientAndCategory(id);
            if (produto == null) return NotFound();

             _productViewModelService.Delete(id);

            TempData["Sucesso"] = "Produto excluido com sucesso ! ";

            return RedirectToAction(nameof(Index));
        }




        private ProductViewModel PopularityClientAndCategory(ProductViewModel productVM)
            {
                productVM.Clients = _productViewModelService.ObterTodosClientes();
                productVM.Categorys = _productViewModelService.ObterTodosCategorias();

                return productVM;
         }


     }
 }

