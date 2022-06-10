using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WindMeasureAPI.Models
{
    public class WindMeasureContext : DbContext
    {
        public WindMeasureContext(DbContextOptions<WindMeasureContext> options) : base(options) { }

        public DbSet<WindMeasureData> Measurements { get; set; }
    }
}
