using Cadastro.Domain.Entities;
using Cadastro.Domain.Interfaces;
using Cadastro.Infrastructure.Data.Common;
using Cadastro.ViewModels;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Cadastro.Infrastructure.Data.Repositories
{
    public class ProductRepository : EfRepository<Product>, IProductRepository
    {
        public ProductRepository(RegisterContext dbContext)
            : base(dbContext)
        {

        }

        public async Task<IEnumerable<Product>> ObterProductClient()
        {
            return await _dbContext.Products.AsNoTracking().Include(p => p.Client).Include(p => p.Category).ToListAsync();
        }

        public async Task<Product> ObterProductClientAndCliente(int id)
        {
            return await _dbContext.Products.AsNoTracking().Include(p => p.Client).Include(p => p.Category).FirstOrDefaultAsync(p => p.Id == id);
        }
    

    }
}
