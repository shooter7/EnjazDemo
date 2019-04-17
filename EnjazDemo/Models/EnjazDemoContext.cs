using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

using Microsoft.EntityFrameworkCore;

namespace EnjazDemo.Models
{
    public class EnjazDemoContext : DbContext
    {
        public EnjazDemoContext(DbContextOptions<EnjazDemoContext> options)
            : base(options)
        {

        }
        public EnjazDemoContext()
        {

        }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseNpgsql("Server=localhost;Port=5432;Database=PayrollForm;User Id=postgres;Password=123456;");
        }
  
        public DbSet<UserModel> UserModels { get; set; }
        public DbSet<Attachment> Attachments { get; set; }

    }
}
