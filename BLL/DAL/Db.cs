using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL.DAL
{
    public class Db : DbContext
    {
        public DbSet<Artists> Artists { get; set; }
        public DbSet<Artworks> Artworks { get; set; }

        //connection string
        public Db(DbContextOptions options) : base(options)
        {
            
        }
    }
}
