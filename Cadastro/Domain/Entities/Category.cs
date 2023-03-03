using System.Collections.Generic;

namespace Cadastro.Domain.Entities
{
    public class Category : BaseModel
    {
        public string Name { get; set; }

        /* EF Relational */
        public IEnumerable<Product> Products { get; set; }

    }
}
