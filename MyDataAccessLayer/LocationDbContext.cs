 using CricketersDetails;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace MyDataAccessLayer
{
   public class LocationDbContext:DbContext
    {
        public LocationDbContext(DbContextOptions options) :base(options)
        {

        }
        public DbSet<Location> Location { get; set; }
    }
}
