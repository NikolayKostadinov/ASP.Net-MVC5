namespace SportStore.Domain.Concrete
{
    using System;
    using System.Collections.Generic;
    using System.Data.Entity;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;
    using SportStore.Domain.Entities;

    public class EFDbContext:DbContext
    {
        public DbSet<Product> Products { get; set; }
    }
}
