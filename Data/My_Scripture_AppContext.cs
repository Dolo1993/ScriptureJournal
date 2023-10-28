using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using My_Scripture_App.Models;

namespace My_Scripture_App.Data
{
    public class My_Scripture_AppContext : DbContext
    {
        public My_Scripture_AppContext (DbContextOptions<My_Scripture_AppContext> options)
            : base(options)
        {
        }

        public DbSet<My_Scripture_App.Models.Scripture> Scripture { get; set; } = default!;
    }
}
