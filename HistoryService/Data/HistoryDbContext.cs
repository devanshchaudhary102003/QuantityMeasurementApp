using HistoryService.Models;
using Microsoft.EntityFrameworkCore;

namespace HistoryService.Data
{
    public class HistoryDbContext : DbContext
    {
        public HistoryDbContext(DbContextOptions<HistoryDbContext> options) : base(options) { }

        public DbSet<QuantityMeasurementEntity> Quantity { get; set; }
    }
}
