using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using TravelBug.Models;

namespace TravelBug.Data
{
    public class TravelBugContext : DbContext
    {
        public TravelBugContext (DbContextOptions<TravelBugContext> options)
            : base(options)
        {
        }

        public DbSet<TravelBug.Models.Booking> Booking { get; set; }

        public DbSet<TravelBug.Models.Destination> Destination { get; set; }

        public DbSet<TravelBug.Models.Package> Package { get; set; }

        public DbSet<TravelBug.Models.TravelCoordinator> TravelCoordinator { get; set; }

        public DbSet<TravelBug.Models.Traveler> Traveler { get; set; }
    }
}
