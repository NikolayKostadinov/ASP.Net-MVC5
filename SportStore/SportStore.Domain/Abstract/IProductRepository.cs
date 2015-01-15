namespace SportStore.Domain.Abstract
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using SportStore.Domain.Entities;

    public interface IProductRepository
    {
        IEnumerable<Product> Products { get; }
        void SaveProduct(Product product);
        Product DeleteProduct(int productId);
    }
}
