using CashFlowApi.Models;
using Microsoft.EntityFrameworkCore;

namespace CashFlowApi.Repositories;

public class CashFlowDb : DbContext
{
    public CashFlowDb(DbContextOptions<CashFlowDb> options)
        : base(options) { }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
{
    modelBuilder.Entity<Entry>().ToTable(t => t.ExcludeFromMigrations());
}
}