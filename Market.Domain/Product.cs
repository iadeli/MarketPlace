namespace Market.Domain
{
    public class Product : BaseEntity
    {
        public int BrandId { get; set; }
        public int CategoryId { get; set; }
        public DateTime DateAdded { get; set; }
        public string Description { get; set; }
        public bool InStock { get; set; }
        public string Name { get; set; }
        public int Popularity { get; set; }
        public decimal Price { get; set; }
        public double Rating { get; set; }

        public Category Category { get; set; }
        public Brand Brand { get; set; }
        public ICollection<ProductAttribute> Attributes { get; set; }
    }
}