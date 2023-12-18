
using CoreWebhook.Infrastructure.Helper;
using Microsoft.EntityFrameworkCore;

namespace CoreWebhook.Infrastructure
{
    public class ApplicationDbContext : DbContext
    {        
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options):base(options)
        {
            
        }
        
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);            
            
        }
    }
}