using Microsoft.EntityFrameworkCore;
using to_do_list.Models;

namespace to_do_list.Data
{
    public class ApplicationDBContext : DbContext
    {
        public ApplicationDBContext(DbContextOptions<ApplicationDBContext> options) : base(options) { }

        public DbSet<Models.Task> Tasks { get; set; }
    }
}
