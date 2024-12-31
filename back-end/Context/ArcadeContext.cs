using Microsoft.EntityFrameworkCore;
using arcade.Models;

namespace arcade.ApplicationDbContext;

public class ArcadeContext: DbContext
{
    public DbSet<Player> Players { get; set; }

    public ArcadeContext(DbContextOptions options) : base (options) {}

}
