using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OrtdursGateDomain;

namespace OrtdursGateDataAccess
{
    public class OrtdursContext : DbContext
    {
        public DbSet<Character> Characters { get; set; }
        public DbSet<Item> Items { get; set; }

        public OrtdursContext()
        {

        }

        public OrtdursContext(DbContextOptions<OrtdursContext> options)
        : base(options)
        {
        }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseInMemoryDatabase(databaseName: "OrtdursGate3MemoryDb");
        }
    }
}
