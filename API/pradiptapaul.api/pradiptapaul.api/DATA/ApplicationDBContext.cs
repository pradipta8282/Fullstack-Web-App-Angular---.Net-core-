using Microsoft.EntityFrameworkCore;
using pradiptapaul.api.Model.domain;

namespace pradiptapaul.api.DATA
{
    public class ApplicationDBContext : DbContext
    {
        public ApplicationDBContext(DbContextOptions options) : base(options)
        {
        }

        public DbSet<Blogpost> blogposts { get; set; }
        public DbSet<Category> Categories { get; set; }
    }
}
