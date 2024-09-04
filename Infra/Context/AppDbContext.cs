using Domain.Models;
using Microsoft.EntityFrameworkCore;

namespace Infra.Context
{
        public class AppDbContext : DbContext
        {
            public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
            {
            }
            public DbSet<Pessoa> Pessoas { get; set; }
        }
    }