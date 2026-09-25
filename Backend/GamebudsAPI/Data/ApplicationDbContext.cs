using GamebudsAPI.Models;
using Microsoft.EntityFrameworkCore;

namespace GamebudsAPI.Data;

public class ApplicationDbContext : DbContext
{
    public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
    {
    }

    public DbSet<User> Users { get; set; }

    #region Wordle
    
    public DbSet<WordleWord> WordleWord { get; set; }
    public DbSet<WordleGame> WordleGames { get; set; }
    public DbSet<WordleGuess> WordleGuesses { get; set; }

    #endregion
}
