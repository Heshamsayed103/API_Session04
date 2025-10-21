using Store.G04.Domain.Entities;
using Store.G04.Domain.Entities.Products;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Store.G04.Services.Specifications.Products
{
    public class ProductsWithBrandAndTypeSpecifications : BaseSpecifications<int, Product>
    {
        public ProductsWithBrandAndTypeSpecifications(int id) : base(P => P.Id == id)
        {
            ApplyInclude();
        }

        public ProductsWithBrandAndTypeSpecifications() : base(null)
        {
            ApplyInclude();

        }

        private void ApplyInclude()
        {
            Includes.Add(P => P.Brand);
            Includes.Add(P => P.Type);
        }
    }
}
