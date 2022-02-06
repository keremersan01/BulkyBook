using BulkyBookWeb.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BulkyBookWeb.Data
{
    public class BulkyContext : DbContext
    {
        public BulkyContext(DbContextOptions<BulkyContext> options) :base(options)
        {

        }
        public DbSet<Category> Categories { get; set; }
    }
}
