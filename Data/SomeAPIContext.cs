namespace SomeAPIAPP.Data
{
    using Microsoft.EntityFrameworkCore;
    using SomeAPIAPP.Models;

    public class SomeAPIContext: DbContext
    {
        public SomeAPIContext(DbContextOptions<SomeAPIContext> opt): base(opt)
        {
            
        }

        public DbSet<SomeAPIModel> SomeAPIs { get; set; }
    }
}