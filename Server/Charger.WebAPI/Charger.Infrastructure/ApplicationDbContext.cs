using Charger.Application.Common.Interfaces;
using Charger.Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace Charger.Infrastructure {

    public class ApplicationDbContext : DbContext, IApplicationDbContext {
        public DbSet<StationEntity> Stations { get; set; }

        public ApplicationDbContext(DbContextOptions options) : base(options) { }
    }

}
