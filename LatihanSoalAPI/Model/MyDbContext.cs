using Microsoft.EntityFrameworkCore;

namespace LatihanSoalAPI.Model
{
    public class MyDbContext : DbContext
    {
        public MyDbContext(DbContextOptions<MyDbContext> options) : base(options)
        {

        }
        public DbSet<MsPelanggan> MsPelanggan { get; set; }
        public DbSet<MsProduct> MsProduct { get; set; }
    }
}
