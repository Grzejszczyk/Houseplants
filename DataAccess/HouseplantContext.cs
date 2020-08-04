using Houseplants.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Houseplants.DataAccess
{
    public class HouseplantContext : DbContext
    {
        public HouseplantContext(DbContextOptions options) : base(options) { }
        public DbSet<Houseplant> Houseplants { get; set; }
        public DbSet<PictureHouseplant> Galleries { get; set; }
    }
}
