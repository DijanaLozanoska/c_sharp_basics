using BSCodeModels_Lib;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Linq;
using System.Threading.Tasks;

namespace BSCodeAPI.Data
{
    public class BSCodeDbContext : DbContext
    {
        public BSCodeDbContext([NotNullAttribute] DbContextOptions options) : base(options)
        {
        }

        public DbSet<Project> Projects { set; get; }
    }
}
