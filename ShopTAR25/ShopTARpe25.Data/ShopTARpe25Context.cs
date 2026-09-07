using Microsoft.EntityFrameworkCore;
using ShopTAR25.Models;

namespace ShopTARpe25.Data
{
    //teha sellest classist DbContext, et saaks andmebaasi kasutada
    public class ShopTARpe25Context : DbContext
    {
        public ShopTARpe25Context(DbContextOptions<ShopTARpe25Context> options)
            : base(options)
        { }
        
        //public DbSet<>  { get; set; }
        public DbSet<ErrorViewModel> ErrorViewModel { get; set; }
              
    }
}
