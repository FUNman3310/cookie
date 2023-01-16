using Microsoft.EntityFrameworkCore;

namespace AAdminPanel1.Models
{
    public class AdminContext :DbContext
    {
        public AdminContext(DbContextOptions<AdminContext> options) : base(options)
        {

        }

        public DbSet<Slider> Sliders { get; set; }

        public DbSet<Book> books { get; set; }

        public DbSet<Genre> genres { get; set; }

        public DbSet<Author> authors { get; set; }

    }
}
