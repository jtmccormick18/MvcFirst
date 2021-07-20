using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using MvcFirst.Models;

    public class MvcFirstContext : DbContext
    {
        public MvcFirstContext (DbContextOptions<MvcFirstContext> options)
            : base(options)
        {
        }

        public DbSet<MvcFirst.Models.CamaSystem> CamaSystem { get; set; }

        public DbSet<MvcFirst.Models.Review> Review { get; set; }
    }
