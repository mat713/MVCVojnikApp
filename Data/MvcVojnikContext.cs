using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using MvcVojnik.Models;
using System.Data.Sql;

namespace MvcVojnik.Data
{
    public class MvcVojnikContext : DbContext
    {
        public MvcVojnikContext (DbContextOptions<MvcVojnikContext> options)
            : base(options)
        {
        }

        public DbSet<MvcVojnik.Models.Vojnik> Vojnik { get; set; }
    }
}
