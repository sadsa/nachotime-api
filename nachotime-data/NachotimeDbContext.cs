using Microsoft.EntityFrameworkCore;
using nachotime_data.Models;

namespace nachotime_data;

public class NachotimeDbContext : DbContext
{
    public NachotimeDbContext(DbContextOptions<NachotimeDbContext> options) : base(options) { }

    public DbSet<Card> Cards => Set<Card>();
    public DbSet<Expression> Expressions => Set<Expression>();
}
