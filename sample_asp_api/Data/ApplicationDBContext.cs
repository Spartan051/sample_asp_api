using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Options;
using sample_api.Models;

namespace sample_api.Data
{
    public class ApplicationDBContext : DbContext
    {
        public ApplicationDBContext(DbContextOptions dbContextOptions) 
        :base(dbContextOptions)
        {
        }
      
        public DbSet<Stock> Stock { get; set; }
        public DbSet<Comment> Comment { get; set; }
    }
}
