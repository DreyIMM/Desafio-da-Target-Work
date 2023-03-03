namespace Cadastro.Domain.Entities
{
    public class Product: BaseModel
    {
        public string Name { get; set; }
        public decimal Value { get; set; }
        public bool Active { get; set; }

        /*EF Relational */
        public int CategoryId { get; set; }
        public  Category Category { get; set; }

        public int ClienteId { get; set; }
        public  Client Client { get; set; }
    }
}