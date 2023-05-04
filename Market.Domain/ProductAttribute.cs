using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Market.Domain
{
    public class ProductAttribute : BaseEntity
    {
        public string Name { get; set; }
        public string Value { get; set; }
        public int ProductId { get; set; }
        public Product Product { get; set; }
    }
}
