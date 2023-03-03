using Cadastro.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Cadastro.Domain.Interfaces
{
    public interface IProductRepository 
    {
        Product Get(int id);
        IEnumerable<Product> GetAll();
        void Insert(Product client);
        void Update(Product client);
        void Delete(int id);
        Task<IEnumerable<Product>> ObterProductClient();

        Task<Product>  ObterProductClientAndCliente(int id);
      

    }
}
