using GamebudsAPI.Models;
using Microsoft.EntityFrameworkCore;

namespace GamebudsAPI.Data;

public class ApplicationDbContext : DbContext
{
    public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
    {
    }

    public DbSet<WordleWord> WordleWord { get; set; }
}