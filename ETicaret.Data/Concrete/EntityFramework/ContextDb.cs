using ETicaret.Entities.Concrete;
using Microsoft.EntityFrameworkCore;

namespace ETicaret.Data.Concrete.EntityFramework
{
    public class ContextDb :DbContext
    {
        public ContextDb(DbContextOptions options):base(options)
        {

        }

        public DbSet<Product> Products { get; set; }
    }
}
